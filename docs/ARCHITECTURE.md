# Arquitetura

Três processos, um contrato. Leia `PROTOCOL.md` antes de mexer em qualquer coisa
que atravesse a fronteira.

```
┌────────────────────────────┐   IPC do Tauri    ┌──────────────────────────────┐
│ apps/web                   │  invoke/emit      │ apps/desktop (Rust)          │
│ Vite + React + TS          │ ◄===============► │  lib.rs      comandos + vida │
│  lib/bridge.ts   ──────────┤                   │  sidecar.rs  spawn/supervisão│
│  hooks/useZmqEvent         │                   │  zmq_bridge.rs  DEALER + SUB │
└────────────────────────────┘                   └───────────────┬──────────────┘
                                                                 │ ZeroMQ (loopback)
                                          DEALER ──── comandos ──┤
                                          SUB    ◄──── eventos ───┤
                                                                 │
                                                 ┌───────────────┴──────────────┐
                                                 │ services/sidecar (Python)     │
                                                 │  __main__.py  ciclo de vida   │
                                                 │  zmq/responder.py  ROUTER     │
                                                 │  zmq/publisher.py  PUB        │
                                                 │  handlers.py  dispatch único  │
                                                 │  http/app.py  FastAPI opcional│
                                                 └───────────────────────────────┘
```

## As cinco decisões que moldam o resto

### 1. O Rust é o único dono dos sockets

Navegador não fala ZeroMQ. Em vez de inventar um proxy WebSocket, o shell Tauri
abre os sockets e a UI fala IPC com ele. Consequência prática: **a UI nunca vê
um socket**, `bridge.ts` só tem `invoke` e `listen`.

### 2. ZMQ é o caminho quente; HTTP é para dev

O FastAPI existe por três motivos: `/health` para saber se o processo está vivo,
Swagger (`/docs`) para testar um método sem escrever cliente, e SSE para o modo
`dev:web`, onde não há Rust. Nenhum deles é o caminho da UI em produção.

Se você se pegar adicionando um endpoint "de verdade" no FastAPI, pare: o lugar
é um método no `Handlers` (que o HTTP também atende, de graça).

### 3. Comandos em DEALER/ROUTER; eventos em PUB/SUB

Explicado em `PROTOCOL.md`. O resumo: REQ/REP trava em pares e ignora timeout;
PUB/SUB desacopla mas tem *slow joiner* — daí o `heartbeat` periódico.

### 4. Um contrato, uma fonte da verdade

`services/sidecar/src/sidecar/protocol.py` (Pydantic) é a fonte. O TS espelha à
mão e `npm run protocol:gen` falha quando os dois divergem. O Rust não tem espelho
tipado: ele trabalha com `serde_json::Value`, porque é ponte, não modelo de
domínio.

### 5. O sidecar é efêmero e supervisionado

O Rust sobe o processo, lê o handshake, vigia a saída e reinicia com backoff
(500 ms → 8 s, desistindo depois de 5 falhas seguidas). A UI acompanha por
`zmq://sidecar` e nunca precisa perguntar "está no ar?".

Corolário: **o sidecar é descartável**. Ele não guarda estado que não possa ser
reconstruído, e a porta muda a cada reinício — por isso o Rust reconecta DEALER e
SUB em vez de assumir `tcp://127.0.0.1:5555` fixo.

## Fluxos

### Subida

1. Rust resolve como subir o Python: binário empacotado ao lado do executável →
   `uv run python -m sidecar` → `python -m sidecar`.
2. O sidecar liga o ROUTER numa porta efêmera, o PUB em `porta + 1`, e escreve
   `SIDECAR_READY {...}` em stdout.
3. Rust lê a linha, guarda o `Child`, publica as portas no canal `watch` e emite
   `zmq://sidecar` = `ready`.
4. O vigia do DEALER e a thread do SUB, que já estavam assinando esse canal,
   conectam sozinhos. Nada de handshake em duas fases.
5. O sidecar emitiria `ready` no PUB — mas o SUB pode ter chegado tarde (slow
   joiner), então o `heartbeat` é o que garante a sincronização.

### Requisição

`request("ping")` → `invoke("zmq_request", {method, params})` → Rust gera `id`,
serializa o envelope, `send` no DEALER, `recv` com timeout correlando por `id` →
resposta vira o valor de retorno da Promise. Erro remoto vira `IpcError` com o
código original do sidecar.

O socket é bloqueante: o comando do Tauri joga o trabalho em `spawn_blocking`
para não travar o runtime async. Ver o comentário de topo em `zmq_bridge.rs`.

### Evento

Sidecar `publish(topic, payload)` → frame `[topic][json]` no PUB → thread do SUB
→ `app.emit("zmq://<topic>", payload)` → `useZmqEvent("<topic>")` no React.
Todo evento também entra no `EventBus` em processo, que alimenta o SSE.

## Onde cada coisa mora

| Preocupação | Arquivo |
|---|---|
| Tabela de métodos (fonte da verdade) | `services/sidecar/src/sidecar/handlers.py` |
| Envelope e modelos | `services/sidecar/src/sidecar/protocol.py` |
| Configuração (`SIDECAR_*`) | `services/sidecar/src/sidecar/config.py` |
| Ciclo de vida do processo | `services/sidecar/src/sidecar/__main__.py` |
| Fan-out de evento em processo | `services/sidecar/src/sidecar/events.py` |
| Spawn, handshake, supervisão | `apps/desktop/src-tauri/src/sidecar.rs` |
| DEALER + thread do SUB | `apps/desktop/src-tauri/src/zmq_bridge.rs` |
| Comandos do IPC e limpeza | `apps/desktop/src-tauri/src/lib.rs` |
| Ponte única UI → backend | `apps/web/src/lib/bridge.ts` |
| Tipos do contrato | `packages/protocol/src/index.ts` |

## Armadilhas que já custaram tempo

- **`zmq.asyncio` não roda no `ProactorEventLoop`** (padrão do Windows). O erro
  só aparece quando algo tenta ler:
  `RuntimeError: Proactor event loop does not implement add_reader family of
  methods required for zmq`. `__main__.py` força `SelectorEventLoop` e
  `tests/conftest.py` faz o mesmo. Detalhes em `RUNBOOK.md`.
- **PUB/SUB perde o que foi publicado antes do handshake.** Não use um evento
  único como sinal de sincronização; use o `heartbeat`.
- **Holding o `Mutex` do socket durante um `await`** trava o executor. Por isso o
  socket é `std::sync::Mutex` e vive só dentro de `spawn_blocking`.
- **`asyncio.Queue` não expõe o loop antes do primeiro `await`.** O `EventBus`
  guarda `fila → loop` no `subscribe()` porque o loop do SSE e o loop principal
  são objetos diferentes.

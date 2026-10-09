# Arquitetura

Dois frontends, um serviço, um arquivo e dois contratos.

Leia `PROTOCOL.md` antes de mexer em qualquer coisa que atravesse a fronteira ZMQ,
e `POSITRON.md` para o modelo de domínio elétrico e integração com o CAD.

```text
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
                                                 │  db/project.py SQLite (leitura)│
                                                 └───────────────┬──────────────┘
                                                                 │
                                                                 │ SQLite (.db)
                                                       PRAGMA journal_mode=WAL
                                                                 │
                                                 ┌───────────────┴──────────────┐
                                                 │ cad-plugin (C# net472)        │
                                                 │  DENTRO do ZWCAD / AutoCAD    │
                                                 │  Positron.Plugin (NETLOAD)    │
                                                 │  Positron.Data (escrita .db)  │
                                                 │  DWG + XData (quem desenha)   │
                                                 └───────────────────────────────┘
```

## As sete decisões que moldam o resto

### 1. Dois frontends desacoplados e especializados

O sistema é composto por dois frontends que rodam em runtimes diferentes e
**não compartilham processo**:
- **Frontend App (Positron):** Tauri (Rust) + React/TS + sidecar Python. Gerencia o
  projeto, painéis, réguas, catálogos e relatórios. Não tem ZWCAD/AutoCAD no seu processo.
- **Frontend CAD (`cad-plugin`):** Assembly C# (.NET Framework 4.7.2) carregado via
  `NETLOAD` dentro do processo do CAD (ZWCAD ou AutoCAD). Só ele tem acesso à API gráfica
  (`ZwSoft.ZwCAD.*` / `Autodesk.AutoCAD.*`), entidades e XData.

### 2. Não há IPC entre o CAD e o App: a integração é o arquivo SQLite

O plugin CAD **não** é cliente ZeroMQ nem depende do app Positron estar aberto para
que o projetista trabalhe no desenho. O único ponto de integração entre os dois é o
**banco de dados SQLite do projeto (`.db`)**, configurado com **`PRAGMA journal_mode=WAL`**
e `busy_timeout = 5000`. Isso permite que o app leia dados concorrentemente sem travar o
plugin no meio de um comando de desenho.

### 3. Quem desenha, grava (domínio exclusivo das tabelas)

Para evitar conflito de escrita (*dual-write*):
- O plugin CAD projeta `DWG + XData → tabelas` e é o **único autor** das tabelas derivadas
  do diagrama funcional (`Fiacao`, `Interligacao4`, `Bornes4F`, `Portas4F`, etc.).
- O sidecar Python do app administra os metadados do projeto, réguas e catálogos, e
  **apenas lê** as tabelas derivadas da fiação. O app nunca edita o diagrama funcional.

### 4. O Rust é o único dono dos sockets no App Desktop

Navegador não fala ZeroMQ. Em vez de inventar um proxy WebSocket, o shell Tauri
abre os sockets e a UI fala IPC com ele. Consequência prática: **a UI nunca vê
um socket**, `bridge.ts` só tem `invoke` e `listen`.

### 5. ZMQ é o caminho quente do App; HTTP é para dev

O FastAPI existe por três motivos: `/health` para saber se o processo está vivo,
Swagger (`/docs`) para testar um método sem escrever cliente, e SSE para o modo
`dev:web`, onde não há Rust. Nenhum deles é o caminho da UI em produção.

Se você se pegar adicionando um endpoint "de verdade" no FastAPI, pare: o lugar
é um método no `Handlers` (que o HTTP também atende, de graça).

### 6. Dois contratos estritos e versionados

O sistema mantém duas fronteiras de tipos fortemente tipadas:
1. **Contrato RPC/Eventos (App ↔ Sidecar):** `services/sidecar/src/sidecar/protocol.py`
   (Pydantic) é a fonte. O TypeScript espelha em `packages/protocol/src/index.ts`.
2. **Contrato de Dados do Projeto (Schema SQLite):** `services/sidecar/src/sidecar/db/schema.sql`
   é a fonte da verdade para o banco. `scripts/gen-schema.mjs` gera automaticamente os tipos
   para TypeScript (`schema.generated.ts`) e C# (`packages/protocol/csharp/Tables.g.cs`).
   `npm run protocol:gen` falha no CI se qualquer lado divergir. O Rust não tem espelho tipado:
   ele trabalha com `serde_json::Value`, porque é ponte, não modelo de domínio.

### 7. O sidecar é efêmero e supervisionado

O Rust sobe o processo do sidecar, lê o handshake (`SIDECAR_READY`), vigia a saída e
reinicia com backoff (500 ms → 8 s, desistindo após 5 falhas seguidas). A UI acompanha por
`zmq://sidecar` e nunca precisa perguntar "está no ar?".

Corolário: **o sidecar é descartável**. Ele não guarda estado que não possa ser
reconstruído, e a porta muda a cada reinício — por isso o Rust reconecta DEALER e
SUB em vez de assumir `tcp://127.0.0.1:5555` fixo.

## Fluxos

### Subida do App Desktop

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

### Requisição da UI (App)

`request("ping")` → `invoke("zmq_request", {method, params})` → Rust gera `id`,
serializa o envelope, `send` no DEALER, `recv` com timeout correlando por `id` →
resposta vira o valor de retorno da Promise. Erro remoto vira `IpcError` com o
código original do sidecar.

O socket é bloqueante: o comando do Tauri joga o trabalho em `spawn_blocking`
para não travar o runtime async. Ver o comentário de topo em `zmq_bridge.rs`.

### Evento do Sidecar (App)

Sidecar `publish(topic, payload)` → frame `[topic][json]` no PUB → thread do SUB
→ `app.emit("zmq://<topic>", payload)` → `useZmqEvent("<topic>")` no React.
Todo evento também entra no `EventBus` em processo, que alimenta o SSE.

### Projeção e Gravação CAD (`cad-plugin`)

1. O projetista carrega o plugin no ZWCAD ou AutoCAD via `NETLOAD`.
2. Ao disparar os comandos de projeção — `FIA` (fiação), `INT` (interligação) ou
   `SYNCD` (o desenho inteiro) —, o plugin varre as entidades gráficas e lê os
   registros XData (`CONEXAO`, `Dispositivo`, etc.). O `VERIF` é read-only: valida
   as tabelas já gravadas (fiação, interligação e modelos).
3. O núcleo puro (`Positron.Data`) calcula as conexões, resolve regras/modelos e grava
   diretamente no `.db` apontado por `POSITRON_DB_PATH`.
4. A transação usa WAL: operações de leitura no Positron Desktop continuam operando
   sem causar `database is locked` no CAD.

## Onde cada coisa mora

| Preocupação | Arquivo / Pasta |
|---|---|
| Tabela de métodos (fonte da verdade) | `services/sidecar/src/sidecar/handlers.py` |
| Envelope e modelos RPC | `services/sidecar/src/sidecar/protocol.py` |
| Schema mestre do banco de dados | `services/sidecar/src/sidecar/db/schema.sql` |
| Acesso e queries do BD no sidecar | `services/sidecar/src/sidecar/db/` |
| Configuração (`SIDECAR_*`) | `services/sidecar/src/sidecar/config.py` |
| Ciclo de vida do processo sidecar | `services/sidecar/src/sidecar/__main__.py` |
| Fan-out de evento em processo | `services/sidecar/src/sidecar/events.py` |
| Spawn, handshake, supervisão do sidecar | `apps/desktop/src-tauri/src/sidecar.rs` |
| DEALER + thread do SUB | `apps/desktop/src-tauri/src/zmq_bridge.rs` |
| Comandos do IPC e limpeza | `apps/desktop/src-tauri/src/lib.rs` |
| Ponte única UI → backend | `apps/web/src/lib/bridge.ts` |
| Tipos do contrato RPC (TS) | `packages/protocol/src/index.ts` |
| Tipos do schema do banco (TS) | `packages/protocol/src/schema.generated.ts` |
| Tipos do schema do banco (C#) | `packages/protocol/csharp/Tables.g.cs` |
| Frontend CAD: comandos e host ZWCAD/AutoCAD | `cad-plugin/Positron.Plugin/` |
| Frontend CAD: domínio e SQLite puro | `cad-plugin/Positron.Data/` |
| Frontend CAD: stub de compilação sem CAD | `cad-plugin/Positron.CadStub/` |

## Armadilhas que já custaram tempo

- **`zmq.asyncio` não roda no `ProactorEventLoop`** (padrão do Windows). O erro
  só aparece quando algo tenta ler:
  `RuntimeError: Proactor event loop does not implement add_reader family of methods required for zmq`.
  `__main__.py` força `SelectorEventLoop` e `tests/conftest.py` faz o mesmo. Detalhes em `RUNBOOK.md`.
- **SQLite sem WAL bloqueia o CAD.** Sem `PRAGMA journal_mode=WAL` e `busy_timeout=5000`,
  a conexão longa de leitura do app trava comandos do plugin no meio de um comando de desenho.
- **PUB/SUB perde o que foi publicado antes do handshake.** Não use um evento
  único como sinal de sincronização; use o `heartbeat`.
- **Holding o `Mutex` do socket durante um `await`** trava o executor. Por isso o
  socket é `std::sync::Mutex` e vive só dentro de `spawn_blocking`.
- **`asyncio.Queue` não expõe o loop antes do primeiro `await`.** O `EventBus`
  guarda `fila → loop` no `subscribe()` porque o loop do SSE e o loop principal
  são objetos diferentes.
- **C# do plugin é net472 / C# 7.3.** Os hosts ZWCAD e AutoCAD rodam sobre o
  .NET Framework clássico. O código não pode usar features modernas de linguagem
  (como nullable reference types `string?`, records ou `init`). Por isso os tipos
  em `Tables.g.cs` são classes convencionais com properties `get; set;`.
- **`NETLOAD` exige assemblies do CAD.** Em máquinas de build/CI sem ZWCAD ou
  AutoCAD instalados, o projeto compila contra o stub (`Positron.CadStub`). A DLL
  gerada com stub serve apenas como gate de compilação e não deve ser carregada no CAD.

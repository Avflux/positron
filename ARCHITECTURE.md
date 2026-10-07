# Arquitetura (resumo de uma tela)

Detalhamento em `docs/ARCHITECTURE.md`. Protocolo em `docs/PROTOCOL.md`.

## Decisões

1. **ZMQ é o barramento principal**, não o HTTP. O FastAPI existe para health-check,
   Swagger e o modo `dev:web` — não é o caminho quente da UI.
2. **O Rust é o dono dos sockets.** `zmq_bridge.rs` mantém DEALER (comandos) e SUB
   (eventos). O React nunca vê um socket.
3. **Comandos usam DEALER/ROUTER, não REQ/REP.** REQ/REP casa um-para-um, não tem
   timeout e trava para sempre com uma resposta perdida. DEALER/ROUTER permite
   correlação por `id` e desistência.
4. **Eventos usam PUB/SUB** — `[tópico][json]` — com `heartbeat` periódico para
   cobrir o *slow joiner*.
5. **Um contrato, uma fonte da verdade:** `services/sidecar/src/sidecar/protocol.py`
   (Pydantic). `packages/protocol` espelha em TS e `npm run protocol:gen` falha
   quando divergem. O Rust trabalha com `serde_json::Value`: é ponte, não modelo.
6. **O sidecar é efêmero e supervisionado.** Se cair, o Rust reinicia com backoff
   (500 ms → 8 s, desistindo após 5 falhas seguidas) e emite `zmq://sidecar` a
   cada transição. Em produção ele é um binário PyInstaller declarado como
   `externalBin`.

## Fluxos

### Subida

1. O Rust resolve como subir o Python: binário empacotado ao lado do executável →
   `uv run python -m sidecar` → `python -m sidecar`.
2. O sidecar escolhe uma **porta efêmera**, liga o ROUTER nela e o PUB em
   `porta + 1`, e escreve uma linha em stdout:
   `SIDECAR_READY {"pid":...,"zmq_port":...,"pub_port":...}`.
3. O Rust lê a linha, publica as portas num canal `watch` e emite
   `zmq://sidecar` = `ready`. O vigia do DEALER e a thread do SUB, que já
   assinavam esse canal, conectam sozinhos.

Quem escolhe a porta é o sidecar, não o Rust: assim não existe a corrida de
"achar uma porta livre, fechar e passar adiante".

### Requisição

`React invoke("zmq_request", {method, params})` → Rust gera `id`, envia o envelope
ao ROUTER e espera a resposta com o mesmo `id` (timeout de 10 s), resolvendo a
Promise. O socket é bloqueante, então o trabalho roda em `spawn_blocking`.

### Evento

Sidecar publica `{topic, payload}` → SUB do Rust → `emit("zmq://" + topic, payload)`
→ `useZmqEvent(topic)` no React.

## Portas e ambiente

| Variável | Padrão | Descrição |
|---|---|---|
| `SIDECAR_ZMQ_HOST` | `127.0.0.1` | Bind do ROUTER/PUB (loopback) |
| `SIDECAR_ZMQ_PORT` | `0` | Porta do ROUTER (`0` = efêmera; PUB usa +1) |
| `SIDECAR_HTTP_ENABLED` | `true` | Liga/desliga o FastAPI |
| `SIDECAR_HTTP_PORT` | `8765` | FastAPI (dev) |
| `SIDECAR_LOG_LEVEL` | `INFO` | Nível do log (vai para stderr) |
| `SIDECAR_HEARTBEAT_SECONDS` | `15` | Intervalo do `heartbeat` (0 desliga) |
| `VITE_HTTP_BASE` | `http://127.0.0.1:8765` | Base do FastAPI no modo navegador |

## Por que não HTTP para tudo?

Streaming de eventos, múltiplos assinantes e desacoplamento de transporte não
cabem bem em request/response. O HTTP continua útil porque tem Swagger, funciona
no navegador puro e serve de fallback de diagnóstico — mas quem atende os dois é o
mesmo `Handlers.dispatch`, então não há duplicação de lógica.

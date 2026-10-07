# sidecar (Python)

Serviço de fundo do app. Fala **ZeroMQ** como transporte principal e expõe um
**FastAPI** opcional para health-check, Swagger e o modo `dev:web` (navegador).

## Sockets

| Socket | Padrão | Par do outro lado |
|---|---|---|
| `ROUTER` | bind `tcp://HOST:PORT` | `DEALER` no Rust — comandos |
| `PUB` | bind `tcp://HOST:PORT+1` | `SUB` no Rust — eventos |

**Quem escolhe a porta é este processo**, não o Rust. Com `--port 0` (o padrão) o SO
dá uma porta livre, e o sidecar avisa o pai por stdout depois de ligar os sockets:

```
SIDECAR_READY {"pid":14244,"version":"0.1.0","zmq_port":51082,"pub_port":51083}
```

Uma linha, flush imediato, e nada mais nunca é escrito em stdout — todo o log vai
para stderr justamente para não sujar esse canal. O Rust lê a linha para saber
onde conectar (ver `apps/desktop/src-tauri/src/sidecar.rs`).

Escolher a porta aqui e não no Rust elimina a corrida de "achar uma porta livre,
fechar e passar adiante": entre o teste e o bind, outro processo pode pegá-la.

## Rodar

```bash
uv sync
uv run python -m sidecar                      # portas efêmeras, HTTP em 8765
uv run python -m sidecar --port 5555          # ROUTER fixo (PUB em 5556)
uv run python -m sidecar --no-http            # só ZMQ
uv run python -m sidecar --log-level DEBUG
```

Ou da raiz do repositório: `npm run sidecar:run`.

## Testar

```bash
uv run pytest -q          # ou, da raiz: npm run test:sidecar
```

`tests/test_roundtrip.py` sobe ROUTER e PUB **reais** e fala com eles por um
DEALER e um SUB de verdade — é o teste que prova que o protocolo fecha. Sem
mock de socket: um mock aqui não provaria nada.

## HTTP (opcional)

| Rota | Uso |
|---|---|
| `GET /health` | liveness |
| `GET /rpc/{method}` | debug manual no navegador |
| `POST /rpc/{method}` | mesmo `dispatch` do ZMQ, sem socket |
| `GET /events` | SSE dos eventos publicados (usado pelo modo navegador) |

O formato do HTTP **não** é o envelope do ZMQ: é `{"ok":true,"result":{...}}`, ou
`{"ok":false,"error":{...}}` com HTTP 400. São dois públicos diferentes — a UI em
produção fala ZMQ.

## Estrutura

| Arquivo | Papel |
|---|---|
| `__main__.py` | ciclo de vida: sockets, heartbeat, sinais, thread do HTTP |
| `protocol.py` | envelope, modelos e erros — **a fonte da verdade do contrato** |
| `handlers.py` | tabela de métodos; o `dispatch` que ZMQ e HTTP compartilham |
| `config.py` | `Settings` (prefixo `SIDECAR_`) |
| `events.py` | `EventBus` em processo, seguro entre threads (alimenta o SSE) |
| `zmq/responder.py` | ROUTER: recebe envelopes e responde |
| `zmq/publisher.py` | PUB: publica eventos também no `EventBus` |
| `tools/` | utilitários de build/CI (não fazem parte do pacote) |

## Contrato

`src/sidecar/protocol.py` é a **fonte da verdade**. O espelho TS está em
`packages/protocol/src/index.ts`, e `npm run protocol:gen` (na raiz) falha quando
os dois divergem.

## Notas

- No **Windows**, o loop principal é criado como `SelectorEventLoop`: o
  `zmq.asyncio` não funciona no `ProactorEventLoop` padrão. Ver `docs/RUNBOOK.md`.
- O **loop do FastAPI** roda numa thread própria e não usa ZMQ — lá o loop padrão
  serve. Os dois publicam no mesmo `EventBus`, que é seguro entre threads.

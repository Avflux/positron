# Protocolo

Contrato entre **Rust** (dono dos sockets), **Python** (o sidecar) e — por tabela —
a UI. A fonte da verdade é `services/sidecar/src/sidecar/protocol.py`; o espelho em
TypeScript é `packages/protocol/src/index.ts`. Os dois são conferidos por
`npm run protocol:gen`.

## Versão

`PROTOCOL_VERSION = 1`. Todo envelope carrega `v`. O Python tipa o campo como
`Literal[1]`, então um envelope com `v` diferente é **recusado** com
`bad_request` — fail fast em vez de interpretar campos que talvez tenham mudado
de significado.

Para evoluir o protocolo: mude a constante nos dois lados, rode
`npm run protocol:gen`, e trate a migração no Rust. Nada de negociação de versão
em runtime enquanto houver um único cliente.

## Transporte

| Uso | Socket | Endereço |
|---|---|---|
| Comandos (request/response) | Rust `DEALER` → Python `ROUTER` | `tcp://127.0.0.1:<zmq_port>` |
| Eventos (pub/sub) | Python `PUB` → Rust `SUB` | `tcp://127.0.0.1:<zmq_port + 1>` |

Sempre loopback. O sidecar não escuta na rede.

### Por que DEALER/ROUTER e não REQ/REP

REQ/REP amarra um pedido a exatamente uma resposta e não tem timeout: uma resposta
perdida deixa o socket travado nesse estado para sempre. Com DEALER cada envelope
carrega `id`, então dá para correlacionar, ignorar resposta atrasada e desistir
com `rcvtimeo`. O ROUTER também aceita vários clientes, o que é o que permite
testes e ferramentas de debug conectarem ao mesmo tempo que o app.

### Por que PUB/SUB para eventos

PUB/SUB desacopla emissor e receptor: o sidecar publica `heartbeat` a cada 15 s
sem saber se alguém está ouvindo, e um assinante novo se sincroniza sozinho. O
custo é o **slow joiner**: mensagens publicadas antes do handshake do SUB são
perdidas (PUB descarta quem não está conectado). É por isso que existe o
`heartbeat` — o `ready` pode se perder, a batida não.

## Envelopes (ZMQ)

Um frame único, JSON UTF-8. A resposta sai pelo mesmo socket, então o
`DEALER` a recebe.

### Requisição (Rust → Python)

```json
{ "v": 1, "id": "7", "method": "ping", "params": {} }
```

`ts` é opcional: o Python preenche com o horário UTC se faltar. O Rust omite.

### Resposta (Python → Rust)

Sucesso:

```json
{ "v": 1, "id": "7", "ok": true, "result": { "service": "sidecar", "version": "0.1.0", "pid": 14244, "ts": "2026-10-07T01:55:04.317616Z", "served": 1 }, "error": null }
```

Falha:

```json
{ "v": 1, "id": "7", "ok": false, "result": null, "error": { "code": "unknown_method", "message": "método desconhecido: 'foo'", "detail": null } }
```

`result` e `error` vêm sempre presentes (a serialização é do modelo Pydantic
inteiro) e exatamente um dos dois é `null`. Não confie em ausência de chave.

Toda falha de domínio é resposta com `ok: false`, nunca silêncio nem queda de
conexão: o loop do ROUTER captura qualquer exceção e responde `internal`.

### Evento (Python → Rust)

Dois frames: `[tópico][json]`. O SUB assina todos os tópicos e o Rust usa o
primeiro frame como nome do evento.

```json
{ "v": 1, "topic": "heartbeat", "payload": { "ts": "2026-10-07T01:55:05.001Z", "served": 3 }, "ts": "2026-10-07T01:55:05.001Z" }
```

O Rust reemite para a UI **apenas o `payload`**, em `zmq://<topic>`.

## Métodos

| Método | `params` | `result` |
|---|---|---|
| `ping` | `{}` | `{ service, version, pid, ts, served }` |
| `echo` | `{ message: string, repeat?: 1..100 }` | `{ message, count }` |

`served` conta quantos comandos o processo já atendeu. O contador é incrementado
**antes** de o handler rodar, então o primeiro `ping` de uma sessão já reporta
`served: 1`.

## Eventos

| Tópico | `payload` | Quando |
|---|---|---|
| `ready` | `PingResult` | logo depois de os sockets subirem |
| `heartbeat` | `{ ts, served }` | a cada `SIDECAR_HEARTBEAT_SECONDS` (padrão 15 s) |
| `sidecar` | `SidecarStatus` | a cada transição do processo (**emitido pelo Rust**) |

`ready` e `heartbeat` vêm do Python. `sidecar` **não** vem: quem sabe se o
processo está vivo é o Rust, e ele emite `starting` / `ready` / `exited` /
`error` / `stopped`. O tipo correspondente (`SidecarStatus`) mora no
`packages/protocol` mas sua fonte da verdade é
`apps/desktop/src-tauri/src/sidecar.rs`.

## Códigos de erro

Produzidos pelo Python (`error.code` no envelope):

| Código | Significado |
|---|---|
| `bad_request` | o envelope não é JSON ou não bate com o schema / versão |
| `unknown_method` | `method` não está na tabela do `Handlers` |
| `bad_params` | `params` não validou; `error.detail` traz os erros do Pydantic |
| `internal` | exceção inesperada dentro de um handler |

Produzidos pela ponte em Rust (`IpcError.code`, que atravessa o `invoke`):

| Código | Significado |
|---|---|
| `not_connected` | o DEALER ainda não conectou (sidecar subindo) |
| `timeout` | o sidecar não respondeu em 10 s |
| `zmq` / `bad_response` | falha no socket ou resposta ilegível |
| (código do sidecar) | erros remotos passam com o código original, para a UI distinguir `unknown_method` de `timeout` |

## Handshake de processo

O sidecar não conhece a porta de antemão: **ele escolhe uma porta efêmera e
avisa**. Isso elimina a corrida do "achar uma porta livre, fechar, passar
adiante" (entre o teste e o bind, outro processo pode pegar a mesma porta).

Depois de ligar ROUTER e PUB, o Python escreve **uma linha** em stdout e dá
flush:

```
SIDECAR_READY {"pid":14244,"version":"0.1.0","zmq_port":51082,"pub_port":51083}
```

O Rust lê essa linha, conecta o DEALER em `zmq_port` e o SUB em `pub_port`, e só
então importa o resto. Todo o log do Python vai para **stderr**, justamente para
não sujar esse canal.

Passar `--port <n>` força a porta; sem isso (ou com `0`) o SO escolhe.

## Rota HTTP (só em dev)

O FastAPI existe para `/health`, Swagger e o modo navegador (`dev:web`). **O
formato é diferente do ZMQ** — não tem envelope:

| Rota | Resposta |
|---|---|
| `GET /health` | `{"status":"ok","version":"0.1.0","served":3}` |
| `GET /rpc/{method}` | `{"ok":true,"result":{...}}` |
| `POST /rpc/{method}` | idem, com `params` no corpo JSON |
| `GET /events` | SSE: `event: <topic>` + `data: <envelope JSON>` |

Erro: `{"ok":false,"error":{"code":"...","message":"..."}}` com HTTP 400.

O `dispatch` é o mesmo do ZMQ (`handlers.py`), então um método novo não precisa
ser registrado duas vezes.

## Como adicionar um método

1. `services/sidecar/src/sidecar/handlers.py` — adicione ao `_table` e escreva o
   handler. Modelos de `params`/`result` vão em `protocol.py`.
2. `packages/protocol/src/index.ts` — adicione o tipo em `MethodMap`.
3. `npm run protocol:gen` — tem que sair com 0.
4. Nada a fazer no Rust: `zmq_request` é genérico e passa o `method` adiante.
5. Na UI: `request("seu_metodo", { ... })` já vem tipado.

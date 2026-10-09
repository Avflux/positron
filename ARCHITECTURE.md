# Arquitetura (resumo de uma tela)

Detalhamento em `docs/ARCHITECTURE.md`. Protocolo em `docs/PROTOCOL.md`. Domínio e CAD em `docs/POSITRON.md`.

## Decisões

1. **Dois frontends especializados:** App Desktop (Tauri/React + sidecar Python) e
   Plugin CAD (`cad-plugin` C# net472 dentro do ZWCAD/AutoCAD via `NETLOAD`).
2. **Integração por arquivo SQLite (WAL):** Não há IPC/ZMQ entre o CAD e o App.
   A integração é o banco `.db` do projeto com `PRAGMA journal_mode=WAL` e `busy_timeout=5000`.
3. **Quem desenha, grava:** O plugin CAD é o único autor das tabelas derivadas do
   diagrama funcional (`Fiacao`, `Interligacao4`, etc.). O sidecar Python do app administra
   metadados/catálogos e apenas lê as tabelas de fiação.
4. **ZMQ é o barramento interno do App Desktop**, não o HTTP. O FastAPI existe para health-check,
   Swagger e o modo `dev:web` — não é o caminho quente da UI.
5. **O Rust é o dono dos sockets.** `zmq_bridge.rs` mantém DEALER (comandos) e SUB
   (eventos). O React nunca vê um socket.
6. **Comandos usam DEALER/ROUTER, não REQ/REP.** REQ/REP casa um-para-um, não tem
   timeout e trava para sempre com uma resposta perdida. DEALER/ROUTER permite
   correlação por `id` e desistência.
7. **Eventos usam PUB/SUB** — `[tópico][json]` — com `heartbeat` periódico para
   cobrir o *slow joiner*.
8. **Dois contratos versionados:**
   - RPC/Eventos: `protocol.py` (Pydantic) ↔ `packages/protocol/src/index.ts` (TS).
   - Schema de Dados: `schema.sql` ↔ TS (`schema.generated.ts`) e C# (`Tables.g.cs`).
   `npm run protocol:gen` valida a consistência de ambos.
9. **O sidecar é efêmero e supervisionado.** Se cair, o Rust reinicia com backoff
   (500 ms → 8 s, desistindo após 5 falhas seguidas) e emite `zmq://sidecar` a
   cada transição. Em produção ele é um binário PyInstaller declarado como
   `externalBin`.

## Fluxos

### Subida (App)

1. O Rust resolve como subir o Python: binário empacotado ao lado do executável →
   `uv run python -m sidecar` → `python -m sidecar`.
2. O sidecar escolhe uma **porta efêmera**, liga o ROUTER nela e o PUB em
   `porta + 1`, e escreve uma linha em stdout:
   `SIDECAR_READY {"pid":...,"zmq_port":...,"pub_port":...}`.
3. O Rust lê a linha, publica as portas num canal `watch` e emite
   `zmq://sidecar` = `ready`. O vigia do DEALER e a thread do SUB conectam sozinhos.

### Requisição (App)

`React invoke("zmq_request", {method, params})` → Rust gera `id`, envia o envelope
ao ROUTER e espera a resposta com o mesmo `id` (timeout de 10 s), resolvendo a
Promise. O socket é bloqueante, então o trabalho roda em `spawn_blocking`.

### Evento (App)

Sidecar publica `{topic, payload}` → SUB do Rust → `emit("zmq://" + topic, payload)`
→ `useZmqEvent(topic)` no React.

### Projeção CAD (`cad-plugin`)

Comandos `FIA`/`INT`/`SYNCD` (projeção) e `VERIF` (validação read-only) no CAD →
lê entidades e XData do DWG → `Positron.Data` grava direto no SQLite
(`POSITRON_DB_PATH`) em WAL → App Desktop lê concorrentemente sem lock.

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
| `POSITRON_DB_PATH` | - | Caminho do `.db` SQLite consumido pelo `cad-plugin` |

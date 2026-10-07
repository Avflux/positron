# positron

Esqueleto de **app desktop com sidecar**: janela **Tauri** (Rust) + UI
**Vite/React/TypeScript** + serviço **Python (FastAPI + pyzmq)** conversando por
**ZeroMQ**.

> O nome da pasta é `positron`, mas o shell escolhido é **Tauri**.
> Para renomear: `mv positron tauri-zmq-starter` (e ajuste `name` nos
> `package.json`).

Serve como base para um projeto maior: a estrutura, os contratos e as decisões
difíceis já estão resolvidos, e o que sobrou de arbitrário está comentado no
lugar onde foi decidido.

## Como as peças conversam

```text
┌──────────────────────────┐   IPC do Tauri (invoke/emit)  ┌──────────────────────────┐
│  apps/web                │ <===========================> │  apps/desktop            │
│  Vite + React + TS       │                               │  Tauri (Rust)            │
└──────────────────────────┘                               │   ├─ sidecar.rs  (spawn) │
                                                           │   └─ zmq_bridge.rs       │
                                                           └───────────┬──────────────┘
                                                                       │ ZeroMQ (loopback)
                                                     DEALER (req) <────┤────> ROUTER  (Python)
                                                     SUB   (evt) <─────┴─────> PUB     (Python)
                                                                       │
                                                           ┌───────────┴──────────────┐
                                                           │  services/sidecar        │
                                                           │  Python + FastAPI + pyzmq│
                                                           └──────────────────────────┘
```

O navegador não fala ZeroMQ, então **o Rust é o único dono dos sockets** e o React
conversa por IPC. O HTTP do sidecar existe só para *dev*, health-check e Swagger —
o caminho de produção é ZMQ.

## Estrutura

| Caminho | Papel |
|---|---|
| `apps/web/` | UI Vite + React + TypeScript |
| `apps/desktop/src-tauri/` | Shell Tauri, spawn do sidecar e bridge ZMQ |
| `services/sidecar/` | Serviço Python (ROUTER + PUB) + FastAPI opcional |
| `packages/protocol/` | Tipos do contrato compartilhado (TS). `apps/web` não o declara como dependência: `@protocol` é um alias de caminho no `tsconfig.json`/`vite.config.ts` |
| `scripts/` | Empacotamento do sidecar e checagem do contrato |
| `docs/` | `ARCHITECTURE.md`, `PROTOCOL.md`, `RUNBOOK.md` |

**Leia `docs/ARCHITECTURE.md` e `docs/PROTOCOL.md` antes de mexer.** O
`docs/RUNBOOK.md` tem os pré-requisitos, os comandos e um troubleshooting que já
sabe dos problemas chatos (o principal: `zmq.asyncio` e o loop do Windows).

## Começando

```bash
npm install                                        # 1) deps JS (web, desktop, protocol)
npm run sidecar:sync                               # 2) deps Python
npm run protocol:gen                               # 3) contrato em sincronia
npm run test:sidecar                               # 4) round-trip ZMQ de verdade
npm run dev                                        # 5) app completo (Vite + Tauri)
```

Se o **Rust** ainda não estiver instalado, `npm run dev` baixa e executa o
instalador oficial do Rust stable automaticamente. É necessário ter conexão com a
internet na primeira execução; outras dependências nativas do Tauri, como o
compilador C/C++ no Windows, ainda precisam estar instaladas.

## Scripts (raiz)

| Script | O que faz |
|---|---|
| `npm run dev` | verifica/instala o Rust se necessário e inicia Vite + `tauri dev` em paralelo; o Tauri sobe o sidecar |
| `npm run dev:web` | só a UI no navegador — ela usa o FastAPI do sidecar automaticamente |
| `npm run build` | build do web → `apps/web/dist` |
| `npm run build:desktop` | build do web + `tauri build` (empacota o app) |
| `npm run typecheck` | `tsc --noEmit` em todos os workspaces TS |
| `npm run test:sidecar` | `pytest` do sidecar, com sockets reais |
| `npm run sidecar:sync` | `uv sync` do ambiente Python |
| `npm run sidecar:run` | roda só o sidecar (`python -m sidecar`) |
| `npm run sidecar:build` | empacota o sidecar com PyInstaller (para o app distribuir) |
| `npm run protocol:gen` | falha se Python e TS divergirem no contrato |

## Estado atual

O **sidecar Python, o contrato e a UI são funcionais e verificados**: 7 testes de
round-trip com sockets reais, handshake de processo ponta a ponta, `typecheck`
limpo e build do web gerando `dist/`.

O que **não** foi verificado: o **código Rust nunca foi compilado** — Rust não
está instalado na máquina onde este esqueleto foi montado. O job `desktop` do CI
roda `cargo check` e é onde isso aparece primeiro. A lista completa do que foi e
do que não foi executado está no fim de `docs/RUNBOOK.md`.

## O que trocar primeiro

Estes são os pontos deliberadamente arbitrários, cada um isolado:

| Quero | Onde |
|---|---|
| Adicionar um método do backend | `services/sidecar/src/sidecar/handlers.py` (+ `packages/protocol` e `npm run protocol:gen`) |
| Trocar a porta/nível de log do sidecar | variáveis `SIDECAR_*` — `services/sidecar/src/sidecar/config.py` |
| Mudar o intervalo do heartbeat | `SIDECAR_HEARTBEAT_SECONDS` |
| Ícones e identidade do app | `apps/desktop/src-tauri/icons/README.md` e `identifier` no `tauri.conf.json` |
| CSP em produção | hoje `null` em `tauri.conf.json`; aperte antes de distribuir |

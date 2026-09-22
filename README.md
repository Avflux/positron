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
| `scripts/` | Empacotamento do sidecar, bootstrap de dev e checagem do contrato |
| `docs/` | `ARCHITECTURE.md`, `PROTOCOL.md`, `RUNBOOK.md` |

**Leia `docs/ARCHITECTURE.md` e `docs/PROTOCOL.md` antes de mexer.** O
`docs/RUNBOOK.md` tem os pré-requisitos, os comandos e um troubleshooting que já
sabe dos problemas chatos (o principal: `zmq.asyncio` e o loop do Windows).

## Começando

### Desenvolvimento

Um único comando cuida de tudo:

```bash
npm run dev
```

Ele prepara o ambiente automaticamente (em sequência, abortando com instruções se
alguma etapa falhar):

1. verifica Node.js 20+ e executa `npm install`
2. encontra ou instala `uv`; se necessário, baixa Python 3.12 gerenciado pelo `uv`
3. no Windows, verifica ou instala CMake, Visual Studio Build Tools (C++ e Windows SDK) e WebView2
4. verifica ou instala Rust stable via rustup
5. sincroniza o ambiente Python e valida `protocol:gen`
6. sobe **Vite + `tauri dev`** em paralelo, com logs coloridos por processo

No Windows, as instalações automáticas usam **WinGet** (incluído no App Installer
da Microsoft Store). A primeira execução pode baixar vários componentes e o
Visual Studio Build Tools pode solicitar autorização e levar alguns minutos. Se
o WinGet não estiver disponível, uma instalação falhar ou o PATH precisar de
atualização, o bootstrap identifica a pendência, mostra como resolvê-la e pode
ser executado novamente depois. É necessária conexão com a internet.

O backend exige **Python 3.11+** e `uv`. O bootstrap e os comandos `sidecar:*`
verificam a versão do Python antes de executar `uv` e exibem uma mensagem de
instalação se ele estiver ausente. Para `plugin:build*` e `plugin:test`, que são
opcionais e não fazem parte do app desktop, instale o **.NET SDK**; o runtime
.NET, sozinho, não basta. Esses comandos verificam o SDK antes de rodar.

No modo dev o Tauri inicia o sidecar Python **direto do código-fonte** via
`uv run`, sem gerar um executável PyInstaller. Alterações no sidecar entram em
vigor ao reiniciar o app.

### Produção (só compila, não sobe o app)

```bash
npm run build:web        # compila apenas o frontend → apps/web/dist
npm run build:desktop    # compila sidecar (PyInstaller) + bundle Tauri
npm run build:all        # protocol:gen → build:web → build:desktop (tudo)
```

## Scripts (raiz)

### Desenvolvimento

| Script | O que faz |
|---|---|
| `npm run dev` | **Bootstrap completo** (Node, uv/Python, pré-requisitos nativos no Windows, Rust e protocolo) e sobe Vite + `tauri dev` em paralelo |
| `npm run dev:web` | Só a UI no navegador — usa o FastAPI do sidecar automaticamente |
| `npm run dev:desktop` | Só o `tauri dev` (assume que `dev:web` já está rodando) |

### Produção — apenas compila, sem subir o app

| Script | O que faz |
|---|---|
| `npm run build:web` | Build do frontend → `apps/web/dist` |
| `npm run build:desktop` | Gera o sidecar standalone (PyInstaller) e empacota com `tauri build` |
| `npm run build:all` | `protocol:gen` → `build:web` → `build:desktop` (pipeline completo) |

### Utilitários

| Script | O que faz |
|---|---|
| `npm run typecheck` | `tsc --noEmit` em todos os workspaces TS |
| `npm run test:sidecar` | `pytest` do sidecar com sockets reais |
| `npm run sidecar:sync` | `uv sync --group dev` do ambiente Python |
| `npm run sidecar:run` | Roda só o sidecar (`python -m sidecar`) |
| `npm run sidecar:build` | Empacota o sidecar com PyInstaller (chamado automaticamente por `build:desktop`) |
| `npm run protocol:gen` | Falha se o contrato divergir: métodos Python↔TS **ou** os tipos gerados do schema |
| `npm run schema:sync` | Regrava os tipos TS/C# a partir de `services/sidecar/src/sidecar/db/schema.sql` |
| `npm run plugin:build` | Compila o plugin CAD (ZWCAD padrão, ou AutoCAD via `plugin:build:autocad`) |
| `npm run plugin:test` | Verifica o .NET SDK e roda os testes xUnit do plugin |

## Estado atual

O **sidecar Python, o contrato e a UI são funcionais e verificados**: 27 testes
(round-trip ZMQ com sockets reais + leitura do SQLite do projeto), handshake de
processo ponta a ponta, `typecheck` limpo e build do web gerando `dist`.

A reconstrução do Eletron4Z sobre este esqueleto (dois frontends, contrato de
dados) está em `docs/POSITRON.md`.

O **plugin CAD** (C# net472, compatível com ZWCAD e AutoCAD) também está funcional e testado (327 testes xunit; veja
`cad-plugin/README.md` e `docs/POSITRON.md`). Ele builda com `npm run plugin:build`
e testa com `npm run plugin:test`.

O projeto inclui as DLLs da API real do **ZWCAD 2026** (`ZwManaged`/`ZwDatabaseMgd`)
em `cad-plugin/lib/ZWCAD/2026`, então é possível compilar
`Positron.Plugin.ZWCAD.dll` sem instalar o ZWCAD. Nesta máquina, o **ZWCAD 2026**
está instalado e carrega a DLL por `NETLOAD` (harness `npm run cad:smoke`) —
`ELET`/`FIA`/
`JMP`/`INT`/`SYNCD`/`VERIF` respondem, mais `ELETCFG` (tela de configuração),
`ELETREL` (relatório da verificação em arquivo), `INDCABO` (a ação "Corrigir cabos" do
verificador da interligação), `EPLQ` (a exportação das plaquetas do desenho,
tabela `Plaquetas4`) e `COMPLM` (a lista de material do desenho, tabela
`ListaMateriais`). O ciclo completo roda num **desenho
real** (`npm run cad:projeto`) com os números documentados (494 linhas em `Fiacao`,
`VERIF` 249, `IDEMPOTENTE`) — ver `docs/RUNBOOK.md`. O alvo **AutoCAD** continua
suportado; nesta máquina `npm run plugin:build:autocad` cai no stub
(`Positron.CadStub`), porque não há AutoCAD instalado. O Rust **está** instalado e a
lib do desktop compila (`cargo build`), mas o `tauri dev`/`build` completo ainda
exige CMake + MSVC. A lista completa do que foi e do que não foi executado está no
fim de `docs/RUNBOOK.md`.

## O que trocar primeiro

Estes são os pontos deliberadamente arbitrários, cada um isolado:

| Quero | Onde |
|---|---|
| Adicionar um método do backend | `services/sidecar/src/sidecar/handlers.py` (+ `packages/protocol` e `npm run protocol:gen`) |
| Trocar a porta/nível de log do sidecar | variáveis `SIDECAR_*` — `services/sidecar/src/sidecar/config.py` |
| Mudar o intervalo do heartbeat | `SIDECAR_HEARTBEAT_SECONDS` |
| Ícones e identidade do app | `apps/desktop/src-tauri/icons/README.md` e `identifier` no `tauri.conf.json` |
| CSP em produção | hoje `null` em `tauri.conf.json`; aperte antes de distribuir |

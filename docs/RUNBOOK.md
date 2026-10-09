# Runbook

## Pré-requisitos

| Ferramenta | Versão | Para quê | Como conferir |
|---|---|---|---|
| Node.js | 20+ | `apps/web`, `packages/protocol` | `node -v` |
| **Rust (rustup)** | stable | `apps/desktop` — instalado automaticamente por `npm run dev` se faltar | `cargo -V` |
| Python | 3.11+ | `services/sidecar` | `python -V` |
| [uv](https://docs.astral.sh/uv/) | — | deps do Python | `uv --version` |
| **CMake + compilador C** | — | libzmq compilado junto (`zmq` com feature `vendored`) | `cmake --version` |
| WebView2 | — | só no Windows, e já vem no Windows 10/11 | — |

Só o Python + Node são necessários para rodar os testes e a UI no navegador.
`npm run dev` instala o Rust stable via rustup se `cargo` não estiver disponível;
é necessária conexão com a internet na primeira execução. O Rust é necessário
para o app desktop de verdade.

## Primeira execução

```bash
# 1) dependências JS (workspaces: web, desktop, protocol)
npm install

# 2) dependências Python
npm run sidecar:sync          # ou: uv sync --directory services/sidecar --group dev

# 3) conferir que o contrato Python <-> TS está em sincronia
npm run protocol:gen

# 4) provar que o sidecar fecha um round-trip ZMQ
npm run test:sidecar
```

## Rodar

| Objetivo | Comando | O que sobe |
|---|---|---|
| App desktop completo | `npm run dev` | Vite (5173) + Tauri (que sobe o sidecar) |
| Só a UI no navegador | `npm run dev:web` | Vite; a UI usa o FastAPI em `127.0.0.1:8765` |
| Só o sidecar | `npm run sidecar:run` | ZMQ + FastAPI |

`npm run dev` verifica se `cargo` está disponível e, se não estiver, baixa e
executa o instalador oficial do rustup para instalar o toolchain stable. Depois,
usa `concurrently` para subir o Vite **e** o `tauri dev` em paralelo. No modo dev,
o Rust roda o sidecar Python do código-fonte via `uv run`; não é necessário
compilá-lo com PyInstaller. O `uv run` sincroniza o ambiente Python quando preciso,
e alterações no sidecar entram em vigor ao reiniciar o app. O
`devUrl`/`frontendDist` do `tauri.conf.json` dizem ao Tauri o que esperar, e ele
fica sondando `http://localhost:5173` até o Vite responder.

No Windows, o Tauri também exige as ferramentas de build do Visual Studio
(MSVC/C++), além do WebView2. A instalação automática do Rust não instala esses
pré-requisitos.

> **Não rode `tauri dev` direto** de dentro de `apps/desktop`: sem o Vite no ar a
> janela abre em branco. Rode `npm run dev` da raiz.

### Por que o `tauri.conf.json` não tem `beforeDevCommand`

Os hooks do Tauri rodam com um diretório de trabalho que não é estável entre
versões nem entre dev/build, e aqui o frontend está em outro workspace
(`apps/web`), não ao lado do `src-tauri`. Um `npm run dev` relativo acertaria por
acidente hoje e quebraria numa atualização do Tauri — ou pior, rodaria o script
`dev` do próprio `@app/desktop` (que é `tauri dev`) e entraria em recursão.

Em vez disso o `concurrently` (na raiz, onde o diretório é previsível) orquestra
os dois, e o Tauri só precisa saber **esperar** pelo Vite. Por isso
`npm run build` não empacota o app: use `npm run build:desktop`, que builda o web
primeiro.

## Verificações

```bash
npm run protocol:gen     # contrato Python <-> TS e tipos do schema em sincronia (exit 1 se não)
npm run schema:sync      # regrava os tipos TS/C# gerados a partir do schema.sql
npm run typecheck        # tsc --noEmit nos dois workspaces TS
npm run test:sidecar     # pytest, incluindo round-trip ZMQ real
npm run build            # build do web, gera apps/web/dist
npm run plugin:build     # C# do plugin CAD (net472) compila (ZWCAD padrão)
npm run plugin:build:autocad # C# do plugin CAD para AutoCAD
npm run plugin:test      # xunit do plugin CAD (net472)

# no sidecar
uv run --directory services/sidecar ruff check .

# no app desktop (precisa do Rust instalado)
npm run check:rust --workspace @app/desktop   # cargo check
npm run fmt:rust --workspace @app/desktop     # cargo fmt
```

`cargo fmt --check` **não** é gate de CI de propósito: formatação vermelha junto
com um erro de compilação vermelho só atrapalha. `cargo check` é o gate.

## Rodar o plugin dentro de um CAD de verdade

O `plugin:build` compila contra o **stub** quando não acha o CAD — isso valida a
sintaxe, mas **não** prova que o plugin carrega. Nesta máquina o **ZWCAD 2026 está
instalado**, então `npm run plugin:build` resolve o `ZWCadDir` sozinho e gera a
DLL contra a API **real**; o alvo AutoCAD continua no stub.

### ZWCAD 2026 (alvo principal)

1. **Compile.** O `csproj` acha o ZWCAD 2026 sozinho (`ZWCadDir`):

   ```bash
   npm run plugin:build     # -> Positron.Plugin.ZWCAD.dll
   ```

2. **Feche o ZWCAD antes.** Ele é instância única: uma segunda execução entrega
   para a instância já aberta, e essa instância **não** herda as variáveis
   `POSITRON_*` (o plugin lê o contexto do processo).

3. **Defina o contexto e garanta o `.db`.** O `ProjectStore` não aplica o
   `schema.sql`; quem cria o arquivo é o sidecar (`projeto_abrir`) — ou copie o
   `Modelo de BD Projeto.db` do reverso.

   ```bash
   export POSITRON_DB_PATH="C:/caminho/projeto.db"
   export POSITRON_DWG=1 POSITRON_REVISAO=R0 POSITRON_LOCAL=LOCAL-A
   # opcional: coluna `Pagina` (switch Conf.incluirColuna 0..6)
   export POSITRON_INCLUIR_COLUNA=0 POSITRON_SEPARADOR_CRUZAMENTO="-"
   ```

4. **Rode por script.** O ZWCAD aceita `/b <script>` (executa o `.scr` depois de
   abrir) e `/nologo`:

   ```lisp
   (setvar "FILEDIA" 0)
   (setvar "SECURELOAD" 0)
   (vl-cmdf "_.NETLOAD" "C:/.../Positron.Plugin.ZWCAD.dll")
   ELET
   QUIT
   ```

   ```bash
   "C:/Program Files/ZWSOFT/ZWCAD 2026/ZWCAD.exe" /nologo /b passo
   ```

   **`/b` espera o caminho SEM a extensão `.scr`** — com ela o ZWCAD ignora o
   script em silêncio (verificado: sem arquivo de log nenhum). É o `passo.scr` no
   disco, `passo` na linha de comando.

   O harness faz isso inteiro — confere o ambiente, recusa rodar com o ZWCAD
   aberto, cria o `.db` pelo `schema.sql`, escreve o `.scr`, roda e imprime o
   `POSITRON_LOG`:

   ```bash
   npm run cad:smoke
   npm run cad:smoke -- -Comandos ELET,FIA,VERIF -Revisao R1
   ```

   Ele sai 0 só quando o log tem `"Positron carregado"`. O `.db` e o log ficam
   no `%TEMP%`; a saída do CAD não tem stdout, então **o log é a evidência**
   (`Plugin.Escrever` anexa nele quando `POSITRON_LOG` existe).

5. **Confira pelo leitor do app**, não por SQL cru (mesma receita do item 4 do
   AutoCAD abaixo).

### E2E com um desenho de verdade (`-Desenho`)

A fixture acima prova o caminho, mas quem acha defeito é desenho real. O harness
aceita um DWG e **abre a cópia** (o original nunca é tocado):

```bash
npm run cad:smoke -- -Desenho "..\Elet\RCD\Funcional.dwg" -Comandos ELET,FIA,INT,SYNCD,VERIF -Revisao R0
```

O desenho vai na **linha de comando** do ZWCAD (não por `_.OPEN`, que num script é
assíncrono). Resultado medido em `..\Elet\RCD\Funcional.dwg` (1.541 entidades com
XData, painéis 503/509):

```text
FIA: 365 linha(s) em Fiacao (199 borne(s), 191 dispositivo(s), 83 posicao(oes),
     321 ponto(s) de bloco); 265 porta(s) em Portas4F; 168 borne(s) em Bornes4F;
     88 contato(s) em Contatos4F; 83 dispositivo(s) em Dispositivos4F;
     11 circuito(s) em Circuitos4F; 15 tipo(s) em Aplicacao4F.
INT: 20 linha(s) em Interligacao4 (199 borne(s)); 265 porta(s) em Portas4I;
     216 borne(s) em Bornes4I
VERIF: 365 fio(s), 20 trecho(s), 265 porta(s), 168 borne(s), 88 contato(s);
       273 problema(s) — fiação: 223; interligação: 32; modelos: 18; desenho: 0
VERIF: por tipo — SemTag: 223; PontoSemTag: 32; TerminalDuplicado: 18
```

O `VERIF` saiu com **821** problemas na primeira medição; **548 deles eram falsos
positivos sistemáticos**, corrigidos com evidência do próprio desenho:

1. **`Portas4F` tem dois tipos de linha** (o `AdicionaItemPortas` do
   `frmCompilarFiacao`): `"B"` = borne declarado pela máscara (`Regua`/`Borne`
   preenchidos, `Terminal` vazio) e `"T"` = terminal da máscara (`Terminal`
   preenchido e `Regua`/`Borne` **vazios por construção**). O verificador exigia
   régua/borne de **toda** linha — 265+265 apontamentos só porque as linhas eram
   "T". Agora a exigência vale para a linha "B" e o terminal é conferido na "T".
2. **Catálogo de cabos vazio não é "nenhum cabo existe"**: `CaboSemCatalogo`
   apontava todo cabo do desenho (18). Sem catálogo carregado a regra não roda —
   no projeto real o catálogo vive no `RCD.mdb` (Access), que não está no nosso banco.

O `SYNCD` repete `FIA`+`INT` e as contagens **não dobram** — idempotência provada
com dado real. O banco sai com `Fiacao` 365, `Interligacao4` 20 (tags `8-CCE-*`,
terminais ` A `/` B `), `Portas4F`/`Portas4I` 265, `Contatos4F` 88,
`Dispositivos4F` 83, `Circuitos4F` 11, `Aplicacao4F` 15.

Este número de bornes só saiu depois de corrigir **três** defeitos que o desenho real
revelou (o `Bornes4F` vinha **0** com 199 bornes no desenho):

1. **`ReguasModelo` lia a partir do índice 0** — o Xrecord `REGUAS/MODELOS2` começa
   com um **cabeçalho** (o maior `indexRegua`) e os registros de 10 valores vêm do
   índice 1 (`for (i = 1; ...)` no `LeOsModelosDeRegua`). Com o deslocamento, o
   `indexPainel` era lido do alternativo (texto) e **toda** régua era descartada.
2. **`Xrecord.Data` lança** no ZWCAD quando o registro existe mas está vazio
   (`InvalidOperationException` em `ResultBuffer..ctor`) — visto em
   `CENG_BORNES/<régua>`. Agora há `XDataNeutro.Para(Xrecord)`, que devolve vazio.
3. **Os `registro.Data == null` restantes** (6 arquivos) estouravam **antes** de
   chegar ao helper; viraram `registro == null`, que basta.

### E2E com dados sintéticos (`npm run cad:e2e`)

O smoke roda num `Drawing1` vazio, então os comandos só provam que carregam. Para
exercitar o caminho de dados, `scripts/cad-fixture.lsp` monta um desenho funcional
mínimo dentro do próprio ZWCAD — duas `LWPOLYLINE` com XData `CONEXAO` e uma com
`INTERLIGACAO` — e o `cad:e2e` roda `ELET`/`FIA`/`INT`/`SYNCD`/`VERIF` sobre ele:

```bash
npm run cad:e2e
```

Log esperado (o `SYNCD` repete `FIA`+`INT`, e a projeção substitui a revisão — as
contagens **não** dobram, que é a prova da idempotência no CAD de verdade):

```text
FIA: 2 linha(s) em Fiacao (...); 2 circuito(s) em Circuitos4F; ...
INT: 1 linha(s) gravada(s) em Interligacao4 (...)
VERIF: 2 fio(s), 1 trecho(s), 0 porta(s), 0 borne(s), 0 contato(s) na revisão.
VERIF: 4 problema(s) — fiação: 2; interligação: 2; modelos: 0; desenho: 0.
VERIF: por tipo — PontoSemTag: 2; SemTag: 2.
```

Confirme no banco com o leitor do app (o `.db` fica no `%TEMP%`, o script imprime o
caminho): `fiacao_por_painel(1)` traz os dois fios (`Pagina` = layer `12`,
`Secao`/`Cor` do XData), `circuitos_por_painel(1)` traz `C1`/`C2` e
`interligacao_por_cabo('CABO1')` traz o trecho com `Painel1`/`Painel2`. A fixture
não tem blocos: bornes, máscaras e contatos saem vazios — é o que falta para
exercitar as fases 7–9 num CAD.

### AutoCAD (evidência histórica; alvo net472)

Os ensaios de `FIA`/`INT` no `accoreconsole` do **AutoCAD 2020** foram feitos pelo
dono do projeto e **deram positivo** — o `INT` gravou `Interligacao4` de verdade e
o `FIA` gravou `Fiacao`/`Bornes4F`. O AutoCAD 2020 **não está instalado nesta
máquina**, então a receita abaixo é referência (o alvo AutoCAD builda só contra o
stub aqui). Vale para AutoCAD 2018–2024; 2025+ e o TrueView 2027 são .NET 8/10 e
**não** carregam um plugin net472.

1. **Compile contra a API real.** Sem `AutoCadDir` o `csproj` procura
   AutoCAD 2026/2025/2024; numa máquina com outra versão, passe o caminho:

   ```bash
   npm run plugin:build:autocad -- -p:AutoCadDir="C:\\Program Files\\Autodesk\\AutoCAD 2020"
   ```

   Se esse build falhar onde o build contra o stub passava, é o **stub que está
   errado** (namespace/assinatura fora da API real) — conserte o stub, não o
   código do plugin.

2. **Defina o contexto por variável de ambiente** (o mesmo do plugin):

   ```bash
   export POSITRON_DB_PATH="C:/caminho/projeto.db"   # .db criado do schema.sql
   export POSITRON_DWG=1 POSITRON_REVISAO=R0 POSITRON_LOCAL=LOCAL-A
   ```

3. **Rode num `accoreconsole` com um script** (`/i desenho.dwg /s passo.scr`).
   Duas armadilhas que custam tempo:

   - **`SECURELOAD`.** Com o padrão `1`, o `NETLOAD` responde
     `Unable to load ... assembly.nil` e não diz o porquê. Ponha
     `(setvar "SECURELOAD" 0)` ou o caminho do plugin em `TRUSTEDPATHS`.
   - **`FILEDIA`.** Sem `(setvar "FILEDIA" 0)` o `NETLOAD` abre diálogo e trava
     um console headless.

   ```lisp
   (setvar "FILEDIA" 0)
   (setvar "SECURELOAD" 0)
   (vl-cmdf "_.NETLOAD" "C:/.../Positron.Plugin.AutoCAD.dll")
   INT
   ```

   A saída do `accoreconsole` é **UTF-16LE**: leia com
   `iconv -f UTF-16LE -t UTF-8 log.txt`.

4. **Confira o que foi gravado pelo leitor do app**, não por SQL cru — é a
   interface que o Positron Desktop usa:

   ```bash
   services/sidecar/.venv/Scripts/python.exe -c "
   import asyncio, sys; sys.path.insert(0, r'<repo>/services/sidecar/src')
   from sidecar.db.project import ProjectDatabase
   db = ProjectDatabase(r'<caminho>/projeto.db')
   print(asyncio.run(db.interligacao_por_cabo('CABO1')))"
   ```

**`FIA`/`INT`/modelos agora SUBSTITUEM a revisão (idempotente).** Era um defeito
conhecido: nenhum INSERT apagava a revisão antes, então rodar duas vezes duplicava
as linhas (medido: `Fiacao` 3→6, `Bornes4F` 2→4) e o `ReordenarOrdemFiacao`,
que renumera `Ordem` 1..N por `Potencial` sobre **todas** as linhas da revisão,
passava a intercalar as duas cópias (`1,3 / 2,4` em vez de `1,2`). Agora
`ProjectStore` apaga `(DWG, Revisão)` na mesma transação do INSERT — o
`RemoveRevisaoTabelaParaDWG` do original — em `Fiacao`, `Interligacao4`,
`Portas4F`, `Bornes4F` e `Contatos4F`; `Cabos4`/`Veias4` já faziam isso. Pode
rodar o comando mais de uma vez no mesmo `.db` sem medo. Coberto por
`cad-plugin/Positron.Data.Tests/IdempotenciaTests.cs`.

## Empacotar

```bash
# 1) gere os ícones (obrigatório só aqui) — veja apps/desktop/src-tauri/icons/README.md
npm run tauri --workspace @app/desktop -- icon ../../logo.png
# e adicione o array "icon" em tauri.conf.json

# 2) gera o sidecar standalone e builde web + app
npm run build:desktop
```

`build:desktop` gera o sidecar standalone antes de empacotar o app. O
`sidecar:build` termina com um smoke test: roda o executável gerado e confere se
ele emitiu o `SIDECAR_READY`. É o que pega o erro clássico do PyInstaller —
módulo importado dinamicamente (uvicorn, fastapi) que não entrou no bundle e só
quebra na execução. A configuração `tauri.bundle.conf.json` adiciona o
`externalBin` somente nesse build; por isso o `tauri dev` não exige o executável.

### Onde os binários de produção são salvos

Ao rodar `npm run build:desktop` (ou `npm run build:all`), os arquivos finais são distribuídos nos seguintes caminhos:

1. **Binário standalone do sidecar (consumido pelo Tauri):**
   - `apps/desktop/src-tauri/binaries/sidecar-<target-triple>.exe`

2. **Executáveis de produção (executáveis diretos):**
   - `apps/desktop/src-tauri/target/release/app-desktop.exe` (executável principal)
   - `apps/desktop/src-tauri/target/release/sidecar.exe` (sidecar Python empacotado que o Tauri copia para o lado do executável)

3. **Instaladores e pacotes de distribuição (bundles):**
   - `apps/desktop/src-tauri/target/release/bundle/nsis/*.exe` (instalador Windows via NSIS)
   - `apps/desktop/src-tauri/target/release/bundle/msi/*.msi` (instalador Windows via WiX)
   - `apps/web/dist/` (build de produção dos assets do frontend React/Vite)

## Troubleshooting

### `RuntimeError: Proactor event loop does not implement add_reader family of methods required for zmq`

O erro clássico no Windows. O loop padrão é o `ProactorEventLoop`, e o
`zmq.asyncio` precisa de `add_reader`. Três saídas, em ordem de preferência:

1. **Já está resolvido neste projeto.** `__main__.py` roda o loop principal com
   `asyncio.Runner(loop_factory=asyncio.SelectorEventLoop)` e `tests/conftest.py`
   força a política equivalente. Se você vir esse erro, é porque criou um
   `asyncio.run()` novo em algum lugar — use o `_run()` do `__main__.py`.
2. Instalar `tornado>=6.1`, que o pyzmq usa como fallback. Custa uma dependência.
3. `asyncio.set_event_loop_policy(asyncio.WindowsSelectorEventLoopPolicy())` no
   seu próprio entrypoint.

Detalhe importante: a mensagem aparece só quando alguém tenta **ler** do socket,
não na criação. Sintoma comum em teste: o `pytest` parece **travar** em vez de
falhar.

### A janela abre em branco (Tauri)

O Vite não está no ar. Rode `npm run dev` da raiz, não `tauri dev`.

### `failed to find binary ... sidecar-x86_64-pc-windows-msvc.exe`

O `externalBin` exige o **sufixo do target triple** no nome do arquivo de origem
(ele remove o sufixo ao copiar para o bundle). O `sidecar:build` cuida disso
sozinho — se falhar, provavelmente `rustc` não está no PATH e o script assumiu
`x86_64-pc-windows-msvc`. Confira a saída do script e passe `-Triple` explícito.

### `binary or library cannot be found` / erro de build no crate `zmq-sys`

A feature `vendored` compila o libzmq junto, o que precisa de **CMake e um
compilador C**. Se preferir não instalar isso, troque a dependência em
`apps/desktop/src-tauri/Cargo.toml`:

```toml
zmq = "0.10"          # em vez de { version = "0.10", features = ["vendored"] }
```

e garanta o libzmq no sistema (Windows: vcpkg ou os binários oficiais).

### O sidecar ficou órfão / a porta está em uso

O Rust mata o filho no `RunEvent::Exit` e o `Command` é criado com
`kill_on_drop(true)`, então isso não deveria acontecer. Se um Rust antigo deixou
processo para trás:

```bash
powershell -NoProfile -Command "Get-Process sidecar,python -ErrorAction SilentlyContinue | Stop-Process -Force"
```

### `uv` reclamando de VIRTUAL_ENV

```
warning: `VIRTUAL_ENV=...` does not match the project environment path `.venv`
```

Você tem outro virtualenv ativo no shell. Ou desative (`deactivate`), ou use
`uv run --active`. Não é erro.

### `npm install` falha com `EALLOWSCRIPTS`

Rode `npm install-scripts ls` para ver quais pacotes aguardam aprovação e
aprove apenas os scripts necessários, por exemplo `npm install-scripts approve
esbuild`. O npm grava a aprovação no `allowScripts` do `package.json`. Se uma
configuração global também define `allow-scripts` no `.npmrc`, o npm avisa que
ela foi ignorada em favor da política do projeto; isso é esperado. O bootstrap
remove a variável de ambiente herdada do npm para que ela não seja interpretada
como uma opção de linha de comando proibida nas instalações locais.

### Xrecord de dicionário: cabeçalho no índice 0 e `Data` que lança

Dois detalhes que só apareceram no desenho real e zeravam o `Bornes4F`:

- os Xrecords do produto (`REGUAS/MODELOS2`) começam com um **cabeçalho** (maior
  índice) e os registros de 10 valores vêm do **índice 1** — quem lê do 0 pega o
  cabeçalho como primeiro registro e desloca todos os campos;
- `Xrecord.Data` **lança** `InvalidOperationException` em registro vazio; leia pelo
  `XDataNeutro.Para(registro)`, que devolve lista vazia, e não cheque `.Data` antes.

### `entget` sem applist não devolve XData no ZWCAD 2026

`(entget e)` **não** trouxe o grupo `-3` no desenho real (o dump dizia "nenhuma
entidade com XData" num desenho que tem 1.541). Com `(entget e '("*"))` o XData
aparece. Ao diagnosticar XData dentro do CAD, use sempre a applist `'("*")`.

### Numérico de XData tem que ser tolerante

O Xrecord real do desenho entrega inteiros como **string** (`"5"`, `"1.0"`), e
`Convert.ToInt32("1.0")` estoura `FormatException` — o comando inteiro falhava com
"Input string was not in a correct format" e não dizia onde. Agora tudo passa por
`XDataNumero` (`Inteiro`/`Curto`/`Real`/`Booleano`), que nunca lança. Os comandos
também passaram a logar `TipoDaExcecao: mensagem | 4 quadros do stack` em vez de só
a mensagem — foi assim que a falha foi localizada em um minuto.

### XData num `INSERT` pelo LISP não funciona no ZWCAD 2026

Tentar carimbar XData num bloco (`INSERT`) pelo LISP falha com
`incorrect type - nil` — nas três formas testadas: `entmake` com o grupo `-3` na
criação, `entmakex` idem, e `entmod` (com o `entget` inteiro ou com a lista
mínima `-1`/`0`/`8`/`10` + `-3`), tanto num INSERT criado por `entmakex` quanto
por `_.INSERT`. O mesmo `entmod` com `-3` funciona em `LWPOLYLINE` (é assim que a
fixture monta `CONEXAO`/`INTERLIGACAO`). Ou seja: a fixture com blocos não sai por
LISP.

A **biblioteca de simbologia** (`..\Elet\libs\Simbologia`) parecia a saída, mas
a varredura dos 2.265 DWGs e o dump de um símbolo mostram que os nomes `CONEXAO`/
`DISPOSITIVO` que aparecem nos bytes são **registros de app name legados**: as
entidades do `H_P_B1_VCC++.dwg` (ATTDEF/LINE/CIRCLE/HATCH) **não têm XData**. Ou
seja, também não há DWG de símbolo que sirva de fonte.

O que sobra para as fases 7–9 num CAD:
- um **desenho de projeto real** (do dono do produto), que é o único artefato com
  bornes/máscaras/dispositivos com XData;
- carimbar pelo próprio plugin, com um comando **só de Debug** (fica fora do
  assembly de release).

Armadilha vizinha, medida na mesma investigação: `(command "_.OPEN" ...)` num
script é assíncrono e a `pz-dump` seguinte roda no desenho antigo. Para abrir um
DWG como desenho ativo, passe o **arquivo na linha de comando** do ZWCAD
(`ZWCAD.exe <desenho> /nologo /b <script>`).

### Editar os scripts `.ps1`

`scripts/build-sidecar.ps1` tem acentos e o PowerShell 5.1 **lê arquivo sem BOM
como ANSI** — o que transforma os acentos em lixo e quebra o parser com erros
que não apontam para o lugar certo (`cadeia de caracteres sem terminador`).
Salve sempre como **UTF-8 com BOM**.

## Estado de verificação

Para não passar a impressão de que tudo foi testado do mesmo jeito:

**Executado e verificado nesta máquina (Windows, Python 3.14, Node 24):**

- `pytest` — 26 testes passando, com DEALER/ROUTER e SUB/PUB reais e leitura do
  SQLite do projeto.
- `npm run plugin:build` — 0 erros/0 avisos; o alvo ZWCAD resolve o `ZWCadDir`
  instalado e gera a DLL contra a API **real** (`ZwManaged`/`ZwDatabaseMgd`
  26.0.26.0), sem o stub na saída.
- `npm run plugin:test` — 162 testes xunit (net472) do plugin CAD.
- `python -m sidecar` ponta a ponta: handshake em stdout, `ping` por DEALER,
  `heartbeat` recebido no SUB, `GET /health` e `POST /rpc/echo` respondendo.
- `npm run protocol:gen` — passa, e falha com exit 1 quando o contrato diverge
  (testado injetando um método só no TS).
- `npm run typecheck` — `tsc --noEmit` limpo nos dois workspaces.
- `npm run build` — gera `apps/web/dist` (51 módulos).
- `ruff check .` no sidecar — limpo.
- **Dentro do ZWCAD 2026 com um desenho real** — `-Desenho ..\Elet\RCD\Funcional.dwg`:
  `FIA` grava 365 linhas (199 bornes, 191 dispositivos), `INT` 20 trechos, o
  `SYNCD` repete sem duplicar e as tabelas derivadas (portas, contatos,
  dispositivos, circuitos, aplicações) saem preenchidas. Foi esta rodada que achou
  o `FormatException` do `ReguasModelo` (ver armadilha abaixo).
- **Dentro do ZWCAD 2026 com dados sintéticos** — `npm run cad:e2e` (fixture `scripts/cad-fixture.lsp`):
  `FIA` grava 2 linhas em `Fiacao` + 2 circuitos, `INT` grava 1 `Interligacao4`, o
  `SYNCD` repete e **não duplica** (idempotência no CAD) e o sidecar lê as mesmas
  linhas do `.db`.
- **Dentro do ZWCAD 2026** — `npm run cad:smoke` carrega a DLL por `NETLOAD` e roda
  os comandos num desenho vazio. O `POSITRON_LOG` traz `Positron carregado.`,
  a resposta do `ELET`, `FIA: nenhuma LWPOLYLINE com XData CONEXAO no desenho.`,
  `INT: nenhuma LWPOLYLINE com XData INTERLIGACAO no desenho.`, o `SYNCD` (as
  duas de novo) e `VERIF: 0 problema(s) — fiação: 0; interligação: 0; modelos: 0;
  desenho: 0.` — a **fase 4 fechada** e o caminho `XData → tabelas` exercitado

**Não executado (por falta de ferramenta no ambiente, não por escolha):**

- `tauri dev` / `tauri build` — o Rust **está** instalado (a lib do desktop
  compila com `cargo build`), mas a feature `vendored` do crate `zmq` ainda
  exigiria CMake + MSVC, que não estão no PATH.
- **Blocos dentro do CAD** — a fixture do `cad:e2e` só tem polylines com XData; não
  tem **bornes, máscaras nem contatos**, então as fases 7–9 (casamento com o
  borne, `Portas4F`/`Bornes4F`/`Contatos4F`, `Jumper4`) seguem exercitadas só por
  teste unitário, não dentro do CAD. **Obstáculo medido** (ver a armadilha do
  INSERT abaixo): carimbar XData num `INSERT` pelo LISP não funciona neste ZWCAD,
  então a fixture com blocos tem que vir de um DWG pronto.
- **AutoCAD** — o AutoCAD 2020 dos ensaios de `FIA`/`INT` (positivos) não está
  instalado aqui; o alvo AutoCAD builda contra o stub (`Positron.CadStub`) e não
  carrega por `NETLOAD`.
- `npm run sidecar:build` (PyInstaller) — não executado aqui.

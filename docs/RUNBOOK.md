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
FIA: 494 linha(s) em Fiacao (199 borne(s), 191 dispositivo(s), 83 posicao(oes),
     450 ponto(s) de bloco); 265 porta(s) em Portas4F; 168 borne(s) em Bornes4F;
     88 contato(s) em Contatos4F; 83 dispositivo(s) em Dispositivos4F;
     7 circuito(s) em Circuitos4F; 15 tipo(s) em Aplicacao4F.
INT: 20 linha(s) em Interligacao4 (199 borne(s)); 265 porta(s) em Portas4I;
     216 borne(s) em Bornes4I
VERIF: 494 fio(s), 20 trecho(s), 265 porta(s), 168 borne(s), 88 contato(s);
       107 problema(s) — fiação: 0; interligação: 0; modelos: 0; desenho: 107
VERIF: por tipo — BorneSemFiacao: 107
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
3. **Ponto de fiação sem tag não é problema** quando o ponto não tem NADA de
   dispositivo (nem `Handle`, nem `NRegua`, nem `IndexModelo`, nem `TipoBorne`,
   nem `Aplicacao`): são vértices e cruzamentos do fio, que nascem sem tag por
   construção — 223 das 365 linhas no desenho real, **todas** sem nenhum campo de
   dispositivo. A regra passou a exigir evidência de dispositivo; a área "fiação"
   do desenho real fechou em **0**.

Em troca desses falsos positivos entrou uma regra que o original também tem (o
`carregaOrfao`): **`BorneSemFiacao`** — borne do desenho que não virou nenhum ponto
de `Fiacao`, comparando o `Handle` dos blocos com os `Handle`s gravados. No desenho
real isso acusa **193** de 199 bornes lidos, e o `FIA` só gravou 6 linhas com
`Tipo = 'B'` (as outras 136 casaram com **dispositivo**, não com borne). Fica como
**investigação aberta**: ou o casamento ponto↔borne está restritivo demais (bounds
±0,25, layer igual, painel), ou esses bornes realmente não estão sobre fio nenhum.
**Investigado na rodada 14** e resolvido em parte: dumpei a geometria do desenho
(199 bornes, 365 polylines `CONEXAO`, 829 vértices) e a definição dos blocos. O
borne da biblioteca é um **círculo de raio 1** (`H_B_FECH_CIMA_PNL_REGUA`,`H_B_ABERTO_*`,
`H_B_BORNE_FECHADO_EQUIP_TXT_DUO`), e a tabela de pontos de ligação do original
**inclui os quatro quadrantes do círculo** (`centro ± raio` — o ramo `Circle` do
`frmCompilarFiacao`, linha ~1357). Nosso port só coletava `Line`/`Polyline`, então a
tabela ficava vazia para esses blocos e o casamento caía no pé de inserção — a
distância media dava exatamente o **raio** (~1,0). Com o ramo do círculo:

| | antes | agora |
|---|---|---|
| `BorneSemFiacao` | 193 | **171** |
| `PontoSemTag` (interligação) | 32 | **0** |
| `VERIF` total no desenho real | 243 | **189** |

**Fechado na rodada 15.** Dumpando `Tipo`/`Disp1`/`Disp2`/`Jumper` das 365 conexões
apareceu o resto: o original **não cria um ponto por polilinha** — cria um ponto na
**primeira** ponta (`(Tipo == 1 && Disp1) || Tipo == 2`) e/ou na **última**
(`(Tipo == 1 && Disp2) || Tipo == 2 || (Tipo == 3 && Jumper == "")`). A distribuição
no desenho real: 167 conexões Tipo 3 com Disp2 (último vértice), 157 Tipo 2 (as duas),
13 Tipo 1 com Disp1 (primeiro) e 28 Tipo 1 sem flag (**nenhum** ponto).

A leitura criava **365** pontos, todos no primeiro vértice; o original cria **494**
(170 primeiros + 324 últimos). Depois da correção o `FIA` grava **494** linhas —
exatamente o previsto —, `Circuitos4F` cai de 11 para **7** (só `Tipo == 1` gera
circuito, como no original) e os órfãos caem de 171 para **107**.

E aí fecha a conta: a simulação offline previa **107** bornes sem vértice de fio a
menos de 0,5 de nenhum ponto de ligação — o mesmo número que o `VERIF` reporta. Ou
seja, **não há mais folga de casamento**: esses 107 bornes de régua não estão sobre
fio nenhum no desenho, e o `VERIF` está certo ao apontá-los.

**Rodada 16 — as duas últimas regras ruidosas saíram.** O `TerminalDuplicado` da
fiação apontava 110 linhas que são dado normal (bornes diferentes numerados `11`,
`A2`, `X2` no mesmo potencial). O original não tem essa regra: ele verifica
**fiação desenhada em duplicidade** (`LFiacaoTTDuplicada`, `ClsVerificadorProjetoFiacao`
linha ~961) — dois trechos **`Tipo == 2`**, na **mesma página**, com **as duas pontas
iguais** e handles diferentes; nesse caso aponta o handle do **menor potencial**.
Isso é lido do desenho (geometria), não da tabela, e entrou como `FiacaoDuplicada`
com o adapter `TrechosDoDesenho`. Mesma coisa nos contatos: o original grava um
contato por `sT1`/`sT2`/`sT3` do modelo **sem dedup** (um fusível com o mesmo
terminal nos dois lados é normal), então a regra de "terminal repetido no modelo"
também saiu (18 apontamentos de ruído). O desenho real fecha em **107 problemas, e
todos são `BorneSemFiacao`** — o mesmo número da simulação offline.

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
VERIF: 2 problema(s) — fiação: 0; interligação: 2; modelos: 0; desenho: 0.
VERIF: por tipo — PontoSemTag: 2.
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

### Rodar **as duas** builds do plugin

`npm run plugin:build` compila contra o ZWCAD real; `npm run plugin:build:autocad`
compila contra o **stub** (`Positron.CadStub`), que é um gate separado. Usar um tipo
da API que o stub ainda não tem (foi o `Circle`, na rodada 14) **só aparece nessa
segunda build** — o `plugin:test` não compila o projeto do plugin, então passa verde
do mesmo jeito. Rodar as duas depois de mexer em adapter.

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

### Relatório de verificação em arquivo (`ELETREL`)

A grid de erros das telas `frmCompilar*` do original virou **relatório em arquivo**,
que roda por script (a tela em si não dá para verificar):

```bash
npm run cad:smoke -- -Desenho "$env:TEMP\positron-match.dwg" -Comandos ELET,FIA,INT,VERIF,ELETREL -Revisao R0
```

O caminho vem de `POSITRON_RELATORIO` (chave `relatorio` na configuração); sem ela,
grava `positron-relatorio.txt` ao lado do banco. Medido no `Funcional.dwg`:

```text
ELETREL: 107 problema(s) em C:\Users\rno\AppData\Local\Temp\positron-relatorio-e2e.txt.
# Verificação do projeto (R0, DWG 1)
# 2026-10-09 11:50:24
VERIF: 494 fio(s), 20 trecho(s), 265 porta(s), 168 borne(s), 88 contato(s) na revisão.
# banco=...\positron-zwcad-20261009-115009.db
# problemas=107
# area;tipo;tabela;identificador;detalhe
Desenho;BorneSemFiacao;Fiacao;4DD53;borne do desenho sem ponto de fiação
...
# 107 linha(s)
```

O conteúdo é puro (`RelatorioCompilacao`: `Texto()`/`Salvar()`, testado) e o `VERIF`
passou a compartilhar a mesma montagem (`VerificarRevisao`), então os dois não podem
divergir.

A **tela** correspondente é o comando `ELETCMP`: mesma montagem (`MontarRelatorio`),
mostrada numa `DataGridView` (área, tipo, tabela, identificador, detalhe) com botão
Salvar. Ela é **modal** — como o `ELETCFG`, não entra em script, e é por isso que a
verificação automatizada usa o `ELETREL`; o conteúdo dos dois é o mesmo objeto.

### Idempotência e isolamento por desenho

Duas invariantes que o recorte promete, verificáveis com o script do repositório
`scripts/cad-dump-tabelas.py`:

1. **Idempotência:** rodar `FIA`/`INT` de novo no mesmo `(DWG, Revisão)` não duplica nem
   muda a projeção — ele apaga `(DWG, Revisão)` e reinsere dentro da mesma transação;
2. **Isolamento:** projetar outro desenho no mesmo banco não toca nas linhas do
   primeiro.

Receita (roda no CAD e compara o **conteúdo**, não só a contagem):

```powershell
# 1. projeta o desenho 63 num banco novo (o ELET ja roda FIA+INT)
npm run cad:smoke -- -Dwg 63 -Revisao R0 -Comandos ELET,FIA,INT `
  -Desenho "..\Elet\RCD\Funcional.dwg" -Banco "$env:TEMP\positron-idem.db"

# 2. dump do conteudo (todas as tabelas do DWG 63, menos o autoincremento Indice)
python scripts/cad-dump-tabelas.py dump $env:TEMP\positron-idem.db 63 $env:TEMP\dump-a.txt

# 3. projeta de novo e compara — o unico campo que pode mudar e Data
npm run cad:smoke -- -Dwg 63 -Revisao R0 -Comandos FIA,INT -Desenho ... -Banco ...mesmo.db
python scripts/cad-dump-tabelas.py dump $env:TEMP\positron-idem.db 63 $env:TEMP\dump-b.txt
python scripts/cad-dump-tabelas.py comparar $env:TEMP\dump-a.txt $env:TEMP\dump-b.txt --ignorar Data

# 4. projeta outro desenho no MESMO banco e confere que o 63 nao mudou (nem o Data)
npm run cad:smoke -- -Dwg 74 -Revisao R0 -Comandos ELET,INT -Desenho ...\Interligação.dwg -Banco ...mesmo.db
python scripts/cad-dump-tabelas.py dump $env:TEMP\positron-idem.db 63 $env:TEMP\dump-c.txt
python scripts/cad-dump-tabelas.py comparar $env:TEMP\dump-b.txt $env:TEMP\dump-c.txt
```

**Medido (rodada 30, `Funcional.dwg`):** 1.607 linhas no DWG 63 (494 `Fiacao`, 265
`Portas4F`, 265 `Portas4I`, 216 `Bornes4I`, 168 `Bornes4F`, 83 `Dispositivos4F`, 70
`Contatos4F`, 20 `Interligacao4`, 15 `Aplicacao4F`, 11 `Circuitos4F`) e três passadas de
projeção:

| Verificação | Resultado |
|---|---|
| 3ª passada sobre o mesmo `(63, R0)`, ignorando `Data` | **idêntico** (hash `7f6db90f…` nos dois lados) |
| 3ª passada sem ignorar nada | difere **só** em `Data` — as 273 chaves de `Fiacao` e a de `Interligacao4` com `Data` re-carimbado, todo o resto igual |
| Rodada no desenho 74 no mesmo banco | DWG 63 **idêntico, inclusive o `Data`** (hash `43be69e9…` nos dois) |
| `INT` no `Interligação.dwg` | recusa corretamente: *"nenhuma LWPOLYLINE com XData INTERLIGACAO"*, perfil `DINTERLIG`=530 — documento de interligação, fora do recorte |

O script falha de propósito quando se compara sem `--ignorar Data`: é o que prova que a
diferença apontada é exatamente essa, e nada mais.

### A/B contra o banco do produto (`RCD.mdb`) — a verificação mais forte

O `..\Elet\RCD\RCD.mdb` (19 MB, Access) é o banco **gerado pelo produto original**
para o mesmo projeto dos três DWGs. Ele abre por ODBC (driver 64-bit *Microsoft
Access Driver*) — sempre na **cópia** em `%TEMP%`, nunca no original:

```powershell
Copy-Item "..\Elet\RCD\RCD.mdb" "$env:TEMP\positron-rcd.mdb" -Force
$conn = New-Object System.Data.Odbc.OdbcConnection("Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=$env:TEMP\positron-rcd.mdb;ReadOnly=1;")
```

A tabela **`DWG`** dá o índice de cada desenho (`Indice`, `Tipo`, `Caminho`, `Nome`),
o que permite achar a linha do desenho certo:

| Desenho | Índice no produto |
|---|---|
| `Funcional.dwg` | **63** (`RCD-8-GGE-04`, `01_Funcional`) |
| `Interligação.dwg` | 74 (`RCD-8-GGE-02`) |
| `Fiação.dwg` | 65 (`RCD-8-GGE-30`) |

Comparação para o **DWG 63, revisão 3**:

| Tabela | Produto original | Recoder | |
|---|---|---|---|
| `Fiacao` | 494 | **494** | ✅ |
| `Portas4F` | 265 | **265** | ✅ |
| `Dispositivos4F` | 83 | **83** | ✅ |
| `Aplicacao4F` | 15 | **15** | ✅ |
| `Circuitos4F` | 11 | **11** | ✅ (era 7 — ver abaixo) |
| `Jumper4` | 0 | 0 | ✅ (o desenho não tem `Tipo 4` nem `Jumper` preenchido) |
| `Contatos4F` | 70 | **70** | ✅ (era 88 — ver abaixo) |
| `Bornes4F` | 155 | 168 | +13 a investigar (detalhe abaixo) |
| `Interligacao4` | 0 (o trecho vive no DWG 74) | 20 | recorte diferente |

**Esquema:** as **19 tabelas** que o recoder implementa batem **coluna a coluna** com
o Access (mesmos nomes e mesma ordem) — `Fiacao` 25, `Interligacao4` 34, `Jumper4` 23,
`Cabos4` 18, `Exportados` 17, `Bornes4F` 16, `Dispositivos4F` 13, `Bornes4I` 13,
`ModelosCabos` 12, `Portas4F` 11, … `Paineis` 5.

**Regras confirmadas pelo dado do produto:**

- **`Portas4F` só tem linha `T`** no projeto (6.425 linhas, todas `Tipo='T'`, todas com
  `Terminal` e **nenhuma** com `Regua`/`Borne`) — confirma a calibração da rodada 12
  (linha `T` não exige régua/borne);
- **contatos repetem terminal** no mesmo modelo (410 modelos com repetição) — confirma a
  rodada 16 (o produto grava um contato por `sT1`/`sT2`/`sT3`, sem dedup);
- **`Circuitos4F`**: o produto gravou **11** circuitos com nomes (`N`, `P`, `MANUAL
  LOCAL`, `MANUAL REMOTO`, `BARRA ∅A/B/C`, `S`, `TL`, `AUTOMÁTICO`). O recoder gravava
  **7**: o gerador era alimentado pelos *pontos* de fiação, e uma `Tipo 1` sem
  `Disp1`/`Disp2` não gera ponto — mas o `t6yXrlfi5w` varre as **conexões** do desenho.
  Corrigido (`ConexoesDoDesenho` + `Circuitos4FGerador` sobre conexões): **11**. É o
  tipo de defeito que só essa comparação pega.
- **`Contatos4F`**: o produto tinha **70** e o recoder gravava **88** — repetia terminais
  nos 7 modelos. Causa: o `Geral.DivideTerminais` do original recebe a lista **por
  referência** e só acrescenta o que ainda não está nela; nós dividíamos os terminais do
  dispositivo e os das bobinas em **duas listas novas** e concatenávamos, repetindo os
  comuns (modelo 52: 18 linhas com `1`, `2` e `B1` duplicados, contra 15 do produto).
  Entrou `Terminais.Acrescentar` (acumula e dedupa) — o desenho real agora fecha em
  **70 = 70**. Outra regressão que só o A/B pega.

**O que ainda difere — `Bornes4F` (155 do produto contra 168 do recoder)**, por
`(bReserva, IndexRegua)`:

| régua | produto | recoder | observação |
|---|---|---|---|
| 478 `R6` | 57 + 6 reservas | 57 + 6 | ✅ |
| 37 `R6` | 46 | 48 | +2 |
| 44 `RA1` | 8 + 4 | 8 + 4 | ✅ |
| 46 `RA2` | 8 + 4 | 8 + 4 | ✅ |
| 5 `BARRA` | 6 | 4 | −2 |
| 39 `R9` | 4 + 2 | 4 + 2 | ✅ |
| 1 | 3, nome **`52-X1`** | 8, nome **`ENTR 1`** | +5 e **nome diferente** |
| 2 | 3, nome **`52-X2`** | 8, nome **`ENTR 2`** | +5 e **nome diferente** |
| 482 `R8` | 2 + 2 | 3 + 1 | +1 / −1 |
| 487 `R8` | — | 3 | só no recoder |

**Investigado (rodada 28): a diferença não é do recoder — a cópia local do desenho não é
a que o produto compilou.** As evidências:

1. **Os bornes extras estão todos na página `1000`** e **não existem em lugar nenhum** do
   banco do produto: `Bornes4F` tem **zero** linhas com `Pagina='1000'`, e os 10 `Handle`
   extras não aparecem nem em `Bornes4F` nem em `Fiacao`. Ou seja, o produto nunca viu
   esses bornes.
2. **O nome da régua 1 e 2 é outro:** o dicionário do desenho de hoje diz `ENTR 1`/`ENTR 2`
   (lido no próprio ZWCAD pelo dump do `REGUAS/MODELOS2`); o banco do produto tem
   `52-X1`/`52-X2` — em **todas as 4 revisões**. A `DWG` do produto aponta para
   `J:\Eletrobras\...\RCD-8-GGE-04`, um caminho externo: os arquivos de `..\Elet\RCD`
   são **cópias**, possivelmente de outro momento.
3. **O número do borne dos mesmos handles é outro:** o handle `49538` é `Borne=' A '` no
   nosso recoder e `Borne='1'` no produto — mesma entidade (mesmo handle), XData
   reescrito entre uma compilação e a cópia que temos.

As outras seis tabelas do `FIA` batem exatamente, então a diferença fica contida em bornes
de régua — o que seria de esperar se o desenho foi editado (régua renomeada, bornes
acrescentados na página 1000). Para fechar de vez seria preciso o **DWG original** do
caminho que o produto registrou. Enquanto isso, o `VERIF` continua apontando 107 bornes
sem fiação **nessa cópia**, o que é a leitura correta do desenho que temos.

Os DWGs reais do projeto têm papéis diferentes, e rodar o comando no desenho errado
não é erro do plugin. Medido no ZWCAD, com a contagem de XData por app name:

| Desenho | XData | Papel |
|---|---|---|
| `Funcional.dwg` | `CONEXAO`, `INTERLIGACAO`, `AUXINTERLIG`, `Dispositivo` | **diagrama funcional** — é o insumo de `FIA`/`INT`/`JMP`/`VERIF` |
| `Interligação.dwg` | `DINTERLIG` (530), `Eletron`, `DiagLog` | **documento** de interligação — o `DINTERLIG` marca o borne do trecho (`XDataDInterlig`, fluxo ArqNet/DI), fora do recorte dos 6 comandos |
| `Fiação.dwg` | `Eletron` (2487), `TOPOGRAFICO`, `LAYOUT`, `DiagLog` | **documento** de fiação (plot), sem os XData do diagrama |

Para isso não virar silêncio, `FIA`/`INT` passaram a responder com o **perfil do
desenho** quando não acham o que procuram:

```text
INT: nenhuma LWPOLYLINE com XData INTERLIGACAO no desenho. perfil do desenho:
     ACAD=130, DiagLog=87, DINTERLIG=530, Eletron=185 — documento de interligação
     (DINTERLIG; o fluxo ArqNet/DI está fora do recorte destes comandos)
```

A classificação é pura (`PerfilDoDesenho`: `DiagramaFuncional` /
`DocumentoInterligacao` / `Documento` / `Desconhecido`), coberta por
`PerfilDoDesenhoTests`; o adapter (`PerfilDoDesenhoDoDesenho`) só conta os `1001` de
cada `Entity.XData`, sem depender de app name conhecido.

### Configuração: arquivo + ambiente (comando `ELETCFG`)

O plugin passou a ter o **arquivo de configuração** no lugar da tela do original:
`%APPDATA%\Positron\positron.ini` (formato `chave=valor`, uma por linha), gravado
pelo comando **`ELETCFG`** (a tela WinForms) e lido por
`ConfiguracaoPositron.Carregar()`.

**Precedência: padrão < arquivo < ambiente.** A variável `POSITRON_*` continua
vencendo, porque é o caminho da automação — o harness e os E2E montam o cenário por
variável e não podem depender de arquivo. Ou seja: nada do que já funcionava mudou,
e a tela só acrescenta persistência para quem opera à mão.

Chaves do arquivo: `banco`, `dwg`, `revisao`, `local`, `log`, `incluirColuna`,
`separadorCruzamento` (o nome da variável também é aceito como chave). Linha
malformada é ignorada e valor inválido mantém o anterior — dado de terceiro não
derruba o comando.

**`ELETCFG` é modal e não pode entrar em script**: ninguém clica em OK e o ZWCAD
fica parado. Por isso nenhum E2E o executa; a lógica testável está em
`ConfiguracaoPositron`, coberta por `ConfiguracaoPositronTests`.

### Editar os scripts `.ps1`

`scripts/build-sidecar.ps1` tem acentos e o PowerShell 5.1 **lê arquivo sem BOM
como ANSI** — o que transforma os acentos em lixo e quebra o parser com erros
que não apontam para o lugar certo (`cadeia de caracteres sem terminador`).
Salve sempre como **UTF-8 com BOM**.

## Estado de verificação

Para não passar a impressão de que tudo foi testado do mesmo jeito:

**Executado e verificado nesta máquina (Windows, Python 3.14, Node 24):**

- `pytest` — 27 testes passando, com DEALER/ROUTER e SUB/PUB reais e leitura do
  SQLite do projeto.
- `npm run plugin:build` — 0 erros/0 avisos; o alvo ZWCAD resolve o `ZWCadDir`
  instalado e gera a DLL contra a API **real** (`ZwManaged`/`ZwDatabaseMgd`
  26.0.26.0), sem o stub na saída.
- `npm run plugin:test` — 194 testes xunit (net472) do plugin CAD.
- `python -m sidecar` ponta a ponta: handshake em stdout, `ping` por DEALER,
  `heartbeat` recebido no SUB, `GET /health` e `POST /rpc/echo` respondendo.
- `npm run protocol:gen` — passa, e falha com exit 1 quando o contrato diverge
  (testado injetando um método só no TS).
- `npm run typecheck` — `tsc --noEmit` limpo nos dois workspaces.
- `npm run build` — gera `apps/web/dist` (57 módulos).
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

# Runbook

## Pré-requisitos

| Ferramenta | Versão | Para quê | Como conferir |
|---|---|---|---|
| Node.js | 20+ | `apps/web`, `packages/protocol` | `node -v` |
| **Rust (rustup)** | stable | `apps/desktop` — instalado automaticamente por `npm run dev` se faltar | `cargo -V` |
| Python | 3.11+ | `services/sidecar` — pode ser instalado/gerenciado pelo `uv` | `uv python find 3.11` |
| [uv](https://docs.astral.sh/uv/) | — | deps do Python — WinGet no Windows; instalação manual nos outros sistemas | `uv --version` |
| .NET SDK | instalado | compilar/testar o plugin C# (`plugin:build*`, `plugin:test`) | `dotnet --list-sdks` |
| **CMake + Visual Studio Build Tools (C++)** | — | dependências nativas do Tauri e libzmq vendorizado | `cmake --version`; Visual Studio Installer |
| WebView2 Runtime | — | janela do app Tauri no Windows | — |

Python 3.11+, `uv` e Node.js são necessários para o sidecar, seus testes e a UI
no navegador; o frontend web isolado precisa apenas de Node.js.
`npm run dev` verifica o Node.js e instala/sincroniza dependências. No Windows,
instala automaticamente as dependências ausentes com WinGet: `uv`, Python 3.12
gerenciado pelo `uv`, CMake, Visual Studio Build Tools com C++/Windows SDK e
WebView2. Também instala Rust stable via rustup se `cargo` não estiver
disponível. A primeira execução precisa de internet; a instalação do Visual
Studio pode pedir autorização do Windows, demorar e consumir vários gigabytes.
Se uma instalação automática falhar, o log informa a ferramenta, o motivo
conhecido e como instalá-la manualmente; corrija a pendência e repita
`npm run dev`. O App Installer da Microsoft Store fornece o WinGet; se faltar,
instale-o em https://aka.ms/getwinget e reabra o terminal.
O bootstrap detecta as ferramentas C++ com `vswhere`, sem exigir uma edição
específica do Visual Studio; instalações posteriores a 2022 também são aceitas
quando incluem o compilador C++.

Em macOS e Linux, `npm run dev` ainda instala Rust, mas a instalação de `uv` e
das bibliotecas nativas do Tauri é manual. Consulte
https://v2.tauri.app/start/prerequisites/ e
https://docs.astral.sh/uv/getting-started/installation/.

O plugin CAD e seus testes precisam de um **.NET SDK**, não apenas do runtime.
O projeto tem alvo .NET Framework 4.7.2; os assemblies de referência desse alvo
são restaurados pelo NuGet, portanto não é necessário instalar o Visual Studio
para compilar/testar o plugin. Os comandos `npm run plugin:build*` e
`npm run plugin:test` verificam se há SDK instalado e explicam como conferir com
`dotnet --list-sdks` caso não encontrem.
O SDK é opcional para o app desktop e não é instalado por `npm run dev`; os
comandos do plugin mostram o link e o comando de verificação se estiver ausente.

### Instalar manualmente uma extensão VS Code (.vsix)

Este repositório não fornece nem gera um arquivo `.vsix`; este procedimento só
se aplica quando o fornecedor da extensão disponibiliza esse arquivo e a
instalação automática da extensão não funciona:

1. No VS Code, pressione `Ctrl+Shift+P` (Windows/Linux; `Cmd+Shift+P` no macOS).
2. Execute **Extensions: Install from VSIX...** (pode aparecer como **Install from VSIX**).
3. Selecione o arquivo `.vsix` fornecido pela extensão e reinicie o VS Code se
   ele solicitar.

Isso instala extensões do editor; não instala o .NET SDK, Python, CMake nem
Visual Studio Build Tools. Para essas ferramentas, siga as instruções de
instalação dos respectivos pré-requisitos acima.

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

`npm run dev` prepara as dependências acima e só inicia os servidores quando as
etapas de bootstrap terminam com sucesso. Em seguida, usa `concurrently` para
subir o Vite **e** o `tauri dev` em paralelo. No modo dev, o Rust roda o sidecar
Python do código-fonte via `uv run`; não é necessário compilá-lo com PyInstaller.
O `uv run` sincroniza o ambiente Python quando preciso, e alterações no sidecar
entram em vigor ao reiniciar o app. O
`devUrl`/`frontendDist` do `tauri.conf.json` dizem ao Tauri o que esperar, e ele
fica sondando `http://localhost:5173` até o Vite responder.

No Windows, se uma instalação do WinGet informar sucesso mas o utilitário ainda
não estiver no PATH, feche e reabra o terminal e repita `npm run dev`. Se o
Visual Studio Installer falhar ou não puder elevar privilégios, abra-o e instale
a carga de trabalho **Desenvolvimento para desktop com C++**, incluindo um
Windows SDK e as ferramentas CMake. Para o WebView2, use o instalador Evergreen
em https://developer.microsoft.com/microsoft-edge/webview2/.

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

# para verificar o ambiente
uv run --directory services/sidecar python --version  # precisa ser 3.11+
uv --version
dotnet --list-sdks       # necessário para build/teste do plugin CAD

# no sidecar
uv run --directory services/sidecar ruff check .

# no app desktop (precisa do Rust instalado)
npm run check:rust --workspace @app/desktop   # cargo check
npm run fmt:rust --workspace @app/desktop     # cargo fmt
```

`cargo fmt --check` **não** é gate de CI de propósito: formatação vermelha junto
com um erro de compilação vermelho só atrapalha. `cargo check` é o gate.

## Rodar o plugin dentro de um CAD de verdade

As DLLs da API real do **ZWCAD 2026** (`ZwManaged`/`ZwDatabaseMgd`) estão
versionadas em `cad-plugin/lib/ZWCAD/2026`; portanto, `npm run plugin:build`
compila o plugin real sem exigir a instalação do ZWCAD. Isso valida a
compilação, mas não substitui o teste de carregamento dentro do CAD. Nesta
máquina o **ZWCAD 2026 está instalado** e o executável carrega a DLL por
`NETLOAD` (seção "ZWCAD 2026 (alvo principal)" abaixo). O **AutoCAD não está
instalado** aqui: `npm run plugin:build:autocad` cai no **stub**
(`Positron.CadStub`) — é o único uso do stub nesta máquina, e serve de gate de
compilação da plataforma AutoCAD.

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
npm run cad:smoke -- -Desenho "..\Elet\Teste_prjeto_real\Funcional.dwg" -Comandos ELET,FIA,INT,SYNCD,VERIF -Revisao R0
```

O desenho vai na **linha de comando** do ZWCAD (não por `_.OPEN`, que num script é
assíncrono). Resultado medido em `..\Elet\Teste_prjeto_real\Funcional.dwg` (1.541 entidades com
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
contagens **não** dobram, que é a prova da idempotência no CAD de verdade).
Medido no ZWCAD 2026 (rodada 58 — o `VERIF` cresceu de 2 para **4** problemas: as
regras `PainelSemCadastro` (rodada 45) e `InterligacaoIndefinida` (rodada 57)
incidem sobre a fixture, que cita o painel `1`, fora do cadastro):

```text
FIA: 2 linha(s) em Fiacao (...); 2 circuito(s) em Circuitos4F; ...
INT: 1 linha(s) gravada(s) em Interligacao4 (...)
VERIF: 2 fio(s), 1 trecho(s), 0 porta(s), 0 borne(s), 0 contato(s) na revisão.
VERIF: 4 problema(s) — fiação: 0; interligação: 2; modelos: 0; desenho: 2.
VERIF: por tipo — PontoSemTag: 2; InterligacaoIndefinida: 1; PainelSemCadastro: 1.
```

Confirme no banco com o leitor do app (o `.db` fica no `%TEMP%`, o script imprime o
caminho): `fiacao_por_painel(1)` traz os dois fios (`Pagina` = layer `12`,
`Secao`/`Cor` do XData), `circuitos_por_painel(1)` traz `C1`/`C2` e
`interligacao_por_cabo('CABO1')` traz o trecho com `Painel1`/`Painel2`. A fixture
não tem blocos: bornes, máscaras e contatos saem vazios — é o que falta para
exercitar as fases 7–9 num CAD.

### AutoCAD 2020 (o host verificado **nesta máquina**, rodada 136)

> **Esta máquina não tem ZWCAD** (o `C:\Program Files\ZWSOFT` não existe) e tem o
> **AutoCAD 2020** (`C:\Program Files\Autodesk\AutoCAD 2020`, com `acad.exe` e
> `accoreconsole.exe`). O **alvo do produto continua sendo o ZWCAD 2026** e os números
> medidos nele seguem valendo (seção acima); aqui o ciclo é medido no AutoCAD 2020 por
> paridade — e ele reproduz o alvo do ZWCAD **linha a linha** (medido na rodada 136).

**A API do AutoCAD é vendorizada** (`cad-plugin/lib/AutoCAD/2020/`, commit `de3837e4`):
`acmgd.dll`, `acdbmgd.dll` e `accoremgd.dll` do AutoCAD 2020 — mais a `AdWindows.dll` desde a
**rodada 138**, que traz a API de interface (`Autodesk.Windows`: o `RibbonControl` e os itens, a
irmã da `ZdWindows` do ZWCAD) — o mesmo padrão do
`cad-plugin/lib/ZWCAD/2026`. O `csproj` **prefere a cópia do repo** e só cai no
`Program Files\Autodesk\AutoCAD 2026…2020` (e, sem nenhuma das duas, no stub
`Positron.CadStub`), então `plugin:build:autocad` compila contra a **API real** mesmo numa
máquina sem AutoCAD instalado. Para refazer a cópia a partir de uma instalação:

```bash
powershell -ExecutionPolicy Bypass -File scripts/prepare-autocad-api.ps1
# com o AutoCAD em outro lugar:
powershell -ExecutionPolicy Bypass -File scripts/prepare-autocad-api.ps1 -AutoCadDir "D:\Autodesk\AutoCAD 2020"
```

Vale o mesmo para o ZWCAD: sem o `C:\Program Files\ZWSOFT`, o `plugin:build` (ZWCAD)
compila contra o `cad-plugin/lib/ZWCAD/2026` do repo — o **build** é reproduzível sem o CAD
instalado, mas **rodar** dentro dele não. **Verificado em 2026-10-16:** nesta data não há ZWCAD
nesta máquina (registro + pastas + `where`; ver *Existe CAD nesta máquina?*) — medir de novo antes de
concluir qualquer ausência.

O `accoreconsole.exe` roda o plugin **headless** e o harness
`scripts/cad-autocad-smoke.ps1` faz o ciclo inteiro (confere o AutoCAD, cria o `.db`
pelo `schema.sql`, escreve o `.scr`, roda e imprime o `POSITRON_LOG`):

```bash
npm run plugin:build:autocad                 # DLL contra a API real (a copia do repo primeiro; senao 2020..2026)
npm run cad:smoke:acad                        # carrega a DLL num desenho vazio (ELET)
npm run cad:e2e:acad                          # fixture sintética (scripts/cad-fixture.lsp)
npm run cad:projeto:acad -- -Idempotencia     # projeto real + catálogo + app + baseline
```

Como o `npm run` mastiga os argumentos depois do `--` (ver a armadilha acima), o
`-Desenho`/`-Mdb`/`-Banco` vão na chamada **direta** do `.ps1`. O `cad-projeto-e2e.ps1`
resolve os caminhos do **projeto real** a partir da raiz do repo
(`cad-plugin\reverso\Teste_projeto_real`, dentro do repo desde a rodada 134), então nesta
máquina o ciclo inteiro é uma linha:

```bash
powershell -ExecutionPolicy Bypass -File scripts/cad-projeto-e2e.ps1 -Cad AutoCAD -Idempotencia
```

O default `-Cad ZWCAD` (o alvo do produto) **falha antes de chamar o harness** numa máquina
sem ZWCAD, com a mensagem que aponta o host instalado (`Nesta maquina o host verificado e o
AutoCAD 2020: rode com '-Cad AutoCAD'`) — em vez do `ZWCAD nao encontrado em '...'` do smoke.

**A interface no AutoCAD (rodada 138).** O `accoreconsole` **não** exercita a interface — e duas
coisas medidas nesta máquina importam para quem for testar:

- o **autoload não roda nele**: o `accoreconsole` sobe sem o `AcAutoLoader.arx` (o `(arx)` dele lista
  só `acdim.crx`, `acvmtools.crx` e `vl.crx`) e um bundle válido em
  `%APPDATA%\Autodesk\ApplicationPlugins` não muda nada — no headless a DLL entra por `NETLOAD`,
  como o `cad-autocad-smoke.ps1` faz;
- **criar `PaletteSet` nele derruba o processo** (e *referenciar* o tipo também: ver a rodada 138 no
  detalhe rodada a rodada). Por isso a interface mora em `PaletaAncoravel`, tocado só quando há
  janela.

**Nesta máquina o pacote de autoload está REMOVIDO de propósito** (rodada 160): o autoload é o caminho
de produção, e ele faz a barra aparecer **sem `NETLOAD`** — o que atrapalha o ciclo de teste (e, com o
pacote velho, mostra a barra velha). Para medir a barra pela interface cheia, instale o pacote
(`instala-bundle.ps1 -Cad AutoCAD`), meça e remova-o de novo (`-Remover`). Para o ciclo por `NETLOAD`,
nenhum pacote é preciso.

O jeito de medir a **barra** e a **paleta** é abrir a **interface cheia** por script — sem `NETLOAD`
(é o autoload que está sob teste) e com o `POSITRON_LOG` apontado:

```powershell
powershell -ExecutionPolicy Bypass -File scripts/instala-bundle.ps1 -Cad AutoCAD   # põe o pacote em %APPDATA%
$env:POSITRON_LOG = "$env:TEMP\positron-gui.txt"; $env:POSITRON_DB_PATH = "$env:TEMP\positron-projeto.db"
$env:POSITRON_DWG = "63"; $env:POSITRON_REVISAO = "R0"
# o CAD fica vivo ~25 s: a barra entra na PRIMEIRA OCIOSIDADE (o ribbon não existe no load)
$scr = "$env:TEMP\pz.scr"; Set-Content $scr -Encoding ASCII -Value @('(setvar "FILEDIA" 0)','FOLHAS','VERIF')
Start-Process 'C:\Program Files\Autodesk\AutoCAD 2020\acad.exe' -ArgumentList @('/nologo','/i',"$env:TEMP\copia.dwg",'/b',$scr)
# 25 s depois leia $env:POSITRON_LOG: 'Positron carregado', a paleta e a linha 'Barra: aba "Positron" ...'
```

**O pacote em `%APPDATA%` é uma cópia da DLL** (rodada 149): depois de **qualquer** build, o AutoCAD
só enxerga a versão nova se o `instala-bundle.ps1` rodar de novo — o smoke do ZWCAD carrega a DLL
recém-compilada por `NETLOAD` e por isso nunca sofre disso, e é o caminho por onde o defeito entra
silencioso: em 13/10 o bundle do AutoCAD era o **da rodada 138** (instalado em 12/10) e a barra de
lá continuava a antiga, com o painel extra "Positron" — o mesmo defeito que a rodada 147 tinha
corrigido, medido e fechado **no ZWCAD** (ver o item do Troubleshooting).

A **validação visual** (a aba na fita e a paleta ancorada) é do dono do produto; o que é automático —
a aba existir com os 9 painéis do original, os 121 botões e as contagens por tipo, e a paleta reportar
as 16 páginas — sai no log. **Números do AutoCAD 2020** (rodada 149; o `pzBarra` lê a aba **viva**,
pelo COM, porque o `Idle` não dispara enquanto um script roda):

```text
Barra: aba "Positron" com 9 painel(is) — 121 botão(ões), 5 menu(s) com 39 item(ns), 1 liga/desliga, 1 lista e 1 campo; 34 linha(s), 86 quebra(s), 7 área(s) recolhível(is), 9 separador(es). Acionáveis: 108 ligado(s) (3 no comando do recoder), 53 desativado(s); tema escuro.
pzBarra: 1 aba(s) POSITRON.ID_Positron ("Positron"), 9 painel(is) [Configuração | Caderno | Dispositivos | Bornes | Fiação | Construtivo | Cabos e Veias | Utilitários | Help]; RibbonButton=120, RibbonCombo=1, RibbonMenuButton=5, RibbonMenuItem=39, RibbonPanelBreak=7, RibbonRowBreak=86, RibbonRowPanel=34, RibbonSeparator=9, RibbonTextBox=1, RibbonToggleButton=1; 1 botão(ões) de canto; 55 item(ns) desativado(s).
```

— **as mesmas linhas do ZWCAD 2026** (rodada 147): uma aba, nove painéis do original, sem o painel
extra, os três comandos substitutos e o mesmo par 108/53 acionáveis. A receita da leitura viva no
AutoCAD (o script sozinho não serve: `pzBarra` roda **antes** da barra existir, e o log sai
`pzBarra: a aba POSITRON.ID_Positron não está no ribbon`):

```powershell
$env:POSITRON_LOG = "$pasta\positron-gui.txt"       # sem /b: o AutoCAD fica na linha de comando
Start-Process 'C:\Program Files\Autodesk\AutoCAD 2020\acad.exe' -ArgumentList @('/nologo','/i',$copia)
Start-Sleep 30                                       # a barra entra na primeira ociosidade
$prog = [Runtime.InteropServices.Marshal]::GetActiveObject('AutoCAD.Application.23')   # (2020)
$prog.ActiveDocument.SendCommand('pzBarra ')         # aí sim: a aba já existe
```

Diferenças em relação ao ZWCAD, todas medidas aqui:

- o `accoreconsole.exe` é um **processo separado** — não há instância única nem a
  necessidade de fechar o CAD antes (o harness do ZWCAD exige isso);
- o script vai no `/s` com o **caminho completo e a extensão `.scr`** (é o ZWCAD
  que exige o caminho **sem** extensão no `/b`);
- o desenho entra por `/i <cópia>` (cópia no TEMP; o original nunca é tocado);
- a saída do `accoreconsole` é **UTF-16LE** e ele redireciona o próprio stdout para
  um arquivo, então o `POSITRON_LOG` continua sendo a evidência primária;
- ao rodar pelo **npm dentro do PowerShell**, o shim `npm.ps1` (npm 11.18 nesta
  máquina) mastiga os argumentos depois do `--` (`-Revisao`/`-Comandos` viram cli
  config e o harness recebe os parâmetros errados). Chame o `.ps1` direto — é o que
  o `cad-projeto-e2e.ps1` faz — ou use o `npm run` pelo **bash**, onde o `--` é
  repassado certo;
- a **barra** funciona nos dois CADs desde a rodada 138 (a `AdWindows` do AutoCAD é a irmã da
  `ZdWindows` do ZWCAD e a construção é a mesma): a linha antiga `Barra: disponível apenas no build
  ZWCAD` **não existe mais** — ver os números do AutoCAD logo acima.

**O `-Cad AutoCAD` do `cad-projeto-e2e.ps1` troca o harness e roda tudo sem ZWCAD.**
Medido nesta máquina, o ciclo completo reproduz o alvo ZWCAD linha a linha:

```text
FIA: 494 linha(s) em Fiacao (199 borne(s), 191 dispositivo(s), 83 posicao(oes));
     265 porta(s) em Portas4F; 168 borne(s) em Bornes4F; 70 contato(s) em Contatos4F;
     83 dispositivo(s) em Dispositivos4F; 11 circuito(s) em Circuitos4F; 15 tipo(s) em Aplicacao4F
INT: 20 linha(s) em Interligacao4 (199 borne(s)); 265 porta(s) em Portas4I;
     216 borne(s) em Bornes4I; 697 cabo(s) em Cabos4; 2388 veia(s) em Veias4
VERIF: 249 problema(s) — fiação: 0; interligação: 0; modelos: 0; desenho: 249
       por tipo — BorneSemLm 119; BorneSemFiacao 107; IntervaloBorneInvalido 11;
       ReguaVazia 10; SobreposicaoAusente 2
IDEMPOTENTE: mesmo conteudo (ignorando Data)
```

A regra do stub vale igual: se o build contra a **API real** falhar onde o stub
passa, é o **stub** que está errado. A receita manual abaixo é a mesma que o
harness executa. Vale para AutoCAD 2018–2024; 2025+ e o TrueView 2027 são .NET
8/10 e **não** carregam um plugin net472.

1. **Compile contra a API real.** Sem `AutoCadDir` o `csproj` usa a **cópia do repo**
   (`cad-plugin/lib/AutoCAD/2020`) e, sem ela, procura AutoCAD 2026…2020; numa máquina com
   outra versão (ou fora do `Program Files`), passe o caminho:

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

### O harness passa e o usuário real vê outra coisa (rodada 180)

Por padrão o `cad-zwcad-smoke.ps1` define `POSITRON_DB_PATH`, `POSITRON_DWG`, `POSITRON_REVISAO` e
`POSITRON_LOCAL`. Elas vencem o desenho, então o projeto ativo do usuário real (o XData `EletronProj` do
desenho, o DWG pelo nome do arquivo) nunca é exercitado. Para provar o caminho real, use **`-SemProjeto`**,
que só define o log. Um desenho novo do Elétron sem banco se monta com
`-Fixture scripts/cad-fixture-projeto.lsp` e `POSITRON_PROJ_MARCAR=1`; `POSITRON_BDPROJETO=<.db>` faz o que o
clique no `SelProj` da tela Banco de Dados do Projeto faria; `(pz-proj:dump)` com `POSITRON_PROJ_SAIDA` despeja o
XData. Com `POSITRON_LOG` definido, o `MsgBox` do plugin (`Interface/Aviso.cs`) só escreve na linha de comando.

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
compila contra a **API do AutoCAD** (a cópia vendorizada em `cad-plugin/lib/AutoCAD/2020`
desde a rodada 136 e, sem ela, a instalação local — o stub `Positron.CadStub` só entra quando
não há nenhuma das duas). Usar um tipo da API que o stub ainda não tem (foi o `Circle`, na
rodada 14) **só aparece nessa segunda build** — o `plugin:test` não compila o projeto do
plugin, então passa verde do mesmo jeito. Rodar as duas depois de mexer em adapter — e, se a
mudança for de **interface**, reinstalar o pacote do AutoCAD (ver a entrada da barra antiga).

### `falha ao criar banco de dados novo: unable to open database file` (o banco no `%TEMP%`)

**Medido na rodada 150.** O `cad-autocad-smoke.ps1` cria o `.db` do projeto no `%TEMP%` quando o
`-Banco` não vem. Nesta máquina a criação **falhou** ali — `sidecar.protocol.DatabaseError: falha ao
criar banco de dados novo: unable to open database file` —, e o `sqlite3` puro dá o mesmo erro (assim
como um `open(...,'w')` no Python, com `PermissionError`, ainda que a ACL da pasta mostre
`FullControl` para o usuário): é permissão/ambiente, não schema nem path errado. O contorno que as
receitas usam é passar o banco **dentro do repo**, que é gravável:

```bash
cp .tmp-smoke/positron-projeto.db .tmp-smoke/r150.db
npm run cad:smoke:acad -- -Comandos ELET -Banco ".tmp-smoke/r150.db"
```

O mesmo vale para o `TEMP` do **console runner do xunit** (`.tmp-smoke/temp`) e para o
`cad:projeto:acad` (`-Banco`).

**A causa, medida na rodada 151:** quem escreve o banco no `cad-autocad-smoke.ps1` é o **python do venv
do sidecar** (`ProjectDatabase(...).create_from_schema()`), e é **ele** que não escreve no `%TEMP%`
nesta máquina — a prova é direta: `services/sidecar/.venv/Scripts/python.exe -c "open(r'C:\Users\...\AppData\Local\Temp\x.txt','w')"`
dá `PermissionError: [Errno 13]`, enquanto o python **do sistema** escreve o mesmo caminho. Os dumps
da idempotência (`cad-dump-tabelas.py`, também pelo python do venv) sofriam o mesmo, e o efeito era
**pior que ruído**: com o dump falhando, o passo 7 comparava os arquivos **da rodada anterior** — na
rodada 150 o `hash A = hash B = 7c1635f0…` saiu dos dumps de 12/10 e o passo 6 conferia a linha de
base num `positron-relatorio.txt` **velho** do `%TEMP%` (o plugin grava o relatório **ao lado do
banco**). Desde a rodada 151 o `cad-projeto-e2e.ps1` põe **relatório e dumps na pasta do banco** — o
mesmo lugar em que o `ELETREL` grava —, e a idempotência mede o que diz medir. Se acontecer em outra
máquina, confira se o python do venv escreve no `%TEMP%` antes de suspeitar do plugin.

### A barra no AutoCAD parece a **antiga** (com o painel extra "Positron")

**Medido na rodada 149.** A interface cheia do AutoCAD carrega o plugin pelo **autoload**, e o pacote
em `%APPDATA%\Autodesk\ApplicationPlugins\Positron.bundle` é uma **cópia da DLL** — feita pelo
`scripts/instala-bundle.ps1`. Quem compila (`plugin:build:autocad`) **não** atualiza essa cópia: o
AutoCAD segue carregando a DLL da instalação anterior, por mais nova que seja a do `bin\`. Foi o que
aconteceu com a barra: o bundle era o da rodada 138 (12/10) e a fita continuava com o painel extra
"Positron" e a forma plana que a rodada 147 corrigiu — o `pzBarra` do ZWCAD, que carrega a DLL
**recém-compilada** por `NETLOAD`, mostrava a barra nova o tempo todo. O defeito não estava no
código: **instale o pacote depois de cada build** e o AutoCAD passa a mostrar a mesma barra.

```powershell
npm run plugin:build:all
powershell -ExecutionPolicy Bypass -File scripts/instala-bundle.ps1 -Cad AutoCAD
# a prova é ler a aba viva (ver a seção do AutoCAD 2020): 'pzBarra: 1 aba(s) ... 9 painel(is)'
```

Sintoma de que a cópia está velha: o log da interface cheia abre com **10 painel(is)** — os nove do
original mais um **Positron** extra, repetindo `ELETCFG`/`VERIF` em botões próprios — em vez dos
nove, ou o `Barra:`/`pzBarra` discordam entre si. A segunda linha do log diz o que está no ar:
`Positron: DLL de <data> — <caminho>`; na interface cheia o caminho é o do **pacote**, e a data tem de
bater com a do `cad-plugin\Positron.Plugin\bin\Debug\AutoCAD\net472\Positron.Plugin.AutoCAD.dll`.

O mesmo vale para a **paleta** e para qualquer correção testada por `NETLOAD`/`accoreconsole` (que
carregam a DLL do `bin\`): o que o dono vê na interface do AutoCAD é sempre a cópia do pacote.

### Captura WinForms no `accoreconsole` não comprova tela visível

Medido na rodada 183: `Control.DrawToBitmap` em form não mostrado no `accoreconsole` produziu
editor vazio apesar de a grade ter 15 linhas, e paleta sem alguns controles superiores. Não tratar
esse PNG como prova visual nem remover controles para ajustá-lo. Conferir em host com GUI e janela
visível. A primeira tentativa retornou `MK_E_UNAVAILABLE` (0x800401E3); a continuação resolveu:
lançar `acad.exe /nologo <copia.dwg>` num job **BACKGROUND** e manter o pai esperando com
`$processo.WaitForExit()`. Encerrar o script que iniciou o CAD pode deixar a árvore sujeita à
limpeza do job; dormir 40 s e só depois buscar COM não corrige isso. Com o pai vivo, a rodada 183
mediu clique real, Timer fora de comando e novo DWG/retorno, com capturas de desktop recortadas
em `docs/recoder/provas/183-paginas/`. Só encerrar a instância de teste criada pelo harness.

Nesta medição, `(setenv "POSITRON_FOLHA_ACAO" "interface")` via AutoLISP não mudou o que
`Environment.GetEnvironmentVariable` do plugin leu. Definir `POSITRON_*` no ambiente **antes**
de iniciar o CAD funcionou. Não confundir os dois mecanismos de ambiente.

Não rodar dois `cad-autocad-smoke.ps1` no mesmo segundo: os nomes temporários usam carimbo com
precisão de segundo (log/script/cópia do desenho). Na rodada 183 as execuções paralelas colidiram e
misturaram logs. Repetir isoladamente antes de atribuir a saída ao desenho ou à DLL testada.

### Medir a paleta na GUI do AutoCAD: autoload, a janela do banco e as teclas (rodada 186)

Quatro coisas medidas ao rodar a paleta com janela visível (o `pzFolhas` + Timer fora de comando, com
as respostas do prompt nativo por `WScript.Shell.SendKeys`):

- **Reinstale o bundle depois de CADA build.** A interface cheia carrega o plugin pelo **autoload** e o
  `NETLOAD` de outro caminho **não** substitui o assembly já carregado no AppDomain (mesma identidade):
  a sessão roda a DLL do pacote e o sintoma é um `POSITRON_FOLHA_ACAO` novo cair no caminho genérico
  ("sem ação"). A conferência é a segunda linha do log (`Positron: DLL de <data> — <caminho>`): a data
  tem de bater com a do `bin\Debug\AutoCAD\net472`. Corrija com
  `scripts/instala-bundle.ps1 -Cad AutoCAD` **antes** de lançar o CAD.
- **A janela "Banco de Dados do Projeto" (`frmConfiguracaoBDProjeto`) rouba o foco.** O arranque a abre
  quando o desenho ainda não tem banco válido (o `IniciarDWG`, tipo `E`); se ela estiver na frente, os
  `SendKeys` vão para ela (e "respondem" no formulário: medido — o `tbProjeto` recebeu o texto do prompt
  e o desenho passou a apontar para o `.mdb`). Feche-a pelo título antes de mandar teclas
  (`FindWindow(null, "Banco de Dados do Projeto")` + `PostMessage(0x0010)`) e confira o foco antes de
  cada resposta (`GetForegroundWindow`/`GetWindowText` — o alvo é `Autodesk AutoCAD 2020 - [<dwg>]`).
- **O handshake pelo log funciona.** O `Plugin.Escrever` usa `File.AppendAllText` (abre e fecha a cada
  linha), então um script externo pode esperar um marco ("clicando o menu") antes de mandar a primeira
  tecla, em vez de dormir um tempo fixo.
- **`-Banco` fora do `%TEMP%`.** O `scripts/cad-autocad-smoke.ps1` cria o `.db` a partir do `schema.sql`
  com o python do sidecar, que **não** tem permissão de escrita no `%TEMP%` (`unable to open database
  file`): passe `-Banco` dentro da árvore do repo (`.tmp-smoke\provas\…`). O mesmo motivo já está no
  cabeçalho do `cad-projeto-e2e.ps1`.

### `npm run plugin:test` sai 0 sem rodar teste nenhum (o adaptador do xunit não carrega)

**Medido na rodada 148, com o SDK 10.0.100-rc e o `xunit.runner.visualstudio` 2.8.2:** o
`dotnet test` (e o `dotnet vstest`) **não carrega** o `xunit.runner.visualstudio.testadapter.dll`
compilado para net472 — a mensagem é `Falha ao carregar as extensões do arquivo ...` seguida de
`Não há nenhum teste disponível ...` — e o comando **termina com exit 0**. É um falso verde: o
`npm run plugin:test` passa sem ter rodado nada.

O caminho que roda a suíte inteira nesta máquina é o **console runner do xunit** (net472), que não
depende do VSTest:

```bash
# uma vez (fica no .tmp-smoke, que é ignorado pelo git)
curl -sSL -o .tmp-smoke/xunit-console.zip https://www.nuget.org/api/v2/package/xunit.runner.console/2.9.2
mkdir -p .tmp-smoke/xunit && (cd .tmp-smoke/xunit && unzip -o -q ../xunit-console.zip)
# e a cada rodada: TEMP precisa ser um caminho Windows válido (o `BancoDeTeste` grava no TEMP)
TEMP='C:\Users\<voce>\AppData\Local\Temp' .tmp-smoke/xunit/tools/net472/xunit.console.exe \
    cad-plugin/Positron.Data.Tests/bin/Debug/net472/Positron.Data.Tests.dll
# -> Total: 718, Errors: 0, Failed: 0, Skipped: 0
```

O `Path.GetTempPath()` do teste segue o `TEMP` do processo: num shell do Git Bash (onde `TEMP=/tmp`)
as falhas são todas `unable to open database file`, não um defeito do código.

**Fixture LISP no ZWCAD (medido na rodada 211, `scripts/cad-fixture-apagar-derivados.lsp`):**
- `entmakex` não monta `INSERT` com atributos: use `entmake` no `INSERT` (com `66 . 1`), nos `ATTRIB` e no `SEQEND`; no ZWCAD o `(entlast)` depois do `SEQEND` já é o `INSERT`.
- Depois de um comando do plugin que apaga (`APAGAPAGINA`) o ZWCAD não executa as linhas seguintes do `.scr`: faça dump, comando e dump num `defun c:...` único com `vl-cmdf`.
- Erro de LISP dentro do `-Fixture` é silencioso: carregue por um driver `(vl-catch-all-apply 'load ...)` que grava a mensagem num arquivo.
- Não indexe um cache de handles pelo `ename`: os handles do XData saíram em branco. Para listar entidades que foram apagadas guarde `(nome . ename)` e teste com `entget` (rodada 216: `vlax-ename->vla-object` quebrou no `accoreconsole` do AutoCAD 2020, com `bad argument type: VLA-OBJECT nil`, e o dump parou depois do cabeçalho sem erro visível; carregue a fixture por um driver com `vl-catch-all-apply` que grava a mensagem).

**Cópia no `%TEMP%` (medido na rodada 208):** no pacote 2.9.2 do runner não existe o
`xunit.execution.desktop.dll` (ele já está no `bin` do teste): copie o `bin` inteiro para o `%TEMP%` e por
cima só `xunit.console.exe`, `xunit.console.exe.config`, `xunit.abstractions.dll`,
`xunit.runner.utility.net452.dll` e `xunit.runner.reporters.net452.dll`. Resultado da rodada 208:
`Total: 984, Errors: 0, Failed: 0`.

**Teste que lê um contador global da suíte fica intermitente (medido na rodada 219):** estado estático do
plugin (o `MonitorDeConexao.Atual`, o contador de conexões) é **da sessão**, e as classes do xUnit rodam
**em paralelo** (cada classe é a sua própria coleção, não há `DisableTestParallelization`): comparar os
**valores** do contador antes/depois de uma operação do `ProjectStore` falha de forma intermitente —
medido: 1 falha em 2 execuções, com o valor esperado deslocado por outra classe abrindo e fechando
conexão no meio. O determinístico é o que a **própria thread** provoca: filtre os avisos por
`Thread.CurrentThread.ManagedThreadId` e afirme a **contagem** (dois avisos por leitura) e o estado na
abertura. Contador que precisa ser medido isolado mora numa **instância** (o `MonitorDeConexao` tem a
instância e o `Atual` da sessão).

**Acesso negado (medido na rodada 151):** se a árvore do repo estiver numa origem que o .NET Framework
trata como **remota** (a mesma que obriga o `-PastaLocal` do harness do CAD — numa pasta do Desktop,
por exemplo), o runner termina com `System.IO.FileLoadException: Não foi possível carregar arquivo ou
assembly 'xunit.execution.desktop' ... Acesso negado.` A saída é rodar a cópia **fora dali**, no
`%TEMP%`:

```bash
DEST=/c/Users/<voce>/AppData/Local/Temp/pm151; BIN=cad-plugin/Positron.Data.Tests/bin/Debug/net472
RUNNER=.tmp-smoke/xunit/tools/net472
mkdir -p $DEST
cp -r $BIN/. $DEST/          # o bin INTEIRO (o System.Data.SQLite e o xunit.core moram nele)
cp $RUNNER/xunit.console.exe $RUNNER/xunit.console.exe.config $RUNNER/xunit.abstractions.dll \
   $RUNNER/xunit.execution.desktop.dll $RUNNER/xunit.runner.utility.net452.dll \
   $RUNNER/xunit.runner.reporters.net452.dll $DEST/   # as do runner DEPOIS (elas mandam)
(cd $DEST && TEMP='C:\Users\<voce>\AppData\Local\Temp' ./xunit.console.exe Positron.Data.Tests.dll)
```

**Copiar só as `Positron.*` produz falha falsa (corrigido na rodada 181):** sem o
`System.Data.SQLite.dll` o runner falha **46** testes com `FileNotFoundException ... System.Data.SQLite`,
e sem o `xunit.core.dll` do bin ele **nem começa** (`FileNotFoundException ... xunit.core 2.9.2` — a
pasta do runner não traz o `xunit.core`). Por isso `cp -r $BIN/.` e só então as DLLs do runner, que
mandam na versão.

**A raiz do `loadFromRemoteSources` (rodada 168).** O `NETLOAD` que morre com `FileLoadException ...
0x80131515` **dentro da árvore** tem correção na raiz, sem copiar a DLL: o switch
`<loadFromRemoteSources enabled="true"/>` no `<runtime>` do `acad.exe.config` do AutoCAD. Nesta máquina
ele foi aplicado (com o backup `acad.exe.config.positron-bak`) e **medido na interface cheia do AutoCAD
2020**: o `NETLOAD` do caminho `...\Desktop\APP\positron\cad-plugin\...\Positron.Plugin.AutoCAD.dll`
carrega (`Positron: DLL de ... — <o caminho da árvore>`, a barra monta com 9 painéis). O `-PastaLocal`
do harness continua valendo como contorno sem mexer no CAD (e é obrigatório no `accoreconsole`, que tem
o seu próprio `accoreconsole.exe.config`).

Duas armadilhas da cópia: o runner precisa do `xunit.execution.desktop.dll` **na própria pasta** (ele
não o resolve pela pasta do teste) e as DLLs do xunit no `bin` do teste são de versões **diferentes**
(as 2.9.0 do adaptador) — copie as do runner **depois** das do teste, ou só as do `Positron.*`.

### O ensaio do Excel deixa um `EXCEL.EXE` "Pasta1" aberto (rodada 220)

A ponte do Excel **pega a instância aberta ou cria uma** (`VerificaExcel`/`VerificaExcelAtivo`) e o
`Liberar` solta as referências COM, mas **não** fecha uma instância que ela mesma criou. Medido no
`accoreconsole` (rodada 220, exportação dos títulos): o processo do CAD termina e sobra um `EXCEL.EXE`
com um livro em branco (`Pasta1 - Excel`, o carimbo de tempo da medição no `StartTime`). Confira antes
de escrever que o ensaio "não deixou nada aberto" (`Get-Process EXCEL | Select Id,StartTime,MainWindowTitle`)
e feche-o **só** quando o `StartTime` for o da medição — o `CloseMainWindow()` funciona, mas pode levar
uns segundos para o processo sumir (não conclua na primeira checagem).

### As recusas do `Renumerar Páginas` se medem sem um caderno grande (rodada 221)

A mMensagem **27** ("Não há espaço suficiente!") parecia exigir 27 linhas selecionadas — e a cópia do
`Funcional.dwg` tem 16 páginas, então ela ficou "não medida" por cinco rodadas. **Não exige:** o
`calculaEspacoAlfaNumerico` conta **27 nomes por número**, e o limite do espaço é só a próxima página
**não selecionada**. Com uma letra vizinha (`5A` criada pela fixture) e o destino `5`, os dois espaços
dão 1 e **duas** selecionadas já recusam. A forma literal (27 cabe, 28 não) é o destino `3` com a `4`
de limite num caderno de 31 páginas.

```bash
P="C:/.../positron"   # caminho absoluto com barras normais: o LISP não come `\n`
POSITRON_FOLHA_ACAO=renumerar POSITRON_FOLHA_SELECIONADAS="6,7" POSITRON_MOVER_PARA="5;5" \
POSITRON_MSG27_MODO=letra \
POSITRON_PAGINAS_SAIDA_ANTES="$P/.tmp-smoke/provas/221/paginas-antes.txt" \
POSITRON_PAGINAS_SAIDA="$P/.tmp-smoke/provas/221/paginas-depois.txt" \
  powershell -ExecutionPolicy Bypass -File scripts/cad-autocad-smoke.ps1 \
    -Desenho "C:/.../Elet/RCD/Funcional.dwg" -Fixture "$P/scripts/cad-fixture-msg27.lsp" \
    -Comandos "pzFolhas,(pz27:dump)" -Banco "$P/.tmp-smoke/provas/220/projeto.db" \
    -PastaLocal "C:/positron-smoke/cad"
```

Três armadilhas medidas nessa receita:

- **A fila `POSITRON_MOVER_PARA` com duas respostas iguais** (`"5;5"`) prova que a recusa **repete** o
  prompt (o `MsgBox` dá `break` para o `while (true)` do original): saem **duas** mensagens no log, uma
  por resposta. Com a fila esgotada o comando **cancela** (status 5100), que é outro caminho.
- **O destino tem de estar livre.** No modo `trinta` a fixture cria `1..31` **menos a `3`**: criando a
  `3`, a recusa que sai é a **25** ("Esta página já existe"), não a 27. E a linha `0` da grade é
  desmarcada pelo próprio handler: para contar selecionadas, escolha os nomes de propósito.
- **O dump em AutoLISP é ANSI:** os acentos saem quebrados no `.txt` (o layer está certo no desenho).
  Compare **nomes** e a contagem `TOTAL;n`, e para provar o XData use a linha `PAGINA;<nome>;xdata=…`.

### Existe CAD nesta máquina? (nunca afirme ausência sem medir — medido em 2026-10-16)

Uma ausência é uma **medição, com data** — e são precisos os três: o **registro**, as **pastas** e o
`where`.

```powershell
Get-ItemProperty 'HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\*',
  'HKLM:\SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\*',
  'HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\*' |
  Where-Object { $_.DisplayName -match 'AutoCAD|ZWCAD|ZWSOFT|GstarCAD|BricsCAD' } |
  Select-Object DisplayName,InstallLocation
Get-ChildItem 'C:\','D:\' -Filter 'ZWCAD*.exe' -Recurse -Depth 4 | Select-Object -ExpandProperty FullName
where.exe acad.exe ; where.exe ZWCAD.exe
```

Medido em **2026-10-16** (registro + pastas + `where`, re-medido ao anoitecer depois da rodada 213):
`acad.exe` só em `C:\Program Files\Autodesk\AutoCAD 2020\`; nenhum `ZWCAD*.exe` em `C:\`/`D:\`
(profundidade 4, e `/c`+`/d` são as únicas unidades montadas); nenhuma chave `ZWSOFT` em
`HKLM`/`HKLM\WOW6432Node`/`HKCU`; o registro de desinstalação só traz as entradas do AutoCAD 2020
(**não** há 2010/2011/2013). Valia a pena medir: o texto antigo desta seção afirmava o contrário e
teria feito a rodada 212 medir num host "inexistente".

**A ausência do ZWCAD não é estável — e é por isso que se mede.** A rodada **211**, do **mesmo dia**,
mediu no **ZWCAD 2026** (`C:\Program Files\ZWSOFT\ZWCAD 2026`); a leitura desta seção, mais tarde no
mesmo dia, já **não** o encontra. Não dá para saber daqui se ele foi desinstalado no meio do dia — e é
exatamente o ponto: ausência e presença de host são **medições com data**, nunca estado herdado. Antes
de escrever "não medido porque não há CAD X", rode os três comandos acima.

### Levantar o `CellEndEdit` real da grade no `accoreconsole` (rodada 213)

O `accoreconsole` não tem paleta nem janela, mas o **evento real** do WinForms funciona nele: crie um
`Form` fora da tela (`ShowInTaskbar = false`, `FormBorderStyle.None`, `Location = (-3000, -3000)`),
adicione o controle, `Show()`, `Application.DoEvents()`, e então
`grade.CurrentCell = linha.Cells[0]; grade.BeginEdit(true); grade.EditingControl.Text = valor; grade.EndEdit();`.
Medido: `BeginEdit=True; EndEdit=True` e o `CellEndEdit` disparou (o `Carregar()` que reconstrói a
grade **dentro** do evento não estourou — era o risco em aberto da rodada 212). Tire o controle do
formulário com `Controls.Remove` antes do `Close()`, senão ele é descartado junto e o resto do harness
(que ainda imprime/captura) quebra.

### O `\r` do dump LISP engana a conferência por linha (rodada 213)

Os dumps escritos por `(write-line ...)` saem com **CRLF**: um `grep '^LAYER;'` casa, mas uma
conferência por conteúdo pode passar batido. Foi o que escondeu três sentinelas **já recalculadas**
nesta rodada — o `TextString` delas tinha virado `7A`/`7A`/`1000`, então `grep SENTINELA` deu a
impressão de dump vazio até ler o arquivo inteiro.

### Erro de LISP no `-Fixture` é silencioso — e pode matar os `defun` seguintes (rodada 214)

O `(load ...)` que o harness põe no `.scr` roda **antes** do `NETLOAD`, e um estouro no meio do
arquivo faz o load **parar ali**: tudo o que vem depois (inclusive os `defun` que o `.scr` chama)
**não existe**. O sintoma é um dump **vazio/sem arquivo nenhum** — e o `grep` do log do plugin não
mostra nada, porque o erro saiu no stdout do `accoreconsole`, que o harness **não** captura.

Duas medidas que resolvem na hora:

- **grave o progresso no load**: um `(defun pz:log (s) ...)` que faz `append` num arquivo, chamado
  entre os passos, mostra **até onde** o load chegou;
- **teste a expressão isolada** num driver que só usa `vl-princ-to-string` sobre o passo suspeito.

O defeito medido nesta rodada: `(car (assoc -3 d))` **não é** o XData de um `entget` — `(assoc -3 d)`
já é a lista `(-3 ("Eletron" ...))` e o `car` devolve a **chave** `-3`. Para o valor (a lista marcada
com o app name) é `(cadr (assoc -3 d))`. Com o `-3` no lugar do valor, o `append` estourava e os
`defun` do dump nem eram criados.

```lisp
(setq d (entget (tblobjname "LAYER" "6") '("Eletron")))
(cadr (assoc -3 d))   ; -> ("Eletron" (1000 . "Unidade") (1000 . "UNIFILAR") (1000 . ""))
```

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

### O XData do **ModelSpace** e como montá-lo por LISP (medido na rodada 181)

Três coisas que custam uma rodada cada se não forem sabidas (o
`scripts/cad-fixture-iniciar.lsp` foi feito com elas):

- **`entget` de um `BlockTableRecord` não devolve o grupo `-3`.** O XData do ModelSpace (o
  `Eletron` do tipo do desenho, o `CORRECAO` das marcas) só sai pelo **ActiveX** —
  `(vla-GetXData (vla-get-ModelSpace doc) app 'tipos 'valores)`. No `accoreconsole` o ActiveX
  **não existe** (o `vlax-get-acad-object` devolve `nil` e o `vla-GetXData` morre com
  `bad argument type`), então: o que depende do XData do ModelSpace se mede na **interface cheia**,
  e no headless só o XData das **entidades** (por `entget` com a applist `'("*")`).
- **`entmake` descarta o valor `1000` de string vazia.** O layout do `AUXCONEXAO` no original tem
  `1000 ""` no meio e o buffer sai **torto** (os índices pulam e o `entget` devolve os valores
  deslocados). Montando por LISP, use um texto não vazio em cada `1000` e não conte com o vazio.
- **O grupo `-3` do `entget` é uma LISTA de blocos**: `(-3 ((APP (1000 . valor)...)))` — o bloco do
  app pedido é o **primeiro** item (`(car (cdr (assoc -3 (entget e (list app)))))`), e a app exata
  vem pela applist. O `(entget e)` **sem** applist também não traz o `-3` no AutoCAD 2020 (mesma regra
  do ZWCAD 2026, acima).

### `DataGridView` sem `Handle` (fora da tela): `ClearSelection()` volta a selecionar a linha 0 (medido na rodada 182)

Ao medir um `UserControl` no `accoreconsole` (o `pzFolhas`, que monta o `FolhasControle` sem criar a
janela), a grade tem `MultiSelect = false` (o padrão do original) e a primeira linha nasce com a
`CurrentCell`. Chamar `_grade.ClearSelection()` e depois `linha.Selected = true` **sem** mover a
`CurrentCell` deixa a linha 0 selecionada junto (ou toma de volta a seleção quando `Rows.Clear()` +
`Rows.Add(...)` reconstrói a grade), e `FirstDisplayedScrollingRowIndex` lança
`InvalidOperationException` por falta de barra de rolagem. Mova `_grade.CurrentCell = linha.Cells[0]`
antes de marcar `Selected = true` e engula o `InvalidOperationException` da rolagem — na tela viva
funciona igual e no harness a seleção mede a linha certa.

### Comando com prompts (`GetKeywords`/`GetSelection`/`GetString`) pelo harness

O `-Comandos` do `cad-zwcad-smoke.ps1` vira **uma linha do `.scr` por item** e descarta item vazio,
então não dá para mandar o Enter que fecha uma seleção como item próprio, e uma vírgula no valor
(`2,5`) parte o item. A saída é a regra do script do CAD: **espaço vale Enter**. Uma linha só
responde a todos os prompts, inclusive o Enter duplo que fecha a seleção (medido no ZWCAD 2026, rodada 176):

```
-Comandos "EDCON A _ALL  4 VM"   # EDCON, modo A, seleção _ALL, Enter (fim da seleção), Seção=4, Cor=VM
```

Prompt de `GetString` com `AllowSpaces = false` termina no espaço, como no teclado. Um
`(expressão LISP)` também pode ser item do `-Comandos` (é assim que o fixture
`cad-fixture-edcon.lsp` despeja o resultado **depois** do comando).

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
# problemas=238
# area;tipo;tabela;identificador;detalhe
Desenho;BorneSemFiacao;Fiacao;4DD53;borne do desenho sem ponto de fiação
...
# 238 linha(s)
```

O total subiu de 107 para **117** (rodada 33) e para **236** (rodada 34) com duas
regras de **higiene do desenho** portadas de checagens próprias da tela do produto —
elas não indicam projeção errada, e sim dado faltando no desenho:

- **`ReguaVazia` (10):** o `buscaReguasVazias` do `ClsVerificadorProjetoFiacao` (linha
  1815) varre o **dicionário de réguas** e aponta toda régua cujo par `(painel, régua)`
  não aparece nos bornes — régua declarada e nunca usada no caderno. O original guarda
  as usadas como texto `"painel,régua"`; aqui a chave é o par de inteiros.
- **`BorneSemLm` (119):** o `GijcRTCGe3` da mesma tela (linha 2720) monta a árvore
  `TreeViewBornesLM` com todo borne do desenho cujo `lm == 0`. O `lm` é resolvido do
  dicionário **na gravação** do borne (`DicionarioBorne.BuscaLMdaRegua`, chamado só em
  `XDataDispositivosMaster.GravarXDataDispBorne`), e o verificador lê o XData **cru** —
  então `lm == 0` quer dizer que a régua não define LM (ou o borne nunca foi regravado
  pelo produto), exatamente o que os 119 bornes desta cópia do desenho mostram.

O relatório continua separando por tipo (`VERIF: por tipo — …`), que é o que mantém o
número legível: `BorneSemFiacao` e `BorneSemLm` são coisas diferentes.

**Rodada 45 — painéis fora do cadastro (`lPnAoagado`).** O painel usado no desenho que
não existe no cadastro do projeto vira `PainelSemCadastro`. A sutileza está na origem do
dicionário: `Dicionario.BuscaNomeDoPainel` **não** lê o desenho — ele chama
`cDadosAccess.carregaPainelDicionario()`, ou seja, o mapa `índice → nome` mora no **banco**
(a tabela `Paineis`, que o app preenche e que o importador traz). Sem cadastro, todo
painel do desenho responde `"???"` e o `ClsVerificadorProjetoFiacao` o joga em
`lPnAoagado`; por isso a regra só faz sentido com o cadastro carregado.

A verificação foi feita **dos dois lados**, que é o que prova a regra:

| Banco | `VERIF` por tipo |
|---|---|
| sem o cadastro (projeção pura) | `BorneSemLm: 119; BorneSemFiacao: 107; ReguaVazia: 10; SobreposicaoAusente: 2; **PainelSemCadastro: 2**` — total **240** |
| com o cadastro importado (480 painéis) | os quatro de sempre — total **238** (a linha de base) |

Os 2 painéis são os que os blocos `P`/`E` e as conexões do desenho citam; com o cadastro
do produto eles existem, e a regra fica limpa.

**Rodada 35 — conexões órfãs (`carregaOrfao`, linha 1311).** É o botão `bt2Orfao` da
tela, e a regra é mais fina do que a nossa aproximação (`BorneSemFiacao`). O
`HandleSup` do verificador é `"OK"` por padrão e, nas `Tipo 3`, recebe o campo
`Handle` do XData — o handle da conexão com que esta se **superpõe**
(`ClsVerificadorProjetoFiacao:813-833`). A partir daí são dois laços: (1) conexão sem
sobreposição (`HandleSup` vazio); (2) conexão cujo `Potencial` não aparece em nenhuma
`Tipo 1`/`2` — potencial isolado — ou cuja sobreposição aponta para um handle que não
existe **como conexão na mesma página**. O original dedupa por potencial durante o
segundo laço e compara com o conjunto de handles das conexões; aqui é o mesmo, sem o
filtro de painéis em uso que a tela aplica.

No desenho real: **2** `SobreposicaoAusente` e **zero** de potencial isolado. O
`ELETREL` dá os dois com nome e endereço:

```
Desenho;SobreposicaoAusente;Conexoes;5BA4;sobreposição "52BF" não existe como conexão na página "18" (potencial 159)
Desenho;SobreposicaoAusente;Conexoes;2163E;sobreposição "215D1" não existe como conexão na página "18" (potencial 1221)
```

Ou seja: duas `Tipo 3` que apontam para um handle que não é conexão nenhuma na página
18 — referência pendente no desenho, não na projeção. O total do `VERIF` vai a **238**.
Como no original, as conexões com `Jumper == "JUMPER"` são **descartadas** antes de
montar o conjunto (`ClsVerificadorProjetoFiacao:791`) — são do `JMP`, não da fiação; o
filtro está no código e tem teste (sem efeito neste desenho, que não tem jumper).

**Rodada 59 — terminais e bornes das portas (`bt5Terminais`, `bt6Portas`).** As duas
últimas checagens da tela são as grades que faltavam, e as duas saem do **mesmo**
`yBNcmOtuQS` (`frmVerificadorProjetoFiacao`): a `dgTerminais` (o `GroupBox5`, mostrada
pelo `bt5Terminais`) e a `dgBornes` (o `GroupBox8`, pelo `bt6Portas`).

O insumo não é a tabela — é o **próprio bloco de porta** (`E`), via
`LeOsTerminaisDeUmaPorta`: os atributos `T*`/`B*`/`R*` são lidos crus, ordenados pela tag
e unidos (`T*` → `sTermM`/`sTerm`, `B*` → `sattB`/`sBorn`, `R*` → `sRegua` com `"; "` e
dedup), e o texto `"0"` ou vazio vira o caracter indefinido `"?"`. Dois detalhes do
original mudam o resultado e foram reproduzidos:

- **bloco com régua E bornes zera os terminais** (a porta é de borne, não de terminal);
- o `sTermM` é **substituído** pelos terminais do **modelo de máscara** quando a porta
  casa com um por `(modelo, porta)` (`mPortas[i].sTerminais`).

A grade monta dois grupos: **"Indefinido"** (algum valor `"?"`) e **"Duplicado"** — e a
chave do `list` é **única para todas as portas**:
`BuscaNomeDoPainel(painel) + "/" + Nome1["-" + Nome2]` + `"-"` + valor, com a **régua**
ainda no meio dos bornes. É por isso que o cadastro de `Paineis` importa aqui: sem ele o
`BuscaNomeDoPainel` responde `"???"` e todo mundo colide. Entrou o
`ProjectStore.LerNomesDePaineis` (o mapa `índice → nome` da tabela `Paineis`, o mesmo
caminho do `lPnAoagado`) e o `PortaNoDesenho` ganhou `Nome1`/`Nome2`/`Painel` (o painel da
máscara resolvido pelo `BuscaPainelDispositivo`, no `PortasDoDesenho`).

**Medido no desenho real:** o `VERIF` continua lendo **45 blocos de porta** e as duas
regras saem **vazias** — a linha de base segue **249** e o `cad-verif-baseline.py`
confere. Como nas rodadas 52–57, o zero é a cópia estar limpa: o insumo existe (os 45
blocos têm atributos `T*`, e as chaves saem distintas).

O verificador do produto é bem maior que as regras de tabela: a tela tem **14 checagens** (`bt1Fiacao` … `bt14PortasDiscrepantes`, rótulos em
`DeclaracoesGeral.mMensagem[1, id]`) e o motor fica em
`ClsVerificadorProjetoFiacao.cs` (2.173 linhas), com uma análise própria do desenho
(`buscaDadosDeFiacaoDWG`, linha 430) que alimenta `carregaOrfao` (1311), `carregaTree`(1159) e companhia. O recoder cobre **as 14** checagens da tela — todas casam 1:1 com um
botão desde a rodada 59, quando o `bt5Terminais`/`bt6Portas` entrou —, incluindo as que
dependem da análise geométrica do desenho — o órfão, a régua, o LM, os intervalos de
borne, a régua da máscara, as portas discrepantes, o principal × auxiliar, os bornes
editados (`bt9`, rodada 55), os blocos duplicados (`bt12`, rodada 56) e os terminais e
bornes das portas (`bt5`/`bt6`, rodada 59). O mapeamento botão a botão está no `PLANO.md` §7.1. O verificador
da **interligação** (outra tela) teve a árvore portada na rodada 57 (jumper indefinido,
jumper duplicado e trecho indefinido, o `carregaTree`) e o **cabo indefinido**
(`IndefineCabosNaoExistentes`) entrou na rodada 60 como comando próprio (`INDCABO`) — é
uma **ação** (regrava o XData do desenho), não uma checagem read-only; receita e medição
abaixo.

## Relatório consolidado

O `docs/RELATORIO.md` é o **retrato datado** (rodada 115) das entregas por frente, das medições no
desenho real, das corroborações cruzadas, dos quirks medidos e do que ficou fora do recorte com
motivo — ele **não** é reescrito a cada rodada. A **contagem viva** de cobertura (comandos × telas ×
regra) é a **§0 do `AUDITORIA.md`**, que se reproduz com `scripts/cobertura-do-reverso.ps1`; o estado
do plano (comandos, testes, frentes) está no topo do `PLANO.md`. Abaixo, o detalhe rodada a rodada
(mais novo primeiro) **até a rodada 175**; da 176 em diante cada rodada é um arquivo em `docs/recoder/rodadas/` — as tabelas de números que aparecem no meio de uma rodada são **o que aquela
rodada mediu**, e não a contagem de hoje.

**Rodada 175 — Cadeia do CAD completa: `TrocaColunas`, `AtualizaRevSimplificada` e `attsync` por referência, medidos no ZWCAD 2026.**
Fecha as pendências que haviam ficado fora da cadeia pós-troca do formato (`Caderno.CriaCaderno:241-250`):

- **Regra pura** (`Positron.Data/Paginas/ColunaDaPaginaXData.cs`, `ColunaDaPagina.cs`):
  - `ColunaDaPaginaXData`: layout DXF com 5 valores do XData `DiagLog`/`COLUNAS` (`XDataGeral.gravarXDataColuna` e `verificaXDataColunas`), lendo o tipo da coluna e gerando os valores carimbados com usuário e data;
  - `ColunaDaPagina`: modelo do par `(página, tipo)` com igualdade case-insensitive e deduplicação (`Deduplicar`) preservando a ordem da primeira aparição, espelhando a matriz de `Pagina.TrocaColunas`.
- **Troca de colunas** (`Positron.Plugin/Paginas/TrocaColunasDoDesenho.cs`):
  - Localiza no ModelSpace as entidades de coluna marcadas com XData `DiagLog`/`COLUNAS`, apaga as entidades antigas do desenho, e reinstancia para cada `(página, tipo)` único as entidades clonadas da definição do novo bloco de formato (`formato.BlockTableRecord`) cujo layer seja igual ao tipo da coluna, regravando o XData.
- **Restauração de revisões simplificadas** (`Positron.Plugin/Paginas/RestauracaoDoFormatoDoDesenho.cs`, `Comandos.cs`):
  - O comando `CAD` passa a capturar `RevisoesDoDesenho.LerSimplificadas()` antes da troca (espelhando `Revisao.capturaRevisoesSimplificadas()`);
  - A cadeia de restauração regrava as revisões nos novos campos de página de índice 8 gerados pelo formato novo (`RevisoesDoDesenho.GravarSimplificadas`).
- **Attsync estrutural e ativação da capa**:
  - `RevisoesDoDesenho.CriarDefinicoesDoFormato` agora expõe a contagem de referências de revisão sincronizadas estruturalmente via `Attsync`;
  - Ao final da cadeia de restauração, ativa com segurança o layer da capa (`PaginaAtivaDoDesenho.Ativar`), reproduzindo `DeclaracoesGeral.ativo.Pagina = Pagina.retornaNumeroCapa()`.
- **Fora, com o motivo:** apenas a chamada de interface `Comandos.GerenciadorPagina()` (abrir/focar janela interativa).

**Verificação:** `plugin:test` **861** (+6 testes em `ColunaDaPaginaTests`), as duas builds (ZWCAD e AutoCAD) **0 avisos, 0 erros**; **medido no ZWCAD 2026** no `Funcional.dwg` (DWG 63) com `formato173.dwg`:
```
CAD: formato trocado — bloco "formato173" (definição "A3_PADRÃO_ELB" e 1 referência(s) apagada(s)); 30 atributo(s) (15 preservado(s), 13 protegido(s)); cadeia: 77 campo(s) apagado(s), 0 TOT, 77 campo(s) em 16 página(s), 1 definição(ões) de revisão (0 apagada(s)), 16 CONT/FL/TOT/ALTERNATIVO, 45 título(s), 16 rev. simplificada(s); maxCapa 1/maxCorpo 0; capa "1" ativa.
```

**Rodada 174 — Páginas: inserir e excluir com AtualizaContTotFl e ativação segura, medidos no ZWCAD 2026.**
O reverso executa o recálculo dos marcadores de sequência (`AtualizaContTotFl()`) e a ativação segura de página tanto na criação/inserção quanto na exclusão de páginas. A rodada fecha essas pontas no plugin:

- **Regra pura** (`Positron.Data/Paginas/PaginasDoCaderno.cs`): `EncontraProximaPagina(IReadOnlyList<string> paginas, string pagina)` — reproduz o algoritmo do `Pagina.cs:2742` do reverso (`EncontraProximaPagina`): dada a lista ordenada de páginas e a página que está sendo apagada, localiza a página restante imediatamente posterior ou, se a apagada for a última, seleciona a última restante.
- **Inserção de páginas** (`Positron.Plugin/Paginas/CriacaoDePaginaDoDesenho.cs`, `Comandos.cs`, `FolhasControle.cs`):
  - `CriarPagina`: após criar o layer, copiar os campos do formato e os títulos da página anterior, agora invoca `RestauracaoDoFormatoDoDesenho.AtualizarContTotFl(banco)` e ativa a nova página (`PaginaAtivaDoDesenho.Ativar(resultado.Nome)`), espelhando `Pagina.cs:2710-2711`.
  - Novos comandos `INSPAG` e `INSEREPAGINA` (`ExecutarInserirPagina`): inserem página entre páginas especificadas via `POSITRON_PAGINA_ANTERIOR` e `POSITRON_PAGINA_POSTERIOR` (ou entre a página ativa e a próxima válida) recalculando `CONT/FL/TOT`.
- **Exclusão de páginas** (`Positron.Plugin/Paginas/ExclusaoDePaginaDoDesenho.cs`, `Comandos.cs`):
  - Guarda de layer corrente: se o layer a ser apagado for o `Clayer` ativo do banco, altera `banco.Clayer` para o layer `"0"` antes de apagar a camada (`layer.Erase()`), reproduzindo `Pagina.cs:2225` e evitando erro de layer em uso (`eCannotRenameOrDeleteCurrentLayer`) no AutoCAD/ZWCAD.
  - Recálculo de sequência: executa `RestauracaoDoFormatoDoDesenho.AtualizarContTotFl(banco)` após o commit da transação de exclusão.
  - Ativação segura no comando `APAGAPAGINA`: quando a página apagada é a ativa, seleciona e ativa a próxima página restante via `PaginasDoCaderno.EncontraProximaPagina`.

**Verificação:** `plugin:test` **855** (+6 testes em `PaginasDoCadernoTests`), as duas builds (ZWCAD e AutoCAD) **0 erros, 0 avisos**; **medido no ZWCAD 2026**:
- Criação e inserção (`NOVAPAGINA` / `INSPAG`):
  ```
  NOVAPAGINA: página "4" criada depois de "3" — layer + 5 campo(s) do formato copiado(s) + 3 título(s) herdado(s) de "3" + 2 CONT/FL/TOT recalculado(s).
  INSPAG: página "5" inserida entre "4" e "fim" — layer + 5 campo(s) do formato + 3 título(s) herdado(s) de "4" + 4 CONT/FL/TOT recalculado(s).
  ```
- Exclusão com layer ativo (`APAGAPAGINA`):
  ```
  APAGAPAGINA: 1 página(s) apagada(s) (4) — 5 entidade(s) do ModelSpace e 1 layer(s).
  ```
  O CAD chaveou `Clayer` com segurança para `"0"`, apagou as 5 entidades e o layer sem colisão, e recalculou os campos `CONT/FL/TOT` restantes.

**Rodada 173 — a cadeia pós-troca do formato (o `CAD`, o resto do `Caderno.CriaCaderno`), medida no AutoCAD 2020.**
A rodada 170 entregou a **troca em si** e deixou a **cadeia que o original roda depois de inserir o bloco** fora, com o motivo (o XML doc do `TrocaDeFormatoDoDesenho`). É o que entra agora:

- **Regra pura** (`Positron.Data/Paginas/CamposDoFormato.cs`): o que o `ApagarCamposPaginas` apaga (todo texto com o XData do título, o `LeXDataTitulo > 0`); o campo `TOT` do `criaCamposTOT` (o atributo protegido de tag `TOT`, texto `"1"`, índice 7); e o valor do `AtualizaContTotFl` por **índice** — 9=ALTERNATIVO (o alternativo da página), 5=CONT (a próxima página válida), 6=FL (o layer), 7=TOT (a última página) —, com o `Conf.incluirColuna` em 3..5 trocando a página pelo **alternativo** dela quando existe (o ramo `BuscaAlternativo(text, true)` do original).
- **Adapter** (`Positron.Plugin/Paginas/RestauracaoDoFormatoDoDesenho.cs`): depois da inserção do bloco, apaga os campos antigos, recria o `TOT` e os **oito campos** de cada página (o `CriacaoDePaginaDoDesenho.CopiarCampos`, agora com o `layerRef` — a **capa** na capa e o `-1` nas demais), refaz as definições `Revisao_Capa{n}`/`Revisao_Corpo{n}` e apaga as que sobram (`RevisoesDoDesenho.CriarDefinicoesDoFormato`, o `for l = maxCapa To 7`), restaura os **títulos** capturados antes da troca (`TitulosDaPaginaDoDesenho`) e regrava o `maxCapa`/`maxCorpo` no XData da configuração (`ConfiguracaoDoDesenho`). O comando `CAD` captura os títulos antes do `Trocar`, e a revisão/os títulos só rodam quando o desenho **já tinha** formato (o `flag2` do original).
- **Fora, com o motivo:** o `TrocaColunas` (as colunas de cruzamento), o `AtualizaRevSimplificada`, o `attsync` por referência e a página ativa/paleta do fim do `CriaCaderno`.

**Verificação:** `plugin:test` **849** (+8, `CamposDoFormatoTests`), as duas builds **0 avisos**; **medido no AutoCAD 2020** (`Funcional.dwg`, DWG 63) com a fixture nova `scripts/cad-fixture-formato.lsp` (exporta a definição do formato do próprio desenho por `_.-WBLOCK`, e o `CAD` a usa como formato novo):

```
CAD: formato trocado — bloco "formato173" (definição "A3_PADRÃO_ELB" e 1 referência(s) apagada(s));
30 atributo(s) (15 preservado(s), 13 protegido(s)); cadeia: 77 campo(s) apagado(s), 0 TOT,
77 campo(s) em 16 página(s), 1 definição(ões) de revisão (0 apagada(s)), 16 CONT/FL/TOT/ALTERNATIVO,
45 título(s); maxCapa 1/maxCorpo 0.
```

Com o `Revisao.dwg` como formato (que não tem os campos de página), a cadeia apaga os 77 campos do formato antigo e **não** recria nenhum (`0 campo(s) em 0 página(s)`), apaga 1 definição e regrava a configuração com `maxCapa 0/maxCorpo 0` — o outro lado do ramo.

**Rodada 170 — o botão CADERNO: "cria ou troca o formato" (o comando `CAD`), a peça que faltava no painel Caderno da barra.**
O item `CADERNO` da barra estava **desativado**: o `BarraDoReverso.Dados.cs` o gerou como `Coberto = false` (nenhum `[CommandMethod("CAD")]` no plugin) e o `Utilizavel` do `ItemDaBarra` só liga com `TemComando && Coberto && !Desativado`. O original (`Caderno.CriaCaderno`, `Comandos.cs:107`) é a **troca do formato** do caderno — e é o que entra:

- **Regra pura** (`Positron.Data/Paginas/TrocaDeFormato.cs`): as decisões do `CriaCaderno` sobre dados — `TagsProtegidas` (as **59** do `attProtCollection`: os quatro títulos, `PAINEL`, `SECAO`, `FL`, `CONT`, `REV`, `TOT`, `ALTERNATIVO` e as seis famílias `REV`/`DESC`/`DATA`/`ELAB`/`VERIF`/`APROV` × `0..7`) e o `Protegida`; o `ValePreservar`/`Captura` (o `CapturaAtributosDoFormato`: não protegida **e** com texto); o `ValorPreservado` (o `euxs3rkWO`: casa pela **página em decimal**, o `calculaPaginaDecimal`, e pela **tag** sem caixa); o `Definir` (protegida → invisível e vazia; o resto → o valor preservado, que no original é o `DefaultValue` do prompt) e o `PrecisaRenomearCapa` (renomear para `"1"` só quando a capa tem outro nome).
- **Adapter** (`Positron.Plugin/Paginas/TrocaDeFormatoDoDesenho.cs`): o `Existe` (o `ExisteFormato`), o `EscolherFormato` (o `GetFileNameForOpen`, "Selecione o formato:") e o `Trocar`: captura os atributos da **referência** do formato antigo, apaga a definição e **todas** as referências dela (o `ApagaDefinicaoReferencias`, as referências primeiro e o registro depois), insere o DWG do formato novo como bloco na **origem** no layer `0` (`Database`/`ReadDwgFile`/`Insert`), carimba o XData `DiagLog`/`Formato` (1001 "DiagLog", 1000 "Formato", 1070 3, 1000 " ") e **recria** um `AttributeReference` por definição com a instrução da regra; a capa vai a `"1"` antes da troca e volta ao nome antigo no fim. No modo interativo cada atributo não protegido é **perguntado** (o `GetString` com o prefixo `CAPA->`/`CORPO->` e o valor preservado de padrão), como o original.
- **Comando `CAD`** (`Comandos.cs`) com os **diálogos do original**: a confirmação `MsgBox` Yes/No quando já existe formato (a mMensagem 75) e o diálogo do DWG. Com a convenção `POSITRON_*`, o `POSITRON_FORMATO` (caminho do DWG) e o `POSITRON_FORMATO_TROCAR=1` (a confirmação) rodam o mesmo **sem diálogo nem prompts** — é o caminho de um script, que o dono pode usar numa medição futura. As cinco mensagens do original (70/71/73/74/75) entraram no `MensagensDoReverso`.
- **Barra e mapa de comandos regenerados** (`extrair-barra-do-reverso.ps1`/`extrair-comandos-do-reverso.ps1`): os cobertos da barra **123 → 124**, o painel **Caderno 8 → 9** (o `CADERNO` passa a `coberto`) e o `ComandosDoReverso.Dados.cs` marca o `CAD` como `JaNoPlugin`.
- **Fora, com o motivo:** a cadeia que o original roda **depois** de inserir o bloco — o `Pagina.CarregaPaginas`/`OrdenaMatrizPaginas`/`ApagarCamposPaginas`/`criaCamposTOT`/`criaCamposFormato` de cada página, o `verificaCriaBlocoRevisao`, o `AtualizaTitulos`/`AtualizaRevSimplificada`/`TrocaColunas`, o `AtualizaContTotFl` e o `GravarXDataConfiguracao`, fechados pelo `GerenciadorPagina` — fica como a fatia seguinte (a troca em si, o que o botão faz, entra inteira). Também fora: o `attsync` por referência.

**Verificação:** `plugin:test` **831** (+8: os 7 de `TrocaDeFormatoTests` e o `OBotaoCaderNoDaBarraFicouUtilizavel`, que fixa o item da barra como **utilizável** — o critério do dono), as duas builds (ZWCAD e AutoCAD) **0 avisos**.
> **Armadilha do instrumento (medida nesta máquina, como nas rodadas 148/168):** o `npm run plugin:test` sai **exit 0 sem rodar teste nenhum** neste SDK .NET 10 preview (o adaptador do xunit não carrega). A suíte foi rodada pelo **console runner do xunit** fora da árvore (a receita está na seção `npm run plugin:test` sai 0 sem rodar teste nenhum, acima), com os **831** verdes. **Não medido no CAD:** a troca é **modal** (diálogo de arquivo + um prompt por atributo + o `MsgBox`); o caminho `POSITRON_FORMATO` existe para a medir num script quando o dono quiser — no `Funcional.dwg` (DWG 63) um formato novo de teste ainda não foi rodado.

**Rodada 169 — Páginas e Revisão: as duas pendências que sobraram (o `NOVAPAGINA` depois da ativa e o `attsync` das referências).**

**1) `NOVAPAGINA` insere depois da página **ativa**.** A rodada 164 registrou a divergência: o recoder calculava a página sempre **depois da última**, enquanto o `criarUmaNovaPagina` do original parte da página **ativa** (`DeclaracoesGeral.ativo.Pagina`) e calcula entre ela e a **próxima válida** (`BuscaProximaPaginaValida`, com o sentinela `1000000` quando a ativa é a última — que o `NovaPaginaEntre.Calcular` já trata como o vazio). O `ExecutarNovaPagina` passou a ler a ativa (`PaginaAtivaDoDesenho.Ler`, o mesmo leitor do `ATIVAPAGINA`), com `POSITRON_PAGINA` sobrepondo (o recorte de teste, como no `ATIVAPAGINA`) e a última como fallback quando a ativa não é do caderno; entrou o overload `PaginasDoCaderno.ProximaValida(IReadOnlyList<string>, string)` sobre os nomes crus.

**2) O `attsync` das referências antigas.** O `verificaCriaBlocoRevisao` do original, depois de refazer cada definição, dispara `_.attsync _Name <def>` em **cada referência** dela. A parte **estrutural** entrou como regra pura `SincronizacaoDeAtributos.Calcular` (as tags da definição que a referência não tem — acrescentar — e as da referência que a definição não tem — remover, sem caixa) e o `RevisoesDoDesenho.Attsync`, chamado ao fim de cada `VerificaCriaDefinicao`, acrescenta os que faltam (do `AttributeDefinition` correspondente) e tira os que sobraram. **Divergência deliberada:** o `ATTSYNC` do CAD rebobina os valores para o padrão da definição — e como as cópias têm `TextString` vazio, isso **apagaria a revisão das páginas não editadas**; o recoder reproduz só a estrutura, preservando os valores. O stub ganhou o `GetBlockReferenceIds`/`ObjectIdCollection` para o gate de compilação.

**Verificação:** `plugin:test` **823** (+6: `SincronizacaoDeAtributosTests` e o overload novo em `PaginasDoCadernoTests`), as duas builds **0 avisos**. **Medido no AutoCAD 2020** (`Funcional.dwg`, DWG 63): com `POSITRON_PAGINA=15` (página do meio do caderno, a próxima é `16`) o `NOVAPAGINA` criou a **`15A` depois de `15`** (o `Calcular` de duas páginas consecutivas acrescenta a letra, como o original); antes o comando criava sempre depois da última. **Não medido:** o `attsync` em si (exige um desenho com bloco de revisão já apontando para uma definição velha) — a regra pura tem teste e o adapter entra no caminho do `REVCOMP`, cuja janela é modal.

**Rodada 168 — Revisão Completa: a criação das definições `Revisao_Capa{n}`/`Revisao_Corpo{n}` (o `verificaCriaBlocoRevisao`) e o `maxCapa`/`maxCorpo` do formato.**
O que as rodadas 166–167 deixaram **aberto**: o plugin só regravava os blocos de revisão **que já existiam** e, quando a definição `Revisao_Capa{n}`/`Revisao_Corpo{n}` não estava no desenho, o bloco era **pulado** (a conta `SemDefinicao`); o `maxCapa`/`maxCorpo` vinha de uma contagem **informal** (quantos `BlockTableRecord`s começam com `Revisao_Capa`/`Revisao_Corpo`). Agora entra a regra que o original chama no **início** do `AtualizaRevCompleta`:

- **Regra pura** (`Positron.Data/Paginas/DefinicoesDeRevisao.cs`): o `verificaCriaBlocoRevisao` em três decisões — `Nome(layer, tipo)` (a capa ou o `-1`, com o dígito da posição: `Revisao_Capa0`…/`Revisao_Corpo0`…), `Copiar(layerDoAtributo, tag, layerAlvo, tipo)` (o atributo do formato entra na definição quando o **layer** casa, a **tag** está no `attRevProtCollection` — as 48 tags `REV`/`DESC`/`DATA`/`ELAB`/`VERIF`/`APROV` × dígitos `0..7` — e ela **termina** com o dígito) e `Contar(formato, capaLayer)` (o `maxCapa`/`maxCorpo` do `carregaConfiguracaoRevisao`: só as tags **numeradas** `REV0..7`, por layer — o `REV` solto só liga um flag no original e **não** conta).
- **Adapter**: `FormatoDoDesenho` (novo) acha o bloco de formato (o `BlockReference` do ModelSpace com o XData `DiagLog`/`Formato`) e lê as `AttributeDefinition` da **definição** dele (o `blockFormatoName` — a definição, não os valores da referência); `RevisoesDoDesenho.GravarCompletas` passa a **criar/refazer** cada definição (esvazia a que existe com o `Erase` de cada entidade, como o original, e copia os atributos que casam com o layer `0`, visíveis e com o texto vazio) e a contar as posições **do formato** em vez do prefixo dos nomes. O `CriarBloco` de cada página continua usando essas definições recém-garantidas.
- **Fora, com o motivo:** o `attsync` que o original dispara **por referência** (é comando do CAD; os blocos novos do recoder já nascem da definição atualizada — as referências **antigas** das outras páginas não são ressincronizadas, o que só apareceria num desenho que já tinha os blocos com o formato velho); e, no `Nome`, o ramo do original para um layer que não é capa nem `-1` cria um registro **sem nome**, que o recoder não reproduz.

**Verificação:** a regra pura tem **5** testes (`DefinicoesDeRevisaoTests`: o nome pela capa/`-1`, as 48 tags protegidas, as três condições do `Copiar`, a contagem por layer com o `REV` solto fora e as tags numeradas). `plugin:test` **817** (a suíte pelo console runner do xunit no `%TEMP%`, `pm170`: `Total: 817, Errors: 0, Failed: 0`), as duas builds **0 avisos**. **Não medido no CAD:** a janela do `REVCOMP` é modal e num script não há quem clique — a criação das definições fica coberta pelos testes da regra e pelo caminho do adapter (que só roda no desenho real).

**Rodada 167 — Revisão Completa: o posicionamento dos blocos (`AtualizaRevCompleta`).**
O que a rodada 166 deixou **aberto**: o plugin só regravava os blocos de revisão **que já existiam**,
sem reposicionar nada. Agora entra a regra pura `PosicionamentoDeRevisoes`, que porta o laço do
`AtualizaRevCompleta` do reverso (sobre o `capturaRevisoesCompletas`) com as três decisões: (1)
**sem alteração** e já com posição → atualiza o bloco da posição (o `LK3p1o8pTVH` + o
`JdCp1GqFmnk`); (2) **revisão alterada** e cabe → a revisão nova entra na `Posicao + 1`; (3)
**alterada no topo** (`Posicao >= maxCapa/maxCorpo`) → o ramo de **estouro**: apaga todos os blocos
da página, desce um cada posição > 1 (recriando com os dados antigos) e cria a nova — a mais antiga
sai, como no original. A comparação com a `RevisaoOriginal` é **sem caixa** (o
`Operators.CompareString(..., TextCompare: true)`) e a página sem revisão é pulada.

- A regra é pura (`PosicionamentoDeRevisoes.Calcular`); o `ContarPosicoes`/`EhTagDeRevisao` portam o
  `carregaConfiguracaoRevisao` (só as tags `REV`/`REV0..7` contam, por layer).
- O adapter `RevisoesDoDesenho.GravarCompletas` virou **plan-driven**: lê todos os blocos de revisão
  agrupados por página, casa cada página editada com o bloco de **maior posição** (a
  `RevisaoOriginal` e a `Posicao` vêm do desenho, não da tela), mede as posições pelos blocos
  `Revisao_Capa{n}`/`Revisao_Corpo{n}` que o `verificaCriaBlocoRevisao` deixou e aplica o plano:
  `Atualizar` (XData + atributos no lugar), `Apagar` (o `Erase`) e `Criar` (o `JdCp1GqFmnk`:
  `new BlockReference(Point3d.Origin, definição)` no layer da página, um `AttributeReference` por
  definição via `SetAttributeFromBlock`, e o XData `DiagLog/Revisao`). O resultado é contado
  (`Paginas`/`Atualizados`/`Criados`/`Apagados`/`Deslocados`/`SemDefinicao`/`SemFormato`) e o
  comando relata na linha de comando.
- **Duas coisas ficaram de fora, com o motivo:** (1) o recoder **não** cria as definições
  `Revisao_Capa{n}`/`Revisao_Corpo{n}` a partir do bloco de formato (o `verificaCriaBlocoRevisao`) —
  quando a definição não existe o bloco é **pulado** e entra na conta `SemDefinicao` (não se apaga
  nada por isso); (2) sem nenhuma definição de posição, `posicoes` cai para `maiorPosicao + 1`
  (`SemFormato`), para nunca disparar o deslocamento por engano num desenho sem formato — o
  `maxCapa/maxCorpo` real do formato fica **aberto**.

**Verificação:** a regra pura tem **8** testes (`PosicionamentoDeRevisoesTests`: os três ramos, a
primeira revisão, o estouro com o deslocamento e a queda da mais antiga, a comparação sem caixa, a
página vazia e a contagem de posições). `plugin:test` **812**, 0 falhas; as duas builds **0 avisos**.
No **AutoCAD 2020** (`cad-autocad-smoke.ps1 -Desenho ..\Elet\RCD\Funcional.dwg -Dwg 63 -Revisao R0
-Comandos REVCOMP`) o comando abre e carrega as **16 páginas** do caderno. **Não medido:** o clique do
**Editar** (a janela é modal e num script não há quem clique) — o posicionamento em si fica coberto
pelos testes da regra; o desenho real também não foi conferido bloco a bloco.

**Rodada 166 — gravação da Revisão Completa: tags de atributo.** O `JdCp1GqFmnk` do original grava nos atributos as tags `REV0..REV7`, `DESC0..DESC7`, `DATA0..7`, `ELAB0..7`, `VERIF0..7` e `APROV0..7`; o plugin só reconhecia `REV`, `DESC`... (e aliases `REVISAO`, `DESCRICAO`, que o original não tem), então com os blocos reais não gravava nenhum atributo. Corrigido com `RevisaoCompletaXData.CampoDoAtributo` (família + dígito 0-7, sem o `REV` solto), usado no `GravarCompletas`; teste `Atributo_de_revisao_usa_a_familia_com_digito_de_0_a_7`. **Não portado (divergência grande, só verificável no CAD):** o `JdCp1GqFmnk`/laço do `capturaRevisoesCompletas` do original desloca as revisões entre posições (`Posicao--`), cria blocos `Revisao_Capa{n}`/`Revisao_Corpo{n}` com `Conf.maxCapa`/`maxCorpo` e apaga os que sobram (`LK3p1o8pTVH`). O plugin só regrava os blocos que já existem e não desloca nada. `plugin:test` **804**, 0 falhas, exit 0; builds 0 avisos.

**Rodada 165 — revisão de Revisão Completa e Simplificada contra o `Revisao.cs` do reverso.** Leitura: (1) a simplificada usava a revisão do **projeto** como fallback para página sem campo REV — o original deixa **vazia** (`mRevSimplificada[1,i] = ""`); corrigido. (2) Com vários textos REV na mesma página, o original fica com o **último** lido (sobrescreve no laço); o plugin ficava com o primeiro; corrigido. (3) A completa aceitava um bloco de posição 0; o `capturaRevisoesCompletas` exige posição **estritamente maior** que a guardada (começa em 0) e também começa vazia; corrigido com `OperacoesDeRevisao.AceitaRevisaoCompleta` e teste. **Não verificado:** a **gravação** da completa (`gravarXDataRevisao` e o laço de atributos do `Revisao.cs` linha ~600–680, que apaga e recria atributos) não foi comparada linha a linha — o plugin só atualiza atributos existentes. A tela no CAD não foi aberta. `plugin:test` **803**, 0 falhas, exit 0.

**Rodada 164 — Páginas: inserir e excluir conferidos contra o reverso.** Achado: o `NovaPaginaEntre.Calcular` devolve `PgNum 0` em alguns casos (ex.: entre `1A` e `1B` dá `0B`); o original (`criarUmaNovaPagina`, `TBNp1Uume8n`) **não cria nada** quando `PgNum == 0` (mensagem 31/32), mas o plugin passava o nome para o `CriacaoDePagina.Normalizar`, que tirava o zero e criava o layer **`B`**. Correção: `NovaPaginaEntre.Cabe` (`PgNum != 0`), usada no `InserirPagina` (grade) e no `NOVAPAGINA` antes de criar. Teste `Quando_nao_cabe_o_PgNum_zero_e_recusado`. Conferido ramo a ramo: `Calcular` bate com o `calculaNovaPagina` nos quatro ramos (numérico × alfanumérico). **Divergências registradas, não corrigidas:** (1) o `NOVAPAGINA` calcula sempre depois da **última** página, enquanto o `criarUmaNovaPagina` do original insere depois da **ativa** (com `BuscaProximaPaginaValida`); (2) o `APAGAPAGINA` apaga o **layer** junto, como o botão "Excluir Páginas" do original (que chama `Pagina.RemoveLayer`). **Corrigido na mesma rodada:** a exclusão não recusava a **capa** (`checaCapa`, mensagem 17 do original) — `ExclusaoDePagina.Recusa` agora recusa a capa (`PaginaAtiva.ChecaCapa`), com teste `A_capa_nao_se_apaga`. `plugin:test` **802** (+2 nesta rodada), 0 falhas, exit 0.

**Rodada 163 — Lista de Plaquetas no app.**
Novo relatório `plaquetas` (`services/sidecar/src/sidecar/relatorios/plaquetas.py`), com a consulta do
`cDadosAccessPlaquetas.CarregaPlaquetas`: `Plaquetas4` filtrada pelo painel e ordenada por `Indice`. As
colunas são as do original (`INDICE`, `Dispositivo`, `Descrição 1..3`, `Modelo`). `TIPO` e `HANDLE`
vêm do desenho e não existem no banco, então não entram. O original também não filtra por revisão nem
por DWG, e o relatório segue assim.

Verificação: `test_db.py` cobre a grade do painel (com `Desc2`/`Desc3` nulos vazios), o painel vazio, o
parâmetro obrigatório e o catálogo com cinco relatórios. `npm run test:sidecar` exit 0 (41 testes) e
`ruff check` exit 0.

**Rodada 162 — testes das chaves da Configuração Geral.**
`ConfiguracaoPositronTests` ganha dois testes: `Padrao_da_tela_geral_segue_as_capturas_do_original`
(os valores padrão da tela) e `As_chaves_da_tela_geral_sobrevivem_ao_round_trip` (as 19 chaves com
valores não padrão, gravadas com `Texto()` e lidas de volta com `Ler`). Suíte do plugin pelo xunit
console no `%TEMP%` (`pm161`): **800 total, 0 errors, 0 failed**. Com isso a persistência das chaves da
tela tem teste próprio; o pipeline continua sem lê-las.

**Rodada 161 — Configuração Geral (`ELETCFG`) em três abas, com as predefinições.**
A tela `FormularioConfiguracao` passa a seguir as capturas do original: abas **Banco de Dados**
(idioma, contatos auxiliares, nome do caderno, tipo de banco, banco do projeto, e DWG/revisão/log),
**Bibliotecas** (quatro simbologias, cada uma com botão de pasta) e **Geral** (os botões **Configurar
Padrão**, o cruzamento de páginas — o `IncluirColuna` 0..6 na ordem da tela —, caracteres, alturas,
representação cabo/veia, cores, prefixos/sufixos e visualização de relés). Os valores das três
predefinições saem do `frmConfiguracaoGeral.cs` decompilado (os handlers `t86y5UlFWX`, `QD0y0V9eIp` e
`zYIyRqNngg`): só preenchem os campos da tela, e o arquivo só é gravado no **Salvar**, como no original.

**19 chaves novas** no `positron.ini` (`ConfiguracaoPositron`), sem variável de ambiente, lidas pelo
mesmo `Aplicar`: `idioma`, `contatosAuxiliares`, `tipoBanco`, quatro `simbologia*`,
`representacaoCaboVeia`, `terminalIndefinido`, `separadorCarimbo`, `alturaCircuitos`,
`alturaReferenciaCruzada`, `corFiacaoConexao`, `corFiacaoTextoCircuito`, os quatro
`prefixo/sufixoCruzFuncFunc` e `...LogFunc`, e `visualizacaoModelosRele`. **Gravadas, mas o pipeline
ainda não as lê** — só as chaves que já existiam mudam comportamento.

**Verificação:** `dotnet build` do `Positron.Plugin` com 0 avisos e 0 erros. A suíte foi rodada pelo
xunit console 2.9.2 (`.tmp-smoke/xunit`) **a partir de `%TEMP%`**, porque na pasta do repo no Desktop o
runner dá `Acesso negado` (o caso descrito no troubleshooting): `Total: 798, Errors: 0, Failed: 0`.
A tela e os cliques das predefinições **não** foram exercitados (modal, precisa do CAD).

**Rodada 160 — o plugin não se desmontava: o `Terminate()` vazio e o pacote de autoload.**
O dono apontou que ao **fechar o AutoCAD/ZWCAD** o plugin não é desmontado e a **barra continua montada** — "para teste isso não é legal", e que por ora bastava o que ele pediu: **remover a barra** e **montar só depois do `NETLOAD`** (em produção pode ficar como está). A investigação achou **quatro** coisas, e três delas eram medíveis:

1. **`Plugin.Terminate()` estava vazio** desde o começo — o CAD *avisava* o plugin do descarregamento e não havia nada removendo a aba. É a causa direta.
2. **No AutoCAD a retentativa agendada nunca era cancelada:** quando o ribbon ainda não existe no `Initialize()`, a montagem é agendada para a primeira ociosidade (`Application.Idle`); o handler **continuava pendurado** e podia **recriar** a aba **depois** do unload. A remoção sem cancelar a retentativa não duraria.
3. **O CAD não avisa no fechamento** — medido na interface cheia do AutoCAD 2020: fechando por `QUIT` (e pelo `Quit()` do COM) o `POSITRON_LOG` termina **sem** linha nenhuma de `Terminate`, enquanto o **`accoreconsole`, ao sair, chama** (a linha do desmonte aparece no harness). Ou seja: no fechamento normal não existe callback nosso para rodar — a aba morre com o processo. E ela **não volta** na sessão seguinte: a montagem do `NETLOAD` não trouxe a nota de sobra (abaixo), isto é, o ribbon **não** tinha aba do Positron antes da carga.
4. **O que o fluxo de teste sentia era o pacote de autoload**, não o desmonte: com o `.bundle` em `%APPDATA%\Autodesk\ApplicationPlugins` (o caminho de **produção**) a DLL é carregada **sem `NETLOAD`**, então a barra aparece sozinha ao abrir o CAD — e, se o pacote estiver velho, aparece a barra **velha** (o defeito da rodada 150). Medido: **com** o pacote o CAD escreve o log e monta a aba na primeira ociosidade sem `NETLOAD`; **sem** o pacote o CAD abre **sem `POSITRON_LOG` nenhum**.

O que entrou no código (o par do `Criar()`):

- `BarraDeFerramentas.Remover()` — cancela a retentativa pendente (`CancelarRetentativa`) e **tira do ribbon toda aba** com o id do Positron, devolvendo a conta de abas e de painéis removidos; `Plugin.Terminate()` passa a chamá-lo (e **nunca lança**: um erro ao fechar o CAD não pode virar diálogo — vai para o log).
- `ConstruirAba()` deixou de **engolir** a sobra: uma aba do Positron que ainda esteja no ribbon (build anterior no ar) sai antes da nova e o log **denuncia** em vez de ficar com duas — `[substituiu N aba(s) do Positron que já estavam no ribbon, com M painel(is) — build anterior no ar?]`.
- O contador da retentativa (`_tentativas`) é **zerado** quando a retentativa termina: ele ficava sujo e uma segunda chamada não reagendaria nada.

O que foi feito **no ambiente** para o fluxo de teste (o pedido literal): o pacote de autoload foi **removido** desta máquina (`instala-bundle.ps1 -Cad AutoCAD -Remover`) — a barra passa a existir **só depois do `NETLOAD`**. Para voltar ao caminho de produção (barra automática ao abrir), `instala-bundle.ps1 -Cad AutoCAD`.

```text
# 1) SEM autoload (pacote removido): o CAD abre sem plugin nenhum
$env:POSITRON_LOG = "$env:TEMP\positron-sem-autoload.txt"
# abre a interface cheia (acad.exe /nologo /i <copia>), espera ~35 s e confere:
POSITRON_LOG existe? False

# 2) NETLOAD da DLL do bin (copia local, por LISP) — a barra monta depois do load
(setvar "FILEDIA" 0)
(vl-cmdf "_.NETLOAD" "C:/positron-smoke/gui/Positron.Plugin.AutoCAD.dll")

Positron carregado. Digite ELET para começar — ELET abre a paleta de folhas (FOLHAS também).
Positron: DLL de 2026-10-14 21:33 — C:\positron-smoke\gui\Positron.Plugin.AutoCAD.dll
Barra: aba "Positron" com 9 painel(is) — 121 botão(ões), 5 menu(s) com 39 item(ns), 1 liga/desliga, 1 lista e 1 campo; 34 linha(s), 86 quebra(s), 7 área(s) recolhível(is), 9 separador(es). Acionáveis: 123 ligado(s) (3 no comando do recoder), 38 desativado(s); tema escuro.
pzBarra: 1 aba(s) POSITRON.ID_Positron ("Positron"), 9 painel(is) [Configuração | Caderno | ...]; RibbonButton=120, RibbonCombo=1, RibbonMenuButton=5, RibbonMenuItem=39, RibbonPanelBreak=7, RibbonRowBreak=86, RibbonRowPanel=34, RibbonSeparator=9, RibbonTextBox=1, RibbonToggleButton=1; 1 botão(ões) de canto; 40 item(ns) desativado(s).

# 3) a prova de que o descarregamento agora age: no accoreconsole (headless), ao sair
Barra: o CAD não tem ribbon nesta sessão — nada a desmontar.
```

**Duas coisas ficaram de fora, com o motivo:** a **paleta de folhas** (`PaletteSet`) não é fechada no desmonte — o pedido era a barra, e a decisão de fechar a paleta (que é do CAD e pode ser restaurada pela sessão) fica com o dono; e o **ZWCAD não foi medido** nesta rodada (o código é o mesmo, mas o `Terminate()`/autoload de lá não foi observado) — a ausência dele foi **medida** em 2026-10-16 (registro + pastas + `where`; → *Existe CAD nesta máquina?*), com a ressalva de que a rodada 211, do mesmo dia, mediu nele: medir de novo antes de afirmar.

**Como refazer a medição:** `.tmp-smoke/gui-netload2.ps1` (interface cheia + `NETLOAD` por LISP + `pzBarra` + `QUIT`), com o pacote removido. As duas builds **0 avisos** e `plugin:test` **798** (inalterado — a mudança é do `Positron.Plugin`, que a suíte do `Positron.Data` não cobre).

**Rodada 159 — frente 12 (parte 9): as duas telas de relatório que já tinham a regra pronta — `frmRelatorio_Veias` (`LVEI`) e `frmRelatorio_Materiais` (`EXPLM`).**
Os relatórios são a frente que o `PLANO.md` deixava como **decisão do dono** (§7.3) e o app já entregava **quatro tabulares** desde as rodadas 65–68 — dois deles (`veias` e `materiais`) reproduzindo as telas `frmRelatorio_Veias` e `frmRelatorio_Materiais`, com a regra medida no banco do projeto real. O que faltava **no CAD** era a tela: as duas cascas abriam pelo comando e ficavam vazias. Esta rodada liga as duas **sem reescrever a regra** — o `ListaDeVeias`/`ListaDeMateriaisDoRelatorio` são a mesma montagem que o app já media, agora em `Positron.Data` (é a regra de ouro do §7.7: nenhum código de tela antes da regra portada e testada).

- `Positron.Data/Relatorios/ListaDeVeias.cs` — a **Lista de Veias** (o `CDadosAccessInterligacao.CarregaVeias4`), com as quinze colunas do `formataDGCabos`: (1) os cabos da revisão com o painel escolhido em `Pn1`/`Pn2`, por `Tag`, cada um **uma vez** (o `lCabosUnico`); (2) a ponta do painel escolhido vira a **ponta 1** e as marcas de `Aterrar` continuam presas aos `Pn1`/`Pn2` **originais** (`1` = fim do `Pn1`, `2` = fim do `Pn2`, `3` = os dois); (3) as veias do `Veias4` da mesma revisão, pulando `Num_Veia <= -51`, com o rótulo do `Nome_Veia` e, quando vazio, o número; (4) as pontas do `Interligacao4` casadas **por painel** — a ponta que não casa fica **vazia** —, com o `Terminal` vazio ou `"0"` saindo como o caracter indefinido (`?`) e o `NRegua` do lado **mandando** sobre a tag na coluna de dispositivo; (5) o `Documento Funcional` como a lista ordenada e sem repetição das duas pontas; (6) a `Página` como `Pagina1, Pagina2` quando diferem; (7) as veias de **reserva** (índice negativo) caindo no trecho da veia **seguinte**, como no original.
- **O `qTotal` da tela** é o `lCabosUnico.Count` — os cabos com veia, **não** as linhas da grade: o cabo cujas veias não acham trecho no `Interligacao4` entra na conta e não aparece na lista. É um quirk do original e ficou fixado em teste; no painel 503 do projeto real são **42 cabos e 22 linhas** (`ListaDeVeias.CabosDoRelatorio`).
- `Positron.Data/Relatorios/ListaDeMateriaisDoRelatorio.cs` — a **Lista de Materiais** pelo caminho de **um painel** da tela (o `CarregaDadosOrdemDispositivos` + o `CarregaGDDisp`): o agrupamento é por **trechos consecutivos do mesmo material** (material fora do catálogo ou `0` sempre começa linha nova), as tags do trecho unidas por `", "` e as quantidades **somadas**; a descrição sai do catálogo **com um espaço** no fim (o `DescCompleta + " "` do original, quirk mantido). O `CarregarOrdem` enche a `dgOrdem` com a ordem do **diagrama** (a `Ordem` que o `COMPLM` renumera 1..N por painel).
- `ProjectStore.LerRevisoesDeCabos4` — a coluna `dgRevisao`: as revisões do **snapshot dos cabos** (`DISTINCT Revisao, Criador, Data FROM Cabos4 ORDER BY Data`), com a mais nova em cima (o laço do original acrescenta de trás para a frente). É outro recorte do `LerRevisoes` (que vem dos três pipelines do diagrama).
- As telas: `LigacaoDeRelatorio` (a base fina das duas), `LigacaoDoFrmRelatorioVeias` e `LigacaoDoFrmRelatorioMateriais` — uma **arquivo por tela** + **uma linha** no `LigacoesDasTelas`, subindo para **14 de 127** telas com regra. A LVEI monta as colunas do `formataDGCabos` (a do `COMPRIMENTO` só com o `CBComprimento` ligado, como lá), a faixa `AntiqueWhite` alternando **por cabo** (o `flag` do `bqipPxovkmF`) e, com mais de um painel escolhido, a linha de cabeçalho `LightBlue` com o nome do painel na **terceira** coluna (o `iPainelSel` do `bSepara`); a EXPLM tem as três grades (`dgEquipamentos`/`dgOrdem`/`dgListaMateriais`), os textos do construtor do original e o recarregamento da `dgOrdem` na troca de painel.
- **O que entra desabilitado, com o motivo na dica:** as exportações (`btExportaEXCEL`/`btExportaDWG` — a planilha e a montagem do bloco são da pilha de exportação, que sai pelo app), o `BTY`/`btLayout`/`btSalvaOrdem`/`btDesagrupar`/`btCima`/`btBaixo`/`btPrimeiro`/`btUltimo` (a **ordenação manual** das linhas e a gravação da ordem ainda não estão portadas), o `ckMultPNDetalhado` (o modo multi-painel, o `CarregaDadosDispositivosMultiplosPN`), a mesclagem de modelo/fabricante na descrição, o `tbMultiplicador`, o `CKAgrupar` (a montagem agrupada do `bSepara`) e o `RBFuncaoVeia` (o `CarregaFuncoesDaVeias4`).
- **Duas coisas deliberadas, registradas:** (1) a tela **carrega na abertura** e não só no `btPesquisar` — no original a grade abre vazia até o clique e num script não há quem clique, então o harness não teria como medir; (2) no original onde há `MsgBox` o recoder **escreve na linha de comando**.
- **Para medir num script:** `POSITRON_REL_PAINEL` escolhe o painel (as duas telas) e `POSITRON_REL_REVISAO` a revisão (a LVEI); sem elas a tela abre no primeiro item de cada coluna, como o original abre com a primeira linha selecionada.
- **Achado de ferramenta:** duas telas de relatório no **mesmo** `.scr` não funcionam — o `accoreconsole` roda a primeira e a **segunda não escreve nada** (a janela modal come as linhas seguintes do script; o `.scr` gerado está correto — uma linha `LVEI` e, na seguinte, `EXPLM`). Cada tela medida em uma passada própria.
- **A conferência valor a valor** (o que a rodada passou a usar): um dumper em C# sobre o `Positron.Data` (`ListaDeVeias.Montar` + `ListaDeMateriaisDoRelatorio.Montar`, 15 e 8 colunas) contra o **lado independente** em Python — o relatório `veias` do **app** (o módulo do sidecar, que nunca passa por C#) e uma reconstrução do agrupamento do EXPLM direto do `ListaMateriais` + `Materiais`. **Resultado: 0 diferença nas 72 linhas** (22 da LVEI + 34 do EXPLM, com as NBSP e o travessão do descritivo do catálogo incluídos).
- **A única diferença que o cruzamento achou, e que era do app:** a coluna `Comprimento` da LVEI saía `0.0` no relatório do app e `0` na regra do CAD. O original usa `clsTextos.TiraNothing(Conversions.ToString(dComprimento))` (`frmRelatorio_Veias.cs:905`) — o `Conversions.ToString` de um `Double` **não escreve as casas quando o número é inteiro** —, então o `0` é o fiel e o `0.0` era o `str(float)` do Python. Entrou o `relatorios/base.py:numero()` (o `Conversions.ToString` do `Double`) e a `veias.py` passou a usá-lo; a variável `numero` do laço virou `numero_da_veia` para não sombrear a função. Fica registrado que o app **mostrava** `0.0` desde a rodada 65.
- **A regra que fica de fora, com o motivo:** o `OrdenaAVeia` do original reordena as veias de índice **negativo** com heurísticas sobre o nome (`"P"`/`"T"`) — aqui as veias saem por `Num_Veia`, como no relatório do app (muda a ordem relativa das veias de reserva, não o conteúdo das linhas).

```text
# AutoCAD 2020 (accoreconsole), banco do projeto real (.tmp-smoke/r159.db: 697 cabos4,
# 2388 veias4, 20 interligacao4, 104 ListaMateriais, 210 materiais), DWG 63, revisao R0
POSITRON_REL_PAINEL=503 POSITRON_REL_REVISAO=R0 powershell -ExecutionPolicy Bypass -File scripts/cad-autocad-smoke.ps1 -Banco <raiz>\.tmp-smoke\r159.db -Dwg 63 -Comandos "LVEI"

LVEI: 22 linha(s) na Lista de Veias da revisão "R0" (42 cabo(s) distinto(s); painel(is) 503 de 697 cabo(s) e 2388 veia(s) na revisão; 480 painel(is) no cadastro).

# mesma receita, -Comandos "EXPLM" (uma tela por passada: ver o achado de ferramenta acima)
EXPLM: painel 503 — 91 item(ns) na ordem do diagrama.
EXPLM: 34 linha(s) na Lista de Materiais do painel 503 (91 item(ns) na ordem do diagrama; 34 material(is) distinto(s)).
EXPLM: 104 item(ns) na ListaMateriais do DWG 63; 210 material(is) no catálogo; 480 painel(is) no cadastro.

# o cruzamento independente (dumper em C# contra o app + a reconstrução do EXPLM)
C# linhas: 72 | ref linhas: 72
linhas diferentes: 0

# o app e o CAD antes da correção do Comprimento (a linha da LVEI, coluna 15)
col 15: C#='0'  ref='0.0'
```

`plugin:test` **798** (+20: `ListaDeVeiasTests` 13, `ListaDeMateriaisDoRelatorioTests` 7), o sidecar **39** (`uv run --directory services/sidecar pytest`) e as duas builds **0 avisos**.

**Rodada 158 — as 15 variantes das telas (`DICHESF`, `DIFURNAS`... — `frmRelatorio_DInterlig`/`_DICemig`/`frmTrocaPaineis`) e os 15 comandos gerados.**
O item 6 da fila do `PLANO.md`: a conferência visual da rodada 153 havia identificado que 15 janelas do reverso eram instanciadas com argumentos no construtor que alteravam o formulário base (`new frmRelatorio_DInterlig(1..11)`, `new frmRelatorio_DICemig(1..3)` e `new frmTrocaPaineis(bAbre: false)`). Essas variantes não eram geradas como comandos para não abrir a casca padrão sem fidelidade.
- Mapa completo `VariantesDoReverso.cs` (`Positron.Data/Interface/Mapas/VariantesDoReverso.cs`) estruturando as 15 variantes com dados puros:
  - 11 variantes de `frmRelatorio_DInterlig`: `DICHESF` (1), `DICPFL` (2), `DICTEEP` (3), `DIEQUAT` (4), `DICPFLTR` (5), `DIEDP` (6), `DITAESA` (7), `DIFURNAS` (8), `DICEMIGGTP` (9), `DIENELSP` (10), `DIITAIPU` (11);
  - 3 variantes de `frmRelatorio_DICemig`: `DICEMIGGTE` (1), `DICEMIGDP` (2), `DICEMIGDE` (3);
  - 1 variante de `frmTrocaPaineis`: `TROCAPN` (`new frmTrocaPaineis(bAbre: false)`);
  - Método puro `Aplicar(Tela baseTela)` que devolve uma nova instância de `Tela` adaptando o título da concessionária/tipo, visibilidade de grupos (`GroupBoxTipoCruz`, `GroupBoxPaineisCima`, `GroupBox1`, `rb2`, `tbReserva`), controles desabilitados/habilitados (`btMirrorJumper`, `btCima`, `btRebateCabos`, `rbC`, `rb4`, `btTrocaosPaineis`) e sobreposição de posições (ex.: `GroupBoxPaineisCima` reposicionado para `12, 459`);
- Extrator `scripts/extrair-comandos-do-reverso.ps1` atualizado para incluir variantes em `Comando.Ligavel` e gerar os métodos em `ComandosDoOriginal.Gerado.cs`;
- Comandos gerados subiram de 99 para **114**; comandos do reverso sem nada no plugin caíram de 68 para **51** (apenas 1 abrindo janela: `IMPBD`; 50 de regra pura);
- Telas alcançadas no CAD subiram de 104 para **107** (+3: `frmRelatorio_DInterlig`, `frmRelatorio_DICemig`, `frmTrocaPaineis`);
- `BarraDoReverso.Dados.cs` atualizado: acionáveis cobertos na barra subiram de 108 para **123** (+15), e os que abrem janela de 101 para **116** (+15); itens de janela sem comando na barra caíram de 16 para apenas **1** (`IMPBD`);
- `RenderizadorDeTelas.cs` e `JanelasDoOriginal.cs` ajustados para buscar a variante pelo nome do comando ou rótulo e aplicar as alterações antes da montagem da janela modeless;
- Testes unitários novos em `VariantesDoReversoTests.cs` (+15 asserções) e contagens atualizadas em `ComandosDoReversoTests.cs` e `BarraDoReversoTests.cs`.

```text
# ZWCAD 2026, banco novo
powershell -ExecutionPolicy Bypass -File scripts/cad-zwcad-smoke.ps1 -Comandos "JANELAS,DICHESF,DICEMIGDE,TROCAPN"

Recursos: 4 template(s) DWG garantido(s) (MascaraM, ErroFiacao, V_B_BORNECPFL, Revisao).
Barra: aba "Positron" com 9 painel(is) — 121 botão(ões), 5 menu(s) com 39 item(ns), 1 liga/desliga, 1 lista e 1 campo; 34 linha(s), 86 quebra(s), 7 área(s) recolhível(is), 9 separador(es). Acionáveis: 123 ligado(s) (3 no comando do recoder), 38 desativado(s); tema escuro.
JANELAS: seletor aberto com 127 tela(s) do reverso.
DICHESF: "Diagrama de Interligação CHESF" (frmRelatorio_DInterlig) aberta no CAD — 54 controle(s).
DICEMIGDE: "Diagrama de Interligação CEMIG-D EQUIP" (frmRelatorio_DICemig) aberta no CAD — 44 controle(s).
TROCAPN: "Trocar Painel" (frmTrocaPaineis) aberta no CAD — 13 controle(s).
```

`plugin:test` **778** (+22), as duas builds **0 avisos**.

**Rodada 157 — §7.8 fatia 6: o splash (`frmSplash`, `ONSPL`/`OFFSPL`) e os recursos DWG (`MascaraM.dwg`, `ErroFiacao.dwg`, `V_B_BORNECPFL.dwg`, `Revisao.dwg`).**
O item 5 da fila do `PLANO.md` e a fatia 6 do shell (§7.8): no original, o splash (`frmSplash`) é a tela de boas-vindas acionada via LISP (`ONSPL`/`OFFSPL`), exibindo a marca com recorte de transparência azul (`SplashEL26`). Além disso, o produto depende de 4 templates/blocos DWG embutidos em `Eletron4.Resources.resx`: `MascaraM.dwg` (formato/máscara de página), `ErroFiacao.dwg` (marcador visual de erro de fiação), `V_B_BORNECPFL.dwg` (bloco de régua/borne CPFL) e `Revisao.dwg` (tabela/bloco de revisão).
- Extração de recursos via script Python (`scripts/extrair-recursos-dwg.py`) decodificando os dados Base64 do `.resx` do reverso para `cad-plugin/lib/Recursos/*.dwg`, embutidos como recursos incorporados em `Positron.Data.csproj` sob o namespace lógico `Positron.Recursos.*`;
- A classe de regra pura `RecursosDoProduto` (`cad-plugin/Positron.Data/Recursos/RecursosDoProduto.cs`):
  - Valida o cabeçalho mágico DWG (`AC10xx`) e identifica a versão CAD correspondente (`AC1024` = AutoCAD 2010, `AC1021` = AutoCAD 2007);
  - Define caminhos padrão em `%APPDATA%\Positron\Recursos\` e retrocompatibilidade com `%APPDATA%\Cadgraph\Eletron4\`;
  - Garante a extração em disco de forma idempotente (`GarantirEmDisco`, `GarantirTodosOsRecursos`);
- A ligação de interface `LigacaoDoFrmSplash` (`cad-plugin/Positron.Plugin/Interface/Telas/LigacaoDoFrmSplash.cs`):
  - Aplica o fundo `SplashEL26`, chave de transparência `Color.Blue`, centralização na tela e borda nenhuma;
  - Fecha o splash ao clique ou nas teclas ESC/Enter;
  - Rastreia instância ativa para controle programático via `OFFSPL`;
- Comandos CAD `ONSPL` e `OFFSPL` adicionados em `Comandos.cs`;
- Inicialização do plugin (`Plugin.Initialize`) agora chama `RecursosDoProduto.GarantirTodosOsRecursos()` ao carregar, garantindo a presença dos templates em disco para qualquer comando subsequente;
- Telas ligadas à regra aumentadas de **11** para **12 de 127** (`pzTelas`).

```text
# ZWCAD 2026, Funcional.dwg (DWG 63), banco r154.db
powershell -ExecutionPolicy Bypass -File scripts/cad-zwcad-smoke.ps1 -Comandos "pzTelas,ONSPL,OFFSPL"

Recursos: 4 template(s) DWG garantido(s) (MascaraM, ErroFiacao, V_B_BORNECPFL, Revisao).
JANELAS: 127 de 127 tela(s) do reverso montada(s), nenhuma falha. Ligacoes: 12 de 127 tela(s) com regra (frmPesquisaXdatas, frmEstatisticaDeBornes, frmCompilarFiacao, frmCompilarInterligacao, frmCompilarJumperExt, frmGerenciadorMateriais, frmGerenciadorMatIndep, frmGerenciadorMascaras, frmGerenciadorContatos, frmEditaRevisaoSimplificada, frmEditaRevisaoCompleta, frmSplash).
ONSPL: "frmSplash" (frmSplash) aberta no CAD — 0 controle(s).
OFFSPL: splash fechada.
```

`plugin:test` **756** (+10, `RecursosDoProdutoTests`), as duas builds **0 avisos**. E2E `-Idempotencia` com baseline `VERIF 249` verificado.

**Rodada 156 — frente 12 (parte 8): as telas de revisões — `REVSIMP` e `REVCOMP` ligadas ao desenho e ao menu das folhas.**
O item 4 da fila do `PLANO.md`: o submenu `Editar Revisões` da paleta de folhas (`FolhasControle.cs`) estava desabilitado com a suposição de que as revisões ficavam apenas no banco. A descompilação do original (`frmEditaRevisaoSimplificada.cs`, `frmEditaRevisaoCompleta.cs` e `Revisao.cs`) mostrou que ambas as telas leem e regravam as revisões **no desenho CAD** por página/layer:
- a regra pura e modelos em `Positron.Data/Paginas/RevisoesDaPagina.cs` cobrem `RevisaoSimplificadaDaPagina`, `RevisaoCompletaDaPagina`, a substituição textual de campos (`OperacoesDeRevisao.Substituir`, com `DE`/`PARA`) e o mapeamento dos 15 campos da XData de revisão (`RevisaoCompletaXData`), espelhando a estrutura do original;
- o adapter `RevisoesDoDesenho` (`cad-plugin/Positron.Plugin/Paginas/RevisoesDoDesenho.cs`) implementa a leitura e gravação no ModelSpace:
  - simplificada: varre os textos `DBText` com XData `TituloPagina` no índice 8 ("REV") por layer de página, com fallback nas revisões do projeto (`ProjectStore.LerRevisoes`);
  - completa: varre blocos `BlockReference` com XData `Revisao` (ou atributos `REV`/`DESC`/`DATA`/`ELAB`/`VERIF`/`APROV`) na camada da página;
- `frmEditaRevisaoSimplificada` (`REVSIMP`): preenche a grade com as páginas do projeto, coluna 0 (Página) somente leitura, coluna 1 (Revisão) editável; menu de contexto com `Copiar`, `Colar`, `Limpar` e `Editar` (grava as revisões simplificadas de volta nas entidades `DBText` do desenho CAD);
- `frmEditaRevisaoCompleta` (`REVCOMP`): preenche a grade com 7 colunas (Página, Revisão, Descrição, Data, Elaborador, Verificador, Aprovador); menu de contexto com `Copiar`, `Colar`, `Limpar`, `Substituir` (campos `DE`/`PARA` para substituição em lote) e `Editar` (grava as revisões completas nos blocos e XData do desenho);
- `FolhasControle.cs`: o item `Editar Revisões` do menu de contexto foi habilitado com seus subitens `Simplificada` e `Completa` abrindo as telas correspondentes;
- comandos diretos `REVSIMP` e `REVCOMP` adicionados em `Comandos.cs`;
- as duas telas registradas em `LigacoesDasTelas`, subindo o total de telas ligadas à regra de **9** para **11 de 127**.

```text
# ZWCAD 2026, Funcional.dwg (DWG 63), banco r154.db
powershell -ExecutionPolicy Bypass -File scripts/cad-zwcad-smoke.ps1 -Dwg 63 -Revisao R0 \
  -Comandos "ELET,REVSIMP,REVCOMP,JANELAS" -Desenho "cad-plugin/reverso/Teste_projeto_real/Funcional.dwg" -Banco "<repo>\.tmp-smoke\r154.db"

Positron — paleta de folhas com 16 página(s) (ancorada no CAD).
REVSIMP: 16 página(s) carregada(s) na grade.
REVSIMP: "Editar Revisão Simplificada" (frmEditaRevisaoSimplificada) aberta no CAD — 9 controle(s).
REVCOMP: 16 página(s) carregada(s) na grade.
REVCOMP: "Editar Revisão Completa" (frmEditaRevisaoCompleta) aberta no CAD — 18 controle(s).
JANELAS: 127 de 127 tela(s) do reverso montada(s), nenhuma falha. Ligacoes: 11 de 127 tela(s) com regra (frmPesquisaXdatas, frmEstatisticaDeBornes, frmCompilarFiacao, frmCompilarInterligacao, frmCompilarJumperExt, frmGerenciadorMateriais, frmGerenciadorMatIndep, frmGerenciadorMascaras, frmGerenciadorContatos, frmEditaRevisaoSimplificada, frmEditaRevisaoCompleta).
```

`plugin:test` **746** (+4, `RevisoesDaPaginaTests`), as duas builds **0 avisos**.

**Rodada 155 — frente 12 (parte 7): as telas de modelos — `GERMASC` e `GERCONT` ligadas ao desenho e ao catálogo.**
As duas telas gêmeas de gerenciamento de modelos do reverso (`frmGerenciadorMascaras` e `frmGerenciadorContatos`)
passam a ter comportamento real ligado à regra do recoder:
- a base comum `LigacaoDeModelos` reúne a leitura do catálogo de materiais (`ProjectStore.LerMateriais`), a resolução dos slots LM1/LM2 e o padrão de desativação de botões com motivo na dica;
- a regra pura `FormatacaoDeModelos` (`Positron.Data/Modelos/FormatacaoDeModelos.cs`) resolve os textos de descrição, modelo e fabricante para os códigos de materiais digitados ou associados aos modelos, além da normalização dos nomes de bloco topográfico e de layout;
- `frmGerenciadorMascaras` (`GERMASC`): preenche `DGMascaras` com os modelos de máscara do desenho (`ModelosMascaraDoDesenho.LerModelos`), sincroniza a seleção com as caixas de modelo/materiais/simbologia e preenche `DGPortas` com os componentes do modelo ativo (`ModelosMascaraDoDesenho.LerPortas`), além de ligar as caixas da porta selecionada (`TBEFC`, `TBTerminais`, `TBOrientacao`, `TBRegua`, `TBBornes`);
- `frmGerenciadorContatos` (`GERCONT`): preenche `DGModelo` com os modelos de contato do desenho (`ContatosDoDesenho.LerModelos`), sincroniza a seleção com as caixas de modelo/terminais/orientação/materiais/simbologia e preenche `DGContato` com os contatos auxiliares do modelo ativo (`ContatosDoDesenho.LerAuxiliares`), além de ligar as caixas e combos do contato selecionado (`TBT1`..`TBT3`, `tbOrientacaoTerminais`, `CBTipo`, `CBComportamento`);
- botões de criação, edição, deleção, interop do Excel e seleção em tela ficam desabilitados com o motivo na dica (o mesmo padrão das rodadas anteriores);
- as ligações foram registradas em `LigacoesDasTelas`, subindo o total de telas ligadas à regra de **7** para **9 de 127**.

```text
# ZWCAD 2026, Funcional.dwg (DWG 63), banco r154.db
powershell -ExecutionPolicy Bypass -File scripts/cad-zwcad-smoke.ps1 -Dwg 63 -Revisao R0 \
  -Comandos "ELET,GERMASC,GERCONT" -Desenho "cad-plugin/reverso/Teste_projeto_real/Funcional.dwg" -Banco "<repo>\.tmp-smoke\r154.db"

GERMASC: 7 modelo(s) de máscara lido(s) do desenho (16 porta(s) no primeiro modelo "BARRA TERRA"); 210 material(is) no catálogo; botões de edição desabilitados.
GERMASC: "Gerenciador de Máscaras" (frmGerenciadorMascaras) aberta no CAD — 50 controle(s).
GERCONT: 8 modelo(s) de contato lido(s) do desenho (1 auxiliar(es) no primeiro modelo "FUSÍVEL"); 210 material(is) no catálogo; botões de edição desabilitados.
GERCONT: "Gerenciador de Contatos" (frmGerenciadorContatos) aberta no CAD — 64 controle(s).
```

E no `pzTelas`: `Ligacoes: 9 de 127 tela(s) com regra (frmPesquisaXdatas, frmEstatisticaDeBornes, frmCompilarFiacao, frmCompilarInterligacao, frmCompilarJumperExt, frmGerenciadorMateriais, frmGerenciadorMatIndep, frmGerenciadorMascaras, frmGerenciadorContatos)`. `plugin:test` **742** (+8, `FormatacaoDeModelosTests`), as duas builds **0 avisos**.

**Rodada 154 — a pintura da grade do `ATINDEP`: o `MesclaDGDisp`.** O último item que a rodada
148 deixou na tela. O original termina cada carga da `dgDisp` (`CarregaDGDisp`) no `MesclaDGDisp`
(`frmGerenciadorMatIndep.cs:926`), que lê três células — a 4 (material), a 7 (`Avulso`) e a 11
(`Handle`) — e o catálogo do `CarregaDadosLMMatriz`. A regra entrou em
`Positron.Data/Materiais/PinturaDaListaDoPainel.cs`, na ordem do original (a seguinte sobrescreve):
células 3–5 **cinza-claro**; com handle (veio do desenho) **limão**; avulso **ciano** com a dica
"Dispositivo Avulso" (1200); com handle e não avulso a dica "Dispositivo Independente" (1201);
material 0 sem handle → erro 1203 + 1202, com handle → 1201/1200 + 1202; material ≠ 0 fora do
catálogo → **só a célula 4** em coral com texto branco e erro 1204 + 1205. O handle nulo e o vazio
são o mesmo (o `Nothing = ""` do VB). Na tela, o `CarregarDispositivos` termina na pintura, e as
linhas `ATINDEP:` da carga e do `POSITRON_LIM_PAINEL` dizem o que ficou **nas células** (lido da
grade, não da regra).

```text
# ZWCAD 2026, Funcional.dwg (DWG 63), copia do banco de partida da rodada 152 (r154.db)
POSITRON_LIM_PAINEL=503 powershell -ExecutionPolicy Bypass -File scripts/cad-zwcad-smoke.ps1 -Dwg 63 -Revisao R0 \
  -Comandos "ELET,pzTelas" -Desenho "cad-plugin/reverso/Teste_projeto_real/Funcional.dwg" -Banco "<repo>\.tmp-smoke\r154.db"

ATINDEP: 8 painel(is) na ListaMateriais do DWG 63 (104 item(ns); 1 no painel 1); 210 material(is) no catálogo; primeiro item: "R16" → material 0 (fora do catálogo); pintura: 1 do desenho, 0 avulso(s), 0 sem marca, 0 material(is) fora do catálogo, 1 com erro; ...
ATINDEP: painel 503 escolhido pelo POSITRON_LIM_PAINEL (91 item(ns); pintura: 48 do desenho, 0 avulso(s), 43 sem marca, 0 material(is) fora do catálogo, 5 com erro).
```

A contagem do painel 503 conferida **direto no banco** (python/sqlite sobre a `ListaMateriais` e a
`Materiais`): 91 linhas, 48 com handle e não avulsas, 0 avulsas, 43 sem marca, 0 material fora do
catálogo, 5 com material 0 — igual. O banco sai com o mesmo hash (`b1a89e9d…`): a pintura não
grava. **Não medido:** as cores na tela aberta (a janela não abre no console headless) e o ciano
num banco com avulso (o caminho do avulso está nos testes; o da escrita, na rodada 151).
`plugin:test` **734** (+5, `PinturaDaListaDoPainelTests`), as duas builds **0 avisos**.

**Rodada 153 — as telas contra as capturas do original.** As 126 capturas da `captura_das_janelas`
(commit `68f7b063`) viraram **124 pares** captura × reconstrução: o `RenderizadorDeTelas` e o
`IconesEmbutidos` compilados num projeto mínimo fora do CAD (a `LigacoesDasTelas` e o
`ShowModelessDialog` trocados por vazios, `EnableVisualStyles` como no CAD), cada tela montada,
mostrada fora da vista e desenhada com `DrawToBitmap`, e o par revisado em duas passadas (antes e
depois). A premissa "a maioria já está certa" **não se confirmou na primeira passada**: só 2 de 124
pares saíram sem diferença (`frmEstimativaVeiasLivres`, `frmLink`). As causas eram **genéricas**,
e foram corrigidas na origem — no gerador (`scripts/extrair-formularios-do-reverso.ps1`) e no
renderizador —, não tela a tela:

- **abas duplicadas/vazias**: o `Montar` chamava o `Ligar` uma vez **por filho** (o `TabPages.Add`
  repetido duplicava as abas do `frmConfiguracaoGeral` e esvaziava as do `frmClonar`); agora uma vez
  por recipiente;
- **o texto traduzido na carga**: a rotina de idioma (`CKNomeVisivel.Text = mMensagem[1, 910]`) é a
  primeira atribuição `mMensagem` fora do designer e vale mais que o texto do designer
  ("CKNomeVisível", "lbFunção", "_Atribuir"...); as abas pelo índice (`TabControl1.TabPages[0].Text`);
- **as colunas das grades**: o renderizador as montava na ordem crua do mapa (não na `Ordem`); o
  gerador agora lê, na mesma rotina do `Columns.Add`, o `Columns[i].Visible` e o `Columns[i].Width`
  — este calculado com as locais (`float num = dgEquip.Width - 22` → 184 − 22 = **162**), o índice
  contado desde o último `Columns.Clear()`, vale a primeira atribuição —, e o **estilo de célula**
  do designer sai como `ColumnHeadersDefaultCellStyle.Font` etc. (o renderizador aplica o caminho
  com ponto sobre o objeto do controle). Largura de coluna é **propriedade** (`Width`), não a caixa
  do `Campo` (o contrato largura/altura em par do `TodoCampoTemTipoECaixaValida`);
- **textos de execução**: `"1" + numberDecimalSeparator + "5"` era lido como **um** literal (o
  regex aceitava aspas no meio) e virava `1" + number...`; agora `1,5` (pt-BR). O
  `.ToString().ToUpper()` resolve ("EXTRA"), o literal desescapa `
`, e o campo de entrada cujo
  valor inteiro só existe em execução abre vazio (o rótulo e o título seguem com a expressão);
- **o título do construtor** era lido com `-match` (sem caixa): o `text = "ANSI";` de uma local
  sobrescrevia o `Text` — `frmContatosAux` e `frmEditaFuncaoBobina` voltam a "Contatos Auxiliares" e
  "Editor de Funções".

Na segunda passada as telas batem no texto, nas abas e nos ícones; **o que sobra não é da casca
estática** e está listado por grupo em `docs/reverso-capturas.txt` (§ "A conferência"): as
**variantes** (`DInterlig`/`DICemig` abrem com o título do último caso, `ENEL-SP`; não são comando
ainda), as grades que o original abre **sem coluna**, as que o gerador **não lê** (`Columns.Add` de um
argumento, `ColumnCount`, `DataSource`), o **layout montado em execução** (`frmCadastroDePaineis`,
os `GBEX` dos verificadores) e os rótulos de execução que não são `mMensagem`. O mapa passou de
**3431** para **3424** campos: 7 cabeçalhos `mMensagem[...].ToUpper()` resolvidos eram o mesmo de
outra rotina da mesma grade. `plugin:test` **729** (+3: a tradução, a coluna da carga e o estilo do
cabeçalho), as duas builds **0 avisos**. **Não medido:** as telas abertas dentro do CAD (o par é do
renderizador fora dele, com a mesma fonte e os mesmos estilos visuais).

**Rodada 152 — o ramo do desenho do `Edita` do `ATINDEP`: o `EditaLMDoDispositivo`.** A linha da
grade que veio **do desenho** (tem `Handle`) agora sai do clique nas duas metades do original: o
`IndiceMaterial` da linha na `ListaMateriais` e o bloco — o `iLM1` no XData `Dispositivo` (só quando
difere, com `1071`) e os atributos `MODELO` (vazio), `PAINEL` (o nome do cadastro, `"???"` fora dele)
e `FABRICANTE` (o do material), gravados sempre. Regra em `DispositivoDaListaEdicao`, I/O em
`DispositivoDaListaDoDesenho`.

**Por que a primeira passada não passou:** o `TrocarUmValor` contava a partir do valor **depois** do
app name, mas o índice (`IndiceDoLmNoXData` = 21) conta o `1001` como 0, como o resto do leitor. A
troca caía no `array[22]` e o `iLM1` não mudava — e a tela contava "1 lm(s) regravado(s)". Com o
contador começando em 1 o dump confere. Reproduzido nos dois sentidos no ZWCAD 2026: sem a correção o
`bTL` segue `lm1=463`; com ela, `461`.

**Como medir** (ZWCAD 2026; o banco é o do `cad-projeto-e2e.ps1 -Banco <repo>\.tmp-smoke\r152.db`):

```bash
R=$PWD/.tmp-smoke
export POSITRON_XDATA="$(cygpath -m $R)/dump.txt" POSITRON_XDATA_SUFIXO=.depois POSITRON_XDATA_DISPOSITIVOS=1
export POSITRON_LIM_PAINEL=503 POSITRON_LIM_ITEM="55;bTL;1;461" POSITRON_LIM_ACAO=editar
# 1) o dispositivo real (linha 55, bTL, 5A3E): o antes no load, o depois no pz-dump
powershell -ExecutionPolicy Bypass -File scripts/cad-zwcad-smoke.ps1 -Dwg 63 -Revisao R0   -Comandos "ELET,pzTelas,pz-dump" -Fixture scripts/cad-dump-xdata.lsp   -Desenho "cad-plugin/reverso/Teste_projeto_real/Funcional.dwg" -Banco "$(cygpath -w $R/r152.db)"
# 2) os atributos: a fixture estraga o MODELO do 5A3E e insere o ZQLIM (handle 4DE81) com os
#    quatro tags; a linha do ZQLIM entra na ListaMateriais a mao (Indice 105, Handle 4DE81, material 0)
export POSITRON_DUMP_LSP="$(cygpath -m $PWD/scripts/cad-dump-xdata.lsp)" POSITRON_LIM_ITEM="105;ZQLIM;1;461"
powershell -ExecutionPolicy Bypass -File scripts/cad-zwcad-smoke.ps1 ... -Fixture scripts/cad-fixture-atindep-lim.lsp ...
```

```text
ATINDEP: painel 503 escolhido pelo POSITRON_LIM_PAINEL (91 item(ns)).
ATINDEP: 0 item(ns) da tela regravado(s) com o material 461 (1 linha(s) do desenho com o material gravado na lista). o desenho: 1 dispositivo(s) — 1 lm(s) regravado(s) no XData (0 já com o material), 0 atributo(s) — 1 já iguais, 2 tag(s) fora do bloco.
ATINDEP: ... o desenho: 1 dispositivo(s) — 1 lm(s) regravado(s) no XData (0 já com o material), 3 atributo(s) — 0 já iguais, 0 tag(s) fora do bloco.
```

| dispositivo | antes | depois |
|---|---|---|
| `bTL` 5A3E (real) | `lm1=463`, `MODELO=MODELO DO REAL` (estragado) | `lm1=461`, `MODELO=` — o dump difere **só** nisso |
| `ZQLIM` 4DE81 (fixture) | `lm1=0`, `MODELO ANTIGO`/`PAINEL ANTIGO`/`FABRICANTE ANTIGO` | `lm1=461`, `MODELO=`, `PAINEL=PNL-GGE`, `FABRICANTE=SIEMENS` |

O `bTL` do desenho real só tem o `MODELO` (por isso os "2 tag(s) fora do bloco"); o `PAINEL` e o
`FABRICANTE` só aparecem no bloco da fixture. A linha 105 da lista ficou com `IndiceMaterial` 461.

**Na mesma rodada:** o `ELETCFG` gravava zeradas as 14 chaves que a tela não mostra (`fonteCabos=0`,
`passoPagina=0`, `estiloLinha=` …) — o `Coletar` agora parte do `ConfiguracaoPositron.Copiar()`. E o
`extrair-formularios-do-reverso.ps1` normaliza o fim de linha ao ler: num checkout em LF ele devolvia
**0 telas** sem erro; agora dá 127/3431 e o mapa sai igual ao commitado.

**Rodada 151 — a escrita da lista de materiais: o item avulso do `ATINDEP`.** O segundo item que a
rodada 148 devolveu para a fila do `PLANO.md` era a **escrita da lista** — o `AdicionaUmItemMaterialAvulso`,
o `EditaUmItemMaterialAvulso` e o `RemoveMaterialAvulso` do `cDadosAccessMateriais`, com o corpo do
formulário (`jnTppR04rG4`, `eK4ppmS0dUi`, `eUVppXAWerf`) decidindo o que cada botão faz.

**A regra (`Positron.Data`).** O `Materiais/ListaMateriaisEdicao.cs` traz o assunto inteiro do item
avulso: a `Ordem` do `rfCpTfmCm7Q` (o construtor deixa **100000** e soma 1 por item da janela — é o que
joga a linha nova para o fim da lista), a quantidade do `eK4ppmS0dUi` (a caixa vazia ou no `"0"` vira
`"1"`), o guarda do `jnTppR04rG4` (`tbCodigo1.Text <> "0"`, **sem aparar**: com a caixa vazia o original
acrescenta o material 0, e é o que se reproduz), o `ItemNovo` e o `PlanoDoMaterialEscolhido`. O plano é
o laço do `eK4ppmS0dUi` lido linha a linha: para **cada** linha selecionada, o item **avulso** vira
**substituição** (o `RemoveMaterialAvulso` pelo `Indice` e o insert de novo, com a tag, a quantidade e o
material digitados) e a linha **com `Handle`** vira a ação do **material do dispositivo** — as duas
saem da mesma linha quando ela é as duas coisas, como no original. A leitura da grade é a
`LinhaDoItemNaGrade`, nas **doze células posicionais** do `formataDGDisp`.

**A escrita (`ProjectStore`).** `AdicionarItemDaLM` (o insert **sem** o `Indice`, que é a chave do
banco — devolve o que ele atribuiu), `EditarMaterialDoItemDaLM` (o `UPDATE ... SET IndiceMaterial` pelo
`Indice`) e `RemoverItemDaLM` (o `DELETE` pelo `Indice`, devolvendo quantas linhas saíram).

**As diferenças deliberadas (as três):**

1. **O ramo do desenho não é gravado.** O `Edita` do original, na linha que tem `Handle`, faz também o
   `clsDispositivo.EditaLMDoDispositivo` — o XData `DISPOSITIVO` (o `iLM1`, o `array[21]`) e os
   atributos `MODELO`/`PAINEL`/`FABRICANTE` do bloco. Como o `IndiceMaterial` sozinho deixaria a linha e
   o desenho discordando (e a próxima projeção desfaria a gravação), a tela **diz o motivo na linha de
   comando** em vez de gravar meia operação — e o comando voltou para a fila do `PLANO.md`.
2. **O `IndiceLM` do item novo fica ausente.** O original grava nele o **índice da linha da grade** (o
   parâmetro `indice` do `AdicionaUmItemMaterialAvulso`), que não é o número do LM — esse é do
   `AtualizaIndiceLM` dos relatórios. Ausente, e não inventado.
3. **A grade é relida do banco depois de cada gravação** (o original só repinta depois do editar e
   apaga), então as chaves da grade são as do banco; e a linha **do desenho** que o `Apaga` deixa de
   fora entra na contagem da resposta, em vez de sumir em silêncio.

**Como a tela é medida num script.** O gancho do harness é o `POSITRON_LIM_ITEM`
(`Indice;Tag;Quantidade;Codigo`) com o `POSITRON_LIM_ACAO` (`adicionar`, `editar` ou `apagar`): o
`Indice` **seleciona** a linha e o resto preenche as caixas — nesta ordem, porque a seleção chama o
`PreencherMaterial` e escreveria por cima do digitado. A seleção **limpa** as outras linhas antes
(a `dgDisp` é de seleção múltipla, como no construtor do original) — sem isso a linha do desenho
entraria junto no editar/apagar.

```bash
# o banco do projeto real (copia do da rodada 149): 210 materiais, 480 paineis, 104 linhas de lista
cp .tmp-smoke/r149.db .tmp-smoke/r151.db

# 1) acrescenta um item avulso no painel 1 (o painel que a tela abre)
POSITRON_LIM_ITEM="0;AV151;2;9001" POSITRON_LIM_ACAO=adicionar npm run cad:smoke:acad -- \
  -Dwg 63 -Revisao R0 -Comandos ELET,pzTelas \
  -Desenho "cad-plugin/reverso/Teste_projeto_real/Funcional.dwg" -Banco ".tmp-smoke/r151.db"

# 2) edita o que foi acrescentado (o `Indice` da linha vem do banco: 105)
POSITRON_LIM_ITEM="105;AV151-EDITADO;3;9002" POSITRON_LIM_ACAO=editar npm run cad:smoke:acad -- ... -Banco ".tmp-smoke/r151.db"

# 3) apaga o item, deixando o banco como estava
POSITRON_LIM_ITEM="105;;;" POSITRON_LIM_ACAO=apagar npm run cad:smoke:acad -- ... -Banco ".tmp-smoke/r151.db"

# 4) os dois guardas: a linha DO DESENHO (o `R16`, indice 12) no apagar e no editar, e a caixa no 0
POSITRON_LIM_ITEM="12;;;" POSITRON_LIM_ACAO=apagar npm run cad:smoke:acad -- ... -Banco ".tmp-smoke/r151.db"
POSITRON_LIM_ITEM="12;R16;1;9001" POSITRON_LIM_ACAO=editar npm run cad:smoke:acad -- ... -Banco ".tmp-smoke/r151.db"
POSITRON_LIM_ITEM="0;AV151;1;0" POSITRON_LIM_ACAO=adicionar npm run cad:smoke:acad -- ... -Banco ".tmp-smoke/r151.db"
```

```text
ATINDEP: 8 painel(is) na ListaMateriais do DWG 63 (104 item(ns); 1 no painel 1); 210 material(is) no catálogo; primeiro item: "R16" → material 0 (fora do catálogo); Adiciona/Edita/Apaga ligados, a pesquisa desabilitada.
ATINDEP: item avulso 9001 "AV151" no painel 1 (quantidade 2, Ordem 100000) gravado — a linha entrou com o Indice 105 do banco.
ATINDEP: 1 item(ns) da tela regravado(s) com o material 9002.
ATINDEP: 1 item(ns) da tela apagado(s).
ATINDEP: 0 item(ns) da tela apagado(s). 1 linha(s) do desenho não entram: quem as escreve é a projeção (o COMPLM).
ATINDEP: 0 item(ns) da tela regravado(s) com o material 9001. 1 linha(s) do desenho ficaram sem o material novo: a escrita do lm no dispositivo (o EditaLMDoDispositivo, o XData do bloco e os atributos) ainda não está portada.
ATINDEP: a caixa do código está no 0 — escolha o material; a linha do dispositivo sem material não entra na lista (o guarda do original).
JANELAS: 127 de 127 tela(s) do reverso montada(s), nenhuma falha. Ligacoes: 7 de 127 tela(s) com regra (...).
```

**O que a medida prova no banco** (hash canônico das três tabelas, conferido no SQLite depois de cada
passo — o instrumento é o `hash-lm.py`, cópia local no `.tmp-smoke`):

| passo | `ListaMateriais` | hash da tabela | a linha |
|---|---|---|---|
| partida | **104** | `bb955f9e5833b39a` | — |
| Adiciona | **105** | `ecc29b60e84e04a6` | `(105, 63, 1, 'AV151', 9001, 2, 100000, 1, None, None)` |
| Edita | **105** | `9769ccd8caab6211` | `(105, 63, 1, 'AV151-EDITADO', 9002, 3, 100000, 1, None, None)` |
| Apaga | **104** | `bb955f9e5833b39a` | — (o **mesmo hash da partida**) |
| guardas (4 a 6) | **104** | `bb955f9e5833b39a` | — |

e a `Materiais` (210, hash `6e4fe9e2155dd676`) e o cadastro `Paineis` (480, `b79ededdb5c5a3a3`) não
mudaram em passo nenhum — a escrita mexe só na lista. O `Avulso` = 1 e o `IndiceLM`/`OrdemLay` **nulos**
do item novo são o que a regra manda gravar (o original mandaria o índice da linha da grade no
`IndiceLM`). O `Indice` 105 ficou **o mesmo** na substituição: o `DELETE` + `INSERT` do original deixa o
SQLite reusar a chave da linha que saiu (a tabela não usa `AUTOINCREMENT`) — por isso a grade é relida
do banco depois de cada gravação.

**O que a medida não cobre:** a janela **aberta** no `accoreconsole` (o `ShowModelessDialog` derruba o
processo, o achado da rodada 138), a **conferência visual** da tela (do dono) e o ramo do
`EditaLMDoDispositivo`, que não é portado — o que dele se prova é a **recusa com o motivo** e o banco
intacto.

**Gate:** `plugin:test` **718** (+13, `ListaMateriaisEdicaoTests`), as duas builds **0 avisos**, o ciclo
completo `cad-projeto-e2e.ps1 -Cad AutoCAD -Idempotencia` verde com o relatório **novo** (249 problemas,
a linha de base 107+119+11+10+2 conferida) e a idempotência no mesmo hash (`7c1635f0…`).

**Dois achados de instrumento nesta rodada** (os dois por causa do repo estar no Desktop):

1. **O console runner do xunit não carrega os assemblies da árvore do repo** — `System.IO.FileLoadException
   ... Acesso negado`, a mesma origem remota que o `-PastaLocal` do harness já contorna para o
   `NETLOAD`. A suíte sai copiando as dependências do runner e as DLLs do teste para uma pasta local
   (`%TEMP%`) e rodando lá — receita atualizada no item do Troubleshooting.
2. **O python do venv do sidecar não escreve no `%TEMP%`** (`PermissionError` num caminho explícito,
   enquanto o python do sistema escreve): os dumps da idempotência do `cad-projeto-e2e.ps1` morriam e o
   passo 6 conferia a linha de base num `positron-relatorio.txt` **velho** de outra rodada (o plugin
   grava o relatório **ao lado do banco**, e o script procurava no `%TEMP%`). O script passou a usar a
   pasta do banco para os dois — é o mesmo lugar onde o ELETREL grava.

**Rodada 150 — a barra do AutoCAD: o pacote velho em `%APPDATA%`.** O dono do produto apontou que a
ribbon do **AutoCAD** estava com os mesmos problemas que a rodada 147 resolveu para o ZWCAD (o painel
extra "Positron", a forma plana). A conferência começou pelo código e ele estava certo: a construção é
**uma só** para os dois CADs desde a rodada 138 (só o `using` muda, mais dois `#if` de `Name`/`Id` e do
`IsActive`), e o montador do AutoCAD abre com os mesmos **9 painéis**. O defeito estava **fora do
código**: a interface cheia carrega o plugin pelo **autoload**, e o pacote em
`%APPDATA%\Autodesk\ApplicationPlugins\Positron.bundle` é uma **cópia da DLL**, feita pelo
`scripts/instala-bundle.ps1`. O pacote instalado era o de **12/10** — anterior à rodada 147 (commit
`dc41a8fd`) —, então o AutoCAD mostrava a barra antiga enquanto o ZWCAD, medido por `NETLOAD` de uma
DLL recém-compilada, mostrava a nova. Rodar `instala-bundle.ps1 -Cad AutoCAD` depois do build é o que
faltava (está no Troubleshooting, com o sintoma que identifica a cópia velha).

**A leitura viva da aba no AutoCAD.** O `pzBarra` nunca tinha rodado no AutoCAD: num script ele lê
**antes** da barra existir (`pzBarra: a aba POSITRON.ID_Positron não está no ribbon` — medido, o `Idle`
que cria a aba não dispara enquanto o script roda, nem com `delay`). A leitura saiu por **COM**, com o
CAD já parado na linha de comando:

```powershell
$env:POSITRON_LOG = "$pasta\positron-gui.txt"      # sem /b
Start-Process 'C:\Program Files\Autodesk\AutoCAD 2020\acad.exe' -ArgumentList @('/nologo','/i',$copia)
Start-Sleep 30                                      # a aba entra na primeira ociosidade
$prog = [Runtime.InteropServices.Marshal]::GetActiveObject('AutoCAD.Application.23')   # (2020)
$prog.ActiveDocument.SendCommand('pzBarra ')
```

```text
Barra: aba "Positron" com 9 painel(is) — 121 botão(ões), 5 menu(s) com 39 item(ns), 1 liga/desliga, 1 lista e 1 campo; 34 linha(s), 86 quebra(s), 7 área(s) recolhível(is), 9 separador(es). Acionáveis: 108 ligado(s) (3 no comando do recoder), 53 desativado(s); tema escuro.
pzBarra: 1 aba(s) POSITRON.ID_Positron ("Positron"), 9 painel(is) [Configuração | Caderno | Dispositivos | Bornes | Fiação | Construtivo | Cabos e Veias | Utilitários | Help]; RibbonButton=120, RibbonCombo=1, RibbonMenuButton=5, RibbonMenuItem=39, RibbonPanelBreak=7, RibbonRowBreak=86, RibbonRowPanel=34, RibbonSeparator=9, RibbonTextBox=1, RibbonToggleButton=1; 1 botão(ões) de canto; 55 item(ns) desativado(s).
```

**As linhas são as mesmas do ZWCAD 2026** da rodada 147 — uma aba, nove painéis na ordem do original,
sem o painel extra, os **3** comandos substitutos (`CFG`/`VFIA`/`VINT`) e o mesmo par **108 ligados / 53
desativados**. Com isso a barra do §7.8 deixa de ser "medida só no ZWCAD": o AutoCAD 2020 reproduz a
fita **por igual**, como já fazia com os pipelines.

**O que impede o defeito de voltar invisível.** O `Plugin.Initialize` passou a escrever, logo abaixo do
`Positron carregado`, **qual build está carregado**:

```text
Positron: DLL de 2026-10-13 22:00 — C:\Users\RNO\AppData\Roaming\Autodesk\ApplicationPlugins\Positron.bundle\Positron.Plugin.AutoCAD.dll
```

A linha (caminho + data do arquivo) separa as duas fontes de DLL: no headless do `cad:smoke:acad` ela
diz `C:\positron-smoke\cad\Positron.Plugin.AutoCAD.dll` (a cópia do `NETLOAD`), na interface cheia diz
a pasta do **pacote** — se a data for antiga, é o pacote que está velho, não o código. O `smoke` segue
verde (a checagem dele continua na string `Positron carregado`, que não mudou).

**Achado de instalação (não é do plugin):** nesta máquina a criação do banco no `%TEMP%` falhou
(`falha ao criar banco de dados novo: unable to open database file`, no `sqlite3` puro também): a
receita do smoke sem `-Banco` não roda **aqui** — as medições desta rodada passaram `-Banco` com um
arquivo dentro do repo. Está no Troubleshooting.

**Gate:** as duas builds **0 avisos**, `plugin:test` **705** (inalterado — a rodada não toca o
`Positron.Data`), o `cad:smoke:acad` verde com a linha nova e a leitura viva acima. A **conferência
visual** da fita continua sendo do dono.

**Rodada 149 — a escrita do catálogo de materiais: os quatro botões do `GERLM`.** O item que a rodada
148 devolveu para a fila do `PLANO.md` era a **escrita do catálogo** — o `AdicionaItemMaterial`, o
`EditaItemMaterial` e o `RemoveMaterial` do `cDadosAccessMateriais`, com o corpo do formulário
(`OYXpWrD09De`, `KcbpW9CNreY`, `LNDpWzth4ys`, `iaGppGHMjAT`) decidindo o que cada botão faz.

**A regra (`Positron.Data`).** No `Materiais/CatalogoDeMateriais.cs` entraram o `ProximoCodigo` e o
`PlanoDeGravacao`, mais os tipos `LinhaDoCatalogoNaGrade`, `OperacaoNoCatalogo` e
`TipoDeOperacaoNoCatalogo`. O `ProximoCodigo` é o `num` do Adiciona Material: o código **digitado**
quando é número (a leitura é pela cultura **invariante**, como o `XDataNumero` do recoder, para o
ponto não virar separador de milhar — a armadilha que a primeira passada da suíte pegou: `"5.6"`
lia **56**; a vírgula do teclado brasileiro também entra) e, senão, o **maior da grade mais um**,
começando em 1, com o laço `if (num < codigo) num = codigo + 1` reproduzido como está. O
`PlanoDeGravacao` é o `btSalvar` na ordem do original: (1) as linhas **apagadas** na tela, (2) na
ordem da grade, cada linha marcada **`A`** vira **remover + adicionar** — é o `RemoveMaterial`
defensivo que o original faz antes do `AdicionaItemMaterial`, para um código repetido ser
substituído — e cada **`E`** vira edição; linha sem marca não gera operação. A **escrita** ficou no
`ProjectStore`: `AdicionarMaterial` (o `Indice` **não** vai no insert — é a chave que o banco atribui,
como no Access), `EditarMaterial` (os cinco campos pelo `CodigoInterno`, que não muda) e
`RemoverMaterial` (devolve quantas linhas saíram).

**A ligação (`Positron.Plugin`).** O `LigacaoDoFrmGerenciadorMateriais` deixou de desabilitar o que
grava e ligou os quatro botões, com um estado de edição por janela (a lista de apagados e o flag de
alterado, que habilita o `Salvar`):

- **Adiciona Material**: as seis caixas vazias não fazem nada; um código que **já está na grade** só
  seleciona a linha (o laço do `ConditionalCompareObjectEqual`); senão o código sai do
  `ProximoCodigo` e é **escrito de volta na caixa**, a linha entra no fim com a marca `A` e as seis
  primeiras células ficam **verdes**.
- **Edita Material Selecionado**: a linha recebe das caixas **só os campos que mudaram** (comparação
  **sem caixa**, o `TextCompare` do VB), cada um pintado de **amarelo**, e a linha passa a `E`.
- **Apaga Material Selecionado**: a linha sai da grade e o código interno (a coluna 6, o
  `IndiceOriginal`) entra na lista de apagados.
- **Salvar Alterações**: o plano vai para o banco **na ordem do original**, a grade é recarregada do
  banco, as caixas são limpas e o `Salvar` volta a desabilitar.

**Duas diferenças deliberadas:** o original pergunta "Salvar Alterações?" num `MsgBox` **ao fechar** a
janela (e o "sim" chama o mesmo `iaGppGHMjAT`) — o recoder **não salva sozinho**, só avisa na linha de
comando —, e a linha recém-acrescentada tem `0` na coluna do índice, que o original empurra para a
lista de apagados ao ser removida (`RemoveMaterial(0)`), enquanto aqui o `0` **não** entra, porque
apagar o material de código 0 apagaria **outro** material. Importar/Exportar do Excel continuam
desabilitados com o motivo na dica (interop).

**Como a tela é medida num script.** Não há clique, então o harness ganhou o gancho: ao abrir a
tela, `POSITRON_LM_MATERIAL` (os seis campos separados por `;`), `POSITRON_LM_ACAO` (`adicionar` é o
padrão quando só o material vem, ou `editar`/`apagar`) e `POSITRON_LM_SALVAR`=1 rodam a **mesma**
ação do clique. **Ordem:** a seleção da linha do código vem **antes** do preenchimento das caixas —
o `MostraSelecionado` da seleção escreveria por cima do digitado e um `editar` nunca acharia
diferença (o original digita **depois** de clicar). As variáveis são exportadas no shell e o
`accoreconsole` as herda:

```bash
# 1) acrescenta um material e grava (o banco é a cópia do banco do projeto)
POSITRON_LM_MATERIAL="9001;CLI9001;MODELO-H;FAB-H;desc resumida do harness;desc completa do harness" \
POSITRON_LM_SALVAR=1 npm run cad:smoke:acad -- -Dwg 63 -Revisao R0 -Comandos ELET,pzTelas \
  -Desenho "cad-plugin/reverso/Teste_projeto_real/Funcional.dwg" -Banco ".tmp-smoke/r149.db"

# 2) edita o que foi acrescentado (só os campos que mudam entram na gravação)
POSITRON_LM_MATERIAL="9001;CLI-EDITADO;MODELO-H2;FAB-H;desc resumida editada;desc completa editada" \
POSITRON_LM_ACAO=editar POSITRON_LM_SALVAR=1 npm run cad:smoke:acad -- ... -Banco ".tmp-smoke/r149.db"

# 3) apaga o material, deixando o banco como estava
POSITRON_LM_MATERIAL="9001" POSITRON_LM_ACAO=apagar POSITRON_LM_SALVAR=1 \
  npm run cad:smoke:acad -- ... -Banco ".tmp-smoke/r149.db"
```

```text
GERLM: 210 material(is) no catálogo ("TP KP101" no código 4); grade com 9 coluna(s); Adiciona/Edita/Apaga/Salvar ligados, o Excel desabilitado.
GERLM: material 9001 "desc resumida do harness" marcado para acrescentar (A).
GERLM: catálogo gravado — 0 removida(s), 1 acrescentada(s), 0 editada(s); a grade foi recarregada.
GERLM: linha 9001 marcada para editar (E) — código do cliente, modelo, descrição resumida, descrição completa.
GERLM: catálogo gravado — 0 removida(s), 0 acrescentada(s), 1 editada(s); a grade foi recarregada.
GERLM: linha 9001 tirada da grade (entra na lista de apagados).
GERLM: catálogo gravado — 1 removida(s), 0 acrescentada(s), 0 editada(s); a grade foi recarregada.
JANELAS: 127 de 127 tela(s) do reverso montada(s), nenhuma falha. Ligacoes: 7 de 127 tela(s) com regra (...).
```

**O que a medida prova no banco** (conferida no SQLite depois de cada passo, não só pela linha do log):

| passo | `Materiais` | o que ficou diferente |
|---|---|---|
| partida (banco da rodada 148) | **210** | — |
| Adiciona + Salvar | **211** | a linha `9001` com os seis campos digitados e o `Indice` **595** que o **banco** atribuiu |
| Edita + Salvar | **211** | só os **quatro** campos que mudaram (`Fabricante` foi digitado igual e **não** entrou) |
| Apaga + Salvar | **210** | o `9001` fora; a tabela **igual à da partida** (hash `fbac1320…` dos dois lados) |

e as **104** linhas da `ListaMateriais` e as **480** do cadastro `Paineis` não foram tocadas em nenhum
passo — a escrita mexe só no catálogo.

**O que a medida não cobre:** o `MsgBox` do fechamento (o recoder avisa na linha de comando, por
desenho), a janela **aberta** no `accoreconsole` (o `JANELA` derruba o processo, o achado da rodada
138) e a conferência **visual** da tela, que é do dono. O `plugin:test` **não roda** nesta máquina (o
item do Troubleshooting) — a suíte inteira saiu pelo console runner do xunit: **705 testes, 0 falhas**.

**Rodada 148 — as duas telas de materiais ligadas à regra (`GERLM` e `ATINDEP`).** O item 3 da fila do
`PLANO.md` mandava confirmar no painel o que a regra cobre antes de ligar as telas: o
`cobertura-do-reverso.ps1 -Listas` dizia `com a ligacao na tela: 5` e nenhuma das duas estava na
lista. O que faltava era **leitura**, e ela entrou como regra primeiro.

**A regra (`Positron.Data`).** `Materiais/CatalogoDeMateriais.cs` traz o `MaterialDoCatalogo` —
`Indice`, `CodigoInterno`, `CodigoCliente`, `Modelo`, `Fabricante`, `DescricaoResumida`/
`DescricaoCompleta`, a tabela `Materiais` (o `LM` do original) — e o `CatalogoDeMateriais` com o
`Indexar` (por `CodigoInterno`, o primeiro vence, como o laço do `ODLpp1Gpc7y`) e o `Buscar` (que
nunca lança). O `ProjectStore.LerMateriais()` lê com o `order by CodigoInterno` do
`CarregaListaMateriaisDoDG` e com o `TiraDBNull` do original — **coluna nula é texto vazio**, porque
os campos vão direto para a grade e para as caixas. O `LerListaMateriais` passou a devolver também o
`Indice` da linha (a chave da tabela, que é a primeira coluna da grade do `ATINDEP`). No
`ListaMateriaisGerador.cs` entrou o assunto da lista: `PaineisDaListaDeMateriais.Distintos` (os
painéis sem repetir, **na ordem da lista**) e `DoPainel` (as linhas de um painel) — são a coluna da
esquerda e a grade do `ATINDEP`. Os testes são o `CatalogoDeMateriaisTests` (o catálogo lido do banco
com a ordem e o nulo, o índice que não repete, a busca sem resultado, os painéis e as linhas do
painel) e uma linha nova no `ListaMateriaisTests` (o `Indice` que a leitura devolve).

**A suíte nesta máquina.** O `npm run plugin:test` **não roda** aqui: o `dotnet test` com o SDK 10
preview não carrega o `xunit.runner.visualstudio.testadapter.dll` do net472, **não descobre teste
nenhum** e ainda sai 0 (ver o item novo do Troubleshooting). A suíte inteira foi rodada pelo console
runner do xunit: **700 testes, 0 erro(s), 0 falha(s), 0 ignorado(s)** — os 4 novos do
`CatalogoDeMateriaisTests` incluídos.

**A ligação (`Positron.Plugin`).** `Interface/Telas/LigacaoDeMateriais.cs` é a base das duas telas —
o catálogo do banco, os **textos e as dicas do construtor do original** (as `mMensagem` que o
renderizador não aplica, porque ele pinta o texto do designer), o `Celula`/`TextoDaCaixa` e o
`Desabilitar` que deixa o motivo na dica — e cada tela tem o seu arquivo, registrado no
`LigacoesDasTelas`:

- `LigacaoDoFrmGerenciadorMateriais` (`GERLM`): a grade `DGMateriais` com as **9 colunas do
  `formataDG`** (inclusive `IndiceOriginal`, `Ação` e `IndiceEL`, que são o contrato do `iaGppGHMjAT`
  de gravação: `A` acrescentar, `E` editar) e as linhas do catálogo no formato do
  `CarregaListaMateriaisDoDG`; o `MostraSelecionado` preenche as seis caixas do material. Os **seis**
  botões que gravam/importam entram desabilitados com o motivo (`btSalvar` inclusive) — **os quatro do
  catálogo ficaram ligados na rodada 149**, que é a seção acima.
- `LigacaoDoFrmGerenciadorMatIndep` (`ATINDEP`): a `dgPaineis` (índice **oculto** + nome do cadastro
  de `Paineis`) e a `dgDisp` com as **12 colunas do `formataDGDisp`**, preenchida **na ordem
  posicional** do `Rows.Add` do original — `Indice`, `DWG`, `Painel`, `Tag`, `IndiceMaterial`,
  `Quantidade`, `Ordem`, `Avulso`, `Destino`, `DescDestino`, `Alternativo`, `Handle` —, porque são as
  células 4, 7 e 11 que as regras de cor/erro do `MesclaDGDisp` leem; a seleção de um item preenche
  `TBTag`, `TBQuantidade` e as quatro caixas do catálogo pelo código interno da célula 4 (o
  `U7Epp0og4bx` + `ODLpp1Gpc7y`). Os quatro botões de gravação/pesquisa entram desabilitados.

**Duas diferenças deliberadas em relação ao original** (as duas registradas em comentário no código):
(1) a lista de painéis sai da **`ListaMateriais`** — a regra do recoder —, em vez de uma segunda
varredura do ModelSpace pelo `clsLM.PaineisDocumentoLM`, que lê o painel de cada entidade por XData;
(2) a **pintura** da grade (o `MesclaDGDisp`, com as cores por avulso/material e o `ErrorText`) fica
para a rodada que portar a **edição** — junto com ela voltaram para a fila do `PLANO.md` as duas
regras que a tela pede e o recoder não tem: a **escrita do catálogo**
(`AdicionaItemMaterial`/`EditaItemMaterial`/`RemoveMaterial`) e a **escrita da lista** (o item avulso:
`AdicionaUmItemMaterialAvulso`/`EditaUmItemMaterialAvulso`/`RemoveMaterialAvulso`).

**Medido no AutoCAD 2020** (`cad:projeto:acad`; verificado em 2026-10-16 que o ZWCAD **não** está
nesta máquina nesta data). O banco do projeto saiu da projeção do desenho real e o catálogo/cadastro do
Access:

```bash
# 1) o banco do projeto + a projeção + a lista de materiais (as telas leem a ListaMateriais)
#    (o `Desenho` é a COPI del `Funcional.dwg`; o original nunca é tocado)
# 2) o catálogo `Materiais` (210) e o cadastro `Paineis` (480), que vivem no `RCD.mdb`
powershell -ExecutionPolicy Bypass -File scripts/cad-importa-catalogo.ps1 `
    -Banco "<repo>\.tmp-smoke\positron-projeto.db" `
    -Mdb "<repo>\cad-plugin\reverso\Teste_projeto_real\RCD.mdb"
# 3) a medida das telas: o `pzTelas` monta as 127 e roda cada ligação
npm run cad:smoke:acad -- -Dwg 63 -Revisao R0 -Comandos ELET,pzTelas -Desenho "<copia do Funcional.dwg>" -Banco "<...>\positron-projeto.db"
```

```text
COMPLM: 104 linha(s) em ListaMateriais (8 painel(is); 0 avulso(s); 199 borne(s) do desenho, 0 sem régua no dicionário; ordem do desenho; 83 posição(ões) de layout).
ATINDEP: 8 painel(is) na ListaMateriais do DWG 63 (104 item(ns); 1 no painel 1); 210 material(is) no catálogo; primeiro item: "R16" → material 0 (fora do catálogo); os botões que gravam estão desabilitados.
GERLM: 210 material(is) no catálogo ("TP KP101" no código 4); grade com 9 coluna(s); os botões que gravam estão desabilitados.   <- rodada 148 (na 149 estes quatro passaram a gravar)
JANELAS: 127 de 127 tela(s) do reverso montada(s), nenhuma falha. Ligacoes: 7 de 127 tela(s) com regra (frmPesquisaXdatas, frmEstatisticaDeBornes, frmCompilarFiacao, frmCompilarInterligacao, frmCompilarJumperExt, frmGerenciadorMateriais, frmGerenciadorMatIndep).
```

Os 210 materiais e os 480 painéis são os **do produto** (importados do `RCD.mdb`), e as 104 linhas da
`ListaMateriais` são as do `COMPLM` no `Funcional.dwg` — nada de dado de teste na medida. O `R16` do
painel 1 tem `lm = 0` (o `BorneSemLm` do `VERIF`), então a primeira linha **exercita o ramo em que a
célula 4 não casa com o catálogo** e a caixa do código fica no `0` que o original deixa; o ramo com
material (o `Buscar` que preenche as quatro caixas) está no teste da regra.

**O que a medida não cobre:** abrir a janela pelo comando (`JANELA` com
`POSITRON_JANELA=frmGerenciadorMatIndep`) **roda a ligação** — a linha `ATINDEP:` sai no log —, mas a
janela não abre no `accoreconsole`: o `ShowModelessDialog` derruba o processo antes da linha de
comando, a mesma limitação do `PaletteSet` registrada na rodada 138. Como nas outras cinco ligações,
a evidência do script é o `pzTelas` (monta as 127 e descarta), e a conferência **visual** da tela é do
dono do produto.

**Rodada 147 — a barra do original de verdade: a árvore do `Ribbon.cs`, sem o painel duplicado.** O dono do produto viu a barra do ZWCAD "misturada, com interface duplicada reverso/recoder". A comparação com o `Ribbon.cs` confirmou: os 9 painéis e os 121 botões batiam no nome e na ordem, mas (1) havia um **10º painel "Positron"** com 8 botões nossos — `ELET` e `FOLHAS` (a mesma paleta), `ELETCFG` (repete o `CFG` do canto da Configuração), `VERIF` (repete o `VFIA`/`VINT`) e quatro ferramentas de diagnóstico (`JANELAS`, `JANELA`, `pzDiag`, `pzTelas`); (2) o `CFG`, o `VFIA` e o `VINT` do original abriam a **casca** gerada da tela, sem comportamento, enquanto o comando que faz o trabalho estava no painel extra; (3) a forma não era a do original — tudo numa fileira, o mesmo estilo em todos os botões, sem as **34 linhas**, as **7 áreas recolhíveis**, os **5 menus suspensos com 39 itens** (os relatórios `RFIA`, `RPOT`, `LCAB`, `DI*`…), a **lista de seção**, o **campo da cor**, o **liga/desliga `InfoOn`** e os ícones do **tema escuro**. O Eletron original **não** está sendo carregado junto: não está no autoload do ZWCAD (`HKLM\...\ZWCAD\2026\en-US\Applications`) e o `ZWCAD.CUIX` do perfil não guarda nada dele nem do Positron.

**O extrator virou um intérprete** (`scripts/extrair-barra-do-reverso.ps1`). O corpo de cada painel é uma sequência regular — cria a variável (`RibbonButton item3 = new RibbonButton()`), configura (por um dos seis ajudantes ou por propriedade) e **adiciona** a um contêiner (`val13.Items.Add(item3)`) —, e o script agora lê instrução por instrução e monta a árvore: linha (`RibbonRowPanel`) com as quebras, área recolhível (`RibbonPanelBreak`), separador (com a largura dos declarados), menu (`RibbonMenuButton` com os `RibbonMenuItem`), lista (`RibbonCombo`), campo (`RibbonTextBox`), liga/desliga (`RibbonToggleButton`) e o botão do canto (`DialogLauncher`). O ícone guarda os **dois temas** (o par `if (num == 0) image = X_Dark; if (num == 1) image = X;`). A **conferência** sai no próprio mapa: cada tipo contra o `new RibbonX()` do arquivo — **121** botões, **5** menus, **39** itens, **34** linhas, **86** quebras, **7** recolhíveis, **1** lista, **1** campo, **1** liga/desliga e **6** separadores declarados (na árvore são **9** usos: o `val6` da Fiação entra seis vezes) —, e os **2** separadores que o original declara e **nunca usa** (`val7`/`val8` da Fiação) ficam listados. O `docs/reverso-barra-do-original.txt` agora mostra a árvore de cada painel.

**O modelo** (`Positron.Data/Interface/Mapas/BarraDoReverso.cs`): o `BotaoDaBarra` virou `ItemDaBarra` (o `TipoDoItemDaBarra`, o grau do ajudante, os dois ícones, a largura, o desativado e os filhos) e o `PainelDaBarra` ganhou o `Lancador` e os `Itens`. Os graus ficaram com nome do que são: `Grande` (ícone grande, texto embaixo — só o banner), `IconeGrande` (era `Pequeno`: ícone grande sem texto), `IconeTexto`, `Icone` (16×16), `Menu`, `ItemDeMenu` e `Dialogo`.

**O montador** (`Positron.Plugin/Interface/Barra/BarraDeFerramentas.cs`) percorre a árvore e aplica o estilo de cada ajudante (`Size`, `Orientation`, `ShowText`, `Image`/`LargeImage`, as larguras), o ícone do tema (`COLORTHEME`, como o original), a aba à frente (`IsActive`) e o `ESC` antes do comando nos itens de menu (o `RibbomMenuItemCommandHandler` de lá). O **painel "Positron" saiu**: o `CFG`, o `VFIA` e o `VINT` chamam o comando do recoder que faz o trabalho (`ELETCFG`, `VERIF`, `VERIF` — `BarraDeFerramentas.ComandoNoRecoder`, com o nome do nosso comando na dica), e os comandos de diagnóstico seguem existindo, fora da barra. Entrou o **`PAG`**, o comando do original que abre a paleta das páginas (o `GerenciadorPagina`, `Comandos.cs:1447`), como o `FOLHAS`. O que não tem comando no recoder entra **desativado com o motivo na dica** — 53 acionáveis (inclusive as 14 variantes `DI*` do menu de relatórios e o `InfoOn`), a lista de seção e o campo da cor (o original grava a seção/cor que o `INSM`/`CON` usam; não portado). A aba continua **Positron** (decisão do dono) e o banner diz "Positron". No ZWCAD o "desativado" passou a ser o `IsEnabled` (que a `ZdWindows.dll` tem no `RibbonItem`, inclusive na lista e no campo) mais o `IsActive = false` que o original usa nos itens de comando.

**O instrumento novo `pzBarra`** lê a aba **no ribbon vivo do CAD** (`ComponentManager.Ribbon`) e conta pela classe real de cada item, sem passar pelo montador.

```powershell
& .\scripts\cad-zwcad-smoke.ps1 -Comandos @('pzBarra','PAG') -Banco "<pasta>\r147.db"
```

Medido no **ZWCAD 2026** (interface cheia, o `ZWCAD.exe /b` do smoke):

```text
Barra: aba "Positron" com 9 painel(is) — 121 botão(ões), 5 menu(s) com 39 item(ns), 1 liga/desliga, 1 lista e 1 campo; 34 linha(s), 86 quebra(s), 7 área(s) recolhível(is), 9 separador(es). Acionáveis: 108 ligado(s) (3 no comando do recoder), 53 desativado(s); tema escuro.
pzBarra: 1 aba(s) POSITRON.ID_Positron ("Positron"), 9 painel(is) [Configuração | Caderno | Dispositivos | Bornes | Fiação | Construtivo | Cabos e Veias | Utilitários | Help]; RibbonButton=120, RibbonCombo=1, RibbonMenuButton=5, RibbonMenuItem=39, RibbonPanelBreak=7, RibbonRowBreak=86, RibbonRowPanel=34, RibbonSeparator=9, RibbonTextBox=1, RibbonToggleButton=1; 1 botão(ões) de canto; 55 item(ns) desativado(s).
Positron — paleta de folhas com 0 página(s) (ancorada no CAD).
```

O ribbon vivo bate com o `Ribbon.cs` em todos os tipos (os 120 botões dos painéis + o do canto = 121); os 55 desativados são os 53 acionáveis sem comando + a lista + o campo; há **uma** aba e **nove** painéis. A última linha é o `PAG` abrindo a paleta (o desenho vazio do smoke não tem página). **A conferência visual** (o tamanho dos ícones, a área recolhível abrindo, os menus) é do dono do produto: o harness roda por script e não olha a tela.

**Gate desta rodada:** `plugin:test` **696** (o `BarraDoReversoTests` reescrito sobre a árvore: as contagens por tipo do `Ribbon.cs`, a forma — quebra só dentro de linha, item de menu só dentro de menu, no máximo uma área recolhível por painel —, o Caderno, a Fiação com a lista/cor/menus, o Help com o `InfoOn` e o cruzamento com o mapa das telas: **117** itens abrem janela, **16** sem comando no recoder) e as duas builds (ZWCAD e AutoCAD) **0 avisos**. O painel `scripts/cobertura-do-reverso.ps1` mede **69 escritos à mão** (49 do reverso + 20 nossos) e **68** do reverso sem nada no plugin (51 de regra pura).

**Rodada 146 — o `EncontraHandle` (frente 2, 37 de 38) e a correção do `AtivaPagina` da rodada 145.** Duas coisas, nesta ordem: a fila do `PLANO.md` mudou e o comando do original expôs um defeito na regra que ele reaproveita.

**A fila.** O item 1 ("fechar a frente 10 com o caderno: `GERDWG`/`DUPCAD`") partia de uma **premissa errada**: lidas no reverso, `frmGerenciadorDWG` e `frmDuplicarCaderno` **não** mexem nas páginas do desenho. Elas mantêm o **cadastro de DWGs do banco** (tabelas `DWG`/`DWGH`: adicionar, atualizar, apagar, restaurar, atribuir índice), e o `DUPCAD` ainda faz o `SaveAs` do arquivo e copia sete tabelas compiladas (`Fiacao`, `Contatos4F`, `Circuitos4F`, `Portas4F`, `Dispositivos4F`, `Bornes4F`, `Jumpers`) mais os avulsos da lista de materiais. No recoder ninguém grava `DWG`/`DWGH` (o índice vem do `POSITRON_DWG`) e o `POSITRON.md` registra essas tabelas como do **app**. Decisão do dono: o cadastro de DWGs vira item próprio, aguardando a decisão de quem é dono dele, e a fatia 6 da frente 10 fecha com a paleta das folhas.

**O comando.** O `EncontraHandle` do original (`clsUtilitarios.cs:950`) pede um handle (`Digite Um Handle`), acha a entidade (`Geral.HandleToObject`), chama `Pagina.AtivaPagina(entidade.Layer)`, sincroniza a paleta (`_uscPagina.ativaPaginaAtalho`) e dá zoom com margem 20 (`Caderno.ZEntity` → `ZoomWin`). O que é puro entrou em `Positron.Data/Paginas/LocalizacaoPorHandle.cs`: o `LerHandle` (o `Convert.ToInt64(s, 16)`, que aceita `0x`; vazio ou inválido devolve nulo — **desvio:** o texto é aparado antes) e a `Janela` do zoom (a caixa com a margem nos quatro lados; centro, largura e altura). O adapter `Positron.Plugin/Paginas/LocalizacaoPorHandleDoDesenho.cs` pergunta pelo prompt do original, acha a entidade (`TryGetObjectId`, que recusa o apagado) e aplica a vista com um `ViewTableRecord` novo, como o `ZoomWin`. O comando entra com o **nome do original** (`EncontraHandle`); o handle vem de `POSITRON_HANDLE` ou do prompt — o script passa o valor ao prompt pelo `vl-cmdf`. A paleta ganhou `PaletaDeFolhas.Recarregar()` (só relê quando já foi aberta), chamada também pelo `ATIVAPAGINA`.

**O defeito da rodada 145.** O `AtivaPagina` do original mantém ligados a página, o `0` e o `right = checaCapa(pagina) ? pagina : "-1"` (`Pagina.cs:1279`) — ou seja, o **`-1`** (o formato do corpo; o `Pagina.cs:1051` o trata junto com a capa) quando a página não é a capa, e **desliga a capa**. A rodada 145 tinha portado o contrário (capa sempre ligada, `-1` desligado) e a medição dela registrou esse comportamento errado (`1 LIGADO`, `-1 DESLIGADO` ao ativar a `3`). O `PapelDoLayerNaAtivacao` passou a ser `Pagina`/`Mantido`/`Fora` e o `Papel(layer, pagina)` reproduz o `right` do original; o `PaginaAtivaTests` ganhou os dois casos (página do corpo e capa). A fixture `cad-fixture-pagina-ativa.lsp` dizia que o `-1` era "a camada de trabalho do produto" — corrigido para o formato do corpo.

**Host desta máquina (verificado em 2026-10-16, rodadas 212–213).** O **AutoCAD 2020 está instalado** (`C:\Program Files\Autodesk\AutoCAD 2020`, `acad.exe` + `accoreconsole.exe`; o registro traz "Autodesk AutoCAD 2020 - English") — a redação anterior desta linha dizia que ele "não está mais instalado" e **estava errada**. O **ZWCAD não está** nesta máquina nesta data (nem `C:\Program Files\ZWSOFT`, nem chave `ZWSOFT` no registro, nem `ZWCAD*.exe` em `C:\`/`D:\`); a rodada 211 mediu nele quando ele estava. **Nunca afirme que um CAD não existe sem medir** — a receita está em *Troubleshooting* → *Existe CAD nesta máquina?*. Para os argumentos com espaço, chame o script **na mesma sessão** (`& .\scripts\cad-zwcad-smoke.ps1 -Comandos $cmds`): repassados a um `powershell -File` filho, eles se quebram.

```powershell
$env:POSITRON_DUMP = "<pasta>\ativa"; $env:POSITRON_PAGINA = "3"
$cmds = @('(pz-conta-camadas "1")','(vl-cmdf "_EncontraHandle" (pz-handle-do-texto "folha 2"))','(pz-conta-camadas "2")',
  '(vl-cmdf "_EncontraHandle" (pz-handle-do-texto "capa"))','(pz-conta-camadas "3")','(vl-cmdf "_EncontraHandle" "ZZZ")',
  '(vl-cmdf "_EncontraHandle" "FFFFFF")','(vl-cmdf "_ATIVAPAGINA")','(pz-conta-camadas "4")')
& .\scripts\cad-zwcad-smoke.ps1 -Fixture scripts/cad-fixture-pagina-ativa.lsp -Comandos $cmds -Banco "<pasta>\r146.db"
```

Medido no **ZWCAD 2026**:

```text
EncontraHandle: 264 = DBText no layer "2" — página ativada (2 layer(s) desligado(s), 3 ligado(s), 2 alterado(s)); zoom em (15.243; 11.251) 50.486 x 42.584.
EncontraHandle: 263 = DBText no layer "1" — página ativada (3 layer(s) desligado(s), 2 ligado(s), 3 alterado(s)); zoom em (13.787; 10.579) 47.573 x 42.546.
EncontraHandle: "ZZZ" não é um handle (hexadecimal).
EncontraHandle: handle FFFFFF não achado no desenho (ou não é entidade).
ATIVAPAGINA: pagina "3" — 2 layer(s) desligado(s), 3 ligado(s), 3 alterado(s); capa "1".

--- dump independente (pz-conta-camadas: CLAYER, VIEWCTR/VIEWSIZE e o 62 de cada layer) ---
ativa1  CORRENTE;3 · VISTA;493.605;398.976;481.652 · 0 LIGADO · 1 LIGADO · 2 LIGADO · 3 LIGADO · -1 LIGADO
ativa2  CORRENTE;2 · VISTA;15.243;11.251;42.696   · 0 LIGADO · 1 DESLIGADO · 2 LIGADO · 3 DESLIGADO · -1 LIGADO
ativa3  CORRENTE;1 · VISTA;13.787;10.579;42.658   · 0 LIGADO · 1 LIGADO · 2 DESLIGADO · 3 DESLIGADO · -1 DESLIGADO
ativa4  CORRENTE;3 · VISTA;13.787;10.579;42.658   · 0 LIGADO · 1 DESLIGADO · 2 DESLIGADO · 3 LIGADO · -1 LIGADO
```

Na página `2` ficam o `0` e o `-1` e a capa desliga; na capa só o `0` e a capa ficam ligados e o `-1` desliga; o `ATIVAPAGINA` na `3` agora segue a mesma regra (a medição da rodada 145 mostrava `1 LIGADO`/`-1 DESLIGADO`). O centro da vista medido é o que o comando calculou; o `VIEWSIZE` sai um pouco acima da altura pedida (42,70 contra 42,58) porque o CAD ajusta a vista à proporção da janela. Os dois handles inválidos (`ZZZ` e um inexistente) não mexem no desenho: o `ativa4` só difere do `ativa3` pelo `ATIVAPAGINA`.

**Gate desta rodada:** `plugin:test` **685** (+13: `LocalizacaoPorHandleTests` com 12 casos e +1 no `PaginaAtivaTests`) e as duas builds (ZWCAD e AutoCAD) **0 avisos**. O painel `scripts/cobertura-do-reverso.ps1` mede **67 escritos à mão** (48 do reverso + 19 nossos) e **69** do reverso sem nada no plugin (52 de regra pura).

**Rodada 145 — a página ativa e o passo da página (fatia 5, parte 2): a regra, os comandos e os formulários.** O `Pagina.cs` do original ainda guardava quatro rotinas: o `AtivaPagina` (linha 1243), o `LocalizaPaginaAtiva` (1347), o `checaCapa` (2595) e o `redefinePasso` (2657) — com os comandos `PAS` (`Comandos.cs:1435`) e `PAG` (`:1447`). O que é **puro** entrou em `cad-plugin/Positron.Data/Paginas/PaginaAtiva.cs`: o `PapelDoLayerNaAtivacao` (`Pagina`, `Capa`, `Fora`), o `PaginaAtiva.Capas` com a **lista literal** do `checaCapa` (`"1"`, `"001"`, `"0001"`, `"00001"`, `"000001"`, `"0000001"`), o `ChecaCapa` (sem caixa), o `Localiza(layerCorrente)` (a camada corrente quando ela passa no `LayerValido`; senão vazio, o que no original cai no `retornaNumeroCapa`), o `Papel(layer, pagina, capas)` e o `Plano(pagina, layers)`. **Limite do original registrado:** a lista de capas tem **seis** nomes e para no de **sete** posições (`'0000001'`); o `'00000001'` (oito posições) **não** é capa — é o `checaCapa` que é assim, e a lista está fixada em teste.

**Onde a ação entra (`cad-plugin/Positron.Plugin/`).** O adapter `Paginas/PaginaAtivaDoDesenho.cs` faz o `Ler()` (a página ativa é a `Clayer`), o `LerCapa()` (o `retornaNumeroCapa`) e o `Ativar(pagina)`, que devolve o `Resultado` (`PaginaEncontrada`, `LayersAlterados`, `LayersDesligados`, `LayersLigados`, `Capa`): ele reproduz o `IsOff` do original — a página fica **ligada** e vira a **camada corrente**, o layer `0` e a **capa** ficam ligados e **todo o resto desliga** —, e o `LayersAlterados` conta só o que **mudou** de estado. Em `Comandos.cs` entraram dois comandos **nossos** (no original o caminho é item de menu/interação, como no `UNIDADE`/`TITULOS`): **`ATIVAPAGINA`** usa o alvo de `POSITRON_PAGINA`; sem a variável, usa a **página ativa** do desenho e, sem ela, a última do caderno — o alvo **explícito** passa pela guarda `ExclusaoDePagina.Recusa` (nome vazio, layer que o `LayerValido` recusa e página fora do caderno); e **`PASSO`** é o `redefinePasso`: o valor vem do argumento ou de `POSITRON_PASSO_PAGINA` (sem nenhum dos dois o comando **só lê**), recusa o que não é **inteiro > 0** (a guarda `AllowNegative=false`/`AllowZero=false` do original) e persiste com `ConfiguracaoPositron.Salvar()` — o original pergunta pelo `Editor` e grava o **XData de configuração do desenho**, uma divergência de instrumento registrada.

**A tela (`cad-plugin/Positron.Plugin/Interface/Folhas/`).** O `FolhasControle` ganhou o campo/linha **'Página ativa: X'** no rodapé, a coluna técnica **`PgAtiva`** na grade (a linha da página ativa sai em **negrito**) e o `Load` do controle passou a ler a página ativa; os itens **Editar Unidade / Editar Alternativo / Editar Títulos** do menu do `cmStrip1`, que estavam desabilitados, agora abrem formulários e regravam pela regra já portada (rodadas 142/144) — o arquivo novo é `Interface/Folhas/FormularioDaPagina.cs` (`FormularioDeCampoDaPagina`, um campo, e `FormularioDeTitulosDaPagina`, os quatro títulos). O item **Editar Revisões** continua desabilitado, agora com o motivo **'regra não portada (as revisões do projeto vivem no banco, não no desenho)'**.

**Receita e medição.** A fixture `scripts/cad-fixture-pagina-ativa.lsp` monta as páginas `1..3`, a capa `1` com um texto 'capa', um texto em cada página e um texto no layer de trabalho `-1`; o instrumento independente `pz-conta-camadas <sufixo>` grava `CORRENTE;<layer>`, `LAYER;<nome>;LIGADO|DESLIGADO` (o sinal do código 62) e `TEXTO;<layer>;<texto>` num arquivo por passo (`POSITRON_DUMP` + sufixo):

```bash
$env:POSITRON_DUMP = "<pasta>\ativa"; $env:POSITRON_PAGINA = "3"; $env:POSITRON_PASSO_PAGINA = "5"
powershell -ExecutionPolicy Bypass -File scripts/cad-autocad-smoke.ps1 -Fixture scripts/cad-fixture-pagina-ativa.lsp \
  -Comandos '(pz-conta-camadas "1")','(vl-cmdf "_ATIVAPAGINA")','(pz-conta-camadas "2")','(vl-cmdf "_PASSO")','(pz-conta-camadas "3")','(vl-cmdf "_PASSO")','(pz-conta-camadas "4")' -Dwg 63 -Banco "<db>"
```

Medido no AutoCAD 2020 (accoreconsole, headless):

```text
ATIVAPAGINA: pagina "3" — 2 layer(s) desligado(s), 3 ligado(s), 2 alterado(s); capa "1".
PASSO: passo do caderno = 5 — regravado para 5.
PASSO: passo do caderno = 5 — regravado para 5.

--- dump independente, ANTES (ativa1) ---
CORRENTE;3 · 0 LIGADO · 1 LIGADO · 2 LIGADO · 3 LIGADO · -1 LIGADO
--- dump independente, DEPOIS (ativa2) ---
CORRENTE;3 · 0 LIGADO · 1 LIGADO · 2 DESLIGADO · 3 LIGADO · -1 DESLIGADO
```

O `2` e o `-1` **desligaram**; a **capa** `1`, o `0` e a página `3` ficaram **ligados**, e a corrente já era `3` e continuou `3`. Os textos das **quatro** camadas continuam no desenho — a ativação **desliga o layer, não apaga nada**.

A **segunda** medição usa a **página ativa** do desenho como alvo (sem `POSITRON_PAGINA`), e o `PASSO` lê e grava:

```text
PASSO: passo do caderno = 3 — regravado para 3.
ATIVAPAGINA: pagina "3" — 2 layer(s) desligado(s), 3 ligado(s), 2 alterado(s); capa "1".
PASSO: passo do caderno = 3 — regravado para 3.
```

A **terceira** mede a **guarda** do alvo explícito torto (`POSITRON_PAGINA=TRABALHO`), com o dump antes/depois **idêntico** (todos os layers `LIGADO` — o desenho não foi tocado):

```text
ATIVAPAGINA: "TRABALHO" não é um layer de página (o LayerValido recusa).
```

**Achado de instrumento (não é regressão do recoder).** Nesta máquina o `NETLOAD` morria com `FileLoadException`/`NotSupportedException` (**'assembly from a network location'** — a árvore do repo cai no `loadFromRemoteSources`) e a suíte via `npm run plugin:test`/`dotnet test` roda **0 testes** no SDK .NET 10 preview instalado (o adaptador xunit não carrega). O contorno: (a) o `scripts/cad-autocad-smoke.ps1` ganhou o parâmetro `-PastaLocal` (padrão `C:\positron-smoke\cad`), que **copia** a DLL e as dependências para fora da árvore antes do `NETLOAD`; (b) os testes foram rodados por um **runner xunit local fora do repo**, com os mesmos **660** testes da linha de base verdes antes da rodada.

**Gate desta rodada:** `plugin:test` **672** (+12, `PaginaAtivaTests`, 6 métodos, um deles um Theory de 6 casos) e as duas builds (ZWCAD e AutoCAD) **0 avisos**. O painel `scripts/cobertura-do-reverso.ps1` mediu **66 escritos à mão** (47 do reverso + **19 nossos**; eram **64** no estado da rodada 144 — os dois comandos novos), com os **99 gerados** e os **70** do reverso sem nada no plugin **inalterados**; nas **telas** nada mudou (as **5** com regra seguem as mesmas e a fila "a regra existe, falta a ligação" continua **vazia**).

**Rodada 144 — a unidade e o alternativo da pagina (fatia 5, parte 1).** O XData `Eletron` do
`LayerTableRecord` (o `LeXDataUnidadeAlternativo`/`GravarXDataUnidadeAlternativo`) virou regra pura
(`UnidadeDaPaginaXData`) + adapter (`UnidadeDaPaginaDoDesenho`), o comando **UNIDADE** (nosso, como o
TITULOS: pagina de POSITRON_PAGINA, padrao a ultima; grava com POSITRON_UNIDADE/POSITRON_ALTERNATIVO)
e a grade das folhas passou a mostrar as colunas alternativo/unidade.

```bash
$env:POSITRON_PAGINA = "3"; $env:POSITRON_UNIDADE = "U1"; $env:POSITRON_ALTERNATIVO = "A1"
powershell -ExecutionPolicy Bypass -File scripts/cad-autocad-smoke.ps1 -Fixture scripts/cad-fixture-novapagina.lsp `
  -Comandos UNIDADE,UNIDADE,pz-conta-paginas -Dwg 63 -Banco "<db>"
```

Medido no AutoCAD 2020 (a segunda passada le de volta o que a primeira gravou):

```text
UNIDADE: pagina "3" — unidade="", alternativo="" — regravado para unidade="U1", alternativo="A1".
UNIDADE: pagina "3" — unidade="U1", alternativo="A1" — regravado para unidade="U1", alternativo="A1".
UNIDADE;3;U1;A1        <- o dump independente do fixture (le o XData do layer)
```

**Gate:** `plugin:test` **660** (+2, `UnidadeDaPaginaTests`), as duas builds 0 avisos e o E2E verde.

**Rodada 143 — o Excluir Paginas (o destrutivo, com o ok do dono).** O item do menu das folhas
estava desabilitado desde a rodada 130 ("regra na fatia 4 da frente 10 (e destrutiva)"); o dono
liberou e ele entrou: o clique apaga as paginas **selecionadas na grade** (a grade e full-row-select
e multi-select, como no original) e o comando **APAGAPAGINA** faz o mesmo por script, **exigindo**
POSITRON_PAGINA — destrutivo nao adivinha alvo.

**O que apaga:** o `Pagina.ApagarElementosPagina` do original apaga **toda** entidade do ModelSpace
com o layer da pagina (com o `clsApagar.ApagarDerivados` antes de cada uma) e deixa o **layer**; o
recoder apaga o layer tambem — sem o layer a pagina sai da lista do caderno, e deixar um layer vazio
seria uma pagina fantasma (diferenca registrada). O `ApagarDerivados` (os textos derivados do
borne/dispositivo) nao entrou: o recoder nao mantem esse estado, entao nao ha derivado a limpar.

**A guarda e pura** (`Positron.Data/Paginas/ExclusaoDePagina.cs`): nome vazio, layer que nao passa
no `LayerValido` (o mesmo crivo que le o caderno) e pagina fora da lista sao **recusados** — e o que
impede um POSITRON_PAGINA torto de apagar os elementos de outra camada.

```bash
$env:POSITRON_DUMP = "$env:TEMP/positron-paginas.txt"; $env:POSITRON_PAGINA = "3"
powershell -ExecutionPolicy Bypass -File scripts/cad-autocad-smoke.ps1 `
  -Fixture scripts/cad-fixture-novapagina.lsp -Comandos NOVAPAGINA,APAGAPAGINA,pz-conta-paginas -Dwg 63 -Banco "<db>"
```

Medido no AutoCAD 2020:

```text
NOVAPAGINA: página "4" criada depois de "3" — layer + 5 campo(s) do formato copiado(s) + 3 título(s) herdado(s) de "3".
APAGAPAGINA: 1 página(s) apagada(s) (3) — 4 entidade(s) do ModelSpace e 1 layer(s).

--- dump independente ---
LAYER;0  LAYER;1  LAYER;2  LAYER;-1  LAYER;4        <- o layer 3 saiu
textos na pagina 3: 0                              <- os 4 titulos dela foram apagados
textos na pagina 4: 5                              <- a pagina 4 (a nova) ficou intacta
```

**Licao de instrumento:** a fixture roda num desenho **vazio** (sem -Desenho), entao as paginas sao
só as que ela cria (1..3): foi isso que fez a medicao dizer "depois de 3" enquanto o desenho real
tem a pagina 1000. Nao e defeito — e o ambiente da fixture, e agora esta registrado.

**Gate desta rodada:** `plugin:test` **658** (+5, `ExclusaoDePaginaTests`), as duas builds **0
avisos / 0 erros** e o `cad:projeto:acad -Idempotencia` verde com os numeros de sempre.

**Rodada 142 — os titulos da pagina (o fim da fatia 6): ler e gravar, e a heranca no Nova Pagina.**
O `capturaTitulosDeUmaPagina` (ler) e o `AtualizaTitulosDeUmaPagina` (regravar) do original entraram:
o que e **puro** e o modelo `TitulosDaPagina` (os quatro titulos, o **indice 1..4** como chave e o
contador que para nos quatro) e o **leitor do XData** (`TituloDaPaginaXData.Ler` — app `DiagLog`,
marca `TituloPagina`); o adapter `TitulosDaPaginaDoDesenho` varre o ModelSpace pelo **layer da
pagina**, como o original. **Dois detalhes do original reproduzidos:** quem identifica um titulo e o
**indice do XData**, nao a tag do atributo (o `TITULO4PAG` e o `PAINEL` do formato tem o **mesmo
indice 4**, entao os dois recebem o `Titulo4`); e a gravacao conta **por texto tocado** (para nos
quatro), como o `num++` do `switch` dele.

**Onde entrou:** o `NOVAPAGINA` passou a **herdar os titulos** da pagina de referencia — o
`pagCorrente.Titulo1..4 = pag.Titulo1..4` + `AtualizaTitulosDeUmaPagina(pagCorrente)` do
`criarUmaNovaPagina` — e entrou o comando **`TITULOS`** (nosso, como o `NOVAPAGINA`): ele **le** os
titulos da pagina de `POSITRON_PAGINA` (padrao: a ultima do caderno) e **regrava** quando alguma
`POSITRON_TITULO1..4` vem definida — a convencao do recoder para os dialogos do original (o form de
edicao dos titulos, no original, fica para a rodada que montar a tela).

**Receita (a fixture planta os quatro titulos na pagina 3):**

```bash
$env:POSITRON_DUMP = "$env:TEMP/positron-paginas.txt"
$env:POSITRON_PAGINA = "4"; $env:POSITRON_TITULO1 = "Z1"
powershell -ExecutionPolicy Bypass -File scripts/cad-autocad-smoke.ps1 \
  -Fixture scripts/cad-fixture-novapagina.lsp -Comandos NOVAPAGINA,TITULOS,pz-conta-paginas -Dwg 63 -Banco "<db>"
```

Medido no AutoCAD 2020:

```text
NOVAPAGINA: página "4" criada depois de "3" — layer + 5 campo(s) do formato copiado(s) + 3 título(s) herdado(s) de "3".
TITULOS: página "4" — T1="T1", T2="T2", T3="", T4="T4"; 3 campo(s) regravado(s).

--- dump independente (pagina 4) ---
TEXTO;4;?;TituloPagina;5      <- CONT (indefinido)
TEXTO;4;?;TituloPagina;6      <- FL (indefinido)
TEXTO;4;T4;TituloPagina;4     <- PAINEL/TITULO4PAG: herdou o Titulo4
TEXTO;4;T2;TituloPagina;2     <- TITULO2PAG: herdou o Titulo2
TEXTO;4;Z1;TituloPagina;1     <- TITULO1PAG: o POSITRON_TITULO1=Z1 regravou
```

O indice **3** nao aparece porque o formato da fixture nao trouxe o `TITULO3PAG` — a pagina nova so
recebe os campos que o bloco de formato define, e a heranca escreve nos que existem. O `T3` da
pagina 3 fica la (a leitura devolve `T3=""` na pagina 4, como o comando imprime).

**Licao de instrumento:** a primeira medicao deu "4 campo(s)" e nenhum campo de indice 2 porque a
fixture criava um bloco chamado `FORMATO` — e o **desenho real ja tem** um bloco com esse nome, entao
o `(if (not (tblsearch ...)))` pulava a definicao e o INSERT usava o bloco do desenho. O bloco da
fixture passou a se chamar **`PZ-FORMATO`** (o `EncontrarFormato` procura o **XData**, nao o nome).
Um `-replace` global de "FORMATO" por "PZ-FORMATO" chegou a renomear a **marca do XData** ("Formato")
e quebrou o `PossuiXDataFormato` — a licao: o nome do bloco e o valor do XData sao coisas diferentes.

**Gate desta rodada:** `plugin:test` **653** (+5, `TitulosDaPaginaTests`), as duas builds **0 avisos /
0 erros** e o `cad:projeto:acad -Idempotencia` verde com os numeros de sempre.

**Rodada 141 — a fatia 6: o "Nova Página" cria a pagina de verdade (o layer e os campos do formato).**
O item 3 da fila do `AUDITORIA.md` §0 saiu dela. No original quem cria a pagina e o
`Pagina.criarUmaNovaPagina`: calcula a pagina (`calculaNovaPagina`, portado desde a rodada 126 como
`NovaPaginaEntre`), cria o **layer** (`CriarLayer` + o XData `Eletron` de unidade/alternativo) e
**copia os campos do formato** (`criaCamposFormato`). O recoder so calculava; agora cria.

**O que e puro (`Positron.Data/Paginas/`):**

- `CriacaoDePagina.Normalizar` e o `montaNumeroPagina` do original: os zeros a esquerda **sempre**
  saem e, com a **largura fixa** ligada, o nome e completado com zeros — incluindo o detalhe do
  original que soma **um** zero a mais quando o nome nao e numerico (o `num++` do ramo
  `Not IsNumeric`). A largura fixa entrou na configuracao (`larguraFixaPaginas` /
  `POSITRON_LARGURA_FIXA_PAGINAS`, padrao 0 = desligada);
- `CriacaoDePagina.CampoDoFormato.De` e o mapa do `criaCamposFormato`: dos atributos **protegidos**
  do bloco de formato, **oito** viram campo da pagina nova — `TITULO1PAG`/`2PAG`/`3PAG`/`4PAG`
  (indices 1..4), `PAINEL` (4), `REV` (8), `ALTERNATIVO` (9), `CONT` (5) e `FL` (6) —, com o
  texto `" "` ou `"?` (so o CONT e o FL nascem com `"?"`). As outras tags protegidas (`SECAO`,
  `REV0..7`, `DESC*`, `DATA*`, `ELAB*`, `VERIF*`, `APROV*`, `TOT`) entram no laco do original e
  **nao geram campo nenhum** — o if/else dele so trata as oito;
- `TituloDaPaginaXData` e o `gravarXDataTitulo`: app `DiagLog`, marca `TituloPagina`, o indice do
  titulo e o valor (10 valores, usuario/data recarimbados).

**O que grava (`Positron.Plugin/Paginas/CriacaoDePaginaDoDesenho.cs`):** o **bloco de formato** e um
`BlockReference` do ModelSpace com o XData `DiagLog`/`Formato` (o `PossuiXDataFormato`) — os
atributos dele na camada `-1` sao o modelo. A pagina nova ganha o layer (com o XData de
unidade/alternativo) e, para cada atributo mapeado, um `DBText` clonado (o `dtepniSZGL6`: mesma
posicao, altura, estilo, rotacao...) com o XData do titulo. **Correcao de premissa:** a fila dizia
"extrair o `MascaraM.dwg` do DLL e criar a folha com o formato" — o `MascaraM.dwg` e o bloco da
**mascara** (o `clsMascara` o insere com o jig), **nao** o formato; o formato e o bloco do desenho.
Sem bloco de formato a pagina nasce **so com o layer**, e o resumo diz isso.

**Onde a acao entra:** o comando **`NOVAPAGINA`** (nosso — no original o caminho e o item de menu)
cria a pagina **depois da ultima**; o `Inserir` do menu das folhas agora **cria** entre a
selecionada e a proxima (antes so mostrava a conta) e o item **Nova Página**, que estava desabilitado
com o motivo da fatia 6, esta **ligado**.

**Receita e medicao.** A fixture `scripts/cad-fixture-novapagina.lsp` monta as paginas 1..3 e um
bloco `FORMATO` com cinco ATTDEFs na camada `-1` (`TITULO1PAG`, `PAINEL`, `FL`, `CONT` e `SECAO`
— o ultimo para provar que **nao** entra) e o instrumento independente `c:pz-conta-paginas` (leitura
crua dos layers e dos textos com o XData):

```bash
$env:POSITRON_DUMP = "$env:TEMP/positron-paginas.txt"
powershell -ExecutionPolicy Bypass -File scripts/cad-autocad-smoke.ps1 \
  -Fixture scripts/cad-fixture-novapagina.lsp -Comandos NOVAPAGINA,pz-conta-paginas -Dwg 63 -Banco "<db>"
```

Medido no AutoCAD 2020:

```text
NOVAPAGINA: página "4" criada depois de "3" — layer + 4 campo(s) do formato copiado(s).

--- dump independente ---
LAYER;1  LAYER;2  LAYER;3  LAYER;-1  LAYER;4
TEXTO;4;?;TituloPagina;5      <- CONT
TEXTO;4;?;TituloPagina;6      <- FL
TEXTO;4; ;TituloPagina;4      <- PAINEL
TEXTO;4; ;TituloPagina;1      <- TITULO1PAG
```

Os quatro campos e os **indices** (1, 4, 5, 6) sao a prova de que o mapa do `criaCamposFormato` esta
certo; o `SECAO` nao aparece. No **desenho real** (`Funcional.dwg`, cuja copia **tem** bloco de
formato) o comando criou a pagina **1001** (depois de 1000, a ultima pela ordem decimal) com **5
campos** — a leitura do bloco de formato funciona no desenho do produto.

**Licao de instrumento (a fixture mentiu primeiro):** o `entmake` de um `INSERT` **nao** cria as
`AttributeReference` dos ATTDEFs do bloco — sem o `66 .= 1` e os `ATTRIB` seguidos do `SEQEND` o
INSERT nasce sem atributo nenhum (foi o que deu "0 campo(s)" na primeira medicao) e o `entmod` do
XData depois do `SEQEND` nao pegava o `-3`; o XData entrou no proprio `entmake`. Esta no fixture,
comentado.

**Gate desta rodada:** `plugin:test` **648** (+26, `CriacaoDePaginaTests` — o normalizar com e sem
largura fixa, o mapa das oito tags e a recusa das outras, e o layout do XData do titulo), as duas
builds **0 avisos / 0 erros** e o `cad:projeto:acad -Idempotencia` verde com os numeros de sempre
(`FIA` 494, `INT` 20, `VERIF` 249 na linha de base, hash `7c1635f0…`).

**Rodada 140 — as tres telas de compilacao ligadas aos pipelines (frmCompilarFiacao/Interligacao/JumperExt).**
O item 2 da fila do `AUDITORIA.md` §0 — e o **ultimo** da lista "a regra existe, falta a ligacao" —
saiu dela. As tres telas do original (`frmCompilarFiacao`, `frmCompilarInterligacao`,
`frmCompilarJumperExt`) tem a mesma casca e a regra de cada uma **ja existia** (os pipelines `FIA`,
`INT` e `JMP`), entao a ligacao ficou numa **base** (`Interface/Telas/LigacaoDeCompilacao.cs`) com um
arquivo fino por tela — o metodo do §7.9: **um arquivo + uma linha** no `LigacoesDasTelas` (2 -> 5).

**O que cada tela liga:**

- `btAnalisar` roda o pipeline da tela com a **revisao do campo `tbRevisao`** (o campo abre com a da
  configuracao; o executor ganhou o parametro opcional: `ExecutarFiacao(revisao)`,
  `ExecutarInterligacao(revisao)`, `ExecutarJumper(revisao)` — sem argumento, o caminho de sempre, a
  revisao da configuracao);
- `dgERROS` abre com os **problemas da revisao**, um por linha — a mesma lista de
  `Comandos.VerificarRevisao` que o `VERIF` e o `ELETREL` usam (o metodo passou de `private` a
  `internal` para a tela poder chama-lo). **Diferenca registrada:** o original so preenche a grade
  depois do Analisar e com as **paginas** onde ele desenhou um bloco `ErroFiacao`; o recoder nao
  desenha erro no desenho, entao mostra o problema;
- `dgRevisao` abre com as revisoes que **ja tem compilacao no banco** para o DWG ativo
  (`ProjectStore.LerRevisoes`, novo: as tres tabelas dos pipelines unidas, uma linha por revisao com
  o carimbo mais recente). As colunas do mapa sao (Revisao, Data, Criador) e o original **adiciona**
  `(revisao, criador, data)` — aqui cada valor vai para a coluna do seu nome.

**O que entra desabilitado, com o motivo na dica** (o padrao do menu das folhas — `Enabled = false` e
a razao no `ToolTip`): `btSalvar` (o recoder grava na **mesma passada** do Analisar; o original
separa analisar de salvar), `btApagar` (destrutivo: apaga a compilacao da revisao em
`Interligacao4`/`Portas4I`/`Bornes4I`/`Cabos4`/`Veias4`) e `btApagarComp` (o original **desenha**
blocos `ErroFiacao` no desenho e este botao os apaga).

**Receita (as duas medidas):**

```bash
# 1) as ligacoes montam com as 127 telas (o pzTelas chama o LigacoesDasTelas.Preencher de cada uma)
powershell -ExecutionPolicy Bypass -File scripts/cad-autocad-smoke.ps1 -Comandos pzTelas \
  -Desenho cad-plugin/reverso/Teste_projeto_real/Funcional.dwg -Dwg 63 -Revisao R0 -Banco "<db do projeto>"

# 2) o Analisar de uma tela: o script nao clica, entao o gancho roda a MESMA analise ao montar a tela
$env:POSITRON_JANELA = "frmCompilarInterligacao"; $env:POSITRON_ANALISAR = "1"
powershell -ExecutionPolicy Bypass -File scripts/cad-autocad-smoke.ps1 -Comandos JANELA \
  -Desenho cad-plugin/reverso/Teste_projeto_real/Funcional.dwg -Dwg 63 -Revisao R0 -Banco "<db do projeto>"
```

Medido no AutoCAD 2020 (a grade de erros com o **mesmo 249** do `VERIF`, e o Analisar rodando o
pipeline do comando):

```text
COMPILAR: frmCompilarInterligacao — Analisar ligado no INT (revisão "R0"); 1 revisão(ões) na grade; 249 problema(s) na grade de erros; desabilitados: Salvar, Apagar e ApagarComp.
COMPILAR: frmCompilarJumperExt — Analisar ligado no JMP (revisão "R0"); 1 revisão(ões) na grade; 249 problema(s) na grade de erros; ...
COMPILAR: frmCompilarFiacao — Analisar ligado no FIA (revisão "R0"); 1 revisão(ões) na grade; 249 problema(s) na grade de erros; ...
JANELAS: 127 de 127 tela(s) do reverso montada(s), nenhuma falha. Ligacoes: 5 de 127 tela(s) com regra (frmPesquisaXdatas, frmEstatisticaDeBornes, frmCompilarFiacao, frmCompilarInterligacao, frmCompilarJumperExt).

--- e, com POSITRON_ANALISAR=1 (o clique do btAnalisar) ---
COMPILAR: frmCompilarInterligacao — ...
INT: 20 linha(s) gravada(s) em Interligacao4 (199 borne(s)); 265 porta(s) em Portas4I; 216 borne(s) em Bornes4I; 697 cabo(s) em Cabos4; 2388 veia(s) em Veias4.
COMPILAR: frmCompilarFiacao — ...
FIA: 494 linha(s) em Fiacao (199 borne(s), 191 dispositivo(s), 0 reordenada(s), 83 posicao(oes), 450 ponto(s) de bloco); ...
COMPILAR: frmCompilarJumperExt — ...
JMP: nenhuma conexão de jumper no desenho.
```

**Achado de instrumento: no `accoreconsole` o `JANELA` nao retorna.** A linha do proprio comando
(`JANELA: "..." aberta no CAD`) **nao sai** e o comando seguinte ao `JANELA` **nao roda**: a janela
modeless prende o script. Medido tambem numa tela **sem** ligacao (`frmConfiguracaoGeral`), entao
**nao** e regressao desta rodada — e por isso a receita poe o `JANELA` **por ultimo** (a ligacao,
que acontece no `Montar`, roda antes) e a varredura das ligacoes e pelo `pzTelas`, que monta sem
mostrar.

**A tela `frmEstatisticaDeCabos` (`ESTVCABOS`) medida num script (rodada 217).** O gancho e
`POSITRON_ESTATISTICA=<formacao|funcao|trajeto>`: ao montar a tela ele marca o radio e escreve a grade
na linha de comando (como o `POSITRON_ANALISAR` das telas de compilacao). Banco de teste com Cabos e
Veias (`Uso`) — a receita:

```bash
POSITRON_ESTATISTICA=formacao powershell -ExecutionPolicy Bypass -File scripts/cad-autocad-smoke.ps1 \
  -Comandos "ESTVCABOS" -Desenho cad-plugin/reverso/Teste_projeto_real/Funcional.dwg \
  -Dwg 63 -Revisao R0 -Banco ".tmp-smoke/r217-estcabos.db"
# -> ESTCABOS: Formação — 2 linha(s); habilitados: Formação, Função, Trajeto; grade: 2x4=1/4 | 3x2,5=2/15
```

O radio desabilitado sai na mesma linha (`habilitados:`), entao a regra do construtor
(`lista.Count > 0`) e medida junto. Medido no **AutoCAD 2020** em 2026-10-16.

**O Excel ativo da estatistica (`btExportaEXCEL` do `ESTVCABOS`, rodada 218 medida em 2026-10-16).**
O gancho e `POSITRON_ESTATISTICA_EXCEL=exportar` (roda a **mesma acao** que o `Click` do botao; o
clique fisico fica para o dono, porque a ligacao roda ainda montando a tela). Ele usa o Excel
**aberto e visivel** (as mesmas tres regras da ponte dos titulos acima) e escreve na aba
**nomeada** `DIF_FORMACAO`/`DIF_FUNCAO`/`DIF_TRAJETO` — nunca na ativa:

```bash
POSITRON_ESTATISTICA=formacao POSITRON_ESTATISTICA_EXCEL=exportar \
  powershell -ExecutionPolicy Bypass -File scripts/cad-autocad-smoke.ps1 -Comandos "ESTVCABOS" \
  -Desenho cad-plugin/reverso/Teste_projeto_real/Funcional.dwg -Dwg 63 -Revisao R0 \
  -Banco ".tmp-smoke/r217-estcabos.db"
# -> EXCEL: 2 linha(s) da estatística de cabos na aba DIF_FORMACAO (Formação).
```

O que a medicao le de volta (por COM, com o Excel ainda aberto): o **nome da aba** e a posicao dela
(a nova vai **depois da ultima**), o `A1`/`B1`/`C1` (`#Cabos | Formação | Comprimento` — sem o
apostrofo, que o Excel consome como prefixo de texto), as larguras `12/40/15`, o **negrito**, o
`ApagaFigura` (ponha uma imagem na aba antes: `$aba.Pictures().Insert(<png>)` e conte depois) e a
limpeza (`A1:Z10000`). Dois achados de instrumento:

- a faixa dos dados quando a grade esta **vazia** sai invertida (`A2:C1`) e o Excel a normaliza para
  `A1:C2` — o `A2` fica vazio e a borda aparece no chao da linha 2 (quirk do original, mantido);
- `Weight = 3` e `HorizontalAlignment = 3` **nao sao constantes validas** do Excel: o Office 16 desta
  maquina devolveu `-4138` (medio) e `-4108` (centro), e o `4` do comprimento virou `-4152` (a
  direita). Os dois lados passam os mesmos literais, entao a comparacao e valida — so nao espere ver
  `3` de volta.

O caminho do **Excel fechado** tambem e medivel: mate o `EXCEL`, rode a exportacao e confira que
sobrou um `EXCEL` visivel com a aba nova depois de `Planilha1` (o recoder solta o COM; a instancia
**nao** fecha — medido).

**A ponte com o Excel ativo (`frmEditaTitulos`, rodada 215 medida em 2026-10-16).** Tres coisas para a
medicao sair, todas aprendidas medindo:

1. **O Excel tem de estar aberto e VISIVEL com um livro.** O `ExcelAberto()` do original conta o processo
   `EXCEL`, mas um Excel **invisivel** (sobra de automacao) faz o plugin **matar o processo**
   (`process.Kill()`) e criar instancia nova pelo CLSID — a aba das duas sessoes deixa de ser a mesma.
   Abra pelo `Start-Process 'EXCEL.EXE'` e confirme com `[Runtime.InteropServices.Marshal]::GetActiveObject('Excel.Application')`.
2. **Duas sessoes de `accoreconsole` na MESMA aba:** a 1a exporta (`POSITRON_TITULOS_EXCEL=exportar`) e a
   2a importa (`=importar;exportar`) — o Excel fica aberto entre elas (o `JANELA` prende o script, entao a
   ligacao e o gancho rodam no `Montar` e o comando nao retorna; ver o achado do `JANELA` acima).
3. **A convergencia e a prova de que a IMPORTACAO mudou a grade:** `POSITRON_TITULOS_EXCEL='importar;importar'`
   tem de dar `1 célula` e depois `0 célula`. Sem isso a linha da exportacao nao distingue "a importacao
   escreveu na grade" de "a grade ja estava igual". Medido em 2026-10-16: `75 entrada(s) lida(s) da aba`,
   `1 célula(s) da grade atualizada(s)`, depois `0 célula(s)` — com o valor vindo **da aba** (posto por COM).

**Se o `LIGACAO` falhar com "a licença para usar este aplicativo expirou", o problema e do OFFICE, nao do
plugin:** o mesmo teste fora do CAD ja denuncia — `Range('A1').ClearContents()` e `EntireRow.Delete()` no
Excel aberto. Nesta maquina (Office ativado em 2026-10-16) os tres passam (escrita, `ClearContents`,
`EntireRow.Delete`); antes da ativacao os dois ultimos falhavam com essa mensagem (rodada 215).

**O painel ganhou a linha da ligacao.** O `scripts/cobertura-do-reverso.ps1` lia "a regra existe" e
nao sabia da ligacao — listava como "falta so a ligacao" telas que ja a tinham. Agora ele le o
`NomeDaTela` de cada `Interface/Telas/Ligacao*.cs` e imprime `com a ligacao na tela: 5 (...)`,
filtrando a lista final ("PROXIMAS DA FILA: telas cuja REGRA ja existe e AINDA NAO tem ligacao" —
que ficou **vazia**).

**Gate desta rodada:** `plugin:test` **622** (+4, `RevisoesDoDwgTests` — as revisoes reunidas das
tres tabelas, o DWG filtrado, o banco vazio e a revisao nula), as duas builds **0 avisos / 0 erros** e
o `cad:projeto:acad -Idempotencia` verde com os numeros de sempre (`FIA` 494, `INT` 20, `VERIF` 249
na linha de base, hash `7c1635f0…`).

**Rodada 139 — a correcao da interligacao (CorrigeInterligacao): o candidato grande da fila.**
O item 1 do `AUDITORIA.md` §0 saiu dela. O comando do original (`clsUtilitarios.cs:611`, 216 linhas)
varre as polylines de interligacao e, para cada trecho **indefinido** (`NumVeia == -1000` — o estado
que o `INDCABO` deixa ao tirar o cabo que o catalogo recusa), redescobre o painel de **cada ponta**
pelo dispositivo que esta sobre ela (`verificaDispInterlig`) e regrava `Painel1`/`Painel2`, que sao
os mesmos campos que a projecao do `INT` le e grava.

**O que e puro e o que e desenho.** A decisao ficou no `Positron.Data`
(`Interligacao/CorrecaoInterligacao.cs`, `Planejar`) e o desenho no adapter
(`Interligacao/CorrecaoDaInterligacaoDoDesenho.cs`), como nas outras `Corrige*`. Tres detalhes do
original ficaram fixados em teste, porque cada um muda o resultado: (a) o par do `Tipo 1` vale em
**qualquer ordem** — o `if` aninhado que o decompilador devolveu e redundante (as duas condicoes
internas sao a negacao da mesma comparacao); (b) no `Tipo 2`/`3` quem escolhe o campo e
`Painel1 == 0` (zerado, o achado vai para o `Painel2`; senao para o `Painel1`) e **so um** dos dois e
tocado; (c) a ponta 2 so e usada quando a 1 nao tem dispositivo (o `if (!flag)` do original).

**Os cinco ramos do `verificaDispInterlig`** (o adapter reproduz os cinco): o original pagina a
entidade ativa (`Pagina.AtivaPagina`) antes de procurar, entao o filtro e o **layer do proprio
trecho**; o **primeiro** `BlockReference` da caixa de 0,2 decide — inclusive quando **nao** e um
dispositivo (o `break` do original); `E` exige um atributo `B<numero>`; `B` resolve o painel no
dicionario `REGUAS` (o `array[8]` e o indice da regua); `I` (importado) so vale com o **tipo
importado** `E` (exigindo o atributo) ou `B`, com o painel no `array[9]`; `E`/`A` resolvem pelo bloco
apontado no `array[4]` (o `BuscaPainelDispositivo` que a projecao ja usava).

**Duas divergencias registradas** (e medidas): a **caixa** e o teste da **posicao** do bloco dentro
de +-0,2 da ponta — o original usa `Editor.SelectCrossingWindow`, que tambem pega geometria cruzando
a janela, e a ordem dos candidatos aqui e a do ModelSpace (nao a do selection set); e um dispositivo
cujo painel resolve em **0** conta como **nao achado** — o original devolveria `true` com painel 0 e
**gravaria o zero**, inclusive por cima de um `Painel2` valido no ramo do `Tipo 2`/`3`. A regra pula
esses trechos e os conta em `SemDispositivo` (mesma decisao do off-by-one do `RENPAGA`, rodada 134).

**Medido.** A fixture nova `scripts/cad-fixture-corrige-interligacao.lsp` monta **oito** trechos, um
por ramo (o par errado, o par revertido, o `Tipo 2`, o `Tipo 3` sem dispositivo na ponta 1, o cabo
definido, o sem dispositivo, o de outra camada e o que tem um `P` que quebra a busca), e o
instrumento independente `scripts/cad-conta-interligacao.lsp` duma o XData **cru** antes/depois. No
**AutoCAD 2020**: `3 de 7` regravados na primeira passada e `0 de 7` na **segunda** (convergencia),
com o dump confirmando `(1,2) -> (503,9)`, `(0,77) -> (0,9)` nos dois de uma ponta e os quatro
intactos. No **`Funcional.dwg`**: **20 trechos lidos, nenhum indefinido** (`0 de 0`) — o zero e o
**dado**, com o mesmo dump mostrando os 20 com `Num_Veia` definido. A receita e o log medido estao na
secao da frente 2 (junto do `INDCABO`).

**Gate desta rodada:** `plugin:test` **618** (+14, `CorrecaoInterligacaoTests`), as duas builds **0
avisos / 0 erros** e o `cad:projeto:acad -Idempotencia` verde com os numeros de sempre (`FIA` 494,
`INT` 20, `VERIF` 249 na linha de base, app 4.988, hash `7c1635f0…`) — a tabela `Interligacao4` e a
projecao nao foram tocadas.

**Rodada 138 — a interface do ZWCAD no build AutoCAD: a AdWindows na lib, a barra e a paleta.**
O build AutoCAD respondia `Barra: disponivel apenas no build ZWCAD (o ZdWindows e a API de
interface)` e a **paleta nao existia**: o `PaletaDeFolhas` do AutoCAD montava o `FolhasControle`
**sem pai** (nada aparecia em lugar nenhum) e a linha `Positron — paleta de folhas com 16 pagina(s)
(ancorada no CAD)` era **mensagem fixa** do comando, nao uma medida — ela ja aparecia na rodada 137 e
foi lida como "a paleta funciona". A rodada fechou os dois:

**1. A AdWindows na lib.** A API de interface do AutoCAD e a `AdWindows.dll`
(`Autodesk.Windows`: o `RibbonControl`, o `ComponentManager` e os itens) — a **mesma** API que o
`ZwSoft.Windows` do ZWCAD clona. Ela entrou na copia do repo
(`cad-plugin/lib/AutoCAD/2020/AdWindows.dll`), na lista do `scripts/prepare-autocad-api.ps1` e no
`csproj` (referencia `AdWindows`, `Private=false`, como as outras tres).

**2. Uma construcao para os dois.** Com o `using` condicional o `BarraDeFerramentas` virou **um**
codigo: o corpo que monta a aba, os paineis e os botoes nao mudou de forma, e o ZWCAD segue com
`ZwSoft.Windows`. Duas divergencias ficaram em `#if` (medidas no compilador): o `Name` do item, que
no AutoCAD e `Id`, e o "desativado", que e `IsActive` no ZWCAD e `IsEnabled` no AutoCAD. Na paleta,
o `PaletteSet` passou a ser o mesmo dos dois (`Autodesk.AutoCAD.Windows.PaletteSet`, que **ja vinha
no `acmgd.dll`** — nao foi preciso vendorizar a `AcWindows.dll`).

**Medido (AutoCAD 2020, interface cheia, por autoload, sem `NETLOAD`):**

```text
Positron carregado. Digite ELET para comecar — ELET abre a paleta de folhas (FOLHAS tambem).
Barra: o ribbon ainda não existe nesta fase do arranque — a aba entra na primeira ociosidade do CAD ...
Positron — paleta de folhas com 16 página(s) (ancorada no CAD).
Barra: aba "Positron" com 10 painel(is) — 121 botão(ões) do original (83 ligado(s), 38 desativado(s); 76 abrem uma janela) e 8 do recoder.
```

A ultima linha e a **prova** de que a barra do AutoCAD existe com os **mesmos numeros** medidos no
ZWCAD (rodada 129): os 9 paineis do original + o nosso, 121 botoes, 83 ligados, 38 desativados, 76
abrindo uma tela e 8 do recoder. A **validacao visual** (a aba na fita, a paleta ancorada) e do dono
do produto; o que e automatico sai no log.

**Dois achados de host — os dois mudaram o desenho do codigo:**

- **o ribbon nao existe no `Initialize()`.** No ZWCAD o `ComponentManager.Ribbon` ja esta montado
  quando o plugin carrega; **no AutoCAD nao** — medido: no load por autoload a barra saiu como "o
  ribbon ainda nao existe nesta fase do arranque". A aba passou a ser criada na **primeira
  ociosidade** (`Application.Idle`, ate 10 tentativas) e a linha da barra sai no log logo depois; no
  `accoreconsole` o evento nao chega a disparar (nada fica pendurado);
- **no `accoreconsole`, so REFERENCIAR o `PaletteSet` derruba o processo.** Com o `ELET` chamando um
  metodo que mencionava `Autodesk.AutoCAD.Windows.PaletteSet`, o processo **morria no JIT** — sem
  excecao e sem log: uma sonda na **primeira linha do corpo** do metodo nunca era escrita, o
  `try/catch` do comando nao via nada e o script **nao chegava ao `FIA`/`INT`** (o
  `cad:projeto:acad` quebraria mais adiante, depois de o smoke dizer OK). A interface ficou isolada
  no tipo `PaletaAncoravel`, tocado **so quando ha janela**; o `PaletaDeFolhas` — esse sim chamado
  nos dois hosts — nao menciona tipo de interface nenhum, e no headless o `ELET` volta a devolver
  so a contagem de paginas com o ciclo inteiro rodando. **Licao de instrumento:** referencia a tipo
  de interface num metodo compartilhado mata o host headless **antes de qualquer log**; quando o
  sintoma e "o comando morre e nao escreve nada", a causa pode ser o JIT resolvendo um tipo que o
  host nao tem.

**Gate desta rodada:** as duas builds **0 avisos / 0 erros**, `plugin:test` **604** (inalterado — a
rodada e de interface), o `cad:projeto:acad -Idempotencia` verde (`FIA` 494, `INT` 20, `VERIF` 249
na linha de base, app **4.988**, `IDEMPOTENTE` com o hash `7c1635f0…` de sempre), o
`cad:smoke:acad` com `ELET` headless sem derrubar o processo e a medicao de interface acima.

**Rodada 137 — o autoload nas duas versoes e os testes reais na compilacao do AutoCAD.**
O `install/Positron.bundle/PackageContents.xml` tinha **um** componente (`Platform="ZWCAD*"`,
`Positron.Plugin.ZWCAD.dll`) e o **AutoCAD nao carregava nada** — medido, nao deduzido: com esse
manifesto em `%APPDATA%\Autodesk\ApplicationPlugins\Positron.bundle`, a interface cheia do AutoCAD
2020 abre e o `POSITRON_LOG` **nao** e escrito (nenhuma linha do plugin). O mesmo pacote passou a ter
**um `<Components>` por plataforma**:

| componente | plataforma | DLL |
|---|---|---|
| ZWCAD (igual ao da rodada 120, `AppName` incluido) | `Platform="ZWCAD*"` SeriesMin/Max `2026` | `Positron.Plugin.ZWCAD.dll` |
| AutoCAD (novo) | `Platform="AutoCAD*"` SeriesMin/Max `R23.1` | `Positron.Plugin.AutoCAD.dll` |

O `RuntimeRequirements` **de pacote** saiu: ele valia para o pacote inteiro e gateava tudo para o
ZWCAD; quem decide passou a ser o de **componente**, que ja existia. O `scripts/instala-bundle.ps1`
(novo) faz a copia — manifesto + DLL da plataforma + dependencias (`Positron.Data`,
`Positron.Contract`, `System.Data.SQLite` e o `x64\SQLite.Interop.dll`) — para a pasta que cada CAD
varre (`%APPDATA%\ZWSOFT\ZWCAD\<ano>\<idioma>\Support` no ZWCAD;
`%APPDATA%\Autodesk\ApplicationPlugins` no AutoCAD), tem `-Remover` e falha com a mensagem do host
quando o CAD nao esta instalado.

**Medido (AutoCAD 2020, interface cheia, `acad.exe /nologo /i <copia> /b <script>`, sem `NETLOAD`):**

```text
Positron: autoload do AutoCAD instalado em 'C:\Users\RNO\AppData\Roaming\Autodesk\ApplicationPlugins\Positron.bundle'.
Positron carregado. Digite ELET para comecar — ELET abre a paleta de folhas (FOLHAS tambem).
Barra: disponivel apenas no build ZWCAD (o ZdWindows e a API de interface).
Positron — paleta de folhas com 16 pagina(s) (ancorada no CAD).
VERIF: 494 fio(s), 20 trecho(s), 265 porta(s), 168 borne(s), 70 contato(s) na revisao.
VERIF: 249 problema(s) — fiacao: 0; interligacao: 0; modelos: 0; desenho: 249.
VERIF: por tipo — BorneSemLm: 119; BorneSemFiacao: 107; IntervaloBorneInvalido: 11; ReguaVazia: 10; SobreposicaoAusente: 2.
```

O **A/B** e o que fecha a rodada: o mesmo pacote com o manifesto **antigo** (so ZWCAD) nao escreve log
nenhum; com o manifesto novo o plugin se apresenta, a paleta abre com as **16 paginas**, o `VERIF`
le o banco — as dependencias foram junto, o SQLite interop entra pelo `x64\` — e devolve a **mesma
linha de base** do ZWCAD (249 = 107+119+11+10+2).

**Achado de instrumento (muda como se testa o autoload):** o **`accoreconsole` nao carrega
`.bundle` nenhum**. Medido dentro dele: `(arx)` lista so `acdim.crx`, `acvmtools.crx` e
`vl.crx` — **sem o `AcAutoLoader.arx`** —, e um bundle valido em
`%APPDATA%\Autodesk\ApplicationPlugins` (ou em `%PROGRAMDATA%\Autodesk\ApplicationPlugins`) nao
muda nada: `FOLHAS` responde `Unknown command`. Ou seja: no harness headless a DLL entra por
**`NETLOAD`** (como o `cad-autocad-smoke.ps1` sempre fez) e o autoload so se mede na **interface
cheia**. Nao e defeito do plugin nem do manifesto.

**Receita (as duas versoes):**

```powershell
npm run plugin:build:all                                   # as duas DLLs
powershell -ExecutionPolicy Bypass -File scripts/instala-bundle.ps1 -Cad AutoCAD
powershell -ExecutionPolicy Bypass -File scripts/instala-bundle.ps1 -Cad ZWCAD     # sem ZWCAD aqui: falha com a mensagem do host
powershell -ExecutionPolicy Bypass -File scripts/instala-bundle.ps1 -Cad AutoCAD -Remover
# a prova do autoload e abrir a INTERFACE do CAD (sem NETLOAD) e ler o POSITRON_LOG
```

**Gate desta rodada:** `plugin:test` **604** (inalterado — a rodada e de instalacao/ambiente), as
duas builds **0 avisos / 0 erros**, o `cad:projeto:acad -Idempotencia` verde (os numeros da rodada
136, repetidos) e a casca no AutoCAD (`ELET` → paleta de 16 paginas; `pzTelas`/`JANELAS` →
**127 de 127** telas montadas, **2** ligacoes; `APAGARXDATA`; `pzDiag`). O **gap do host** segue o
mesmo da rodada 136: a **barra** do §7.8 e do `ZdWindows` (no AutoCAD a linha diz isso) — a paleta
funciona.

**Rodada 136 — o host verificado passa a ser o AutoCAD 2020 e o E2E le o projeto real do repo.**
A maquina trocou de host: o **ZWCAD 2026 nao esta mais instalado** (`C:\Program Files\ZWSOFT`
nao existe) e o **AutoCAD 2020** esta (`acad.exe` + `accoreconsole.exe` em
`C:\Program Files\Autodesk\AutoCAD 2020`). O **alvo do produto continua sendo o ZWCAD** e os
numeros medidos la seguem valendo; o que mudou e **onde o ciclo e medido aqui** — e duas coisas
dependiam disso:

**1. O `cad-projeto-e2e.ps1` apontava para fora do repo.** Os defaults eram
`..\Elet\Teste_projeto_real\{Funcional.dwg,RCD.mdb}`, de quando o material estava fora do repo;
o projeto real mora **dentro** desde a rodada 134 (`cad-plugin/reverso/Teste_projeto_real`,
adicionado no `7a542b59`) e o caminho antigo nao existe nesta maquina — o `-Desenho` morria em
`nao encontrei o desenho`. Os defaults passaram a ser resolvidos pela **raiz do repo** (e nao pelo
diretorio de chamada), entao o ciclo roda sem argumento nenhum.

**2. Sem ZWCAD, o default `-Cad ZWCAD` falhava dentro do harness.** Agora o E2E confere o
`C:\Program Files\ZWSOFT\ZWCAD 2026|2025` antes e falha com a mensagem que diz o host que existe
(`Nesta maquina o host verificado e o AutoCAD 2020: rode com '-Cad AutoCAD'`) — antes o erro era o
generico `ZWCAD nao encontrado em '...'` do smoke, depois de ja ter criado o banco.

**Medido (a prova da paridade).** `cad:projeto:acad -Idempotencia` com os defaults novos:

```text
FIA: 494 linha(s) em Fiacao (199 borne(s), 191 dispositivo(s), 0 reordenada(s), 83 posicao(oes),
     450 ponto(s) de bloco); 265 porta(s) em Portas4F; 168 borne(s) em Bornes4F; 70 contato(s) em
     Contatos4F; 83 dispositivo(s) em Dispositivos4F; 11 circuito(s) em Circuitos4F; 15 tipo(s) em Aplicacao4F
INT: 20 linha(s) gravada(s) em Interligacao4 (199 borne(s)); 265 porta(s) em Portas4I; 216 borne(s) em
     Bornes4I; 697 cabo(s) em Cabos4; 2388 veia(s) em Veias4
COMPLM: 104 linha(s) em ListaMateriais (8 painel(is); 199 borne(s) do desenho; 83 posicao(oes) de layout)
VERIF: 249 problema(s) — fiacao: 0; interligacao: 0; modelos: 0; desenho: 249
       por tipo — BorneSemLm: 119; BorneSemFiacao: 107; IntervaloBorneInvalido: 11; ReguaVazia: 10; SobreposicaoAusente: 2
app: total 4988 linha(s) nas consultas (480 paineis, 697 cabos, 2388 veias, 265 portas, 168 bornes, 70 contatos)
IDEMPOTENTE: mesmo conteudo (ignorando Data) — hash A = hash B = 7c1635f0…b69698babd
```

O `cad:smoke:acad` tambem passa (`Positron carregado no AutoCAD 2020`) e o proprio log entrega a
**limitacao do host**: `Barra: disponivel apenas no build ZWCAD (o ZdWindows e a API de interface)`
— a barra do §7.8 e do ZWCAD; no AutoCAD a **paleta de folhas** funciona (ancorada) e a fita nao
existe. Fica registrado como gap de host, nao como regressao (nenhuma linha de codigo do plugin
mudou nesta rodada).

**A API do AutoCAD fica vendorizada** (`cad-plugin/lib/AutoCAD/2020/{acmgd,acdbmgd,accoremgd}.dll`,
commit `de3837e4`, com o `scripts/prepare-autocad-api.ps1` que a refaz a partir de uma instalacao):
o mesmo padrao do `cad-plugin/lib/ZWCAD/2026` — o `csproj` prefere a copia do repo e so cai no
`Program Files` (ou no stub) sem ela, entao `plugin:build:autocad` compila contra a **API real**
mesmo sem o AutoCAD instalado. A receita e o estado do host ficam na secao **AutoCAD 2020** deste
RUNBOOK.

**Gate desta rodada:** `plugin:test` **604** (inalterado — rodada de ambiente, nao de regra), as
duas builds **0 avisos / 0 erros** e o ciclo completo `-Idempotencia` medido acima.

**Rodada 135 — a familia dos atributos: a troca de blocos (5 comandos, 277 linhas do reverso).**
O **primeiro item da fila** do `AUDITORIA.md` §0 saiu dela. No `clsTrocaEditaBlocos.cs` o fluxo e
**grade -> buffer -> desenho**: a tela `frmTrocaEditaBlocos` le os atributos dos blocos escolhidos para
o buffer, o usuario troca os blocos e o buffer **devolve os valores** ao bloco novo. O unico detalhe
que faz o fluxo existir e o **filtro do buffer**: entram so os atributos **invisiveis** (`if
(!Entity.Visible)`, `clsTrocaEditaBlocos.cs:230`) — e neles que o projeto guarda o que o projetista nao
ve na tela, e e por eles que o valor **atravessa a substituicao do bloco**.

**O que entrou.** A regra pura em `Positron.Data/TrocaDeBlocos/AtributosDosBlocos.cs` (o buffer
`Invisiveis`, os nomes/handles unicos do original, o resumo do `CorrigeAtributos` e a escolha das
correcoes do pos-troca), o adapter `Positron.Plugin/TrocaDeBlocos/AtributosDoDesenho.cs` (a varredura
do ModelSpace com o buffer **estatico**, como o `clsTrocaEditaBlocosMat.mAtributos` do original — la
os comandos sao disparados por `SendStringToExecute` e nao recebem nada) e os **5 comandos**:
`LeTodosAtributos`, `LeAtributos`, `CorrigeAtributos`, `CorrigeAtributosSemMsg` e
`PreencheNovosAtributos`.

| no original | no recoder |
|---|---|
| `LeTodosAtributos` (95 linhas): varre o ModelSpace e guarda os invisiveis | o mesmo, com a leitura instrumentada (blocos lidos, blocos com atributo, atributos lidos, entradas do buffer) |
| `LeAtributos` (122 linhas): o mesmo com a lista de nomes **da grade** | a lista vem do **`POSITRON_BLOCOS`** (separada por virgula); sem a variavel, a varredura e a de todos |
| `CorrigeAtributos` (29 linhas): aplica o buffer e mostra o resumo num `MsgBox` | aplica o buffer (por handle do bloco e tag; grava **so o que muda**) e o texto do `MsgBox` vai para a **linha de comando**, com as mesmas `mMensagem` (`1298`/`1302` no singular/plural, `1349` quando algum handle mudou, `1299`/`1300` para os blocos que nao existem, sempre com a `1301` "no Desenho") e as mesmas trocas de titulo |
| `CorrigeAtributosSemMsg` (10 linhas): a mesma gravacao sem o resumo | idem (a tela usa quando nao quer a caixa) |
| `PreencheNovosAtributos` (21 linhas): o pos-troca por bloco — `_E_` chama o `clsPortas.AtualizaAsPortasTrocadas` e `_A_` chama o `Correcao.CorrigeContatosAux` | o comando faz os **dois niveis** do original num so: as marcas do nome (`frmTrocaEditaBlocos.cs:699-740`) ligam o `CorrigeBlocosContatosAux` (`_A_`), o `CorrigePainelET1DosBornes` (`_B_`) e este comando (`_A_` **ou** `_E_`, o `flag | flag3`), e o corpo dele manda o `_A_` para o nosso `CorrigeContatosAux`; o `_E_` fica **registrado na linha** (o `AtualizaAsPortasTrocadas` precisa da matriz de handles que so a troca produz) |

**Achado de medicao — o `Visible` do CAD mente para atributo.** A fixture foi montada para provar o
buffer e o achado apareceu no primeiro disparo: **0 atributo(s) invisivel(is)** com os dois atributos
invisiveis no desenho. Medindo as **duas** propriedades no mesmo atributo, com o `70` do DXF em `1`:

```
LeTodosAtributos: ... 3 atributo(s) em 2 bloco(s) ... TEMP: Visible=0 Invisible=2.
dump:             ATRIB;249;MODELO_NA_1;T1;B2;SIM      <- o 70 bit 1 do DXF diz invisivel
```

O original le e grava `((Entity)val7).Visible`, e no ZWCAD esse membro **sempre devolve verdadeiro** —
com ele o buffer sairia **vazio em todo desenho**. O recoder usa `AttributeReference.Invisible` (o
mesmo flag `70` bit 1, e a propriedade que o leitor de portas do recoder ja usa desde a rodada 53).
Fica no XML doc do adapter.

**Medido no ZWCAD 2026, na fixture sintetica** (`scripts/cad-fixture-troca-atributos.lsp`: `MODELO_NA_1`
com `T1` invisivel e `T2` visivel, `AUXILIAR_A_1` com `T3` invisivel; `(pz-tb:estraga)` e o **avesso
da troca** — muda o texto do invisivel e o poe visivel, que e o que a substituicao do bloco faria com o
bloco novo):

```
npm run cad:smoke -- -Fixture scripts/cad-fixture-troca-atributos.lsp -Banco "$TEMP/positron-troca.db" `
  -Comandos "LeTodosAtributos,(pz-tb:estraga),CorrigeAtributosSemMsg,CorrigeAtributos,(pz-tb:conta)"
#   LeTodosAtributos: 2 atributo(s) invisivel(is) no buffer (3 atributo(s) em 2 bloco(s) de 2 bloco(s) lido(s)); 2 bloco(s) com atributo(s), 2 entrada(s) no buffer; ex: T1=B2, T3=C3.
#   CorrigeAtributosSemMsg: (2 atributo(s) gravado(s) em 2 de 2 entrada(s) do buffer; 2 visibilidade(s); 0 bloco(s) sem a tag; 0 fora do desenho).
#   CorrigeAtributos: 2 Tipos de Blocos Trocados (0 atributo(s) gravado(s) em 2 de 2 entrada(s) do buffer; 0 visibilidade(s); 0 bloco(s) sem a tag; 0 fora do desenho).
#   dump (fora do plugin): ATRIB;249;MODELO_NA_1;T1;B2;SIM
#                         ATRIB;24D;AUXILIAR_A_1;T3;C3;SIM
#                         TOTAL;insercoes;2;atributos;3;invisiveis;2
```

O dump e a prova **independente** do caminho de escrita: os dois atributos que o `estraga` tinha
estragado (valor e visibilidade) voltaram ao valor do buffer **e** a invisibilidade foi restaurada — e a
**segunda** passada (`CorrigeAtributos`, logo depois) grava **0**, com o resumo do original saindo na
linha de comando. Sem o buffer lido, os dois comandos recusam:
`o buffer esta vazio — rode o LeAtributos/LeTodosAtributos antes.`

**Medido no `Funcional.dwg` real** (copia; banco novo):

```
#   LeTodosAtributos: 0 atributo(s) invisivel(is) no buffer (1978 atributo(s) em 557 bloco(s) de 557 bloco(s) lido(s)); 44 bloco(s) com atributo(s), 0 entrada(s) no buffer.
#   CorrigeAtributosSemMsg / CorrigeAtributos: o buffer esta vazio — ...
#   PreencheNovosAtributos: CorrigeBlocosContatosAux: 0 atributo(s) regravado(s) em 63 de 63 bloco(s) auxiliar(es) (8 modelo(s) e 26 contato(s) no CONTATOS). CorrigePainelET1DosBornes: 0 atributo(s) regravado(s) em 199 de 199 borne(s) (31 regua(s) no dicionario). CorrigeContatosAux: 0 de 129 modelo(s) com o HandleContatoAux acertado (63 bloco(s) auxiliar(es) lido(s); 66 modelo(s) sem contato casado). o ramo _E_ fica fora: ...
```

Nesta copia **nenhum atributo e invisivel** (1978 lidos, 0 invisiveis), entao o buffer sai vazio e o
comando **recusa** — o zero e o dado do desenho, nao um no-op silencioso; e o `PreencheNovosAtributos`
prova a **escolha das correcoes pelas marcas** no desenho real: os tres ramos do original disparam os
comandos ja medidos nas rodadas 85/96/77, com os mesmos numeros (63/63, 199/199, 0 de 129).

**Medido (o filtro do `LeAtributos`)**: a variavel vai **do shell** — o ZWCAD herda o ambiente de quem
o lanca:

```
POSITRON_BLOCOS=AUXILIAR_A_1 npm run cad:smoke -- -Fixture scripts/cad-fixture-troca-atributos.lsp -Comandos LeAtributos ...
#   LeAtributos: 1 atributo(s) invisivel(is) no buffer (1 atributo(s) em 1 bloco(s) de 2 bloco(s) lido(s)); 1 bloco(s) com atributo(s), 1 entrada(s) no buffer; ex: T3=C3.
```

**Licao de ferramenta (registrada):** uma linha LISP **com aspas** na lista do `-Comandos`
(`(setenv "POSITRON_BLOCOS" "AUXILIAR_A_1")`) nao chega intacta ao `.scr`: o ZWCAD reexecutou o
comando anterior no lugar dela e **engoliu a linha seguinte**. O `.scr` gerado estava correto — a
linha e que nao serve para dirigir o plugin. Variavel de ambiente, so pelo shell.

**Fora do recorte, documentado:** a **troca em si** (o `insereUmBlocoParaSubstituir`/
`ApagaOsBlocosAntigos`/`corrigeOsHandlesDosBlocos`, que importam um DWG e apagam blocos), o ramo `_E_`
(`clsPortas.AtualizaAsPortasTrocadas`) e o filtro de "bloco do Eletron" do `LeAtributos`
(`clsBlocos.TipoBlocoDoEletron` le o `XData.ToString()` cru e para no `PointMonitorToolTips` do CAD:
ambiente/UI, e aqui o recorte por nome ja limita a varredura). A **tela** (`frmTrocaEditaBlocos`,
744 linhas) fica para a frente 12: a regra — que era o bloqueio registrado no `CorrecaoDosBlocosMirror`
— esta pronta.

**Gate desta rodada:** `plugin:test` **604** (+11, `TrocaDeBlocosTests`), as duas builds **0 avisos / 0 erros**
e o painel de cobertura re-medido: **59** comandos escritos a mao (**46** do reverso + 13 nossos),
**158** respondidos (com os 99 gerados) e **71** do reverso sem nada no plugin (**17** abrem janela +
**54** de regra pura).

**Rodada 134 — o reverso dentro do repo, o `RENPAGA` medido e a semantica dos 5 comandos de nucleo.**
O dono do produto **adicionou o reverso ao repo** (`cad-plugin/reverso/Eletron4_ZWcad`, com o
`decompiled/`, o `decompiled-cleaned/`, o `cleaned/` e o `DLL/`) e pediu tres coisas de uma vez:
seguir o plano **um item por vez**, **varios metodos por arquivo** ("desnecessario criar um arquivo
com 10 linhas") e manter a **licenca documentada** mesmo sem usa-la. A rodada fez as tres.

**Os instrumentos passaram a ler a copia do repo.** O `cobertura-do-reverso.ps1` e os cinco
extratores (`extrair-{comandos,formularios,barra,icones,imagens}-do-reverso.ps1`) tinham o caminho
**absoluto** da maquina de analise; agora o default e o caminho do repo e o `-Decomp`/`-Dll` continua
trocando. O painel **imprime de onde leu** — e por isso que a conferencia e objetiva:

```
powershell -ExecutionPolicy Bypass -File scripts/cobertura-do-reverso.ps1
#   TELAS
#     reverso lido de                : cad-plugin\reverso\Eletron4_ZWcad\decompiled-cleaned\Eletron4
#     telas frm* no decompilado      : 127
```

A regeracao saiu **byte a byte igual** (so a linha de proveniencia dos mapas mudou):

```
for s in extrair-comandos-do-reverso extrair-formularios-do-reverso extrair-barra-do-reverso; do \
  powershell -ExecutionPolicy Bypass -File scripts/$s.ps1; done
git status --porcelain   # so docs/reverso-*.txt (a linha de proveniencia) + os scripts
```

Os icones e as imagens tambem: `extrair-icones-do-reverso.ps1` (que agora usa a
`reverso/.../cleaned/Eletron4Z-cleaned.dll` do repo, sem depender do de4dot de novo) extraiu os
**348** icones e o `extrair-imagens-dos-formularios.ps1` as **34** imagens, os dois sem mudar um byte
do que ja estava em `cad-plugin/lib/Icons/`.**

**Pegadinha de contagem (registrada):** das 127 telas, **3** comecam com `Frm*` maiusculo
(`FrmBuscaNuvem`, `FrmImportarCabosExcel`, `FrmTrocaUsuario`). O `-Filter` do PowerShell casa sem
diferenciar caixa e acha **127**; um glob de shell (que diferencia) acha **124** — o comentario esta
no script.

**O comando `RENPAGA`** (o ultimo item trivial da fila do `AUDITORIA.md` §0) entrou no lugar de
"falta so registrar o nome": o sufixo vem de **`POSITRON_SUFIXO`** (padrao `A`, o mesmo do campo da
paleta) em vez do `InputBox` do original, e a regra e a mesma do botao **Renumerar Paginas**.
Lendo o corpo do original (`Correcao.cs:3273`) apareceram **dois defeitos latentes** na regra que ja
estava portada — e so um deles virou comportamento:

| achado no corpo do original | o que o recoder faz |
|---|---|
| `!Versioned.IsNumeric` + `MsgBox`: com **qualquer** pagina alfabetica o lote inteiro e recusado | **reproduzido** (`PaginasDoCaderno.TodasNumericas`, usado pelo comando **e** pela paleta): sem a guarda, a segunda passada geraria `1A` + `A` = `1AA`, que o `LayerValido` ja nao aceita — a pagina sairia do caderno |
| `For j = 2 To UBound(mPaginas, 2)` sobre um `mPaginas` que comeca no indice 1 (`Pagina.cs`, `CarregaPaginas`): a **primeira** pagina da tabela de layers **nunca** e renomeada | **nao reproduzido** (off-by-one do original): o recoder renomeia todas, e a decisao esta no XML doc + num teste |

**Medido no ZWCAD 2026** (copia do `Funcional.dwg`, 16 paginas):

```
npm run cad:smoke -- -Desenho "..\Elet\Teste_projeto_real\Funcional.dwg" -Comandos RENPAGA,RENPAGA -Revisao R0 -Banco "$TEMP/positron-renpaga.db"
#   RENPAGA: 16 de 16 pagina(s) renomeada(s) com o sufixo "A".
#   RENPAGA: as paginas nao podem conter caracter alfabetico para usar esta funcao (o lote inteiro e recusado, como no original).
```

A **segunda** passada e a prova da guarda pelo proprio desenho: depois da primeira, as 16 paginas
tem o sufixo `A`, entao o lote seguinte e recusado — exatamente o que o original faz.

**A semantica dos 5 comandos de nucleo** (o dono do produto a informou; o `ARQUITETURA.md` §11 dizia
que o fluxo deles nao tinha sido lido): `ELET` = o `NETLOAD` com o **caminho da DLL memorizado** (na
primeira execucao o caminho e gravado e as seguintes carregam direto), `DLOG` = o plugin do
**DiagLog** (outra DLL) e `ETPG`/`ANET`/`EARQ` = os **subprodutos** (topografico / ArqNet /
arquitetura). Nada disso e regra de desenho — e a razao de o corpo dos cinco ser **vazio** no
`Eletron4Z.dll` (quem trabalha e o `IExtensionApplication` do produto carregado). Ficou escrito no
`ARQUITETURA.md` §4/§11 do reverso, no §7.6 (frente 11) do `PLANO.md` e no `AUDITORIA.md` §0/§3.

**A licenca fica documentada e nao usada:** nota nova no `ARQUITETURA.md` §8 (o subsistema nao e
portado; os binarios do hardlock estao em `DLL/` como parte do reverso) e o mesmo em `POSITRON.md` §8.

**Gate desta rodada:** `plugin:test` **593** (+2: a guarda do `RENPAGA` e o off-by-one), as duas
builds **0 avisos / 0 erros** e o painel com exit 0 nos dois modos (base e `-Acoplamento`). O painel
mede **54** comandos escritos a mao (41 do reverso + 13 nossos) e **76** sem nada no plugin (17 abrem
janela + **59** de regra pura).

**Observacao de peso:** o reverso entrou no repo **com os binarios** (`DLL/` com o `Eletron4Z.dll` de
12 MB, os `.exe` do hardlock, os `.rar` de blocos e os `.accdb`) — ~411 MB. Nada foi movido nesta
rodada; se o peso incomodar, o caminho e `git lfs` (decisao do dono).

**Rodada 133 — por que a regra nao vem pronta do decompilado: `-Acoplamento` no painel.**
O dono do produto perguntou por que os 53 comandos escritos a mao nao foram **pegados do reverso**, ja
que estao la. A resposta passou a ser medida em vez de argumentada: o `-Acoplamento` do painel le o
**corpo de cada comando** do decompilado (chaves balanceadas, com as strings fora da conta) e marca o que
ele carrega do ambiente do original.

```
powershell -ExecutionPolicy Bypass -File scripts/cobertura-do-reverso.ps1 -Acoplamento
```

| marca | ocorrencias no decompilado | comandos que carregam |
|---|---|---|
| runtime VB (`Conversions.` / `Operators.`) | **22.195** | 31 |
| estado global (`DeclaracoesGeral.`) | **12.089** | 48 |
| banco Access/MDB (`cDados*`) | **2.215** | 11 |
| `Interaction.MsgBox` (trava um script: nao ha quem clique) | **655** | 13 |
| hardlock/licenca | **274** | 5 |
| `Editor` do CAD (`.GetPoint` 16 + a assinatura `Editor editor` 115) | **131** | 6 |

**164 dos 216** comandos tem corpo de **8 linhas ou menos** — no original, o comando e, na pratica, so montar a tela —,
e **23** passam de 60 linhas (os candidatos de verdade: `CorrigeInterligacao` 216, `AtualizaOpcionaisDoCabo`
204, `CriaJigCloud` 186). O que vem do reverso e a **declaracao** (as 127 telas com os 3431 campos, a barra
com os 9 paineis e 121 botoes, os textos da `mMensagem`, os icones, os 99 comandos gerados na rodada 128); a
**regra** e reescrita, porque traduzir o corpo 1:1 traria o runtime VB, o Access, o clique do `MsgBox` e a
licenca junto — e porque o decompilador nao devolve a intencao (foi ele que escreveu
`RenomearPaginasToolStripMenuItem` com o texto **"Renumerar Paginas"**). O `-Acoplamento` e o termometro
para achar onde a traducao e quase 1:1: entre os pendentes que ele lista, o `LeAtributos` (122 linhas) e o
unico que so toca `Conversions`/`DeclaracoesGeral`. A leitura completa: `docs/AUDITORIA.md` §0.

**Rodada 132 — o painel de cobertura: `scripts/cobertura-do-reverso.ps1` (+ `docs/AUDITORIA.md` §0).**
O dono do produto perguntou varias vezes "o que ja cobrimos e o que falta" e a resposta nunca era
concreta. A causa foi encontrada: o inventario existe (§7.6, das rodadas 105-117) mas **nao estava
cruzado com o codigo atual** — ele ainda marcava como pendentes o `RENPAGA` (a regra foi portada nas
rodadas 125/129), o `APAGARXDATA` (entregue na 127) e o `PesquisaBlocos` (entregue na 128). Agora a
pergunta tem instrumento, e ele mede de tres fontes que ja existem no repo: o mapa dos 216 comandos, os
`[CommandMethod]` do plugin (separa os **escritos a mao** dos **gerados** da rodada 128) e os `frm*.cs`
do decompilado (com o tamanho de cada tela).

```
powershell -ExecutionPolicy Bypass -File scripts/cobertura-do-reverso.ps1           # o painel
powershell -ExecutionPolicy Bypass -File scripts/cobertura-do-reverso.ps1 -Listas   # + as listas nominais
```

| | medido |
|---|---|
| comandos do reverso | **216** (**121** abrem janela, **95** regra de desenho pura) |
| comandos que o plugin responde | **152** = **53** escritos a mao (40 do reverso + 13 nossos) + **99** gerados (so abrem a tela) |
| do reverso **sem nada** no plugin | **77** = **17** abrem janela (15 variantes + `IMPBD` + `ONSPL`/`TROCAPN`) + **60** de regra pura — que **nao** sao 60 regras faltando: o §7.6 ja triou cada um |
| telas | **127** (**103** alcancadas: **5** com regra, 98 so casca; **19** sao sub-janelas que nenhum comando abre) |

**A leitura e a fila recomendada ficam no `docs/AUDITORIA.md` §0**: a **familia dos atributos** (5
comandos, 277 linhas — o bloqueio "sem a tela nao ha o que aplicar" caiu na rodada 127), o
**`CorrigeInterligacao`** (216 linhas, fecha o laco do `VERIF` por pagina inteira) e **ligar as 3 telas
de compilacao** (`FIA`/`INT`/`JMP`, cuja regra ja existe) — mais o trivial que some da lista (registrar
o nome `RENPAGA`). O que **nao** e pendencia tambem esta la: as 15 variantes, a frente 11
(ambiente/licenca), os 3 destrutivos com `MsgBox` e as 19 sub-janelas de exportacao DWG/Excel.

**Rodada 131 — os namespaces acompanham as pastas (`Mapas`, `Barra`, `Folhas`, `Telas`).**
A rodada 130 deixou as pastas separadas com todos os tipos no namespace antigo; o dono do produto pediu
o casamento (pasta = namespace), que e a convencao do .NET. O que dava trabalho nao foi o `using` — foi
os **emissores**:

```
Positron.Data.Interface.Mapas                 <- os tres mapas + os .Dados.cs gerados
Positron.Plugin.Interface.Barra               <- BarraDeFerramentas
Positron.Plugin.Interface.Folhas              <- PaletaDeFolhas, FolhasControle
Positron.Plugin.Interface.Telas               <- RenderizadorDeTelas, SeletorDeTelas, JanelasDoOriginal,
                                                 ILigacaoDeTela, LigacoesDasTelas, ControlesDaTela, Ligacao*
Positron.Data.Interface / Plugin.Interface    <- so o compartilhado (MensagensDoReverso, IconesEmbutidos)
```

**Os tres extratores foram junto** (`namespace Positron.Data.Interface.Mapas` nos gerados, e o
`ComandosDoOriginal.Gerado.cs` chamando `Interface.Telas.JanelasDoOriginal`): se o gerador ficasse no
namespace antigo, a proxima regeracao criava a `partial class` em **dois** namespaces e o build
quebrava. No consumo entraram `using Positron.Data.Interface.Mapas;` (cinco arquivos do plugin e tres
testes), os comandos passaram a nomear `Interface.Barra.BarraDeFerramentas`,
`Interface.Folhas.PaletaDeFolhas` e `Interface.Telas.*` (o `Positron.Plugin` enxerga
`Positron.Plugin.Interface` mas **nao** as subpastas) e o `using Positron.Data.Interface;` que perdeu
uso foi removido.

**Checagens (as duas builds e o CAD):** 0 avisos / 0 erros nas duas plataformas, `plugin:test` **591**
e o E2E no `Funcional.dwg` com os **mesmos** numeros de antes — barra `121 botao(oes) … 83 ligado(s),
38 desativado(s); 76 abrem uma janela`, `JANELAS: 127 de 127 … Ligacoes: 2 de 127`, `APAGARXDATA: …
CONSTRUTOR (4).`, `STATBORN: 31/199/17` e `DUPCAD` abrindo a `frmDuplicarCaderno`.

**Rodada 130 — a interface organizada: nomes, pastas e o registro das ligacoes.**
O dono do produto perguntou se era ideal os arquivos se chamarem "Reverso" e lembrou o que quer: a
interface **montada** antes de integrar os metodos **um a um**. As duas coisas ficaram resolvidas com
uma regra escrita e com a estrutura — nada aqui mudou comportamento (os testes continuam 591 e os
numeros no desenho sao os mesmos).

**A regra de nomes** (vale para o que vier):

- **`DoReverso` / `DoOriginal` so em dado transcrito do original** — `BarraDoReverso`,
  `ComandosDoReverso`, `FormulariosDoReverso` (os tres **gerados** por script),
  `MensagensDoReverso` (a tabela escrita da `mMensagem`) e o recorte `mensagens-pt.txt`. Neles o nome
  e o aviso de "nao edite a mao, a fonte e o descompilado".
- **Codigo nosso leva o nome do que ele e**; a origem fica no XML doc (que o editor ja mostra):
  `JanelaDoReverso` → **`RenderizadorDeTelas`**, `IconsDoReverso` → **`IconesEmbutidos`**,
  `LigacoesDoReverso` → **`LigacoesDasTelas`**.
- Nomes de produto ficam como estavam: `BarraDeFerramentas`, `PaletaDeFolhas`, `FolhasControle`,
  `SeletorDeTelas`, `JanelasDoOriginal`.

**As pastas** (e os **namespaces acompanham**, desde a rodada 131 — o bloco acima conta a migracao; o
`.csproj` e SDK-style, entao mover nao exigiu edicao de projeto):

```
Positron.Data/Interface/                     Positron.Plugin/Interface/
  Mapas/          <- gerado + recorte          Barra/   BarraDeFerramentas.cs
    BarraDoReverso{,.Dados}.cs                 Folhas/  PaletaDeFolhas.cs, FolhasControle.cs
    ComandosDoReverso{,.Dados}.cs              Telas/   RenderizadorDeTelas.cs, SeletorDeTelas.cs,
    FormulariosDoReverso{,.Dados}.cs                     JanelasDoOriginal.cs, LigacoesDasTelas.cs,
    mensagens-pt.txt                                     LigacaoDoFrm*.cs, ControlesDaTela.cs,
  MensagensDoReverso.cs                                  ILigacaoDeTela.cs
                                               IconesEmbutidos.cs
```

Os tres extratores foram ajustados para escrever nos caminhos novos (`-Dados`, `-Mensagens`,
`-Comandos`). **Os caminhos citados nas rodadas 127 a 129** (`Positron.Data/Interface/…`) passaram a
`Positron.Data/Interface/Mapas/…`: os comandos sao os mesmos, so mudou o destino.

**Integrar o metodo de uma tela — a receita (1 arquivo + 1 linha):**

1. a regra pura ja tem de existir no `Positron.Data` **com teste** (a regra de ouro do §7.7) e o
   adapter que le/escreve o desenho, se a regra olhar o desenho;
2. crie `cad-plugin/Positron.Plugin/Interface/Telas/LigacaoDoFrmXxx.cs` copiando o molde
   (`LigacaoDoFrmPesquisaXdatas.cs`) e mantenha o `namespace Positron.Plugin.Interface.Telas` (o
   namespace acompanha a pasta, rodada 131): implemente `ILigacaoDeTela`, devolva o **nome do `frm*`**
   do original em `NomeDaTela` e ligue os controles **pelo `Name` do designer** (o mapa
   `docs/reverso-formularios.txt` tem o nome e a caixa de cada um) com `ControlesDaTela.Achar<T>`;
3. acrescente **uma linha** na lista `Todas` do `LigacoesDasTelas`;
4. rode `npm run plugin:build` e, no CAD, o comando do original (ex.: `APAGARXDATA`) — a tela abre
   fiel e a ligacao reporta na linha de comando o que leu/gravou;
5. confira a conta: `pzTelas` (ou o botao *Montar todas* do seletor) imprime
   `Ligacoes: N de 127 tela(s) com regra (…)` — e, se o `NomeDaTela` **nao existir** no mapa, a mesma
   linha termina em `ATENCAO: frmX nao esta(o) no mapa de telas.` (uma ligacao com o nome errado
   ficaria muda para sempre; a guarda foi conferida **quebrando o nome de proposito**:
   `Ligacoes: 2 de 127 tela(s) com regra (frmPesquisaXdatas, frmNaoExiste). ATENCAO: frmNaoExiste
   nao esta(o) no mapa de telas.`, com o nome restaurado depois).

Nada disso toca nas telas ja ligadas, e uma tela **sem** ligacao abre do mesmo jeito: fiel e sem
comportamento. As duas diferencas deliberadas de sempre: onde o original mostra `MsgBox`, o recoder
escreve na **linha de comando** (o `MsgBox` trava um script); e onde a tela lia o banco, entra a
**regra do recoder** que o comando equivalente ja usa e ja foi medida.

**O que a rodada mediu (ZWCAD 2026, `Funcional.dwg` real, DLL recompilada):**

```
JANELAS: 127 de 127 tela(s) do reverso montada(s), nenhuma falha. Ligacoes: 2 de 127 tela(s) com regra (frmPesquisaXdatas, frmEstatisticaDeBornes).
APAGARXDATA: 1 app name(s) de XData na grade (só os de terceiros): CONSTRUTOR (4).
STATBORN: 31 régua(s), 199 usados simples, 17 de reserva simples, 0 usados duplos e 0 de reserva duplos (216 no total; 199 borne(s) no desenho e 17 reserva(s)).
```

sao os **mesmos numeros** da rodada 127 (as duas ligacoes passaram pelos arquivos novos e nao
mudaram o resultado). E a prova de que a mudanca de pasta nao mexeu no que e gerado: os tres
extratores regeraram **byte a byte iguais** — no `git status`, os mapas e o
`ComandosDoOriginal.Gerado.cs` saem como *rename*, nao como modificacao.

**Checagens:** `plugin:build:all` **0 avisos / 0 erros** (ZWCAD e AutoCAD), `plugin:test` **591** e
`scripts/cad-zwcad-smoke.ps1` com exit 0.

**Nota para quem ler os blocos abaixo:** os das rodadas 123 a 129 citam os nomes e os caminhos de
então — `JanelaDoReverso`, `IconsDoReverso`, `LigacoesDoReverso` e `Positron.Data/Interface/<mapa>`.
São o que os arquivos se chamavam naquele momento; hoje são `RenderizadorDeTelas`,
`IconesEmbutidos`, `LigacoesDasTelas` + `Ligacao*`, e os mapas estão em `Interface/Mapas/`.

**Rodada 129 — a barra de ferramentas do original (9 paineis, 121 botoes) e o menu das folhas pelo designer.**
O dono do produto perguntou o quanto a **barra** que aparece no ZWCAD e o **controle de folhas** estao
fieis ao original — e, em especial, se a barra ja **chama as outras janelas**. As duas respostas sairam
de medicao contra o `Ribbon.cs` e o `uscPaginas.cs` do decompilado, nao de opiniao.

**O que a barra do original e** (contra o que o recoder montava a mao):

| | antes (rodada 121) | agora |
|---|---|---|
| estrutura | 2 paineis inventados (Projeto / Interligacao) | os **9 paineis** do original, na ordem de `CreateRibbon()` (dois) e `CreateRibbon2()` (sete) |
| botoes | 12 (so os comandos que existiam) | os **121** do original: **83 ligados** (o comando existe), **38 desativados** com o comando que falta na dica |
| janelas | 8 comandos do recoder num painel extra | **76** botoes do original abrem uma tela do mapa da rodada 128, mais os 8 do recoder |

**Como a barra sabe o que ja funciona** — os dois campos sao **calculados**, nao digitados: `Coberto` e
"existe um `[CommandMethod]` com esse nome no plugin" (varredura dos `.cs`, inclusive os **gerados** da
rodada 128) e `AbreJanela` e o cruzamento com `docs/reverso-comandos.txt`. E por isso que os 121 botoes
entraram **sem nenhum codigo de tela novo**.

**A extracao estrutural** (o script foi reescrito; antes ele lia a lista achatada):

```
powershell -ExecutionPolicy Bypass -File scripts/extrair-barra-do-reverso.ps1
# aba: CENG.ID_Elet (Eletron)
# paineis: 9
# botoes: 121
# cobertos pelo plugin: 83
# cobertos que abrem janela: 76
# chamadas de ajudante no Ribbon.cs: 120 + 1 launcher(s) = 121
# mapa:  docs/reverso-barra-do-original.txt          (a evidencia linha a linha)
# dados: cad-plugin/Positron.Data/Interface/BarraDoReverso.Dados.cs
```

**As tres armadilhas da extracao** (medidas, e as tres davam barra a menos):

1. **a lista achatada.** A primeira versao pegava os pares `"rotulo", "COMANDO "` por expressao
   regular solta no arquivo e achava **42** — sem painel, sem ordem e com os botoes de icone de fora.
   O original monta cada botao por um dos quatro ajudantes (nome ofuscado, corpo nao) e o
   `CreateRibbon` chama um metodo por painel: so lendo a estrutura saem os **9 paineis / 121 botoes**.
2. **a assinatura que mentia.** Cinco dos nove paineis **retornam** a `RibbonPanelSource` em vez de
   `void` (o `CreateRibbon2` usa o retorno); exigir `void` na assinatura deixava exatamente esses
   cinco de fora e a barra saia com **4 paineis e 33 botoes**.
3. **as assinaturas contadas como chamadas.** As **quatro assinaturas** dos ajudantes no fim do
   arquivo (`private void Nowp1LGUQxQ(ref RibbonButton P_0, ...)`) casam com o mesmo padrao das
   chamadas e a conferencia dava **124** para 121 botoes. Declaracao nao e chamada: descartadas, a
   conta fecha com o arquivo — **120** chamadas + **1** `DialogLauncher` (o `CFG` da Configuracao,
   o unico do arquivo) = **121**.

**O menu das folhas saiu do designer, item a item** (o `cmStrip1` do `uscPaginas`): os **14 itens na
ordem do designer**, com o texto que o **construtor** do original grava por cima do literal do designer
(a `mMensagem`) e os icones do produto — Multiselecao, Alternativo, Nova Pagina, Inserir, Excluir
Paginas, **Renumerar Paginas**, Editar Unidade, Editar Alternativo, Editar Titulos, Editar Revisoes
(com as duas revisoes dentro) e o combo **Folha** com os seis formatos literais (`12`, `012`, `0012`,
`00012`, `000012`, `0000012`). O que ainda nao tem regra portada fica **desabilitado com o motivo** no
tooltip, e o `Alternativo` faz o que o original faz no clique (esconde a coluna e o item
`Editar Alternativo`).

**Um erro de fidelidade corrigido aqui:** o campo do designer chama-se `RenomearPáginasToolStripMenuItem`,
mas a `mMensagem[1, 22]` — o texto que o usuario le — e **"Renumerar Paginas"**, e a regra por tras e o
`RENPAGA` (renumerar o caderno). O recoder escrevia "Renomear Paginas" desde a rodada 122; agora o rotulo
do menu, o botao do rodape e um teste dizem o que a operacao faz.

**Medido no ZWCAD 2026** (banco novo, `scripts/cad-zwcad-smoke.ps1`):

```
Positron carregado. Digite ELET para começar — ELET abre a paleta de folhas (FOLHAS também).
Barra: aba "Positron" com 10 painel(is) — 121 botão(ões) do original (83 ligado(s), 38 desativado(s); 76 abrem uma janela) e 8 do recoder.
Positron — paleta de folhas com 0 página(s) (ancorada no CAD).
DUPCAD: "Duplicar Caderno" (frmDuplicarCaderno) aberta no CAD — 5 controle(s).
```

Os **10** paineis sao os 9 do original + o nosso (os comandos do recoder que nao existem na barra de la:
`ELET`, `FOLHAS`, `JANELAS`, `JANELA`, `VERIF`, `ELETCFG`, `pzDiag`, `pzTelas`). O `DUPCAD` foi rodado de
proposito: e um botao que a barra **ativa** (comando coberto) e que **abre tela** — o caminho que o dono
do produto perguntou se funcionava.

**O que continuou diferente do original, de proposito** (esta escrito no codigo e no mapa): a aba e
`POSITRON.ID_Positron` / "Positron" (o id e o titulo de la — `CENG.ID_Elet` / "Eletron" — ficam no
`BarraDoReverso`), e os botoes pequenos, que no original mostram **so o icone** (o texto vai na dica),
aqui mostram o texto curto, porque a nossa barra tem menos botoes por painel e o rotulo ajuda a chamar a
janela certa.

**Testes:** `BarraDoReversoTests` e `FolhasDoReversoTests` (**+19**, `plugin:test` **591**), com o
cruzamento que interessa travado: todo botao que diz abrir janela tem o comando **e** a tela no outro
mapa, os **83/76** sao fixados, e o unico `Dialogo` da barra e o `CFG`. As duas builds 0 avisos; **a
validacao visual da barra e da paleta e do dono do produto**.

**Rodada 128 — frente 12: o mapa comando -> janela (99 comandos do original abrem as telas no CAD).**
A rodada 127 decodificou as **127** telas; faltava o que o original usa para **chegar** nelas. No
`Eletron4Z` o comando e fino de proposito: o corpo monta a janela (`new frmGerenciadorDWG();`) e a
propria janela abre **dentro do CAD** (`Application.ShowModelessDialog(this)` no construtor do
`frm*`). Entao a lista dos `[CommandMethod]` diz **quais nomes abrem quais telas** — e agora o
plugin responde por eles.

**Como rodar a extracao** (nao precisa do de4dot nem da DLL: le o decompilado direto):

```
powershell -ExecutionPolicy Bypass -File scripts/extrair-comandos-do-reverso.ps1
# comandos: 216 | abrem janela: 121 | so abrem a janela: 119 | com variante: 15
# comandos novos no plugin: 99
# mapa:  docs/reverso-comandos.txt
# dados: cad-plugin/Positron.Data/Interface/ComandosDoReverso.Dados.cs
# comandos do plugin: cad-plugin/Positron.Plugin/ComandosDoOriginal.Gerado.cs
```

O script tem um modo de inspecao (`-Amostra`) que imprime a classificacao sem escrever arquivo —
ele foi o que separou, com o olho em cada linha, os tres grupos: os que **so abrem a janela**, os que
abrem **uma variante** (`new frmRelatorio_DICemig(3)`) e os que **fazem mais** alguma coisa.

**As duas armadilhas da varredura** (as duas custaram uma rodada de numeros errados):

1. **o corpo que abre com guarda.** O extrator procurava a chave de abertura e **avancava** a linha
   antes de contar o nivel, entao o corpo comecava ja dentro do bloco e um comando como o
   `DEF` — cujo corpo e `if (clsRegua.VerificaRegua()) { new frmDefinicao(); }` — fechava na
   **primeira** linha do corpo e perdia o `new frmDefinicao()`. Sintoma: ele saia do mapa como "nao
   abre janela" (e o `EDBORN` com ele). A correcao e parar **na** linha da chave.
2. **o proprio gerado na conta do "ja no plugin".** O script varre o plugin para nao registrar duas
   vezes um nome que o recoder ja tem; a primeira rodada gerou 96 comandos e a segunda, **3** —
   porque o `ComandosDoOriginal.Gerado.cs` da primeira entrou na propria varredura e todos os
   comandos passaram a constar como "ja implementados". A regra agora exclui `*.Gerado.cs`.

**O que o de4dot diz do assembly original** (a pergunta "existe mais algo codificado?"):

```
tools/de4dotEx/de4dot.exe cad-plugin/reverso/Eletron4_ZWcad/DLL/Eletron4Z.dll -o <fora do projeto>
# Detected .NET Reactor
# DNR decrypterType: V2 / V3 / V4  (o V4 devolve System.String - a tabela de strings cifradas)
```

- o original **tinha** as strings cifradas pelo **.NET Reactor** e o de4dot as decifra;
- **a copia de trabalho ja esta decifrada:** no `decompiled-cleaned` nao sobra **nenhuma** chamada ao
decifrador (o `guwp00C390P`/`GG5BlYp0wNmlGYMYs7HP` que aparece no `decompiled/` pre-limpeza
**desapareceu**), e a classe `<Module>` ficou **vazia** (3 linhas, sem metodo) — ou seja, os
literais que lemos (os textos do designer, os nomes de recurso, os indices do `mMensagem`) sao o
**plaintext**;
- os **3 recursos sem extensao** (`f0QEEDDabf39S0voTp.*`, `lQO5NCp2fwKETZ8xnu.*`,
  `V9DgpHoXKSwaPCP9VK.*`) sao o **payload do proprio ofuscador**: byte aleatorio, nenhum
  `GetManifestResourceStream` no reverso inteiro — **nada os le** (nao ha o que decodificar);
- os unicos `Convert.FromBase64String` do reverso estao nos stubs de **licenca**
  (`CProtect`/`cProtectNuvem`), que o recoder **nao porta** de proposito (§7.5 do plano);
- **achado desta rodada, ainda nao decodificado:** o `Construtor4Z.dll` (2,3 MB) tem **dois**
  formularios proprios (`frmConstrutor` e `frmSplash`) e **nao** esta descompilado em nenhuma copia
  de trabalho — decodificar essa janela exige descompilador de IL (o de4dot **limpa**, nao gera C#).
  Fica registrado como a proxima frente de decodificacao.

**Como o plugin usa o mapa:** o `ComandosDoOriginal.Gerado.cs` (gerado, 99 metodos) tem um
`[CommandMethod]` por comando **ligavel** e o corpo e so o **nome** — quem sabe a tela e o mapa do
`Positron.Data.Interface.ComandosDoReverso`, entao mapa e comando saem de uma fonte so. O
`JanelasDoOriginal.Abrir` abre cada janela pelo `JanelaDoReverso` e reporta com o **nome do comando
na frente da linha**. Ficam **de fora, de proposito:** as **15 variantes** (abrir a tela padrao no
lugar delas seria mentir — a construcao com o argumento fica no mapa) e os **5** que o recoder ja
tem com regra propria (`APAGARXDATA`, `FIA`, `INT`, `SYNCD`, `STATBORN`).

**Medido no ZWCAD 2026** (banco novo, sem fixture):

```
JANELAS: 127 de 127 tela(s) do reverso montada(s), nenhuma falha.
GERDWG: "Gerenciador de DWGs do Projeto" (frmGerenciadorDWG) aberta no CAD - 7 controle(s).
DEF: "Atribuir Definicao" (frmDefinicao) aberta no CAD - 15 controle(s).
BORN: "Inserir Bornes" (frmBornes) aberta no CAD - 37 controle(s).
JANELAS: seletor aberto com 127 tela(s) do reverso.
```

O seletor ganhou a coluna **Comando(s) do original** (com a construcao entre parenteses quando o
comando abre uma variante): e a mesma lista do mapa, exibida onde se escolhe a tela.

**Rodada 127 — frente 12: as 127 telas do reverso decodificadas e abertas no CAD (os `frm*`).**
O dono do produto pediu o recode do maximo de `frm*` — os formularios que abrem **dentro do CAD** —
e perguntou se, com o que existe, da para saber a formatacao correta das janelas. **Da**, e isso foi
medido antes de escrever codigo:

- os **127** `frm*` do `decompiled-cleaned` guardam o metodo do designer inteiro (o
  `[DebuggerStepThrough]` com o `SuspendLayout()`);
- o de4dot **nao** ofuscou os nomes de controle nem os valores das propriedades — so os campos
  privados e os nomes de metodo. A formatacao nao se perdeu: da para le-la, nao adivinha-la.

**Como rodar a extracao** (nao precisa do de4dot nem da DLL: le o decompilado direto):

```
powershell -ExecutionPolicy Bypass -File scripts/extrair-formularios-do-reverso.ps1
# formularios: 127 | campos: 3431
# mapa:  docs/reverso-formularios.txt
# dados: cad-plugin/Positron.Data/Interface/FormulariosDoReverso.Dados.cs
```

**Como a tela fica de verdade:** `docs/reverso-capturas.txt` liga cada captura do original rodando
(`cad-plugin/reverso/captura_das_janelas/*.png`) ao `frm*` e ao comando. Para conferir uma tela
reconstruida, abra a captura ao lado do `JANELA` com `POSITRON_JANELA=<frm*>` — o mapa diz o que o
designer declara, a captura mostra o que o construtor e a carga mudam depois dele.

E as imagens que so existem no `.resx` de cada formulario (o `Resources` global nao as tem — elas
sao um `Bitmap` serializado pelo `BinaryFormatter`, decodificado com o mesmo caminho do
`ResourceReader`):

```
powershell -ExecutionPolicy Bypass -File scripts/extrair-imagens-dos-formularios.ps1
# imagens extraidas: 34   (cad-plugin/lib/Icons: 348 -> 363)
```

**As quatro armadilhas do designer, todas resolvidas e medidas:**

1. **a `mMensagem` por indice** — inclusive a **concatenacao do VB**
   (`Conversions.ToString(Operators.ConcatenateObject(mMensagem[1, 595], " - "))`, que o
   `frmTrocaEditaBlocos` usa no titulo); o que **so existe em execucao** (um nome de painel buscado
   no banco) vira o marcador `{expressao}`, nunca um valor inventado;
2. **os icones** pelo nome do recurso (`Resources.Delete_32` -> `lib/Icons/Delete_32.png`, extraidos
   nas rodadas 124 e 127);
3. **as colunas das grades** — o original **nao** as cria no designer e sim nas rotinas de carga
   (`dg.Columns.Add("", mMensagem[1, 786])`), deduplicadas por grade+cabecalho: **842 campos**;
4. **os textos que o designer deixa como placeholder** (o `Label1` com texto `"Label1"`), que o
   original preenche nas rotinas de carga: **508** campos com o texto igual ao nome cairam para
   **157** — so os que continuam sem atribuicao resolvivel ficam como o designer deixou.

**Uma quirk de fidelidade que vale registrar:** o designer do original tem controle em **coordenada
negativa** (`BTCorrigaPortasDiscrepantes` em `Location = (-18, ...)`) — por isso o "o designer nao
pos" e `Campo.NaoDefinido` (`int.MinValue`) e nao `-1`, e o renderizador **nao** faz clamp.

**No plugin:** o `JanelaDoReverso` monta a tela pelo mapa (aninhamento por `Pai`+`Ordem`, abas,
itens de menu, colunas, ancoras, fontes, cores e os icones) e a abre **modeless no CAD** com o
`Application.ShowModelessDialog` do original (121 chamadas no reverso; o stub do AutoCAD ganhou o
metodo e as referencias de WinForms, para o gate de compilacao seguir valendo). O `SeletorDeTelas`
(`JANELAS`) lista as 127 com filtro; o `JANELA` abre uma pelo `POSITRON_JANELA`; o `pzTelas` monta as
127 e descarta (a prova dentro de um script, sem abrir nada). As telas com regra pronta tem o
**comando do original**: `APAGARXDATA`.

**Medido no ZWCAD 2026** (harness por `/b`; as duas builds com 0 avisos):

| passada | linha do `POSITRON_LOG` |
|---|---|
| `pzTelas` (com o fixture) | `JANELAS: 127 de 127 tela(s) do reverso montada(s), nenhuma falha.` |
| `JANELA` com `POSITRON_JANELA=frmConfiguracaoGeral` | `JANELA: "Configuração Geral" (frmConfiguracaoGeral) aberta no CAD — 110 controle(s).` |
| `APAGARXDATA` no `Funcional.dwg` real | `APAGARXDATA: 1 app name(s) de XData na grade (só os de terceiros): CONSTRUTOR (4).` |
| `STATBORN` + a tela ligada, no `Funcional.dwg` | `STATBORN: 31 régua(s), 199 usados simples, 17 de reserva simples…` |

O **`CONSTRUTOR (4)`** e o app name de terceiros que o desenho real carrega — a grade do
`frmPesquisaXdatas` leu o ModelSpace de verdade. Os **31/199/17** sao os mesmos numeros das rodadas
51 e 108: a tela ligada **confere** o comando, nao substitui a medicao dele.

**As duas ligacoes desta rodada** (regra pronta -> comportamento, no `LigacoesDoReverso`):

- **`APAGARXDATA`** abre o `frmPesquisaXdatas` com a grade vinda do `XDatasDoDesenho` (a regra: a
  lista fixa dos **32** app names do produto, usada como **filtro** — e o construtor do original
  ainda **esconde** o `CkXdataEletron` desmarcado, ou seja o filtro esta sempre ligado) mais o
  `XDatasDoCad` (le o **ultimo `1001`** do XData da entidade, em maiusculas, como o
  `LeTodosOsXdatasDoCaderno`, e grava a **marca unica** no apagar, o mesmo quirk do
  `apagaXDataTerceiros`);
- o **`frmEstatisticaDeBornes`** mostra a estatistica do `STATBORN` na grade por regua com os
  **sete totais** do rodape (usados/reserva simples e duplos, o total simples, o total duplo e o
  geral) sobre as linhas **selecionadas** (ou todas, quando nada esta selecionado: o
  `calculaSelecionado`), com o `TBPesquisa` filtrando por nome/painel/indice.

**Duas diferencas deliberadas:** onde o original mostra `MsgBox`, o recoder escreve na **linha de
comando** (um `MsgBox` num script nao tem quem o feche); e as **colunas** da grade da estatistica
nao estao no designer nem nas rotinas do formulario (o original as cria no `clsReguasDeBornes`,
que o recoder nao porta), entao entram as do relatorio do proprio recoder.

**Testes:** +23 (`plugin:test` **555**) — o mapa das 127 telas (contagens golden, integridade
"todo pai existe", as duas telas de fundo sem controle, os titulos resolvidos da `mMensagem`, o
marcador de execucao e a coordenada negativa preservada) e a regra do `XDatasDoDesenho` (a lista
do produto, o teste ordinal, a ordem da primeira aparicao, o filtro do `CkXdataEletron`).

**O teste visual das telas e do dono do produto** (o harness abre, mas ninguem olha o desenho).

**Rodada 126 — a fatia 3: a pagina que cabe entre duas (o "Inserir").**
O `Pagina.calculaNovaPagina` do reverso (170 linhas) foi portado **ramo a ramo** para a classe
`NovaPaginaEntre`, com o `Conf.PassoPagina` (que entrou na configuracao, padrao 1):

- cada lado e partido em numero/letra (o `Asc` da ultima letra e o prefixo numerico; no ramo
  numerico o original usa o **numero inteiro**, no alfanumerico o `Mid(1, len-1)`);
- as **quatro** combinacoes (numerico x alfanumerico) com a mesma casca — "cabe no passo? entao a
  letra, senao o proximo numero; nao cabe? entao `num4 + Passo`";
- posterior **vazio** vale o sentinela `1000000` (o fim) — e por isso o "Nova Pagina" tambem
  tem a sua conta pronta;
- saida: `PgNum`, `PgAlfa` (vazia quando o codigo e 64), `Pagina` e `PgDec`.

**O que o portou ensinou (e os testes fixam):** o caso `0B` do ramo alfanumerico/alfanumerico e do
proprio reverso (o numero invalido que os chamadores tratam), e o passo so aparece quando a
distancia entre as paginas passa dele.

**No menu:** o **Inserir** ficou **ligado** — ele pega a pagina selecionada e a **proxima** da lista,
calcula a nova pela regra e **informa** ("entre X e Y a nova pagina e Z"); a criacao do layer e do
formato entra na fatia 6, junto com o "Nova Pagina".

**Testes:** +5 (vizinhas numericas → letra A; com espaco → o proximo numero; o sentinela do fim; o
passo do caderno; o ramo alfanumerico) — `plugin:test` **532**.

**Rodada 125 — o "Renomear Paginas" ligado na regra do RENPAGA.**
O menu de contexto das folhas tinha sete itens do reverso, todos desabilitados. Agora **um deles
funciona**, com a regra do original:

- **a regra pura** (`PaginasDoCaderno.SufixoValido` + `Renomear`): o sufixo tem de ser **um**
  caractere — um número ou uma letra **maiúscula** (o `Asc` entre 65 e 90 do `RENPAGA`, que
  recusa a minúscula e o alfabético com mais de um caractere) — e cada página vira
  `página + sufixo` (o `renumerarPaginasLote`);
- **o adapter** (`PaginasDoDesenho.Renomear`): renomeia os **layers** das páginas (o
  `LayerTableRecord.Name` que o reverso troca no lote) e devolve quantos renomeou;
- **na paleta**: um campo para o sufixo (padrão `A`), o botão **Renomear Páginas** no rodapé e o
  item do menu de contexto ligados na mesma operação; a grade recarrega depois.

Os outros três itens continuam desabilitados **com o motivo**, e agora se sabe exatamente por quê:

| item | por quê ainda não |
|---|---|
| Nova Página | o `criarUmaNovaPagina` do reverso depende do `capturaTitulos` (os blocos de formato/título da folha) — fatia 6 |
| Inserir | precisa do `calculaNovaPagina` (a página entre duas), que usa o `Conf.PassoPagina` |
| Excluir Páginas | é **destrutivo** (`ApagarElementosPagina` apaga os elementos e o layer) — entra com confirmação, como as rotinas destrutivas do original |

**Testes:** +3 (`SufixoValido` e a renomeação em lote, incluindo a recusa da minúscula e do
sufixo vazio) — `plugin:test` **527**.

**Rodada 124 — os icones do produto, extraidos e na barra.**
O de4dot limpou o codigo e o `ResourceManager` devolveu os `Bitmap`: sairam **348 icones**
(1,95 MB) para `cad-plugin/lib/Icons/` pelo script novo
`scripts/extrair-icones-do-reverso.ps1` (ele le os nomes dos acessores do proprio produto,
resolve as dependencias do assembly limpo e salva cada um em PNG).

**O mapa da barra ganhou o icone:** o `Ribbon.cs` atribui `image = Resources.X` antes de cada
botao, entao o script passou a extrair **(comando, rotulo, icone)** — 42 pares, agora em
`docs/reverso-barra-do-original.txt`:

```text
CAD    = CADERNO    | Caderno_32
GERDWG = GER DWG    | Database_Preto_32
REGH   = REGUAH     | ReguaH_32
PORT   = PORTA      | Portas_32
CBD    = CBD        | Comprimir_32
RESTPROJ = RESTPROJ | Sincroniza_32
```

**No plugin:** os 348 PNGs entram como **recursos embutidos** (`Positron.Icons.<nome>.png`) e o
`IconsDoReverso` os converte como o `Ribbon.getBitmap` do reverso (Bitmap → PNG em memória →
`BitmapImage`, com cache). Os botoes que temos usam o **icone do original** quando o comando
existe na barra dele (`CBD` = `Comprimir_32`, `RESTPROJ` = `Sincroniza_32`) e o **generico
`Item`** nos demais — que e exatamente o que o proprio reverso faz nos botoes sem icone proprio.

**Medido no ZWCAD 2026** (a DLL foi de 1,7 MB para **2,13 MB** com os icones embutidos):

```text
Barra: aba "Positron" com 12 botão(ões).
Positron — paleta de folhas com 16 página(s) (ancorada no CAD).
```

> **Sobre a ideia dos icones internos do CAD:** ela fica como **reserva** — como desta vez os
> originais sairam, nao foi preciso; se algum icone faltar (ou para os 30 comandos ainda nao
> portados), a biblioteca de imagens do proprio CAD e o caminho, e o `IconsDoReverso` ja cai no
> generico quando o nome nao existe.

**Rodada 123 — o de4dot no DLL original: os textos do produto, extraídos.**
O dono do produto apontou a ferramenta (`tools\de4dotEx`) e a pergunta certa: dá para pegar a
formatação do reverso em vez de inventar? **Dá** — e a receita ficou:

1. `de4dot.exe -d Eletron4Z.dll` → **.NET Reactor** detectado;
2. `de4dot.exe Eletron4Z.dll` → `Eletron4Z-cleaned.dll` (7,5 MB, 138 recursos com nome legível);
3. no assembly **limpo**, o `ResourceManager("Eletron4.Resources", asm)` com um `AssemblyResolve`
   apontando para as DLLs do ZWCAD devolve `GetString("Mensagens")` — a **tabela inteira**
   (118.390 chars; a seção `[PT]` tem **60.680 chars / 1982 entradas**, salva em
   `cad-plugin/Positron.Data/Interface/Mapas/mensagens-pt.txt`).

**Os textos do original que a interface usa** (chaves do `mMensagem[1, N]`):

| chave | texto | onde o original usa |
|---|---|---|
| 8 | **Páginas** | o título da `PaletteSet` (o `_pspag`) |
| 9 / 10 / 11 | **Página** / **Alternativo** / **Unidade** | as três primeiras colunas do `dg` do `uscPaginas` |
| 109..112 | **Caderno**, **Dispositivos**, **Configuração**, **Utilitários** | painéis da barra |
| 540 / 559 / 560 / 1549 | **Bornes**, **Fiação**, **Cabos e Veias**, **Construtivo** | painéis da barra |

E o **mapa da barra** (42 pares rótulo/comando do `Ribbon.cs`) ficou em
`docs/reverso-barra-do-original.txt`, extraído pelo script novo
`scripts/extrair-barra-do-reverso.ps1` — nele, dos nossos comandos, aparecem o `CBD`, o
`RESTPROJ` e o `GERDWG` (com os rótulos do original).

**O que mudou no recoder:** a paleta agora se chama **Páginas**; a grade tem as colunas
**Página / Alternativo / Unidade** (mais as técnicas `Pg`/`PgDecimal`, escondidas); a barra
passou a agrupar os nossos comandos **nos painéis do original** (Caderno, Fiação, Cabos e Veias,
Bornes, Utilitários) com os rótulos do reverso onde eles existem; tudo vindo da classe
`MensagensDoReverso`, que documenta a origem.

> **O que ainda não é 1:1:** os **ícones** (ficam nos recursos que o .NET Reactor protege — o
> de4dot limpou o código, mas as imagens continuam embutidas/compactadas nos três recursos
> ofuscados que sobraram) e os **42 rótulos** da barra só entram conforme os comandos forem
> portados (hoje temos 12 na barra).

**Rodada 122 — o carregador, a formatação do reverso e a descoberta dos recursos ofuscados.**
Três respostas para as perguntas do dono do produto.

**1. O carregador (o `ELET` não é exigido).** O `ELET` do reverso é um comando **vazio** dentro da
DLL: quem carrega a DLL é o **autoload** (ou um LISP). Então o pacote em
`install/Positron.bundle/` ganhou o `LEIA-ME.txt` e o **`Positron.lsp`**:

- **autoload** (recomendado): copiar a pasta para a `Support` do perfil — o
  `PackageContents.xml` faz o ZWCAD carregar a DLL na abertura e chamar o
  `IExtensionApplication` (a barra aparece sozinha, **sem digitar nada**);
- **por comando**: o `Positron.lsp` define `c:ELET`, que faz `(findfile "Positron.Plugin.ZWCAD.dll")`
  — acha a DLL **pelo nome**, sem procurar o caminho — dá o `NETLOAD` e abre a paleta de folhas.

**2. A formatação do reverso (o que dá e o que não dá).**

- do **código decompilado** dá para copiar a **estrutura e os rótulos literais**: o menu de
  contexto do `uscPaginas` (**Multiseleção**, **Nova Página**, **Inserir**, **Excluir Páginas**,
  **Renomear Páginas**, **Editar Unidade**, **Editar Alternativo**) e as colunas técnicas
  (`Pg`, `PgDecimal`) entraram no `FolhasControle`; a barra segue o `Ribbon.cs` (a aba com
  painéis e botões, cada botão com o `CommandParameter`);
- os **textos das mensagens** (os títulos dos painéis da barra e os três primeiros cabeçalhos da
  grade, que vêm do `mMensagem`) e os **ícones** estão nos **recursos ofuscados** da DLL original:
  verifiquei o `Eletron4Z.dll` (12 MB) e ele tem **6 recursos com nomes aleatórios** — não são
  extraíveis como texto. Por isso os rótulos descritivos e a ausência de ícones: é o único ponto em
  que pegar do reverso não é possível com o que temos (o instalador/imagens do produto resolveriam).

**3. O que a tela já mostra.** O menu traz os itens do reverso; os que dependem de **regra ainda não
portada** (Nova Página/Inserir = fatia 3 da frente 10; Excluir/Renomear = fatia 4) ficam
**desabilitados** com o motivo — é o roteiro: portar essas regras **acende** o menu.

**Medido no ZWCAD 2026** (passada `FOLHAS`, com o controle novo):

```text
Positron carregado. Digite ELET para começar — ELET abre a paleta de folhas (FOLHAS também).
Barra: aba "Positron" com 12 botão(ões).
Positron — paleta de folhas com 16 página(s) (ancorada no CAD).
```

**Rodada 121 — frente 11, fatias 3 e 4: a paleta de folhas e a barra de ferramentas.**
Duas correções pedidas pelo dono do produto: **a janela de folhas era uma janela de sistema
operacional** (roubava o foco e não dava para usar o CAD) e **a barra não existia**.

**A API (pesquisada no reverso):** o ribbon vem de `ZwSoft.Windows` (`ComponentManager.Ribbon`,
`RibbonTab`/`RibbonPanel`/`RibbonPanelSource`/`RibbonButton`) e a paleta de
`ZwSoft.ZwCAD.Windows` (`PaletteSet`, `DockSides`) — os dois no `ZdWindows.dll`, que o
.csproj do reverso referencia; o botão roda o comando pelo `ICommand` (`AdskCommandHandler`)
lendo o `CommandParameter` e chamando `SendStringToExecute`; e o `DockEnabled`/`Dock` são
`DockSides` (o reverso usa `(DockSides)20480` e `(DockSides)4096`).

**O que entrou:**

- `FolhasControle` (o `uscPaginas`: um `UserControl` com a grade e o recarregar) +
  `PaletaDeFolhas` (a `PaletteSet` ancorável, uma instância por sessão) — a janela de OS foi **removida**;
- `BarraDeFerramentas` — a aba `Positron` com dois painéis (Projeto: `ELET`, `FOLHAS`, `FIA`,
  `INT`, `VERIF`, `SYNCD`; Interligação: `SYNCV`, `RECRIACABOS`, `STATBORN`,
  `CBD`, `RESTPROJ`, `pzDiag`) e o `ComandoDoBotao` (`ICommand`) que manda o
  comando para a linha de comando;
- o `Plugin.Initialize` cria a barra no load; o `ELET`/`FOLHAS` abrem a **paleta**.

**Ferramenta:** o `ZdWindows.dll` foi **vendorizado** em `cad-plugin/lib/ZWCAD/2026/` (como os outros dois
DLLs da API) e o csproj passou a referenciá-lo, com `WindowsBase`/`PresentationCore`/
`PresentationFramework`/`System.Xaml` (o ribbon deriva de `Control` do WPF).

**Medido no ZWCAD 2026** (a passada `FOLHAS`):

```text
Positron carregado. Digite ELET para começar — ELET abre a paleta de folhas (FOLHAS também).
Barra: aba "Positron" com 12 botão(ões).
Positron — paleta de folhas com 16 página(s) (ancorada no CAD).
OK: plugin carregado no ZWCAD 2026
```

A **barra** entra no load, a **paleta** abre com as 16 folhas e **o teste visual** (a barra e a
paleta ancoradas no CAD) é do dono do produto.

**Rodada 120 — frente 11: o shell do plugin (o arranque, a janela de folhas e o autoload).**
Pesquisa no reverso, com evidência:

| peça | onde | o que faz |
|---|---|---|
| o arranque | `myEletron.cs@@I@@IExtensionApplication@@, @@Initialize()@@` | o CAD chama no load |
| o arranque de verdade | `Iniciar.cs@@IniciarApp()@@` | splash, coleções, `Ribbon.CreateRibbon/CreateRibbon2` e os recursos |
| a barra | `Ribbon.cs@@CreateRibbon@@(50)/@@CreateRibbon2@@(83)` | abas/painéis/botões |
| a janela de folhas | `Comandos.cs:1454-1476` | `PaletteSet` + `uscPaginas`, ancorável, `CarregaPG()` |
| o comando `ELET` | `Comandos.cs:49-52` | **vazio** no reverso |
| a interface | o `.csproj` do reverso | referencia `ZdWindows` (está no diretório do ZWCAD 2026) |

**O que entrou (fatias 1, 2 e 5):**

- a mensagem do shell entrou no **`Plugin.Initialize()`** — o `IExtensionApplication` que **já existia** no projeto (e que os smokes procuram pela string `Positron carregado`): a DLL **se apresenta no load**, sem depender de digitar comando; eu tinha criado um **segundo** `IExtensionApplication` e o CAD chama **um só** — o duplicado foi **removido** (lição registrada);
- `PaginasDoDesenho` (o I/O: os layers que a regra aceita, na ordem) + `JanelaDeFolhas` (WinForms) com a grade das folhas, o decimal e o botão de recarregar — a **janela de folhas**;
- `ELET` e o novo `FOLHAS` abrem a janela;
- `install/Positron.bundle/PackageContents.xml` — o **autoload** (a DLL carregada na abertura do CAD, sem `NETLOAD`).

**Medido no ZWCAD 2026** (depois do build, com o ZWCAD fechado), com a passada `FOLHAS`:

```text
Positron carregado. Digite ELET para começar — ELET abre a janela de folhas (FOLHAS tambem).
Positron — janela de folhas aberta com 16 página(s) (fechar pela janela).
OK: plugin carregado no ZWCAD 2026
```

A primeira linha é o **ponto de entrada** disparando no load; a segunda é a **janela de folhas**
aberta com as **16 páginas** — o mesmo número do dump do `pzDiag` (a segunda testemunha). O
**teste visual** (a janela em si) é do dono do produto.

**As próximas fatias** (no §7.8): a **paleta** ancorável (`PaletteSet` do `ZdWindows`), a
**barra de ferramentas** (`Ribbon`) e o splash/recursos.

**Rodada 119 — frente 10, fatia 2: o nome da página pelo layer e a seção PAGINA do pzDiag.**
A segunda fatia de páginas/caderno, agora na classe `PaginasDoCaderno`:

| regra do reverso | o que faz |
|---|---|
| `LayerValido` | número **maior que zero**, ou número + dígito/letra **maiúscula** (48-57 ou 65-90 no `Asc`) |
| `montaNumeroPagina` | tira os zeros à esquerda e, com **largura fixa**, completa com zeros — **um a mais** quando o texto tem letra |
| `localizaPaginaMatriz` | o índice **1-based** da página na lista, `0` quando não achou |
| `BuscaProximaPaginaValida` | a próxima da lista (vazio se for a última) |
| `BuscaAlternativo` | o alternativo; sem o "retorna vazio", devolve a própria página |

A matriz de páginas do original virou uma `IReadOnlyList<PaginaDoCaderno>` — a regra fica
testável sem o CAD.

**A seção `PAGINA` do `pzDiag`** (o artefato para o dono do produto conferir no caderno):
cabeçalho, uma linha por **layer válido** com o decimal e a ordem, e o `TOTAL;paginas`.

**Medido no ZWCAD 2026** (`..\Elet\Teste_projeto_real\Funcional.dwg`, DWG 63):

```text
PAGINA;layer;decimal;ordem
PAGINA;1;1.00;1
PAGINA;2;2.00;2
PAGINA;6;6.00;3
PAGINA;7;7.00;4
PAGINA;8;8.00;5
PAGINA;15;15.00;6  (… 16 a 24 nas posições 7 a 15)
PAGINA;1000;1000.00;16
TOTAL;paginas;16
```

**16 páginas** na ordem da regra — pronto para conferência contra o caderno real.

> **Duas expectativas minhas foram corrigidas pelo próprio original:** só zeros vira **vazio** (não
> `"0"`) e a letra soma **dois** zeros na largura fixa (`10A` a 4 = `0010A`). Os testes
> ficaram com o comportamento do reverso.

**Rodada 111 — o `SYNCV`, o pipeline das veias (o gêmeo do `SYNCD`).**
O `SYNCV` do reverso tem **nove** passos (barra de progresso com `Quantidade = 9`):

```text
CorrigeOsTextosDosCabos -> InsereTextosDeCabos -> SincronizaVeiasDoCaderno -> AtualizaNomesDosCabos
  -> SincronizaCruzamentoInterlig -> RecriaOCruzamentoInterligTipo2Apagados
  -> AtualizaTodosOpcionaisDoCabo -> ModeloDoDispositivoPrincipalTipo3 (conforme Conf.ModeloBobina)
```

O comando passou a compor, na ordem do original, os passos que o recoder tem:

| passo | o que é |
|---|---|
| `[1/3]` os textos dos cabos | pelo `Conf.InterligacaoLayout` — é o `RECRIACABOS` do original (0/2/3 = Eletron, 1 = Eletrosul) |
| `[2/3] INT` | a projeção das veias para o banco, que é o `SincronizaVeiasDoCaderno` |
| `[3/3]` os opcionais | o `AtualizaTodosOpcionaisDoCabo` |

> **Fora do recorte, documentado:** o `InsereTextosDeCabos`, o `AtualizaNomesDosCabos`, a
> família do **cruzamento** da interligação (`SincronizaCruzamentoInterlig` e
> `RecriaOCruzamentoInterligTipo2Apagados`) e o `ModeloDoDispositivoPrincipalTipo3`.

**Medido no ZWCAD 2026** (`..\Elet\Teste_projeto_real\Funcional.dwg`, DWG 63, com cópia do banco):

```text
[1/3] RecriaTextosCabo: 24 rótulo(s) apagado(s) e 20 reinserido(s) de 20 trecho(s) (0 já tinham rótulo; 305 cabo(s) singelo(s) no catálogo).
[2/3] INT: 20 linha(s) gravada(s) em Interligacao4 (199 borne(s)); 265 porta(s) em Portas4I; 216 borne(s) em Bornes4I; 697 cabo(s) em Cabos4; 2388 veia(s) em Veias4.
[3/3] AtualizaOpcionaisDoCabo: 0 de 0 rótulo(s) com os opcionais atualizados (20 rótulo(s) auxiliares lido(s); 0 sem trecho resolvido).
```

Os três passos rodam no desenho real, e a projeção repete exatamente os números do `SYNCD` da
rodada 107 — a segunda testemunha do mesmo cálculo.
**Rodada 115 — o `RECRIACABOS` (o `MsgBox` + o `switch` do layout).**
Última ponta do mapa da frente 7: o `RECRIACABOS` do reverso é um `MsgBox` de
confirmação e um `switch` sobre o `Conf.InterligacaoLayout` — o caso **1** chama
`clsEletrosul.RecriaTextosCaboEletrosul()` e os casos **0/2/3** chamam
`clsEletron.RecriaTextosCabo()` (a substância das rodadas 78/79).

Entraram a regra pura `LayoutDaInterligacao.EhEletrosul` (com teste) e o comando, que
**não pergunta nada**: o harness roda os comandos sem ninguém para responder, então a
**confirmação é o próprio ato de rodar o comando** — a mesma razão que deixa as rotinas
destrutivas do original (com `MsgBox`) fora do recorte.

**Medido no ZWCAD 2026** (`..\Elet\Teste_projeto_real\Funcional.dwg`, DWG 63):

```text
RECRIACABOS: layout 0 (Eletron). RecriaTextosCabo: 24 rótulo(s) apagado(s) e 20 reinserido(s) de 20 trecho(s) (0 já tinham rótulo; 305 cabo(s) singelo(s) no catálogo).
```

> **Limite de evidência registrado:** o branch do **Eletrosul** não é exercitado no CAD — o
> harness passa as variáveis ao plugin pelo `.scr` (não herda as do processo), então o
> `POSITRON_INTERLIGACAO_LAYOUT` não chega. O branch fica coberto pelo **teste unitário** da
> regra pura e pela medição do próprio `RecriaTextosCaboEletrosul` na rodada 79.
**Rodada 113 — o `RESTPROJ` (o pipeline-mãe) e o `ApagaERROS`.**
O `RESTPROJ` do reverso é o **pipeline-mãe**: **dezesseis** passos (barra de progresso com
`Quantidade = 16`) que **superam** o `SYNCD` (rodada 107) e o `SYNCV` (rodada 111).
O comando passou a compor, na ordem do original, os passos que o recoder tem:

| passo | o que é |
|---|---|
| `[1/5]` os textos dos cabos | pelo `Conf.InterligacaoLayout` (o `RECRIACABOS`) |
| `[2/5] ApagaERROS` | **novo nesta rodada** |
| `[3/5] CorrigeModelosDeContatos` | as duas metades (o dicionário e o desenho) |
| `[4/5] FIA` + `INT` | a **projeção**, que no original são os quatro `Sincroniza*` |
| `[5/5] os opcionais do cabo | **só quando `InterligacaoLayout == 3`**, como no original |

**O `ApagaERROS`** (o único passo do `RESTPROJ` que não tinha par): o
`clsBlocos.ApagaERROS` lê o XData `ERRO` e confere se o **primeiro valor** é a marca —
a mesma regra que o `clsPortas` usa com a marca `PORTAS`. Entraram a regra pura
`EntidadesDeErro` e o adapter, que percorre o espaço de modelo e apaga as marcadas.

**Medido no ZWCAD 2026** (`..\Elet\Teste_projeto_real\Funcional.dwg`, DWG 63, com cópia do banco):

```text
[1/5] RecriaTextosCabo: 24 rótulo(s) apagado(s) e 20 reinserido(s) de 20 trecho(s) (0 já tinham rótulo; 305 cabo(s) singelo(s) no catálogo).
[2/5] ApagaERROS: 0 entidade(s) marcada(s) apagada(s) de 3286 no espaço de modelo.
[3/5] CorrigeModelosDeContatos: nenhum contato fora da posição (8 modelo(s) e 26 contato(s) no CONTATOS) — nada a corrigir.
[4/5] FIA: 494 linha(s) em Fiacao (199 borne(s), 191 dispositivo(s), 0 reordenada(s), 83 posicao(oes), 450 ponto(s) de bloco); 265 porta(s) em Portas4F; ...
[4/5] INT: 20 linha(s) gravada(s) em Interligacao4 (199 borne(s)); 265 porta(s) em Portas4I; 216 borne(s) em Bornes4I; 697 cabo(s) em Cabos4; 2388 veia(s) em Veias4.
[5/5] os opcionais do cabo ficam de fora: o original só os atualiza com InterligacaoLayout = 3 (aqui = 0).
```

**Seis passos no desenho real**, com os números repetindo as medições das rodadas 107 e 111 — a
**terceira testemunha** do mesmo cálculo. E o `ApagaERROS` mostra o tamanho da varredura: **3286
entidades** no espaço de modelo (0 marcadas nesta cópia).

> **Fora do recorte, documentado:** o `ApagaContatosOrfaos`, o
> `EditaPortaDipAuxPainelModeloFabricante`, o `sincronizaCircuitos` (coberto pela projeção), o
> `InsereTextosDeCabos`, a família do **cruzamento**, o `AtualizaNomesDosCabos` e os modelos
> de bobina.
**Rodada 112 — a triagem das frentes 8 e 9 e o `CBD` (compactar o banco).**
As duas últimas frentes do §7.6: a **8** (materiais, 3) tem 2 só UI (`GERLM` =
`frmGerenciadorMateriais`, `ATINDEP` = `frmGerenciadorMatIndep`) e 1 destrutivo com
confirmação (`DELLM`); a **9** (exportar/importar, 17) tem **13 só UI**, o `IMPBD` (ambiente,
com arquivo) e o `DELPLA` (destrutivo) — e **dois candidatos reais**.

**Candidato 1, entregue: `CBD`.** O original chama `clsCompactador.CompactarBD()`; no SQLite o
equivalente exato é o `VACUUM` (que não pode rodar dentro de transação). Entrou o
`ProjectStore.Compactar` e o comando, que reporta o tamanho antes e depois.

**Medido no ZWCAD 2026**, sobre uma cópia do banco do projeto (DWG 63):

```text
CBD: banco compactado — 584 KB antes, 572 KB depois (12 KB liberado(s)).
```

**Candidato 2, o próximo: `RESTPROJ`.** É o **pipeline-mãe de 16 passos**
(`Quantidade = 16`) e um **superconjunto** do `SYNCD` (rodada 107) e do `SYNCV` (111):
`CorrigeOsTextosDosCabos`, `ApagaERROS`, `ApagaContatosOrfaos`,
`CorrigeModelosDeContatos`, `SincronizaContatos`, `SincronizaPortas`,
`SincronizaDePara`, `EditaPortaDipAuxPainelModeloFabricante`, `sincronizaCircuitos`,
`InsereTextosDeCabos`, `SincronizaVeiasDoCaderno`, `SincronizaCruzamentoInterlig`,
`RecriaOCruzamentoInterligTipo2Apagados`, `AtualizaNomesDosCabos` e (se `InterligacaoLayout == 3`)
`AtualizaTodosOpcionaisDoCabo` — o `RESTPROJ` pode virar o terceiro pipeline do recoder, compondo
tudo o que já foi portado (mais o `ApagaERROS`, que ainda não tem par).

**Com as triagens 105, 106, 110 e 112, o mapa do §7.6 está completo** (frentes 1–9): o trabalho
em lote está entregue e o que resta são editores de UI, interação e arquivo — mais o
`RESTPROJ`.

**Rodada 110 — a triagem das frentes 5, 6 e 7.**
Li o corpo dos **49** comandos das três frentes. O veredito repete o das frentes 3 e 4 — são
editores de UI, interação e ambiente —, mas desta vez **sobrou um candidato grande**.

**Frente 5 (17):** 8 só UI (`GERDWG`, `DUPCAD`, `CIRC`, `EDTNCIRC`, `INSM`, `APL`, `EDCONP`,
`REVAUT`), 8 interativos/ambiente (`CONAUT`/`DERAUT` com o `Editor`, `CON` = `CriarConexao` a cada
clique, `RESTAURA` = `Pagina.restauraCampos()`, `CAD` = `CriarCaderno` com formato, `EDCON`,
`CriaJigCloud` = um *jig*, `AJUDA` = abre a URL) e **1 candidato**: `SYNCC` =
`clsConexao.sincronizaCircuitos()`, cuja substância já está na projeção `FIA` (`Circuitos4F`) —
entra como **verificação**, não como comando novo.

**Frente 6 (4):** `LR`, `SEQ`, `LNK` = só UI; `DELFIPROJ` = `MsgBox` de confirmação e depois apaga
o projeto de fiação (destrutivo, não vale portar).

**Frente 7 (28):** 14 só UI, 3 toggles de exibição (`OCCAB`, `LNOME`, `DNOME`), 4 interativos
(`INDV`, `VEIA1`, `VEIA2`, `VEAUT`, `BLI`) e 3 com a **substância já portada**:

- `LAYELN` = `clsEletron.RecriaTextosCabo()` → **rodada 78**;
- `LAYELS` = `clsEletrosul.RecriaTextosCaboEletrosul()` → **rodada 79**;
- `RECRIACABOS` = o `MsgBox` + o `switch` sobre o `Conf.InterligacaoLayout` que escolhe entre os dois.

**O candidato grande — `SYNCV`, o gêmeo do `SYNCD`:**

```text
[pb 1..9] CorrigeOsTextosDosCabos -> InsereTextosDeCabos -> SincronizaVeiasDoCaderno
-> AtualizaNomesDosCabos -> SincronizaCruzamentoInterlig
-> RecriaOCruzamentoInterligTipo2Apagados -> AtualizaTodosOpcionaisDoCabo
-> ModeloDoDispositivoPrincipalTipo3 (conforme Conf.ModeloBobina)
```

Os passos que o recoder **já tem em comandos separados**: os textos dos cabos (rodadas 78/79), os
opcionais (82) e a sincronização das veias (a projeção `INT`). Ou seja, o `SYNCV` pode virar um
**pipeline** como o `SYNCD` virou na rodada 107 — é o próximo candidato de código, e o último que
esta triagem revelou.
**Rodada 108 — o `STATBORN` em lote (o candidato da frente 3).**
A estatística de bornes do `frmEstatisticaDeBornes` é só exibição; a conta está no
`clsReguasDeBornes.SomaOsBornes`, que:

1. percorre os blocos de **Dispositivo tipo `B`** do desenho, casa pelo `IndiceRegua` e conta
   `tipo != 0` como **duplo** e o resto como **simples**;
2. soma a **reserva** da régua (o `CENG_BORNES`), partida por tipo;
3. fecha com `quantBornesRegua = S + SRes + D + DRes`.

Entraram a regra pura `EstatisticaDeBornes` (a contagem por régua, a linha e o total — o
`calculaSelecionado` do original), o adapter `EstatisticaDeBornesDoDesenho` — reusando
`ReguasDoDesenho`, `BornesDoDesenho` e `BornesReservaDoDesenho`, que já existiam — e o comando, que
**acrescenta** a tabela ao arquivo do `pzDiag` (`## STATBORN ##`).

**Medido no ZWCAD 2026** (`..\Elet\Teste_projeto_real\Funcional.dwg`, DWG 63):

```text
STATBORN: 31 régua(s), 199 usados simples, 17 de reserva simples, 0 usados duplos e 0 de reserva duplos
          (216 no total; 199 borne(s) no desenho e 17 reserva(s)).
--- arquivo ---
REGUA;indice;painel;regua;UsoS;ResS;UsoD;ResD;Total
REGUA;1;503;ENTR 1;8;0;0;0;8
REGUA;2;503;ENTR 2;8;0;0;0;8
REGUA;489;510;SAÍDA;8;0;0;0;8
...
REGUA;0;;TOTAL;199;17;0;0;216
```

**Os números batem com duas medições anteriores:** os **199 bornes** do `FIA`/`SYNCD` e os **216 de
`Bornes4I`** (199 usados + 17 de reserva). O `STATBORN` passa a ser uma **terceira testemunha
independente** da leitura de bornes.

> **De quebra:** o comando `pzDiagCriar` — cuja gravação não persistiu na rodada 104 e por isso
> **não** era executado pelo harness — foi **registrado de novo** no `Comandos.cs`, agora com a nota
> do quirk.

**Rodada 107 — o `SYNCD` virou o pipeline do original.**
O `SYNCD` do reverso **não** é uma projeção simples: é um **pipeline** de seis passos com barra de
progresso (`Quantidade = 6`).

```text
ApagaContatosOrfaos -> CorrigeModelosDeContatos -> SincronizaContatos -> SincronizaPortas
  -> SincronizaDePara -> EditaPortaDipAuxPainelModeloFabricante -> CorrigeCoresDosBlocos
```

O recoder só fazia a projeção (`FIA` + `INT`). O comando passou a compor, **na ordem do
original**, os passos que o recoder tem:

| passo | o que é |
|---|---|
| `[1/4] CorrigeModelosDeContatos` | as duas metades (o dicionário e o desenho) |
| `[2/4] FIA` e `[3/4] INT` | a **projeção** para o banco — é o que no original fazem os três `Sincroniza*` |
| `[4/4] CorrigeCoresDosBlocos` | o original fecha com ele |

> **Fora do recorte, documentado:** o `ApagaContatosOrfaos` e o
> `EditaPortaDipAuxPainelModeloFabricante` (a família de sincronização de tabelas/UI que o
> recoder não porta) e a barra de progresso.

**Medido no ZWCAD 2026** (`..\Elet\Teste_projeto_real\Funcional.dwg`, DWG 63, com uma cópia do
banco):

```text
[1/4] CorrigeModelosDeContatos: nenhum contato fora da posição (8 modelo(s) e 26 contato(s) no CONTATOS) — nada a corrigir.
[2/4] FIA: 494 linha(s) em Fiacao (199 borne(s), 191 dispositivo(s), 0 reordenada(s), 83 posicao(oes), 450 ponto(s) de bloco); 265 porta(s) em Portas4F; 168 borne(s) em Bornes4F; 70 contato(s) em Contatos4F; 83 dispositivo(s) em Dispositivos4F; 11 circuito(s) em Circuitos4F; 15 tipo(s) em Aplicacao4F.
[3/4] INT: 20 linha(s) gravada(s) em Interligacao4 (199 borne(s)); 265 porta(s) em Portas4I; 216 borne(s) em Bornes4I; 697 cabo(s) em Cabos4; 2388 veia(s) em Veias4.
[4/4] CorrigeCoresDosBlocos: 0 atributo(s) com a cor corrigida (0 bloco(s); 197 atributo(s) de definição em 44 nome(s) de bloco).
```

É a **primeira passada que roda correção + projeção + correção num comando só** — e ela mostra o
pipeline completo do produto funcionando de ponta a ponta no desenho real.

**Rodada 106 — a triagem da frente 4 (dispositivos, máscaras, portas e contatos).**
Li o corpo dos **28** comandos. O resultado repete o da frente 3: **20 são só UI** e **8 são
interativos ou dirigidos por arquivo**.

**Só UI (20):** `PN` (`frmCadastroDePaineis`), `GERCONT`, `GERMASC`, `DISP`, `PORT`,
`CONT`, `MASC`, `MOVPN`, `CONFLP`, `ADDDESC`, `MIGPOR`, `MCONT`, `MMASC`,
`EDTFUNC`, `EDTDISPSA`, `EDTDISPS`, `LAYMEC`, `PLAQ`, `TPG`, `ATPG`.

**Interativos ou por arquivo (8):**

| comando | por quê |
|---|---|
| `DEPARA` | `clsDePara.CriarDePara` com um contador **estático** de tipo — inserção a cada clique |
| `LDAT` | `clsAtributos.ligaNomedeDispositivos` → `selecionaUmBloco` (escolhe **um** bloco) |
| `PINC` | `clsAtributos.Pincel` → `selecionaUmBloco` |
| `MOV` | `clsUtilitarios.moverElementos` |
| `CHVAUT` | `clsPortas.AtribuiChavePrimaria`: exige a **lista de pontos** num arquivo externo (`cDadosExcel.ImportarPaginasPosLogico`) + `MsgBox` de confirmação |
| `SYNCLP` | `clsPortas.ExportaImportarPortas` (o mesmo arquivo) |
| `LXLS`, `PortasChesf` | `clsDispositivo.LPDisponivel` + `Process` (abrem programa externo) |

> **Achado da triagem:** o `SYNCD` do original **não** é uma projeção simples — é um **pipeline**:
> `ApagaContatosOrfaos` → `CorrigeModelosDeContatos` → `SincronizaContatos` →
> `SincronizaPortas` → `SincronizaDePara` → `EditaPortaDipAuxPainelModeloFabricante`.
> O `SYNCD` do recoder projeta o desenho no banco; a composição do pipeline fica **proposta**
> para uma rodada futura (é mudança num comando já entregue — não entra por conta própria).

**Conclusão das duas triagens (frentes 3 e 4):** as frentes restantes do §7.6 são **editores de UI**
e ferramentas de interação; o trabalho **em lote** do plugin estava concentrado na frente 2, que
está entregue (27 de 38) e sem pendências.

**Rodada 105 — a triagem da frente 3 (réguas e bornes).**
A frente 3 tem 13 comandos. Li o corpo de cada um no reverso; **nenhum é correção em lote** e a
classificação fecha assim:

| comando | corpo do reverso | classificação |
|---|---|---|
| `DEF` | `new frmDefinicao()` | só UI |
| `GERRB` | `new frmCriarReguas()` | só UI |
| `BORN` | `new frmBornes()` | só UI |
| `EDBORN` | `new frmGerenciadorReguasBornes()` | só UI |
| `STATBORN` | `new frmEstatisticaDeBornes()` | só UI (mas a **conta** vive no `clsReguasDeBornes`) |
| `SELBORN` | `new frmEditaBornesSelecao()` | só UI |
| `MBOR` | `new frmMigraBornes()` | só UI |
| `CLOBORN` | `new frmClonarEstruturaRegua()` | só UI |
| `REGH` | `clsRegua.insereReguaH()` → `CapturaDadosDaRegua` | interativo (formulário de captura) |
| `REGV` | `clsRegua.insereReguaV()` → `CapturaDadosDaRegua` | interativo |
| `HBASE` | `clsRegua.redefineAlturaBase()` → `editor.GetPoint` | interativo (a nova altura vem de um clique) |
| `LDNR` | `clsBornes.OcultaAtributoNome()` → `clsAtributos.selecionaUmBloco` | interativo (escolhe **um** bloco) |
| `OCPN` | `clsBornes.OcultaAtributoPainel()` → `clsAtributos.selecionaUmBloco` | interativo |

Ou seja: **8 de UI + 5 de interação** — nenhum comando da frente 3 é uma passada pelo desenho como
as correções da frente 2. O que sobra como **candidato de código em lote** é a **estatística de
bornes** do `STATBORN`: o formulário só exibe, e a conta está no `clsReguasDeBornes`
(`mQuantBornes`: `US`/`RS`/`TS` + `UD`/`RD`/`TD` + total, por régua) — a
classe irmã do `ReguasDoDesenho`/`BornesDoDesenho` que o recoder já tem.

**Próxima frente com trabalho real:** a **4** (dispositivos, máscaras, portas e contatos), cuja lista
tem comandos de sincronização que valem uma triagem igual a esta.

**Rodada 104 — a prova ponta a ponta do `IndefineUmaPorta` (a última pendência da frente 2).**
A prova que faltava desde a rodada 101, agora **em C#** (a fixture LISP nunca deu saída):

- o `pzDiagCriar` monta no desenho a **porta sintética** — bloco `PZPORT` com os quatro ATTDEFs
  (`NOME1`/`T1`/`PAINEL`/`EFC`), a inserção com os valores antigos, o XData `Dispositivo` tipo `E` no
  **modelo 9/porta 5** e um `MASCARAS` cujo modelo 9 só tem a **porta 3** — com os 25 valores do
  XData na regra pura `PortaSintetica` (testada);
- o `pzDiag` ganhou o modo **acrescentar** (`## pzDiag ##` por chamada), o que permite o
  **antes/depois na mesma passada** (o harness sempre parte de uma cópia limpa entre passadas).

> **Quirk medido:** o harness executa o `pzDiag` e **não** o `pzDiagCriar` — o comando novo não
> produz saída nenhuma, nem sozinho, enquanto os antigos rodam na mesma linha. Por isso a criação
> entra pelo próprio `pzDiag` quando `POSITRON_DIAG_CRIAR` está ligada, e é **idempotente** (a segunda
> chamada não estoura o `eDuplicateRecordName`).

**Medido no ZWCAD 2026** num desenho em branco, com a passada
`pzDiag,corrigePortas,pzDiag` e `POSITRON_DIAG_CRIAR=1`:

```text
## pzDiag ##
PORTA;tipo;indiceModelo;indiceDaPorta;handleMascara;handleDefinicao;NOME1;T1;PAINEL;EFC
PORTA;E;9;5;;;NOME-ANTIGO;7;PT1;EFC-ANTIGO          <- ANTES
TOTAL;portas;1;4;0
...
## pzDiag ##
PORTA;E;9;0;;;;?;;                                   <- DEPOIS
TOTAL;portas;1;4;0

corrigePortas: 0 atributo(s) e 0 visibilidade(s) regravado(s) em 0 de 1 bloco(s) de porta
                (1 porta(s) no dicionário; 1 fora dele, 1 indefinida(s)).
```

Leitura do depois: o `indiceDaPorta` foi **zerado**, as protegidas `NOME1` e `PAINEL` ficaram
**vazias**, o `T1` recebeu o **caracter de terminal indefinido** e o `EFC` (o resto) ficou
**vazio** — a regra da `LimpezaDaPorta` aplicada no ZWCAD de verdade.

**Ferramenta:** o stub ganhou `AttributeCollection` (com `AppendAttribute`), o construtor
`BlockReference(Point3d, ObjectId)`, `BlockTableRecord : SymbolTableRecord`, o `SymbolTable.Add`
devolvendo `ObjectId`, `AttributeDefinition : DBText` e o `DBText.Position`.

**Rodada 103 — o `pzDiag`: a ferramenta de diagnóstico em **C#** (e o fecho do contador da cor).**
A lição das rodadas 90/91/102 era que o gargalo das evidências era o **LISP** — contador sem
saída, rastro parando em `0 load`, parênteses. A saída foi trocar a ferramenta de linguagem.

**O comando** `pzDiag` escreve, no runtime do plugin (sem `entget`/`tblsearch`/parênteses), um
arquivo com **duas seções**:

- `PORTA`: cada bloco de Dispositivo tipo `E` com o par modelo/porta, os dois handles e os
  atributos `NOME1`/`T1`/`PAINEL`/`EFC` (a metade que faltava da fixture do
  `IndefineUmaPorta`);
- `COR`: cada referência cujo nome de bloco tem definição, com a cor da referência e a da
  definição, e o total de diferenças (o contador da cor).

O formato é puro e testado (`RelatorioDeDiagnostico`), e o caminho sai de `POSITRON_DIAG` ou, sem
ele, de `%TEMP%\positron-diag.txt`.

**Medido no ZWCAD 2026 — na primeira tentativa** (`..\Elet\Teste_projeto_real\Funcional.dwg`,
DWG 63):

```text
pzDiag: 45 porta(s), 1834 referência(s) de cor e 50 diferença(s) — escrito em C:\...\positron-diag.txt.
--- arquivo ---
TOTAL;portas;45;1834;50
COR;396E;MascaraM.DWG;ALTERNATIVO;256;2
...
TOTAL;diferencas;50
```

**As 50 diferenças são exatamente as da rodada 91**, e todas no `MascaraM.DWG` — o bloco cujo nome
quebra o quirk do `CorrigeCoresDosBlocos` — agora corroboradas por uma ferramenta **C#**,
independente do LISP. **A pendência do contador da cor fica fechada.**

> **O que sobra:** o desenho sintético da porta fora do dicionário (para exercitar o
> `IndefineUmaPorta`) — o dump está pronto nesta ferramenta e a criação pode ir pela mesma via,
> em C#.

**Rodada 102 — o prefixo/sufixo do cruzamento na `ORIGEM` (correção de fidelidade).**
A rodada 100 portou a `ORIGEM` como o **layer** do texto da definição, assumindo vazios os dois
campos `Conf.PrefixoCruzInterno`/`SufixoCruzInterno`. Caçando os padrões no reverso
(`XDataGeral.cs:312-313`) eles são o **abre-parênteses** e o **fecha-parênteses** — a `ORIGEM`
correta é `(layer)` e o recoder estava gravando `layer`. **Erro meu**, pego por não ter
procurado o padrão antes de assumir.

**O que entrou:** os dois campos de configuração completos (chave, variável de ambiente,
propriedade, padrão `(` e `)`, `Texto`, `Definir` e `Ambiente`) e o `PaginaDoTexto` passa a
envolver o layer com eles.

**Medido no ZWCAD 2026** (`..\Elet\Teste_projeto_real\Funcional.dwg`, DWG 63):

```text
corrigePortas: 9 atributo(s) e 0 visibilidade(s) regravado(s) em 45 de 45 bloco(s) de porta (240 porta(s) no dicionário; 0 fora dele, 0 indefinida(s)).
2ª chamada: 0 atributo(s) e 0 visibilidade(s)
```

Os **mesmos 9** atributos de antes, agora com o valor **certo** (e a idempotência preservada).

> **Pendências de ferramenta que seguem abertas:** o contador `cad-conta-cores.lsp` e a fixture do
> `IndefineUmaPorta`. Tentei as duas nesta rodada — a fixture enxuta ficou com um parêntese a
> mais e a de rastro para em `0 load` (o mesmo bloqueio das rodadas 90/91): o caminho de
> indefinir continua sem prova sintética, embora a regra esteja coberta por 4 testes unitários.

**Rodada 101 — o `IndefineUmaPorta`/`LimpaPorta` do `corrigePortas` (cauda da pendência da rodada 87).**
A porta cujo par `(indiceDoModelo, indiceDaPorta)` **não** está no dicionário passa a ser
**indefinida**:

- o `IndefineUmaPorta(handle, bLimpaTudo: true)` zera os **três** campos do XData
  `Dispositivo` — o `indiceDaPorta` (o `array[6]`), o `handleDaDefinicao` (o `array[9]`) e a
  `chavePrimaria` (o `array[10]`) — trocando só o registro do app;
- a `LimpaPorta` roda nos atributos, com a regra pura nova `LimpezaDaPorta`:

| tag | valor |
|---|---|
| `NOME1` `NOME2` `ALTERNATIVO` `PAINEL` `MODELO` `FABRICANTE` | vazias (esvaziadas no primeiro passo e não tocadas depois) |
| `T<n>` / `B<n>` | o caracter de terminal indefinido |
| o resto | vazio |

**Medido no ZWCAD 2026** (`..\Elet\Teste_projeto_real\Funcional.dwg`, DWG 63):

```text
corrigePortas: 9 atributo(s) e 0 visibilidade(s) regravado(s) em 45 de 45 bloco(s) de porta (240 porta(s) no dicionário; 0 fora dele, 0 indefinida(s)).
```

Nesta cópia **não há** porta fora do dicionário, então o caminho de indefinir **não é exercitado**.

> **Pendência de ferramenta (registrada):** a fixture sintética
> `scripts/cad-fixture-indefine-porta.lsp` foi escrita (bloco `BTEPORT` com os ATTDEFs
> `NOME1`/`T1`/`PAINEL`/`EFC`, o XData tipo `E` apontando o modelo 9/porta 5 e um `MASCARAS` com só a
> porta 3), mas **não produziu saída**: o rastro para em `0 load` — o mesmo sintoma das rodadas
> 90/91 (saldo de parênteses em 0, mas o load não chega ao fim).

**Rodada 100 — o `NOME1`/`ORIGEM` do `corrigePortas` (pendência da rodada 87).**
Fecha a **metade de atributos** da pendência, implementando os dois `Busca*` que faltavam:

- `clsMascara.BuscaNomeDaMascara`: abre o bloco da **máscara** pelo `HandleDaMascara`, lê o XData
  `Dispositivo` dela com o `MascaraXData` e devolve o `Nome1` — com `/Nome2` quando o segundo
  nome existe;
- `clsTextos.EncontraPaginaDoTexto`: abre a **definição** pelo `HandleDaDefinicao` e usa o
  **layer** do texto.

> Os dois campos `Conf.PrefixoCruzInterno`/`SufixoCruzInterno` que o original usa em volta da
> página **ainda não existem** como configuração no recoder: aqui saem vazios (registrado).

A regra pura ganhou uma sobrecarga com os dois valores (`NOME1` = a máscara, `ORIGEM` = a página) e a
antiga virou o caso "sem os dois"; o `LerPorta` do adapter passou a devolver também os handles do
`array[4]` e do `array[9]`, resolvidos uma vez por porta.

**Medido no ZWCAD 2026** (`..\Elet\Teste_projeto_real\Funcional.dwg`, DWG 63):

```text
1ª chamada: corrigePortas: 9 atributo(s) e 0 visibilidade(s) regravado(s) em 45 de 45 bloco(s) de porta (240 porta(s) no dicionário; 0 fora dele).
2ª chamada: corrigePortas: 0 atributo(s) e 0 visibilidade(s) regravado(s) em 45 de 45 bloco(s) de porta
```

**9 atributos** que a rodada 87 não tocava agora são corrigidos — e a segunda chamada zera
(idempotência **de verdade**, sem a limpeza que o `CorrigeHandleSuperior` faz).

**O que ainda fica fora:** o `IndefineUmaPorta` da porta que **não** está no dicionário (0 nesta
cópia) — ele depende do `LimpaPorta`, uma varredura de atributos/layers que fica como fatia
registrada — e os dois campos de prefixo/sufixo do cruzamento.

**Rodada 99 — a renumeração do dicionário do `CorrigeModelosDeContatos` (pendência da rodada 86).**
A pendência estava registrada com o motivo: o **leitor tipado recalcula a orientação** ao ler
(`OrientacaoContato.Verificar`) e gravar de volta o que se leu persistiria o valor recalculado. A
solução foi o **registro cru**:

- `ModelosContato` ganhou `ContatoBruto` + `LerAuxiliaresBrutos`/`ParaValoresBrutos` (os **oito**
  valores como estão no XRecord);
- a regra pura `CorrecaoModeloDeContato.Renumerar` troca **só o índice** — o mesmo código DXF,
  todo o resto intacto;
- o `ContatosDoDesenho` ganhou `LerAuxiliaresBrutos`/`GravarAuxiliares` (que regrava o `Data` do
  XRecord da chave do modelo);
- o adapter passou a renumerar **o dicionário** antes da varredura do desenho, como o original.

**Medido no ZWCAD 2026** na fixture sintética (o `CONTATOS` com o modelo 53 e os contatos de
índice **7** e **9**):

```text
CorrigeModelosDeContatos: 2 contato(s) renumerado(s); 1 bloco(s) com o XData Dispositivo e 0 com o XData Modelo regravado(s) (1 auxiliar(es) lido(s); 1 dicionário(s) renumerado(s)).
BLOCO;A;53;1          <- o indexContato do bloco (era 7)
CONTATO;1             <- o dicionário: era 7
CONTATO;2             <- o dicionário: era 9
TOTAL;contatos;2
```

A renumeração fica provada ponta a ponta: o dicionário **e** o desenho.

**Rodada 98 — `CorrigeHandleSuperior` (frente 2 do §7.6, parte 25: o resolvedor por ponto).**
Fecha o comando. A **primeira metade** é o `limpaHandleSuperior` (o `Limpahandle` da rodada 92,
reusado) e a **segunda** é o `verificaConexao` — o resolvedor que faltava:

| passo | regra |
|---|---|
| a janela | ±**0.2** em volta do **ponto inicial** da derivação (o `SelectCrossingWindow` do original; aqui os limites da polilinha contra a mesma janela, sem editor) |
| o vizinho | o **primeiro** que esteja na **mesma camada** (sem caixa), **não** seja ela mesma (handle, comparação sem caixa) e tenha XData `CONEXAO` |
| o que grava | **handle**, **nome** e **potencial** (índices 2, 6 e 1 do app), trocando só o registro do app |
| o tipo | do `Jumper`: vazio → `"C"`; `"JUMPER"` → `"J"`; outro valor → não mexe |

**Medido no ZWCAD 2026** (`..\Elet\Teste_projeto_real\Funcional.dwg`, DWG 63):

```text
CorrigeHandleSuperior: 167 handle(s) limpo(s); 167 de 167 derivação(ões) resolvida(s) e 167 regravada(s) (365 conexão(ões) no desenho).
```

**Todas as 167 derivações** acharam um vizinho e foram regravadas. A segunda chamada repete os
167 — **não** é falha de convergência: o comando **começa** limpando os handles (é o
`limpaHandleSuperior()` do original), então a re-resolução sempre tem trabalho.

> **Fora do recorte, documentado:** a parte de **páginas** do original
> (`AtivaTodasAsPagina`, `Pagina.AtivaPagina`) e o gate de hardlock.

**Ferramenta:** o stub ganhou `Polyline.StartPoint`/`EndPoint` e o adapter usa o alias do
`Polyline` (o `GraphicsInterface` do ZWCAD traz outro `Polyline`, que dá ambiguidade).

**Rodada 97 — `CorrigeCabos` (frente 2 do §7.6, parte 24: o `CorrigeNothing` do banco).**
O `CorrigeCabos` do `Correcao.cs` é **só banco** (não olha o desenho): o
`CorrigeNothing("Funcao")` do `cDadosAccessInterligacao2` roda **três** atualizações:

```sql
UPDATE Cabos  SET Funcao = ' ' WHERE Funcao = ''
UPDATE Cabos4 SET Funcao = ' ' WHERE Funcao = ''
UPDATE Cabos  SET Alarme = 0            -- sem filtro, como no original
```

Entraram a regra pura `CorrecaoDeCabosNothing` (o plano das três, na ordem, com **lista branca**
da coluna — o original concatena o nome no SQL), o `ProjectStore.CorrigirCabosNothing` (que
devolve as linhas afetadas de cada uma) e o comando.

**Medido no ZWCAD 2026** (`..\Elet\Teste_projeto_real\Funcional.dwg`, DWG 63, com uma **cópia** do
banco do projeto para não sujar o de trabalho):

```text
CorrigeCabos: 0 Funcao vazia(s) virou(aram) espaço em Cabos, 0 em Cabos4 e o Alarme foi tocado em 697 linha(s) (o UPDATE do Alarme não tem filtro, como no original).
```

E a **sonda independente** `scripts/cad-sonda-cabos.py` (as mesmas três atualizações numa cópia do
`.db`, fora do plugin) confirma: **0** `Funcao` vazias nas duas tabelas e **697** linhas em
`Cabos`.

> **Nota de honestidade:** o SQLite devolve as linhas **tocadas** por um `UPDATE` sem filtro, não
> as que mudaram. A primeira redação da mensagem dizia "697 Alarme(s) zerado(s)" e foi corrigida
> para "o Alarme foi tocado em 697 linha(s)".

**Classificações registradas:** o `APAGARXDATA` é só de UI (`new frmPesquisaXdatas()`) e o
`RENPAGA` é **interativo + sistema de páginas** (`InputBox` + `Pagina.renumerarPaginasLote` + a
cascata de sincronizações) — os dois saem do recorte.

**Rodada 96 — `CorrigePainelET1DosBornes` (frente 2 do §7.6, parte 23: os atributos do borne).**
O `clsUtilitarios.cs` que reescreve os atributos do bloco do **borne** (Dispositivo tipo
`B`): resolve a **régua** pelo `IndiceRegua` no dicionário `REGUAS` (o
`BuscaPainelDoBorneNoDicionario` do reverso — no recoder é o `ReguasDoDesenho`, que já traz o
`Painel` de cada régua) e o **nome do painel** pelo cadastro (`LerNomesDePaineis`).

| tag | valor |
|---|---|
| `NOME1` | a régua — ou **painel + separador + régua** quando o borne **não** está visível (`Visivel != 1`) |
| `PAINEL` | o nome do painel |
| `REGUA` | o nome da régua |
| `T1` | o número — ou o caracter de terminal indefinido quando é **`0`** |
| outra | não mexe |

**Quirk reproduzido:** a sentinela do original é a **string `OK`** — um atributo cujo valor
calculado for exatamente `OK` **não é escrito** (é o "só grava o que muda" do original, com um
literal no lugar de um nulo). Entrou também o campo de configuração
`SeparadorPainelRegua` (chave/variável/Texto/Definir/Ambiente, padrão `/`).

**Medido no ZWCAD 2026** (`..\Elet\Teste_projeto_real\Funcional.dwg`, DWG 63) — contador
independente no load:

```text
contador: TOTAL;bornes;199;comPainel;0
          BORNE;4E8B;H_B_FECH_CIMA_PNL_REGUA;PNL-GGE/R9;;;1     <- NOME1 já na forma painel/régua
comando:  CorrigePainelET1DosBornes: 0 atributo(s) regravado(s) em 199 de 199 borne(s) (31 régua(s) no dicionário).
          2ª chamada: 0 de novo (idempotência)
```

Ou seja: **todos os 199 bornes** casaram com uma régua (das **31** do dicionário) e nenhum
atributo precisou mudar — esta cópia não tem os atributos `PAINEL`/`REGUA`, e o `NOME1`/`T1` já
estão certos. O caminho de escrita fica provado pelos 5 testes das regras.

> **Classificação registrada:** o `CorrigeJanelas` é só de UI (`Geral.moveFormOrigem()`) e sai do
> recorte.

**Rodada 95 — `CorrigeTextosDasLigacoes`: um comando **duplicado** no reverso.**
O achado é do tipo que só aparece lendo o corpo: o `CorrigeTextosDasLigacoes` do
`clsUtilitarios.cs` tem o **mesmo corpo** do `ApagaBlocosMirror` — o laço idêntico

1. bloco com **algum** XData;
2. **sem** o app `DINTERLIG`;
3. `ScaleFactors.X &lt; 0` → `Erase`.

Ele **não toca em texto nenhum**, apesar do nome. O recoder entrega o comportamento fiel
reusando o mesmo adapter (`BlocosMirrorDoDesenho`) e a linha de resumo declara o achado; não
há teste novo porque a regra é a mesma (já coberta pelos 3 testes de `CorrecaoDosBlocosMirror`).

**Medido no ZWCAD 2026** no desenho da fixture `scripts/cad-fixture-mirror.lsp` (as mesmas três
inserções da rodada 94):

```text
CorrigeTextosDasLigacoes: 1 bloco(s) espelhado(s) apagado(s) — o corpo deste comando no original é o MESMO do ApagaBlocosMirror (não há correção de texto): 2 espelhado(s) entre 3 com XData; 1 são cabo de aranha e ficam.
dump: BLOCO;245;BTMIRROR;-1;NAO;SIM      <- o espelhado com DINTERLIG ficou
      BLOCO;246;BTMIRROR;1;SIM;NAO       <- o normal ficou
      TOTAL;blocos;2;espelhados;1
```

Exatamente o resultado do `ApagaBlocosMirror` na rodada 94 — a duplicação, provada pela
medição.

**Rodada 94 — o caminho de apagar do `ApagaBlocosMirror`, provado (frente 2, ferramenta/evidência).**
Fecha a pendência de fixture da rodada 93. A `scripts/cad-fixture-mirror.lsp` monta **três**
inserções do mesmo bloco vazio:

| # | como está | o que o comando faz |
|---|---|---|
| 1 | espelhada (escala X = **−1**) com um XData qualquer | **apaga** |
| 2 | espelhada (escala X = −1) **com o app `DINTERLIG`** (cabo de aranha) | fica |
| 3 | normal (escala X = 1) com XData | fica |

**Medido no ZWCAD 2026** (desenho sintético):

```text
1ª chamada: ApagaBlocosMirror: 1 bloco(s) espelhado(s) apagado(s) (2 espelhado(s) entre 3 com XData; 1 são cabo de aranha e ficam; 3 bloco(s) lido(s)).
2ª chamada: ApagaBlocosMirror: 0 bloco(s) espelhado(s) apagado(s) (1 espelhado(s) entre 2 com XData; 1 são cabo de aranha e ficam; 2 bloco(s) lido(s)).
dump:       BLOCO;245;BTMIRROR;-1;NAO;SIM      <- o espelhado com DINTERLIG ficou
            BLOCO;246;BTMIRROR;1;SIM;NAO       <- o normal ficou
            TOTAL;blocos;2;espelhados;1
```

Ou seja: **só** o espelhado sem o cabo de aranha foi apagado, os outros dois ficaram, e a segunda
chamada da mesma passada não acha mais nada (idempotência).

> **A outra pendência de ferramenta — o contador da cor:** a tentativa de consertar o
> aninhamento do `cad-conta-cores.lsp` mostrou um **desequilíbrio de parênteses** na cauda do
> arquivo e foi **revertida**; o contador volta ao estado anterior (saldo 0) e segue como
> pendência pequena. A evidência que ele daria já está coberta pelo dump da fixture (rodada 91)
> e pelos números do próprio comando (rodada 93).

**Rodada 93 — `ApagaBlocosMirror` (frente 2 do §7.6, parte 21: os blocos espelhados).**
O `clsUtilitarios.cs`: apaga os blocos de referência que

1. têm **algum** XData (`val6.XData != null`);
2. **não** têm o app `DINTERLIG` (o cabo de aranha);
3. estão **espelhados** — fator de escala em X **negativo** (`ScaleFactors.X &lt; 0`).

O original apaga em silêncio (sem contagem nem mensagem); o comando do recoder **reporta** os
números.

**Medido no ZWCAD 2026** (`..\Elet\Teste_projeto_real\Funcional.dwg`, DWG 63):

```text
ApagaBlocosMirror: 0 bloco(s) espelhado(s) apagado(s) (0 espelhado(s) entre 521 com XData; 0 são cabo de aranha e ficam; 557 bloco(s) lido(s)).
```

**Não há bloco espelhado com XData nesta cópia** — 557 blocos lidos, 521 com XData e **0** com
escala X negativa —, então o caminho de apagar **não é exercitado** aqui: fica registrado como
pendência de fixture sintética (um `INSERT` com `(41 . -1)` e um XData qualquer resolve).

> **Nota de ferramenta:** o contador `scripts/cad-conta-mirror.lsp` **não produziu saída** (a
> mesma família de armadilhas do `entget` com app names / `APPID` das rodadas 90/91); os
> números acima vêm do próprio comando.

**Classificação registrada — a família de atributos sai do recorte:**
`LeAtributos`/`LeTodosAtributos` + `CorrigeAtributos`/`CorrigeAtributosSemMsg`/
`PreencheNovosAtributos` operam sobre o buffer **estático** `clsTrocaEditaBlocosMat.mAtributos`,
que é preenchido por uma **tela** (a grade de atributos) e aplicado depois — sem a tela não há o
que aplicar (mesmo caso do `PesquisaBlocos`).

**Rodada 92 — `Limpahandle` (frente 2 do §7.6, parte 20: os handles das derivações).**
O `limpaHandleSuperior` do `Correcao.cs`, que é `[CommandMethod("Limpahandle")]` — e a
**primeira metade** do `CorrigeHandleSuperior`: zera o `Handle` do XData `CONEXAO` de cada
polilinha de **derivação** (tipo **3**).

A gravação troca **um valor** do registro do app dentro do buffer da polilinha (o `Handle` é o
`valores[3]` do leitor), preservando os outros app names — a mesma técnica da rodada 86.

**Medido no ZWCAD 2026** (`..\Elet\Teste_projeto_real\Funcional.dwg`, DWG 63). O contador
independente `scripts/cad-conta-derivacoes.lsp` roda **no load** (lição das rodadas 90/91: a
linha de comando LISP depois do `NETLOAD` não executa no desenho real):

```text
antes:  TOTAL;conexoes;365;derivacoes;167;comHandle;167
comando: Limpahandle: 167 handle(s) de derivação zerado(s) (167 derivação(ões) em 365 conexão(ões) lida(s)).
```

**A idempotência foi medida na MESMA passada** (`-Comandos "Limpahandle,Limpahandle"`): `167` e
depois **`0`** — a segunda chamada não acha nada. (Passadas separadas acham 167 de novo porque o
harness **sempre parte de uma cópia limpa** do desenho — o que invalidaria a comparação e virou
nota de método.)

> **Desvios registrados:** o gate de hardlock (`companyHardlock == "CADGRAPH"`) não existe no
> recoder; e o original regrava **toda** derivação a cada passada, enquanto aqui só as que têm
> handle (mesmo efeito, convergência medível).

**`PesquisaBlocos`, investigado e classificado:** é um comando **só de UI** (`new frmNavegador()`,
também sob o hardlock) — sai do recorte. E o `CorrigeHandleSuperior` fica como fatia pendente do
**resolvedor por ponto** (`verificaConexao`: o bloco sob o ponto inicial da polilinha), que o
recoder ainda não tem; a metade que ele chama já está entregue nesta rodada.

**Rodada 91 — o quirk do nome, medido no desenho real (frente 2, ferramenta/evidência).**
Fecha a segunda pendência da rodada 88 **por outra via** e mede a consequência do quirk.

**Duas coisas atrapalharam o contador** `scripts/cad-conta-cores.lsp`, e as duas ficaram
diagnosticadas:

- a **linha de comando LISP** depois do `NETLOAD` **não executa** no desenho real (o comando do
  plugin roda na mesma passada, a LISP não — rodada 90);
- o arquivo tem um **erro de aninhamento**: o `(defun pz-cor:conta ...)` fecha **depois** das formas
  finais — o saldo total do arquivo é 0, mas a chamada do fim fica **dentro** do defun. A prova são
  os marcadores de carga, que param em `6 conta` sem nenhum `C0 entrou no conta`.

A contagem saiu então do **dump da própria fixture** (`pz-cf:conta`), que roda no desenho real como
rodou no sintético.

**Medido no ZWCAD 2026** (`..\Elet\Teste_projeto_real\Funcional.dwg`, DWG 63):

```text
CorrigeCoresDosBlocos: 1 atributo(s) com a cor corrigida (1 bloco(s); 198 atributo(s) de definição em 45 nome(s) de bloco).
COR;396E;MascaraM.DWG;ALTERNATIVO;256;2
...
TOTAL;referencias;1979;diferencas;50;insercoes;558
```

(O dump escreve **uma linha por referência** e o `TOTAL` traz a contagem real de diferenças — o
`diferencas;50` é o número.)

**O achado:** as **50 diferenças estão todas num único bloco, o `MascaraM.DWG`** — justamente o
bloco cujo nome **quebra o quirk do original**: a passada 3 compara
`P_1.Contains(val6.Name.ToUpper())` e a lista da passada 1 guarda o nome **cru** (`MascaraM.DWG`),
então o `MASCARAM.DWG` procurado **não está** na lista e o bloco é pulado. Todos os outros **44**
nomes têm **0** diferenças.

Ou seja: o port **reproduz fielmente** o original (que também pula esse bloco), e a **única**
divergência entre referência e definição no desenho real é exatamente a **fronteira de cobertura do
quirk** — e o caminho de escrita, quando o nome casa, funciona (foi o caso do `BTZX` da fixture,
com a cor 1 → 3).

> **Pendência que sobra (pequena):** consertar o aninhamento do `cad-conta-cores.lsp` para ele rodar
> sozinho no desenho real (ou manter a via do dump da fixture, que é a que deu a evidência).

**Rodada 90 — o caminho de escrita do `CorrigeCoresDosBlocos`, provado (frente 2, ferramenta/evidência).**
Fecha o **achado 1** da rodada 89 e a pendência de evidência da 88.

**O achado 1, resolvido:** o `entmake` do `ATTDEF` **dentro** do `BLOCK` criado por
`entmake` não funciona no ZWCAD — mas o **ATTDEF solto** (`entmakex`) e o bloco pela
**`_.-BLOCK`** (selecionando o ATTDEF) funcionam. A fixture foi reescrita nessa via e o rastro
confirma os 7 passos:

```text
1 ATTDEF solto
2 ATTDEF feito: <ENTITY NAME: d19d35d0>
3 bloco BTZX criado
4 insert feito
5 ATTRIB forcado para 1
6 XData no INSERT
7 fim da fixture
```

**O caminho de escrita, provado** — o `ATTRIB` da inserção foi forçado para a cor **1** e o
`ATTDEF` tem a cor **3**; depois do comando o dump mostra a referência já em **3** e nenhuma
diferença:

```text
CorrigeCoresDosBlocos: 1 atributo(s) com a cor corrigida (1 bloco(s); 1 atributo(s) de definição em 1 nome(s) de bloco).
COR;242;BTZX;T1;3;3
TOTAL;referencias;1;diferencas;0
```

**O contador (a outra pendência), avançado e ainda aberto.** O diagnóstico isolou duas coisas:

- a lista de app names agora é **filtrada por `tblsearch`** — o `entget` com um app name **não
  registrado** estoura, e era isso que derrubava o contador no desenho real (o `tblnext` sobre o
  `APPID` também se mostrou frágil);
- os marcadores de carga provam que o **load completa** e define tudo (marcas `0..6`) no desenho
  real, mas a **linha de comando LISP não executa** naquela passada: nenhum `C0 entrou no conta`
  aparece, **enquanto o comando do plugin roda** na mesma passada.

A causa **não foi isolada** e a pendência segue aberta com essa evidência exata (a suspeita é a
execução da própria linha do script depois do `NETLOAD`; o próximo passo é rodar o contador
sozinho no desenho real, sem o comando do plugin, e comparar com o irmão `cad-conta-portas.lsp`,
que funciona).

**Rodada 89 — diagnóstico da evidência da cor dos blocos (frente 2, sem comando novo).**
A pendência da rodada 88 era de **evidência**, não de código: o caminho de escrita do
`CorrigeCoresDosBlocos` não era exercitado (o desenho já está consistente) e o contador
`scripts/cad-conta-cores.lsp` não produzia saída. O que entrou e o que se aprendeu:

**1) A fixture sintética** `scripts/cad-fixture-cores.lsp` (e a versão com rastro
`scripts/cad-fixture-cores-trace.lsp`): um bloco com `ATTDEF` de cor **3**, uma inserção com o
`ATTRIB` em BYLAYER (256) e **algum XData** — o cenário mínimo em que o comando tem o que
corrigir.

**Achado 1 — o `entmake` do `ATTDEF` falha no ZWCAD.** O rastro para em `2 BLOCK-ok`:

```text
1 antes-do-BLOCK
2 BLOCK-ok
```

Nem o `ATTDEF` nem o `INSERT` entram: o comando vê `0 nome(s) de bloco com XData` e o dump
`insercoes;0`. Não adiantou pôr os marcadores de subclasse
(`100 AcDbEntity`/`AcDbText`/`AcDbAttributeDefinition`) nem corrigir a ordem dos grupos
(o `62` antes do `70`). Registrado como bloqueio de ferramenta; o caminho para o cenário
sintético de blocos com atributos passa por outra via (definir o bloco por `_.BLOCK` e o
atributo por `_.ATTDEF` em script, ou usar um bloco existente do próprio desenho).

**2) O contador** foi reescrito para usar uma **lista fixa** de app names no lugar do
`tblnext` sobre o `APPID` (que estourava no ZWCAD — de novo a lição da rodada 75).

**Achado 2 — o contador roda na fixture, mas não no desenho real.** No desenho da fixture o
dump sai completo:

```text
COR;handle;nome;tag;corRef;corDef
TOTAL;referencias;0;diferencas;0;insercoes;0
```

No `Funcional.dwg` (DWG 63) o arquivo de saída **continua não sendo criado**, mesmo com o
comando rodando (o `POSITRON_LOG` mostra a linha do plugin). A causa **não foi isolada**; o
próximo passo é pôr marcadores de carga no próprio contador — a mesma técnica do rastro que
resolveu o achado 1.

**O que ficou provado:** a medição do comando no desenho real se reconfirma —
`CorrigeCoresDosBlocos: 0 atributo(s) com a cor corrigida (0 bloco(s); 197 atributo(s) de definição em 44 nome(s) de bloco)`.

> **Pendência que segue aberta (registrada):** exercitar o caminho de escrita do
> `CorrigeCoresDosBlocos` — bloqueada pelo `entmake` do `ATTDEF` — e fazer o contador rodar
> no desenho real. Junto delas continuam as pendências das rodadas 86 e 87: a renumeração do
> dicionário do `CorrigeModelosDeContatos` e o `NOME1`/`ORIGEM` + `IndefineUmaPorta` do
> `corrigePortas`.

**Rodada 88 — `CorrigeCoresDosBlocos` (frente 2 do §7.6, parte 19: a cor dos atributos).**
O comando com os três métodos do `Correcao.cs` — e o único até agora com nomes ofuscados
(`MMg1xjoRaA` e `lu61bhmRNc`):

1. `carregaBlocosInseridos` — os **nomes** dos blocos inseridos no ModelSpace que têm **algum**
   XData (**44** nomes nesta cópia);
2. `MMg1xjoRaA` — para cada nome, varre a **definição** (`BlockTable[nome]`) e guarda a cor de
   cada `AttributeDefinition` (**197** atributos);
3. `lu61bhmRNc` — para cada inserção cujo nome entra na lista, acerta a cor de cada
   `AttributeReference` com a da definição (só quando difere).

> **Quirk reproduzido:** a lista da passada 1 guarda o nome **cru**, e a passada 3 compara com
> `nome.ToUpper()` — o original só acerta os blocos cujo nome já está em caixa alta. A
> comparação do **tag** é sem caixa (`TextCompare`).

**Medido no ZWCAD 2026** (`..\Elet\Teste_projeto_real\Funcional.dwg`, DWG 63):

```text
CorrigeCoresDosBlocos: 0 atributo(s) com a cor corrigida (0 bloco(s); 197 atributo(s) de definição em 44 nome(s) de bloco).
```

Ou seja: 44 nomes de bloco entraram, 197 definições de atributo foram lidas e **nenhuma**
referência precisou mudar — o desenho já está consistente. O caminho de escrita **não é
exercitado** nesta cópia: fica registrado como pendência de fixture sintética (um desenho com
uma referência de cor diferente da definição).

> **Nota de ferramenta:** o contador `scripts/cad-conta-cores.lsp` **não produziu saída** nesta
> rodada (falha de carga/runtime do LISP — o saldo de parênteses está em 0; a suspeita é o
> `tblnext`/a lista de app names), então ele **não** entrou como evidência. O número acima vem
> do próprio comando. Fica como pendência fechar o contador junto da fixture sintética.

**Rodada 87 — `corrigePortas` (frente 2 do §7.6, parte 18: os atributos das portas).**
O `EditaTodasPortas` do `clsPortas.cs`: junta as portas de todos os modelos do dicionário
`MASCARAS` (o `MODELOS2` + a chave `<indice>` de cada modelo — **240 portas** nesta cópia) e
reescreve os atributos dos blocos de **porta** (Dispositivo tipo `E`), casados pelo par
`indiceDoModelo`/`indiceDaPorta` do XData `Dispositivo` (valores 5 e 6, como o `StructurePortas`
do reverso).

| tag | regra |
|---|---|
| `EFC` | o `sEFC` da porta |
| `T<n>` | o terminal `n` — ou o caracter de terminal indefinido quando o campo está vazio |
| `B<n>` | o borne `n` **sem** o `*` da frente (um espaço quando não há) |
| `R<n>` | a régua, e o atributo fica **visível só** quando aquele borne tinha o `*` |

O `SepararBornes` guarda a marca do asterisco e tira ele do valor (o laço de `Mid(borne, 2)` do
original).

> **Fora deste recorte, documentado:** as tags `NOME1` (o nome da máscara pelo `HandleDaMascara`)
> e `ORIGEM` (a página do texto da definição) — faltam os dois `Busca*` do original no recoder
> (`clsMascara.BuscaNomeDaMascara` e `clsTextos.EncontraPaginaDoTexto`) — e o
> `IndefineUmaPorta` que o original roda na porta que **não** está no dicionário (aqui a porta
> fica como está e é contada à parte).

**Medido no ZWCAD 2026** (`..\Elet\Teste_projeto_real\Funcional.dwg`, DWG 63) com o contador
independente `scripts/cad-conta-portas.lsp`:

```text
antes:  PORTA;13CE5;V_E_CONTATO_NA1;5;7;;13;14;;;;      <- modelo 5, porta 7, T1 13, T2 14
        PORTA;39A0;V_E_BTERRA;1;1;;1;;;;;
        TOTAL;blocos;45;comDispositivo;45
depois: corrigePortas: 0 atributo(s) e 0 visibilidade(s) regravado(s) em 45 de 45 bloco(s) de porta
        (240 porta(s) no dicionário; 0 fora dele — o IndefineUmaPorta fica fora deste recorte).
```

Ou seja: **45 de 45** blocos de porta casaram com uma porta do dicionário (o pareamento está
certo) e **nenhum** atributo precisou mudar — o cadastro e o desenho já concordam nesta cópia.
As regras (incluindo a visibilidade da régua e o `*` dos bornes) ficam provadas pelos 7 testes.

**Rodada 86 — `CorrigeModelosDeContatos` (frente 2 do §7.6, parte 17: o índice do contato).**
O par do `CorrigeBlocosContatosAux` da rodada 85: aquele reescreve os **terminais**; este acerta o
**índice do contato**. Quando o `Indice` de um contato do `CONTATOS` **não é o da sua posição**
na lista do modelo, o original renumera o dicionário (1, 2, 3...) e grava o índice novo no
desenho — no XData **`Dispositivo`** (blocos auxiliares tipo `A`, valor 6) e no XData
**`Modelo`** (valor 3). A regra pura é `CorrecaoModeloDeContato.Planejar`/`ContatoNovo`.

A gravação troca **só o registro do app** dentro do buffer do bloco (o precedente da rodada 77);
o original troca o buffer inteiro. No fim o comando chama o `CorrigeContatosAux` (rodada 77),
como o original.

> **Escopo registrado (fora):** a renumeração do **dicionário**
> (`GravaOsContatosAuxiliarDoModeloDoDicionario`) e o `SincronizaContatos` do fim. O motivo
> do dicionário ficar de fora é concreto: o leitor do recoder **recalcula a orientação** ao
> ler (`OrientacaoContato`, desvio documentado de rodada anterior), então gravar de volta o
> que se leu persistiria a orientação recalculada em vez da original — o escritor precisa do
> registro cru antes.

**Medido na fixture sintética** (`scripts/cad-fixture-modelos-contatos.lsp`: um `CONTATOS` com o
modelo 53 e os contatos de índice **7** e **9**, e um bloco `A` apontando o contato 7):

```text
CorrigeModelosDeContatos: 2 contato(s) renumerado(s); 1 bloco(s) com o XData Dispositivo e 0 com o XData Modelo regravado(s) (1 auxiliar(es) lido(s)).
BLOCO;A;53;1        <- o IndexContato do bloco passou de 7 para 1 (o da posição)
```

**Medido no desenho real** (`..\Elet\Teste_projeto_real\Funcional.dwg`, DWG 63):

```text
CorrigeModelosDeContatos: nenhum contato fora da posição (8 modelo(s) e 26 contato(s) no CONTATOS) — nada a corrigir.
CorrigeContatosAux: 0 de 129 modelo(s) com o HandleContatoAux acertado (63 bloco(s) auxiliar(es) lido(s); 66 modelo(s) sem contato casado).
```

Ou seja: o dicionário desta cópia **já está consistente** e o comando é no-op aqui (é o mesmo
caminho de saída antecipada do original, `if (array2.Count() <= 1) return`); o caminho de escrita
fica provado pela fixture.

**Rodada 85 — `CorrigeBlocosContatosAux` (frente 2 do §7.6, parte 16: os terminais dos blocos auxiliares).**
O par de escrita do `bt4Auxiliar`: para cada bloco de **Dispositivo tipo `A`**, casa o par
`IndexModelo`/`IndexContato` com um contato do dicionário `CONTATOS` e reescreve os atributos
`T1`, `T2` e `T3` com o que diz o contato (o `AtualizaOsTerminaisAuxiliares`).

| tag | regra |
|---|---|
| `T1` | sempre `sT1` |
| `T2` | `sT2`, **exceto** com o tipo do contato `RV`: aí o **tipo do bloco** decide — `NA` recebe `sT3`, `NF`/`RV` recebem `sT2`, qualquer outro **não mexe** |
| `T3` | `sT3`; com o tipo `NA` e o `sT3` vazio, cai no `sT2` |
| outra | não mexe (a sentinela `##VAZIO##` do original) |

O **tipo do bloco** sai do próprio nome: `Mid(nome, 5, 2)` — os **dois** caracteres da quinta
posição. (O deslocamento importa: `BT4NAXX` é `AX`, não `NA`; o teste guarda isso.)

> **Achado medido:** os blocos auxiliares desta cópia **não têm o XData `Modelo`**. O par
> `IndexModelo`/`IndexContato` vem do XData **`Dispositivo`**: tipo `A` no valor 1, `IndexModelo`
> no **5** e `IndexContato` no **6** — exatamente os `array[5]`/`array[6]` que o
> `LeXDataQualquerDispositivo` do reverso lê para o `StructureAuxiliar`. O primeiro corte do
> adapter lia o `Modelo` e casava **0 de 63**; corrigido, casa 63 de 63.

**Medido no ZWCAD 2026** (`..\Elet\Teste_projeto_real\Funcional.dwg`, DWG 63) com o contador
independente `scripts/cad-conta-contatos-aux.lsp`:

```text
CorrigeBlocosContatosAux: 0 atributo(s) regravado(s) em 63 de 63 bloco(s) auxiliar(es) (8 modelo(s) e 26 contato(s) no CONTATOS).
BLOCO;7367;V_A_NA1_ST;53;2;21;24;        <- modelo 53, contato 2, T1 21, T2 24, T3 vazio
BLOCO;11D34;V_A_RV1I5_MOD_ST;53;1;11;12;14
BLOCO;1C7D7;V_A_NA13_ST;9;1;11;;14
TOTAL;blocos;63;comModelo;63
```

Ou seja: **o cadastro e o desenho já concordam** — o comando não tem o que corrigir nesta cópia
(o valor calculado é igual ao que está no atributo). As ramificações, incluindo o `RV`/`NA` e
o deslocamento do `Mid`, ficam provadas pelos 11 testes.

> **Fora do recorte, documentados:** o `iContatoNovo` que o original calcula e **não usa**, a
> barra de progresso e o `atualizaXdata` (este comando não mexe no XData do bloco).

**Rodada 84 — `REMLAYDUP` (frente 2 do §7.6, parte 15: o dedup do CENG_LAYOUT).**
O `RemoveDuplicadoLayoutRapido` do `Correcao.cs`: para cada painel **do cadastro**
(`Paineis`), lê as chaves `P<painel>` e `C<painel>` do dicionário nomeado `CENG_LAYOUT` —
o mesmo que o `FIA` lê para o `PosicaoNum` e o `COMPLM` para o `OrdemLay` —, tira os **tags
repetidos conservando o primeiro** e regrava a chave.

O registro cru tem **5 valores por posição** (`gravaDicLayout`): tag e alternativo em 1, X e Y em
40 e um campo vazio em 1. Entraram `LayoutPosicoes.PosicaoBruta` + `LerBruto`/`ParaValores`.

> **Quirk reproduzido (e medido):** o laço do original vai de `0` a `UBound - 1` — o
> **último registro de cada chave é descartado**, mesmo quando não há duplicado. O comando é
> **destrutivo se repetido** (é o "Rapido" do nome): rodar duas vezes come outro registro por
> chave. Como no original, o uso é uma passada.

**Medido na fixture** (`scripts/cad-fixture-layout.lsp`: `P3` = A|B|A|C, `C3` = X|Y e `P999` =
M|N, com o 999 **fora** do cadastro):

```text
-- antes ---------------------------------------------------------------
CHAVE;C3;2;X|Y          CHAVE;P3;4;A|B|A|C          CHAVE;P999;2;M|N
-- depois (1a passada) ------------------------------------------------
REMLAYDUP: 2 de 2 chave(s) de layout regravada(s) (6 registro(s) -> 3; 480 painel(is) do cadastro).
CHAVE;C3;1;X            CHAVE;P3;2;A|B              CHAVE;P999;2;M|N   <- intacta
-- depois (2a passada, o quirk) ---------------------------------------
REMLAYDUP: 2 de 2 chave(s) de layout regravada(s) (3 registro(s) -> 1; 480 painel(is) do cadastro).
CHAVE;C3;0;             CHAVE;P3;1;A
```

**Medido no desenho real** (`..\Elet\Teste_projeto_real\Funcional.dwg`, DWG 63) com o contador
independente `scripts/cad-conta-layout.lsp`:

```text
antes:  TOTAL;chaves;14;registros;340
REMLAYDUP: 14 de 14 chave(s) de layout regravada(s) (340 registro(s) -> 326; 480 painel(is) do cadastro).
depois: TOTAL;chaves;14;registros;326
```

As 14 chaves perdem exatamente **um** registro cada — ou seja, **não havia duplicado nenhum**
nesta cópia (as tags do `C503`, por exemplo, são todas distintas; o `P503` idem). O efeito
medido no desenho real é só o do quirk; os casos com duplicado ficam provados pela fixture.

**Rodada 83 — `LimpaTextosLPCopiados` (frente 2 do §7.6, parte 14: a sexta limpeza).**
Tira o XData `TextoLP` (o rótulo **copiado de outra página**) do ModelSpace. A regra:

| entidade | condição |
|---|---|
| `DBText` | sai **sempre** (o ramo do original não olha o Y) |
| `MText` | sai só quando está **abaixo do topo** do desenho — o maior Y arredondado das polilinhas `CONEXAO` do **tipo 1** |

A gravação é o `LimpaXData` do original: o buffer inteiro vira a **marca única** (um 1001
com o app name), a mesma gravação do `apagaXDataTerceiros` da rodada 70 — o `MarcaUnica`
ficou compartilhado em `LimpezaDoDesenho`.

**Medido na fixture** (`scripts/cad-fixture-textolp.lsp`: topo em y=10, MTEXT em y=5, MTEXT em
y=20, TEXT em y=30 e TEXT sem XData em y=40):

```text
LimpaTextosLPCopiados: 2 de 3 texto(s) com XData TextoLP limpo(s) (topo do desenho 10).
TEXTO;MTEXT;(0.0 5.0 0.0);       <- abaixo do topo: limpo (só a marca, grupo vazio)
TEXTO;MTEXT;(0.0 20.0 0.0);1     <- acima do topo: FICOU com o XData (1 valor)
TEXTO;TEXT;(0.0 30.0 0.0);       <- DBText acima do topo: limpo
TEXTO;TEXT;(0.0 40.0 0.0);       <- sem o XData: não é tocado
```

**Medido no desenho real** (`..\Elet\Teste_projeto_real\Funcional.dwg`, DWG 63):

```text
LimpaTextosLPCopiados: nenhum texto com XData TextoLP (136 MTEXT e 616 TEXT lido(s); topo do desenho 255,3).
```

O `TextoLP` não aparece nesta cópia (também não estava no inventário de app names da rodada 77),
então o comando é **no-op** aqui — e o caminho de escrita fica provado pela fixture. Os 616
TEXT lidos batem com o número da rodada 70.

> **Lição de ferramenta:** a fixture passou a definir o **dump antes do desenho**. No primeiro
> recorte o saldo de parênteses estava certo e, mesmo assim, o arquivo de saída não saía — uma
> linha do setup estourava e levava o `defun` do dump junto. Com as definições primeiro, o
> dump sobrevive ao setup.

**Rodada 82 — `AtualizaOpcionaisDoCabo` (frente 2 do §7.6, parte 13: a receita de opcionais).**
O comando do `clsUtilitarios.cs` que o `RecriaTextosCabo` chama no layout 3 — e o único
ponto daquele caminho que ficava por documentar. O campo **opcionais** do XData
`AUXINTERLIG` é uma **receita** separada por `#`; cada token vira um pedaço do texto:

| token | vira |
|---|---|
| `C` | a tag do cabo |
| `V` | o nome da veia no catálogo (`BuscaNomeVeia`, que devolve o **número** quando o nome está vazio) |
| `N` | o `NomeVeia` do trecho |
| `FU` / `FO` | a função da veia / a formação do cabo (do catálogo) |
| `(` `)` `/` `-` | eles mesmos; `E` vira espaço |
| qualquer outro | nada |

**Quirks reproduzidos:** o laço vai de `0` a `UBound - 1` — o **último token é
descartado** (a receita termina com um token que não entra); com `NumVeia == -1000` o texto
inteiro é **zerado** (no `V` e de novo depois do laço); texto só de pontuação/espaço vira o
`?` do terminal indefinido; o `()` some e os espaços duplos colapsam em **duas** passadas.

**Medido na fixture** (`scripts/cad-fixture-opcionais.lsp`: um rótulo tipo 3 com a receita
`C#-#N#` e um tipo 1 ao lado):

```text
AtualizaOpcionaisDoCabo: 1 de 1 rótulo(s) com os opcionais atualizados (2 rótulo(s) auxiliares lido(s); 0 sem trecho resolvido).
AtualizaOpcionaisDoCabo: 0 de 1 rótulo(s) com os opcionais atualizados (2 rótulo(s) auxiliares lido(s); 0 sem trecho resolvido).
ROTULO;CABO-1-V1;3;C#-#N#      <- C + - + N (o último token, vazio, é descartado)
ROTULO;NAO-MEXE;1;             <- o tipo 1 fica intacto
```

**Medido no desenho real** (`..\Elet\Teste_projeto_real\Funcional.dwg`, DWG 63):

```text
AtualizaOpcionaisDoCabo: 0 de 0 rótulo(s) com os opcionais atualizados (24 rótulo(s) auxiliares lido(s); 0 sem trecho resolvido).
```

Os 24 rótulos da cópia são do **tipo 1** — nenhum dos tipos 3..6 que este comando olha —, então
aqui ele é **no-op**; o caminho de escrita fica provado pela fixture. É o mesmo tipo de medição
honesta das rodadas 74 e 77 (o zero é o dado, não um silêncio do comando).

> **Fora do recorte, documentado:** o `clsEditarInterligacao.AtualizaNomesDosCabos` do fim do
> original (outra passada de nomes) e a barra de progresso (`_uscPagina`).

**Rodada 81 — `CorrigeCabosSingelos` (frente 2 do §7.6, parte 12: os cabos singelos do catálogo).**
A primeira correção da frente que mexe **no banco e no desenho**. O original:

1. `SELECT Tag FROM Cabos WHERE Cabos = 1` — os candidatos do catálogo;
2. para cada um, `SELECT Nome_Veia FROM Veias WHERE DWG=@dwg And Tag=@tag And indice > 0`, e entra na lista quando vem **exatamente uma** linha e o nome tem `#`;
3. `UPDATE Veias Set Nome_Veia='' WHERE Tag=@tag` — **sem** o filtro de arquivo (quirk reproduzido: o update é mais largo que a leitura);
4. limpa o `NomeVeia` do XData dos trechos com aquele `Tag_Cabo` e, no fim, **sempre** chama o `RecriaTextosCaboEletrosul`.

> **Achado medido — a consulta 2 do reverso não roda.** Ela cita uma coluna `DWG` que a
> tabela `Veias` **não tem**, nem no `RCD.mdb` do próprio produto: as colunas são
> `Tag, Indice, Nome_Veia, Uso, Handle, Arquivo, Pagina, Chave, Funcao`. Com a coluna do
> reverso a consulta estoura, o `catch` do original relança e o comando **não faz nada**.
> O recoder usa `Arquivo` — a coluna que existe e a que o `LerVeias` lê — e registra o
> desvio.

**Medido com o banco semeado** (`scripts/cad-seed-singelos.py` cria um `Cabos` com
`Cabos = 1` e uma `Veias` com `#`):

```powershell
& services/sidecar/.venv/Scripts/python.exe scripts/cad-seed-singelos.py "$env:TEMP\positron-singelos.db" 63 CABO-SINGELO
$env:POSITRON_XDATA = "$env:TEMP\positron-singelos.txt"
powershell -ExecutionPolicy Bypass -File scripts/cad-zwcad-smoke.ps1 -Dwg 63 -Revisao R1 `
  -Fixture scripts/cad-fixture-singelos.lsp `
  -Comandos "CorrigeCabosSingelos,(pz-sing:dump)" `
  -Banco "$env:TEMP\positron-singelos.db"
```

```text
CorrigeCabosSingelos: 1 trecho(s) com o NomeVeia limpo (1 cabo(s) candidato(s); 1 tag(s) com Cabos = 1; 1 veia(s) no catálogo; 1 linha(s) do banco atualizada(s); 1 trecho(s) varrido(s)).
RecriaTextosCaboEletrosul: 1 texto(s) e 0 ornamento(s) apagado(s); 1 rótulo(s) e 2 ornamento(s) reinserido(s) de 1 trecho(s) (1 cabo(s) singelo(s) no catálogo).
TRECHO;23F;CABO-SINGELO;1;          <- o NomeVeia do XData ficou vazio
ROTULO;CABO-SINGELO;1                <- o rótulo recriado: só a tag (o cabo é singelo)
```

E o banco, conferido **por fora** do plugin (`sqlite3`): `[('CABO-SINGELO', '')]`.

**Medido no desenho real** (`..\Elet\Teste_projeto_real\Funcional.dwg`, DWG 63) — o mesmo 0 que
a consulta direta ao projeto previa:

```text
CorrigeCabosSingelos: 0 trecho(s) com o NomeVeia limpo (0 cabo(s) candidato(s); 697 tag(s) com Cabos = 1; 2388 veia(s) no catálogo; 0 linha(s) do banco atualizada(s); 0 trecho(s) varrido(s)).
RecriaTextosCaboEletrosul: 24 texto(s) e 0 ornamento(s) apagado(s); 20 rótulo(s) e 40 ornamento(s) reinserido(s) de 20 trecho(s) (305 cabo(s) singelo(s) no catálogo).
```

> **Lição de ferramenta (a terceira da família):** de novo o **saldo de parênteses** da fixture —
> desta vez com um `)` a mais no fim do dump, o `load` parou antes de definir a função e o
> arquivo de saída simplesmente não existia, sem erro no `POSITRON_LOG`. Conferir o saldo antes
> de rodar continua sendo mais barato.

**Rodada 80 — `AdicionaCaboEletrosul` (frente 2 do §7.6, parte 11) e a correção da geometria da Eletrosul.**
Fecha o que a rodada 79 deixou de fora (as duas entidades) e **corrige** o que ela mediu errado:
o `criarTextoNomeCaboEletrosul` chama o `AdicionaCaboEletrosul`, que **reescreve o
`mCenterPt` por referência** — e o texto usa o ponto **já mexido**.

| Peça | O que é |
|---|---|
| elipse | no **meio do segmento**, eixo maior conforme a direção (`Vertical` → (1,0,0), senão (0,1,0)), raio 0.6, cor `CorInterligacao`, no layer do trecho |
| "leader" | polilinha de **três vértices** — (x+1,y),(x+2,y),(x+2,y) na horizontal e (x,y+1),(x,y+2),(x+1,y+2) na vertical — com o `EstiloLinha` e a escala |
| XData | os dois levam `ELETROSUL` tipo **0** com o handle do trecho (é esse XData que a limpeza da passada seguinte apaga) |
| texto | no **fim do leader**: `p8.X + 1` (vertical) ou `+ 2` (horizontal), com o Y em `p8.Y - FonteCabos * 0.85` |

**A correção (registrada):** a rodada 79 portou o rótulo no **meio do segmento** e mediu
`(5.0 0.0)`; o original põe o texto no fim do leader — para o mesmo trecho da fixture, o
ponto é `(9.0 -1.275)`. A fixture é a mesma; só o ponto mudou:

```text
RecriaTextosCaboEletrosul: 1 texto(s) e 2 ornamento(s) apagado(s); 1 rótulo(s) e 2 ornamento(s) reinserido(s) de 1 trecho(s).
AUXILIAR;ELETROSUL;;;(5.0 0.0 0.0);(0.0 1.0 0.0);      <- a elipse no centro (5,0), eixo (0,1,0)
AUXILIAR;ELETROSUL;;;(6.0 0.0);;                        <- o leader, primeiro vértice (6,0)
AUXILIAR;AUXINTERLIG;1;CABO-1/2;(9.0 -0.830935 0.0);(9.0 -1.275 0.0);0.0   <- o texto no fim do leader
```

**Medido no desenho real** (`..\Elet\Teste_projeto_real\Funcional.dwg`, DWG 63):

```text
RecriaTextosCaboEletrosul: 24 texto(s) e 0 ornamento(s) apagado(s); 20 rótulo(s) e 40 ornamento(s) reinserido(s) de 20 trecho(s) (305 cabo(s) singelo(s) no catálogo).
RecriaTextosCaboEletrosul: 20 texto(s) e 40 ornamento(s) apagado(s); 20 rótulo(s) e 40 ornamento(s) reinserido(s) de 20 trecho(s).
TOTAL;60;AUXINTERLIG;20;ELETROSUL;40
INT: 20 linha(s) gravada(s) em Interligacao4 (199 borne(s)).   VERIF: 249 problema(s).   <- sem regressão
```

> **Lição de ferramenta:** o contador de auxiliares passou a **reler a lista do APPID na hora do
> dump**, e não no load. O plugin registra o app name `ELETROSUL` no meio da execução, e o
> `entget` só devolve os app names que recebe — com a lista de antes das ações, os 40
> ornamentos recém-criados apareciam como "sem XData" e o `TOTAL` dizia 20 em vez de 60. É a
> mesma família da lição da rodada 70, com o **tempo da leitura** a mais.

**Rodada 79 — `RecriaTextosCaboEletrosul` (frente 2 do §7.6, parte 10: o irmão da Eletrosul).**
O segundo comando da dupla: **a mesma limpeza** da rodada 78 e um rótulo por trecho, com a
geometria própria da Eletrosul.

| Peça | Padrão (rodada 78) | Eletrosul (rodada 79) |
|---|---|---|
| alinhamento | meio do segmento + **1** unidade na perpendicular | **meio do segmento** (`num5 = 0.0`) |
| rotação | a do segmento (com meia volta fora do meio-plano) | **0** sempre |
| modo horizontal | bottom-**center** | bottom-**left** |
| quem entra | só o trecho **sem** rótulo | **todo** trecho |
| `iModeloVeiaFuncao` | 0 | **1** |
| texto, catálogo, XData | — | **os mesmos** (`TextoDoRotuloDeCabo`, `LerSingelos`, `AUXINTERLIG` tipo 1) |
| limpeza | `clsEletron.ApagarTodosOsTextosDasVeias` | **a mesma** (helper `ApagarRotulosDeCabo`) |

**Medido na fixture** (`scripts/cad-fixture-rotulos.lsp`, a mesma da rodada 78, só trocando o
comando): o alinhamento sai no **meio** do segmento e a rotação fica 0 —

```text
RecriaTextosCaboEletrosul: 3 rótulo(s) apagado(s) e 1 reinserido(s) de 1 trecho(s) (0 cabo(s) singelo(s) no catálogo).
TRECHO;240;CABO-1;2;1
AUXILIAR;AUXINTERLIG;1;CABO-1/2;(5.0 0.444065 0.0);(5.0 0.0 0.0);0.0     <- (5.0 1.0 0.0) no padrão
```

**Medido no desenho real** (`..\Elet\Teste_projeto_real\Funcional.dwg`, DWG 63) — os mesmos números e
**os mesmos textos** da rodada 78 (o texto não depende da geometria):

```text
RecriaTextosCaboEletrosul: 24 rótulo(s) apagado(s) e 20 reinserido(s) de 20 trecho(s) (305 cabo(s) singelo(s) no catálogo).
RecriaTextosCaboEletrosul: 20 rótulo(s) apagado(s) e 20 reinserido(s) de 20 trecho(s)   <- 2a passada: apaga e recria
INT: 20 linha(s) gravada(s) em Interligacao4 (199 borne(s)); 265/216/697/2388.
VERIF: 249 problema(s) — fiação: 0; interligação: 0; modelos: 0; desenho: 249.
```

E o contador confirma os 20 rótulos com os textos do produto
(`TOTAL;20;AUXINTERLIG;20;ELETROSUL;0`).

> **Fora do recorte, documentado:** o `AdicionaCaboEletrosul` (que o
> `criarTextoNomeCaboEletrosul` chama e que cria **duas entidades extras** com o XData
> `ELETROSUL`, mais a marca `H`/`V`) e o `bApaga`. A marca `H`/`V` já está isolada em
> `PosicaoDoRotuloDeCabo.SegmentoVertical`, pronta para o dia em que essas entidades entrarem.

**Rodada 78 — `RecriaTextosCabo` (frente 2 do §7.6, parte 9: o par de escrita dos rótulos).**
Fecha o par da limpeza da rodada 75: o `clsEletron.RecriaTextosCabo` apaga os rótulos
auxiliares e **reinsere um por trecho de interligação** que ficou sem rótulo, no **modelo
padrão** (`bPadraoEL = true`, `iModeloVeiaFuncao = 0`).

| Peça | Do original | No recoder |
|---|---|---|
| limpeza | `clsEletron.ApagarTodosOsTextosDasVeias` | igual — e **diferente** da rodada 75: o não-texto sai pelo `ELETROSUL` **ou** pelo `AUXINTERLIG` (ENEL), e o `DBText` pelos tipos **1, 4, 5 ou 6** |
| texto | `InsereTextosDeCabos` (layout ≠ 3) | `TextoDoRotuloDeCabo` |
| posição | `criarTextoNomeCabo` | `PosicaoDoRotuloDeCabo` (mesmo π arredondado) |
| catálogo | `SELECT Tag FROM Cabos WHERE Formacao like '%1x%'` | `ProjectStore.LerCabos()` + `IndexOf(1x)` |

**Medido no desenho real** (`..\Elet\Teste_projeto_real\Funcional.dwg`, DWG 63) — a prova mais
forte é a comparação com os rótulos do **próprio produto** (o dump da rodada 75):

```text
RecriaTextosCabo: 24 rótulo(s) apagado(s) e 20 reinserido(s) de 20 trecho(s) (0 já tinham rótulo; 305 cabo(s) singelo(s) no catálogo).
RecriaTextosCabo: 20 rótulo(s) apagado(s) e 20 reinserido(s) de 20 trecho(s) (...)   <- 2a passada: apaga e recria (não é idempotente de propósito)
INT: 20 linha(s) gravada(s) em Interligacao4 (199 borne(s)); 265 porta(s) em Portas4I; 216/697/2388.
VERIF: 249 problema(s) — fiação: 0; interligação: 0; modelos: 0; desenho: 249.
```

```text
ANTES (24 rótulos do produto)              DEPOIS (20 recriados)
8-CCE-001 … 8-CCE-002 (16)                 8-CCE-001 … 8-CCE-002 (16)
8-GGE-017/1, 8-GGE-017/2 (2 de cada)       8-GGE-017/1, 8-GGE-017/2 (1 de cada)
8-GGE-018/1, 8-GGE-018/2 (2 de cada)       8-GGE-018/1, 8-GGE-018/2 (1 de cada)
```

Os **20 textos são idênticos aos 20 distintos dos 24** do produto (os quatro pares repetidos são
dois trechos com o mesmo cabo): a recriação reproduz os rótulos do produto **texto a texto**,
inclusive os `NomeVeia` com `/N`, que saem do ramo `(NomeVeia)` com a tag na frente. E os
**305 cabos singelos** (`Formacao like 1x`) do catálogo são o que faz o `8-CCE-001` (uma veia)
sair **sem** o número.

Como o desenho real já tem rótulos, a **escrita do zero** é provada na fixture
`scripts/cad-fixture-rotulos.lsp` (um trecho sem rótulo válido, um rótulo velho, um texto comum
e duas linhas com os app names das variantes):

```powershell
$env:POSITRON_XDATA = "$env:TEMP\positron-rotulos.txt"
powershell -ExecutionPolicy Bypass -File scripts/cad-zwcad-smoke.ps1 -Dwg 1 -Revisao R0 `
  -Fixture scripts/cad-fixture-rotulos.lsp `
  -Comandos "RecriaTextosCabo,RecriaTextosCabo,(pz-rot:dump)" `
  -Banco "$env:TEMP\positron-rot.db"
```

```text
RecriaTextosCabo: 3 rótulo(s) apagado(s) e 1 reinserido(s) de 1 trecho(s) (0 já tinham rótulo; 0 cabo(s) singelo(s) no catálogo).
RecriaTextosCabo: 1 rótulo(s) apagado(s) e 1 reinserido(s) de 1 trecho(s) (0 já tinham rótulo; ...)
TRECHO;240;CABO-1;2;0
AUXILIAR;AUXINTERLIG;1;CABO-1/2;(0.225273 1.44407 0.0);(5.0 1.0 0.0);0.0
```

O `(5.0 1.0 0.0)` é o **ponto de alinhamento** que a geometria pura calcula para o segmento
(0,0)–(10,0) — o meio do segmento mais 1 unidade na perpendicular — e a rotação 0 confere; o
`TRECHO;…;0` é o `iModeloVeiaFuncao` regravado.

> **Configuração nova:** o rótulo lê `CorTextoInterligacao` (7), `FonteCabos` (1.5),
> `SeparadorCaboVeia` (`/`) e `InterligacaoLayout` (0) — os padrões do `XDataGeral.cs` do
> reverso — por arquivo (`positron.ini`) ou ambiente (`POSITRON_*`).
>
> **Fora do recorte, documentado:** o `RecriaTextosCaboEletrosul`, o `InterligacaoLayout == 3`
> (ENEL), o `bApaga` e o `AtualizaTodosOpcionaisDoCabo`.

**Rodada 77 — `CorrigeContatosAux` (frente 2 do §7.6, parte 8: o `HandleContatoAux`).** A
sexta `Corrige*` e o **par de escrita do `bt4Auxiliar`** (rodada 54): casa o bloco auxiliar
(tipo `A`) ao bloco de modelo pela chave `(HandleBob, indexModelo, indexContato)` e grava o
handle do auxiliar no `HandleContatoAux` do XData `Modelo`.

| Peça | Do original | No recoder |
|---|---|---|
| chave | `HandleBob` (sem caixa) + `indexModelo` + `indexContato` | igual (`CorrecaoContatoAuxiliar.Casa`) |
| desempate | o **primeiro** `A` da ordem do ModelSpace vence | igual (a lista vem nessa ordem) |
| quem não casa | grava `HandleContatoAux = ""` | igual |
| gravação | regrava **todo** bloco de modelo, sempre, trocando o buffer inteiro | só o que muda, e preservando os outros app names |

**Medido no desenho real** (`..\Elet\Teste_projeto_real\Funcional.dwg`, DWG 63) — o desenho do
produto **já está consistente**, e a correção reproduz o invariante:

```text
CorrigeContatosAux: 0 de 129 modelo(s) com o HandleContatoAux acertado (63 bloco(s) auxiliar(es) lido(s); 66 modelo(s) sem contato casado).
TOTAL;modelos;129;preenchido;63;vazio;66;auxiliares;63;comOutrosApps;0
```

Os **63** preenchidos são exatamente os 63 que casam com um auxiliar e os **66** vazios são os
que não têm auxiliar — o `bt4Auxiliar` não tem o que apontar nesta cópia, e a correção não
muda nada (o contador confirma antes e depois).

A conferência independente é o `scripts/cad-conta-contatos.lsp` (app names da tabela `APPID`,
uma linha por modelo e por auxiliar, mais o total):

```powershell
$env:POSITRON_XDATA = "$env:TEMP\positron-contatos.txt"
powershell -ExecutionPolicy Bypass -File scripts/cad-zwcad-smoke.ps1 -Dwg 63 -Revisao R0 `
  -Fixture scripts/cad-conta-contatos.lsp `
  -Comandos "CorrigeContatosAux,CorrigeContatosAux,FIA,VERIF,(pz-cc:conta)" `
  -Desenho ..\Elet\Teste_projeto_real\Funcional.dwg -Banco "$env:TEMP\positron-limpeza.db"
```

```text
FIA: 494 linha(s) em Fiacao (199 borne(s), 191 dispositivo(s), 83 posicao(oes)); 265 porta(s) em Portas4F; 168 borne(s) em Bornes4F; 70 contato(s) em Contatos4F; 83 dispositivo(s) em Dispositivos4F; 11 circuito(s) em Circuitos4F; 15 tipo(s) em Aplicacao4F.
VERIF: 249 problema(s) — fiação: 0; interligação: 0; modelos: 0; desenho: 249.
```

Como o desenho real não exercita a **escrita**, entra a fixture
`scripts/cad-fixture-contatos.lsp` — dois auxiliares (`1A/5/2` e `1A/5/9`) e quatro modelos
(um casando e vazio, um casando com o outro, um sem casamento e um com o handle errado):

```powershell
$env:POSITRON_XDATA = "$env:TEMP\positron-ca-fixture.txt"
powershell -ExecutionPolicy Bypass -File scripts/cad-zwcad-smoke.ps1 -Dwg 1 -Revisao R0 `
  -Fixture scripts/cad-fixture-contatos.lsp `
  -Comandos "CorrigeContatosAux,CorrigeContatosAux,(pz-ca:dump)" `
  -Banco "$env:TEMP\positron-ca.db"
```

```text
CorrigeContatosAux: 3 de 4 modelo(s) com o HandleContatoAux acertado (2 bloco(s) auxiliar(es) lido(s); 1 modelo(s) sem contato casado).
CorrigeContatosAux: 0 de 4 modelo(s) com o HandleContatoAux acertado (2 bloco(s) auxiliar(es) lido(s); 1 modelo(s) sem contato casado).
MODELO;247;1A;5;2;245      <- o vazio ganhou o handle do primeiro auxiliar
MODELO;248;1A;5;9;246      <- ganhou o do segundo
MODELO;249;2B;1;1;         <- sem casamento: continua vazio
MODELO;24A;1A;5;2;245      <- estava com ZZZ: corrigido
```

> **Duas lições de ferramenta desta rodada** (cada uma custou uma corrida de CAD):
>
> - **Fixture com `defun` desbalanceado:** faltava um `)` no fim do `pz-ca:dump` e o
>   `load` parou ali — como os `INSERT` já tinham sido executados, os comandos rodaram e só o
>   `(pz-ca:dump)` "não existia" (arquivo de saída ausente, **sem** erro no `POSITRON_LOG`).
>   Conferir o **saldo de parênteses** do script antes de rodar é mais barato que descobrir pelo
>   arquivo que não foi escrito.
> - **Split de linha em LISP:** o `pz-cc:sub` montava os pedaços com o `;` junto (o campo vazio
>   virava `";0"`), então o `TOTAL` contava **129 preenchidos** num arquivo cujas linhas diziam
>   63 — o dado por linha estava certo, o resumo mentia. O `substr` tem de **pular o separador**
>   (`(substr linha 1 pos)` e `(substr linha (+ pos 2))`).

**Rodada 76 — `corrigeDicMascaras` (frente 2 do §7.6, parte 7: o dicionário de máscaras).**
A quinta `Corrige*` e o **par de escrita do `bt13ReguaMascara`** (a checagem da régua da
máscara, rodada 52): normaliza a lista de portas de cada modelo do dicionário `MASCARAS`. O
que é puro está em `Positron.Data/Correcoes/CorrecaoPortasDaMascara.cs`; o XRecord é regravado
por `ModelosMascara.ParaValores` (o avesso do `LerPortas`).

| Passo | Do original | No recoder |
|---|---|---|
| dedup | `List.Contains` por `IndiceDaPorta`, fica a **primeira** | igual |
| ordem | `OrdenaAsPortasDoModeloMascara` (bolha por índice) | igual (o original ordena **duas** vezes — a segunda, dentro do gravador, é no-op) |
| `MaxIndice` | o cabeçalho começa em 0 e vira o **maior índice mantido** — não é preservado | igual — **quirk reproduzido** |
| gravação | regrava o registro de **todo** modelo, sempre | regrava **só o que muda** (desvio de propósito: a 2ª passada converge) |

**Medido no desenho real** (`..\Elet\Teste_projeto_real\Funcional.dwg`, DWG 63) — o dicionário tem
**16** registros e a lista `MODELOS2` **7** modelos (o plugin segue a lista, como o original):

```text
corrigeDicMascaras: 6 de 7 modelo(s) de máscara normalizado(s) (0 porta(s) duplicada(s) descartada(s); 240 porta(s) lida(s); 0 sem registro de portas).
corrigeDicMascaras: 0 de 7 modelo(s) de máscara normalizado(s) (0 porta(s) duplicada(s) descartada(s); 240 porta(s) lida(s); 0 sem registro de portas).
```

A conferência **independente** é o `scripts/cad-conta-mascaras.lsp`: ele lê o **XRECORD cru**
(o `entget` de um `XRECORD` mostra os valores **depois do grupo 280**, medido na sonda que
escolheu esta rodada) e conta, por modelo, o cabeçalho, as portas e as duplicadas:

```text
ANTES  MODELO;1;0;16;1,2,...,16;0      DEPOIS  MODELO;1;16;16;...;0     <- cinco cabeçalhos zerados viram 16/90/90/10/16
ANTES  MODELO;3;16;8;1,2,...,8;0       DEPOIS  MODELO;3;8;8;...;0       <- rebaixado: 16 com portas 1..8
ANTES  TOTAL;modelos;16;portas;240;duplicadas;0;header_zero;14
DEPOIS TOTAL;modelos;16;portas;240;duplicadas;0;header_zero;9
```

O caso do modelo 3 é o **quirk** do original medido no desenho: o cabeçalho era o **maior** (16)
e a maior porta é 8, então a correção o **rebaixa** — o gravador não lê o cabeçalho antigo.

Receita completa (a correção **antes** da projeção, para provar que o `Portas4F` não muda):

```powershell
$env:POSITRON_XDATA = "$env:TEMP\positron-mascaras.txt"
powershell -ExecutionPolicy Bypass -File scripts/cad-zwcad-smoke.ps1 -Dwg 63 -Revisao R0 `
  -Fixture scripts/cad-conta-mascaras.lsp `
  -Comandos "corrigeDicMascaras,corrigeDicMascaras,FIA,VERIF,(pz-masc:conta)" `
  -Desenho ..\Elet\Teste_projeto_real\Funcional.dwg -Banco "$env:TEMP\positron-limpeza.db"
```

```text
FIA: 494 linha(s) em Fiacao (199 borne(s), 191 dispositivo(s), 83 posicao(oes)); 265 porta(s) em Portas4F; 168 borne(s) em Bornes4F; 70 contato(s) em Contatos4F; 83 dispositivo(s) em Dispositivos4F; 11 circuito(s) em Circuitos4F; 15 tipo(s) em Aplicacao4F.
VERIF: 249 problema(s) — fiação: 0; interligação: 0; modelos: 0; desenho: 249.
```

> **Por que a projeção não muda:** o valor 0 do XRecord é o `MaxIndice` e o leitor começa no
> índice 1 (`for i = 1; ...; i += 8`). Como o desenho real não tem **nenhuma** porta duplicada,
> o conjunto de portas é o mesmo: mudam só o cabeçalho (que a projeção não lê) e um campo de
> orientação que o gravador passa a maiúsculas.

Como o desenho real não exercita o **dedup** (0 duplicadas), entra a fixture
`scripts/cad-fixture-mascaras.lsp` — um modelo (900) com a porta 3 repetida (terminais `T3` e
`T3BIS`) e fora de ordem (3, 1, 3), com o cabeçalho em 0:

```powershell
$env:POSITRON_XDATA = "$env:TEMP\positron-masc-fixture.txt"
powershell -ExecutionPolicy Bypass -File scripts/cad-zwcad-smoke.ps1 -Dwg 1 -Revisao R0 `
  -Fixture scripts/cad-fixture-mascaras.lsp `
  -Comandos "corrigeDicMascaras,corrigeDicMascaras,(pz-masc:dump)" `
  -Banco "$env:TEMP\positron-masc.db"
```

```text
corrigeDicMascaras: 1 de 1 modelo(s) de máscara normalizado(s) (1 porta(s) duplicada(s) descartada(s); 3 porta(s) lida(s); 0 sem registro de portas).
corrigeDicMascaras: 0 de 1 modelo(s) de máscara normalizado(s) (0 porta(s) duplicada(s) descartada(s); 2 porta(s) lida(s); 0 sem registro de portas).
MODELO;900;3;1,3;T1,T3     <- cabeçalho 0->3, ordem 1,3 e ficou a PRIMEIRA porta 3 (terminais T3, não T3BIS)
```

**Rodada 75 — `apagarTodosOsTextosDasVeias` (frente 2 do §7.6, parte 6: a quinta limpeza).**
A quinta ação de limpeza do `Correcao.cs` e a primeira que **apaga por XData**: varre o
ModelSpace e apaga os **rótulos auxiliares das veias** — o `DBText` com `AUXINTERLIG` do tipo
1 (o mesmo tipo que o `INDCABO` reescreve, rodada 60) e **qualquer** entidade com o XData
`ELETROSUL`. A regra pura está em `LimpezaDoDesenho.ApagarRotuloAuxiliar`:

| Ramo | Condição | Do original |
|---|---|---|
| 1 | qualquer entidade com XData `ELETROSUL` (texto ou não) | ✅ `lerXDataAuxInterligacaoEletrosul` |
| 2 | `DBText` com `AUXINTERLIG` do **tipo 1** | ✅ `lerXDataAuxInterligacao(...) && tipo == 1` |

O `ehTexto` só vale no ramo 2: um `AUXINTERLIG` tipo 1 numa polyline **fica**. E o app name
do ramo 1 é `ELETROSUL`, **não** `AUXINTERLIGELETROSUL` — o nome da função do reverso
(`lerXDataAuxInterligacaoEletrosul`) engana; o layout que o
`GravarXDataAuxInterligacaoEletrosul` grava é app name, usuário, data, **handle** (+3) e o
`1071 1` (o leitor do recoder é tolerante onde o original estoura no `array[3]`).

**Medido no desenho real** (`..\Elet\Teste_projeto_real\Funcional.dwg`, DWG 63) — as 24 são os
rótulos dos cabos da interligação:

```text
apagarTodosOsTextosDasVeias: 24 rótulo(s) de veia apagado(s) (3290 entidade(s) no ModelSpace; 24 com AUXINTERLIG e 0 com ELETROSUL).
apagarTodosOsTextosDasVeias: 0 rótulo(s) de veia apagado(s) (3266 entidade(s) no ModelSpace; 0 com AUXINTERLIG e 0 com ELETROSUL).
```

A segunda passada converge na aritmética do próprio resumo: **3290 − 24 = 3266**. E o resto do
ciclo não muda (a receita roda a projeção **antes** da limpeza):

```powershell
powershell -ExecutionPolicy Bypass -File scripts/cad-zwcad-smoke.ps1 -Dwg 63 -Revisao R0 `
  -Comandos "FIA,INT,apagarTodosOsTextosDasVeias,apagarTodosOsTextosDasVeias,VERIF" `
  -Desenho ..\Elet\Teste_projeto_real\Funcional.dwg -Banco "$env:TEMP\positron-limpeza.db"
```

```text
FIA: 494 linha(s) em Fiacao (199 borne(s), 191 dispositivo(s), 83 posicao(oes)); 265 porta(s) em Portas4F; 168 borne(s) em Bornes4F; 70 contato(s) em Contatos4F; 83 dispositivo(s) em Dispositivos4F; 11 circuito(s) em Circuitos4F; 15 tipo(s) em Aplicacao4F.
INT: 20 linha(s) gravada(s) em Interligacao4 (199 borne(s)); 265 porta(s) em Portas4I; 216 borne(s) em Bornes4I; 697 cabo(s) em Cabos4; 2388 veia(s) em Veias4.
apagarTodosOsTextosDasVeias: 24 rótulo(s) de veia apagado(s) (3290 entidade(s) no ModelSpace; 24 com AUXINTERLIG e 0 com ELETROSUL).
apagarTodosOsTextosDasVeias: 0 rótulo(s) de veia apagado(s) (3266 entidade(s) no ModelSpace; 0 com AUXINTERLIG e 0 com ELETROSUL).
VERIF: 0 jumper(s) e 20 trecho(s) de interligação lido(s) do desenho.
VERIF: 249 problema(s) — fiação: 0; interligação: 0; modelos: 0; desenho: 249.   <- sem regressão
```

A conferência **independente** é o `scripts/cad-conta-auxiliares.lsp`, que lista cada entidade
com um dos dois XData e fecha com `TOTAL;…`. Como o `-Fixture` carrega antes do NETLOAD, o
comando `(pz-aux:dump)` roda **depois** da ação — a mesma contagem serve para o antes e para o
depois:

```powershell
$env:POSITRON_XDATA = "$env:TEMP\positron-aux.txt"
powershell -ExecutionPolicy Bypass -File scripts/cad-zwcad-smoke.ps1 -Dwg 63 -Revisao R0 `
  -Fixture scripts/cad-conta-auxiliares.lsp `
  -Comandos "apagarTodosOsTextosDasVeias,(pz-aux:dump)" `
  -Desenho ..\Elet\Teste_projeto_real\Funcional.dwg -Banco "$env:TEMP\positron-limpeza.db"
```

```text
AUXILIAR;TEXT;4DD26;8-CCE-001;tipo=1;          <- antes da ação: 24 linhas
AUXILIAR;TEXT;4DDC6;8-GGE-017/2;tipo=1;
TOTAL;24;AUXINTERLIG;24;ELETROSUL;0
...
TOTAL;0;AUXINTERLIG;0;ELETROSUL;0              <- depois da ação: 0
```

> **Lição de ferramenta (medida e isolada).** O primeiro recorte deste contador passava uma
> **lista fixa** de app names ao `entget` (`'("AUXINTERLIG" "ELETROSUL")`) e devolveu
> `TOTAL;0` num desenho em que o plugin apagou **24**. Uma sonda no mesmo desenho comparou
> os recortes, todos contando as entidades com XData `AUXINTERLIG`:
>
> ```text
> A_SEMFILTRO_APPID;24            (ssget "_X" sem filtro + app names da tabela APPID)
> B_FILTRO_TEXTO_APPID;24         (ssget "_X" '((0 . "TEXT")) + APPID)
> C_FILTRO_LISTA_APPID;24         (ssget "_X" '((0 . "TEXT,MTEXT,LWPOLYLINE")) + APPID)
> D_SEMFILTRO_FIXO;0              (sem filtro + lista fixa '("AUXINTERLIG" "ELETROSUL"))
> E_SEMFILTRO_APPID_TEXTO;0       (filtro TEXT + lista fixa)
> ```
>
> Ou seja: o filtro de tipo (inclusive a lista separada por vírgula) **não** era o problema —
> o `entget` com a **lista fixa** é que não devolveu o grupo `-3` dos rótulos. A lição da
> rodada 70 continua valendo e agora está isolada: a lista de app names **tem de vir da tabela
> `APPID` do desenho**.

Como o desenho real exercita só um dos ramos (24 textos tipo 1, nenhum `ELETROSUL`), entra a
fixture `scripts/cad-fixture-veias.lsp`, com os quatro casos num desenho só — texto tipo 1
(sai), texto tipo 2 (fica), `ELETROSUL` em polyline e em texto (saem), `AUXINTERLIG` tipo 1
em polyline (fica) e texto sem XData (fica):

```powershell
$env:POSITRON_XDATA = "$env:TEMP\positron-veias.txt"
powershell -ExecutionPolicy Bypass -File scripts/cad-zwcad-smoke.ps1 -Dwg 1 -Revisao R0 `
  -Fixture scripts/cad-fixture-veias.lsp `
  -Comandos "apagarTodosOsTextosDasVeias,apagarTodosOsTextosDasVeias,(pz-veias:dump)" `
  -Banco "$env:TEMP\positron-veias.db"
```

```text
apagarTodosOsTextosDasVeias: 3 rótulo(s) de veia apagado(s) (6 entidade(s) no ModelSpace; 3 com AUXINTERLIG e 2 com ELETROSUL).
apagarTodosOsTextosDasVeias: 0 rótulo(s) de veia apagado(s) (3 entidade(s) no ModelSpace; 2 com AUXINTERLIG e 0 com ELETROSUL).
ENTIDADE;TEXT;PONTA-2;tipo=2;      <- o tipo 2 fica
ENTIDADE;LWPOLYLINE;;tipo=1;       <- o tipo 1 fora de texto fica
ENTIDADE;TEXT;SEM-XDATA;;          <- sem XData nenhum fica
```

**Rodada 74 — `SobeLm` (comando próprio: fecha o `BorneSemLm`).** O `lm` que o
`VERIF` aponta como zerado (`BorneSemLm`, **119** no desenho real) não tinha conserto no
recoder — e o reverso também não tem botão para isso: o original só resolve o `lm` **na
gravação** do borne (`GravarXDataDispBorne` → `DicionarioBorne.BuscaLMdaRegua`), e o campo que
ele lê (+6/+7 do `REGUAS/MODELOS2`) é **zerado pelo próprio gravador**
(`GravaOsModelosDeRegua` escreve `0` em +4..+8). O recoder resolve o `lm` por **duas
fontes**, nesta ordem:

| Fonte | O que é | Do original? |
|---|---|---|
| `REGUAS/MODELOS2` (+6 = tipo 0, +7 = tipo 1) | o campo que o `BuscaLMdaRegua` lê | ✅ o original |
| dicionário de bornes da régua (`CENG_BORNES`, o `lm` do primeiro borne de reserva **do tipo**) | onde o dado existe de verdade | ⚠️ **desvio do recoder**, com medição |

A regra é pura (`Positron.Data/Bornes/LmDasReguas.cs`) e só entra o borne **zerado** e
**com** definição (`CorrecaoLmBornes.Planejar`); quem a régua não define fica como está — é
**dado faltando no desenho**, não regra. O adapter
(`Positron.Plugin/Correcoes/LmDosBornesDoDesenho.cs`) faz as duas transações do
`GravarXDataDispBorne` e lê o dicionário **uma vez por régua**; o que era copiado em três
adapters (`EspacoDeModelo`, `LerXData`, `ParaResultBuffer`, `GarantirAppName`,
`AbrirPorHandle`) virou o `Positron.Plugin/Bornes/BornesDaCorrecao.cs`, adotado também
pelas rodadas 71/72.

**Medido no desenho real** (`..\Elet\Teste_projeto_real\Funcional.dwg`, DWG 63) — o zero é o
**dado**: nenhuma das duas fontes define o `lm` dos 119, então a subida é 0 e o `VERIF` não
muda:

```text
FIA: 494 linha(s) em Fiacao (199 borne(s), 191 dispositivo(s), 83 posicao(oes)); 265 porta(s) em Portas4F;
     168 borne(s) em Bornes4F; 70 contato(s) em Contatos4F; 83 dispositivo(s) em Dispositivos4F;
     11 circuito(s) em Circuitos4F; 15 tipo(s) em Aplicacao4F.
SobeLm: 0 de 199 borne(s) ganharam o lm da régua (119 com lm zerado; 119 sem definição para o tipo na régua).
SobeLm: 0 de 199 borne(s) ganharam o lm da régua (119 com lm zerado; 119 sem definição para o tipo na régua).
VERIF: 249 problema(s) — fiação: 0; interligação: 0; modelos: 0; desenho: 249.
VERIF: por tipo — BorneSemLm: 119; BorneSemFiacao: 107; IntervaloBorneInvalido: 11; ReguaVazia: 10; SobreposicaoAusente: 2.
```

A conferência **independente** é o dump cru dos bornes (`POSITRON_XDATA_BORNES=1`), que passou
a trazer o `lm` (o campo que o `VERIF` olha) e o `tipo` **no fim** da linha `BORNE` —
quem lia os campos anteriores continua lendo:

```powershell
$env:POSITRON_XDATA = "$env:TEMP\positron-xdata.txt"
$env:POSITRON_XDATA_BORNES = "1"
powershell -ExecutionPolicy Bypass -File scripts/cad-zwcad-smoke.ps1 -Dwg 63 -Revisao R0 -Comandos ELET `
  -Fixture scripts/cad-dump-xdata.lsp -Desenho ..\Elet\Teste_projeto_real\Funcional.dwg -Banco "$env:TEMP\positron-limpeza.db"
```

```text
BORNE;4E8B;B;1;;1.0;39;15;0;496;0      <- lm = 496 (já tinha)
BORNE;1425A;B;412;;7.0;37;20;1;0;0     <- lm = 0: é um dos 119
199 bornes: 119 com lm = 0, 73 com 476 e 7 com 496 — a mesma população de 119 do BorneSemLm
```

Receita do comando no desenho real (o `FIA` antes do `SobeLm` é o controle de regressão —
seguem os mesmos 494/265/168/70/83/11/15 das rodadas anteriores):

```powershell
powershell -ExecutionPolicy Bypass -File scripts/cad-zwcad-smoke.ps1 -Dwg 63 -Revisao R0 `
  -Comandos "FIA,SobeLm,SobeLm,VERIF" `
  -Desenho ..\Elet\Teste_projeto_real\Funcional.dwg -Banco "$env:TEMP\positron-limpeza.db"
```

Como o desenho real **não exercita a escrita** (não há o que subir), entra a fixture
sintética `scripts/cad-fixture-lm.lsp` com as **duas fontes** — a régua 39 define `496` no
`MODELOS2` e a régua 44 tem um borne de reserva com `497` no `CENG_BORNES`, mais um borne que
já tinha `lm` (10) e **não** pode entrar:

```powershell
$env:POSITRON_XDATA = "$env:TEMP\positron-lm.txt"
powershell -ExecutionPolicy Bypass -File scripts/cad-zwcad-smoke.ps1 -Dwg 1 -Revisao R0 `
  -Fixture scripts/cad-fixture-lm.lsp -Comandos "SobeLm,SobeLm,(pz-lm:dump)" `
  -Banco "$env:TEMP\positron-lm.db"
```

```text
SobeLm: 3 de 4 borne(s) ganharam o lm da régua (3 com lm zerado; 0 sem definição para o tipo na régua).
SobeLm: os 4 borne(s) do desenho já têm lm.          <- 2a passada: converge
BORNE;247;496;0;39     <- caminho do REGUAS/MODELOS2
BORNE;248;497;0;44     <- caminho do CENG_BORNES
BORNE;249;497;0;44
BORNE;24A;10;0;39      <- já tinha lm: não entrou
```

> **Nota de ferramenta:** a fixture é **auto-contida** (monta os dois dicionários, os bornes e
> o próprio dump) porque o harness aceita **um** `-Fixture`; o `(pz-lm:dump)` roda como
> comando, **depois** do `SobeLm`, e é o que confere fora do plugin os valores gravados.

**Rodada 73 — `CorrigeStyle` (frente 2 do §7.6, parte 4: os estilos de texto).** O
`corrigeStyles` do `Correcao.cs` mexe na **`TextStyleTable`** do desenho (não lê banco nem
cadastro). O que é puro está em `Positron.Data/Correcoes/CorrecaoEstiloTexto.cs`:

| Peça | Do original | No recoder |
|---|---|---|
| problema | `FileName == ""` **ou** `XScale == 0` | `CorrecaoEstiloTexto.PrecisaCorrigir` |
| referência | primeiro estilo com `FileName == "arial.ttf"`; sem ele, o **último** da tabela | `IndiceDaReferencia` (o quirk fica no `TemReferenciaArial`) |
| correção | estilo **sem fonte**: copia `Font`, `XScale` (`ref` ou `1`) e `TextSize`; **independente**, se a **referência** tem escala 0, põe `1` na escala de todo estilo que não esteja em `1` | `Planejar` |
| referência viva | o laço corrige a referência **ao passar por ela**, e os estilos seguintes já leem a escala nova | `Planejar` percorre na ordem e atualiza a escala da referência |

**Achado (com medição):** o original só copia o **descritor** `Font`
(`val4.Font = val5.Font`) e **não** regrava o `FileName`. No ZWCAD isso não persiste o
arquivo da fonte: o estilo continua lido como "sem fonte" e o comando nunca converge.
Medido numa fixture (o `Font` é copiado, mas o grupo 3 do DXF — o `FileName` — fica
vazio): o recoder grava o `FileName` da referência **junto** com a fonte, que é o que faz
o defeito sair. Sem isso a segunda passada reportaria o mesmo problema para sempre.

**Medido no desenho real** (`..\Elet\Teste_projeto_real\Funcional.dwg`, DWG 63): os **5**
estilos de texto estão todos com fonte e escala 1, então não há nada a corrigir (o zero é o
dado, não um no-op) — duas passadas iguais:

```text
CorrigeStyle: os 5 estilo(s) de texto do desenho estão sem problema de fonte.
CorrigeStyle: os 5 estilo(s) de texto do desenho estão sem problema de fonte.
```

A conferência **independente** é a seção `ESTILO` nova do `cad-dump-xdata.lsp` (uma linha
por estilo: nome, `FileName`, `XScale` do grupo 41 e `TextSize` do grupo 40), que sempre sai:

```text
ESTILO;Standard;arial.ttf;1.0;0.0
ESTILO;Romans;romans.shx;1.0;0.0
ESTILO;TÍTULO;bgothm.ttf;1.0;0.0
ESTILO;swis721ltexbt;swissel.ttf;1.0;0.0
ESTILO;Annotative;txt.shx;1.0;0.0
```

Como o desenho real não exercita a **escrita**, entra a fixture sintética
`scripts/cad-fixture-estilos.lsp` (um estilo `PZSEMFONTE` com o `FileName` vazio, escala
2.0 e altura 1.5 — o `CorrigeStyle` copia fonte/escala/altura da `Standard` e regrava o
arquivo):

```powershell
$env:POSITRON_XDATA = "$env:TEMP\positron-estilos.txt"
powershell -ExecutionPolicy Bypass -File scripts/cad-zwcad-smoke.ps1 -Dwg 1 -Revisao R0 `
  -Fixture scripts/cad-fixture-estilos.lsp -Comandos "CorrigeStyle,CorrigeStyle,(pz-estilos:dump)" `
  -Banco "$env:TEMP\positron-estilos.db"
```

```text
CorrigeStyle: 1 de 3 estilo(s) de texto corrigido(s) (referência: Standard; problemas: PZSEMFONTE).
CorrigeStyle: os 3 estilo(s) de texto do desenho estão sem problema de fonte.   <- 2a passada: converge
ESTILO;PZSEMFONTE;arial.ttf;1.0;0.0                                            <- o FileName foi regravado
```

> **O caso `XScale == 0` não dá para montar por `entmake`:** o ZWCAD normaliza o fator de
> largura 0 para 1 (a fixture chega a criar o estilo e o dump mostra `1.0`), então esse
> ramo fica coberto só pela regra pura (`CorrecaoEstiloTextoTests`).
>
> A referência é escolhida pela **ordem da tabela** (o primeiro `arial.ttf`, ou o último
> estilo): a fixture se apoia na `Standard` do desenho novo, que já é `arial.ttf`.

**Rodada 72 — `CorrigeBornes` e `CorrigeDisp` (frente 2 do §7.6, parte 3).** As duas
correções de **um campo** do `Correcao.cs` — as duas só olham o desenho:

| Comando | O que faz (do original) | Puro (testado) |
|---|---|---|
| `CorrigeBornes` | o borne com `Visivel == -1` volta para `0`, com o XData regravado pelo mesmo `GravarXDataDispBorne` (que resolve o `lm`) | `CorrecaoVisibilidadeBorne.PrecisaCorrigir` |
| `CorrigeDisp` | renomeia o app name **legado** `DISPOSITIVO` para `Dispositivo` na tabela `APPID` | `CorrecaoAppNameDispositivo` (os dois nomes + a checagem contra os leitores) |

No desenho real **nenhum dos dois tem o que corrigir** (o zero é o dado, não um no-op):

```text
CorrigeDisp: o desenho não tem o app name legado DISPOSITIVO.
CorrigeBornes: 0 de 199 borne(s) com a visibilidade corrigida.
```

O dump cru confirma os dois: os **199** bornes só têm `Visivel` `0` (51) ou `1` (148) — o campo
foi **acrescentado no fim** da linha `BORNE` justamente para isso, sem quebrar quem lia os
campos anteriores — e a tabela `APPID` do desenho tem só `Dispositivo` (a seção `APPID` do
`cad-dump-xdata.lsp` mostra os dois nomes quando existem).

Como o desenho real não exercita **escrita** nenhuma, os dois caminhos são provados numa
**fixture sintética** (`scripts/cad-fixture-correcoes.lsp`: bloco `B` com `Visivel = -1` e
`lm = 0`, o app name legado e um `REGUAS/MODELOS2` com o `lm` da régua):

```powershell
powershell -ExecutionPolicy Bypass -File scripts/cad-zwcad-smoke.ps1 -Dwg 1 -Revisao R0 `
  -Comandos "CorrigeDisp,CorrigeBornes,CorrigeDisp,CorrigeBornes" `
  -Fixture scripts/cad-fixture-correcoes.lsp -Banco "$env:TEMP\positron-correcoes.db"
```

```text
CorrigeDisp: app name DISPOSITIVO renomeado para Dispositivo.
CorrigeBornes: 1 de 1 borne(s) com a visibilidade corrigida (1 com o lm do dicionário de réguas).
CorrigeDisp: o desenho não tem o app name legado DISPOSITIVO.      <- 2a passada: converge
CorrigeBornes: 0 de 1 borne(s) com a visibilidade corrigida.       <- 2a passada: converge
```

> **Achado (e bug pego pela medição):** a busca de app name do CAD **não diferencia caixa** —
> `Has("DISPOSITIVO")` acha a entrada `Dispositivo`. O primeiro recorte do `CorrigeDisp` usava
> esse `Has` e por isso dizia *"o app name legado existe, mas não deu para renomear"* **em todo
> desenho**, inclusive no real (onde não há legado nenhum). A correção é **enumerar a tabela
> `APPID` e comparar a caixa gravada** (`string.Equals(..., Ordinal)`), e reconferir o efeito
> numa transação nova — só assim "renomeou" quer dizer que o CAD aceitou.
>
> A busca por caixa também explica por que os leitores do recoder aceitarem os dois nomes já
> basta: o dado gravado sob `DISPOSITIVO` é achado pedindo `Dispositivo`.

**Rodada 71 — `corrigeOrdemBornes` (frente 2 do §7.6, parte 2: a primeira `Corrige*`).**
Renumera a `Ordem` dos bornes por régua (1..N), **pulando as ordens dos bornes de reserva**
(`CENG_BORNES`) — o botão de correção do `Correcao.cs`. O que é puro está em
`Positron.Data/Correcoes/CorrecaoOrdemBornes.cs`:

| Peça | Do original | No recoder |
|---|---|---|
| ordenação | bolha por `IndiceRegua` e, na mesma régua, por `Ordem` | igual, com as **duas comparações independentes** (a segunda é avaliada depois de um eventual primeiro swap — não é uma comparação composta) |
| renumeração | `1..N` por régua, com `k` avançando enquanto a ordem está reservada | igual |
| ordens reservadas | `LeOrdemDicBornesReserva` — ordem (+3) de **todo** registro de `CENG_BORNES` da régua, **sem** o filtro de `tipo` | `BornesReserva.OrdensReservadas` |
| gravação | `GravarXDataDispBorne`: relê o borne e só grava se a ordem difere; resolve o `lm` no dicionário de réguas quando está zerado | `BorneXData.ParaValores` (18 valores) + `ReguasModelo.BuscarLm` (campos +6/+7 por tipo) |

Receita (`-Comandos` aceita o nome do comando como no original):

```powershell
powershell -ExecutionPolicy Bypass -File scripts/cad-zwcad-smoke.ps1 -Dwg 63 -Revisao R0 `
  -Comandos "VERIF,corrigeOrdemBornes,corrigeOrdemBornes,VERIF" `
  -Desenho ..\Elet\Teste_projeto_real\Funcional.dwg -Banco "$env:TEMP\positron-limpeza.db"
```

Medido em 2026-09-23 (ZWCAD 2026, `Funcional.dwg`, DWG 63):

```text
VERIF: por tipo — BorneSemLm: 119; BorneSemFiacao: 107; IntervaloBorneInvalido: 11; ReguaVazia: 10; SobreposicaoAusente: 2.
corrigeOrdemBornes: 32 de 199 borne(s) renumerado(s).
corrigeOrdemBornes: 0 de 199 borne(s) renumerado(s).          <- 2a passada: converge
VERIF: por tipo — BorneSemLm: 119; BorneSemFiacao: 107; IntervaloBorneInvalido: 11; ReguaVazia: 10; SobreposicaoAusente: 2.
```

Duas leituras do resultado, para não confundir regra com dado:

- **As 11 lacunas continuam lá** porque a regra `IntervaloBorneInvalido` olha o **número**
  do borne (`Terminal` = `Numero` + `NumeroComplem`), não a `Ordem`: a correção normaliza a
  ordem (32 bornes nas réguas 476/477/480/481/483/487/489), e as lacunas de numeração são
  **dado** do desenho.
- **O `lm` não mudou nada aqui**: o dicionário de réguas desta cópia tem `+6`/`+7` zerados
  (conferido no dump: 31 réguas, todas com `+4..+9` vazios), então a resolução do
  `GravarXDataDispBorne` é no-op — a pendência do §7.2 (subir o `lm`) segue aberta.

**Conferência independente** — o `cad-dump-xdata.lsp` ganhou a seção `RESERVA` (uma entrada
por régua do `CENG_BORNES`) e, com `POSITRON_XDATA_BORNES=1`, dumou os 199 bornes:

```powershell
$env:POSITRON_XDATA = "$env:TEMP\positron-xdata.txt"
$env:POSITRON_XDATA_BORNES = "1"
powershell -ExecutionPolicy Bypass -File scripts/cad-zwcad-smoke.ps1 -Dwg 63 -Revisao R0 -Comandos ELET `
  -Fixture scripts/cad-dump-xdata.lsp -Desenho ..\Elet\Teste_projeto_real\Funcional.dwg -Banco "$env:TEMP\positron-limpeza.db"
```

A reconstrução em Python (fora do plugin) refaz a ordenação e a renumeração sobre o dump cru
e prevê **32 ajustes** — os mesmos do plugin, com os handles e as ordens novas. As **19
réguas** com reserva entram na conta (o plano lê as mesmas ordens do dicionário), mas a
interseção com as réguas que mudam é **vazia** neste desenho: o ramo do pulo é exercitado no
código, não altera o resultado aqui.

> **Teste flaky corrigido no caminho:** o `RelatorioCompilacao` carimbava a data dentro de
> `Texto()`, então duas leituras do mesmo relatório podiam cair em segundos diferentes e o
> teste do arquivo falhava de vez em quando (observado nesta rodada). O carimbo passou para a
> **criação** do relatório.

**Rodada 70 — limpeza do CAD no plugin (frente 2 do §7.6, parte 1).** As quatro ações de
limpeza do `Correcao.cs` que **só olham o desenho** (nenhuma lê banco nem cadastro) — é a
abertura da frente que fecha o laço *detecta → corrige* do `VERIF`:

| Comando | O que faz (do original) | Puro (testado) |
|---|---|---|
| `ApagarTextosEmBranco` | apaga do ModelSpace os `DBText` cujo texto é só espaços **e** que **não** têm XData | `LimpezaDoDesenho.TextoEmBranco(texto, temXData)` |
| `apagaXDataTerceiros` | nas entidades com o app name de terceiro `AEC_XDATA_BOUND_SPACE`, troca o XData pelo registro único de marca (o original faz isso: o conteúdo de terceiro some) | `LimpezaDoDesenho.XDataDeTerceirosSubstituido()` + `LimpezaDoDesenho.XDataTerceiros` |
| `ApagaLayouts` | apaga o dicionário **`CENG_LAYOUT`** (posição do equipamento no layout — o `PosicaoNum` do `FIA` e a `OrdemLay` do `COMPLM`) | `LimpezaDoDesenho.DicionarioLayout` |
| `ApagaPlaquetas` | apaga o dicionário **`CENG_PLAQUETA`** (o insumo do `EPLQ`) | `LimpezaDoDesenho.DicionarioPlaquetas` |

Receita (a mesma do ciclo, com o banco já projetado e o cadastro importado):

```powershell
powershell -ExecutionPolicy Bypass -File scripts/cad-zwcad-smoke.ps1 -Dwg 63 -Revisao R0 `
  -Comandos "ApagarTextosEmBranco,apagaXDataTerceiros" `
  -Desenho ..\Elet\Teste_projeto_real\Funcional.dwg -Banco "$env:TEMP\positron-limpeza.db"
```

Medido em 2026-09-23 (ZWCAD 2026, `Funcional.dwg`, DWG 63):

```text
ApagarTextosEmBranco: 14 texto(s) apagado(s) (616 DBText lido(s) no ModelSpace).
apagaXDataTerceiros: 0 entidade(s) com XData de terceiros limpo(s) (3276 entidade(s) no ModelSpace).
ApagarTextosEmBranco: 0 texto(s) apagado(s) (602 DBText lido(s) no ModelSpace).   <- 2a passada
```

A **segunda passada** é a prova interna: o total lido cai de 616 para 602, exatamente os 14
apagados. `ApagaLayouts`/`ApagaPlaquetas` se conferem **pelo efeito** — rode `COMPLM`/`EPLQ`
antes, apague e rode de novo: o `COMPLM` passa a dizer `sem layout CENG_LAYOUT` (antes: **83**
posição(ões)) e o `EPLQ` passa a `nenhum painel com plaquetas no dicionário CENG_PLAQUETA`
(antes: **87** plaquetas, 8 painéis).

**Conferência independente** (o cru manda — o mesmo método dos outros dumps):

```powershell
$env:POSITRON_TEXTOS = "$env:TEMP\positron-textos.txt"
powershell -ExecutionPolicy Bypass -File scripts/cad-zwcad-smoke.ps1 -Dwg 63 -Revisao R0 -Comandos ELET `
  -Fixture scripts/cad-conta-textos.lsp `
  -Desenho ..\Elet\Teste_projeto_real\Funcional.dwg -Banco "$env:TEMP\positron-limpeza.db"
```

O `-Fixture` carrega antes do `NETLOAD`, então o desenho está intacto. A reconstrução em
Python do arquivo dá: **616** lidos (= **612** `TEXT` + **4** `ATTDEF` — o
`AttributeDefinition` deriva de `DBText`, e é o cast que o original faz), **45** em branco e
**14 apagáveis** (em branco **e sem XData**), com os handles. Os **31** que sobram **não** são
no-op: têm XData de outro app name (`AUXCONEXAO` 23, `DiagLog` 4, `Construtor` 4). O
`TERCEIROS;0` fecha o zero do `apagaXDataTerceiros`.

> **Lição de ferramenta:** a lista de app names do `entget` **tem de vir do desenho** (`tblnext
> "APPID"`), não de uma lista fixa. Com lista fixa o dump acusou **41** apagáveis contra os
> **14** do plugin — os outros 27 tinham XData de um app name fora da lista e apareciam como
> "sem XData", que é justamente a condição de apagar.

**Rodada 68 — relatório de Fiação no app (modo *Dispositivos*).** É o quarto tabular, e o
único que **não** é árvore: a tela `frmRelatorio_Fiacao` monta um **grafo**
`terminal → potencial → outras pontas` com o `CarregaLigacoesTerminal` (~760 linhas no
reverso). O módulo é `sidecar/relatorios/fiacao.py` e porta o **modo padrão** da tela
(`rbDispositivos` + `rbTodos`, com `cbAlternativo`/`cbLayout` desligados):

| Peça | Do original | No recoder |
|---|---|---|
| dispositivos | `CarregaDispTipoIndexModelo`: `Fiacao` por painel com `BJumper=0`, dedup pela chave `Tag`+`-A`/`-E`/`-B`; o tipo do relatório colapsa `P` e `A` em `"A"` | igual (o `rbDispositivos` exclui os de tipo `B`) |
| terminais | `CarregaTerminaisDispositivo` (sem modelo, da `Fiacao`, dedup) / `CarregaTerminaisContato` (`Contatos4F`, sem dedup) / `CarregaTerminaisMascara` (`Portas4F`, `Terminal` = `Borne` quando há `Regua`) | igual |
| ligações | `CarregaLigacoesTerminal`: por linha da `Fiacao` do terminal, os vizinhos `Ordem∓1` do mesmo `Potencial`; a `Seção`/`Cor` é a da linha do terminal e a `Página` é a da **última** | igual (no tipo `A`/`E` o `bLink` do original é sempre falso, então o `mLink` não entra) |
| linhas | laço `R9dpbbD9Jbg`, por nº de ligações: 1 linha (1), **uma só** (2), duas (3 = 2+1 e 4 = 2+2) e `>4` = `Erro: Conexões>4` | igual (colunas de `formataDGFiacao`, ids 776/777/778/779/780/781/782/783 no `Mensagens`) |

Receita (a mesma dos outros relatórios — o banco do passo 5b do `cad-projeto-e2e.ps1`):

```powershell
& services\sidecar\.venv\Scripts\python.exe scripts\app-relatorios.py "$env:TEMP\positron-projeto.db" `
  --painel 503 --revisao R0
```

Medido em 2026-09-23 (DWG 63, painel 503, revisão `R0`):

```text
== fiacao == Relatórios de Fiação (918 linha(s))
   Terminal |  | Dispositivo 1 | Terminal 1 | Dispositivo 2 | Terminal 2 | Seção | Cor | Página
   27TTX1 | - | - | - | - | - | - | - | -
   11 | - | 27TX1 | 14 | d27X1T | 14 | 1,5 | PT | 15
   12 | - | d27X1T | A1 | - | - | 1,5 | PT | 15
   ... mais 916 linha(s)
```

**A conta foi refeita por SQL independente** (sem passar pelo módulo): **82**
dispositivos + **754** terminais + **82** linhas em branco = **918**, com **0 divergência**
linha a linha. O **histograma** de ligações por terminal no painel real é **209** sem
ligação, **393** com uma e **152** com duas — nenhum com 3 ou mais, então os ramos de
**3/4/>4** ficam travados por um **banco de teste** próprio (`test_db.py`), não pelo desenho.

O que **não** entrou (registrado no §7.3): os modos `Réguas de Bornes` (`rbReguas`) e
`Terminais usados` (`rbUsados`), o alternativo (`cbAlternativo`), a ordem de layout
(`cbLayout`), os caracteres de ligação `║╗╝` (o `mLink`, só calculado no modo de régua) e as
exportações DWG/Excel.

**Rodada 67 — relatório de Interligação no app (o modo texto).** É o terceiro tabular, e o
único dos dois "intricados" que dava para fechar: o de Fiação é um **grafo** (terminal →
potencial → outras pontas) e ficou para a próxima. O de Interligação é uma **árvore**
`régua → bornes → cabos`, montada em `sidecar/relatorios/interligacao.py` a partir do
`cDadosAccessInterligacao2`:

| Peça | Do original | No recoder |
|---|---|---|
| réguas de borne | `CarregaReguas`: `SELECT DISTINCT Regua, DWG FROM Bornes4I WHERE Revisao=? AND Painel=? AND Tipo<2` com `Tag = Regua`, `NRegua = ""`, `Tipo = "B"` | igual |
| réguas de **porta** | `CarregaReguasPortas`: pontas da `Interligacao4` com `NRegua<>''` e `TipoBorne` `-1`/`-2` (`Tag = Tag1`, `NRegua = NRegua1`, `Tipo = "E"`) | igual |
| bornes | `CarregaBornesReguas` no modo **cadastro**: `Bornes4I` por régua, dedup, `Array.Reverse` | igual (o modo "desenho" não entrou) |
| cabos do borne | `CarregaCabosNosBornesRI`: ponta 1 = `(Painel1, Tag1, NRegua1, Terminal1)`; destino = ponta 2 | igual |
| linhas | laço `rbTexto`: `Tag`, `Formação`, `Anilha`, `Destino`, `Régua`/`Borne` destino, `Função`, `Documento`, `Trajeto` | igual (as regras estão no docstring do módulo) |

Receita (a mesma dos outros relatórios):

```powershell
& services\sidecar\.venv\Scripts\python.exe scripts\app-relatorios.py "$env:TEMP\positron-projeto.db" `
  --painel 503 --revisao R0
```

Medido em 2026-09-22 (DWG 63, painel 503, revisão `R0`):

```text
== interligacao == Relatório de Interligação (27 linha(s))
   Régua |  | Tag | Formação | Anilha | Destino | Régua | Borne | Função | Documento |  | Trajeto
   R9 | - | - | - | - | - | - | - | - | - | - | -
   ...
   ENTR 1 | - | - | - | - | - | - | - | - | - | - | -
    A  | - | 8-CCE-001 | 1x300 | ENTR 1- A  | 400G1 | SAÍDA |  A  | - | LOCAL-A/8 | 0 | -
   ...
   R6 | - | - | - | - | - | - | - | - | - | - | -
   22 | - | 8-GGE-017-1 | (2x2,5) | R6-22 | 400G1 | NOTA 3 | XX  | - | LOCAL-A/19 | 0 | -
   ... mais 19 linha(s)
```

**A conta foi refeita por SQL independente**, régua a régua e borne a borne, no mesmo
banco: **8** réguas (`Bornes4I` do painel 503 com `Tipo<2`) + **19** cabos (a consulta da
ponta 1, pulando `$REP$`) = **27** — igual ao relatório. As linhas também batem com o
`Interligacao4`/`Cabos4`/`Paineis` crus: o `8-CCE-001` não tem `Nome_Veia` e a formação
começa com `1x` → a `Tag` sai o próprio `Tag_Cabo`; o `8-GGE-017-1` cai no caminho
`Tag-Num_Veia`; a `Anilha` é `RÉGUA-BORNE`; o `Destino` é o nome do painel do cadastro
(`400G1`/`400G2`).

**Achado que vale para qualquer relatório novo: o original roda em Jet/Access, e o Jet
não distingue string vazia de `NULL`.** O `WHERE ... AND NRegua1 = @nRegua` dele casa
`''` **e** `NULL`; no SQLite a coluna vazia é `NULL` (o `ProjectStore` grava `DBNull`) e
`NULL = ''` é falso — a primeira versão do relatório saiu com **0 cabo** por isso. As
comparações com `''` levam `IFNULL(coluna, '')` no módulo, com o motivo comentado. A
mesma armadilha vale para `<> ''`.

O que **não** entrou (registrado no §7.3): o modo **gráfico** (`rbGrafico`, que desenha a
árvore de jumpers com `bEntra`/`bSai`) e a seção de **veias de reserva** (`cbReserva`); o
modo **texto** é o que lista os cabos por borne.

**Rodada 66 — `NRegua1`/`NRegua2` da `Interligacao4`: o bug que o relatório de
interligação denunciou.** O levantamento dos relatórios de Fiação/Interligação (§7.3 do
`PLANO.md`) mostrou que o relatório de interligação identifica a **ponta de régua** assim
(`cDadosAccessInterligacao2.CarregaCabosNosBornesRI`):

```sql
SELECT ... FROM Interligacao4
WHERE Revisao=@revisao AND Painel1=@painel AND Tag1=@tag AND NRegua1=@nRegua AND Terminal1=@terminal
```

…com `Tag = <nome da régua>` e **`NRegua = ''`** (é o que o `CarregaReguas` monta para as
réguas de borne: `Tag = Regua`, `NRegua = ""`). A nossa projeção preenchia
`NRegua1`/`NRegua2` com o nome da régua — ou seja, a consulta do relatório original
**não acharia nenhum cabo** no nosso banco.

A medição no produto (a mesma forma da rodada 43, que corrigiu isso na `Fiacao`):

```text
Interligacao4 no produto (todas as revisões/desenhos):
   total de linhas      : 5042
   NRegua1 preenchido   : 0
   NRegua2 preenchido   : 0
   TipoBorne1 <> 0      : 55      (as pontas de porta também têm NRegua vazio)
Fiacao no produto:
   total de linhas      : 38221
   NRegua preenchido    : 14      (o número que a rodada 43 mediu)
```

**A coluna nunca é preenchida** — a regra é mais forte que na `Fiacao` (onde 14 linhas
têm). A correção foi a de `PontoFiacao.AplicarBorne` aplicada a
`PontoInterligacao.AplicarBornePonta1/Ponta2` (`NRegua1/2 = ""`, com a medição no
comentário), e o teste do projetor passou a travar isso.

**Por que sobreviveu desde a rodada 39:** a `Interligacao4` **não estava** no
`cad-ab-tabelas` — a ferramenta comparava só as 7 tabelas do `FIA`, e a conferência da
interligação era por *hash* de conteúdo, não coluna a coluna. A tabela entrou na
ferramenta (`COLUNAS`/`CHAVE` com as 22 colunas das duas pontas, chave
`Tag_Cabo`+`Num_Veia`), e a receita é a mesma dos outros A/B — só a **revisão** é
diferente do lado do produto (a interligação usa `00A-n`/`CORR`, a fiação `1..4`):

```powershell
# lado do produto, na revisão DELE
powershell -ExecutionPolicy Bypass -File scripts/cad-ab-tabelas.ps1 `
  -Mdb "..\Elet\Teste_projeto_real\RCD.mdb" -Tabelas Interligacao4 -Revisao 00A-1 -SaidaDir "$TEMP\ab-il4"

# lado do recoder (a nossa revisão do ciclo é R0)
python scripts/cad-ab-tabelas.py "$TEMP\positron-projeto.db" "$TEMP\ab-il4\mdb-<data>" `
  --nosso-dwg 63 --nosso-revisao R0 --detalhe
```

Medido em 2026-09-22, **depois** da correção:

```text
Interligacao4          20       20        0  IDENTICO (b4919622ef820429)

== detalhe por coluna (linhas casadas pela chave da tabela) ==
  Interligacao4: 20 x 20 linhas, 20 chave(s) em comum
    so no recoder: 0 | so no produto: 0
    colunas iguais nas chaves em comum
```

São 22 colunas conferidas por linha (as duas pontas: `Painel`, `Tag`, `Alternativo`,
`NRegua`, `Terminal`, `TerminalNum`, `TipoBorne`, `Handle`, `Pagina`, `IndexModelo`), o que
é mais forte que o *hash* anterior. `Documento1`/`Documento2` ficam de fora da lista de
propósito: eles saem do `Conf.Local` do ambiente (`POSITRON_LOCAL`), não do desenho.

**Rodada 65 — relatórios tabulares no app (`Lista de Veias` e `Lista de Materiais`).** O
original tinha **38 telas** `frmRelatorio_*`, todas WinForms com grade e exportação para
Excel/DWG. O caminho escolhido (decisão 9b do `PLANO.md`) é renderizar no **app Python**:
o conteúdo vem do banco, que o plugin projeta e que já está conferido contra o produto.

O motor vive em `services/sidecar/src/sidecar/relatorios/` — cada relatório é um módulo que
declara as **colunas** (com o texto do resource `Mensagens` do original, extraído do
`Eletron4.Resources.resx` descompilado) e monta as linhas com SQL leitor. Os textos usados
ficam citados por **id** no módulo, então a conferência não depende de adivinhação:

| Relatório | Título | Colunas (ids do `Mensagens`) | Consulta do reverso |
|---|---|---|---|
| `veias` | `Lista de Veias` (895) | Tag 176, Formação 1285, Função 1430, Veias 1239, Painel 1081, Dispositivos 518, Borne 1429, Aterrar 1243 (×2), Documento Funcional 253, Página 9, Comprimento 1246 | `CDadosAccessInterligacao.CarregaVeias4` + `CarregaUmaVeias4Copel` + `CarregaDadosInterlig4` |
| `materiais` | `Lista de Materiais` (656) | Índice 915, Quant 1218, Tag 176, Descrição 64, Modelo 654, Fabricante 1169, Código do Cliente 1163, INDEXLM | `cDadosLM.CarregaDadosDispositivosMultiplosPN` (o caso de um painel) |

Receita (o mesmo caminho da UI — handlers do sidecar, sem ZMQ e sem CAD):

```powershell
# o banco do ciclo completo, com o catalogo e o cadastro importados
npm run cad:projeto -- -Desenho "..\Elet\Teste_projeto_real\Funcional.dwg" `
  -Mdb "..\Elet\Teste_projeto_real\RCD.mdb" -Banco "$env:TEMP\positron-rel.db"

& services\sidecar\.venv\Scripts\python.exe scripts\app-relatorios.py "$env:TEMP\positron-rel.db" `
  --painel 503 --revisao R0
```

Medido em 2026-09-22 (DWG 63, painel 503, revisão `R0`):

```text
relatorios: veias, materiais

== veias == Lista de Veias (22 linha(s))
   Tag | Formação | Função | Veias | Painel | Dispositivos | Borne | Aterrar | Painel | ...
   8-CCE-001 | 1x300 | - | 1 | PNL-GGE | ENTR 1 | A | - | 400G1 | SAÍDA | A | - | LOCAL-A | 8 | 0.0
   ... mais 18 linha(s)

== materiais == Lista de Materiais (86 linha(s))
   Índice | Quant | Tag | Descrição | Modelo | Fabricante | Código do Cliente | INDEXLM
   1 | 1 | TP1-X1 | TRANSFORMADOR DE POTENCIAL BT; ... | KP101 | KRON | - | 0
   ... mais 82 linha(s)
```

**As duas contagens foram conferidas por SQL independente** (sem passar pelo relatório), no
mesmo banco:

| Conta | SQL | Relatório |
|---|---|---|
| `ListaMateriais` do painel 503 | 91 | — |
| com `IndiceMaterial <> 0` **e** no catálogo (`INNER JOIN Materiais`) | **86** | **86** ✔ |
| veias dos cabos do painel 503 (`Num_Veia > -51`) | 122 | — |
| dessas, com trecho próprio no `Interligacao4` | **20** | — |
| veias de reserva (índice ≤ 0) que caem no trecho da **seguinte** | **2** | — |
| **total do relatório** | 20 + 2 = **22** | **22** ✔ |

O `+2` é uma regra do original reproduzida de propósito (item 8 do módulo): nas veias de
índice negativo o `CarregaVeias4` ainda tenta o trecho da veia **seguinte**
(`mVeia[k + 1].iIndice`). Sem ela o relatório daria 20.

Dois detalhes do relatório de materiais que vieram do original e não são escolha nossa: a
descrição é a **`DescricaoCompleta`** e o `INNER JOIN` com `IndiceMaterial <> 0`
**descarta** as linhas sem material no catálogo (no painel 503, 5 das 91) — é por isso que
o relatório tem 86 linhas onde a tela do painel mostra 91.

O passo **5b** do `cad-projeto-e2e.ps1` roda os relatórios no ciclo, então a regressão é
pega automaticamente:

```text
=== 5b/7 relatorios tabulares do app ===
  == veias == Lista de Veias (22 linha(s))
  == materiais == Lista de Materiais (86 linha(s))
```

O que **não** entrou: os relatórios de **Fiação** e **Interligação** (os outros dois
tabulares do começo recomendado — remontam bornes/réguas/dispositivos de várias tabelas),
a exportação para Excel/DWG/PDF e o `OrdenaAVeia` do original (a ordenação das veias de
reserva usa heurísticas sobre o nome; aqui elas saem por `Num_Veia`). Ver `PLANO.md` §7.3.

**Rodada 64 — as duas tabelas sem revisão no app (`plaquetas_por_painel` e
`lista_materiais_por_painel`).** O `Plaquetas4` (rodada 61) e o `ListaMateriais` (rodada
62) eram gravados pelo plugin e conferidos **direto no banco**, sem leitura no app. Aqui
elas entram no contrato no molde da Etapa 10 — e são as **únicas** tabelas do projeto
sem coluna `Revisao`: a chave é o `DWG`, então o recorte da consulta é o `Painel`.

```powershell
# 1) projeta o desenho no banco do projeto (o EPLQ precisa do dicionario do desenho)
powershell -ExecutionPolicy Bypass -File scripts/cad-zwcad-smoke.ps1 -Dwg 63 -Revisao 3 `
  -Desenho "..\Elet\Teste_projeto_real\Funcional.dwg" -Banco "$TEMP\positron-projeto.db" `
  -Comandos ELET,FIA,INT,EPLQ,COMPLM

# 2) roda as MESMAS consultas que a UI chama (handlers do sidecar, sem ZMQ e sem CAD)
& services\sidecar\.venv\Scripts\python.exe scripts\app-consultas.py "$TEMP\positron-projeto.db" --painel 503
```

Medido em 2026-09-22 (o banco do ciclo completo, com o catálogo e o cadastro importados):

```text
EPLQ: 87 plaqueta(s) em Plaquetas4 (8 painel(is) com dicionário; 2 painel(is) com fiação no desenho).
COMPLM: 104 linha(s) em ListaMateriais (8 painel(is); 0 avulso(s); 199 borne(s) do desenho, 0 sem régua no dicionário; ordem do desenho; 83 posição(ões) de layout).
...
  lista_materiais_por_painel       91 linha(s)
  plaquetas_por_painel             87 linha(s)
  total                          5075 linha(s)
```

As duas contagens são as do **painel 503** e batem com o que o plugin gravou: o `COMPLM`
numera a lista por painel e o painel 503 tem **91** das **104** linhas (as outras 13 se
distribuem por 7 painéis: `1`=1, `9`=2, `149`=1, `154`=1, `155`=4, `509`=2, `510`=2); o
`EPLQ` gravou **87** plaquetas, **todas** no painel 503 (os outros painéis com dicionário
no desenho não têm plaqueta que passe nas guardas de nome **e** descrição). O smoke do app
ia a **4.897** antes das consultas novas: com elas o ciclo padrão fecha em **4.988**
(+91, a lista do painel 503) e, com o `EPLQ` rodado, em **5.075** (+178, a lista e as
plaquetas).

> Conferido direto no banco (o que o plugin gravou, sem passar pelo app):
> `Plaquetas4` 87 e `ListaMateriais` 104, com os painéis acima.

> O `EPLQ` **não** está no ciclo padrão do `cad-projeto-e2e.ps1` (ele é independente da
> projeção); o `COMPLM` está, no passo 4. Para exercitar as consultas novas pelo ciclo,
> acrescente `EPLQ` à lista de `-Comandos` do passo 4.


tabela **`ListaMateriais`**: uma passada pelo ModelSpace vira uma lista de material por
painel — uma linha por LM da **máscara** (`M`) e do **dispositivo** (`P`), uma linha
**agregada** por `(painel, régua, tipo, lm)` para cada **borne** (`B`) e as **reservas**
das réguas somadas às linhas equivalentes. O `E`, o `A` e o `I` **não** entram: o
`switch` do original só trata `B`/`P`/`M`.

Duas colunas merecem atenção na conferência:

- **`OrdemLay`** — o `BuscaOrdemEquipamento`, que é o **índice** da tag na lista do painel
  do dicionário **`CENG_LAYOUT` do próprio desenho** (`"P"&painel` e depois `"C"&painel`),
  ou **10000** quando o equipamento não está no layout (e `0` nas reservas). A dedup da
  lista é **ordinal** e a busca é **sem caixa**, como no original. Não é "modelo de
  página fora do desenho": o `CENG_LAYOUT` é o mesmo dicionário que o `FIA` lê para o
  `PosicaoNum`/`Ordem`.
- **`Ordem`** — é **renumerada 1..N por painel** no fim do fluxo, e a ordem dentro do
  painel sai da segunda bolha do original, que é **defeituosa** (a primeira comparação usa
  o índice de fora). Ou seja: a ordem depende da **lista inteira**, não só do painel.

O `COMPLM` não precisa de catálogo nem de cadastro — só do desenho e do banco:

```bash
powershell -ExecutionPolicy Bypass -File scripts/cad-zwcad-smoke.ps1 \
  -Dwg 63 -Desenho "..\Elet\Teste_prjeto_real\Funcional.dwg" \
  -Banco "$TEMP\positron-complm.db" -Comandos ELET,COMPLM,COMPLM
```

Log medido no ZWCAD 2026 (o desenho real; `COMPLM` **duas vezes** de propósito):

```text
COMPLM: 104 linha(s) em ListaMateriais (8 painel(is); 0 avulso(s); 199 borne(s) do desenho, 0 sem régua no dicionário; ordem do desenho; 83 posição(ões) de layout).
COMPLM: 104 linha(s) em ListaMateriais (8 painel(is); 0 avulso(s); 199 borne(s) do desenho, 0 sem régua no dicionário; ordem do desenho; 83 posição(ões) de layout).
```

As **duas** passadas darem 104 é a idempotência: a projeção apaga por `DWG`
(`RemoveMateriaisLista` + `RemoveItemMaterial`) antes de inserir, como o `FIA`/`INT`. O
`FIA` rodado na mesma sessão segue nos números de sempre (494/265/**168**/70/83/11/15) —
o `COMPLM` não mexe em nenhuma outra tabela. O `cad-projeto-e2e.ps1` passou a rodar
`COMPLM` no passo 4, então o ciclo completo (`npm run cad:projeto -- -Idempotencia`) já
cobre a tabela.

**A/B contra o produto.** A tabela **não tem `Revisao`** (a chave é o `DWG`), e é o
`cad-ab-tabelas.ps1` que sabe disso (`-TabelasSemRevisao`, padrão `ListaMateriais`):

```bash
powershell -ExecutionPolicy Bypass -File scripts/cad-ab-tabelas.ps1 \
  -Mdb "..\Elet\Teste_prjeto_real\RCD.mdb" -Tabelas Bornes4F,ListaMateriais -SaidaDir "$TEMP\ab"
python scripts/cad-ab-tabelas.py "$TEMP\positron-complm.db" "$TEMP\ab\mdb-<data>" \
  --nosso-dwg 63 --nosso-revisao 3 --detalhe
```

Medido em 2026-09-22 no `Funcional.dwg` (DWG 63, com o `FIA` na mesma base): **104** linhas
do recoder contra **111** do produto. O número engana — separando as linhas por família, o
resultado é:

| Família | Recoder | Produto | Chaves comuns | O que difere |
|---|---|---|---|---|
| dispositivo (`Handle` = handle do bloco) | 40 | 40 | **40** | só a `Ordem` |
| máscara/modelo (`Handle` vazio) | 43 | 43 | **43** | só a `Ordem` |
| borne (`Handle = "BORNE"`) | 21 | 25 | 15 | `Ordem` (7), `Quantidade` (2), 6 só no recoder e 10 só no produto |
| avulso (`Avulso = true`) | 0 | 3 | 0 | itens manuais do app |

As **83** linhas de dispositivo/máscara são **idênticas em conteúdo** — `IndiceMaterial`,
`Quantidade`, `OrdemLay`, `Handle`, `Alternativo` e `Avulso` batem **todas**; só a `Ordem`
difere (é o que está explicado abaixo). Isso valida o `OrdemLay` **linha a linha** contra o
produto, inclusive as **83 posições** do layout.

As linhas de **borne** divergem **exatamente** onde o `Bornes4F` diverge — e as chaves são
as mesmas, o que atribui a diferença à **cópia do desenho**, não a regra:

```text
(Painel, Régua) só no recoder:  (9,'R8') 3   (503,'ENTR 1') 8   (503,'ENTR 2') 8
(Painel, Régua) só no produto:  (503,'52-X1') 3   (503,'52-X2') 3
contagem diferente:             (9,'R6') 48 x 46   (503,'BARRA') 4 x 6
```

É o mesmo `168 x 155` documentado desde a rodada 28 (a cópia local do `Funcional.dwg` não é
a que o produto compilou; as réguas `ENTR 1`/`ENTR 2` do desenho são as `52-X1`/`52-X2` do
banco do produto). O `COMPLM` ainda informa **199 bornes lidos e 0 sem régua no
dicionário**, então nenhuma linha caiu por falta de régua: as linhas a mais do produto nos
painéis **715/716** (4+4, réguas `A`/`B`/`C`/`N`) e as nossas a mais no painel **1** (`R16`)
e nos **509/510** (`SAÍDA`) são a mesma diferença de população de bornes.

**A `Ordem` do produto veio do "Sim" do diálogo.** O `CompilaListaDeMateriais` pergunta
(`YesNoCancel`) se a ordem vem da **lista que já estava no banco**; no "Sim" ele soma
`10000` a todas as linhas e sobrescreve cada uma com a `Ordem` anterior, o que faz a
ordenação final das linhas **não avulsas** ser pela `Ordem` antiga. O rastro está no
próprio produto: o `Indice` (autonumber) das 111 linhas do DWG 63 está agrupado pela
`Ordem` — todas as "1" (`52-X1`, `72-27B`, `72-27A`, `R1`, `R6`, `NOTA 3`, `A`…) antes de
todas as "2" —, ordem que só esse caminho produz. O recoder usa o **`Não`** por padrão
(ordem do desenho), com o `Sim` em `ordemListaBanco`/`POSITRON_LM_ORDEM_BANCO`; é por isso
que a coluna `Ordem` difere em **todas** as linhas das duas famílias idênticas. As **3**
linhas `Avulso` do produto são itens lançados à mão no app: a projeção os relê
(`CapturaMateriaisAvulso`) e os regrava, mas uma base nova não tem nenhum — o teste de
unidade cobre a preservação (inclusive o `IndiceLM`, que a projeção **não** atribui).

**Rodada 61 — exportação das plaquetas (`EPLQ`, o `exportaPlaquetas`).** É o fluxo da
tabela **`Plaquetas4`** — a plaqueta de identificação de cada painel. Não vem do
catálogo nem do diagrama: vem do **próprio desenho**, do dicionário
`CENG_PLAQUETA` do `NamedObjectsDictionary` (um `Xrecord` por **painel**, com registros
de **7 valores**: tipo, handle, indexRegua, desc1, desc2, desc3, modelo). O **nome** de
cada plaqueta sai do tipo: `P` = nome do painel (cadastro `Paineis`), `D` = `Nome1[/Nome2]`
do bloco `M`/`P` resolvido pelo **handle**, `X` = a primeira descrição não-vazia e
`R` = o nome da **régua** pelo `IndiceRegua` (o mesmo dicionário `REGUAS/MODELOS2` que o
`FIA` já lê). Só entram painéis **com fiação no desenho** (os citados pelas `CONEXAO`)
e só gravam as plaquetas com nome **e** alguma descrição — plaqueta sem texto é plaqueta
que não imprimiu.

A fixture monta o dicionário à mão (é o único jeito: nada mais no recorte escreve
`CENG_PLAQUETA`) e semeia o cadastro de painéis, que é quem dá o nome do tipo `P`:

```bash
# banco com o cadastro de paineis (o nome da plaqueta "P" sai daqui)
python -c "import sys, sqlite3; sys.path.insert(0, r'services/sidecar/src'); \
  from sidecar.db.project import ProjectDatabase; ProjectDatabase(r'<db>').create_from_schema(); \
  c=sqlite3.connect(r'<db>'); c.execute(\"INSERT INTO Paineis(Indice, Nome) VALUES (9, 'PAINEL-9')\"); c.commit()"

powershell -ExecutionPolicy Bypass -File scripts/cad-zwcad-smoke.ps1 -Banco "<db>" \
  -Fixture scripts/cad-fixture-plaquetas.lsp -Comandos ELET,EPLQ
```

Log medido no ZWCAD 2026 (fixture: painel **9** com `CONEXAO` e 4 registros — `P` com
descrição, `X`, `D` sem dispositivo e `P` sem descrição — mais o painel **77**, que só
existe no dicionário):

```text
EPLQ: 2 plaqueta(s) em Plaquetas4 (2 painel(is) com dicionário; 1 painel(is) com fiação no desenho).
```

E a tabela no banco, conferida direto:

```text
PLAQUETA (1, 1, 9, 'PAINEL-9',      'MOD-P', 'PLACA DO PAINEL', NULL, NULL, NULL)
PLAQUETA (2, 1, 9, 'TEXTO LIVRE',   'MOD-X', 'TEXTO LIVRE',     NULL, NULL, NULL)
```

Os dois registros que caem provam as guardas: o `D` (handle sem dispositivo no desenho) e
o segundo `P` (sem nenhuma descrição) não entram, e o painel **77** não entra por não ter
fiação no desenho. O `Quantidade` sai **NULL** — o original não a informa nesse INSERT — e
o `Indice` é o rowid da chave primária. Rodando o `EPLQ` **duas vezes** o resultado são as
**mesmas 2 linhas** (o `DELETE ... WHERE DWG = @dwg` mais o lote na mesma transação, a
mesma idempotência por desenho do `FIA`/`INT`) — receita: acrescente `EPLQ` à lista do
`-Comandos` e confira que o `SELECT COUNT(*) FROM Plaquetas4` não muda.

A mesma receita aponta para o **desenho real** — que tem o dicionário preenchido (basta
`POSITRON_XDATA` apontando para um arquivo e a fixture `scripts/cad-dump-xdata.lsp`, que
duma o `CENG_PLAQUETA` cru):

```bash
export POSITRON_XDATA="$TEMP/positron-xdata.txt"
powershell -ExecutionPolicy Bypass -File scripts/cad-zwcad-smoke.ps1 -Dwg 63 \
  -Desenho "..\Elet\Teste_prjeto_real\Funcional.dwg" -Banco "$TEMP\positron-projeto.db" \
  -Fixture scripts/cad-dump-xdata.lsp -Comandos ELET,EPLQ
```

```text
EPLQ: 87 plaqueta(s) em Plaquetas4 (8 painel(is) com dicionário; 2 painel(is) com fiação no desenho).
```

A conferência é **independente do plugin**: o dump traz o Xrecord cru de cada painel
(`PLAQUETA;<painel>;<entget>`) e a regra do original refeita fora do C# — no painel
**503**, **93** registros (`2 P` + `83 D` + `8 R`) dão **87** linhas (2 + 80 + 5, caindo
3 `D` e 3 `R` sem descrição), e as 5 plaquetas `R` resolvem os índices `39/44/46/478/482`
para `R9/RA1/RA2/R6/R8`. O banco fecha a conta: **87** linhas do painel 503, **0** com tag
vazia, **0** sem descrição e as 5 réguas presentes com o nome esperado. Os outros 7
painéis do dicionário (`176 177 178 453 454 465 466`) não têm fiação no desenho e por isso
não entram — a guarda do `carregaEquipComFiacao`. Uma tag se repete (`PNL-GGE`, o painel):
são **dois registros `P` idênticos** no dicionário, e o original insere um por registro
(o `AdicionaItemPlaqueta` não agrega, e o INSERT não tem `Quantidade`) — a repetição é o
espelho do dado, não do código.

**Rodada 60 — ação "Corrigir cabos" (`INDCABO`, o `IndefineCabosNaoExistentes`).** É o
botão `BTCorrigeCabos` da tela de verificação da **interligação**: o trecho cujo
`Tag_Cabo` não existe no catálogo (`Cabos`) perde o cabo e a veia no XData, e o rótulo
auxiliar (`AUXINTERLIG` tipo 1) vira o caracter de terminal indefinido. É a contrapartida
de **escrita** da regra read-only `CaboSemCatalogo` que o `VERIF` reporta. Duas guardas do
original foram reproduzidas: **catálogo vazio não faz nada** (`if (lCabos.Count <= 0)
return;` — sem isso a ação apagaria a tag de todo trecho do desenho) e a comparação é
**ordinal** (sensível a caixa, o `List(Of String).Contains` do original).

A prova é o próprio ciclo do plugin, e não SQL cru: uma fixture com dois trechos — um
cabo no catálogo e um **fantasma** — e um rótulo de cabo, com o catálogo semeado na mão
(`INSERT INTO Cabos(Tag, Blindagem) VALUES('CABO-OK', 0)`):

```bash
# banco com o catálogo semeado
python -c "import sys; sys.path.insert(0, r'services/sidecar/src'); \
  from sidecar.db.project import ProjectDatabase; ProjectDatabase(r'<db>').create_from_schema()"
python -c "import sqlite3; c=sqlite3.connect(r'<db>'); \
  c.execute(\"INSERT INTO Cabos(Tag, Blindagem) VALUES('CABO-OK', 0)\"); c.commit()"

powershell -ExecutionPolicy Bypass -File scripts/cad-zwcad-smoke.ps1 -Banco "<db>" \
  -Fixture scripts/cad-fixture-indefcab.lsp -Comandos ELET,INT,INDCABO,INT,VERIF
```

Log medido no ZWCAD 2026 (a **prova** é o segundo `INT` cair de 2 para **1**: a leitura da
projeção descarta `Num_Veia == -1000`, ou seja o XData foi mesmo regravado):

```text
INT: 2 linha(s) gravada(s) em Interligacao4 (0 borne(s)); ... 2 cabo(s) em Cabos4
INDCABO: 1 de 2 trecho(s) de interligação indefinido(s); 1 de 1 rótulo(s) do cabo com o caracter indefinido (catálogo: 2 cabo(s)).
INT: 1 linha(s) gravada(s) em Interligacao4 (0 borne(s)); ... 2 cabo(s) em Cabos4
VERIF: por tipo — PontoSemTag: 2; InterligacaoIndefinida: 1.
```

O `VERIF` passa a apontar `InterligacaoIndefinida: 1` (a regra do `carregaTree`), que é o
mesmo trecho que a ação limpou. Na fixture padrão (`npm run cad:e2e`) nada muda — os
números documentados (4 problemas) seguem iguais.

**Rodada 139 — a correcao da interligacao (`CorrigeInterligacao`, o `verificaDispInterlig`).** O
comando da frente 2 que fecha o laco do `VERIF` na interligacao por **pagina inteira**: para cada
trecho **indefinido** (`NumVeia == -1000`, o estado que o `INDCABO` deixa) ele redescobre o painel de
cada ponta pelo dispositivo que esta sobre ela e regrava `Painel1`/`Painel2` — os mesmos campos que a
projecao do `INT` le. A regra e pura (`Positron.Data.Interligacao.CorrecaoInterligacao`) e o adapter
(`Positron.Plugin.Interligacao.CorrecaoDaInterligacaoDoDesenho`) reproduz os **cinco ramos** do
`verificaDispInterlig`, com **duas divergencias registradas**: a caixa e o teste da **posicao** do
bloco (o original usa `SelectCrossingWindow`) e um painel que resolve em **0** conta como **nao
achado** — o original gravaria o zero por cima de um painel valido; a regra pula e conta esses
trechos em `SemDispositivo`.

A fixture monta **oito** trechos, um por ramo, e o instrumento
`scripts/cad-conta-interligacao.lsp` (leitura crua do XData, sem regra nenhuma) da o dump
independente:

| trecho | y | o que e | o que o comando faz |
|---|---|---|---|
| A | 10 | par errado `(1, 2)` | grava `(503, 9)` |
| B | 20 | o par certo na **ordem trocada** `(9, 503)` | nao regrava |
| C | 30 | `Tipo 2` com `Painel1 = 0` | grava o achado no `Painel2` (`0, 9`) |
| D | 40 | `Tipo 3` sem dispositivo na ponta 1 | usa a **ponta 2** (`0, 9`) |
| E | 50 | cabo **definido** | fora do comando |
| F | 60 | **sem dispositivo** nas pontas | pula (o original gravaria 0) |
| G | 70 | dispositivos em **outra camada** | o filtro de pagina do original os recusa |
| H | 80 | um dispositivo **`P`** na ponta 1 | **quebra** a busca daquela ponta (o ramo do original) |

```bash
$env:POSITRON_CONTA = "<repo>/scripts/cad-conta-interligacao.lsp"   # o fixture faz (load)
$env:POSITRON_DUMP  = "$env:TEMP/positron-ilig-dump.txt"
powershell -ExecutionPolicy Bypass -File scripts/cad-autocad-smoke.ps1 \
  -Fixture scripts/cad-fixture-corrige-interligacao.lsp \
  -Comandos CorrigeInterligacao,CorrigeInterligacao,pz-conta-ilig -Dwg 63 -Banco "$env:TEMP/positron-ilig.db"
```

Log medido no AutoCAD 2020 (a **segunda passada e a convergencia**):

```text
CorrigeInterligacao: 3 de 7 trecho(s) indefinido(s) regravado(s); 3 sem dispositivo na(s) ponta(s) (8 trecho(s) lido(s); 8 bloco(s) na(s) caixa(s) das pontas).
CorrigeInterligacao: 0 de 7 trecho(s) indefinido(s) regravado(s); 3 sem dispositivo na(s) ponta(s) (8 trecho(s) lido(s); 8 bloco(s) na(s) caixa(s) das pontas).
```

Dump independente (o `y` identifica o trecho):

```text
ILIG;2A4;80;1;-1000;5;7      <- H: o P quebrou a busca, pulado
ILIG;2A1;70;1;-1000;5;7      <- G: camada errada, pulado
ILIG;2A0;60;1;-1000;5;7      <- F: sem dispositivo, pulado
ILIG;29D;50;1;1;1;2          <- E: cabo definido, intacto
ILIG;29B;40;3;-1000;0;9      <- D: corrigido pela ponta 2
ILIG;299;30;2;-1000;0;9      <- C: corrigido no Painel2
ILIG;296;20;1;-1000;9;503    <- B: par revertido, intacto
ILIG;28F;10;1;-1000;503;9    <- A: corrigido
```

No **desenho real** (`Funcional.dwg`) o comando le **20 trechos e nenhum indefinido** — `0 de 0`,
com o mesmo dump mostrando os 20 com `Num_Veia` definido (`2`, `1`, ...) e os pares de painel da
copia: o zero e o **dado**, nao um no-op silencioso.

**Licao de instrumento (a fixture mentiu primeiro):** o `_.LAYER _M "99"` deixa a camada 99
**corrente**, e as polylines nasciam nela — o comando filtra os candidatos pelo **layer do proprio
trecho**, entao a primeira medicao saiu `1 de 7` e com o trecho **G** corrigido (os unicos blocos
naquela camada eram os dele). O conserto e o `_.LAYER _S "12"` antes de desenhar (esta no fixture,
com comentario); a medicao errada e o que provou que o filtro de pagina e real.

**Rodada 51 — intervalos de borne (`bt8intervalos`, o `nXnc5R08lF`).** É a checagem que
monta a árvore `TreeViewBornes`: por régua, junta os bornes do desenho **e as reservas**
(`LeDicBornesReserva`), ordena por `Ordem` e aponta três coisas na sequência — número
indefinido, buraco/queda na numeração e número repetido. Duas sutilezas saíram da leitura
do original e mudam o resultado:

- o número comparado é `Numero + NumeroComplem` (**o `Terminal`**), colado antes do
  teste — e `"0"` vira `CaracterTerminalIndefinido` (`"?"`), que é como o desenho grava
  "sem número". Assim um borne com complemento (`"11A"`) **sai** do teste numérico e o
  buraco em volta dele fica escondido;
- as **reservas** entram cruas do dicionário: o mapeamento do `"0"` não é repetido nelas,
  então uma reserva `"0"` continua numérica (e vira `1 a 0`).

Só as réguas **em uso** entram (o `lPn`/`cOWeaBRTRB` do original = os painéis do desenho),
e o par `(painel, régua)` é o mesmo que a `ReguaVazia` usa. No desenho real saíram **11**
intervalos: 9 na régua `#37` (`R6`, painel 9) e 2 na `#487` (`R8`, painel 9) — a linha de
base do `VERIF` vai a **249**.

A conferência **independente** é o que dá confiança na regra: o dump dos **199** bornes do
ModelSpace (o modo `POSITRON_XDATA_BORNES=1` do `cad-dump-xdata.lsp`) reconstruído em
Python **fora do plugin** reproduz os **11 pares exatos**, e mostra os 7 que **não** entram
— réguas `476`/`477`/`481`/`483`/`486`, dos painéis `149`/`154`/`155`/`1`, fora do filtro
de réguas em uso (o dicionário `REGUAS/MODELOS2` diz de que painel é cada régua).

**Rodada 52 — régua da máscara (`bt13ReguaMascara`, o `AC1cAJLSDI`).** A mais simples
das que faltavam: **não** toca o desenho, só o dicionário `MASCARAS`. Para cada modelo de
máscara, divide o campo `Régua` e o campo `Bornes` da porta em itens e aponta a régua
**com separador** (`;`) quando a contagem não fecha — contagens iguais (uma régua por
borne) ou `1 régua × N bornes` são o caso legítimo; qualquer outro par com `;` é
discrepância. O dedup é **por modelo** (o `list` do original) e o item apontado é o texto
cru da régua. A contagem espelha o `Geral.DivideTerminais(bRepete: true)` — descarta
**uma** `;` final e conta os trechos — e **não** reusa o `Terminais.Dividir`, que descarta
**todas** as `;` finais (divergiria de `"A;;"`, que o original conta como 2).

A regra sai **vazia** neste desenho, e o dump cru diz por quê: o `cad-dump-xdata.lsp`
ganhou uma linha por modelo (`MASCARA;<indice>;<xrecord>`) e, reconstruindo o XRecord com
o layout de 8 valores do leitor, **todos** os modelos desta cópia têm o campo `Régua`
vazio — o separador `;` mora no campo **`Terminais`** (o insumo do `bt14PortasDiscrepantes`,
que entra numa próxima rodada). Ou seja: a regra está fiel, mas este dado não a dispara;
por isso a linha de base do `VERIF` segue em **249** e o ciclo completo no AutoCAD 2020
(`cad:projeto:acad`) reproduz tudo sem regressão.

**Rodada 53 — portas discrepantes (`bt14PortasDiscrepantes`).** O `VerificaPortasDiscrepantes`
do `clsPortas` (alimentado pelo `CarregaTodasAsPortasPortas`) cruza cada **bloco `E`**
do desenho com a **definição do modelo** e aponta, atributo a atributo (só os com tag de
sufixo numérico): `T<n>` contra o n-ésimo item de `Terminais` (modelo com menos itens que
`n` já é discrepância), `B<n>` contra `Bornes` (com o `*` de "repete" removido) e `R<n>`
contra `Régua` — mais o ramo do `list`: um borne marcado com `*` cuja régua `R<n>` está
**invisível** também aponta. A comparação é sem diferenciar maiúsculas e **sem `Trim`**
(o texto cru).

Duas defensivas separam o recoder do original: o original **estoura** o índice quando
`B<n>`/`R<n>` cai fora da lista do modelo (`array2[num5 - 1]`) e no `CInt` de uma tag sem
número; aqui isso vira discrepância (ou é ignorado) — o plugin não pode derrubar o CAD.
Entraram o leitor `PortasDoDesenho` (blocos `E` + atributos com visibilidade), o campo
`IndiceDaPorta` no `DispositivoFiacao` (o `array[6]` do XData `E`/`A`) e o `Invisible` no
stub do CAD.

**Medido no desenho real:** o `VERIF` loga **45** blocos `E` lidos — o mesmo número do
dump cru dos `557` INSERTs — e a regra sai **vazia**: os 45 blocos casam com os modelos e
não têm atributos `B*`/`R*` (só `T*`, que bate com o modelo). A reconstrução em Python do
dump cru, **fora do plugin**, também prevê **0** discrepâncias; a linha de base segue
**249** e o ciclo completo no AutoCAD 2020 (`cad:projeto:acad`) reproduz tudo.

**Rodada 54 — principal × auxiliar (`bt3Principal`, `bt4Auxiliar`).** Os dois botões
reusam a grade da tela: `bt3Principal` só chama `mostraBT(2)`, `bt4Auxiliar` chama
`mostraBT(3)` e `AtualizaAuxiliar()` — quem monta as duas listas é a **carga do
formulário**, em `MbycXLEWI4()` (a `dgPrincipal`, sobre `zvRejlppGf`, os dispositivos
`P`) e `XSScUGxu4K()` (a `dgAuxiliar`, sobre `A94eLhaDqZ`, os blocos `A`).

O `bt3` junta os atributos `T*` do bloco num texto só (o `LeOsTerminais`: ordenados
pela tag, unidos por `", "` e com `"0"`/vazio virando o `CaracterTerminalIndefinido`
`"?"`) e aponta o dispositivo quando esse texto tem `"?"` **ou** quando
`LM1 == 0 && LM2 == 0`. **A conjunção do LM é do original e foi reproduzida**: a
montagem da lista exige `iLM1 == 0 && iLM2 == 0`, e só depois a linha pede `iLM1 == 0`
— então um dispositivo com `LM1 == 0` e `LM2 != 0` **não** é apontado. Isso parece
acadêmico até olhar o desenho: **os 73 dispositivos `P` desta cópia têm `LM2 = 0`**
(o `LM1` está preenchido em todos). Ou seja, um teste disjuntivo acusaria os 73/73; a
conjunção é o que faz a regra calar.

O `bt4` é o mais intrincado dos portados até aqui, porque a comparação dos terminais
depende de **dois tipos**:

- o tipo do **contato do modelo** — o `TipoDoContato` do XData do `A` (`array[7]`:
  `1` = `NA`, `2` = `NF`, `3` = `RV`);
- o tipo do **bloco usado** — o `TipoBlocoUsado = Mid(Nome, 5, 2)`, que neste desenho
  sai `NA`/`NF`/`RV` dos nomes `V_A_NA1_ST`, `V_A_NF13_ST`, `V_A_RV1I5_MOD_ST`.

E é a matriz dos dois que decide **quais** terminais contam: `RV`×`RV` compara os três
(`T1`/`T2`/`T3`), `RV`×`NF` compara dois, `RV`×`NA` compara o `T1` e — a assimetria que
parece bug e não é — o `T2` do bloco contra o **`T3`** do modelo (é o contato `RV`
desenhado como bloco `NA`: só dois terminais são desenhados, e o terceiro do modelo é
pulado), e `NA`×`NA` / `NF`×`NF` comparam `T1`/`T2` e exigem o `T3` do bloco **vazio**.
Qualquer outra combinação não é apontada. Os terminais do modelo saem do dicionário
`CONTATOS` (o `LeOsTerminaisdeUmIndiceDeContatosAuxiliar`: `T1` sempre, `T2`/`T3` só
quando não vazios).

Entraram quatro campos no `DispositivoFiacao` — `Lm1`/`Lm2` (`array[21]`/`array[23]` do
`P`) e `HandleBob`/`TipoDoContato` (`array[4]`/`array[7]` do `A`) — e **nenhum leitor
novo**: as duas regras consomem o mesmo `DispositivosDeFiacaoDoDesenho` que a fiação
já usa, com os terminais de cada bloco. As regras são puras (`VerificarDispositivosPrincipais`,
`VerificarAuxiliaresDivergentes`) e recebem os contatos por modelo como dicionário, no
mesmo estilo da régua da máscara.

**Medido no desenho real:** o `VERIF` loga `73 dispositivo(s) principal(is) (P) e 63
auxiliar(es) (A) lido(s) do desenho` e as duas regras saem **vazias** — a linha de base
segue **249** e o `cad:projeto:acad` reproduz o ciclo. O que dá confiança não é o zero,
mas o dado por baixo dele, reconstruído **fora do plugin** a partir do dump cru novo
(`POSITRON_XDATA_DISPOSITIVOS=1`):

- os 73 `P` não têm nenhum `LM1 = 0` e nenhum `"?"` nos terminais → `bt3` = **0**;
- no lado `A`, **51** dos 63 blocos têm terminais **diferentes** do contato do modelo
  (27 bobs, todos dispositivos `P` conhecidos) e mesmo assim a contagem é **0**, porque
  a matriz de tipos os filtra — e ela está toda exercitada no desenho (`37` `NA`×`RV`,
  `14` `NF`×`RV`, `6` `RV`×`RV`, `6` `NA`×`NA`).

Exemplo do que a matriz esconde (handle `7367`, bloco `V_A_NA1_ST`): o bloco traz
`T1 = 21`, `T2 = 24` e o modelo 53/contato 2 tem `21, 22, 24` — o `T2` do bloco casa
com o **terceiro** terminal do modelo, que é exatamente o caso `RV`×`NA` previsto na
tela (`21` contra `21`, `24` contra `24`).

O conteúdo é puro (`RelatorioCompilacao`: `Texto()`/`Salvar()`, testado) e o `VERIF`
passou a compartilhar a mesma montagem (`VerificarRevisao`), então os dois não podem
divergir.

A **tela** correspondente é o comando `ELETCMP`: mesma montagem (`MontarRelatorio`),
mostrada numa `DataGridView` (área, tipo, tabela, identificador, detalhe) com botão
Salvar. Ela é **modal** — como o `ELETCFG`, não entra em script, e é por isso que a
verificação automatizada usa o `ELETREL`; o conteúdo dos dois é o mesmo objeto.

**Rodada 55 — bornes editados (`bt9Discrepantes`, o `QU5c0lgjBd`).** O botão lista a grade
`dgBornesEditados`: os bornes cujo **número visível** no bloco contradiz o número que a
régua/XData define. A regra nasce na montagem de `m_TodosBornes`, no
`buscaDadosDeFiacaoDWG` (linhas 743-757): o original parte do número do XData (o `Numero`
com o `NumeroComplem` colado e o `"0"` virando `CaracterTerminalIndefinido`),
**substitui** o `NumeroComplem` pelo atributo `T1` do bloco (`clsBlocos.LeUmAtributoDeUmBloco`)
e o zera quando coincide com o número; a grade mostra exatamente os que sobram. A
comparação é sem diferenciar maiúsculas (`TextCompare`) e sem `Trim`, e a tag é casada
ignorando caixa.

Entrou um campo no `PontoBorne` — `NumeroVisivel`, lido do atributo `T1` no
`BornesDoDesenho.Ler` (na mesma transação e na mesma varredura dos bornes) — e a regra pura
`VerificarBornesEditados`. Nenhum leitor novo de entidade: o `T1` sai da
`AttributeCollection` que o adapter de dispositivos já percorria.

**Medido no desenho real:** a regra sai **vazia** — nenhum `BorneEditado`, e a linha de base
segue **249**. O insumo, porém, é não-trivial e foi conferido **fora do plugin** com o dump
cru (`POSITRON_XDATA_BORNES=1`, que passou a dumpar também a linha `ATT;T1=`): os **199**
bornes do ModelSpace têm o atributo `T1` preenchido (199/199) e **nenhum** diverge do número
do XData — logo o zero é a cópia estar limpa, não um no-op.

**Rodada 57 — verificador da interligação (`carregaTree`).** A outra tela de verificação
(`frmVerificadorProjetoInterligacao`) monta **duas** árvores sobre o ModelSpace, e as duas
saem do mesmo `carregaTree` (`clsVerificadorProjetoInterligacao:352`), alimentado por
`buscaDadosDoDWG` (linha 44) e pelos convidados da tela de fiação (`lPnApagados`, o
`LFiacaoTTDuplicada`): **"External Jumper"** (mensagem 703) e **"Interconnection"** (508).

O que cada nó aponta:

- **Jumper indefinido** — jumper é a conexão `CONEXAO` com `Jumper == "JUMPER"`. Entra quando
  **não tem cabo** (`Cor`) ou **não tem seção** (`Secao`), ou quando o painel está apagado; o
  original aponta **um por potencial** (`iPotencial_Veia`), mesmo com vários jumpers no mesmo
  potencial.
- **Jumper duplicado** — o nó "Duplicates" (1567) sob "External Jumper" não vem do
  `carregaTree`: vem do `buscaDadosDeFiacaoDWG` no modo `"J"`
  (`ClsVerificadorProjetoFiacao:797`), que joga no `LFiacaoTTDuplicada` o jumper `Tipo 4`
  **com as duas pontas ligadas** (`Disp1 & Disp2`) que repete um potencial já visto. O
  primeiro é o legítimo; do segundo em diante, o handle entra na lista.
- **Trecho de interligação indefinido** — trecho sem `Tag_Cabo` (o texto vira "Undefined",
  740) ou em painel apagado, **um por handle**.

Dois pontos de fidelidade que o recoder reproduz:

1. `lPnApagados` **não é do desenho**: a tela de interligação o recebe da tela de fiação, e é
   o painel referenciado que o cadastro do projeto não conhece (o
   `Dicionario.BuscaNomeDoPainel` devolveria `"???"`) — o mesmo conjunto de
   `PainelSemCadastro`, sem o painel `0`.
2. O verificador da interligação **não filtra a veia indefinida**: o `buscaDadosDoDWG`
   aceita todo XData válido, inclusive `Num_Veia == -1000` — só o `frmCompilarInterligacao`
   (linha 1353) descarta esses trechos. Por isso `InterligacaoDoDesenho.Ler` ganhou
   `incluirVeiaIndefinida: true` (a projeção continua no padrão `false`).

Entram os campos `Disp1`/`Disp2` no `ConexaoFiacao` (o `array[14]`/`[15]` do XData `CONEXAO`,
que só essa checagem usa) e os três tipos novos (`JumperIndefinido`, `JumperDuplicado`,
`InterligacaoIndefinida`), todos de **área Desenho**, com as regras puras
`VerificarJumpersIndefinidos`, `VerificarJumpersDuplicados` e
`VerificarTrechosInterligacaoIndefinidos`.

**Medido no desenho real:** o `VERIF` loga `0 jumper(s) e 20 trecho(s) de interligação
lido(s) do desenho` e as três regras saem **vazias** — a linha de base segue **249** e o
ciclo completo no AutoCAD 2020 (`cad:projeto:acad -- -Idempotencia`) reproduz tudo
(`IDEMPOTENTE`). O zero tem duas causas, ambas conferidas: o `Funcional.dwg` **não tem
jumper** (a rodada 35 já registrou isso — "sem efeito neste desenho, que não tem jumper"),
e os 20 trechos de interligação têm `Tag_Cabo` preenchido e painel dentro do cadastro
(consulta direta ao banco: `Interligacao4` = 20 linhas, **0** sem `Tag_Cabo`, **0** com
painel fora de `Paineis`). Ou seja: no lado da interligação o zero é a cópia estar limpa; no
lado do jumper, o insumo não existe nesta cópia — o que sobra de garantia são os **7 testes**
unitários das três regras.

**Rodada 56 — blocos duplicados (`bt12AMao`, "Copy made by hand").** É a última checagem da
tela de fiação. O botão chama `mostraBT`, mas quem monta a grade `dgAMao` é a carga do
formulário (`mqVcgNjXuh`), **sobre o `jhleNuAtKc`** — o array que o
`clsBlocos.VerificaDuplicados` preenche numa varredura do ModelSpace. Ou seja: não é uma
tela de cálculo própria, é o **detector de duplicados** do desenho.

A regra do original: por bloco, monta uma **chave de identidade** conforme o tipo e, quando
a chave já apareceu, o bloco é um duplicado. O `list` de chaves é **um só** para todos os
tipos (compartilhado), a comparação é **ordinal**, e a grade mostra só os de **painel em
uso** (`cOWeaBRTRB`). As chaves, que é o que importa portar:

| tipo | chave | rótulo |
|------|-------|--------|
| máscara (`M`) | `painel_nome1_nome2_alternativo` (pula complementar) | `Mask` |
| dispositivo (`P`) | idem (pula complementar) | `Main Device` |
| porta (`E`) | identidade da **máscara** apontada + `indiceDaPorta` | `Door` |
| borne (`B`) | `painel_indiceRegua_numero` (pula `"?"`/`"0"` no duplicado) | `Terminal` |
| auxiliar (`A`) | identidade do **bob** apontado + `IndexContato` | `Auxiliary Contacts` |
| definição (`D`, `DBText`) | `handleMascara_indiceModelo_indiceDaPorta` | `Definition` |

Dois detalhes do original foram reproduzidos de propósito: o **complemento do número do
borne não entra** na chave (é o `Numero` cru, não o `Terminal`), e o **filtro do auxiliar
usa o `indexPainel` do último borne processado** — não o do bob (a variável `structureBorne`
é reaproveitada fora do laço). É um bug do original, e o zero desta cópia não o esconde: a
regra unitária o exercita.

Entrou um leitor novo numa **passada só** (`BlocosDuplicaveisDoDesenho`) — a ordem do
ModelSpace importa, porque é ela que decide qual cópia vira apontamento e qual painel o
auxiliar vê. Ele resolve as referências da porta e do auxiliar pelo handle (`array[4]`) e o
texto de definição pelo XData `Definicao`; a identidade da máscara/bob sai do mesmo
`DispositivoFiacaoXData` da fiação. A regra pura é `VerificarBlocosDuplicados` e o tipo novo
é `BlocoDuplicado`.

**Medido no desenho real:** o `VERIF` loga `406 bloco(s) lido(s) para a checagem de
duplicados` e a regra sai **vazia** — a linha de base segue **249** e o ciclo completo no
AutoCAD 2020 (`cad:projeto:acad -- -Idempotencia`) reproduz tudo (`IDEMPOTENTE`). O que dá
confiança é a conferência **independente**: o modo novo `POSITRON_XDATA_DUPLICADOS=1` do
`cad-dump-xdata.lsp` dumpar identidade por item e a reconstrução em Python **fora do
plugin** fecha **406 itens** (199 `B`, 73 `P`, 63 `A`, 45 `E`, 10 `M`, 16 `D`) com **406
chaves distintas** — logo o zero é a cópia estar limpa, não um no-op, e o leitor concorda
com o dump item a item.

### O ciclo completo no projeto real (`npm run cad:projeto`)

Um comando roda o caminho inteiro sobre os arquivos do dono — projeta, carrega o
cadastro, confere o app, o relatório e (com `-Idempotencia`) a repetibilidade:

```powershell
npm run cad:projeto                       # projeta, importa, consulta, confere a base
npm run cad:projeto -- -Idempotencia      # + 3a passada e comparacao de conteudo
```

Passos: banco novo → `ELET,FIA,INT` no `Funcional.dwg` → catálogo e cadastro de painéis
do `RCD.mdb` → **`INT,COMPLM,VERIF,ELETREL` de novo** → consultas do app → linha de base
do `VERIF` → idempotência. Tudo com os caminhos do projeto por padrão (`-Desenho`, `-Mdb`,
`-Dwg 63`, `-Revisao R0`).

**A segunda passada de `INT` não é redundância — é a ordem certa.** O `INT` carimba
`Cabos4`/`Veias4` a partir do **catálogo carregado** (é o `RUIU5Sbjhj` do original, que
copia o catálogo no momento da compilação). Rodar o `INT` antes de o cadastro existir
grava zero cabo — foi exatamente o que a primeira versão deste script fez, e o passo 5
denunciou (`cabos4_por_revisao 0`). Na vida real é o mesmo: carregue o projeto (catálogo
e painéis) **antes** de compilar, ou recompile depois de carregar.

Saída boa (resumida):

```
FIA: 494 linha(s) em Fiacao (...); 265 porta(s) em Portas4F; 168 borne(s) em Bornes4F;
     70 contato(s) em Contatos4F; 83 dispositivo(s) em Dispositivos4F; 11 circuito(s);
     15 tipo(s) em Aplicacao4F
INT: 20 linha(s) em Interligacao4; 265 porta(s) em Portas4I; 216 borne(s) em Bornes4I;
     697 cabo(s) em Cabos4; 2388 veia(s) em Veias4
projeto_listar_paineis   480 | fiacao_por_painel 490 | circuitos_por_painel 11
cabos4_por_revisao       697 | veias4_por_revisao 2388 | materiais 210
lista_materiais_por_painel 91 | plaquetas_por_painel 0     (painel 503; 4.988 no total)
linha de base confere (249 = 107 + 119 + 11 + 10 + 2)
IDEMPOTENTE: mesmo conteudo (ignorando Data)
```

> As duas últimas linhas são da rodada 64 e são **por painel** (essas tabelas não têm
> revisão). No **ciclo padrão** o `COMPLM` roda no passo 4, então a lista sai com **91**
> linhas no painel 503 e as plaquetas ficam em **0** (o `EPLQ` não está na lista de
> comandos do ciclo): o total do smoke vai a **4.988**. Acrescentando `EPLQ` aos
> `-Comandos` do passo 4 — ele depende do dicionário `CENG_PLAQUETA`, que o
> `Funcional.dwg` tem — as plaquetas saem **87** e o total vai a **5.075**.

### A/B de conteúdo das tabelas (`scripts/cad-ab-tabelas.ps1` + `.py`)

O A/B de conteúdo virou ferramenta: um script exporta as tabelas do produto e o outro
compara com o banco do recoder, com os dois lados passando pela **mesma normalização**.

```powershell
# lado do produto (Access, numa copia) -> um CSV por tabela
powershell -ExecutionPolicy Bypass -File scripts/cad-ab-tabelas.ps1 `
  -Dwg 63 -Revisao 3 -SaidaDir "$env:TEMP\positron-ab"

# comparacao (o filtro do recoder vem por parametro: o rotulo da revisao e outro)
& services\sidecar\.venv\Scripts\python.exe scripts\cad-ab-tabelas.py `
  "$env:TEMP\positron-projeto.db" "$env:TEMP\positron-ab\mdb-..." --nosso-dwg 63 --nosso-revisao R0
```

O lado do recoder sai do **host CAD instalado** (o ZWCAD 2026 nesta máquina):

```bash
npm run cad:smoke -- -Dwg 63 -Revisao R0 -Comandos ELET,FIA `
  -Desenho "..\Elet\Teste_prjeto_real\Funcional.dwg" -Banco "$TEMP/positron-ab.db"
```

A rodada 48 rodou o mesmo A/B pelo AutoCAD 2020 (evidência histórica) e reproduz os
vereditos da rodada 44 linha a linha:
**4 idênticas** (`Portas4F` 265, `Contatos4F` 70, `Circuitos4F` 11, `Aplicacao4F` 15) e
as 3 restantes com cada coluna divergente já explicada por **dado do desenho** (a
tabela de veredito por coluna está logo abaixo).

**Normalizações obrigatórias** (cada uma já gerou falso positivo): `None`/vazio → `''`;
`True`/`False` do Access → o **mesmo formato numérico** (`0.0000`) do SQLite, não `0`;
números com 4 casas (`Ordem 1.0` × `1`); e o texto do Access desfeito da dupla
codificação (`s.encode('cp1252').decode('utf-8')`). Sem a normalização de bool, toda
linha com coluna booleana aparecia diferente.

Com `--detalhe` o script desce ao nível da coluna: casa as linhas por `Handle` e mostra
**quantas linhas divergem em cada coluna**, com um exemplo. É o que separa "a tabela
difere" de "a coluna X difere em N linhas" — e foi assim que os dois bugs e a diferença
de dado apareceram.

Resultado no `Funcional.dwg` (revisão `3` do produto contra `R0` do recoder):

| Tabela | Recoder | Produto | Situação |
|---|---|---|---|
| `Portas4F` | 265 | 265 | **idêntico** |
| `Contatos4F` | 70 | 70 | **idêntico** |
| `Circuitos4F` | 11 | 11 | **idêntico** |
| `Aplicacao4F` | 15 | 15 | **idêntico** |
| `Fiacao` | 494 | 494 | diferenças localizadas — ver abaixo |
| `Bornes4F` | 168 | 155 | diferenças localizadas — ver abaixo |
| `Dispositivos4F` | 83 | 83 | **2** linhas, uma coluna (`BlocoLayout`) |

**Veredito de cada diferença que sobrou** (rodada 44, com o `--detalhe`):

| Tabela | Coluna | Linhas | Causa |
|---|---|---|---|
| `Fiacao` | `TipoBorne` | 79 | dado: o desenho local tem 199/199 bornes com `tipo = 0` |
| `Fiacao` | `Ordem` | 29 | dado: ordem/posição no layout |
| `Fiacao` | `Potencial` / `Terminal` | 19 / 19 | dado: pontos diferentes da cópia |
| `Fiacao` | `Tag` | 6 | dado: régua `ENTR 2` × `52-X2` |
| `Fiacao` | 2 chaves de cada lado | 2 | dado: bornes da página 1000 |
| `Bornes4F` | `Tipo` | 79 | dado (o mesmo `tipo` do borne) |
| `Bornes4F` | `Ordem` | 53 | dado: ordenação dos bornes na régua |
| `Bornes4F` | `Borne` / `Regua` | 10 / 6 | dado: bornes/numeração da cópia |
| `Bornes4F` | 33 e 20 chaves | — | dado: bornes que só existem de um lado (página 1000) |
| `Dispositivos4F` | `BlocoLayout` | 2 | dado: valor do dicionário na cópia |

As **quatro** tabelas idênticas não têm nenhuma coluna divergente, e nas três restantes
cada linha divergente tem causa identificada — nenhuma é regra de projeção. Nos dois
casos em que a dúvida era "regra ou dado?" (`TipoBorne` e `Tipo`), a resposta veio do
**dump do XData no desenho**: os dois lados leem o **mesmo índice** (14) e o dado local
é uniformemente zero.

**Duas diferenças da `Fiacao` que não são da cópia do desenho** (as linhas amostradas
mostram as duas colunas isoladas):

```
recoder: ...|FU3|FU3|NA|A|...        produto: ...|FU3||NA|A|...
recoder: ...|R6|R6|40|B|...|0.00|    produto: ...|R6||40|B|...|1.00|
```

1. **`NRegua` — era bug, corrigido na rodada 43.** O recoder preenchia o nome da régua
   no ponto (do borne ou do dispositivo); o produto deixa **vazio** — das 38.221 linhas
   de `Fiacao` do banco do produto, só **14** têm `NRegua`. A origem está no
   `ltZUHdAX7R` do `frmCompilarFiacao` (linha 2915): `NRegua` é um **parâmetro de saída**
   do casamento de terminal (`ref P_6`) e só é preenchido no caminho da **porta** (`E`,
   via `f2yUfcqdnE`, quando a regra de casamento é 2). Em `B`/`P`/`A` ele fica vazio — o
   nome da régua vai na `Tag`. Corrigido em `AplicarBorne`/`AplicarDispositivo`: a
   `Fiacao` saiu de **988** linhas divergentes para **238**;
2. **`TipoBorne` — não é bug do recoder, é o dado.** Em `R6`/borne `40` o produto grava
   `1` e o recoder `0`. Os **dois** leem o mesmo índice (`structureBorne.tipo`, XData 14
   — `XDataDispositivosMaster`, linha 891) e o dado do produto é coerente entre as duas
   tabelas (`Bornes4F.Tipo` = `1` e `Fiacao.TipoBorne` = `1` no mesmo handle). Um dump do
   XData no desenho que temos mostra **199 de 199** bornes com `tipo = 0`; a distribuição
   do produto é 79 com `1` e 58 com `0`. Ou seja: a cópia local do desenho tem os bornes
   sem o tipo (simples/duplo) gravado — mesma classe das outras diferenças de entrada.

**Fechado na rodada 42: os blocos do `Dispositivos4F`.** Eram **42** linhas divergentes
(metade da tabela) porque o recoder deixava `BlocoTopografico`/`BlocoLayout` vazias. A
regra está no `frmCompilarFiacao` (linhas 2699-2716): com `indexModelo != 0` os blocos
vêm do **dicionário do modelo**; com `indexModelo == 0`, do **XData do próprio bloco**
— `Layout = array[17]`/`Topografico = array[18]` no dispositivo `P` e
`Topografico = array[16]`/`Layout = array[17]` na máscara `M`
(`XDataDispositivosMaster`, linhas 808-809 e 845-846). O leitor de XData não expunha
esses índices; passou a expor, e o gerador usa o XData quando não há modelo. Resultado:
de **42** linhas divergentes para **2**.

**Fechado na rodada 49: as 2 restantes também são dado do desenho.** O dump do XData
no próprio desenho (`scripts/cad-dump-xdata.lsp`, rodado pelo `accoreconsole`) fecha a
questão nos handles `4D642`/`4D672` (os dois polos do `52-X1`/`52-X2`):

- o tipo é `P` e **`indexModelo = 53`** (o `array[12]`; no dump aparece como `idx=11`
  porque o dump lista os valores **depois** do app name, que é o `array[0]` do leitor);
- com `indexModelo != 0` o original usa o **dicionário** `CONTATOS → "MODELOS2"`; o
  registro do modelo **53** é `(56.34) … (1 . FINDER_58-34.DWG)`
  `(1 . FINDER_56.34+BASE_LAYOUT.DWG) … (1 . A1;A2)`, ou seja `BlocoTopografico` =
  `FINDER_58-34.DWG` e `BlocoLayout` = `FINDER_56.34+BASE_LAYOUT.DWG` — **exatamente o
  que o recoder gravou**;
- o **XData do próprio bloco concorda**: `Layout = array[17] = FINDER_56.34+BASE_LAYOUT.DWG`
  e `Topografico = array[18] = FINDER_58-34.DWG`.

Ou seja, **as duas fontes possíveis** (dicionário e XData) dizem a mesma coisa na cópia
local. O `RJ-8.dwg` que o produto gravou **não existe em fonte nenhuma** para esses
blocos: ele é o `BlocoLayout` do modelo **6** (`(RJ-8)` → `ARTECHE__RJ8_NOVO.DWG` /
`RJ-8.dwg`), e o `BlocoTopografico` do produto (`FINDER_58-34.DWG`) é do modelo **53**.
O par gravado pelo produto (`FINDER_58-34.DWG`, `RJ-8.dwg`) é um **estado anterior** do
modelo 53 (o `Layout` trocado depois da compilação) — mesma classe das demais
diferenças: dado do desenho, não regra de projeção. Com isso, **todas as diferenças do
A/B do `FIA` estão atribuídas**.

### Dumpar o XData do desenho (`scripts/cad-dump-xdata.lsp`)

Separar "bug da projeção" de "dado da cópia do desenho" exige ler o XData **do
próprio DWG**. O utilitário dumpa os handles pedidos (app `DISPOSITIVO`/`Dispositivo`/
`MASCARA`) e os dicionários `CONTATOS → "MODELOS2"`, `MASCARAS → "MODELOS2"`,
`REGUAS → "MODELOS2"` (régua → painel, que é o que explica por que uma régua fica fora
das checagens) e as **portas de cada modelo de máscara**, uma linha por modelo
(`MASCARA;<indice>;<xrecord>`, o insumo da régua da máscara — `bt13ReguaMascara`):

```bash
# roda dentro do AutoCAD 2020, carregando o utilitario antes do NETLOAD
powershell -ExecutionPolicy Bypass -File scripts/cad-autocad-smoke.ps1 `
  -Desenho "..\Elet\Teste_prjeto_real\Funcional.dwg" -Fixture scripts/cad-dump-xdata.lsp -Comandos ELET
```

A saída vai para `%POSITRON_XDATA%` ou, sem ela, `%TEMP%\positron-xdata.txt`. Os
handles são `*positron-dump-handles*` (padrão `4D642`/`4D672`); ajuste a lista antes do
`load` para dumpar outros. **Armadilha medida:** AutoLISP **não tem `let`** — o load
falha em silêncio e nada sai no arquivo; use `setq`.

Com `POSITRON_XDATA_DISPOSITIVOS=1` no ambiente ele lista **todos** os dispositivos `P`
e os auxiliares `A` do ModelSpace, mais os atributos de cada bloco e os contatos de
**todos** os modelos do dicionário `CONTATOS` — é o dado bruto das regras de principal
× auxiliar (`bt3`/`bt4`):

```text
DISP;<handle>;tipo=<P|A>;bloco=<nome>;mid52=<2 chars>;nome=<nome>;painel=<n>;lm1=<n>;lm2=<n>;bob=<handle>;modelo=<n>;contato=<n>;tipoContato=<1|2|3>
  ATT;<tag>=<texto>
```

O `mid52` é o `Mid(Nome, 5, 2)` que o `bt4Auxiliar` compara com o tipo do contato, e os
`LM` vêm de `vals[20]`/`vals[22]` (o `array[21]`/`array[23]` do leitor).

Com `POSITRON_XDATA_BORNES=1` no ambiente ele também lista **todos** os blocos de borne
do ModelSpace, um por linha — é o dado bruto para conferir qualquer regra de borne
(intervalos, réguas, LM) **fora** do plugin:

```text
BORNE;<handle>;<tipo>;<numero>;<complemento>;<ordem>;<indexRegua>;<layer>
```

```bash
POSITRON_XDATA_BORNES=1 POSITRON_XDATA="$TEMP/positron-bornes.txt" \
  powershell -ExecutionPolicy Bypass -File scripts/cad-autocad-smoke.ps1 \
    -Desenho "..\Elet\Teste_prjeto_real\Funcional.dwg" -Dwg 63 -Comandos ELET \
    -Fixture scripts/cad-dump-xdata.lsp
```

### Comparação de **conteúdo** (não só de contagem) — `Portas4I`/`Bornes4I`

Contagem igual não é conteúdo igual, e a rodada 40 provou isso: `Bornes4I` tinha 216
linhas dos dois lados e **17 linhas diferentes**. A receita vale para qualquer tabela:
exportar as colunas escolhidas dos dois lados, normalizar e comparar os conjuntos.

```powershell
# lado do recoder (Python, UTF-8)
#   SELECT Regua, Borne, Pagina, bReserva FROM Bornes4I
# lado do produto (PowerShell + ODBC, gravando com [Text.Encoding]::UTF8)
#   SELECT ... FROM Bornes4I WHERE DWG=63 AND Revisao='00A-1'
# e a comparacao em Python, com duas normalizacoes obrigatorias:
#   * Bool: o Access devolve True/False, o SQLite devolve 1/0;
#   * Texto: o driver ODBC entrega os bytes UTF-8 lidos como CP1252
#     (BARRA FORÇA chega como BARRA FORÃ‡A) -> s.encode('cp1252').decode('utf-8').
```

Uma armadilha de harness que custou tempo: `Get-Content` sem `-Encoding` le um arquivo
UTF-8 como CP1252, o que reintroduz o mojibake no lado que estava certo. Leia os dois
lados com a mesma codificacao explicita (ou faca a comparacao inteira numa linguagem).

Resultado depois das normalizacoes:

| Tabela | recoder | produto | conteúdo |
|---|---|---|---|
| `Portas4I` | 265 | 265 | **hash igual** (`b8dc1259…`) |
| `Bornes4I` | 216 | 216 | **hash igual** (`f03c69df…`) |
| `Interligacao4` | 20 | 20 | **hash igual** (`ddf44e52…`) |

Ou seja: a projecao do **`INT` inteira** e igual ao produto, linha a linha. As tabelas do
`FIA` estao conferidas por **contagem** (e batem); a comparacao de conteudo delas e o
proximo passo natural.

### A pagina da reserva: o bug que so o conteudo pegaria

As 17 linhas diferentes eram todas de **reserva**, e a diferenca era uma coluna:
`Pagina`. O produto grava o rotulo **`RESERVA`** (2.645 linhas de reserva no banco, nas
duas tabelas, todas com `Tipo` 0 ou 1); o recoder gravava vazio.

A origem esta no `DicionarioBorne.LeDicBornesReserva` (linhas 253-261 do reverso): a
pagina da reserva vem da **tabela de mensagens** do produto —
`mMensagem[1, 1050]` para `tipo` 0/1 e `mMensagem[1, 1890]` para `tipo` 2, sempre em
maiusculas. Nenhum literal `"RESERVA"` existe no codigo descompilado (por isso a busca
por string nao achava nada) e a tabela de mensagens **nao** esta no `RCD.mdb`: o texto
so aparece no dado. `Tipo == 2` ficou vazio de proposito — nao ha reserva tipo 2 em
lugar nenhum no banco, entao o texto da mensagem 1890 nao e recuperavel; inventar seria
pior que faltar.

**E a linha de base do `VERIF` pegou o efeito colateral.** Com a pagina `RESERVA`
gravada, a regra `PaginaAusente` passou a acusar o rotulo como pagina fora da
`LayerTable`: o total foi de 238 para 239 (`PaginaAusente: 1`), o script acusou `NOVO` e
saiu 1. Correcao: a regra ignora as linhas de reserva (a reserva nao tem pagina de
desenho). Total de volta em **238**, linha de base conferindo — o ciclo completo
funcionando como projetado: o A/B acha a diferenca de dado, a linha de base protege as
regras de verificacao.

### Linha de base do `VERIF` (regressão do conjunto de regras)

O conjunto de regras do `VERIF` cresceu (são **seis** checagens do desenho além das de
tabela), e a única leitura rápida é o resumo por tipo. Para que uma rodada futura
perceba uma mudança **não intencional**, a contagem esperada no desenho real está
gravada em `scripts/verif-baseline.txt` e há um conferidor:

```powershell
# gera o relatorio (o ELETREL escreve em %TEMP%\positron-relatorio.txt)
npm run cad:smoke -- -Dwg 63 -Revisao R0 -Comandos ELETREL `
  -Desenho "..\Elet\Teste_prjeto_real\Funcional.dwg" -Banco "$env:TEMP\positron-idem.db"

# confere: sai 0 quando confere, 1 quando algum tipo mudou
python scripts/cad-verif-baseline.py $env:TEMP\positron-relatorio.txt
```

Saída de hoje:

```
  tipo                       agora   base
  BorneSemFiacao              107    107
  BorneSemLm                  119    119
  ReguaVazia                   10     10
  SobreposicaoAusente           2      2
linha de base confere
```

Regravar a base é deliberado (`--atualizar`) e deve vir junto da explicação da
diferença — o script marca cada tipo como `DIFERE` ou `NOVO`. Ele compara **contagens
por tipo**, não linhas: identificadores e ordem mudam entre rodadas, o número de
problemas de cada regra é que é o contrato.

### O `BorneSemFiacao` no A/B (o que os 107 querem dizer)

Vale registrar a diferença de **população** entre o que o `VERIF` conta e o que a
tabela mostra — foi fonte de confusão desde a rodada 13:

| | produto (rev 3) | recoder (R0) |
|---|---|---|
| bornes **não-reserva** em `Bornes4F` | 137 | 151 |
| … **com** ponto em `Fiacao` | **92** | **92** |
| … sem ponto | 45 | 59 |
| bornes **do desenho** sem ponto (a regra `BorneSemFiacao`) | — | **107** |

O que importa: os **92 bornes com fiação batem exatamente** — mesmo conjunto de handles
nos dois lados, embora a tabela do recoder tenha 14 bornes a mais (a cópia local do
desenho tem bornes que o produto não tinha, como os da página 1000). E os **107** do
`VERIF` não são os 59 da tabela: a regra compara os **bornes lidos do desenho** (199)
com os handles gravados em `Fiacao` (92), enquanto a tabela `Bornes4F` tem 168 linhas
(151 sem reserva). Mesma história, populações diferentes — os dois números estão certos.

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
  -Desenho "..\Elet\Teste_prjeto_real\Funcional.dwg" -Banco "$env:TEMP\positron-idem.db"

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

### Catalogo do produto → banco do projeto (e o snapshot de cabos/veias)

O catalogo (`Cabos`, `Veias`, `Materiais`, `ModelosCabos`) e o **cadastro de paineis**
(`Paineis`) vivem no Access do produto; o positron guarda os dois no SQLite.
`scripts/cad-importa-catalogo.ps1` (com o carregador `scripts/cad-importa-catalogo.py`)
le a **copia** do `.mdb`, casa as colunas **por nome**, converte `BOOL` para 0/1 e
recarrega as tabelas (a lista sai em `-Tabelas`):

```powershell
powershell -ExecutionPolicy Bypass -File scripts/cad-importa-catalogo.ps1 `
  -Banco "$env:TEMP\positron-idem.db" -Mdb "..\Elet\Teste_prjeto_real\RCD.mdb"
```

Rodar duas vezes da o mesmo resultado (697 cabos, 2.388 veias, 210 materiais, **480
paineis**; `ModelosCabos` esta vazia no Access e e pulada).

Com o cadastro carregado o **app funciona sobre o projeto real**:

| Consulta | Resultado |
|---|---|
| `projeto_listar_paineis` | **480** paineis, com nome (`04F6 TFO1`, `04J1/4RB1`, …) |
| `fiacao_por_painel(503)` | **490** fios (dos 494 da revisao — 4 sao de outro painel) |
| `interligacao_por_painel(503)` | 20 trechos |
| `circuitos_por_painel(503)` | **11** circuitos (o mesmo numero do A/B) |

E os **quatro** paineis que a projecao usa (`9`, `503`, `509`, `510`) estao todos no
cadastro do produto — o dado do desenho e o cadastro do projeto concordam.

Com o catalogo carregado, o `INT` passa a carimbar o **snapshot por revisao**
(`Cabos4`/`Veias4`), que antes saia 0 — e o resultado bate com o produto:

| Comparacao | Resultado |
|---|---|
| `INT` com catalogo carregado | **697 cabos** e **2.388 veias** em `Cabos4`/`Veias4` |
| `Veias4` do recoder x `Veias4` do produto (revisao `00A-4`) | **hash igual** (`5bb6de59…`), 2.388 linhas |
| `Cabos4` do recoder x **catalogo vivo** do produto (`Cabos`) | **hash igual** (`3073d268…`), 697 linhas |
| `Cabos4` do recoder x snapshot do produto (`00A-4`) | 25 de 697 linhas diferem — `Formacao` de cabos que o produto **editou depois** daquela revisao (o catalogo vivo e que confere) |

Ou seja: o `Cabos4` e mesmo um **retrato do catalogo corrente** (nao dos cabos usados no
desenho) — que era a regra lida no `RUIU5Sbjhj`, agora provada com dado real.

Efeito no `VERIF`: com o catalogo carregado a regra `CaboSemCatalogo` deixa de ser
pulada e **passa a rodar** — e continua limpa, porque os **18** `Tag_Cabo` que a
interligacao do `Funcional.dwg` cita (`8-CCE-001`…`8-GGE-018`) estao todos no catalogo
importado. O total segue **107 problemas, todos `BorneSemFiacao`**.

### A/B contra o banco do produto (`RCD.mdb`) — a verificação mais forte

O `..\Elet\Teste_prjeto_real\RCD.mdb` (19 MB, Access) é o banco **gerado pelo produto original**
para o mesmo projeto dos três DWGs. Ele abre por ODBC (driver 64-bit *Microsoft
Access Driver*) — sempre na **cópia** em `%TEMP%`, nunca no original:

```powershell
Copy-Item "..\Elet\Teste_prjeto_real\RCD.mdb" "$env:TEMP\positron-rcd.mdb" -Force
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
| `Interligacao4` | **20** (revisão `00A-1`) | **20** | ✅ (conteúdo idêntico — ver a nota das revisões) |

**Nota das revisões — por que uma comparação pode parecer vazia.** Os dois fluxos do
produto usam **ciclos de revisão diferentes**: a fiação usa `1`, `2`, `3`, `4`; a
interligação e o snapshot de cabos usam `00A-1`, `00A-4`, `CORR` (e as variantes
`0A-06`, `0B-00` em outros desenhos). Foi exatamente isso que fez a comparação da
rodada 26 concluir "`Interligacao4` = 0 para o DWG 63": a consulta era com a revisão
`3`, e as 20 linhas do produto para esse desenho estão sob `00A-1` e `CORR`. Com a
revisão certa, o conjunto `(Tag_Cabo, Num_Veia, Nome_Veia)` bate **hash a hash**
(`ddf44e52…`), 20 = 20. Antes de concluir que uma tabela não tem dado, confira **qual
ciclo de revisão** aquele fluxo usa.

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
   `J:\Eletrobras\...\RCD-8-GGE-04`, um caminho externo: os arquivos de `..\Elet\Teste_prjeto_real`
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

**A configuração geral também vai para o desenho, como no reverso.** O comando
`CFG`/`ELETCFG` do original **não grava no banco**: o `btSalvar` do
`frmConfiguracaoGeral` manda o `DeclaracoesGeral.Conf` para o **XData do ModelSpace**
(`XDataGeral.GravarXDataConfiguracao`: app `Eletron`, marcador `Config`, 41 valores;
e `GravarXDataConfiguracao2`: app `EletronProj`, marcador `Projeto`, as pastas), e o
`IniciarDWG` relê os dois ao abrir o desenho. O `ELETCFG` do recoder faz o mesmo: abre a tela com o que o XData do desenho tem e, no
**Salvar**, grava o `.ini` **e** o XData. A regra pura é o `ConfiguracaoDoCaderno` (o
layout, campo a campo, é um teste) e o I/O é o `ConfiguracaoDoDesenho` (junta os dois
apps num buffer só, sem apagar o XData de terceiros). Os campos que só o original usa
(`SCapa`, `Norma`, `DataSource`, `User`…) ficam **preservados** no round-trip.

**Os comandos também leem o desenho** (o `IniciarDWG` do reverso). A leitura dos
comandos/adapter é o `ConfiguracaoEfetiva.Carregar()` — `padrão < arquivo < desenho <
ambiente`, via `ConfiguracaoPositron.Carregar(arquivo, ambiente, desenho)`: o desenho
(o XData `Eletron`/`Config`) vence o arquivo e o ambiente `POSITRON_*` vence os dois (é
o caminho da automação). Sem desenho ativo, ou sem o XData, cai no arquivo — como
antes. O `Plugin.Escrever` (o caminho do `log`) segue no `ConfiguracaoPositron.Carregar()`
com cache, porque o `log` não é do desenho.

**`ELETCFG` é modal e não pode entrar em script**: ninguém clica em OK e o ZWCAD
fica parado. Por isso nenhum E2E o executa; a lógica testável está em
`ConfiguracaoPositron`, coberta por `ConfiguracaoPositronTests`.

### Editar os scripts `.ps1`

`scripts/build-sidecar.ps1` tem acentos e o PowerShell 5.1 **lê arquivo sem BOM
como ANSI** — o que transforma os acentos em lixo e quebra o parser com erros
que não apontam para o lugar certo (`cadeia de caracteres sem terminador`).
Salve sempre como **UTF-8 com BOM**.

## Estado de verificação

> **Nesta máquina, a partir da rodada 136, o host CAD é o AutoCAD 2020** (o `C:\Program Files\ZWSOFT`
> não existe aqui; o `cad:projeto:e2e` roda com `-Cad AutoCAD` e a API do AutoCAD está vendorizada em
> `cad-plugin/lib/AutoCAD/2020`). Os itens abaixo que falam do ZWCAD 2026 ficam como o registro da
> **máquina da rodada 58** — o estado vivo está no topo do `PLANO.md` e as receitas, nas seções
> "Rodar o plugin dentro de um CAD de verdade".

Para não passar a impressão de que tudo foi testado do mesmo jeito:

**Executado e verificado nesta máquina (Windows, Python 3.12, Node 24, .NET SDK 8):**

- `pytest` — 27 testes passando, com DEALER/ROUTER e SUB/PUB reais e leitura do
  SQLite do projeto.
- `npm run plugin:build` — 0 erros/0 avisos **contra a API real do ZWCAD 2026**
  (`ZWCadDir` auto-detectada). `npm run plugin:build:autocad` cai no **stub**, porque
  não há AutoCAD aqui, e é o gate de compilação daquela plataforma.
- `npm run plugin:test` — 514 testes xunit (net472) do plugin CAD.
- `npm run cad:smoke` / `cad:e2e` — smoke e fixture **dentro do ZWCAD 2026**, o host
  CAD desta máquina.
- `npm run cad:projeto -- -Idempotencia` — o ciclo completo no projeto real
  (`..\Elet\Teste_prjeto_real`) pelo ZWCAD 2026: mesma projeção, mesma linha de base
  (249) e `IDEMPOTENTE`.
- `python -m sidecar` ponta a ponta: handshake em stdout, `ping` por DEALER,
  `heartbeat` recebido no SUB, `GET /health` e `POST /rpc/echo` respondendo.
- `npm run protocol:gen` — passa, e falha com exit 1 quando o contrato diverge
  (testado injetando um método só no TS).
- `npm run typecheck` — `tsc --noEmit` limpo nos dois workspaces.
- `npm run build` — gera `apps/web/dist` (57 módulos).
- `ruff check .` no sidecar — limpo.
- **No alvo ZWCAD 2026 desta máquina, com um desenho real** —
  `-Desenho ..\Elet\Teste_prjeto_real\Funcional.dwg`:
  `FIA` grava 494 linhas (199 bornes, 191 dispositivos), `INT` 20 trechos, o
  `SYNCD` repete sem duplicar e as tabelas derivadas (portas, contatos,
  dispositivos, circuitos, aplicações) saem preenchidas. Foi esta rodada que achou
  o `FormatException` do `ReguasModelo` (ver armadilha abaixo).
- **No alvo ZWCAD 2026, com dados sintéticos** — `npm run cad:e2e` (fixture `scripts/cad-fixture.lsp`):
  `FIA` grava 2 linhas em `Fiacao` + 2 circuitos, `INT` grava 1 `Interligacao4`, o
  `SYNCD` repete e **não duplica** (idempotência no CAD) e o sidecar lê as mesmas
  linhas do `.db`.
- **No alvo ZWCAD 2026** — `npm run cad:smoke` carrega a DLL por `NETLOAD` e roda
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
- **AutoCAD** — esta linha **estava errada** (é da rodada 130, quando o código caiu
  no stub `Positron.CadStub`). **Medido em 2026-10-16** (registro + pastas +
  `where`): o **AutoCAD 2020 está instalado** em `C:\Program Files\Autodesk\AutoCAD
  2020`, o alvo compila contra a **API real** (`cad-plugin/lib/AutoCAD/2020`) e o
  plugin **é carregado** por `NETLOAD` no `accoreconsole` — é o host das medições das
  rodadas 212–214 (`scripts/cad-autocad-smoke.ps1`). Antes de repetir a ausência,
  meça (→ *Existe CAD nesta máquina?*).
- `npm run sidecar:build` (PyInstaller) — não executado aqui.

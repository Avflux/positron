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

### AutoCAD 2020 (evidência histórica — **não** instalado nesta máquina)

> **Histórico.** Esta seção foi escrita numa máquina que tinha o **AutoCAD 2020**
> (`C:\Program Files\Autodesk\AutoCAD 2020`) e **não** tinha ZWCAD; os números
> ficam registrados como estão. Nesta máquina o `C:\Program Files\Autodesk` não
> existe e o host CAD verificado é o **ZWCAD 2026** (seção acima).

O `accoreconsole.exe` roda o plugin **headless** e o harness
`scripts/cad-autocad-smoke.ps1` faz o ciclo inteiro (confere o AutoCAD, cria o `.db`
pelo `schema.sql`, escreve o `.scr`, roda e imprime o `POSITRON_LOG`):

```bash
npm run plugin:build:autocad                 # DLL contra a API real (auto-detecta 2020..2026)
npm run cad:smoke:acad                        # carrega a DLL num desenho vazio (ELET)
npm run cad:e2e:acad                          # fixture sintética (scripts/cad-fixture.lsp)
npm run cad:projeto:acad -- -Idempotencia     # projeto real + catálogo + app + baseline
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
  repassado certo.

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

1. **Compile contra a API real.** Sem `AutoCadDir` o `csproj` procura
   AutoCAD 2026…2020; numa máquina com outra versão (ou fora do `Program Files`),
   passe o caminho:

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
do `RCD.mdb` → **`INT` de novo** → consultas do app → linha de base do `VERIF` →
idempotência. Tudo com os caminhos do projeto por padrão (`-Desenho`, `-Mdb`, `-Dwg 63`,
`-Revisao R0`).

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
linha de base confere (249 = 107 + 119 + 11 + 10 + 2)
IDEMPOTENTE: mesmo conteudo (ignorando Data)
```

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

**Executado e verificado nesta máquina (Windows, Python 3.12, Node 24, .NET SDK 8):**

- `pytest` — 27 testes passando, com DEALER/ROUTER e SUB/PUB reais e leitura do
  SQLite do projeto.
- `npm run plugin:build` — 0 erros/0 avisos **contra a API real do ZWCAD 2026**
  (`ZWCadDir` auto-detectada). `npm run plugin:build:autocad` cai no **stub**, porque
  não há AutoCAD aqui, e é o gate de compilação daquela plataforma.
- `npm run plugin:test` — 279 testes xunit (net472) do plugin CAD.
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
- **AutoCAD** — não está instalado nesta máquina; o alvo AutoCAD compila contra o
  stub (`Positron.CadStub`) e não foi carregado por `NETLOAD` aqui. As execuções no
  AutoCAD 2020 do `RUNBOOK` são **evidência histórica** da máquina que o tinha.
- `npm run sidecar:build` (PyInstaller) — não executado aqui.

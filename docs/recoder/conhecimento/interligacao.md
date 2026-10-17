# Interligação (`INTERLIGACAO`) — veias indefinidas

Caminhos relativos a `cad-plugin/reverso/Eletron4_ZWcad/decompiled-cleaned/Eletron4/`.
Layout do XData: `InterligacaoXData` (`cad-plugin/Positron.Data/Interligacao/`).

## Veia indefinida

`NumVeia == -1000`. Duas rotinas carregam as veias indefinidas do desenho, com regras parecidas
mas **não iguais** (rodada 177):

| | `carregaApenasAsVeiasIndefinidasDoCaderno` | `carregaTodasAsVeiasIndefinidasDoCaderno` (`clsEditarInterligacao.cs:950`) |
|---|---|---|
| quem usa | `ESTVL` (`EstimativaDeVeiasLivres`) | `PESQC` (`VeiasIndefinidasDoCaderno`) |
| filtro | fora: `Painel1 == 0 && Painel2 > 0 && Tipo != 3` | o mesmo |
| tipo 3 só com painel 2 | — | painel 2 vai para o painel 1 (`:1093`) |
| tipo 2 sem painel 1 | painel 1 = `Painel2` da apontada | o mesmo **e** o handle da veia passa a ser o da apontada (`:1113`) |
| tipo 2 sem painel 2 | painel 2 = `Painel2` da apontada | o mesmo |
| ordem | painel 1 desc., painel 2 asc. | bubble sort de três trocas em sequência: página em decimal; mesma página (texto, sem caixa) → Y maior antes; mesmo Y → X menor antes (`:1144`) |

- A "apontada" é a polyline do `ilig.handle` (`Geral.HandleToObject`), lida com qualquer `NumVeia`.
- X/Y = `Bounds.MinPoint` arredondado (`Math.Round`, par mais próximo).
- O primeiro laço da rotina (`:1007`) monta um array (`GjFnBTpYJ2jOTH3qRap`) que **nunca é usado**.
- `1` e `001` têm o mesmo decimal mas não são "a mesma página" para o desempate por Y/X.

## A tela `frmPesquisaVeiasIndefinidas` (`PESQC`)

- Construtor (`frmPesquisaVeiasIndefinidas.cs:163`): o `Geral.ExisteForm` procura
  `"frmPesquisaVeiasIndefinidas "` **com espaço no fim** — nunca acha, a tela abre de novo a cada
  `PESQC`. Sem arquivo cadastrado (`arqAtivo.Indice == 0`; no recoder, `ConfiguracaoPositron.Dwg == 0`): mMensagem 331
  `Este arquivo ainda não foi cadastrado no banco do projeto!`. Título = mMensagem 568.
- Grade (`:201`): `#` (1..n), página, `BuscaNomeDoPainel(menor)`, `BuscaNomeDoPainel(maior)`, handle
  oculto; `"???"` vira `" "`. Larguras 10/30/30/30% de `Width - 4` (ou `- 21` com barra vertical).
- `KeyUp`/`MouseUp` da grade → `wkpp6H6CivH` (`:279`): `clsBlocos.Unhighlight` (tira o realce das
  entidades do layer da página ativa, `clsBlocos.cs:1952`), `SetFocus` no desenho e, para a linha
  selecionada, `clsInterligacao.AtivaUmaHighlightZoom` (`clsInterligacao.cs:3682`): `AtivaPagina(layer)`,
  atalho da paleta, `Caderno.ZEntity(id, 20)` e `Highlight()`.
- Apelidos: `wkpp6H6CivH` = ir até a veia selecionada; `Otfp6h0f11R` = `Resize` → `AtualizaDGVeiasDWG`;
  `haG8HN1M755FJ2bc2NW.ARP1IVj2So` = a grade tem barra vertical visível.

## A tela `frmPesquisaCabos` (`PESQCAB`) — o catálogo `Veias` (rodada 178)

Lê o **banco**, não o desenho. Recoder: `PesquisaDeCabos` (`Positron.Data/Interligacao/`).

- Cabos do caderno: `SELECT DISTINCT(Tag) FROM Veias WHERE Arquivo=@arquivo ORDER BY Tag` e
  `List.Sort()` (`CDadosAccessInterligacao.cs:674`). Cabos de outros: `DISTINCT(Tag) ... WHERE Arquivo>0`
  menos os do caderno (`:791`). As veias de cada tag são lidas **de todos os arquivos**
  (`WHERE Tag=@tag ORDER BY Indice`).
- A grade de veias usa o `LeCabosVeiasTodos` (`:4319`). O `sCaderno` é o `DWG.Nome` do `Arquivo` da veia.
  Cabo deste caderno: página + handle (mesmo que a veia seja de outro DWG). Cabo de outro: `caderno-página`
  e sem handle.
- `ClsCabos.OrdenaVeias(dg, indice=4)` (`ClsCabos.cs:1208`): a veia 1 com `P` → pares (×2), com `T` →
  ternas (×3; o `T` vence se tiver os dois). `-99` → 0; `< -50` → `+50`; negativos → `-(n·k − 0,1)`; bubble sort
  crescente trocando as células como texto. Cores: col. 0 = 0/-99 → `LightBlue`; os outros alternam
  `LightGoldenrodYellow`/`LightGray` quando a 1ª letra muda (sem caixa) ou quando um dos dois nomes é número.
- Apelidos: `MI1pvipBDIv` = veias do cabo selecionado; `vp1pvC6nLi1` = ir até a veia (igual ao `wkpp6H6CivH`);
  `JBgaA5p5W7h1TRpQ5uHE` = (índice, nome) do DWG.
- `arqAtivo.Indice` no recoder = `ConfiguracaoPositron.Dwg` (`POSITRON_DWG`).

## A tela `frmEstatisticaDeCabos` (`ESTVCABOS`) — a estatística por formação/função/trajeto (rodada 217)

Lê o **banco**, não o desenho. Recoder: `EstatisticaDeCabos` (`Positron.Data/Interligacao/`) + a ligação
`LigacaoDoFrmEstatisticaDeCabos`.

- `CDadosAccessInterligacao.LeTodosOsCabosEmUso` (`CDadosAccessInterligacao.cs:266`): SQL
  `SELECT C.Tag, C.Formacao, C.Funcao, C.Comprimento, c.Trajeto, V.Tag, V.Uso FROM Cabos C, Veias V
  WHERE V.Uso=@bUso AND C.Tag=V.Tag` com `@bUso = true`. Só entra cabo com **alguma veia em uso**, **uma
  vez por tag** (a lista de tags já vistas); o comprimento guardado é o **do cabo**, não por veia.
- As três listas de valores (formação/função/trajeto) pulam valor nulo/vazio (`clsTextos.TiraDBNull`) e
  levam `Sort()` no fim (`:344-346`) — a ordem da grade.
- O comando é `new frmEstatisticaDeCabos()` direto (`Comandos.cs:955`): **sem** checagem de banco ou de DWG
  cadastrado antes de abrir.
- Construtor (`frmEstatisticaDeCabos.cs:352-411`): os três radios começam **desabilitados** e cada um só
  habilita se a lista dele tiver linha; título `mMensagem[1, 1756]` = "Estatística de Cabos Utilizados",
  trocado por `1757` ("Estatística de Cabos Utilizados por: ") + o nome do agrupamento ao escolher o radio.
- Colunas do `formataDGCabos` (`:418`): `"# " + 514` ("# Cabos"), o agrupamento (`1285` Formação,
  `1244` Função, `1248` Trajeto) e `1246` (Comprimento). Larguras do `qnPkkbgPBU` (`:452`): 90 px fixos na
  coluna 0 e o resto em **70%/30%** (descontada a barra vertical, quando visível —
  `haG8HN1M755FJ2bc2NW.ARP1IVj2So`); `MultiSelect = true`, nenhuma coluna oculta.
- A conta do `Hpgk6bJ1Ce` (`:473-600`): por valor do agrupamento, soma 1 na quantidade e o comprimento;
  a linha nasce no primeiro cabo do grupo e **só se o valor não for vazio**. Comparação **sem caixa**
  (`CompareString`, `TextCompare: true`).
- `formataDGCabos` engole exceção (`catch` vazio); o comprimento sai **cru** na grade (`Conversions.ToString`).
- Apelidos: `OlbkdikPqi` = troca de agrupamento (título + `ikdkQu3CIi`), `Hpgk6bJ1Ce` = grade + conta,
  `qnPkkbgPBU` = larguras, `BnnktwdI2n` = `Resize`, `poxkjhv2fW` = `btExportaEXCEL` →
  `Relatorios_EstatisticaCaboEXCEL.ExportaEstatisticaExcel(dg, ikdkQu3CIi)`.

## O Excel ativo do `frmEstatisticaDeCabos` (rodada 218)

O `btExportaEXCEL` (`frmEstatisticaDeCabos.cs:604-607`, apelido `poxkjhv2fW`) chama
`Relatorios_EstatisticaCaboEXCEL.ExportaEstatisticaExcel(dg, itipo)` (`Relatorios_EstatisticaCaboEXCEL.cs:12-98`),
com o `itipo` = `ikdkQu3CIi` (0 Formação, 1 Função, 2 Trajeto — `frmEstatisticaDeCabos.cs:355/459/465`).
Recoder: `ExcelDaEstatisticaDeCabos` (`Positron.Data/Interligacao/`, regra pura) + `ExcelAtivoDaEstatisticaDeCabos`
(adapter) + `ExcelDoReverso` (as folhas COM comuns às duas pontes).

- **A aba é NOMEADA, não a ativa.** Este caminho usa o `ExcFuncoesExcel.VerificaExcel`
  (`:36-165`) — o outro caminho do produto (`VerificaExcelAtivo`, `:122-162`) é o dos títulos, que
  trabalha na aba ativa. Quem não separar os dois reproduz a ponte errada.
- **Nome da aba:** `"DIF_"` + o grupo com `ç`→`c` e `ã`→`a` (`:31-32`), passado pelo `TrocaBarra`
  (`:886-944`), que troca o que não é `0-9A-Za-z` por `_` (mantendo `/ ? ! * @ # $ % & - ( ) espaço Ã É Ç`;
  `/` vira `|`), corta em **31** e **sobe para maiúsculas** (`:940-941`). Dá `DIF_FORMACAO`, `DIF_FUNCAO`,
  `DIF_TRAJETO`. Nome vazio vira `Plan1` (`:39-42`).
- **Achar ou criar:** procura a aba pelo nome **sem caixa** (`TextCompare: true`); se existe →
  `Activate` → `ApagaFigura` (`:796-846`, apaga as **imagens** da aba ativa) → `LimpaSheet`
  (`:530-536`, `A1:Z10000` apagadas, largura `A1:Z1` = 8,43, `ClearComments`) e devolve; se não existe →
  ativa a **primeira** aba, acrescenta a nova **depois da última** (`Workbook.Worksheets.Add` com o
  `After` = última) e a ativa. Quirk do caminho novo: com o cálculo em `Manual`, passa a `Automatic` e
  volta a `Manual` (`:150-157`).
- **Cálculo:** aqui é o `AtivaCalculOExcel` (`:417-448`, `Visible`/`ScreenUpdating`/`Calculation = Automatic`);
  o `DesativaCalculoExcel` (`:395-416`) é da ponte dos títulos. O `DesativaCalculoExcel` tem o quirk da
  versão `A_2025`/`A_2026`/`A_2027` (liga em vez de desligar).
- **Como o `ExcelAberto()` trata o Excel invisível:** conta o processo `EXCEL`, mas um Excel **invisível**
  conta como fechado e é **morto** (`process.Kill()`, `:374-394`); sem Excel, a instância vem do CLSID
  `00024500-0000-0000-C000-000000000046` (`:45-51`).
- **A planilha:** larguras `A1` 12, `B1` 40, `C1` 15; `A1` = `"'" + "#" + mMensagem[514]` = `'#Cabos`
  (**sem** o espaço que a grade usa — a grade é `"# " + 514` = `# Cabos`), `B1` = `"'" +` o grupo
  (1285 Formação, 1430 Função, 1248 Trajeto), `C1` = `"'" + 1246` = `'Comprimento`; negrito em `A1:C1` +
  `CriaLinhasInterna` (`:1001-1014`, `WrapText` e `Borders.LineStyle = 1`) + `CriaLinhasExterna`
  (`:946-963`, as quatro bordas com `Weight = 3`). Cada linha da planilha é **uma linha da grade** (nada
  é recalculado) com `"'"` na frente de cada valor.
- **Quirk da faixa vazia:** a faixa dos dados é `"A2:C" + num` com o `num` do laço, que **não** é
  incrementado quando a grade está vazia — sai `A2:C1`, o Excel **normaliza** e a borda cai em `A1:C2`
  (medido: `usadas=2x5`, `A2` vazio).
- **Literais que não são constantes do Excel:** `Weight = 3` volta como `-4138` (**xlMedium** — os
  válidos são 1 hairline, 2 thin, 4 thick) e `HorizontalAlignment = 3` volta como `-4108` (**centro**;
  o `4` do comprimento volta `-4152`, à direita). O recoder passa os mesmos literais, então o resultado
  é o mesmo do original neste Office.
- **Engole tudo:** o `catch` vazio do `ExportaEstatisticaExcel` (`:93-98`) — a falha do Excel não chega ao
  usuário (a casca do recoder reproduz).

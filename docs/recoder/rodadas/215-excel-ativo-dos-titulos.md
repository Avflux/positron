# Rodada 215 — Excel ativo: exportar/importar os títulos do `frmEditaTitulos`

**Data:** 2026-10-16 · **Commit:** `2edf4696` (código) + *(este)* (prova viva) · **Frente:** correção do básico, item 3 (paleta fiel) · **Situação:** ✅ completa (a prova viva saiu em 2026-10-16, depois de o dono ativar o Office — ver *Prova*)

## Alvo

Item 1 da fila do `ESTADO.md`, o recorte **Excel ativo** (`clsTextos.ExportaPaginas`/`ImportaTitulos`
chamados pelos itens **Exportar**/**Importar** do menu de contexto da tela `frmEditaTitulos`). Decisão
do dono nesta data: **fiel ao reverso** — a ponte é o Excel **aberto** (`Microsoft.Office.Interop.Excel`),
não um arquivo gerado por nós.

Nas rodadas 183/197 os dois itens ficaram **desabilitados com o motivo** ("a ponte Excel é um recorte
pendente"); esta rodada os liga.

## O que o reverso faz

Caminhos relativos a `cad-plugin/reverso/Eletron4_ZWcad/decompiled-cleaned/Eletron4/`.

- **Exportar** (`frmEditaTitulos.cs:875-888`): `ExcFuncoesExcel.VerificaExcelAtivo` → `DesativaCalculoExcel` →
  `clsTextos.ExportaPaginas` → `AtivaCalculOExcel`. **Importar** (`:890-917`): `dg.RowCount <= 0` sai fora,
  `VerificaExcelAtivo` → `DesativaCalculoExcel` → `ImportaTitulos` → `AtivaCalculOExcel` → aplica na grade.
- **`VerificaExcelAtivo` (`ExcFuncoesExcel.cs:122-162`)**: com o Excel aberto pega a instância ativa
  (livro e aba ativos, cria um livro se não houver); sem Excel, cria a instância pelo CLSID
  `00024500-0000-0000-C000-000000000046`, um livro novo, aba ativa, seleciona `A1`.
- **`DesativaCalculoExcel` (`:395-416`)**: desliga `ScreenUpdating` e põe `Calculation = Manual` —
  **exceto** quando a versão do CAD é `A_2025`/`A_2026`/`A_2027` (quirk: aí chama `AtivaCalculOExcel`).
- **`ExportaPaginas` (`clsTextos.cs:1059-1213`)**: `LimpaSheet` (`:530-536`), formatação `A1:G{n}` e
  `E2:G{n}`, cabeçalho com larguras (0 = escondida), uma linha por página com apóstrofo (texto), faixa com
  borda interna e cor 36 nas linhas alternadas.
- **`ImportaTitulos` (`clsTextos.cs:1214-1306`)**: lê a aba de 2 até a última linha da coluna A; `G` com mais
  de 20 caracteres é truncado e pintado com a mensagem 1927 (cor 3); monta uma entrada por título
  existente, a Unidade (5) e o Alternativo (6, só com o alternativo ligado).
- **Aplicação na grade (`frmEditaTitulos.cs:890-936`)**: casa página e índice sem caixa e escreve só o que
  muda. A importação **não grava no desenho**; quem grava é o Editar DWG.

## O que foi feito

| arquivo | o quê |
|---|---|
| `cad-plugin/Positron.Data/Paginas/ExcelDosTitulos.cs` | regra pura: plano de exportação, leitura de importação, aplicação na grade, ano/versão do CAD |
| `cad-plugin/Positron.Data/Interface/MensagensDoReverso.cs` | mensagem 1927 ("Máximo de 20 caracteres") |
| `cad-plugin/Positron.Data.Tests/ExcelDosTitulosTests.cs` | 15 testes da regra |
| `cad-plugin/Positron.Plugin/Interface/Excel/ExcelAtivoDosTitulos.cs` | adapter Interop (Excel ativo, cálculo, escrita, leitura, comentários) |
| `cad-plugin/Positron.Plugin/Interface/Telas/LigacaoDoFrmEditaTitulos.cs` | liga Exportar/Importar ao adapter e ao gancho `POSITRON_TITULOS_EXCEL` |
| `cad-plugin/Positron.Plugin/Positron.Plugin.csproj` | referência à PIA do Excel vendorizada |
| `scripts/prepare-excel-api.ps1` | copia a PIA do Office para `cad-plugin/lib/Excel` |
| `scripts/cad-fixture-titulo-importar.lsp` | fixture: troca o TextString do título 1 da página "6" antes do plugin carregar |

## Prova

- Testes da regra: **1042/1042** passam (inclui os 15 de `ExcelDosTitulosTests`). Rodados pelo runner xUnit
  de `%TEMP%\pz-test-runner` (o adapter do VSTest não carrega xunit neste projeto). Primeira rodada teve 46
  falhas só por `schema.sql` ausente no diretório do runner; copiado o arquivo, zero falhas.
- `npm run plugin:build:autocad`: 0 avisos, 0 erros.
- CAD (AutoCAD 2020, `accoreconsole`, desenho `Funcional.dwg` dwg 63): o plugin carrega e o `JANELA
  frmEditaTitulos` **não abriu**. Causa: `LIGACAO: "frmEditaTitulos" falhou — a licença para usar este
  aplicativo expirou.` A mensagem vem do **Office** desta máquina: a janela do Excel mostra "Falha na
  Ativação do Produto" e `Range.ClearContents` falha com o mesmo texto (a escrita de valor funciona).
  **Não há gate de licença no plugin** (`Comandos.cs:56`). A exportação usa `EntireRow.Delete`/`ClearContents`
  e falhava do mesmo jeito neste computador — **superado** pela prova viva abaixo (2026-10-16, Office ativado).

### Prova viva (2026-10-16, com o Office ativado pelo dono)

- **Antes de tudo, o ambiente:** o mesmo teste do diagnóstico passou — `Escrita: OK`, `ClearContents: OK`,
  `EntireRow.Delete: OK` (os dois últimos falhavam na medição original), Excel **16.0 build 14334**.
- **Exportar** (`POSITRON_JANELA=frmEditaTitulos`, `POSITRON_TITULOS_EXCEL=exportar`, `JANELA` no
  AutoCAD 2020 com um Excel visível aberto):

```text
EXCEL: 15 página(s) exportada(s) para a aba ativa do Excel (6 coluna(s) com título; 14 passo(s) na barra).
```

  e a **aba** (lida por COM depois) tem conteúdo de verdade — `$A$1:$G$16`, cabeçalho
  `Página | Título 1 | Título 2 | Título 3 | (vazia) | Unidade | Alternativo` e uma linha por página
  (L2 `2 | PNL-GGE | DIAGRAMA FUNCIONAL | ÍNDICE GERAL | | ÍNDICE |`, L3 `6 | …`, …).
- **Importar** (`POSITRON_TITULOS_EXCEL='importar;exportar'` com a fixture
  `scripts/cad-fixture-titulo-importar.lsp`, que troca o `TextString` do título 1 da página "6" para
  `TITULO1-MEDIDO-215` antes do plugin carregar):

```text
(dump da fixture)  TROCADO indice 1 -> TITULO1-MEDIDO-215
EXCEL: 75 entrada(s) lida(s) da aba ativa; 1 célula(s) da grade atualizada(s).
EXCEL: 15 página(s) exportada(s) para a aba ativa do Excel (6 coluna(s) com título; 14 passo(s) na barra).
```

  Uma **só** célula diferiu entre a grade e a aba depois de a fixture mexer no desenho — e a exportação
  que veio em seguida devolveu o valor da **aba** (a importação escreve na grade, não no desenho).
- **A convergência, que prova que a importação muda a grade:** com a aba contendo um valor que só existe
  nela (página 6, Título 1 = `TITULO1-DO-EXCEL-215`, posto por COM) e **sem** a fixture,
  `POSITRON_TITULOS_EXCEL='importar;importar;exportar'`:

```text
EXCEL: 75 entrada(s) lida(s) da aba ativa; 1 célula(s) da grade atualizada(s).
EXCEL: 75 entrada(s) lida(s) da aba ativa; 0 célula(s) da grade atualizada(s).
EXCEL: 15 página(s) exportada(s) para a aba ativa do Excel (6 coluna(s) com título; 14 passo(s) na barra).
```

  A **segunda** importação dá **0 células**: o estado da grade mudou na primeira (o valor do Excel entrou
  nela) e a comparação convergiu. Depois da exportação a aba mostra `6 | TITULO1-DO-EXCEL-215 | …` — o
  ciclo Excel → grade → Excel fechado.

**Não medido:** se a importação grava no desenho. Por código ela **não** grava (só as células da grade,
`LigacaoDoFrmEditaTitulos.Importar`), como o original; a conferência no desenho é do dono, ao clicar
**Editar DWG**.

## Falta

- [ ] Conferir no **desenho** o resultado de uma importação seguida do **Editar DWG** (a importação não
      grava; quem grava é o Editar DWG) — conferência do dono.
- [ ] Os demais botões/rotinas de Excel do produto (o `btExportaEXCEL` das estatísticas, por exemplo)
      continuam **sem** a ponte — vão para a fila (item 8).
- [ ] Repetir no **ZWCAD 2026** quando ele voltar a ser instalado (ausente nesta máquina em 2026-10-16).

## Conhecimento registrado

- A ponte com o Excel ativo (as duas direções, a convergência como prova, o `ExcelAberto()` que mata um
  Excel invisível e as colunas da aba) → `docs/recoder/conhecimento/paginas.md`.
- A receita da medição (Excel **visível** com livro, as duas sessões de `accoreconsole` e a convergência de
  duas importações) → `RUNBOOK.md` → *Troubleshooting*.
- A licença que bloqueia o comando vem do **Office**, não do Positron: "Este comando não está disponível
  porque a licença para usar este aplicativo expirou" aparece no `LIGACAO` quando o Excel COM recusa a
  operação. Diagnóstico: `Range('A1').ClearContents()` no Excel aberto — **resolvido em 2026-10-16** com a
  ativação do Office pelo dono.
- `dotnet test` (VSTest) não carrega o xunit neste projeto; usar o runner de console em `%TEMP%`, com o
  `bin` copiado para lá (a árvore do repo dá "Acesso negado").
- O runner xUnit procura `schema.sql` no próprio diretório: copiar `services/sidecar/src/sidecar/db/schema.sql`
  para o diretório do runner.


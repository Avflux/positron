# Rodada 215 — Excel ativo: exportar/importar os títulos do `frmEditaTitulos`

**Data:** 2026-10-16 · **Commit:** *(não commitado)* · **Frente:** correção do básico, item 3 (paleta fiel) · **Situação:** 🟡 código e testes prontos; prova viva no Excel **bloqueada pelo ambiente**

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
  e vai falhar do mesmo jeito neste computador.

## Falta

- [ ] Prova viva da exportação e da importação (sessão 1 `POSITRON_TITULOS_EXCEL=exportar`; sessão 2
      `importar;exportar` com a fixture) — **bloqueada** até o Office desta máquina ser ativado.
- [ ] Ativar o Office (ação do dono da máquina; não foi tentado contornar a ativação).
- [ ] Commit da rodada, após a prova viva ou com a limitação declarada.

## Conhecimento registrado

- A licença que bloqueia o comando vem do **Office**, não do Positron: "Este comando não está disponível
  porque a licença para usar este aplicativo expirou" aparece no `LIGACAO` quando o Excel COM recusa a
  operação. Diagnóstico: `Range('A1').ClearContents()` no Excel aberto.
- `dotnet test` (VSTest) não carrega o xunit neste projeto; usar o `pz-test-runner` em `%TEMP%`.
- O runner xUnit procura `schema.sql` no próprio diretório: copiar `services/sidecar/src/sidecar/db/schema.sql`
  para `bin/Debug/net472` do runner.

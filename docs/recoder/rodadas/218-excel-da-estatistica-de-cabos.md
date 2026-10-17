# Rodada 218 — `btExportaEXCEL` do `frmEstatisticaDeCabos`: a estatística para o Excel ativo (fila, item 8)

**Data:** 2026-10-16 · **Commit:** *(este)* · **Frente:** 7 — interligação, cabos e veias · **Situação:** ✅ completa

## Alvo

Item 8 da fila do `ESTADO.md` — a **ponte de Excel que ainda falta**, começando pelo botão que a rodada
217 deixou na tela sem ação: `btExportaEXCEL` do `frmEstatisticaDeCabos` (`ESTVCABOS`), que o original
liga ao `Relatorios_EstatisticaCaboEXCEL.ExportaEstatisticaExcel(dg, ikdkQu3CIi)`. O dono ativou o Office
desta máquina em 2026-10-16, então a **prova viva** (o Excel aberto recebendo a aba) é possível.

## O que o reverso faz

Caminhos relativos a `cad-plugin/reverso/Eletron4_ZWcad/decompiled-cleaned/Eletron4/`.

- **Entrada:** o `Click` do `btExportaEXCEL` (`frmEstatisticaDeCabos.cs:604-607`, apelido `poxkjhv2fW`)
  chama `Relatorios_EstatisticaCaboEXCEL.ExportaEstatisticaExcel(dg, ikdkQu3CIi)` — a **grade** e o
  **tipo** do agrupamento. O `ikdkQu3CIi` nasce `0` no construtor (`:355`, Formação) e os radios o levam
  a `1` (Função, `:465`) ou `2` (Trajeto, `:459`).
- **Nome da aba (`:18-32` + `ExcFuncoesExcel.cs:36-41,886-944`):** o texto vem da `mMensagem` do grupo
  (1285 Formação, 1430 Função, 1248 Trajeto); o export troca **só** `ç`→`c` e `ã`→`a` (`:31-32`),
  prefixa `"DIF_"` e o `VerificaExcel` passa o nome pelo `TrocaBarra`, que troca todo caractere fora de
  `0-9A-Za-z` por `_` (mantendo `/ ? ! * @ # $ % & - ( ) espaço Ã É Ç`; `/` vira `|`), **corta em 31** e
  **sobe para maiúsculas** (`:940-941`). Resultado: `DIF_FORMACAO`, `DIF_FUNCAO`, `DIF_TRAJETO` (o
  `Replace` do acento é redundante com o `TrocaBarra`, mas é o caminho real).
- **`VerificaExcel` (`ExcFuncoesExcel.cs:36-165`)** — o **outro** caminho de Excel do produto (o
  `VerificaExcelAtivo` é o dos títulos): com o nome vazio usa `Plan1`; sem Excel aberto cria a instância
  pelo CLSID `00024500-0000-0000-C000-000000000046` com um livro novo; com Excel aberto pega a instância
  ativa (cria livro se não houver) e desminimiza. Depois **procura a aba pelo nome** (comparação sem
  caixa): se existe → `Activate` → `ApagaFigura` (apaga as **imagens** da aba ativa, `:796-846`) →
  `LimpaSheet` (`:530-536`: apaga as linhas `A1:Z10000`, largura de `A1:Z1` = 8,43 e `ClearComments`) →
  `Visible = true` e **devolve** (a limpeza já foi feita); se não existe → ativa a primeira aba,
  acrescenta uma **no fim** do livro com esse nome e a ativa. Quirk do caminho novo: com o cálculo em
  `Manual`, passa a `Automatic`, volta a `Manual` e chama `DoEvents` (`:150-157`).
- **Cálculo (`:119`):** `AtivaCalculOExcel` (`ExcFuncoesExcel.cs:417-448`) — `Visible = true`,
  `ScreenUpdating = true`, `Calculation = Automatic` (o contrário do `DesativaCalculoExcel` que a ponte
  dos títulos usa).
- **Limpeza da exportação (`:33-34`):** apaga de novo as linhas `A1:Z10000` e `ClearComments` — a aba
  existente é limpa **duas** vezes (o `VerificaExcel` + aqui).
- **Cabeçalho (`:35-70`):** larguras `A1` = 12, `B1` = 40, `C1` = 15, as três com `VerticalAlignment = 2`
  e `HorizontalAlignment = 3`; `A1` = `"'#" + mMensagem[514]` → **`'#Cabos`** (a grade usa
  `"# " + 514` = `# Cabos` — o espaço **não** vai para o Excel), `B1` = `"'" +` o nome do agrupamento,
  `C1` = `"'" + 1246` = `'Comprimento`; negrito na faixa `A1:C1`, `CriaLinhasInterna(A1:C1)` (`WrapText` +
  `LineStyle = 1`) e `CriaLinhasExterna(A1:C1, completo)` (as quatro bordas com `Weight = 3`).
- **Linhas (`:71-88`):** uma por **linha da grade** (não recalcula nada): `A{2..}` = `"'" + célula 0` com
  `Vertical = 2`/`Horizontal = 3`, `B{2..}` = `"'" + célula 1`, `C{2..}` = `"'" + célula 2` com
  `Vertical = 2`/`Horizontal = 4`.
- **Fecho (`:89-92`):** `A2:C{última}` com `CriaLinhasInterna` + `CriaLinhasExterna(completo)` — com a
  grade vazia a última linha é `1` e a faixa sai **invertida** (`A2:C1`), que o Excel normaliza; e
  `A1.Select()` no fim.
- **Erro:** tudo dentro de um `try/catch` que **engole** a exceção (`:93-98`) — nenhuma mensagem ao
  usuário.
- **Grade:** o designer a deixa `ReadOnly = true` (`frmEstatisticaDeCabos.cs:254`), então a exportação
  escreve o que a conta montou; o `qnPkkbgPBU` reafirma `ReadOnly = false` **por coluna** (`:441`), que o
  `ReadOnly` da grade sobrepõe.
- **Mensagens:** 514 "Cabos", 1246 "Comprimento", 1248 "Trajeto", 1285 "Formação", 1430 "Função".
- **Tela:** nenhum ajuste novo — o botão já está no designer (492,209 40x42, ícone `ExportaExcel_20`, o
  mapa em `FormulariosDoReverso.Dados.cs:3748`) e o recoder não mexe na forma.

## O que foi feito

| arquivo | o quê |
|---|---|
| `cad-plugin/Positron.Data/Interligacao/ExcelDaEstatisticaDeCabos.cs` | regra pura: o nome da aba (`TrocaBarra`), as três colunas e o plano do que escrever (cabeçalho e linhas, já com o apóstrofo do original) |
| `cad-plugin/Positron.Plugin/Interface/Excel/ExcelDoReverso.cs` | as folhas COM que os dois caminhos do reverso compartilham (`ExcelAberto`, instância pelo CLSID/ativa, `AtivaCalculOExcel`/`DesativaCalculoExcel`, `Geral.CADVersion`, `Liberar`) |
| `cad-plugin/Positron.Plugin/Interface/Excel/ExcelAtivoDaEstatisticaDeCabos.cs` | adapter: o `VerificaExcel` com **aba nomeada** (`ApagaFigura` + `LimpaSheet`), o `AtivaCalculOExcel` e a escrita |
| `cad-plugin/Positron.Plugin/Interface/Excel/ExcelAtivoDosTitulos.cs` | passa a usar as folhas compartilhadas (nenhuma mudança de comportamento — remedido) |
| `cad-plugin/Positron.Plugin/Interface/Telas/LigacaoDoFrmEstatisticaDeCabos.cs` | liga o `btExportaEXCEL` (a ação que o `Click` dispara) e o gancho `POSITRON_ESTATISTICA_EXCEL=exportar` |
| `cad-plugin/Positron.Data.Tests/ExcelDaEstatisticaDeCabosTests.cs` | +8 métodos (12 casos) de teste |

Desvios do original (com motivo):

- **A linha de resumo na linha de comando/log** (`EXCEL: N linha(s) …`): o original não escreve nada. É o
  que a ponte dos títulos (rodada 215) já faz e é o que a medição lê; sem ela não há como provar a
  exportação num script.
- **Erro engolido também na casca:** no original o `catch` vazio está dentro do
  `ExportaEstatisticaExcel`; aqui a casca engole em volta — efeito para o usuário idêntico (nenhuma
  mensagem) e é onde um `Microsoft.Office.Interop.Excel` ausente estouraria.
- **`Liberar` dos objetos COM** (herdado da 215, agora nas folhas compartilhadas): o original não solta
  nada. Medido nesta rodada: depois de uma exportação que **criou** a instância do Excel (nenhum Excel
  aberto antes), o processo continua de pé e **visível** com a aba escrita — o efeito é o mesmo.
- **`ReadOnly` da grade:** o recoder deixa a grade `ReadOnly = true` (como o designer do original) e lê as
  células; a exportação é idêntica porque o `ReadOnly` da grade vence o `ReadOnly = false` por coluna.

## Prova

- `plugin:test`: **1068** (+12 casos de teste, 8 métodos) pelo console runner do xunit (o
  `npm run plugin:test` sai 0 sem rodar nada — o adaptador do VS não carrega; a suíte veio do `bin`
  copiado para o `%TEMP%`, como o RUNBOOK manda).
  `Total: 1068, Errors: 0, Failed: 0, Skipped: 0`.
- builds ZWCAD / AutoCAD: **0 avisos, 0 erros**.
- Cobertura: `com a ligacao na tela: 23` (não mudou — a rodada completou um botão de uma tela já ligada).
- **CAD: AutoCAD 2020** (`accoreconsole`, `Funcional.dwg`, banco `.tmp-smoke/r217-estcabos.db`) com um
  **Excel 16.0 visível** aberto. O comando é o da barra (`ESTVCABOS`, "Estatística de Cabos Utilizados")
  e a exportação sai pela **ação que o `Click` do `btExportaEXCEL` dispara**
  (`POSITRON_ESTATISTICA_EXCEL=exportar`; um script do CAD não clica — ver *Falta*).

```text
EXCEL: versao 16.0; livro Pasta1; abas=3
ANTES: aba=DIF_FORMACAO A1=LIXO DA ABA ANTIGA Z500=LIXO largura A=30 imagens=2 abas=3
ESTCABOS: Formação — 2 linha(s); habilitados: Formação, Função, Trajeto; grade: 2x4=1/4 | 3x2,5=2/15
EXCEL: 2 linha(s) da estatística de cabos na aba DIF_FORMACAO (Formação).
DEPOIS 1: A1=#Cabos B1=Formação C1=Comprimento Z500= imagens=0
DEPOIS 1: larguras=12/40/15 negrito A1=True usadas=3x3 em uso a partir de 1/1
DEPOIS 1: L2 = [1] [2x4] [4]
DEPOIS 1: L3 = [2] [3x2,5] [15]
DEPOIS 1: bordas internas A1:C1= topo=-4138 chao dos dados=2 alinhamento A2=-4108/-4108 C2=-4152
ESTCABOS: Trajeto — 2 linha(s); habilitados: Formação, Função, Trajeto; grade: BANDEJA A=2/15 | T1=2/13
EXCEL: 2 linha(s) da estatística de cabos na aba DIF_TRAJETO (Trajeto).
DEPOIS 2: abas=Planilha1,DIF_FORMACAO,DIF_TRAJETO (total 3)
DEPOIS 2: A1=#Cabos B1=Trajeto C1=Comprimento
DEPOIS 2: L2 = [2] [BANDEJA A] [15]
DEPOIS 2: L3 = [2] [T1] [13]
DEPOIS 3: abas antes=3 depois=3
```

  Confere com o original, item por item: a aba **existente** foi achada (`DIF_FORMACAO`), o lixo da aba
  anterior (`Z500`, largura 30 e as 500 linhas usadas) **saiu** (`usadas=3x3` a partir de `1/1`), as
  **duas imagens** que estavam nela foram apagadas (`imagens=0`, o `ApagaFigura`), as larguras são
  12/40/15, o cabeçalho está em negrito e os valores são os da grade da 217 (`2x4=1/4 | 3x2,5=2/15` e
  `BANDEJA A=2/15 | T1=2/13`); a aba nova (`DIF_TRAJETO`) foi criada **depois da última** (`Planilha1,
  DIF_FORMACAO, DIF_TRAJETO`), e a terceira sessão **não** criou aba nova (`antes=3 depois=3`).
- **Grade vazia** (`r217-estcabos-semtrajeto.db`, o mesmo caminho):

```text
ESTCABOS: Trajeto — 0 linha(s); habilitados: Formação, Função; grade:
EXCEL: 0 linha(s) da estatística de cabos na aba DIF_TRAJETO (Trajeto) — a grade está vazia.
DEPOIS: usadas=2x5 A1=#Cabos B1=Trajeto C1=Comprimento A2= larguras=12/40/15 topoA1C1=-4138 chaoA2C1=-4138
```

  O quirk medido: com zero linhas a faixa sai `A2:C1`, o Excel a **normaliza** e a borda acaba na faixa
  `A1:C2` — o `A2` continua vazio e o "chão" da tabela sai na linha 2 (`chaoA2C1=-4138`, o mesmo `Weight`
  do topo). É o comportamento do original com a grade vazia.
- **Excel fechado** (nenhum processo `EXCEL` antes — medido: `processos EXCEL=0 ativo=False`):

```text
EXCEL: 2 linha(s) da estatística de cabos na aba DIF_FORMACAO (Formação).
DEPOIS: processos EXCEL=1
DEPOIS: visivel=True abas=2
DEPOIS: abas=Planilha1,DIF_FORMACAO
DEPOIS: DIF_FORMACAO A1=#Cabos B1=Formação C1=Comprimento L2=[1][2x4][4]
```

  A instância criada pelo CLSID, o livro novo com a aba acrescentada **no fim** (`Planilha1,
  DIF_FORMACAO`) e a instância **continua aberta e visível** depois da exportação (o `Liberar` não fecha
  o Excel do usuário).
- **Regressão da ponte dos títulos** (o `ExcelAtivoDosTitulos` passou a usar `ExcelDoReverso`), no mesmo
  Excel: `POSITRON_JANELA=frmEditaTitulos`, `POSITRON_TITULOS_EXCEL=exportar` →
  `EXCEL: 15 página(s) exportada(s) para a aba ativa do Excel (6 coluna(s) com título; 14 passo(s) na barra).`
  — igual à rodada 215.
- **Não medido:** o **clique físico** no `btExportaEXCEL` com a janela visível (o harness roda a mesma
  ação; a ligação roda ainda montando a tela, quando o `PerformClick` não dispara). **ZWCAD 2026:**
  ausente nesta máquina (medição de 2026-10-16, `RUNBOOK.md` → *Existe CAD nesta máquina?*).

## Falta

- [ ] **Clique físico** no `btExportaEXCEL` (janela visível no AutoCAD e no ZWCAD quando voltar) — dono;
      o harness roda a mesma ação, não o botão.
- [ ] Conferência **visual** da janela contra `estimativa de cabos utilizados por formação.png` — segue
      como item da rodada 217.
- [ ] Os **demais botões de Excel do produto** (item 8 da fila): o `ExcFuncoesExcel` ainda tem os caminhos
      das outras telas de relatório/estatística (as 19 sub-janelas de exportação DWG/Excel).
- [ ] O **`Weight = 3`** das `CriaLinhasExterna` e o `HorizontalAlignment = 3` não são constantes válidas
      do Excel; o Excel 16.0 desta máquina devolveu `-4138` (médio) e `-4108` (centro). Os dois lados
      passam os mesmos literais, então a tela sai igual — conferir na GUI com o Excel do dono se o
      resultado visual é o que ele espera (o `4` do comprimento vira `-4152`, à direita).

## Conhecimento registrado

`docs/recoder/conhecimento/interligacao.md` — o `ExportaEstatisticaCaboEXCEL` (nome da aba, `apóstrofo`,
as larguras e os literais de alinhamento/borda que o Excel normaliza), o `VerificaExcel` (aba nomeada ×
aba ativa) e as `mMensagem` 514/1246/1248/1285/1430. `docs/RUNBOOK.md` — a receita de medição da
estatística com o Excel aberto (o mesmo cuidado do Excel visível da 215) e os literais que o Excel
normaliza.

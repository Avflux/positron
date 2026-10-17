# Rodada 217 — `frmEstatisticaDeCabos` (`ESTVCABOS`): a estatística de cabos por formação, função ou trajeto (fila, item 3)

**Data:** 2026-10-16 · **Commit:** *(este)* · **Frente:** 7 — interligação, cabos e veias · **Situação:** ✅ completa

## Alvo

Item 3 da fila do `ESTADO.md`: as **telas só-casca mais baratas** cuja regra cabe numa rodada, começando
pela `frmEstatisticaDeCabos` (`ESTVCABOS`). O dono pediu o AutoCAD instalado para testar e avisou que o
Excel desta máquina foi ativado (o teste do Excel ativo ficou para a fila — ver *Falta*).

## O que o reverso faz

Caminhos relativos a `cad-plugin/reverso/Eletron4_ZWcad/decompiled-cleaned/Eletron4/`.

- **Entrada:** `ESTVCABOS` → `new frmEstatisticaDeCabos()` (`Comandos.cs:955`). Sem checagem de banco nem
  de DWG antes de abrir (o comando é a chamada direta).
- **Carga (construtor, `frmEstatisticaDeCabos.cs:352-411`):** `CDadosAccessInterligacao` (o banco pelo
  `DeclaracoesGeral.Conf.Banco` — `A`cesso/`S`QLite/`SV` SQL Server, `:17-38`) e
  `LeTodosOsCabosEmUso(ref aaok8Enuht /*função*/, ref Si4kaqKOpu /*formação*/, ref s3BkNESafw /*trajeto*/,
  ref mEstat)` (`CDadosAccessInterligacao.cs:266`):
  - SQL: `SELECT C.Tag, C.Formacao, C.Funcao, C.Comprimento, c.Trajeto, V.Tag, V.Uso FROM Cabos C, Veias V
    WHERE V.Uso=@bUso AND C.Tag=V.Tag` com `@bUso = true`;
  - **um cabo por tag** (a lista `list.Contains` de tags já vistas), com o comprimento do cabos;
  - cada lista de valores recebe o valor do cabo quando não é nulo/vazio
    (`clsTextos.TiraDBNull`), e no fim leva `Sort()` (`:344-346`).
- **Habilitação dos radios (`:381-397`):** `RBFormacao`/`RBFuncao`/`RBTrajeto` começam **desabilitados** e
  cada um só habilita se a lista dele tiver linha.
- **Título e colunas (`:400, :418-450`):** `mMensagem[1, 1756]` = "Estatística de Cabos Utilizados";
  ao escolher um radio, o título vira `1757` ("Estatística de Cabos Utilizados por: ") + o nome do
  agrupamento (`1285` Formação, `1430` Função, `1248` Trajeto). Colunas: `"# " + 514` ("# Cabos"), o
  agrupamento (`1285`/`1244` Função/`1248` Trajeto) e `1246` (Comprimento).
- **A conta (`Hpgk6bJ1Ce`, `:473-600`):** para cada valor da lista do agrupamento, percorre os
  `mEstat` com aquele valor e soma `1` na quantidade e `Comprimento` no comprimento; a linha só nasce no
  primeiro cabo do grupo, e **só se o valor do grupo não for vazio** (`clsTextos.TiraNothing(...) != ""`).
  A comparação não diferencia maiúsculas (`CompareString`, `TextCompare: true`).
- **Larguras (`qnPkkbgPBU`, `:452-471`):** a coluna 0 com 90 px fixos; a largura restante (descontando a
  barra vertical pelo `haG8HN1M755FJ2bc2NW.ARP1IVj2So`) dividida em **70%/30%** entre a coluna do
  agrupamento e o comprimento; `MultiSelect = true` e nenhuma coluna oculta (a grade é a do designer:
  `ReadOnly`, `FullRowSelect`, `AllowUserToOrderColumns`, 520 x 191, `Anchor` nos quatro lados).
- **Erro:** o `formataDGCabos` engole qualquer exceção (`catch` vazio, `:444-449`).
- **Apelidos:** `OlbkdikPqi` = troca de agrupamento (título + `ikdkQu3CIi` = o índice do agrupamento);
  `iVPkfDw7tn`/`yXokDfunLa`/`mTukviDQZB` = os `CheckedChanged` dos três radios; `Hpgk6bJ1Ce` = a grade +
  a conta; `qnPkkbgPBU` = larguras/visibilidade; `BnnktwdI2n` = `Resize` (só reajusta as colunas);
  `poxkjhv2fW` = o `Click` do `btExportaEXCEL` → `Relatorios_EstatisticaCaboEXCEL.ExportaEstatisticaExcel(dg, ikdkQu3CIi)`.
- **Tela:** captura `estimativa de cabos utilizados por formação.png` (`docs/reverso-capturas.txt:91`);
  designer: grade `dg` (12,12 520x191), `GroupBox18` (12,209 474x42) com os três radios em
  (6,17)/(189,17)/(361,17) e o `btExportaEXCEL` (492,209 40x42, ícone `ExportaExcel_20`), `ClientSize`
  544x261, `MinimumSize` 560x300, `Text` "_Estatisticas de Cabos por" (o designer; o construtor troca por
  `mMensagem[1, 1756]`). **Não** havia ajuste anterior desta janela (nenhuma rodada a citava); o mapa
  `FormulariosDoReverso.Dados.cs:3736` já traz os campos do designer, e o recoder **não** mexe na forma.
- **Quirk mantido:** o original mostra o **comprimento cru** (`Conversions.ToString(Comprimento)`, sem
  formato nem unidade) e o total é a soma dos comprimentos dos cabos, **não** do comprimento por veia
  (um cabo com 3 veias em uso conta **uma** vez).

## O que foi feito

| arquivo | o quê |
|---|---|
| `cad-plugin/Positron.Data/Interligacao/EstatisticaDeCabos.cs` | regra pura: `AgrupamentoDeCabos`, `LinhaEstatisticaCabos` e `Calcular(cabos, veias, agrupamento)` |
| `cad-plugin/Positron.Data.Tests/EstatisticaDeCabosTests.cs` | +7 testes (só o cabo com veia em uso, um por tag, soma por grupo, grupo vazio fora, os três agrupamentos, sem caixa e banco sem uso) |
| `cad-plugin/Positron.Plugin/Interface/Telas/LigacaoDoFrmEstatisticaDeCabos.cs` | casca: lê `Cabos`/`Veias` do banco do projeto, habilita os radios, liga os `CheckedChanged`, monta a grade e as larguras 90/70%/30%; gancho `POSITRON_ESTATISTICA` |
| `cad-plugin/Positron.Plugin/Interface/Telas/LigacoesDasTelas.cs` | registra a ligação |

Desvios do original (com motivo):

- **Fonte dos dados:** o original lê o banco do `Conf.Banco` (Access/SQLite/SQL Server); o recoder lê o
  SQLite do projeto (`ProjectStore.LerCabos` + `LerVeias`), que é o que existe hoje (item 1a da fila,
  decisão do dono). A consulta é a mesma — só entram cabos com `Uso = true`, um por tag.
- **Ordenação das listas:** o `List.Sort()` do VB (comparação de cultura, sem caixa) é
  `StringComparer.CurrentCulture` aqui; a comparação de igualdade é sem caixa, como o `CompareString`.
- **Sem banco legível a tela abre vazia** (o original estouraria no construtor, sem `MsgBox`): não há
  mensagem ao usuário em nenhum dos dois casos porque o original não tem.
- **`btExportaEXCEL` não ligado:** a exportação (`Relatorios_EstatisticaCaboEXCEL`) ainda não foi portada.
  O botão fica como o designer o deixa, sem ação — vai para a fila.

## Prova

- `plugin:test`: **1056** (+7) pelo console runner do xunit (o `npm run plugin:test` sai 0 sem rodar nada —
  o adaptador do VS não carrega; a suíte veio do `bin` copiado para o `%TEMP%`, como o RUNBOOK manda).
  `Total: 1056, Errors: 0, Failed: 0, Skipped: 0`.
- builds ZWCAD / AutoCAD: **0 avisos, 0 erros**.
- CAD: **AutoCAD 2020** (`scripts/cad-autocad-smoke.ps1`, `Funcional.dwg`, banco `.tmp-smoke/r217-estcabos.db`
  com C1/C2 `3x2,5`, C3 `2x4`, C4 formação vazia, C5 **sem** veia em uso). O comando é o da barra
  ("Estatística de Cabos Utilizados" → `ESTVCABOS`), ou seja, o caminho do usuário:

```text
ESTCABOS: Formação — 2 linha(s); habilitados: Formação, Função, Trajeto; grade: 2x4=1/4 | 3x2,5=2/15
ESTCABOS: Função   — 2 linha(s); habilitados: Formação, Função, Trajeto; grade: ALIM=3/23 | COMANDO=1/5
ESTCABOS: Trajeto  — 2 linha(s); habilitados: Formação, Função, Trajeto; grade: BANDEJA A=2/15 | T1=2/13
ESTCABOS: Trajeto  — 0 linha(s); habilitados: Formação, Função; grade:            (todos os trajetos vazios)
```

  Confere com o original: o **C5** (sem veia em uso) e o **C4** (formação vazia) ficam fora; `3x2,5` = 2
  cabos / 10+5 = 15; `ALIM` = 3 cabos (C1+C3+C4) / 10+4+9 = 23; `T1` = 2 (C3+C4) / 4+9 = 13. Com o
  trajeto vazio em todos, a grade fica sem linha e o radio **Trajeto** desabilita (a regra
  `s3BkNESafw.Count > 0`).
- Casco e ligações (`pzTelas` no mesmo AutoCAD): `JANELAS: 127 de 127 tela(s) do reverso montada(s),
  nenhuma falha. Ligacoes: 23 de 127 tela(s) com regra (… frmEstatisticaDeCabos …)` — a guarda de nome
  órfão não acusou nada.
- `scripts/cobertura-do-reverso.ps1`: `com a ligacao na tela: 23` (era 22).
- **Não medido nesta rodada:** a conferência **visual** da janela contra a captura
  (`estimativa de cabos utilizados por formação.png`) — no `accoreconsole` o `JANELA` não retorna e a
  captura de WinForms headless não comprova tela visível (RUNBOOK); fica como conferência do dono.
  **ZWCAD 2026:** ausente nesta máquina (medição de 2026-10-16, ver `RUNBOOK.md` → *Existe CAD nesta máquina?*).

## Falta

- [ ] **Exportar para Excel** (`btExportaEXCEL` → `Relatorios_EstatisticaCaboEXCEL.ExportaEstatisticaExcel(dg, ikdkQu3CIi)`):
      não portado; o botão está na tela sem ação. (O Excel desta máquina foi ativado em 2026-10-16, então a
      prova viva é possível a partir de agora.)
- [ ] Conferência **visual** da janela contra `estimativa de cabos utilizados por formação.png` no AutoCAD
      com interface (o headless não prova tela visível) — dono.
- [ ] Medir no **ZWCAD 2026**, se ele voltar a ser instalado.
- [ ] O **formato do comprimento** na grade: o original imprime o `Double` cru; a grade do recoder usa
      `ToString()` da cultura corrente (a mesma coisa que o `Conversions.ToString` do VB) — conferir na GUI
      se o separador decimal sai igual ao do original em uso real.

## Conhecimento registrado

`docs/recoder/conhecimento/interligacao.md` — o `LeTodosOsCabosEmUso` (a consulta `Cabos × Veias` com
`Uso = true`), a regra do `Hpgk6bJ1Ce` (um cabo por tag, valor de grupo vazio fora, soma do comprimento
**do cabo**) e as `mMensagem` 514/1246/1248/1285/1430/1756/1757.

Nenhuma armadilha nova de operação: o `JANELA` que não retorna no `accoreconsole` e a cópia do `bin` para
o `%TEMP%` (runner do xunit) já estavam no *Troubleshooting* do `RUNBOOK.md`.

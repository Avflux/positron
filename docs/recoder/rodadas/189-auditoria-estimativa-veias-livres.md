# Rodada 189 — auditoria da `frmEstimativaVeiasLivres` (item 5 da correção do básico, 2ª tela)

**Data:** 2026-10-16 · **Commit:** `*(este)*` · **Frente:** correção do básico · **Situação:** 🟡 parcial (2 telas auditadas)

## Alvo

Item 5 do `ESTADO.md`. Tela ligada na rodada 160 (`ESTVL`); nunca auditada. Primeira vez que é ajustada nesta fase (grep em `docs/recoder/` sem ocorrência).

## O que o reverso faz

`frmEstimativaVeiasLivres.cs` (designer `:ff1Cn20r00`; construtor; `formataDGVeias`; `btCopiar`). Sem captura `.png` própria.

- Título = mMensagem 1432 "Estimativa Veias Faltantes" (o mapa já traz esse texto); colunas 48 `DE`, 49 `PARA`, 1433 `# VEIAS`, larguras 2/5, 2/5, 1/5 de `Width-22`.
- `clsInterligacao.Estimativa` (`clsInterligacao.cs:4544-4591`): veias indefinidas com os dois painéis ≠ 0, par ordenado (menor, maior), contagem por par, nome por `Dicionario.BuscaNomeDoPainel`.
- `btCopiar`: `Nome\tNome\tQtd\r\n` por linha, só com linhas (`:mRAC11iHWi`).

Conferido contra o mapa gerado (`FormulariosDoReverso.Dados.cs:3843`): 414×361, `dgTrajeto` 12,12,390×292, `btCopiar` 180,310,40×40 `Copy_32`, `CenterParent`, fora da barra de tarefas. Tudo igual; regra e cópia da ligação batem.

Diferenças achadas: 2 linhas inventadas na linha de comando (`ESTVL: n par(es)…` e `o cadastro de painéis não veio do banco — …`); o original não escreve nada.

## O que foi feito

| arquivo | o quê |
|---|---|
| `cad-plugin/Positron.Plugin/Interface/Telas/LigacaoDoFrmEstimativaVeiasLivres.cs` | removidas as 2 linhas inventadas (e a lista `pares` que só servia a elas) |

## Prova

- `plugin:test`: **975** aprovados, 0 falhas (sem teste novo: só casca).
- builds ZWCAD / AutoCAD: 0 avisos, 0 erros.
- CAD: não medido: a mudança só tira texto; nada em `scripts/` ou `docs/RUNBOOK.md` lê as mensagens (grep).

## Falta

- [ ] `MinimumSize 430×400`/`MaximumSize 430×1000` do designer não vêm do mapa (o gerador não os emite) — ver rodada 188.
- [ ] Auditar as demais telas ligadas (20) e as feitas à mão.

## Conhecimento registrado

Nenhum fato novo.

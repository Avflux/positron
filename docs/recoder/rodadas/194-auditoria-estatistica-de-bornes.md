# Rodada 194 — auditoria da `frmEstatisticaDeBornes` (item 5 da correção do básico, 7ª tela)

**Data:** 2026-10-16 · **Commit:** `*(este)*` · **Frente:** correção do básico · **Situação:** 🟡 parcial (7 telas auditadas)

## Alvo

Item 5 do `ESTADO.md`. Tela ligada na frente 3 (`STATBORN`); sem outra passagem (grep em `docs/recoder/`). Sem captura `.png` própria.

## O que o reverso faz

`frmEstatisticaDeBornes.cs` (construtor `:633`; `fALCfcTcWb` filtro; `MostraSelecionado`; `FvUC6nnRtb` resize) e `clsReguasDeBornes.cs` (`calculaSelecionado :26`, `carregaEstatisticaNoDG :58`, `AtualizaColunasDGEstatistica :101`).

- Colunas: `#` (oculta), Painel 1081 (nome do cadastro, `"???"` se faltar), Régua 1043, Simples 1078, Reserva 1049, Duplo 1079, Reserva 1049, Total 1080; linhas centralizadas.
- Filtro por "contém" (sem diferenciar maiúsculas) no nome do painel **ou** da régua; no `KeyUp` o texto vira maiúsculo, a grade recarrega e os totais refazem.
- `AtualizaColunasDGEstatistica`: larguras 25/20/10/10/10/10/15%, `MultiSelect`, **todas as linhas selecionadas** — a cada carga e a cada redimensionamento.
- Rodapé: soma **só as linhas selecionadas** (nenhuma = zero), atualizado no `KeyUp`/`MouseUp` da grade.
- Construtor: banco inválido ou DWG sem índice → `MsgBox` (331) e a tela não abre.
- Designer: `MinimumSize 450×540`, `MaximumSize 450×1200`, `AllowUserToOrderColumns`.

Controles, posições e rótulos conferem com o mapa (`FormulariosDoReverso.Dados.cs:3715`).

Diferenças: a ligação **inventava as colunas** (`Régua`, `Painel`, `Nome`, `US`, `RS`, `UD`, `RD`, `Total`), alegando que não estavam no reverso — estão em `carregaEstatisticaNoDG`; mostrava o **índice** do painel em vez do nome; o filtro era `TextChanged` e casava também pelo índice da régua; sem maiúsculas; totais somavam tudo quando nada selecionado; sem larguras, coluna oculta, centralização nem seleção total; sem a guarda de banco/DWG; faltavam os limites de tamanho.

## O que foi feito

| arquivo | o quê |
|---|---|
| `Interface/Telas/LigacaoDoFrmEstatisticaDeBornes.cs` | reescrita fiel: colunas/textos 1081/1043/1078/1049/1079/1080, nome do painel pelo cadastro (`ProjectStore.LerNomesDePaineis`), filtro e eventos do original, larguras, seleção total, rodapé só do selecionado, guarda 331, limites de tamanho |

## Prova

- `plugin:test`: **975** aprovados, 0 falhas (sem teste novo: só casca; a conta por régua não mudou).
- builds ZWCAD / AutoCAD: 0 avisos, 0 erros.
- CAD: não medido: sem ZWCAD nesta máquina (medido; ausência = medição com data — ver RUNBOOK.md → *Existe CAD nesta máquina?*); a tela não foi aberta no AutoCAD nesta rodada.

## Falta

- [ ] Medir a tela aberta no CAD (`STATBORN` no `Funcional.dwg`): nomes de painel, filtro e rodapé.
- [ ] No filtro o texto é reescrito em maiúsculas a cada tecla, como no original (o cursor volta ao início do campo no WinForms).
- [ ] Auditar as demais telas ligadas e as feitas à mão.

## Conhecimento registrado

Nenhum fato novo.

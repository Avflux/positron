# Rodada 192 — auditoria da `frmPesquisaCabos` (item 5 da correção do básico, 5ª tela)

**Data:** 2026-10-16 · **Commit:** `*(este)*` · **Frente:** correção do básico · **Situação:** 🟡 parcial (5 telas auditadas)

## Alvo

Item 5 do `ESTADO.md`. Tela ligada na 178; a 191 já deixou o clique nas veias silencioso. Sem captura `.png` própria.

## O que o reverso faz

`frmPesquisaCabos.cs` (designer `M31pvuFo6Vc`; construtor; `formataDGCabos`/`formataDGVeias`; `Atualiza*`; `MI1pvipBDIv`; `vp1pvC6nLi1`).

- Título mMensagem 580; colunas 1238 / `Tipo` oculto; veias 915, 1239, 772, `Handle`, `Ordena`; larguras 30/70% (Nome/Página).
- Designer: `MinimumSize 430×400`, `MaximumSize 430×1000`, `AllowUserToOrderColumns` nas duas grades.
- Cabeçalho coral = mMensagem 1638 em maiúsculas; catálogo vazio → `MsgBox` 1284 e `Close()`.
- Nenhuma escrita na linha de comando em todo o caminho.

Tela, textos e regra conferem com o mapa (`FormulariosDoReverso.Dados.cs:636`) e com `PesquisaDeCabos`.

Diferenças: 3 linhas inventadas (`PESQCAB: n cabo(s)…`, `PESQCAB: cabo … — n veia(s)` ao clicar e uma "primeira linha mostrada como medida" no abrir); faltavam `MinimumSize`/`MaximumSize` e `AllowUserToOrderColumns`.

## O que foi feito

| arquivo | o quê |
|---|---|
| `Interface/Telas/LigacaoDoFrmPesquisaCabos.cs` | saem as 3 linhas e o `Resumo`; entram os limites de tamanho e `AllowUserToOrderColumns` |

## Prova

- `plugin:test`: **975** aprovados, 0 falhas (sem teste novo: só casca).
- builds ZWCAD / AutoCAD: 0 avisos, 0 erros.
- CAD: não medido: a mudança só tira texto; nenhum script lê essas linhas (grep em `scripts/` e `RUNBOOK.md`).

## Falta

- [ ] `EditMode = EditProgrammatically` não aplicado (grade já é `ReadOnly`).
- [ ] Auditar as demais telas ligadas e as feitas à mão.

## Conhecimento registrado

Nenhum fato novo.

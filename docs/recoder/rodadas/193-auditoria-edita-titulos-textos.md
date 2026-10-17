# Rodada 193 — auditoria da `frmEditaTitulosTextos` (item 5 da correção do básico, 6ª tela)

**Data:** 2026-10-16 · **Commit:** `*(este)*` · **Frente:** correção do básico · **Situação:** 🟡 parcial (6 telas auditadas)

## Alvo

Item 5 do `ESTADO.md`. Tela ligada na 179 (`TROCTT`); sem outra passagem (grep em `docs/recoder/`). Sem captura `.png` própria.

## O que o reverso faz

`frmEditaTitulosTextos.cs` (designer `K9qSt9nUaH`; construtor; `sgrSxhI2bv`) e `clsEditaTitulosTextos.cs`.

- Título/dica = 592; DE 48, PARA 49, Título 1..4 = 40..43, 1161, 1222; coluna 9.
- Designer: `MinimumSize 396×387`, `MaximumSize 396×600`.
- Sem título no formato: `MsgBox(53, Information, "Elétron")` e a tela não abre.
- Fim da edição: `MsgBox(n & 1221, Information)` (`clsEditaTitulosTextos.cs:158`); erro é relançado (`:162`, `:296`). Nenhuma linha de comando.
- Sem caixa marcada ou sem DE, o botão volta calado.

Tela e textos conferem com o mapa (`FormulariosDoReverso.Dados.cs:3824`).

Diferenças: o aviso 53 e o resultado iam só para a linha de comando (não eram `MsgBox`); 1 linha inventada de contagem de páginas/títulos; resultado com texto extra (`"DE" -> "PARA" em n página(s)`); erro como linha "falhou —"; faltavam os limites de tamanho.

## O que foi feito

| arquivo | o quê |
|---|---|
| `Interface/Telas/LigacaoDoFrmEditaTitulosTextos.cs` | aviso 53 e resultado viram `Aviso.MsgBox` (texto exato, título "Elétron"/vazio); erro vira `MsgBoxCritico`; sai a linha de contagem e o `Lista`; entram `MinimumSize`/`MaximumSize` |

`Aviso` mostra o diálogo e ecoa na linha de comando (convenção do projeto); no harness só ecoa, então o ensaio `POSITRON_TROCTT` segue funcionando.

## Prova

- `plugin:test`: **975** aprovados, 0 falhas (sem teste novo: só casca).
- builds ZWCAD / AutoCAD: 0 avisos, 0 erros.
- CAD: não medido: sem ZWCAD nesta máquina (medido; ausência = medição com data — ver RUNBOOK.md → *Existe CAD nesta máquina?*); a mudança é de casca (texto/diálogo).

## Falta

- [ ] Erro relançado no original aparece como diálogo de exceção do .NET; aqui é `MsgBoxCritico` (desvio de forma, não de efeito).
- [ ] Auditar as demais telas ligadas e as feitas à mão.

## Conhecimento registrado

Nenhum fato novo.

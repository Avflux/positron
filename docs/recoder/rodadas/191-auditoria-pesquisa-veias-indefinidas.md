# Rodada 191 — auditoria da `frmPesquisaVeiasIndefinidas` (item 5 da correção do básico, 4ª tela)

**Data:** 2026-10-16 · **Commit:** `*(este)*` · **Frente:** correção do básico · **Situação:** 🟡 parcial (4 telas auditadas)

## Alvo

Item 5 do `ESTADO.md`. Tela ligada na rodada 177 (`PESQC`); a 180 só mexeu no `BancoValido`/DWG. Sem captura `.png` própria.

## O que o reverso faz

`frmPesquisaVeiasIndefinidas.cs` (designer; construtor; `formataDGVeiasDWG`; `AtualizaDGVeiasDWG`; `wkpp6H6CivH`).

- Título = mMensagem 568 "Pesquisar Veias Indefinidas"; colunas `#`, 9, 429, 432, `Handle` (oculto); larguras 10/30/30/30%.
- Designer: `MinimumSize 400×200`, `AllowUserToOrderColumns = true`, `EditMode = EditProgrammatically`.
- `CarregaTodasAsVeiasDoCadernoNoDG`: par ordenado (menor, maior); `"???"` vira `" "`.
- Clique/tecla (`wkpp6H6CivH`): `Unhighlight`, foco, `AtivaUmaHighlightZoom` por linha; o `catch` só faz `Abort` — **nada é impresso**. Mesmo código no `frmPesquisaCabos`.
- Construtor: banco inválido ou DWG sem índice → `MsgBox` (331) e a tela não abre; `Dicionario.BuscaNomeDoPainel` (`Dicionario.cs:47`) engole o erro e devolve `"???"`.

Tela e regra conferem com o mapa (`FormulariosDoReverso.Dados.cs:668`).

Diferenças: linhas inventadas na linha de comando (`PESQC: n veia(s)…`, `o cadastro de painéis não veio do banco…`, `PESQC/PESQCAB: veia … (zoom e realce)`, `handle … não achado`, `falhou — …`); faltavam `MinimumSize` e `AllowUserToOrderColumns` (o mapa não os emite).

## O que foi feito

| arquivo | o quê |
|---|---|
| `Interface/Telas/LigacaoDoFrmPesquisaVeiasIndefinidas.cs` | saem a linha de contagem e a do cadastro de painéis (erro engolido, como no original); entram `MinimumSize 400×200` e `AllowUserToOrderColumns` |
| `Interface/Telas/IrAteAVeiaDaGrade.cs` | passa a ser silencioso (sem `rotulo`); erro engolido como no original — vale também para o `PESQCAB` |
| `Interface/Telas/LigacaoDoFrmPesquisaCabos.cs` | só a chamada do helper |

## Prova

- `plugin:test`: **975** aprovados, 0 falhas (sem teste novo: só casca).
- builds ZWCAD / AutoCAD: 0 avisos, 0 erros.
- CAD: não medido: a mudança só tira texto; nenhum script lê essas linhas (grep em `scripts/`).

## Falta

- [ ] `LigacaoDoFrmPesquisaCabos.cs` ainda escreve `PESQCAB: …` (linhas 116 e 150) — fica para a auditoria dela.
- [ ] `EditMode = EditProgrammatically` não aplicado (grade já é `ReadOnly`; sem efeito observável).
- [ ] Auditar as demais telas ligadas e as feitas à mão.

## Conhecimento registrado

Nenhum fato novo.

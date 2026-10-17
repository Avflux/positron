# Rodada 197 — auditoria da `frmEditaTitulos` (item 5 da correção do básico, 10ª tela)

**Data:** 2026-10-16 · **Commit:** `*(este)*` · **Frente:** correção do básico · **Situação:** 🟡 parcial (10 telas auditadas)

## Alvo

Item 5 do `ESTADO.md`. Tela já ajustada nas rodadas 183/184 (grade, colunas por título existente, `restauraCampos`); esta passou só o que sobrou de invenção. Sem captura própria.

## O que o reverso faz

`frmEditaTitulos.cs` (construtor `:540`, `limpaDG`, `AtualizaDG`, `wFKiyTSi1h`, `Y4nisXqkkF`, `DrQiVfVSwm`, `RmDiunMFty`, `SBsiSR9Mfr`).

- Sem títulos no formato: `MsgBox` 53, título "Elétron". Erro de carga e de gravação: `MsgBox(ex.Message, Critical)` sem título.
- Coluna Alternativo (6) cortada em 20 caracteres no Colar/Substituir; ao sair da célula, mMensagem 1927 ("Máximo de 20 caracteres") via `MsgBox` sem título.
- Editar DWG: grava títulos, unidade/alternativo, recarrega a paleta e fecha. Nenhuma linha na linha de comando.
- Exportar/Importar (1382/1383): ponte Excel (`clsTextos.ExportaPaginas/ImportaTitulos`) — continua recorte pendente (fila item 1).
- Quirk do original (`AtualizaDG`): sem o título 2 esconde a coluna **3** e deixa a 2; **não replicado** (esconderia a coluna errada); fica a visibilidade pela coluna do próprio título — desvio por motivo de usabilidade, a confirmar com o dono.

Diferenças: 2 linhas inventadas `Editar os Títulos: …` na linha de comando; `MsgBox` crítico e o de 1927 com título "Elétron"; erro do `restauraCampos` como aviso simples; rolagem da grade até a página ativa (não existe no original).

## O que foi feito

| arquivo | o quê |
|---|---|
| `cad-plugin/Positron.Plugin/Interface/Telas/LigacaoDoFrmEditaTitulos.cs` | saem as 2 linhas `Editar os Títulos:` e o `FirstDisplayedScrollingRowIndex`; títulos dos `MsgBox` como no original (sem título, exceto 53); erro do `restauraCampos` vira `MsgBox` crítico |

## Prova

- `plugin:test`: não rodado: só casca; runner xUnit ausente. Última contagem: 975.
- builds ZWCAD / AutoCAD: 0 avisos, 0 erros.
- CAD: não medido: sem ZWCAD (medido; ausência = medição com data — ver RUNBOOK.md → *Existe CAD nesta máquina?*); tela não aberta nesta rodada.

## Falta

- [ ] Decisão do dono: replicar o quirk do `AtualizaDG` (sem título 2 → some a coluna 3)?
- [ ] Fechar a janela ao trocar de documento (`Idle`) e a trava `ReferenceEquals(documento…)` não existem no original: desvio das rodadas 183/184 para não gravar em outro DWG; confirmar.
- [ ] Excel (Exportar/Importar), já na fila item 1.
- [ ] Auditar `frmGerenciador*`, `frmCompilar*`, `frmPesquisaXdatas`, `frmRelatorio_*`.

## Conhecimento registrado

Nenhum fato novo.

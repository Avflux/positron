# Rodada 206 — auditoria da `frmGerenciadorMatIndep` (item 5 da correção do básico, 21ª e última tela ligada)

**Data:** 2026-10-16 · **Commit:** `*(este)*` · **Frente:** correção do básico · **Situação:** 🟡 parcial (21 telas ligadas auditadas)

## Alvo

Item 5 do `ESTADO.md`; comando `ATINDEP` (escrita ligada na rodada 148). Captura: `dispositivos independentes e avulsos.png`.

## O que o reverso faz

`frmGerenciadorMatIndep.cs` (construtor `:747`, `formataDGPainelLM :1215`, `formataDGDisp :1269`).

- Construtor: `Geral.ExisteForm` e `clsAuxiliar.BancoValido()` (sem o 331); textos 586/804/797/584/1245/246/654/1169; dicas só de `BTAdicionaLM`/`BTEditaLM`/`BTApagaLM` (1164–1166); `tbCodigo1 = "0"`; `dgDisp.MultiSelect = true`.
- `dgPaineis`: colunas `Indice` (sem título) e "Equipamentos  Painéis" (748); `dgDisp`: doze colunas, com os títulos de 804/584/797 e as demais sem título.
- Erros: `MessageBox` "Elétron" crítico em todas as rotinas; as ações dos botões não escrevem mensagem.
- Não há dica no `btPesquisaLM1`.

Colunas, textos e dicas da ligação **já conferiam** com o original.

Diferenças da ligação anterior: sem a guarda do `BancoValido`; cada botão e a abertura escreviam linhas `ATINDEP:` na linha de comando (resumo da carga, resultado de adicionar/editar/apagar); erros do banco só na linha de comando; dica "Pesquisar: abre o frmPesquisaMateriais…" inventada no `btPesquisaLM1`.

## O que foi feito

| arquivo | o quê |
|---|---|
| `cad-plugin/Positron.Plugin/Interface/Telas/LigacaoDoFrmGerenciadorMatIndep.cs` | guarda `BancoValido`; ações e abertura silenciosas (só o gancho do harness `POSITRON_LIM_*` escreve); erros do banco em `MsgBox` crítico "Elétron"; `btPesquisaLM1` desabilitado sem dica |

(O erro do catálogo como `MsgBox` já vinha da base `LigacaoDeMateriais`, rodada 205.)

## Prova

- `plugin:test`: não rodado: só casca; runner xUnit ausente. Última contagem: 975.
- builds ZWCAD / AutoCAD: 0 avisos, 0 erros.
- CAD: não medido: sem ZWCAD (medido; ausência = medição com data — ver RUNBOOK.md → *Existe CAD nesta máquina?*); tela não aberta. Receitas do RUNBOOK (rodada 148) que liam as linhas `ATINDEP:` da abertura/dos botões só valem pelo gancho do harness.

## Falta

- [ ] Pesquisa de material (`frmPesquisaMateriais`, nenhum comando a abre) — botão desabilitado.
- [ ] Atualizar a receita do RUNBOOK (rodada 148) que cita as linhas `ATINDEP:`.
- [ ] Medir `ATINDEP` no AutoCAD (clique em Adiciona/Edita/Apaga, painel, seleção múltipla).
- [ ] Fim da auditoria das telas **ligadas**: faltam as telas feitas à mão e as 102 só-casca (fila do `ESTADO.md`).

## Conhecimento registrado

Nenhum fato novo.

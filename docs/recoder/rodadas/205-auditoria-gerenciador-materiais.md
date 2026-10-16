# Rodada 205 — auditoria da `frmGerenciadorMateriais` (item 5 da correção do básico, 20ª tela)

**Data:** 2026-10-16 · **Commit:** `*(este)*` · **Frente:** correção do básico · **Situação:** 🟡 parcial (20 telas auditadas)

## Alvo

Item 5 do `ESTADO.md`; comando `GERLM` (escrita ligada na rodada 149). Captura: `gerenciador de materiais.png`.

## O que o reverso faz

`frmGerenciadorMateriais.cs` (construtor `:834`, `formataDG :1072`, `AtualizaColunasDGMateriais :1088`, finalizador `:1269`).

- Construtor: `BancoValido()`; DWG sem índice → `MsgBox` 331; textos 585/584/246/247/1162/1163/654/1169; dicas 1164–1168 e `TBDescCompleta` 1884 ("Pressione CTRL + ENTER para quebra de Linha"); `TBDescCompleta` multilinha com `AcceptsTab`.
- Grade: `#`, `CodigoCliente`, `Modelo`, `Fabricante`, `DescricaoResumida`, `DescricaoCompleta`, `IndiceOriginal`, `Ação`, `IndiceEL`; larguras 10/20/35/35% da largura (menos 4 ou 21) e as cinco últimas escondidas.
- Adicionar/Editar/Apagar/Salvar: **sem nenhuma mensagem** ao usuário.
- Ao fechar com alteração: `MsgBox` "Salvar Alterações?" Sim/Não, título "Elétron"; `Sim` salva.

Diferenças da ligação anterior: sem a guarda do 331; coluna "Cod.Cliente"; sem larguras nem colunas escondidas (as cinco colunas técnicas apareciam); sem a dica/multilinha da descrição completa; cada botão e a abertura escreviam linhas `GERLM:` na linha de comando; ao fechar só avisava na linha de comando (o original pergunta e salva com `Sim`); erro de gravação/catálogo só na linha de comando; dicas do Excel com "motivo" inventado.

## O que foi feito

| arquivo | o quê |
|---|---|
| `cad-plugin/Positron.Plugin/Interface/Telas/LigacaoDoFrmGerenciadorMateriais.cs` | guarda 331; cabeçalho e larguras do original; descrição completa multilinha com dica; ações silenciosas (só o gancho do harness escreve o resultado); "Salvar Alterações?" ao fechar (pulado no harness); erro de gravação em `MsgBox` crítico; dicas do Excel do original |
| `cad-plugin/Positron.Plugin/Interface/Telas/LigacaoDeMateriais.cs` | erro do catálogo vira `MsgBox` crítico (vale também para `frmGerenciadorMatIndep`) |

Desvios: a pergunta ao fechar sai no `FormClosing` (o original, no finalizador); a linha de código 0 recém-acrescentada não vai para a lista de apagados (rodada 149).

## Prova

- `plugin:test`: não rodado: só casca; runner xUnit ausente. Última contagem: 975.
- builds ZWCAD / AutoCAD: 0 avisos, 0 erros.
- CAD: não medido: sem ZWCAD; tela não aberta. Receitas do RUNBOOK da rodada 149 que liam as linhas `GERLM:` dos botões só valem pelo gancho do harness (`POSITRON_LM_*`), que continua escrevendo o resultado.

## Falta

- [ ] Importar/Exportar do Excel (desabilitados, interop).
- [ ] Atualizar a receita do RUNBOOK (rodada 149) que cita as linhas `GERLM:`.
- [ ] Auditar `frmGerenciadorMatIndep`.
- [ ] Medir `GERLM` no AutoCAD: seleção, edição, salvar e a pergunta ao fechar.

## Conhecimento registrado

Nenhum fato novo.

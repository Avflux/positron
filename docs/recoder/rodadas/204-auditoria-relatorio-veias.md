# Rodada 204 — auditoria da `frmRelatorio_Veias` (item 5 da correção do básico, 19ª tela)

**Data:** 2026-10-16 · **Commit:** `*(este)*` · **Frente:** correção do básico · **Situação:** 🟡 parcial (19 telas auditadas)

## Alvo

Item 5 do `ESTADO.md`; comando `LVEI`, irmã da `frmRelatorio_Materiais` (rodada 203, mesma base `LigacaoDeRelatorio`). Captura: `lista de veias.png`.

## O que o reverso faz

`frmRelatorio_Veias.cs` (construtor `:681`, `R96pPjkCH8F :730`, `formataDGRevisao :1136`, `formataDGEquip :1180`, `formataDGCabos :1232`).

- Construtor: título 895; textos pelas mMensagens; única dica = `btPesquisar` (1411 "Visualizador de Cabos"); `formataDGRevisao`/`formataDGEquip` com colunas; revisões do `Cabos4` da mais nova para a mais antiga; `qTotal` vazio; `dgVeias` com **linhas e colunas limpas**; `CKAgrupar` desmarcado.
- `formataDGCabos` (colunas da lista) roda no `btPesquisar`.
- Erro de leitura: `MessageBox` "Elétron" crítico; sem guarda de banco.

Diferenças da ligação anterior: `dgVeias` já abria com as 14/15 colunas; lia o `CBComprimento` só na abertura; escolhia revisão e painel e carregava a lista sozinha ao abrir; dicas inventadas (motivos) em `btExportaEXCEL`, `CKAgrupar`, `RBFuncaoVeia`, `RBSheetDiferente` e nenhuma no `btPesquisar`; `CKAgrupar` sem desmarcar; linhas `LVEI:` na linha de comando ("escolha a revisão…", "Cabos4 sem revisão", resumo da carga, banco não configurado).

## O que foi feito

| arquivo | o quê |
|---|---|
| `cad-plugin/Positron.Plugin/Interface/Telas/LigacaoDoFrmRelatorioVeias.cs` | `dgVeias` sem colunas até o `btPesquisar` (colunas montadas lá, com o `CBComprimento` da hora); dica do `btPesquisar`; `CKAgrupar` desmarcado; controles não portados desabilitados sem dica; sem as linhas `LVEI:`; harness (`POSITRON_REL_REVISAO`/`POSITRON_REL_PAINEL`) carrega ao abrir |

(O erro do banco como `MsgBox` crítico já veio na rodada 203, na base `LigacaoDeRelatorio`.)

## Prova

- `plugin:test`: não rodado: só casca; runner xUnit ausente. Última contagem: 975.
- builds ZWCAD / AutoCAD: 0 avisos, 0 erros.
- CAD: não medido: sem ZWCAD; tela não aberta. A receita do RUNBOOK (linha ~1315–1324) que esperava a carga automática sem as variáveis `POSITRON_REL_*` fica desatualizada.

## Falta

- [ ] Modos Agrupar Cabos Por Painel, Função da Veia, Worksheet Diferente e exportar Excel (regra não portada: `bSepara`, `CarregaFuncoesDaVeias4`).
- [ ] Larguras das colunas (`formataDGRevisao`/`formataDGEquip`/`formataDGCabos`) e o redimensionamento (`sAUpPMrMRCb`).
- [ ] Atualizar a receita do RUNBOOK do `LVEI`/`EXPLM`.
- [ ] Auditar `frmGerenciadorMateriais` e `frmGerenciadorMatIndep`.

## Conhecimento registrado

Nenhum fato novo.

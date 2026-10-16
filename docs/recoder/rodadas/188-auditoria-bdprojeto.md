# Rodada 188 — auditoria da `frmConfiguracaoBDProjeto` (item 5 da correção do básico, 1ª tela)

**Data:** 2026-10-16 · **Commit:** `*(este)*` · **Frente:** correção do básico · **Situação:** 🟡 parcial (1 tela de ~42 auditada)

## Alvo

Item 5 do `ESTADO.md`: auditar as telas ligadas/feitas à mão atrás de invenções. Começou pela menor: `frmConfiguracaoBDProjeto`.

## O que o reverso faz

`frmConfiguracaoBDProjeto.cs:89-124` (designer), `:127-237` (lógica). Já ajustada na rodada 180 (ver `rodadas/180-…`).
Sem captura `.png` (`reverso-capturas.txt:218` = "-"); conferido contra o designer e o mapa gerado.

Conferido controle a controle (mapa `FormulariosDoReverso.Dados.cs:2997`): título mMensagem 107; 384×91; `FixedSingle`, sem
maximizar/minimizar, fora da barra de tarefas; `tbProjeto` (12,12,323×68, multilinha, âncoras T/B/L/R); `SelProj` (341,27,36×36, `Database_32`,
âncora Right). Textos 237, 323, 1970 batem com `Mensagens-PT.txt`. Filtros do seletor idênticos (`:140-155`).

Diferenças achadas:
- 3 linhas de linha de comando inventadas (`o desenho passa a usar…`, `DWG n cadastrado…`, `falhou — …`): o original não escreve nada.
- erro no `UPDATE DWG`: o original mostra `MsgBox(ex.Message, Critical, "Eletron")` (`:222-227`); o plugin o engolia no `catch` externo.

## O que foi feito

| arquivo | o quê |
|---|---|
| `cad-plugin/Positron.Plugin/Interface/Telas/LigacaoDoFrmConfiguracaoBDProjeto.cs` | removidas as 3 linhas inventadas; erro do cadastro do DWG vira `MsgBoxCritico` como no `yKiycL7IZh` |

## Prova

- `plugin:test`: **975** aprovados, 0 falhas (sem teste novo: só casca).
- builds ZWCAD / AutoCAD: 0 avisos, 0 erros.
- CAD: não medido: mudança só tira texto e adiciona `MsgBox` em caminho de erro; nenhuma linha de harness dependia das mensagens (grep em `scripts/` e `cad-plugin/`).

## Falta

- [ ] `MinimumSize 400×130`/`MaximumSize 1000×400` do designer não vêm do mapa (o gerador não os emite); sem efeito visível com `FixedSingle`.
- [ ] `ACorrecaoBD.CorrigeBD`, `carregaPainelDicionario`, `carregaDWGDicionario` e o monitor de tooltips depois do `SelProj` (já na fila, rodada 181).
- [ ] Auditar as demais telas ligadas (21) e as feitas à mão — o item 5 segue aberto.

## Conhecimento registrado

Nenhum fato novo.

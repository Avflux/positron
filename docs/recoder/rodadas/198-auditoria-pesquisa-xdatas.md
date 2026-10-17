# Rodada 198 — auditoria da `frmPesquisaXdatas` (item 5 da correção do básico, 11ª tela)

**Data:** 2026-10-16 · **Commit:** `*(este)*` · **Frente:** correção do básico · **Situação:** 🟡 parcial (11 telas auditadas)

## Alvo

Item 5 do `ESTADO.md`; comando `APAGARXDATA`. Sem outra passagem (grep em `docs/recoder/`). Captura: `apagar xdatas de terceiros.png`.

## O que o reverso faz

`frmPesquisaXdatas.cs` (construtor, `DTXp66plP1w`, `e4vp6t1s1VL`, `wRjp6jaJG6g`, `Hl5p6wKgTZt`) e `clsApagaXdatas.cs:112`.

- Construtor: título mMensagem 1930, `CkXdataEletron` desmarcado e escondido, grade recriada ("xData" + mMensagem 797), `MultiSelect` ligado, `MinimumSize 320×500`, `MaximumSize 320×1500`.
- Carga: sem o "Incluir Eletron", esconde os 34 app names do produto (lista fixa); `BtPesquisa` recarrega.
- Larguras: 70% / 30% de (largura − 4), ou − 21 com a barra de rolagem, na carga.
- `BtApaga`: varre `Rows[i].Selected` na ordem da grade, `ApagaxDatasSelecionados` (com `LockDocument`), recarrega e `MsgBox` "N xData apagados" (Information).

Diferenças: o resultado ia só para a linha de comando (a nota em `LigacoesDasTelas.cs` mandava isso; `Aviso.MsgBox` já cobre o harness); a carga escrevia a linha `APAGARXDATA: …` com os nomes; sem larguras 70/30 nem limites de tamanho; seleção na ordem inversa de `SelectedRows`; `XDatasDoCad.Apagar` não travava o documento (tela não modal).

## O que foi feito

| arquivo | o quê |
|---|---|
| `cad-plugin/Positron.Plugin/Interface/Telas/LigacaoDoFrmPesquisaXdatas.cs` | `MsgBox` "N xData apagados"; sai a linha de medida da carga; larguras 70/30; limites de tamanho; seleção pela ordem da grade |
| `cad-plugin/Positron.Plugin/Limpeza/XDatasDoCad.cs` | `Apagar` trava o documento (`LockDocument`) como o original |
| `cad-plugin/Positron.Plugin/Interface/Telas/LigacoesDasTelas.cs` | corrige a nota que mandava trocar `MsgBox` por linha de comando |

## Prova

- `plugin:test`: não rodado: só casca; runner xUnit ausente. Última contagem: 975.
- builds ZWCAD / AutoCAD: 0 avisos, 0 erros.
- CAD: não medido: sem ZWCAD (medido; ausência = medição com data — ver RUNBOOK.md → *Existe CAD nesta máquina?*); tela não aberta. Nenhum script do harness lia as linhas `APAGARXDATA:` (grep em `scripts/` e `cad-plugin/`).

## Falta

- [ ] Medir `APAGARXDATA` no `Funcional.dwg` (AutoCAD): lista, apagar pela tela clicada e o `MsgBox`.
- [ ] Auditar `frmGerenciador*`, `frmCompilar*`, `frmRelatorio_*`, `frmSplash`.

## Conhecimento registrado

Nenhum fato novo.

# Rodada 195 — auditoria da `frmEditaRevisaoSimplificada` (item 5 da correção do básico, 8ª tela)

**Data:** 2026-10-16 · **Commit:** `*(este)*` · **Frente:** correção do básico · **Situação:** 🟡 parcial (8 telas auditadas)

## Alvo

Item 5 do `ESTADO.md`. Tela do `REVSIMP`; sem outra passagem (grep em `docs/recoder/` e `git log`). Captura: `editar revisão simplificada.png`.

## O que o reverso faz

`frmEditaRevisaoSimplificada.cs` (construtor `:309`, `limpaDG :332`, `uy7iNUG3AA :359`, `jMviF3tmHg :383`, `C6GiKcqEd2 :425`, `nZfi2W6nmd :464`) e `Revisao.cs` (`capturaRevisoesSimplificadas :80`, `AtualizaRevSimplificada :159`, com `LockDocument`).

- Construtor: `Pagina.restauraCampos`, grade, textos do menu pelas mMensagens 61/45/46/51/52, `MinimumSize 230×500`.
- Grade: Página (39, somente leitura) | Revisão (62), sem ordenação; larguras = (largura da grade − 30)/2, refeitas a cada `Resize`.
- Linhas: de `SCapa ? 1 : 2` até `SCorpo ? última : 1` (com os dois falsos, nenhuma). Erro → `MsgBox` crítico.
- `Click` da grade: Copiar só habilitado com 1 célula selecionada. Colar/Limpar só na coluna Revisão.
- Editar DWG: revisão nula vira vazia, grava com `LockDocument`, fecha; erro → `MsgBox` crítico (tela fica aberta).

Tela e captura conferem com o mapa (`FormulariosDoReverso.Dados.cs:3129`).

Diferenças da ligação anterior: sem `restauraCampos`; carregava **todas** as páginas, ignorando `SCapa`/`SCorpo`; colunas sem ordenação fixa e sem larguras meio a meio; Copiar sempre habilitado; 2 linhas inventadas do `REVSIMP` na linha de comando; gravava sem `LockDocument` (a tela é não modal) e sem `MsgBox` no erro; sem `MinimumSize`.

## O que foi feito

| arquivo | o quê |
|---|---|
| `cad-plugin/Positron.Plugin/Interface/Telas/LigacaoDoFrmEditaRevisaoSimplificada.cs` | reescrita fiel: `RestaurarCampos`, faixa `SCapa`..`SCorpo`, colunas e larguras, Copiar pelo `Click`, gravação com `LockDocument`, erros em `MsgBox` crítico, `MinimumSize`; saem as 2 linhas `REVSIMP:` |

## Prova

- `plugin:test`: não rodado: só casca (a regra de leitura/gravação não mudou); runner xUnit ausente nesta máquina. Última contagem: 975.
- builds ZWCAD / AutoCAD: 0 avisos, 0 erros.
- CAD: não medido: sem ZWCAD nesta máquina (medido; ausência = medição com data — ver RUNBOOK.md → *Existe CAD nesta máquina?*); a tela não foi aberta no AutoCAD nesta rodada.

## Falta

- [ ] Medir `REVSIMP` no `Funcional.dwg` (AutoCAD): linhas pela `SCapa`/`SCorpo`, Editar DWG pela paleta (lock) e desenho novo.
- [ ] Tooltip "abre a tela de edição de revisão simplificada…" no botão da paleta (`FolhasControle.cs:274`) não tem prova no reverso — checar na auditoria da paleta.
- [ ] Auditar as demais telas ligadas (`frmEditaRevisaoCompleta`, `frmEditaTitulos`, `frmGerenciador*`, `frmCompilar*`, `frmPesquisaXdatas`, `frmRelatorio_*`).

## Conhecimento registrado

Nenhum fato novo.

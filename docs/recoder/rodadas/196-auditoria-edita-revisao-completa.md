# Rodada 196 — auditoria da `frmEditaRevisaoCompleta` (item 5 da correção do básico, 9ª tela)

**Data:** 2026-10-16 · **Commit:** `*(este)*` · **Frente:** correção do básico · **Situação:** 🟡 parcial (9 telas auditadas)

## Alvo

Item 5 do `ESTADO.md`; irmã da 195. Captura: `editar revisão completa.png`.

## O que o reverso faz

`frmEditaRevisaoCompleta.cs` (construtor, `limpaDG`, `zwRiJ8qk2J`, `APeih1WTWH`, `QPUikak4gJ`, `NX5idRlEeH`, `tt4iDtS0Ar`).

- Construtor: `Pagina.restauraCampos`, textos pelas mMensagens 69/45/46/51/47/52/48/49, `DE`/`PARA` com `BackColor LightGray` e `BorderStyle Fixed3D`, `MinimumSize 700×500`.
- Grade: 7 colunas (39, 63..68), sem ordenação, larguras 10/10/40/10/10/10/10% de (largura − 30), refeitas a cada `Resize`; Página somente leitura.
- Linhas: de `CCapa ? 1 : 2` até `CCorpo ? última : 1`. Erro → `MsgBox` crítico.
- Copiar só habilitado com 1 célula (`Click` da grade). Substituir: `Contains` + `Replace` + `Trim`, colunas > 0.
- Editar DWG: nulos das colunas 1..6 viram vazio, grava (`AtualizaRevCompleta`, com `LockDocument`), fecha; erro → `MsgBox` crítico, tela aberta.

Diferenças da ligação anterior: sem `restauraCampos`; todas as páginas (ignorava `CCapa`/`CCorpo`); sem larguras percentuais nem ordenação fixa; Copiar sempre habilitado; DE/PARA sem cor/borda; sem `MinimumSize`; gravava sem `LockDocument` e sem `MsgBox` no erro; 2 linhas inventadas `REVCOMP:` (carga e resumo da gravação).

## O que foi feito

| arquivo | o quê |
|---|---|
| `cad-plugin/Positron.Plugin/Interface/Telas/LigacaoDoFrmEditaRevisaoCompleta.cs` | reescrita fiel: `RestaurarCampos`, faixa `CCapa`..`CCorpo`, colunas/larguras, Copiar pelo `Click`, DE/PARA, gravação com `LockDocument`, erros em `MsgBox` crítico; saem as linhas `REVCOMP:` |

## Prova

- `plugin:test`: não rodado: só casca; runner xUnit ausente. Última contagem: 975.
- builds ZWCAD / AutoCAD: 0 avisos, 0 erros.
- CAD: não medido: sem ZWCAD (medido; ausência = medição com data — ver RUNBOOK.md → *Existe CAD nesta máquina?*); tela não aberta no AutoCAD.

## Falta

- [ ] Medir `REVCOMP` no `Funcional.dwg`: faixa `CCapa`/`CCorpo`, Editar DWG pela paleta (lock).
- [ ] Texto do formulário no designer é `"frmEditaTitulos"` mas o original o troca pela mMensagem 69 no construtor — conferido, sem ação.
- [ ] Auditar as demais telas ligadas (`frmEditaTitulos`, `frmGerenciador*`, `frmCompilar*`, `frmPesquisaXdatas`, `frmRelatorio_*`).

## Conhecimento registrado

Nenhum fato novo.

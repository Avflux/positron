# Rodada 211 — medir no ZWCAD 2026 o `ApagarDerivados` (ramos das rodadas 208–210)

**Data:** 2026-10-16 · **Commit:** `f767cb6d` · **Frente:** 10 — páginas e caderno · **Situação:** ✅ medido (os três ramos); o bloco `P` segue na fila

## Alvo

O ZWCAD 2026 voltou a estar instalado nesta máquina (`C:\Program Files\ZWSOFT\ZWCAD 2026`). Esta rodada **mede no CAD** o que as rodadas 208 (polyline de interligação), 209 (contato auxiliar) e 210 (máscara) deixaram em *Falta*. Nenhuma regra nova: só a fixture, a medição e o registro.

## O que foi feito

| arquivo | o quê |
|---|---|
| `scripts/cad-fixture-apagar-derivados.lsp` | fixture sobre o `Funcional.dwg`: monta, na página `16` (a apagada) e na `15` (vizinha), os três ramos; `PZ-APD-DUMP` lista cada entidade de teste (atributos, visibilidade, XData) e `PZ-APD-RODA` faz dump → `APAGAPAGINA` → dump num comando só |
| `cad-plugin/Positron.Plugin/Paginas/DerivadosDaExclusaoDoDesenho.cs` | sem mudança de regra (o diagnóstico temporário saiu) |

Comando: `POSITRON_PAGINA=16` e
`powershell -ExecutionPolicy Bypass -File scripts/cad-zwcad-smoke.ps1 -Desenho cad-plugin/reverso/Teste_projeto_real/Funcional.dwg -Fixture <driver que carrega a fixture> -Comandos PZ-APD-RODA -EsperaSegundos 40`
(o `-Desenho` copia o `.dwg` para o TEMP; o original não é tocado). A saída vai para `%TEMP%\positron-apagar-derivados.txt`.

## Prova (ZWCAD 2026, `Funcional.dwg`, `APAGAPAGINA` da página 16)

| ramo | antes | depois |
|---|---|---|
| **interligação** | `P1` (layer 16, tipo 2 → handle de `P2`); `P2`, rótulo `R1` (handle de `P2`) e rótulo `R2` (handle `FFFF`) no layer 15 | `P1`, **`P2` e `R1` apagados**; `R2` fica |
| **contato auxiliar** | `A1` (layer 16); `MO` (layer 15) com `HandleContatoAux = A1` e atributos `INSERCAO=X1`, `INSERCAONA=X2`, `TAG=keep` | `A1` apagado; `MO` com `INSERCAO=""`, `INSERCAONA=""`, `TAG=keep` e `HandleContatoAux = ""` |
| **máscara com cópias** | `M1` (layer 16, LM 11/22, `TOPO`/`LAY`, atributos `MOD1`/`FAB1`/`DESC1`); cópias `M2` (atributos vazios, LM 0) e `M3` (LM 33/44); `E1`/`D1` apontam para `M1` | `M1` apagada; **`M2` com o estado de `M1`** (LM 11/22, `TOPO`/`LAY`) e os atributos `MOD1`/`FAB1` visíveis e `DESC1` **invisível** (`bliga:false`); **`M3` com `HandleMascPrincipal = M2`, LM 0/0, topográfico e layout vazios**; `E1`/`D1` passam a apontar para `M2` |
| **máscara sem cópias** | `M4` (layer 16) com `E2`/`D2` apontando para ela | `M4`, `E2` e `D2` apagadas |
| controle | `E3` (porta de máscara inexistente `ZZZ`) | `E3` intacta |

- `plugin:test`: sem mudança de código de regra desde a rodada 210 (**1008** aprovados).
- builds ZWCAD / AutoCAD: 0 avisos, 0 erros.
- Os índices de leitura de `Nome1`/`Nome2`/`Alternativo`/`HandleMascPrincipal`/`iLM1`/`iLM2` (risco da rodada 210) ficam **provados**: as cópias só foram reconhecidas e regravadas com os valores certos.

## Armadilhas de operação (já no RUNBOOK → Troubleshooting)

- `entmakex` **não** monta `INSERT` com atributos: `entmake` do `INSERT` (com `66 . 1`), dos `ATTRIB` e do `SEQEND`; no ZWCAD o `(entlast)` depois do `SEQEND` já devolve o `INSERT`.
- Depois do `APAGAPAGINA` o ZWCAD **não executa as linhas seguintes** do `.scr`: dump, apagar e dump saem de um comando só (`vl-cmdf`).
- Erro de LISP no `-Fixture` é silencioso: carregar a fixture por um *driver* com `vl-catch-all-apply` que grava o erro num arquivo.
- Guardar o **handle** de uma entidade num cache indexado pelo `ename` quebrou a fixture (handles em branco em todo o XData); ler o handle direto, e para listar entidades já apagadas guardar a lista `(nome . ename)` e testar `vlax-erased-p`.

## Falta

- [ ] Os dois ramos do bloco `P` (`promoveComplementar`, `ApagaContatosModeloDispositivo`) — item 2 da fila.
- [ ] Medir os mesmos três ramos no AutoCAD 2020 (`scripts/cad-autocad-smoke.ps1`), se o dono quiser a prova nos dois hosts.
- [ ] Medir pelo clique da paleta (menu "Excluir Páginas"), que roda fora de comando.

## Conhecimento registrado

Nenhum fato novo do reverso (só de operação, acima).

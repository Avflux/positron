# Rodada 208 — `clsApagar.ApagarDerivados`: ramo da polyline de interligação (fila, item 2)

**Data:** 2026-10-16 · **Commit:** `*(este)*` · **Frente:** 10 — páginas e caderno · **Situação:** 🟡 parcial (1 dos 5 ramos)

## Alvo

Item 2 da fila do `ESTADO.md` (saiu da rodada 182): `clsApagar.ApagarDerivados` (`clsApagar.cs:9`), chamado pelo `Pagina.ApagarElementosPagina` (`Pagina.cs:2121`, linha `:2159`) antes do `Erase` de cada entidade da página. Sem outra passagem (grep em `docs/recoder/`).

## O que o reverso faz

`ApagarDerivados(ref Entity)` decide pelo tipo da entidade; qualquer exceção é engolida (`catch` vazio):

| entidade | ramo | chama |
|---|---|---|
| `Polyline` com `INTERLIGACAO` de `Tipo == 2` | **portado nesta rodada** | `clsInterligacao.ApagarPL(ilig.handle)` (`:2087`) |
| bloco com tipo de dispositivo `P`, `indexModelo <= 0` | fila | `clsDispositivo.promoveComplementar` (`:286`) |
| bloco com tipo `P`, `indexModelo > 0` | fila | `clsDispositivo.ApagaContatosModeloDispositivo` (`:151`) |
| tipo `A` (contato auxiliar) | fila | `clsDispositivoAuxiliares.limpaInsercaoTabela(handle)` (`:2656`) |
| tipo `M` (máscara) | fila | `clsMascara.ApagaAMascara` (`:1264`) |

`ApagarPL(handle)` (com `LockDocument`): abre a entidade do handle como `Polyline`; se ela tem `INTERLIGACAO`, chama `ApagarTextosAuxiliaresVeias(layer, handle)` e apaga a polyline.
`ApagarTextosAuxiliaresVeias(layer, handle)` (`:2005`): no layer da irmã, apaga o `DBText` cujo `AUXINTERLIG` (campo +2, `XDataInterligacao.cs:498`) é o handle (sem diferenciar caixa) e, entre as entidades que não são texto nem bloco, a que tem `ELETROSUL` (campo +3, `:513`) com o handle.
`lerXDataInterligacao` (`XDataInterligacao.cs:135`): `Tipo` no campo +1, `handle` no +9.

## O que foi feito

| arquivo | o quê |
|---|---|
| `cad-plugin/Positron.Data/Paginas/DerivadosDaExclusao.cs` | regra pura: `HandleDaIrma` (só `Tipo == 2` com handle) e `RotuloDoTrecho` (comparação sem caixa) |
| `cad-plugin/Positron.Plugin/Paginas/DerivadosDaExclusaoDoDesenho.cs` | casca CAD: polyline `Tipo 2` → irmã pelo handle + rótulos auxiliares; usa os leitores existentes (`InterligacaoXData`, `AuxInterligacaoXData`, `AuxInterligacaoEletrosulXData`); falha engolida como no original |
| `cad-plugin/Positron.Plugin/Paginas/ExclusaoDePaginaDoDesenho.cs` | chama `ApagarDerivados` antes do `Erase` de cada entidade e pula as já apagadas |
| `cad-plugin/Positron.Data.Tests/DerivadosDaExclusaoTests.cs` | +9 testes |
| `docs/RUNBOOK.md` | receita do runner xUnit (pacote 2.9.2 sem `xunit.execution.desktop.dll`) |

Desvio: roda dentro da transação da exclusão (o original abre uma aninhada por rotina; o resultado é o mesmo).

## Prova

- `plugin:test` (console xUnit na cópia do `%TEMP%`): **984** aprovados, 0 falhas (975 + 9).
- builds ZWCAD / AutoCAD: 0 avisos, 0 erros.
- CAD: não medido: sem ZWCAD; a exclusão de uma página com polyline `Tipo 2` não foi rodada no AutoCAD nem no `Funcional.dwg`.

## Falta

- [ ] Medir no AutoCAD (`Funcional.dwg`): apagar uma página com interligação `Tipo 2` pela paleta e conferir que a irmã e os rótulos saem.
- [ ] Os quatro ramos do dispositivo/contato auxiliar/máscara (tabela acima).

## Conhecimento registrado

Nenhum fato novo (os layouts de `INTERLIGACAO`/`AUXINTERLIG`/`ELETROSUL` já estavam nas classes de XData).

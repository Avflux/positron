# Rodada 210 — `clsApagar.ApagarDerivados`: ramo da máscara (fila, item 2)

**Data:** 2026-10-16 · **Commit:** `*(este)*` · **Frente:** 10 — páginas e caderno · **Situação:** 🟡 parcial (3 dos 5 ramos)

## Alvo

Item 2 da fila do `ESTADO.md`, terceiro ramo do `ApagarDerivados` (`clsApagar.cs:9`): entidade de tipo `M` → `clsMascara.ApagaAMascara` (`clsMascara.cs:1264`). Continua as rodadas 208 e 209.

## O que o reverso faz

`ApagaAMascara(entMasc)` (com `LockDocument`, transação própria; falha engolida):

1. Lê o `Dispositivo` tipo `M` da apagada (`LeXDataQualquerDispositivo`); **máscara complementar** (`Complementar`) → retorna sem fazer nada.
2. Lê os atributos `MODELO`/`FABRICANTE`/`DESCRICAO` da apagada.
3. Varre o ModelSpace por blocos tipo `M` com **mesmo painel, Nome1, Nome2 e Alternativo** (sem diferenciar caixa) e **outro handle**:
   - a **primeira** é a sucessora: `GravarXDataMascara` com o **estado da apagada**; os atributos dela que estão vazios ganham os da apagada (`MODELO` e `FABRICANTE` visíveis, `DESCRICAO` invisível — o `bliga` do `EditaUmAtributoDeUmBloco`, que também ajusta o alinhamento);
   - as **seguintes**: `HandleMascPrincipal = sucessora`, `iLM1 = iLM2 = 0`, `Topografico = Layout = ""`; o teste de atributo vazio olha o **bloco apagado** (`LeUmAtributoDeUmBloco(ref sHandle, …)`) e grava o valor dele, com `MODELO`/`DESCRICAO` invisíveis e `FABRICANTE` visível — quirk replicado como está.
4. Sem sucessora: apaga as **portas** (tipo `E`, `HandleDaMascara` = handle da apagada) e as **definições** (`Definicao` com `HandleDaMascara` = ela). Com sucessora: as mesmas passam a apontar para ela (`GravarXDataPorta`/`GravarXDataDefinicao`).

Layouts regravados (`XDataDispositivosMaster.cs`): máscara 29 valores (`:502`; leitura no ramo `M` de `:740`, índices 8/12/13/14/16/17/21/23), porta 18 valores (`:396`, leitura nos índices 2–6/9–11), definição 5 valores (`:903`/`:970`, app name `Definicao` ou o legado `DEFINICAO`).

## O que foi feito

| arquivo | o quê |
|---|---|
| `cad-plugin/Positron.Data/Paginas/ApagarMascara.cs` | regra pura: `EstadoDaMascara`/`EstadoDaPorta`/`EstadoDaDefinicao` (leitura e os layouts de 29/18/5 valores) e `ApagarMascara.Planejar` (sucessora, estado novo e atributos por máscara) + `NovoHandleDaMascara` |
| `cad-plugin/Positron.Plugin/Paginas/DerivadosDaExclusaoDoDesenho.cs` | casca CAD: tipo `M` → plano, regrava as máscaras (atributos + XData) e apaga/reaponta portas e definições |
| `cad-plugin/Positron.Data.Tests/ApagarMascaraTests.cs` | +11 testes (plano, quirk do atributo, layouts) |

Diferenças do original: a transação é a da exclusão (não uma própria); o `Draw()` explícito dos atributos não é chamado (o commit da transação redesenha); `Plaquetas`, `Modelo`, `Fabricante` e `Descricao` do `StructureMascara` não vão ao XData no original e aqui também não.

## Prova

- `plugin:test` (console xUnit na cópia do `%TEMP%`): **1008** aprovados, 0 falhas (997 + 11).
- builds ZWCAD / AutoCAD: 0 avisos, 0 erros.
- CAD: não medido: sem ZWCAD (medido; ausência = medição com data — ver RUNBOOK.md → *Existe CAD nesta máquina?*); apagar uma página com máscara não foi rodado no AutoCAD.

## Falta

- [ ] Medir no AutoCAD (`Funcional.dwg`): apagar uma página com uma máscara que tenha cópias (sucessora) e outra sem cópias (portas/definições saem); conferir o `HandleMascPrincipal`, os atributos e as portas.
- [ ] Os dois ramos do bloco `P`: `promoveComplementar` (`clsDispositivo.cs:286`) e `ApagaContatosModeloDispositivo` (`:151`).
- [ ] Conferir a ordem de leitura de `Nome1`/`Nome2` do ramo `M` do `LeXDataQualquerDispositivo` com um desenho real (os índices 2–4 foram lidos do código do ramo; o ramo da porta usa `Alternativo` no 11).

## Conhecimento registrado

`docs/recoder/conhecimento/paginas.md`: seção *XData de máscara, porta e definição* (layouts de 29/18/5 valores, índices de leitura e o `bliga` do `EditaUmAtributoDeUmBloco`).

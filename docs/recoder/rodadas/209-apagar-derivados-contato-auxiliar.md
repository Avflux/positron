# Rodada 209 — `clsApagar.ApagarDerivados`: ramo do contato auxiliar (fila, item 2)

**Data:** 2026-10-16 · **Commit:** `*(este)*` · **Frente:** 10 — páginas e caderno · **Situação:** 🟡 parcial (2 dos 5 ramos)

## Alvo

Item 2 da fila do `ESTADO.md`, segundo ramo do `ApagarDerivados` (`clsApagar.cs:9`): entidade de tipo `A` → `clsDispositivoAuxiliares.limpaInsercaoTabela(handle)`. Continua a rodada 208 (`rodadas/208-apagar-derivados-interligacao.md`).

## O que o reverso faz

- `XDataDispositivo.verificaTipoDispositivo` (`XDataDispositivo.cs:15`): campo +1 do XData `DISPOSITIVO`; sem ele, `"I"` se há `IMPORTADO`; senão vazio.
- `limpaInsercaoTabela(handle)` (`clsDispositivoAuxiliares.cs:2656`, com `LockDocument`; **sem SQL**): varre os `BlockReference` do ModelSpace; no **primeiro** cujo `Modelo` (`LerXDataModelo`) tem `HandleContatoAux` igual ao handle do contato apagado (sem diferenciar caixa), zera o texto dos atributos de tag `INSERCAO`/`INSERCAONA`/`INSERCAONF` (em maiúsculas), põe `HandleContatoAux = ""`, regrava o `Modelo` (`GravarXDataDispModelo`) e sai do laço. Depois atualiza o `frmContatosAux` se estiver aberto (`AtualizadgDisp`) — a tela não existe no plugin.
- Falha engolida pelo `catch` do `ApagarDerivados`.

## O que foi feito

| arquivo | o quê |
|---|---|
| `cad-plugin/Positron.Data/Paginas/DerivadosDaExclusao.cs` | regra pura: `TipoDoDispositivo` (DISPOSITIVO → campo +1; IMPORTADO → `I`) e `AtributoDeInsercao` |
| `cad-plugin/Positron.Plugin/Paginas/DerivadosDaExclusaoDoDesenho.cs` | despacha pelo tipo; tipo `A` → `LimparInsercaoDoModelo` (usa `ModeloXData` e a troca do registro `Modelo` já existente) |
| `cad-plugin/Positron.Plugin/Correcoes/ContatosAuxiliaresDoDesenho.cs` | `TrocandoOModelo` passa a `internal` (reuso, sem duplicar o gravador do `Modelo`) |
| `cad-plugin/Positron.Data.Tests/DerivadosDaExclusaoTests.cs` | +13 testes |

## Prova

- `plugin:test` (console xUnit na cópia do `%TEMP%`): **997** aprovados, 0 falhas (984 + 13).
- builds ZWCAD / AutoCAD: 0 avisos, 0 erros.
- CAD: não medido: sem ZWCAD; apagar uma página com contato auxiliar não foi rodado no AutoCAD.

## Falta

- [ ] Medir no AutoCAD (`Funcional.dwg`): apagar pela paleta uma página com contato auxiliar inserido num modelo; conferir os atributos zerados e o `HandleContatoAux` vazio.
- [ ] Os três ramos que sobram: bloco `P` (`promoveComplementar :286`, `ApagaContatosModeloDispositivo :151`) e máscara `M` (`ApagaAMascara :1264`).

## Conhecimento registrado

Nenhum fato novo (o layout do `Modelo` já estava em `ModeloXData`).

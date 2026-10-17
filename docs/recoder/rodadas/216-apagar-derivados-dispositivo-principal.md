# Rodada 216 — `clsApagar.ApagarDerivados`: ramos do dispositivo principal `P` (fila, item 2)

**Data:** 2026-10-16 · **Commit:** *(não commitado)* · **Frente:** 10 — páginas e caderno · **Situação:** ✅ código e medição no AutoCAD 2020; falta o clique da paleta

## Alvo

Item 2 da fila do `ESTADO.md`: os dois ramos do bloco `P` que sobravam do `ApagarDerivados` (`clsApagar.cs:40-50`).
Pedido do dono: usar o AutoCAD instalado para testar.

## O que o reverso faz

Caminhos relativos a `cad-plugin/reverso/Eletron4_ZWcad/decompiled-cleaned/Eletron4/`.

- **Entrada:** `clsApagar.ApagarDerivados` (`clsApagar.cs:9`) com entidade tipo `P`: se `indexModelo <= 0` → `clsDispositivo.promoveComplementar`; senão → `clsDispositivo.ApagaContatosModeloDispositivo` (`clsApagar.cs:40-50`).
- **`promoveComplementar` (`clsDispositivo.cs:286`):** para cada bloco `P` do ModelSpace com handle diferente da apagada e mesmos Nome1/Nome2/Alternativo (sem caixa) que é complementar, e só se a apagada **não** é complementar: o primeiro casamento perde o `Complementar` (regrava o XData `Dispositivo` com `GravarXDataDispPrincipal`, `XDataDispositivosMaster.cs`) e o laço para (`break`).
- **`ApagaContatosModeloDispositivo` (`clsDispositivo.cs:151`):** para cada bloco do ModelSpace:
  - tipo `A` (contato auxiliar) com `HandleBob` = handle da apagada → apaga;
  - tipo `P` (handle diferente) com mesmo painel, Nome1, Nome2, Alternativo e complementar → apaga;
  - demais tipos com o XData `Modelo` cujo `HandleBob` = handle da apagada → apaga.
- **Erro:** o `ApagarDerivados` engole qualquer exceção (`catch` vazio).

## O que foi feito

| arquivo | o quê |
|---|---|
| `cad-plugin/Positron.Data/Paginas/ApagarDispositivo.cs` | regra pura: `HandleAPromover` e `HandlesDosContatosDoModelo` sobre a lista de `Bloco` |
| `cad-plugin/Positron.Data.Tests/ApagarDispositivoTests.cs` | +7 testes (promoção, não-promoção, contatos por tipo e painel) |
| `cad-plugin/Positron.Plugin/Paginas/DerivadosDaExclusaoDoDesenho.cs` | casca: ramo `P` (`ApagarDoDispositivoPrincipal`), leitura dos blocos (`LerBloco`), promoção (`PromoverComplementar`) e apagar contatos (`ApagarContatosDoModelo`) |
| `scripts/cad-fixture-apagar-derivados.lsp` | casos P: PP1/PC1 (promoção), PP2/PC2/PX2/MD2 (contatos do modelo); `entget` no lugar de `vlax-erased-p` (quebrava no AutoCAD) |

Desvio do original: `promoveComplementar` regrava o XData **inteiro** a partir do que leu (`GravarXDataDispPrincipal`). Aqui só mudam o campo 13 (Complementar) e os campos 24/25 (usuário/data), e o resto do XData fica como está, porque o leitor (`DispositivoFiacaoXData`) não guarda todos os campos. O resultado para os campos lidos é o mesmo.

## Prova

- `plugin:test` (xunit console, cópia no `%TEMP%`): **1049** aprovados, 0 falhas (1042 + 7).
- builds ZWCAD (`plugin:build:zwcad`) e AutoCAD (`plugin:build:autocad`): 0 avisos, 0 erros.
- CAD: **AutoCAD 2020** (`cad-autocad-smoke.ps1`, `Funcional.dwg`, `APAGAPAGINA` da página 16). Trecho do dump depois da exclusão:

```text
PP1;APAGADO                       (promovida a origem: indexModelo 0)
PC1;layer=15  XD;Dispositivo;P|PN|PM|...|0|0|...|RNO|16/10/2026 23:10:59   (Complementar -1 -> 0)
PP2;APAGADO                       (indexModelo 3)
PC2;APAGADO                       (complementar de mesmo nome, saiu)
PX2;layer=15  XD;Dispositivo;P|XN|XM|...|0|-1   (outro nome: ficou)
MD2;APAGADO                       (Modelo com bob = PP2)
MO;layer=15  XD;Modelo;1A|5|2||   (contato auxiliar A1 apagado: HandleContatoAux limpo, rodada 209)
P1, A1, M1, M4, E2, D2: APAGADO   (ramos das rodadas 208-210 seguem iguais)
```

- ZWCAD 2026: não medido nesta rodada — ausente nesta máquina (medição de hoje, ver RUNBOOK → *Existe CAD nesta máquina?*).
- Falha de ambiente encontrada: a primeira medição não saiu do cabeçalho do dump porque `vlax-ename->vla-object` quebrou no `accoreconsole` do AutoCAD; trocado por `entget` dentro de `vl-catch-all-apply`. A segunda falha foi da fixture (o `x-modelo` punha o bob no campo errado); corrigida na própria fixture, não no código.

## Falta

- [ ] Medir pelo clique da paleta (menu "Excluir Páginas"), que roda fora de comando, com um desenho que tenha um complementar e um principal de modelo.
- [ ] Medir no ZWCAD 2026, se ele voltar a ser instalado (ausente em 2026-10-16).
- [ ] Commit da rodada (ainda não commitado).
- [ ] Conferir visualmente a visibilidade de `DESCRICAO` da máscara promovida no AutoCAD: o dump mostra `vis60=1` na M2, que é a mesma regra da rodada 210, mas não foi medida na GUI.

## Conhecimento registrado

Nenhum fato novo do reverso. Operação (no RUNBOOK → Troubleshooting): `vlax-ename->vla-object` quebra no `accoreconsole` do AutoCAD 2020; usar `entget`.

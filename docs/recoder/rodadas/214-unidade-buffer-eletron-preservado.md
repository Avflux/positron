# Rodada 214 — a unidade/alternativo conserva o buffer `Eletron` do layer

**Data:** 2026-10-16 · **Commit:** *(este)* · **Frente:** correção do básico, item 3 (paleta fiel) · **Situação:** ✅ completa

## Alvo

Item 1 da fila do `ESTADO.md` (fechar os recortes da rodada 183), o último recorte **de código**: a
preservação das extensões no buffer `Eletron`. O adapter do recoder **recriava os quatro valores** a
cada gravação — o que apaga silenciosamente tudo o que o desenho tiver além deles.

## O que o reverso faz

Caminhos relativos a `cad-plugin/reverso/Eletron4_ZWcad/decompiled-cleaned/Eletron4/`.

- **A gravação tem dois caminhos** (`XDataGeral.cs`):
  - `GravarXDataUnidadeAlternativo` (`:1085-1124`): cria a marca **do zero** — monta um
    `TypedValue[4]` (`1001 "Eletron"`, `1000 "Unidade"`, `1000 unidade`, `1000 alternativo`) e
    atribui `layer.XData`. É o caminho de quando **não há** XData.
  - `AlteraXDataUnidadeAlternativo` (`:1243-1296`): varre a `LayerTable` atrás do layer da página
    (comparação de nome **sem caixa**), faz `UpgradeOpen`, e então:
    - `GetXDataForApplication("Eletron") == null` → chama o `Gravar` acima;
    - XData existe e `array[1].Value.ToString().ToUpper() == "UNIDADE"` → **troca só as posições 2 e
      3** (`array[2]`/`array[3]`) e regrava o **mesmo** `array` (`new ResultBuffer(array)`);
    - XData existe com **outra** marca → o `if` **não tem `else`**: nada é escrito.
- **A consequência é o buffer conservado:** tudo o que estiver nas posições 0, 1 e da 4 em diante —
  inclusive valores com **outro código** de grupo (1070/1040…) — volta intacto. É o que o campo
  `EXTRA` medido abaixo exige.
- **A leitura** (`LeXDataUnidadeAlternativo`, `:1136`) também checa a marca em `array[1]` antes de ler
  `array[2]`/`array[3]`, e o original **indexa direto**: um buffer com menos de quatro valores
  estouraria lá.
- **A gravadora abre o `LockDocument`** (a escrita vem da paleta): o recoder já fazia isso.

## O que foi feito

| arquivo | o quê |
|---|---|
| `cad-plugin/Positron.Data/Paginas/UnidadeDaPaginaXData.cs` | `EhMarcaUnidade` (app + marca, sem caixa) e **`Atualizar(existentes, unidade, alternativo)`**: `null`/sem XData → os quatro valores novos; XData da marca → troca **só** as posições 2 e 3 sobre uma **cópia** do que existe; outra marca → `null` (nada a escrever) |
| `cad-plugin/Positron.Plugin/Paginas/UnidadeDaPaginaDoDesenho.cs` | o `Gravar` lê o XData do layer (`GetXDataForApplication`), passa pelo `Atualizar` e só escreve quando ele devolve valores — com outra marca o layer fica **intocado** |
| `scripts/cad-fixture-unidade-buffer.lsp` | fixture opt-in: acrescenta **dois valores extras** (`1000 "EXTRA-214"`, `1070 214`) ao XData `Eletron` do layer `6` e despeja o `Eletron` dos layers `6`/`7`/`7A` antes e depois do comando (leitura independente, `entget`) |
| `cad-plugin/Positron.Data.Tests/UnidadeDaPaginaTests.cs` | +5 testes (1025) |

**Desvio declarado:** com o buffer da marca **curto** (menos de quatro valores) o recoder o
**completa** até os quatro em vez de estourar como o original; a leitura já era tolerante. Ficou
fixado em teste.

## Prova

- Console xUnit 2.9.2 em `%TEMP%/pm214b`, bin completo: **1025**, Errors **0**, Failed **0**,
  Skipped **0** (+5). `npm run plugin:test`: **0 testes** — falha conhecida do adaptador VSTest
  (não é passe).
- Builds finais ZWCAD / AutoCAD: **0 avisos, 0 erros**.
- **AutoCAD 2020** (`accoreconsole`, cópia do `Funcional.dwg`, rodada 63): sentinela posta no layer
  `6` (**com** os dois valores extras), dump independente **antes** e **depois** do `UNIDADE`:

```text
UNIDADE: pagina "6" — unidade="UNIFILAR", alternativo="" — regravado para unidade="UNIDADE NOVA 214", alternativo="ALT NOVO 214".
```

```text
===== ANTES =====
LAYER;6;eletron=((1000 . Unidade) (1000 . UNIFILAR) (1000 . ) (1000 . EXTRA-214) (1070 . 214))
LAYER;7;eletron=((1000 . Unidade) (1000 . UNIFILAR) (1000 . ))
===== DEPOIS =====
LAYER;6;eletron=((1000 . Unidade) (1000 . UNIDADE NOVA 214) (1000 . ALT NOVO 214) (1000 . EXTRA-214) (1070 . 214))
LAYER;7;eletron=((1000 . Unidade) (1000 . UNIFILAR) (1000 . ))
```

  As posições 2 e 3 mudaram e os **dois valores extras continuam no buffer**, com o código de grupo
  deles; o layer `7` (que o comando não toca) sai igual. Com o adapter anterior o `ResultBuffer`
  novo teria **quatro** valores e o `EXTRA-214`/`1070 214` sumiria — é a diferença que este teste
  mede.
- **Não medido:** o **clique na paleta** (a gravação foi pelo comando `UNIDADE` com o
  `POSITRON_PAGINA`/`POSITRON_UNIDADE`/`POSITRON_ALTERNATIVO` do harness — o mesmo `Gravar` que a
  paleta chama); o **ZWCAD**, verificado ausente nesta máquina nesta data (registro + pastas +
  `where`; receita no `RUNBOOK.md` → *Existe CAD nesta máquina?*).

## Falta

- [ ] Clique/edição da unidade pela **paleta com janela** (a gravação em si está provada).
- [ ] Repetir no **ZWCAD** quando ele estiver nesta máquina (verificar antes de afirmar ausência).
- [ ] Restantes do item 1 da fila: Excel ativo, status do banco pelo contador de conexões
  (`statusBanco`/`monitorConexao`), progresso compartilhado, título 4/D/A/V e atalhos em GUI, e a
  saída anômala do `acad.exe`.

## Conhecimento registrado

`conhecimento/paginas.md`: o XData `Eletron` do layer tem **dois modos** de escrita (criar vs
atualizar) e a atualização **conserva** o buffer — o que decide entre os dois é a existência do
`ResultBuffer` da marca. `docs/RUNBOOK.md` (*Troubleshooting*): `(car (assoc -3 d))` **não** é o
XData — é a chave `-3`; o valor (a lista marcada com o app name) sai de `(cadr (assoc -3 d))`, e o
erro no `append` faz o load do `.lsp` estourar e os `defun` seguintes nem existirem.

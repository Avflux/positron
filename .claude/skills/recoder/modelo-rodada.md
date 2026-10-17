# Rodada NNN — <alvo em uma linha>

**Data:** AAAA-MM-DD · **Commit:** `<hash>` · **Frente:** <n — nome> · **Situação:** ✅ completa | 🟡 parcial | ⛔ bloqueada

## Alvo

Comando(s)/tela(s) do reverso e por que este item (fila do `ESTADO.md`, pedido do dono…).

## O que o reverso faz

Ficha do comportamento original, com `arquivo:linha` (caminhos relativos a
`cad-plugin/reverso/Eletron4_ZWcad/decompiled-cleaned/Eletron4/`).

- **Entrada / cadeia:** `Classe.Metodo` → `...` → folhas.
- **Lê:** XData (app + layout), dicionários, tabelas/colunas, `Conf.*`.
- **Grava / efeitos:** desenho, banco, arquivos; o que apaga, recria, ativa.
- **Ramos e quirks:** `switch` por cliente/layout, valores mágicos, comportamento estranho mantido.
- **Mensagens:** texto exato.
- **Apelidos de ofuscados:** `xYz123` = o que faz.
- **Tela / janela (se houver):** conferir se já foi ajustada (rodadas anteriores); captura em `cad-plugin/reverso/captura_das_janelas/` vs recode.

## O que foi feito

| arquivo | o quê |
|---|---|
| `cad-plugin/Positron.Data/...` | regra pura |
| `cad-plugin/Positron.Plugin/...` | casca CAD / comando / tela |
| `cad-plugin/Positron.Data.Tests/...` | +N testes |

Desvios do original (com motivo), se houver.

## Prova

- `plugin:test`: **N** (+n) — total conferido > 0.
- builds ZWCAD / AutoCAD: 0 avisos, 0 erros.
- CAD (`<host>`, `<desenho>`): linha de resumo do comando colada abaixo — ou *não medido: motivo*.
- **Ausência é afirmação medida:** ao escrever "não medido" por falta de CAD/host/arquivo, **meça
  antes** (registro + pastas + `where`; `RUNBOOK.md` → *Existe CAD nesta máquina?*) e escreva a
  ausência **com data**. Nunca herde "não existe" de uma rodada anterior — inclusive do `RUNBOOK`
  (as rodadas 176–180 afirmaram que o AutoCAD 2020 não estava instalado e ele **está**).

```
<saída>
```

## Falta

O que ficou de fora **com o motivo** — cada item também foi para a fila do `ESTADO.md`.

- [ ] …

## Conhecimento registrado

Temas atualizados em `docs/recoder/conhecimento/` (ou "nenhum fato novo").

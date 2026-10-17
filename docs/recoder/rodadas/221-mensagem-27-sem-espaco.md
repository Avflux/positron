# Rodada 221 — A mMensagem 27 ("Não há espaço suficiente!") medida no CAD

**Data:** 2026-10-17 · **Commit:** *(este)* · **Frente:** correção do básico, item 3 (paleta `uscPaginas`) · **Situação:** ✅ completa

## Alvo

O último recorte **sem GUI** do item 1 da fila (`Fechar a rodada 183`), o que a rodada 186 deixou
aberto por escrito: *"Mensagem 27 (sem espaço) não medida no CAD: precisa de 27 linhas selecionadas e o
`Funcional.dwg` tem 16 páginas — coberta por teste unitário"*. A regra já estava portada e provada na
regra pura e pelo clique no menu (186), mas a **recusa** nunca tinha saído de uma medição no CAD: a
mensagem, a volta ao prompt e o "nada foi renomeado".

A rodada mostrou que a premissa da 186 estava **errada** (ver *O que o reverso faz*, quirk (b)) — e com
isso a medição coube numa cópia do `Funcional.dwg` de 16 páginas.

## O que o reverso faz

Caminhos relativos a `cad-plugin/reverso/Eletron4_ZWcad/decompiled-cleaned/Eletron4/`.

- **O laço e as quatro recusas.** `uscPaginas.cs:2247-2390` (o `C8Op1CM1YgS`): prompt `mMensagem[1,24]`
  com `AllowSpaces = false`, só o `Status 5100` prossegue; a resposta é `ToUpper()` +
  `montaNumeroPagina` (`:2286-2299`). Então, nesta ordem: `checaCapa` → **57**; alvo entre as
  **selecionadas** → **26**; alvo que já é outra página → **25**; e, depois dos dois espaços, **27**
  (`Interaction.MsgBox(mMensagem[1,27], MsgBoxStyle.Information)`, `:2353`). Os quatro `MsgBox` são
  **Information** (não crítico) e cada um dá `break` — o que devolve o fluxo ao `while (true)` do prompt:
  a pergunta é **repetida**, não abortada.
- **O limite do espaço.** `p = "1000000"`; no laço sobre as **não selecionadas**, na ordem da grade, a
  primeira cujo `Cells[4]` (a página **decimal**) é maior que o destino vira o limite (`:2329-2340`).
- **A conta.** `calculaEspacoNumerico` (`Pagina.cs:305-311`) e `calculaEspacoAlfaNumerico` (`:313-350`),
  testadas com `>=` contra o número de selecionadas; a segunda só entra quando a primeira não cabe, e se
  ela também não couber sai a **27** (`:2341-2355`). O alfanumérico conta **27 nomes por número** — a
  página "seca" (64 = `'A' - 1`) e as 26 letras, com `91 - letraA` no fim da faixa.
- **Quirks que a medição tinha de encostar:**
  - **(a)** O espaço é medido **até a próxima página não selecionada**, não até o fim do caderno: do
    destino `5` com o limite `6` cabem 1 numérica e 27 alfanuméricas — duas já caem no ramo
    alfanumérico (`5`, `5A`).
  - **(b)** O espaço alfanumérico **não depende do tamanho do caderno**: um destino numérico cujo limite
    é a **letra vizinha** (`5` com limite `5A`) esgota os dois espaços com **duas** selecionadas — 1
    numérica (`floor(5,65) - 5 + 1`) e 1 alfanumérica (de 64 a 65). A premissa da 186 ("precisa de 27
    linhas selecionadas") vale só para o outro extremo: com o limite numérico na página seguinte (`3`
    com limite `4`) o alfanumérico dá exatamente 27 (`91 - 64`), então **27 cabe e 28 não**.
  - **(c)** Na recusa, **nada** é renomeado — o `renumerarPaginasLote` só é alcançado depois dos dois
    `if` de espaço.
- **Mensagens:** `mMensagem[1,27]` = **"Não há espaço suficiente!"** (`MensagensDoReverso.NaoHaEspacoSuficiente`).

## O que foi feito

Nem uma linha de código de produto mudou: a regra (`RenumeracaoComDestino.Planejar`) e a casca
(`FolhasControle.RenumerarSelecionadas`) já faziam exatamente isto desde a 186. O que faltava era a
**medição** — e para ela o instrumento:

| arquivo | o quê |
|---|---|
| `scripts/cad-fixture-msg27.lsp` | **novo**: monta o desenho das duas rotas por `POSITRON_MSG27_MODO` — `letra` cria o layer `5A` (a fronteira com **2** selecionadas) e `trinta` cria as páginas `1..31` **menos a `3`** (o destino livre; com ela a recusa seria a 25), com o dump independente em AutoLISP (`pz27:dump-para`) lido da tabela de LAYERS |
| `cad-plugin/Positron.Data.Tests/RenumeracaoComDestinoTests.cs` | +1 caso: `A_letra_vizinha_esgota_os_dois_espacos_com_duas_selecionadas` — o formato da rota `letra` (`"5"` com limite `"5A"`: 2 recusa, 1 aplica `5`), que não existia nos testes (os da 186 partem de uma letra no destino) |

Nada a desviar do original. A fixture é a mesma receita das outras: o desenho é uma **cópia** (o harness
copia o `-Desenho`), o comando roda no caminho do usuário (o clique no item do menu) e as respostas vêm
só da fila do harness.

## Prova

- Console xUnit 2.9.2 em cópia do `bin` no `%TEMP%` (`pm221`): **1083** aprovados (1082 + 1), `Errors: 0,
  Failed: 0, Skipped: 0`, em **3,7 s**.
- Builds contra as APIs reais: **ZWCAD 0 avisos/0 erros** e **AutoCAD 0 avisos/0 erros** (nenhum código
  de produto mudou; o log da medição registra a DLL de `2026-10-17 10:32`, a do build final).
- **AutoCAD 2020** (`accoreconsole`, cópia do `Funcional.dwg`, banco do ensaio 220), três passagens —
  **repetidas depois do build final**, com o mesmo resultado (a saída colada é a da repetição). Logs em
  `.tmp-smoke/provas/221/` (`cad-letra.log`, `cad-trinta28.log`, `cad-trinta27.log`) com os dumps
  `paginas-{letra,trinta28,trinta27}-{antes,depois}.txt`.

  1) **Rota da letra vizinha** (`-Fixture scripts/cad-fixture-msg27.lsp`, `POSITRON_MSG27_MODO=letra`,
     `POSITRON_FOLHA_ACAO=renumerar`, `POSITRON_FOLHA_SELECIONADAS=6,7`, `POSITRON_MOVER_PARA="5;5"`).
     A fila tem **duas** respostas iguais de propósito: a segunda é respondida porque a primeira
     **voltou a perguntar** — é o `break` do `MsgBox` voltando ao `while (true)`:

```text
Não há espaço suficiente!
Não há espaço suficiente!
pzFolhas: 17 página(s) na grade [1 | 2 | 5A | 6 | 7 | 8 | 15 | 16 | 17 | 18 | 19 | 20 | 21 | 22 | 23 | 24 | 1000];
  combo="12" (antes: 17); seleção pedida [6 | 7] (2 achada(s)); selecionada depois [7 | 6];
  ação "renumerar" → clique no menu → Renumerar Páginas: cancelado (nenhuma página foi movida).;
  ... tbPagina=23; multiseleção=True; controles=11
```

     O dump independente é **idêntico** antes e depois (17 páginas, `TOTAL;17`): as duas recusas não
     renomearam nada, e a `5A` criada pela fixture continua `5A` (`xdata=ausente`). A fila esgotada
     depois da segunda recusa cancela — é o caminho do `Status 5100` (Esc) do prompt do original.

  2) **A fronteira 27/28, forma literal da premissa da 186** (`POSITRON_MSG27_MODO=trinta`, caderno
     `1..31` sem a `3` + a `1000`, destino `3` com a `4` de limite). **28** selecionadas:

```text
Não há espaço suficiente!
pzFolhas: 31 página(s) na grade [1 | 2 | 4 | 5 | 6 | 7 | 8 | 9 | 10 | 11 | 12 | 13 | 14 | 15 | 16 | 17 |
  18 | 19 | 20 | 21 | 22 | 23 | 24 | 25 | 26 | 27 | 28 | 29 | 30 | 31 | 1000]; combo="12" (antes: 31);
  seleção pedida [2 | 5 | 6 | … | 31] (28 achada(s)); selecionada depois [31 | 30 | … | 2];
  ação "renumerar" → clique no menu → Renumerar Páginas: cancelado (nenhuma página foi movida).; …
```

     Dump idêntico antes/depois (`TOTAL;31`). É o `27 >= 28` falso dos dois espaços (numérico 0,
     alfanumérico 27) — o número da fila, medido.

  3) **27 cabe** (mesma cópia, `POSITRON_FOLHA_SELECIONADAS` = as mesmas menos a `31`) — a contraprova de
     que a recusa do ensaio 2 é a fronteira e não um defeito:

```text
pzFolhas: 31 página(s) na grade [1 | 3 | 3A | 3B | 3C | 3D | 3E | 3F | 3G | 3H | 3I | 3J | 3K | 3L | 3M |
  3N | 3O | 3P | 3Q | 3R | 3S | 3T | 3U | 3V | 3W | 3X | 3Y | 3Z | 4 | 31 | 1000]; combo="12" (antes: 31);
  seleção pedida [2 | 5 | 6 | … | 30] (27 achada(s)); selecionada depois [3S];
  ação "renumerar" → clique no menu → Renumerar Páginas: 27 de 27 página(s) movida(s) a partir de "3"
  (2->3, 5->3A, 6->3B, 7->3C, 8->3D, 9->3E, 10->3F, 11->3G, 12->3H, 13->3I, 14->3J, 15->3K, 16->3L,
  17->3M, 18->3N, 19->3O, 20->3P, 21->3Q, 22->3R, 23->3S, 24->3T, 25->3U, 26->3V, 27->3W, 28->3X,
  29->3Y, 30->3Z).; … tbPagina=3S; multiseleção=False
```

     Nenhuma mensagem de recusa: o ramo alfanumérico aplicou (a grade depois já vem lida do desenho, com
     `3, 3A..3Z`). Dump independente:

```text
PAGINA;1;xdata=((1000 . Unidade) (1000 . CAPA) (1000 . ))
PAGINA;3;xdata=((1000 . Unidade) (1000 . ÍNDICE) (1000 . ))
PAGINA;3D;xdata=((1000 . Unidade) (1000 . TRIFILAR) (1000 . ))
PAGINA;3K;xdata=((1000 . Unidade) (1000 . ALIMENT. 125Vcc) (1000 . ))
PAGINA;3S;xdata=((1000 . Unidade) (1000 . ILUM. E AQUEC.) (1000 . ))
PAGINA;3B;xdata=((1000 . Unidade) (1000 . UNIFILAR) (1000 . ))
PAGINA;3C;xdata=((1000 . Unidade) (1000 . UNIFILAR) (1000 . ))
PAGINA;4;xdata=ausente
PAGINA;3A;xdata=ausente
…
PAGINA;31;xdata=ausente
TOTAL;31
```

     O XData `Eletron` viajou com o rename (a `3` é o ÍNDICE que era a `2`, a `3K` o ALIMENT. 125Vcc que
     era a `15`, a `3S` o ILUM. E AQUEC. que era a `23`), a `4` e a `31` ficaram como estavam, e as
     páginas criadas pela fixture continuam sem XData — como no original. O arquivo do dump sai em
     ANSI (o AutoLISP grava assim): os acentos aparecem quebrados lá, e aqui estão transcritos.

- Limpeza: as cópias (desenho e `.db`) ficaram em `%TEMP%`/`.tmp-smoke` e o original nunca foi aberto para
  escrita; nenhum `acad`/`accoreconsole` restante depois das três passagens.

## Falta

- [ ] **A aparência do `MsgBox` na tela** segue não auditada: a sessão roda com `POSITRON_LOG` e, nesse
  recorte, o `Aviso` grava no log em vez de abrir o diálogo (`Aviso.Mostrar`). O que está provado é o
  texto, a ordem, a repetição do prompt e o "nada renomeado".
- [ ] **ZWCAD**: repetir quando ele voltar. **Ausência remedida nesta data** (2026-10-17: registro sem
  entrada ZWSOFT, sem `C:\Program Files\ZWSOFT`, `where.exe ZWCAD.exe` vazio); o **AutoCAD 2020** está
  lá e rodou as três passagens.
- [ ] O resto do item 1 da fila continua como estava, e é todo ele de **GUI**: o clique físico na paleta
  visível, o título 4/D/A/V e os seis atalhos em GUI, a saída anômala do `acad.exe` e o foco do
  `frmConfiguracaoBDProjeto` no arranque.

## Conhecimento registrado

`docs/recoder/conhecimento/paginas.md`: seção nova do espaço da movimentação — a ordem das quatro
recusas com os números das mensagens, o `Information` que **repete** o prompt, o limite pela primeira
não selecionada, as duas contas com a aritmética de 27 por número e as duas fronteiras (a letra vizinha
com 2 selecionadas e o número vizinho com 27), além da receita da fixture para montar cada uma.

A mesma correção de premissa entrou no `RUNBOOK.md`, junto da receita de medição, e o item da 186 foi
marcado como medido em `rodadas/186-renumerar-paginas-e-combo.md`.

# Rodada 186 — Renumerar Páginas (destino informado) e a ação do combo Folha

**Data:** 2026-10-15 · **Commit:** *(este)* · **Frente:** correção do básico, item 3 (paleta fiel ao
`uscPaginas`) · **Situação:** ✅ completa (com as faltas listadas)

## Alvo

Fila item 1 (fechar os recortes da 183/184), na parte da **paleta**: os dois caminhos de renumeração do
menu `uscPaginas` que ainda estavam desligados — o item **Renumerar Páginas** (o `C8Op1CM1YgS`, que move
as linhas selecionadas a partir de um número informado) e a **ação do combo `Folha`** (o `Es6p1Y15jTb`,
que grava a largura fixa e renormaliza o caderno inteiro). O item estava `Enabled = false` com o
comentário "C8Op1CM1YgS (lote a partir de número informado) ainda não portado" e o combo não tinha
`TextChanged` ("a regra não foi portada").

Critérios: nenhum prompt/controle/configuração novos além dos do reverso; refusar a capa, o destino que
já é página (com as duas mensagens distintas do original) e o destino que não cabe; nome novo calculado
pelas duas famílias do original (numérica com `Conf.PassoPagina`, alfanumérica com a aritmética de 27);
largura fixa gravada no XData de configuração do desenho; GUI medida pelo caminho do usuário.

## O que o reverso faz

Caminhos relativos a `cad-plugin/reverso/Eletron4_ZWcad/decompiled-cleaned/Eletron4/`.

### `C8Op1CM1YgS` — o item `Renumerar Páginas` (`uscPaginas.cs:2247-2390`)

- **Entrada:** o clique no `RenomearPáginasToolStripMenuItem`, cujo **texto** o construtor troca pela
  `mMensagem[1,22]` = "Renumerar Páginas" (o nome do campo mente; a rodada 129 já corrigira o rótulo).
- **Monta as duas listas:** se `dg.Rows[0].Selected`, **desmarca** a primeira linha; depois percorre
  `dg.Rows` **na ordem da grade** e joga a linha em `array2` (as **selecionadas**, com um terceiro campo
  vazio para o nome novo) ou em `array` (as outras). É a ordem da grade que casa cada página com o seu
  nome novo — ao contrário do `Inserir` e do `Apagar`, que percorrem `dg.SelectedRows`.
- **Prompt, dentro de um laço** (`:2286-2390`): SetFocus na janela do documento
  (`hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF`), `PromptStringOptions("\n" + mMensagem[1,24] + " ")` com
  `AllowSpaces = false` e **sem** `DefaultValue`; `Editor.GetString`. Só `Status == 5100` prossegue (o
  cancela sai do laço). A resposta é `ToUpper()` e depois `Pagina.montaNumeroPagina` (que dá o `Trim`).
- **Recusas, e volta ao prompt** (é a única pergunta da paleta que o original repete):
  `checaCapa(alvo)` → `MsgBox` mMensagem **57** ("Não é possível mover sobre a Capa!");
  alvo igual a uma **selecionada** → **26**; alvo igual a outra página → **25**; espaço insuficiente → **27**.
- **O limite do espaço** (`p`): a **primeira** linha não selecionada, **na ordem da grade**, cuja página
  decimal é maior que a do destino; sem nenhuma, o sentinela `"1000000"`.
- **Os nomes novos:** `Pagina.calculaEspacoNumerico(alvo, p) >= mPagSel` (as selecionadas) → o ramo
  numérico (`definePaginasNumericas`); senão `calculaEspacoAlfaNumerico(alvo, p) >= mPagSel` → o
  alfanumérico (`definePaginasAlfaNumericas`); senão mMensagem 27 e volta ao prompt.
  - `definePaginasNumericas` (`Pagina.cs:352-382`): do destino (ou do número **seguinte** quando o destino
    tem letra: `Floor(calculaPaginaDecimal) + 1`) em diante, de `Conf.PassoPagina` em diante; cada nome
    passa pelo `montaNumeroPagina` (a largura fixa).
  - `definePaginasAlfaNumericas` (`:384-425`): `Asc` da última letra e o resto como número; a cada `Z`
    (`Asc == 91`) volta para 64 (a página "seca", sem letra) e o número sobe. Vazio ou prefixo não
    numérico **estoura** ali dentro (o `Strings.Mid("", 0, 1)` e o `Conversions.ToInteger`).
- **Grava:** `Pagina.renumerarPaginasLote` (`:1964-2036`): `LockDocument` + uma transação; para cada item,
  `LayerTable.Has` e `Layer.Name = novo`; depois `CarregaPaginas`, `OrdenaMatrizPaginas`,
  `AtualizaContTotFl`. **Só o nome do layer muda** — os elementos da página e o XData `Eletron` do layer
  ficam como estão.
- **Fecha:** `Y9op1KgeRgW(); VSWp1ebyWra();` (a grade é reconstruída da matriz, a multiseleção volta
  desligada e a linha da página ativa é reselecionada) e a cascata de sincronizações
  (`clsConexao.sincronizaCircuitos`, `clsInterligacao.SincronizaCruzamentoInterlig`,
  `clsDePara.SincronizaDePara(false)`, `clsDispositivoAuxiliares.SincronizaContatos`,
  `clsPortas.SincronizaPortas`). `DeclaracoesGeral.ativo.Pagina` **não** é recalculado aqui (só o combo o
  recalcula): a grade fica com a seleção antiga se `ativo.Pagina` não casar mais.
- **Quirk mantido:** com **nenhuma** linha selecionada o laço do prompt fica **fora** do
  `If dg.SelectedRows.Count > 0` — o original pergunta do mesmo jeito e o `renumerarPaginasLote` não tem o
  que renomear (o primeiro caso medido aqui: "0 de 0 página(s)"). Desmarcar a linha 0 (a capa) é o outro
  lado disso: clicar em Renumerar com a capa selecionada não faz nada.

### `Es6p1Y15jTb` — o `TextChanged` do combo `Folha` (`uscPaginas.cs:2389-2455`)

- **Entrada:** `FolhaToolStripMenuItem.TextChanged` (o combo é **editável**), com a guarda `fKqplRiGop5`
  que o `CarregaPG` deixa ligada enquanto escreve o texto (`:1326-1360`).
- **O `switch` do literal:** `12` → largura **0**, `012` → 3, `0012` → 4, `00012` → 5, `000012` → 6,
  `0000012` → 7 — cada comparação com `TextCompare: true`, e **sem `default`**: texto fora dos seis
  literais **não** mexe na largura (mas o resto do corpo roda igual).
- **Grava:** `XDataGeral.GravarXDataConfiguracao()` — o XData `Eletron`/`Config` do **ModelSpace**
  (`XDataGeral.cs:460-500`, o `1070` da posição 34 é a largura).
- **Renomeia:** monta a matriz de **todas** as linhas (`array[0]` = nome atual, `array[2]` =
  `montaNumeroPagina(nome)`), escreve o nome novo de volta nas células 0 e 3, e chama
  `Pagina.renumerarPaginasLote`.
- **Fecha:** `DeclaracoesGeral.ativo.Pagina = Pagina.LocalizaPaginaAtiva()` (aqui **é** recalculada),
  `cmStrip1.Hide()` e `Application.UpdateScreen()`. `CarregaPG` não é chamado (a grade fica como estava,
  com os nomes novos).
- **Erros** (`FIA`/`INT` do banco, nome repetido de layer) saem no `MsgBox` crítico do `catch`.

## O que foi feito

| arquivo | o quê |
|---|---|
| `cad-plugin/Positron.Data/Paginas/RenumeracaoComDestino.cs` | regra pura nova: `Planejar` (normalização do prompt, capa/existe/não cabe, o limite da grade), `Numericas`, `AlfaNumericas`, `Normalizar` (o corpo do combo) e `LarguraDoFormatoLiteral` |
| `cad-plugin/Positron.Data/Interface/MensagensDoReverso.cs` | mMensagem 24, 25, 26, 27 e 57 (texto exato) |
| `cad-plugin/Positron.Data.Tests/RenumeracaoComDestinoTests.cs` | +18 casos |
| `cad-plugin/Positron.Plugin/Interface/Folhas/FormularioDaPagina.cs` | `PerguntaDeRenumeracao`: o prompt `AllowSpaces = false` sem padrão, com o SetFocus e a fila do harness |
| `cad-plugin/Positron.Plugin/Interface/RespostaDoHarness.cs` | fila `POSITRON_MOVER_PARA` (separada por `;`): a recusa **volta a perguntar** e a fila prova a resposta seguinte; fila esgotada **cancela** (um script não pode girar para sempre) |
| `cad-plugin/Positron.Plugin/Interface/Folhas/FolhasControle.cs` | liga o item `Renumerar Páginas` ao handler; `TextChanged` do combo com a guarda da carga; `RenumerarSelecionadas`, `AplicarFormatoDaNumeracao`, `EscolherFormatoDaNumeracao`, `Pares` |
| `cad-plugin/Positron.Plugin/Comandos.cs` | `SincronizacoesDoCaderno()` extraído (o mesmo stand-in que o `Apagar Páginas` já usava) |
| `cad-plugin/Positron.Plugin/Interface/Folhas/ProvaDaPaleta.cs` | ações `renumerar` (clique **no item do menu**, não chamada direta), `formato:LITERAL` (escolha no combo) e `renumerar-interface` (Timer fora de comando) |
| `cad-plugin/README.md` | a linha do `PAG`/`pzFolhas` |
| `scripts/cad-fixture-renumerar.lsp` | dump independente dos layers de página e do XData `Eletron` deles |

**Desvios do original (com o motivo):**

- **O nome novo de cada linha vem da ordem da grade.** A primeira medição usou `dg.SelectedRows` (a ordem
  que o `Inserir`/`Apagar` do original usam) e o resumo saiu `(6->3, 2->4)` para as páginas 2 e 6; o
  original casa pela ordem de `dg.Rows`, então o handler passou a montar as duas listas num único laço
  sobre a grade. Medido depois: `(2->3, 6->4)`.
- **Destino que o original não converte** (vazio, ou prefixo não numérico no ramo alfanumérico): lá o
  estouro (`Strings.Mid`/`Conversions.ToInteger`) sai no `MsgBox` crítico do `catch`, sem renomear nada;
  aqui `RenumeracaoComDestino` lança `InvalidOperationException` com o mesmo efeito (o `ExecutarNaTela` do
  handler mostra crítico). Fixado em teste.
- **A página ativa depois da renumeração** (item do menu): o original **não** recalcula `ativo.Pagina`, e
  a grade reconstruída pode ficar sem seleção quando a página ativa foi uma das renomeadas. O recoder lê a
  página ativa **do desenho** a cada `Carregar()` (a decisão da rodada 180), então a linha da página ativa
  continua marcada, com o nome novo. O combo faz o que o original faz (`LocalizaPaginaAtiva`).
  **Correção da rodada 222** (clique físico na célula Página, o mesmo `Carregar` dentro do
  `CellEndEdit`): a seleção que a reconstrução deixava pendente era entregue **depois** do
  `_carregando`, e o `SelectionChanged` atrasado ativava a **linha seguinte** — renomear a página ativa
  `7` → `7A` terminava com o desenho na `8`. Hoje o `SelectionChanged` fica segurado até o primeiro
  `Application.Idle` e a seleção volta para a ativa (o fim do `VSWp1ebyWra`).
- **Combo com texto fora dos seis literais:** o original deixa o texto digitado no campo e renumera com a
  largura anterior; aqui o `Carregar()` do fim devolve o literal da configuração (a mesma convenção do
  `CarregaPG` do original, que é quem escreve o combo).
- **O XData `Eletron` do layer não é reescrito** pela renumeração (nem pelo combo): só o `Name` muda, como
  no `renumerarPaginasLote`. Confirmado por dump independente em AutoLISP.
- **As sincronizações** são o **stand-in** já registrado (a família `clsConexao`/`clsInterligacao`/… não
  está portada): o mesmo `SincronizacoesDoCaderno()` do `Apagar Páginas`. Na GUI sobre o projeto real o
  stand-in falha em FIA/INT — o banco do desenho é o Access (`RCD.mdb`), que o plugin não lê (decisão 1a);
  a falha **chega ao log e à linha de comando**, não é engolida.

## Prova

- `npm run plugin:test`: **0 testes**, falha conhecida do adaptador VSTest; não é passe.
  Console xUnit 2.9.2 em `%TEMP%/pm186`, bin completo: **971 (+18)**, Errors **0**, Failed **0**,
  Skipped **0**; tempo **3,628 s**.
- Builds finais ZWCAD / AutoCAD: **0 avisos, 0 erros** (verificação de tipos contra as duas APIs reais).
- Cobertura: **78** manuais (53 do reverso + 25 nossos), **115** gerados, **48** ausentes, **127** telas
  (**21** com ligação) — igual ao início da rodada: nenhum comando nem tela novos.
- AutoCAD 2020 **accoreconsole**, cópia do `Funcional.dwg` (16 páginas: 1, 2, 6, 7, 8, 15..24, 1000),
  ação pelo **clique real no item do menu** e respostas só da fila do harness:

```text
Não é possível mover sobre a Capa!
Esta página foi selecionada, informe uma página livre!
Esta página já existe, informe uma página livre!
pzFolhas: ... ação "renumerar" → clique no menu → Renumerar Páginas: 2 de 2 página(s) movida(s)
  a partir de "3" (2->3, 6->4).; ... tbPagina=23; multiseleção=False
```

As três recusas na **ordem em que o original as faz** (capa → selecionada → outra) e o ramo **numérico**
(`"1;2;7;3"`: 57, 26, 25 e o `3` aplicado). O ramo **alfanumérico** saiu na segunda medição
(`"1;7;2;7A"`): mesmas três recusas e `2->7A, 6->7B` — as páginas "2" e "6" viraram "7A"/"7B" (a grade
depois: `[1 | 7 | 7A | 7B | 8 | 15 | …]`). A segunda chamada de `pzFolhas` do mesmo ensaio, com a fila
esgotada, **cancelou** ("0 de 0 página(s)"), provando que a fila do harness não faz o laço girar.
Dump independente em AutoLISP (`scripts/cad-fixture-renumerar.lsp`), página a página:

```text
PAGINA;7A;xdata=((1000 . Unidade) (1000 . ÍNDICE) (1000 . ))
PAGINA;7B;xdata=((1000 . Unidade) (1000 . UNIFILAR) (1000 . ))
PAGINA;1;xdata=((1000 . Unidade) (1000 . CAPA) (1000 . ))
```

- **Combo, no core:** `POSITRON_FOLHA_ACAO=formato:0012` escolhe o item **da lista** (o
  `SelectedIndex`, não o texto digitado):

```text
pzFolhas: 16 página(s) na grade [0001 | 0002 | 0006 | … | 1000]; combo="0012";
  ação "formato:0012" → Folha: 16 de 16 página(s) renumerada(s) com a largura 4;
  configuração gravada no desenho.
```

A **segunda** chamada do mesmo ensaio lê o combo já em `"0012"` **do desenho** (o
`GravarXDataConfiguracao` foi persistido e relido), e o dump LISP confirma `0001`, `0002`, `0006`, …
`001000` (largura 4) com o XData preservado. Segunda escolha com o mesmo texto não dispara o
`TextChanged` (o resultado sai vazio) — o corpo é idempotente.
- **Desenho novo (accoreconsole sem `/i`):** 0 páginas, `combo="12"`, menu **ausente**

```text
RENUM186: sem menu (documento D/A/V ou sem páginas) — nada a clicar
pzFolhas: 0 página(s) na grade []; combo="12"; ação "renumerar" → ...
```

- **AutoCAD 2020 com a interface cheia e a paleta visível** (`acad.exe /nologo <cópia>`, job
  BACKGROUND com o pai vivo; bundle **reinstalado depois do build** — senão a sessão roda a DLL antiga,
  medido na rodada 149): a DLL do log é a do build (`Positron: DLL de 2026-10-15 23:58`).

```text
RENUM186 UI: interface: 5 colunas [Página | Unidade]; tbPagina=23; multiseleção=False; controles=11
RENUM186 UI: seleção pedida "2,6" (2 achada(s))
RENUM186 UI: clicando o menu — aguardando as respostas no prompt nativo.
Não é possível mover sobre a Capa!
Esta página já existe, informe uma página livre!
Esta página foi selecionada, informe uma página livre!
RENUM186 UI: PASSOU — Renumerar Páginas: 2 de 2 página(s) movida(s) a partir de "7A" (2->7A, 6->7B).;
  página ativa=23
```

O clique foi o **PerformClick do item real do menu, dentro do Timer do WinForms** — fora de comando, sem
o lock automático — e o prompt **nativo** foi respondido por teclado de fora do processo
(`WScript.Shell.SendKeys`), com o foco medido na janela do desenho
(`Autodesk AutoCAD 2020 - [pz186-gui.dwg]`); o log dá o marco ("clicando o menu") que sincroniza as
respostas. Capturas em `docs/recoder/provas/186-renumerar/` (`gui-paleta-renumerada.png` — o desktop
inteiro — e `paginas-antes-do-clique.png`). O roteiro da medição vive em `.tmp-smoke/r186-gui.ps1`
(ignorado, como o `r183-gui.ps1` da rodada 183). **As três recusas saíram só no log**, porque a sessão
rodou com `POSITRON_LOG` e nesse modo o `Aviso` não abre o `MsgBox` (o mesmo recorte de sempre, um script
não tem quem clique): o que está provado é a **ordem** das recusas e a volta ao prompt; a aparência dos
diálogos na tela não foi auditada nesta rodada.
- **Combo na GUI** (`POSITRON_FOLHA_FORMATO=000012`, Timer, fora de comando):

```text
RENUM186 UI: PASSOU — combo "000012" → Folha: 16 de 16 página(s) renumerada(s) com a largura 6;
  configuração gravada no desenho.; páginas depois: [000001 | 000002 | 000006 | … | 001000]
```

Capturas `gui-paleta-formato.png`, `paginas-antes-do-formato.png` e `paginas-depois-do-formato.png`.
A cópia foi **salva** (a cópia é descartável; o original nunca é tocado) e um **outro processo** a abriu:
`combo="000012"` e a grade `[000001 | 000002 | … | 001000]`, com o dump LISP confirmando os layers e o
XData `Eletron` preservado. É a persistência do XData de configuração provada ponta a ponta.
- Provas preservadas em `docs/recoder/provas/186-renumerar/`: `numero-core.log`, `menu-core.log`,
  `formato-core.log`, `novo-desenho.log`, `dump-gui.log`, `gui-plugin.log`, `gui-saida.txt`,
  `gui-saida-formato.txt`, `paginas-{numero,B,C,gui}.txt` e as capturas. Cópia e desenhos de ensaio
  fechados sem salvar (exceto a cópia do combo, salva de propósito para o dump); **original intocado**;
  nenhum `acad`/`accoreconsole` restante (`CAD_PROCESSOS=0`).
- **Falhas do instrumento, mantidas explícitas:** a primeira GUI rodou a DLL **velha** do bundle (o
  autoload carrega antes do `NETLOAD` e a mesma identidade de assembly não recarrega): o `pzFolhas` caiu no
  caminho genérico e nada foi clicado; e os `SendKeys` dessa tentativa foram para a janela
  `Banco de Dados do Projeto` (o `frmConfiguracaoBDProjeto` que o arranque abre com o banco do desenho
  inválido) em vez do prompt. Repetida depois do `instala-bundle.ps1 -Cad AutoCAD` e com a janela fechada.
  Os dois `acad.exe` terminaram com código de saída anômalo (`-840123714` e `27703998`, não zero) —
  o mesmo tipo de encerramento já registrado em 183/184; **não** é contado como gate de saída aprovado.
  O conserto da causa continua pendente.

## Falta

- [x] **Mensagem 27 (sem espaço) medida no CAD** — rodada **221**. A premissa escrita aqui estava errada:
  não são precisas 27 linhas selecionadas. Duas já bastam quando o limite é a **letra vizinha**
  (destino `5` com limite `5A`: os dois espaços dão 1), e a forma literal de 27/28 (destino `3` com
  limite `4` num caderno de 31 páginas) foi medida na mesma rodada; os três ensaios no AutoCAD 2020
  estão em `rodadas/221-mensagem-27-sem-espaco.md`, com a fixture `scripts/cad-fixture-msg27.lsp`.
- [ ] Combinação `finalize` (repetir a edição depois de um retorno MDI) e a troca de documento durante o
  prompt: o guarda existe (não aplica seleção de outro documento), mas não foi exercitado no CAD.
- [ ] ZWCAD ausente nesta máquina (medido; a ausência é uma medição com data: `RUNBOOK.md` → *Existe CAD nesta máquina?*; leitura de 2026-10-15): repetir menu/combo nesse host.
- [ ] Excel ativo (`clsTextos.ExportaPaginas/ImportaTitulos`) e a **renumeração inline** da célula Página
  continuam fora (fila 1 da `183`).
- [x] Saída anômala do `acad.exe` no fim do ensaio (183/184/186) — **medida na rodada 222**: é do
  **host**, não do plugin. Desenho novo + `Quit` pela COM dá `EXIT=0`; o `Funcional.dwg` salvo e
  fechado pela COM dá não-zero **com o bundle do plugin renomeado** (`24361662`, sem `POSITRON_LOG`)
  e com ele ligado (`24623806`). A receita e a tabela estão no `RUNBOOK.md` (*A saída não-zero do
  `acad.exe` é do host*).
- [ ] `frmConfiguracaoBDProjeto` abre no arranque com o banco Access não configurado e **rouba o foco** do
  prompt nativo: o harness fecha a janela pelo título; no uso real é uma tela a mais antes de tudo.

## Conhecimento registrado

`docs/recoder/conhecimento/paginas.md`: o `C8Op1CM1YgS` inteiro (as duas listas na ordem da grade, o laço
do prompt, as quatro mensagens, o limite `p`, as duas famílias de nome e o `renumerarPaginasLote`) e o
`Es6p1Y15jTb` (o `switch` sem `default`, a guarda do `CarregaPG`, o `GravarXDataConfiguracao`, o
`LocalizaPaginaAtiva` no fim). `docs/RUNBOOK.md`: a armadilha do autoload vs. `NETLOAD` na medição da GUI
e a janela de banco que rouba o foco.

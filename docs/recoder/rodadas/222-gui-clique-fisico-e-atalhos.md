# Rodada 222 — O clique físico na paleta: célula Página, os quatro atalhos, o título 4 e o documento tipo D

**Data:** 2026-10-17 · **Commit:** *(este)* · **Frente:** correção do básico, item 1 da fila (fechar a 183) · **Situação:** ✅ completa (com uma correção de produto encontrada pela medição)

## Alvo

O item 1 da fila (`Fechar a rodada 183`) ficou só com pendências de **GUI**: o **clique físico** na
célula Página com a paleta visível (a 212/213 mediram o método e o evento, mas nunca o clique do
mouse), os **quatro atalhos** `lb1..lb4` exercitados individualmente (a 183 só capturou o `lb1`, e
pelas costas — `OnClick` por reflexão), o **título 4** presente e os **documentos D/A/V**. Decisão do
dono nesta data: fechar esses pendentes na GUI do AutoCAD 2020. A investigação da **saída anômala do
`acad.exe`** (183/184/186) entrou de carona na mesma sessão.

## O que o reverso faz

Caminhos relativos a `cad-plugin/reverso/Eletron4_ZWcad/decompiled-cleaned/Eletron4/`.

- **Os quatro rótulos de atalho.** `uscPaginas.cs:1514-1601` (`RXnp13sEwHd`, `e7qp1nZuNdI`,
  `jXHp11IcvOu`, `xPyp1ljbIB8`, um por `lb1..lb4`): cada clique tem dois ramos.
  - **Captura** (`u8wplmSvBqh`, armado pelo `btSalva` — `EDJp12YldpK`, `:1509`): põe no rótulo a
    página **ativa** (`DeclaracoesGeral.ativo.Pagina`), copia para `atalhosPag.atalhoN` e chama
    `Dicionario.gravaAtalhos()`; desarma a captura.
  - **Uso** (`ativaPaginaAtalho`, `:1602-1629`): só com rótulo não vazio; `Pagina.montaNumeroPagina`
    normaliza o texto, a grade é varrida pela coluna 0 e, achando, ativa a página, seleciona a linha,
    copia **Unidade** e **Alternativo** da linha para o ativo, rola até ela e escreve o `tbPagina`.
    Não achando, o rótulo é **limpo**, `atalhoN = ""` e `gravaAtalhos()` — o atalho inexistente é
    apagado pelo próprio clique.
- **O Xrecord.** `Dicionario.gravaAtalhos` (`Dicionario.cs:99-207`): NOD `CENG_ELET` → Xrecord
  `Atalhos`, **seis** valores DXF 1 (`atalho1..6`), sempre os seis, em `LockDocument`.
  `Dicionario.LeAtalhos` (`:209-259`) lê os seis índices **sem conferir o tamanho** (array curto
  estoura no `Conversions.ToString(array[5])`; o `catch` aborta e os seis ficam vazios). Os rótulos
  mostram **quatro** (designer `:1156-1200`): `atalho5/6` são carregados e regravados sem aparecer na
  tela — o clique em qualquer rótulo não pode perdê-los.
- **A célula Página.** O `CellEndEdit` (`j9Sp1mKZkcD`, `:1733-1846`) trata `ColumnIndex == 0` com o
  texto **aparado** e `ToUpper`; vazio devolve a página ativa; a primeira linha (a capa) e nome
  inválido devolvem o nome carregado; nome válido renomeia por `Pagina.renumerarPagina` e, quando
  renomeou, roda `Y9op1KgeRgW`/`VSWp1ebyWra`, escreve o `tbPagina` e as sincronizações. O designer
  **não** grava `EditMode`: vale o padrão do WinForms (`EditOnKeystrokeOrF2`) — quem abre a edição é a
  **primeira tecla**, não o duplo clique.
- **O `alteraNomeLayer`.** `Pagina.cs:1903-1949`: a renomeação é o `LayerTableRecord.Name = novo`
  dentro de uma transação com `LockDocument`, e **nada** mexe no `Database.Clayer` — a camada corrente
  continua sendo a renomeada (confirmado na sonda desta rodada).
- **Título 4.** O editor (`frmEditaTitulos`) mostra a coluna do título **quando o campo existe no
  formato**: `Pagina.buscaTitulosExistentes` (`Pagina.cs:2502-2562`) varre os **atributos da referência
  do formato**, só os do layer **`-1`**, e liga `bTitulo4` para a tag `TITULO4PAG` **ou** `PAINEL`.
- **Documentos D/A/V.** `Y9op1KgeRgW` (`:1396-1449`) e `VSWp1ebyWra` (`:1450-1506`): tipo `D`, `A` ou
  `V` — lido das apps do ModelSpace (`XDataGeral.verificaTipoXData`: `Eletron`=E, `DiagLog`=D,
  `ArqNet`=A, nenhuma=V) — esconde o **Alternativo** e a grade fica **sem menu** e somente leitura.

## O que foi feito

| arquivo | o quê |
|---|---|
| `cad-plugin/Positron.Plugin/Interface/Folhas/EntradaFisicaDaProva.cs` | **novo** (só harness): o mouse e o teclado de **verdade** (`SetCursorPos`/`mouse_event`/`keybd_event`), com um clique de aquecimento quando a janela não está em foco |
| `cad-plugin/Positron.Plugin/Interface/Folhas/TipoDoDesenhoDaProva.cs` | **novo** (só harness): o tipo do desenho pelo `InicioDoDesenho.TipoDoDesenho` |
| `cad-plugin/Positron.Plugin/Interface/Folhas/Titulo4DaProva.cs` | **novo** (só harness): põe o atributo `TITULO4PAG` (layer `-1`) na referência do formato pela API do CAD |
| `cad-plugin/Positron.Plugin/Interface/Folhas/ProvaDaPaleta.cs` | modos `clique-inline` (clique físico + digitação + Enter), `clique-atalhos` (os quatro rótulos e o `btSalva`), `tipo-d`, `sonda-renomear`; o `inline` e o `titulos` ganharam a leitura da camada corrente e da linha do alvo |
| `cad-plugin/Positron.Plugin/Interface/Folhas/FolhasControle.cs` | **correção de produto**: `_reconstruindoSelecao` + `SegurarSelecaoDuranteReconstrucao()` (ver abaixo) |
| `scripts/cad-fixture-clique222.lsp` | **novo**: Xrecord de seis atalhos, DBText de título 4, 4 layers de página + `DiagLog` no ModelSpace (tipo D) e o **despejo independente** em AutoLISP |

**A correção que a medição achou.** No clique físico a sequência real é: clique seleciona a linha
(`SelectionChanged` → ativa a página 7, `CLAYER=7`), a **tecla** abre a edição, o Enter fecha e o
`CellEndEdit` renomeia dentro do evento (o `Carregar` reconstrói a grade, como o
`Y9op1KgeRgW`/`VSWp1ebyWra` do original). Medido antes da correção: o desenho terminava na página
**8** — o DataGridView entrega a seleção que sobrou da reconstrução **depois** de o `finally` do
`Carregar` já ter baixado o `_carregando`, e o `SelectionChanged` atrasado ativava a linha seguinte
(a de baixo, 8). O original tem a guarda equivalente (`zmrpl5cr22t`) e **não** reativa ninguém: o
`renumerarPagina` mantém o `CLAYER` na página renomeada (sonda `sonda-renomear`:
`rename "23" → "23Z" = 1; camada corrente "23" → "23Z"`). A correção segura o `SelectionChanged` até o
primeiro `Application.Idle` e, ao soltar, devolve a seleção para a página ativa (`SelecionarAtiva`) —
que é o fim do `VSWp1ebyWra`. Depois dela: `página ativa=7A; camada corrente="7A"; grade: linha
atual=3, selecionadas=1 (7A)`.

Nada mais do produto mudou: os quatro rótulos, a captura pelo `btSalva`, a leitura dos títulos e o
ramo D/A/V já estavam portados e fiéis — faltava a prova pelo caminho do usuário. O `Function`
`c222:atributo-titulo4` (ActiveX) ficou no arquivo LISP como registro do beco: **o ActiveX do AutoCAD
2020 não tem `AddAttribute`** ("unknown name: AddAttribute"), e o `BlockTableRecord.XData` **não**
troca o `Eletron` de um desenho existente (medido: a app continuou lá e o tipo continuou "E") — o
documento tipo D da prova é um **desenho novo** com o `DiagLog` posto pelo `vla-SetXData`.

## Prova

- `npm run plugin:test`: **0 testes** — a falha conhecida do adaptador VSTest (`Falha ao carregar as
  extensões … xunit.runner.visualstudio.testadapter.dll`), não é passe. Console xUnit 2.9.2 em cópia do
  `bin` no `%TEMP%` (`pm222`): **1083** aprovados, `Errors: 0, Failed: 0, Skipped: 0`, em **6,5 s**
  (sem teste novo: a rodada não mudou regra pura).
- Builds contra as APIs reais: **ZWCAD 0 avisos/0 erros** e **AutoCAD 0 avisos/0 erros**, refeitos
  depois da correção e da entrada física.
- **AutoCAD 2020 com a interface cheia**, cópia do `Funcional.dwg` (16 páginas), plugin pelo autoload
  do bundle reinstalado a cada modo (`instala-bundle.ps1 -Cad AutoCAD`), comandos pelo caminho do
  usuário (o `pzFolhas` do harness, fora de comando, no Timer do WinForms). Logs e capturas em
  `docs/recoder/provas/222-clique-fisico/`; a rotina que dispara as sessões é o `.tmp-smoke/r222-gui.ps1`
  (ignorado, como os `r183/r186-gui.ps1`).

  1) **Clique físico na célula Página** (`clique-inline`, página `7` → `7A`; ponto de tela, célula,
     foco e o estado da grade a cada passo):

```text
CLIQUE222: paleta — interface: 5 colunas [Página | Unidade | Alternativo]; tbPagina=23; multiseleção=False; controles=11; páginas [1 | 2 | 6 | 7 | 8 | 15 | ... | 1000]; rótulos [lb1="" | lb2="" | lb3="" | lb4=""]
CLIQUE222: clique físico em (253,381), célula {X=2,Y=90,Width=92,Height=22}, foco antes="Autodesk AutoCAD 2020 - [pz222-inline.dwg]"
CLIQUE222: depois do clique — célula atual=3,0; foco na grade=True; em edição=False; camada corrente="7"; ativa="7"; foco="Autodesk AutoCAD 2020 - [pz222-inline.dwg]"
CLIQUE222: digitando "7A" no teclado físico.
CLIQUE222: em edição=True; editor="7A"
CLIQUE222: Enter físico — aguardando o CellEndEdit.
CLIQUE222: PASSOU — página ativa=7A; camada corrente="7A"; grade: linha atual=3, selecionadas=1 (7A); páginas do desenho [1 | 2 | 6 | 7A | 8 | 15 | ... | 1000]; Página: "7" → "7A"; 1 layer(s) renomeado(s).; rótulos [lb1="" | lb2="" | lb3="" | lb4=""]
```

     Capturas do desktop: `gui-inline.png` e `inline-{antes-do-clique,depois-do-enter}.png`. Prova
     independente no **despejo em AutoLISP** da cópia salva (`dump-inline.txt`, outro processo,
     `accoreconsole`, tabela de LAYERS): `PAGINA;7A` presente, **sem** `PAGINA;7`, `TOTAL;16`.

  2) **Os quatro atalhos pelo clique físico** (`clique-atalhos`): o Xrecord da fixture com
     `2 | 6 | 999 | (vazio) | QUINTO | SEXTO` (os dois últimos sem rótulo na tela):

```text
CLIQUE222: paleta — ... rótulos [lb1="2" | lb2="6" | lb3="999" | lb4=""]; Xrecord [2 | 6 | 999 | (vazio) | QUINTO | SEXTO]
CLIQUE222: clicando o lb1 (rótulo "2")
CLIQUE222: lb1 usou o atalho — ativa=2
CLIQUE222: clicando o lb2 (rótulo "6")
CLIQUE222: lb2 usou o atalho — ativa=6
CLIQUE222: clicando o lb3 (rotulo inexistente "999")
CLIQUE222: lb3 inexistente limpou o slot 3; slots 5/6 preservados ("QUINTO"/"SEXTO")
CLIQUE222: clicando o btSalva (arma a captura).
CLIQUE222: clicando o lb4 (captura da página ativa "6")
CLIQUE222: PASSOU — ativa=6; rótulos [lb1="2" | lb2="6" | lb3="" | lb4="6"]; Xrecord [2 | 6 | (vazio) | 6 | QUINTO | SEXTO]
```

     Duas passagens seguidas com o mesmo resultado (a primeira tentativa, antes do clique de
     aquecimento, perdeu o `lb1` — ver *Falta*). Despejo independente da cópia salva
     (`dump-atalhos.txt`): `ATALHOS;6`, `ATALHO;1;2`, `ATALHO;2;6`, `ATALHO;3;` (vazio),
     `ATALHO;4;6`, `ATALHO;5;QUINTO`, `ATALHO;6;SEXTO`.

  3) **Título 4** (`titulos`): a fixture põe o `DBText` de índice 4 no layer `7` e o harness o
     atributo `TITULO4PAG` (layer `-1`) no formato; o editor é aberto pelo item **Editar Títulos** do
     menu da paleta:

```text
CLIQUE222: formato — atributo TITULO4PAG (layer -1) acrescentado ao formato
CLIQUE222: títulos — 15 linha(s); colunas [Página | Título 1 | Título 2 | Título 3 | Título 4 | Unidade | Alternativo]; linha 7 = [T1 "PNL-GGE" | T2 "DIAGRAMA FUNCIONAL" | T3 "DIAGRAMA UNIFILAR" | T4 "TITULO 4 DA PROVA 222"]; Editar DWG pelo menu; fechou=True
```

  4) **Documento tipo D** (`tipo-d`): desenho **novo**, 4 layers de página e o `DiagLog` no ModelSpace
     pela fixture (`vla-SetXData`, ActiveX que só existe com interface):

```text
CLIQUE222: tipo D → D; 4 página(s); menu=ausente; grade=somente leitura; colunas [Página | Unidade]
```

     O `Verificar` do harness falha se o tipo não for D/A/V, se o menu existir, se a grade estiver
     editável ou se o Alternativo aparecer — os quatro passaram. Captura `gui-tipo-d.png`.

- **Saída anômala do `acad.exe` (item de 183/184/186): é do host, não do plugin.** Medido nesta
  rodada, três cenários de fechamento pela COM (`$app.ActiveDocument.Close(...)` + `$app.Quit()`):

  | cenário | log do plugin | EXIT |
  |---|---|---|
  | desenho **novo**, sem documento de arquivo, `Quit` puro | por construção, sem documento | **0** |
  | `Funcional.dwg` salvo e fechado, **bundle do plugin renomeado** (`Positron.bundle.off`) | **ausente** (o `POSITRON_LOG` não foi criado) | 24361662 |
  | o mesmo, com o plugin ligado | presente (`Positron carregado.`, DLL de `2026-10-17 11:10`) | 24623806 |

  O código muda a cada ensaio (183/184/186/222: 51100350, 48151230, -840123714, 27703998, 27966142,
  28031678, 27900606, 24623806, 24361662) e **não depende do plugin**: abrir ESTE desenho por arquivo e
  fechá-lo pela COM já devolve não-zero. O `acad.exe` do AutoCAD 2020 é o dono do código; o plugin
  apenas o acompanha.

- Limpeza: nenhum `acad`/`accoreconsole` restante depois das sessões (`CAD_PROCESSOS=0` em todas);
  o **original** `Funcional.dwg` nunca foi aberto para escrita (todo ensaio roda numa cópia em
  `C:\positron-smoke\r222`), e o bundle do plugin foi restaurado depois do ensaio negativo.

## Falta

- [ ] **ZWCAD ausente nesta máquina** — remedido hoje (2026-10-17): sem a chave `HKLM\SOFTWARE\ZWSOFT`,
      sem `C:\Program Files\ZWSOFT`, `where.exe ZWCAD.exe` vazio; em `C:\Program Files\Autodesk` só o
      **AutoCAD 2020** (e o `AdSSO`). Repetir clique/atalhos/título 4 nesse host quando ele voltar.
- [ ] **Aparência dos `MsgBox` na tela** continua fora: a sessão roda com `POSITRON_LOG` e, nesse modo,
      o `Aviso` grava no log em vez de abrir o diálogo (o mesmo recorte de 186/221). O que está provado
      aqui é o caminho do clique, a digitação física e o efeito no desenho.
- [ ] **Primeiro clique perdido na ativação da janela** (medido: o clique no `lb1` não navegou e o
      ensaio falhou): o harness passou a fazer um clique de **aquecimento** quando
      `GetForegroundWindow()` não é a janela da paleta — duas passagens seguidas passaram. É limitação
      do instrumento, não do produto: no uso real o usuário já tem a paleta em foco.
- [ ] O **`frmConfiguracaoBDProjeto` no arranque** (tipo E sem banco válido) continua roubando o foco
      do prompt nativo: fiel ao original (`Iniciar.cs`), mas é uma tela a mais antes de tudo — segue
      como conferência do dono.
- [ ] O **`Function c222:atributo-titulo4`** (ActiveX `AddAttribute`) fica no arquivo LISP só como
      registro do beco: no AutoCAD 2020 o método não existe. Quem monta o `TITULO4PAG` é o harness
      (`Titulo4DaProva`), pela API .NET.

## Conhecimento registrado

`docs/recoder/conhecimento/paginas.md`: o espaço do clique e da reconstrução — o `EditMode` que o
designer do original **não** grava (quem abre a edição inline é a tecla), o `alteraNomeLayer` que
**não** mexe no `Clayer` (sonda desta rodada: o `CLAYER` segue a camada renomeada) e a **seleção
atrasada** do DataGridView depois de reconstruir a grade dentro do `CellEndEdit` (com a guarda até o
`Application.Idle`). `docs/RUNBOOK.md`: as armadilhas de operação medidas — o clique físico do harness
(clique de aquecimento), o Xrecord de seis strings da prova, e a **saída não-zero do `acad.exe` como
comportamento do host** (com os três cenários e os códigos).

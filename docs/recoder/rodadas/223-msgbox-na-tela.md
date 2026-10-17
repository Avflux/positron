# Rodada 223 — Os diálogos de aviso (`MsgBox`) na tela

**Data:** 2026-10-17 · **Commit:** *(este)* · **Frente:** correção do básico, item 2 da fila · **Situação:** ✅ completa (com três correções de fidelidade que a medição exigiu)

## Alvo

O item 2 da fila: desde a rodada 186 todos os ensaios rodam com `POSITRON_LOG` e, nesse modo, o
`Aviso` **grava no log em vez de abrir o diálogo** — a janela de aviso nunca tinha sido vista na tela.
Esta rodada mede o `MsgBox` de verdade na interface cheia do AutoCAD 2020, **sem** a variável, com o
**mouse do Windows** clicando o OK; e confere texto, título, ícone e o que o produto faz depois do OK.

## O que o reverso faz

Caminhos relativos a `cad-plugin/reverso/Eletron4_ZWcad/decompiled-cleaned/Eletron4/`. O aviso do
produto é o `Interaction.MsgBox` do VB, e **estilo e título mudam por chamada** — é essa a ficha que
a paleta precisa copiar:

| chamada no reverso | texto | estilo | título |
|---|---|---|---|
| `uscPaginas.cs:1948-1963` (Nova Página) | mMensagem 33/32/31/30 | `Information` | `"Elétron"` |
| `uscPaginas.cs:2191` (capa selecionada no apagar) | mMensagem 17 | `Critical` | `"Elétron"` |
| `uscPaginas.cs:2198` (falha por página do apagar) | `ex.Message` | `Critical` | — |
| `uscPaginas.cs:2312,2326,2353,2375` (renumerar com destino) | mMensagem 26/25/27/57 | `Information` | — |
| `uscPaginas.cs:1773` (Alternativo acima de 20 na célula) | mMensagem 1927 | *(nenhum)* | — |
| `Pagina.cs:1855` (`renumerarPagina`, destino que já é página) | mMensagem 28 | `Information` | — |
| `uscPaginas.cs:1852,1883,2033,2048,2089,2132,2220,2383,2460,2481,2501,2521,2541,2561` | `ex.Message` | `Critical` | — |

- **Sem `Title` o VB põe o nome da aplicação** — e o recoder não reproduz isso: a convenção adotada na
  auditoria do `frmEditaTitulos` (rodada 197) é `string.Empty` quando o reverso não passa título. O que
  a medição desta rodada prova é que a janela abre com a barra **vazia**; o nome da aplicação do VB
  fica na *Falta* (é o único ponto do aviso que não é literal do decompilado).
- **O ícone é o do estilo**: `Information` → o "i" azul; `Critical` → o "X" vermelho; sem estilo →
  **nenhum** ícone. Medido pelo dump da janela: o controle `Static id=20` (o lugar do ícone) existe nos
  dois primeiros e **não existe** no terceiro.
- **O aviso é modal e a rotina continua depois do OK.** No apagar, o `MsgBox` da capa está **dentro**
  do laço das linhas selecionadas (`:2183-2202`): fechado o aviso, as outras páginas seguem sendo
  apagadas e as sincronizações rodam. No renumerar, o `MsgBox` está dentro do `while (true)` do prompt
  (`:2286-2390`): fechado o aviso, a pergunta é **repetida** (a fila de respostas vazia cancela).
- **Apelidos:** `j9Sp1mKZkcD` é o `CellEndEdit` (mMensagem 1927 e 28 saem de dentro dele);
  `cPup1SWxSYc` é o apagar das páginas; `C8Op1CM1YgS` é o renumerar com destino.

## O que foi feito

| arquivo | o quê |
|---|---|
| `cad-plugin/Positron.Plugin/Interface/Aviso.cs` | a **terceira forma** do `Interaction.MsgBox`: `MsgBoxSemIcone` (OK sem ícone), e o ícone passou a ser um parâmetro explícito (`Nenhum`/`Informacao`/`Erro`) |
| `cad-plugin/Positron.Plugin/Interface/Folhas/FolhasControle.cs` | cinco chamadas da paleta com o **título e o ícone do reverso** (tabela abaixo) |
| `cad-plugin/Positron.Plugin/Interface/Folhas/ProvaDaPaleta.cs` | modo `POSITRON_FOLHA_ACAO=aviso` (três sub-modos), o arquivo de evidência `POSITRON_PROVA_SAIDA` e a **guarda de reentrância** do Timer (ver abaixo) |
| `.tmp-smoke/r223-gui.ps1` | **novo** (ignorado): o driver externo que abre o AutoCAD, acha o `#32770` do processo, despeja os controles, captura a tela e clica o OK com o mouse físico |

As cinco correções (todas "o título `Elétron` era invenção"):

| local | antes | depois | prova no reverso |
|---|---|---|---|
| `FolhasControle.RenumerarSelecionadas` | `MsgBox(aviso, "Elétron")` | `MsgBox(aviso, string.Empty)` | `uscPaginas.cs:2312,2326,2353,2375` |
| `FolhasControle.ApagarSelecionadas` (falhas por página) | `MsgBoxCritico(falha, "Elétron")` | `MsgBoxCritico(falha, string.Empty)` | `uscPaginas.cs:2198` |
| `FolhasControle.EditarCelula` (Alternativo > 20) | `MsgBox("Máximo de 20 caracteres", "Elétron")` | `MsgBoxSemIcone(mMensagem 1927)` | `uscPaginas.cs:1773` |
| `FolhasControle.RenomearPaginaInline` (destino já existe) | `MsgBox(aviso, "Elétron")` | `MsgBox(aviso, string.Empty)` | `Pagina.cs:1855` |
| `FolhasControle.ExecutarNaTela` (erro do handler) | `MsgBoxCritico(erro.Message, "Elétron")` | `MsgBoxCritico(erro.Message, string.Empty)` | `uscPaginas.cs:2198,2220` |

**O que a medição achou no instrumento.** O `MessageBox` abre um **laço aninhado** que despacha o
`WM_TIMER`: o passo do Timer do harness rodava de novo enquanto o diálogo estava na tela — medido no
primeiro ensaio, o clique em "Apagar Páginas" se repetiu a cada 1,5 s e o ensaio terminou com o
`acad.exe` travado (o `Quit` pela COM não voltou). A guarda `ocupado` (pula o tick que reentra) resolveu;
depois dela o ensaio é limpo: um clique, um diálogo, um OK.

**O que a medição achou no diálogo.** O OK do `MessageBox` do WinForms sai com **id de controle 2**, não
com o `IDOK` (1) do Win32 — o driver acha o botão pelo texto ("OK"). É do WinForms, não do plugin.

## Prova

- `npm run plugin:test`: **0 testes** — a falha conhecida do adaptador VSTest
  (`Falha ao carregar as extensões … xunit.runner.visualstudio.testadapter.dll`), não é passe. Console
  xUnit 2.9.2 numa cópia do `bin` no `%TEMP%` (`pm223`): **1083** aprovados,
  `Errors: 0, Failed: 0, Skipped: 0`, em **3,9 s** (sem teste novo: a rodada não mudou regra pura).
- Builds contra as APIs reais: **ZWCAD 0 avisos/0 erros** e **AutoCAD 0 avisos/0 erros**.
- **AutoCAD 2020 com a interface cheia**, cópia do `Funcional.dwg` (16 páginas), plugin pelo autoload do
  bundle reinstalado a cada modo (`instala-bundle.ps1 -Cad AutoCAD`), **sem `POSITRON_LOG`** — é o que
  faz o `Aviso` abrir a janela. Comandos pelo caminho do usuário (`pzFolhas` fora de comando, no Timer
  do WinForms) e o OK pelo **mouse do Windows**. Logs, dumps e capturas em
  `docs/recoder/provas/223-msgbox/`; a rotina que dispara as sessões é `.tmp-smoke/r223-gui.ps1`.

  1) **Aviso crítico, com título** (`capa` — "Apagar Páginas" com a página `1` selecionada):

```text
DIALOGO: classe=#32770
DIALOGO: titulo=[Elétron]
DIALOGO: filho classe=Button id=2 texto=[OK]
DIALOGO: filho classe=Static id=20 texto=[]
DIALOGO: filho classe=Static id=65535 texto=[A Capa não pode ser apagada!]
clicando o OK do dialogo com o mouse fisico
AVISO223: clicando "Apagar Páginas" — o diálogo abre no clique.
AVISO223: PASSOU — depois do aviso: Apagar Páginas: nada apagado (a capa não se apaga).; páginas [1 | 2 | 6 | 7 | 8 | 15 | 16 | 17 | 18 | 19 | 20 | 21 | 22 | 23 | 24 | 1000]
```

  2) **Aviso de informação, sem título** (`mover` — "Renumerar Páginas" com o destino `1`, a capa;
     as quatro recusas saem com `Information` e sem título):

```text
DIALOGO: classe=#32770
DIALOGO: titulo=[]
DIALOGO: filho classe=Button id=2 texto=[OK]
DIALOGO: filho classe=Static id=20 texto=[]
DIALOGO: filho classe=Static id=65535 texto=[Não é possível mover sobre a Capa!]
AVISO223: clicando "Renumerar Páginas" — o diálogo abre no clique.
AVISO223: PASSOU — depois do aviso: Renumerar Páginas: cancelado (nenhuma página foi movida).; páginas [1 | 2 | 6 | 7 | 8 | 15 | 16 | 17 | 18 | 19 | 20 | 21 | 22 | 23 | 24 | 1000]
```

  3) **Aviso sem ícone** (`mais20` — clique e digitação **físicos** na célula Alternativo da página
     `2`, 27 caracteres, Enter). Note que **não há** o `Static id=20` (o ícone) no dump:

```text
DIALOGO: classe=#32770
DIALOGO: titulo=[]
DIALOGO: filho classe=Button id=2 texto=[OK]
DIALOGO: filho classe=Static id=65535 texto=[Máximo de 20 caracteres]
AVISO223: clique físico em (437,337), célula Alternativo {X=186,Y=46,Width=92,Height=22}, foco antes="Autodesk AutoCAD 2020 - [pz223-mais20.dwg]"
AVISO223: digitando 27 caracteres no teclado físico (o aviso sai ao confirmar).
AVISO223: Enter físico — aguardando o aviso.
AVISO223: PASSOU — célula="NOME ALTERNATIVO 223" (20 caracteres) e XData "NOME ALTERNATIVO 223" na página "2"
```

     O diálogo abre **dentro** do `CellEndEdit` (o mesmo evento do usuário) e só depois do OK a célula é
     cortada em 20 e o XData `Eletron` regravado — é a prova de que o aviso não engole a rotina.

- Capturas do desktop com a janela na tela: `gui-capa.png`, `gui-mover.png`, `gui-mais20.png` (e as do
  controle depois do OK: `aviso-*-depois.png`).
- **Saída do `acad.exe`:** não-zero nos três ensaios (−1396000066, 27966142, 27966142) — é o
  comportamento do **host**, já isolado na rodada 222 (sem o plugin, o mesmo fechamento pela COM dá
  não-zero; desenho novo + `Quit` dá 0). `CAD_PROCESSOS=0` depois de cada sessão.
- O original `Funcional.dwg` nunca foi aberto para escrita (todo ensaio roda numa cópia em
  `C:\positron-smoke\r223`).

## Falta

- [ ] **ZWCAD ausente nesta máquina** (medição de 2026-10-17, refeita na rodada 222): repetir os três
      avisos nesse host quando ele voltar.
- [ ] **Título padrão do VB sem `Title`:** o `Interaction.MsgBox` sem `Title` mostra o **nome da
      aplicação** (documentação do VB); o recoder usa `string.Empty` (convenção da rodada 197 e o que
      esta rodada mediu na tela — barra vazia). É o único ponto do aviso sem literal do decompilado;
      fica a decisão do dono (não há como medir o texto que o VB poria dentro do AutoCAD sem o original).
- [ ] **Auditoria de título/ícone dos avisos fora da paleta:** esta rodada olhou o `uscPaginas` (as
      telas das rodadas 185–207 já tinham sido auditadas). As cinco chamadas da paleta eram as que
      estavam com o `"Elétron"` inventado; um passe nas demais (`Ligacao*`, `InicioDoDesenho`) não foi
      feito.
- [ ] O **`frmConfiguracaoBDProjeto` no arranque** continua roubando o foco do prompt nativo (segue da
      186/222, conferência do dono) — nos ensaios desta rodada ele foi fechado pelo título, como lá.

## Conhecimento registrado

`docs/recoder/conhecimento/paginas.md`: a tabela de estilo/título dos `MsgBox` do `uscPaginas`, o laço
aninhado do `MessageBox` que despacha `WM_TIMER` (e a guarda que o ensaio precisa), o id 2 do botão OK
do WinForms e o ícone ausente quando o estilo é nenhum. `docs/RUNBOOK.md`: a receita de medir o
`MsgBox` **sem** `POSITRON_LOG` e as armadilhas de operação (reentrância e id do OK).

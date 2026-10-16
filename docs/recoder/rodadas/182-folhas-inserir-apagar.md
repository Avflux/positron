# Rodada 182 — folhas pela paleta: o `Inserir` de colunas, a `Nova Página` pela linha selecionada e o `Apagar Páginas` do original

**Data:** 2026-10-15 · **Commit:** *(este)* · **Frente:** correção do básico, item 2 (e item 1c) · **Situação:** 🟡 parcial (o `clsApagar.ApagarDerivados` e a família `Sincroniza*` da tela/cruzamento ficaram em *Falta*)

## Alvo

Item **2** da *Correção do básico* do `ESTADO.md`: **folhas — adicionar e apagar pela paleta**. O dono
testou em uso real e o que a paleta faz hoje é uma invenção em três pontos:

1. o `Inserir` do menu **não insere colunas** — no original ele é um submenu com as colunas que o
   **formato** oferece (`ELET1..5`), e o recoder o usou para criar uma *página* (que é a `Nova Página`);
2. a `Nova Página` não usa a **linha selecionada** da grade (o original parte dela) e engole a
   recusa da multiseleção;
3. o `Apagar Páginas` não pede **confirmação**, não recusa a **capa**, não roda as
   **sincronizações** do original e não devolve a seleção à linha anterior.

A rodada também fecha o **`LockDocument`** de todas as gravações da paleta (o original trava em cada
rotina), faz o **erro chegar ao usuário** (`MsgBox`), em vez de morrer numa propriedade
`UltimaMensagem` que ninguém lê, e leva os ganchos `POSITRON_*` do item **1c** para o caminho da
paleta (as perguntas de campo e de confirmação não abrem form nem prompt quando o harness as responde).

## O que o reverso faz

Caminhos relativos a `cad-plugin/reverso/Eletron4_ZWcad/decompiled-cleaned/Eletron4/`.

Todos os handlers abaixo são do controle **`uscPaginas`** (a paleta das folhas) e rodam **fora de
comando** — o CAD **não** trava o documento por eles: quem trava é cada rotina que grava
(`Pagina.InserirColuna`, `Pagina.RemoveLayer`, `Pagina.ApagarElementosPagina`…).

### `Inserir` — as cinco colunas do formato (`uscPaginas.cs:2466-2565`)

- O item `InserirToolStripMenuItem` (texto `mMensagem[1,35]` = "Inserir") tem **cinco sub-itens**
  (`ToolStripMenuItem1..5`, `uscPaginas.cs:1083`). Cada clique
  (`ALbp1rlkV2U`/`yvkp19tK4tH`/`ldUp1zs1gc7`/`DTMplWw4hxb`/`oIPplp5NlDs`) faz, para **cada linha
  selecionada** da grade: `Pagina.InserirColuna(pagina, "ELETn_" + ToolStripMenuItemN.Text)`.
- **De onde vêm o rótulo e a visibilidade** (`CarregaPG`, `uscPaginas.cs:1376-1393`): de
  `Pagina.verificaLayerExtraNoFormato(ref bLayers)` (`Pagina.cs:2315-2412`), que varre a **tabela de
  layers** do desenho e, para cada nome que começa com `ELET1_`..`ELET5_`, liga
  `bELETn` e guarda o resto do nome — `sELETn = name.Remove(0, 6)` — como o **texto** do sub-item.
  Sem `DeclaracoesGeral.blockFormatoID` válido a rotina **sai antes** (tudo falso). Com todos falsos
  o item `Inserir` inteiro fica **invisível** (`uscPaginas.cs:1390-1393`).
  Quirk mantido: quem decide é a **ordem de enumeração** da tabela — com dois layers `ELET1_*`, o
  último lido é o que fica.
- **`Pagina.InserirColuna(sPag, sTipo)`** (`Pagina.cs:2415-2478`): `LockDocument`; a transação abre a
  **definição** do bloco de formato (`blockFormatoName`) e o ModelSpace; toda entidade da definição
  com `Layer == sTipo` é **clonada** para o ModelSpace no layer da página, com
  `XDataGeral.gravarXDataColuna(clone, sTipo)` (app `DiagLog`, marca `COLUNAS`, o tipo, usuário e
  data — o XData que o recoder já tem em `ColunaDaPaginaXData`). Não há mensagem: erro vira
  `MsgBox(ex.Message, Critical)` genérico.

### `Nova Página` — a linha selecionada (`uscPaginas.cs:1888-1972`, `:2029`)

O item `CriarPaginaToolStripMenuItem` (texto 29 = "Nova Página") chama `TBNp1Uume8n`. O **mesmo**
método é chamado pela tecla **Insert** (`wZ0p1XlFJ5o`, `:1859-1884`), que depois põe
`tbPagina.Text = DeclaracoesGeral.ativo.Pagina`.

- **Guarda do tipo:** a tecla só age com `DeclaracoesGeral.ativo.Tipo == "E"` (o desenho do Elétron);
  o item de menu não tem essa guarda.
- **Guarda da multiseleção:** com `dg.MultiSelect` ligado → `MsgBox(mMensagem[1,30])` =
  "Desative a multiseleção!" e **nada mais acontece**.
- **A referência é a linha selecionada:** `pag.Pagina = dg.Rows[index].Cells[0]`, unidade/alternativo
  das colunas 1 e 2, `Pagina.capturaTitulosDeUmaPagina(ref pag)` (os títulos dela), e a **posterior**
  é a **próxima linha da grade** — na última, o sentinela `"1000000"`. `Pagina.calculaNovaPagina` é a
  regra (`NovaPaginaEntre` no recoder).
- **Recusas, com o texto exato:** `PgNum == 0` → `mMensagem[1,31]` "Não há espaço para uma nova
  página!"; `CriarLayer` devolvendo `-1` → `mMensagem[1,32]` "Esta página já existe!"; devolvendo `0`
  → `mMensagem[1,33]` "Não foi possível criar esta página!". Todas `MsgBox` de informação, título
  "Elétron".
- **O que a criação faz** (o ramo bom): insere a linha na grade (empurra as de baixo), `CriarLayer`,
  e então `CarregaPaginas` + `OrdenaMatrizPaginas` + **`criaCamposFormato("-1", pagina)`** +
  **`AtualizaContTotFl`** + **`AtivaPagina(pagina)`** + `tbPagina.Text = pagina`, e os **títulos
  herdados** da página de referência (`Titulo1..4` + `AtualizaTitulosDeUmaPagina`).

### `Apagar Páginas` — confirmação, capa, sincronizações e a seleção (`uscPaginas.cs:2145-2222`, `:1859-1884`)

O item `ExcluirPáginasToolStripMenuItem` (cujo **texto visível** o construtor troca pela
`mMensagem[1,21]` = **"Apagar Páginas"**, `uscPaginas.cs:1299`) e a tecla **Delete** chamam
`cPup1SWxSYc`:

- **Confirmação:** `PromptKeywordOptions` com a mensagem `mMensagem[1,23]` = "Apagar as páginas
  selecionadas?" e as palavras `mMensagem[1,19]` = "Sim" e `mMensagem[1,20]` = "Não" (`AllowNone =
  false`, `AllowArbitraryInput = false`). Sem "Sim" **e** sem linha selecionada, sai.
- **A linha que fica selecionada** (`JaTp14wdVuV`, `:2225`): a primeira selecionada **menos um**,
  nunca abaixo de 0 — é o que o fim do handler reseleciona e rola até ela.
- **Por página selecionada:** `Pagina.checaCapa` (`Pagina.cs:2595`; "1", "001", "0001", "00001",
  "000001", "0000001") → `MsgBox(mMensagem[1,17])` = "A Capa não pode ser apagada!" **crítico** e a
  página é **pulada**; senão `Pagina.ApagarElementosPagina` + `Pagina.RemoveLayer`.
- **`ApagarElementosPagina`** (`Pagina.cs:2121`): `LockDocument`; toda entidade do ModelSpace no
  layer da página sofre **`clsApagar.ApagarDerivados`** (`clsApagar.cs:9`) **antes** do `Erase`.
- **`RemoveLayer`** (`Pagina.cs:2199`): `LockDocument`; passa a camada corrente para o layer `"0"` e
  apaga o layer. O `bAtivaPag` (só `frmExportarImportar.cs:1514` usa `true`) **não** entra aqui —
  a paleta deixa a camada corrente no `0`.
- **Sincronizações, nesta ordem** (`uscPaginas.cs:2205-2212`): `CarregaPaginas`,
  `OrdenaMatrizPaginas`, `AtualizaContTotFl`, **`clsConexao.sincronizaCircuitos`**,
  **`clsInterligacao.SincronizaCruzamentoInterlig`**, **`clsDePara.SincronizaDePara(false)`**,
  **`clsDispositivoAuxiliares.ApagaContatosOrfaos`**, **`clsDispositivoAuxiliares.SincronizaContatos`**,
  **`clsPortas.SincronizaPortas`**.
- **Fim:** `DeclaracoesGeral._uscPagina.CarregaPG()` (rebate a grade inteira, inclusive os cinco
  sub-itens do `Inserir`), restaura o check da `Multiseleção`, reseleciona a linha calculada e
  `FirstDisplayedScrollingRowIndex` nela.

### Mensagens exatas (Mensagens-PT.txt)

| índice | texto |
|---|---|
| 14 | `Multiseleção` |
| 17 | `A Capa não pode ser apagada!` |
| 19 / 20 | `Sim` / `Não` |
| 21 | `Apagar Páginas` |
| 23 | `Apagar as páginas selecionadas?` |
| 29 | `Nova Página` |
| 30 | `Desative a multiseleção!` |
| 31 | `Não há espaço para uma nova página!` |
| 32 | `Esta página já existe!` |
| 33 | `Não foi possível criar esta página!` |
| 35 | `Inserir` |

## O que foi feito

| arquivo | o quê |
|---|---|
| `cad-plugin/Positron.Data/Paginas/ColunasDoFormato.cs` | **novo**: o `Pagina.verificaLayerExtraNoFormato` — as cinco colunas `ELET1_..ELET5_`, `DosLayers` e `TemAlguma` (com o quirk da ordem da enumeração) |
| `cad-plugin/Positron.Data/Paginas/GradeDeFolhas.cs` | **novo**: `ReferenciaDaNovaPagina` (a linha selecionada e a seguinte, com o sentinela `"1000000"` na última) e `LinhaAposApagar` (o `JaTp14wdVuV`: `primeira - 1`, piso em 0) |
| `cad-plugin/Positron.Data/Interface/MensagensDoReverso.cs` | as mensagens 14, 17, 19..21, 23, 29..33 e 35 |
| `cad-plugin/Positron.Plugin/Paginas/ColunasDoDesenho.cs` | **novo**: `Ler()` (as cinco colunas da tabela de layers; sai antes quando não há formato) e `Inserir(pagina, tipo)` (o `Pagina.InserirColuna`, com `LockDocument`) |
| `cad-plugin/Positron.Plugin/Paginas/TrocaColunasDoDesenho.cs` | reutiliza `ColunasDoDesenho.InserirColuna` no passo 3 (o corpo era o mesmo) |
| `cad-plugin/Positron.Plugin/Paginas/CriacaoDePaginaDoDesenho.cs` | `LockDocument` na criação do layer e dos campos (quem chama é a paleta) |
| `cad-plugin/Positron.Plugin/Paginas/ExclusaoDePaginaDoDesenho.cs` | `LockDocument`, `Falha` por página (o `MsgBox(ex.Message, Critical)` do original) e a camada corrente que fica no `"0"` |
| `cad-plugin/Positron.Plugin/Paginas/PaginasDoDesenho.cs` | `LockDocument` no `Renomear` |
| `cad-plugin/Positron.Plugin/Paginas/UnidadeDaPaginaDoDesenho.cs` | `LockDocument` no `Gravar` |
| `cad-plugin/Positron.Plugin/Paginas/TitulosDaPaginaDoDesenho.cs` | `LockDocument` no `Gravar` |
| `cad-plugin/Positron.Plugin/Interface/Aviso.cs` | `MsgBoxCritico` (o `MsgBoxStyle.Critical`, usado na capa e nas falhas por página) |
| `cad-plugin/Positron.Plugin/Interface/ConfirmacaoDoUsuario.cs` | **novo**: o `PromptKeywordOptions` do original (`Sim`/`Não`) com o gancho `POSITRON_CONFIRMA` para o harness |
| `cad-plugin/Positron.Plugin/Interface/RespostaDoHarness.cs` | **novo**: os ganchos `POSITRON_UNIDADE`, `POSITRON_ALTERNATIVO` e `POSITRON_TITULO1..4` na pergunta do form da paleta (item 1c) |
| `cad-plugin/Positron.Plugin/Interface/Folhas/FormularioDaPagina.cs` | consulta `RespostaDoHarness` antes de abrir o diálogo |
| `cad-plugin/Positron.Plugin/Interface/Folhas/FolhasControle.cs` | `MultiSelect = false` por padrão (o item `Multiseleção` a liga); `Inserir` vira o submenu das cinco colunas; `Nova Página` usa a linha selecionada e os três `MsgBox`; `Apagar Páginas` confirma, recusa a capa, roda as sincronizações e reseleciona a linha anterior; teclas Insert/Delete na grade (só no tipo `E`) |
| `cad-plugin/Positron.Plugin/Interface/Folhas/ProvaDaPaleta.cs` | **novo**: o comando `pzFolhas` — monta o `FolhasControle` e chama os mesmos handlers do menu/tecla |
| `cad-plugin/Positron.Plugin/Comandos.cs` | `ExecutarNovaPagina(referencia, posterior)` com o resultado discriminado; `ExecutarExclusaoDePaginas` com as sincronizações do `SYNCD` e sem a reativação inventada (o original deixa `Clayer = "0"`); comando `pzFolhas` |
| `scripts/cad-fixture-folhas.lsp` | **novo**: monta `ELET1_COMANDO` e `ELET2_SINALIZACAO` no formato e despeja `CLAYER`, os layers das páginas e as entidades com XData `DiagLog`/`COLUNAS` |
| `cad-plugin/Positron.Data.Tests/ColunasDoFormatoTests.cs` | **novo**: +8 testes |

**Desvios do original (com motivo):**

- **Reativação no apagar retirada:** o `ExecutarApagarPaginas` do recoder (rodada 174) reativava a
  página seguinte quando a ativa era apagada. O `RemoveLayer` do original (`Pagina.cs:2225`) põe
  `Clayer = "0"` e o `bAtivaPag` (que só o `frmExportarImportar.cs:1514` passa `true`) **não** entra no
  apagar da paleta — então a camada corrente fica no `"0"`, como lá.
- **Sincronizações do apagar:** a família `clsConexao.sincronizaCircuitos` /
  `clsInterligacao.SincronizaCruzamentoInterlig` / `clsDePara.SincronizaDePara` /
  `clsDispositivoAuxiliares.ApagaContatosOrfaos`+`SincronizaContatos` / `clsPortas.SincronizaPortas`
  é a mesma que os `SYNCD`/`SYNCV`/`RESTPROJ` tratam pelo **stand-in** do recoder (`CorrigeModelosDeContatos` +
  `FIA` + `INT`), e é o que roda aqui.
- **`clsApagar.ApagarDerivados`** no `ApagarElementosPagina`: não portado (ver *Falta*).
- **`CurrentCell` no `DataGridView` fora da tela:** sem `Handle` criado, `ClearSelection()` deixa a
  `CurrentCell` na linha 0 e ela volta a selecionar a linha 0 em `MultiSelect = false`; mover a
  `CurrentCell` para a linha alvo antes de marcar `Selected = true` faz o `JaTp14wdVuV` valer tanto
  na tela quanto no harness.

## Prova

- `plugin:test`: **929** (921 + 8 novos), `Total: 929, Errors: 0, Failed: 0` pelo console runner do
  xunit.
- builds ZWCAD / AutoCAD: 0 avisos, 0 erros.
- **AutoCAD 2020** (`accoreconsole`, cópia do `Funcional.dwg`, DWG 63, pelo `pzFolhas`, que monta o
  `FolhasControle` real e chama o mesmo método do clique/tecla):

**(A) `Nova Página` pela linha selecionada** — a página ativa do desenho é a `23`, mas a linha
selecionada na grade é a `2`: a página criada é a **`3` (entre `2` e `6`)**, que vira a camada
corrente (`CLAYER;3`), com os campos do formato e os títulos herdados de `2` (antes a paleta criava
depois da `23`, ignorando a seleção):

```
pzFolhas: 17 página(s) na grade [1 | 2 | 3 | 6 | 7 | 8 | 15 | 16 | 17 | 18 | 19 | 20 | 21 | 22 | 23 | 24 | 1000] (antes: 16);
          seleção pedida [2] (1 achada(s)); selecionada depois [3];
          ação "nova" → NOVAPAGINA: página "3" criada depois de "2" — layer + 5 campo(s) do formato copiado(s)
                        + 3 título(s) herdado(s) de "2" + 17 CONT/FL/TOT recalculado(s).
CLAYER;3
```

**(B) `Nova Página` com a multiseleção ligada** → `mMensagem[1,30]`, nada criado:

```
Desative a multiseleção!
pzFolhas: 16 página(s) na grade ... ação "multiselecao" → Desative a multiseleção!
```

**(C) `Inserir` de coluna do formato (`ELET1_COMANDO`) nas páginas `2` e `6`** — as cinco colunas são
lidas da tabela de layers (`ELET1_COMANDO` e `ELET2_SINALIZACAO` visíveis, `ELET3..5` ausentes) e as
duas `LINE` da definição do formato nascem em cada página com o XData `DiagLog`/`COLUNAS` (despejo
independente por `entget`):

```
pzFolhas: ... seleção pedida [2 | 6] (2 achada(s));
          ação "inserir:1" → Inserir: coluna "ELET1_COMANDO" em 2 de 2 página(s) — 4 entidade(s) clonada(s) do formato.;
          colunas do formato visíveis [ELET1_COMANDO | ELET2_SINALIZACAO | ELET3_ausente | ELET4_ausente | ELET5_ausente]
COLUNA;LINE;layer=6;tipo=ELET1_COMANDO
COLUNA;LINE;layer=6;tipo=ELET1_COMANDO
COLUNA;LINE;layer=2;tipo=ELET1_COMANDO
COLUNA;LINE;layer=2;tipo=ELET1_COMANDO
```

**(D) `Apagar Páginas` com `POSITRON_CONFIRMA=Não`** → nada apagado (16 páginas continuam na grade):

```
pzFolhas: 16 página(s) na grade ... ação "apagar" → Apagar Páginas: cancelado (a resposta não foi "Sim").
```

**(E) `Apagar Páginas` com `1, 2, 23` e `POSITRON_CONFIRMA=Sim`** — a capa (`1`) recebe o `MsgBox`
crítico `A Capa não pode ser apagada!` e **fica**; `2` e `23` (que era a ativa) são apagadas; rodam
as sincronizações (`CorrigeModelosDeContatos` + `FIA` + `INT`); a camada corrente vai para o `"0"`
(`CLAYER;0`, sem a reativação inventada); e a linha selecionada volta para a `1` (índice 0):

```
A Capa não pode ser apagada!
Apagar Páginas — sincronizações: [1/3] CorrigeModelosDeContatos: ... [2/3] FIA: 478 linha(s) ... [3/3] INT: 20 linha(s) ...
pzFolhas: 14 página(s) na grade [1 | 6 | 7 | 8 | 15 | 16 | 17 | 18 | 19 | 20 | 21 | 22 | 24 | 1000] (antes: 16);
          seleção pedida [1 | 2 | 23] (3 achada(s)); selecionada depois [1];
          ação "apagar" → APAGAPAGINA: 2 página(s) apagada(s) (23, 2) — 194 entidade(s) do ModelSpace e 2 layer(s).
CLAYER;0
LAYER;1;existe
LAYER;2;apagado
LAYER;23;apagado
```

**(F) O `JaTp14wdVuV` (a linha anterior selecionada depois de apagar)** — apagando a página `22`
(índice 12), a selecionada passa a ser a `21` (índice 11):

```
pzFolhas: 15 página(s) na grade ... seleção pedida [22] (1 achada(s)); selecionada depois [21];
          ação "apagar" → APAGAPAGINA: 1 página(s) apagada(s) (22) — 74 entidade(s) do ModelSpace e 1 layer(s).
```

## Falta

- [ ] **`clsApagar.ApagarDerivados`** (`clsApagar.cs:9`), chamado pelo `ApagarElementosPagina` antes
  do `Erase` de cada entidade: apaga a polyline irmã de interligação tipo 2 (`clsInterligacao.ApagarPL`),
  a máscara (`clsMascara.ApagaAMascara`), a inserção de tabela do contato auxiliar
  (`clsDispositivoAuxiliares.limpaInsercaoTabela`) e promove o complementar / apaga os contatos de
  modelo do dispositivo principal (`clsDispositivo.promoveComplementar` /
  `ApagaContatosModeloDispositivo`) — **inclusive o que mora em outras páginas**. Nenhuma das cinco
  rotinas existe no recoder hoje; vai para a fila como item próprio.
- [ ] **A família `Sincroniza*` da tela/cruzamento** (`sincronizaCircuitos`,
  `SincronizaCruzamentoInterlig`, `SincronizaDePara`, `ApagaContatosOrfaos`, `SincronizaContatos`,
  `SincronizaPortas`): aqui entra pelo stand-in do `SYNCD` (`CorrigeModelosDeContatos` + `FIA` + `INT`),
  como nos outros pipelines.
- [ ] **`tbPagina.Text = ...` depois da `Nova Página`/Insert** e o layout visual da paleta: entram no
  **item 3** da correção do básico (a paleta fiel ao `uscPaginas`, onde a faixa de cima nasce).
- [ ] **`POSITRON_FORMATO_TROCAR`** (a confirmação da troca de formato no `CAD`): o comando já lê a
  variável; falta trocar o gate pelo `ConfirmacaoDoUsuario.Perguntar` com a `mMensagem[1,75]` quando a
  troca de formato for revisada.
- [ ] **Conferência visual do dono** (clique no menu de contexto e nas teclas Insert/Delete na paleta
  ancorada, em ZWCAD/AutoCAD).

## Conhecimento registrado

`docs/recoder/conhecimento/paginas.md` — seção nova sobre o **`uscPaginas`**: como o `Inserir` monta
os cinco sub-itens (`Pagina.verificaLayerExtraNoFormato` e `InserirColuna`), a diferença entre o
`Nova Página` da paleta (que parte da linha selecionada e respeita o `MultiSelect`) e o comando, o
`Apagar Páginas` completo (a pergunta 23 com `Sim`/`Não`, a capa 17, o `RemoveLayer` que deixa o
`Clayer` no `"0"`, o `JaTp14wdVuV` e o `clsApagar.ApagarDerivados`). No `RUNBOOK.md`, *Troubleshooting*:
a armadilha da `CurrentCell` do `DataGridView` sem `Handle` (em `MultiSelect = false` a linha 0 volta
a ficar selecionada se a `CurrentCell` não acompanhar).

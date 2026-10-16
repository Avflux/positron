# Páginas — títulos, textos e a paleta (`uscPaginas`)

Caminhos relativos a `cad-plugin/reverso/Eletron4_ZWcad/decompiled-cleaned/Eletron4/`.

## Títulos de página (`DiagLog`/`TituloPagina`)

- Layout do XData: `TituloDaPaginaXData` (`cad-plugin/Positron.Data/Paginas/`).
- `clsEditaTitulosTextos.LeXDataTitulo` (`clsEditaTitulosTextos.cs:230`) só reconhece os índices **1..4**
  (`array[2] > 0 And < 5`); os outros índices do `TituloPagina` (6 = página, 8 = revisão…) não são "título".
- `Pagina.buscaTitulosExistentes` (`Pagina.cs:2502`) lê as `AttributeReference` do bloco de formato
  (`blockFormatoID`, o `BlockReference` com `DiagLog`/`Formato`) no layer `-1`: `TITULOnPAG` → título n, e
  **`PAINEL` → título 4**. No `Funcional.dwg` existem os títulos 1, 2 e 3 (rodada 179).

## Grade `frmEditaTitulos` e faixa da paleta (rodada 183)

- **Não confundir três caminhos:** `capturaTitulosDeUmaPagina`/`AtualizaTitulosDeUmaPagina`
  usam o contrato individual (limite de quatro); a grade usa `capturaTitulos` (`Pagina.cs:722`) /
  `AtualizaTitulos` (`:1653`). A grade lê **TextString** (não o valor do XData), último índice
  duplicado vence; aplica a **todos** os DBText 1..4 e **9** (Alternativo), sem limite de quatro,
  regravando texto e XData. `clsTextos.AtualizaUnidadeAlternativo` (`clsTextos.cs:1460`) grava o layer.
- `frmEditaTitulos.cs:748-765` começa em **2** na matriz: a capa não aparece. Colunas Página,
  Títulos 1..4, Unidade, Alternativo; só Página é read-only. Formato decide títulos visíveis;
  registro decide Alternativo. Copiar usa buffer privado; Colar/Limpar/Substituir mudam apenas a
  grade; somente **Editar DWG** aplica e fecha (`:774-870`). X fecha sem aplicar.
- `frmEditaTitulos.cs:533-560` chama `Pagina.restauraCampos` **antes** de ler formato/títulos:
  essa cadeia apaga/recria campos, preserva títulos/revisões e recalcula CONT/FL/TOT
  (`Pagina.cs:2050-2098`). Não é equivalente a executar a cadeia inteira de **troca de formato**.
- `uscPaginas.cs:1280-1324,1996-2026`: HKCU `Software/Cadgraph/Eletron4`, `Altern` string `0`/`1`,
  padrão **0**. A grade tem Página | Unidade | Alternativo, Pg/PgDecimal invisíveis; não PgAtiva.
- `btSalva` (`uscPaginas.cs:1510-1610`) **não salva o arquivo**: arma capturar a página corrente
  no próximo clique em lb1..4. `Dicionario.cs:99-259`: NOD `CENG_ELET`, Xrecord `Atalhos`,
  **seis strings DXF 1** (a UI usa quatro, mas as outras duas precisam ser preservadas).
- `statusBanco` (`uscPaginas.cs:2600`) recebe contador de conexões >0; arquivo existente não é
  conexão. Menu D/A/V ausente e grade read-only (`:1488-1501`).

## `EditaTitulosTextosDoDWG` (`TROCTT`, rodada 179)

- Filtro de página: `List.Contains(Ent.Layer)`, que diferencia maiúsculas. `BlockReference` é pulado (atributos não entram).
- `LerXDataVazio` (`:174`) = tem XData de `Eletron`, `DiagLog`, `TextoLP`, `AUXCONEXAO`, `AUXINTERLIG`,
  `AUXIMPORTADO`, `DEPARA` ou `Definicao`. Texto/multitexto com um deles não é "texto do AutoCAD".
- A troca é `String.Replace` (diferencia maiúsculas), mas só grava se `novo.ToUpper.Trim <> velho.ToUpper.Trim`
  (`TextCompare`). Uma troca que só muda a caixa não grava nem conta.
- O título trocado **não** tem o valor do XData atualizado (só o `TextString`). O `AtualizaUmTituloEditado`
  (`:258`), que regrava o XData, é de outro caminho.
- Cada texto é gravado com lock + transação próprios (`clsTextos.AtualizarTexto`/`AtualizarMTexto`), dentro da
  transação de leitura, que não tem lock.

## Paleta `uscPaginas`: `Inserir`, `Nova Página`, `Apagar Páginas` e as teclas (rodada 182)

- **As cinco colunas do `Inserir`** (`uscPaginas.cs:1083, 1376-1393, 2466-2565`): o item
  `InserirToolStripMenuItem` (`mMensagem[1,35]` = "Inserir") tem **cinco sub-itens**
  (`ToolStripMenuItem1..5`). O rótulo e a visibilidade vêm de
  `Pagina.verificaLayerExtraNoFormato(ref bLayers)` (`Pagina.cs:2315-2412`), que varre a **tabela de
  layers** do desenho: cada nome que começa com `ELET1_`..`ELET5_` liga `bELETn` e guarda o resto do
  nome (`name.Remove(0, 6)`) como texto do sub-item. Sem `blockFormatoID` válido a rotina sai antes
  (tudo falso); com todos falsos o `Inserir` inteiro fica **invisível**. Quirk: quem decide é a ordem
  de enumeração da tabela (o último `ELETn_*` lido fica). O clique chama
  `Pagina.InserirColuna(pagina, "ELETn_" + ToolStripMenuItemN.Text)` (`Pagina.cs:2415-2478`, com
  `LockDocument`) para **cada linha selecionada** da grade: toda entidade da **definição** do bloco de
  formato com `Layer == sTipo` é clonada para o ModelSpace no layer da página e recebe o XData
  `DiagLog`/`COLUNAS` (`XDataGeral.gravarXDataColuna`, `:1813`).
- **`Nova Página` e a tecla Insert** (`TBNp1Uume8n`, `uscPaginas.cs:1888-1972`, e `wZ0p1XlFJ5o`,
  `:1859-1884`): a tecla só age no desenho do Elétron (`ativo.Tipo == "E"`). Com `dg.MultiSelect`
  ligado → `MsgBox(mMensagem[1,30])` = "Desative a multiseleção!" e sai (o padrão da grade é
  `MultiSelect = false`; o item `Multiseleção` é que o liga, `:1974-1993`). Sem multiseleção, a
  referência é a **linha selecionada** (`dg.Rows[index].Cells[0]`), com os títulos dela, e a posterior
  é a **linha seguinte** (na última, o sentinela `"1000000"`). As três recusas têm cada uma o seu
  `MsgBox` de informação, título "Elétron": `PgNum == 0` → 31 ("Não há espaço para uma nova página!");
  `CriarLayer == "-1"` → 32 ("Esta página já existe!"); `CriarLayer == "0"` → 33 ("Não foi possível
  criar esta página!").
- **`Apagar Páginas` e a tecla Delete** (`cPup1SWxSYc`, `uscPaginas.cs:2157-2222`): o texto visível do
  item é a `mMensagem[1,21]` = "Apagar Páginas" (o construtor sobrescreve o "Excluir Páginas" do
  designer, `:1299`). Pergunta com `PromptKeywordOptions`: `mMensagem[1,23]` ("Apagar as páginas
  selecionadas?"), palavras `Sim` (19) e `Não` (20). Por linha selecionada: `Pagina.checaCapa` (`:2595`,
  `"1"`..`"0000001"`) → `MsgBox(mMensagem[1,17], Critical)` = "A Capa não pode ser apagada!" e pula a
  página; senão `ApagarElementosPagina` + `RemoveLayer(text)` (`bAtivaPag = false`: a camada corrente
  passa para o `"0"` e **fica lá** — só `frmExportarImportar.cs:1514` passa `bAtivaPag: true`). Antes
  de apagar cada entidade o `ApagarElementosPagina` chama `clsApagar.ApagarDerivados` (`clsApagar.cs:9`).
  Depois do laço rodam `CarregaPaginas`, `OrdenaMatrizPaginas`, `AtualizaContTotFl`,
  `clsConexao.sincronizaCircuitos`, `clsInterligacao.SincronizaCruzamentoInterlig`,
  `clsDePara.SincronizaDePara(false)`, `clsDispositivoAuxiliares.ApagaContatosOrfaos`,
  `clsDispositivoAuxiliares.SincronizaContatos`, `clsPortas.SincronizaPortas`, e o handler fecha com
  `CarregaPG()` e a seleção de volta na linha calculada por `JaTp14wdVuV` (`:2225`: a primeira linha
  selecionada **menos um**, nunca abaixo de 0).

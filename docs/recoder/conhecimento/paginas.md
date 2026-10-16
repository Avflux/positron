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

## Menu Editar Unidade / Alternativo (rodada 185)

- `uscPaginas.cs:2054-2135`: sem SelectedRows **retorna**, não edita a página ativa como fallback.
  PromptStringOptions com AllowSpaces e UseDefaultValue; padrão é a célula 1/2 de **SelectedRows[0]**
  (ordem da coleção da grade, não necessariamente a primeira página). Só Status 5100/OK prossegue.
- Mensagens 15 e 16 (`../Mensagens-PT.txt:16-17`); resposta **ToUpper().Trim()**, todos os selecionados
  recebem a resposta, cada qual conserva seu outro campo. Atualiza a célula correspondente, não
  recarrega CarregaPG: multiseleção permanece. Matriz mPaginas é relida/ordenada ao final.
- Menu **não limita Alternativo a 20**: essa validação pertence à edição inline, não generalizar.
  Alternativo chama `AtualizaContTotFl` (`Pagina.cs:1389`, inclui índice **9**) e UpdateScreen;
  Unidade não chama. Recálculo altera TextString, **não** regrava valor de título no XData.
- `XDataGeral.AlteraXDataUnidadeAlternativo` (`:1243-1325`) tem lock/transação por layer; sem Eletron
  cria Unidade; com Unidade altera índices 2/3 **preservando o restante do buffer**. O adapter atual
  do recoder já existia e recria quatro valores; preservação de extensões ainda é pendência de auditoria.
- Foco ofuscado resolvido: `../oADsu33FpCEasW73ADP/hDTV5h3NAKArXvSEL1u.cs:12-13`,
  `lwF3Qy6iqF` = user32 **SetFocus** para Window.Handle do documento, não um diálogo modal.

## `Renumerar Páginas` com destino (`C8Op1CM1YgS`, rodada 186)

- `uscPaginas.cs:2247-2390`: **desmarca** `dg.Rows[0]` se estiver selecionada e monta as duas listas num
  laço só sobre `dg.Rows`, **na ordem da grade** (`array2` = selecionadas + o nome novo, `array` = as
  outras). É a ordem da grade que casa página e nome novo — `dg.SelectedRows` (usado pelo `Inserir` e
  pelo `Apagar`) daria outro par: a primeira medição saiu `(6->3, 2->4)` e o original produz
  `(2->3, 6->4)`.
- **Laço de prompt** (`:2286-2390`), SetFocus na janela, `PromptStringOptions("\n" + mMensagem[1,24] +
  " ")`, `AllowSpaces = false`, **sem** `DefaultValue`; só `Status 5100` prossegue. Resposta
  `ToUpper()` + `montaNumeroPagina`.
- Recusas (todas voltam ao prompt): `checaCapa(alvo)` → mMensagem **57**; alvo entre as **selecionadas**
  → **26**; alvo que já é outra página → **25**; espaço insuficiente → **27**.
- O **limite** `p` = a primeira linha **não** selecionada, na ordem da grade, com página decimal maior
  que a do destino; sem nenhuma, o sentinela `"1000000"`.
- `calculaEspacoNumerico`/`calculaEspacoAlfaNumerico` (`Pagina.cs:305-350`) decidem o ramo; o original
  testa `>= 0` contra o número de **selecionadas** (`UBound(array2, 2)`), então sem seleção o ramo
  numérico sempre "cabe" e não renomeia nada — o prompt acontece igual (o laço está **fora** do
  `If dg.SelectedRows.Count > 0`).
- `definePaginasNumericas` (`:352-382`): do destino (ou `Floor(calculaPaginaDecimal) + 1` quando o
  destino tem letra) de `Conf.PassoPagina` em diante, cada nome pelo `montaNumeroPagina`.
- `definePaginasAlfaNumericas` (`:384-425`): `Asc` da última letra + o resto como número; em `Asc == 91`
  volta a 64 (página "seca") e o número sobe — 27 páginas por número (26 letras + a seca). Destino vazio
  ou com prefixo não numérico **estoura** (`Strings.Mid("", 0, 1)` / `Conversions.ToInteger`) e sai no
  `MsgBox` crítico do `catch`, sem renomear.
- `renumerarPaginasLote` (`:1964-2036`): lock + transação; `LayerTable.Has` e `Layer.Name = novo`; depois
  `CarregaPaginas`, `OrdenaMatrizPaginas`, `AtualizaContTotFl`. **Não** toca nos elementos da página nem
  no XData `Eletron` do layer (confirmado por dump LISP em AutoLISP no `Funcional.dwg`).
- Fim do handler: `Y9op1KgeRgW` + `VSWp1ebyWra` reconstroem a grade, **desligam a multiseleção** e
  reselecionam a linha de `ativo.Pagina`; a cascata de sincronizações roda (a mesma família do apagar,
  menos o `ApagaContatosOrfaos`). `ativo.Pagina` **não** é recalculado aqui — só o combo o faz.

## Combo `Folha` (`Es6p1Y15jTb`, rodada 186)

- `uscPaginas.cs:2389-2455`, ligado ao **`TextChanged`** do `ToolStripComboBox` (que é editável), com a
  guarda `fKqplRiGop5` em volta da escrita do texto dentro do `CarregaPG` (`:1326-1360`).
- `switch` do literal, `TextCompare: true` e **sem `default`**: `12` → 0, `012` → 3, `0012` → 4,
  `00012` → 5, `000012` → 6, `0000012` → 7. Texto fora dos seis **não** mexe na largura mas o corpo roda
  igual (o `montaNumeroPagina` de cada linha e o `renumerarPaginasLote`).
- Grava `XDataGeral.GravarXDataConfiguracao()` (o `Eletron`/`Config` do ModelSpace; a largura é o `1070`
  da posição 34) — só isso faz o combo refletir a configuração no próximo `CarregaPG`.
- Renomeia **todas** as linhas (não só as selecionadas) e no fim faz
  `DeclaracoesGeral.ativo.Pagina = Pagina.LocalizaPaginaAtiva()`, `cmStrip1.Hide()` e
  `Application.UpdateScreen()`. `CarregaPG` **não** é chamado (o texto digitado fica no campo).

## Restauração específica do editor (rodada 184)

- `Pagina.restauraCampos` (`Pagina.cs:2050-2123`) não é a restauração pós-troca de formato:
  captura títulos e revisões simplificadas, apaga/recria campos, devolve títulos/revisões e
  recalcula CONT/FL/TOT. **Não** troca colunas, reconstrói definições de revisão, sincroniza
  atributos, grava configuração ou ativa capa. Tem lock e transação abrangente.
- `ApagarCamposPaginas` (`Pagina.cs:1118-1195`) remove todo DBText marcado com índice positivo,
  não apenas títulos 1..4 nem apenas layers de página. Duplicados e campos obsoletos desaparecem;
  recriam-se os campos dos atributos do formato. Textos comuns sem marca ficam.
- `Revisao.capturaRevisoesSimplificadas` (`Revisao.cs:80-157`) lê **TextString**, último índice 8
  da página vence. `AtualizaRevSimplificada` (`:159-243`) restaura texto **e XData**.
- A chamada é anterior a `buscaTitulosExistentes` (`frmEditaTitulos.cs:557`): mesmo descartar a
  grade pelo X não desfaz a **restauração estrutural já feita na abertura**. Descarte significa
  não aplicar os valores editados localmente, não prometer desenho sem qualquer alteração.

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

## XData de máscara, porta e definição (rodada 210)

Layouts que o `ApagaAMascara` regrava (`XDataDispositivosMaster.cs`); app name `Dispositivo` (a `Definicao` tem o dela, e aceita o legado `DEFINICAO`):

| XData | gravação | leitura (índices) |
|---|---|---|
| máscara `M` | `:502`, 29 valores (`1011` no 19; usuário/data nos 24/25) | `:740` ramo `M`: Nome1 2, Nome2 3, Alternativo 4, Painel 8, indexModelo 12, Complementar 13 (`-1`/`0` na gravação), HandleMascPrincipal 14, Topografico 16, Layout 17, iLM1 21, iLM2 23 |
| porta `E` | `:396`, 18 valores (usuário/data nos 16/17) | Nome1 2, Nome2 3, HandleDaMascara 4, indiceDoModelo 5, indiceDaPorta 6, handleDaDefinicao 9, chavePrimaria 10, Alternativo 11 |
| `Definicao` | `:903`, 5 valores | `:970`: HandleDaMascara 1, indiceDoModelo 2, indiceDaPorta 3, handleDaPorta 4 |

Classes: `Positron.Data/Paginas/ApagarMascara.cs` (`EstadoDaMascara`, `EstadoDaPorta`, `EstadoDaDefinicao`).
`EditaUmAtributoDeUmBloco(handle, tag, valor, bliga)` (`clsBlocos.cs:391`): grava o texto só se mudou, **`Visible = bliga`**, `AdjustAlignment` e `Draw`.

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

## Paleta `uscPaginas`: a edição inline da célula Página (rodada 212)

`dg.CellEndEdit` → `j9Sp1mKZkcD` (`uscPaginas.cs:1733-1846`), ligado no designer em `:220`. O mesmo
handler trata a Unidade (`case 1`, só regrava o XData) e o Alternativo (`case 2`, com o limite de 20 =
mMensagem 1927, `CarregaPaginas`, `OrdenaMatrizPaginas` e `AtualizaContTotFl`). A coluna Página (`case 0`)
**não** é `ReadOnly` no designer.

- **Coluna `Pg` (`Cells[3]`)** guarda o nome **carregado** da linha (a coluna `PgDecimal`, `Cells[4]`, é o
  decimal): é de onde o original tira o nome antigo para reverter. A coluna `Pg` some da edição inline
  só porque não é a editada.
- **Normalização:** `Trim()`; na coluna 0, `ToUpper()` quando não vazio. **Vazio** → escreve
  `DeclaracoesGeral.ativo.Pagina` (a **página ativa**) na célula e **retorna** — sem renomear. Esse teste
  vem **antes** do teste da capa, então vale para a linha 0 também. Na prática a ativa é a própria linha
  (a seleção a ativa), então o quirk quase sempre coincide com reverter.
- **Linha 0 (a capa):** escreve de volta `Cells[3]` e sai. É a **única** proteção da primeira linha —
  não há `ReadOnly` na linha nem no designer; o que há é reversão.
- **Validação (linhas ≥ 1):** não numérico com **um** caractere → reverte; com mais, **todo caractere
  menos o último** tem de ser dígito (o último pode ser a letra do alfanumérico) — qualquer outro →
  reverte. Depois `Pagina.montaNumeroPagina` (`Pagina.cs:1819`) e `Pagina.LayerValido` (`:240`).
- **`Pagina.renumerarPagina` (`Pagina.cs:1841-1902`):** percorre `mPaginas`; se o nome novo já é página,
  `MsgBox` de informação da mMensagem **28** (`Esta página já existe!`, o mesmo texto da 32 do
  `CriarLayer`) e devolve **false** (não renomeia). Senão `alteraNomeLayer` (`:1903`, `LockDocument` +
  transação, **só** o `Name` do layer — o XData `Eletron` e os elementos ficam), atualiza a matriz,
  `OrdenaMatrizPaginas` e `AtualizaContTotFl`.
- **Fim do handler:** no sucesso, `Y9op1KgeRgW()` (reconstrói a grade) + `VSWp1ebyWra()` (multiseleção
  desligada, linha da ativa) e `tbPagina.Text = text2` (mesmo se a página renomeada **não** é a ativa: o
  original não recalcula `ativo.Pagina` aqui). A família de sincronizações
  (`clsConexao.sincronizaCircuitos`, `clsInterligacao.SincronizaCruzamentoInterlig`,
  `clsDePara.SincronizaDePara(false)`, `clsDispositivoAuxiliares.SincronizaContatos`,
  `clsPortas.SincronizaPortas`) roda em **todo** ramo que chega ao fim do `case 0` — inclusive quando o
  `LayerValido` recusa — mas **não** quando o handler sai antes (vazio, capa, um caractere não numérico,
  prefixo inválido, nome inalterado). Exceção → `MsgBox` crítico.
- A existência é conferida contra o **`mPaginas`**, não contra a grade: a célula em edição já carrega o
  nome digitado e não pode contar como página existente.

## `AtualizaContTotFl`: o que ele reescreve (medido na rodada 213)

O passo fecha o `Pagina.renumerarPagina` (e o `Apagar`/`Renumerar Páginas`): varre os `DBText` do
ModelSpace que têm o XData `DiagLog`/`TituloPagina` com índice e escreve **só o `TextString`** — o
XData (app, índice e o texto que ele guarda) **fica como estava**.

| índice | campo | texto que recebe |
|---|---|---|
| 5 | `CONT` | a **próxima** página válida daquele layer (o `BuscaProximaPaginaValida`) |
| 6 | `FL` | o **próprio layer** da entidade (portanto o nome novo, quando o layer foi renomeado) |
| 7 | `TOT` | a **última** página do caderno |
| 9 | `ALTERNATIVO` | o alternativo da própria página |
| 8 | `REV` | **não** é tocado |

Com o `Conf.incluirColuna` em 3..5, o `CONT` e o `TOT` trocam a página pelo **alternativo** dela quando
existe. Medido na cópia do `Funcional.dwg`: renomeando `7 → 7A`, uma sentinela `índice 5` no layer `6`
vira `7A`, uma `índice 6` no layer `7` vira `7A` (o layer virou `7A`) e uma `índice 7` vira `1000`.

## O XData `Eletron` do layer: **criar** e **atualizar** são caminhos diferentes (medido na rodada 214)

A unidade e o alternativo de uma página moram no XData `Eletron` do `LayerTableRecord` e são gravados
por **dois** caminhos do `XDataGeral.cs`, com resultados diferentes no buffer:

| situação do layer | caminho do original | o buffer depois |
|---|---|---|
| **sem** `GetXDataForApplication("Eletron")` | `GravarXDataUnidadeAlternativo` (`:1085-1124`) | **novo**, com os **quatro** valores (`1001 "Eletron"`, `1000 "Unidade"`, `1000 unidade`, `1000 alternativo`) |
| com o XData da marca **`Unidade`** (`array[1].ToUpper() == "UNIDADE"`) | `AlteraXDataUnidadeAlternativo` (`:1243-1296`) | o **mesmo** array, com **só** as posições 2 e 3 trocadas — as demais (inclusive valores de outro código de grupo: 1070/1040…) voltam intactas |
| com o XData de **outra** marca | idem | **intocado**: o `if` não tem `else` e nada é escrito |

- A varredura é pelo **nome do layer comparado sem caixa** (`Pagina: true`/`TextCompare`) e a checagem
  da marca também é sem caixa (`"unidade"` vale).
- Quem decide o caminho é a **existência do `ResultBuffer`** da marca, não a existência do layer.
- Consequência prática (por que o recoder **não pode** recriar os quatro valores ao atualizar):
  **desenhos reais têm valores além dos quatro** — um `1000 "EXTRA"` e um `1070` posto no layer `6` do
  `Funcional.dwg` sobreviveram à gravação pelo caminho do `Altera`, e sumiriam pelo do `Gravar`.
- A **leitura** (`LeXDataUnidadeAlternativo`, `:1136`) checa a marca em `array[1]` e então indexa
  `array[2]`/`array[3]` **direto**: um buffer de menos de quatro valores estoura no original. No recoder
  a atualização **completa** o buffer curto até os quatro (desvio declarado, fixado em teste).

## O Excel ativo dos títulos (`frmEditaTitulos`) — as duas direções (rodadas 215 e a prova viva de 2026-10-16)

Lê/escreve o **Excel aberto** pela PIA (`Microsoft.Office.Interop.Excel`), não um arquivo nosso.

- **Exportar** (`frmEditaTitulos.cs:875-888`) = `VerificaExcelAtivo` → `DesativaCalculoExcel` →
  `clsTextos.ExportaPaginas` → `AtivaCalculOExcel`; **Importar** (`:890-917`) acrescenta
  `dg.RowCount <= 0` como saída antecipada.
- **A direção importa:** a importação lê a aba e **escreve na grade** — o desenho **não** muda (quem grava
  é o Editar DWG). Consequência medida: uma importação seguida de exportação devolve à aba o valor que a
  importação leu (o ciclo é Excel → grade → Excel), então a prova de que a importação mexeu na grade é a
  **convergência** — a segunda importação seguida dá **0 célula** (medido: `75 entrada(s) lida(s)`, `1` e
  depois `0` célula).
- **`DesativaCalculoExcel` (`ExcFuncoesExcel.cs:395-416`)**: `ScreenUpdating = false` e `Calculation = Manual`
  **exceto** com o CAD em `A_2025`/`A_2026`/`A_2027`, quando chama o `AtivaCalculOExcel` (cálculo **ligado**).
- **`VerificaExcelAtivo` (`:122-162`)**: com Excel aberto usa a instância ativa (livro e aba ativos; cria um
  livro se não houver, e desminimiza); sem Excel, cria pelo CLSID `00024500-0000-0000-C000-000000000046`.
  O `ExcelAberto()` (`:374-394`) conta o processo `EXCEL` mas trata um Excel **invisível** como **não aberto**
  e o **mata** (`process.Kill()`) — por isso a medição exige um Excel visível com livro.
- **Colunas da aba:** `Página` (com apóstrofo, para o Excel tratar como texto), `Título 1..4` (só os ligados
  em `buscaTitulosExistentes`), `Unidade` e `Alternativo` (este só com o `Altern` do registro ligado).
  Largura 0 = coluna escondida; `A1:G{n}` com fonte 10 centralizada e `E2:G{n}` com quebra.
- **A importação** lê da linha 2 até a última da coluna A; o `G` com mais de 20 caracteres é truncado e
  pintado com a mensagem 1927 (cor 3). Casa página e índice **sem caixa** e escreve só o que muda.
- **Bloqueio de ambiente (2026-10-16, resolvido):** a falha `LIGACAO: "frmEditaTitulos" falhou — a licença
  para usar este aplicativo expirou` era do **Office** desta máquina (não há gate de licença no plugin):
  `Range.ClearContents`/`EntireRow.Delete` falhavam fora do CAD com a mesma mensagem e, depois da ativação
  do Office pelo dono, os três testes passam.

## O status do banco na paleta: `monitorConexao` + `statusBanco` (rodada 219)

O `PictureBox2` do rodapé da paleta (31 × 17 em (16, 7), nascendo `DB_DISCONNECTED`,
`uscPaginas.cs:1209-1214`) **não** é "o banco está configurado": é o **contador de conexões abertas**.

- O contador é `DeclaracoesGeral.monitorConexao` (`DeclaracoesGeral.cs:566`, zerado no construtor
  estático em `:610`) — `public static int`.
- Quem o move é cada `Acesso*`, no par abrir/fechar, **sempre** seguido do aviso:
  `AcessoSQLite.cs:99-104` incrementa no `Open()` **só** quando o estado era `Closed` (e
  `fechaConexao()`, `:33-43`, decrementa **só** quando estava `Open`); o mesmo em `AcessoAccess.cs`
  (6 métodos) e `AcessoSQLServer.cs`.
- **`AcessoExcel` NÃO conta**: abre e fecha `OleDbConnection` (`AcessoExcel.cs:22,55,93,129,…`) sem
  nunca chamar `statusBanco`/`monitorConexao` — uma leitura de Excel aberto não mexe no ícone.
- O teste de provedores do Access (`AcessoAccess.cs:95-97`) também abre/fecha conexão de sondagem
  sem contar.
- A decisão: `uscPaginas.statusBanco(string valor)` (`:2606-2617`) faz
  `Conversions.ToDouble(valor) > 0` → `DB_CONNECTED`, senão `DB_DISCONNECTED`, e
  `Application.DoEvents()` no fim. É o **número**, não o arquivo.
- O reset é do arranque: `Iniciar.IniciarDWG` (`Iniciar.cs:178-179`) faz `monitorConexao = 0` e
  `statusBanco("0")`, e a linha fica **fora** do `if (!lDwgRegen.Contains(...))` — logo roda em toda
  ativação de documento, não só na primeira.
- **`CarregaPG`/`CarregaPaginas` não chamam `statusBanco`** (o grep do decompilado só acha as três
  famílias `Acesso*`, o `Iniciar.cs:179` e a própria definição em `uscPaginas.cs`): a carga da paleta
  não mexe no ícone, e o recoder não sincroniza o ícone ao carregar.

No recoder: `Positron.Data/MonitorDeConexao` (o contador, com o monitor da sessão em `Atual`),
`ProjectStore.Abrir()` incrementando e o `Disposed` da conexão decrementando,
`FolhasControle` trocando a imagem no aviso e `InicioDoDesenho.Iniciar()` reiniciando por ativação.

## O progresso compartilhado: `Quantidade` + `pbIniciar`/`pbPasso`/`pbFim` (rodada 220)

A barra do rodapé da paleta (`ProgressBar1`, 152 × 7 em (9, 426), `uscPaginas.cs:1203-1208` com
`ForeColor = Color.Transparent` e **mais nada** — os padrões do WinForms valem: 0..100, `Step` 10,
valor 0) é a barra de **todas** as rotinas longas: 92 arquivos chamam o par por
`DeclaracoesGeral._uscPagina` (`DeclaracoesGeral.cs:556`), que nasce no arranque
(`Comandos.GerenciadorPagina`, `Comandos.cs:1448-1470`, com o `new uscPaginas()` em `:1467`, chamado
por `Iniciar.cs:114,123` a cada ativação de documento).

- **O estado é o do controle, não uma cor.** `pbIniciar` (`uscPaginas.cs:1247-1257`) manda
  `SendMessage(Handle, 1040, (int)ProgressBarColor.Red, 0)` (`:1238-1245`): a mensagem **1040** é o
  `PBM_SETSTATE` (`WM_USER + 16`) e 1/2/3 são `PBST_NORMAL`/`PBST_ERROR`/`PBST_PAUSED` — o enum
  `ProgressBarColor { Green = 1, Red, Yellow }` (`:21-26`) com nome de cor, valores de **estado**.
  Depois de um `pbIniciar` a barra está no estado de **erro** (vermelha).
- **O que cada chamada faz:**
  - `pbIniciar()`: `Minimum = 0`; `Quantidade < 0` vira 0; `Maximum = Quantidade`; `Step = 1`; estado
    Red. **Não zera o `Value`** — o valor anterior fica (o controle só o corta se o novo `Maximum` for
    menor). Com a barra virgem (0..100), um `pbPasso` anterior já a terá movido.
  - `pbPasso(int iPasso = 1)`: `Increment(iPasso)` — o valor anda e **satura no `Maximum`** (a
    contagem de passos pode passar do `Maximum`: é o caso do `ExportaPaginas`, `RowCount` passos para
    `RowCount - 1`).
  - `pbFim()`: `Value`/`Minimum`/`Maximum` = 0; `Step` e estado **não** mudam.
- **Quem a dirige** (os das rotinas que o recoder tem): `SYNCD` (`Comandos.cs:288-303`; `Quantidade =
  6`, um passo **depois de cada** rotina), `SYNCV` (`:865-911`; `Quantidade = 9`, o primeiro passo
  **antes** da primeira rotina), `RESTPROJ` (`:1258-1327`; **`pbIniciar()` antes do `Quantidade = 16`**
  — a barra herda o `Maximum` da rotina anterior e o 16 nunca chega a ela) e o
  `clsTextos.ExportaPaginas` (`:1059-1213`; `pbPasso` antes do `pbIniciar` em `:1064`, `Quantidade =
  dg.RowCount - 1` + `pbIniciar` em `:1149-1150`, um passo por linha em `:1201-1202`, `pbFim` em
  `:1210`). Também `AcessoExcel.cs:239-261` (`Quantidade = UBound(Porta)`, `pbPasso(100)` a cada cem
  linhas) e o `ExportaTextos` (`:1312-1389`).
- **Quem NÃO a dirige:** o `clsTextos.ImportaTitulos` (`:1214-1306`) — nenhum `pb*` (quem move a barra
  na importação é o `ImportaTextos`, `:1393-1441`, do `frmExportarImportarTextos`); e a **carga da
  paleta** (`uscPaginas.CarregaPG`, `:1327-1400`, e `Pagina.CarregaPaginas`) — o recoder movia a barra
  no `Carregar()` desde a rodada 183, e isso era invenção.
- **A barra não repinta durante a rotina:** nenhuma das cadeias que a dirigem chama
  `Application.DoEvents` (as 37 ocorrências do decompilado estão em telas/relatórios), e o `pbFim` zera
  a faixa no fim do comando — numa rotina **digitada** a barra não chega a aparecer na tela.

No recoder: `Positron.Data/ProgressoCompartilhado` é a regra (estado + aviso `Mudou`, com os padrões do
WinForms como estado inicial), `FolhasControle` a espelha no `ProgressBar1` (e manda o `SendMessage`
quando há handle), `PaletaDeFolhas.Progresso*` é o `_uscPagina` das rotinas e
`ExcelAtivoDosTitulos.Exportar`/as três pipelines são os pontos ligados.

## O espaço da movimentação com destino: as quatro recusas e as duas fronteiras (rodada 221)

- **A ordem das recusas** (`uscPaginas.cs:2286-2390`) é: capa (**57**) → destino entre as
  **selecionadas** (**26**) → destino que já é outra página (**25**) → espaço insuficiente (**27**). Os
  quatro são `Interaction.MsgBox(..., MsgBoxStyle.Information)` — **não** crítico — e cada um dá `break`,
  o que devolve o fluxo ao `while (true)` do prompt: a pergunta é **repetida**, não abortada. É isso que
  o `POSITRON_MOVER_PARA="5;5"` mede (duas recusas seguidas no mesmo comando) e o que separa essa recusa
  da cancelada (fila vazia → `Status 5100` → sai).
- **O limite** `p` (`:2328-2340`): a primeira linha **não selecionada**, na ordem da grade, cuja página
  **decimal** (`Cells[4]`) é maior que o destino; sem nenhuma, o sentinela `"1000000"`. O espaço é
  medido **até ali**, não até o fim do caderno — mover duas páginas para o buraco entre a `5` e a `6`
  cabe (no ramo alfanumérico: `5`, `5A`).
- **As duas contas** (`Pagina.cs:305-350`), na ordem em que o original as tenta:
  - `calculaEspacoNumerico(p0, p1)` = `p1 - 1 - p0 + 1` com `p0` numérico (`Floor + 1` quando tem
    letra) e `p1` numérico (`Floor` quando tem letra);
  - `calculaEspacoAlfaNumerico(p0, p1)` = **27 nomes por número** — a página "seca" vale 64 (`'A' - 1`)
    e as letras 65..90; entre números diferentes `91 - letraA` (+ `letraB - 64` se `p1` tem letra, +
    `27` por número pulado); no **mesmo** número, `letraB - letraA`.
- **Fronteira da letra (2 selecionadas).** Destino numérico cujo limite é a **letra vizinha**: `5` com
  limite `5A` (5,65) → numérico `floor(5,65) - 5 + 1 = 1` e alfanumérico `65 - 64 = 1`. Duas já não
  cabem → **27**. Foi a rota medida na cópia do `Funcional.dwg` (16 páginas + a `5A` criada pela
  fixture); a premissa antiga ("precisa de 27 linhas selecionadas") só vale para a outra fronteira.
- **Fronteira do número (27/28).** Destino `3` com a `4` de limite (`numeroB - numeroA == 1`): o
  numérico dá 0 e o alfanumérico `91 - 64 = 27`. **27 cabe** (aplicam `3`, `3A`..`3Z`), **28 recusa** —
  o nome novo de cada selecionada, na ordem da grade, e o `renumerarPaginasLote` só é alcançado depois
  dos dois `if`, então a recusa **não renomeia nada**.
- **Instrumento** (`scripts/cad-fixture-msg27.lsp`, rodada 221): `POSITRON_MSG27_MODO=letra` cria o
  layer `5A`; `trinta` cria as páginas `1..31` **menos a `3`** — o destino tem de estar livre, senão a
  recusa que sai é a **25** — e o `(pz27:dump)` despeja os layers de página com o XData `Eletron` em
  `POSITRON_PAGINAS_SAIDA` (e, no load, em `POSITRON_PAGINAS_SAIDA_ANTES`). O dump conta só número
  **maior que zero**, como o `LayerValido` (o layer `0` fica de fora).

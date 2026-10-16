# Projeto ativo — o banco, o DWG e a configuração do desenho

Caminhos relativos a `cad-plugin/reverso/Eletron4_ZWcad/decompiled-cleaned/Eletron4/`. Confirmado na rodada 180.

## Tudo é do desenho

- O banco do projeto é o `Conf.DirProjeto`, lido do XData `EletronProj`/`Projeto` do ModelSpace (valores
  `[2]` = banco, `[3]` = simbologia elétrica, `[4]` = relatórios, `[5]` = topográfico, `[7]` = layout;
  `XDataGeral.cs:532-571`). Sem o XData, **tudo vazio**.
- A configuração geral é o `Eletron`/`Config` (41 valores, `LerXDataConfiguracao`, `:153`). Sem ele, os padrões
  de `:291-300` (`Conf.Banco = "A"`, `Local = "???"`, `PassoPagina = 1`, cores 7, `Continuous`…). O
  `ConfiguracaoDoCaderno.Padrao()` do recoder confere com eles.
- `Conf.Banco` é o **tipo** (`A` Access, `S` SQLite, `SV` SQL Server), não o caminho.
- Fora do desenho: só `My.Settings` (`LicMode`, `Cor`, `Secao`, `DesinstalarAut`…; `Eletron4.My/MySettings.cs`) e o
  registro `HKCU\Software\Cadgraph\Eletron4` (`Idioma`, `Altern`). **Nada do projeto.**
- Gravações: `GravarXDataConfiguracao` (`Config`) e `GravarXDataConfiguracao2` (`EletronProj`, `:592`), cada uma
  com `LockDocument` e substituindo o XData do ModelSpace.

## A cada desenho ativado

`myEletron.cs:202-233`: `Initialize` → `IniciarApp` + `IniciarDWG`; `DocumentActivated` → `EventosDOC.AtivaDocumento`
(`EventosDOC.cs:119-150`), que fecha as janelas (menos `frmExportarImportar`, `frmClonar`, `frmRelatorio_Aranha`,
`frmRelatorio_DInterlig`, `frmRelatorio_DIEnergisaMS/MT`, `frmRelatorio_DICemig`, `frmMisturador`,
`frmClonarEstruturaRegua`, `frmCopiarObjetos`) e roda o `IniciarDWG` (`Iniciar.cs:61-195`). A ordem e o que cada
passo faz estão na rodada 180.

## `BancoValido` e o índice do DWG

- `clsAuxiliar.BancoValido(bMsg = true)` (`clsAuxiliar.cs:10-60`): A/S → `DirProjeto` vazio = mMensagem 328
  `Banco do Projeto não configurado!`; arquivo inexistente = 329 `Banco do Projeto não encontrado!`. SV → campos e
  `testaConexao` (1968). As telas que leem o banco chamam no construtor (com `MsgBox`).
- `cDadosAccess.carregaDadosDWG` (`cDadosAccess.cs:15-62`): `arqAtivo.Indice` = o `Indice` da linha da tabela `DWG`
  cujo `Nome` é o nome do arquivo do desenho **sem os 4 últimos caracteres** (`Geral.extraiNomeCaminhoDwg`), sem
  diferenciar maiúsculas; 0 se não achar ou o banco for inválido. `arqAtivo.Path` = a pasta com `\` no fim.

## `frmConfiguracaoBDProjeto`

- Abre **sozinha**: no `IniciarDWG` (1ª ativação de um desenho tipo `E` com o banco inválido) e no
  `AcessoAccess`/`AcessoSQLite` (`:46,51` / `:62,67`) quando a conexão falha. Nenhum comando a abre.
- `SelProj`: filtro pelo `Conf.Banco` → grava o `DirProjeto` → `yKiycL7IZh`: DWG 0 = mMensagem 323; senão
  `UPDATE DWG SET Caminho=@caminho, Editor=@editor, Data=@data WHERE Indice=@indice`
  (`cDadosAccessDWG.AtualizaValores`, `:297`). **Não insere** o DWG: o cadastro é do Gerenciador de DWGs.

## O resto do `IniciarDWG` (a ordem, rodada 181)

Depois do banco/índice (acima), ainda no `Iniciar.cs:61-195` e sempre por ativação de desenho:

- **Tipo do desenho** (`XDataGeral.verificaTipoXData`, `:16`): XData do **ModelSpace** — `Eletron` =
  `E`, `DiagLog` = `D`, `ArqNet` = `A`, nenhum = `V`. É a chave de tudo o que segue.
- **Painéis da aba** (`Iniciar.cs:72-127`): `E` → painéis 0 e 1 + todos ligados; `V` → 0 e 1 ligados e
  `for j = 2 to count - 2` desligados (o **último painel fica como está**: o laço para no penúltimo);
  `D`/`A` → **todos** desligados. O `LerXDataConfiguracao`/`2` (e o `LerXDataConfiguracaoListaDePontos` no
  `E`) rodam só nos ramos que os usam.
- **Páginas** (`:128-141`): `CarregaPaginas` + `OrdenaMatrizPaginas`; com páginas, `LocalizaPaginaAtiva` →
  `AtivaPagina` → `Painel = 0` + `LeAtalhos` + `ExisteFormato`. Nos **dois** ramos, o **último passo** do
  bloco é `Comandos.GerenciadorPagina()` (a paleta abre sozinha).
- **Uma vez por desenho** (o `lDwgRegen` com o nome do arquivo, `:143-194`), nesta ordem: (1)
  `Geral.travaDWG(false)` (`Geral.cs:1061`) — `IsLocked = false` em todas as camadas, `LocalizaPaginaAtiva`
  + `AtivaPagina` + `Regen`; (2) `Geral.CriaTextStyle("Romans", "romans.shx")` (`:1118`, erro engolido
  em silêncio); (3) as cinco correções do XData `CORRECAO` (abaixo); (4) `Editor.Regen`; (5)
  `BancoValido(bMsg: false)` — inválido e tipo `E` → `frmConfiguracaoBDProjeto`; **válido** →
  `ACorrecaoBD.CorrigeBD()`.
- Depois (fora do `lDwgRegen`): o `dicDWG` (dicionário de DWG/painel, pelo banco) e os monitores.
- O `AtivaPagina` (`Pagina.cs:1243`) liga a página pedida, o `0` e o `-1` (ou a capa), desliga **todo o
  resto** — a capa inclusive — e deixa a página pedida como `Clayer`.

## XData `CORRECAO` — a marca das cinco correções automáticas

`XDataCorrecao.cs`; o buffer vai no **ModelSpace**, como o `EletronProj`:

- app `CORRECAO`, `1001` + **30** valores `1070` (o buffer novo nasce com todos `0`);
- `LerCorrecao(n)` = o valor do índice `n` é `1`; `setaCorrecao(n)` regrava o buffer **inteiro** com o
  índice `n` em `1` (o `setXData` do CAD troca só o bloco daquele app name: `Eletron`/`EletronProj` ficam);
- as cinco, na ordem: 1 `CorrecaoDisp` (`Correcao.cs:259`, app `DISPOSITIVO` → `Dispositivo`), 2
  `CorrecaoBornesVisiveis` (`:318`, `Visivel -1` → `0`), 3 `correcaoTextosCircuitos` (`:397`, `DBText` com
  `AUXCONEXAO` tipo 1 e `VerticalMode 1` → `VerticalMode 0` com `Position = AlignmentPoint`), 4
  `correcaoLines` (`:480`, a `Line` com `CONEXAO` senão `INTERLIGACAO` perde o XData pelo `LimpaXData`,
  `:937` — o buffer vira **um registro único** com o app name), 5 `corrigeOrdemBornes` (`:1565`);
- o original **indexa sem conferir o tamanho** do buffer (curto = `IndexOutOfRangeException` que estoura o
  `IniciarDWG` inteiro no `catch`); no recoder o buffer sem o índice responde "não lida".
- Como os desenhos do dono **já vêm com as marcas** do original, as correções não rodam duas vezes — é a
  compatibilidade de dado que mantém as duas implementações no mesmo desenho.

## Projeto real desta máquina

O `Funcional.dwg` aponta para `J:\Eletrobras\Retrofit Serviços Auxiliares\SE Recife II\...\07_Banco de Dados
Elétron\RCD.mdb` (Access, existe no `J:`), com as simbologias em `J:\Adm Tec\Onde Encontrar\Cadgraph\Simbologia Elétron 4\`.

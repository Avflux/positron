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

## Projeto real desta máquina

O `Funcional.dwg` aponta para `J:\Eletrobras\Retrofit Serviços Auxiliares\SE Recife II\...\07_Banco de Dados
Elétron\RCD.mdb` (Access, existe no `J:`), com as simbologias em `J:\Adm Tec\Onde Encontrar\Cadgraph\Simbologia Elétron 4\`.

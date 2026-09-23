# Positron — plugin CAD (ZWCAD / AutoCAD)

Frontend CAD do Positron: um assembly **.NET Framework 4.7.2 (x64)** carregado
no CAD por **`NETLOAD`**. Ele constrói a **fiação e a interligação do diagrama
funcional** e é o único que escreve as tabelas derivadas do diagrama no `.db` do
projeto. O contexto todo está em `../docs/POSITRON.md`.

```text
Positron.Contract/   tipos do schema gerado (namespace Positron.Contract)
Positron.Data/       acesso ao SQLite do projeto (System.Data.SQLite - 100% puro/agnóstico)
Positron.Plugin/     IExtensionApplication + comandos ([CommandMethod]) para ZWCAD e AutoCAD
Positron.CadStub/    stub de compilação — gate de compilação quando não há CAD instalado
```

## Por que não é Electron/React

A API de desenho (`ZwSoft.ZwCAD.*` ou `Autodesk.AutoCAD.*`) só existe **dentro do
processo do CAD**. `NETLOAD` carrega um assembly .NET que a referencia — não há
como um frontend web tocar entidades ou XData.

## Build

O contrato é gerado no repositório principal — rode antes:

```bash
npm run schema:sync      # regrava packages/protocol/csharp/Tables.g.cs
```

### 1. ZWCAD

**Sem o ZWCAD instalado** (a API 2026 versionada em `lib/ZWCAD/2026` é usada para compilar a DLL real):

```bash
npm run plugin:build:zwcad
```

O projeto inclui `ZwManaged.dll` e `ZwDatabaseMgd.dll` 26.0.26.0 para compilar
contra a API real. Portanto, instalar o ZWCAD não é necessário para gerar a DLL,
mas o ZWCAD 2026 continua necessário para carregá-la e executar testes de
integração. Para usar outra instalação/API, informe `ZWCadDir`:

```bash
dotnet build Positron.Plugin/Positron.Plugin.csproj -p:CadPlatform=ZWCAD -p:ZWCadDir="C:\Program Files\ZWSOFT\ZWCAD 2026"
```

Se as DLLs versionadas não estiverem presentes, o build procura uma instalação
local do ZWCAD 2026/2025; sem ambas as opções, compila contra o **stub**
(`Positron.CadStub`), que serve como gate de compilação, mas não gera um plugin
carregável no CAD.

WinForms não precisa ser copiado para `lib`: `System.Windows.Forms` e
`System.Drawing` são referenciados pelo projeto usando os assemblies do
.NET Framework 4.7.2.

### 2. AutoCAD

**Com o AutoCAD instalado** (gera a DLL carregável de verdade `Positron.Plugin.AutoCAD.dll`):

```bash
dotnet build Positron.Plugin/Positron.Plugin.csproj -p:CadPlatform=AutoCAD -p:AutoCadDir="C:\Program Files\Autodesk\AutoCAD 2024"
# ou via npm:
npm run plugin:build:autocad
```

**Sem o AutoCAD** (gate de compilação contra o stub):

```bash
dotnet build Positron.Plugin/Positron.Plugin.csproj -p:CadPlatform=AutoCAD
```

> **Nesta máquina o AutoCAD não está instalado**, então `npm run plugin:build:autocad`
> cai no segundo caso (stub) — é o gate de compilação da plataforma AutoCAD aqui.
> Numa máquina com AutoCAD o `csproj` auto-detecta 2020–2026 e gera
> `Positron.Plugin.AutoCAD.dll` contra a API **real**, carregável pelo
> `accoreconsole` (harness `npm run cad:smoke:acad`). Continua valendo o alvo net472:
> AutoCAD 2018–2024. AutoCAD **2025+** e o `accoreconsole` do DWG TrueView 2027
> usam .NET 8/10 e **não** carregam um plugin net472. Receita e números no
> `../docs/RUNBOOK.md`.

### 3. Build de ambos

```bash
npm run plugin:build:all
```

## Comandos

Digitados na linha de comando do ZWCAD ou AutoCAD depois do `NETLOAD`:

| Comando | Estado |
|---|---|
| `ELET` | **implementado** — mensagem de entrada do plugin |
| `FIA` | **implementado** — projeta a fiação do desenho para `Fiacao` |
| `INT` | **implementado** — projeta a interligação do desenho para `Interligacao4` |
| `SYNCD` | **implementado** — projeta o desenho para o banco (fiação + interligação) |
| `JMP` | **implementado** — projeta os jumpers do desenho para `Jumper4` |
| `VERIF` | **implementado** — valida as tabelas gravadas (fiação, interligação e modelos) **e lê o desenho**: as 14 checagens da tela `frmVerificadorProjetoFiacao` (régua do borne, cabo fora do catálogo, página fora da `LayerTable`, borne sem fiação, fiação duplicada, intervalos, LM, painéis, terminais/bornes das portas, principal × auxiliar, bornes editados, blocos duplicados, régua da máscara, portas discrepantes) e as 3 do verificador da interligação |
| `INDCABO` | **implementado** — a **ação** "Corrigir cabos" (`IndefineCabosNaoExistentes`) do verificador da interligação: o trecho cujo `Tag_Cabo` não está no catálogo (`Cabos`) perde o cabo e a veia no XData e o rótulo auxiliar (`AUXINTERLIG`) vira o caracter de terminal indefinido. Roda por script |
| `EPLQ` | **implementado** — exporta as **plaquetas** do desenho para `Plaquetas4` (`clsDispositivoTacito.exportaPlaquetas`): lê o dicionário `CENG_PLAQUETA` do **próprio desenho** (um `Xrecord` por painel, registros de 7 valores) e resolve o **nome** de cada plaqueta pelo tipo — `P` = nome do painel (cadastro `Paineis`), `D` = `Nome1[/Nome2]` do bloco `M`/`P` pelo handle, `X` = primeira descrição não-vazia, `R` = nome da régua (`REGUAS/MODELOS2`). Entram só painéis **com fiação no desenho** e plaquetas com nome **e** descrição. Roda por script |
| `COMPLM` | **implementado** — compila a **lista de material** do desenho para `ListaMateriais` (`clsLM.CompilaListaDeMateriais`): uma linha por LM da **máscara** (`M`) e do **dispositivo** (`P`), uma **agregada** por `(painel, régua, tipo, lm)` para cada **borne** (`B`) e as reservas das réguas somadas. A `OrdemLay` de cada linha é o **índice da tag** no `CENG_LAYOUT` do próprio desenho (10000 quando não está no layout) e a `Ordem` é renumerada 1..N por painel. Preserva os itens **avulsos** do app. Roda por script |
| `ELETCFG` | **implementado** — abre a tela de configuração (WinForms) e grava `%APPDATA%\Positron\positron.ini`. **Modal**: não rode dentro de script |
| `ELETREL` | **implementado** — grava o **relatório da verificação** em arquivo (a grid de erros das telas do original, sem tela). Roda por script |
| `ELETCMP` | **implementado** — abre a **tela de compilação** (grid de erros) sobre o mesmo relatório do `ELETREL`, com botão Salvar. **Modal**: não rode dentro de script |
| `ApagarTextosEmBranco` | **implementado** — frente 2 do §7.6, limpeza: apaga do ModelSpace os `DBText` cujo texto é só espaços **e** que **não** têm XData (`LimpezaDoDesenho.TextoEmBranco`). Roda por script |
| `apagaXDataTerceiros` | **implementado** — limpeza: nas entidades com o app name de terceiro `AEC_XDATA_BOUND_SPACE`, troca o XData pelo registro único de marca (o conteúdo de terceiro some, como no original). Roda por script |
| `ApagaLayouts` | **implementado** — limpeza: apaga o dicionário `CENG_LAYOUT` do desenho (o `PosicaoNum` do `FIA` e a `OrdemLay` do `COMPLM`). Roda por script |
| `ApagaPlaquetas` | **implementado** — limpeza: apaga o dicionário `CENG_PLAQUETA` do desenho (o insumo do `EPLQ`). Roda por script |
| `LimpaTextosLPCopiados` | **implementado** — limpeza: tira o XData `TextoLP` (o rótulo copiado de outra página) — do `DBText` **sempre** e do `MText` só quando ele está **abaixo do topo** do desenho (as `CONEXAO` tipo 1); a gravação troca o buffer pela marca única, como o `LimpaXData` do original. Só olha o desenho. Roda por script |
| `apagarTodosOsTextosDasVeias` | **implementado** — limpeza: apaga os **rótulos auxiliares das veias** do ModelSpace (frente 2 do §7.6) — o `DBText` com XData `AUXINTERLIG` do **tipo 1** (o mesmo que o `INDCABO` reescreve) e **qualquer** entidade com o XData `ELETROSUL`; um `AUXINTERLIG` tipo 1 fora de texto fica. Só olha o desenho. Roda por script |
| `corrigeOrdemBornes` | **implementado** — correção: renumera a `Ordem` dos bornes por régua (1..N), **pulando as ordens dos bornes de reserva** (`CENG_BORNES`), e regrava o XData dos que mudam (resolvendo o `lm` no dicionário de réguas, como o `GravarXDataDispBorne` do original). Roda por script |
| `corrigeDicMascaras` | **implementado** — correção: normaliza a lista de portas de cada modelo no dicionário `MASCARAS` (dedup por índice, ficando a primeira; ordem crescente; `MaxIndice` recalculado), o par de escrita do `bt13ReguaMascara`. Só olha o desenho. Roda por script |
| `RecriaTextosCaboEletrosul` | **implementado** — o irmão da Eletrosul do `RecriaTextosCabo`: a mesma limpeza e um rótulo por trecho (o original reinsere **para todo** trecho), com a geometria própria — a **elipse** no meio do segmento, o "leader" de três vértices (os dois com XData `ELETROSUL` tipo 0) e o texto no **fim do leader**, rotação 0, horizontal à esquerda e `iModeloVeiaFuncao = 1`. Roda por script |
| `RecriaTextosCabo` | **implementado** — correção: apaga os rótulos auxiliares das veias (o não-texto pelo `ELETROSUL`/ENEL e o `DBText` pelos tipos 1/4/5/6) e **reinsere um por trecho de interligação** que ficou sem rótulo, no modelo padrão — texto (tag, separador, número, cabo singelo, `(NomeVeia)`) e posição (meio do segmento + 1 na perpendicular) calculados. Lê o catálogo. Roda por script |
| `AtualizaOpcionaisDoCabo` | **implementado** — o texto dos rótulos auxiliares dos tipos **3..6** é remontado a partir da **receita** de opcionais do XData `AUXINTERLIG` (`C` = tag, `V` = nome da veia, `N` = NomeVeia, `FU`/`FO` = função/formação, `(` `)` `/` `-` e `E` = espaço; o último token da receita é descartado, como no original). Lê o catálogo. Roda por script |
| `CorrigeHandleSuperior` | **implementado** — as duas metades do original: **limpa** os handles das derivações (o `Limpahandle`) e **re-resolve** cada uma com o `verificaConexao` — a janela de ±0.2 em volta do ponto inicial acha a conexão vizinha (mesma camada, handle diferente) e grava o **handle**, o **nome** e o **potencial** dela. O tipo do vizinho sai do `Jumper`. **Fora do recorte:** a parte de páginas e o hardlock. Só olha o desenho. Roda por script |
| `CorrigeCabos` | **implementado** — correção **só de banco**: a `Funcao` vazia vira um espaço em `Cabos` e `Cabos4`, e o `Alarme` do cadastro é zerado (o `UPDATE` não tem filtro, como no original). Coluna com lista branca. Roda por script |
| `CorrigePainelET1DosBornes` | **implementado** — correção: os atributos do borne (Dispositivo tipo `B`) são reescritos com a régua (do dicionário `REGUAS`, via `ReguasDoDesenho`) e o painel (`Paineis`): `NOME1` = régua, ou `painel + separador + régua` quando o borne não está visível; `PAINEL`/`REGUA`; `T1` = número (ou `?` quando `0`). **Quirk:** a sentinela do original é o literal `OK` (valor `OK` não é escrito). Só olha o desenho + cadastro. Roda por script |
| `CorrigeTextosDasLigacoes` | **implementado** — **achado do reverso:** o corpo deste comando é **idêntico** ao do `ApagaBlocosMirror` (apaga os blocos espelhados com XData e sem `DINTERLIG`); ele não corrige texto nenhum, apesar do nome. Reusa o mesmo adapter e a linha de resumo declara o achado. Só olha o desenho. Roda por script |
| `ApagaBlocosMirror` | **implementado** — limpeza: apaga os blocos de referência com algum XData, **sem** o app `DINTERLIG` (cabo de aranha) e com a escala **X negativa** (espelhados). O original apaga em silêncio; aqui a linha de resumo traz os números. Só olha o desenho. Roda por script |
| `Limpahandle` | **implementado** — limpeza: zera o `Handle` do XData `CONEXAO` das polilinhas de **derivação** (tipo 3), gravando só o registro do app. É a primeira metade do `CorrigeHandleSuperior` (a segunda precisa do resolvedor por ponto, que ainda não existe no recoder). Só olha o desenho. Roda por script |
| `CorrigeCoresDosBlocos` | **implementado** — correção: para os blocos inseridos que têm XData, a cor de cada `AttributeReference` passa a ser a do `AttributeDefinition` da definição do bloco, casando (bloco, tag). **Quirk reproduzido:** a lista de nomes guarda o nome cru e a comparação usa `ToUpper` (só entram nomes já em caixa alta). Só olha o desenho. Roda por script |
| `corrigePortas` | **implementado** — correção: os atributos dos blocos de porta (Dispositivo tipo `E`) são reescritos com a porta do `MASCARAS` casada por `indiceDoModelo`/`indiceDaPorta` — `EFC` = `sEFC`, `T<n>` = terminal (ou o `?`), `B<n>` = borne sem o `*`, `R<n>` = régua com a visibilidade decidida pela marca do borne. O `NOME1` recebe o nome da **máscara** (pelo `HandleDaMascara`, com `/Nome2`) e a `ORIGEM` a **página** (o layer do texto da definição). A porta que **não** está no dicionário é **indefinida** (o `IndefineUmaPorta`/`LimpaPorta`: XData zerado e atributos limpos — protegidas vazias, `T`/`B` com o caracter indefinido). A `ORIGEM` sai como `PrefixoCruzInterno + layer + SufixoCruzInterno` (padrão `(` e `)`). Só olha o desenho. Roda por script |
| `CorrigeModelosDeContatos` | **implementado** — correção: quando o `Indice` de um contato do `CONTATOS` não é o da sua posição na lista do modelo, o índice novo (o da posição) é gravado no XData **`Dispositivo`** dos blocos auxiliares (valor 6) e no XData **`Modelo`** (valor 3), trocando só o registro do app. No fim chama o `CorrigeContatosAux` e **renumera o dicionário** (a chave do modelo recebe os contatos com o índice da posição, pelo registro **cru** — o leitor tipado recalcularia a orientação). **Fora do recorte:** o `SincronizaContatos`. Só olha o desenho. Roda por script |
| `CorrigeBlocosContatosAux` | **implementado** — correção: os blocos auxiliares (Dispositivo tipo `A`) têm os atributos `T1`/`T2`/`T3` reescritos com o contato do dicionário `CONTATOS` casado por `IndexModelo`/`IndexContato` (que vêm do XData **Dispositivo**, valores 5 e 6). Regra: `T1` = `sT1`; `T2` = `sT2`, mas com o tipo `RV` o **tipo do bloco** (`Mid(nome, 5, 2)`) decide; `T3` = `sT3` (com o tipo `NA` e `sT3` vazio, cai no `sT2`). Só olha o desenho. Roda por script |
| `REMLAYDUP` | **implementado** — correção: tira os **tags repetidos** (conservando o primeiro) dos XRecords `CENG_LAYOUT` das chaves `P`/`C` de cada painel do cadastro — o dicionário que o `FIA` e o `COMPLM` leem. **Quirk reproduzido:** o último registro de cada chave é descartado, então rodar duas vezes come um registro por chave (use uma passada). Lê o cadastro. Roda por script |
| `CorrigeCabosSingelos` | **implementado** — correção (banco + desenho): os cabos do catálogo com `Cabos = 1` cuja veia do arquivo tem **uma** linha com `#` no nome perdem o `Nome_Veia` no banco (`UPDATE Veias`) e o `NomeVeia` do XData dos trechos com aquele `Tag_Cabo`; no fim recria os rótulos (`RecriaTextosCaboEletrosul`), como o original. **Desvio medido:** o reverso lê a coluna `DWG`, que não existe na `Veias` — o recoder usa `Arquivo`. Roda por script |
| `CorrigeContatosAux` | **implementado** — correção: preenche o `HandleContatoAux` do XData `Modelo` de cada bloco de modelo com o handle do bloco auxiliar (tipo `A`) que casa pela chave (HandleBob sem caixa, indexModelo, indexContato) — quem não casa fica vazio; par de escrita do `bt4Auxiliar`. Só olha o desenho. Roda por script |
| `CorrigeBornes` | **implementado** — correção: o borne com `Visivel == -1` volta para `0` (o `CorrecaoBornesVisiveis` do original), com o XData regravado pelo mesmo caminho. Roda por script |
| `CorrigeDisp` | **implementado** — correção: renomeia o app name legado `DISPOSITIVO` para `Dispositivo` na tabela `APPID` (o `CorrecaoDisp` do original). Atenção: a busca de app name do CAD não diferencia caixa, então o legado é procurado pela **caixa gravada**. Roda por script |
| `SobeLm` | **implementado** — correção **própria do recoder** (sem par no reverso): o borne com `lm == 0` (o `BorneSemLm` que o `VERIF` aponta) recebe o `lm` que a régua dele define para o tipo — o campo +6/+7 do `REGUAS/MODELOS2`, que o original só lê na gravação do borne, ou o dicionário de bornes da régua (`CENG_BORNES`) quando aquele está zerado. Só o borne zerado e **com** definição entra. Roda por script |
| `CorrigeStyle` | **implementado** — correção: os **estilos de texto** do desenho sem fonte (`FileName == ""`) ou com escala horizontal zero recebem a fonte, a escala e a altura da referência `arial.ttf` (ou, sem ela, do último estilo da tabela, como o original). O original copia só o descritor `Font`; aqui o `FileName` também é regravado (no ZWCAD só o `Font` não persiste o arquivo — medido na rodada 73). Roda por script |

### Fluxo de fiação (`FIA`)

Lê as `LWPOLYLINE` do ModelSpace com XData **`CONEXAO`** (layout recuperado em
`Positron.Data/Fiacao/ConexaoXData.cs`) e grava em `Fiacao` pelo INSERT canônico
do original. Configuração por arquivo **ou** variável de ambiente:

**Precedência: padrão < arquivo < ambiente** — a automação (harness/E2E) sempre vence.

| Variável | Chave do arquivo | Papel |
|---|---|---|
| `POSITRON_DB_PATH` | `banco` | caminho do `.db` do projeto (obrigatória) |
| `POSITRON_DWG` | `dwg` | índice do desenho (`DWG`), padrão `0` |
| `POSITRON_REVISAO` | `revisao` | revisão da linha (`Revisao`), padrão vazio |
| `POSITRON_LOCAL` | `local` | documento local (`Documento1`/`Documento2`), padrão vazio |
| `POSITRON_LOG` | `log` | arquivo onde `Plugin.Escrever` anexa cada mensagem (evidência de execução por script) — opcional |
| `POSITRON_INCLUIR_COLUNA` | `incluirColuna` | switch `Conf.incluirColuna` da coluna `Pagina` (`0..6`), padrão `0` (layer cru) |
| `POSITRON_SEPARADOR_CRUZAMENTO` | `separadorCruzamento` | separador do caso `6` de `POSITRON_INCLUIR_COLUNA`, padrão vazio |
| `POSITRON_RELATORIO` | `relatorio` | arquivo do relatório do `ELETREL`; padrão: `positron-relatorio.txt` ao lado do banco |

O arquivo (`%APPDATA%\Positron\positron.ini`, `chave=valor`) é gravado pelo comando
`ELETCFG`; a leitura é tolerante (linha malformada ignorada, valor inválido mantém o
anterior).

**Bornes/terminais (fase 7).** O `FIA` varre os blocos de borne do desenho
(XData `Dispositivo` tipo `"B"`) e as réguas do dicionário
(`REGUAS`/`MODELOS2`), e casa cada ponto de fiação ao borne mais próximo
(`Positron.Data/Bornes/`). Isso preenche `Terminal`, `TerminalNum`, `Tipo`,
`TipoBorne`, `IndexModelo`, `Tag`, `Alternativo` e `Handle`.

**`Pagina` (coluna configurada).** A coluna `Pagina` sai do layer pelo switch
`Conf.incluirColuna` do `frmCompilarFiacao`, reproduzido em `ColunaPagina`:
`0..2` = layer cru, `3..5` = `Pagina.BuscaAlternativo` (o alternativo do layer, ou
o próprio layer) e `6` = `(layer)` + separador + alternativo. A **matriz de
páginas** vem do desenho (`PaginaMatrix`/`PaginasDoDesenho`), montada da
`LayerTable` como o `Pagina.CarregaPaginas`. A configuração vem do ambiente —
`POSITRON_INCLUIR_COLUNA` (padrão `0`) e `POSITRON_SEPARADOR_CRUZAMENTO` — porque
o original a define na tela `frmConfiguracaoGeral`, que ainda não existe aqui.
Vale para `Fiacao`, `Bornes4F`, `Dispositivos4F`, `Interligacao4` e `Bornes4I`.

**Modelos (fases 8 e 9).** O `FIA` também gera **`Portas4F`**, **`Bornes4F`** e
**`Contatos4F`** a partir dos modelos do desenho: as portas vêm de
`MASCARAS`/`MODELOS2` (modelos de máscara) e `MASCARAS/<índice>` (portas); os
bornes de reserva de `CENG_BORNES/<indexRegua>`; e os contatos de
`CONTATOS`/`MODELOS2` e `CONTATOS/<índice>`, mais os terminais de bobina (atributos
`T*` dos blocos de dispositivo). Os geradores são puros
(`Positron.Data/Modelos/`). Réquas, bornes, máscaras e dispositivos também são
procurados no desenho; os painéis em uso, que no original vêm da tela, aqui saem
das conexões/máscaras/dispositivos presentes.

**Dispositivos (`Dispositivos4F`).** O `FIA` também grava um **dispositivo por
bloco**: um por bloco de dispositivo (`P`) e um por bloco de máscara (`M`), como
o `frmCompilarFiacao` do original — blocos `Complementar` e de painel fora de uso
ficam de fora. A `Tag` é `Nome1[/Nome2]`; a `Pagina` é o layer do bloco; o
`BlocoTopografico`/`BlocoLayout` vêm do **modelo** casado por `IndexModelo` (no
`P` o dicionário de modelos de contato, no `M` o de máscaras); e
`PosicaoNum`/`Ordem` vêm das posições do layout (`CENG_LAYOUT`), casadas por
`(painel, tag)`. Limite assumido: no `P` com `IndexModelo == 0` o original lê
essas duas colunas do próprio XData — o leitor atual não expõe esses índices, então
elas saem vazias (ausente, não inventado).

**Jumpers (`JMP` → `Jumper4`).** O comando `JMP` reproduz o
`frmCompilarJumperExt`: varre as conexões `CONEXAO` e cria um ponto por ponta —
**vértice 0** quando `Tipo == 4` e `Disp1`, **último vértice** quando `Tipo == 3`
e `Jumper == "JUMPER"` ou `Tipo == 4` e `Disp2` — sempre com `bJumper = true`. O
casamento com borne/dispositivo, a posição do layout, a numeração de `Ordem` e a
coluna `Pagina` são os mesmos do `FIA`; muda só a tabela de destino (`Jumper4`, que
tem as mesmas colunas sem `Aplicacao`/`Orientacao`).

**Circuitos (`Circuitos4F`).** O `FIA` grava um circuito por **potencial**: das
conexões `CONEXAO` com `Tipo == 1` e `Nome` não-vazio, de painel em uso,
deduplicando por `Potencial` (o primeiro vence) — o `t6yXrlfi5w` do original. A
coluna `Circuito` recebe o `Nome` cru da conexão (o `Trim` só decide se entra).

**Aplicações (`Aplicacao4F`).** O `FIA` copia **todos** os tipos de aplicação do
dicionário do desenho — `NamedObjectsDictionary → "APLICACAO" → "TIPOS"`
(`Xrecord`), o `FiRUTW6Q6W` do original. A lista é plana, com **10 valores por
aplicação**, e o original começa no índice **1**: `Indice`, `Nome`, `Secao`,
`Cor`, `TipoCabo`, `Isolacao` (+4 reservados). Não há filtro por painel ou uso.

**Casamento por bounds + deslocamento.** O casamento ponto↔borne usa as duas
etapas do original: o ponto tem que cair dentro da **bounding-box** do bloco com
0,25 de folga (`Bounds ±0,25`), e o ponto de referência é
`inserção + ponto de ligação`, onde os pontos de ligação vêm das **definições de
bloco** (`mknUzyUVsW`), montados por `DeslocamentosDoDesenho`.

**Ordenação e reordenação (backlog 3).** A `Ordem` segue a chave do original —
`Potencial`, `PosicaoNum` decrescente (bornes primeiro), `dOrdem`, `TerminalNum`,
`Terminal`. Depois, o comando roda o `ReordenaOrdemPotenciais`
(`ReordenarOrdemFiacao`), que renumera `Ordem` 1..N por potencial. `NRegua`,
`PosicaoNum` e `BLink` vêm do borne casado. O `dOrdem` do **não-borne** vem da
tabela `mPosicao`, lida do dicionário `CENG_LAYOUT` (`LayoutDoDesenho`), que casa
por `(painel, tag)`.

**Varredura de dispositivos (backlog 1).** O ponto que **não** casa com um borne
é casado com o **bloco de dispositivo** mais próximo (`CasamentoDispositivo`), que
lhe dá a `tag` (`Nome1[/Nome2]`) e o `Tipo`. A varredura `DispositivosDeFiacaoDoDesenho`
percorre o ModelSpace lendo o XData de dispositivo (`DISPOSITIVO`/`Dispositivo`:
tipos `P`/`E`/`A`; `IMPORTADO`: tipo `I`) e o `PontoFiacao` recebe
`Tag`/`Alternativo`/`Tipo`/`IndexModelo`/`Handle`/`NRegua`, com `TipoBorne = -1`.
Só então o `mPosicao` casa por `(painel, tag)` e o não-borne ganha
`PosicaoNum`/`dOrdem`. O `E`/`A` tem o painel lido do bloco da máscara
(`array[4]`), como no original.

**Diferenças assumidas:** o original **pula** os tipos `I` e `M` nesse casamento
(`verificaTipoDispositivo`); aqui o `I` entra a pedido do projeto (`M` é máscara,
nunca entra). E o original só aceita o casamento se o bloco também tirar um
**terminal** não-vazio (`ltZUHdAX7R`, que lê atributos `T*`/`B*` do bloco) — isso
**já está no núcleo** (`CasamentoDispositivo.EscolherTerminal`), com o adapter
lendo os atributos do bloco (`DispositivosDeFiacaoDoDesenho.LerTerminais`) e a
regra coberta por `DispositivosFiacaoTests` (`Sem_terminal_nao_casa`,
`Terminal_indefinido_nao_casa`, `Tipo_P_ignora_atributo_B...`).

### Fluxo de interligação (`INT`)

Lê as `LWPOLYLINE` do ModelSpace com XData **`INTERLIGACAO`** (layout recuperado
em `Positron.Data/Interligacao/InterligacaoXData.cs`), mescla as pontas por
`(Tag_Cabo, Num_Veia)` e grava em `Interligacao4` pelo INSERT canônico do
original. Usa as mesmas variáveis de ambiente do `FIA` (`POSITRON_DB_PATH`,
`POSITRON_DWG`, `POSITRON_REVISAO`) mais `POSITRON_LOCAL` (o `Conf.Local` do
original).

**Bornes/terminais das duas pontas (backlog 1).** O `INT` varre os blocos de
borne do desenho (XData `Dispositivo` tipo `"B"`) e as réguas do dicionário
(`REGUAS`/`MODELOS2`), e casa cada ponta do trecho ao borne mais próximo
(`Positron.Data/Bornes/`) — a mesma varredura da fase 7 aplicada ao
`Interligacao4` (o `pf6UXj3X1f` do original). Isso preenche, por ponta, `Tag`,
`Alternativo`, `Terminal`, `TerminalNum`, `TipoBorne`, `Handle` e `IndexModelo`.

**Snapshot do catálogo (backlog 2).** O `INT` também regrava **`Cabos4`** e
**`Veias4`** copiando o catálogo (`Cabos`/`Veias`) e carimbando cada linha com a
revisão — o `RUIU5Sbjhj`/`v1TU0cEjWd` do original. Não é derivado do desenho: é o
catálogo por revisão. As linhas da revisão são apagadas antes de inserir, para
rodar duas vezes não duplicar.

**Por ponta, além do borne.** O mesmo casamento carimba `DWG1`/`DWG2` (o DWG
ativo) e `Documento1`/`Documento2` (o `Conf.Local`, hoje via `POSITRON_LOCAL`);
`Posicao1`/`Posicao2` saem vazias, como no original. Sem borne, `DWG`/`Documento`
saem nulos — o original grava `0`/`""` (dado ausente é melhor que dado
inventado).

**Criação de linha, tipo a tipo.** Reproduz o `frmCompilarInterligacao`: o
`Tipo == 1` (polyline com as duas pontas) e o `Tipo == 3` (só a ponta de destino)
**sempre** anexam uma linha nova; só o `Tipo == 2` procura a linha do mesmo
`(Tag_Cabo, Num_Veia)` para completar a outra ponta — e compara o cabo ignorando
caixa, como o `yHoU3hlYPo` do original (ver `../docs/POSITRON.md`).

**Portas e bornes intermediários (`Portas4I`/`Bornes4I`).** O `INT` também
projeta as tabelas **I** do original: o `wrlU180vl0` grava `Portas4I` a partir
das portas de **todos** os modelos de máscara do dicionário (não só os em uso) e o
`T6NUlT3ghH` grava `Bornes4I` com os bornes do desenho mais as reservas das
réguas, **sem** o filtro de painel em uso que o `FIA` aplica ao `Bornes4F`. As
duas tabelas não têm `Orientacao`/`LM`/`BlocoLayout`.

O leitor e o projetor são puros (não dependem do CAD) e têm teste real contra
um SQLite montado do `schema.sql`:

```bash
npm run plugin:test      # xunit, net472
```

## Pré-requisitos

- **.NET Framework 4.7.2** e um SDK do .NET para o `dotnet build` (o pacote
  `Microsoft.NETFramework.ReferenceAssemblies` traz os assemblies de referência
  sem exigir o Visual Studio).
- **ZWCAD 2026+** ou **AutoCAD 2024+** para gerar/carregar a DLL real.

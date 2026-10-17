# Rodada 181 — o resto do `IniciarDWG`: painéis pelo tipo, `Romans`, as cinco correções com marca e a página ativa

**Data:** 2026-10-15 · **Commit:** `0547e4c8` · **Frente:** correção do básico, item 1b · **Situação:** 🟡 parcial (o `ACorrecaoBD.CorrigeBD` e os dicionários de DWG/painel ficaram em *Falta*)

## Alvo

Item **1b** da *Correção do básico* do `ESTADO.md`: o que ainda faltava do `Iniciar.IniciarDWG`
(`Iniciar.cs:61-195`) além do que a rodada 180 portou (o banco, o índice do DWG e a
`frmConfiguracaoBDProjeto`): os **painéis da barra pelo tipo do desenho**, o **estilo `Romans`**, as
**cinco correções automáticas** (com a marca que as torna únicas por desenho), o **`travaDWG(false)`**
(destravas as camadas, ativa a página ativa e dá `Regen`) e a **página ativa ao abrir** o desenho.

O item 1a (o banco Access do projeto real) é decisão do dono e não foi tocado; o
`ACorrecaoBD.CorrigeBD`, que também é do `IniciarDWG`, saiu para a fila (ver *Falta*).

## O que o reverso faz

Caminhos relativos a `cad-plugin/reverso/Eletron4_ZWcad/decompiled-cleaned/Eletron4/`.

- **Entrada:** o `IniciarDWG` roda no `Initialize` e **a cada `DocumentActivated`**
  (`myEletron.cs:202-233` → `EventosDOC.AtivaDocumento`, `EventosDOC.cs:119-150`). Tudo o que segue é
  por ativação de desenho.
- **Tipo do desenho** (`XDataGeral.verificaTipoXData`, `:16`): o XData do **ModelSpace** — `Eletron` =
  `E`, `DiagLog` = `D`, `ArqNet` = `A`, nenhum = `V`.
- **Painéis da barra** (`Iniciar.cs:72-127`): o `ribbon.Tabs[DeclaracoesGeral.indexRibbon].Panels` (a
  aba `CENG.ID_Elet`, 9 painéis — 2 do `CreateRibbon()` + 7 do `CreateRibbon2()`):
  - **E**: `LerXDataConfiguracao` + `LerXDataConfiguracao2` + `LerXDataConfiguracaoListaDePontos` e
    **todos** os painéis ligados;
  - **V**: os mesmos dois `LerXDataConfiguracao` e: painéis **0 e 1** ligados, `for j = 2 to count - 2`
    desligados — o **último painel o original não toca** (fica como está: ligado). O laço usa o número
    de painéis do momento, não uma constante;
  - **D** e **A**: **todos** desligados (nenhum `LerXDataConfiguracao`).
- **Páginas** (`Iniciar.cs:128-141`): `Pagina.CarregaPaginas()` e `OrdenaMatrizPaginas()`; com páginas
  (`UBound(mPaginas, 2) > 0`): `ativo.Pagina = LocalizaPaginaAtiva()`, `AtivaPagina(ativo.Pagina)`,
  `ativo.Painel = 0`, `Dicionario.LeAtalhos()`, `Caderno.ExisteFormato()`. **Nos dois ramos** o
  `Comandos.GerenciadorPagina()` abre a paleta, e é o **último** passo do bloco.
- **Uma vez por desenho** (o `lDwgRegen`, `Iniciar.cs:143-194`, com o nome do arquivo no
  `DeclaracoesGeral.lDwgRegen`):
  1. `Geral.travaDWG(false)` (`Geral.cs:1061`): `IsLocked = false` em **todas** as camadas, depois
     `LocalizaPaginaAtiva()` + `AtivaPagina(pagina)` e um `Regen`;
  2. `Geral.CriaTextStyle("Romans", "romans.shx")` (`Geral.cs:1118`): cria o estilo se a tabela não o
     tem (entra na tabela, depois recebe a `FileName`); o erro é **engolido** (sem aviso);
  3. as **cinco correções**, cada uma guardada pela marca no XData `CORRECAO` do ModelSpace
     (`XDataCorrecao.LerCorrecao`/`setaCorrecao`, `XDataCorrecao.cs`):
     | nº | correção | o que faz |
     |----|----------|-----------|
     | 1 | `CorrecaoDisp` (`Correcao.cs:259`) | app name legado `DISPOSITIVO` → `Dispositivo` |
     | 2 | `CorrecaoBornesVisiveis` (`:318`) | `Visivel -1` → `0` no borne |
     | 3 | `correcaoTextosCircuitos` (`:397`) | `DBText` com `AUXCONEXAO` tipo 1 e `VerticalMode 1` → `VerticalMode 0` com `Position = AlignmentPoint` |
     | 4 | `correcaoLines` (`:480`) | a `Line` com XData `CONEXAO` (senão `INTERLIGACAO`) perde o XData pelo `LimpaXData` (`:937`): o buffer vira **um registro único** com o app name |
     | 5 | `corrigeOrdemBornes` (`:1565`) | renumera a `Ordem` dos bornes por régua |
  4. `Editor.Regen()`;
  5. `clsAuxiliar.BancoValido(bMsg: false)`: inválido e tipo `E` → `frmConfiguracaoBDProjeto`;
     **válido** → `ACorrecaoBD.CorrigeBD()` (a migração do banco).
- Depois (fora do `lDwgRegen`): `DeclaracoesGeral.dicDWG = new Dictionary` e, com o banco válido,
  `cDadosAccess.carregaDWGDicionario()`, `carregaPainelDicionario()`, o `PointMonitorToolTips`
  reiniciado, um `EventosDB` novo, `monitorConexao = 0` e `_uscPagina.statusBanco("0")`.
- **XData `CORRECAO`** (`XDataCorrecao.cs`): app `CORRECAO` no **ModelSpace**, `1001` + **30** valores
  `1070` (o buffer nasce com todos `0`); `LerCorrecao(n)` = o valor do índice `n` é `1`; `setaCorrecao(n)`
  grava o buffer inteiro com o índice `n` em `1` (o `setXData` do CAD troca só o bloco daquele app name).
  O original **indexa sem conferir o tamanho** (um buffer curto derruba o `IniciarDWG` inteiro no `catch`).
- **Fora do `travaDWG`**, o `AtivaPagina(pagina)` do `Pagina.cs:1243` percorre a tabela de layers: a
  página pedida fica ligada e vira a `Clayer`; `0` e o `-1` (ou a própria capa) também ficam ligados;
  **todo o resto desliga, a capa inclusive**.

## O que foi feito

| arquivo | o quê |
|---|---|
| `cad-plugin/Positron.Data/Correcoes/MarcasDeCorrecao.cs` | **novo**: o XData `CORRECAO` — os cinco números, a `Base()` (1001 + 30 zeros), `Lida` e `Marcar` |
| `cad-plugin/Positron.Data/Correcoes/CorrecaoDoTextoDeCircuito.cs` | **novo**: `PrecisaCorrigir(tipo, verticalMode)` (`tipo == 1 && verticalMode == 1`) |
| `cad-plugin/Positron.Data/Correcoes/CorrecaoXDataDasLinhas.cs` | **novo**: `QualLimpar(temConexao, temInterligacao)` |
| `cad-plugin/Positron.Data/Interface/Mapas/LigacaoDosPaineis.cs` | **novo**: `Plano(tipo, quantidade)` — `true` liga, `false` desliga, `null` não mexe (o último painel no tipo `V`) |
| `cad-plugin/Positron.Plugin/Correcoes/MarcasDeCorrecaoDoDesenho.cs` | **novo**: lê e grava o `CORRECAO` no ModelSpace, com `LockDocument`, trocando só o bloco daquele app name (os `Eletron`/`EletronProj` ficam) |
| `cad-plugin/Positron.Plugin/Correcoes/TextosDeCircuitoDoDesenho.cs` | **novo**: o `correcaoTextosCircuitos` (varre o ModelSpace, `Position = AlignmentPoint`, `VerticalMode` 0) |
| `cad-plugin/Positron.Plugin/Correcoes/XDataDasLinhasDoDesenho.cs` | **novo**: o `correcaoLines` (o mesmo quirk do `LimpaXData` pelo `LimpezaDoDesenho.MarcaUnica`) |
| `cad-plugin/Positron.Plugin/Correcoes/EstiloDeTextoDoDesenho.cs` | **novo**: o `Geral.CriaTextStyle` e o par `Romans`/`romans.shx` |
| `cad-plugin/Positron.Plugin/InicioDoDesenho.cs` | a ordem do `IniciarDWG`: tipo → painéis → páginas (ativação) → paleta → `lDwgRegen` (destrava + `Romans` + as cinco correções com marca + `Regen`) → `frmConfiguracaoBDProjeto`. Cada passo sai **só no log do harness** (o original não escreve nada ao carregar) |
| `cad-plugin/Positron.Plugin/Interface/Barra/BarraDeFerramentas.cs` | `AplicarTipoDoDesenho(tipo)` (aplica o plano da regra pura e devolve a linha do log) e a reaplicação do tipo **quando a aba é montada** — no AutoCAD ela nasce na primeira ociosidade, **depois** do `IniciarDWG`; o `pzBarra` passou a medir o `IsEnabled` de cada painel e o tipo do desenho |
| `cad-plugin/Positron.Plugin/Paginas/PaginaAtivaDoDesenho.cs` | `LerCamadaCorrente()` — o `LocalizaPaginaAtiva` **cru** (é o que o original passa ao `AtivaPagina` no `IniciarDWG`/`travaDWG`); o `Ler()` com a guarda continua para quem pergunta pela página ativa |
| `cad-plugin/Positron.Plugin/Plugin.cs` | `Registrar(linha)`: linha **só no log do harness**, sem a linha de comando |
| `scripts/cad-fixture-iniciar.lsp` | **novo**: monta o que as duas correções novas olham (2 `Line` com XData de versão antiga, 3 `Text` com `AUXCONEXAO` — um alvo e dois controles) e despeja tipo, marcas `CORRECAO`, `Romans`, camadas ligadas e o estado de cada `Line`/`Text` |
| `cad-plugin/Positron.Data.Tests/` | +26 testes: `MarcasDeCorrecaoTests` (11), `LigacaoDosPaineisTests` (7), `CorrecoesDeMigracaoTests` (8) |

**Desvios do original (com motivo):**

- **Buffer `CORRECAO` curto:** o original indexa sem conferir o tamanho e estoura o `IniciarDWG` inteiro
  no `catch` (`MsgBox` com `IndexOutOfRangeException`). Aqui o buffer sem o índice responde "não lida" e
  a marca nova nasce do zero (registrado no XML doc de `MarcasDeCorrecao.Lida`).
- **Menos de 2 painéis na barra:** o original acessaria `Panels[1]` sem existir (estoura). A regra nossa
  liga só o que existe e o último fica intocado.
- **`LerXDataConfiguracao*`:** no plugin a configuração **não fica guardada** — cada comando relê o
  desenho (`ConfiguracaoEfetiva`, rodada 180); o efeito do `LerXDataConfiguracao` no ramo do tipo é o
  mesmo, e o `LerXDataConfiguracaoListaDePontos` (a lista de pontos) não tem consumidor no recoder.
- **Falha ao criar o estilo `Romans`:** o original engole o erro em silêncio; aqui a linha do log diz o
  que aconteceu (nenhuma mensagem ao usuário, como lá).

## Prova

- `plugin:test`: **921** (895 + 26 novos), `Total: 921, Errors: 0, Failed: 0` pelo **console runner do
  xunit** (o `npm run plugin:test` sai 0 sem rodar nada neste SDK — ver *RUNBOOK*).
- builds ZWCAD / AutoCAD: 0 avisos, 0 erros.
- **AutoCAD 2020** — o **ZWCAD não está** nesta máquina (**verificado em 2026-10-16** por registro +
  pastas + `where`; receita no `RUNBOOK.md` → *Existe CAD nesta máquina?* — medir de novo antes de
  concluir qualquer ausência; a leitura de 2026-10-15 valia naquela data), então a medição foi pelo par
  `accoreconsole` (headless) + **interface cheia** (`acad.exe`, o único host com ribbon). O **AutoCAD
  2020 está instalado** — ao contrário do que as rodadas 176–180 afirmaram (corrigidas lá).

**(A) `Funcional.dwg` real** (`accoreconsole`, cópia): as marcas **que o original deixou** nos desenhos
do dono são lidas e as correções **não** rodam de novo — é a compatibilidade com o dado de verdade; a
página ativa do desenho é ativada ao abrir (17 layers desligados):

```
IniciarDWG: 16 página(s) do caderno — página ativa "23": 17 layer(s) desligado(s), 3 ligado(s), 0 alterado(s)
IniciarDWG: camadas destravadas (0 travada(s) liberada(s)) — página ativa "23": 17 layer(s) desligado(s), 3 ligado(s), 0 alterado(s)
IniciarDWG: estilo de texto Romans — já existia
CorrecaoDisp: já corrigido neste desenho (marca 1 no XData CORRECAO).
CorrecaoBornesVisiveis: já corrigido neste desenho (marca 2 no XData CORRECAO).
correcaoTextosCircuitos: já corrigido neste desenho (marca 3 no XData CORRECAO).
correcaoLines: já corrigido neste desenho (marca 4 no XData CORRECAO).
corrigeOrdemBornes: já corrigido neste desenho (marca 5 no XData CORRECAO).
```

**(B) Desenho novo com o fixture** (`accoreconsole`): as cinco marcas gravadas, o `Romans` criado e as
duas correções novas fazendo exatamente o que devem (o despejo é leitura independente, por `entget`):

```
IniciarDWG: estilo de texto Romans — criado
CorrecaoDisp: ... (marca 1 gravada).
CorrecaoBornesVisiveis: ... (marca 2 gravada).
correcaoTextosCircuitos: 1 de 3 texto(s) auxiliar(es) de circuito alinhados (marca 3 gravada).
correcaoLines: 2 de 2 Line(s) com o XData limpo (1 CONEXAO, 1 INTERLIGACAO) (marca 4 gravada).
corrigeOrdemBornes: ... (marca 5 gravada).
```

```
# despejo B (depois do load) — o alvo virou Baseline, os dois controles não foram tocados
LINE;28D;CONEXAO=sem;INTERLIGACAO=sem
LINE;28E;CONEXAO=sem;INTERLIGACAO=sem
TEXT;290;tipo=1;vertical=0;texto=circuito tipo 1 vmode 1     <- alvo: vertical 1 -> 0
TEXT;291;tipo=1;vertical=0;texto=circuito tipo 1 vmode 0     <- controle (já era 0)
TEXT;292;tipo=4;vertical=1;texto=secao tipo 4 vmode 1        <- controle (outro tipo): intacto
```

**(C) Página ativa ao abrir, com o fixture controlado** das páginas 1..3 (`cad-fixture-pagina-ativa.lsp`
+ o despejo): a camada corrente era `3` e as outras duas páginas ficaram desligadas, o `-1` e o `0`
ligados:

```
IniciarDWG: 3 página(s) do caderno — página ativa "3": 2 layer(s) desligado(s), 3 ligado(s), 2 alterado(s)
CAMADAS;corrente=3;ligadas=3
```

**(D) Interface cheia do AutoCAD 2020** (o caminho do usuário para a barra — sem ribbon no
`accoreconsole`), desenho novo marcado como do Elétron, **NETLOAD** e `pzBarra` na barra viva:

```
Barra: desenho tipo "E" — 9 painel(is) ligado(s) [Configuração | Caderno | Dispositivos | Bornes |
       Fiação | Construtivo | Cabos e Veias | Utilitários | Help], 0 desligado(s), 0 intocado(s).
pzBarra: 1 aba(s) POSITRON.ID_Positron ("Positron"), 9 painel(is) [Configuração ligado | Caderno
       ligado | Dispositivos ligado | Bornes ligado | Fiação ligado | Construtivo ligado | Cabos e
       Veias ligado | Utilitários ligado | Help ligado]; ... desenho tipo "E".
```

e o despejo independente (ActiveX, interface cheia) das cinco marcas gravadas no ModelSpace:

```
TIPO;E
CORRECAO;(CORRECAO 1 1 1 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0)
ROMANS;sim
```

**(E) Interface cheia, desenho novo sem nada** (tipo `V`) — os dois primeiros painéis ligados, do
terceiro ao penúltimo desligados e o **último intocado**, como o laço `for j = 2 to count - 2` do
original:

```
Barra: desenho tipo "V" — 2 painel(is) ligado(s) [Configuração | Caderno], 6 desligado(s)
       [Dispositivos | Bornes | Fiação | Construtivo | Cabos e Veias | Utilitários],
       1 intocado(s) [Help (ligado)].
pzBarra: ... [Configuração ligado | Caderno ligado | Dispositivos DESLIGADO | Bornes DESLIGADO |
       Fiação DESLIGADO | Construtivo DESLIGADO | Cabos e Veias DESLIGADO | Utilitários DESLIGADO |
       Help ligado]; ... desenho tipo "V".
```

**Regressão:** o ciclo completo no projeto real pelo `accoreconsole`
(`scripts/cad-projeto-e2e.ps1 -Cad AutoCAD -ExigirBaseline`, banco `.tmp-smoke/r181-e2e.db`):
`=== OK: ciclo completo ===`, com o relatório do `VERIF` em **249** = a linha de base (`BorneSemFiacao`
107, `BorneSemLm` 119, `IntervaloBorneInvalido` 11, `ReguaVazia` 10, `SobreposicaoAusente` 2).

**Não medido:** a troca de documento com dois desenhos abertos (a conferência do dono, que a rodada 180
já deixou em *Falta*) — o `DocumentActivated` continua o mesmo caminho, mas os painéis e a página ativa
agora também são refeitos a cada troca.

## Falta

- [ ] **`ACorrecaoBD.CorrigeBD`** (`ACorrecaoBD.cs`, 1573 linhas): a migração do banco, chamada no
  `IniciarDWG` quando o banco **é válido** — lê o `MAX(Numero)` da tabela `Correcao`, apaga as linhas de
  número negativo e aplica as correções de esquema/dado por versão (50..). Fora desta rodada porque é
  banco, não desenho, e porque a primeira leva depende da decisão do Access (item 1a). Na fila.
- [ ] **Dicionários de DWG e de painel** (`cDadosAccess.carregaDWGDicionario`/`carregaPainelDicionario`
  para o `dicDWG` do `DeclaracoesGeral`) e o `PointMonitorToolTips`: o recoder **não guarda cache** —
  lê a tabela `DWG`/os painéis sob demanda (`ProjectStore`) e não tem o monitor de dicas. Se algum
  comando do original depender do dicionário **quente** logo depois do load, isto volta para a fila.
- [ ] **`Dicionario.LeAtalhos`** (o `Xrecord` `CENG_ELET`/`Atalhos`, 6 valores) e o
  **`Caderno.ExisteFormato`** do ramo das páginas: nenhum dos dois é lido sob demanda hoje (o
  `ExisteFormato` equivalente é o de leitura do `TrocaDeFormatoDoDesenho`). Ficam com o ramo das páginas
  e dos atalhos.
- [ ] **`_uscPagina.statusBanco(...)`** — o status do banco no rodapé da paleta: entra no item 3 da
  correção do básico (a paleta fiel ao `uscPaginas`).
- [ ] **Ganchos `POSITRON_*` restantes** (`POSITRON_PAGINA`, `POSITRON_TITULO1..4`, `POSITRON_UNIDADE`,
  `POSITRON_FORMATO_TROCAR`): entram com o item 2 (as folhas).
- [ ] **Host ZWCAD não medido** — **verificado em 2026-10-16** que não há ZWCAD nesta máquina (registro + pastas + `where`); a ausência é uma medição **com data**, a repetir antes de concluir (`RUNBOOK.md` → *Existe CAD nesta máquina?*). O caminho da barra no
  ZWCAD é o do `ConstruirAba()` no load (a aba já existe quando o `IniciarDWG` roda), que é o caso mais
  simples; e a `pzBarra` mede o mesmo. Conferência do dono quando houver ZWCAD.

## Conhecimento registrado

`docs/recoder/conhecimento/projeto.md` — seção nova: o resto do `IniciarDWG` (os painéis pelo tipo de
desenho com o quirk do último painel, a ordem do `lDwgRegen`, o `travaDWG(false)`, o `CriaTextStyle`) e
o XData `CORRECAO` (app, 30 valores, `LerCorrecao`/`setaCorrecao`, o `setXData` que troca só o bloco do
app). No `RUNBOOK.md`, *Troubleshooting*: o conflito de versão do `xunit.runner.utility` na receita do
runner (e a ordem da cópia) e o que **não** existe no `accoreconsole` para ler XData (ActiveX e
`entget` de `BlockTableRecord`), com as armadilhas de `entmake` de XData. O harness da barra na
interface cheia ganhou o roteiro (o `NETLOAD` por `vl-cmdf`, numa linha só).

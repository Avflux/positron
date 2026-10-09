# Plano de execução — recoder do Eletron4Z sobre o positron

> Documento vivo. Cada etapa concluída vira uma linha na
> [tabela de registro](#registro-de-execução), com o commit e a evidência.
> Contexto de arquitetura: `POSITRON.md`. Como rodar/verificar: `RUNBOOK.md`.

## 1. Objetivo

Cobrir o máximo do recoder do `Eletron4Z` (reverso em
`..\..\Elet\Eletron4_ZWcad`) sobre este repositório, com estas regras:

1. **Toda etapa termina em commit** (um commit por etapa, mensagem descritiva).
2. **Toda alteração fica registrada** aqui (tabela de registro + `git log`).
3. **Toda etapa tem um critério de pronto verificável** — comando que roda e
   devolve exit 0, ou execução documentada dentro do CAD.
4. **Nada de dado inventado:** quando o original grava `0`/`""` e o dado não
   existe, o recoder grava ausente e o documento diz por quê (regra já adotada
   em `POSITRON.md` §6).

## 2. Estado de partida (baseline verificado)

Medido em 2026-10-09, árvore limpa, último commit `b37576e`.

| Gate | Resultado |
|---|---|
| `npm run plugin:build` (ZWCAD) | exit 0, 0 avisos → `Positron.Plugin.ZWCAD.dll` (29 KB) |
| `npm run plugin:test` | 100 aprovados |
| `npm run protocol:gen` | contrato OK (9 métodos; 31 tabelas / 341 colunas) |
| `npm run typecheck` | limpo |
| `npm run build:web` | OK (49 módulos) |
| `npm run test:sidecar` / `ruff check` | 20 testes / limpo |

**Ambiente CAD desta máquina:**

| Host | Estado | Consequência |
|---|---|---|
| **ZWCAD 2026** (26.31.0.20285) | instalado em `C:\Program Files\ZWSOFT\ZWCAD 2026`; `ZwManaged`/`ZwDatabaseMgd` 26.0.26.0, IL `v4.0.30319`; `.NET Framework 4.8.1`; símbolo `cmd_netload` presente | **alvo principal**: o build ZWCAD resolve `ZWCadDir` sozinho e a DLL é carregável por `NETLOAD` |
| **AutoCAD 2020** | **não instalado nesta máquina** (há 2010/2011/2013) | as execuções de `FIA`/`INT` feitas pelo dono do projeto no AutoCAD 2020 **foram positivas** e ficam documentadas como evidência histórica; não são reproduzíveis aqui |
| DWG TrueView 2027 | `accoreconsole.exe` + `acmgd/acdbmgd/accoremgd`, mas em **.NET 10** | **não serve** para o plugin net472 (falha `CS1705`); não substituir o AutoCAD |
| AutoCAD 2025+ | API .NET 8+ | fora do alvo net472 por construção |

**Defeito conhecido a corrigir primeiro** (bloqueia rodar dentro do CAD mais de
uma vez): só `Cabos4`/`Veias4` apagam a revisão antes de regravar
(`ProjectStore.RegravarCabos4`/`RegravarVeias4`). `Fiacao`,
`Interligacao4`, `Portas4F`, `Bornes4F` e `Contatos4F` **acumulam** — a
segunda execução de `FIA`/`INT` duplica linhas e o `ReordenarOrdemFiacao`
passa a reescrever a `Ordem` das duas cópias (medido no `RUNBOOK.md`: `Fiacao`
3→6, `Bornes4F` 2→4). **Corrigido na Etapa 1.**

## 3. Etapas

Prioridade **P0** = desbloqueia o resto; **P1** = fecha as fases 5–9; **P2** =
escopo estrutural do recoder.

### Etapa 0 — Plano e baseline · P0 · **concluída**

- **Entrega:** este documento + registro do baseline.
- **Pronto quando:** `docs/PLANO.md` existe, com as etapas e critérios.
- **Commit:** `docs(plano): ...`

### Etapa 1 — Idempotência da projeção · P0 · **concluída**

- **O que:** apagar as linhas da revisão (`DWG`+`Revisao`) antes de inserir em
  `Fiacao`, `Interligacao4`, `Portas4F`, `Bornes4F` e `Contatos4F`,
  espelhando o `RemoveRevisaoTabelaParaDWG`/`...ParaTodosDWG` do original.
  `Cabos4`/`Veias4` já fazem isso e servem de molde.
- **Pronto quando:** um teste roda `Projetar`/`Inserir*` **duas vezes** sobre a
  mesma revisão e o número de linhas não muda; a `Ordem` continua `1..N` por
  potencial depois da segunda rodada. `npm run plugin:test` e
  `npm run plugin:build` verdes.
- **Arquivos:** `cad-plugin/Positron.Data/ProjectStore.cs`,
  `cad-plugin/Positron.Data.Tests/*`, `docs/POSITRON.md` (fases 5–8),
  `docs/RUNBOOK.md` (remover o aviso de "nunca rode duas vezes").

### Etapa 2 — Saneamento documental · P0 · **concluída**

- **O que:** corrigir o que está factualmente errado ou velho:
  - `POSITRON.md` §6 e §9: ZWCAD 2026 **está** instalado; o alvo ZWCAD builda
    contra a API **real**; o AutoCAD 2020 é evidência histórica positiva do dono
    do projeto e não está nesta máquina; contagem de testes (100) e de módulos do
    web (49).
  - `RUNBOOK.md`: receita CAD deixa de ser só `accoreconsole` (AutoCAD) e ganha
    a receita ZWCAD `/b`; "Estado de verificação" atualizado.
  - `README.md` e `cad-plugin/README.md`: estado atual e pré-requisitos.
- **Pronto quando:** nenhum documento afirmar que o ZWCAD não está instalado nem
  que o build ZWCAD usa o stub; a receita do AutoCAD 2020 fica marcada como
  "executada pelo dono do projeto, resultado positivo, não reproduzível nesta
  máquina".
- **Commit:** `docs: ...`

### Etapa 3 — Harness ZWCAD 2026 (fase 4 fecha) · P0 · **concluída**

- **O que:**
  1. `Plugin.Escrever` também anexa a mensagem num arquivo quando
     `POSITRON_LOG` estiver definido (evidência *headless*; hoje a saída só
     aparece na linha de comando).
  2. Script `passo.scr` (`FILEDIA 0`, `SECURELOAD 0`, `NETLOAD`, comandos,
     `QUIT`) e um script de apoio (`scripts/cad-zwcad-smoke.ps1`) que cria o
     `.db` do zero pelo `schema.sql`, exporta as variáveis `POSITRON_*` e roda
     `ZWCAD.exe /nologo /b`.
  3. Receita no `RUNBOOK.md`.
- **Pronto quando:** `ELET` imprime `"Positron carregado..."` no
  `POSITRON_LOG` a partir de uma execução real do ZWCAD 2026. Requer o ZWCAD
  **fechado** (a segunda instância entrega para a primeira e não herda as
  variáveis de ambiente).
- **Estado: concluída.** `npm run cad:smoke` carrega a DLL por `NETLOAD` no ZWCAD
  2026 e roda `ELET`/`FIA`/`INT`/`SYNCD`/`VERIF` num `Drawing1` vazio; o
  `POSITRON_LOG` traz `Positron carregado.` e as respostas de cada comando.
  Três defeitos do próprio harness apareceram e foram corrigidos: o `-Db` do
  script colidia com o alias de `-Debug` (virou `-Banco`); o `/b` do ZWCAD espera
  o caminho **sem** `.scr`; e dentro de `@()` a vírgula do PowerShell tem
  precedência sobre o `+`, então a concatenação do caminho da DLL virava três
  elementos (uma linha cada) e o `NETLOAD` recebia um caminho quebrado.

### Etapa 4 — E2E das fases 5–9 dentro do ZWCAD · P1 · **concluída**

- **O que:** um DWG de teste com XData (`CONEXAO`, `INTERLIGACAO`, bornes,
  máscara e contatos), montado por script, e o ciclo
  `FIA` → `INT` → `SYNCD` → `VERIF` lido de volta pelo sidecar
  (`fiacao_por_painel`, `interligacao_por_cabo`).
- **Pronto quando:** o número de linhas gravado por comando confere com o
  esperado do desenho e o sidecar lê o mesmo conteúdo; resultado registrado no
  `RUNBOOK.md`.
- **Estado: concluída.** Dois níveis de prova dentro do ZWCAD 2026:
  - **fixture sintética** (`npm run cad:e2e`, `scripts/cad-fixture.lsp`): 2
    `CONEXAO` + 1 `INTERLIGACAO` → 2 linhas em `Fiacao` + 2 circuitos + 1 trecho,
    idempotente;
  - **desenho real** (`-Desenho ..\Elet\RCD\Funcional.dwg`): `FIA` 365 linhas
    (199 bornes, 191 dispositivos, 83 posições), 265 portas, 88 contatos, 83
    dispositivos, 11 circuitos, 15 aplicações; `INT` 20 trechos; `SYNCD` repete
    **sem duplicar**; `VERIF` aponta 1.034 problemas. O sidecar lê tudo de volta.
  Esta rodada achou e corrigiu um defeito real: `ReguasModelo.Inteiro` estourava
  `FormatException` com os inteiros vindo como string — agora tudo passa por
  `XDataNumero` (tolerante, coberto por `XDataNumeroTests`).
- **~~Pendência do `Bornes4F`/`Bornes4I`~~ — resolvida:** eram **três** defeitos
  que só o desenho real mostrava — (1) o Xrecord `REGUAS/MODELOS2` tem um
  **cabeçalho** no índice 0 e a régua é lida do índice 1 (`ReguasModelo` lia do 0 e
  descartava todas); (2) `Xrecord.Data` **lança** em registro vazio, agora lido por
  `XDataNeutro.Para(registro)`; (3) sobravam seis `registro.Data == null` que
  estouravam antes do helper. Resultado no desenho real: `Bornes4F` **168** e
  `Bornes4I` **216** (era 0/0).
- **Falta (opcional):** uma fixture com **blocos** (borne com XData `Dispositivo`/`B`, máscara
  `M`, contatos) para exercitar as fases 7–9 dentro do CAD — hoje elas só têm
  cobertura unitária.
- **Obstáculo medido (rodadas 9–10):** carimbar XData num `INSERT` pelo LISP **não
  funciona** no ZWCAD 2026 (`incorrect type - nil` em `entmake`/`entmakex` com o
  grupo `-3` e em `entmod` com a lista completa ou mínima), embora funcione em
  `LWPOLYLINE`. E a **biblioteca de simbologia** (`..\Elet\libs\Simbologia`) não
  resolve: os `CONEXAO`/`DISPOSITIVO` que aparecem nos bytes são **app names
  legados**; as entidades do símbolo (`H_P_B1_VCC++.dwg`) não têm XData. Sobram
  duas saídas: um **desenho de projeto real** ou um comando de fixture **só de
  Debug** no plugin. Detalhes no `RUNBOOK.md`.

### Etapa 5 — Pendências de projeção · P1 · **concluída**

- **~~Página com cruzamento~~ — feito na Etapa 12:** `ColunaPagina` reproduz o
  switch `Conf.incluirColuna` (`0..2` layer cru, `3..5` `BuscaAlternativo`, `6`
  `(layer)` + separador + alternativo) sobre a `PaginaMatrix`, e o `FIA`/`INT`
  aplicam a coluna ao gravar `Fiacao`, `Bornes4F`, `Dispositivos4F`,
  `Interligacao4` e `Bornes4I`. Config pelo ambiente: `POSITRON_INCLUIR_COLUNA`
  (padrão `0`) e `POSITRON_SEPARADOR_CRUZAMENTO`.
- **~~`ltZUHdAX7R`~~**: já implementado — `CasamentoDispositivo.EscolherTerminal`
  exige terminal `T*`/`B*` não-vazio e `!= "?"`, com o adapter lendo os
  atributos do bloco; testes `Sem_terminal_nao_casa`/`Terminal_indefinido_nao_casa`.
  Esta etapa só corrigiu a documentação, que dizia "fica como próximo passo".
- **~~Tipos `I`/`M`~~**: decisão já documentada e coberta
  (`Mascara_M_nunca_da_tag`, `Importado_le_tipo_I_e_painel_do_indice_9`).
- **Estado:** concluída — o `Pagina` da conexão (e das outras tabelas) é a coluna
  montada; `PaginaMatrixTests`/`ColunaPaginaTests` cobrem a matriz, o switch e a
  gravação.

### Etapa 6 — `VERIF` lendo o desenho · P1 · **concluída (regras) + calibrada no desenho real**

- **O que:** o verificador original (`frmVerificadorProjetoFiacao`/
  `...Interligacao`, ~3 mil linhas) também pinta erros do **desenho**
  (geometria, páginas apagadas, cabo referenciado fora do catálogo). Hoje o
  `VERIF` valida só as tabelas gravadas.
- **Pronto quando:** o `VERIF` reporta ao menos os problemas de desenho de maior
  valor (cabo sem catálogo, borne sem régua, página ausente) com teste cobrindo
  a regra pura.
- **Estado:** duas das três regras entraram — `VerificarCabosSemCatalogo`
  (`Interligacao4.Tag_Cabo` fora do catálogo `Cabos`) e `VerificarBornesSemRegua`
  (`IndiceRegua` que não resolve em `REGUAS/MODELOS2`), na área nova
  `AreaVerificacao.Desenho`; o `VERIF` lê o desenho (réguas/bornes) e o catálogo,
  e o resumo separa "desenho". A terceira regra entrou na Etapa 11
  (`VerificarPaginasAusentes`, com a matriz de páginas). Testes em
  `VerificadorDesenhoTests` e `PaginaMatrixTests`.
- **A/B contra o banco do produto (rodada 26):** o `RCD.mdb` do projeto (Access,
  gerado pelo original) abre por ODBC e permite comparar **tabela a tabela** no mesmo
  desenho (`Funcional.dwg` = índice **63** na tabela `DWG` do produto, revisão 3):
  `Fiacao` 494=**494**, `Portas4F` 265=**265**, `Dispositivos4F` 83=**83**,
  `Aplicacao4F` 15=**15**, `Circuitos4F` 11=**11** (era 7 — defeito achado e
  corrigido: o gerador varria pontos em vez das conexões); as **19 tabelas** batem
  coluna a coluna com o Access. `Contatos4F` fechou em **70 = 70** na rodada 27 (o
  gerador repetia terminais porque dividia dispositivo e bobinas em listas separadas;
  o `DivideTerminais` do original acumula e dedupa). `Bornes4F` (155 vs 168) foi
  investigado na rodada 28 e **não é defeito do recoder**: os bornes extras estão todos
  na página `1000` e não existem em nenhuma tabela do produto; o nome das réguas 1/2 é
  `ENTR 1/2` no desenho de hoje e `52-X1/X2` no banco do produto (todas as revisões); e
  o mesmo handle tem número de borne diferente. A cópia local não é a que o produto
  compilou. Detalhe no `RUNBOOK.md`.

- **Calibração no desenho real (rodada 12):** o `VERIF` saiu com **821** problemas
  no `Funcional.dwg`, e **548 eram falsos positivos sistemáticos** —
  (1) o verificador exigia régua/borne de **toda** linha de `Portas4F`, mas o
  produto grava dois tipos: `"B"` (borne da máscara, com régua/borne e terminal
  vazio) e `"T"` (terminal da máscara, **sem** régua/borne por construção);
  (2) `CaboSemCatalogo` acusava todo cabo com o **catálogo vazio** (ausência de
  dado, não "cabo inexistente" — o catálogo real vive no `RCD.mdb`). Com as duas
  correções o desenho real fecha em **273** problemas (SemTag 223, PontoSemTag 32,
  TerminalDuplicado 18, desenho 0) e o `VERIF` passou a imprimir a composição por
  tipo no log.
- **Segunda calibração (rodada 13):** a área "fiação" apontava **223** pontos sem
  tag — eram vértices/cruzamentos de fio, **todos** sem nenhum campo de dispositivo
  (`Handle`, `NRegua`, `IndexModelo`, `TipoBorne`, `Aplicacao`). A regra passou a
  exigir evidência de dispositivo e a área fechou em **0**. Em troca entrou a regra
  de **órfão** do original (`carregaOrfao`): `BorneSemFiacao` compara o `Handle` dos
  bornes do desenho com os gravados em `Fiacao` e acusa **193** de 199 no desenho
  real — investigação aberta (casamento restritivo demais ou bornes fora de fio?).

### Etapa 7 — Tabelas restantes do contrato · P2 · **concluída no recorte (7 de 10; as 3 restantes têm fluxo próprio, fora do recorte)**

- **Fora do recorte atual (verificado no reverso, com quem escreve cada uma):** os
  três restantes pertencem a fluxos que o plugin **não** cobre, e o `POSITRON.md` §3
  já diz que só o tipo `"E"` (Eletron) é operado.

  | Tabela | Escrita por | Gatilho | Insumo |
  |---|---|---|---|
  | `Aranha4` | `exportaCabos` (`cDadosAccessInterligacao2`) | **cinco telas de relatório**: `frmRelatorio_Aranha`, `frmRelatorio_DInterlig`, `frmRelatorio_DICemig`, `frmRelatorio_DIEnergisaMS`, `frmRelatorio_DIEnergisaMT` | `clsDInterlig.carregaTodosCabosDWG` (e as variantes `clsDIEnergisaMT/MS`), que varre o **documento de interligação** — o XData `DINTERLIG`, o mesmo que o `Interligação.dwg` real tem em **530** entidades |
  | `Atributos` | `cDadosAccessExpImp` / `cDadosAccessImportarProj` | telas de exportar/importar projeto | atributos (handle/nome/valor) do DWG exportado |
  | `Exportados` | `cDadosAccessExpImp` | idem | `Exportados(Codigo, Tipo, DWG, Caderno, Handle, Pagina, Posicao, Painel, Texto, …)` do DWG exportado |

  Ou seja: `Aranha4` é a **aranha do relatório de cabos** (ArqNet/DI e as variantes
  por concessionária), não derivável do `Interligacao4` (a hipótese da rodada 6 foi
  descartada); `Atributos`/`Exportados` são do fluxo de **exportação cross-DWG**.
  Nenhuma das três é produzida por um dos 6 comandos do recorte — e o insumo de
  `Aranha4` (o `DINTERLIG`) **existe** nos desenhos reais, então o dia em que o
  fluxo de relatório entrar no escopo, o dado está mapeado. Vale registrar que
  `DINTERLIG` é **um app name com cinco layouts** (`XDataDInterlig.GravarXData*`:
  borne, nome de régua, jumper, cabo e veia) — é a estrutura inteira da aranha do
  documento de interligação, não um campo só.
- **~~`Dispositivos4F`~~ — feito:** `Dispositivos4FGerador` (puro) +
  `ProjectStore.InserirDispositivos`/`DispositivosDaRevisao` (substitui a
  revisão) + o `FIA` gerando; 5 testes em `Dispositivos4FTests`.
- **~~`Circuitos4F`~~ — feito:** `Circuitos4FGerador` (puro) +
  `InserirCircuitos`/`CircuitosDaRevisao` + o `FIA` gerando (o `t6yXrlfi5w` do
  original: `Tipo == 1`, nome não-vazio, painel em uso, dedup por `Potencial`);
  `PontoFiacao` passou a carregar `Nome`/`Tipo` da conexão; 4 testes em
  `Circuitos4FTests`.
- **~~`Aplicacao4F`~~ — feito:** `Aplicacao4FGerador` (puro: lê o `Xrecord`
  `APLICACAO/TIPOS` — 10 valores por tipo, a partir do índice 1 — e mapeia para as
  linhas) + `AplicacoesDoDesenho` (adapter do dicionário) +
  `InserirAplicacoes`/`AplicacoesDaRevisao` + o `FIA` gerando (o `FiRUTW6Q6W` do
  original: copia todos os tipos, sem filtro); 4 testes em `Aplicacao4FTests`.
- **~~`Jumper4`~~ — feito:** comando novo `JMP` (o `frmCompilarJumperExt`):
  `JumperDoDesenho` monta um ponto por ponta da conexão (`Tipo == 4` com
  `Disp1`/`Disp2`, `Tipo == 3` com `Jumper == "JUMPER"`, sempre `bJumper = true`),
  e o `FiacaoProjetor` ganhou o destino `Jumper4` (`new FiacaoProjetor(store, true)`)
  reaproveitando casamento, layout, numeração e coluna `Pagina`;
  `InserirJumper`/`JumperDaRevisao` no `ProjectStore`; 3 testes em `JumperTests`.
- **~~`Portas4I`/`Bornes4I`~~ — feito:** `Portas4IGerador`/`Bornes4IGerador`
  (reaproveitam `Portas4FGerador`/`Bornes4FGerador` com o filtro nulo — a
  interligação não filtra por painel/modelo em uso) + `InserirPortas4I`/
  `InserirBornes4I`/`Portas4IDaRevisao`/`Bornes4IDaRevisao` + o `INT` gerando
  (o `wrlU180vl0` e o `T6NUlT3ghH` do `frmCompilarInterligacao`); 4 testes em
  `Interligacao4ITests`.
- **Custo real medido no reverso** (cada tabela vem de um fluxo próprio, não é só
  um `INSERT`):
  - (feito) `Dispositivos4F` — do próprio `frmCompilarFiacao` (linhas 2640–2793): um
    bloco por dispositivo tipo `P` **e** por máscara tipo `M` (`Tipo` = `"P"`/
    `"M"`), pulando `Complementar` e painel fora de uso. `Tag` = `Nome1[/Nome2]`;
    `Pagina` = layer (caso `0..2`); `PosicaoNum`/`Ordem` da `mPosicao` por
    `(painel, tag)`. No `P`, `BlocoTopografico`/`BlocoLayout` vêm do **dicionário
    de modelos de contato** (`DicionarioContatos` = nosso `ModelosContato`, que já
    tem os dois campos) por `IndexModelo`; quando `indexModelo == 0`, do próprio
    XData (`Topografico`/`Layout`). No `M`, vêm do **dicionário de máscaras**
    (`DicionarioMascaras` = nosso `ModelosMascara`). O scan dos blocos `M` já
    vinha do `DispositivosDeFiacaoDoDesenho` (o leitor aceita `M`), então não foi
    preciso adapter novo.
  - `Jumper4` — **não** vem do `FIA`: é escrito por `frmCompilarJumperExt`
    (comando `JMP`/`JPEXT` do reverso), fora do recorte atual.
  - `Aranha4`, `Circuitos4F`, `Aplicacao4F`, `Atributos`, `Exportados` — cada um
    com o seu fluxo/tela no reverso.
- **Pronto quando:** cada tabela projetada tem gerador puro + teste + comando ou
  passo de comando que a produz.

### Etapa 8 — UI WinForms do plugin · P2 · **concluída (telas + configuração)**

- **O que:** as telas `frmCompilar*` equivalentes, hoje substituídas por
  variáveis de ambiente (`POSITRON_DB_PATH`, `POSITRON_DWG`, ...).
- **Feito (rodada 17):** a camada de configuração que as telas do original
  editavam — `ConfiguracaoPositron` (padrão < arquivo `%APPDATA%\Positron\positron.ini`
  < ambiente, leitura tolerante, round-trip testado), os comandos e o log lendo
  dela, e a tela WinForms `FormularioConfiguracao` no comando **`ELETCFG`** (modal,
  nunca em script). A variável de ambiente continua vencendo, então nenhum E2E
  depende de arquivo.
- **Feito também (rodada 19):** o **conteúdo** da grid de erros —
  `RelatorioCompilacao` (puro, com `Texto()`/`Salvar()`) e o comando `ELETREL`, que
  grava em arquivo a verificação inteira (título, resumo, contagens e uma linha por
  problema). Como roda por script, é verificável: no `Funcional.dwg` sai um relatório
  de 116 linhas com os 107 problemas.
- **Feito (rodada 22):** a **tela de compilação** (`FormularioCompilacao`) no comando
  `ELETCMP`: grid de erro com área/tipo/tabela/identificador/detalhe, resumo e contagem
  no topo, e botão Salvar que grava pelo mesmo `RelatorioCompilacao`. O conteúdo vem de
  `MontarRelatorio` — o mesmo caminho do `ELETREL`.
- **Critério de pronto, com ressalva honesta:** as telas são **modais** e não há como
  clicar nelas nesta máquina; o que se verifica é (a) as duas builds compilam com as
  telas, (b) os 9 nomes de comando estão no assembly gerado e (c) o conteúdo da tela
  sai igual no `ELETREL` — 116 linhas, 107 problemas, no `Funcional.dwg`. Seleção de
  painéis/revisão e barra de progresso das telas do original seguem **fora**: painel e
  revisão vêm da configuração, e o progresso é a linha de resumo que o comando imprime.

### Etapa 9 — Decisões abertas · P2 · **aberta — depende do dono do projeto**

Três decisões de produto. **O encaixe de cada uma já existe** — decidir não volta a
bloquear implementação, e não decidir não trava nada (o recorte roda com SQLite, sem
licença e com relatório em texto).

#### 9a. Licenciamento — **encaixe pronto**, falta o provedor

O reverso tinha **três** provedores, todos checados na carga do plugin
(`myEletron`/`frmCarregaEL`): `cCheckLicRockey` (+`Rockey`, dongle), `cCheckElecKey`
(+`wElecKey`) e `cCheckNuvem` (+`FormRegNuvem`/`cDadosSQLServerLicenca`). As
credenciais do reverso **não** foram reconstruídas.

**Feito (rodada 29):** `ServicoDeLicenca` + `ILicenca` (ponto de encaixe) com
`LicencaDeDesenvolvimento` como padrão, e o gate `BloqueioDeLicenca` no início de
`FIA`/`JMP`/`INT`/`VERIF`/`ELETREL` — 4 testes cobrem autorizado, negado, provedor
que estoura e provedor nulo.

**Falta:** escolher o provedor e plugá-lo (uma linha na carga do plugin), mais o teste
com o hardware/serviço real. Esforço concentrado na carga do plugin.

#### 9b. Relatórios — hoje só o de verificação

O reverso tem **37 telas** `frmRelatorio_*`: Fiação (4 variantes), Interligação (5),
Potenciais (5), Materiais (2), Veias (2), Jumpers (2), Plaquetas (2), Anilhas (2),
Aranha, DI (4: ArqNet/Energisa MS/MT/SSE), Elektro, Copel, Eletrosul (2), GIGA,
Siemens, Furnas, TAF, Diferencial, Distribuição de Potencial, Estatística de Fiação,
Índice de Páginas e Revisão (2). Hoje o recoder entrega **um**: o de verificação, em
texto (`ELETREL`).

| Caminho | Custo | Onde brilha |
|---|---|---|
| Texto/CSV pelo próprio recoder | baixo (já existe o modelo `RelatorioCompilacao`) | conferência e anexo rápido |
| PDF no plugin (iTextSharp) | dependência .NET + layout por relatório | entrega ao cliente sem o app |
| Render no app Python | sem dependência .NET; o app já lê as 13 tabelas | layout iterável, exportação e impressão |

**Recomendação:** começar pelos 4 de conteúdo tabular (Fiação, Interligação,
Materiais, Veias) no app Python — a consulta já existe, o custo está no layout — e
deixar o PDF como render final. Os relatórios por concessionária (DI/Elektro/Copel/
Eletrosul/GIGA/Siemens) são variantes de layout sobre os mesmos dados.

#### 9c. Multi-usuário — SQLite hoje, SQL Server como caminho do produto

O reverso convivia com **os dois**: 13 classes `cDadosAccess*` (Access) **e**
`cDadosSQLServer.cs`. No recoder, o `ProjectStore` (~1.400 linhas) isola o SQL num só
lugar e o `.db` é do sidecar/app; o plugin é o único escritor das tabelas do diagrama.

**O que mudaria:** fábrica de conexão, dialeto (`IDENTITY` vs `AUTOINCREMENT`, `BIT` vs
`BOOL`, `DATETIME`), a chave `Indice` (hoje autoincremento por tabela) e a posse do
banco (deixa de ser arquivo único). A regra **"quem desenha, grava"** e o contrato de
20 métodos **não** mudam — é por isso que a decisão pode esperar.

#### O que já está pronto nas três frentes

| Frente | Encaixe |
|---|---|
| Licença | `ServicoDeLicenca`/`ILicenca` + gate em todos os comandos ✅ |
| Relatório | `RelatorioCompilacao` (texto) + `ELETREL`/`ELETCMP` + 20 métodos de leitura no app |
| Banco | `ProjectStore` com o SQL isolado; sidecar dono do `.db`; 31 tabelas em sincronia |

### Etapa 10 — Expor ao app as tabelas novas · P1 · **concluída**

- **O que:** o plugin passou a gravar `Circuitos4F`, `Dispositivos4F` e
  `Aplicacao4F`, mas o app não tinha como lê-las. Entraram no contrato
  (`protocol.py` + `packages/protocol/src/index.ts`) os métodos
  `circuitos_por_painel`, `dispositivos_por_painel` e
  `aplicacoes_por_revisao`, com as consultas no `ProjectDatabase`; o
  `protocol:gen` confere os dois lados.
- **UI:** a visão de painel (`usePainelDetalhe` + `PainelView`) ganhou
  `CircuitosPanel` e `DispositivosPanel` ao lado da fiação e da interligação.
- **UI (rodadas 23–25):** todos os métodos de leitura têm tela —
  `JumpersPanel` (`jumper_por_painel`), `AplicacoesPanel` (`aplicacoes_por_revisao`),
  `CatalogoPanel` (`cabos4_por_revisao`, `veias4_por_revisao`,
  `catalogo_listar_materiais`, `catalogo_listar_modelos_cabo`), a **busca por cabo**
  no `InterligacaoPanel` (`interligacao_por_cabo`) e o **drill-down do modelo/régua**
  (`PortasPanel` → `portas4i_por_modelo`, `BornesPanel` → `bornes4i_por_regua`) e
  `ContatosPanel` (`contatos4f_por_revisao`). Para isso entraram no contrato
  `portas4f_por_revisao`, `bornes4f_por_revisao` e `contatos4f_por_revisao` — as
  três tabelas do diagrama que o app ainda não lia: **20 métodos**, e agora **todas
  as 13 tabelas** que o plugin grava têm leitura no app, sincronizadas por
  `protocol:gen`.
- **Pronto quando:** `protocol:gen` verde (12 métodos **na época**; o contrato está em 17 depois das rodadas 10 e 12), `typecheck` limpo,
  `pytest` cobrindo os métodos novos e `build:web` OK.

### Etapa 11 — Matriz de páginas · P1 · **concluída**

- **O que:** o `DeclaracoesGeral.mPaginas` do original é montado por
  `Pagina.CarregaPaginas` a partir da **LayerTable**: cada layer que passa no
  `Pagina.LayerValido` (número positivo ou `<número><dígito|letra maiúscula>`)
  vira página, com `unidade`/`alternativo` do XData do app `Eletron`
  (marcador `UNIDADE`). Entraram: `PaginaMatrix` (puro: `Ler`, `Contem`,
  `Buscar`, `BuscaAlternativo`, `LayerValido`) e o adapter
  `PaginasDoDesenho` (LayerTable + XData).
- **Uso:** a regra `VerificarPaginasAusentes` no `VERIF` — a página gravada que
  não existe na `LayerTable` vira problema na área `Desenho`.
- **Pronto quando:** `plugin:build` (ZWCAD e stub) 0 avisos, `plugin:test` com
  `PaginaMatrixTests` cobrindo `LayerValido`, o `BuscaAlternativo` e a regra.
- **Feito na Etapa 12:** o switch `Conf.incluirColuna` 3..6 é aplicado na
  gravação. O original define `Conf.incluirColuna`/`Conf.SeparadorCruzamento` na
  tela `frmConfiguracaoGeral` (config de sessão), **não** no `.db`; o recoder usa
  `POSITRON_INCLUIR_COLUNA` (padrão `0`) e `POSITRON_SEPARADOR_CRUZAMENTO`, no
  mesmo padrão de `POSITRON_DWG`/`POSITRON_LOCAL`.

## 4. Como cada etapa é verificada

Sempre os mesmos gates, do `RUNBOOK.md`, **todos exit 0**:

```bash
npm run plugin:build          # C# do plugin (ZWCAD, API real quando instalada)
npm run plugin:build:autocad  # C# contra o STUB (gate separado!)
npm run plugin:test           # xunit, net472
npm run protocol:gen          # contrato Python<->TS e tipos do schema
npm run typecheck
npm run build:web
npm run test:sidecar
uv run --directory services/sidecar ruff check .
```

**`plugin:build:autocad` é gate separado:** mexer em adapter pode usar um tipo que
só existe na API real (foi o `Circle`, na rodada 14) — `plugin:build` e
`plugin:test` passam verdes e o stub quebra. Rodar as duas builds.

Etapas que mexem no host CAD acrescentam a execução dentro do ZWCAD:
`npm run cad:smoke` (comandos num desenho vazio), `npm run cad:e2e` (fixture
`scripts/cad-fixture.lsp`) e `npm run cad:smoke -- -Desenho <dwg>` (desenho real,
aberto por **cópia no TEMP**).

## 5. Registro de execução

| Etapa | Data | Commit | Evidência |
|---|---|---|---|
| 0 — Plano e baseline | 2026-10-09 | 24a7c5b | baseline da seção 2 medido nesta máquina |
| 1 — Idempotência da projeção | 2026-10-09 | cbadec5 | `plugin:build` 0 avisos; `plugin:test` **105** aprovados (5 novos em `IdempotenciaTests`); `ProjectStore` apaga `(DWG, Revisão)` antes do INSERT em `Fiacao`, `Interligacao4`, `Portas4F`, `Bornes4F` e `Contatos4F` (mesma transação) |
| 2 — Saneamento documental | 2026-10-09 | 3673d80 | `POSITRON.md` §6/§9, `RUNBOOK.md` (receita ZWCAD + estado de verificação), `README.md` e `cad-plugin/README.md`; contagens 105 testes / 49 módulos |
| 3 — Harness ZWCAD | 2026-10-09 | f5bc9a5 | `POSITRON_LOG` no `Plugin.Escrever`; `scripts/cad-zwcad-smoke.ps1` + `npm run cad:smoke`; receita no `RUNBOOK.md`; parser do `.ps1` OK e criação do `.db` (31 tabelas) validada — execução no CAD pendente do ZWCAD fechado |
| 3b — Harness **executado** no ZWCAD | 2026-10-09 | ee042f4 | `npm run cad:smoke` exit 0: `NETLOAD` + `ELET`/`FIA`/`INT`/`SYNCD`/`VERIF` no ZWCAD 2026 (fase 4 fechada); 3 defeitos do harness corrigidos (`-Db`×`-Debug`, `/b` sem `.scr`, precedência da vírgula no `@()`) |
| 4 — E2E com dados no ZWCAD | 2026-10-09 | 54fdcdf | `scripts/cad-fixture.lsp` + `npm run cad:e2e`: `FIA` 2 linhas + 2 circuitos, `INT` 1 `Interligacao4`, `SYNCD` repete sem duplicar, sidecar lê o mesmo conteúdo; falta fixture com blocos (fases 7–9) |
| 4b — E2E com **desenho real** | 2026-10-09 | 0bff89d | `-Desenho ..\Elet\RCD\Funcional.dwg`: `FIA` 365 linhas (199 bornes, 191 dispositivos), 265 portas, 88 contatos, 83 dispositivos; `INT` 20 trechos; `SYNCD` sem duplicar; `VERIF` 1.034 problemas. Achou e corrigiu o `FormatException` do `ReguasModelo` (`XDataNumero` + `DescreverErro` + `-Desenho` no harness); `plugin:test` **160** aprovados |
| 4c — 3 defeitos do desenho real (bornes) | 2026-10-09 | 58183d6 | `ReguasModelo` passa a ler do índice 1 (cabeçalho), `XDataNeutro.Para(Xrecord)` tolera `Xrecord.Data` que lança e os `registro.Data == null` saíram; no `Funcional.dwg` `Bornes4F` 0→**168** e `Bornes4I` 0→**216**; `plugin:test` **161** aprovados |
| 5 — Pendências de projeção (parcial) | 2026-10-09 | bc59c8d | auditoria mostrou que `ltZUHdAX7R` e a regra `I`/`M` **já estavam implementadas e testadas** (`DispositivosFiacaoTests`, 105 testes); `cad-plugin/README.md` corrigido; a `Pagina` com cruzamento veio na Etapa 12 (`ColunaPagina`) |
| 6 — `VERIF` no desenho (parcial) | 2026-10-09 | 50e06b4 | área `Desenho` + `VerificarCabosSemCatalogo`/`VerificarBornesSemRegua` ligadas ao `VERIF`; `plugin:test` **126** aprovados; falta a regra de página ausente |
| 6b — `VERIF` calibrado no desenho real | 2026-10-09 | d1e07f0 | composição por tipo no log; linha `"T"` de `Portas4F` não exige régua/borne (só a `"B"`) e catálogo de cabos vazio não gera apontamento; no `Funcional.dwg` o `VERIF` caiu de **821** para **273** problemas (548 falsos positivos); `plugin:test` **162** |
| 7a — `Dispositivos4F` | 2026-10-09 | ed7222a | gerador puro + gravação idempotente + `FIA` gerando; `plugin:test` **110** aprovados |
| 7b — `Circuitos4F` | 2026-10-09 | 1afbd7a | gerador puro + gravação idempotente + `FIA` gerando (`t6yXrlfi5w`); `plugin:test` **114** aprovados |
| 7c — `Aplicacao4F` | 2026-10-09 | 8591b9c | leitor do dicionário `APLICACAO/TIPOS` + gerador puro + gravação idempotente + `FIA` gerando (`FiRUTW6Q6W`); `plugin:test` **118** aprovados |
| 7d — `Portas4I`/`Bornes4I` | 2026-10-09 | bf46e7d | geradores `4I` (reuso com filtro nulo) + gravação idempotente + `INT` gerando (`wrlU180vl0`/`T6NUlT3ghH`); `plugin:test` **122** aprovados; restam `Jumper4`, `Aranha4`, `Atributos`, `Exportados` |
| 7e — `Jumper4` (`JMP`) | 2026-10-09 | 2a8035c | `JumperDoDesenho` (Tipo 3/4 com `Jumper`/`Disp1`/`Disp2`) + `FiacaoProjetor(store, true)` + `InserirJumper`/`JumperDaRevisao` + comando `JMP`; `plugin:test` **148** aprovados |
| 10 — Tabelas novas no app | 2026-10-09 | bc65cbf | `circuitos_por_painel`, `dispositivos_por_painel`, `aplicacoes_por_revisao` no contrato (12 métodos, `protocol:gen` verde) + consultas no `ProjectDatabase` + `CircuitosPanel`/`DispositivosPanel` na visão de painel; `pytest` **23** testes, `build:web` 51 módulos |
| 11 — Matriz de páginas | 2026-10-09 | 16e88c3 | `PaginaMatrix` (LayerValido/BuscaAlternativo) + `PaginasDoDesenho` (LayerTable + XData `Eletron`) + `VerificarPaginasAusentes` no `VERIF`; `plugin:test` **139** aprovados; build ZWCAD e stub 0 avisos |
| 12 — Coluna `Pagina` (cruzamento) | 2026-10-09 | b14fd51 | `ColunaPagina` (switch `Conf.incluirColuna` 0..6) sobre a `PaginaMatrix`, com `POSITRON_INCLUIR_COLUNA`/`POSITRON_SEPARADOR_CRUZAMENTO`, aplicada na gravação de `Fiacao`, `Bornes4F`, `Dispositivos4F`, `Interligacao4` e `Bornes4I`; `plugin:test` **145** aprovados |
| 13 — tag ausente e órfãos no `VERIF` | 2026-10-09 | a8a7091 | `SemTag` exige evidência de dispositivo (fiação do desenho real: 223 → **0**); nova regra `BorneSemFiacao` (órfão) acusa 193 de 199 bornes; desenho real em **243** problemas (BorneSemFiacao 193, PontoSemTag 32, TerminalDuplicado 18); `plugin:test` **163** |
| 14 — pontos de ligação do bloco (círculo) | 2026-10-09 | 01eeb0a | a tabela de deslocamentos passa a incluir os **quatro quadrantes do círculo** (o ramo `Circle` do `frmCompilarFiacao`), com helper puro `PontosDeLigacao` + 3 testes; no `Funcional.dwg` `BorneSemFiacao` 193→**171**, `PontoSemTag` de interligação 32→**0** e o `VERIF` 243→**189**; `plugin:test` **166** |
| 15 — pontos de fiação nas duas pontas | 2026-10-09 | ff8227e | a leitura passa a criar ponto na **primeira** e/ou **última** ponta da `CONEXAO` conforme `Tipo`/`Disp1`/`Disp2`/`Jumper` (regra do `frmCompilarFiacao`), com `PontosDaConexao` + 6 testes; no `Funcional.dwg` o `FIA` grava **494** linhas (era 365; previsto 494), `Circuitos4F` 11→**7** e os órfãos 171→**107** — o mesmo 107 que a simulação offline previa, fechando o casamento; `plugin:test` **172** |
| 16 — regras de duplicidade fiéis ao original | 2026-10-09 | 755b374 | sai a regra de "terminal repetido" da fiação (110 falsos positivos) e entra a do original: dois trechos **Tipo 2** com **mesma página e mesmas pontas** (`FiacaoDuplicada` + adapter `TrechosDoDesenho`); mesma coisa nos contatos (18 falsos positivos; o produto grava um contato por `sT1`/`sT2`/`sT3` sem dedup). Desenho real: **107 problemas, todos `BorneSemFiacao`** (a conta fecha com a simulação); `plugin:test` **173** |
| 17 — configuração do plugin (Etapa 8) | 2026-10-09 | 1feccfb | `ConfiguracaoPositron` (padrão < arquivo < ambiente, tolerante, com 5 testes), comandos e log lendo dela, tela WinForms + comando `ELETCFG`; `Circle` entra no `Positron.CadStub` (a build AutoCAD estava quebrada desde a rodada 14); desenho real segue em **107** problemas e `plugin:test` em **178** |
| 18 — perfil de XData do desenho | 2026-10-09 | 12b0e68 | os três DWGs reais mapeados por papel (Funcional = diagrama; Interligação = documento com `DINTERLIG`; Fiação = documento/plot) e `FIA`/`INT` passam a responder com o **perfil do desenho** quando não acham o que procuram (`PerfilDoDesenho` puro + `PerfilDoDesenhoDoDesenho`, 5 testes); `cad:e2e` sintético re-rodado (pendente da 17) e `Funcional.dwg` sem regressão (494 linhas / 107 problemas); `plugin:test` **183** |
| 19 — relatório de verificação (`ELETREL`) | 2026-10-09 | 060df46 | a grid de erros das telas do original vira arquivo: `RelatorioCompilacao` puro (`Texto()`/`Salvar()`, 4 testes) + comando `ELETREL` (chave `relatorio`/`POSITRON_RELATORIO`), com `VERIF` e `ELETREL` compartilhando `VerificarRevisao`; no `Funcional.dwg` saiu um relatório de 116 linhas com os **107** problemas (`Desenho;BorneSemFiacao;Fiacao;…`); `plugin:test` **188** |
| 20 — saneamento do plano | 2026-10-09 | eaa5bc1 | auditoria do documento inteiro: `(este commit)` zerado (19→`060df46`, 7e→`2a8035c`), tabela de registro reordenada por etapa (26 linhas), status em todas as etapas (1 e 2 estavam sem), Etapa 7 de 6→**7 de 10** (o `Jumper4` entrou na 7e), Etapa 9 virou tabela de decisão (o que existe / o que muda em cada escolha), gates ganham `plugin:build:autocad` com a lição do stub e o risco obsoleto de `FIA`/`INT` acumularem saiu; no follow-up `f6fd0d0` o `README.md` passou a listar os **8 comandos** (faltavam `JMP`, `ELETCFG` e `ELETREL`) e o E2E em desenho real |
| 21 — evidência das 3 tabelas fora do recorte | 2026-10-09 | dd1c533 | rastreado quem escreve cada uma no reverso: `Aranha4` só por `exportaCabos`, chamado por **cinco telas de relatório** (`frmRelatorio_Aranha`/`DInterlig`/`DICemig`/`DIEnergisaMS`/`MT`), com insumo em `clsDInterlig.carregaTodosCabosDWG` (o XData `DINTERLIG`, **530** entidades no `Interligação.dwg` real); `Atributos`/`Exportados` pelo `cDadosAccessExpImp` (exportar/importar cross-DWG). `DINTERLIG` é um app name com **cinco layouts** (borne, régua, jumper, cabo, veia) |
| 22 — tela de compilação (`ELETCMP`) | 2026-10-09 | f0f2878 | `FormularioCompilacao` (DataGridView + Salvar) sobre `MontarRelatorio`, o mesmo conteúdo do `ELETREL`; verificação: as duas builds com as telas, os **9 comandos** presentes no assembly gerado (`ELET`…`ELETREL`) e o relatório do `Funcional.dwg` idêntico ao da rodada 19 (116 linhas / 107 problemas); Etapa 8 fecha (ressalva: telas modais não clicáveis aqui) |
| 23 — painéis das consultas novas no app | 2026-10-09 | 3816651 | `JumpersPanel`, `AplicacoesPanel` e `CatalogoPanel` (cabos+veias) entram na `PainelView` via `usePainelDetalhe` (5 chamadas novas em paralelo), fechando a UI dos métodos expostos na rodada 10; verificado com as consultas contra o `.db` do `Funcional.dwg` — `aplicacoes_por_revisao` 15 linhas, `portas4i_por_modelo(1)` 17, `bornes4i_por_regua(5)` 4 (jumpers/catálogo 0, coerente: sem `JMP` e sem catálogo) — e `typecheck` + `build:web` (**54** módulos) |
| 24 — busca por cabo e catálogo completo no app | 2026-10-09 | e5a7954 | `InterligacaoPanel` ganha busca por `Tag_Cabo` (`interligacao_por_cabo`, com o resultado substituindo a lista) e o `CatalogoPanel` passa a mostrar `Materiais` e `ModelosCabos` além de cabos/veias; verificado com as consultas no `.db` real (`interligacao_por_cabo('8-CCE-001')` → 1 trecho; catálogo 0, coerente com o `RCD.mdb` não carregado) e `typecheck` + `build:web` (**54** módulos); UI fecha **15 dos 17 métodos** |
| 25 — Portas4F/Bornes4F no contrato e drill-down do modelo | 2026-10-09 | 0444254 | dois métodos novos (`portas4f_por_revisao`, `bornes4f_por_revisao`) levam o contrato a **19** e fecham a leitura das 13 tabelas do diagrama; na UI, `PortasPanel` e `BornesPanel` listam as portas/bornes do diagrama e abrem `portas4i_por_modelo`/`bornes4i_por_regua` no mesmo painel; verificado com o `.db` real (`portas4f` **265** e `bornes4f` **168**, batendo com o log do `FIA`; drill-downs 17 e 4) e `pytest` **27** / `build:web` **57** módulos; follow-up fechou o `Contatos4F` (20 métodos, **88** contatos no desenho real, batendo com o `FIA`) |
| 26 — A/B contra o banco do produto e correção dos circuitos | 2026-10-09 | 563c78f | o `RCD.mdb` (Access, gerado pelo original) abre por ODBC na cópia e permite comparar no mesmo desenho (`Funcional.dwg` = DWG **63**): `Fiacao` 494=494, `Portas4F` 265=265, `Dispositivos4F` 83=83, `Aplicacao4F` 15=15, `Circuitos4F` 11=**11** (era 7) e as **19 tabelas** batem coluna a coluna; confirma as regras `T`/`B` das portas e dos contatos repetidos; `Circuitos4FGerador` passa a receber as **conexões** (`ConexoesDoDesenho`), não os pontos — 1 teste novo, `plugin:test` **189** |
| 27 — A/B: contatos e circuitos iguais ao produto | 2026-10-09 | a30ebb0 | `Contatos4F` fecha em **70 = 70** (o `DivideTerminais` do original acumula e dedupa contra a lista; nós concatenávamos duas listas novas) e `Circuitos4F` em **11 = 11**; `Terminais.Acrescentar` + 1 teste, `plugin:test` **190**; resta `Bornes4F` 155 vs 168 com o detalhe por régua documentado |
| 28 — `Bornes4F` no A/B: cópia local ≠ a compilada | 2026-10-09 | 5b56b3b | investigação fecha sem mudança de código: os bornes extras estão todos na página **1000** e não aparecem em tabela nenhuma do produto (`Bornes4F` com `Pagina='1000'` = 0 linhas, handles ausentes até em `Fiacao`); as réguas 1/2 são `ENTR 1/2` no desenho e `52-X1/X2` no banco do produto em todas as revisões; o mesmo handle tem número de borne diferente. Conclusão: a cópia de `..\Elet\RCD` não é a que o produto compilou (o `DWG` do produto aponta para `J:\…`) |
| 29 — encaixe de licença e proposta da Etapa 9 | 2026-10-09 | 25621a7 | `ServicoDeLicenca`/`ILicenca` + `LicencaDeDesenvolvimento` e o gate nos 6 comandos (4 testes); levantamento do reverso para a Etapa 9: **3 provedores** de licença, **37 telas** `frmRelatorio_*` e **Access + SQL Server** no produto — proposta de cada caminho escrita no plano, com recomendação (licença: plugar provedor; relatórios: 4 tabulares no app Python; banco: SQL Server sem mudar o contrato); `plugin:test` **194** |
| 30 — idempotência e isolamento verificados por conteúdo | 2026-10-09 | 2a10c1b | terceira passada de projeção no mesmo `(DWG, Revisão)`: **1.607 linhas** idênticas, mudando **só `Data`** (re-carimbo esperado); rodada no desenho 74 no mesmo banco deixa o DWG 63 **byte-identico, inclusive `Data`**; `INT` no `Interligação.dwg` recusa com o perfil `DINTERLIG`; a verificação virou script do repositório (`scripts/cad-dump-tabelas.py` + receita no RUNBOOK) |
| 31 — catálogo importado e snapshot de cabos/veias verificado | 2026-10-09 | 97f4696 | `scripts/cad-importa-catalogo.ps1`+`.py` carregam o catálogo do Access por nome de coluna (697 cabos, 2.388 veias, 210 materiais; idempotente); com o catálogo, o `INT` carimba `Cabos4`/`Veias4` — **697** e **2.388** — e o `Veias4` bate **hash a hash** com o produto; o `Cabos4` bate com o **catálogo vivo** do produto (hash `3073d268…`), com as 25 diferenças contra o snapshot `00A-4` explicadas por edição do catálogo depois daquela revisão; `VERIF` com catálogo: regra `CaboSemCatalogo` ativa e limpa (os 18 `Tag_Cabo` do desenho estão no catálogo), 107 problemas seguem todos `BorneSemFiacao` |

## 6. Riscos e armadilhas

- **ZWCAD é instância única.** Rodar o script com o ZWCAD já aberto entrega para a
  instância existente, que **não** herda `POSITRON_*` — feche antes.
- **`FIA`/`INT` acumulavam** até a Etapa 1 — hoje são idempotentes (cada projeção
  apaga a `(DWG, Revisão)` na mesma transação).
- **O `.db` não é criado pelo plugin.** `ProjectStore` não aplica o schema;
  quem cria é o sidecar (`ProjectDatabase.create_from_schema`, usado por
  `projeto_abrir`) ou o harness da Etapa 3.
- **`WAL` não é opcional** — leitor longo sem WAL trava o plugin no meio do
  comando.
- **AutoCAD 2020 é evidência histórica.** Não "consertar" o stub para fazer o
  build AutoCAD passar por acidente: o stub é gate de compilação, não host.

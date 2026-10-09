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

### Etapa 1 — Idempotência da projeção · P0

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

### Etapa 2 — Saneamento documental · P0

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

### Etapa 4 — E2E das fases 5–9 dentro do ZWCAD · P1 · **parcial (fases 5–6 fechadas)**

- **O que:** um DWG de teste com XData (`CONEXAO`, `INTERLIGACAO`, bornes,
  máscara e contatos), montado por script, e o ciclo
  `FIA` → `INT` → `SYNCD` → `VERIF` lido de volta pelo sidecar
  (`fiacao_por_painel`, `interligacao_por_cabo`).
- **Pronto quando:** o número de linhas gravado por comando confere com o
  esperado do desenho e o sidecar lê o mesmo conteúdo; resultado registrado no
  `RUNBOOK.md`.
- **Estado:** o caminho de dados está fechado ponta a ponta no CAD. O
  `scripts/cad-fixture.lsp` monta duas `CONEXAO` e uma `INTERLIGACAO` dentro do
  ZWCAD e o `npm run cad:e2e` roda `ELET`/`FIA`/`INT`/`SYNCD`/`VERIF`: `FIA` grava
  2 linhas em `Fiacao` + 2 circuitos, `INT` grava 1 `Interligacao4`, o `SYNCD`
  repete **sem duplicar** (idempotência no CAD) e o sidecar lê as mesmas linhas.
- **Falta:** uma fixture com **blocos** (borne com XData `Dispositivo`/`B`, máscara
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

### Etapa 6 — `VERIF` lendo o desenho · P1 · **parcial**

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

### Etapa 7 — Tabelas restantes do contrato · P2 · **parcial (6 de 10 feitas)**

- **Fora do recorte atual (verificado, não é pendência de execução):** os três
  restantes pertencem a fluxos que o plugin **não** cobre, e o `POSITRON.md` §3 já
  diz que só o tipo `"E"` (Eletron) é operado:
  - `Aranha4` — o mapa cabo→página da **aranha** vem das telas de ArqNet/DI: o
    `clsDInterlig.carregaTodosCabosDWG` (e as variantes `clsDIEnergisaMT/MS`) varre
    blocos com nome contendo `CABO` e lê o XData `XDataDIEnergisa.LerXDataCabo`,
    montando `caboSync { Revisao, Tag_Cabo, Painel, Caderno = Conf.Local,
    Folha = layer, Coluna = cabo.Coluna }`; o `exportaCabos` só grava esse array.
    **Não** é derivável do `Interligacao4` (hipótese da rodada 6, descartada aqui).
  - `Atributos` / `Exportados` — do fluxo de exportação/importação cross-DWG
    (`cDadosAccessExpImp`), comandos `EXPDWG`/`IMP*`, fora do recorte.
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

### Etapa 8 — UI WinForms do plugin · P2

- **O que:** as telas `frmCompilar*` equivalentes, hoje substituídas por
  variáveis de ambiente (`POSITRON_DB_PATH`, `POSITRON_DWG`, ...).

### Etapa 9 — Decisões abertas · P2

- Licenciamento (Rockey/ElecKey/Nuvem — **não** reconstruir as credenciais Azure
  do reverso), relatórios (PDF/iTextSharp vs. app Python) e multi-usuário
  (SQLite → SQL Server).

### Etapa 10 — Expor ao app as tabelas novas · P1 · **concluída**

- **O que:** o plugin passou a gravar `Circuitos4F`, `Dispositivos4F` e
  `Aplicacao4F`, mas o app não tinha como lê-las. Entraram no contrato
  (`protocol.py` + `packages/protocol/src/index.ts`) os métodos
  `circuitos_por_painel`, `dispositivos_por_painel` e
  `aplicacoes_por_revisao`, com as consultas no `ProjectDatabase`; o
  `protocol:gen` confere os dois lados.
- **UI:** a visão de painel (`usePainelDetalhe` + `PainelView`) ganhou
  `CircuitosPanel` e `DispositivosPanel` ao lado da fiação e da interligação.
- **Pronto quando:** `protocol:gen` verde (12 métodos), `typecheck` limpo,
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
npm run plugin:build      # C# do plugin (ZWCAD, API real quando instalada)
npm run plugin:test       # xunit, net472
npm run protocol:gen      # contrato Python<->TS e tipos do schema
npm run typecheck
npm run build:web
npm run test:sidecar
uv run --directory services/sidecar ruff check .
```

Etapas que mexem no host CAD acrescentam a execução dentro do ZWCAD (Etapa 3) e
a leitura de volta pelo sidecar (Etapa 4).

## 5. Registro de execução

| Etapa | Data | Commit | Evidência |
|---|---|---|---|
| 0 — Plano e baseline | 2026-10-09 | 24a7c5b | baseline da seção 2 medido nesta máquina |
| 2 — Saneamento documental | 2026-10-09 | 3673d80 | `POSITRON.md` §6/§9, `RUNBOOK.md` (receita ZWCAD + estado de verificação), `README.md` e `cad-plugin/README.md`; contagens 105 testes / 49 módulos |
| 3 — Harness ZWCAD | 2026-10-09 | f5bc9a5 | `POSITRON_LOG` no `Plugin.Escrever`; `scripts/cad-zwcad-smoke.ps1` + `npm run cad:smoke`; receita no `RUNBOOK.md`; parser do `.ps1` OK e criação do `.db` (31 tabelas) validada — execução no CAD pendente do ZWCAD fechado |
| 3b — Harness **executado** no ZWCAD | 2026-10-09 | ee042f4 | `npm run cad:smoke` exit 0: `NETLOAD` + `ELET`/`FIA`/`INT`/`SYNCD`/`VERIF` no ZWCAD 2026 (fase 4 fechada); 3 defeitos do harness corrigidos (`-Db`×`-Debug`, `/b` sem `.scr`, precedência da vírgula no `@()`) |
| 4 — E2E com dados no ZWCAD (parcial) | 2026-10-09 | (este commit) | `scripts/cad-fixture.lsp` + `npm run cad:e2e`: `FIA` 2 linhas + 2 circuitos, `INT` 1 `Interligacao4`, `SYNCD` repete sem duplicar, sidecar lê o mesmo conteúdo; falta fixture com blocos (fases 7–9) |
| 5 — Pendências de projeção (parcial) | 2026-10-09 | bc59c8d | auditoria mostrou que `ltZUHdAX7R` e a regra `I`/`M` **já estavam implementadas e testadas** (`DispositivosFiacaoTests`, 105 testes); `cad-plugin/README.md` corrigido; resta só a `Pagina` com cruzamento (matriz de páginas) |
| 7a — `Dispositivos4F` | 2026-10-09 | ed7222a | gerador puro + gravação idempotente + `FIA` gerando; `plugin:test` **110** aprovados |
| 7b — `Circuitos4F` | 2026-10-09 | 1afbd7a | gerador puro + gravação idempotente + `FIA` gerando (`t6yXrlfi5w`); `plugin:test` **114** aprovados |
| 7c — `Aplicacao4F` | 2026-10-09 | 8591b9c | leitor do dicionário `APLICACAO/TIPOS` + gerador puro + gravação idempotente + `FIA` gerando (`FiRUTW6Q6W`); `plugin:test` **118** aprovados |
| 7d — `Portas4I`/`Bornes4I` | 2026-10-09 | bf46e7d | geradores `4I` (reuso com filtro nulo) + gravação idempotente + `INT` gerando (`wrlU180vl0`/`T6NUlT3ghH`); `plugin:test` **122** aprovados; restam `Jumper4`, `Aranha4`, `Atributos`, `Exportados` |
| 6 — `VERIF` no desenho (parcial) | 2026-10-09 | 50e06b4 | área `Desenho` + `VerificarCabosSemCatalogo`/`VerificarBornesSemRegua` ligadas ao `VERIF`; `plugin:test` **126** aprovados; falta a regra de página ausente |
| 10 — Tabelas novas no app | 2026-10-09 | bc65cbf | `circuitos_por_painel`, `dispositivos_por_painel`, `aplicacoes_por_revisao` no contrato (12 métodos, `protocol:gen` verde) + consultas no `ProjectDatabase` + `CircuitosPanel`/`DispositivosPanel` na visão de painel; `pytest` **23** testes, `build:web` 51 módulos |
| 11 — Matriz de páginas | 2026-10-09 | 16e88c3 | `PaginaMatrix` (LayerValido/BuscaAlternativo) + `PaginasDoDesenho` (LayerTable + XData `Eletron`) + `VerificarPaginasAusentes` no `VERIF`; `plugin:test` **139** aprovados; build ZWCAD e stub 0 avisos |
| 12 — Coluna `Pagina` (cruzamento) | 2026-10-09 | b14fd51 | `ColunaPagina` (switch `Conf.incluirColuna` 0..6) sobre a `PaginaMatrix`, com `POSITRON_INCLUIR_COLUNA`/`POSITRON_SEPARADOR_CRUZAMENTO`, aplicada na gravação de `Fiacao`, `Bornes4F`, `Dispositivos4F`, `Interligacao4` e `Bornes4I`; `plugin:test` **145** aprovados |
| 7e — `Jumper4` (`JMP`) | 2026-10-09 | (este commit) | `JumperDoDesenho` (Tipo 3/4 com `Jumper`/`Disp1`/`Disp2`) + `FiacaoProjetor(store, true)` + `InserirJumper`/`JumperDaRevisao` + comando `JMP`; `plugin:test` **148** aprovados |
| 1 — Idempotência da projeção | 2026-10-09 | cbadec5 | `plugin:build` 0 avisos; `plugin:test` **105** aprovados (5 novos em `IdempotenciaTests`); `ProjectStore` apaga `(DWG, Revisão)` antes do INSERT em `Fiacao`, `Interligacao4`, `Portas4F`, `Bornes4F` e `Contatos4F` (mesma transação) |

## 6. Riscos e armadilhas

- **ZWCAD é instância única.** Rodar o script com o ZWCAD já aberto entrega para a
  instância existente, que **não** herda `POSITRON_*` — feche antes.
- **`FIA`/`INT` acumulam** até a Etapa 1 entrar: comece sempre de um `.db` novo.
- **O `.db` não é criado pelo plugin.** `ProjectStore` não aplica o schema;
  quem cria é o sidecar (`ProjectDatabase.create_from_schema`, usado por
  `projeto_abrir`) ou o harness da Etapa 3.
- **`WAL` não é opcional** — leitor longo sem WAL trava o plugin no meio do
  comando.
- **AutoCAD 2020 é evidência histórica.** Não "consertar" o stub para fazer o
  build AutoCAD passar por acidente: o stub é gate de compilação, não host.

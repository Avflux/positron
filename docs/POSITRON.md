# Arquitetura — dois frontends (app + plugin ZWCAD)

Este documento decide **como reconstruir o Eletron4Z** sobre o esqueleto do
`positron`, a partir da engenharia reversa em
`..\..\Elet\Eletron4_ZWcad` (veja `ARQUITETURA.md` daquela pasta).

Leia `ARCHITECTURE.md` e `PROTOCOL.md` antes: eles descrevem o esqueleto
(Tauri + React/TS + sidecar Python por ZMQ) que este documento **estende**.
Nada aqui substitui aquelas decisões; tudo aqui se apoia nelas.

## 1. O recorte

O plugin original é um monolito .NET de ~33.7 mil métodos: 216 comandos, 131
telas, acesso a cinco bancos, licenciamento por dongle/nuvem e 45 relatórios.
Reconstruir isso inteiro de uma vez é inviável — e a maior parte não é o valor
central. O recorte pedido é:

- **Construir a fiação e a interligação do diagrama funcional** (o núcleo).
- **Gerenciar o projeto** (painéis, cabos, veias, materiais, relatórios) lendo o
  banco.

Isso se divide naturalmente em **dois frontends** que rodam em runtimes
diferentes e **não compartilham processo**.

```text
   ┌─────────────────────────────┐              ┌─────────────────────────────┐
   │ FRONTEND APP (positron)      │              │ FRONTEND ZWCAD (plugin .NET) │
   │  Tauri + React/TS            │              │  C# net472 + WinForms        │
   │  NÃO tem ZWCAD               │              │  rodando DENTRO do ZWCAD     │
   │                              │              │  ZwManaged v26               │
   └──────────────┬──────────────┘              └──────────────┬──────────────┘
                  │ IPC + ZMQ                                    │ API gerenciada
   ┌──────────────┴──────────────┐                              │ (entidades + XData)
   │ sidecar Python (dono do BD)  │                              │
   │  SQLite do projeto (.db)     │◄───── mesmo arquivo ────►────┘
   └──────────────────────────────┘         SQLite (WAL)
```

O **banco SQLite do projeto** é o único ponto de integração entre os dois. O
plugin enxerga também o **DWG + XData**; o app não enxerga nada disso (não há
ZWCAD no processo dele).

## 2. As decisões que moldam o resto

### 1. Não há servidor: a integração é um arquivo

O backend original podia ser Access (`.accdb`), SQLite (`.db`) ou SQL Server.
Começamos por **SQLite** por decisão explícita: zero instalação, schema já
extraído do `Modelo de BD Projeto.db`, e é o que dá para testar hoje. O schema
é a interface — tratar qualquer fala sobre "API entre os frontends" como uma
camada a mais é o erro clássico aqui.

### 2. O plugin ZWCAD é o único autor da fiação e da interligação

Só o plugin roda dentro do ZWCAD, então **só ele** toca entidades e XData. Por
consequência ele é também **o único que escreve** as tabelas derivadas do
diagrama (`Fiacao`, `Interligacao4`, `Bornes4F`, …). O app as **lê**.

Isso elimina dual-write: não existem duas fontes tentando manter a mesma linha
coerente. A regra é uma frase: **quem desenha, grava.** O plugin projeta
`XData → tabelas`; o app nunca edita diagrama.

### 3. O acesso a banco do app vive no sidecar, exposto pelo protocolo atual

A tentação é pôr um driver SQLite no Rust ou abrir o arquivo no React. Não:
`ARCHITECTURE.md` já decidiu que **a UI nunca vê socket nem arquivo**, e o
`schema` de métodos do sidecar já é a fonte da verdade. Então

- a leitura/escrita do app é um conjunto de **métodos** (`projeto.*`,
  `fiacao.*`, `catalogo.*`) em `handlers.py`;
- o TS espelha os tipos em `packages/protocol` e `npm run protocol:gen` fecha o
  contrato;
- o Rust não muda: `zmq_request` é genérico.

Ganho: o app frontend não precisa de nenhuma ponte nova. Custo: nenhum.

### 4. O plugin fala SQLite direto — não depende do sidecar

O plugin **não** é cliente ZMQ. Draftar no ZWCAD não pode depender de outro
processo estar no ar; e introduzir NetMQ no plugin criaria uma segunda cópia do
protocolo. Em vez disso o plugin usa `System.Data.SQLite` (já vinha no original)
e trata o **schema** como contrato.

Consequência dura, e é a decisão mais importante daqui: como os dois escrevem no
mesmo arquivo, o **schema precisa ser versionado e conferido nas duas
linguagens**. Ver `## 4. Contrato compartilhado`.

### 5. A coerção mora no plugin; a verdade dos catálogos mora no app

O diagrama funcional é do tipo `"E"` (Eletron). Ao salvar/sincronizar, o plugin
projeta o desenho para as tabelas. As **definições** (modelo de cabo, catálogo
de materiais, réguas) pertencem ao app; o plugin só referencia por chave
(`Tag`, `Codigo`, `IndexModelo`). Se o plugin gravar um `Tag` que não existe no
catálogo, a UI do app sinaliza — não inventa dado.

## 3. Contrato compartilhado — o schema

Extraído de `BD Projeto\Modelo de BD Projeto.db`. A coluna **dono** define quem
**escreve**; todos leem. Chave de versão da linha: `(Indice, Revisao, DWG)` nas
tabelas derivadas do diagrama.

### Escrito pelo plugin (derivado do diagrama)

| Tabela | Papel | Chaves relevantes |
|---|---|---|
| `Fiacao` | fios ligados a bornes | `DWG, Painel, Potencial, Tag, Terminal, Secao, Cor, Handle, IndexModelo` |
| `Interligacao4` | cabo/veia de um ponto a outro | `Tag_Cabo, Num_Veia, DWG1/Tag1/Terminal1 ↔ DWG2/Tag2/Terminal2` |
| `Jumper4` | jumper (espelho de `Fiacao`) | igual a `Fiacao` |
| `Bornes4F` / `Bornes4I` | bornes fixos / intermediários | `DWG, Painel, Regua, Borne, Ordem, LM` |
| `Portas4F` / `Portas4I` | portas lógicas | `DWG, IndexModelo, Regua, Borne, Terminal` |
| `Contatos4F` | contatos auxiliares | `DWG, IndexModelo, Terminal, Orientacao` |
| `Dispositivos4F` | dispositivos no diagrama | `DWG, Painel, Tag, Tipo, Handle` |
| `Aranha4` | mapa cabo→página ("aranha") | `Tag_Cabo, Painel, Caderno, Folha, Coluna` |
| `Circuitos4F` | circuito por painel | `DWG, Painel, Circuito, Potencial` |
| `Aplicacao4F` | aplicação de cabo (seção/cor/tipo) | `DWG, Numero, Nome, Secao, Cor, TipoCabo, Isolacao` |
| `Atributos`, `Exportados` | atributos de bloco e projeção cross-DWG | `DWG, Handle, Nome, Valor` |

### Escrito pelo app (catálogo, projeto e configuração)

| Tabela | Papel |
|---|---|
| `Materiais`, `ListaMateriais` | catálogo e lista de material |
| `ModelosCabos`, `Cabos`, `Veias` | **definições** (catalog) de cabo/veia |
| `Cabos4`, `Veias4` | **instâncias** (o plugin grava as instâncias; ver nota) |
| `Paineis`, `PaineisH`, `Plaquetas4` | projeto |
| `DWG`, `DWGH` | índice de desenhos |
| `Configuracoes`, `Preferencias`, `Comandos`, `Correcao` | estado e migração |

> **Nota sobre `Cabos4`/`Veias4`:** o catálogo (`Cabos`, `Veias`) é do app; a
> instanciação por projeto (`Cabos4`, `Veias4`) nasce no plugin, quando o cabo é
> lançado no diagrama. Regra: **quem cria a linha é o dono** — e o app só
> atualiza campos de catálogo via `JOIN` por `Tag`.

### XData — domínio exclusivo do plugin

O estado elétrico também vive **dentro das entidades do DWG**, via `RegAppTable`.
O app **não consegue ler isso** (não tem ZWCAD). *App names* observados no
reverso: `Eletron`, `ArqNet`, `ARANHA`, `CONEXAO`, `AUXBORNES`, `AUXCONEXAO`,
`AUXDERIVACAO`, `AUXINTERLIG`, `AUXDISP*`, `AUXEXPORTADO`, `AUXIMPORTADO`,
`CODEXPORT`, `DiagLog`.

O tipo do desenho (`XDataGeral.verificaTipoXData`) decide o que o plugin aceita
operar:

| Retorno | App name raiz | Tipo | O plugin da fiação atua? |
|---|---|---|---|
| `"E"` | `Eletron` | Eletron | **sim** (diagrama funcional) |
| `"D"` | `DiagLog` | DiagLog | não |
| `"A"` | `ArqNet` | ArqNet | não |
| `"V"` | — | vazio/outro | não (exige iniciar) |

Regra: **toda operação do plugin valida o tipo antes de escrever.** É o
equivalente do `limpaComandos()` original, mas por desenho, não por licença.

### Concorrência

SQLite com **`PRAGMA journal_mode=WAL`**. Um escritor por vez (o plugin, durante
o desenho) e leitores concorrentes (o app). Sem WAL, o app que abre uma conexão
longa bloqueia o plugin no meio de um comando. Se um dia houver multi-usuário,
o caminho (já previsto no original) é SQL Server — não "melhorar" o SQLite.

## 4. Interfaces

### App frontend → sidecar (protocolo ZMQ existente)

Implementados na fase 2 em `handlers.py` + `packages/protocol` (contrato conferido
por `npm run protocol:gen`). Os nomes ficam em **snake_case**, como os existentes
(`ping`, `echo`): o `gen-protocol` só aceita `[a-z_][a-z0-9_]*`, então
`projeto.abrir` (com ponto) **quebraria o gate** — não é estilo, é restrição da
ferramenta.

| Método | `params` | `result` |
|---|---|---|
| `projeto_abrir` | `{ caminho }` | `{ caminho, tabelas: string[] }` |
| `projeto_listar_paineis` | `{}` | `{ paineis: Paineis[] }` |
| `catalogo_listar_materiais` | `{ filtro? }` | `{ materiais: Materiais[] }` |
| `catalogo_listar_modelos_cabo` | `{}` | `{ modelos: ModelosCabos[] }` |
| `fiacao_por_painel` | `{ painel, revisao? }` | `{ fios: Fiacao[] }` |
| `interligacao_por_cabo` | `{ tag_cabo }` | `{ trechos: Interligacao4[] }` |
| `interligacao_por_painel` | `{ painel }` | `{ trechos: Interligacao4[] }` |
| `circuitos_por_painel` | `{ painel, revisao? }` | `{ circuitos: Circuitos4F[] }` |
| `dispositivos_por_painel` | `{ painel, revisao? }` | `{ dispositivos: Dispositivos4F[] }` |
| `aplicacoes_por_revisao` | `{ revisao? }` | `{ aplicacoes: Aplicacao4F[] }` |
| `jumper_por_painel` | `{ painel, revisao? }` | `{ jumpers: Jumper4[] }` |
| `portas4i_por_modelo` | `{ index_modelo }` | `{ portas: Portas4I[] }` |
| `bornes4i_por_regua` | `{ index_regua }` | `{ bornes: Bornes4I[] }` |
| `cabos4_por_revisao` | `{ revisao? }` | `{ cabos: Cabos4[] }` |
| `veias4_por_revisao` | `{ revisao? }` | `{ veias: Veias4[] }` |
| `portas4f_por_revisao` | `{ revisao? }` | `{ portas: Portas4F[] }` |
| `bornes4f_por_revisao` | `{ revisao? }` | `{ bornes: Bornes4F[] }` |
| `contatos4f_por_revisao` | `{ revisao? }` | `{ contatos: Contatos4F[] }` |

O tipo de cada linha (`Paineis`, `Fiacao`, …) vem de `schema.generated.ts`, não de
modelos escritos à mão. `relatorio_gerar` fica para a fase de relatórios.

As tabelas que o `FIA`/`INT` passaram a gravar também chegam ao app:
`circuitos_por_painel`, `dispositivos_por_painel` e `aplicacoes_por_revisao`
(`Circuitos4F`, `Dispositivos4F`, `Aplicacao4F`). A visão de painel da UI mostra
circuitos e dispositivos ao lado da fiação e da interligação — o laço
"quem desenha, grava; o app lê" fecha sem uma ponte nova.

Todas são **leitura** das tabelas derivadas (decisão 2) e leitura/escrita das
tabelas do app (decisão 5). Erros: `db_not_open` (nenhum projeto aberto) e
`db_error` (arquivo/SQL), além dos códigos já definidos em `PROTOCOL.md`.

### Plugin ZWCAD (comandos NETLOAD)

O comando de entrada é o `NETLOAD` do ZWCAD, que carrega a DLL e chama
`IExtensionApplication.Initialize()`. A partir daí os comandos (atributos
`[CommandMethod]`, no padrão do original) são digitados na linha de comando. O
recorte mínimo:

| Comando | O que faz |
|---|---|
| `ELET` | mensagem de entrada / valida o desenho (tipo `"E"`) |
| `FIA` | projeta a fiação do desenho para `Fiacao` (equivalente a `frmCompilarFiacao`) |
| `INT` | projeta a interligação do desenho para `Interligacao4` (equivalente a `frmCompilarInterligacao`) |
| `SYNCD` | projeta XData → tabelas do banco (o "quem desenha, grava") |
| `VERIF` | valida o projeto (espelho de `frmVerificadorProjetoFiacao`) |
| `JMP` | projeta os jumpers do desenho para `Jumper4` (o `frmCompilarJumperExt`) |

Implementados: `ELET`, `FIA`, `INT`, `SYNCD` e `VERIF` (sem tela ainda — ver
`cad-plugin/README.md`). O `SYNCD` é a projeção em lote (fiação + interligação); o
`VERIF` valida as tabelas **gravadas** e o **desenho** — read-only, cobre a fiação, a interligação
e os modelos (`Portas4F`/`Bornes4F`/`Contatos4F`).

Os nomes vêm do `COMANDOS.txt` do reverso — evitamos inventar comandos novos para
o usuário não reaprender.

## 5. Estrutura proposta

O plugin é um **build separado** — não é Rust, não é TS, não compila no
`npm run build:desktop`. Ele tem projeto e build próprios (`npm run plugin:build`):

```text
positron/
├─ apps/web/                    # UI do app (React/TS)
├─ apps/desktop/src-tauri/      # shell + bridge (Rust)
├─ services/sidecar/            # DONO do banco (Python)
│  └─ src/sidecar/db/
│     ├─ schema.sql             # FONTE DA VERDADE do contrato de dados
│     └─ project.py             # leitura do SQLite (WAL + to_thread)
├─ packages/protocol/           # contrato compartilhado (gerado)
│  ├─ src/schema.generated.ts   # tipos TS das tabelas (frontend APP)
│  └─ csharp/Tables.g.cs        # tipos C# das tabelas (frontend ZWCAD)
├─ scripts/gen-schema.mjs       # gera os dois a partir do schema.sql
├─ cad-plugin/                  # frontend CAD: ZWCAD + AutoCAD (C# net472)
│  ├─ Positron.Contract/        # compila os tipos gerados
│  ├─ Positron.Data/            # acesso SQLite (System.Data.SQLite)
│  ├─ Positron.Plugin/          # IExtensionApplication + comandos (ZWCAD/AutoCAD)
│  └─ Positron.CadStub/         # stub de compilação neutro (sem CAD instalado)
└─ docs/POSITRON.md             # este documento
```

O plugin mora **dentro** do repo (não como projeto irmão): assim a referência ao
contrato gerado é local e o build entra no CI. A UI do plugin é WinForms e chega
junto com o fluxo de fiação (fase 5); o scaffold já tem `ELET` registrado.

### O contrato do schema precisa de uma única fonte

Este é o ponto frágil: TS, Python e C# não compartilham tipos. A fonte é o
**`schema.sql`** — o DDL extraído do banco modelo. `scripts/gen-schema.mjs` o
parseia e gera os dois espelhos: `schema.generated.ts` (TS) e `csharp/Tables.g.cs`
(C#, namespace `Positron.Contract`). Mesmo princípio do `protocol:gen`:
**divergiu, o build falha.**

```bash
npm run schema:sync    # regrava os tipos gerados a partir do schema.sql
npm run protocol:gen   # gate: falha se os tipos gerados estiverem velhos
```

## 6. Fases

| Fase | Entrega | Critério de pronto | Status |
|---|---|---|---|
| 0 | Este documento | decisões revisadas | feito |
| 1 | Schema + gerador de contrato | `protocol:gen` falha se os tipos gerados divergirem | feito |
| 2 | Sidecar lê SQLite (métodos do §4) | `projeto_listar_paineis` responde do `.db` real | feito |
| 3 | UI do app lista painéis/veias/fiação | navegável, typecheck limpo | feito |
| 4 | Plugin compila e registra comandos | `ELET` e `SYNCD` rodando dentro do ZWCAD | **feito** |
| 5 | Fiação: XData → `Fiacao` | fios no desenho aparecem no app | **feito** |
| 6 | Interligação: XData → `Interligacao4` | trecho de cabo fecha ponta a ponta | **feito** |
| 7 | Bornes/terminais: desenho → colunas deferidas | terminal/régua da fiação vêm do desenho | **feito** |
| 8 | Modelos de régua/máscara → `Portas4F` e `Bornes4F` | portas e bornes gerados dos modelos do desenho | **feito** |
| 9 | Modelos de contato → `Contatos4F` | contatos e auxiliares gerados dos modelos do desenho | **feito** |

Cada fase é verificável sozinha. As fases 2 e 4 não dependem uma da outra — só a
5 fecha o laço entre os dois frontends.

> **Mapa vigente:** o acompanhamento por etapa (com o que foi implementado,
> verificado e commitado em cada rodada) está no `PLANO.md` — etapas 0 a 12. A tabela
> acima é o recorte original do projeto; o texto que segue é o registro de como cada
> fase foi fechada, com os detalhes que continuam valendo.
>
> **Verificação atual (rodada 32):** além dos testes de unidade (**194** xunit + **27**
> no sidecar), o recorte foi conferido contra o **banco do produto** (`RCD.mdb`) no
> mesmo desenho (`Funcional.dwg` = DWG 63): `Fiacao` 494, `Portas4F` 265,
> `Dispositivos4F` 83, `Aplicacao4F` 15, `Circuitos4F` 11 e `Contatos4F` 70 batem
> **exatamente**; `Cabos4`/`Veias4` batem **hash a hash** com o catálogo do produto
> (697/2.388); a única diferença restante (`Bornes4F` 168 × 155) vem de a cópia local
> do desenho não ser a que o produto compilou. Idempotência e isolamento por desenho
> estão provados por **conteúdo**. Receitas no `RUNBOOK.md`.

A fase 4 está **fechada** (o texto abaixo é o registro de como fechou). Na época: o scaffold compila (0 avisos) e registra os comandos
(`ELET`, `FIA`, `INT`, `SYNCD`, `VERIF`). O **ZWCAD 2026 está instalado** nesta
máquina (`C:\Program Files\ZWSOFT\ZWCAD 2026`, com `ZwManaged.dll`/
`ZwDatabaseMgd.dll` 26.0.26.0 em .NET Framework e o símbolo `cmd_netload`), então
`npm run plugin:build` resolve o `ZWCadDir` sozinho e gera
`Positron.Plugin.ZWCAD.dll` contra a API **real** `ZwSoft.ZwCAD.*` — não é mais o
stub. A fase **fechou**: `npm run cad:smoke` carrega a DLL por `NETLOAD` no ZWCAD
2026 e roda `ELET`/`FIA`/`INT`/`SYNCD`/`VERIF` num `Drawing1` vazio — o
`POSITRON_LOG` traz `Positron carregado.` e as respostas de cada comando. Dois
detalhes do harness que custaram tempo e ficaram documentados no `RUNBOOK.md`: o
`/b` do ZWCAD espera o caminho **sem** a extensão `.scr`, e o `-Db` do script
colide com o alias de `-Debug` (é `-Banco`).

Os alvos **AutoCAD** continuam buildando contra o stub nesta máquina: o
`AutoCAD 2020` usado nos ensaios originais **não está instalado aqui** (há
2010/2011/2013 e o DWG TrueView 2027). Os ensaios de `FIA`/`INT` no
`accoreconsole` 2020 foram feitos pelo dono do projeto e **deram positivo** — o
`INT` gravou `Interligacao4` de verdade e o `FIA` gravou `Fiacao`/`Bornes4F` —
e ficam registrados no `RUNBOOK.md` como evidência histórica. Atenção: o
`csproj` procura 2026/2025/2024; numa máquina com 2020 o caminho precisa ser
passado à mão, e AutoCAD 2025+/TrueView 2027 (API .NET 8/10) **não** carregam um
plugin net472.

A fase 5 está **fechada** (registro da época: *parcial*). Já existem e são testados: o comando `FIA`, o
leitor do XData `CONEXAO`, a projeção para `Fiacao` (INSERT canônico) e a leitura
no app (o sidecar lê o `.db` que o projetor .NET gravou). As colunas que dependem
do desenho (`Tag`, `Terminal`, `Tipo`, `TipoBorne`, `IndexModelo`, `Alternativo`,
`Handle`, `NRegua`, `PosicaoNum`, `BLink`) são preenchidas pela varredura de
**bornes/terminais** da fase 7. A `Pagina` vem do **layer** da conexão: o
`AdicionaItemPotencial` grava `pot.layer` nessa coluna, e o `frmCompilarFiacao`
monta esse valor a partir do layer pelo switch `Conf.incluirColuna` (`0..2` =
código cru, `3..5` = `Pagina.BuscaAlternativo`, `6` = `(layer)` + separador +
cruzamento). A coluna é montada pelo switch em `ColunaPagina` — o mesmo caminho do `Bornes4F`, do `Dispositivos4F`, do `Interligacao4` e do
`Bornes4I`; as variantes usam a **matriz de páginas** do desenho (`PaginaMatrix`/`PaginasDoDesenho`, montada da `LayerTable`) e a configuração por ambiente (`POSITRON_INCLUIR_COLUNA`, `POSITRON_SEPARADOR_CRUZAMENTO`) enquanto não há tela. O casamento ponto↔borne já usa as **duas etapas
do original**: o filtro de **bounds ±0,25** e a **tabela de pontos de ligação por
nome de bloco** (`mknUzyUVsW`) — o ponto de referência é `inserção + deslocamento`,
não o pé de inserção. A `Ordem` segue a **chave do original** — `Potencial`,
`PosicaoNum` decrescente (bornes primeiro), `dOrdem`, `TerminalNum`, `Terminal` —
e o comando roda o `ReordenaOrdemPotenciais` (renumera `Ordem` 1..N por potencial).
O ponto que **não** casa com um borne ganha a `tag` da **varredura de
dispositivos**: o `DispositivosDeFiacaoDoDesenho` varre os blocos de dispositivo do
ModelSpace (XData `DISPOSITIVO`/`Dispositivo` tipos `P`/`E`/`A` e `IMPORTADO` tipo
`I`) e o `CasamentoDispositivo` liga o ponto ao mais próximo com as mesmas duas
etapas dos bornes (bounds ±0,25 + tabela de deslocamento), exigindo
`painel == painel do ponto` e `painel > 0`. O `E`/`A` tem o painel lido do bloco
da máscara. Com a `tag`, o `dOrdem` do **não-borne** passa a ser a ordem da tabela
`mPosicao` (dicionário `CENG_LAYOUT`). O `I`/`M` são pulados no original; aqui o
`I` entra a pedido do projeto (`M` nunca — é máscara). O casamento reproduz também
a segunda checagem do `ltZUHdAX7R`: o bloco só é aceito se tirar um terminal
**não-vazio** do atributo `T*` (ou `B*`, no `E`) mais próximo do ponto — o adapter
lê os atributos do bloco e o núcleo exige o terminal, que vira `Terminal`/
`TerminalNum` do ponto. O `FIA` rodou dentro do AutoCAD 2020 (ver `RUNBOOK.md`):
num desenho com 4 conexões e 2 bornes, gravou 3 linhas em `Fiacao` — a conexão de
`Potencial == 0` foi descartada, como no original. O caminho do **dispositivo**
não foi exercitado (o desenho não tinha blocos de dispositivo).

A projeção é **idempotente**: `ProjectStore` apaga `(DWG, Revisão)` na mesma
transação do INSERT (`Fiacao`, `Interligacao4`, `Portas4F`, `Bornes4F`,
`Contatos4F`) — o `RemoveRevisaoTabelaParaDWG` do original, que o reverso tem mas
não chamava. Rodar `FIA`/`INT` duas vezes no mesmo `.db` deixa o mesmo resultado,
e a `Ordem` não é mais reembaralhada (`IdempotenciaTests`).

A fase 6 está **fechada** pelo mesmo caminho da 5 (registro da época: *parcial*). Já existem e são
testados: o comando `INT`, o leitor do XData `INTERLIGACAO`, a mesclagem das
pontas por `(Tag_Cabo, Num_Veia)` (o `ssqypmV1FI`/`yHoU3hlYPo` do original), a
**varredura de bornes/terminais das duas pontas** (a mesma da fase 7, aplicada ao
`Interligacao4` — o `pf6UXj3X1f` do original) e a projeção para `Interligacao4` —
verificado ponta a ponta (o projetor .NET grava e o sidecar lê
`interligacao_por_cabo`/`interligacao_por_painel`). A varredura preenche `Tag`,
`Alternativo`, `Terminal`, `TerminalNum`, `TipoBorne`, `Handle` e `IndexModelo` de
cada ponta, e carimba `DWG1`/`DWG2` (o DWG ativo) e `Documento1`/`Documento2` (o
`Conf.Local`, hoje via `POSITRON_LOCAL`); `Posicao1`/`Posicao2` saem vazias, como
no original. Sem borne casado, `DWG`/`Documento` saem nulos — o original grava
`0`/`""`; dado ausente é melhor que dado inventado. A criação de linha segue o
original tipo a tipo: o `Tipo == 1` (duas pontas) e o `Tipo == 3` (só a ponta de
destino) **sempre** anexam uma linha nova; só o `Tipo == 2` mescla pela chave,
comparando o cabo ignorando caixa (o `yHoU3hlYPo`). Tudo isso foi conferido
**dentro do AutoCAD 2020** (ver `RUNBOOK.md`): num desenho com duas polylines
de `CABO1`, uma de `CABO2` (`Tipo == 3`) e uma de `CABO3` (`Tipo == 1`), mais
dois blocos de borne, o `INT` gravou 3 linhas — a do `CABO1` com as duas pontas
mescladas (cada uma casada com o seu borne: `Terminal`/`Handle`/`DWG1`/
`Documento1` preenchidos) e as outras duas com a ponta que não tem borne nula.

O `INT` também regrava **`Cabos4`/`Veias4`** como **snapshot do catálogo**
(`Cabos`/`Veias`) carimbado com a revisão — o `RUIU5Sbjhj`/`v1TU0cEjWd` do
original (que copiam o catálogo, sem derivar do desenho). A regravação apaga as
linhas da revisão antes de inserir, para rodar duas vezes não duplicar.

A fase 7 está **fechada** (registro da época: *parcial*). Já existem e são testados: o leitor do XData de
borne (`Dispositivo` tipo `"B"`), o parser do dicionário de réguas
do desenho (`REGUAS`/`MODELOS2`), o casamento ponto↔borne com as **duas etapas**
do original (bounds ±0,25 + tabela de pontos de ligação por nome de bloco) e a
reordenação de `Ordem` (`ReordenaOrdemPotenciais`), aplicados a `FIA` e `INT`. Com
eles, o `FIA` passa a preencher `Terminal`, `TerminalNum`, `Tipo`, `TipoBorne`,
`IndexModelo`, `Tag`, `Alternativo` e `Handle` — verificado ponta a ponta (o
projetor .NET grava e o sidecar lê). A geração de `Portas4F`/`Bornes4F` que
constava aqui foi feita na fase 8; a varredura de bornes do lado da interligação,
na fase 6. A varredura de bornes **rodou dentro do AutoCAD 2020** pelo `INT` (ver
`RUNBOOK.md`): as duas pontas de um trecho casaram com bornes distintos, cada uma
preenchendo `Terminal`/`Handle`/`IndexModelo` da sua ponta. O `FIA` também rodou
no AutoCAD 2020: o ponto casado com o borne recebeu da régua do dicionário a
`Tag`/`NRegua`, e a renumeração de `Ordem` 1..N por `Potencial` saiu ordenada
(bornes primeiro, `PosicaoNum` decrescente).

A fase 8 está **fechada** (registro da época: *parcial*). Já existem e são testados: o parser dos
**modelos de máscara** e suas **portas** (`MASCARAS`/`MODELOS2` e
`MASCARAS/<índice>`), o parser dos **bornes de reserva**
(`CENG_BORNES/<indexRegua>`), o leitor do XData de **máscara** (tipo `"M"`) e os
**geradores** de `Portas4F` (portas de borne e de terminal) e de `Bornes4F`
(bornes do desenho + reservas), com gravação transacional — verificado ponta a
ponta (gravou-se em `.db` real e leu-se de outro processo). O `FIA` passou a
gerar as duas tabelas, como no original. A numeração de terminal agora reproduz
as formas com `:` e `-` (`TerminalNumerico`). O que **falta**: os **painéis em
uso**, que no original vêm da tela e aqui são derivados das conexões/máscaras do
desenho. O `FIA` já rodou no AutoCAD 2020 e gerou `Bornes4F` (2 linhas, com a
régua e a página resolvidas); `Portas4F` saiu com 0 linhas porque aquele desenho
não tinha modelo de máscara — esse caminho ainda não foi exercitado num CAD.

A fase 9 está **fechada** (registro da época: *parcial*). Já existem e são testados: o parser dos
**modelos de contato** e seus **contatos auxiliares** (`CONTATOS`/`MODELOS2` e
`CONTATOS/<índice>`), o leitor do XData de **dispositivo** (tipo `"P"`), a
varredura dos blocos de dispositivo (com os terminais de bobina vindos dos
atributos `T*`) e o gerador de `Contatos4F` (terminais do dispositivo + bobinas +
auxiliares), com gravação transacional — verificado ponta a ponta. O `FIA` passou
a gerar a tabela. A orientação dos contatos é reprocessada na leitura do dicionário
(`OrientacaoContato.Verificar`, o `VerificaOrientacaoContato` do original). O
`sComportamento` o original lê mas **não** escreve em `Contatos4F`, então não é
projetado aqui tampouco. Ainda não exercitado num CAD: o `FIA` rodou no AutoCAD
2020, mas o desenho não tinha modelo de contato, então `Contatos4F` saiu vazia.

A fase 7 (tabelas) avançou sobre o `Dispositivos4F`: o `FIA` grava **um
dispositivo por bloco** — um por bloco `P` e um por bloco de máscara `M`, como o
`frmCompilarFiacao` (linhas 2640–2793 do reverso), pulando `Complementar` e
painel fora de uso. A `Tag` é `Nome1[/Nome2]`, a `Pagina` é o layer do bloco, o
`BlocoTopografico`/`BlocoLayout` vêm do modelo casado por `IndexModelo` (no `P` o
dicionário de modelos de contato, no `M` o de máscaras) e `PosicaoNum`/`Ordem`
saem do `CENG_LAYOUT` por `(painel, tag)`. Limite assumido: no `P` com
`IndexModelo == 0` o original lê essas duas colunas do XData do bloco e o leitor
atual não expõe esses índices — saem vazias.

O **`Circuitos4F`** também passou a ser projetado pelo `FIA`: o `t6yXrlfi5w` do
original grava um circuito por **potencial**, das conexões `CONEXAO` com
`Tipo == 1` e `Nome` não-vazio, de painel em uso, deduplicando por `Potencial`
(o primeiro vence). Para isso o `PontoFiacao` passou a carregar o `Nome` e o
`Tipo` da conexão (idx 7 e 1 do XData).

O `INT` ganhou as tabelas **intermediárias** do original: `Portas4I` (o
`wrlU180vl0`: portas de **todos** os modelos de máscara do dicionário, sem
filtro de uso) e `Bornes4I` (o `T6NUlT3ghH`: bornes do desenho + reservas das
réguas, **sem** o filtro de painel em uso que o `FIA` aplica). Os geradores
reaproveitam `Portas4FGerador`/`Bornes4FGerador` com o filtro nulo e projetam
o subconjunto de colunas das tabelas I.

## 7. Armadilhas

- **App não lê XData.** Qualquer informação que a UI do app precisa ver **tem**
  que estar no banco. Se sumir da tela, o bug provavelmente é uma projeção
  XData→tabela que não rodou no plugin, não um erro de UI.
- **`NETLOAD` é uma DLL .NET.** O plugin **não pode** ser Electron/React: a API
  de desenho (`ZwManaged` v26) só existe no processo do ZWCAD. UI WebView2 é
  possível, mas continua sendo um assembly .NET referenciando a API — não um
  frontend web solto.
- **Não confunda `Cabos` com `Cabos4`.** Catálogo x instância. Trocar os dois faz
  o plugin achar que todo cabo é novo.
- **Versão da API do ZWCAD.** O reverso usa `ZwManaged` v26 (ZWCAD 2026+). Uma
  DLL compilada contra v26 não roda em versões anteriores — tratar como
  pré-requisito, não como bug.
- **WAL não é opcional.** SQLite em modo `delete` e conexão longa = o app trava o
  plugin no meio de um comando.
- **`Indice/Revisao` fazem parte da chave.** `Revisao` versiona a linha; ignorar
  isso faz uma revisão sobrescrever a anterior.

## 8. Decisões ainda abertas

- **UI do plugin:** WinForms nativo (escolhido) vs hospedar a UI React em
  WebView2. WinForms reduz partes móveis agora; WebView2 reusa componentes.
- **Licenciamento:** o original tem Rockey/ElecKey/Nuvem e **credenciais Azure em
  texto claro**. Não reconstruir isso por acidente. **Encaixe pronto:**
  `Positron.Data.Licenca.ServicoDeLicenca` (com `ILicenca` e o provedor de
  desenvolvimento como padrão) e o gate `BloqueioDeLicenca` no início dos 6 comandos
  — plugar o provedor é uma linha na carga do plugin, sem mexer em comando.
- **Relatórios:** PDF via iTextSharp no original. O `Relatorios*` no app Python
  pode cobrir, mas a decisão não foi tomada.
- **Multi-usuário:** SQLite hoje; SQL Server quando/se necessário (o caminho já
  existe no reverso).

## 9. Retomada (nova sessão)

Se você está começando um contexto novo, isto é o mínimo para continuar sem
reler o repositório inteiro.

**Onde as coisas estão**

- Repo: `C:\Users\rno\Desktop\APPs\positron`.
- Reverso (referência): `C:\Users\rno\Desktop\APPs\Elet\Eletron4_ZWcad` — o código
  descompilado em `decompiled-cleaned/Eletron4/` (435 `.cs`) e `COMANDOS.txt`.
- Projeto real do dono (desenhos + banco do produto): `..\Elet\RCD\`
  (`Funcional.dwg`, `Interligação.dwg`, `Fiação.dwg`, `RCD.mdb`).
- Dono do contrato de dados: `services/sidecar/src/sidecar/db/schema.sql`
  (gera `packages/protocol/...`). Plugin: `cad-plugin/`.
- Frontend CAD em `cad-plugin/Positron.Data/` (núcleo puro, testável sem
  CAD) e `cad-plugin/Positron.Plugin/` (adapters do ZWCAD e AutoCAD).
- **Plano e acompanhamento:** `docs/PLANO.md` (etapas 0–12, com o registro por
  rodada). **Receitas de verificação:** `docs/RUNBOOK.md`.

**Estado (rodada 32):** as etapas 0–12 do `PLANO.md` estão **concluídas**, exceto a
**9** (licenciamento, relatórios e multi-usuário), que é decisão do dono e já tem os
encaixes prontos. Números de hoje: **194** testes xunit + **27** no sidecar, contrato
com **20 métodos** e **31 tabelas** em sincronia, **57** módulos no app, **9** comandos
no CAD. O recorte roda no ZWCAD 2026 sobre o **desenho real** (`Funcional.dwg`):
`FIA` grava 494 linhas em `Fiacao`, 265 em `Portas4F`, 168 em `Bornes4F`, 70 em
`Contatos4F`, 83 em `Dispositivos4F`, 11 em `Circuitos4F` e 15 em `Aplicacao4F`; o
`INT` grava 20 em `Interligacao4`, 265 em `Portas4I` e 216 em `Bornes4I`, mais o
snapshot de catálogo (`Cabos4`/`Veias4`). O `VERIF` aponta **107** problemas, todos
`BorneSemFiacao` (bornes de régua fora de fio, genuínos nesse desenho).

**Verificação que sustenta isso** (tudo no `RUNBOOK.md`):

- **A/B contra o banco do produto** (`..\Elet\RCD\RCD.mdb`, Access, aberto por ODBC
  numa cópia): no mesmo desenho (DWG **63**, revisão 3) `Fiacao` 494, `Portas4F` 265,
  `Dispositivos4F` 83, `Aplicacao4F` 15, `Circuitos4F` 11 e `Contatos4F` 70 batem
  **exatamente** com o que o produto gravou; as **19 tabelas** do recorte batem
  coluna a coluna com o Access; `Cabos4`/`Veias4` batem **hash a hash** com o catálogo
  (697/2.388). A única diferença restante (`Bornes4F` 168 × 155) está explicada: os
  bornes a mais estão na página `1000` e não existem em nenhuma tabela do produto — a
  cópia local do desenho não é a que o produto compilou.
- **Idempotência e isolamento por conteúdo** (`scripts/cad-dump-tabelas.py`): três
  passadas de projeção no mesmo `(DWG, Revisão)` deixam o mesmo resultado, mudando só
  o campo `Data`; rodar outro desenho no mesmo banco deixa o primeiro intacto.
- **Catálogo real:** `scripts/cad-importa-catalogo.ps1` carrega `Cabos`/`Veias`/
  `Materiais` do Access (697/2.388/210) e o app passa a devolver esses dados
  (`cabos4_por_revisao` 697, `catalogo_listar_materiais` 210, …).
- **Harness:** `npm run cad:smoke` (desenho de verdade, com `-Desenho`), `npm run
  cad:e2e` (fixture sintético) e os dois builds de plugin (`plugin:build` ZWCAD e
  `plugin:build:autocad`, contra o stub). Ensaios em **AutoCAD 2020** feitos pelo dono
  ficam como evidência histórica.

**Backlog do que ainda falta** (não é ordem obrigatória):

1. **Etapa 9 — decisões do dono** (`PLANO.md` §9): (a) **licença**, com o encaixe
   `ServicoDeLicenca`/`ILicenca` e o gate nos 6 comandos já prontos, faltando escolher
   o provedor; (b) **relatórios**, hoje só o de verificação em texto (`ELETREL`), com
   a recomendação de começar pelos 4 tabulares no app; (c) **banco**, SQLite hoje,
   SQL Server quando/quando — o SQL está isolado no `ProjectStore`.
2. **`VERIF` no desenho (parcial):** as telas originais
   (`frmVerificadorProjetoFiacao`/`frmVerificadorProjetoInterligacao`, ~3 mil
   linhas) também pintam erros lidos do **desenho**. O `VERIF` já valida as
   tabelas gravadas **e** três regras do desenho — o borne cuja régua não resolve
   no dicionário, o cabo referenciado que não existe no catálogo e a **página
   gravada que não está na `LayerTable`**
   (`VerificarBornesSemRegua`/`VerificarCabosSemCatalogo`/`VerificarPaginasAusentes`,
   área `Desenho`).
   Falta o que depende de **geometria**. A **matriz de páginas** já é lida do
   desenho (`PaginaMatrix`/`PaginasDoDesenho`, montada da `LayerTable` como o
   `Pagina.CarregaPaginas`) e alimenta a regra de **página ausente**
   (`VerificarPaginasAusentes`) e a coluna `Pagina` (`ColunaPagina`, o switch
   `Conf.incluirColuna` 0..6, configurado por `POSITRON_INCLUIR_COLUNA`).
3. **Tabelas do contrato §3 ainda não projetadas:** o plugin grava `Fiacao`,
   `Interligacao4`, `Portas4F`, `Bornes4F`, `Contatos4F`, `Dispositivos4F`,
   `Circuitos4F`, `Aplicacao4F`, `Portas4I`, `Bornes4I`, `Jumper4`, `Cabos4` e
   `Veias4`. Ficam por cobrir `Aranha4`, `Atributos` e `Exportados` (aranha,
   atributos de bloco e projeção cross-DWG). O `Jumper4` tem o seu próprio comando
   (`JMP`), porque **não** vem do `FIA`: o `frmCompilarJumperExt` monta um ponto por
   ponta da conexão (`Tipo == 4` com `Disp1`/`Disp2`, e `Tipo == 3` com
   `Jumper == "JUMPER"`) e usa a mesma máquina de casamento do `FIA`, só trocando a
   tabela. Os três restantes vêm de telas de relatório e de importação/exportação —
   a receita de cada um está no `PLANO.md`.
4. **Pendências menores:** `ModelosCabos` está vazia no Access do projeto (nada a
   importar); os ensaios de `FIA`/`INT` no AutoCAD 2020 seguem no `RUNBOOK.md` como
   evidência histórica; o detalhe de cada tabela fora do recorte está no `PLANO.md`.

**Convenções que não podem ser esquecidas**

- Nomes de método no protocolo são **`snake_case`** (`scripts/gen-protocol.mjs`
  rejeita ponto).
- Os tipos gerados (`schema.generated.ts`, `csharp/Tables.g.cs`) são **gerados** —
  rode `npm run schema:sync`, nunca edite à mão.
- C# do plugin é **net472 / C# 7.3 / `Nullable disable`**, com
  `TreatWarningsAsErrors`. Classes geradas levam sufixo `Row`.
- Regra de ouro: **quem desenha, grava** — o plugin escreve as tabelas derivadas;
  o app só lê.

**Como verificar (tudo tem que dar exit 0)**

```bash
npm run plugin:build      # C# do plugin compila (0 avisos)
npm run plugin:test       # xunit, net472 (hoje 194 testes)
npm run protocol:gen      # contrato Python↔TS e tipos do schema em sincronia
npm run typecheck
npm run build             # web
npm run test:sidecar
uv run --directory services/sidecar ruff check .
```

**E2E plugin→sidecar (sem ZWCAD).** O plugin não roda, mas o núcleo puro é
exercitado contra um `.db` real: defina `POSITRON_TEST_DB` com um caminho Windows
e rode um teste de gravação; depois leia com o sidecar (ou `sqlite3`). Ex.:

```bash
DB="C:/Users/RNO/AppData/Local/Temp/positron-e2e.db"; rm -f "$DB"*
POSITRON_TEST_DB="$DB" dotnet test cad-plugin/Positron.Data.Tests/Positron.Data.Tests.csproj \
  --filter "FullyQualifiedName~Grava_no_banco_e_le_de_volta"
uv run --directory services/sidecar python -c "import asyncio,sys; ..."
```

(Use caminho **Windows** para `POSITRON_TEST_DB`: o `/tmp` do Git Bash não é o
mesmo do Python nativo.)

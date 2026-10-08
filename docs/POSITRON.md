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

O tipo de cada linha (`Paineis`, `Fiacao`, …) vem de `schema.generated.ts`, não de
modelos escritos à mão. `relatorio_gerar` fica para a fase de relatórios.

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

Implementados: `ELET`, `FIA` e `INT` (sem tela ainda — ver
`zwcad-plugin/README.md`). `SYNCD` e `VERIF` ficam para depois.

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
├─ zwcad-plugin/                # frontend ZWCAD (C# net472)
│  ├─ Positron.Contract/        # compila os tipos gerados
│  ├─ Positron.Data/            # acesso SQLite (System.Data.SQLite)
│  ├─ Positron.Plugin/          # IExtensionApplication + comandos
│  └─ Positron.ZwcadStub/       # stub de compilação (sem ZWCAD)
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
| 4 | Plugin compila e registra comandos | `ELET` e `SYNCD` rodando dentro do ZWCAD | parcial |
| 5 | Fiação: XData → `Fiacao` | fios no desenho aparecem no app | parcial |
| 6 | Interligação: XData → `Interligacao4` | trecho de cabo fecha ponta a ponta | parcial |
| 7 | Bornes/terminais: desenho → colunas deferidas | terminal/régua da fiação vêm do desenho | parcial |
| 8 | Modelos de régua/máscara → `Portas4F` e `Bornes4F` | portas e bornes gerados dos modelos do desenho | parcial |
| 9 | Modelos de contato → `Contatos4F` | contatos e auxiliares gerados dos modelos do desenho | parcial |

Cada fase é verificável sozinha. As fases 2 e 4 não dependem uma da outra — só a
5 fecha o laço entre os dois frontends.

A fase 4 está **parcial**: o scaffold compila (0 avisos) e registra o `ELET`, mas
(a) não foi carregado dentro do ZWCAD — ele não está instalado nesta máquina,
então não há `ZwManaged.dll` — e (b) o `SYNCD` ainda não existe. Neste ambiente o
plugin builda contra o stub (`Positron.ZwcadStub`), que é só gate de compilação e
**não** produz um assembly carregável por NETLOAD.

A fase 5 também está **parcial**. Já existem e são testados: o comando `FIA`, o
leitor do XData `CONEXAO`, a projeção para `Fiacao` (INSERT canônico, `Ordem`
reiniciando por potencial) e a leitura no app (o sidecar lê o `.db` que o
projetor .NET gravou). As colunas que dependem do desenho (`Tag`, `Terminal`, `Tipo`,
`TipoBorne`, `IndexModelo`, `Alternativo`, `Handle`) passaram a ser preenchidas
pela varredura de **bornes/terminais** da fase 7; o que ainda sai vazio é
`NRegua` e `PosicaoNum`/`BLink` (dependem dos modelos de régua e da passada de
reordenação). E, como o ZWCAD não está instalado, o `FIA` ainda não rodou dentro
do desenho.

A fase 6 também está **parcial**, pelo mesmo motivo da 5. Já existem e são
testados: o comando `INT`, o leitor do XData `INTERLIGACAO`, a mesclagem das
pontas por `(Tag_Cabo, Num_Veia)` (o `ssqypmV1FI`/`yHoU3hlYPo` do original) e a
projeção para `Interligacao4` — verificado ponta a ponta (o projetor .NET grava e
o sidecar lê `interligacao_por_cabo`/`interligacao_por_painel`). O que **falta** é
a varredura de **bornes/terminais**, que preenche `Tag`, `Alternativo`, `NRegua`,
`Terminal`, `TerminalNum`, `TipoBorne`, `Handle`, `Posicao`, `IndexModelo` e
`Documento` das duas pontas — essas colunas saem vazias, de propósito. Também
ficou aproximada a semântica fina do `Tipo == 3` (o original anexa uma linha só
de destino, em vez de mesclar); como o ZWCAD não está instalado, isso não pôde ser
conferido no desenho.

A fase 7 também está **parcial**. Já existem e são testados: o leitor do XData de
borne (`Dispositivo` tipo `"B"`), o parser do dicionário de réguas
do desenho (`REGUAS`/`MODELOS2`) e o casamento ponto↔borne por proximidade
(o `ltZUHdAX7R` do original, tolerância 0,5). Com eles, o `FIA` passa a preencher
`Terminal`, `TerminalNum`, `Tipo`, `TipoBorne`, `IndexModelo`, `Tag`,
`Alternativo` e `Handle` — verificado ponta a ponta (o projetor .NET grava e o
sidecar lê). O que **falta**: a passada de reordenação de `Ordem`, o casamento
pelas **bounds** do bloco (o original usa `Bounds ±0,25`, que exige a geometria do
bloco e a tabela de deslocamento por nome de bloco), e a varredura de bornes do
lado da **interligação**. A geração de `Portas4F`/`Bornes4F` que constava aqui foi
feita na fase 8. O ZWCAD não está instalado, então nada disso rodou dentro do
desenho.

A fase 8 também está **parcial**. Já existem e são testados: o parser dos
**modelos de máscara** e suas **portas** (`MASCARAS`/`MODELOS2` e
`MASCARAS/<índice>`), o parser dos **bornes de reserva**
(`CENG_BORNES/<indexRegua>`), o leitor do XData de **máscara** (tipo `"M"`) e os
**geradores** de `Portas4F` (portas de borne e de terminal) e de `Bornes4F`
(bornes do desenho + reservas), com gravação transacional — verificado ponta a
ponta (gravou-se em `.db` real e leu-se de outro processo). O `FIA` passou a
gerar as duas tabelas, como no original. O que **falta**: a numeração do terminal
não reproduz as formas com `:` e `-` (caem no indefinido), e os **painéis em uso**
que no original vêm da tela aqui são derivados das conexões/máscaras do desenho.
Como o ZWCAD não está instalado, nada disso rodou dentro do desenho.

A fase 9 também está **parcial**. Já existem e são testados: o parser dos
**modelos de contato** e seus **contatos auxiliares** (`CONTATOS`/`MODELOS2` e
`CONTATOS/<índice>`), o leitor do XData de **dispositivo** (tipo `"P"`), a
varredura dos blocos de dispositivo (com os terminais de bobina vindos dos
atributos `T*`) e o gerador de `Contatos4F` (terminais do dispositivo + bobinas +
auxiliares), com gravação transacional — verificado ponta a ponta. O `FIA` passou
a gerar a tabela. O que **falta**: reprocessar a orientação dos contatos
(`VerificaOrientacaoContato`) e o `sComportamento` (que o original lê mas não
escreve em `Contatos4F`). Como o ZWCAD não está instalado, nada disso rodou
dentro do desenho.

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
  texto claro**. Não reconstruir isso por acidente — decidir o modelo antes da
  fase 4.
- **Relatórios:** PDF via iTextSharp no original. O `Relatorios*` no app Python
  pode cobrir, mas a decisão não foi tomada.
- **Multi-usuário:** SQLite hoje; SQL Server quando/se necessário (o caminho já
  existe no reverso).

## 9. Retomada (nova sessão)

Se você está começando um contexto novo, isto é o mínimo para continuar sem
reler o repositório inteiro.

**Onde as coisas estão**

- Repo: `C:\Users\RNO\Desktop\APP\positron`.
- Reverso (referência): `C:\Users\RNO\Desktop\APP\Elet\Eletron4_ZWcad` — o código
  descompilado em `decompiled-cleaned/Eletron4/` (435 `.cs`) e `COMANDOS.txt`.
- Dono do contrato de dados: `services/sidecar/src/sidecar/db/schema.sql`
  (gera `packages/protocol/...`). Plugin: `zwcad-plugin/`.
- Frontend ZWCAD em `zwcad-plugin/Positron.Data/` (núcleo puro, testável sem
  ZWCAD) e `zwcad-plugin/Positron.Plugin/` (adapters do ZWCAD).

**Estado:** fases 0–3 **feitas**; fases 4–9 **parciais** (a tabela do §6 diz o
que falta em cada uma). Nenhuma delas rodou dentro do ZWCAD — ele não está
instalado.

**Backlog do que ainda falta** (não é ordem obrigatória):

1. **Interligação — bornes/terminais** das duas pontas (mesma varredura da fase 7,
   aplicada ao `Interligacao4`).
2. **`Cabos4` e `Veias4`** a partir do diagrama (`wrlU180vl0`/`RUIU5Sbjhj` no
   reverso).
3. **Reordenação de `Ordem`** da `Fiacao` (`ReordenaOrdemPotenciais`), que fecha
   `PosicaoNum`/`BLink`.
4. **Casamento por bounds** do bloco no lugar da distância de inserção
   (`Bounds ±0,25` + tabela de deslocamento por nome de bloco).
5. **`TerminalNumerico`** com as formas `:` e `-` (`VerificaOrientacaoContato`
   também, para os contatos).
6. **`SYNCD` e `VERIF`** — comandos restantes do recorte do plugin.
7. **UI WinForms** do plugin (as telas `frmCompilar*`), hoje substituídas por
   comandos que leem variáveis de ambiente.
8. Decisões abertas do §8 (licenciamento, relatórios, multi-usuário).

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
npm run plugin:test       # xunit, net472 (hoje 46 testes)
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
POSITRON_TEST_DB="$DB" dotnet test zwcad-plugin/Positron.Data.Tests/Positron.Data.Tests.csproj \
  --filter "FullyQualifiedName~Grava_no_banco_e_le_de_volta"
uv run --directory services/sidecar python -c "import asyncio,sys; ..."
```

(Use caminho **Windows** para `POSITRON_TEST_DB`: o `/tmp` do Git Bash não é o
mesmo do Python nativo.)

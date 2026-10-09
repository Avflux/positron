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

**Com o ZWCAD instalado** (gera a DLL carregável de verdade `Positron.Plugin.ZWCAD.dll`):

```bash
dotnet build Positron.Plugin/Positron.Plugin.csproj -p:CadPlatform=ZWCAD -p:ZWCadDir="C:\Program Files\ZWSOFT\ZWCAD 2026"
# ou via npm:
npm run plugin:build:zwcad
```

**Sem o ZWCAD** (gate de compilação):

```bash
dotnet build Positron.Plugin/Positron.Plugin.csproj -p:CadPlatform=ZWCAD
```

Nesse caso o `Positron.Plugin` compila contra o **stub** (`Positron.CadStub`),
que reproduz a fatia mínima da API. Serve para o build não quebrar em máquinas sem CAD e para o CI ter um gate.

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
| `VERIF` | **implementado** — valida a fiação gravada (`Fiacao`) |

### Fluxo de fiação (`FIA`)

Lê as `LWPOLYLINE` do ModelSpace com XData **`CONEXAO`** (layout recuperado em
`Positron.Data/Fiacao/ConexaoXData.cs`) e grava em `Fiacao` pelo INSERT canônico
do original. Configuração por variável de ambiente:

| Variável | Papel |
|---|---|
| `POSITRON_DB_PATH` | caminho do `.db` do projeto (obrigatória) |
| `POSITRON_DWG` | índice do desenho (`DWG`), padrão `0` |
| `POSITRON_REVISAO` | revisão da linha (`Revisao`), padrão vazio |

**Bornes/terminais (fase 7).** O `FIA` varre os blocos de borne do desenho
(XData `Dispositivo` tipo `"B"`) e as réguas do dicionário
(`REGUAS`/`MODELOS2`), e casa cada ponto de fiação ao borne mais próximo
(`Positron.Data/Bornes/`). Isso preenche `Terminal`, `TerminalNum`, `Tipo`,
`TipoBorne`, `IndexModelo`, `Tag`, `Alternativo` e `Handle`.

**Modelos (fases 8 e 9).** O `FIA` também gera **`Portas4F`**, **`Bornes4F`** e
**`Contatos4F`** a partir dos modelos do desenho: as portas vêm de
`MASCARAS`/`MODELOS2` (modelos de máscara) e `MASCARAS/<índice>` (portas); os
bornes de reserva de `CENG_BORNES/<indexRegua>`; e os contatos de
`CONTATOS`/`MODELOS2` e `CONTATOS/<índice>`, mais os terminais de bobina (atributos
`T*` dos blocos de dispositivo). Os geradores são puros
(`Positron.Data/Modelos/`). Réquas, bornes, máscaras e dispositivos também são
procurados no desenho; os painéis em uso, que no original vêm da tela, aqui saem
das conexões/máscaras/dispositivos presentes.

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
depende da entidade e fica como próximo passo; o núcleo valida a geometria.

### Fluxo de interligação (`INT`)

Lê as `LWPOLYLINE` do ModelSpace com XData **`INTERLIGACAO`** (layout recuperado
em `Positron.Data/Interligacao/InterligacaoXData.cs`), mescla as pontas por
`(Tag_Cabo, Num_Veia)` e grava em `Interligacao4` pelo INSERT canônico do
original. Usa as mesmas variáveis de ambiente do `FIA` (`POSITRON_DB_PATH`,
`POSITRON_DWG`, `POSITRON_REVISAO`).

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

**O que ainda sai vazio:** `Documento`/`Posicao`/`DWG1`/`DWG2` (configuração e
por-ponta, não projetadas). Ficam nulas de propósito. A semântica fina do
`Tipo == 3` também ficou aproximada (ver `../docs/POSITRON.md`).

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

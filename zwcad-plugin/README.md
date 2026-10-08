# Positron — plugin ZWCAD

Frontend ZWCAD do Positron: um assembly **.NET Framework 4.7.2 (x64)** carregado
no ZWCAD por **`NETLOAD`**. Ele constrói a **fiação e a interligação do diagrama
funcional** e é o único que escreve as tabelas derivadas do diagrama no `.db` do
projeto. O contexto todo está em `../docs/POSITRON.md`.

```text
Positron.Contract/   tipos do schema gerado (namespace Positron.Contract)
Positron.Data/       acesso ao SQLite do projeto (System.Data.SQLite)
Positron.Plugin/     IExtensionApplication + comandos ([CommandMethod])
Positron.ZwcadStub/  stub de compilação — só quando não há ZWCAD (ver abaixo)
```

## Por que não é Electron/React

A API de desenho (`ZwSoft.ZwCAD.*`, `ZwManaged.dll` v26) só existe **dentro do
processo do ZWCAD**. `NETLOAD` carrega um assembly .NET que a referencia — não há
como um frontend web tocar entidades ou XData.

## Build

O contrato é gerado no repositório principal — rode antes:

```bash
npm run schema:sync      # regrava packages/protocol/csharp/Tables.g.cs
```

**Com o ZWCAD instalado** (gera a DLL carregável de verdade):

```bash
dotnet build Positron.Plugin/Positron.Plugin.csproj -p:ZWCadDir="C:\Program Files\ZWSOFT\ZWCAD 2026"
```

**Sem o ZWCAD** (gate de compilação):

```bash
dotnet build Positron.Plugin/Positron.Plugin.csproj
```

Nesse caso o `Positron.Plugin` compila contra o **stub** (`Positron.ZwcadStub`),
que reproduz a fatia mínima da API copiada dos `using` do código reverso. O
stub **não é a API do ZWCAD** e o assembly resultante **não carrega por
NETLOAD** — ele referencia o stub, que não existe dentro do ZWCAD. Serve só para
o build não quebrar em máquina sem ZWCAD e para o CI ter um gate.

## Comandos

Digitados na linha de comando do ZWCAD depois do `NETLOAD`:

| Comando | Estado |
|---|---|
| `ELET` | **implementado** — mensagem de entrada do plugin |
| `FIA` | **implementado** — projeta a fiação do desenho para `Fiacao` |
| `INT` | **implementado** — projeta a interligação do desenho para `Interligacao4` |
| `SYNCD`, `VERIF` | ainda não (ver `../docs/POSITRON.md`) |

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

**O que ainda sai vazio:** `NRegua` e `PosicaoNum`/`BLink` (dependem da passada de
reordenação, ainda não implementada). A projeção deixa essas colunas nulas de
propósito — dado ausente é melhor que dado inventado.

### Fluxo de interligação (`INT`)

Lê as `LWPOLYLINE` do ModelSpace com XData **`INTERLIGACAO`** (layout recuperado
em `Positron.Data/Interligacao/InterligacaoXData.cs`), mescla as pontas por
`(Tag_Cabo, Num_Veia)` e grava em `Interligacao4` pelo INSERT canônico do
original. Usa as mesmas variáveis de ambiente do `FIA` (`POSITRON_DB_PATH`,
`POSITRON_DWG`, `POSITRON_REVISAO`).

**O que ainda sai vazio:** `Tag`, `Alternativo`, `NRegua`, `Terminal`,
`TerminalNum`, `TipoBorne`, `Handle`, `Posicao`, `IndexModelo` e `Documento` das
duas pontas vêm da varredura de **bornes/terminais**, que ainda não foi
implementada. Ficam nulas de propósito. A semântica fina do `Tipo == 3` também
ficou aproximada (ver `../docs/POSITRON.md`).

O leitor e o projetor são puros (não dependem do ZWCAD) e têm teste real contra
um SQLite montado do `schema.sql`:

```bash
npm run plugin:test      # xunit, net472
```

## Pré-requisitos

- **.NET Framework 4.7.2** e um SDK do .NET para o `dotnet build` (o pacote
  `Microsoft.NETFramework.ReferenceAssemblies` traz os assemblies de referência
  sem exigir o Visual Studio).
- **ZWCAD 2026+** para gerar/carregar a DLL real (`ZwManaged` v26). Uma build
  contra a v26 não roda em versões anteriores.

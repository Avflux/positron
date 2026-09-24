# Arquitetura — Eletron4Z (plugin ZWCAD)

> **Fonte:** engenharia reversa do assembly `Eletron4Z.dll` (11,7 MB), desobfuscado com **de4dotEx 3.11.0**
> (protetor identificado: **.NET Reactor**), descompilado com **ILSpy 11.1.0**.
> Base de análise: `decompiled-cleaned\` (~99% dos corpos de método restaurados; 33.718 métodos, 72 vazios).

---

## 1. Identidade

| Item | Valor |
|---|---|
| Assembly | `Eletron4Z, Version=4.26.3.0, Culture=neutral, PublicKeyToken=null` |
| Plataforma | .NET Framework **4.7.2** (`net472`), x64, ILONLY |
| Linguagem | **VB.NET** (`Microsoft.VisualBasic`, namespace `Eletron4.My.*`) |
| Tipos | ~416 classes na metadata (357 em `Eletron4.*`) |
| Protetor | **.NET Reactor** (Eziriz) — corpos de método cifrados + strings |
| API CAD | `ZwManaged`, `ZwDatabaseMgd` (v26), `ZdWindows` — ZWCAD 2026+ |
| Outras deps | `System.Data.SQLite`, `itextsharp` (PDF), `KeyLib`, Office Interop (Access DAO/Excel) |
| Domínio | Engenharia elétrica: fiação, cabos, bornes, painéis, interligação, relatórios |

---

## 2. Visão geral das camadas

```text
ZWCAD (Ribbon "CENG.ID_Elet" + linha de comando)
        |
   myEletron : IExtensionApplication        <- ponto de entrada
        |  Initialize()
        +-- licenciamento (Rockey | ElecKey | Nuvem)
        +-- Iniciar.IniciarApp()  -> Ribbon + recursos + splash
        +-- Iniciar.IniciarDWG()  -> ajusta UI conforme o tipo do desenho
        +-- EventosDOC            -> criaDocumento / AtivaDocumento / fechaDocumento
        |
   Comandos (216 x [CommandMethod])          <- fachada FINA: abre tela ou chama cls*
        |
   cls*  (52 classes de regra de negocio)
        |      clsDInterlig, ClsAranha, clsDispositivo, clsPortas, clsInterligacao ...
        |
   cDados* (19)  ->  Acesso* (5 conectores)
        |              Access | SQLite | SQL Server | Excel | Azure (licenca)
   Banco do projeto (.accdb | .db | SQL Server)  +  Azure SQL (licencas)
        |
   XData* (16)  <- dados eletricos embutidos nas entidades do DWG
        |
   Relatorios* (45) -> DWG / Excel / PDF (iTextSharp)
```

---

## 3. Ciclo de inicialização (`myEletron.Initialize`)

1. Exige Ribbon ativo (senão: `"Nenhum Ribbon ativo! / No Ribbon active!"`).
2. Lê idioma em `HKCU\Software\Cadgraph\Eletron4\Idioma` (cria a chave se não existir).
3. Carrega mensagens i18n (`Mensagem.CarregaMensagens`).
4. **Seleciona o modo de licença** (`LicModeSel` / `My.Settings.LicMode`):
   `0` -> `frmCarregaEL`, `1` -> Rockey, `2` -> ElecKey, `4` -> Nuvem.
5. Falhando a licença -> `clsUtilitarios.limpaComandos()`.
6. `Iniciar.IniciarApp()`: cria o Ribbon, grava templates `.dwg` em `%APPDATA%\Cadgraph\Eletron4\`, exibe `frmSplash` (2 s).
7. `Iniciar.IniciarDWG()`: detecta o **tipo do desenho** e mostra/oculta painéis do Ribbon.
8. Assina eventos: `DocumentCreated`, `DocumentActivated`, `DocumentDestroyed`,
   `DocumentLockModeWillChange`, `SystemVariableChanged`.
9. Se em modo Nuvem, inicia um **Timer** que revalida a licença a cada 4-20 s.

`Terminate()` -> `cCheckNuvem.DesregistraNuvemAut()` quando `LicModeSel=4` e `Settings.DesinstalarAut`.

---

## 4. Comandos — 216

**Não ficam todos em um só arquivo.** Distribuição verificada:

| Arquivo | Comandos |
|---|---:|
| `Comandos.cs` | 177 |
| `Correcao.cs` | 24 |
| `clsUtilitarios.cs` | 7 |
| `clsTrocaEditaBlocos.cs` | 5 |
| `clsEletrosul.cs` | 1 |
| `clsEletron.cs` | 1 |
| `clsCloud.cs` | 1 |
| **Total** | **216** |

### Grupos funcionais

| Grupo | Exemplos | O que faz |
|---|---|---|
| Núcleo | `ELET`, `DLOG`, `ETPG`, `ANET`, `EARQ` | entrada principal (ainda ofuscados) |
| Configuração | `CFG`, `RESETLIC`, `LOADAUT`, `UNLOADAUT` | config geral, reset de licença, automação |
| Import/Export | `IMPBD`, `EXPDWG`, `EXPPDF`, `EXPCOMP`, `GERDWG` | projetos, DWG, PDF, Excel |
| Diagramas | `DI*` (`DICEMIG`, `DICHESF`, `DIFURNAS`, `DIENER*`) | diagramas por concessionária |
| Relatórios | `new frmRelatorio*` | 42 chamadas para 30 telas distintas |
| Manutenção | `Corrige*`, `Apaga*`, `APAGARXDATA`, `apagaXDataTerceiros` | reprocessa / limpa XData |

### Mecanismo de bloqueio por licença

`clsUtilitarios.limpaComandos()` percorre todos os `[CommandMethod]` do assembly e executa
`_UNDEFINE <cmd>` para cada um, **exceto `RESETLIC`** — que permanece disponível para o usuário
reconfigurar o modo de licença.

---

## 5. Telas

| Métrica | Valor |
|---|---:|
| `frm*.cs` | 127 |
| `usc*.cs` (UserControl) | 1 |
| Janelas WPF de licença (`wElecKey`, `wHardlock`, `WNuvem`) | 3 |
| Arquivos com `[DesignerGenerated]` | 133 |
| `frmRelatorio*.cs` (telas de relatório) | 38 |
| Classes `Relatorios*` | 45 |

### Destaques

- **Licença:** `frmCarregaEL`, `FormRegNuvem`
- **Configuração:** `frmConfiguracaoGeral`, `frmConfiguracaoBDProjeto`, `frmConfiguracaoLP`
- **Operação:** `frmDispPrincipal`, `frmEditorCabos`, `frmCircuito`, `frmPortas`, `frmPlaquetas`, `frmTopografico`
- **Gerenciadores:** `frmGerenciador{Contatos,Mascaras,Materiais,ReguasBornes,DWG,MatIndep}`
- **Validação:** `frmVerificadorProjetoFiacao`, `frmVerificadorProjetoInterligacao`
- **Ribbon:** `Ribbon.CreateRibbon()` / `CreateRibbon2()` / `RemoveRibbon()`, aba Id `CENG.ID_Elet`

---

## 6. Acesso a banco

Configuração em `DeclaracoesGeral.Conf` (struct `ConfigCaderno`):
`DirProjeto`, `DataSource`, `BancoDeDados`, `User`, `Senha`, `Norma` + diretórios de simbologia
(`DirSimbologiaEletrica`, `dirSimbologiaTopografico`, `dirSimbologiaLayout`, `dirSimbologiaRelatorios`).

`Conf.Banco` seleciona o backend: **`"A"` = Access**, **`"S"` = SQLite**, **`"SV"` = SQL Server**.

| Classe | Provedor | Conexão |
|---|---|---|
| `AcessoAccess` | `System.Data.OleDb` | Microsoft Access |
| `AcessoSQLite` | `System.Data.SQLite` | `DataSource = Conf.DirProjeto` |
| `AcessoSQLServer` | `System.Data.SqlClient` | `DataSource` / `UserID` / `Password` / `InitialCatalog` = `Conf` |
| `AcessoExcel` | OleDb `ACE.OLEDB.12.0` | `ConfLP.listaDePontos` (import/export) |
| `AcessoSQLServerLicenca` | `System.Data.SqlClient` | **Azure SQL hardcoded** (ver seção 8) |

### Camada de dados (`cDados*`, 19 classes)

`cDadosAccess`, `cDadosAccessComum`, `cDadosAccessDuplicaCaderno`, `cDadosAccessDWG`,
`cDadosAccessExpImp`, `cDadosAccessFiacao`, `cDadosAccessImportarProj`, `CDadosAccessInterligacao`,
`cDadosAccessInterligacao2`, `cDadosAccessJumper`, `cDadosAccessMateriais`, `cDadosAccessPaineis`,
`cDadosAccessPlaquetas`, `cDadosAccessRelPot`, `cDadosAtualizaBanco`, `cDadosExcel`, `cDadosLM`,
`cDadosSQLServer`, `cDadosSQLServerLicenca`.

- Padrão: o construtor escolhe o backend por `Conf.Banco` e guarda a instância em `db`;
  os métodos chamam via **late binding** (`NewLateBinding.LateCall`), o que torna a classe polimórfica
  entre Access / SQLite / SQL Server.
- **Monitor de conexões:** `DeclaracoesGeral.monitorConexao++/--` com `_uscPagina.statusBanco(...)`
  exibindo o número de conexões abertas na UI.
- **Migração de schema:** `cDadosAtualizaBanco` / `ACorrecaoBD` aplicam `ALTER TABLE ...`
  (ex.: `ALTER TABLE Bornes4F ADD LM Long`, `ALTER TABLE Fiacao ADD Aplicacao Integer`).

---

## 7. Persistência dentro do DWG — `XData*` (16 classes)

O estado elétrico é gravado como **XData nas próprias entidades** do desenho (não apenas no banco).
*App names* registrados incluem: `Eletron`, `ArqNet`, `ARANHA`, `CONEXAO`, `AUXBORNES`, `AUXCONEXAO`,
`AUXDERIVACAO`, `AUXINTERLIG`, `AUXDISP*`, `AUXEXPORTADO`, `AUXIMPORTADO`, `CODEXPORT`, `DiagLog`.

`XDataGeral.verificaTipoXData()` inspeciona o ModelSpace e classifica o desenho:

| Retorno | Tipo |
|---|---|
| `"E"` | Eletron |
| `"D"` | DiagLog |
| `"A"` | ArqNet |
| `"V"` | outro |

O tipo do DWG determina quais painéis do Ribbon aparecem (por isso a UI se adapta ao arquivo aberto).

Classes: `XDataAranha`, `XDataConexao`, `XDataCorrecao`, `XDataDIEnergisa`, `XDataDIEnergisaSSE`,
`XDataDInterlig`, `XDataDispositivo`, `XDataDispositivosMaster`, `XDataExpImp`, `XDataGeral`,
`XDataInterligacao`, `XDataLayout`, `XDataLeitura`, `XDataRelatorio`, `XDataTopografico`,
`XDataTrocaBlocos`.

---

## 8. Licenciamento — 4 modos

`My.Settings.LicMode` (espelhado em `DeclaracoesGeral.LicModeSel`), trocável pelo comando `RESETLIC`
(que apenas zera `LicMode` e salva).

| Modo | Classe | Mecanismo |
|---|---|---|
| **1 — Rockey** | `cCheckLicRockey`, `Rockey` | Dongle Feitian. P/Invoke para `Rockey432`, `Rockey4ND32`, `Rockey464`, `NetRockey432/464` |
| **2 — ElecKey** | `cCheckElecKey` | `KeyLib.KeyCheck(1975451131, 1, 0, 0, "", Application.ExecutablePath, "")`, `SrvIdx = 6`; licença em `HKCU\Software\W64c\Elk` valor `CL3` |
| **4 — Nuvem** | `cCheckNuvem` | `verificaLic()` -> flags `bApp` / `bTrial` / `bAbreRegistro`; registro em `FormRegNuvem`; DB Azure `LICSQL_CSE` |
| **0** | `frmCarregaEL` | Tela de escolha do provedor (checkbox/botões Rockey / ElecKey) |

- **Revalidação em runtime:** `myEletron.TimerEventHandler` lê `CL3` a cada poucos segundos;
  sem licença -> instancia `WNuvem`.
- **Anti-tamper:** `cCheckNuvem.cs` contém a checagem de relógio alterado
  (`"A data do computador foi adulterada"`).
- **Desinstalação:** `Terminate()` -> `DesregistraNuvemAut()`.

### Credenciais expostas (licenciamento em nuvem)

`AcessoSQLServerLicenca.cs` traz a connection string **em texto claro**:

```text
Servidor : svsqlcse.database.windows.net,1433
Usuario  : azureadm
Senha    : 2020CSE@lic
Banco    : LICSQL_CSE
```

---

## 9. Onde está cada coisa

Base: `decompiled-cleaned\Eletron4\`

| Caminho | Camada |
|---|---|
| `myEletron.cs`, `Iniciar.cs`, `EventosDOC.cs`, `Ribbon.cs` | bootstrap / UI |
| `Comandos.cs`, `Correcao.cs`, `clsUtilitarios.cs`, `clsTrocaEditaBlocos.cs` | registro de comandos |
| `frm*.cs`, `usc*.cs`, `w*.cs` | 131 telas WinForms/WPF |
| `cls*.cs` (52) | regra de negócio |
| `cDados*.cs` (19) + `Acesso*.cs` (5) | acesso a dados |
| `XData*.cs` (16) | dados no DWG |
| `Relatorios*.cs` (45) | relatórios DWG / Excel / PDF |
| `cCheckLicRockey.cs`, `Rockey.cs`, `cCheckElecKey.cs`, `cCheckNuvem.cs` | licenciamento |
| `Mensagem.cs`, `DeclaracoesGeral.cs` | i18n e estado global |

---

## 10. Artefatos da análise

| Arquivo | Descrição |
|---|---|
| `cleaned\Eletron4Z-cleaned.dll` | binário desobfuscado (7,3 MB) |
| `decompiled-cleaned\` | código-fonte real (434 `.cs`, ~99% dos corpos) |
| `decompiled\` | versão original ofuscada (referência) |
| `COMANDOS.txt` | lista dos 216 comandos |
| `..\tools\de4dotEx\de4dot.exe` | ferramenta de desobfuscação |

---

## 11. Limitações deste mapa

- Os **5 comandos principais** (`elet`, `dlog`, `etpg`, `Anet`, `earq`) ainda têm corpo vazio
  no desobfuscado — o fluxo real deles não foi lido. Candidatos: NETReactorSlayer ou análise dinâmica (dnSpyEx).
- `Initialize()` e alguns métodos retornam com avisos de IL do ILSpy (`Unknown result type`),
  deixando trechos parcialmente ilegíveis e nomes de campos locais ofuscados.
- As **consultas SQL exatas** (SELECT/INSERT por tabela) não foram inventariadas uma a uma;
  o schema aparece via `ALTER TABLE` e nas telas.

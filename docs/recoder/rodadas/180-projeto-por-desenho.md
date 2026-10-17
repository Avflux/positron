# Rodada 180 — projeto por desenho: o banco, o DWG e a configuração vêm do desenho ativo

**Data:** 2026-10-15 · **Commit:** *(este)* · **Frente:** correção do básico, item 1 · **Situação:** 🟡 parcial (o essencial entrou; o resto do `IniciarDWG` e o Access estão em *Falta*)

## Alvo

Item 1 da *Correção do básico* do `ESTADO.md`. O dono testou em uso real e viu que, ao começar um
projeto novo e carregar a DLL, os dados do projeto anterior continuavam. A causa estava confirmada no
código: o banco, o índice do DWG e a revisão vinham de `%APPDATA%\Positron\positron.ini`, um arquivo da
máquina que não existe no original, e um desenho sem XData herdava o banco de outro projeto. O plugin
também não tinha nenhum evento de troca de documento.

Decisões do dono (2026-10-15): o cadastro do DWG fica fiel ao original (a `frmConfiguracaoBDProjeto`
grava o `DirProjeto` e o índice sai da tabela `DWG`), e as variáveis `POSITRON_*` ficam só no harness.

## O que o reverso faz

Caminhos relativos a `cad-plugin/reverso/Eletron4_ZWcad/decompiled-cleaned/Eletron4/`.

- **Entrada:** o `Initialize` roda `Iniciar.IniciarDWG()` e liga o `DocumentActivated` ao
  `EventosDOC.AtivaDocumento` (`myEletron.cs:202-233`). O `AtivaDocumento` (`EventosDOC.cs:119-150`)
  fecha as janelas abertas, menos 10 da lista, e roda o `IniciarDWG` **a cada desenho ativado**.
- **`IniciarDWG`** (`Iniciar.cs:61-195`):
  - `verificaTipoXData` (`XDataGeral.cs:16`): XData do ModelSpace `Eletron` = `E`, `DiagLog` = `D`, `ArqNet` = `A`, nenhum = `V`. O tipo liga ou desliga os painéis da barra;
  - `LerXDataConfiguracao` (`:153`) e `LerXDataConfiguracao2` (`:532`): sem o XData, os padrões
    (`:291-300`: `Local = "???"`, `PassoPagina = 1`, `Banco = "A"`…) e as pastas **vazias**, com o
    `DirProjeto` vazio (`:563-571`);
  - recarrega as páginas e abre a paleta (`Comandos.GerenciadorPagina`);
  - na primeira ativação de cada desenho (`lDwgRegen`): estilo `Romans`, as 5 correções automáticas
    (`XDataCorrecao`), e, se `!BancoValido(bMsg: false)` num desenho tipo `E`, `new frmConfiguracaoBDProjeto()`;
    com o banco válido, `ACorrecaoBD.CorrigeBD()`;
  - recarrega os dicionários de DWG e de painéis.
- **`BancoValido`** (`clsAuxiliar.cs:10-60`): Access/SQLite pedem `DirProjeto` preenchido (senão mMensagem 328)
  e o arquivo existente (senão 329); SQL Server pede servidor, banco e usuário, e testa a conexão (1968).
- **Índice do DWG** (`cDadosAccess.carregaDadosDWG`, `cDadosAccess.cs:15-62`): o nome do arquivo sem a extensão
  (`Geral.extraiNomeCaminhoDwg`) procurado, sem diferenciar maiúsculas, no `SELECT Indice, Nome FROM DWG`.
- **`frmConfiguracaoBDProjeto`** (`frmConfiguracaoBDProjeto.cs:127-237`; 384×91, `tbProjeto` e `SelProj`):
  - Com SQL Server, mostra a mMensagem 1970 e não abre.
  - O `SelProj` abre o `OpenFileDialog` (título 237; filtro Access `*.accdb;*.mdb` ou SQLite `*.db`,
    conforme o `Conf.Banco`), grava o `DirProjeto` no XData `EletronProj` (`GravarXDataConfiguracao2`,
    `XDataGeral.cs:592`, com `LockDocument`) e roda o `yKiycL7IZh`:
    - DWG não cadastrado: mMensagem 323, `Este arquivo ainda não foi cadastrado!`;
    - DWG cadastrado: `UPDATE DWG SET Caminho, Editor, Data WHERE Indice` (`cDadosAccessDWG.AtualizaValores`, `:297`).
- **`PAS`** (`Pagina.redefinePasso`, `Pagina.cs:2657`): `GetInteger` (mMensagem 143, sem zero nem negativo, padrão = o passo atual) e `GravarXDataConfiguracao`.
- **Fora do desenho**, o original guarda só `My.Settings` (`LicMode`, `Cor`, `Secao`…) e o registro `Idioma`. Nada do projeto.

## O que foi feito

| arquivo | o quê |
|---|---|
| `cad-plugin/Positron.Data/Configuracao/ConfiguracaoPositron.cs` | **sai o arquivo** (`ArquivoPadrao`, `Salvar`, `Texto`, a leitura do `.ini`, o cache estático); `Carregar(ambiente, desenho)`: o desenho ou os padrões do original, com o ambiente do harness por cima |
| `cad-plugin/Positron.Plugin/Configuracao/ConfiguracaoDoDesenho.cs` | `LerOuPadrao` (os dois apps lidos independentes, como o original), `GravarProjeto`/`GravarConfig` (cada `GravarXDataConfiguracao*` sozinho) e o `LockDocument` |
| `cad-plugin/Positron.Plugin/ConfiguracaoEfetiva.cs` | a configuração do desenho ativo, sem cache; o **índice do DWG pelo nome do arquivo** na tabela `DWG` |
| `cad-plugin/Positron.Plugin/InicioDoDesenho.cs` | o `DocumentActivated`/`IniciarDWG`: fecha as janelas do Elétron (menos as 10 da lista), abre a paleta e, na 1ª ativação de um desenho tipo `E` sem banco, a `frmConfiguracaoBDProjeto`; `BancoValido` com as mMensagens 328/329; `TipoDoDesenho` |
| `cad-plugin/Positron.Plugin/Interface/Telas/LigacaoDoFrmConfiguracaoBDProjeto.cs` (+1 linha em `LigacoesDasTelas`) | a tela ligada (filtro por tipo de banco, `GravarXDataConfiguracao2`, mMensagens 323/1970, `UPDATE DWG`) |
| `cad-plugin/Positron.Data/ProjectStore.cs` | `AtualizarDwg` (o `AtualizaValores`) |
| `cad-plugin/Positron.Plugin/Interface/Aviso.cs` | o `MsgBox` do original (no harness, só a linha de comando) |
| `cad-plugin/Positron.Plugin/Plugin.cs` | `Initialize` liga o `DocumentActivated` e roda o `IniciarDWG`; as linhas de abertura vão **só para o log do harness** (o original não escreve nada ao carregar); o log só existe com `POSITRON_LOG` |
| `cad-plugin/Positron.Plugin/Paginas/PassoDoCaderno.cs`, `Comandos.cs` (`PASSO`) | o `redefinePasso`: pergunta e grava no **desenho** (antes gravava o `.ini`) |
| `cad-plugin/Positron.Plugin/Comandos.cs` (`ELETCFG`) | grava só no desenho; sai o `.ini` |
| `cad-plugin/Positron.Plugin/Configuracao/FormularioConfiguracao.cs` | sai o grupo inventado **"Projeto"** (DWG, Revisão, Log) |
| 21 mensagens em `Comandos.cs` e nas telas | `"X: defina POSITRON_DB_PATH…"` → mMensagem 328 `Banco do Projeto não configurado!` (`MensagensDoReverso.BancoNaoConfigurado`) |
| `LigacaoDoFrmPesquisaCabos.cs`, `LigacaoDoFrmPesquisaVeiasIndefinidas.cs` | o `BancoValido()` do construtor (328/329) e os `MsgBox` 331/1284 |
| `Interface/Telas/RenderizadorDeTelas.cs` | a janela recebe o `Name` do `frm*` (o fechamento por nome do `AtivaDocumento` precisa) |
| `scripts/cad-zwcad-smoke.ps1` | `-SemProjeto`: não define `POSITRON_DB_PATH/DWG/REVISAO/LOCAL` — o caminho do usuário real |
| `scripts/cad-fixture-projeto.lsp` | despeja o `EletronProj`/`Eletron` do ModelSpace; com `POSITRON_PROJ_MARCAR`, marca um desenho novo como tipo `E` |
| `cad-plugin/Positron.Data.Tests/ConfiguracaoPositronTests.cs` | testes do `.ini` trocados pelos do desenho: −8 +4 |

**Desvios do original (com motivo):**
- **Banco Access:** o plugin só lê SQLite. Um desenho cujo `DirProjeto` é `.mdb`/`.accdb` recebe o aviso
  `O banco do projeto deste desenho é do Access (...); o Positron ainda só lê banco SQLite (.db).`, e a
  `frmConfiguracaoBDProjeto` **não** abre sozinha (no original esse banco é válido). Decisão do dono.
- SQL Server: o `BancoValido` confere só os campos, sem testar a conexão (decisão 9c do dono).
- `POSITRON_BDPROJETO=<arquivo>`: gancho do harness que faz o mesmo que escolher o arquivo no `SelProj`.

## Prova

- `plugin:test`: **895** (−8 testes do `.ini` que saíram, +4 do desenho), total conferido > 0.
- builds ZWCAD / AutoCAD: 0 avisos, 0 erros.
- **ZWCAD 2026, caminho do usuário real** (`-SemProjeto`, sem nenhuma variável de projeto; o
  `%APPDATA%\Positron\positron.ini` antigo, com `banco=...Modelo de BD Projeto.db`, continua no disco):

1. **Desenho novo, marcado como do Elétron, sem banco** (`-Fixture scripts/cad-fixture-projeto.lsp`,
   `POSITRON_PROJ_MARCAR=1`, `POSITRON_BDPROJETO=` uma cópia do banco do e2e com `DWG(77, 'Drawing1')`).
   A tela abriu sozinha ao carregar, ligou o desenho, achou o DWG pelo nome e o `PESQCAB` usou o DWG 77:

```
Banco de Dados do Projeto: o desenho passa a usar "C:\Users\rno\AppData\Local\Temp\pz-proj.db".
Banco de Dados do Projeto: DWG 77 cadastrado — 1 linha(s) atualizada(s) (Caminho, Editor, Data).
PESQCAB: 0 cabo(s) deste DWG (77) e 697 de outros cadernos na grade; 2388 veia(s) no catálogo.
ELETRONPROJ;(EletronProj Projeto C:\Users\rno\AppData\Local\Temp\pz-proj.db     )
DWG depois: [(77, '', 'rno', '2026-10-15 17:03:00.8690581')]
```

2. **Desenho novo em seguida, sem nada:** não herdou nada (nem o banco do passo 1, nem o do `.ini`):

```
Banco do Projeto não configurado!
PESQCAB: "Pesquisar Cabos e Veias" (frmPesquisaCabos) não aberta.
Banco do Projeto não configurado!
PESQC: "Pesquisar Veias Indefinidas" (frmPesquisaVeiasIndefinidas) não aberta.
ELETRONPROJ;(sem)
```

3. **`Funcional.dwg` real:** o `EletronProj` dele aponta para
   `J:\Eletrobras\...\07_Banco de Dados Elétron\RCD.mdb`, que **existe** nesta máquina (Access):

```
O banco do projeto deste desenho é do Access (J:\Eletrobras\...\RCD.mdb); o Positron ainda só lê banco SQLite (.db).
PESQCAB: "Pesquisar Cabos e Veias" (frmPesquisaCabos) não aberta.
```

- **Harness de sempre** (`npm run cad:projeto`, com `POSITRON_*`): `=== OK: ciclo completo ===`, `VERIF` **249**
  contra a linha de base, os mesmos números de antes.
- AutoCAD: **não medido** nesta rodada — e a justificativa dela **estava errada**: o **AutoCAD 2020 está instalado** (**verificado em 2026-10-16** por registro + pastas + `where`; `C:\Program Files\Autodesk\AutoCAD 2020`). Ausência de CAD é uma **medição, com data** (`RUNBOOK.md` → *Existe CAD nesta máquina?*). A build compila.

## Falta

- [ ] **Banco Access (decisão do dono):** o projeto real (`RCD.mdb` no `J:`) é Access, e o plugin só lê SQLite.
  Sem um leitor de Access, o uso real nesse projeto exige converter o banco para `.db`.
- [ ] **Troca de documento com dois desenhos abertos:** o harness abre um desenho só. Conferência do dono:
  abrir dois desenhos de projetos diferentes, alternar e ver que a paleta e o `PESQCAB` seguem o desenho ativo.
- [ ] **Resto do `IniciarDWG`:** os painéis da barra ligados/desligados pelo tipo `E`/`V`/`D`/`A`; as 5 correções
  automáticas por `XDataCorrecao`; o estilo `Romans`; o `ACorrecaoBD.CorrigeBD`; a página ativa ao abrir.
- [ ] **Revisão:** sem `POSITRON_REVISAO`, a revisão das compilações fica vazia. No original, ela vem da grade
  de revisões das telas `frmCompilar*`. Conferir na rodada das telas de compilação.
- [ ] **Ganchos `POSITRON_*` restantes em comandos** (`POSITRON_PAGINA`, `POSITRON_TITULO1..4`, `POSITRON_UNIDADE`,
  `POSITRON_FORMATO_TROCAR`): no original esses comandos perguntam ao usuário. Entram na rodada das folhas (item 2).
- [ ] O `ELETCFG` continua a tela feita à mão (item 4 da correção do básico).
- [ ] O `positron.ini` antigo em `%APPDATA%\Positron\` não é mais lido; pode ser apagado.

## Conhecimento registrado

`docs/recoder/conhecimento/projeto.md` (novo): o `IniciarDWG`, o `BancoValido`, o índice do DWG pelo nome,
a `frmConfiguracaoBDProjeto` e o que o original guarda fora do desenho.

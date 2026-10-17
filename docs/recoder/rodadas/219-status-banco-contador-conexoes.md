# Rodada 219 — O status do banco na paleta pelo contador de conexões

**Data:** 2026-10-17 · **Commit:** `67a92ada` · **Frente:** correção do básico, item 3 (paleta `uscPaginas`) · **Situação:** 🟡 parcial

## Alvo

Item 1 da fila do `ESTADO.md` (*Fechar a rodada 183 — Páginas / Editar os Títulos*), recorte que
sobrou: **"status do banco ligado ao contador de conexões"**. Hoje o `PictureBox2` da paleta nasce
`DB_DISCONNECTED` (`FolhasControle.cs:125`) e **nunca muda** — o plugin não tem o contador que o
reverso usa para decidir o ícone.

## O que o reverso faz

Caminhos relativos a `cad-plugin/reverso/Eletron4_ZWcad/decompiled-cleaned/Eletron4/`.

- **O contador:** `DeclaracoesGeral.cs:566` `public static int monitorConexao;`, zerado no
  construtor estático (`:610`). Ele conta **conexões abertas**, não "banco configurado".
- **Quem incrementa/decrementa** — todo acesso a dados, no mesmo par abrir/fechar:
  - `AcessoSQLite.cs:99-104` (no `Open()` do `ExecuteScalar`/`ExecuteNonQuery`/`ExecuteReader`,
    **só** quando o estado era `Closed`): `monitorConexao++` e `statusBanco(monitorConexao)`;
  - `fechaConexao()` (`AcessoSQLite.cs:33-43`): `if (State == Open) { …Close(); monitorConexao--; statusBanco(monitorConexao); }`;
  - os mesmos dois pontos em `AcessoAccess.cs:28-29,136-137,…` e `AcessoSQLServer.cs:37-38,110-111,…`.
  - O teste de provedores do Access (`AcessoAccess.cs:95-97`) abre e fecha uma `OleDbConnection`
    **sem** mexer no contador: nada de conexão auxiliar de sondagem conta.
  - O **`AcessoExcel` NÃO conta**: ele abre e fecha a `OleDbConnection` (`AcessoExcel.cs:22,55,93,…`)
    sem nunca chamar `statusBanco`/`monitorConexao` — uma leitura do Excel aberto não mexe no ícone.
- **A decisão:** `uscPaginas.statusBanco(string valor)` (`:2606-2617`):
  `Conversions.ToDouble(valor) > 0` → `PictureBox2.Image = DB_CONNECTED`; senão `DB_DISCONNECTED`;
  e `Application.DoEvents()` no fim. O designer (`:1210`) nasce `DB_DISCONNECTED`
  (31 × 17, em (16, 7)) — já replicado no recoder.
- **O reset:** `Iniciar.IniciarDWG` (`Iniciar.cs:178-179`), **fora** do `lDwgRegen` (roda em toda
  ativação de documento): `monitorConexao = 0; _uscPagina.statusBanco("0");`. É o único ponto que
  põe o ícone em desconectado sem passar por uma conexão — quem chama `statusBanco` são os acessos.
- **O que ele NÃO faz:** `CarregaPG`/`CarregaPaginas` **não** chamam `statusBanco` — a carga da paleta
  não mexe no ícone (grep: as únicas chamadas de `statusBanco` no decompilado estão em
  `AcessoAccess/AcessoSQLite/AcessoSQLServer` e no `Iniciar.cs:179`).
- **Mensagens:** nenhuma (o indicador é só imagem).

## O que foi feito

| arquivo | o quê |
|---|---|
| `cad-plugin/Positron.Data/MonitorDeConexao.cs` | **novo**: o `monitorConexao` do original — contador de conexões abertas, `ConectadoCom`/`Conectado` (o `> 0` do `statusBanco`) e o aviso `Mudou`. O monitor da sessão é o estático `Atual`; a instância existe para a regra ser medida isolada |
| `cad-plugin/Positron.Data/ProjectStore.cs` | o **único** ponto de abertura do plugin (`Abrir()`, 57 usos `using`): incrementa depois do `Open()`, decrementa no `Disposed` (o `fechaConexao` do original) e devolve a conexão se os PRAGMA falharem, para não vazar contador |
| `cad-plugin/Positron.Plugin/Interface/Folhas/FolhasControle.cs` | o `PictureBox2` passa a acompanhar o contador (o `statusBanco`): assinatura do `Mudou` no construtor, troca da imagem com o `Application.DoEvents()` do original, `Dispose` que sai do evento e `BancoConectado()` para a prova do harness |
| `cad-plugin/Positron.Plugin/InicioDoDesenho.cs` | o `monitorConexao = 0` + `statusBanco("0")` do `IniciarDWG`, em **toda** ativação de documento (antes do `lDwgRegen`, como no original) |
| `cad-plugin/Positron.Plugin/Interface/Folhas/ProvaDaPaleta.cs` | ação `banco` do `pzFolhas`: mede o ícone na carga da paleta sem `POSITRON_DWG` (o caminho real do índice do DWG), numa leitura direta do banco e depois do `IniciarDWG` |
| `cad-plugin/Positron.Data.Tests/MonitorDeConexaoTests.cs` | +4 casos |
| `cad-plugin/README.md` | a linha do `pzFolhas` ganha a ação `banco` |

**Desvios do original (com motivo):**

- O contador não vive num campo público de uma classe de declarações globais: é o `Atual` do
  `MonitorDeConexao`, para a regra ter teste sem estado global compartilhado pela suíte.
- O fechamento vem do `Disposed` da conexão (todos os usos são `using`), e não de um `fechaConexao()`
  chamado à mão: o plugin não tem o par de métodos do original, e o `Dispose` é o mesmo momento.
- O original também conta as conexões do **Access** e do **SQL Server** (`AcessoAccess`/
  `AcessoSQLServer`); no plugin só o `ProjectStore` (SQLite) abre conexão — os outros dois são
  decisão do dono (1a/9c) e entram no mesmo `Atual` quando existirem.

## Prova

- `plugin:test`: o adaptador VSTest segue quebrado nesta máquina (falso verde conhecido). Console
  xUnit 2.9.2 em cópia do `bin` no `%TEMP%` (`pm219`): **1072** aprovados, 0 erros, 0 falhas,
  0 pulados (1068 + 4), em **cinco execuções seguidas** (3,6–4,3 s cada).
- **Uma armadilha de teste medida nesta rodada:** a primeira versão do teste de integração
  comparava os **valores** do contador (`vistos[0] - 1 == vistos[ultimo]`) e falhou 1 de 2 execuções —
  o `MonitorDeConexao.Atual` é o contador **da sessão** e as classes da suíte rodam em paralelo (uma
  conexão de outra classe entra no meio). O que é determinístico é o que a própria thread provoca:
  **dois** avisos (abertura e fechamento) e o estado conectado na abertura. Ficou registrado no
  `RUNBOOK.md` (*Troubleshooting*) para não se repetir.
- Builds contra as APIs reais: **ZWCAD 0 avisos/0 erros** (1,38 s, depois da última edição) e
  **AutoCAD 0 avisos/0 erros** (1,22 s).
- **AutoCAD 2020** (`accoreconsole`, cópia do `Funcional.dwg`, banco `.tmp-smoke/provas/219/projeto.db`
  com 3 DWG e 2 painéis, DWG 63), `pzFolhas` com `POSITRON_FOLHA_ACAO=banco`:

```
pzFolhas: 16 página(s) na grade [1 | 2 | 6 | 7 | 8 | 15 | 16 | 17 | 18 | 19 | 20 | 21 | 22 | 23 | 24 | 1000];
combo="12" (antes: 16); seleção pedida [] (0 achada(s)); selecionada depois [23];
ação "banco" → banco "...\.tmp-smoke\provas\219\projeto.db": ícone inicial=desconectado;
carga da paleta sem POSITRON_DWG → 2 aviso(s) [conectado | desconectado], depois=desconectado;
leitura direta = 3 DWG(s) e 2 painel(is), avisos [conectado | desconectado | conectado | desconectado],
agora=desconectado; conexão aberta fora do par → ícone=conectado;
depois do IniciarDWG: contador=0, ícone=desconectado
```

  Os três recortes medidos no host real: (1) a **carga da paleta pelo caminho real** (sem
  `POSITRON_DWG`, variável que só existe no harness) resolve o índice do DWG pelo banco do projeto —
  a conexão abre e fecha **dentro** da carga, e o ícone vai a conectado e volta; (2) uma **leitura
  direta** do banco devolve 3 DWG e 2 painéis com os dois pares de avisos (uma conexão por leitura);
  (3) uma conexão fora do par deixa o ícone conectado e o **`IniciarDWG`** da ativação de documento
  zera o contador e devolve o ícone ao desconectado (o `accoreconsole` não abre um segundo documento:
  foi chamado o **mesmo** `Iniciar()` que o `DocumentActivated` chama).
- **Ausência é afirmação medida:** 2026-10-17 — registro de desinstalação só com as entradas do
  **AutoCAD 2020** (`C:\Program Files\Autodesk\AutoCAD 2020`), nenhum `ZWCAD*.exe` em `C:\`/`D:\`
  (profundidade 4) e `where ZWCAD.exe` sem resultado. O ZWCAD está **ausente nesta data** (medido).
- O `Altern` do registro (`HKCU\Software\Cadgraph\Eletron4`) estava `1` nesta máquina, então a linha
  do harness traz `[Página | Unidade | Alternativo]`; é **estado da máquina**, não efeito da rodada
  (nenhum caminho desta rodada grava a preferência).

## Falta

- [ ] **Conferência visual** do ícone na janela do AutoCAD 2020 (interface cheia): não medida. O
  `accoreconsole` não tem janela e o que se mede ali é a **imagem posta no `PictureBox2`** — que é
  exatamente o que o `statusBanco` troca —, não o repaint. Além disso o estado conectado dura o tempo
  da conexão (milissegundos): na tela ele aparece nas rotinas longas, não numa leitura de comando.
- [ ] **ZWCAD**: repetir quando ele voltar (ausente em 2026-10-17, medido acima).
- [ ] O **Access** e o **SQL Server** do original contam no mesmo contador (decisão do dono, itens 1a/9c).
- [ ] O resto do item 1 da fila segue como estava: **progresso compartilhado pelas rotinas longas**,
  título 4/D/A/V e os seis atalhos em GUI, a `mMensagem 27` (precisa de um desenho com 27 páginas),
  a saída anômala do `acad.exe` e o foco roubado pelo `frmConfiguracaoBDProjeto` no arranque.

## Conhecimento registrado

`docs/recoder/conhecimento/paginas.md`: seção nova do status do banco — o par
`monitorConexao`/`statusBanco`, quem incrementa/decrementa, o reset do `IniciarDWG` e o fato de a
carga da paleta **não** mexer no ícone.

# Rodada 220 — O progresso compartilhado da paleta (o `pbIniciar`/`pbPasso`/`pbFim` do `uscPaginas`)

**Data:** 2026-10-17 · **Commit:** *(este)* · **Frente:** correção do básico, item 3 (paleta `uscPaginas`) · **Situação:** 🟡 parcial

## Alvo

Item 1 da fila do `ESTADO.md` (*Fechar a rodada 183 — Páginas / Editar os Títulos*), o recorte que a
rodada 219 deixou nomeado: **"o progresso compartilhado pelas rotinas longas"**. Hoje a paleta tem um
`ProgressBar1` desenhado (rodada 183) e **nada o move** — nem as rotinas longas, que no original o
dirigem por `DeclaracoesGeral._uscPagina` (~92 arquivos), nem o `Carregar()` que o movia por conta
própria (uma invenção, ver *Desvios*). Faltava o comportamento da barra: o `Quantidade`, o `pbIniciar`,
o `pbPasso`, o `pbFim` e o estado/pintura que o original manda.

## O que o reverso faz

Caminhos relativos a `cad-plugin/reverso/Eletron4_ZWcad/decompiled-cleaned/Eletron4/`.

- **O controle e o estado.** `uscPaginas.cs:1203-1208` (designer): `ProgressBar1` em (9, 426), 152 × 7,
  ancorada embaixo à esquerda/direita, `ForeColor = Color.Transparent` — e **nada mais**: os padrões do
  `ProgressBar` do WinForms valem (0..100, `Step` 10, valor 0) e a barra nasce no estado normal.
- **O par cor/estado.** `uscPaginas.cs:21-26` é o enum `ProgressBarColor { Green = 1, Red, Yellow }` e
  `:1238-1245` o `aGSp1cgg3tL(ProgressBar, ProgressBarColor)`:
  `SendMessage(P_0.Handle, 1040, (int)P_1, 0)`. A mensagem **1040** é o `PBM_SETSTATE`
  (`WM_USER + 16`), e 1/2/3 são `PBST_NORMAL`/`PBST_ERROR`/`PBST_PAUSED`: o "Red" do nome é o estado de
  **erro** da barra — é assim que ela fica vermelha.
- **As três chamadas** (`uscPaginas.cs:1247-1269`):
  - `pbIniciar()`: `Minimum = 0`; se `Quantidade < 0` então `Quantidade = 0`; `Maximum = Quantidade`;
    `Step = 1`; estado **Red** (`:1250-1256`). **Não** zera o `Value` — o valor que sobrou fica (e o
    controle o corta se o novo `Maximum` for menor).
  - `pbPasso(int iPasso = 1)`: `Increment(iPasso)` (`:1259-1262`) — anda e **para no `Maximum`**.
  - `pbFim()`: `Value = 0`, `Minimum = 0`, `Maximum = 0` (`:1264-1269`) — `Step` e estado ficam.
- **Quem é a barra.** `DeclaracoesGeral.cs:556`: `public static uscPaginas _uscPagina;` — o objeto
  estático que todas as rotinas alcançam. Ele **nasce no arranque**: o `Comandos.GerenciadorPagina`
  (`Comandos.cs:1448-1470`, com o `_uscPagina = new uscPaginas()` em `:1467`) é chamado pelo
  `Iniciar.IniciarDWG` (`Iniciar.cs:114,123`) a cada ativação de documento, então em uso normal o campo
  nunca é nulo.
- **Quem a dirige** (92 arquivos com `pbIniciar`/`pbPasso`/`pbFim`; os das rotinas que o recoder tem):
  - `SYNCD` (`Comandos.cs:288-303`): `Quantidade = 6`, `pbIniciar()`, e um `pbPasso()` **depois de cada**
    uma das seis rotinas, `pbFim()` no fim;
  - `SYNCV` (`Comandos.cs:865-911`): `Quantidade = 9` e nove `pbPasso` — o primeiro **antes** da
    primeira rotina e um depois de cada uma (mesma contagem, colocação deslocada);
  - `RESTPROJ` (`Comandos.cs:1258-1327`): **`pbIniciar()` antes do `Quantidade = 16`** — a barra herda o
    `Maximum` da rotina anterior e o 16 nunca chega a ela (quirk do original, mantido aqui);
  - `clsTextos.ExportaPaginas` (`clsTextos.cs:1059-1213`), a **exportação dos títulos** pelo Excel ativo:
    `pbPasso()` **antes** do `pbIniciar` (logo depois do `LimpaSheet`, `:1064`), `Quantidade =
    dg.RowCount - 1` + `pbIniciar` (`:1149-1150`), um `pbPasso()` no fim de **cada** linha escrita
    (`:1201-1202`) e o `pbFim` (`:1210`). São `RowCount` passos para `Maximum = RowCount - 1`: o último
    **satura** (o off-by-one é do original);
  - `AcessoExcel.cs:239-261` (posição funcional do LP): `Quantidade = UBound(Porta)` e um `pbPasso(100)`
    a cada cem linhas;
  - o `clsTextos.ImportaTitulos` (`:1214-1306`) **não** chama nenhum dos três — quem o faz na importação
    de textos é o `ImportaTextos` (`:1393-1441`, do `frmExportarImportarTextos`, fora do recorte);
  - o `ExportaTextos` (`:1312-1389`) repete o padrão do `ExportaPaginas`.
- **Quem NÃO a dirige:** a **carga da paleta**. O `uscPaginas.CarregaPG` (`:1327-1400`) e o
  `Pagina.CarregaPaginas` não chamam `pb*` (grep: as chamadas estão só nas famílias `Acesso*`, nas
  rotinas longas e nos `relatorios`; o `Iniciar.cs:179` é o `statusBanco` do ícone do banco, não a
  barra).
- **Quirk de repintura:** os três pipelines e as exportações **não** chamam `Application.DoEvents`
  (nenhuma das 37 ocorrências do decompilado está nessas cadeias), e o `pbFim` zera a barra no fim do
  comando: numa rotina digitada a barra **não aparece** na tela — o valor só anda entre a primeira e a
  última linha do comando. Quem repinta durante uma rotina longa é o `statusBanco` do ícone do banco
  (rodada 219).
- **Mensagens:** nenhuma (a barra não tem texto).

## O que foi feito

| arquivo | o quê |
|---|---|
| `Positron.Data/ProgressoCompartilhado.cs` | **novo**: a regra pura do `ProgressBar1` com o `Quantidade` e o `pbIniciar`/`pbPasso`/`pbFim` do original, o estado de pintura (`CorDaBarra` = o `PBST_*` que a mensagem 1040 recebe) e o aviso `Mudou`; os padrões do WinForms (0..100, `Step` 10) entram como estado inicial |
| `Positron.Plugin/Interface/Folhas/FolhasControle.cs` | o `ProgressBar1` passa a ser **espelho** da regra (o original **é** o controle): `Mudou` → `Minimum`/`Maximum`/`Step`/`Value` e o `SendMessage(1040, estado)` do `pbIniciar` quando a cor muda (só com handle); `ForeColor = Color.Transparent` do designer; o `Progresso` exposto; **sai** o progresso que o `Carregar()` movia por conta própria; `Dispose` sai do evento |
| `Positron.Plugin/Interface/Folhas/PaletaDeFolhas.cs` | o `DeclaracoesGeral._uscPagina` do recoder: `Progresso` (a barra da paleta, `null` se ela não existir) e os `ProgressoQuantidade`/`ProgressoIniciar`/`ProgressoPasso`/`ProgressoFim` que as rotinas chamam |
| `Positron.Plugin/Comandos.cs` | as três pipelines ligadas à barra: `SYNCD` (`Quantidade` = os quatro passos, um `ProgressoPasso` depois de cada), `SYNCV` (três) e `RESTPROJ` (cinco, com o `Iniciar` **antes** do `Quantidade`, como no original) |
| `Positron.Plugin/Interface/Excel/ExcelAtivoDosTitulos.cs` | a exportação dos títulos move a barra como o `ExportaPaginas`: o `Passo` antes do `Iniciar`, `Quantidade = plano.TotalDePassos` (o `dg.RowCount - 1` do original) e um passo por linha escrita; a **importação não move** (o `ImportaTitulos` do original também não — comentado no adapter para não "consertarem") |
| `Positron.Plugin/Interface/Folhas/ProvaDaPaleta.cs` | ação `progresso` do `pzFolhas`: lê o **`ProgressBar1` da paleta do arranque** a cada aviso e imprime a sequência da exportação dos títulos (quando `POSITRON_TITULOS_EXCEL` está posta) e das três pipelines, com a asserção do `SYNCD` |
| `Positron.Data.Tests/ProgressoCompartilhadoTests.cs` | +10 casos |
| `cad-plugin/README.md` | a linha do `pzFolhas` ganha a ação `progresso` |

**Desvios do original (com motivo):**

- A invenção que **saiu**: o `Carregar()` da paleta movia a barra (`Maximum` = páginas, um `Increment`
  por linha e `Value = 0` no fim). O `CarregaPG` do original não toca na barra — o código estava no
  recoder desde a rodada 183 sem prova no reverso.
- A regra vive em `Positron.Data` e a paleta a **espelha**, em vez de o estado **ser** o do controle
  (como no original): é o que torna o `pbIniciar`/`pbPasso`/`pbFim` medível sem CAD, sem mudar o que o
  usuário vê.
- O `SendMessage(1040, estado)` sai quando a cor/estado **muda** de fato, e não em toda chamada como no
  `pbIniciar` do original: o controle fica no mesmo estado (só não repete a mensagem).
- As quantidades das três pipelines são as dos **passos que o recoder roda** (4/3/5), e não as do
  original (6/9/16): o recoder tem menos passos naquelas cadeias (o desvio do pipeline, documentado
  desde as rodadas 107/111 — as três `Sincroniza*` viram a projeção `FIA`/`INT`, e os modelos de bobina,
  o cruzamento e o `AtualizaNomesDosCabos` estão fora do recorte). O que se replica é a **forma**:
  `Quantidade` = número de passos, um `pbPasso` por passo, `pbFim` no fim.
- `PaletaDeFolhas.Progresso*` não faz nada quando a paleta não existe (no original o acesso direto ao
  campo estático estouraria): no arranque a paleta **é** criada nas duas implementações
  (`Iniciar.cs:114,123` lá, `InicioDoDesenho.cs:102` aqui), então o caminho nulo não é alcançável em uso
  normal — é defesa, não comportamento.

## Prova

- `plugin:test`: o adaptador VSTest segue quebrado nesta máquina (falso verde conhecido). Console xUnit
  2.9.2 em cópia do `bin` no `%TEMP%` (`pm220`, com o runner copiado **para dentro** da pasta, como no
  `RUNBOOK`): **1082** aprovados (1072 + 10), `Errors: 0, Failed: 0, Skipped: 0`, em **3,9 s** — e
  repetido mais duas vezes com o mesmo resultado.
- Builds contra as APIs reais: **ZWCAD 0 avisos/0 erros** e **AutoCAD 0 avisos/0 erros**.
- **AutoCAD 2020** (`accoreconsole`, cópia do `Funcional.dwg`, banco
  `.tmp-smoke/provas/220/projeto.db` — o do ensaio 219, com o DWG 63 = `Funcional` e a revisão R0),
  duas passagens, **cada uma repetida depois da última edição do código** (a saída colada é a da
  repetição final); os logs estão em `.tmp-smoke/provas/220/` (`cad-sincd.log`,
  `cad-exportacao-final.log` e o `cad-exportacao.log` da primeira).

  1) `-Comandos SYNCD,pzFolhas` com `POSITRON_FOLHA_ACAO=progresso` — o `SYNCD` **digitado** (o caminho do
  usuário) e as sequências lidas do **controle** (`ProgressBar1`), no formato `Minimum..Maximum=Value`:

```text
pzFolhas: 16 página(s) na grade [...]; ação "progresso" → barra da paleta (ProgressBar1) — exportação dos títulos → (sem exportação: `POSITRON_TITULOS_EXCEL` ausente); SYNCD → 0..4=0, estado 2 | 0..4=1, estado 2 | 0..4=2, estado 2 | 0..4=3, estado 2 | 0..4=4, estado 2 | 0..0=0, estado 2; SYNCV → 0..3=0, estado 2 | 0..3=1, estado 2 | 0..3=2, estado 2 | 0..3=3, estado 2 | 0..0=0, estado 2; RESTPROJ → 0..3=0, estado 2 | 0..3=1, estado 2 | 0..3=2, estado 2 | 0..3=3, estado 2 | 0..3=3, estado 2 | 0..3=3, estado 2 | 0..0=0, estado 2; compartilhada com o controle: True
```

  O que essa linha prova, recorte por recorte: a barra que o **comando** move é a **da paleta**
  (`compartilhada com o controle: True`, lida pelo `ProgressBar1` do `FolhasControle` do arranque); o
  `SYNCD` faz `Iniciar` (faixa 0..4 e estado **2** = `PBST_ERROR`, o "Red" do original), quatro passos e
  o `Fim` (0..0); o `SYNCV` faz o mesmo em 0..3; e o `RESTPROJ` **herda o `Maximum` da rotina anterior**
  (`0..3`, não 0..5) — o quirk do `pbIniciar` antes do `Quantidade`, medido.

  2) `-Comandos pzFolhas` com `POSITRON_FOLHA_ACAO=progresso` **e** `POSITRON_TITULOS_EXCEL=exportar` — a
  barra vem **antes** das pipelines, ainda virgem (0..100) — e as duas execuções deram a **mesma**
  sequência, caractere a caractere:

```text
EXCEL: 15 página(s) exportada(s) para a aba ativa do Excel (6 coluna(s) com título; 14 passo(s) na barra).
pzFolhas: ... ação "progresso" → barra da paleta (ProgressBar1) — exportação dos títulos → 0..100=1, estado 1 | 0..14=1, estado 2 | 0..14=2, estado 2 | ... | 0..14=14, estado 2 | 0..14=14, estado 2 | 0..14=14, estado 2 | 0..0=0, estado 2; SYNCD → 0..4=0, ...; SYNCV → ...; RESTPROJ → 0..3=0, ...
```

  A exportação real dos títulos (**15 páginas** na aba do Excel, 6 colunas com título) move a barra como
  o original, e a sequência mostra os três fatos que a ficha previu: (a) o `pbPasso()` **antes** do
  `pbIniciar` anda a barra que ainda está em **0..100** (os padrões do WinForms, estado 1 = normal);
  (b) o `pbIniciar` põe `Quantidade = 14` (`dg.RowCount - 1`), muda o estado para **2** (vermelho) e
  **não zera** o valor (`0..14=1`, o valor veio do passo anterior); (c) os **15** passos para
  `Maximum = 14` saturam (`0..14=14` três vezes no fim) e o `pbFim` devolve a faixa a `0..0`.
- **Desenho novo / troca de documento:** não se aplicam — nada aqui lê ou grava o desenho (a barra é da
  sessão) e a paleta nasce a cada ativação, como no original.
- Limpeza: as cópias do desenho e do banco ficaram em `%TEMP%`/`.tmp-smoke` e o `EXCEL.EXE` "Pasta1"
  criado pela ponte do ensaio foi fechado depois da medição (`tasklist`: nenhum `EXCEL`/`acad` aberto).

## Falta

- [ ] **Conferência visual** da barra em host com GUI: no `accoreconsole` o controle **não tem handle**,
  então o `SendMessage(1040, 2)` (o `PBM_SETSTATE` que pinta a barra de vermelho) nunca é exercitado — o
  que se mediu foi o estado da regra e os valores do `ProgressBar1`. E, como a barra não é repintada
  durante um comando (nenhum `DoEvents` nas cadeias, ver a ficha), o que o usuário vê numa pipeline é a
  barra voltando a zero no fim; a rotina em que ela apareceria é uma exportação com o Excel aberto.
  Conferência do dono: abrir a paleta, rodar `SYNCD` e observar a barra — não medida nesta rodada.
- [ ] **ZWCAD**: repetir quando ele voltar. **Ausência medida de novo nesta data** (2026-10-17,
  registro + pastas + `where`): o registro de desinstalação só traz as entradas do **AutoCAD 2020**, não
  há `C:\Program Files\ZWSOFT` e o `where.exe ZWCAD.exe` não acha nada; o **AutoCAD 2020** está lá
  (`C:\Program Files\Autodesk\AutoCAD 2020`, e foi ele que rodou as duas medições acima). A receita de
  verificação está no `RUNBOOK.md` → *Existe CAD nesta máquina?*.
- [ ] Os **outros ~90 pontos de chamada** do original (`AcessoExcel.UpdateConectadoPosFuncional`, os
  `clsCabos`/`clsBornes`/`clsTextos.ExportaTextos`/`ImportaTextos`, os relatórios…) entram nas rodadas
  que portarem cada rotina — o `ProgressoCompartilhado` já é o ponto único, como o `_uscPagina`.
- [ ] O resto do item 1 da fila segue como estava: o clique físico na paleta visível, o título 4/D/A/V e
  os seis atalhos em GUI, a `mMensagem 27`, a saída anômala do `acad.exe` e o foco do
  `frmConfiguracaoBDProjeto`.

## Conhecimento registrado

`docs/recoder/conhecimento/paginas.md`: seção nova do progresso compartilhado — as três chamadas com os
efeitos exatos (o `pbIniciar` que não zera o valor, o estado `PBST_ERROR` da mensagem 1040, os padrões do
designer), quem a dirige, o quirk do `RESTPROJ` (`pbIniciar` antes do `Quantidade`), o
`ImportaTitulos` que não mexe na barra e a carga da paleta que também não.

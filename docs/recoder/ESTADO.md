# Recoder — estado e fila

> **Só estado e fila.** A narrativa de cada rodada fica em `rodadas/NNN-slug.md`; os fatos do
> reverso em `conhecimento/`. Fluxo completo: skill `recoder` (`.claude/skills/recoder/SKILL.md`).
> Histórico até a rodada 175: `../PLANO.md` §5 e as seções "Rodada N" do `../RUNBOOK.md`.

## Estado (2026-10-17, depois da rodada 222)

| | valor |
|---|---|
| última rodada | **222** |
| comandos no plugin | **77** escritos à mão (53 do reverso + 24 nossos) + **115** gerados (só abrem a tela) |
| comandos do reverso sem nada no plugin | **48** (todas regra pura; triagem em `../PLANO.md` §7.6) |
| telas `frm*` do reverso | **127**; **23** com a ligação à regra; 19 que nenhum comando abre |
| testes (console xUnit; adaptador de `plugin:test` indisponível) | **1083** |
| builds ZWCAD / AutoCAD | 0 avisos |
| botões da barra cobertos | **126** de 161 acionáveis |
| host CAD medido | **AutoCAD 2020** — instalado e **verificado** (registro + pastas + `where`; a nota do `RUNBOOK` que dizia o contrário foi corrigida) e rodando as provas de GUI das rodadas 222 e seguintes; **ZWCAD ausente**, remedido em **2026-10-17** (sem `HKLM\SOFTWARE\ZWSOFT`, sem `C:\Program Files\ZWSOFT`, `where.exe ZWCAD.exe` vazio) — medido na 211 quando estava |

Números de cobertura: `powershell -ExecutionPolicy Bypass -File scripts/cobertura-do-reverso.ps1`.

## Frentes

| frente | situação |
|---|---|
| 1 — base e pipelines (`FIA`/`INT`/`JMP`/`VERIF`/`SYNCD`) | ✅ |
| 2 — correções e limpeza do CAD | ✅ 37 de 38 (o `CorrigeJanelas` é ambiente) |
| 3–9 — edição (réguas, dispositivos, fiação, cabos, materiais, exportação) | triadas (`PLANO.md` §7.6); portar comando a comando |
| 10 — páginas e caderno | ✅ (cadeia do `CAD` fechada na 175) |
| 11 — shell (arranque, paleta, barra, autoload) | ✅ |
| relatórios (9b) | ⏳ decisão do dono |
| SQL Server multiusuário (9c) | ⏸️ adiado (decisão do dono em 2026-10-16: rever após o recode do plugin) |
| **correção do básico** (projeto por desenho, folhas, configuração) | ⛔ prioridade — ver abaixo |

## Correção do básico (antes de qualquer item da fila)

O dono testou o plugin em uso real em 2026-10-15, depois da rodada 179, e o básico falhou. Os quatro
diagnósticos abaixo foram conferidos no código. Uma rodada por item, nesta ordem, cada uma provada pelo
caminho do usuário real (desenho novo, paleta, clique, troca de documento), não só pelo harness:

1. ✅ *(rodada 180; o que faltou está nos itens 1a–1c)* **Projeto por desenho.** Hoje o banco, o DWG e a revisão vêm do `%APPDATA%\Positron\positron.ini`
   global (`ConfiguracaoPositron.cs:14-20`, `ConfiguracaoEfetiva.cs:19-34`), e um desenho novo herda o
   projeto anterior. O original lê o banco do XData `EletronProj` do desenho e, sem ele, zera o banco
   (`XDataGeral.cs:532-571`). O índice do DWG vem do nome do arquivo na tabela `DWG`
   (`cDadosAccess.carregaDadosDWG`), e tudo isso é refeito a cada `DocumentActivated` (`myEletron.cs:233` →
   `EventosDOC.AtivaDocumento` → `Iniciar.IniciarDWG`, `Iniciar.cs:61-195`). Portar também a
   `frmConfiguracaoBDProjeto`, que liga o desenho ao banco e cadastra o DWG (decisão do dono: fiel).
   Parar de gravar banco, DWG e revisão no `.ini`; `POSITRON_*` fica só no harness (decisão do dono).
   - 1a. **Banco Access:** o projeto real (`RCD.mdb`) é Access e o plugin só lê SQLite — **decisão do dono** (ver abaixo).
   - 1b. ✅ *(rodada 181; falta o `ACorrecaoBD.CorrigeBD`, os dicionários de DWG/painel e os atalhos — ver a rodada)* **Resto do `IniciarDWG`** (`Iniciar.cs:61-195`): a barra ligada/desligada pelo tipo do desenho, as 5
     correções automáticas (`XDataCorrecao`), o estilo `Romans`, o `ACorrecaoBD.CorrigeBD` e a página ativa ao abrir.
   - 1c. ✅ *(rodada 182; falta o `POSITRON_FORMATO_TROCAR` na confirmação do `CAD`)* Ganchos `POSITRON_*` restantes em comandos (`POSITRON_PAGINA`, `POSITRON_TITULO1..4`, `POSITRON_UNIDADE`,
     `POSITRON_FORMATO_TROCAR`): no original esses comandos perguntam ao usuário.
2. ✅ *(rodada 182; falta o `clsApagar.ApagarDerivados` e o `tbPagina.Text`, que entra no item 3 — ver a rodada)* **Folhas: adicionar e apagar pela paleta.** As gravações não usam `LockDocument` e o erro vai para
   `UltimaMensagem`, que ninguém lê. Ao apagar a página ativa, nenhuma página é reativada (`Comandos.cs:1369`).
   No original, "Inserir" insere colunas ELET1..5 (`uscPaginas.cs:2466-2565`) e "Nova Página" usa a
   linha selecionada (`:1888-1972`). Faltam a confirmação e as sincronizações do apagar (`:2157-2222`) e
   as teclas Insert/Delete (`:1858-1887`).
3. ✅ *(rodadas 182/183/185/186; os recortes que sobraram estão no item 1 da fila)* **Paleta de folhas fiel ao `uscPaginas`** (`uscPaginas.cs:987-1497`, `paginas.png`, `paginas1.png`).
   - Sair: o rodapé inventado, a coluna `PgAtiva`, o negrito, as dicas e o Alternativo ligado por padrão
     (o original lê o registro `Altern`, padrão `"0"`).
   - Corrigir: a ordem Página | Unidade | Alternativo, o texto "Apagar Páginas" (mMensagem 21) e
     `MultiSelect=false`.
   - Entrar: a faixa de cima (`tbPagina`/Enter, `lb1..lb4`, status do banco, `btSalva`), a barra de
     progresso e o logo.
4. ✅ *(rodada 187; o que faltou está no item 5 e na fila)* **Configuração geral fiel.** O `CFG` da barra chamava o `ELETCFG`, feito à mão
   (`BarraDeFerramentas.cs:63`, `FormularioConfiguracao.cs`).
   - Ligar a `frmConfiguracaoGeral` (`frmConfiguracaoGeral.cs:2529-4600`; capturas `configuração geral 1-3.png`).
   - Ela grava o XData (`GravarXDataConfiguracao`/`2`) e o idioma no registro (`:3904-3910`).
   - Inclui o bloco SQL Server; tira o grupo "Projeto" (DWG/Revisão/Log).
   - Leva ao XData a norma IEC/ANSI, o Log Func e a representação cabo/veia, que hoje não chegam lá.
5. ✅ *(rodadas 188–207: `frmConfiguracaoBDProjeto`, `frmEstimativaVeiasLivres`, `frmEditaConexao`, `frmPesquisaVeiasIndefinidas`, `frmPesquisaCabos`, `frmEditaTitulosTextos`, `frmEstatisticaDeBornes` `frmEditaRevisaoSimplificada` `frmEditaRevisaoCompleta` `frmEditaTitulos` `frmPesquisaXdatas` as três `frmCompilar*` `frmGerenciadorMascaras` `frmGerenciadorContatos` `frmSplash` `frmRelatorio_Materiais` `frmRelatorio_Veias` `frmGerenciadorMateriais` e `frmGerenciadorMatIndep` feitas; as 21 telas ligadas então estão auditadas, faltam as feitas à mão; as ligadas depois da 207 — as 23 de hoje — ainda não)* **Auditoria das telas ligadas e das telas feitas à mão**, comparando controle a controle com o
   designer e a captura, atrás de invenções do mesmo tipo. O que aparecer vira item aqui.

## Fila (depois da correção do básico; uma rodada por item, na ordem)

1. **Fechar a rodada 183 (Páginas / Editar os Títulos)** — o que sobrou:
   - ✅ *(rodada 222, medido no AutoCAD 2020 visível)* **clique físico** na célula Página (o mouse e o
     teclado do Windows, com o `CLAYER` de `7` a `7A` e o despejo independente), os **quatro
     atalhos** `lb1..lb4` com o Xrecord de seis strings (slots 5/6 preservados) e o **título 4 /
     documento D** no editor; a medição achou e corrigiu a **seleção atrasada** do DataGridView
     (renomear a página ativa terminava na página seguinte) e provou que a **saída não-zero do
     `acad.exe` é do host** (sem o plugin, o mesmo fechamento pela COM também é não-zero);
   - ✅ *(rodada 215, prova viva em 2026-10-16)* Excel ativo do `frmEditaTitulos`: exportação (15 páginas, 6 colunas com título) e importação medidas no AutoCAD 2020 com o Excel aberto (1 célula na 1ª importação e **0** na 2ª — a grade convergiu; a aba devolve o valor importado). O que faltou virou item próprio na fila;
   - ✅ *(rodada 219, medido no AutoCAD 2020)* status do banco ligado ao contador de conexões (o
     `monitorConexao`/`statusBanco`); falta a conferência visual do ícone na janela;
   - ✅ *(rodada 220, medido no AutoCAD 2020)* **progresso compartilhado** (`Quantidade`+`pbIniciar`/
     `pbPasso`/`pbFim` em `Positron.Data/ProgressoCompartilhado`, ligado ao Excel dos títulos e às três
     pipelines); falta a conferência visual da barra em host com GUI e o `ZWCAD`;
   - repetir a edição após o retorno MDI e no ZWCAD (ausente — medição de 2026-10-17);
   - ✅ *(rodada 214)* a unidade/alternativo **conserva** o buffer `Eletron` do layer (o `Altera` troca só as posições 2/3; o adapter recriava os quatro valores);
   - ✅ *(rodada 221, medido no AutoCAD 2020)* a **mMensagem 27** ("Não há espaço suficiente!"), nas duas
     fronteiras: a letra vizinha (`5` com limite `5A`, 2 selecionadas, duas recusas seguidas pelo laço que
     repete o prompt) e o 27/28 (destino `3` com limite `4` num caderno de 31: 27 aplica `3, 3A..3Z`, 28
     recusa) — a premissa da 186 ("precisa de 27 páginas") estava errada;
   - ✅ *(rodada 222)* a **saída anômala do `acad.exe`** (183/184/186: 51100350, 48151230,
     -840123714, 27703998) é do **host**: desenho novo + `Quit` dá 0, e o `Funcional.dwg` fechado pela
     COM dá não-zero **com o plugin desligado** (24361662) e ligado (24623806);
   - o `frmConfiguracaoBDProjeto` abre no arranque (tipo E sem banco válido) e **rouba o foco** do prompt
     nativo (medido na 186): no uso real é uma tela a mais antes de tudo — fiel ao original, conferência do dono.
   Prova e passos em `rodadas/183-paginas-editar-titulos.md`, `184-…`, `185-…`, `186-…` e `222-…`.
2. **Conferência visual dos diálogos de aviso (`MsgBox`)** na GUI: os ensaios rodam com `POSITRON_LOG`
   e, nesse modo, o `Aviso` grava no log em vez de abrir o diálogo (recorte que se repete desde a 186) —
   falta ver a janela de aviso na tela num ensaio sem `POSITRON_LOG` (com quem clique).
3. ✅ *(rodada 216, medido no AutoCAD 2020; falta o clique da paleta e o ZWCAD, se voltar)* **`clsApagar.ApagarDerivados`** — ramos portados: polyline (208), contato auxiliar (209), máscara (210) e, na 216, o dispositivo principal `P` (`promoveComplementar` `:286` e `ApagaContatosModeloDispositivo` `:151`).
4. **Telas só-casca mais baratas** cuja regra cabe numa rodada (lista: `cobertura-do-reverso.ps1 -Listas`):
   ✅ *(rodada 217, `frmEstatisticaDeCabos`; a ponte de Excel dela saiu na 218)*; falta a conferência
   **visual** contra `estimativa de cabos utilizados por formação.png`; depois, a próxima leva da lista
   `-Listas`.
5. **Seção e cor ativas da barra** (`ListaDeSecao`/`CampoDeCor`, `Ribbon.cs:971,2264`; `My.Settings.Secao`/`Cor`):
   o padrão dos prompts do `EDCON`/`EDCONP` (hoje fixo em `1,5`/`PT`) e do `INSM`/`CON` — saiu da rodada 176.
6. **Comandos de regra pura sem nada no plugin** (48) — pegar os que a triagem do `PLANO.md` §7.6
   **não** marcou como fora do recorte/ambiente, começando pelos de edição das frentes 3–9.
7. **Contínuo:** os 42 rótulos/ícones da barra (`../reverso-barra-do-original.txt`) entram na rodada
   que portar o comando de cada um.
8. **Contínuo (ambiente):** **medir antes de afirmar ausência** de CAD, host ou arquivo do projeto —
   registro + pastas + `where` (`RUNBOOK.md` → *Existe CAD nesta máquina?*, medido em 2026-10-16). Os
   documentos de rodadas antigas que dizem "o AutoCAD 2020 não está instalado" levaram essa correção:
   ele **está** (`C:\Program Files\Autodesk\AutoCAD 2020`) e a ausência **do ZWCAD** é medição desta
   data, não afirmação permanente.
9. **Ponte de Excel:** ✅ *(rodada 218: o `btExportaEXCEL` do `frmEstatisticaDeCabos` — `Relatorios_EstatisticaCaboEXCEL`
   — escrevendo na aba **nomeada** `DIF_*` por `VerificaExcel`/`ApagaFigura`/`LimpaSheet`)*; a ponte do
   `frmEditaTitulos` já estava provada viva (rodada 215, 2026-10-16). Faltam os **demais botões de Excel do
   produto** (as 19 sub-janelas de exportação DWG/Excel do reverso) e o **clique físico** no botão da
   estatística (o harness roda a mesma ação): a receita da medição (Excel visível, `accoreconsole`, o
   `Weight = 3`/`HorizontalAlignment = 3` que o Excel normaliza) está no `RUNBOOK.md`.

## Depende do dono (não começar sem decisão)

- Relatórios tabulares restantes (9b, `PLANO.md` §7.3).
- **Banco Access do projeto (1a):** o original lê o `.mdb`/`.accdb` direto; o plugin só lê SQLite. Ler o Access (OleDb/ACE no plugin) ou exigir a conversão para `.db`?
- **Banco multiusuário / SQL Server (9c):** ✅ **Decisão do dono (2026-10-16):** Adiado para depois da conclusão do recode do plugin. O foco da fase de teste e recode continua no banco de arquivo monousuário (SQLite/Access). A tela fiel `frmConfiguracaoGeral` continua gravando os campos no XData normalmente, sem conexão de dados ativa.

## Últimas rodadas

| rodada | data | commit | resumo | arquivo |
|---|---|---|---|---|
| 222 | 2026-10-17 | *(este)* | fechar a 183 pela **GUI**: o **clique físico** na célula Página (mouse e teclado do Windows no Timer do WinForms — `7` → `7A` com despejo independente), os **quatro atalhos** `lb1..lb4` e o Xrecord `CENG_ELET`/`Atalhos` de seis strings (slot 3 limpo pelo clique inexistente, captura pelo `btSalva`+`lb4`, os slots 5/6 preservados), o **título 4** no editor (atributo `TITULO4PAG` no formato + `DBText` de índice 4) e o **documento tipo D** (desenho novo com `DiagLog` no ModelSpace: menu ausente, grade somente leitura, Alternativo oculto); a medição achou e **corrigiu** a seleção atrasada do DataGridView (renomear a página ativa terminava na página **seguinte**) e provou que a **saída não-zero do `acad.exe` é do host** (sem o plugin, 24361662; com ele, 24623806; desenho novo + `Quit`, 0); 1083 testes, builds 0 avisos; harness e fixture novos (`EntradaFisicaDaProva`, `Titulo4DaProva`, `cad-fixture-clique222.lsp`) | `rodadas/222-gui-clique-fisico-e-atalhos.md` |
| 221 | 2026-10-17 | `a9f62003` | **mMensagem 27** ("Não há espaço suficiente!") medida no CAD — a premissa da 186 corrigida (não precisa de 27 páginas: a fronteira de **letra**, `5` com limite `5A`, esgota os dois espaços com 2 selecionadas) e as duas fronteiras provadas no **AutoCAD 2020 accoreconsole** (a letra vizinha: 2 recusas seguidas — o laço **repete** o prompt — e o dump independente idêntico; o número vizinho num caderno de 31 páginas: 27 aplica `3, 3A..3Z` com o XData `Eletron` preservado, 28 recusa); fixture nova `cad-fixture-msg27.lsp` e +1 teste (1083), builds 0 avisos; nenhuma mudança de código de produto | `rodadas/221-mensagem-27-sem-espaco.md` |
| 220 | 2026-10-17 | `8bde36d2` | progresso compartilhado da paleta: `ProgressoCompartilhado` (o `Quantidade` + `pbIniciar`/`pbPasso`/`pbFim` do `uscPaginas`, com os padrões do WinForms e o estado `PBST_ERROR` da mensagem 1040) + a paleta espelhando no `ProgressBar1` e o `PaletaDeFolhas.Progresso*` como o `_uscPagina` + as três pipelines (SYNCD/SYNCV/RESTPROJ, com o quirk do `RESTPROJ`) e o Excel ativo dos títulos ligados; **sai** o progresso que o `Carregar()` movia sem prova no reverso; +10 testes (1082), builds 0 avisos; medido no **AutoCAD 2020 accoreconsole** (a barra do comando lida no `ProgressBar1` da paleta: `0..4` no `SYNCD`, `0..3` no `SYNCV`, o `Maximum` herdado no `RESTPROJ` e a exportação de 15 páginas no Excel movendo `0..100 → 0..14 → 0..0`) | `rodadas/220-progresso-compartilhado.md` |
| 219 | 2026-10-17 | `67a92ada` | status do banco na paleta pelo contador de conexões: `MonitorDeConexao` (o `monitorConexao`/`statusBanco` do reverso, monitor da sessão em `Atual`) + `ProjectStore.Abrir()` incrementando e o `Disposed` decrementando + a paleta trocando o `PictureBox2` no aviso + o `IniciarDWG` reiniciando por ativação; +4 testes (1072), builds 0 avisos; medido no **AutoCAD 2020 accoreconsole** (a carga da paleta pelo caminho real sem `POSITRON_DWG` abre e fecha conexão, leitura direta de 3 DWG/2 painéis, e o `IniciarDWG` zera o contador) | `rodadas/219-status-banco-contador-conexoes.md` |
| 218 | 2026-10-16 | `de1acafd` | `btExportaEXCEL` do `frmEstatisticaDeCabos` ligado à regra: `ExcelDaEstatisticaDeCabos` (a aba `DIF_FORMACAO`/`DIF_FUNCAO`/`DIF_TRAJETO` pelo `TrocaBarra`, o cabeçalho `'#Cabos`/grupo/`'Comprimento` e a faixa `A2:C{n}`, com os literais/quirks do original) + as folhas COM comuns às duas pontes (`ExcelDoReverso`) + o adapter com `VerificaExcel`/`ApagaFigura`/`LimpaSheet`; +8 métodos (1068 testes), builds 0 avisos; **medido no AutoCAD 2020 com o Excel 16.0 visível** (aba suja limpa, imagem apagada, larguras 12/40/15, negrito, valores; aba nova depois da última; convergência; grade vazia; Excel fechado; ponte dos títulos remedida) | `rodadas/218-excel-da-estatistica-de-cabos.md` |
| 217 | 2026-10-16 | `4050bf7a` | `frmEstatisticaDeCabos` (`ESTVCABOS`) ligada à regra: `EstatisticaDeCabos` (cabos com veia em uso, um por tag, agrupamento por formação/função/trajeto, soma do comprimento do cabo — o `LeTodosOsCabosEmUso` + `Hpgk6bJ1Ce`) e a ligação com os três radios (habilitados só com linha) e as larguras 90/70%/30%; +7 testes (1056), builds 0 avisos; medido no **AutoCAD 2020** nos três agrupamentos e no radio desabilitado; cobertura 23 de 127 telas com regra | `rodadas/217-estatistica-de-cabos.md` |
| 216 | 2026-10-16 | `29ed6889` | ramos do dispositivo principal `P` do `ApagarDerivados` (`promoveComplementar` e `ApagaContatosModeloDispositivo`): regra pura `ApagarDispositivo` + casca; +7 testes (1049); builds 0 avisos; medido no **AutoCAD 2020** (promoção, contatos por tipo e painel, complementar de outro nome fica) | `rodadas/216-apagar-derivados-dispositivo-principal.md` |
| 215 | 2026-10-16 | `2edf4696` + `774dd95c` | Excel ativo do `frmEditaTitulos`: exportar/importar pela PIA do Excel aberto (regra pura `ExcelDosTitulos` + adapter Interop + ligação do menu); +15 testes (1042 pelo runner xUnit), build AutoCAD 0 erros; **prova viva feita** depois de o dono ativar o Office (exportação de 15 páginas na aba; importação com 1 célula e depois **0** — a grade convergiu; ciclo Excel → grade → Excel fechado) | `rodadas/215-excel-ativo-dos-titulos.md` |
| 214 | 2026-10-16 | `58236768` | unidade/alternativo **conserva** o buffer XData `Eletron` do layer (`Atualizar`: sem XData cria os quatro; com a marca troca **só** as posições 2/3; outra marca não escreve) — como o `AlteraXDataUnidadeAlternativo` do reverso; +5 testes (1025), builds 0 avisos; medido no **AutoCAD 2020** com um `1000 EXTRA-214` + `1070 214` postos no layer `6` (sobrevivem à gravação) | `rodadas/214-unidade-buffer-eletron-preservado.md` |
| 213 | 2026-10-16 | `402dcf97` | edição inline da célula Página: medido o **evento real** da grade (`inline-evento`: `BeginEdit`/`EndEdit` → `CellEndEdit`; o `Carregar()` dentro do evento não estoura) e o **CONT/FL/TOT** do rename com sentinelas (`6/5 → 7A`, `7/6 → 7A`, `7/7 → 1000`); 1020 testes, builds 0 avisos; sem regra nova | `rodadas/213-inline-evento-e-cont-fl-tot.md` |
| 212 | 2026-10-16 | `402dcf97` | paleta `uscPaginas`, **edição inline da célula Página** (item 1 da fila): regra pura `RenomeacaoInlineDaPagina` (validação, `montaNumeroPagina`, `LayerValido`, mMensagem 28, capa e o quirk do vazio), rename pelo `PaginasDoDesenho.Renomear`, aviso em `MsgBox`; +12 testes (1020), builds 0 avisos; medido no **AutoCAD 2020 accoreconsole** (rename 7→7A com dump independente do XData preservado, já-existe, capa e vazio) | `rodadas/212-edicao-inline-celula-pagina.md` |

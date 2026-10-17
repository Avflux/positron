# Recoder — estado e fila

> **Só estado e fila.** A narrativa de cada rodada fica em `rodadas/NNN-slug.md`; os fatos do
> reverso em `conhecimento/`. Fluxo completo: skill `recoder` (`.claude/skills/recoder/SKILL.md`).
> Histórico até a rodada 175: `../PLANO.md` §5 e as seções "Rodada N" do `../RUNBOOK.md`.

## Estado (2026-10-16, depois da rodada 218)

| | valor |
|---|---|
| última rodada | **218** |
| comandos no plugin | **77** escritos à mão (53 do reverso + 24 nossos) + **115** gerados (só abrem a tela) |
| comandos do reverso sem nada no plugin | **48** (todas regra pura; triagem em `../PLANO.md` §7.6) |
| telas `frm*` do reverso | **127**; **23** com a ligação à regra; 19 que nenhum comando abre |
| testes (console xUnit; adaptador de `plugin:test` indisponível) | **1068** |
| builds ZWCAD / AutoCAD | 0 avisos |
| botões da barra cobertos | **126** de 161 acionáveis |
| host CAD medido | **AutoCAD 2020** — instalado e **verificado** em 2026-10-16 (registro + pastas + `where`; a nota do `RUNBOOK` que dizia o contrário foi corrigida); **ZWCAD ausente** nesta data, também verificado (medido na 211 quando estava) |

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
   - edição inline da célula Página: falta o **clique físico** com a janela da paleta visível e
     repetir no ZWCAD quando ele voltar (o evento real e o CONT/FL/TOT foram medidos na 213);
   - ✅ *(rodada 215, prova viva em 2026-10-16)* Excel ativo do `frmEditaTitulos`: exportação (15 páginas, 6 colunas com título) e importação medidas no AutoCAD 2020 com o Excel aberto (1 célula na 1ª importação e **0** na 2ª — a grade convergiu; a aba devolve o valor importado). O que faltou virou item próprio na fila;
   - status do banco ligado ao contador de conexões; progresso compartilhado pelas rotinas longas;
   - título 4/D/A/V e os seis atalhos em GUI; repetir edição após o retorno MDI e no ZWCAD;
   - ✅ *(rodada 214)* a unidade/alternativo **conserva** o buffer `Eletron` do layer (o `Altera` troca só as posições 2/3; o adapter recriava os quatro valores);
   - `medir a mMensagem 27` no CAD precisa de um desenho com 27 páginas (o `Funcional.dwg` tem 16);
   - **saída anômala do `acad.exe`** no fim do ensaio de GUI (183/184/186: 51100350, 48151230,
     -840123714, 27703998 — nunca zero): investigar a causa;
   - o `frmConfiguracaoBDProjeto` abre no arranque (tipo E sem banco válido) e **rouba o foco** do prompt
     nativo (medido na 186): no uso real é uma tela a mais antes de tudo.
   Prova e passos em `rodadas/183-paginas-editar-titulos.md`, `184-…`, `185-…` e `186-…`.
2. ✅ *(rodada 216, medido no AutoCAD 2020; falta o clique da paleta e o ZWCAD, se voltar)* **`clsApagar.ApagarDerivados`** — ramos portados: polyline (208), contato auxiliar (209), máscara (210) e, na 216, o dispositivo principal `P` (`promoveComplementar` `:286` e `ApagaContatosModeloDispositivo` `:151`).
3. **Telas só-casca mais baratas** cuja regra cabe numa rodada (lista: `cobertura-do-reverso.ps1 -Listas`):
   ✅ *(rodada 217, `frmEstatisticaDeCabos`; a ponte de Excel dela saiu na 218)*; falta a conferência
   **visual** contra `estimativa de cabos utilizados por formação.png`; depois, a próxima leva da lista
   `-Listas`.
4. **Seção e cor ativas da barra** (`ListaDeSecao`/`CampoDeCor`, `Ribbon.cs:971,2264`; `My.Settings.Secao`/`Cor`):
   o padrão dos prompts do `EDCON`/`EDCONP` (hoje fixo em `1,5`/`PT`) e do `INSM`/`CON` — saiu da rodada 176.
5. **Comandos de regra pura sem nada no plugin** (48) — pegar os que a triagem do `PLANO.md` §7.6
   **não** marcou como fora do recorte/ambiente, começando pelos de edição das frentes 3–9.
6. **Contínuo:** os 42 rótulos/ícones da barra (`../reverso-barra-do-original.txt`) entram na rodada
   que portar o comando de cada um.
7. **Contínuo (ambiente):** **medir antes de afirmar ausência** de CAD, host ou arquivo do projeto —
   registro + pastas + `where` (`RUNBOOK.md` → *Existe CAD nesta máquina?*, medido em 2026-10-16). Os
   documentos de rodadas antigas que dizem "o AutoCAD 2020 não está instalado" levaram essa correção:
   ele **está** (`C:\Program Files\Autodesk\AutoCAD 2020`) e a ausência **do ZWCAD** é medição desta
   data, não afirmação permanente.
8. **Ponte de Excel:** ✅ *(rodada 218: o `btExportaEXCEL` do `frmEstatisticaDeCabos` — `Relatorios_EstatisticaCaboEXCEL`
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
| 218 | 2026-10-16 | *(este)* | `btExportaEXCEL` do `frmEstatisticaDeCabos` ligado à regra: `ExcelDaEstatisticaDeCabos` (a aba `DIF_FORMACAO`/`DIF_FUNCAO`/`DIF_TRAJETO` pelo `TrocaBarra`, o cabeçalho `'#Cabos`/grupo/`'Comprimento` e a faixa `A2:C{n}`, com os literais/quirks do original) + as folhas COM comuns às duas pontes (`ExcelDoReverso`) + o adapter com `VerificaExcel`/`ApagaFigura`/`LimpaSheet`; +8 métodos (1068 testes), builds 0 avisos; **medido no AutoCAD 2020 com o Excel 16.0 visível** (aba suja limpa, imagem apagada, larguras 12/40/15, negrito, valores; aba nova depois da última; convergência; grade vazia; Excel fechado; ponte dos títulos remedida) | `rodadas/218-excel-da-estatistica-de-cabos.md` |
| 217 | 2026-10-16 | `4050bf7a` | `frmEstatisticaDeCabos` (`ESTVCABOS`) ligada à regra: `EstatisticaDeCabos` (cabos com veia em uso, um por tag, agrupamento por formação/função/trajeto, soma do comprimento do cabo — o `LeTodosOsCabosEmUso` + `Hpgk6bJ1Ce`) e a ligação com os três radios (habilitados só com linha) e as larguras 90/70%/30%; +7 testes (1056), builds 0 avisos; medido no **AutoCAD 2020** nos três agrupamentos e no radio desabilitado; cobertura 23 de 127 telas com regra | `rodadas/217-estatistica-de-cabos.md` |
| 216 | 2026-10-16 | `29ed6889` | ramos do dispositivo principal `P` do `ApagarDerivados` (`promoveComplementar` e `ApagaContatosModeloDispositivo`): regra pura `ApagarDispositivo` + casca; +7 testes (1049); builds 0 avisos; medido no **AutoCAD 2020** (promoção, contatos por tipo e painel, complementar de outro nome fica) | `rodadas/216-apagar-derivados-dispositivo-principal.md` |
| 215 | 2026-10-16 | `2edf4696` + `774dd95c` | Excel ativo do `frmEditaTitulos`: exportar/importar pela PIA do Excel aberto (regra pura `ExcelDosTitulos` + adapter Interop + ligação do menu); +15 testes (1042 pelo runner xUnit), build AutoCAD 0 erros; **prova viva feita** depois de o dono ativar o Office (exportação de 15 páginas na aba; importação com 1 célula e depois **0** — a grade convergiu; ciclo Excel → grade → Excel fechado) | `rodadas/215-excel-ativo-dos-titulos.md` |
| 214 | 2026-10-16 | `58236768` | unidade/alternativo **conserva** o buffer XData `Eletron` do layer (`Atualizar`: sem XData cria os quatro; com a marca troca **só** as posições 2/3; outra marca não escreve) — como o `AlteraXDataUnidadeAlternativo` do reverso; +5 testes (1025), builds 0 avisos; medido no **AutoCAD 2020** com um `1000 EXTRA-214` + `1070 214` postos no layer `6` (sobrevivem à gravação) | `rodadas/214-unidade-buffer-eletron-preservado.md` |
| 213 | 2026-10-16 | `402dcf97` | edição inline da célula Página: medido o **evento real** da grade (`inline-evento`: `BeginEdit`/`EndEdit` → `CellEndEdit`; o `Carregar()` dentro do evento não estoura) e o **CONT/FL/TOT** do rename com sentinelas (`6/5 → 7A`, `7/6 → 7A`, `7/7 → 1000`); 1020 testes, builds 0 avisos; sem regra nova | `rodadas/213-inline-evento-e-cont-fl-tot.md` |
| 212 | 2026-10-16 | `402dcf97` | paleta `uscPaginas`, **edição inline da célula Página** (item 1 da fila): regra pura `RenomeacaoInlineDaPagina` (validação, `montaNumeroPagina`, `LayerValido`, mMensagem 28, capa e o quirk do vazio), rename pelo `PaginasDoDesenho.Renomear`, aviso em `MsgBox`; +12 testes (1020), builds 0 avisos; medido no **AutoCAD 2020 accoreconsole** (rename 7→7A com dump independente do XData preservado, já-existe, capa e vazio) | `rodadas/212-edicao-inline-celula-pagina.md` |
| 211 | 2026-10-16 | `f767cb6d` | medição no **ZWCAD 2026** dos três ramos do `ApagarDerivados` (interligação, contato auxiliar, máscara): fixture `cad-fixture-apagar-derivados.lsp`, todos conferem com o original; índices de leitura da máscara provados | `rodadas/211-medir-apagar-derivados-zwcad.md` |
| 210 | 2026-10-16 | `bac5de5e` | `ApagarDerivados`, ramo da máscara (`ApagaAMascara`): sucessora promovida com o estado da apagada, demais apontam para ela, portas/definições saem ou reapontam; layouts de XData de 29/18/5 valores; +11 testes; 1008 testes, builds 0 avisos | `rodadas/210-apagar-derivados-mascara.md` |
| 208 | 2026-10-16 | `8bc77678` | `ApagarDerivados`, ramo da polyline de interligação `Tipo 2` (irmã por handle + rótulos `AUXINTERLIG`/`ELETROSUL`), chamado na exclusão de página; +9 testes; 984 testes, builds 0 avisos | `rodadas/208-apagar-derivados-interligacao.md` |

# Recoder — estado e fila

> **Só estado e fila.** A narrativa de cada rodada fica em `rodadas/NNN-slug.md`; os fatos do
> reverso em `conhecimento/`. Fluxo completo: skill `recoder` (`.claude/skills/recoder/SKILL.md`).
> Histórico até a rodada 175: `../PLANO.md` §5 e as seções "Rodada N" do `../RUNBOOK.md`.

## Estado (2026-10-16, depois da rodada 205)

| | valor |
|---|---|
| última rodada | **205** |
| comandos no plugin | **78** escritos à mão (53 do reverso + 25 nossos) + **115** gerados (só abrem a tela) |
| comandos do reverso sem nada no plugin | **48** (todos regra pura; triagem em `../PLANO.md` §7.6) |
| telas `frm*` do reverso | **127**; **22** com a ligação à regra; 19 que nenhum comando abre |
| testes (console xUnit; adaptador de `plugin:test` indisponível) | **975** |
| builds ZWCAD / AutoCAD | 0 avisos |
| botões da barra cobertos | **126** de 161 acionáveis |
| host CAD medido | AutoCAD (interface cheia + `accoreconsole`); o ZWCAD não está instalado nesta máquina (2026-10-16) |

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
5. 🟡 *(rodadas 188–205: `frmConfiguracaoBDProjeto`, `frmEstimativaVeiasLivres`, `frmEditaConexao`, `frmPesquisaVeiasIndefinidas`, `frmPesquisaCabos`, `frmEditaTitulosTextos`, `frmEstatisticaDeBornes` `frmEditaRevisaoSimplificada` `frmEditaRevisaoCompleta` `frmEditaTitulos` `frmPesquisaXdatas` as três `frmCompilar*` `frmGerenciadorMascaras` `frmGerenciadorContatos` `frmSplash` `frmRelatorio_Materiais` `frmRelatorio_Veias` e `frmGerenciadorMateriais` feitas; faltam as outras)* **Auditoria das 20 telas ligadas e das telas feitas à mão**, comparando controle a controle com o
   designer e a captura, atrás de invenções do mesmo tipo. O que aparecer vira item aqui.

## Fila (depois da correção do básico; uma rodada por item, na ordem)

1. **Fechar a rodada 183 (Páginas / Editar os Títulos)** — o que sobrou:
   - Excel ativo (`clsTextos.ExportaPaginas/ImportaTitulos`, exportar/importar por página/índice);
   - **renumeração inline** da célula Página (primeira linha protegida) e o status do banco ligado ao
     contador de conexões; progresso compartilhado pelas rotinas longas;
   - título 4/D/A/V e os seis atalhos em GUI; repetir edição após o retorno MDI e no ZWCAD;
   - auditar a preservação de extensões no buffer `Eletron`/`Unidade` (o adapter recria quatro valores);
   - `medir a mMensagem 27` no CAD precisa de um desenho com 27 páginas (o `Funcional.dwg` tem 16);
   - **saída anômala do `acad.exe`** no fim do ensaio de GUI (183/184/186: 51100350, 48151230,
     -840123714, 27703998 — nunca zero): investigar a causa;
   - o `frmConfiguracaoBDProjeto` abre no arranque (tipo E sem banco válido) e **rouba o foco** do prompt
     nativo (medido na 186): no uso real é uma tela a mais antes de tudo.
   Prova e passos em `rodadas/183-paginas-editar-titulos.md`, `184-…`, `185-…` e `186-…`.
2. **`clsApagar.ApagarDerivados`** (`clsApagar.cs:9`), chamado pelo `ApagarElementosPagina` antes do
   `Erase` — a polyline irmã de interligação tipo 2, a máscara, a inserção do contato auxiliar e os
   contatos de modelo / complementar do dispositivo principal (saiu da rodada 182).
3. **Telas só-casca mais baratas** cuja regra cabe numa rodada (lista: `cobertura-do-reverso.ps1 -Listas`):
   `frmEstatisticaDeCabos` (`ESTVCABOS`); depois, a próxima leva da lista `-Listas`.
4. **Seção e cor ativas da barra** (`ListaDeSecao`/`CampoDeCor`, `Ribbon.cs:971,2264`; `My.Settings.Secao`/`Cor`):
   o padrão dos prompts do `EDCON`/`EDCONP` (hoje fixo em `1,5`/`PT`) e do `INSM`/`CON` — saiu da rodada 176.
5. **Comandos de regra pura sem nada no plugin** (48) — pegar os que a triagem do `PLANO.md` §7.6
   **não** marcou como fora do recorte/ambiente, começando pelos de edição das frentes 3–9.
6. **Contínuo:** os 42 rótulos/ícones da barra (`../reverso-barra-do-original.txt`) entram na rodada
   que portar o comando de cada um.

## Depende do dono (não começar sem decisão)

- Relatórios tabulares restantes (9b, `PLANO.md` §7.3).
- **Banco Access do projeto (1a):** o original lê o `.mdb`/`.accdb` direto; o plugin só lê SQLite. Ler o Access (OleDb/ACE no plugin) ou exigir a conversão para `.db`?
- **Banco multiusuário / SQL Server (9c):** ✅ **Decisão do dono (2026-10-16):** Adiado para depois da conclusão do recode do plugin. O foco da fase de teste e recode continua no banco de arquivo monousuário (SQLite/Access). A tela fiel `frmConfiguracaoGeral` continua gravando os campos no XData normalmente, sem conexão de dados ativa.

## Últimas rodadas

| rodada | data | commit | resumo | arquivo |
|---|---|---|---|---|
| 205 | 2026-10-16 | *(este)* | auditoria da `frmGerenciadorMateriais`: guarda 331, cabeçalho/larguras e colunas escondidas do original, ações silenciosas, "Salvar Alterações?" ao fechar, erro em `MsgBox`; saem as linhas `GERLM:` e dicas inventadas; builds 0 avisos, testes não rodados (só casca) | `rodadas/205-auditoria-gerenciador-materiais.md` |
| 204 | 2026-10-16 | `96b17960` | auditoria da `frmRelatorio_Veias`: `dgVeias` sem colunas até o `btPesquisar`, dica do original, `CKAgrupar` desmarcado; saem dicas e linhas `LVEI:` inventadas; builds 0 avisos, testes não rodados (só casca) | `rodadas/204-auditoria-relatorio-veias.md` |
| 203 | 2026-10-16 | `116e7939` | auditoria da `frmRelatorio_Materiais`: grades sem colunas até haver dados, lista só no `btPesquisar`, dicas e controles escondidos como no construtor; saem dicas e linhas `EXPLM:` inventadas; builds 0 avisos, testes não rodados (só casca) | `rodadas/203-auditoria-relatorio-materiais.md` |
| 202 | 2026-10-16 | `bb4b3a34` | auditoria da `frmSplash`: saem o fechamento por clique/tecla e as mensagens do `OFFSPL`, que o original não tem; builds 0 avisos, testes não rodados (só casca) | `rodadas/202-auditoria-splash.md` |
| 201 | 2026-10-16 | `3fee7071` | auditoria da `frmGerenciadorContatos`: guarda 331, grades sem colunas quando vazias e com cabeçalhos/larguras do original, dicas pelas mMensagens, `LbTerminais` e cor dos blocos; saem dicas e linhas inventadas (inclui `MODELOS:` da base); builds 0 avisos, testes não rodados (só casca) | `rodadas/201-auditoria-gerenciador-contatos.md` |
| 200 | 2026-10-16 | `097fdc5c` | auditoria da `frmGerenciadorMascaras`: guarda 331, grades sem colunas quando vazias e com os cabeçalhos/larguras do original, dicas pelas mMensagens, cor dos blocos; saem dicas e linha inventadas; builds 0 avisos, testes não rodados (só casca) | `rodadas/200-auditoria-gerenciador-mascaras.md` |
| 199 | 2026-10-16 | `3e1e906d` | auditoria das três telas `frmCompilar*` (base `LigacaoDeCompilacao`): guarda 331, dicas pelas mMensagens, `dgRevisao` Revisão/Criador/Data, `dgERROS` vazia na abertura, 761 para revisão vazia; saem dicas e linhas inventadas; builds 0 avisos, testes não rodados (só casca) | `rodadas/199-auditoria-compilar-telas.md` |
| 198 | 2026-10-16 | `95d3b85e` | auditoria da `frmPesquisaXdatas`: resultado do apagar em `MsgBox`, `LockDocument` no apagar, larguras 70/30 e limites de tamanho; sai a linha inventada; builds 0 avisos, testes não rodados (só casca) | `rodadas/198-auditoria-pesquisa-xdatas.md` |
| 197 | 2026-10-16 | `ddf3acf2` | auditoria da `frmEditaTitulos`: saem 2 linhas inventadas e a rolagem extra, `MsgBox` sem título como no original; builds 0 avisos, testes não rodados (só casca) | `rodadas/197-auditoria-edita-titulos.md` |
| 196 | 2026-10-16 | `ea7e928e` | auditoria da `frmEditaRevisaoCompleta`: faixa `CCapa`..`CCorpo`, `restauraCampos`, larguras percentuais, DE/PARA, gravação com `LockDocument` e `MsgBox`; saem 2 linhas inventadas; builds 0 avisos, testes não rodados (só casca) | `rodadas/196-auditoria-edita-revisao-completa.md` |

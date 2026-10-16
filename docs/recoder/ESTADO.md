# Recoder — estado e fila

> **Só estado e fila.** A narrativa de cada rodada fica em `rodadas/NNN-slug.md`; os fatos do
> reverso em `conhecimento/`. Fluxo completo: skill `recoder` (`.claude/skills/recoder/SKILL.md`).
> Histórico até a rodada 175: `../PLANO.md` §5 e as seções "Rodada N" do `../RUNBOOK.md`.

## Estado (2026-10-15, depois da rodada 185)

| | valor |
|---|---|
| última rodada | **185** |
| comandos no plugin | **78** escritos à mão (53 do reverso + 25 nossos) + **115** gerados (só abrem a tela) |
| comandos do reverso sem nada no plugin | **48** (todos regra pura; triagem em `../PLANO.md` §7.6) |
| telas `frm*` do reverso | **127**; **21** com a ligação à regra; 19 que nenhum comando abre |
| testes (console xUnit; adaptador de `plugin:test` indisponível) | **953** |
| builds ZWCAD / AutoCAD | 0 avisos |
| botões da barra cobertos | **126** de 161 acionáveis |
| host CAD medido | AutoCAD 2020 (interface cheia + `accoreconsole`); o ZWCAD não está instalado nesta máquina (2026-10-15) |

Números de cobertura: `powershell -ExecutionPolicy Bypass -File scripts/cobertura-do-reverso.ps1`.

## Frentes

| frente | situação |
|---|---|
| 1 — base e pipelines (`FIA`/`INT`/`JMP`/`VERIF`/`SYNCD`) | ✅ |
| 2 — correções e limpeza do CAD | ✅ 37 de 38 (o `CorrigeJanelas` é ambiente) |
| 3–9 — edição (réguas, dispositivos, fiação, cabos, materiais, exportação) | triadas (`PLANO.md` §7.6); portar comando a comando |
| 10 — páginas e caderno | ✅ (cadeia do `CAD` fechada na 175) |
| 11 — shell (arranque, paleta, barra, autoload) | ✅ |
| 12 — as 127 telas | todas abrem; 20 com regra ligada |
| relatórios (9b) · SQL Server (9c) | ⏳ decisão do dono |
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
3. **Paleta de folhas fiel ao `uscPaginas`** (`uscPaginas.cs:987-1497`, `paginas.png`, `paginas1.png`).
   - Sair: o rodapé inventado, a coluna `PgAtiva`, o negrito, as dicas e o Alternativo ligado por padrão
     (o original lê o registro `Altern`, padrão `"0"`).
   - Corrigir: a ordem Página | Unidade | Alternativo, o texto "Apagar Páginas" (mMensagem 21) e
     `MultiSelect=false`.
   - Entrar: a faixa de cima (`tbPagina`/Enter, `lb1..lb4`, status do banco, `btSalva`), a barra de
     progresso e o logo.
4. **Configuração geral fiel.** O `CFG` da barra hoje abre o `ELETCFG`, feito à mão
   (`BarraDeFerramentas.cs:63`, `FormularioConfiguracao.cs`).
   - Ligar a `frmConfiguracaoGeral` (`frmConfiguracaoGeral.cs:2529-4600`; capturas `configuração geral 1-3.png`).
   - Ela grava o XData (`GravarXDataConfiguracao`/`2`) e o idioma no registro (`:3904-3910`).
   - Inclui o bloco SQL Server; tira o grupo "Projeto" (DWG/Revisão/Log).
   - Leva ao XData a norma IEC/ANSI, o Log Func e a representação cabo/veia, que hoje não chegam lá.
5. **Auditoria das 20 telas ligadas e das telas feitas à mão**, comparando controle a controle com o
   designer e a captura, atrás de invenções do mesmo tipo. O que aparecer vira item aqui.

## Fila (depois da correção do básico; uma rodada por item, na ordem)

1. **Fechar a rodada 183 (Páginas / Editar os Títulos):** GUI AutoCAD validada (menu, descarte,
   aplicação fora de comando, Alternativo, novo DWG e retorno); falta repetir no ZWCAD e exercitar
   título 4/D/A/V e todos os atalhos. `Pagina.restauraCampos` específico portado na **184**;
   falta medir sem formato/rollback/colunas/configuração em fixture e investigar saída anômala
   do AutoCAD GUI. Portar Excel ativo; completar Renumerar lote/inline,
   combo de largura e status de conexões/progresso. Prompts Unidade/Alternativo em multiseleção
   portados e medidos na **185** (core e GUI/fora de comando, cancelamento/padrão; novo DWG sem menu,
   retorno MDI). Falta repetir edição após retorno e no ZWCAD; auditar preservação de extensões
   no buffer Eletron/Unidade (o adapter atual recria quatro valores).
   Prova e passos em `rodadas/183-paginas-editar-titulos.md`; não dar o item 3 do básico por encerrado.
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
- **Banco Access do projeto:** o original lê o `.mdb`/`.accdb` direto; o plugin só lê SQLite. Ler o Access (OleDb/ACE no plugin) ou exigir a conversão para `.db`?
- Banco multiusuário / SQL Server (9c). A tela de configuração fiel mostra os campos do SQL Server, como
  o original; a conexão em si continua dependendo desta decisão.

## Últimas rodadas

| rodada | data | commit | resumo | arquivo |
|---|---|---|---|---|
| 185 | 2026-10-15 | *(este)* | prompts nativos Unidade/Alternativo pelo menu, 2 páginas/14 preservadas, 4 campos recalculados; 953 testes e builds sem avisos; GUI com novo DWG/retorno, host final exit 0 | `rodadas/185-unidade-alternativo-da-paleta.md` |
| 184 | 2026-10-15 | `70c05d8a` | restauraCampos específico antes do editor, sem cadeia da troca de formato; 947 testes, core e paleta não modal medidos; limites de GUI/host registrados | `rodadas/184-restaurar-campos-do-editor.md` |
| 183 | 2026-10-15 | `e959d0dd` | Páginas sem rodapé inventado; cabeçalho/atalhos/Altern; grade não modal Editar os Títulos, 15 páginas/51 textos medidos; GUI AutoCAD validada com clique, descarte e troca MDI; recortes funcionais pendentes | `rodadas/183-paginas-editar-titulos.md` |
| 182 | 2026-10-15 | `d6d1466d` | folhas pela paleta: `Inserir` de colunas `ELET1..5`, `Nova Página` pela linha selecionada, `Apagar Páginas` com confirmação/capa/sincronizações, `LockDocument` e Insert/Delete | `rodadas/182-folhas-inserir-apagar.md` |
| 181 | 2026-10-15 | `0547e4c8` | resto do `IniciarDWG`: painéis da barra pelo tipo do desenho, `Romans`, as 5 correções com a marca `CORRECAO`, camadas destravadas e página ativa ao abrir | `rodadas/181-resto-do-iniciardwg.md` |
| 180 | 2026-10-15 | `49d06e51` | projeto por desenho: sai o `positron.ini`; banco e DWG do desenho ativo; `DocumentActivated`; `frmConfiguracaoBDProjeto` ligada | `rodadas/180-projeto-por-desenho.md` |
| 179 | 2026-10-15 | `86907aaf` | `TROCTT`: troca DE → PARA em títulos 1..4, textos e multitextos das páginas escolhidas | `rodadas/179-edita-titulos-textos.md` |
| 178 | 2026-10-15 | `e3c69237` | `PESQCAB`: cabos do catálogo (deste DWG e de outros), veias com o `OrdenaVeias`, ir até a veia; `TCHAVE` fora (licença) | `rodadas/178-pesquisa-cabos.md` |
| 177 | 2026-10-15 | `e4f19340` | `PESQC`: veias indefinidas na grade, ir até a veia (página, zoom, realce) | `rodadas/177-pesquisa-veias-indefinidas.md` |
| 176 | 2026-10-15 | `054b001a` | `EDCON`/`EDCONP`: seção e cor das conexões por seleção e por página, tela ligada | `rodadas/176-edicao-secao-cor-conexoes.md` |

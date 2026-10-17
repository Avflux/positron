using System;
using System.Collections.Generic;
using Positron.Contract;
using Positron.Data;
using Positron.Data.Cabos;
using Positron.Data.Bornes;
using Positron.Data.Configuracao;
using Positron.Data.Fiacao;
using Positron.Data.Interligacao;
using Positron.Data.Layout;
using Positron.Data.Materiais;
using Positron.Data.Modelos;
using Positron.Data.Paginas;
using Positron.Data.Plaquetas;
using Positron.Data.Relatorios;
using Positron.Data.TrocaDeBlocos;
using Positron.Plugin.Bornes;
using Positron.Plugin.Fiacao;
using Positron.Plugin.Interligacao;
using Positron.Plugin.Layout;
using Positron.Plugin.Modelos;
using Positron.Plugin.Plaquetas;
#if AUTOCAD
using Autodesk.AutoCAD.Runtime;
#else
using ZwSoft.ZwCAD.Runtime;
#endif

namespace Positron.Plugin
{
    /// <summary>
    /// Comandos registrados por atributo, no mesmo padrão do assembly original
    /// (216 x <c>[CommandMethod]</c>). Fachada fina: valida e delega.
    ///
    /// Recorte atual: <c>ELET</c>, <c>FIA</c>, <c>INT</c>, <c>SYNCD</c> e
    /// <c>VERIF</c> — os nomes vêm do <c>COMANDOS.txt</c> do reverso — mais os que
    /// não existem como comando lá e foram criados como comando próprio
    /// (<c>JMP</c>, <c>ELETCFG</c>, <c>ELETREL</c> e <c>INDCABO</c>),
    /// e as tabelas fora do recorte que ganharam fluxo próprio (<c>EPLQ</c> e
    /// <c>COMPLM</c>).
    ///
    /// Depois do recorte veio a **frente 2** do §7.6 do plano (o <c>Correcao.cs</c>
    /// do reverso): as **ações de limpeza** do CAD
    /// (<c>ApagarTextosEmBranco</c>, <c>apagaXDataTerceiros</c>, <c>ApagaLayouts</c>
    /// e <c>ApagaPlaquetas</c>, rodada 70; <c>apagarTodosOsTextosDasVeias</c>,
    /// rodada 75) e as **correções** —
    /// <c>corrigeOrdemBornes</c> (a que conserta um defeito que o <c>VERIF</c> aponta,
    /// rodada 71), as de um campo <c>CorrigeBornes</c>/<c>CorrigeDisp</c>
    /// (rodada 72) e a dos estilos de texto <c>CorrigeStyle</c> (rodada 73), mais o
    /// <c>SobeLm</c> (rodada 74) — **comando próprio**, sem par no original: sobe o
    /// <c>lm</c> dos bornes a partir do dicionário de réguas, fechando a pendência
    /// do §7.2, o <c>corrigeDicMascaras</c> (rodada 76) — o dicionário de máscaras — e o
    /// <c>CorrigeContatosAux</c> (rodada 77) — o <c>HandleContatoAux</c> dos modelos.
    /// As outras <c>Corrige*</c> são o próximo passo da mesma frente.
    ///
    /// **Sem licença:** o produto é open source e nenhum comando verifica licença. O
    /// gate que existia aqui (o <c>ServicoDeLicenca</c>/<c>ILicenca</c> da rodada 29,
    /// espelho dos três provedores do original) foi removido na rodada 63 — junto com
    /// o encaixe, para não deixar no código um caminho que ninguém vai usar.
    ///
    /// **A frente 2 segue:** o <c>RENPAGA</c> entrou na rodada 134 — é o **nome do comando** do
    /// original para a renumeração das páginas que a paleta já fazia (a regra é a mesma).
    /// </summary>
    public sealed class Comandos
    {
        [CommandMethod("ELET")]
        public void Elet()
        {
            Plugin.Escrever(ExecutarJanelaDeFolhas());
        }

        /// <summary>
        /// <c>FOLHAS</c> — abre a **janela de folhas** direto (o <c>ELET</c> faz o mesmo: no
        /// reverso ele é um comando vazio e o arranque é o <c>IExtensionApplication</c>).
        /// </summary>
        [CommandMethod("FOLHAS")]
        public void Folhas()
        {
            Plugin.Escrever(ExecutarJanelaDeFolhas());
        }

        /// <summary>
        /// <c>PAG</c> — o comando do original que abre a paleta das páginas (o
        /// <c>GerenciadorPagina</c>, <c>Comandos.cs:1447</c> do reverso): no recoder, o mesmo que o
        /// <c>FOLHAS</c>.
        /// </summary>
        [CommandMethod("PAG")]
        public void Pag()
        {
            Plugin.Escrever(ExecutarJanelaDeFolhas());
        }

        /// <summary>Abre a janela de folhas e devolve a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarJanelaDeFolhas()
        {
            try
            {
                int paginas = Interface.Folhas.PaletaDeFolhas.Mostrar();

                return "Positron — paleta de folhas com " + paginas + " página(s) (ancorada no CAD).";
            }
            catch (System.Exception erro)
            {
                return "ELET: falhou — " + DescreverErro(erro) + ".";
            }
        }

        /// <summary>
        /// <c>RENPAGA</c> — a **renumeração em lote** das páginas do caderno (o <c>Correcao.cs:3273</c>
        /// do original): cada página vira <c>página + sufixo</c> e os **layers** são renomeados — o
        /// mesmo que o botão **Renumerar Páginas** da paleta faz, pela mesma regra
        /// (<see cref="PaginasDoCaderno"/>).
        ///
        /// **Uma** diferença do corpo do original, deliberada (a evidência está no XML doc da regra):
        /// o sufixo vem da variável <c>POSITRON_SUFIXO</c> (padrão `A`, o mesmo do campo da paleta) em
        /// vez do `InputBox` do original — um diálogo trava um script. A **guarda** do original
        /// (recusar o lote inteiro quando alguma página tem letra), essa é **reproduzida**
        /// (<see cref="PaginasDoCaderno.TodasNumericas"/>): sem ela, a segunda passada geraria `1AA`,
        /// que o `LayerValido` já não aceita como página.
        /// </summary>
        [CommandMethod("RENPAGA")]
        public void RenPaga()
        {
            Plugin.Escrever(ExecutarRenumeracaoDePaginas());
        }

        /// <summary>A renumeração em lote das páginas e a linha de resumo. Nunca lança.</summary>
        /// <remarks>
        /// O adapter é qualificado (`Positron.Plugin.Paginas.PaginasDoDesenho`) porque o `using` de
        /// `Positron.Plugin.Paginas` colidiria com o `Positron.Plugin.Layout.PaginasDoDesenho`, que já
        /// é usado neste arquivo — os dois nomes existem e são coisas diferentes.
        /// </remarks>
        internal static string ExecutarRenumeracaoDePaginas()
        {
            try
            {
                string sufixo = Environment.GetEnvironmentVariable("POSITRON_SUFIXO");
                if (string.IsNullOrEmpty(sufixo))
                {
                    sufixo = "A";
                }

                if (!PaginasDoCaderno.SufixoValido(sufixo))
                {
                    return "RENPAGA: o sufixo tem de ser um caractere (número ou A-Z) — POSITRON_SUFIXO=\"" + sufixo + "\".";
                }

                List<string> antigos = Positron.Plugin.Paginas.PaginasDoDesenho.Ler();
                if (antigos.Count == 0)
                {
                    return "RENPAGA: nenhuma página do caderno no desenho (os layers que o LayerValido aceita).";
                }

                // A guarda do original: com qualquer página alfabética o lote inteiro é recusado.
                if (!PaginasDoCaderno.TodasNumericas(antigos))
                {
                    return "RENPAGA: as páginas não podem conter caracter alfabético para usar esta função (o lote inteiro é recusado, como no original).";
                }

                IReadOnlyList<string> novos = PaginasDoCaderno.Renomear(antigos, sufixo);
                int renomeados = Positron.Plugin.Paginas.PaginasDoDesenho.Renomear(antigos, novos);

                return "RENPAGA: " + renomeados + " de " + antigos.Count + " página(s) renomeada(s) com o sufixo \"" + sufixo + "\".";
            }
            catch (System.Exception erro)
            {
                return "RENPAGA: falhou — " + DescreverErro(erro) + ".";
            }
        }

        /// <summary>
        /// <c>LeTodosAtributos</c> — o **buffer da troca de blocos** (o <c>clsTrocaEditaBlocos.cs</c>
        /// do original): varre o ModelSpace e guarda os atributos **invisíveis** de **todos** os
        /// blocos. É por eles que o valor atravessa a substituição de um bloco — o projetista não os
        /// vê na tela, e a troca não pode perder o que eles guardam. O buffer fica no estático do
        /// adapter, como no original (lá os comandos são disparados por <c>SendStringToExecute</c>).
        /// </summary>
        [CommandMethod("LeTodosAtributos")]
        public void LeTodosAtributos()
        {
            Plugin.Escrever(ExecutarLeituraDosAtributos("LeTodosAtributos", null));
        }

        /// <summary>
        /// <c>LeAtributos</c> — o mesmo buffer, restrito aos blocos cujo nome está no
        /// <c>POSITRON_BLOCOS</c> (lista separada por vírgula; sem a variável a leitura é a de todos
        /// os blocos). No original a lista vem da grade da tela; a varredura é a mesma.
        /// </summary>
        [CommandMethod("LeAtributos")]
        public void LeAtributos()
        {
            IReadOnlyCollection<string> nomes = NomesDeBlocoDaVariavel();
            Plugin.Escrever(ExecutarLeituraDosAtributos(
                nomes == null || nomes.Count == 0 ? "LeAtributos (sem POSITRON_BLOCOS: lê todos)" : "LeAtributos",
                nomes));
        }

        /// <summary>A leitura dos atributos invisíveis e a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarLeituraDosAtributos(string comando, IReadOnlyCollection<string> nomesDeBloco)
        {
            try
            {
                TrocaDeBlocos.AtributosDoDesenho.ResultadoDaLeitura resultado =
                    TrocaDeBlocos.AtributosDoDesenho.Ler(nomesDeBloco);

                if (resultado.BlocosLidos == 0)
                {
                    return comando + ": o ModelSpace não tem bloco nenhum.";
                }

                return comando + ": " + resultado.EntradasNoBuffer + " atributo(s) invisível(is) no buffer ("
                    + resultado.AtributosLidos + " atributo(s) em " + resultado.BlocosComAtributo + " bloco(s) de "
                    + resultado.BlocosLidos + " bloco(s) lido(s)); " + TrocaDeBlocos.AtributosDoDesenho.NomesExistentes.Count
                    + " bloco(s) com atributo(s), " + TrocaDeBlocos.AtributosDoDesenho.Buffer.Count
                    + " entrada(s) no buffer" + ExemplosDoBuffer() + ".";
            }
            catch (System.Exception erro)
            {
                return comando + ": falhou — " + DescreverErro(erro) + ".";
            }
        }

        /// <summary>
        /// <c>CorrigeAtributos</c> — aplica o buffer no desenho (o <c>EditaUmAtributoDeUmBloco</c>
        /// do original, por handle do bloco e tag) e mostra o **resumo do original**: o MsgBox dele
        /// vira linha de comando (um diálogo trava um script), com as mesmas <c>mMensagem</c>
        /// (1298/1302/1349/1299/1300/1301) e as mesmas trocas de título.
        /// </summary>
        [CommandMethod("CorrigeAtributos")]
        public void CorrigeAtributos()
        {
            Plugin.Escrever(ExecutarAplicacaoDosAtributos(true));
        }

        /// <summary>
        /// <c>CorrigeAtributosSemMsg</c> — a mesma gravação **sem** o resumo do original (é o que a
        /// tela usa quando não quer a caixa de mensagem).
        /// </summary>
        [CommandMethod("CorrigeAtributosSemMsg")]
        public void CorrigeAtributosSemMsg()
        {
            Plugin.Escrever(ExecutarAplicacaoDosAtributos(false));
        }

        /// <summary>A aplica o buffer e devolve a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarAplicacaoDosAtributos(bool comResumo)
        {
            string comando = comResumo ? "CorrigeAtributos" : "CorrigeAtributosSemMsg";
            try
            {
                if (TrocaDeBlocos.AtributosDoDesenho.Buffer.Count == 0)
                {
                    return comando + ": o buffer está vazio — rode o LeAtributos/LeTodosAtributos antes.";
                }

                TrocaDeBlocos.AtributosDoDesenho.ResultadoDaAplicacao resultado =
                    TrocaDeBlocos.AtributosDoDesenho.Aplicar();

                string medicao = "(" + resultado.AtributosAplicados + " atributo(s) gravado(s) em "
                    + resultado.BlocosCasados + " de " + resultado.Entradas + " entrada(s) do buffer; "
                    + resultado.VisibilidadesAplicadas + " visibilidade(s); "
                    + resultado.TagsNaoAchadas + " bloco(s) sem a tag; " + resultado.BlocosNaoAchados + " fora do desenho)";

                if (!comResumo)
                {
                    return comando + ": " + medicao + ".";
                }

                // O resumo do original vem do MsgBox dele — aqui ele sai na linha de comando, com as
                // mesmas mMensagem, e a medição do recoder vem ao lado, entre parênteses.
                return comando + ": " + AtributosDosBlocos.Resumo(
                    TrocaDeBlocos.AtributosDoDesenho.NomesExistentes.Count,
                    0,
                    TrocaDeBlocos.AtributosDoDesenho.BlocosNaoExistentes) + " " + medicao + ".";
            }
            catch (System.Exception erro)
            {
                return comando + ": falhou — " + DescreverErro(erro) + ".";
            }
        }

        /// <summary>
        /// <c>PreencheNovosAtributos</c> — o comando que a tela dispara **depois** da troca. Ele é
        /// dois níveis do original num só: as marcas do nome escolhem as correções
        /// (<c>frmTrocaEditaBlocos.cs:699-740</c>) — <c>_A_</c> → <c>CorrigeBlocosContatosAux</c>,
        /// <c>_B_</c> → <c>CorrigePainelET1DosBornes</c>, e <c>_A_</c> **ou** <c>_E_</c> → este
        /// comando (<c>flag | flag3</c>) — e o corpo dele (<c>clsTrocaEditaBlocos.cs:278-296</c>)
        /// percorre os blocos: <c>_E_</c> → <c>clsPortas.AtualizaAsPortasTrocadas</c> (não portado:
        /// precisa da matriz de handles que só a troca produz) e <c>_A_</c> →
        /// <c>Correcao.CorrigeContatosAux()</c>, que é o nosso <c>CorrigeContatosAux</c>.
        /// </summary>
        [CommandMethod("PreencheNovosAtributos")]
        public void PreencheNovosAtributos()
        {
            Plugin.Escrever(ExecutarPreenchimentoPosTroca());
        }

        /// <summary>O pós-troca: dispara as correções das marcas e devolve a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarPreenchimentoPosTroca()
        {
            try
            {
                if (TrocaDeBlocos.AtributosDoDesenho.NomesExistentes.Count == 0)
                {
                    return "PreencheNovosAtributos: nenhum bloco no buffer — rode o LeAtributos/LeTodosAtributos antes.";
                }

                CorrecoesPosTroca acoes =
                    AtributosDosBlocos.AcoesPosTroca(TrocaDeBlocos.AtributosDoDesenho.NomesExistentes);

                List<string> linhas = new List<string>();
                if (acoes.ContatosAuxiliares)
                {
                    linhas.Add(ExecutarCorrigirBlocosContatosAux());
                }

                if (acoes.PainelEt1)
                {
                    linhas.Add(ExecutarCorrigirPainelET1DosBornes());
                }

                if (acoes.PreencheAtributos)
                {
                    linhas.Add(ExecutarCorrigirContatosAuxiliares());

                    if (TemBlocoDosPortas())
                    {
                        linhas.Add("o ramo _E_ fica fora: o AtualizaAsPortasTrocadas precisa da matriz de "
                            + "handles que só a troca de blocos produz (não portado)");
                    }
                }

                if (linhas.Count == 0)
                {
                    return "PreencheNovosAtributos: nenhum bloco do buffer carrega as marcas _A_/_B_/_E_ — nada a preencher.";
                }

                return "PreencheNovosAtributos: " + string.Join(" ", linhas.ToArray()) + ".";
            }
            catch (System.Exception erro)
            {
                return "PreencheNovosAtributos: falhou — " + DescreverErro(erro) + ".";
            }
        }

        /// <summary>Os blocos do <c>POSITRON_BLOCOS</c> (lista separada por vírgula); <c>null</c> quando não há.</summary>
        internal static IReadOnlyCollection<string> NomesDeBlocoDaVariavel()
        {
            string valor = Environment.GetEnvironmentVariable("POSITRON_BLOCOS");
            if (string.IsNullOrEmpty(valor))
            {
                return null;
            }

            List<string> nomes = new List<string>();
            foreach (string parte in valor.Split(','))
            {
                string nome = parte.Trim();
                if (nome.Length > 0)
                {
                    nomes.Add(nome);
                }
            }

            return nomes.Count == 0 ? null : nomes;
        }

        /// <summary>Amostra do buffer (até três pares tag=valor) para a linha de comando.</summary>
        private static string ExemplosDoBuffer()
        {
            List<string> exemplos = new List<string>();
            foreach (AtributoDoBloco atributo in TrocaDeBlocos.AtributosDoDesenho.Buffer)
            {
                if (exemplos.Count == 3)
                {
                    exemplos.Add("...");
                    break;
                }

                exemplos.Add(atributo.Tag + "=" + (atributo.Valor ?? string.Empty));
            }

            return exemplos.Count == 0 ? string.Empty : "; ex: " + string.Join(", ", exemplos.ToArray());
        }

        private static bool TemBlocoDosPortas()
        {
            foreach (string nome in TrocaDeBlocos.AtributosDoDesenho.NomesExistentes)
            {
                if (AtributosDosBlocos.EhDosPortas(nome))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// <c>JANELAS</c> — abre o **seletor das janelas do reverso**: as **127 telas `frm*`**
        /// decodificadas do original (o mapa é o `docs/reverso-formularios.txt`), com um filtro e
        /// o botão de abrir montando a janela fiel dentro do CAD pelo <c>RenderizadorDeTelas</c>.
        /// </summary>
        [CommandMethod("JANELAS")]
        public void Janelas()
        {
            Plugin.Escrever(Interface.Telas.SeletorDeTelas.Abrir());
        }

        /// <summary>
        /// <c>JANELA</c> — abre **uma** tela do reverso pelo nome do `frm`, lido da variável
        /// <c>POSITRON_JANELA</c> (o mesmo padrão `POSITRON_*` do resto do plugin); sem a variável,
        /// abre o seletor. A janela sai modeless, como no original
        /// (<c>Application.ShowModelessDialog(this)</c> no construtor de cada `frm*`).
        /// </summary>
        [CommandMethod("JANELA")]
        public void Janela()
        {
            string nome = Interface.Telas.RenderizadorDeTelas.NomeDaVariavel();
            Plugin.Escrever(nome == null ? Interface.Telas.SeletorDeTelas.Abrir() : Interface.Telas.RenderizadorDeTelas.Abrir(nome));
        }

        /// <summary>
        /// <c>APAGARXDATA</c> — o comando do original que abre o <c>frmPesquisaXdatas</c> (a tela
        /// que lista os app names de XData do desenho e deixa apagar os escolhidos). Aqui ela abre
        /// **ligada**: a grade lê o ModelSpace pelo <c>XDatasDoCad</c>, o `BtPesquisa` recarrega e o
        /// `BtApaga` limpa os escolhidos — a regra é a <c>XDatasDoDesenho</c>.
        /// </summary>
        [CommandMethod("APAGARXDATA")]
        public void ApagarXData()
        {
            Plugin.Escrever(Interface.Telas.RenderizadorDeTelas.Abrir("frmPesquisaXdatas"));
        }

        /// <summary>
        /// <c>pzTelas</c> — a prova da casca (o par do `pzDiag`): monta **todas** as telas do mapa
        /// e descarta cada uma, **sem abrir nada**, para caber num script. É o teste de que o
        /// renderizador dá conta das 127 definições do original.
        /// </summary>
        [CommandMethod("pzTelas")]
        public void ConferirTelas()
        {
            Plugin.Escrever(Interface.Telas.RenderizadorDeTelas.ConferirTodas());
        }

        /// <summary>
        /// <c>pzBarra</c> — a prova da barra (o par do `pzTelas`): lê a aba do Positron **no ribbon
        /// vivo do CAD** e conta os itens pela classe real de cada um, sem passar pelo montador.
        /// </summary>
        [CommandMethod("pzBarra")]
        public void ConferirBarra()
        {
            Plugin.Escrever(Interface.Barra.BarraDeFerramentas.Inspecionar());
        }

        /// <summary>
        /// <c>pzFolhas</c> — a prova do caminho da **paleta de folhas** (o par do `pzBarra`): monta o
        /// controle e chama o mesmo handler do clique e da tecla, com a seleção da grade vinda do
        /// harness (ver <see cref="Interface.Folhas.ProvaDaPaleta"/>).
        /// </summary>
        [CommandMethod("pzFolhas")]
        public void ConferirFolhas()
        {
            Plugin.Escrever(Interface.Folhas.ProvaDaPaleta.Executar());
        }

        /// <summary>
        /// Compila a fiação: lê as <c>CONEXAO</c> do desenho e grava em
        /// <c>Fiacao</c> no banco do projeto. Equivale ao <c>FIA</c> do original
        /// (<c>frmCompilarFiacao</c>), sem a tela ainda.
        ///
        /// O caminho do banco vem de <c>POSITRON_DB_PATH</c>; <c>POSITRON_DWG</c>
        /// e <c>POSITRON_REVISAO</c> completam a linha (o original pega do
        /// desenho ativo, que ainda não resolvemos).
        /// </summary>
        /// <summary>
        /// <c>ELETCFG</c> — abre a <c>frmConfiguracaoGeral</c> fiel (comando <c>CFG</c> do reverso,
        /// <c>Comandos.cs:95</c>). Grava no XData do ModelSpace e o idioma no registro.
        /// </summary>
        [CommandMethod("ELETCFG")]
        public void Configurar()
        {
#if !POSITRON_SEM_WINFORMS
            Plugin.Escrever(Interface.Telas.JanelasDoOriginal.Abrir("CFG"));
#else
            Plugin.Escrever("ELETCFG: compilado sem WinForms.");
#endif
        }

        [CommandMethod("FIA")]
        public void Fia()
        {
            Plugin.Escrever(ExecutarFiacao());
        }

        /// <summary>
        /// <c>JMP</c> — compila os **jumpers** do desenho para <c>Jumper4</c>, o
        /// <c>frmCompilarJumperExt</c> do original (sem a tela).
        /// </summary>
        [CommandMethod("JMP")]
        public void Jmp()
        {
            Plugin.Escrever(ExecutarJumper());
        }

        /// <summary>
        /// A revisão que o comando usa: a que a **tela** passou (o <c>tbRevisao</c> das
        /// <c>frmCompilar*</c>) ou a da configuração (<c>POSITRON_REVISAO</c>). Vazia/nula cai na
        /// configuração — é o caminho de todos os outros chamadores (os pipelines).
        /// </summary>
        private static string RevisaoEfetiva(ConfiguracaoPositron config, string revisao)
        {
            return string.IsNullOrEmpty(revisao) ? config.Revisao : revisao.Trim();
        }

        /// <summary>
        /// Projeta a fiação do desenho e devolve a linha de resumo — usada tanto
        /// pelo <c>FIA</c> quanto pelo <c>SYNCD</c> (e pela tela <c>frmCompilarFiacao</c>, que passa
        /// a revisão do <c>tbRevisao</c>). Nunca lança: um comando que
        /// estoura derruba a linha de comando do ZWCAD.
        /// </summary>
        internal static string ExecutarFiacao(string revisao = null)
        {
            ConfiguracaoPositron config = ConfiguracaoEfetiva.Carregar();
            string caminho = config.Banco;
            if (string.IsNullOrEmpty(caminho))
            {
                return "FIA: " + Positron.Data.Interface.MensagensDoReverso.BancoNaoConfigurado;
            }

            try
            {
                IReadOnlyList<PontoFiacao> pontos = FiacaoDoDesenho.Ler();
                if (pontos.Count == 0)
                {
                    return "FIA: nenhuma LWPOLYLINE com XData CONEXAO no desenho. " + PerfilDoDesenhoDoDesenho.Ler().Explicacao();
                }

                ContextoProjecao contexto = new ContextoProjecao
                {
                    Dwg = config.Dwg,
                    Revisao = RevisaoEfetiva(config, revisao),
                    Criador = Environment.UserName,
                    Data = DateTime.Now,
                };

                // Bornes do desenho completam o ponto (terminal, régua, tipo).
                // Sem dicionário de réguas os bornes ficam sem nome de régua, mas
                // o terminal ainda casa.
                ReguasModelo reguas = ReguasDoDesenho.Ler();
                IReadOnlyList<PontoBorne> bornes = BornesDoDesenho.Ler(reguas);

                // Pontos de ligação por nome de bloco (bounds ±0,25 + offset).
                TabelaDeslocamentoBlocos deslocamentos = DeslocamentosDoDesenho.Ler();

                // Painéis desta revisão: no original vêm da tela; aqui, das
                // conexões e das máscaras/dispositivos presentes no desenho.
                MascarasDoDesenho.EmUso emUso = MascarasDoDesenho.Ler();
                List<int> paineis = new List<int>(emUso.Paineis);
                foreach (PontoFiacao ponto in pontos)
                {
                    if (!paineis.Contains(ponto.Painel))
                    {
                        paineis.Add(ponto.Painel);
                    }
                }

                DispositivosDoDesenho.Dispositivos dispositivos = DispositivosDoDesenho.Ler();
                foreach (int painelDispositivo in dispositivos.Paineis)
                {
                    if (!paineis.Contains(painelDispositivo))
                    {
                        paineis.Add(painelDispositivo);
                    }
                }

                // Blocos de dispositivo (P/E/A/I): dão a tag ao ponto não-borne.
                IReadOnlyList<DispositivoFiacao> dispositivosDeFiacao = DispositivosDeFiacaoDoDesenho.Ler();

                // Posições do layout (CENG_LAYOUT) — dão o PosicaoNum/ordem do
                // ponto não-borne, casadas por (painel, tag).
                LayoutPosicoes posicoes = LayoutDoDesenho.Ler(paineis);

                // Coluna `Pagina`: o switch `Conf.incluirColuna` do original, lido do
                // ambiente (a tela ainda não existe). O ponto guarda a página montada
                // e mantém o layer — ele é a chave do casamento com borne/dispositivo.
                ColunaPagina colunaPagina = LerColunaPagina();
                foreach (PontoFiacao ponto in pontos)
                {
                    ponto.Pagina = colunaPagina.Para(ponto.Layer);
                }

                ProjectStore store = new ProjectStore(caminho);
                FiacaoProjetor projetor = new FiacaoProjetor(store);
                int gravados = projetor.Projetar(pontos, contexto, bornes, posicoes, deslocamentos, dispositivosDeFiacao);

                // Renumera Ordem 1..N por potencial (ReordenaOrdemPotenciais do
                // original). No-op quando a projeção já inseriu ordenada.
                int reordenados = store.ReordenarOrdemFiacao(contexto.Dwg, contexto.Revisao);

                int portas = GerarPortas(store, contexto, emUso.Modelos);
                int reservas = GerarBornes(store, contexto, reguas, bornes, paineis, colunaPagina);
                int contatos = GerarContatos(store, contexto, dispositivos);
                int dispositivos4F = GerarDispositivos(store, contexto, paineis, dispositivosDeFiacao, posicoes, colunaPagina);
                int circuitos = GerarCircuitos(store, contexto, paineis);
                int aplicacoes = GerarAplicacoes(store, contexto);

                return "FIA: " + gravados + " linha(s) em Fiacao (" + bornes.Count + " borne(s), "
                    + dispositivosDeFiacao.Count + " dispositivo(s), "
                    + reordenados + " reordenada(s), " + posicoes.NumPosicoes + " posicao(oes), "
                    + deslocamentos.NumPontos + " ponto(s) de bloco); "
                    + portas + " porta(s) em Portas4F; " + reservas + " borne(s) em Bornes4F; "
                    + contatos + " contato(s) em Contatos4F; "
                    + dispositivos4F + " dispositivo(s) em Dispositivos4F; "
                    + circuitos + " circuito(s) em Circuitos4F; "
                    + aplicacoes + " tipo(s) em Aplicacao4F.";
            }
            catch (System.Exception erro)
            {
                return "FIA: falhou — " + DescreverErro(erro);
            }
        }

        /// <summary>
        /// Projeta os jumpers do desenho e devolve a linha de resumo.
        ///
        /// O <c>frmCompilarJumperExt</c> lê as conexões com <c>Tipo == 4</c>
        /// (<c>Disp1</c>/<c>Disp2</c>) e as de <c>Tipo == 3</c> com
        /// <c>Jumper == "JUMPER"</c>, casa cada ponta com borne/dispositivo e grava
        /// em <c>Jumper4</c> — a mesma máquina do <c>FIA</c>, com a tabela de
        /// destino trocada. Nunca lança.
        /// </summary>
        internal static string ExecutarJumper(string revisao = null)
        {
            ConfiguracaoPositron config = ConfiguracaoEfetiva.Carregar();
            string caminho = config.Banco;
            if (string.IsNullOrEmpty(caminho))
            {
                return "JMP: " + Positron.Data.Interface.MensagensDoReverso.BancoNaoConfigurado;
            }

            try
            {
                IReadOnlyList<PontoFiacao> pontos = JumperDoDesenho.Ler();
                if (pontos.Count == 0)
                {
                    return "JMP: nenhuma conexão de jumper no desenho.";
                }

                ContextoProjecao contexto = new ContextoProjecao
                {
                    Dwg = config.Dwg,
                    Revisao = RevisaoEfetiva(config, revisao),
                    Criador = Environment.UserName,
                    Data = DateTime.Now,
                };

                ReguasModelo reguas = ReguasDoDesenho.Ler();
                IReadOnlyList<PontoBorne> bornes = BornesDoDesenho.Ler(reguas);
                TabelaDeslocamentoBlocos deslocamentos = DeslocamentosDoDesenho.Ler();

                MascarasDoDesenho.EmUso emUso = MascarasDoDesenho.Ler();
                List<int> paineis = new List<int>(emUso.Paineis);
                foreach (PontoFiacao ponto in pontos)
                {
                    if (!paineis.Contains(ponto.Painel))
                    {
                        paineis.Add(ponto.Painel);
                    }
                }

                IReadOnlyList<DispositivoFiacao> dispositivosDeFiacao = DispositivosDeFiacaoDoDesenho.Ler();
                LayoutPosicoes posicoes = LayoutDoDesenho.Ler(paineis);

                ColunaPagina colunaPagina = LerColunaPagina();
                foreach (PontoFiacao ponto in pontos)
                {
                    ponto.Pagina = colunaPagina.Para(ponto.Layer);
                }

                ProjectStore store = new ProjectStore(caminho);
                FiacaoProjetor projetor = new FiacaoProjetor(store, true);
                int gravados = projetor.Projetar(pontos, contexto, bornes, posicoes, deslocamentos, dispositivosDeFiacao);

                return "JMP: " + gravados + " linha(s) em Jumper4 (" + bornes.Count + " borne(s), "
                    + dispositivosDeFiacao.Count + " dispositivo(s)).";
            }
            catch (System.Exception erro)
            {
                return "JMP: falhou — " + DescreverErro(erro);
            }
        }

        /// <summary>
        /// Compila a interligação: lê as <c>INTERLIGACAO</c> do desenho e grava em
        /// <c>Interligacao4</c> no banco do projeto. Equivale ao <c>INT</c> do
        /// original (<c>frmCompilarInterligacao</c>), sem a tela ainda.
        ///
        /// O caminho do banco vem de <c>POSITRON_DB_PATH</c>; <c>POSITRON_DWG</c>,
        /// <c>POSITRON_REVISAO</c> e <c>POSITRON_LOCAL</c> (o <c>Conf.Local</c> do
        /// original, que vira <c>Documento1</c>/<c>Documento2</c>) completam a linha.
        /// </summary>
        [CommandMethod("INT")]
        public void Int()
        {
            Plugin.Escrever(ExecutarInterligacao());
        }

        /// <summary>
        /// <c>INDCABO</c> — a **ação** <c>IndefineCabosNaoExistentes</c> do
        /// verificador da interligação (o botão "Corrigir cabos",
        /// <c>BTCorrigeCabos</c>): o trecho de interligação cujo <c>Tag_Cabo</c>
        /// **não** existe no catálogo (<c>Cabos</c>) perde o cabo e a veia no XData,
        /// e o rótulo auxiliar da ponta vira o caracter de terminal indefinido.
        ///
        /// É a contrapartida de **escrita** da regra read-only
        /// <c>CaboSemCatalogo</c> que o <c>VERIF</c> reporta: o original separa as
        /// duas (a regra aponta, o botão corrige). O catálogo vem do banco do
        /// projeto (<c>POSITRON_DB_PATH</c>); com ele vazio a ação não faz nada, como
        /// no original.
        /// </summary>
        [CommandMethod("INDCABO")]
        public void IndefinirCabos()
        {
            Plugin.Escrever(ExecutarIndefinirCabos());
        }

        /// <summary>
        /// <c>CorrigeInterligacao</c> — a correção do original (<c>clsUtilitarios.cs:611</c>): para
        /// **cada trecho indefinido** (<c>NumVeia == -1000</c>, o estado que o <c>INDCABO</c> deixa)
        /// ele redescobre o painel de cada ponta pelo **dispositivo que está sobre ela** e regrava
        /// <c>Painel1</c>/<c>Painel2</c> — os mesmos campos que a projeção do <c>INT</c> lê.
        ///
        /// É a correção do laço do <c>VERIF</c> na interligação por **página inteira**: o
        /// <c>INDCABO</c> conserta os trechos escolhidos (tira o cabo fora do catálogo), esta
        /// recompõe os painéis pelo desenho. A regra é pura
        /// (<see cref="Positron.Data.Interligacao.CorrecaoInterligacao"/>) e o resumo traz o que foi
        /// regravado e quantos trechos ficaram **sem dispositivo** nas pontas — que o original
        /// gravaria como painel 0 (a divergência deliberada está no XML doc da regra).
        /// </summary>
        [CommandMethod("CorrigeInterligacao")]
        public void CorrigirInterligacao()
        {
            Plugin.Escrever(ExecutarCorrecaoDaInterligacao());
        }

        /// <summary>
        /// <c>NOVAPAGINA</c> — cria a **página nova** do caderno: o "Nova Página" do menu das folhas
        /// (o <c>Pagina.criarUmaNovaPagina</c> do original). Calcula a página **depois da última**
        /// (<see cref="NovaPaginaEntre"/> com o sentinela do fim e o <c>Conf.PassoPagina</c>), cria o
        /// **layer** com o XData de unidade/alternativo e copia os **campos do formato** do bloco de
        /// formato, quando o desenho tem um.
        ///
        /// O comando é **nosso** (no original o caminho é o item de menu, sem <c>[CommandMethod]</c>) e
        /// existe para o script medir o mesmo que a tela faz — o <c>Inserir</c> do menu usa a mesma
        /// regra, com a página selecionada em vez da última.
        /// </summary>
        /// <summary>
        /// <c>UNIDADE</c> — a **unidade e o alternativo** de uma pagina (o XData <c>Eletron</c> do
        /// layer; o <c>LeXDataUnidadeAlternativo</c>/<c>GravarXDataUnidadeAlternativo</c> do original). A
        /// pagina vem de <c>POSITRON_PAGINA</c> (padrao: a ultima) e a gravacao das variaveis
        /// <c>POSITRON_UNIDADE</c>/<c>POSITRON_ALTERNATIVO</c> — sem elas o comando so **le**. E nosso,
        /// como o <c>TITULOS</c>: no original quem edita sao os itens "Editar Unidade"/"Alternativo" do
        /// menu (o form da fatia 5).
        /// </summary>
        [CommandMethod("UNIDADE")]
        public void Unidade()
        {
            Plugin.Escrever(ExecutarUnidade());
        }

        /// <summary>A unidade/alternativo da pagina e a linha de resumo. Nunca lanca.</summary>
        internal static string ExecutarUnidade()
        {
            try
            {
                List<string> paginas = Positron.Plugin.Paginas.PaginasDoDesenho.Ler();
                string pagina = System.Environment.GetEnvironmentVariable("POSITRON_PAGINA");
                if (string.IsNullOrEmpty(pagina))
                {
                    if (paginas.Count == 0)
                    {
                        return "UNIDADE: nenhuma pagina do caderno no desenho.";
                    }

                    pagina = paginas[paginas.Count - 1];
                }

                string unidade;
                string alternativo;
                Positron.Plugin.Paginas.UnidadeDaPaginaDoDesenho.Ler(pagina, out unidade, out alternativo);
                string linha = "UNIDADE: pagina \"" + pagina + "\" — unidade=\"" + unidade
                    + "\", alternativo=\"" + alternativo + "\"";

                string novaUnidade = System.Environment.GetEnvironmentVariable("POSITRON_UNIDADE");
                string novoAlternativo = System.Environment.GetEnvironmentVariable("POSITRON_ALTERNATIVO");
                if (novaUnidade == null && novoAlternativo == null)
                {
                    return linha + " (defina POSITRON_UNIDADE/POSITRON_ALTERNATIVO para gravar).";
                }

                string gravarUnidade = novaUnidade ?? unidade;
                string gravarAlternativo = novoAlternativo ?? alternativo;
                if (!Positron.Plugin.Paginas.UnidadeDaPaginaDoDesenho.Gravar(pagina, gravarUnidade, gravarAlternativo))
                {
                    return "UNIDADE: o layer da pagina \"" + pagina + "\" nao existe.";
                }

                return linha + " — regravado para unidade=\"" + gravarUnidade + "\", alternativo=\""
                    + gravarAlternativo + "\".";
            }
            catch (System.Exception erro)
            {
                return "UNIDADE: falhou — " + DescreverErro(erro) + ".";
            }
        }

        /// <summary>
        /// <c>ATIVAPAGINA</c> — a **pagina ativa** (o <c>AtivaPagina</c>/<c>LocalizaPaginaAtiva</c>
        /// do <c>Pagina.cs</c>): liga a pagina pedida, passa a camada corrente para ela e **desliga
        /// os outros layers** — o isolamento do original. A pagina vem de <c>POSITRON_PAGINA</c>
        /// (padrao: a **pagina ativa** do desenho e, sem ela, a ultima do caderno). O comando e
        /// **nosso**, como o <c>UNIDADE</c>: no original o caminho e o item do menu das folhas.
        /// </summary>
        [CommandMethod("ATIVAPAGINA")]
        public void AtivarPagina()
        {
            Plugin.Escrever(ExecutarAtivarPagina());
        }

        /// <summary>A ativacao da pagina e a linha de resumo. Nunca lanca.</summary>
        internal static string ExecutarAtivarPagina()
        {
            try
            {
                List<string> paginas = Positron.Plugin.Paginas.PaginasDoDesenho.Ler();
                string pagina = System.Environment.GetEnvironmentVariable("POSITRON_PAGINA");
                bool doAmbiente = !string.IsNullOrEmpty(pagina);
                if (!doAmbiente)
                {
                    // Sem a variavel o alvo e a pagina que o desenho ja mostra; sem ela, a ultima.
                    pagina = Positron.Plugin.Paginas.PaginaAtivaDoDesenho.Ler();
                }

                if (string.IsNullOrEmpty(pagina))
                {
                    if (paginas.Count == 0)
                    {
                        return "ATIVAPAGINA: nenhuma pagina do caderno no desenho.";
                    }

                    pagina = paginas[paginas.Count - 1];
                }

                // A pagina pedida tem de ser do caderno (a mesma guarda do APAGAPAGINA, que impede
                // um POSITRON_PAGINA torto de mexer em layer alheio); a que veio da camada corrente
                // ja passou no LayerValido.
                if (doAmbiente)
                {
                    string recusa = ExclusaoDePagina.Recusa(pagina, paginas);
                    if (recusa != null)
                    {
                        return "ATIVAPAGINA: " + recusa + ".";
                    }
                }

                pagina = pagina.Trim();
                Positron.Plugin.Paginas.PaginaAtivaDoDesenho.Resultado resultado =
                    Positron.Plugin.Paginas.PaginaAtivaDoDesenho.Ativar(pagina);
                Interface.Folhas.PaletaDeFolhas.Recarregar();

                string capa = resultado.Capa ?? string.Empty;
                return "ATIVAPAGINA: pagina \"" + pagina + "\" — " + resultado.LayersDesligados
                    + " layer(s) desligado(s), " + resultado.LayersLigados + " ligado(s), "
                    + resultado.LayersAlterados + " alterado(s)"
                    + (capa.Length > 0 ? "; capa \"" + capa + "\"" : "; sem capa na tabela") + ".";
            }
            catch (System.Exception erro)
            {
                return "ATIVAPAGINA: falhou — " + DescreverErro(erro) + ".";
            }
        }

        /// <summary>
        /// <c>EDCON</c> — o comando do original (<c>Comandos.cs:579</c>, <c>clsConexao.editarSecaoCor</c>):
        /// pergunta <c>Seção, Cor ou Ambas</c>, pede a seleção das conexões e troca a seção e/ou a cor
        /// de **todos os condutores dos potenciais selecionados**, reescrevendo os textos auxiliares
        /// (<c>AUXCONEXAO</c> tipos 4/5/6). A variante por página é a tela do <c>EDCONP</c>
        /// (<c>frmEditaConexao</c>). A regra está em <see cref="SecaoECorDasConexoes"/>.
        /// </summary>
        [CommandMethod("EDCON")]
        public void EditarSecaoECor()
        {
            try
            {
                ModoSecaoECor? modo = SecaoECorDasConexoesDoDesenho.PerguntarModo();
                if (modo.HasValue)
                {
                    SecaoECorDasConexoesDoDesenho.Executar(modo.Value, null);
                }
            }
            catch (System.Exception erro)
            {
                // O `MsgBox(ex.Message, Information)` do `clsConexao.editarSecaoCor`.
                Interface.Aviso.MsgBox(erro.Message, "Eletron");
            }
        }

        /// <summary>
        /// <c>EncontraHandle</c> — o comando do original (<c>clsUtilitarios.cs:950</c>, o último item
        /// de regra da frente 2): acha a entidade pelo **handle**, **ativa a página** dela (o
        /// <c>AtivaPagina(entidade.Layer)</c>, sem guarda de nome, como lá) e dá **zoom** nela com a
        /// margem de 20 (o <c>ZEntity</c>). O handle vem de <c>POSITRON_HANDLE</c> (o script) ou do
        /// prompt do original, <c>Digite Um Handle</c>.
        /// </summary>
        [CommandMethod("EncontraHandle")]
        public void EncontrarHandle()
        {
            string texto = System.Environment.GetEnvironmentVariable("POSITRON_HANDLE");
            if (string.IsNullOrEmpty(texto))
            {
                texto = Positron.Plugin.Paginas.LocalizacaoPorHandleDoDesenho.PerguntarHandle();
            }

            Plugin.Escrever(ExecutarEncontraHandle(texto));
        }

        /// <summary>A localização pelo handle e a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarEncontraHandle(string texto)
        {
            try
            {
                long? handle = LocalizacaoPorHandle.LerHandle(texto);
                if (!handle.HasValue)
                {
                    return "EncontraHandle: \"" + (texto ?? string.Empty) + "\" não é um handle (hexadecimal).";
                }

                Positron.Plugin.Paginas.LocalizacaoPorHandleDoDesenho.Entidade entidade =
                    Positron.Plugin.Paginas.LocalizacaoPorHandleDoDesenho.Achar(handle.Value);
                if (entidade == null)
                {
                    return "EncontraHandle: handle " + handle.Value.ToString("X") + " não achado no desenho (ou não é entidade).";
                }

                Positron.Plugin.Paginas.PaginaAtivaDoDesenho.Resultado ativacao =
                    Positron.Plugin.Paginas.PaginaAtivaDoDesenho.Ativar(entidade.Layer);
                Interface.Folhas.PaletaDeFolhas.Recarregar();

                JanelaDeZoom? janela = Positron.Plugin.Paginas.LocalizacaoPorHandleDoDesenho.DarZoom(entidade.Id);
                string zoom = janela.HasValue
                    ? string.Format(System.Globalization.CultureInfo.InvariantCulture,
                        "zoom em ({0:0.###}; {1:0.###}) {2:0.###} x {3:0.###}",
                        janela.Value.CentroX, janela.Value.CentroY, janela.Value.Largura, janela.Value.Altura)
                    : "sem zoom (a entidade não tem caixa)";

                return "EncontraHandle: " + handle.Value.ToString("X") + " = " + entidade.Tipo
                    + " no layer \"" + entidade.Layer + "\" — página ativada ("
                    + ativacao.LayersDesligados + " layer(s) desligado(s), " + ativacao.LayersLigados
                    + " ligado(s), " + ativacao.LayersAlterados + " alterado(s)); " + zoom + ".";
            }
            catch (System.Exception erro)
            {
                return "EncontraHandle: falhou — " + DescreverErro(erro) + ".";
            }
        }

        /// <summary>
        /// <c>PASSO</c> — o **passo do caderno** (o <c>Pagina.redefinePasso</c> do original, o comando
        /// <c>PAS</c>, <c>Pagina.cs:2657</c>): a distância entre as páginas que o <c>NovaPaginaEntre</c>
        /// usa. Pergunta o inteiro (mMensagem 143, sem zero nem negativo, padrão = o passo atual) e grava
        /// no XData de configuração **do desenho** (o <c>GravarXDataConfiguracao</c>).
        /// </summary>
        [CommandMethod("PASSO")]
        public void Passo()
        {
            Plugin.Escrever(ExecutarPasso());
        }

        /// <summary>O passo do caderno: pergunta e grava no desenho. Nunca lança.</summary>
        internal static string ExecutarPasso()
        {
            try
            {
                return Positron.Plugin.Paginas.PassoDoCaderno.Redefinir();
            }
            catch (System.Exception erro)
            {
                return "PASSO: falhou — " + DescreverErro(erro) + ".";
            }
        }

        /// <summary>
        /// <c>CAD</c> — o botão **CADERNO** da barra (o <c>Caderno.CriaCaderno</c> do reverso,
        /// <c>Comandos.cs:107</c>): **cria ou troca o formato** do caderno.
        ///
        /// O caminho do desenho: se o desenho já tem um formato (o bloco com o XData
        /// <c>DiagLog</c>/<c>Formato</c>), o original pergunta se é para substituir (a mMensagem
        /// 75) e, confirmado, **captura** os atributos da referência, apaga a definição e as
        /// referências do formato antigo e renomeia a capa para <c>"1"</c>; pede o DWG do formato
        /// novo ("Selecione o formato:"), o insere como bloco na origem e **recria os atributos** —
        /// os protegidos (<c>attProtCollection</c>) invisíveis e vazios, os demais com o valor
        /// capturado (casado por página e tag, o <c>euxs3rkWO</c>), cada um perguntado no
        /// <c>GetString</c> como no original; e restaura a capa.
        ///
        /// **Diálogos como o original.** Com <c>POSITRON_FORMATO</c> definido (a convenção
        /// <c>POSITRON_*</c>) o comando **não** abre o diálogo de arquivo nem os prompts: usa o
        /// caminho, mantém os valores preservados (o "Enter" do original) e aceita a troca pela
        /// variável <c>POSITRON_FORMATO_TROCAR=1</c>.
        ///
        /// **A cadeia pós-troca** (recarregar as páginas, recriar os campos de cada uma, os blocos de
        /// revisão, os títulos e o <c>CONT</c>/<c>FL</c>/<c>TOT</c>/<c>ALTERNATIVO</c>) roda depois da
        /// inserção do bloco, em <c>RestauracaoDoFormatoDoDesenho</c>.
        /// </summary>
        [CommandMethod("CAD")]
        public void Cad()
        {
            Plugin.Escrever(ExecutarTrocaDoFormato());
        }

        /// <summary>A troca (ou criação) do formato e a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarTrocaDoFormato()
        {
            try
            {
                string caminho = System.Environment.GetEnvironmentVariable("POSITRON_FORMATO");
                bool modoScript = !string.IsNullOrEmpty(caminho);

                if (Positron.Plugin.Paginas.TrocaDeFormatoDoDesenho.Existe())
                {
                    if (modoScript)
                    {
                        // A confirmação do MsgBox vira variável: sem ela o script não troca nada.
                        if (System.Environment.GetEnvironmentVariable("POSITRON_FORMATO_TROCAR") != "1")
                        {
                            return "CAD: " + Positron.Data.Interface.MensagensDoReverso.SubstituirFormato
                                + " — defina POSITRON_FORMATO_TROCAR=1 para trocar.";
                        }
                    }
                    else if (!ConfirmarTrocaDoFormato())
                    {
                        return "CAD: troca do formato cancelada (o formato atual fica).";
                    }
                }

                // Os títulos e as revisões simplificadas das páginas são capturados **antes** da troca
                // (o `capturaTitulos` e `capturaRevisoesSimplificadas` do original) e devolvidos depois,
                // quando a cadeia recria os campos (o `AtualizaTitulos` e `AtualizaRevSimplificada`).
                System.Collections.Generic.Dictionary<string, Positron.Data.Paginas.TitulosDaPagina> titulos =
                    CapturarTitulos();
                System.Collections.Generic.List<Positron.Data.Paginas.RevisaoSimplificadaDaPagina> revisoes =
                    Positron.Plugin.Paginas.RevisoesDoDesenho.LerSimplificadas();

                Positron.Plugin.Paginas.TrocaDeFormatoDoDesenho.Resultado resultado =
                    Positron.Plugin.Paginas.TrocaDeFormatoDoDesenho.Trocar(caminho);

                if (resultado.Cancelado)
                {
                    return "CAD: nenhum formato escolhido — nada foi trocado.";
                }

                if (resultado.NomeDoBloco == null)
                {
                    return "CAD: não foi possível ler o DWG do formato — nada foi trocado.";
                }

                // A cadeia que o original roda depois de inserir o bloco (o resto do `CriaCaderno`):
                // recarrega as páginas, recria os campos, refaz a revisão com attsync, restaura os títulos,
                // restaura as revisões simplificadas, reconstitui as colunas e regrava a configuração do desenho.
                Positron.Plugin.Paginas.RestauracaoDoFormatoDoDesenho.Resultado cadeia =
                    Positron.Plugin.Paginas.RestauracaoDoFormatoDoDesenho.Executar(titulos, revisoes, resultado.TinhaFormato);

                string linha = "CAD: " + (resultado.TinhaFormato ? "formato trocado" : "formato criado")
                    + " — bloco \"" + resultado.NomeDoBloco + "\""
                    + (resultado.TinhaFormato
                        ? " (definição \"" + resultado.DefinicaoApagada + "\" e "
                            + resultado.ReferenciasApagadas + " referência(s) apagada(s))"
                        : string.Empty)
                    + "; " + resultado.AtributosCriados + " atributo(s) ("
                    + resultado.AtributosPreservados + " preservado(s), "
                    + resultado.AtributosProtegidos + " protegido(s)"
                    + (resultado.AtributosPerguntados > 0 ? ", " + resultado.AtributosPerguntados + " perguntado(s)" : string.Empty)
                    + ")"
                    + (string.IsNullOrEmpty(resultado.CapaRestaurada)
                        ? string.Empty
                        : "; capa \"" + resultado.CapaRestaurada + "\" passou por \"1\" e voltou")
                    + "; cadeia: " + cadeia.CamposApagados + " campo(s) apagado(s), "
                    + cadeia.CamposTot + " TOT, " + cadeia.CamposCriados + " campo(s) em " + cadeia.Paginas
                    + " página(s), " + cadeia.Definicoes + " definição(ões) de revisão ("
                    + cadeia.DefinicoesApagadas + " apagada(s)"
                    + (cadeia.ReferenciasSincronizadas > 0 ? ", " + cadeia.ReferenciasSincronizadas + " attsync" : string.Empty)
                    + "), " + cadeia.ContTotFl + " CONT/FL/TOT/ALTERNATIVO, "
                    + cadeia.Titulos + " título(s), "
                    + cadeia.RevSimplificadas + " rev. simplificada(s)"
                    + (cadeia.ColunasApagadas > 0 || cadeia.ColunasCriadas > 0
                        ? ", colunas: " + cadeia.ColunasApagadas + " apagada(s)/" + cadeia.ColunasCriadas + " recriada(s)"
                        : string.Empty)
                    + "; maxCapa " + cadeia.MaxCapa + "/maxCorpo " + cadeia.MaxCorpo
                    + (cadeia.ConfigGravada ? " (configuração regravada)" : "")
                    + (!string.IsNullOrEmpty(cadeia.CapaAtivada) ? "; capa \"" + cadeia.CapaAtivada + "\" ativa" : string.Empty)
                    + ".";

                return linha;
            }
            catch (System.Exception erro)
            {
                return "CAD: falhou — " + DescreverErro(erro) + ".";
            }
        }

        /// <summary>
        /// Captura os títulos de todas as páginas (o <c>capturaTitulos</c> do original) — o que a
        /// cadeia pós-troca devolve nos campos novos com o <c>AtualizaTitulos</c>.
        /// </summary>
        private static System.Collections.Generic.Dictionary<string, Positron.Data.Paginas.TitulosDaPagina> CapturarTitulos()
        {
            System.Collections.Generic.Dictionary<string, Positron.Data.Paginas.TitulosDaPagina> titulos =
                new System.Collections.Generic.Dictionary<string, Positron.Data.Paginas.TitulosDaPagina>(
                    System.StringComparer.OrdinalIgnoreCase);
            foreach (string pagina in Positron.Plugin.Paginas.PaginasDoDesenho.Ler())
            {
                titulos[pagina] = Positron.Plugin.Paginas.TitulosDaPaginaDoDesenho.Ler(pagina);
            }

            return titulos;
        }

        /// <summary>
        /// O <c>MsgBox</c> Yes/No do original (a mMensagem 75, sem título). Compilado sem WinForms a
        /// troca é recusada — não há como confirmar (o mesmo caminho do <c>ELETCFG</c>).
        /// </summary>
        private static bool ConfirmarTrocaDoFormato()
        {
#if !POSITRON_SEM_WINFORMS
            return System.Windows.Forms.MessageBox.Show(
                Positron.Data.Interface.MensagensDoReverso.SubstituirFormato,
                string.Empty,
                System.Windows.Forms.MessageBoxButtons.YesNo,
                System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes;
#else
            return false;
#endif
        }

        [CommandMethod("NOVAPAGINA")]
        public void NovaPagina()
        {
            Plugin.Escrever(ExecutarNovaPagina());
        }

        /// <summary>
        /// <c>TITULOS</c> — os **quatro títulos** de uma página: o <c>capturaTitulosDeUmaPagina</c>
        /// (ler) e o <c>AtualizaTitulosDeUmaPagina</c> (regravar) do original. A página vem de
        /// <c>POSITRON_PAGINA</c> (padrão: a **última** do caderno) e os valores a gravar de
        /// <c>POSITRON_TITULO1</c>..<c>POSITRON_TITULO4</c> — o comando é **nosso** (no original os
        /// títulos são um item de menu com campos de texto) e existe para o script medir a leitura e a
        /// gravação; sem nenhuma variável de título ele só **lê**.
        /// </summary>
        [CommandMethod("TITULOS")]
        public void Titulos()
        {
            Plugin.Escrever(ExecutarTitulos());
        }

        /// <summary>Os títulos da página e a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarTitulos()
        {
            try
            {
                List<string> paginas = Positron.Plugin.Paginas.PaginasDoDesenho.Ler();
                string pagina = System.Environment.GetEnvironmentVariable("POSITRON_PAGINA");
                if (string.IsNullOrEmpty(pagina))
                {
                    if (paginas.Count == 0)
                    {
                        return "TITULOS: nenhuma página do caderno no desenho.";
                    }

                    pagina = paginas[paginas.Count - 1];
                }

                TitulosDaPagina lidos = Positron.Plugin.Paginas.TitulosDaPaginaDoDesenho.Ler(pagina);
                string linha = "TITULOS: página \"" + pagina + "\" — T1=\"" + (lidos.Titulo1 ?? string.Empty)
                    + "\", T2=\"" + (lidos.Titulo2 ?? string.Empty) + "\", T3=\"" + (lidos.Titulo3 ?? string.Empty)
                    + "\", T4=\"" + (lidos.Titulo4 ?? string.Empty) + "\"";

                // Só grava quando alguma POSITRON_TITULO* veio definida (as outras ficam como estão).
                TitulosDaPagina novos = new TitulosDaPagina();
                bool escrever = false;
                for (int i = 1; i <= TitulosDaPagina.UltimoIndice; i++)
                {
                    string doAmbiente = System.Environment.GetEnvironmentVariable("POSITRON_TITULO" + i);
                    if (doAmbiente != null)
                    {
                        escrever = true;
                    }

                    novos.Definir(i, doAmbiente ?? lidos.De(i));
                }

                if (!escrever)
                {
                    return linha + " (defina POSITRON_TITULO1..4 para regravar).";
                }

                int gravados = Positron.Plugin.Paginas.TitulosDaPaginaDoDesenho.Gravar(pagina, novos);
                return linha + "; " + gravados + " campo(s) regravado(s).";
            }
            catch (System.Exception erro)
            {
                return "TITULOS: falhou — " + DescreverErro(erro) + ".";
            }
        }

        /// <summary>
        /// <c>REVSIMP</c> — abre o formulário de edição de revisão simplificada (<c>frmEditaRevisaoSimplificada</c>).
        /// </summary>
        [CommandMethod("REVSIMP")]
        public void ComandoRevSimp()
        {
            Plugin.Escrever(Interface.Telas.RenderizadorDeTelas.Abrir("frmEditaRevisaoSimplificada", "REVSIMP"));
        }

        /// <summary>
        /// <c>REVCOMP</c> — abre o formulário de edição de revisão completa (<c>frmEditaRevisaoCompleta</c>).
        /// </summary>
        [CommandMethod("REVCOMP")]
        public void ComandoRevComp()
        {
            Plugin.Escrever(Interface.Telas.RenderizadorDeTelas.Abrir("frmEditaRevisaoCompleta", "REVCOMP"));
        }

        /// <summary>
        /// <c>ONSPL</c> — abre a tela de splash (<c>frmSplash</c>), idêntica ao original (<c>Comandos.cs:31</c>).
        /// </summary>
        [CommandMethod("ONSPL")]
        public void ComandoOnSpl()
        {
            Plugin.Escrever(Interface.Telas.RenderizadorDeTelas.Abrir("frmSplash", "ONSPL"));
        }

        /// <summary>
        /// <c>OFFSPL</c> — fecha a tela de splash ativa (<c>frmSplash</c>), idêntico ao original (<c>Comandos.cs:40</c>).
        /// </summary>
        [CommandMethod("OFFSPL")]
        public void ComandoOffSpl()
        {
            // O original só fecha a tela (`LjQTwnGi0W.Close()`), sem mensagem.
            Interface.Telas.LigacaoDoFrmSplash.Fechar();
        }

        /// <summary>
        /// <c>APAGAPAGINA</c> — apaga uma **página**: os elementos do ModelSpace no layer dela (o
        /// <c>Pagina.ApagarElementosPagina</c> do reverso) e o layer. A página vem de
        /// <c>POSITRON_PAGINA</c> — **sem ela o comando não faz nada** (é destrutivo e não adivinha
        /// alvo). O comando é **nosso**: no original o caminho é o item "Excluir Páginas" do menu, que
        /// apaga as páginas selecionadas na grade (é o que o menu do recoder faz agora).
        /// </summary>
        [CommandMethod("APAGAPAGINA")]
        public void ApagarPagina()
        {
            Plugin.Escrever(ExecutarApagarPagina());
        }

        /// <summary>A exclusão de uma página (a de `POSITRON_PAGINA`) e a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarApagarPagina()
        {
            string pagina = System.Environment.GetEnvironmentVariable("POSITRON_PAGINA");
            if (string.IsNullOrEmpty(pagina))
            {
                return "APAGAPAGINA: defina POSITRON_PAGINA com a página a apagar (o comando é destrutivo e não adivinha o alvo).";
            }

            return ExecutarApagarPaginas(new List<string> { pagina });
        }

        /// <summary>O que uma exclusão de páginas fez, para o resumo, as falhas e as sincronizações.</summary>
        internal sealed class ResultadoDaExclusao
        {
            /// <summary>A linha de resumo (a mesma que o comando imprime).</summary>
            internal string Resumo { get; set; } = string.Empty;

            /// <summary>O que as sincronizações do apagar fizeram (linha separada, para não poluir o rótulo).</summary>
            internal string Sincronizacoes { get; set; } = string.Empty;

            /// <summary>Quantas páginas foram realmente apagadas.</summary>
            internal int Apagadas { get; set; }

            /// <summary>A mensagem do erro de cada página que não pôde ser apagada (o `MsgBox` do original).</summary>
            internal List<string> Falhas { get; } = new List<string>();
        }

        /// <summary>Apaga as páginas pedidas (o menu passa as selecionadas na grade) e resume. Nunca lança.</summary>
        internal static string ExecutarApagarPaginas(IReadOnlyList<string> paginasPedidas)
        {
            return ExecutarExclusaoDePaginas(paginasPedidas).Resumo;
        }

        /// <summary>
        /// O <c>Apagar Páginas</c> do menu das folhas (`uscPaginas.cs:2157-2222`): apaga o que passou no
        /// crivo, roda as **sincronizações** do original e devolve o que fez. Nunca lança.
        /// </summary>
        /// <remarks>
        /// **Fecha o pipeline do original:** depois do `AtualizaContTotFl` (dentro do apagar de cada
        /// página), o original chama `clsConexao.sincronizaCircuitos`,
        /// `clsInterligacao.SincronizaCruzamentoInterlig`, `clsDePara.SincronizaDePara(false)`,
        /// `clsDispositivoAuxiliares.ApagaContatosOrfaos`, `clsDispositivoAuxiliares.SincronizaContatos`
        /// e `clsPortas.SincronizaPortas`. Essa família **não está portada** (é o mesmo "fora do
        /// recorte" dos `SYNCD`/`SYNCV`/`RESTPROJ`); o stand-in do recoder é o pipeline do `SYNCD` —
        /// os modelos de contatos e a **projeção** (`FIA` + `INT`).
        /// </remarks>
        internal static ResultadoDaExclusao ExecutarExclusaoDePaginas(IReadOnlyList<string> paginasPedidas)
        {
            ResultadoDaExclusao retorno = new ResultadoDaExclusao();
            try
            {
                List<string> doDesenho = Positron.Plugin.Paginas.PaginasDoDesenho.Ler();
                int entidades = 0;
                int layers = 0;
                List<string> apagadas = new List<string>();
                List<string> recusadas = new List<string>();

                foreach (string pedida in paginasPedidas)
                {
                    string recusa = ExclusaoDePagina.Recusa(pedida, doDesenho);
                    if (recusa != null)
                    {
                        recusadas.Add(recusa);
                        continue;
                    }

                    Positron.Plugin.Paginas.ExclusaoDePaginaDoDesenho.Resultado resultado =
                        Positron.Plugin.Paginas.ExclusaoDePaginaDoDesenho.Executar(pedida.Trim());
                    entidades += resultado.Entidades;
                    if (resultado.LayerApagado)
                    {
                        layers++;
                    }

                    if (!string.IsNullOrEmpty(resultado.Falha))
                    {
                        // O erro chega ao usuário (o `MsgBox(ex.Message, Critical)` do original).
                        retorno.Falhas.Add("\"" + pedida.Trim() + "\": " + resultado.Falha);
                        continue;
                    }

                    apagadas.Add(pedida.Trim());
                }

                if (apagadas.Count == 0)
                {
                    retorno.Resumo = "APAGAPAGINA: nada apagado — " + string.Join("; ", recusadas.ToArray()) + ".";
                    return retorno;
                }

                retorno.Apagadas = apagadas.Count;
                retorno.Resumo = "APAGAPAGINA: " + apagadas.Count + " página(s) apagada(s) ("
                    + string.Join(", ", apagadas.ToArray()) + ") — " + entidades + " entidade(s) do ModelSpace e "
                    + layers + " layer(s)."
                    + (recusadas.Count > 0 ? " Recusadas: " + string.Join("; ", recusadas.ToArray()) + "." : string.Empty);

                // As sincronizações do apagar — o stand-in do recoder (ver o remarks).
                retorno.Sincronizacoes = SincronizacoesDoCaderno();

                return retorno;
            }
            catch (System.Exception erro)
            {
                retorno.Resumo = "APAGAPAGINA: falhou — " + DescreverErro(erro) + ".";
                return retorno;
            }
        }

        /// <summary>
        /// O **stand-in** das sincronizações que o original roda depois de mexer no caderno — a
        /// família <c>clsConexao.sincronizaCircuitos</c>, <c>clsInterligacao.SincronizaCruzamentoInterlig</c>,
        /// <c>clsDePara.SincronizaDePara(false)</c>, <c>clsDispositivoAuxiliares.*</c> e
        /// <c>clsPortas.SincronizaPortas</c> **não está portada** (é o mesmo "fora do recorte" dos
        /// <c>SYNCD</c>/<c>SYNCV</c>/<c>RESTPROJ</c>): quem faz esse papel é o pipeline do
        /// <c>SYNCD</c> — os modelos de contatos e a projeção (<c>FIA</c> + <c>INT</c>).
        ///
        /// Chamam-no o `Apagar Páginas` (`cPup1SWxSYc`) e o `Renumerar Páginas`
        /// (`C8Op1CM1YgS`), que no original rodam a mesma família.
        /// </summary>
        internal static string SincronizacoesDoCaderno()
        {
            return "[1/3] " + ExecutarCorrigirModelosDeContatos()
                + " [2/3] " + ExecutarFiacao()
                + " [3/3] " + ExecutarInterligacao();
        }

        /// <summary>
        /// <c>INSPAG</c> / <c>INSEREPAGINA</c> — insere uma página calculada entre a página anterior
        /// (<c>POSITRON_PAGINA_ANTERIOR</c> ou a ativa) e a posterior (<c>POSITRON_PAGINA_POSTERIOR</c> ou a próxima válida).
        /// </summary>
        [CommandMethod("INSPAG")]
        public void ComandoInsPag()
        {
            Plugin.Escrever(ExecutarInserirPagina());
        }

        [CommandMethod("INSEREPAGINA")]
        public void ComandoInserePagina()
        {
            Plugin.Escrever(ExecutarInserirPagina());
        }

        /// <summary>A inserção de página entre duas páginas e o resumo. Nunca lança.</summary>
        internal static string ExecutarInserirPagina()
        {
            try
            {
                ConfiguracaoPositron config = ConfiguracaoEfetiva.Carregar();
                List<string> paginas = Positron.Plugin.Paginas.PaginasDoDesenho.Ler();
                if (paginas.Count == 0)
                {
                    return "INSPAG: nenhuma página do caderno no desenho.";
                }

                string anterior = System.Environment.GetEnvironmentVariable("POSITRON_PAGINA_ANTERIOR");
                if (string.IsNullOrEmpty(anterior))
                {
                    anterior = System.Environment.GetEnvironmentVariable("POSITRON_PAGINA");
                }
                if (string.IsNullOrEmpty(anterior))
                {
                    anterior = Positron.Plugin.Paginas.PaginaAtivaDoDesenho.Ler();
                }
                if (!EstaNoCaderno(paginas, anterior))
                {
                    anterior = paginas[paginas.Count - 1];
                }

                string posterior = System.Environment.GetEnvironmentVariable("POSITRON_PAGINA_POSTERIOR");
                if (string.IsNullOrEmpty(posterior))
                {
                    posterior = PaginasDoCaderno.ProximaValida(paginas, anterior);
                }

                PaginaCalculada nova = NovaPaginaEntre.Calcular(anterior, posterior, config.PassoPagina);
                if (!NovaPaginaEntre.Cabe(nova))
                {
                    return "INSPAG: não cabe página entre \"" + anterior + "\" e \"" + (posterior ?? "") + "\" — nada criado.";
                }

                Positron.Plugin.Paginas.CriacaoDePaginaDoDesenho.Resultado resultado =
                    Positron.Plugin.Paginas.CriacaoDePaginaDoDesenho.Executar(
                        nova.Pagina, config.LarguraFixaPaginas, string.Empty, string.Empty, anterior);

                if (resultado.JaExistia)
                {
                    return "INSPAG: o layer \"" + resultado.Nome + "\" já existe — página não criada.";
                }

                return "INSPAG: página \"" + resultado.Nome + "\" inserida entre \"" + anterior + "\" e \""
                    + (string.IsNullOrEmpty(posterior) ? "fim" : posterior) + "\" — layer"
                    + (resultado.TemFormato
                        ? " + " + resultado.CamposCopiados + " campo(s) do formato"
                        : " (desenho sem bloco de formato)")
                    + (resultado.TitulosCopiados > 0
                        ? " + " + resultado.TitulosCopiados + " título(s) herdado(s) de \"" + anterior + "\""
                        : string.Empty)
                    + (resultado.ContTotFlAtualizados > 0
                        ? " + " + resultado.ContTotFlAtualizados + " CONT/FL/TOT recalculado(s)."
                        : ".");
            }
            catch (System.Exception erro)
            {
                return "INSPAG: falhou — " + DescreverErro(erro) + ".";
            }
        }

        /// <summary>
        /// O que a criação de página fez — e **qual** das recusas do original ela encontrou (cada uma
        /// tem o seu `MsgBox` no `TBNp1Uume8n`, `uscPaginas.cs:1948-1963`).
        /// </summary>
        internal sealed class ResultadoDaNovaPagina
        {
            internal string Resumo { get; set; } = string.Empty;

            internal bool Criada { get; set; }

            /// <summary>A página calculada não cabe (o `PgNum == 0` → mMensagem 31).</summary>
            internal bool SemEspaco { get; set; }

            /// <summary>O layer já existe (o `CriarLayer` devolvendo `-1` → mMensagem 32).</summary>
            internal bool JaExistia { get; set; }

            /// <summary>Não foi possível criar (o `CriarLayer` devolvendo `0` → mMensagem 33).</summary>
            internal bool NaoCriou { get; set; }
        }

        /// <summary>A criação da página pela **página ativa** e a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarNovaPagina()
        {
            try
            {
                List<string> paginas = Positron.Plugin.Paginas.PaginasDoDesenho.Ler();
                if (paginas.Count == 0)
                {
                    return "NOVAPAGINA: nenhuma página do caderno no desenho (os layers que o LayerValido aceita).";
                }

                // A página **ativa** do desenho (o `DeclaracoesGeral.ativo.Pagina` do
                // `criarUmaNovaPagina`); `POSITRON_PAGINA` a sobrepõe (o recorte de teste, como no
                // `ATIVAPAGINA`) e, sem ela (ou fora do caderno), a última.
                string ativa = System.Environment.GetEnvironmentVariable("POSITRON_PAGINA");
                if (string.IsNullOrEmpty(ativa))
                {
                    ativa = Positron.Plugin.Paginas.PaginaAtivaDoDesenho.Ler();
                }

                if (!EstaNoCaderno(paginas, ativa))
                {
                    ativa = paginas[paginas.Count - 1];
                }

                // A nova entra **depois da ativa**, como o original: a posterior é a próxima válida
                // (e o fim quando a ativa é a última), para a página caber no meio.
                return ExecutarNovaPagina(ativa, PaginasDoCaderno.ProximaValida(paginas, ativa)).Resumo;
            }
            catch (System.Exception erro)
            {
                return "NOVAPAGINA: falhou — " + DescreverErro(erro) + ".";
            }
        }

        /// <summary>
        /// A criação com a **referência** e a **posterior** explícitas — o par que a grade das folhas
        /// selecionou (o `TBNp1Uume8n` do original, `uscPaginas.cs:1893-1972`, que parte da linha
        /// selecionada e da seguinte). Nunca lança.
        /// </summary>
        internal static ResultadoDaNovaPagina ExecutarNovaPagina(string referencia, string posterior)
        {
            ResultadoDaNovaPagina retorno = new ResultadoDaNovaPagina();
            try
            {
                ConfiguracaoPositron config = ConfiguracaoEfetiva.Carregar();
                string anterior = (referencia ?? string.Empty).Trim();
                if (anterior.Length == 0)
                {
                    retorno.NaoCriou = true;
                    retorno.Resumo = "NOVAPAGINA: sem página de referência — nada criado.";
                    return retorno;
                }

                PaginaCalculada nova = NovaPaginaEntre.Calcular(anterior, posterior, config.PassoPagina);
                if (!NovaPaginaEntre.Cabe(nova))
                {
                    retorno.SemEspaco = true;
                    retorno.Resumo = "NOVAPAGINA: não cabe página depois de \"" + anterior + "\" — nada criado.";
                    return retorno;
                }

                // Unidade/alternativo vazios, como o `criarUmaNovaPagina` do original (ele zera os
                // dois antes do `CriarLayer`; quem os edita é a fatia 5).
                Positron.Plugin.Paginas.CriacaoDePaginaDoDesenho.Resultado resultado =
                    Positron.Plugin.Paginas.CriacaoDePaginaDoDesenho.Executar(
                        nova.Pagina, config.LarguraFixaPaginas, string.Empty, string.Empty, anterior);

                if (resultado.JaExistia)
                {
                    retorno.JaExistia = true;
                    retorno.Resumo = "NOVAPAGINA: o layer \"" + resultado.Nome + "\" já existe — página não criada (depois de \""
                        + anterior + "\" a nova seria \"" + nova.Pagina + "\", passo " + config.PassoPagina + ").";
                    return retorno;
                }

                if (resultado.Nome.Length == 0)
                {
                    retorno.NaoCriou = true;
                    retorno.Resumo = "NOVAPAGINA: a página calculada \"" + nova.Pagina + "\" não pôde ser criada (nome vazio).";
                    return retorno;
                }

                retorno.Criada = true;
                retorno.Resumo = "NOVAPAGINA: página \"" + resultado.Nome + "\" criada depois de \"" + anterior + "\" — layer"
                    + (resultado.TemFormato
                        ? " + " + resultado.CamposCopiados + " campo(s) do formato copiado(s)"
                        : " (o desenho não tem bloco de formato: nenhum campo copiado)")
                    + (resultado.TitulosCopiados > 0
                        ? " + " + resultado.TitulosCopiados + " título(s) herdado(s) de \"" + anterior + "\""
                        : string.Empty)
                    + (resultado.ContTotFlAtualizados > 0
                        ? " + " + resultado.ContTotFlAtualizados + " CONT/FL/TOT recalculado(s)."
                        : ".");
                return retorno;
            }
            catch (System.Exception erro)
            {
                retorno.Resumo = "NOVAPAGINA: falhou — " + DescreverErro(erro) + ".";
                return retorno;
            }
        }

        /// <summary>A página está na lista do caderno? (sem caixa, como as comparações do original.)</summary>
        private static bool EstaNoCaderno(IReadOnlyList<string> paginas, string pagina)
        {
            if (string.IsNullOrEmpty(pagina))
            {
                return false;
            }

            foreach (string nome in paginas)
            {
                if (string.Equals(nome ?? string.Empty, pagina, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>A correção da interligação e a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarCorrecaoDaInterligacao()
        {
            try
            {
                CorrecaoDaInterligacaoDoDesenho.Resultado resultado =
                    CorrecaoDaInterligacaoDoDesenho.Executar();

                return "CorrigeInterligacao: " + resultado.Corrigidos + " de "
                    + resultado.TrechosIndefinidos + " trecho(s) indefinido(s) regravado(s); "
                    + resultado.SemDispositivo + " sem dispositivo na(s) ponta(s) ("
                    + resultado.TrechosLidos + " trecho(s) lido(s); "
                    + resultado.BlocosNaCaixa + " bloco(s) na(s) caixa(s) das pontas).";
            }
            catch (System.Exception erro)
            {
                return "CorrigeInterligacao: falhou — " + DescreverErro(erro) + ".";
            }
        }


        /// <summary>
        /// <c>EPLQ</c> — exporta as **plaquetas** do desenho para <c>Plaquetas4</c>
        /// (o <c>clsDispositivoTacito.exportaPlaquetas()</c>, o <c>EPLQ</c> do
        /// reverso). Lê o dicionário de plaquetas do **próprio desenho**
        /// (<c>CENG_PLAQUETA</c>), resolve o nome de cada uma (painel, dispositivo,
        /// texto livre ou régua) e grava as que têm descrição — o cadastro de
        /// painéis (<c>Paineis</c>) é que dá os nomes do tipo <c>P</c>.
        /// </summary>
        [CommandMethod("EPLQ")]
        public void ExportarPlaquetas()
        {
            Plugin.Escrever(ExecutarPlaquetas());
        }

        /// <summary>
        /// Exporta as plaquetas do desenho e devolve a linha de resumo. Nunca lança.
        /// </summary>
        internal static string ExecutarPlaquetas()
        {
            ConfiguracaoPositron config = ConfiguracaoEfetiva.Carregar();
            string caminho = config.Banco;
            if (string.IsNullOrEmpty(caminho))
            {
                return "EPLQ: " + Positron.Data.Interface.MensagensDoReverso.BancoNaoConfigurado;
            }

            try
            {
                ProjectStore store = new ProjectStore(caminho);
                IReadOnlyDictionary<int, string> nomesDePaineis = store.LerNomesDePaineis();

                // `dicPainel` vazio é ausência de dado: sem nome de painel não há
                // como resolver as plaquetas do tipo "P".
                if (nomesDePaineis.Count == 0)
                {
                    return "EPLQ: cadastro de painéis vazio (Paineis) — importe o cadastro antes de exportar as plaquetas.";
                }

                Dictionary<int, IReadOnlyList<PlaquetaDefinicao>> dicionario = PlaquetasDoDesenho.LerDicionario();
                if (dicionario.Count == 0)
                {
                    return "EPLQ: nenhum painel com plaquetas no dicionário CENG_PLAQUETA do desenho.";
                }

                ReguasModelo reguas = ReguasDoDesenho.Ler();
                HashSet<int> paineisComFiacao = PlaquetasDoDesenho.PaineisComFiacao();
                Dictionary<int, IReadOnlyDictionary<string, string>> nomesDeDispositivos =
                    PlaquetasDoDesenho.NomesDeDispositivosPorPainel();

                List<Plaquetas4Row> linhas = Plaquetas4Gerador.Gerar(
                    config.Dwg, dicionario, nomesDePaineis, reguas, paineisComFiacao, nomesDeDispositivos);

                store.InserirPlaquetas(linhas, config.Dwg);

                return "EPLQ: " + linhas.Count + " plaqueta(s) em Plaquetas4 ("
                    + dicionario.Count + " painel(is) com dicionário; " + paineisComFiacao.Count
                    + " painel(is) com fiação no desenho).";
            }
            catch (System.Exception erro)
            {
                return "EPLQ: falhou — " + DescreverErro(erro);
            }
        }

        /// <summary>
        /// <c>COMPLM</c> — compila a **lista de materiais** do desenho para
        /// <c>ListaMateriais</c> (o <c>clsLM.CompilaListaDeMateriais()</c>, o
        /// <c>COMPLM</c> do reverso).
        ///
        /// Cada bloco do ModelSpace vira linha de material: a **máscara** (<c>M</c>) e
        /// o **dispositivo** (<c>P</c>) até duas (uma por LM do modelo) e o **borne**
        /// (<c>B</c>) uma **agregada** por <c>(Painel, régua, tipo, lm)</c> — mais as
        /// reservas das réguas. A ordenação e a renumeração por painel são as do
        /// original, incluindo a bolha defeituosa da segunda passada (ver
        /// <see cref="ListaMateriaisGerador"/>).
        /// </summary>
        [CommandMethod("COMPLM")]
        public void CompilarListaDeMateriais()
        {
            Plugin.Escrever(ExecutarListaDeMateriais());
        }

        /// <summary>
        /// Compila a lista de materiais e devolve a linha de resumo. Nunca lança.
        ///
        /// A ordem das operações é a do original: lê a ordem anterior (quando
        /// <c>POSITRON_LM_ORDEM_BANCO</c>), apaga as linhas **não-avulsas** do desenho,
        /// limpa as listas de desenhos fora do cadastro, relê os **avulsos** (que
        /// sobrevivem e são regravados) e só então projeta e grava.
        /// </summary>
        internal static string ExecutarListaDeMateriais()
        {
            ConfiguracaoPositron config = ConfiguracaoEfetiva.Carregar();
            string caminho = config.Banco;
            if (string.IsNullOrEmpty(caminho))
            {
                return "COMPLM: " + Positron.Data.Interface.MensagensDoReverso.BancoNaoConfigurado;
            }

            try
            {
                ProjectStore store = new ProjectStore(caminho);
                bool ordemDoBanco = config.OrdemListaNoBanco;

                // `CarregaOrdemEmMateriais` — lê a ordem ANTES de apagar (o original
                // pergunta ao usuário e, no "Sim", usa a lista que já estava no banco).
                List<LinhaListaMaterial> ordem = ordemDoBanco ? store.LerListaMateriais(config.Dwg) : null;

                // `RemoveMateriaisLista` + `AtualizaLMBaseadoNosDWGsCadastrados`.
                store.RemoverListaMateriaisNaoAvulsos(config.Dwg);
                store.RemoverListaMateriaisDeDwgsForaDoCadastro();

                // `CapturaMateriaisAvulso` — o que o usuário lançou à mão sobrevive.
                List<LinhaListaMaterial> avulsos = store.LerListaMateriaisAvulsos(config.Dwg);

                ReguasModelo reguas = ReguasDoDesenho.Ler();
                IReadOnlyList<PontoBorne> bornes = BornesDoDesenho.Ler(reguas);
                IReadOnlyList<DispositivoFiacao> dispositivos = DispositivosDeFiacaoDoDesenho.Ler();

                Dictionary<int, ModeloMascara> modelosMascara = IndexarPorIndice(ModelosMascaraDoDesenho.LerModelos());
                Dictionary<int, ModeloContato> modelosContato = IndexarPorIndice(ContatosDoDesenho.LerModelos());

                // As reservas de todas as réguas entram na lista (o
                // `LeDicBornesReservaTodos` do original).
                Dictionary<int, IReadOnlyList<BorneReserva>> reservasPorRegua =
                    new Dictionary<int, IReadOnlyList<BorneReserva>>();
                foreach (ReguaInfo regua in reguas.Ordenadas)
                {
                    if (regua != null)
                    {
                        reservasPorRegua[regua.Indice] = BornesReservaDoDesenho.Ler(regua.Indice);
                    }
                }

                List<int> paineis = new List<int>();
                foreach (ReguaInfo regua in reguas.Ordenadas)
                {
                    AcrescentarPainel(paineis, regua == null ? 0 : regua.Painel);
                }

                foreach (PontoBorne borne in bornes)
                {
                    AcrescentarPainel(paineis, borne.Painel);
                }

                foreach (DispositivoFiacao dispositivo in dispositivos)
                {
                    AcrescentarPainel(paineis, dispositivo.Painel);
                }

                LayoutPosicoes layout = LayoutDoDesenho.Ler(paineis);

                // Bornes cuja régua não está no dicionário saem com painel 0 e **não**
                // entram na lista — o `indexPainel != 0` do original. É o número que
                // explica (ou não) uma diferença de população contra o produto, então
                // ele vai no resumo.
                int bornesSemRegua = 0;
                foreach (PontoBorne borne in bornes)
                {
                    if (borne.Painel == 0)
                    {
                        bornesSemRegua++;
                    }
                }

                List<LinhaListaMaterial> linhas = ListaMateriaisGerador.Gerar(
                    config.Dwg,
                    dispositivos,
                    modelosMascara,
                    modelosContato,
                    bornes,
                    reguas,
                    reservasPorRegua,
                    layout,
                    avulsos,
                    ordem,
                    ordemDoBanco);

                int gravados = store.InserirListaMateriais(linhas, config.Dwg);

                return "COMPLM: " + gravados + " linha(s) em ListaMateriais ("
                    + ContarPaineis(linhas) + " painel(is); " + avulsos.Count + " avulso(s); "
                    + bornes.Count + " borne(s) do desenho, " + bornesSemRegua + " sem régua no dicionário; "
                    + "ordem do " + (ordemDoBanco ? "banco" : "desenho") + "; "
                    + (layout.EstaVazia ? "sem layout CENG_LAYOUT" : layout.NumPosicoes + " posição(ões) de layout")
                    + ").";
            }
            catch (System.Exception erro)
            {
                return "COMPLM: falhou — " + DescreverErro(erro);
            }
        }

        /// <summary>
        /// <c>ApagarTextosEmBranco</c> — apaga do ModelSpace os <c>DBText</c> sem
        /// texto (só espaços) e sem XData (frente 2 do §7.6, o <c>Correcao.cs</c>).
        /// Limpeza pura de desenho: não lê banco nem cadastro.
        /// </summary>
        [CommandMethod("ApagarTextosEmBranco")]
        public void ApagarTextosVazios()
        {
            Plugin.Escrever(ExecutarApagarTextosEmBranco());
        }

        /// <summary>Apaga os textos em branco do desenho e devolve a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarApagarTextosEmBranco()
        {
            try
            {
                Limpeza.LimpezaDoCad.Resultado resultado = Limpeza.LimpezaDoCad.ApagarTextosEmBranco();
                return "ApagarTextosEmBranco: " + resultado.Alterados + " texto(s) apagado(s) ("
                    + resultado.Lidos + " DBText lido(s) no ModelSpace).";
            }
            catch (System.Exception erro)
            {
                return "ApagarTextosEmBranco: falhou — " + DescreverErro(erro);
            }
        }

        /// <summary>
        /// <c>apagaXDataTerceiros</c> — tira do ModelSpace o XData do app name de
        /// terceiros (<c>AEC_XDATA_BOUND_SPACE</c>), regravando o buffer com a marca
        /// única do original.
        /// </summary>
        [CommandMethod("apagaXDataTerceiros")]
        public void ApagarXDataTerceiros()
        {
            Plugin.Escrever(ExecutarApagarXDataTerceiros());
        }

        /// <summary>Apaga o XData de terceiros e devolve a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarApagarXDataTerceiros()
        {
            try
            {
                Limpeza.LimpezaDoCad.Resultado resultado = Limpeza.LimpezaDoCad.ApagarXDataTerceiros();
                return "apagaXDataTerceiros: " + resultado.Alterados + " entidade(s) com XData de terceiros limpo(s) ("
                    + resultado.Lidos + " entidade(s) no ModelSpace).";
            }
            catch (System.Exception erro)
            {
                return "apagaXDataTerceiros: falhou — " + DescreverErro(erro);
            }
        }

        /// <summary>
        /// <c>ApagaLayouts</c> — apaga o dicionário <c>CENG_LAYOUT</c> do desenho (a
        /// posição dos equipamentos no layout dos painéis). Depois dele o <c>FIA</c>
        /// projeta sem <c>PosicaoNum</c> e o <c>COMPLM</c> sai "sem layout".
        /// </summary>
        [CommandMethod("ApagaLayouts")]
        public void RemoverLayouts()
        {
            Plugin.Escrever(ExecutarApagarLayouts());
        }

        /// <summary>Apaga o dicionário de layout e devolve a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarApagarLayouts()
        {
            try
            {
                Limpeza.LimpezaDoCad.Resultado resultado = Limpeza.LimpezaDoCad.ApagarDicionarioLayout();
                return "ApagaLayouts: " + (resultado.Alterados > 0
                    ? "dicionário CENG_LAYOUT apagado do desenho."
                    : "o desenho não tem dicionário CENG_LAYOUT.");
            }
            catch (System.Exception erro)
            {
                return "ApagaLayouts: falhou — " + DescreverErro(erro);
            }
        }

        /// <summary>
        /// <c>ApagaPlaquetas</c> — apaga o dicionário <c>CENG_PLAQUETA</c> do desenho
        /// (as plaquetas de identificação dos painéis, o insumo do <c>EPLQ</c>).
        /// </summary>
        [CommandMethod("ApagaPlaquetas")]
        public void RemoverPlaquetas()
        {
            Plugin.Escrever(ExecutarApagarPlaquetas());
        }

        /// <summary>Apaga o dicionário de plaquetas e devolve a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarApagarPlaquetas()
        {
            try
            {
                Limpeza.LimpezaDoCad.Resultado resultado = Limpeza.LimpezaDoCad.ApagarDicionarioPlaquetas();
                return "ApagaPlaquetas: " + (resultado.Alterados > 0
                    ? "dicionário CENG_PLAQUETA apagado do desenho."
                    : "o desenho não tem dicionário CENG_PLAQUETA.");
            }
            catch (System.Exception erro)
            {
                return "ApagaPlaquetas: falhou — " + DescreverErro(erro);
            }
        }

        /// <summary>
        /// <c>apagarTodosOsTextosDasVeias</c> — apaga os **rótulos auxiliares** das
        /// veias do ModelSpace: o <c>DBText</c> com XData <c>AUXINTERLIG</c> do tipo 1
        /// e qualquer entidade com o XData <c>ELETROSUL</c> (frente 2 do §7.6, o
        /// <c>Correcao.cs</c>). Limpeza pura de desenho: não lê banco nem cadastro.
        /// </summary>
        [CommandMethod("apagarTodosOsTextosDasVeias")]
        public void ApagarTextosDasVeias()
        {
            Plugin.Escrever(ExecutarApagarTextosDasVeias());
        }

        /// <summary>Apaga os rótulos auxiliares das veias e devolve a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarApagarTextosDasVeias()
        {
            try
            {
                Limpeza.TextosDasVeiasDoDesenho.Resultado resultado =
                    Limpeza.TextosDasVeiasDoDesenho.Executar();
                return "apagarTodosOsTextosDasVeias: " + resultado.Apagados + " rótulo(s) de veia apagado(s) ("
                    + resultado.EntidadesLidas + " entidade(s) no ModelSpace; "
                    + resultado.RotulosAuxiliares + " com AUXINTERLIG e "
                    + resultado.RotulosEletrosul + " com ELETROSUL).";
            }
            catch (System.Exception erro)
            {
                return "apagarTodosOsTextosDasVeias: falhou — " + DescreverErro(erro);
            }
        }

        /// <summary>
        /// <c>corrigeOrdemBornes</c> — renumerar a <c>Ordem</c> dos bornes por régua
        /// (1..N, pulando as ordens das reservas), o botão de correção do
        /// <c>Correcao.cs</c> do original — a contrapartida de **escrita** do
        /// <c>IntervaloBorneInvalido</c> que o <c>VERIF</c> aponta. Regrava o XData
        /// dos bornes que mudam, resolvendo o <c>lm</c> no dicionário de réguas
        /// (como o <c>GravarXDataDispBorne</c> do original).
        /// </summary>
        [CommandMethod("corrigeOrdemBornes")]
        public void CorrigirOrdemDosBornes()
        {
            Plugin.Escrever(ExecutarCorrigirOrdemDosBornes());
        }

        /// <summary>Corrige a ordem dos bornes e devolve a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarCorrigirOrdemDosBornes()
        {
            try
            {
                Correcoes.OrdemDosBornesDoDesenho.Resultado resultado =
                    Correcoes.OrdemDosBornesDoDesenho.Executar();

                return "corrigeOrdemBornes: " + resultado.BornesAjustados + " de "
                    + resultado.BornesLidos + " borne(s) renumerado(s)"
                    + (resultado.LmResolvidos > 0
                        ? " (" + resultado.LmResolvidos + " com o lm do dicionário de réguas)"
                        : string.Empty)
                    + ".";
            }
            catch (System.Exception erro)
            {
                return "corrigeOrdemBornes: falhou — " + DescreverErro(erro);
            }
        }

        /// <summary>
        /// <c>CorrigeBornes</c> — põe em <c>0</c> o campo <c>Visivel</c> do borne que
        /// está em <c>-1</c> (o <c>CorrecaoBornesVisiveis</c> do <c>Correcao.cs</c>),
        /// regravando o XData pelo mesmo caminho do original.
        /// </summary>
        [CommandMethod("CorrigeBornes")]
        public void CorrigirVisibilidadeDosBornes()
        {
            Plugin.Escrever(ExecutarCorrigirVisibilidadeDosBornes());
        }

        /// <summary>Corrige a visibilidade dos bornes e devolve a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarCorrigirVisibilidadeDosBornes()
        {
            try
            {
                Correcoes.BornesVisiveisDoDesenho.Resultado resultado =
                    Correcoes.BornesVisiveisDoDesenho.Executar();

                return "CorrigeBornes: " + resultado.BornesCorrigidos + " de "
                    + resultado.BornesLidos + " borne(s) com a visibilidade corrigida"
                    + (resultado.LmResolvidos > 0
                        ? " (" + resultado.LmResolvidos + " com o lm do dicionário de réguas)"
                        : string.Empty)
                    + ".";
            }
            catch (System.Exception erro)
            {
                return "CorrigeBornes: falhou — " + DescreverErro(erro);
            }
        }

        /// <summary>
        /// <c>CorrigeDisp</c> — renomeia o app name legado <c>DISPOSITIVO</c> para
        /// <c>Dispositivo</c> na tabela <c>APPID</c> do desenho (o <c>CorrecaoDisp</c>
        /// do <c>Correcao.cs</c>). Os leitores já aceitam os dois nomes; a migração
        /// deixa um só.
        /// </summary>
        [CommandMethod("CorrigeDisp")]
        public void CorrigirAppNameDosDispositivos()
        {
            Plugin.Escrever(ExecutarCorrigirAppNameDosDispositivos());
        }

        /// <summary>Renomeia o app name legado e devolve a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarCorrigirAppNameDosDispositivos()
        {
            try
            {
                Correcoes.AppNameDoDesenho.Resultado resultado = Correcoes.AppNameDoDesenho.Executar();

                return "CorrigeDisp: " + (resultado.Renomeado
                    ? "app name DISPOSITIVO renomeado para Dispositivo."
                    : resultado.TinhaLegado
                        ? "o CAD não aplicou o rename do app name DISPOSITIVO (a busca de app name não diferencia caixa, então não há o que migrar)."
                        : "o desenho não tem o app name legado DISPOSITIVO.");
            }
            catch (System.Exception excecao)
            {
                return "CorrigeDisp: falhou — " + DescreverErro(excecao);
            }
        }

        /// <summary>
        /// <c>CorrigeStyle</c> — corrige os **estilos de texto** do desenho (o
        /// <c>corrigeStyles</c> do <c>Correcao.cs</c>): o estilo sem fonte
        /// (<c>FileName == ""</c>) ou com escala horizontal zero (<c>XScale == 0</c>)
        /// recebe a fonte/escala/altura da referência (<c>arial.ttf</c> ou, sem ela,
        /// o último estilo da tabela). Só olha o desenho.
        /// </summary>
        [CommandMethod("CorrigeStyle")]
        public void CorrigirEstilosDeTexto()
        {
            Plugin.Escrever(ExecutarCorrigirEstilosDeTexto());
        }

        /// <summary>Corrige os estilos de texto e devolve a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarCorrigirEstilosDeTexto()
        {
            try
            {
                Correcoes.EstilosDoDesenho.Resultado resultado =
                    Correcoes.EstilosDoDesenho.Executar();

                if (resultado.EstilosComProblema == 0)
                {
                    return "CorrigeStyle: os " + resultado.EstilosLidos
                        + " estilo(s) de texto do desenho estão sem problema de fonte.";
                }

                string lista = string.Join(", ", resultado.Problemas);
                return "CorrigeStyle: " + resultado.EstilosCorrigidos + " de "
                    + resultado.EstilosLidos + " estilo(s) de texto corrigido(s) "
                    + "(referência: " + resultado.EstiloReferencia
                    + (resultado.TemReferenciaArial ? "" : ", sem arial.ttf no desenho")
                    + "; problemas: " + lista + ").";
            }
            catch (System.Exception erro)
            {
                return "CorrigeStyle: falhou — " + DescreverErro(erro);
            }
        }

        /// <summary>
        /// <c>SobeLm</c> — **sobe o <c>lm</c> da régua** para o XData dos bornes: o
        /// borne com <c>lm == 0</c> (o <c>BorneSemLm</c> que o <c>VERIF</c> aponta)
        /// recebe o <c>lm</c> que a régua dele define para o tipo — o campo +6/+7 do
        /// <c>REGUAS/MODELOS2</c> (o que o original lê) ou, quando ele não define, o
        /// dicionário de bornes da régua (<c>CENG_BORNES</c>), medido na rodada 74.
        /// Comando **próprio do recoder**: o original só resolve o <c>lm</c> ao
        /// regravar um borne, e o campo do <c>MODELOS2</c> que ele lê nunca é
        /// gravado pelo próprio original (o <c>GravaOsModelosDeRegua</c> escreve 0).
        /// </summary>
        [CommandMethod("SobeLm")]
        public void SubirLmDosBornes()
        {
            Plugin.Escrever(ExecutarSubirLmDosBornes());
        }

        /// <summary>Sobe o lm dos bornes e devolve a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarSubirLmDosBornes()
        {
            try
            {
                Correcoes.LmDosBornesDoDesenho.Resultado resultado =
                    Correcoes.LmDosBornesDoDesenho.Executar();

                if (resultado.BornesSemLm == 0)
                {
                    return "SobeLm: os " + resultado.BornesLidos
                        + " borne(s) do desenho já têm lm.";
                }

                return "SobeLm: " + resultado.BornesCorrigidos + " de "
                    + resultado.BornesLidos + " borne(s) ganharam o lm da régua ("
                    + resultado.BornesSemLm + " com lm zerado; "
                    + resultado.SemDefinicao + " sem definição para o tipo na régua).";
            }
            catch (System.Exception erro)
            {
                return "SobeLm: falhou — " + DescreverErro(erro);
            }
        }

        /// <summary>
        /// <c>corrigeDicMascaras</c> — normaliza a lista de portas de cada modelo de
        /// máscara no dicionário <c>MASCARAS</c> do desenho: tira as portas com índice
        /// repetido (fica a **primeira**), ordena por índice e acerta o <c>MaxIndice</c>
        /// do registro (frente 2 do §7.6, o <c>Correcao.cs</c>). É o par de escrita do
        /// <c>bt13ReguaMascara</c>. Só olha o desenho.
        /// </summary>
        [CommandMethod("corrigeDicMascaras")]
        public void CorrigirDicionarioDeMascaras()
        {
            Plugin.Escrever(ExecutarCorrigirDicionarioDeMascaras());
        }

        /// <summary>Normaliza o dicionário de máscaras e devolve a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarCorrigirDicionarioDeMascaras()
        {
            try
            {
                Correcoes.PortasDaMascaraDoDesenho.Resultado resultado =
                    Correcoes.PortasDaMascaraDoDesenho.Executar();

                if (resultado.ModelosLidos == 0)
                {
                    return "corrigeDicMascaras: o desenho não tem modelos de máscara no dicionário MASCARAS.";
                }

                return "corrigeDicMascaras: " + resultado.ModelosAlterados + " de "
                    + resultado.ModelosLidos + " modelo(s) de máscara normalizado(s) ("
                    + resultado.PortasDuplicadas + " porta(s) duplicada(s) descartada(s); "
                    + resultado.PortasLidas + " porta(s) lida(s); "
                    + resultado.ModelosSemRegistro + " sem registro de portas).";
            }
            catch (System.Exception erro)
            {
                return "corrigeDicMascaras: falhou — " + DescreverErro(erro);
            }
        }

        /// <summary>
        /// <c>CorrigeContatosAux</c> — preenche o <c>HandleContatoAux</c> do XData
        /// <c>Modelo</c> de cada bloco de modelo com o handle do **bloco auxiliar**
        /// (tipo <c>A</c>) que casa pela chave (HandleBob, indexModelo, indexContato) —
        /// o par de escrita do <c>bt4Auxiliar</c> (frente 2 do §7.6, o <c>Correcao.cs</c>).
        /// </summary>
        [CommandMethod("CorrigeContatosAux")]
        public void CorrigirContatosAuxiliares()
        {
            Plugin.Escrever(ExecutarCorrigirContatosAuxiliares());
        }

        /// <summary>Acerta o HandleContatoAux dos modelos e devolve a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarCorrigirContatosAuxiliares()
        {
            try
            {
                Correcoes.ContatosAuxiliaresDoDesenho.Resultado resultado =
                    Correcoes.ContatosAuxiliaresDoDesenho.Executar();

                if (resultado.ModelosLidos == 0)
                {
                    return "CorrigeContatosAux: o desenho não tem blocos de modelo (XData Modelo).";
                }

                return "CorrigeContatosAux: " + resultado.ModelosAlterados + " de "
                    + resultado.ModelosLidos + " modelo(s) com o HandleContatoAux acertado ("
                    + resultado.AuxiliaresLidos + " bloco(s) auxiliar(es) lido(s); "
                    + resultado.SemContato + " modelo(s) sem contato casado).";
            }
            catch (System.Exception erro)
            {
                return "CorrigeContatosAux: falhou — " + DescreverErro(erro);
            }
        }

        /// <summary>
        /// <c>RecriaTextosCabo</c> — apaga os rótulos auxiliares das veias (a regra do
        /// <c>clsEletron.ApagarTodosOsTextosDasVeias</c>) e **reinsere um por trecho de
        /// interligação** que ficou sem rótulo, no modelo padrão — o
        /// <c>clsEditarInterligacao.InsereTextosDeCabos(bPadraoEL: true)</c>. Lê o
        /// catálogo (<c>Cabos.Formacao like 1x</c>) para o caso do cabo singelo.
        /// </summary>
        [CommandMethod("RecriaTextosCabo")]
        public void RecriarTextosDeCabo()
        {
            Plugin.Escrever(ExecutarRecriarTextosDeCabo());
        }

        /// <summary>Recria os rótulos de cabo e devolve a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarRecriarTextosDeCabo()
        {
            try
            {
                RotulosDeCaboDoDesenho.Resultado resultado = RotulosDeCaboDoDesenho.Executar();

                if (resultado.TrechosLidos == 0 && resultado.RotulosApagados == 0)
                {
                    return "RecriaTextosCabo: o desenho não tem trechos de interligação nem rótulos auxiliares.";
                }

                return "RecriaTextosCabo: " + resultado.RotulosApagados + " rótulo(s) apagado(s) e "
                    + resultado.RotulosInseridos + " reinserido(s) de " + resultado.TrechosLidos
                    + " trecho(s) (" + resultado.TrechosComRotulo + " já tinham rótulo; "
                    + resultado.CabosSingelos + " cabo(s) singelo(s) no catálogo"
                    + (resultado.SemCatalogo ? "; sem catálogo" : "") + ").";
            }
            catch (System.Exception erro)
            {
                return "RecriaTextosCabo: falhou — " + DescreverErro(erro);
            }
        }

        /// <summary>
        /// <c>RecriaTextosCaboEletrosul</c> — o irmão da Eletrosul do
        /// <c>RecriaTextosCabo</c>: a mesma limpeza e um rótulo por trecho, com a
        /// geometria própria (<c>criarTextoNomeCaboEletrosul</c>: meio do segmento,
        /// rotação 0, horizontal à esquerda) e <c>iModeloVeiaFuncao = 1</c>.
        /// </summary>
        [CommandMethod("RecriaTextosCaboEletrosul")]
        public void RecriarTextosDeCaboEletrosul()
        {
            Plugin.Escrever(ExecutarRecriarTextosDeCaboEletrosul());
        }

        /// <summary>Recria os rótulos no modelo da Eletrosul e devolve a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarRecriarTextosDeCaboEletrosul()
        {
            try
            {
                RotulosDeCaboDoDesenho.Resultado resultado = RotulosDeCaboDoDesenho.ExecutarEletrosul();

                if (resultado.TrechosLidos == 0 && resultado.RotulosApagados == 0)
                {
                    return "RecriaTextosCaboEletrosul: o desenho não tem trechos de interligação nem rótulos auxiliares.";
                }

                return "RecriaTextosCaboEletrosul: " + resultado.TextosApagados + " texto(s) e "
                    + resultado.OrnamentosApagados + " ornamento(s) apagado(s); "
                    + resultado.RotulosInseridos + " rótulo(s) e " + resultado.OrnamentosInseridos
                    + " ornamento(s) reinserido(s) de " + resultado.TrechosLidos
                    + " trecho(s) (" + resultado.CabosSingelos + " cabo(s) singelo(s) no catálogo"
                    + (resultado.SemCatalogo ? "; sem catálogo" : "") + ").";
            }
            catch (System.Exception erro)
            {
                return "RecriaTextosCaboEletrosul: falhou — " + DescreverErro(erro);
            }
        }

        /// <summary>
        /// <c>CorrigeCabosSingelos</c> — corrige os cabos **singelos** do catálogo cujo
        /// nome de veia tem o marcador <c>#</c>: limpa o <c>Nome_Veia</c> no banco e o
        /// <c>NomeVeia</c> do XData dos trechos, e no fim recria os rótulos (o
        /// <c>RecriaTextosCaboEletrosul</c>), como o original.
        /// </summary>
        [CommandMethod("CorrigeCabosSingelos")]
        public void CorrigirCabosSingelos()
        {
            Plugin.Escrever(ExecutarCorrigirCabosSingelos());
            Plugin.Escrever(ExecutarRecriarTextosDeCaboEletrosul());
        }

        /// <summary>Corrige os cabos singelos e devolve a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarCorrigirCabosSingelos()
        {
            try
            {
                CabosSingelosDoDesenho.Resultado resultado = CabosSingelosDoDesenho.Executar();

                if (resultado.SemBanco)
                {
                    return "CorrigeCabosSingelos: " + Positron.Data.Interface.MensagensDoReverso.BancoNaoConfigurado;
                }

                return "CorrigeCabosSingelos: " + resultado.TrechosLimpos + " trecho(s) com o NomeVeia limpo ("
                    + resultado.Candidatos + " cabo(s) candidato(s); "
                    + resultado.TagsComFlag + " tag(s) com Cabos = 1; "
                    + resultado.VeiasLidas + " veia(s) no catálogo; "
                    + resultado.VeiasLimparNoBanco + " linha(s) do banco atualizada(s); "
                    + resultado.TrechosLidos + " trecho(s) varrido(s)).";
            }
            catch (System.Exception erro)
            {
                return "CorrigeCabosSingelos: falhou — " + DescreverErro(erro);
            }
        }

        /// <summary>
        /// <c>AtualizaOpcionaisDoCabo</c> — reescreve o texto dos rótulos auxiliares dos
        /// tipos 3..6 a partir da receita de opcionais do XData <c>AUXINTERLIG</c>
        /// (o <c>clsUtilitarios.AtualizaTodosOpcionaisDoCabo</c>).
        /// </summary>
        [CommandMethod("AtualizaOpcionaisDoCabo")]
        public void AtualizarOpcionaisDoCabo()
        {
            Plugin.Escrever(ExecutarAtualizarOpcionaisDoCabo());
        }

        /// <summary>Atualiza os opcionais dos rótulos e devolve a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarAtualizarOpcionaisDoCabo()
        {
            try
            {
                OpcionaisDoCaboDoDesenho.Resultado resultado = OpcionaisDoCaboDoDesenho.Executar();

                if (resultado.SemBanco)
                {
                    return "AtualizaOpcionaisDoCabo: " + Positron.Data.Interface.MensagensDoReverso.BancoNaoConfigurado;
                }

                return "AtualizaOpcionaisDoCabo: " + resultado.Alterados + " de "
                    + resultado.Rotulos + " rótulo(s) com os opcionais atualizados ("
                    + resultado.Lidos + " rótulo(s) auxiliares lido(s); "
                    + resultado.SemTrecho + " sem trecho resolvido).";
            }
            catch (System.Exception erro)
            {
                return "AtualizaOpcionaisDoCabo: falhou — " + DescreverErro(erro);
            }
        }

        /// <summary>
        /// <c>LimpaTextosLPCopiados</c> — tira o XData <c>TextoLP</c> dos textos copiados
        /// (o <c>Correcao.cs</c>): o <c>DBText</c> sempre e o <c>MText</c> só abaixo do topo
        /// do desenho (as <c>CONEXAO</c> tipo 1).
        /// </summary>
        [CommandMethod("LimpaTextosLPCopiados")]
        public void LimparTextosLPCopiados()
        {
            Plugin.Escrever(ExecutarLimparTextosLPCopiados());
        }

        /// <summary>Limpa o XData dos textos copiados e devolve a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarLimparTextosLPCopiados()
        {
            try
            {
                Limpeza.TextosLPCopiadosDoDesenho.Resultado resultado =
                    Limpeza.TextosLPCopiadosDoDesenho.Executar();

                if (resultado.ComTextoLP == 0)
                {
                    return "LimpaTextosLPCopiados: nenhum texto com XData TextoLP ("
                        + resultado.MTextosLidos + " MTEXT e " + resultado.TextosLidos
                        + " TEXT lido(s); topo do desenho " + resultado.Topo + ").";
                }

                return "LimpaTextosLPCopiados: " + resultado.Limpos + " de "
                    + resultado.ComTextoLP + " texto(s) com XData TextoLP limpo(s) (topo do desenho "
                    + resultado.Topo + ").";
            }
            catch (System.Exception erro)
            {
                return "LimpaTextosLPCopiados: falhou — " + DescreverErro(erro);
            }
        }

        /// <summary>
        /// <c>REMLAYDUP</c> — o <c>RemoveDuplicadoLayoutRapido</c> do <c>Correcao.cs</c>:
        /// tira os tags repetidos dos XRecords <c>CENG_LAYOUT</c> (<c>P</c>/<c>C</c>) de
        /// cada painel do cadastro. O <c>FIA</c> (<c>PosicaoNum</c>) e o <c>COMPLM</c>
        /// (<c>OrdemLay</c>) leem esse dicionário.
        /// </summary>
        [CommandMethod("REMLAYDUP")]
        public void RemoverDuplicadosDeLayout()
        {
            Plugin.Escrever(ExecutarRemoverDuplicadosDeLayout());
        }

        /// <summary>Remove os duplicados do layout e devolve a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarRemoverDuplicadosDeLayout()
        {
            try
            {
                Correcoes.LayoutDuplicadoDoDesenho.Resultado resultado =
                    Correcoes.LayoutDuplicadoDoDesenho.Executar();

                if (resultado.SemBanco)
                {
                    return "REMLAYDUP: " + Positron.Data.Interface.MensagensDoReverso.BancoNaoConfigurado;
                }

                return "REMLAYDUP: " + resultado.ChavesAlteradas + " de " + resultado.ChavesLidas
                    + " chave(s) de layout regravada(s) (" + resultado.RegistrosAntes + " registro(s) -> "
                    + resultado.RegistrosDepois + "; " + resultado.Paineis + " painel(is) do cadastro).";
            }
            catch (System.Exception erro)
            {
                return "REMLAYDUP: falhou — " + DescreverErro(erro);
            }
        }

        /// <summary>
        /// <c>CorrigeBlocosContatosAux</c> — reescreve os terminais (T1/T2/T3) dos blocos
        /// auxiliares (Dispositivo tipo "A") com o contato do dicionário CONTATOS
        /// (o <c>Correcao.cs</c>). O bloco casa por IndexModelo/IndexContato.
        /// </summary>
        [CommandMethod("CorrigeBlocosContatosAux")]
        public void CorrigirBlocosContatosAux()
        {
            Plugin.Escrever(ExecutarCorrigirBlocosContatosAux());
        }

        /// <summary>Corrige os terminais dos blocos auxiliares e devolve a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarCorrigirBlocosContatosAux()
        {
            try
            {
                Correcoes.BlocosContatosAuxDoDesenho.Resultado resultado =
                    Correcoes.BlocosContatosAuxDoDesenho.Executar();

                if (resultado.Contatos == 0)
                {
                    return "CorrigeBlocosContatosAux: o dicionário CONTATOS não tem contato nenhum ("
                        + resultado.Modelos + " modelo(s)).";
                }

                return "CorrigeBlocosContatosAux: " + resultado.AtributosAlterados + " atributo(s) regravado(s) em "
                    + resultado.BlocosCasados + " de " + resultado.BlocosLidos + " bloco(s) auxiliar(es) ("
                    + resultado.Modelos + " modelo(s) e " + resultado.Contatos + " contato(s) no CONTATOS).";
            }
            catch (System.Exception erro)
            {
                return "CorrigeBlocosContatosAux: falhou — " + DescreverErro(erro);
            }
        }

        /// <summary>
        /// <c>CorrigeModelosDeContatos</c> — acerta o **índice do contato** dos blocos
        /// auxiliares e do XData <c>Modelo</c> quando o <c>CONTATOS</c> tem contato fora
        /// da posição; no fim chama o <c>CorrigeContatosAux</c>, como o original.
        /// </summary>
        [CommandMethod("CorrigeModelosDeContatos")]
        public void CorrigirModelosDeContatos()
        {
            Plugin.Escrever(ExecutarCorrigirModelosDeContatos());
            Plugin.Escrever(ExecutarCorrigirContatosAuxiliares());
        }

        /// <summary>Corrige os índices de contato e devolve a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarCorrigirModelosDeContatos()
        {
            try
            {
                Correcoes.ModelosDeContatosDoDesenho.Resultado resultado =
                    Correcoes.ModelosDeContatosDoDesenho.Executar();

                if (resultado.Ajustes == 0)
                {
                    return "CorrigeModelosDeContatos: nenhum contato fora da posição ("
                        + resultado.Modelos + " modelo(s) e " + resultado.Contatos
                        + " contato(s) no CONTATOS) — nada a corrigir.";
                }

                return "CorrigeModelosDeContatos: " + resultado.Ajustes + " contato(s) renumerado(s); "
                    + resultado.DispositivosAlterados + " bloco(s) com o XData Dispositivo e "
                    + resultado.ModelosAlterados + " com o XData Modelo regravado(s) ("
                    + resultado.AuxiliaresLidos + " auxiliar(es) lido(s); " + resultado.DicionariosAlterados
                    + " dicionário(s) renumerado(s)).";
            }
            catch (System.Exception erro)
            {
                return "CorrigeModelosDeContatos: falhou — " + DescreverErro(erro);
            }
        }

        /// <summary>
        /// <c>corrigePortas</c> — reescreve os atributos dos blocos de porta (Dispositivo
        /// tipo E) com o que diz o dicionário MASCARAS (o <c>EditaTodasPortas</c> do
        /// <c>clsPortas.cs</c>).
        /// </summary>
        [CommandMethod("corrigePortas")]
        public void CorrigirPortas()
        {
            Plugin.Escrever(ExecutarCorrigirPortas());
        }

        /// <summary>Corrige os atributos das portas e devolve a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarCorrigirPortas()
        {
            try
            {
                Correcoes.PortasDoModeloDoDesenho.Resultado resultado =
                    Correcoes.PortasDoModeloDoDesenho.Executar();

                if (resultado.Portas == 0)
                {
                    return "corrigePortas: o dicionário MASCARAS não tem porta nenhuma.";
                }

                return "corrigePortas: " + resultado.AtributosAlterados + " atributo(s) e "
                    + resultado.VisibilidadesAlteradas + " visibilidade(s) regravado(s) em "
                    + resultado.Casados + " de " + resultado.BlocosLidos + " bloco(s) de porta ("
                    + resultado.Portas + " porta(s) no dicionário; " + resultado.SemPorta
                    + " fora dele, " + resultado.Indefinidas + " indefinida(s)).";
            }
            catch (System.Exception erro)
            {
                return "corrigePortas: falhou — " + DescreverErro(erro);
            }
        }

        /// <summary>
        /// <c>CorrigeCoresDosBlocos</c> — a cor dos atributos das referências passa a ser a
        /// da definição do bloco, para os blocos inseridos que têm XData (o <c>Correcao.cs</c>:
        /// carregaBlocosInseridos + MMg1xjoRaA + lu61bhmRNc).
        /// </summary>
        [CommandMethod("CorrigeCoresDosBlocos")]
        public void CorrigirCoresDosBlocos()
        {
            Plugin.Escrever(ExecutarCorrigirCoresDosBlocos());
        }

        /// <summary>Corrige as cores dos atributos e devolve a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarCorrigirCoresDosBlocos()
        {
            try
            {
                Correcoes.CoresDosBlocosDoDesenho.Resultado resultado =
                    Correcoes.CoresDosBlocosDoDesenho.Executar();

                if (resultado.Definicoes == 0)
                {
                    return "CorrigeCoresDosBlocos: nenhum atributo de definição nos blocos inseridos ("
                        + resultado.BlocosInseridos + " nome(s) de bloco com XData).";
                }

                return "CorrigeCoresDosBlocos: " + resultado.AtributosAlterados + " atributo(s) com a cor corrigida ("
                    + resultado.BlocosAlterados + " bloco(s); " + resultado.Definicoes
                    + " atributo(s) de definição em " + resultado.BlocosInseridos + " nome(s) de bloco).";
            }
            catch (System.Exception erro)
            {
                return "CorrigeCoresDosBlocos: falhou — " + DescreverErro(erro);
            }
        }

        /// <summary>
        /// <c>Limpahandle</c> — zera o <c>Handle</c> do XData <c>CONEXAO</c> das
        /// polilinhas de derivação (tipo 3), como o <c>limpaHandleSuperior</c> do
        /// <c>Correcao.cs</c> (a primeira metade do <c>CorrigeHandleSuperior</c>).
        /// </summary>
        [CommandMethod("Limpahandle")]
        public void LimparHandleDasDerivacoes()
        {
            Plugin.Escrever(ExecutarLimparHandleDasDerivacoes());
        }

        /// <summary>Limpa os handles das derivações e devolve a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarLimparHandleDasDerivacoes()
        {
            try
            {
                Limpeza.HandlesDasDerivacoesDoDesenho.Resultado resultado =
                    Limpeza.HandlesDasDerivacoesDoDesenho.Executar();

                return "Limpahandle: " + resultado.HandlesLimpos + " handle(s) de derivação zerado(s) ("
                    + resultado.Derivacoes + " derivação(ões) em " + resultado.ConexoesLidas
                    + " conexão(ões) lida(s)).";
            }
            catch (System.Exception erro)
            {
                return "Limpahandle: falhou — " + DescreverErro(erro);
            }
        }

        /// <summary>
        /// <c>ApagaBlocosMirror</c> — apaga os blocos espelhados (escala X negativa) que
        /// têm algum XData e não são cabo de aranha (DINTERLIG), como o <c>clsUtilitarios.cs</c>.
        /// </summary>
        [CommandMethod("ApagaBlocosMirror")]
        public void ApagarBlocosMirror()
        {
            Plugin.Escrever(ExecutarApagarBlocosMirror());
        }

        /// <summary>Apaga os blocos espelhados e devolve a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarApagarBlocosMirror()
        {
            try
            {
                Correcoes.BlocosMirrorDoDesenho.Resultado resultado =
                    Correcoes.BlocosMirrorDoDesenho.Executar();

                return "ApagaBlocosMirror: " + resultado.Apagados + " bloco(s) espelhado(s) apagado(s) ("
                    + resultado.Espelhados + " espelhado(s) entre " + resultado.ComXData
                    + " com XData; " + resultado.CabosDeAranha + " são cabo de aranha e ficam; "
                    + resultado.BlocosLidos + " bloco(s) lido(s)).";
            }
            catch (System.Exception erro)
            {
                return "ApagaBlocosMirror: falhou — " + DescreverErro(erro);
            }
        }

        /// <summary>
        /// <c>CorrigeTextosDasLigacoes</c> — **achado do reverso:** o corpo desse comando no
        /// <c>clsUtilitarios.cs</c> é **idêntico** ao do <c>ApagaBlocosMirror</c> (o mesmo
        /// laço que apaga os blocos espelhados com XData e sem <c>DINTERLIG</c>); ele não
        /// toca em texto nenhum. Aqui ele reusa o mesmo adapter, e a linha de resumo
        /// registra o achado.
        /// </summary>
        [CommandMethod("CorrigeTextosDasLigacoes")]
        public void CorrigirTextosDasLigacoes()
        {
            Plugin.Escrever(ExecutarCorrigirTextosDasLigacoes());
        }

        /// <summary>
        /// O mesmo efeito do <c>ApagaBlocosMirror</c> (o corpo do original é o mesmo) e
        /// devolve a linha de resumo. Nunca lança.
        /// </summary>
        internal static string ExecutarCorrigirTextosDasLigacoes()
        {
            try
            {
                Correcoes.BlocosMirrorDoDesenho.Resultado resultado =
                    Correcoes.BlocosMirrorDoDesenho.Executar();

                return "CorrigeTextosDasLigacoes: " + resultado.Apagados
                    + " bloco(s) espelhado(s) apagado(s) — o corpo deste comando no original é o MESMO do"
                    + " ApagaBlocosMirror (não há correção de texto): " + resultado.Espelhados
                    + " espelhado(s) entre " + resultado.ComXData + " com XData; "
                    + resultado.CabosDeAranha + " são cabo de aranha e ficam.";
            }
            catch (System.Exception erro)
            {
                return "CorrigeTextosDasLigacoes: falhou — " + DescreverErro(erro);
            }
        }

        /// <summary>
        /// <c>CorrigePainelET1DosBornes</c> — escreve os atributos do borne (Dispositivo tipo B)
        /// com o painel e a régua do dicionário REGUAS e o nome do painel do cadastro
        /// (o <c>clsUtilitarios.cs</c>).
        /// </summary>
        [CommandMethod("CorrigePainelET1DosBornes")]
        public void CorrigirPainelET1DosBornes()
        {
            Plugin.Escrever(ExecutarCorrigirPainelET1DosBornes());
        }

        /// <summary>Corrige o painel e o T1 dos bornes e devolve a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarCorrigirPainelET1DosBornes()
        {
            try
            {
                Correcoes.PainelDoBorneDoDesenho.Resultado resultado =
                    Correcoes.PainelDoBorneDoDesenho.Executar();

                if (resultado.SemBanco)
                {
                    return "CorrigePainelET1DosBornes: " + Positron.Data.Interface.MensagensDoReverso.BancoNaoConfigurado;
                }

                return "CorrigePainelET1DosBornes: " + resultado.AtributosAlterados
                    + " atributo(s) regravado(s) em " + resultado.ReguasResolvidas + " de "
                    + resultado.BornesLidos + " borne(s) (" + resultado.Reguas + " régua(s) no dicionário).";
            }
            catch (System.Exception erro)
            {
                return "CorrigePainelET1DosBornes: falhou — " + DescreverErro(erro);
            }
        }

        /// <summary>
        /// <c>CorrigeCabos</c> — o <c>CorrigeNothing("Funcao")</c> do original: a <c>Funcao</c>
        /// vazia vira um espaço em <c>Cabos</c> e <c>Cabos4</c>, e o <c>Alarme</c> do cadastro é
        /// zerado sem filtro. É correção **só de banco** (não olha o desenho).
        /// </summary>
        [CommandMethod("CorrigeCabos")]
        public void CorrigirCabos()
        {
            Plugin.Escrever(ExecutarCorrigirCabos());
        }

        /// <summary>Corrige a Funcao vazia e o Alarme no banco. Nunca lança.</summary>
        internal static string ExecutarCorrigirCabos()
        {
            try
            {
                ConfiguracaoPositron config = ConfiguracaoEfetiva.Carregar();
                if (string.IsNullOrEmpty(config.Banco))
                {
                    return "CorrigeCabos: " + Positron.Data.Interface.MensagensDoReverso.BancoNaoConfigurado;
                }

                ProjectStore store = new ProjectStore(config.Banco);
                System.Collections.Generic.IReadOnlyList<int> linhas = store.CorrigirCabosNothing(
                    Positron.Data.Correcoes.CorrecaoDeCabosNothing.ColunaFuncao);

                if (linhas.Count < 3)
                {
                    return "CorrigeCabos: a coluna não está na lista branca — nada foi feito.";
                }

                // O `UPDATE ... SET Alarme = 0` do original **não tem filtro**: o número que o
                // SQLite devolve é de linhas tocadas, não de linhas que mudaram.
                return "CorrigeCabos: " + linhas[0] + " Funcao vazia(s) virou(aram) espaço em Cabos, "
                    + linhas[1] + " em Cabos4 e o Alarme foi tocado em " + linhas[2]
                    + " linha(s) (o UPDATE do Alarme não tem filtro, como no original).";
            }
            catch (System.Exception erro)
            {
                return "CorrigeCabos: falhou — " + DescreverErro(erro);
            }
        }

        /// <summary>
        /// <c>CorrigeHandleSuperior</c> — limpa os handles das derivações (a primeira metade,
        /// o <c>limpaHandleSuperior</c>) e re-resolve cada uma com o <c>verificaConexao</c>
        /// (a conexão vizinha do ponto inicial da polilinha).
        /// </summary>
        [CommandMethod("CorrigeHandleSuperior")]
        public void CorrigirHandleSuperior()
        {
            Plugin.Escrever(ExecutarCorrigirHandleSuperior());
        }

        /// <summary>Limpa e re-resolve as derivações e devolve a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarCorrigirHandleSuperior()
        {
            try
            {
                Correcoes.DerivacoesDoHandleSuperiorDoDesenho.Resultado resultado =
                    Correcoes.DerivacoesDoHandleSuperiorDoDesenho.Executar();

                return "CorrigeHandleSuperior: " + resultado.HandlesLimpos + " handle(s) limpo(s); "
                    + resultado.Resolvidas + " de " + resultado.Derivacoes + " derivação(ões) resolvida(s)"
                    + " e " + resultado.Alteradas + " regravada(s) (" + resultado.Conexoes
                    + " conexão(ões) no desenho; as páginas do original ficam fora do recorte).";
            }
            catch (System.Exception erro)
            {
                return "CorrigeHandleSuperior: falhou — " + DescreverErro(erro);
            }
        }

        /// <summary>
        /// <c>pzDiag</c> — a ferramenta de diagnóstico em C# (substitui os contadores LISP):
        /// escreve um arquivo com a seção das portas (o estado que o Indefine muda) e a das
        /// cores (a diferença entre a referência e a definição). O caminho vem de
        /// POSITRON_DIAG ou, sem ele, de %TEMP%\positron-diag.txt.
        /// </summary>
        [CommandMethod("pzDiag")]
        public void DiagnosticoDoDesenho()
        {
            Plugin.Escrever(ExecutarDiagnostico());
        }

        /// <summary>Escreve o diagnóstico e devolve a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarDiagnostico()
        {
            try
            {
                // A criação da porta sintética entra aqui, e não num comando próprio: o
                // harness executa o `pzDiag` e **não** o `pzDiagCriar` (medido na rodada 104).
                string criar = System.Environment.GetEnvironmentVariable("POSITRON_DIAG_CRIAR");
                string prefixo = string.Empty;
                if (!string.IsNullOrEmpty(criar) && criar != "0")
                {
                    prefixo = Diagnostico.PortaSinteticaDoDesenho.Criar() + " ";
                }

                Diagnostico.DiagnosticoDoDesenho.Resultado resultado =
                    Diagnostico.DiagnosticoDoDesenho.Escrever();

                return prefixo + "pzDiag: " + resultado.Portas + " porta(s), " + resultado.Referencias
                    + " referência(s) de cor e " + resultado.Diferencas + " diferença(s) — escrito em "
                    + resultado.Caminho + ".";
            }
            catch (System.Exception erro)
            {
                return "pzDiag: falhou — " + DescreverErro(erro);
            }
        }

        private static Dictionary<int, ModeloMascara> IndexarPorIndice(List<ModeloMascara> modelos)
        {
            Dictionary<int, ModeloMascara> indice = new Dictionary<int, ModeloMascara>();
            foreach (ModeloMascara modelo in modelos)
            {
                if (modelo != null)
                {
                    indice[modelo.Indice] = modelo;
                }
            }

            return indice;
        }

        private static Dictionary<int, ModeloContato> IndexarPorIndice(List<ModeloContato> modelos)
        {
            Dictionary<int, ModeloContato> indice = new Dictionary<int, ModeloContato>();
            foreach (ModeloContato modelo in modelos)
            {
                if (modelo != null)
                {
                    indice[modelo.Indice] = modelo;
                }
            }

            return indice;
        }

        private static void AcrescentarPainel(List<int> paineis, int painel)
        {
            if (painel > 0 && !paineis.Contains(painel))
            {
                paineis.Add(painel);
            }
        }

        private static int ContarPaineis(IEnumerable<LinhaListaMaterial> linhas)
        {
            List<int> paineis = new List<int>();
            foreach (LinhaListaMaterial linha in linhas)
            {
                if (!paineis.Contains(linha.Painel))
                {
                    paineis.Add(linha.Painel);
                }
            }

            return paineis.Count;
        }

        /// <summary>
        /// Executa a ação de indefinir os cabos fora do catálogo e devolve a linha
        /// de resumo. Nunca lança.
        /// </summary>
        internal static string ExecutarIndefinirCabos()
        {
            ConfiguracaoPositron config = ConfiguracaoEfetiva.Carregar();
            string caminho = config.Banco;
            if (string.IsNullOrEmpty(caminho))
            {
                return "INDCABO: " + Positron.Data.Interface.MensagensDoReverso.BancoNaoConfigurado;
            }

            try
            {
                ProjectStore store = new ProjectStore(caminho);
                List<string> catalogo = new List<string>();
                foreach (CabosRow cabo in store.LerCabos())
                {
                    catalogo.Add(cabo.Tag);
                }

                // Catálogo vazio não é "nenhum cabo existe": é ausência de dado. O
                // original sai cedo aqui (`if (lCabos.Count <= 0) return;`) — sem a
                // guarda a ação apagaria a tag de todo trecho do desenho.
                if (catalogo.Count == 0)
                {
                    return "INDCABO: catálogo de cabos vazio (Cabos) — nada a indefinir; importe o catálogo primeiro.";
                }

                CabosNaoExistentesDoDesenho.Resultado resultado =
                    CabosNaoExistentesDoDesenho.Executar(catalogo);

                return "INDCABO: " + resultado.TrechosIndefinidos + " de " + resultado.TrechosLidos
                    + " trecho(s) de interligação indefinido(s); " + resultado.RotulosIndefinidos
                    + " de " + resultado.RotulosLidos + " rótulo(s) do cabo com o caracter indefinido "
                    + "(catálogo: " + catalogo.Count + " cabo(s)).";
            }
            catch (System.Exception erro)
            {
                return "INDCABO: falhou — " + DescreverErro(erro);
            }
        }

        /// <summary>
        /// Projeta a interligação do desenho e devolve a linha de resumo — usada
        /// tanto pelo <c>INT</c> quanto pelo <c>SYNCD</c>. Nunca lança.
        /// </summary>
        internal static string ExecutarInterligacao(string revisao = null)
        {
            ConfiguracaoPositron config = ConfiguracaoEfetiva.Carregar();
            string caminho = config.Banco;
            if (string.IsNullOrEmpty(caminho))
            {
                return "INT: " + Positron.Data.Interface.MensagensDoReverso.BancoNaoConfigurado;
            }

            try
            {
                IReadOnlyList<PontoInterligacao> pontos = InterligacaoDoDesenho.Ler();
                if (pontos.Count == 0)
                {
                    return "INT: nenhuma LWPOLYLINE com XData INTERLIGACAO no desenho. " + PerfilDoDesenhoDoDesenho.Ler().Explicacao();
                }

                ContextoInterligacao contexto = new ContextoInterligacao
                {
                    Dwg = config.Dwg,
                    Documento = config.Local,
                    Revisao = RevisaoEfetiva(config, revisao),
                    Criador = Environment.UserName,
                    Data = DateTime.Now,
                };

                // Bornes do desenho completam as duas pontas (terminal, régua,
                // tipo). Sem dicionário de réguas os bornes ficam sem nome de
                // régua, mas o terminal ainda casa.
                ReguasModelo reguas = ReguasDoDesenho.Ler();
                IReadOnlyList<PontoBorne> bornes = BornesDoDesenho.Ler(reguas);

                // Pontos de ligação por nome de bloco (bounds ±0,25 + offset).
                TabelaDeslocamentoBlocos deslocamentos = DeslocamentosDoDesenho.Ler();

                // Coluna `Pagina` (Conf.incluirColuna) — a mesma regra do FIA. A
                // ponta guarda a página montada e mantém o layer, que é o usado no
                // casamento com o borne.
                ColunaPagina colunaPagina = LerColunaPagina();
                foreach (PontoInterligacao ponto in pontos)
                {
                    ponto.PaginaProjetada = colunaPagina.Para(ponto.Pagina);
                }

                ProjectStore store = new ProjectStore(caminho);
                InterligacaoProjetor projetor = new InterligacaoProjetor(store);
                int gravados = projetor.Projetar(pontos, contexto, bornes, deslocamentos);

                // Portas e bornes da interligação (wrlU180vl0 / T6NUlT3ghH do
                // frmCompilarInterligacao): todos os modelos de máscara e todos os
                // bornes do desenho + reservas, sem o filtro de painel em uso que
                // o FIA aplica.
                int portas4I = GerarPortas4I(store, contexto);
                int bornes4I = GerarBornes4I(store, contexto, reguas, bornes, colunaPagina);

                // Snapshot do catálogo por revisão (RUIU5Sbjhj/v1TU0cEjWd do
                // original): Cabos4/Veias4 são o catálogo carimbado com a revisão.
                int cabos = RegravarCabos4(store, contexto);
                int veias = RegravarVeias4(store, contexto);

                return "INT: " + gravados + " linha(s) gravada(s) em Interligacao4 ("
                    + bornes.Count + " borne(s)); " + portas4I + " porta(s) em Portas4I; "
                    + bornes4I + " borne(s) em Bornes4I; " + cabos + " cabo(s) em Cabos4; "
                    + veias + " veia(s) em Veias4.";
            }
            catch (System.Exception erro)
            {
                return "INT: falhou — " + DescreverErro(erro);
            }
        }

        /// <summary>
        /// <c>SYNCD</c> — o **pipeline** do original num comando só. No reverso o <c>SYNCD</c> não é
        /// uma projeção simples: ele roda seis passos (a barra de progresso com
        /// <c>Quantidade = 6</c>) — <c>ApagaContatosOrfaos</c>, <c>CorrigeModelosDeContatos</c>,
        /// <c>SincronizaContatos</c>, <c>SincronizaPortas</c>, <c>SincronizaDePara</c>,
        /// <c>EditaPortaDipAuxPainelModeloFabricante</c> — e termina com o
        /// <c>CorrigeCoresDosBlocos</c>.
        ///
        /// Aqui entram, na ordem do original, os passos que o recoder **tem**:
        ///
        /// 1. <c>CorrigeModelosDeContatos</c> (as duas metades: o dicionário e o desenho);
        /// 2. e 3. a **projeção** para o banco (<c>FIA</c> + <c>INT</c>), que é o que no original
        ///    fazem os três <c>Sincroniza*</c>;
        /// 4. <c>CorrigeCoresDosBlocos</c>, como o original fecha.
        ///
        /// **Fora do recorte, documentado:** o <c>ApagaContatosOrfaos</c> e o
        /// <c>EditaPortaDipAuxPainelModeloFabricante</c> (a família de sincronização de
        /// tabelas/UI que o recoder não porta) e a barra de progresso.
        /// </summary>
        [CommandMethod("SYNCD")]
        public void SincD()
        {
            // A **barra compartilhada** do original (`Comandos.cs:288-303`): `Quantidade = 6`, o
            // `pbIniciar`, um `pbPasso` **depois de cada** rotina e o `pbFim` no fim. Aqui a
            // quantidade é a dos passos que o recoder roda (os seus quatro `[n/4]`) — o desvio do
            // pipeline, que funde as três `Sincroniza*` na projeção `FIA`/`INT`, é o mesmo já
            // documentado desde a rodada 107.
            Interface.Folhas.PaletaDeFolhas.ProgressoQuantidade(4);
            Interface.Folhas.PaletaDeFolhas.ProgressoIniciar();
            Plugin.Escrever("[1/4] " + ExecutarCorrigirModelosDeContatos());
            Interface.Folhas.PaletaDeFolhas.ProgressoPasso();
            Plugin.Escrever("[2/4] " + ExecutarFiacao());
            Interface.Folhas.PaletaDeFolhas.ProgressoPasso();
            Plugin.Escrever("[3/4] " + ExecutarInterligacao());
            Interface.Folhas.PaletaDeFolhas.ProgressoPasso();
            Plugin.Escrever("[4/4] " + ExecutarCorrigirCoresDosBlocos());
            Interface.Folhas.PaletaDeFolhas.ProgressoPasso();
            Interface.Folhas.PaletaDeFolhas.ProgressoFim();
        }

        /// <summary>
        /// <c>VERIF</c> — valida as tabelas derivadas gravadas (ver
        /// <see cref="VerificadorProjeto"/>): fiação, interligação e modelos.
        /// Read-only: lê a revisão de <c>POSITRON_DWG</c>/<c>POSITRON_REVISAO</c> e
        /// resume os problemas por área.
        /// </summary>
        [CommandMethod("VERIF")]
        public void Verif()
        {
            ConfiguracaoPositron config = ConfiguracaoEfetiva.Carregar();
            string caminho = config.Banco;
            if (string.IsNullOrEmpty(caminho))
            {
                Plugin.Escrever("VERIF: " + Positron.Data.Interface.MensagensDoReverso.BancoNaoConfigurado);
                return;
            }

            try
            {
                int fios;
                int trechos;
                int portas;
                int bornes;
                int contatos;
                List<Problema> problemas = VerificarRevisao(
                    caminho, config.Dwg, config.Revisao, out fios, out trechos, out portas, out bornes, out contatos);

                int porFiacao = 0;
                int porInterligacao = 0;
                int porModelos = 0;
                int porDesenho = 0;
                foreach (Problema problema in problemas)
                {
                    switch (problema.Area)
                    {
                        case AreaVerificacao.Fiacao:
                            porFiacao++;
                            break;
                        case AreaVerificacao.Interligacao:
                            porInterligacao++;
                            break;
                        case AreaVerificacao.Modelos:
                            porModelos++;
                            break;
                        case AreaVerificacao.Desenho:
                            porDesenho++;
                            break;
                    }
                }

                Plugin.Escrever("VERIF: " + fios + " fio(s), " + trechos + " trecho(s), "
                    + portas + " porta(s), " + bornes + " borne(s), " + contatos
                    + " contato(s) na revisão.");
                // Composição por TIPO: sem isso, "548 problemas de modelos" não diz
                // se é regra estrita demais ou dado ruim. Só os tipos que aparecem.
                System.Collections.Generic.Dictionary<TipoProblema, int> porTipo =
                    new System.Collections.Generic.Dictionary<TipoProblema, int>();
                foreach (Problema problema in problemas)
                {
                    int quantos;
                    porTipo.TryGetValue(problema.Tipo, out quantos);
                    porTipo[problema.Tipo] = quantos + 1;
                }

                List<System.Collections.Generic.KeyValuePair<TipoProblema, int>> ranking =
                    new List<System.Collections.Generic.KeyValuePair<TipoProblema, int>>(porTipo);
                ranking.Sort((a, b) => b.Value.CompareTo(a.Value));

                System.Text.StringBuilder tipos = new System.Text.StringBuilder();
                for (int i = 0; i < ranking.Count && i < 6; i++)
                {
                    if (i > 0)
                    {
                        tipos.Append("; ");
                    }

                    tipos.Append(ranking[i].Key).Append(": ").Append(ranking[i].Value);
                }

                Plugin.Escrever("VERIF: " + problemas.Count + " problema(s) — fiação: " + porFiacao
                    + "; interligação: " + porInterligacao + "; modelos: " + porModelos
                    + "; desenho: " + porDesenho + ".");
                Plugin.Escrever("VERIF: por tipo — " + tipos + ".");
            }
            catch (System.Exception erro)
            {
                Plugin.Escrever("VERIF: falhou — " + DescreverErro(erro));
            }
        }

        /// <summary>
        /// <c>ELETREL</c> — grava o **relatório da verificação** em arquivo: é a grid
        /// de erros das telas <c>frmCompilar*</c> do original, sem tela. Serve para
        /// rodar por script (o harness lê o arquivo) e para anexar ao projeto.
        ///
        /// O caminho vem da configuração: chave <c>relatorio</c> (variável
        /// <c>POSITRON_RELATORIO</c>); sem ela, grava ao lado do banco, como
        /// <c>positron-relatorio.txt</c>.
        /// </summary>
        [CommandMethod("ELETREL")]
        public void EletRel()
        {
            ConfiguracaoPositron config = ConfiguracaoEfetiva.Carregar();
            string caminho = config.Banco;
            if (string.IsNullOrEmpty(caminho))
            {
                Plugin.Escrever("ELETREL: " + Positron.Data.Interface.MensagensDoReverso.BancoNaoConfigurado);
                return;
            }

            try
            {
                RelatorioCompilacao relatorio = MontarRelatorio(config);
                string destino = CaminhoDoRelatorio(config);

                relatorio.Salvar(destino);

                Plugin.Escrever("ELETREL: " + relatorio.Linhas.Count + " problema(s) em " + destino + ".");
                Plugin.Escrever("ELETREL: " + relatorio.Resumo);
            }
            catch (System.Exception erro)
            {
                Plugin.Escrever("ELETREL: falhou — " + DescreverErro(erro));
            }
        }

        /// <summary>Monta o relatório da revisão (o conteúdo que a tela e o arquivo mostram).</summary>
        private static RelatorioCompilacao MontarRelatorio(ConfiguracaoPositron config)
        {
            int fios;
            int trechos;
            int portas;
            int bornes;
            int contatos;
            List<Problema> problemas = VerificarRevisao(
                config.Banco, config.Dwg, config.Revisao, out fios, out trechos, out portas, out bornes, out contatos);

            string resumo = "VERIF: " + fios + " fio(s), " + trechos + " trecho(s), "
                + portas + " porta(s), " + bornes + " borne(s), " + contatos + " contato(s) na revisão.";

            RelatorioCompilacao relatorio = RelatorioCompilacao.DeProblemas(
                "Verificação do projeto (" + (config.Revisao ?? "sem revisão") + ", DWG " + config.Dwg + ")",
                resumo,
                problemas);

            relatorio.Contagens.Add("# banco=" + config.Banco);
            relatorio.Contagens.Add("# problemas=" + problemas.Count);
            return relatorio;
        }

        /// <summary>Caminho do relatório: o da configuração ou, sem ela, ao lado do banco.</summary>
        private static string CaminhoDoRelatorio(ConfiguracaoPositron config)
        {
            if (!string.IsNullOrWhiteSpace(config.Relatorio))
            {
                return config.Relatorio;
            }

            string pasta = System.IO.Path.GetDirectoryName(config.Banco);
            return System.IO.Path.Combine(
                string.IsNullOrEmpty(pasta) ? "." : pasta,
                "positron-relatorio.txt");
        }

        /// <summary>
        /// Monta os problemas da revisão: as regras de tabela (<see cref="VerificadorProjeto"/>)
        /// mais as que leem o desenho (régua do borne, órfãos, fiação duplicada, página
        /// ausente). Devolve também as contagens que o resumo imprime. Compartilhado por
        /// <c>VERIF</c> (imprime) e <c>ELETREL</c> (grava em arquivo).
        /// </summary>
        internal static List<Problema> VerificarRevisao(
            string caminho, int dwg, string revisao,
            out int fios, out int trechos, out int portas, out int bornes, out int contatos)
        {
            ProjectStore store = new ProjectStore(caminho);

            IReadOnlyList<FiacaoRow> fiacao = store.FiacaoDaRevisao(dwg, revisao);
            IReadOnlyList<Interligacao4Row> interligacao = store.InterligacaoDaRevisao(dwg, revisao);
            IReadOnlyList<Portas4FRow> linhasPortas = store.PortasDaRevisao(dwg, revisao);
            IReadOnlyList<Bornes4FRow> linhasBornes = store.BornesDaRevisao(dwg, revisao);
            IReadOnlyList<Contatos4FRow> linhasContatos = store.ContatosDaRevisao(dwg, revisao);

            fios = fiacao.Count;
            trechos = interligacao.Count;
            portas = linhasPortas.Count;
            bornes = linhasBornes.Count;
            contatos = linhasContatos.Count;

            List<Problema> problemas = VerificadorProjeto.Verificar(
                fiacao, interligacao, linhasPortas, linhasBornes, linhasContatos);

            // O verifier original também lê o DESENHO: a régua de cada borne e
            // o cabo referenciado que não existe no catálogo.
            ReguasModelo reguas = ReguasDoDesenho.Ler();
            IReadOnlyList<PontoBorne> bornesDoDesenho = BornesDoDesenho.Ler(reguas);
            problemas.AddRange(VerificadorProjeto.VerificarBornesSemRegua(bornesDoDesenho, reguas));

            // Réguas do dicionário que ficaram sem borne no caderno (o
            // `buscaReguasVazias` da tela de verificação).
            problemas.AddRange(VerificadorProjeto.VerificarReguasVazias(reguas, bornesDoDesenho));

            // Bornes sem LM (`lm == 0`) — a árvore `TreeViewBornesLM` do original.
            problemas.AddRange(VerificadorProjeto.VerificarBornesSemLm(bornesDoDesenho));

            // Bornes editados (`bt9Discrepantes`, `QU5c0lgjBd`): o atributo `T1`
            // (número visível no bloco) que contradiz o número da régua/XData.
            problemas.AddRange(VerificadorProjeto.VerificarBornesEditados(bornesDoDesenho));

            // Conexões órfãs — o botão `bt2Orfao` da tela (`carregaOrfao`).
            IReadOnlyList<ConexaoFiacao> conexoes = ConexoesDoDesenho.Ler();
            problemas.AddRange(VerificadorProjeto.VerificarOrfaos(conexoes));

            // Painéis do desenho que não existem no cadastro do projeto
            // (`lPnAoagado`): o original olha os blocos `P` e `E` (`buscaPaineisDoDG`).
            List<int> paineisDoDesenho = new List<int>();
            foreach (int painel in MascarasDoDesenho.Ler().Paineis)
            {
                paineisDoDesenho.Add(painel);
            }

            foreach (int painel in DispositivosDoDesenho.Ler().Paineis)
            {
                paineisDoDesenho.Add(painel);
            }

            foreach (ConexaoFiacao conexao in conexoes)
            {
                paineisDoDesenho.Add(conexao.Painel);
            }

            HashSet<int> cadastroDePaineis = new HashSet<int>(store.LerIndicesDePaineis());
            problemas.AddRange(VerificadorProjeto.VerificarPaineisSemCadastro(
                paineisDoDesenho, cadastroDePaineis));

            // O `lPnApagados` da tela de verificação: painel referenciado no desenho
            // que não existe no cadastro do projeto (o dicionário devolveria "???").
            // É o insumo do `bPnApagado` das checagens do `carregaTree` da
            // interligação (o mesmo conjunto que `VerificarPaineisSemCadastro` aponta,
            // sem o painel 0, que é "não definido" e não um cadastro ausente).
            HashSet<int> paineisApagados = new HashSet<int>();
            foreach (int painel in paineisDoDesenho)
            {
                if (painel > 0 && !cadastroDePaineis.Contains(painel))
                {
                    paineisApagados.Add(painel);
                }
            }

            // O `carregaTree` do verificador da interligação: jumper sem cabo/seção ou
            // em painel apagado (nó "External Jumper"), jumper de duas pontas repetindo
            // potencial ("Duplicates") e trecho sem Tag_Cabo ou em painel apagado
            // ("Interconnection"). Os trechos são lidos **com** os de veia indefinida
            // (`Num_Veia == -1000`), como o `buscaDadosDoDWG` do original — a projeção
            // os descarta, o verificador não.
            IReadOnlyList<PontoInterligacao> trechosDoDesenho =
                InterligacaoDoDesenho.Ler(incluirVeiaIndefinida: true);
            int quantosJumpers = 0;
            foreach (ConexaoFiacao conexao in conexoes)
            {
                if (string.Equals((conexao.Jumper ?? string.Empty).Trim(), "JUMPER", StringComparison.OrdinalIgnoreCase))
                {
                    quantosJumpers++;
                }
            }

            Plugin.Escrever("VERIF: " + quantosJumpers + " jumper(s) e " + trechosDoDesenho.Count
                + " trecho(s) de interligação lido(s) do desenho.");
            problemas.AddRange(VerificadorProjeto.VerificarJumpersIndefinidos(conexoes, paineisApagados));
            problemas.AddRange(VerificadorProjeto.VerificarJumpersDuplicados(conexoes));
            problemas.AddRange(VerificadorProjeto.VerificarTrechosInterligacaoIndefinidos(
                trechosDoDesenho, paineisApagados));

            // Régua da máscara (`bt13ReguaMascara`, `AC1cAJLSDI`): porta de um modelo
            // cujo campo Régua traz separador que não fecha com a contagem de bornes.
            // Sai do dicionário de máscaras do desenho (MASCARAS), não das tabelas.
            List<ModeloMascara> modelosDeMascara = ModelosMascaraDoDesenho.LerModelos();
            Dictionary<int, IReadOnlyList<ModeloPorta>> portasDeMascara =
                new Dictionary<int, IReadOnlyList<ModeloPorta>>();
            foreach (ModeloMascara modelo in modelosDeMascara)
            {
                portasDeMascara[modelo.Indice] = ModelosMascaraDoDesenho.LerPortas(modelo.Indice, modelo.Nome);
            }

            problemas.AddRange(VerificadorProjeto.VerificarReguasMascara(modelosDeMascara, portasDeMascara));

            // Portas discrepantes (`bt14PortasDiscrepantes`): cruza os blocos `E` do
            // desenho com a definição do modelo (os mesmos modelos de máscara acima).
            List<ModeloPorta> portasDoModelo = new List<ModeloPorta>();
            foreach (IReadOnlyList<ModeloPorta> listaDePortas in portasDeMascara.Values)
            {
                portasDoModelo.AddRange(listaDePortas);
            }

            IReadOnlyList<PortaNoDesenho> portasDeBloco = PortasDoDesenho.Ler();
            Plugin.Escrever("VERIF: " + portasDeBloco.Count + " bloco(s) de porta (E) lido(s) do desenho.");
            problemas.AddRange(VerificadorProjeto.VerificarPortasDiscrepantes(portasDoModelo, portasDeBloco));

            // Terminais (`bt5Terminais`, a grade dgTerminais) e bornes
            // (`bt6Portas`, a dgBornes) dos blocos de porta: os atributos T*/B*/R*
            // do próprio bloco, com a chave de repetição por máscara. O prefixo da
            // máscara é o nome do painel no cadastro (`Paineis`) — o
            // `Dicionario.BuscaNomeDoPainel` do original.
            IReadOnlyDictionary<int, string> nomesDePaineis = store.LerNomesDePaineis();
            problemas.AddRange(VerificadorProjeto.VerificarTerminaisDasPortas(
                portasDeBloco, portasDoModelo, nomesDePaineis));
            problemas.AddRange(VerificadorProjeto.VerificarBornesDasPortas(
                portasDeBloco, portasDoModelo, nomesDePaineis));

            // Dispositivos principais incompletos (`bt3Principal`) e auxiliares
            // divergentes (`bt4Auxiliar`): cruzam os blocos `P`/`A` do desenho com o
            // dicionário de contatos (o `CONTATOS`). O mesmo leitor da fiação já
            // traz os dois tipos, com os terminais do bloco.
            List<DispositivoFiacao> dispositivosPrincipais = new List<DispositivoFiacao>();
            List<DispositivoFiacao> dispositivosAuxiliares = new List<DispositivoFiacao>();
            foreach (DispositivoFiacao dispositivo in DispositivosDeFiacaoDoDesenho.Ler())
            {
                if (string.Equals(dispositivo.Tipo, DispositivoFiacaoXData.TipoDispositivo, StringComparison.Ordinal))
                {
                    dispositivosPrincipais.Add(dispositivo);
                }
                else if (string.Equals(dispositivo.Tipo, DispositivoFiacaoXData.TipoAuxiliar, StringComparison.Ordinal))
                {
                    dispositivosAuxiliares.Add(dispositivo);
                }
            }

            Plugin.Escrever("VERIF: " + dispositivosPrincipais.Count + " dispositivo(s) principal(is) (P) e "
                + dispositivosAuxiliares.Count + " auxiliar(es) (A) lido(s) do desenho.");

            problemas.AddRange(VerificadorProjeto.VerificarDispositivosPrincipais(dispositivosPrincipais));

            Dictionary<int, IReadOnlyList<ContatoAuxiliar>> contatosPorModelo =
                new Dictionary<int, IReadOnlyList<ContatoAuxiliar>>();
            foreach (ModeloContato modelo in ContatosDoDesenho.LerModelos())
            {
                contatosPorModelo[modelo.Indice] = ContatosDoDesenho.LerAuxiliares(modelo.Indice);
            }

            problemas.AddRange(VerificadorProjeto.VerificarAuxiliaresDivergentes(
                dispositivosAuxiliares, dispositivosPrincipais, contatosPorModelo));

            // Blocos duplicados (`bt12AMao`, "Copy made by hand"): a varredura de
            // `clsBlocos.VerificaDuplicados` — dois blocos do mesmo item, por tipo.
            IReadOnlyList<BlocoDuplicavel> blocosDuplicaveis = BlocosDuplicaveisDoDesenho.Ler(reguas);
            Plugin.Escrever("VERIF: " + blocosDuplicaveis.Count + " bloco(s) lido(s) para a checagem de duplicados.");
            problemas.AddRange(VerificadorProjeto.VerificarBlocosDuplicados(blocosDuplicaveis, paineisDoDesenho));

            // Intervalos de borne por régua — o `bt8intervalos` da tela (`TreeViewBornes`).
            // As reservas de cada régua entram na sequência de números (o
            // `LeDicBornesReserva`); só as réguas **em uso** são lidas, como no original.
            Dictionary<int, IReadOnlyList<BorneReserva>> reservasPorRegua =
                new Dictionary<int, IReadOnlyList<BorneReserva>>();
            foreach (ReguaInfo regua in reguas.Ordenadas)
            {
                if (regua != null && paineisDoDesenho.Contains(regua.Painel))
                {
                    reservasPorRegua[regua.Indice] = BornesReservaDoDesenho.Ler(regua.Indice);
                }
            }

            problemas.AddRange(VerificadorProjeto.VerificarIntervalosBornes(
                reguas, bornesDoDesenho, paineisDoDesenho, reservasPorRegua));

            List<string> handlesDoDesenho = new List<string>();
            foreach (PontoBorne borne in bornesDoDesenho)
            {
                handlesDoDesenho.Add(borne.Handle);
            }

            List<string> handlesNaFiacao = new List<string>();
            foreach (FiacaoRow fio in fiacao)
            {
                handlesNaFiacao.Add(fio.Handle);
            }

            problemas.AddRange(VerificadorProjeto.VerificarBornesSemFiacao(handlesDoDesenho, handlesNaFiacao));

            // Fiação desenhada em duplicidade: dois trechos Tipo 2 com as mesmas
            // pontas na mesma página (o `LFiacaoTTDuplicada` do original).
            problemas.AddRange(VerificadorProjeto.VerificarFiacaoDuplicada(TrechosDoDesenho.Ler()));

            List<string> cabosUsados = new List<string>();
            foreach (Interligacao4Row trecho in interligacao)
            {
                cabosUsados.Add(trecho.Tag_Cabo);
            }

            List<string> catalogo = new List<string>();
            foreach (CabosRow cabo in store.LerCabos())
            {
                catalogo.Add(cabo.Tag);
            }

            problemas.AddRange(VerificadorProjeto.VerificarCabosSemCatalogo(cabosUsados, catalogo));

            List<string> paginasGravadas = new List<string>();
            foreach (FiacaoRow fio in fiacao)
            {
                paginasGravadas.Add(fio.Pagina);
            }

            foreach (Bornes4FRow borne in linhasBornes)
            {
                // A reserva não tem página de desenho: o original grava o rótulo
                // "RESERVA" (mensagem 1050) na coluna. Comparar esse rótulo com a
                // `LayerTable` acusaria página ausente em toda revisão — a linha de base
                // do VERIF pegou exatamente isso (rodada 40).
                if (borne.bReserva)
                {
                    continue;
                }

                paginasGravadas.Add(borne.Pagina);
            }

            foreach (Interligacao4Row trecho in interligacao)
            {
                paginasGravadas.Add(trecho.Pagina1);
                paginasGravadas.Add(trecho.Pagina2);
            }

            foreach (Dispositivos4FRow dispositivo in store.DispositivosDaRevisao(dwg, revisao))
            {
                paginasGravadas.Add(dispositivo.Pagina);
            }

            problemas.AddRange(VerificadorProjeto.VerificarPaginasAusentes(paginasGravadas, PaginasDoDesenho.Ler()));
            return problemas;
        }

        /// <summary>Gera <c>Portas4F</c> a partir dos modelos de máscara do desenho.</summary>
        private static int GerarPortas(ProjectStore store, ContextoProjecao contexto, ICollection<int> modelosEmUso)
        {
            List<ModeloMascara> modelos = ModelosMascaraDoDesenho.LerModelos();
            Dictionary<int, IReadOnlyList<ModeloPorta>> portasPorModelo = new Dictionary<int, IReadOnlyList<ModeloPorta>>();
            foreach (ModeloMascara modelo in modelos)
            {
                portasPorModelo[modelo.Indice] = ModelosMascaraDoDesenho.LerPortas(modelo.Indice, modelo.Nome);
            }

            List<Porta4F> linhas = Portas4FGerador.Gerar(modelos, portasPorModelo, modelosEmUso);
            store.InserirPortas(linhas, contexto.Revisao, contexto.Dwg);
            return linhas.Count;
        }

        /// <summary>Gera <c>Bornes4F</c> (bornes do desenho + reservas das réguas).</summary>
        private static int GerarBornes(
            ProjectStore store,
            ContextoProjecao contexto,
            ReguasModelo reguas,
            IReadOnlyList<PontoBorne> bornes,
            ICollection<int> paineisEmUso,
            ColunaPagina colunaPagina)
        {
            Dictionary<int, IReadOnlyList<BorneReserva>> reservasPorRegua =
                new Dictionary<int, IReadOnlyList<BorneReserva>>();
            foreach (ReguaInfo regua in reguas.Ordenadas)
            {
                reservasPorRegua[regua.Indice] = BornesReservaDoDesenho.Ler(regua.Indice);
            }

            List<Borne4F> linhas = Bornes4FGerador.Gerar(bornes, reguas, paineisEmUso, reservasPorRegua);
            foreach (Borne4F linha in linhas)
            {
                // Reserva entra com Pagina vazia: `Para("")` devolve vazio.
                linha.Pagina = colunaPagina.Para(linha.Pagina);
            }

            store.InserirBornes(linhas, contexto.Revisao, contexto.Dwg);
            return linhas.Count;
        }

        /// <summary>Gera <c>Contatos4F</c> a partir dos modelos de contato do desenho.</summary>
        private static int GerarContatos(ProjectStore store, ContextoProjecao contexto, DispositivosDoDesenho.Dispositivos dispositivos)
        {
            List<ModeloContato> modelos = ContatosDoDesenho.LerModelos();
            Dictionary<int, IReadOnlyList<ContatoAuxiliar>> auxiliaresPorModelo =
                new Dictionary<int, IReadOnlyList<ContatoAuxiliar>>();
            foreach (ModeloContato modelo in modelos)
            {
                auxiliaresPorModelo[modelo.Indice] = ContatosDoDesenho.LerAuxiliares(modelo.Indice);
            }

            List<Contato4F> linhas = Contatos4FGerador.Gerar(
                modelos,
                dispositivos.Modelos,
                auxiliaresPorModelo,
                dispositivos.TerminaisBobinas);
            store.InserirContatos(linhas, contexto.Revisao, contexto.Dwg);
            return linhas.Count;
        }

        /// <summary>
        /// Gera <c>Aplicacao4F</c> a partir do dicionário <c>APLICACAO</c> do
        /// desenho (o <c>FiRUTW6Q6W</c> do original: copia todos os tipos, sem
        /// filtro). Ver <see cref="Aplicacao4FGerador"/>.
        /// </summary>
        private static int GerarAplicacoes(ProjectStore store, ContextoProjecao contexto)
        {
            List<Aplicacao4F> linhas = Aplicacao4FGerador.Gerar(AplicacoesDoDesenho.Ler());
            store.InserirAplicacoes(linhas, contexto.Revisao, contexto.Dwg);
            return linhas.Count;
        }

        /// <summary>
        /// Gera <c>Circuitos4F</c> a partir das conexões (<c>CONEXAO</c>) — o
        /// <c>t6yXrlfi5w</c> do original: painel em uso, <c>Tipo == 1</c>, nome
        /// não-vazio e dedup por <c>Potencial</c>. Ver <see cref="Circuitos4FGerador"/>.
        ///
        /// Recebe as **conexões do desenho** (não os pontos): uma `Tipo 1` sem
        /// `Disp1`/`Disp2` não vira ponto de fiação, mas vira circuito.
        /// </summary>
        private static int GerarCircuitos(
            ProjectStore store,
            ContextoProjecao contexto,
            ICollection<int> paineis)
        {
            // As conexões são lidas **aqui**, e não vêm dos pontos: o original
            // (`t6yXrlfi5w`) varre as polylines do desenho, e uma `Tipo 1` sem
            // `Disp1`/`Disp2` não gera ponto de fiação mas gera circuito. Medido
            // contra o banco do produto: 11 circuitos no desenho real, contra 7
            // quando o gerador era alimentado pelos pontos.
            IReadOnlyList<ConexaoFiacao> conexoes = ConexoesDoDesenho.Ler();

            List<int> paineisEfetivos = new List<int>(paineis ?? new List<int>());
            foreach (ConexaoFiacao conexao in conexoes)
            {
                if (!paineisEfetivos.Contains(conexao.Painel))
                {
                    paineisEfetivos.Add(conexao.Painel);
                }
            }

            List<Circuito4F> linhas = Circuitos4FGerador.Gerar(conexoes, paineisEfetivos);
            store.InserirCircuitos(linhas, contexto.Revisao, contexto.Dwg);
            return linhas.Count;
        }

        /// <summary>
        /// Gera <c>Dispositivos4F</c> a partir dos blocos <c>P</c>/<c>M</c> do
        /// desenho (ver <see cref="Dispositivos4FGerador"/>). Os modelos que dão
        /// <c>BlocoTopografico</c>/<c>BlocoLayout</c> vêm dos mesmos dicionários
        /// já lidos pelo <c>FIA</c>: contatos (para o <c>P</c>) e máscaras (para o
        /// <c>M</c>).
        /// </summary>
        private static int GerarDispositivos(
            ProjectStore store,
            ContextoProjecao contexto,
            ICollection<int> paineis,
            IReadOnlyList<DispositivoFiacao> blocos,
            LayoutPosicoes posicoes,
            ColunaPagina colunaPagina)
        {
            Dictionary<int, BlocoDoModelo> modeloDeDispositivo = new Dictionary<int, BlocoDoModelo>();
            foreach (ModeloContato modelo in ContatosDoDesenho.LerModelos())
            {
                modeloDeDispositivo[modelo.Indice] = new BlocoDoModelo
                {
                    BlocoTopografico = modelo.BlocoTopografico,
                    BlocoLayout = modelo.BlocoLayout,
                };
            }

            Dictionary<int, BlocoDoModelo> modeloDeMascara = new Dictionary<int, BlocoDoModelo>();
            foreach (ModeloMascara modelo in ModelosMascaraDoDesenho.LerModelos())
            {
                modeloDeMascara[modelo.Indice] = new BlocoDoModelo
                {
                    BlocoTopografico = modelo.BlocoTopografico,
                    BlocoLayout = modelo.BlocoLayout,
                };
            }

            List<Dispositivo4F> linhas = Dispositivos4FGerador.Gerar(
                blocos, paineis, modeloDeDispositivo, modeloDeMascara, posicoes);
            foreach (Dispositivo4F linha in linhas)
            {
                linha.Pagina = colunaPagina.Para(linha.Pagina);
            }

            store.InserirDispositivos(linhas, contexto.Revisao, contexto.Dwg);
            return linhas.Count;
        }

        /// <summary>
        /// Gera <c>Portas4I</c> — o <c>wrlU180vl0</c> do <c>frmCompilarInterligacao</c>:
        /// todas as portas dos modelos de máscara do dicionário, sem o filtro de
        /// "em uso". Ver <see cref="Portas4IGerador"/>.
        /// </summary>
        private static int GerarPortas4I(ProjectStore store, ContextoInterligacao contexto)
        {
            List<ModeloMascara> modelos = ModelosMascaraDoDesenho.LerModelos();
            Dictionary<int, IReadOnlyList<ModeloPorta>> portasPorModelo =
                new Dictionary<int, IReadOnlyList<ModeloPorta>>();
            foreach (ModeloMascara modelo in modelos)
            {
                portasPorModelo[modelo.Indice] = ModelosMascaraDoDesenho.LerPortas(modelo.Indice, modelo.Nome);
            }

            List<Porta4I> linhas = Portas4IGerador.Gerar(modelos, portasPorModelo);
            store.InserirPortas4I(linhas, contexto.Revisao, contexto.Dwg);
            return linhas.Count;
        }

        /// <summary>
        /// Gera <c>Bornes4I</c> — o <c>T6NUlT3ghH</c> do
        /// <c>frmCompilarInterligacao</c>: bornes do desenho + reservas das réguas,
        /// sem o filtro de painel em uso. Ver <see cref="Bornes4IGerador"/>.
        /// </summary>
        private static int GerarBornes4I(
            ProjectStore store,
            ContextoInterligacao contexto,
            ReguasModelo reguas,
            IReadOnlyList<PontoBorne> bornes,
            ColunaPagina colunaPagina)
        {
            Dictionary<int, IReadOnlyList<BorneReserva>> reservasPorRegua =
                new Dictionary<int, IReadOnlyList<BorneReserva>>();
            foreach (ReguaInfo regua in reguas.Ordenadas)
            {
                reservasPorRegua[regua.Indice] = BornesReservaDoDesenho.Ler(regua.Indice);
            }

            List<Borne4I> linhas = Bornes4IGerador.Gerar(bornes, reguas, reservasPorRegua);
            foreach (Borne4I linha in linhas)
            {
                linha.Pagina = colunaPagina.Para(linha.Pagina);
            }

            store.InserirBornes4I(linhas, contexto.Revisao, contexto.Dwg);
            return linhas.Count;
        }

        /// <summary>Regrava <c>Cabos4</c> como snapshot do catálogo da revisão.</summary>
        private static int RegravarCabos4(ProjectStore store, ContextoInterligacao contexto)
        {
            List<Cabos4Row> linhas = CabosVeias4Gerador.GerarCabos(
                store.LerCabos(), contexto.Revisao, contexto.Criador, contexto.Data);
            store.RegravarCabos4(contexto.Revisao, linhas);
            return linhas.Count;
        }

        /// <summary>Regrava <c>Veias4</c> como snapshot do catálogo da revisão.</summary>
        private static int RegravarVeias4(ProjectStore store, ContextoInterligacao contexto)
        {
            List<Veias4Row> linhas = CabosVeias4Gerador.GerarVeias(store.LerVeias(), contexto.Revisao);
            store.RegravarVeias4(contexto.Revisao, linhas);
            return linhas.Count;
        }

        /// <summary>
        /// Como a coluna `Pagina` é montada: `Conf.incluirColuna` (0..6) e o
        /// `SeparadorCruzamento`, que vêm da configuração — arquivo do usuário
        /// (`%APPDATA%\Positron\positron.ini`, gravado pela tela de configuração) ou
        /// variável de ambiente, que tem prioridade. Sem configuração, o
        /// comportamento é o caso 0..2 (layer cru). Ver `ColunaPagina`.
        /// </summary>
        private static ColunaPagina LerColunaPagina()
        {
            ConfiguracaoPositron config = ConfiguracaoEfetiva.Carregar();
            return new ColunaPagina(
                PaginasDoDesenho.Ler(),
                config.IncluirColuna,
                config.SeparadorCruzamento);
        }

        /// <summary>
        /// Descreve a falha para o log: mensagem + tipo + primeiro quadro do stack.
        /// Sem isso um erro de dado (formato, conversao) vira so "falhou" e nao da
        /// para saber qual leitor estourou dentro do CAD.
        /// </summary>
        private static string DescreverErro(System.Exception erro)
        {
            string pilha = erro.StackTrace;
            if (string.IsNullOrEmpty(pilha))
            {
                return erro.GetType().Name + ": " + erro.Message;
            }

            // Ajuda a achar qual leitor estourou: as falhas de dado (formato) sao
            // FormatException com uma pilha longa, e o primeiro quadro e sempre o
            // proprio Number.StringToNumber.
            string[] quadros = pilha.Split(new[] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            System.Text.StringBuilder texto = new System.Text.StringBuilder();
            texto.Append(erro.GetType().Name).Append(": ").Append(erro.Message);
            for (int i = 0; i < quadros.Length && i < 4; i++)
            {
                texto.Append(" | ").Append(quadros[i].Trim());
            }

            return texto.ToString();
        }

        /// <summary>
        /// <c>pzDiagCriar</c> — monta no desenho a **porta sintética** (bloco com os quatro
        /// ATTDEFs, a inserção com os valores antigos, o XData tipo E no modelo 9/porta 5 e o
        /// MASCARAS só com a porta 3) para o <c>IndefineUmaPorta</c> ter o que indefinir.
        ///
        /// **Medido na rodada 104:** o harness executa o <c>pzDiag</c> mas **não** este comando —
        /// por isso a criação também entra pelo <c>pzDiag</c> quando <c>POSITRON_DIAG_CRIAR</c> está
        /// ligada (e é idempotente). Aqui ele fica registrado para uso interativo.
        /// </summary>
        [CommandMethod("pzDiagCriar")]
        public void CriarPortaSintetica()
        {
            Plugin.Escrever(ExecutarCriarPortaSintetica());
        }

        /// <summary>Cria a porta sintética e devolve a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarCriarPortaSintetica()
        {
            try
            {
                return Diagnostico.PortaSinteticaDoDesenho.Criar();
            }
            catch (System.Exception erro)
            {
                return "pzDiagCriar: falhou — " + DescreverErro(erro);
            }
        }

        /// <summary>
        /// <c>STATBORN</c> — a estatística de bornes em **lote** (o que no original é a grade do
        /// <c>frmEstatisticaDeBornes</c>): conta os bornes de cada régua e as reservas, com o tipo
        /// (simples/duplo) e o uso (desenho/reserva), e escreve o relatório no arquivo do
        /// diagnóstico (acrescentando, para caber antes/depois numa passada).
        /// </summary>
        [CommandMethod("STATBORN")]
        public void EstatisticaDeBornes()
        {
            Plugin.Escrever(ExecutarEstatisticaDeBornes());
        }

        /// <summary>Conta os bornes e escreve o relatório. Nunca lança.</summary>
        internal static string ExecutarEstatisticaDeBornes()
        {
            try
            {
                Modelos.EstatisticaDeBornesDoDesenho.Resultado resultado =
                    Modelos.EstatisticaDeBornesDoDesenho.Calcular();

                string caminho = System.Environment.GetEnvironmentVariable("POSITRON_DIAG");
                if (string.IsNullOrEmpty(caminho))
                {
                    caminho = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "positron-diag.txt");
                }

                System.Collections.Generic.List<string> linhas = new System.Collections.Generic.List<string>();
                linhas.Add("## STATBORN ##");
                linhas.Add(Positron.Data.Modelos.EstatisticaDeBornes.Cabecalho);
                foreach (Positron.Data.Modelos.LinhaDeEstatistica linha in resultado.Linhas)
                {
                    linhas.Add(Positron.Data.Modelos.EstatisticaDeBornes.Linha(linha));
                }

                linhas.Add(Positron.Data.Modelos.EstatisticaDeBornes.Linha(resultado.Total));
                System.IO.File.AppendAllLines(caminho, linhas);

                Positron.Data.Modelos.LinhaDeEstatistica total = resultado.Total;
                return "STATBORN: " + resultado.Linhas.Count + " régua(s), " + total.UsoS
                    + " usados simples, " + total.ResS + " de reserva simples, " + total.UsoD
                    + " usados duplos e " + total.ResD + " de reserva duplos (" + total.Total
                    + " no total; " + resultado.Bornes + " borne(s) no desenho e "
                    + resultado.Reservas + " reserva(s)) — escrito em " + caminho + ".";
            }
            catch (System.Exception erro)
            {
                return "STATBORN: falhou — " + DescreverErro(erro);
            }
        }

        /// <summary>
        /// <c>SYNCV</c> — o **pipeline das veias**, gêmeo do <c>SYNCD</c>. No reverso ele tem
        /// **nove** passos (barra de progresso com <c>Quantidade = 9</c>):
        /// <c>CorrigeOsTextosDosCabos</c> → <c>InsereTextosDeCabos</c> →
        /// <c>SincronizaVeiasDoCaderno</c> → <c>AtualizaNomesDosCabos</c> →
        /// <c>SincronizaCruzamentoInterlig</c> → <c>RecriaOCruzamentoInterligTipo2Apagados</c> →
        /// <c>AtualizaTodosOpcionaisDoCabo</c> → <c>ModeloDoDispositivoPrincipalTipo3</c>
        /// (conforme o <c>Conf.ModeloBobina</c>) → fim.
        ///
        /// Aqui entram, na ordem do original, os passos que o recoder **tem**:
        ///
        /// 1. os **textos dos cabos**, pelo <c>Conf.InterligacaoLayout</c> — é o <c>RECRIACABOS</c>
        ///    do original (0/2/3 = Eletron, 1 = Eletrosul);
        /// 2. a **projeção das veias** para o banco (<c>INT</c>), que é o
        ///    <c>SincronizaVeiasDoCaderno</c>;
        /// 3. os **opcionais do cabo** (<c>AtualizaTodosOpcionaisDoCabo</c>).
        ///
        /// **Fora do recorte, documentado:** o <c>InsereTextosDeCabos</c>, o
        /// <c>AtualizaNomesDosCabos</c>, a família do **cruzamento** da interligação e o
        /// <c>ModeloDoDispositivoPrincipalTipo3</c> (o modelo de bobina).
        /// </summary>
        [CommandMethod("SYNCV")]
        public void SincV()
        {
            // A barra do original (`Comandos.cs:865-911`): `Quantidade = 9` e **nove** `pbPasso` —
            // o primeiro antes da primeira rotina e um depois de cada uma. Aqui, os três passos do
            // recoder (`[n/3]`), um `pbPasso` por passo.
            Interface.Folhas.PaletaDeFolhas.ProgressoQuantidade(3);
            Interface.Folhas.PaletaDeFolhas.ProgressoIniciar();
            ConfiguracaoPositron config = ConfiguracaoEfetiva.Carregar();

            if (config.InterligacaoLayout == 1)
            {
                Plugin.Escrever("[1/3] " + ExecutarRecriarTextosDeCaboEletrosul());
            }
            else
            {
                Plugin.Escrever("[1/3] " + ExecutarRecriarTextosDeCabo());
            }

            Interface.Folhas.PaletaDeFolhas.ProgressoPasso();
            Plugin.Escrever("[2/3] " + ExecutarInterligacao());
            Interface.Folhas.PaletaDeFolhas.ProgressoPasso();
            Plugin.Escrever("[3/3] " + ExecutarAtualizarOpcionaisDoCabo());
            Interface.Folhas.PaletaDeFolhas.ProgressoPasso();
            Interface.Folhas.PaletaDeFolhas.ProgressoFim();
        }

        /// <summary>
        /// <c>CBD</c> — compacta o banco do projeto (o <c>clsCompactador.CompactarBD()</c> do
        /// original): no SQLite é o <c>VACUUM</c>, que devolve o espaço livre. É só banco: não olha
        /// o desenho.
        /// </summary>
        [CommandMethod("CBD")]
        public void CompactarBanco()
        {
            Plugin.Escrever(ExecutarCompactarBanco());
        }

        /// <summary>Compacta o banco e devolve a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarCompactarBanco()
        {
            try
            {
                ConfiguracaoPositron config = ConfiguracaoEfetiva.Carregar();
                if (string.IsNullOrEmpty(config.Banco))
                {
                    return "CBD: " + Positron.Data.Interface.MensagensDoReverso.BancoNaoConfigurado;
                }

                ProjectStore store = new ProjectStore(config.Banco);
                long[] tamanhos = store.Compactar();
                long liberado = tamanhos[0] - tamanhos[1];

                return "CBD: banco compactado — " + (tamanhos[0] / 1024) + " KB antes, "
                    + (tamanhos[1] / 1024) + " KB depois (" + (liberado / 1024) + " KB liberado(s)).";
            }
            catch (System.Exception erro)
            {
                return "CBD: falhou — " + DescreverErro(erro) + ".";
            }
        }

        /// <summary>
        /// <c>ApagaERROS</c> — apaga as entidades marcadas com o XData <c>ERRO</c> (o
        /// <c>clsBlocos.ApagaERROS</c>, passo 2 do <c>RESTPROJ</c>).
        /// </summary>
        [CommandMethod("ApagaERROS")]
        public void ApagarEntidadesDeErro()
        {
            Plugin.Escrever(ExecutarApagarEntidadesDeErro());
        }

        /// <summary>Apaga as entidades marcadas e devolve a linha de resumo. Nunca lança.</summary>
        internal static string ExecutarApagarEntidadesDeErro()
        {
            try
            {
                Correcoes.EntidadesDeErroDoDesenho.Resultado resultado =
                    Correcoes.EntidadesDeErroDoDesenho.Executar(Positron.Data.Correcoes.EntidadesDeErro.Marca);

                return "ApagaERROS: " + resultado.Marcadas + " entidade(s) marcada(s) apagada(s) de "
                    + resultado.Entidades + " no espaço de modelo.";
            }
            catch (System.Exception erro)
            {
                return "ApagaERROS: falhou — " + DescreverErro(erro) + ".";
            }
        }

        /// <summary>
        /// <c>RESTPROJ</c> — o **pipeline-mãe** do original: **dezesseis** passos (barra de
        /// progresso com <c>Quantidade = 16</c>) que **superam** o <c>SYNCD</c> (rodada 107) e o
        /// <c>SYNCV</c> (rodada 111).
        ///
        /// Aqui entram, na ordem do original, os passos que o recoder **tem**: os textos dos
        /// cabos pelo <c>Conf.InterligacaoLayout</c> (o <c>RECRIACABOS</c>), o <c>ApagaERROS</c>
        /// (novo nesta rodada), o <c>CorrigeModelosDeContatos</c>, a **projeção** (<c>FIA</c> +
        /// <c>INT</c>, que é o que no original fazem os quatro <c>Sincroniza*</c>) e os
        /// **opcionais do cabo** — estes só quando <c>Conf.InterligacaoLayout == 3</c>, como no
        /// original.
        ///
        /// **Fora do recorte, documentado:** o <c>ApagaContatosOrfaos</c>, o
        /// <c>EditaPortaDipAuxPainelModeloFabricante</c>, o <c>sincronizaCircuitos</c> (coberto
        /// pela projeção), o <c>InsereTextosDeCabos</c>, a família do **cruzamento**, o
        /// <c>AtualizaNomesDosCabos</c> e os modelos de bobina.
        /// </summary>
        [CommandMethod("RESTPROJ")]
        public void RestaurarProjeto()
        {
            // A barra do original (`Comandos.cs:1258-1259`) sai **invertida**: o `pbIniciar()` vem
            // antes do `Quantidade = 16`, então a barra herda o `Maximum` da rotina anterior e o 16
            // nunca chega a ela. O quirk é mantido — e, como no `SYNCD`/`SYNCV`, a quantidade é a
            // dos passos que o recoder roda (os seus cinco `[n/5]`).
            Interface.Folhas.PaletaDeFolhas.ProgressoIniciar();
            Interface.Folhas.PaletaDeFolhas.ProgressoQuantidade(5);
            ConfiguracaoPositron config = ConfiguracaoEfetiva.Carregar();

            if (config.InterligacaoLayout == 1)
            {
                Plugin.Escrever("[1/5] " + ExecutarRecriarTextosDeCaboEletrosul());
            }
            else
            {
                Plugin.Escrever("[1/5] " + ExecutarRecriarTextosDeCabo());
            }

            Interface.Folhas.PaletaDeFolhas.ProgressoPasso();
            Plugin.Escrever("[2/5] " + ExecutarApagarEntidadesDeErro());
            Interface.Folhas.PaletaDeFolhas.ProgressoPasso();
            Plugin.Escrever("[3/5] " + ExecutarCorrigirModelosDeContatos());
            Interface.Folhas.PaletaDeFolhas.ProgressoPasso();
            Plugin.Escrever("[4/5] " + ExecutarFiacao());
            Plugin.Escrever("[4/5] " + ExecutarInterligacao());
            // A projeção (`FIA` + `INT`) é **um** passo do recoder, como no `SYNCD`.
            Interface.Folhas.PaletaDeFolhas.ProgressoPasso();

            if (config.InterligacaoLayout == 3)
            {
                Plugin.Escrever("[5/5] " + ExecutarAtualizarOpcionaisDoCabo());
            }
            else
            {
                Plugin.Escrever("[5/5] os opcionais do cabo ficam de fora: o original só os atualiza com InterligacaoLayout = 3 (aqui = " + config.InterligacaoLayout + ").");
            }

            Interface.Folhas.PaletaDeFolhas.ProgressoPasso();
            Interface.Folhas.PaletaDeFolhas.ProgressoFim();
        }

        /// <summary>
        /// <c>RECRIACABOS</c> — recria os rótulos dos cabos **pelo layout da interligação**: no
        /// reverso é um <c>MsgBox</c> de confirmação e um <c>switch</c> sobre o
        /// <c>Conf.InterligacaoLayout</c> (o caso <c>1</c> usa o Eletrosul, os demais o Eletron).
        ///
        /// Aqui não há diálogo: o harness roda os comandos sem ninguém para responder, então a
        /// **confirmação é o próprio ato de rodar o comando** — a mesma decisão que deixa as
        /// rotinas destrutivas do original (com <c>MsgBox</c>) fora do recorte.
        /// </summary>
        [CommandMethod("RECRIACABOS")]
        public void RecriarCabosPeloLayout()
        {
            ConfiguracaoPositron config = ConfiguracaoEfetiva.Carregar();

            if (Positron.Data.Configuracao.LayoutDaInterligacao.EhEletrosul(config.InterligacaoLayout))
            {
                Plugin.Escrever("RECRIACABOS: layout " + config.InterligacaoLayout + " (Eletrosul). "
                    + ExecutarRecriarTextosDeCaboEletrosul());
            }
            else
            {
                Plugin.Escrever("RECRIACABOS: layout " + config.InterligacaoLayout + " (Eletron). "
                    + ExecutarRecriarTextosDeCabo());
            }
        }
    }
}

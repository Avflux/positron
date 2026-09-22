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
using Positron.Data.Licenca;
using Positron.Data.Modelos;
using Positron.Data.Plaquetas;
using Positron.Data.Relatorios;
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
    /// (<c>JMP</c>, <c>ELETCFG</c>, <c>ELETREL</c>, <c>ELETCMP</c> e <c>INDCABO</c>),
    /// e as tabelas fora do recorte que ganharam fluxo próprio (<c>EPLQ</c>).
    /// </summary>
    public sealed class Comandos
    {
        [CommandMethod("ELET")]
        public void Elet()
        {
            Plugin.Escrever("Positron — fiação e interligação do diagrama funcional.");
            Plugin.Escrever("FIA projeta a fiação do desenho para o banco do projeto.");
            Plugin.Escrever("INT projeta a interligação do desenho para o banco do projeto.");
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
        /// <c>ELETCFG</c> — abre a tela de configuração (o lugar das variáveis
        /// <c>POSITRON_*</c>) e grava o arquivo. Modal: **não** rode dentro de
        /// script, porque ninguém clica em OK.
        /// </summary>
        [CommandMethod("ELETCFG")]
        public void Configurar()
        {
#if !POSITRON_SEM_WINFORMS
            try
            {
                ConfiguracaoPositron atual = ConfiguracaoPositron.Carregar();
                using (Configuracao.FormularioConfiguracao tela = new Configuracao.FormularioConfiguracao(atual))
                {
                    if (tela.ShowDialog() != System.Windows.Forms.DialogResult.OK || tela.Resultado == null)
                    {
                        Plugin.Escrever("ELETCFG: configuração mantida.");
                        return;
                    }

                    tela.Resultado.Salvar();
                    Plugin.Escrever("ELETCFG: configuração gravada em " + ConfiguracaoPositron.ArquivoPadrao + ".");
                    Plugin.Escrever("ELETCFG: a variável de ambiente POSITRON_* tem prioridade sobre o arquivo.");
                }
            }
            catch (System.Exception erro)
            {
                Plugin.Escrever("ELETCFG: falhou — " + DescreverErro(erro));
            }
#else
            Plugin.Escrever("ELETCFG: compilado sem WinForms; edite " + ConfiguracaoPositron.ArquivoPadrao + " à mão.");
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
        /// Projeta a fiação do desenho e devolve a linha de resumo — usada tanto
        /// pelo <c>FIA</c> quanto pelo <c>SYNCD</c>. Nunca lança: um comando que
        /// estoura derruba a linha de comando do ZWCAD.
        /// </summary>
        internal static string ExecutarFiacao()
        {
            string bloqueio = BloqueioDeLicenca("FIA");
            if (bloqueio != null)
            {
                return bloqueio;
            }

            ConfiguracaoPositron config = ConfiguracaoPositron.Carregar();
            string caminho = config.Banco;
            if (string.IsNullOrEmpty(caminho))
            {
                return "FIA: defina POSITRON_DB_PATH com o caminho do banco do projeto (.db).";
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
                    Revisao = config.Revisao,
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
        internal static string ExecutarJumper()
        {
            string bloqueio = BloqueioDeLicenca("JMP");
            if (bloqueio != null)
            {
                return bloqueio;
            }

            ConfiguracaoPositron config = ConfiguracaoPositron.Carregar();
            string caminho = config.Banco;
            if (string.IsNullOrEmpty(caminho))
            {
                return "JMP: defina POSITRON_DB_PATH com o caminho do banco do projeto (.db).";
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
                    Revisao = config.Revisao,
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
            string bloqueio = BloqueioDeLicenca("EPLQ");
            if (bloqueio != null)
            {
                return bloqueio;
            }

            ConfiguracaoPositron config = ConfiguracaoPositron.Carregar();
            string caminho = config.Banco;
            if (string.IsNullOrEmpty(caminho))
            {
                return "EPLQ: defina POSITRON_DB_PATH com o caminho do banco do projeto (.db) — o cadastro de painéis (Paineis) vem dele.";
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
        /// Executa a ação de indefinir os cabos fora do catálogo e devolve a linha
        /// de resumo. Nunca lança.
        /// </summary>
        internal static string ExecutarIndefinirCabos()
        {
            string bloqueio = BloqueioDeLicenca("INDCABO");
            if (bloqueio != null)
            {
                return bloqueio;
            }

            ConfiguracaoPositron config = ConfiguracaoPositron.Carregar();
            string caminho = config.Banco;
            if (string.IsNullOrEmpty(caminho))
            {
                return "INDCABO: defina POSITRON_DB_PATH com o caminho do banco do projeto (.db) — o catálogo de cabos (Cabos) vem dele.";
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
        internal static string ExecutarInterligacao()
        {
            string bloqueio = BloqueioDeLicenca("INT");
            if (bloqueio != null)
            {
                return bloqueio;
            }

            ConfiguracaoPositron config = ConfiguracaoPositron.Carregar();
            string caminho = config.Banco;
            if (string.IsNullOrEmpty(caminho))
            {
                return "INT: defina POSITRON_DB_PATH com o caminho do banco do projeto (.db).";
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
                    Revisao = config.Revisao,
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
        /// <c>SYNCD</c> — projeta o **desenho inteiro** para o banco do projeto
        /// (fiação + interligação) num passo só: a regra "quem desenha, grava". O
        /// original sincroniza tabelas de apoio numa UI; aqui cada projetor já
        /// deriva o que precisa, então o sincronizar é <c>FIA</c> + <c>INT</c>.
        /// </summary>
        [CommandMethod("SYNCD")]
        public void SincD()
        {
            Plugin.Escrever(ExecutarFiacao());
            Plugin.Escrever(ExecutarInterligacao());
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
            string bloqueio = BloqueioDeLicenca("VERIF");
            if (bloqueio != null)
            {
                Plugin.Escrever(bloqueio);
                return;
            }

            ConfiguracaoPositron config = ConfiguracaoPositron.Carregar();
            string caminho = config.Banco;
            if (string.IsNullOrEmpty(caminho))
            {
                Plugin.Escrever("VERIF: defina POSITRON_DB_PATH com o caminho do banco do projeto (.db).");
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
            string bloqueio = BloqueioDeLicenca("ELETREL");
            if (bloqueio != null)
            {
                Plugin.Escrever(bloqueio);
                return;
            }

            ConfiguracaoPositron config = ConfiguracaoPositron.Carregar();
            string caminho = config.Banco;
            if (string.IsNullOrEmpty(caminho))
            {
                Plugin.Escrever("ELETREL: defina POSITRON_DB_PATH com o caminho do banco do projeto (.db).");
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

        /// <summary>
        /// <c>ELETCMP</c> — abre a **tela de compilação** (a grid de erros do
        /// `frmCompilarFiacao`/`Interligacao`) sobre a verificação da revisão. A tela
        /// só mostra e salva; quem monta o conteúdo é <see cref="MontarRelatorio"/>,
        /// o mesmo do `ELETREL`.
        ///
        /// **Modal** (como `ELETCFG`): não rode dentro de script — ninguém clica em OK
        /// e o ZWCAD fica parado. Para script existe o `ELETREL`.
        /// </summary>
        [CommandMethod("ELETCMP")]
        public void EletCmp()
        {
#if !POSITRON_SEM_WINFORMS
            ConfiguracaoPositron config = ConfiguracaoPositron.Carregar();
            if (string.IsNullOrEmpty(config.Banco))
            {
                Plugin.Escrever("ELETCMP: defina POSITRON_DB_PATH com o caminho do banco do projeto (.db).");
                return;
            }

            try
            {
                RelatorioCompilacao relatorio = MontarRelatorio(config);
                using (Relatorios.FormularioCompilacao tela = new Relatorios.FormularioCompilacao(relatorio, CaminhoDoRelatorio(config)))
                {
                    tela.ShowDialog();
                    Plugin.Escrever("ELETCMP: " + relatorio.Linhas.Count + " problema(s) na tela"
                        + (string.IsNullOrEmpty(tela.ArquivoSalvo) ? "." : " e salvos em " + tela.ArquivoSalvo + "."));
                }
            }
            catch (System.Exception erro)
            {
                Plugin.Escrever("ELETCMP: falhou — " + DescreverErro(erro));
            }
#else
            Plugin.Escrever("ELETCMP: compilado sem WinForms; use ELETREL para gravar o relatório.");
#endif
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
        private static List<Problema> VerificarRevisao(
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
            ConfiguracaoPositron config = ConfiguracaoPositron.Carregar();
            return new ColunaPagina(
                PaginasDoDesenho.Ler(),
                config.IncluirColuna,
                config.SeparadorCruzamento);
        }

        /// <summary>
        /// Gate de licença: devolve a mensagem de bloqueio, ou <c>null</c> quando
        /// autorizado. O provedor é plugável (ver <c>ServicoDeLicenca</c>); o padrão
        /// autoriza, então o recorte atual roda sem licença — a decisão de provedor
        /// (Rockey/ElecKey/Nuvem) não muda nenhum comando.
        /// </summary>
        private static string BloqueioDeLicenca(string comando)
        {
            ResultadoLicenca licenca = ServicoDeLicenca.Verificar();
            if (licenca.Autorizado)
            {
                return null;
            }

            return comando + ": comando bloqueado — " + (licenca.Mensagem ?? "licença não autorizada") + ".";
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
    }
}

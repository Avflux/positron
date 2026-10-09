using System;
using System.Collections.Generic;
using Positron.Contract;
using Positron.Data;
using Positron.Data.Cabos;
using Positron.Data.Bornes;
using Positron.Data.Fiacao;
using Positron.Data.Interligacao;
using Positron.Data.Layout;
using Positron.Data.Modelos;
using Positron.Plugin.Bornes;
using Positron.Plugin.Fiacao;
using Positron.Plugin.Interligacao;
using Positron.Plugin.Layout;
using Positron.Plugin.Modelos;
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
    /// <c>VERIF</c> — os nomes vêm do <c>COMANDOS.txt</c> do reverso.
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
            string caminho = Environment.GetEnvironmentVariable("POSITRON_DB_PATH");
            if (string.IsNullOrEmpty(caminho))
            {
                return "FIA: defina POSITRON_DB_PATH com o caminho do banco do projeto (.db).";
            }

            try
            {
                IReadOnlyList<PontoFiacao> pontos = FiacaoDoDesenho.Ler();
                if (pontos.Count == 0)
                {
                    return "FIA: nenhuma LWPOLYLINE com XData CONEXAO no desenho.";
                }

                ContextoProjecao contexto = new ContextoProjecao
                {
                    Dwg = LerInteiro("POSITRON_DWG", 0),
                    Revisao = Environment.GetEnvironmentVariable("POSITRON_REVISAO"),
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
                int circuitos = GerarCircuitos(store, contexto, paineis, pontos);
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
            string caminho = Environment.GetEnvironmentVariable("POSITRON_DB_PATH");
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
                    Dwg = LerInteiro("POSITRON_DWG", 0),
                    Revisao = Environment.GetEnvironmentVariable("POSITRON_REVISAO"),
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
        /// Projeta a interligação do desenho e devolve a linha de resumo — usada
        /// tanto pelo <c>INT</c> quanto pelo <c>SYNCD</c>. Nunca lança.
        /// </summary>
        internal static string ExecutarInterligacao()
        {
            string caminho = Environment.GetEnvironmentVariable("POSITRON_DB_PATH");
            if (string.IsNullOrEmpty(caminho))
            {
                return "INT: defina POSITRON_DB_PATH com o caminho do banco do projeto (.db).";
            }

            try
            {
                IReadOnlyList<PontoInterligacao> pontos = InterligacaoDoDesenho.Ler();
                if (pontos.Count == 0)
                {
                    return "INT: nenhuma LWPOLYLINE com XData INTERLIGACAO no desenho.";
                }

                ContextoInterligacao contexto = new ContextoInterligacao
                {
                    Dwg = LerInteiro("POSITRON_DWG", 0),
                    Documento = Environment.GetEnvironmentVariable("POSITRON_LOCAL"),
                    Revisao = Environment.GetEnvironmentVariable("POSITRON_REVISAO"),
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
            string caminho = Environment.GetEnvironmentVariable("POSITRON_DB_PATH");
            if (string.IsNullOrEmpty(caminho))
            {
                Plugin.Escrever("VERIF: defina POSITRON_DB_PATH com o caminho do banco do projeto (.db).");
                return;
            }

            try
            {
                ProjectStore store = new ProjectStore(caminho);
                int dwg = LerInteiro("POSITRON_DWG", 0);
                string revisao = Environment.GetEnvironmentVariable("POSITRON_REVISAO");

                IReadOnlyList<FiacaoRow> fiacao = store.FiacaoDaRevisao(dwg, revisao);
                IReadOnlyList<Interligacao4Row> interligacao = store.InterligacaoDaRevisao(dwg, revisao);
                IReadOnlyList<Portas4FRow> portas = store.PortasDaRevisao(dwg, revisao);
                IReadOnlyList<Bornes4FRow> bornes = store.BornesDaRevisao(dwg, revisao);
                IReadOnlyList<Contatos4FRow> contatos = store.ContatosDaRevisao(dwg, revisao);

                List<Problema> problemas = VerificadorProjeto.Verificar(
                    fiacao, interligacao, portas, bornes, contatos);

                // O verifier original também lê o DESENHO: a régua de cada borne e
                // o cabo referenciado que não existe no catálogo.
                ReguasModelo reguas = ReguasDoDesenho.Ler();
                IReadOnlyList<PontoBorne> bornesDoDesenho = BornesDoDesenho.Ler(reguas);
                problemas.AddRange(VerificadorProjeto.VerificarBornesSemRegua(bornesDoDesenho, reguas));

                // Borne do desenho que não casou com nenhum ponto de fiação (órfão).
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

                // Página gravada que não existe na LayerTable do desenho (a matriz
                // de páginas é montada dos layers, como o Pagina.CarregaPaginas).
                List<string> paginasGravadas = new List<string>();
                foreach (FiacaoRow fio in fiacao)
                {
                    paginasGravadas.Add(fio.Pagina);
                }

                foreach (Bornes4FRow borne in bornes)
                {
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

                Plugin.Escrever("VERIF: " + fiacao.Count + " fio(s), " + interligacao.Count + " trecho(s), "
                    + portas.Count + " porta(s), " + bornes.Count + " borne(s), " + contatos.Count
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
        /// </summary>
        private static int GerarCircuitos(
            ProjectStore store,
            ContextoProjecao contexto,
            ICollection<int> paineis,
            IReadOnlyList<PontoFiacao> pontos)
        {
            List<Circuito4F> linhas = Circuitos4FGerador.Gerar(pontos, paineis);
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
        /// `SeparadorCruzamento`, do ambiente — a tela do original
        /// (`frmConfiguracaoGeral`) ainda não existe aqui. Sem configuração, o
        /// comportamento é o caso 0..2 (layer cru). Ver `ColunaPagina`.
        /// </summary>
        private static ColunaPagina LerColunaPagina()
        {
            return new ColunaPagina(
                PaginasDoDesenho.Ler(),
                LerInteiro("POSITRON_INCLUIR_COLUNA", 0),
                Environment.GetEnvironmentVariable("POSITRON_SEPARADOR_CRUZAMENTO"));
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

        private static int LerInteiro(string nome, int padrao)
        {
            string valor = Environment.GetEnvironmentVariable(nome);
            int numero;
            return !string.IsNullOrEmpty(valor) && int.TryParse(valor, out numero) ? numero : padrao;
        }
    }
}

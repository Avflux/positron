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

                ProjectStore store = new ProjectStore(caminho);
                FiacaoProjetor projetor = new FiacaoProjetor(store);
                int gravados = projetor.Projetar(pontos, contexto, bornes, posicoes, deslocamentos, dispositivosDeFiacao);

                // Renumera Ordem 1..N por potencial (ReordenaOrdemPotenciais do
                // original). No-op quando a projeção já inseriu ordenada.
                int reordenados = store.ReordenarOrdemFiacao(contexto.Dwg, contexto.Revisao);

                int portas = GerarPortas(store, contexto, emUso.Modelos);
                int reservas = GerarBornes(store, contexto, reguas, bornes, paineis);
                int contatos = GerarContatos(store, contexto, dispositivos);
                int dispositivos4F = GerarDispositivos(store, contexto, paineis, dispositivosDeFiacao, posicoes);
                int circuitos = GerarCircuitos(store, contexto, paineis, pontos);

                return "FIA: " + gravados + " linha(s) em Fiacao (" + bornes.Count + " borne(s), "
                    + dispositivosDeFiacao.Count + " dispositivo(s), "
                    + reordenados + " reordenada(s), " + posicoes.NumPosicoes + " posicao(oes), "
                    + deslocamentos.NumPontos + " ponto(s) de bloco); "
                    + portas + " porta(s) em Portas4F; " + reservas + " borne(s) em Bornes4F; "
                    + contatos + " contato(s) em Contatos4F; "
                    + dispositivos4F + " dispositivo(s) em Dispositivos4F; "
                    + circuitos + " circuito(s) em Circuitos4F.";
            }
            catch (System.Exception erro)
            {
                return "FIA: falhou — " + erro.Message;
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

                ProjectStore store = new ProjectStore(caminho);
                InterligacaoProjetor projetor = new InterligacaoProjetor(store);
                int gravados = projetor.Projetar(pontos, contexto, bornes, deslocamentos);

                // Snapshot do catálogo por revisão (RUIU5Sbjhj/v1TU0cEjWd do
                // original): Cabos4/Veias4 são o catálogo carimbado com a revisão.
                int cabos = RegravarCabos4(store, contexto);
                int veias = RegravarVeias4(store, contexto);

                return "INT: " + gravados + " linha(s) gravada(s) em Interligacao4 ("
                    + bornes.Count + " borne(s)); " + cabos + " cabo(s) em Cabos4; "
                    + veias + " veia(s) em Veias4.";
            }
            catch (System.Exception erro)
            {
                return "INT: falhou — " + erro.Message;
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

                int porFiacao = 0;
                int porInterligacao = 0;
                int porModelos = 0;
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
                    }
                }

                Plugin.Escrever("VERIF: " + fiacao.Count + " fio(s), " + interligacao.Count + " trecho(s), "
                    + portas.Count + " porta(s), " + bornes.Count + " borne(s), " + contatos.Count
                    + " contato(s) na revisão.");
                Plugin.Escrever("VERIF: " + problemas.Count + " problema(s) — fiação: " + porFiacao
                    + "; interligação: " + porInterligacao + "; modelos: " + porModelos + ".");
            }
            catch (System.Exception erro)
            {
                Plugin.Escrever("VERIF: falhou — " + erro.Message);
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
            ICollection<int> paineisEmUso)
        {
            Dictionary<int, IReadOnlyList<BorneReserva>> reservasPorRegua =
                new Dictionary<int, IReadOnlyList<BorneReserva>>();
            foreach (ReguaInfo regua in reguas.Ordenadas)
            {
                reservasPorRegua[regua.Indice] = BornesReservaDoDesenho.Ler(regua.Indice);
            }

            List<Borne4F> linhas = Bornes4FGerador.Gerar(bornes, reguas, paineisEmUso, reservasPorRegua);
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
            LayoutPosicoes posicoes)
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
            store.InserirDispositivos(linhas, contexto.Revisao, contexto.Dwg);
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

        private static int LerInteiro(string nome, int padrao)
        {
            string valor = Environment.GetEnvironmentVariable(nome);
            int numero;
            return !string.IsNullOrEmpty(valor) && int.TryParse(valor, out numero) ? numero : padrao;
        }
    }
}

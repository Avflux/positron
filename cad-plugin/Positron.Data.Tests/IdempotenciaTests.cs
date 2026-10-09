using System;
using System.Collections.Generic;
using Positron.Contract;
using Positron.Data.Fiacao;
using Positron.Data.Interligacao;
using Positron.Data.Modelos;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// A projeção SUBSTITUI a revisão de um desenho (DWG + Revisão) — o
    /// <c>RemoveRevisaoTabelaParaDWG</c> do original. Rodar o mesmo comando duas
    /// vezes no mesmo desenho não pode duplicar linha nem bagunçar a <c>Ordem</c>.
    /// </summary>
    public class IdempotenciaTests
    {
        private static ContextoProjecao ContextoFiacao(int dwg, string revisao)
        {
            return new ContextoProjecao
            {
                Dwg = dwg,
                Revisao = revisao,
                Criador = "ana",
                Data = new DateTime(2026, 10, 9, 9, 0, 0),
            };
        }

        private static ContextoInterligacao ContextoInterligacao(int dwg, string revisao)
        {
            return new ContextoInterligacao
            {
                Dwg = dwg,
                Documento = "LOCAL-A",
                Revisao = revisao,
                Criador = "ana",
                Data = new DateTime(2026, 10, 9, 9, 0, 0),
            };
        }

        private static List<PontoFiacao> PontosFiacao()
        {
            return new List<PontoFiacao>
            {
                new PontoFiacao { Painel = 1, Potencial = 7, Secao = "2,5", Cor = "PT" },
                new PontoFiacao { Painel = 1, Potencial = 7, Secao = "4", Cor = "PT" },
                new PontoFiacao { Painel = 1, Potencial = 9, Secao = "2,5", Cor = "AZ" },
            };
        }

        [Fact]
        public void Fiacao_rodar_duas_vezes_nao_duplica_e_mantem_ordem()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);
                FiacaoProjetor projetor = new FiacaoProjetor(store);
                ContextoProjecao contexto = ContextoFiacao(1, "R0");

                projetor.Projetar(PontosFiacao(), contexto);
                IReadOnlyList<FiacaoRow> primeira = store.FiacaoDaRevisao(1, "R0");
                Assert.Equal(3, primeira.Count);

                projetor.Projetar(PontosFiacao(), contexto);
                IReadOnlyList<FiacaoRow> segunda = store.FiacaoDaRevisao(1, "R0");

                Assert.Equal(primeira.Count, segunda.Count);
                Assert.Equal(Ordens(primeira), Ordens(segunda));
                Assert.Equal(new long[] { 1, 2, 1 }, Ordens(segunda));
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }

        [Fact]
        public void Fiacao_preserva_outras_revisoes_e_outros_desenhos()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);
                FiacaoProjetor projetor = new FiacaoProjetor(store);

                projetor.Projetar(PontosFiacao(), ContextoFiacao(1, "R0"));
                projetor.Projetar(PontosFiacao(), ContextoFiacao(1, "R1"));
                projetor.Projetar(PontosFiacao(), ContextoFiacao(2, "R0"));

                Assert.Equal(3, store.FiacaoDaRevisao(1, "R0").Count);
                Assert.Equal(3, store.FiacaoDaRevisao(1, "R1").Count);
                Assert.Equal(3, store.FiacaoDaRevisao(2, "R0").Count);
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }

        [Fact]
        public void Interligacao_rodar_duas_vezes_nao_duplica()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);
                ContextoInterligacao contexto = ContextoInterligacao(1, "R0");

                // Tipo == 2: cada polyline traz uma ponta; o projetor mescla por
                // (Tag_Cabo, Num_Veia) — uma linha só.
                List<PontoInterligacao> pontos = new List<PontoInterligacao>
                {
                    new PontoInterligacao { Tipo = 2, Tag_Cabo = "CABO1", NumVeia = 1, NomeVeia = "V1", Painel1 = 2 },
                    new PontoInterligacao { Tipo = 2, Tag_Cabo = "CABO1", NumVeia = 1, NomeVeia = "V1", Painel2 = 4 },
                };

                List<TrechoInterligacao> linhas = InterligacaoProjetor.Mesclar(pontos, contexto);
                Assert.Single(linhas);

                store.InserirInterligacao(linhas);
                Assert.Single(store.InterligacaoDaRevisao(1, "R0"));

                store.InserirInterligacao(linhas);
                Assert.Single(store.InterligacaoDaRevisao(1, "R0"));
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }

        [Fact]
        public void Modelos_rodar_duas_vezes_nao_duplica()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);

                List<Porta4F> portas = new List<Porta4F>
                {
                    new Porta4F { IndexModelo = 1, NomeModelo = "M1", Tipo = "T", Terminal = "1" },
                };
                List<Borne4F> bornes = new List<Borne4F>
                {
                    new Borne4F { Painel = 1, IndexRegua = 8, Regua = "R1", Borne = "1", Ordem = 1.0, Tipo = 1 },
                };
                List<Contato4F> contatos = new List<Contato4F>
                {
                    new Contato4F { IndexModelo = 2, NomeModelo = "C1", Terminal = "13" },
                };

                GravarModelos(store, portas, bornes, contatos, "R0");
                Assert.Single(store.PortasDaRevisao(1, "R0"));
                Assert.Single(store.BornesDaRevisao(1, "R0"));
                Assert.Single(store.ContatosDaRevisao(1, "R0"));

                GravarModelos(store, portas, bornes, contatos, "R0");
                Assert.Single(store.PortasDaRevisao(1, "R0"));
                Assert.Single(store.BornesDaRevisao(1, "R0"));
                Assert.Single(store.ContatosDaRevisao(1, "R0"));
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }

        [Fact]
        public void Lote_vazio_limpa_so_a_revisao_alvo()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);
                List<Porta4F> portas = new List<Porta4F>
                {
                    new Porta4F { IndexModelo = 1, NomeModelo = "M1", Tipo = "T", Terminal = "1" },
                };

                store.InserirPortas(portas, "R0", 1);
                store.InserirPortas(portas, "R1", 1);
                Assert.Single(store.PortasDaRevisao(1, "R0"));
                Assert.Single(store.PortasDaRevisao(1, "R1"));

                // O desenho não tem mais porta nenhuma nesta revisão: o banco
                // reflete o desenho, mas a outra revisão fica intacta.
                store.InserirPortas(new List<Porta4F>(), "R0", 1);
                Assert.Empty(store.PortasDaRevisao(1, "R0"));
                Assert.Single(store.PortasDaRevisao(1, "R1"));
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }

        private static void GravarModelos(
            ProjectStore store,
            List<Porta4F> portas,
            List<Borne4F> bornes,
            List<Contato4F> contatos,
            string revisao)
        {
            store.InserirPortas(portas, revisao, 1);
            store.InserirBornes(bornes, revisao, 1);
            store.InserirContatos(contatos, revisao, 1);
        }

        private static long[] Ordens(IReadOnlyList<FiacaoRow> linhas)
        {
            long[] valores = new long[linhas.Count];
            for (int i = 0; i < linhas.Count; i++)
            {
                valores[i] = linhas[i].Ordem ?? 0;
            }

            return valores;
        }
    }
}

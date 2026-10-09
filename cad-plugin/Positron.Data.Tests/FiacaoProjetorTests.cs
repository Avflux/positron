using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using Positron.Contract;
using Positron.Data.Bornes;
using Positron.Data.Fiacao;
using Xunit;

namespace Positron.Data.Tests
{
    public class FiacaoProjetorTests
    {
        [Fact]
        public void Grava_e_numera_ordem_por_potencial()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);
                FiacaoProjetor projetor = new FiacaoProjetor(store);

                List<PontoFiacao> pontos = new List<PontoFiacao>
                {
                    new PontoFiacao { Painel = 1, Potencial = 9, Secao = "2,5", Cor = "AZ" },
                    new PontoFiacao { Painel = 1, Potencial = 7, Secao = "2,5", Cor = "PT" },
                    new PontoFiacao { Painel = 1, Potencial = 7, Secao = "4", Cor = "PT" },
                };
                ContextoProjecao contexto = new ContextoProjecao
                {
                    Dwg = 1,
                    Revisao = "R0",
                    Criador = "ana",
                    Data = new DateTime(2026, 10, 7, 12, 0, 0),
                };

                int gravados = projetor.Projetar(pontos, contexto);
                Assert.Equal(3, gravados);

                IReadOnlyList<FiacaoRow> linhas = store.FiacaoDoPainel(1);
                Assert.Equal(3, linhas.Count);

                // Ordem dentro de cada potencial: 7 → 1, 2; depois 9 → 1.
                Assert.Equal(new long[] { 7, 7, 9 }, PotencialPorLinha(linhas));
                Assert.Equal(new long[] { 1, 2, 1 }, OrdemPorLinha(linhas));
                Assert.Equal("2,5", linhas[0].Secao);
                Assert.Equal("4", linhas[1].Secao);

                // Contexto aplicado em todas as linhas.
                foreach (FiacaoRow linha in linhas)
                {
                    Assert.Equal("R0", linha.Revisao);
                    Assert.Equal(1L, linha.DWG ?? -1);
                    Assert.Equal("ana", linha.Criador);
                }
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }

        [Fact]
        public void Ordem_reinicia_em_cada_potencial_mesmo_fora_de_ordem()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);
                FiacaoProjetor projetor = new FiacaoProjetor(store);

                // Entrada fora de ordem de propósito: o projetor ordena.
                List<PontoFiacao> pontos = new List<PontoFiacao>
                {
                    new PontoFiacao { Painel = 2, Potencial = 5 },
                    new PontoFiacao { Painel = 2, Potencial = 3 },
                    new PontoFiacao { Painel = 2, Potencial = 5 },
                    new PontoFiacao { Painel = 2, Potencial = 3 },
                };

                projetor.Projetar(pontos, new ContextoProjecao { Dwg = 1, Criador = "ana", Data = DateTime.Now });

                IReadOnlyList<FiacaoRow> linhas = store.FiacaoDoPainel(2);
                Assert.Equal(new long[] { 1, 2, 1, 2 }, OrdemPorLinha(linhas));
                Assert.Equal(new long[] { 3, 3, 5, 5 }, PotencialPorLinha(linhas));
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }

        [Fact]
        public void Casamento_com_borne_preenche_terminal_e_regua()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);
                FiacaoProjetor projetor = new FiacaoProjetor(store);

                List<PontoFiacao> pontos = new List<PontoFiacao>
                {
                    new PontoFiacao { Painel = 1, Potencial = 4, X = 0.0, Y = 0.0, Layer = "PAG1" },
                };

                List<PontoBorne> bornes = new List<PontoBorne>
                {
                    new PontoBorne
                    {
                        Handle = "H1", X = 0.1, Y = 0.0, Layer = "PAG1", Painel = 1,
                        Terminal = "12A", Ordem = 3.5, IndiceRegua = 8, Tipo = 1,
                        NomeRegua = "R1", Alternativo = "ALT1",
                    },
                };

                int gravados = projetor.Projetar(pontos, new ContextoProjecao { Dwg = 1, Criador = "ana", Data = DateTime.Now }, bornes);
                Assert.Equal(1, gravados);

                IReadOnlyList<FiacaoRow> linhas = store.FiacaoDoPainel(1);
                FiacaoRow linha = Assert.Single(linhas);
                Assert.Equal("R1/ALT1", linha.Tag);
                Assert.Equal("12A", linha.Terminal);
                // Pagina é o layer da conexão (o `pot.layer` do AdicionaItemPotencial).
                Assert.Equal("PAG1", linha.Pagina);
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }

        [Fact]
        public void Pagina_vem_do_layer_da_conexao_sem_depender_do_borne()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);
                FiacaoProjetor projetor = new FiacaoProjetor(store);

                // O original grava `pot.layer` em `Pagina` para todo ponto — o
                // ponto que não casa com borne também recebe a sua página.
                List<PontoFiacao> pontos = new List<PontoFiacao>
                {
                    new PontoFiacao { Painel = 1, Potencial = 1, Layer = "PAG-A" },
                    new PontoFiacao { Painel = 1, Potencial = 1, Layer = "PAG-B" },
                };

                int gravados = projetor.Projetar(pontos, new ContextoProjecao { Dwg = 1, Criador = "ana", Data = DateTime.Now });
                Assert.Equal(2, gravados);

                IReadOnlyList<FiacaoRow> linhas = store.FiacaoDoPainel(1);
                Assert.Equal(2, linhas.Count);
                Assert.Equal("PAG-A", linhas[0].Pagina);
                Assert.Equal("PAG-B", linhas[1].Pagina);
                Assert.Null(linhas[0].Tag);
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }

        [Fact]
        public void Borne_vem_primeiro_e_ordem_e_renumerada()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);
                FiacaoProjetor projetor = new FiacaoProjetor(store);

                // Dois pontos no mesmo potencial. Na entrada o não-borne vem
                // primeiro, mas o borne (PosicaoNum = 1) tem que vir antes na Ordem.
                List<PontoFiacao> pontos = new List<PontoFiacao>
                {
                    new PontoFiacao { Painel = 1, Potencial = 4, X = 50.0, Y = 50.0, Layer = "PAG1" },
                    new PontoFiacao { Painel = 1, Potencial = 4, X = 0.0, Y = 0.0, Layer = "PAG1" },
                };
                List<PontoBorne> bornes = new List<PontoBorne>
                {
                    new PontoBorne
                    {
                        Handle = "H1", X = 0.1, Y = 0.0, Layer = "PAG1", Painel = 1,
                        Terminal = "T1", Ordem = 5.0, IndiceRegua = 8, NomeRegua = "R1",
                    },
                };

                projetor.Projetar(pontos, new ContextoProjecao { Dwg = 1, Criador = "ana", Data = DateTime.Now }, bornes);

                IReadOnlyList<FiacaoRow> linhas = store.FiacaoDoPainel(1);
                Assert.Equal(2, linhas.Count);

                // Ordem 1 = o borne (PosicaoNum 1), com terminal preenchido e
                // **NRegua vazio** — no original essa coluna so sai do casamento da
                // porta (E); o nome da regua vai na `Tag`.
                Assert.Equal(1L, linhas[0].Ordem ?? 0);
                Assert.Equal(1L, linhas[0].PosicaoNum ?? 0);
                Assert.Equal("R1", linhas[0].Tag);
                Assert.True(string.IsNullOrEmpty(linhas[0].NRegua));
                Assert.Equal("T1", linhas[0].Terminal);
                Assert.Equal(8L, linhas[0].IndexModelo ?? -1);

                // Ordem 2 = o não-borne.
                Assert.Equal(2L, linhas[1].Ordem ?? 0);
                Assert.Equal(0L, linhas[1].PosicaoNum ?? -1);
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }

        [Fact]
        public void Reordenar_numera_ordem_de_1_a_n_por_potencial()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                // Linhas "cruas" com Ordem fora de sequência (como um banco antigo).
                using (SQLiteConnection conexao = new SQLiteConnection("Data Source=" + caminho + ";Version=3;"))
                {
                    conexao.Open();
                    using (SQLiteCommand comando = conexao.CreateCommand())
                    {
                        comando.CommandText =
                            "INSERT INTO Fiacao(Revisao, DWG, Painel, Potencial, Ordem, BJumper, BLink) VALUES" +
                            "('R0', 1, 1, 7, 5, 0, 0), ('R0', 1, 1, 7, 9, 0, 0), " +
                            "('R0', 1, 1, 9, 2, 0, 0), ('R0', 1, 1, 9, 4, 0, 0)";
                        comando.ExecuteNonQuery();
                    }
                }

                ProjectStore store = new ProjectStore(caminho);
                int corrigidas = store.ReordenarOrdemFiacao(1, "R0");
                Assert.Equal(4, corrigidas);

                IReadOnlyList<FiacaoRow> linhas = store.FiacaoDoPainel(1);
                Assert.Equal(new long[] { 7, 7, 9, 9 }, PotencialPorLinha(linhas));
                Assert.Equal(new long[] { 1, 2, 1, 2 }, OrdemPorLinha(linhas));
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }

        private static long[] OrdemPorLinha(IReadOnlyList<FiacaoRow> linhas)
        {
            long[] valores = new long[linhas.Count];
            for (int i = 0; i < linhas.Count; i++)
            {
                valores[i] = linhas[i].Ordem ?? 0;
            }

            return valores;
        }

        private static long[] PotencialPorLinha(IReadOnlyList<FiacaoRow> linhas)
        {
            long[] valores = new long[linhas.Count];
            for (int i = 0; i < linhas.Count; i++)
            {
                valores[i] = linhas[i].Potencial ?? 0;
            }

            return valores;
        }
    }
}

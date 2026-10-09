using System.Collections.Generic;
using Positron.Contract;
using Positron.Data.Fiacao;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// <c>Jumper4</c> — o <c>JMP</c> (<c>frmCompilarJumperExt</c>): a mesma máquina
    /// do <c>FIA</c>, com a tabela de destino trocada.
    /// </summary>
    public class JumperTests
    {
        private static ContextoProjecao Contexto()
        {
            return new ContextoProjecao
            {
                Dwg = 1,
                Revisao = "R0",
                Criador = "ana",
                Data = new System.DateTime(2026, 10, 9, 10, 0, 0),
            };
        }

        private static List<PontoFiacao> Pontos()
        {
            return new List<PontoFiacao>
            {
                new PontoFiacao { Painel = 1, Potencial = 7, BJumper = true, Layer = "12" },
                new PontoFiacao { Painel = 1, Potencial = 7, BJumper = true, Layer = "12" },
                new PontoFiacao { Painel = 1, Potencial = 9, BJumper = true, Layer = "13" },
            };
        }

        [Fact]
        public void JMP_grava_em_Jumper4_e_nao_em_Fiacao()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);
                FiacaoProjetor projetor = new FiacaoProjetor(store, true);

                int gravados = projetor.Projetar(Pontos(), Contexto());
                Assert.Equal(3, gravados);

                IReadOnlyList<Jumper4Row> linhas = store.JumperDaRevisao(1, "R0");
                Assert.Equal(3, linhas.Count);
                Assert.Equal("R0", linhas[0].Revisao);
                Assert.True(linhas[0].BJumper);

                // Ordem reinicia a cada potencial, como no FIA.
                Assert.Equal(new long[] { 7, 7, 9 }, Potenciais(linhas));
                Assert.Equal(new long[] { 1, 2, 1 }, Ordens(linhas));

                // O jumper não vaza para a tabela da fiação.
                Assert.Empty(store.FiacaoDaRevisao(1, "R0"));
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }

        [Fact]
        public void JMP_rodar_duas_vezes_nao_duplica()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);
                FiacaoProjetor projetor = new FiacaoProjetor(store, true);

                projetor.Projetar(Pontos(), Contexto());
                projetor.Projetar(Pontos(), Contexto());

                Assert.Equal(3, store.JumperDaRevisao(1, "R0").Count);
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }

        [Fact]
        public void JMP_respeita_a_coluna_pagina_montada()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);
                FiacaoProjetor projetor = new FiacaoProjetor(store, true);

                List<PontoFiacao> pontos = Pontos();
                foreach (PontoFiacao ponto in pontos)
                {
                    ponto.Pagina = "(12)-P12";
                }

                projetor.Projetar(pontos, Contexto());

                IReadOnlyList<Jumper4Row> linhas = store.JumperDaRevisao(1, "R0");
                Assert.Equal("(12)-P12", linhas[0].Pagina);
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }

        private static long[] Potenciais(IReadOnlyList<Jumper4Row> linhas)
        {
            long[] valores = new long[linhas.Count];
            for (int i = 0; i < linhas.Count; i++)
            {
                valores[i] = linhas[i].Potencial ?? 0;
            }

            return valores;
        }

        private static long[] Ordens(IReadOnlyList<Jumper4Row> linhas)
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

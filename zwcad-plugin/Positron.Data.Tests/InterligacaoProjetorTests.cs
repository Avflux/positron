using System;
using System.Collections.Generic;
using Positron.Contract;
using Positron.Data.Interligacao;
using Xunit;

namespace Positron.Data.Tests
{
    public class InterligacaoProjetorTests
    {
        private static ContextoInterligacao Contexto()
        {
            return new ContextoInterligacao
            {
                Dwg = 1,
                Revisao = "R0",
                Criador = "ana",
                Data = new DateTime(2026, 10, 7, 12, 0, 0),
            };
        }

        [Fact]
        public void Mescla_as_duas_pontas_do_mesmo_cabo_veia()
        {
            // Tipo == 2: cada polyline traz uma ponta; Painel1 > 0 indica a ponta 1.
            List<PontoInterligacao> pontos = new List<PontoInterligacao>
            {
                new PontoInterligacao { Tipo = 2, Tag_Cabo = "CABO1", NumVeia = 1, NomeVeia = "V1", Painel1 = 2, Painel2 = 0, Pagina = "PAG-ORIG" },
                new PontoInterligacao { Tipo = 2, Tag_Cabo = "CABO1", NumVeia = 1, NomeVeia = "V1", Painel1 = 0, Painel2 = 4, Pagina = "PAG-DEST" },
            };

            List<TrechoInterligacao> linhas = InterligacaoProjetor.Mesclar(pontos, Contexto());

            Assert.Single(linhas);
            Assert.Equal("CABO1", linhas[0].Tag_Cabo);
            Assert.Equal(1, linhas[0].NumVeia);
            Assert.Equal((short)2, linhas[0].Painel1);
            Assert.Equal("PAG-ORIG", linhas[0].Pagina1);
            Assert.Equal((short)4, linhas[0].Painel2);
            Assert.Equal("PAG-DEST", linhas[0].Pagina2);
        }

        [Fact]
        public void Tipo_um_preenche_as_duas_pontas_de_uma_so_polyline()
        {
            List<PontoInterligacao> pontos = new List<PontoInterligacao>
            {
                new PontoInterligacao { Tipo = 1, Tag_Cabo = "CABO2", NumVeia = 2, NomeVeia = "V2", Painel1 = 3, Painel2 = 5, Pagina = "PAG-X" },
            };

            List<TrechoInterligacao> linhas = InterligacaoProjetor.Mesclar(pontos, Contexto());

            Assert.Single(linhas);
            Assert.Equal((short)3, linhas[0].Painel1);
            Assert.Equal((short)5, linhas[0].Painel2);
            Assert.Equal("PAG-X", linhas[0].Pagina1);
            Assert.Equal("PAG-X", linhas[0].Pagina2);
        }

        [Fact]
        public void Cabos_diferentes_viram_linhas_diferentes()
        {
            List<PontoInterligacao> pontos = new List<PontoInterligacao>
            {
                new PontoInterligacao { Tipo = 1, Tag_Cabo = "CABO1", NumVeia = 1, Painel1 = 1, Painel2 = 2, Pagina = "A" },
                new PontoInterligacao { Tipo = 1, Tag_Cabo = "CABO2", NumVeia = 1, Painel1 = 3, Painel2 = 4, Pagina = "B" },
            };

            List<TrechoInterligacao> linhas = InterligacaoProjetor.Mesclar(pontos, Contexto());
            Assert.Equal(2, linhas.Count);
        }

        [Fact]
        public void Grava_no_banco_e_le_de_volta()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);
                InterligacaoProjetor projetor = new InterligacaoProjetor(store);

                List<PontoInterligacao> pontos = new List<PontoInterligacao>
                {
                    new PontoInterligacao { Tipo = 2, Tag_Cabo = "CABO1", NumVeia = 1, NomeVeia = "V1", Painel1 = 2, Pagina = "PAG-ORIG" },
                    new PontoInterligacao { Tipo = 2, Tag_Cabo = "CABO1", NumVeia = 1, NomeVeia = "V1", Painel1 = 0, Painel2 = 4, Pagina = "PAG-DEST" },
                    new PontoInterligacao { Tipo = 1, Tag_Cabo = "CABO1", NumVeia = 2, NomeVeia = "V2", Painel1 = 2, Painel2 = 7, Pagina = "AT" },
                };

                int gravados = projetor.Projetar(pontos, Contexto());
                Assert.Equal(2, gravados);

                IReadOnlyList<Interligacao4Row> linhas = store.InterligacaoPorCabo("CABO1");
                Assert.Equal(2, linhas.Count);

                // Ordenado por Num_Veia.
                Assert.Equal(1L, linhas[0].Num_Veia.Value);
                Assert.Equal((short)2, (short)linhas[0].Painel1);
                Assert.Equal("PAG-ORIG", linhas[0].Pagina1);
                Assert.Equal((short)4, (short)linhas[0].Painel2);
                Assert.Equal("PAG-DEST", linhas[0].Pagina2);
                Assert.Equal("R0", linhas[0].Revisao);
                Assert.Equal(1L, linhas[0].DWG);
                Assert.Equal("ana", linhas[0].Criador);

                Assert.Equal(2L, linhas[1].Num_Veia.Value);
                Assert.Equal((short)2, (short)linhas[1].Painel1);
                Assert.Equal((short)7, (short)linhas[1].Painel2);
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }
    }
}

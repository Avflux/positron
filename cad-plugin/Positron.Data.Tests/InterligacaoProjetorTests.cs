using System;
using System.Collections.Generic;
using Positron.Contract;
using Positron.Data.Bornes;
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
                Documento = "LOCAL-A",
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
        public void Tipo_tres_anexa_linha_so_de_destino()
        {
            // Tipo == 3: a polyline só traz a ponta de destino; a ponta 1 fica
            // sem painel nem página (o original a inicializa como sentinela).
            List<PontoInterligacao> pontos = new List<PontoInterligacao>
            {
                new PontoInterligacao
                {
                    Tipo = 3, Tag_Cabo = "CABO3", NumVeia = 1, NomeVeia = "V1",
                    Painel2 = 4, Pagina = "PAG-DEST",
                    TemPonta2 = true, X2 = 20.0, Y2 = 20.0,
                },
            };

            List<TrechoInterligacao> linhas = InterligacaoProjetor.Mesclar(pontos, Contexto());

            Assert.Single(linhas);
            Assert.False(linhas[0].TemPonta1);
            Assert.Equal((short)0, linhas[0].Painel1);
            Assert.Null(linhas[0].Pagina1);
            Assert.True(linhas[0].TemPonta2);
            Assert.Equal((short)4, linhas[0].Painel2);
            Assert.Equal("PAG-DEST", linhas[0].Pagina2);
        }

        [Fact]
        public void Tipo_tres_e_um_nao_mesclam_com_o_mesmo_cabo_veia()
        {
            // Só o Tipo == 2 mescla pela chave (Tag_Cabo, Num_Veia); Tipo 1 e 3
            // sempre anexam uma linha nova, como no original.
            List<PontoInterligacao> pontos = new List<PontoInterligacao>
            {
                new PontoInterligacao { Tipo = 1, Tag_Cabo = "CABO-A", NumVeia = 1, Painel1 = 2, Painel2 = 3, Pagina = "PAG-A", TemPonta1 = true, X1 = 1.0, Y1 = 1.0, TemPonta2 = true, X2 = 2.0, Y2 = 2.0 },
                new PontoInterligacao { Tipo = 1, Tag_Cabo = "CABO-A", NumVeia = 1, Painel1 = 4, Painel2 = 5, Pagina = "PAG-B", TemPonta1 = true, X1 = 3.0, Y1 = 3.0, TemPonta2 = true, X2 = 4.0, Y2 = 4.0 },
                new PontoInterligacao { Tipo = 2, Tag_Cabo = "CABO-B", NumVeia = 1, Painel1 = 6, Pagina = "PAG-C", TemPonta1 = true, X1 = 5.0, Y1 = 5.0 },
                new PontoInterligacao { Tipo = 3, Tag_Cabo = "CABO-B", NumVeia = 1, Painel2 = 7, Pagina = "PAG-D", TemPonta2 = true, X2 = 6.0, Y2 = 6.0 },
            };

            List<TrechoInterligacao> linhas = InterligacaoProjetor.Mesclar(pontos, Contexto());

            Assert.Equal(4, linhas.Count);
            // As duas Tipo 1 ficaram separadas.
            Assert.Equal((short)2, linhas[0].Painel1);
            Assert.Equal((short)3, linhas[0].Painel2);
            Assert.Equal((short)4, linhas[1].Painel1);
            Assert.Equal((short)5, linhas[1].Painel2);
            // O Tipo 2 anexou a sua própria linha (nada a mesclar antes dele).
            Assert.Equal((short)6, linhas[2].Painel1);
            Assert.False(linhas[2].TemPonta2);
            // O Tipo 3 veio depois e também é linha própria, só de destino.
            Assert.Equal((short)7, linhas[3].Painel2);
            Assert.False(linhas[3].TemPonta1);
            Assert.Equal((short)0, linhas[3].Painel1);
        }

        [Fact]
        public void Tipo_dois_mescla_ignorando_a_caixa_do_cabo()
        {
            // O yHoU3hlYPo do original compara o Tag_Cabo com TextCompare (ignora
            // caixa): "cabo1" completa a linha aberta por "CABO1".
            List<PontoInterligacao> pontos = new List<PontoInterligacao>
            {
                new PontoInterligacao { Tipo = 2, Tag_Cabo = "CABO1", NumVeia = 1, Painel1 = 2, Pagina = "PAG-ORIG", TemPonta1 = true, X1 = 10.0, Y1 = 10.0 },
                new PontoInterligacao { Tipo = 2, Tag_Cabo = "cabo1", NumVeia = 1, Painel2 = 4, Pagina = "PAG-DEST", TemPonta2 = true, X2 = 20.0, Y2 = 20.0 },
            };

            List<TrechoInterligacao> linhas = InterligacaoProjetor.Mesclar(pontos, Contexto());

            Assert.Single(linhas);
            Assert.Equal((short)2, linhas[0].Painel1);
            Assert.Equal((short)4, linhas[0].Painel2);
        }

        [Fact]
        public void Tipo_tres_grava_ponta_um_vazia_no_banco()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);
                List<PontoInterligacao> pontos = new List<PontoInterligacao>
                {
                    new PontoInterligacao
                    {
                        Tipo = 3, Tag_Cabo = "CABO3", NumVeia = 1, Painel2 = 4, Pagina = "PAG-DEST",
                        TemPonta2 = true, X2 = 20.0, Y2 = 20.0,
                    },
                };

                int gravados = new InterligacaoProjetor(store).Projetar(pontos, Contexto());
                Assert.Equal(1, gravados);

                Interligacao4Row linha = store.InterligacaoPorCabo("CABO3")[0];
                Assert.Null(linha.Painel1);
                Assert.Null(linha.Pagina1);
                Assert.Equal((short)4, (short)linha.Painel2.Value);
                Assert.Equal("PAG-DEST", linha.Pagina2);
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
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
        public void Aplica_o_borne_mais_proximo_em_cada_ponta()
        {
            // A ponta 1 cai perto do borne da régua R1 (painel 2); a ponta 2,
            // perto do borne de R2/ALT (painel 4). Cada ponta casa com o seu.
            List<PontoBorne> bornes = new List<PontoBorne>
            {
                new PontoBorne { Layer = "PAG-ORIG", X = 10.1, Y = 10.0, Terminal = "1", Ordem = 1.0, IndiceRegua = 7, Tipo = 0, Painel = 2, NomeRegua = "R1", Handle = "AA" },
                new PontoBorne { Layer = "PAG-DEST", X = 20.0, Y = 20.2, Terminal = "2", Ordem = 2.0, IndiceRegua = 8, Tipo = 0, Painel = 4, NomeRegua = "R2", Alternativo = "ALT", Handle = "BB" },
                // Isca: mesmo layer/painel da ponta 1, mas fora da tolerância (0,5).
                new PontoBorne { Layer = "PAG-ORIG", X = 30.0, Y = 30.0, Terminal = "9", Ordem = 9.0, IndiceRegua = 99, Tipo = 0, Painel = 2, NomeRegua = "LONGE", Handle = "CC" },
            };

            List<PontoInterligacao> pontos = new List<PontoInterligacao>
            {
                new PontoInterligacao { Tipo = 2, Tag_Cabo = "CABO1", NumVeia = 1, Painel1 = 2, Pagina = "PAG-ORIG", TemPonta1 = true, X1 = 10.0, Y1 = 10.0 },
                new PontoInterligacao { Tipo = 2, Tag_Cabo = "CABO1", NumVeia = 1, Painel2 = 4, Pagina = "PAG-DEST", TemPonta2 = true, X2 = 20.0, Y2 = 20.0 },
            };

            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);
                InterligacaoProjetor projetor = new InterligacaoProjetor(store);
                int gravados = projetor.Projetar(pontos, Contexto(), bornes);
                Assert.Equal(1, gravados);

                Interligacao4Row linha = store.InterligacaoPorCabo("CABO1")[0];
                Assert.Equal("R1", linha.Tag1);
                Assert.Null(linha.Alternativo1);
                Assert.Equal("R1", linha.NRegua1);
                Assert.Equal("1", linha.Terminal1);
                Assert.Equal(1.0, linha.TerminalNum1.Value);
                Assert.Equal(0L, linha.TipoBorne1.Value);
                Assert.Equal(7L, linha.IndexModelo1.Value);
                Assert.Equal("AA", linha.Handle1);
                // O casamento carimba o DWG ativo e o documento local na ponta.
                Assert.Equal(1L, linha.DWG1.Value);
                Assert.Equal("LOCAL-A", linha.Documento1);
                Assert.Equal(string.Empty, linha.Posicao1);

                Assert.Equal("R2/ALT", linha.Tag2);
                Assert.Equal("ALT", linha.Alternativo2);
                Assert.Equal("R2", linha.NRegua2);
                Assert.Equal("2", linha.Terminal2);
                Assert.Equal(2.0, linha.TerminalNum2.Value);
                Assert.Equal(8L, linha.IndexModelo2.Value);
                Assert.Equal("BB", linha.Handle2);
                Assert.Equal(1L, linha.DWG2.Value);
                Assert.Equal("LOCAL-A", linha.Documento2);
                Assert.Equal(string.Empty, linha.Posicao2);
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }

        [Fact]
        public void Sem_borne_proximo_as_colunas_da_ponta_ficam_nulas()
        {
            List<PontoBorne> bornes = new List<PontoBorne>
            {
                new PontoBorne { Layer = "PAG-ORIG", X = 99.0, Y = 99.0, Terminal = "1", IndiceRegua = 7, Painel = 2, NomeRegua = "R1" },
            };

            List<PontoInterligacao> pontos = new List<PontoInterligacao>
            {
                new PontoInterligacao { Tipo = 1, Tag_Cabo = "CABO1", NumVeia = 1, Painel1 = 2, Pagina = "PAG-ORIG", TemPonta1 = true, X1 = 10.0, Y1 = 10.0, TemPonta2 = true, X2 = 20.0, Y2 = 20.0 },
            };

            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);
                new InterligacaoProjetor(store).Projetar(pontos, Contexto(), bornes);

                Interligacao4Row linha = store.InterligacaoPorCabo("CABO1")[0];
                Assert.Null(linha.Tag1);
                Assert.Null(linha.Terminal1);
                Assert.Null(linha.TerminalNum1);
                Assert.Null(linha.Tag2);
                Assert.Null(linha.Handle2);
                // Sem borne, o DWG/documento da ponta saem nulos (dado ausente é
                // melhor que dado inventado); a posição é vazia, como no original.
                Assert.Null(linha.DWG1);
                Assert.Null(linha.Documento1);
                Assert.Null(linha.DWG2);
                Assert.Null(linha.Documento2);
                Assert.Equal(string.Empty, linha.Posicao1);
                Assert.Equal(string.Empty, linha.Posicao2);
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
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

using System.Collections.Generic;
using Positron.Contract;
using Positron.Data.Fiacao;
using Positron.Data.Layout;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// A coluna <c>Pagina</c> montada pelo switch <c>Conf.incluirColuna</c> do
    /// original (0..2 layer cru, 3..5 alternativo, 6 com cruzamento).
    /// </summary>
    public class ColunaPaginaTests
    {
        private static PaginaMatrix Matriz()
        {
            return PaginaMatrix.Ler(new List<PaginaDesenho>
            {
                new PaginaDesenho { Pagina = "12", Alternativo = "P12" },
                new PaginaDesenho { Pagina = "13", Alternativo = "" },
            });
        }

        [Theory]
        [InlineData(0)]
        [InlineData(2)]
        public void Caso_cru_devolve_o_layer(int coluna)
        {
            Assert.Equal("12", new ColunaPagina(Matriz(), coluna, "-").Para("12"));
        }

        [Fact]
        public void Caso_3_a_5_devolve_o_alternativo()
        {
            ColunaPagina coluna = new ColunaPagina(Matriz(), 4, "-");

            Assert.Equal("P12", coluna.Para("12"));
            // Sem alternativo, o BuscaAlternativo(false) devolve o próprio layer.
            Assert.Equal("13", coluna.Para("13"));
            // Layer fora da matriz: mesma regra.
            Assert.Equal("99", coluna.Para("99"));
        }

        [Fact]
        public void Caso_6_poe_o_layer_entre_parenteses_e_o_cruzamento()
        {
            ColunaPagina coluna = new ColunaPagina(Matriz(), 6, "-");

            Assert.Equal("(12)-P12", coluna.Para("12"));
            // Sem alternativo o separador não entra.
            Assert.Equal("(13)", coluna.Para("13"));
            Assert.Equal("(99)", coluna.Para("99"));
        }

        [Fact]
        public void Layer_vazio_nao_vira_parenteses()
        {
            // As reservas de borne entram com Pagina vazia.
            Assert.Equal("", new ColunaPagina(Matriz(), 6, "-").Para(""));
            Assert.Equal("", ColunaPagina.Crua.Para(null));
        }

        [Fact]
        public void Fiacao_grava_a_pagina_montada_quando_ela_vem()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);
                store.InserirFiacao(new List<PontoFiacao>
                {
                    new PontoFiacao
                    {
                        Dwg = 1, Revisao = "R0", Painel = 1, Potencial = 5,
                        Layer = "12", Pagina = "(12)-P12",
                    },
                    new PontoFiacao
                    {
                        Dwg = 1, Revisao = "R0", Painel = 1, Potencial = 6,
                        Layer = "13",
                    },
                });

                IReadOnlyList<FiacaoRow> linhas = store.FiacaoDaRevisao(1, "R0");
                Assert.Equal(2, linhas.Count);
                Assert.Equal("(12)-P12", linhas[0].Pagina);
                // Sem página montada, cai no layer (o caso 0..2).
                Assert.Equal("13", linhas[1].Pagina);
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }
    }
}

using System.Collections.Generic;
using Positron.Data.Layout;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// A matriz de páginas do desenho (<c>Pagina.CarregaPaginas</c>): quais layers
    /// são páginas, o <c>BuscaAlternativo</c> e a regra de página ausente do
    /// <c>VERIF</c>.
    /// </summary>
    public class PaginaMatrixTests
    {
        [Theory]
        [InlineData("12", true)]
        [InlineData("12A", true)]
        [InlineData("1B", true)]
        [InlineData("1.5", true)]
        [InlineData("0", false)]
        [InlineData("A1", false)]
        [InlineData("PAG1", false)]
        [InlineData("1a", false)]
        [InlineData("", false)]
        [InlineData("  ", false)]
        public void Layer_valido_segue_a_regra_do_original(string pagina, bool esperado)
        {
            Assert.Equal(esperado, PaginaMatrix.LayerValido(pagina));
        }

        [Fact]
        public void Busca_alternativo_cai_no_proprio_layer_quando_vazio()
        {
            PaginaMatrix matriz = PaginaMatrix.Ler(new List<PaginaDesenho>
            {
                new PaginaDesenho { Pagina = "12", Unidade = "UC1", Alternativo = "P12" },
                new PaginaDesenho { Pagina = "13", Unidade = "UC1", Alternativo = "" },
            });

            Assert.Equal("P12", matriz.BuscaAlternativo("12", false));
            Assert.Equal("P12", matriz.BuscaAlternativo("12", true));

            // Sem alternativo: o próprio layer, ou vazio quando `bretornaVazio`.
            Assert.Equal("13", matriz.BuscaAlternativo("13", false));
            Assert.Equal("", matriz.BuscaAlternativo("13", true));

            // Layer fora da matriz: mesma regra do original.
            Assert.Equal("99", matriz.BuscaAlternativo("99", false));
            Assert.Equal("", matriz.BuscaAlternativo("99", true));
        }

        [Fact]
        public void Aponta_pagina_gravada_que_nao_esta_no_desenho()
        {
            PaginaMatrix matriz = PaginaMatrix.Ler(new List<PaginaDesenho>
            {
                new PaginaDesenho { Pagina = "12" },
            });

            List<string> paginas = new List<string> { "12", "99", "99", null, " " };
            List<Problema> problemas = VerificadorProjeto.VerificarPaginasAusentes(paginas, matriz);

            Problema problema = Assert.Single(problemas);
            Assert.Equal(AreaVerificacao.Desenho, problema.Area);
            Assert.Equal(TipoProblema.PaginaAusente, problema.Tipo);
            Assert.Equal("99", problema.Identificador);
        }

        [Fact]
        public void Matriz_completa_nao_aponta_nada()
        {
            PaginaMatrix matriz = PaginaMatrix.Ler(new List<PaginaDesenho>
            {
                new PaginaDesenho { Pagina = "12" },
            });

            Assert.Empty(VerificadorProjeto.VerificarPaginasAusentes(new List<string> { "12" }, matriz));
        }
    }
}

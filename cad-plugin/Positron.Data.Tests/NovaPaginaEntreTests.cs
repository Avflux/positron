using Positron.Data.Paginas;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// A fatia 3 da frente 10: a página **entre** duas (o <c>calculaNovaPagina</c> do reverso).
    /// As expectativas saem da aritmética do próprio original, ramo a ramo.
    /// </summary>
    public class NovaPaginaEntreTests
    {
        [Fact]
        public void Entre_duas_numericas_vizinhas_nasce_a_letra_A()
        {
            // ant=1, post=2, passo=1: cabe a "1A".
            PaginaCalculada pagina = NovaPaginaEntre.Calcular("1", "2", 1);

            Assert.Equal(1, pagina.PgNum);
            Assert.Equal("A", pagina.PgAlfa);
            Assert.Equal("1A", pagina.Pagina);
        }

        [Fact]
        public void Com_espaco_a_pagina_e_o_proximo_numero()
        {
            // ant=1, post=5, passo=1: 5 esta longe, entao a nova e a "2".
            PaginaCalculada pagina = NovaPaginaEntre.Calcular("1", "5", 1);

            Assert.Equal(2, pagina.PgNum);
            Assert.Equal("", pagina.PgAlfa);
            Assert.Equal("2", pagina.Pagina);
        }

        [Fact]
        public void Sem_posterior_o_sentinela_e_o_fim()
        {
            // O posterior vazio vale "1000000" (o fim), como no original. E a "Nova Pagina".
            PaginaCalculada pagina = NovaPaginaEntre.Calcular("24", "", 1);

            Assert.Equal(25, pagina.PgNum);
            Assert.Equal("25", pagina.Pagina);
        }

        [Fact]
        public void O_passo_do_caderno_e_respeitado()
        {
            // ant=1, post=100, passo=10: num2-num4 = 99 > 10, entao num4 + passo = 11.
            PaginaCalculada pagina = NovaPaginaEntre.Calcular("1", "100", 10);

            Assert.Equal(11, pagina.PgNum);
            Assert.Equal("11", pagina.Pagina);
        }

        [Fact]
        public void Com_alfanumericas_o_ramo_segue_o_original()
        {
            // ant="1A" (letra 65), post="1B" (letra 66): o ramo !num/!num cai no num5 = 0.
            PaginaCalculada pagina = NovaPaginaEntre.Calcular("1A", "1B", 1);

            Assert.Equal(0, pagina.PgNum);
            Assert.Equal("B", pagina.PgAlfa);
            Assert.Equal("0B", pagina.Pagina);
        }
    }
}

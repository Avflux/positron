using System.Collections.Generic;
using Positron.Data.Paginas;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// A fatia 4 da frente 10: o sufixo do <c>RENPAGA</c> e a renomeação em lote (o
    /// <c>renumerarPaginasLote</c> do reverso).
    /// </summary>
    public class RenumeracaoDePaginasTests
    {
        [Fact]
        public void O_sufixo_tem_de_ser_um_caractere_alfanumerico_maiusculo()
        {
            Assert.True(PaginasDoCaderno.SufixoValido("A"));
            Assert.True(PaginasDoCaderno.SufixoValido("Z"));
            Assert.True(PaginasDoCaderno.SufixoValido("7"));

            // O original recusa mais de um caractere e a minúscula (o Asc vai só até 90).
            Assert.False(PaginasDoCaderno.SufixoValido("a"));
            Assert.False(PaginasDoCaderno.SufixoValido("AB"));
            Assert.False(PaginasDoCaderno.SufixoValido(""));
            Assert.False(PaginasDoCaderno.SufixoValido(null));
        }

        [Fact]
        public void A_renomeacao_acrescenta_o_sufixo_a_cada_pagina()
        {
            List<string> paginas = new List<string> { "1", "2A", "489" };

            IReadOnlyList<string> novas = PaginasDoCaderno.Renomear(paginas, "B");

            Assert.Equal(3, novas.Count);
            Assert.Equal("1B", novas[0]);
            Assert.Equal("2AB", novas[1]);
            Assert.Equal("489B", novas[2]);
        }

        [Fact]
        public void Sem_sufixo_valido_nao_ha_renomeacao()
        {
            Assert.Empty(PaginasDoCaderno.Renomear(new List<string> { "1" }, "ab"));
            Assert.Empty(PaginasDoCaderno.Renomear(null, "A"));
        }
    }
}

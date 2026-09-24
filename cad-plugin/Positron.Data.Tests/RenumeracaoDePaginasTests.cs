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
            List<string> paginas = new List<string> { "1", "2", "489" };

            IReadOnlyList<string> novas = PaginasDoCaderno.Renomear(paginas, "B");

            Assert.Equal(3, novas.Count);
            Assert.Equal("1B", novas[0]);
            Assert.Equal("2B", novas[1]);
            Assert.Equal("489B", novas[2]);
        }

        [Fact]
        public void Com_pagina_alfabetica_o_lote_inteiro_e_recusado()
        {
            // A guarda do `RENPAGA` (`Correcao.cs:3283`): qualquer página não numérica derruba o lote
            // inteiro. Sem ela a segunda passada geraria `2A` + `B` = `2AB`, que o `LayerValido` já
            // não aceita como página — a página sairia do caderno.
            Assert.True(PaginasDoCaderno.TodasNumericas(new List<string> { "1", "2", "489" }));
            Assert.False(PaginasDoCaderno.TodasNumericas(new List<string> { "1", "2A" }));
            Assert.False(PaginasDoCaderno.TodasNumericas(null));

            Assert.Empty(PaginasDoCaderno.Renomear(new List<string> { "1", "2A", "489" }, "B"));
        }

        [Fact]
        public void A_primeira_pagina_tambem_e_renomeada_ao_contrario_do_corpo_do_original()
        {
            // O corpo do `RENPAGA` (`Correcao.cs:3273`) monta o lote com
            // `For j = 2 To UBound(mPaginas, 2)` sobre um `mPaginas` que começa no índice 1
            // (`Pagina.cs`, `CarregaPaginas`): a PRIMEIRA página da tabela de layers não é renomeada.
            // É um off-by-one do original e o recoder não o reproduz — este teste existe para que a
            // diferença seja uma decisão, e não um acidente.
            IReadOnlyList<string> novas = PaginasDoCaderno.Renomear(new List<string> { "1", "2", "3" }, "A");

            Assert.Equal(new[] { "1A", "2A", "3A" }, novas);
        }

        [Fact]
        public void Sem_sufixo_valido_nao_ha_renomeacao()
        {
            Assert.Empty(PaginasDoCaderno.Renomear(new List<string> { "1" }, "ab"));
            Assert.Empty(PaginasDoCaderno.Renomear(null, "A"));
        }
    }
}

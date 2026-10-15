using System.Collections.Generic;
using Positron.Data.Paginas;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// A fatia 2 da frente 10 (páginas/caderno): o nome da página pelo layer e as buscas na lista.
    /// </summary>
    public class PaginasDoCadernoTests
    {
        [Fact]
        public void O_layer_e_pagina_valida_quando_e_numero_positivo()
        {
            Assert.True(PaginasDoCaderno.LayerValido("1"));
            Assert.True(PaginasDoCaderno.LayerValido("489"));

            // Zero e negativo não são páginas.
            Assert.False(PaginasDoCaderno.LayerValido("0"));
            Assert.False(PaginasDoCaderno.LayerValido("-1"));
        }

        [Fact]
        public void O_layer_com_letra_so_vale_com_maiuscula()
        {
            Assert.True(PaginasDoCaderno.LayerValido("10A"));
            Assert.True(PaginasDoCaderno.LayerValido("10Z"));
            Assert.True(PaginasDoCaderno.LayerValido("10 9"));

            // Minúscula não passa (o Asc do original vai só até 'Z').
            Assert.False(PaginasDoCaderno.LayerValido("10a"));
            Assert.False(PaginasDoCaderno.LayerValido("A"));
            Assert.False(PaginasDoCaderno.LayerValido("X10"));
            Assert.False(PaginasDoCaderno.LayerValido(""));
            Assert.False(PaginasDoCaderno.LayerValido(null));
        }

        [Fact]
        public void O_numero_da_pagina_tira_os_zeros_a_esquerda()
        {
            Assert.Equal("12", PaginasDoCaderno.MontaNumeroPagina("0012", 0));
            Assert.Equal("12", PaginasDoCaderno.MontaNumeroPagina("12", 0));
            // Só zeros: o original tira todos (não sobra nem o "0").
            Assert.Equal("", PaginasDoCaderno.MontaNumeroPagina("000", 0));
            Assert.Equal("10A", PaginasDoCaderno.MontaNumeroPagina("0010A", 0));
        }

        [Fact]
        public void Com_largura_fixa_o_numero_e_completado_com_zeros()
        {
            // Largura 4: "12" vira "0012"; "10A" ganha **dois** zeros (um pela largura, outro pela letra).
            Assert.Equal("0012", PaginasDoCaderno.MontaNumeroPagina("12", 4));
            Assert.Equal("0010A", PaginasDoCaderno.MontaNumeroPagina("10A", 4));

            // O que já tem o tamanho (ou é numérico e maior) fica como está.
            Assert.Equal("1234", PaginasDoCaderno.MontaNumeroPagina("1234", 4));
            Assert.Equal("12345", PaginasDoCaderno.MontaNumeroPagina("12345", 4));
        }

        [Fact]
        public void As_buscas_na_lista_de_paginas()
        {
            List<PaginaDoCaderno> paginas = new List<PaginaDoCaderno>
            {
                new PaginaDoCaderno { Nome = "1", Alternativo = "ENTRADA" },
                new PaginaDoCaderno { Nome = "2", Alternativo = "" },
                new PaginaDoCaderno { Nome = "3", Alternativo = "SAIDA" },
            };

            // O índice é 1-based, como a matriz do original.
            Assert.Equal(2, PaginasDoCaderno.Indice(paginas, "2"));
            Assert.Equal(0, PaginasDoCaderno.Indice(paginas, "9"));
            Assert.Equal(2, PaginasDoCaderno.Indice(paginas, "2"));

            Assert.Equal("3", PaginasDoCaderno.ProximaValida(paginas, "2"));
            Assert.Equal("", PaginasDoCaderno.ProximaValida(paginas, "3"));
            Assert.Equal("", PaginasDoCaderno.ProximaValida(paginas, "9"));

            Assert.Equal("ENTRADA", PaginasDoCaderno.Alternativo(paginas, "1", true));
            Assert.Equal("", PaginasDoCaderno.Alternativo(paginas, "2", true));

            // Sem querer vazio, o alternativo vazio devolve a própria página.
            Assert.Equal("2", PaginasDoCaderno.Alternativo(paginas, "2", false));
        }

        [Fact]
        public void A_proxima_valida_sobre_os_nomes_crus()
        {
            // O NOVAPAGINA usa esta sobre a lista de nomes que o PaginasDoDesenho devolve.
            List<string> paginas = new List<string> { "1", "2", "6", "10", "1000" };

            Assert.Equal("2", PaginasDoCaderno.ProximaValida(paginas, "1"));
            Assert.Equal("6", PaginasDoCaderno.ProximaValida(paginas, "2"));

            // Sem caixa, como as comparações do original.
            Assert.Equal("10", PaginasDoCaderno.ProximaValida(paginas, "6"));

            // A última (e o que não está) devolve vazio — o "fim" do calculaNovaPagina.
            Assert.Equal("", PaginasDoCaderno.ProximaValida(paginas, "1000"));
            Assert.Equal("", PaginasDoCaderno.ProximaValida(paginas, "99"));
            Assert.Equal("", PaginasDoCaderno.ProximaValida((IReadOnlyList<string>)null, "1"));
        }
    }
}

using Positron.Data.Paginas;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// A fatia 1 da frente 10 (páginas/caderno): as três contas do Pagina.cs do reverso —
    /// a numeração da página e o espaço entre duas.
    /// </summary>
    public class PaginaNumeradaTests
    {
        [Fact]
        public void A_pagina_numerica_vale_o_numero()
        {
            Assert.Equal(10.0, PaginaNumerada.Decimal("10"));
            Assert.Equal(1.0, PaginaNumerada.Decimal("1"));
            Assert.Equal(489.0, PaginaNumerada.Decimal("489"));
        }

        [Fact]
        public void A_pagina_com_letra_vale_o_numero_mais_a_letra_sobre_cem()
        {
            // 'A' = 65 -> 10 + 0,65 = 10,65; 'Z' = 90 -> 10,90.
            Assert.Equal(10.65, PaginaNumerada.Decimal("10A"), 5);
            Assert.Equal(10.90, PaginaNumerada.Decimal("10Z"), 5);
            Assert.Equal(1.66, PaginaNumerada.Decimal("1B"), 5);
        }

        [Fact]
        public void O_que_nao_tem_o_formato_do_original_vale_zero()
        {
            Assert.Equal(0.0, PaginaNumerada.Decimal("A"));
            Assert.Equal(0.0, PaginaNumerada.Decimal("1a"));
            Assert.Equal(0.0, PaginaNumerada.Decimal("X10"));
            Assert.Equal(0.0, PaginaNumerada.Decimal(""));
            Assert.Equal(0.0, PaginaNumerada.Decimal(null));
        }

        [Fact]
        public void O_espaco_numerico_conta_as_paginas_entre_as_duas()
        {
            // De "10" a "12" cabe a página 11.
            Assert.Equal(2, PaginaNumerada.EspacoNumerico("10", "12"));
            Assert.Equal(1, PaginaNumerada.EspacoNumerico("10", "11"));
            Assert.Equal(3, PaginaNumerada.EspacoNumerico("10", "13"));

            // Com o alfanumérico no início, o "+1" do original passa do fim: o espaço é 0.
            Assert.Equal(0, PaginaNumerada.EspacoNumerico("10A", "11"));
        }

        [Fact]
        public void O_espaco_alfanumerico_usa_a_aritmetica_de_27_por_numero()
        {
            // Mesmo número: de "10A" a "10C" cabem B (e a própria C, como no original).
            Assert.Equal(2, PaginaNumerada.EspacoAlfaNumerico("10A", "10C"));

            // De "10" (seca) a "11" (seca): as 26 letras de 10 = 27 posições.
            Assert.Equal(27, PaginaNumerada.EspacoAlfaNumerico("10", "11"));

            // De "10" a "12": as 26 letras de 10 mais as 26 de 11 mais a "12" = 54.
            Assert.Equal(54, PaginaNumerada.EspacoAlfaNumerico("10", "12"));
        }
    }
}

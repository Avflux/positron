using System.Collections.Generic;
using Positron.Data.Fiacao;
using Positron.Data.Paginas;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// Os títulos de uma página: o modelo (<see cref="TitulosDaPagina"/>) e o leitor do XData
    /// (<see cref="TituloDaPaginaXData.Ler"/>). A leitura/gravação no desenho é do adapter.
    /// </summary>
    public class TitulosDaPaginaTests
    {
        private static List<TypedXData> XData(int indice, string valor)
        {
            return new List<TypedXData>(TituloDaPaginaXData.ParaValores(indice, valor, "ana", "2026-10-12"));
        }

        [Fact]
        public void Le_o_indice_e_o_valor_do_xdata()
        {
            int indice;
            string valor;

            Assert.True(TituloDaPaginaXData.Ler(XData(3, "T3"), out indice, out valor));
            Assert.Equal(3, indice);
            Assert.Equal("T3", valor);
        }

        [Fact]
        public void Recusa_o_xdata_que_nao_e_titulo()
        {
            int indice;
            string valor;
            List<TypedXData> outro = new List<TypedXData>
            {
                new TypedXData(1001, "DiagLog"),
                new TypedXData(1000, "Formato"),
                new TypedXData(1070, 3),
                new TypedXData(1000, " "),
            };

            Assert.False(TituloDaPaginaXData.Ler(outro, out indice, out valor));
            Assert.False(TituloDaPaginaXData.Ler(null, out indice, out valor));
            Assert.False(TituloDaPaginaXData.Ler(new List<TypedXData>(), out indice, out valor));
        }

        [Fact]
        public void Os_quatro_titulos_ficam_completos()
        {
            TitulosDaPagina titulos = new TitulosDaPagina();

            titulos.Definir(1, "A");
            titulos.Definir(2, "B");
            Assert.False(titulos.Completos);

            titulos.Definir(3, "C");
            titulos.Definir(4, "D");
            Assert.True(titulos.Completos);
            Assert.Equal("A", titulos.Titulo1);
            Assert.Equal("D", titulos.De(4));
        }

        [Fact]
        public void Indice_fora_da_faixa_nao_entra()
        {
            TitulosDaPagina titulos = new TitulosDaPagina();

            titulos.Definir(5, "CONT");
            titulos.Definir(6, "FL");
            titulos.Definir(0, "nada");

            Assert.Equal(0, titulos.Quantos);
            Assert.Null(titulos.De(5));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void Captura_da_grade_preserva_o_ultimo_texto_mesmo_apos_quatro_indices(int indice)
        {
            TitulosDaPagina titulos = new TitulosDaPagina();
            for (int i = 1; i <= 4; i++) titulos.Definir(i, "original " + i);
            // restauraCampos captura todos os textos, não para quando Completos fica true.
            titulos.Definir(indice, "último TextString");
            Assert.Equal("último TextString", titulos.De(indice));
            Assert.Equal(4, titulos.Quantos);
            Assert.True(titulos.Completos);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(4)]
        public void Captura_vazia_substitui_o_titulo_antigo_na_restauracao(int indice)
        {
            TitulosDaPagina titulos = new TitulosDaPagina();
            titulos.Definir(indice, "antigo");
            titulos.Definir(indice, "");
            Assert.Equal("", titulos.De(indice));
            Assert.Equal(1, titulos.Quantos);
        }

        [Fact]
        public void O_mesmo_indice_nao_conta_duas_vezes()
        {
            // O TITULO4PAG e o PAINEL do formato tem o MESMO índice (4): o texto que
            // chegar depois sobrescreve o valor, mas o contador do original não dobra.
            TitulosDaPagina titulos = new TitulosDaPagina();

            titulos.Definir(4, "primeiro");
            titulos.Definir(4, "segundo");

            Assert.Equal(1, titulos.Quantos);
            Assert.Equal("segundo", titulos.Titulo4);
        }
    }
}

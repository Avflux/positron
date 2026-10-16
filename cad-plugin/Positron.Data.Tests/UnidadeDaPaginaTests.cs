using System.Collections.Generic;
using Positron.Data.Fiacao;
using Positron.Data.Paginas;
using Xunit;

namespace Positron.Data.Tests
{
    public class UnidadeDaPaginaTests
    {
        [Fact]
        public void Le_a_unidade_e_o_alternativo()
        {
            string unidade;
            string alternativo;
            Assert.True(UnidadeDaPaginaXData.Ler(
                UnidadeDaPaginaXData.ParaValores("U1", "A1"), out unidade, out alternativo));
            Assert.Equal("U1", unidade);
            Assert.Equal("A1", alternativo);
        }

        [Theory]
        [InlineData("  unidade com espaços  ", "UNIDADE COM ESPAÇOS")]
        [InlineData("  nome alternativo com mais de vinte caracteres  ", "NOME ALTERNATIVO COM MAIS DE VINTE CARACTERES")]
        [InlineData("", "")]
        [InlineData("   ", "")]
        [InlineData(null, "")]
        [InlineData("a  b", "A  B")]
        public void MenuNormalizaRespostaSemTruncar(string resposta, string esperado)
        {
            Assert.Equal(esperado, UnidadeDaPaginaXData.NormalizarRespostaDoMenu(resposta));
        }

        [Fact]
        public void Recusa_o_xdata_de_outra_marca()
        {
            string unidade;
            string alternativo;
            List<TypedXData> outro = new List<TypedXData>
            {
                new TypedXData(1001, "Eletron"),
                new TypedXData(1000, "TituloPagina"),
                new TypedXData(1000, "x"),
                new TypedXData(1000, "y"),
            };
            Assert.False(UnidadeDaPaginaXData.Ler(outro, out unidade, out alternativo));
            Assert.False(UnidadeDaPaginaXData.Ler(null, out unidade, out alternativo));
        }
    }
}

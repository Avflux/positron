using Positron.Data.Paginas;
using Xunit;

namespace Positron.Data.Tests
{
    public class LocalizacaoPorHandleTests
    {
        [Theory]
        [InlineData("1A", 0x1A)]
        [InlineData("1a", 0x1A)]
        [InlineData("0x2F0", 0x2F0)]
        [InlineData(" 2F0 ", 0x2F0)]
        public void LerHandle_le_o_hexadecimal_como_o_HandleToObject(string texto, long esperado)
        {
            Assert.Equal(esperado, LocalizacaoPorHandle.LerHandle(texto));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("XYZ")]
        [InlineData("1 2")]
        [InlineData("123456789ABCDEF01")]
        public void LerHandle_devolve_nulo_no_que_o_original_nao_acha(string texto)
        {
            Assert.Null(LocalizacaoPorHandle.LerHandle(texto));
        }

        [Fact]
        public void Janela_e_a_caixa_com_a_margem_nos_quatro_lados()
        {
            JanelaDeZoom janela = LocalizacaoPorHandle.Janela(10, 20, 30, 25, LocalizacaoPorHandle.MargemDoZoom);

            Assert.Equal(20, janela.CentroX, 9);
            Assert.Equal(22.5, janela.CentroY, 9);
            Assert.Equal(60, janela.Largura, 9);
            Assert.Equal(45, janela.Altura, 9);
        }

        [Fact]
        public void Janela_de_um_ponto_e_o_quadrado_da_margem()
        {
            JanelaDeZoom janela = LocalizacaoPorHandle.Janela(5, 5, 5, 5, 20);

            Assert.Equal(5, janela.CentroX, 9);
            Assert.Equal(5, janela.CentroY, 9);
            Assert.Equal(40, janela.Largura, 9);
            Assert.Equal(40, janela.Altura, 9);
        }
    }
}

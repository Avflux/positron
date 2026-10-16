using Positron.Data.Paginas;
using Xunit;

namespace Positron.Data.Tests
{
    public class EdicaoDaGradeDeTitulosTests
    {
        [Theory]
        [InlineData(0, "90", "novo", "90")]
        [InlineData(1, "antes", " novo ", " novo ")]
        [InlineData(5, "antes", "123456789012345678901234", "123456789012345678901234")]
        [InlineData(6, "antes", "123456789012345678901234", "12345678901234567890")]
        public void ColarProtegePaginaELimitaSoAlternativo(int coluna, string antes, string copiado, string esperado)
        {
            Assert.Equal(esperado, EdicaoDaGradeDeTitulos.Colar(coluna, antes, copiado));
        }

        [Theory]
        [InlineData(0, "90", "90")]
        [InlineData(1, "titulo", "")]
        [InlineData(6, "alternativo", "")]
        public void LimparNaoAlteraPagina(int coluna, string antes, string esperado)
        {
            Assert.Equal(esperado, EdicaoDaGradeDeTitulos.Limpar(coluna, antes));
        }

        [Theory]
        [InlineData(0, "90", "90", "91", "90")]
        [InlineData(1, "  PAINEL A  ", "A", "B", "PBINEL B")]
        [InlineData(1, "  PAINEL A  ", "a", "b", "  PAINEL A  ")]
        [InlineData(1, "texto", "", "x", "texto")]
        [InlineData(6, "a", "a", "123456789012345678901234", "12345678901234567890")]
        public void SubstituirDiferenciaCaixaETiraEspacosSoQuandoTroca(int coluna, string antes, string de, string para, string esperado)
        {
            Assert.Equal(esperado, EdicaoDaGradeDeTitulos.Substituir(coluna, antes, de, para));
        }
    }
}

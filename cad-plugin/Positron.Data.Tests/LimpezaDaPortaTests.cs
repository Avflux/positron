using Positron.Data.Correcoes;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// O <c>IndefineUmaPorta</c>/<c>LimpaPorta</c> (frente 2 do §7.6, cauda da rodada 87):
    /// o que acontece com cada atributo da porta que não está no dicionário.
    /// </summary>
    public class LimpezaDaPortaTests
    {
        [Fact]
        public void As_tags_protegidas_ficam_com_o_esvaziamento_inicial()
        {
            Assert.Equal(string.Empty, LimpezaDaPorta.ValorDoAtributoLimpo("NOME1", true, "?"));
            Assert.Equal(string.Empty, LimpezaDaPorta.ValorDoAtributoLimpo("NOME2", true, "?"));
            Assert.Equal(string.Empty, LimpezaDaPorta.ValorDoAtributoLimpo("ALTERNATIVO", true, "?"));
            Assert.Equal(string.Empty, LimpezaDaPorta.ValorDoAtributoLimpo("PAINEL", true, "?"));
            Assert.Equal(string.Empty, LimpezaDaPorta.ValorDoAtributoLimpo("MODELO", true, "?"));
            Assert.Equal(string.Empty, LimpezaDaPorta.ValorDoAtributoLimpo("FABRICANTE", true, "?"));

            // Sem o esvaziamento inicial, o original não mexe nelas.
            Assert.Null(LimpezaDaPorta.ValorDoAtributoLimpo("NOME1", false, "?"));
        }

        [Fact]
        public void As_tags_de_terminal_e_borne_recebem_o_caracter()
        {
            Assert.Equal("?", LimpezaDaPorta.ValorDoAtributoLimpo("T1", true, "?"));
            Assert.Equal("?", LimpezaDaPorta.ValorDoAtributoLimpo("B10", true, "?"));
            Assert.Equal("?", LimpezaDaPorta.ValorDoAtributoLimpo("t2", false, "?"));

            Assert.Equal(string.Empty, LimpezaDaPorta.ValorDoAtributoLimpo("TX", true, "?"));
            Assert.Equal(string.Empty, LimpezaDaPorta.ValorDoAtributoLimpo("X1", true, "?"));
        }

        [Fact]
        public void O_resto_e_esvaziado()
        {
            Assert.Equal(string.Empty, LimpezaDaPorta.ValorDoAtributoLimpo("EFC", true, "?"));
            Assert.Equal(string.Empty, LimpezaDaPorta.ValorDoAtributoLimpo("REGUA", true, "?"));
            Assert.Equal(string.Empty, LimpezaDaPorta.ValorDoAtributoLimpo("", true, "?"));
            Assert.Equal(string.Empty, LimpezaDaPorta.ValorDoAtributoLimpo(null, true, "?"));
        }

        [Fact]
        public void As_duas_consultas_de_tag()
        {
            Assert.True(LimpezaDaPorta.Protegida("painel"));
            Assert.False(LimpezaDaPorta.Protegida("T1"));
            Assert.True(LimpezaDaPorta.TerminalOuBorne("b3"));
            Assert.False(LimpezaDaPorta.TerminalOuBorne("B"));
            Assert.False(LimpezaDaPorta.TerminalOuBorne("NOME1"));
        }
    }
}

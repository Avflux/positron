using Positron.Data.Configuracao;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// O <c>switch</c> do <c>RECRIACABOS</c> (rodada 115): o caso <c>1</c> usa o Eletrosul, os
    /// demais o Eletron.
    /// </summary>
    public class LayoutDaInterligacaoTests
    {
        [Fact]
        public void So_o_layout_1_usa_o_eletrosul()
        {
            Assert.True(LayoutDaInterligacao.EhEletrosul(1));

            Assert.False(LayoutDaInterligacao.EhEletrosul(0));
            Assert.False(LayoutDaInterligacao.EhEletrosul(2));
            Assert.False(LayoutDaInterligacao.EhEletrosul(3));
        }
    }
}

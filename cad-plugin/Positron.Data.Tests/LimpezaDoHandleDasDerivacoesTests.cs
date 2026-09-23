using Positron.Data.Limpeza;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// O <c>Limpahandle</c> (frente 2 do §7.6): a regra do <c>limpaHandleSuperior</c> —
    /// só a derivação (tipo 3) tem o handle zerado.
    /// </summary>
    public class LimpezaDoHandleDasDerivacoesTests
    {
        [Fact]
        public void So_o_tipo_3_e_derivacao()
        {
            Assert.True(LimpezaDoHandleDasDerivacoes.EhDerivacao(3));
            Assert.False(LimpezaDoHandleDasDerivacoes.EhDerivacao(1));
            Assert.False(LimpezaDoHandleDasDerivacoes.EhDerivacao(2));
            Assert.False(LimpezaDoHandleDasDerivacoes.EhDerivacao(0));
        }

        [Fact]
        public void So_limpa_quando_ha_handle()
        {
            Assert.True(LimpezaDoHandleDasDerivacoes.PrecisaLimpar("1A2B"));
            Assert.False(LimpezaDoHandleDasDerivacoes.PrecisaLimpar(""));
            Assert.False(LimpezaDoHandleDasDerivacoes.PrecisaLimpar(null));
        }
    }
}

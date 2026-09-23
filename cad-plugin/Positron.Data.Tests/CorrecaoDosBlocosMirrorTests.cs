using Positron.Data.Correcoes;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// O <c>ApagaBlocosMirror</c> (frente 2 do §7.6): as três condições do original —
    /// algum XData, sem <c>DINTERLIG</c> e escala X negativa.
    /// </summary>
    public class CorrecaoDosBlocosMirrorTests
    {
        [Fact]
        public void Espelhado_sem_cabo_de_aranha_e_apagado()
        {
            Assert.True(CorrecaoDosBlocosMirror.PrecisaApagar(true, false, -1.0));
            Assert.True(CorrecaoDosBlocosMirror.PrecisaApagar(true, false, -2.0));
        }

        [Fact]
        public void O_cabo_de_aranha_fica()
        {
            Assert.False(CorrecaoDosBlocosMirror.PrecisaApagar(true, true, -1.0));
        }

        [Fact]
        public void Sem_XData_ou_sem_espelho_fica()
        {
            Assert.False(CorrecaoDosBlocosMirror.PrecisaApagar(false, false, -1.0));
            Assert.False(CorrecaoDosBlocosMirror.PrecisaApagar(true, false, 1.0));
            Assert.False(CorrecaoDosBlocosMirror.PrecisaApagar(true, false, 0.0));
        }
    }
}

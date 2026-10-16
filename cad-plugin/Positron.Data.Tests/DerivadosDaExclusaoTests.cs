using Positron.Data.Interligacao;
using Positron.Data.Paginas;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>A decisão pura do <c>clsApagar.ApagarDerivados</c> (ramo da polyline de interligação).</summary>
    public class DerivadosDaExclusaoTests
    {
        [Fact]
        public void Interligacao_tipo_2_leva_a_irma_pelo_handle()
        {
            InterligacaoXData ilig = new InterligacaoXData { Tipo = 2, Handle = "2A3F" };
            Assert.Equal("2A3F", DerivadosDaExclusao.HandleDaIrma(ilig));
        }

        [Fact]
        public void Handle_da_irma_vem_sem_espacos()
        {
            InterligacaoXData ilig = new InterligacaoXData { Tipo = 2, Handle = " 2A3F " };
            Assert.Equal("2A3F", DerivadosDaExclusao.HandleDaIrma(ilig));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(4)]
        public void Outros_tipos_nao_levam_a_irma(short tipo)
        {
            InterligacaoXData ilig = new InterligacaoXData { Tipo = tipo, Handle = "2A3F" };
            Assert.Null(DerivadosDaExclusao.HandleDaIrma(ilig));
        }

        [Fact]
        public void Tipo_2_sem_handle_ou_sem_interligacao_nao_apaga_nada()
        {
            Assert.Null(DerivadosDaExclusao.HandleDaIrma(new InterligacaoXData { Tipo = 2, Handle = "" }));
            Assert.Null(DerivadosDaExclusao.HandleDaIrma(new InterligacaoXData { Tipo = 2, Handle = null }));
            Assert.Null(DerivadosDaExclusao.HandleDaIrma(null));
        }

        [Fact]
        public void Rotulo_do_trecho_compara_sem_diferenciar_caixa()
        {
            Assert.True(DerivadosDaExclusao.RotuloDoTrecho("2a3f", "2A3F"));
            Assert.True(DerivadosDaExclusao.RotuloDoTrecho("2A3F", "2A3F"));
            Assert.False(DerivadosDaExclusao.RotuloDoTrecho("2A40", "2A3F"));
        }

        [Fact]
        public void Rotulo_ou_trecho_sem_handle_nunca_casa()
        {
            Assert.False(DerivadosDaExclusao.RotuloDoTrecho("", "2A3F"));
            Assert.False(DerivadosDaExclusao.RotuloDoTrecho("2A3F", null));
            Assert.False(DerivadosDaExclusao.RotuloDoTrecho(null, null));
        }
    }
}

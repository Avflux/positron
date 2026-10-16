using System.Collections.Generic;
using Positron.Data.Fiacao;
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

        private static List<TypedXData> Registro(string app, object tipo)
        {
            return new List<TypedXData> { new TypedXData(1001, app), new TypedXData(1000, tipo) };
        }

        [Theory]
        [InlineData("P")]
        [InlineData("A")]
        [InlineData("M")]
        [InlineData("E")]
        public void Tipo_do_dispositivo_e_o_campo_1_do_xdata_dispositivo(string tipo)
        {
            Assert.Equal(tipo, DerivadosDaExclusao.TipoDoDispositivo(Registro("DISPOSITIVO", tipo), null));
        }

        [Fact]
        public void Sem_dispositivo_o_importado_vira_I_e_sem_nenhum_e_vazio()
        {
            Assert.Equal("I", DerivadosDaExclusao.TipoDoDispositivo(null, Registro("IMPORTADO", "x")));
            Assert.Equal(string.Empty, DerivadosDaExclusao.TipoDoDispositivo(null, null));
        }

        [Fact]
        public void Dispositivo_prevalece_sobre_o_importado()
        {
            Assert.Equal("A", DerivadosDaExclusao.TipoDoDispositivo(Registro("DISPOSITIVO", "A"), Registro("IMPORTADO", "x")));
        }

        [Theory]
        [InlineData("INSERCAO", true)]
        [InlineData("insercaona", true)]
        [InlineData("InsercaoNF", true)]
        [InlineData("INSERCAOX", false)]
        [InlineData("TAG", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void Atributos_de_insercao(string tag, bool esperado)
        {
            Assert.Equal(esperado, DerivadosDaExclusao.AtributoDeInsercao(tag));
        }
    }
}

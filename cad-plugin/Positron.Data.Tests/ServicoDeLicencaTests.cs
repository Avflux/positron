using Positron.Data.Licenca;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// Encaixe de licença (Etapa 9): o provedor é plugável e o padrão autoriza. O
    /// original checava Rockey/ElecKey/Nuvem na carga do plugin; aqui o comando
    /// pergunta antes de rodar, e a decisão do provedor não muda nenhum comando.
    /// </summary>
    public class ServicoDeLicencaTests
    {
        [Fact]
        public void Padrao_autoriza_e_diz_que_e_desenvolvimento()
        {
            ServicoDeLicenca.UsarDesenvolvimento();

            ResultadoLicenca resultado = ServicoDeLicenca.Verificar();

            Assert.True(resultado.Autorizado);
            Assert.Contains("desenvolvimento", resultado.Mensagem);
        }

        [Fact]
        public void Provedor_que_nega_bloqueia_o_comando()
        {
            try
            {
                ServicoDeLicenca.Provedor = new LicencaNegada();

                ResultadoLicenca resultado = ServicoDeLicenca.Verificar();

                Assert.False(resultado.Autorizado);
                Assert.Equal("dongle ausente", resultado.Mensagem);
            }
            finally
            {
                ServicoDeLicenca.UsarDesenvolvimento();
            }
        }

        [Fact]
        public void Provedor_que_estoura_vira_negativa_sem_derrubar()
        {
            try
            {
                ServicoDeLicenca.Provedor = new LicencaQuebrada();

                ResultadoLicenca resultado = ServicoDeLicenca.Verificar();

                Assert.False(resultado.Autorizado);
                Assert.Contains("falha ao verificar", resultado.Mensagem);
            }
            finally
            {
                ServicoDeLicenca.UsarDesenvolvimento();
            }
        }

        [Fact]
        public void Provedor_nulo_volta_para_desenvolvimento()
        {
            ServicoDeLicenca.Provedor = null;

            Assert.True(ServicoDeLicenca.Verificar().Autorizado);
        }

        private sealed class LicencaNegada : ILicenca
        {
            public ResultadoLicenca Verificar()
            {
                return ResultadoLicenca.Negado("dongle ausente");
            }
        }

        private sealed class LicencaQuebrada : ILicenca
        {
            public ResultadoLicenca Verificar()
            {
                throw new System.InvalidOperationException("sem rede");
            }
        }
    }
}

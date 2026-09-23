using System.Collections.Generic;
using Positron.Data.Fiacao;
using Positron.Data.Limpeza;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// O <c>LimpaTextosLPCopiados</c> (frente 2 do §7.6): a regra do XData <c>TextoLP</c>
    /// e a marca única que o <c>LimpaXData</c> grava.
    /// </summary>
    public class LimpezaTextosLPCopiadosTests
    {
        [Fact]
        public void MText_abaixo_do_topo_sai()
        {
            Assert.True(LimpezaDoDesenho.ApagarXDataTextoLP(true, true, 10.0, 5.0));
        }

        [Fact]
        public void MText_no_topo_ou_acima_fica()
        {
            // A comparação do original é `< topo` (estrita).
            Assert.False(LimpezaDoDesenho.ApagarXDataTextoLP(true, true, 10.0, 10.0));
            Assert.False(LimpezaDoDesenho.ApagarXDataTextoLP(true, true, 10.0, 20.0));
        }

        [Fact]
        public void DBText_sai_mesmo_acima_do_topo()
        {
            // O ramo do DBText no original não olha o Y.
            Assert.True(LimpezaDoDesenho.ApagarXDataTextoLP(false, true, 10.0, 20.0));
            Assert.True(LimpezaDoDesenho.ApagarXDataTextoLP(false, true, 10.0, 0.0));
        }

        [Fact]
        public void Sem_o_XData_nao_sai()
        {
            Assert.False(LimpezaDoDesenho.ApagarXDataTextoLP(true, false, 10.0, 0.0));
            Assert.False(LimpezaDoDesenho.ApagarXDataTextoLP(false, false, 10.0, 20.0));
        }

        [Fact]
        public void A_marca_unica_tem_so_o_app_name()
        {
            IReadOnlyList<TypedXData> marca = LimpezaDoDesenho.MarcaUnica(LimpezaDoDesenho.AppNameTextoLP);

            Assert.Single(marca);
            Assert.Equal(1001, marca[0].Codigo);
            Assert.Equal("TextoLP", marca[0].Valor);

            // O `apagaXDataTerceiros` usa a mesma gravação.
            Assert.Single(LimpezaDoDesenho.XDataDeTerceirosSubstituido());
            Assert.Equal(LimpezaDoDesenho.XDataTerceiros, LimpezaDoDesenho.XDataDeTerceirosSubstituido()[0].Valor);
        }
    }
}

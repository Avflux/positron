using Positron.Data.Correcoes;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// O <c>ApagaERROS</c> (passo 2 do <c>RESTPROJ</c>, rodada 113): a marca do XData
    /// <c>ERRO</c> — a mesma regra que o <c>clsPortas</c> usa com a marca <c>PORTAS</c>.
    /// </summary>
    public class EntidadesDeErroTests
    {
        [Fact]
        public void A_marca_e_o_primeiro_valor_sem_caixa()
        {
            Assert.True(EntidadesDeErro.EhDeErro("ERRO"));
            Assert.True(EntidadesDeErro.EhDeErro("erro"));
            Assert.True(EntidadesDeErro.EhMarca("ErRo", "ERRO"));

            Assert.False(EntidadesDeErro.EhDeErro("PORTAS"));
            Assert.False(EntidadesDeErro.EhDeErro(""));
            Assert.False(EntidadesDeErro.EhDeErro(null));
        }

        [Fact]
        public void A_mesma_regra_serve_para_a_marca_das_portas()
        {
            Assert.True(EntidadesDeErro.EhMarca("PORTAS", "portas"));
            Assert.False(EntidadesDeErro.EhMarca("ERRO", "PORTAS"));
            Assert.False(EntidadesDeErro.EhMarca(null, "PORTAS"));
        }
    }
}

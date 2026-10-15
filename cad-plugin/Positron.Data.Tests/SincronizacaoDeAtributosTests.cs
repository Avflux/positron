using System.Collections.Generic;
using Positron.Data.Paginas;
using Xunit;

namespace Positron.Data.Tests
{
    public class SincronizacaoDeAtributosTests
    {
        [Fact]
        public void Referencia_que_ja_casa_nao_gera_plano()
        {
            PlanoDeSincronizacao plano = SincronizacaoDeAtributos.Calcular(
                new List<string> { "REV0", "DESC0", "DATA0" },
                new List<string> { "REV0", "DATA0", "DESC0" });

            Assert.True(plano.Vazio);
            Assert.Empty(plano.Acrescentar);
            Assert.Empty(plano.Remover);
        }

        [Fact]
        public void Acrescenta_o_que_falta_na_referencia()
        {
            PlanoDeSincronizacao plano = SincronizacaoDeAtributos.Calcular(
                new List<string> { "REV0", "DESC0", "DATA0" },
                new List<string> { "REV0" });

            Assert.False(plano.Vazio);
            Assert.Equal(new[] { "DESC0", "DATA0" }, plano.Acrescentar);
            Assert.Empty(plano.Remover);
        }

        [Fact]
        public void Remove_o_que_sobra_na_referencia()
        {
            PlanoDeSincronizacao plano = SincronizacaoDeAtributos.Calcular(
                new List<string> { "REV0" },
                new List<string> { "REV0", "ANTIGO" });

            Assert.Equal(new[] { "ANTIGO" }, plano.Remover);
            Assert.Empty(plano.Acrescentar);
        }

        [Fact]
        public void A_comparacao_das_tags_e_sem_caixa()
        {
            PlanoDeSincronizacao plano = SincronizacaoDeAtributos.Calcular(
                new List<string> { "rev0", "desc0" },
                new List<string> { "REV0", "DESC0" });

            Assert.True(plano.Vazio);
        }

        [Fact]
        public void Listas_nulas_ou_vazias_nao_estouram()
        {
            PlanoDeSincronizacao semNada = SincronizacaoDeAtributos.Calcular(null, null);
            Assert.True(semNada.Vazio);

            PlanoDeSincronizacao definicaoSo = SincronizacaoDeAtributos.Calcular(new List<string> { "REV0" }, null);
            Assert.Equal(new[] { "REV0" }, definicaoSo.Acrescentar);
            Assert.Empty(definicaoSo.Remover);

            PlanoDeSincronizacao referenciaSo = SincronizacaoDeAtributos.Calcular(null, new List<string> { "REV0" });
            Assert.Equal(new[] { "REV0" }, referenciaSo.Remover);
            Assert.Empty(referenciaSo.Acrescentar);
        }
    }
}

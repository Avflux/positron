using System.Collections.Generic;
using Positron.Data.Bornes;
using Xunit;

namespace Positron.Data.Tests
{
    public class PontosDeLigacaoTests
    {
        [Fact]
        public void Circulo_da_os_quatro_quadrantes_na_ordem_do_original()
        {
            IReadOnlyList<double[]> pontos = PontosDeLigacao.DoCirculo(0.0, 0.0, 1.0);

            Assert.Equal(4, pontos.Count);
            Assert.Equal(new[] { 1.0, 0.0 }, pontos[0]);   // +X
            Assert.Equal(new[] { -1.0, 0.0 }, pontos[1]);  // -X
            Assert.Equal(new[] { 0.0, 1.0 }, pontos[2]);   // +Y
            Assert.Equal(new[] { 0.0, -1.0 }, pontos[3]);  // -Y
        }

        [Fact]
        public void Circulo_deslocado_e_sem_centro_na_origem()
        {
            // Como nos blocos reais: o borne é o círculo (0,0) r=1 e o fio chega
            // na borda — com um centro fora da origem os quadrantes acompanham.
            IReadOnlyList<double[]> pontos = PontosDeLigacao.DoCirculo(2.5, -3.0, 0.5);

            Assert.Equal(new[] { 3.0, -3.0 }, pontos[0]);
            Assert.Equal(new[] { 2.0, -3.0 }, pontos[1]);
            Assert.Equal(new[] { 2.5, -2.5 }, pontos[2]);
            Assert.Equal(new[] { 2.5, -3.5 }, pontos[3]);
        }

        [Fact]
        public void Extensoes_do_circulo_dao_a_bounding_box()
        {
            double[] extensoes = PontosDeLigacao.ExtensoesDoCirculo(0.0, 0.0, 1.0);
            Assert.Equal(new[] { -1.0, -1.0, 1.0, 1.0 }, extensoes);
        }
    }
}

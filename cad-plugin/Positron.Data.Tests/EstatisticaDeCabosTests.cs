using System.Collections.Generic;
using System.Linq;
using Positron.Contract;
using Positron.Data.Interligacao;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>A conta do <c>frmEstatisticaDeCabos</c> (<c>LeTodosOsCabosEmUso</c> + <c>Hpgk6bJ1Ce</c>).</summary>
    public class EstatisticaDeCabosTests
    {
        private static CabosRow Cabo(string tag, string formacao, string funcao, string trajeto, double? comprimento)
        {
            return new CabosRow { Tag = tag, Formacao = formacao, Funcao = funcao, Trajeto = trajeto, Comprimento = comprimento };
        }

        private static VeiasRow Veia(string tag, bool uso)
        {
            return new VeiasRow { Tag = tag, Uso = uso };
        }

        [Fact]
        public void SoEntraCaboComVeiaEmUso()
        {
            List<CabosRow> cabos = new List<CabosRow>
            {
                Cabo("C1", "3x2,5", "ALIM", "BANDEJA A", 10.0),
                Cabo("C2", "3x2,5", "ALIM", "BANDEJA A", 20.0),
            };
            List<VeiasRow> veias = new List<VeiasRow> { Veia("C1", true), Veia("C2", false) };

            IReadOnlyList<LinhaEstatisticaCabos> linhas = EstatisticaDeCabos.Calcular(cabos, veias, AgrupamentoDeCabos.Formacao);

            LinhaEstatisticaCabos unica = Assert.Single(linhas);
            Assert.Equal(1, unica.Quantidade);
            Assert.Equal(10.0, unica.Comprimento);
        }

        [Fact]
        public void CaboComVariasVeiasEmUsoContaUmaVez()
        {
            List<CabosRow> cabos = new List<CabosRow> { Cabo("C1", "4x6", "ALIM", "T1", 7.5) };
            List<VeiasRow> veias = new List<VeiasRow> { Veia("C1", true), Veia("C1", true), Veia("C1", true) };

            IReadOnlyList<LinhaEstatisticaCabos> linhas = EstatisticaDeCabos.Calcular(cabos, veias, AgrupamentoDeCabos.Formacao);

            LinhaEstatisticaCabos unica = Assert.Single(linhas);
            Assert.Equal(1, unica.Quantidade);
            Assert.Equal(7.5, unica.Comprimento);
        }

        [Fact]
        public void SomaQuantidadeEComprimentoPorGrupo()
        {
            List<CabosRow> cabos = new List<CabosRow>
            {
                Cabo("C1", "3x2,5", "ALIM", "T1", 10.0),
                Cabo("C2", "3x2,5", "COMANDO", "T1", 4.0),
                Cabo("C3", "2x4", "ALIM", "T2", 6.0),
            };
            List<VeiasRow> veias = new List<VeiasRow> { Veia("C1", true), Veia("C2", true), Veia("C3", true) };

            IReadOnlyList<LinhaEstatisticaCabos> linhas = EstatisticaDeCabos.Calcular(cabos, veias, AgrupamentoDeCabos.Formacao);

            Assert.Equal(2, linhas.Count);
            Assert.Equal("2x4", linhas[0].Nome);
            Assert.Equal(1, linhas[0].Quantidade);
            Assert.Equal(6.0, linhas[0].Comprimento);
            Assert.Equal("3x2,5", linhas[1].Nome);
            Assert.Equal(2, linhas[1].Quantidade);
            Assert.Equal(14.0, linhas[1].Comprimento);
        }

        [Fact]
        public void GrupoVazioNaoEntra()
        {
            List<CabosRow> cabos = new List<CabosRow>
            {
                Cabo("C1", "", "ALIM", "T1", 10.0),
                Cabo("C2", null, "ALIM", "T1", 5.0),
                Cabo("C3", "3x2,5", "ALIM", "T1", 2.0),
            };
            List<VeiasRow> veias = new List<VeiasRow> { Veia("C1", true), Veia("C2", true), Veia("C3", true) };

            IReadOnlyList<LinhaEstatisticaCabos> linhas = EstatisticaDeCabos.Calcular(cabos, veias, AgrupamentoDeCabos.Formacao);

            LinhaEstatisticaCabos unica = Assert.Single(linhas);
            Assert.Equal("3x2,5", unica.Nome);
        }

        [Fact]
        public void AgrupaPorFuncaoETrajeto()
        {
            List<CabosRow> cabos = new List<CabosRow>
            {
                Cabo("C1", "3x2,5", "ALIM", "BANDEJA", 3.0),
                Cabo("C2", "3x2,5", "COMANDO", "BANDEJA", 4.0),
            };
            List<VeiasRow> veias = new List<VeiasRow> { Veia("C1", true), Veia("C2", true) };

            IReadOnlyList<LinhaEstatisticaCabos> porFuncao = EstatisticaDeCabos.Calcular(cabos, veias, AgrupamentoDeCabos.Funcao);
            IReadOnlyList<LinhaEstatisticaCabos> porTrajeto = EstatisticaDeCabos.Calcular(cabos, veias, AgrupamentoDeCabos.Trajeto);

            Assert.Equal(new[] { "ALIM", "COMANDO" }, porFuncao.Select(linha => linha.Nome).ToArray());
            LinhaEstatisticaCabos trajeto = Assert.Single(porTrajeto);
            Assert.Equal("BANDEJA", trajeto.Nome);
            Assert.Equal(2, trajeto.Quantidade);
            Assert.Equal(7.0, trajeto.Comprimento);
        }

        [Fact]
        public void AgrupamentoNaoDiferenciaMaiusculas()
        {
            List<CabosRow> cabos = new List<CabosRow>
            {
                Cabo("C1", "3X2,5", "ALIM", "T1", 1.0),
                Cabo("C2", "3x2,5", "ALIM", "T1", 2.0),
            };
            List<VeiasRow> veias = new List<VeiasRow> { Veia("C1", true), Veia("C2", true) };

            IReadOnlyList<LinhaEstatisticaCabos> linhas = EstatisticaDeCabos.Calcular(cabos, veias, AgrupamentoDeCabos.Formacao);

            LinhaEstatisticaCabos unica = Assert.Single(linhas);
            Assert.Equal(2, unica.Quantidade);
            Assert.Equal(3.0, unica.Comprimento);
        }

        [Fact]
        public void SemVeiaEmUsoNaoHaLinhas()
        {
            List<CabosRow> cabos = new List<CabosRow> { Cabo("C1", "3x2,5", "ALIM", "T1", 10.0) };
            List<VeiasRow> veias = new List<VeiasRow> { Veia("C1", false) };

            IReadOnlyList<LinhaEstatisticaCabos> linhas = EstatisticaDeCabos.Calcular(cabos, veias, AgrupamentoDeCabos.Formacao);

            Assert.Empty(linhas);
        }
    }
}

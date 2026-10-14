using System.Collections.Generic;
using Positron.Data.Interligacao;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// O <c>ESTVL</c> (<c>frmEstimativaVeiasLivres</c>): as veias indefinidas do
    /// <c>carregaApenasAsVeiasIndefinidasDoCaderno</c> contadas por par de painéis pelo
    /// <c>clsInterligacao.Estimativa</c>.
    /// </summary>
    public class EstimativaDeVeiasLivresTests
    {
        private static readonly Dictionary<int, string> Nomes = new Dictionary<int, string>
        {
            { 1, "PN1" },
            { 2, "PN2" },
            { 3, "PN3" },
        };

        private static KeyValuePair<string, InterligacaoXData> Trecho(
            string handle, short tipo, short painel1, short painel2, int veia = InterligacaoXData.NumVeiaIndefinido, string apontado = "")
        {
            return new KeyValuePair<string, InterligacaoXData>(handle, new InterligacaoXData
            {
                Tipo = tipo,
                Tag_Cabo = "C1",
                NumVeia = veia,
                NomeVeia = "",
                Painel1 = painel1,
                Painel2 = painel2,
                Handle = apontado,
            });
        }

        [Fact]
        public void Conta_as_veias_indefinidas_por_par_ordenado()
        {
            var trechos = new List<KeyValuePair<string, InterligacaoXData>>
            {
                Trecho("A1", 1, 1, 2),
                Trecho("A2", 1, 2, 1),
                Trecho("A3", 1, 1, 2, veia: 4),
                Trecho("A4", 1, 3, 1),
            };

            IReadOnlyList<LinhaDaEstimativa> linhas = EstimativaDeVeiasLivres.Calcular(trechos, Nomes);

            // ordem do bubble sort: painel 1 decrescente -> (3,1) antes de (2,1) antes de (1,2)
            Assert.Equal(2, linhas.Count);
            Assert.Equal("PN1", linhas[0].Nome1);
            Assert.Equal("PN3", linhas[0].Nome2);
            Assert.Equal(1, linhas[0].Quantidade);
            Assert.Equal(1, linhas[1].Painel1);
            Assert.Equal(2, linhas[1].Painel2);
            Assert.Equal(2, linhas[1].Quantidade);
        }

        [Fact]
        public void Pula_a_ponta_so_com_o_painel_2_e_a_veia_com_painel_zero()
        {
            var trechos = new List<KeyValuePair<string, InterligacaoXData>>
            {
                Trecho("B1", 1, 0, 2),
                Trecho("B2", 3, 0, 2),
            };

            Assert.Empty(EstimativaDeVeiasLivres.Calcular(trechos, Nomes));
        }

        [Fact]
        public void No_tipo_2_o_painel_que_falta_vem_do_painel_2_da_polyline_apontada()
        {
            var trechos = new List<KeyValuePair<string, InterligacaoXData>>
            {
                Trecho("C1", 2, 1, 0, apontado: "C2"),
                Trecho("C2", 2, 0, 3, apontado: "C1"),
            };

            IReadOnlyList<LinhaDaEstimativa> linhas = EstimativaDeVeiasLivres.Calcular(trechos, Nomes);

            LinhaDaEstimativa linha = Assert.Single(linhas);
            Assert.Equal(1, linha.Painel1);
            Assert.Equal(3, linha.Painel2);
        }

        [Fact]
        public void Painel_fora_do_cadastro_vira_interrogacoes()
        {
            var trechos = new List<KeyValuePair<string, InterligacaoXData>> { Trecho("D1", 1, 1, 9) };

            LinhaDaEstimativa linha = Assert.Single(EstimativaDeVeiasLivres.Calcular(trechos, Nomes));
            Assert.Equal("???", linha.Nome2);
        }

        [Fact]
        public void O_texto_copiado_e_separado_por_tab_com_crlf()
        {
            string texto = EstimativaDeVeiasLivres.ParaAreaDeTransferencia(new[]
            {
                new[] { "PN1", "PN2", "2" },
                new[] { "PN1", "PN3", "1" },
            });

            Assert.Equal("PN1\tPN2\t2\r\nPN1\tPN3\t1\r\n", texto);
        }
    }
}

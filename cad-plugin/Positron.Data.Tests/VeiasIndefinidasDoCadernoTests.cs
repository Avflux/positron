using System.Collections.Generic;
using Positron.Data.Interligacao;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// O <c>PESQC</c> (<c>frmPesquisaVeiasIndefinidas</c>): o
    /// <c>carregaTodasAsVeiasIndefinidasDoCaderno</c> e a carga da grade.
    /// </summary>
    public class VeiasIndefinidasDoCadernoTests
    {
        private static readonly Dictionary<int, string> Nomes = new Dictionary<int, string>
        {
            { 1, "PN1" },
            { 2, "PN2" },
            { 3, "PN3" },
        };

        private static TrechoNoDesenho Trecho(
            string handle, string pagina, short tipo, short painel1, short painel2,
            double x = 0, double y = 0, int veia = InterligacaoXData.NumVeiaIndefinido, string apontado = "")
        {
            return new TrechoNoDesenho(handle, pagina, x, y, new InterligacaoXData
            {
                Tipo = tipo,
                Tag_Cabo = "",
                NumVeia = veia,
                NomeVeia = "",
                Painel1 = painel1,
                Painel2 = painel2,
                Handle = apontado,
            });
        }

        private static List<string> Handles(IReadOnlyList<VeiaIndefinida> veias)
        {
            List<string> handles = new List<string>();
            foreach (VeiaIndefinida veia in veias)
            {
                handles.Add(veia.Handle);
            }

            return handles;
        }

        [Fact]
        public void So_entram_as_veias_indefinidas_menos_a_ponta_so_com_o_painel_2()
        {
            var veias = VeiasIndefinidasDoCaderno.Carregar(new[]
            {
                Trecho("A", "1", 1, 1, 2),
                Trecho("B", "1", 1, 1, 2, veia: 3),
                Trecho("C", "1", 2, 0, 2),
                Trecho("D", "1", 1, 0, 0),
            });

            Assert.Equal(new[] { "A", "D" }, Handles(veias));
        }

        [Fact]
        public void Superposicao_so_com_o_painel_2_entra_com_ele_no_painel_1()
        {
            var veias = VeiasIndefinidasDoCaderno.Carregar(new[] { Trecho("A", "1", 3, 0, 2) });

            Assert.Single(veias);
            Assert.Equal(2, veias[0].Painel1);
            Assert.Equal(0, veias[0].Painel2);
        }

        [Fact]
        public void Tipo_2_le_o_painel_2_da_apontada_e_o_painel_1_troca_o_handle()
        {
            var veias = VeiasIndefinidasDoCaderno.Carregar(new[]
            {
                Trecho("A", "1", 2, 0, 0, apontado: "b"),
                Trecho("B", "1", 2, 1, 3, veia: 7),
            });

            Assert.Single(veias);
            Assert.Equal(3, veias[0].Painel1);
            Assert.Equal(3, veias[0].Painel2);
            Assert.Equal("B", veias[0].Handle);
        }

        [Fact]
        public void Tipo_2_so_sem_o_painel_2_mantem_o_proprio_handle()
        {
            var veias = VeiasIndefinidasDoCaderno.Carregar(new[]
            {
                Trecho("A", "1", 2, 1, 0, apontado: "B"),
                Trecho("B", "1", 2, 1, 3, veia: 7),
            });

            Assert.Equal(1, veias[0].Painel1);
            Assert.Equal(3, veias[0].Painel2);
            Assert.Equal("A", veias[0].Handle);
        }

        [Fact]
        public void Ordena_por_pagina_depois_y_decrescente_e_x_crescente()
        {
            var veias = VeiasIndefinidasDoCaderno.Carregar(new[]
            {
                Trecho("P10", "10", 1, 1, 2, x: 0, y: 0),
                Trecho("P2-baixo", "2", 1, 1, 2, x: 0, y: 10),
                Trecho("P2-alto-dir", "2", 1, 1, 2, x: 50, y: 90),
                Trecho("P2-alto-esq", "2", 1, 1, 2, x: 5, y: 90),
                Trecho("P2A", "2A", 1, 1, 2),
            });

            Assert.Equal(new[] { "P2-alto-esq", "P2-alto-dir", "P2-baixo", "P2A", "P10" }, Handles(veias));
        }

        [Fact]
        public void Posicao_arredonda_como_o_original()
        {
            var veias = VeiasIndefinidasDoCaderno.Carregar(new[] { Trecho("A", "1", 1, 1, 2, x: 2.5, y: 3.5) });

            Assert.Equal(2, veias[0].X);
            Assert.Equal(4, veias[0].Y);
        }

        [Fact]
        public void Grade_numera_de_1_poe_os_paineis_em_ordem_e_esconde_o_sem_cadastro()
        {
            var veias = VeiasIndefinidasDoCaderno.Carregar(new[]
            {
                Trecho("A", "1", 1, 3, 1, y: 10),
                Trecho("B", "1", 1, 9, 0),
            });

            var linhas = VeiasIndefinidasDoCaderno.LinhasDaGrade(veias, Nomes);

            Assert.Equal(2, linhas.Count);
            Assert.Equal(1, linhas[0].Indice);
            Assert.Equal("PN1", linhas[0].Origem);
            Assert.Equal("PN3", linhas[0].Destino);
            Assert.Equal("A", linhas[0].Handle);
            Assert.Equal(2, linhas[1].Indice);
            Assert.Equal(" ", linhas[1].Origem);
            Assert.Equal(" ", linhas[1].Destino);
        }

        [Fact]
        public void Sem_trechos_nao_ha_linhas()
        {
            Assert.Empty(VeiasIndefinidasDoCaderno.Carregar(null));
            Assert.Empty(VeiasIndefinidasDoCaderno.LinhasDaGrade(null, Nomes));
        }
    }
}

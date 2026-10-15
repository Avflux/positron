using System.Collections.Generic;
using System.Linq;
using Positron.Contract;
using Positron.Data.Interligacao;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// O <c>PESQCAB</c> (<c>frmPesquisaCabos</c>): a grade de cabos do catálogo <c>Veias</c> e as
    /// veias de um cabo com o <c>ClsCabos.OrdenaVeias</c>.
    /// </summary>
    public class PesquisaDeCabosTests
    {
        private static long chave;

        private static VeiasRow Veia(string tag, int arquivo, int indice, string nome = "", string pagina = "1", string handle = "")
        {
            return new VeiasRow
            {
                Tag = tag,
                Arquivo = arquivo,
                Indice = indice,
                Nome_Veia = nome,
                Pagina = pagina,
                Handle = handle,
                Chave = ++chave,
            };
        }

        [Fact]
        public void Cabos_deste_dwg_primeiro_depois_cabecalho_e_os_de_outros_cadernos()
        {
            var veias = new List<VeiasRow>
            {
                Veia("C2", 63, 1),
                Veia("C1", 63, 1),
                Veia("C1", 5, 2),
                Veia("X9", 5, 1),
                Veia("X1", 7, 1),
                Veia("LIVRE", 0, 1),
            };

            var cabos = PesquisaDeCabos.Cabos(veias, 63);

            Assert.Equal(new[] { "C1", "C2", PesquisaDeCabos.CabecalhoOutrosCadernos, "X1", "X9" }, cabos.Select(c => c.Tag).ToArray());
            Assert.False(cabos[0].OutroCaderno);
            Assert.True(cabos[2].Cabecalho);
            Assert.True(cabos[3].OutroCaderno);
        }

        [Fact]
        public void Sem_cabos_de_outros_cadernos_nao_ha_cabecalho()
        {
            var cabos = PesquisaDeCabos.Cabos(new List<VeiasRow> { Veia("C1", 63, 1), Veia("C1", 5, 2) }, 63);

            Assert.Equal(new[] { "C1" }, cabos.Select(c => c.Tag).ToArray());
        }

        [Fact]
        public void Veias_do_cabo_vem_de_todos_os_dwgs_com_o_handle_e_o_nome_ou_o_indice()
        {
            var veias = new List<VeiasRow>
            {
                Veia("C1", 63, 2, "", "8", "4DD25"),
                Veia("C1", 5, 1, "A", "3", "11"),
            };
            var cabo = PesquisaDeCabos.Cabos(veias, 63)[0];

            var linhas = PesquisaDeCabos.VeiasDoCabo(veias, null, cabo);

            Assert.Equal(new[] { "A", "2" }, linhas.Select(l => l.Texto).ToArray());
            Assert.Equal(new[] { "11", "4DD25" }, linhas.Select(l => l.Handle).ToArray());
        }

        [Fact]
        public void Cabo_de_outro_caderno_sem_handle_e_com_o_nome_do_dwg_na_pagina()
        {
            var veias = new List<VeiasRow>
            {
                Veia("C1", 63, 1),
                Veia("X1", 5, 1, "", "3", "AA"),
                Veia("X1", 6, 2, "", "4", "BB"),
            };
            var cabo = PesquisaDeCabos.Cabos(veias, 63).Single(c => c.Tag == "X1");

            var linhas = PesquisaDeCabos.VeiasDoCabo(veias, new Dictionary<int, string> { { 5, "CAD5" } }, cabo);

            Assert.Equal(new[] { "CAD5-3", "4" }, linhas.Select(l => l.Pagina).ToArray());
            Assert.All(linhas, l => Assert.Equal("", l.Handle));
        }

        [Fact]
        public void Cabecalho_nao_tem_veias()
        {
            var veias = new List<VeiasRow> { Veia("C1", 63, 1), Veia("X1", 5, 1) };
            var cabecalho = PesquisaDeCabos.Cabos(veias, 63).Single(c => c.Cabecalho);

            Assert.Empty(PesquisaDeCabos.VeiasDoCabo(veias, null, cabecalho));
        }

        [Fact]
        public void Pares_poem_a_blindagem_de_cada_par_depois_dele()
        {
            // cabo de pares: 1P1/2P1, blindagem -1; 3P2/4P2, blindagem -2; terra -99
            var veias = new List<VeiasRow>
            {
                Veia("C", 63, -99, "TERRA"),
                Veia("C", 63, -2, "B2"),
                Veia("C", 63, -1, "B1"),
                Veia("C", 63, 1, "1P1"),
                Veia("C", 63, 2, "2P1"),
                Veia("C", 63, 3, "3P2"),
                Veia("C", 63, 4, "4P2"),
            };
            var cabo = PesquisaDeCabos.Cabos(veias, 63)[0];

            var linhas = PesquisaDeCabos.VeiasDoCabo(veias, null, cabo);

            // -99 -> 0; -1 -> 2,1; -2 -> 4,1
            Assert.Equal(new[] { "TERRA", "1P1", "2P1", "B1", "3P2", "4P2", "B2" }, linhas.Select(l => l.Texto).ToArray());
            Assert.Equal(2.1, linhas[3].Ordem, 6);
            Assert.Equal(CorDaVeia.Blindagem, linhas[0].Cor);
        }

        [Fact]
        public void Ternas_multiplicam_por_tres()
        {
            var veias = new List<VeiasRow>
            {
                Veia("C", 63, -1, "B1"),
                Veia("C", 63, 1, "1T1"),
                Veia("C", 63, 2, "2T1"),
                Veia("C", 63, 3, "3T1"),
                Veia("C", 63, 4, "4T2"),
            };
            var linhas = PesquisaDeCabos.VeiasDoCabo(veias, null, PesquisaDeCabos.Cabos(veias, 63)[0]);

            Assert.Equal(new[] { "1T1", "2T1", "3T1", "B1", "4T2" }, linhas.Select(l => l.Texto).ToArray());
        }

        [Fact]
        public void Menor_que_menos_50_sobe_50_sem_agrupamento()
        {
            var veias = new List<VeiasRow>
            {
                Veia("C", 63, -52, "X"),
                Veia("C", 63, 1, "A"),
            };
            var linhas = PesquisaDeCabos.VeiasDoCabo(veias, null, PesquisaDeCabos.Cabos(veias, 63)[0]);

            Assert.Equal(new[] { "X", "A" }, linhas.Select(l => l.Texto).ToArray());
            Assert.Equal(-2.0, linhas[0].Ordem, 6);
        }

        [Fact]
        public void Cor_alterna_quando_a_primeira_letra_muda_ou_o_nome_e_numero()
        {
            var veias = new List<VeiasRow>
            {
                Veia("C", 63, 1, "A1"),
                Veia("C", 63, 2, "A2"),
                Veia("C", 63, 3, "B1"),
                Veia("C", 63, 4, ""),
                Veia("C", 63, 5, ""),
            };
            var linhas = PesquisaDeCabos.VeiasDoCabo(veias, null, PesquisaDeCabos.Cabos(veias, 63)[0]);

            Assert.Equal(
                new[] { CorDaVeia.Clara, CorDaVeia.Clara, CorDaVeia.Escura, CorDaVeia.Clara, CorDaVeia.Escura },
                linhas.Select(l => l.Cor).ToArray());
        }
    }
}

using System.Collections.Generic;
using Positron.Contract;
using Positron.Data.Relatorios;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// A **Lista de Veias** (rodada 159): a regra que a tela <c>frmRelatorio_Veias</c> (<c>LVEI</c>)
    /// mostra, com as duas pontas casadas por painel, o <c>NRegua</c> na frente da tag, o terminal
    /// indefinido, o aterramento preso às pontas originais do cabo e a veia de reserva caindo no trecho
    /// da veia seguinte.
    /// </summary>
    public class ListaDeVeiasTests
    {
        private static readonly IReadOnlyDictionary<int, string> Nomes =
            new Dictionary<int, string> { { 9, "PAINEL-9" }, { 503, "PNL-GGE" } };

        private static Cabos4Row Cabo(
            string tag,
            int pn1,
            int pn2,
            string formacao = "1x50",
            bool blindagem = false,
            int? cabos = null,
            long? aterrar = null,
            string funcao = "CIRC",
            double? comprimento = null)
        {
            return new Cabos4Row
            {
                Revisao = "R0",
                Tag = tag,
                Formacao = formacao,
                Blindagem = blindagem,
                Pn1 = pn1,
                Pn2 = pn2,
                Cabos = cabos,
                Aterrar = aterrar,
                Funcao = funcao,
                Comprimento = comprimento,
            };
        }

        private static Veias4Row Veia(string tag, int numero, string nome = null)
        {
            return new Veias4Row { Revisao = "R0", Tag = tag, Num_Veia = numero, Nome_Veia = nome };
        }

        private static Interligacao4Row Trecho(
            string tag,
            int numero,
            int painel1,
            string tag1,
            string nregua1,
            string terminal1,
            string pagina1,
            string documento1,
            int painel2,
            string tag2,
            string nregua2,
            string terminal2,
            string pagina2,
            string documento2)
        {
            return new Interligacao4Row
            {
                Revisao = "R0",
                Tag_Cabo = tag,
                Num_Veia = numero,
                Painel1 = painel1,
                Tag1 = tag1,
                NRegua1 = nregua1,
                Terminal1 = terminal1,
                Pagina1 = pagina1,
                Documento1 = documento1,
                Painel2 = painel2,
                Tag2 = tag2,
                NRegua2 = nregua2,
                Terminal2 = terminal2,
                Pagina2 = pagina2,
                Documento2 = documento2,
            };
        }

        [Fact]
        public void A_ponta_do_painel_escolhido_vira_a_ponta_1()
        {
            // O cabo tem o painel 503 na ponta 2: o relatório dele troca as pontas.
            List<LinhaDaListaDeVeias> linhas = ListaDeVeias.Montar(
                new[] { Cabo("8-CCE-001", 9, 503) },
                new[] { Veia("8-CCE-001", 1, "A") },
                new[] { Trecho("8-CCE-001", 1, 9, "X1", "R1", "1", "8", "RCD-A", 503, "X2", "R2", "2", "1000", "RCD-B") },
                Nomes,
                "R0",
                503);

            // A ponta 1 do relatório é sempre a do painel escolhido (o 503), seja ela o Pn1 ou o Pn2
            // do cabo.
            LinhaDaListaDeVeias linha = Assert.Single(linhas);
            Assert.Equal("PNL-GGE", linha.Painel1);
            Assert.Equal("PAINEL-9", linha.Painel2);
            Assert.Equal("R2", linha.Dispositivo1);
            Assert.Equal("2", linha.Borne1);
            Assert.Equal("R1", linha.Dispositivo2);
            Assert.Equal("1", linha.Borne2);
            Assert.Equal("RCD-A, RCD-B", linha.Documento);
            Assert.Equal("1000, 8", linha.Pagina);
        }

        [Fact]
        public void A_ponta_que_nao_casa_com_o_painel_fica_vazia()
        {
            // O trecho só tem a ponta 1 no painel 9; a outra ponta é de um painel que não é o 503.
            List<LinhaDaListaDeVeias> linhas = ListaDeVeias.Montar(
                new[] { Cabo("C1", 9, 503) },
                new[] { Veia("C1", 1) },
                new[] { Trecho("C1", 1, 9, "X1", "R1", "1", "8", "DOC", 77, "Y", "R9", "3", "9", "DOC2") },
                Nomes,
                "R0",
                9);

            // O nome das duas pontas vem do **cabo** (o `sPainel1`/`sPainel2` do original), e não do
            // trecho: o que o trecho sem painel deixa vazio são as colunas de dispositivo e borne.
            LinhaDaListaDeVeias linha = Assert.Single(linhas);
            Assert.Equal("PAINEL-9", linha.Painel1);
            Assert.Equal("PNL-GGE", linha.Painel2);
            Assert.Equal("R1", linha.Dispositivo1);
            Assert.Equal(string.Empty, linha.Dispositivo2);
            Assert.Equal(string.Empty, linha.Borne2);
            // A página do lado que não casa sai com o separador — é o texto do original, que só
            // junta quando o primeiro não é vazio.
            Assert.Equal("8, ", linha.Pagina);
        }

        [Fact]
        public void O_NRegua_manda_sobre_a_tag_e_o_terminal_indefinido_sai_com_o_caracter()
        {
            List<LinhaDaListaDeVeias> linhas = ListaDeVeias.Montar(
                new[] { Cabo("C1", 9, 9) },
                new[] { Veia("C1", 1) },
                new[] { Trecho("C1", 1, 9, "TAG-1", "ENTR 1", "0", "8", "DOC", 9, "TAG-2", string.Empty, string.Empty, "8", "DOC") },
                Nomes,
                "R0",
                9);

            LinhaDaListaDeVeias linha = Assert.Single(linhas);
            Assert.Equal("ENTR 1", linha.Dispositivo1);
            Assert.Equal("?", linha.Borne1);
            // O `NRegua` vazio cai na tag.
            Assert.Equal("TAG-2", linha.Dispositivo2);
            Assert.Equal("?", linha.Borne2);
            // As páginas iguais saem uma vez só.
            Assert.Equal("8", linha.Pagina);
        }

        [Fact]
        public void A_formacao_leva_a_blindagem_e_o_Nx_dos_cabos()
        {
            List<LinhaDaListaDeVeias> linhas = ListaDeVeias.Montar(
                new[] { Cabo("C1", 9, 9, "50", blindagem: true, cabos: 3) },
                new[] { Veia("C1", 1) },
                new[] { Trecho("C1", 1, 9, "X", "R", "1", "1", "D", 9, "Y", "R", "2", "1", "D") },
                Nomes,
                "R0",
                9);

            Assert.Equal("3x(50)", Assert.Single(linhas).Formacao);
        }

        [Fact]
        public void O_aterramento_fica_preso_as_pontas_originais_do_cabo()
        {
            // Aterrar 1 = fim do Pn1: com o painel 503 (que é o Pn2) a marca vai para a ponta 2.
            List<LinhaDaListaDeVeias> linhas = ListaDeVeias.Montar(
                new[] { Cabo("C1", 9, 503, aterrar: 1) },
                new[] { Veia("C1", 1) },
                new[] { Trecho("C1", 1, 9, "X", "R1", "1", "1", "D", 503, "Y", "R2", "2", "1", "D") },
                Nomes,
                "R0",
                503);

            LinhaDaListaDeVeias linha = Assert.Single(linhas);
            Assert.False(linha.Aterrar1);
            Assert.True(linha.Aterrar2);
        }

        [Fact]
        public void O_aterrar_3_marca_as_duas_pontas()
        {
            List<LinhaDaListaDeVeias> linhas = ListaDeVeias.Montar(
                new[] { Cabo("C1", 9, 503, aterrar: 3) },
                new[] { Veia("C1", 1) },
                new[] { Trecho("C1", 1, 9, "X", "R1", "1", "1", "D", 503, "Y", "R2", "2", "1", "D") },
                Nomes,
                "R0",
                9);

            LinhaDaListaDeVeias linha = Assert.Single(linhas);
            Assert.True(linha.Aterrar1);
            Assert.True(linha.Aterrar2);
        }

        [Fact]
        public void A_veia_de_reserva_cai_no_trecho_da_veia_seguinte()
        {
            // O original não **pula** a veia de reserva: ela recebe o trecho da seguinte e a seguinte
            // continua na lista com o próprio trecho — as duas linhas saem.
            List<LinhaDaListaDeVeias> linhas = ListaDeVeias.Montar(
                new[] { Cabo("C1", 9, 9) },
                new[] { Veia("C1", -1, "RESERVA"), Veia("C1", 1, "A") },
                new[] { Trecho("C1", 1, 9, "X", "R1", "1", "8", "D", 9, "Y", "R2", "2", "8", "D") },
                Nomes,
                "R0",
                9);

            Assert.Equal(2, linhas.Count);
            Assert.Equal("RESERVA", linhas[0].Veia);
            Assert.Equal("R1", linhas[0].Dispositivo1);
            Assert.Equal("A", linhas[1].Veia);
            Assert.Equal("R1", linhas[1].Dispositivo1);
        }

        [Fact]
        public void A_veia_sem_nome_sai_com_o_numero_e_o_comprimento_inteiro_sem_casas()
        {
            List<LinhaDaListaDeVeias> linhas = ListaDeVeias.Montar(
                new[] { Cabo("C1", 9, 9, comprimento: 12) },
                new[] { Veia("C1", 7) },
                new[] { Trecho("C1", 7, 9, "X", "R1", "1", "8", "D", 9, "Y", "R2", "2", "8", "D") },
                Nomes,
                "R0",
                9);

            LinhaDaListaDeVeias linha = Assert.Single(linhas);
            Assert.Equal("7", linha.Veia);
            Assert.Equal("12", linha.Comprimento);
            Assert.Equal("CIRC", linha.Funcao);
        }

        [Fact]
        public void O_cabo_de_outro_painel_e_as_veias_abaixo_de_51_saem()
        {
            List<LinhaDaListaDeVeias> linhas = ListaDeVeias.Montar(
                new[]
                {
                    Cabo("C1", 9, 9),
                    Cabo("C2", 77, 78),
                },
                new[] { Veia("C1", -51), Veia("C1", 1) },
                new[]
                {
                    Trecho("C1", -51, 9, "X", "R", "1", "1", "D", 9, "Y", "R", "2", "1", "D"),
                    Trecho("C1", 1, 9, "X", "R", "1", "1", "D", 9, "Y", "R", "2", "1", "D"),
                    Trecho("C2", 1, 77, "X", "R", "1", "1", "D", 78, "Y", "R", "2", "1", "D"),
                },
                Nomes,
                "R0",
                9);

            Assert.Single(linhas);
            Assert.Equal("C1", linhas[0].Tag);
        }

        [Fact]
        public void O_cabo_com_a_tag_repetida_entra_uma_vez()
        {
            List<Cabos4Row> cabos = new List<Cabos4Row> { Cabo("C1", 9, 9), Cabo("C1", 9, 9) };
            List<LinhaDaListaDeVeias> linhas = ListaDeVeias.Montar(
                cabos,
                new[] { Veia("C1", 1) },
                new[] { Trecho("C1", 1, 9, "X", "R", "1", "1", "D", 9, "Y", "R", "2", "1", "D") },
                Nomes,
                "R0",
                9);

            Assert.Single(linhas);
            Assert.Single(ListaDeVeias.CabosDoRelatorio(cabos, new[] { Veia("C1", 1) }, "R0", 9));
        }

        [Fact]
        public void O_total_de_cabos_conta_o_cabo_sem_trecho_mas_nao_o_sem_veia()
        {
            // O `qTotal` do original é o `lCabosUnico.Count`: os cabos que o CarregaVeias4 montou, e
            // não as linhas da grade — o cabo cujas veias não acham trecho entra na conta e não sai na
            // lista (medido na rodada 159: 42 cabos e 22 linhas no painel 503).
            List<Cabos4Row> cabos = new List<Cabos4Row> { Cabo("C1", 9, 9), Cabo("C2", 9, 9), Cabo("C3", 9, 9) };
            List<Veias4Row> veias = new List<Veias4Row> { Veia("C1", 1), Veia("C2", 1), Veia("C3", -51) };

            Assert.Equal(new[] { "C1", "C2" }, ListaDeVeias.CabosDoRelatorio(cabos, veias, "R0", 9));
        }

        [Fact]
        public void O_trecho_sem_painel_nao_vira_linha()
        {
            List<LinhaDaListaDeVeias> linhas = ListaDeVeias.Montar(
                new[] { Cabo("C1", 9, 9) },
                new[] { Veia("C1", 1) },
                new[] { Trecho("C1", 1, 0, "X", "R", "1", "1", "D", 0, "Y", "R", "2", "1", "D") },
                Nomes,
                "R0",
                9);

            Assert.Empty(linhas);
        }

        [Fact]
        public void Os_paineis_da_revisao_saem_sem_repeticao()
        {
            List<int> paineis = ListaDeVeias.Paineis(
                new[]
                {
                    Cabo("C1", 9, 503),
                    Cabo("C2", 503, 9),
                    Cabo("C3", 77, 78),
                },
                "R0");

            Assert.Equal(new[] { 9, 503, 77, 78 }, paineis);
        }
    }
}

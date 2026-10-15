using System.Collections.Generic;
using System.Linq;
using Positron.Data.Paginas;
using Xunit;

namespace Positron.Data.Tests
{
    public class PosicionamentoDeRevisoesTests
    {
        private static RevisaoCompletaDaPagina Revisao(string pagina, string revisao, string original, int posicao)
        {
            RevisaoCompletaDaPagina rev = new RevisaoCompletaDaPagina(
                pagina, revisao, "desc", "01/01/2026", "ANA", "BOB", "CARLOS", posicao);
            rev.RevisaoOriginal = original;
            return rev;
        }

        [Fact]
        public void Sem_alteracao_o_plano_atualiza_o_bloco_da_posicao()
        {
            PlanoDaRevisaoCompleta plano = PosicionamentoDeRevisoes.Calcular(
                Revisao("01", "R2", "R2", 2), new List<RevisaoCompletaDaPagina>(), 8);

            OperacaoDaRevisao operacao = Assert.Single(plano.Operacoes);
            Assert.False(plano.Estourou);
            Assert.Equal(TipoDaOperacaoDaRevisao.Atualizar, operacao.Tipo);
            Assert.Equal(2, operacao.Posicao);
        }

        [Fact]
        public void A_comparacao_com_a_revisao_original_e_sem_caixa()
        {
            // O Operators.CompareString(..., TextCompare: true) do original não diferencia caixa.
            PlanoDaRevisaoCompleta plano = PosicionamentoDeRevisoes.Calcular(
                Revisao("01", "r2", "R2", 2), new List<RevisaoCompletaDaPagina>(), 8);

            Assert.Equal(TipoDaOperacaoDaRevisao.Atualizar, Assert.Single(plano.Operacoes).Tipo);
        }

        [Fact]
        public void Revisao_alterada_com_espaco_entra_na_posicao_seguinte()
        {
            PlanoDaRevisaoCompleta plano = PosicionamentoDeRevisoes.Calcular(
                Revisao("01", "R3", "R2", 2), new List<RevisaoCompletaDaPagina>(), 8);

            OperacaoDaRevisao operacao = Assert.Single(plano.Operacoes);
            Assert.False(plano.Estourou);
            Assert.Equal(TipoDaOperacaoDaRevisao.Criar, operacao.Tipo);
            Assert.Equal(3, operacao.Posicao);
            Assert.Equal("R3", operacao.Dados.Revisao);
        }

        [Fact]
        public void Primeira_revisao_da_pagina_entra_na_posicao_um()
        {
            PlanoDaRevisaoCompleta plano = PosicionamentoDeRevisoes.Calcular(
                Revisao("01", "R0", string.Empty, 0), new List<RevisaoCompletaDaPagina>(), 8);

            OperacaoDaRevisao operacao = Assert.Single(plano.Operacoes);
            Assert.Equal(TipoDaOperacaoDaRevisao.Criar, operacao.Tipo);
            Assert.Equal(1, operacao.Posicao);
        }

        [Fact]
        public void Revisao_alterada_no_topo_desloca_todos_e_apaga_a_mais_antiga()
        {
            List<RevisaoCompletaDaPagina> existentes = new List<RevisaoCompletaDaPagina>
            {
                Revisao("01", "R1", "R1", 1),
                Revisao("01", "R2", "R2", 2),
                Revisao("01", "R3", "R3", 3),
            };

            PlanoDaRevisaoCompleta plano = PosicionamentoDeRevisoes.Calcular(
                Revisao("01", "R4", "R3", 3), existentes, 3);

            Assert.True(plano.Estourou);

            // Apaga as três posições atuais.
            Assert.Equal(new[] { 1, 2, 3 },
                plano.Operacoes.Where(o => o.Tipo == TipoDaOperacaoDaRevisao.Apagar)
                    .Select(o => o.Posicao).ToArray());

            // A posição 1 (a mais antiga) não volta; a 2 e a 3 descem para 1 e 2 com os dados antigos.
            OperacaoDaRevisao[] criadas = plano.Operacoes
                .Where(o => o.Tipo == TipoDaOperacaoDaRevisao.Criar).ToArray();
            Assert.Equal(new[] { 1, 2, 3 }, criadas.Select(o => o.Posicao).ToArray());
            Assert.Equal("R2", criadas[0].Dados.Revisao);
            Assert.Equal("R3", criadas[1].Dados.Revisao);
            Assert.Equal("R4", criadas[2].Dados.Revisao);
        }

        [Fact]
        public void Pagina_sem_revisao_nao_gera_operacao()
        {
            PlanoDaRevisaoCompleta plano = PosicionamentoDeRevisoes.Calcular(
                Revisao("01", "   ", string.Empty, 0), new List<RevisaoCompletaDaPagina>(), 8);

            Assert.True(plano.Vazio);
        }

        [Fact]
        public void Contar_posicoes_le_so_as_tags_de_revisao_do_layer()
        {
            List<TagDeAtributo> atributos = new List<TagDeAtributo>
            {
                new TagDeAtributo("REV0", "-1"),
                new TagDeAtributo("REV1", "-1"),
                new TagDeAtributo("DESC0", "-1"),
                new TagDeAtributo("DATA0", "-1"),
                new TagDeAtributo("REV0", "1"),
            };

            Assert.Equal(2, PosicionamentoDeRevisoes.ContarPosicoes(atributos, "-1"));
            Assert.Equal(1, PosicionamentoDeRevisoes.ContarPosicoes(atributos, "1"));
            Assert.Equal(0, PosicionamentoDeRevisoes.ContarPosicoes(atributos, "3"));
            Assert.Equal(0, PosicionamentoDeRevisoes.ContarPosicoes(null, "-1"));
        }

        [Fact]
        public void Tag_de_revisao_aceita_rev_e_rev0_a_rev7()
        {
            Assert.True(PosicionamentoDeRevisoes.EhTagDeRevisao("REV"));
            Assert.True(PosicionamentoDeRevisoes.EhTagDeRevisao("rev7"));
            Assert.False(PosicionamentoDeRevisoes.EhTagDeRevisao("REV8"));
            Assert.False(PosicionamentoDeRevisoes.EhTagDeRevisao("REVISAO"));
            Assert.False(PosicionamentoDeRevisoes.EhTagDeRevisao("DESC0"));
            Assert.False(PosicionamentoDeRevisoes.EhTagDeRevisao(null));
        }
    }
}

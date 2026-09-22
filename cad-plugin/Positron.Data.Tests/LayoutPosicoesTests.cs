using System;
using System.Collections.Generic;
using Positron.Contract;
using Positron.Data.Fiacao;
using Positron.Data.Layout;
using Xunit;

namespace Positron.Data.Tests
{
    public class LayoutPosicoesTests
    {
        private static TypedXData[] Xrecord(params string[] tags)
        {
            TypedXData[] valores = new TypedXData[tags.Length * LayoutPosicoes.ValoresPorPosicao];
            for (int i = 0; i < tags.Length; i++)
            {
                valores[i * LayoutPosicoes.ValoresPorPosicao] = new TypedXData(1000, tags[i]);
            }

            return valores;
        }

        [Fact]
        public void Interpreta_5_em_5_com_ordem_sequencial()
        {
            List<PosicaoLayout> posicoes = LayoutPosicoes.Interpretar(Xrecord("D1", "D2"), 2, "P");

            Assert.Equal(2, posicoes.Count);
            Assert.Equal("D1", posicoes[0].Tag);
            Assert.Equal(1, posicoes[0].Ordem);
            Assert.Equal(3, posicoes[0].PosicaoNum);
            Assert.Equal(2, posicoes[0].Painel);
            Assert.Equal("D2", posicoes[1].Tag);
            Assert.Equal(2, posicoes[1].Ordem);
        }

        [Fact]
        public void Posicao_C_vale_2()
        {
            List<PosicaoLayout> posicoes = LayoutPosicoes.Interpretar(Xrecord("X1"), 5, "C");
            Assert.Equal(2, Assert.Single(posicoes).PosicaoNum);
        }

        [Fact]
        public void Busca_por_painel_e_tag()
        {
            LayoutPosicoes tabela = LayoutPosicoes.Ler(LayoutPosicoes.Interpretar(Xrecord("D1"), 1, "P"));

            Assert.NotNull(tabela.Buscar(1, "D1"));
            Assert.Null(tabela.Buscar(2, "D1"));
            Assert.Null(tabela.Buscar(1, "ZZ"));
        }

        [Fact]
        public void Ordem_equipamento_e_o_indice_da_tag_no_layout()
        {
            // As tags do `P` vêm antes das do `C`, e o índice é o da lista concatenada
            // — o `BuscaOrdemEquipamento` do original.
            List<PosicaoLayout> posicoes = new List<PosicaoLayout>();
            posicoes.AddRange(LayoutPosicoes.Interpretar(Xrecord("D1", "D2", "D3"), 1, "P"));
            posicoes.AddRange(LayoutPosicoes.Interpretar(Xrecord("D4"), 1, "C"));

            LayoutPosicoes tabela = LayoutPosicoes.Ler(posicoes);

            Assert.Equal(0, tabela.OrdemEquipamento(1, "D1"));
            Assert.Equal(2, tabela.OrdemEquipamento(1, "D3"));
            Assert.Equal(3, tabela.OrdemEquipamento(1, "D4"));
        }

        [Fact]
        public void Ordem_equipamento_ausente_e_10000_e_a_busca_ignora_caixa()
        {
            LayoutPosicoes tabela = LayoutPosicoes.Ler(LayoutPosicoes.Interpretar(Xrecord("D1", "D2"), 1, "P"));

            Assert.Equal(LayoutPosicoes.OrdemEquipamentoAusente, tabela.OrdemEquipamento(1, "ZZ"));
            Assert.Equal(LayoutPosicoes.OrdemEquipamentoAusente, tabela.OrdemEquipamento(2, "D1"));
            Assert.Equal(LayoutPosicoes.OrdemEquipamentoAusente, tabela.OrdemEquipamento(1, null));

            // A lista dedupa por **ordinal** (o `List.Contains` do original), mas a
            // busca é sem diferenciar maiúsculas (`TextCompare: true`): duas grafias
            // ficam as duas na lista e a primeira responde.
            List<PosicaoLayout> posicoes = new List<PosicaoLayout>
            {
                new PosicaoLayout { Painel = 1, Tag = "D1", PosicaoNum = 3, Ordem = 1 },
                new PosicaoLayout { Painel = 1, Tag = "d1", PosicaoNum = 3, Ordem = 2 },
                new PosicaoLayout { Painel = 1, Tag = "D2", PosicaoNum = 3, Ordem = 3 },
            };

            LayoutPosicoes comDuasGrafias = LayoutPosicoes.Ler(posicoes);
            Assert.Equal(0, comDuasGrafias.OrdemEquipamento(1, "D1"));
            Assert.Equal(0, comDuasGrafias.OrdemEquipamento(1, "d1"));
            Assert.Equal(2, comDuasGrafias.OrdemEquipamento(1, "D2"));
        }

        [Fact]
        public void Ordem_equipamento_repetido_conta_uma_vez()
        {
            LayoutPosicoes tabela = LayoutPosicoes.Ler(new List<PosicaoLayout>
            {
                new PosicaoLayout { Painel = 1, Tag = "D1", PosicaoNum = 3, Ordem = 1 },
                new PosicaoLayout { Painel = 1, Tag = "D1", PosicaoNum = 3, Ordem = 2 },
                new PosicaoLayout { Painel = 1, Tag = "D2", PosicaoNum = 3, Ordem = 3 },
            });

            Assert.Equal(1, tabela.OrdemEquipamento(1, "D2"));
        }

        [Fact]
        public void Nao_borne_recebe_posicao_do_layout_na_ordenacao()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);
                FiacaoProjetor projetor = new FiacaoProjetor(store);

                // Dois não-bornes no mesmo potencial; o layout dá a ordem a cada
                // um. "D1" (ordem 1) tem que vir antes de "D2" (ordem 2).
                List<PontoFiacao> pontos = new List<PontoFiacao>
                {
                    new PontoFiacao { Painel = 1, Potencial = 4, Tag = "D2" },
                    new PontoFiacao { Painel = 1, Potencial = 4, Tag = "D1" },
                };

                LayoutPosicoes posicoes = LayoutPosicoes.Ler(new List<PosicaoLayout>
                {
                    new PosicaoLayout { Painel = 1, Tag = "D1", PosicaoNum = 3, Ordem = 1 },
                    new PosicaoLayout { Painel = 1, Tag = "D2", PosicaoNum = 3, Ordem = 2 },
                });

                projetor.Projetar(
                    pontos,
                    new ContextoProjecao { Dwg = 1, Criador = "ana", Data = DateTime.Now },
                    null,
                    posicoes);

                IReadOnlyList<FiacaoRow> linhas = store.FiacaoDoPainel(1);
                Assert.Equal(2, linhas.Count);
                Assert.Equal("D1", linhas[0].Tag);
                Assert.Equal(3L, linhas[0].PosicaoNum ?? 0);
                Assert.Equal(1L, linhas[0].Ordem ?? 0);
                Assert.Equal("D2", linhas[1].Tag);
                Assert.Equal(2L, linhas[1].Ordem ?? 0);
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }
    }
}

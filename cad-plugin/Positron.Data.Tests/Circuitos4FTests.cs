using System.Collections.Generic;
using Positron.Data.Fiacao;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// <c>Circuitos4F</c> — o <c>t6yXrlfi5w</c> do <c>frmCompilarFiacao</c>: um
    /// circuito por potencial, só nas conexões de <c>Tipo == 1</c> com nome.
    /// </summary>
    public class Circuitos4FTests
    {
        [Fact]
        public void Gera_um_circuito_por_potencial()
        {
            List<PontoFiacao> pontos = new List<PontoFiacao>
            {
                new PontoFiacao { Painel = 1, Potencial = 5, TipoConexao = 1, NomeCircuito = "C1" },
                // Mesmo potencial: o primeiro vence (o list.Contains do original).
                new PontoFiacao { Painel = 1, Potencial = 5, TipoConexao = 1, NomeCircuito = "C1-BIS" },
                // Tipo diferente de 1 não gera.
                new PontoFiacao { Painel = 1, Potencial = 6, TipoConexao = 2, NomeCircuito = "C2" },
                // Nome em branco não gera.
                new PontoFiacao { Painel = 1, Potencial = 7, TipoConexao = 1, NomeCircuito = "  " },
                // Painel fora de uso não gera.
                new PontoFiacao { Painel = 9, Potencial = 8, TipoConexao = 1, NomeCircuito = "C4" },
                new PontoFiacao { Painel = 1, Potencial = 9, TipoConexao = 1, NomeCircuito = "C5" },
            };

            List<Circuito4F> linhas = Circuitos4FGerador.Gerar(pontos, new List<int> { 1 });

            Assert.Equal(2, linhas.Count);
            Assert.Equal((short)1, linhas[0].Painel);
            Assert.Equal("C1", linhas[0].Circuito);
            Assert.Equal(5, linhas[0].Potencial);
            Assert.Equal("C5", linhas[1].Circuito);
            Assert.Equal(9, linhas[1].Potencial);
        }

        [Fact]
        public void Preserva_o_nome_cru_da_conexao()
        {
            List<PontoFiacao> pontos = new List<PontoFiacao>
            {
                new PontoFiacao { Painel = 1, Potencial = 3, TipoConexao = 1, NomeCircuito = " C1 " },
            };

            List<Circuito4F> linhas = Circuitos4FGerador.Gerar(pontos, new List<int> { 1 });

            // O original passa conex.Nome sem recortar; o Trim só decide se entra.
            Assert.Equal(" C1 ", Assert.Single(linhas).Circuito);
        }

        [Fact]
        public void Ponto_carrega_nome_e_tipo_da_conexao()
        {
            PontoFiacao ponto = PontoFiacao.DeConexao(new ConexaoXData
            {
                Painel = 1,
                Potencial = 4,
                Nome = "CIRC-4",
                Tipo = 3,
            });

            Assert.Equal("CIRC-4", ponto.NomeCircuito);
            Assert.Equal((short)3, ponto.TipoConexao);
        }

        [Fact]
        public void Gravar_duas_vezes_nao_duplica_e_lote_vazio_limpa_a_revisao()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);
                List<Circuito4F> linhas = new List<Circuito4F>
                {
                    new Circuito4F { Painel = 1, Circuito = "C1", Potencial = 5 },
                    new Circuito4F { Painel = 1, Circuito = "C2", Potencial = 6 },
                };

                store.InserirCircuitos(linhas, "R0", 1);
                Assert.Equal(2, store.CircuitosDaRevisao(1, "R0").Count);

                store.InserirCircuitos(linhas, "R0", 1);
                Assert.Equal(2, store.CircuitosDaRevisao(1, "R0").Count);

                store.InserirCircuitos(linhas, "R1", 1);
                store.InserirCircuitos(new List<Circuito4F>(), "R0", 1);
                Assert.Empty(store.CircuitosDaRevisao(1, "R0"));
                Assert.Equal(2, store.CircuitosDaRevisao(1, "R1").Count);
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }
    }
}

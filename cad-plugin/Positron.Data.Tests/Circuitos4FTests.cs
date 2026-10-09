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
            List<ConexaoFiacao> conexoes = new List<ConexaoFiacao>
            {
                new ConexaoFiacao { Painel = 1, Potencial = 5, Tipo = 1, Nome = "C1" },
                // Mesmo potencial: o primeiro vence (o list.Contains do original).
                new ConexaoFiacao { Painel = 1, Potencial = 5, Tipo = 1, Nome = "C1-BIS" },
                // Tipo diferente de 1 não gera.
                new ConexaoFiacao { Painel = 1, Potencial = 6, Tipo = 2, Nome = "C2" },
                // Nome em branco não gera.
                new ConexaoFiacao { Painel = 1, Potencial = 7, Tipo = 1, Nome = "  " },
                // Painel fora de uso não gera.
                new ConexaoFiacao { Painel = 9, Potencial = 8, Tipo = 1, Nome = "C4" },
                new ConexaoFiacao { Painel = 1, Potencial = 9, Tipo = 1, Nome = "C5" },
            };

            List<Circuito4F> linhas = Circuitos4FGerador.Gerar(conexoes, new List<int> { 1 });

            Assert.Equal(2, linhas.Count);
            Assert.Equal((short)1, linhas[0].Painel);
            Assert.Equal("C1", linhas[0].Circuito);
            Assert.Equal(5, linhas[0].Potencial);
            Assert.Equal("C5", linhas[1].Circuito);
            Assert.Equal(9, linhas[1].Potencial);
        }

        [Fact]
        public void Conexao_sem_ponto_de_fiacao_ainda_gera_circuito()
        {
            // Tipo 1 sem Disp1/Disp2 não gera ponto (PontosDaConexao), mas o
            // original varre as CONEXAO do desenho: o circuito sai. Regressão do
            // banco do produto (11 circuitos no DWG 63; 7 quando alimentado pelos
            // pontos).
            ConexaoXData semPonto = new ConexaoXData
            {
                Tipo = 1,
                Disp1 = false,
                Disp2 = false,
                Painel = 1,
                Potencial = 2059,
                Nome = "BARRA A",
            };

            Assert.False(PontosDaConexao.UsaPrimeiroVertice(semPonto));
            Assert.False(PontosDaConexao.UsaUltimoVertice(semPonto));

            List<Circuito4F> linhas = Circuitos4FGerador.Gerar(
                new List<ConexaoFiacao>
                {
                    new ConexaoFiacao { Painel = 1, Potencial = 2059, Tipo = 1, Nome = "BARRA A" },
                },
                new List<int> { 1 });

            Assert.Equal("BARRA A", Assert.Single(linhas).Circuito);
        }

        [Fact]
        public void Preserva_o_nome_cru_da_conexao()
        {
            List<ConexaoFiacao> conexoes = new List<ConexaoFiacao>
            {
                new ConexaoFiacao { Painel = 1, Potencial = 3, Tipo = 1, Nome = " C1 " },
            };

            List<Circuito4F> linhas = Circuitos4FGerador.Gerar(conexoes, new List<int> { 1 });

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

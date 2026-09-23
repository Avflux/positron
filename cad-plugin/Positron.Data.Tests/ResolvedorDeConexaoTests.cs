using Positron.Data.Correcoes;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// O <c>CorrigeHandleSuperior</c> (frente 2 do §7.6): o resolvedor por ponto
    /// (<c>verificaConexao</c>) — a janela de ±0.2, o tipo do vizinho e a comparação.
    /// </summary>
    public class ResolvedorDeConexaoTests
    {
        [Fact]
        public void A_janela_e_de_mais_ou_menos_02()
        {
            // Um alvo em (0,0)-(1,0) é tocado por um ponto em (1,0) e por (0.1, 0).
            Assert.True(ResolvedorDeConexao.JanelaToca(1.0, 0.0, 0.0, 0.0, 1.0, 0.0));
            Assert.True(ResolvedorDeConexao.JanelaToca(0.1, 0.0, 0.0, 0.0, 1.0, 0.0));

            // A 0.3 de distância já fica fora.
            Assert.False(ResolvedorDeConexao.JanelaToca(1.3, 0.0, 0.0, 0.0, 1.0, 0.0));
            Assert.False(ResolvedorDeConexao.JanelaToca(0.0, 0.3, 0.0, 0.0, 1.0, 0.0));
        }

        [Fact]
        public void O_tipo_do_vizinho_sai_do_jumper()
        {
            Assert.Equal("C", ResolvedorDeConexao.TipoDoVizinho(""));
            Assert.Equal("C", ResolvedorDeConexao.TipoDoVizinho(null));
            Assert.Equal("J", ResolvedorDeConexao.TipoDoVizinho("JUMPER"));
            Assert.Equal("J", ResolvedorDeConexao.TipoDoVizinho("jumper"));

            // Jumper com outro valor: o original não mexe no tipo.
            Assert.Null(ResolvedorDeConexao.TipoDoVizinho("X"));
        }

        [Fact]
        public void O_vizinho_precisa_ser_da_mesma_camada_e_nao_ser_ele_mesmo()
        {
            Assert.True(ResolvedorDeConexao.EhVizinho("12", "12", "AA", "BB"));

            // A comparação do handle também é sem caixa no original (`TextCompare`).
            Assert.False(ResolvedorDeConexao.EhVizinho("12", "12", "AA", "aa"));

            Assert.False(ResolvedorDeConexao.EhVizinho("13", "12", "AA", "BB"));
            Assert.False(ResolvedorDeConexao.EhVizinho("12", "12", "AA", "AA"));
        }

        [Fact]
        public void So_regrava_quando_algum_dos_tres_muda()
        {
            Assert.False(ResolvedorDeConexao.PrecisaAtualizar("A", "N", 5, "A", "N", 5));
            Assert.True(ResolvedorDeConexao.PrecisaAtualizar("", "N", 5, "A", "N", 5));
            Assert.True(ResolvedorDeConexao.PrecisaAtualizar("A", "", 5, "A", "N", 5));
            Assert.True(ResolvedorDeConexao.PrecisaAtualizar("A", "N", 5, "A", "N", 7));
        }
    }
}

using System.Collections.Generic;
using Positron.Data.Interface.Mapas;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// O plano dos painéis da barra pelo tipo do desenho (<c>Iniciar.cs:72-127</c>): os nove painéis do
    /// original, o quirk do último painel no tipo <c>V</c> e os tipos <c>D</c>/<c>A</c> com tudo
    /// desligado.
    /// </summary>
    public class LigacaoDosPaineisTests
    {
        /// <summary>Os nove painéis do <c>Ribbon.cs</c> (o mapa é o <c>BarraDoReverso</c>).</summary>
        private const int Paineis = 9;

        [Fact]
        public void No_desenho_do_eletron_todos_os_paineis_ficam_ligados()
        {
            IReadOnlyList<bool?> plano = LigacaoDosPaineis.Plano(LigacaoDosPaineis.TipoEletron, Paineis);

            Assert.Equal(Paineis, plano.Count);
            foreach (bool? painel in plano)
            {
                Assert.True(painel);
            }
        }

        [Fact]
        public void No_desenho_vazio_o_ultimo_painel_o_original_nao_toca()
        {
            // O laço do original vai do índice 2 até `count - 2`: o painel do índice 8 (o Help) fica
            // como estava — e como a criação o deixa ligado, sai ligado.
            IReadOnlyList<bool?> plano = LigacaoDosPaineis.Plano(LigacaoDosPaineis.TipoVazio, Paineis);

            Assert.True(plano[0]);
            Assert.True(plano[1]);
            for (int i = 2; i < Paineis - 1; i++)
            {
                Assert.False(plano[i]);
            }

            Assert.Null(plano[Paineis - 1]);
        }

        [Fact]
        public void Nos_desenhos_de_outros_produtos_nenhum_painel_fica_ligado()
        {
            foreach (string tipo in new[] { LigacaoDosPaineis.TipoDiagLog, LigacaoDosPaineis.TipoArqNet })
            {
                IReadOnlyList<bool?> plano = LigacaoDosPaineis.Plano(tipo, Paineis);
                foreach (bool? painel in plano)
                {
                    Assert.False(painel);
                }
            }
        }

        [Fact]
        public void Tipo_fora_dos_quatro_do_original_fica_com_a_barra_inerte()
        {
            // O `verificaTipoXData` só devolve E/D/A/V, mas um tipo imprevisto não pode ligar a barra.
            IReadOnlyList<bool?> plano = LigacaoDosPaineis.Plano("X", Paineis);

            foreach (bool? painel in plano)
            {
                Assert.False(painel);
            }
        }

        [Fact]
        public void A_comparacao_do_tipo_nao_diferencia_caixa()
        {
            // O original compara com `TextCompare` (o `e` de um tipo em minúscula liga a barra).
            IReadOnlyList<bool?> plano = LigacaoDosPaineis.Plano("e", Paineis);

            Assert.True(plano[0]);
            Assert.True(plano[Paineis - 1]);
        }

        [Fact]
        public void Sem_paineis_o_plano_e_vazio()
        {
            Assert.Empty(LigacaoDosPaineis.Plano(LigacaoDosPaineis.TipoEletron, 0));
        }

        [Fact]
        public void Com_um_painel_so_o_tipo_vazio_liga_ele_e_nao_toca_em_nada()
        {
            // O original acessaria `Panels[1]` sem existir (estouraria o `IniciarDWG`); aqui não há o
            // segundo painel para ligar, e o único fica intocado.
            IReadOnlyList<bool?> plano = LigacaoDosPaineis.Plano(LigacaoDosPaineis.TipoVazio, 1);

            Assert.Single(plano);
            Assert.Null(plano[0]);
        }
    }
}

using Positron.Data.Correcoes;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// As duas correções automáticas do <c>IniciarDWG</c> que não são comando nenhum do original — só
    /// rodam ali: o <c>correcaoTextosCircuitos</c> (<c>Correcao.cs:397</c>) e o <c>correcaoLines</c>
    /// (<c>Correcao.cs:480</c>).
    /// </summary>
    public class CorrecoesDeMigracaoTests
    {
        [Fact]
        public void So_o_texto_auxiliar_tipo_1_com_vertical_mode_1_e_corrigido()
        {
            Assert.True(CorrecaoDoTextoDeCircuito.PrecisaCorrigir(1, 1));
        }

        [Fact]
        public void Os_outros_tipos_do_auxconexao_nao_sao_mexidos()
        {
            // O `AUXCONEXAO` do circuito é o tipo 1; os 4/5/6 são os rótulos de seção e cor que o
            // `EDCON` regrava — o original não passa perto deles nesta correção.
            Assert.False(CorrecaoDoTextoDeCircuito.PrecisaCorrigir(4, 1));
            Assert.False(CorrecaoDoTextoDeCircuito.PrecisaCorrigir(5, 1));
            Assert.False(CorrecaoDoTextoDeCircuito.PrecisaCorrigir(6, 1));
        }

        [Fact]
        public void Do_tipo_1_so_o_modo_vertical_1_e_corrigido()
        {
            // O original testa `CInt(text.VerticalMode) = 1` — os outros modos (0, 2, 3) ficam.
            Assert.False(CorrecaoDoTextoDeCircuito.PrecisaCorrigir(1, 0));
            Assert.False(CorrecaoDoTextoDeCircuito.PrecisaCorrigir(1, 2));
            Assert.False(CorrecaoDoTextoDeCircuito.PrecisaCorrigir(1, 3));
        }

        [Fact]
        public void A_correcao_do_texto_volta_para_o_baseline()
        {
            Assert.Equal(1, CorrecaoDoTextoDeCircuito.VerticalModeCorrigido);
            Assert.Equal(0, CorrecaoDoTextoDeCircuito.VerticalModeAlinhado);
            Assert.Equal(1, CorrecaoDoTextoDeCircuito.TipoDoTextoDeCircuito);
        }

        [Fact]
        public void A_linha_com_conexao_e_limpa_pelo_conexao()
        {
            Assert.Equal(CorrecaoXDataDasLinhas.Conexao, CorrecaoXDataDasLinhas.QualLimpar(true, false));
        }

        [Fact]
        public void A_linha_sem_conexao_cai_no_interligacao()
        {
            Assert.Equal(CorrecaoXDataDasLinhas.Interligacao, CorrecaoXDataDasLinhas.QualLimpar(false, true));
        }

        [Fact]
        public void A_linha_com_os_dois_app_names_e_limpa_so_pelo_conexao()
        {
            // O `if/else` do original: com o `CONEXAO` presente, o `INTERLIGACAO` nem é procurado —
            // uma varredura tira o primeiro, a seguinte (a marca já não deixa) tiraria o outro.
            Assert.Equal(CorrecaoXDataDasLinhas.Conexao, CorrecaoXDataDasLinhas.QualLimpar(true, true));
        }

        [Fact]
        public void A_linha_sem_xdata_nenhum_nao_e_mexida()
        {
            Assert.Null(CorrecaoXDataDasLinhas.QualLimpar(false, false));
        }

        [Fact]
        public void Os_app_names_sao_os_do_xdata_das_conexoes()
        {
            // Estes nomes são os mesmos que os leitores de `CONEXAO`/`INTERLIGACAO` do recoder usam:
            // um erro de caixa aqui deixaria a linha sem o XData e o leitor achando que ela tem.
            Assert.Equal(Positron.Data.Fiacao.ConexaoXData.AppName, CorrecaoXDataDasLinhas.Conexao);
            Assert.Equal(Positron.Data.Interligacao.InterligacaoXData.AppName, CorrecaoXDataDasLinhas.Interligacao);
        }
    }
}

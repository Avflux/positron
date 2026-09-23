using Positron.Data.Bornes;
using Positron.Data.Correcoes;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// As regras das duas correções de um campo: o <c>CorrigeBornes</c>
    /// (visibilidade <c>-1</c> → <c>0</c>) e o <c>CorrigeDisp</c> (app name legado
    /// → atual).
    /// </summary>
    public class CorrecaoSimplesTests
    {
        [Fact]
        public void Visivel_menos_um_e_corrigido()
        {
            Assert.True(CorrecaoVisibilidadeBorne.PrecisaCorrigir(-1));
        }

        [Fact]
        public void Outros_valores_de_visivel_nao_sao_mexidos()
        {
            // Só o `-1` é do original: 0 (invisível) e 1 (visível) são estado válido.
            Assert.False(CorrecaoVisibilidadeBorne.PrecisaCorrigir(0));
            Assert.False(CorrecaoVisibilidadeBorne.PrecisaCorrigir(1));
            Assert.False(CorrecaoVisibilidadeBorne.PrecisaCorrigir(-2));
        }

        [Fact]
        public void A_correcao_escreve_zero()
        {
            Assert.Equal(0, CorrecaoVisibilidadeBorne.VisivelCorrigido);
            Assert.Equal(-1, CorrecaoVisibilidadeBorne.VisivelInvalido);
        }

        [Fact]
        public void Nomes_do_corrigedisp_batem_com_os_leitores()
        {
            // Se estes nomes saírem do lugar, a migração renomeia para um app name
            // que nenhum leitor procura.
            Assert.True(CorrecaoAppNameDispositivo.BateComOsLeitores());
            Assert.Equal("DISPOSITIVO", CorrecaoAppNameDispositivo.Legado);
            Assert.Equal("Dispositivo", CorrecaoAppNameDispositivo.Atual);
        }

        [Fact]
        public void Visivel_ida_e_volta_no_xdata()
        {
            // O `CorrigeBornes` grava o borne corrigido com o mesmo escritor da
            // correção de ordem; o campo tem de voltar pelo leitor.
            BorneXData borne = new BorneXData { Numero = "3", Ordem = 1, IndiceRegua = 5 };
            borne.Visivel = CorrecaoVisibilidadeBorne.VisivelCorrigido;

            BorneXData lido;
            Assert.True(BorneXData.Ler(borne.ParaValores("ana", "2026-09-23"), out lido));
            Assert.Equal(0, lido.Visivel);
        }
    }
}

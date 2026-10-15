using System.Collections.Generic;
using Positron.Data.Configuracao;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// Configuração do plugin: vem do desenho (ou dos padrões do original, sem o XData) e o
    /// ambiente <c>POSITRON_*</c> do harness vem por cima. Não há arquivo da máquina (rodada 180).
    /// </summary>
    public class ConfiguracaoPositronTests
    {
        private static Dictionary<string, string> Ambiente(params string[] pares)
        {
            Dictionary<string, string> ambiente = new Dictionary<string, string>();
            for (int i = 0; i + 1 < pares.Length; i += 2)
            {
                ambiente[pares[i]] = pares[i + 1];
            }

            return ambiente;
        }

        [Fact]
        public void Padrao_nao_tem_banco_e_zera_os_numeros()
        {
            ConfiguracaoPositron configuracao = ConfiguracaoPositron.Padrao();

            Assert.Null(configuracao.Banco);
            Assert.Null(configuracao.Revisao);
            Assert.Equal(0, configuracao.Dwg);
            Assert.Equal(0, configuracao.IncluirColuna);
        }

        [Fact]
        public void Desenho_sem_xdata_volta_aos_padroes_do_original_e_nao_tem_banco()
        {
            // O ramo `else` do `LerXDataConfiguracao` e do `LerXDataConfiguracao2`
            // (`XDataGeral.cs:291-300`, `:563-571`): nada fica de outro projeto.
            ConfiguracaoPositron lida = ConfiguracaoPositron.Carregar(null, null);

            Assert.Null(lida.Banco);
            Assert.Equal(0, lida.Dwg);
            Assert.Equal("???", lida.Local);
            Assert.Equal(1, lida.PassoPagina);
            Assert.Equal(1, lida.IncluirColuna);
        }

        [Fact]
        public void O_banco_vem_do_xdata_do_desenho()
        {
            ConfiguracaoDoCaderno desenho = ConfiguracaoDoCaderno.Padrao();
            desenho.DirProjeto = @"C:\obra\projeto.db";
            desenho.Local = "SE-1";

            ConfiguracaoPositron lida = ConfiguracaoPositron.Carregar(null, desenho);

            Assert.Equal(@"C:\obra\projeto.db", lida.Banco);
            Assert.Equal("SE-1", lida.Local);
        }

        [Fact]
        public void O_ambiente_do_harness_vence_o_desenho()
        {
            ConfiguracaoDoCaderno desenho = ConfiguracaoDoCaderno.Padrao();
            desenho.DirProjeto = @"C:\desenho.db";
            desenho.Local = "DO_DESENHO";

            ConfiguracaoPositron lida = ConfiguracaoPositron.Carregar(
                Ambiente("POSITRON_DB_PATH", @"C:\harness.db", "POSITRON_DWG", "9", "POSITRON_REVISAO", "R1"), desenho);

            Assert.Equal(@"C:\harness.db", lida.Banco);
            Assert.Equal(9, lida.Dwg);
            Assert.Equal("R1", lida.Revisao);
            Assert.Equal("DO_DESENHO", lida.Local);
        }

        [Fact]
        public void Valor_invalido_no_ambiente_mantem_o_anterior()
        {
            ConfiguracaoPositron lida = ConfiguracaoPositron.Carregar(Ambiente("POSITRON_DWG", "abc", "POSITRON_DB_PATH", ""), null);

            Assert.Equal(0, lida.Dwg);
            Assert.Null(lida.Banco);
        }

        [Fact]
        public void Padrao_da_tela_geral_segue_as_capturas_do_original()
        {
            ConfiguracaoPositron configuracao = ConfiguracaoPositron.Padrao();

            Assert.Equal("pt", configuracao.Idioma);
            Assert.Equal("IEC", configuracao.ContatosAuxiliares);
            Assert.Equal("Access", configuracao.TipoBanco);
            Assert.Equal("Eletronorte", configuracao.RepresentacaoCaboVeia);
            Assert.Equal("?", configuracao.TerminalIndefinido);
            Assert.Equal("-", configuracao.SeparadorCarimbo);
            Assert.Equal(1.5, configuracao.AlturaCircuitos);
            Assert.Equal(1.5, configuracao.AlturaReferenciaCruzada);
            Assert.Equal(7, configuracao.CorFiacaoConexao);
            Assert.Equal(7, configuracao.CorFiacaoTextoCircuito);
            Assert.Equal("[", configuracao.PrefixoCruzLogFunc);
            Assert.Equal("]", configuracao.SufixoCruzLogFunc);
            Assert.Equal(0, configuracao.VisualizacaoModelosRele);
        }
    }
}

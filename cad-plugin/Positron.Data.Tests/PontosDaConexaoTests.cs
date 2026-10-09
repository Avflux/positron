using Positron.Data.Fiacao;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// De qual ponta da <c>CONEXAO</c> nasce o ponto de fiação — as condições do
    /// <c>frmCompilarFiacao</c>. Regressão do desenho real: a leitura pegava sempre
    /// o primeiro vértice, o que punha 167 conexões Tipo 3 no vértice errado e
    /// deixava o borne da outra ponta órfão.
    /// </summary>
    public class PontosDaConexaoTests
    {
        private static ConexaoXData Conexao(short tipo, bool disp1, bool disp2, string jumper)
        {
            return new ConexaoXData { Tipo = tipo, Disp1 = disp1, Disp2 = disp2, Jumper = jumper };
        }

        [Fact]
        public void Tipo_1_usa_o_vertice_do_flag_marcado()
        {
            Assert.True(PontosDaConexao.UsaPrimeiroVertice(Conexao(1, true, false, "")));
            Assert.False(PontosDaConexao.UsaUltimoVertice(Conexao(1, true, false, "")));

            Assert.False(PontosDaConexao.UsaPrimeiroVertice(Conexao(1, false, true, "")));
            Assert.True(PontosDaConexao.UsaUltimoVertice(Conexao(1, false, true, "")));

            // Os dois flags: duas pontas, dois pontos.
            Assert.True(PontosDaConexao.UsaPrimeiroVertice(Conexao(1, true, true, "")));
            Assert.True(PontosDaConexao.UsaUltimoVertice(Conexao(1, true, true, "")));
        }

        [Fact]
        public void Tipo_1_sem_flag_nao_gera_ponto()
        {
            ConexaoXData conexao = Conexao(1, false, false, "");
            Assert.False(PontosDaConexao.UsaPrimeiroVertice(conexao));
            Assert.False(PontosDaConexao.UsaUltimoVertice(conexao));
        }

        [Fact]
        public void Tipo_2_gera_as_duas_pontas()
        {
            ConexaoXData conexao = Conexao(2, false, false, "");
            Assert.True(PontosDaConexao.UsaPrimeiroVertice(conexao));
            Assert.True(PontosDaConexao.UsaUltimoVertice(conexao));
        }

        [Fact]
        public void Tipo_3_so_gera_o_ultimo_e_sem_jumper()
        {
            Assert.False(PontosDaConexao.UsaPrimeiroVertice(Conexao(3, true, true, "")));
            Assert.True(PontosDaConexao.UsaUltimoVertice(Conexao(3, true, true, "")));

            // Com jumper a conexão é do fluxo do JMP, não da fiação.
            Assert.False(PontosDaConexao.UsaUltimoVertice(Conexao(3, true, true, "JUMPER")));
            Assert.False(PontosDaConexao.UsaUltimoVertice(Conexao(3, true, true, "  ")));
        }

        [Fact]
        public void Tipo_4_nao_gera_ponto_de_fiacao()
        {
            ConexaoXData conexao = Conexao(4, true, true, "");
            Assert.False(PontosDaConexao.UsaPrimeiroVertice(conexao));
            Assert.False(PontosDaConexao.UsaUltimoVertice(conexao));
        }

        [Fact]
        public void Conexao_nula_nao_gera_nada()
        {
            Assert.False(PontosDaConexao.UsaPrimeiroVertice(null));
            Assert.False(PontosDaConexao.UsaUltimoVertice(null));
        }
    }
}

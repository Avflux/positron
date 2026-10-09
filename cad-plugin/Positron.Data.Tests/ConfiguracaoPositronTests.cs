using System.Collections.Generic;
using Positron.Data.Configuracao;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// Configuração do plugin: precedência padrão &lt; arquivo &lt; ambiente, com leitura
    /// tolerante. A variável de ambiente vence porque é o caminho da automação (o
    /// harness do ZWCAD e os testes montam o cenário por variável).
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
        public void Arquivo_sobrevive_ao_round_trip()
        {
            ConfiguracaoPositron original = new ConfiguracaoPositron
            {
                Banco = @"C:\proj\obra.db",
                Dwg = 12,
                Revisao = "R3",
                Local = "SUBESTACAO",
                Log = @"C:\temp\positron.log",
                IncluirColuna = 6,
                SeparadorCruzamento = "-",
            };

            ConfiguracaoPositron lida = ConfiguracaoPositron.Ler(original.Texto(), null);

            Assert.Equal(original.Banco, lida.Banco);
            Assert.Equal(12, lida.Dwg);
            Assert.Equal("R3", lida.Revisao);
            Assert.Equal("SUBESTACAO", lida.Local);
            Assert.Equal(6, lida.IncluirColuna);
            Assert.Equal("-", lida.SeparadorCruzamento);
        }

        [Fact]
        public void Ambiente_vence_o_arquivo()
        {
            string conteudo = "banco=C:\\a.db\ndwg=1\nrevisao=R1\n";
            Dictionary<string, string> ambiente = Ambiente("POSITRON_DB_PATH", @"C:\b.db", "POSITRON_DWG", "9");

            ConfiguracaoPositron configuracao = ConfiguracaoPositron.Ler(conteudo, ambiente);

            Assert.Equal(@"C:\b.db", configuracao.Banco);
            Assert.Equal(9, configuracao.Dwg);
            // O que o ambiente não define continua vindo do arquivo.
            Assert.Equal("R1", configuracao.Revisao);
        }

        [Fact]
        public void Linha_malformada_e_valor_invalido_nao_derrubam()
        {
            string conteudo = "# comentario\n; outro\nlinha sem igual\nbanco=\ndwg=abc\nrevisao=R7\n";
            ConfiguracaoPositron configuracao = ConfiguracaoPositron.Ler(conteudo, null);

            Assert.Null(configuracao.Banco);      // valor vazio vira ausente
            Assert.Equal(0, configuracao.Dwg);    // inteiro inválido mantém o padrão
            Assert.Equal("R7", configuracao.Revisao);
        }

        [Fact]
        public void Chave_pode_vir_com_o_nome_da_variavel()
        {
            ConfiguracaoPositron configuracao = ConfiguracaoPositron.Ler("POSITRON_REVISAO=R9\nPOSITRON_INCLUIR_COLUNA=3\n", null);

            Assert.Equal("R9", configuracao.Revisao);
            Assert.Equal(3, configuracao.IncluirColuna);
        }
    }
}

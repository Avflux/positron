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
        public void Copiar_preserva_as_chaves_que_a_tela_nao_edita()
        {
            ConfiguracaoPositron atual = ConfiguracaoPositron.Padrao();
            atual.FonteCabos = 2.5;
            atual.PassoPagina = 2;
            atual.CorInterligacao = 3;
            atual.EstiloLinha = "DASHED";
            atual.Relatorio = @"C:\rel";

            ConfiguracaoPositron editada = atual.Copiar();
            editada.IncluirColuna = 4;

            ConfiguracaoPositron lida = ConfiguracaoPositron.Ler(editada.Texto(), null);

            Assert.Equal(4, lida.IncluirColuna);
            Assert.Equal(2.5, lida.FonteCabos);
            Assert.Equal(2, lida.PassoPagina);
            Assert.Equal(3, lida.CorInterligacao);
            Assert.Equal("DASHED", lida.EstiloLinha);
            Assert.Equal(@"C:\rel", lida.Relatorio);
            Assert.Equal(0, atual.IncluirColuna);
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
            Assert.Equal(original.Relatorio, lida.Relatorio);
        }

        [Fact]
        public void Relatorio_vem_do_ambiente_e_do_arquivo()
        {
            ConfiguracaoPositron doArquivo = ConfiguracaoPositron.Ler("relatorio=C:\\a\\r.txt\n", null);
            Assert.Equal(@"C:\a\r.txt", doArquivo.Relatorio);

            ConfiguracaoPositron doAmbiente = ConfiguracaoPositron.Ler(
                "relatorio=C:\\a\\r.txt\n",
                Ambiente("POSITRON_RELATORIO", @"C:\b\r.txt"));
            Assert.Equal(@"C:\b\r.txt", doAmbiente.Relatorio);
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

        [Fact]
        public void As_chaves_da_tela_geral_sobrevivem_ao_round_trip()
        {
            ConfiguracaoPositron original = new ConfiguracaoPositron
            {
                Idioma = "en",
                ContatosAuxiliares = "ANSI",
                TipoBanco = "SQL Server",
                SimbologiaEletrica = @"C:\lib\eletrica",
                SimbologiaTopografico = @"C:\lib\topo",
                SimbologiaLayout = @"C:\lib\layout",
                SimbologiaRelatorios = @"C:\lib\rel",
                RepresentacaoCaboVeia = "Enel-SP",
                TerminalIndefinido = "#",
                SeparadorCarimbo = "_",
                AlturaCircuitos = 2.25,
                AlturaReferenciaCruzada = 1.75,
                CorFiacaoConexao = 3,
                CorFiacaoTextoCircuito = 5,
                PrefixoCruzFuncFunc = "<",
                SufixoCruzFuncFunc = ">",
                PrefixoCruzLogFunc = "{",
                SufixoCruzLogFunc = "}",
                VisualizacaoModelosRele = 3,
            };

            ConfiguracaoPositron lida = ConfiguracaoPositron.Ler(original.Texto(), null);

            Assert.Equal("en", lida.Idioma);
            Assert.Equal("ANSI", lida.ContatosAuxiliares);
            Assert.Equal("SQL Server", lida.TipoBanco);
            Assert.Equal(@"C:\lib\eletrica", lida.SimbologiaEletrica);
            Assert.Equal(@"C:\lib\topo", lida.SimbologiaTopografico);
            Assert.Equal(@"C:\lib\layout", lida.SimbologiaLayout);
            Assert.Equal(@"C:\lib\rel", lida.SimbologiaRelatorios);
            Assert.Equal("Enel-SP", lida.RepresentacaoCaboVeia);
            Assert.Equal("#", lida.TerminalIndefinido);
            Assert.Equal("_", lida.SeparadorCarimbo);
            Assert.Equal(2.25, lida.AlturaCircuitos);
            Assert.Equal(1.75, lida.AlturaReferenciaCruzada);
            Assert.Equal(3, lida.CorFiacaoConexao);
            Assert.Equal(5, lida.CorFiacaoTextoCircuito);
            Assert.Equal("<", lida.PrefixoCruzFuncFunc);
            Assert.Equal(">", lida.SufixoCruzFuncFunc);
            Assert.Equal("{", lida.PrefixoCruzLogFunc);
            Assert.Equal("}", lida.SufixoCruzLogFunc);
            Assert.Equal(3, lida.VisualizacaoModelosRele);
        }

        [Fact]
        public void Desenho_vence_o_arquivo_e_o_ambiente_vence_o_desenho()
        {
            ConfiguracaoDoCaderno desenho = ConfiguracaoDoCaderno.Padrao();
            desenho.Local = "DO_DESENHO";
            desenho.PrefixoCruzInterno = "{";
            desenho.CorConexao = 3;

            string conteudo = "local=DO_ARQUIVO\nprefixoCruzInterno=(\ncorFiacaoConexao=1\ndwg=7\n";
            Dictionary<string, string> ambiente = Ambiente("POSITRON_LOCAL", "DO_AMBIENTE");

            ConfiguracaoPositron lida = ConfiguracaoPositron.Ler(conteudo, ambiente, desenho);

            Assert.Equal("DO_AMBIENTE", lida.Local);     // o ambiente vence o desenho
            Assert.Equal("{", lida.PrefixoCruzInterno);  // o desenho vence o arquivo
            Assert.Equal(3, lida.CorFiacaoConexao);      // idem
            Assert.Equal(7, lida.Dwg);                   // campo só do arquivo fica
        }

        [Fact]
        public void Sem_desenho_a_leitura_e_a_do_arquivo_e_ambiente()
        {
            ConfiguracaoPositron lida = ConfiguracaoPositron.Ler("local=DO_ARQUIVO\n", null, null);

            Assert.Equal("DO_ARQUIVO", lida.Local);
        }
    }
}

using System.Collections.Generic;
using Positron.Data.Configuracao;
using Positron.Data.Fiacao;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// A configuração geral no **desenho**, como o reverso a grava: os buffers
    /// <c>Eletron</c>/<c>Config</c> e <c>EletronProj</c>/<c>Projeto</c> do
    /// <c>XDataGeral</c>. A tela <c>frmConfiguracaoGeral</c> grava no desenho,
    /// **não** no banco.
    /// </summary>
    public class ConfiguracaoDoCadernoTests
    {
        private static ConfiguracaoDoCaderno DoReverso()
        {
            return new ConfiguracaoDoCaderno
            {
                DirProjeto = @"C:\proj\obra.db",
                DirSimbologiaEletrica = @"C:\lib\eletrica",
                DirSimbologiaTopografico = @"C:\lib\topo",
                DirSimbologiaLayout = @"C:\lib\layout",
                DirSimbologiaRelatorios = @"C:\lib\rel",
                Banco = ConfiguracaoDoCaderno.BancoSqlServer,
                SeparadorCarimbo = "_",
                PrefixoCruzFuncFunc = "<",
                SufixoCruzFuncFunc = ">",
                PassoPagina = 3,
                Local = "SUBESTACAO",
                PrefixoCruzInterno = "{",
                SufixoCruzInterno = "}",
                CorConexao = 3,
                CorTextoCircuito = 5,
                InterligacaoLayout = 2,
                CorInterligacao = 1,
                CorTextoInterligacao = 4,
                SeparadorCaboVeia = "|",
                SCapa = true,
                SCorpo = false,
                CCapa = true,
                CCorpo = false,
                MaxCapa = 12,
                MaxCorpo = 34,
                PrefixoCruzExterno = "[",
                SufixoCruzExterno = "]",
                CaracterTerminalIndefinido = "#",
                IncluirColuna = 5,
                SeparadorPainelRegua = "-",
                Norma = 1,
                EstiloLinha = "DASHED",
                SeparadorCruzamento = "|",
                FonteCircuito = 2.5,
                FonteCabos = 1.75,
                ModeloBobina = 3,
                LarguraFixaPaginas = 4,
                FonteCruzamento = 2.0,
                EstiloLinhaEscala = 0.5,
                DataSource = "SRV01",
                BancoDeDados = "POSITRON",
                User = "sa",
                Senha = "s3nha",
            };
        }

        [Fact]
        public void Buffer_do_config_tem_o_layout_do_reverso()
        {
            List<TypedXData> buffer = new List<TypedXData>(DoReverso().ParaValores());

            Assert.Equal(41, buffer.Count);
            Assert.Equal(1001, buffer[0].Codigo);
            Assert.Equal("Eletron", buffer[0].Valor);
            Assert.Equal(1000, buffer[1].Codigo);
            Assert.Equal("Config", buffer[1].Valor);
            Assert.Equal(1000, buffer[3].Codigo);   // Banco
            Assert.Equal("SV", buffer[3].Valor);
            Assert.Equal(1070, buffer[7].Codigo);   // PassoPagina
            Assert.Equal(1040, buffer[36].Codigo);  // EstiloLinhaEscala
            Assert.Equal(1000, buffer[40].Codigo);  // Senha
            Assert.Equal("s3nha", buffer[40].Valor);
        }

        [Fact]
        public void Buffer_do_projeto_tem_o_layout_do_reverso()
        {
            List<TypedXData> buffer = new List<TypedXData>(DoReverso().ParaValoresProjeto());

            Assert.Equal(8, buffer.Count);
            Assert.Equal("EletronProj", buffer[0].Valor);
            Assert.Equal("Projeto", buffer[1].Valor);
            Assert.Equal(@"C:\proj\obra.db", buffer[2].Valor);
            Assert.Equal(@"C:\lib\eletrica", buffer[3].Valor);
            Assert.Equal(@"C:\lib\rel", buffer[4].Valor);
            Assert.Equal(@"C:\lib\topo", buffer[5].Valor);
            Assert.Equal(string.Empty, buffer[6].Valor);
            Assert.Equal(@"C:\lib\layout", buffer[7].Valor);
        }

        [Fact]
        public void Round_trip_preserva_o_desenho()
        {
            ConfiguracaoDoCaderno original = DoReverso();

            ConfiguracaoDoCaderno config = ConfiguracaoDoCaderno.Ler(original.ParaValores());
            ConfiguracaoDoCaderno caderno = ConfiguracaoDoCaderno.LerProjeto(original.ParaValoresProjeto(), config);

            Assert.NotNull(caderno);
            Assert.Equal(original.DirProjeto, caderno.DirProjeto);
            Assert.Equal(original.DirSimbologiaEletrica, caderno.DirSimbologiaEletrica);
            Assert.Equal(original.DirSimbologiaTopografico, caderno.DirSimbologiaTopografico);
            Assert.Equal(original.DirSimbologiaLayout, caderno.DirSimbologiaLayout);
            Assert.Equal(original.DirSimbologiaRelatorios, caderno.DirSimbologiaRelatorios);
            Assert.Equal(original.Banco, caderno.Banco);
            Assert.Equal(original.SeparadorCarimbo, caderno.SeparadorCarimbo);
            Assert.Equal(original.PassoPagina, caderno.PassoPagina);
            Assert.Equal(original.Local, caderno.Local);
            Assert.Equal(original.IncluirColuna, caderno.IncluirColuna);
            Assert.Equal(original.CorConexao, caderno.CorConexao);
            Assert.Equal(original.InterligacaoLayout, caderno.InterligacaoLayout);
            Assert.Equal(original.SCapa, caderno.SCapa);
            Assert.Equal(original.CCapa, caderno.CCapa);
            Assert.Equal(original.MaxCapa, caderno.MaxCapa);
            Assert.Equal(original.MaxCorpo, caderno.MaxCorpo);
            Assert.Equal(original.PrefixoCruzExterno, caderno.PrefixoCruzExterno);
            Assert.Equal(original.Norma, caderno.Norma);
            Assert.Equal(original.EstiloLinha, caderno.EstiloLinha);
            Assert.Equal(original.EstiloLinhaEscala, caderno.EstiloLinhaEscala);
            Assert.Equal(original.FonteCircuito, caderno.FonteCircuito);
            Assert.Equal(original.FonteCabos, caderno.FonteCabos);
            Assert.Equal(original.FonteCruzamento, caderno.FonteCruzamento);
            Assert.Equal(original.ModeloBobina, caderno.ModeloBobina);
            Assert.Equal(original.DataSource, caderno.DataSource);
            Assert.Equal(original.BancoDeDados, caderno.BancoDeDados);
            Assert.Equal(original.User, caderno.User);
            Assert.Equal(original.Senha, caderno.Senha);
        }

        [Fact]
        public void Sem_o_marcador_o_desenho_nao_tem_configuracao()
        {
            List<TypedXData> outro = new List<TypedXData>
            {
                new TypedXData(1001, "OutroApp"),
                new TypedXData(1000, "Coisa"),
            };

            Assert.Null(ConfiguracaoDoCaderno.Ler(outro));
            Assert.Null(ConfiguracaoDoCaderno.Ler(null));
            Assert.Null(ConfiguracaoDoCaderno.LerProjeto(outro, null));
        }

        [Fact]
        public void Leitura_tolerante_aplica_as_guardas_do_original()
        {
            ConfiguracaoDoCaderno padrao = DoReverso();
            List<TypedXData> buffer = new List<TypedXData>(padrao.ParaValores());
            buffer[3] = new TypedXData(1000, string.Empty);   // Banco vazio -> A
            buffer[4] = new TypedXData(1000, string.Empty);   // SeparadorCarimbo vazio -> "-"
            buffer[27] = new TypedXData(1000, "1");           // SeparadorPainelRegua "1" -> "/"
            buffer[29] = new TypedXData(1000, string.Empty);  // EstiloLinha vazio -> Continuous
            buffer[35] = new TypedXData(1040, 0.0);           // FonteCruzamento 0 -> FonteCircuito
            buffer[36] = new TypedXData(1040, 0.0);           // Escala 0 -> 1.0

            ConfiguracaoDoCaderno lido = ConfiguracaoDoCaderno.Ler(buffer);

            Assert.Equal(ConfiguracaoDoCaderno.BancoAccess, lido.Banco);
            Assert.Equal("-", lido.SeparadorCarimbo);
            Assert.Equal("/", lido.SeparadorPainelRegua);
            Assert.Equal("Continuous", lido.EstiloLinha);
            Assert.Equal(lido.FonteCircuito, lido.FonteCruzamento);
            Assert.Equal(1.0, lido.EstiloLinhaEscala);
        }

        [Fact]
        public void Conversao_com_o_arquivo_mapeia_banco_e_tipo()
        {
            ConfiguracaoPositron arquivo = ConfiguracaoPositron.Padrao();
            arquivo.Banco = @"C:\proj\obra.db";
            arquivo.TipoBanco = "SQL Server";
            arquivo.SimbologiaEletrica = @"C:\lib\eletrica";
            arquivo.AlturaCircuitos = 2.5;
            arquivo.CorFiacaoConexao = 3;

            ConfiguracaoDoCaderno caderno = ConfiguracaoDoCaderno.De(arquivo);

            Assert.Equal(@"C:\proj\obra.db", caderno.DirProjeto);
            Assert.Equal(ConfiguracaoDoCaderno.BancoSqlServer, caderno.Banco);
            Assert.Equal(@"C:\lib\eletrica", caderno.DirSimbologiaEletrica);
            Assert.Equal(2.5, caderno.FonteCircuito);
            Assert.Equal(3, caderno.CorConexao);

            ConfiguracaoPositron volta = ConfiguracaoPositron.Padrao();
            caderno.AplicarEm(volta);
            Assert.Equal(@"C:\proj\obra.db", volta.Banco);
            Assert.Equal("SQL Server", volta.TipoBanco);
            Assert.Equal(@"C:\lib\eletrica", volta.SimbologiaEletrica);
            Assert.Equal(2.5, volta.AlturaCircuitos);
            Assert.Equal(3, volta.CorFiacaoConexao);
        }

        [Fact]
        public void AplicarDe_nao_zera_os_campos_que_o_arquivo_nao_tem()
        {
            ConfiguracaoDoCaderno caderno = DoReverso();
            ConfiguracaoPositron arquivo = ConfiguracaoPositron.Padrao();
            arquivo.Banco = @"C:\outro.db";

            caderno.AplicarDe(arquivo);

            Assert.Equal(@"C:\outro.db", caderno.DirProjeto);
            // O que só existe no desenho (o original grava) fica.
            Assert.Equal(1, caderno.Norma);
            Assert.Equal("SRV01", caderno.DataSource);
            Assert.Equal(12, caderno.MaxCapa);
        }

        [Fact]
        public void Codigo_do_tipo_cobre_os_tres_bancos()
        {
            Assert.Equal("A", ConfiguracaoDoCaderno.CodigoDoTipo("Access"));
            Assert.Equal("S", ConfiguracaoDoCaderno.CodigoDoTipo("SQLite"));
            Assert.Equal("SV", ConfiguracaoDoCaderno.CodigoDoTipo("SQL Server"));
            Assert.Equal("A", ConfiguracaoDoCaderno.CodigoDoTipo(null));

            Assert.Equal("Access", ConfiguracaoDoCaderno.TipoDoCodigo("A"));
            Assert.Equal("SQLite", ConfiguracaoDoCaderno.TipoDoCodigo("S"));
            Assert.Equal("SQL Server", ConfiguracaoDoCaderno.TipoDoCodigo("SV"));
        }

        [Fact]
        public void Norma_IEC_e_ANSI_sao_preservadas_no_XData()
        {
            ConfiguracaoDoCaderno iec = DoReverso();
            iec.Norma = 0;
            ConfiguracaoDoCaderno lidoIec = ConfiguracaoDoCaderno.Ler(iec.ParaValores());
            Assert.Equal(0, lidoIec.Norma);

            ConfiguracaoDoCaderno ansi = DoReverso();
            ansi.Norma = 1;
            ConfiguracaoDoCaderno lidoAnsi = ConfiguracaoDoCaderno.Ler(ansi.ParaValores());
            Assert.Equal(1, lidoAnsi.Norma);
        }

        [Fact]
        public void Delimitadores_de_Log_Func_sao_preservados_no_XData()
        {
            ConfiguracaoDoCaderno caderno = DoReverso();
            caderno.PrefixoCruzExterno = "[";
            caderno.SufixoCruzExterno = "]";

            ConfiguracaoDoCaderno lido = ConfiguracaoDoCaderno.Ler(caderno.ParaValores());
            Assert.Equal("[", lido.PrefixoCruzExterno);
            Assert.Equal("]", lido.SufixoCruzExterno);
        }

        [Fact]
        public void Interligacao_Layout_cobre_as_quatro_representacoes_cabo_veia()
        {
            for (int layout = 0; layout <= 3; layout++)
            {
                ConfiguracaoDoCaderno caderno = DoReverso();
                caderno.InterligacaoLayout = layout;

                ConfiguracaoDoCaderno lido = ConfiguracaoDoCaderno.Ler(caderno.ParaValores());
                Assert.Equal(layout, lido.InterligacaoLayout);
            }
        }

        [Fact]
        public void Campos_do_SQL_Server_sao_preservados_no_buffer_config()
        {
            ConfiguracaoDoCaderno sql = DoReverso();
            sql.Banco = ConfiguracaoDoCaderno.BancoSqlServer;
            sql.DataSource = @"192.168.1.100\SQLEXPRESS";
            sql.BancoDeDados = "PROJETO_2026";
            sql.User = "admin";
            sql.Senha = "p@ssword";

            ConfiguracaoDoCaderno lido = ConfiguracaoDoCaderno.Ler(sql.ParaValores());
            Assert.Equal(ConfiguracaoDoCaderno.BancoSqlServer, lido.Banco);
            Assert.Equal(@"192.168.1.100\SQLEXPRESS", lido.DataSource);
            Assert.Equal("PROJETO_2026", lido.BancoDeDados);
            Assert.Equal("admin", lido.User);
            Assert.Equal("p@ssword", lido.Senha);
        }
    }
}

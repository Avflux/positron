using System;
using System.Collections.Generic;
using System.Globalization;

namespace Positron.Data.Configuracao
{
    /// <summary>
    /// A configuração que os comandos do plugin leem — o <c>DeclaracoesGeral.Conf</c> do original.
    ///
    /// **Vem do desenho**, como no original: o <c>IniciarDWG</c> lê o XData do ModelSpace
    /// (<c>Eletron</c>/<c>Config</c> e <c>EletronProj</c>/<c>Projeto</c>) a cada desenho ativado e,
    /// sem ele, volta aos padrões (<c>XDataGeral.cs:291-300</c>, <c>:563-571</c>) — ver
    /// <see cref="Carregar"/>. **Não há arquivo de configuração da máquina:** até a rodada 179 havia um
    /// <c>%APPDATA%\Positron\positron.ini</c> que vazava o banco, o DWG e a revisão de um projeto
    /// para o desenho seguinte; ele não existe no original e saiu na rodada 180.
    ///
    /// As variáveis <c>POSITRON_*</c> vencem o desenho, mas existem **só para o harness** montar o
    /// cenário sem clique (decisão do dono, 2026-10-15).
    /// </summary>
    public sealed class ConfiguracaoPositron
    {
        public const string ChaveBanco = "banco";
        public const string ChaveDwg = "dwg";
        public const string ChaveRevisao = "revisao";
        public const string ChaveLocal = "local";
        public const string ChaveLog = "log";
        public const string ChaveIncluirColuna = "incluirColuna";
        public const string ChaveSeparador = "separadorCruzamento";
        public const string ChaveRelatorio = "relatorio";
        public const string ChaveOrdemListaBanco = "ordemListaBanco";
        public const string ChaveCorTextoInterligacao = "corTextoInterligacao";
        public const string ChaveFonteCabos = "fonteCabos";
        public const string ChaveSeparadorCaboVeia = "separadorCaboVeia";

    /// <summary>Chave do separador entre o painel e a régua no `NOME1` do borne (o `Conf.SeparadorPainelRegua`).</summary>
    public const string ChaveSeparadorPainelRegua = "separadorPainelRegua";

    /// <summary>Chave do prefixo do cruzamento interno (o `Conf.PrefixoCruzInterno`, padrão `(`).</summary>
    public const string ChavePrefixoCruzInterno = "prefixoCruzInterno";

    /// <summary>Chave do passo da página (o `Conf.PassoPagina`, padrão 1).</summary>
    public const string ChavePassoPagina = "passoPagina";

    /// <summary>Chave da largura fixa das páginas (o `Conf.LarguraFixaPaginas`, padrão 0 = sem zeros à esquerda).</summary>
    public const string ChaveLarguraFixaPaginas = "larguraFixaPaginas";

    /// <summary>Chave do sufixo do cruzamento interno (o `Conf.SufixoCruzInterno`, padrão `)`).</summary>
    public const string ChaveSufixoCruzInterno = "sufixoCruzInterno";
        public const string ChaveInterligacaoLayout = "interligacaoLayout";
        public const string ChaveCorInterligacao = "corInterligacao";
        public const string ChaveEstiloLinha = "estiloLinha";
        public const string ChaveEstiloLinhaEscala = "estiloLinhaEscala";

        public const string VariavelBanco = "POSITRON_DB_PATH";
        public const string VariavelDwg = "POSITRON_DWG";
        public const string VariavelRevisao = "POSITRON_REVISAO";
        public const string VariavelLocal = "POSITRON_LOCAL";
        public const string VariavelLog = "POSITRON_LOG";
        public const string VariavelIncluirColuna = "POSITRON_INCLUIR_COLUNA";
        public const string VariavelSeparador = "POSITRON_SEPARADOR_CRUZAMENTO";
        public const string VariavelRelatorio = "POSITRON_RELATORIO";
        public const string VariavelOrdemListaBanco = "POSITRON_LM_ORDEM_BANCO";
        public const string VariavelCorTextoInterligacao = "POSITRON_COR_TEXTO_INTERLIGACAO";
        public const string VariavelFonteCabos = "POSITRON_FONTE_CABOS";
        public const string VariavelSeparadorCaboVeia = "POSITRON_SEPARADOR_CABO_VEIA";

    /// <summary>Variável de ambiente do separador painel/régua.</summary>
    public const string VariavelSeparadorPainelRegua = "POSITRON_SEPARADOR_PAINEL_REGUA";

    /// <summary>Variável de ambiente do prefixo do cruzamento interno.</summary>
    public const string VariavelPrefixoCruzInterno = "POSITRON_PREFIXO_CRUZ_INTERNO";

    /// <summary>Variável de ambiente do passo da página.</summary>
    public const string VariavelPassoPagina = "POSITRON_PASSO_PAGINA";

    /// <summary>Variável de ambiente da largura fixa das páginas.</summary>
    public const string VariavelLarguraFixaPaginas = "POSITRON_LARGURA_FIXA_PAGINAS";

    /// <summary>Variável de ambiente do sufixo do cruzamento interno.</summary>
    public const string VariavelSufixoCruzInterno = "POSITRON_SUFIXO_CRUZ_INTERNO";
        public const string VariavelInterligacaoLayout = "POSITRON_INTERLIGACAO_LAYOUT";
        public const string VariavelCorInterligacao = "POSITRON_COR_INTERLIGACAO";
        public const string VariavelEstiloLinha = "POSITRON_ESTILO_LINHA";
        public const string VariavelEstiloLinhaEscala = "POSITRON_ESTILO_LINHA_ESCALA";

        // Chaves da tela "Configuração Geral" sem variável de ambiente (só ficam no arquivo).
        public const string ChaveIdioma = "idioma";
        public const string ChaveContatosAuxiliares = "contatosAuxiliares";
        public const string ChaveTipoBanco = "tipoBanco";
        public const string ChaveSimbologiaEletrica = "simbologiaEletrica";
        public const string ChaveSimbologiaTopografico = "simbologiaTopografico";
        public const string ChaveSimbologiaLayout = "simbologiaLayout";
        public const string ChaveSimbologiaRelatorios = "simbologiaRelatorios";
        public const string ChaveRepresentacaoCaboVeia = "representacaoCaboVeia";
        public const string ChaveTerminalIndefinido = "terminalIndefinido";
        public const string ChaveSeparadorCarimbo = "separadorCarimbo";
        public const string ChaveAlturaCircuitos = "alturaCircuitos";
        public const string ChaveAlturaReferenciaCruzada = "alturaReferenciaCruzada";
        public const string ChaveCorFiacaoConexao = "corFiacaoConexao";
        public const string ChaveCorFiacaoTextoCircuito = "corFiacaoTextoCircuito";
        public const string ChavePrefixoCruzFuncFunc = "prefixoCruzFuncFunc";
        public const string ChaveSufixoCruzFuncFunc = "sufixoCruzFuncFunc";
        public const string ChavePrefixoCruzLogFunc = "prefixoCruzLogFunc";
        public const string ChaveSufixoCruzLogFunc = "sufixoCruzLogFunc";
        public const string ChaveVisualizacaoModelosRele = "visualizacaoModelosRele";

        public string Banco { get; set; }

        public int Dwg { get; set; }

        public string Revisao { get; set; }

        public string Local { get; set; }

        public string Log { get; set; }

        public int IncluirColuna { get; set; }

        public string SeparadorCruzamento { get; set; }

        /// <summary>Arquivo do relatório de verificação (<c>ELETREL</c>).</summary>
        public string Relatorio { get; set; }

        /// <summary>
        /// O <c>Sim</c>/<c>Não</c> do diálogo do <c>COMPLM</c> ("a ordem da lista de
        /// materiais vem do banco?") — no original é um <c>MsgBox</c>; aqui é
        /// configuração. <c>false</c> (padrão) = ordem do **desenho**, o <c>Não</c>.
        /// </summary>
        public bool OrdemListaNoBanco { get; set; }

        /// <summary>Cor ACI do texto de interligação (o <c>Conf.CorTextoInterligacao</c>, padrão 7).</summary>
        public int CorTextoInterligacao { get; set; }

        /// <summary>Altura do texto de cabo (o <c>Conf.FonteCabos</c>, padrão 1.5).</summary>
        public double FonteCabos { get; set; }

        /// <summary>Separador entre a tag do cabo e o número da veia (o <c>Conf.SeparadorCaboVeia</c>, padrão <c>/</c>).</summary>
        public string SeparadorCaboVeia { get; set; }

        /// <summary>Separador entre o painel e a régua no `NOME1` do borne (o `Conf.SeparadorPainelRegua`, padrão `/`).</summary>
        public string SeparadorPainelRegua { get; set; }

        /// <summary>Prefixo do cruzamento interno (o `Conf.PrefixoCruzInterno`, padrão `(`).</summary>
        public string PrefixoCruzInterno { get; set; }

        /// <summary>Passo da página (o `Conf.PassoPagina` do original, padrão 1).</summary>
        public int PassoPagina { get; set; }

        /// <summary>
        /// Largura fixa do nome da página (o `Conf.LarguraFixaPaginas` do original, padrão 0 =
        /// desligado): com ela, o nome criado ganha zeros à esquerda até essa largura.
        /// </summary>
        public int LarguraFixaPaginas { get; set; }

        /// <summary>Sufixo do cruzamento interno (o `Conf.SufixoCruzInterno`, padrão `)`).</summary>
        public string SufixoCruzInterno { get; set; }

        /// <summary>Layout da interligação (o <c>Conf.InterligacaoLayout</c>, padrão 0 — o recoder só porta o caminho do layout padrão).</summary>
        public int InterligacaoLayout { get; set; }

        /// <summary>Cor ACI dos ornamentos da interligação (o <c>Conf.CorInterligacao</c>, padrão 7) — a elipse e o "leader" da Eletrosul.</summary>
        public int CorInterligacao { get; set; }

        /// <summary>Estilo de linha dos ornamentos (o <c>Conf.EstiloLinha</c>, padrão <c>Continuous</c>).</summary>
        public string EstiloLinha { get; set; }

        /// <summary>Escala do estilo de linha (o <c>Conf.EstiloLinhaEscala</c>, padrão 1.0).</summary>
        public double EstiloLinhaEscala { get; set; }

        /// <summary>Idioma da interface: <c>pt</c> (padrão) ou <c>en</c>.</summary>
        public string Idioma { get; set; }

        /// <summary>Contatos auxiliares: <c>IEC</c> (padrão) ou <c>ANSI</c>.</summary>
        public string ContatosAuxiliares { get; set; }

        /// <summary>Banco de dados: <c>Access</c> (padrão), <c>SQLite</c> ou <c>SQL Server</c>.</summary>
        public string TipoBanco { get; set; }

        /// <summary>Bibliotecas de simbologia (caminhos de arquivo/pasta).</summary>
        public string SimbologiaEletrica { get; set; }

        public string SimbologiaTopografico { get; set; }

        public string SimbologiaLayout { get; set; }

        public string SimbologiaRelatorios { get; set; }

        /// <summary>Representação do cabo/veia: <c>Elétron</c>, <c>Eletrosul</c>, <c>Eletronorte</c> (padrão) ou <c>Enel-SP</c>.</summary>
        public string RepresentacaoCaboVeia { get; set; }

        /// <summary>Caracter do terminal indefinido (padrão <c>?</c>).</summary>
        public string TerminalIndefinido { get; set; }

        /// <summary>Separador do carimbo (padrão <c>-</c>).</summary>
        public string SeparadorCarimbo { get; set; }

        /// <summary>Altura do texto dos circuitos (padrão 1.5).</summary>
        public double AlturaCircuitos { get; set; }

        /// <summary>Altura do texto da referência cruzada (padrão 1.5).</summary>
        public double AlturaReferenciaCruzada { get; set; }

        /// <summary>Cor ACI da conexão da fiação (padrão 7).</summary>
        public int CorFiacaoConexao { get; set; }

        /// <summary>Cor ACI do texto do circuito da fiação (padrão 7).</summary>
        public int CorFiacaoTextoCircuito { get; set; }

        public string PrefixoCruzFuncFunc { get; set; }

        public string SufixoCruzFuncFunc { get; set; }

        public string PrefixoCruzLogFunc { get; set; }

        public string SufixoCruzLogFunc { get; set; }

        /// <summary>Visualização dos modelos de relés: 0 = no contato (padrão), 1 = na bobina, 2 = na bobina e no contato, 3 = na bobina e no contato (Eletrosul).</summary>
        public int VisualizacaoModelosRele { get; set; }

        /// <summary>
        /// Cópia independente — quem edita parte das chaves (a tela do <c>ELETCFG</c>)
        /// parte dela para não gravar as demais zeradas.
        /// </summary>
        public ConfiguracaoPositron Copiar()
        {
            return (ConfiguracaoPositron)MemberwiseClone();
        }

        public static ConfiguracaoPositron Padrao()
        {
            return new ConfiguracaoPositron
            {
                Banco = null,
                Dwg = 0,
                Revisao = null,
                Local = null,
                Log = null,
                IncluirColuna = 0,
                SeparadorCruzamento = null,
                Relatorio = null,
                OrdemListaNoBanco = false,
                CorTextoInterligacao = 7,
                FonteCabos = 1.5,
                SeparadorCaboVeia = "/",
            SeparadorPainelRegua = "/",
            PrefixoCruzInterno = "(",
            PassoPagina = 1,
            LarguraFixaPaginas = 0,
            SufixoCruzInterno = ")",
                InterligacaoLayout = 0,
                CorInterligacao = 7,
                EstiloLinha = "Continuous",
                EstiloLinhaEscala = 1.0,
                Idioma = "pt",
                ContatosAuxiliares = "IEC",
                TipoBanco = "Access",
                RepresentacaoCaboVeia = "Eletronorte",
                TerminalIndefinido = "?",
                SeparadorCarimbo = "-",
                AlturaCircuitos = 1.5,
                AlturaReferenciaCruzada = 1.5,
                CorFiacaoConexao = 7,
                CorFiacaoTextoCircuito = 7,
                PrefixoCruzFuncFunc = "(",
                SufixoCruzFuncFunc = ")",
                PrefixoCruzLogFunc = "[",
                SufixoCruzLogFunc = "]",
                VisualizacaoModelosRele = 0,
            };
        }

        /// <summary>
        /// A configuração **efetiva** do desenho, como o <c>IniciarDWG</c> do original a monta: os
        /// valores do XData do desenho (<see cref="ConfiguracaoDoCaderno"/>, o <c>LerXDataConfiguracao</c> e
        /// o <c>LerXDataConfiguracao2</c>) e, **sem** o XData, os padrões do ramo <c>else</c> do original
        /// (<see cref="ConfiguracaoDoCaderno.Padrao"/>: banco vazio, <c>Local = "???"</c>…) — nunca o que
        /// ficou de outro projeto. O <paramref name="ambiente"/> (<c>POSITRON_*</c>) vem por cima e
        /// existe **só para o harness** (decisão do dono, 2026-10-15): nada daqui é gravado em arquivo.
        /// </summary>
        public static ConfiguracaoPositron Carregar(IDictionary<string, string> ambiente, ConfiguracaoDoCaderno desenho)
        {
            ConfiguracaoPositron configuracao = Padrao();
            (desenho ?? ConfiguracaoDoCaderno.Padrao()).AplicarEm(configuracao);
            AplicarAmbiente(configuracao, ambiente);
            return configuracao;
        }

        private static void Definir(ConfiguracaoPositron configuracao, string chave, string valor)
        {
            if (Mesma(chave, ChaveBanco, VariavelBanco)) { configuracao.Banco = Vazio(valor); return; }
            if (Mesma(chave, ChaveDwg, VariavelDwg)) { configuracao.Dwg = Inteiro(valor, configuracao.Dwg); return; }
            if (Mesma(chave, ChaveRevisao, VariavelRevisao)) { configuracao.Revisao = Vazio(valor); return; }
            if (Mesma(chave, ChaveLocal, VariavelLocal)) { configuracao.Local = Vazio(valor); return; }
            if (Mesma(chave, ChaveLog, VariavelLog)) { configuracao.Log = Vazio(valor); return; }
            if (Mesma(chave, ChaveIncluirColuna, VariavelIncluirColuna)) { configuracao.IncluirColuna = Inteiro(valor, configuracao.IncluirColuna); return; }
            if (Mesma(chave, ChaveSeparador, VariavelSeparador)) { configuracao.SeparadorCruzamento = Vazio(valor); return; }
            if (Mesma(chave, ChaveRelatorio, VariavelRelatorio)) { configuracao.Relatorio = Vazio(valor); return; }
            if (Mesma(chave, ChaveOrdemListaBanco, VariavelOrdemListaBanco)) { configuracao.OrdemListaNoBanco = Logico(valor, configuracao.OrdemListaNoBanco); return; }
            if (Mesma(chave, ChaveCorTextoInterligacao, VariavelCorTextoInterligacao)) { configuracao.CorTextoInterligacao = Inteiro(valor, configuracao.CorTextoInterligacao); return; }
            if (Mesma(chave, ChaveFonteCabos, VariavelFonteCabos)) { configuracao.FonteCabos = Real(valor, configuracao.FonteCabos); return; }
            if (Mesma(chave, ChaveSeparadorCaboVeia, VariavelSeparadorCaboVeia)) { configuracao.SeparadorCaboVeia = Vazio(valor); return; }
            if (Mesma(chave, ChaveSeparadorPainelRegua, VariavelSeparadorPainelRegua)) { configuracao.SeparadorPainelRegua = Vazio(valor); return; }
            if (Mesma(chave, ChavePrefixoCruzInterno, VariavelPrefixoCruzInterno)) { configuracao.PrefixoCruzInterno = Vazio(valor); return; }
            if (Mesma(chave, ChavePassoPagina, VariavelPassoPagina)) { configuracao.PassoPagina = Inteiro(valor, 1); return; }
            if (Mesma(chave, ChaveLarguraFixaPaginas, VariavelLarguraFixaPaginas)) { configuracao.LarguraFixaPaginas = Inteiro(valor, 0); return; }
            if (Mesma(chave, ChaveSufixoCruzInterno, VariavelSufixoCruzInterno)) { configuracao.SufixoCruzInterno = Vazio(valor); return; }
            if (Mesma(chave, ChaveInterligacaoLayout, VariavelInterligacaoLayout)) { configuracao.InterligacaoLayout = Inteiro(valor, configuracao.InterligacaoLayout); return; }
            if (Mesma(chave, ChaveCorInterligacao, VariavelCorInterligacao)) { configuracao.CorInterligacao = Inteiro(valor, configuracao.CorInterligacao); return; }
            if (Mesma(chave, ChaveEstiloLinha, VariavelEstiloLinha)) { configuracao.EstiloLinha = Vazio(valor); return; }
            if (Mesma(chave, ChaveEstiloLinhaEscala, VariavelEstiloLinhaEscala)) { configuracao.EstiloLinhaEscala = Real(valor, configuracao.EstiloLinhaEscala); return; }

            if (Chave(chave, ChaveIdioma)) { configuracao.Idioma = Vazio(valor); return; }
            if (Chave(chave, ChaveContatosAuxiliares)) { configuracao.ContatosAuxiliares = Vazio(valor); return; }
            if (Chave(chave, ChaveTipoBanco)) { configuracao.TipoBanco = Vazio(valor); return; }
            if (Chave(chave, ChaveSimbologiaEletrica)) { configuracao.SimbologiaEletrica = Vazio(valor); return; }
            if (Chave(chave, ChaveSimbologiaTopografico)) { configuracao.SimbologiaTopografico = Vazio(valor); return; }
            if (Chave(chave, ChaveSimbologiaLayout)) { configuracao.SimbologiaLayout = Vazio(valor); return; }
            if (Chave(chave, ChaveSimbologiaRelatorios)) { configuracao.SimbologiaRelatorios = Vazio(valor); return; }
            if (Chave(chave, ChaveRepresentacaoCaboVeia)) { configuracao.RepresentacaoCaboVeia = Vazio(valor); return; }
            if (Chave(chave, ChaveTerminalIndefinido)) { configuracao.TerminalIndefinido = Vazio(valor); return; }
            if (Chave(chave, ChaveSeparadorCarimbo)) { configuracao.SeparadorCarimbo = Vazio(valor); return; }
            if (Chave(chave, ChaveAlturaCircuitos)) { configuracao.AlturaCircuitos = Real(valor, configuracao.AlturaCircuitos); return; }
            if (Chave(chave, ChaveAlturaReferenciaCruzada)) { configuracao.AlturaReferenciaCruzada = Real(valor, configuracao.AlturaReferenciaCruzada); return; }
            if (Chave(chave, ChaveCorFiacaoConexao)) { configuracao.CorFiacaoConexao = Inteiro(valor, configuracao.CorFiacaoConexao); return; }
            if (Chave(chave, ChaveCorFiacaoTextoCircuito)) { configuracao.CorFiacaoTextoCircuito = Inteiro(valor, configuracao.CorFiacaoTextoCircuito); return; }
            if (Chave(chave, ChavePrefixoCruzFuncFunc)) { configuracao.PrefixoCruzFuncFunc = Vazio(valor); return; }
            if (Chave(chave, ChaveSufixoCruzFuncFunc)) { configuracao.SufixoCruzFuncFunc = Vazio(valor); return; }
            if (Chave(chave, ChavePrefixoCruzLogFunc)) { configuracao.PrefixoCruzLogFunc = Vazio(valor); return; }
            if (Chave(chave, ChaveSufixoCruzLogFunc)) { configuracao.SufixoCruzLogFunc = Vazio(valor); return; }
            if (Chave(chave, ChaveVisualizacaoModelosRele)) { configuracao.VisualizacaoModelosRele = Inteiro(valor, configuracao.VisualizacaoModelosRele); }
        }

        private static void AplicarAmbiente(ConfiguracaoPositron configuracao, IDictionary<string, string> ambiente)
        {
            if (ambiente == null)
            {
                return;
            }

            foreach (KeyValuePair<string, string> par in ambiente)
            {
                if (par.Value == null)
                {
                    continue;
                }

                Definir(configuracao, par.Key, par.Value);
            }
        }

        /// <summary>
        /// As variáveis <c>POSITRON_*</c> do processo, na forma que o <see cref="Carregar"/>
        /// aceita: o caminho do harness por cima do desenho.
        /// </summary>
        public static IDictionary<string, string> VariaveisDeAmbiente()
        {
            Dictionary<string, string> ambiente = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (string nome in new[] { VariavelBanco, VariavelDwg, VariavelRevisao, VariavelLocal, VariavelLog, VariavelIncluirColuna, VariavelSeparador, VariavelRelatorio, VariavelOrdemListaBanco, VariavelCorTextoInterligacao, VariavelFonteCabos, VariavelSeparadorCaboVeia, VariavelSeparadorPainelRegua, VariavelPrefixoCruzInterno, VariavelSufixoCruzInterno, VariavelPassoPagina, VariavelLarguraFixaPaginas, VariavelInterligacaoLayout, VariavelCorInterligacao, VariavelEstiloLinha, VariavelEstiloLinhaEscala })
            {
                string valor = Environment.GetEnvironmentVariable(nome);
                if (!string.IsNullOrEmpty(valor))
                {
                    ambiente[nome] = valor;
                }
            }

            return ambiente;
        }

        private static bool Mesma(string chave, string canonica, string variavel)
        {
            return string.Equals(chave, canonica, StringComparison.OrdinalIgnoreCase)
                || string.Equals(chave, variavel, StringComparison.OrdinalIgnoreCase);
        }

        private static bool Chave(string chave, string canonica)
        {
            return string.Equals(chave, canonica, StringComparison.OrdinalIgnoreCase);
        }

        private static string Vazio(string valor)
        {
            return string.IsNullOrEmpty(valor) ? null : valor;
        }

        private static int Inteiro(string valor, int padrao)
        {
            if (string.IsNullOrEmpty(valor))
            {
                return padrao;
            }

            int numero;
            return int.TryParse(valor.Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out numero) ? numero : padrao;
        }

        private static double Real(string valor, double padrao)
        {
            if (string.IsNullOrEmpty(valor))
            {
                return padrao;
            }

            double numero;
            return double.TryParse(valor.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out numero) ? numero : padrao;
        }

        /// <summary>
        /// Lê um booleano tolerante: <c>1</c>/<c>true</c>/<c>sim</c>/<c>on</c> ligam,
        /// <c>0</c>/<c>false</c>/<c>nao</c>/<c>off</c> desligam e qualquer outra coisa
        /// (inclusive vazio) mantém o valor anterior.
        /// </summary>
        private static bool Logico(string valor, bool padrao)
        {
            if (string.IsNullOrEmpty(valor))
            {
                return padrao;
            }

            switch (valor.Trim().ToUpperInvariant())
            {
                case "1":
                case "TRUE":
                case "SIM":
                case "ON":
                    return true;
                case "0":
                case "FALSE":
                case "NAO":
                case "NÃO":
                case "OFF":
                    return false;
                default:
                    return padrao;
            }
        }
    }
}

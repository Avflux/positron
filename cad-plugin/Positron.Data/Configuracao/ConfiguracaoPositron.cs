using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Positron.Data.Configuracao
{
    /// <summary>
    /// Configuração do plugin — o que o produto original guardava nas telas
    /// (<c>frmCompilar*</c>) e o recoder, até aqui, só aceitava por variável de
    /// ambiente (<c>POSITRON_*</c>).
    ///
    /// **Precedência: padrão &lt; arquivo &lt; ambiente.** A variável de ambiente vence
    /// porque é o caminho da automação (o harness do ZWCAD e os testes montam o
    /// cenário por variável); o arquivo é o caminho do usuário, gravado pela tela de
    /// configuração. Assim a UI acrescenta persistência sem quebrar nada do que já
    /// funciona.
    ///
    /// O arquivo é um <c>.ini</c> simples (<c>chave=valor</c>, uma por linha), lido e
    /// escrito sem dependência externa. Linha malformada é ignorada e valor inválido
    /// mantém o anterior — dado de terceiro não derruba o comando.
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

    /// <summary>Variável de ambiente do sufixo do cruzamento interno.</summary>
    public const string VariavelSufixoCruzInterno = "POSITRON_SUFIXO_CRUZ_INTERNO";
        public const string VariavelInterligacaoLayout = "POSITRON_INTERLIGACAO_LAYOUT";
        public const string VariavelCorInterligacao = "POSITRON_COR_INTERLIGACAO";
        public const string VariavelEstiloLinha = "POSITRON_ESTILO_LINHA";
        public const string VariavelEstiloLinhaEscala = "POSITRON_ESTILO_LINHA_ESCALA";

        private static ConfiguracaoPositron _cache;

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

        /// <summary>Arquivo padrão: <c>%APPDATA%\Positron\positron.ini</c> (ou o TEMP).</summary>
        public static string ArquivoPadrao
        {
            get
            {
                string baseDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                if (string.IsNullOrEmpty(baseDir))
                {
                    baseDir = Path.GetTempPath();
                }

                return Path.Combine(Path.Combine(baseDir, "Positron"), "positron.ini");
            }
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
            SufixoCruzInterno = ")",
                InterligacaoLayout = 0,
                CorInterligacao = 7,
                EstiloLinha = "Continuous",
                EstiloLinhaEscala = 1.0,
            };
        }

        /// <summary>
        /// Configuração efetiva: o arquivo padrão por baixo e o ambiente por cima.
        /// O resultado fica em cache (o comando lê uma vez por execução).
        /// </summary>
        public static ConfiguracaoPositron Carregar()
        {
            if (_cache == null)
            {
                _cache = Carregar(ArquivoPadrao, Ambiente());
            }

            return _cache;
        }

        /// <summary>Carrega do arquivo indicado (se existir) e aplica o ambiente por cima.</summary>
        public static ConfiguracaoPositron Carregar(string arquivo, IDictionary<string, string> ambiente)
        {
            ConfiguracaoPositron configuracao = Padrao();

            if (!string.IsNullOrEmpty(arquivo) && File.Exists(arquivo))
            {
                try
                {
                    Aplicar(configuracao, File.ReadAllLines(arquivo));
                }
                catch (IOException)
                {
                    // Arquivo ilegível não impede o comando: segue com o padrão.
                }
            }

            AplicarAmbiente(configuracao, ambiente);
            return configuracao;
        }

        /// <summary>Zera o cache (usado depois de gravar a configuração).</summary>
        public static void InvalidarCache()
        {
            _cache = null;
        }

        /// <summary>Grava no arquivo padrão (criando a pasta) e invalida o cache.</summary>
        public void Salvar()
        {
            Salvar(ArquivoPadrao);
        }

        public void Salvar(string arquivo)
        {
            string pasta = Path.GetDirectoryName(arquivo);
            if (!string.IsNullOrEmpty(pasta) && !Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            File.WriteAllText(arquivo, Texto());
            InvalidarCache();
        }

        /// <summary>O conteúdo do arquivo, no formato <c>chave=valor</c>.</summary>
        public string Texto()
        {
            StringBuilder texto = new StringBuilder();
            texto.AppendLine("# Configuracao do plugin Positron (o ambiente POSITRON_* tem prioridade)");
            texto.AppendLine(ChaveBanco + "=" + (Banco ?? string.Empty));
            texto.AppendLine(ChaveDwg + "=" + Dwg.ToString(CultureInfo.InvariantCulture));
            texto.AppendLine(ChaveRevisao + "=" + (Revisao ?? string.Empty));
            texto.AppendLine(ChaveLocal + "=" + (Local ?? string.Empty));
            texto.AppendLine(ChaveLog + "=" + (Log ?? string.Empty));
            texto.AppendLine(ChaveIncluirColuna + "=" + IncluirColuna.ToString(CultureInfo.InvariantCulture));
            texto.AppendLine(ChaveSeparador + "=" + (SeparadorCruzamento ?? string.Empty));
            texto.AppendLine(ChaveRelatorio + "=" + (Relatorio ?? string.Empty));
            texto.AppendLine(ChaveOrdemListaBanco + "=" + (OrdemListaNoBanco ? "1" : "0"));
            texto.AppendLine(ChaveCorTextoInterligacao + "=" + CorTextoInterligacao.ToString(CultureInfo.InvariantCulture));
            texto.AppendLine(ChaveFonteCabos + "=" + FonteCabos.ToString(CultureInfo.InvariantCulture));
            texto.AppendLine(ChaveSeparadorCaboVeia + "=" + (SeparadorCaboVeia ?? string.Empty));
            texto.AppendLine(ChaveSeparadorPainelRegua + "=" + (SeparadorPainelRegua ?? string.Empty));
            texto.AppendLine(ChavePrefixoCruzInterno + "=" + (PrefixoCruzInterno ?? string.Empty));
            texto.AppendLine(ChavePassoPagina + "=" + PassoPagina.ToString(System.Globalization.CultureInfo.InvariantCulture));
            texto.AppendLine(ChaveSufixoCruzInterno + "=" + (SufixoCruzInterno ?? string.Empty));
            texto.AppendLine(ChaveInterligacaoLayout + "=" + InterligacaoLayout.ToString(CultureInfo.InvariantCulture));
            texto.AppendLine(ChaveCorInterligacao + "=" + CorInterligacao.ToString(CultureInfo.InvariantCulture));
            texto.AppendLine(ChaveEstiloLinha + "=" + (EstiloLinha ?? string.Empty));
            texto.AppendLine(ChaveEstiloLinhaEscala + "=" + EstiloLinhaEscala.ToString(CultureInfo.InvariantCulture));
            return texto.ToString();
        }

        /// <summary>Lê o conteúdo (mesmo formato do arquivo). Exposto para teste.</summary>
        public static ConfiguracaoPositron Ler(string conteudo, IDictionary<string, string> ambiente)
        {
            ConfiguracaoPositron configuracao = Padrao();
            if (!string.IsNullOrEmpty(conteudo))
            {
                Aplicar(configuracao, conteudo.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries));
            }

            AplicarAmbiente(configuracao, ambiente);
            return configuracao;
        }

        private static void Aplicar(ConfiguracaoPositron configuracao, IEnumerable<string> linhas)
        {
            foreach (string linha in linhas)
            {
                string limpa = linha.Trim();
                if (limpa.Length == 0 || limpa.StartsWith("#", StringComparison.Ordinal) || limpa.StartsWith(";", StringComparison.Ordinal))
                {
                    continue;
                }

                int igual = limpa.IndexOf('=');
                if (igual <= 0)
                {
                    continue;
                }

                string chave = limpa.Substring(0, igual).Trim();
                string valor = limpa.Substring(igual + 1).Trim();
                Definir(configuracao, chave, valor);
            }
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
            if (Mesma(chave, ChaveSufixoCruzInterno, VariavelSufixoCruzInterno)) { configuracao.SufixoCruzInterno = Vazio(valor); return; }
            if (Mesma(chave, ChaveInterligacaoLayout, VariavelInterligacaoLayout)) { configuracao.InterligacaoLayout = Inteiro(valor, configuracao.InterligacaoLayout); return; }
            if (Mesma(chave, ChaveCorInterligacao, VariavelCorInterligacao)) { configuracao.CorInterligacao = Inteiro(valor, configuracao.CorInterligacao); return; }
            if (Mesma(chave, ChaveEstiloLinha, VariavelEstiloLinha)) { configuracao.EstiloLinha = Vazio(valor); return; }
            if (Mesma(chave, ChaveEstiloLinhaEscala, VariavelEstiloLinhaEscala)) { configuracao.EstiloLinhaEscala = Real(valor, configuracao.EstiloLinhaEscala); }
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

        private static IDictionary<string, string> Ambiente()
        {
            Dictionary<string, string> ambiente = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (string nome in new[] { VariavelBanco, VariavelDwg, VariavelRevisao, VariavelLocal, VariavelLog, VariavelIncluirColuna, VariavelSeparador, VariavelRelatorio, VariavelOrdemListaBanco, VariavelCorTextoInterligacao, VariavelFonteCabos, VariavelSeparadorCaboVeia, VariavelSeparadorPainelRegua, VariavelPrefixoCruzInterno, VariavelSufixoCruzInterno, VariavelPassoPagina, VariavelInterligacaoLayout, VariavelCorInterligacao, VariavelEstiloLinha, VariavelEstiloLinhaEscala })
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

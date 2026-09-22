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

        public const string VariavelBanco = "POSITRON_DB_PATH";
        public const string VariavelDwg = "POSITRON_DWG";
        public const string VariavelRevisao = "POSITRON_REVISAO";
        public const string VariavelLocal = "POSITRON_LOCAL";
        public const string VariavelLog = "POSITRON_LOG";
        public const string VariavelIncluirColuna = "POSITRON_INCLUIR_COLUNA";
        public const string VariavelSeparador = "POSITRON_SEPARADOR_CRUZAMENTO";
        public const string VariavelRelatorio = "POSITRON_RELATORIO";
        public const string VariavelOrdemListaBanco = "POSITRON_LM_ORDEM_BANCO";

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
            if (Mesma(chave, ChaveOrdemListaBanco, VariavelOrdemListaBanco)) { configuracao.OrdemListaNoBanco = Logico(valor, configuracao.OrdemListaNoBanco); }
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
            foreach (string nome in new[] { VariavelBanco, VariavelDwg, VariavelRevisao, VariavelLocal, VariavelLog, VariavelIncluirColuna, VariavelSeparador, VariavelRelatorio, VariavelOrdemListaBanco })
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

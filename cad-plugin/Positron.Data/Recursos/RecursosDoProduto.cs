using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Positron.Data.Recursos
{
    /// <summary>
    /// Gerencia os **templates e recursos DWG** originais do produto, embutidos no assembly
    /// (<c>lib/Recursos/*.dwg</c>) e extraídos no arranque para as pastas de trabalho do CAD.
    ///
    /// No original (<c>Iniciar.IniciarApp()</c>, linhas 33–47):
    /// - Grava <c>MascaraM.dwg</c> (<c>Resources.MascaraM</c>) em <c>%APPDATA%\Cadgraph\Eletron4\</c>
    /// - Grava <c>ErroFiacao.dwg</c> (<c>Resources.ErroFiacao</c>) em <c>%APPDATA%\Cadgraph\Eletron4\</c>
    /// - Grava <c>V_B_BORNECPFL.dwg</c> (<c>Resources.V_B_BORNECPFL</c>) em <c>%APPDATA%\Cadgraph\Eletron4\</c>
    /// - E o recurso de revisão <c>Revisao.dwg</c> (<c>Resources.Revisao</c>).
    ///
    /// Aqui a regra é pura: extração idempotente, validação de cabeçalho DWG (<c>AC1021</c> /
    /// <c>AC1024</c>) e resolução dos caminhos (pasta padrão Positron e compatibilidade legada).
    /// </summary>
    public static class RecursosDoProduto
    {
        public const string MascaraM = "MascaraM.dwg";
        public const string ErroFiacao = "ErroFiacao.dwg";
        public const string BorneCpfl = "V_B_BORNECPFL.dwg";
        public const string Revisao = "Revisao.dwg";

        private static readonly string[] Arquivos = new[]
        {
            MascaraM,
            ErroFiacao,
            BorneCpfl,
            Revisao
        };

        /// <summary>Lista de todos os recursos DWG conhecidos do produto.</summary>
        public static IReadOnlyList<string> Todos
        {
            get { return Arquivos; }
        }

        /// <summary>Pasta padrão dos recursos no perfil Positron (%APPDATA%\Positron\Recursos).</summary>
        public static string PastaPadraoPositron
        {
            get
            {
                string baseDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                if (string.IsNullOrEmpty(baseDir))
                {
                    baseDir = Path.GetTempPath();
                }

                return Path.Combine(Path.Combine(baseDir, "Positron"), "Recursos");
            }
        }

        /// <summary>Pasta legada compatível com o original (%APPDATA%\Cadgraph\Eletron4).</summary>
        public static string PastaLegadaCadgraph
        {
            get
            {
                string baseDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                if (string.IsNullOrEmpty(baseDir))
                {
                    baseDir = Path.GetTempPath();
                }

                return Path.Combine(Path.Combine(baseDir, "Cadgraph"), "Eletron4");
            }
        }

        /// <summary>
        /// Resolve o caminho de um arquivo de recurso, verificando primeiro na pasta padrão Positron,
        /// depois na pasta legada do Cadgraph e, se nenhuma existir, devolve o caminho padrão.
        /// </summary>
        public static string ResolverCaminho(string nomeArquivo)
        {
            if (string.IsNullOrEmpty(nomeArquivo))
            {
                throw new ArgumentNullException("nomeArquivo");
            }

            string caminhoPositron = Path.Combine(PastaPadraoPositron, nomeArquivo);
            if (File.Exists(caminhoPositron))
            {
                return caminhoPositron;
            }

            string caminhoLegado = Path.Combine(PastaLegadaCadgraph, nomeArquivo);
            if (File.Exists(caminhoLegado))
            {
                return caminhoLegado;
            }

            return caminhoPositron;
        }

        /// <summary>
        /// Obtém os bytes brutos do recurso embutido no assembly pelo nome do arquivo.
        /// </summary>
        public static byte[] ObterBytes(string nomeArquivo)
        {
            if (string.IsNullOrEmpty(nomeArquivo))
            {
                throw new ArgumentNullException("nomeArquivo");
            }

            Assembly assembly = typeof(RecursosDoProduto).Assembly;
            string nomeRecurso = "Positron.Recursos." + nomeArquivo;

            using (Stream stream = assembly.GetManifestResourceStream(nomeRecurso))
            {
                if (stream == null)
                {
                    // Fallback se chamado sem extensão .dwg
                    if (!nomeArquivo.EndsWith(".dwg", StringComparison.OrdinalIgnoreCase))
                    {
                        return ObterBytes(nomeArquivo + ".dwg");
                    }

                    return null;
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    stream.CopyTo(ms);
                    return ms.ToArray();
                }
            }
        }

        /// <summary>
        /// Valida se o array de bytes corresponde a um cabeçalho DWG válido (iniciado em AC10xx).
        /// </summary>
        public static bool EhDwgValido(byte[] bytes)
        {
            if (bytes == null || bytes.Length < 6)
            {
                return false;
            }

            return bytes[0] == (byte)'A'
                && bytes[1] == (byte)'C'
                && bytes[2] == (byte)'1'
                && bytes[3] == (byte)'0';
        }

        /// <summary>
        /// Identifica a versão do formato DWG pelo número de versão do cabeçalho.
        /// </summary>
        public static string IdentificarVersaoDwg(byte[] bytes)
        {
            if (!EhDwgValido(bytes))
            {
                return "Inválido";
            }

            string codigo = Encoding.ASCII.GetString(bytes, 0, 6);
            switch (codigo)
            {
                case "AC1015": return "AutoCAD 2000";
                case "AC1018": return "AutoCAD 2004";
                case "AC1021": return "AutoCAD 2007";
                case "AC1024": return "AutoCAD 2010";
                case "AC1027": return "AutoCAD 2013";
                case "AC1032": return "AutoCAD 2018";
                default: return codigo;
            }
        }

        /// <summary>
        /// Garante que todos os recursos estejam extraídos na pasta de destino informada.
        /// Devolve quantos arquivos foram efetivamente gravados em disco.
        /// </summary>
        public static int GarantirEmDisco(string pastaDestino, bool sobrescrever = false)
        {
            if (string.IsNullOrEmpty(pastaDestino))
            {
                throw new ArgumentNullException("pastaDestino");
            }

            if (!Directory.Exists(pastaDestino))
            {
                Directory.CreateDirectory(pastaDestino);
            }

            int gravados = 0;
            foreach (string nome in Arquivos)
            {
                string caminho = Path.Combine(pastaDestino, nome);
                byte[] conteudo = ObterBytes(nome);
                if (conteudo == null)
                {
                    continue;
                }

                if (!sobrescrever && File.Exists(caminho))
                {
                    FileInfo fi = new FileInfo(caminho);
                    if (fi.Length == conteudo.Length)
                    {
                        continue;
                    }
                }

                File.WriteAllBytes(caminho, conteudo);
                gravados++;
            }

            return gravados;
        }

        /// <summary>
        /// Garante todos os recursos DWG tanto na pasta Positron quanto na pasta Cadgraph (compatibilidade legada).
        /// </summary>
        public static int GarantirTodosOsRecursos(bool sobrescrever = false)
        {
            int gravados = 0;
            try
            {
                gravados += GarantirEmDisco(PastaPadraoPositron, sobrescrever);
            }
            catch (Exception)
            {
            }

            try
            {
                gravados += GarantirEmDisco(PastaLegadaCadgraph, sobrescrever);
            }
            catch (Exception)
            {
            }

            return gravados;
        }
    }
}

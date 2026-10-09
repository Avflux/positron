using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Positron.Data;

namespace Positron.Data.Relatorios
{
    /// <summary>Uma linha do relatório (o que a grid de erros do original mostrava).</summary>
    public sealed class LinhaRelatorio
    {
        public string Area { get; set; }

        public string Tipo { get; set; }

        public string Tabela { get; set; }

        public string Identificador { get; set; }

        public string Detalhe { get; set; }

        /// <summary>Linha no formato do relatório (separada por <c>;</c>).</summary>
        public override string ToString()
        {
            return string.Join(";", new[]
            {
                Area ?? string.Empty,
                Tipo ?? string.Empty,
                Tabela ?? string.Empty,
                Identificador ?? string.Empty,
                Detalhe ?? string.Empty,
            });
        }
    }

    /// <summary>
    /// Relatório de uma compilação/verificação — a **grid de erros** das telas
    /// <c>frmCompilar*</c> do original, em forma pura: o resumo que o comando já
    /// imprimia mais as linhas de problema, com <c>Texto()</c> para a tela e
    /// <c>Salvar()</c> para arquivo.
    ///
    /// Existe para separar o que é **conteúdo** (aqui, testável) do que é **tela**
    /// (WinForms, que não dá para verificar em script). O comando <c>ELETREL</c>
    /// grava este relatório em arquivo — então o caminho todo é verificável dentro
    /// do ZWCAD, sem clicar em nada.
    /// </summary>
    public sealed class RelatorioCompilacao
    {
        private readonly List<LinhaRelatorio> _linhas = new List<LinhaRelatorio>();

        public string Titulo { get; set; }

        /// <summary>A linha de resumo que o comando imprime (e que os E2E leem).</summary>
        public string Resumo { get; set; }

        /// <summary>Resumo por tabela/contagem (uma linha por item).</summary>
        public IList<string> Contagens { get; } = new List<string>();

        public IReadOnlyList<LinhaRelatorio> Linhas
        {
            get { return _linhas; }
        }

        public void Adicionar(LinhaRelatorio linha)
        {
            if (linha != null)
            {
                _linhas.Add(linha);
            }
        }

        /// <summary>
        /// Relatório a partir dos problemas do verificador. A ordem é a que o
        /// verificador devolveu (ele já agrupa por área).
        /// </summary>
        public static RelatorioCompilacao DeProblemas(string titulo, string resumo, IEnumerable<Problema> problemas)
        {
            RelatorioCompilacao relatorio = new RelatorioCompilacao { Titulo = titulo, Resumo = resumo };
            if (problemas != null)
            {
                foreach (Problema problema in problemas)
                {
                    if (problema == null)
                    {
                        continue;
                    }

                    relatorio.Adicionar(new LinhaRelatorio
                    {
                        Area = problema.Area.ToString(),
                        Tipo = problema.Tipo.ToString(),
                        Tabela = problema.Tabela,
                        Identificador = problema.Identificador,
                        Detalhe = problema.Detalhe,
                    });
                }
            }

            return relatorio;
        }

        /// <summary>O texto do relatório — o mesmo que a tela mostra e o arquivo recebe.</summary>
        public string Texto()
        {
            StringBuilder texto = new StringBuilder();
            texto.AppendLine("# " + (Titulo ?? "Relatório do Positron"));
            texto.AppendLine("# " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
            if (!string.IsNullOrEmpty(Resumo))
            {
                texto.AppendLine(Resumo);
            }

            foreach (string contagem in Contagens)
            {
                texto.AppendLine(contagem);
            }

            texto.AppendLine();
            texto.AppendLine("# area;tipo;tabela;identificador;detalhe");
            foreach (LinhaRelatorio linha in _linhas)
            {
                texto.AppendLine(linha.ToString());
            }

            texto.AppendLine();
            texto.AppendLine("# " + _linhas.Count + " linha(s)");
            return texto.ToString();
        }

        /// <summary>Grava o relatório (criando a pasta), em UTF-8.</summary>
        public void Salvar(string caminho)
        {
            if (string.IsNullOrWhiteSpace(caminho))
            {
                throw new ArgumentException("Informe o caminho do relatório.", "caminho");
            }

            string pasta = Path.GetDirectoryName(caminho);
            if (!string.IsNullOrEmpty(pasta) && !Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            File.WriteAllText(caminho, Texto(), new UTF8Encoding(false));
        }
    }
}

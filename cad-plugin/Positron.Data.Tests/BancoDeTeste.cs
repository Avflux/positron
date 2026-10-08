using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Text;

namespace Positron.Data.Tests
{
    /// <summary>
    /// Cria um banco de teste a partir do <c>schema.sql</c> CANÔNICO (copiado
    /// para a saída pelo csproj). Se o schema mudar e a projeção não, o teste
    /// quebra — que é exatamente o que se quer.
    /// </summary>
    internal static class BancoDeTeste
    {
        /// <summary>
        /// Cria o banco. Com <c>POSITRON_TEST_DB</c> definido, usa esse caminho e
        /// <see cref="Limpar"/> não apaga — é o gancho para checar o arquivo
        /// gravado com outro processo (o sidecar), num teste de ponta a ponta.
        /// </summary>
        internal static string Criar()
        {
            string fixo = Environment.GetEnvironmentVariable("POSITRON_TEST_DB");
            string destino = string.IsNullOrEmpty(fixo)
                ? Path.Combine(Path.GetTempPath(), "positron-teste-" + Guid.NewGuid().ToString("N") + ".db")
                : fixo;

            string schema = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "schema.sql"));

            using (SQLiteConnection conexao = new SQLiteConnection("Data Source=" + destino + ";Version=3;"))
            {
                conexao.Open();
                foreach (string comando in Separar(schema))
                {
                    using (SQLiteCommand cmd = conexao.CreateCommand())
                    {
                        cmd.CommandText = comando;
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            return destino;
        }

        /// <summary>Apaga o banco do teste — a menos que seja o caminho de verificação externa.</summary>
        internal static void Limpar(string caminho)
        {
            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("POSITRON_TEST_DB")))
            {
                File.Delete(caminho);
            }
        }

        /// <summary>O `ExecuteNonQuery` do SQLite executa um comando por vez.</summary>
        private static IEnumerable<string> Separar(string script)
        {
            StringBuilder acumulado = new StringBuilder();

            foreach (string linha in script.Split('\n'))
            {
                int comentario = linha.IndexOf("--", StringComparison.Ordinal);
                string limpa = comentario >= 0 ? linha.Substring(0, comentario) : linha;
                if (limpa.Trim().Length == 0)
                {
                    continue;
                }

                acumulado.Append(limpa).Append(' ');
                if (limpa.IndexOf(';') >= 0)
                {
                    string comando = acumulado.ToString().Trim();
                    acumulado.Length = 0;
                    if (comando.Length > 1)
                    {
                        yield return comando;
                    }
                }
            }
        }
    }
}

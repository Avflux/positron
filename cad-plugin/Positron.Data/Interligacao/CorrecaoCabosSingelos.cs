using System;
using System.Collections.Generic;
using Positron.Contract;

namespace Positron.Data.Interligacao
{
    /// <summary>
    /// O <c>CorrigeCabosSingelos</c> do <c>Correcao.cs</c> — a correção dos cabos
    /// **singelos** do catálogo (a coluna <c>Cabos</c> da tabela <c>Cabos</c>) cujo
    /// nome de veia tem o marcador <c>#</c>.
    ///
    /// O original faz duas consultas e um <c>UPDATE</c>:
    ///
    /// 1. <c>SELECT Tag FROM Cabos WHERE Cabos = 1</c> — os candidatos do catálogo;
    /// 2. para cada candidato, <c>SELECT Nome_Veia FROM Veias WHERE DWG=@dwg AND
    ///    Tag=@tag AND indice &gt; 0</c> e entra na lista quando vem **exatamente uma**
    ///    linha e o nome contém <c>#</c>;
    /// 3. <c>UPDATE Veias SET Nome_Veia='' WHERE Tag=@tag</c> — **sem** o filtro de
    ///    arquivo (quirk reproduzido: o update é mais largo que a leitura).
    ///
    /// **Achado medido:** a consulta 2 do reverso cita uma coluna <c>DWG</c> que a
    /// tabela <c>Veias</c> **não tem** — nem no <c>RCD.mdb</c> do produto (as colunas
    /// são <c>Tag, Indice, Nome_Veia, Uso, Handle, Arquivo, Pagina, Chave, Funcao</c>).
    /// O recoder usa <c>Arquivo</c>, a coluna que existe e a que o <c>LerVeias</c> já
    /// lê; com a coluna do reverso a consulta estouraria e o comando não faria nada.
    ///
    /// Depois da correção o original **sempre** chama o
    /// <c>RecriaTextosCaboEletrosul</c> — inclusive quando não há candidato.
    /// </summary>
    public static class CorrecaoCabosSingelos
    {
        /// <summary>O marcador do nome de veia que denuncia o cabo singelo (o <c>#</c> do original).</summary>
        public const string Marcador = "#";

        /// <summary>A condição da consulta 2: **uma** veia no arquivo e o nome com o marcador.</summary>
        public static bool PrecisaLimpar(int veiasNoArquivo, string nomeVeia)
        {
            return veiasNoArquivo == 1
                && nomeVeia != null
                && nomeVeia.IndexOf(Marcador, StringComparison.Ordinal) >= 0;
        }

        /// <summary>
        /// Os candidatos: os tags do catálogo (<paramref name="tagsComFlag"/>, na ordem
        /// da consulta 1) cujo arquivo tem uma veia só com o marcador no nome.
        /// </summary>
        public static IReadOnlyList<string> Candidatos(
            IReadOnlyList<string> tagsComFlag,
            IReadOnlyList<VeiasRow> veias,
            int arquivo)
        {
            List<string> candidatos = new List<string>();
            if (tagsComFlag == null)
            {
                return candidatos;
            }

            foreach (string tag in tagsComFlag)
            {
                if (string.IsNullOrEmpty(tag))
                {
                    continue;
                }

                int quantas = 0;
                string nome = null;
                if (veias != null)
                {
                    foreach (VeiasRow veia in veias)
                    {
                        if (veia == null || !string.Equals(veia.Tag, tag, StringComparison.Ordinal))
                        {
                            continue;
                        }

                        if (veia.Arquivo != arquivo || !(veia.Indice > 0))
                        {
                            continue;
                        }

                        quantas++;
                        nome = veia.Nome_Veia;
                    }
                }

                if (PrecisaLimpar(quantas, nome))
                {
                    candidatos.Add(tag);
                }
            }

            return candidatos;
        }

        /// <summary>
        /// Os tags dos trechos a limpar: o <c>Tag_Cabo</c> que está na lista de
        /// candidatos (o original varre as polilinhas e limpa o
        /// <c>NomeVeia</c> de cada uma).
        /// </summary>
        public static IReadOnlyList<string> TrechosParaLimpar(
            IReadOnlyList<string> tagsDosTrechos,
            IReadOnlyCollection<string> candidatos)
        {
            List<string> limpar = new List<string>();
            if (tagsDosTrechos == null || candidatos == null)
            {
                return limpar;
            }

            HashSet<string> alvos = new HashSet<string>(candidatos, StringComparer.Ordinal);
            foreach (string tag in tagsDosTrechos)
            {
                if (!string.IsNullOrEmpty(tag) && alvos.Contains(tag))
                {
                    limpar.Add(tag);
                }
            }

            return limpar;
        }
    }
}

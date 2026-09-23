using System;
using System.Collections.Generic;
using Positron.Contract;

namespace Positron.Data.Interligacao
{
    /// <summary>
    /// O que a expansão dos **opcionais do cabo** precisa do trecho e do catálogo —
    /// o insumo dos <c>Busca*</c> do <c>clsUtilitarios</c>.
    /// </summary>
    public sealed class ContextoOpcionais
    {
        public string TagCabo { get; set; }

        public int NumVeia { get; set; }

        public string NomeVeia { get; set; }

        /// <summary>O <c>BuscaNomeVeia</c>: o nome da veia no catálogo (ou o número, quando vazio).</summary>
        public string NomeDaVeia { get; set; }

        /// <summary>O <c>BuscaFuncaoVeia</c>.</summary>
        public string FuncaoDaVeia { get; set; }

        /// <summary>O <c>BuscaFormacoes</c>.</summary>
        public string Formacao { get; set; }
    }

    /// <summary>
    /// O <c>AtualizaOpcionaisDoCabo</c> do <c>clsUtilitarios.cs</c> — o texto do rótulo
    /// auxiliar dos tipos **3, 4, 5 e 6** (o layout ENEL/opcionais), montado a partir do
    /// campo **opcionais** do XData <c>AUXINTERLIG</c>.
    ///
    /// O campo é uma **receita** separada por <c>#</c>: cada token vira um pedaço do
    /// texto (o original compara sem caixa):
    ///
    /// | token | vira |
    /// |---|---|
    /// | <c>C</c> | a tag do cabo |
    /// | <c>V</c> | o nome da veia no catálogo (<c>BuscaNomeVeia</c>) — e, com
    ///   <c>NumVeia == -1000</c>, o texto inteiro é **zerado** |
    /// | <c>N</c> | o <c>NomeVeia</c> do trecho |
    /// | <c>FU</c> / <c>FO</c> | a função da veia / a formação do cabo |
    /// | <c>(</c> <c>)</c> <c>/</c> <c>-</c> | eles mesmos |
    /// | <c>E</c> | um espaço |
    /// | qualquer outro | nada |
    ///
    /// **Quirks reproduzidos:** o laço vai de <c>0</c> a <c>UBound - 1</c>, então o
    /// **último token é descartado** (a receita termina com o token que não entra); e a
    /// normalização é a do original — se o texto só tiver pontuação/espaço vira o
    /// caracter de terminal indefinido (<c>?</c>), <c>()</c> some, os espaços duplos
    /// colapsam em **duas** passadas e o resultado é aparado.
    /// </summary>
    public static class OpcionaisDoCabo
    {
        public const int NumVeiaIndefinido = -1000;

        /// <summary>Expande a receita de opcionais num texto de rótulo.</summary>
        public static string Expandir(string opcionais, ContextoOpcionais contexto, string caracterTerminalIndefinido)
        {
            ContextoOpcionais dados = contexto ?? new ContextoOpcionais();
            string[] tokens = (opcionais ?? string.Empty).Split('#');
            string texto = string.Empty;

            // O original percorre `0 .. UBound(array) - 1`: o último token NÃO entra.
            for (int i = 0; i <= tokens.Length - 2; i++)
            {
                string token = tokens[i];

                if (Mesmo(token, "C"))
                {
                    texto += dados.TagCabo ?? string.Empty;
                }
                else if (Mesmo(token, "V"))
                {
                    if (dados.NumVeia == NumVeiaIndefinido)
                    {
                        texto = string.Empty;
                        break;
                    }

                    texto += dados.NomeDaVeia ?? string.Empty;
                }
                else if (Mesmo(token, "N"))
                {
                    texto += dados.NomeVeia ?? string.Empty;
                }
                else if (Mesmo(token, "FU"))
                {
                    texto += dados.FuncaoDaVeia ?? string.Empty;
                }
                else if (Mesmo(token, "FO"))
                {
                    texto += dados.Formacao ?? string.Empty;
                }
                else if (Mesmo(token, "("))
                {
                    texto += "(";
                }
                else if (Mesmo(token, ")"))
                {
                    texto += ")";
                }
                else if (Mesmo(token, "/"))
                {
                    texto += "/";
                }
                else if (Mesmo(token, "E"))
                {
                    texto += " ";
                }
                else if (Mesmo(token, "-"))
                {
                    texto += "-";
                }
            }

            if (dados.NumVeia == NumVeiaIndefinido)
            {
                texto = string.Empty;
            }

            return Normalizar(texto, caracterTerminalIndefinido);
        }

        /// <summary>A normalização do original (e o <c>?</c> quando não sobra nada).</summary>
        public static string Normalizar(string texto, string caracterTerminalIndefinido)
        {
            string valor = texto ?? string.Empty;
            string semPontuacao = valor
                .Replace("(", string.Empty)
                .Replace(")", string.Empty)
                .Replace("/", string.Empty)
                .Replace(" ", string.Empty);
            if (semPontuacao.Length == 0)
            {
                return caracterTerminalIndefinido ?? string.Empty;
            }

            valor = valor.Replace("()", string.Empty);
            valor = valor.Replace("  ", " ");
            valor = valor.Replace("  ", " ");
            valor = valor.Trim();
            return valor.Length == 0 ? (caracterTerminalIndefinido ?? string.Empty) : valor;
        }

        /// <summary>O <c>BuscaNomeVeia</c>: o nome da veia (ou o número, quando o nome está vazio).</summary>
        public static string BuscarNomeDaVeia(IReadOnlyList<VeiasRow> veias, string tag, int indice)
        {
            if (veias == null)
            {
                return string.Empty;
            }

            foreach (VeiasRow veia in veias)
            {
                if (veia != null && Mesmo(veia.Tag, tag) && veia.Indice == indice)
                {
                    string nome = (veia.Nome_Veia ?? string.Empty).Trim();
                    return nome.Length != 0 ? nome : indice.ToString();
                }
            }

            return string.Empty;
        }

        /// <summary>O <c>BuscaFuncaoVeia</c>.</summary>
        public static string BuscarFuncaoDaVeia(IReadOnlyList<VeiasRow> veias, string tag, int indice)
        {
            if (veias == null)
            {
                return string.Empty;
            }

            foreach (VeiasRow veia in veias)
            {
                if (veia != null && Mesmo(veia.Tag, tag) && veia.Indice == indice)
                {
                    return veia.Funcao ?? string.Empty;
                }
            }

            return string.Empty;
        }

        /// <summary>O <c>BuscaFormacoes</c>.</summary>
        public static string BuscarFormacao(IReadOnlyList<CabosRow> cabos, string tag)
        {
            if (cabos == null)
            {
                return string.Empty;
            }

            foreach (CabosRow cabo in cabos)
            {
                if (cabo != null && Mesmo(cabo.Tag, tag))
                {
                    return cabo.Formacao ?? string.Empty;
                }
            }

            return string.Empty;
        }

        private static bool Mesmo(string a, string b)
        {
            return string.Equals(a ?? string.Empty, b ?? string.Empty, StringComparison.OrdinalIgnoreCase);
        }
    }
}

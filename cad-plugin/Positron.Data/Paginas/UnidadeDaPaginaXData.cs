using System;
using System.Collections.Generic;
using Positron.Data.Fiacao;

namespace Positron.Data.Paginas
{
    /// <summary>
    /// O XData da **unidade/alternativo** de uma pagina, gravado no <c>LayerTableRecord</c> — o
    /// <c>XDataGeral.GravarXDataUnidadeAlternativo</c>/<c>LeXDataUnidadeAlternativo</c> do original:
    /// app name <c>Eletron</c>, marca <c>Unidade</c>, a unidade e o alternativo.
    ///
    /// Layout (4 valores):
    ///
    /// | idx | codigo | campo |
    /// |-----|--------|-------|
    /// | 0 | 1001 | "Eletron" |
    /// | 1 | 1000 | "Unidade" |
    /// | 2 | 1000 | unidade |
    /// | 3 | 1000 | alternativo |
    /// </summary>
    public static class UnidadeDaPaginaXData
    {
        public const string AppName = "Eletron";

        public const string Marca = "Unidade";

        public const int QuantidadeValores = 4;

        /// <summary>uscPaginas.bt6p1Bww9xD/T5Qp1VoBCME: só a resposta do menu, sem limite de 20.</summary>
        public static string NormalizarRespostaDoMenu(string resposta)
        {
            return (resposta ?? string.Empty).ToUpper().Trim();
        }

        public static IReadOnlyList<TypedXData> ParaValores(string unidade, string alternativo)
        {
            return new List<TypedXData>
            {
                new TypedXData(1001, AppName),
                new TypedXData(1000, Marca),
                new TypedXData(1000, unidade ?? string.Empty),
                new TypedXData(1000, alternativo ?? string.Empty),
            };
        }

        /// <summary>Le a unidade e o alternativo; <c>false</c> quando o XData nao e o da pagina.</summary>
        public static bool Ler(IReadOnlyList<TypedXData> valores, out string unidade, out string alternativo)
        {
            unidade = string.Empty;
            alternativo = string.Empty;

            if (valores == null || valores.Count < QuantidadeValores)
            {
                return false;
            }

            if (valores[0].Codigo != 1001
                || !string.Equals(valores[0].Valor as string, AppName, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            if (!string.Equals(Convert.ToString(valores[1].Valor), Marca, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            unidade = valores[2].Valor == null ? string.Empty : Convert.ToString(valores[2].Valor);
            alternativo = valores[3].Valor == null ? string.Empty : Convert.ToString(valores[3].Valor);
            return true;
        }
    }
}

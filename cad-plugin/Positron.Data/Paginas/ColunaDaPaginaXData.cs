using System;
using System.Collections.Generic;
using Positron.Data.Fiacao;

namespace Positron.Data.Paginas
{
    /// <summary>
    /// O XData de uma **coluna** (as colunas de cruzamento da página) — o
    /// <c>XDataGeral.gravarXDataColuna</c> / <c>verificaXDataColunas</c> do original:
    /// app name <c>DiagLog</c>, marca <c>COLUNAS</c>, o tipo da coluna (o nome do layer do bloco
    /// de formato de onde ela veio, ex. <c>ELET1_...</c>), o usuário e a data.
    ///
    /// Layout (5 valores):
    ///
    /// | idx | código | campo |
    /// |-----|--------|-------|
    /// | 0 | 1001 | "DiagLog" |
    /// | 1 | 1000 | "COLUNAS" |
    /// | 2 | 1000 | tipo (ex. "ELET1_...") |
    /// | 3 | 1000 | usuário |
    /// | 4 | 1000 | data |
    /// </summary>
    public static class ColunaDaPaginaXData
    {
        public const string AppName = "DiagLog";

        public const string Marca = "COLUNAS";

        public const int QuantidadeValores = 5;

        public static IReadOnlyList<TypedXData> ParaValores(string tipo, string usuario, string data)
        {
            return new List<TypedXData>
            {
                new TypedXData(1001, AppName),
                new TypedXData(1000, Marca),
                new TypedXData(1000, tipo ?? string.Empty),
                new TypedXData(1000, usuario ?? string.Empty),
                new TypedXData(1000, data ?? string.Empty),
            };
        }

        /// <summary>
        /// Lê o tipo da coluna; devolve <c>false</c> quando a entidade não tem a marca de coluna
        /// (o <c>verificaXDataColunas</c> do original devolve <c>"0"</c> nesse caso).
        /// </summary>
        public static bool Ler(IReadOnlyList<TypedXData> valores, out string tipo)
        {
            tipo = null;

            if (valores == null || valores.Count < 3)
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

            tipo = Convert.ToString(valores[2].Valor) ?? string.Empty;
            return true;
        }
    }
}

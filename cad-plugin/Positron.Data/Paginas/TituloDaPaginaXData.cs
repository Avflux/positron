using System.Collections.Generic;
using Positron.Data.Fiacao;

namespace Positron.Data.Paginas
{
    /// <summary>
    /// O XData do **título de uma página** — o <c>XDataGeral.gravarXDataTitulo</c> do original: app
    /// name <c>DiagLog</c>, marca <c>TituloPagina</c>, o **índice** do título (1..9, o mapa do
    /// <see cref="CriacaoDePagina.CampoDoFormato"/>) e o valor. O usuário e a data são recarimbados,
    /// como o original faz.
    ///
    /// Layout (10 valores, do <c>gravarXDataTitulo</c>):
    ///
    /// | idx | código | campo |
    /// |-----|--------|-------|
    /// | 0 | 1001 | "DiagLog" |
    /// | 1 | 1000 | "TituloPagina" |
    /// | 2 | 1070 | índice |
    /// | 3 | 1000 | valor |
    /// | 4 | 1070 | 1 |
    /// | 5 | 1000 | usuário |
    /// | 6 | 1000 | data |
    /// | 7 | 1071 | 1 |
    /// | 8 | 1040 | 1.0 |
    /// | 9 | 1000 | " " |
    /// </summary>
    public static class TituloDaPaginaXData
    {
        public const string AppName = "DiagLog";

        public const string Marca = "TituloPagina";

        public const int QuantidadeValores = 10;

        /// <summary>Os valores do XData de um título de página.</summary>
        public static IReadOnlyList<TypedXData> ParaValores(int indice, string valor, string usuario, string data)
        {
            return new List<TypedXData>
            {
                new TypedXData(1001, AppName),
                new TypedXData(1000, Marca),
                new TypedXData(1070, indice),
                new TypedXData(1000, valor ?? string.Empty),
                new TypedXData(1070, 1),
                new TypedXData(1000, usuario ?? string.Empty),
                new TypedXData(1000, data ?? string.Empty),
                new TypedXData(1071, 1),
                new TypedXData(1040, 1.0),
                new TypedXData(1000, " "),
            };
        }
    }
}

using System.Collections.Generic;
using Positron.Data.Fiacao;
#if AUTOCAD
using Autodesk.AutoCAD.DatabaseServices;
#else
using ZwSoft.ZwCAD.DatabaseServices;
#endif

namespace Positron.Plugin
{
    /// <summary>
    /// Traduz o <see cref="ResultBuffer"/> do ZWCAD para a forma neutra
    /// (<see cref="TypedXData"/>), que os leitores puros de <c>Positron.Data</c>
    /// consomem sem depender do ZWCAD.
    /// </summary>
    internal static class XDataNeutro
    {
        internal static IReadOnlyList<TypedXData> Para(ResultBuffer xdata)
        {
            TypedValue[] valores = xdata.AsArray();
            List<TypedXData> lista = new List<TypedXData>(valores.Length);
            foreach (TypedValue valor in valores)
            {
                lista.Add(new TypedXData(valor.TypeCode, valor.Value));
            }

            return lista;
        }
    }
}

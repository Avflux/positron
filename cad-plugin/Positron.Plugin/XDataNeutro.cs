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
            if (xdata == null)
            {
                return new List<TypedXData>();
            }

            TypedValue[] valores = xdata.AsArray();
            List<TypedXData> lista = new List<TypedXData>(valores.Length);
            foreach (TypedValue valor in valores)
            {
                lista.Add(new TypedXData(valor.TypeCode, valor.Value));
            }

            return lista;
        }

        /// <summary>
        /// Lê o conteúdo de um <c>Xrecord</c> do dicionário nomeado.
        ///
        /// <c>Xrecord.Data</c> **lança** no ZWCAD quando o registro existe mas está
        /// vazio (<c>InvalidOperationException</c> em <c>ResultBuffer..ctor</c>) —
        /// medido no desenho real, em <c>CENG_BORNES</c>. Registro degenerado é dado
        /// de terceiro: a leitura devolve vazio em vez de derrubar o comando.
        /// </summary>
        internal static IReadOnlyList<TypedXData> Para(Xrecord registro)
        {
            if (registro == null)
            {
                return new List<TypedXData>();
            }

            ResultBuffer dados;
            try
            {
                dados = registro.Data;
            }
            catch (System.Exception)
            {
                return new List<TypedXData>();
            }

            return Para(dados);
        }
    }
}

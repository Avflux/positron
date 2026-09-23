using System.Collections.Generic;
using Positron.Data.Fiacao;
using Positron.Data.Modelos;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
#endif

namespace Positron.Plugin.Modelos
{
    /// <summary>
    /// Lê os bornes de reserva de uma régua do dicionário
    /// <c>CENG_BORNES → "&lt;indexRegua&gt;"</c> do desenho (o
    /// <c>DicionarioBorne.LeDicBornesReserva</c> do original).
    /// </summary>
    public static class BornesReservaDoDesenho
    {
        public static List<BorneReserva> Ler(int indexRegua)
        {
            IReadOnlyList<TypedXData> valores = LerValores(indexRegua);
            return valores == null ? new List<BorneReserva>() : BornesReserva.Ler(valores);
        }

        /// <summary>
        /// As ordens já ocupadas pelas reservas da régua
        /// (<c>DicionarioBorne.LeOrdemDicBornesReserva</c>) — o insumo da correção
        /// de ordem dos bornes.
        /// </summary>
        public static List<int> LerOrdensReservadas(int indexRegua)
        {
            IReadOnlyList<TypedXData> valores = LerValores(indexRegua);
            return valores == null ? new List<int>() : BornesReserva.OrdensReservadas(valores);
        }

        private static IReadOnlyList<TypedXData> LerValores(int indexRegua)
        {
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return null;
            }

            Database banco = documento.Database;
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                DBDictionary raiz = transacao.GetObject(banco.NamedObjectsDictionaryId, OpenMode.ForRead) as DBDictionary;
                string chave = indexRegua.ToString();
                if (raiz == null || !raiz.Contains("CENG_BORNES"))
                {
                    transacao.Commit();
                    return null;
                }

                DBDictionary bornes = transacao.GetObject(raiz.GetAt("CENG_BORNES"), OpenMode.ForRead) as DBDictionary;
                if (bornes == null || !bornes.Contains(chave))
                {
                    transacao.Commit();
                    return null;
                }

                Xrecord registro = transacao.GetObject(bornes.GetAt(chave), OpenMode.ForRead) as Xrecord;
                IReadOnlyList<TypedXData> valores = registro == null
                    ? null
                    : XDataNeutro.Para(registro);
                transacao.Commit();
                return valores;
            }
        }
    }
}

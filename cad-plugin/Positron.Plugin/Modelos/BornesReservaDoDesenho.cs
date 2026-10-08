using System.Collections.Generic;
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
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return new List<BorneReserva>();
            }

            Database banco = documento.Database;
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                DBDictionary raiz = transacao.GetObject(banco.NamedObjectsDictionaryId, OpenMode.ForRead) as DBDictionary;
                string chave = indexRegua.ToString();
                if (raiz == null || !raiz.Contains("CENG_BORNES"))
                {
                    transacao.Commit();
                    return new List<BorneReserva>();
                }

                DBDictionary bornes = transacao.GetObject(raiz.GetAt("CENG_BORNES"), OpenMode.ForRead) as DBDictionary;
                if (bornes == null || !bornes.Contains(chave))
                {
                    transacao.Commit();
                    return new List<BorneReserva>();
                }

                Xrecord registro = transacao.GetObject(bornes.GetAt(chave), OpenMode.ForRead) as Xrecord;
                List<BorneReserva> reservas = registro == null || registro.Data == null
                    ? new List<BorneReserva>()
                    : BornesReserva.Ler(XDataNeutro.Para(registro.Data));
                transacao.Commit();
                return reservas;
            }
        }
    }
}

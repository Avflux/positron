using System.Collections.Generic;
using Positron.Data.Paginas;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
#endif

namespace Positron.Plugin.Paginas
{
    /// <summary>
    /// Lê as **páginas do caderno** do desenho: os layers que passam no <c>LayerValido</c> do
    /// reverso, na ordem da regra (<see cref="PaginaNumerada.Decimal"/>).
    ///
    /// É o I/O da frente 10: a regra é pura (<see cref="PaginasDoCaderno"/>), a tela é a
    /// <c>JanelaDeFolhas</c> e este adapter só lê o desenho.
    /// </summary>
    internal static class PaginasDoDesenho
    {
        internal static List<string> Ler()
        {
            List<string> paginas = new List<string>();
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return paginas;
            }

            using (Transaction transacao = documento.Database.TransactionManager.StartTransaction())
            {
                LayerTable tabela = (LayerTable)transacao.GetObject(
                    documento.Database.LayerTableId, OpenMode.ForRead);
                foreach (ObjectId id in tabela)
                {
                    LayerTableRecord layer = transacao.GetObject(id, OpenMode.ForRead) as LayerTableRecord;
                    if (layer == null || !PaginasDoCaderno.LayerValido(layer.Name))
                    {
                        continue;
                    }

                    paginas.Add(layer.Name);
                }

                transacao.Commit();
            }

            paginas.Sort((a, b) => PaginaNumerada.Decimal(a).CompareTo(PaginaNumerada.Decimal(b)));
            return paginas;
        }
    }
}

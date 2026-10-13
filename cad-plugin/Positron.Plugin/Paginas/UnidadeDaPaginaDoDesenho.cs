using System;
using Positron.Data.Paginas;
using Positron.Plugin.Bornes;
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
    /// A **unidade e o alternativo** de uma pagina: o XData <c>Eletron</c> do <c>LayerTableRecord</c>
    /// (o <c>GravarXDataUnidadeAlternativo</c>/<c>LeXDataUnidadeAlternativo</c> do original). E o que as
    /// colunas da grade das folhas mostram e o que o <c>CriarLayer</c> grava quando a pagina nasce.
    /// </summary>
    internal static class UnidadeDaPaginaDoDesenho
    {
        /// <summary>A unidade e o alternativo da pagina (vazios quando ela nao tem XData).</summary>
        internal static void Ler(string pagina, out string unidade, out string alternativo)
        {
            unidade = string.Empty;
            alternativo = string.Empty;

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null || string.IsNullOrEmpty(pagina))
            {
                return;
            }

            Database banco = documento.Database;
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                LayerTable camadas = (LayerTable)transacao.GetObject(banco.LayerTableId, OpenMode.ForRead);
                if (!camadas.Has(pagina))
                {
                    transacao.Commit();
                    return;
                }

                LayerTableRecord layer = (LayerTableRecord)transacao.GetObject(camadas[pagina], OpenMode.ForRead);
                ResultBuffer xdata = layer.GetXDataForApplication(UnidadeDaPaginaXData.AppName);
                if (xdata != null)
                {
                    UnidadeDaPaginaXData.Ler(XDataNeutro.Para(xdata), out unidade, out alternativo);
                }

                transacao.Commit();
            }
        }

        /// <summary>Grava a unidade e o alternativo no layer da pagina. Devolve <c>false</c> sem o layer.</summary>
        internal static bool Gravar(string pagina, string unidade, string alternativo)
        {
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null || string.IsNullOrEmpty(pagina))
            {
                return false;
            }

            Database banco = documento.Database;
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                LayerTable camadas = (LayerTable)transacao.GetObject(banco.LayerTableId, OpenMode.ForRead);
                if (!camadas.Has(pagina))
                {
                    transacao.Commit();
                    return false;
                }

                camadas.UpgradeOpen();
                LayerTableRecord layer = (LayerTableRecord)transacao.GetObject(camadas[pagina], OpenMode.ForWrite);
                BornesDaCorrecao.GarantirAppName(transacao, banco, UnidadeDaPaginaXData.AppName);
                layer.XData = BornesDaCorrecao.ParaResultBuffer(UnidadeDaPaginaXData.ParaValores(unidade, alternativo));
                transacao.Commit();
            }

            return true;
        }
    }
}

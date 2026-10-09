using System.Collections.Generic;
using Positron.Data.Fiacao;
using Positron.Data.Layout;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
#endif

namespace Positron.Plugin.Layout
{
    /// <summary>
    /// Monta a **matriz de páginas** do desenho a partir da <c>LayerTable</c> —
    /// o <c>Pagina.CarregaPaginas</c> do original: cada layer que passa no
    /// <see cref="PaginaMatrix.LayerValido"/> vira uma página, com a
    /// <c>unidade</c> e o <c>alternativo</c> lidos do XData do app
    /// <c>Eletron</c> (marcador <c>UNIDADE</c>).
    /// </summary>
    public static class PaginasDoDesenho
    {
        private const string AppName = "Eletron";
        private const string MarcadorUnidade = "UNIDADE";

        public static PaginaMatrix Ler()
        {
            List<PaginaDesenho> paginas = new List<PaginaDesenho>();

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return PaginaMatrix.Vazia;
            }

            Database banco = documento.Database;

            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                LayerTable tabela = transacao.GetObject(banco.LayerTableId, OpenMode.ForRead) as LayerTable;
                if (tabela == null)
                {
                    transacao.Commit();
                    return PaginaMatrix.Vazia;
                }

                foreach (ObjectId id in tabela)
                {
                    LayerTableRecord layer = transacao.GetObject(id, OpenMode.ForRead) as LayerTableRecord;
                    if (layer == null || !PaginaMatrix.LayerValido(layer.Name))
                    {
                        continue;
                    }

                    string unidade;
                    string alternativo;
                    LerUnidadeAlternativo(layer, out unidade, out alternativo);

                    paginas.Add(new PaginaDesenho
                    {
                        Pagina = layer.Name,
                        Unidade = unidade,
                        Alternativo = alternativo,
                    });
                }

                transacao.Commit();
            }

            return PaginaMatrix.Ler(paginas);
        }

        /// <summary>
        /// Lê <c>unidade</c>/<c>alternativo</c> do XData <c>Eletron</c> do layer —
        /// o <c>XDataGeral.LeXDataUnidadeAlternativo</c>: o valor 1 tem que ser
        /// <c>UNIDADE</c>, e os valores 2/3 são os textos.
        /// </summary>
        private static void LerUnidadeAlternativo(
            LayerTableRecord layer,
            out string unidade,
            out string alternativo)
        {
            unidade = string.Empty;
            alternativo = string.Empty;

            ResultBuffer xdata = layer.GetXDataForApplication(AppName);
            if (xdata == null)
            {
                return;
            }

            IReadOnlyList<TypedXData> valores = XDataNeutro.Para(xdata);
            if (valores.Count < 4)
            {
                return;
            }

            string marcador = valores[1].Valor == null
                ? string.Empty
                : valores[1].Valor.ToString().ToUpperInvariant();
            if (marcador != MarcadorUnidade)
            {
                return;
            }

            unidade = Texto(valores[2].Valor);
            alternativo = Texto(valores[3].Valor);
        }

        private static string Texto(object valor)
        {
            return valor == null || valor is System.DBNull ? string.Empty : System.Convert.ToString(valor);
        }
    }
}

using System.Collections.Generic;
using Positron.Data.Fiacao;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
#endif

namespace Positron.Plugin.Fiacao
{
    /// <summary>
    /// Lê os trechos de fiação do desenho (handle, página, potencial, tipo e as duas
    /// pontas) — o insumo da regra de **fiação duplicada** do original
    /// (<c>LFiacaoTTDuplicada</c>), que compara trechos <c>Tipo 2</c> com as mesmas
    /// pontas na mesma página.
    ///
    /// É separado do <see cref="FiacaoDoDesenho"/> porque aquele devolve *pontos de
    /// fiação* (filtrados por <c>Tipo</c>/<c>Disp</c>) e aqui interessam os *trechos
    /// completos*, independentemente de gerarem ponto. O XData é lido com o mesmo
    /// <see cref="ConexaoXData"/> e <c>entget</c> tolerante dos outros adapters.
    /// </summary>
    public static class TrechosDoDesenho
    {
        public static IReadOnlyList<TrechoFiacao> Ler()
        {
            List<TrechoFiacao> trechos = new List<TrechoFiacao>();

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return trechos;
            }

            Database banco = documento.Database;

            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTable tabela = (BlockTable)transacao.GetObject(banco.BlockTableId, OpenMode.ForRead);
                BlockTableRecord espaco = (BlockTableRecord)transacao.GetObject(
                    tabela[BlockTableRecord.ModelSpace],
                    OpenMode.ForRead);

                foreach (ObjectId id in espaco)
                {
                    Polyline linha = transacao.GetObject(id, OpenMode.ForRead) as Polyline;
                    if (linha == null || linha.NumberOfVertices == 0)
                    {
                        continue;
                    }

                    ResultBuffer xdata = ((DBObject)linha).GetXDataForApplication(ConexaoXData.AppName);
                    if (xdata == null)
                    {
                        continue;
                    }

                    ConexaoXData conexao;
                    if (!ConexaoXData.Ler(XDataNeutro.Para(xdata), out conexao))
                    {
                        continue;
                    }

                    Point2d inicio = linha.GetPoint2dAt(0);
                    Point2d fim = linha.GetPoint2dAt(linha.NumberOfVertices - 1);

                    trechos.Add(new TrechoFiacao
                    {
                        Handle = ((DBObject)linha).Handle.ToString(),
                        Pagina = ((Entity)linha).Layer,
                        Potencial = conexao.Potencial,
                        Tipo = conexao.Tipo,
                        IniX = inicio.X,
                        IniY = inicio.Y,
                        FimX = fim.X,
                        FimY = fim.Y,
                    });
                }

                transacao.Commit();
            }

            return trechos;
        }
    }
}

using System.Collections.Generic;
using Positron.Data.Bornes;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;

namespace Positron.Plugin.Bornes
{
    /// <summary>
    /// Varre o ModelSpace atrás de blocos de **borne** — <c>BlockReference</c> com
    /// XData <c>Dispositivo</c> tipo <c>"B"</c> — e devolve os bornes já em tipos
    /// neutros (<see cref="PontoBorne"/>).
    ///
    /// A régua e o painel de cada borne são resolvidos pelo dicionário
    /// (<see cref="ReguasModelo"/>), que o chamador carrega do próprio desenho
    /// (<see cref="ReguasDoDesenho"/>).
    /// </summary>
    public static class BornesDoDesenho
    {
        public static IReadOnlyList<PontoBorne> Ler(ReguasModelo reguas)
        {
            List<PontoBorne> bornes = new List<PontoBorne>();

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return bornes;
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
                    BlockReference bloco = transacao.GetObject(id, OpenMode.ForRead) as BlockReference;
                    if (bloco == null)
                    {
                        continue;
                    }

                    ResultBuffer xdata = bloco.GetXDataForApplication(BorneXData.AppName);
                    if (xdata == null)
                    {
                        xdata = bloco.GetXDataForApplication(BorneXData.AppNameLegado);
                    }

                    if (xdata == null)
                    {
                        continue;
                    }

                    BorneXData borne;
                    if (!BorneXData.Ler(XDataNeutro.Para(xdata), out borne))
                    {
                        continue;
                    }

                    bornes.Add(PontoBorne.DeBorne(
                        borne,
                        bloco.Handle.ToString(),
                        bloco.Layer,
                        bloco.Position.X,
                        bloco.Position.Y,
                        reguas));
                }

                transacao.Commit();
            }

            return bornes;
        }
    }
}

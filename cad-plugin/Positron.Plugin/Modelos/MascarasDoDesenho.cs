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
    /// Varre os blocos de **máscara** do ModelSpace (XData <c>Dispositivo</c> tipo
    /// <c>"M"</c>) para descobrir quais modelos estão em uso e em que painéis —
    /// o <c>clsDispositivoTacito.carregaModelosUsadosMascaras</c> do original.
    ///
    /// O original ainda filtra pelos painéis escolhidos na tela; aqui os painéis
    /// são os próprios painéis das máscaras encontradas.
    /// </summary>
    public static class MascarasDoDesenho
    {
        public sealed class EmUso
        {
            public List<int> Modelos { get; set; }

            public List<int> Paineis { get; set; }
        }

        public static EmUso Ler()
        {
            EmUso emUso = new EmUso { Modelos = new List<int>(), Paineis = new List<int>() };

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return emUso;
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

                    ResultBuffer xdata = bloco.GetXDataForApplication(MascaraXData.AppName);
                    if (xdata == null)
                    {
                        continue;
                    }

                    MascaraXData mascara;
                    if (!MascaraXData.Ler(XDataNeutro.Para(xdata), out mascara))
                    {
                        continue;
                    }

                    if (mascara.Complementar || mascara.IndexModelo <= 0)
                    {
                        continue;
                    }

                    if (!emUso.Paineis.Contains(mascara.Painel))
                    {
                        emUso.Paineis.Add(mascara.Painel);
                    }

                    if (!emUso.Modelos.Contains(mascara.IndexModelo))
                    {
                        emUso.Modelos.Add(mascara.IndexModelo);
                    }
                }

                transacao.Commit();
            }

            return emUso;
        }
    }
}

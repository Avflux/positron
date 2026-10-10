using System;
using System.Collections.Generic;
using Positron.Data.Bornes;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.GraphicsInterface;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.GraphicsInterface;
#endif

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

                    PontoBorne ponto = PontoBorne.DeBorne(
                        borne,
                        bloco.Handle.ToString(),
                        bloco.Layer,
                        bloco.Position.X,
                        bloco.Position.Y,
                        reguas);

                    // Nome do bloco (chave da tabela de deslocamento) e a
                    // bounding-box (filtro ±0,25 do casamento).
                    ponto.NomeBloco = bloco.Name;

                    // Número visível (atributo `T1`): base do `bt9Discrepantes`, que
                    // compara o que está impresso no bloco com o número da régua.
                    ponto.NumeroVisivel = LerAtributo(transacao, bloco, "T1");
                    Extents3d? bounds = ((Drawable)bloco).Bounds;
                    if (bounds.HasValue)
                    {
                        ponto.TemBounds = true;
                        ponto.MinX = bounds.Value.MinPoint.X;
                        ponto.MinY = bounds.Value.MinPoint.Y;
                        ponto.MaxX = bounds.Value.MaxPoint.X;
                        ponto.MaxY = bounds.Value.MaxPoint.Y;
                    }

                    bornes.Add(ponto);
                }

                transacao.Commit();
            }

            return bornes;
        }

        /// <summary>
        /// Lê o texto de um atributo do bloco pela tag (sem diferenciar maiúsculas),
        /// como o <c>clsBlocos.LeUmAtributoDeUmBloco</c> do original: devolve vazio
        /// quando a tag não existe.
        /// </summary>
        private static string LerAtributo(Transaction transacao, BlockReference bloco, string tag)
        {
            foreach (ObjectId idAtributo in bloco.AttributeCollection)
            {
                AttributeReference atributo = transacao.GetObject(idAtributo, OpenMode.ForRead) as AttributeReference;
                if (atributo != null && string.Equals(atributo.Tag, tag, StringComparison.OrdinalIgnoreCase))
                {
                    return atributo.TextString ?? string.Empty;
                }
            }

            return string.Empty;
        }
    }
}

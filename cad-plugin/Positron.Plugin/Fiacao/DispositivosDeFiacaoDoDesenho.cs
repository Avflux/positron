using System.Collections.Generic;
using Positron.Data.Fiacao;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
#endif

namespace Positron.Plugin.Fiacao
{
    /// <summary>
    /// Varre o ModelSpace atrás dos blocos de **dispositivo** e devolve-os em
    /// tipos neutros (<see cref="DispositivoFiacao"/>) — a base da varredura que
    /// dá a **tag** ao ponto de fiação **não-borne** (<c>verificaTipoDispositivo</c>
    /// + <c>LeXDataQualquerDispositivo</c> do original).
    ///
    /// Lê os dois app names: <c>Dispositivo</c>/<c>DISPOSITIVO</c> (tipos
    /// <c>P</c>/<c>E</c>/<c>A</c>/<c>M</c>) e <c>IMPORTADO</c> (tipo <c>I</c>).
    /// O <c>B</c> é borne (<see cref="Positron.Plugin.Bornes.BornesDoDesenho"/>) e
    /// é ignorado aqui.
    ///
    /// Em <c>E</c>/<c>A</c> o painel não está no próprio bloco: o original o lê do
    /// bloco da **máscara** apontado por <c>array[4]</c>
    /// (<c>BuscaPainelDispositivo</c>). O adapter resolve isso aqui, dentro da
    /// mesma transação.
    /// </summary>
    public static class DispositivosDeFiacaoDoDesenho
    {
        public static IReadOnlyList<DispositivoFiacao> Ler()
        {
            List<DispositivoFiacao> dispositivos = new List<DispositivoFiacao>();

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return dispositivos;
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

                    DispositivoFiacao dispositivo;
                    if (!LerIdentidade(bloco, out dispositivo))
                    {
                        continue;
                    }

                    dispositivo.Handle = bloco.Handle.ToString();
                    dispositivo.Layer = bloco.Layer;
                    dispositivo.X = bloco.Position.X;
                    dispositivo.Y = bloco.Position.Y;
                    dispositivo.NomeBloco = bloco.Name;

                    // Atributos de terminal (T*/B*): o núcleo só casa o bloco
                    // que tira um terminal não-vazio (ltZUHdAX7R).
                    LerTerminais(transacao, bloco, dispositivo);

                    Extents3d? bounds = ((Drawable)bloco).Bounds;
                    if (bounds.HasValue)
                    {
                        dispositivo.TemBounds = true;
                        dispositivo.MinX = bounds.Value.MinPoint.X;
                        dispositivo.MinY = bounds.Value.MinPoint.Y;
                        dispositivo.MaxX = bounds.Value.MaxPoint.X;
                        dispositivo.MaxY = bounds.Value.MaxPoint.Y;
                    }

                    if (dispositivo.PainelPendente)
                    {
                        ResolverPainel(banco, transacao, dispositivo);
                    }

                    dispositivos.Add(dispositivo);
                }

                transacao.Commit();
            }

            return dispositivos;
        }

        /// <summary>Lê o XData do bloco: primeiro o app de dispositivo, depois o de importado.</summary>
        private static bool LerIdentidade(BlockReference bloco, out DispositivoFiacao dispositivo)
        {
            dispositivo = null;

            ResultBuffer xdata = bloco.GetXDataForApplication(DispositivoFiacaoXData.AppName);
            if (xdata == null)
            {
                xdata = bloco.GetXDataForApplication(DispositivoFiacaoXData.AppNameLegado);
            }

            if (xdata != null)
            {
                return DispositivoFiacaoXData.Ler(XDataNeutro.Para(xdata), out dispositivo);
            }

            ResultBuffer importado = bloco.GetXDataForApplication(DispositivoFiacaoXData.AppNameImportado);
            if (importado == null)
            {
                return false;
            }

            return DispositivoFiacaoXData.LerImportado(XDataNeutro.Para(importado), out dispositivo);
        }

        /// <summary>
        /// Lê os atributos de terminal do bloco (<c>T*</c>/<c>B*</c>) para o campo
        /// <see cref="DispositivoFiacao.Terminais"/>. O adapter só lê o atributo
        /// cru (tag, texto e posição); a escolha do mais próximo e a exigência de
        /// terminal não-vazio ficam no núcleo (<see cref="CasamentoDispositivo"/>).
        ///
        /// A posição segue o original: o <c>AlignmentPoint</c> quando o texto não
        /// está no modo de justificação padrão, senão o <c>Position</c>.
        /// </summary>
        private static void LerTerminais(Transaction transacao, BlockReference bloco, DispositivoFiacao dispositivo)
        {
            foreach (ObjectId idAtributo in bloco.AttributeCollection)
            {
                AttributeReference atributo = transacao.GetObject(idAtributo, OpenMode.ForRead) as AttributeReference;
                if (atributo == null)
                {
                    continue;
                }

                Point3d posicao = (int)atributo.Justify != 10 ? atributo.AlignmentPoint : atributo.Position;
                dispositivo.Terminais.Add(new TerminalDispositivo
                {
                    Atributo = atributo.Tag,
                    Texto = atributo.TextString,
                    X = posicao.X,
                    Y = posicao.Y,
                });
            }
        }

        /// <summary>
        /// Resolve o painel do <c>E</c>/<c>A</c> a partir do bloco da máscara
        /// (<c>HandleMascara</c>): lê o <c>array[8]</c> do XData de dispositivo do
        /// bloco apontado.
        /// </summary>
        private static void ResolverPainel(Database banco, Transaction transacao, DispositivoFiacao dispositivo)
        {
            if (string.IsNullOrEmpty(dispositivo.HandleMascara))
            {
                return;
            }

            ObjectId id;
            if (!banco.TryGetObjectId(new Handle(dispositivo.HandleMascara), out id))
            {
                return;
            }

            BlockReference mascara = transacao.GetObject(id, OpenMode.ForRead) as BlockReference;
            if (mascara == null)
            {
                return;
            }

            ResultBuffer xdata = mascara.GetXDataForApplication(DispositivoFiacaoXData.AppName);
            if (xdata == null)
            {
                xdata = mascara.GetXDataForApplication(DispositivoFiacaoXData.AppNameLegado);
            }

            if (xdata == null)
            {
                return;
            }

            short painel;
            if (DispositivoFiacaoXData.LerPainel(XDataNeutro.Para(xdata), out painel))
            {
                dispositivo.DefinirPainel(painel);
            }
        }
    }
}

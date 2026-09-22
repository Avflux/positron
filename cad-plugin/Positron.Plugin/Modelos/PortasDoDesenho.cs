using System;
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
    /// Varre o ModelSpace atrás dos blocos de **porta** (XData <c>Dispositivo</c>
    /// tipo <c>E</c>) e devolve o handle, o modelo/porta referenciados e os
    /// atributos <c>T*</c>/<c>B*</c>/<c>R*</c> — o insumo do
    /// <c>bt14PortasDiscrepantes</c> (<c>clsPortas.VerificaPortasDiscrepantes</c>,
    /// alimentado por <c>CarregaTodasAsPortasPortas</c>).
    ///
    /// Só entram blocos com <c>indiceDaPorta != 0</c>, como no original. O XData é o
    /// mesmo layout de <c>E</c>/<c>A</c> (<see cref="DispositivoFiacaoXData"/>) e os
    /// atributos são lidos crus (tag, texto e visibilidade); a comparação com a
    /// definição do modelo fica no núcleo (<c>VerificadorProjeto.VerificarPortasDiscrepantes</c>).
    /// </summary>
    public static class PortasDoDesenho
    {
        public static IReadOnlyList<PortaNoDesenho> Ler()
        {
            List<PortaNoDesenho> portas = new List<PortaNoDesenho>();

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return portas;
            }

            Database banco = documento.Database;
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTable tabela = (BlockTable)transacao.GetObject(banco.BlockTableId, OpenMode.ForRead);
                BlockTableRecord espaco = (BlockTableRecord)transacao.GetObject(
                    tabela[BlockTableRecord.ModelSpace], OpenMode.ForRead);

                foreach (ObjectId id in espaco)
                {
                    BlockReference bloco = transacao.GetObject(id, OpenMode.ForRead) as BlockReference;
                    if (bloco == null)
                    {
                        continue;
                    }

                    DispositivoFiacao dispositivo;
                    if (!LerDispositivo(bloco, out dispositivo))
                    {
                        continue;
                    }

                    if (!string.Equals(dispositivo.Tipo, DispositivoFiacaoXData.TipoPorta, StringComparison.Ordinal)
                        || dispositivo.IndiceDaPorta == 0)
                    {
                        continue;
                    }

                    if (dispositivo.PainelPendente)
                    {
                        ResolverPainel(banco, transacao, dispositivo);
                    }

                    PortaNoDesenho porta = new PortaNoDesenho
                    {
                        Handle = bloco.Handle.ToString(),
                        IndiceModelo = dispositivo.IndexModelo,
                        IndiceDaPorta = dispositivo.IndiceDaPorta,
                        Nome1 = dispositivo.Nome1,
                        Nome2 = dispositivo.Nome2,
                        Painel = dispositivo.Painel,
                    };

                    LerAtributos(transacao, bloco, porta);
                    portas.Add(porta);
                }

                transacao.Commit();
            }

            return portas;
        }

        /// <summary>Lê o XData <c>Dispositivo</c>/<c>DISPOSITIVO</c> do bloco.</summary>
        private static bool LerDispositivo(BlockReference bloco, out DispositivoFiacao dispositivo)
        {
            dispositivo = null;

            ResultBuffer xdata = bloco.GetXDataForApplication(DispositivoFiacaoXData.AppName);
            if (xdata == null)
            {
                xdata = bloco.GetXDataForApplication(DispositivoFiacaoXData.AppNameLegado);
            }

            if (xdata == null)
            {
                return false;
            }

            return DispositivoFiacaoXData.Ler(XDataNeutro.Para(xdata), out dispositivo);
        }

        /// <summary>
        /// Resolve o painel do <c>E</c> a partir do bloco da máscara
        /// (<c>HandleMascara</c>, o <c>array[4]</c> do XData): lê o <c>array[8]</c>
        /// do XData de dispositivo do bloco apontado — o mesmo
        /// <c>BuscaPainelDispositivo</c> do adapter da fiação.
        /// </summary>
        private static void ResolverPainel(Database banco, Transaction transacao, DispositivoFiacao dispositivo)
        {
            if (string.IsNullOrEmpty(dispositivo.HandleMascara))
            {
                return;
            }

            ObjectId id;
            if (!banco.TryGetObjectId(new Handle(Convert.ToInt64(dispositivo.HandleMascara, 16)), out id))
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

        /// <summary>Lê os atributos do bloco (tag, texto, visibilidade) para a porta.</summary>
        private static void LerAtributos(Transaction transacao, BlockReference bloco, PortaNoDesenho porta)
        {
            foreach (ObjectId idAtributo in bloco.AttributeCollection)
            {
                AttributeReference atributo = transacao.GetObject(idAtributo, OpenMode.ForRead) as AttributeReference;
                if (atributo == null)
                {
                    continue;
                }

                porta.Atributos.Add(new AtributoPorta
                {
                    Tag = atributo.Tag,
                    Texto = atributo.TextString,
                    Visivel = !atributo.Invisible,
                });
            }
        }
    }
}

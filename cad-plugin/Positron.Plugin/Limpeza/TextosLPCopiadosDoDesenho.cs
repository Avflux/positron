using System;
using System.Collections.Generic;
using Positron.Data.Fiacao;
using Positron.Data.Limpeza;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.GraphicsInterface;
using Polyline = Autodesk.AutoCAD.DatabaseServices.Polyline;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.GraphicsInterface;
using Polyline = ZwSoft.ZwCAD.DatabaseServices.Polyline;
#endif

namespace Positron.Plugin.Limpeza
{
    /// <summary>
    /// <c>LimpaTextosLPCopiados</c> — a sexta limpeza da frente 2 do §7.6 (o
    /// <c>Correcao.cs</c>): tira o XData <c>TextoLP</c> (o rótulo copiado de outra
    /// página) dos textos do ModelSpace.
    ///
    /// A regra é pura (ver <see cref="LimpezaDoDesenho.ApagarXDataTextoLP"/>): o
    /// <c>DBText</c> sai **sempre** e o <c>MText</c> só quando está **abaixo do topo**
    /// do desenho — o maior Y arredondado das polilinhas <c>CONEXAO</c> do tipo 1, que
    /// a primeira varredura mede. O XData é trocado pela **marca única** do
    /// <c>LimpaXData</c> do original (some o conteúdo do <c>TextoLP</c>; os outros app
    /// names do texto também, como no original).
    /// </summary>
    internal static class TextosLPCopiadosDoDesenho
    {
        internal sealed class Resultado
        {
            /// <summary>O topo do desenho (o maior Y; começa em -1000, como o original).</summary>
            internal double Topo { get; set; }

            internal int MTextosLidos { get; set; }

            internal int TextosLidos { get; set; }

            /// <summary>Textos que têm o XData <c>TextoLP</c>.</summary>
            internal int ComTextoLP { get; set; }

            /// <summary>Textos cujo XData foi trocado pela marca.</summary>
            internal int Limpos { get; set; }
        }

        internal static Resultado Executar()
        {
            Resultado resultado = new Resultado { Topo = -1000.0 };

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return resultado;
            }

            Database banco = documento.Database;
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTableRecord espaco = EspacoDeModelo(transacao, banco);

                // Fase 1 — o topo do desenho (as CONEXAO tipo 1).
                foreach (ObjectId id in espaco)
                {
                    Polyline linha = transacao.GetObject(id, OpenMode.ForRead) as Polyline;
                    if (linha == null)
                    {
                        continue;
                    }

                    ResultBuffer xdata = linha.GetXDataForApplication(ConexaoXData.AppName);
                    ConexaoXData conexao;
                    if (xdata == null || !ConexaoXData.Ler(XDataNeutro.Para(xdata), out conexao))
                    {
                        continue;
                    }

                    if (conexao.Tipo != 1)
                    {
                        continue;
                    }

                    Extents3d? limites = ((Drawable)linha).Bounds;
                    if (!limites.HasValue)
                    {
                        continue;
                    }

                    double y = Math.Round(limites.Value.MaxPoint.Y, 2);
                    if (resultado.Topo < y)
                    {
                        resultado.Topo = y;
                    }
                }

                // Fase 2 — os textos com o XData `TextoLP`.
                foreach (ObjectId id in espaco)
                {
                    Entity entidade = transacao.GetObject(id, OpenMode.ForRead) as Entity;
                    if (entidade == null)
                    {
                        continue;
                    }

                    bool ehMText = entidade is MText;
                    if (!ehMText && !(entidade is DBText))
                    {
                        continue;
                    }

                    if (ehMText)
                    {
                        resultado.MTextosLidos++;
                    }
                    else
                    {
                        resultado.TextosLidos++;
                    }

                    if (entidade.GetXDataForApplication(LimpezaDoDesenho.AppNameTextoLP) == null)
                    {
                        continue;
                    }

                    resultado.ComTextoLP++;

                    double maxY = 0.0;
                    if (ehMText)
                    {
                        Extents3d? limites = ((Drawable)entidade).Bounds;
                        if (limites.HasValue)
                        {
                            maxY = limites.Value.MaxPoint.Y;
                        }
                    }

                    if (!LimpezaDoDesenho.ApagarXDataTextoLP(ehMText, true, resultado.Topo, maxY))
                    {
                        continue;
                    }

                    entidade.UpgradeOpen();
                    entidade.XData = ParaResultBuffer(
                        LimpezaDoDesenho.MarcaUnica(LimpezaDoDesenho.AppNameTextoLP));
                    resultado.Limpos++;
                }

                transacao.Commit();
            }

            return resultado;
        }

        private static BlockTableRecord EspacoDeModelo(Transaction transacao, Database banco)
        {
            BlockTable tabela = (BlockTable)transacao.GetObject(banco.BlockTableId, OpenMode.ForRead);
            return (BlockTableRecord)transacao.GetObject(tabela[BlockTableRecord.ModelSpace], OpenMode.ForRead);
        }

        private static ResultBuffer ParaResultBuffer(IReadOnlyList<TypedXData> valores)
        {
            TypedValue[] array = new TypedValue[valores.Count];
            for (int i = 0; i < valores.Count; i++)
            {
                array[i] = new TypedValue(valores[i].Codigo, valores[i].Valor);
            }

            return new ResultBuffer(array);
        }
    }
}

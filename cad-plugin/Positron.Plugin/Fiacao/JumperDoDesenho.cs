using System;
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
    /// Varre o ModelSpace atrás das **conexões de jumper** e devolve os pontos
    /// como <see cref="PontoFiacao"/> — o trecho do <c>frmCompilarJumperExt</c>
    /// (do <c>JMP</c>) que monta os pontos antes de casar com os blocos.
    ///
    /// O original cria um ponto por ponta da conexão, com a mesma XData
    /// <c>CONEXAO</c>:
    ///
    /// - **vértice 0** quando <c>Tipo == 4</c> e <c>Disp1</c>;
    /// - **último vértice** quando <c>Tipo == 3</c> e <c>Jumper == "JUMPER"</c>,
    ///   ou <c>Tipo == 4</c> e <c>Disp2</c>.
    ///
    /// Em todos eles o <c>bJumper</c> nasce <c>true</c> (é o marcador do
    /// original). O resto do casamento com borne/dispositivo é o mesmo do
    /// <c>FIA</c> — ver <see cref="FiacaoProjetor"/>.
    /// </summary>
    public static class JumperDoDesenho
    {
        public static IReadOnlyList<PontoFiacao> Ler()
        {
            List<PontoFiacao> pontos = new List<PontoFiacao>();

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return pontos;
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
                    Entity entidade = transacao.GetObject(id, OpenMode.ForRead) as Entity;
                    Polyline linha = entidade as Polyline;
                    if (linha == null || linha.NumberOfVertices <= 0)
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

                    if (conexao.Tipo == 4 && conexao.Disp1)
                    {
                        Acrescenta(pontos, linha, conexao, 0);
                    }

                    bool fim = (conexao.Tipo == 3 && EhJumper(conexao.Jumper))
                        || (conexao.Tipo == 4 && conexao.Disp2);
                    if (fim)
                    {
                        Acrescenta(pontos, linha, conexao, linha.NumberOfVertices - 1);
                    }
                }

                transacao.Commit();
            }

            return pontos;
        }

        private static bool EhJumper(string jumper)
        {
            return !string.IsNullOrEmpty(jumper)
                && string.Equals(jumper, "JUMPER", StringComparison.OrdinalIgnoreCase);
        }

        private static void Acrescenta(
            List<PontoFiacao> pontos,
            Polyline linha,
            ConexaoXData conexao,
            int vertice)
        {
            PontoFiacao ponto = PontoFiacao.DeConexao(conexao);

            Point2d posicao = linha.GetPoint2dAt(vertice);
            ponto.X = posicao.X;
            ponto.Y = posicao.Y;
            ponto.Layer = ((Entity)linha).Layer;

            // O original marca todo ponto do JMP como jumper.
            ponto.BJumper = true;
            pontos.Add(ponto);
        }
    }
}

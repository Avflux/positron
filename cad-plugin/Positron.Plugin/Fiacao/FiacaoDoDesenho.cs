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
    /// Única parte do fluxo de fiação que toca a API do ZWCAD: varre o ModelSpace
    /// atrás de <c>LWPOLYLINE</c> com XData <c>CONEXAO</c> e devolve os pontos já
    /// em tipos neutros (<see cref="PontoFiacao"/>), que o resto do código sabe
    /// projetar e testar sem o ZWCAD.
    ///
    /// A varredura é a mesma do original (ver <c>clsConexao</c>): abre uma
    /// transação, pega a BlockTable/ModelSpace e lê o XData por entidade.
    /// </summary>
    public static class FiacaoDoDesenho
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
                    if (linha == null)
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
                        // XData inválido/truncado não derruba o comando.
                        continue;
                    }

                    // A posição vem da geometria (não do XData), e **quais** pontas
                    // geram ponto é o switch Tipo/Disp1/Disp2/Jumper do original.
                    string layer = ((Entity)linha).Layer;

                    if (PontosDaConexao.UsaPrimeiroVertice(conexao))
                    {
                        Adicionar(pontos, conexao, linha.GetPoint2dAt(0), layer);
                    }

                    if (PontosDaConexao.UsaUltimoVertice(conexao))
                    {
                        Adicionar(pontos, conexao, linha.GetPoint2dAt(linha.NumberOfVertices - 1), layer);
                    }
                }

                transacao.Commit();
            }

            return pontos;
        }

        /// <summary>Um ponto de fiação na ponta indicada (cada ponta é um objeto novo).</summary>
        private static void Adicionar(List<PontoFiacao> pontos, ConexaoXData conexao, Point2d vertice, string layer)
        {
            PontoFiacao ponto = PontoFiacao.DeConexao(conexao);
            ponto.X = vertice.X;
            ponto.Y = vertice.Y;
            ponto.Layer = layer;
            pontos.Add(ponto);
        }
    }
}

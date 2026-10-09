using System.Collections.Generic;
using Positron.Data.Fiacao;
using Positron.Data.Interligacao;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
#endif

namespace Positron.Plugin.Interligacao
{
    /// <summary>
    /// Única parte do fluxo de interligação que toca a API do ZWCAD: varre o
    /// ModelSpace atrás de <c>LWPOLYLINE</c> com XData <c>INTERLIGACAO</c> e
    /// devolve os pontos já em tipos neutros (<see cref="PontoInterligacao"/>),
    /// que o resto do código sabe projetar e testar sem o ZWCAD.
    ///
    /// Mesma varredura do original (<c>frmCompilarInterligacao</c>): uma
    /// transação, BlockTable/ModelSpace e leitura do XData por entidade.
    /// Trechos com <c>Num_Veia == -1000</c> (veia indefinida) são descartados,
    /// como no original.
    /// </summary>
    public static class InterligacaoDoDesenho
    {
        public static IReadOnlyList<PontoInterligacao> Ler()
        {
            List<PontoInterligacao> pontos = new List<PontoInterligacao>();

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

                    ResultBuffer xdata = ((DBObject)linha).GetXDataForApplication(InterligacaoXData.AppName);
                    if (xdata == null)
                    {
                        continue;
                    }

                    InterligacaoXData ilig;
                    if (!InterligacaoXData.Ler(XDataNeutro.Para(xdata), out ilig))
                    {
                        // XData inválido/truncado não derruba o comando.
                        continue;
                    }

                    if (ilig.NumVeia == InterligacaoXData.NumVeiaIndefinido)
                    {
                        continue;
                    }

                    PontoInterligacao ponto = PontoInterligacao.DeInterligacao(ilig, entidade.Layer);
                    MarcarGeometria(ponto, linha, ilig);
                    pontos.Add(ponto);
                }

                transacao.Commit();
            }

            return pontos;
        }

        /// <summary>
        /// Marca quais pontas esta polyline fornece e guarda a posição de cada
        /// uma — o que casa com o borne (<see cref="Positron.Data.Bornes.CasamentoBorne"/>).
        /// Mesma regra do <c>frmCompilarInterligacao</c>:
        ///
        /// - <c>Tipo == 1</c>: as duas pontas (vértice 0 e último vértice).
        /// - <c>Tipo == 2</c>: uma ponta — <c>Painel1 &gt; 0</c> é a ponta 1.
        /// - <c>Tipo == 3</c>: só a ponta 2 (último vértice).
        /// </summary>
        private static void MarcarGeometria(PontoInterligacao ponto, Polyline linha, InterligacaoXData ilig)
        {
            int ultimo = linha.NumberOfVertices - 1;

            if (ilig.Tipo == 3)
            {
                Point2d fim = linha.GetPoint2dAt(ultimo);
                ponto.TemPonta2 = true;
                ponto.X2 = fim.X;
                ponto.Y2 = fim.Y;
                return;
            }

            if (ilig.Tipo == 2)
            {
                if (ilig.Painel1 > 0)
                {
                    Point2d inicio = linha.GetPoint2dAt(0);
                    ponto.TemPonta1 = true;
                    ponto.X1 = inicio.X;
                    ponto.Y1 = inicio.Y;
                }
                else
                {
                    Point2d fim = linha.GetPoint2dAt(ultimo);
                    ponto.TemPonta2 = true;
                    ponto.X2 = fim.X;
                    ponto.Y2 = fim.Y;
                }

                return;
            }

            // Tipo == 1 (e desconhecidos): a polyline traz as duas pontas.
            Point2d inicioTipo1 = linha.GetPoint2dAt(0);
            ponto.TemPonta1 = true;
            ponto.X1 = inicioTipo1.X;
            ponto.Y1 = inicioTipo1.Y;

            Point2d fimTipo1 = linha.GetPoint2dAt(ultimo);
            ponto.TemPonta2 = true;
            ponto.X2 = fimTipo1.X;
            ponto.Y2 = fimTipo1.Y;
        }
    }
}

using System;
using System.Collections.Generic;
using Positron.Data.Bornes;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
#endif

namespace Positron.Plugin.Bornes
{
    /// <summary>
    /// Monta a **tabela de pontos de ligação por nome de bloco** a partir das
    /// **definições de bloco** do desenho — o <c>mknUzyUVsW</c> (fiação) e
    /// <c>KmGUFiSNQK</c> (interligação) do original.
    ///
    /// **Algoritmo recuperado do reverso**, por definição de bloco:
    ///
    /// 1. percorre as entidades e tira a bounding-box (<c>DBPoint</c>/vértices de
    ///    <c>Line</c> e <c>Polyline</c>);
    /// 2. coleta os vértices (<c>Line</c> início/fim, <c>Polyline</c>
    ///    primeiro/último) que caem **sobre a borda** da bounding-box, com
    ///    <see cref="FolgaBorda"/> de folga — são os pontos onde o fio encosta no
    ///    bloco.
    ///
    /// Esses pontos são o que o casamento soma ao pé de inserção
    /// (<see cref="CasamentoBorne"/>). Aproximação conhecida: <c>Circle</c>/<c>Arc</c>
    /// não entram na coleta de borda (os blocos de fiação usam <c>Line</c>/
    /// <c>Polyline</c>).
    /// </summary>
    public static class DeslocamentosDoDesenho
    {
        /// <summary>Folga do original em torno da bounding-box para aceitar o vértice.</summary>
        public const double FolgaBorda = 1.0;

        public static TabelaDeslocamentoBlocos Ler()
        {
            List<DeslocamentoBloco> pontos = new List<DeslocamentoBloco>();

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return TabelaDeslocamentoBlocos.Vazia;
            }

            Database banco = documento.Database;

            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTable tabela = transacao.GetObject(banco.BlockTableId, OpenMode.ForRead) as BlockTable;
                if (tabela == null)
                {
                    transacao.Commit();
                    return TabelaDeslocamentoBlocos.Vazia;
                }

                foreach (ObjectId idBloco in tabela)
                {
                    BlockTableRecord bloco = transacao.GetObject(idBloco, OpenMode.ForRead) as BlockTableRecord;
                    if (bloco == null || string.IsNullOrEmpty(bloco.Name))
                    {
                        continue;
                    }

                    double minX = 0.0;
                    double minY = 0.0;
                    double maxX = 0.0;
                    double maxY = 0.0;
                    bool temBounds = false;

                    foreach (ObjectId idEntidade in bloco)
                    {
                        Entity entidade = transacao.GetObject(idEntidade, OpenMode.ForRead) as Entity;
                        AcumularBounds(entidade, ref temBounds, ref minX, ref minY, ref maxX, ref maxY);
                    }

                    if (!temBounds)
                    {
                        continue;
                    }

                    foreach (ObjectId idEntidade in bloco)
                    {
                        Entity entidade = transacao.GetObject(idEntidade, OpenMode.ForRead) as Entity;
                        ColetarPontosDeBorda(entidade, bloco.Name, minX, minY, maxX, maxY, pontos);
                    }
                }

                transacao.Commit();
            }

            return TabelaDeslocamentoBlocos.Ler(pontos);
        }

        private static void AcumularBounds(
            Entity entidade,
            ref bool temBounds,
            ref double minX,
            ref double minY,
            ref double maxX,
            ref double maxY)
        {
            Line linha = entidade as Line;
            if (linha != null)
            {
                Acumular(linha.StartPoint, ref temBounds, ref minX, ref minY, ref maxX, ref maxY);
                Acumular(linha.EndPoint, ref temBounds, ref minX, ref minY, ref maxX, ref maxY);
                return;
            }

            Polyline polilinha = entidade as Polyline;
            if (polilinha != null)
            {
                for (int i = 0; i < polilinha.NumberOfVertices; i++)
                {
                    Point2d vertice = polilinha.GetPoint2dAt(i);
                    Acumular(vertice.X, vertice.Y, ref temBounds, ref minX, ref minY, ref maxX, ref maxY);
                }

                return;
            }

            DBPoint ponto = entidade as DBPoint;
            if (ponto != null)
            {
                Acumular(ponto.Position, ref temBounds, ref minX, ref minY, ref maxX, ref maxY);
            }
        }

        private static void ColetarPontosDeBorda(
            Entity entidade,
            string nomeBloco,
            double minX,
            double minY,
            double maxX,
            double maxY,
            List<DeslocamentoBloco> destino)
        {
            Line linha = entidade as Line;
            if (linha != null)
            {
                AdicionarSeNaBorda(nomeBloco, linha.StartPoint.X, linha.StartPoint.Y, minX, minY, maxX, maxY, destino);
                AdicionarSeNaBorda(nomeBloco, linha.EndPoint.X, linha.EndPoint.Y, minX, minY, maxX, maxY, destino);
                return;
            }

            Polyline polilinha = entidade as Polyline;
            if (polilinha != null && polilinha.NumberOfVertices > 0)
            {
                Point2d inicio = polilinha.GetPoint2dAt(0);
                Point2d fim = polilinha.GetPoint2dAt(polilinha.NumberOfVertices - 1);
                AdicionarSeNaBorda(nomeBloco, inicio.X, inicio.Y, minX, minY, maxX, maxY, destino);
                AdicionarSeNaBorda(nomeBloco, fim.X, fim.Y, minX, minY, maxX, maxY, destino);
            }
        }

        private static void AdicionarSeNaBorda(
            string nomeBloco,
            double x,
            double y,
            double minX,
            double minY,
            double maxX,
            double maxY,
            List<DeslocamentoBloco> destino)
        {
            if (!NaBorda(x, y, minX, minY, maxX, maxY))
            {
                return;
            }

            destino.Add(new DeslocamentoBloco { Nome = nomeBloco, X = x, Y = y });
        }

        private static bool NaBorda(double x, double y, double minX, double minY, double maxX, double maxY)
        {
            return Perto(x, minX) || Perto(x, maxX) || Perto(y, minY) || Perto(y, maxY);
        }

        private static bool Perto(double a, double b)
        {
            return Math.Abs(a - b) <= FolgaBorda;
        }

        private static void Acumular(
            Point3d ponto,
            ref bool temBounds,
            ref double minX,
            ref double minY,
            ref double maxX,
            ref double maxY)
        {
            Acumular(ponto.X, ponto.Y, ref temBounds, ref minX, ref minY, ref maxX, ref maxY);
        }

        private static void Acumular(
            double x,
            double y,
            ref bool temBounds,
            ref double minX,
            ref double minY,
            ref double maxX,
            ref double maxY)
        {
            if (!temBounds)
            {
                temBounds = true;
                minX = x;
                maxX = x;
                minY = y;
                maxY = y;
                return;
            }

            if (x < minX) { minX = x; }
            if (x > maxX) { maxX = x; }
            if (y < minY) { minY = y; }
            if (y > maxY) { maxY = y; }
        }
    }
}

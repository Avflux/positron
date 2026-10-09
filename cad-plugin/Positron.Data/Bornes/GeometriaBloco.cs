using System;
using System.Collections.Generic;

namespace Positron.Data.Bornes
{
    /// <summary>
    /// As duas etapas geométricas do casamento ponto↔bloco, comuns a bornes
    /// (<see cref="CasamentoBorne"/>) e dispositivos
    /// (<see cref="Positron.Data.Fiacao.CasamentoDispositivo"/>):
    ///
    /// 1. o ponto tem que cair dentro da bounding-box do bloco com
    ///    <see cref="CasamentoBorne.MargemBounds"/> de folga;
    /// 2. a distância é medida do ponto aos **pontos de ligação** do bloco
    ///    (<c>inserção + deslocamento</c>, ver <see cref="TabelaDeslocamentoBlocos"/>);
    ///    sem tabela, usa o pé de inserção.
    /// </summary>
    internal static class GeometriaBloco
    {
        public static bool DentroDosBounds(
            double x,
            double y,
            bool temBounds,
            double minX,
            double minY,
            double maxX,
            double maxY)
        {
            if (!temBounds)
            {
                return true;
            }

            double margem = CasamentoBorne.MargemBounds;
            return x >= minX - margem
                && x <= maxX + margem
                && y >= minY - margem
                && y <= maxY + margem;
        }

        public static double DistanciaMinima(
            double x,
            double y,
            double baseX,
            double baseY,
            string nomeBloco,
            TabelaDeslocamentoBlocos deslocamentos)
        {
            IReadOnlyList<DeslocamentoBloco> pontos = deslocamentos == null
                ? null
                : deslocamentos.Buscar(nomeBloco);

            if (pontos == null || pontos.Count == 0)
            {
                return Distancia(baseX, baseY, x, y);
            }

            double menor = double.MaxValue;
            foreach (DeslocamentoBloco ponto in pontos)
            {
                double distancia = Distancia(baseX + ponto.X, baseY + ponto.Y, x, y);
                if (distancia < menor)
                {
                    menor = distancia;
                }
            }

            return menor;
        }

        public static double Distancia(double ax, double ay, double bx, double by)
        {
            return Math.Sqrt(Math.Pow(ax - bx, 2.0) + Math.Pow(ay - by, 2.0));
        }

        public static bool MesmoLayer(string a, string b)
        {
            if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b))
            {
                return true;
            }

            return string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
        }
    }
}

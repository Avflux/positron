using System.Collections.Generic;

namespace Positron.Data.Bornes
{
    /// <summary>
    /// Pontos de ligação de um símbolo, na forma pura (sem CAD) — o que o
    /// <c>frmCompilarFiacao</c> do original coleta da definição do bloco para
    /// montar <c>KmGUFiSNQK</c> / <c>mknUzyUVsW</c>: início/fim de <c>Line</c>,
    /// primeiro/último vértice de <c>Polyline</c> e os **quatro quadrantes do
    /// <c>Circle</c>** (<c>centro ± raio</c>).
    ///
    /// Regressão do desenho real: os bornes da biblioteca são círculos de raio 1;
    /// sem os quadrantes a tabela ficava vazia para eles e o casamento caía no pé
    /// de inserção (distância ~1,0 = o raio), deixando 193 de 199 bornes sem fio.
    /// </summary>
    public static class PontosDeLigacao
    {
        /// <summary>Quadrantes de um círculo, na ordem do original: +X, -X, +Y, -Y.</summary>
        public static IReadOnlyList<double[]> DoCirculo(double centroX, double centroY, double raio)
        {
            return new List<double[]>
            {
                new[] { centroX + raio, centroY },
                new[] { centroX - raio, centroY },
                new[] { centroX, centroY + raio },
                new[] { centroX, centroY - raio },
            };
        }

        /// <summary>Extensões de um círculo (min/max X/Y), para a bounding-box do bloco.</summary>
        public static double[] ExtensoesDoCirculo(double centroX, double centroY, double raio)
        {
            return new[] { centroX - raio, centroY - raio, centroX + raio, centroY + raio };
        }
    }
}

using System;
using System.Collections.Generic;

namespace Positron.Data.Interligacao
{
    /// <summary>Um vértice em 2D — o que a geometria do rótulo precisa do desenho.</summary>
    public sealed class PontoDoRotulo
    {
        public double X { get; set; }

        public double Y { get; set; }
    }

    /// <summary>Onde (e girado como) o rótulo sai.</summary>
    public sealed class PosicaoDoRotulo
    {
        public double AlignX { get; set; }

        public double AlignY { get; set; }

        public double Rotation { get; set; }
    }

    /// <summary>
    /// A geometria do `clsInterligacao.criarTextoNomeCabo` (o texto do rótulo de
    /// cabo): de qual **segmento** da polilinha o rótulo sai, o ponto de alinhamento
    /// e a rotação.
    ///
    /// O segmento, como no original: 2 vértices → o próprio; 3 → o **maior** dos
    /// dois; 4 → o do meio (1–2); qualquer outro → o primeiro.
    ///
    /// O ponto de alinhamento é o **meio do segmento** mais um deslocamento de 1
    /// unidade na perpendicular (`num5 = 1.0`), do lado que o sinal de `num10` decide
    /// — é a mesma conta com `num9`/`num10` do original, inclusive os dois casos em que
    /// o `num9` troca de sinal. **Quirk reproduzido:** o limite do meio-plano é
    /// `Math.Round(Math.PI, 2) / 2` (= `1.57`), e não `π/2` — o original arredonda o π
    /// antes de comparar.
    /// </summary>
    public static class PosicaoDoRotuloDeCabo
    {
        public static PosicaoDoRotulo Calcular(IReadOnlyList<PontoDoRotulo> vertices)
        {
            PosicaoDoRotulo posicao = new PosicaoDoRotulo();
            if (vertices == null || vertices.Count < 2)
            {
                return posicao;
            }

            double limite = Math.Round(Math.PI, 2);

            PontoDoRotulo inicio;
            PontoDoRotulo fim;
            EscolherSegmento(vertices, out inicio, out fim);

            double meio = Distancia(inicio, fim) / 2.0;
            const double afastamento = 1.0;

            double dx = fim.X - inicio.X;
            double dy = fim.Y - inicio.Y;
            double angulo = Math.Round(Math.Atan2(dy, dx), 2);

            // `!(angulo <= limite/2 && angulo > -limite/2)` → o texto é girado meia volta.
            posicao.Rotation = (angulo <= limite / 2.0 && angulo > limite / 2.0 * -1.0)
                ? angulo
                : angulo - Math.PI;

            double aoLongoX = meio * Math.Cos(angulo);
            double aoLongoY = meio * Math.Sin(angulo);
            double perpendicularX = afastamento * Math.Cos(Math.PI / 2.0 - angulo);
            double perpendicularY = afastamento * Math.Sin(Math.PI / 2.0 - angulo);

            if (perpendicularY < 0.0)
            {
                perpendicularY *= -1.0;
            }

            if (angulo == limite / 2.0)
            {
                perpendicularX *= -1.0;
            }

            if ((angulo > 0.0 && angulo < limite / 2.0) || (angulo < 0.0 && angulo > limite / 2.0 * -1.0))
            {
                perpendicularX *= -1.0;
            }

            posicao.AlignX = inicio.X + aoLongoX + perpendicularX;
            posicao.AlignY = inicio.Y + aoLongoY + perpendicularY;
            return posicao;
        }

        /// <summary>
        /// A geometria do <c>criarTextoNomeCaboEletrosul</c> (o rótulo da variante
        /// Eletrosul): o **mesmo segmento** do rótulo padrão, mas com o afastamento
        /// perpendicular **zero** (`num5 = 0.0`) e a rotação **sempre 0** — o texto
        /// sai horizontal, alinhado à esquerda (`TextHorizontalMode.TextLeft`) no
        /// **meio do segmento**, e não bottom-center 1 unidade acima como no padrão.
        /// </summary>
        public static PosicaoDoRotulo CalcularEletrosul(IReadOnlyList<PontoDoRotulo> vertices)
        {
            PosicaoDoRotulo posicao = new PosicaoDoRotulo();
            if (vertices == null || vertices.Count < 2)
            {
                return posicao;
            }

            PontoDoRotulo inicio;
            PontoDoRotulo fim;
            EscolherSegmento(vertices, out inicio, out fim);

            double meio = Distancia(inicio, fim) / 2.0;
            double angulo = Math.Round(Math.Atan2(fim.Y - inicio.Y, fim.X - inicio.X), 2);

            posicao.AlignX = inicio.X + meio * Math.Cos(angulo);
            posicao.AlignY = inicio.Y + meio * Math.Sin(angulo);
            posicao.Rotation = 0.0;
            return posicao;
        }

        /// <summary>
        /// A marca <c>H</c>/<c>V</c> da Eletrosul (`sRotaHV`): <c>true</c> quando o
        /// segmento escolhido é **vertical** — o teste do original é o X arredondado
        /// em 2 casas igual nas duas pontas.
        /// </summary>
        public static bool SegmentoVertical(IReadOnlyList<PontoDoRotulo> vertices)
        {
            if (vertices == null || vertices.Count < 2)
            {
                return false;
            }

            PontoDoRotulo inicio;
            PontoDoRotulo fim;
            EscolherSegmento(vertices, out inicio, out fim);
            return Math.Round(inicio.X, 2) == Math.Round(fim.X, 2);
        }

        private static void EscolherSegmento(
            IReadOnlyList<PontoDoRotulo> vertices,
            out PontoDoRotulo inicio,
            out PontoDoRotulo fim)
        {
            if (vertices.Count == 2)
            {
                inicio = vertices[0];
                fim = vertices[1];
                return;
            }

            if (vertices.Count == 3)
            {
                double primeiro = Distancia(vertices[0], vertices[1]);
                double segundo = Distancia(vertices[1], vertices[2]);
                if (primeiro > segundo)
                {
                    inicio = vertices[0];
                    fim = vertices[1];
                }
                else
                {
                    inicio = vertices[1];
                    fim = vertices[2];
                }

                return;
            }

            if (vertices.Count == 4)
            {
                inicio = vertices[1];
                fim = vertices[2];
                return;
            }

            inicio = vertices[0];
            fim = vertices[1];
        }

        private static double Distancia(PontoDoRotulo a, PontoDoRotulo b)
        {
            double dx = b.X - a.X;
            double dy = b.Y - a.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}

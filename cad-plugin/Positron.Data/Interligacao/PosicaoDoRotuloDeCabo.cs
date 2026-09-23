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
    /// O que o <c>AdicionaCaboEletrosul</c> desenha para um trecho: o centro da
    /// **elipse** (o meio do segmento), a direção (<see cref="Vertical"/> = o
    /// <c>sRotaHV</c> "H" do original), os três vértices do "leader" e o ponto onde o
    /// **texto** fica (o fim do "leader", não o centro).
    /// </summary>
    public sealed class RotuloEletrosul
    {
        /// <summary>Raio do eixo maior da elipse (<c>0.6</c> no original).</summary>
        public const double RaioElipse = 0.6;

        /// <summary>Centro da elipse — o meio do segmento (o <c>mCenterPt</c> de entrada).</summary>
        public PontoDoRotulo Centro { get; set; }

        /// <summary><c>true</c> quando o segmento é vertical (o <c>sRotaHV == "H"</c>).</summary>
        public bool Vertical { get; set; }

        public PontoDoRotulo Ponto7 { get; set; }

        public PontoDoRotulo Ponto8 { get; set; }

        public PontoDoRotulo Ponto9 { get; set; }

        /// <summary>O ponto de alinhamento do texto (o <c>mCenterPt</c> **depois** do leader).</summary>
        public double AlignX { get; set; }

        public double AlignY { get; set; }
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
        /// Eletrosul), com os pontos que o <c>AdicionaCaboEletrosul</c> desenha: a
        /// **elipse** no meio do segmento, o "leader" de três vértices e o **ponto
        /// final do texto**.
        ///
        /// Duas particularidades do original, as duas reproduzidas:
        ///
        /// 1. o <c>sRotaHV</c> é **"H" quando o segmento é vertical** (o teste é o X
        ///    arredondado igual nas pontas) — e é ele que decide a direção do "leader"
        ///    e do eixo maior da elipse;
        /// 2. o texto **não** fica no meio do segmento: o <c>AdicionaCaboEletrosul</c>
        ///    reescreve o <c>mCenterPt</c> por referência e o
        ///    <c>criarTextoNomeCaboEletrosul</c> usa o ponto **já mexido** — o fim do
        ///    "leader", com o Y deslocado por <c>FonteCabos * 0.85</c>.
        ///
        /// (A rodada 79 parou no meio do segmento; a correção está registrada no
        /// <c>RUNBOOK</c>.)
        /// </summary>
        public static RotuloEletrosul CalcularEletrosul(IReadOnlyList<PontoDoRotulo> vertices, double fonteCabos)
        {
            RotuloEletrosul rotulo = new RotuloEletrosul();
            if (vertices == null || vertices.Count < 2)
            {
                return rotulo;
            }

            PontoDoRotulo inicio;
            PontoDoRotulo fim;
            EscolherSegmento(vertices, out inicio, out fim);

            double meio = Distancia(inicio, fim) / 2.0;
            double angulo = Math.Round(Math.Atan2(fim.Y - inicio.Y, fim.X - inicio.X), 2);

            rotulo.Centro = new PontoDoRotulo
            {
                X = inicio.X + meio * Math.Cos(angulo),
                Y = inicio.Y + meio * Math.Sin(angulo),
            };
            rotulo.Vertical = Math.Round(inicio.X, 2) == Math.Round(fim.X, 2);

            double x = rotulo.Centro.X;
            double y = rotulo.Centro.Y;
            if (rotulo.Vertical)
            {
                rotulo.Ponto7 = new PontoDoRotulo { X = x, Y = y + 1.0 };
                rotulo.Ponto8 = new PontoDoRotulo { X = x, Y = y + 2.0 };
                rotulo.Ponto9 = new PontoDoRotulo { X = x + 1.0, Y = y + 2.0 };
                rotulo.AlignX = rotulo.Ponto8.X + 1.0;
            }
            else
            {
                rotulo.Ponto7 = new PontoDoRotulo { X = x + 1.0, Y = y };
                rotulo.Ponto8 = new PontoDoRotulo { X = x + 2.0, Y = y };
                rotulo.Ponto9 = new PontoDoRotulo { X = x + 2.0, Y = y };
                rotulo.AlignX = rotulo.Ponto8.X + 2.0;
            }

            rotulo.AlignY = rotulo.Ponto8.Y - fonteCabos * 0.85;
            return rotulo;
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

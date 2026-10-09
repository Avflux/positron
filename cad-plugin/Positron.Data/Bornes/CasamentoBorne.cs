using System;
using System.Collections.Generic;

namespace Positron.Data.Bornes
{
    /// <summary>
    /// Liga um ponto de fiação (ou de interligação) ao borne do desenho — a parte
    /// pura do <c>frmCompilarFiacao.ltZUHdAX7R</c> / <c>frmCompilarInterligacao.pf6UXj3X1f</c>.
    ///
    /// **Regra recuperada do reverso (em duas etapas).**
    ///
    /// 1. **Bounds ±0,25.** O chamador do original só aceita o bloco se o ponto
    ///    cai dentro da bounding-box do bloco, com 0,25 de folga
    ///    (<c>Bounds.Min/Max ± 0,25</c>). Aqui isso vira o filtro de
    ///    <see cref="MargemBounds"/>, aplicado quando o borne traz bounds
    ///    (<see cref="PontoBorne.TemBounds"/>).
    /// 2. **Deslocamento por nome de bloco.** O ponto de referência não é o pé de
    ///    inserção, e sim <c>inserção + deslocamento</c>, onde o deslocamento vem
    ///    da **tabela de pontos de ligação do bloco**
    ///    (<see cref="TabelaDeslocamentoBlocos"/>, o <c>mknUzyUVsW</c>). O bloco
    ///    pode ter vários pontos de ligação; basta um dentro de
    ///    <see cref="Tolerancia"/> (0,5). Sem tabela, cai no pé de inserção — que é
    ///    o caso quando o bloco é desenhado na origem.
    ///
    /// Diferente do original (que para no primeiro bloco/offset que casa, na ordem
    /// do desenho), aqui se escolhe o **mais próximo** dentro da tolerância —
    /// determinístico e independente da ordem de varredura.
    /// </summary>
    public static class CasamentoBorne
    {
        /// <summary>Tolerância do original para o ponto de ligação: 0,5 unidade de desenho.</summary>
        public const double Tolerancia = 0.5;

        /// <summary>Folga do original em torno da bounding-box do bloco.</summary>
        public const double MargemBounds = 0.25;

        /// <summary>Borne mais próximo do ponto dentro da tolerância, ou <c>null</c>.</summary>
        public static PontoBorne Proximo(double x, double y, string layer, short painel, IEnumerable<PontoBorne> bornes)
        {
            return Proximo(x, y, layer, painel, bornes, Tolerancia, null);
        }

        public static PontoBorne Proximo(double x, double y, string layer, short painel, IEnumerable<PontoBorne> bornes, double tolerancia)
        {
            return Proximo(x, y, layer, painel, bornes, tolerancia, null);
        }

        /// <summary>
        /// Versão completa: com <paramref name="deslocamentos"/>, o ponto de
        /// referência de cada bloco é <c>inserção + ponto de ligação</c>; sem ela,
        /// o pé de inserção.
        /// </summary>
        public static PontoBorne Proximo(
            double x,
            double y,
            string layer,
            short painel,
            IEnumerable<PontoBorne> bornes,
            double tolerancia,
            TabelaDeslocamentoBlocos deslocamentos)
        {
            if (bornes == null)
            {
                return null;
            }

            PontoBorne melhor = null;
            double menor = tolerancia;

            foreach (PontoBorne borne in bornes)
            {
                if (borne == null)
                {
                    continue;
                }

                if (!MesmoLayer(layer, borne.Layer))
                {
                    continue;
                }

                // Painel 0 significa "desconhecido" (régua fora do dicionário):
                // não restringe, senão o casamento nunca aconteceria.
                if (painel > 0 && borne.Painel > 0 && borne.Painel != painel)
                {
                    continue;
                }

                if (!DentroDosBounds(x, y, borne))
                {
                    continue;
                }

                double distancia = DistanciaMinima(x, y, borne, deslocamentos);
                if (distancia <= menor)
                {
                    menor = distancia;
                    melhor = borne;
                }
            }

            return melhor;
        }

        private static bool DentroDosBounds(double x, double y, PontoBorne borne)
        {
            if (!borne.TemBounds)
            {
                return true;
            }

            return x >= borne.MinX - MargemBounds
                && x <= borne.MaxX + MargemBounds
                && y >= borne.MinY - MargemBounds
                && y <= borne.MaxY + MargemBounds;
        }

        /// <summary>
        /// Menor distância do ponto aos pontos de ligação do bloco
        /// (<c>inserção + deslocamento</c>). Sem deslocamento conhecido, usa o pé
        /// de inserção.
        /// </summary>
        private static double DistanciaMinima(double x, double y, PontoBorne borne, TabelaDeslocamentoBlocos deslocamentos)
        {
            IReadOnlyList<DeslocamentoBloco> pontos = deslocamentos == null
                ? null
                : deslocamentos.Buscar(borne.NomeBloco);

            if (pontos == null || pontos.Count == 0)
            {
                return Distancia(borne.X, borne.Y, x, y);
            }

            double menor = double.MaxValue;
            foreach (DeslocamentoBloco ponto in pontos)
            {
                double distancia = Distancia(borne.X + ponto.X, borne.Y + ponto.Y, x, y);
                if (distancia < menor)
                {
                    menor = distancia;
                }
            }

            return menor;
        }

        private static double Distancia(double ax, double ay, double bx, double by)
        {
            return Math.Sqrt(Math.Pow(ax - bx, 2.0) + Math.Pow(ay - by, 2.0));
        }

        private static bool MesmoLayer(string a, string b)
        {
            if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b))
            {
                return true;
            }

            return string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
        }
    }
}

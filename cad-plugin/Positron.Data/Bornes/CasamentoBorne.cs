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

                if (!GeometriaBloco.MesmoLayer(layer, borne.Layer))
                {
                    continue;
                }

                // Painel 0 significa "desconhecido" (régua fora do dicionário):
                // não restringe, senão o casamento nunca aconteceria.
                if (painel > 0 && borne.Painel > 0 && borne.Painel != painel)
                {
                    continue;
                }

                if (!GeometriaBloco.DentroDosBounds(
                        x, y, borne.TemBounds, borne.MinX, borne.MinY, borne.MaxX, borne.MaxY))
                {
                    continue;
                }

                double distancia = GeometriaBloco.DistanciaMinima(
                    x, y, borne.X, borne.Y, borne.NomeBloco, deslocamentos);
                if (distancia <= menor)
                {
                    menor = distancia;
                    melhor = borne;
                }
            }

            return melhor;
        }

    }
}

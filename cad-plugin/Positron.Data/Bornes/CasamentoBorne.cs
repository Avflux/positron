using System;
using System.Collections.Generic;

namespace Positron.Data.Bornes
{
    /// <summary>
    /// Liga um ponto de fiação ao borne do desenho — a parte pura do
    /// <c>frmCompilarFiacao.ltZUHdAX7R</c>.
    ///
    /// **Regra recuperada do reverso.** Para cada bloco de borne cujo layer casa
    /// com o do ponto e cujo painel é o mesmo do ponto (quando o painel é
    /// conhecido), o original mede a distância do ponto à **posição de inserção
    /// deslocada** do bloco e aceita o primeiro dentro de <see cref="Tolerancia"/>.
    /// Aqui o deslocamento por nome de bloco (tabela interna do original) não é
    /// reproduzido: usamos a inserção direta do bloco, o que é equivalente quando
    /// o ponto de fiação mira o próprio pé do borne.
    ///
    /// Diferente do original (que para no primeiro bloco na ordem do desenho),
    /// aqui se escolhe o **mais próximo** dentro da tolerância — determinístico e
    /// independente da ordem de varredura.
    /// </summary>
    public static class CasamentoBorne
    {
        /// <summary>Tolerância do original para o borne: 0,5 unidade de desenho.</summary>
        public const double Tolerancia = 0.5;

        /// <summary>
        /// Devolve o borne mais próximo do ponto dentro da tolerância, ou
        /// <c>null</c> se nenhum casar.
        /// </summary>
        public static PontoBorne Proximo(double x, double y, string layer, short painel, IEnumerable<PontoBorne> bornes)
        {
            return Proximo(x, y, layer, painel, bornes, Tolerancia);
        }

        public static PontoBorne Proximo(double x, double y, string layer, short painel, IEnumerable<PontoBorne> bornes, double tolerancia)
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

                double distancia = Math.Sqrt(Math.Pow(borne.X - x, 2.0) + Math.Pow(borne.Y - y, 2.0));
                if (distancia <= menor)
                {
                    menor = distancia;
                    melhor = borne;
                }
            }

            return melhor;
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

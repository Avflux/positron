using System;
using System.Collections.Generic;

namespace Positron.Data.Paginas
{
    /// <summary>
    /// Uma **coluna de cruzamento** associada a uma página — o par <c>(página, tipo)</c> que o
    /// <c>Pagina.TrocaColunas</c> acumula e depois reinstancia via <c>InserirColuna</c>.
    /// </summary>
    public sealed class ColunaDaPagina : IEquatable<ColunaDaPagina>
    {
        public ColunaDaPagina(string pagina, string tipo)
        {
            Pagina = pagina ?? string.Empty;
            Tipo = tipo ?? string.Empty;
        }

        /// <summary>O layer da página onde a coluna está inserida (ex. "1", "2").</summary>
        public string Pagina { get; }

        /// <summary>O tipo da coluna (o layer original no bloco de formato, ex. "ELET1_...").</summary>
        public string Tipo { get; }

        public bool Equals(ColunaDaPagina other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Pagina, other.Pagina, StringComparison.OrdinalIgnoreCase)
                && string.Equals(Tipo, other.Tipo, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ColunaDaPagina);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = StringComparer.OrdinalIgnoreCase.GetHashCode(Pagina ?? string.Empty);
                hash = (hash * 397) ^ StringComparer.OrdinalIgnoreCase.GetHashCode(Tipo ?? string.Empty);
                return hash;
            }
        }

        public override string ToString()
        {
            return Pagina + ":" + Tipo;
        }

        /// <summary>
        /// Filtra e preserva apenas pares únicos <c>(página, tipo)</c> mantendo a ordem de primeira aparição,
        /// espelhando a deduplicação de <c>Pagina.TrocaColunas</c>.
        /// </summary>
        public static List<ColunaDaPagina> Deduplicar(IEnumerable<ColunaDaPagina> colunas)
        {
            List<ColunaDaPagina> resultado = new List<ColunaDaPagina>();
            if (colunas == null)
            {
                return resultado;
            }

            HashSet<ColunaDaPagina> vistos = new HashSet<ColunaDaPagina>();
            foreach (ColunaDaPagina coluna in colunas)
            {
                if (coluna != null && !string.IsNullOrEmpty(coluna.Pagina) && !string.IsNullOrEmpty(coluna.Tipo))
                {
                    if (vistos.Add(coluna))
                    {
                        resultado.Add(coluna);
                    }
                }
            }

            return resultado;
        }
    }
}

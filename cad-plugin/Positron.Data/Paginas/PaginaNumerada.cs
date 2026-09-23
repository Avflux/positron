using System;
using System.Globalization;

namespace Positron.Data.Paginas
{
    /// <summary>
    /// A numeração das páginas do caderno — a primeira fatia da **frente 10** (interface, uma
    /// funcionalidade por vez): as três contas puras do <c>Pagina.cs</c> do reverso que sustentam
    /// toda a UI de páginas (a página é o **layer** do desenho).
    ///
    /// **O formato da página**, como o original o lê: um número ("10") ou um número seguido de uma
    /// letra maiúscula ("10A"), que vale <c>número + Asc(letra)/100</c> — ou seja <c>10A = 10,65</c>
    /// e <c>10Z = 10,90</c>, o que dá a ordem natural das páginas alfanuméricas.
    /// </summary>
    public static class PaginaNumerada
    {
        /// <summary>O valor decimal da página (0 quando a página não tem o formato do original).</summary>
        public static double Decimal(string pagina)
        {
            string texto = pagina ?? string.Empty;
            if (texto.Length == 0)
            {
                return 0.0;
            }

            double numero;
            if (double.TryParse(texto, NumberStyles.Float, CultureInfo.InvariantCulture, out numero))
            {
                return numero;
            }

            // O prefixo (tudo menos a última letra) tem de ser numérico, e a última, uma letra A-Z.
            string prefixo = texto.Substring(0, texto.Length - 1);
            double baseNumerica;
            if (prefixo.Length == 0 ||
                !double.TryParse(prefixo, NumberStyles.Float, CultureInfo.InvariantCulture, out baseNumerica))
            {
                return 0.0;
            }

            char letra = texto[texto.Length - 1];
            if (letra < 'A' || letra > 'Z')
            {
                return 0.0;
            }

            return baseNumerica + letra / 100.0;
        }

        /// <summary>Diz se o texto é um número (o <c>IsNumeric</c> do VB usado pelo original).</summary>
        public static bool EhNumerico(string pagina)
        {
            double numero;
            return double.TryParse(
                pagina ?? string.Empty, NumberStyles.Float, CultureInfo.InvariantCulture, out numero);
        }

        /// <summary>
        /// O espaço **numérico** entre duas páginas (o <c>calculaEspacoNumerico</c>): quantas páginas
        /// numéricas cabem de <paramref name="p0"/> a <paramref name="p1"/>.
        /// </summary>
        public static int EspacoNumerico(string p0, string p1)
        {
            double inicio = EhNumerico(p0) ? double.Parse(p0, CultureInfo.InvariantCulture) : Math.Floor(Decimal(p0)) + 1.0;
            double fim = EhNumerico(p1) ? double.Parse(p1, CultureInfo.InvariantCulture) - 1.0 : Math.Floor(Decimal(p1));
            return (int)Math.Round(fim - inicio + 1.0);
        }

        /// <summary>
        /// O espaço **alfanumérico** entre duas páginas (o <c>calculaEspacoAlfaNumerico</c>): a
        /// aritmética de 27 por número (26 letras + a página "seca", que vale 64 = 'A' - 1).
        /// </summary>
        public static int EspacoAlfaNumerico(string p0, string p1)
        {
            double a = Decimal(p0);
            double b = Decimal(p1);

            int numeroA = (int)Math.Floor(a);
            int letraA = (int)Math.Round((a - Math.Floor(a)) * 100.0);
            int numeroB = (int)Math.Floor(b);
            int letraB = (int)Math.Round((b - Math.Floor(b)) * 100.0);

            int espaco;
            if (numeroA != numeroB)
            {
                if (letraA == 0)
                {
                    letraA = 64;
                }

                espaco = 91 - letraA;
                if (letraB > 0)
                {
                    espaco += letraB - 64;
                }

                if (numeroB - numeroA > 1)
                {
                    espaco += (numeroB - numeroA - 1) * 27;
                }
            }
            else
            {
                if (letraA == 0)
                {
                    letraA = 64;
                }

                espaco = letraB - letraA;
            }

            return espaco;
        }
    }
}

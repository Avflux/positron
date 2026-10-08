using System;
using System.Globalization;

namespace Positron.Data.Modelos
{
    /// <summary>
    /// Ordenação numérica de um terminal — o <c>clsConexao.CalculaTerminalNumerico</c>
    /// do original. Converte o rótulo textual do terminal ("12", "1.2", "A", "A5")
    /// num número que ordena junto com o resto.
    ///
    /// **Regra recuperada do reverso:**
    /// - vazio → <c>0</c>;
    /// - só dígitos/ponto e inteiro → o próprio valor ("12" → 12);
    /// - só dígitos/ponto com casa → inteiro + fração/10000 ("1.2" → 1,0002);
    /// - uma letra A-Z → <c>Asc(letra) * 1000</c> ("A" → 65000);
    /// - letra + número → <c>Asc(letra) * 1000 + número</c> ("A5" → 65005);
    /// - qualquer outra forma → <see cref="Indefinido"/> (1000000), que ordena por
    ///   último, como no original.
    ///
    /// As formas com ":" e "-" do original não são reproduzidas — caem no
    /// <see cref="Indefinido"/>. Ver docs/POSITRON.md (fase 8).
    /// </summary>
    public static class TerminalNumerico
    {
        /// <summary>Valor do original para terminal não decodificável.</summary>
        public const double Indefinido = 1000000.0;

        public static double Calcular(string terminal)
        {
            if (string.IsNullOrEmpty(terminal))
            {
                return 0.0;
            }

            string texto = terminal.Trim().ToUpperInvariant();
            if (texto.Length == 0)
            {
                return 0.0;
            }

            if (SomenteDigitosEPonto(texto))
            {
                long inteiro;
                if (long.TryParse(texto, NumberStyles.Integer, CultureInfo.InvariantCulture, out inteiro))
                {
                    return inteiro;
                }

                int ponto = texto.IndexOf('.');
                if (ponto >= 0)
                {
                    string esquerda = texto.Substring(0, ponto);
                    string direita = texto.Substring(ponto + 1);
                    double parteInteira = esquerda.Length == 0 ? 0.0 : Convert.ToDouble(esquerda, CultureInfo.InvariantCulture);
                    double parteFracionaria = direita.Length == 0 ? 0.0 : Convert.ToDouble(direita, CultureInfo.InvariantCulture);
                    return parteInteira + (parteFracionaria / 10000.0);
                }

                return Indefinido;
            }

            // Uma letra A-Z.
            if (texto.Length == 1 && EhLetra(texto[0]))
            {
                return texto[0] * 1000.0;
            }

            // Letra + número ("A5").
            if (EhLetra(texto[0]))
            {
                string resto = texto.Substring(1);
                long numero;
                if (resto.Length > 0
                    && long.TryParse(resto, NumberStyles.Integer, CultureInfo.InvariantCulture, out numero))
                {
                    return (texto[0] * 1000.0) + numero;
                }
            }

            return Indefinido;
        }

        private static bool SomenteDigitosEPonto(string texto)
        {
            foreach (char c in texto)
            {
                if (c != '.' && (c < '0' || c > '9'))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool EhLetra(char c)
        {
            return c >= 'A' && c <= 'Z';
        }
    }
}

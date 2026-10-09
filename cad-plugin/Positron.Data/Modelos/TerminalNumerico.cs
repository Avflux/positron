using System;
using System.Globalization;

namespace Positron.Data.Modelos
{
    /// <summary>
    /// Ordenação numérica de um terminal — o <c>clsConexao.CalculaTerminalNumerico</c>
    /// do original. Converte o rótulo textual do terminal (\"12\", \"1.2\", \"A\", \"A5\",
    /// \"A1:2\") num número que ordena junto com o resto.
    ///
    /// **Regra recuperada do reverso:**
    /// - vazio → <c>0</c>;
    /// - só dígitos/ponto e inteiro → o próprio valor (\"12\" → 12);
    /// - só dígitos/ponto com casa → inteiro + fração/10000 (\"1.2\" → 1,0002);
    /// - uma letra A-Z → <c>Asc(letra) * 1000</c> (\"A\" → 65000);
    /// - letra + número → <c>Asc(letra) * 1000 + número</c> (\"A5\" → 65005);
    /// - número + letra → <c>número + Asc(letra) / 100</c> (\"12A\" → 12,65);
    /// - letra + separador + número + separador + número → <c>Asc(letra) * 1000 +
    ///   n1 + n2 / 1000</c> (\"A1:2\" e \"A1-2\" → 65001,002);
    /// - dígitos + 1 separador + dígitos → <c>n1 * 1000 + Asc(separador) +
    ///   n2 / 100</c> (\"1A2\" → 1065,02);
    /// - dígitos + sinal → <c>número + 0,1</c> no <c>+</c> e <c>número + 0,0</c> no
    ///   <c>-</c> (\"12+\" → 12,1; \"12-\" → 12,0);
    /// - qualquer outra forma → <see cref="Indefinido"/> (1000000), que ordena por
    ///   último, como no original.
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
                long numero;
                if (texto.Length > 1
                    && long.TryParse(texto.Substring(1), NumberStyles.Integer, CultureInfo.InvariantCulture, out numero))
                {
                    return (texto[0] * 1000.0) + numero;
                }
            }

            // Número + letra ("12A").
            if (texto.Length > 1
                && EhLetra(texto[texto.Length - 1])
                && SomenteDigitosEPonto(texto.Substring(0, texto.Length - 1)))
            {
                double inteiro;
                if (TentarNumero(texto.Substring(0, texto.Length - 1), out inteiro))
                {
                    return inteiro + (texto[texto.Length - 1] / 100.0);
                }
            }

            // Letra + separador + número + separador + número ("A1:2", "A1-2").
            if (EhLetra(texto[0]))
            {
                int separador = PrimeiroSeparador(texto);
                if (separador > 0 && separador < texto.Length - 1)
                {
                    string esquerda = texto.Substring(1, separador - 1);
                    string direita = texto.Substring(separador + 1);
                    if (esquerda.Length > 0
                        && SomenteDigitosEPonto(esquerda)
                        && SomenteDigitosEPonto(direita))
                    {
                        double n1;
                        double n2;
                        if (TentarNumero(esquerda, out n1) && TentarNumero(direita, out n2))
                        {
                            return (texto[0] * 1000.0) + n1 + (n2 / 1000.0);
                        }
                    }
                }
            }

            // Dígitos + 1 separador + dígitos ("1A2").
            string antes;
            string meio;
            string depois;
            if (DividePorSeparador(texto, out antes, out meio, out depois))
            {
                double n1;
                double n2;
                if (TentarNumero(antes, out n1) && TentarNumero(depois, out n2))
                {
                    return (n1 * 1000.0) + meio[0] + (n2 / 100.0);
                }
            }

            // Dígitos + sinal ("12+" → 12,1; "12-" → 12,0).
            if (texto.IndexOf('+') >= 0 || texto.IndexOf('-') >= 0)
            {
                string digitos = string.Empty;
                int i = 0;
                while (i < texto.Length && texto[i] >= '0' && texto[i] <= '9')
                {
                    digitos += texto[i];
                    i++;
                }

                double baseNumerica;
                if (digitos.Length > 0 && TentarNumero(digitos, out baseNumerica))
                {
                    return texto.IndexOf('+') >= 0 ? baseNumerica + 0.1 : baseNumerica;
                }
            }

            return Indefinido;
        }

        /// <summary>
        /// Divisão do <c>num4</c> do original: dígitos antes do primeiro
        /// separador, o separador, e os dígitos depois — exigindo **exatamente um**
        /// separador (que não o ponto decimal) e dígitos de ambos os lados.
        /// </summary>
        private static bool DividePorSeparador(string texto, out string antes, out string meio, out string depois)
        {
            antes = string.Empty;
            meio = null;
            depois = string.Empty;
            int contador = 1;

            foreach (char c in texto)
            {
                if (c == '.')
                {
                    continue;
                }

                if (c >= '0' && c <= '9')
                {
                    if (contador == 2)
                    {
                        depois += c;
                    }
                    else if (contador == 1)
                    {
                        antes += c;
                    }

                    continue;
                }

                meio = c.ToString();
                contador++;
            }

            return contador == 2 && antes.Length > 0 && depois.Length > 0;
        }

        /// <summary>O primeiro separador na ordem do original: <c>:</c>, senão <c>-</c>, senão <c>.</c>.</summary>
        private static int PrimeiroSeparador(string texto)
        {
            int i = texto.IndexOf(':');
            if (i >= 0)
            {
                return i;
            }

            i = texto.IndexOf('-');
            if (i >= 0)
            {
                return i;
            }

            return texto.IndexOf('.');
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

        private static bool TentarNumero(string texto, out double valor)
        {
            return double.TryParse(texto, NumberStyles.Float, CultureInfo.InvariantCulture, out valor);
        }
    }
}

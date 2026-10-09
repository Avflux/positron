using System;
using System.Globalization;

namespace Positron.Data
{
    /// <summary>
    /// Conversão **tolerante** dos valores de XData/Xrecord.
    ///
    /// O dado é de terceiro: o mesmo campo chega como <c>short</c>, <c>int</c>,
    /// <c>double</c> ou **string** (<c>"5"</c>, <c>"5.0"</c>, <c>"5,0"</c>,
    /// <c>""</c>) conforme quem gravou e como o CAD devolve o registro.
    /// <c>Convert.ToInt32("5.0")</c> estoura <see cref="FormatException"/> e
    /// derrubava o comando inteiro dentro do CAD — medido no desenho funcional
    /// real. Aqui a leitura **nunca lança**: o que não dá para interpretar vira
    /// zero (dado ausente, não erro fatal).
    /// </summary>
    public static class XDataNumero
    {
        public static int Inteiro(object valor)
        {
            double numero = Real(valor);
            return (int)Math.Round(numero, MidpointRounding.AwayFromZero);
        }

        public static short Curto(object valor)
        {
            return (short)Inteiro(valor);
        }

        public static double Real(object valor)
        {
            if (valor == null || valor is DBNull)
            {
                return 0.0;
            }

            if (valor is double)
            {
                return (double)valor;
            }

            if (valor is float)
            {
                return (float)valor;
            }

            if (valor is short)
            {
                return (short)valor;
            }

            if (valor is int)
            {
                return (int)valor;
            }

            if (valor is long)
            {
                return (long)valor;
            }

            if (valor is decimal)
            {
                return (double)(decimal)valor;
            }

            if (valor is bool)
            {
                return (bool)valor ? 1.0 : 0.0;
            }

            string texto = valor as string ?? Convert.ToString(valor);
            if (texto == null)
            {
                return 0.0;
            }

            texto = texto.Trim();
            if (texto.Length == 0)
            {
                return 0.0;
            }

            double numero;
            if (double.TryParse(texto, NumberStyles.Float, CultureInfo.InvariantCulture, out numero))
            {
                return numero;
            }

            // Alguns gravadores usam a vírgula decimal (cultura pt-BR).
            if (double.TryParse(texto.Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out numero))
            {
                return numero;
            }

            return 0.0;
        }

        public static bool Booleano(object valor)
        {
            if (valor == null || valor is DBNull)
            {
                return false;
            }

            if (valor is bool)
            {
                return (bool)valor;
            }

            if (Real(valor) != 0.0)
            {
                return true;
            }

            string texto = valor as string;
            return texto != null && string.Equals(texto.Trim(), "true", StringComparison.OrdinalIgnoreCase);
        }
    }
}

using System;
using System.Globalization;

namespace Positron.Data.Paginas
{
    /// <summary>Uma página calculada: o número, a letra (vazia quando não há), o nome e o decimal.</summary>
    public sealed class PaginaCalculada
    {
        public int PgNum { get; set; }

        public string PgAlfa { get; set; }

        public string Pagina { get; set; }

        public double PgDec { get; set; }
    }

    /// <summary>
    /// A **fatia 3** da frente 10: o `Pagina.calculaNovaPagina` do reverso — a página que cabe
    /// **entre** a anterior (`pagAnt`) e a posterior (`pagPost`), com o `Conf.PassoPagina`.
    ///
    /// Traduzido fielmente: o original parte o número/letra de cada lado (`Asc` da última letra e
    /// o prefixo numérico), decide por **quatro** combinações (numérico × alfanumérico) e devolve
    /// `PgNum` + `PgAlfa` (letter vazia quando o código é 64, que é a página "seca"). Posterior
    /// vazio vale o sentinela `1000000` — o "fim", como no original.
    ///
    /// **Nota:** o `0` que aparece em alguns ramos é do próprio reverso (o valor inválido que os
    /// chamadores tratam); o teste fixa esses casos com o comportamento original.
    /// </summary>
    public static class NovaPaginaEntre
    {
        public const string Fim = "1000000";

        public static PaginaCalculada Calcular(string anterior, string posterior, int passoPagina)
        {
            string textoPost = (posterior ?? string.Empty).Trim();
            if (textoPost.Length == 0)
            {
                textoPost = Fim;
            }

            string textoAnt = (anterior ?? string.Empty).Trim();

            bool antNumerico = PaginaNumerada.EhNumerico(textoAnt);
            bool postNumerico = PaginaNumerada.EhNumerico(textoPost);

            // No ramo numérico o original usa o número **inteiro** (`ToInteger(pagina)`); no
            // alfanumérico, o `Asc` da última letra e o prefixo (`Mid(1, len-1)`).
            int num = postNumerico ? 64 : Letra(textoPost);
            int num2 = postNumerico ? Numero(textoPost) : Prefixo(textoPost);
            int num3 = antNumerico ? 64 : Letra(textoAnt);
            int num4 = antNumerico ? Numero(textoAnt) : Prefixo(textoAnt);
            int num5 = 0;
            int num6 = 0;

            if (antNumerico && postNumerico)
            {
                if (num2 - num4 <= passoPagina)
                {
                    if (num2 <= num4 + 1)
                    {
                        num5 = num4;
                        num6 = 65;
                    }
                    else
                    {
                        num5 = num4 + 1;
                        num6 = 64;
                    }
                }
                else
                {
                    num5 = num4 + passoPagina;
                    num6 = 64;
                }
            }

            if (antNumerico && !postNumerico)
            {
                if (num2 - num4 <= passoPagina)
                {
                    if (num2 <= num4 + 1)
                    {
                        if (num2 != num4 + 1)
                        {
                            if (num2 == num4)
                            {
                                num6 = 65;
                                num5 = 65 != num ? num4 : 0;
                            }
                        }
                        else
                        {
                            num5 = num4;
                            num6 = 65;
                        }
                    }
                    else
                    {
                        num5 = num4 + 1;
                        num6 = 64;
                    }
                }
                else
                {
                    num5 = num4 + passoPagina;
                    num6 = 64;
                }
            }

            if (!antNumerico && postNumerico)
            {
                if (num2 - num4 <= passoPagina)
                {
                    if (num2 <= num4 + 1)
                    {
                        if (num2 == num4 + 1)
                        {
                            num6 = num3 + 1;
                            num5 = num6 <= 90 ? num4 : 0;
                        }
                    }
                    else
                    {
                        num5 = num4 + 1;
                        num6 = 64;
                    }
                }
                else
                {
                    num5 = num4 + passoPagina;
                    num6 = 64;
                }
            }

            if (!antNumerico && !postNumerico)
            {
                if (num2 - num4 <= passoPagina)
                {
                    if (num2 <= num4 + 1)
                    {
                        if (num2 != num4 + 1)
                        {
                            if (num2 == num4)
                            {
                                num6 = num3 + 1;
                                num5 = num6 < num ? num4 : 0;
                            }
                        }
                        else
                        {
                            num6 = num3 + 1;
                            if (num6 > 90)
                            {
                                num6 = num - 1;
                                num5 = num6 > 64 ? num2 : 0;
                            }
                            else
                            {
                                num5 = num4;
                            }
                        }
                    }
                    else
                    {
                        num5 = num4 + 1;
                        num6 = 64;
                    }
                }
                else
                {
                    num5 = num4 + passoPagina;
                    num6 = 64;
                }
            }

            PaginaCalculada pagina = new PaginaCalculada { PgNum = num5 };
            pagina.PgAlfa = num6 != 64 ? ((char)num6).ToString() : string.Empty;
            pagina.Pagina = pagina.PgNum.ToString(CultureInfo.InvariantCulture) + pagina.PgAlfa;
            pagina.PgDec = PaginaNumerada.Decimal(pagina.Pagina);
            return pagina;
        }

        /// <summary>
        /// Cabe a página? O original só cria quando `PgNum` é diferente de zero (a mensagem 31/32
        /// quando não cabe). Sem essa guarda, `0B` viraria o layer `B` no `Normalizar`.
        /// </summary>
        public static bool Cabe(PaginaCalculada pagina)
        {
            return pagina != null && pagina.PgNum != 0;
        }

        /// <summary>O `Asc` da última letra (0 quando não é letra).</summary>
        private static int Letra(string pagina)
        {
            if (string.IsNullOrEmpty(pagina))
            {
                return 0;
            }

            return pagina[pagina.Length - 1];
        }

        /// <summary>O número inteiro da página (`ToInteger(pagina)` no ramo numérico).</summary>
        private static int Numero(string pagina)
        {
            int valor;
            return int.TryParse(pagina, NumberStyles.Integer, CultureInfo.InvariantCulture, out valor) ? valor : 0;
        }

        /// <summary>O prefixo numérico como inteiro (0 quando não é número) — o `Mid` + `ToInteger`.</summary>
        private static int Prefixo(string pagina)
        {
            if (string.IsNullOrEmpty(pagina) || pagina.Length < 2)
            {
                return 0;
            }

            int valor;
            return int.TryParse(pagina.Substring(0, pagina.Length - 1), out valor) ? valor : 0;
        }
    }
}

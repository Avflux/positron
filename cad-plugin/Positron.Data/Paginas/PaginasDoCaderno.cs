using System;
using System.Collections.Generic;

namespace Positron.Data.Paginas
{
    /// <summary>Uma página do caderno — o nome (que é o layer) e o seu alternativo.</summary>
    public sealed class PaginaDoCaderno
    {
        public string Nome { get; set; }

        public string Alternativo { get; set; }
    }

    /// <summary>
    /// A **fatia 2** da frente 10 (páginas/caderno): o nome da página a partir do layer e as
    /// buscas na lista de páginas — o <c>LayerValido</c>, o <c>montaNumeroPagina</c>, o
    /// <c>localizaPaginaMatriz</c>, o <c>BuscaProximaPaginaValida</c> e o <c>BuscaAlternativo</c>
    /// do <c>Pagina.cs</c> do reverso, sem a matriz de páginas (que aqui é uma lista).
    /// </summary>
    public static class PaginasDoCaderno
    {
        /// <summary>
        /// O layer é uma página válida? O original aceita um número <b>maior que zero</b> ou um
        /// número seguido de um dígito/letra **maiúscula** (o <c>Asc</c> entre 48-57 ou 65-90).
        /// </summary>
        public static bool LayerValido(string pagina)
        {
            string texto = (pagina ?? string.Empty).Trim();
            if (texto.Length == 0)
            {
                return false;
            }

            int numero;
            if (int.TryParse(texto, out numero))
            {
                return numero > 0;
            }

            string prefixo = texto.Substring(0, texto.Length - 1);
            double baseNumerica;
            if (prefixo.Length == 0 ||
                !double.TryParse(prefixo, System.Globalization.NumberStyles.Float,
                    System.Globalization.CultureInfo.InvariantCulture, out baseNumerica))
            {
                return false;
            }

            char ultimo = texto[texto.Length - 1];
            return (ultimo >= '0' && ultimo <= '9') || (ultimo >= 'A' && ultimo <= 'Z');
        }

        /// <summary>
        /// O **número da página** a partir do layer (o <c>montaNumeroPagina</c>): tira os zeros à
        /// esquerda e, quando o caderno tem largura fixa, completa com zeros — com **um a mais**
        /// quando o texto não é numérico, para caber a letra.
        /// </summary>
        public static string MontaNumeroPagina(string layer, int larguraFixaPaginas)
        {
            string texto = (layer ?? string.Empty).Trim();
            while (texto.Length > 0 && texto[0] == '0')
            {
                texto = texto.Substring(1);
            }

            if (larguraFixaPaginas != 0)
            {
                double numero;
                bool numerico = double.TryParse(texto, System.Globalization.NumberStyles.Float,
                    System.Globalization.CultureInfo.InvariantCulture, out numero);
                if (!(numerico && texto.Length >= larguraFixaPaginas) && texto.Length <= larguraFixaPaginas)
                {
                    int faltam = larguraFixaPaginas - texto.Length;
                    if (!numerico)
                    {
                        faltam++;
                    }

                    texto = new string('0', faltam) + texto;
                }
            }

            return texto;
        }

        /// <summary>
        /// O índice **1-based** da página na lista (o <c>localizaPaginaMatriz</c>) — <c>0</c> quando
        /// não está; a comparação é sem caixa, como o <c>TextCompare</c> do original.
        /// </summary>
        public static int Indice(IReadOnlyList<PaginaDoCaderno> paginas, string pagina)
        {
            if (paginas == null)
            {
                return 0;
            }

            for (int i = 0; i < paginas.Count; i++)
            {
                if (paginas[i] != null &&
                    string.Equals(paginas[i].Nome ?? string.Empty, pagina ?? string.Empty, StringComparison.OrdinalIgnoreCase))
                {
                    return i + 1;
                }
            }

            return 0;
        }

        /// <summary>
        /// A **próxima** página válida da lista (o <c>BuscaProximaPaginaValida</c>) — vazio quando a
        /// página não está ou é a última.
        /// </summary>
        public static string ProximaValida(IReadOnlyList<PaginaDoCaderno> paginas, string pagina)
        {
            if (paginas == null)
            {
                return string.Empty;
            }

            for (int i = 0; i < paginas.Count - 1; i++)
            {
                if (paginas[i] != null &&
                    string.Equals(paginas[i].Nome ?? string.Empty, pagina ?? string.Empty, StringComparison.OrdinalIgnoreCase))
                {
                    return paginas[i + 1] == null ? string.Empty : (paginas[i + 1].Nome ?? string.Empty);
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// O **alternativo** da página (o <c>BuscaAlternativo</c>); com
        /// <paramref name="retornaVazio"/> falso e o alternativo vazio, devolve a própria página.
        /// </summary>
        public static string Alternativo(IReadOnlyList<PaginaDoCaderno> paginas, string pagina, bool retornaVazio)
        {
            string alternativo = string.Empty;
            if (paginas != null)
            {
                for (int i = 0; i < paginas.Count; i++)
                {
                    if (paginas[i] != null &&
                        string.Equals(paginas[i].Nome ?? string.Empty, pagina ?? string.Empty, StringComparison.OrdinalIgnoreCase))
                    {
                        alternativo = paginas[i].Alternativo ?? string.Empty;
                        break;
                    }
                }
            }

            if (!retornaVazio && alternativo.Length == 0)
            {
                alternativo = pagina ?? string.Empty;
            }

            return alternativo;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;

namespace Positron.Data.Layout
{
    /// <summary>Uma página do desenho (um layer válido) com a unidade e o alternativo do XData.</summary>
    public sealed class PaginaDesenho
    {
        public string Pagina { get; set; }

        public string Unidade { get; set; }

        public string Alternativo { get; set; }
    }

    /// <summary>
    /// A **matriz de páginas** do desenho — o <c>DeclaracoesGeral.mPaginas</c> do
    /// original, montado por <c>Pagina.CarregaPaginas</c> a partir da
    /// <c>LayerTable</c> (não do banco).
    ///
    /// Só entram os layers que passam no <c>Pagina.LayerValido</c>: um número
    /// positivo, ou <c>&lt;número&gt;&lt;dígito|letra maiúscula&gt;</c> (ex.:
    /// <c>12</c>, <c>12A</c>, <c>1B</c>). De cada um vêm a <c>unidade</c> e o
    /// <c>alternativo</c> do XData do app <c>Eletron</c> (marcador
    /// <c>UNIDADE</c>).
    ///
    /// <see cref="BuscaAlternativo"/> é o que o <c>frmCompilarFiacao</c> usa para
    /// montar a coluna <c>Pagina</c> quando <c>Conf.incluirColuna</c> é 3..6; a
    /// projeção do recoder ainda usa o layer cru (caso 0..2), mas a regra de
    /// "página ausente" do <c>VERIF</c> já olha esta matriz.
    /// </summary>
    public sealed class PaginaMatrix
    {
        private readonly Dictionary<string, PaginaDesenho> _porPagina =
            new Dictionary<string, PaginaDesenho>(StringComparer.OrdinalIgnoreCase);

        public static PaginaMatrix Vazia
        {
            get { return new PaginaMatrix(); }
        }

        public bool EstaVazia
        {
            get { return _porPagina.Count == 0; }
        }

        public int NumPaginas
        {
            get { return _porPagina.Count; }
        }

        public static PaginaMatrix Ler(IEnumerable<PaginaDesenho> paginas)
        {
            PaginaMatrix matriz = new PaginaMatrix();
            if (paginas == null)
            {
                return matriz;
            }

            foreach (PaginaDesenho pagina in paginas)
            {
                if (pagina == null || string.IsNullOrEmpty(pagina.Pagina))
                {
                    continue;
                }

                matriz._porPagina[pagina.Pagina] = pagina;
            }

            return matriz;
        }

        /// <summary>O layer é uma página do desenho? (o <c>Pagina.LayerValido</c> do original)</summary>
        public bool Contem(string pagina)
        {
            return pagina != null && _porPagina.ContainsKey(pagina);
        }

        public PaginaDesenho Buscar(string pagina)
        {
            PaginaDesenho encontrada;
            if (pagina != null && _porPagina.TryGetValue(pagina, out encontrada))
            {
                return encontrada;
            }

            return null;
        }

        /// <summary>
        /// O <c>Pagina.BuscaAlternativo</c>: devolve o <c>alternativo</c> do layer.
        /// Sem alternativo, devolve o próprio layer quando
        /// <paramref name="bretornaVazio"/> é <c>false</c> — e vazio quando é
        /// <c>true</c>.
        /// </summary>
        public string BuscaAlternativo(string pagina, bool bretornaVazio)
        {
            string texto = "";
            PaginaDesenho encontrada = Buscar(pagina);
            if (encontrada != null && encontrada.Alternativo != null)
            {
                texto = encontrada.Alternativo;
            }

            if (!bretornaVazio && texto.Length == 0)
            {
                texto = pagina;
            }

            return texto;
        }

        /// <summary>
        /// O <c>Pagina.LayerValido</c>: número positivo, ou
        /// <c>&lt;número&gt;&lt;dígito|letra maiúscula&gt;</c>. O <c>A1</c> e o
        /// <c>1a</c> ficam de fora (como no original).
        /// </summary>
        public static bool LayerValido(string pagina)
        {
            if (string.IsNullOrEmpty(pagina))
            {
                return false;
            }

            if (!EhNumerico(pagina))
            {
                // O original lê `Mid(pagina, 1, Len-1)`: sem um caractere antes do
                // último, não há o que validar.
                if (pagina.Length < 2)
                {
                    return false;
                }

                if (!EhNumerico(pagina.Substring(0, pagina.Length - 1)))
                {
                    return false;
                }

                char ultimo = pagina[pagina.Length - 1];
                return (ultimo >= '0' && ultimo <= '9') || (ultimo >= 'A' && ultimo <= 'Z');
            }

            double numero;
            return double.TryParse(pagina, NumberStyles.Float, CultureInfo.InvariantCulture, out numero)
                && numero > 0;
        }

        private static bool EhNumerico(string texto)
        {
            if (string.IsNullOrEmpty(texto))
            {
                return false;
            }

            double valor;
            return double.TryParse(texto, NumberStyles.Float, CultureInfo.InvariantCulture, out valor);
        }
    }

    /// <summary>
    /// Como a coluna <c>Pagina</c> é montada a partir do layer — o switch
    /// <c>Conf.incluirColuna</c> do <c>frmCompilarFiacao</c>:
    ///
    /// | valor | saída |
    /// |---|---|
    /// | <c>0..2</c> | o layer cru |
    /// | <c>3..5</c> | <c>Pagina.BuscaAlternativo(layer, false)</c> — o alternativo, ou o próprio layer |
    /// | <c>6</c> | <c>(layer)</c> + separador + alternativo (o separador só entra se houver alternativo) |
    ///
    /// Layer vazio devolve vazio: as reservas de borne entram com <c>Pagina = ""</c> e
    /// não podem virar <c>"()"</c>.
    /// </summary>
    public sealed class ColunaPagina
    {
        private readonly PaginaMatrix _matriz;
        private readonly int _incluirColuna;
        private readonly string _separador;

        public ColunaPagina(PaginaMatrix matriz, int incluirColuna, string separador)
        {
            _matriz = matriz ?? PaginaMatrix.Vazia;
            _incluirColuna = incluirColuna;
            _separador = separador ?? string.Empty;
        }

        /// <summary>Sem matriz e sem config: devolve o layer (caso <c>0..2</c>).</summary>
        public static ColunaPagina Crua
        {
            get { return new ColunaPagina(PaginaMatrix.Vazia, 0, string.Empty); }
        }

        public string Para(string layer)
        {
            if (string.IsNullOrEmpty(layer))
            {
                return layer ?? string.Empty;
            }

            if (_incluirColuna >= 3 && _incluirColuna <= 5)
            {
                return _matriz.BuscaAlternativo(layer, false);
            }

            if (_incluirColuna == 6)
            {
                string texto = "(" + layer + ")";
                string alternativo = _matriz.BuscaAlternativo(layer, true);
                if (alternativo.Length > 0)
                {
                    texto = texto + _separador + alternativo;
                }

                return texto;
            }

            return layer;
        }
    }
}

using System;

namespace Positron.Data.Paginas
{
    /// <summary>
    /// A janela de zoom em volta de uma entidade: o centro e o tamanho da vista que o
    /// <c>ZoomWin</c> do original monta.
    /// </summary>
    public struct JanelaDeZoom
    {
        public double CentroX;
        public double CentroY;
        public double Largura;
        public double Altura;
    }

    /// <summary>
    /// O <c>EncontraHandle</c> do original (<c>clsUtilitarios.cs:950</c>, o último item de regra
    /// da frente 2): o usuário digita um handle, o comando acha a entidade, **ativa a página** dela
    /// (o <c>Pagina.AtivaPagina(entidade.Layer)</c> — ver <see cref="PaginaAtiva"/>) e dá zoom nela
    /// (o <c>Caderno.ZEntity(id, 20)</c>).
    ///
    /// O que é puro está aqui: a leitura do texto do handle (o <c>Geral.HandleToObject</c>) e a
    /// janela do <c>ZEntity</c>/<c>ZoomWin</c>. Achar a entidade, ativar e mudar a vista são do adapter.
    /// </summary>
    public static class LocalizacaoPorHandle
    {
        /// <summary>A margem, em unidades do desenho, em volta da entidade (o <c>iTamanho = 20</c> da chamada).</summary>
        public const double MargemDoZoom = 20;

        /// <summary>
        /// O número do handle digitado — o <c>Convert.ToInt64(sHandle, 16)</c> do
        /// <c>HandleToObject</c>, que aceita o prefixo <c>0x</c>; vazio ou inválido devolve
        /// <c>null</c> (o original engole a exceção e não acha nada). **Desvio:** o texto é aparado
        /// antes (o <c>GetString</c> do original tem <c>AllowSpaces</c> e um espaço sobrando
        /// fazia o handle não ser achado).
        /// </summary>
        public static long? LerHandle(string texto)
        {
            string limpo = (texto ?? string.Empty).Trim();
            if (limpo.Length == 0)
            {
                return null;
            }

            try
            {
                return Convert.ToInt64(limpo, 16);
            }
            catch (FormatException)
            {
                return null;
            }
            catch (OverflowException)
            {
                return null;
            }
            catch (ArgumentException)
            {
                return null;
            }
        }

        /// <summary>
        /// A vista do <c>ZEntity</c>: a caixa da entidade (<c>Bounds</c>) aumentada da
        /// <paramref name="margem"/> nos quatro lados, e o <c>ZoomWin</c> tomando o centro, a
        /// largura e a altura dela.
        /// </summary>
        public static JanelaDeZoom Janela(double minX, double minY, double maxX, double maxY, double margem)
        {
            double x1 = minX - margem;
            double y1 = minY - margem;
            double x2 = maxX + margem;
            double y2 = maxY + margem;

            return new JanelaDeZoom
            {
                CentroX = x1 + (x2 - x1) / 2.0,
                CentroY = y1 + (y2 - y1) / 2.0,
                Largura = x2 - x1,
                Altura = y2 - y1,
            };
        }
    }
}

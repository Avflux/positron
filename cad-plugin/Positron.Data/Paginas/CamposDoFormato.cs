using System;
using System.Collections.Generic;

namespace Positron.Data.Paginas
{
    /// <summary>
    /// A **cadeia que o original roda depois de inserir o bloco do formato novo** — o trecho do
    /// <c>Caderno.CriaCaderno</c> que recria os campos das páginas e define o conteúdo dos campos
    /// <c>CONT</c>/<c>FL</c>/<c>TOT</c>/<c>ALTERNATIVO</c> (o <c>Pagina.ApagarCamposPaginas</c>, o
    /// <c>criaCamposTOT</c> e o <c>AtualizaContTotFl</c>). Aqui ficam só as decisões **puras**; quem
    /// fala com o CAD é o adapter do plugin.
    ///
    /// O mapa dos campos que cada página recebe já é o <see cref="CriacaoDePagina.CampoDoFormato.De"/>
    /// (o mesmo do <c>criaCamposFormato</c>, reusado no <c>criarUmaNovaPagina</c>); o que esta classe
    /// acrescenta é (1) a decisão do que o <c>ApagarCamposPaginas</c> apaga, (2) o campo <c>TOT</c> do
    /// <c>criaCamposTOT</c> e (3) o valor que o <c>AtualizaContTotFl</c> escreve em cada campo.
    /// </summary>
    public static class CamposDoFormato
    {
        /// <summary>O índice do <c>ALTERNATIVO</c> no XData do título (o caso 9 do <c>AtualizaContTotFl</c>).</summary>
        public const int IndiceAlternativo = 9;

        /// <summary>O índice do <c>REV</c> no XData do título (o caso 8, que o <c>AtualizaContTotFl</c> não toca).</summary>
        public const int IndiceRev = 8;

        /// <summary>O índice do <c>TOT</c> no XData do título (o caso 7).</summary>
        public const int IndiceTot = 7;

        /// <summary>O índice do <c>FL</c> no XData do título (o caso 6).</summary>
        public const int IndiceFl = 6;

        /// <summary>O índice do <c>CONT</c> no XData do título (o caso 5).</summary>
        public const int IndiceCont = 5;

        /// <summary>O texto que o campo <c>TOT</c> nasce com (o <c>dtepniSZGL6(val6, "1", …)</c>).</summary>
        public const string TextoDoTot = "1";

        /// <summary>
        /// Um texto com o XData do título é um **campo de página** e o <c>ApagarCamposPaginas</c>
        /// apaga todos eles antes de recriar (a varredura é pelo <c>LeXDataTitulo &gt; 0</c>).
        /// </summary>
        public static bool EhCampoDePagina(int indice)
        {
            return indice > 0;
        }

        /// <summary>
        /// O atributo do formato gera um campo <c>TOT</c>? A condição do <c>criaCamposTOT</c>: ser do
        /// conjunto protegido, ter a tag <c>TOT</c> e (a) estar no layer da capa ou no <c>-1</c>. O
        /// filtro do layer (capa/<c>-1</c>) é do adapter, que conhece a capa do desenho.
        /// </summary>
        public static bool GeraCampoTot(bool protegida, string tag)
        {
            return protegida
                && string.Equals((tag ?? string.Empty).Trim(), "TOT", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// O texto que o <c>AtualizaContTotFl</c> escreve no campo de título de índice
        /// <paramref name="indice"/>, ou <c>null</c> quando o passo não mexe nele (o <c>REV</c> e
        /// qualquer outro índice). Os casos são os do <c>switch (LeXDataTitulo)</c>:
        /// <list type="bullet">
        /// <item><c>9</c> (ALTERNATIVO): o alternativo da própria página (o <c>BuscaAlternativo</c>);</item>
        /// <item><c>5</c> (CONT): a **próxima** página válida (o <c>BuscaProximaPaginaValida</c>);</item>
        /// <item><c>6</c> (FL): o nome do layer (= a página);</item>
        /// <item><c>7</c> (TOT): a **última** página do caderno.</item>
        /// </list>
        /// Com o <c>incluirColuna</c> em 3..5 (o <c>Conf.incluirColuna</c>), o <c>CONT</c> e o
        /// <c>TOT</c> trocam a página pelo **alternativo** dela quando ele existe — o ramo
        /// <c>BuscaAlternativo(text, true)</c> do original.
        /// </summary>
        public static string TextoDoContTotFl(
            int indice,
            string layer,
            string ultimaPagina,
            IReadOnlyList<PaginaDoCaderno> paginas,
            int incluirColuna)
        {
            switch (indice)
            {
                case IndiceAlternativo:
                    return PaginasDoCaderno.Alternativo(paginas, layer, true);

                case IndiceCont:
                    return ComAlternativo(PaginasDoCaderno.ProximaValida(paginas, layer), paginas, incluirColuna);

                case IndiceFl:
                    return layer ?? string.Empty;

                case IndiceTot:
                    return ComAlternativo(ultimaPagina, paginas, incluirColuna);

                default:
                    return null;
            }
        }

        /// <summary>
        /// O ramo do <c>incluirColuna</c> 3..5: devolve o alternativo da página quando ele existe,
        /// senão a própria página. Fora de 3..5 devolve a página como veio.
        /// </summary>
        private static string ComAlternativo(string pagina, IReadOnlyList<PaginaDoCaderno> paginas, int incluirColuna)
        {
            string texto = pagina ?? string.Empty;
            if (incluirColuna >= 3 && incluirColuna <= 5)
            {
                string alternativo = PaginasDoCaderno.Alternativo(paginas, texto, true);
                if (alternativo.Length > 0)
                {
                    return alternativo;
                }
            }

            return texto;
        }
    }
}

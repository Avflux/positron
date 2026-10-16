using System;
using Positron.Data.Interligacao;

namespace Positron.Data.Paginas
{
    /// <summary>
    /// Os **derivados** que a exclusão de uma página leva junto — o <c>clsApagar.ApagarDerivados</c>
    /// do reverso (<c>clsApagar.cs:9</c>), chamado pelo <c>Pagina.ApagarElementosPagina</c> antes do
    /// <c>Erase</c> de cada entidade da página.
    ///
    /// Aqui só a decisão pura do ramo da **polyline de interligação**: uma polyline com
    /// <c>INTERLIGACAO</c> de <c>Tipo == 2</c> leva consigo a polyline irmã cujo handle ela guarda
    /// (<c>clsInterligacao.ApagarPL :2087</c>) e os rótulos auxiliares dessa irmã
    /// (<c>ApagarTextosAuxiliaresVeias :2005</c>). Os ramos do dispositivo, do contato auxiliar e da
    /// máscara ficam na fila do <c>ESTADO.md</c>.
    /// </summary>
    public static class DerivadosDaExclusao
    {
        /// <summary>O <c>Tipo</c> da interligação cuja exclusão leva a polyline irmã (<c>ilig.Tipo == 2</c>).</summary>
        public const short TipoComIrma = 2;

        /// <summary>
        /// O handle da polyline irmã a apagar, ou <c>null</c> quando a interligação não é do tipo 2
        /// (ou não guarda handle): o original só chama o <c>ApagarPL</c> no tipo 2.
        /// </summary>
        public static string HandleDaIrma(InterligacaoXData interligacao)
        {
            if (interligacao == null || interligacao.Tipo != TipoComIrma)
            {
                return null;
            }

            string handle = (interligacao.Handle ?? string.Empty).Trim();
            return handle.Length == 0 ? null : handle;
        }

        /// <summary>
        /// O rótulo auxiliar (o campo +2 do <c>AUXINTERLIG</c>, ou o +3 do <c>ELETROSUL</c>) é do
        /// trecho de handle <paramref name="handleDoTrecho"/>? O VB compara com <c>TextCompare</c>
        /// (sem diferenciar caixa).
        /// </summary>
        public static bool RotuloDoTrecho(string handleDoRotulo, string handleDoTrecho)
        {
            if (string.IsNullOrEmpty(handleDoRotulo) || string.IsNullOrEmpty(handleDoTrecho))
            {
                return false;
            }

            return string.Equals(handleDoRotulo, handleDoTrecho, StringComparison.OrdinalIgnoreCase);
        }
    }
}

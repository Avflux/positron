using System;
using System.Collections.Generic;
using Positron.Data.Fiacao;
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
    /// máscara ficam na fila do <c>ESTADO.md</c> — o do **contato auxiliar** (tipo <c>A</c>,
    /// <c>clsDispositivoAuxiliares.limpaInsercaoTabela :2656</c>) entra aqui também: a decisão do tipo
    /// (<see cref="TipoDoDispositivo"/>) e os atributos de inserção que a limpeza zera
    /// (<see cref="AtributoDeInsercao"/>).
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
        /// O <c>XDataDispositivo.verificaTipoDispositivo</c> (<c>XDataDispositivo.cs:15</c>): o tipo
        /// (campo +1) do XData <c>DISPOSITIVO</c>; sem ele, <c>"I"</c> se a entidade tem <c>IMPORTADO</c>;
        /// vazio nos outros casos. <paramref name="dispositivo"/> e <paramref name="importado"/> são os
        /// registros de cada app name (<c>null</c> quando a entidade não os tem).
        /// </summary>
        public static string TipoDoDispositivo(IReadOnlyList<TypedXData> dispositivo, IReadOnlyList<TypedXData> importado)
        {
            if (dispositivo != null)
            {
                return dispositivo.Count > 1 ? Convert.ToString(dispositivo[1].Valor) ?? string.Empty : string.Empty;
            }

            return importado != null ? "I" : string.Empty;
        }

        /// <summary>
        /// É um dos atributos que a <c>limpaInsercaoTabela</c> zera (<c>INSERCAO</c>, <c>INSERCAONA</c> ou
        /// <c>INSERCAONF</c>, em maiúsculas)?
        /// </summary>
        public static bool AtributoDeInsercao(string tag)
        {
            string maiusculo = (tag ?? string.Empty).ToUpperInvariant();
            return maiusculo == "INSERCAO" || maiusculo == "INSERCAONA" || maiusculo == "INSERCAONF";
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

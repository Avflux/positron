using System;

namespace Positron.Data.Correcoes
{
    /// <summary>
    /// O <c>ApagaERROS</c> do <c>clsBlocos</c> (usado pelo <c>RESTPROJ</c>): apaga as entidades
    /// marcadas com o XData <c>ERRO</c>.
    ///
    /// O <c>XDataDispositivosMaster.LerXDataErro</c> do reverso lê o app <c>ERRO</c> e confere se o
    /// **primeiro valor** é o texto esperado (o <c>"ERRO"</c> do <c>clsBlocos</c>, o <c>"PORTAS"</c>
    /// do <c>clsPortas</c>) — sem caixa.
    /// </summary>
    public static class EntidadesDeErro
    {
        public const string AppName = "ERRO";

        public const string Marca = "ERRO";

        /// <summary>O primeiro valor do XData casa com a marca esperada (sem caixa)?</summary>
        public static bool EhMarca(string primeiroValor, string esperado)
        {
            return string.Equals(
                primeiroValor ?? string.Empty, esperado ?? string.Empty, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>A entidade está marcada como erro (a marca é <c>ERRO</c>)?</summary>
        public static bool EhDeErro(string primeiroValor)
        {
            return EhMarca(primeiroValor, Marca);
        }
    }
}

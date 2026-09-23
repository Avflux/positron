using System;

namespace Positron.Data.Limpeza
{
    /// <summary>
    /// O <c>limpaHandleSuperior</c> do <c>Correcao.cs</c> — o comando <c>Limpahandle</c>
    /// (frente 2 do §7.6): zera o <c>Handle</c> do XData <c>CONEXAO</c> das polilinhas de
    /// **derivação** (tipo <c>3</c>).
    ///
    /// É a primeira metade do <c>CorrigeHandleSuperior</c>: o original limpa todos os
    /// handles das derivações e depois re-resolve cada um com o <c>verificaConexao</c>
    /// (o bloco sob o ponto inicial da polilinha). Aquela segunda metade fica **fora**
    /// deste recorte — o recoder ainda não tem o resolvedor por ponto — e por isso o
    /// comando entrega exatamente o que o <c>Limpahandle</c> do original entrega.
    ///
    /// **Diferença registrada:** o original regrava **toda** derivação a cada passada;
    /// aqui só as que têm handle (o efeito é o mesmo e a passada seguinte não regrava
    /// nada, o que deixa a convergência medível).
    /// </summary>
    public static class LimpezaDoHandleDasDerivacoes
    {
        /// <summary>O tipo da conexão que é uma **derivação** (o <c>conex.Tipo == 3</c>).</summary>
        public const short TipoDerivacao = 3;

        /// <summary>A regra do original: tipo <c>3</c> é derivação.</summary>
        public static bool EhDerivacao(int tipo)
        {
            return tipo == TipoDerivacao;
        }

        /// <summary>Só vale regravar quando há handle para limpar.</summary>
        public static bool PrecisaLimpar(string handle)
        {
            return !string.IsNullOrEmpty(handle);
        }
    }
}

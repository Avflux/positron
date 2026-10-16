namespace Positron.Data.Correcoes
{
    /// <summary>
    /// <c>correcaoTextosCircuitos</c> — a terceira das cinco correções automáticas do
    /// <c>IniciarDWG</c> (<c>Correcao.cs:397</c>).
    ///
    /// Ela percorre o ModelSpace procurando <c>DBText</c> com o XData <c>AUXCONEXAO</c> (o texto
    /// auxiliar de circuito, <c>XDataConexao.lerXDataAuxCircuito</c>) **do tipo 1** e, no texto que
    /// está com o <c>VerticalMode</c> em <c>1</c>, faz:
    ///
    /// <code>
    /// Point3d alinhamento = text.AlignmentPoint;
    /// text.VerticalMode = 0;            // Baseline
    /// text.Position = alinhamento;      // o texto não anda de lugar
    /// </code>
    ///
    /// Ou seja: os textos de circuito gravados por uma versão antiga com o modo vertical <c>1</c>
    /// passam a **Baseline na mesma posição da tela** (o <c>Position</c> recebe o
    /// <c>AlignmentPoint</c>, que é o ponto que vale enquanto o modo não é Baseline). Só o índice
    /// <c>1</c> é corrigido — os outros modos verticais o original não toca.
    ///
    /// Quem varre o ModelSpace e escreve é o adapter
    /// (<c>Positron.Plugin.Correcoes.TextosDeCircuitoDoDesenho</c>).
    /// </summary>
    public static class CorrecaoDoTextoDeCircuito
    {
        /// <summary>O tipo do <c>AUXCONEXAO</c> que a correção olha (o <c>tipo == 1</c> do original).</summary>
        public const short TipoDoTextoDeCircuito = 1;

        /// <summary>O <c>VerticalMode</c> que a correção conserta (o único valor que o original testa).</summary>
        public const int VerticalModeCorrigido = 1;

        /// <summary>O <c>VerticalMode</c> que entra no lugar (o <c>Baseline</c> do CAD).</summary>
        public const int VerticalModeAlinhado = 0;

        /// <summary>O texto auxiliar precisa da correção (tipo do XData e modo vertical).</summary>
        public static bool PrecisaCorrigir(short tipo, int verticalMode)
        {
            return tipo == TipoDoTextoDeCircuito && verticalMode == VerticalModeCorrigido;
        }
    }
}

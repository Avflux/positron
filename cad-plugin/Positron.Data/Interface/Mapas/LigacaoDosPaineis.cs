using System.Collections.Generic;

namespace Positron.Data.Interface.Mapas
{
    /// <summary>
    /// Quais **painéis da barra** ficam ligados, pelo **tipo do desenho**
    /// (<c>XDataGeral.verificaTipoXData</c>): o bloco que abre o <c>Iniciar.IniciarDWG</c>
    /// (<c>Iniciar.cs:72-127</c>).
    ///
    /// Os nove painéis do original (o mapa é o <see cref="BarraDoReverso"/>), com o tipo do desenho:
    ///
    /// - **E** (Elétron, o XData <c>Eletron</c> no ModelSpace): **todos** os painéis ligados;
    /// - **V** (desenho vazio, sem XData nenhum): os **dois primeiros** (Configuração e Caderno)
    ///   ligados e os painéis do **índice 2 até o penúltimo** desligados — o **último** painel
    ///   (Help) o original **não toca**: ele fica como está, e como a criação o deixa ligado, sai
    ///   ligado. É o quirk da rodada 181, mantido como está no original;
    /// - **D** (DiagLog) e **A** (ArqNet): **todos** os painéis desligados (o desenho não é do
    ///   Elétron, então a barra fica à vista e inerte).
    ///
    /// O laço do original usa o **número de painéis do momento** (`ribbon.Tabs[indexRibbon].Panels`),
    /// não uma constante: por isso a regra recebe a quantidade. Quem mexeu nos painéis de volta para
    /// o tipo E foi o desenho ser fechado e outro (do Elétron) ativado — o <c>IniciarDWG</c> roda a
    /// cada troca de documento.
    ///
    /// O estado de cada painel é **três** valores, e não dois: <c>true</c> liga, <c>false</c> desliga e
    /// <c>null</c> **não mexe** (o último painel no tipo V). Quem aplica é
    /// <c>Positron.Plugin.Interface.Barra.BarraDeFerramentas</c>.
    /// </summary>
    public static class LigacaoDosPaineis
    {
        /// <summary>Desenho do Elétron (o XData <c>Eletron</c>).</summary>
        public const string TipoEletron = "E";

        /// <summary>Desenho do DiagLog (o XData <c>DiagLog</c>).</summary>
        public const string TipoDiagLog = "D";

        /// <summary>Desenho do ArqNet (o XData <c>ArqNet</c>).</summary>
        public const string TipoArqNet = "A";

        /// <summary>Desenho sem XData nenhum dos três produtos.</summary>
        public const string TipoVazio = "V";

        /// <summary>Painel da Configuração — o primeiro ligado no tipo V.</summary>
        public const int PrimeiroPainelDoVazio = 0;

        /// <summary>Primeiro painel que o tipo V **não** olha (o laço vai até o penúltimo).</summary>
        public const int PrimeiroPainelDesligadoNoVazio = 1;

        /// <summary>
        /// O plano por índice de painel: <c>true</c> liga, <c>false</c> desliga e <c>null</c> deixa como
        /// está. Ver o resumo da regra na classe.
        /// </summary>
        public static IReadOnlyList<bool?> Plano(string tipo, int quantidade)
        {
            List<bool?> plano = new List<bool?>();
            if (quantidade <= 0)
            {
                return plano;
            }

            for (int i = 0; i < quantidade; i++)
            {
                plano.Add(false);
            }

            if (string.Equals(tipo, TipoEletron, System.StringComparison.OrdinalIgnoreCase))
            {
                for (int i = 0; i < quantidade; i++)
                {
                    plano[i] = true;
                }

                return plano;
            }

            if (!string.Equals(tipo, TipoVazio, System.StringComparison.OrdinalIgnoreCase))
            {
                // D, A e qualquer outro tipo: tudo desligado.
                return plano;
            }

            // O tipo V: os dois primeiros ligados, do índice 2 até o penúltimo desligados e o
            // último **intocado** (o laço `for j = 2 to count - 2` do original).
            for (int i = 0; i <= PrimeiroPainelDesligadoNoVazio && i < quantidade; i++)
            {
                plano[i] = true;
            }

            plano[quantidade - 1] = null;
            return plano;
        }
    }
}

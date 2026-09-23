using System;

namespace Positron.Data.Correcoes
{
    /// <summary>
    /// O <c>verificaConexao</c> do <c>Correcao.cs</c> — o **resolvedor por ponto** que a segunda
    /// metade do <c>CorrigeHandleSuperior</c> usa (frente 2 do §7.6): acha a conexão
    /// **vizinha** do ponto inicial de uma derivação.
    ///
    /// O original abre uma janela de seleção de ±<c>0.2</c> em volta do ponto
    /// (<c>SelectCrossingWindow</c>), anda pelos objetos e pega o **primeiro** que:
    ///
    /// 1. está na **mesma camada** (sem caixa) da derivação;
    /// 2. **não** é a própria derivação (o handle tem que ser diferente);
    /// 3. é uma polilinha com XData <c>CONEXAO</c>.
    ///
    /// E o tipo do vizinho sai do <c>Jumper</c>: vazio → <c>"C"</c>; <c>"JUMPER"</c> →
    /// <c>"J"</c>; qualquer outro valor → **não mexe** (o <c>sTipo</c> do original fica como
    /// estava).
    ///
    /// **Diferença registrada:** o recoder não usa a seleção do editor — testa os limites da
    /// polilinha contra a **mesma janela** (o equivalente do <c>crossing window</c> aqui) e
    /// percorre o ModelSpace na ordem dele.
    /// </summary>
    public static class ResolvedorDeConexao
    {
        /// <summary>O meio-lado da janela de procura (±0.2, como o original).</summary>
        public const double Janela = 0.2;

        /// <summary>
        /// A janela de ±<see cref="Janela"/> em volta de <c>(x, y)</c> toca os limites
        /// informados? (a versão sem editor do <c>SelectCrossingWindow</c>).
        /// </summary>
        public static bool JanelaToca(double x, double y, double minX, double minY, double maxX, double maxY)
        {
            return !(maxX < x - Janela || minX > x + Janela || maxY < y - Janela || minY > y + Janela);
        }

        /// <summary>
        /// O tipo que o vizinho dá à derivação — <c>"C"</c>, <c>"J"</c>, ou <c>null</c>
        /// quando o original não mexe (o jumper preenchido com outra coisa).
        /// </summary>
        public static string TipoDoVizinho(string jumper)
        {
            string valor = jumper ?? string.Empty;
            if (valor.Length == 0)
            {
                return "C";
            }

            return string.Equals(valor, "JUMPER", StringComparison.OrdinalIgnoreCase) ? "J" : null;
        }

        /// <summary>As duas condições de identidade: mesma camada e handle diferente.</summary>
        public static bool EhVizinho(string layerDoVizinho, string layerDaDerivacao, string handleDoVizinho, string handleDaDerivacao)
        {
            bool mesmaCamada = string.Equals(
                layerDoVizinho ?? string.Empty, layerDaDerivacao ?? string.Empty, StringComparison.OrdinalIgnoreCase);
            bool mesmoHandle = string.Equals(
                handleDoVizinho ?? string.Empty, handleDaDerivacao ?? string.Empty, StringComparison.OrdinalIgnoreCase);
            return mesmaCamada && !mesmoHandle;
        }

        /// <summary>O original só regrava quando algum dos três campos muda.</summary>
        public static bool PrecisaAtualizar(string handle, string nome, int potencial, string novoHandle, string novoNome, int novoPotencial)
        {
            return !string.Equals(handle ?? string.Empty, novoHandle ?? string.Empty, StringComparison.OrdinalIgnoreCase)
                || !string.Equals(nome ?? string.Empty, novoNome ?? string.Empty, StringComparison.OrdinalIgnoreCase)
                || potencial != novoPotencial;
        }
    }
}

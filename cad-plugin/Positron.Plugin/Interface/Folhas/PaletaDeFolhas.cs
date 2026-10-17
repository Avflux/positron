using System;
using Positron.Data;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
#endif

namespace Positron.Plugin.Interface.Folhas
{
    /// <summary>
    /// A **paleta de folhas** — o <c>_pspag</c> do reverso: a **porta** da paleta (o
    /// <see cref="FolhasControle"/> com as páginas do caderno) e a decisão de **onde** ela é
    /// ancorada: <see cref="PaletaAncoravel"/>, o <c>PaletteSet</c> do CAD.
    ///
    /// **Por que a criação do <c>PaletteSet</c> mora em outro tipo** (rodada 138): no
    /// <c>accoreconsole</c> o simples **fato de este método referenciar**
    /// <c>Autodesk.AutoCAD.Windows.PaletteSet</c> já derruba o processo no JIT — medido: com a
    /// referência aqui dentro, o <c>ELET</c> morria sem log nenhum (a sonda, a primeira linha do
    /// corpo, nunca chegava a ser escrita) e o script não alcançava o <c>FIA</c>/<c>INT</c>; com o
    /// tipo de interface isolado num método que **só é chamado quando há janela**, o harness
    /// headless segue o ciclo inteiro. O <c>using</c> de <c>Autodesk.AutoCAD.Windows</c> fica no
    /// arquivo do <see cref="PaletaAncoravel"/>, nunca neste.
    /// </summary>
    internal static class PaletaDeFolhas
    {
        private static FolhasControle _controle;

        internal static FolhasControle Controle { get { return _controle; } }

        /// <summary>
        /// O <c>DeclaracoesGeral._uscPagina</c> do original (<c>DeclaracoesGeral.cs:556</c>): a barra
        /// **compartilhada** que as rotinas longas dirigem. Como lá, ela é a da paleta — o que muda é
        /// que aqui quem chama não depende de a paleta existir: no original o acesso é direto no
        /// objeto estático e as rotinas rodam **depois** do arranque (que abre a paleta pelo
        /// <c>GerenciadorPagina</c>, <c>Comandos.cs:1448-1470</c>, chamado pelo <c>IniciarDWG</c>,
        /// <c>Iniciar.cs:114,123</c>), então o campo nunca chega nulo em uso normal.
        /// </summary>
        internal static ProgressoCompartilhado Progresso { get { return _controle == null ? null : _controle.Progresso; } }

        /// <summary>O <c>_uscPagina.Quantidade = n</c> do original (quem chama define **antes** do <c>pbIniciar</c>).</summary>
        internal static void ProgressoQuantidade(int quantidade)
        {
            if (_controle != null)
            {
                _controle.Progresso.Quantidade = quantidade;
            }
        }

        /// <summary>O <c>pbIniciar()</c>.</summary>
        internal static void ProgressoIniciar()
        {
            if (_controle != null)
            {
                _controle.Progresso.Iniciar();
            }
        }

        /// <summary>O <c>pbPasso(int iPasso = 1)</c>.</summary>
        internal static void ProgressoPasso(int iPasso = 1)
        {
            if (_controle != null)
            {
                _controle.Progresso.Passo(iPasso);
            }
        }

        /// <summary>O <c>pbFim()</c>.</summary>
        internal static void ProgressoFim()
        {
            if (_controle != null)
            {
                _controle.Progresso.Fim();
            }
        }

        /// <summary>Abre (criando na primeira vez) a paleta e devolve quantas páginas mostrou.</summary>
        internal static int Mostrar()
        {
            _controle = _controle ?? new FolhasControle();

            if (SemJanela())
            {
                return _controle.Carregar();
            }

            return PaletaAncoravel.Mostrar(_controle);
        }

        /// <summary>
        /// Relê as páginas na paleta **se ela já foi aberta** (o <c>_uscPagina.ativaPaginaAtalho</c>
        /// do original, que acompanha a página ativada por um comando); devolve quantas mostrou, ou
        /// <c>-1</c> quando ainda não há paleta.
        /// </summary>
        internal static int Recarregar()
        {
            return _controle == null ? -1 : _controle.Carregar();
        }

        /// <summary>
        /// Há janela nesta sessão? O <c>accoreconsole</c> **não** aceita interface — a checagem é o
        /// nome do processo (o sinal direto do host headless) e, como segunda testemunha, a ausência
        /// de janela principal (que só é lida quando o processo não é o core console).
        /// </summary>
        private static bool SemJanela()
        {
#if AUTOCAD
            if (string.Equals(System.Diagnostics.Process.GetCurrentProcess().ProcessName,
                              "accoreconsole", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return Application.MainWindow == null;
#else
            return false;
#endif
        }
    }
}

using System;

namespace Positron.Plugin.Interface
{
    /// <summary>
    /// O <c>Interaction.MsgBox</c> do original: o aviso **chega ao usuário** num diálogo, com o texto
    /// da mMensagem e o título que o original usa. Também vai para a linha de comando (e o log).
    ///
    /// No harness (a variável <c>POSITRON_LOG</c> definida, ver <c>scripts/cad-zwcad-smoke.ps1</c>) o
    /// diálogo não abre: um script não tem quem o feche. É a única diferença, e só existe lá.
    /// </summary>
    internal static class Aviso
    {
        internal static void MsgBox(string texto, string titulo)
        {
            Mostrar(texto, titulo, false);
        }

        /// <summary>O <c>MsgBoxStyle.Critical</c>: o ícone de erro do original (a capa do apagar).</summary>
        internal static void MsgBoxCritico(string texto, string titulo)
        {
            Mostrar(texto, titulo, true);
        }

        private static void Mostrar(string texto, string titulo, bool critico)
        {
            Plugin.Escrever(texto);
            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable(Positron.Data.Configuracao.ConfiguracaoPositron.VariavelLog)))
            {
                return;
            }

#if !POSITRON_SEM_WINFORMS
            System.Windows.Forms.MessageBox.Show(texto, titulo ?? string.Empty,
                System.Windows.Forms.MessageBoxButtons.OK,
                critico ? System.Windows.Forms.MessageBoxIcon.Error : System.Windows.Forms.MessageBoxIcon.Information);
#endif
        }
    }
}

using System;

namespace Positron.Plugin.Interface
{
    /// <summary>
    /// O <c>Interaction.MsgBox</c> do original: o aviso **chega ao usuário** num diálogo, com o texto
    /// da mMensagem e o título que o original usa. Também vai para a linha de comando (e o log).
    ///
    /// As três formas são as do reverso, e cada uma tem o seu <c>MsgBoxStyle</c> lá:
    /// <list type="bullet">
    /// <item><see cref="MsgBox"/> = <c>MsgBox(texto, Information)</c> — o ícone de informação;</item>
    /// <item><see cref="MsgBoxCritico"/> = <c>MsgBox(texto, Critical)</c> — o ícone de erro;</item>
    /// <item><see cref="MsgBoxSemIcone"/> = <c>MsgBox(texto)</c> — sem estilo, só o OK.</item>
    /// </list>
    /// O título é o que está na chamada do reverso: quando ela **não** passa título
    /// (<c>Interaction.MsgBox(texto, Information)</c>, como no 1927 e na mMensagem 28), o diálogo
    /// abre sem título — a convenção já usada na auditoria do `frmEditaTitulos` (rodada 197).
    ///
    /// No harness (a variável <c>POSITRON_LOG</c> definida, ver <c>scripts/cad-zwcad-smoke.ps1</c>) o
    /// diálogo não abre: um script não tem quem o feche. É a única diferença, e só existe lá.
    /// </summary>
    internal static class Aviso
    {
        /// <summary>O <c>MsgBoxStyle.Information</c> do original.</summary>
        internal static void MsgBox(string texto, string titulo)
        {
            Mostrar(texto, titulo, IconeDoAviso.Informacao);
        }

        /// <summary>O <c>MsgBoxStyle.Critical</c>: o ícone de erro do original (a capa do apagar).</summary>
        internal static void MsgBoxCritico(string texto, string titulo)
        {
            Mostrar(texto, titulo, IconeDoAviso.Erro);
        }

        /// <summary>
        /// O <c>Interaction.MsgBox(texto)</c> **sem estilo**: o original o usa na edição da célula
        /// Alternativo (mMensagem 1927, "Máximo de 20 caracteres", `uscPaginas.cs:1773`) — um OK sem
        /// ícone e sem título.
        /// </summary>
        internal static void MsgBoxSemIcone(string texto)
        {
            Mostrar(texto, string.Empty, IconeDoAviso.Nenhum);
        }

        private enum IconeDoAviso
        {
            Nenhum,
            Informacao,
            Erro,
        }

        private static void Mostrar(string texto, string titulo, IconeDoAviso icone)
        {
            Plugin.Escrever(texto);
            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable(Positron.Data.Configuracao.ConfiguracaoPositron.VariavelLog)))
            {
                return;
            }

#if !POSITRON_SEM_WINFORMS
            System.Windows.Forms.MessageBoxIcon estilo =
                icone == IconeDoAviso.Erro ? System.Windows.Forms.MessageBoxIcon.Error
                : icone == IconeDoAviso.Informacao ? System.Windows.Forms.MessageBoxIcon.Information
                : System.Windows.Forms.MessageBoxIcon.None;
            System.Windows.Forms.MessageBox.Show(texto, titulo ?? string.Empty,
                System.Windows.Forms.MessageBoxButtons.OK, estilo);
#endif
        }
    }
}

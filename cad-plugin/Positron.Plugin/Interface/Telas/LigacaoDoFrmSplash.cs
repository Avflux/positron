using System;
using System.Drawing;
using System.Windows.Forms;

namespace Positron.Plugin.Interface.Telas
{
    /// <summary>
    /// A ligação do <c>frmSplash</c> (comandos <c>ONSPL</c> e <c>OFFSPL</c> do original):
    /// exibe a tela de abertura centrada, sem bordas, com transparência azul sobre o bitmap
    /// <c>SplashEL26</c> (<c>frmSplash.cs</c>). Como no original, a tela não tem clique nem tecla:
    /// fecha só pelo comando <c>OFFSPL</c> (<c>Comandos.cs:40</c>).
    /// </summary>
    internal sealed class LigacaoDoFrmSplash : ILigacaoDeTela
    {
        private static Form _instanciaAtiva;

        public string NomeDaTela
        {
            get { return "frmSplash"; }
        }

        /// <summary>Instância atualmente aberta da tela de splash, se houver.</summary>
        public static Form InstanciaAtiva
        {
            get { return _instanciaAtiva != null && !_instanciaAtiva.IsDisposed ? _instanciaAtiva : null; }
        }

        /// <summary>Fecha a tela de splash ativa se estiver aberta. Devolve true se fechou.</summary>
        public static bool Fechar()
        {
            Form splash = InstanciaAtiva;
            if (splash != null)
            {
                splash.Close();
                _instanciaAtiva = null;
                return true;
            }

            return false;
        }

        public void Preencher(Form janela)
        {
            if (janela == null)
            {
                return;
            }

            // Garante o fundo com a imagem do SplashEL26 e a transparência em azul
            if (janela.BackgroundImage == null)
            {
                janela.BackgroundImage = IconesEmbutidos.BitmapDe("SplashEL26");
            }

            janela.BackgroundImageLayout = ImageLayout.Center;
            janela.BackColor = Color.Blue;
            janela.TransparencyKey = Color.Blue;
            janela.FormBorderStyle = FormBorderStyle.None;
            janela.StartPosition = FormStartPosition.CenterScreen;
            janela.TopMost = true;
            janela.ShowIcon = false;
            janela.ShowInTaskbar = false;

            _instanciaAtiva = janela;
            janela.FormClosed += (s, e) =>
            {
                if (_instanciaAtiva == janela)
                {
                    _instanciaAtiva = null;
                }
            };
        }
    }
}

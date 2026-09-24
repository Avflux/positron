using System;
#if !AUTOCAD
using ZwSoft.ZwCAD.Windows;
#endif

namespace Positron.Plugin.Interface
{
    /// <summary>
    /// A **paleta de folhas** — o <c>_pspag</c> do reverso: um <c>PaletteSet</c> do CAD (não uma
    /// janela de sistema operacional), ancorável, hospedando o <see cref="FolhasControle"/>.
    ///
    /// O original usa dois Guids (PT/EN) e o título da mensagem; aqui o Guid é o do Positron e o
    /// título é fixo. Fica **uma** instância viva durante a sessão (cria na primeira abertura).
    /// </summary>
    internal static class PaletaDeFolhas
    {
        private static readonly Guid IdDaPaleta = new Guid("D17CCE76-F129-49A2-BFE6-6B9FCD7EC955");

        private static FolhasControle _controle;

#if !AUTOCAD
        private static PaletteSet _paleta;
#endif

        /// <summary>Abre (criando na primeira vez) a paleta e devolve quantas páginas mostrou.</summary>
        internal static int Mostrar()
        {
#if AUTOCAD
            _controle = _controle ?? new FolhasControle();
            return _controle.Carregar();
#else
            if (_paleta == null)
            {
                _controle = new FolhasControle();
                // Os mesmos valores do reverso (`DockEnabled = (DockSides)20480`,
                // `Dock = (DockSides)4096`): a paleta pode ancorar e nasce à direita.
                // O título é o do original: `mMensagem[1, 8]` = "Páginas".
                _paleta = new PaletteSet(Positron.Data.Interface.MensagensDoReverso.Paginas, "", IdDaPaleta);
                _paleta.DockEnabled = (DockSides)20480;
                _paleta.Dock = (DockSides)4096;
                _paleta.MinimumSize = new System.Drawing.Size(240, 320);
                _paleta.Add("folhas", _controle);
            }

            int paginas = _controle.Carregar();
            _paleta.Visible = true;
            _paleta.KeepFocus = true;
            return paginas;
#endif
        }
    }
}

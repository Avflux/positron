using System;
#if AUTOCAD
using Autodesk.AutoCAD.Windows;
#else
using ZwSoft.ZwCAD.Windows;
#endif

namespace Positron.Plugin.Interface.Folhas
{
    /// <summary>
    /// O <c>PaletteSet</c> de verdade — a paleta ancorável do CAD (o <c>_pspag</c> do reverso),
    /// com o <see cref="FolhasControle"/> dentro.
    ///
    /// **Um tipo só para isso, de propósito** (rodada 138): ele é o único lugar do build AutoCAD que
    /// menciona <c>Autodesk.AutoCAD.Windows.PaletteSet</c>, e só é tocado quando há janela (ver
    /// <see cref="PaletaDeFolhas"/>). No <c>accoreconsole</c> a referência era fatal — o processo
    /// morria no JIT do método, sem exceção e sem log.
    ///
    /// O <c>Autodesk.AutoCAD.Windows.PaletteSet</c> (que o build AutoCAD já tinha via
    /// <c>acmgd.dll</c>) e o <c>ZwSoft.ZwCAD.Windows.PaletteSet</c> do ZWCAD são a mesma API: só o
    /// <c>using</c> muda. Os valores são os do reverso (<c>DockEnabled = (DockSides)20480</c>,
    /// <c>Dock = (DockSides)4096</c>) e o título é a <c>mMensagem[1, 8]</c> = "Páginas".
    /// </summary>
    internal static class PaletaAncoravel
    {
        private static readonly Guid IdDaPaleta = new Guid("D17CCE76-F129-49A2-BFE6-6B9FCD7EC955");

        private static PaletteSet _paleta;

        /// <summary>Abre (criando na primeira vez) a paleta ancorada e devolve a conta de páginas.</summary>
        internal static int Mostrar(FolhasControle controle)
        {
            if (_paleta == null)
            {
                _paleta = new PaletteSet(Positron.Data.Interface.MensagensDoReverso.Paginas, "", IdDaPaleta);
                _paleta.DockEnabled = (DockSides)20480;
                _paleta.Dock = (DockSides)4096;
                _paleta.MinimumSize = new System.Drawing.Size(240, 320);
                _paleta.Add("folhas", controle);
            }

            int paginas = controle.Carregar();
            _paleta.Visible = true;
            _paleta.KeepFocus = true;
            return paginas;
        }
    }
}

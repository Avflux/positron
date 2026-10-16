using System;
using System.Runtime.InteropServices;
using Positron.Data.Interface;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.EditorInput;
#endif

namespace Positron.Plugin.Interface.Folhas
{
    /// <summary>uscPaginas.bt6p1Bww9xD/T5Qp1VoBCME: pergunta no CAD, não em um form.</summary>
    internal static class PerguntaDeCampoDaPagina
    {
        [DllImport("user32.dll", EntryPoint = "SetFocus")]
        private static extern IntPtr SetFocus(IntPtr janela);

        internal static bool Perguntar(bool alternativo, string padrao, out string escolhido)
        {
            string rotulo = alternativo ? MensagensDoReverso.Alternativo : MensagensDoReverso.Unidade;
            if (RespostaDoHarness.Campo(rotulo, out escolhido)) return true;
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null) return false;
            SetFocus(documento.Window.Handle);
            PromptStringOptions opcoes = new PromptStringOptions("\n" + (alternativo
                ? MensagensDoReverso.InformeNovoAlternativo : MensagensDoReverso.InformeNovaUnidade) + " ")
            {
                AllowSpaces = true,
                DefaultValue = padrao ?? string.Empty,
                UseDefaultValue = true,
            };
            PromptResult resposta = documento.Editor.GetString(opcoes);
            if (resposta.Status != PromptStatus.OK) return false;
            escolhido = resposta.StringResult;
            return true;
        }
    }
}

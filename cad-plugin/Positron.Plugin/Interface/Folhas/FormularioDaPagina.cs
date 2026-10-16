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

    /// <summary>
    /// uscPaginas.C8Op1CM1YgS: o prompt "Mover para página?" (mMensagem 24) do item
    /// **Renumerar Páginas** — `AllowSpaces = false`, sem valor padrão, e o foco vai para a janela
    /// do documento antes de perguntar (o `lwF3Qy6iqF`), como na pergunta dos campos.
    ///
    /// É a única pergunta da paleta que o original **repete**: a resposta recusada volta ao prompt,
    /// por isso o harness entrega uma fila (`POSITRON_MOVER_PARA`, separada por `;`).
    /// </summary>
    internal static class PerguntaDeRenumeracao
    {
        [DllImport("user32.dll", EntryPoint = "SetFocus")]
        private static extern IntPtr SetFocus(IntPtr janela);

        internal static bool Perguntar(out string escolhido)
        {
            escolhido = null;
            if (RespostaDoHarness.Movimentacao(out escolhido)) return true;
            // Fila esgotada no harness: cancela em vez de abrir o prompt (o laço não pode girar).
            if (RespostaDoHarness.MovimentacaoAtiva) return false;
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null) return false;
            SetFocus(documento.Window.Handle);
            PromptStringOptions opcoes = new PromptStringOptions("\n" + MensagensDoReverso.MoverParaPagina + " ")
            {
                AllowSpaces = false,
            };
            PromptResult resposta = documento.Editor.GetString(opcoes);
            if (resposta.Status != PromptStatus.OK) return false;
            escolhido = resposta.StringResult;
            return true;
        }
    }
}

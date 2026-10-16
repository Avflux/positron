using System;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.EditorInput;
#endif

namespace Positron.Plugin.Interface
{
    /// <summary>
    /// A **confirmação na linha de comando** — o <c>Editor.GetKeywords</c> que o original usa nas
    /// rotinas destrutivas (o `cPup1SWxSYc` do apagar das folhas é o caso desta rodada,
    /// `uscPaginas.cs:2162-2174`: a mensagem 23 e as palavras 19/20).
    ///
    /// **Uma** diferença do original, deliberada e só nossa: com <c>POSITRON_CONFIRMA</c> definida a
    /// resposta vem do ambiente e o prompt não abre — um script não tem quem o responda (a mesma
    /// receita dos outros ganchos do harness). Sem a variável, é o prompt do CAD, com as palavras do
    /// original e o padrão do original (a primeira palavra, o "Sim", sai com Enter).
    /// </summary>
    internal static class ConfirmacaoDoUsuario
    {
        /// <summary>A variável do harness que responde pelo usuário.</summary>
        internal const string VariavelConfirma = "POSITRON_CONFIRMA";

        internal static bool Perguntar(string pergunta, string sim, string nao)
        {
            string doAmbiente = Environment.GetEnvironmentVariable(VariavelConfirma);
            if (!string.IsNullOrEmpty(doAmbiente))
            {
                return string.Equals(doAmbiente.Trim(), sim, StringComparison.OrdinalIgnoreCase);
            }

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return false;
            }

            PromptKeywordOptions opcoes = new PromptKeywordOptions("\n" + pergunta + " ");
            opcoes.Keywords.Add(sim);
            opcoes.Keywords.Add(nao);
            opcoes.Keywords.Default = sim;
            opcoes.AllowNone = true;
            opcoes.AppendKeywordsToMessage = true;

            PromptResult resultado = documento.Editor.GetKeywords(opcoes);
            if (resultado.Status != PromptStatus.OK)
            {
                return false;
            }

            return string.Equals(resultado.StringResult, sim, StringComparison.OrdinalIgnoreCase);
        }
    }
}

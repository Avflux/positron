using Positron.Data.Configuracao;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.EditorInput;
#endif

namespace Positron.Plugin.Paginas
{
    /// <summary>
    /// O <c>Pagina.redefinePasso</c> do original (<c>Pagina.cs:2657-2671</c>): pergunta o passo de
    /// criação de páginas (mMensagem 143, sem zero nem negativo, padrão = o passo atual) e grava no
    /// XData de configuração do desenho (o <c>GravarXDataConfiguracao</c>).
    /// </summary>
    internal static class PassoDoCaderno
    {
        internal static string Redefinir()
        {
            Document documento = Application.DocumentManager.MdiActiveDocument;
            ConfiguracaoDoCaderno caderno = Configuracao.ConfiguracaoDoDesenho.LerOuPadrao();
            if (documento == null || caderno == null)
            {
                return "PASSO: sem desenho ativo.";
            }

            PromptIntegerOptions opcoes = new PromptIntegerOptions("\r\nInforme o passo de criação de páginas: ");
            opcoes.AllowNegative = false;
            opcoes.AllowZero = false;
            opcoes.DefaultValue = caderno.PassoPagina;
            opcoes.UseDefaultValue = true;
            PromptIntegerResult resposta = documento.Editor.GetInteger(opcoes);
            if (resposta.Status != PromptStatus.OK)
            {
                return "PASSO: passo do caderno = " + caderno.PassoPagina + " (mantido).";
            }

            caderno.PassoPagina = resposta.Value;
            Configuracao.ConfiguracaoDoDesenho.GravarConfig(caderno);
            return "PASSO: passo do caderno = " + resposta.Value + " (gravado no desenho).";
        }
    }
}

using System;
using System.IO;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.EditorInput;
using ZwSoft.ZwCAD.Runtime;
#endif

namespace Positron.Plugin
{
    /// <summary>
    /// Ponto de entrada carregado pelo `NETLOAD` (ver docs/POSITRON.md, seção 4).
    ///
    /// O ZWCAD procura o tipo que implementa <see cref="IExtensionApplication"/> e
    /// chama <see cref="Initialize"/> ao carregar a DLL. É aqui que o plugin
    /// validaria o tipo do desenho (só atua no diagrama funcional, tipo "E") —
    /// isso entra junto com o fluxo de fiação (fase 5).
    /// </summary>
    public sealed class Plugin : IExtensionApplication
    {
        public void Initialize()
        {
            Escrever("Positron carregado. Digite ELET para começar.");
        }

        public void Terminate()
        {
            // Nada a liberar ainda: o plugin não abre recursos que sobrevivam ao
            // descarregamento (conexões são abertas e fechadas por consulta).
        }

        /// <summary>Escreve uma linha na linha de comando do ZWCAD.</summary>
        internal static void Escrever(string mensagem)
        {
            RegistrarEmArquivo(mensagem);

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                // Sem documento ativo não há editor; evita NullReferenceException.
                return;
            }

            Editor editor = documento.Editor;
            editor.WriteMessage("\n" + mensagem);
        }

        /// <summary>
        /// Anexa a mensagem em <c>POSITRON_LOG</c> quando a variável existe. A
        /// linha de comando do CAD não tem stdout: rodando por script
        /// (<c>ZWCAD.exe /b passo.scr</c>), este arquivo é a evidência de que o
        /// plugin carregou e o que cada comando gravou.
        /// </summary>
        private static void RegistrarEmArquivo(string mensagem)
        {
            string caminho = Environment.GetEnvironmentVariable("POSITRON_LOG");
            if (string.IsNullOrEmpty(caminho))
            {
                return;
            }

            try
            {
                File.AppendAllText(caminho, mensagem + Environment.NewLine);
            }
            catch (IOException)
            {
                // Log de execução não pode derrubar um comando do CAD.
            }
            catch (UnauthorizedAccessException)
            {
            }
        }
    }
}

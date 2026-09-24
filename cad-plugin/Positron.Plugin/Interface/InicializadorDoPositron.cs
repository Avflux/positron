#if AUTOCAD
using Autodesk.AutoCAD.Runtime;
#else
using ZwSoft.ZwCAD.Runtime;
#endif

namespace Positron.Plugin.Interface
{
    /// <summary>
    /// O **ponto de entrada** do plugin (a fatia 1 da frente 11, o shell): o <c>myEletron</c> do
    /// reverso, que implementa <c>IExtensionApplication</c> e chama o <c>Iniciar.IniciarApp()</c>
    /// (lá: o splash, os recursos e a barra de ferramentas).
    ///
    /// É o que faz o plugin **se apresentar sozinho quando a DLL é carregada**, sem depender de
    /// digitar um comando: o <c>ELET</c> do reverso é um comando **vazio** — o arranque de verdade
    /// é aqui.
    ///
    /// **Fatia atual:** apresenta-se e informa como abrir a janela de folhas. As próximas trazem a
    /// **barra de ferramentas** (o <c>Ribbon.CreateRibbon</c> do reverso, com o <c>ZdWindows</c>) e
    /// a **paleta** ancorável.
    /// </summary>
    public sealed class InicializadorDoPositron : IExtensionApplication
    {
        public void Initialize()
        {
            Plugin.Escrever("Positron carregado — ELET abre a janela de folhas (e FOLHAS a abre direto).");
        }

        public void Terminate()
        {
        }
    }
}

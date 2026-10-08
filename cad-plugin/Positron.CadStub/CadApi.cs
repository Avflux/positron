// ============================================================================
// STUB DE COMPILAÇÃO — NÃO É A API REAL DO CAD (ZWCAD / AUTOCAD).
// ============================================================================
//
// O CAD (ZWCAD ou AutoCAD) não está disponível em toda máquina de build. Sem
// ele, `Positron.Plugin` não compilaria e não haveria gate nenhum. Este assembly
// reproduz a fatia MÍNIMA da API gerenciada que o plugin usa.
//
// Limites que não podem ser esquecidos:
//   - o plugin compilado contra o stub referencia o assembly `Positron.CadStub`,
//     que NÃO existe dentro do CAD. Ele compila, mas NÃO carrega por NETLOAD.
//     É só um gate de compilação.
//   - a DLL de verdade sai quando se builda com `ZWCadDir` ou `AutoCadDir` apontando
//     para a instalação do CAD correspondente (ou NuGet no caso do AutoCAD).

using System;

#if AUTOCAD
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;

namespace Autodesk.AutoCAD.Runtime
#else
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.EditorInput;

namespace ZwSoft.ZwCAD.Runtime
#endif
{
    /// <summary>Implementada pelo plugin; o CAD a chama ao carregar a DLL.</summary>
    public interface IExtensionApplication
    {
        void Initialize();

        void Terminate();
    }

    /// <summary>Marca um método público como comando digitável na linha de comando.</summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class CommandMethodAttribute : Attribute
    {
        public CommandMethodAttribute(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; private set; }
    }
}

#if AUTOCAD
namespace Autodesk.AutoCAD.EditorInput
#else
namespace ZwSoft.ZwCAD.EditorInput
#endif
{
    public sealed class Editor
    {
        public void WriteMessage(string mensagem)
        {
            throw new NotSupportedException("stub de compilacao: nao existe dentro do CAD");
        }
    }
}

#if AUTOCAD
namespace Autodesk.AutoCAD.ApplicationServices
#else
namespace ZwSoft.ZwCAD.ApplicationServices
#endif
{
    public sealed class Document
    {
        public Editor Editor
        {
            get { throw new NotSupportedException("stub de compilacao: nao existe dentro do CAD"); }
        }

        public Database Database
        {
            get { throw new NotSupportedException("stub de compilacao: nao existe dentro do CAD"); }
        }
    }

    public sealed class DocumentCollection
    {
        public Document MdiActiveDocument
        {
            get { return null; }
        }
    }

    public static class Application
    {
        public static DocumentCollection DocumentManager
        {
            get { return new DocumentCollection(); }
        }
    }
}

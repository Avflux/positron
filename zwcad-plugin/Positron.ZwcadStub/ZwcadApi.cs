// ============================================================================
// STUB DE COMPILAÇÃO — NÃO É A API DO ZWCAD.
// ============================================================================
//
// O ZWCAD não está disponível em toda máquina de build (e não está nesta). Sem
// ele, `Positron.Plugin` não compilaria e não haveria gate nenhum. Este assembly
// reproduz a fatia MÍNIMA da API gerenciada que o plugin usa — nomes de
// namespace e assinaturas copiados dos `using` do código reverso
// (Eletron4_ZWCAD/decompiled-cleaned), onde a API é `ZwSoft.ZwCAD.*`.
//
// Limites que não podem ser esquecidos:
//   - o plugin compilado contra o stub referencia o assembly `Positron.ZwcadStub`,
//     que NÃO existe dentro do ZWCAD. Ele compila, mas NÃO carrega por NETLOAD.
//     É só um gate de compilação.
//   - a DLL de verdade sai quando se builda com `ZWCadDir` apontando para a
//     instalação do ZWCAD (ver zwcad-plugin/README.md), aí a referência é a
//     `ZwManaged.dll` real e o resultado é o mesmo código, ligado ao alvo certo.
//
// Ou seja: este arquivo nunca vai para o ZWCAD. Se as assinaturas divergirem do
// real, o build com `ZWCadDir` é quem acusa.

using System;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.EditorInput;

namespace ZwSoft.ZwCAD.Runtime
{
    /// <summary>Implementada pelo plugin; o ZWCAD a chama ao carregar a DLL.</summary>
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

namespace ZwSoft.ZwCAD.EditorInput
{
    public sealed class Editor
    {
        public void WriteMessage(string mensagem)
        {
            throw new NotSupportedException("stub de compilacao: nao existe dentro do ZWCAD");
        }
    }
}

namespace ZwSoft.ZwCAD.ApplicationServices
{
    public sealed class Document
    {
        public Editor Editor
        {
            get { throw new NotSupportedException("stub de compilacao: nao existe dentro do ZWCAD"); }
        }

        public Database Database
        {
            get { throw new NotSupportedException("stub de compilacao: nao existe dentro do ZWCAD"); }
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

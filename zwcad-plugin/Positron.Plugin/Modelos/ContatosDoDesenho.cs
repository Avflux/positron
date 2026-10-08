using System.Collections.Generic;
using Positron.Data.Modelos;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;

namespace Positron.Plugin.Modelos
{
    /// <summary>
    /// Lê do desenho os modelos de contato e seus contatos auxiliares — o
    /// dicionário <c>CONTATOS</c> (<c>DicionarioContatos</c> no original):
    /// <c>CONTATOS → "MODELOS2"</c> (lista) e <c>CONTATOS → "&lt;indice&gt;"</c>
    /// (auxiliares do modelo).
    /// </summary>
    public static class ContatosDoDesenho
    {
        public static List<ModeloContato> LerModelos()
        {
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return new List<ModeloContato>();
            }

            Database banco = documento.Database;
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                DBDictionary contatos = AbrirContatos(transacao, banco);
                if (contatos == null || !contatos.Contains("MODELOS2"))
                {
                    transacao.Commit();
                    return new List<ModeloContato>();
                }

                Xrecord registro = transacao.GetObject(contatos.GetAt("MODELOS2"), OpenMode.ForRead) as Xrecord;
                List<ModeloContato> modelos = registro == null || registro.Data == null
                    ? new List<ModeloContato>()
                    : ModelosContato.LerModelos(XDataNeutro.Para(registro.Data));
                transacao.Commit();
                return modelos;
            }
        }

        public static List<ContatoAuxiliar> LerAuxiliares(int indiceModelo)
        {
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return new List<ContatoAuxiliar>();
            }

            Database banco = documento.Database;
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                DBDictionary contatos = AbrirContatos(transacao, banco);
                string chave = indiceModelo.ToString();
                if (contatos == null || !contatos.Contains(chave))
                {
                    transacao.Commit();
                    return new List<ContatoAuxiliar>();
                }

                Xrecord registro = transacao.GetObject(contatos.GetAt(chave), OpenMode.ForRead) as Xrecord;
                List<ContatoAuxiliar> auxiliares = registro == null || registro.Data == null
                    ? new List<ContatoAuxiliar>()
                    : ModelosContato.LerAuxiliares(XDataNeutro.Para(registro.Data));
                transacao.Commit();
                return auxiliares;
            }
        }

        private static DBDictionary AbrirContatos(Transaction transacao, Database banco)
        {
            DBDictionary raiz = transacao.GetObject(banco.NamedObjectsDictionaryId, OpenMode.ForRead) as DBDictionary;
            if (raiz == null || !raiz.Contains("CONTATOS"))
            {
                return null;
            }

            return transacao.GetObject(raiz.GetAt("CONTATOS"), OpenMode.ForRead) as DBDictionary;
        }
    }
}

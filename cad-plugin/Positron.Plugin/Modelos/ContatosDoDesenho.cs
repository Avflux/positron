using System.Collections.Generic;
using Positron.Data.Fiacao;
using Positron.Data.Modelos;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
#endif

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
                List<ModeloContato> modelos = registro == null
                    ? new List<ModeloContato>()
                    : ModelosContato.LerModelos(XDataNeutro.Para(registro));
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
                List<ContatoAuxiliar> auxiliares = registro == null
                    ? new List<ContatoAuxiliar>()
                    : ModelosContato.LerAuxiliares(XDataNeutro.Para(registro));
                transacao.Commit();
                return auxiliares;
            }
        }

        /// <summary>Os contatos auxiliares **crus** de um modelo (para o caminho de escrita).</summary>
        public static List<ModelosContato.ContatoBruto> LerAuxiliaresBrutos(int indiceModelo)
        {
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return new List<ModelosContato.ContatoBruto>();
            }

            Database banco = documento.Database;
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                DBDictionary contatos = AbrirContatos(transacao, banco);
                string chave = indiceModelo.ToString();
                if (contatos == null || !contatos.Contains(chave))
                {
                    transacao.Commit();
                    return new List<ModelosContato.ContatoBruto>();
                }

                Xrecord registro = transacao.GetObject(contatos.GetAt(chave), OpenMode.ForRead) as Xrecord;
                List<ModelosContato.ContatoBruto> brutos = registro == null
                    ? new List<ModelosContato.ContatoBruto>()
                    : ModelosContato.LerAuxiliaresBrutos(XDataNeutro.Para(registro));
                transacao.Commit();
                return brutos;
            }
        }

        /// <summary>
        /// Regrava os contatos auxiliares de um modelo (o
        /// <c>GravaOsContatosAuxiliarDoModeloDoDicionario</c>): o XRecord da chave do modelo
        /// recebe o cabeçalho e os registros crus. Devolve <c>false</c> quando a chave ou o
        /// dicionário não existem.
        /// </summary>
        public static bool GravarAuxiliares(int indiceModelo, int maxIndice, IReadOnlyList<ModelosContato.ContatoBruto> contatos)
        {
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return false;
            }

            Database banco = documento.Database;
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                DBDictionary contatosDoDesenho = AbrirContatos(transacao, banco);
                string chave = indiceModelo.ToString();
                if (contatosDoDesenho == null || !contatosDoDesenho.Contains(chave))
                {
                    transacao.Commit();
                    return false;
                }

                Xrecord registro = transacao.GetObject(contatosDoDesenho.GetAt(chave), OpenMode.ForRead) as Xrecord;
                if (registro == null)
                {
                    transacao.Commit();
                    return false;
                }

                IReadOnlyList<TypedXData> valores = ModelosContato.ParaValoresBrutos(maxIndice, contatos);
                TypedValue[] array = new TypedValue[valores.Count];
                for (int i = 0; i < valores.Count; i++)
                {
                    array[i] = new TypedValue(valores[i].Codigo, valores[i].Valor);
                }

                registro.UpgradeOpen();
                registro.Data = new ResultBuffer(array);
                transacao.Commit();
                return true;
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

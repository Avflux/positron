using System.Collections.Generic;
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
    /// Lê do desenho os modelos de máscara e suas portas — o dicionário
    /// <c>MASCARAS</c> (<c>DicionarioMascaras</c> no original):
    /// <c>MASCARAS → "MODELOS2"</c> (lista) e <c>MASCARAS → "&lt;indice&gt;"</c>
    /// (portas do modelo).
    /// </summary>
    public static class ModelosMascaraDoDesenho
    {
        public static List<ModeloMascara> LerModelos()
        {
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return new List<ModeloMascara>();
            }

            Database banco = documento.Database;
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                DBDictionary mascaras = AbrirMascaras(transacao, banco);
                if (mascaras == null || !mascaras.Contains("MODELOS2"))
                {
                    transacao.Commit();
                    return new List<ModeloMascara>();
                }

                Xrecord registro = transacao.GetObject(mascaras.GetAt("MODELOS2"), OpenMode.ForRead) as Xrecord;
                List<ModeloMascara> modelos = registro == null
                    ? new List<ModeloMascara>()
                    : ModelosMascara.LerModelos(XDataNeutro.Para(registro));
                transacao.Commit();
                return modelos;
            }
        }

        /// <summary>Lê as portas de um modelo (<c>MASCARAS → "&lt;indice&gt;"</c>).</summary>
        public static List<ModeloPorta> LerPortas(int indiceModelo, string nomeModelo)
        {
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return new List<ModeloPorta>();
            }

            Database banco = documento.Database;
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                DBDictionary mascaras = AbrirMascaras(transacao, banco);
                string chave = indiceModelo.ToString();
                if (mascaras == null || !mascaras.Contains(chave))
                {
                    transacao.Commit();
                    return new List<ModeloPorta>();
                }

                Xrecord registro = transacao.GetObject(mascaras.GetAt(chave), OpenMode.ForRead) as Xrecord;
                List<ModeloPorta> portas = registro == null
                    ? new List<ModeloPorta>()
                    : ModelosMascara.LerPortas(XDataNeutro.Para(registro), indiceModelo, nomeModelo);
                transacao.Commit();
                return portas;
            }
        }

        private static DBDictionary AbrirMascaras(Transaction transacao, Database banco)
        {
            DBDictionary raiz = transacao.GetObject(banco.NamedObjectsDictionaryId, OpenMode.ForRead) as DBDictionary;
            if (raiz == null || !raiz.Contains("MASCARAS"))
            {
                return null;
            }

            return transacao.GetObject(raiz.GetAt("MASCARAS"), OpenMode.ForRead) as DBDictionary;
        }
    }
}

#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
#endif

namespace Positron.Plugin.Paginas
{
    /// <summary>Dicionario.gravaAtalhos/LeAtalhos: CENG_ELET/Atalhos, seis strings DXF 1.</summary>
    internal static class AtalhosDePaginasDoDesenho
    {
        internal static string[] Ler()
        {
            string[] atalhos = { "", "", "", "", "", "" };
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null) return atalhos;
            using (Transaction transacao = documento.Database.TransactionManager.StartTransaction())
            {
                DBDictionary raiz = (DBDictionary)transacao.GetObject(documento.Database.NamedObjectsDictionaryId, OpenMode.ForRead);
                if (raiz.Contains("CENG_ELET"))
                {
                    DBDictionary pasta = (DBDictionary)transacao.GetObject(raiz.GetAt("CENG_ELET"), OpenMode.ForRead);
                    if (pasta.Contains("Atalhos"))
                    {
                        Xrecord registro = (Xrecord)transacao.GetObject(pasta.GetAt("Atalhos"), OpenMode.ForRead);
                        using (ResultBuffer dados = registro.Data)
                        {
                            TypedValue[] valores = dados == null ? new TypedValue[0] : dados.AsArray();
                            for (int i = 0; i < atalhos.Length && i < valores.Length; i++)
                                atalhos[i] = System.Convert.ToString(valores[i].Value);
                        }
                    }
                }
                transacao.Commit();
            }
            return atalhos;
        }

        internal static void Gravar(int indice, string pagina)
        {
            string[] atalhos = Ler();
            atalhos[indice] = pagina ?? "";
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null) return;
            using (documento.LockDocument())
            using (Transaction transacao = documento.Database.TransactionManager.StartTransaction())
            {
                DBDictionary raiz = (DBDictionary)transacao.GetObject(documento.Database.NamedObjectsDictionaryId, OpenMode.ForRead);
                DBDictionary pasta;
                if (raiz.Contains("CENG_ELET"))
                    pasta = (DBDictionary)transacao.GetObject(raiz.GetAt("CENG_ELET"), OpenMode.ForRead);
                else
                {
                    raiz.UpgradeOpen();
                    pasta = new DBDictionary();
                    raiz.SetAt("CENG_ELET", pasta);
                    transacao.AddNewlyCreatedDBObject(pasta, true);
                }
                Xrecord registro;
                if (pasta.Contains("Atalhos"))
                    registro = (Xrecord)transacao.GetObject(pasta.GetAt("Atalhos"), OpenMode.ForWrite);
                else
                {
                    pasta.UpgradeOpen();
                    registro = new Xrecord();
                    pasta.SetAt("Atalhos", registro);
                    transacao.AddNewlyCreatedDBObject(registro, true);
                }
                TypedValue[] valores = new TypedValue[6];
                for (int i = 0; i < valores.Length; i++) valores[i] = new TypedValue(1, atalhos[i]);
                using (ResultBuffer dados = new ResultBuffer(valores)) registro.Data = dados;
                transacao.Commit();
            }
        }
    }
}

using Positron.Data.Bornes;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;

namespace Positron.Plugin.Bornes
{
    /// <summary>
    /// Lê as réguas do desenho do dicionário de objetos nomeados:
    /// <c>NamedObjectsDictionary → "REGUAS" → "MODELOS2"</c>, um <c>Xrecord</c>
    /// com o layout que <see cref="ReguasModelo"/> interpreta (o mesmo caminho de
    /// <c>DicionarioReguas.LeOsModelosDeRegua</c> no original).
    /// </summary>
    public static class ReguasDoDesenho
    {
        public static ReguasModelo Ler()
        {
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return new ReguasModelo();
            }

            Database banco = documento.Database;

            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                DBDictionary raiz = transacao.GetObject(banco.NamedObjectsDictionaryId, OpenMode.ForRead) as DBDictionary;
                if (raiz == null || !raiz.Contains("REGUAS"))
                {
                    transacao.Commit();
                    return new ReguasModelo();
                }

                DBDictionary reguas = transacao.GetObject(raiz.GetAt("REGUAS"), OpenMode.ForRead) as DBDictionary;
                if (reguas == null || !reguas.Contains("MODELOS2"))
                {
                    transacao.Commit();
                    return new ReguasModelo();
                }

                Xrecord registro = transacao.GetObject(reguas.GetAt("MODELOS2"), OpenMode.ForRead) as Xrecord;
                if (registro == null || registro.Data == null)
                {
                    transacao.Commit();
                    return new ReguasModelo();
                }

                ReguasModelo modelo = ReguasModelo.Ler(XDataNeutro.Para(registro.Data));
                transacao.Commit();
                return modelo;
            }
        }
    }
}

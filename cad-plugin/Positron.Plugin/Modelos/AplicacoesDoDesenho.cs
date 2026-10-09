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
    /// Lê os tipos de aplicação do desenho: <c>NamedObjectsDictionary →
    /// "APLICACAO" → "TIPOS"</c>, um <c>Xrecord</c> com o layout que
    /// <see cref="Aplicacao4FGerador.LerTipos"/> interpreta (o mesmo caminho de
    /// <c>DicionarioAplicacao.LeOsTiposDeAplicacoes</c> no original).
    /// </summary>
    public static class AplicacoesDoDesenho
    {
        public static IReadOnlyList<AplicacaoDefinicao> Ler()
        {
            List<AplicacaoDefinicao> vazio = new List<AplicacaoDefinicao>();

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return vazio;
            }

            Database banco = documento.Database;

            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                DBDictionary raiz = transacao.GetObject(banco.NamedObjectsDictionaryId, OpenMode.ForRead) as DBDictionary;
                if (raiz == null || !raiz.Contains("APLICACAO"))
                {
                    transacao.Commit();
                    return vazio;
                }

                DBDictionary aplicacao = transacao.GetObject(raiz.GetAt("APLICACAO"), OpenMode.ForRead) as DBDictionary;
                if (aplicacao == null || !aplicacao.Contains("TIPOS"))
                {
                    transacao.Commit();
                    return vazio;
                }

                Xrecord registro = transacao.GetObject(aplicacao.GetAt("TIPOS"), OpenMode.ForRead) as Xrecord;
                if (registro == null || registro.Data == null)
                {
                    transacao.Commit();
                    return vazio;
                }

                List<AplicacaoDefinicao> tipos = Aplicacao4FGerador.LerTipos(XDataNeutro.Para(registro.Data));
                transacao.Commit();
                return tipos;
            }
        }
    }
}

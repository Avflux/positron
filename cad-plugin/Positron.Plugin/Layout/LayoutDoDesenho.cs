using System.Collections.Generic;
using Positron.Data.Layout;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
#endif

namespace Positron.Plugin.Layout
{
    /// <summary>
    /// Lê as **posições de dispositivo** do dicionário de objetos nomeados:
    /// <c>NamedObjectsDictionary → "CENG_LAYOUT" → {"P"&lt;painel&gt;, "C"&lt;painel&gt;}</c>,
    /// dois <c>Xrecord</c> por painel — o mesmo caminho de
    /// <c>DicionarioLayout.buscaDicLayoutPainel</c> no original.
    ///
    /// É o que dá ao ponto **não-borne** o <c>PosicaoNum</c> e a ordem na
    /// reordenação. O adapter do CAD só lê; a interpretação é pura
    /// (<see cref="LayoutPosicoes.Interpretar"/>).
    /// </summary>
    public static class LayoutDoDesenho
    {
        private const string DicionarioLayout = "CENG_LAYOUT";

        public static LayoutPosicoes Ler(IEnumerable<int> paineis)
        {
            List<PosicaoLayout> posicoes = new List<PosicaoLayout>();

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null || paineis == null)
            {
                return LayoutPosicoes.Vazia;
            }

            Database banco = documento.Database;

            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                DBDictionary raiz = transacao.GetObject(banco.NamedObjectsDictionaryId, OpenMode.ForRead) as DBDictionary;
                if (raiz == null || !raiz.Contains(DicionarioLayout))
                {
                    transacao.Commit();
                    return LayoutPosicoes.Vazia;
                }

                DBDictionary layout = transacao.GetObject(raiz.GetAt(DicionarioLayout), OpenMode.ForRead) as DBDictionary;
                if (layout == null)
                {
                    transacao.Commit();
                    return LayoutPosicoes.Vazia;
                }

                foreach (int painel in paineis)
                {
                    LerPainel(layout, transacao, "P", painel, posicoes);
                    LerPainel(layout, transacao, "C", painel, posicoes);
                }

                transacao.Commit();
            }

            return LayoutPosicoes.Ler(posicoes);
        }

        private static void LerPainel(
            DBDictionary layout,
            Transaction transacao,
            string pos,
            int painel,
            List<PosicaoLayout> destino)
        {
            string chave = pos + painel;
            if (!layout.Contains(chave))
            {
                return;
            }

            Xrecord registro = transacao.GetObject(layout.GetAt(chave), OpenMode.ForRead) as Xrecord;
            if (registro == null)
            {
                return;
            }

            destino.AddRange(LayoutPosicoes.Interpretar(XDataNeutro.Para(registro), painel, pos));
        }
    }
}

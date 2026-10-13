using Positron.Data.Paginas;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.EditorInput;
using ZwSoft.ZwCAD.Geometry;
#endif

namespace Positron.Plugin.Paginas
{
    /// <summary>
    /// O <c>EncontraHandle</c> no desenho: pede o handle (o <c>GetString</c> do original), acha a
    /// entidade (o <c>Geral.HandleToObject</c>) e dá zoom nela (o <c>Caderno.ZEntity</c>). A
    /// ativação da página fica com o <see cref="PaginaAtivaDoDesenho"/>; o que é puro, com o
    /// <see cref="LocalizacaoPorHandle"/>.
    /// </summary>
    internal static class LocalizacaoPorHandleDoDesenho
    {
        /// <summary>A entidade achada: o layer (a página a ativar) e a caixa (para o zoom).</summary>
        internal sealed class Entidade
        {
            internal string Tipo { get; set; }
            internal string Layer { get; set; }
            internal ObjectId Id { get; set; }
        }

        /// <summary>O prompt do original (<c>"Digite Um Handle"</c>, com espaços); vazio quando cancelado.</summary>
        internal static string PerguntarHandle()
        {
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return string.Empty;
            }

            PromptStringOptions opcoes = new PromptStringOptions("\nDigite Um Handle");
            opcoes.AllowSpaces = true;
            PromptResult resposta = documento.Editor.GetString(opcoes);
            return resposta.Status == PromptStatus.OK ? resposta.StringResult : string.Empty;
        }

        /// <summary>
        /// A entidade do handle, no desenho ativo; <c>null</c> quando o handle não existe, foi
        /// apagado ou não é uma entidade (o <c>HandleToObject</c> devolve <c>Nothing</c> e o
        /// original não faz nada).
        /// </summary>
        internal static Entidade Achar(long handle)
        {
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return null;
            }

            Database banco = documento.Database;
            ObjectId id;
            if (!banco.TryGetObjectId(new Handle(handle), out id) || !id.IsValid || id.IsErased)
            {
                return null;
            }

            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                Entity entidade = transacao.GetObject(id, OpenMode.ForRead) as Entity;
                transacao.Commit();
                if (entidade == null)
                {
                    return null;
                }

                return new Entidade { Tipo = entidade.GetType().Name, Layer = entidade.Layer, Id = id };
            }
        }

        /// <summary>
        /// O <c>ZEntity(id, 20)</c>: a vista passa a ser a caixa da entidade com a margem. Devolve a
        /// janela aplicada, ou <c>null</c> quando a entidade não tem caixa (o <c>Bounds</c> vazio,
        /// onde o original lança e engole).
        /// </summary>
        internal static JanelaDeZoom? DarZoom(ObjectId id)
        {
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return null;
            }

            JanelaDeZoom janela;
            using (Transaction transacao = documento.Database.TransactionManager.StartTransaction())
            {
                Entity entidade = transacao.GetObject(id, OpenMode.ForRead) as Entity;
                Extents3d? caixa = entidade == null ? null : entidade.Bounds;
                transacao.Commit();
                if (!caixa.HasValue)
                {
                    return null;
                }

                janela = LocalizacaoPorHandle.Janela(caixa.Value.MinPoint.X, caixa.Value.MinPoint.Y,
                    caixa.Value.MaxPoint.X, caixa.Value.MaxPoint.Y, LocalizacaoPorHandle.MargemDoZoom);
            }

            // Uma vista nova, como o `ZoomWin` do original (`new ViewTableRecord()`): só o centro, a
            // largura e a altura.
            using (ViewTableRecord vista = new ViewTableRecord())
            {
                vista.CenterPoint = new Point2d(janela.CentroX, janela.CentroY);
                vista.Width = janela.Largura;
                vista.Height = janela.Altura;
                documento.Editor.SetCurrentView(vista);
            }

            return janela;
        }
    }
}

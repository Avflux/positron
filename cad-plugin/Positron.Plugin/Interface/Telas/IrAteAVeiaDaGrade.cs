using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Positron.Data.Paginas;
using Positron.Plugin.Paginas;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Application = Autodesk.AutoCAD.ApplicationServices.Application;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
using Application = ZwSoft.ZwCAD.ApplicationServices.Application;
#endif

namespace Positron.Plugin.Interface.Telas
{
    /// <summary>
    /// O clique (ou tecla) numa grade de veias das telas de pesquisa — o <c>wkpp6H6CivH</c> do
    /// <c>frmPesquisaVeiasIndefinidas</c> e o <c>vp1pvC6nLi1</c> do <c>frmPesquisaCabos</c>, que são o
    /// mesmo código: tira o realce da página ativa (<c>clsBlocos.Unhighlight</c>), devolve o foco ao
    /// desenho e, para cada linha selecionada, o <c>clsInterligacao.AtivaUmaHighlightZoom</c> —
    /// ativa a página da entidade, dá zoom com margem 20 e a realça.
    /// </summary>
    internal static class IrAteAVeiaDaGrade
    {
        // O `hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF` do original: devolve o foco à janela do desenho.
        [DllImport("user32.dll", EntryPoint = "SetFocus")]
        private static extern IntPtr SetFocus(IntPtr janela);

        /// <summary>
        /// Vai até as linhas selecionadas. O handle está na coluna <paramref name="colunaDoHandle"/>;
        /// a linha sem handle é pulada e, com <paramref name="desmarcarSemHandle"/>, perde a seleção
        /// (o <c>frmPesquisaCabos</c> faz isso com as veias de outros cadernos). Nunca lança.
        /// </summary>
        internal static void Selecionadas(DataGridView grade, int colunaDoHandle, string rotulo, bool desmarcarSemHandle)
        {
            try
            {
                Document documento = Application.DocumentManager.MdiActiveDocument;
                if (documento == null)
                {
                    return;
                }

                SetFocus(documento.Window.Handle);
                using (documento.LockDocument())
                {
                    TirarRealceDaPaginaAtiva(documento);
                    foreach (DataGridViewRow linha in grade.Rows)
                    {
                        if (!linha.Selected)
                        {
                            continue;
                        }

                        string handle = Convert.ToString(linha.Cells[colunaDoHandle].Value);
                        if (string.IsNullOrEmpty(handle))
                        {
                            if (desmarcarSemHandle)
                            {
                                linha.Selected = false;
                            }

                            continue;
                        }

                        Plugin.Escrever(rotulo + ": " + IrAte(documento, handle));
                        SetFocus(documento.Window.Handle);
                    }
                }
            }
            catch (Exception erro)
            {
                Plugin.Escrever(rotulo + ": falhou — " + erro.Message + ".");
            }
        }

        /// <summary>O <c>AtivaUmaHighlightZoom</c>: ativa a página da entidade, dá zoom e a realça.</summary>
        private static string IrAte(Document documento, string texto)
        {
            long? handle = LocalizacaoPorHandle.LerHandle(texto);
            LocalizacaoPorHandleDoDesenho.Entidade entidade = handle.HasValue ? LocalizacaoPorHandleDoDesenho.Achar(handle.Value) : null;
            if (entidade == null)
            {
                return "handle \"" + texto + "\" não achado no desenho.";
            }

            PaginaAtivaDoDesenho.Ativar(entidade.Layer);
            Folhas.PaletaDeFolhas.Recarregar();
            LocalizacaoPorHandleDoDesenho.DarZoom(entidade.Id);

            using (Transaction transacao = documento.Database.TransactionManager.StartTransaction())
            {
                Entity alvo = transacao.GetObject(entidade.Id, OpenMode.ForRead) as Entity;
                if (alvo != null)
                {
                    alvo.Highlight();
                }

                transacao.Commit();
            }

            return "veia " + texto + " na página \"" + entidade.Layer + "\" (zoom e realce).";
        }

        /// <summary>O <c>clsBlocos.Unhighlight</c>: tira o realce de toda entidade do layer da página ativa.</summary>
        private static void TirarRealceDaPaginaAtiva(Document documento)
        {
            string pagina = PaginaAtivaDoDesenho.Ler();
            Database banco = documento.Database;
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTable tabela = (BlockTable)transacao.GetObject(banco.BlockTableId, OpenMode.ForRead);
                BlockTableRecord espaco = (BlockTableRecord)transacao.GetObject(tabela[BlockTableRecord.ModelSpace], OpenMode.ForRead);
                foreach (ObjectId id in espaco)
                {
                    Entity entidade = transacao.GetObject(id, OpenMode.ForRead) as Entity;
                    if (entidade != null && string.Equals(entidade.Layer, pagina, StringComparison.OrdinalIgnoreCase))
                    {
                        entidade.Unhighlight();
                    }
                }

                transacao.Commit();
            }
        }
    }
}

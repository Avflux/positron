using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Positron.Data;
using Positron.Data.Configuracao;
using Positron.Data.Interligacao;
using Positron.Plugin.Interligacao;
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
    /// A ligação do <c>frmPesquisaVeiasIndefinidas</c> (o comando <c>PESQC</c>): a grade
    /// <c>dgVeiasDWG</c> com as <see cref="VeiasIndefinidasDoCaderno"/> do desenho ativo (colunas
    /// do <c>formataDGVeiasDWG</c>: <c>#</c>, mMensagem 9/429/432 e o handle oculto) e, a cada
    /// clique ou tecla na grade, o <c>wkpp6H6CivH</c> do original: tira o realce da página ativa
    /// (<c>clsBlocos.Unhighlight</c>) e vai até a veia selecionada — ativa a página dela, dá zoom
    /// com margem 20 e a realça (<c>clsInterligacao.AtivaUmaHighlightZoom</c>).
    /// </summary>
    internal sealed class LigacaoDoFrmPesquisaVeiasIndefinidas : ILigacaoDeTela
    {
        // O `hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF` do original: devolve o foco à janela do desenho.
        [DllImport("user32.dll", EntryPoint = "SetFocus")]
        private static extern IntPtr SetFocus(IntPtr janela);

        public string NomeDaTela
        {
            get { return "frmPesquisaVeiasIndefinidas"; }
        }

        public void Preencher(Form janela)
        {
            DataGridView grade = ControlesDaTela.Achar<DataGridView>(janela, "dgVeiasDWG");
            if (grade == null)
            {
                return;
            }

            grade.Rows.Clear();
            grade.Columns.Clear();
            grade.Columns.Add("Indice", "#");
            grade.Columns.Add("pAGINA", "Página");
            grade.Columns.Add("PN1", "Origem");
            grade.Columns.Add("PN2", "Destino");
            grade.Columns.Add("Handle", "Handle");

            IReadOnlyList<VeiaIndefinida> veias = VeiasIndefinidasDoCaderno.Carregar(InterligacaoDoDesenho.LerComPosicao());
            IReadOnlyList<LinhaDeVeiaIndefinida> linhas = VeiasIndefinidasDoCaderno.LinhasDaGrade(veias, LerNomesDePaineis());
            foreach (LinhaDeVeiaIndefinida linha in linhas)
            {
                grade.Rows.Add(linha.Indice, linha.Pagina, linha.Origem, linha.Destino, linha.Handle);
            }

            AjustarColunas(grade);
            if (grade.Rows.Count > 0)
            {
                grade.Rows[0].Selected = false;
            }

            janela.Resize += (origem, evento) => AjustarColunas(grade);
            grade.KeyUp += (origem, evento) => IrAteASelecionada(grade);
            grade.MouseUp += (origem, evento) => IrAteASelecionada(grade);

            List<string> amostra = new List<string>();
            foreach (LinhaDeVeiaIndefinida linha in linhas)
            {
                if (amostra.Count == 5)
                {
                    amostra.Add("...");
                    break;
                }

                amostra.Add(linha.Pagina + " " + linha.Origem.Trim() + "->" + linha.Destino.Trim() + " [" + linha.Handle + "]");
            }

            Plugin.Escrever("PESQC: " + linhas.Count + " veia(s) indefinida(s) na grade"
                + (amostra.Count > 0 ? ": " + string.Join("; ", amostra.ToArray()) : string.Empty) + ".");
        }

        /// <summary>O <c>AtualizaDGVeiasDWG</c>: 10/30/30/30% da largura útil e o handle oculto.</summary>
        private static void AjustarColunas(DataGridView grade)
        {
            if (grade.Columns.Count < 5)
            {
                return;
            }

            bool barra = HaBarraVertical(grade);
            double largura = barra ? grade.Width - 21 : grade.Width - 4;
            grade.Columns[0].Width = (int)Math.Round(largura * 0.1);
            grade.Columns[1].Width = (int)Math.Round(largura * 0.3);
            grade.Columns[2].Width = (int)Math.Round(largura * 0.3);
            grade.Columns[3].Width = (int)Math.Round(largura * 0.3);
            grade.Columns[4].Visible = false;
        }

        private static bool HaBarraVertical(DataGridView grade)
        {
            foreach (Control controle in grade.Controls)
            {
                if (controle is VScrollBar && controle.Visible)
                {
                    return true;
                }
            }

            return false;
        }

        private static void IrAteASelecionada(DataGridView grade)
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

                        string handle = Convert.ToString(linha.Cells[4].Value);
                        Plugin.Escrever("PESQC: " + IrAte(handle));
                        SetFocus(documento.Window.Handle);
                    }
                }
            }
            catch (Exception erro)
            {
                Plugin.Escrever("PESQC: falhou — " + erro.Message + ".");
            }
        }

        /// <summary>O <c>AtivaUmaHighlightZoom</c>: ativa a página da entidade, dá zoom e a realça.</summary>
        private static string IrAte(string texto)
        {
            long? handle = Positron.Data.Paginas.LocalizacaoPorHandle.LerHandle(texto);
            LocalizacaoPorHandleDoDesenho.Entidade entidade = handle.HasValue ? LocalizacaoPorHandleDoDesenho.Achar(handle.Value) : null;
            if (entidade == null)
            {
                return "handle \"" + texto + "\" não achado no desenho.";
            }

            PaginaAtivaDoDesenho.Ativar(entidade.Layer);
            Interface.Folhas.PaletaDeFolhas.Recarregar();
            LocalizacaoPorHandleDoDesenho.DarZoom(entidade.Id);

            Database banco = Application.DocumentManager.MdiActiveDocument.Database;
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
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

        private static IReadOnlyDictionary<int, string> LerNomesDePaineis()
        {
            ConfiguracaoPositron config = ConfiguracaoPositron.Carregar();
            if (config == null || string.IsNullOrEmpty(config.Banco))
            {
                return new Dictionary<int, string>();
            }

            try
            {
                return new ProjectStore(config.Banco).LerNomesDePaineis();
            }
            catch (Exception erro)
            {
                Plugin.Escrever("PESQC: o cadastro de painéis não veio do banco — " + erro.Message);
                return new Dictionary<int, string>();
            }
        }
    }
}

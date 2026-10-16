using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Positron.Data.Configuracao;
using Positron.Data.Paginas;
using Positron.Plugin.Configuracao;
using Positron.Plugin.Paginas;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Application = Autodesk.AutoCAD.ApplicationServices.Application;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using Application = ZwSoft.ZwCAD.ApplicationServices.Application;
#endif

namespace Positron.Plugin.Interface.Telas
{
    /// <summary>
    /// Ligação da tela <c>frmEditaRevisaoSimplificada</c> (comando <c>REVSIMP</c>), como o construtor
    /// do original (<c>frmEditaRevisaoSimplificada.cs:309</c>): <c>Pagina.restauraCampos</c>, grade
    /// Página (somente leitura) | Revisão, sem ordenação, com as páginas de <c>SCapa</c> a
    /// <c>SCorpo</c> (<c>uy7iNUG3AA :359</c>); menu Copiar / Colar / Limpar / Editar DWG; colunas
    /// meio a meio da largura da grade menos 30, a cada redimensionamento (<c>:464</c>).
    /// </summary>
    internal sealed class LigacaoDoFrmEditaRevisaoSimplificada : ILigacaoDeTela
    {
        private string _copiado = string.Empty;

        public string NomeDaTela
        {
            get { return "frmEditaRevisaoSimplificada"; }
        }

        public void Preencher(Form janela)
        {
            if (janela == null)
            {
                return;
            }

            DataGridView grade = ControlesDaTela.Achar<DataGridView>(janela, "dg");
            if (grade == null)
            {
                return;
            }

            // `Pagina.restauraCampos` antes de ler a grade (aberta pela paleta, o lock é nosso).
            try
            {
                Positron.Plugin.Paginas.RestauracaoDoFormatoDoDesenho.RestaurarCampos();
            }
            catch (Exception erro)
            {
                Aviso.MsgBoxCritico(erro.Message, string.Empty);
            }

            // Do designer: `MinimumSize = 230×500`.
            janela.MinimumSize = new Size(230, 500);

            ContextMenuStrip menu = grade.ContextMenuStrip;
            ToolStripMenuItem copiar = ControlesDaTela.AcharItem<ToolStripMenuItem>(menu, "CopiarToolStripMenuItem");
            ToolStripMenuItem colar = ControlesDaTela.AcharItem<ToolStripMenuItem>(menu, "ColarToolStripMenuItem");
            ToolStripMenuItem limpar = ControlesDaTela.AcharItem<ToolStripMenuItem>(menu, "LimparStripMenuItem");
            ToolStripMenuItem editar = ControlesDaTela.AcharItem<ToolStripMenuItem>(menu, "EditarToolStripMenuItem");

            // `limpaDG`: duas colunas (mMensagem 39 e 62), sem ordenação, meio a meio.
            grade.Rows.Clear();
            grade.Columns.Clear();
            grade.Columns.Add("", "Página");
            grade.Columns.Add("", "Revisão");
            foreach (DataGridViewColumn coluna in grade.Columns)
            {
                coluna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            Action larguras = () =>
            {
                if (grade.Columns.Count == 2)
                {
                    int metade = (int)Math.Round((grade.Width - 30) / 2f);
                    grade.Columns[0].Width = metade;
                    grade.Columns[1].Width = metade;
                }
            };
            larguras();
            janela.Resize += (origem, evento) => larguras();

            // `uy7iNUG3AA`: de `SCapa` (1, senão 2) até `SCorpo` (a última, senão 1).
            ConfiguracaoDoCaderno conf = ConfiguracaoDoDesenho.LerOuPadrao();
            bool incluiCapa = conf.SCapa;
            bool incluiCorpo = conf.SCorpo;
            try
            {
                List<RevisaoSimplificadaDaPagina> revisoes = RevisoesDoDesenho.LerSimplificadas();
                int primeira = incluiCapa ? 1 : 2;
                int ultima = incluiCorpo ? revisoes.Count : 1;
                for (int i = primeira; i <= ultima; i++)
                {
                    grade.Rows.Add(revisoes[i - 1].Pagina, revisoes[i - 1].Revisao);
                }
                grade.Columns[0].ReadOnly = true;
            }
            catch (Exception erro)
            {
                Aviso.MsgBoxCritico(erro.Message, string.Empty);
            }

            // `jMviF3tmHg` (Click da grade): Copiar só com uma célula selecionada.
            grade.Click += (origem, evento) =>
            {
                if (copiar != null)
                {
                    copiar.Enabled = grade.SelectedCells.Count == 1;
                }
            };

            if (copiar != null)
            {
                copiar.Click += (origem, evento) =>
                {
                    if (grade.SelectedCells.Count == 1)
                    {
                        _copiado = Convert.ToString(grade.SelectedCells[0].Value) ?? string.Empty;
                    }
                };
            }

            if (colar != null)
            {
                colar.Click += (origem, evento) =>
                {
                    foreach (DataGridViewCell celula in grade.SelectedCells)
                    {
                        if (celula.ColumnIndex > 0)
                        {
                            celula.Value = _copiado;
                        }
                    }
                };
            }

            if (limpar != null)
            {
                limpar.Click += (origem, evento) =>
                {
                    foreach (DataGridViewCell celula in grade.SelectedCells)
                    {
                        if (celula.ColumnIndex > 0)
                        {
                            celula.Value = string.Empty;
                        }
                    }
                };
            }

            if (editar != null)
            {
                // `C6GiKcqEd2`: revisão nula vira vazia, grava (`AtualizaRevSimplificada`, com o
                // lock do documento) e fecha; o erro vira MsgBox crítico e a tela fica aberta.
                editar.Click += (origem, evento) =>
                {
                    try
                    {
                        List<RevisaoSimplificadaDaPagina> lista = new List<RevisaoSimplificadaDaPagina>();
                        foreach (DataGridViewRow linha in grade.Rows)
                        {
                            lista.Add(new RevisaoSimplificadaDaPagina(
                                Convert.ToString(linha.Cells[0].Value),
                                Convert.ToString(linha.Cells[1].Value) ?? string.Empty));
                        }

                        using (Application.DocumentManager.MdiActiveDocument.LockDocument())
                        {
                            RevisoesDoDesenho.GravarSimplificadas(lista);
                        }

                        janela.Close();
                    }
                    catch (Exception erro)
                    {
                        Aviso.MsgBoxCritico(erro.Message, string.Empty);
                    }
                };
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Positron.Data.Paginas;
using Positron.Plugin.Paginas;

namespace Positron.Plugin.Interface.Telas
{
    /// <summary>
    /// Ligação da tela <c>frmEditaRevisaoSimplificada</c> à regra do recoder:
    /// - preenche a grade com as páginas do caderno e a revisão lida do desenho CAD
    ///   (<see cref="RevisoesDoDesenho.LerSimplificadas"/>);
    /// - liga o menu de contexto: Copiar, Colar, Limpar e Editar (grava no desenho);
    /// - a coluna 0 (Página) é somente leitura; a coluna 1 (Revisão) é editável.
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

            ContextMenuStrip menu = grade.ContextMenuStrip;
            ToolStripMenuItem copiar = ControlesDaTela.AcharItem<ToolStripMenuItem>(menu, "CopiarToolStripMenuItem");
            ToolStripMenuItem colar = ControlesDaTela.AcharItem<ToolStripMenuItem>(menu, "ColarToolStripMenuItem");
            ToolStripMenuItem limpar = ControlesDaTela.AcharItem<ToolStripMenuItem>(menu, "LimparStripMenuItem");
            ToolStripMenuItem editar = ControlesDaTela.AcharItem<ToolStripMenuItem>(menu, "EditarToolStripMenuItem");

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
                editar.Click += (origem, evento) =>
                {
                    List<RevisaoSimplificadaDaPagina> lista = new List<RevisaoSimplificadaDaPagina>();
                    foreach (DataGridViewRow linha in grade.Rows)
                    {
                        if (linha.Cells.Count >= 2)
                        {
                            string pag = Convert.ToString(linha.Cells[0].Value);
                            string rev = Convert.ToString(linha.Cells[1].Value);
                            if (!string.IsNullOrEmpty(pag))
                            {
                                lista.Add(new RevisaoSimplificadaDaPagina(pag, rev));
                            }
                        }
                    }

                    int gravados = RevisoesDoDesenho.GravarSimplificadas(lista);
                    Plugin.Escrever("REVSIMP: " + gravados + " revisão(ões) simplificada(s) regravada(s) no desenho.");
                    janela.Close();
                };
            }

            // Carga das páginas e revisões
            grade.Rows.Clear();
            List<RevisaoSimplificadaDaPagina> revisoes = RevisoesDoDesenho.LerSimplificadas();
            foreach (RevisaoSimplificadaDaPagina rev in revisoes)
            {
                grade.Rows.Add(rev.Pagina, rev.Revisao);
            }

            if (grade.Columns.Count > 0)
            {
                grade.Columns[0].ReadOnly = true;
            }

            Plugin.Escrever("REVSIMP: " + revisoes.Count + " página(s) carregada(s) na grade.");
        }
    }
}

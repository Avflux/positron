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
    /// Ligação da tela <c>frmEditaRevisaoCompleta</c> (comando <c>REVCOMP</c>), como o construtor do
    /// original (<c>frmEditaRevisaoCompleta.cs:~330</c>): <c>Pagina.restauraCampos</c>, grade de 7
    /// colunas (Página somente leitura) sem ordenação e com larguras 10/10/40/10/10/10/10% da grade
    /// menos 30 (<c>limpaDG</c>, <c>tt4iDtS0Ar</c> a cada <c>Resize</c>), páginas de <c>CCapa</c> a
    /// <c>CCorpo</c> (<c>zwRiJ8qk2J</c>); menu Copiar / Colar / Limpar / DE / PARA / Substituir /
    /// Editar DWG, com DE e PARA em cinza claro e borda 3D.
    /// </summary>
    internal sealed class LigacaoDoFrmEditaRevisaoCompleta : ILigacaoDeTela
    {
        private string _copiado = string.Empty;

        public string NomeDaTela
        {
            get { return "frmEditaRevisaoCompleta"; }
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
                RestauracaoDoFormatoDoDesenho.RestaurarCampos();
            }
            catch (Exception erro)
            {
                Aviso.MsgBoxCritico(erro.Message, string.Empty);
            }

            // Do designer: `MinimumSize = 700×500`.
            janela.MinimumSize = new Size(700, 500);

            ContextMenuStrip menu = grade.ContextMenuStrip;
            ToolStripMenuItem copiar = ControlesDaTela.AcharItem<ToolStripMenuItem>(menu, "CopiarToolStripMenuItem");
            ToolStripMenuItem colar = ControlesDaTela.AcharItem<ToolStripMenuItem>(menu, "ColarToolStripMenuItem");
            ToolStripMenuItem limpar = ControlesDaTela.AcharItem<ToolStripMenuItem>(menu, "LimparStripMenuItem");
            ToolStripTextBox deBox = ControlesDaTela.AcharItem<ToolStripTextBox>(menu, "DeToolStripTextBox");
            ToolStripTextBox paraBox = ControlesDaTela.AcharItem<ToolStripTextBox>(menu, "ParaToolStripTextBox");
            ToolStripMenuItem substituir = ControlesDaTela.AcharItem<ToolStripMenuItem>(menu, "SubstituirToolStripMenuItem");
            ToolStripMenuItem editar = ControlesDaTela.AcharItem<ToolStripMenuItem>(menu, "EditarToolStripMenuItem");

            foreach (ToolStripTextBox caixa in new[] { deBox, paraBox })
            {
                if (caixa != null)
                {
                    caixa.BackColor = Color.LightGray;
                    caixa.BorderStyle = BorderStyle.Fixed3D;
                }
            }

            // `limpaDG`: sete colunas (mMensagem 39, 63..68), sem ordenação.
            grade.Rows.Clear();
            grade.Columns.Clear();
            foreach (string titulo in new[] { "Página", "Revisão", "Descrição", "Data", "Elaborador", "Verificador", "Aprovador" })
            {
                int indice = grade.Columns.Add("", titulo);
                grade.Columns[indice].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            Action larguras = () =>
            {
                if (grade.Columns.Count == 7)
                {
                    float util = grade.Width - 30;
                    float[] percentuais = { 10f, 10f, 40f, 10f, 10f, 10f, 10f };
                    for (int i = 0; i < 7; i++)
                    {
                        grade.Columns[i].Width = (int)Math.Round(util * percentuais[i] / 100f);
                    }
                }
            };
            larguras();
            janela.Resize += (origem, evento) => larguras();

            // `zwRiJ8qk2J`: de `CCapa` (1, senão 2) até `CCorpo` (a última, senão 1).
            ConfiguracaoDoCaderno conf = ConfiguracaoDoDesenho.LerOuPadrao();
            try
            {
                List<RevisaoCompletaDaPagina> revisoes = RevisoesDoDesenho.LerCompletas();
                int primeira = conf.CCapa ? 1 : 2;
                int ultima = conf.CCorpo ? revisoes.Count : 1;
                for (int i = primeira; i <= ultima; i++)
                {
                    RevisaoCompletaDaPagina r = revisoes[i - 1];
                    grade.Rows.Add(r.Pagina, r.Revisao, r.Descricao, r.Data, r.Elaborador, r.Verificador, r.Aprovador);
                }
                grade.Columns[0].ReadOnly = true;
            }
            catch (Exception erro)
            {
                Aviso.MsgBoxCritico(erro.Message, string.Empty);
            }

            // `APeih1WTWH` (Click da grade): Copiar só com uma célula selecionada.
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

            if (substituir != null)
            {
                substituir.Click += (origem, evento) =>
                {
                    string de = deBox != null ? deBox.Text : string.Empty;
                    string para = paraBox != null ? paraBox.Text : string.Empty;
                    foreach (DataGridViewCell celula in grade.SelectedCells)
                    {
                        if (celula.ColumnIndex > 0)
                        {
                            string atual = Convert.ToString(celula.Value) ?? string.Empty;
                            celula.Value = OperacoesDeRevisao.Substituir(atual, de, para);
                        }
                    }
                };
            }

            if (editar != null)
            {
                // `NX5idRlEeH`: nulos das colunas 1..6 viram vazio, grava (`AtualizaRevCompleta`, com
                // o lock do documento) e fecha; o erro vira MsgBox crítico e a tela fica aberta.
                editar.Click += (origem, evento) =>
                {
                    try
                    {
                        List<RevisaoCompletaDaPagina> lista = new List<RevisaoCompletaDaPagina>();
                        foreach (DataGridViewRow linha in grade.Rows)
                        {
                            lista.Add(new RevisaoCompletaDaPagina(
                                Convert.ToString(linha.Cells[0].Value),
                                Convert.ToString(linha.Cells[1].Value) ?? string.Empty,
                                Convert.ToString(linha.Cells[2].Value) ?? string.Empty,
                                Convert.ToString(linha.Cells[3].Value) ?? string.Empty,
                                Convert.ToString(linha.Cells[4].Value) ?? string.Empty,
                                Convert.ToString(linha.Cells[5].Value) ?? string.Empty,
                                Convert.ToString(linha.Cells[6].Value) ?? string.Empty));
                        }

                        using (Application.DocumentManager.MdiActiveDocument.LockDocument())
                        {
                            RevisoesDoDesenho.GravarCompletas(lista);
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

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Positron.Data.Paginas;
using Positron.Plugin.Paginas;

namespace Positron.Plugin.Interface.Telas
{
    /// <summary>
    /// Ligação da tela <c>frmEditaRevisaoCompleta</c> à regra do recoder:
    /// - preenche a grade com as páginas do caderno e a revisão completa lida do desenho CAD
    ///   (<see cref="RevisoesDoDesenho.LerCompletas"/>);
    /// - liga o menu de contexto: Copiar, Colar, Limpar, Substituir (com campos DE/PARA) e Editar (grava no desenho);
    /// - a coluna 0 (Página) é somente leitura; as demais são editáveis.
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

            ContextMenuStrip menu = grade.ContextMenuStrip;
            ToolStripMenuItem copiar = ControlesDaTela.AcharItem<ToolStripMenuItem>(menu, "CopiarToolStripMenuItem");
            ToolStripMenuItem colar = ControlesDaTela.AcharItem<ToolStripMenuItem>(menu, "ColarToolStripMenuItem");
            ToolStripMenuItem limpar = ControlesDaTela.AcharItem<ToolStripMenuItem>(menu, "LimparStripMenuItem");
            ToolStripTextBox deBox = ControlesDaTela.AcharItem<ToolStripTextBox>(menu, "DeToolStripTextBox");
            ToolStripTextBox paraBox = ControlesDaTela.AcharItem<ToolStripTextBox>(menu, "ParaToolStripTextBox");
            ToolStripMenuItem substituir = ControlesDaTela.AcharItem<ToolStripMenuItem>(menu, "SubstituirToolStripMenuItem");
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
                editar.Click += (origem, evento) =>
                {
                    List<RevisaoCompletaDaPagina> lista = new List<RevisaoCompletaDaPagina>();
                    foreach (DataGridViewRow linha in grade.Rows)
                    {
                        if (linha.Cells.Count >= 7)
                        {
                            string pag = Convert.ToString(linha.Cells[0].Value);
                            if (!string.IsNullOrEmpty(pag))
                            {
                                lista.Add(new RevisaoCompletaDaPagina(
                                    pag,
                                    Convert.ToString(linha.Cells[1].Value),
                                    Convert.ToString(linha.Cells[2].Value),
                                    Convert.ToString(linha.Cells[3].Value),
                                    Convert.ToString(linha.Cells[4].Value),
                                    Convert.ToString(linha.Cells[5].Value),
                                    Convert.ToString(linha.Cells[6].Value)
                                ));
                            }
                        }
                    }

                    RevisoesDoDesenho.ResultadoDaGravacaoDeRevisoes gravacao = RevisoesDoDesenho.GravarCompletas(lista);
                    Plugin.Escrever("REVCOMP: " + gravacao.Paginas + " página(s) posicionada(s) — "
                        + gravacao.Atualizados + " atualizada(s), " + gravacao.Criados + " criada(s) ("
                        + gravacao.Deslocados + " deslocada(s)), " + gravacao.Apagados + " apagada(s)"
                        + (gravacao.Estourou ? "; houve deslocamento por falta de posição" : "")
                        + (gravacao.Definicoes > 0 ? "; " + gravacao.Definicoes + " definição(ões) Revisao_Capa/Corpo (re)criada(s)" : "")
                        + (gravacao.Referencias > 0 ? "; " + gravacao.Referencias + " referência(s) ressincronizada(s)" : "")
                        + (gravacao.SemDefinicao > 0 ? "; " + gravacao.SemDefinicao + " sem bloco de formato (Revisao_Capa/Corpo)" : "")
                        + (gravacao.SemFormato > 0 ? "; " + gravacao.SemFormato + " página(s) sem posições no formato" : "")
                        + ".");
                    janela.Close();
                };
            }

            // Carga das páginas e revisões completas
            grade.Rows.Clear();
            List<RevisaoCompletaDaPagina> revisoes = RevisoesDoDesenho.LerCompletas();
            foreach (RevisaoCompletaDaPagina r in revisoes)
            {
                grade.Rows.Add(r.Pagina, r.Revisao, r.Descricao, r.Data, r.Elaborador, r.Verificador, r.Aprovador);
            }

            if (grade.Columns.Count > 0)
            {
                grade.Columns[0].ReadOnly = true;
            }

            Plugin.Escrever("REVCOMP: " + revisoes.Count + " página(s) carregada(s) na grade.");
        }
    }
}

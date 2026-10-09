#if !POSITRON_SEM_WINFORMS
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Positron.Data.Relatorios;

namespace Positron.Plugin.Relatorios
{
    /// <summary>
    /// Tela de compilação — a **grid de erros** do <c>frmCompilarFiacao</c>/
    /// <c>Interligacao</c> do original, montada sobre o mesmo
    /// <see cref="RelatorioCompilacao"/> que o comando <c>ELETREL</c> grava em
    /// arquivo.
    ///
    /// A tela **não** monta conteúdo: ela mostra as linhas já calculadas e, no botão
    /// Salvar, escreve o mesmo texto no mesmo formato. Assim o que a tela mostra e o
    /// que o arquivo leva não podem divergir.
    ///
    /// É modal e aberta pelo comando <c>ELETCMP</c>; para script existe o
    /// <c>ELETREL</c> (mesmo conteúdo, sem tela).
    /// </summary>
    internal sealed class FormularioCompilacao : Form
    {
        private readonly RelatorioCompilacao _relatorio;
        private readonly string _caminho;
        private readonly DataGridView _grade = new DataGridView();

        /// <summary>Caminho gravado no botão Salvar (vazio se o usuário cancelou).</summary>
        internal string ArquivoSalvo { get; private set; }

        internal FormularioCompilacao(RelatorioCompilacao relatorio, string caminho)
        {
            _relatorio = relatorio ?? RelatorioCompilacao.DeProblemas("Relatório", string.Empty, null);
            _caminho = caminho;

            Text = "Positron — compilação";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(900, 480);
            MinimumSize = new Size(600, 320);

            Label resumo = new Label
            {
                Text = _relatorio.Resumo ?? string.Empty,
                Left = 12,
                Top = 12,
                Width = 860,
                Height = 20,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
            };

            Label contagem = new Label
            {
                Text = _relatorio.Linhas.Count + " problema(s)",
                Left = 12,
                Top = 34,
                Width = 860,
                Height = 20,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
            };

            _grade.Left = 12;
            _grade.Top = 60;
            _grade.Width = 860;
            _grade.Height = 370;
            _grade.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            _grade.ReadOnly = true;
            _grade.AllowUserToAddRows = false;
            _grade.AllowUserToDeleteRows = false;
            _grade.AllowUserToResizeRows = false;
            _grade.RowHeadersVisible = false;
            _grade.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _grade.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _grade.Columns.Add("area", "Área");
            _grade.Columns.Add("tipo", "Tipo");
            _grade.Columns.Add("tabela", "Tabela");
            _grade.Columns.Add("identificador", "Identificador");
            _grade.Columns.Add("detalhe", "Detalhe");

            foreach (LinhaRelatorio linha in _relatorio.Linhas)
            {
                _grade.Rows.Add(linha.Area, linha.Tipo, linha.Tabela, linha.Identificador, linha.Detalhe);
            }

            Button salvar = new Button
            {
                Text = "Salvar",
                Left = 700,
                Top = 440,
                Width = 80,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
            };

            Button fechar = new Button
            {
                Text = "Fechar",
                Left = 792,
                Top = 440,
                Width = 80,
                DialogResult = DialogResult.OK,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
            };

            salvar.Click += (origem, evento) => Salvar();

            Controls.Add(resumo);
            Controls.Add(contagem);
            Controls.Add(_grade);
            Controls.Add(salvar);
            Controls.Add(fechar);
            AcceptButton = fechar;
            CancelButton = fechar;
        }

        private void Salvar()
        {
            try
            {
                string destino = _caminho;
                if (string.IsNullOrWhiteSpace(destino))
                {
                    using (SaveFileDialog dialogo = new SaveFileDialog())
                    {
                        dialogo.FileName = "positron-relatorio.txt";
                        dialogo.Filter = "Texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
                        if (dialogo.ShowDialog() != DialogResult.OK)
                        {
                            return;
                        }

                        destino = dialogo.FileName;
                    }
                }

                _relatorio.Salvar(destino);
                ArquivoSalvo = destino;
                MessageBox.Show("Relatório gravado em " + destino + ".", "Positron");
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possível gravar: " + erro.Message, "Positron", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
#endif

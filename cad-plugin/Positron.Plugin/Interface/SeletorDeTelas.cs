using System;
using System.Drawing;
using System.Windows.Forms;
using Positron.Data.Interface;

namespace Positron.Plugin.Interface
{
    /// <summary>
    /// O **seletor das telas do reverso**: lista as 127 janelas decodificadas (o nome do `frm`, o
    /// título, quantos controles e a linha do designer) e abre a escolhida **dentro do CAD**, pelo
    /// <see cref="JanelaDoReverso"/>.
    ///
    /// Esta tela **não existe no original** — lá cada janela tem o seu comando (`GERDWG` abre a
    /// `frmGerenciadorDWG`, `DEF` a `frmDefinicao`, `BORN` a `frmBornes`…). O seletor é do recoder:
    /// um lugar só para alcançar as 127 sem decorar 127 nomes de comando. O que ele abre é fiel.
    ///
    /// O botão **Montar todas** roda a mesma prova do comando <c>pzTelas</c> sem sair da tela:
    /// monta as 127 e descarta, reportando qualquer falha.
    /// </summary>
    internal sealed class SeletorDeTelas : Form
    {
        private readonly TextBox _filtro;
        private readonly DataGridView _grade;
        private readonly Label _contagem;

        internal SeletorDeTelas()
        {
            Text = "Positron — janelas do reverso (" + FormulariosDoReverso.Quantidade + ")";
            ClientSize = new Size(760, 460);
            StartPosition = FormStartPosition.CenterScreen;
            MinimizeBox = false;
            Font = new Font("Microsoft Sans Serif", 8.25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScaleDimensions = new SizeF(6F, 13F);

            Panel topo = new Panel { Dock = DockStyle.Top, Height = 26 };
            Label rotulo = new Label { Text = "Filtrar:", Left = 6, Top = 5, Width = 44 };
            _filtro = new TextBox { Left = 54, Top = 3, Width = 690, Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
            _filtro.TextChanged += (origem, evento) => Carregar();
            topo.Controls.Add(rotulo);
            topo.Controls.Add(_filtro);

            _grade = new DataGridView
            {
                Name = "dgTelas",
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                RowHeadersVisible = false,
                MultiSelect = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
            };
            _grade.Columns.Add("frm", "frm (o nome no original)");
            _grade.Columns.Add("titulo", "Título");
            _grade.Columns.Add("controles", "Controles");
            _grade.Columns.Add("designer", "Designer (linha)");
            _grade.Columns[0].FillWeight = 30;
            _grade.Columns[1].FillWeight = 45;
            _grade.Columns[2].FillWeight = 12;
            _grade.Columns[3].FillWeight = 13;
            _grade.CellDoubleClick += (origem, evento) => AbrirSelecionada();

            Panel rodape = new Panel { Dock = DockStyle.Bottom, Height = 34 };
            Button abrir = new Button { Text = "Abrir no CAD", Left = 6, Top = 5, Width = 120 };
            abrir.Click += (origem, evento) => AbrirSelecionada();
            Button montar = new Button { Text = "Montar todas", Left = 132, Top = 5, Width = 110 };
            montar.Click += (origem, evento) => Plugin.Escrever(JanelaDoReverso.ConferirTodas());
            _contagem = new Label { Left = 252, Top = 10, Width = 500, Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
            rodape.Controls.Add(abrir);
            rodape.Controls.Add(montar);
            rodape.Controls.Add(_contagem);

            Controls.Add(_grade);
            Controls.Add(rodape);
            Controls.Add(topo);

            Carregar();
        }

        /// <summary>Preenche a grade com as telas que passam no filtro.</summary>
        internal int Carregar()
        {
            string filtro = _filtro.Text.Trim();
            _grade.Rows.Clear();

            int mostradas = 0;
            foreach (Tela tela in FormulariosDoReverso.Todas)
            {
                if (filtro.Length > 0
                    && tela.Nome.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) < 0
                    && (tela.Titulo ?? string.Empty).IndexOf(filtro, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    continue;
                }

                _grade.Rows.Add(tela.Nome, tela.Titulo, tela.Campos.Count, tela.Origem);
                mostradas++;
            }

            _contagem.Text = mostradas + " de " + FormulariosDoReverso.Quantidade + " tela(s). Duplo clique abre no CAD.";
            return mostradas;
        }

        private void AbrirSelecionada()
        {
            if (_grade.SelectedRows.Count == 0)
            {
                return;
            }

            string nome = _grade.SelectedRows[0].Cells[0].Value as string;
            Plugin.Escrever(JanelaDoReverso.Abrir(nome));
        }

        /// <summary>Abre o seletor modeless dentro do CAD e devolve a linha de resumo.</summary>
        internal static string Abrir()
        {
            try
            {
                SeletorDeTelas seletor = new SeletorDeTelas();
#if AUTOCAD
                Autodesk.AutoCAD.ApplicationServices.Application.ShowModelessDialog(seletor);
#else
                ZwSoft.ZwCAD.ApplicationServices.Application.ShowModelessDialog(seletor);
#endif
                return "JANELAS: seletor aberto com " + FormulariosDoReverso.Quantidade + " tela(s) do reverso.";
            }
            catch (System.Exception erro)
            {
                return "JANELAS: falhou — " + erro.Message + ".";
            }
        }
    }
}

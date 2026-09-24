using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Positron.Data.Paginas;
using Positron.Plugin.Paginas;

namespace Positron.Plugin.Interface
{
    /// <summary>
    /// A **janela de folhas** — a primeira fatia da frente 11 (o shell do plugin): a lista das
    /// páginas do caderno (os layers do desenho que a regra aceita), na ordem do
    /// <see cref="PaginaNumerada"/>.
    ///
    /// **Fatia atual:** uma janela WinForms com a grade e o botão de recarregar. A **paleta**
    /// ancorável do original (<c>PaletteSet</c> + <c>uscPaginas</c>) e a **barra de ferramentas**
    /// vêm nas próximas fatias — e a validação visual é do dono do produto.
    /// </summary>
    internal sealed class JanelaDeFolhas : Form
    {
        private readonly DataGridView _grade;

        internal JanelaDeFolhas()
        {
            Text = "Positron — folhas do caderno";
            Width = 420;
            Height = 460;
            StartPosition = FormStartPosition.CenterScreen;

            _grade = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            };
            _grade.Columns.Add("ordem", "#");
            _grade.Columns.Add("pagina", "Folha");
            _grade.Columns.Add("decimal", "Ordem");

            Button recarregar = new Button
            {
                Dock = DockStyle.Bottom,
                Height = 30,
                Text = "Recarregar do desenho",
            };
            recarregar.Click += (origem, evento) => Carregar();

            Controls.Add(_grade);
            Controls.Add(recarregar);
        }

        /// <summary>Relê as páginas do desenho e preenche a grade. Devolve quantas achou.</summary>
        internal int Carregar()
        {
            List<string> paginas = PaginasDoDesenho.Ler();

            _grade.Rows.Clear();
            for (int i = 0; i < paginas.Count; i++)
            {
                _grade.Rows.Add(
                    (i + 1).ToString(),
                    paginas[i],
                    PaginaNumerada.Decimal(paginas[i]).ToString("0.00"));
            }

            Text = "Positron — folhas do caderno (" + paginas.Count + ")";
            return paginas.Count;
        }
    }
}

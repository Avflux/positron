using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Positron.Data.Paginas;
using Positron.Plugin.Paginas;

namespace Positron.Plugin.Interface
{
    /// <summary>
    /// O controle das **folhas do caderno** — a grade com as páginas do desenho (o
    /// <c>uscPaginas</c> do reverso). Ele vive dentro da <see cref="PaletaDeFolhas"/> (a
    /// <c>PaletteSet</c>), e não numa janela solta: a paleta é do CAD, então o desenho continua
    /// utilizável sem perder o foco (a correção pedida na rodada 121).
    /// </summary>
    internal sealed class FolhasControle : UserControl
    {
        private readonly DataGridView _grade;

        internal FolhasControle()
        {
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
                Height = 26,
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

            return paginas.Count;
        }
    }
}

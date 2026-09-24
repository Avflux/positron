using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Positron.Data.Paginas;
using Positron.Plugin.Paginas;

namespace Positron.Plugin.Interface
{
    /// <summary>
    /// O controle das **folhas do caderno** — o `uscPaginas` do reverso: a grade `dg` com as
    /// colunas dele (`Pg` e `PgDecimal` são técnicas, como lá) e o **menu de contexto** com os
    /// itens literais do designer do original: Multiseleção, Nova Página, Inserir, Excluir
    /// Páginas, Renomear Páginas, Editar Unidade e Editar Alternativo.
    ///
    /// Os **títulos** das três primeiras colunas e os textos dos painéis da barra vêm da tabela
    /// `mMensagem` do original, que está nos **recursos ofuscados** da DLL (ver a auditoria da
    /// rodada 122): aqui vão rótulos descritivos. Os itens cuja regra ainda não foi portada
    /// (as fatias 3 a 5 da frente 10) ficam **desabilitados**, com o motivo no texto.
    /// </summary>
    internal sealed class FolhasControle : UserControl
    {
        private readonly DataGridView _grade;

        internal FolhasControle()
        {
            _grade = new DataGridView
            {
                Name = "dg",
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            };

            // As colunas do reverso: as três de conteúdo (da mMensagem) e as duas técnicas
            // (`Pg` e `PgDecimal`), que ficam escondidas como lá.
            _grade.Columns.Add("pagina", Positron.Data.Interface.MensagensDoReverso.Pagina);
            _grade.Columns.Add("alternativo", Positron.Data.Interface.MensagensDoReverso.Alternativo);
            _grade.Columns.Add("unidade", Positron.Data.Interface.MensagensDoReverso.Unidade);
            _grade.Columns.Add("Pg", "Pg");
            _grade.Columns.Add("PgDecimal", "PgDecimal");
            _grade.Columns[3].Visible = false;
            _grade.Columns[4].Visible = false;

            _grade.ContextMenuStrip = MenuDoReverso();

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

        /// <summary>
        /// O menu de contexto com os itens **literais** do `uscPaginas` do reverso. Os que
        /// dependem de regra ainda não portada ficam desabilitados — a intenção é a mesma tela,
        /// com o que já funciona ligado.
        /// </summary>
        private static ContextMenuStrip MenuDoReverso()
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            menu.Items.Add(new ToolStripMenuItem("Multiseleção"));
            menu.Items.Add(new ToolStripMenuItem("Alternativo"));
            menu.Items.Add(new ToolStripSeparator());
            menu.Items.Add(Desabilitado("Nova Página", "regra na fatia 3 da frente 10"));
            menu.Items.Add(Desabilitado("Inserir", "regra na fatia 3 da frente 10"));
            menu.Items.Add(Desabilitado("Excluir Páginas", "regra na fatia 4 da frente 10"));
            menu.Items.Add(Desabilitado("Renomear Páginas", "regra na fatia 4 da frente 10"));
            menu.Items.Add(new ToolStripSeparator());
            menu.Items.Add(new ToolStripMenuItem("Editar Unidade"));
            menu.Items.Add(new ToolStripMenuItem("Editar Alternativo"));
            return menu;
        }

        private static ToolStripMenuItem Desabilitado(string texto, string motivo)
        {
            return new ToolStripMenuItem(texto) { Enabled = false, ToolTipText = motivo };
        }

        /// <summary>Relê as páginas do desenho e preenche a grade. Devolve quantas achou.</summary>
        internal int Carregar()
        {
            List<string> paginas = PaginasDoDesenho.Ler();

            _grade.Rows.Clear();
            for (int i = 0; i < paginas.Count; i++)
            {
                double valor = PaginaNumerada.Decimal(paginas[i]);
                _grade.Rows.Add(
                    paginas[i],
                    "",
                    "",
                    paginas[i],
                    valor.ToString("0.00"));
            }

            return paginas.Count;
        }
    }
}

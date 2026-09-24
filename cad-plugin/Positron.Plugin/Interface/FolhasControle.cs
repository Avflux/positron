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

        private readonly TextBox _sufixo;

        /// <summary>O resultado da última operação, para o chamador registrar.</summary>
        internal string UltimaMensagem { get; private set; } = string.Empty;

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

            // A barra de baixo: o sufixo do RENPAGA, o renomear (a regra pura) e o recarregar.
            Panel rodape = new Panel { Dock = DockStyle.Bottom, Height = 30 };
            _sufixo = new TextBox { Left = 4, Top = 4, Width = 28, MaxLength = 1, Text = "A" };
            Button renomear = new Button { Left = 36, Top = 3, Width = 150, Text = "Renomear Páginas" };
            renomear.Click += (origem, evento) => RenomearPaginas();
            Button recarregar = new Button { Left = 190, Top = 3, Width = 150, Text = "Recarregar do desenho" };
            recarregar.Click += (origem, evento) => Carregar();
            rodape.Controls.Add(_sufixo);
            rodape.Controls.Add(renomear);
            rodape.Controls.Add(recarregar);

            Controls.Add(_grade);
            Controls.Add(rodape);
        }

        /// <summary>
        /// O menu de contexto com os itens **literais** do `uscPaginas` do reverso. Os que
        /// dependem de regra ainda não portada ficam desabilitados — a intenção é a mesma tela,
        /// com o que já funciona ligado.
        /// </summary>
        private ContextMenuStrip MenuDoReverso()
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            menu.Items.Add(new ToolStripMenuItem("Multiseleção"));
            menu.Items.Add(new ToolStripMenuItem("Alternativo"));
            menu.Items.Add(new ToolStripSeparator());
            menu.Items.Add(Desabilitado("Nova Página", "regra na fatia 3 da frente 10"));
            menu.Items.Add(Desabilitado("Inserir", "regra na fatia 3 da frente 10"));
            menu.Items.Add(Desabilitado("Excluir Páginas", "regra na fatia 4 da frente 10"));
            // O Renomear está ligado na regra do RENPAGA (o sufixo vem do campo ao lado).
            ToolStripMenuItem renomear = new ToolStripMenuItem("Renomear Páginas");
            renomear.Click += (origem, evento) => RenomearPaginas();
            menu.Items.Add(renomear);
            menu.Items.Add(new ToolStripSeparator());
            menu.Items.Add(new ToolStripMenuItem("Editar Unidade"));
            menu.Items.Add(new ToolStripMenuItem("Editar Alternativo"));
            return menu;
        }

        private static ToolStripMenuItem Desabilitado(string texto, string motivo)
        {
            return new ToolStripMenuItem(texto) { Enabled = false, ToolTipText = motivo };
        }

        /// <summary>
        /// O <c>Renomear Páginas</c> do menu: aplica o sufixo do <c>RENPAGA</c> (a regra pura
        /// valida e monta os nomes) e renomeia os layers; depois recarrega a grade.
        /// </summary>
        internal int RenomearPaginas()
        {
            string sufixo = _sufixo.Text;
            if (!PaginasDoCaderno.SufixoValido(sufixo))
            {
                UltimaMensagem = "RENPAGA: o sufixo tem de ser um caractere (número ou A-Z).";
                return 0;
            }

            List<string> antigos = PaginasDoDesenho.Ler();
            IReadOnlyList<string> novos = PaginasDoCaderno.Renomear(antigos, sufixo);
            int renomeados = PaginasDoDesenho.Renomear(antigos, novos);
            Carregar();

            UltimaMensagem = "RENPAGA: " + renomeados + " página(s) renomeada(s) com o sufixo \"" + sufixo + "\".";
            return renomeados;
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

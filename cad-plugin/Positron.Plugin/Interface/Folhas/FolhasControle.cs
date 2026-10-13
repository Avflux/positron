using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Positron.Data.Paginas;
using Positron.Plugin.Paginas;

namespace Positron.Plugin.Interface.Folhas
{
    /// <summary>
    /// O controle das **folhas do caderno** — o `uscPaginas` do reverso: a grade `dg` com as
    /// colunas dele (`Pg` e `PgDecimal` são técnicas, como lá) e o **menu de contexto inteiro**, os
    /// 14 itens do `cmStrip1` na ordem do designer, com os textos que o usuário lê (a `mMensagem`
    /// do original, que o construtor grava por cima do literal do designer — o `Renumerar Páginas`
    /// é a mMensagem 22) e os ícones do produto (`Pagina`, `Colunas2`, `Apagar`, `Renomear`,
    /// `Editar_16`), mais o combo `Folha` com os seis formatos literais.
    ///
    /// Os itens cuja regra ainda não foi portada (as fatias 4 a 6 da frente 10) ficam
    /// **desabilitados**, com o motivo no tooltip — a mesma regra da barra e da frente 12: a tela
    /// é a do original, e o que funciona é o que está ligado (`Inserir` pela regra do
    /// `NovaPaginaEntre` e o `Renumerar Páginas` pelo `RENPAGA`).
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
            Button renomear = new Button { Left = 36, Top = 3, Width = 150, Text = Positron.Data.Interface.MensagensDoReverso.RenumerarPaginas };
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
        /// O menu de contexto do `cmStrip1` do reverso: os **14 itens, na ordem do designer**, com
        /// o **texto que o usuário lê** (o que o construtor do original grava por cima do literal
        /// do designer — a `mMensagem`) e os **ícones do produto**. Os itens cuja regra ainda não
        /// foi portada ficam desabilitados, com o motivo no tooltip.
        /// </summary>
        private ContextMenuStrip MenuDoReverso()
        {
            ContextMenuStrip menu = new ContextMenuStrip();

            // 1 e 2 - os dois checáveis do designer. O `Alternativo` faz o que o original faz
            // (`uscPaginas.cs:2005`): liga/desliga a coluna e o item `Editar Alternativo`. O
            // `Multiseleção` fica checável como lá, mas o efeito dele não foi rastreado.
            ToolStripMenuItem multiselecao = new ToolStripMenuItem("Multiseleção")
            {
                CheckOnClick = true,
                Checked = false,
                ToolTipText = "o efeito deste item no original não foi portado",
            };
            menu.Items.Add(multiselecao);

            ToolStripMenuItem alternativo = new ToolStripMenuItem(Positron.Data.Interface.MensagensDoReverso.Alternativo)
            {
                CheckOnClick = true,
                Checked = true,
                ToolTipText = "mostra ou esconde a coluna Alternativo",
            };
            menu.Items.Add(alternativo);

            menu.Items.Add(new ToolStripSeparator());

            // 4 - Nova Página (o `CriarPaginaToolStripMenuItem`, ícone Pagina): a fatia 6 — cria a
            // página depois da última, com o layer e os campos do formato (o `criarUmaNovaPagina`).
            ToolStripMenuItem nova = new ToolStripMenuItem("Nova Página");
            Icone(nova, "Pagina");
            nova.ToolTipText = "cria a página depois da última, com o layer e os campos do formato";
            nova.Click += (origem, evento) => CriarPagina();
            menu.Items.Add(nova);

            // 5 - Inserir: no original são CINCO sub-itens preenchidos em execução; aqui a conta
            // da página entre as duas entra pela regra do `NovaPaginaEntre`.
            ToolStripMenuItem inserir = new ToolStripMenuItem("Inserir");
            Icone(inserir, "Colunas2");
            inserir.ToolTipText = "o original abre cinco sub-itens aqui, preenchidos em execução; este calcula a página entre a selecionada e a próxima";
            inserir.Click += (origem, evento) => InserirPagina();
            menu.Items.Add(inserir);

            // 6 - Excluir Páginas (ícone Apagar): apaga os elementos e o layer das páginas
            // selecionadas (o `ApagarElementosPagina` do original e o ok do dono, rodada 143).
            ToolStripMenuItem excluir = new ToolStripMenuItem("Excluir Páginas");
            Icone(excluir, "Apagar");
            excluir.ToolTipText = "apaga os elementos e o layer das páginas selecionadas (destrutivo)";
            excluir.Click += (origem, evento) => ExcluirPaginas();
            menu.Items.Add(excluir);

            // 7 - o `RENPAGA`: a mMensagem 22 diz "Renumerar", e é isso que a regra faz.
            ToolStripMenuItem renumerar = new ToolStripMenuItem(Positron.Data.Interface.MensagensDoReverso.RenumerarPaginas);
            Icone(renumerar, "Renomear");
            renumerar.ToolTipText = "aplica o sufixo do campo ao lado nas páginas do caderno";
            renumerar.Click += (origem, evento) => RenomearPaginas();
            menu.Items.Add(renumerar);

            menu.Items.Add(new ToolStripSeparator());

            // 9 a 12 - os quatro `Editar*` (todos com o ícone Editar_16 no original).
            menu.Items.Add(Desabilitado(Positron.Data.Interface.MensagensDoReverso.EditarUnidade, "regra na fatia 5 da frente 10", "Editar_16"));

            ToolStripMenuItem editarAlternativo = Desabilitado(
                Positron.Data.Interface.MensagensDoReverso.EditarAlternativo,
                "regra na fatia 5 da frente 10",
                "Editar_16");
            menu.Items.Add(editarAlternativo);

            menu.Items.Add(Desabilitado(Positron.Data.Interface.MensagensDoReverso.EditarTitulos, "regra na fatia 6 da frente 10 (títulos e formatos)", "Editar_16"));

            ToolStripMenuItem revisoes = Desabilitado(
                Positron.Data.Interface.MensagensDoReverso.EditarRevisoes,
                "regra na fatia 5 da frente 10",
                "Editar_16");
            revisoes.DropDownItems.Add(Desabilitado(Positron.Data.Interface.MensagensDoReverso.RevisaoSimplificada, "regra não portada"));
            revisoes.DropDownItems.Add(Desabilitado(Positron.Data.Interface.MensagensDoReverso.RevisaoCompleta, "regra não portada"));
            menu.Items.Add(revisoes);

            menu.Items.Add(new ToolStripSeparator());

            // 14 - o `Folha`: no original é um **combo** no menu, com os seis formatos literais.
            ToolStripComboBox folha = new ToolStripComboBox
            {
                Name = "FolhaToolStripMenuItem",
                FlatStyle = FlatStyle.Standard,
                BackColor = Color.LightGray,
                ToolTipText = "o formato da folha (o original grava no layer da página; a regra não foi portada)",
            };
            foreach (string formato in Positron.Data.Interface.MensagensDoReverso.FormatosDeFolha)
            {
                folha.Items.Add(formato);
            }

            menu.Items.Add(folha);

            // O que o original faz no clique do `Alternativo`.
            alternativo.CheckedChanged += (origem, evento) =>
            {
                _grade.Columns["alternativo"].Visible = alternativo.Checked;
                editarAlternativo.Visible = alternativo.Checked;
            };

            return menu;
        }

        /// <summary>O ícone do item, pelo nome do recurso do produto (o mesmo da barra).</summary>
        private static void Icone(ToolStripMenuItem item, string nome)
        {
            System.Drawing.Bitmap imagem = IconesEmbutidos.BitmapDe(nome);
            if (imagem != null)
            {
                item.Image = imagem;
            }
        }

        private static ToolStripMenuItem Desabilitado(string texto, string motivo)
        {
            return Desabilitado(texto, motivo, null);
        }

        private static ToolStripMenuItem Desabilitado(string texto, string motivo, string icone)
        {
            ToolStripMenuItem item = new ToolStripMenuItem(texto) { Enabled = false, ToolTipText = motivo };
            if (!string.IsNullOrEmpty(icone))
            {
                Icone(item, icone);
            }

            return item;
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
            if (!PaginasDoCaderno.TodasNumericas(antigos))
            {
                UltimaMensagem = "RENPAGA: as páginas não podem conter caracter alfabético para usar esta função.";
                return 0;
            }

            IReadOnlyList<string> novos = PaginasDoCaderno.Renomear(antigos, sufixo);
            int renomeados = PaginasDoDesenho.Renomear(antigos, novos);
            Carregar();

            UltimaMensagem = "RENPAGA: " + renomeados + " página(s) renomeada(s) com o sufixo \"" + sufixo + "\".";
            return renomeados;
        }

        /// <summary>
        /// O <c>Inserir</c> do menu: pega a página selecionada e a **próxima** da lista e calcula,
        /// com a regra do reverso (<see cref="NovaPaginaEntre"/>), a página que cabe entre as duas.
        /// A criação do layer e do formato entra na fatia 6 — aqui a conta é mostrada.
        /// </summary>
        internal string InserirPagina()
        {
            if (_grade.SelectedRows.Count == 0)
            {
                UltimaMensagem = "Inserir: selecione a página anterior à nova.";
                return UltimaMensagem;
            }

            int linha = _grade.SelectedRows[0].Index;
            string anterior = _grade.Rows[linha].Cells[0].Value as string;
            string posterior = linha + 1 < _grade.Rows.Count ? _grade.Rows[linha + 1].Cells[0].Value as string : string.Empty;

            PaginaCalculada nova = NovaPaginaEntre.Calcular(anterior, posterior, PassoPagina());

            // A fatia 6: a página não é só calculada — o layer e os campos do formato são criados.
            CriacaoDePaginaDoDesenho.Resultado resultado = CriacaoDePaginaDoDesenho.Executar(
                nova.Pagina, LarguraFixa(), string.Empty, string.Empty, anterior);
            Carregar();

            UltimaMensagem = "Inserir: entre \"" + anterior + "\" e \"" + (posterior ?? "") + "\" a nova página é \""
                + nova.Pagina + "\" — " + (resultado.Criado
                    ? "layer criado" + (resultado.TemFormato
                        ? " + " + resultado.CamposCopiados + " campo(s) do formato copiado(s)"
                        : " (o desenho não tem bloco de formato)")
                    : (resultado.JaExistia ? "o layer já existia" : "não criada")) + ".";
            return UltimaMensagem;
        }

        /// <summary>A exclusão das páginas selecionadas na grade (o item "Excluir Páginas").</summary>
        private void ExcluirPaginas()
        {
            List<string> escolhidas = new List<string>();
            foreach (DataGridViewRow linha in _grade.SelectedRows)
            {
                if (linha.Cells.Count > 0 && linha.Cells[0].Value != null)
                {
                    escolhidas.Add(linha.Cells[0].Value.ToString());
                }
            }

            UltimaMensagem = escolhidas.Count == 0
                ? "Excluir Páginas: selecione a(s) página(s) na grade."
                : Positron.Plugin.Comandos.ExecutarApagarPaginas(escolhidas);
            Carregar();
        }

        /// <summary>A criação da página do menu "Nova Página" (depois da última) e o recarregar da grade.</summary>
        private void CriarPagina()
        {
            UltimaMensagem = Positron.Plugin.Comandos.ExecutarNovaPagina();
            Carregar();
        }

        /// <summary>A largura fixa do nome da página (o <c>Conf.LarguraFixaPaginas</c>; 0 quando não há configuração).</summary>
        private static int LarguraFixa()
        {
            try
            {
                return Positron.Data.Configuracao.ConfiguracaoPositron.Carregar().LarguraFixaPaginas;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        /// <summary>O passo do caderno (o <c>Conf.PassoPagina</c>; 1 quando não há configuração).</summary>
        private static int PassoPagina()
        {
            try
            {
                return Positron.Data.Configuracao.ConfiguracaoPositron.Carregar().PassoPagina;
            }
            catch (System.Exception)
            {
                return 1;
            }
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

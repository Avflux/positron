using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Positron.Data.Interface;
using Positron.Data.Paginas;
using Positron.Plugin.Paginas;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using AplicacaoDoCad = Autodesk.AutoCAD.ApplicationServices.Application;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using AplicacaoDoCad = ZwSoft.ZwCAD.ApplicationServices.Application;
#endif

namespace Positron.Plugin.Interface.Folhas
{
    /// <summary>Paleta uscPaginas: navegação e atalhos acima, grade, progresso e logo abaixo.</summary>
    internal sealed class FolhasControle : UserControl
    {
        private readonly DataGridView _grade;

        private readonly TextBox _pagina;
        private readonly Label[] _atalhos = new Label[4];
        private readonly ProgressBar _progresso;
        private readonly PictureBox _statusBanco;
        private bool _capturarAtalho;
        private bool _carregando;
        private ToolStripMenuItem _multiselecao;
        private ToolStripMenuItem _alternativo;
        private ToolStripMenuItem _editarAlternativo;
        private ContextMenuStrip _menu;
        private ToolStripComboBox _formatoDaNumeracao;

        /// <summary>O resultado da última operação, para o chamador registrar.</summary>
        internal string UltimaMensagem { get; private set; } = string.Empty;

        /// <summary>A página ativa do desenho (vazia quando a camada corrente não é página).</summary>
        internal string PaginaAtiva { get; private set; } = string.Empty;

        /// <summary>O item `Inserir` (mMensagem 35) e os cinco sub-itens das colunas do formato.</summary>
        private ToolStripMenuItem _inserir;

        private readonly List<ToolStripMenuItem> _colunasDoInserir = new List<ToolStripMenuItem>();

        /// <summary>As cinco colunas do formato do desenho (o `verificaLayerExtraNoFormato`).</summary>
        private IReadOnlyList<ColunaDoFormato> _colunas = ColunasDoFormato.DosLayers(null);

        internal FolhasControle()
        {
            Font = new Font("Microsoft Sans Serif", 8.25F);
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Size = new Size(180, 472);
            _grade = new DataGridView
            {
                Name = "dg",
                Location = new Point(9, 51),
                Size = new Size(Width - 18, Height - 103),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                BackgroundColor = SystemColors.Control,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                ScrollBars = ScrollBars.Vertical,
                ReadOnly = false,
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                // O padrão do original é a multiseleção **desligada** (`uscPaginas.cs:1908`: sem ela o
                // `TBNp1Uume8n` age; com ela, ele só avisa, mMensagem 30). O item `Multiseleção` do
                // menu é quem a liga.
                MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            };

            // As colunas do reverso: as três de conteúdo (da mMensagem) e as duas técnicas
            // (`Pg` e `PgDecimal`), que ficam escondidas como lá.
            _grade.Columns.Add("pagina", Positron.Data.Interface.MensagensDoReverso.Pagina);
            _grade.Columns.Add("unidade", Positron.Data.Interface.MensagensDoReverso.Unidade);
            _grade.Columns.Add("alternativo", Positron.Data.Interface.MensagensDoReverso.Alternativo);
            _grade.Columns.Add("Pg", "Pg");
            _grade.Columns.Add("PgDecimal", "PgDecimal");
            _grade.Columns[3].Visible = false;
            _grade.Columns[4].Visible = false;
            foreach (DataGridViewColumn coluna in _grade.Columns)
                coluna.SortMode = DataGridViewColumnSortMode.NotSortable;
            _grade.Columns[0].ReadOnly = true; // A renumeração inline permanece fora desta rodada.
            _grade.DefaultCellStyle.BackColor = SystemColors.Control;
            _menu = MenuDoReverso();
            _grade.ContextMenuStrip = _menu;
            _grade.SelectionChanged += (origem, evento) =>
            {
                if (!_carregando && !_grade.MultiSelect && _grade.SelectedRows.Count == 1)
                    ExecutarNaTela(() => AtivarPagina(PaginaSelecionada()));
            };
            _grade.CellEndEdit += (origem, evento) => ExecutarNaTela(() =>
            {
                if (evento.RowIndex < 0 || evento.ColumnIndex < 1 || evento.ColumnIndex > 2) return;
                DataGridViewRow linha = _grade.Rows[evento.RowIndex];
                string unidade = Convert.ToString(linha.Cells[1].Value).Trim();
                string alternativo = Convert.ToString(linha.Cells[2].Value).Trim();
                if (alternativo.Length > 20)
                {
                    alternativo = alternativo.Substring(0, 20);
                    Aviso.MsgBox("Máximo de 20 caracteres", "Elétron");
                }
                linha.Cells[1].Value = unidade;
                linha.Cells[2].Value = alternativo;
                UnidadeDaPaginaDoDesenho.Gravar(Convert.ToString(linha.Cells[0].Value), unidade, alternativo);
                if (evento.ColumnIndex == 2) AtualizarContagem();
            });
            _grade.KeyDown += GradeKeyDown;

            _pagina = new TextBox { Name = "tbPagina", Left = 9, Top = 25, Width = 45,
                MaxLength = 7, CharacterCasing = CharacterCasing.Upper };
            Button ir = new Button { Name = "btPagina", Left = 55, Top = 24, Size = new Size(25, 20),
                FlatStyle = FlatStyle.Flat, ForeColor = SystemColors.Control, Image = IconesEmbutidos.BitmapDe("Enter_16") };
            ir.Click += (origem, evento) => ExecutarNaTela(() => IrParaPagina(_pagina.Text));
            _pagina.KeyDown += (origem, evento) =>
            {
                if (evento.KeyCode != Keys.Enter) return;
                evento.SuppressKeyPress = true;
                ExecutarNaTela(() => IrParaPagina(_pagina.Text));
            };
            Button salvar = new Button { Name = "btSalva", Left = 55, Top = 3, Size = new Size(25, 20),
                FlatStyle = FlatStyle.Flat, ForeColor = SystemColors.Control, Image = IconesEmbutidos.BitmapDe("Record_16") };
            salvar.Click += (origem, evento) => _capturarAtalho = true;
            for (int i = 0; i < _atalhos.Length; i++)
            {
                int indice = i;
                Label atalho = new Label { Name = "lb" + (i + 1), Left = 80 + (i % 2) * 48,
                    Top = 7 + (i / 2) * 20, Size = new Size(46, 15), BorderStyle = BorderStyle.FixedSingle,
                    Font = new Font("Tahoma", 8.25F), TextAlign = ContentAlignment.MiddleCenter };
                atalho.Click += (origem, evento) => ExecutarNaTela(() => UsarAtalho(indice));
                _atalhos[i] = atalho;
                Controls.Add(atalho);
            }
            _statusBanco = new PictureBox { Name = "PictureBox2", Left = 16, Top = 7,
                Size = new Size(31, 17), Image = IconesEmbutidos.BitmapDe("DB_DISCONNECTED") };
            _progresso = new ProgressBar { Name = "ProgressBar1", Left = 9, Top = Height - 46,
                Size = new Size(Width - 18, 7), Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right };
            PictureBox logo = new PictureBox { Name = "PictureBox1", Left = 9, Top = Height - 33,
                Size = new Size(162, 28), Anchor = AnchorStyles.Bottom | AnchorStyles.Left,
                Image = IconesEmbutidos.BitmapDe("eletron_grande21") };
            Controls.AddRange(new Control[] { _grade, _pagina, ir, salvar, _statusBanco, _progresso, logo });

            // O original le a pagina ativa quando a janela abre (o `LocalizaPaginaAtiva` do `PAG`);
            // o smoke do accoreconsole nao carrega o controle, entao a leitura so acontece com janela.
            Load += (origem, evento) => Carregar();
        }

        /// <summary>
        /// O menu de contexto do `cmStrip1` do reverso: os **14 itens, na ordem do designer**, com
        /// o **texto que o usuário lê** (o que o construtor do original grava por cima do literal
        /// do designer — a `mMensagem`) e os **ícones do produto**. Os itens cuja regra ainda não
        /// foi portada ficam desabilitados e registrados na rodada (sem dicas inventadas).
        /// </summary>
        private ContextMenuStrip MenuDoReverso()
        {
            ContextMenuStrip menu = new ContextMenuStrip();

            // 1 e 2 - os dois checáveis do designer. O `Alternativo` faz o que o original faz
            // (`uscPaginas.cs:2005`): liga/desliga a coluna e o item `Editar Alternativo`. O
            // `Multiseleção` controla também a edição das células.
            ToolStripMenuItem multiselecao = _multiselecao = new ToolStripMenuItem(MensagensDoReverso.Multiselecao)
            {
                CheckOnClick = true,
                Checked = false,
                ToolTipText = "liga a seleção de várias linhas (a Nova Página exige a multiseleção desligada)",
            };
            multiselecao.CheckedChanged += (origem, evento) =>
            {
                _grade.MultiSelect = multiselecao.Checked;
                _grade.Columns[1].ReadOnly = multiselecao.Checked;
                _grade.Columns[2].ReadOnly = multiselecao.Checked;
                if (!multiselecao.Checked && !_carregando) SelecionarAtiva();
            };
            menu.Items.Add(multiselecao);

            ToolStripMenuItem alternativo = _alternativo = new ToolStripMenuItem(Positron.Data.Interface.MensagensDoReverso.Alternativo)
            {
                CheckOnClick = true,
                Checked = PreferenciasDeFolhas.LerAlternativo(),
            };
            menu.Items.Add(alternativo);

            menu.Items.Add(new ToolStripSeparator());

            // 4 - Nova Página (o `CriarPaginaToolStripMenuItem`, ícone Pagina, mMensagem 29): o
            // `TBNp1Uume8n` do original — parte da **linha selecionada** da grade, e é o mesmo
            // handler da tecla Insert (`uscPaginas.cs:1888-1972`).
            ToolStripMenuItem nova = new ToolStripMenuItem(MensagensDoReverso.NovaPagina);
            Icone(nova, "Pagina");
            nova.ToolTipText = "cria a página entre a linha selecionada e a seguinte (a tecla Insert faz o mesmo)";
            nova.Click += (origem, evento) => ExecutarNaTela(() => NovaPagina());
            menu.Items.Add(nova);

            // 5 - Inserir (mMensagem 35): os **cinco sub-itens das colunas do formato**
            // (`uscPaginas.cs:2466-2565`). O rótulo e a visibilidade de cada um saem da tabela de
            // layers (o `Pagina.verificaLayerExtraNoFormato`), pelo `AtualizarInserir` a cada carga;
            // sem nenhuma coluna o item inteiro fica **invisível** (como lá).
            _inserir = new ToolStripMenuItem(MensagensDoReverso.Inserir);
            Icone(_inserir, "Colunas2");
            _inserir.ToolTipText = "insere as colunas ELET1..5 do formato nas páginas selecionadas";
            for (int i = 1; i <= ColunasDoFormato.Quantidade; i++)
            {
                int indice = i;
                ToolStripMenuItem coluna = new ToolStripMenuItem(string.Empty);
                coluna.Click += (origem, evento) => ExecutarNaTela(() => InserirColuna(indice));
                _colunasDoInserir.Add(coluna);
                _inserir.DropDownItems.Add(coluna);
            }

            menu.Items.Add(_inserir);

            // 6 - Apagar Páginas (no designer é o `ExcluirPáginasToolStripMenuItem`, mas o texto que o
            // usuário lê é a mMensagem 21): a confirmação, a capa recusada, as sincronizações e a
            // seleção de volta — o `cPup1SWxSYc` (`uscPaginas.cs:2145-2222`).
            ToolStripMenuItem excluir = new ToolStripMenuItem(MensagensDoReverso.ApagarPaginas);
            Icone(excluir, "Apagar");
            excluir.ToolTipText = "apaga os elementos e o layer das páginas selecionadas (destrutivo, com confirmação)";
            excluir.Click += (origem, evento) => ExecutarNaTela(() => ApagarSelecionadas());
            menu.Items.Add(excluir);

            // 7 - o `RENPAGA`: a mMensagem 22 diz "Renumerar", e é isso que a regra faz.
            ToolStripMenuItem renumerar = new ToolStripMenuItem(Positron.Data.Interface.MensagensDoReverso.RenumerarPaginas);
            Icone(renumerar, "Renomear");
            renumerar.ToolTipText = "aplica o sufixo do campo ao lado nas páginas do caderno";
            // C8Op1CM1YgS (lote a partir de número informado) ainda não portado.
            // Não reutilizar o RENPAGA, que aplica sufixo e não é esta operação.
            renumerar.Enabled = false;
            menu.Items.Add(renumerar);

            menu.Items.Add(new ToolStripSeparator());

            // 9 a 12 - os quatro `Editar*` (todos com o ícone Editar_16 no original). O
            // `Editar Unidade`/`Editar Alternativo` e o `Editar Títulos` passaram a **ligar** na
            // regra que já existe (o XData `Eletron` da rodada 144 e os títulos da 142): abrem o
            // campo do form do original e regravam pelo adapter. A página vem da linha
            // selecionada na grade e, sem seleção, da página ativa do desenho.
            ToolStripMenuItem editarUnidade = new ToolStripMenuItem(Positron.Data.Interface.MensagensDoReverso.EditarUnidade)
            {
                ToolTipText = "regrava a unidade da página pelo XData Eletron do layer (POSITRON_UNIDADE)",
            };
            Icone(editarUnidade, "Editar_16");
            editarUnidade.Click += (origem, evento) => ExecutarNaTela(() => EditarUnidade());
            menu.Items.Add(editarUnidade);

            ToolStripMenuItem editarAlternativo = _editarAlternativo = new ToolStripMenuItem(Positron.Data.Interface.MensagensDoReverso.EditarAlternativo)
            {
                ToolTipText = "regrava o alternativo da página pelo XData Eletron do layer (POSITRON_ALTERNATIVO)",
            };
            Icone(editarAlternativo, "Editar_16");
            editarAlternativo.Click += (origem, evento) => ExecutarNaTela(() => EditarAlternativo());
            menu.Items.Add(editarAlternativo);

            ToolStripMenuItem editarTitulos = new ToolStripMenuItem(Positron.Data.Interface.MensagensDoReverso.EditarTitulos)
            {
                ToolTipText = "regrava os quatro títulos da página (o XData TituloPagina dos textos do layer)",
            };
            Icone(editarTitulos, "Editar_16");
            editarTitulos.Click += (origem, evento) => ExecutarNaTela(() => EditarTitulos());
            menu.Items.Add(editarTitulos);

            ToolStripMenuItem revisoes = new ToolStripMenuItem(Positron.Data.Interface.MensagensDoReverso.EditarRevisoes)
            {
                ToolTipText = "editar revisões das páginas (simplificada ou completa)",
            };
            Icone(revisoes, "Editar_16");

            ToolStripMenuItem revSimplificada = new ToolStripMenuItem(Positron.Data.Interface.MensagensDoReverso.RevisaoSimplificada)
            {
                ToolTipText = "abre a tela de edição de revisão simplificada (frmEditaRevisaoSimplificada)",
            };
            revSimplificada.Click += (origem, evento) => AbrirRevisaoSimplificada();
            revisoes.DropDownItems.Add(revSimplificada);

            ToolStripMenuItem revCompleta = new ToolStripMenuItem(Positron.Data.Interface.MensagensDoReverso.RevisaoCompleta)
            {
                ToolTipText = "abre a tela de edição de revisão completa (frmEditaRevisaoCompleta)",
            };
            revCompleta.Click += (origem, evento) => AbrirRevisaoCompleta();
            revisoes.DropDownItems.Add(revCompleta);

            menu.Items.Add(revisoes);

            menu.Items.Add(new ToolStripSeparator());

            // 14 - o `Folha`: no original é um **combo** no menu, com os seis formatos literais.
            ToolStripComboBox folha = _formatoDaNumeracao = new ToolStripComboBox
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
                ExecutarNaTela(() =>
                {
                    PreferenciasDeFolhas.GravarAlternativo(alternativo.Checked);
                    AtualizarAlternativo();
                });
            };

            // O original não tem dicas de implementação nos itens.
            LimparDicas(menu.Items);
            AtualizarAlternativo();
            return menu;
        }

        private static void LimparDicas(ToolStripItemCollection itens)
        {
            foreach (ToolStripItem item in itens)
            {
                item.ToolTipText = string.Empty;
                item.AutoToolTip = false;
                ToolStripMenuItem submenu = item as ToolStripMenuItem;
                if (submenu != null) LimparDicas(submenu.DropDownItems);
            }
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

        /// <summary>
        /// A **Nova Página** do menu e da tecla Insert — o `TBNp1Uume8n` do original
        /// (`uscPaginas.cs:1888-1972`): com a grade em multiseleção ele **só avisa** (mMensagem 30);
        /// sem ela, a referência é a **linha selecionada** e a posterior é a **linha seguinte** da
        /// grade (o sentinela `1000000` na última). Cada recusa do original sai no seu `MsgBox`.
        /// </summary>
        internal string NovaPagina()
        {
            if (_grade.MultiSelect)
            {
                UltimaMensagem = MensagensDoReverso.DesativeAMultiselecao;
                Aviso.MsgBox(UltimaMensagem, "Elétron");
                return UltimaMensagem;
            }

            if (_grade.SelectedRows.Count == 0)
            {
                UltimaMensagem = MensagensDoReverso.NovaPagina + ": selecione na grade a página anterior à nova.";
                return UltimaMensagem;
            }

            string anterior;
            string posterior;
            if (!GradeDeFolhas.ReferenciaDaNovaPagina(
                PaginasDaGrade(), _grade.SelectedRows[0].Index, out anterior, out posterior))
            {
                UltimaMensagem = MensagensDoReverso.NovaPagina + ": a linha selecionada não é uma página.";
                return UltimaMensagem;
            }

            Positron.Plugin.Comandos.ResultadoDaNovaPagina resultado =
                Positron.Plugin.Comandos.ExecutarNovaPagina(anterior, posterior);
            UltimaMensagem = resultado.Resumo;
            Carregar();

            // As recusas do original, cada uma no seu MsgBox de informação (`uscPaginas.cs:1948-1963`).
            if (resultado.SemEspaco)
            {
                Aviso.MsgBox(MensagensDoReverso.NaoHaEspacoParaUmaNovaPagina, "Elétron");
            }
            else if (resultado.JaExistia)
            {
                Aviso.MsgBox(MensagensDoReverso.EstaPaginaJaExiste, "Elétron");
            }
            else if (resultado.NaoCriou)
            {
                Aviso.MsgBox(MensagensDoReverso.NaoFoiPossivelCriarEstaPagina, "Elétron");
            }

            return UltimaMensagem;
        }

        /// <summary>
        /// Um dos cinco sub-itens do `Inserir` — a coluna do formato clonada em **cada linha
        /// selecionada** (o `Pagina.InserirColuna` por linha, `uscPaginas.cs:2466-2565`).
        /// </summary>
        internal string InserirColuna(int indice)
        {
            ColunaDoFormato coluna = ColunaDe(indice);
            if (coluna == null || !coluna.Visivel)
            {
                UltimaMensagem = MensagensDoReverso.Inserir + ": a coluna " + indice + " não existe no formato deste desenho.";
                return UltimaMensagem;
            }

            List<string> escolhidas = PaginasSelecionadas();
            if (escolhidas.Count == 0)
            {
                UltimaMensagem = MensagensDoReverso.Inserir + ": selecione a(s) página(s) na grade.";
                return UltimaMensagem;
            }

            int entidades = 0;
            List<string> semColuna = new List<string>();
            foreach (string pagina in escolhidas)
            {
                int criadas = ColunasDoDesenho.Inserir(pagina, coluna.Tipo);
                entidades += criadas;
                if (criadas == 0)
                {
                    semColuna.Add(pagina);
                }
            }

            UltimaMensagem = MensagensDoReverso.Inserir + ": coluna \"" + coluna.Tipo + "\" em "
                + (escolhidas.Count - semColuna.Count) + " de " + escolhidas.Count + " página(s) — "
                + entidades + " entidade(s) clonada(s) do formato"
                + (semColuna.Count > 0
                    ? "; o formato não tem essa coluna nas páginas " + string.Join(", ", semColuna.ToArray())
                    : string.Empty) + ".";
            return UltimaMensagem;
        }

        /// <summary>
        /// O `Apagar Páginas` do menu e da tecla Delete — o `cPup1SWxSYc` do original
        /// (`uscPaginas.cs:2145-2222`): pergunta (mMensagem 23, palavras `Sim`/`Não`), recusa a capa
        /// (mMensagem 17, crítico), apaga o resto com as sincronizações do comando e devolve a
        /// seleção à **linha anterior** (o `JaTp14wdVuV`).
        /// </summary>
        internal string ApagarSelecionadas()
        {
            List<string> escolhidas = PaginasSelecionadas();
            if (escolhidas.Count == 0)
            {
                UltimaMensagem = MensagensDoReverso.ApagarPaginas + ": selecione a(s) página(s) na grade.";
                return UltimaMensagem;
            }

            if (!ConfirmacaoDoUsuario.Perguntar(
                MensagensDoReverso.ApagarAsPaginasSelecionadas, MensagensDoReverso.Sim, MensagensDoReverso.Nao))
            {
                UltimaMensagem = MensagensDoReverso.ApagarPaginas + ": cancelado (a resposta não foi \""
                    + MensagensDoReverso.Sim + "\").";
                return UltimaMensagem;
            }

            // A linha que fica selecionada sai da grade **antes** de apagar (o `JaTp14wdVuV`).
            int linha = GradeDeFolhas.LinhaAposApagar(LinhasSelecionadas());

            List<string> apagaveis = new List<string>();
            foreach (string pagina in escolhidas)
            {
                if (Positron.Data.Paginas.PaginaAtiva.ChecaCapa(pagina))
                {
                    Aviso.MsgBoxCritico(MensagensDoReverso.CapaNaoPodeSerApagada, "Elétron");
                    continue;
                }

                apagaveis.Add(pagina);
            }

            if (apagaveis.Count == 0)
            {
                UltimaMensagem = MensagensDoReverso.ApagarPaginas + ": nada apagado (a capa não se apaga).";
                Carregar();
                return UltimaMensagem;
            }

            Positron.Plugin.Comandos.ResultadoDaExclusao resultado =
                Positron.Plugin.Comandos.ExecutarExclusaoDePaginas(apagaveis);
            UltimaMensagem = resultado.Resumo;
            foreach (string falha in resultado.Falhas)
            {
                Aviso.MsgBoxCritico(falha, "Elétron");
            }

            if (resultado.Sincronizacoes.Length > 0)
            {
                Plugin.Escrever(MensagensDoReverso.ApagarPaginas + " — sincronizações: " + resultado.Sincronizacoes);
            }

            bool multiselecao = _grade.MultiSelect;
            Carregar();
            Multiselecao = multiselecao;
            SelecionarLinha(linha);
            return UltimaMensagem;
        }

        /// <summary>As páginas selecionadas na grade (para o resumo do `pzFolhas`).</summary>
        internal IReadOnlyList<string> Selecionadas()
        {
            return PaginasSelecionadas();
        }

        /// <summary>As páginas das linhas selecionadas, na ordem da grade.</summary>
        private List<string> PaginasSelecionadas()
        {
            List<string> escolhidas = new List<string>();
            foreach (DataGridViewRow linha in _grade.SelectedRows)
            {
                if (linha.Cells.Count > 0 && linha.Cells[0].Value != null)
                {
                    escolhidas.Add(linha.Cells[0].Value.ToString());
                }
            }

            return escolhidas;
        }

        /// <summary>Os índices das linhas selecionadas (para o `JaTp14wdVuV`).</summary>
        private List<int> LinhasSelecionadas()
        {
            List<int> linhas = new List<int>();
            foreach (DataGridViewRow linha in _grade.SelectedRows)
            {
                linhas.Add(linha.Index);
            }

            return linhas;
        }

        /// <summary>Os nomes da coluna Página, na ordem da grade (a referência da Nova Página).</summary>
        private List<string> PaginasDaGrade()
        {
            List<string> paginas = new List<string>();
            foreach (DataGridViewRow linha in _grade.Rows)
            {
                paginas.Add(linha.Cells.Count > 0 && linha.Cells[0].Value != null
                    ? linha.Cells[0].Value.ToString()
                    : string.Empty);
            }

            return paginas;
        }

        /// <summary>Quantas páginas a grade mostra (o `Carregar` sem recarregar).</summary>
        internal IReadOnlyList<string> Paginas()
        {
            return PaginasDaGrade();
        }

        internal string DescreverInterface()
        {
            List<string> colunas = new List<string>();
            foreach (DataGridViewColumn coluna in _grade.Columns)
                if (coluna.Visible) colunas.Add(coluna.HeaderText);
            return "interface: " + _grade.Columns.Count + " colunas [" + string.Join(" | ", colunas.ToArray())
                + "]; tbPagina=" + _pagina.Text + "; multiseleção=" + _grade.MultiSelect
                + "; controles=" + Controls.Count;
        }

        /// <summary>As cinco colunas do formato da última carga (a prova do harness).</summary>
        internal IReadOnlyList<ColunaDoFormato> Colunas()
        {
            return _colunas;
        }

        /// <summary>Seleciona e mostra a linha pedida — o fim do handler do original.</summary>
        private void SelecionarLinha(int linha)
        {
            if (linha < 0 || linha >= _grade.Rows.Count)
            {
                return;
            }

            // O `ClearSelection` de um DataGridView fora da tela (sem Handle) deixa a `CurrentCell`
            // na linha 0 e ela volta a selecionar a linha 0 quando se marca outra em `MultiSelect = false`.
            // Movendo a `CurrentCell` para a linha alvo a seleção vale tanto na tela quanto no harness.
            _grade.ClearSelection();
            if (_grade.Rows[linha].Cells.Count > 0)
            {
                _grade.CurrentCell = _grade.Rows[linha].Cells[0];
            }

            _grade.Rows[linha].Selected = true;
            try
            {
                _grade.FirstDisplayedScrollingRowIndex = linha;
            }
            catch (InvalidOperationException)
            {
                // Sem Handle criado o scroll não tem barra para rolar; a seleção já está na linha.
            }
        }

        /// <summary>
        /// Seleciona na grade as páginas pedidas — o harness não tem quem clique (o `pzFolhas` usa
        /// isto para pôr a grade no estado em que o usuário a deixaria). Devolve quantas achou.
        /// </summary>
        internal int Selecionar(IReadOnlyList<string> paginas)
        {
            _grade.ClearSelection();
            int achadas = 0;
            if (paginas == null)
            {
                return achadas;
            }

            bool primeira = true;
            foreach (string pagina in paginas)
            {
                foreach (DataGridViewRow linha in _grade.Rows)
                {
                    if (linha.Cells.Count == 0 || linha.Cells[0].Value == null)
                    {
                        continue;
                    }

                    if (string.Equals(linha.Cells[0].Value.ToString(), (pagina ?? string.Empty).Trim(), System.StringComparison.OrdinalIgnoreCase))
                    {
                        if (primeira && linha.Cells.Count > 0)
                        {
                            // Tira a `CurrentCell` da linha 0 (mesma armadilha do `SelecionarLinha`).
                            _grade.CurrentCell = linha.Cells[0];
                            primeira = false;
                        }

                        linha.Selected = true;
                        achadas++;
                        break;
                    }
                }
            }

            return achadas;
        }

        /// <summary>A multiseleção da grade (o item do menu) — o harness liga pela prova das recusas.</summary>
        internal bool Multiselecao
        {
            get { return _grade.MultiSelect; }
            set { _multiselecao.Checked = value; }
        }

        /// <summary>A coluna do formato pelo número do sub-item (1..5), tal como a última carga a leu.</summary>
        private ColunaDoFormato ColunaDe(int indice)
        {
            foreach (ColunaDoFormato coluna in _colunas)
            {
                if (coluna.Indice == indice)
                {
                    return coluna;
                }
            }

            return null;
        }

        /// <summary>
        /// O `Inserir` a cada carga (o `CarregaPG` do original, `uscPaginas.cs:1376-1393`): o rótulo
        /// do sub-item é o resto do nome do layer e, sem nenhuma coluna, o item inteiro desaparece.
        /// </summary>
        private void AtualizarInserir()
        {
            _colunas = ColunasDoDesenho.Ler();
            for (int i = 0; i < _colunasDoInserir.Count && i < _colunas.Count; i++)
            {
                _colunasDoInserir[i].Text = _colunas[i].Nome;
                _colunasDoInserir[i].Visible = _colunas[i].Visivel;
            }

            if (_inserir != null)
            {
                _inserir.Visible = ColunasDoFormato.TemAlguma(_colunas);
            }
        }

        /// <summary>
        /// As teclas da grade (`wZ0p1XlFJ5o`, `uscPaginas.cs:1859-1884`): só no desenho do Elétron
        /// (tipo `E`) o **Insert** cria a página e o **Delete** apaga as selecionadas — os mesmos
        /// handlers dos itens do menu.
        /// </summary>
        private void GradeKeyDown(object origem, KeyEventArgs evento)
        {
            Document documento = AplicacaoDoCad.DocumentManager.MdiActiveDocument;
            if (documento == null
                || !string.Equals(InicioDoDesenho.TipoDoDesenho(documento), "E", System.StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            if (evento.KeyCode == Keys.Insert)
            {
                ExecutarNaTela(() => NovaPagina());
            }
            else if (evento.KeyCode == Keys.Delete)
            {
                ExecutarNaTela(() => ApagarSelecionadas());
            }
        }

        /// <summary>Relê as páginas do desenho e preenche a grade. Devolve quantas achou.</summary>
        internal int Carregar()
        {
            List<string> paginas = PaginasDoDesenho.Ler();
            PaginaAtiva = PaginaAtivaDoDesenho.Ler();
            _carregando = true;
            try
            {
                _multiselecao.Checked = false;
                _capturarAtalho = false;
                _pagina.Text = PaginaAtiva;
                string[] atalhos = AtalhosDePaginasDoDesenho.Ler();
                for (int i = 0; i < _atalhos.Length; i++) _atalhos[i].Text = atalhos[i];

                AtualizarInserir();
                int largura = ConfiguracaoEfetiva.Carregar().LarguraFixaPaginas;
                _formatoDaNumeracao.Text = largura >= 3 && largura <= 7
                    ? "12".PadLeft(largura, '0') : "12";
                _progresso.Maximum = Math.Max(1, paginas.Count);
                _progresso.Value = 0;
                _grade.Rows.Clear();
                for (int i = 0; i < paginas.Count; i++)
                {
                    string unidade;
                    string alternativo;
                    UnidadeDaPaginaDoDesenho.Ler(paginas[i], out unidade, out alternativo);
                    _grade.Rows.Add(paginas[i], unidade, alternativo, paginas[i],
                        PaginaNumerada.Decimal(paginas[i]).ToString("0.00"));
                    _progresso.Increment(1);
                }

                SelecionarAtiva();
                AtualizarAlternativo();
                return paginas.Count;
            }
            finally
            {
                _progresso.Value = 0;
                _carregando = false;
            }
        }

        private void SelecionarAtiva()
        {
            for (int i = 0; i < _grade.Rows.Count; i++)
                if (string.Equals(Convert.ToString(_grade.Rows[i].Cells[0].Value), PaginaAtiva, StringComparison.OrdinalIgnoreCase))
                {
                    SelecionarLinha(i);
                    break;
                }
        }

        private void AtualizarAlternativo()
        {
            if (_alternativo == null || _editarAlternativo == null) return;
            Document documento = AplicacaoDoCad.DocumentManager.MdiActiveDocument;
            string tipo = documento == null ? "" : InicioDoDesenho.TipoDoDesenho(documento);
            bool outro = tipo == "D" || tipo == "A" || tipo == "V";
            bool mostrar = _alternativo.Checked && !outro;
            _grade.Columns[2].Visible = mostrar;
            _editarAlternativo.Visible = _alternativo.Checked;
            _grade.Columns[0].FillWeight = mostrar ? 1 : 2;
            _grade.Columns[1].FillWeight = mostrar ? 1 : 3;
            _grade.Columns[2].FillWeight = 1;
            _grade.ReadOnly = outro;
            if (_menu != null) _grade.ContextMenuStrip = outro ? null : _menu;
        }

        internal void IrParaPagina(string pagina)
        {
            Multiselecao = false;
            string alvo = CriacaoDePagina.Normalizar((pagina ?? "").Trim().ToUpperInvariant(), ConfiguracaoEfetiva.Carregar().LarguraFixaPaginas);
            foreach (string existente in PaginasDaGrade())
                if (string.Equals(existente, alvo, StringComparison.OrdinalIgnoreCase))
                {
                    AtivarPagina(existente);
                    SelecionarAtiva();
                    return;
                }
            _pagina.Text = PaginaAtiva;
        }

        private void AtivarPagina(string pagina)
        {
            if (string.IsNullOrEmpty(pagina)) return;
            PaginaAtivaDoDesenho.Ativar(pagina);
            PaginaAtiva = PaginaAtivaDoDesenho.Ler();
            _pagina.Text = PaginaAtiva;
        }

        private void UsarAtalho(int indice)
        {
            if (_capturarAtalho)
            {
                AtalhosDePaginasDoDesenho.Gravar(indice, PaginaAtivaDoDesenho.Ler());
                _atalhos[indice].Text = PaginaAtivaDoDesenho.Ler();
                _capturarAtalho = false;
                return;
            }
            string alvo = _atalhos[indice].Text;
            if (alvo.Length == 0) return;
            IrParaPagina(alvo);
            if (!string.Equals(PaginaAtiva, alvo, StringComparison.OrdinalIgnoreCase))
            {
                AtalhosDePaginasDoDesenho.Gravar(indice, "");
                _atalhos[indice].Text = "";
            }
        }

        internal void ProgressoIniciar(int quantidade)
        {
            _progresso.Value = 0;
            _progresso.Maximum = Math.Max(0, quantidade);
        }

        internal void ProgressoPasso() { _progresso.Increment(1); }
        internal void ProgressoFim() { _progresso.Value = 0; }

        private static void AtualizarContagem()
        {
            Document documento = AplicacaoDoCad.DocumentManager.MdiActiveDocument;
            if (documento == null) return;
            using (documento.LockDocument()) RestauracaoDoFormatoDoDesenho.AtualizarContTotFl(documento.Database);
        }

        private static void ExecutarNaTela(Action acao)
        {
            try { acao(); }
            catch (Exception erro) { Aviso.MsgBoxCritico(erro.Message, "Elétron"); }
        }

        /// <summary>A página selecionada na grade (todas as colunas têm o mesmo nome).</summary>
        private string PaginaSelecionada()
        {
            if (_grade.SelectedRows.Count == 0 || _grade.SelectedRows[0].Cells.Count == 0)
            {
                return string.Empty;
            }

            object valor = _grade.SelectedRows[0].Cells[0].Value;
            return valor == null ? string.Empty : valor.ToString();
        }

        /// <summary>
        /// A página que o item `Editar*` do menu edita: a linha selecionada na grade e, sem seleção,
        /// a **página ativa** (o que o item do original edita quando nada está marcado).
        /// </summary>
        private string PaginaParaEditar()
        {
            string escolhida = PaginaSelecionada();
            if (escolhida.Length > 0)
            {
                return escolhida;
            }

            if (PaginaAtiva.Length > 0)
            {
                return PaginaAtiva;
            }

            return string.Empty;
        }

        /// <summary>O `Editar Unidade` do menu: o campo do form e a regravação pelo XData do layer.</summary>
        internal string EditarUnidade()
        {
            string pagina = PaginaParaEditar();
            if (pagina.Length == 0)
            {
                UltimaMensagem = "Editar Unidade: selecione a página na grade (ou ative uma página).";
                return UltimaMensagem;
            }

            string unidade;
            string alternativo;
            UnidadeDaPaginaDoDesenho.Ler(pagina, out unidade, out alternativo);

            string escolhida;
            if (!FormularioDeCampoDaPagina.Perguntar(
                Positron.Data.Interface.MensagensDoReverso.EditarUnidade,
                Positron.Data.Interface.MensagensDoReverso.Unidade,
                pagina,
                unidade,
                out escolhida))
            {
                UltimaMensagem = "Editar Unidade: cancelado.";
                return UltimaMensagem;
            }

            bool gravou = UnidadeDaPaginaDoDesenho.Gravar(pagina, escolhida ?? string.Empty, alternativo);
            Carregar();
            UltimaMensagem = "Editar Unidade: página \"" + pagina + "\" — unidade=\"" + (escolhida ?? string.Empty)
                + "\"" + (gravou ? " regravada pelo XData Eletron do layer." : " — o layer da página não existe.");
            return UltimaMensagem;
        }

        /// <summary>O `Editar Alternativo` do menu.</summary>
        internal string EditarAlternativo()
        {
            string pagina = PaginaParaEditar();
            if (pagina.Length == 0)
            {
                UltimaMensagem = "Editar Alternativo: selecione a página na grade (ou ative uma página).";
                return UltimaMensagem;
            }

            string unidade;
            string alternativo;
            UnidadeDaPaginaDoDesenho.Ler(pagina, out unidade, out alternativo);

            string escolhido;
            if (!FormularioDeCampoDaPagina.Perguntar(
                Positron.Data.Interface.MensagensDoReverso.EditarAlternativo,
                Positron.Data.Interface.MensagensDoReverso.Alternativo,
                pagina,
                alternativo,
                out escolhido))
            {
                UltimaMensagem = "Editar Alternativo: cancelado.";
                return UltimaMensagem;
            }

            bool gravou = UnidadeDaPaginaDoDesenho.Gravar(pagina, unidade, escolhido ?? string.Empty);
            Carregar();
            UltimaMensagem = "Editar Alternativo: página \"" + pagina + "\" — alternativo=\"" + (escolhido ?? string.Empty)
                + "\"" + (gravou ? " regravado pelo XData Eletron do layer." : " — o layer da página não existe.");
            return UltimaMensagem;
        }

        /// <summary>O `Editar Títulos` abre a grade não modal do caderno, não um diálogo de página.</summary>
        internal string EditarTitulos()
        {
            foreach (Form janela in System.Windows.Forms.Application.OpenForms)
                if (janela.Name == "frmEditaTitulos")
                {
                    janela.Activate();
                    return UltimaMensagem;
                }
            UltimaMensagem = Telas.RenderizadorDeTelas.Abrir("frmEditaTitulos", "Editar os Títulos");
            return UltimaMensagem;
        }

        private void AbrirRevisaoSimplificada()
        {
            UltimaMensagem = Telas.RenderizadorDeTelas.Abrir("frmEditaRevisaoSimplificada", "REVSIMP");
        }

        private void AbrirRevisaoCompleta()
        {
            UltimaMensagem = Telas.RenderizadorDeTelas.Abrir("frmEditaRevisaoCompleta", "REVCOMP");
        }
    }
}

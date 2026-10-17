using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Positron.Data;
using Positron.Data.Configuracao;
using Positron.Data.Interface;
using Positron.Plugin.Configuracao;
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

        /// <summary>A cor/estado já mandada ao controle (o `SendMessage` sai quando ela muda).</summary>
        private CorDaBarra _corDaBarra = CorDaBarra.Verde;
        private bool _capturarAtalho;
        private bool _carregando;

        /// <summary>
        /// A grade sendo reconstruída **dentro** de um evento dela (a edição inline da célula
        /// Página chama o `Carregar` no `CellEndEdit`, como o `Y9op1KgeRgW`/`VSWp1ebyWra` do
        /// original): o DataGridView entrega a seleção que sobrou da reconstrução **depois** de o
        /// `finally` do `Carregar` já ter baixado o <see cref="_carregando"/> — sem esta guarda o
        /// `SelectionChanged` atrasado ativa a linha seguinte (medido na rodada 222: renomear a
        /// página ativa 7 → 7A terminava com o desenho na 8). Sai no primeiro `Application.Idle`.
        /// </summary>
        private bool _reconstruindoSelecao;
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
            _grade.DefaultCellStyle.BackColor = SystemColors.Control;
            _menu = MenuDoReverso();
            _grade.ContextMenuStrip = _menu;
            _grade.SelectionChanged += (origem, evento) =>
            {
                if (_carregando || _reconstruindoSelecao) return;
                if (!_grade.MultiSelect && _grade.SelectedRows.Count == 1)
                    ExecutarNaTela(() => AtivarPagina(PaginaSelecionada()));
            };
            _grade.CellEndEdit += (origem, evento) =>
                ExecutarNaTela(() => EditarCelula(evento.RowIndex, evento.ColumnIndex));
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
            // O `PictureBox2` do designer do original: 31 × 17 em (16, 7), nascendo `DB_DISCONNECTED`
            // (`uscPaginas.cs:1209-1214`) — e quem o troca é o `statusBanco` (`:2606-2617`), avisado a
            // cada mudança do contador de conexões (`DeclaracoesGeral.monitorConexao`).
            _statusBanco = new PictureBox { Name = "PictureBox2", Left = 16, Top = 7,
                Size = new Size(31, 17), Image = IconesEmbutidos.BitmapDe("DB_DISCONNECTED") };
            MonitorDeConexao.Atual.Mudou += AoMudarAsConexoes;
            // O `ProgressBar1` do designer do original (`uscPaginas.cs:1203-1208`: âncora inferior,
            // 7 de altura e `ForeColor` transparente) — e quem o move é o `pbIniciar`/`pbPasso`/
            // `pbFim` (`:1247-1269`), aqui na regra `ProgressoCompartilhado`.
            _progresso = new ProgressBar { Name = "ProgressBar1", Left = 9, Top = Height - 46,
                Size = new Size(Width - 18, 7), Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                ForeColor = Color.Transparent };
            Progresso.Mudou += AoMudarOProgresso;
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

            // 7 - o `Renumerar Páginas` (mMensagem 22): o `C8Op1CM1YgS` — pergunta o destino
            // (mMensagem 24) e move as linhas **selecionadas** a partir dele. Não é o `RENPAGA`,
            // que aplica sufixo ao caderno inteiro.
            ToolStripMenuItem renumerar = new ToolStripMenuItem(Positron.Data.Interface.MensagensDoReverso.RenumerarPaginas);
            Icone(renumerar, "Renomear");
            renumerar.Click += (origem, evento) => ExecutarNaTela(() => RenumerarSelecionadas());
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
            // Escolher (ou digitar) um formato é o `Es6p1Y15jTb` (`uscPaginas.cs:2389`): grava a
            // largura na configuração do desenho e renumera **todas** as páginas.
            ToolStripComboBox folha = _formatoDaNumeracao = new ToolStripComboBox
            {
                Name = "FolhaToolStripMenuItem",
                FlatStyle = FlatStyle.Standard,
                BackColor = Color.LightGray,
            };
            foreach (string formato in Positron.Data.Interface.MensagensDoReverso.FormatosDeFolha)
            {
                folha.Items.Add(formato);
            }

            folha.TextChanged += (origem, evento) =>
            {
                // A carga da paleta escreve o texto do combo; o original tem a mesma guarda
                // (o `fKqplRiGop5` em volta do `CarregaPG`).
                if (_carregando) return;
                ExecutarNaTela(() => AplicarFormatoDaNumeracao());
            };

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
        /// O item **Renumerar Páginas** — o `C8Op1CM1YgS` do original (`uscPaginas.cs:2247-2390`):
        /// tira a primeira linha da seleção, pergunta "Mover para página?" (mMensagem 24),
        /// **volta a perguntar** enquanto a resposta é recusada, move as linhas selecionadas pela
        /// regra pura (<see cref="RenumeracaoComDestino"/>) e roda as sincronizações do original.
        /// </summary>
        internal string RenumerarSelecionadas()
        {
            // O original tira a **primeira linha** da seleção antes de montar as duas listas
            // (`dg.Rows[0].Selected = false`): ela volta para o lado das não selecionadas — o
            // destino que já existe e o limite do espaço contam com ela (é a capa, que não se move).
            if (_grade.Rows.Count > 0 && _grade.Rows[0].Selected)
            {
                _grade.Rows[0].Selected = false;
            }

            // As duas listas do original saem do mesmo laço sobre `dg.Rows` **na ordem da grade**
            // (ao contrário do Inserir e do Apagar, que percorrem `dg.SelectedRows`): é essa ordem
            // que casa cada página selecionada com o seu nome novo.
            List<string> escolhidas = new List<string>();
            List<string> outras = new List<string>();
            foreach (DataGridViewRow linha in _grade.Rows)
            {
                if (linha.Cells.Count == 0)
                {
                    continue;
                }

                string pagina = Convert.ToString(linha.Cells[0].Value);
                if (linha.Selected)
                {
                    escolhidas.Add(pagina);
                }
                else
                {
                    outras.Add(pagina);
                }
            }

            Positron.Data.Configuracao.ConfiguracaoPositron config = ConfiguracaoEfetiva.Carregar();
            string titulo = MensagensDoReverso.RenumerarPaginas;
            while (true)
            {
                string resposta;
                if (!PerguntaDeRenumeracao.Perguntar(out resposta))
                {
                    return UltimaMensagem = titulo + ": cancelado (nenhuma página foi movida).";
                }

                // A recusa estoura a exceção da regra (o destino que o original também não consegue
                // converter) e sobe para o `MsgBox` crítico do handler, como lá.
                RenumeracaoComDestino.Plano plano = RenumeracaoComDestino.Planejar(
                    resposta, config.LarguraFixaPaginas, config.PassoPagina, escolhidas, outras);
                if (!plano.Aplicar)
                {
                    // O `Interaction.MsgBox` do original está **dentro** do laço: avisa e pergunta de
                    // novo. As quatro recusas (57/26/25/27) saem com `MsgBoxStyle.Information` e
                    // **sem título** (`uscPaginas.cs:2312,2326,2353,2375`).
                    Aviso.MsgBox(plano.Aviso, string.Empty);
                    continue;
                }

                int renomeados = PaginasDoDesenho.Renomear(escolhidas, plano.Novas);
                Carregar();

                // A família de sincronizações do original (o mesmo stand-in do `Apagar Páginas`).
                Plugin.Escrever(titulo + " — sincronizações: " + Comandos.SincronizacoesDoCaderno());
                return UltimaMensagem = titulo + ": " + renomeados + " de " + escolhidas.Count
                    + " página(s) movida(s) a partir de \"" + plano.Destino + "\"" + Pares(escolhidas, plano.Novas) + ".";
            }
        }

        /// <summary>
        /// O corpo do `Es6p1Y15jTb` — a escolha do formato no combo `Folha`
        /// (`uscPaginas.cs:2389-2455`): grava a largura fixa no XData de configuração do desenho
        /// (o `GravarXDataConfiguracao`), normaliza **todas** as páginas pelo `montaNumeroPagina` e
        /// renomeia os layers. Um texto que não é um dos seis literais não mexe na largura (o
        /// `switch` do original não tem `default`), mas a renumeração acontece igual.
        /// </summary>
        private string AplicarFormatoDaNumeracao()
        {
            string literal = _formatoDaNumeracao.Text;
            int largura;
            bool conhecido = RenumeracaoComDestino.LarguraDoFormatoLiteral(literal, out largura);
            ConfiguracaoDoCaderno caderno = ConfiguracaoDoDesenho.LerOuPadrao();
            if (caderno == null)
            {
                return UltimaMensagem = "Folha: sem desenho ativo.";
            }

            if (conhecido)
            {
                caderno.LarguraFixaPaginas = largura;
            }

            bool gravada = ConfiguracaoDoDesenho.GravarConfig(caderno);
            List<string> antigas = PaginasDaGrade();
            IReadOnlyList<string> novas = RenumeracaoComDestino.Normalizar(antigas, caderno.LarguraFixaPaginas);
            int renomeados = PaginasDoDesenho.Renomear(antigas, novas);
            Carregar();
            AplicacaoDoCad.UpdateScreen();
            return UltimaMensagem = "Folha: " + renomeados + " de " + antigas.Count
                + " página(s) renumerada(s) com a largura " + caderno.LarguraFixaPaginas
                + (conhecido ? string.Empty : " (o texto \"" + literal + "\" não é um formato do combo; a largura foi mantida)")
                + (gravada ? "; configuração gravada no desenho." : "; a configuração NÃO pôde ser gravada.");
        }

        /// <summary>Os pares antigo→novo da movimentação, para o resumo do `pzFolhas`.</summary>
        private static string Pares(IReadOnlyList<string> antigas, IReadOnlyList<string> novas)
        {
            if (antigas == null || novas == null || antigas.Count == 0)
            {
                return string.Empty;
            }

            List<string> pares = new List<string>();
            for (int i = 0; i < antigas.Count && i < novas.Count; i++)
            {
                pares.Add(antigas[i] + "->" + novas[i]);
            }

            return " (" + string.Join(", ", pares.ToArray()) + ")";
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
                // O `catch` por página do original: `MsgBox(ex.Message, Critical)` **sem título**
                // (`uscPaginas.cs:2198`).
                Aviso.MsgBoxCritico(falha, string.Empty);
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

        /// <summary>
        /// O `statusBanco` do reverso (`uscPaginas.cs:2606-2617`): o ícone é o de **conectado**
        /// enquanto houver conexão aberta no contador, e o de desconectado quando ele volta a zero.
        /// O aviso do contador chega de qualquer rotina que leia o banco, dentro ou fora de comando.
        /// </summary>
        private void AoMudarAsConexoes(object origem, EventArgs evento)
        {
            _statusBanco.Image = IconesEmbutidos.BitmapDe(
                MonitorDeConexao.Atual.Conectado ? "DB_CONNECTED" : "DB_DISCONNECTED");
            // O `Application.DoEvents()` do fim do `statusBanco` do original: o ícone aparece já no
            // meio de uma rotina longa, não só quando ela devolve o controle.
            System.Windows.Forms.Application.DoEvents();
        }

        /// <summary>O estado do ícone do banco (a prova do harness): o `DB_CONNECTED` está posto?</summary>
        internal bool BancoConectado()
        {
            return ReferenceEquals(_statusBanco.Image, IconesEmbutidos.BitmapDe("DB_CONNECTED"));
        }

        /// <summary>
        /// O aviso do contador é estático: a paleta sai da lista ao ser descartada (a janela do CAD
        /// pode ser recriada na sessão) para não deixar imagem viva pendurada no evento.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                MonitorDeConexao.Atual.Mudou -= AoMudarAsConexoes;
                Progresso.Mudou -= AoMudarOProgresso;
            }

            base.Dispose(disposing);
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

        /// <summary>
        /// O harness escolhe o formato **pelo próprio combo** (o caminho do usuário): o texto novo
        /// dispara o mesmo `TextChanged` do `Es6p1Y15jTb`.
        /// </summary>
        internal string EscolherFormatoDaNumeracao(string literal)
        {
            int indice = _formatoDaNumeracao.Items.IndexOf(literal);
            if (indice >= 0)
            {
                // O caminho do usuário: escolher o item da lista, não digitar no campo.
                _formatoDaNumeracao.SelectedIndex = indice;
            }
            else
            {
                _formatoDaNumeracao.Text = literal;
            }

            return UltimaMensagem;
        }

        /// <summary>O texto atual do combo `Folha` (a prova confere se a carga o devolveu).</summary>
        internal string FormatoDaNumeracao()
        {
            return _formatoDaNumeracao.Text;
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
                _grade.Rows.Clear();
                for (int i = 0; i < paginas.Count; i++)
                {
                    string unidade;
                    string alternativo;
                    UnidadeDaPaginaDoDesenho.Ler(paginas[i], out unidade, out alternativo);
                    _grade.Rows.Add(paginas[i], unidade, alternativo, paginas[i],
                        PaginaNumerada.Decimal(paginas[i]).ToString("0.00"));
                }

                SelecionarAtiva();
                AtualizarAlternativo();
                return paginas.Count;
            }
            finally
            {
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

        /// <summary>
        /// O fim da edição de uma célula da grade — o `j9Sp1mKZkcD` do reverso
        /// (`uscPaginas.cs:1733-1846`): a coluna Página renomeia a página (ou reverte), a Unidade e
        /// o Alternativo regravam o XData `Eletron` do layer.
        /// </summary>
        private void EditarCelula(int linha, int coluna)
        {
            if (linha < 0 || linha >= _grade.Rows.Count || coluna < 0 || coluna > 2)
            {
                return;
            }

            if (coluna == 0)
            {
                RenomearPaginaInline(linha);
                return;
            }

            DataGridViewRow linhaDaGrade = _grade.Rows[linha];
            string unidade = Convert.ToString(linhaDaGrade.Cells[1].Value).Trim();
            string alternativo = Convert.ToString(linhaDaGrade.Cells[2].Value).Trim();
            if (alternativo.Length > 20)
            {
                alternativo = alternativo.Substring(0, 20);
                // O `Interaction.MsgBox(mMensagem[1, 1927])` do `j9Sp1mKZkcD`: **sem estilo** (um
                // OK sem ícone) e sem título (`uscPaginas.cs:1773`).
                Aviso.MsgBoxSemIcone(MensagensDoReverso.MaximoDe20Caracteres);
            }

            linhaDaGrade.Cells[1].Value = unidade;
            linhaDaGrade.Cells[2].Value = alternativo;
            UnidadeDaPaginaDoDesenho.Gravar(Convert.ToString(linhaDaGrade.Cells[0].Value), unidade, alternativo);
            if (coluna == 2) AtualizarContagem();
        }

        /// <summary>
        /// A **edição inline da célula Página** (o ramo `ColumnIndex == 0` do `j9Sp1mKZkcD`,
        /// `uscPaginas.cs:1733-1846`): o texto que ficou na célula passa pela regra pura
        /// (<see cref="RenomeacaoInlineDaPagina"/>) e, quando vale, o layer é renomeado pelo
        /// `Pagina.renumerarPagina` — com o aviso da mMensagem 28 quando o nome já é página. Na
        /// recusa a célula volta ao nome carregado (a coluna técnica `Pg`), inclusive na **primeira
        /// linha** (a capa). A grade é reconstruída e a linha da ativa volta marcada (o
        /// `Y9op1KgeRgW`/`VSWp1ebyWra` do original). O harness chama este método: é o mesmo caminho
        /// que o `CellEndEdit` da grade dispara.
        /// </summary>
        internal string RenomearPaginaInline(int linha)
        {
            if (linha < 0 || linha >= _grade.Rows.Count)
            {
                return UltimaMensagem;
            }

            DataGridViewRow linhaDaGrade = _grade.Rows[linha];
            string original = Convert.ToString(linhaDaGrade.Cells[3].Value);
            int largura = ConfiguracaoEfetiva.Carregar().LarguraFixaPaginas;
            // As páginas do caderno saem do **desenho** (o `mPaginas` que o `renumerarPagina`
            // percorre), não da grade: a célula em edição já carrega o nome digitado e não conta.
            PlanoDaRenomeacaoInline plano = RenomeacaoInlineDaPagina.Planejar(
                Convert.ToString(linhaDaGrade.Cells[0].Value), original,
                PaginaAtivaDoDesenho.Ler(), largura, PaginasDoDesenho.Ler(), linha == 0);

            linhaDaGrade.Cells[0].Value = plano.Nome;
            if (plano.Aviso != null)
            {
                // O `Interaction.MsgBox(..., Information)` do `renumerarPagina` (mMensagem 28):
                // informação e **sem título** (`Pagina.cs:1855`).
                Aviso.MsgBox(plano.Aviso, string.Empty);
            }

            string nomeNovo = plano.Nome;
            if (plano.Acao == AcaoDaRenomeacaoInline.Renomear)
            {
                int renomeados = PaginasDoDesenho.Renomear(new[] { original }, new[] { nomeNovo });
                if (renomeados == 0)
                {
                    // O `alteraNomeLayer` que devolve false: a célula volta ao nome original.
                    linhaDaGrade.Cells[0].Value = original;
                    nomeNovo = original;
                    UltimaMensagem = MensagensDoReverso.Pagina + ": não foi possível renomear \"" + original + "\".";
                }
                else
                {
                    // O `AtualizaContTotFl` do `renumerarPagina` e o `tbPagina.Text = text2` do handler.
                    AtualizarContagem();
                    SegurarSelecaoDuranteReconstrucao();
                    Carregar();
                    _pagina.Text = nomeNovo;
                    UltimaMensagem = MensagensDoReverso.Pagina + ": \"" + original + "\" → \"" + nomeNovo + "\"; "
                        + renomeados + " layer(s) renomeado(s).";
                }
            }
            else if (plano.Acao == AcaoDaRenomeacaoInline.JaExiste)
            {
                UltimaMensagem = MensagensDoReverso.Pagina + ": " + plano.Aviso;
            }
            else if (plano.Acao == AcaoDaRenomeacaoInline.EscreverAtiva)
            {
                UltimaMensagem = MensagensDoReverso.Pagina + ": célula vazia — escrita a página ativa \""
                    + plano.Nome + "\" (sem renomear).";
            }
            else if (plano.Acao == AcaoDaRenomeacaoInline.Escrever)
            {
                UltimaMensagem = MensagensDoReverso.Pagina + ": \"" + nomeNovo + "\" (nome inalterado).";
            }
            else if (linha == 0)
            {
                UltimaMensagem = MensagensDoReverso.Pagina + ": a primeira linha (a capa) não se renomeia; \""
                    + original + "\" mantido.";
            }
            else
            {
                UltimaMensagem = MensagensDoReverso.Pagina + ": \"" + original + "\" não é página válida; mantido.";
            }

            if (plano.RodarSincronizacoes)
            {
                // O mesmo stand-in do Apagar Páginas/Renumerar Páginas (a família clsConexao/… não está portada).
                Plugin.Escrever(MensagensDoReverso.Pagina + " — sincronizações: " + Comandos.SincronizacoesDoCaderno());
            }

            return UltimaMensagem;
        }

        /// <summary>
        /// Segura o `SelectionChanged` até o primeiro `Application.Idle` — a reconstrução dentro do
        /// `CellEndEdit` deixa uma seleção pendente que, sem a guarda, ativa a linha seguinte.
        /// </summary>
        private void SegurarSelecaoDuranteReconstrucao()
        {
            // Sem janela não há `Application.Idle` para soltar a guarda: no harness headless o
            // `Carregar` é síncrono e a seleção atrasada não existe.
            if (!_grade.IsHandleCreated) return;

            _reconstruindoSelecao = true;
            EventHandler soltar = null;
            soltar = (origem, evento) =>
            {
                System.Windows.Forms.Application.Idle -= soltar;
                _reconstruindoSelecao = false;
                // A seleção que o DataGridView restaurou sozinho não é a da página ativa: volta
                // para ela, como o `VSWp1ebyWra` do original (sem ativar outra página).
                SelecionarAtiva();
            };
            System.Windows.Forms.Application.Idle += soltar;
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

        /// <summary>
        /// A barra compartilhada — o `ProgressBar1` do original com o `pbIniciar`/`pbPasso`/`pbFim`
        /// (`uscPaginas.cs:1242-1269`). A carga da paleta **não** a move: o `CarregaPG` do original
        /// (`:1327-1400`) não chama nenhum dos três (só as rotinas longas o fazem, por
        /// `DeclaracoesGeral._uscPagina.Quantidade`/`pbIniciar`).
        /// </summary>
        internal ProgressoCompartilhado Progresso { get; } = new ProgressoCompartilhado();

        /// <summary>
        /// O espelho da regra no controle: o original **é** o controle, aqui o estado é da regra e
        /// quem o leva para o `ProgressBar` é este aviso. O `SendMessage` do `pbIniciar`
        /// (`uscPaginas.cs:1242-1245`) sai quando a cor/estado muda — no `accoreconsole` o controle
        /// não tem handle e nada é mandado (a imagem/estado que o harness lê é o da regra).
        /// </summary>
        private void AoMudarOProgresso(object origem, EventArgs evento)
        {
            ProgressoCompartilhado barra = Progresso;
            _progresso.Minimum = barra.Minimo;
            _progresso.Maximum = barra.Maximo;
            _progresso.Step = barra.Incremento;
            _progresso.Value = barra.Valor;
            if (barra.Cor == _corDaBarra)
            {
                return;
            }

            _corDaBarra = barra.Cor;
            if (_progresso.IsHandleCreated)
            {
                SendMessage(_progresso.Handle, ProgressoCompartilhado.MensagemDeEstado, (int)barra.Cor, 0);
            }
        }

        /// <summary>
        /// O `SendMessage(IntPtr, int, int, int)` que o original declara no próprio controle
        /// (`uscPaginas.cs:1238-1241`) e usa para o estado da barra (a mensagem 1040 é o
        /// `PBM_SETSTATE`).
        /// </summary>
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto,
            SetLastError = true)]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        private static void AtualizarContagem()
        {
            Document documento = AplicacaoDoCad.DocumentManager.MdiActiveDocument;
            if (documento == null) return;
            using (documento.LockDocument()) RestauracaoDoFormatoDoDesenho.AtualizarContTotFl(documento.Database);
        }

        private static void ExecutarNaTela(Action acao)
        {
            try { acao(); }
            catch (Exception erro) { Aviso.MsgBoxCritico(erro.Message, string.Empty); }
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

        /// <summary>uscPaginas.bt6p1Bww9xD: um prompt, todas as linhas selecionadas.</summary>
        internal string EditarUnidade() { return EditarCampo(false); }

        /// <summary>uscPaginas.T5Qp1VoBCME: também recalcula CONT/FL/TOT/Alternativo.</summary>
        internal string EditarAlternativo() { return EditarCampo(true); }

        private string EditarCampo(bool alternativo)
        {
            string titulo = alternativo ? MensagensDoReverso.EditarAlternativo : MensagensDoReverso.EditarUnidade;
            if (_grade.SelectedRows.Count == 0)
                return UltimaMensagem = titulo + ": nenhuma linha selecionada.";

            // Captura as linhas antes do prompt; não recarrega a grade nem perde a multiseleção.
            List<DataGridViewRow> linhas = new List<DataGridViewRow>();
            foreach (DataGridViewRow linha in _grade.SelectedRows) linhas.Add(linha);
            Document documento = AplicacaoDoCad.DocumentManager.MdiActiveDocument;
            int coluna = alternativo ? 2 : 1;
            string resposta;
            if (!PerguntaDeCampoDaPagina.Perguntar(alternativo,
                Convert.ToString(linhas[0].Cells[coluna].Value), out resposta))
                return UltimaMensagem = titulo + ": cancelado.";
            // Não aplicar uma seleção capturada de outro documento após um prompt modeless.
            if (documento == null || documento != AplicacaoDoCad.DocumentManager.MdiActiveDocument)
                return UltimaMensagem = titulo + ": documento alterado.";

            string valor = UnidadeDaPaginaXData.NormalizarRespostaDoMenu(resposta);
            foreach (DataGridViewRow linha in linhas)
            {
                string unidade = alternativo ? Convert.ToString(linha.Cells[1].Value) : valor;
                string nomeAlternativo = alternativo ? valor : Convert.ToString(linha.Cells[2].Value);
                if (!UnidadeDaPaginaDoDesenho.Gravar(Convert.ToString(linha.Cells[0].Value), unidade, nomeAlternativo))
                    throw new InvalidOperationException("Layer da página não encontrado.");
                linha.Cells[coluna].Value = valor;
            }
            // Os leitores do recoder consultam o desenho, não mantêm mPaginas em cache.
            if (alternativo)
            {
                AtualizarContagem();
                AplicacaoDoCad.UpdateScreen();
            }
            return UltimaMensagem = titulo + ": " + linhas.Count + " página(s); valor=\"" + valor + "\".";
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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Positron.Data.Configuracao;
using Positron.Data.Materiais;
using Positron.Data.Modelos;
using Positron.Plugin.Configuracao;
using Positron.Plugin.Modelos;

namespace Positron.Plugin.Interface.Telas
{
    /// <summary>
    /// A ligação do <c>frmGerenciadorContatos</c> (o comando <c>GERCONT</c>):
    /// - a grade <c>DGModelo</c> preenchida com os modelos de contato do desenho (<see cref="ContatosDoDesenho.LerModelos"/>);
    /// - a grade <c>DGContato</c> preenchida com os contatos auxiliares do modelo selecionado (<see cref="ContatosDoDesenho.LerAuxiliares"/>);
    /// - as caixas de texto do modelo (<c>TBModelo</c>, <c>TBTerminais</c>, <c>tbOrientacao</c>, <c>tbBlocoTopografico</c>, <c>tbBlocoLayout</c>);
    /// - o catálogo de materiais resolvendo os códigos LM1 e LM2 (<c>tbCodigo*</c>, <c>tbDescricaoResum*</c>, <c>tbModelo*</c>, <c>tbFabricante*</c>);
    /// - as caixas do contato auxiliar selecionado (<c>TBT1</c>, <c>TBT2</c>, <c>TBT3</c>, <c>tbOrientacaoTerminais</c>, <c>CBTipo</c>, <c>CBComportamento</c>);
    /// - como o construtor do original (<c>frmGerenciadorContatos.cs:1960</c>): banco inválido ou DWG sem
    ///   cadastro → <c>MsgBox</c> 331; dicas pelas mMensagens; as grades só ganham colunas quando há linhas
    ///   (<c>clsDispositivo.carregaModelosNoDG :2062</c>, <c>clsDispositivoAuxiliares.carregaContatosNoDG :667</c>),
    ///   com as larguras de <c>AtualizaColunasDGModelos :2123</c> e <c>AtualizaColunasDGContatosAuxiliaresMODELO :1751</c>;
    /// - os botões de edição, gravação e Excel ficam desabilitados (regra ainda não portada), com a dica do original.
    /// </summary>
    internal sealed class LigacaoDoFrmGerenciadorContatos : LigacaoDeModelos
    {
        public override string NomeDaTela
        {
            get { return "frmGerenciadorContatos"; }
        }

        public override void Preencher(Form janela)
        {
            DataGridView dgModelo = ControlesDaTela.Achar<DataGridView>(janela, "DGModelo");
            DataGridView dgContato = ControlesDaTela.Achar<DataGridView>(janela, "DGContato");
            ComboBox cbTipo = ControlesDaTela.Achar<ComboBox>(janela, "CBTipo");
            ComboBox cbComp = ControlesDaTela.Achar<ComboBox>(janela, "CBComportamento");

            // Construtor do original: `clsAuxiliar.BancoValido()` e, sem o DWG cadastrado, a mMensagem 331.
            if (!InicioDoDesenho.BancoValido(true))
            {
                janela.Dispose();
                return;
            }

            ConfiguracaoPositron config = ConfiguracaoEfetiva.Carregar();
            if (config.Dwg == 0)
            {
                Aviso.MsgBox("Este arquivo ainda não foi cadastrado no banco do projeto!", string.Empty);
                janela.Dispose();
                return;
            }

            TextosDoOriginal(janela);
            ConfigurarCombos(cbTipo, cbComp);
            DesabilitarAcoes(janela);

            Dictionary<int, MaterialDoCatalogo> catalogo = CatalogoIndexado(Catalogo(config));
            ConfiguracaoDoCaderno caderno = ConfiguracaoDoDesenho.LerOuPadrao();

            List<ModeloContato> modelos = ContatosDoDesenho.LerModelos();

            if (dgModelo != null)
            {
                // `carregaModelosNoDG`: sem modelos, a grade fica sem colunas.
                dgModelo.Rows.Clear();
                dgModelo.Columns.Clear();
                if (modelos.Count > 0)
                {
                    dgModelo.Columns.Add("IndiceModelo", "#");
                    dgModelo.Columns.Add("Nome", "Nome");
                    dgModelo.Columns.Add("Material1", "LM1");
                    dgModelo.Columns.Add("Material2", "LM2");
                    dgModelo.Columns.Add("Reserva1", "Reserva1");
                    dgModelo.Columns.Add("Topográfico", "Topográfico");
                    dgModelo.Columns.Add("Layout", "Layout");
                    dgModelo.Columns.Add("Plaquetas", "Plaquetas");
                    dgModelo.Columns.Add("Reserva2", "Reserva2");
                    dgModelo.Columns.Add("Terminais", "Terminais");
                    dgModelo.Columns.Add("Orientação", "Orientação");
                    dgModelo.ColumnHeadersVisible = true;

                    foreach (ModeloContato m in modelos)
                    {
                        dgModelo.Rows.Add(
                            m.Indice,
                            m.Nome ?? string.Empty,
                            m.Lm1,
                            m.Lm2,
                            0,
                            m.BlocoTopografico ?? string.Empty,
                            m.BlocoLayout ?? string.Empty,
                            string.Empty,
                            string.Empty,
                            m.TerminaisDoDispositivo ?? string.Empty,
                            m.Orientacao ?? string.Empty);
                    }

                    foreach (DataGridViewRow linha in dgModelo.Rows)
                    {
                        linha.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }

                    LarguraDosModelos(dgModelo);
                    janela.Resize += (origem, evento) =>
                    {
                        LarguraDosModelos(dgModelo);
                        LarguraDosContatos(dgContato);
                    };
                }

                Action atualizarModeloSelecionado = () =>
                {
                    if (dgModelo.CurrentRow == null)
                    {
                        return;
                    }

                    int idx = dgModelo.CurrentRow.Index;
                    if (idx < 0 || idx >= modelos.Count)
                    {
                        return;
                    }

                    ModeloContato sel = modelos[idx];
                    TextoDaCaixa(janela, "TBModelo", sel.Nome);
                    TextoDaCaixa(janela, "TBTerminais", sel.TerminaisDoDispositivo);
                    TextoDaCaixa(janela, "tbOrientacao", sel.Orientacao);
                    PreencherMaterial(janela, sel.Lm1, 1, catalogo);
                    PreencherMaterial(janela, sel.Lm2, 2, catalogo);
                    // `mostraModelo`: cinza, e branco quando o diretório da simbologia existe.
                    CorDoBloco(janela, "tbBlocoTopografico", caderno.DirSimbologiaTopografico);
                    CorDoBloco(janela, "tbBlocoLayout", caderno.DirSimbologiaLayout);
                    TextoDaCaixa(janela, "tbBlocoTopografico", FormatacaoDeModelos.FormatarNomeDoBloco(sel.BlocoTopografico));
                    TextoDaCaixa(janela, "tbBlocoLayout", FormatacaoDeModelos.FormatarNomeDoBloco(sel.BlocoLayout));

                    List<ContatoAuxiliar> auxiliares = ContatosDoDesenho.LerAuxiliares(sel.Indice);
                    PreencherContatos(janela, dgContato, auxiliares);
                };

                dgModelo.SelectionChanged += (origem, evento) => atualizarModeloSelecionado();

                if (dgModelo.Rows.Count > 0)
                {
                    string filtro = Environment.GetEnvironmentVariable("POSITRON_CONTATO_MODELO");
                    int linhaEscolhida = 0;
                    if (!string.IsNullOrEmpty(filtro))
                    {
                        for (int i = 0; i < modelos.Count; i++)
                        {
                            if (modelos[i].Indice.ToString() == filtro
                                || string.Equals(modelos[i].Nome, filtro, StringComparison.OrdinalIgnoreCase))
                            {
                                linhaEscolhida = i;
                                break;
                            }
                        }
                    }

                    dgModelo.Rows[linhaEscolhida].Selected = true;
                    atualizarModeloSelecionado();
                }
            }
        }

        /// <summary>`clsDispositivo.AtualizaColunasDGModelos`: 5/13/9/9/0/19/19/0/0/13/13% da largura.</summary>
        private static void LarguraDosModelos(DataGridView grade)
        {
            if (grade == null || grade.RowCount == 0 || grade.Columns.Count < 11)
            {
                return;
            }

            int linhasVisiveis = (int)Math.Round(grade.Height / 23.0);
            double util = grade.Width - (grade.RowCount < linhasVisiveis ? 4 : 21);
            double[] fatores = { 0.05, 0.13, 0.09, 0.09, 0, 0.19, 0.19, 0, 0, 0.13, 0.13 };
            for (int i = 0; i < 11; i++)
            {
                grade.Columns[i].Width = (int)Math.Round(util * fatores[i]);
            }

            grade.Columns[4].Visible = false;
            grade.Columns[7].Visible = false;
            grade.Columns[8].Visible = false;
            grade.MultiSelect = false;
        }

        /// <summary>`AtualizaColunasDGContatosAuxiliaresMODELO`: a coluna 0 e as três últimas escondidas, o resto em sextos.</summary>
        private static void LarguraDosContatos(DataGridView grade)
        {
            if (grade == null || grade.RowCount == 0 || grade.Columns.Count < 10)
            {
                return;
            }

            bool barra = false;
            foreach (Control controle in grade.Controls)
            {
                VScrollBar b = controle as VScrollBar;
                if (b != null && b.Visible)
                {
                    barra = true;
                }
            }

            double util = grade.Width - (barra ? 21 : 5);
            double[] fatores = { 0, 0.166, 0.166, 0.166, 0.167, 0.166, 0.166, 0, 0, 0 };
            for (int i = 0; i < 10; i++)
            {
                grade.Columns[i].Width = (int)Math.Round(util * fatores[i]);
                grade.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            grade.Columns[0].Visible = false;
            grade.Columns[7].Visible = false;
            grade.Columns[8].Visible = false;
            grade.Columns[9].Visible = false;
            grade.MultiSelect = false;
            foreach (DataGridViewRow linha in grade.Rows)
            {
                linha.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private static void CorDoBloco(Form janela, string nome, string diretorio)
        {
            TextBox caixa = ControlesDaTela.Achar<TextBox>(janela, nome);
            if (caixa != null)
            {
                caixa.BackColor = !string.IsNullOrEmpty(diretorio) && Directory.Exists(diretorio)
                    ? Color.White
                    : Color.Silver;
            }
        }

        private static void PreencherContatos(Form janela, DataGridView dgContato, List<ContatoAuxiliar> auxiliares)
        {
            if (dgContato == null)
            {
                return;
            }

            // `carregaContatosNoDG`: sem contatos, a grade fica sem colunas.
            dgContato.Rows.Clear();
            dgContato.Columns.Clear();
            if (auxiliares.Count == 0)
            {
                LimparCaixasDoContato(janela);
                return;
            }

            dgContato.Columns.Add("IndiceModelo", "#");
            dgContato.Columns.Add("T1", "T1");
            dgContato.Columns.Add("T2", "T2");
            dgContato.Columns.Add("T3", "T3");
            dgContato.Columns.Add("Orientação", "Orientação");
            dgContato.Columns.Add("Tipo", "Tipo");
            dgContato.Columns.Add("Comportamento", "Comportamento");
            dgContato.Columns.Add("Uso", "ReservaUso");
            dgContato.Columns.Add("Pagina", "Página");
            dgContato.Columns.Add("Handle", "Handle");
            dgContato.ColumnHeadersVisible = true;

            foreach (ContatoAuxiliar c in auxiliares)
            {
                dgContato.Rows.Add(
                    c.Indice,
                    c.T1 ?? string.Empty,
                    c.T2 ?? string.Empty,
                    c.T3 ?? string.Empty,
                    c.Orientacao ?? string.Empty,
                    c.Tipo ?? string.Empty,
                    c.Comportamento ?? string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty);
            }

            LarguraDosContatos(dgContato);
            LimparCaixasDoContato(janela);

            dgContato.SelectionChanged += (origem, evento) =>
            {
                if (dgContato.CurrentRow == null || dgContato.CurrentRow.Index < 0)
                {
                    return;
                }

                DataGridViewRow row = dgContato.CurrentRow;
                TextoDaCaixa(janela, "TBT1", Convert.ToString(row.Cells[1].Value));
                TextoDaCaixa(janela, "TBT2", Convert.ToString(row.Cells[2].Value));
                TextoDaCaixa(janela, "TBT3", Convert.ToString(row.Cells[3].Value));
                TextoDaCaixa(janela, "tbOrientacaoTerminais", Convert.ToString(row.Cells[4].Value));

                ComboBox cbT = ControlesDaTela.Achar<ComboBox>(janela, "CBTipo");
                if (cbT != null)
                {
                    cbT.Text = Convert.ToString(row.Cells[5].Value) ?? "NA";
                }

                ComboBox cbC = ControlesDaTela.Achar<ComboBox>(janela, "CBComportamento");
                if (cbC != null)
                {
                    cbC.Text = Convert.ToString(row.Cells[6].Value) ?? "ST";
                }
            };

            if (dgContato.Rows.Count > 0)
            {
                dgContato.Rows[0].Selected = false;
            }
        }

        private static void LimparCaixasDoContato(Form janela)
        {
            TextoDaCaixa(janela, "TBT1", string.Empty);
            TextoDaCaixa(janela, "TBT2", string.Empty);
            TextoDaCaixa(janela, "TBT3", string.Empty);
            TextoDaCaixa(janela, "tbOrientacaoTerminais", string.Empty);

            ComboBox cbTipo = ControlesDaTela.Achar<ComboBox>(janela, "CBTipo");
            if (cbTipo != null)
            {
                cbTipo.Text = "NA";
            }

            ComboBox cbComp = ControlesDaTela.Achar<ComboBox>(janela, "CBComportamento");
            if (cbComp != null)
            {
                cbComp.Text = "ST";
            }
        }

        private static void ConfigurarCombos(ComboBox cbTipo, ComboBox cbComp)
        {
            if (cbTipo != null)
            {
                cbTipo.Items.Clear();
                cbTipo.Items.AddRange(new object[] { "NA", "NF", "RV" });
                cbTipo.Text = "NA";
            }

            if (cbComp != null)
            {
                cbComp.Items.Clear();
                cbComp.Items.AddRange(new object[] { "ST", "TE", "TD", "BI", "AM" });
                cbComp.Text = "ST";
            }
        }

        private static void TextosDoOriginal(Form janela)
        {
            Texto(janela, "GroupBoxModelos", "Modelos");
            Texto(janela, "lbNomeModelo", "Nome");
            Texto(janela, "LbTerminais", "Terminais");
            Texto(janela, "GroupBox2", "Modelo");
            Texto(janela, "GroupBox3", "Simbologia");
            Texto(janela, "GroupBox4", "Materiais");
            Texto(janela, "lbCodigo", "Código");
            Texto(janela, "lbDesc", "Descrição Resumida");
            Texto(janela, "lbModelo", "Modelo");
            Texto(janela, "lbFabricante", "Fabricante");
            Texto(janela, "lbTerminaisModelo", "Terminais ;");
            Texto(janela, "lbOrientacao", "Orientação ;");
            Texto(janela, "GroupBoxContatos", "Contatos");
            Texto(janela, "lbOrientacaoTerm", "Orientação ;");
            Texto(janela, "LbTipo", "Tipo");
            Texto(janela, "lbTopografico", "Bloco Topográfico");
            Texto(janela, "lbLayout", "Bloco de Layout");
        }

        /// <summary>
        /// As dicas do construtor do original (mMensagens 661–673, 1211, 1353, 1843). Os botões de edição,
        /// gravação e Excel ficam desabilitados: a regra deles ainda não foi portada (fila do <c>ESTADO.md</c>).
        /// As dicas do Excel levam o nome do modelo (916/917 + <c>TBModelo</c>) no original.
        /// </summary>
        private static void DesabilitarAcoes(Form janela)
        {
            Desabilitar(janela, "BTAdicionaModelo", "Adiciona Novo Modelo");
            Desabilitar(janela, "BTEditaModelo", "Edita o Modelo");
            Desabilitar(janela, "BTApagaModelo", "Apaga o Modelo");
            Desabilitar(janela, "btApagaModelosSemUso", "Apagar Modelos não utilizados");
            Desabilitar(janela, "BTNovo", "Sugere terminais de um novo contato");
            Desabilitar(janela, "BTAdicionaContato", "Adicionar Novo Contato");
            Desabilitar(janela, "BTEditaContato", "Editar Contato Selecionado");
            Desabilitar(janela, "BTApagaContaro", "Apagar Contato Selecionado");
            Desabilitar(janela, "BTImportaEX", "Importa do Excel contatos auxiliares para um modelo novo: ");
            Desabilitar(janela, "BTExportaEX", "Exporta para o Excel os contatos auxiliares do modelo: ");
            Desabilitar(janela, "btSelecionaBlocoTopo", "Procurar Bloco");
            Desabilitar(janela, "btSelecionaBlocoLayout", "Procurar Bloco");
            Desabilitar(janela, "btPesquisaLM1", "Pesquisar Materiais");
            Desabilitar(janela, "btPesquisaLM2", "Pesquisar Materiais");

            Dica(janela, "TBT1", "Terminal 1");
            Dica(janela, "TBT2", "Terminal 2");
            Dica(janela, "TBT3", "Terminal 3");
            Dica(janela, "CBTipo", "Tipo NA, NF, RV");
            Dica(janela, "CBComportamento", "Comportamento ST, TE, TD, BI, AM");
            Dica(janela, "DGContatosInseridos", "Contatos Auxiliares já inseridos");

            TextBox tbTopo = ControlesDaTela.Achar<TextBox>(janela, "tbBlocoTopografico");
            if (tbTopo != null)
            {
                tbTopo.Enabled = false;
            }

            TextBox tbLay = ControlesDaTela.Achar<TextBox>(janela, "tbBlocoLayout");
            if (tbLay != null)
            {
                tbLay.Enabled = false;
            }
        }
    }
}

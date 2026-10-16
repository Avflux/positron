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
    /// A ligação do <c>frmGerenciadorMascaras</c> (o comando <c>GERMASC</c>):
    /// - a grade <c>DGMascaras</c> preenchida com os modelos de máscara do desenho (<see cref="ModelosMascaraDoDesenho.LerModelos"/>);
    /// - a grade <c>DGPortas</c> preenchida com os componentes/portas do modelo selecionado (<see cref="ModelosMascaraDoDesenho.LerPortas"/>);
    /// - as caixas de texto do modelo (<c>TBModelo</c>, <c>tbBlocoTopografico</c>, <c>tbBlocoLayout</c>);
    /// - o catálogo de materiais resolvendo os códigos LM1 e LM2 (<c>tbCodigo*</c>, <c>tbDescricaoResum*</c>, <c>tbModelo*</c>, <c>tbFabricante*</c>);
    /// - as caixas da porta selecionada (<c>TBEFC</c>, <c>TBTerminais</c>, <c>TBOrientacao</c>, <c>TBRegua</c>, <c>TBBornes</c>);
    /// - como o construtor do original (<c>frmGerenciadorMascaras.cs:1881</c>): banco inválido ou DWG sem
    ///   cadastro → <c>MsgBox</c> 331; dicas pelas mMensagens; as grades só ganham colunas quando há linhas
    ///   (<c>clsMascara.carregaModelosDeMascaraNoDG :397</c>, <c>clsDispositivoMascaras.carregaContatosNoDGMascara :543</c>),
    ///   com as larguras de <c>AtualizaColunasDGModelos :474</c> e <c>AtualizaColunasDGPortasMascara :2962</c>;
    /// - os botões de edição, gravação e Excel ficam desabilitados (regra ainda não portada), com a dica do original.
    /// </summary>
    internal sealed class LigacaoDoFrmGerenciadorMascaras : LigacaoDeModelos
    {
        public override string NomeDaTela
        {
            get { return "frmGerenciadorMascaras"; }
        }

        public override void Preencher(Form janela)
        {
            DataGridView dgMascaras = ControlesDaTela.Achar<DataGridView>(janela, "DGMascaras");
            DataGridView dgPortas = ControlesDaTela.Achar<DataGridView>(janela, "DGPortas");

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
            DesabilitarAcoes(janela);

            Dictionary<int, MaterialDoCatalogo> catalogo = CatalogoIndexado(Catalogo(config));
            ConfiguracaoDoCaderno caderno = ConfiguracaoDoDesenho.LerOuPadrao();

            List<ModeloMascara> modelos = ModelosMascaraDoDesenho.LerModelos();

            if (dgMascaras != null)
            {
                // `carregaModelosDeMascaraNoDG`: sem modelos, a grade fica sem colunas.
                dgMascaras.Rows.Clear();
                dgMascaras.Columns.Clear();
                if (modelos.Count > 0)
                {
                    dgMascaras.Columns.Add("IndiceModelo", "#");
                    dgMascaras.Columns.Add("Nome", "Nome");
                    dgMascaras.Columns.Add("Material1", "LM1");
                    dgMascaras.Columns.Add("Material2", "LM2");
                    dgMascaras.Columns.Add("Topográfico", "Topográfico");
                    dgMascaras.Columns.Add("Layout", "Layout");
                    dgMascaras.Columns.Add(string.Empty, string.Empty);
                    dgMascaras.ColumnHeadersVisible = true;

                    foreach (ModeloMascara m in modelos)
                    {
                        dgMascaras.Rows.Add(
                            m.Indice,
                            m.Nome ?? string.Empty,
                            m.Lm1,
                            m.Lm2,
                            m.BlocoTopografico ?? string.Empty,
                            m.BlocoLayout ?? string.Empty,
                            string.Empty);
                    }

                    foreach (DataGridViewRow linha in dgMascaras.Rows)
                    {
                        linha.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }

                    LarguraDosModelos(dgMascaras);
                    janela.Resize += (origem, evento) =>
                    {
                        LarguraDosModelos(dgMascaras);
                        LarguraDasPortas(dgPortas);
                    };
                }

                Action atualizarModeloSelecionado = () =>
                {
                    if (dgMascaras.CurrentRow == null)
                    {
                        return;
                    }

                    int idx = dgMascaras.CurrentRow.Index;
                    if (idx < 0 || idx >= modelos.Count)
                    {
                        return;
                    }

                    ModeloMascara sel = modelos[idx];
                    TextoDaCaixa(janela, "TBModelo", sel.Nome);
                    PreencherMaterial(janela, sel.Lm1, 1, catalogo);
                    PreencherMaterial(janela, sel.Lm2, 2, catalogo);
                    // `mostraModeloMascara`: cinza, e branco quando o diretório da simbologia existe.
                    CorDoBloco(janela, "tbBlocoTopografico", caderno.DirSimbologiaTopografico);
                    CorDoBloco(janela, "tbBlocoLayout", caderno.DirSimbologiaLayout);
                    TextoDaCaixa(janela, "tbBlocoTopografico", FormatacaoDeModelos.FormatarNomeDoBloco(sel.BlocoTopografico));
                    TextoDaCaixa(janela, "tbBlocoLayout", FormatacaoDeModelos.FormatarNomeDoBloco(sel.BlocoLayout));

                    List<ModeloPorta> portas = ModelosMascaraDoDesenho.LerPortas(sel.Indice, sel.Nome);
                    PreencherPortas(janela, dgPortas, portas);
                };

                dgMascaras.SelectionChanged += (origem, evento) => atualizarModeloSelecionado();

                if (dgMascaras.Rows.Count > 0)
                {
                    string filtro = Environment.GetEnvironmentVariable("POSITRON_MASCARA_MODELO");
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

                    dgMascaras.Rows[linhaEscolhida].Selected = true;
                    atualizarModeloSelecionado();
                }
            }
        }

        /// <summary>`clsMascara.AtualizaColunasDGModelos`: 10/18/10/10/26/26% e a última coluna escondida.</summary>
        private static void LarguraDosModelos(DataGridView grade)
        {
            if (grade == null || grade.RowCount == 0 || grade.Columns.Count < 7)
            {
                return;
            }

            double util = grade.Width - (TemBarra(grade) ? 21 : 4);
            double[] fatores = { 0.1, 0.18, 0.1, 0.1, 0.26, 0.26 };
            for (int i = 0; i < 6; i++)
            {
                grade.Columns[i].Width = (int)Math.Round(util * fatores[i]);
            }

            grade.Columns[6].Width = 0;
            grade.Columns[6].Visible = false;
            grade.MultiSelect = false;
        }

        /// <summary>`AtualizaColunasDGPortasMascara`: 50/0/20%/30%/65/30%/20% (do que sobra de largura − 115).</summary>
        private static void LarguraDasPortas(DataGridView grade)
        {
            if (grade == null || grade.RowCount == 0 || grade.Columns.Count < 7)
            {
                return;
            }

            double util = grade.Width - (TemBarra(grade) ? 21 : 4) - 115.0;
            grade.Columns[0].Width = 50;
            grade.Columns[1].Width = 0;
            grade.Columns[2].Width = (int)Math.Round(util * 0.2);
            grade.Columns[3].Width = (int)Math.Round(util * 0.3);
            grade.Columns[4].Width = 65;
            grade.Columns[5].Width = (int)Math.Round(util * 0.3);
            grade.Columns[6].Width = (int)Math.Round(util * 0.2);
            grade.Columns[1].Visible = false;
            grade.MultiSelect = false;
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

        private static bool TemBarra(DataGridView grade)
        {
            foreach (Control controle in grade.Controls)
            {
                VScrollBar barra = controle as VScrollBar;
                if (barra != null && barra.Visible)
                {
                    return true;
                }
            }

            return false;
        }

        private static void PreencherPortas(Form janela, DataGridView dgPortas, List<ModeloPorta> portas)
        {
            if (dgPortas == null)
            {
                return;
            }

            // `carregaContatosNoDGMascara`: sem portas, a grade fica sem colunas.
            dgPortas.Rows.Clear();
            dgPortas.Columns.Clear();
            if (portas.Count == 0)
            {
                LimparCaixasDaPorta(janela);
                return;
            }

            dgPortas.Columns.Add("IndicePorta", "#");
            dgPortas.Columns.Add("indexModelo", "indexModelo");
            dgPortas.Columns.Add("EFC", "EFC");
            dgPortas.Columns.Add("Terminais", "Terminais");
            dgPortas.Columns.Add("Orientação", "Orientação");
            dgPortas.Columns.Add("Regua", "Régua");
            dgPortas.Columns.Add("Bornes", "Bornes");
            dgPortas.Columns[1].Visible = false;
            dgPortas.ColumnHeadersVisible = true;

            foreach (ModeloPorta p in portas)
            {
                dgPortas.Rows.Add(
                    p.IndiceDaPorta,
                    p.IndiceModelo,
                    p.EFC ?? string.Empty,
                    p.Terminais ?? string.Empty,
                    p.Orientacao ?? string.Empty,
                    p.Regua ?? string.Empty,
                    p.Bornes ?? string.Empty);
            }

            LarguraDasPortas(dgPortas);
            LimparCaixasDaPorta(janela);

            dgPortas.SelectionChanged += (origem, evento) =>
            {
                if (dgPortas.CurrentRow == null || dgPortas.CurrentRow.Index < 0)
                {
                    return;
                }

                DataGridViewRow row = dgPortas.CurrentRow;
                TextoDaCaixa(janela, "TBEFC", Convert.ToString(row.Cells[2].Value));
                TextoDaCaixa(janela, "TBTerminais", Convert.ToString(row.Cells[3].Value));
                TextoDaCaixa(janela, "TBOrientacao", Convert.ToString(row.Cells[4].Value));
                TextoDaCaixa(janela, "TBRegua", Convert.ToString(row.Cells[5].Value));
                TextoDaCaixa(janela, "TBBornes", Convert.ToString(row.Cells[6].Value));
            };

            if (dgPortas.Rows.Count > 0)
            {
                dgPortas.Rows[0].Selected = false;
            }
        }

        private static void LimparCaixasDaPorta(Form janela)
        {
            TextoDaCaixa(janela, "TBEFC", string.Empty);
            TextoDaCaixa(janela, "TBTerminais", string.Empty);
            TextoDaCaixa(janela, "TBOrientacao", string.Empty);
            TextoDaCaixa(janela, "TBRegua", string.Empty);
            TextoDaCaixa(janela, "TBBornes", string.Empty);
        }

        private static void TextosDoOriginal(Form janela)
        {
            Texto(janela, "GroupBoxMascara", "Modelos");
            Texto(janela, "GroupBoxPorta", "Componentes da Máscara");
            Texto(janela, "LbModelo", "Modelo");
            Texto(janela, "LBEF", "EFC");
            Texto(janela, "LBTerminais", "Terminais;");
            Texto(janela, "lbOrientacao", "Orientação;");
            Texto(janela, "LBRegua", "Réguas");
            Texto(janela, "LBBornes", "Bornes;");
            Texto(janela, "GroupBox2", "Modelo");
            Texto(janela, "GroupBox3", "Simbologia");
            Texto(janela, "GroupBox4", "Materiais");
            Texto(janela, "lbCodigo", "Código");
            Texto(janela, "lbDesc", "Descrição Resumida");
            Texto(janela, "lbFabricante", "Fabricante");
            Texto(janela, "lbTopografico", "Bloco Topográfico");
            Texto(janela, "lbLayout", "Bloco de Layout");
        }

        /// <summary>
        /// As dicas do construtor do original (mMensagens 661–663, 1126–1128, 668–670, 673, 1124, 1125,
        /// 1353, 1481, 1843). Os botões de edição, gravação e Excel ficam desabilitados: a regra deles
        /// ainda não foi portada (fila do <c>ESTADO.md</c>).
        /// </summary>
        private static void DesabilitarAcoes(Form janela)
        {
            Desabilitar(janela, "BTAdicionaMascara", "Adiciona Novo Modelo");
            Desabilitar(janela, "BTEditaMascara", "Edita o Modelo");
            Desabilitar(janela, "BTApagaMascara", "Apaga o Modelo");
            Desabilitar(janela, "btApagaModelosSemUso", "Apagar Modelos não utilizados");
            Desabilitar(janela, "BTAdicionaPorta", "Adicionar Componente");
            Desabilitar(janela, "BTEditaPorta", "Editar Componente");
            Desabilitar(janela, "BTApagaPorta", "Apagar Componente");
            Desabilitar(janela, "btVerifica", "Verifica terminais e bornes duplicados.");
            Desabilitar(janela, "BTImportaEX", "Importa do Excel o modelo Selecionado ");
            Desabilitar(janela, "BTExportaEX", "Exporta para o Excel o modelo Selecionado ");
            Desabilitar(janela, "btSelecionaBlocoTopo", "Procurar Bloco");
            Desabilitar(janela, "btSelecionaBlocoLayout", "Procurar Bloco");

            // Os botões de pesquisa de material (LM1/LM2) não têm dica no construtor do original.
            Desabilitar(janela, "btPesquisaLM1", null);
            Desabilitar(janela, "btPesquisaLM2", null);

            Dica(janela, "TBEFC", "Terminal 1");
            Dica(janela, "TBTerminais", "Terminal 2");
            Dica(janela, "TBRegua", "Terminal 3");
            Dica(janela, "DGPortasInseridas", "Contatos Auxiliares já inseridos");

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

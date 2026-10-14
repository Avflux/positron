using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Positron.Data.Configuracao;
using Positron.Data.Materiais;
using Positron.Data.Modelos;
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
    /// - botões de edição, gravação e interop do Excel desabilitados com motivo explicativo na dica.
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

            TextosDoOriginal(janela);
            ConfigurarCombos(cbTipo, cbComp);
            DesabilitarAcoes(janela);

            ConfiguracaoPositron config = ConfiguracaoPositron.Carregar();
            Dictionary<int, MaterialDoCatalogo> catalogo = CatalogoIndexado(Catalogo(config));

            List<ModeloContato> modelos = ContatosDoDesenho.LerModelos();

            if (dgModelo != null)
            {
                dgModelo.Columns.Clear();
                dgModelo.Columns.Add("IndiceModelo", "#");
                dgModelo.Columns.Add("Nome", "Nome");
                dgModelo.Columns.Add("Material1", "Material 1");
                dgModelo.Columns.Add("Material2", "Material 2");
                dgModelo.Columns.Add("Reserva1", "0");
                dgModelo.Columns.Add("Topográfico", "Bloco Topográfico");
                dgModelo.Columns.Add("Layout", "Bloco Layout");
                dgModelo.Columns.Add("Plaquetas", "Plaquetas");
                dgModelo.Columns.Add("Reserva2", "Reserva2");
                dgModelo.Columns.Add("Terminais", "Terminais");
                dgModelo.Columns.Add("Orientação", "Orientação");
                dgModelo.Columns[4].Visible = false;
                dgModelo.Columns[7].Visible = false;
                dgModelo.Columns[8].Visible = false;
                dgModelo.ColumnHeadersVisible = true;

                dgModelo.Rows.Clear();
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

            int auxPrimeiro = (modelos.Count > 0)
                ? ContatosDoDesenho.LerAuxiliares(modelos[0].Indice).Count
                : 0;
            string nomePrimeiro = (modelos.Count > 0) ? modelos[0].Nome : "-";

            Plugin.Escrever(string.Format(
                "GERCONT: {0} modelo(s) de contato lido(s) do desenho ({1} auxiliar(es) no primeiro modelo \"{2}\"); {3} material(is) no catálogo; botões de edição desabilitados.",
                modelos.Count, auxPrimeiro, nomePrimeiro, catalogo.Count));
        }

        private static void PreencherContatos(Form janela, DataGridView dgContato, List<ContatoAuxiliar> auxiliares)
        {
            if (dgContato == null)
            {
                return;
            }

            dgContato.Columns.Clear();
            dgContato.Columns.Add("IndiceModelo", "#");
            dgContato.Columns.Add("T1", "T1");
            dgContato.Columns.Add("T2", "T2");
            dgContato.Columns.Add("T3", "T3");
            dgContato.Columns.Add("Orientação", "Orientação");
            dgContato.Columns.Add("Tipo", "Tipo");
            dgContato.Columns.Add("Comportamento", "Comportamento");
            dgContato.Columns.Add("Uso", "Uso");
            dgContato.Columns.Add("Pagina", "Página");
            dgContato.Columns.Add("Handle", "Handle");
            dgContato.ColumnHeadersVisible = true;

            dgContato.Rows.Clear();
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
            Texto(janela, "LbTerminais", "Terminais da Bobina");
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

        private static void DesabilitarAcoes(Form janela)
        {
            Desabilitar(janela, "BTAdicionaModelo", "adição de modelo de contato não portada");
            Desabilitar(janela, "BTEditaModelo", "edição de modelo de contato não portada");
            Desabilitar(janela, "BTApagaModelo", "remoção de modelo de contato não portada");
            Desabilitar(janela, "btApagaModelosSemUso", "limpeza de modelos sem uso não portada");
            Desabilitar(janela, "BTNovo", "criação de contato não portada");
            Desabilitar(janela, "BTAdicionaContato", "adição de contato auxiliar não portada");
            Desabilitar(janela, "BTEditaContato", "edição de contato auxiliar não portada");
            Desabilitar(janela, "BTApagaContaro", "remoção de contato auxiliar não portada");
            Desabilitar(janela, "BTImportaEX", "interop Excel não portado");
            Desabilitar(janela, "BTExportaEX", "interop Excel não portado");
            Desabilitar(janela, "btSelecionaBlocoTopo", "seleção gráfica não portada");
            Desabilitar(janela, "btSelecionaBlocoLayout", "seleção gráfica não portada");
            Desabilitar(janela, "btPesquisaLM1", "pesquisa de material na tela não portada");
            Desabilitar(janela, "btPesquisaLM2", "pesquisa de material na tela não portada");

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

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
    /// A ligação do <c>frmGerenciadorMascaras</c> (o comando <c>GERMASC</c>):
    /// - a grade <c>DGMascaras</c> preenchida com os modelos de máscara do desenho (<see cref="ModelosMascaraDoDesenho.LerModelos"/>);
    /// - a grade <c>DGPortas</c> preenchida com os componentes/portas do modelo selecionado (<see cref="ModelosMascaraDoDesenho.LerPortas"/>);
    /// - as caixas de texto do modelo (<c>TBModelo</c>, <c>tbBlocoTopografico</c>, <c>tbBlocoLayout</c>);
    /// - o catálogo de materiais resolvendo os códigos LM1 e LM2 (<c>tbCodigo*</c>, <c>tbDescricaoResum*</c>, <c>tbModelo*</c>, <c>tbFabricante*</c>);
    /// - as caixas da porta selecionada (<c>TBEFC</c>, <c>TBTerminais</c>, <c>TBOrientacao</c>, <c>TBRegua</c>, <c>TBBornes</c>);
    /// - botões de edição, gravação e interop do Excel desabilitados com motivo explicativo na dica.
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

            TextosDoOriginal(janela);
            DesabilitarAcoes(janela);

            ConfiguracaoPositron config = ConfiguracaoEfetiva.Carregar();
            Dictionary<int, MaterialDoCatalogo> catalogo = CatalogoIndexado(Catalogo(config));

            List<ModeloMascara> modelos = ModelosMascaraDoDesenho.LerModelos();

            if (dgMascaras != null)
            {
                dgMascaras.Columns.Clear();
                dgMascaras.Columns.Add("IndiceModelo", "#");
                dgMascaras.Columns.Add("Nome", "Modelo");
                dgMascaras.Columns.Add("Material1", "Material 1");
                dgMascaras.Columns.Add("Material2", "Material 2");
                dgMascaras.Columns.Add("Topográfico", "Bloco Topográfico");
                dgMascaras.Columns.Add("Layout", "Bloco Layout");
                dgMascaras.Columns.Add(string.Empty, string.Empty);
                dgMascaras.Columns[6].Visible = false;
                dgMascaras.ColumnHeadersVisible = true;

                dgMascaras.Rows.Clear();
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

            int portasPrimeiro = (modelos.Count > 0)
                ? ModelosMascaraDoDesenho.LerPortas(modelos[0].Indice, modelos[0].Nome).Count
                : 0;
            string nomePrimeiro = (modelos.Count > 0) ? modelos[0].Nome : "-";

            Plugin.Escrever(string.Format(
                "GERMASC: {0} modelo(s) de máscara lido(s) do desenho ({1} porta(s) no primeiro modelo \"{2}\"); {3} material(is) no catálogo; botões de edição desabilitados.",
                modelos.Count, portasPrimeiro, nomePrimeiro, catalogo.Count));
        }

        private static void PreencherPortas(Form janela, DataGridView dgPortas, List<ModeloPorta> portas)
        {
            if (dgPortas == null)
            {
                return;
            }

            dgPortas.Columns.Clear();
            dgPortas.Columns.Add("IndicePorta", "#");
            dgPortas.Columns.Add("indexModelo", "indexModelo");
            dgPortas.Columns.Add("EFC", "EFC");
            dgPortas.Columns.Add("Terminais", "Terminais");
            dgPortas.Columns.Add("Orientação", "Orientação");
            dgPortas.Columns.Add("Regua", "Régua");
            dgPortas.Columns.Add("Bornes", "Bornes");
            dgPortas.Columns[1].Visible = false;
            dgPortas.ColumnHeadersVisible = true;

            dgPortas.Rows.Clear();
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

        private static void DesabilitarAcoes(Form janela)
        {
            Desabilitar(janela, "BTAdicionaMascara", "adição de modelo de máscara não portada");
            Desabilitar(janela, "BTEditaMascara", "edição de modelo de máscara não portada");
            Desabilitar(janela, "BTApagaMascara", "remoção de modelo de máscara não portada");
            Desabilitar(janela, "btApagaModelosSemUso", "limpeza de modelos sem uso não portada");
            Desabilitar(janela, "BTAdicionaPorta", "adição de componente não portada");
            Desabilitar(janela, "BTEditaPorta", "edição de componente não portada");
            Desabilitar(janela, "BTApagaPorta", "remoção de componente não portada");
            Desabilitar(janela, "btVerifica", "verificação na tela não portada (use VERIF)");
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

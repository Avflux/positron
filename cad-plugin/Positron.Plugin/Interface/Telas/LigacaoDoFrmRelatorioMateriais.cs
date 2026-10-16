using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Positron.Data;
using Positron.Data.Configuracao;
using Positron.Data.Materiais;
using Positron.Data.Relatorios;

namespace Positron.Plugin.Interface.Telas
{
    /// <summary>
    /// A ligação da <c>frmRelatorio_Materiais</c> (o comando <c>EXPLM</c>, "Relatório LM"): as três
    /// grades do original — <c>dgEquipamentos</c> com os painéis da <c>ListaMateriais</c> do desenho,
    /// <c>dgOrdem</c> com os itens do painel escolhido **na ordem do diagrama** e
    /// <c>dgListaMateriais</c> com a lista agrupada por material — mais os títulos das colunas
    /// (<c>tbIndice</c>…<c>tbCod</c>) e o <c>btPesquisar</c>.
    ///
    /// **A regra é a do recoder** (<see cref="ListaDeMateriaisDoRelatorio"/>, o recorte de **um painel**
    /// do original) sobre a <c>ListaMateriais</c> que o <c>COMPLM</c> já grava e o catálogo
    /// (<c>Materiais</c>) — as mesmas tabelas que o <c>ATINDEP</c> liga desde a rodada 148.
    ///
    /// **Como o construtor do original** (<c>frmRelatorio_Materiais.cs:1647</c>): as grades abrem sem
    /// colunas (a <c>dgEquipamentos</c> só ganha colunas se há painéis; <c>dgOrdem</c> e
    /// <c>dgListaMateriais</c> ganham as suas ao carregar), o grupo "Multiplicador de Típicos" e o
    /// <c>tbCod</c>/<c>ckExcel2</c>/<c>ckDWG2</c> ficam escondidos, e as dicas são só as de
    /// <c>btPesquisar</c>, <c>btExportaDWG</c>, <c>btExportaEXCEL</c>, <c>btSalvaOrdem</c> e <c>BTY</c>.
    ///
    /// **O que entra desabilitado:** as duas exportações, a ordenação manual das linhas com a gravação
    /// da ordem, o modo **multi-painel** e a **mesclagem** de modelo/fabricante — regras ainda não
    /// portadas (fila do <c>ESTADO.md</c>). A tela usa o modo padrão do designer (um painel, descrição completa).
    ///
    /// Como no original, a lista só sai no <c>btPesquisar</c>. No harness, <c>POSITRON_REL_PAINEL</c>
    /// escolhe o painel e roda a mesma carga ao abrir (a receita no RUNBOOK).
    /// </summary>
    internal sealed class LigacaoDoFrmRelatorioMateriais : LigacaoDeRelatorio
    {
        public override string NomeDaTela
        {
            get { return "frmRelatorio_Materiais"; }
        }

        public override void Preencher(Form janela)
        {
            DataGridView equipamentos = ControlesDaTela.Achar<DataGridView>(janela, "dgEquipamentos");
            DataGridView ordem = ControlesDaTela.Achar<DataGridView>(janela, "dgOrdem");
            DataGridView grade = ControlesDaTela.Achar<DataGridView>(janela, "dgListaMateriais");
            Button pesquisar = ControlesDaTela.Achar<Button>(janela, "btPesquisar");
            RadioButton completa = ControlesDaTela.Achar<RadioButton>(janela, "RBCompleta");
            bool descricaoCompleta = completa == null || completa.Checked;

            TextosDoOriginal(janela);
            Motivos(janela);

            // Sem colunas até haver o que mostrar (o `x0npqmuPsyI` limpa as grades no construtor).
            LimparGrade(equipamentos);
            LimparGrade(ordem);
            LimparGrade(grade);

            ConfiguracaoPositron config = Configuracao();
            if (config == null || string.IsNullOrEmpty(config.Banco))
            {
                return;
            }

            List<LinhaListaMaterial> linhas = DoBanco("EXPLM",
                () => new ProjectStore(config.Banco).LerListaMateriais(config.Dwg))
                ?? new List<LinhaListaMaterial>();
            List<MaterialDoCatalogo> catalogo = DoBanco("EXPLM",
                () => new ProjectStore(config.Banco).LerMateriais())
                ?? new List<MaterialDoCatalogo>();
            IReadOnlyDictionary<int, string> nomes = DoBanco("EXPLM",
                () => new ProjectStore(config.Banco).LerNomesDePaineis())
                ?? new Dictionary<int, string>();

            IReadOnlyDictionary<int, MaterialDoCatalogo> indexado = CatalogoDeMateriais.Indexar(catalogo);
            List<int> paineis = ListaDeMateriaisDoRelatorio.Paineis(linhas);

            if (paineis.Count == 0)
            {
                return;
            }

            // `formataDGEquip`: Indice (escondida) | "Equipamentos  Painéis" (mMensagem 748).
            if (equipamentos != null)
            {
                equipamentos.MultiSelect = false;
                equipamentos.Columns.Add("Indice", "Indice");
                equipamentos.Columns.Add(string.Empty, "Equipamentos  Painéis");
                equipamentos.Columns[0].Width = 0;
                equipamentos.Columns[0].Visible = false;
                foreach (int painel in paineis)
                {
                    equipamentos.Rows.Add(painel, NomeDoPainel(nomes, painel));
                }

                // O original, ao trocar o equipamento escolhido, recarrega a `dgOrdem`; a
                // `dgListaMateriais` só sai no `btPesquisar`.
                equipamentos.SelectionChanged += (origem, evento) =>
                    CarregarOrdem(ordem, linhas, PainelEscolhido(equipamentos), janela);
            }

            Ligar(pesquisar, (origem, evento) =>
                Carregar(equipamentos, ordem, grade, linhas, indexado, descricaoCompleta, janela));

            // Harness: um script não clica nem escolhe, então `POSITRON_REL_PAINEL` escolhe o painel
            // e roda a carga do `btPesquisar` ao abrir.
            int pedido = PainelPedido();
            if (pedido != 0 && paineis.Contains(pedido) && equipamentos != null)
            {
                equipamentos.Rows[paineis.IndexOf(pedido)].Selected = true;
                Carregar(equipamentos, ordem, grade, linhas, indexado, descricaoCompleta, janela);
            }
        }

        private static void LimparGrade(DataGridView grade)
        {
            if (grade != null)
            {
                grade.Rows.Clear();
                grade.Columns.Clear();
            }
        }

        /// <summary>Os textos do construtor do original (o <c>mMensagem</c> que vira cabeçalho de coluna).</summary>
        private static void TextosDoOriginal(Form janela)
        {
            Texto(janela, "GroupBox1", "Multiplicador de Típicos");
            Texto(janela, "GroupBox2", string.Empty);
            Texto(janela, "lbTitulos", "Titulos dos Relatórios");
            Texto(janela, "lbMultiplicador", "Fator de Multiplicação");
            Texto(janela, "ckMesclarModelo", "Mesclar Modelo na Descrição");
            Texto(janela, "ckMesclarFabricante", "Mesclar Fabricante na Descrição");
            Texto(janela, "ckCodCli", "Código do Cliente");
            Texto(janela, "ckMultPNDetalhado", "Detalhar Quantidade Por Painel");
            Texto(janela, "CBMultiselecao", "Multiseleção");
            Texto(janela, "btDesagrupar", "Desagrupar");
            Texto(janela, "btLayout", "Ordem Layout");
            Texto(janela, "RBCompleta", "Descrição Completa");
            Texto(janela, "RBResumida", "Descrição Resumida");
            Texto(janela, "lPTIni", "Ponto inicial do Relatório");
            Texto(janela, "tbIndice", "Índice");
            Texto(janela, "tbQuant", "Quant");
            Texto(janela, "tbTag", "Tag");
            Texto(janela, "tbDesc", "Descrição");
            Texto(janela, "tbMod", "Modelo");
            Texto(janela, "tbFab", "Fabricante");
            Texto(janela, "tbCod", "Código do Cliente");
            Texto(janela, "tbMultiplicador", "1");

            // Do construtor: escondidos e desabilitados.
            Esconder(janela, "GroupBox1");
            Esconder(janela, "GroupBox4");
            Esconder(janela, "tbCod");
            Esconder(janela, "ckExcel2");
            Esconder(janela, "ckDWG2");

            Dica(janela, "btPesquisar", "Pesquisar Materiais");
            Dica(janela, "btExportaDWG", "Exporta Lista de Materiais para o DWG");
            Dica(janela, "btExportaEXCEL", "Exporta Lista de Materiais para o Excel");
            Dica(janela, "btSalvaOrdem", "Salvar Ordem");
            Dica(janela, "BTY", "Altura Inicial do Relatório");
        }

        private static void Esconder(Form janela, string nome)
        {
            Control controle = ControlesDaTela.Procurar(janela, nome);
            if (controle != null)
            {
                controle.Visible = false;
            }
        }

        /// <summary>
        /// O que a tela não porta: os botões ficam desabilitados (regra ainda não portada). Só os que têm
        /// dica no construtor do original (<c>btExportaEXCEL</c>, <c>btExportaDWG</c>, <c>btSalvaOrdem</c>,
        /// <c>BTY</c>) mostram dica; <c>tbMultiplicador</c> e <c>btSalvaOrdem</c> já abrem desabilitados lá.
        /// </summary>
        private static void Motivos(Form janela)
        {
            foreach (string nome in new[]
            {
                "btExportaEXCEL", "btExportaDWG", "btSalvaOrdem", "btDesagrupar", "btLayout", "BTY",
                "btCima", "btBaixo", "btPrimeiro", "btUltimo", "ckMultPNDetalhado", "ckMesclarModelo",
                "ckMesclarFabricante", "tbMultiplicador",
            })
            {
                Control controle = ControlesDaTela.Procurar(janela, nome);
                if (controle != null)
                {
                    controle.Enabled = false;
                }
            }
        }

        /// <summary>
        /// A carga do painel escolhido: o <c>dgOrdem</c> com os itens na ordem do diagrama e o
        /// <c>dgListaMateriais</c> com a <see cref="ListaDeMateriaisDoRelatorio"/>.
        /// </summary>
        private static void Carregar(
            DataGridView equipamentos,
            DataGridView ordem,
            DataGridView grade,
            List<LinhaListaMaterial> linhas,
            IReadOnlyDictionary<int, MaterialDoCatalogo> catalogo,
            bool descricaoCompleta,
            Form janela)
        {
            if (equipamentos == null || grade == null)
            {
                return;
            }

            int painel = PainelEscolhido(equipamentos);
            if (painel == 0)
            {
                return;
            }

            CarregarOrdem(ordem, linhas, painel, janela);

            // `formataDGListaMateriais`: os títulos vêm das caixas `tbIndice`…`tbCod`, sem ordenação.
            grade.Rows.Clear();
            grade.Columns.Clear();
            foreach (string[] coluna in new[]
            {
                new[] { "#", "tbIndice" }, new[] { "Quant", "tbQuant" }, new[] { "TAG", "tbTag" },
                new[] { "DESC", "tbDesc" }, new[] { "MOD", "tbMod" }, new[] { "FAB", "tbFab" },
                new[] { "COD", "tbCod" }, new[] { "INDEXLM", null },
            })
            {
                int indice = grade.Columns.Add(coluna[0], coluna[1] == null ? string.Empty : LerCaixa(janela, coluna[1]));
                grade.Columns[indice].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            List<LinhaDaLMDoRelatorio> lista = ListaDeMateriaisDoRelatorio.Montar(linhas, catalogo, painel, descricaoCompleta);
            foreach (LinhaDaLMDoRelatorio linha in lista)
            {
                grade.Rows.Add(
                    linha.Sequencia,
                    linha.Quantidade,
                    linha.Tag,
                    linha.Descricao,
                    linha.Modelo,
                    linha.Fabricante,
                    linha.CodigoCliente,
                    linha.IndiceLM);
            }

            if (grade.Rows.Count > 0)
            {
                grade.Rows[0].Selected = true;
            }
        }

        /// <summary>
        /// A `dgOrdem` do painel escolhido — o `CarregaDadosOrdemDispositivos`/`formataDGOrdem`: os
        /// itens na **ordem do diagrama** (a `Ordem` que o `COMPLM` renumera 1..N por painel).
        /// </summary>
        private static void CarregarOrdem(DataGridView ordem, List<LinhaListaMaterial> linhas, int painel, Form janela)
        {
            if (ordem == null)
            {
                return;
            }

            // `formataDGOrdem`: as colunas só existem com um painel escolhido.
            ordem.Rows.Clear();
            ordem.Columns.Clear();
            if (painel == 0)
            {
                return;
            }

            ordem.Columns.Add("#", "#");
            ordem.Columns.Add("TAG", LerCaixa(janela, "tbTag"));
            ordem.Columns.Add("COD", "MAT");
            ordem.Columns.Add("Ordem", "Ordem");
            ordem.Columns.Add("Quantidade", "Quantidade");
            ordem.Columns.Add("OrdemLay", "OrdemLay");

            foreach (LinhaListaMaterial linha in PaineisDaListaDeMateriais.DoPainel(linhas, painel))
            {
                ordem.Rows.Add(linha.Indice, linha.Tag, linha.IndiceMaterial, linha.Ordem, linha.Quantidade, linha.OrdemLay);
            }
        }

        private static int PainelEscolhido(DataGridView equipamentos)
        {
            if (equipamentos.SelectedRows.Count == 0)
            {
                return 0;
            }

            int painel;
            return int.TryParse(Celula(equipamentos.SelectedRows[0], 0), out painel) ? painel : 0;
        }

        private static string NomeDoPainel(IReadOnlyDictionary<int, string> nomes, int painel)
        {
            string nome;
            if (nomes != null && nomes.TryGetValue(painel, out nome))
            {
                return nome ?? string.Empty;
            }

            return string.Empty;
        }
    }
}

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
    /// **O que entra desabilitado, com o motivo na dica:** as duas exportações (<c>btExportaEXCEL</c> e
    /// <c>btExportaDWG</c>, interop), a ordenação manual das linhas com a gravação da ordem
    /// (<c>btCima</c>/<c>btBaixo</c>/<c>btPrimeiro</c>/<c>btUltimo</c>/<c>btSalvaOrdem</c>/
    /// <c>btDesagrupar</c>/<c>BTY</c>/<c>btLayout</c>), o modo **multi-painel**
    /// (<c>ckMultPNDetalhado</c>, que acrescenta uma coluna por painel) e a **mesclagem** de
    /// modelo/fabricante na descrição — a tela abre no modo padrão do designer (um painel, descrição
    /// completa), que é o portado.
    ///
    /// O painel sai do primeiro item da coluna da esquerda; num script, <c>POSITRON_REL_PAINEL</c>
    /// escolhe (a receita no RUNBOOK).
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
            Colunas(equipamentos, ordem, grade, janela);
            Motivos(janela);

            ConfiguracaoPositron config = Configuracao();
            if (config == null || string.IsNullOrEmpty(config.Banco))
            {
                Plugin.Escrever("EXPLM: defina POSITRON_DB_PATH com o caminho do banco do projeto (.db) "
                    + "para a Lista de Materiais; a tela abre vazia.");
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

            if (equipamentos != null)
            {
                equipamentos.Columns.Clear();
                equipamentos.Columns.Add("Indice", "Indice");
                equipamentos.Columns.Add(string.Empty, "Equipamentos  Painéis");
                equipamentos.Columns[0].Width = 0;
                equipamentos.Columns[0].Visible = false;

                equipamentos.Rows.Clear();
                foreach (int painel in paineis)
                {
                    equipamentos.Rows.Add(painel, NomeDoPainel(nomes, painel));
                }

                // O original, ao trocar o equipamento escolhido, recarrega a `dgOrdem` (o
                // `CarregaDadosOrdemDispositivos`); a `dgListaMateriais` só sai no `btPesquisar`.
                equipamentos.SelectionChanged += (origem, evento) =>
                {
                    int escolhido = PainelEscolhido(equipamentos);
                    Plugin.Escrever("EXPLM: painel " + escolhido + " — "
                        + CarregarOrdem(ordem, linhas, escolhido) + " item(ns) na ordem do diagrama.");
                };
            }

            if (paineis.Count == 0)
            {
                Plugin.Escrever("EXPLM: a ListaMateriais do DWG " + config.Dwg + " está vazia (o COMPLM "
                    + "ainda não rodou neste projeto); a tela abre vazia.");
                return;
            }

            int pedido = PainelPedido();
            int escolhida = pedido != 0 && paineis.Contains(pedido) ? paineis.IndexOf(pedido) : 0;
            if (equipamentos != null)
            {
                equipamentos.Rows[escolhida].Selected = true;
            }

            // Num script a tela não é *clicada*: sem esta carga a grade abriria vazia até o
            // btPesquisar, como no original, e o harness não teria como medir a lista.
            Plugin.Escrever(Carregar(equipamentos, ordem, grade, linhas, indexado, descricaoCompleta));
            Ligar(pesquisar, (origem, evento) => Plugin.Escrever(
                Carregar(equipamentos, ordem, grade, linhas, indexado, descricaoCompleta)));

            Plugin.Escrever("EXPLM: " + linhas.Count + " item(ns) na ListaMateriais do DWG "
                + config.Dwg + "; " + indexado.Count + " material(is) no catálogo; "
                + nomes.Count + " painel(is) no cadastro.");
        }

        /// <summary>Os textos do construtor do original (o <c>mMensagem</c> que vira cabeçalho de coluna).</summary>
        private static void TextosDoOriginal(Form janela)
        {
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

            Dica(janela, "btPesquisar", "Pesquisar Materiais");
            Dica(janela, "btExportaDWG", "Exporta Lista de Materiais para o DWG");
            Dica(janela, "btExportaEXCEL", "Exporta Lista de Materiais para o Excel");
        }

        /// <summary>
        /// As três grades do original: o <c>formataDGEquip</c>, o <c>formataDGOrdem</c> e o
        /// <c>formataDGListaMateriais</c> — este último com os títulos das caixas, como lá.
        /// </summary>
        private static void Colunas(DataGridView equipamentos, DataGridView ordem, DataGridView grade, Form janela)
        {
            if (equipamentos != null)
            {
                equipamentos.Rows.Clear();
                equipamentos.Columns.Clear();
                equipamentos.Columns.Add("Indice", "Indice");
                equipamentos.Columns.Add(string.Empty, "Equipamentos  Painéis");
                equipamentos.Columns[0].Width = 0;
                equipamentos.Columns[0].Visible = false;
            }

            if (ordem != null)
            {
                ordem.Rows.Clear();
                ordem.Columns.Clear();
                ordem.Columns.Add("#", "#");
                ordem.Columns.Add("TAG", LerCaixa(janela, "tbTag"));
                ordem.Columns.Add("COD", "MAT");
                ordem.Columns.Add("Ordem", "Ordem");
                ordem.Columns.Add("Quantidade", "Quantidade");
                ordem.Columns.Add("OrdemLay", "OrdemLay");
            }

            if (grade != null)
            {
                grade.Rows.Clear();
                grade.Columns.Clear();
                grade.Columns.Add("#", LerCaixa(janela, "tbIndice"));
                grade.Columns.Add("Quant", LerCaixa(janela, "tbQuant"));
                grade.Columns.Add("TAG", LerCaixa(janela, "tbTag"));
                grade.Columns.Add("DESC", LerCaixa(janela, "tbDesc"));
                grade.Columns.Add("MOD", LerCaixa(janela, "tbMod"));
                grade.Columns.Add("FAB", LerCaixa(janela, "tbFab"));
                grade.Columns.Add("COD", LerCaixa(janela, "tbCod"));
                grade.Columns.Add("INDEXLM", string.Empty);
            }
        }

        /// <summary>O que a tela não porta, com o motivo na dica.</summary>
        private static void Motivos(Form janela)
        {
            Desabilitar(janela, "btExportaEXCEL",
                "Exporta para o Excel: a planilha é da pilha de exportação do original, que sai pelo app");
            Desabilitar(janela, "btExportaDWG",
                "Exporta para o DWG: a montagem do bloco é do fluxo de layout do original, que ainda não está portado");
            Desabilitar(janela, "btSalvaOrdem",
                "Salvar a Ordem: a gravação da ordem das linhas no banco ainda não está portada");
            Desabilitar(janela, "btDesagrupar",
                "Desagrupar: mexe na ordem das linhas, que ainda não é editável nesta tela");
            Desabilitar(janela, "btLayout",
                "Ordem Layout: reordena pelas posições do layout, que ainda não está portado");
            Desabilitar(janela, "BTY",
                "Configuração do relatório: a tela de configuração do original ainda não está portada");
            Desabilitar(janela, "btCima",
                "Mover para cima: a ordenação manual das linhas ainda não é editável nesta tela");
            Desabilitar(janela, "btBaixo",
                "Mover para baixo: a ordenação manual das linhas ainda não é editável nesta tela");
            Desabilitar(janela, "btPrimeiro",
                "Mover para o primeiro: a ordenação manual das linhas ainda não é editável nesta tela");
            Desabilitar(janela, "btUltimo",
                "Mover para o último: a ordenação manual das linhas ainda não é editável nesta tela");
            Desabilitar(janela, "ckMultPNDetalhado",
                "Detalhar Quantidade Por Painel: o modo multi-painel (o CarregaDadosDispositivosMultiplosPN) ainda não está portado");
            Desabilitar(janela, "ckMesclarModelo",
                "Mesclar Modelo na Descrição: a mesclagem do texto da descrição ainda não está portada");
            Desabilitar(janela, "ckMesclarFabricante",
                "Mesclar Fabricante na Descrição: a mesclagem do texto da descrição ainda não está portada");
            Desabilitar(janela, "ckDWG2",
                "DWG: o relatório por DWG do original ainda não está portado");
            Desabilitar(janela, "ckExcel2",
                "Excel: a planilha é da pilha de exportação do original, que sai pelo app");
            Desabilitar(janela, "tbMultiplicador",
                "Fator de Multiplicação: o multiplicador de típicos ainda não está portado");
        }

        /// <summary>
        /// A carga do painel escolhido: o <c>dgOrdem</c> com os itens na ordem do diagrama e o
        /// <c>dgListaMateriais</c> com a <see cref="ListaDeMateriaisDoRelatorio"/>.
        /// </summary>
        private static string Carregar(
            DataGridView equipamentos,
            DataGridView ordem,
            DataGridView grade,
            List<LinhaListaMaterial> linhas,
            IReadOnlyDictionary<int, MaterialDoCatalogo> catalogo,
            bool descricaoCompleta)
        {
            if (equipamentos == null || grade == null)
            {
                return "EXPLM: as grades da lista de materiais não estão na tela.";
            }

            int painel = PainelEscolhido(equipamentos);
            if (painel == 0)
            {
                return "EXPLM: escolha o painel na coluna da esquerda.";
            }

            int itens = CarregarOrdem(ordem, linhas, painel);

            List<LinhaDaLMDoRelatorio> lista = ListaDeMateriaisDoRelatorio.Montar(linhas, catalogo, painel, descricaoCompleta);
            grade.Rows.Clear();
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

            return "EXPLM: " + grade.Rows.Count + " linha(s) na Lista de Materiais do painel " + painel
                + " (" + itens + " item(ns) na ordem do diagrama; " + lista.Count
                + " material(is) distinto(s)).";
        }

        /// <summary>
        /// A `dgOrdem` do painel escolhido — o `CarregaDadosOrdemDispositivos`/`formataDGOrdem`: os
        /// itens na **ordem do diagrama** (a `Ordem` que o `COMPLM` renumera 1..N por painel). Devolve
        /// quantos itens entraram.
        /// </summary>
        private static int CarregarOrdem(DataGridView ordem, List<LinhaListaMaterial> linhas, int painel)
        {
            if (ordem == null)
            {
                return 0;
            }

            ordem.Rows.Clear();
            if (painel == 0)
            {
                return 0;
            }

            int itens = 0;
            foreach (LinhaListaMaterial linha in PaineisDaListaDeMateriais.DoPainel(linhas, painel))
            {
                ordem.Rows.Add(linha.Indice, linha.Tag, linha.IndiceMaterial, linha.Ordem, linha.Quantidade, linha.OrdemLay);
                itens++;
            }

            return itens;
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

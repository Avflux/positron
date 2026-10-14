using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Positron.Data;
using Positron.Data.Configuracao;
using Positron.Data.Materiais;

namespace Positron.Plugin.Interface.Telas
{
    /// <summary>
    /// A ligação do <c>frmGerenciadorMatIndep</c> (o comando <c>ATINDEP</c>, "Dispositivos
    /// Independentes e Avulsos"): a coluna <c>dgPaineis</c> com os **painéis da lista de materiais**
    /// do desenho ativo, a grade <c>dgDisp</c> com os itens do painel escolhido — nas doze colunas do
    /// <c>formataDGDisp</c> do original — e, na seleção de um item, as caixas do material
    /// (<c>TBTag</c>, <c>TBQuantidade</c> e as quatro do catálogo, o <c>U7Epp0og4bx</c> +
    /// <c>ODLpp1Gpc7y</c>).
    ///
    /// **A diferença deliberada da rodada 148:** o original monta a lista de painéis varrendo o
    /// ModelSpace (<c>clsLM.PaineisDocumentoLM</c>, o painel de cada entidade por XData); aqui ela sai
    /// da <c>ListaMateriais</c> do desenho — a projeção que o <c>COMPLM</c> já gravou (a regra do
    /// recoder). O painel continua vindo do desenho; o caminho é que não é uma segunda varredura.
    ///
    /// Os itens de <c>dgDisp</c> são as linhas da <c>ListaMateriais</c> do painel, com os mesmos doze
    /// valores na mesma ordem posicional do original (`Indice`, `DWG`, `Painel`, `Tag`,
    /// `IndiceMaterial`, `Quantidade`, `Ordem`, `Avulso`, `Destino`, `DescDestino`, `Alternativo`,
    /// `Handle`) — é o que as regras de cor e de erro do <c>MesclaDGDisp</c> leem nas células 4, 7 e
    /// 11. A **pintura** da grade fica para a rodada que portar a edição, junto com o
    /// <c>frmPesquisaMateriais</c> (o botão de pesquisa do material).
    ///
    /// **Desabilitado com o motivo na dica:** os três botões que gravam a lista (o
    /// <c>AdicionaUmItemMaterialAvulso</c>/<c>EditaUmItemMaterialAvulso</c>/<c>RemoveMaterialAvulso</c>
    /// do original) e o de pesquisa.
    /// </summary>
    internal sealed class LigacaoDoFrmGerenciadorMatIndep : LigacaoDeMateriais
    {
        public override string NomeDaTela
        {
            get { return "frmGerenciadorMatIndep"; }
        }

        public override void Preencher(Form janela)
        {
            DataGridView paineis = ControlesDaTela.Achar<DataGridView>(janela, "dgPaineis");
            DataGridView grade = ControlesDaTela.Achar<DataGridView>(janela, "dgDisp");

            TextosDoOriginal(janela);
            MontarColunas(paineis, grade);

            ConfiguracaoPositron config = ConfiguracaoPositron.Carregar();
            IReadOnlyDictionary<int, MaterialDoCatalogo> catalogo =
                CatalogoDeMateriais.Indexar(Catalogo(config));

            List<LinhaListaMaterial> linhas = LerLista(config, out int dwg);
            IReadOnlyDictionary<int, string> nomes = LerNomesDePaineis(config);

            List<int> doDesenho = PaineisDaListaDeMateriais.Distintos(linhas);
            if (paineis != null)
            {
                paineis.Rows.Clear();
                foreach (int painel in doDesenho)
                {
                    paineis.Rows.Add(painel, NomeDoPainel(nomes, painel));
                }

                paineis.SelectionChanged += (origem, evento) =>
                    CarregarDispositivos(grade, linhas, PainelSelecionado(paineis));

                // O original seleciona a primeira linha ao terminar a carga (o `CarregaDGPainelLM`).
                if (paineis.Rows.Count > 0)
                {
                    paineis.Rows[0].Selected = true;
                }
            }

            if (grade != null)
            {
                grade.SelectionChanged += (origem, evento) => PreencherMaterial(janela, grade, catalogo);
            }

            Motivos(janela);

            // A carga da primeira linha é explícita aqui: num script a tela não é *mostrada*, e a
            // seleção programática não dispara o `SelectionChanged` de um controle sem janela — o
            // original conta com o clique. Assim a tela abre com o painel 1 carregado, como no uso.
            int doPrimeiro = 0;
            string materialDoPrimeiro = string.Empty;
            if (doDesenho.Count > 0)
            {
                doPrimeiro = CarregarDispositivos(grade, linhas, doDesenho[0]);
                materialDoPrimeiro = PreencherMaterial(janela, grade, catalogo);
            }

            Plugin.Escrever("ATINDEP: " + doDesenho.Count + " painel(is) na ListaMateriais do DWG " + dwg
                + " (" + linhas.Count + " item(ns); " + doPrimeiro + " no painel "
                + (doDesenho.Count == 0 ? "-" : doDesenho[0].ToString()) + ")"
                + "; " + catalogo.Count + " material(is) no catálogo"
                + (string.IsNullOrEmpty(materialDoPrimeiro) ? string.Empty : "; primeiro item: " + materialDoPrimeiro)
                + "; os botões que gravam estão desabilitados.");
        }

        /// <summary>Os textos e as dicas que o construtor do original aplica por cima do designer.</summary>
        private static void TextosDoOriginal(Form janela)
        {
            Texto(janela, "GroupBox4", "Materiais");
            Texto(janela, "LbTag", "Dispositivo");
            Texto(janela, "lbQuantidade", "Quantidade");
            Texto(janela, "lbCodigo", "Código");
            Texto(janela, "lbDesc", "Descrição Resumida");
            Texto(janela, "lbModelo", "Modelo");
            Texto(janela, "lbFabricante", "Fabricante");
            Texto(janela, "tbCodigo1", "0");

            Dica(janela, "BTAdicionaLM", "Adiciona Material");
            Dica(janela, "BTEditaLM", "Edita Material Selecionado");
            Dica(janela, "BTApagaLM", "Apaga Material Selecionado");
        }

        /// <summary>
        /// As colunas do <c>formataDGPainelLM</c> e do <c>formataDGDisp</c> do original. A coluna 0 da
        /// grade dos painéis fica **oculta** (o original mostra só o nome e guarda o índice na linha).
        /// </summary>
        private static void MontarColunas(DataGridView paineis, DataGridView grade)
        {
            if (paineis != null)
            {
                paineis.Columns.Clear();
                paineis.Columns.Add("Indice", string.Empty);
                paineis.Columns.Add("Equipamento", "Equipamentos  Painéis");
                paineis.Columns[0].Visible = false;
            }

            if (grade != null)
            {
                grade.Columns.Clear();
                grade.Columns.Add("#", string.Empty);
                grade.Columns.Add("DWG", string.Empty);
                grade.Columns.Add("PN", string.Empty);
                grade.Columns.Add("TAG", "Dispositivo");
                grade.Columns.Add("Material", "Materiais");
                grade.Columns.Add("Quantidade", "Quantidade");
                grade.Columns.Add("Ordem", string.Empty);
                grade.Columns.Add("Avulso", string.Empty);
                grade.Columns.Add("DESC", string.Empty);
                grade.Columns.Add("DESCDEST", string.Empty);
                grade.Columns.Add("Alternativo", string.Empty);
                grade.Columns.Add("indexModelo", string.Empty);
            }
        }

        /// <summary>As linhas da <c>ListaMateriais</c> do desenho ativo (o `CarregaDadosDispositivos` por DWG).</summary>
        private static List<LinhaListaMaterial> LerLista(ConfiguracaoPositron config, out int dwg)
        {
            dwg = config == null ? 0 : config.Dwg;
            if (config == null || string.IsNullOrEmpty(config.Banco))
            {
                return new List<LinhaListaMaterial>();
            }

            try
            {
                return new ProjectStore(config.Banco).LerListaMateriais(config.Dwg);
            }
            catch (Exception erro)
            {
                Plugin.Escrever("ATINDEP: a lista de materiais não veio do banco — " + erro.Message);
                return new List<LinhaListaMaterial>();
            }
        }

        private static IReadOnlyDictionary<int, string> LerNomesDePaineis(ConfiguracaoPositron config)
        {
            if (config == null || string.IsNullOrEmpty(config.Banco))
            {
                return new Dictionary<int, string>();
            }

            try
            {
                return new ProjectStore(config.Banco).LerNomesDePaineis();
            }
            catch (Exception erro)
            {
                Plugin.Escrever("ATINDEP: o cadastro de painéis não veio do banco — " + erro.Message);
                return new Dictionary<int, string>();
            }
        }

        /// <summary>O nome do painel no cadastro e, sem cadastro, o índice — o `BuscaNomeDoPainel` do original.</summary>
        private static string NomeDoPainel(IReadOnlyDictionary<int, string> nomes, int painel)
        {
            string nome;
            if (nomes != null && nomes.TryGetValue(painel, out nome) && !string.IsNullOrEmpty(nome))
            {
                return nome;
            }

            return painel.ToString(System.Globalization.CultureInfo.InvariantCulture);
        }

        private static int PainelSelecionado(DataGridView paineis)
        {
            if (paineis == null || paineis.SelectedRows.Count == 0)
            {
                return 0;
            }

            object valor = paineis.SelectedRows[0].Cells[0].Value;
            if (valor == null)
            {
                return 0;
            }

            int painel;
            return int.TryParse(Convert.ToString(valor), out painel) ? painel : 0;
        }

        /// <summary>
        /// O <c>CarregaDGDisp</c> do original para o painel escolhido: as linhas da lista na ordem
        /// posicional do `Rows.Add` (a edição não entra — só o que o banco já tem).
        /// </summary>
        private static int CarregarDispositivos(DataGridView grade, List<LinhaListaMaterial> linhas, int painel)
        {
            if (grade == null)
            {
                return 0;
            }

            grade.Rows.Clear();
            if (painel == 0)
            {
                return 0;
            }

            foreach (LinhaListaMaterial linha in PaineisDaListaDeMateriais.DoPainel(linhas, painel))
            {
                grade.Rows.Add(
                    linha.Indice,
                    linha.DWG,
                    linha.Painel,
                    linha.Tag,
                    linha.IndiceMaterial,
                    linha.Quantidade,
                    linha.Ordem,
                    linha.Avulso,
                    linha.Destino,
                    linha.DescDestino,
                    linha.Alternativo,
                    linha.Handle);
            }

            if (grade.Rows.Count > 0)
            {
                grade.Rows[0].Selected = true;
            }

            return grade.Rows.Count;
        }

        /// <summary>
        /// A seleção de um item de <c>dgDisp</c> — o `U7Epp0og4bx` + `ODLpp1Gpc7y`: as caixas de tag e
        /// quantidade vêm das células 3 e 5, e as do catálogo da célula 4 (o código interno), que o
        /// original procura no vetor do `CarregaDadosLMMatriz`. Devolve a descrição resumida do
        /// material (vazia quando a célula 4 não casa com o catálogo), para a linha de comando.
        /// </summary>
        private static string PreencherMaterial(
            Form janela,
            DataGridView grade,
            IReadOnlyDictionary<int, MaterialDoCatalogo> catalogo)
        {
            TextoDaCaixa(janela, "TBTag", string.Empty);
            TextoDaCaixa(janela, "TBQuantidade", string.Empty);
            TextoDaCaixa(janela, "tbCodigo1", "0");
            TextoDaCaixa(janela, "tbDescricaoResum1", string.Empty);
            TextoDaCaixa(janela, "tbModelo1", string.Empty);
            TextoDaCaixa(janela, "tbFabricante1", string.Empty);

            if (grade == null || grade.Rows.Count == 0)
            {
                return string.Empty;
            }

            DataGridViewRow linha = grade.SelectedRows.Count > 0 ? grade.SelectedRows[0] : grade.Rows[0];
            TextoDaCaixa(janela, "TBTag", Celula(linha, 3));
            TextoDaCaixa(janela, "TBQuantidade", Celula(linha, 5));

            int codigo;
            if (!int.TryParse(Celula(linha, 4), out codigo))
            {
                return string.Empty;
            }

            MaterialDoCatalogo material = CatalogoDeMateriais.Buscar(catalogo, codigo);
            if (material == null)
            {
                // Acontece de verdade: o `lm == 0` do borne (o `BorneSemLm`) não está no catálogo — é
                // o dado, e a caixa do código fica no `0` que o original deixa.
                return "\"" + Celula(linha, 3) + "\" → material "
                    + codigo.ToString(System.Globalization.CultureInfo.InvariantCulture) + " (fora do catálogo)";
            }

            TextoDaCaixa(janela, "tbCodigo1", material.CodigoInterno.ToString(System.Globalization.CultureInfo.InvariantCulture));
            TextoDaCaixa(janela, "tbDescricaoResum1", material.DescricaoResumida);
            TextoDaCaixa(janela, "tbModelo1", material.Modelo);
            TextoDaCaixa(janela, "tbFabricante1", material.Fabricante);

            return "\"" + Celula(linha, 3) + "\" → " + material.CodigoInterno
                + " \"" + material.DescricaoResumida + "\"";
        }

        private static void Motivos(Form janela)
        {
            Desabilitar(janela, "BTAdicionaLM", "Adiciona Material: grava um item avulso na ListaMateriais");
            Desabilitar(janela, "BTEditaLM", "Edita Material Selecionado: grava na ListaMateriais");
            Desabilitar(janela, "BTApagaLM", "Apaga Material Selecionado: destrutivo — apaga o item da ListaMateriais");
            Desabilitar(janela, "btPesquisaLM1", "Pesquisar: abre o frmPesquisaMateriais, que o recoder ainda não porta");
        }
    }
}

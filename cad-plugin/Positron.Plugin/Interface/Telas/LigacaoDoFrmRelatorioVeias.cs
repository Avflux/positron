using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Positron.Contract;
using Positron.Data;
using Positron.Data.Configuracao;
using Positron.Data.Relatorios;

namespace Positron.Plugin.Interface.Telas
{
    /// <summary>
    /// A ligação da <c>frmRelatorio_Veias</c> (o comando <c>LVEI</c>, "Lista de Veias"): as três
    /// colunas do original — <c>dgRevisao</c> com as revisões do <c>Cabos4</c>, <c>dgEquip</c> com os
    /// painéis da revisão escolhida e <c>dgVeias</c> com a lista — mais o <c>qTotal</c> e o
    /// <c>btPesquisar</c>.
    ///
    /// **A regra é a do recoder** (<see cref="ListaDeVeias"/>), a mesma que o relatório <c>veias</c> do
    /// app monta e mede desde a rodada 65; aqui ela chega à grade do CAD com as quinze colunas do
    /// <c>formataDGCabos</c> (a de <c>COMPRIMENTO</c> só entra com o <c>CBComprimento</c> ligado, como
    /// lá) e com a faixa <c>AntiqueWhite</c> alternando por cabo (o <c>flag</c> do
    /// <c>bqipPxovkmF</c>). Com mais de um painel escolhido, cada painel ganha a linha de cabeçalho
    /// <c>LightBlue</c> com o nome na terceira coluna — o <c>iPainelSel</c> do <c>bSepara</c>.
    ///
    /// **Como o construtor do original** (<c>frmRelatorio_Veias.cs:681</c>): <c>dgRevisao</c> e
    /// <c>dgEquip</c> com colunas desde a abertura, <c>dgVeias</c> **sem colunas** até o
    /// <c>btPesquisar</c> (o <c>formataDGCabos</c> roda ali, com o <c>CBComprimento</c> daquela hora),
    /// <c>qTotal</c> vazio, <c>CKAgrupar</c> desmarcado e a única dica é a do <c>btPesquisar</c> (1411).
    ///
    /// **O que entra desabilitado:** o <c>btExportaEXCEL</c> e os modos <b>Agrupar Cabos Por Painel</b>
    /// e <b>Função da Veia</b>, que no original mudam a montagem (<c>bSepara</c> e o
    /// <c>CarregaFuncoesDaVeias4</c>) — regras ainda não portadas; a tela usa o modo padrão do designer.
    ///
    /// A revisão e o painel saem do primeiro item de cada coluna. Como no original, a lista só sai no
    /// <c>btPesquisar</c>; no harness, <c>POSITRON_REL_REVISAO</c>/<c>POSITRON_REL_PAINEL</c> escolhem e
    /// rodam a mesma carga ao abrir (a receita no RUNBOOK).
    /// </summary>
    internal sealed class LigacaoDoFrmRelatorioVeias : LigacaoDeRelatorio
    {
        /// <summary>O que a tela leu do banco para a revisão escolhida (uma leitura por revisão).</summary>
        private sealed class Estado
        {
            internal string Revisao;
            internal IReadOnlyList<Cabos4Row> Cabos = new List<Cabos4Row>();
            internal IReadOnlyList<Veias4Row> Veias = new List<Veias4Row>();
            internal IReadOnlyList<Interligacao4Row> Trechos = new List<Interligacao4Row>();
            internal IReadOnlyDictionary<int, string> Nomes = new Dictionary<int, string>();
        }

        public override string NomeDaTela
        {
            get { return "frmRelatorio_Veias"; }
        }

        public override void Preencher(Form janela)
        {
            DataGridView revisoes = ControlesDaTela.Achar<DataGridView>(janela, "dgRevisao");
            DataGridView equipamentos = ControlesDaTela.Achar<DataGridView>(janela, "dgEquip");
            DataGridView grade = ControlesDaTela.Achar<DataGridView>(janela, "dgVeias");
            Label total = ControlesDaTela.Achar<Label>(janela, "qTotal");
            CheckBox comprimento = ControlesDaTela.Achar<CheckBox>(janela, "CBComprimento");
            Button pesquisar = ControlesDaTela.Achar<Button>(janela, "btPesquisar");

            bool comComprimento = comprimento != null && comprimento.Checked;
            Colunas(revisoes, equipamentos, grade);
            Motivos(janela);
            Dica(janela, "btPesquisar", "Visualizador de Cabos");
            Texto(janela, "qTotal", string.Empty);

            CheckBox agrupar = ControlesDaTela.Achar<CheckBox>(janela, "CKAgrupar");
            if (agrupar != null)
            {
                agrupar.Checked = false;
            }

            ConfiguracaoPositron config = Configuracao();
            if (config == null || string.IsNullOrEmpty(config.Banco))
            {
                return;
            }

            Estado estado = new Estado();
            List<RevisaoDoDwg> lista = MaisNovaPrimeiro(
                DoBanco("LVEI", () => new ProjectStore(config.Banco).LerRevisoesDeCabos4()));

            if (revisoes != null)
            {
                revisoes.Rows.Clear();
                foreach (RevisaoDoDwg revisao in lista)
                {
                    revisoes.Rows.Add(revisao.Revisao, revisao.Criador, revisao.Data);
                }
            }

            if (lista.Count == 0)
            {
                return;
            }

            int escolhida = IndiceDaRevisao(lista, RevisaoPedida());
            if (revisoes != null)
            {
                revisoes.SelectionChanged += (origem, evento) => TrocarRevisao(
                    janela, revisoes, equipamentos, grade, total, estado, config, comComprimento);
            }

            if (revisoes != null)
            {
                revisoes.Rows[escolhida].Selected = true;
            }

            TrocarRevisao(janela, revisoes, equipamentos, grade, total, estado, config, comComprimento);

            Ligar(pesquisar, (origem, evento) =>
                Carregar(janela, equipamentos, grade, total, estado, config, comComprimento));

            // Harness: um script não clica nem escolhe, então as variáveis `POSITRON_REL_*` escolhem a
            // revisão/o painel e rodam a carga do `btPesquisar` ao abrir.
            if (PainelPedido() != 0 || RevisaoPedida() != null)
            {
                Carregar(janela, equipamentos, grade, total, estado, config, comComprimento);
            }
        }

        /// <summary>
        /// As três colunas do designer no original: o <c>formataDGRevisao</c> (Revisão/Criador/Data), o
        /// <c>formataDGEquip</c> (o índice escondido e os "Equipamentos  Painéis") e o
        /// <c>formataDGCabos</c>, que só roda no <c>btPesquisar</c>: a grade abre sem colunas.
        /// </summary>
        private static void Colunas(DataGridView revisoes, DataGridView equipamentos, DataGridView grade)
        {
            if (revisoes != null)
            {
                revisoes.Rows.Clear();
                revisoes.Columns.Clear();
                revisoes.Columns.Add(string.Empty, "Revisão");
                revisoes.Columns.Add(string.Empty, "Criador");
                revisoes.Columns.Add(string.Empty, "Data");
            }

            if (equipamentos != null)
            {
                equipamentos.Rows.Clear();
                equipamentos.Columns.Clear();
                equipamentos.Columns.Add("Indice", "Indice");
                equipamentos.Columns.Add(string.Empty, "Equipamentos  Painéis");
                equipamentos.Columns[0].Width = 0;
                equipamentos.Columns[0].Visible = false;
            }

            if (grade != null)
            {
                grade.Rows.Clear();
                grade.Columns.Clear();
            }
        }

        /// <summary>O <c>formataDGCabos</c>: as catorze colunas e a do comprimento, quando ligado.</summary>
        private static void ColunasDosCabos(DataGridView grade, bool comComprimento)
        {
            grade.Rows.Clear();
            grade.Columns.Clear();
            grade.Columns.Add(string.Empty, "TAG");
            grade.Columns.Add(string.Empty, "FORMAÇÃO");
            grade.Columns.Add(string.Empty, "FUNÇÃO");
            grade.Columns.Add(string.Empty, "VEIAS");
            grade.Columns.Add(string.Empty, "PAINEL");
            grade.Columns.Add(string.Empty, "DISPOSITIVOS");
            grade.Columns.Add(string.Empty, "BORNE");
            grade.Columns.Add(string.Empty, "ATERRAR");
            grade.Columns.Add(string.Empty, "PAINEL");
            grade.Columns.Add(string.Empty, "DISPOSITIVOS");
            grade.Columns.Add(string.Empty, "BORNE");
            grade.Columns.Add(string.Empty, "ATERRAR");
            grade.Columns.Add(string.Empty, "DOCUMENTO FUNCIONAL");
            grade.Columns.Add(string.Empty, "PÁGINA");
            if (comComprimento)
            {
                grade.Columns.Add(string.Empty, "COMPRIMENTO");
            }
        }

        /// <summary>O que a tela não porta: desabilitado (regra ainda não portada), sem dica — o original não tem.</summary>
        private static void Motivos(Form janela)
        {
            foreach (string nome in new[] { "btExportaEXCEL", "CKAgrupar", "RBFuncaoVeia", "RBSheetDiferente" })
            {
                Control controle = ControlesDaTela.Procurar(janela, nome);
                if (controle != null)
                {
                    controle.Enabled = false;
                }
            }
        }

        /// <summary>Troca a revisão: lê o <c>Cabos4</c>/<c>Veias4</c>/<c>Interligacao4</c> dela e a coluna dos painéis.</summary>
        private static void TrocarRevisao(
            Form janela,
            DataGridView revisoes,
            DataGridView equipamentos,
            DataGridView grade,
            Label total,
            Estado estado,
            ConfiguracaoPositron config,
            bool comComprimento)
        {
            string revisao = RevisaoDaColuna(revisoes);
            if (string.IsNullOrEmpty(revisao))
            {
                return;
            }

            estado.Revisao = revisao;
            estado.Cabos = DoBanco("LVEI", () => new ProjectStore(config.Banco).Cabos4PorRevisao(revisao))
                ?? new List<Cabos4Row>();
            estado.Veias = DoBanco("LVEI", () => new ProjectStore(config.Banco).Veias4PorRevisao(revisao))
                ?? new List<Veias4Row>();
            estado.Trechos = DoBanco("LVEI", () => new ProjectStore(config.Banco).InterligacaoDaRevisao(config.Dwg, revisao))
                ?? new List<Interligacao4Row>();
            estado.Nomes = DoBanco("LVEI", () => new ProjectStore(config.Banco).LerNomesDePaineis())
                ?? new Dictionary<int, string>();

            List<int> paineis = ListaDeVeias.Paineis(estado.Cabos, revisao);
            if (equipamentos == null)
            {
                return;
            }

            equipamentos.Rows.Clear();
            foreach (int painel in paineis)
            {
                equipamentos.Rows.Add(painel, NomeDoPainel(estado, painel));
            }

            if (equipamentos.Rows.Count > 0)
            {
                int pedido = PainelPedido();
                int linha = 0;
                if (pedido != 0 && paineis.Contains(pedido))
                {
                    linha = paineis.IndexOf(pedido);
                }

                equipamentos.Rows[linha].Selected = true;
            }

            if (grade != null)
            {
                grade.Rows.Clear();
            }

            if (total != null)
            {
                total.Text = string.Empty;
            }
        }

        /// <summary>
        /// O clique do <c>btPesquisar</c> (e a carga da abertura): as linhas da <see cref="ListaDeVeias"/>
        /// para cada painel escolhido, com a faixa por cabo e o total de cabos distintos.
        /// </summary>
        private static void Carregar(
            Form janela,
            DataGridView equipamentos,
            DataGridView grade,
            Label total,
            Estado estado,
            ConfiguracaoPositron config,
            bool comComprimento)
        {
            if (grade == null || equipamentos == null || string.IsNullOrEmpty(estado.Revisao))
            {
                return;
            }

            List<int> escolhidos = PaineisEscolhidos(equipamentos);
            if (escolhidos.Count == 0)
            {
                return;
            }

            // `formataDGCabos` roda aqui, com o `CBComprimento` desta hora.
            CheckBox caixaComprimento = ControlesDaTela.Achar<CheckBox>(janela, "CBComprimento");
            comComprimento = caixaComprimento != null && caixaComprimento.Checked;
            ColunasDosCabos(grade, comComprimento);
            foreach (int painel in escolhidos)
            {
                List<LinhaDaListaDeVeias> linhas = ListaDeVeias.Montar(
                    estado.Cabos, estado.Veias, estado.Trechos, estado.Nomes, estado.Revisao, painel);

                if (escolhidos.Count > 1)
                {
                    // A linha de cabeçalho do painel (o `iPainelSel != 0` do `bSepara`): o nome vai na
                    // terceira coluna, e a faixa é `LightBlue`.
                    AdicionarLinha(grade, new LinhaDaListaDeVeias
                    {
                        Funcao = NomeDoPainel(estado, painel),
                    }, comComprimento, Color.LightBlue);
                }

                bool destacar = false;
                string anterior = null;
                foreach (LinhaDaListaDeVeias linha in linhas)
                {
                    if (!string.Equals(anterior, linha.Tag, StringComparison.Ordinal))
                    {
                        anterior = linha.Tag;
                        destacar = !destacar;
                    }

                    AdicionarLinha(grade, linha, comComprimento, destacar ? Color.AntiqueWhite : Color.Empty);
                }

            }

            // O `lCabosUnico` do original é uma lista **compartilhada** entre os painéis escolhidos:
            // o total é a união dos cabos de cada um.
            List<string> cabos = new List<string>();
            foreach (int painelEscolhido in escolhidos)
            {
                foreach (string tag in ListaDeVeias.CabosDoRelatorio(
                    estado.Cabos, estado.Veias, estado.Revisao, painelEscolhido))
                {
                    if (!cabos.Contains(tag))
                    {
                        cabos.Add(tag);
                    }
                }
            }
            if (total != null)
            {
                total.Text = cabos.Count.ToString(System.Globalization.CultureInfo.InvariantCulture);
            }
        }

        /// <summary>Uma linha da grade, na ordem das colunas do <c>formataDGCabos</c>.</summary>
        private static void AdicionarLinha(DataGridView grade, LinhaDaListaDeVeias linha, bool comComprimento, Color faixa)
        {
            object[] celulas = comComprimento
                ? new object[]
                {
                    linha.Tag, linha.Formacao, linha.Funcao, linha.Veia, linha.Painel1, linha.Dispositivo1,
                    linha.Borne1, linha.Aterrar1 ? "X" : string.Empty, linha.Painel2, linha.Dispositivo2,
                    linha.Borne2, linha.Aterrar2 ? "X" : string.Empty, linha.Documento, linha.Pagina,
                    linha.Comprimento,
                }
                : new object[]
                {
                    linha.Tag, linha.Formacao, linha.Funcao, linha.Veia, linha.Painel1, linha.Dispositivo1,
                    linha.Borne1, linha.Aterrar1 ? "X" : string.Empty, linha.Painel2, linha.Dispositivo2,
                    linha.Borne2, linha.Aterrar2 ? "X" : string.Empty, linha.Documento, linha.Pagina,
                };

            int indice = grade.Rows.Add(celulas);
            if (!faixa.IsEmpty)
            {
                grade.Rows[indice].DefaultCellStyle.BackColor = faixa;
            }
        }

        private static List<int> PaineisEscolhidos(DataGridView equipamentos)
        {
            List<int> escolhidos = new List<int>();
            foreach (DataGridViewRow linha in equipamentos.Rows)
            {
                if (!linha.Selected)
                {
                    continue;
                }

                int painel;
                if (int.TryParse(Celula(linha, 0), out painel) && painel != 0 && !escolhidos.Contains(painel))
                {
                    escolhidos.Add(painel);
                }
            }

            return escolhidos;
        }

        private static string RevisaoDaColuna(DataGridView revisoes)
        {
            if (revisoes == null || revisoes.SelectedRows.Count == 0)
            {
                return null;
            }

            return Celula(revisoes.SelectedRows[0], 0);
        }

        private static int IndiceDaRevisao(List<RevisaoDoDwg> lista, string pedida)
        {
            if (string.IsNullOrEmpty(pedida))
            {
                return 0;
            }

            for (int i = 0; i < lista.Count; i++)
            {
                if (string.Equals(lista[i].Revisao, pedida, StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }

            return 0;
        }

        /// <summary>O nome do painel pelo cadastro — o <c>Dicionario.BuscaNomeDoPainel</c>.</summary>
        private static string NomeDoPainel(Estado estado, int painel)
        {
            string nome;
            if (estado.Nomes != null && estado.Nomes.TryGetValue(painel, out nome))
            {
                return nome ?? string.Empty;
            }

            return string.Empty;
        }
    }
}

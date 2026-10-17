using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Positron.Contract;
using Positron.Data;
using Positron.Data.Configuracao;
using Positron.Data.Interligacao;

namespace Positron.Plugin.Interface.Telas
{
    /// <summary>
    /// A ligação do <c>frmEstatisticaDeCabos</c> (o comando <c>ESTVCABOS</c>): a grade <c>dg</c> com a
    /// <see cref="EstatisticaDeCabos"/> do banco do projeto e os três radiobuttons que escolhem o
    /// agrupamento (<c>RBFormacao</c>, <c>RBFuncao</c>, <c>RBTrajeto</c>). Cada radio fica habilitado
    /// só se houver algum valor para o agrupamento (<c>frmEstatisticaDeCabos.cs</c>, construtor).
    ///
    /// Textos (<c>mMensagem</c>): título 1756 ("Estatística de Cabos Utilizados") e 1757 ("... por: ")
    /// com o nome do agrupamento (1285 Formação, 1430 Função, 1248 Trajeto); colunas "# " + 514
    /// ("Cabos"), o agrupamento e 1246 (Comprimento). As larguras são as do <c>qnPkkbgPBU</c>: 90 px
    /// na contagem e o resto em 70/30.
    ///
    /// O botão <c>btExportaEXCEL</c> não é ligado aqui (a exportação ainda não foi portada; ver a rodada 217).
    ///
    /// **Como a tela é medida num script:** não há clique, então <c>POSITRON_ESTATISTICA</c> (o
    /// agrupamento: <c>formacao</c>, <c>funcao</c> ou <c>trajeto</c>) marca o radio e escreve a grade
    /// na linha de comando — o gancho do harness, como o <c>POSITRON_ANALISAR</c> das telas de
    /// compilação, e só ele escreve o resultado. Sem a variável, nada é escrito.
    /// </summary>
    internal sealed class LigacaoDoFrmEstatisticaDeCabos : ILigacaoDeTela
    {
        public string NomeDaTela
        {
            get { return "frmEstatisticaDeCabos"; }
        }

        public void Preencher(Form janela)
        {
            DataGridView grade = ControlesDaTela.Achar<DataGridView>(janela, "dg");
            RadioButton formacao = ControlesDaTela.Achar<RadioButton>(janela, "RBFormacao");
            RadioButton funcao = ControlesDaTela.Achar<RadioButton>(janela, "RBFuncao");
            RadioButton trajeto = ControlesDaTela.Achar<RadioButton>(janela, "RBTrajeto");
            if (grade == null || formacao == null || funcao == null || trajeto == null)
            {
                return;
            }

            janela.Text = "Estatística de Cabos Utilizados";

            IReadOnlyList<CabosRow> cabos;
            IReadOnlyList<VeiasRow> veias;
            LerCabosEVeias(out cabos, out veias);

            formacao.Enabled = EstatisticaDeCabos.Calcular(cabos, veias, AgrupamentoDeCabos.Formacao).Count > 0;
            funcao.Enabled = EstatisticaDeCabos.Calcular(cabos, veias, AgrupamentoDeCabos.Funcao).Count > 0;
            trajeto.Enabled = EstatisticaDeCabos.Calcular(cabos, veias, AgrupamentoDeCabos.Trajeto).Count > 0;

            grade.MultiSelect = true;
            grade.ReadOnly = true;

            Action atualizar = () => Mostrar(janela, grade, cabos, veias, Atual(formacao, funcao, trajeto));
            formacao.CheckedChanged += (origem, evento) => atualizar();
            funcao.CheckedChanged += (origem, evento) => atualizar();
            trajeto.CheckedChanged += (origem, evento) => atualizar();
            janela.Resize += (origem, evento) => AjustarColunas(grade);

            formacao.Checked = true;
            atualizar();

            GanchoDoHarness(janela, grade, cabos, veias, formacao, funcao, trajeto);
        }

        /// <summary>
        /// O gancho do harness (um script não clica no radio): <c>POSITRON_ESTATISTICA</c> escolhe o
        /// agrupamento e escreve a grade na linha de comando. Sem a variável, nada acontece.
        /// </summary>
        private static void GanchoDoHarness(Form janela, DataGridView grade, IReadOnlyList<CabosRow> cabos,
            IReadOnlyList<VeiasRow> veias, RadioButton formacao, RadioButton funcao, RadioButton trajeto)
        {
            string escolha = Environment.GetEnvironmentVariable("POSITRON_ESTATISTICA");
            if (string.IsNullOrEmpty(escolha))
            {
                return;
            }

            string nome = escolha.Trim().ToLowerInvariant();
            if (nome == "funcao")
            {
                funcao.Checked = true;
            }
            else if (nome == "trajeto")
            {
                trajeto.Checked = true;
            }
            else
            {
                formacao.Checked = true;
            }

            AgrupamentoDeCabos agrupamento = Atual(formacao, funcao, trajeto);
            Mostrar(janela, grade, cabos, veias, agrupamento);

            List<string> linhas = new List<string>();
            foreach (LinhaEstatisticaCabos linha in EstatisticaDeCabos.Calcular(cabos, veias, agrupamento))
            {
                linhas.Add(linha.Nome + "=" + linha.Quantidade + "/" + linha.Comprimento.ToString());
            }

            Plugin.Escrever("ESTCABOS: " + Rotulo(agrupamento) + " — " + linhas.Count + " linha(s)"
                + "; habilitados: " + Habilitados(formacao, funcao, trajeto)
                + "; grade: " + string.Join(" | ", linhas.ToArray()));
        }

        private static string Habilitados(RadioButton formacao, RadioButton funcao, RadioButton trajeto)
        {
            List<string> nomes = new List<string>();
            if (formacao.Enabled)
            {
                nomes.Add("Formação");
            }

            if (funcao.Enabled)
            {
                nomes.Add("Função");
            }

            if (trajeto.Enabled)
            {
                nomes.Add("Trajeto");
            }

            return nomes.Count == 0 ? "nenhum" : string.Join(", ", nomes.ToArray());
        }

        private static void Mostrar(Form janela, DataGridView grade, IReadOnlyList<CabosRow> cabos,
            IReadOnlyList<VeiasRow> veias, AgrupamentoDeCabos agrupamento)
        {
            string rotulo = Rotulo(agrupamento);
            janela.Text = "Estatística de Cabos Utilizados por: " + rotulo;

            grade.Rows.Clear();
            grade.Columns.Clear();
            grade.Columns.Add("", "# Cabos");
            grade.Columns.Add("", rotulo);
            grade.Columns.Add("", "Comprimento");

            foreach (LinhaEstatisticaCabos linha in EstatisticaDeCabos.Calcular(cabos, veias, agrupamento))
            {
                grade.Rows.Add(linha.Quantidade, linha.Nome, linha.Comprimento.ToString());
            }

            AjustarColunas(grade);
        }

        private static void AjustarColunas(DataGridView grade)
        {
            if (grade.Columns.Count < 3)
            {
                return;
            }

            bool haBarraVertical = grade.RowCount > grade.DisplayedRowCount(false);
            double largura = grade.Width - (haBarraVertical ? 22 : 5) - 90;
            grade.Columns[0].Width = 90;
            grade.Columns[1].Width = (int)Math.Round(largura * 0.7);
            grade.Columns[2].Width = (int)Math.Round(largura * 0.3);
        }

        private static AgrupamentoDeCabos Atual(RadioButton formacao, RadioButton funcao, RadioButton trajeto)
        {
            if (funcao.Checked)
            {
                return AgrupamentoDeCabos.Funcao;
            }

            if (trajeto.Checked)
            {
                return AgrupamentoDeCabos.Trajeto;
            }

            return AgrupamentoDeCabos.Formacao;
        }

        private static string Rotulo(AgrupamentoDeCabos agrupamento)
        {
            switch (agrupamento)
            {
                case AgrupamentoDeCabos.Funcao:
                    return "Função";
                case AgrupamentoDeCabos.Trajeto:
                    return "Trajeto";
                default:
                    return "Formação";
            }
        }

        private static void LerCabosEVeias(out IReadOnlyList<CabosRow> cabos, out IReadOnlyList<VeiasRow> veias)
        {
            cabos = new List<CabosRow>();
            veias = new List<VeiasRow>();

            ConfiguracaoPositron config = ConfiguracaoEfetiva.Carregar();
            if (config == null || string.IsNullOrEmpty(config.Banco))
            {
                return;
            }

            try
            {
                ProjectStore loja = new ProjectStore(config.Banco);
                cabos = loja.LerCabos();
                veias = loja.LerVeias();
            }
            catch (Exception)
            {
                // Sem banco legível a tela abre vazia, como o original sem linhas (`CDadosAccessInterligacao`).
                cabos = new List<CabosRow>();
                veias = new List<VeiasRow>();
            }
        }
    }
}

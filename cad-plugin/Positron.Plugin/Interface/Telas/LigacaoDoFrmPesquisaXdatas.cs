using System.Collections.Generic;
using System.Windows.Forms;
using Positron.Data.Limpeza;

namespace Positron.Plugin.Interface
{
    /// <summary>
    /// A ligação do <c>frmPesquisaXdatas</c> (o comando <c>APAGARXDATA</c> do original): a grade
    /// lista os app names de XData do desenho com a contagem de entidades (o `DTXp66plP1w` do
    /// original), o `BtPesquisa` recarrega e o `BtApaga` troca o XData dos escolhidos pela marca
    /// única (o `ApagaxDatasSelecionados`).
    ///
    /// Este arquivo é o **molde** de uma ligação de tela: o `NomeDaTela` é o do `frm*` do original
    /// (a chave do mapa) e o `Preencher` acha os controles pelo `Name` do designer e os liga à
    /// regra do recoder.
    /// </summary>
    internal sealed class LigacaoDoFrmPesquisaXdatas : ILigacaoDeTela
    {
        public string NomeDaTela
        {
            get { return "frmPesquisaXdatas"; }
        }

        public void Preencher(Form janela)
        {
            DataGridView grade = ControlesDaTela.Achar<DataGridView>(janela, "DG");
            if (grade == null)
            {
                return;
            }

            Button pesquisar = ControlesDaTela.Achar<Button>(janela, "BtPesquisa");
            Button apagar = ControlesDaTela.Achar<Button>(janela, "BtApaga");
            CheckBox incluir = ControlesDaTela.Achar<CheckBox>(janela, "CkXdataEletron");

            // O construtor do original desmarca E esconde o "Incluir xData Eletron": o filtro dos
            // app names do produto fica sempre ligado (fidelidade registrada no mapa).
            if (incluir != null)
            {
                incluir.Checked = false;
                incluir.Visible = false;
            }

            if (pesquisar != null)
            {
                pesquisar.Click += (origem, evento) => CarregarXDatas(grade, incluir);
            }

            if (apagar != null)
            {
                apagar.Click += (origem, evento) => ApagarXDatas(grade, incluir);
            }

            CarregarXDatas(grade, incluir);
        }

        private static void CarregarXDatas(DataGridView grade, CheckBox incluir)
        {
            grade.Rows.Clear();

            // O `e4vp6t1s1VL` do original: a grade aceita multipla selecao e a coluna 0 vira
            // editavel a cada carga.
            grade.MultiSelect = true;
            if (grade.Columns.Count > 0)
            {
                grade.Columns[0].ReadOnly = false;
            }

            bool incluirEletron = incluir != null && incluir.Checked;
            IReadOnlyList<ContagemDeXData> contagens = XDatasDoDesenho.Contar(Limpeza.XDatasDoCad.LerNomePorEntidade(), incluirEletron);
            foreach (ContagemDeXData contagem in contagens)
            {
                grade.Rows.Add(contagem.Nome, contagem.Quantidade);
            }

            // a medida fica na linha de comando: e por ela que o harness ve o que a tela leu
            List<string> nomes = new List<string>();
            int mostrados = 0;
            foreach (ContagemDeXData contagem in contagens)
            {
                if (mostrados == 8)
                {
                    nomes.Add("...");
                    break;
                }

                nomes.Add(contagem.Nome + " (" + contagem.Quantidade + ")");
                mostrados++;
            }

            Plugin.Escrever("APAGARXDATA: " + contagens.Count + " app name(s) de XData na grade"
                + (incluirEletron ? " (incluindo os do Elétron)" : " (só os de terceiros)")
                + (nomes.Count > 0 ? ": " + string.Join(", ", nomes.ToArray()) : string.Empty) + ".");
        }

        private static void ApagarXDatas(DataGridView grade, CheckBox incluir)
        {
            List<string> escolhidos = new List<string>();
            foreach (DataGridViewRow linha in grade.SelectedRows)
            {
                if (linha.Cells.Count > 0 && linha.Cells[0].Value != null)
                {
                    escolhidos.Add(linha.Cells[0].Value.ToString());
                }
            }

            int apagados = Limpeza.XDatasDoCad.Apagar(escolhidos);
            CarregarXDatas(grade, incluir);

            // O original fecha com um MsgBox ("N xData apagados"); aqui vai para a linha de
            // comando, que o harness le.
            Plugin.Escrever("APAGARXDATA: " + apagados + " xData apagado(s).");
        }
    }
}

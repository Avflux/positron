using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Positron.Data.Limpeza;

namespace Positron.Plugin.Interface.Telas
{
    /// <summary>
    /// A ligação do <c>frmPesquisaXdatas</c> (o comando <c>APAGARXDATA</c> do original): a grade
    /// lista os app names de XData do desenho com a contagem de entidades (o `DTXp66plP1w` do
    /// original), o `BtPesquisa` recarrega e o `BtApaga` troca o XData dos escolhidos pela marca
    /// única (o `ApagaxDatasSelecionados`).
    ///
    /// Como o original (`frmPesquisaXdatas.cs`): `MinimumSize 320×500`, larguras 70/30%, e o
    /// resultado do apagar num `MsgBox` ("N xData apagados").
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

            // Do designer: largura presa em 320, altura de 500 a 1500.
            janela.MinimumSize = new Size(320, 500);
            janela.MaximumSize = new Size(320, 1500);

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

            Larguras(grade);
        }

        /// <summary>
        /// O `wRjp6jaJG6g`: 70% / 30% da largura menos 4 (ou menos 21 com a barra de rolagem).
        /// </summary>
        private static void Larguras(DataGridView grade)
        {
            if (grade.Columns.Count < 2)
            {
                return;
            }

            VScrollBar barra = grade.Controls.OfType<VScrollBar>().FirstOrDefault();
            double util = grade.Width - (barra != null && barra.Visible ? 21 : 4);
            grade.Columns[0].Width = (int)Math.Round(util * 0.7);
            grade.Columns[1].Width = (int)Math.Round(util * 0.3);
        }

        private static void ApagarXDatas(DataGridView grade, CheckBox incluir)
        {
            // O original varre as linhas pela ordem da grade (`Rows[i].Selected`).
            List<string> escolhidos = new List<string>();
            foreach (DataGridViewRow linha in grade.Rows)
            {
                if (linha.Selected)
                {
                    escolhidos.Add(Convert.ToString(linha.Cells[0].Value));
                }
            }

            int apagados = Limpeza.XDatasDoCad.Apagar(escolhidos);
            CarregarXDatas(grade, incluir);
            Aviso.MsgBox(apagados + " xData apagados", string.Empty);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using Positron.Data.Modelos;
using Positron.Plugin.Modelos;

namespace Positron.Plugin.Interface
{
    /// <summary>
    /// A ligação do <c>frmEstatisticaDeBornes</c> (o comando <c>STATBORN</c>): a grade por régua (a
    /// mesma conta do comando, a do `clsReguasDeBornes.SomaOsBornes`) e os sete totais do rodapé —
    /// usados simples/reserva, duplos e o total — sobre as linhas **selecionadas** (ou todas, quando
    /// nada está selecionado: o `calculaSelecionado` do original).
    ///
    /// As **colunas** desta grade não estão no designer nem nas rotinas do formulário: o original as
    /// cria dentro do `clsReguasDeBornes`, que o recoder não porta. Aqui entram as do relatório do
    /// recoder (o `Cabecalho` do <see cref="EstatisticaDeBornes"/>).
    /// </summary>
    internal sealed class LigacaoDoFrmEstatisticaDeBornes : ILigacaoDeTela
    {
        public string NomeDaTela
        {
            get { return "frmEstatisticaDeBornes"; }
        }

        public void Preencher(Form janela)
        {
            DataGridView grade = ControlesDaTela.Achar<DataGridView>(janela, "dgReguas");
            if (grade == null)
            {
                return;
            }

            if (grade.Columns.Count == 0)
            {
                grade.Columns.Add("indice", "Régua");
                grade.Columns.Add("painel", "Painel");
                grade.Columns.Add("nome", "Nome");
                grade.Columns.Add("usoS", "US");
                grade.Columns.Add("resS", "RS");
                grade.Columns.Add("usoD", "UD");
                grade.Columns.Add("resD", "RD");
                grade.Columns.Add("total", "Total");
            }

            EstatisticaDeBornesDoDesenho.Resultado resultado = EstatisticaDeBornesDoDesenho.Calcular();

            grade.Rows.Clear();
            foreach (LinhaDeEstatistica linha in resultado.Linhas)
            {
                grade.Rows.Add(linha.IndiceRegua, linha.Painel, linha.NomeRegua, linha.UsoS, linha.ResS, linha.UsoD, linha.ResD, linha.Total);
            }

            TextBox filtro = ControlesDaTela.Achar<TextBox>(janela, "TBPesquisa");
            if (filtro != null)
            {
                filtro.TextChanged += (origem, evento) => FiltrarReguas(grade, filtro, resultado);
            }

            grade.SelectionChanged += (origem, evento) => RecalcularTotais(janela, grade);
            RecalcularTotais(janela, grade);
        }

        private static void FiltrarReguas(DataGridView grade, TextBox filtro, EstatisticaDeBornesDoDesenho.Resultado resultado)
        {
            string alvo = (filtro.Text ?? string.Empty).Trim();
            grade.Rows.Clear();

            foreach (LinhaDeEstatistica linha in resultado.Linhas)
            {
                if (alvo.Length > 0
                    && (linha.NomeRegua ?? string.Empty).IndexOf(alvo, StringComparison.OrdinalIgnoreCase) < 0
                    && (linha.Painel ?? string.Empty).IndexOf(alvo, StringComparison.OrdinalIgnoreCase) < 0
                    && linha.IndiceRegua.ToString().IndexOf(alvo, StringComparison.Ordinal) < 0)
                {
                    continue;
                }

                grade.Rows.Add(linha.IndiceRegua, linha.Painel, linha.NomeRegua, linha.UsoS, linha.ResS, linha.UsoD, linha.ResD, linha.Total);
            }

            RecalcularTotais(grade.FindForm(), grade);
        }

        /// <summary>
        /// Os sete rótulos do rodapé: usados/reserva simples, usados/reserva duplos, o total simples
        /// (`TS` = US + RS), o total duplo (`TD` = UD + RD) e o total geral — o `mQuantBornes` do
        /// original.
        /// </summary>
        private static void RecalcularTotais(Form janela, DataGridView grade)
        {
            if (janela == null || grade == null)
            {
                return;
            }

            List<DataGridViewRow> linhas = new List<DataGridViewRow>();
            foreach (DataGridViewRow linha in grade.Rows)
            {
                if (linha.Selected)
                {
                    linhas.Add(linha);
                }
            }

            if (linhas.Count == 0)
            {
                foreach (DataGridViewRow linha in grade.Rows)
                {
                    linhas.Add(linha);
                }
            }

            int usoS = 0;
            int resS = 0;
            int usoD = 0;
            int resD = 0;
            foreach (DataGridViewRow linha in linhas)
            {
                usoS += Numero(linha, 3);
                resS += Numero(linha, 4);
                usoD += Numero(linha, 5);
                resD += Numero(linha, 6);
            }

            Rotulo(janela, "qBorneUS", usoS);
            Rotulo(janela, "qBorneRS", resS);
            Rotulo(janela, "qBorneTS", usoS + resS);
            Rotulo(janela, "qBorneUD", usoD);
            Rotulo(janela, "qBorneRD", resD);
            Rotulo(janela, "qBorneTD", usoD + resD);
            Rotulo(janela, "qBorneTotal", usoS + resS + usoD + resD);
        }

        private static int Numero(DataGridViewRow linha, int coluna)
        {
            if (coluna >= linha.Cells.Count || linha.Cells[coluna].Value == null)
            {
                return 0;
            }

            int valor;
            return int.TryParse(linha.Cells[coluna].Value.ToString(), out valor) ? valor : 0;
        }

        private static void Rotulo(Form janela, string nome, int valor)
        {
            Label rotulo = ControlesDaTela.Achar<Label>(janela, nome);
            if (rotulo != null)
            {
                rotulo.Text = valor.ToString(CultureInfo.InvariantCulture);
            }
        }
    }
}

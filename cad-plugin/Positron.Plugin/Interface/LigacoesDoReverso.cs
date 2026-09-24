using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Positron.Data.Interface;
using Positron.Data.Limpeza;
using Positron.Data.Modelos;

namespace Positron.Plugin.Interface
{
    /// <summary>
    /// As **ligações** das telas do reverso: para as janelas cuja **regra já está portada**, liga
    /// os controles do designer (que o <see cref="JanelaDoReverso"/> reconstrói fielmente) à regra
    /// pura do <c>Positron.Data</c>. É a "casca fina" da regra de ouro do §7.7 do plano.
    ///
    /// As telas que **não** estão aqui abrem com a casca fiel e sem comportamento — o que a rodada
    /// entrega é a formatação, e cada ligação entra quando a regra dela existe.
    ///
    /// Duas diferenças deliberadas em relação ao original, as duas para não travar:
    ///
    /// - onde o original mostra um `MsgBox` de confirmação/resultado (o "N xData apagados"), o
    ///   recoder **escreve na linha de comando** — um `MsgBox` num script não tem quem o feche;
    /// - onde o original lê o banco para montar a tela, aqui entra a **regra do recoder** (a mesma
    ///   que o comando equivalente já usa e que já foi medida no desenho real).
    /// </summary>
    internal static class LigacoesDoReverso
    {
        /// <summary>Liga uma tela pelo nome, quando há ligação. Nunca lança.</summary>
        internal static void Preencher(Form janela, Tela tela)
        {
            if (janela == null || tela == null)
            {
                return;
            }

            try
            {
                switch (tela.Nome)
                {
                    case "frmPesquisaXdatas":
                        PesquisaXDatas(janela);
                        break;
                    case "frmEstatisticaDeBornes":
                        EstatisticaDeBornes(janela);
                        break;
                }
            }
            catch (Exception erro)
            {
                Plugin.Escrever("LIGACAO: \"" + tela.Nome + "\" falhou — " + erro.Message + ".");
            }
        }

        // ---------------------------------------------------------------- frmPesquisaXdatas (APAGARXDATA)

        /// <summary>
        /// O <c>frmPesquisaXdatas</c> do <c>APAGARXDATA</c>: a grade lista os app names de XData do
        /// desenho com a contagem de entidades (o `DTXp66plP1w` do original), o `BtPesquisa`
        /// recarrega e o `BtApaga` troca o XData dos escolhidos pela marca única (o
        /// `ApagaxDatasSelecionados`).
        /// </summary>
        private static void PesquisaXDatas(Form janela)
        {
            DataGridView grade = Achar<DataGridView>(janela, "DG");
            if (grade == null)
            {
                return;
            }

            Button pesquisar = Achar<Button>(janela, "BtPesquisa");
            Button apagar = Achar<Button>(janela, "BtApaga");
            CheckBox incluir = Achar<CheckBox>(janela, "CkXdataEletron");

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

        // ---------------------------------------------------------------- frmEstatisticaDeBornes (STATBORN)

        /// <summary>
        /// O <c>frmEstatisticaDeBornes</c>: a grade por régua (a mesma conta do comando
        /// <c>STATBORN</c>, a do <c>clsReguasDeBornes.SomaOsBornes</c>) e os sete totais do rodapé
        /// — usados simples/reserva, duplos e o total — sobre as linhas **selecionadas** (ou todas,
        /// quando nada está selecionado: o `calculaSelecionado` do original).
        ///
        /// As **colunas** desta grade não estão no designer nem nas rotinas do formulário: o
        /// original as cria dentro do <c>clsReguasDeBornes</c>, que o recoder não porta. Aqui
        /// entram as do relatório do recoder (o `Cabecalho` do <see cref="EstatisticaDeBornes"/>).
        /// </summary>
        private static void EstatisticaDeBornes(Form janela)
        {
            DataGridView grade = Achar<DataGridView>(janela, "dgReguas");
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

            Modelos.EstatisticaDeBornesDoDesenho.Resultado resultado = Modelos.EstatisticaDeBornesDoDesenho.Calcular();

            grade.Rows.Clear();
            foreach (LinhaDeEstatistica linha in resultado.Linhas)
            {
                grade.Rows.Add(linha.IndiceRegua, linha.Painel, linha.NomeRegua, linha.UsoS, linha.ResS, linha.UsoD, linha.ResD, linha.Total);
            }

            TextBox filtro = Achar<TextBox>(janela, "TBPesquisa");
            if (filtro != null)
            {
                filtro.TextChanged += (origem, evento) => FiltrarReguas(grade, filtro, resultado);
            }

            grade.SelectionChanged += (origem, evento) => RecalcularTotais(janela, grade);
            RecalcularTotais(janela, grade);
        }

        private static void FiltrarReguas(DataGridView grade, TextBox filtro, Modelos.EstatisticaDeBornesDoDesenho.Resultado resultado)
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
            Label rotulo = Achar<Label>(janela, nome);
            if (rotulo != null)
            {
                rotulo.Text = valor.ToString(System.Globalization.CultureInfo.InvariantCulture);
            }
        }

        // ---------------------------------------------------------------- o achador

        /// <summary>O controle pelo `Name` do designer, em qualquer nível de aninhamento.</summary>
        private static T Achar<T>(Control raiz, string nome) where T : Control
        {
            return Procurar(raiz, nome) as T;
        }

        private static Control Procurar(Control raiz, string nome)
        {
            if (raiz == null)
            {
                return null;
            }

            if (string.Equals(raiz.Name, nome, StringComparison.Ordinal))
            {
                return raiz;
            }

            foreach (Control filho in raiz.Controls)
            {
                Control achado = Procurar(filho, nome);
                if (achado != null)
                {
                    return achado;
                }
            }

            return null;
        }
    }
}

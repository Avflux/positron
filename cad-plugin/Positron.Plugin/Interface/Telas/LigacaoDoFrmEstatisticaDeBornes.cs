using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Positron.Data;
using Positron.Data.Configuracao;
using Positron.Data.Modelos;
using Positron.Plugin.Modelos;

namespace Positron.Plugin.Interface.Telas
{
    /// <summary>
    /// A ligação do <c>frmEstatisticaDeBornes</c> (o comando <c>STATBORN</c>): a grade por régua (a
    /// mesma conta do comando, a do `clsReguasDeBornes.SomaOsBornes`) e os sete totais do rodapé —
    /// usados/reserva simples e duplos, os totais simples/duplo e o geral — sobre as linhas
    /// **selecionadas** (<c>clsReguasDeBornes.calculaSelecionado</c>, <c>:26</c>).
    ///
    /// As colunas e o filtro são os do <c>clsReguasDeBornes.carregaEstatisticaNoDG</c> (<c>:58</c>):
    /// `#` (oculta), Painel (1081, pelo nome do cadastro), Régua (1043), Simples (1078), Reserva
    /// (1049), Duplo (1079), Reserva (1049), Total (1080); o filtro casa por "contém" o nome do
    /// painel ou da régua, sem diferenciar maiúsculas. O <c>AtualizaColunasDGEstatistica</c>
    /// (<c>:101</c>) fixa as larguras 25/20/10/10/10/10/15%, liga a seleção múltipla e **seleciona
    /// todas as linhas** — a cada carga e a cada redimensionamento.
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

            // O construtor do original: `clsAuxiliar.BancoValido()` (MsgBox 328/329) e, sem o DWG
            // cadastrado (`arqAtivo.Indice == 0`), a mMensagem 331. Nos dois casos a tela não abre.
            if (!InicioDoDesenho.BancoValido(true))
            {
                janela.Dispose();
                return;
            }

            ConfiguracaoPositron config = ConfiguracaoEfetiva.Carregar();
            if (config.Dwg == 0)
            {
                Aviso.MsgBox("Este arquivo ainda não foi cadastrado no banco do projeto!", string.Empty);
                janela.Dispose();
                return;
            }

            // Do designer (`frmEstatisticaDeBornes.cs`): largura presa em 450 e colunas reordenáveis.
            janela.MinimumSize = new Size(450, 540);
            janela.MaximumSize = new Size(450, 1200);
            grade.AllowUserToOrderColumns = true;

            EstatisticaDeBornesDoDesenho.Resultado resultado = EstatisticaDeBornesDoDesenho.Calcular();
            IReadOnlyDictionary<int, string> nomesDePaineis = LerNomesDePaineis(config);
            TextBox filtro = ControlesDaTela.Achar<TextBox>(janela, "TBPesquisa");

            Carregar(grade, resultado, nomesDePaineis, filtro == null ? string.Empty : filtro.Text);
            MostrarSelecionado(janela, grade);

            if (filtro != null)
            {
                // O `fALCfcTcWb` do original (KeyUp): maiúsculas, recarrega e refaz os totais.
                filtro.KeyUp += (origem, evento) =>
                {
                    filtro.Text = filtro.Text.ToUpper();
                    Carregar(grade, resultado, nomesDePaineis, filtro.Text);
                    MostrarSelecionado(janela, grade);
                };
            }

            grade.KeyUp += (origem, evento) => MostrarSelecionado(janela, grade);
            grade.MouseUp += (origem, evento) => MostrarSelecionado(janela, grade);
            janela.Resize += (origem, evento) => AjustarColunas(grade);
        }

        /// <summary>O <c>carregaEstatisticaNoDG</c>: colunas, linhas filtradas e o ajuste final.</summary>
        private static void Carregar(DataGridView grade, EstatisticaDeBornesDoDesenho.Resultado resultado,
            IReadOnlyDictionary<int, string> nomesDePaineis, string pesquisa)
        {
            grade.Rows.Clear();
            grade.Columns.Clear();
            grade.Columns.Add("IndiceRegua", "#");
            grade.Columns.Add("Painel", "Painel");
            grade.Columns.Add("Regua", "Régua");
            grade.Columns.Add("UsoS", "Simples");
            grade.Columns.Add("ResS", "Reserva");
            grade.Columns.Add("UsoD", "Duplo");
            grade.Columns.Add("ResD", "Reserva");
            grade.Columns.Add("Total", "Total");
            grade.ColumnHeadersVisible = true;

            string alvo = (pesquisa ?? string.Empty).ToUpperInvariant();
            foreach (LinhaDeEstatistica linha in resultado.Linhas)
            {
                int indicePainel;
                string painel;
                if (!int.TryParse(linha.Painel, out indicePainel) || !nomesDePaineis.TryGetValue(indicePainel, out painel))
                {
                    painel = "???";
                }

                if (painel.ToUpperInvariant().Contains(alvo) || (linha.NomeRegua ?? string.Empty).ToUpperInvariant().Contains(alvo))
                {
                    int novo = grade.Rows.Add(linha.IndiceRegua, painel, linha.NomeRegua, linha.UsoS, linha.ResS, linha.UsoD, linha.ResD, linha.Total);
                    grade.Rows[novo].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }

            AjustarColunas(grade);
        }

        /// <summary>O <c>AtualizaColunasDGEstatistica</c>: larguras, colunas visíveis e todas as linhas selecionadas.</summary>
        private static void AjustarColunas(DataGridView grade)
        {
            if (grade.RowCount == 0 || grade.Columns.Count < 8)
            {
                return;
            }

            double largura = HaBarraVertical(grade) ? grade.Width - 21 : grade.Width - 4;
            double[] fatores = { 0, 0.25, 0.2, 0.1, 0.1, 0.1, 0.1, 0.15 };
            for (int i = 0; i < 8; i++)
            {
                grade.Columns[i].Width = (int)Math.Round(largura * fatores[i]);
                grade.Columns[i].Visible = i != 0;
                grade.Columns[i].ReadOnly = false;
            }

            grade.MultiSelect = true;
            foreach (DataGridViewRow linha in grade.Rows)
            {
                linha.Selected = true;
            }
        }

        private static bool HaBarraVertical(DataGridView grade)
        {
            foreach (Control controle in grade.Controls)
            {
                if (controle is VScrollBar && controle.Visible)
                {
                    return true;
                }
            }

            return false;
        }

        private static IReadOnlyDictionary<int, string> LerNomesDePaineis(ConfiguracaoPositron config)
        {
            try
            {
                return new ProjectStore(config.Banco).LerNomesDePaineis();
            }
            catch (Exception)
            {
                // `Dicionario.BuscaNomeDoPainel` (`Dicionario.cs:47`) engole o erro e devolve "???".
                return new Dictionary<int, string>();
            }
        }

        /// <summary>
        /// O <c>MostraSelecionado</c> (<c>frmEstatisticaDeBornes.cs</c>): os sete rótulos do rodapé
        /// somam **só as linhas selecionadas** (nenhuma selecionada = tudo zero).
        /// </summary>
        private static void MostrarSelecionado(Form janela, DataGridView grade)
        {
            int usoS = 0;
            int resS = 0;
            int usoD = 0;
            int resD = 0;
            foreach (DataGridViewRow linha in grade.Rows)
            {
                if (!linha.Selected)
                {
                    continue;
                }

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

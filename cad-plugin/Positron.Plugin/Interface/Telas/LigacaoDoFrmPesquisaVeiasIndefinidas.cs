using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Positron.Data;
using Positron.Data.Configuracao;
using Positron.Data.Interligacao;
using Positron.Plugin.Interligacao;

namespace Positron.Plugin.Interface.Telas
{
    /// <summary>
    /// A ligação do <c>frmPesquisaVeiasIndefinidas</c> (o comando <c>PESQC</c>): a grade
    /// <c>dgVeiasDWG</c> com as <see cref="VeiasIndefinidasDoCaderno"/> do desenho ativo (colunas
    /// do <c>formataDGVeiasDWG</c>: <c>#</c>, mMensagem 9/429/432 e o handle oculto) e, a cada
    /// clique ou tecla na grade, o <c>wkpp6H6CivH</c> do original: tira o realce da página ativa
    /// (<c>clsBlocos.Unhighlight</c>) e vai até a veia selecionada — ativa a página dela, dá zoom
    /// com margem 20 e a realça (<c>clsInterligacao.AtivaUmaHighlightZoom</c>).
    /// </summary>
    internal sealed class LigacaoDoFrmPesquisaVeiasIndefinidas : ILigacaoDeTela
    {
        public string NomeDaTela
        {
            get { return "frmPesquisaVeiasIndefinidas"; }
        }

        public void Preencher(Form janela)
        {
            DataGridView grade = ControlesDaTela.Achar<DataGridView>(janela, "dgVeiasDWG");
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

            janela.MinimumSize = new System.Drawing.Size(400, 200);
            grade.AllowUserToOrderColumns = true;
            grade.Rows.Clear();
            grade.Columns.Clear();
            grade.Columns.Add("Indice", "#");
            grade.Columns.Add("pAGINA", "Página");
            grade.Columns.Add("PN1", "Origem");
            grade.Columns.Add("PN2", "Destino");
            grade.Columns.Add("Handle", "Handle");

            IReadOnlyList<VeiaIndefinida> veias = VeiasIndefinidasDoCaderno.Carregar(InterligacaoDoDesenho.LerComPosicao());
            IReadOnlyList<LinhaDeVeiaIndefinida> linhas = VeiasIndefinidasDoCaderno.LinhasDaGrade(veias, LerNomesDePaineis());
            foreach (LinhaDeVeiaIndefinida linha in linhas)
            {
                grade.Rows.Add(linha.Indice, linha.Pagina, linha.Origem, linha.Destino, linha.Handle);
            }

            AjustarColunas(grade);
            if (grade.Rows.Count > 0)
            {
                grade.Rows[0].Selected = false;
            }

            janela.Resize += (origem, evento) => AjustarColunas(grade);
            grade.KeyUp += (origem, evento) => IrAteAVeiaDaGrade.Selecionadas(grade, 4, false);
            grade.MouseUp += (origem, evento) => IrAteAVeiaDaGrade.Selecionadas(grade, 4, false);
        }

        /// <summary>O <c>AtualizaDGVeiasDWG</c>: 10/30/30/30% da largura útil e o handle oculto.</summary>
        private static void AjustarColunas(DataGridView grade)
        {
            if (grade.Columns.Count < 5)
            {
                return;
            }

            bool barra = HaBarraVertical(grade);
            double largura = barra ? grade.Width - 21 : grade.Width - 4;
            grade.Columns[0].Width = (int)Math.Round(largura * 0.1);
            grade.Columns[1].Width = (int)Math.Round(largura * 0.3);
            grade.Columns[2].Width = (int)Math.Round(largura * 0.3);
            grade.Columns[3].Width = (int)Math.Round(largura * 0.3);
            grade.Columns[4].Visible = false;
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

        private static IReadOnlyDictionary<int, string> LerNomesDePaineis()
        {
            ConfiguracaoPositron config = ConfiguracaoEfetiva.Carregar();
            if (config == null || string.IsNullOrEmpty(config.Banco))
            {
                return new Dictionary<int, string>();
            }

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
    }
}

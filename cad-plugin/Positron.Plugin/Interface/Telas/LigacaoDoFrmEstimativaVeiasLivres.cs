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
    /// A ligação do <c>frmEstimativaVeiasLivres</c> (o comando <c>ESTVL</c>): a grade
    /// <c>dgTrajeto</c> com a <see cref="EstimativaDeVeiasLivres"/> do desenho ativo — o par de
    /// painéis e quantas veias indefinidas o ligam — e o <c>btCopiar</c>, que põe a grade na área
    /// de transferência. As colunas são as do <c>formataDGVeias</c> do original, que as recria em
    /// tempo de execução (<c>mMensagem</c> 48, 49 e 1433: <c>DE</c>, <c>PARA</c>, <c># VEIAS</c>).
    /// </summary>
    internal sealed class LigacaoDoFrmEstimativaVeiasLivres : ILigacaoDeTela
    {
        public string NomeDaTela
        {
            get { return "frmEstimativaVeiasLivres"; }
        }

        public void Preencher(Form janela)
        {
            DataGridView grade = ControlesDaTela.Achar<DataGridView>(janela, "dgTrajeto");
            if (grade == null)
            {
                return;
            }

            grade.Rows.Clear();
            grade.Columns.Clear();
            grade.Columns.Add("", "DE");
            grade.Columns.Add("", "PARA");
            grade.Columns.Add("", "# VEIAS");
            float largura = grade.Width - 22;
            grade.Columns[0].Width = (int)Math.Round(largura * 2f / 5f);
            grade.Columns[1].Width = (int)Math.Round(largura * 2f / 5f);
            grade.Columns[2].Width = (int)Math.Round(largura / 5f);

            IReadOnlyList<LinhaDaEstimativa> linhas = EstimativaDeVeiasLivres.Calcular(
                InterligacaoDoDesenho.LerComHandles(),
                LerNomesDePaineis());
            List<string> pares = new List<string>();
            foreach (LinhaDaEstimativa linha in linhas)
            {
                grade.Rows.Add(linha.Nome1, linha.Nome2, linha.Quantidade.ToString());
                pares.Add(linha.Nome1 + " -> " + linha.Nome2 + " (" + linha.Quantidade + ")");
            }

            Button copiar = ControlesDaTela.Achar<Button>(janela, "btCopiar");
            if (copiar != null)
            {
                copiar.Click += (origem, evento) => Copiar(grade);
            }

            Plugin.Escrever("ESTVL: " + linhas.Count + " par(es) de painéis com veia indefinida"
                + (pares.Count > 0 ? ": " + string.Join("; ", pares) : string.Empty) + ".");
        }

        private static void Copiar(DataGridView grade)
        {
            if (grade.RowCount == 0)
            {
                return;
            }

            List<string[]> linhas = new List<string[]>();
            foreach (DataGridViewRow linha in grade.Rows)
            {
                linhas.Add(new[] { Texto(linha, 0), Texto(linha, 1), Texto(linha, 2) });
            }

            Clipboard.SetText(EstimativaDeVeiasLivres.ParaAreaDeTransferencia(linhas));
        }

        private static string Texto(DataGridViewRow linha, int coluna)
        {
            object valor = linha.Cells[coluna].Value;
            return valor == null ? string.Empty : valor.ToString();
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
            catch (Exception erro)
            {
                Plugin.Escrever("ESTVL: o cadastro de painéis não veio do banco — " + erro.Message);
                return new Dictionary<int, string>();
            }
        }
    }
}

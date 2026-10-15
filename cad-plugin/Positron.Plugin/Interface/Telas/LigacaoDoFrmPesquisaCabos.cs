using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Positron.Contract;
using Positron.Data;
using Positron.Data.Configuracao;
using Positron.Data.Interligacao;

namespace Positron.Plugin.Interface.Telas
{
    /// <summary>
    /// A ligação do <c>frmPesquisaCabos</c> (o comando <c>PESQCAB</c>): à esquerda, a grade
    /// <c>dgCabos</c> com os cabos do catálogo <c>Veias</c> deste DWG e, depois do cabeçalho
    /// coral, os de outros cadernos (<see cref="PesquisaDeCabos.Cabos"/>); clicar num cabo enche a
    /// <c>dgVeias</c> com as veias dele (<see cref="PesquisaDeCabos.VeiasDoCabo"/>, com as cores do
    /// <c>OrdenaVeias</c>); clicar numa veia vai até ela no desenho (<see cref="IrAteAVeiaDaGrade"/>).
    /// </summary>
    internal sealed class LigacaoDoFrmPesquisaCabos : ILigacaoDeTela
    {
        public string NomeDaTela
        {
            get { return "frmPesquisaCabos"; }
        }

        public void Preencher(Form janela)
        {
            DataGridView cabos = ControlesDaTela.Achar<DataGridView>(janela, "dgCabos");
            DataGridView veias = ControlesDaTela.Achar<DataGridView>(janela, "dgVeias");
            if (cabos == null || veias == null)
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

            ProjectStore store = new ProjectStore(config.Banco);
            IReadOnlyList<VeiasRow> catalogo = store.LerVeias();
            IReadOnlyDictionary<int, string> nomesDeDwgs = store.LerNomesDeDwgs();
            IReadOnlyList<CaboNaPesquisa> lista = PesquisaDeCabos.Cabos(catalogo, config.Dwg);

            // O `formataDGCabos`: "Nome do Cabo" (mMensagem 1238) e o `Tipo` oculto.
            cabos.Rows.Clear();
            cabos.Columns.Clear();
            cabos.Columns.Add("Cabo", "Nome do Cabo");
            cabos.Columns.Add("Tipo", "Tipo");
            foreach (CaboNaPesquisa cabo in lista)
            {
                int indice = cabos.Rows.Add(cabo.Tag, cabo.Cabecalho ? (object)string.Empty : cabo.OutroCaderno);
                cabos.Rows[indice].Tag = cabo;
                if (cabo.Cabecalho)
                {
                    cabos.Rows[indice].Cells[0].Style.BackColor = Color.LightCoral;
                }
                else if (cabo.OutroCaderno)
                {
                    cabos.Rows[indice].Cells[0].Style.BackColor = Color.LightGray;
                }
            }

            FormatarVeias(veias);
            AjustarColunas(cabos, veias);
            if (cabos.Rows.Count > 0)
            {
                cabos.Rows[0].Selected = false;
            }

            janela.Resize += (origem, evento) => AjustarColunas(cabos, veias);
            cabos.KeyUp += (origem, evento) => MostrarVeias(cabos, veias, catalogo, nomesDeDwgs);
            cabos.MouseUp += (origem, evento) => MostrarVeias(cabos, veias, catalogo, nomesDeDwgs);
            veias.KeyUp += (origem, evento) => IrAteAVeiaDaGrade.Selecionadas(veias, 3, "PESQCAB", true);
            veias.MouseUp += (origem, evento) => IrAteAVeiaDaGrade.Selecionadas(veias, 3, "PESQCAB", true);

            int doCaderno = 0;
            int deOutros = 0;
            foreach (CaboNaPesquisa cabo in lista)
            {
                if (!cabo.Cabecalho && cabo.OutroCaderno)
                {
                    deOutros++;
                }
                else if (!cabo.Cabecalho)
                {
                    doCaderno++;
                }
            }

            Plugin.Escrever("PESQCAB: " + doCaderno + " cabo(s) deste DWG (" + config.Dwg + ") e " + deOutros
                + " de outros cadernos na grade; " + catalogo.Count + " veia(s) no catálogo.");

            // O `UBound(LeCabosVeiasTodos) == 0`: mMensagem 1284, e a tela fecha.
            if (catalogo.Count == 0)
            {
                Aviso.MsgBox("O Projeto não possui Cabos", string.Empty);
                janela.Dispose();
                return;
            }

            // Sem clique no harness: a primeira linha é mostrada na linha de comando, como medida.
            if (lista.Count > 0 && !lista[0].Cabecalho)
            {
                Plugin.Escrever("PESQCAB: " + Resumo(lista[0], PesquisaDeCabos.VeiasDoCabo(catalogo, nomesDeDwgs, lista[0])));
            }
        }

        private static void MostrarVeias(DataGridView cabos, DataGridView veias, IReadOnlyList<VeiasRow> catalogo, IReadOnlyDictionary<int, string> nomesDeDwgs)
        {
            if (cabos.SelectedRows.Count == 0)
            {
                return;
            }

            CaboNaPesquisa cabo = cabos.SelectedRows[0].Tag as CaboNaPesquisa;
            IReadOnlyList<VeiaDaPesquisa> linhas = PesquisaDeCabos.VeiasDoCabo(catalogo, nomesDeDwgs, cabo);

            FormatarVeias(veias);
            foreach (VeiaDaPesquisa linha in linhas)
            {
                int indice = veias.Rows.Add(linha.Indice, linha.Texto, linha.Pagina, linha.Handle, linha.Ordem);
                Color fundo = linha.Cor == CorDaVeia.Blindagem ? Color.LightBlue
                    : linha.Cor == CorDaVeia.Clara ? Color.LightGoldenrodYellow : Color.LightGray;
                for (int coluna = 1; coluna <= 4; coluna++)
                {
                    veias.Rows[indice].Cells[coluna].Style.BackColor = fundo;
                }
            }

            AjustarColunas(cabos, veias);
            if (veias.Rows.Count > 0)
            {
                veias.Rows[0].Selected = false;
            }

            if (cabo != null)
            {
                Plugin.Escrever("PESQCAB: " + Resumo(cabo, linhas));
            }
        }

        private static string Resumo(CaboNaPesquisa cabo, IReadOnlyList<VeiaDaPesquisa> linhas)
        {
            List<string> amostra = new List<string>();
            foreach (VeiaDaPesquisa linha in linhas)
            {
                if (amostra.Count == 6)
                {
                    amostra.Add("...");
                    break;
                }

                amostra.Add(linha.Texto + "@" + linha.Pagina + (linha.Handle.Length > 0 ? " [" + linha.Handle + "]" : string.Empty));
            }

            return "cabo \"" + cabo.Tag + "\"" + (cabo.OutroCaderno ? " (outro caderno)" : string.Empty) + " — "
                + linhas.Count + " veia(s)" + (amostra.Count > 0 ? ": " + string.Join("; ", amostra.ToArray()) : string.Empty) + ".";
        }

        /// <summary>O <c>formataDGVeias</c>: Índice (915), Veias (1239), Página (772), Handle, Ordena.</summary>
        private static void FormatarVeias(DataGridView veias)
        {
            veias.Rows.Clear();
            veias.Columns.Clear();
            veias.Columns.Add("Indice", "Índice");
            veias.Columns.Add("Nome", "Veias");
            veias.Columns.Add("Pagina", "Página");
            veias.Columns.Add("Handle", "Handle");
            veias.Columns.Add("Ordena", "Ordena");
        }

        /// <summary>O <c>AtualizaDGCabos</c> e o <c>AtualizaDGVeias</c>: as larguras e as colunas ocultas.</summary>
        private static void AjustarColunas(DataGridView cabos, DataGridView veias)
        {
            if (cabos.Columns.Count >= 2)
            {
                cabos.Columns[0].Width = (int)Math.Round(LarguraUtil(cabos));
                cabos.Columns[1].Visible = false;
            }

            if (veias.Columns.Count >= 5)
            {
                double largura = LarguraUtil(veias);
                veias.Columns[0].Visible = false;
                veias.Columns[1].Width = (int)Math.Round(largura * 0.3);
                veias.Columns[2].Width = (int)Math.Round(largura * 0.7);
                veias.Columns[3].Visible = false;
                veias.Columns[4].Visible = false;
            }
        }

        private static double LarguraUtil(DataGridView grade)
        {
            foreach (Control controle in grade.Controls)
            {
                if (controle is VScrollBar && controle.Visible)
                {
                    return grade.Width - 21;
                }
            }

            return grade.Width - 4;
        }
    }
}

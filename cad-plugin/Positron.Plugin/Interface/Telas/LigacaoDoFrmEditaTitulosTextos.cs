using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Positron.Data.Paginas;
using Positron.Plugin.Paginas;

namespace Positron.Plugin.Interface.Telas
{
    /// <summary>
    /// A ligação do <c>frmEditaTitulosTextos</c> (o comando <c>TROCTT</c>): a grade <c>dgPaginas</c>
    /// com as páginas do caderno (seleção múltipla), os "Título n" habilitados só para os títulos que
    /// o formato tem (sem nenhum, a tela não abre: mMensagem 53) e o <c>BtEditar</c>, que troca DE →
    /// PARA nas páginas selecionadas (<see cref="TitulosETextosDoDesenho"/>).
    ///
    /// **Como a tela é medida num script** (não há clique): <c>POSITRON_TROCTT</c> =
    /// <c>DE|PARA|caixas|páginas</c> — as caixas são <c>1</c>..<c>4</c>, <c>T</c> (textos) e <c>M</c>
    /// (multitextos); as páginas, separadas por vírgula (vazio = todas). A ligação preenche os
    /// controles e roda o clique do botão ao abrir.
    /// </summary>
    internal sealed class LigacaoDoFrmEditaTitulosTextos : ILigacaoDeTela
    {
        public string NomeDaTela
        {
            get { return "frmEditaTitulosTextos"; }
        }

        public void Preencher(Form janela)
        {
            DataGridView grade = ControlesDaTela.Achar<DataGridView>(janela, "dgPaginas");
            Button editar = ControlesDaTela.Achar<Button>(janela, "BtEditar");
            if (grade == null || editar == null)
            {
                return;
            }

            CheckBox[] titulos =
            {
                null,
                ControlesDaTela.Achar<CheckBox>(janela, "cbTitulo1"),
                ControlesDaTela.Achar<CheckBox>(janela, "cbTitulo2"),
                ControlesDaTela.Achar<CheckBox>(janela, "cbTitulo3"),
                ControlesDaTela.Achar<CheckBox>(janela, "cbTitulo4"),
            };
            CheckBox textos = ControlesDaTela.Achar<CheckBox>(janela, "cbText");
            CheckBox multi = ControlesDaTela.Achar<CheckBox>(janela, "cbMText");
            TextBox de = ControlesDaTela.Achar<TextBox>(janela, "tbDe");
            TextBox para = ControlesDaTela.Achar<TextBox>(janela, "tbPara");

            // Do designer (`frmEditaTitulosTextos.cs`): largura presa em 396.
            janela.MinimumSize = new System.Drawing.Size(396, 387);
            janela.MaximumSize = new System.Drawing.Size(396, 600);

            bool[] existentes = TitulosETextosDoDesenho.LerTitulosExistentes();
            if (!existentes[1] && !existentes[2] && !existentes[3] && !existentes[4])
            {
                Aviso.MsgBox("O Formato usado não possui títulos!", "Elétron");
                janela.Dispose();
                return;
            }

            for (int i = 1; i <= 4; i++)
            {
                if (titulos[i] != null)
                {
                    titulos[i].Enabled = existentes[i];
                }
            }

            // O `QyUSj1syjb`/`sOZSLnbfGo`: uma coluna "Página", sem ordenação, seleção múltipla.
            grade.Rows.Clear();
            grade.Columns.Clear();
            grade.Columns.Add("", "Página");
            grade.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            grade.MultiSelect = true;
            List<string> paginas = PaginasDoDesenho.Ler();
            foreach (string pagina in paginas)
            {
                grade.Rows.Add(pagina);
            }

            grade.Columns[0].Width = LarguraUtil(grade);

            editar.Click += (origem, evento) => Editar(grade, titulos, textos, multi, de, para);

            PreencherPeloHarness(grade, titulos, textos, multi, de, para);
        }

        private static void Editar(DataGridView grade, CheckBox[] titulos, CheckBox textos, CheckBox multi, TextBox de, TextBox para)
        {
            try
            {
                OpcoesDeTitulosETextos opcoes = new OpcoesDeTitulosETextos
                {
                    Titulo1 = Marcada(titulos[1]),
                    Titulo2 = Marcada(titulos[2]),
                    Titulo3 = Marcada(titulos[3]),
                    Titulo4 = Marcada(titulos[4]),
                    Textos = Marcada(textos),
                    MultiTextos = Marcada(multi),
                    De = de == null ? string.Empty : de.Text,
                    Para = para == null ? string.Empty : para.Text,
                };

                // O original volta calado sem caixa marcada ou sem o DE.
                if (!opcoes.Valida)
                {
                    return;
                }

                List<string> selecionadas = new List<string>();
                foreach (DataGridViewRow linha in grade.Rows)
                {
                    if (linha.Selected)
                    {
                        selecionadas.Add(Convert.ToString(linha.Cells[0].Value));
                    }
                }

                int alterados = TitulosETextosDoDesenho.Editar(opcoes, selecionadas);

                // O MsgBox do original (`clsEditaTitulosTextos.cs:158`): o número e a mMensagem 1221.
                Aviso.MsgBox(alterados + " textos sofreram alteração.", string.Empty);
            }
            catch (Exception erro)
            {
                // O original relança (`clsEditaTitulosTextos.cs:162`) e o erro chega ao usuário.
                Aviso.MsgBoxCritico(erro.Message, string.Empty);
            }
        }

        /// <summary>O gancho do harness (<c>POSITRON_TROCTT</c>): preenche a tela e roda o clique do botão.</summary>
        private static void PreencherPeloHarness(DataGridView grade, CheckBox[] titulos, CheckBox textos, CheckBox multi, TextBox de, TextBox para)
        {
            string valor = Environment.GetEnvironmentVariable("POSITRON_TROCTT");
            if (string.IsNullOrEmpty(valor))
            {
                return;
            }

            string[] partes = valor.Split('|');
            if (partes.Length < 3 || de == null || para == null)
            {
                Plugin.Escrever("TROCTT: POSITRON_TROCTT inválido (DE|PARA|caixas|páginas).");
                return;
            }

            de.Text = partes[0];
            para.Text = partes[1];
            for (int i = 1; i <= 4; i++)
            {
                if (titulos[i] != null)
                {
                    titulos[i].Checked = titulos[i].Enabled && partes[2].Contains(i.ToString());
                }
            }

            if (textos != null)
            {
                textos.Checked = partes[2].IndexOf('T') >= 0;
            }

            if (multi != null)
            {
                multi.Checked = partes[2].IndexOf('M') >= 0;
            }

            HashSet<string> escolhidas = new HashSet<string>(StringComparer.Ordinal);
            if (partes.Length > 3)
            {
                foreach (string pagina in partes[3].Split(','))
                {
                    if (pagina.Length > 0)
                    {
                        escolhidas.Add(pagina);
                    }
                }
            }

            foreach (DataGridViewRow linha in grade.Rows)
            {
                linha.Selected = escolhidas.Count == 0 || escolhidas.Contains(Convert.ToString(linha.Cells[0].Value));
            }

            // O `PerformClick` não age numa janela ainda não mostrada: chama o mesmo tratador.
            Editar(grade, titulos, textos, multi, de, para);
        }

        private static bool Marcada(CheckBox caixa)
        {
            return caixa != null && caixa.Checked;
        }

        private static int LarguraUtil(DataGridView grade)
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

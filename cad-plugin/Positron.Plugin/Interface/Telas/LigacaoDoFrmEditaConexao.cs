using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Positron.Data.Fiacao;
using Positron.Plugin.Fiacao;
using Positron.Plugin.Paginas;

namespace Positron.Plugin.Interface.Telas
{
    /// <summary>
    /// A ligação do <c>frmEditaConexao</c> (o comando <c>EDCONP</c>): a grade <c>dg</c> com as
    /// páginas do caderno (o <c>FpkZYb3mMU</c> do original carrega o <c>mPaginas</c>, uma coluna
    /// "Página", seleção múltipla) e o <c>btEditar</c>, que pergunta <c>Seção, Cor ou Ambas</c> e
    /// roda o <c>clsConexao.editarSecaoCorPaginas</c> sobre as páginas selecionadas
    /// (<see cref="SecaoECorDasConexoesDoDesenho"/>). A janela fica aberta, como no original.
    /// </summary>
    internal sealed class LigacaoDoFrmEditaConexao : ILigacaoDeTela
    {
        public string NomeDaTela
        {
            get { return "frmEditaConexao"; }
        }

        public void Preencher(Form janela)
        {
            DataGridView grade = ControlesDaTela.Achar<DataGridView>(janela, "dg");
            if (grade == null)
            {
                return;
            }

            // O `QNjZraIE9k` do original: uma coluna (mMensagem 9), sem ordenação, na largura da grade.
            grade.Rows.Clear();
            grade.Columns.Clear();
            grade.Columns.Add("", "Página");
            grade.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            grade.Columns[0].Width = (int)Math.Round((float)(grade.Width - 20));
            grade.MultiSelect = true;

            List<string> paginas = PaginasDoDesenho.Ler();
            foreach (string pagina in paginas)
            {
                grade.Rows.Add(pagina);
            }

            Button editar = ControlesDaTela.Achar<Button>(janela, "btEditar");
            if (editar != null)
            {
                editar.Click += (origem, evento) => Editar(grade);
            }
        }

        private static void Editar(DataGridView grade)
        {
            try
            {
                List<string> selecionadas = new List<string>();
                foreach (DataGridViewRow linha in grade.Rows)
                {
                    if (linha.Selected)
                    {
                        selecionadas.Add(Convert.ToString(linha.Cells[0].Value));
                    }
                }

                ModoSecaoECor? modo = SecaoECorDasConexoesDoDesenho.PerguntarModo();
                if (modo.HasValue)
                {
                    SecaoECorDasConexoesDoDesenho.Executar(modo.Value, selecionadas);
                }
            }
            catch (Exception erro)
            {
                // O `MsgBox(ex.Message, Information)` do `clsConexao.editarSecaoCorPaginas`.
                Aviso.MsgBox(erro.Message, "Eletron");
            }
        }
    }
}

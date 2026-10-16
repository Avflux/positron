using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Positron.Data.Paginas;
using Positron.Plugin.Paginas;
using Positron.Plugin.Interface.Folhas;
#if AUTOCAD
using AplicacaoDoCad = Autodesk.AutoCAD.ApplicationServices.Application;
#else
using AplicacaoDoCad = ZwSoft.ZwCAD.ApplicationServices.Application;
#endif

namespace Positron.Plugin.Interface.Telas
{
    internal sealed class LigacaoDoFrmEditaTitulos : ILigacaoDeTela
    {
        public string NomeDaTela { get { return "frmEditaTitulos"; } }

        public void Preencher(Form janela)
        {
            DataGridView grade = ControlesDaTela.Achar<DataGridView>(janela, "dg");
            if (grade == null) throw new InvalidOperationException("dg");
            // frmEditaTitulos chama restauraCampos antes de inspecionar o formato, inclusive
            // quando depois não encontra títulos. Abertura pela paleta exige lock próprio.
            try { RestauracaoDoFormatoDoDesenho.RestaurarCampos(); }
            catch (Exception erro) { Aviso.MsgBoxCritico(erro.Message, string.Empty); }
            bool[] existentes = TitulosETextosDoDesenho.LerTitulosExistentes();
            if (!existentes[1] && !existentes[2] && !existentes[3] && !existentes[4])
            {
                Aviso.MsgBox("O Formato usado não possui títulos!", "Elétron");
                janela.Dispose();
                return;
            }
            var documento = AplicacaoDoCad.DocumentManager.MdiActiveDocument;
            janela.MinimumSize = new Size(700, 500);
            grade.BackgroundColor = Color.FromArgb(224, 224, 224);
            grade.AllowUserToDeleteRows = false;
            grade.AllowUserToResizeRows = false;
            grade.Columns.Clear();
            string[] nomes = { "Página", "Título 1", "Título 2", "Título 3", "Título 4", "Unidade", "Alternativo" };
            foreach (string nome in nomes)
            {
                int indice = grade.Columns.Add("c" + grade.Columns.Count, nome);
                grade.Columns[indice].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            grade.Columns[0].ReadOnly = true;
            for (int i = 1; i <= 4; i++) grade.Columns[i].Visible = existentes[i];
            grade.Columns[6].Visible = PreferenciasDeFolhas.LerAlternativo();
            Dictionary<string, TitulosDaPagina> titulos = TitulosDaPaginaDoDesenho.LerGrade();
            foreach (string pagina in PaginasDoDesenho.Ler())
            {
                if (Positron.Data.Paginas.PaginaAtiva.ChecaCapa(pagina)) continue;
                string unidade, alternativo;
                UnidadeDaPaginaDoDesenho.Ler(pagina, out unidade, out alternativo);
                TitulosDaPagina t = titulos[pagina];
                grade.Rows.Add(pagina, t.Titulo1 ?? "", t.Titulo2 ?? "", t.Titulo3 ?? "", t.Titulo4 ?? "", unidade, alternativo);
            }
            Action larguras = () =>
            {
                int largura = Math.Max(100, grade.Width - 25);
                grade.Columns[0].Width = Math.Max(20, (int)Math.Round(largura * .05));
                grade.Columns[5].Width = Math.Max(20, (int)Math.Round(largura * .1));
                grade.Columns[6].Width = grade.Columns[5].Width;
                int quantidade = 0;
                for (int i = 1; i <= 4; i++) if (grade.Columns[i].Visible) quantidade++;
                int restante = largura - grade.Columns[0].Width - grade.Columns[5].Width
                    - (grade.Columns[6].Visible ? grade.Columns[6].Width : 0);
                for (int i = 1; i <= 4; i++) if (grade.Columns[i].Visible)
                    grade.Columns[i].Width = Math.Max(20, restante / Math.Max(1, quantidade));
            };
            janela.Resize += (origem, evento) => larguras();
            larguras();
            ContextMenuStrip menu = grade.ContextMenuStrip ?? new ContextMenuStrip();
            grade.ContextMenuStrip = menu;
            menu.Items.Clear();
            string copiado = "";
            ToolStripMenuItem copiar = Item(menu, "Copiar", "Copiar", () =>
            {
                if (grade.SelectedCells.Count == 1) copiado = Convert.ToString(grade.SelectedCells[0].Value);
            });
            Item(menu, "Colar", "Colar", () => Transformar(grade, c => EdicaoDaGradeDeTitulos.Colar(c.ColumnIndex, Convert.ToString(c.Value), copiado)));
            Item(menu, "Limpar", "Limpar", () => Transformar(grade, c => EdicaoDaGradeDeTitulos.Limpar(c.ColumnIndex, Convert.ToString(c.Value))));
            menu.Items.Add(new ToolStripSeparator());
            // A ponte Excel é um recorte pendente; não oferecer ação sem implementação.
            Item(menu, "Exportar", "ExportarStripMenuItem", () => { }).Enabled = false;
            Item(menu, "Importar", "ImportarStripMenuItem", () => { }).Enabled = false;
            menu.Items.Add(new ToolStripSeparator());
            ToolStripTextBox de = new ToolStripTextBox { Text = "DE", BackColor = Color.LightGray, BorderStyle = BorderStyle.Fixed3D };
            ToolStripTextBox para = new ToolStripTextBox { Text = "PARA", BackColor = Color.LightGray, BorderStyle = BorderStyle.Fixed3D };
            menu.Items.Add(de);
            menu.Items.Add(para);
            Item(menu, "Substituir", "Substituir", () => Transformar(grade,
                c => EdicaoDaGradeDeTitulos.Substituir(c.ColumnIndex, Convert.ToString(c.Value), de.Text, para.Text)));
            menu.Items.Add(new ToolStripSeparator());
            Item(menu, "Editar DWG", "DWG1", () =>
            {
                if (!ReferenceEquals(documento, AplicacaoDoCad.DocumentManager.MdiActiveDocument))
                {
                    // Não aplicar linhas capturadas de um desenho em outro documento.
                    janela.Close();
                    return;
                }
                grade.EndEdit();
                Dictionary<string, TitulosDaPagina> novos = new Dictionary<string, TitulosDaPagina>(StringComparer.OrdinalIgnoreCase);
                Dictionary<string, string> alternativos = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                foreach (DataGridViewRow linha in grade.Rows)
                {
                    string pagina = Convert.ToString(linha.Cells[0].Value);
                    TitulosDaPagina t = new TitulosDaPagina();
                    for (int i = 1; i <= 4; i++) t.Definir(i, Convert.ToString(linha.Cells[i].Value));
                    novos[pagina] = t;
                    alternativos[pagina] = Convert.ToString(linha.Cells[6].Value);
                }
                TitulosDaPaginaDoDesenho.GravarGrade(novos, alternativos);
                foreach (DataGridViewRow linha in grade.Rows)
                    UnidadeDaPaginaDoDesenho.Gravar(Convert.ToString(linha.Cells[0].Value),
                        Convert.ToString(linha.Cells[5].Value), Convert.ToString(linha.Cells[6].Value));
                PaletaDeFolhas.Recarregar();
                janela.Close();
            });
            menu.Opening += (origem, evento) => copiar.Enabled = grade.SelectedCells.Count == 1;
            grade.CellEndEdit += (origem, evento) =>
            {
                if (evento.RowIndex < 0 || evento.ColumnIndex != 6) return;
                DataGridViewCell celula = grade.Rows[evento.RowIndex].Cells[6];
                string valor = Convert.ToString(celula.Value);
                celula.Value = EdicaoDaGradeDeTitulos.Limitar(6, valor);
                if (valor.Length > 20) Aviso.MsgBox("Máximo de 20 caracteres", string.Empty);
            };
            string ativa = PaginaAtivaDoDesenho.Ler();
            foreach (DataGridViewRow linha in grade.Rows)
                if (Convert.ToString(linha.Cells[0].Value) == ativa)
                {
                    grade.CurrentCell = linha.Cells[0];
                    linha.Selected = true;
                    break;
                }
            // A janela modeless pertence ao DWG que a abriu; fecha ao trocar de documento.
            EventHandler verificar = (origem, evento) =>
            {
                if (!ReferenceEquals(documento, AplicacaoDoCad.DocumentManager.MdiActiveDocument)) janela.Close();
            };
            System.Windows.Forms.Application.Idle += verificar;
            janela.FormClosed += (origem, evento) => System.Windows.Forms.Application.Idle -= verificar;
            janela.Disposed += (origem, evento) => System.Windows.Forms.Application.Idle -= verificar;
        }

        private static void Transformar(DataGridView grade, Func<DataGridViewCell, string> transformar)
        {
            grade.EndEdit();
            foreach (DataGridViewCell celula in grade.SelectedCells)
                if (celula.ColumnIndex > 0) celula.Value = transformar(celula);
        }

        private static ToolStripMenuItem Item(ContextMenuStrip menu, string texto, string icone, Action acao)
        {
            ToolStripMenuItem item = new ToolStripMenuItem(texto) { Image = IconesEmbutidos.BitmapDe(icone) };
            item.Click += (origem, evento) =>
            {
                try { acao(); }
                catch (Exception erro) { Aviso.MsgBoxCritico(erro.Message, string.Empty); }
            };
            menu.Items.Add(item);
            return item;
        }
    }
}

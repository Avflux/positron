using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Positron.Plugin.Interface.Telas;
using Positron.Data.Interface.Mapas;
using Positron.Plugin.Paginas;
using Positron.Data.Paginas;

namespace Positron.Plugin.Interface.Folhas
{
    /// <summary>
    /// A **prova do caminho da paleta** — o que o comando <c>pzFolhas</c> roda. Monta o
    /// <see cref="FolhasControle"/> e chama o **mesmo** handler que o clique do menu e a tecla
    /// chamam, sem passar pela interface: é o caminho do usuário sem o clique (que um script não dá).
    ///
    /// A entrada é toda do harness, e **só** daqui: <c>POSITRON_FOLHA_ACAO</c> (<c>nova</c>,
    /// <c>inserir:N</c>, <c>apagar</c>, <c>multiselecao</c>; sem ela o comando só despeja o estado),
    /// <c>POSITRON_FOLHA_SELECAO</c> (a linha selecionada; o padrão é <c>POSITRON_PAGINA</c>) e
    /// <c>POSITRON_FOLHA_SELECIONADAS</c> (as linhas selecionadas, separadas por vírgula).
    /// </summary>
    internal static class ProvaDaPaleta
    {
        internal static string Executar()
        {
            try
            {
                if (Environment.GetEnvironmentVariable("POSITRON_FOLHA_ACAO") == "interface")
                {
                    AgendarProvaDaInterface();
                    return "pzFolhas: prova agendada fora de comando (Timer da interface).";
                }
                FolhasControle controle = new FolhasControle();
                int paginas = controle.Carregar();

                string selecao = Environment.GetEnvironmentVariable("POSITRON_FOLHA_SELECAO");
                if (string.IsNullOrEmpty(selecao))
                {
                    selecao = Environment.GetEnvironmentVariable("POSITRON_PAGINA");
                }

                string selecionadas = Environment.GetEnvironmentVariable("POSITRON_FOLHA_SELECIONADAS");
                List<string> linhas = new List<string>();
                if (!string.IsNullOrEmpty(selecionadas))
                {
                    foreach (string parte in selecionadas.Split(','))
                    {
                        if (!string.IsNullOrEmpty(parte.Trim()))
                        {
                            linhas.Add(parte.Trim());
                        }
                    }

                    // Mais de uma página pedida é o usuário que ligou a `Multiseleção` no menu para
                    // poder marcar as linhas (no `Inserir` de colunas ou no `Apagar Páginas`).
                    if (linhas.Count > 1)
                    {
                        controle.Multiselecao = true;
                    }
                }
                else if (!string.IsNullOrEmpty(selecao))
                {
                    linhas.Add(selecao);
                }

                int achadas = controle.Selecionar(linhas);

                string acao = (Environment.GetEnvironmentVariable("POSITRON_FOLHA_ACAO") ?? string.Empty).Trim().ToLowerInvariant();
                string resultado = "(sem ação: só o estado da grade)";

                if (acao == "titulos")
                {
                    using (Form janela = RenderizadorDeTelas.Montar(FormulariosDoReverso.Buscar("frmEditaTitulos")))
                    {
                        if (janela.IsDisposed) resultado = "sem títulos no formato; janela não aberta";
                        else
                        {
                            DataGridView grade = ControlesDaTela.Achar<DataGridView>(janela, "dg");
                            List<string> visiveis = new List<string>();
                            foreach (DataGridViewColumn coluna in grade.Columns)
                                if (coluna.Visible) visiveis.Add(coluna.HeaderText);
                            resultado = grade.Rows.Count + " linha(s); colunas [" + string.Join(" | ", visiveis.ToArray()) + "]";
                            string alvo = Environment.GetEnvironmentVariable("POSITRON_PAGINA");
                            foreach (DataGridViewRow linha in grade.Rows)
                            {
                                if (Convert.ToString(linha.Cells[0].Value) != alvo) continue;
                                for (int i = 1; i <= 4; i++)
                                {
                                    string valor = Environment.GetEnvironmentVariable("POSITRON_TITULO" + i);
                                    if (valor != null) linha.Cells[i].Value = valor;
                                }
                                string unidade = Environment.GetEnvironmentVariable("POSITRON_UNIDADE");
                                if (unidade != null) linha.Cells[5].Value = unidade;
                                string alternativo = Environment.GetEnvironmentVariable("POSITRON_ALTERNATIVO");
                                if (alternativo != null) linha.Cells[6].Value = EdicaoDaGradeDeTitulos.Limitar(6, alternativo);
                            }
                            Capturar(janela, "editar-os-titulos");
                            foreach (ToolStripItem item in grade.ContextMenuStrip.Items)
                                if (item.Text == "Editar DWG") item.PerformClick();
                            resultado += "; Editar DWG pelo menu; fechou=" + janela.IsDisposed;
                            string esperado = Environment.GetEnvironmentVariable("POSITRON_TITULO1");
                            if (esperado != null && TitulosDaPaginaDoDesenho.LerGrade()[alvo].Titulo1 != esperado)
                                throw new InvalidOperationException("Título gravado difere do pedido");
                        }
                    }
                }
                else if (acao == "ler-titulos")
                {
                    Dictionary<string, TitulosDaPagina> capturados = TitulosDaPaginaDoDesenho.LerGrade();
                    string alvo = Environment.GetEnvironmentVariable("POSITRON_PAGINA") ?? "2";
                    resultado = "TextString capturado=" + (capturados.ContainsKey(alvo) ? capturados[alvo].Titulo1 : "ausente");
                }
                else if (acao == "ir")
                {
                    controle.IrParaPagina(selecao);
                    resultado = "página ativa=" + PaginaAtivaDoDesenho.Ler();
                }
                else if (acao == "multiselecao")
                {
                    controle.Multiselecao = true;
                    resultado = controle.NovaPagina();
                }
                else if (acao == "nova")
                {
                    resultado = controle.NovaPagina();
                }
                else if (acao == "apagar")
                {
                    resultado = controle.ApagarSelecionadas();
                }
                else if (acao.StartsWith("inserir", StringComparison.Ordinal))
                {
                    int indice = 1;
                    int doisPontos = acao.IndexOf(':');
                    if (doisPontos > 0)
                    {
                        int.TryParse(acao.Substring(doisPontos + 1), out indice);
                    }

                    resultado = controle.InserirColuna(indice);
                }

                Capturar(controle, "paginas");
                return "pzFolhas: " + controle.Paginas().Count + " página(s) na grade " + Lista(controle.Paginas())
                    + " (antes: " + paginas + ")"
                    + "; seleção pedida " + Lista(linhas) + " (" + achadas + " achada(s))"
                    + "; selecionada depois " + Lista(controle.Selecionadas())
                    + "; ação \"" + (acao.Length == 0 ? "(nenhuma)" : acao) + "\" → " + resultado
                    + "; " + DescreverColunas(controle.Colunas())
                    + "; " + controle.DescreverInterface();
            }
            catch (Exception erro)
            {
                return "pzFolhas: falhou — " + erro.GetType().Name + ": " + erro.Message;
            }
        }

        private static void AgendarProvaDaInterface()
        {
            Timer timer = new Timer { Interval = 1500 };
            int passo = 0;
            Form editor = null;
            string alvo = Environment.GetEnvironmentVariable("POSITRON_PAGINA") ?? "2";
            string antes = TitulosDaPaginaDoDesenho.LerGrade().ContainsKey(alvo)
                ? TitulosDaPaginaDoDesenho.LerGrade()[alvo].Titulo1 : null;
            timer.Tick += (origem, evento) =>
            {
                try
                {
                    if (passo == 0)
                    {
                        PaletaDeFolhas.Mostrar();
                        Plugin.Escrever("pzFolhas UI: " + PaletaDeFolhas.Controle.DescreverInterface());
                    }
                    else if (passo == 1)
                    {
                        FolhasControle controle = PaletaDeFolhas.Controle;
                        TextBox pagina = (TextBox)controle.Controls["tbPagina"];
                        pagina.Text = alvo;
                        ((Button)controle.Controls["btPagina"]).PerformClick();
                        if (PaginaAtivaDoDesenho.Ler() != alvo) throw new InvalidOperationException("Navegação não ativou a página");
                        ((Button)controle.Controls["btSalva"]).PerformClick();
                        // Label não expõe PerformClick: dispara o mesmo evento WinForms do clique.
                        typeof(Control).GetMethod("OnClick", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                            .Invoke(controle.Controls["lb1"], new object[] { EventArgs.Empty });
                        if (AtalhosDePaginasDoDesenho.Ler()[0] != alvo) throw new InvalidOperationException("Atalho não gravado");
                        Capturar(controle, "paginas");
                        DataGridView grade = (DataGridView)controle.Controls["dg"];
                        foreach (ToolStripItem item in grade.ContextMenuStrip.Items)
                            if (item.Text == Positron.Data.Interface.MensagensDoReverso.EditarTitulos) item.PerformClick();
                    }
                    else if (passo == 2)
                    {
                        foreach (Form form in System.Windows.Forms.Application.OpenForms)
                            if (form.Name == "frmEditaTitulos") editor = form;
                        if (editor == null) throw new InvalidOperationException("Menu não abriu editor");
                        DataGridView grade = ControlesDaTela.Achar<DataGridView>(editor, "dg");
                        foreach (DataGridViewRow linha in grade.Rows)
                            if (Convert.ToString(linha.Cells[0].Value) == alvo)
                            {
                                linha.Cells[1].Value = "PROVA UI 183";
                                linha.Cells[5].Value = "UNIDADE UI 183";
                                linha.Cells[6].Value = "ALTERNATIVO UI 183";
                            }
                        if (TitulosDaPaginaDoDesenho.LerGrade()[alvo].Titulo1 != antes)
                            throw new InvalidOperationException("Grade gravou antes de Editar DWG");
                        Capturar(editor, "editar-os-titulos");
                        int quantidadeDeLinhas = grade.Rows.Count;
                        foreach (ToolStripItem item in grade.ContextMenuStrip.Items)
                            if (item.Text == "Editar DWG") item.PerformClick();
                        string unidade, alternativo;
                        UnidadeDaPaginaDoDesenho.Ler(alvo, out unidade, out alternativo);
                        if (!editor.IsDisposed || TitulosDaPaginaDoDesenho.LerGrade()[alvo].Titulo1 != "PROVA UI 183"
                            || unidade != "UNIDADE UI 183" || alternativo != "ALTERNATIVO UI 183")
                            throw new InvalidOperationException("Gravação/fechamento não confirmados");
                        Plugin.Escrever("pzFolhas UI: PASSOU — navegação pelo botão, atalho Xrecord, menu Editar Títulos, "
                            + quantidadeDeLinhas + " linha(s), edição local sem gravação antecipada; Editar DWG fora de comando; texto e XData confirmados.");
                        timer.Stop();
                        timer.Dispose();
                    }
                    passo++;
                }
                catch (Exception erro)
                {
                    timer.Stop();
                    timer.Dispose();
                    Plugin.Escrever("pzFolhas UI: FALHOU — " + erro);
                }
            };
            timer.Start();
        }

        private static void Capturar(Control controle, string nome)
        {
            string pasta = Environment.GetEnvironmentVariable("POSITRON_FOLHA_PROVA_DIR");
            if (string.IsNullOrEmpty(pasta)) return;
            System.IO.Directory.CreateDirectory(pasta);
            using (System.Drawing.Bitmap imagem = new System.Drawing.Bitmap(controle.Width, controle.Height))
            {
                controle.DrawToBitmap(imagem, new System.Drawing.Rectangle(0, 0, controle.Width, controle.Height));
                imagem.Save(System.IO.Path.Combine(pasta, nome + ".png"), System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        private static string Lista(IReadOnlyList<string> nomes)
        {
            List<string> limpos = new List<string>();
            for (int i = 0; i < nomes.Count; i++)
            {
                limpos.Add(nomes[i].Length == 0 ? "(vazio)" : nomes[i]);
            }

            return "[" + string.Join(" | ", limpos.ToArray()) + "]";
        }

        private static string DescreverColunas(IReadOnlyList<ColunaDoFormato> colunas)
        {
            List<string> itens = new List<string>();
            foreach (ColunaDoFormato coluna in colunas)
            {
                itens.Add(coluna.Visivel ? coluna.Tipo : ("ELET" + coluna.Indice + "_ausente"));
            }

            return "colunas do formato " + (ColunasDoFormato.TemAlguma(colunas) ? "visíveis" : "nenhuma")
                + " [" + string.Join(" | ", itens.ToArray()) + "]";
        }
    }
}

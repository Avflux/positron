using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Positron.Data.Interface.Mapas;

namespace Positron.Plugin.Interface.Telas
{
    /// <summary>
    /// Reconstrói uma **janela do reverso** a partir do mapa (<see cref="FormulariosDoReverso"/>)
    /// e a abre **dentro do CAD**, como o original: o `frm*` do Eletron4Z faz
    /// `Application.ShowModelessDialog(this)` no próprio construtor (121 chamadas no reverso),
    /// então a janela fica presa ao CAD e dá para continuar desenhando com ela aberta.
    ///
    /// O que é fiel: o título, o `ClientSize`, cada controle na posição e no tamanho do designer,
    /// os textos (a `mMensagem` do original) e os **ícones do produto** (a `lib/Icons`, extraída
    /// do DLL). Os rótulos com `{expressão}` são os que o original só monta em tempo de execução
    /// (um nome de painel buscado no banco, por exemplo) — aparecem como estão, sem valor
    /// inventado. O comportamento de cada tela é das rodadas seguintes; aqui entra a **casca**.
    /// </summary>
    internal static class RenderizadorDeTelas
    {
        private static readonly Dictionary<string, Font> Fontes = new Dictionary<string, Font>(StringComparer.Ordinal);

        private static Font _padrao;

        /// <summary>Monta a janela (sem mostrar) e devolve o formulário pronto.</summary>
        internal static Form Montar(Tela tela)
        {
            if (tela == null)
            {
                throw new ArgumentNullException("tela");
            }

            Form janela = new Form();
            janela.SuspendLayout();
            janela.Font = FontePadrao();
            // O designer do original usa AutoScaleDimensions 6 x 13 (a fonte padrao do VB).
            janela.AutoScaleDimensions = new SizeF(6F, 13F);
            janela.AutoScaleMode = AutoScaleMode.Font;
            janela.ClientSize = new Size(tela.Largura, tela.Altura);
            janela.Text = string.IsNullOrEmpty(tela.Titulo) ? tela.Nome : tela.Titulo;
            Aplicar(janela, tela.Propriedades, null);

            Dictionary<string, Control> controles = new Dictionary<string, Control>(StringComparer.Ordinal);
            Dictionary<string, ToolStripItem> itens = new Dictionary<string, ToolStripItem>(StringComparer.Ordinal);

            foreach (Campo campo in tela.Campos)
            {
                if (campo.EhColuna || campo.EhItem)
                {
                    continue;
                }

                Control controle = CriarControle(campo, controles);
                if (controle != null)
                {
                    if (!string.IsNullOrEmpty(campo.Nome))
                    {
                        controles[campo.Nome] = controle;
                    }

                    continue;
                }

                ToolStripItem item = CriarItem(campo);
                if (item != null && !string.IsNullOrEmpty(campo.Nome))
                {
                    itens[campo.Nome] = item;
                }
            }

            PreencherGradesEListas(tela, controles);

            // Uma vez por recipiente: o `TabPages.Add` (e o `Items.Add` da barra) repetido duplica.
            Ligar(janela, string.Empty, tela, controles, itens);
            HashSet<string> ligados = new HashSet<string>(StringComparer.Ordinal);
            foreach (Campo campo in tela.Campos)
            {
                if (!string.IsNullOrEmpty(campo.Pai) && ligados.Add(campo.Pai))
                {
                    Ligar(janela, campo.Pai, tela, controles, itens);
                }
            }

            janela.ResumeLayout(false);
            janela.PerformLayout();

            // As telas cuja regra ja esta portada ganham o comportamento aqui; as outras abrem
            // so com a casca fiel. Nunca lanca (reporta na linha de comando).
            LigacoesDasTelas.Preencher(janela, tela);
            return janela;
        }

        /// <summary>
        /// Abre a janela pelo nome do `frm` do original e devolve a linha de resumo (nunca lança:
        /// o comando do CAD reporta o motivo).
        /// </summary>
        internal static string Abrir(string nome)
        {
            return Abrir(nome, "JANELA");
        }

        /// <summary>
        /// Abre a tela com o **rótulo do chamador** na frente da linha (o comando do original, por
        /// exemplo: <c>GERDWG: "Gerenciador de DWGs" (frmGerenciadorDWG) aberta no CAD — 42
        /// controle(s).</c>). É o que faz o comando do original responder com o próprio nome.
        /// </summary>
        internal static string Abrir(string nome, string rotulo)
        {
            VarianteDeTela variante = VariantesDoReverso.Buscar(nome) ?? VariantesDoReverso.Buscar(rotulo);
            string nomeTela = variante != null ? variante.Tela : nome;

            Tela tela = FormulariosDoReverso.Buscar(nomeTela);
            if (tela == null)
            {
                return rotulo + ": não há \"" + nome + "\" no mapa do reverso (são " + FormulariosDoReverso.Quantidade + " telas).";
            }

            try
            {
                if (variante != null)
                {
                    tela = variante.Aplicar(tela);
                }

                Form janela = Montar(tela);

                // A ligação descarta a janela quando o original não a abre (o `MsgBox` do
                // construtor: arquivo não cadastrado, projeto sem cabos...); o motivo já foi escrito.
                if (janela.IsDisposed)
                {
                    return rotulo + ": \"" + tela.Titulo + "\" (" + tela.Nome + ") não aberta.";
                }

                Mostrar(janela);
                return rotulo + ": \"" + tela.Titulo + "\" (" + tela.Nome + ") aberta no CAD — " + tela.Campos.Count + " controle(s).";
            }
            catch (Exception erro)
            {
                return rotulo + ": falhou em \"" + tela.Nome + "\" — " + erro.Message + ".";
            }
        }

        /// <summary>
        /// O nome da janela pedido pela variável <c>POSITRON_JANELA</c> (o mesmo padrão
        /// <c>POSITRON_*</c> do resto do plugin, que o harness usa), ou <c>null</c> quando não há.
        /// </summary>
        internal static string NomeDaVariavel()
        {
            string nome = Environment.GetEnvironmentVariable("POSITRON_JANELA");
            if (string.IsNullOrEmpty(nome) || nome.Trim().Length == 0)
            {
                return null;
            }

            return nome.Trim();
        }

        /// <summary>
        /// A prova da casca: monta **todas** as telas do mapa e descarta — sem abrir nada, para
        /// caber num script. Devolve quantas montaram e as que falharam (o original tem 127).
        /// </summary>
        internal static string ConferirTodas()
        {
            List<string> falhas = new List<string>();
            int montadas = 0;
            foreach (Tela tela in FormulariosDoReverso.Todas)
            {
                try
                {
                    using (Form janela = Montar(tela))
                    {
                        montadas++;
                    }
                }
                catch (Exception erro)
                {
                    falhas.Add(tela.Nome + ": " + erro.Message);
                }
            }

            string resumo = "JANELAS: " + montadas + " de " + FormulariosDoReverso.Quantidade + " tela(s) do reverso montada(s)";
            if (falhas.Count == 0)
            {
                resumo += ", nenhuma falha.";
            }
            else
            {
                resumo += ", " + falhas.Count + " falha(s): " + string.Join(" | ", falhas.ToArray()) + ".";
            }

            // A guarda das ligacoes: uma ligacao registrada com o nome de tela errado nunca acha a
            // janela e ficaria muda para sempre - entao o nome e conferido contra o mapa aqui.
            List<string> orfas = new List<string>();
            foreach (ILigacaoDeTela ligacao in LigacoesDasTelas.Ligadas)
            {
                if (FormulariosDoReverso.Buscar(ligacao.NomeDaTela) == null)
                {
                    orfas.Add(ligacao.NomeDaTela);
                }
            }

            // O outro lado da casca: quantas telas ja tem a **regra** ligada (as outras abrem so
            // com a formatacao). E a medida que cresce uma a uma, a cada metodo integrado.
            resumo += " Ligacoes: " + LigacoesDasTelas.Ligadas.Count + " de "
                + FormulariosDoReverso.Quantidade + " tela(s) com regra (" + LigacoesDasTelas.Nomes() + ")";
            if (orfas.Count > 0)
            {
                return resumo + ". ATENCAO: " + string.Join(", ", orfas.ToArray()) + " nao esta(o) no mapa de telas.";
            }

            return resumo + ".";
        }

        private static void Mostrar(Form janela)
        {
            // A janela modeless do CAD. Qualificado porque `System.Windows.Forms.Application`
            // (trazido pelo `using System.Windows.Forms`) tambem se chama `Application`.
#if AUTOCAD
            Autodesk.AutoCAD.ApplicationServices.Application.ShowModelessDialog(janela);
#else
            ZwSoft.ZwCAD.ApplicationServices.Application.ShowModelessDialog(janela);
#endif
        }

        // ------------------------------------------------------------------ a montagem

        private static Control CriarControle(Campo campo, Dictionary<string, Control> controles)
        {
            Control novo = NovoControle(campo.Tipo);
            if (novo == null)
            {
                return null;
            }

            try
            {
                if (!string.IsNullOrEmpty(campo.Nome))
                {
                    novo.Name = campo.Nome;
                }

                novo.Text = TextoDoControle(novo, campo.Texto);
                if (campo.TemLocal)
                {
                    // sem clamp: o designer do original tem controle em coordenada negativa
                    // (o `BTCorrigaPortasDiscrepantes`, por exemplo, esta em (-18, ...))
                    novo.Location = new Point(campo.X, campo.Y);
                }

                if (campo.TemTamanho)
                {
                    novo.Size = new Size(campo.Largura, campo.Altura);
                }

                if (!string.IsNullOrEmpty(campo.Imagem))
                {
                    Bitmap imagem = IconesEmbutidos.BitmapDe(campo.Imagem);
                    if (imagem != null)
                    {
                        DefinirImagem(novo, imagem);
                    }
                }

                Aplicar(novo, campo.Propriedades, controles);
            }
            catch (Exception)
            {
                // um controle que nao aceita uma propriedade do designer nao derruba a tela
            }

            return novo;
        }

        /// <summary>
        /// O texto do designer, menos num caso: o campo de entrada cujo valor inteiro só existe em
        /// execução (`{DeclaracoesGeral.Conf.AlturaFonte}`) abre vazio — a expressão crua no lugar
        /// do número não é o que o original mostra. Rótulo e título continuam com a expressão.
        /// </summary>
        private static string TextoDoControle(Control controle, string texto)
        {
            texto = texto ?? string.Empty;
            bool soExecucao = texto.Length > 1 && texto[0] == '{' && texto[texto.Length - 1] == '}';
            if (soExecucao && (controle is TextBoxBase || controle is ComboBox || controle is UpDownBase))
            {
                return string.Empty;
            }

            return texto;
        }

        private static ToolStripItem CriarItem(Campo campo)
        {
            ToolStripItem novo;
            switch (campo.Tipo)
            {
                case "ToolStripButton": novo = new ToolStripButton(); break;
                case "ToolStripComboBox": novo = new ToolStripComboBox(); break;
                case "ToolStripDropDownButton": novo = new ToolStripDropDownButton(); break;
                case "ToolStripLabel": novo = new ToolStripLabel(); break;
                case "ToolStripMenuItem": novo = new ToolStripMenuItem(); break;
                case "ToolStripSeparator": novo = new ToolStripSeparator(); break;
                case "ToolStripTextBox": novo = new ToolStripTextBox(); break;
                case "ToolStripStatusLabel": novo = new ToolStripStatusLabel(); break;
                default: return null;
            }

            try
            {
                if (!string.IsNullOrEmpty(campo.Nome))
                {
                    novo.Name = campo.Nome;
                }

                if (!(novo is ToolStripSeparator))
                {
                    novo.Text = campo.Texto ?? string.Empty;
                }

                if (!string.IsNullOrEmpty(campo.Imagem))
                {
                    novo.Image = IconesEmbutidos.BitmapDe(campo.Imagem);
                }

                Aplicar(novo, campo.Propriedades, null);
            }
            catch (Exception)
            {
            }

            return novo;
        }

        private static Control NovoControle(string tipo)
        {
            switch (tipo)
            {
                case "Button": return new Button();
                case "CheckBox": return new CheckBox();
                case "CheckedListBox": return new CheckedListBox();
                case "ComboBox": return new ComboBox();
                case "ContextMenuStrip": return new ContextMenuStrip();
                case "DataGridView": return new DataGridView();
                case "DateTimePicker": return new DateTimePicker();
                case "FlowLayoutPanel": return new FlowLayoutPanel();
                case "GroupBox": return new GroupBox();
                case "Label": return new Label();
                case "LinkLabel": return new LinkLabel();
                case "ListBox": return new ListBox();
                case "ListView": return new ListView();
                case "MaskedTextBox": return new MaskedTextBox();
                case "MenuStrip": return new MenuStrip();
                case "MonthCalendar": return new MonthCalendar();
                case "NumericUpDown": return new NumericUpDown();
                case "Panel": return new Panel();
                case "PictureBox": return new PictureBox();
                case "ProgressBar": return new ProgressBar();
                case "RadioButton": return new RadioButton();
                case "RichTextBox": return new RichTextBox();
                case "SplitContainer": return new SplitContainer();
                case "StatusStrip": return new StatusStrip();
                case "TabControl": return new TabControl();
                case "TabPage": return new TabPage();
                case "TableLayoutPanel": return new TableLayoutPanel();
                case "TextBox": return new TextBox();
                case "ToolStrip": return new ToolStrip();
                case "TreeView": return new TreeView();
                default: return null;
            }
        }

        /// <summary>As colunas das grades e os itens das listas que o original cria nas rotinas de carga.</summary>
        private static void PreencherGradesEListas(Tela tela, Dictionary<string, Control> controles)
        {
            // Pelos filhos de cada controle (na ordem do original), nao pela lista crua dos campos.
            foreach (KeyValuePair<string, Control> par in controles)
            {
                DataGridView grade = par.Value as DataGridView;
                ComboBox lista = par.Value as ComboBox;
                if (grade == null && lista == null)
                {
                    continue;
                }

                foreach (Campo campo in tela.Filhos(par.Key))
                {
                    if (campo.EhColuna && grade != null)
                    {
                        DataGridViewColumn coluna = new DataGridViewTextBoxColumn();
                        coluna.HeaderText = campo.Texto ?? string.Empty;
                        if (!string.IsNullOrEmpty(campo.Nome))
                        {
                            coluna.Name = campo.Nome;
                        }

                        // a largura (do designer ou a que a rotina de carga calcula) e o Visible
                        Aplicar(coluna, campo.Propriedades, null);
                        grade.Columns.Add(coluna);
                    }
                    else if (campo.EhItem && lista != null)
                    {
                        lista.Items.Add(campo.Texto ?? string.Empty);
                    }
                }
            }
        }

        /// <summary>Pendura os filhos de um controle (ou da janela) no lugar certo do original.</summary>
        private static void Ligar(
            Form janela,
            string pai,
            Tela tela,
            Dictionary<string, Control> controles,
            Dictionary<string, ToolStripItem> itens)
        {
            Control recipiente = null;
            ToolStrip barra = null;
            if (string.IsNullOrEmpty(pai))
            {
                recipiente = janela;
            }
            else
            {
                controles.TryGetValue(pai, out recipiente);
                barra = recipiente as ToolStrip;
            }

            foreach (Campo filho in tela.Filhos(pai))
            {
                if (filho.EhColuna || filho.EhItem)
                {
                    continue;
                }

                ToolStripItem item;
                if (barra != null && !string.IsNullOrEmpty(filho.Nome) && itens.TryGetValue(filho.Nome, out item))
                {
                    barra.Items.Add(item);
                    continue;
                }

                if (recipiente == null || string.IsNullOrEmpty(filho.Nome) || !controles.ContainsKey(filho.Nome))
                {
                    continue;
                }

                Control controle = controles[filho.Nome];

                // O menu de contexto e do controle, nao da janela: nao entra no Controls.
                if (controle is ContextMenuStrip)
                {
                    continue;
                }

                TabControl abas = recipiente as TabControl;
                TabPage pagina = controle as TabPage;
                if (abas != null && pagina != null)
                {
                    abas.TabPages.Add(pagina);
                    continue;
                }

                recipiente.Controls.Add(controle);
                MenuStrip menu = controle as MenuStrip;
                if (menu != null && recipiente is Form)
                {
                    ((Form)recipiente).MainMenuStrip = menu;
                }
            }
        }

        private static void DefinirImagem(Control controle, Bitmap imagem)
        {
            ButtonBase botao = controle as ButtonBase;
            if (botao != null)
            {
                botao.Image = imagem;
                return;
            }

            PictureBox quadro = controle as PictureBox;
            if (quadro != null)
            {
                quadro.Image = imagem;
                return;
            }

            Label rotulo = controle as Label;
            if (rotulo != null)
            {
                rotulo.Image = imagem;
            }
        }

        // ------------------------------------------------------------------ as propriedades

        /// <summary>
        /// Aplica as propriedades do designer **pelo tipo do próprio controle**: assim o
        /// `TextAlign` de um `TextBox` sai como `HorizontalAlignment` e o de um `Label` como
        /// `ContentAlignment`, e o `SelectionMode` de uma grade não se confunde com o de uma lista
        /// — a mesma fidelidade que a propriedade tem no original. O que não casa fica de fora.
        /// </summary>
        private static void Aplicar(object alvo, IReadOnlyList<Par> propriedades, Dictionary<string, Control> controles)
        {
            if (alvo == null || propriedades == null)
            {
                return;
            }

            foreach (Par par in propriedades)
            {
                try
                {
                    AplicarUma(alvo, par, controles);
                }
                catch (Exception)
                {
                    // propriedade que o controle nao aceita: nao derruba a tela
                }
            }
        }

        private static void AplicarUma(object alvo, Par par, Dictionary<string, Control> controles)
        {
            if (par == null || string.IsNullOrEmpty(par.Nome))
            {
                return;
            }

            if (par.Nome == "ContextMenuStrip")
            {
                Control menu;
                if (controles != null && controles.TryGetValue(par.Valor ?? string.Empty, out menu))
                {
                    Propriedade(alvo, "ContextMenuStrip", menu);
                }

                return;
            }

            // `ColumnHeadersDefaultCellStyle.Font`: o estilo de celula do designer, sub-propriedade
            // por sub-propriedade sobre o objeto que o controle ja tem
            string nome = par.Nome;
            int ponto = nome.IndexOf('.');
            if (ponto > 0)
            {
                PropertyInfo dono = alvo.GetType().GetProperty(nome.Substring(0, ponto), BindingFlags.Public | BindingFlags.Instance);
                alvo = dono == null ? null : dono.GetValue(alvo, null);
                if (alvo == null)
                {
                    return;
                }

                nome = nome.Substring(ponto + 1);
            }

            PropertyInfo destino = alvo.GetType().GetProperty(nome, BindingFlags.Public | BindingFlags.Instance);
            if (destino == null || !destino.CanWrite)
            {
                return;
            }

            Type tipo = destino.PropertyType;
            object valor = null;
            if (tipo == typeof(string))
            {
                valor = par.Valor;
            }
            else if (tipo == typeof(bool))
            {
                valor = string.Equals(par.Valor, "True", StringComparison.OrdinalIgnoreCase);
            }
            else if (tipo == typeof(int))
            {
                int numero;
                if (!int.TryParse(par.Valor, NumberStyles.Integer, CultureInfo.InvariantCulture, out numero))
                {
                    return;
                }

                valor = numero;
            }
            else if (tipo == typeof(decimal))
            {
                decimal numero;
                if (!decimal.TryParse(par.Valor, NumberStyles.Number, CultureInfo.InvariantCulture, out numero))
                {
                    return;
                }

                valor = numero;
            }
            else if (tipo == typeof(char))
            {
                if (string.IsNullOrEmpty(par.Valor) || par.Valor.Length != 1)
                {
                    return;
                }

                valor = par.Valor[0];
            }
            else if (tipo == typeof(Color))
            {
                Color cor = CorDe(par.Valor);
                if (cor.IsEmpty)
                {
                    return;
                }

                valor = cor;
            }
            else if (tipo == typeof(Font))
            {
                Font fonte = FonteDe(par.Valor);
                if (fonte == null)
                {
                    return;
                }

                valor = fonte;
            }
            else if (tipo == typeof(Image))
            {
                Bitmap imagem = IconesEmbutidos.BitmapDe(par.Valor);
                if (imagem == null)
                {
                    return;
                }

                valor = imagem;
            }
            else if (tipo.IsEnum)
            {
                valor = Enum.Parse(tipo, par.Valor, true);
            }
            else
            {
                return;
            }

            destino.SetValue(alvo, valor, null);
        }

        private static void Propriedade(object alvo, string nome, object valor)
        {
            PropertyInfo destino = alvo.GetType().GetProperty(nome, BindingFlags.Public | BindingFlags.Instance);
            if (destino != null && destino.CanWrite)
            {
                destino.SetValue(alvo, valor, null);
            }
        }

        private static Font FontePadrao()
        {
            if (_padrao == null)
            {
                _padrao = FonteDe("\"Microsoft Sans Serif\", 8.25f, FontStyle.Regular");
            }

            return _padrao;
        }

        /// <summary>O `new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, ...)` do designer.</summary>
        private static Font FonteDe(string valor)
        {
            if (string.IsNullOrEmpty(valor))
            {
                return null;
            }

            Font guardada;
            if (Fontes.TryGetValue(valor, out guardada))
            {
                return guardada;
            }

            Match nome = Regex.Match(valor, "\"([^\"]+)\"\\s*,\\s*([0-9.]+)f?");
            if (!nome.Success)
            {
                return null;
            }

            float tamanho;
            if (!float.TryParse(nome.Groups[2].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out tamanho))
            {
                return null;
            }

            FontStyle estilo = FontStyle.Regular;
            Match achado = Regex.Match(valor, "FontStyle\\.(\\w+)");
            if (achado.Success)
            {
                try
                {
                    estilo = (FontStyle)Enum.Parse(typeof(FontStyle), achado.Groups[1].Value, true);
                }
                catch (ArgumentException)
                {
                }
            }

            Font fonte = new Font(nome.Groups[1].Value, tamanho, estilo);
            Fontes[valor] = fonte;
            return fonte;
        }

        /// <summary>O `Color.White` / `SystemColors.Control` do designer, pelo nome conhecido.</summary>
        private static Color CorDe(string valor)
        {
            if (string.IsNullOrEmpty(valor))
            {
                return Color.Empty;
            }

            Color cor = Color.FromName(valor);
            return cor;
        }
    }
}

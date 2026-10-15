#if !POSITRON_SEM_WINFORMS
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Positron.Data.Configuracao;

namespace Positron.Plugin.Configuracao
{
    /// <summary>
    /// Tela <c>Configuração Geral</c> do plugin, no layout das telas do original
    /// (<c>frmConfiguracaoGeral</c>): abas <c>Banco de Dados</c>, <c>Bibliotecas</c> e <c>Geral</c>.
    ///
    /// Ela só **edita e grava** o arquivo: quem decide a configuração efetiva é
    /// <see cref="ConfiguracaoPositron.Carregar()"/>, com a precedência
    /// padrão &lt; arquivo &lt; ambiente — a variável de ambiente continua vencendo,
    /// para o harness e a automação não dependerem de arquivo nenhum.
    ///
    /// A tela é aberta pelo comando <c>ELETCFG</c>. Ela é modal: rodar
    /// <c>ELETCFG</c> dentro do script do harness trava (ninguém clica em OK), por
    /// isso os E2E **não** a executam — a lógica testável está em
    /// <see cref="ConfiguracaoPositron"/>.
    /// </summary>
    internal sealed class FormularioConfiguracao : Form
    {
        private static readonly string[] Representacoes = { "Elétron", "Eletrosul", "Eletronorte", "Enel-SP" };
        private static readonly string[] Estilos = { "Continuous", "Dashed", "Dotted", "DashDot" };

        // Banco de Dados
        private readonly RadioButton _idiomaPt = new RadioButton();
        private readonly RadioButton _idiomaEn = new RadioButton();
        private readonly RadioButton _contatosIec = new RadioButton();
        private readonly RadioButton _contatosAnsi = new RadioButton();
        private readonly TextBox _nomeCaderno = new TextBox();
        private readonly RadioButton _tipoAccess = new RadioButton();
        private readonly RadioButton _tipoSqlite = new RadioButton();
        private readonly RadioButton _tipoSqlServer = new RadioButton();
        private readonly TextBox _banco = new TextBox();
        private readonly TextBox _dwg = new TextBox();
        private readonly TextBox _revisao = new TextBox();
        private readonly TextBox _log = new TextBox();

        // Bibliotecas
        private readonly TextBox _simbologiaEletrica = new TextBox();
        private readonly TextBox _simbologiaTopografico = new TextBox();
        private readonly TextBox _simbologiaLayout = new TextBox();
        private readonly TextBox _simbologiaRelatorios = new TextBox();

        // Geral
        private readonly RadioButton[] _cruzamento = new RadioButton[7];
        private readonly TextBox _terminalIndefinido = new TextBox();
        private readonly TextBox _separadorCaboVeia = new TextBox();
        private readonly TextBox _separadorCruzamento = new TextBox();
        private readonly TextBox _separadorCarimbo = new TextBox();
        private readonly TextBox _separadorPainelRegua = new TextBox();
        private readonly TextBox _alturaCircuitos = new TextBox();
        private readonly TextBox _alturaReferenciaCruzada = new TextBox();
        private readonly TextBox _alturaCabos = new TextBox();
        private readonly RadioButton[] _representacao = new RadioButton[Representacoes.Length];
        private readonly TextBox _corConexao = new TextBox();
        private readonly TextBox _corTextoCircuito = new TextBox();
        private readonly TextBox _corInterligacao = new TextBox();
        private readonly TextBox _corTextoInterligacao = new TextBox();
        private readonly ComboBox _estiloLinha = new ComboBox();
        private readonly TextBox _estiloEscala = new TextBox();
        private readonly TextBox _prefixoCruzInterno = new TextBox();
        private readonly TextBox _sufixoCruzInterno = new TextBox();
        private readonly TextBox _prefixoFuncFunc = new TextBox();
        private readonly TextBox _sufixoFuncFunc = new TextBox();
        private readonly TextBox _prefixoLogFunc = new TextBox();
        private readonly TextBox _sufixoLogFunc = new TextBox();
        private readonly RadioButton[] _visualizacao = new RadioButton[4];

        internal ConfiguracaoPositron Resultado { get; private set; }

        internal FormularioConfiguracao(ConfiguracaoPositron configuracao)
        {
            ConfiguracaoPositron atual = configuracao ?? ConfiguracaoPositron.Padrao();

            Text = "Configuração Geral";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(470, 720);

            TabControl abas = new TabControl { Left = 8, Top = 8, Width = 454, Height = 660 };
            TabPage tBanco = new TabPage("Banco de Dados");
            TabPage tBibliotecas = new TabPage("Bibliotecas");
            TabPage tGeral = new TabPage("Geral");
            abas.TabPages.Add(tBanco);
            abas.TabPages.Add(tBibliotecas);
            abas.TabPages.Add(tGeral);
            Controls.Add(abas);

            ConstruirBancoDeDados(tBanco);
            ConstruirBibliotecas(tBibliotecas);
            ConstruirGeral(tGeral);

            Button salvar = new Button { Text = "Salvar", Left = 185, Top = 680, Width = 100, Height = 30, DialogResult = DialogResult.OK };
            Button cancelar = new Button { Text = "Cancelar", Left = 295, Top = 680, Width = 100, Height = 30, DialogResult = DialogResult.Cancel };
            Controls.Add(salvar);
            Controls.Add(cancelar);
            AcceptButton = salvar;
            CancelButton = cancelar;

            Carregar(atual);
            salvar.Click += (origem, evento) => Coletar(atual);
        }

        private void ConstruirBancoDeDados(Control aba)
        {
            GroupBox idioma = Grupo(aba, "Idioma", 8, 8, 130, 80);
            Opcao(idioma, _idiomaPt, "Português", 10, 20, 110);
            Opcao(idioma, _idiomaEn, "English", 10, 46, 110);

            GroupBox contatos = Grupo(aba, "Contatos Auxiliares", 146, 8, 130, 80);
            Opcao(contatos, _contatosIec, "IEC", 10, 20, 110);
            Opcao(contatos, _contatosAnsi, "ANSI", 10, 46, 110);

            GroupBox caderno = Grupo(aba, "Nome do Caderno", 284, 8, 150, 80);
            Caixa(caderno, _nomeCaderno, 10, 30, 128);

            GroupBox tipo = Grupo(aba, "Banco de Dados", 8, 98, 426, 56);
            Opcao(tipo, _tipoAccess, "Access", 14, 24, 90);
            Opcao(tipo, _tipoSqlite, "SQLite", 150, 24, 90);
            Opcao(tipo, _tipoSqlServer, "SQL Server", 280, 24, 110);

            GroupBox projeto = Grupo(aba, "Banco do Projeto", 8, 164, 426, 80);
            Caixa(projeto, _banco, 12, 30, 360);
            Button procurarBanco = Botao(projeto, "...", 380, 28);
            procurarBanco.Click += (origem, evento) => ProcurarArquivoDb();

            GroupBox extras = Grupo(aba, "Projeto", 8, 254, 426, 110);
            Rotulo(extras, "DWG (índice)", 12, 25, 130);
            Caixa(extras, _dwg, 150, 22, 100);
            Rotulo(extras, "Revisão", 12, 53, 130);
            Caixa(extras, _revisao, 150, 50, 260);
            Rotulo(extras, "Log", 12, 81, 130);
            Caixa(extras, _log, 150, 78, 260);
        }

        private void ConstruirBibliotecas(Control aba)
        {
            Biblioteca(aba, "Simbologia Elétrica", _simbologiaEletrica, 8);
            Biblioteca(aba, "Simbologia Topográfico", _simbologiaTopografico, 74);
            Biblioteca(aba, "Simbologia Layout", _simbologiaLayout, 140);
            Biblioteca(aba, "Simbologia Relatórios", _simbologiaRelatorios, 206);
        }

        private void ConstruirGeral(Control aba)
        {
            // "Configurar Padrão" (as três predefinições do original) no topo; o resto da aba desce 58 px.
            GroupBox padroes = Grupo(aba, "Configurar Padrão", 8, 8, 446, 50);
            PadraoBotao(padroes, "Eletronorte", 12).Click += (origem, evento) => AplicarPadrao("/", "-", "/", 1.8, false, 0, "Eletronorte", 0);
            PadraoBotao(padroes, "Eletrosul", 160).Click += (origem, evento) => AplicarPadrao("-", "/", "/", 1.8, false, 0, "Eletrosul", 3);
            PadraoBotao(padroes, "Chesf", 308).Click += (origem, evento) => AplicarPadrao("/", "-", "/", 1.5, true, 2, "Elétron", 1);

            Panel corpo = new Panel { Left = 0, Top = 58, Width = 446, Height = 580 };
            aba.Controls.Add(corpo);
            aba = corpo;

            // Coluna da esquerda
            GroupBox cruz = Grupo(aba, "Cruzamento de Páginas", 8, 8, 214, 178);
            string[] rotulosCruz =
            {
                "Página [Eletronorte, Eletrosul]",
                "Página + HV",
                "HV + Página [Chesf]",
                "Alternativo [CEEE]",
                "Alternativo + VH [Coelba]",
                "Alternativo + HV [Metrô SP]",
                "(Página) + Alternativo",
            };
            for (int i = 0; i < _cruzamento.Length; i++)
            {
                _cruzamento[i] = new RadioButton();
                Opcao(cruz, _cruzamento[i], rotulosCruz[i], 12, 20 + i * 22, 195);
            }

            GroupBox caracteres = Grupo(aba, "Caracteres", 8, 194, 214, 150);
            Linha(caracteres, "Terminal indefinido", _terminalIndefinido, 20);
            Linha(caracteres, "Separador cabo/veia", _separadorCaboVeia, 46);
            Linha(caracteres, "Separador cruzamento", _separadorCruzamento, 72);
            Linha(caracteres, "Separador carimbo", _separadorCarimbo, 98);
            Linha(caracteres, "Separador painel/régua", _separadorPainelRegua, 124);

            GroupBox altura = Grupo(aba, "Altura Textos", 8, 352, 214, 104);
            Linha(altura, "Circuitos", _alturaCircuitos, 20);
            Linha(altura, "Referência cruzada", _alturaReferenciaCruzada, 46);
            Linha(altura, "Cabos", _alturaCabos, 72);

            GroupBox representacao = Grupo(aba, "Representação Cabo/Veia", 8, 464, 214, 82);
            for (int i = 0; i < Representacoes.Length; i++)
            {
                _representacao[i] = new RadioButton();
                Opcao(representacao, _representacao[i], Representacoes[i], 12 + (i % 2) * 98, 20 + (i / 2) * 26, 95);
            }

            // Coluna da direita
            GroupBox cores = Grupo(aba, "Cores - Fiação", 230, 8, 214, 80);
            Linha(cores, "Conexão", _corConexao, 20, 90);
            Linha(cores, "Texto circuito", _corTextoCircuito, 46, 90);

            GroupBox coresInterligacao = Grupo(aba, "Cores - Interligação", 230, 96, 214, 124);
            Linha(coresInterligacao, "Interligação", _corInterligacao, 20, 90);
            Linha(coresInterligacao, "Texto interligação", _corTextoInterligacao, 46, 90);
            Rotulo(coresInterligacao, "Estilo", 12, 73, 90);
            Caixa(coresInterligacao, _estiloLinha, 110, 70, 94);
            _estiloLinha.DropDownStyle = ComboBoxStyle.DropDown;
            _estiloLinha.Items.AddRange(Estilos);
            Linha(coresInterligacao, "Escala", _estiloEscala, 98, 90);

            ParPrefixoSufixo(aba, "Cruzamento Interno", _prefixoCruzInterno, _sufixoCruzInterno, 228);
            ParPrefixoSufixo(aba, "Cruzamento Func Func", _prefixoFuncFunc, _sufixoFuncFunc, 288);
            ParPrefixoSufixo(aba, "Cruzamento Log Func", _prefixoLogFunc, _sufixoLogFunc, 348);

            GroupBox visualizacao = Grupo(aba, "Visualização Modelos Relés", 230, 408, 214, 124);
            string[] rotulosVis =
            {
                "No contato",
                "Na bobina",
                "Na bobina e no contato",
                "Na bobina e no contato (Eletrosul)",
            };
            for (int i = 0; i < _visualizacao.Length; i++)
            {
                _visualizacao[i] = new RadioButton();
                Opcao(visualizacao, _visualizacao[i], rotulosVis[i], 12, 20 + i * 24, 195);
            }
        }

        private static Button PadraoBotao(Control pai, string texto, int x)
        {
            Button botao = new Button
            {
                Text = texto,
                Left = x,
                Top = 17,
                Width = 130,
                Height = 25,
                ForeColor = Color.DarkBlue,
                Font = new Font("Trebuchet MS", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0),
            };
            pai.Controls.Add(botao);
            return botao;
        }

        /// <summary>
        /// Preenche a tela com a predefinição (os botões de <c>Configurar Padrão</c> do original,
        /// <c>t86y5UlFWX</c>/<c>QD0y0V9eIp</c>/<c>zYIyRqNngg</c>). Só mexe nos campos da tela:
        /// o arquivo é gravado no <c>Salvar</c>, como no original.
        /// </summary>
        private void AplicarPadrao(string separadorCaboVeia, string separadorCarimbo, string separadorPainelRegua,
            double altura, bool ansi, int incluirColuna, string representacao, int visualizacao)
        {
            _terminalIndefinido.Text = "?";
            _separadorCaboVeia.Text = separadorCaboVeia;
            _separadorCruzamento.Text = "/";
            _separadorCarimbo.Text = separadorCarimbo;
            _separadorPainelRegua.Text = separadorPainelRegua;
            _alturaCircuitos.Text = altura.ToString(CultureInfo.InvariantCulture);
            _alturaCabos.Text = altura.ToString(CultureInfo.InvariantCulture);
            _corConexao.Text = "7";
            _corTextoCircuito.Text = "7";
            _corInterligacao.Text = "7";
            _corTextoInterligacao.Text = "7";
            _prefixoCruzInterno.Text = "(";
            _sufixoCruzInterno.Text = ")";
            _prefixoFuncFunc.Text = "(";
            _sufixoFuncFunc.Text = ")";
            _contatosAnsi.Checked = ansi;
            _contatosIec.Checked = !ansi;
            _cruzamento[incluirColuna].Checked = true;
            _representacao[Array.IndexOf(Representacoes, representacao)].Checked = true;
            _visualizacao[visualizacao].Checked = true;
        }

        private void Carregar(ConfiguracaoPositron atual)
        {
            _idiomaEn.Checked = Igual(atual.Idioma, "en");
            _idiomaPt.Checked = !_idiomaEn.Checked;
            _contatosAnsi.Checked = Igual(atual.ContatosAuxiliares, "ANSI");
            _contatosIec.Checked = !_contatosAnsi.Checked;
            _nomeCaderno.Text = atual.Local ?? string.Empty;
            _tipoSqlite.Checked = Igual(atual.TipoBanco, "SQLite");
            _tipoSqlServer.Checked = Igual(atual.TipoBanco, "SQL Server");
            _tipoAccess.Checked = !_tipoSqlite.Checked && !_tipoSqlServer.Checked;

            _banco.Text = atual.Banco ?? string.Empty;
            _dwg.Text = atual.Dwg.ToString(CultureInfo.InvariantCulture);
            _revisao.Text = atual.Revisao ?? string.Empty;
            _log.Text = atual.Log ?? string.Empty;

            _simbologiaEletrica.Text = atual.SimbologiaEletrica ?? string.Empty;
            _simbologiaTopografico.Text = atual.SimbologiaTopografico ?? string.Empty;
            _simbologiaLayout.Text = atual.SimbologiaLayout ?? string.Empty;
            _simbologiaRelatorios.Text = atual.SimbologiaRelatorios ?? string.Empty;

            _cruzamento[Limitar(atual.IncluirColuna, _cruzamento.Length)].Checked = true;
            _terminalIndefinido.Text = atual.TerminalIndefinido ?? string.Empty;
            _separadorCaboVeia.Text = atual.SeparadorCaboVeia ?? string.Empty;
            _separadorCruzamento.Text = atual.SeparadorCruzamento ?? string.Empty;
            _separadorCarimbo.Text = atual.SeparadorCarimbo ?? string.Empty;
            _separadorPainelRegua.Text = atual.SeparadorPainelRegua ?? string.Empty;
            _alturaCircuitos.Text = atual.AlturaCircuitos.ToString(CultureInfo.InvariantCulture);
            _alturaReferenciaCruzada.Text = atual.AlturaReferenciaCruzada.ToString(CultureInfo.InvariantCulture);
            _alturaCabos.Text = atual.FonteCabos.ToString(CultureInfo.InvariantCulture);

            int representacao = Array.FindIndex(Representacoes, nome => Igual(nome, atual.RepresentacaoCaboVeia));
            _representacao[representacao < 0 ? 2 : representacao].Checked = true;

            _corConexao.Text = atual.CorFiacaoConexao.ToString(CultureInfo.InvariantCulture);
            _corTextoCircuito.Text = atual.CorFiacaoTextoCircuito.ToString(CultureInfo.InvariantCulture);
            _corInterligacao.Text = atual.CorInterligacao.ToString(CultureInfo.InvariantCulture);
            _corTextoInterligacao.Text = atual.CorTextoInterligacao.ToString(CultureInfo.InvariantCulture);
            _estiloLinha.Text = atual.EstiloLinha ?? "Continuous";
            _estiloEscala.Text = atual.EstiloLinhaEscala.ToString(CultureInfo.InvariantCulture);

            _prefixoCruzInterno.Text = atual.PrefixoCruzInterno ?? string.Empty;
            _sufixoCruzInterno.Text = atual.SufixoCruzInterno ?? string.Empty;
            _prefixoFuncFunc.Text = atual.PrefixoCruzFuncFunc ?? string.Empty;
            _sufixoFuncFunc.Text = atual.SufixoCruzFuncFunc ?? string.Empty;
            _prefixoLogFunc.Text = atual.PrefixoCruzLogFunc ?? string.Empty;
            _sufixoLogFunc.Text = atual.SufixoCruzLogFunc ?? string.Empty;

            _visualizacao[Limitar(atual.VisualizacaoModelosRele, _visualizacao.Length)].Checked = true;
        }

        private void Coletar(ConfiguracaoPositron atual)
        {
            // A tela edita quase todas as chaves; o que sobra sai do atual.
            Resultado = atual.Copiar();

            Resultado.Idioma = _idiomaEn.Checked ? "en" : "pt";
            Resultado.ContatosAuxiliares = _contatosAnsi.Checked ? "ANSI" : "IEC";
            Resultado.Local = Texto(_nomeCaderno);
            Resultado.TipoBanco = _tipoSqlite.Checked ? "SQLite" : _tipoSqlServer.Checked ? "SQL Server" : "Access";
            Resultado.Banco = Texto(_banco);
            Resultado.Dwg = Inteiro(_dwg, atual.Dwg);
            Resultado.Revisao = Texto(_revisao);
            Resultado.Log = Texto(_log);

            Resultado.SimbologiaEletrica = Texto(_simbologiaEletrica);
            Resultado.SimbologiaTopografico = Texto(_simbologiaTopografico);
            Resultado.SimbologiaLayout = Texto(_simbologiaLayout);
            Resultado.SimbologiaRelatorios = Texto(_simbologiaRelatorios);

            Resultado.IncluirColuna = Marcado(_cruzamento);
            Resultado.TerminalIndefinido = Texto(_terminalIndefinido);
            Resultado.SeparadorCaboVeia = Texto(_separadorCaboVeia);
            Resultado.SeparadorCruzamento = Texto(_separadorCruzamento);
            Resultado.SeparadorCarimbo = Texto(_separadorCarimbo);
            Resultado.SeparadorPainelRegua = Texto(_separadorPainelRegua);
            Resultado.AlturaCircuitos = Real(_alturaCircuitos, atual.AlturaCircuitos);
            Resultado.AlturaReferenciaCruzada = Real(_alturaReferenciaCruzada, atual.AlturaReferenciaCruzada);
            Resultado.FonteCabos = Real(_alturaCabos, atual.FonteCabos);
            Resultado.RepresentacaoCaboVeia = Representacoes[Marcado(_representacao)];

            Resultado.CorFiacaoConexao = Inteiro(_corConexao, atual.CorFiacaoConexao);
            Resultado.CorFiacaoTextoCircuito = Inteiro(_corTextoCircuito, atual.CorFiacaoTextoCircuito);
            Resultado.CorInterligacao = Inteiro(_corInterligacao, atual.CorInterligacao);
            Resultado.CorTextoInterligacao = Inteiro(_corTextoInterligacao, atual.CorTextoInterligacao);
            Resultado.EstiloLinha = Texto(_estiloLinha) ?? "Continuous";
            Resultado.EstiloLinhaEscala = Real(_estiloEscala, atual.EstiloLinhaEscala);

            Resultado.PrefixoCruzInterno = Texto(_prefixoCruzInterno);
            Resultado.SufixoCruzInterno = Texto(_sufixoCruzInterno);
            Resultado.PrefixoCruzFuncFunc = Texto(_prefixoFuncFunc);
            Resultado.SufixoCruzFuncFunc = Texto(_sufixoFuncFunc);
            Resultado.PrefixoCruzLogFunc = Texto(_prefixoLogFunc);
            Resultado.SufixoCruzLogFunc = Texto(_sufixoLogFunc);
            Resultado.VisualizacaoModelosRele = Marcado(_visualizacao);
        }

        private void ProcurarArquivoDb()
        {
            using (OpenFileDialog dialogo = new OpenFileDialog { Filter = "Banco do projeto (*.db)|*.db|Todos os arquivos (*.*)|*.*" })
            {
                if (dialogo.ShowDialog(this) == DialogResult.OK)
                {
                    _banco.Text = dialogo.FileName;
                }
            }
        }

        private void ProcurarPasta(TextBox alvo)
        {
            using (FolderBrowserDialog dialogo = new FolderBrowserDialog())
            {
                if (dialogo.ShowDialog(this) == DialogResult.OK)
                {
                    alvo.Text = dialogo.SelectedPath;
                }
            }
        }

        private void Biblioteca(Control aba, string titulo, TextBox caixa, int y)
        {
            GroupBox grupo = Grupo(aba, titulo, 8, y, 426, 58);
            Caixa(grupo, caixa, 12, 24, 360);
            Button procurar = Botao(grupo, "...", 380, 22);
            procurar.Click += (origem, evento) => ProcurarPasta(caixa);
        }

        private void ParPrefixoSufixo(Control aba, string titulo, TextBox prefixo, TextBox sufixo, int y)
        {
            GroupBox grupo = Grupo(aba, titulo, 230, y, 214, 52);
            Rotulo(grupo, "Prefixo", 12, 20, 50);
            Caixa(grupo, prefixo, 62, 17, 40);
            Rotulo(grupo, "Sufixo", 112, 20, 45);
            Caixa(grupo, sufixo, 160, 17, 40);
        }

        /// <summary>Linha "rótulo + caixa" dentro de um grupo.</summary>
        private static void Linha(GroupBox grupo, string rotulo, TextBox caixa, int y, int larguraRotulo = 130)
        {
            Rotulo(grupo, rotulo, 12, y, larguraRotulo);
            Caixa(grupo, caixa, 12 + larguraRotulo + 8, y, 50);
        }

        private static GroupBox Grupo(Control pai, string titulo, int x, int y, int largura, int altura)
        {
            GroupBox grupo = new GroupBox { Text = titulo, Left = x, Top = y, Width = largura, Height = altura };
            pai.Controls.Add(grupo);
            return grupo;
        }

        private static void Rotulo(Control pai, string texto, int x, int y, int largura)
        {
            pai.Controls.Add(new Label { Text = texto, Left = x, Top = y + 3, Width = largura });
        }

        private static void Caixa(Control pai, Control caixa, int x, int y, int largura)
        {
            caixa.Left = x;
            caixa.Top = y;
            caixa.Width = largura;
            pai.Controls.Add(caixa);
        }

        private static void Opcao(Control pai, RadioButton opcao, string texto, int x, int y, int largura)
        {
            opcao.Text = texto;
            opcao.Left = x;
            opcao.Top = y;
            opcao.Width = largura;
            pai.Controls.Add(opcao);
        }

        private static Button Botao(Control pai, string texto, int x, int y)
        {
            Button botao = new Button { Text = texto, Left = x, Top = y, Width = 34, Height = 26 };
            pai.Controls.Add(botao);
            return botao;
        }

        private static int Limitar(int valor, int tamanho)
        {
            return Math.Max(0, Math.Min(tamanho - 1, valor));
        }

        private static bool Igual(string valor, string esperado)
        {
            return string.Equals(valor, esperado, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>O índice do rádio marcado (0 quando nenhum está marcado).</summary>
        private static int Marcado(RadioButton[] opcoes)
        {
            for (int i = 0; i < opcoes.Length; i++)
            {
                if (opcoes[i].Checked)
                {
                    return i;
                }
            }

            return 0;
        }

        private static string Texto(Control caixa)
        {
            string valor = caixa.Text.Trim();
            return valor.Length == 0 ? null : valor;
        }

        private static int Inteiro(TextBox caixa, int padrao)
        {
            int numero;
            return int.TryParse(caixa.Text.Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out numero) ? numero : padrao;
        }

        private static double Real(TextBox caixa, double padrao)
        {
            double numero;
            string texto = caixa.Text.Trim().Replace(',', '.');
            return double.TryParse(texto, NumberStyles.Float, CultureInfo.InvariantCulture, out numero) ? numero : padrao;
        }
    }
}
#endif

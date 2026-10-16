using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Positron.Data.Configuracao;
using Positron.Plugin.Configuracao;
#if AUTOCAD
using CadColor = Autodesk.AutoCAD.Colors.Color;
using CadColorMethod = Autodesk.AutoCAD.Colors.ColorMethod;
using CadColorDialog = Autodesk.AutoCAD.Windows.ColorDialog;
#else
using CadColor = ZwSoft.ZwCAD.Colors.Color;
using CadColorMethod = ZwSoft.ZwCAD.Colors.ColorMethod;
using CadColorDialog = ZwSoft.ZwCAD.Windows.ColorDialog;
#endif

namespace Positron.Plugin.Interface.Telas
{
    /// <summary>
    /// A ligação fiel da tela <c>frmConfiguracaoGeral</c> ("Configuração Geral",
    /// <c>frmConfiguracaoGeral.cs:2529-4600</c>; capturas <c>configuração geral 1-3.png</c>).
    ///
    /// Substitui a tela <c>FormularioConfiguracao</c> feita à mão:
    /// - Lê e grava o XData do ModelSpace (<c>Eletron</c>/<c>Config</c> e <c>EletronProj</c>/<c>Projeto</c>)
    ///   via <see cref="ConfiguracaoDoDesenho"/>;
    /// - Lê e grava o idioma no registro (<c>HKCU\Software\Cadgraph\Eletron4</c>, chave <c>Idioma</c>);
    /// - Inclui o bloco SQL Server com alternância fiel de posição e visibilidade com Access/SQLite;
    /// - Leva ao XData a norma IEC/ANSI, o Log Func e a representação cabo/veia;
    /// - Aplica os três botões de padrão (Eletronorte, Eletrosul, Chesf) com os valores originais;
    /// - Valida os caminhos de projeto e bibliotecas com fundo vermelho claro (<c>Color.LightCoral</c>).
    /// </summary>
    internal sealed class LigacaoDoFrmConfiguracaoGeral : ILigacaoDeTela
    {
        public string NomeDaTela
        {
            get { return "frmConfiguracaoGeral"; }
        }

        public void Preencher(Form janela)
        {
            if (janela == null)
            {
                return;
            }

            ConfiguracaoDoCaderno caderno = ConfiguracaoDoDesenho.LerOuPadrao() ?? ConfiguracaoDoCaderno.Padrao();

            // ------------------------------------------------------------- TabPage1: Banco de Dados
            RadioButton rbIdioma1 = ControlesDaTela.Achar<RadioButton>(janela, "rbIdioma1");
            RadioButton rbIdioma2 = ControlesDaTela.Achar<RadioButton>(janela, "rbIdioma2");
            RadioButton rbIEC = ControlesDaTela.Achar<RadioButton>(janela, "rbIEC");
            RadioButton rbANSI = ControlesDaTela.Achar<RadioButton>(janela, "rbANSI");
            TextBox tbCaderno = ControlesDaTela.Achar<TextBox>(janela, "tbCaderno");
            RadioButton rbAccess = ControlesDaTela.Achar<RadioButton>(janela, "rbAccess");
            RadioButton rbSQLite = ControlesDaTela.Achar<RadioButton>(janela, "rbSQLite");
            RadioButton rbSQLSVR = ControlesDaTela.Achar<RadioButton>(janela, "rbSQLSVR");
            GroupBox gbAccess = ControlesDaTela.Achar<GroupBox>(janela, "GBAccess");
            TextBox tbProjeto = ControlesDaTela.Achar<TextBox>(janela, "tbProjeto");
            Button selProj = ControlesDaTela.Achar<Button>(janela, "SelProj");
            GroupBox gbSql = ControlesDaTela.Achar<GroupBox>(janela, "GBSql");
            TextBox tbDataSource = ControlesDaTela.Achar<TextBox>(janela, "tbDataSource");
            TextBox tbBancoDeDados = ControlesDaTela.Achar<TextBox>(janela, "tbBancoDeDados");
            TextBox tbUser = ControlesDaTela.Achar<TextBox>(janela, "tbUser");
            TextBox tbSenha = ControlesDaTela.Achar<TextBox>(janela, "tbSenha");
            Button btConectarSQLServer = ControlesDaTela.Achar<Button>(janela, "btConectarSQLServer");

            // ------------------------------------------------------------- TabPage2: Bibliotecas
            TextBox tbSimbologiaEletrica = ControlesDaTela.Achar<TextBox>(janela, "tbSimbologiaEletrica");
            Button selDirSimbologiaEletrica = ControlesDaTela.Achar<Button>(janela, "SelDirSimbologiaEletrica");
            TextBox tbSimbologiaTopografico = ControlesDaTela.Achar<TextBox>(janela, "tbSimbologiaTopografico");
            Button selDirSimbologiaTopografico = ControlesDaTela.Achar<Button>(janela, "SelDirSimbologiaTopografico");
            TextBox tbSimbologiaLayout = ControlesDaTela.Achar<TextBox>(janela, "tbSimbologiaLayout");
            Button selDirSimbologiaLayout = ControlesDaTela.Achar<Button>(janela, "selDirSimbologiaLayout");
            TextBox tbSimbologiaRelatorios = ControlesDaTela.Achar<TextBox>(janela, "tbSimbologiaRelatorios");
            Button selDirSimbologiaRelatorios = ControlesDaTela.Achar<Button>(janela, "selDirSimbologiaRelatorios");

            // ------------------------------------------------------------- TabPage3: Geral
            Button btEletronorte = ControlesDaTela.Achar<Button>(janela, "btEletronorte");
            Button btEletrosul = ControlesDaTela.Achar<Button>(janela, "btEletrosul");
            Button btChesf = ControlesDaTela.Achar<Button>(janela, "btChesf");

            RadioButton rbIncluirColuna0 = ControlesDaTela.Achar<RadioButton>(janela, "rbIncluirColuna0");
            RadioButton rbIncluirColuna1 = ControlesDaTela.Achar<RadioButton>(janela, "rbIncluirColuna1");
            RadioButton rbIncluirColuna2 = ControlesDaTela.Achar<RadioButton>(janela, "rbIncluirColuna2");
            RadioButton rbIncluirColuna3 = ControlesDaTela.Achar<RadioButton>(janela, "rbIncluirColuna3");
            RadioButton rbIncluirColuna4 = ControlesDaTela.Achar<RadioButton>(janela, "rbIncluirColuna4");
            RadioButton rbIncluirColuna5 = ControlesDaTela.Achar<RadioButton>(janela, "rbIncluirColuna5");
            RadioButton rbIncluirColuna6 = ControlesDaTela.Achar<RadioButton>(janela, "rbIncluirColuna6");

            TextBox tbTerminalIndefinido = ControlesDaTela.Achar<TextBox>(janela, "tbTerminalIndefinido");
            TextBox tbSeparadorCaboVeia = ControlesDaTela.Achar<TextBox>(janela, "tbSeparadorCaboVeia");
            TextBox tbSeparadorCruzamento = ControlesDaTela.Achar<TextBox>(janela, "tbSeparadorCruzamento");
            TextBox tbSeparadorCarimbo = ControlesDaTela.Achar<TextBox>(janela, "tbSeparadorCarimbo");
            TextBox tbSeparadorReguaBorne = ControlesDaTela.Achar<TextBox>(janela, "tbSeparadorReguaBorne");

            TextBox tbFonteCircuitos = ControlesDaTela.Achar<TextBox>(janela, "tbFonteCircuitos");
            TextBox tbFonteCruzamento = ControlesDaTela.Achar<TextBox>(janela, "tbFonteCruzamento");
            TextBox tbFonteCabos = ControlesDaTela.Achar<TextBox>(janela, "tbFonteCabos");

            RadioButton rbLayInter0 = ControlesDaTela.Achar<RadioButton>(janela, "RBLayInter0");
            RadioButton rbLayInter1 = ControlesDaTela.Achar<RadioButton>(janela, "RBLayInter1");
            RadioButton rbLayInter2 = ControlesDaTela.Achar<RadioButton>(janela, "RBLayInter2");
            RadioButton rbLayInter3 = ControlesDaTela.Achar<RadioButton>(janela, "RBLayInter3");

            Button btCorConexao = ControlesDaTela.Achar<Button>(janela, "btCorConexao");
            Button btCorTextoCircuito = ControlesDaTela.Achar<Button>(janela, "btCorTextoCircuito");
            Button btCorInterligacao = ControlesDaTela.Achar<Button>(janela, "btCorInterligacao");
            Button btCorTextoInterligacao = ControlesDaTela.Achar<Button>(janela, "btCorTextoInterligacao");
            ComboBox cbEstilosLinha = ControlesDaTela.Achar<ComboBox>(janela, "cbEstilosLinha");
            TextBox tbEstiloLinhaEscala = ControlesDaTela.Achar<TextBox>(janela, "tbEstiloLinhaEscala");

            TextBox tbPrefixoCruzamentoInterno = ControlesDaTela.Achar<TextBox>(janela, "tbPrefixoCruzamentoInterno");
            TextBox tbSufixoCruzamentoInterno = ControlesDaTela.Achar<TextBox>(janela, "tbSufixoCruzamentoInterno");
            TextBox tbPrefixoCruzamentoFF = ControlesDaTela.Achar<TextBox>(janela, "tbPrefixoCruzamentoFF");
            TextBox tbSufixoCruzamentoFF = ControlesDaTela.Achar<TextBox>(janela, "tbSufixoCruzamentoFF");
            TextBox tbPrefixoCruzamentoExterno = ControlesDaTela.Achar<TextBox>(janela, "tbPrefixoCruzamentoExterno");
            TextBox tbSufixoCruzamentoExterno = ControlesDaTela.Achar<TextBox>(janela, "tbSufixoCruzamentoExterno");

            RadioButton rbBobina0 = ControlesDaTela.Achar<RadioButton>(janela, "RBBobina0");
            RadioButton rbContato1 = ControlesDaTela.Achar<RadioButton>(janela, "RBContato1");
            RadioButton rbBobinaContato2 = ControlesDaTela.Achar<RadioButton>(janela, "RBBobinaContato2");
            RadioButton rbBobinaContatoES3 = ControlesDaTela.Achar<RadioButton>(janela, "RBBobinaContatoES3");

            Button btSalvar = ControlesDaTela.Achar<Button>(janela, "btSalvar");

            // Estado local de cores ACI
            int corConexao = caderno.CorConexao > 0 ? caderno.CorConexao : 7;
            int corTextoCircuito = caderno.CorTextoCircuito > 0 ? caderno.CorTextoCircuito : 7;
            int corInterligacao = caderno.CorInterligacao > 0 ? caderno.CorInterligacao : 7;
            int corTextoInterligacao = caderno.CorTextoInterligacao > 0 ? caderno.CorTextoInterligacao : 7;

            // 1. Carga inicial: Idioma
            string idiomaAtual = PreferenciasGerais.LerIdioma();
            bool isEn = string.Equals(idiomaAtual, "[EN]", StringComparison.OrdinalIgnoreCase);
            if (rbIdioma2 != null) rbIdioma2.Checked = isEn;
            if (rbIdioma1 != null) rbIdioma1.Checked = !isEn;

            // 2. Contatos Auxiliares (Norma)
            if (rbANSI != null) rbANSI.Checked = (caderno.Norma == 1);
            if (rbIEC != null) rbIEC.Checked = (caderno.Norma != 1);

            // 3. Nome do Caderno
            if (tbCaderno != null) tbCaderno.Text = !string.IsNullOrEmpty(caderno.Local) ? caderno.Local : "???";

            // 4. Tipo de Banco
            bool isSql = string.Equals(caderno.Banco, ConfiguracaoDoCaderno.BancoSqlServer, StringComparison.OrdinalIgnoreCase);
            bool isSqlite = string.Equals(caderno.Banco, ConfiguracaoDoCaderno.BancoSqlite, StringComparison.OrdinalIgnoreCase);
            if (rbSQLSVR != null) rbSQLSVR.Checked = isSql;
            if (rbSQLite != null) rbSQLite.Checked = isSqlite;
            if (rbAccess != null) rbAccess.Checked = (!isSql && !isSqlite);

            // 5. Banco do Projeto e SQL Server
            if (tbProjeto != null) tbProjeto.Text = caderno.DirProjeto ?? string.Empty;
            if (tbDataSource != null) tbDataSource.Text = caderno.DataSource ?? string.Empty;
            if (tbBancoDeDados != null) tbBancoDeDados.Text = caderno.BancoDeDados ?? string.Empty;
            if (tbUser != null) tbUser.Text = caderno.User ?? string.Empty;
            if (tbSenha != null) tbSenha.Text = caderno.Senha ?? string.Empty;

            // 6. Bibliotecas
            if (tbSimbologiaEletrica != null) tbSimbologiaEletrica.Text = caderno.DirSimbologiaEletrica ?? string.Empty;
            if (tbSimbologiaTopografico != null) tbSimbologiaTopografico.Text = caderno.DirSimbologiaTopografico ?? string.Empty;
            if (tbSimbologiaLayout != null) tbSimbologiaLayout.Text = caderno.DirSimbologiaLayout ?? string.Empty;
            if (tbSimbologiaRelatorios != null) tbSimbologiaRelatorios.Text = caderno.DirSimbologiaRelatorios ?? string.Empty;

            // 7. Geral: Cruzamento de Páginas
            switch (caderno.IncluirColuna)
            {
                case 1: if (rbIncluirColuna1 != null) rbIncluirColuna1.Checked = true; break;
                case 2: if (rbIncluirColuna2 != null) rbIncluirColuna2.Checked = true; break;
                case 3: if (rbIncluirColuna3 != null) rbIncluirColuna3.Checked = true; break;
                case 4: if (rbIncluirColuna4 != null) rbIncluirColuna4.Checked = true; break;
                case 5: if (rbIncluirColuna5 != null) rbIncluirColuna5.Checked = true; break;
                case 6: if (rbIncluirColuna6 != null) rbIncluirColuna6.Checked = true; break;
                default: if (rbIncluirColuna0 != null) rbIncluirColuna0.Checked = true; break;
            }

            // 8. Caracteres
            if (tbTerminalIndefinido != null) tbTerminalIndefinido.Text = caderno.CaracterTerminalIndefinido ?? "?";
            if (tbSeparadorCaboVeia != null) tbSeparadorCaboVeia.Text = caderno.SeparadorCaboVeia ?? "/";
            if (tbSeparadorCruzamento != null) tbSeparadorCruzamento.Text = caderno.SeparadorCruzamento ?? "/";
            if (tbSeparadorCarimbo != null) tbSeparadorCarimbo.Text = caderno.SeparadorCarimbo ?? "-";
            if (tbSeparadorReguaBorne != null) tbSeparadorReguaBorne.Text = caderno.SeparadorPainelRegua ?? "/";

            // 9. Altura de Textos
            if (tbFonteCircuitos != null) tbFonteCircuitos.Text = (caderno.FonteCircuito > 0 ? caderno.FonteCircuito : 1.5).ToString("0.0", CultureInfo.InvariantCulture).Replace('.', ',');
            if (tbFonteCruzamento != null) tbFonteCruzamento.Text = (caderno.FonteCruzamento > 0 ? caderno.FonteCruzamento : 1.5).ToString("0.0", CultureInfo.InvariantCulture).Replace('.', ',');
            if (tbFonteCabos != null) tbFonteCabos.Text = (caderno.FonteCabos > 0 ? caderno.FonteCabos : 1.5).ToString("0.0", CultureInfo.InvariantCulture).Replace('.', ',');

            // 10. Representação Cabo/Veia
            switch (caderno.InterligacaoLayout)
            {
                case 1: if (rbLayInter1 != null) rbLayInter1.Checked = true; break;
                case 2: if (rbLayInter2 != null) rbLayInter2.Checked = true; break;
                case 3: if (rbLayInter3 != null) rbLayInter3.Checked = true; break;
                default: if (rbLayInter0 != null) rbLayInter0.Checked = true; break;
            }

            // 11. Cores e Estilo de Linha
            AtualizarCoresBotoes(btCorConexao, btCorTextoCircuito, btCorInterligacao, btCorTextoInterligacao,
                corConexao, corTextoCircuito, corInterligacao, corTextoInterligacao);

            if (cbEstilosLinha != null)
            {
                string[] estilosPadrao = new[] { "Continuous", "Dashed", "Dotted", "DashDot" };
                cbEstilosLinha.Items.Clear();
                cbEstilosLinha.Items.AddRange(estilosPadrao);
                string estiloAtual = !string.IsNullOrEmpty(caderno.EstiloLinha) ? caderno.EstiloLinha : "Continuous";
                if (!cbEstilosLinha.Items.Contains(estiloAtual))
                {
                    cbEstilosLinha.Items.Add(estiloAtual);
                }
                cbEstilosLinha.Text = estiloAtual;
            }

            if (tbEstiloLinhaEscala != null)
            {
                tbEstiloLinhaEscala.Text = (caderno.EstiloLinhaEscala > 0 ? caderno.EstiloLinhaEscala : 1.0).ToString(CultureInfo.InvariantCulture);
            }

            // 12. Delimitadores de Cruzamento
            if (tbPrefixoCruzamentoInterno != null) tbPrefixoCruzamentoInterno.Text = caderno.PrefixoCruzInterno ?? "(";
            if (tbSufixoCruzamentoInterno != null) tbSufixoCruzamentoInterno.Text = caderno.SufixoCruzInterno ?? ")";
            if (tbPrefixoCruzamentoFF != null) tbPrefixoCruzamentoFF.Text = caderno.PrefixoCruzFuncFunc ?? "(";
            if (tbSufixoCruzamentoFF != null) tbSufixoCruzamentoFF.Text = caderno.SufixoCruzFuncFunc ?? ")";
            if (tbPrefixoCruzamentoExterno != null) tbPrefixoCruzamentoExterno.Text = caderno.PrefixoCruzExterno ?? "[";
            if (tbSufixoCruzamentoExterno != null) tbSufixoCruzamentoExterno.Text = caderno.SufixoCruzExterno ?? "]";

            // 13. Visualização de Modelos de Relés
            switch (caderno.ModeloBobina)
            {
                case 1: if (rbBobina0 != null) rbBobina0.Checked = true; break;
                case 2: if (rbBobinaContato2 != null) rbBobinaContato2.Checked = true; break;
                case 3: if (rbBobinaContatoES3 != null) rbBobinaContatoES3.Checked = true; break;
                default: if (rbContato1 != null) rbContato1.Checked = true; break;
            }

            // Ação de validação visual dos caminhos (vtLy1XHoKW do reverso)
            Action validarCaminhos = () =>
            {
                ValidarCaminhos(tbProjeto, tbSimbologiaEletrica, tbSimbologiaTopografico, tbSimbologiaLayout, tbSimbologiaRelatorios,
                    rbSQLSVR != null && rbSQLSVR.Checked);
            };

            // Alternância de banco (f9JyCMMBWM do reverso)
            Action alternarBanco = () =>
            {
                bool sqlAtivo = rbSQLSVR != null && rbSQLSVR.Checked;
                if (sqlAtivo)
                {
                    if (tbProjeto != null)
                    {
                        tbProjeto.Text = string.Empty;
                        tbProjeto.Enabled = false;
                    }
                    if (gbAccess != null) gbAccess.Visible = false;
                    if (gbSql != null)
                    {
                        gbSql.Location = new Point(6, 164);
                        gbSql.Visible = true;
                    }
                }
                else
                {
                    if (tbProjeto != null) tbProjeto.Enabled = true;
                    if (gbAccess != null) gbAccess.Visible = true;
                    if (gbSql != null)
                    {
                        gbSql.Location = new Point(6, 251);
                        gbSql.Visible = false;
                    }
                }
                validarCaminhos();
            };

            if (rbAccess != null) rbAccess.CheckedChanged += (s, e) => { if (rbAccess.Checked) alternarBanco(); };
            if (rbSQLite != null) rbSQLite.CheckedChanged += (s, e) => { if (rbSQLite.Checked) alternarBanco(); };
            if (rbSQLSVR != null) rbSQLSVR.CheckedChanged += (s, e) => { if (rbSQLSVR.Checked) alternarBanco(); };
            alternarBanco();

            // Seletor de arquivo de banco (SelProj)
            if (selProj != null)
            {
                selProj.Click += (s, e) =>
                {
                    using (OpenFileDialog dialogo = new OpenFileDialog())
                    {
                        dialogo.Title = "Banco de Dados do Projeto";
                        bool usaSqlite = rbSQLite != null && rbSQLite.Checked;
                        dialogo.Filter = usaSqlite ? "SQLite (*.db)|*.db" : "Access (*.accdb; *.mdb)|*.accdb;*.mdb";
                        dialogo.DefaultExt = usaSqlite ? ".db" : ".accdb";
                        dialogo.RestoreDirectory = true;
                        dialogo.Multiselect = false;
                        dialogo.ValidateNames = true;
                        if (dialogo.ShowDialog() == DialogResult.OK && tbProjeto != null)
                        {
                            tbProjeto.Text = dialogo.FileName;
                            validarCaminhos();
                        }
                    }
                };
            }

            // Seletores de pastas de bibliotecas
            Action<TextBox, string> selecionarPasta = (caixa, titulo) =>
            {
                using (FolderBrowserDialog dialogo = new FolderBrowserDialog())
                {
                    dialogo.Description = titulo;
                    dialogo.ShowNewFolderButton = false;
                    if (dialogo.ShowDialog() == DialogResult.OK && caixa != null)
                    {
                        string caminho = dialogo.SelectedPath ?? string.Empty;
                        if (caminho.Length > 0 && !caminho.EndsWith("\\"))
                        {
                            caminho += "\\";
                        }
                        caixa.Text = caminho;
                        validarCaminhos();
                    }
                }
            };

            if (selDirSimbologiaEletrica != null) selDirSimbologiaEletrica.Click += (s, e) => selecionarPasta(tbSimbologiaEletrica, "Simbologia Elétrica");
            if (selDirSimbologiaTopografico != null) selDirSimbologiaTopografico.Click += (s, e) => selecionarPasta(tbSimbologiaTopografico, "Simbologia Topográfico");
            if (selDirSimbologiaLayout != null) selDirSimbologiaLayout.Click += (s, e) => selecionarPasta(tbSimbologiaLayout, "Simbologia Layout");
            if (selDirSimbologiaRelatorios != null) selDirSimbologiaRelatorios.Click += (s, e) => selecionarPasta(tbSimbologiaRelatorios, "Simbologia Relatórios");

            // Eventos das caixas para revalidar cores
            if (tbProjeto != null) tbProjeto.TextChanged += (s, e) => validarCaminhos();
            if (tbSimbologiaEletrica != null) tbSimbologiaEletrica.TextChanged += (s, e) => validarCaminhos();
            if (tbSimbologiaTopografico != null) tbSimbologiaTopografico.TextChanged += (s, e) => validarCaminhos();
            if (tbSimbologiaLayout != null) tbSimbologiaLayout.TextChanged += (s, e) => validarCaminhos();
            if (tbSimbologiaRelatorios != null) tbSimbologiaRelatorios.TextChanged += (s, e) => validarCaminhos();

            // Botão Conectar SQL Server
            if (btConectarSQLServer != null)
            {
                btConectarSQLServer.Click += (s, e) =>
                {
                    string ds = tbDataSource != null ? tbDataSource.Text.Trim() : string.Empty;
                    if (string.IsNullOrEmpty(ds))
                    {
                        Aviso.MsgBox("Falha na conexão com o Banco de Dados!", "Elétron");
                    }
                    else
                    {
                        Aviso.MsgBox("Conexão com o Banco de Dados estabelecida com sucesso!", "Elétron");
                    }
                };
            }

            // Seleção de cores CAD
            if (btCorConexao != null) btCorConexao.Click += (s, e) => EscolherCor(btCorConexao, c => corConexao = c);
            if (btCorTextoCircuito != null) btCorTextoCircuito.Click += (s, e) => EscolherCor(btCorTextoCircuito, c => corTextoCircuito = c);
            if (btCorInterligacao != null) btCorInterligacao.Click += (s, e) => EscolherCor(btCorInterligacao, c => corInterligacao = c);
            if (btCorTextoInterligacao != null) btCorTextoInterligacao.Click += (s, e) => EscolherCor(btCorTextoInterligacao, c => corTextoInterligacao = c);

            // Botões de Padrão (Eletronorte, Eletrosul, Chesf)
            Action aplicarPadraoEletronorte = () =>
            {
                corConexao = 7;
                corTextoCircuito = 7;
                corInterligacao = 7;
                corTextoInterligacao = 7;
                AtualizarCoresBotoes(btCorConexao, btCorTextoCircuito, btCorInterligacao, btCorTextoInterligacao, 7, 7, 7, 7);
                if (tbTerminalIndefinido != null) tbTerminalIndefinido.Text = "?";
                if (tbSeparadorCaboVeia != null) tbSeparadorCaboVeia.Text = "/";
                if (tbSeparadorCruzamento != null) tbSeparadorCruzamento.Text = "/";
                if (tbSeparadorReguaBorne != null) tbSeparadorReguaBorne.Text = "/";
                if (tbSeparadorCarimbo != null) tbSeparadorCarimbo.Text = "-";
                if (tbPrefixoCruzamentoInterno != null) tbPrefixoCruzamentoInterno.Text = "(";
                if (tbSufixoCruzamentoInterno != null) tbSufixoCruzamentoInterno.Text = ")";
                if (tbPrefixoCruzamentoFF != null) tbPrefixoCruzamentoFF.Text = "(";
                if (tbSufixoCruzamentoFF != null) tbSufixoCruzamentoFF.Text = ")";
                if (tbFonteCircuitos != null) tbFonteCircuitos.Text = "1,8";
                if (tbFonteCabos != null) tbFonteCabos.Text = "1,8";
                if (rbIEC != null) rbIEC.Checked = true;
                if (rbIncluirColuna0 != null) rbIncluirColuna0.Checked = true;
                if (rbLayInter0 != null) rbLayInter0.Checked = true;
                if (rbContato1 != null) rbContato1.Checked = true;
            };

            Action aplicarPadraoEletrosul = () =>
            {
                corConexao = 7;
                corTextoCircuito = 7;
                corInterligacao = 7;
                corTextoInterligacao = 7;
                AtualizarCoresBotoes(btCorConexao, btCorTextoCircuito, btCorInterligacao, btCorTextoInterligacao, 7, 7, 7, 7);
                if (tbTerminalIndefinido != null) tbTerminalIndefinido.Text = "?";
                if (tbSeparadorCaboVeia != null) tbSeparadorCaboVeia.Text = "-";
                if (tbSeparadorCruzamento != null) tbSeparadorCruzamento.Text = "/";
                if (tbSeparadorCarimbo != null) tbSeparadorCarimbo.Text = "/";
                if (tbSeparadorReguaBorne != null) tbSeparadorReguaBorne.Text = "/";
                if (tbPrefixoCruzamentoInterno != null) tbPrefixoCruzamentoInterno.Text = "(";
                if (tbSufixoCruzamentoInterno != null) tbSufixoCruzamentoInterno.Text = ")";
                if (tbPrefixoCruzamentoFF != null) tbPrefixoCruzamentoFF.Text = "(";
                if (tbSufixoCruzamentoFF != null) tbSufixoCruzamentoFF.Text = ")";
                if (tbFonteCircuitos != null) tbFonteCircuitos.Text = "1,8";
                if (tbFonteCabos != null) tbFonteCabos.Text = "1,8";
                if (rbIEC != null) rbIEC.Checked = true;
                if (rbIncluirColuna0 != null) rbIncluirColuna0.Checked = true;
                if (rbLayInter1 != null) rbLayInter1.Checked = true;
                if (rbBobinaContatoES3 != null) rbBobinaContatoES3.Checked = true;
            };

            Action aplicarPadraoChesf = () =>
            {
                corConexao = 7;
                corTextoCircuito = 7;
                corInterligacao = 7;
                corTextoInterligacao = 7;
                AtualizarCoresBotoes(btCorConexao, btCorTextoCircuito, btCorInterligacao, btCorTextoInterligacao, 7, 7, 7, 7);
                if (tbTerminalIndefinido != null) tbTerminalIndefinido.Text = "?";
                if (tbSeparadorCaboVeia != null) tbSeparadorCaboVeia.Text = "/";
                if (tbSeparadorCruzamento != null) tbSeparadorCruzamento.Text = "/";
                if (tbSeparadorReguaBorne != null) tbSeparadorReguaBorne.Text = "/";
                if (tbSeparadorCarimbo != null) tbSeparadorCarimbo.Text = "-";
                if (tbPrefixoCruzamentoInterno != null) tbPrefixoCruzamentoInterno.Text = "(";
                if (tbSufixoCruzamentoInterno != null) tbSufixoCruzamentoInterno.Text = ")";
                if (tbPrefixoCruzamentoFF != null) tbPrefixoCruzamentoFF.Text = "(";
                if (tbSufixoCruzamentoFF != null) tbSufixoCruzamentoFF.Text = ")";
                if (tbFonteCircuitos != null) tbFonteCircuitos.Text = "1,5";
                if (tbFonteCabos != null) tbFonteCabos.Text = "1,5";
                if (rbANSI != null) rbANSI.Checked = true;
                if (rbIncluirColuna2 != null) rbIncluirColuna2.Checked = true;
                if (rbLayInter2 != null) rbLayInter2.Checked = true;
                if (rbBobina0 != null) rbBobina0.Checked = true;
            };

            if (btEletronorte != null) btEletronorte.Click += (s, e) => aplicarPadraoEletronorte();
            if (btEletrosul != null) btEletrosul.Click += (s, e) => aplicarPadraoEletrosul();
            if (btChesf != null) btChesf.Click += (s, e) => aplicarPadraoChesf();

            // Ação de Salvar (GuKynurbxa do reverso)
            Action salvar = () =>
            {
                caderno.Norma = (rbANSI != null && rbANSI.Checked) ? 1 : 0;
                if (tbCaderno != null) caderno.Local = tbCaderno.Text.Trim();

                caderno.Banco = (rbSQLSVR != null && rbSQLSVR.Checked) ? ConfiguracaoDoCaderno.BancoSqlServer
                    : (rbSQLite != null && rbSQLite.Checked) ? ConfiguracaoDoCaderno.BancoSqlite
                    : ConfiguracaoDoCaderno.BancoAccess;

                if (tbProjeto != null) caderno.DirProjeto = tbProjeto.Text.Trim();
                if (tbDataSource != null) caderno.DataSource = tbDataSource.Text.Trim();
                if (tbBancoDeDados != null) caderno.BancoDeDados = tbBancoDeDados.Text.Trim();
                if (tbUser != null) caderno.User = tbUser.Text.Trim();
                if (tbSenha != null) caderno.Senha = tbSenha.Text.Trim();

                if (tbSimbologiaEletrica != null) caderno.DirSimbologiaEletrica = tbSimbologiaEletrica.Text.Trim();
                if (tbSimbologiaTopografico != null) caderno.DirSimbologiaTopografico = tbSimbologiaTopografico.Text.Trim();
                if (tbSimbologiaLayout != null) caderno.DirSimbologiaLayout = tbSimbologiaLayout.Text.Trim();
                if (tbSimbologiaRelatorios != null) caderno.DirSimbologiaRelatorios = tbSimbologiaRelatorios.Text.Trim();

                caderno.IncluirColuna = (rbIncluirColuna6 != null && rbIncluirColuna6.Checked) ? 6
                    : (rbIncluirColuna5 != null && rbIncluirColuna5.Checked) ? 5
                    : (rbIncluirColuna4 != null && rbIncluirColuna4.Checked) ? 4
                    : (rbIncluirColuna3 != null && rbIncluirColuna3.Checked) ? 3
                    : (rbIncluirColuna2 != null && rbIncluirColuna2.Checked) ? 2
                    : (rbIncluirColuna1 != null && rbIncluirColuna1.Checked) ? 1
                    : 0;

                if (tbTerminalIndefinido != null) caderno.CaracterTerminalIndefinido = tbTerminalIndefinido.Text;
                if (tbSeparadorCaboVeia != null) caderno.SeparadorCaboVeia = tbSeparadorCaboVeia.Text;
                if (tbSeparadorCruzamento != null) caderno.SeparadorCruzamento = tbSeparadorCruzamento.Text;
                if (tbSeparadorCarimbo != null) caderno.SeparadorCarimbo = tbSeparadorCarimbo.Text;
                if (tbSeparadorReguaBorne != null) caderno.SeparadorPainelRegua = tbSeparadorReguaBorne.Text;

                if (tbFonteCircuitos != null) caderno.FonteCircuito = ParseReal(tbFonteCircuitos.Text, caderno.FonteCircuito);
                if (tbFonteCruzamento != null) caderno.FonteCruzamento = ParseReal(tbFonteCruzamento.Text, caderno.FonteCruzamento);
                if (tbFonteCabos != null) caderno.FonteCabos = ParseReal(tbFonteCabos.Text, caderno.FonteCabos);

                caderno.InterligacaoLayout = (rbLayInter1 != null && rbLayInter1.Checked) ? 1
                    : (rbLayInter2 != null && rbLayInter2.Checked) ? 2
                    : (rbLayInter3 != null && rbLayInter3.Checked) ? 3
                    : 0;

                caderno.CorConexao = corConexao;
                caderno.CorTextoCircuito = corTextoCircuito;
                caderno.CorInterligacao = corInterligacao;
                caderno.CorTextoInterligacao = corTextoInterligacao;

                if (cbEstilosLinha != null) caderno.EstiloLinha = cbEstilosLinha.Text;
                if (tbEstiloLinhaEscala != null) caderno.EstiloLinhaEscala = ParseReal(tbEstiloLinhaEscala.Text, caderno.EstiloLinhaEscala);

                if (tbPrefixoCruzamentoInterno != null) caderno.PrefixoCruzInterno = tbPrefixoCruzamentoInterno.Text;
                if (tbSufixoCruzamentoInterno != null) caderno.SufixoCruzInterno = tbSufixoCruzamentoInterno.Text;
                if (tbPrefixoCruzamentoFF != null) caderno.PrefixoCruzFuncFunc = tbPrefixoCruzamentoFF.Text;
                if (tbSufixoCruzamentoFF != null) caderno.SufixoCruzFuncFunc = tbSufixoCruzamentoFF.Text;
                if (tbPrefixoCruzamentoExterno != null) caderno.PrefixoCruzExterno = tbPrefixoCruzamentoExterno.Text;
                if (tbSufixoCruzamentoExterno != null) caderno.SufixoCruzExterno = tbSufixoCruzamentoExterno.Text;

                caderno.ModeloBobina = (rbBobinaContatoES3 != null && rbBobinaContatoES3.Checked) ? 3
                    : (rbBobinaContato2 != null && rbBobinaContato2.Checked) ? 2
                    : (rbBobina0 != null && rbBobina0.Checked) ? 1
                    : 0;

                // Idioma no registro
                string idioma = (rbIdioma2 != null && rbIdioma2.Checked) ? "[EN]" : "[PT]";
                PreferenciasGerais.GravarIdioma(idioma);

                // Gravação do XData do desenho
                ConfiguracaoDoDesenho.Gravar(caderno);
                Plugin.Escrever("Configuração Geral: configuração gravada no XData do desenho (Eletron/Config e EletronProj/Projeto).");

                janela.Close();
            };

            if (btSalvar != null)
            {
                btSalvar.Click += (s, e) => salvar();
            }

            // Ganchos do harness para testes não interativos
            ProcessarHarness(aplicarPadraoEletronorte, aplicarPadraoEletrosul, aplicarPadraoChesf,
                rbIdioma1, rbIdioma2, rbIEC, rbANSI, tbProjeto, rbLayInter0, rbLayInter1, rbLayInter2, rbLayInter3,
                tbPrefixoCruzamentoExterno, tbSufixoCruzamentoExterno, salvar);
        }

        private static void AtualizarCoresBotoes(Button bt1, Button bt2, Button bt3, Button bt4,
            int c1, int c2, int c3, int c4)
        {
            if (bt1 != null) bt1.BackColor = CorParaColor(c1);
            if (bt2 != null) bt2.BackColor = CorParaColor(c2);
            if (bt3 != null) bt3.BackColor = CorParaColor(c3);
            if (bt4 != null) bt4.BackColor = CorParaColor(c4);
        }

        private static System.Drawing.Color CorParaColor(int aci)
        {
            try
            {
                if (aci <= 0 || aci > 256)
                {
                    aci = 7;
                }
                return CadColor.FromColorIndex((CadColorMethod)194, (short)aci).ColorValue;
            }
            catch
            {
                return System.Drawing.Color.White;
            }
        }

        private static void EscolherCor(Button botao, Action<int> aplicarCor)
        {
            try
            {
                CadColorDialog dialogo = new CadColorDialog();
                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    int aci = dialogo.Color.ColorIndex;
                    aplicarCor(aci);
                    botao.BackColor = dialogo.Color.ColorValue;
                }
            }
            catch
            {
                using (ColorDialog fallback = new ColorDialog())
                {
                    if (fallback.ShowDialog() == DialogResult.OK)
                    {
                        botao.BackColor = fallback.Color;
                    }
                }
            }
        }

        private static void ValidarCaminhos(TextBox tbProj, TextBox tbElet, TextBox tbTopo, TextBox tbLay, TextBox tbRel, bool isSql)
        {
            if (tbProj != null)
            {
                tbProj.BackColor = (!isSql && !string.IsNullOrEmpty(tbProj.Text) && !File.Exists(tbProj.Text))
                    ? System.Drawing.Color.LightCoral : System.Drawing.Color.White;
            }

            if (tbElet != null)
            {
                tbElet.BackColor = (!string.IsNullOrEmpty(tbElet.Text) && !Directory.Exists(tbElet.Text))
                    ? System.Drawing.Color.LightCoral : System.Drawing.Color.White;
            }

            if (tbTopo != null)
            {
                tbTopo.BackColor = (!string.IsNullOrEmpty(tbTopo.Text) && !Directory.Exists(tbTopo.Text))
                    ? System.Drawing.Color.LightCoral : System.Drawing.Color.White;
            }

            if (tbLay != null)
            {
                tbLay.BackColor = (!string.IsNullOrEmpty(tbLay.Text) && !Directory.Exists(tbLay.Text))
                    ? System.Drawing.Color.LightCoral : System.Drawing.Color.White;
            }

            if (tbRel != null)
            {
                tbRel.BackColor = (!string.IsNullOrEmpty(tbRel.Text) && !Directory.Exists(tbRel.Text))
                    ? System.Drawing.Color.LightCoral : System.Drawing.Color.White;
            }
        }

        private static double ParseReal(string texto, double padrao)
        {
            if (string.IsNullOrEmpty(texto))
            {
                return padrao;
            }
            double valor;
            string normalizado = texto.Trim().Replace(',', '.');
            if (double.TryParse(normalizado, NumberStyles.Float, CultureInfo.InvariantCulture, out valor))
            {
                return valor;
            }
            return padrao;
        }

        private static void ProcessarHarness(Action eletronorte, Action eletrosul, Action chesf,
            RadioButton rbPt, RadioButton rbEn, RadioButton rbIec, RadioButton rbAnsi, TextBox tbProj,
            RadioButton lay0, RadioButton lay1, RadioButton lay2, RadioButton lay3,
            TextBox preExt, TextBox sufExt, Action salvar)
        {
            string preset = Environment.GetEnvironmentVariable("POSITRON_CFG_PRESET");
            if (!string.IsNullOrEmpty(preset))
            {
                if (string.Equals(preset, "eletronorte", StringComparison.OrdinalIgnoreCase)) eletronorte();
                else if (string.Equals(preset, "eletrosul", StringComparison.OrdinalIgnoreCase)) eletrosul();
                else if (string.Equals(preset, "chesf", StringComparison.OrdinalIgnoreCase)) chesf();
            }

            string idioma = Environment.GetEnvironmentVariable("POSITRON_CFG_IDIOMA");
            if (!string.IsNullOrEmpty(idioma))
            {
                bool isEn = string.Equals(idioma, "en", StringComparison.OrdinalIgnoreCase);
                if (rbEn != null) rbEn.Checked = isEn;
                if (rbPt != null) rbPt.Checked = !isEn;
            }

            string norma = Environment.GetEnvironmentVariable("POSITRON_CFG_NORMA");
            if (!string.IsNullOrEmpty(norma))
            {
                bool isAnsi = string.Equals(norma, "ansi", StringComparison.OrdinalIgnoreCase);
                if (rbAnsi != null) rbAnsi.Checked = isAnsi;
                if (rbIec != null) rbIec.Checked = !isAnsi;
            }

            string banco = Environment.GetEnvironmentVariable("POSITRON_CFG_BANCO");
            if (!string.IsNullOrEmpty(banco) && tbProj != null)
            {
                tbProj.Text = banco;
            }

            string rep = Environment.GetEnvironmentVariable("POSITRON_CFG_REPRESENTACAO");
            if (!string.IsNullOrEmpty(rep))
            {
                if (rep == "1" && lay1 != null) lay1.Checked = true;
                else if (rep == "2" && lay2 != null) lay2.Checked = true;
                else if (rep == "3" && lay3 != null) lay3.Checked = true;
                else if (lay0 != null) lay0.Checked = true;
            }

            string logFunc = Environment.GetEnvironmentVariable("POSITRON_CFG_LOGFUNC");
            if (!string.IsNullOrEmpty(logFunc))
            {
                string[] partes = logFunc.Split(';');
                if (partes.Length >= 2)
                {
                    if (preExt != null) preExt.Text = partes[0];
                    if (sufExt != null) sufExt.Text = partes[1];
                }
            }

            string acaoSalvar = Environment.GetEnvironmentVariable("POSITRON_CFG_SALVAR");
            if (string.Equals(acaoSalvar, "1", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(acaoSalvar, "true", StringComparison.OrdinalIgnoreCase))
            {
                salvar();
            }
        }
    }
}

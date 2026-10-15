using System;
using System.IO;
using System.Windows.Forms;
using Positron.Data;
using Positron.Data.Configuracao;
using Positron.Plugin.Configuracao;
#if AUTOCAD
using Application = Autodesk.AutoCAD.ApplicationServices.Application;
#else
using Application = ZwSoft.ZwCAD.ApplicationServices.Application;
#endif

namespace Positron.Plugin.Interface.Telas
{
    /// <summary>
    /// A ligação do <c>frmConfiguracaoBDProjeto</c> ("Banco de Dados do Projeto",
    /// <c>frmConfiguracaoBDProjeto.cs:127-237</c>): **liga o desenho a um banco**. O <c>tbProjeto</c>
    /// mostra o <c>DirProjeto</c> do desenho; o <c>SelProj</c> abre o seletor de arquivo (Access ou
    /// SQLite, conforme o tipo de banco do desenho), grava o caminho no XData
    /// <c>EletronProj</c>/<c>Projeto</c> do desenho (o <c>GravarXDataConfiguracao2</c>) e confere o
    /// cadastro do DWG (o <c>yKiycL7IZh</c>): sem cadastro, mMensagem 323; com cadastro, o
    /// <c>UPDATE DWG SET Caminho, Editor, Data</c>. A tela abre sozinha quando o desenho do Elétron
    /// não tem banco válido (<see cref="InicioDoDesenho"/>, o <c>IniciarDWG</c>).
    /// </summary>
    internal sealed class LigacaoDoFrmConfiguracaoBDProjeto : ILigacaoDeTela
    {
        public string NomeDaTela
        {
            get { return "frmConfiguracaoBDProjeto"; }
        }

        public void Preencher(Form janela)
        {
            TextBox projeto = ControlesDaTela.Achar<TextBox>(janela, "tbProjeto");
            Button selecionar = ControlesDaTela.Achar<Button>(janela, "SelProj");
            ConfiguracaoDoCaderno caderno = ConfiguracaoDoDesenho.LerOuPadrao();
            if (projeto == null || selecionar == null || caderno == null)
            {
                return;
            }

            // Com SQL Server o banco não é um arquivo: mMensagem 1970, e a tela não abre.
            if (string.Equals(caderno.Banco, ConfiguracaoDoCaderno.BancoSqlServer, StringComparison.OrdinalIgnoreCase))
            {
                Aviso.MsgBox("Abra a Configuração Geral e altere os dados do banco SQL Server.", "Eletron");
                janela.Dispose();
                return;
            }

            projeto.Text = caderno.DirProjeto ?? string.Empty;
            selecionar.Click += (origem, evento) => Selecionar(janela, projeto);

            // O gancho do harness: o seletor de arquivo não é scriptável, então
            // `POSITRON_BDPROJETO=<arquivo>` faz o mesmo que escolher o arquivo e fecha a tela.
            string escolhido = Environment.GetEnvironmentVariable("POSITRON_BDPROJETO");
            if (!string.IsNullOrEmpty(escolhido))
            {
                projeto.Text = escolhido;
                Ligar(escolhido.Trim());
                janela.Dispose();
            }
        }

        private static void Selecionar(Form janela, TextBox projeto)
        {
            try
            {
                ConfiguracaoDoCaderno caderno = ConfiguracaoDoDesenho.LerOuPadrao();
                if (caderno == null)
                {
                    return;
                }

                using (OpenFileDialog seletor = new OpenFileDialog())
                {
                    seletor.Title = "Selecione o banco do projeto";
                    if (string.Equals(caderno.Banco, ConfiguracaoDoCaderno.BancoSqlite, StringComparison.OrdinalIgnoreCase))
                    {
                        seletor.Filter = "SQLite (*.db)|*.db";
                        seletor.DefaultExt = ".db";
                    }
                    else
                    {
                        seletor.Filter = "Access (*.accdb; *.mdb)|*.accdb;*.mdb";
                        seletor.DefaultExt = ".accdb";
                    }

                    seletor.FileName = string.Empty;
                    seletor.RestoreDirectory = true;
                    seletor.Multiselect = false;
                    seletor.ValidateNames = true;
                    if (seletor.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    projeto.Text = seletor.FileName;
                }

                Ligar(projeto.Text.Trim());
                janela.Close();
            }
            catch (Exception erro)
            {
                // O original engole aqui (o `catch` vazio do `YX7yPFeedB`); a linha de comando registra.
                Plugin.Escrever("Banco de Dados do Projeto: falhou — " + erro.Message + ".");
            }
        }

        /// <summary>
        /// O que o <c>SelProj</c> faz depois de escolher o arquivo: grava o <c>DirProjeto</c> no desenho e
        /// confere o cadastro do DWG.
        /// </summary>
        private static void Ligar(string arquivo)
        {
            ConfiguracaoDoCaderno caderno = ConfiguracaoDoDesenho.LerOuPadrao();
            caderno.DirProjeto = arquivo ?? string.Empty;
            ConfiguracaoDoDesenho.GravarProjeto(caderno);
            Plugin.Escrever("Banco de Dados do Projeto: o desenho passa a usar \"" + caderno.DirProjeto + "\".");

            // O `yKiycL7IZh`: o índice do DWG pelo nome do arquivo (o `carregaDadosDWG`).
            int indice = ConfiguracaoEfetiva.IndiceDoDwg(caderno.DirProjeto);
            if (indice == 0)
            {
                Aviso.MsgBox("Este arquivo ainda não foi cadastrado!", "Eletron");
                return;
            }

            string caminho = Path.GetDirectoryName(Application.DocumentManager.MdiActiveDocument.Name) ?? string.Empty;
            int alterados = new ProjectStore(caderno.DirProjeto).AtualizarDwg(
                indice, caminho.Length > 0 ? caminho + "\\" : caminho, Environment.UserName, DateTime.Now);
            Plugin.Escrever("Banco de Dados do Projeto: DWG " + indice + " cadastrado — " + alterados + " linha(s) atualizada(s) (Caminho, Editor, Data).");
        }
    }
}

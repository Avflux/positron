using System;
using System.Collections.Generic;
using System.IO;
using Positron.Data.Configuracao;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
#endif

namespace Positron.Plugin
{
    /// <summary>
    /// O que o original faz **a cada desenho ativado**: o <c>EventosDOC.AtivaDocumento</c>
    /// (<c>EventosDOC.cs:119-150</c>, ligado ao <c>DocumentActivated</c> em <c>myEletron.cs:233</c>) fecha as
    /// janelas abertas e roda o <c>Iniciar.IniciarDWG</c> (<c>Iniciar.cs:61-195</c>), que também roda no
    /// <c>Initialize</c> para o desenho já aberto. Do <c>IniciarDWG</c> entram aqui:
    ///
    /// - a paleta de páginas aberta e recarregada com as páginas **deste** desenho (o
    ///   <c>Comandos.GerenciadorPagina</c>, chamado nos dois ramos);
    /// - na **primeira** ativação de cada desenho (o <c>lDwgRegen</c>), com o banco do projeto inválido
    ///   (o <c>clsAuxiliar.BancoValido(bMsg: false)</c>) num desenho do Elétron (tipo <c>E</c>), a
    ///   <c>frmConfiguracaoBDProjeto</c>, para ligar o desenho a um banco.
    ///
    /// A configuração (o <c>LerXDataConfiguracao</c>/<c>2</c>) não fica guardada: cada comando relê o
    /// desenho ativo (<see cref="ConfiguracaoEfetiva"/>). O que o <c>IniciarDWG</c> faz e ainda não entrou
    /// está na rodada 180 (*Falta*).
    /// </summary>
    internal static class InicioDoDesenho
    {
        /// <summary>As janelas que a troca de documento **não** fecha (a lista do <c>AtivaDocumento</c>).</summary>
        private static readonly HashSet<string> FicamAbertas = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "frmExportarImportar", "frmClonar", "frmRelatorio_Aranha", "frmRelatorio_DInterlig",
            "frmRelatorio_DIEnergisaMS", "frmRelatorio_DIEnergisaMT", "frmRelatorio_DICemig", "frmMisturador",
            "frmClonarEstruturaRegua", "frmCopiarObjetos",
        };

        /// <summary>mMensagem 329.</summary>
        private const string BancoNaoEncontrado = "Banco do Projeto não encontrado!";

        /// <summary>Os desenhos já iniciados nesta sessão (o <c>DeclaracoesGeral.lDwgRegen</c>).</summary>
        private static readonly HashSet<string> Iniciados = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        internal static void Ligar()
        {
            Application.DocumentManager.DocumentActivated += AoAtivar;
        }

        internal static void Desligar()
        {
            Application.DocumentManager.DocumentActivated -= AoAtivar;
        }

        private static void AoAtivar(object origem, DocumentCollectionEventArgs evento)
        {
            try
            {
                FecharJanelas();
                Iniciar();
            }
            catch (Exception erro)
            {
                Interface.Aviso.MsgBox(erro.Message, string.Empty);
            }
        }

        /// <summary>O <c>IniciarDWG</c> (a parte que entrou): a paleta e o banco do projeto.</summary>
        internal static void Iniciar()
        {
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return;
            }

            Interface.Folhas.PaletaDeFolhas.Mostrar();

            if (!Iniciados.Add(documento.Name))
            {
                return;
            }

            // Só os motivos do original (328/329): o banco Access, que o original lê, não abre a tela.
            string motivo = Validar();
            bool invalidoNoOriginal = motivo == Positron.Data.Interface.MensagensDoReverso.BancoNaoConfigurado
                || motivo == BancoNaoEncontrado;
            if (invalidoNoOriginal && TipoDoDesenho(documento) == "E")
            {
                Plugin.Escrever(Interface.Telas.RenderizadorDeTelas.Abrir("frmConfiguracaoBDProjeto", "Banco de Dados do Projeto"));
            }
        }

        /// <summary>
        /// O <c>clsAuxiliar.BancoValido(bMsg: false)</c> (<c>clsAuxiliar.cs:10-60</c>): Access/SQLite pedem o
        /// <c>DirProjeto</c> preenchido e o arquivo existente; SQL Server pede servidor, banco e usuário.
        /// </summary>
        internal static bool BancoValido()
        {
            return BancoValido(false);
        }

        /// <summary>
        /// O <c>BancoValido()</c> com o aviso (o <c>bMsg</c> padrão do original): <c>MsgBox</c> da
        /// mMensagem 328 sem banco e da 329 com o arquivo inexistente.
        /// </summary>
        internal static bool BancoValido(bool avisar)
        {
            if (!avisar)
            {
                return Validar() == null;
            }

            string aviso = Validar();
            if (aviso != null)
            {
                Interface.Aviso.MsgBox(aviso, string.Empty);
            }

            return aviso == null;
        }

        /// <summary>O motivo do banco inválido (as mMensagens 328/329), ou <c>null</c> quando é válido.</summary>
        private static string Validar()
        {
            ConfiguracaoDoCaderno caderno = Configuracao.ConfiguracaoDoDesenho.LerOuPadrao();
            if (caderno == null)
            {
                return Positron.Data.Interface.MensagensDoReverso.BancoNaoConfigurado;
            }

            // SQL Server: o original ainda testa a conexão (mMensagem 1968); aqui só os campos (a
            // conexão depende da decisão 9c do dono).
            if (string.Equals(caderno.Banco, ConfiguracaoDoCaderno.BancoSqlServer, StringComparison.OrdinalIgnoreCase))
            {
                bool preenchido = !string.IsNullOrWhiteSpace(caderno.DataSource)
                    && !string.IsNullOrWhiteSpace(caderno.BancoDeDados)
                    && !string.IsNullOrWhiteSpace(caderno.User);
                return preenchido ? null : Positron.Data.Interface.MensagensDoReverso.BancoNaoConfigurado;
            }

            string banco = ConfiguracaoEfetiva.Carregar(caderno).Banco;
            if (string.IsNullOrWhiteSpace(banco))
            {
                return Positron.Data.Interface.MensagensDoReverso.BancoNaoConfigurado;
            }

            if (!File.Exists(banco))
            {
                return BancoNaoEncontrado;
            }

            // Desvio do original (que lê o Access): o plugin só lê SQLite. Sem isto o comando seguiria
            // e falharia com "file is not a database".
            return ConfiguracaoEfetiva.EhAccess(banco)
                ? "O banco do projeto deste desenho é do Access (" + banco + "); o Positron ainda só lê banco SQLite (.db)."
                : null;
        }

        /// <summary>
        /// O <c>XDataGeral.verificaTipoXData</c> (<c>XDataGeral.cs:16</c>): o XData do ModelSpace diz de
        /// que produto é o desenho — <c>Eletron</c> = <c>E</c>, <c>DiagLog</c> = <c>D</c>,
        /// <c>ArqNet</c> = <c>A</c>, nenhum = <c>V</c>.
        /// </summary>
        internal static string TipoDoDesenho(Document documento)
        {
            Database banco = documento.Database;
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTable tabela = (BlockTable)transacao.GetObject(banco.BlockTableId, OpenMode.ForRead);
                DBObject espaco = transacao.GetObject(tabela[BlockTableRecord.ModelSpace], OpenMode.ForRead);
                string tipo = Tem(espaco, "Eletron") ? "E" : Tem(espaco, "DiagLog") ? "D" : Tem(espaco, "ArqNet") ? "A" : "V";
                transacao.Commit();
                return tipo;
            }
        }

        private static bool Tem(DBObject objeto, string app)
        {
            using (ResultBuffer xdata = objeto.GetXDataForApplication(app))
            {
                return xdata != null;
            }
        }

        private static void FecharJanelas()
        {
#if !POSITRON_SEM_WINFORMS
            System.Windows.Forms.FormCollection abertas = System.Windows.Forms.Application.OpenForms;
            for (int i = abertas.Count - 1; i >= 0; i--)
            {
                System.Windows.Forms.Form janela = abertas[i];
                // Só as janelas do Elétron (as `frm*` do mapa do reverso): a coleção é do processo e
                // tem também as janelas do próprio CAD.
                string nome = janela.Name ?? string.Empty;
                if (Positron.Data.Interface.Mapas.FormulariosDoReverso.Buscar(nome) != null && !FicamAbertas.Contains(nome))
                {
                    janela.Close();
                }
            }
#endif
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using Positron.Data;
using Positron.Data.Correcoes;
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
    /// <c>Initialize</c> para o desenho já aberto. Do <c>IniciarDWG</c> entram aqui, na ordem do original:
    ///
    /// - os **painéis da barra** pelo **tipo do desenho** (<c>Iniciar.cs:72-127</c>) — a regra é pura
    ///   (<see cref="Positron.Data.Interface.Mapas.LigacaoDosPaineis"/>) e quem aplica é a
    ///   <see cref="Interface.Barra.BarraDeFerramentas"/>;
    /// - as **páginas deste** desenho: com páginas, a **página ativa** é ativada antes de a paleta
    ///   abrir (o <c>else</c> do <c>IniciarDWG</c>, que também lê os atalhos e checa o formato — os dois
    ///   o recoder lê sob demanda, ver *Falta* da rodada 181);
    /// - a paleta de páginas recarregada (o <c>Comandos.GerenciadorPagina</c>, nos dois ramos);
    /// - na **primeira** ativação de cada desenho (o <c>lDwgRegen</c>): o <c>Geral.travaDWG(false)</c>
    ///   (destrava as camadas, ativa a página ativa e dá <c>Regen</c>), o estilo de texto **Romans**, as
    ///   **cinco correções automáticas** — cada uma só se a marca dela ainda não estiver no XData
    ///   <c>CORRECAO</c> do ModelSpace (<see cref="Positron.Data.Correcoes.MarcasDeCorrecao"/>) — e, com
    ///   o banco do projeto inválido (o <c>clsAuxiliar.BancoValido(bMsg: false)</c>) num desenho do
    ///   Elétron (tipo <c>E</c>), a <c>frmConfiguracaoBDProjeto</c>, para ligar o desenho a um banco.
    ///
    /// A configuração (o <c>LerXDataConfiguracao</c>/<c>2</c>) não fica guardada: cada comando relê o
    /// desenho ativo (<see cref="ConfiguracaoEfetiva"/>). O que o <c>IniciarDWG</c> faz e ainda não
    /// entrou (o <c>ACorrecaoBD.CorrigeBD</c> e os dicionários de DWG/painel) está na rodada 181
    /// (*Falta*); o <b>status do banco na paleta</b> entrou na rodada 219
    /// (<see cref="Positron.Data.MonitorDeConexao"/>).
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

        /// <summary>O <c>IniciarDWG</c>: o tipo do desenho, as páginas, a paleta e o bloco de uma vez por desenho.</summary>
        internal static void Iniciar()
        {
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return;
            }

            string tipo = TipoDoDesenho(documento);
            Registrar(Interface.Barra.BarraDeFerramentas.AplicarTipoDoDesenho(tipo));

            // O `else` do `IniciarDWG` (o desenho tem páginas): ativa a página que o desenho mostra e
            // só depois abre a paleta — sem páginas o original abre a paleta direto (o `GerenciadorPagina`).
            IReadOnlyList<string> paginas = Positron.Plugin.Paginas.PaginasDoDesenho.Ler();
            if (paginas.Count > 0)
            {
                Registrar(AtivarAPaginaCorrente("IniciarDWG: " + paginas.Count + " página(s) do caderno"));
            }

            Interface.Folhas.PaletaDeFolhas.Mostrar();

            // O `monitorConexao = 0` + `statusBanco("0")` do `IniciarDWG` (`Iniciar.cs:178-179`): no
            // original a linha está **fora** do `lDwgRegen` (o `if (!lDwgRegen.Contains(...))`), logo
            // roda em toda ativação de documento, e não só na primeira — é o que devolve o ícone do
            // banco ao desconectado ao trocar de desenho.
            MonitorDeConexao.Atual.Reiniciar();

            if (!Iniciados.Add(documento.Name))
            {
                // Já iniciado nesta sessão: o original sai antes do `lDwgRegen`.
                return;
            }

            // --- o `lDwgRegen`: o que roda uma vez por desenho ---

            // O `Geral.travaDWG(bTravar: false)`: destrava as camadas, ativa a página ativa e dá o Regen.
            Registrar(DestravarCamadas());

            Registrar("IniciarDWG: estilo de texto Romans — " + Correcoes.EstiloDeTextoDoDesenho.GarantirRomans());

            foreach (string linha in CorrecoesAutomaticas())
            {
                Registrar(linha);
            }

            documento.Editor.Regen();

            // Só os motivos do original (328/329): o banco Access, que o original lê, não abre a tela.
            string motivo = Validar();
            bool invalidoNoOriginal = motivo == Positron.Data.Interface.MensagensDoReverso.BancoNaoConfigurado
                || motivo == BancoNaoEncontrado;
            if (invalidoNoOriginal && tipo == "E")
            {
                Plugin.Escrever(Interface.Telas.RenderizadorDeTelas.Abrir("frmConfiguracaoBDProjeto", "Banco de Dados do Projeto"));
            }
        }

        /// <summary>
        /// As **cinco correções automáticas** do <c>IniciarDWG</c> (<c>Iniciar.cs:151-186</c>), na ordem
        /// do original, cada uma pulada quando a marca dela já está no XData <c>CORRECAO</c> do desenho.
        /// </summary>
        private static IReadOnlyList<string> CorrecoesAutomaticas()
        {
            List<string> linhas = new List<string>();
            linhas.Add(UmaCorrecao(
                MarcasDeCorrecao.AppNameDoDispositivo,
                "CorrecaoDisp",
                Comandos.ExecutarCorrigirAppNameDosDispositivos));
            linhas.Add(UmaCorrecao(
                MarcasDeCorrecao.BornesVisiveis,
                "CorrecaoBornesVisiveis",
                Comandos.ExecutarCorrigirVisibilidadeDosBornes));
            linhas.Add(UmaCorrecao(
                MarcasDeCorrecao.TextosDeCircuito,
                "correcaoTextosCircuitos",
                ExecutarCorrecaoDosTextosDeCircuito));
            linhas.Add(UmaCorrecao(
                MarcasDeCorrecao.Linhas,
                "correcaoLines",
                ExecutarCorrecaoDosLines));
            linhas.Add(UmaCorrecao(
                MarcasDeCorrecao.OrdemDosBornes,
                "corrigeOrdemBornes",
                Comandos.ExecutarCorrigirOrdemDosBornes));
            return linhas;
        }

        /// <summary>
        /// Uma correção do <c>lDwgRegen</c>: o <c>LerCorrecao</c> (a marca), a correção e o
        /// <c>setaCorrecao</c>. Nunca lança — o erro da correção vira a linha do log, e a marca **não**
        /// é gravada (a correção roda de novo na próxima vez, como no original, que também não marca
        /// quando a chamada estoura e o <c>catch</c> do <c>IniciarDWG</c> pega o erro).
        /// </summary>
        private static string UmaCorrecao(int marca, string nome, Func<string> executar)
        {
            try
            {
                if (Correcoes.MarcasDeCorrecaoDoDesenho.Lida(marca))
                {
                    return nome + ": já corrigido neste desenho (marca " + marca + " no XData " + MarcasDeCorrecao.AppName + ").";
                }

                string resultado = executar();
                bool marcado = Correcoes.MarcasDeCorrecaoDoDesenho.Marcar(marca);
                return nome + ": " + resultado + " (marca " + marca
                    + (marcado ? " gravada" : " NÃO gravada — sem desenho ativo") + ").";
            }
            catch (Exception erro)
            {
                return nome + ": falhou — " + erro.Message + " (marca " + marca + " não gravada).";
            }
        }

        /// <summary>O <c>correcaoTextosCircuitos</c> (<c>Correcao.cs:397</c>) e a linha de resumo.</summary>
        private static string ExecutarCorrecaoDosTextosDeCircuito()
        {
            Correcoes.TextosDeCircuitoDoDesenho.Resultado resultado =
                Correcoes.TextosDeCircuitoDoDesenho.Executar();
            return resultado.TextosCorrigidos + " de " + resultado.TextosAuxiliares
                + " texto(s) auxiliar(es) de circuito alinhados (o VerticalMode 1 vira Baseline na mesma posição)";
        }

        /// <summary>O <c>correcaoLines</c> (<c>Correcao.cs:480</c>) e a linha de resumo.</summary>
        private static string ExecutarCorrecaoDosLines()
        {
            Correcoes.XDataDasLinhasDoDesenho.Resultado resultado =
                Correcoes.XDataDasLinhasDoDesenho.Executar();
            return resultado.LinhasLimpas + " de " + resultado.LinhasLidas + " Line(s) com o XData limpo ("
                + resultado.ConexaoLimpos + " CONEXAO, " + resultado.InterligacaoLimpos + " INTERLIGACAO)";
        }

        /// <summary>
        /// O <c>Geral.travaDWG(false)</c> (<c>Geral.cs:1061</c>): destrava **todas** as camadas, ativa a
        /// página ativa (<c>LocalizaPaginaAtiva</c> + <c>AtivaPagina</c>, dentro do próprio
        /// <c>travaDWG</c>) e dá o <c>Regen</c>. Devolve a linha do log.
        /// </summary>
        private static string DestravarCamadas()
        {
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return "IniciarDWG: sem desenho ativo — camadas não destravadas.";
            }

            Database banco = documento.Database;
            int destravadas = 0;
            using (documento.LockDocument())
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                LayerTable tabela = (LayerTable)transacao.GetObject(banco.LayerTableId, OpenMode.ForRead);
                foreach (ObjectId id in tabela)
                {
                    LayerTableRecord camada = transacao.GetObject(id, OpenMode.ForRead) as LayerTableRecord;
                    if (camada == null || !camada.IsLocked)
                    {
                        continue;
                    }

                    camada.UpgradeOpen();
                    camada.IsLocked = false;
                    destravadas++;
                }

                transacao.Commit();
            }

            string ativacao = AtivarAPaginaCorrente("camadas destravadas (" + destravadas + " travada(s) liberada(s))");
            documento.Editor.Regen();
            return "IniciarDWG: " + ativacao;
        }

        /// <summary>
        /// O <c>Pagina.LocalizaPaginaAtiva()</c> seguido do <c>Pagina.AtivaPagina(pagina)</c>: o
        /// original passa a **camada corrente crua** (não checa se ela é uma página) e a ativação
        /// desliga todos os outros layers. Devolve a linha do log.
        /// </summary>
        private static string AtivarAPaginaCorrente(string situacao)
        {
            string pagina = Positron.Plugin.Paginas.PaginaAtivaDoDesenho.LerCamadaCorrente();
            Positron.Plugin.Paginas.PaginaAtivaDoDesenho.Resultado resultado =
                Positron.Plugin.Paginas.PaginaAtivaDoDesenho.Ativar(pagina);

            // A paleta acompanha a página ativada (o `_uscPagina.ativaPaginaAtalho`), quando já existe.
            Interface.Folhas.PaletaDeFolhas.Recarregar();

            return situacao + " — página ativa \"" + (resultado.PaginaEncontrada ? pagina : "(nenhuma)")
                + "\": " + resultado.LayersDesligados + " layer(s) desligado(s), "
                + resultado.LayersLigados + " ligado(s), " + resultado.LayersAlterados + " alterado(s)";
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

        /// <summary>
        /// A linha do <c>IniciarDWG</c> vai **só para o log do harness** (o original não escreve nada ao
        /// carregar): sem <c>POSITRON_LOG</c> não há linha nenhuma, e a linha de comando do CAD fica
        /// limpa. <c>null</c>/vazio não escreve nada.
        /// </summary>
        private static void Registrar(string linha)
        {
            if (!string.IsNullOrEmpty(linha))
            {
                Plugin.Registrar(linha);
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

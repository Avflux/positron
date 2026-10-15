using System;
using System.Collections.Generic;
using Positron.Data.Configuracao;
using Positron.Data.Fiacao;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
#endif

namespace Positron.Plugin.Configuracao
{
    /// <summary>
    /// O I/O da configuração geral no **desenho**: lê e grava o XData do ModelSpace
    /// como o <c>XDataGeral</c> do reverso (<c>GravarXDataConfiguracao</c>/
    /// <c>GravarXDataConfiguracao2</c>, app <c>Eletron</c> marcador <c>Config</c> e app
    /// <c>EletronProj</c> marcador <c>Projeto</c>).
    ///
    /// A tela <c>frmConfiguracaoGeral</c> do original **grava no desenho, não no banco**:
    /// o <c>btSalvar</c> manda os dois buffers para o ModelSpace e o <c>IniciarDWG</c>
    /// relê ao abrir. A regra (o layout do buffer) é pura:
    /// <see cref="ConfiguracaoDoCaderno"/>.
    ///
    /// O <c>Gravar</c> daqui **junta** os dois apps num buffer só, em vez de trocar o
    /// XData inteiro do ModelSpace a cada chamada (o original faz dois <c>.XData =</c>
    /// seguidos, um por app): assim um não apaga o outro e o XData de terceiros do
    /// ModelSpace fica intacto.
    /// </summary>
    internal static class ConfiguracaoDoDesenho
    {
        /// <summary>O caderno do XData do ModelSpace, ou <c>null</c> quando o desenho ainda não tem.</summary>
        internal static ConfiguracaoDoCaderno Ler()
        {
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return null;
            }

            Database banco = documento.Database;
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTableRecord espaco = EspacoDeModelo(transacao, banco, OpenMode.ForRead);
                ConfiguracaoDoCaderno caderno = ConfiguracaoDoCaderno.Ler(
                    XDataNeutro.Para(((DBObject)espaco).GetXDataForApplication(ConfiguracaoDoCaderno.AppNameConfig)));
                if (caderno == null)
                {
                    transacao.Commit();
                    return null;
                }

                ConfiguracaoDoCaderno comProjeto = ConfiguracaoDoCaderno.LerProjeto(
                    XDataNeutro.Para(((DBObject)espaco).GetXDataForApplication(ConfiguracaoDoCaderno.AppNameProjeto)),
                    caderno);
                transacao.Commit();
                return comProjeto ?? caderno;
            }
        }

        /// <summary>
        /// O que o <c>IniciarDWG</c> do original deixa no <c>Conf</c>: o XData do desenho ou, sem ele, os
        /// padrões (o <c>else</c> do <c>LerXDataConfiguracao</c>, <c>XDataGeral.cs:291-300</c>) e as pastas
        /// do projeto vazias (o <c>else</c> do <c>LerXDataConfiguracao2</c>, <c>:563-571</c>). Os dois apps
        /// são lidos **independentes**, como lá. Nunca <c>null</c> com documento ativo.
        /// </summary>
        internal static ConfiguracaoDoCaderno LerOuPadrao()
        {
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return null;
            }

            Database banco = documento.Database;
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTableRecord espaco = EspacoDeModelo(transacao, banco, OpenMode.ForRead);
                ConfiguracaoDoCaderno caderno = ConfiguracaoDoCaderno.Ler(
                    XDataNeutro.Para(((DBObject)espaco).GetXDataForApplication(ConfiguracaoDoCaderno.AppNameConfig)))
                    ?? ConfiguracaoDoCaderno.Padrao();
                caderno.DirProjeto = string.Empty;
                caderno.DirSimbologiaEletrica = string.Empty;
                caderno.DirSimbologiaRelatorios = string.Empty;
                caderno.DirSimbologiaTopografico = string.Empty;
                caderno.DirSimbologiaLayout = string.Empty;
                ConfiguracaoDoCaderno comProjeto = ConfiguracaoDoCaderno.LerProjeto(
                    XDataNeutro.Para(((DBObject)espaco).GetXDataForApplication(ConfiguracaoDoCaderno.AppNameProjeto)),
                    caderno);
                transacao.Commit();
                return comProjeto ?? caderno;
            }
        }

        /// <summary>Grava os dois buffers no XData do ModelSpace (sem apagar os de terceiros).</summary>
        internal static bool Gravar(ConfiguracaoDoCaderno caderno)
        {
            return Gravar(caderno, true, true);
        }

        /// <summary>Grava só o buffer <c>Eletron</c>/<c>Config</c> — o <c>GravarXDataConfiguracao</c> do original.</summary>
        internal static bool GravarConfig(ConfiguracaoDoCaderno caderno)
        {
            return Gravar(caderno, true, false);
        }

        /// <summary>
        /// Grava só o buffer <c>EletronProj</c>/<c>Projeto</c> — o <c>GravarXDataConfiguracao2</c> do
        /// original (<c>XDataGeral.cs:592</c>), que a <c>frmConfiguracaoBDProjeto</c> chama.
        /// </summary>
        internal static bool GravarProjeto(ConfiguracaoDoCaderno caderno)
        {
            return Gravar(caderno, false, true);
        }

        private static bool Gravar(ConfiguracaoDoCaderno caderno, bool comConfig, bool comProjeto)
        {
            if (caderno == null)
            {
                return false;
            }

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return false;
            }

            // Trava como o original (`GravarXDataConfiguracao2` abre `LockDocument`): quem chama pode ser
            // uma janela não modal.
            Database banco = documento.Database;
            using (documento.LockDocument())
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTableRecord espaco = EspacoDeModelo(transacao, banco, OpenMode.ForWrite);
                if (comConfig)
                {
                    Bornes.BornesDaCorrecao.GarantirAppName(transacao, banco, ConfiguracaoDoCaderno.AppNameConfig);
                }

                if (comProjeto)
                {
                    Bornes.BornesDaCorrecao.GarantirAppName(transacao, banco, ConfiguracaoDoCaderno.AppNameProjeto);
                }

                List<TypedValue> buffer = new List<TypedValue>();
                ResultBuffer atual = ((DBObject)espaco).XData;
                if (atual != null)
                {
                    foreach (TypedValue valor in atual.AsArray())
                    {
                        buffer.Add(valor);
                    }
                }

                if (comConfig)
                {
                    RemoverApp(buffer, ConfiguracaoDoCaderno.AppNameConfig);
                    Acrescentar(buffer, caderno.ParaValores());
                }

                if (comProjeto)
                {
                    RemoverApp(buffer, ConfiguracaoDoCaderno.AppNameProjeto);
                    Acrescentar(buffer, caderno.ParaValoresProjeto());
                }

                ((DBObject)espaco).XData = new ResultBuffer(buffer.ToArray());
                transacao.Commit();
            }

            return true;
        }

        /// <summary>
        /// Tira do buffer o bloco do app name pedido: o `1001` e todos os valores até o
        /// próximo `1001` (o XData é uma sequência de blocos, um por app).
        /// </summary>
        private static void RemoverApp(List<TypedValue> buffer, string appName)
        {
            int i = 0;
            while (i < buffer.Count)
            {
                if (buffer[i].TypeCode != 1001
                    || !string.Equals(Convert.ToString(buffer[i].Value), appName, StringComparison.OrdinalIgnoreCase))
                {
                    i++;
                    continue;
                }

                int fim = i + 1;
                while (fim < buffer.Count && buffer[fim].TypeCode != 1001)
                {
                    fim++;
                }

                buffer.RemoveRange(i, fim - i);
            }
        }

        private static void Acrescentar(List<TypedValue> buffer, IReadOnlyList<TypedXData> valores)
        {
            for (int i = 0; i < valores.Count; i++)
            {
                buffer.Add(new TypedValue(valores[i].Codigo, valores[i].Valor));
            }
        }

        private static BlockTableRecord EspacoDeModelo(Transaction transacao, Database banco, OpenMode modo)
        {
            BlockTable tabela = (BlockTable)transacao.GetObject(banco.BlockTableId, OpenMode.ForRead);
            return (BlockTableRecord)transacao.GetObject(tabela[BlockTableRecord.ModelSpace], modo);
        }
    }
}

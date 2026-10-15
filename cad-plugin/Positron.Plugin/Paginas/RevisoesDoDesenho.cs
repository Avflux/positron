using System;
using System.Collections.Generic;
using Positron.Data;
using Positron.Data.Paginas;
using Positron.Plugin.Bornes;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
#endif

namespace Positron.Plugin.Paginas
{
    /// <summary>
    /// Leitor e gravador das revisões das páginas no desenho CAD:
    /// - <see cref="LerSimplificadas"/> e <see cref="GravarSimplificadas"/>:
    ///   opera sobre os <see cref="DBText"/> de cada página com o XData <c>DiagLog</c>/<c>TituloPagina</c>
    ///   de índice 8 (a tag "REV" do formato, o mesmo do original <c>Revisao.capturaRevisoesSimplificadas</c>).
    /// - <see cref="LerCompletas"/> e <see cref="GravarCompletas"/>:
    ///   opera sobre os blocos de revisão no desenho com XData <c>DiagLog</c>/<c>Revisao</c>
    ///   (o mesmo do original <c>Revisao.capturaRevisoesCompletas</c>).
    /// </summary>
    internal static class RevisoesDoDesenho
    {
        /// <summary>
        /// Lê as revisões simplificadas de todas as páginas do caderno.
        /// </summary>
        internal static List<RevisaoSimplificadaDaPagina> LerSimplificadas()
        {
            List<string> paginas = PaginasDoDesenho.Ler();
            List<RevisaoSimplificadaDaPagina> resultado = new List<RevisaoSimplificadaDaPagina>(paginas.Count);

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                foreach (string pagina in paginas)
                {
                    resultado.Add(new RevisaoSimplificadaDaPagina(pagina, string.Empty));
                }
                return resultado;
            }

            Database banco = documento.Database;
            Dictionary<string, string> revisaoPorPagina = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTableRecord espaco = EspacoDeModelo(transacao, banco, OpenMode.ForRead);
                foreach (ObjectId id in espaco)
                {
                    DBText texto = transacao.GetObject(id, OpenMode.ForRead) as DBText;
                    if (texto == null || string.IsNullOrEmpty(texto.Layer))
                    {
                        continue;
                    }

                    // Como o original, o último campo REV lido na página é o que fica.
                    int indice;
                    string valor;
                    if (IndiceDoTitulo(texto, out indice, out valor) && indice == 8)
                    {
                        revisaoPorPagina[texto.Layer] = texto.TextString ?? valor ?? string.Empty;
                    }
                }

                transacao.Commit();
            }

            // Sem campo REV a revisão fica vazia, como no original (não há fallback para o projeto).
            foreach (string pagina in paginas)
            {
                string rev;
                if (!revisaoPorPagina.TryGetValue(pagina, out rev))
                {
                    rev = string.Empty;
                }
                resultado.Add(new RevisaoSimplificadaDaPagina(pagina, rev));
            }

            return resultado;
        }

        /// <summary>
        /// Regrava as revisões simplificadas nos textos das páginas do desenho.
        /// Devolve quantos textos foram atualizados.
        /// </summary>
        internal static int GravarSimplificadas(IReadOnlyList<RevisaoSimplificadaDaPagina> revisoes)
        {
            if (revisoes == null || revisoes.Count == 0)
            {
                return 0;
            }

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return 0;
            }

            Dictionary<string, string> mapa = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (RevisaoSimplificadaDaPagina item in revisoes)
            {
                if (item != null && !string.IsNullOrEmpty(item.Pagina))
                {
                    mapa[item.Pagina] = item.Revisao ?? string.Empty;
                }
            }

            int gravados = 0;
            Database banco = documento.Database;

            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTableRecord espaco = EspacoDeModelo(transacao, banco, OpenMode.ForWrite);
                BornesDaCorrecao.GarantirAppName(transacao, banco, TituloDaPaginaXData.AppName);

                foreach (ObjectId id in espaco)
                {
                    DBText texto = transacao.GetObject(id, OpenMode.ForRead) as DBText;
                    if (texto == null || string.IsNullOrEmpty(texto.Layer))
                    {
                        continue;
                    }

                    string novaRevisao;
                    if (!mapa.TryGetValue(texto.Layer, out novaRevisao))
                    {
                        continue;
                    }

                    int indice;
                    string valor;
                    if (!IndiceDoTitulo(texto, out indice, out valor) || indice != 8)
                    {
                        continue;
                    }

                    texto.UpgradeOpen();
                    texto.TextString = novaRevisao;
                    texto.XData = BornesDaCorrecao.ParaResultBuffer(TituloDaPaginaXData.ParaValores(
                        8, novaRevisao, Environment.UserName, DateTime.Now.ToString()));
                    gravados++;
                }

                transacao.Commit();
            }

            return gravados;
        }

        /// <summary>
        /// Lê as revisões completas de todas as páginas do caderno.
        /// </summary>
        internal static List<RevisaoCompletaDaPagina> LerCompletas()
        {
            List<string> paginas = PaginasDoDesenho.Ler();
            List<RevisaoCompletaDaPagina> resultado = new List<RevisaoCompletaDaPagina>(paginas.Count);

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                foreach (string pagina in paginas)
                {
                    resultado.Add(new RevisaoCompletaDaPagina(pagina, string.Empty, string.Empty, string.Empty,
                        string.Empty, string.Empty, string.Empty));
                }
                return resultado;
            }

            Database banco = documento.Database;
            Dictionary<string, RevisaoCompletaDaPagina> revPorPagina = new Dictionary<string, RevisaoCompletaDaPagina>(StringComparer.OrdinalIgnoreCase);

            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTableRecord espaco = EspacoDeModelo(transacao, banco, OpenMode.ForRead);
                foreach (ObjectId id in espaco)
                {
                    BlockReference bloco = transacao.GetObject(id, OpenMode.ForRead) as BlockReference;
                    if (bloco == null || string.IsNullOrEmpty(bloco.Layer))
                    {
                        continue;
                    }

                    ResultBuffer xdata = bloco.GetXDataForApplication(RevisaoCompletaXData.AppName);
                    if (xdata == null)
                    {
                        continue;
                    }

                    RevisaoCompletaDaPagina rev;
                    if (!RevisaoCompletaXData.Ler(XDataNeutro.Para(xdata), out rev))
                    {
                        continue;
                    }

                    rev.Pagina = bloco.Layer;

                    // Como o capturaRevisoesCompletas: a posição nova tem de ser maior que a guardada (0 no início).
                    RevisaoCompletaDaPagina existente;
                    int posicaoGuardada = revPorPagina.TryGetValue(bloco.Layer, out existente) ? existente.Posicao : 0;
                    if (OperacoesDeRevisao.AceitaRevisaoCompleta(posicaoGuardada, rev.Posicao))
                    {
                        revPorPagina[bloco.Layer] = rev;
                    }
                }

                transacao.Commit();
            }

            foreach (string pagina in paginas)
            {
                RevisaoCompletaDaPagina rev;
                if (!revPorPagina.TryGetValue(pagina, out rev))
                {
                    rev = new RevisaoCompletaDaPagina(pagina, string.Empty, string.Empty, string.Empty,
                        string.Empty, string.Empty, string.Empty);
                }
                resultado.Add(rev);
            }

            return resultado;
        }

        /// <summary>
        /// Regrava as revisões completas nos blocos de revisão do desenho.
        /// Devolve quantos blocos foram atualizados.
        /// </summary>
        internal static int GravarCompletas(IReadOnlyList<RevisaoCompletaDaPagina> revisoes)
        {
            if (revisoes == null || revisoes.Count == 0)
            {
                return 0;
            }

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return 0;
            }

            Dictionary<string, RevisaoCompletaDaPagina> mapa = new Dictionary<string, RevisaoCompletaDaPagina>(StringComparer.OrdinalIgnoreCase);
            foreach (RevisaoCompletaDaPagina item in revisoes)
            {
                if (item != null && !string.IsNullOrEmpty(item.Pagina))
                {
                    mapa[item.Pagina] = item;
                }
            }

            int gravados = 0;
            Database banco = documento.Database;

            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTableRecord espaco = EspacoDeModelo(transacao, banco, OpenMode.ForWrite);
                BornesDaCorrecao.GarantirAppName(transacao, banco, RevisaoCompletaXData.AppName);

                foreach (ObjectId id in espaco)
                {
                    BlockReference bloco = transacao.GetObject(id, OpenMode.ForRead) as BlockReference;
                    if (bloco == null || string.IsNullOrEmpty(bloco.Layer))
                    {
                        continue;
                    }

                    RevisaoCompletaDaPagina nova;
                    if (!mapa.TryGetValue(bloco.Layer, out nova))
                    {
                        continue;
                    }

                    ResultBuffer xdata = bloco.GetXDataForApplication(RevisaoCompletaXData.AppName);
                    if (xdata == null)
                    {
                        continue;
                    }

                    RevisaoCompletaDaPagina atual;
                    if (!RevisaoCompletaXData.Ler(XDataNeutro.Para(xdata), out atual))
                    {
                        continue;
                    }

                    bloco.UpgradeOpen();
                    nova.Posicao = atual.Posicao;
                    bloco.XData = BornesDaCorrecao.ParaResultBuffer(RevisaoCompletaXData.ParaValores(
                        nova, Environment.UserName, DateTime.Now.ToString()));

                    // Sincroniza atributos do bloco caso existam
                    foreach (ObjectId idAtributo in bloco.AttributeCollection)
                    {
                        AttributeReference atributo = transacao.GetObject(idAtributo, OpenMode.ForWrite) as AttributeReference;
                        if (atributo == null || string.IsNullOrEmpty(atributo.Tag))
                        {
                            continue;
                        }

                        // As tags reais são REV0..REV7, DESC0..DESC7 etc. (o JdCp1GqFmnk do original).
                        switch (RevisaoCompletaXData.CampoDoAtributo(atributo.Tag))
                        {
                            case "Revisao":
                                atributo.TextString = nova.Revisao ?? string.Empty;
                                break;
                            case "Descricao":
                                atributo.TextString = nova.Descricao ?? string.Empty;
                                break;
                            case "Data":
                                atributo.TextString = nova.Data ?? string.Empty;
                                break;
                            case "Elaborador":
                                atributo.TextString = nova.Elaborador ?? string.Empty;
                                break;
                            case "Verificador":
                                atributo.TextString = nova.Verificador ?? string.Empty;
                                break;
                            case "Aprovador":
                                atributo.TextString = nova.Aprovador ?? string.Empty;
                                break;
                        }
                    }

                    gravados++;
                }

                transacao.Commit();
            }

            return gravados;
        }

        private static bool IndiceDoTitulo(DBText texto, out int indice, out string valor)
        {
            indice = 0;
            valor = null;
            ResultBuffer xdata = texto.GetXDataForApplication(TituloDaPaginaXData.AppName);
            return xdata != null && TituloDaPaginaXData.Ler(XDataNeutro.Para(xdata), out indice, out valor);
        }

        private static BlockTableRecord EspacoDeModelo(Transaction transacao, Database banco, OpenMode modo)
        {
            BlockTable tabela = (BlockTable)transacao.GetObject(banco.BlockTableId, OpenMode.ForRead);
            return (BlockTableRecord)transacao.GetObject(tabela[BlockTableRecord.ModelSpace], modo);
        }
    }
}

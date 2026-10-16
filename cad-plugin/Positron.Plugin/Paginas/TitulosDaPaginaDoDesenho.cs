using System;
using System.Collections.Generic;
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
    /// Os **quatro títulos de uma página** no desenho: o <c>capturaTitulosDeUmaPagina</c> (ler) e o
    /// <c>AtualizaTitulosDeUmaPagina</c> (regravar) do original. O que identifica um título é o
    /// **XData** <c>DiagLog</c>/<c>TituloPagina</c> do texto (o <c>LeXDataTitulo</c>) — a tag do
    /// atributo que o criou não entra na conta.
    ///
    /// A leitura e a gravação varrem o ModelSpace pelo **layer da página**, como o original:
    ///
    /// - ler: o primeiro texto de cada índice 1..4 preenche o título e a conta para quando os
    ///   **quatro** apareceram (mesmo vazios);
    /// - gravar: cada texto com índice 1..4 recebe o título do seu índice e o XData é reescrito com
    ///   o valor novo, até **quatro** textos (o contador do original é por texto, e é por isso que
    ///   uma página com <c>TITULO4PAG</c> **e** <c>PAINEL</c> — os dois com índice 4 — pode parar
    ///   antes de tocar todos).
    /// </summary>
    internal static class TitulosDaPaginaDoDesenho
    {
        /// <summary>Lê os títulos de uma página (vazios quando ela não tem campo nenhum).</summary>
        internal static TitulosDaPagina Ler(string pagina)
        {
            TitulosDaPagina titulos = new TitulosDaPagina();
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null || string.IsNullOrEmpty(pagina))
            {
                return titulos;
            }

            Database banco = documento.Database;
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTableRecord espaco = EspacoDeModelo(transacao, banco, OpenMode.ForRead);
                foreach (ObjectId id in espaco)
                {
                    if (titulos.Completos)
                    {
                        break;
                    }

                    DBText texto = transacao.GetObject(id, OpenMode.ForRead) as DBText;
                    if (texto == null || !string.Equals(texto.Layer, pagina, StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    int indice;
                    string valor;
                    if (IndiceDoTitulo(texto, out indice, out valor))
                    {
                        titulos.Definir(indice, valor);
                    }
                }

                transacao.Commit();
            }

            return titulos;
        }

        /// <summary>Regrava os títulos nos textos da página e devolve quantos foram tocados.</summary>
        internal static int Gravar(string pagina, TitulosDaPagina titulos)
        {
            if (titulos == null || string.IsNullOrEmpty(pagina))
            {
                return 0;
            }

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return 0;
            }

            Database banco = documento.Database;
            int gravados = 0;
            // A gravacao vem da paleta (fora de comando): trava como o original, que abre o
            // `LockDocument` em cada rotina de escrita.
            using (documento.LockDocument())
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTableRecord espaco = EspacoDeModelo(transacao, banco, OpenMode.ForWrite);
                BornesDaCorrecao.GarantirAppName(transacao, banco, TituloDaPaginaXData.AppName);

                foreach (ObjectId id in espaco)
                {
                    if (gravados >= TitulosDaPagina.UltimoIndice)
                    {
                        break;
                    }

                    DBText texto = transacao.GetObject(id, OpenMode.ForRead) as DBText;
                    if (texto == null || !string.Equals(texto.Layer, pagina, StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    int indice;
                    string valor;
                    if (!IndiceDoTitulo(texto, out indice, out valor))
                    {
                        continue;
                    }

                    string novo = titulos.De(indice);
                    if (novo == null)
                    {
                        continue;
                    }

                    texto.UpgradeOpen();
                    texto.TextString = novo;
                    texto.XData = BornesDaCorrecao.ParaResultBuffer(TituloDaPaginaXData.ParaValores(
                        indice, novo, Environment.UserName, DateTime.Now.ToString()));
                    gravados++;
                }

                transacao.Commit();
            }

            return gravados;
        }

        /// <summary>Pagina.capturaTitulos: TextString, último índice vence; não usa o limite da edição individual.</summary>
        internal static Dictionary<string, TitulosDaPagina> LerGrade()
        {
            Dictionary<string, TitulosDaPagina> linhas = new Dictionary<string, TitulosDaPagina>(StringComparer.OrdinalIgnoreCase);
            foreach (string pagina in PaginasDoDesenho.Ler()) linhas[pagina] = new TitulosDaPagina();
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null) return linhas;
            using (Transaction transacao = documento.Database.TransactionManager.StartTransaction())
            {
                foreach (ObjectId id in EspacoDeModelo(transacao, documento.Database, OpenMode.ForRead))
                {
                    DBText texto = transacao.GetObject(id, OpenMode.ForRead) as DBText;
                    TitulosDaPagina titulos;
                    int indice;
                    string valor;
                    if (texto != null && linhas.TryGetValue(texto.Layer, out titulos)
                        && IndiceDoTitulo(texto, out indice, out valor) && indice >= 1 && indice <= 4)
                        titulos.Definir(indice, texto.TextString);
                }
                transacao.Commit();
            }
            return linhas;
        }

        /// <summary>Pagina.AtualizaTitulos: todos os textos 1..4 e 9, numa transação com lock.</summary>
        internal static int GravarGrade(IDictionary<string, TitulosDaPagina> linhas, IDictionary<string, string> alternativos)
        {
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null) return 0;
            int gravados = 0;
            using (documento.LockDocument())
            using (Transaction transacao = documento.Database.TransactionManager.StartTransaction())
            {
                BornesDaCorrecao.GarantirAppName(transacao, documento.Database, TituloDaPaginaXData.AppName);
                foreach (ObjectId id in EspacoDeModelo(transacao, documento.Database, OpenMode.ForRead))
                {
                    DBText texto = transacao.GetObject(id, OpenMode.ForRead) as DBText;
                    TitulosDaPagina titulos;
                    int indice;
                    string valor;
                    if (texto == null || !linhas.TryGetValue(texto.Layer, out titulos)
                        || !IndiceDoTitulo(texto, out indice, out valor)) continue;
                    string novo;
                    if (indice >= 1 && indice <= 4) novo = titulos.De(indice) ?? "";
                    else if (indice == 9 && alternativos.TryGetValue(texto.Layer, out novo)) { }
                    else continue;
                    texto.UpgradeOpen();
                    texto.TextString = novo;
                    texto.XData = BornesDaCorrecao.ParaResultBuffer(TituloDaPaginaXData.ParaValores(
                        indice, novo, Environment.UserName, DateTime.Now.ToString()));
                    gravados++;
                }
                transacao.Commit();
            }
            return gravados;
        }

        /// <summary>O índice e o valor do XData do título do texto (o <c>LeXDataTitulo</c>).</summary>
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

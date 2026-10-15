using System;
using System.Collections.Generic;
using Positron.Data.Paginas;
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
    /// A casca do <c>TROCTT</c>: lê os títulos que o formato tem (o <c>buscaTitulosExistentes</c>) e
    /// aplica a <see cref="EdicaoDeTitulosETextos"/> no ModelSpace (o <c>EditaTitulosTextosDoDWG</c>).
    /// </summary>
    internal static class TitulosETextosDoDesenho
    {
        /// <summary>Os títulos 1..4 que existem nos atributos do bloco de formato (índice 0 sem uso).</summary>
        internal static bool[] LerTitulosExistentes()
        {
            List<KeyValuePair<string, string>> atributos = new List<KeyValuePair<string, string>>();
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return EdicaoDeTitulosETextos.TitulosExistentes(atributos);
            }

            Database banco = documento.Database;
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTable tabela = (BlockTable)transacao.GetObject(banco.BlockTableId, OpenMode.ForRead);
                BlockTableRecord espaco = (BlockTableRecord)transacao.GetObject(tabela[BlockTableRecord.ModelSpace], OpenMode.ForRead);
                BlockReference formato = FormatoDoDesenho.Encontrar(transacao, espaco);
                if (formato != null)
                {
                    foreach (ObjectId id in formato.AttributeCollection)
                    {
                        AttributeReference atributo = transacao.GetObject(id, OpenMode.ForRead) as AttributeReference;
                        if (atributo != null)
                        {
                            atributos.Add(new KeyValuePair<string, string>(atributo.Tag, atributo.Layer));
                        }
                    }
                }

                transacao.Commit();
            }

            return EdicaoDeTitulosETextos.TitulosExistentes(atributos);
        }

        /// <summary>Aplica a troca nas páginas dadas; devolve quantos textos mudaram.</summary>
        internal static int Editar(OpcoesDeTitulosETextos opcoes, ICollection<string> paginas)
        {
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null || opcoes == null || !opcoes.Valida)
            {
                return 0;
            }

            int alterados = 0;
            Database banco = documento.Database;
            using (documento.LockDocument())
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTable tabela = (BlockTable)transacao.GetObject(banco.BlockTableId, OpenMode.ForRead);
                BlockTableRecord espaco = (BlockTableRecord)transacao.GetObject(tabela[BlockTableRecord.ModelSpace], OpenMode.ForRead);
                foreach (ObjectId id in espaco)
                {
                    Entity entidade = transacao.GetObject(id, OpenMode.ForRead) as Entity;
                    DBText texto = entidade as DBText;
                    MText multi = entidade as MText;
                    if (texto == null && multi == null)
                    {
                        continue;
                    }

                    TextoNaPagina lida = texto != null
                        ? new TextoNaPagina(TipoDeTextoNaPagina.Texto, entidade.Layer, texto.TextString, Titulo(texto), Protegido(entidade))
                        : new TextoNaPagina(TipoDeTextoNaPagina.MultiTexto, entidade.Layer, multi.Contents, 0, Protegido(entidade));
                    string novo = EdicaoDeTitulosETextos.NovoTexto(lida, opcoes, paginas);
                    if (novo == null)
                    {
                        continue;
                    }

                    entidade.UpgradeOpen();
                    if (texto != null)
                    {
                        texto.TextString = novo;
                    }
                    else
                    {
                        multi.Contents = novo;
                    }

                    alterados++;
                }

                transacao.Commit();
            }

            return alterados;
        }

        /// <summary>O <c>LeXDataTitulo</c>: o índice do <c>TituloPagina</c> (só 1..4 vale), ou 0.</summary>
        private static int Titulo(DBText texto)
        {
            ResultBuffer xdata = texto.GetXDataForApplication(TituloDaPaginaXData.AppName);
            int indice;
            string valor;
            if (xdata == null || !TituloDaPaginaXData.Ler(XDataNeutro.Para(xdata), out indice, out valor))
            {
                return 0;
            }

            return indice > 0 && indice < 5 ? indice : 0;
        }

        /// <summary>O <c>LerXDataVazio</c>: tem XData de algum app do produto.</summary>
        private static bool Protegido(Entity entidade)
        {
            foreach (string app in EdicaoDeTitulosETextos.AppsProtegidos)
            {
                ResultBuffer xdata = entidade.GetXDataForApplication(app);
                if (xdata != null)
                {
                    xdata.Dispose();
                    return true;
                }
            }

            return false;
        }
    }
}

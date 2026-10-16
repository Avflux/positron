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
    /// A parte que **apaga** a página: o <c>Pagina.ApagarElementosPagina</c> do reverso — toda
    /// entidade do ModelSpace no layer da página é apagada (<c>Erase</c>) — mais o **layer**, que o
    /// botão "Excluir Páginas" do original também chama o `RemoveLayer`, então o layer sai junto).
    ///
    /// A decisão de poder apagar é pura (<see cref="ExclusaoDePagina.Recusa"/>); aqui só se varre e
    /// se apaga. **Nunca lança**: a ação é destrutiva e o comando reporta o que fez.
    /// </summary>
    internal static class ExclusaoDePaginaDoDesenho
    {
        internal sealed class Resultado
        {
            /// <summary>O nome recusado (vazio quando a página foi apagada).</summary>
            internal string Recusa { get; set; }

            /// <summary>A mensagem do erro que impediu o apagar (o `MsgBox(ex.Message, Critical)` do original).</summary>
            internal string Falha { get; set; }

            /// <summary>Entidades apagadas do ModelSpace.</summary>
            internal int Entidades { get; set; }

            /// <summary>O layer da página foi apagado.</summary>
            internal bool LayerApagado { get; set; }

            /// <summary>Campos CONT/FL/TOT/ALTERNATIVO recalculados após a exclusão da página.</summary>
            internal int ContTotFlAtualizados { get; set; }
        }

        internal static Resultado Executar(string pagina)
        {
            Resultado resultado = new Resultado();

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                resultado.Recusa = "sem documento ativo";
                return resultado;
            }

            Database banco = documento.Database;
            try
            {
                // O original trava em cada rotina (`Pagina.ApagarElementosPagina` e `Pagina.RemoveLayer`):
                // a exclusao vem da paleta, que roda fora de comando.
                using (documento.LockDocument())
                using (Transaction transacao = banco.TransactionManager.StartTransaction())
                {
                    BlockTableRecord espaco = EspacoDeModelo(transacao, banco, OpenMode.ForWrite);
                    List<ObjectId> apagar = new List<ObjectId>();
                    foreach (ObjectId id in espaco)
                    {
                        Entity entidade = transacao.GetObject(id, OpenMode.ForRead) as Entity;
                        if (entidade == null)
                        {
                            continue;
                        }

                        if (string.Equals(entidade.Layer, pagina, StringComparison.OrdinalIgnoreCase))
                        {
                            apagar.Add(id);
                        }
                    }

                    foreach (ObjectId id in apagar)
                    {
                        DBObject objeto = transacao.GetObject(id, OpenMode.ForWrite);
                        objeto.Erase();
                        resultado.Entidades++;
                    }

                    LayerTable camadas = (LayerTable)transacao.GetObject(banco.LayerTableId, OpenMode.ForRead);
                    if (camadas.Has(pagina))
                    {
                        // Como no Pagina.RemoveLayer do original (linha 2225): se o layer a apagar for a camada
                        // corrente (Clayer), mudar para o layer "0" antes de apagar, evitando exceção no CAD.
                        // O original deixa a camada corrente no "0" (o `bAtivaPag` do RemoveLayer é do
                        // `frmExportarImportar`, não da paleta).
                        if (banco.Clayer == camadas[pagina])
                        {
                            banco.Clayer = camadas["0"];
                        }

                        camadas.UpgradeOpen();
                        LayerTableRecord layer = (LayerTableRecord)transacao.GetObject(camadas[pagina], OpenMode.ForWrite);
                        layer.Erase();
                        resultado.LayerApagado = true;
                    }

                    transacao.Commit();
                }
            }
            catch (Exception erro)
            {
                // O `MsgBox(ex.Message, Critical)` de cada linha do handler do original
                // (`uscPaginas.cs:2194`): a falha sobe para quem chamou, que a mostra ao usuário.
                resultado.Falha = erro.Message;
                return resultado;
            }

            // Recalcula CONT, FL, TOT e ALTERNATIVO do caderno remanescente (o Pagina.AtualizaContTotFl do original).
            resultado.ContTotFlAtualizados = RestauracaoDoFormatoDoDesenho.AtualizarContTotFl(banco);

            return resultado;
        }

        private static BlockTableRecord EspacoDeModelo(Transaction transacao, Database banco, OpenMode modo)
        {
            BlockTable tabela = (BlockTable)transacao.GetObject(banco.BlockTableId, OpenMode.ForRead);
            return (BlockTableRecord)transacao.GetObject(tabela[BlockTableRecord.ModelSpace], modo);
        }
    }
}

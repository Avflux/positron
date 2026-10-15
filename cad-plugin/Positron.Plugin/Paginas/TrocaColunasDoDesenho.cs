using System;
using System.Collections.Generic;
using Positron.Data.Fiacao;
using Positron.Data.Paginas;
using Positron.Plugin.Bornes;
#if AUTOCAD
using Autodesk.AutoCAD.DatabaseServices;
#else
using ZwSoft.ZwCAD.DatabaseServices;
#endif

namespace Positron.Plugin.Paginas
{
    /// <summary>
    /// A rotina de <c>Pagina.TrocaColunas</c> do reverso:
    /// 1. Varre o ModelSpace buscando entidades com XData <c>DiagLog</c>/<c>COLUNAS</c>;
    /// 2. Coleta os pares únicos de <c>(layer, tipo)</c> (página e tipo da coluna);
    /// 3. Apaga essas entidades de coluna antigas do ModelSpace;
    /// 4. Para cada par único <c>(página, tipo)</c>, busca no bloco de formato as entidades
    ///    cujo layer coincide com <c>tipo</c>, clona cada uma para o ModelSpace no layer da
    ///    <c>página</c> e regrava o XData <c>DiagLog</c>/<c>COLUNAS</c> (<c>InserirColuna</c>).
    /// </summary>
    internal static class TrocaColunasDoDesenho
    {
        internal sealed class Resultado
        {
            /// <summary>Entidades de coluna antigas apagadas do ModelSpace.</summary>
            internal int EntidadesApagadas { get; set; }

            /// <summary>Pares únicos (página, tipo de coluna) reconhecidos.</summary>
            internal int ColunasReconhecidas { get; set; }

            /// <summary>Entidades de coluna clonadas e inseridas a partir do novo formato.</summary>
            internal int EntidadesCriadas { get; set; }
        }

        /// <summary>
        /// Executa a troca de colunas. Nunca lança exceção.
        /// </summary>
        internal static Resultado Trocar(Database banco, ObjectId formatoDefId)
        {
            Resultado resultado = new Resultado();
            if (banco == null || formatoDefId.IsNull)
            {
                return resultado;
            }

            try
            {
                List<ObjectId> entidadesAntigas = new List<ObjectId>();
                List<ColunaDaPagina> colunasEncontradas = new List<ColunaDaPagina>();

                using (Transaction transacao = banco.TransactionManager.StartTransaction())
                {
                    BlockTable tabela = transacao.GetObject(banco.BlockTableId, OpenMode.ForRead) as BlockTable;
                    if (tabela == null)
                    {
                        return resultado;
                    }

                    BlockTableRecord espaco = transacao.GetObject(tabela[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                    if (espaco == null)
                    {
                        return resultado;
                    }

                    // 1) Identifica as entidades de coluna existentes no ModelSpace
                    foreach (ObjectId id in espaco)
                    {
                        Entity ent = transacao.GetObject(id, OpenMode.ForRead) as Entity;
                        if (ent == null || string.IsNullOrEmpty(ent.Layer))
                        {
                            continue;
                        }

                        ResultBuffer xdata = ent.GetXDataForApplication(ColunaDaPaginaXData.AppName);
                        if (xdata == null)
                        {
                            continue;
                        }

                        string tipo;
                        if (ColunaDaPaginaXData.Ler(XDataNeutro.Para(xdata), out tipo) && !string.IsNullOrEmpty(tipo))
                        {
                            colunasEncontradas.Add(new ColunaDaPagina(ent.Layer, tipo));
                            entidadesAntigas.Add(id);
                        }
                    }

                    // 2) Apaga as entidades antigas
                    foreach (ObjectId id in entidadesAntigas)
                    {
                        Entity ent = transacao.GetObject(id, OpenMode.ForWrite) as Entity;
                        if (ent != null)
                        {
                            ent.Erase();
                            resultado.EntidadesApagadas++;
                        }
                    }

                    transacao.Commit();
                }

                // Deduplica (página, tipo)
                List<ColunaDaPagina> colunasUnicas = ColunaDaPagina.Deduplicar(colunasEncontradas);
                resultado.ColunasReconhecidas = colunasUnicas.Count;

                if (colunasUnicas.Count == 0)
                {
                    return resultado;
                }

                // 3) Insere as novas entidades a partir da definição do bloco de formato
                using (Transaction transacao = banco.TransactionManager.StartTransaction())
                {
                    BlockTable tabela = transacao.GetObject(banco.BlockTableId, OpenMode.ForRead) as BlockTable;
                    BlockTableRecord espaco = transacao.GetObject(tabela[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                    BlockTableRecord formatoDef = transacao.GetObject(formatoDefId, OpenMode.ForRead) as BlockTableRecord;

                    if (espaco != null && formatoDef != null)
                    {
                        BornesDaCorrecao.GarantirAppName(transacao, banco, ColunaDaPaginaXData.AppName);

                        foreach (ColunaDaPagina col in colunasUnicas)
                        {
                            foreach (ObjectId id in formatoDef)
                            {
                                Entity modelo = transacao.GetObject(id, OpenMode.ForRead) as Entity;
                                if (modelo == null)
                                {
                                    continue;
                                }

                                if (string.Equals(modelo.Layer, col.Tipo, StringComparison.OrdinalIgnoreCase))
                                {
                                    Entity clone = modelo.Clone() as Entity;
                                    if (clone != null)
                                    {
                                        clone.Layer = col.Pagina;
                                        espaco.AppendEntity(clone);
                                        transacao.AddNewlyCreatedDBObject(clone, true);

                                        IReadOnlyList<TypedXData> xdataValores = ColunaDaPaginaXData.ParaValores(
                                            col.Tipo,
                                            Environment.UserName,
                                            DateTime.Now.ToString());
                                        clone.XData = BornesDaCorrecao.ParaResultBuffer(xdataValores);

                                        resultado.EntidadesCriadas++;
                                    }
                                }
                            }
                        }
                    }

                    transacao.Commit();
                }
            }
            catch
            {
                // TrocaColunas não deve interromper a cadeia do CAD em caso de erro não crítico
            }

            return resultado;
        }
    }
}

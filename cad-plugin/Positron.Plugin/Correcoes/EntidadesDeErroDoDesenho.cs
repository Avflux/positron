using System.Collections.Generic;
using Positron.Data.Correcoes;
using Positron.Data.Fiacao;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
#endif

namespace Positron.Plugin.Correcoes
{
    /// <summary>
    /// O <c>clsBlocos.ApagaERROS</c> (o passo 2 do <c>RESTPROJ</c>): percorre o espaço de modelo e
    /// **apaga** as entidades marcadas com o XData <c>ERRO</c> cujo primeiro valor é a marca.
    ///
    /// A regra é pura (<see cref="EntidadesDeErro"/>); aqui só se lê e se apaga.
    /// </summary>
    internal static class EntidadesDeErroDoDesenho
    {
        internal sealed class Resultado
        {
            internal int Entidades { get; set; }

            internal int Marcadas { get; set; }
        }

        internal static Resultado Executar(string marca)
        {
            Resultado resultado = new Resultado();

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return resultado;
            }

            Database banco = documento.Database;
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTable tabela = (BlockTable)transacao.GetObject(banco.BlockTableId, OpenMode.ForRead);
                BlockTableRecord espaco = (BlockTableRecord)transacao.GetObject(
                    tabela[BlockTableRecord.ModelSpace], OpenMode.ForWrite);

                foreach (ObjectId id in espaco)
                {
                    Entity entidade = transacao.GetObject(id, OpenMode.ForRead) as Entity;
                    if (entidade == null)
                    {
                        continue;
                    }

                    resultado.Entidades++;

                    ResultBuffer xdata = entidade.GetXDataForApplication(EntidadesDeErro.AppName);
                    IReadOnlyList<TypedXData> valores = XDataNeutro.Para(xdata);
                    if (valores == null || valores.Count == 0)
                    {
                        continue;
                    }

                    if (!EntidadesDeErro.EhMarca(valores[0].Valor as string, marca))
                    {
                        continue;
                    }

                    entidade.UpgradeOpen();
                    entidade.Erase();
                    resultado.Marcadas++;
                }

                transacao.Commit();
            }

            return resultado;
        }
    }
}

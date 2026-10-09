using System.Collections.Generic;
using Positron.Data.Layout;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
#endif

namespace Positron.Plugin.Layout
{
    /// <summary>
    /// Lê o perfil de XData do ModelSpace: quantos XData de cada app name o desenho
    /// carrega. É o que permite o comando dizer *o que* o desenho tem quando não
    /// encontra o que procurava.
    ///
    /// Percorre `Entity.XData` (o <c>ResultBuffer</c> inteiro) e conta as entradas de
    /// código <c>1001</c> — o nome da aplicação de cada bloco de XData. Não depende
    /// de app name conhecido, então funciona em desenho de documento, de diagrama ou
    /// de outro produto qualquer.
    /// </summary>
    public static class PerfilDoDesenhoDoDesenho
    {
        public static PerfilDoDesenho Ler()
        {
            PerfilDoDesenho perfil = new PerfilDoDesenho();

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return perfil;
            }

            Database banco = documento.Database;

            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTable tabela = (BlockTable)transacao.GetObject(banco.BlockTableId, OpenMode.ForRead);
                BlockTableRecord espaco = (BlockTableRecord)transacao.GetObject(
                    tabela[BlockTableRecord.ModelSpace],
                    OpenMode.ForRead);

                foreach (ObjectId id in espaco)
                {
                    Entity entidade = transacao.GetObject(id, OpenMode.ForRead) as Entity;
                    if (entidade == null)
                    {
                        continue;
                    }

                    ResultBuffer xdata = entidade.XData;
                    if (xdata == null)
                    {
                        continue;
                    }

                    foreach (TypedValue valor in xdata.AsArray())
                    {
                        if (valor.TypeCode == 1001)
                        {
                            perfil.Registrar(valor.Value as string);
                        }
                    }
                }

                transacao.Commit();
            }

            return perfil;
        }
    }
}

using System.Collections.Generic;
using Positron.Data.Fiacao;
using Positron.Data.Interligacao;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
#endif

namespace Positron.Plugin.Interligacao
{
    /// <summary>
    /// Única parte do fluxo de interligação que toca a API do ZWCAD: varre o
    /// ModelSpace atrás de <c>LWPOLYLINE</c> com XData <c>INTERLIGACAO</c> e
    /// devolve os pontos já em tipos neutros (<see cref="PontoInterligacao"/>),
    /// que o resto do código sabe projetar e testar sem o ZWCAD.
    ///
    /// Mesma varredura do original (<c>frmCompilarInterligacao</c>): uma
    /// transação, BlockTable/ModelSpace e leitura do XData por entidade.
    /// Trechos com <c>Num_Veia == -1000</c> (veia indefinida) são descartados,
    /// como no original.
    /// </summary>
    public static class InterligacaoDoDesenho
    {
        public static IReadOnlyList<PontoInterligacao> Ler()
        {
            List<PontoInterligacao> pontos = new List<PontoInterligacao>();

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return pontos;
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
                    Polyline linha = entidade as Polyline;
                    if (linha == null)
                    {
                        continue;
                    }

                    ResultBuffer xdata = ((DBObject)linha).GetXDataForApplication(InterligacaoXData.AppName);
                    if (xdata == null)
                    {
                        continue;
                    }

                    InterligacaoXData ilig;
                    if (!InterligacaoXData.Ler(XDataNeutro.Para(xdata), out ilig))
                    {
                        // XData inválido/truncado não derruba o comando.
                        continue;
                    }

                    if (ilig.NumVeia == InterligacaoXData.NumVeiaIndefinido)
                    {
                        continue;
                    }

                    pontos.Add(PontoInterligacao.DeInterligacao(ilig, entidade.Layer));
                }

                transacao.Commit();
            }

            return pontos;
        }
    }
}

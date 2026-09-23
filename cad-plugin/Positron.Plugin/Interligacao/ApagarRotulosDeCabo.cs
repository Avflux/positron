using System.Collections.Generic;
using Positron.Data.Configuracao;
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
    /// A **limpeza** compartilhada pelas duas recriações de rótulo de cabo
    /// (<c>RecriaTextosCabo</c> e <c>RecriaTextosCaboEletrosul</c>): as duas chamam
    /// o mesmo <c>clsEletron.ApagarTodosOsTextosDasVeias</c> antes de reinserir.
    ///
    /// A regra é pura (<see cref="CorrecaoTextosCabo.ApagarRotulo"/>); aqui só se
    /// varre o ModelSpace e se apaga.
    /// </summary>
    internal static class ApagarRotulosDeCabo
    {
        internal sealed class Resultado
        {
            internal int EntidadesLidas { get; set; }

            internal int Apagados { get; set; }

            /// <summary>Textos apagados (os rótulos auxiliares).</summary>
            internal int TextosApagados { get; set; }

            /// <summary>Não-textos apagados (os ornamentos da Eletrosul).</summary>
            internal int OrnamentosApagados { get; set; }
        }

        internal static Resultado Executar(ConfiguracaoPositron config)
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
                    tabela[BlockTableRecord.ModelSpace], OpenMode.ForRead);

                foreach (ObjectId id in espaco)
                {
                    Entity entidade = transacao.GetObject(id, OpenMode.ForRead) as Entity;
                    if (entidade == null)
                    {
                        continue;
                    }

                    resultado.EntidadesLidas++;

                    bool apagar;
                    if (entidade is DBText)
                    {
                        short tipo;
                        bool auxiliar = AuxInterligacaoXData.Ler(
                            LerXData(entidade, AuxInterligacaoXData.AppName), out tipo);
                        apagar = CorrecaoTextosCabo.ApagarRotulo(
                            true, false, auxiliar, tipo, config.InterligacaoLayout, false);
                    }
                    else
                    {
                        bool eletrosul = TemXData(entidade, AuxInterligacaoEletrosulXData.AppName);
                        bool auxiliar = TemXData(entidade, AuxInterligacaoXData.AppName);
                        apagar = CorrecaoTextosCabo.ApagarRotulo(
                            false, eletrosul, auxiliar, 0, config.InterligacaoLayout, false);
                    }

                    if (!apagar)
                    {
                        continue;
                    }

                    entidade.UpgradeOpen();
                    entidade.Erase();
                    entidade.DowngradeOpen();
                    resultado.Apagados++;
                    if (entidade is DBText)
                    {
                        resultado.TextosApagados++;
                    }
                    else
                    {
                        resultado.OrnamentosApagados++;
                    }
                }

                transacao.Commit();
            }

            return resultado;
        }

        private static bool TemXData(Entity entidade, string appName)
        {
            return entidade.GetXDataForApplication(appName) != null;
        }

        private static IReadOnlyList<TypedXData> LerXData(Entity entidade, string appName)
        {
            ResultBuffer xdata = entidade.GetXDataForApplication(appName);
            return xdata == null ? null : XDataNeutro.Para(xdata);
        }
    }
}

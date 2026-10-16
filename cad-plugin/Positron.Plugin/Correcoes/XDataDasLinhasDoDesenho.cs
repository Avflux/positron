using System.Collections.Generic;
using Positron.Data.Correcoes;
using Positron.Data.Fiacao;
using Positron.Data.Limpeza;
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
    /// <c>correcaoLines</c> — a quarta das cinco correções automáticas do <c>IniciarDWG</c>
    /// (<c>Correcao.cs:480-557</c>): a <c>Line</c> que carrega o XData <c>CONEXAO</c> ou o
    /// <c>INTERLIGACAO</c> (resto de uma versão antiga, que gravava o trecho na linha) perde o XData
    /// pelo <c>LimpaXData</c> do original — o buffer vira um **registro único** com o próprio app
    /// name, o mesmo quirk que o <c>apagaXDataTerceiros</c> e o <c>LimpaTextosLPCopiados</c> já
    /// reproduzem (<see cref="LimpezaDoDesenho.MarcaUnica"/>).
    ///
    /// A decisão é pura (<see cref="CorrecaoXDataDasLinhas"/>); aqui varre-se o ModelSpace e grava-se.
    /// </summary>
    internal static class XDataDasLinhasDoDesenho
    {
        internal sealed class Resultado
        {
            /// <summary><c>Line</c> do ModelSpace lidas.</summary>
            internal int LinhasLidas { get; set; }

            /// <summary>Linhas que perderam o XData (a conta que o resumo do <c>IniciarDWG</c> mostra).</summary>
            internal int LinhasLimpas { get; set; }

            /// <summary>Quantas foram limpas pelo <c>CONEXAO</c>.</summary>
            internal int ConexaoLimpos { get; set; }

            /// <summary>Quantas foram limpas pelo <c>INTERLIGACAO</c>.</summary>
            internal int InterligacaoLimpos { get; set; }
        }

        internal static Resultado Executar()
        {
            Resultado resultado = new Resultado();

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return resultado;
            }

            Database banco = documento.Database;
            using (documento.LockDocument())
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                bool temConexaoRegistrado = TemRegApp(transacao, banco, CorrecaoXDataDasLinhas.Conexao);
                bool temInterligacaoRegistrado = TemRegApp(transacao, banco, CorrecaoXDataDasLinhas.Interligacao);

                BlockTableRecord espaco = Bornes.BornesDaCorrecao.EspacoDeModelo(transacao, banco, OpenMode.ForRead);
                foreach (ObjectId id in espaco)
                {
                    Line linha = transacao.GetObject(id, OpenMode.ForRead) as Line;
                    if (linha == null)
                    {
                        continue;
                    }

                    resultado.LinhasLidas++;

                    // O original só tenta limpar o app name que está na tabela `APPID` (`Has` antes do
                    // `LimpaXData`) — sem o registro não há XData nenhum desse app para limpar.
                    bool conexao = temConexaoRegistrado
                        && linha.GetXDataForApplication(CorrecaoXDataDasLinhas.Conexao) != null;
                    bool interligacao = !conexao && temInterligacaoRegistrado
                        && linha.GetXDataForApplication(CorrecaoXDataDasLinhas.Interligacao) != null;

                    string app = CorrecaoXDataDasLinhas.QualLimpar(conexao, interligacao);
                    if (app == null)
                    {
                        continue;
                    }

                    IReadOnlyList<TypedXData> marca = LimpezaDoDesenho.MarcaUnica(app);
                    linha.UpgradeOpen();
                    linha.XData = XDataNeutro.ParaResultBuffer(marca);

                    resultado.LinhasLimpas++;
                    if (app == CorrecaoXDataDasLinhas.Conexao)
                    {
                        resultado.ConexaoLimpos++;
                    }
                    else
                    {
                        resultado.InterligacaoLimpos++;
                    }
                }

                transacao.Commit();
            }

            return resultado;
        }

        private static bool TemRegApp(Transaction transacao, Database banco, string appName)
        {
            RegAppTable tabela = transacao.GetObject(banco.RegAppTableId, OpenMode.ForRead) as RegAppTable;
            return tabela != null && tabela.Has(appName);
        }
    }
}

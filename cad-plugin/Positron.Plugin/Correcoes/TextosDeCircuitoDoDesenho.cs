using Positron.Data.Correcoes;
using Positron.Data.Fiacao;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
#endif

namespace Positron.Plugin.Correcoes
{
    /// <summary>
    /// <c>correcaoTextosCircuitos</c> — a terceira das cinco correções automáticas do
    /// <c>IniciarDWG</c>: o texto auxiliar de circuito (<c>DBText</c> com o XData <c>AUXCONEXAO</c>
    /// tipo 1) que ficou com o <c>VerticalMode</c> em <c>1</c> vira **Baseline na mesma posição**
    /// (<c>Position = AlignmentPoint</c>), como o original (<c>Correcao.cs:397-477</c>).
    ///
    /// A decisão é pura (<see cref="CorrecaoDoTextoDeCircuito"/>); aqui varre-se o ModelSpace e
    /// escreve-se, dentro do <c>LockDocument</c> e da transação única do original.
    /// </summary>
    internal static class TextosDeCircuitoDoDesenho
    {
        internal sealed class Resultado
        {
            /// <summary><c>DBText</c> do ModelSpace com o XData <c>AUXCONEXAO</c> legível.</summary>
            internal int TextosAuxiliares { get; set; }

            /// <summary>Textos com o <c>AUXCONEXAO</c> tipo 1 e o modo vertical errado (regravados).</summary>
            internal int TextosCorrigidos { get; set; }
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
                BlockTableRecord espaco = Bornes.BornesDaCorrecao.EspacoDeModelo(transacao, banco, OpenMode.ForRead);
                foreach (ObjectId id in espaco)
                {
                    DBText texto = transacao.GetObject(id, OpenMode.ForRead) as DBText;
                    if (texto == null)
                    {
                        continue;
                    }

                    short tipo;
                    int potencial;
                    string handle;
                    if (!AuxConexaoXData.Ler(
                        XDataNeutro.Para(texto.GetXDataForApplication(AuxConexaoXData.AppName)),
                        out tipo,
                        out potencial,
                        out handle))
                    {
                        continue;
                    }

                    resultado.TextosAuxiliares++;

                    if (!CorrecaoDoTextoDeCircuito.PrecisaCorrigir(tipo, (int)texto.VerticalMode))
                    {
                        continue;
                    }

                    // A ordem do original: guarda o ponto de alinhamento, volta o modo para Baseline e
                    // devolve o ponto como `Position` (é o `Position` que vale fora do Baseline).
                    Point3d alinhamento = texto.AlignmentPoint;
                    texto.UpgradeOpen();
                    texto.VerticalMode = (TextVerticalMode)CorrecaoDoTextoDeCircuito.VerticalModeAlinhado;
                    texto.Position = alinhamento;
                    resultado.TextosCorrigidos++;
                }

                transacao.Commit();
            }

            return resultado;
        }
    }
}

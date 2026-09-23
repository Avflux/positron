using System.Collections.Generic;
using Positron.Data.Fiacao;
using Positron.Data.Interligacao;
using Positron.Data.Limpeza;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
#endif

namespace Positron.Plugin.Limpeza
{
    /// <summary>
    /// <c>apagarTodosOsTextosDasVeias</c> — a quinta ação de limpeza da frente 2 do
    /// §7.6 (o <c>Correcao.cs</c> do reverso): apaga do ModelSpace os **rótulos
    /// auxiliares** das veias.
    ///
    /// São dois ramos, como no original: qualquer entidade com o XData
    /// <c>ELETROSUL</c> (a variante da Eletrosul, que o original apaga sem olhar o
    /// tipo) e o <c>DBText</c> com <c>AUXINTERLIG</c> do tipo 1. A regra é pura e
    /// está em <see cref="LimpezaDoDesenho.ApagarRotuloAuxiliar"/>; aqui só se varre
    /// o ModelSpace e se apaga.
    ///
    /// **Só o desenho:** não lê banco nem cadastro, como as outras quatro.
    /// </summary>
    internal static class TextosDasVeiasDoDesenho
    {
        internal sealed class Resultado
        {
            /// <summary>Entidades varridas no ModelSpace.</summary>
            internal int EntidadesLidas { get; set; }

            /// <summary>Entidades com XData <c>AUXINTERLIG</c> válido (qualquer tipo).</summary>
            internal int RotulosAuxiliares { get; set; }

            /// <summary>Entidades com XData <c>ELETROSUL</c> válido.</summary>
            internal int RotulosEletrosul { get; set; }

            /// <summary>Entidades apagadas.</summary>
            internal int Apagados { get; set; }
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
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTableRecord espaco = EspacoDeModelo(transacao, banco);

                foreach (ObjectId id in espaco)
                {
                    Entity entidade = transacao.GetObject(id, OpenMode.ForRead) as Entity;
                    if (entidade == null)
                    {
                        continue;
                    }

                    resultado.EntidadesLidas++;

                    short tipo = 0;
                    bool temAuxiliar = AuxInterligacaoXData.Ler(
                        Ler(entidade, AuxInterligacaoXData.AppName), out tipo);

                    string handle;
                    bool temEletrosul = AuxInterligacaoEletrosulXData.Ler(
                        Ler(entidade, AuxInterligacaoEletrosulXData.AppName), out handle);

                    if (temAuxiliar)
                    {
                        resultado.RotulosAuxiliares++;
                    }

                    if (temEletrosul)
                    {
                        resultado.RotulosEletrosul++;
                    }

                    if (!LimpezaDoDesenho.ApagarRotuloAuxiliar(entidade is DBText, temEletrosul, tipo))
                    {
                        continue;
                    }

                    entidade.UpgradeOpen();
                    entidade.Erase();
                    entidade.DowngradeOpen();
                    resultado.Apagados++;
                }

                transacao.Commit();
            }

            return resultado;
        }

        private static IReadOnlyList<TypedXData> Ler(Entity entidade, string appName)
        {
            ResultBuffer xdata = entidade.GetXDataForApplication(appName);
            return xdata == null ? null : XDataNeutro.Para(xdata);
        }

        private static BlockTableRecord EspacoDeModelo(Transaction transacao, Database banco)
        {
            BlockTable tabela = (BlockTable)transacao.GetObject(banco.BlockTableId, OpenMode.ForRead);
            return (BlockTableRecord)transacao.GetObject(tabela[BlockTableRecord.ModelSpace], OpenMode.ForRead);
        }
    }
}

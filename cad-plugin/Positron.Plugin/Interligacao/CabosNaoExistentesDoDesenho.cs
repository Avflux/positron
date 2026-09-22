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
    /// A parte do fluxo de interligação que **grava** no desenho: a ação
    /// <c>IndefineCabosNaoExistentes</c> do <c>clsVerificadorProjetoInterligacao</c>
    /// (o botão "Corrigir" da tela de verificação, não uma checagem).
    ///
    /// Duas transações, como o original:
    /// 1. as <c>LWPOLYLINE</c> de interligação cujo <c>Tag_Cabo</c> não está no
    ///    catálogo perdem o cabo (<see cref="InterligacaoXData.IndefinirCabo"/>) e o
    ///    XData é regravado (<see cref="InterligacaoXData.ParaValores"/>);
    /// 2. os rótulos auxiliares (<c>DBText</c> com XData <c>AUXINTERLIG</c> do tipo
    ///    do cabo) recebem o caracter de terminal indefinido.
    ///
    /// A decisão de quais trechos indefinir é pura (<see cref="AcaoIndefinirCabos"/>);
    /// aqui só se varre o ModelSpace e se escreve.
    /// </summary>
    internal static class CabosNaoExistentesDoDesenho
    {
        internal sealed class Resultado
        {
            /// <summary>Trechos de interligação lidos do desenho (XData válido).</summary>
            internal int TrechosLidos { get; set; }

            /// <summary>Trechos indefinidos (XData parcialmente regravado).</summary>
            internal int TrechosIndefinidos { get; set; }

            /// <summary>Rótulos auxiliares lidos (XData <c>AUXINTERLIG</c>).</summary>
            internal int RotulosLidos { get; set; }

            /// <summary>Rótulos do cabo que receberam o caracter indefinido.</summary>
            internal int RotulosIndefinidos { get; set; }
        }

        /// <summary>
        /// Executa a ação com o catálogo informado. O catálogo vazio não faz nada
        /// (<see cref="AcaoIndefinirCabos.Planejar"/> explica por quê).
        /// </summary>
        internal static Resultado Executar(IReadOnlyCollection<string> catalogo)
        {
            Resultado resultado = new Resultado();

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return resultado;
            }

            Database banco = documento.Database;

            List<InterligacaoXData> trechos = new List<InterligacaoXData>();
            List<Polyline> entidades = new List<Polyline>();

            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTableRecord espaco = EspacoDeModelo(transacao, banco, OpenMode.ForRead);

                foreach (ObjectId id in espaco)
                {
                    Polyline linha = transacao.GetObject(id, OpenMode.ForRead) as Polyline;
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

                    trechos.Add(ilig);
                    entidades.Add(linha);
                }

                resultado.TrechosLidos = trechos.Count;

                List<string> tags = new List<string>(trechos.Count);
                foreach (InterligacaoXData trecho in trechos)
                {
                    tags.Add(trecho.Tag_Cabo);
                }

                IReadOnlyList<int> indefinidos = AcaoIndefinirCabos.Planejar(tags, catalogo);
                if (indefinidos.Count > 0)
                {
                    GarantirAppName(transacao, banco, InterligacaoXData.AppName);
                    foreach (int indice in indefinidos)
                    {
                        InterligacaoXData trecho = trechos[indice];
                        trecho.IndefinirCabo();

                        DBObject objeto = entidades[indice];
                        objeto.UpgradeOpen();
                        objeto.XData = ParaResultBuffer(trecho.ParaValores(
                            System.Environment.UserName,
                            System.DateTime.Now.ToString()));

                        resultado.TrechosIndefinidos++;
                    }
                }

                transacao.Commit();
            }

            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTableRecord espaco = EspacoDeModelo(transacao, banco, OpenMode.ForRead);

                foreach (ObjectId id in espaco)
                {
                    DBText rotulo = transacao.GetObject(id, OpenMode.ForRead) as DBText;
                    if (rotulo == null)
                    {
                        continue;
                    }

                    ResultBuffer xdata = ((DBObject)rotulo).GetXDataForApplication(AuxInterligacaoXData.AppName);
                    if (xdata == null)
                    {
                        continue;
                    }

                    short tipo;
                    if (!AuxInterligacaoXData.Ler(XDataNeutro.Para(xdata), out tipo))
                    {
                        continue;
                    }

                    resultado.RotulosLidos++;

                    if (!AcaoIndefinirCabos.RotuloEhDoCabo(tipo))
                    {
                        continue;
                    }

                    ((DBObject)rotulo).UpgradeOpen();
                    rotulo.TextString = AcaoIndefinirCabos.TerminalIndefinido;
                    resultado.RotulosIndefinidos++;
                }

                transacao.Commit();
            }

            return resultado;
        }

        private static BlockTableRecord EspacoDeModelo(Transaction transacao, Database banco, OpenMode modo)
        {
            BlockTable tabela = (BlockTable)transacao.GetObject(banco.BlockTableId, modo);
            return (BlockTableRecord)transacao.GetObject(tabela[BlockTableRecord.ModelSpace], modo);
        }

        private static ResultBuffer ParaResultBuffer(IReadOnlyList<TypedXData> valores)
        {
            TypedValue[] array = new TypedValue[valores.Count];
            for (int i = 0; i < valores.Count; i++)
            {
                array[i] = new TypedValue(valores[i].Codigo, valores[i].Valor);
            }

            return new ResultBuffer(array);
        }

        /// <summary>
        /// Registra o app name antes de escrever, como o <c>AtualizaXDataInterligacao</c>
        /// do original. Na prática ele já existe (só mexemos em entidade que **tinha**
        /// o XData), mas regravar com o nome não registrado lança dentro do CAD.
        /// </summary>
        private static void GarantirAppName(Transaction transacao, Database banco, string appName)
        {
            SymbolTable tabela = (SymbolTable)transacao.GetObject(banco.RegAppTableId, OpenMode.ForWrite);
            if (tabela.Has(appName))
            {
                return;
            }

            RegAppTableRecord registro = new RegAppTableRecord();
            registro.Name = appName;
            tabela.Add(registro);
            transacao.AddNewlyCreatedDBObject(registro, true);
        }
    }
}

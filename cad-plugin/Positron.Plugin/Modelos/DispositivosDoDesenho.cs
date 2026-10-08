using System.Collections.Generic;
using System.Text;
using Positron.Data.Modelos;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
#endif

namespace Positron.Plugin.Modelos
{
    /// <summary>
    /// Varre os blocos de **dispositivo** do ModelSpace (XData <c>Dispositivo</c>
    /// tipo <c>"P"</c>) — o <c>clsDispositivoTacito.carregaModelosUsadosBobinas</c>
    /// e o <c>carregaTerminaisBobinas</c> do original.
    ///
    /// Os terminais das bobinas são os **atributos** do bloco cujo tag é
    /// <c>T&lt;número&gt;</c> (<c>clsDispositivo.BuscaTerminaisTipoTdoBloco</c>),
    /// concatenados com <c>;</c>.
    /// </summary>
    public static class DispositivosDoDesenho
    {
        public sealed class Dispositivos
        {
            /// <summary>Índices de modelo em uso (não complementares).</summary>
            public List<int> Modelos { get; set; }

            /// <summary>Painéis onde há dispositivo.</summary>
            public List<int> Paineis { get; set; }

            /// <summary>Terminais de bobina por índice de modelo, concatenados com <c>;</c>.</summary>
            public Dictionary<int, string> TerminaisBobinas { get; set; }
        }

        public static Dispositivos Ler()
        {
            Dispositivos dispositivo = new Dispositivos
            {
                Modelos = new List<int>(),
                Paineis = new List<int>(),
                TerminaisBobinas = new Dictionary<int, string>(),
            };

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return dispositivo;
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
                    BlockReference bloco = transacao.GetObject(id, OpenMode.ForRead) as BlockReference;
                    if (bloco == null)
                    {
                        continue;
                    }

                    ResultBuffer xdata = bloco.GetXDataForApplication(DispositivoXData.AppName);
                    if (xdata == null)
                    {
                        continue;
                    }

                    DispositivoXData dado;
                    if (!DispositivoXData.Ler(XDataNeutro.Para(xdata), out dado))
                    {
                        continue;
                    }

                    if (dado.Complementar || dado.IndexModelo <= 0)
                    {
                        continue;
                    }

                    if (!dispositivo.Paineis.Contains(dado.Painel))
                    {
                        dispositivo.Paineis.Add(dado.Painel);
                    }

                    if (!dispositivo.Modelos.Contains(dado.IndexModelo))
                    {
                        dispositivo.Modelos.Add(dado.IndexModelo);
                    }

                    // O original usa o último bloco encontrado para o modelo.
                    dispositivo.TerminaisBobinas[dado.IndexModelo] = TerminaisT(transacao, bloco);
                }

                transacao.Commit();
            }

            return dispositivo;
        }

        /// <summary>Atributos <c>T&lt;número&gt;</c> do bloco, concatenados com <c>;</c>.</summary>
        private static string TerminaisT(Transaction transacao, BlockReference bloco)
        {
            StringBuilder texto = new StringBuilder();
            foreach (ObjectId id in bloco.AttributeCollection)
            {
                AttributeReference atributo = transacao.GetObject(id, OpenMode.ForRead) as AttributeReference;
                if (atributo == null)
                {
                    continue;
                }

                string tag = atributo.Tag;
                if (tag.Length > 1 && tag[0] == 'T' && EhNumero(tag.Substring(1)))
                {
                    texto.Append(atributo.TextString).Append(';');
                }
            }

            return texto.ToString();
        }

        private static bool EhNumero(string texto)
        {
            if (texto.Length == 0)
            {
                return false;
            }

            foreach (char c in texto)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }

            return true;
        }
    }
}

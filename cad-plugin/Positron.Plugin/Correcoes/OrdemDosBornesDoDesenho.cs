using System;
using System.Collections.Generic;
using Positron.Data.Bornes;
using Positron.Data.Correcoes;
using Positron.Data.Fiacao;
using Positron.Plugin.Bornes;
using Positron.Plugin.Modelos;
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
    /// A parte do <c>corrigeOrdemBornes</c> que toca o desenho (frente 2 do §7.6):
    /// varre os bornes do ModelSpace, decide a nova ordem com a regra pura
    /// (<see cref="CorrecaoOrdemBornes"/>) e regrava o XData dos que mudam — o
    /// mesmo caminho de escrita do original
    /// (<c>XDataDispositivosMaster.GravarXDataDispBorne</c>), que **também resolve
    /// o <c>lm</c>** quando ele está zerado.
    ///
    /// Três fases, como o original: uma transação para ler os bornes, as leituras
    /// do dicionário <c>CENG_BORNES</c> (uma por régua, com cache) para planejar, e
    /// uma transação para gravar.
    /// </summary>
    internal static class OrdemDosBornesDoDesenho
    {
        internal sealed class Resultado
        {
            /// <summary>Bornes do desenho (blocos <c>B</c> com XData válido).</summary>
            internal int BornesLidos { get; set; }

            /// <summary>Bornes cuja ordem mudou e foram regravados.</summary>
            internal int BornesAjustados { get; set; }

            /// <summary>Bornes que ganharam o <c>lm</c> do dicionário de réguas na regravação.</summary>
            internal int LmResolvidos { get; set; }
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

            List<BorneDeOrdem> bornes = new List<BorneDeOrdem>();
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTableRecord espaco = BornesDaCorrecao.EspacoDeModelo(transacao, banco, OpenMode.ForRead);
                foreach (ObjectId id in espaco)
                {
                    BlockReference bloco = transacao.GetObject(id, OpenMode.ForRead) as BlockReference;
                    if (bloco == null)
                    {
                        continue;
                    }

                    IReadOnlyList<TypedXData> valores = BornesDaCorrecao.LerXData(bloco);
                    BorneXData borne;
                    if (valores == null || !BorneXData.Ler(valores, out borne))
                    {
                        continue;
                    }

                    bornes.Add(new BorneDeOrdem
                    {
                        Handle = bloco.Handle.ToString(),
                        IndiceRegua = borne.IndiceRegua,
                        Ordem = borne.Ordem,
                    });
                }

                transacao.Commit();
            }

            resultado.BornesLidos = bornes.Count;
            if (bornes.Count == 0)
            {
                return resultado;
            }

            // As ordens das reservas, por régua, com cache: o original relê o
            // dicionário toda vez que o índice da régua muda.
            Dictionary<int, IReadOnlyList<int>> reservas = new Dictionary<int, IReadOnlyList<int>>();
            IReadOnlyList<CorrecaoOrdemBornes.Ajuste> ajustes = CorrecaoOrdemBornes.Planejar(
                bornes,
                indice =>
                {
                    IReadOnlyList<int> lista;
                    if (!reservas.TryGetValue(indice, out lista))
                    {
                        lista = BornesReservaDoDesenho.LerOrdensReservadas(indice);
                        reservas[indice] = lista;
                    }

                    return lista;
                });

            ReguasModelo reguas = ReguasDoDesenho.Ler();
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                foreach (CorrecaoOrdemBornes.Ajuste ajuste in ajustes)
                {
                    BlockReference bloco = BornesDaCorrecao.AbrirPorHandle(transacao, banco, ajuste.Handle);
                    if (bloco == null)
                    {
                        continue;
                    }

                    // O original relê o borne antes de gravar e só grava se a ordem
                    // ainda difere (protege contra o desenho ter mudado no meio).
                    IReadOnlyList<TypedXData> valores = BornesDaCorrecao.LerXData(bloco);
                    BorneXData borne;
                    if (valores == null || !BorneXData.Ler(valores, out borne) || borne.Ordem == ajuste.OrdemNova)
                    {
                        continue;
                    }

                    borne.Ordem = ajuste.OrdemNova;

                    // `GravarXDataDispBorne`: com `lm` zerado, o valor sai do que a
                    // régua define para o tipo do borne.
                    if (borne.Lm == 0)
                    {
                        int lm = reguas.BuscarLm(borne.IndiceRegua, borne.Tipo);
                        if (lm != 0)
                        {
                            borne.Lm = lm;
                            resultado.LmResolvidos++;
                        }
                    }

                    BornesDaCorrecao.GarantirAppName(transacao, banco, BorneXData.AppName);
                    DBObject objeto = bloco;
                    objeto.UpgradeOpen();
                    objeto.XData = BornesDaCorrecao.ParaResultBuffer(borne.ParaValores(
                        Environment.UserName,
                        DateTime.Now.ToString()));

                    resultado.BornesAjustados++;
                }

                transacao.Commit();
            }

            return resultado;
        }
    }
}

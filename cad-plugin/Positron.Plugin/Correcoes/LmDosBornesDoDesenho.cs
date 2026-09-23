using System.Collections.Generic;
using Positron.Data.Bornes;
using Positron.Data.Correcoes;
using Positron.Data.Fiacao;
using Positron.Data.Modelos;
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
    /// <c>SobeLm</c> — **sobe o <c>lm</c> do dicionário de réguas** para o XData
    /// dos bornes: todo borne com <c>lm == 0</c> (o <c>BorneSemLm</c> que o
    /// <c>VERIF</c> aponta) recebe o <c>lm</c> que a régua dele define para o tipo.
    ///
    /// É o par de escrita do defeito de **maior contagem** do desenho real e o
    /// fecho da pendência do §7.2: o valor sai da **régua** — a regra é pura e
    /// mora em <see cref="LmDasReguas"/> (o campo +6/+7 do <c>REGUAS/MODELOS2</c>,
    /// que o <c>BuscaLMdaRegua</c> do original lê, e, quando ele não define, o
    /// dicionário de bornes da régua <c>CENG_BORNES</c>, que é onde o dado existe
    /// de verdade — o gravador do original zera o campo do <c>MODELOS2</c>).
    /// Medido no desenho real (rodada 74): os 119 <c>BorneSemLm</c> são dado
    /// faltando — nenhuma régua deles define <c>lm</c> em nenhuma das duas fontes,
    /// então lá a subida é 0 e o <c>VERIF</c> continua apontando os 119; o caminho
    /// de escrita é provado na fixture sintética (o <c>MODELOS2</c> e o
    /// <c>CENG_BORNES</c> um de cada vez).
    ///
    /// O comando é **próprio do recoder** (o original não tem botão para isso): a
    /// decisão é pura (<see cref="CorrecaoLmBornes"/>) e o que toca o CAD é
    /// varredura do ModelSpace + o mesmo caminho de escrita do
    /// <c>GravarXDataDispBorne</c>.
    /// </summary>
    internal static class LmDosBornesDoDesenho
    {
        internal sealed class Resultado
        {
            /// <summary>Bornes do desenho (blocos <c>B</c> com XData válido).</summary>
            internal int BornesLidos { get; set; }

            /// <summary>Bornes com <c>lm == 0</c> — a população do <c>BorneSemLm</c>.</summary>
            internal int BornesSemLm { get; set; }

            /// <summary>Bornes que ganharam o <c>lm</c> da régua.</summary>
            internal int BornesCorrigidos { get; set; }

            /// <summary>Bornes zerados cuja régua **não** define <c>lm</c> (ficam como estão: é dado faltando).</summary>
            internal int SemDefinicao { get; set; }
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

            List<BorneDeLm> bornes = new List<BorneDeLm>();
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

                    bornes.Add(new BorneDeLm
                    {
                        Handle = bloco.Handle.ToString(),
                        IndiceRegua = borne.IndiceRegua,
                        Tipo = borne.Tipo,
                        Lm = borne.Lm,
                    });
                }

                transacao.Commit();
            }

            resultado.BornesLidos = bornes.Count;
            resultado.BornesSemLm = SemLm(bornes);
            if (resultado.BornesSemLm == 0)
            {
                return resultado;
            }

            ReguasModelo reguas = ReguasDoDesenho.Ler();

            // A segunda fonte do `lm` e o dicionario de bornes da regua
            // (CENG_BORNES), lido **uma vez por regua** - o mesmo cache do
            // corrigeOrdemBornes.
            Dictionary<int, IReadOnlyList<BorneReserva>> reservas =
                new Dictionary<int, IReadOnlyList<BorneReserva>>();
            IReadOnlyList<CorrecaoLmBornes.Ajuste> ajustes = CorrecaoLmBornes.Planejar(
                bornes,
                (indice, tipo) => LmDasReguas.Resolver(reguas, indice, DoDicionario(reservas, indice), tipo));

            resultado.SemDefinicao = resultado.BornesSemLm - ajustes.Count;

            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                foreach (CorrecaoLmBornes.Ajuste ajuste in ajustes)
                {
                    BlockReference bloco = BornesDaCorrecao.AbrirPorHandle(transacao, banco, ajuste.Handle);
                    if (bloco == null)
                    {
                        continue;
                    }

                    // O original relê o borne antes de gravar (o desenho pode ter
                    // mudado no meio); aqui a releitura também protege contra o
                    // mesmo borne já ter sido regravado.
                    IReadOnlyList<TypedXData> valores = BornesDaCorrecao.LerXData(bloco);
                    BorneXData borne;
                    if (valores == null || !BorneXData.Ler(valores, out borne) || borne.Lm != 0)
                    {
                        continue;
                    }

                    borne.Lm = ajuste.Lm;

                    BornesDaCorrecao.GarantirAppName(transacao, banco, BorneXData.AppName);
                    DBObject objeto = bloco;
                    objeto.UpgradeOpen();
                    objeto.XData = BornesDaCorrecao.ParaResultBuffer(borne.ParaValores(
                        System.Environment.UserName,
                        System.DateTime.Now.ToString()));

                    resultado.BornesCorrigidos++;
                }

                transacao.Commit();
            }

            return resultado;
        }

        /// <summary>Os bornes de reserva da regua, com cache (uma leitura do dicionario por regua).</summary>
        private static IReadOnlyList<BorneReserva> DoDicionario(
            Dictionary<int, IReadOnlyList<BorneReserva>> cache,
            int indiceRegua)
        {
            IReadOnlyList<BorneReserva> lista;
            if (!cache.TryGetValue(indiceRegua, out lista))
            {
                lista = BornesReservaDoDesenho.Ler(indiceRegua);
                cache[indiceRegua] = lista;
            }

            return lista;
        }

        private static int SemLm(List<BorneDeLm> bornes)
        {
            int total = 0;
            foreach (BorneDeLm borne in bornes)
            {
                if (borne.Lm == 0)
                {
                    total++;
                }
            }

            return total;
        }
    }
}

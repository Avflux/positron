using System;
using System.Collections.Generic;
using Positron.Contract;
using Positron.Data;
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
    /// <c>CorrigeCabosSingelos</c> — a correção dos cabos **singelos** (frente 2 do
    /// §7.6, o <c>Correcao.cs</c>): lê o catálogo, decide os candidatos com a regra pura
    /// (<see cref="CorrecaoCabosSingelos"/>), **limpa o <c>Nome_Veia</c> no banco** e
    /// depois limpa o <c>NomeVeia</c> do XData dos trechos de interligação com aquele
    /// <c>Tag_Cabo</c>. O comando termina recriando os rótulos (o
    /// <c>RecriaTextosCaboEletrosul</c>, que o original chama sempre).
    ///
    /// Como no original, a varredura do desenho só acontece quando há candidato.
    /// </summary>
    internal static class CabosSingelosDoDesenho
    {
        internal sealed class Resultado
        {
            internal bool SemBanco { get; set; }

            /// <summary>Tags do catálogo com <c>Cabos = 1</c> (a consulta 1).</summary>
            internal int TagsComFlag { get; set; }

            /// <summary>Linhas do catálogo <c>Veias</c> lidas.</summary>
            internal int VeiasLidas { get; set; }

            /// <summary>Tags que passaram na regra (uma veia no arquivo e o <c>#</c> no nome).</summary>
            internal int Candidatos { get; set; }

            /// <summary>Linhas de <c>Veias</c> atualizadas no banco.</summary>
            internal int VeiasLimparNoBanco { get; set; }

            /// <summary>Trechos de interligação varridos no desenho.</summary>
            internal int TrechosLidos { get; set; }

            /// <summary>Trechos cujo <c>NomeVeia</c> foi limpo no XData.</summary>
            internal int TrechosLimpos { get; set; }
        }

        internal static Resultado Executar()
        {
            Resultado resultado = new Resultado();

            ConfiguracaoPositron config = ConfiguracaoPositron.Carregar();
            if (string.IsNullOrEmpty(config.Banco))
            {
                resultado.SemBanco = true;
                return resultado;
            }

            ProjectStore store = new ProjectStore(config.Banco);
            IReadOnlyList<string> tags = store.LerTagsDeCabosComFlag();
            resultado.TagsComFlag = tags.Count;

            IReadOnlyList<VeiasRow> veias = store.LerVeias();
            resultado.VeiasLidas = veias.Count;

            IReadOnlyList<string> candidatos = CorrecaoCabosSingelos.Candidatos(tags, veias, config.Dwg);
            resultado.Candidatos = candidatos.Count;
            if (candidatos.Count == 0)
            {
                return resultado;
            }

            resultado.VeiasLimparNoBanco = store.LimparNomeDeVeiaDasVeias(candidatos);

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return resultado;
            }

            Database banco = documento.Database;
            string usuario = Environment.UserName;
            string data = DateTime.Now.ToString();

            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTable tabela = (BlockTable)transacao.GetObject(banco.BlockTableId, OpenMode.ForRead);
                BlockTableRecord espaco = (BlockTableRecord)transacao.GetObject(
                    tabela[BlockTableRecord.ModelSpace], OpenMode.ForRead);

                foreach (ObjectId id in espaco)
                {
                    Polyline linha = transacao.GetObject(id, OpenMode.ForRead) as Polyline;
                    if (linha == null)
                    {
                        continue;
                    }

                    ResultBuffer xdata = linha.GetXDataForApplication(InterligacaoXData.AppName);
                    InterligacaoXData ilig;
                    if (xdata == null ||
                        !InterligacaoXData.Ler(XDataNeutro.Para(xdata), out ilig))
                    {
                        continue;
                    }

                    resultado.TrechosLidos++;

                    if (CorrecaoCabosSingelos.TrechosParaLimpar(
                            new[] { ilig.Tag_Cabo }, candidatos).Count == 0)
                    {
                        continue;
                    }

                    ilig.NomeVeia = string.Empty;
                    linha.UpgradeOpen();
                    linha.XData = ParaResultBuffer(ilig.ParaValores(usuario, data));
                    resultado.TrechosLimpos++;
                }

                transacao.Commit();
            }

            return resultado;
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
    }
}

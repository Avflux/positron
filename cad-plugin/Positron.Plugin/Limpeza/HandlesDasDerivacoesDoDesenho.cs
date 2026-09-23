using System;
using System.Collections.Generic;
using Positron.Data;
using Positron.Data.Fiacao;
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
    /// <c>Limpahandle</c> — o <c>limpaHandleSuperior</c> do <c>Correcao.cs</c>: zera o
    /// <c>Handle</c> do XData <c>CONEXAO</c> de cada polilinha de **derivação** (tipo 3).
    ///
    /// A gravação troca **um valor** do registro <c>CONEXAO</c> dentro do buffer da
    /// polilinha (o <c>Handle</c> é o terceiro valor, <c>valores[3]</c> do leitor),
    /// preservando os outros app names — mesma técnica da rodada 86. O gate de hardlock
    /// do original (<c>CADGRAPH</c>) não existe no recoder e é registrado como fora do
    /// recorte.
    /// </summary>
    internal static class HandlesDasDerivacoesDoDesenho
    {
        /// <summary>O índice do <c>Handle</c> dentro do registro do app (o <c>valores[3]</c>).</summary>
        private const int IndiceDoHandle = 2;

        internal sealed class Resultado
        {
            /// <summary>Polilinhas com XData <c>CONEXAO</c> lidas.</summary>
            internal int ConexoesLidas { get; set; }

            /// <summary>Derivações (tipo 3) encontradas.</summary>
            internal int Derivacoes { get; set; }

            /// <summary>Derivações com o handle zerado.</summary>
            internal int HandlesLimpos { get; set; }
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

                    ResultBuffer xdata = linha.GetXDataForApplication(ConexaoXData.AppName);
                    ConexaoXData conexao;
                    if (xdata == null || !ConexaoXData.Ler(XDataNeutro.Para(xdata), out conexao))
                    {
                        continue;
                    }

                    resultado.ConexoesLidas++;
                    if (!LimpezaDoHandleDasDerivacoes.EhDerivacao(conexao.Tipo))
                    {
                        continue;
                    }

                    resultado.Derivacoes++;
                    if (!LimpezaDoHandleDasDerivacoes.PrecisaLimpar(conexao.Handle))
                    {
                        continue;
                    }

                    linha.UpgradeOpen();
                    linha.XData = ParaResultBuffer(TrocandoOHandle(linha.XData, string.Empty));
                    resultado.HandlesLimpos++;
                }

                transacao.Commit();
            }

            return resultado;
        }

        /// <summary>
        /// Troca o <c>Handle</c> do registro <c>CONEXAO</c> no buffer inteiro da
        /// polilinha, preservando os outros app names.
        /// </summary>
        private static IReadOnlyList<TypedXData> TrocandoOHandle(ResultBuffer todos, string handle)
        {
            List<TypedXData> saida = new List<TypedXData>();
            IReadOnlyList<TypedXData> valores = todos == null ? null : XDataNeutro.Para(todos);
            if (valores == null)
            {
                return saida;
            }

            int i = 0;
            while (i < valores.Count)
            {
                bool ehConexao = valores[i].Codigo == 1001 &&
                    string.Equals(valores[i].Valor as string, ConexaoXData.AppName, StringComparison.Ordinal);
                if (!ehConexao)
                {
                    saida.Add(valores[i]);
                    i++;
                    continue;
                }

                saida.Add(valores[i]);
                i++;
                int k = 0;
                while (i < valores.Count && valores[i].Codigo != 1001)
                {
                    saida.Add(k == IndiceDoHandle ? new TypedXData(valores[i].Codigo, handle) : valores[i]);
                    k++;
                    i++;
                }
            }

            return saida;
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

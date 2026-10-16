using System;
using System.Collections.Generic;
using Positron.Data.Correcoes;
using Positron.Data.Fiacao;
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
    /// O I/O do XData <c>CORRECAO</c> no **ModelSpace**: as marcas das cinco correções automáticas do
    /// <c>IniciarDWG</c>. A regra (o layout do buffer e as duas decisões) é pura:
    /// <see cref="MarcasDeCorrecao"/>.
    ///
    /// O original (<c>XDataCorrecao.LerCorrecao</c>/<c>setaCorrecao</c>) abre o <c>LockDocument</c> e
    /// grava o buffer inteiro no ModelSpace a cada marca. Aqui o mesmo efeito pela via que o
    /// <c>ConfiguracaoDoDesenho</c> já usa (rodada 180): o bloco do app name <c>CORRECAO</c> é
    /// substituído no XData do ModelSpace e os blocos de **outros** app names (<c>Eletron</c>,
    /// <c>EletronProj</c>, terceiros) ficam intactos — a regra do <c>setXData</c> do CAD, que o
    /// original herda ao atribuir <c>XData</c>.
    /// </summary>
    internal static class MarcasDeCorrecaoDoDesenho
    {
        /// <summary>
        /// O <c>XDataCorrecao.LerCorrecao(numero)</c>: o desenho já rodou a correção.
        /// </summary>
        internal static bool Lida(int numero)
        {
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return false;
            }

            Database banco = documento.Database;
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTableRecord espaco = Bornes.BornesDaCorrecao.EspacoDeModelo(transacao, banco, OpenMode.ForRead);
                bool lida = MarcasDeCorrecao.Lida(LerDoEspaco(espaco), numero);
                transacao.Commit();
                return lida;
            }
        }

        /// <summary>
        /// O <c>XDataCorrecao.setaCorrecao(numero)</c>: grava a marca da correção. Devolve <c>false</c>
        /// quando não há documento ativo.
        /// </summary>
        internal static bool Marcar(int numero)
        {
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return false;
            }

            Database banco = documento.Database;

            // Como no original (o `DocumentLock` do `setaCorrecao`): a correção roda no `IniciarDWG`, e
            // a marca é uma escrita no desenho.
            using (documento.LockDocument())
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTableRecord espaco = Bornes.BornesDaCorrecao.EspacoDeModelo(transacao, banco, OpenMode.ForWrite);
                IReadOnlyList<TypedXData> marcados = MarcasDeCorrecao.Marcar(LerDoEspaco(espaco), numero);

                Bornes.BornesDaCorrecao.GarantirAppName(transacao, banco, MarcasDeCorrecao.AppName);

                List<TypedValue> buffer = new List<TypedValue>();
                ResultBuffer atual = espaco.XData;
                if (atual != null)
                {
                    foreach (TypedValue valor in atual.AsArray())
                    {
                        buffer.Add(valor);
                    }
                }

                RemoverApp(buffer, MarcasDeCorrecao.AppName);
                foreach (TypedXData valor in marcados)
                {
                    buffer.Add(new TypedValue(valor.Codigo, valor.Valor));
                }

                espaco.XData = new ResultBuffer(buffer.ToArray());
                transacao.Commit();
            }

            return true;
        }

        private static IReadOnlyList<TypedXData> LerDoEspaco(BlockTableRecord espaco)
        {
            return XDataNeutro.Para(espaco.GetXDataForApplication(MarcasDeCorrecao.AppName));
        }

        /// <summary>
        /// Tira do buffer o bloco do app name pedido: o `1001` e todos os valores até o próximo `1001`
        /// (o XData é uma sequência de blocos, um por app) — o mesmo do <c>ConfiguracaoDoDesenho</c>.
        /// </summary>
        private static void RemoverApp(List<TypedValue> buffer, string appName)
        {
            int i = 0;
            while (i < buffer.Count)
            {
                if (buffer[i].TypeCode != 1001
                    || !string.Equals(Convert.ToString(buffer[i].Value), appName, StringComparison.OrdinalIgnoreCase))
                {
                    i++;
                    continue;
                }

                int fim = i + 1;
                while (fim < buffer.Count && buffer[fim].TypeCode != 1001)
                {
                    fim++;
                }

                buffer.RemoveRange(i, fim - i);
            }
        }
    }
}

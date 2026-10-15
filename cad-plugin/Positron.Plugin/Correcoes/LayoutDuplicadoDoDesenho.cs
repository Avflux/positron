using System;
using System.Collections.Generic;
using Positron.Data;
using Positron.Data.Configuracao;
using Positron.Data.Correcoes;
using Positron.Data.Fiacao;
using Positron.Data.Layout;
using Positron.Plugin.Layout;
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
    /// <c>REMLAYDUP</c> — o <c>RemoveDuplicadoLayoutRapido</c> do <c>Correcao.cs</c>:
    /// reescreve os XRecords <c>CENG_LAYOUT</c> das chaves <c>P</c> e <c>C</c> de cada
    /// painel **do cadastro**, sem os tags repetidos (frente 2 do §7.6).
    ///
    /// A regra está em <see cref="CorrecaoLayoutDuplicado.RemoverDuplicados"/> (o
    /// primeiro de cada tag fica e o **último registro é descartado**). Aqui se lê o
    /// dicionário nomeado, se aplica a regra e se regrava **só o que muda** — o
    /// original apaga e recria o registro a cada passada.
    /// </summary>
    internal static class LayoutDuplicadoDoDesenho
    {
        private const string DicionarioLayout = "CENG_LAYOUT";

        internal sealed class Resultado
        {
            internal bool SemBanco { get; set; }

            /// <summary>Painéis do cadastro (<c>Paineis</c>) percorridos.</summary>
            internal int Paineis { get; set; }

            /// <summary>Chaves <c>P</c>/<c>C</c> encontradas no dicionário.</summary>
            internal int ChavesLidas { get; set; }

            /// <summary>Chaves regravadas.</summary>
            internal int ChavesAlteradas { get; set; }

            internal int RegistrosAntes { get; set; }

            internal int RegistrosDepois { get; set; }
        }

        internal static Resultado Executar()
        {
            Resultado resultado = new Resultado();

            ConfiguracaoPositron config = ConfiguracaoEfetiva.Carregar();
            if (string.IsNullOrEmpty(config.Banco))
            {
                resultado.SemBanco = true;
                return resultado;
            }

            ProjectStore store = new ProjectStore(config.Banco);
            IReadOnlyCollection<int> paineis = store.LerIndicesDePaineis();
            resultado.Paineis = paineis.Count;

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return resultado;
            }

            Database banco = documento.Database;
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                DBDictionary raiz = transacao.GetObject(
                    banco.NamedObjectsDictionaryId, OpenMode.ForRead) as DBDictionary;
                if (raiz == null || !raiz.Contains(DicionarioLayout))
                {
                    transacao.Commit();
                    return resultado;
                }

                DBDictionary layout = transacao.GetObject(
                    raiz.GetAt(DicionarioLayout), OpenMode.ForRead) as DBDictionary;
                if (layout == null)
                {
                    transacao.Commit();
                    return resultado;
                }

                foreach (int painel in paineis)
                {
                    CorrigirChave(layout, transacao, "P", painel, resultado);
                    CorrigirChave(layout, transacao, "C", painel, resultado);
                }

                transacao.Commit();
            }

            return resultado;
        }

        private static void CorrigirChave(
            DBDictionary layout,
            Transaction transacao,
            string pos,
            int painel,
            Resultado resultado)
        {
            string chave = pos + painel;
            if (!layout.Contains(chave))
            {
                return;
            }

            resultado.ChavesLidas++;

            Xrecord registro = transacao.GetObject(layout.GetAt(chave), OpenMode.ForRead) as Xrecord;
            if (registro == null)
            {
                return;
            }

            IReadOnlyList<TypedXData> valores = registro.Data == null
                ? new List<TypedXData>()
                : XDataNeutro.Para(registro.Data);
            IReadOnlyList<LayoutPosicoes.PosicaoBruta> antes = LayoutPosicoes.LerBruto(valores);
            IReadOnlyList<LayoutPosicoes.PosicaoBruta> depois =
                CorrecaoLayoutDuplicado.RemoverDuplicados(antes);

            resultado.RegistrosAntes += antes.Count;
            if (!CorrecaoLayoutDuplicado.PrecisaRegravar(antes, depois))
            {
                resultado.RegistrosDepois += antes.Count;
                return;
            }

            registro.UpgradeOpen();
            registro.Data = ParaResultBuffer(LayoutPosicoes.ParaValores(depois));
            resultado.ChavesAlteradas++;
            resultado.RegistrosDepois += depois.Count;
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

using System;
using System.Collections.Generic;
using System.Globalization;
using Positron.Data.Correcoes;
using Positron.Data.Fiacao;
using Positron.Data.Modelos;
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
    /// <c>corrigeDicMascaras</c> — normaliza a **lista de portas** de cada modelo de
    /// máscara no dicionário <c>MASCARAS</c> do desenho (frente 2 do §7.6, o
    /// <c>Correcao.cs</c>). É o par de escrita do <c>bt13ReguaMascara</c> (rodada 52),
    /// que aponta a régua da máscara a partir desse mesmo registro.
    ///
    /// O que é regra está em <see cref="CorrecaoPortasDaMascara"/> (dedup por índice,
    /// ordem crescente e o <c>MaxIndice</c> recalculado); aqui só se lê o dicionário e
    /// se regrava o XRecord de cada modelo.
    ///
    /// **Diferença de propósito:** o original regrava o registro de **todo** modelo,
    /// sempre. Aqui o registro só é escrito quando os valores **mudam** — assim a
    /// segunda passada converge e o desenho não é tocado à toa (o mesmo critério das
    /// correções das rodadas 71/72).
    /// </summary>
    internal static class PortasDaMascaraDoDesenho
    {
        internal sealed class Resultado
        {
            /// <summary>Modelos de máscara lidos da lista <c>MASCARAS/MODELOS2</c>.</summary>
            internal int ModelosLidos { get; set; }

            /// <summary>Modelos cujo registro de portas foi regravado.</summary>
            internal int ModelosAlterados { get; set; }

            /// <summary>Portas lidas (antes da normalização).</summary>
            internal int PortasLidas { get; set; }

            /// <summary>Portas descartadas por repetir o índice.</summary>
            internal int PortasDuplicadas { get; set; }

            /// <summary>Modelos sem registro de portas no dicionário (nada a normalizar).</summary>
            internal int ModelosSemRegistro { get; set; }
        }

        internal static Resultado Executar()
        {
            Resultado resultado = new Resultado();

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return resultado;
            }

            List<ModeloMascara> modelos = ModelosMascaraDoDesenho.LerModelos();
            resultado.ModelosLidos = modelos.Count;
            if (modelos.Count == 0)
            {
                return resultado;
            }

            Database banco = documento.Database;
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                DBDictionary raiz =
                    (DBDictionary)transacao.GetObject(banco.NamedObjectsDictionaryId, OpenMode.ForRead);
                if (raiz == null || !raiz.Contains("MASCARAS"))
                {
                    transacao.Commit();
                    return resultado;
                }

                DBDictionary mascaras =
                    (DBDictionary)transacao.GetObject(raiz.GetAt("MASCARAS"), OpenMode.ForWrite);

                foreach (ModeloMascara modelo in modelos)
                {
                    if (modelo == null)
                    {
                        continue;
                    }

                    string chave = modelo.Indice.ToString(CultureInfo.InvariantCulture);
                    if (!mascaras.Contains(chave))
                    {
                        resultado.ModelosSemRegistro++;
                        continue;
                    }

                    Xrecord registro = transacao.GetObject(mascaras.GetAt(chave), OpenMode.ForWrite) as Xrecord;
                    if (registro == null)
                    {
                        resultado.ModelosSemRegistro++;
                        continue;
                    }

                    IReadOnlyList<TypedXData> atual = XDataNeutro.Para(registro);
                    List<ModeloPorta> portas = ModelosMascara.LerPortas(atual, modelo.Indice, modelo.Nome);
                    resultado.PortasLidas += portas.Count;

                    CorrecaoPortasDaMascara.Resultado plano = CorrecaoPortasDaMascara.Planejar(portas);
                    resultado.PortasDuplicadas += plano.Removidas;

                    IReadOnlyList<TypedXData> novo = ModelosMascara.ParaValores(plano.MaxIndice, plano.Portas);
                    if (Iguais(atual, novo))
                    {
                        continue;
                    }

                    registro.Data = ParaResultBuffer(novo);
                    resultado.ModelosAlterados++;
                }

                transacao.Commit();
            }

            return resultado;
        }

        /// <summary>Compara os valores crus (código e valor) para decidir se o registro precisa ser regravado.</summary>
        private static bool Iguais(IReadOnlyList<TypedXData> atual, IReadOnlyList<TypedXData> novo)
        {
            if (atual == null || novo == null)
            {
                return atual == novo;
            }

            if (atual.Count != novo.Count)
            {
                return false;
            }

            for (int i = 0; i < atual.Count; i++)
            {
                if (atual[i].Codigo != novo[i].Codigo ||
                    !string.Equals(Texto(atual[i].Valor), Texto(novo[i].Valor), StringComparison.Ordinal))
                {
                    return false;
                }
            }

            return true;
        }

        private static string Texto(object valor)
        {
            return valor == null || valor is DBNull
                ? string.Empty
                : Convert.ToString(valor, CultureInfo.InvariantCulture);
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

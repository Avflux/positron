using System.Collections.Generic;
using Positron.Data.Layout;

namespace Positron.Data.Correcoes
{
    /// <summary>
    /// O <c>REMLAYDUP</c> (<c>RemoveDuplicadoLayoutRapido</c>) do <c>Correcao.cs</c>:
    /// remove os **duplicados** dos XRecords <c>CENG_LAYOUT</c> por painel — as chaves
    /// <c>P</c> e <c>C</c>, que o FIA (<c>PosicaoNum</c>) e o COMPLM (<c>OrdemLay</c>)
    /// leem.
    ///
    /// O original percorre o cadastro de painéis (<c>Paineis</c>), lê cada chave e
    /// regrava a lista sem os tags repetidos, **conservando o primeiro**.
    ///
    /// **Quirk reproduzido:** o laço vai de <c>0</c> a <c>UBound - 1</c>, então o
    /// **último registro da chave é descartado** mesmo quando não há duplicado (é o
    /// &quot;Rapido&quot; do nome).
    /// </summary>
    public static class CorrecaoLayoutDuplicado
    {
        /// <summary>
        /// A lista sem os tags repetidos (o primeiro de cada tag fica), sem o último
        /// registro — a regra do <c>RemoveDuplicadoLayoutRapido</c>.
        /// </summary>
        public static IReadOnlyList<LayoutPosicoes.PosicaoBruta> RemoverDuplicados(
            IReadOnlyList<LayoutPosicoes.PosicaoBruta> registros)
        {
            List<LayoutPosicoes.PosicaoBruta> saida = new List<LayoutPosicoes.PosicaoBruta>();
            if (registros == null || registros.Count == 0)
            {
                return saida;
            }

            List<string> vistos = new List<string>();

            // O original vai de 0 a `UBound(mTags) - 1`: o último registro NÃO entra.
            for (int i = 0; i < registros.Count - 1; i++)
            {
                LayoutPosicoes.PosicaoBruta registro = registros[i];
                if (registro == null)
                {
                    continue;
                }

                if (vistos.Contains(registro.Tag))
                {
                    continue;
                }

                vistos.Add(registro.Tag);
                saida.Add(registro);
            }

            return saida;
        }

        /// <summary>Diz se a chave precisa ser regravada (a lista muda).</summary>
        public static bool PrecisaRegravar(
            IReadOnlyList<LayoutPosicoes.PosicaoBruta> antes,
            IReadOnlyList<LayoutPosicoes.PosicaoBruta> depois)
        {
            if (antes == null || depois == null)
            {
                return antes != depois;
            }

            if (antes.Count != depois.Count)
            {
                return true;
            }

            for (int i = 0; i < antes.Count; i++)
            {
                if (antes[i] == null || depois[i] == null)
                {
                    if (antes[i] != depois[i])
                    {
                        return true;
                    }

                    continue;
                }

                if (!string.Equals(antes[i].Tag, depois[i].Tag, System.StringComparison.Ordinal) ||
                    !string.Equals(antes[i].Alternativo, depois[i].Alternativo, System.StringComparison.Ordinal) ||
                    antes[i].X != depois[i].X ||
                    antes[i].Y != depois[i].Y)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

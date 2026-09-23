using System;
using System.Collections.Generic;

namespace Positron.Data.Correcoes
{
    /// <summary>Um borne do desenho, como a subida do <c>lm</c> precisa dele.</summary>
    public sealed class BorneDeLm
    {
        public string Handle { get; set; }

        public int IndiceRegua { get; set; }

        public int Tipo { get; set; }

        public int Lm { get; set; }
    }

    /// <summary>
    /// A regra da **subida do <c>lm</c>** — o par de escrita do <c>BorneSemLm</c>
    /// que o <c>VERIF</c> aponta: o borne do desenho com <c>lm == 0</c> recebe o
    /// <c>lm</c> que a régua define para o tipo dele.
    ///
    /// De onde sai o valor é a <see cref="Bornes.LmDasReguas"/> (o campo +6/+7 do
    /// <c>REGUAS/MODELOS2</c>, que o <c>DicionarioBorne.BuscaLMdaRegua</c> do
    /// original lê, e o dicionário de bornes da régua, que é onde o dado existe —
    /// medição da rodada 74). Aqui só entra a **decisão**: muda quem está zerado
    /// **e** tem de onde subir; quem a régua não define fica como está (é dado
    /// faltando no desenho, não regra).
    /// </summary>
    public static class CorrecaoLmBornes
    {
        /// <summary>Um borne que ganha o <c>lm</c> (o que o adapter tem de regravar).</summary>
        public sealed class Ajuste
        {
            public string Handle { get; set; }

            public int IndiceRegua { get; set; }

            public int Tipo { get; set; }

            public int Lm { get; set; }
        }

        /// <summary>
        /// Planeja a subida. <paramref name="lmDaRegua"/> recebe o índice da régua
        /// e o tipo do borne e devolve o <c>lm</c> que a régua define (<c>0</c>
        /// quando não define).
        /// </summary>
        public static IReadOnlyList<Ajuste> Planejar(
            IReadOnlyList<BorneDeLm> bornes,
            Func<int, int, int> lmDaRegua)
        {
            List<Ajuste> ajustes = new List<Ajuste>();
            if (bornes == null || lmDaRegua == null)
            {
                return ajustes;
            }

            foreach (BorneDeLm borne in bornes)
            {
                if (borne == null || borne.Lm != 0)
                {
                    continue;
                }

                int lm = lmDaRegua(borne.IndiceRegua, borne.Tipo);
                if (lm == 0)
                {
                    continue;
                }

                ajustes.Add(new Ajuste
                {
                    Handle = borne.Handle,
                    IndiceRegua = borne.IndiceRegua,
                    Tipo = borne.Tipo,
                    Lm = lm,
                });
            }

            return ajustes;
        }
    }
}

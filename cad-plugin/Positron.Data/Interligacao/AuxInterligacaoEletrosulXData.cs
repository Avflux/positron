using System;
using System.Collections.Generic;
using Positron.Data.Fiacao;

namespace Positron.Data.Interligacao
{
    /// <summary>
    /// XData do app name <c>ELETROSUL</c>: o rótulo auxiliar de um trecho no layout
    /// da Eletrosul (uma variante do <see cref="AuxInterligacaoXData"/>).
    ///
    /// Recuperado de <c>XDataInterligacao.lerXDataAuxInterligacaoEletrosul</c>
    /// (engenharia reversa, ver docs/POSITRON.md):
    ///
    /// | idx | código | campo         |
    /// |-----|--------|---------------|
    /// | 0   | 1001   | "ELETROSUL"  |
    /// | 1   | 1000   | usuario       |
    /// | 2   | 1000   | data          |
    /// | 3   | 1000   | handle        |
    /// | 4   | 1071   | 1 (constante) |
    ///
    /// O recoder só olha o <c>handle</c>, que é o que o original lê. Como no
    /// <see cref="AuxInterligacaoXData"/>, o app name **não** é
    /// <c>AUXINTERLIGELETROSUL</c>: é outro app name (<c>ELETROSUL</c>), o que
    /// confundia o nome da função do reverso.
    /// </summary>
    public static class AuxInterligacaoEletrosulXData
    {
        public const string AppName = "ELETROSUL";

        /// <summary>Menor registro que ainda diz o handle (app name + usuario + data + handle).</summary>
        public const int QuantidadeMinima = 4;

        /// <summary>
        /// Lê o handle do rótulo. Devolve <c>false</c> (sem exceção) quando não é um
        /// <c>ELETROSUL</c> válido — registro truncado é dado de terceiro, não erro
        /// fatal (o original estoura no <c>array[3]</c>).
        /// </summary>
        public static bool Ler(IReadOnlyList<TypedXData> valores, out string handle)
        {
            handle = null;

            if (valores == null || valores.Count < QuantidadeMinima)
            {
                return false;
            }

            if (valores[0].Codigo != 1001 ||
                !string.Equals(valores[0].Valor as string, AppName, StringComparison.Ordinal))
            {
                return false;
            }

            handle = valores[3].Valor as string;
            return true;
        }
    }
}

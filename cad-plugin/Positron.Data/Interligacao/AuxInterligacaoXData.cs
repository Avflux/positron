using System;
using System.Collections.Generic;
using Positron.Data.Fiacao;

namespace Positron.Data.Interligacao
{
    /// <summary>
    /// XData do app name <c>AUXINTERLIG</c>: o rótulo auxiliar de um trecho de
    /// interligação (o <c>DBText</c> que mostra o cabo/veia na ponta).
    ///
    /// Recuperado de <c>XDataInterligacao.lerXDataAuxInterligacao</c>
    /// (engenharia reversa, ver docs/POSITRON.md):
    ///
    /// | idx | código | campo        |
    /// |-----|--------|--------------|
    /// | 0   | 1001   | "AUXINTERLIG"|
    /// | 1   | 1070   | tipo         |
    /// | 2   | 1000   | handle       |
    /// | 3   | 1000   | THandle      |
    /// | 7   | 1000   | opcionais    |
    ///
    /// O recoder só olha o <c>tipo</c> — é o que o <c>IndefineCabosNaoExistentes</c>
    /// usa para saber que o rótulo é do cabo (tipo 1) e deve virar o caracter de
    /// terminal indefinido. O original lê os índices 1..7 direto e **estoura** se o
    /// registro vier truncado; aqui a leitura é tolerante (registro degenerado é
    /// dado de terceiro, não um erro fatal).
    /// </summary>
    public static class AuxInterligacaoXData
    {
        public const string AppName = "AUXINTERLIG";

        /// <summary>Menor registro que ainda diz o tipo (app name + tipo).</summary>
        public const int QuantidadeMinima = 2;

        /// <summary>
        /// Lê o tipo do rótulo. Devolve <c>false</c> (sem exceção) quando não é um
        /// <c>AUXINTERLIG</c> válido.
        /// </summary>
        public static bool Ler(IReadOnlyList<TypedXData> valores, out short tipo)
        {
            tipo = 0;

            if (valores == null || valores.Count < QuantidadeMinima)
            {
                return false;
            }

            if (valores[0].Codigo != 1001 || !string.Equals(valores[0].Valor as string, AppName, StringComparison.Ordinal))
            {
                return false;
            }

            tipo = XDataNumero.Curto(valores[1].Valor);
            return true;
        }
    }
}

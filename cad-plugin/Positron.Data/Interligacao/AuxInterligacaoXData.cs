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
        /// <summary>
        /// Monta o XData do rótulo no layout de 8 valores do
        /// <c>GravarXDataAuxInterligacao</c> — o caminho de escrita do
        /// <c>RecriaTextosCabo</c>: app name, tipo, handle do trecho, THandle, o
        /// <c>1071 1</c>, usuário, data e os opcionais.
        /// </summary>
        public static IReadOnlyList<TypedXData> ParaValores(string handle, short tipo, string tHandle, string usuario, string data, string opcionais)
        {
            return new List<TypedXData>
            {
                new TypedXData(1001, AppName),
                new TypedXData(1070, tipo),
                new TypedXData(1000, handle ?? string.Empty),
                new TypedXData(1000, tHandle ?? string.Empty),
                new TypedXData(1071, 1),
                new TypedXData(1000, usuario ?? string.Empty),
                new TypedXData(1000, data ?? string.Empty),
                new TypedXData(1000, opcionais ?? string.Empty),
            };
        }

        public static bool Ler(IReadOnlyList<TypedXData> valores, out short tipo)
        {
            string handle;
            return Ler(valores, out tipo, out handle);
        }

        /// <summary>
        /// Lê o tipo e o **handle do trecho** (o campo +2 do layout) — o
        /// <c>RecriaTextosCabo</c> precisa dos dois: o tipo diz se o rótulo é de cabo
        /// (1) ou de ponta (3), e o handle diz **qual trecho já está rotulado**.
        /// </summary>
        public static bool Ler(IReadOnlyList<TypedXData> valores, out short tipo, out string handle)
        {
            string opcionais;
            return Ler(valores, out tipo, out handle, out opcionais);
        }

        /// <summary>
        /// Lê o tipo, o handle do trecho e os **opcionais** (o campo +7, a receita do
        /// <c>AtualizaOpcionaisDoCabo</c>).
        /// </summary>
        public static bool Ler(IReadOnlyList<TypedXData> valores, out short tipo, out string handle, out string opcionais)
        {
            tipo = 0;
            handle = null;
            opcionais = null;

            if (valores == null || valores.Count < QuantidadeMinima)
            {
                return false;
            }

            if (valores[0].Codigo != 1001 || !string.Equals(valores[0].Valor as string, AppName, StringComparison.Ordinal))
            {
                return false;
            }

            tipo = XDataNumero.Curto(valores[1].Valor);
            handle = valores.Count > 2 ? valores[2].Valor as string : null;
            opcionais = valores.Count > 7 ? valores[7].Valor as string : null;
            return true;
        }
    }
}

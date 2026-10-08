using System;
using System.Collections.Generic;
using Positron.Data.Fiacao;

namespace Positron.Data.Interligacao
{
    /// <summary>
    /// XData do app name <c>INTERLIGACAO</c>, gravado pelo plugin original nas
    /// <c>LWPOLYLINE</c> que representam um trecho de interligação (cabo/veia) do
    /// diagrama funcional.
    ///
    /// Layout recuperado de <c>XDataInterligacao.GravarXDataInterligacao</c> e
    /// <c>lerXDataInterligacao</c> (engenharia reversa, ver docs/POSITRON.md):
    ///
    /// | idx | código | campo                 |
    /// |-----|--------|-----------------------|
    /// | 0   | 1001   | "INTERLIGACAO"        |
    /// | 1   | 1070   | Tipo                  |
    /// | 2   | 1000   | Tag_Cabo              |
    /// | 3   | 1070   | NumVeia               |
    /// | 4   | 1000   | NomeVeia              |
    /// | 5   | 1070   | Painel1               |
    /// | 6   | 1070   | (reservado, 0)        |
    /// | 7   | 1070   | Painel2               |
    /// | 8   | 1070   | (reservado, 0)        |
    /// | 9   | 1000   | handle (ponta)        |
    /// | 10  | 1000   | (reservado)           |
    /// | 11  | 1000   | (reservado)           |
    /// | 12  | 1070   | ocultaTag             |
    /// | 13  | 1070   | iModeloVeiaFuncao     |
    /// | 14  | 1000   | Usuario               |
    /// | 15  | 1000   | Data                  |
    /// | 16  | 1071   | (reservado, 1)        |
    /// | 17  | 1040   | (reservado, 0)        |
    /// | 18  | 1000   | (reservado)           |
    /// </summary>
    public sealed class InterligacaoXData
    {
        public const string AppName = "INTERLIGACAO";

        /// <summary>O original sempre grava 19 valores; menos que isso é dado truncado.</summary>
        public const int QuantidadeValores = 19;

        /// <summary>Veia "não usada" no desenho — o original descarta estes trechos.</summary>
        public const int NumVeiaIndefinido = -1000;

        public short Tipo { get; set; }

        public string Tag_Cabo { get; set; }

        public int NumVeia { get; set; }

        public string NomeVeia { get; set; }

        public short Painel1 { get; set; }

        public short Painel2 { get; set; }

        /// <summary>Handle da entidade da ponta que este trecho representa.</summary>
        public string Handle { get; set; }

        public int OcultaTag { get; set; }

        public int IndexModeloVeiaFuncao { get; set; }

        public string Usuario { get; set; }

        public string Data { get; set; }

        /// <summary>
        /// Lê o XData de uma interligação. Devolve <c>false</c> (sem exceção)
        /// quando não é uma <c>INTERLIGACAO</c> válida — dado de terceiro não
        /// deve virar erro fatal.
        /// </summary>
        public static bool Ler(IReadOnlyList<TypedXData> valores, out InterligacaoXData ilig)
        {
            ilig = null;

            if (valores == null || valores.Count < QuantidadeValores)
            {
                return false;
            }

            if (valores[0].Codigo != 1001 || !string.Equals(valores[0].Valor as string, AppName, StringComparison.Ordinal))
            {
                return false;
            }

            InterligacaoXData lida = new InterligacaoXData
            {
                Tipo = Curto(valores[1].Valor),
                Tag_Cabo = Texto(valores[2].Valor),
                NumVeia = Inteiro(valores[3].Valor),
                NomeVeia = Texto(valores[4].Valor),
                Painel1 = Curto(valores[5].Valor),
                Painel2 = Curto(valores[7].Valor),
                Handle = Texto(valores[9].Valor),
                OcultaTag = Inteiro(valores[12].Valor),
                IndexModeloVeiaFuncao = Inteiro(valores[13].Valor),
                Usuario = Texto(valores[14].Valor),
                Data = Texto(valores[15].Valor),
            };

            ilig = lida;
            return true;
        }

        private static short Curto(object valor)
        {
            return valor == null || valor is DBNull ? (short)0 : Convert.ToInt16(valor);
        }

        private static int Inteiro(object valor)
        {
            return valor == null || valor is DBNull ? 0 : Convert.ToInt32(valor);
        }

        private static string Texto(object valor)
        {
            if (valor == null || valor is DBNull)
            {
                return null;
            }

            string texto = valor as string;
            return texto ?? Convert.ToString(valor);
        }
    }
}

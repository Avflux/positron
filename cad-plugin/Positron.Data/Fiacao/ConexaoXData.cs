using System;
using System.Collections.Generic;

namespace Positron.Data.Fiacao
{
    /// <summary>
    /// XData do app name <c>CONEXAO</c>, gravado pelo plugin original nas
    /// <c>LWPOLYLINE</c> que representam a fiação do diagrama funcional.
    ///
    /// Layout recuperado de <c>XDataConexao.GravarXDataConexao</c> /
    /// <c>lerXDataConexao</c> (engenharia reversa, ver docs/POSITRON.md):
    ///
    /// | idx | código | campo         |
    /// |-----|--------|---------------|
    /// | 0   | 1001   | "CONEXAO"     |
    /// | 1   | 1070   | Tipo (liga/fase, 1..4) |
    /// | 2   | 1071   | Potencial     |
    /// | 3   | 1000   | Handle        |
    /// | 4   | 1070   | Painel        |
    /// | 5   | 1070   | Aplicacao     |
    /// | 6   | 1070   | (reservado)   |
    /// | 7   | 1000   | Nome          |
    /// | 8   | 1000   | Funcao        |
    /// | 9   | 1000   | Tensao        |
    /// | 10  | 1000   | Secao         |
    /// | 11  | 1000   | Cor           |
    /// | 12  | 1000   | (reservado)   |
    /// | 13  | 1040   | (reservado)   |
    /// | 14  | 1070   | Disp1 (0 ou -1) |
    /// | 15  | 1070   | Disp2 (0 ou -1) |
    /// | 16  | 1000   | Jumper        |
    /// | 17  | 1000   | (reservado)   |
    /// | 18  | 1071   | Enderecamento |
    /// | 19  | 1071   | (reservado)   |
    /// | 20  | 1000   | Usuario       |
    /// | 21  | 1000   | Data          |
    /// | 22  | 1071   | (reservado)   |
    /// | 23  | 1040   | (reservado)   |
    /// | 24  | 1000   | (reservado)   |
    /// </summary>
    public sealed class ConexaoXData
    {
        public const string AppName = "CONEXAO";

        /// <summary>O original sempre grava 25 valores; menos que isso é dado truncado.</summary>
        public const int QuantidadeValores = 25;

        public short Tipo { get; set; }

        public int Potencial { get; set; }

        public string Handle { get; set; }

        public short Painel { get; set; }

        public int Aplicacao { get; set; }

        public string Nome { get; set; }

        public string Funcao { get; set; }

        public string Tensao { get; set; }

        public string Secao { get; set; }

        public string Cor { get; set; }

        public bool Disp1 { get; set; }

        public bool Disp2 { get; set; }

        public string Jumper { get; set; }

        public int Enderecamento { get; set; }

        public string Usuario { get; set; }

        public string Data { get; set; }

        /// <summary>
        /// Lê o XData de uma conexão. Devolve <c>false</c> (sem exceção) quando
        /// não é uma <c>CONEXAO</c> válida — o chamador não deve tratar dado de
        /// terceiro como erro fatal.
        /// </summary>
        public static bool Ler(IReadOnlyList<TypedXData> valores, out ConexaoXData conexao)
        {
            conexao = null;

            if (valores == null || valores.Count < QuantidadeValores)
            {
                return false;
            }

            if (valores[0].Codigo != 1001 || !string.Equals(valores[0].Valor as string, AppName, StringComparison.Ordinal))
            {
                return false;
            }

            ConexaoXData lida = new ConexaoXData
            {
                Tipo = Curto(valores[1].Valor),
                Potencial = Inteiro(valores[2].Valor),
                Handle = Texto(valores[3].Valor),
                Painel = Curto(valores[4].Valor),
                Aplicacao = Inteiro(valores[5].Valor),
                Nome = Texto(valores[7].Valor),
                Funcao = Texto(valores[8].Valor),
                Tensao = Texto(valores[9].Valor),
                Secao = Texto(valores[10].Valor),
                Cor = Texto(valores[11].Valor),
                Disp1 = Booleano(valores[14].Valor),
                Disp2 = Booleano(valores[15].Valor),
                Jumper = Texto(valores[16].Valor),
                Enderecamento = Inteiro(valores[18].Valor),
                Usuario = Texto(valores[20].Valor),
                Data = Texto(valores[21].Valor),
            };

            conexao = lida;
            return true;
        }

        // O original guarda os inteiros como short/int/double conforme o código
        // DXF e usa Conversions.* do VB. Aqui a conversão tolera nulo e tipo
        // inesperado em vez de estourar.

        private static short Curto(object valor)
        {
            return valor == null || valor is DBNull ? (short)0 : XDataNumero.Curto(valor);
        }

        private static int Inteiro(object valor)
        {
            return valor == null || valor is DBNull ? 0 : XDataNumero.Inteiro(valor);
        }

        private static bool Booleano(object valor)
        {
            // Grava-se 0 ou -1 (padrão do CAD); qualquer não-zero é true.
            return valor != null && !(valor is DBNull) && XDataNumero.Booleano(valor);
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

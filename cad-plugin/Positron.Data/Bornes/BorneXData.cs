using System;
using System.Collections.Generic;
using Positron.Data.Fiacao;

namespace Positron.Data.Bornes
{
    /// <summary>
    /// XData de um **borne** — bloco (<c>BlockReference</c>) com app name
    /// <c>Dispositivo</c> e tipo <c>"B"</c>. É o que o plugin original grava em
    /// <c>XDataDispositivosMaster.GravarXDataDispBorne</c> e lê em
    /// <c>LeXDataQualquerDispositivo</c>.
    ///
    /// O mesmo app name guarda vários tipos de dispositivo (o campo 1 é o tipo);
    /// aqui só interessa o <c>"B"</c> (borne). Layout (18 valores):
    ///
    /// | idx | código | campo            |
    /// |-----|--------|------------------|
    /// | 0   | 1001   | "Dispositivo"    |
    /// | 1   | 1000   | tipo ("B")       |
    /// | 2   | 1000   | (reservado)      |
    /// | 3   | 1000   | PosInt_Jumper    |
    /// | 4   | 1000   | BlocoLayout      |
    /// | 5   | 1000   | Numero           |
    /// | 6   | 1000   | NumeroComplem    |
    /// | 7   | 1040   | Ordem            |
    /// | 8   | 1071   | IndiceRegua      |
    /// | 9   | 1000   | conector         |
    /// | 10  | 1000   | lm               |
    /// | 11  | 1000   | Orientacao       |
    /// | 12  | 1040   | (reservado)      |
    /// | 13  | 1040   | (reservado)      |
    /// | 14  | 1071   | tipo             |
    /// | 15  | 1071   | Visivel          |
    /// | 16  | 1000   | Usuario          |
    /// | 17  | 1000   | Data             |
    /// </summary>
    public sealed class BorneXData
    {
        public const string AppName = "Dispositivo";

        /// <summary>App name legado que o original também aceita.</summary>
        public const string AppNameLegado = "DISPOSITIVO";

        public const string TipoBorne = "B";

        public const int QuantidadeValores = 18;

        public string TipoDispositivo { get; set; }

        public string PosIntJumper { get; set; }

        public string BlocoLayout { get; set; }

        public string Numero { get; set; }

        public string NumeroComplem { get; set; }

        public double Ordem { get; set; }

        public int IndiceRegua { get; set; }

        public string Conector { get; set; }

        public int Lm { get; set; }

        public string Orientacao { get; set; }

        public int Tipo { get; set; }

        public int Visivel { get; set; }

        public string Usuario { get; set; }

        public string Data { get; set; }

        /// <summary>Número do terminal com o complemento, como a fiação grava em <c>Terminal</c>.</summary>
        public string Terminal
        {
            get
            {
                return string.IsNullOrEmpty(NumeroComplem) ? Numero : Numero + NumeroComplem;
            }
        }

        /// <summary>
        /// Lê o XData de um borne. Devolve <c>false</c> (sem exceção) quando não é
        /// um borne válido — dado de terceiro não deve virar erro fatal.
        /// </summary>
        public static bool Ler(IReadOnlyList<TypedXData> valores, out BorneXData borne)
        {
            borne = null;

            if (valores == null || valores.Count < QuantidadeValores)
            {
                return false;
            }

            if (!AppNameValido(valores[0]))
            {
                return false;
            }

            if (valores[1].Codigo != 1000 || !string.Equals(Texto(valores[1].Valor), TipoBorne, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            BorneXData lida = new BorneXData
            {
                TipoDispositivo = Texto(valores[1].Valor),
                PosIntJumper = Texto(valores[3].Valor),
                BlocoLayout = Texto(valores[4].Valor),
                Numero = Texto(valores[5].Valor),
                NumeroComplem = Texto(valores[6].Valor),
                Ordem = Real(valores[7].Valor),
                IndiceRegua = Inteiro(valores[8].Valor),
                Conector = Texto(valores[9].Valor),
                Lm = Inteiro(valores[10].Valor),
                Orientacao = Texto(valores[11].Valor),
                Tipo = Inteiro(valores[14].Valor),
                Visivel = Inteiro(valores[15].Valor),
                Usuario = Texto(valores[16].Valor),
                Data = Texto(valores[17].Valor),
            };

            borne = lida;
            return true;
        }

        private static bool AppNameValido(TypedXData valor)
        {
            if (valor.Codigo != 1001)
            {
                return false;
            }

            string app = valor.Valor as string;
            return string.Equals(app, AppName, StringComparison.Ordinal)
                || string.Equals(app, AppNameLegado, StringComparison.Ordinal);
        }

        private static double Real(object valor)
        {
            return valor == null || valor is DBNull ? 0.0 : Convert.ToDouble(valor);
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

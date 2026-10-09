using System;
using System.Collections.Generic;
using Positron.Data.Fiacao;

namespace Positron.Data.Modelos
{
    /// <summary>
    /// XData de uma **máscara** — bloco (<c>BlockReference</c>) com app name
    /// <c>Dispositivo</c> e tipo <c>"M"</c> (ramos <c>StructureMascara</c> de
    /// <c>LeXDataQualquerDispositivo</c>).
    ///
    /// Serve para descobrir quais **modelos de máscara estão em uso** no desenho
    /// (o <c>clsDispositivoTacito.carregaModelosUsadosMascaras</c> do original).
    /// Layout (26 valores):
    ///
    /// | idx | código | campo          |
    /// |-----|--------|----------------|
    /// | 0   | 1001   | "Dispositivo"  |
    /// | 1   | 1000   | tipo ("M")     |
    /// | 2   | 1000   | Nome1          |
    /// | 3   | 1000   | Nome2          |
    /// | 4   | 1000   | Alternativo    |
    /// | 8   | 1070   | Painel         |
    /// | 12  | 1071   | indexModelo    |
    /// | 13  | 1071   | Complementar   |
    /// </summary>
    public sealed class MascaraXData
    {
        public const string AppName = "Dispositivo";

        public const string TipoMascara = "M";

        public const int QuantidadeValores = 26;

        public string Nome1 { get; set; }

        public string Nome2 { get; set; }

        public string Alternativo { get; set; }

        public short Painel { get; set; }

        public int IndexModelo { get; set; }

        public bool Complementar { get; set; }

        public static bool Ler(IReadOnlyList<TypedXData> valores, out MascaraXData mascara)
        {
            mascara = null;

            if (valores == null || valores.Count < QuantidadeValores)
            {
                return false;
            }

            if (valores[0].Codigo != 1001
                || !string.Equals(valores[0].Valor as string, AppName, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            if (valores[1].Codigo != 1000
                || !string.Equals(Texto(valores[1].Valor), TipoMascara, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            mascara = new MascaraXData
            {
                Nome1 = Texto(valores[2].Valor),
                Nome2 = Texto(valores[3].Valor),
                Alternativo = Texto(valores[4].Valor),
                Painel = Curto(valores[8].Valor),
                IndexModelo = Inteiro(valores[12].Valor),
                Complementar = Booleano(valores[13].Valor),
            };
            return true;
        }

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

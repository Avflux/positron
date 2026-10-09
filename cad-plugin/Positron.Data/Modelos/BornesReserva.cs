using System;
using System.Collections.Generic;
using Positron.Data.Fiacao;

namespace Positron.Data.Modelos
{
    /// <summary>Um borne de reserva definido para uma régua.</summary>
    public sealed class BorneReserva
    {
        public string Numero { get; set; }

        public string Alternativo { get; set; }

        public double Ordem { get; set; }

        public int Tipo { get; set; }

        public int Lm { get; set; }

        public bool Reserva { get; set; }

        public string Orientacao { get; set; }

        public string BlocoLayout { get; set; }
    }

    /// <summary>
    /// Os bornes de reserva de cada régua, guardados no desenho em
    /// <c>NamedObjectsDictionary → "CENG_BORNES" → "&lt;indexRegua&gt;"</c>
    /// (<c>DicionarioBorne.LeDicBornesReserva</c>).
    ///
    /// O <c>Xrecord</c> é uma lista plana de registros de **10 valores**; do
    /// registro interessa (campo +0 e +9 não são usados):
    ///
    /// | deslocamento | campo       |
    /// |--------------|-------------|
    /// | +1           | Numero      |
    /// | +2           | Alternativo |
    /// | +3           | Ordem       |
    /// | +4           | tipo        |
    /// | +5           | lm          |
    /// | +6           | reserva     |
    /// | +7           | Orientacao  |
    /// | +8           | BlocoLayout |
    ///
    /// Só entram reservas com <c>tipo</c> em 0, 1 ou 2 — como no original.
    /// </summary>
    public static class BornesReserva
    {
        public const int ValoresPorBorne = 10;

        public static List<BorneReserva> Ler(IReadOnlyList<TypedXData> valores)
        {
            List<BorneReserva> bornes = new List<BorneReserva>();
            if (valores == null)
            {
                return bornes;
            }

            for (int i = 0; i + 8 < valores.Count; i += ValoresPorBorne)
            {
                int tipo = Inteiro(valores[i + 4].Valor);
                if (tipo < 0 || tipo > 2)
                {
                    continue;
                }

                bornes.Add(new BorneReserva
                {
                    Numero = Texto(valores[i + 1].Valor),
                    Alternativo = Texto(valores[i + 2].Valor),
                    Ordem = Real(valores[i + 3].Valor),
                    Tipo = tipo,
                    Lm = Inteiro(valores[i + 5].Valor),
                    Reserva = Booleano(valores[i + 6].Valor),
                    Orientacao = Texto(valores[i + 7].Valor),
                    BlocoLayout = Texto(valores[i + 8].Valor),
                });
            }

            return bornes;
        }

        private static int Inteiro(object valor)
        {
            return valor == null || valor is DBNull ? 0 : XDataNumero.Inteiro(valor);
        }

        private static double Real(object valor)
        {
            return valor == null || valor is DBNull ? 0.0 : XDataNumero.Real(valor);
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

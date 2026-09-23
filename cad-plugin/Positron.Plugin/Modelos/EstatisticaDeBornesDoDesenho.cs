using System.Collections.Generic;
using Positron.Data.Bornes;
using Positron.Data.Modelos;
using Positron.Plugin.Bornes;

namespace Positron.Plugin.Modelos
{
    /// <summary>
    /// O STATBORN em lote (frente 3 do §7.6): conta os bornes de cada régua e as reservas,
    /// reusando os leitores que já existem — <see cref="ReguasDoDesenho"/> (as réguas),
    /// BornesDoDesenho (os bornes do desenho) e BornesReservaDoDesenho (o CENG_BORNES).
    ///
    /// A conta é pura (<see cref="EstatisticaDeBornes"/>); aqui só se lê o desenho.
    /// </summary>
    internal static class EstatisticaDeBornesDoDesenho
    {
        internal sealed class Resultado
        {
            internal List<LinhaDeEstatistica> Linhas { get; } = new List<LinhaDeEstatistica>();

            internal int Bornes { get; set; }

            internal int Reservas { get; set; }

            internal LinhaDeEstatistica Total
            {
                get { return EstatisticaDeBornes.Total(Linhas); }
            }
        }

        internal static Resultado Calcular()
        {
            Resultado resultado = new Resultado();

            ReguasModelo reguas = ReguasDoDesenho.Ler();
            IReadOnlyList<PontoBorne> bornes = BornesDoDesenho.Ler(reguas);

            foreach (ReguaInfo regua in reguas.Ordenadas)
            {
                List<int> tiposDosBornes = new List<int>();
                foreach (PontoBorne borne in bornes)
                {
                    if (borne.IndiceRegua == regua.Indice)
                    {
                        tiposDosBornes.Add(borne.Tipo);
                    }
                }

                List<int> tiposDasReservas = new List<int>();
                foreach (BorneReserva reserva in BornesReservaDoDesenho.Ler(regua.Indice))
                {
                    tiposDasReservas.Add(reserva.Tipo);
                }

                resultado.Bornes += tiposDosBornes.Count;
                resultado.Reservas += tiposDasReservas.Count;
                resultado.Linhas.Add(EstatisticaDeBornes.Contar(
                    regua.Indice, regua.Painel.ToString(), regua.Nome, tiposDosBornes, tiposDasReservas));
            }

            return resultado;
        }
    }
}

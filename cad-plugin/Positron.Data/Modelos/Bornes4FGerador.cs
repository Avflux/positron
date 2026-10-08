using System;
using System.Collections.Generic;
using Positron.Data.Bornes;

namespace Positron.Data.Modelos
{
    /// <summary>Uma linha de <c>Bornes4F</c>.</summary>
    public sealed class Borne4F
    {
        public short Painel { get; set; }

        public int IndexRegua { get; set; }

        public string Regua { get; set; }

        public string Alternativo { get; set; }

        public string Handle { get; set; }

        public string Borne { get; set; }

        public double Ordem { get; set; }

        public int Tipo { get; set; }

        public string Pagina { get; set; }

        public bool BReserva { get; set; }

        public int Lm { get; set; }

        public string Orientacao { get; set; }

        public string BlocoLayout { get; set; }
    }

    /// <summary>
    /// Gera as linhas de <c>Bornes4F</c> — o <c>frmCompilarFiacao.F85UWVZrkZ</c>
    /// do original.
    ///
    /// Duas origens:
    /// - os **bornes do desenho** (blocos com XData de borne): resolvem a régua
    ///   pelo dicionário e a página pelo layer; entram com <c>Handle</c> do bloco e
    ///   <c>bReserva = false</c>. Só entram os que têm painel conhecido e em uso.
    /// - os **bornes de reserva** de cada régua (dicionário <c>CENG_BORNES</c>):
    ///   entram sem handle e com <c>bReserva</c> do próprio registro.
    /// </summary>
    public static class Bornes4FGerador
    {
        public static List<Borne4F> Gerar(
            IEnumerable<PontoBorne> bornes,
            ReguasModelo reguas,
            ICollection<int> paineisEmUso,
            IReadOnlyDictionary<int, IReadOnlyList<BorneReserva>> reservasPorRegua)
        {
            List<Borne4F> linhas = new List<Borne4F>();

            if (bornes != null)
            {
                foreach (PontoBorne borne in bornes)
                {
                    ReguaInfo regua = reguas == null ? null : reguas.Buscar(borne.IndiceRegua);
                    if (regua == null)
                    {
                        continue;
                    }

                    if (paineisEmUso != null && !paineisEmUso.Contains(regua.Painel))
                    {
                        continue;
                    }

                    linhas.Add(new Borne4F
                    {
                        Painel = regua.Painel,
                        IndexRegua = borne.IndiceRegua,
                        Regua = regua.Nome,
                        Alternativo = string.Empty,
                        Handle = borne.Handle,
                        Borne = borne.Numero,
                        Ordem = borne.Ordem,
                        Tipo = borne.Tipo,
                        Pagina = borne.Layer,
                        BReserva = false,
                        Lm = borne.Lm,
                        Orientacao = NormalizarOrientacao(borne.Orientacao),
                        BlocoLayout = borne.BlocoLayout,
                    });
                }
            }

            if (reguas != null && reservasPorRegua != null)
            {
                foreach (ReguaInfo regua in reguas.Ordenadas)
                {
                    if (paineisEmUso != null && !paineisEmUso.Contains(regua.Painel))
                    {
                        continue;
                    }

                    IReadOnlyList<BorneReserva> reservas;
                    if (!reservasPorRegua.TryGetValue(regua.Indice, out reservas) || reservas == null)
                    {
                        continue;
                    }

                    foreach (BorneReserva reserva in reservas)
                    {
                        linhas.Add(new Borne4F
                        {
                            Painel = regua.Painel,
                            IndexRegua = regua.Indice,
                            Regua = regua.Nome,
                            Alternativo = reserva.Alternativo,
                            Handle = string.Empty,
                            Borne = reserva.Numero,
                            Ordem = reserva.Ordem,
                            Tipo = reserva.Tipo,
                            Pagina = string.Empty,
                            BReserva = reserva.Reserva,
                            Lm = reserva.Lm,
                            Orientacao = NormalizarOrientacao(reserva.Orientacao),
                            BlocoLayout = reserva.BlocoLayout,
                        });
                    }
                }
            }

            return linhas;
        }

        private static string NormalizarOrientacao(string orientacao)
        {
            return orientacao == null ? string.Empty : orientacao.Trim();
        }
    }
}

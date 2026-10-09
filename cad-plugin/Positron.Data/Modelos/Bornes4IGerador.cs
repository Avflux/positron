using System.Collections.Generic;
using Positron.Data.Bornes;

namespace Positron.Data.Modelos
{
    /// <summary>Uma linha de <c>Bornes4I</c> (borne da interligação).</summary>
    public sealed class Borne4I
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
    }

    /// <summary>
    /// Projeta <c>Bornes4I</c> — o <c>T6NUlT3ghH</c> do
    /// <c>frmCompilarInterligacao</c>: os bornes do desenho mais os de reserva,
    /// com a régua resolvida pelo dicionário.
    ///
    /// A diferença em relação ao <c>Bornes4F</c> do <c>FIA</c>: a interligação
    /// **não** filtra por painel em uso (basta a régua resolver), então a geração
    /// reaproveita o <see cref="Bornes4FGerador"/> sem esse filtro. A tabela não
    /// tem <c>LM</c>, <c>Orientacao</c> nem <c>BlocoLayout</c>.
    /// </summary>
    public static class Bornes4IGerador
    {
        public static List<Borne4I> Gerar(
            IEnumerable<PontoBorne> bornes,
            ReguasModelo reguas,
            IReadOnlyDictionary<int, IReadOnlyList<BorneReserva>> reservasPorRegua)
        {
            return Mapear(Bornes4FGerador.Gerar(bornes, reguas, null, reservasPorRegua));
        }

        public static List<Borne4I> Mapear(IEnumerable<Borne4F> bornes)
        {
            List<Borne4I> linhas = new List<Borne4I>();
            if (bornes == null)
            {
                return linhas;
            }

            foreach (Borne4F borne in bornes)
            {
                if (borne == null)
                {
                    continue;
                }

                linhas.Add(new Borne4I
                {
                    Painel = borne.Painel,
                    IndexRegua = borne.IndexRegua,
                    Regua = borne.Regua,
                    Alternativo = borne.Alternativo,
                    Handle = borne.Handle,
                    Borne = borne.Borne,
                    Ordem = borne.Ordem,
                    Tipo = borne.Tipo,
                    Pagina = borne.Pagina,
                    BReserva = borne.BReserva,
                });
            }

            return linhas;
        }
    }
}

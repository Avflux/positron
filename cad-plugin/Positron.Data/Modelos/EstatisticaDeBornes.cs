using System.Collections.Generic;
using System.Globalization;

namespace Positron.Data.Modelos
{
    /// <summary>
    /// A estatística de bornes de uma régua — o que o STATBORN do original mostra na grade e o
    /// clsReguasDeBornes.SomaOsBornes calcula (frente 3 do §7.6, o único candidato em lote
    /// daquela frente).
    ///
    /// A regra, do reverso:
    ///
    /// - **usados**: os blocos de borne **no desenho** (Dispositivo tipo B), por IndiceRegua;
    ///   o tipo != 0 conta como **duplo**, senão **simples**;
    /// - **reserva**: os bornes da lista de reserva da régua (o CENG_BORNES), também partidos
    ///   por tipo;
    /// - **total**: usados simples + reserva simples + usados duplos + reserva duplos.
    /// </summary>
    public sealed class LinhaDeEstatistica
    {
        public int IndiceRegua { get; set; }

        public string Painel { get; set; }

        public string NomeRegua { get; set; }

        /// <summary>Bornes **usados** simples (os que estão no desenho).</summary>
        public int UsoS { get; set; }

        /// <summary>Bornes de **reserva** simples.</summary>
        public int ResS { get; set; }

        public int UsoD { get; set; }

        public int ResD { get; set; }

        public int Total
        {
            get { return UsoS + ResS + UsoD + ResD; }
        }
    }

    /// <summary>As contas e o formato da estatística de bornes.</summary>
    public static class EstatisticaDeBornes
    {
        public const string Cabecalho = "REGUA;indice;painel;regua;UsoS;ResS;UsoD;ResD;Total";

        /// <summary>
        /// Conta a régua: os tipos crus (0 = simples, outro = duplo) dos bornes do desenho e
        /// das reservas.
        /// </summary>
        public static LinhaDeEstatistica Contar(
            int indiceRegua,
            string painel,
            string nomeRegua,
            IReadOnlyList<int> tiposDosBornes,
            IReadOnlyList<int> tiposDasReservas)
        {
            LinhaDeEstatistica linha = new LinhaDeEstatistica
            {
                IndiceRegua = indiceRegua,
                Painel = painel,
                NomeRegua = nomeRegua,
            };

            if (tiposDosBornes != null)
            {
                foreach (int tipo in tiposDosBornes)
                {
                    if (tipo != 0)
                    {
                        linha.UsoD++;
                    }
                    else
                    {
                        linha.UsoS++;
                    }
                }
            }

            if (tiposDasReservas != null)
            {
                foreach (int tipo in tiposDasReservas)
                {
                    if (tipo != 0)
                    {
                        linha.ResD++;
                    }
                    else
                    {
                        linha.ResS++;
                    }
                }
            }

            return linha;
        }

        /// <summary>A linha do relatório (o separador é ; , como no pzDiag).</summary>
        public static string Linha(LinhaDeEstatistica linha)
        {
            if (linha == null)
            {
                return string.Empty;
            }

            return string.Join(";", new[]
            {
                "REGUA",
                Numero(linha.IndiceRegua),
                linha.Painel ?? string.Empty,
                linha.NomeRegua ?? string.Empty,
                Numero(linha.UsoS),
                Numero(linha.ResS),
                Numero(linha.UsoD),
                Numero(linha.ResD),
                Numero(linha.Total),
            });
        }

        /// <summary>O total de todas as réguas (o calculaSelecionado do original).</summary>
        public static LinhaDeEstatistica Total(IReadOnlyList<LinhaDeEstatistica> linhas)
        {
            LinhaDeEstatistica total = new LinhaDeEstatistica { Painel = string.Empty, NomeRegua = "TOTAL" };
            if (linhas == null)
            {
                return total;
            }

            foreach (LinhaDeEstatistica linha in linhas)
            {
                if (linha == null)
                {
                    continue;
                }

                total.UsoS += linha.UsoS;
                total.ResS += linha.ResS;
                total.UsoD += linha.UsoD;
                total.ResD += linha.ResD;
            }

            return total;
        }

        private static string Numero(int valor)
        {
            return valor.ToString(CultureInfo.InvariantCulture);
        }
    }
}

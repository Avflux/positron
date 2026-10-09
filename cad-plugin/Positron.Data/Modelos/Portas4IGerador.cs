using System.Collections.Generic;

namespace Positron.Data.Modelos
{
    /// <summary>Uma linha de <c>Portas4I</c> (porta da interligação).</summary>
    public sealed class Porta4I
    {
        public int IndexModelo { get; set; }

        public string NomeModelo { get; set; }

        public string Regua { get; set; }

        public string Borne { get; set; }

        public string Terminal { get; set; }

        public double TerminalNum { get; set; }

        public string Tipo { get; set; }
    }

    /// <summary>
    /// Projeta <c>Portas4I</c> a partir das portas dos **modelos de máscara** —
    /// o <c>wrlU180vl0</c> do <c>frmCompilarInterligacao</c>.
    ///
    /// A diferença em relação ao <c>Portas4F</c> do <c>FIA</c>: a interligação
    /// percorre **todos** os modelos de máscara do dicionário (não só os que
    /// estão em uso no desenho), então a geração reaproveita o
    /// <see cref="Portas4FGerador"/> sem filtro de uso. A tabela não tem a
    /// coluna <c>Orientacao</c>.
    /// </summary>
    public static class Portas4IGerador
    {
        public static List<Porta4I> Gerar(
            IEnumerable<ModeloMascara> modelos,
            IReadOnlyDictionary<int, IReadOnlyList<ModeloPorta>> portasPorModelo)
        {
            return Mapear(Portas4FGerador.Gerar(modelos, portasPorModelo, null));
        }

        public static List<Porta4I> Mapear(IEnumerable<Porta4F> portas)
        {
            List<Porta4I> linhas = new List<Porta4I>();
            if (portas == null)
            {
                return linhas;
            }

            foreach (Porta4F porta in portas)
            {
                if (porta == null)
                {
                    continue;
                }

                linhas.Add(new Porta4I
                {
                    IndexModelo = porta.IndexModelo,
                    NomeModelo = porta.NomeModelo,
                    Regua = porta.Regua,
                    Borne = porta.Borne,
                    Terminal = porta.Terminal,
                    TerminalNum = porta.TerminalNum,
                    Tipo = porta.Tipo,
                });
            }

            return linhas;
        }
    }
}

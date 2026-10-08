using System;
using System.Collections.Generic;

namespace Positron.Data.Modelos
{
    /// <summary>Uma linha de <c>Portas4F</c>.</summary>
    public sealed class Porta4F
    {
        public int IndexModelo { get; set; }

        public string NomeModelo { get; set; }

        public string Regua { get; set; }

        public string Borne { get; set; }

        public string Terminal { get; set; }

        public double TerminalNum { get; set; }

        public string Tipo { get; set; }

        public string Orientacao { get; set; }
    }

    /// <summary>
    /// Gera as linhas de <c>Portas4F</c> a partir dos **modelos de máscara** do
    /// desenho — o <c>frmCompilarFiacao.NNYXzPbSi2</c> do original.
    ///
    /// Para cada modelo em uso, e cada porta dele:
    /// - se a porta traz **régua e bornes**, gera uma linha por borne, casando a
    ///   régua pela posição (a lista de réguas se repete uma vez por borne se
    ///   tiver só uma), com <c>Tipo = "B"</c> e <c>Terminal</c> vazio;
    /// - senão, se traz **terminais**, gera uma linha por terminal, com
    ///   <c>Tipo = "T"</c>, <c>Régua</c>/<c>Borne</c> vazios.
    ///
    /// Um borne que começa com <c>*</c> tem o asterisco removido (o original usa
    /// isso para marcar "repete").
    /// </summary>
    public static class Portas4FGerador
    {
        public static List<Porta4F> Gerar(
            IEnumerable<ModeloMascara> modelos,
            IReadOnlyDictionary<int, IReadOnlyList<ModeloPorta>> portasPorModelo,
            ICollection<int> modelosEmUso)
        {
            List<Porta4F> linhas = new List<Porta4F>();
            if (modelos == null || portasPorModelo == null)
            {
                return linhas;
            }

            foreach (ModeloMascara modelo in modelos)
            {
                if (modelosEmUso != null && !modelosEmUso.Contains(modelo.Indice))
                {
                    continue;
                }

                IReadOnlyList<ModeloPorta> portas;
                if (!portasPorModelo.TryGetValue(modelo.Indice, out portas) || portas == null)
                {
                    continue;
                }

                foreach (ModeloPorta porta in portas)
                {
                    GerarDaPorta(linhas, modelo, porta);
                }
            }

            return linhas;
        }

        private static void GerarDaPorta(List<Porta4F> linhas, ModeloMascara modelo, ModeloPorta porta)
        {
            string terminais = Limpo(porta.Terminais);
            string bornes = Limpo(porta.Bornes);
            string regua = Limpo(porta.Regua);
            string orientacao = Limpo(porta.Orientacao);

            if (regua.Length > 0 && bornes.Length > 0 && bornes != ";")
            {
                List<string> listaBornes = Terminais.Dividir(bornes, repete: true);
                List<string> listaReguas = Terminais.Dividir(regua);

                for (int i = 0; i < listaBornes.Count; i++)
                {
                    string borne = listaBornes[i];
                    if (borne.StartsWith("*", StringComparison.Ordinal))
                    {
                        borne = borne.Substring(1);
                    }

                    string reguaDaLinha = i < listaReguas.Count ? listaReguas[i] : regua;

                    linhas.Add(new Porta4F
                    {
                        IndexModelo = modelo.Indice,
                        NomeModelo = modelo.Nome,
                        Regua = reguaDaLinha,
                        Borne = borne,
                        Terminal = string.Empty,
                        TerminalNum = TerminalNumerico.Calcular(borne),
                        Tipo = "B",
                        Orientacao = orientacao,
                    });
                }

                return;
            }

            if (terminais.Length == 0 || terminais == ";")
            {
                return;
            }

            foreach (string terminal in Terminais.Dividir(terminais))
            {
                linhas.Add(new Porta4F
                {
                    IndexModelo = modelo.Indice,
                    NomeModelo = modelo.Nome,
                    Regua = string.Empty,
                    Borne = string.Empty,
                    Terminal = terminal,
                    TerminalNum = TerminalNumerico.Calcular(terminal),
                    Tipo = "T",
                    Orientacao = orientacao,
                });
            }
        }

        private static string Limpo(string valor)
        {
            return valor == null ? string.Empty : valor.Trim();
        }
    }
}

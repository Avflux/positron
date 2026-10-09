using System;
using System.Collections.Generic;

namespace Positron.Data.Modelos
{
    /// <summary>Uma linha de <c>Contatos4F</c>.</summary>
    public sealed class Contato4F
    {
        public int IndexModelo { get; set; }

        public string NomeModelo { get; set; }

        public string Terminal { get; set; }

        public double TerminalNum { get; set; }

        public string Orientacao { get; set; }
    }

    /// <summary>
    /// Gera as linhas de <c>Contatos4F</c> a partir dos **modelos de contato** do
    /// desenho — o <c>frmCompilarFiacao.WPcX9UGCKZ</c> do original.
    ///
    /// Para cada modelo em uso:
    /// - os terminais vêm de <c>sTerminaisDoDispositivo</c> e dos terminais das
    ///   **bobinas** do desenho (atributos <c>T*</c> do bloco), cada um com a
    ///   orientação casada pela posição (<c>sOrientacao</c>);
    /// - os **contatos auxiliares** acrescentam até três terminais
    ///   (<c>sT1</c>/<c>sT2</c>/<c>sT3</c>), cada um com a orientação casada.
    /// </summary>
    public static class Contatos4FGerador
    {
        public static List<Contato4F> Gerar(
            IEnumerable<ModeloContato> modelos,
            ICollection<int> modelosEmUso,
            IReadOnlyDictionary<int, IReadOnlyList<ContatoAuxiliar>> auxiliaresPorModelo,
            IReadOnlyDictionary<int, string> terminaisBobinasPorModelo)
        {
            List<Contato4F> linhas = new List<Contato4F>();
            if (modelos == null)
            {
                return linhas;
            }

            foreach (ModeloContato modelo in modelos)
            {
                if (modelosEmUso != null && !modelosEmUso.Contains(modelo.Indice))
                {
                    continue;
                }

                GerarTerminais(linhas, modelo, terminaisBobinasPorModelo);
                GerarAuxiliares(linhas, modelo, auxiliaresPorModelo);
            }

            return linhas;
        }

        private static void GerarTerminais(
            List<Contato4F> linhas,
            ModeloContato modelo,
            IReadOnlyDictionary<int, string> terminaisBobinasPorModelo)
        {
            List<string> terminais = new List<string>();
            List<string> orientacoes = new List<string>();

            // Acumula **sem repetir** (o `DivideTerminais(ref List, ...)` do original):
            // os terminais das bobinas acrescentam ao que veio do modelo, e o que já
            // estava lá não entra de novo.
            Terminais.Acrescentar(terminais, modelo.TerminaisDoDispositivo);

            string orientacao = Limpo(modelo.Orientacao);
            if (orientacao.Length > 0)
            {
                Acrescenta(orientacoes, Terminais.DividirOrientacoes(orientacao));
            }

            string bobinas;
            if (terminaisBobinasPorModelo != null
                && terminaisBobinasPorModelo.TryGetValue(modelo.Indice, out bobinas))
            {
                Terminais.Acrescentar(terminais, bobinas);
            }

            for (int i = 0; i < terminais.Count; i++)
            {
                linhas.Add(new Contato4F
                {
                    IndexModelo = modelo.Indice,
                    NomeModelo = modelo.Nome,
                    Terminal = terminais[i],
                    TerminalNum = TerminalNumerico.Calcular(terminais[i]),
                    Orientacao = i < orientacoes.Count ? orientacoes[i] : string.Empty,
                });
            }
        }

        private static void GerarAuxiliares(
            List<Contato4F> linhas,
            ModeloContato modelo,
            IReadOnlyDictionary<int, IReadOnlyList<ContatoAuxiliar>> auxiliaresPorModelo)
        {
            IReadOnlyList<ContatoAuxiliar> auxiliares;
            if (auxiliaresPorModelo == null || !auxiliaresPorModelo.TryGetValue(modelo.Indice, out auxiliares) || auxiliares == null)
            {
                return;
            }

            foreach (ContatoAuxiliar auxiliar in auxiliares)
            {
                List<string> orientacoes = OrientacoesDoAuxiliar(auxiliar);
                string[] terminais = { auxiliar.T1, auxiliar.T2, auxiliar.T3 };

                for (int i = 0; i < terminais.Length; i++)
                {
                    string terminal = terminais[i];
                    if (string.IsNullOrEmpty(terminal) || terminal.Trim().Length == 0)
                    {
                        continue;
                    }

                    linhas.Add(new Contato4F
                    {
                        IndexModelo = modelo.Indice,
                        NomeModelo = modelo.Nome,
                        Terminal = terminal.Trim(),
                        TerminalNum = TerminalNumerico.Calcular(terminal),
                        Orientacao = orientacoes[i],
                    });
                }
            }
        }

        private static List<string> OrientacoesDoAuxiliar(ContatoAuxiliar auxiliar)
        {
            List<string> orientacoes = Terminais.DividirOrientacoes(Limpo(auxiliar.Orientacao));
            while (orientacoes.Count < 3)
            {
                orientacoes.Add(string.Empty);
            }

            return orientacoes;
        }

        private static void Acrescenta(List<string> destino, List<string> origem)
        {
            foreach (string item in origem)
            {
                destino.Add(item);
            }
        }

        private static string Limpo(string valor)
        {
            return valor == null ? string.Empty : valor.Trim();
        }
    }
}

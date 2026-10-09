using System;
using System.Collections.Generic;
using Positron.Contract;

namespace Positron.Data.Fiacao
{
    /// <summary>Categoria de um problema achado pelo <see cref="VerificadorProjetoFiacao"/>.</summary>
    public enum TipoProblemaFiacao
    {
        /// <summary>Ponto não-borne que terminou sem tag (não casou com dispositivo nem borne).</summary>
        SemTag,

        /// <summary>Terminal com o texto indefinido do original (<c>\"?\"</c>).</summary>
        TerminalIndefinido,

        /// <summary>Potencial ausente ou ≤ 0.</summary>
        PotencialInvalido,

        /// <summary>Mesmo terminal repetido no mesmo <c>(painel, potencial)</c>.</summary>
        TerminalDuplicado,
    }

    /// <summary>Um problema apontado numa linha de <c>Fiacao</c>.</summary>
    public sealed class ProblemaFiacao
    {
        public TipoProblemaFiacao Tipo { get; set; }

        public long? Painel { get; set; }

        public long? Potencial { get; set; }

        public string Terminal { get; set; }

        public string Tag { get; set; }

        public string Handle { get; set; }

        public string Descricao { get; set; }
    }

    /// <summary>
    /// Valida a **fiação projetada** — um primeiro recorte do
    /// <c>frmVerificadorProjetoFiacao</c> do original, que é uma tela grande
    /// (2173 linhas) montada sobre o desenho. Aqui a validação é read-only e olha
    /// o que foi **gravado** em <c>Fiacao</c>, apontando as classes de problema
    /// que os próprios passos de projeção já deixam visíveis:
    ///
    /// - <see cref="TipoProblemaFiacao.SemTag"/> — o ponto não-borne que não achou
    ///   dispositivo (ou o borne sem régua) fica sem <c>Tag</c>;
    /// - <see cref="TipoProblemaFiacao.TerminalIndefinido"/> — o
    ///   <c>CaracterTerminalIndefinido</c> (<c>\"?\"</c>) gravado no terminal;
    /// - <see cref="TipoProblemaFiacao.PotencialInvalido"/> — potencial ≤ 0, que o
    ///   original nem ordena;
    /// - <see cref="TipoProblemaFiacao.TerminalDuplicado"/> — o mesmo terminal no
    ///   mesmo <c>(painel, potencial)</c>, o <c>LFiacaoTTDuplicada</c>.
    ///
    /// A tela original também pinta erros lidos **do desenho** (geometria, páginas
    /// apagadas). Isso não está aqui — depende do ZWCAD e do adapter.
    /// </summary>
    public static class VerificadorProjetoFiacao
    {
        /// <summary>Texto de terminal indefinido do original (<c>CaracterTerminalIndefinido</c>).</summary>
        public const string TerminalIndefinido = "?";

        public static List<ProblemaFiacao> Verificar(IEnumerable<FiacaoRow> linhas)
        {
            List<ProblemaFiacao> problemas = new List<ProblemaFiacao>();
            if (linhas == null)
            {
                return problemas;
            }

            List<FiacaoRow> lista = new List<FiacaoRow>(linhas);

            Dictionary<string, bool> vistos = new Dictionary<string, bool>(StringComparer.Ordinal);
            foreach (FiacaoRow linha in lista)
            {
                if (linha == null)
                {
                    continue;
                }

                if (!linha.Potencial.HasValue || linha.Potencial.Value <= 0)
                {
                    problemas.Add(Novo(TipoProblemaFiacao.PotencialInvalido, linha, "potencial ausente ou <= 0"));
                }

                string terminal = linha.Terminal == null ? null : linha.Terminal.Trim();
                bool indefinido = string.Equals(terminal, TerminalIndefinido, StringComparison.Ordinal);

                if (string.IsNullOrWhiteSpace(linha.Tag))
                {
                    problemas.Add(Novo(TipoProblemaFiacao.SemTag, linha, "ponto sem tag"));
                }
                else if (indefinido)
                {
                    problemas.Add(Novo(TipoProblemaFiacao.TerminalIndefinido, linha, "terminal indefinido"));
                }

                if (!string.IsNullOrEmpty(terminal) && !indefinido)
                {
                    string chave = (linha.Painel ?? 0) + "|" + (linha.Potencial ?? 0) + "|" + terminal;
                    if (vistos.ContainsKey(chave))
                    {
                        problemas.Add(Novo(TipoProblemaFiacao.TerminalDuplicado, linha, "terminal repetido no mesmo potencial"));
                    }
                    else
                    {
                        vistos[chave] = true;
                    }
                }
            }

            return problemas;
        }

        private static ProblemaFiacao Novo(TipoProblemaFiacao tipo, FiacaoRow linha, string descricao)
        {
            return new ProblemaFiacao
            {
                Tipo = tipo,
                Painel = linha.Painel,
                Potencial = linha.Potencial,
                Terminal = linha.Terminal,
                Tag = linha.Tag,
                Handle = linha.Handle,
                Descricao = descricao,
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Positron.Contract;

namespace Positron.Data.Interligacao
{
    /// <summary>Por qual campo do cabo a estatística agrupa (os três radiobuttons da tela).</summary>
    public enum AgrupamentoDeCabos
    {
        Formacao,
        Funcao,
        Trajeto,
    }

    /// <summary>Uma linha da estatística: quantos cabos caem no grupo e a soma dos seus comprimentos.</summary>
    public sealed class LinhaEstatisticaCabos
    {
        public LinhaEstatisticaCabos(int quantidade, string nome, double comprimento)
        {
            Quantidade = quantidade;
            Nome = nome;
            Comprimento = comprimento;
        }

        /// <summary>Quantos cabos do grupo (a coluna <c>#</c>).</summary>
        public int Quantidade { get; }

        /// <summary>O valor do grupo (formação, função ou trajeto).</summary>
        public string Nome { get; }

        /// <summary>A soma dos comprimentos dos cabos do grupo.</summary>
        public double Comprimento { get; }
    }

    /// <summary>
    /// A conta do <c>frmEstatisticaDeCabos</c> (<c>ESTVCABOS</c>), que é o <c>LeTodosOsCabosEmUso</c>
    /// (<c>CDadosAccessInterligacao.cs:266</c>) somado ao <c>Hpgk6bJ1Ce</c> do formulário
    /// (<c>frmEstatisticaDeCabos.cs</c>):
    ///
    /// 1. só entra o cabo que tem **pelo menos uma veia em uso** (<c>Veias.Uso = true</c>), uma
    ///    vez por tag, com o comprimento do cabo;
    /// 2. o valor do grupo vazio (ou nulo) não entra; os valores distintos saem em ordem de
    ///    comparação de texto (o <c>lFormacao.Sort()</c> do original);
    /// 3. para cada valor, <c>Quantidade</c> é quantos cabos em uso têm esse valor e
    ///    <c>Comprimento</c> é a soma dos comprimentos deles. A comparação não diferencia maiúsculas
    ///    (<c>CompareString</c>, <c>TextCompare: true</c>).
    /// </summary>
    public static class EstatisticaDeCabos
    {
        public static IReadOnlyList<LinhaEstatisticaCabos> Calcular(
            IEnumerable<CabosRow> cabos,
            IEnumerable<VeiasRow> veias,
            AgrupamentoDeCabos agrupamento)
        {
            if (cabos == null || veias == null)
            {
                return new List<LinhaEstatisticaCabos>();
            }

            HashSet<string> comVeiaEmUso = new HashSet<string>(
                veias.Where(veia => veia != null && veia.Uso && veia.Tag != null).Select(veia => veia.Tag),
                StringComparer.OrdinalIgnoreCase);

            // Um cabo por tag (o DISTINCT de `list.Contains(tag)` do original): a primeira ocorrência.
            List<CabosRow> emUso = new List<CabosRow>();
            HashSet<string> tagsVistas = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (CabosRow cabo in cabos)
            {
                if (cabo == null || cabo.Tag == null || !comVeiaEmUso.Contains(cabo.Tag))
                {
                    continue;
                }

                if (tagsVistas.Add(cabo.Tag))
                {
                    emUso.Add(cabo);
                }
            }

            List<string> nomes = emUso
                .Select(cabo => ValorDoGrupo(cabo, agrupamento))
                .Where(nome => !string.IsNullOrEmpty(nome))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();
            nomes.Sort(StringComparer.CurrentCulture);

            List<LinhaEstatisticaCabos> linhas = new List<LinhaEstatisticaCabos>();
            foreach (string nome in nomes)
            {
                List<CabosRow> doGrupo = emUso
                    .Where(cabo => string.Equals(ValorDoGrupo(cabo, agrupamento), nome, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                double comprimento = doGrupo.Sum(cabo => cabo.Comprimento ?? 0.0);
                linhas.Add(new LinhaEstatisticaCabos(doGrupo.Count, nome, comprimento));
            }

            return linhas;
        }

        private static string ValorDoGrupo(CabosRow cabo, AgrupamentoDeCabos agrupamento)
        {
            switch (agrupamento)
            {
                case AgrupamentoDeCabos.Funcao:
                    return cabo.Funcao ?? string.Empty;
                case AgrupamentoDeCabos.Trajeto:
                    return cabo.Trajeto ?? string.Empty;
                default:
                    return cabo.Formacao ?? string.Empty;
            }
        }
    }
}

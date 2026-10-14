using System.Collections.Generic;
using System.Linq;
using System.Text;
using Positron.Data.Materiais;

namespace Positron.Data.Interligacao
{
    /// <summary>Uma linha da estimativa: o par de painéis e quantas veias indefinidas o ligam.</summary>
    public sealed class LinhaDaEstimativa
    {
        public LinhaDaEstimativa(int painel1, int painel2, string nome1, string nome2, int quantidade)
        {
            Painel1 = painel1;
            Painel2 = painel2;
            Nome1 = nome1;
            Nome2 = nome2;
            Quantidade = quantidade;
        }

        /// <summary>O menor índice do par (o <c>iPn1</c> do original, já ordenado).</summary>
        public int Painel1 { get; }

        /// <summary>O maior índice do par (o <c>iPn2</c>).</summary>
        public int Painel2 { get; }

        /// <summary>O nome do cadastro para o <see cref="Painel1"/> (<c>"???"</c> fora dele).</summary>
        public string Nome1 { get; }

        /// <summary>O nome do cadastro para o <see cref="Painel2"/>.</summary>
        public string Nome2 { get; }

        /// <summary>Quantas veias indefinidas ligam o par (a coluna <c># VEIAS</c>).</summary>
        public int Quantidade { get; internal set; }
    }

    /// <summary>
    /// A **estimativa de veias livres** (o comando <c>ESTVL</c>, a tela
    /// <c>frmEstimativaVeiasLivres</c>): quantas veias **indefinidas** (<c>NumVeia == -1000</c>)
    /// ligam cada par de painéis — o que falta definir nos cabos. É a soma de duas rotinas do
    /// reverso, as duas sem banco e sem tela:
    ///
    /// 1. <c>clsEditarInterligacao.carregaApenasAsVeiasIndefinidasDoCaderno</c>: cada polyline de
    ///    interligação com a veia indefinida vira uma veia, **menos** a ponta de cabo singelo que só
    ///    tem o painel 2 (<c>Painel1 == 0</c>, <c>Painel2 &gt; 0</c> e <c>Tipo != 3</c>). No
    ///    <c>Tipo == 2</c> o painel que falta vem da polyline apontada pelo handle do XData — e
    ///    vem o <c>Painel2</c> dela nos **dois** casos (é o que o original lê; reproduzido como
    ///    está). Depois ordena por painel 1 decrescente e, no empate, painel 2 crescente.
    /// 2. <c>clsInterligacao.Estimativa</c>: pula a veia com algum painel zero, põe o par em ordem
    ///    (menor, maior) e conta, na ordem em que cada par aparece pela primeira vez.
    ///
    /// O nome de cada painel é o <c>Dicionario.BuscaNomeDoPainel</c> (o cadastro <c>Paineis</c>,
    /// <c>"???"</c> fora dele).
    /// </summary>
    public static class EstimativaDeVeiasLivres
    {
        /// <summary>
        /// Calcula a estimativa. <paramref name="trechos"/> são as polylines de interligação do
        /// desenho na ordem do ModelSpace, cada uma com o próprio handle; o handle do XData de
        /// cada uma é procurado entre elas.
        /// </summary>
        public static IReadOnlyList<LinhaDaEstimativa> Calcular(
            IReadOnlyList<KeyValuePair<string, InterligacaoXData>> trechos,
            IReadOnlyDictionary<int, string> nomesDePaineis)
        {
            List<LinhaDaEstimativa> linhas = new List<LinhaDaEstimativa>();
            if (trechos == null)
            {
                return linhas;
            }

            Dictionary<string, InterligacaoXData> porHandle = new Dictionary<string, InterligacaoXData>(System.StringComparer.OrdinalIgnoreCase);
            foreach (KeyValuePair<string, InterligacaoXData> trecho in trechos)
            {
                if (!string.IsNullOrEmpty(trecho.Key) && trecho.Value != null && !porHandle.ContainsKey(trecho.Key))
                {
                    porHandle[trecho.Key] = trecho.Value;
                }
            }

            List<KeyValuePair<int, int>> veias = new List<KeyValuePair<int, int>>();
            foreach (KeyValuePair<string, InterligacaoXData> trecho in trechos)
            {
                InterligacaoXData ilig = trecho.Value;
                if (ilig == null || ilig.NumVeia != InterligacaoXData.NumVeiaIndefinido)
                {
                    continue;
                }

                if (ilig.Painel1 == 0 && ilig.Painel2 > 0 && ilig.Tipo != 3)
                {
                    continue;
                }

                int painel1 = ilig.Painel1;
                int painel2 = ilig.Painel2;
                if (ilig.Tipo == 2)
                {
                    InterligacaoXData apontada = null;
                    if (!string.IsNullOrEmpty(ilig.Handle))
                    {
                        porHandle.TryGetValue(ilig.Handle, out apontada);
                    }

                    if (apontada != null && ilig.Painel1 == 0)
                    {
                        painel1 = apontada.Painel2;
                    }

                    if (apontada != null && ilig.Painel2 == 0)
                    {
                        painel2 = apontada.Painel2;
                    }
                }

                veias.Add(new KeyValuePair<int, int>(painel1, painel2));
            }

            // O bubble sort do carregaApenasAsVeiasIndefinidasDoCaderno: estável, painel 1
            // decrescente e painel 2 crescente — é ele que decide a ordem das linhas da grade.
            foreach (KeyValuePair<int, int> veia in veias.OrderByDescending(v => v.Key).ThenBy(v => v.Value))
            {
                if (veia.Key == 0 || veia.Value == 0)
                {
                    continue;
                }

                int menor = veia.Key > veia.Value ? veia.Value : veia.Key;
                int maior = veia.Key > veia.Value ? veia.Key : veia.Value;

                LinhaDaEstimativa existente = linhas.FirstOrDefault(l => l.Painel1 == menor && l.Painel2 == maior);
                if (existente != null)
                {
                    existente.Quantidade++;
                    continue;
                }

                linhas.Add(new LinhaDaEstimativa(
                    menor,
                    maior,
                    DispositivoDaListaEdicao.NomeDoPainel(nomesDePaineis, menor),
                    DispositivoDaListaEdicao.NomeDoPainel(nomesDePaineis, maior),
                    1));
            }

            return linhas;
        }

        /// <summary>
        /// O texto do <c>btCopiar</c>: uma linha por par, <c>DE\tPARA\tQUANT</c> e <c>\r\n</c> no
        /// fim de cada uma (o <c>Clipboard.SetText</c> do original).
        /// </summary>
        public static string ParaAreaDeTransferencia(IEnumerable<string[]> linhas)
        {
            StringBuilder texto = new StringBuilder();
            foreach (string[] linha in linhas)
            {
                texto.Append(linha[0]).Append('\t').Append(linha[1]).Append('\t').Append(linha[2]).Append("\r\n");
            }

            return texto.ToString();
        }
    }
}

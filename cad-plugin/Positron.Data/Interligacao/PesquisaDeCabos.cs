using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Positron.Contract;

namespace Positron.Data.Interligacao
{
    /// <summary>Uma linha da grade <c>dgCabos</c>: o cabo e se ele é de outro caderno (a coluna oculta <c>Tipo</c>).</summary>
    public sealed class CaboNaPesquisa
    {
        public CaboNaPesquisa(string tag, bool outroCaderno, bool cabecalho)
        {
            Tag = tag;
            OutroCaderno = outroCaderno;
            Cabecalho = cabecalho;
        }

        public string Tag { get; }

        /// <summary>O <c>bCor</c>: o cabo só aparece em outros DWGs (fundo cinza na grade).</summary>
        public bool OutroCaderno { get; }

        /// <summary>A linha <c>CABOS DE OUTROS CADERNOS</c> (fundo coral), que separa os dois grupos.</summary>
        public bool Cabecalho { get; }
    }

    /// <summary>O fundo de uma veia na grade (o fim do <c>ClsCabos.OrdenaVeias</c>).</summary>
    public enum CorDaVeia
    {
        /// <summary><c>LightBlue</c>: a veia de índice 0 ou -99 (blindagem/terra).</summary>
        Blindagem,

        /// <summary><c>LightGoldenrodYellow</c>.</summary>
        Clara,

        /// <summary><c>LightGray</c>.</summary>
        Escura,
    }

    /// <summary>Uma linha da grade <c>dgVeias</c>.</summary>
    public sealed class VeiaDaPesquisa
    {
        public int Indice { get; internal set; }

        /// <summary>O nome da veia, ou o índice quando ela não tem nome (a coluna "Veias").</summary>
        public string Texto { get; internal set; }

        /// <summary>A página; num cabo de outro caderno, <c>caderno-página</c> quando o DWG tem nome.</summary>
        public string Pagina { get; internal set; }

        /// <summary>O handle em que a grade dá zoom; vazio num cabo de outro caderno.</summary>
        public string Handle { get; internal set; }

        /// <summary>A coluna oculta <c>Ordena</c>, depois do <c>OrdenaVeias</c>.</summary>
        public double Ordem { get; internal set; }

        public CorDaVeia Cor { get; internal set; }
    }

    /// <summary>
    /// A **pesquisa de cabos e veias** (o comando <c>PESQCAB</c>, a tela <c>frmPesquisaCabos</c>),
    /// lida do catálogo <c>Veias</c> do banco do projeto — não do desenho.
    ///
    /// <see cref="Cabos"/> é o construtor da tela (<c>frmPesquisaCabos.cs:227</c>) com o
    /// <c>LeCabosVeiasUsadasCaderno</c>, o <c>LeCabosTodosCabos</c> e o
    /// <c>LeCabosVeiasUsadasOutrosCaderno</c> (<c>CDadosAccessInterligacao.cs:674,791,837</c>);
    /// <see cref="VeiasDoCabo"/> é o <c>CarregaTodasAsVeiasDoCadernoNoDG</c> (<c>:345</c>) sobre o
    /// <c>LeCabosVeiasTodos</c> (<c>:4319</c>) mais o <c>ClsCabos.OrdenaVeias</c> (<c>ClsCabos.cs:1208</c>).
    /// </summary>
    public static class PesquisaDeCabos
    {
        /// <summary>A mMensagem 1638 (<c>Cabos de outros Cadernos</c>) em maiúsculas, como a grade a mostra.</summary>
        public const string CabecalhoOutrosCadernos = "CABOS DE OUTROS CADERNOS";

        /// <summary>
        /// A grade de cabos: primeiro os cabos com veia neste DWG (<paramref name="dwg"/>, o
        /// <c>arqAtivo.Indice</c>); depois, se houver, o cabeçalho e os cabos que só aparecem em
        /// outros DWGs (<c>Arquivo &gt; 0</c>). Cada grupo em ordem de <c>List.Sort</c> (a cultura
        /// corrente, como no original).
        /// </summary>
        public static IReadOnlyList<CaboNaPesquisa> Cabos(IReadOnlyList<VeiasRow> veias, int dwg)
        {
            List<CaboNaPesquisa> cabos = new List<CaboNaPesquisa>();
            if (veias == null)
            {
                return cabos;
            }

            List<string> doCaderno = Distintos(veias.Where(v => v.Arquivo == dwg));
            List<string> outros = Distintos(veias.Where(v => v.Arquivo > 0)).Where(t => !doCaderno.Contains(t)).ToList();
            doCaderno.Sort(StringComparer.CurrentCulture);
            outros.Sort(StringComparer.CurrentCulture);

            // O `CarregaTodasCabosDoCadernoNoDG`: cada tag das veias lidas entra uma vez (o
            // `List.Contains` da grade, que diferencia maiúsculas — e já contém o cabeçalho).
            List<string> naGrade = new List<string>();
            foreach (VeiasRow veia in VeiasDasTags(veias, doCaderno))
            {
                if (!naGrade.Contains(veia.Tag))
                {
                    naGrade.Add(veia.Tag);
                    cabos.Add(new CaboNaPesquisa(veia.Tag, false, false));
                }
            }

            List<VeiasRow> deOutros = VeiasDasTags(veias, outros);
            if (deOutros.Count > 0)
            {
                naGrade.Add(CabecalhoOutrosCadernos);
                cabos.Add(new CaboNaPesquisa(CabecalhoOutrosCadernos, false, true));
                foreach (VeiasRow veia in deOutros)
                {
                    if (!naGrade.Contains(veia.Tag))
                    {
                        naGrade.Add(veia.Tag);
                        cabos.Add(new CaboNaPesquisa(veia.Tag, true, false));
                    }
                }
            }

            return cabos;
        }

        /// <summary>
        /// As veias do cabo escolhido, de **todos** os DWGs, na ordem do <c>OrdenaVeias</c>. Num cabo
        /// deste caderno a linha leva o handle (e o clique dá zoom nela — inclusive a veia que mora em
        /// outro DWG, como no original); num de outro caderno, o handle fica vazio e a página ganha o
        /// nome do DWG (o cadastro <c>DWG</c>) na frente.
        /// </summary>
        public static IReadOnlyList<VeiaDaPesquisa> VeiasDoCabo(
            IReadOnlyList<VeiasRow> veias,
            IReadOnlyDictionary<int, string> nomesDeDwgs,
            CaboNaPesquisa cabo)
        {
            List<VeiaDaPesquisa> linhas = new List<VeiaDaPesquisa>();
            if (veias == null || cabo == null || cabo.Cabecalho)
            {
                return linhas;
            }

            foreach (VeiasRow veia in VeiasDasTags(veias, new[] { cabo.Tag }))
            {
                int indice = (int)(veia.Indice ?? 0);
                string nome = veia.Nome_Veia ?? string.Empty;
                string texto = nome.Length > 0 ? nome : indice.ToString(CultureInfo.InvariantCulture);
                string pagina = veia.Pagina ?? string.Empty;
                string handle = veia.Handle ?? string.Empty;
                if (cabo.OutroCaderno)
                {
                    string caderno;
                    if (nomesDeDwgs == null || !nomesDeDwgs.TryGetValue((int)(veia.Arquivo ?? 0), out caderno))
                    {
                        caderno = string.Empty;
                    }

                    pagina = string.IsNullOrEmpty(caderno) ? pagina : caderno + "-" + pagina;
                    handle = string.Empty;
                }

                linhas.Add(new VeiaDaPesquisa { Indice = indice, Texto = texto, Pagina = pagina, Handle = handle, Ordem = indice });
            }

            OrdenarVeias(linhas);
            return linhas;
        }

        /// <summary>
        /// O <c>ClsCabos.OrdenaVeias</c>: a veia 1 com <c>P</c>/<c>T</c> no nome diz se o cabo é de
        /// pares ou ternas; as veias negativas (a blindagem de cada par/terna) vão para depois do
        /// grupo delas (<c>-n</c> vira <c>n·2 + 0,1</c> ou <c>n·3 + 0,1</c>); <c>-99</c> vira 0 e o
        /// que for menor que -50 sobe 50. Depois um bubble sort crescente e as cores alternadas por
        /// grupo (muda quando a primeira letra muda, ou a cada linha quando o nome é número).
        /// </summary>
        internal static void OrdenarVeias(List<VeiaDaPesquisa> linhas)
        {
            string agrupamento = string.Empty;
            foreach (VeiaDaPesquisa linha in linhas)
            {
                if (Inteiro(linha.Ordem) == 1)
                {
                    if (linha.Texto.Contains("P"))
                    {
                        agrupamento = "P";
                    }

                    if (linha.Texto.Contains("T"))
                    {
                        agrupamento = "T";
                    }
                }

                if (Inteiro(linha.Ordem) == -99)
                {
                    linha.Ordem = 0;
                }

                if (Inteiro(linha.Ordem) < -50)
                {
                    linha.Ordem += 50.0;
                }
            }

            if (agrupamento.Length > 0)
            {
                double fator = agrupamento == "P" ? 2.0 : 3.0;
                foreach (VeiaDaPesquisa linha in linhas)
                {
                    if (linha.Ordem < 0)
                    {
                        linha.Ordem = linha.Ordem * fator - 0.1;
                    }
                }

                foreach (VeiaDaPesquisa linha in linhas)
                {
                    if (Inteiro(linha.Ordem) < 0)
                    {
                        linha.Ordem = -linha.Ordem;
                    }
                }
            }

            for (int l = linhas.Count - 2; l >= 0; l--)
            {
                for (int m = 0; m <= l; m++)
                {
                    if (linhas[m].Ordem > linhas[m + 1].Ordem)
                    {
                        VeiaDaPesquisa troca = linhas[m];
                        linhas[m] = linhas[m + 1];
                        linhas[m + 1] = troca;
                    }
                }
            }

            bool clara = true;
            for (int i = 0; i < linhas.Count; i++)
            {
                if (i > 0)
                {
                    string anterior = linhas[i - 1].Texto;
                    string atual = linhas[i].Texto;
                    if (EhNumero(anterior) || EhNumero(atual)
                        || !string.Equals(PrimeiraLetra(anterior), PrimeiraLetra(atual), StringComparison.CurrentCultureIgnoreCase))
                    {
                        clara = !clara;
                    }
                }

                linhas[i].Cor = linhas[i].Indice == -99 || linhas[i].Indice == 0
                    ? CorDaVeia.Blindagem
                    : (clara ? CorDaVeia.Clara : CorDaVeia.Escura);
            }
        }

        /// <summary>O <c>SELECT DISTINCT(Tag)</c> do Access: sem diferenciar maiúsculas, a primeira grafia.</summary>
        private static List<string> Distintos(IEnumerable<VeiasRow> veias)
        {
            List<string> tags = new List<string>();
            HashSet<string> vistos = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (VeiasRow veia in veias)
            {
                string tag = veia.Tag ?? string.Empty;
                if (vistos.Add(tag))
                {
                    tags.Add(tag);
                }
            }

            return tags;
        }

        /// <summary>
        /// Para cada tag, na ordem dada, o <c>SELECT ... FROM veias WHERE Tag=@tag ORDER BY Indice</c>
        /// (de todos os DWGs; o empate no índice fica na ordem da chave).
        /// </summary>
        private static List<VeiasRow> VeiasDasTags(IReadOnlyList<VeiasRow> veias, IEnumerable<string> tags)
        {
            List<VeiasRow> lidas = new List<VeiasRow>();
            foreach (string tag in tags)
            {
                lidas.AddRange(veias
                    .Where(v => string.Equals(v.Tag ?? string.Empty, tag, StringComparison.OrdinalIgnoreCase))
                    .OrderBy(v => v.Indice)
                    .ThenBy(v => v.Chave));
            }

            return lidas;
        }

        /// <summary>O <c>Conversions.ToInteger</c> de um <c>Double</c>: arredonda para o par mais próximo.</summary>
        private static int Inteiro(double valor)
        {
            return (int)Math.Round(valor);
        }

        /// <summary>O <c>Versioned.IsNumeric</c> de um texto.</summary>
        private static bool EhNumero(string texto)
        {
            double numero;
            return !string.IsNullOrEmpty(texto) && double.TryParse(texto, NumberStyles.Any, CultureInfo.CurrentCulture, out numero);
        }

        private static string PrimeiraLetra(string texto)
        {
            return string.IsNullOrEmpty(texto) ? string.Empty : texto.Substring(0, 1);
        }
    }
}

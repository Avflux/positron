using System;
using System.Collections.Generic;
using Positron.Data.Materiais;
using Positron.Data.Paginas;

namespace Positron.Data.Interligacao
{
    /// <summary>
    /// Uma polyline de interligação como o <c>carregaTodasAsVeiasIndefinidasDoCaderno</c> a lê:
    /// o handle dela, o layer (a página), o canto mínimo da caixa (<c>Bounds.MinPoint</c>) e o
    /// XData.
    /// </summary>
    public sealed class TrechoNoDesenho
    {
        public TrechoNoDesenho(string handle, string layer, double x, double y, InterligacaoXData xdata)
        {
            Handle = handle;
            Layer = layer;
            X = x;
            Y = y;
            XData = xdata;
        }

        public string Handle { get; }

        public string Layer { get; }

        public double X { get; }

        public double Y { get; }

        public InterligacaoXData XData { get; }
    }

    /// <summary>Uma veia indefinida do caderno (o <c>structureVeiasCaderno</c> do original, nos campos que a pesquisa usa).</summary>
    public sealed class VeiaIndefinida
    {
        public string Pagina { get; internal set; }

        public int Painel1 { get; internal set; }

        public int Painel2 { get; internal set; }

        /// <summary>O <c>sHandleCabo1</c>: a polyline em que a pesquisa dá zoom.</summary>
        public string Handle { get; internal set; }

        public int Tipo { get; internal set; }

        /// <summary>O <c>X</c>/<c>Y</c> do original: o canto mínimo da caixa, arredondado para inteiro.</summary>
        public double X { get; internal set; }

        public double Y { get; internal set; }
    }

    /// <summary>Uma linha da grade <c>dgVeiasDWG</c>: <c>#</c>, página, origem, destino e o handle (coluna oculta).</summary>
    public sealed class LinhaDeVeiaIndefinida
    {
        public LinhaDeVeiaIndefinida(int indice, string pagina, string origem, string destino, string handle)
        {
            Indice = indice;
            Pagina = pagina;
            Origem = origem;
            Destino = destino;
            Handle = handle;
        }

        public int Indice { get; }

        public string Pagina { get; }

        public string Origem { get; }

        public string Destino { get; }

        public string Handle { get; }
    }

    /// <summary>
    /// A **pesquisa de veias indefinidas** (o comando <c>PESQC</c>, a tela
    /// <c>frmPesquisaVeiasIndefinidas</c>): toda polyline de interligação com a veia indefinida
    /// (<c>NumVeia == -1000</c>), em ordem de página, para o projetista clicar e ir até ela.
    ///
    /// <see cref="Carregar"/> é o <c>clsEditarInterligacao.carregaTodasAsVeiasIndefinidasDoCaderno</c>
    /// (<c>clsEditarInterligacao.cs:950</c>); <see cref="LinhasDaGrade"/>, o
    /// <c>CarregaTodasAsVeiasDoCadernoNoDG</c> da tela (<c>frmPesquisaVeiasIndefinidas.cs:201</c>).
    /// Difere do <c>carregaApenasAsVeiasIndefinidasDoCaderno</c> da <see cref="EstimativaDeVeiasLivres"/>
    /// no que guarda (página, posição e handle) e na ordem (página, depois a posição na folha).
    /// </summary>
    public static class VeiasIndefinidasDoCaderno
    {
        /// <summary>
        /// As veias indefinidas, na ordem da grade. <paramref name="trechos"/> são todas as polylines
        /// com XData <c>INTERLIGACAO</c> válido, na ordem do ModelSpace.
        /// </summary>
        public static IReadOnlyList<VeiaIndefinida> Carregar(IReadOnlyList<TrechoNoDesenho> trechos)
        {
            List<VeiaIndefinida> veias = new List<VeiaIndefinida>();
            if (trechos == null)
            {
                return veias;
            }

            // O `Geral.HandleToObject(ilig.handle)` do original: a polyline apontada pelo XData.
            Dictionary<string, TrechoNoDesenho> porHandle = new Dictionary<string, TrechoNoDesenho>(StringComparer.OrdinalIgnoreCase);
            foreach (TrechoNoDesenho trecho in trechos)
            {
                if (trecho != null && trecho.XData != null && !string.IsNullOrEmpty(trecho.Handle) && !porHandle.ContainsKey(trecho.Handle))
                {
                    porHandle[trecho.Handle] = trecho;
                }
            }

            foreach (TrechoNoDesenho trecho in trechos)
            {
                InterligacaoXData ilig = trecho == null ? null : trecho.XData;
                if (ilig == null || ilig.NumVeia != InterligacaoXData.NumVeiaIndefinido)
                {
                    continue;
                }

                // A ponta de cabo que só tem o painel 2 fica de fora (menos a superposição, tipo 3).
                if (ilig.Painel1 == 0 && ilig.Painel2 > 0 && ilig.Tipo != 3)
                {
                    continue;
                }

                VeiaIndefinida veia = new VeiaIndefinida
                {
                    Pagina = trecho.Layer,
                    Painel1 = ilig.Painel1,
                    Painel2 = ilig.Painel2,
                    Handle = trecho.Handle,
                    Tipo = ilig.Tipo,
                    X = Math.Round(trecho.X),
                    Y = Math.Round(trecho.Y),
                };

                if (ilig.Tipo == 3 && veia.Painel1 == 0 && veia.Painel2 != 0)
                {
                    veia.Painel1 = veia.Painel2;
                    veia.Painel2 = 0;
                }

                if (ilig.Tipo == 2)
                {
                    TrechoNoDesenho apontado = null;
                    if (!string.IsNullOrEmpty(ilig.Handle))
                    {
                        porHandle.TryGetValue(ilig.Handle, out apontado);
                    }

                    // Os dois ramos leem o **Painel2** da apontada, e o do painel 1 troca também o
                    // handle em que a grade dá zoom — como o original.
                    if (apontado != null && ilig.Painel1 == 0)
                    {
                        veia.Painel1 = apontado.XData.Painel2;
                        veia.Handle = apontado.Handle;
                    }

                    if (apontado != null && ilig.Painel2 == 0)
                    {
                        veia.Painel2 = apontado.XData.Painel2;
                    }
                }

                veias.Add(veia);
            }

            Ordenar(veias);
            return veias;
        }

        /// <summary>
        /// O bubble sort do original, passo a passo: em cada par vizinho, três trocas **em sequência**
        /// (a página em decimal; na mesma página, o Y maior antes; no mesmo Y, o X menor antes). A
        /// "mesma página" compara o texto sem diferenciar maiúsculas — <c>1</c> e <c>001</c> têm o
        /// mesmo decimal mas não são a mesma página para o Y/X.
        /// </summary>
        private static void Ordenar(List<VeiaIndefinida> veias)
        {
            for (int i = veias.Count - 2; i >= 0; i--)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (PaginaNumerada.Decimal(veias[j].Pagina) > PaginaNumerada.Decimal(veias[j + 1].Pagina))
                    {
                        Trocar(veias, j);
                    }

                    if (MesmaPagina(veias[j], veias[j + 1]) && veias[j].Y < veias[j + 1].Y)
                    {
                        Trocar(veias, j);
                    }

                    if (MesmaPagina(veias[j], veias[j + 1]) && veias[j].Y == veias[j + 1].Y && veias[j].X > veias[j + 1].X)
                    {
                        Trocar(veias, j);
                    }
                }
            }
        }

        private static bool MesmaPagina(VeiaIndefinida a, VeiaIndefinida b)
        {
            return string.Equals(a.Pagina ?? string.Empty, b.Pagina ?? string.Empty, StringComparison.OrdinalIgnoreCase);
        }

        private static void Trocar(List<VeiaIndefinida> veias, int j)
        {
            VeiaIndefinida troca = veias[j];
            veias[j] = veias[j + 1];
            veias[j + 1] = troca;
        }

        /// <summary>
        /// As linhas da grade: o <c>#</c> conta de 1, os painéis vão em ordem (menor, maior) e o nome
        /// fora do cadastro (<c>"???"</c>) vira um espaço.
        /// </summary>
        public static IReadOnlyList<LinhaDeVeiaIndefinida> LinhasDaGrade(
            IReadOnlyList<VeiaIndefinida> veias,
            IReadOnlyDictionary<int, string> nomesDePaineis)
        {
            List<LinhaDeVeiaIndefinida> linhas = new List<LinhaDeVeiaIndefinida>();
            if (veias == null)
            {
                return linhas;
            }

            for (int i = 0; i < veias.Count; i++)
            {
                VeiaIndefinida veia = veias[i];
                int menor = veia.Painel1 > veia.Painel2 ? veia.Painel2 : veia.Painel1;
                int maior = veia.Painel1 > veia.Painel2 ? veia.Painel1 : veia.Painel2;
                linhas.Add(new LinhaDeVeiaIndefinida(i + 1, veia.Pagina, Nome(nomesDePaineis, menor), Nome(nomesDePaineis, maior), veia.Handle));
            }

            return linhas;
        }

        private static string Nome(IReadOnlyDictionary<int, string> nomesDePaineis, int painel)
        {
            string nome = DispositivoDaListaEdicao.NomeDoPainel(nomesDePaineis, painel);
            return string.Equals(nome, DispositivoDaListaEdicao.PainelSemCadastro, StringComparison.OrdinalIgnoreCase) ? " " : nome;
        }
    }
}

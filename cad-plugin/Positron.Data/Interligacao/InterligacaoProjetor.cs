using System;
using System.Collections.Generic;
using Positron.Data.Bornes;

namespace Positron.Data.Interligacao
{
    /// <summary>
    /// Mescla os pontos de interligação e grava em <c>Interligacao4</c> — o
    /// equivalente ao <c>ssqypmV1FI</c> + <c>AdicionaItemInterligacao</c> do
    /// original, mas em lote.
    ///
    /// **Regra de mesclagem** (recuperada de <c>frmCompilarInterligacao</c>): a
    /// chave é <c>(Tag_Cabo, Num_Veia)</c> — <c>yHoU3hlYPo</c> procura uma linha
    /// já existente com esse par. Um cabo/veia pode ter mais de uma
    /// <c>LWPOLYLINE</c> (uma por ponta):
    ///
    /// - <c>Tipo == 2</c>: cada polyline contribui com **uma** ponta, decidida
    ///   por <c>Painel1 &gt; 0</c> (ponta 1) ou <c>Painel1 &lt;= 0</c> (ponta 2).
    /// - Outros tipos: a polyline traz as duas pontas e preenche as duas.
    ///
    /// O layer da entidade vira a página da ponta (<c>Pagina1</c>/<c>Pagina2</c>),
    /// como em <c>montaCruzamentoPagina</c> no original.
    ///
    /// **Bornes/terminais.** Com <paramref name="bornes"/>, cada ponta é completada
    /// pelo borne mais próximo (<see cref="CasamentoBorne"/>) — a mesma varredura
    /// da fase 7 aplicada ao <c>Interligacao4</c>. É o <c>pf6UXj3X1f</c> do
    /// original, casando ponto↔borne por posição e layer.
    /// </summary>
    public sealed class InterligacaoProjetor
    {
        private readonly ProjectStore _store;

        public InterligacaoProjetor(ProjectStore store)
        {
            if (store == null)
            {
                throw new ArgumentNullException("store");
            }

            _store = store;
        }

        /// <summary>Projeta os pontos e devolve quantas linhas foram gravadas.</summary>
        public int Projetar(IEnumerable<PontoInterligacao> pontos, ContextoInterligacao contexto)
        {
            return Projetar(pontos, contexto, null, null);
        }

        /// <summary>
        /// Projeta os pontos e devolve quantas linhas foram gravadas. Com
        /// <paramref name="bornes"/>, cada ponta é completada com o borne mais
        /// próximo (terminal, régua, tipo, handle).
        /// </summary>
        public int Projetar(IEnumerable<PontoInterligacao> pontos, ContextoInterligacao contexto, IReadOnlyList<PontoBorne> bornes)
        {
            return Projetar(pontos, contexto, bornes, null);
        }

        /// <summary>Versão completa, com a tabela de deslocamento dos bornes.</summary>
        public int Projetar(
            IEnumerable<PontoInterligacao> pontos,
            ContextoInterligacao contexto,
            IReadOnlyList<PontoBorne> bornes,
            TabelaDeslocamentoBlocos deslocamentos)
        {
            if (pontos == null)
            {
                throw new ArgumentNullException("pontos");
            }

            if (contexto == null)
            {
                throw new ArgumentNullException("contexto");
            }

            List<TrechoInterligacao> linhas = Mesclar(pontos, contexto);
            AplicarBornes(linhas, bornes, deslocamentos);
            _store.InserirInterligacao(linhas);
            return linhas.Count;
        }

        /// <summary>
        /// Casa o borne de cada ponta (<see cref="CasamentoBorne"/>) e preenche as
        /// colunas da ponta. Ponta sem borne dentro da tolerância fica com as
        /// colunas nulas — dado ausente é melhor que dado inventado.
        /// </summary>
        internal static void AplicarBornes(IEnumerable<TrechoInterligacao> linhas, IReadOnlyList<PontoBorne> bornes, TabelaDeslocamentoBlocos deslocamentos)
        {
            if (linhas == null || bornes == null || bornes.Count == 0)
            {
                return;
            }

            foreach (TrechoInterligacao linha in linhas)
            {
                if (linha.TemPonta1)
                {
                    PontoBorne borne = CasamentoBorne.Proximo(
                        linha.X1, linha.Y1, linha.Pagina1, linha.Painel1, bornes, CasamentoBorne.Tolerancia, deslocamentos);
                    if (borne != null)
                    {
                        linha.AplicarBornePonta1(borne);
                    }
                }

                if (linha.TemPonta2)
                {
                    PontoBorne borne = CasamentoBorne.Proximo(
                        linha.X2, linha.Y2, linha.Pagina2, linha.Painel2, bornes, CasamentoBorne.Tolerancia, deslocamentos);
                    if (borne != null)
                    {
                        linha.AplicarBornePonta2(borne);
                    }
                }
            }
        }

        /// <summary>
        /// Mescla os pontos por <c>(Tag_Cabo, Num_Veia)</c> preservando a ordem de
        /// primeira aparição, e completa o contexto em todas as linhas.
        /// </summary>
        internal static List<TrechoInterligacao> Mesclar(IEnumerable<PontoInterligacao> pontos, ContextoInterligacao contexto)
        {
            List<TrechoInterligacao> linhas = new List<TrechoInterligacao>();
            Dictionary<string, TrechoInterligacao> porChave = new Dictionary<string, TrechoInterligacao>();

            foreach (PontoInterligacao ponto in pontos)
            {
                string chave = Chave(ponto);

                TrechoInterligacao linha;
                if (!porChave.TryGetValue(chave, out linha))
                {
                    linha = new TrechoInterligacao
                    {
                        Tag_Cabo = ponto.Tag_Cabo,
                        NumVeia = ponto.NumVeia,
                        NomeVeia = ponto.NomeVeia,
                    };
                    porChave.Add(chave, linha);
                    linhas.Add(linha);
                }

                if (string.IsNullOrEmpty(linha.NomeVeia))
                {
                    linha.NomeVeia = ponto.NomeVeia;
                }

                if (ponto.Tipo == 2)
                {
                    // Cada polyline traz uma ponta: Painel1 > 0 é a ponta 1.
                    if (ponto.Painel1 > 0)
                    {
                        linha.Painel1 = ponto.Painel1;
                        linha.Pagina1 = ponto.Pagina;
                    }
                    else
                    {
                        linha.Painel2 = ponto.Painel2;
                        linha.Pagina2 = ponto.Pagina;
                    }
                }
                else
                {
                    // Um trecho só com as duas pontas conhecidas de uma polyline.
                    if (ponto.Painel1 > 0)
                    {
                        linha.Painel1 = ponto.Painel1;
                        linha.Pagina1 = ponto.Pagina;
                    }

                    if (ponto.Painel2 > 0)
                    {
                        linha.Painel2 = ponto.Painel2;
                        linha.Pagina2 = ponto.Pagina;
                    }
                }

                // Geometria das pontas: independe do painel (o original a guarda
                // mesmo quando o painel é 0). É o que casa com o borne depois.
                if (ponto.TemPonta1)
                {
                    linha.TemPonta1 = true;
                    linha.X1 = ponto.X1;
                    linha.Y1 = ponto.Y1;
                }

                if (ponto.TemPonta2)
                {
                    linha.TemPonta2 = true;
                    linha.X2 = ponto.X2;
                    linha.Y2 = ponto.Y2;
                }
            }

            foreach (TrechoInterligacao linha in linhas)
            {
                linha.Revisao = contexto.Revisao;
                linha.Dwg = contexto.Dwg;
                linha.Data = contexto.Data;
                if (string.IsNullOrWhiteSpace(linha.Criador))
                {
                    linha.Criador = contexto.Criador;
                }
            }

            return linhas;
        }

        private static string Chave(PontoInterligacao ponto)
        {
            // Num_Veia -1000 marca veia indefinida; o original descarta esses trechos.
            return (ponto.Tag_Cabo ?? string.Empty) + "\u0000" + ponto.NumVeia;
        }
    }
}

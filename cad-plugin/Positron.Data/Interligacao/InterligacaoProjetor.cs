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
    /// **Criação de linha** (recuperada de <c>frmCompilarInterligacao</c>): um
    /// cabo/veia pode ter mais de uma <c>LWPOLYLINE</c>, e o tipo do XData decide
    /// se a polyline completa uma linha existente ou anexa uma nova. A chave é
    /// <c>(Tag_Cabo, Num_Veia)</c> — o <c>yHoU3hlYPo</c> do original, que compara
    /// o cabo ignorando caixa:
    ///
    /// - <c>Tipo == 1</c>: a polyline traz as duas pontas — sempre uma linha nova.
    /// - <c>Tipo == 2</c>: cada polyline contribui com **uma** ponta, decidida
    ///   por <c>Painel1 &gt; 0</c> (ponta 1) ou <c>Painel1 &lt;= 0</c> (ponta 2).
    /// - <c>Tipo == 3</c>: só a ponta 2 — sempre uma linha nova (não mescla).
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
            AplicarBornes(linhas, bornes, deslocamentos, contexto.Dwg, contexto.Documento);
            _store.InserirInterligacao(linhas);
            return linhas.Count;
        }

        /// <summary>
        /// Casa o borne de cada ponta (<see cref="CasamentoBorne"/>) e preenche as
        /// colunas da ponta. Ponta sem borne dentro da tolerância fica com as
        /// colunas nulas — dado ausente é melhor que dado inventado.
        /// </summary>
        internal static void AplicarBornes(
            IEnumerable<TrechoInterligacao> linhas,
            IReadOnlyList<PontoBorne> bornes,
            TabelaDeslocamentoBlocos deslocamentos,
            int dwg,
            string documento)
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
                        // O original carimba dwg/documento junto com o resto da
                        // ponta (só quando o bloco casa): arqAtivo.Indice + Conf.Local.
                        linha.AplicarBornePonta1(borne, dwg, documento);
                    }
                }

                if (linha.TemPonta2)
                {
                    PontoBorne borne = CasamentoBorne.Proximo(
                        linha.X2, linha.Y2, linha.Pagina2, linha.Painel2, bornes, CasamentoBorne.Tolerancia, deslocamentos);
                    if (borne != null)
                    {
                        linha.AplicarBornePonta2(borne, dwg, documento);
                    }
                }
            }
        }

        /// <summary>
        /// Mescla os pontos e completa o contexto em todas as linhas. Reproduz a
        /// regra de criação de linhas do original:
        ///
        /// - <c>Tipo == 1</c>: a polyline traz as duas pontas — **sempre** uma
        ///   linha nova (não mescla).
        /// - <c>Tipo == 3</c>: só a ponta 2 (a linha de destino) — **sempre** uma
        ///   linha nova; a ponta 1 fica sem painel/página.
        /// - <c>Tipo == 2</c>: cada polyline traz uma ponta; procura a primeira
        ///   linha do mesmo <c>(Tag_Cabo, Num_Veia)</c> (o <c>yHoU3hlYPo</c>, que
        ///   compara o cabo ignorando caixa) e completa a ponta 1
        ///   (<c>Painel1 &gt; 0</c>) ou a 2. Sem linha, cria uma nova com painel
        ///   <c>-1</c> nas duas pontas.
        /// - Outros tipos: ignorados, como no original.
        /// </summary>
        /// <summary>A página da ponta: a coluna projetada (`Conf.incluirColuna`) ou o layer.</summary>
        private static string PaginaDoPonto(PontoInterligacao ponto)
        {
            return string.IsNullOrEmpty(ponto.PaginaProjetada) ? ponto.Pagina : ponto.PaginaProjetada;
        }

        internal static List<TrechoInterligacao> Mesclar(IEnumerable<PontoInterligacao> pontos, ContextoInterligacao contexto)
        {
            List<TrechoInterligacao> linhas = new List<TrechoInterligacao>();

            foreach (PontoInterligacao ponto in pontos)
            {
                switch (ponto.Tipo)
                {
                    case 1:
                        TrechoInterligacao tipo1 = NovoTrecho(ponto);
                        tipo1.Painel1 = ponto.Painel1;
                        tipo1.Pagina1 = PaginaDoPonto(ponto);
                        tipo1.Painel2 = ponto.Painel2;
                        tipo1.Pagina2 = PaginaDoPonto(ponto);
                        linhas.Add(tipo1);
                        break;

                    case 3:
                        TrechoInterligacao tipo3 = NovoTrecho(ponto);
                        tipo3.Painel2 = ponto.Painel2;
                        tipo3.Pagina2 = PaginaDoPonto(ponto);
                        linhas.Add(tipo3);
                        break;

                    case 2:
                        TrechoInterligacao trecho = Procurar(linhas, ponto);
                        if (trecho == null)
                        {
                            trecho = NovoTrecho(ponto);
                            trecho.Painel1 = -1;
                            trecho.Painel2 = -1;
                            linhas.Add(trecho);
                        }

                        trecho.NomeVeia = ponto.NomeVeia;

                        // A geometria é da polyline que chegou agora, mesmo quando
                        // a linha já existia (a outra ponta veio de outro trecho).
                        AplicarGeometria(trecho, ponto);

                        // Cada polyline traz uma ponta: Painel1 > 0 é a ponta 1.
                        if (ponto.Painel1 <= 0)
                        {
                            trecho.Painel2 = ponto.Painel2;
                            trecho.Pagina2 = PaginaDoPonto(ponto);
                        }
                        else
                        {
                            trecho.Painel1 = ponto.Painel1;
                            trecho.Pagina1 = PaginaDoPonto(ponto);
                        }

                        break;
                }
            }

            foreach (TrechoInterligacao linha in linhas)
            {
                linha.Revisao = contexto.Revisao;
                linha.Dwg = contexto.Dwg;
                linha.Data = contexto.Data;
                linha.Posicao1 = string.Empty;
                linha.Posicao2 = string.Empty;
                if (string.IsNullOrWhiteSpace(linha.Criador))
                {
                    linha.Criador = contexto.Criador;
                }
            }

            return linhas;
        }

        /// <summary>
        /// Linha nova com o que vem do ponto bruto: cabo/veia e a geometria das
        /// pontas (que independe do painel — o original a guarda mesmo quando o
        /// painel é 0). É o que casa com o borne depois.
        /// </summary>
        private static TrechoInterligacao NovoTrecho(PontoInterligacao ponto)
        {
            TrechoInterligacao linha = new TrechoInterligacao
            {
                Tag_Cabo = ponto.Tag_Cabo,
                NumVeia = ponto.NumVeia,
                NomeVeia = ponto.NomeVeia,
            };

            AplicarGeometria(linha, ponto);
            return linha;
        }

        /// <summary>
        /// Copia a posição da(s) ponta(s) que esta polyline fornece. Vale também
        /// para uma linha Tipo 2 já existente: a ponta que faltava chega agora.
        /// </summary>
        private static void AplicarGeometria(TrechoInterligacao linha, PontoInterligacao ponto)
        {
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

        /// <summary>
        /// Primeira linha do mesmo <c>(Tag_Cabo, Num_Veia)</c> — o
        /// <c>yHoU3hlYPo</c> do original (cabo comparado ignorando caixa, a partir
        /// da primeira linha).
        /// </summary>
        private static TrechoInterligacao Procurar(List<TrechoInterligacao> linhas, PontoInterligacao ponto)
        {
            foreach (TrechoInterligacao linha in linhas)
            {
                if (linha.NumVeia == ponto.NumVeia
                    && string.Equals(linha.Tag_Cabo, ponto.Tag_Cabo, StringComparison.OrdinalIgnoreCase))
                {
                    return linha;
                }
            }

            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Positron.Data.Bornes;

namespace Positron.Data.Fiacao
{
    /// <summary>
    /// Grava pontos de fiação na tabela <c>Fiacao</c> — o equivalente ao
    /// <c>AdicionaItemPotencial</c> do original, mas em lote.
    ///
    /// A regra de <c>Ordem</c> é a mesma de <c>frmCompilarFiacao</c>: a sequência
    /// reinicia sempre que o potencial muda, e o original processa as linhas
    /// ordenadas por potencial.
    /// </summary>
    public sealed class FiacaoProjetor
    {
        private readonly ProjectStore _store;

        public FiacaoProjetor(ProjectStore store)
        {
            if (store == null)
            {
                throw new ArgumentNullException("store");
            }

            _store = store;
        }

        /// <summary>Projeta os pontos e devolve quantas linhas foram gravadas.</summary>
        public int Projetar(IEnumerable<PontoFiacao> pontos, ContextoProjecao contexto)
        {
            return Projetar(pontos, contexto, null);
        }

        /// <summary>
        /// Projeta os pontos e devolve quantas linhas foram gravadas. Com
        /// <paramref name="bornes"/>, cada ponto é completado com o borne mais
        /// próximo (<see cref="CasamentoBorne"/>), preenchendo as colunas que a
        /// varredura de bornes fornece.
        /// </summary>
        public int Projetar(IEnumerable<PontoFiacao> pontos, ContextoProjecao contexto, IReadOnlyList<PontoBorne> bornes)
        {
            if (pontos == null)
            {
                throw new ArgumentNullException("pontos");
            }

            if (contexto == null)
            {
                throw new ArgumentNullException("contexto");
            }

            List<PontoFiacao> lista = pontos as List<PontoFiacao> ?? new List<PontoFiacao>(pontos);
            if (bornes != null && bornes.Count > 0)
            {
                foreach (PontoFiacao ponto in lista)
                {
                    PontoBorne borne = CasamentoBorne.Proximo(ponto.X, ponto.Y, ponto.Layer, ponto.Painel, bornes);
                    if (borne != null)
                    {
                        ponto.AplicarBorne(borne);
                    }
                }
            }

            List<PontoFiacao> numerados = Numerar(lista, contexto);
            _store.InserirFiacao(numerados);
            return numerados.Count;
        }

        /// <summary>
        /// Ordena e numera <c>Ordem</c> dentro de cada potencial — a reordenação
        /// do <c>frmCompilarFiacao</c> (o efeito do <c>DataTable.Select</c> +
        /// <c>ReordenaOrdemPotenciais</c>).
        ///
        /// **Chave de ordenação** (a mesma do original): <c>Potencial</c>,
        /// <c>PosicaoNum</c> decrescente (bornes primeiro), <c>dOrdem</c> — o índice
        /// da régua no borne; no não-borne é 0, a aproximação sem a tabela
        /// <c>mPosicao</c> (que no original vem da tela de posições) —,
        /// <c>TerminalNum</c> e <c>Terminal</c>. Só entram pontos com
        /// <c>Potencial &gt; 0</c>, como o filtro do original.
        ///
        /// `OrderBy`/`ThenBy` são estáveis (ao contrário de `List.Sort`), então
        /// empates preservam a ordem de entrada.
        /// </summary>
        internal static List<PontoFiacao> Numerar(IEnumerable<PontoFiacao> pontos, ContextoProjecao contexto)
        {
            List<PontoFiacao> ordenados = pontos
                .Where(ponto => ponto.Potencial > 0)
                .OrderBy(ponto => ponto.Potencial)
                .ThenByDescending(ponto => ponto.PosicaoNum)
                .ThenBy(ponto => ponto.PosicaoNum == 1 ? ponto.IndexModelo : 0)
                .ThenBy(ponto => ponto.TerminalNum)
                .ThenBy(ponto => ponto.Terminal ?? string.Empty, StringComparer.Ordinal)
                .ToList();

            List<PontoFiacao> numerados = new List<PontoFiacao>(ordenados.Count);
            int potencialAtual = 0;
            int ordem = 0;

            foreach (PontoFiacao ponto in ordenados)
            {
                if (ponto.Potencial != potencialAtual)
                {
                    potencialAtual = ponto.Potencial;
                    ordem = 0;
                }

                ordem++;
                ponto.Ordem = ordem;
                ponto.Dwg = contexto.Dwg;
                ponto.Revisao = contexto.Revisao;
                ponto.Data = contexto.Data;
                if (string.IsNullOrWhiteSpace(ponto.Criador))
                {
                    ponto.Criador = contexto.Criador;
                }

                numerados.Add(ponto);
            }

            return numerados;
        }
    }
}

using System;
using System.Collections.Generic;

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
            if (pontos == null)
            {
                throw new ArgumentNullException("pontos");
            }

            if (contexto == null)
            {
                throw new ArgumentNullException("contexto");
            }

            List<TrechoInterligacao> linhas = Mesclar(pontos, contexto);
            _store.InserirInterligacao(linhas);
            return linhas.Count;
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

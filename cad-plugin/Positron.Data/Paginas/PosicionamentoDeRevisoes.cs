using System;
using System.Collections.Generic;

namespace Positron.Data.Paginas
{
    /// <summary>O que o <c>AtualizaRevCompleta</c> do original faz com um bloco de revisão.</summary>
    public enum TipoDaOperacaoDaRevisao
    {
        /// <summary>Regrava o bloco que já está na posição (o ramo "sem alteração" — o <c>JdCp1GqFmnk</c> depois do <c>LK3p1o8pTVH</c>).</summary>
        Atualizar,

        /// <summary>Apaga o bloco da posição (o <c>LK3p1o8pTVH</c>).</summary>
        Apagar,

        /// <summary>Cria o bloco na posição (o <c>JdCp1GqFmnk</c>).</summary>
        Criar,
    }

    /// <summary>Uma operação do posicionamento dos blocos de revisão de uma página.</summary>
    public sealed class OperacaoDaRevisao
    {
        public OperacaoDaRevisao(TipoDaOperacaoDaRevisao tipo, int posicao, RevisaoCompletaDaPagina dados)
        {
            Tipo = tipo;
            Posicao = posicao;
            Dados = dados;
        }

        public TipoDaOperacaoDaRevisao Tipo { get; private set; }

        /// <summary>A posição (1-based) do bloco — o sufixo do nome é <c>Posicao - 1</c>.</summary>
        public int Posicao { get; private set; }

        /// <summary>Os dados do bloco a criar; <c>null</c> quando é um apagar/atualizar por posição.</summary>
        public RevisaoCompletaDaPagina Dados { get; private set; }
    }

    /// <summary>O plano que o adapter aplica a uma página (o corpo do <c>AtualizaRevCompleta</c>).</summary>
    public sealed class PlanoDaRevisaoCompleta
    {
        internal PlanoDaRevisaoCompleta(bool estourou, List<OperacaoDaRevisao> operacoes)
        {
            Estourou = estourou;
            Operacoes = operacoes ?? new List<OperacaoDaRevisao>();
        }

        /// <summary>
        /// O ramo de **estouro**: a revisão nova não cabe na última posição
        /// (<c>Posicao &gt;= maxCapa/maxCorpo</c>) e o original desloca todas as outras uma posição
        /// para baixo, apagando a mais antiga.
        /// </summary>
        public bool Estourou { get; private set; }

        public IReadOnlyList<OperacaoDaRevisao> Operacoes { get; private set; }

        public bool Vazio
        {
            get { return Operacoes.Count == 0; }
        }
    }

    /// <summary>
    /// O posicionamento dos blocos de revisão completa do <c>Revisao.cs</c> do reverso: o laço do
    /// <c>AtualizaRevCompleta</c> com as três decisões — quando há alteração, se cabe uma posição
    /// nova (o <c>Posicao++</c>) ou se é o ramo de **estouro** (<c>Posicao &gt;= maxCapa/maxCorpo</c>,
    /// que apaga os blocos da página, desce cada posição &gt; 1 e cria a nova); e a
    /// **atualização** do bloco que não mudou (o <c>LK3p1o8pTVH</c> + <c>JdCp1GqFmnk</c>).
    ///
    /// A regra é **pura** (só dados): quem aplica no desenho é o <c>RevisoesDoDesenho</c>. O
    /// <c>posicoes</c> é o <c>maxCapa</c>/<c>maxCorpo</c> — o número de posições do formato, que o
    /// original conta pelos atributos <c>REV</c>/<c>REV0..7</c> do bloco de formato.
    /// </summary>
    public static class PosicionamentoDeRevisoes
    {
        /// <summary>
        /// Calcula o plano de uma página. <paramref name="existentes"/> são os blocos de revisão
        /// que **já estão no desenho** na página (cada um com a sua <c>Posicao</c> lida do XData) e
        /// <paramref name="nova"/> é a revisão editada na tela, com <c>Posicao</c> e
        /// <c>RevisaoOriginal</c> vindos do desenho.
        /// </summary>
        public static PlanoDaRevisaoCompleta Calcular(
            RevisaoCompletaDaPagina nova,
            IReadOnlyList<RevisaoCompletaDaPagina> existentes,
            int posicoes)
        {
            List<OperacaoDaRevisao> operacoes = new List<OperacaoDaRevisao>();
            if (nova == null)
            {
                return new PlanoDaRevisaoCompleta(false, operacoes);
            }

            // O original pula a página sem revisão (o `Revisao.Trim() == ""`).
            if (string.IsNullOrEmpty((nova.Revisao ?? string.Empty).Trim()))
            {
                return new PlanoDaRevisaoCompleta(false, operacoes);
            }

            // Sem alteração e já com posição: o original apaga e recria o bloco (o `else` do `AtualizaRevCompleta`).
            bool semAlteracao = nova.Posicao > 0
                && string.Equals(nova.Revisao ?? string.Empty, nova.RevisaoOriginal ?? string.Empty,
                    StringComparison.OrdinalIgnoreCase);
            if (semAlteracao)
            {
                operacoes.Add(new OperacaoDaRevisao(TipoDaOperacaoDaRevisao.Atualizar, nova.Posicao, nova));
                return new PlanoDaRevisaoCompleta(false, operacoes);
            }

            if (nova.Posicao >= posicoes)
            {
                // Não cabe: apaga **todos** os blocos da página, desce um cada posição > 1 e cria a nova.
                if (existentes != null)
                {
                    foreach (RevisaoCompletaDaPagina existente in existentes)
                    {
                        if (existente == null)
                        {
                            continue;
                        }

                        operacoes.Add(new OperacaoDaRevisao(TipoDaOperacaoDaRevisao.Apagar, existente.Posicao, null));
                        if (existente.Posicao > 1)
                        {
                            operacoes.Add(new OperacaoDaRevisao(TipoDaOperacaoDaRevisao.Criar, existente.Posicao - 1, existente));
                        }
                    }
                }

                operacoes.Add(new OperacaoDaRevisao(TipoDaOperacaoDaRevisao.Criar, nova.Posicao, nova));
                return new PlanoDaRevisaoCompleta(true, operacoes);
            }

            // Cabe: a revisão nova entra na posição seguinte, sem deslocar nada (o `Posicao++`).
            RevisaoCompletaDaPagina acrescentada = Copiar(nova);
            acrescentada.Posicao = nova.Posicao + 1;
            operacoes.Add(new OperacaoDaRevisao(TipoDaOperacaoDaRevisao.Criar, acrescentada.Posicao, acrescentada));
            return new PlanoDaRevisaoCompleta(false, operacoes);
        }

        /// <summary>
        /// O número de posições (<c>maxCapa</c>/<c>maxCorpo</c>) contado pelos atributos do bloco
        /// de formato, como o <c>carregaConfiguracaoRevisao</c>: só as tags <c>REV</c>/<c>REV0..7</c>
        /// contam, e por **layer** (a capa ou o <c>-1</c> do corpo).
        /// </summary>
        public static int ContarPosicoes(IReadOnlyList<TagDeAtributo> atributos, string layer)
        {
            if (atributos == null)
            {
                return 0;
            }

            int total = 0;
            foreach (TagDeAtributo atributo in atributos)
            {
                if (atributo == null)
                {
                    continue;
                }

                if (!string.Equals((atributo.Layer ?? string.Empty).Trim(), (layer ?? string.Empty).Trim(),
                        StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                if (EhTagDeRevisao(atributo.Tag))
                {
                    total++;
                }
            }

            return total;
        }

        /// <summary>A tag é <c>REV</c> ou <c>REV0..REV7</c> (sem caixa), como o <c>carregaConfiguracaoRevisao</c>.</summary>
        public static bool EhTagDeRevisao(string tag)
        {
            string texto = (tag ?? string.Empty).Trim().ToUpperInvariant();
            if (texto == "REV")
            {
                return true;
            }

            return texto.Length == 4 && texto.StartsWith("REV", StringComparison.Ordinal)
                && texto[3] >= '0' && texto[3] <= '7';
        }

        private static RevisaoCompletaDaPagina Copiar(RevisaoCompletaDaPagina origem)
        {
            return new RevisaoCompletaDaPagina(
                origem.Pagina,
                origem.Revisao,
                origem.Descricao,
                origem.Data,
                origem.Elaborador,
                origem.Verificador,
                origem.Aprovador,
                origem.Posicao)
            {
                RevisaoOriginal = origem.RevisaoOriginal,
            };
        }
    }

    /// <summary>Uma tag de atributo com o layer onde ela vive (o insumo do <c>ContarPosicoes</c>).</summary>
    public sealed class TagDeAtributo
    {
        public TagDeAtributo(string tag, string layer)
        {
            Tag = tag;
            Layer = layer;
        }

        public string Tag { get; private set; }

        public string Layer { get; private set; }
    }
}

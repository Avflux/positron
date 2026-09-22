using System;
using System.Collections.Generic;
using Positron.Data.Fiacao;

namespace Positron.Data.Layout
{
    /// <summary>
    /// Uma **posição de dispositivo** no layout — equivalente a
    /// <c>structurePosicaoDisp</c> no original (<c>DeclaracoesFiacao</c>).
    ///
    /// É o que dá ao ponto **não-borne** o seu <c>PosicaoNum</c> e a sua ordem na
    /// reordenação: o <c>frmCompilarFiacao</c> casa o ponto por
    /// <c>(painel, tag)</c> e copia <c>posicaoNum</c>/<c>ordem</c>.
    /// </summary>
    public sealed class PosicaoLayout
    {
        public int Painel { get; set; }

        public string Tag { get; set; }

        public int PosicaoNum { get; set; }

        public int Ordem { get; set; }
    }

    /// <summary>
    /// As posições de dispositivo do desenho, indexadas por <c>(painel, tag)</c>.
    ///
    /// No original vêm do dicionário de objetos nomeados:
    /// <c>NamedObjectsDictionary → "CENG_LAYOUT" → {"P"&lt;painel&gt;, "C"&lt;painel&gt;}</c>
    /// — dois <c>Xrecord</c> por painel, lidos em
    /// <c>DicionarioLayout.buscaDicLayoutPainel</c>. Cada <c>Xrecord</c> é uma
    /// lista plana de valores, **5 por posição**; o índice 0 de cada quíntupla é a
    /// <c>tag</c> e a <c>ordem</c> é a sequência (1..N).
    ///
    /// O <c>PosicaoNum</c> depende do sufixo lido: <c>"P"</c> → 3, <c>"C"</c> → 2,
    /// <c>"X"</c> → 3 (como no reverso). O ponto é interpolado no mesmo esquema do
    /// original: sem borne, <c>1</c> é o borne e os não-bornes usam estes valores.
    ///
    /// Contraparte pura: quem lê o dicionário é o adapter do CAD
    /// (<c>LayoutDoDesenho</c>); aqui só se interpreta e consulta.
    /// </summary>
    public sealed class LayoutPosicoes
    {
        /// <summary>Valores por posição no <c>Xrecord</c>.</summary>
        public const int ValoresPorPosicao = 5;

        /// <summary>
        /// O que o <c>BuscaOrdemEquipamento</c> devolve quando o equipamento não está
        /// no layout — o <c>result = 10000</c> do original. Não é "sem ordem": é o
        /// valor gravado em <c>OrdemLay</c> para quem não tem posição no layout.
        /// </summary>
        public const int OrdemEquipamentoAusente = 10000;

        private readonly Dictionary<string, PosicaoLayout> _porChave =
            new Dictionary<string, PosicaoLayout>(StringComparer.Ordinal);

        /// <summary>
        /// As tags de cada painel **na ordem em que aparecem** no dicionário
        /// (<c>"P"&lt;painel&gt;</c> e depois <c>"C"&lt;painel&gt;</c>), já sem
        /// repetição. É a lista que o <c>BuscaOrdemEquipamento</c> monta a cada
        /// chamada para devolver o **índice** do equipamento.
        ///
        /// A repetição sai por comparação **ordinal** — o <c>List(Of String).Contains</c>
        /// do original —, mas a busca é **sem diferenciar maiúsculas**
        /// (<c>TextCompare: true</c>): duas grafias da mesma tag ficam as duas na
        /// lista e a primeira é a que responde.
        /// </summary>
        private readonly Dictionary<int, List<string>> _tagsPorPainel =
            new Dictionary<int, List<string>>();

        public static LayoutPosicoes Vazia
        {
            get { return new LayoutPosicoes(); }
        }

        public bool EstaVazia
        {
            get { return _porChave.Count == 0; }
        }

        /// <summary>Quantas posições a tabela tem.</summary>
        public int NumPosicoes
        {
            get { return _porChave.Count; }
        }

        public static LayoutPosicoes Ler(IEnumerable<PosicaoLayout> posicoes)
        {
            LayoutPosicoes tabela = new LayoutPosicoes();
            if (posicoes == null)
            {
                return tabela;
            }

            foreach (PosicaoLayout posicao in posicoes)
            {
                if (posicao == null || posicao.Tag == null)
                {
                    continue;
                }

                tabela._porChave[Chave(posicao.Painel, posicao.Tag)] = posicao;
                tabela.AnotarTag(posicao.Painel, posicao.Tag);
            }

            return tabela;
        }

        /// <summary>
        /// O <c>OrdemLay</c> de um equipamento: o **índice** da tag na lista do
        /// painel (<c>BuscaOrdemEquipamento</c> do original) ou
        /// <see cref="OrdemEquipamentoAusente"/> quando não está no layout.
        ///
        /// A comparação é sem diferenciar maiúsculas, como o <c>TextCompare: true</c>
        /// do original (a lista, essa, dedupa por ordinal).
        /// </summary>
        public int OrdemEquipamento(int painel, string tag)
        {
            List<string> tags;
            if (tag == null || !_tagsPorPainel.TryGetValue(painel, out tags))
            {
                return OrdemEquipamentoAusente;
            }

            for (int i = 0; i < tags.Count; i++)
            {
                if (string.Equals(tag, tags[i], StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }

            return OrdemEquipamentoAusente;
        }

        private void AnotarTag(int painel, string tag)
        {
            List<string> tags;
            if (!_tagsPorPainel.TryGetValue(painel, out tags))
            {
                tags = new List<string>();
                _tagsPorPainel[painel] = tags;
            }

            if (!tags.Contains(tag))
            {
                tags.Add(tag);
            }
        }

        /// <summary>Posição de um ponto, ou <c>null</c> se o par não está no layout.</summary>
        public PosicaoLayout Buscar(int painel, string tag)
        {
            PosicaoLayout posicao;
            if (tag != null && _porChave.TryGetValue(Chave(painel, tag), out posicao))
            {
                return posicao;
            }

            return null;
        }

        /// <summary>
        /// Interpreta o conteúdo de um <c>Xrecord</c> de painel. <paramref name="pos"/>
        /// é <c>"P"</c>, <c>"C"</c> ou <c>"X"</c>. Valores truncados no fim são
        /// ignorados.
        /// </summary>
        public static List<PosicaoLayout> Interpretar(IReadOnlyList<TypedXData> valores, int painel, string pos)
        {
            List<PosicaoLayout> posicoes = new List<PosicaoLayout>();
            if (valores == null)
            {
                return posicoes;
            }

            int posicaoNum = PosicaoNumeroDe(pos);

            int ordem = 0;
            for (int i = 0; i + ValoresPorPosicao <= valores.Count; i += ValoresPorPosicao)
            {
                ordem++;
                posicoes.Add(new PosicaoLayout
                {
                    Painel = painel,
                    Tag = Texto(valores[i].Valor),
                    PosicaoNum = posicaoNum,
                    Ordem = ordem,
                });
            }

            return posicoes;
        }

        private static int PosicaoNumeroDe(string pos)
        {
            if (string.Equals(pos, "P", StringComparison.OrdinalIgnoreCase))
            {
                return 3;
            }

            if (string.Equals(pos, "C", StringComparison.OrdinalIgnoreCase))
            {
                return 2;
            }

            if (string.Equals(pos, "X", StringComparison.OrdinalIgnoreCase))
            {
                return 3;
            }

            return 0;
        }

        private static string Chave(int painel, string tag)
        {
            return painel + "\u0000" + tag;
        }

        private static string Texto(object valor)
        {
            if (valor == null || valor is DBNull)
            {
                return null;
            }

            string texto = valor as string;
            return texto ?? Convert.ToString(valor);
        }
    }
}

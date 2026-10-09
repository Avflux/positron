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

        private readonly Dictionary<string, PosicaoLayout> _porChave =
            new Dictionary<string, PosicaoLayout>(StringComparer.Ordinal);

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
            }

            return tabela;
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

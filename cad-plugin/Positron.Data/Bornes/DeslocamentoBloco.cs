using System;
using System.Collections.Generic;

namespace Positron.Data.Bornes
{
    /// <summary>
    /// Um **ponto de ligação** de um bloco, relativo à origem do bloco —
    /// equivalente a uma entrada de <c>structurePontosBlocos</c> no original
    /// (<c>mknUzyUVsW</c> na fiação, <c>KmGUFiSNQK</c>).
    ///
    /// No original esses pontos são extraídos das **definições de bloco**: os
    /// vértices das <c>Line</c>/<c>Polyline</c> (e afins) que caem sobre a borda
    /// da bounding-box do bloco. É onde o fio encosta no bloco — não o pé de
    /// inserção. O casamento usa <c>inserção + deslocamento</c> (ver
    /// <see cref="CasamentoBorne"/>).
    /// </summary>
    public sealed class DeslocamentoBloco
    {
        public string Nome { get; set; }

        public double X { get; set; }

        public double Y { get; set; }
    }

    /// <summary>
    /// A tabela de pontos de ligação do desenho, indexada por **nome de bloco**.
    /// Um bloco pode ter mais de um ponto de ligação (um por terminal), então
    /// cada nome mapeia para uma lista.
    ///
    /// Contraparte pura do <c>mknUzyUVsW</c>: quem varre as definições de bloco é
    /// o adapter do CAD (<c>DeslocamentosDoDesenho</c>); aqui só se guarda e
    /// consulta.
    /// </summary>
    public sealed class TabelaDeslocamentoBlocos
    {
        private readonly Dictionary<string, List<DeslocamentoBloco>> _porNome =
            new Dictionary<string, List<DeslocamentoBloco>>(StringComparer.OrdinalIgnoreCase);

        private int _total;

        /// <summary>Tabela vazia — sem pontos de ligação, o casamento usa a inserção.</summary>
        public static TabelaDeslocamentoBlocos Vazia
        {
            get { return new TabelaDeslocamentoBlocos(); }
        }

        public bool EstaVazia
        {
            get { return _porNome.Count == 0; }
        }

        /// <summary>Quantos pontos de ligação a tabela tem (todos os blocos).</summary>
        public int NumPontos
        {
            get { return _total; }
        }

        public static TabelaDeslocamentoBlocos Ler(IEnumerable<DeslocamentoBloco> pontos)
        {
            TabelaDeslocamentoBlocos tabela = new TabelaDeslocamentoBlocos();
            if (pontos == null)
            {
                return tabela;
            }

            foreach (DeslocamentoBloco ponto in pontos)
            {
                if (ponto == null || string.IsNullOrEmpty(ponto.Nome))
                {
                    continue;
                }

                List<DeslocamentoBloco> lista;
                if (!tabela._porNome.TryGetValue(ponto.Nome, out lista))
                {
                    lista = new List<DeslocamentoBloco>();
                    tabela._porNome.Add(ponto.Nome, lista);
                }

                lista.Add(ponto);
                tabela._total++;
            }

            return tabela;
        }

        /// <summary>Pontos de ligação de um bloco; lista vazia se o nome é desconhecido.</summary>
        public IReadOnlyList<DeslocamentoBloco> Buscar(string nome)
        {
            List<DeslocamentoBloco> lista;
            if (!string.IsNullOrEmpty(nome) && _porNome.TryGetValue(nome, out lista))
            {
                return lista;
            }

            return new List<DeslocamentoBloco>();
        }
    }
}

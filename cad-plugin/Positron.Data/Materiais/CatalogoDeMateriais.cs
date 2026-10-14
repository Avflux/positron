using System.Collections.Generic;

namespace Positron.Data.Materiais
{
    /// <summary>
    /// Uma linha do **catálogo de materiais** — a tabela <c>Materiais</c> do banco do projeto, que o
    /// original chama de <c>LM</c>: o código interno, o código do cliente, o modelo, o fabricante e
    /// as duas descrições.
    ///
    /// É o alvo de dois formulários do reverso: o <c>frmGerenciadorMateriais</c> (<c>GERLM</c>) edita
    /// o catálogo e o <c>frmGerenciadorMatIndep</c> (<c>ATINDEP</c>) o consulta para mostrar o
    /// material de cada linha da lista (<c>CarregaListaMateriaisDoDG</c> e <c>CarregaDadosLMMatriz</c>).
    /// </summary>
    public sealed class MaterialDoCatalogo
    {
        /// <summary>A chave da tabela (<c>Materiais.Indice</c>) — o <c>IndiceEL</c> da grade do original.</summary>
        public int Indice { get; set; }

        /// <summary>O código interno (<c>CodigoInterno</c>), que é o que a <c>ListaMateriais</c> guarda em <c>IndiceMaterial</c>.</summary>
        public int CodigoInterno { get; set; }

        public string CodigoCliente { get; set; }

        public string Modelo { get; set; }

        public string Fabricante { get; set; }

        public string DescricaoResumida { get; set; }

        public string DescricaoCompleta { get; set; }
    }

    /// <summary>
    /// O catálogo **indexado pelo código interno** — o mesmo caminho que os dois formulários do
    /// reverso usam para achar o material de uma linha da lista (<c>CarregaDadosLMMatriz</c> monta o
    /// vetor e o <c>ODLpp1Gpc7y</c>/<c>MesclaDGDisp</c> procuram por <c>CodigoInterno</c>, que é o
    /// <c>IndiceMaterial</c> gravado na <c>ListaMateriais</c>).
    /// </summary>
    public static class CatalogoDeMateriais
    {
        /// <summary>
        /// Indexa por <c>CodigoInterno</c>. Um material repetido fica com o **primeiro** — o laço do
        /// original para na primeira ocorrência, e a tabela não tem chave única por código interno.
        /// </summary>
        public static IReadOnlyDictionary<int, MaterialDoCatalogo> Indexar(IEnumerable<MaterialDoCatalogo> materiais)
        {
            Dictionary<int, MaterialDoCatalogo> indice = new Dictionary<int, MaterialDoCatalogo>();
            if (materiais == null)
            {
                return indice;
            }

            foreach (MaterialDoCatalogo material in materiais)
            {
                if (material == null || indice.ContainsKey(material.CodigoInterno))
                {
                    continue;
                }

                indice[material.CodigoInterno] = material;
            }

            return indice;
        }

        /// <summary>O material do código interno, ou <c>null</c> — o <c>carregaMaterial</c> sem lançar.</summary>
        public static MaterialDoCatalogo Buscar(IReadOnlyDictionary<int, MaterialDoCatalogo> catalogo, int codigoInterno)
        {
            if (catalogo == null)
            {
                return null;
            }

            MaterialDoCatalogo material;
            return catalogo.TryGetValue(codigoInterno, out material) ? material : null;
        }
    }
}

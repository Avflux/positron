using System;
using System.Collections.Generic;
using System.Globalization;

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

        /// <summary>
        /// O código interno de um material **novo** — o <c>num</c> do <c>OYXpWrD09De</c> (o clique do
        /// Adiciona Material): o que foi digitado, quando é número; senão o **maior da grade mais
        /// um**, começando em 1.
        ///
        /// O laço do original é reproduzido como está — `num = 1` e, a cada código da grade,
        /// `if (num < codigo) num = codigo + 1`. Com códigos não negativos ele dá o mesmo que
        /// `max + 1`; com a grade vazia, 1. O texto é aceito como número inteiro e, se vier
        /// decimal (o `IsNumeric` do VB), é arredondado (o `ToInteger`).
        /// </summary>
        public static int ProximoCodigo(IEnumerable<int> codigosNaGrade, string digitado)
        {
            int informado;
            if (TentarNumero(digitado, out informado))
            {
                return informado;
            }

            int num = 1;
            if (codigosNaGrade != null)
            {
                foreach (int codigo in codigosNaGrade)
                {
                    if (num < codigo)
                    {
                        num = codigo + 1;
                    }
                }
            }

            return num;
        }

        /// <summary>
        /// O plano de gravação do <c>btSalvar</c> — o corpo do <c>iaGppGHMjAT</c> do original, na
        /// mesma ordem: (1) as linhas **apagadas** na tela (o <c>QH3pp205How</c> do
        /// <c>LNDpWzth4ys</c>) saem primeiro; (2) na ordem da grade, cada linha marcada **`A`**
        /// (acrescentada) vira **remover + adicionar** — é o <c>RemoveMaterial</c> defensivo que o
        /// original faz antes do <c>AdicionaItemMaterial</c>, para o código repetido ser substituído —
        /// e cada linha marcada **`E`** (editada) vira uma edição. Linha sem marca não gera operação.
        /// </summary>
        public static List<OperacaoNoCatalogo> PlanoDeGravacao(
            IEnumerable<LinhaDoCatalogoNaGrade> linhas,
            IEnumerable<int> apagados)
        {
            List<OperacaoNoCatalogo> plano = new List<OperacaoNoCatalogo>();

            if (apagados != null)
            {
                foreach (int codigo in apagados)
                {
                    plano.Add(new OperacaoNoCatalogo
                    {
                        Tipo = TipoDeOperacaoNoCatalogo.Remover,
                        Material = new MaterialDoCatalogo { CodigoInterno = codigo },
                    });
                }
            }

            if (linhas == null)
            {
                return plano;
            }

            foreach (LinhaDoCatalogoNaGrade linha in linhas)
            {
                if (linha == null || string.IsNullOrEmpty(linha.Marca))
                {
                    continue;
                }

                if (EhMarca(linha.Marca, "A"))
                {
                    plano.Add(new OperacaoNoCatalogo
                    {
                        Tipo = TipoDeOperacaoNoCatalogo.Remover,
                        Material = new MaterialDoCatalogo { CodigoInterno = linha.CodigoInterno },
                    });
                    plano.Add(new OperacaoNoCatalogo
                    {
                        Tipo = TipoDeOperacaoNoCatalogo.Adicionar,
                        Material = linha.ParaMaterial(),
                    });
                    continue;
                }

                if (EhMarca(linha.Marca, "E"))
                {
                    plano.Add(new OperacaoNoCatalogo
                    {
                        Tipo = TipoDeOperacaoNoCatalogo.Editar,
                        Material = linha.ParaMaterial(),
                    });
                }
            }

            return plano;
        }

        private static bool TentarNumero(string texto, out int valor)
        {
            valor = 0;
            if (string.IsNullOrEmpty(texto))
            {
                return false;
            }

            string limpo = texto.Trim();
            if (int.TryParse(limpo, NumberStyles.Integer, CultureInfo.InvariantCulture, out valor))
            {
                return true;
            }

            // O `IsNumeric` do VB aceita decimal no campo; o `ToInteger` arredonda. A leitura é
            // pela cultura invariante (o ponto é o separador decimal da ferramenta, como no
            // `XDataNumero`), mas a vírgula do teclado brasileiro também entra.
            double quebrado;
            if (double.TryParse(limpo, NumberStyles.Float, CultureInfo.InvariantCulture, out quebrado)
                || double.TryParse(limpo.Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out quebrado))
            {
                valor = (int)Math.Round(quebrado, MidpointRounding.AwayFromZero);
                return true;
            }

            return false;
        }

        private static bool EhMarca(string marca, string esperada)
        {
            return string.Equals((marca ?? string.Empty).Trim(), esperada, StringComparison.OrdinalIgnoreCase);
        }
    }

    /// <summary>
    /// Uma linha da grade do <c>GERLM</c> no estado em que o <c>btSalvar</c> a lê: os seis campos do
    /// material e a **marca** da coluna <c>Ação</c> — <c>"A"</c> (acrescentada na tela), <c>"E"</c>
    /// (editada na tela) ou vazia (veio do banco).
    /// </summary>
    public sealed class LinhaDoCatalogoNaGrade
    {
        public int CodigoInterno { get; set; }

        public string CodigoCliente { get; set; }

        public string Modelo { get; set; }

        public string Fabricante { get; set; }

        public string DescricaoResumida { get; set; }

        public string DescricaoCompleta { get; set; }

        public string Marca { get; set; }

        /// <summary>A linha como material do catálogo (sem o `Indice`, que é do banco).</summary>
        public MaterialDoCatalogo ParaMaterial()
        {
            return new MaterialDoCatalogo
            {
                CodigoInterno = CodigoInterno,
                CodigoCliente = CodigoCliente ?? string.Empty,
                Modelo = Modelo ?? string.Empty,
                Fabricante = Fabricante ?? string.Empty,
                DescricaoResumida = DescricaoResumida ?? string.Empty,
                DescricaoCompleta = DescricaoCompleta ?? string.Empty,
            };
        }
    }

    /// <summary>O que fazer com a linha do catálogo na gravação (o <c>Adiciona</c>/<c>Edita</c>/<c>Remove</c> do original).</summary>
    public enum TipoDeOperacaoNoCatalogo
    {
        Remover,
        Adicionar,
        Editar,
    }

    /// <summary>Uma operação do plano de gravação, na ordem em que o original a executa.</summary>
    public sealed class OperacaoNoCatalogo
    {
        public TipoDeOperacaoNoCatalogo Tipo { get; set; }

        public MaterialDoCatalogo Material { get; set; }
    }
}

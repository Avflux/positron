using System.Collections.Generic;
using Positron.Data.Materiais;

namespace Positron.Data.Relatorios
{
    /// <summary>Uma linha da **lista de materiais** do <c>frmRelatorio_Materiais</c> (o <c>EXPLM</c>).</summary>
    public sealed class LinhaDaLMDoRelatorio
    {
        /// <summary>O <c>#</c> da grade: a posição da linha na lista (o contador do <c>CarregaGDDisp</c>).</summary>
        public int Sequencia { get; set; }

        /// <summary>A soma das quantidades das linhas do mesmo material.</summary>
        public int Quantidade { get; set; }

        /// <summary>As tags das linhas do mesmo material, unidas por <c>", "</c> (o <c>sOrdem</c> do original).</summary>
        public string Tag { get; set; }

        /// <summary>A descrição do catálogo — a **completa** por padrão, como o <c>RBCompleta</c> da tela.</summary>
        public string Descricao { get; set; }

        public string Modelo { get; set; }

        public string Fabricante { get; set; }

        public string CodigoCliente { get; set; }

        /// <summary>O código interno do material desta linha — o <c>INDEXLM</c> da grade.</summary>
        public int IndiceLM { get; set; }
    }

    /// <summary>
    /// A **lista de materiais** do <c>frmRelatorio_Materiais</c> (o comando <c>EXPLM</c>) — a leitura
    /// e o agrupamento do caminho de **um painel** da tela, que são o <c>CarregaDadosOrdemDispositivos</c>
    /// + o <c>CarregaDadosDispositivosSel</c> + o <c>CarregaGDDisp</c> do original.
    ///
    /// **A montagem, na ordem do original:**
    ///
    /// 1. as linhas da <c>ListaMateriais</c> do painel escolhido, na ordem da **projeção** (a
    ///    <c>Ordem</c> do diagrama, que o <c>COMPLM</c> renumera 1..N por painel) — é a ordem que o
    ///    <c>CarregaDadosOrdemDispositivos</c> devolve e a que a grade <c>dgOrdem</c> mostra;
    /// 2. o agrupamento é por **trechos consecutivos do mesmo material**: uma linha nova começa quando
    ///    o material muda de uma linha para a seguinte, e o material **fora do catálogo** (ou o
    ///    <c>0</c>) sempre começa uma linha nova — é o teste do `Cells[2]` com a cor coral do
    ///    <c>mZGpqsaJEfm</c> (a linha coral é a que o dicionário não resolve);
    /// 3. dentro do trecho, as tags são unidas por <c>", "</c> e as quantidades **somadas** (o
    ///    <c>sOrdem[i].sTag</c> acumulado e o <c>Conversions.ToDouble(quantidade) + ...</c>);
    /// 4. os campos do catálogo (descrição, modelo, fabricante e código do cliente) vêm do material do
    ///    trecho; sem catálogo, saem vazios — menos a descrição, que no original sai do
    ///    <c>CarregaGDDisp</c> como o texto do catálogo **mais um espaço** (`DescCompleta + " "`), quirk
    ///    mantido para o texto da tela ser o de lá;
    /// 5. o <c>#</c> é a posição da linha na lista (o contador do <c>CarregaGDDisp</c>).
    ///
    /// **O que fica de fora, registrado:** o modo **multi-painel** da tela (o <c>ckMultPNDetalhado</c>,
    /// que usa o <c>CarregaDadosDispositivosMultiplosPN</c> e acrescenta uma coluna por painel), a
    /// mesclagem de modelo/fabricante na descrição, o multiplicador de típicos, a ordenação manual das
    /// linhas e a gravação da ordem (<c>btSalvaOrdem</c>) — a ligação da tela desabilita cada um com o
    /// motivo na dica. O relatório <c>materiais</c> do app é o **outro** caminho do original (a
    /// consulta do modo multi, uma linha por material do catálogo): ele e esta regra são dois recortes
    /// da mesma tela, e não a mesma lista.
    /// </summary>
    public static class ListaDeMateriaisDoRelatorio
    {
        /// <summary>
        /// Os painéis que aparecem na <c>ListaMateriais</c> do desenho — a coluna <c>dgEquipamentos</c>
        /// (o <c>CarregaDadosEquipamentos</c> do original), sem repetição e na ordem da projeção.
        /// </summary>
        public static List<int> Paineis(IEnumerable<LinhaListaMaterial> linhas)
        {
            List<int> paineis = new List<int>();
            if (linhas == null)
            {
                return paineis;
            }

            foreach (LinhaListaMaterial linha in linhas)
            {
                if (linha.Painel != 0 && !paineis.Contains(linha.Painel))
                {
                    paineis.Add(linha.Painel);
                }
            }

            return paineis;
        }

        /// <summary>
        /// As linhas da lista de materiais do painel escolhido, já agrupadas — a grade
        /// <c>dgListaMateriais</c> da tela. <paramref name="descricaoCompleta"/> é o
        /// <c>RBCompleta</c>/<c>RBResumida</c> da tela (o padrão do designer é a completa).
        /// </summary>
        public static List<LinhaDaLMDoRelatorio> Montar(
            IEnumerable<LinhaListaMaterial> linhas,
            IReadOnlyDictionary<int, MaterialDoCatalogo> catalogo,
            int painel,
            bool descricaoCompleta)
        {
            List<LinhaDaLMDoRelatorio> lista = new List<LinhaDaLMDoRelatorio>();
            if (linhas == null)
            {
                return lista;
            }

            int anterior = -1;
            LinhaDaLMDoRelatorio atual = null;
            foreach (LinhaListaMaterial linha in linhas)
            {
                if (linha == null || linha.Painel != painel)
                {
                    continue;
                }

                MaterialDoCatalogo material = null;
                if (catalogo != null)
                {
                    catalogo.TryGetValue(linha.IndiceMaterial, out material);
                }

                bool mesmoMaterial = atual != null
                    && anterior == linha.IndiceMaterial
                    && material != null;

                if (!mesmoMaterial)
                {
                    atual = new LinhaDaLMDoRelatorio
                    {
                        Sequencia = lista.Count + 1,
                        Quantidade = 0,
                        Tag = string.Empty,
                        Descricao = Descricao(material, descricaoCompleta),
                        Modelo = material == null ? string.Empty : Texto(material.Modelo),
                        Fabricante = material == null ? string.Empty : Texto(material.Fabricante),
                        CodigoCliente = material == null ? string.Empty : Texto(material.CodigoCliente),
                        IndiceLM = linha.IndiceMaterial,
                    };

                    lista.Add(atual);
                    anterior = linha.IndiceMaterial;
                }

                atual.Tag = atual.Tag.Length == 0 ? Texto(linha.Tag) : atual.Tag + ", " + Texto(linha.Tag);
                atual.Quantidade += linha.Quantidade;
            }

            return lista;
        }

        /// <summary>
        /// A descrição da linha como o <c>CarregaGDDisp</c> a monta: a completa (ou a resumida, no
        /// <c>RBResumida</c>) **mais um espaço** — o original concatena o espaço e ele fica no texto da
        /// célula.
        /// </summary>
        private static string Descricao(MaterialDoCatalogo material, bool descricaoCompleta)
        {
            if (material == null)
            {
                return string.Empty;
            }

            string texto = descricaoCompleta ? material.DescricaoCompleta : material.DescricaoResumida;
            return Texto(texto) + " ";
        }

        private static string Texto(string valor)
        {
            return valor ?? string.Empty;
        }
    }
}

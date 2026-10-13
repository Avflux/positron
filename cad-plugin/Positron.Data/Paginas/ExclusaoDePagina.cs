using System.Collections.Generic;

namespace Positron.Data.Paginas
{
    /// <summary>
    /// A **exclusão de uma página** — o <c>Pagina.ApagarElementosPagina</c> do reverso (o item
    /// "Excluir Páginas" do menu das folhas). O original apaga **toda** entidade do ModelSpace cujo
    /// layer é o da página e deixa o layer (o recoder apaga o layer junto: uma página sem elementos
    /// não é página nenhuma — a decisão está registrada no RUNBOOK).
    ///
    /// O que é puro: **quais páginas podem ser apagadas**. A regra recusa o nome vazio e o que não
    /// passa no <see cref="PaginasDoCaderno.LayerValido"/> (o mesmo crivo que lê o caderno), e é
    /// isso que impede um <c>POSITRON_PAGINA</c> torto de apagar os elementos de outra camada.
    /// </summary>
    public static class ExclusaoDePagina
    {
        /// <summary>Motivo da recusa, ou <c>null</c> quando a página pode ser apagada.</summary>
        public static string Recusa(string pagina, IReadOnlyList<string> paginas)
        {
            string nome = (pagina ?? string.Empty).Trim();
            if (nome.Length == 0)
            {
                return "o nome da página está vazio";
            }

            if (!PaginasDoCaderno.LayerValido(nome))
            {
                return "\"" + nome + "\" não é um layer de página (o LayerValido recusa)";
            }

            if (paginas != null && paginas.Count > 0)
            {
                foreach (string candidata in paginas)
                {
                    if (string.Equals(candidata, nome, System.StringComparison.OrdinalIgnoreCase))
                    {
                        return null;
                    }
                }

                return "\"" + nome + "\" não está entre as páginas do caderno";
            }

            return null;
        }
    }
}

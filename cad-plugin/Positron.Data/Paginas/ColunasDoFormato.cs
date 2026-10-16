using System;
using System.Collections.Generic;

namespace Positron.Data.Paginas
{
    /// <summary>
    /// Uma **coluna do formato** — uma das cinco que o `Inserir` da paleta das folhas oferece. O par
    /// vem do `Pagina.verificaLayerExtraNoFormato` do reverso (`Pagina.cs:2315-2412`): a **visibilidade**
    /// e o **nome legível** saem da tabela de layers do desenho (o sufixo depois de `ELETn_`) e o
    /// **tipo** é o nome inteiro do layer, que é o que o `Pagina.InserirColuna` procura na definição
    /// do bloco de formato para clonar (`Pagina.cs:2415`).
    /// </summary>
    public sealed class ColunaDoFormato
    {
        internal ColunaDoFormato(int indice, bool visivel, string nome)
        {
            Indice = indice;
            Visivel = visivel;
            Nome = nome ?? string.Empty;
        }

        /// <summary>O número da coluna (1..5), o `n` do `ToolStripMenuItemN`/`bELETn` do original.</summary>
        public int Indice { get; private set; }

        /// <summary>Há um layer `ELETn_*` no desenho (o `bELETn` do original).</summary>
        public bool Visivel { get; private set; }

        /// <summary>O que o usuário lê no sub-item do `Inserir` (o `sELETn`, sem o prefixo).</summary>
        public string Nome { get; private set; }

        /// <summary>O layer da coluna na definição do bloco de formato (`"ELETn_" + Nome`).</summary>
        public string Tipo
        {
            get { return Visivel ? ColunasDoFormato.Prefixo(Indice) + Nome : string.Empty; }
        }

        public override string ToString()
        {
            return Indice + "=" + (Visivel ? Tipo : "(sem layer)");
        }
    }

    /// <summary>
    /// As **cinco colunas** que o `Inserir` do menu das folhas oferece — o
    /// `Pagina.verificaLayerExtraNoFormato` do reverso (`Pagina.cs:2315-2412`).
    ///
    /// A rotina do original varre a **tabela de layers** e, para cada nome que começa com
    /// `ELET1_`..`ELET5_`, liga o `bELETn` e guarda o **resto do nome** (`name.Remove(0, 6)`) como o
    /// texto do sub-item. Quirk mantido: quem decide é a **ordem da enumeração** — com dois layers
    /// `ELET1_*`, o último lido é o que fica.
    ///
    /// O original **sai antes** de varrer quando o desenho não tem o bloco de formato
    /// (`DeclaracoesGeral.blockFormatoID.IsValid`, `Pagina.cs:2338`); quem chama passa <c>null</c>
    /// nesse caso (é o que o adapter do plugin faz), e as cinco saem invisíveis.
    /// </summary>
    public static class ColunasDoFormato
    {
        /// <summary>Quantas colunas o `Inserir` do original oferece (os cinco `ToolStripMenuItemN`).</summary>
        public const int Quantidade = 5;

        /// <summary>O prefixo do layer da coluna: `ELET1_`..`ELET5_`.</summary>
        public static string Prefixo(int indice)
        {
            return "ELET" + indice + "_";
        }

        /// <summary>As cinco colunas, na ordem do original (1..5).</summary>
        public static IReadOnlyList<ColunaDoFormato> DosLayers(IReadOnlyList<string> layers)
        {
            string[] nomes = new string[Quantidade];
            bool[] visiveis = new bool[Quantidade];
            for (int i = 0; i < Quantidade; i++)
            {
                nomes[i] = string.Empty;
            }

            if (layers != null)
            {
                foreach (string layer in layers)
                {
                    if (string.IsNullOrEmpty(layer))
                    {
                        continue;
                    }

                    for (int indice = 1; indice <= Quantidade; indice++)
                    {
                        string prefixo = Prefixo(indice);
                        if (layer.StartsWith(prefixo, StringComparison.OrdinalIgnoreCase))
                        {
                            visiveis[indice - 1] = true;
                            nomes[indice - 1] = layer.Substring(prefixo.Length);
                        }
                    }
                }
            }

            List<ColunaDoFormato> colunas = new List<ColunaDoFormato>(Quantidade);
            for (int i = 0; i < Quantidade; i++)
            {
                colunas.Add(new ColunaDoFormato(i + 1, visiveis[i], nomes[i]));
            }

            return colunas;
        }

        /// <summary>
        /// Alguma coluna visível? É o que decide a visibilidade do item `Inserir` **inteiro** no
        /// original (`uscPaginas.cs:1390-1393`): sem nenhuma coluna, o submenu não aparece.
        /// </summary>
        public static bool TemAlguma(IReadOnlyList<ColunaDoFormato> colunas)
        {
            if (colunas == null)
            {
                return false;
            }

            foreach (ColunaDoFormato coluna in colunas)
            {
                if (coluna != null && coluna.Visivel)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

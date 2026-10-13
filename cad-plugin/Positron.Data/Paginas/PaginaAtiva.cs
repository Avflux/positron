using System;
using System.Collections.Generic;

namespace Positron.Data.Paginas
{
    /// <summary>O que acontece com um layer quando uma página é ativada.</summary>
    public enum PapelDoLayerNaAtivacao
    {
        /// <summary>É a página ativada: fica ligada e vira a camada corrente.</summary>
        Pagina,

        /// <summary>
        /// O layer `0` e, quando a página pedida **não** é a capa, o `-1` (o layer do formato do
        /// corpo): ficam ligados.
        /// </summary>
        Mantido,

        /// <summary>Todo o resto — a capa inclusive, quando a página é outra: fica **desligado**.</summary>
        Fora,
    }

    /// <summary>
    /// A **página ativa** — a fatia 5 da frente 10: o `LocalizaPaginaAtiva` (qual página o desenho
    /// está mostrando), o `checaCapa` (quais nomes de layer são a capa) e a decisão por layer do
    /// `AtivaPagina` do `Pagina.cs` do reverso.
    ///
    /// O `AtivaPagina` do original (`Pagina.cs:1243`) percorre a tabela de layers e, para cada
    /// um, decide o `IsOff`: a página pedida fica ligada e vira a `Clayer` (a camada corrente do
    /// desenho); ficam ligados também o layer `0` e o `right = checaCapa(pagina) ? pagina : "-1"`
    /// — ou seja, o **`-1`** (o layer do formato do corpo, o mesmo que o `Pagina.cs:1051` trata
    /// junto com a capa) quando a página **não** é a capa; **todo o resto desliga, a capa
    /// inclusive**. É por isso que abrir uma página esconde as outras — o desenho passa a mostrar
    /// só a folha escolhida com o seu formato.
    ///
    /// A comparação de nome é sem caixa (o `TextCompare` do original). O original **não** tem
    /// guarda de nome: quem chama decide (o `ATIVAPAGINA` recusa o que não é do caderno; o
    /// `EncontraHandle` ativa o layer da entidade, como lá).
    /// </summary>
    public static class PaginaAtiva
    {
        /// <summary>
        /// Os nomes de layer que o `checaCapa` do original aceita como **capa**: o `1` e as
        /// variantes com zeros à esquerda, uma por largura fixa de página (7 posições).
        /// </summary>
        public static readonly IReadOnlyList<string> Capas =
            new List<string> { "1", "001", "0001", "00001", "000001", "0000001" };

        /// <summary>O layer de formato que acompanha as páginas do corpo (o `"-1"` do `AtivaPagina`).</summary>
        public const string LayerDoFormatoDoCorpo = "-1";

        /// <summary>O layer é a **capa**? (o `checaCapa`, sem caixa).</summary>
        public static bool ChecaCapa(string layer)
        {
            string texto = (layer ?? string.Empty).Trim();
            foreach (string capa in Capas)
            {
                if (string.Equals(texto, capa, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// A página ativa: a `Clayer` do desenho quando ela é uma página (`LayerValido`); o
        /// **vazio** quando o desenho está numa camada que não é página — é o estado que o
        /// `retornaNumeroCapa` do original cobre ao perguntar pela capa depois.
        /// </summary>
        public static string Localiza(string layerCorrente)
        {
            string layer = (layerCorrente ?? string.Empty).Trim();
            return PaginasDoCaderno.LayerValido(layer) ? layer : string.Empty;
        }

        /// <summary>
        /// O papel do layer na ativação da página pedida: a própria página, mantido ligado
        /// (o `0` e o formato do corpo) ou fora.
        /// </summary>
        public static PapelDoLayerNaAtivacao Papel(string layer, string pagina)
        {
            string nome = (layer ?? string.Empty).Trim();
            string alvo = (pagina ?? string.Empty).Trim();

            if (nome.Length > 0 && string.Equals(nome, alvo, StringComparison.OrdinalIgnoreCase))
            {
                return PapelDoLayerNaAtivacao.Pagina;
            }

            // O `right` do original: a própria página quando ela é a capa (já coberta acima),
            // senão o `-1`.
            string formato = ChecaCapa(alvo) ? alvo : LayerDoFormatoDoCorpo;
            if (string.Equals(nome, "0", StringComparison.OrdinalIgnoreCase)
                || string.Equals(nome, formato, StringComparison.OrdinalIgnoreCase))
            {
                return PapelDoLayerNaAtivacao.Mantido;
            }

            return PapelDoLayerNaAtivacao.Fora;
        }

        /// <summary>
        /// O papel de cada layer da tabela, na ordem em que veio — o que o adapter aplica
        /// (`IsOff`) e o que a medição imprime.
        /// </summary>
        public static IReadOnlyList<PapelDoLayerNaAtivacao> Plano(string pagina, IReadOnlyList<string> layers)
        {
            List<PapelDoLayerNaAtivacao> papeis = new List<PapelDoLayerNaAtivacao>();
            if (layers == null)
            {
                return papeis;
            }

            foreach (string layer in layers)
            {
                papeis.Add(Papel(layer, pagina));
            }

            return papeis;
        }
    }
}

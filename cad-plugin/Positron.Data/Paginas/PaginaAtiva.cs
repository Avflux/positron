using System;
using System.Collections.Generic;

namespace Positron.Data.Paginas
{
    /// <summary>O que acontece com um layer quando uma página é ativada.</summary>
    public enum PapelDoLayerNaAtivacao
    {
        /// <summary>É a página ativada: fica ligada e vira a camada corrente.</summary>
        Pagina,

        /// <summary>Uma das capas (`1`..`1` com zeros, o `checaCapa`): fica ligada.</summary>
        Capa,

        /// <summary>Não é página nem capa: fica **desligada** (o isolamento do original).</summary>
        Fora,
    }

    /// <summary>
    /// A **página ativa** — a fatia 5 da frente 10: o `LocalizaPaginaAtiva` (qual página o desenho
    /// está mostrando), o `checaCapa` (quais nomes de layer são a capa) e a decisão por layer do
    /// `AtivaPagina` do `Pagina.cs` do reverso.
    ///
    /// O `AtivaPagina` do original percorre a tabela de layers e, para cada um, decide o `IsOff`:
    /// a página pedida fica ligada e vira a `Clayer` (a camada corrente do desenho); o layer
    /// `0` e a capa ficam ligados; **todo o resto desliga**. É por isso que abrir uma página
    /// esconde as outras — o desenho passa a mostrar só a folha escolhida.
    ///
    /// A comparação de nome é sem caixa (o `TextCompare` do original); a guarda do nome de layer
    /// (`Pagina` vazia ou que não passa no `LayerValido`) é do adapter.
    /// </summary>
    public static class PaginaAtiva
    {
        /// <summary>
        /// Os nomes de layer que o `checaCapa` do original aceita como **capa**: o `1` e as
        /// variantes com zeros à esquerda, uma por largura fixa de página (7 posições).
        /// </summary>
        public static readonly IReadOnlyList<string> Capas =
            new List<string> { "1", "001", "0001", "00001", "000001", "0000001" };

        /// <summary>O layer é a **capa**? (o `checaCapa`, sem caixa).</summary>
        public static bool EhCapa(string layer, IReadOnlyList<string> capas)
        {
            if (capas == null)
            {
                return false;
            }

            string texto = (layer ?? string.Empty).Trim();
            foreach (string capa in capas)
            {
                if (string.Equals(texto, capa ?? string.Empty, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>O layer é a capa, na lista padrão do original (`ChecaCapa`).</summary>
        public static bool ChecaCapa(string layer)
        {
            return EhCapa(layer, Capas);
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
        /// O papel do layer na ativação da página pedida: a própria página, uma capa ou fora.
        /// </summary>
        public static PapelDoLayerNaAtivacao Papel(string layer, string pagina, IReadOnlyList<string> capas)
        {
            string nome = (layer ?? string.Empty).Trim();
            string alvo = (pagina ?? string.Empty).Trim();

            if (nome.Length > 0 && string.Equals(nome, alvo, StringComparison.OrdinalIgnoreCase))
            {
                return PapelDoLayerNaAtivacao.Pagina;
            }

            if (string.Equals(nome, "0", StringComparison.OrdinalIgnoreCase) || EhCapa(nome, capas))
            {
                return PapelDoLayerNaAtivacao.Capa;
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
                papeis.Add(Papel(layer, pagina, Capas));
            }

            return papeis;
        }
    }
}

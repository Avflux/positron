using System;
using System.Collections.Generic;

namespace Positron.Data.Correcoes
{
    /// <summary>A cor de um atributo na **definição** do bloco.</summary>
    public sealed class CorDeAtributo
    {
        public string NomeBloco { get; set; }

        public string Tag { get; set; }

        public short Cor { get; set; }
    }

    /// <summary>
    /// O <c>CorrigeCoresDosBlocos</c> do <c>Correcao.cs</c> — a cor dos **atributos das
    /// referências** passa a ser a que está na **definição** do bloco (frente 2 do §7.6).
    ///
    /// O original faz três passadas:
    ///
    /// 1. <c>carregaBlocosInseridos</c> — os **nomes** dos blocos inseridos no ModelSpace
    ///    que têm **algum** XData;
    /// 2. <c>MMg1xjoRaA</c> — para cada nome, varre a **definição** (`BlockTable[nome]`) e
    ///    guarda a cor de cada <c>AttributeDefinition</c>;
    /// 3. <c>lu61bhmRNc</c> — para cada inserção cujo nome entra na lista, acerta a cor
    ///    de cada atributo com a da definição.
    ///
    /// **Quirk reproduzido:** a lista da passada 1 guarda o nome **como está** e a passada
    /// 3 compara com <c>nome.ToUpper()</c> — o original só acerta os blocos cujo nome já
    /// está em caixa alta. A comparação do **tag** é sem caixa.
    /// </summary>
    public static class CorrecaoDasCoresDosBlocos
    {
        /// <summary>
        /// O <c>P_1.Contains(val6.Name.ToUpper())</c> do original: o nome do bloco em caixa
        /// alta tem que estar na lista (que guarda o nome cru).
        /// </summary>
        public static bool BlocoEntra(IReadOnlyCollection<string> nomes, string nomeDoBloco)
        {
            if (nomes == null || nomeDoBloco == null)
            {
                return false;
            }

            string alvo = nomeDoBloco.ToUpperInvariant();
            foreach (string nome in nomes)
            {
                if (string.Equals(nome, alvo, StringComparison.Ordinal))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// A cor que o atributo <paramref name="tag"/> deve ter — a da definição do bloco
        /// (nome sem caixa e tag sem caixa, como no original), ou <c>null</c> quando não há
        /// definição para o par.
        /// </summary>
        public static short? CorDoAtributo(
            IReadOnlyList<CorDeAtributo> cores,
            string nomeDoBloco,
            string tag)
        {
            if (cores == null)
            {
                return null;
            }

            string bloco = nomeDoBloco ?? string.Empty;
            string etiqueta = tag ?? string.Empty;
            foreach (CorDeAtributo cor in cores)
            {
                if (cor == null)
                {
                    continue;
                }

                if (string.Equals(cor.NomeBloco ?? string.Empty, bloco, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(cor.Tag ?? string.Empty, etiqueta, StringComparison.OrdinalIgnoreCase))
                {
                    return cor.Cor;
                }
            }

            return null;
        }
    }
}

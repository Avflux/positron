using System;
using System.Collections.Generic;

namespace Positron.Data.Correcoes
{
    /// <summary>
    /// O <c>clsPortas.LimpaPorta</c> do reverso — o que o <c>IndefineUmaPorta</c> roda depois de
    /// zerar o XData da porta (frente 2 do §7.6, a cauda da pendência da rodada 87).
    ///
    /// As regras, na ordem do original:
    ///
    /// 1. com <c>bLimpaTudo</c>, **todo** atributo é esvaziado primeiro;
    /// 2. as tags **protegidas** — <c>NOME1</c>, <c>NOME2</c>, <c>ALTERNATIVO</c>, <c>PAINEL</c>,
    ///    <c>MODELO</c> e <c>FABRICANTE</c> — ficam como o passo 1 deixou;
    /// 3. as tags de terminal/borne (<c>T</c> ou <c>B</c> seguidas de número) recebem o
    ///    **caracter de terminal indefinido**;
    /// 4. qualquer outra tag é esvaziada.
    ///
    /// A comparação das tags é sem caixa, como no <c>TextCompare</c> do original.
    /// </summary>
    public static class LimpezaDaPorta
    {
        /// <summary>As tags que o original não toca depois do esvaziamento inicial.</summary>
        private static readonly string[] Protegidas = new[]
        {
            "NOME1", "NOME2", "ALTERNATIVO", "PAINEL", "MODELO", "FABRICANTE",
        };

        /// <summary>
        /// O valor que o atributo <paramref name="tag"/> recebe na limpeza — ou <c>null</c>
        /// quando o original **não mexe** (tag protegida com <paramref name="limpaTudo"/> falso).
        /// </summary>
        public static string ValorDoAtributoLimpo(string tag, bool limpaTudo, string caracterTerminalIndefinido)
        {
            string etiqueta = tag ?? string.Empty;
            string valor = limpaTudo ? string.Empty : null;

            if (Protegida(etiqueta))
            {
                return valor;
            }

            return TerminalOuBorne(etiqueta) ? (caracterTerminalIndefinido ?? string.Empty) : string.Empty;
        }

        /// <summary>Diz se a tag é uma das protegidas (sem caixa).</summary>
        public static bool Protegida(string tag)
        {
            string etiqueta = tag ?? string.Empty;
            foreach (string protegida in Protegidas)
            {
                if (string.Equals(etiqueta, protegida, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>A tag é <c>T</c> ou <c>B</c> seguida de número (o <c>IsNumeric(Mid(tag, 2))</c>)?</summary>
        public static bool TerminalOuBorne(string tag)
        {
            string etiqueta = tag ?? string.Empty;
            if (etiqueta.Length < 2)
            {
                return false;
            }

            string inicial = etiqueta.Substring(0, 1).ToUpperInvariant();
            if (inicial != "T" && inicial != "B")
            {
                return false;
            }

            int numero;
            return int.TryParse(etiqueta.Substring(1), out numero);
        }
    }
}

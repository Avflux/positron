using System;

namespace Positron.Data.Correcoes
{
    /// <summary>
    /// O <c>CorrigePainelET1DosBornes</c> do <c>clsUtilitarios.cs</c> (frente 2 do §7.6):
    /// escreve os atributos do bloco do **borne** (Dispositivo tipo <c>B</c>) com o painel
    /// e a régua resolvidos no dicionário <c>REGUAS</c> e no cadastro de painéis.
    ///
    /// | tag | valor |
    /// |---|---|
    /// | <c>NOME1</c> | o nome da régua — ou <c>painel + separador + régua</c> quando o borne
    ///   **não** está visível (<c>Visivel != 1</c>) |
    /// | <c>PAINEL</c> | o nome do painel |
    /// | <c>REGUA</c> | o nome da régua |
    /// | <c>T1</c> | o número do borne — ou o caracter de terminal indefinido quando é <c>0</c> |
    /// | outra | não mexe |
    ///
    /// **Quirk reproduzido:** a sentinela do original é a **string <c>"OK"</c>** — o
    /// atributo cujo valor calculado for exatamente <c>"OK"</c> **não é escrito** (e
    /// qualquer tag que não seja uma das quatro também fica como está).
    /// </summary>
    public static class CorrecaoPainelDoBorne
    {
        /// <summary>A sentinela de &quot;não mexe&quot; do original (o literal <c>"OK"</c>).</summary>
        public const string NaoMexer = "OK";

        /// <summary>O valor de cada atributo do borne, ou a sentinela quando não há o que escrever.</summary>
        public static string ValorDoAtributo(
            string tag,
            string nomePainel,
            string nomeRegua,
            string numero,
            int visivel,
            string separadorPainelRegua,
            string caracterTerminalIndefinido)
        {
            string etiqueta = tag ?? string.Empty;

            if (Mesmo(etiqueta, "NOME1"))
            {
                return visivel == 1
                    ? (nomeRegua ?? string.Empty)
                    : (nomePainel ?? string.Empty) + (separadorPainelRegua ?? string.Empty) + (nomeRegua ?? string.Empty);
            }

            if (Mesmo(etiqueta, "PAINEL"))
            {
                return nomePainel ?? string.Empty;
            }

            if (Mesmo(etiqueta, "REGUA"))
            {
                return nomeRegua ?? string.Empty;
            }

            if (Mesmo(etiqueta, "T1"))
            {
                string valor = numero ?? string.Empty;
                return Mesmo(valor, "0") ? (caracterTerminalIndefinido ?? string.Empty) : valor;
            }

            return NaoMexer;
        }

        private static bool Mesmo(string a, string b)
        {
            return string.Equals(a ?? string.Empty, b ?? string.Empty, StringComparison.OrdinalIgnoreCase);
        }
    }
}

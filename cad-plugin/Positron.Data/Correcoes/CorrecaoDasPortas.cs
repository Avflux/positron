using System;
using System.Collections.Generic;

namespace Positron.Data.Correcoes
{
    /// <summary>Os bornes de uma porta, com a marca do asterisco separada.</summary>
    public sealed class BornesDaPorta
    {
        /// <summary>Os bornes (sem o <c>*</c> da frente).</summary>
        public IReadOnlyList<string> Bornes { get; set; }

        /// <summary>Um por borne: <c>true</c> quando ele tinha o <c>*</c> (a régua aparente).</summary>
        public IReadOnlyList<bool> Marcas { get; set; }
    }

    /// <summary>
    /// O <c>EditaTodasPortas</c> do <c>clsPortas.cs</c> — o que o <c>corrigePortas</c>
    /// chama para reescrever os atributos dos blocos de **porta** (Dispositivo tipo
    /// <c>E</c>) com o que diz o dicionário <c>MASCARAS</c> (frente 2 do §7.6).
    ///
    /// O bloco casa pelo par <c>indiceDoModelo</c>/<c>indiceDaPorta</c> do XData
    /// <c>Dispositivo</c> com uma porta do dicionário. Cada atributo recebe:
    ///
    /// | tag | valor |
    /// |---|---|
    /// | <c>EFC</c> | o <c>sEFC</c> da porta |
    /// | <c>T&lt;n&gt;</c> | o terminal <c>n</c> — ou o caracter de terminal indefinido quando o campo está vazio |
    /// | <c>B&lt;n&gt;</c> | o borne <c>n</c> já **sem** o <c>*</c> (espaço quando não há) |
    /// | <c>R&lt;n&gt;</c> | a régua; e o atributo fica **visível** só quando o borne <c>n</c> tinha o <c>*</c> |
    ///
    /// O borne que começa com <c>*</c> perde o asterisco no valor (<c>Mid(borne, 2)</c>) e
    /// a marca fica guardada para decidir a visibilidade da régua.
    ///
    /// **Fora deste recorte, documentado:** as tags <c>NOME1</c> (o nome da máscara pelo
    /// <c>HandleDaMascara</c>) e <c>ORIGEM</c> (a página do texto da definição) — os dois
    /// <c>Busca*</c> do original que ainda não existem no recoder — e o
    /// <c>IndefineUmaPorta</c> que o original roda na porta que **não** está no dicionário.
    /// </summary>
    public static class CorrecaoDasPortas
    {
        /// <summary>A sentinela de &quot;não mexe&quot; do original.</summary>
        public const string NaoMexer = "##VAZIO##";

        /// <summary>
        /// O laço do original sobre os bornes: o <c>*</c> da frente sai do valor e
        /// vira a marca que a régua usa.
        /// </summary>
        public static BornesDaPorta SepararBornes(string bornes)
        {
            List<string> valores = new List<string>();
            List<bool> marcas = new List<bool>();
            string[] partes = (bornes ?? string.Empty).Split(';');
            foreach (string parte in partes)
            {
                string borne = parte ?? string.Empty;
                bool marcado = borne.StartsWith("*", StringComparison.Ordinal);
                valores.Add(marcado ? borne.Substring(1) : borne);
                marcas.Add(marcado);
            }

            return new BornesDaPorta { Bornes = valores, Marcas = marcas };
        }

        /// <summary>
        /// O valor do atributo <paramref name="tag"/> e, quando for uma régua, a
        /// visibilidade que ela deve ter (<c>null</c> = o original não mexe).
        /// </summary>
        public static string ValorDoAtributo(
            string tag,
            IReadOnlyList<string> terminais,
            BornesDaPorta bornes,
            string regua,
            string efc,
            string caracterTerminalIndefinido,
            out bool? visivel)
        {
            return ValorDoAtributo(tag, terminais, bornes, regua, efc, caracterTerminalIndefinido, null, null, out visivel);
        }

        /// <summary>
        /// A versão com o **nome da máscara** (<c>NOME1</c>) e a **página** (<c>ORIGEM</c>) —
        /// os dois <c>Busca*</c> que o adapter resolve no desenho.
        /// </summary>
        public static string ValorDoAtributo(
            string tag,
            IReadOnlyList<string> terminais,
            BornesDaPorta bornes,
            string regua,
            string efc,
            string caracterTerminalIndefinido,
            string nomeDaMascara,
            string pagina,
            out bool? visivel)
        {
            visivel = null;
            string etiqueta = tag ?? string.Empty;

            if (Mesmo(etiqueta, "NOME1"))
            {
                return nomeDaMascara ?? string.Empty;
            }

            if (Mesmo(etiqueta, "ORIGEM"))
            {
                return pagina ?? string.Empty;
            }

            if (Mesmo(etiqueta, "EFC"))
            {
                return efc ?? string.Empty;
            }

            int numero;
            if (!NumeroDaTag(etiqueta, out numero))
            {
                return NaoMexer;
            }

            int posicao = numero - 1;
            string inicial = etiqueta.Substring(0, 1).ToUpperInvariant();

            if (inicial == "T")
            {
                string valor = caracterTerminalIndefinido ?? string.Empty;
                if (terminais != null && numero <= terminais.Count &&
                    !string.IsNullOrEmpty(terminais[posicao]))
                {
                    valor = terminais[posicao];
                }

                return valor;
            }

            if (inicial == "B")
            {
                if (bornes != null && bornes.Bornes != null && numero <= bornes.Bornes.Count)
                {
                    return bornes.Bornes[posicao] ?? string.Empty;
                }

                return " ";
            }

            if (inicial == "R")
            {
                visivel = false;
                if (bornes != null && bornes.Marcas != null && numero <= bornes.Marcas.Count &&
                    bornes.Marcas[posicao])
                {
                    visivel = true;
                }

                return regua ?? string.Empty;
            }

            return NaoMexer;
        }

        /// <summary>
        /// O <c>Mid(tag, 2)</c> numérico do original: a etiqueta tem que terminar em
        /// número (o <c>T1</c>, o <c>B10</c>...).
        /// </summary>
        private static bool NumeroDaTag(string tag, out int numero)
        {
            numero = 0;
            if (tag.Length < 2)
            {
                return false;
            }

            return int.TryParse(tag.Substring(1), out numero);
        }

        private static bool Mesmo(string a, string b)
        {
            return string.Equals(a ?? string.Empty, b ?? string.Empty, StringComparison.OrdinalIgnoreCase);
        }
    }
}

using System;
using System.Collections.Generic;
using Positron.Data.Modelos;

namespace Positron.Data.Correcoes
{
    /// <summary>
    /// O <c>AtualizaOsTerminaisAuxiliares</c> do <c>clsDispositivoAuxiliares.cs</c> — a
    /// regra que o <c>CorrigeBlocosContatosAux</c> usa para reescrever os atributos
    /// <c>T1</c>, <c>T2</c> e <c>T3</c> dos blocos auxiliares (os de Dispositivo tipo
    /// <c>"A"</c>) a partir do contato do dicionário <c>CONTATOS</c> (frente 2 do §7.6).
    ///
    /// O valor de cada atributo depende de três coisas: a **tag**, o <c>sTipoModelo</c>
    /// (o tipo do contato no dicionário) e o **tipo do bloco**, que sai do próprio nome
    /// — <c>Mid(nome, 5, 2)</c>, os dois caracteres da quinta posição em diante (o
    /// <c>BT4NAXX</c> é <c>NA</c>).
    ///
    /// | tag | regra |
    /// |---|---|
    /// | <c>T1</c> | sempre <c>sT1</c> |
    /// | <c>T2</c> | <c>sT2</c>, **exceto** com <c>sTipoModelo = "RV"</c>: aí o tipo do
    ///   bloco decide — <c>NA</c> recebe <c>sT3</c>, <c>NF</c> e <c>RV</c> recebem
    ///   <c>sT2</c>, e qualquer outro **não mexe** |
    /// | <c>T3</c> | <c>sT3</c>, e com <c>sTipoModelo = "NA"</c> o <c>sT2</c> quando o
    ///   <c>sT3</c> está vazio |
    /// | outra | não mexe |
    ///
    /// O <c>"##VAZIO##"</c> é a sentinela do original para &quot;não mexe&quot;.
    /// </summary>
    public static class TerminaisDoContato
    {
        /// <summary>A sentinela de &quot;não mexe&quot; do original.</summary>
        public const string NaoMexer = "##VAZIO##";

        /// <summary>O tipo do bloco pelo nome: os dois caracteres do <c>Mid(nome, 5, 2)</c>.</summary>
        public static string TipoDoBloco(string nomeDoBloco)
        {
            if (string.IsNullOrEmpty(nomeDoBloco) || nomeDoBloco.Length < 5)
            {
                return string.Empty;
            }

            return nomeDoBloco.Substring(4, Math.Min(2, nomeDoBloco.Length - 4));
        }

        /// <summary>
        /// O valor que o atributo <paramref name="tag"/> recebe — ou
        /// <see cref="NaoMexer"/> quando o original deixa o atributo como está.
        /// </summary>
        public static string ValorDoAtributo(
            string tag,
            string tipoModelo,
            string tipoDoBloco,
            string t1,
            string t2,
            string t3)
        {
            string sT1 = t1 ?? string.Empty;
            string sT2 = t2 ?? string.Empty;
            string sT3 = t3 ?? string.Empty;

            if (Mesmo(tag, "T1"))
            {
                return sT1;
            }

            if (Mesmo(tag, "T2"))
            {
                if (!Mesmo(tipoModelo, "RV"))
                {
                    return sT2;
                }

                if (Mesmo(tipoDoBloco, "NA"))
                {
                    return sT3;
                }

                if (Mesmo(tipoDoBloco, "NF") || Mesmo(tipoDoBloco, "RV"))
                {
                    return sT2;
                }

                return NaoMexer;
            }

            if (Mesmo(tag, "T3"))
            {
                if (!Mesmo(tipoModelo, "NA"))
                {
                    return sT3;
                }

                return sT3.Length == 0 ? sT2 : sT3;
            }

            return NaoMexer;
        }

        /// <summary>O contato do modelo pelo índice (o par do bloco), ou <c>null</c>.</summary>
        public static ContatoAuxiliar BuscarContato(
            IReadOnlyList<ContatoAuxiliar> contatos,
            int indiceContato)
        {
            if (contatos == null)
            {
                return null;
            }

            foreach (ContatoAuxiliar contato in contatos)
            {
                if (contato != null && contato.Indice == indiceContato)
                {
                    return contato;
                }
            }

            return null;
        }

        private static bool Mesmo(string a, string b)
        {
            return string.Equals(a ?? string.Empty, b ?? string.Empty, StringComparison.OrdinalIgnoreCase);
        }
    }
}

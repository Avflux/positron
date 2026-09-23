using System;
using System.Collections.Generic;
using Positron.Data.Modelos;

namespace Positron.Data.Correcoes
{
    /// <summary>
    /// Um bloco **auxiliar** (tipo <c>A</c>) do desenho, como a correção do
    /// <c>HandleContatoAux</c> precisa dele.
    /// </summary>
    public sealed class ContatoAuxiliarNoDesenho
    {
        /// <summary>Handle do bloco auxiliar no desenho.</summary>
        public string Handle { get; set; }

        /// <summary>Handle do bob (o <c>array[4]</c> do XData de <c>A</c>).</summary>
        public string HandleBob { get; set; }

        /// <summary>Índice do modelo (<c>array[5]</c>).</summary>
        public int IndexModelo { get; set; }

        /// <summary>Índice do contato (<c>array[6]</c>).</summary>
        public int IndexContato { get; set; }
    }

    /// <summary>
    /// O <c>CorrigeContatosAux</c> do <c>Correcao.cs</c> — o par de escrita do
    /// <c>bt4Auxiliar</c> (a checagem principal × auxiliar, rodada 54).
    ///
    /// O original faz duas passadas pelo ModelSpace: a primeira coleta os blocos
    /// <c>A</c> numa matriz <c>(HandleBob, IndexModelo, IndexContato, Handle)</c> e a
    /// segunda, para cada bloco com XData <c>Modelo</c>, procura **o primeiro**
    /// auxiliar da lista cuja chave casa e grava o handle dele em
    /// <c>HandleContatoAux</c> — **vazio** quando nenhum casa.
    ///
    /// A comparação do <c>HandleBob</c> é **sem caixa** (o <c>TextCompare: true</c>
    /// do original); os dois índices são inteiros. Quem não casa fica com o campo
    /// vazio, e é isso que o <c>bt4Auxiliar</c> enxerga como divergência.
    ///
    /// Aqui fica só a decisão; quem varre o desenho e grava é o adapter.
    /// </summary>
    public static class CorrecaoContatoAuxiliar
    {
        /// <summary>Um bloco de modelo e o valor que ele deve receber.</summary>
        public sealed class Ajuste
        {
            /// <summary>Handle do bloco do modelo (o que o adapter reabre para gravar).</summary>
            public string Handle { get; set; }

            /// <summary>O modelo como ele está no desenho (o adapter regrava os campos lidos).</summary>
            public BlocoModelo Modelo { get; set; }

            /// <summary>O novo <c>HandleContatoAux</c> — vazio quando nenhum auxiliar casa.</summary>
            public string HandleContatoAux { get; set; }

            /// <summary><c>true</c> quando o valor muda em relação ao que está gravado.</summary>
            public bool Mudou { get; set; }
        }

        /// <summary>
        /// Decide o <c>HandleContatoAux</c> de cada modelo. <paramref name="auxiliares"/>
        /// são os blocos <c>A</c> **na ordem do ModelSpace** (o primeiro que casa vence).
        /// </summary>
        public static IReadOnlyList<Ajuste> Planejar(
            IReadOnlyList<ContatoAuxiliarNoDesenho> auxiliares,
            IReadOnlyList<BlocoModelo> modelos)
        {
            List<Ajuste> ajustes = new List<Ajuste>();
            if (modelos == null)
            {
                return ajustes;
            }

            foreach (BlocoModelo modelo in modelos)
            {
                if (modelo == null)
                {
                    continue;
                }

                string casado = string.Empty;
                if (auxiliares != null)
                {
                    foreach (ContatoAuxiliarNoDesenho auxiliar in auxiliares)
                    {
                        if (auxiliar == null || !Casa(auxiliar, modelo))
                        {
                            continue;
                        }

                        casado = auxiliar.Handle ?? string.Empty;
                        break;
                    }
                }

                ajustes.Add(new Ajuste
                {
                    Handle = modelo.Handle,
                    Modelo = modelo,
                    HandleContatoAux = casado,
                    Mudou = !string.Equals(modelo.HandleContatoAux ?? string.Empty, casado, StringComparison.Ordinal),
                });
            }

            return ajustes;
        }

        private static bool Casa(ContatoAuxiliarNoDesenho auxiliar, BlocoModelo modelo)
        {
            return auxiliar.IndexModelo == modelo.IndexModelo
                && auxiliar.IndexContato == modelo.IndexContato
                && string.Equals(
                    auxiliar.HandleBob ?? string.Empty,
                    modelo.HandleBob ?? string.Empty,
                    StringComparison.OrdinalIgnoreCase);
        }
    }
}

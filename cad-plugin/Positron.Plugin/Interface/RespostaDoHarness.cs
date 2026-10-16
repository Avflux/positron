using System;
using System.Collections.Generic;
using Positron.Data.Interface;
using Positron.Data.Paginas;

namespace Positron.Plugin.Interface
{
    /// <summary>
    /// Os ganchos do **harness** para as perguntas da paleta (o item 1c da correção do básico): o
    /// original abre um form modal e os comandos do recoder já leem as mesmas respostas do ambiente
    /// (<c>POSITRON_UNIDADE</c>, <c>POSITRON_ALTERNATIVO</c>, <c>POSITRON_TITULO1..4</c>).
    ///
    /// Aqui é a **mesma pergunta pelo caminho da paleta**: com a variável definida o form **não abre**
    /// (um script não tem quem o feche) e a resposta é a do ambiente; sem ela, o form é o de sempre.
    /// Nada disso é gravado em arquivo nem mostrado em tela — é só o recorte de teste.
    /// </summary>
    internal static class RespostaDoHarness
    {
        internal const string VariavelUnidade = "POSITRON_UNIDADE";

        internal const string VariavelAlternativo = "POSITRON_ALTERNATIVO";

        internal const string PrefixoTitulo = "POSITRON_TITULO";

        /// <summary>
        /// A variável da pergunta **repetível** da renumeração (o `Mover para página?` do menu):
        /// uma fila de respostas separadas por `;`, consumida uma por prompt — é assim que o
        /// harness prova a recusa que **volta a perguntar** e a resposta seguinte que aplica.
        /// </summary>
        internal const string VariavelMoverPara = "POSITRON_MOVER_PARA";

        private static readonly Queue<string> FilaDaMovimentacao = new Queue<string>();

        private static bool _filaCarregada;

        /// <summary>O valor do campo pelo rótulo do form (os dois que a paleta edita).</summary>
        internal static bool Campo(string rotulo, out string valor)
        {
            valor = null;
            string variavel = null;
            if (string.Equals(rotulo, MensagensDoReverso.Unidade, StringComparison.OrdinalIgnoreCase))
            {
                variavel = VariavelUnidade;
            }
            else if (string.Equals(rotulo, MensagensDoReverso.Alternativo, StringComparison.OrdinalIgnoreCase))
            {
                variavel = VariavelAlternativo;
            }

            if (variavel == null)
            {
                return false;
            }

            string doAmbiente = Environment.GetEnvironmentVariable(variavel);
            if (doAmbiente == null)
            {
                return false;
            }

            valor = doAmbiente;
            return true;
        }

        /// <summary>
        /// A próxima resposta da fila do `Mover para página?`. Devolve <c>false</c> quando a fila
        /// acabou (ou nunca existiu).
        /// </summary>
        internal static bool Movimentacao(out string valor)
        {
            valor = null;
            if (!_filaCarregada)
            {
                _filaCarregada = true;
                string doAmbiente = Environment.GetEnvironmentVariable(VariavelMoverPara);
                if (doAmbiente != null)
                {
                    foreach (string parte in doAmbiente.Split(';'))
                    {
                        FilaDaMovimentacao.Enqueue(parte);
                    }
                }
            }

            if (FilaDaMovimentacao.Count == 0)
            {
                return false;
            }

            valor = FilaDaMovimentacao.Dequeue();
            return true;
        }

        /// <summary>
        /// O harness está no comando da pergunta repetível: com a variável definida (mesmo sem
        /// resposta na fila) **não** se abre o prompt nativo — um script não tem quem o responda, e
        /// o laço do original insistiria para sempre.
        /// </summary>
        internal static bool MovimentacaoAtiva
        {
            get { return Environment.GetEnvironmentVariable(VariavelMoverPara) != null; }
        }

        /// <summary>
        /// Os quatro títulos, com os que o ambiente definiu por cima dos atuais (os outros ficam como
        /// estão — o mesmo recorte do comando dos títulos). Devolve <c>false</c> sem nenhuma variável.
        /// </summary>
        internal static bool Titulos(TitulosDaPagina atuais, out TitulosDaPagina escolhidos)
        {
            escolhidos = null;
            bool algum = false;
            TitulosDaPagina resultado = new TitulosDaPagina();
            for (int i = 1; i <= TitulosDaPagina.UltimoIndice; i++)
            {
                string doAmbiente = Environment.GetEnvironmentVariable(PrefixoTitulo + i);
                if (doAmbiente != null)
                {
                    algum = true;
                }

                resultado.Definir(i, doAmbiente ?? (atuais == null ? string.Empty : atuais.De(i)));
            }

            if (!algum)
            {
                return false;
            }

            escolhidos = resultado;
            return true;
        }
    }
}

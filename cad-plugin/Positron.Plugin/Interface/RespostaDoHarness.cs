using System;
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

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Positron.Data.Diagnostico
{
    /// <summary>
    /// O relatório do comando de diagnóstico <c>pzDiag</c> — a **ferramenta em C#** que
    /// substitui os contadores LISP (a lição das rodadas 90/91 e 102: o gargalo era o LISP,
    /// não a lógica).
    ///
    /// O formato é puro e testável: uma linha por porta e uma por diferença de cor, com o
    /// total no fim de cada seção (o separador é <c>;</c>, como nos contadores antigos).
    /// </summary>
    public static class RelatorioDeDiagnostico
    {
        public const string CabecalhoDePortas = "PORTA;tipo;indiceModelo;indiceDaPorta;handleMascara;handleDefinicao;NOME1;T1;PAINEL;EFC";

        public const string CabecalhoDeCores = "COR;handle;nome;tag;corRef;corDef";

        /// <summary>Uma linha da seção das portas (o separador é <c>;</c>).</summary>
        public static string LinhaDePorta(
            string tipo,
            int indiceModelo,
            int indiceDaPorta,
            string handleMascara,
            string handleDefinicao,
            string nome1,
            string t1,
            string painel,
            string efc)
        {
            return string.Join(";", new[]
            {
                "PORTA",
                Texto(tipo),
                Numero(indiceModelo),
                Numero(indiceDaPorta),
                Texto(handleMascara),
                Texto(handleDefinicao),
                Texto(nome1),
                Texto(t1),
                Texto(painel),
                Texto(efc),
            });
        }

        /// <summary>Uma linha da seção das cores (a referência e a definição do mesmo tag).</summary>
        public static string LinhaDeCor(string handle, string nome, string tag, int corDaReferencia, int corDaDefinicao)
        {
            return string.Join(";", new[]
            {
                "COR",
                Texto(handle),
                Texto(nome),
                Texto(tag),
                Numero(corDaReferencia),
                Numero(corDaDefinicao),
            });
        }

        /// <summary>O total de uma seção (o nome e os pares que o chamador quiser).</summary>
        public static string Total(string secao, params int[] numeros)
        {
            StringBuilder linha = new StringBuilder();
            linha.Append("TOTAL;").Append(Texto(secao));
            foreach (int numero in numeros)
            {
                linha.Append(';').Append(Numero(numero));
            }

            return linha.ToString();
        }

        /// <summary>Diz se a cor da referência difere da definição (o que o comando corrige).</summary>
        public static bool CorDiferente(int corDaReferencia, int corDaDefinicao)
        {
            return corDaReferencia != corDaDefinicao;
        }

        private static string Texto(string valor)
        {
            return valor ?? string.Empty;
        }

        private static string Numero(int valor)
        {
            return valor.ToString(CultureInfo.InvariantCulture);
        }
    }
}

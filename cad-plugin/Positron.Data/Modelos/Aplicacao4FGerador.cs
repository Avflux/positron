using System;
using System.Collections.Generic;
using Positron.Data.Fiacao;

namespace Positron.Data.Modelos
{
    /// <summary>
    /// Um **tipo de aplicação** do desenho — o <c>structureAplicacao</c> do
    /// original, lido do dicionário <c>APLICACAO</c>.
    /// </summary>
    public sealed class AplicacaoDefinicao
    {
        public int Indice { get; set; }

        public string Nome { get; set; }

        public string Secao { get; set; }

        public string Cor { get; set; }

        public string TipoCabo { get; set; }

        public string Isolacao { get; set; }
    }

    /// <summary>Uma linha de <c>Aplicacao4F</c>.</summary>
    public sealed class Aplicacao4F
    {
        public int Numero { get; set; }

        public string Nome { get; set; }

        public string Secao { get; set; }

        public string Cor { get; set; }

        public string TipoCabo { get; set; }

        public string Isolacao { get; set; }
    }

    /// <summary>
    /// Lê e projeta <c>Aplicacao4F</c> — o <c>FiRUTW6Q6W</c> do
    /// <c>frmCompilarFiacao</c>: copia **todos** os tipos de aplicação do
    /// dicionário do desenho (sem filtro por painel ou por uso).
    ///
    /// O <c>Xrecord</c> de <c>APLICACAO/TIPOS</c> é uma lista plana com **10
    /// valores por aplicação**, e o original começa a ler no índice **1** (o
    /// valor 0 não é uma aplicação), avançando de 10 em 10:
    ///
    /// | deslocamento | campo |
    /// |---|---|
    /// | +0 | <c>Indice</c> |
    /// | +1 | <c>Nome</c> |
    /// | +2 | <c>Secao</c> |
    /// | +3 | <c>Cor</c> |
    /// | +4 | <c>TipoCabo</c> |
    /// | +5 | <c>Isolacao</c> |
    /// | +6..+9 | reservados |
    /// </summary>
    public static class Aplicacao4FGerador
    {
        /// <summary>Valores por aplicação no <c>Xrecord</c>.</summary>
        public const int ValoresPorAplicacao = 10;

        /// <summary>Primeiro índice lido — o 0 não é aplicação (como no original).</summary>
        public const int PrimeiroIndice = 1;

        public static List<AplicacaoDefinicao> LerTipos(IReadOnlyList<TypedXData> valores)
        {
            List<AplicacaoDefinicao> tipos = new List<AplicacaoDefinicao>();
            if (valores == null)
            {
                return tipos;
            }

            for (int i = PrimeiroIndice; i + 5 < valores.Count; i += ValoresPorAplicacao)
            {
                tipos.Add(new AplicacaoDefinicao
                {
                    Indice = Inteiro(valores[i].Valor),
                    Nome = Texto(valores[i + 1].Valor),
                    Secao = Texto(valores[i + 2].Valor),
                    Cor = Texto(valores[i + 3].Valor),
                    TipoCabo = Texto(valores[i + 4].Valor),
                    Isolacao = Texto(valores[i + 5].Valor),
                });
            }

            return tipos;
        }

        public static List<Aplicacao4F> Gerar(IEnumerable<AplicacaoDefinicao> definicoes)
        {
            List<Aplicacao4F> linhas = new List<Aplicacao4F>();
            if (definicoes == null)
            {
                return linhas;
            }

            foreach (AplicacaoDefinicao definicao in definicoes)
            {
                if (definicao == null)
                {
                    continue;
                }

                linhas.Add(new Aplicacao4F
                {
                    Numero = definicao.Indice,
                    Nome = definicao.Nome,
                    Secao = definicao.Secao,
                    Cor = definicao.Cor,
                    TipoCabo = definicao.TipoCabo,
                    Isolacao = definicao.Isolacao,
                });
            }

            return linhas;
        }

        private static int Inteiro(object valor)
        {
            return valor == null || valor is DBNull ? 0 : Convert.ToInt32(valor);
        }

        private static string Texto(object valor)
        {
            if (valor == null || valor is DBNull)
            {
                return null;
            }

            string texto = valor as string;
            return texto ?? Convert.ToString(valor);
        }
    }
}

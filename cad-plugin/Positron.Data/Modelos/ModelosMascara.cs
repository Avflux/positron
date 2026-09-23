using System;
using System.Collections.Generic;
using Positron.Data.Fiacao;

namespace Positron.Data.Modelos
{
    /// <summary>Um modelo de máscara (dispositivo) do desenho.</summary>
    public sealed class ModeloMascara
    {
        public int Indice { get; set; }

        public string Nome { get; set; }

        public int Lm1 { get; set; }

        public int Lm2 { get; set; }

        public string BlocoTopografico { get; set; }

        public string BlocoLayout { get; set; }

        public string Orientacao { get; set; }
    }

    /// <summary>Uma porta (terminal/bome) de um modelo de máscara.</summary>
    public sealed class ModeloPorta
    {
        public int IndiceDaPorta { get; set; }

        public int IndiceModelo { get; set; }

        public string NomeModelo { get; set; }

        public string Orientacao { get; set; }

        public string EFC { get; set; }

        public string Terminais { get; set; }

        public string Bornes { get; set; }

        public string Regua { get; set; }
    }

    /// <summary>
    /// Os modelos de máscara e suas portas, guardados no dicionário de objetos
    /// nomeados do DWG (<c>DicionarioMascaras</c> no original):
    ///
    /// - a **lista de modelos** fica em <c>MASCARAS → "MODELOS2"</c>, um
    ///   <c>Xrecord</c> de registros de **10 valores** a partir do índice 1
    ///   (campo +4 não é usado);
    /// - as **portas** de um modelo ficam em <c>MASCARAS → "&lt;indice&gt;"</c>,
    ///   um <c>Xrecord</c> cujo valor 0 é o índice máximo e cujos registros de
    ///   **8 valores** começam no índice 1 (campos +5 e +7 não são usados).
    /// </summary>
    public static class ModelosMascara
    {
        public const int ValoresPorModelo = 10;

        public const int ValoresPorPorta = 8;

        /// <summary>Interpreta o XRecord <c>MODELOS2</c> da lista de modelos.</summary>
        public static List<ModeloMascara> LerModelos(IReadOnlyList<TypedXData> valores)
        {
            List<ModeloMascara> modelos = new List<ModeloMascara>();
            if (valores == null)
            {
                return modelos;
            }

            // O original começa em 1 (o valor 0 não é um modelo) e lê até +7.
            for (int i = 1; i + 7 < valores.Count; i += ValoresPorModelo)
            {
                modelos.Add(new ModeloMascara
                {
                    Indice = Inteiro(valores[i + 0].Valor),
                    Nome = Texto(valores[i + 1].Valor),
                    Lm1 = Inteiro(valores[i + 2].Valor),
                    Lm2 = Inteiro(valores[i + 3].Valor),
                    BlocoTopografico = Texto(valores[i + 5].Valor),
                    BlocoLayout = Texto(valores[i + 6].Valor),
                    Orientacao = Texto(valores[i + 7].Valor),
                });
            }

            return modelos;
        }

        /// <summary>Interpreta o XRecord de portas de um modelo.</summary>
        public static List<ModeloPorta> LerPortas(IReadOnlyList<TypedXData> valores, int indiceModelo, string nomeModelo)
        {
            List<ModeloPorta> portas = new List<ModeloPorta>();
            if (valores == null)
            {
                return portas;
            }

            // O valor 0 é o índice máximo; as portas começam em 1 e leem até +6.
            for (int i = 1; i + 6 < valores.Count; i += ValoresPorPorta)
            {
                portas.Add(new ModeloPorta
                {
                    IndiceDaPorta = Inteiro(valores[i + 0].Valor),
                    IndiceModelo = indiceModelo,
                    NomeModelo = nomeModelo,
                    Orientacao = Texto(valores[i + 1].Valor),
                    EFC = Texto(valores[i + 2].Valor),
                    Terminais = Texto(valores[i + 3].Valor),
                    Bornes = Texto(valores[i + 4].Valor),
                    Regua = Texto(valores[i + 6].Valor),
                });
            }

            return portas;
        }

        /// <summary>
        /// Monta o XRecord das portas de um modelo, no layout que o
        /// <c>GravaAsPortasDoModeloDoDicionario</c> escreve: o valor 0 é o
        /// <c>MaxIndice</c> e cada porta ocupa **8 valores** — o índice (+0, grupo
        /// 90), orientação (+1, grupo 1 e **em maiúsculas**, o <c>ToUpper</c> do
        /// original), EFC (+2), terminais (+3), bornes (+4), um campo vazio (+5),
        /// régua (+6) e outro vazio (+7). É o caminho de **escrita** do
        /// <c>corrigeDicMascaras</c> (o avesso de <see cref="LerPortas"/>).
        /// </summary>
        public static IReadOnlyList<TypedXData> ParaValores(int maxIndice, IReadOnlyList<ModeloPorta> portas)
        {
            List<TypedXData> valores = new List<TypedXData>
            {
                new TypedXData(90, maxIndice),
            };

            if (portas == null)
            {
                return valores;
            }

            foreach (ModeloPorta porta in portas)
            {
                if (porta == null)
                {
                    continue;
                }

                valores.Add(new TypedXData(90, porta.IndiceDaPorta));
                valores.Add(new TypedXData(1, (porta.Orientacao ?? string.Empty).ToUpperInvariant()));
                valores.Add(new TypedXData(1, porta.EFC ?? string.Empty));
                valores.Add(new TypedXData(1, porta.Terminais ?? string.Empty));
                valores.Add(new TypedXData(1, porta.Bornes ?? string.Empty));
                valores.Add(new TypedXData(1, string.Empty));
                valores.Add(new TypedXData(1, porta.Regua ?? string.Empty));
                valores.Add(new TypedXData(1, string.Empty));
            }

            return valores;
        }

        private static int Inteiro(object valor)
        {
            return valor == null || valor is DBNull ? 0 : XDataNumero.Inteiro(valor);
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

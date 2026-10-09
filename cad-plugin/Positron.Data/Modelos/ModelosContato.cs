using System;
using System.Collections.Generic;
using Positron.Data.Fiacao;

namespace Positron.Data.Modelos
{
    /// <summary>Um modelo de contato (dispositivo com terminais).</summary>
    public sealed class ModeloContato
    {
        public int Indice { get; set; }

        public string Nome { get; set; }

        public int Lm1 { get; set; }

        public int Lm2 { get; set; }

        public string BlocoTopografico { get; set; }

        public string BlocoLayout { get; set; }

        public string Orientacao { get; set; }

        public string TerminaisDoDispositivo { get; set; }
    }

    /// <summary>Um contato auxiliar (até 3 terminais) de um modelo.</summary>
    public sealed class ContatoAuxiliar
    {
        public int Indice { get; set; }

        public string T1 { get; set; }

        public string T2 { get; set; }

        public string T3 { get; set; }

        /// <summary>Tipo do contato: <c>"NA"</c>, <c>"NF"</c> ou <c>"RV"</c>.</summary>
        public string Tipo { get; set; }

        public string Comportamento { get; set; }

        public string Orientacao { get; set; }
    }

    /// <summary>
    /// Os modelos de contato e seus contatos auxiliares, no dicionário do DWG
    /// (<c>DicionarioContatos</c> no original):
    ///
    /// - a lista fica em <c>CONTATOS → "MODELOS2"</c>, um <c>Xrecord</c> cujo
    ///   valor 0 é a contagem e cujos registros de **10 valores** começam no
    ///   índice 1 (campos +4 e +7 não são usados);
    /// - os auxiliares de um modelo ficam em <c>CONTATOS → "&lt;indice&gt;"</c>,
    ///   registros de **8 valores** a partir do índice 1 (campo +7 não usado).
    ///
    /// O <c>tipo</c> (campo +4 dos auxiliares) vira <c>"NA"</c> (1), <c>"NF"</c>
    /// (2) ou <c>"RV"</c> (3), como no original.
    /// </summary>
    public static class ModelosContato
    {
        public const int ValoresPorModelo = 10;

        public const int ValoresPorAuxiliar = 8;

        public static List<ModeloContato> LerModelos(IReadOnlyList<TypedXData> valores)
        {
            List<ModeloContato> modelos = new List<ModeloContato>();
            if (valores == null)
            {
                return modelos;
            }

            // Começa em 1 (valor 0 é a contagem) e lê até +9.
            for (int i = 1; i + 9 < valores.Count; i += ValoresPorModelo)
            {
                modelos.Add(new ModeloContato
                {
                    Indice = Inteiro(valores[i + 0].Valor),
                    Nome = Texto(valores[i + 1].Valor),
                    Lm1 = Inteiro(valores[i + 2].Valor),
                    Lm2 = Inteiro(valores[i + 3].Valor),
                    BlocoTopografico = Texto(valores[i + 5].Valor),
                    BlocoLayout = Texto(valores[i + 6].Valor),
                    Orientacao = Texto(valores[i + 8].Valor),
                    TerminaisDoDispositivo = Texto(valores[i + 9].Valor),
                });
            }

            return modelos;
        }

        public static List<ContatoAuxiliar> LerAuxiliares(IReadOnlyList<TypedXData> valores)
        {
            List<ContatoAuxiliar> auxiliares = new List<ContatoAuxiliar>();
            if (valores == null)
            {
                return auxiliares;
            }

            // Começa em 1 e lê até +6.
            for (int i = 1; i + 6 < valores.Count; i += ValoresPorAuxiliar)
            {
                string t1 = Texto(valores[i + 1].Valor);
                string t2 = Texto(valores[i + 2].Valor);
                string t3 = Texto(valores[i + 3].Valor);

                // A orientação é ajustada ao número de terminais preenchidos
                // (VerificaOrientacaoContato do original).
                string orientacao = OrientacaoContato.Verificar(
                    t1 + ";" + t2 + ";" + t3 + ";",
                    Texto(valores[i + 6].Valor));

                auxiliares.Add(new ContatoAuxiliar
                {
                    Indice = Inteiro(valores[i + 0].Valor),
                    T1 = t1,
                    T2 = t2,
                    T3 = t3,
                    Tipo = TipoDoContato(Inteiro(valores[i + 4].Valor)),
                    Comportamento = Texto(valores[i + 5].Valor),
                    Orientacao = orientacao,
                });
            }

            return auxiliares;
        }

        private static string TipoDoContato(int tipo)
        {
            switch (tipo)
            {
                case 1:
                    return "NA";
                case 2:
                    return "NF";
                case 3:
                    return "RV";
                default:
                    return null;
            }
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

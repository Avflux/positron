using System.Collections.Generic;
using Positron.Data.Fiacao;

namespace Positron.Data.Diagnostico
{
    /// <summary>
    /// A **porta sintética** que o comando <c>pzDiagCriar</c> monta para provar o
    /// <c>IndefineUmaPorta</c> ponta a ponta (a última pendência da frente 2).
    ///
    /// O XData <c>Dispositivo</c> sai no layout de 25 valores do reverso, com o tipo <c>E</c>,
    /// o índice do modelo, o índice da porta e os campos que o indefinir zera.
    /// </summary>
    public static class PortaSintetica
    {
        public const string NomeDoBloco = "PZPORT";

        public const string AppName = "Dispositivo";

        public const int IndiceDoModelo = 9;

        /// <summary>A porta que o desenho aponta e que o dicionário **não** tem.</summary>
        public const int IndiceDaPorta = 5;

        /// <summary>A única porta do modelo no <c>MASCARAS</c> (a que não casa).</summary>
        public const int IndiceDaPortaDoDicionario = 3;

        public static IReadOnlyList<string> Tags = new[] { "NOME1", "T1", "PAINEL", "EFC" };

        public static IReadOnlyList<string> Valores = new[] { "NOME-ANTIGO", "7", "PT1", "EFC-ANTIGO" };

        /// <summary>Os 25 valores do XData <c>Dispositivo</c> da porta sintética.</summary>
        public static IReadOnlyList<TypedXData> ParaValores(int indiceModelo, int indiceDaPorta)
        {
            return new List<TypedXData>
            {
                new TypedXData(1001, AppName),
                new TypedXData(1000, "E"),
                new TypedXData(1000, string.Empty),
                new TypedXData(1000, string.Empty),
                new TypedXData(1000, string.Empty),
                new TypedXData(1070, indiceModelo),
                new TypedXData(1070, indiceDaPorta),
                new TypedXData(1070, 0),
                new TypedXData(1070, 0),
                new TypedXData(1000, string.Empty),
                new TypedXData(1000, "1A2B"),
                new TypedXData(1000, "CHAVE"),
                new TypedXData(1000, string.Empty),
                new TypedXData(1070, 0),
                new TypedXData(1070, 0),
                new TypedXData(1070, 0),
                new TypedXData(1000, "ana"),
                new TypedXData(1000, "2026-09-23"),
                new TypedXData(1070, 0),
                new TypedXData(1070, 0),
                new TypedXData(1070, 0),
                new TypedXData(1040, 0.0),
                new TypedXData(1000, string.Empty),
                new TypedXData(1000, string.Empty),
                new TypedXData(1071, 0),
                new TypedXData(1000, string.Empty),
            };
        }
    }
}

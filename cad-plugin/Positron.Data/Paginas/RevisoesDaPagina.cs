using System;
using System.Collections.Generic;
using Positron.Data.Fiacao;

namespace Positron.Data.Paginas
{
    /// <summary>
    /// Uma linha da revisão simplificada de uma página (o modelo do <c>frmEditaRevisaoSimplificada</c>).
    /// </summary>
    public sealed class RevisaoSimplificadaDaPagina
    {
        public RevisaoSimplificadaDaPagina()
        {
            Pagina = string.Empty;
            Revisao = string.Empty;
        }

        public RevisaoSimplificadaDaPagina(string pagina, string revisao)
        {
            Pagina = pagina ?? string.Empty;
            Revisao = revisao ?? string.Empty;
        }

        /// <summary>O nome da página / layer no caderno (ex.: "01", "02").</summary>
        public string Pagina { get; set; }

        /// <summary>O código de revisão da página (ex.: "R0", "0", "A").</summary>
        public string Revisao { get; set; }
    }

    /// <summary>
    /// Uma linha da revisão completa de uma página (o modelo do <c>frmEditaRevisaoCompleta</c>).
    /// </summary>
    public sealed class RevisaoCompletaDaPagina
    {
        public RevisaoCompletaDaPagina()
        {
            Pagina = string.Empty;
            Revisao = string.Empty;
            RevisaoOriginal = string.Empty;
            Descricao = string.Empty;
            Data = string.Empty;
            Elaborador = string.Empty;
            Verificador = string.Empty;
            Aprovador = string.Empty;
        }

        public RevisaoCompletaDaPagina(string pagina, string revisao, string descricao, string data,
            string elaborador, string verificador, string aprovador, int posicao = 0)
        {
            Pagina = pagina ?? string.Empty;
            Posicao = posicao;
            Revisao = revisao ?? string.Empty;
            RevisaoOriginal = Revisao;
            Descricao = descricao ?? string.Empty;
            Data = data ?? string.Empty;
            Elaborador = elaborador ?? string.Empty;
            Verificador = verificador ?? string.Empty;
            Aprovador = aprovador ?? string.Empty;
        }

        public string Pagina { get; set; }

        public int Posicao { get; set; }

        public string Revisao { get; set; }

        public string RevisaoOriginal { get; set; }

        public string Descricao { get; set; }

        public string Data { get; set; }

        public string Elaborador { get; set; }

        public string Verificador { get; set; }

        public string Aprovador { get; set; }
    }

    /// <summary>
    /// Regras puras para operações sobre dados de revisões (substituição em lote, etc.).
    /// </summary>
    public static class OperacoesDeRevisao
    {
        /// <summary>
        /// Substitui uma ocorrência de texto em uma célula, como o <c>Substituir</c> do original.
        /// </summary>
        public static string Substituir(string texto, string de, string para)
        {
            if (string.IsNullOrEmpty(texto) || string.IsNullOrEmpty(de))
            {
                return texto ?? string.Empty;
            }

            if (!texto.Contains(de))
            {
                return texto;
            }

            return texto.Replace(de, para ?? string.Empty).Trim();
        }
    }

    /// <summary>
    /// O XData de um bloco de **revisão completa** — o <c>XDataGeral.gravarXDataRevisao</c> e
    /// <c>LeXDataRevisao</c> do original: AppName <c>DiagLog</c>, marca <c>Revisao</c>.
    ///
    /// Layout (15 valores):
    /// | idx | código | campo |
    /// |-----|--------|-------|
    /// | 0 | 1001 | "DiagLog" |
    /// | 1 | 1000 | "Revisao" |
    /// | 2 | 1070 | Posicao |
    /// | 3 | 1000 | Revisao |
    /// | 4 | 1000 | Descricao |
    /// | 5 | 1000 | Elaborador |
    /// | 6 | 1000 | Verificador |
    /// | 7 | 1000 | Aprovador |
    /// | 8 | 1000 | Data |
    /// | 9 | 1070 | 1 |
    /// | 10 | 1000 | usuario |
    /// | 11 | 1000 | data/hora |
    /// | 12 | 1071 | 1 |
    /// | 13 | 1040 | 1.1 |
    /// | 14 | 1000 | " " |
    /// </summary>
    public static class RevisaoCompletaXData
    {
        public const string AppName = "DiagLog";

        public const string Marca = "Revisao";

        public const int QuantidadeMinimaValores = 9;

        /// <summary>
        /// Lê os campos do XData de revisão do bloco.
        /// </summary>
        public static bool Ler(IReadOnlyList<TypedXData> valores, out RevisaoCompletaDaPagina revisao)
        {
            revisao = null;

            if (valores == null || valores.Count < QuantidadeMinimaValores)
            {
                return false;
            }

            if (valores[0].Codigo != 1001
                || !string.Equals(valores[0].Valor as string, AppName, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            if (!string.Equals(Convert.ToString(valores[1].Valor), Marca, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            revisao = new RevisaoCompletaDaPagina
            {
                Posicao = XDataNumero.Inteiro(valores[2].Valor),
                Revisao = ValorTexto(valores[3].Valor),
                RevisaoOriginal = ValorTexto(valores[3].Valor),
                Descricao = ValorTexto(valores[4].Valor),
                Elaborador = ValorTexto(valores[5].Valor),
                Verificador = ValorTexto(valores[6].Valor),
                Aprovador = ValorTexto(valores[7].Valor),
                Data = ValorTexto(valores[8].Valor),
            };

            return true;
        }

        /// <summary>
        /// Produz os 15 valores de XData no formato fiel do original.
        /// </summary>
        public static IReadOnlyList<TypedXData> ParaValores(RevisaoCompletaDaPagina rev, string usuario, string dataHora)
        {
            if (rev == null)
            {
                throw new ArgumentNullException("rev");
            }

            return new List<TypedXData>
            {
                new TypedXData(1001, AppName),
                new TypedXData(1000, Marca),
                new TypedXData(1070, rev.Posicao),
                new TypedXData(1000, rev.Revisao ?? string.Empty),
                new TypedXData(1000, rev.Descricao ?? string.Empty),
                new TypedXData(1000, rev.Elaborador ?? string.Empty),
                new TypedXData(1000, rev.Verificador ?? string.Empty),
                new TypedXData(1000, rev.Aprovador ?? string.Empty),
                new TypedXData(1000, rev.Data ?? string.Empty),
                new TypedXData(1070, 1),
                new TypedXData(1000, usuario ?? string.Empty),
                new TypedXData(1000, dataHora ?? string.Empty),
                new TypedXData(1071, 1),
                new TypedXData(1040, 1.1),
                new TypedXData(1000, " "),
            };
        }

        private static string ValorTexto(object valor)
        {
            if (valor == null || valor is DBNull)
            {
                return string.Empty;
            }

            return Convert.ToString(valor);
        }
    }
}

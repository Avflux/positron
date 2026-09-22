using System.Collections.Generic;
using Positron.Data.Fiacao;

namespace Positron.Data.Plaquetas
{
    /// <summary>
    /// Uma plaqueta declarada no dicionário do desenho — o
    /// <c>Declaracoes2.StructurePlaquetas</c> do original.
    /// </summary>
    public sealed class PlaquetaDefinicao
    {
        /// <summary>Tipo da plaqueta: <c>"P"</c> (painel), <c>"D"</c> (dispositivo), <c>"X"</c> (texto livre/vários) ou <c>"R"</c> (régua).</summary>
        public string Tipo { get; set; }

        /// <summary>Handle do bloco a que a plaqueta se refere (em <c>"X"</c> é só a chave de ordenação, o <c>#n</c>).</summary>
        public string Handle { get; set; }

        /// <summary>Índice da régua (só usado no tipo <c>"R"</c>).</summary>
        public int IndiceRegua { get; set; }

        public string Desc1 { get; set; }

        public string Desc2 { get; set; }

        public string Desc3 { get; set; }

        public string Modelo { get; set; }
    }

    /// <summary>
    /// O dicionário <c>CENG_PLAQUETA</c> do desenho — um <c>Xrecord</c> por
    /// **painel**, com registros de **7 valores** cada:
    ///
    /// | idx | código | campo        |
    /// |-----|--------|--------------|
    /// | 0   | 1      | Tipo         |
    /// | 1   | 1      | Handle       |
    /// | 2   | 70     | IndiceRegua  |
    /// | 3   | 1      | Desc1        |
    /// | 4   | 1      | Desc2        |
    /// | 5   | 1      | Desc3        |
    /// | 6   | 1      | Modelo       |
    ///
    /// Recuperado de <c>DicionarioPlaqueta.gravaDicPlaqueta</c>/<c>LeDicPlaquetas</c>
    /// (engenharia reversa, ver docs/POSITRON.md).
    ///
    /// A leitura é por **blocos de 7**: o original calcula
    /// <c>Round((UBound+1)/7)</c> registros e varre de 7 em 7. Um XData de
    /// terceiro com cauda incompleta é ignorado em vez de estourar.
    /// </summary>
    public static class PlaquetasXData
    {
        /// <summary>Nome do dicionário de plaquetas no <c>NamedObjectsDictionary</c>.</summary>
        public const string NomeDicionario = "CENG_PLAQUETA";

        /// <summary>Valores por registro (o <c>7 * num</c> do gravador).</summary>
        public const int ValoresPorRegistro = 7;

        /// <summary>
        /// Lê os registros do Xrecord de um painel. Devolve vazio (sem exceção)
        /// quando o dado é degenerado.
        /// </summary>
        public static IReadOnlyList<PlaquetaDefinicao> Ler(IReadOnlyList<TypedXData> valores)
        {
            List<PlaquetaDefinicao> plaquetas = new List<PlaquetaDefinicao>();
            if (valores == null)
            {
                return plaquetas;
            }

            int quantos = valores.Count / ValoresPorRegistro;
            for (int registro = 0; registro < quantos; registro++)
            {
                int i = registro * ValoresPorRegistro;
                plaquetas.Add(new PlaquetaDefinicao
                {
                    Tipo = Texto(valores[i].Valor),
                    Handle = Texto(valores[i + 1].Valor),
                    IndiceRegua = XDataNumero.Inteiro(valores[i + 2].Valor),
                    Desc1 = Texto(valores[i + 3].Valor),
                    Desc2 = Texto(valores[i + 4].Valor),
                    Desc3 = Texto(valores[i + 5].Valor),
                    Modelo = Texto(valores[i + 6].Valor),
                });
            }

            return plaquetas;
        }

        private static string Texto(object valor)
        {
            if (valor == null || valor is System.DBNull)
            {
                return string.Empty;
            }

            return valor as string ?? System.Convert.ToString(valor);
        }
    }
}

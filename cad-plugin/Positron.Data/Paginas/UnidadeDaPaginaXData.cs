using System;
using System.Collections.Generic;
using Positron.Data.Fiacao;

namespace Positron.Data.Paginas
{
    /// <summary>
    /// O XData da **unidade/alternativo** de uma pagina, gravado no <c>LayerTableRecord</c> — o
    /// <c>XDataGeral.GravarXDataUnidadeAlternativo</c>/<c>LeXDataUnidadeAlternativo</c> do original:
    /// app name <c>Eletron</c>, marca <c>Unidade</c>, a unidade e o alternativo.
    ///
    /// Layout (4 valores):
    ///
    /// | idx | codigo | campo |
    /// |-----|--------|-------|
    /// | 0 | 1001 | "Eletron" |
    /// | 1 | 1000 | "Unidade" |
    /// | 2 | 1000 | unidade |
    /// | 3 | 1000 | alternativo |
    ///
    /// O layout tem **quatro** valores quando o XData nasce; a **atualização** não recria o buffer:
    /// o <c>XDataGeral.AlteraXDataUnidadeAlternativo</c> troca só as posições 2 e 3 e conserva o
    /// resto — ver <see cref="Atualizar"/>. É o que o campo `EXTRA` de um desenho real (valores
    /// além dos quatro) exige.
    /// </summary>
    public static class UnidadeDaPaginaXData
    {
        public const string AppName = "Eletron";

        public const string Marca = "Unidade";

        public const int QuantidadeValores = 4;

        /// <summary>uscPaginas.bt6p1Bww9xD/T5Qp1VoBCME: só a resposta do menu, sem limite de 20.</summary>
        public static string NormalizarRespostaDoMenu(string resposta)
        {
            return (resposta ?? string.Empty).ToUpper().Trim();
        }

        public static IReadOnlyList<TypedXData> ParaValores(string unidade, string alternativo)
        {
            return new List<TypedXData>
            {
                new TypedXData(1001, AppName),
                new TypedXData(1000, Marca),
                new TypedXData(1000, unidade ?? string.Empty),
                new TypedXData(1000, alternativo ?? string.Empty),
            };
        }

        /// <summary>Le a unidade e o alternativo; <c>false</c> quando o XData nao e o da pagina.</summary>
        public static bool Ler(IReadOnlyList<TypedXData> valores, out string unidade, out string alternativo)
        {
            unidade = string.Empty;
            alternativo = string.Empty;

            if (valores == null || valores.Count < QuantidadeValores)
            {
                return false;
            }

            if (!EhMarcaUnidade(valores))
            {
                return false;
            }

            unidade = valores[2].Valor == null ? string.Empty : Convert.ToString(valores[2].Valor);
            alternativo = valores[3].Valor == null ? string.Empty : Convert.ToString(valores[3].Valor);
            return true;
        }

        /// <summary>
        /// O XData é o da página — app <c>Eletron</c> e marca <c>Unidade</c>?
        /// O <c>if (array[1].Value.ToString().ToUpper() == "UNIDADE")</c> do
        /// <c>AlteraXDataUnidadeAlternativo</c> (<c>XDataGeral.cs:1289</c>), com a comparação sem
        /// caixa do <c>TextCompare</c>.
        /// </summary>
        public static bool EhMarcaUnidade(IReadOnlyList<TypedXData> valores)
        {
            if (valores == null || valores.Count < 2)
            {
                return false;
            }

            if (valores[0].Codigo != 1001
                || !string.Equals(valores[0].Valor as string, AppName, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            return string.Equals(Convert.ToString(valores[1].Valor), Marca, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Os valores a **escrever** no layer (o <c>XDataGeral.AlteraXDataUnidadeAlternativo</c>,
        /// <c>XDataGeral.cs:1243-1296</c>):
        /// <list type="bullet">
        /// <item>sem XData → **cria** a marca com os quatro valores
        /// (<c>GravarXDataUnidadeAlternativo</c>, <c>:1085-1124</c>);</item>
        /// <item>com o XData da marca <c>Unidade</c> → troca **só** as posições 2 e 3 e conserva o
        /// resto do buffer (posições 0, 1 e da 4 em diante);</item>
        /// <item>com **outra** marca → <c>null</c>: o <c>if</c> do original não tem <c>else</c> e
        /// nada é gravado.</item>
        /// </list>
        /// </summary>
        public static IReadOnlyList<TypedXData> Atualizar(IReadOnlyList<TypedXData> existentes,
            string unidade, string alternativo)
        {
            if (existentes == null)
            {
                return ParaValores(unidade, alternativo);
            }

            if (!EhMarcaUnidade(existentes))
            {
                return null;
            }

            List<TypedXData> valores = new List<TypedXData>(existentes);
            // O original acessa `array[2]`/`array[3]` direto: um buffer mais curto estouraria lá.
            // Aqui ele é completado até os quatro — mantém a leitura tolerante do recoder.
            while (valores.Count < QuantidadeValores)
            {
                valores.Add(new TypedXData(1000, string.Empty));
            }

            valores[2] = new TypedXData(1000, unidade ?? string.Empty);
            valores[3] = new TypedXData(1000, alternativo ?? string.Empty);
            return valores;
        }
    }
}

using System;
using System.Collections.Generic;
using Positron.Data.Fiacao;

namespace Positron.Data.Modelos
{
    /// <summary>
    /// Um **bloco de modelo** do desenho: o <c>BlockReference</c> que traz o XData
    /// do app name <c>Modelo</c> — a referência ao modelo de contato e ao contato
    /// auxiliar que ele usa.
    /// </summary>
    public sealed class BlocoModelo
    {
        /// <summary>Handle do próprio bloco no desenho (preenchido pelo adapter).</summary>
        public string Handle { get; set; }

        /// <summary>Handle do bob — o dispositivo cujo contato este modelo representa (<c>array[1]</c>).</summary>
        public string HandleBob { get; set; }

        /// <summary>Índice do modelo de contato (<c>array[2]</c>).</summary>
        public int IndexModelo { get; set; }

        /// <summary>Índice do contato (<c>array[3]</c>).</summary>
        public int IndexContato { get; set; }

        /// <summary>Handle do **bloco do contato auxiliar** que casa com esta chave (<c>array[4]</c>) — o que o <c>CorrigeContatosAux</c> preenche.</summary>
        public string HandleContatoAux { get; set; }
    }

    /// <summary>
    /// XData do app name <c>Modelo</c>: o que um bloco de modelo guarda. Recuperado
    /// de <c>XDataDispositivosMaster.LeXDataModelo</c> / <c>GravarXDataDispModelo</c>
    /// (engenharia reversa, ver docs/POSITRON.md):
    ///
    /// | idx | código | campo             |
    /// |-----|--------|-------------------|
    /// | 0   | 1001   | "Modelo"         |
    /// | 1   | 1000   | HandleBob         |
    /// | 2   | 1071   | indexModelo       |
    /// | 3   | 1071   | indexContato      |
    /// | 4   | 1000   | HandleContatoAux  |
    ///
    /// O leitor aceita o app name legado <c>MODELO</c> (o original compara o valor
    /// **em maiúsculas** com <c>MODELO</c>, então os dois passam): é a mesma
    /// tolerância dos leitores de dispositivo.
    /// </summary>
    public static class ModeloXData
    {
        public const string AppName = "Modelo";

        /// <summary>App name legado que o original também aceita.</summary>
        public const string AppNameLegado = "MODELO";

        public const int QuantidadeValores = 5;

        /// <summary>
        /// Lê o XData do modelo. Devolve <c>false</c> (sem exceção) quando não é um
        /// <c>Modelo</c> válido — registro truncado é dado de terceiro, não erro
        /// fatal (o original estoura nos índices 1..4).
        /// </summary>
        public static bool Ler(IReadOnlyList<TypedXData> valores, out BlocoModelo modelo)
        {
            modelo = null;

            if (valores == null || valores.Count < QuantidadeValores)
            {
                return false;
            }

            string appName = valores[0].Valor as string;
            if (valores[0].Codigo != 1001 || appName == null ||
                !string.Equals(appName, AppName, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            modelo = new BlocoModelo
            {
                Handle = null,
                HandleBob = Texto(valores[1].Valor),
                IndexModelo = Inteiro(valores[2].Valor),
                IndexContato = Inteiro(valores[3].Valor),
                HandleContatoAux = Texto(valores[4].Valor),
            };
            return true;
        }

        /// <summary>
        /// Monta o XData do modelo no layout de 5 valores do
        /// <c>GravarXDataDispModelo</c> — o caminho de escrita do
        /// <c>CorrigeContatosAux</c>. O app name sai sempre como
        /// <see cref="AppName"/>, mesmo quando o registro veio do legado.
        /// </summary>
        public static IReadOnlyList<TypedXData> ParaValores(BlocoModelo modelo)
        {
            BlocoModelo dados = modelo ?? new BlocoModelo();
            return new List<TypedXData>
            {
                new TypedXData(1001, AppName),
                new TypedXData(1000, dados.HandleBob ?? string.Empty),
                new TypedXData(1071, dados.IndexModelo),
                new TypedXData(1071, dados.IndexContato),
                new TypedXData(1000, dados.HandleContatoAux ?? string.Empty),
            };
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

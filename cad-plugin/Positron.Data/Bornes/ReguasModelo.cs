using System.Collections.Generic;
using Positron.Data.Fiacao;

namespace Positron.Data.Bornes
{
    /// <summary>Uma régua de bornes, como definida no desenho.</summary>
    public sealed class ReguaInfo
    {
        public int Indice { get; set; }

        public string Nome { get; set; }

        public string Alternativo { get; set; }

        public short Painel { get; set; }
    }

    /// <summary>
    /// As réguas do desenho. O original guarda em um <c>Xrecord</c> no
    /// dicionário de objetos nomeados do DWG —
    /// <c>NamedObjectsDictionary → "REGUAS" → "MODELOS2"</c> — e o lê em
    /// <c>DicionarioReguas.LeOsModelosDeRegua</c>.
    ///
    /// O XRecord é uma lista plana de <c>TypedValue</c>. O **índice 0 é o
    /// cabeçalho** — o maior <c>indexRegua</c> do desenho (o
    /// <c>array2[0] = num</c> do <c>GravaOsModelosDeRegua</c> e o
    /// <c>mModelo[0].iMaxIndice</c> do leitor) — e os registros começam no
    /// **índice 1**: cada régua ocupa **10 valores**, e do registro interessa:
    ///
    /// | deslocamento | campo          |
    /// |--------------|----------------|
    /// | +0           | indexRegua     |
    /// | +1           | nomeRegua      |
    /// | +2           | nomeAlternativo|
    /// | +3           | indexPainel    |
    ///
    /// Só entram as réguas com <c>indexPainel &gt; 0</c>; o original descarta as
    /// demais. O resto do registro (+4..+9) não é usado aqui.
    ///
    /// **Regressão medida no desenho real:** ler a partir do índice 0 fazia o
    /// cabeçalho virar "primeira régua" e deslocava todos os campos — com
    /// <c>indexPainel</c> lido do alternativo (texto) a régua virava 0 e
    /// **nenhuma** régua era aceita, o que zerava o <c>Bornes4F</c>.
    /// </summary>
    public sealed class ReguasModelo
    {
        /// <summary>Valores por régua no XRecord.</summary>
        public const int ValoresPorRegua = 10;

        private readonly Dictionary<int, ReguaInfo> _porIndice = new Dictionary<int, ReguaInfo>();
        private readonly List<ReguaInfo> _ordenadas = new List<ReguaInfo>();

        /// <summary>As réguas na ordem em que aparecem no XRecord.</summary>
        public IReadOnlyList<ReguaInfo> Ordenadas
        {
            get { return _ordenadas; }
        }

        public IReadOnlyCollection<ReguaInfo> Reguas
        {
            get { return _porIndice.Values; }
        }

        public ReguaInfo Buscar(int indice)
        {
            ReguaInfo regua;
            return _porIndice.TryGetValue(indice, out regua) ? regua : null;
        }

        /// <summary>
        /// Interpreta o conteúdo do XRecord <c>MODELOS2</c>. Valores truncados no
        /// fim são ignorados; um registro com painel 0 é descartado.
        /// </summary>
        public static ReguasModelo Ler(IReadOnlyList<TypedXData> valores)
        {
            ReguasModelo modelo = new ReguasModelo();

            if (valores == null)
            {
                return modelo;
            }

            // Começa em 1: o índice 0 é o cabeçalho (maior indexRegua), como no
            // `for (i = 1; ...)` do LeOsModelosDeRegua.
            for (int i = 1; i + 3 < valores.Count; i += ValoresPorRegua)
            {
                int indicePainel = Inteiro(valores[i + 3].Valor);
                if (indicePainel <= 0)
                {
                    continue;
                }

                ReguaInfo regua = new ReguaInfo
                {
                    Indice = Inteiro(valores[i + 0].Valor),
                    Nome = Texto(valores[i + 1].Valor),
                    Alternativo = Texto(valores[i + 2].Valor),
                    Painel = (short)indicePainel,
                };

                if (!modelo._porIndice.ContainsKey(regua.Indice))
                {
                    modelo._ordenadas.Add(regua);
                }
                else
                {
                    modelo._ordenadas.Remove(modelo._porIndice[regua.Indice]);
                    modelo._ordenadas.Add(regua);
                }

                modelo._porIndice[regua.Indice] = regua;
            }

            return modelo;
        }

        private static int Inteiro(object valor)
        {
            return valor == null || valor is System.DBNull ? 0 : XDataNumero.Inteiro(valor);
        }

        private static string Texto(object valor)
        {
            if (valor == null || valor is System.DBNull)
            {
                return null;
            }

            string texto = valor as string;
            return texto ?? System.Convert.ToString(valor);
        }
    }
}

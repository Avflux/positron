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
    /// O <c>lm</c> que a régua define por tipo de borne (+6 = tipo 0, +7 = tipo 1,
    /// como o <c>DicionarioBorne.BuscaLMdaRegua</c> do original).
    /// </summary>
    internal sealed class LmDaRegua
    {
        internal int Tipo0 { get; set; }

        internal int Tipo1 { get; set; }
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
        private readonly Dictionary<int, LmDaRegua> _lmPorIndice = new Dictionary<int, LmDaRegua>();

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
        /// O <c>lm</c> que a régua define para o tipo de borne informado — o
        /// <c>DicionarioBorne.BuscaLMdaRegua</c> do original, usado na **gravação**
        /// do borne (<c>GravarXDataDispBorne</c> resolve o <c>lm</c> quando ele
        /// está zerado). Tipo 0 lê o campo +6 do registro; tipo 1, o +7; qualquer
        /// outro devolve 0, como o original.
        ///
        /// Diferente de <see cref="Buscar"/>, aqui **não** se filtra por painel: o
        /// original casa só o índice da régua, então uma régua com painel 0 ainda
        /// pode definir o <c>lm</c>.
        /// </summary>
        public int BuscarLm(int indiceRegua, int tipo)
        {
            LmDaRegua lm;
            if (!_lmPorIndice.TryGetValue(indiceRegua, out lm))
            {
                return 0;
            }

            if (tipo == 0)
            {
                return lm.Tipo0;
            }

            return tipo == 1 ? lm.Tipo1 : 0;
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
                // O `lm` por tipo sai de **todo** registro (o BuscaLMdaRegua do
                // original não filtra por painel); é lido antes do descarte abaixo.
                if (i + 7 < valores.Count)
                {
                    modelo._lmPorIndice[Inteiro(valores[i + 0].Valor)] = new LmDaRegua
                    {
                        Tipo0 = Inteiro(valores[i + 6].Valor),
                        Tipo1 = Inteiro(valores[i + 7].Valor),
                    };
                }

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

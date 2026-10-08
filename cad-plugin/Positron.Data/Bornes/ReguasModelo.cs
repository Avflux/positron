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
    /// O XRecord é uma lista plana de <c>TypedValue</c>: cada régua ocupa **10
    /// valores**, e do registro interessa (ver o reverso):
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

            for (int i = 0; i + 3 < valores.Count; i += ValoresPorRegua)
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
            return valor == null || valor is System.DBNull ? 0 : System.Convert.ToInt32(valor);
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

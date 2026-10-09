using System.Collections.Generic;

namespace Positron.Data.Fiacao
{
    /// <summary>Um trecho de fiação lido do desenho: a <c>CONEXAO</c> com as duas pontas.</summary>
    public sealed class TrechoFiacao
    {
        public string Handle { get; set; }

        public string Pagina { get; set; }

        public int Potencial { get; set; }

        public short Tipo { get; set; }

        public double IniX { get; set; }

        public double IniY { get; set; }

        public double FimX { get; set; }

        public double FimY { get; set; }
    }

    /// <summary>
    /// Fiação desenhada **em duplicidade** — o <c>LFiacaoTTDuplicada</c> do
    /// <c>ClsVerificadorProjetoFiacao</c> (linha ~961).
    ///
    /// A regra do original é: dois trechos de **<c>Tipo == 2</c>**, na **mesma
    /// página**, com **as duas pontas iguais** e **handles diferentes**. Quando
    /// acontece, ele guarda o handle do trecho de **menor potencial**.
    ///
    /// Ou seja: não é "terminal repetido" (dois bornes diferentes numerados 11 no
    /// mesmo potencial são normais — era o que a nossa regra antiga apontava, 110
    /// vezes no desenho real), e sim **o mesmo fio desenhado duas vezes**.
    /// </summary>
    public static class FiacaoDuplicada
    {
        public static List<ProblemaFiacaoDuplicada> Verificar(IEnumerable<TrechoFiacao> trechos)
        {
            List<ProblemaFiacaoDuplicada> problemas = new List<ProblemaFiacaoDuplicada>();
            if (trechos == null)
            {
                return problemas;
            }

            List<TrechoFiacao> lista = new List<TrechoFiacao>();
            foreach (TrechoFiacao trecho in trechos)
            {
                if (trecho != null && trecho.Tipo == 2)
                {
                    lista.Add(trecho);
                }
            }

            for (int i = 0; i < lista.Count; i++)
            {
                for (int j = i + 1; j < lista.Count; j++)
                {
                    TrechoFiacao a = lista[i];
                    TrechoFiacao b = lista[j];

                    if (string.Equals(a.Handle, b.Handle, System.StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    if (!string.Equals(a.Pagina ?? string.Empty, b.Pagina ?? string.Empty, System.StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    if (a.IniX != b.IniX || a.IniY != b.IniY || a.FimX != b.FimX || a.FimY != b.FimY)
                    {
                        continue;
                    }

                    // O original aponta o handle do trecho de menor potencial.
                    TrechoFiacao menor = a.Potencial <= b.Potencial ? a : b;
                    problemas.Add(new ProblemaFiacaoDuplicada { Handle = menor.Handle, Pagina = menor.Pagina, Potencial = menor.Potencial });
                }
            }

            return problemas;
        }
    }

    /// <summary>Um trecho de fiação apontado como duplicado.</summary>
    public sealed class ProblemaFiacaoDuplicada
    {
        public string Handle { get; set; }

        public string Pagina { get; set; }

        public int Potencial { get; set; }
    }
}

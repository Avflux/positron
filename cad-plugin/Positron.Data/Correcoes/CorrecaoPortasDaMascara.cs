using System.Collections.Generic;
using Positron.Data.Modelos;

namespace Positron.Data.Correcoes
{
    /// <summary>
    /// A regra do <c>corrigeDicMascaras</c> do <c>Correcao.cs</c> — o par de escrita
    /// do <c>bt13ReguaMascara</c> (a checagem da régua da máscara, rodada 52) sobre o
    /// dicionário <c>MASCARAS</c>: normaliza a **lista de portas** de cada modelo.
    ///
    /// Três passos, na ordem do original:
    ///
    /// 1. **dedup por <see cref="ModeloPorta.IndiceDaPorta"/>**, mantendo a
    ///    **primeira** ocorrência (o <c>List.Contains</c> do original);
    /// 2. **ordenação crescente** por índice (o <c>OrdenaAsPortasDoModeloMascara</c>,
    ///    uma bolha simples);
    /// 3. o <c>MaxIndice</c> do registro passa a ser o **maior índice mantido** — o
    ///    original começa o cabeçalho em 0 e só o atualiza no ramo do dedup, então
    ///    ele é **recalculado**, não preservado (quirk reproduzido de propósito: o
    ///    gravador não lê o cabeçalho antigo).
    ///
    /// O original classifica **duas vezes** — uma no comando e outra dentro do
    /// <c>GravaAsPortasDoModeloDoDicionario</c>; a segunda é no-op e por isso aqui
    /// há uma só.
    /// </summary>
    public static class CorrecaoPortasDaMascara
    {
        /// <summary>O resultado do planejamento de um modelo.</summary>
        public sealed class Resultado
        {
            /// <summary>As portas que ficam, já sem duplicadas e em ordem crescente de índice.</summary>
            public IReadOnlyList<ModeloPorta> Portas { get; set; }

            /// <summary>O novo <c>MaxIndice</c> do registro (0 sem portas).</summary>
            public int MaxIndice { get; set; }

            /// <summary>Quantas portas foram descartadas por repetir o índice.</summary>
            public int Removidas { get; set; }
        }

        public static Resultado Planejar(IReadOnlyList<ModeloPorta> portas)
        {
            List<ModeloPorta> mantidas = new List<ModeloPorta>();
            Resultado resultado = new Resultado
            {
                Portas = mantidas,
                MaxIndice = 0,
                Removidas = 0,
            };

            if (portas == null)
            {
                return resultado;
            }

            List<int> vistos = new List<int>();
            foreach (ModeloPorta porta in portas)
            {
                if (porta == null)
                {
                    continue;
                }

                if (vistos.Contains(porta.IndiceDaPorta))
                {
                    resultado.Removidas++;
                    continue;
                }

                vistos.Add(porta.IndiceDaPorta);
                mantidas.Add(porta);
                if (resultado.MaxIndice < porta.IndiceDaPorta)
                {
                    resultado.MaxIndice = porta.IndiceDaPorta;
                }
            }

            Ordenar(mantidas);
            return resultado;
        }

        /// <summary>A bolha do <c>OrdenaAsPortasDoModeloMascara</c> (crescente por índice; com menos de duas portas, não faz nada).</summary>
        private static void Ordenar(List<ModeloPorta> portas)
        {
            if (portas.Count < 2)
            {
                return;
            }

            for (int i = portas.Count - 1; i >= 1; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (portas[j].IndiceDaPorta > portas[j + 1].IndiceDaPorta)
                    {
                        ModeloPorta troca = portas[j + 1];
                        portas[j + 1] = portas[j];
                        portas[j] = troca;
                    }
                }
            }
        }
    }
}

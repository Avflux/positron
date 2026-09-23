using System;
using System.Collections.Generic;

namespace Positron.Data.Correcoes
{
    /// <summary>Um borne do desenho, como a correção de ordem precisa dele.</summary>
    public sealed class BorneDeOrdem
    {
        public string Handle { get; set; }

        public int IndiceRegua { get; set; }

        public double Ordem { get; set; }
    }

    /// <summary>
    /// A regra do comando <c>corrigeOrdemBornes</c> do original
    /// (<c>Correcao.cs</c>, um dos botões de correção da tela de verificação) —
    /// a contrapartida de **escrita** do <c>IntervaloBorneInvalido</c> do
    /// <c>VERIF</c>: o borne cujo <c>Ordem</c> está fora da sequência da régua
    /// volta para <c>1..N</c>, respeitando as ordens dos **bornes de reserva**
    /// (<c>CENG_BORNES</c>), que não podem ser ocupadas.
    ///
    /// Sequência do original, reproduzida aqui:
    /// 1. **ordena** os bornes por <c>IndiceRegua</c> e, na mesma régua, por
    ///    <c>Ordem</c> — com a bolha do original, inclusive as duas comparações
    ///    independentes (a segunda é avaliada **depois** de um eventual primeiro
    ///    swap, então o resultado não é o de uma comparação composta);
    /// 2. percorre na ordem e renumera <c>1..N</c> por régua, **pulando** as
    ///    ordens das reservas (`k` avança enquanto o número está reservado);
    /// 3. devolve só os bornes cuja ordem **muda** (o original relê cada um e
    ///    regrava o XData apenas quando difere).
    ///
    /// O que é puro é a decisão (esta classe); quem varre o desenho e grava é o
    /// adapter do plugin.
    /// </summary>
    public static class CorrecaoOrdemBornes
    {
        /// <summary>Um borne cuja ordem muda (o que o adapter tem de regravar).</summary>
        public sealed class Ajuste
        {
            public string Handle { get; set; }

            public double OrdemAntiga { get; set; }

            public double OrdemNova { get; set; }
        }

        /// <summary>
        /// Planeja a correção. <paramref name="ordensReservadas"/> recebe o índice
        /// da régua e devolve as ordens já ocupadas pelos bornes de reserva (vazio
        /// quando a régua não tem registro no dicionário).
        /// </summary>
        public static IReadOnlyList<Ajuste> Planejar(
            IReadOnlyList<BorneDeOrdem> bornes,
            Func<int, IReadOnlyList<int>> ordensReservadas)
        {
            List<Ajuste> ajustes = new List<Ajuste>();
            if (bornes == null || bornes.Count == 0)
            {
                return ajustes;
            }

            List<BorneDeOrdem> ordenados = new List<BorneDeOrdem>(bornes);

            // O `if (UBound(array) >= 2)` do original: com um borne só não há o que
            // ordenar (na verdade UBound é o número de bornes, então o laço roda a
            // partir de dois — mantido como está).
            if (ordenados.Count >= 2)
            {
                int n = ordenados.Count;
                for (int i = 0; i < n; i++)
                {
                    for (int j = n - 2; j >= i; j--)
                    {
                        if (ordenados[j].IndiceRegua > ordenados[j + 1].IndiceRegua)
                        {
                            Trocar(ordenados, j, j + 1);
                        }

                        if (ordenados[j].IndiceRegua == ordenados[j + 1].IndiceRegua
                            && ordenados[j].Ordem > ordenados[j + 1].Ordem)
                        {
                            Trocar(ordenados, j, j + 1);
                        }
                    }
                }
            }

            int reguaAtual = -1;
            List<int> reservadas = new List<int>();
            int k = 1;
            for (int i = 0; i < ordenados.Count; i++)
            {
                if (reguaAtual != ordenados[i].IndiceRegua)
                {
                    reguaAtual = ordenados[i].IndiceRegua;
                    reservadas.Clear();
                    IReadOnlyList<int> doDicionario = ordensReservadas == null
                        ? null
                        : ordensReservadas(reguaAtual);
                    if (doDicionario != null)
                    {
                        reservadas.AddRange(doDicionario);
                    }

                    k = 1;
                }

                while (reservadas.Contains(k))
                {
                    k++;
                }

                if (ordenados[i].Ordem != k)
                {
                    ajustes.Add(new Ajuste
                    {
                        Handle = ordenados[i].Handle,
                        OrdemAntiga = ordenados[i].Ordem,
                        OrdemNova = k,
                    });
                }

                ordenados[i].Ordem = k;
                k++;
            }

            return ajustes;
        }

        private static void Trocar(List<BorneDeOrdem> lista, int a, int b)
        {
            BorneDeOrdem temporario = lista[a];
            lista[a] = lista[b];
            lista[b] = temporario;
        }
    }
}

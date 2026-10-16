using System;
using System.Collections.Generic;

namespace Positron.Data.Paginas
{
    /// <summary>
    /// As duas contas que a **grade das folhas** faz antes de gravar — as que o item 2 da correção
    /// do básico tirou da tela (`uscPaginas`):
    ///
    /// 1. <see cref="ReferenciaDaNovaPagina"/> é o começo do `TBNp1Uume8n` (`uscPaginas.cs:1893`), o
    ///    handler da **Nova Página** e da tecla **Insert**: a referência é a **linha selecionada** e a
    ///    posterior é a **linha seguinte** — e, na última, o sentinela `"1000000"` do original, que o
    ///    <see cref="NovaPaginaEntre.Calcular"/> já trata como o fim;
    /// 2. <see cref="LinhaAposApagar"/> é o `JaTp14wdVuV` (`uscPaginas.cs:2225`), chamado **antes** de
    ///    apagar: a linha que o handler reseleciona no fim é a **primeira selecionada menos um**,
    ///    nunca abaixo de zero.
    /// </summary>
    public static class GradeDeFolhas
    {
        /// <summary>
        /// A referência da página nova a partir da grade: a linha selecionada e a **seguinte**.
        /// Devolve <c>false</c> quando a linha não existe na grade (nada selecionado, ou fora dela) —
        /// o que o original faria estourando o índice.
        /// </summary>
        public static bool ReferenciaDaNovaPagina(
            IReadOnlyList<string> paginasDaGrade, int linhaSelecionada, out string anterior, out string posterior)
        {
            anterior = string.Empty;
            posterior = string.Empty;

            if (paginasDaGrade == null || linhaSelecionada < 0 || linhaSelecionada >= paginasDaGrade.Count)
            {
                return false;
            }

            anterior = (paginasDaGrade[linhaSelecionada] ?? string.Empty).Trim();
            if (anterior.Length == 0)
            {
                return false;
            }

            if (linhaSelecionada + 1 < paginasDaGrade.Count)
            {
                posterior = (paginasDaGrade[linhaSelecionada + 1] ?? string.Empty).Trim();
            }

            if (posterior.Length == 0)
            {
                posterior = NovaPaginaEntre.Fim;
            }

            return true;
        }

        /// <summary>
        /// A linha que fica selecionada depois de apagar: a primeira das selecionadas menos um, com o
        /// piso em zero (`JaTp14wdVuV`). Sem nenhuma selecionada o original começa com o valor `0`.
        /// </summary>
        public static int LinhaAposApagar(IReadOnlyList<int> linhasSelecionadas)
        {
            int valor = 0;
            if (linhasSelecionadas != null)
            {
                int primeira = int.MaxValue;
                foreach (int linha in linhasSelecionadas)
                {
                    if (linha < primeira)
                    {
                        primeira = linha;
                    }
                }

                if (primeira != int.MaxValue)
                {
                    valor = primeira - 1;
                }
            }

            return valor < 0 ? 0 : valor;
        }
    }
}

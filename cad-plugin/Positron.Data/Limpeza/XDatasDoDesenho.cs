using System;
using System.Collections.Generic;

namespace Positron.Data.Limpeza
{
    /// <summary>Quantas entidades do desenho carregam o XData de um app name.</summary>
    public sealed class ContagemDeXData
    {
        public ContagemDeXData(string nome, int quantidade)
        {
            Nome = nome;
            Quantidade = quantidade;
        }

        /// <summary>O app name (sempre em maiúsculas, como o original o lê).</summary>
        public string Nome { get; private set; }

        public int Quantidade { get; private set; }
    }

    /// <summary>
    /// A regra da tela <c>frmPesquisaXdatas</c> — o comando <c>APAGARXDATA</c> do original. A
    /// tela mostra os **app names de XData** que o desenho carrega, com a contagem de entidades
    /// de cada um, e deixa apagar os escolhidos.
    ///
    /// Dois pontos de fidelidade que estão no reverso e importam:
    ///
    /// 1. a lista de app names que o produto **considera dele** (`ARANHA`, `CONEXAO`,
    ///    `DISPOSITIVO`…) é **fixa** no código do formulário e é usada como **filtro**: o que
    ///    aparece na grade é só o que **não** é do Elétron. O `CkXdataEletron` existe para
    ///    desligar esse filtro, mas o próprio construtor o deixa **invisível e desmarcado** —
    ///    ou seja, na prática o filtro está sempre ligado;
    /// 2. o nome do app vem do **último `1001`** do XData da entidade (o
    ///    `LeTodosOsXdatasDoCaderno` do `clsApagaXdatas` varre o buffer e fica com o último),
    ///    **em maiúsculas**.
    ///
    /// A varredura do desenho e a gravação ficam no adapter
    /// (<c>Positron.Plugin.Limpeza.XDatasDoCad</c>) — aqui só a regra.
    /// </summary>
    public static class XDatasDoDesenho
    {
        /// <summary>
        /// A lista fixa do <c>frmPesquisaXdatas</c> (na ordem em que o original a escreve; o
        /// teste dela é presença, não ordem).
        /// </summary>
        private static readonly string[] NomesDoProduto =
        {
            "ACAD",
            "ARANHA",
            "AUXBORNES",
            "AUXCONEXAO",
            "AUXDERIVACAO",
            "AUXINTERLIG",
            "CONEXAO",
            "DEFINICAO",
            "DEPARA",
            "DIAGLOG",
            "DISPOSITIVO",
            "DISP_FUNCAO",
            "DISTRIBUICAODEPOTENCIAIS",
            "ELETROSUL",
            "ELETRON",
            "EXPORTADO",
            "INTERLIGACAO",
            "LAYOUT",
            "LINHATEXTOLP",
            "MODELO",
            "TEXTOLP",
            "AUXIMPORTADO",
            "IMPORTADO",
            "MATERIAIS",
            "PLAQUETAS",
            "AUXEXPORTADO",
            "PADRAOINTERLIGACAOBORNE",
            "PADRAOINTERLIGACAOCABO",
            "PADRAOINTERLIGACAOCABOLINHA",
            "FIACAODWG",
            "DINTERLIG",
            "TOPOGRAFICO",
        };

        /// <summary>Os app names que o produto considera dele (o filtro da tela).</summary>
        public static IReadOnlyList<string> NomesDoEletron
        {
            get { return NomesDoProduto; }
        }

        /// <summary>O app name é do produto? (comparação ordinal, com o nome já em maiúsculas.)</summary>
        public static bool EhDoEletron(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                return false;
            }

            foreach (string conhecido in NomesDoProduto)
            {
                if (string.Equals(conhecido, nome, StringComparison.Ordinal))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Conta as entidades por app name, na ordem da **primeira aparição** (a ordem em que a
        /// grade do original fica) e sem repetir — o `BuscaxDatasNaoEletron` do
        /// <c>clsApagaXdatas</c>.
        /// </summary>
        /// <param name="nomePorEntidade">
        /// O app name de cada entidade com XData, na ordem em que o desenho foi varrido (pode
        /// vir vazio quando a entidade não tem nome legível).
        /// </param>
        /// <param name="incluirEletron">Mostra também os app names do produto (o `CkXdataEletron`).</param>
        public static IReadOnlyList<ContagemDeXData> Contar(IReadOnlyList<string> nomePorEntidade, bool incluirEletron)
        {
            List<ContagemDeXData> contagens = new List<ContagemDeXData>();
            if (nomePorEntidade == null)
            {
                return contagens;
            }

            List<string> nomes = new List<string>();
            List<int> quantidades = new List<int>();

            foreach (string bruto in nomePorEntidade)
            {
                if (string.IsNullOrEmpty(bruto))
                {
                    continue;
                }

                string nome = bruto.ToUpperInvariant();
                if (!incluirEletron && EhDoEletron(nome))
                {
                    continue;
                }

                int achado = nomes.IndexOf(nome);
                if (achado < 0)
                {
                    nomes.Add(nome);
                    quantidades.Add(1);
                    continue;
                }

                quantidades[achado] = quantidades[achado] + 1;
            }

            for (int i = 0; i < nomes.Count; i++)
            {
                contagens.Add(new ContagemDeXData(nomes[i], quantidades[i]));
            }

            return contagens;
        }
    }
}

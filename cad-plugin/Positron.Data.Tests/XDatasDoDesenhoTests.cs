using System.Collections.Generic;
using Positron.Data.Limpeza;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// A regra do <c>frmPesquisaXdatas</c> (o comando <c>APAGARXDATA</c> do reverso): a lista fixa
    /// de app names do produto usada como filtro e a contagem de entidades por app name, na ordem
    /// da primeira aparição — o <c>BuscaxDatasNaoEletron</c> do <c>clsApagaXdatas</c>.
    /// </summary>
    public class XDatasDoDesenhoTests
    {
        [Fact]
        public void AListaDoProdutoEADoReverso()
        {
            // os 32 distintos do frmPesquisaXdatas (o original repete LAYOUT e ELETRON)
            Assert.Equal(32, XDatasDoDesenho.NomesDoEletron.Count);
            Assert.Contains("CONEXAO", XDatasDoDesenho.NomesDoEletron);
            Assert.Contains("DINTERLIG", XDatasDoDesenho.NomesDoEletron);
            Assert.Contains("TOPOGRAFICO", XDatasDoDesenho.NomesDoEletron);
            Assert.Contains("AUXINTERLIG", XDatasDoDesenho.NomesDoEletron);
            Assert.Contains("PADRAOINTERLIGACAOBORNE", XDatasDoDesenho.NomesDoEletron);
        }

        /// <summary>
        /// A comparação da lista é **ordinal** sobre o nome já em maiúsculas (o
        /// `List.Contains` do original sobre um nome que veio de um `ToUpper`).
        /// </summary>
        [Fact]
        public void OTesteDaListaEOrdinal()
        {
            Assert.True(XDatasDoDesenho.EhDoEletron("CONEXAO"));
            Assert.True(XDatasDoDesenho.EhDoEletron("ELETRON"));
            Assert.False(XDatasDoDesenho.EhDoEletron("Conexao"));
            Assert.False(XDatasDoDesenho.EhDoEletron("AEC_XDATA_BOUND_SPACE"));
            Assert.False(XDatasDoDesenho.EhDoEletron(null));
            Assert.False(XDatasDoDesenho.EhDoEletron(string.Empty));
        }

        /// <summary>O que aparece na grade é o que **não** é do produto — o filtro do original.</summary>
        [Fact]
        public void ContaSoOsDeTerceirosNaOrdemDaPrimeiraAparicao()
        {
            List<string> nomes = new List<string>
            {
                "AEC_XDATA_BOUND_SPACE",
                "CONEXAO",
                "ACAD",
                "AEC_XDATA_BOUND_SPACE",
                "OUTRO_APP",
                "CONEXAO",
            };

            IReadOnlyList<ContagemDeXData> contagens = XDatasDoDesenho.Contar(nomes, false);

            Assert.Equal(2, contagens.Count);
            Assert.Equal("AEC_XDATA_BOUND_SPACE", contagens[0].Nome);
            Assert.Equal(2, contagens[0].Quantidade);
            Assert.Equal("OUTRO_APP", contagens[1].Nome);
            Assert.Equal(1, contagens[1].Quantidade);
        }

        /// <summary>O nome entra em maiúsculas (o `LeTodosOsXdatasDoCaderno` faz `ToUpper`).</summary>
        [Fact]
        public void ONomeEntraEmMaiusculasEAgradeNaoRepete()
        {
            List<string> nomes = new List<string> { "outro_app", "OUTRO_APP", "Outro_App" };

            IReadOnlyList<ContagemDeXData> contagens = XDatasDoDesenho.Contar(nomes, false);

            Assert.Single(contagens);
            Assert.Equal("OUTRO_APP", contagens[0].Nome);
            Assert.Equal(3, contagens[0].Quantidade);
        }

        /// <summary>
        /// O `CkXdataEletron` do original desliga o filtro — desmarcado ele é o comportamento
        /// padrão (e o construtor ainda o esconde).
        /// </summary>
        [Fact]
        public void OIncluirEletronDesligaOFiltro()
        {
            List<string> nomes = new List<string> { "OUTRO_APP", "CONEXAO", "CONEXAO" };

            IReadOnlyList<ContagemDeXData> semEletron = XDatasDoDesenho.Contar(nomes, false);
            Assert.Single(semEletron);
            Assert.Equal("OUTRO_APP", semEletron[0].Nome);

            IReadOnlyList<ContagemDeXData> comEletron = XDatasDoDesenho.Contar(nomes, true);
            Assert.Equal(2, comEletron.Count);
            Assert.Equal("OUTRO_APP", comEletron[0].Nome);
            Assert.Equal("CONEXAO", comEletron[1].Nome);
            Assert.Equal(2, comEletron[1].Quantidade);
        }

        [Fact]
        public void EntidadeSemNomeLegivelNaoConta()
        {
            List<string> nomes = new List<string> { null, string.Empty, "  ", "AEC_XDATA_BOUND_SPACE" };

            IReadOnlyList<ContagemDeXData> contagens = XDatasDoDesenho.Contar(nomes, false);

            // o nulo e o vazio nao viram app name; o espaco, sim (o original nao da Trim no nome
            // lido) — e a ordem e a da primeira aparicao, por isso o espaco vem antes
            Assert.Equal(2, contagens.Count);
            Assert.Equal("  ", contagens[0].Nome);
            Assert.Equal("AEC_XDATA_BOUND_SPACE", contagens[1].Nome);
            Assert.Equal(1, contagens[1].Quantidade);
        }

        [Fact]
        public void SemEntradaNaoHaContagem()
        {
            Assert.Empty(XDatasDoDesenho.Contar(null, false));
            Assert.Empty(XDatasDoDesenho.Contar(new List<string>(), false));
        }
    }
}

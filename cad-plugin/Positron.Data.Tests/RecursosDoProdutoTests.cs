using System;
using System.IO;
using Positron.Data.Recursos;
using Xunit;

namespace Positron.Data.Tests
{
    public class RecursosDoProdutoTests
    {
        [Fact]
        public void TodosOsRecursosConhecidosEstaoListados()
        {
            Assert.Contains("MascaraM.dwg", RecursosDoProduto.Todos);
            Assert.Contains("ErroFiacao.dwg", RecursosDoProduto.Todos);
            Assert.Contains("V_B_BORNECPFL.dwg", RecursosDoProduto.Todos);
            Assert.Contains("Revisao.dwg", RecursosDoProduto.Todos);
            Assert.Equal(4, RecursosDoProduto.Todos.Count);
        }

        [Theory]
        [InlineData(RecursosDoProduto.MascaraM, "AutoCAD 2010")]
        [InlineData(RecursosDoProduto.ErroFiacao, "AutoCAD 2007")]
        [InlineData(RecursosDoProduto.BorneCpfl, "AutoCAD 2010")]
        [InlineData(RecursosDoProduto.Revisao, "AutoCAD 2007")]
        public void RecursosEmbutidosSaoDwgsValidos(string nomeArquivo, string versaoEsperada)
        {
            byte[] bytes = RecursosDoProduto.ObterBytes(nomeArquivo);
            Assert.NotNull(bytes);
            Assert.True(bytes.Length > 1000, "Arquivo deve ter tamanho razoável (> 1000 bytes)");
            Assert.True(RecursosDoProduto.EhDwgValido(bytes), "Cabeçalho deve ser DWG válido");
            Assert.Equal(versaoEsperada, RecursosDoProduto.IdentificarVersaoDwg(bytes));
        }

        [Fact]
        public void ObterBytesSemExtensaoFunciona()
        {
            byte[] comExt = RecursosDoProduto.ObterBytes("MascaraM.dwg");
            byte[] semExt = RecursosDoProduto.ObterBytes("MascaraM");

            Assert.NotNull(comExt);
            Assert.NotNull(semExt);
            Assert.Equal(comExt.Length, semExt.Length);
        }

        [Fact]
        public void ObterBytesRecursoInexistenteDevolveNull()
        {
            byte[] bytes = RecursosDoProduto.ObterBytes("NaoExiste.dwg");
            Assert.Null(bytes);
        }

        [Fact]
        public void ValidacaoDeDwgRejeitaEntradaInvalida()
        {
            Assert.False(RecursosDoProduto.EhDwgValido(null));
            Assert.False(RecursosDoProduto.EhDwgValido(new byte[0]));
            Assert.False(RecursosDoProduto.EhDwgValido(new byte[] { 1, 2, 3 }));
            Assert.False(RecursosDoProduto.EhDwgValido(new byte[] { (byte)'B', (byte)'C', (byte)'1', (byte)'0', (byte)'2', (byte)'4' }));
            Assert.Equal("Inválido", RecursosDoProduto.IdentificarVersaoDwg(new byte[] { 1, 2, 3 }));
        }

        [Fact]
        public void PastasPadraoApontamParaEstruturaEsperada()
        {
            Assert.EndsWith(Path.Combine("Positron", "Recursos"), RecursosDoProduto.PastaPadraoPositron);
            Assert.EndsWith(Path.Combine("Cadgraph", "Eletron4"), RecursosDoProduto.PastaLegadaCadgraph);
        }

        [Fact]
        public void GarantirEmDiscoExtraiComSucessoEIdempotente()
        {
            string pastaTeste = Path.Combine(Path.GetTempPath(), "positron-recursos-teste-" + Guid.NewGuid().ToString("N"));
            try
            {
                // Primeira execução: extrai todos os 4 arquivos
                int primeiraVez = RecursosDoProduto.GarantirEmDisco(pastaTeste);
                Assert.Equal(4, primeiraVez);

                foreach (string nome in RecursosDoProduto.Todos)
                {
                    string caminho = Path.Combine(pastaTeste, nome);
                    Assert.True(File.Exists(caminho), "Arquivo deve existir: " + caminho);

                    byte[] esperados = RecursosDoProduto.ObterBytes(nome);
                    byte[] gravados = File.ReadAllBytes(caminho);
                    Assert.Equal(esperados.Length, gravados.Length);
                }

                // Segunda execução sem sobrescrever: idempotente (0 arquivos gravados)
                int segundaVez = RecursosDoProduto.GarantirEmDisco(pastaTeste, sobrescrever: false);
                Assert.Equal(0, segundaVez);

                // Terceira execução com sobrescrever: regrava os 4
                int terceiraVez = RecursosDoProduto.GarantirEmDisco(pastaTeste, sobrescrever: true);
                Assert.Equal(4, terceiraVez);
            }
            finally
            {
                if (Directory.Exists(pastaTeste))
                {
                    try { Directory.Delete(pastaTeste, recursive: true); } catch { }
                }
            }
        }
    }
}

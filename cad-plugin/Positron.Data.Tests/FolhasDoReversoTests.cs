using Positron.Data.Interface;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// Os textos do menu das **folhas** (`uscPaginas`) que saem da `mMensagem` do original.
    ///
    /// O que estes testes prendem é uma **correção de fidelidade**: o campo do designer chama-se
    /// `RenomearPáginasToolStripMenuItem`, mas o texto que o construtor do original grava por cima
    /// é a `mMensagem[1, 22]` — **"Renumerar Páginas"**. O recoder lia o nome do campo e escrevia
    /// "Renomear Páginas" numa tela cuja regra é renumerar (o `RENPAGA`, o `PaginasDoCaderno`).
    /// </summary>
    public class FolhasDoReversoTests
    {
        [Fact]
        public void OItemDoMenuERenumerarENaoRenomear()
        {
            Assert.Equal("Renumerar Páginas", MensagensDoReverso.RenumerarPaginas);
            Assert.NotEqual("Renomear Páginas", MensagensDoReverso.RenumerarPaginas);
        }

        [Fact]
        public void OsDemaisItensDoMenuSaoOsDaMensagem()
        {
            Assert.Equal("Editar Unidade", MensagensDoReverso.EditarUnidade);
            Assert.Equal("Editar Alternativo", MensagensDoReverso.EditarAlternativo);
            Assert.Equal("Editar Títulos", MensagensDoReverso.EditarTitulos);
            Assert.Equal("Editar Revisões", MensagensDoReverso.EditarRevisoes);
            Assert.Equal("Simplificada", MensagensDoReverso.RevisaoSimplificada);
            Assert.Equal("Completa", MensagensDoReverso.RevisaoCompleta);
        }

        [Fact]
        public void OComboDaFolhaTemOsSeisFormatosLiterais()
        {
            Assert.Equal(new[] { "12", "012", "0012", "00012", "000012", "0000012" }, MensagensDoReverso.FormatosDeFolha);
        }

        [Fact]
        public void OMenuEDaPaletaSaoOsTextosDoOriginal()
        {
            Assert.Equal("Páginas", MensagensDoReverso.Paginas);
            Assert.Equal("Página", MensagensDoReverso.Pagina);
            Assert.Equal("Alternativo", MensagensDoReverso.Alternativo);
            Assert.Equal("Unidade", MensagensDoReverso.Unidade);
        }
    }
}

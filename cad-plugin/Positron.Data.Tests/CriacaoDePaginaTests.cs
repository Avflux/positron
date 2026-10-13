using System.Collections.Generic;
using Positron.Data.Fiacao;
using Positron.Data.Paginas;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// A criação de página (fatia 6 da frente 10, o <c>Pagina.criarUmaNovaPagina</c>): o nome que a
    /// página nova recebe (<c>montaNumeroPagina</c>), o mapa dos campos do formato
    /// (<c>criaCamposFormato</c>) e o layout do XData do título (<c>gravarXDataTitulo</c>).
    /// </summary>
    public class CriacaoDePaginaTests
    {
        // ── Normalizar: o montaNumeroPagina ───────────────────────────────────

        [Fact]
        public void Normalizar_tira_os_zeros_a_esquerda()
        {
            Assert.Equal("16", CriacaoDePagina.Normalizar("0016", 0));
            Assert.Equal("7", CriacaoDePagina.Normalizar(" 007 ", 0));
        }

        [Fact]
        public void Normalizar_com_largura_fixa_completa_com_zeros()
        {
            Assert.Equal("000016", CriacaoDePagina.Normalizar("0016", 6));
        }

        [Fact]
        public void Normalizar_nao_mexe_quando_a_largura_ja_basta()
        {
            // Os zeros à esquerda saem **sempre**; a largura fixa só completa quando falta.
            Assert.Equal("16", CriacaoDePagina.Normalizar("0016", 2));
            Assert.Equal("16", CriacaoDePagina.Normalizar("16", 0));
        }

        [Fact]
        public void Normalizar_soma_um_zero_a_mais_quando_nao_e_numerico()
        {
            // O `num++` do ramo `Not IsNumeric` do original.
            Assert.Equal("000A1", CriacaoDePagina.Normalizar("A1", 4));
        }

        [Fact]
        public void Normalizar_de_vazio_e_vazio()
        {
            Assert.Equal(string.Empty, CriacaoDePagina.Normalizar("0000", 0));
            Assert.Equal(string.Empty, CriacaoDePagina.Normalizar("", 0));

            // Com largura fixa o vazio vira só zeros — é o que o original faz (`Len(text)`
            // zero é <= largura); quem chama tem de recusar a página vazia antes (o adapter faz).
            Assert.Equal("0000000", CriacaoDePagina.Normalizar("", 6));
        }

        // ── CampoDoFormato: o criaCamposFormato ──────────────────────────────

        [Theory]
        [InlineData("TITULO1PAG", 1, " ")]
        [InlineData("TITULO2PAG", 2, " ")]
        [InlineData("TITULO3PAG", 3, " ")]
        [InlineData("TITULO4PAG", 4, " ")]
        [InlineData("PAINEL", 4, " ")]
        [InlineData("REV", 8, " ")]
        [InlineData("ALTERNATIVO", 9, " ")]
        [InlineData("CONT", 5, "?")]
        [InlineData("FL", 6, "?")]
        public void Os_oito_campos_do_formato(string tag, int indice, string texto)
        {
            CriacaoDePagina.CampoDoFormato campo = CriacaoDePagina.CampoDoFormato.De(tag);

            Assert.NotNull(campo);
            Assert.Equal(indice, campo.Indice);
            Assert.Equal(texto, campo.Texto);
        }

        [Fact]
        public void A_tag_nao_diferencia_caixa()
        {
            CriacaoDePagina.CampoDoFormato campo = CriacaoDePagina.CampoDoFormato.De(" titulo1pag ");

            Assert.NotNull(campo);
            Assert.Equal(1, campo.Indice);
        }

        [Theory]
        [InlineData("SECAO")]
        [InlineData("REV0")]
        [InlineData("DESC3")]
        [InlineData("DATA0")]
        [InlineData("ELAB1")]
        [InlineData("VERIF2")]
        [InlineData("APROV0")]
        [InlineData("TOT")]
        [InlineData("")]
        public void As_outras_tags_protegidas_nao_geram_campo(string tag)
        {
            // O original passa por elas no laço e não cria texto nenhum (o if/else dele só
            // trata as oito acima).
            Assert.Null(CriacaoDePagina.CampoDoFormato.De(tag));
        }

        [Fact]
        public void Tag_nula_nao_gera_campo()
        {
            Assert.Null(CriacaoDePagina.CampoDoFormato.De(null));
        }

        // ── TituloDaPaginaXData: o gravarXDataTitulo ─────────────────────────

        [Fact]
        public void O_xdata_do_titulo_tem_os_dez_valores_do_original()
        {
            IReadOnlyList<TypedXData> valores = TituloDaPaginaXData.ParaValores(4, " ", "ana", "2026-10-12");

            Assert.Equal(10, valores.Count);
            Assert.Equal(1001, valores[0].Codigo);
            Assert.Equal("DiagLog", valores[0].Valor);
            Assert.Equal("TituloPagina", valores[1].Valor);
            Assert.Equal(4, valores[2].Valor);
            Assert.Equal(" ", valores[3].Valor);
            Assert.Equal("ana", valores[5].Valor);
            Assert.Equal("2026-10-12", valores[6].Valor);
            Assert.Equal(10, TituloDaPaginaXData.QuantidadeValores);
        }
    }
}

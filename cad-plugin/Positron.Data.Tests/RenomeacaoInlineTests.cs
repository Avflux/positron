using System.Collections.Generic;
using Positron.Data.Interface;
using Positron.Data.Paginas;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// A edição inline da célula Página da paleta — o ramo `ColumnIndex == 0` do `j9Sp1mKZkcD`
    /// (`uscPaginas.cs:1733-1846`) e o `Pagina.renumerarPagina` (`Pagina.cs:1841`).
    /// </summary>
    public class RenomeacaoInlineTests
    {
        private static PlanoDaRenomeacaoInline Planejar(string digitado, string original,
            string ativa = "2", int largura = 0, IReadOnlyList<string> existentes = null,
            bool primeiraLinha = false)
        {
            return RenomeacaoInlineDaPagina.Planejar(digitado, original, ativa, largura,
                existentes ?? new List<string> { "1", original }, primeiraLinha);
        }

        [Fact]
        public void A_celula_vazia_escreve_a_pagina_ativa_sem_renomear()
        {
            PlanoDaRenomeacaoInline plano = Planejar("   ", "7", "2");

            Assert.Equal(AcaoDaRenomeacaoInline.EscreverAtiva, plano.Acao);
            Assert.Equal("2", plano.Nome);
            Assert.Null(plano.Aviso);
            Assert.False(plano.RodarSincronizacoes);
        }

        [Fact]
        public void A_celula_vazia_escreve_a_ativa_ate_na_capa()
        {
            // O teste do vazio vem **antes** do teste da linha 0 — o quirk vale para a capa também.
            PlanoDaRenomeacaoInline plano = Planejar("", "1", "2", primeiraLinha: true);

            Assert.Equal(AcaoDaRenomeacaoInline.EscreverAtiva, plano.Acao);
            Assert.Equal("2", plano.Nome);
        }

        [Fact]
        public void A_primeira_linha_capa_volta_ao_nome_carregado()
        {
            PlanoDaRenomeacaoInline plano = Planejar("9", "1", primeiraLinha: true);

            Assert.Equal(AcaoDaRenomeacaoInline.Reverter, plano.Acao);
            Assert.Equal("1", plano.Nome);
            Assert.False(plano.RodarSincronizacoes);
        }

        [Fact]
        public void O_nome_valido_renomeia_com_caixa_alta_e_trim()
        {
            PlanoDaRenomeacaoInline plano = Planejar("  7a  ", "7", existentes: new List<string> { "1", "7" });

            Assert.Equal(AcaoDaRenomeacaoInline.Renomear, plano.Acao);
            Assert.Equal("7A", plano.Nome);
            Assert.True(plano.RodarSincronizacoes);
        }

        [Fact]
        public void A_largura_fixa_do_caderno_entra_no_nome()
        {
            PlanoDaRenomeacaoInline plano = Planejar("12", "7", largura: 4);

            Assert.Equal(AcaoDaRenomeacaoInline.Renomear, plano.Acao);
            Assert.Equal("0012", plano.Nome);
        }

        [Fact]
        public void O_nome_igual_ao_carregado_nao_renomeia()
        {
            PlanoDaRenomeacaoInline plano = Planejar("7", "7", existentes: new List<string> { "1", "7" });

            Assert.Equal(AcaoDaRenomeacaoInline.Escrever, plano.Acao);
            Assert.Equal("7", plano.Nome);
            Assert.False(plano.RodarSincronizacoes);
        }

        [Fact]
        public void O_nome_que_ja_e_pagina_avisa_e_nao_renomeia()
        {
            // mMensagem 28 — o `renumerarPagina` mostra e devolve false (a célula volta ao original).
            PlanoDaRenomeacaoInline plano = Planejar("9", "7", existentes: new List<string> { "1", "7", "9" });

            Assert.Equal(AcaoDaRenomeacaoInline.JaExiste, plano.Acao);
            Assert.Equal(MensagensDoReverso.EstaPaginaJaExiste, plano.Aviso);
            Assert.Equal("7", plano.Nome);
            Assert.True(plano.RodarSincronizacoes);
        }

        [Theory]
        [InlineData("A")]      // um caractere só não numérico
        [InlineData("A12")]    // prefixo não numérico
        [InlineData("12A3")]   // não numérico no meio (só a última posição pode ser letra)
        [InlineData("0")]      // o `LayerValido` recusa o zero
        public void O_que_nao_vira_pagina_volta_ao_nome_carregado(string digitado)
        {
            PlanoDaRenomeacaoInline plano = Planejar(digitado, "7");

            Assert.Equal(AcaoDaRenomeacaoInline.Reverter, plano.Acao);
            Assert.Equal("7", plano.Nome);
            Assert.Null(plano.Aviso);
        }

        [Fact]
        public void So_a_recusa_do_LayerValido_roda_as_sincronizacoes()
        {
            // A validação de dígitos sai antes do fim do `case 0` (o `break`/`return`); a recusa do
            // `LayerValido` e a renomeação caem no ponto em que o original sincroniza.
            Assert.False(Planejar("A", "7").RodarSincronizacoes);
            Assert.False(Planejar("12A3", "7").RodarSincronizacoes);
            Assert.True(Planejar("0", "7").RodarSincronizacoes);
            Assert.True(Planejar("4", "7").RodarSincronizacoes);
        }
    }
}

using System.Collections.Generic;
using Positron.Data.Paginas;
using Xunit;

namespace Positron.Data.Tests
{
    public class CamposDoFormatoTests
    {
        private static IReadOnlyList<PaginaDoCaderno> Paginas(params string[] nomes)
        {
            List<PaginaDoCaderno> paginas = new List<PaginaDoCaderno>();
            foreach (string nome in nomes)
            {
                paginas.Add(new PaginaDoCaderno { Nome = nome, Alternativo = string.Empty });
            }

            return paginas;
        }

        [Fact]
        public void ApagarCamposPaginas_so_quem_tem_o_indice_do_titulo()
        {
            Assert.False(CamposDoFormato.EhCampoDePagina(0));
            for (int indice = 1; indice <= 9; indice++)
            {
                Assert.True(CamposDoFormato.EhCampoDePagina(indice));
            }
        }

        [Fact]
        public void GeraCampoTot_so_com_a_tag_TOT_e_protegida()
        {
            Assert.True(CamposDoFormato.GeraCampoTot(true, "TOT"));
            Assert.True(CamposDoFormato.GeraCampoTot(true, "tot"));
            Assert.False(CamposDoFormato.GeraCampoTot(false, "TOT"));
            Assert.False(CamposDoFormato.GeraCampoTot(true, "REV"));
            Assert.False(CamposDoFormato.GeraCampoTot(true, "TOT0"));
            Assert.Equal("1", CamposDoFormato.TextoDoTot);
        }

        [Fact]
        public void CONT_recebe_a_proxima_pagina_e_o_vazio_na_ultima()
        {
            IReadOnlyList<PaginaDoCaderno> paginas = Paginas("1", "2", "3");

            Assert.Equal("3", CamposDoFormato.TextoDoContTotFl(
                CamposDoFormato.IndiceCont, "2", "3", paginas, 1));
            Assert.Equal(string.Empty, CamposDoFormato.TextoDoContTotFl(
                CamposDoFormato.IndiceCont, "3", "3", paginas, 1));
        }

        [Fact]
        public void FL_recebe_o_proprio_layer()
        {
            IReadOnlyList<PaginaDoCaderno> paginas = Paginas("1", "2");
            Assert.Equal("2", CamposDoFormato.TextoDoContTotFl(
                CamposDoFormato.IndiceFl, "2", "2", paginas, 1));
        }

        [Fact]
        public void TOT_recebe_a_ultima_pagina()
        {
            IReadOnlyList<PaginaDoCaderno> paginas = Paginas("1", "2", "3");
            Assert.Equal("3", CamposDoFormato.TextoDoContTotFl(
                CamposDoFormato.IndiceTot, "1", "3", paginas, 1));
        }

        [Fact]
        public void ALTERNATIVO_recebe_o_alternativo_da_pagina()
        {
            List<PaginaDoCaderno> paginas = new List<PaginaDoCaderno>
            {
                new PaginaDoCaderno { Nome = "1", Alternativo = "CAPA" },
                new PaginaDoCaderno { Nome = "2", Alternativo = string.Empty },
            };

            Assert.Equal("CAPA", CamposDoFormato.TextoDoContTotFl(
                CamposDoFormato.IndiceAlternativo, "1", "2", paginas, 1));
            Assert.Equal(string.Empty, CamposDoFormato.TextoDoContTotFl(
                CamposDoFormato.IndiceAlternativo, "2", "2", paginas, 1));
        }

        [Fact]
        public void REV_e_outros_nao_sao_tocados()
        {
            IReadOnlyList<PaginaDoCaderno> paginas = Paginas("1", "2");
            Assert.Null(CamposDoFormato.TextoDoContTotFl(CamposDoFormato.IndiceRev, "1", "2", paginas, 1));
            Assert.Null(CamposDoFormato.TextoDoContTotFl(1, "1", "2", paginas, 1));
            Assert.Null(CamposDoFormato.TextoDoContTotFl(0, "1", "2", paginas, 1));
        }

        [Fact]
        public void IncluirColuna_3_a_5_troca_a_pagina_pelo_alternativo()
        {
            List<PaginaDoCaderno> paginas = new List<PaginaDoCaderno>
            {
                new PaginaDoCaderno { Nome = "1", Alternativo = string.Empty },
                new PaginaDoCaderno { Nome = "2", Alternativo = string.Empty },
                new PaginaDoCaderno { Nome = "3", Alternativo = "A3" },
            };

            // Sem o incluirColuna, o CONT do 2 é a página "3".
            Assert.Equal("3", CamposDoFormato.TextoDoContTotFl(
                CamposDoFormato.IndiceCont, "2", "3", paginas, 1));

            // Com 3..5, o alternativo da "3" (A3) entra no lugar dela.
            Assert.Equal("A3", CamposDoFormato.TextoDoContTotFl(
                CamposDoFormato.IndiceCont, "2", "3", paginas, 3));
            Assert.Equal("A3", CamposDoFormato.TextoDoContTotFl(
                CamposDoFormato.IndiceTot, "1", "3", paginas, 5));

            // O alternativo vazio deixa a própria página.
            Assert.Equal("2", CamposDoFormato.TextoDoContTotFl(
                CamposDoFormato.IndiceCont, "1", "3", paginas, 3));
        }
    }
}

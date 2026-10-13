using System.Collections.Generic;
using Positron.Data.Paginas;
using Xunit;

namespace Positron.Data.Tests
{
    public class PaginaAtivaTests
    {
        [Theory]
        [InlineData("1", true)]
        [InlineData("001", true)]
        [InlineData("0000001", true)]
        [InlineData("00000001", false)]
        [InlineData("1A", false)]
        [InlineData("", false)]
        public void ChecaCapa_reproduz_a_lista_do_original(string layer, bool esperado)
        {
            Assert.Equal(esperado, PaginaAtiva.ChecaCapa(layer));
        }

        [Fact]
        public void ChecaCapa_ignora_a_caixa_e_recusa_o_que_nao_e_capa()
        {
            Assert.True(PaginaAtiva.ChecaCapa("0001"));
            Assert.False(PaginaAtiva.ChecaCapa("2"));
            Assert.False(PaginaAtiva.ChecaCapa(null));
        }

        [Fact]
        public void Localiza_a_pagina_pela_camada_corrente()
        {
            Assert.Equal("3", PaginaAtiva.Localiza("3"));
            Assert.Equal("10A", PaginaAtiva.Localiza("10A"));
            Assert.Equal("3", PaginaAtiva.Localiza(" 3 "));
        }

        [Fact]
        public void Localiza_devolve_vazio_fora_de_uma_pagina()
        {
            // A `Clayer` do desenho fora do caderno (o `0`, o `-1`, um layer de trabalho) nao e
            // pagina: o original cai no `retornaNumeroCapa` e a pagina ativa fica vazia.
            Assert.Equal(string.Empty, PaginaAtiva.Localiza("0"));
            Assert.Equal(string.Empty, PaginaAtiva.Localiza("-1"));
            Assert.Equal(string.Empty, PaginaAtiva.Localiza("TRABALHO"));
            Assert.Equal(string.Empty, PaginaAtiva.Localiza(null));
        }

        [Fact]
        public void Papel_reproduz_o_right_do_original_numa_pagina_do_corpo()
        {
            // `right = checaCapa(pagina) ? pagina : "-1"`: numa pagina do corpo ficam ligados a
            // pagina, o `0` e o `-1` (o formato do corpo) — e a **capa desliga**.
            Assert.Equal(PapelDoLayerNaAtivacao.Pagina, PaginaAtiva.Papel("3", "3"));
            Assert.Equal(PapelDoLayerNaAtivacao.Mantido, PaginaAtiva.Papel("0", "3"));
            Assert.Equal(PapelDoLayerNaAtivacao.Mantido, PaginaAtiva.Papel("-1", "3"));
            Assert.Equal(PapelDoLayerNaAtivacao.Fora, PaginaAtiva.Papel("0001", "3"));
            Assert.Equal(PapelDoLayerNaAtivacao.Fora, PaginaAtiva.Papel("2", "3"));
        }

        [Fact]
        public void Papel_na_capa_desliga_o_formato_do_corpo()
        {
            // A capa tem o formato dela: ativando a capa o `-1` desliga.
            Assert.Equal(PapelDoLayerNaAtivacao.Pagina, PaginaAtiva.Papel("001", "001"));
            Assert.Equal(PapelDoLayerNaAtivacao.Mantido, PaginaAtiva.Papel("0", "001"));
            Assert.Equal(PapelDoLayerNaAtivacao.Fora, PaginaAtiva.Papel("-1", "001"));
        }

        [Fact]
        public void Plano_do_desenho_marca_uma_pagina_e_o_resto_fora()
        {
            List<string> layers = new List<string> { "0", "-1", "1", "2", "3", "TRABALHO" };
            IReadOnlyList<PapelDoLayerNaAtivacao> papeis = PaginaAtiva.Plano("2", layers);

            Assert.Equal(6, papeis.Count);
            Assert.Equal(PapelDoLayerNaAtivacao.Mantido, papeis[0]);
            Assert.Equal(PapelDoLayerNaAtivacao.Mantido, papeis[1]);
            Assert.Equal(PapelDoLayerNaAtivacao.Fora, papeis[2]);
            Assert.Equal(PapelDoLayerNaAtivacao.Pagina, papeis[3]);
            Assert.Equal(PapelDoLayerNaAtivacao.Fora, papeis[4]);
            Assert.Equal(PapelDoLayerNaAtivacao.Fora, papeis[5]);
        }

        [Fact]
        public void Plano_vazio_sem_layers()
        {
            Assert.Empty(PaginaAtiva.Plano("3", null));
        }
    }
}

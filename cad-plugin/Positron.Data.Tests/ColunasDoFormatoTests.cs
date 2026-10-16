using System.Collections.Generic;
using Positron.Data.Paginas;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// As cinco colunas do `Inserir` da paleta das folhas (`Pagina.verificaLayerExtraNoFormato`,
    /// `Pagina.cs:2315-2412`) e as duas contas da grade (<see cref="GradeDeFolhas"/>): a referência
    /// da `Nova Página` (`TBNp1Uume8n`) e a linha que o `Apagar Páginas` reseleciona (`JaTp14wdVuV`).
    /// </summary>
    public class ColunasDoFormatoTests
    {
        [Fact]
        public void Sem_layers_as_cinco_colunas_saem_invisiveis_e_o_inserir_nao_aparece()
        {
            IReadOnlyList<ColunaDoFormato> colunas = ColunasDoFormato.DosLayers(null);

            Assert.Equal(5, colunas.Count);
            Assert.False(ColunasDoFormato.TemAlguma(colunas));
            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(i + 1, colunas[i].Indice);
                Assert.False(colunas[i].Visivel);
                Assert.Equal(string.Empty, colunas[i].Nome);
                Assert.Equal(string.Empty, colunas[i].Tipo);
            }
        }

        [Fact]
        public void Cada_prefixo_ELETn_liga_a_coluna_e_guarda_o_resto_do_nome()
        {
            // O `name.Remove(0, 6)` do original: o sub-item mostra o sufixo e o `InserirColuna`
            // recebe `"ELETn_" + sufixo`, que é o próprio layer.
            IReadOnlyList<ColunaDoFormato> colunas = ColunasDoFormato.DosLayers(new List<string>
            {
                "0",
                "-1",
                "1",
                "ELET1_COMANDO",
                "ELET3_SINALIZACAO",
                "ELET5_RESERVA",
            });

            Assert.True(ColunasDoFormato.TemAlguma(colunas));

            Assert.True(colunas[0].Visivel);
            Assert.Equal("COMANDO", colunas[0].Nome);
            Assert.Equal("ELET1_COMANDO", colunas[0].Tipo);

            Assert.False(colunas[1].Visivel);
            Assert.Equal(string.Empty, colunas[1].Tipo);

            Assert.True(colunas[2].Visivel);
            Assert.Equal("SINALIZACAO", colunas[2].Nome);
            Assert.Equal("ELET3_SINALIZACAO", colunas[2].Tipo);

            Assert.False(colunas[3].Visivel);

            Assert.True(colunas[4].Visivel);
            Assert.Equal("RESERVA", colunas[4].Nome);
            Assert.Equal("ELET5_RESERVA", colunas[4].Tipo);
        }

        [Fact]
        public void Dois_layers_do_mesmo_ELETn_ficam_com_o_ultimo_lido()
        {
            // Quirk do original: ele atribui `bELET1`/`sELET1` dentro do laço da tabela de layers,
            // então o último `ELET1_*` vence.
            IReadOnlyList<ColunaDoFormato> colunas = ColunasDoFormato.DosLayers(new List<string>
            {
                "ELET1_PRIMEIRO",
                "ELET1_SEGUNDO",
            });

            Assert.True(colunas[0].Visivel);
            Assert.Equal("SEGUNDO", colunas[0].Nome);
            Assert.Equal("ELET1_SEGUNDO", colunas[0].Tipo);
        }

        [Fact]
        public void Outros_layers_nao_ligam_nenhuma_coluna()
        {
            IReadOnlyList<ColunaDoFormato> colunas = ColunasDoFormato.DosLayers(new List<string>
            {
                "0",
                "ELET6_FORA",
                "ELET1",
                "10",
            });

            Assert.False(ColunasDoFormato.TemAlguma(colunas));
        }

        [Fact]
        public void A_referencia_da_nova_pagina_e_a_linha_selecionada_e_a_seguinte()
        {
            List<string> grade = new List<string> { "1", "2", "10" };

            string anterior;
            string posterior;
            Assert.True(GradeDeFolhas.ReferenciaDaNovaPagina(grade, 0, out anterior, out posterior));
            Assert.Equal("1", anterior);
            Assert.Equal("2", posterior);

            Assert.True(GradeDeFolhas.ReferenciaDaNovaPagina(grade, 1, out anterior, out posterior));
            Assert.Equal("2", anterior);
            Assert.Equal("10", posterior);
        }

        [Fact]
        public void Na_ultima_linha_a_posterior_e_o_sentinela_do_original()
        {
            // O `pagPost.Pagina = "1000000"` de quando `index == dg.Rows.Count - 1` (`uscPaginas.cs:1906`).
            List<string> grade = new List<string> { "1", "2", "10" };

            string anterior;
            string posterior;
            Assert.True(GradeDeFolhas.ReferenciaDaNovaPagina(grade, 2, out anterior, out posterior));
            Assert.Equal("10", anterior);
            Assert.Equal(NovaPaginaEntre.Fim, posterior);
        }

        [Fact]
        public void Sem_selecao_ou_fora_da_grade_nao_ha_referencia()
        {
            List<string> grade = new List<string> { "1", "2" };

            string anterior;
            string posterior;
            Assert.False(GradeDeFolhas.ReferenciaDaNovaPagina(null, 0, out anterior, out posterior));
            Assert.False(GradeDeFolhas.ReferenciaDaNovaPagina(grade, -1, out anterior, out posterior));
            Assert.False(GradeDeFolhas.ReferenciaDaNovaPagina(grade, 2, out anterior, out posterior));
        }

        [Fact]
        public void A_linha_apos_apagar_e_a_primeira_selecionada_menos_um_com_piso_em_zero()
        {
            // O `JaTp14wdVuV` (`uscPaginas.cs:2225`): na primeira linha (`0`) `0 - 1` cai no `< 0` e
            // volta a ser `0`; nas demais é `primeira - 1`, mesmo que o `SelectedRows` venha fora de
            // ordem.
            Assert.Equal(0, GradeDeFolhas.LinhaAposApagar(null));
            Assert.Equal(0, GradeDeFolhas.LinhaAposApagar(new List<int>()));
            Assert.Equal(0, GradeDeFolhas.LinhaAposApagar(new List<int> { 0 }));
            Assert.Equal(0, GradeDeFolhas.LinhaAposApagar(new List<int> { 1 }));
            Assert.Equal(2, GradeDeFolhas.LinhaAposApagar(new List<int> { 5, 3, 4 }));
        }
    }
}

using System.Collections.Generic;
using Positron.Data.Paginas;
using Xunit;

namespace Positron.Data.Tests
{
    public class ExcelDosTitulosTests
    {
        private static bool[] TodosOsTitulos()
        {
            return new[] { false, true, true, true, true };
        }

        private static LinhaDeTitulosDaGrade Linha(string pagina, string t1, string t2, string t3, string t4, string unidade, string alternativo)
        {
            var titulos = new TitulosDaPagina();
            titulos.Definir(1, t1);
            titulos.Definir(2, t2);
            titulos.Definir(3, t3);
            titulos.Definir(4, t4);
            return new LinhaDeTitulosDaGrade(pagina, titulos, unidade, alternativo);
        }

        [Theory]
        [InlineData(1, "A")]
        [InlineData(7, "G")]
        [InlineData(27, "AA")]
        public void LetraDaColuna_e_o_mudaNumeroAsc(int coluna, string esperado)
        {
            // `LetraDaColuna` é 1-based como o `mudaNumeroAsc` do original; `Endereco` recebe o
            // índice da GRADE (0 = A), que é o das colunas do recoder.
            Assert.Equal(esperado, ExcelDosTitulos.LetraDaColuna(coluna));
            Assert.Equal(esperado + "3", ExcelDosTitulos.Endereco(coluna - 1, 3));
        }

        [Fact]
        public void Cabecalho_trunca_as_colunas_desligadas_e_usa_as_mMensagem()
        {
            PlanoDaPlanilha plano = ExcelDosTitulos.Exportar(
                new List<LinhaDeTitulosDaGrade>(), new[] { false, true, false, false, false }, false);

            Assert.Equal(7, plano.Colunas.Count);
            Assert.Equal("Página", plano.Colunas[0].Titulo);
            Assert.Equal(10, plano.Colunas[0].Largura);
            Assert.Equal("Título 1", plano.Colunas[1].Titulo);
            Assert.Equal(50, plano.Colunas[1].Largura);
            Assert.Equal(0, plano.Colunas[2].Largura);
            Assert.False(plano.Colunas[2].Visivel);
            Assert.Equal("Unidade", plano.Colunas[5].Titulo);
            Assert.Equal(15, plano.Colunas[5].Largura);
            Assert.Equal("Alternativo", plano.Colunas[6].Titulo);
            Assert.Equal(0, plano.Colunas[6].Largura);
        }

        [Fact]
        public void Com_o_alternativo_ligado_a_coluna_G_entra_com_20()
        {
            PlanoDaPlanilha plano = ExcelDosTitulos.Exportar(
                new List<LinhaDeTitulosDaGrade>(), TodosOsTitulos(), true);

            Assert.Equal(20, plano.Colunas[6].Largura);
            Assert.True(plano.Colunas[6].Visivel);
        }

        [Fact]
        public void Exporta_as_linhas_com_apostrofo_e_so_as_colunas_ligadas()
        {
            var linhas = new List<LinhaDeTitulosDaGrade>
            {
                Linha("6", "UM", "DOIS", "TRES", "QUATRO", "UNIFILAR", "ALT"),
                Linha("7", "A", "B", "C", "D", "U2", ""),
            };

            PlanoDaPlanilha plano = ExcelDosTitulos.Exportar(linhas, new[] { false, true, false, true, false }, false);

            Assert.Equal(2, plano.Linhas.Count);
            LinhaDaPlanilha primeira = plano.Linhas[0];
            Assert.Equal(2, primeira.Numero);
            Assert.Equal(new[] { "A2", "B2", "D2", "F2" }, Enderecos(primeira));
            Assert.Equal("'6", primeira.Celulas[0].Valor);
            Assert.Equal("'UM", primeira.Celulas[1].Valor);
            Assert.Equal("'TRES", primeira.Celulas[2].Valor);
            Assert.Equal("'UNIFILAR", primeira.Celulas[3].Valor);
            // Sem o alternativo a faixa da linha vai só até a coluna F.
            Assert.Equal("A2:F2", primeira.Faixa);
            Assert.Equal("A3:F3", plano.Linhas[1].Faixa);
        }

        [Fact]
        public void Com_o_alternativo_a_linha_ganha_a_coluna_G_na_faixa()
        {
            var linhas = new List<LinhaDeTitulosDaGrade> { Linha("6", "x", "x", "x", "x", "u", "ALT") };

            PlanoDaPlanilha plano = ExcelDosTitulos.Exportar(linhas, TodosOsTitulos(), true);

            Assert.Equal(7, plano.Linhas[0].Celulas.Count);
            Assert.Equal("'ALT", plano.Linhas[0].Celulas[6].Valor);
            Assert.Equal("A2:G2", plano.Linhas[0].Faixa);
        }

        [Fact]
        public void A_primeira_linha_de_dados_e_a_pintada_e_depois_alterna()
        {
            var linhas = new List<LinhaDeTitulosDaGrade>
            {
                Linha("1", "", "", "", "", "", ""),
                Linha("2", "", "", "", "", "", ""),
                Linha("3", "", "", "", "", "", ""),
            };

            PlanoDaPlanilha plano = ExcelDosTitulos.Exportar(linhas, TodosOsTitulos(), false);

            Assert.True(plano.Linhas[0].Colorida);
            Assert.False(plano.Linhas[1].Colorida);
            Assert.True(plano.Linhas[2].Colorida);
        }

        [Fact]
        public void As_faixas_de_formatacao_e_o_total_da_barra_sao_os_do_original()
        {
            var linhas = new List<LinhaDeTitulosDaGrade>
            {
                Linha("1", "", "", "", "", "", ""),
                Linha("2", "", "", "", "", "", ""),
            };

            PlanoDaPlanilha plano = ExcelDosTitulos.Exportar(linhas, TodosOsTitulos(), false);

            Assert.Equal("A1:G3", plano.FaixaDoTitulo);
            Assert.Equal("E2:G3", plano.FaixaDaQuebra);
            Assert.Equal("A1:G1", plano.FaixaDoCabecalho);
            // `Quantidade = dg.RowCount - 1`: o total anunciado é uma linha a menos.
            Assert.Equal(1, plano.TotalDePassos);
        }

        [Fact]
        public void Le_a_planilha_com_uma_entrada_por_titulo_mais_unidade_e_alternativo()
        {
            var linhas = new List<IReadOnlyList<string>>
            {
                new[] { "6", "UM", "DOIS", "TRES", "QUATRO", "UNIFILAR", "ALT" },
            };

            LeituraDaPlanilha leitura = ExcelDosTitulos.Importar(linhas, TodosOsTitulos(), true);

            Assert.Equal(6, leitura.Titulos.Count);
            Assert.Equal("6", leitura.Titulos[0].Pagina);
            Assert.Equal(1, leitura.Titulos[0].Indice);
            Assert.Equal("UM", leitura.Titulos[0].Texto);
            Assert.Equal(4, leitura.Titulos[3].Indice);
            Assert.Equal(5, leitura.Titulos[4].Indice);
            Assert.Equal("UNIFILAR", leitura.Titulos[4].Texto);
            Assert.Equal(6, leitura.Titulos[5].Indice);
            Assert.Equal("ALT", leitura.Titulos[5].Texto);
            Assert.Empty(leitura.Avisos);
        }

        [Fact]
        public void Sem_o_alternativo_o_indice_6_nao_entra()
        {
            var linhas = new List<IReadOnlyList<string>>
            {
                new[] { "6", "UM", "DOIS", "TRES", "QUATRO", "UNIFILAR", "ALT" },
            };

            LeituraDaPlanilha leitura = ExcelDosTitulos.Importar(linhas, TodosOsTitulos(), false);

            Assert.Equal(5, leitura.Titulos.Count);
            Assert.DoesNotContain(leitura.Titulos, t => t.Indice == 6);
        }

        [Fact]
        public void Linha_sem_a_coluna_A_entra_vazia_como_no_original()
        {
            var linhas = new List<IReadOnlyList<string>>
            {
                new[] { null, "B", "C", "D", "E", "F", "G" },
            };

            LeituraDaPlanilha leitura = ExcelDosTitulos.Importar(linhas, TodosOsTitulos(), false);

            Assert.Equal(5, leitura.Titulos.Count);
            Assert.Equal(string.Empty, leitura.Titulos[0].Pagina);
            Assert.Equal(string.Empty, leitura.Titulos[0].Texto);
        }

        [Fact]
        public void O_alternativo_maior_que_vinte_e_truncado_e_a_celula_entra_no_aviso()
        {
            var linhas = new List<IReadOnlyList<string>>
            {
                new[] { "6", "UM", "", "", "", "U", "0123456789012345678901234" },
            };

            LeituraDaPlanilha leitura = ExcelDosTitulos.Importar(linhas, TodosOsTitulos(), true);

            Assert.Equal("01234567890123456789", leitura.Titulos[5].Texto);
            AvisoDaPlanilha aviso = Assert.Single(leitura.Avisos);
            Assert.Equal(2, aviso.Linha);
            Assert.Equal("G2", aviso.Endereco);
            Assert.Equal("Máximo de 20 caracteres", aviso.Mensagem);
            Assert.Equal(3, aviso.CorIndice);
        }

        [Fact]
        public void So_muda_a_celula_quando_o_valor_e_diferente_sem_caixa()
        {
            var grade = new List<LinhaDeTitulosDaGrade>
            {
                Linha("6", "UM", "DOIS", "", "", "U", ""),
                Linha("7", "A", "", "", "", "", ""),
            };
            var importados = new List<TituloImportado>
            {
                new TituloImportado { Pagina = "6", Indice = 1, Texto = "um" },
                new TituloImportado { Pagina = "6", Indice = 2, Texto = "DOIS NOVO" },
                new TituloImportado { Pagina = "6", Indice = 5, Texto = "U2" },
                new TituloImportado { Pagina = "7", Indice = 1, Texto = "B" },
            };

            IReadOnlyList<MudancaNaGrade> mudancas = ExcelDosTitulos.AplicarNaGrade(grade, importados, TodosOsTitulos(), false);

            // O ``um`` do índice 1 é igual sem caixa ao da grade: não muda. A ordem é a do original:
            // linha da grade por fora, entradas por dentro.
            Assert.Equal(3, mudancas.Count);
            Assert.Equal(0, mudancas[0].Linha);
            Assert.Equal(2, mudancas[0].Coluna);
            Assert.Equal("DOIS NOVO", mudancas[0].Valor);
            Assert.Equal(0, mudancas[1].Linha);
            Assert.Equal(5, mudancas[1].Coluna);
            Assert.Equal("U2", mudancas[1].Valor);
            Assert.Equal(1, mudancas[2].Linha);
            Assert.Equal(1, mudancas[2].Coluna);
            Assert.Equal("B", mudancas[2].Valor);
        }

        [Fact]
        public void Titulo_desligado_e_alternativo_desligado_nao_mudam_a_grade()
        {
            var grade = new List<LinhaDeTitulosDaGrade>
            {
                Linha("6", "UM", "DOIS", "", "", "U", ""),
            };
            var importados = new List<TituloImportado>
            {
                new TituloImportado { Pagina = "6", Indice = 1, Texto = "UM NOVO" },
                new TituloImportado { Pagina = "6", Indice = 2, Texto = "DOIS NOVO" },
                new TituloImportado { Pagina = "6", Indice = 6, Texto = "ALT" },
            };

            IReadOnlyList<MudancaNaGrade> mudancas = ExcelDosTitulos.AplicarNaGrade(
                grade, importados, new[] { false, false, true, false, false }, false);

            MudancaNaGrade mudanca = Assert.Single(mudancas);
            Assert.Equal(2, mudanca.Coluna);
            Assert.Equal("DOIS NOVO", mudanca.Valor);
        }

        [Fact]
        public void A_entrada_anterior_muda_o_valor_que_a_seguinte_compara()
        {
            var grade = new List<LinhaDeTitulosDaGrade>
            {
                Linha("6", "ANTIGO", "", "", "", "", ""),
            };
            var importados = new List<TituloImportado>
            {
                new TituloImportado { Pagina = "6", Indice = 1, Texto = "MEIO" },
                new TituloImportado { Pagina = "6", Indice = 1, Texto = "MEIO" },
            };

            IReadOnlyList<MudancaNaGrade> mudancas = ExcelDosTitulos.AplicarNaGrade(grade, importados, TodosOsTitulos(), false);

            // A primeira casa com "ANTIGO" e grava; a segunda já encontra "MEIO" e não muda nada.
            Assert.Single(mudancas);
            Assert.Equal("MEIO", mudancas[0].Valor);
        }

        [Fact]
        public void Pagina_diferente_sem_caixa_ainda_casa()
        {
            var grade = new List<LinhaDeTitulosDaGrade>
            {
                Linha("7A", "", "", "", "", "", ""),
            };
            var importados = new List<TituloImportado>
            {
                new TituloImportado { Pagina = "7a", Indice = 1, Texto = "NOVO" },
            };

            MudancaNaGrade mudanca = Assert.Single(ExcelDosTitulos.AplicarNaGrade(grade, importados, TodosOsTitulos(), false));
            Assert.Equal("NOVO", mudanca.Valor);
        }

        private static string[] Enderecos(LinhaDaPlanilha linha)
        {
            var enderecos = new List<string>();
            foreach (CelulaDaPlanilha celula in linha.Celulas)
            {
                enderecos.Add(celula.Endereco);
            }

            return enderecos.ToArray();
        }
    }
}

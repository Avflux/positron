using System.Collections.Generic;
using Positron.Data.Interligacao;
using Xunit;

namespace Positron.Data.Tests
{
    public class ExcelDaEstatisticaDeCabosTests
    {
        private static List<IReadOnlyList<string>> Linhas(params string[][] linhas)
        {
            var lista = new List<IReadOnlyList<string>>();
            foreach (string[] linha in linhas)
            {
                lista.Add(linha);
            }

            return lista;
        }

        [Theory]
        [InlineData(AgrupamentoDeCabos.Formacao, "DIF_FORMACAO")]
        [InlineData(AgrupamentoDeCabos.Funcao, "DIF_FUNCAO")]
        [InlineData(AgrupamentoDeCabos.Trajeto, "DIF_TRAJETO")]
        public void NomeDaAba_e_o_DIF_do_grupo_em_maiusculas(AgrupamentoDeCabos agrupamento, string esperado)
        {
            // `"DIF_"` + o grupo sem `ç`/`ã` e o `TrocaBarra` (que sobe para maiúsculas), `:32` e
            // `ExcFuncoesExcel.cs:886-944`.
            Assert.Equal(esperado, ExcelDaEstatisticaDeCabos.NomeDaAba(agrupamento));
        }

        [Fact]
        public void TrocaBarra_troca_o_invalido_corta_em_31_e_sobe_para_maiusculas()
        {
            // O `/` vira `|`; o que o original preserva fica; o resto vira `_`.
            Assert.Equal("A|B_C-D (E)?", ExcelDaEstatisticaDeCabos.TrocaBarra("a/b_c-d (e)?"));
            Assert.Equal("ABCDEFGHIJKLMNOPQRSTUVWXYZ01234",
                ExcelDaEstatisticaDeCabos.TrocaBarra("abcdefghijklmnopqrstuvwxyz0123456789"));
        }

        [Fact]
        public void SemAcento_troca_so_o_cedilha_e_o_a_til()
        {
            // `Relatorios_EstatisticaCaboEXCEL.cs:31-32` — só estas duas trocas (o `ã` também sai de
            // "Formação" no caminho).
            Assert.Equal("Formacao", ExcelDaEstatisticaDeCabos.SemAcento("Formação"));
            Assert.Equal("Funcao", ExcelDaEstatisticaDeCabos.SemAcento("Função"));
            Assert.Equal("Trajeto", ExcelDaEstatisticaDeCabos.SemAcento("Trajeto"));
        }

        [Theory]
        [InlineData(AgrupamentoDeCabos.Formacao, "'Formação")]
        [InlineData(AgrupamentoDeCabos.Funcao, "'Função")]
        [InlineData(AgrupamentoDeCabos.Trajeto, "'Trajeto")]
        public void Cabecalho_tem_as_tres_colunas_com_o_apostrofo_do_original(AgrupamentoDeCabos agrupamento, string doGrupo)
        {
            PlanoDaEstatisticaDeCabos plano = ExcelDaEstatisticaDeCabos.Exportar(Linhas(), agrupamento);

            // `"'" + "#" + 514` — sem o espaço da grade ("# Cabos"); 1246 = "Comprimento".
            Assert.Equal(3, plano.Colunas.Count);
            Assert.Equal("'#Cabos", plano.Colunas[0].Titulo);
            Assert.Equal(doGrupo, plano.Colunas[1].Titulo);
            Assert.Equal("'Comprimento", plano.Colunas[2].Titulo);
            Assert.Equal(new[] { "A1", "B1", "C1" },
                new[] { plano.Colunas[0].Endereco, plano.Colunas[1].Endereco, plano.Colunas[2].Endereco });
            Assert.Equal(new double[] { 12, 40, 15 },
                new[] { plano.Colunas[0].Largura, plano.Colunas[1].Largura, plano.Colunas[2].Largura });
            Assert.Equal("A1:C1", plano.FaixaDoCabecalho);
        }

        [Fact]
        public void Linhas_levam_o_apostrofo_e_a_numeracao_da_planilha()
        {
            PlanoDaEstatisticaDeCabos plano = ExcelDaEstatisticaDeCabos.Exportar(
                Linhas(
                    new[] { "2", "3x2,5", "15" },
                    new[] { "1", "2x4", "4" }),
                AgrupamentoDeCabos.Formacao);

            Assert.Equal(2, plano.Linhas.Count);
            Assert.Equal(2, plano.Linhas[0].Numero);
            Assert.Equal("'2", plano.Linhas[0].Contagem);
            Assert.Equal("'3x2,5", plano.Linhas[0].Grupo);
            Assert.Equal("'15", plano.Linhas[0].Comprimento);
            Assert.Equal("A2", plano.Linhas[0].Endereco(0));
            Assert.Equal("B2", plano.Linhas[0].Endereco(1));
            Assert.Equal("C2", plano.Linhas[0].Endereco(2));
            // O `Valor` devolve o que vai para a célula — com o apóstrofo, como o `Contagem`.
            Assert.Equal("'2", plano.Linhas[0].Valor(0));
            Assert.Equal("'3x2,5", plano.Linhas[0].Valor(1));
            Assert.Equal("'15", plano.Linhas[0].Valor(2));
            Assert.Equal(3, plano.Linhas[1].Numero);
            Assert.Equal("A3", plano.Linhas[1].Endereco(0));

            // A faixa fecha na última linha ESCRITA (o `"A2:C" + num` do original).
            Assert.Equal("A2:C3", plano.FaixaDosDados);
        }

        [Fact]
        public void Grade_vazia_deixa_a_faixa_invertida_como_o_original()
        {
            // Quirk de `Relatorios_EstatisticaCaboEXCEL.cs:89`: com zero linhas o `num` continua 1 e a
            // faixa sai `A2:C1` (o Excel normaliza na hora de aplicar a borda). Mantido.
            PlanoDaEstatisticaDeCabos plano = ExcelDaEstatisticaDeCabos.Exportar(Linhas(), AgrupamentoDeCabos.Trajeto);

            Assert.Empty(plano.Linhas);
            Assert.Equal("A2:C1", plano.FaixaDosDados);
        }

        [Fact]
        public void Celula_vazia_ou_nula_vira_so_o_apostrofo()
        {
            // O `TiraNothing` do `clsTextos`: a célula sem valor não vira "``" nem estoura.
            PlanoDaEstatisticaDeCabos plano = ExcelDaEstatisticaDeCabos.Exportar(
                Linhas(new[] { null, "", null }),
                AgrupamentoDeCabos.Funcao);

            Assert.Equal("'", plano.Linhas[0].Contagem);
            Assert.Equal("'", plano.Linhas[0].Grupo);
            Assert.Equal("'", plano.Linhas[0].Comprimento);
        }

        [Fact]
        public void NomeDaAbaDe_usa_o_mesmo_caminho_do_grupo()
        {
            // O `ExportaEstatisticaExcel` monta o nome com o texto do agrupamento; o `TrocaBarra`
            // responde pelo resto (corte, inválidos e maiúsculas).
            Assert.Equal("DIF_FORMACAO", ExcelDaEstatisticaDeCabos.NomeDaAbaDe("Formação"));
            Assert.Equal("PLAN1", ExcelDaEstatisticaDeCabos.TrocaBarra(ExcelDaEstatisticaDeCabos.NomePadraoDaAba));
        }
    }
}

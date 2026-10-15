using System.Collections.Generic;
using Positron.Data.Materiais;
using Positron.Data.Relatorios;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// A **lista de materiais** do <c>frmRelatorio_Materiais</c> (<c>EXPLM</c>, rodada 159): o
    /// agrupamento por trechos consecutivos do mesmo material, com as tags unidas e as quantidades
    /// somadas, a linha nova para o material fora do catálogo e o material <c>0</c> mantido na lista.
    /// </summary>
    public class ListaDeMateriaisDoRelatorioTests
    {
        private static readonly IReadOnlyDictionary<int, MaterialDoCatalogo> Catalogo =
            new Dictionary<int, MaterialDoCatalogo>
            {
                {
                    461,
                    new MaterialDoCatalogo
                    {
                        CodigoInterno = 461,
                        CodigoCliente = "CLI-1",
                        Modelo = "RJ-8",
                        Fabricante = "FINDER",
                        DescricaoResumida = "Resumida",
                        DescricaoCompleta = "Descrição completa do material",
                    }
                },
                {
                    476,
                    new MaterialDoCatalogo
                    {
                        CodigoInterno = 476,
                        Modelo = "M-2",
                        DescricaoCompleta = "Outro material",
                    }
                },
            };

        private static LinhaListaMaterial Linha(int painel, string tag, int material, int quantidade, int ordem)
        {
            return new LinhaListaMaterial
            {
                DWG = 63,
                Painel = painel,
                Tag = tag,
                IndiceMaterial = material,
                Quantidade = quantidade,
                Ordem = ordem,
            };
        }

        [Fact]
        public void O_mesmo_material_em_linhas_consecutivas_vira_uma_linha_com_as_tags_e_a_soma()
        {
            List<LinhaDaLMDoRelatorio> linhas = ListaDeMateriaisDoRelatorio.Montar(
                new[]
                {
                    Linha(9, "T1", 461, 2, 1),
                    Linha(9, "T2", 461, 3, 2),
                    Linha(9, "T3", 476, 1, 3),
                },
                Catalogo,
                9,
                true);

            Assert.Equal(2, linhas.Count);
            Assert.Equal("T1, T2", linhas[0].Tag);
            Assert.Equal(5, linhas[0].Quantidade);
            Assert.Equal(461, linhas[0].IndiceLM);
            Assert.Equal(1, linhas[0].Sequencia);
            Assert.Equal("Descrição completa do material ", linhas[0].Descricao);
            Assert.Equal("RJ-8", linhas[0].Modelo);
            Assert.Equal("FINDER", linhas[0].Fabricante);
            Assert.Equal("CLI-1", linhas[0].CodigoCliente);
            Assert.Equal("T3", linhas[1].Tag);
            Assert.Equal(2, linhas[1].Sequencia);
        }

        [Fact]
        public void O_mesmo_material_separado_por_outro_abre_uma_linha_nova()
        {
            List<LinhaDaLMDoRelatorio> linhas = ListaDeMateriaisDoRelatorio.Montar(
                new[]
                {
                    Linha(9, "T1", 461, 1, 1),
                    Linha(9, "T2", 476, 1, 2),
                    Linha(9, "T3", 461, 1, 3),
                },
                Catalogo,
                9,
                true);

            Assert.Equal(3, linhas.Count);
            Assert.Equal(new[] { "T1", "T2", "T3" }, new[] { linhas[0].Tag, linhas[1].Tag, linhas[2].Tag });
        }

        [Fact]
        public void O_material_fora_do_catalogo_sempre_abre_uma_linha_nova_e_sai_sem_os_campos()
        {
            // Duas linhas do mesmo material que o catálogo não resolve: no original cada uma começa uma
            // linha (o teste da célula coral), e os campos do catálogo saem vazios.
            List<LinhaDaLMDoRelatorio> linhas = ListaDeMateriaisDoRelatorio.Montar(
                new[]
                {
                    Linha(9, "T1", 999, 1, 1),
                    Linha(9, "T2", 999, 2, 2),
                },
                Catalogo,
                9,
                true);

            Assert.Equal(2, linhas.Count);
            Assert.Equal("T1", linhas[0].Tag);
            Assert.Equal("T2", linhas[1].Tag);
            Assert.Equal(string.Empty, linhas[0].Descricao);
            Assert.Equal(string.Empty, linhas[0].Modelo);
            Assert.Equal(string.Empty, linhas[0].Fabricante);
            Assert.Equal(string.Empty, linhas[0].CodigoCliente);
            Assert.Equal(999, linhas[0].IndiceLM);
        }

        [Fact]
        public void O_material_zero_fica_na_lista_com_o_indice_zero()
        {
            List<LinhaDaLMDoRelatorio> linhas = ListaDeMateriaisDoRelatorio.Montar(
                new[] { Linha(9, "BORNE-1", 0, 4, 1) },
                Catalogo,
                9,
                true);

            LinhaDaLMDoRelatorio linha = Assert.Single(linhas);
            Assert.Equal(0, linha.IndiceLM);
            Assert.Equal(4, linha.Quantidade);
            Assert.Equal("BORNE-1", linha.Tag);
        }

        [Fact]
        public void A_descricao_resumida_vem_no_modo_resumido()
        {
            List<LinhaDaLMDoRelatorio> linhas = ListaDeMateriaisDoRelatorio.Montar(
                new[] { Linha(9, "T1", 461, 1, 1) },
                Catalogo,
                9,
                false);

            Assert.Equal("Resumida ", Assert.Single(linhas).Descricao);
        }

        [Fact]
        public void So_as_linhas_do_painel_escolhido_entram()
        {
            List<LinhaDaLMDoRelatorio> linhas = ListaDeMateriaisDoRelatorio.Montar(
                new[]
                {
                    Linha(9, "T1", 461, 1, 1),
                    Linha(503, "T2", 461, 1, 1),
                },
                Catalogo,
                503,
                true);

            LinhaDaLMDoRelatorio linha = Assert.Single(linhas);
            Assert.Equal("T2", linha.Tag);
            Assert.Equal(1, linha.Sequencia);
        }

        [Fact]
        public void Os_paineis_da_lista_saem_sem_repeticao_na_ordem_da_projecao()
        {
            List<int> paineis = ListaDeMateriaisDoRelatorio.Paineis(
                new[]
                {
                    Linha(9, "T1", 461, 1, 1),
                    Linha(9, "T2", 461, 1, 2),
                    Linha(503, "T3", 461, 1, 1),
                });

            Assert.Equal(new[] { 9, 503 }, paineis);
        }
    }
}

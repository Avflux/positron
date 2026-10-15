using System.Collections.Generic;
using Positron.Data.Fiacao;
using Positron.Data.Paginas;
using Xunit;

namespace Positron.Data.Tests
{
    public class ColunaDaPaginaTests
    {
        [Fact]
        public void ParaValores_gera_layout_esperado_com_5_itens()
        {
            IReadOnlyList<TypedXData> xdata = ColunaDaPaginaXData.ParaValores("ELET1_COPIADO", "admin", "15/10/2026");

            Assert.NotNull(xdata);
            Assert.Equal(ColunaDaPaginaXData.QuantidadeValores, xdata.Count);
            Assert.Equal(1001, xdata[0].Codigo);
            Assert.Equal("DiagLog", xdata[0].Valor);
            Assert.Equal(1000, xdata[1].Codigo);
            Assert.Equal("COLUNAS", xdata[1].Valor);
            Assert.Equal(1000, xdata[2].Codigo);
            Assert.Equal("ELET1_COPIADO", xdata[2].Valor);
            Assert.Equal(1000, xdata[3].Codigo);
            Assert.Equal("admin", xdata[3].Valor);
            Assert.Equal(1000, xdata[4].Codigo);
            Assert.Equal("15/10/2026", xdata[4].Valor);
        }

        [Fact]
        public void Ler_extrai_tipo_corretamente()
        {
            IReadOnlyList<TypedXData> xdata = ColunaDaPaginaXData.ParaValores("ELET2_ARANHA", "user", "2026-10-15");

            string tipo;
            bool ok = ColunaDaPaginaXData.Ler(xdata, out tipo);

            Assert.True(ok);
            Assert.Equal("ELET2_ARANHA", tipo);
        }

        [Fact]
        public void Ler_recusa_xdata_com_marca_ou_app_invalido()
        {
            List<TypedXData> invalidoApp = new List<TypedXData>
            {
                new TypedXData(1001, "OutroApp"),
                new TypedXData(1000, "COLUNAS"),
                new TypedXData(1000, "ELET1_A"),
            };
            string tipo;
            Assert.False(ColunaDaPaginaXData.Ler(invalidoApp, out tipo));
            Assert.Null(tipo);

            List<TypedXData> invalidoMarca = new List<TypedXData>
            {
                new TypedXData(1001, "DiagLog"),
                new TypedXData(1000, "TituloPagina"),
                new TypedXData(1000, "ELET1_A"),
            };
            Assert.False(ColunaDaPaginaXData.Ler(invalidoMarca, out tipo));
            Assert.Null(tipo);

            Assert.False(ColunaDaPaginaXData.Ler(null, out tipo));
            Assert.False(ColunaDaPaginaXData.Ler(new List<TypedXData>(), out tipo));
        }

        [Fact]
        public void Deduplicar_remove_duplicados_preservando_ordem_e_case_insensitive()
        {
            List<ColunaDaPagina> colunas = new List<ColunaDaPagina>
            {
                new ColunaDaPagina("1", "ELET1_A"),
                new ColunaDaPagina("2", "ELET2_B"),
                new ColunaDaPagina("1", "elet1_a"), // duplicado
                new ColunaDaPagina("1", "ELET2_B"), // outra coluna na página 1
                new ColunaDaPagina("2", "ELET2_B"), // duplicado
                new ColunaDaPagina("3", "ELET1_A"),
            };

            List<ColunaDaPagina> unicas = ColunaDaPagina.Deduplicar(colunas);

            Assert.Equal(4, unicas.Count);
            Assert.Equal("1", unicas[0].Pagina);
            Assert.Equal("ELET1_A", unicas[0].Tipo);

            Assert.Equal("2", unicas[1].Pagina);
            Assert.Equal("ELET2_B", unicas[1].Tipo);

            Assert.Equal("1", unicas[2].Pagina);
            Assert.Equal("ELET2_B", unicas[2].Tipo);

            Assert.Equal("3", unicas[3].Pagina);
            Assert.Equal("ELET1_A", unicas[3].Tipo);
        }

        [Fact]
        public void Deduplicar_ignora_entradas_vazias_ou_nulas()
        {
            List<ColunaDaPagina> colunas = new List<ColunaDaPagina>
            {
                null,
                new ColunaDaPagina("", "ELET1_A"),
                new ColunaDaPagina("1", ""),
                new ColunaDaPagina(null, null),
                new ColunaDaPagina("4", "ELET4_C"),
            };

            List<ColunaDaPagina> unicas = ColunaDaPagina.Deduplicar(colunas);

            Assert.Single(unicas);
            Assert.Equal("4", unicas[0].Pagina);
            Assert.Equal("ELET4_C", unicas[0].Tipo);
        }

        [Fact]
        public void Equals_e_GetHashCode_comparam_pagina_e_tipo_sem_distincao_de_caixa()
        {
            ColunaDaPagina col1 = new ColunaDaPagina("10A", "ELET1_COLUNA");
            ColunaDaPagina col2 = new ColunaDaPagina("10a", "elet1_coluna");
            ColunaDaPagina col3 = new ColunaDaPagina("10A", "ELET2_COLUNA");

            Assert.Equal(col1, col2);
            Assert.Equal(col1.GetHashCode(), col2.GetHashCode());
            Assert.NotEqual(col1, col3);
        }
    }
}

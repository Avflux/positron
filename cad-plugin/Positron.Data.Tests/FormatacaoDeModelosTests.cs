using System.Collections.Generic;
using Positron.Data.Materiais;
using Positron.Data.Modelos;
using Xunit;

namespace Positron.Data.Tests
{
    public class FormatacaoDeModelosTests
    {
        private static readonly IReadOnlyDictionary<int, MaterialDoCatalogo> Catalogo =
            new Dictionary<int, MaterialDoCatalogo>
            {
                {
                    101,
                    new MaterialDoCatalogo
                    {
                        CodigoInterno = 101,
                        DescricaoResumida = "DISJUNTOR 10A",
                        Modelo = "3RV2011",
                        Fabricante = "SIEMENS",
                    }
                },
            };

        [Fact]
        public void Resolve_material_existente_no_catalogo()
        {
            FormatacaoDeModelos.DetalheDoMaterial det = FormatacaoDeModelos.ResolverMaterial(101, Catalogo);

            Assert.Equal("101", det.Codigo);
            Assert.Equal("DISJUNTOR 10A", det.Descricao);
            Assert.Equal("3RV2011", det.Modelo);
            Assert.Equal("SIEMENS", det.Fabricante);
        }

        [Fact]
        public void Resolve_material_zero_como_vazio()
        {
            FormatacaoDeModelos.DetalheDoMaterial det = FormatacaoDeModelos.ResolverMaterial(0, Catalogo);

            Assert.Equal("0", det.Codigo);
            Assert.Equal(string.Empty, det.Descricao);
            Assert.Equal(string.Empty, det.Modelo);
            Assert.Equal(string.Empty, det.Fabricante);
        }

        [Fact]
        public void Resolve_material_fora_do_catalogo()
        {
            FormatacaoDeModelos.DetalheDoMaterial det = FormatacaoDeModelos.ResolverMaterial(999, Catalogo);

            Assert.Equal("999", det.Codigo);
            Assert.Equal(string.Empty, det.Descricao);
            Assert.Equal(string.Empty, det.Modelo);
            Assert.Equal(string.Empty, det.Fabricante);
        }

        [Fact]
        public void Resolve_material_com_catalogo_nulo()
        {
            FormatacaoDeModelos.DetalheDoMaterial det = FormatacaoDeModelos.ResolverMaterial(101, null);

            Assert.Equal("101", det.Codigo);
            Assert.Equal(string.Empty, det.Descricao);
            Assert.Equal(string.Empty, det.Modelo);
            Assert.Equal(string.Empty, det.Fabricante);
        }

        [Theory]
        [InlineData("bloco_a", "BLOCO_A")]
        [InlineData("  topo1  ", "TOPO1")]
        [InlineData("", "")]
        [InlineData(null, "")]
        public void Formata_nome_do_bloco_em_caixa_alta_e_sem_espacos(string entrada, string esperado)
        {
            Assert.Equal(esperado, FormatacaoDeModelos.FormatarNomeDoBloco(entrada));
        }
    }
}

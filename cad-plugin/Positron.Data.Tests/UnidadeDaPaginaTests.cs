using System.Collections.Generic;
using Positron.Data.Fiacao;
using Positron.Data.Paginas;
using Xunit;

namespace Positron.Data.Tests
{
    public class UnidadeDaPaginaTests
    {
        [Fact]
        public void Le_a_unidade_e_o_alternativo()
        {
            string unidade;
            string alternativo;
            Assert.True(UnidadeDaPaginaXData.Ler(
                UnidadeDaPaginaXData.ParaValores("U1", "A1"), out unidade, out alternativo));
            Assert.Equal("U1", unidade);
            Assert.Equal("A1", alternativo);
        }

        [Theory]
        [InlineData("  unidade com espaços  ", "UNIDADE COM ESPAÇOS")]
        [InlineData("  nome alternativo com mais de vinte caracteres  ", "NOME ALTERNATIVO COM MAIS DE VINTE CARACTERES")]
        [InlineData("", "")]
        [InlineData("   ", "")]
        [InlineData(null, "")]
        [InlineData("a  b", "A  B")]
        public void MenuNormalizaRespostaSemTruncar(string resposta, string esperado)
        {
            Assert.Equal(esperado, UnidadeDaPaginaXData.NormalizarRespostaDoMenu(resposta));
        }

        [Fact]
        public void Sem_xdata_o_buffer_nasce_com_os_quatro_valores()
        {
            // `GravarXDataUnidadeAlternativo`: cria a marca do zero.
            IReadOnlyList<TypedXData> valores = UnidadeDaPaginaXData.Atualizar(null, "U1", "A1");

            Assert.Equal(4, valores.Count);
            Assert.Equal(1001, valores[0].Codigo);
            Assert.Equal("Eletron", valores[0].Valor);
            Assert.Equal("Unidade", valores[1].Valor);
            Assert.Equal("U1", valores[2].Valor);
            Assert.Equal("A1", valores[3].Valor);
        }

        [Fact]
        public void A_atualizacao_conserva_o_resto_do_buffer()
        {
            // `AlteraXDataUnidadeAlternativo`: troca só as posições 2 e 3 — o que o desenho tiver
            // além dos quatro valores continua lá, com o código dele.
            List<TypedXData> existentes = new List<TypedXData>
            {
                new TypedXData(1001, "Eletron"),
                new TypedXData(1000, "Unidade"),
                new TypedXData(1000, "ANTIGA"),
                new TypedXData(1000, "ALT ANTIGO"),
                new TypedXData(1000, "EXTRA"),
                new TypedXData(1070, 213),
            };

            IReadOnlyList<TypedXData> valores = UnidadeDaPaginaXData.Atualizar(existentes, "NOVA", "NOVO ALT");

            Assert.Equal(6, valores.Count);
            Assert.Equal("Eletron", valores[0].Valor);
            Assert.Equal("Unidade", valores[1].Valor);
            Assert.Equal("NOVA", valores[2].Valor);
            Assert.Equal("NOVO ALT", valores[3].Valor);
            Assert.Equal(1000, valores[4].Codigo);
            Assert.Equal("EXTRA", valores[4].Valor);
            Assert.Equal(1070, valores[5].Codigo);
            Assert.Equal(213, valores[5].Valor);
        }

        [Fact]
        public void Com_outra_marca_nada_e_escrito()
        {
            // O `if` do original não tem `else`: com outra marca o XData do layer fica intocado.
            List<TypedXData> outro = new List<TypedXData>
            {
                new TypedXData(1001, "Eletron"),
                new TypedXData(1000, "TituloPagina"),
                new TypedXData(1000, "x"),
                new TypedXData(1000, "y"),
            };

            Assert.Null(UnidadeDaPaginaXData.Atualizar(outro, "U", "A"));
            Assert.Null(UnidadeDaPaginaXData.Atualizar(new List<TypedXData>(), "U", "A"));
        }

        [Fact]
        public void A_marca_e_lida_sem_caixa()
        {
            List<TypedXData> existentes = new List<TypedXData>
            {
                new TypedXData(1001, "eletron"),
                new TypedXData(1000, "unidade"),
                new TypedXData(1000, "U"),
                new TypedXData(1000, "A"),
            };

            Assert.True(UnidadeDaPaginaXData.EhMarcaUnidade(existentes));
            Assert.NotNull(UnidadeDaPaginaXData.Atualizar(existentes, "NOVA", "NOVO"));
        }

        [Fact]
        public void Buffer_curto_da_marca_e_completado_ate_os_quatro()
        {
            // Desvio declarado: o original acessa `array[2]`/`array[3]` direto e estouraria num
            // buffer de dois valores; aqui ele é completado (a leitura do recoder é tolerante).
            List<TypedXData> curto = new List<TypedXData>
            {
                new TypedXData(1001, "Eletron"),
                new TypedXData(1000, "Unidade"),
            };

            IReadOnlyList<TypedXData> valores = UnidadeDaPaginaXData.Atualizar(curto, "U", "A");

            Assert.Equal(4, valores.Count);
            Assert.Equal("U", valores[2].Valor);
            Assert.Equal("A", valores[3].Valor);
        }

        [Fact]
        public void Recusa_o_xdata_de_outra_marca()
        {
            string unidade;
            string alternativo;
            List<TypedXData> outro = new List<TypedXData>
            {
                new TypedXData(1001, "Eletron"),
                new TypedXData(1000, "TituloPagina"),
                new TypedXData(1000, "x"),
                new TypedXData(1000, "y"),
            };
            Assert.False(UnidadeDaPaginaXData.Ler(outro, out unidade, out alternativo));
            Assert.False(UnidadeDaPaginaXData.Ler(null, out unidade, out alternativo));
        }
    }
}

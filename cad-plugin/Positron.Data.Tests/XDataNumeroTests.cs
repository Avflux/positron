using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// Conversão tolerante do XData: o mesmo campo chega como número ou string
    /// ("5", "5.0", "5,0", "") e nenhuma dessas formas pode derrubar o comando
    /// dentro do CAD. Regressão do desenho funcional real (FormatException em
    /// <c>ReguasModelo.Inteiro</c>).
    /// </summary>
    public class XDataNumeroTests
    {
        [Theory]
        [InlineData("5", 5)]
        [InlineData("5.0", 5)]
        [InlineData("5,0", 5)]
        [InlineData(" 7 ", 7)]
        [InlineData("-3", -3)]
        [InlineData("", 0)]
        [InlineData("   ", 0)]
        [InlineData("A1", 0)]
        [InlineData("1.9", 2)]
        public void Inteiro_aceita_string_de_todo_tipo(string entrada, int esperado)
        {
            Assert.Equal(esperado, XDataNumero.Inteiro(entrada));
        }

        [Fact]
        public void Inteiro_aceita_os_tipos_nativos()
        {
            Assert.Equal(5, XDataNumero.Inteiro((short)5));
            Assert.Equal(5, XDataNumero.Inteiro(5));
            Assert.Equal(5, XDataNumero.Inteiro(5.0));
            Assert.Equal(5, XDataNumero.Inteiro(5L));
            Assert.Equal(0, XDataNumero.Inteiro(null));
            Assert.Equal(0, XDataNumero.Inteiro(System.DBNull.Value));
        }

        [Fact]
        public void Real_e_Booleano_tambem_nao_lancam()
        {
            Assert.Equal(1.5, XDataNumero.Real("1,5"));
            Assert.Equal(0.0, XDataNumero.Real("xyz"));
            Assert.True(XDataNumero.Booleano("1"));
            Assert.True(XDataNumero.Booleano(true));
            Assert.False(XDataNumero.Booleano("0"));
            Assert.False(XDataNumero.Booleano(null));
        }

        [Fact]
        public void Modelo_de_regua_le_painel_vindo_como_string()
        {
            // O Xrecord real do desenho traz os inteiros como string ("1", "5");
            // antes isto estourava FormatException e derrubava o FIA.
            var valores = new System.Collections.Generic.List<Positron.Data.Fiacao.TypedXData>
            {
                // Índice 0 é o cabeçalho (maior indexRegua).
                new Positron.Data.Fiacao.TypedXData(90, "5"),
                new Positron.Data.Fiacao.TypedXData(1071, "5"),
                new Positron.Data.Fiacao.TypedXData(1000, "R1"),
                new Positron.Data.Fiacao.TypedXData(1000, "ALT1"),
                new Positron.Data.Fiacao.TypedXData(1071, "1"),
                new Positron.Data.Fiacao.TypedXData(1071, "0"),
                new Positron.Data.Fiacao.TypedXData(1071, "0"),
                new Positron.Data.Fiacao.TypedXData(1071, "0"),
                new Positron.Data.Fiacao.TypedXData(1071, "0"),
                new Positron.Data.Fiacao.TypedXData(1071, "0"),
                new Positron.Data.Fiacao.TypedXData(1071, "0"),
            };

            Positron.Data.Bornes.ReguasModelo reguas = Positron.Data.Bornes.ReguasModelo.Ler(valores);

            Positron.Data.Bornes.ReguaInfo regua = reguas.Buscar(5);
            Assert.NotNull(regua);
            Assert.Equal("R1", regua.Nome);
            Assert.Equal(1, regua.Painel);
        }
    }
}

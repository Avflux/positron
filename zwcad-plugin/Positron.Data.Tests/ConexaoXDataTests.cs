using System.Collections.Generic;
using Positron.Data.Fiacao;
using Xunit;

namespace Positron.Data.Tests
{
    public class ConexaoXDataTests
    {
        /// <summary>Mesma sequência que <c>GravarXDataConexao</c> produz (25 valores).</summary>
        private static List<TypedXData> ValoresValidos()
        {
            return new List<TypedXData>
            {
                new TypedXData(1001, "CONEXAO"),
                new TypedXData(1070, (short)2),        // Tipo
                new TypedXData(1071, 7),               // Potencial
                new TypedXData(1000, "A1B2"),          // Handle
                new TypedXData(1070, (short)3),        // Painel
                new TypedXData(1070, 0),               // Aplicacao
                new TypedXData(1070, 0),               // reservado
                new TypedXData(1000, "PT1"),           // Nome
                new TypedXData(1000, "F1"),            // Funcao
                new TypedXData(1000, "220"),           // Tensao
                new TypedXData(1000, "2,5"),           // Secao
                new TypedXData(1000, "PT"),            // Cor
                new TypedXData(1000, string.Empty),
                new TypedXData(1040, 0.0),
                new TypedXData(1070, -1),              // Disp1 ligado
                new TypedXData(1070, 0),               // Disp2 desligado
                new TypedXData(1000, string.Empty),    // Jumper
                new TypedXData(1000, string.Empty),
                new TypedXData(1071, 5),               // Enderecamento
                new TypedXData(1071, 1),
                new TypedXData(1000, "ana"),           // Usuario
                new TypedXData(1000, "2026-10-07"),    // Data
                new TypedXData(1071, 1),
                new TypedXData(1040, 0.0),
                new TypedXData(1000, string.Empty),
            };
        }

        [Fact]
        public void Le_o_layout_completo()
        {
            ConexaoXData conexao;
            Assert.True(ConexaoXData.Ler(ValoresValidos(), out conexao));

            Assert.Equal((short)2, conexao.Tipo);
            Assert.Equal(7, conexao.Potencial);
            Assert.Equal("A1B2", conexao.Handle);
            Assert.Equal((short)3, conexao.Painel);
            Assert.Equal("PT1", conexao.Nome);
            Assert.Equal("2,5", conexao.Secao);
            Assert.Equal("PT", conexao.Cor);
            Assert.True(conexao.Disp1);
            Assert.False(conexao.Disp2);
            Assert.Equal(5, conexao.Enderecamento);
            Assert.Equal("ana", conexao.Usuario);
            Assert.Equal("2026-10-07", conexao.Data);
        }

        [Fact]
        public void Recusa_app_name_diferente()
        {
            List<TypedXData> valores = ValoresValidos();
            valores[0] = new TypedXData(1001, "INTERLIGACAO");

            ConexaoXData conexao;
            Assert.False(ConexaoXData.Ler(valores, out conexao));
            Assert.Null(conexao);
        }

        [Fact]
        public void Recusa_xdata_truncado()
        {
            List<TypedXData> valores = ValoresValidos();
            valores.RemoveRange(20, 5);

            ConexaoXData conexao;
            Assert.False(ConexaoXData.Ler(valores, out conexao));
        }

        [Fact]
        public void Projeta_apenas_os_campos_inequivocos()
        {
            ConexaoXData conexao;
            ConexaoXData.Ler(ValoresValidos(), out conexao);

            PontoFiacao ponto = PontoFiacao.DeConexao(conexao);

            Assert.Equal((short)3, ponto.Painel);
            Assert.Equal(7, ponto.Potencial);
            Assert.Equal("2,5", ponto.Secao);
            Assert.Equal("PT", ponto.Cor);
            Assert.False(ponto.BJumper);
            Assert.Equal("ana", ponto.Criador);

            // Explicitamente deferidos: dependem da varredura de bornes.
            Assert.Null(ponto.Tag);
            Assert.Null(ponto.Terminal);
            Assert.Null(ponto.Handle);
        }
    }
}

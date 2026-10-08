using System.Collections.Generic;
using Positron.Data.Fiacao;
using Positron.Data.Interligacao;
using Xunit;

namespace Positron.Data.Tests
{
    public class InterligacaoXDataTests
    {
        /// <summary>Mesma sequência que <c>GravarXDataInterligacao</c> produz (19 valores).</summary>
        private static List<TypedXData> ValoresValidos()
        {
            return new List<TypedXData>
            {
                new TypedXData(1001, "INTERLIGACAO"),
                new TypedXData(1070, (short)2),        // Tipo
                new TypedXData(1000, "CABO1"),         // Tag_Cabo
                new TypedXData(1070, 3),               // NumVeia
                new TypedXData(1000, "VEIA1"),         // NomeVeia
                new TypedXData(1070, (short)2),        // Painel1
                new TypedXData(1070, 0),               // reservado
                new TypedXData(1070, (short)0),        // Painel2
                new TypedXData(1070, 0),               // reservado
                new TypedXData(1000, "H1"),            // handle
                new TypedXData(1000, string.Empty),
                new TypedXData(1000, string.Empty),
                new TypedXData(1070, 0),               // ocultaTag
                new TypedXData(1070, 5),               // iModeloVeiaFuncao
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
            InterligacaoXData ilig;
            Assert.True(InterligacaoXData.Ler(ValoresValidos(), out ilig));

            Assert.Equal((short)2, ilig.Tipo);
            Assert.Equal("CABO1", ilig.Tag_Cabo);
            Assert.Equal(3, ilig.NumVeia);
            Assert.Equal("VEIA1", ilig.NomeVeia);
            Assert.Equal((short)2, ilig.Painel1);
            Assert.Equal((short)0, ilig.Painel2);
            Assert.Equal("H1", ilig.Handle);
            Assert.Equal(5, ilig.IndexModeloVeiaFuncao);
            Assert.Equal("ana", ilig.Usuario);
            Assert.Equal("2026-10-07", ilig.Data);
        }

        [Fact]
        public void Recusa_app_name_diferente()
        {
            List<TypedXData> valores = ValoresValidos();
            valores[0] = new TypedXData(1001, "CONEXAO");

            InterligacaoXData ilig;
            Assert.False(InterligacaoXData.Ler(valores, out ilig));
            Assert.Null(ilig);
        }

        [Fact]
        public void Recusa_xdata_truncado()
        {
            List<TypedXData> valores = ValoresValidos();
            valores.RemoveRange(15, 4);

            InterligacaoXData ilig;
            Assert.False(InterligacaoXData.Ler(valores, out ilig));
        }

        [Fact]
        public void Projeta_o_ponto_a_partir_do_xdata()
        {
            InterligacaoXData ilig;
            InterligacaoXData.Ler(ValoresValidos(), out ilig);

            PontoInterligacao ponto = PontoInterligacao.DeInterligacao(ilig, "PAG1");

            Assert.Equal((short)2, ponto.Tipo);
            Assert.Equal("CABO1", ponto.Tag_Cabo);
            Assert.Equal(3, ponto.NumVeia);
            Assert.Equal((short)2, ponto.Painel1);
            Assert.Equal("PAG1", ponto.Pagina);
        }
    }
}

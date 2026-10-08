using System.Collections.Generic;
using Positron.Data.Bornes;
using Positron.Data.Fiacao;
using Xunit;

namespace Positron.Data.Tests
{
    public class BorneXDataTests
    {
        private static List<TypedXData> ValoresValidos()
        {
            return new List<TypedXData>
            {
                new TypedXData(1001, "Dispositivo"),
                new TypedXData(1000, "B"),            // tipo
                new TypedXData(1000, ""),             // reservado
                new TypedXData(1000, "J1"),           // PosInt_Jumper
                new TypedXData(1000, "LAY"),          // BlocoLayout
                new TypedXData(1000, "12"),           // Numero
                new TypedXData(1000, "A"),            // NumeroComplem
                new TypedXData(1040, 3.5),            // Ordem
                new TypedXData(1071, 8),              // IndiceRegua
                new TypedXData(1000, "CON"),          // conector
                new TypedXData(1000, "2"),            // lm
                new TypedXData(1000, "H"),            // Orientacao
                new TypedXData(1040, 0.0),
                new TypedXData(1040, 0.0),
                new TypedXData(1071, 1),              // tipo
                new TypedXData(1071, 1),              // Visivel
                new TypedXData(1000, "ana"),          // Usuario
                new TypedXData(1000, "2026-10-07"),   // Data
            };
        }

        [Fact]
        public void Le_o_layout_completo()
        {
            BorneXData borne;
            Assert.True(BorneXData.Ler(ValoresValidos(), out borne));

            Assert.Equal("12", borne.Numero);
            Assert.Equal("A", borne.NumeroComplem);
            Assert.Equal("12A", borne.Terminal);
            Assert.Equal(3.5, borne.Ordem);
            Assert.Equal(8, borne.IndiceRegua);
            Assert.Equal(1, borne.Tipo);
            Assert.Equal("ana", borne.Usuario);
        }

        [Fact]
        public void Aceita_app_name_legado()
        {
            List<TypedXData> valores = ValoresValidos();
            valores[0] = new TypedXData(1001, "DISPOSITIVO");

            BorneXData borne;
            Assert.True(BorneXData.Ler(valores, out borne));
        }

        [Fact]
        public void Recusa_dispositivo_que_nao_e_borne()
        {
            List<TypedXData> valores = ValoresValidos();
            valores[1] = new TypedXData(1000, "E"); // porta, não borne

            BorneXData borne;
            Assert.False(BorneXData.Ler(valores, out borne));
            Assert.Null(borne);
        }

        [Fact]
        public void Recusa_app_name_diferente()
        {
            List<TypedXData> valores = ValoresValidos();
            valores[0] = new TypedXData(1001, "CONEXAO");

            BorneXData borne;
            Assert.False(BorneXData.Ler(valores, out borne));
        }

        [Fact]
        public void Recusa_xdata_truncado()
        {
            List<TypedXData> valores = ValoresValidos();
            valores.RemoveRange(15, 3);

            BorneXData borne;
            Assert.False(BorneXData.Ler(valores, out borne));
        }
    }
}

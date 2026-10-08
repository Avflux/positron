using System.Collections.Generic;
using Positron.Data.Bornes;
using Positron.Data.Fiacao;
using Xunit;

namespace Positron.Data.Tests
{
    public class ReguasModeloTests
    {
        /// <summary>Dois registros de 10 valores: o segundo com painel 0 (descartado).</summary>
        private static List<TypedXData> Registros()
        {
            List<TypedXData> valores = new List<TypedXData>();
            Acrescenta(valores, 5, "R1", "ALT1", 3);
            Acrescenta(valores, 6, "R2", "", 0);
            Acrescenta(valores, 7, "R3", "ALT3", 4);
            return valores;
        }

        private static void Acrescenta(List<TypedXData> valores, int indice, string nome, string alternativo, int painel)
        {
            valores.Add(new TypedXData(1071, indice));
            valores.Add(new TypedXData(1000, nome));
            valores.Add(new TypedXData(1000, alternativo));
            valores.Add(new TypedXData(1071, painel));
            for (int i = 0; i < 6; i++)
            {
                valores.Add(new TypedXData(1071, 0));
            }
        }

        [Fact]
        public void Interpreta_as_reguas_e_descarta_painel_zero()
        {
            ReguasModelo modelo = ReguasModelo.Ler(Registros());

            Assert.Equal(2, modelo.Reguas.Count);

            ReguaInfo r1 = modelo.Buscar(5);
            Assert.NotNull(r1);
            Assert.Equal("R1", r1.Nome);
            Assert.Equal("ALT1", r1.Alternativo);
            Assert.Equal((short)3, r1.Painel);

            Assert.Null(modelo.Buscar(6)); // painel 0 → descartada
            Assert.Equal("R3", modelo.Buscar(7).Nome);
        }

        [Fact]
        public void Ignora_registro_truncado_no_fim()
        {
            List<TypedXData> valores = Registros();
            valores.Add(new TypedXData(1071, 9)); // sobrou só 1 valor

            ReguasModelo modelo = ReguasModelo.Ler(valores);
            Assert.Equal(2, modelo.Reguas.Count);
        }
    }
}

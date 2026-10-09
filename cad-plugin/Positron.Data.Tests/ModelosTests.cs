using System.Collections.Generic;
using Positron.Data.Fiacao;
using Positron.Data.Modelos;
using Xunit;

namespace Positron.Data.Tests
{
    public class ModelosTests
    {
        [Theory]
        [InlineData(null, 0.0)]
        [InlineData("", 0.0)]
        [InlineData("12", 12.0)]
        [InlineData("1.5", 1.0005)]
        [InlineData("A", 65000.0)]
        [InlineData("A5", 65005.0)]
        [InlineData("12A", 12.65)]
        [InlineData("1A2", 1065.02)]
        [InlineData("A1:2", 65001.002)]
        [InlineData("A1-2", 65001.002)]
        [InlineData("12+", 12.1)]
        [InlineData("12-", 12.0)]
        [InlineData("ABC", 1000000.0)]
        public void Calcula_o_numero_do_terminal(string terminal, double esperado)
        {
            Assert.Equal(esperado, TerminalNumerico.Calcular(terminal), 6);
        }

        [Theory]
        [InlineData("A1;A2;;", "NN;SS", "N;S")]
        [InlineData("A1;A2;;", "NS;SN", "N;S")]
        [InlineData("A1;;;", "NN;SS", "N;")]
        [InlineData("A1;A2;;", "", "")]
        public void Ajusta_a_orientacao_do_contato_ao_numero_de_terminais(string terminais, string orientacao, string esperado)
        {
            Assert.Equal(esperado, OrientacaoContato.Verificar(terminais, orientacao));
        }

        [Fact]
        public void Le_os_modelos_de_mascara()
        {
            List<TypedXData> valores = new List<TypedXData>
            {
                new TypedXData(1000, "cabeçalho"),
                new TypedXData(1071, 4),            // índice
                new TypedXData(1000, "MOD4"),       // nome
                new TypedXData(1071, 1),            // lm1
                new TypedXData(1071, 2),            // lm2
                new TypedXData(1000, "ignorado"),
                new TypedXData(1000, "TOPO"),       // bloco topográfico
                new TypedXData(1000, "LAYOUT"),     // bloco layout
                new TypedXData(1000, "0"),          // orientação
                new TypedXData(1000, "ignorado"),
            };

            List<ModeloMascara> modelos = ModelosMascara.LerModelos(valores);

            ModeloMascara modelo = Assert.Single(modelos);
            Assert.Equal(4, modelo.Indice);
            Assert.Equal("MOD4", modelo.Nome);
            Assert.Equal(2, modelo.Lm2);
            Assert.Equal("LAYOUT", modelo.BlocoLayout);
        }

        [Fact]
        public void Le_as_portas_de_um_modelo()
        {
            List<TypedXData> valores = new List<TypedXData>
            {
                new TypedXData(1071, 9),          // índice máximo
                new TypedXData(1071, 1),          // índice da porta
                new TypedXData(1000, "H"),        // orientação
                new TypedXData(1000, "EFC"),
                new TypedXData(1000, "1;2"),      // terminais
                new TypedXData(1000, "11;12"),    // bornes
                new TypedXData(1000, "ignorado"),
                new TypedXData(1000, "R1"),       // régua
                new TypedXData(1000, "ignorado"),
            };

            List<ModeloPorta> portas = ModelosMascara.LerPortas(valores, 4, "MOD4");

            ModeloPorta porta = Assert.Single(portas);
            Assert.Equal(4, porta.IndiceModelo);
            Assert.Equal("MOD4", porta.NomeModelo);
            Assert.Equal("1;2", porta.Terminais);
            Assert.Equal("11;12", porta.Bornes);
            Assert.Equal("R1", porta.Regua);
        }

        [Fact]
        public void Le_os_bornes_de_reserva_e_descarta_tipo_invalido()
        {
            List<TypedXData> valores = new List<TypedXData>();
            AcrescentaReserva(valores, "9", "1", 1.0, 0);   // tipo válido
            AcrescentaReserva(valores, "9", "3", 3.0, 9);   // tipo inválido → fora
            AcrescentaReserva(valores, "D", "1", 2.0, 1);   // tipo válido

            List<BorneReserva> reservas = BornesReserva.Ler(valores);

            Assert.Equal(2, reservas.Count);
            Assert.Equal("9", reservas[0].Numero);
            Assert.Equal(0, reservas[0].Tipo);
            Assert.Equal("D", reservas[1].Numero);
        }

        [Fact]
        public void Le_a_mascara_em_uso()
        {
            List<TypedXData> valores = new List<TypedXData>();
            valores.Add(new TypedXData(1001, "Dispositivo"));
            valores.Add(new TypedXData(1000, "M"));
            valores.Add(new TypedXData(1000, "N1"));
            valores.Add(new TypedXData(1000, "N2"));
            valores.Add(new TypedXData(1000, "ALT"));
            for (int i = 5; i < 26; i++)
            {
                valores.Add(new TypedXData(1071, 0));
            }

            valores[8] = new TypedXData(1070, (short)3);   // painel
            valores[12] = new TypedXData(1071, 4);         // índice do modelo
            valores[13] = new TypedXData(1071, 0);         // complementar

            MascaraXData mascara;
            Assert.True(MascaraXData.Ler(valores, out mascara));
            Assert.Equal((short)3, mascara.Painel);
            Assert.Equal(4, mascara.IndexModelo);
            Assert.False(mascara.Complementar);
        }

        private static void AcrescentaReserva(List<TypedXData> valores, string numero, string alternativo, double ordem, int tipo)
        {
            valores.Add(new TypedXData(1000, "cabeçalho"));
            valores.Add(new TypedXData(1000, numero));
            valores.Add(new TypedXData(1000, alternativo));
            valores.Add(new TypedXData(1040, ordem));
            valores.Add(new TypedXData(1071, tipo));
            valores.Add(new TypedXData(1071, 2));      // lm
            valores.Add(new TypedXData(1071, 1));      // reserva
            valores.Add(new TypedXData(1000, "H"));    // orientação
            valores.Add(new TypedXData(1000, "LAY"));  // bloco layout
            valores.Add(new TypedXData(1000, "ignorado"));
        }
    }
}

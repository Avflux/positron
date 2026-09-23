using System.Collections.Generic;
using Positron.Data.Modelos;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// O <c>STATBORN</c> em lote (frente 3): a contagem por régua e o total, com a regra do
    /// <c>SomaOsBornes</c> (tipo 0 = simples, outro = duplo; reserva à parte).
    /// </summary>
    public class EstatisticaDeBornesTests
    {
        [Fact]
        public void Conta_os_bornes_do_desenho_e_as_reservas()
        {
            LinhaDeEstatistica linha = EstatisticaDeBornes.Contar(
                12, "PT1", "R12",
                new List<int> { 0, 0, 1, 1, 1 },
                new List<int> { 0, 1 });

            Assert.Equal(2, linha.UsoS);
            Assert.Equal(3, linha.UsoD);
            Assert.Equal(1, linha.ResS);
            Assert.Equal(1, linha.ResD);
            Assert.Equal(7, linha.Total);
        }

        [Fact]
        public void A_linha_tem_os_nove_campos()
        {
            LinhaDeEstatistica linha = EstatisticaDeBornes.Contar(3, "PT9", "R3", new List<int> { 0 }, null);

            Assert.Equal("REGUA;3;PT9;R3;1;0;0;0;1", EstatisticaDeBornes.Linha(linha));
        }

        [Fact]
        public void O_total_soma_todas_as_reguas()
        {
            List<LinhaDeEstatistica> linhas = new List<LinhaDeEstatistica>
            {
                EstatisticaDeBornes.Contar(1, "P", "R1", new List<int> { 0, 1 }, new List<int> { 0 }),
                EstatisticaDeBornes.Contar(2, "P", "R2", new List<int> { 0 }, new List<int> { 1, 1 }),
            };

            LinhaDeEstatistica total = EstatisticaDeBornes.Total(linhas);

            Assert.Equal(2, total.UsoS);
            Assert.Equal(1, total.UsoD);
            Assert.Equal(1, total.ResS);
            Assert.Equal(2, total.ResD);
            Assert.Equal(6, total.Total);
            Assert.Equal("TOTAL", total.NomeRegua);
        }
    }
}

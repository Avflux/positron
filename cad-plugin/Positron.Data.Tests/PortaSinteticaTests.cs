using System.Collections.Generic;
using Positron.Data.Diagnostico;
using Positron.Data.Fiacao;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// A porta sintética do <c>pzDiagCriar</c> (a prova do <c>IndefineUmaPorta</c>, rodada 104):
    /// os 25 valores do XData <c>Dispositivo</c> no layout do reverso.
    /// </summary>
    public class PortaSinteticaTests
    {
        [Fact]
        public void Os_valores_do_XData_seguem_o_layout_do_reverso()
        {
            IReadOnlyList<TypedXData> valores = PortaSintetica.ParaValores(
                PortaSintetica.IndiceDoModelo, PortaSintetica.IndiceDaPorta);

            Assert.Equal(26, valores.Count);
            Assert.Equal(1001, valores[0].Codigo);
            Assert.Equal("Dispositivo", valores[0].Valor);
            Assert.Equal(1000, valores[1].Codigo);
            Assert.Equal("E", valores[1].Valor);

            // Os índices: o modelo no 5 e a porta no 6 (como o leitor do reverso).
            Assert.Equal(9, valores[5].Valor);
            Assert.Equal(5, valores[6].Valor);

            // O handle da definição e a chave primária (o que o Indefine zera).
            Assert.Equal(string.Empty, valores[9].Valor);
            Assert.Equal("CHAVE", valores[11].Valor);
        }

        [Fact]
        public void A_porta_do_desenho_nao_e_a_do_dicionario()
        {
            Assert.NotEqual(PortaSintetica.IndiceDaPorta, PortaSintetica.IndiceDaPortaDoDicionario);
            Assert.Equal(4, PortaSintetica.Tags.Count);
            Assert.Equal(4, PortaSintetica.Valores.Count);
            Assert.Equal("NOME1", PortaSintetica.Tags[0]);
            Assert.Equal("NOME-ANTIGO", PortaSintetica.Valores[0]);
        }
    }
}

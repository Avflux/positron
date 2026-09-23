using Positron.Data.Correcoes;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// O <c>CorrigePainelET1DosBornes</c> (frente 2 do §7.6): os atributos do borne e a
    /// sentinela <c>"OK"</c> do original.
    /// </summary>
    public class CorrecaoPainelDoBorneTests
    {
        [Fact]
        public void Nome1_com_o_borne_visivel_e_so_a_regua()
        {
            Assert.Equal("R1", CorrecaoPainelDoBorne.ValorDoAtributo("NOME1", "PT1", "R1", "5", 1, "/", "?"));
        }

        [Fact]
        public void Nome1_com_o_borne_invisivel_junta_painel_e_regua()
        {
            Assert.Equal("PT1/R1", CorrecaoPainelDoBorne.ValorDoAtributo("NOME1", "PT1", "R1", "5", 0, "/", "?"));
            Assert.Equal("PT1-R1", CorrecaoPainelDoBorne.ValorDoAtributo("NOME1", "PT1", "R1", "5", 2, "-", "?"));
        }

        [Fact]
        public void Painel_e_regua_saem_diretos()
        {
            Assert.Equal("PT1", CorrecaoPainelDoBorne.ValorDoAtributo("PAINEL", "PT1", "R1", "5", 1, "/", "?"));
            Assert.Equal("R1", CorrecaoPainelDoBorne.ValorDoAtributo("REGUA", "PT1", "R1", "5", 1, "/", "?"));
        }

        [Fact]
        public void T1_e_o_numero_ou_o_caracter_quando_zero()
        {
            Assert.Equal("7", CorrecaoPainelDoBorne.ValorDoAtributo("T1", "PT1", "R1", "7", 1, "/", "?"));
            Assert.Equal("?", CorrecaoPainelDoBorne.ValorDoAtributo("T1", "PT1", "R1", "0", 1, "/", "?"));
            // O original só troca o literal "0": um número vazio sai vazio.
            Assert.Equal(string.Empty, CorrecaoPainelDoBorne.ValorDoAtributo("T1", "PT1", "R1", "", 1, "/", "?"));
        }

        [Fact]
        public void Qualquer_outra_tag_nao_mexe()
        {
            // A sentinela do original é o literal "OK".
            Assert.Equal("OK", CorrecaoPainelDoBorne.NaoMexer);
            Assert.Equal(CorrecaoPainelDoBorne.NaoMexer, CorrecaoPainelDoBorne.ValorDoAtributo("T2", "PT1", "R1", "5", 1, "/", "?"));
            Assert.Equal(CorrecaoPainelDoBorne.NaoMexer, CorrecaoPainelDoBorne.ValorDoAtributo("", "PT1", "R1", "5", 1, "/", "?"));
            Assert.Equal(CorrecaoPainelDoBorne.NaoMexer, CorrecaoPainelDoBorne.ValorDoAtributo(null, "PT1", "R1", "5", 1, "/", "?"));
        }
    }
}

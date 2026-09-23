using Positron.Data.Diagnostico;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// O <c>pzDiag</c> (a ferramenta em C# que substitui os contadores LISP): o formato das
    /// linhas das duas seções.
    /// </summary>
    public class RelatorioDeDiagnosticoTests
    {
        [Fact]
        public void A_linha_da_porta_tem_os_dez_campos()
        {
            string linha = RelatorioDeDiagnostico.LinhaDePorta("E", 9, 5, "1A2B", "3C4D", "NOME1", "7", "PT1", "EFC1");

            Assert.Equal("PORTA;E;9;5;1A2B;3C4D;NOME1;7;PT1;EFC1", linha);
        }

        [Fact]
        public void Os_campos_vazios_saem_vazios()
        {
            Assert.Equal("PORTA;E;0;0;;;;;;", RelatorioDeDiagnostico.LinhaDePorta("E", 0, 0, null, null, null, null, null, null));

            // Sem o tipo, o campo sai vazio (nada de "null").
            Assert.Equal("PORTA;;0;0;;;;;;", RelatorioDeDiagnostico.LinhaDePorta(null, 0, 0, null, null, null, null, null, null));
        }

        [Fact]
        public void A_linha_da_cor_tem_o_par_da_referencia_e_da_definicao()
        {
            Assert.Equal("COR;242;BTZX;T1;1;3", RelatorioDeDiagnostico.LinhaDeCor("242", "BTZX", "T1", 1, 3));
        }

        [Fact]
        public void O_total_e_a_comparacao_de_cor()
        {
            Assert.Equal("TOTAL;portas;45;1979;50", RelatorioDeDiagnostico.Total("portas", 45, 1979, 50));
            Assert.Equal("TOTAL;diferencas;0", RelatorioDeDiagnostico.Total("diferencas", 0));

            Assert.True(RelatorioDeDiagnostico.CorDiferente(1, 3));
            Assert.False(RelatorioDeDiagnostico.CorDiferente(3, 3));
        }
    }
}

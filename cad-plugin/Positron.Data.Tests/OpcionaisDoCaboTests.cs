using System.Collections.Generic;
using Positron.Contract;
using Positron.Data.Interligacao;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// O <c>AtualizaOpcionaisDoCabo</c> (frente 2 do §7.6): a **receita** de opcionais do
    /// XData <c>AUXINTERLIG</c> e a normalização do <c>clsUtilitarios</c>.
    /// </summary>
    public class OpcionaisDoCaboTests
    {
        [Fact]
        public void Os_tokens_viram_o_texto()
        {
            // C = tag, N = NomeVeia, FU = função da veia, FO = formação, E = espaço.
            Assert.Equal("CABO-1-V1", Expandir("C#-#N#", Contexto()));
            Assert.Equal("CABO-1 V1 FU1 FO1", Expandir("C#E#N#E#FU#E#FO#", Contexto()));
        }

        [Fact]
        public void O_token_V_usa_o_nome_do_catalogo()
        {
            ContextoOpcionais contexto = Contexto();
            contexto.NomeDaVeia = "VEIA-X";
            Assert.Equal("CABO-1/VEIA-X", Expandir("C#/#V#", contexto));
        }

        [Fact]
        public void NumVeia_indefinido_zera_o_texto()
        {
            // A regra do original: com `-1000` o texto inteiro é zerado — e, depois do
            // laço, a checagem se repete.
            ContextoOpcionais contexto = Contexto();
            contexto.NumVeia = OpcionaisDoCabo.NumVeiaIndefinido;

            Assert.Equal("?", Expandir("C#-#N#", contexto));
            Assert.Equal("?", Expandir("N#", contexto));
        }

        [Fact]
        public void O_ultimo_token_e_descartado()
        {
            // O laço do original vai de 0 a `UBound - 1` (quirk): a receita termina com
            // um token que NÃO entra — aqui o `N` que ficaria entre parênteses.
            Assert.Equal("V1", Expandir("N#X#", Contexto()));
            Assert.Equal("V1", Expandir("N#", Contexto()));
        }

        [Fact]
        public void Parenteses_e_barra_saem_como_estao()
        {
            Assert.Equal("(V1)", Expandir("(#N#)#", Contexto()));
            Assert.Equal("CABO-1/V1", Expandir("C#/#N#", Contexto()));
        }

        [Fact]
        public void So_pontuacao_vira_o_caracter_indefinido()
        {
            // `()` some na normalização e, sem nada que preste, sai o `?`.
            Assert.Equal("?", Expandir("(#)#", Contexto()));
            Assert.Equal("?", Expandir(string.Empty, Contexto()));
            Assert.Equal(string.Empty, OpcionaisDoCabo.Normalizar("", string.Empty));
        }

        [Fact]
        public void Espacos_duplos_colapsam_em_duas_passadas()
        {
            // Traço + três espaços: as duas passadas deixam um só.
            Assert.Equal("- CABO-1", Expandir("-#E#E#E#C#", Contexto()));
        }

        [Fact]
        public void O_que_nao_e_token_nao_entra()
        {
            Assert.Equal("CABO-1", Expandir("C#X#", Contexto()));
            Assert.Equal("?", Expandir("X#Y#", Contexto()));
        }

        // ── O catálogo ────────────────────────────────────────────────────────

        [Fact]
        public void Busca_por_tag_sem_caixa_e_por_indice()
        {
            List<VeiasRow> veias = new List<VeiasRow> { Veia("CABO-1", 2, "V1", "FU1") };
            List<CabosRow> cabos = new List<CabosRow> { Cabo("cabo-1", "1x") };

            Assert.Equal("V1", OpcionaisDoCabo.BuscarNomeDaVeia(veias, "CABO-1", 2));
            Assert.Equal("FU1", OpcionaisDoCabo.BuscarFuncaoDaVeia(veias, "CABO-1", 2));
            Assert.Equal("1x", OpcionaisDoCabo.BuscarFormacao(cabos, "CABO-1"));

            Assert.Equal(string.Empty, OpcionaisDoCabo.BuscarNomeDaVeia(veias, "CABO-1", 3));
            Assert.Equal(string.Empty, OpcionaisDoCabo.BuscarFormacao(cabos, "OUTRO"));
            Assert.Equal(string.Empty, OpcionaisDoCabo.BuscarNomeDaVeia(null, "CABO-1", 2));
        }

        [Fact]
        public void Nome_da_veia_vazio_vira_o_numero()
        {
            // O `BuscaNomeVeia` devolve o índice quando o nome do catálogo está vazio.
            Assert.Equal("2", OpcionaisDoCabo.BuscarNomeDaVeia(
                new List<VeiasRow> { Veia("CABO-1", 2, "  ", "FU1") }, "CABO-1", 2));
        }

        // ── Montagem ──────────────────────────────────────────────────────────

        private static string Expandir(string opcionais, ContextoOpcionais contexto)
        {
            return OpcionaisDoCabo.Expandir(opcionais, contexto, "?");
        }

        private static ContextoOpcionais Contexto()
        {
            return new ContextoOpcionais
            {
                TagCabo = "CABO-1",
                NumVeia = 2,
                NomeVeia = "V1",
                NomeDaVeia = "V1",
                FuncaoDaVeia = "FU1",
                Formacao = "FO1",
            };
        }

        private static VeiasRow Veia(string tag, int indice, string nome, string funcao)
        {
            return new VeiasRow { Tag = tag, Indice = indice, Nome_Veia = nome, Funcao = funcao };
        }

        private static CabosRow Cabo(string tag, string formacao)
        {
            return new CabosRow { Tag = tag, Formacao = formacao };
        }
    }
}

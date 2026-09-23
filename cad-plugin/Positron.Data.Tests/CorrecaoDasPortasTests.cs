using System.Collections.Generic;
using Positron.Data.Correcoes;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// O <c>corrigePortas</c> (frente 2 do §7.6): o <c>EditaTodasPortas</c> — os atributos
    /// dos blocos de porta a partir da porta do <c>MASCARAS</c>.
    /// </summary>
    public class CorrecaoDasPortasTests
    {
        [Fact]
        public void Separar_bornes_tira_o_asterisco_e_guarda_a_marca()
        {
            BornesDaPorta bornes = CorrecaoDasPortas.SepararBornes("A;*B;C");

            Assert.Equal(new[] { "A", "B", "C" }, bornes.Bornes);
            Assert.Equal(new[] { false, true, false }, bornes.Marcas);
        }

        [Fact]
        public void T_recebe_o_terminal_e_o_vazio_vira_o_caracter()
        {
            string valor;
            bool? visivel;

            valor = CorrecaoDasPortas.ValorDoAtributo("T1", Terminais("X", ""), Bornes(""), "R", "E", "?", out visivel);
            Assert.Equal("X", valor);
            Assert.Null(visivel);

            valor = CorrecaoDasPortas.ValorDoAtributo("T2", Terminais("X", ""), Bornes(""), "R", "E", "?", out visivel);
            Assert.Equal("?", valor);

            // Sem terminal na posição, o caracter indefinido também vale.
            valor = CorrecaoDasPortas.ValorDoAtributo("T3", Terminais("X", ""), Bornes(""), "R", "E", "?", out visivel);
            Assert.Equal("?", valor);
        }

        [Fact]
        public void B_recebe_o_borne_sem_o_asterisco()
        {
            string valor;
            bool? visivel;
            BornesDaPorta bornes = CorrecaoDasPortas.SepararBornes("*A;B");

            valor = CorrecaoDasPortas.ValorDoAtributo("B1", Terminais(""), bornes, "R", "E", "?", out visivel);
            Assert.Equal("A", valor);

            valor = CorrecaoDasPortas.ValorDoAtributo("B2", Terminais(""), bornes, "R", "E", "?", out visivel);
            Assert.Equal("B", valor);

            // Sem o borne, o original escreve um espaço.
            valor = CorrecaoDasPortas.ValorDoAtributo("B9", Terminais(""), bornes, "R", "E", "?", out visivel);
            Assert.Equal(" ", valor);
        }

        [Fact]
        public void R_recebe_a_regua_e_a_visibilidade_vem_da_marca()
        {
            string valor;
            bool? visivel;
            BornesDaPorta bornes = CorrecaoDasPortas.SepararBornes("*A;B");

            valor = CorrecaoDasPortas.ValorDoAtributo("R1", Terminais(""), bornes, "R1X", "E", "?", out visivel);
            Assert.Equal("R1X", valor);
            Assert.True(visivel);

            valor = CorrecaoDasPortas.ValorDoAtributo("R2", Terminais(""), bornes, "R1X", "E", "?", out visivel);
            Assert.Equal("R1X", valor);
            Assert.False(visivel);

            valor = CorrecaoDasPortas.ValorDoAtributo("R9", Terminais(""), bornes, "R1X", "E", "?", out visivel);
            Assert.Equal("R1X", valor);
            Assert.False(visivel);
        }

        [Fact]
        public void EFC_recebe_o_efc_da_porta()
        {
            bool? visivel;
            Assert.Equal("EFCX", CorrecaoDasPortas.ValorDoAtributo(
                "EFC", Terminais(""), Bornes(""), "R", "EFCX", "?", out visivel));
            Assert.Null(visivel);
        }

        [Fact]
        public void O_que_nao_e_tag_de_porta_nao_mexe()
        {
            bool? visivel;

            // `NOME1` e `ORIGEM` ficam fora do recorte (as duas Busca* do original).
            Assert.Equal(CorrecaoDasPortas.NaoMexer, CorrecaoDasPortas.ValorDoAtributo(
                "NOME1", Terminais("X"), Bornes("A"), "R", "E", "?", out visivel));
            Assert.Equal(CorrecaoDasPortas.NaoMexer, CorrecaoDasPortas.ValorDoAtributo(
                "ORIGEM", Terminais("X"), Bornes("A"), "R", "E", "?", out visivel));
            Assert.Equal(CorrecaoDasPortas.NaoMexer, CorrecaoDasPortas.ValorDoAtributo(
                "X1", Terminais("X"), Bornes("A"), "R", "E", "?", out visivel));
            Assert.Equal(CorrecaoDasPortas.NaoMexer, CorrecaoDasPortas.ValorDoAtributo(
                "T", Terminais("X"), Bornes("A"), "R", "E", "?", out visivel));
            Assert.Equal(CorrecaoDasPortas.NaoMexer, CorrecaoDasPortas.ValorDoAtributo(
                null, Terminais("X"), Bornes("A"), "R", "E", "?", out visivel));
        }

        [Fact]
        public void O_numero_da_tag_aceita_mais_de_um_digito()
        {
            string valor;
            bool? visivel;
            List<string> terminais = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                terminais.Add("T" + i);
            }

            valor = CorrecaoDasPortas.ValorDoAtributo("T10", terminais, Bornes(""), "R", "E", "?", out visivel);
            Assert.Equal("T9", valor);
        }

        private static List<string> Terminais(params string[] valores)
        {
            return new List<string>(valores);
        }

        private static BornesDaPorta Bornes(string bornes)
        {
            return CorrecaoDasPortas.SepararBornes(bornes);
        }
    }
}

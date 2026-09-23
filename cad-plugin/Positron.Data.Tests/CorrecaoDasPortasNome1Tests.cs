using System.Collections.Generic;
using Positron.Data.Correcoes;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// O <c>corrigePortas</c> (frente 2 do §7.6): o <c>NOME1</c> (o nome da máscara) e a
    /// <c>ORIGEM</c> (a página do texto da definição), que fecharam o recorte da rodada 87.
    /// </summary>
    public class CorrecaoDasPortasNome1Tests
    {
        [Fact]
        public void Nome1_recebe_o_nome_da_mascara()
        {
            bool? visivel;
            string valor = CorrecaoDasPortas.ValorDoAtributo(
                "NOME1", Terminais("T1"), Bornes("A"), "R", "E", "?", "PT1/R9", "/12", out visivel);

            Assert.Equal("PT1/R9", valor);
            Assert.Null(visivel);
        }

        [Fact]
        public void Origem_recebe_a_pagina()
        {
            bool? visivel;
            string valor = CorrecaoDasPortas.ValorDoAtributo(
                "ORIGEM", Terminais("T1"), Bornes("A"), "R", "E", "?", "PT1/R9", "/12", out visivel);

            Assert.Equal("/12", valor);
            Assert.Null(visivel);
        }

        [Fact]
        public void Sem_a_mascara_e_a_pagina_os_dois_saem_vazios()
        {
            bool? visivel;

            // A sobrecarga sem os dois continua valendo (NOME1/ORIGEM vazios).
            Assert.Equal(string.Empty, CorrecaoDasPortas.ValorDoAtributo(
                "NOME1", Terminais("T1"), Bornes("A"), "R", "E", "?", out visivel));
            Assert.Equal(string.Empty, CorrecaoDasPortas.ValorDoAtributo(
                "ORIGEM", Terminais("T1"), Bornes("A"), "R", "E", "?", out visivel));
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

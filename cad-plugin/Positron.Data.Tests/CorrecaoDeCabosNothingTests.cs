using System.Collections.Generic;
using Positron.Data.Correcoes;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// O <c>CorrigeCabos</c> (frente 2 do §7.6): o <c>CorrigeNothing("Funcao")</c> — as três
    /// atualizações, na ordem, e a lista branca da coluna.
    /// </summary>
    public class CorrecaoDeCabosNothingTests
    {
        [Fact]
        public void As_tres_atualizacoes_do_original()
        {
            IReadOnlyList<AtualizacaoDeCabo> plano = CorrecaoDeCabosNothing.Plano("Funcao");

            Assert.Equal(3, plano.Count);

            Assert.Equal("Cabos", plano[0].Tabela);
            Assert.Equal("Funcao", plano[0].Coluna);
            Assert.Equal(" ", plano[0].Valor);
            Assert.False(plano[0].SemFiltro);

            Assert.Equal("Cabos4", plano[1].Tabela);
            Assert.Equal(" ", plano[1].Valor);

            // O `Alarme` é zerado SEM filtro, como no original.
            Assert.Equal("Cabos", plano[2].Tabela);
            Assert.Equal("Alarme", plano[2].Coluna);
            Assert.Equal("0", plano[2].Valor);
            Assert.True(plano[2].SemFiltro);
        }

        [Fact]
        public void A_coluna_esta_na_lista_branca()
        {
            Assert.True(CorrecaoDeCabosNothing.ColunaValida("Funcao"));
            Assert.True(CorrecaoDeCabosNothing.ColunaValida("funcao"));
            Assert.False(CorrecaoDeCabosNothing.ColunaValida("Tag"));
            Assert.False(CorrecaoDeCabosNothing.ColunaValida(null));

            // Fora da lista branca não há plano nenhum.
            Assert.Empty(CorrecaoDeCabosNothing.Plano("Tag"));
        }
    }
}

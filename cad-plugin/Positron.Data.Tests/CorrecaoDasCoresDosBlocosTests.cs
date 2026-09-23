using System.Collections.Generic;
using Positron.Data.Correcoes;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// O <c>CorrigeCoresDosBlocos</c> (frente 2 do §7.6): a cor do atributo vem da
    /// definição do bloco (e o quirk do nome em caixa alta).
    /// </summary>
    public class CorrecaoDasCoresDosBlocosTests
    {
        [Fact]
        public void O_nome_do_bloco_e_procurado_em_caixa_alta()
        {
            // O quirk: a lista guarda o nome CRU e a terceira passada compara com o
            // `ToUpper` do bloco — o nome já em caixa alta entra.
            List<string> nomes = new List<string> { "BT4NAXX", "ZeBra" };

            Assert.True(CorrecaoDasCoresDosBlocos.BlocoEntra(nomes, "BT4NAXX"));
            Assert.True(CorrecaoDasCoresDosBlocos.BlocoEntra(nomes, "bt4naxx"));

            // O `ZeBra` cru não casa com o `ZEBRA` procurado.
            Assert.False(CorrecaoDasCoresDosBlocos.BlocoEntra(nomes, "Zebra"));
            Assert.False(CorrecaoDasCoresDosBlocos.BlocoEntra(nomes, "OUTRO"));
            Assert.False(CorrecaoDasCoresDosBlocos.BlocoEntra(null, "BT4NAXX"));
            Assert.False(CorrecaoDasCoresDosBlocos.BlocoEntra(nomes, null));
        }

        [Fact]
        public void A_cor_vem_da_definicao_do_par_bloco_tag()
        {
            List<CorDeAtributo> cores = new List<CorDeAtributo>
            {
                new CorDeAtributo { NomeBloco = "BT4NAXX", Tag = "T1", Cor = 3 },
                new CorDeAtributo { NomeBloco = "BT4NAXX", Tag = "T2", Cor = 256 },
            };

            Assert.Equal(3, Cor(cores, "BT4NAXX", "T1"));

            // As duas comparações são sem caixa (o `TextCompare` do original).
            Assert.Equal(256, Cor(cores, "bt4naxx", "t2"));

            // Sem definição para o par, o atributo fica como está (-1).
            Assert.Equal(-1, Cor(cores, "BT4NAXX", "T9"));
            Assert.Equal(-1, Cor(cores, "OUTRO", "T1"));
            Assert.Equal(-1, Cor(null, "BT4NAXX", "T1"));
        }

        private static int Cor(IReadOnlyList<CorDeAtributo> cores, string bloco, string tag)
        {
            short? cor = CorrecaoDasCoresDosBlocos.CorDoAtributo(cores, bloco, tag);
            return cor.HasValue ? cor.Value : -1;
        }
    }
}

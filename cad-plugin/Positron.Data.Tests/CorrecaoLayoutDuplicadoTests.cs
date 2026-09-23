using System.Collections.Generic;
using Positron.Data.Correcoes;
using Positron.Data.Layout;
using Positron.Data.Fiacao;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// O <c>REMLAYDUP</c> (frente 2 do §7.6): a regra de dedup do <c>CENG_LAYOUT</c>
    /// e a leitura/gravação crua dos cinco valores por posição.
    /// </summary>
    public class CorrecaoLayoutDuplicadoTests
    {
        [Fact]
        public void Tira_o_duplicado_e_conserva_o_primeiro()
        {
            // A sequência do original: o `A` repetido sai e o último (`C`) também.
            IReadOnlyList<LayoutPosicoes.PosicaoBruta> saida = CorrecaoLayoutDuplicado.RemoverDuplicados(
                new List<LayoutPosicoes.PosicaoBruta> { Bruta("A", 1), Bruta("B", 2), Bruta("A", 3), Bruta("C", 4) });

            Assert.Equal(2, saida.Count);
            Assert.Equal("A", saida[0].Tag);
            Assert.Equal("B", saida[1].Tag);
            Assert.Equal(1.0, saida[0].X, 6);
        }

        [Fact]
        public void O_ultimo_registro_sempre_sai()
        {
            // O laço vai de 0 a `UBound - 1`: sem duplicado nenhum, o último cai.
            IReadOnlyList<LayoutPosicoes.PosicaoBruta> saida = CorrecaoLayoutDuplicado.RemoverDuplicados(
                new List<LayoutPosicoes.PosicaoBruta> { Bruta("A", 1), Bruta("B", 2), Bruta("C", 3) });

            Assert.Equal(new[] { "A", "B" }, Tags(saida));
        }

        [Fact]
        public void Um_registro_so_vira_lista_vazia()
        {
            Assert.Empty(CorrecaoLayoutDuplicado.RemoverDuplicados(
                new List<LayoutPosicoes.PosicaoBruta> { Bruta("A", 1) }));
            Assert.Empty(CorrecaoLayoutDuplicado.RemoverDuplicados(new List<LayoutPosicoes.PosicaoBruta>()));
            Assert.Empty(CorrecaoLayoutDuplicado.RemoverDuplicados(null));
        }

        [Fact]
        public void O_indice_de_leitura_e_de_gravacao()
        {
            // O layout do `gravaDicLayout`: 1 = tag, 1 = alternativo, 40 = X, 40 = Y, 1 = vazio.
            IReadOnlyList<TypedXData> valores = LayoutPosicoes.ParaValores(
                new List<LayoutPosicoes.PosicaoBruta>
                {
                    new LayoutPosicoes.PosicaoBruta { Tag = "T1", Alternativo = "ALT", X = 1.5, Y = 2.5 },
                    new LayoutPosicoes.PosicaoBruta { Tag = "T2" },
                });

            Assert.Equal(10, valores.Count);
            Assert.Equal(1, valores[0].Codigo);
            Assert.Equal("T1", valores[0].Valor);
            Assert.Equal(1, valores[1].Codigo);
            Assert.Equal("ALT", valores[1].Valor);
            Assert.Equal(40, valores[2].Codigo);
            Assert.Equal(1.5, valores[2].Valor);
            Assert.Equal(40, valores[3].Codigo);
            Assert.Equal(2.5, valores[3].Valor);
            Assert.Equal(1, valores[4].Codigo);
            Assert.Equal(string.Empty, valores[4].Valor);

            IReadOnlyList<LayoutPosicoes.PosicaoBruta> lidos = LayoutPosicoes.LerBruto(valores);
            Assert.Equal(2, lidos.Count);
            Assert.Equal("T1", lidos[0].Tag);
            Assert.Equal("ALT", lidos[0].Alternativo);
            Assert.Equal(1.5, lidos[0].X, 6);
            Assert.Equal(2.5, lidos[0].Y, 6);
            Assert.Equal("T2", lidos[1].Tag);
            Assert.Equal(string.Empty, lidos[1].Alternativo);
        }

        [Fact]
        public void Valores_truncados_sao_ignorados()
        {
            IReadOnlyList<TypedXData> valores = new List<TypedXData>
            {
                new TypedXData(1, "T1"), new TypedXData(1, ""),
                new TypedXData(40, 0.0), new TypedXData(40, 0.0),
                new TypedXData(1, ""),
                new TypedXData(1, "T2"),
            };

            Assert.Single(LayoutPosicoes.LerBruto(valores));
            Assert.Empty(LayoutPosicoes.LerBruto(null));
            Assert.Empty(LayoutPosicoes.ParaValores(null));
        }

        [Fact]
        public void Precisa_regravar_so_quando_muda()
        {
            List<LayoutPosicoes.PosicaoBruta> antes = new List<LayoutPosicoes.PosicaoBruta> { Bruta("A", 1), Bruta("B", 2) };
            List<LayoutPosicoes.PosicaoBruta> igual = new List<LayoutPosicoes.PosicaoBruta> { Bruta("A", 1), Bruta("B", 2) };
            List<LayoutPosicoes.PosicaoBruta> outro = new List<LayoutPosicoes.PosicaoBruta> { Bruta("A", 1) };

            Assert.False(CorrecaoLayoutDuplicado.PrecisaRegravar(antes, igual));
            Assert.True(CorrecaoLayoutDuplicado.PrecisaRegravar(antes, outro));
            Assert.True(CorrecaoLayoutDuplicado.PrecisaRegravar(antes, null));

            outro[0].X = 9.0;
            Assert.True(CorrecaoLayoutDuplicado.PrecisaRegravar(antes, outro));
        }

        private static string[] Tags(IReadOnlyList<LayoutPosicoes.PosicaoBruta> registros)
        {
            List<string> tags = new List<string>();
            foreach (LayoutPosicoes.PosicaoBruta registro in registros)
            {
                tags.Add(registro.Tag);
            }

            return tags.ToArray();
        }

        private static LayoutPosicoes.PosicaoBruta Bruta(string tag, double x)
        {
            return new LayoutPosicoes.PosicaoBruta { Tag = tag, Alternativo = "", X = x, Y = x };
        }
    }
}

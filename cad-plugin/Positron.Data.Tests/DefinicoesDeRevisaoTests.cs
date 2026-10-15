using System.Collections.Generic;
using Positron.Data.Paginas;
using Xunit;

namespace Positron.Data.Tests
{
    public class DefinicoesDeRevisaoTests
    {
        private static TagDeAtributo Tag(string tag, string layer)
        {
            return new TagDeAtributo(tag, layer);
        }

        [Fact]
        public void Nome_usa_a_capa_ou_o_formato_do_corpo()
        {
            Assert.Equal("Revisao_Capa0", DefinicoesDeRevisao.Nome("1", "0"));
            Assert.Equal("Revisao_Capa3", DefinicoesDeRevisao.Nome("0001", "3"));
            Assert.Equal("Revisao_Corpo2", DefinicoesDeRevisao.Nome("-1", "2"));

            // Um layer que não é nem a capa nem o -1 não gera definição.
            Assert.Equal(string.Empty, DefinicoesDeRevisao.Nome("5", "0"));
            Assert.Equal(string.Empty, DefinicoesDeRevisao.Nome(null, "0"));
        }

        [Fact]
        public void So_as_48_tags_do_attRevProtCollection_sao_protegidas()
        {
            Assert.True(DefinicoesDeRevisao.EhTagProtegida("REV0"));
            Assert.True(DefinicoesDeRevisao.EhTagProtegida("desc7"));
            Assert.True(DefinicoesDeRevisao.EhTagProtegida("APROV0"));
            Assert.True(DefinicoesDeRevisao.EhTagProtegida("VERIF5"));

            // A tag REV sozinha, os dígitos 8/9 e as famílias fora do conjunto ficam fora.
            Assert.False(DefinicoesDeRevisao.EhTagProtegida("REV"));
            Assert.False(DefinicoesDeRevisao.EhTagProtegida("REV8"));
            Assert.False(DefinicoesDeRevisao.EhTagProtegida("REVISAO"));
            Assert.False(DefinicoesDeRevisao.EhTagProtegida("TITULO0"));
            Assert.False(DefinicoesDeRevisao.EhTagProtegida(null));
        }

        [Fact]
        public void Copiar_exige_o_layer_a_tag_protegida_e_o_digito_no_fim()
        {
            Assert.True(DefinicoesDeRevisao.Copiar("1", "REV0", "1", "0"));
            Assert.True(DefinicoesDeRevisao.Copiar("-1", "DESC3", "-1", "3"));

            // Layer errado.
            Assert.False(DefinicoesDeRevisao.Copiar("-1", "REV0", "1", "0"));
            // O dígito da posição tem de ser o fim da tag.
            Assert.False(DefinicoesDeRevisao.Copiar("1", "REV1", "1", "0"));
            // Tag não protegida.
            Assert.False(DefinicoesDeRevisao.Copiar("1", "REV", "1", "0"));
            Assert.False(DefinicoesDeRevisao.Copiar("1", "TITULO0", "1", "0"));
            // Sem tipo não há sufixo.
            Assert.False(DefinicoesDeRevisao.Copiar("1", "REV0", "1", string.Empty));
        }

        [Fact]
        public void Contar_le_so_as_tags_numeradas_da_capa_e_do_corpo()
        {
            List<TagDeAtributo> formato = new List<TagDeAtributo>
            {
                Tag("REV0", "1"),
                Tag("REV1", "1"),
                Tag("REV2", "1"),
                Tag("REV3", "1"),
                Tag("REV0", "-1"),
                Tag("REV1", "-1"),
                // Não contam: o REV solto e as descrições.
                Tag("REV", "1"),
                Tag("DESC0", "-1"),
                // Fora dos dois layers.
                Tag("REV7", "5"),
            };

            PosicoesDoFormato posicoes = DefinicoesDeRevisao.Contar(formato, "1");
            Assert.Equal(4, posicoes.Capa);
            Assert.Equal(2, posicoes.Corpo);
            Assert.False(posicoes.Vazio);

            PosicoesDoFormato vazio = DefinicoesDeRevisao.Contar(null, "1");
            Assert.Equal(0, vazio.Capa);
            Assert.Equal(0, vazio.Corpo);
            Assert.True(vazio.Vazio);
        }

        [Fact]
        public void Tag_numerada_de_revisao_e_rev_e_um_digito_de_0_a_7()
        {
            Assert.True(DefinicoesDeRevisao.EhTagNumeradaDeRevisao("REV0"));
            Assert.True(DefinicoesDeRevisao.EhTagNumeradaDeRevisao("rev7"));
            Assert.False(DefinicoesDeRevisao.EhTagNumeradaDeRevisao("REV"));
            Assert.False(DefinicoesDeRevisao.EhTagNumeradaDeRevisao("REV8"));
            Assert.False(DefinicoesDeRevisao.EhTagNumeradaDeRevisao("DESC0"));
            Assert.False(DefinicoesDeRevisao.EhTagNumeradaDeRevisao(null));
        }
    }
}

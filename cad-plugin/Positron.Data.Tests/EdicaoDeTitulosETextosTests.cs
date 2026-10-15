using System.Collections.Generic;
using Positron.Data.Paginas;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// O <c>TROCTT</c> (<c>frmEditaTitulosTextos</c>): o <c>EditaTitulosTextosDoDWG</c> e o
    /// <c>buscaTitulosExistentes</c>.
    /// </summary>
    public class EdicaoDeTitulosETextosTests
    {
        private static readonly List<string> Paginas = new List<string> { "1", "2" };

        private static OpcoesDeTitulosETextos Opcoes(bool t1 = false, bool t4 = false, bool textos = false, bool multi = false, string de = "ABC", string para = "XYZ")
        {
            return new OpcoesDeTitulosETextos { Titulo1 = t1, Titulo4 = t4, Textos = textos, MultiTextos = multi, De = de, Para = para };
        }

        private static TextoNaPagina Texto(string texto, int titulo = 0, bool protegido = false, string layer = "1")
        {
            return new TextoNaPagina(TipoDeTextoNaPagina.Texto, layer, texto, titulo, protegido);
        }

        [Fact]
        public void Titulo_so_troca_quando_o_indice_dele_esta_marcado()
        {
            Assert.Equal("SE XYZ", EdicaoDeTitulosETextos.NovoTexto(Texto("SE ABC", titulo: 1), Opcoes(t1: true), Paginas));
            Assert.Null(EdicaoDeTitulosETextos.NovoTexto(Texto("SE ABC", titulo: 2), Opcoes(t1: true, textos: true), Paginas));
        }

        [Fact]
        public void Texto_solto_so_com_textos_marcado_e_sem_xdata_do_produto()
        {
            Assert.Equal("XYZ-1", EdicaoDeTitulosETextos.NovoTexto(Texto("ABC-1"), Opcoes(textos: true), Paginas));
            Assert.Null(EdicaoDeTitulosETextos.NovoTexto(Texto("ABC-1"), Opcoes(t1: true), Paginas));
            Assert.Null(EdicaoDeTitulosETextos.NovoTexto(Texto("ABC-1", protegido: true), Opcoes(textos: true), Paginas));
        }

        [Fact]
        public void Multitexto_so_com_a_caixa_dele()
        {
            var mtext = new TextoNaPagina(TipoDeTextoNaPagina.MultiTexto, "2", "ABC\\PABC", 0, false);

            Assert.Equal("XYZ\\PXYZ", EdicaoDeTitulosETextos.NovoTexto(mtext, Opcoes(multi: true), Paginas));
            Assert.Null(EdicaoDeTitulosETextos.NovoTexto(mtext, Opcoes(textos: true), Paginas));
        }

        [Fact]
        public void Fora_das_paginas_escolhidas_nada_e_a_pagina_diferencia_maiusculas()
        {
            Assert.Null(EdicaoDeTitulosETextos.NovoTexto(Texto("ABC", layer: "3"), Opcoes(textos: true), Paginas));
            Assert.Null(EdicaoDeTitulosETextos.NovoTexto(Texto("ABC", layer: "1a"), Opcoes(textos: true), new List<string> { "1A" }));
        }

        [Fact]
        public void A_troca_diferencia_maiusculas_e_so_trocar_a_caixa_nao_grava()
        {
            Assert.Null(EdicaoDeTitulosETextos.NovoTexto(Texto("abc"), Opcoes(textos: true), Paginas));
            Assert.Null(EdicaoDeTitulosETextos.NovoTexto(Texto("ABC"), Opcoes(textos: true, para: "abc"), Paginas));
            Assert.Null(EdicaoDeTitulosETextos.NovoTexto(Texto("   "), Opcoes(textos: true, de: " "), Paginas));
        }

        [Fact]
        public void Opcoes_validas_pedem_uma_caixa_e_o_de()
        {
            Assert.False(Opcoes().Valida);
            Assert.False(Opcoes(textos: true, de: "").Valida);
            Assert.True(Opcoes(multi: true).Valida);
        }

        [Fact]
        public void Titulos_existentes_vem_dos_atributos_no_layer_menos_1_e_painel_liga_o_4()
        {
            bool[] existe = EdicaoDeTitulosETextos.TitulosExistentes(new[]
            {
                new KeyValuePair<string, string>("titulo1pag", "-1"),
                new KeyValuePair<string, string>("TITULO2PAG", "0"),
                new KeyValuePair<string, string>("PAINEL", "-1"),
            });

            Assert.True(existe[1]);
            Assert.False(existe[2]);
            Assert.False(existe[3]);
            Assert.True(existe[4]);
        }
    }
}

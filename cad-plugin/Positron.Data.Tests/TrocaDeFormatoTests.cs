using System.Collections.Generic;
using Positron.Data.Paginas;
using Xunit;

namespace Positron.Data.Tests
{
    public class TrocaDeFormatoTests
    {
        private static AtributoDoFormato Atributo(string layer, string tag, string valor)
        {
            return new AtributoDoFormato(layer, tag, valor);
        }

        [Fact]
        public void TagsProtegidas_sao_as_59_do_attProtCollection()
        {
            // 11 soltas (os títulos, o painel, a seção, FL/CONT/REV/TOT) + 6 famílias × 8 dígitos.
            Assert.Equal(59, TrocaDeFormato.TagsProtegidas.Count);

            HashSet<string> vistas = new HashSet<string>();
            foreach (string tag in TrocaDeFormato.TagsProtegidas)
            {
                Assert.True(vistas.Add(tag), "tag repetida: " + tag);
            }
        }

        [Fact]
        public void Protegida_cobre_o_conjunto_e_recusa_o_resto()
        {
            Assert.True(TrocaDeFormato.Protegida("TITULO1PAG"));
            Assert.True(TrocaDeFormato.Protegida("TITULO4PAG"));
            Assert.True(TrocaDeFormato.Protegida("PAINEL"));
            Assert.True(TrocaDeFormato.Protegida("SECAO"));
            Assert.True(TrocaDeFormato.Protegida("FL"));
            Assert.True(TrocaDeFormato.Protegida("CONT"));
            Assert.True(TrocaDeFormato.Protegida("REV"));
            Assert.True(TrocaDeFormato.Protegida("TOT"));
            Assert.True(TrocaDeFormato.Protegida("ALTERNATIVO"));
            Assert.True(TrocaDeFormato.Protegida("REV0"));
            Assert.True(TrocaDeFormato.Protegida("REV7"));
            Assert.True(TrocaDeFormato.Protegida("desc3"));
            Assert.True(TrocaDeFormato.Protegida("DATA7"));
            Assert.True(TrocaDeFormato.Protegida("ELAB0"));
            Assert.True(TrocaDeFormato.Protegida("VERIF5"));
            Assert.True(TrocaDeFormato.Protegida("APROV0"));

            // Fora do conjunto.
            Assert.False(TrocaDeFormato.Protegida("REV8"));
            Assert.False(TrocaDeFormato.Protegida("REVISAO"));
            Assert.False(TrocaDeFormato.Protegida("TITULO0"));
            Assert.False(TrocaDeFormato.Protegida("TITULO5PAG"));
            Assert.False(TrocaDeFormato.Protegida("DESC8"));
            Assert.False(TrocaDeFormato.Protegida("CLIENTE"));
            Assert.False(TrocaDeFormato.Protegida(null));
            Assert.False(TrocaDeFormato.Protegida("   "));
        }

        [Fact]
        public void ValePreservar_exige_nao_protegida_e_texto()
        {
            Assert.True(TrocaDeFormato.ValePreservar("CLIENTE", "Eletrosul"));
            Assert.True(TrocaDeFormato.ValePreservar("DATA", "2026"));

            // Protegida nunca entra, mesmo com texto.
            Assert.False(TrocaDeFormato.ValePreservar("PAINEL", "7"));
            Assert.False(TrocaDeFormato.ValePreservar("REV0", "A"));

            // Sem texto (ou só espaços) não entra.
            Assert.False(TrocaDeFormato.ValePreservar("CLIENTE", ""));
            Assert.False(TrocaDeFormato.ValePreservar("CLIENTE", "   "));
            Assert.False(TrocaDeFormato.ValePreservar("CLIENTE", null));
        }

        [Fact]
        public void Captura_guarda_so_o_que_vale_e_na_ordem()
        {
            List<AtributoDoFormato> formato = new List<AtributoDoFormato>
            {
                Atributo("1", "CLIENTE", "Eletrosul"),   // entra
                Atributo("1", "PAINEL", "7"),            // protegida: fora
                Atributo("1", "VAZIO", ""),              // sem texto: fora
                Atributo("-1", "NOTA", "  x  "),         // entra
            };

            IReadOnlyList<AtributoDoFormato> capturados = TrocaDeFormato.Captura(formato);
            Assert.Equal(2, capturados.Count);
            Assert.Equal("CLIENTE", capturados[0].Tag);
            Assert.Equal("NOTA", capturados[1].Tag);

            Assert.Empty(TrocaDeFormato.Captura(null));
        }

        [Fact]
        public void ValorPreservado_casa_pagina_em_decimal_e_tag_sem_caixa()
        {
            List<AtributoDoFormato> capturados = new List<AtributoDoFormato>
            {
                Atributo("001", "cliente", "Eletrosul"),
                Atributo("2", "cliente", "Outra"),
            };

            // A página casa pelo decimal: "1" acha o capturado no "001".
            Assert.Equal("Eletrosul", TrocaDeFormato.ValorPreservado("1", "CLIENTE", capturados));
            Assert.Equal("Eletrosul", TrocaDeFormato.ValorPreservado("001", "cliente", capturados));

            // Página diferente → o outro valor.
            Assert.Equal("Outra", TrocaDeFormato.ValorPreservado("2", "CLIENTE", capturados));

            // Página sem par, tag sem par e buffer vazio → vazio.
            Assert.Equal(string.Empty, TrocaDeFormato.ValorPreservado("3", "CLIENTE", capturados));
            Assert.Equal(string.Empty, TrocaDeFormato.ValorPreservado("1", "NOTA", capturados));
            Assert.Equal(string.Empty, TrocaDeFormato.ValorPreservado("1", "CLIENTE", null));
        }

        [Fact]
        public void Definir_protege_o_conjunto_e_preserva_o_resto()
        {
            List<AtributoDoFormato> capturados = new List<AtributoDoFormato>
            {
                Atributo("1", "CLIENTE", "Eletrosul"),
            };

            // Não protegida: herda o valor capturado.
            InstrucaoDeAtributo cliente = TrocaDeFormato.Definir("CLIENTE", "1", capturados);
            Assert.False(cliente.Invisivel);
            Assert.Equal("Eletrosul", cliente.Texto);

            // Protegida: invisível e vazia.
            InstrucaoDeAtributo painel = TrocaDeFormato.Definir("PAINEL", "1", capturados);
            Assert.True(painel.Invisivel);
            Assert.Equal(string.Empty, painel.Texto);

            // Não protegida sem par no buffer: visível e vazia.
            InstrucaoDeAtributo nota = TrocaDeFormato.Definir("NOTA", "1", capturados);
            Assert.False(nota.Invisivel);
            Assert.Equal(string.Empty, nota.Texto);
        }

        [Fact]
        public void PrecisaRenomearCapa_so_quando_ha_capa_com_outro_nome()
        {
            Assert.True(TrocaDeFormato.PrecisaRenomearCapa("001"));
            Assert.True(TrocaDeFormato.PrecisaRenomearCapa("0001"));

            // O "1" já é o destino; sem capa não há o que renomear.
            Assert.False(TrocaDeFormato.PrecisaRenomearCapa("1"));
            Assert.False(TrocaDeFormato.PrecisaRenomearCapa(" 1 "));
            Assert.False(TrocaDeFormato.PrecisaRenomearCapa(string.Empty));
            Assert.False(TrocaDeFormato.PrecisaRenomearCapa(null));
        }
    }
}

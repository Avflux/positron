using System.Collections.Generic;
using Positron.Data.Correcoes;
using Positron.Data.Modelos;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// O <c>CorrigeModelosDeContatos</c> (frente 2 do §7.6): a regra que acha os
    /// contatos do <c>CONTATOS</c> fora da posição e o índice novo de cada um.
    /// </summary>
    public class CorrecaoModeloDeContatoTests
    {
        [Fact]
        public void Contato_na_posicao_nao_gera_ajuste()
        {
            Assert.Empty(CorrecaoModeloDeContato.Planejar(53, Contatos(1, 2, 3)));
            Assert.Empty(CorrecaoModeloDeContato.Planejar(53, Contatos()));
            Assert.Empty(CorrecaoModeloDeContato.Planejar(53, null));
        }

        [Fact]
        public void Contato_fora_da_posicao_gera_ajuste()
        {
            // A lista (5, 2, 9): o primeiro vira 1 e o terceiro vira 3; o do meio já está.
            IReadOnlyList<AjusteDeContato> ajustes = CorrecaoModeloDeContato.Planejar(53, Contatos(5, 2, 9));

            Assert.Equal(2, ajustes.Count);
            Assert.Equal(53, ajustes[0].IndiceModelo);
            Assert.Equal(5, ajustes[0].IndiceContato);
            Assert.Equal(1, ajustes[0].IndiceContatoNovo);
            Assert.Equal(9, ajustes[1].IndiceContato);
            Assert.Equal(3, ajustes[1].IndiceContatoNovo);
        }

        [Fact]
        public void Um_contato_so_deslocado_vira_o_primeiro()
        {
            IReadOnlyList<AjusteDeContato> ajustes = CorrecaoModeloDeContato.Planejar(9, Contatos(7));

            Assert.Single(ajustes);
            Assert.Equal(7, ajustes[0].IndiceContato);
            Assert.Equal(1, ajustes[0].IndiceContatoNovo);
        }

        [Fact]
        public void ContatoNovo_acha_o_par_e_o_indice_novo()
        {
            IReadOnlyList<AjusteDeContato> ajustes = CorrecaoModeloDeContato.Planejar(53, Contatos(5, 2, 9));

            Assert.Equal(1, CorrecaoModeloDeContato.ContatoNovo(ajustes, 53, 5));
            Assert.Equal(3, CorrecaoModeloDeContato.ContatoNovo(ajustes, 53, 9));

            // O contato que já estava na posição não tem ajuste; outro modelo, idem.
            Assert.Equal(-1, CorrecaoModeloDeContato.ContatoNovo(ajustes, 53, 2));
            Assert.Equal(-1, CorrecaoModeloDeContato.ContatoNovo(ajustes, 49, 5));
            Assert.Equal(-1, CorrecaoModeloDeContato.ContatoNovo(null, 53, 5));
        }

        private static List<ContatoAuxiliar> Contatos(params int[] indices)
        {
            List<ContatoAuxiliar> contatos = new List<ContatoAuxiliar>();
            foreach (int indice in indices)
            {
                contatos.Add(new ContatoAuxiliar { Indice = indice, T1 = "T1", Tipo = "NA" });
            }

            return contatos;
        }
    }
}

using System.Collections.Generic;
using Positron.Data.Correcoes;
using Positron.Data.Fiacao;
using Positron.Data.Modelos;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// A renumeração dos contatos no dicionário (a pendência da rodada 86): pelos
    /// registros crus, preservando todo o resto do registro.
    /// </summary>
    public class RenumeracaoDeContatosTests
    {
        [Fact]
        public void Contatos_fora_da_posicao_sao_renumerados()
        {
            List<ModelosContato.ContatoBruto> brutos = Brutos(7, 9);

            bool mudou;
            IReadOnlyList<ModelosContato.ContatoBruto> saida = CorrecaoModeloDeContato.Renumerar(brutos, out mudou);

            Assert.True(mudou);
            Assert.Equal(2, saida.Count);
            Assert.Equal(1, Indice(saida[0]));
            Assert.Equal(2, Indice(saida[1]));

            // O resto do registro vai junto, inclusive os terminais e a orientação crua.
            Assert.Equal("T1A", saida[0].Valores[1].Valor);
            Assert.Equal("H", saida[0].Valores[6].Valor);
        }

        [Fact]
        public void Contatos_na_posicao_nao_mudam()
        {
            bool mudou;
            IReadOnlyList<ModelosContato.ContatoBruto> saida = CorrecaoModeloDeContato.Renumerar(Brutos(1, 2), out mudou);

            Assert.False(mudou);
            Assert.Equal(2, saida.Count);
        }

        [Fact]
        public void A_ida_e_a_volta_dos_registros_crus()
        {
            List<ModelosContato.ContatoBruto> brutos = Brutos(7, 9);
            IReadOnlyList<TypedXData> valores = ModelosContato.ParaValoresBrutos(2, brutos);

            // Cabeçalho (90, 2) + 8 por contato.
            Assert.Equal(17, valores.Count);
            Assert.Equal(90, valores[0].Codigo);
            Assert.Equal(2, valores[0].Valor);

            IReadOnlyList<ModelosContato.ContatoBruto> lidos = ModelosContato.LerAuxiliaresBrutos(valores);
            Assert.Equal(2, lidos.Count);
            Assert.Equal(7, Indice(lidos[0]));
            Assert.Equal(9, Indice(lidos[1]));
            Assert.Equal("T1A", lidos[0].Valores[1].Valor);
        }

        private static int Indice(ModelosContato.ContatoBruto contato)
        {
            return XDataNumero.Inteiro(contato.Valores[0].Valor);
        }

        private static List<ModelosContato.ContatoBruto> Brutos(params int[] indices)
        {
            List<ModelosContato.ContatoBruto> brutos = new List<ModelosContato.ContatoBruto>();
            foreach (int indice in indices)
            {
                brutos.Add(new ModelosContato.ContatoBruto
                {
                    Valores = new List<TypedXData>
                    {
                        new TypedXData(90, indice),
                        new TypedXData(1, "T1A"),
                        new TypedXData(1, "T2A"),
                        new TypedXData(1, "T3A"),
                        new TypedXData(90, 1),
                        new TypedXData(1, "CP"),
                        new TypedXData(1, "H"),
                        new TypedXData(1, ""),
                    },
                });
            }

            return brutos;
        }
    }
}

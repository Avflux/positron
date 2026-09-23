using System;
using System.Collections.Generic;
using Positron.Data.Correcoes;
using Positron.Data.Fiacao;
using Positron.Data.Modelos;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// O <c>corrigeDicMascaras</c> (frente 2 do §7.6): a regra do
    /// <see cref="CorrecaoPortasDaMascara"/> e o escritor do XRecord das portas
    /// (<see cref="ModelosMascara.ParaValores"/>), o avesso do <c>LerPortas</c>.
    /// </summary>
    public class CorrecaoPortasDaMascaraTests
    {
        // ── A regra ───────────────────────────────────────────────────────────

        [Fact]
        public void A_porta_repetida_sai_e_fica_a_primeira()
        {
            // O `List.Contains` do original mantém a **primeira** ocorrência: a
            // terceira porta (índice 3) é a que traz o Terminais diferente.
            List<ModeloPorta> portas = new List<ModeloPorta>
            {
                Porta(3, terminais: "PRIMEIRA"),
                Porta(1),
                Porta(3, terminais: "SEGUNDA"),
            };

            CorrecaoPortasDaMascara.Resultado plano = CorrecaoPortasDaMascara.Planejar(portas);

            Assert.Equal(1, plano.Removidas);
            Assert.Collection(
                plano.Portas,
                p => Assert.Equal(1, p.IndiceDaPorta),
                p =>
                {
                    Assert.Equal(3, p.IndiceDaPorta);
                    Assert.Equal("PRIMEIRA", p.Terminais);
                });
        }

        [Fact]
        public void Ordena_por_indice_crescente()
        {
            CorrecaoPortasDaMascara.Resultado plano = CorrecaoPortasDaMascara.Planejar(new List<ModeloPorta>
            {
                Porta(3),
                Porta(1),
                Porta(2),
            });

            Assert.Collection(
                plano.Portas,
                p => Assert.Equal(1, p.IndiceDaPorta),
                p => Assert.Equal(2, p.IndiceDaPorta),
                p => Assert.Equal(3, p.IndiceDaPorta));
        }

        [Fact]
        public void O_MaxIndice_e_o_maior_indice_mantido()
        {
            // O cabeçalho é **recalculado** (o original não lê o antigo): vale o
            // maior índice que sobrou, não o que estava gravado.
            CorrecaoPortasDaMascara.Resultado plano = CorrecaoPortasDaMascara.Planejar(new List<ModeloPorta>
            {
                Porta(1),
                Porta(5),
                Porta(5),
                Porta(2),
            });

            Assert.Equal(5, plano.MaxIndice);
            Assert.Equal(1, plano.Removidas);
            Assert.Equal(3, plano.Portas.Count);
        }

        [Fact]
        public void Sem_portas_o_MaxIndice_e_zero()
        {
            Assert.Equal(0, CorrecaoPortasDaMascara.Planejar(new List<ModeloPorta>()).MaxIndice);
            Assert.Equal(0, CorrecaoPortasDaMascara.Planejar(null).MaxIndice);
            Assert.Empty(CorrecaoPortasDaMascara.Planejar(null).Portas);
        }

        [Fact]
        public void Uma_porta_so_fica_como_esta()
        {
            CorrecaoPortasDaMascara.Resultado plano = CorrecaoPortasDaMascara.Planejar(
                new List<ModeloPorta> { Porta(7) });

            Assert.Single(plano.Portas);
            Assert.Equal(7, plano.MaxIndice);
            Assert.Equal(0, plano.Removidas);
        }

        // ── O escritor ────────────────────────────────────────────────────────

        [Fact]
        public void O_escritor_monta_o_layout_de_8_valores()
        {
            IReadOnlyList<TypedXData> valores = ModelosMascara.ParaValores(3, new List<ModeloPorta>
            {
                new ModeloPorta
                {
                    IndiceDaPorta = 1,
                    Orientacao = "h",
                    EFC = "E1",
                    Terminais = "1;3",
                    Bornes = "B1",
                    Regua = "R1",
                },
            });

            // Cabeçalho + 8 valores por porta (o +5 e o +7 saem vazios, como no
            // `GravaAsPortasDoModeloDoDicionario`).
            Assert.Equal(9, valores.Count);
            Assert.Equal(90, valores[0].Codigo);
            Assert.Equal("3", Texto(valores[0].Valor));
            Assert.Equal(90, valores[1].Codigo);
            Assert.Equal("1", Texto(valores[1].Valor));
            Assert.Equal("H", Texto(valores[2].Valor));
            Assert.Equal("E1", Texto(valores[3].Valor));
            Assert.Equal("1;3", Texto(valores[4].Valor));
            Assert.Equal("B1", Texto(valores[5].Valor));
            Assert.Equal(string.Empty, Texto(valores[6].Valor));
            Assert.Equal("R1", Texto(valores[7].Valor));
            Assert.Equal(string.Empty, Texto(valores[8].Valor));
        }

        [Fact]
        public void O_escritor_zera_o_que_vem_nulo()
        {
            IReadOnlyList<TypedXData> valores = ModelosMascara.ParaValores(0, new List<ModeloPorta>
            {
                new ModeloPorta { IndiceDaPorta = 2 },
            });

            Assert.Equal(string.Empty, Texto(valores[2].Valor));
            Assert.Equal(string.Empty, Texto(valores[8].Valor));
        }

        [Fact]
        public void O_que_o_escritor_grava_o_leitor_le_de_volta()
        {
            // O caminho do corrigeDicMascaras: planeja, grava e relê. A orientação
            // volta **em maiúsculas** (o `ToUpper` do gravador).
            CorrecaoPortasDaMascara.Resultado plano = CorrecaoPortasDaMascara.Planejar(new List<ModeloPorta>
            {
                Porta(3),
                Porta(1),
                Porta(3),
            });

            List<ModeloPorta> lidas = ModelosMascara.LerPortas(
                ModelosMascara.ParaValores(plano.MaxIndice, plano.Portas), 900, "M900");

            Assert.Collection(
                lidas,
                p =>
                {
                    Assert.Equal(1, p.IndiceDaPorta);
                    Assert.Equal(900, p.IndiceModelo);
                    Assert.Equal("M900", p.NomeModelo);
                },
                p => Assert.Equal(3, p.IndiceDaPorta));
        }

        // ── Montagem ──────────────────────────────────────────────────────────

        private static ModeloPorta Porta(int indice, string terminais = null)
        {
            return new ModeloPorta
            {
                IndiceDaPorta = indice,
                Orientacao = "h",
                EFC = "",
                Terminais = terminais ?? "",
                Bornes = "",
                Regua = "",
            };
        }

        private static string Texto(object valor)
        {
            return valor == null || valor is DBNull ? string.Empty : Convert.ToString(valor);
        }
    }
}

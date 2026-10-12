using System.Collections.Generic;
using Positron.Data.Interligacao;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// A correção `CorrigeInterligacao` do original (`clsUtilitarios.cs:611`): o que é puro
    /// é a decisão de **qual par de painéis regravar** em cada trecho indefinido, dado o painel que o
    /// adapter achou sobre cada ponta. Cada ramo do original tem um teste — inclusive a divergência
    /// deliberada (não gravar zero quando não há dispositivo na ponta).
    /// </summary>
    public class CorrecaoInterligacaoTests
    {
        private static CorrecaoInterligacao.Ponta Achou(short painel)
        {
            return new CorrecaoInterligacao.Ponta(painel, true);
        }

        private static CorrecaoInterligacao.Trecho Trecho(
            short tipo,
            short painel1,
            short painel2,
            CorrecaoInterligacao.Ponta ponta1,
            CorrecaoInterligacao.Ponta ponta2,
            bool indefinido = true)
        {
            return CorrecaoInterligacao.Trecho.De(tipo, indefinido, painel1, painel2, ponta1, ponta2);
        }

        // ── Tipo 1: as duas pontas ────────────────────────────────────────────

        [Fact]
        public void Tipo1_com_o_par_certo_em_qualquer_ordem_nao_corrige()
        {
            // O `if` aninhado do decompilado é redundante: as duas condições internas são a
            // negação da mesma comparação (o par em qualquer ordem).
            CorrecaoInterligacao.Plano plano = CorrecaoInterligacao.Planejar(new List<CorrecaoInterligacao.Trecho>
            {
                Trecho(1, 9, 503, Achou(9), Achou(503)),
                Trecho(1, 503, 9, Achou(9), Achou(503)),
            });

            Assert.Empty(plano.Correcoes);
            Assert.Equal(0, plano.SemDispositivo);
        }

        [Fact]
        public void Tipo1_com_o_par_trocado_grava_o_achado_na_ordem_das_pontas()
        {
            CorrecaoInterligacao.Plano plano = CorrecaoInterligacao.Planejar(new List<CorrecaoInterligacao.Trecho>
            {
                Trecho(1, 1, 2, Achou(503), Achou(9)),
            });

            CorrecaoInterligacao.Correcao correcao = Assert.Single(plano.Correcoes);
            Assert.Equal(0, correcao.Indice);
            Assert.Equal(503, correcao.Painel1);
            Assert.Equal(9, correcao.Painel2);
        }

        [Fact]
        public void Tipo1_sem_dispositivo_numa_ponta_e_pulado_e_contado()
        {
            // Divergência deliberada: o original gravaria `Painel2 = 0` (apagando o 7).
            CorrecaoInterligacao.Plano plano = CorrecaoInterligacao.Planejar(new List<CorrecaoInterligacao.Trecho>
            {
                Trecho(1, 5, 7, Achou(5), CorrecaoInterligacao.Ponta.NaoEncontrada),
            });

            Assert.Empty(plano.Correcoes);
            Assert.Equal(1, plano.SemDispositivo);
        }

        [Fact]
        public void Tipo1_com_painel_zerado_nos_dois_campos_grava_o_achado()
        {
            CorrecaoInterligacao.Plano plano = CorrecaoInterligacao.Planejar(new List<CorrecaoInterligacao.Trecho>
            {
                Trecho(1, 0, 0, Achou(503), Achou(9)),
            });

            CorrecaoInterligacao.Correcao correcao = Assert.Single(plano.Correcoes);
            Assert.Equal(503, correcao.Painel1);
            Assert.Equal(9, correcao.Painel2);
        }

        // ── Tipo 2 e 3: uma ponta ─────────────────────────────────────────────

        [Fact]
        public void Tipo2_com_Painel1_zerado_grava_o_achado_no_Painel2()
        {
            CorrecaoInterligacao.Plano plano = CorrecaoInterligacao.Planejar(new List<CorrecaoInterligacao.Trecho>
            {
                Trecho(2, 0, 77, Achou(9), CorrecaoInterligacao.Ponta.NaoEncontrada),
            });

            CorrecaoInterligacao.Correcao correcao = Assert.Single(plano.Correcoes);
            Assert.Equal(0, correcao.Painel1);
            Assert.Equal(9, correcao.Painel2);
        }

        [Fact]
        public void Tipo2_com_Painel1_zerado_e_o_Painel2_ja_certo_nao_corrige()
        {
            CorrecaoInterligacao.Plano plano = CorrecaoInterligacao.Planejar(new List<CorrecaoInterligacao.Trecho>
            {
                Trecho(2, 0, 9, Achou(9), CorrecaoInterligacao.Ponta.NaoEncontrada),
            });

            Assert.Empty(plano.Correcoes);
        }

        [Fact]
        public void Tipo2_com_Painel1_preenchido_grava_o_achado_no_Painel1()
        {
            CorrecaoInterligacao.Plano plano = CorrecaoInterligacao.Planejar(new List<CorrecaoInterligacao.Trecho>
            {
                Trecho(2, 5, 0, Achou(9), CorrecaoInterligacao.Ponta.NaoEncontrada),
            });

            CorrecaoInterligacao.Correcao correcao = Assert.Single(plano.Correcoes);
            Assert.Equal(9, correcao.Painel1);
            Assert.Equal(0, correcao.Painel2);
        }

        [Fact]
        public void Tipo3_usa_a_segunda_ponta_quando_a_primeira_nao_tem_dispositivo()
        {
            CorrecaoInterligacao.Plano plano = CorrecaoInterligacao.Planejar(new List<CorrecaoInterligacao.Trecho>
            {
                Trecho(3, 0, 77, CorrecaoInterligacao.Ponta.NaoEncontrada, Achou(9)),
            });

            CorrecaoInterligacao.Correcao correcao = Assert.Single(plano.Correcoes);
            Assert.Equal(9, correcao.Painel2);
        }

        [Fact]
        public void Tipo2_sem_dispositivo_nas_pontas_e_pulado_e_contado()
        {
            // Divergência deliberada: com o achado em 0 o original zeraria o `Painel2` (77).
            CorrecaoInterligacao.Plano plano = CorrecaoInterligacao.Planejar(new List<CorrecaoInterligacao.Trecho>
            {
                Trecho(2, 0, 77, CorrecaoInterligacao.Ponta.NaoEncontrada, CorrecaoInterligacao.Ponta.NaoEncontrada),
            });

            Assert.Empty(plano.Correcoes);
            Assert.Equal(1, plano.SemDispositivo);
        }

        // ── O que fica de fora ────────────────────────────────────────────────

        [Fact]
        public void Trecho_com_cabo_definido_nao_entra()
        {
            // Só `NumVeia == -1000` (o estado que o INDCABO deixa) participa.
            CorrecaoInterligacao.Plano plano = CorrecaoInterligacao.Planejar(new List<CorrecaoInterligacao.Trecho>
            {
                Trecho(1, 1, 2, Achou(503), Achou(9), indefinido: false),
            });

            Assert.Empty(plano.Correcoes);
            Assert.Equal(0, plano.SemDispositivo);
        }

        [Fact]
        public void Tipo_desconhecido_nao_entra()
        {
            CorrecaoInterligacao.Plano plano = CorrecaoInterligacao.Planejar(new List<CorrecaoInterligacao.Trecho>
            {
                Trecho(4, 1, 2, Achou(503), Achou(9)),
            });

            Assert.Empty(plano.Correcoes);
        }

        [Fact]
        public void Lista_nula_devolve_plano_vazio()
        {
            CorrecaoInterligacao.Plano plano = CorrecaoInterligacao.Planejar(null);

            Assert.Empty(plano.Correcoes);
            Assert.Equal(0, plano.SemDispositivo);
        }

        [Fact]
        public void Trecho_nulo_e_ignorado()
        {
            CorrecaoInterligacao.Plano plano = CorrecaoInterligacao.Planejar(new List<CorrecaoInterligacao.Trecho>
            {
                null,
                Trecho(1, 1, 2, Achou(503), Achou(9)),
            });

            CorrecaoInterligacao.Correcao correcao = Assert.Single(plano.Correcoes);
            Assert.Equal(1, correcao.Indice);
        }

        [Fact]
        public void Cada_correcao_leva_o_indice_do_trecho_como_ele_veio()
        {
            CorrecaoInterligacao.Plano plano = CorrecaoInterligacao.Planejar(new List<CorrecaoInterligacao.Trecho>
            {
                Trecho(1, 1, 2, Achou(503), Achou(9)),
                Trecho(2, 0, 77, Achou(9), CorrecaoInterligacao.Ponta.NaoEncontrada),
            });

            Assert.Equal(2, plano.Correcoes.Count);
            Assert.Equal(0, plano.Correcoes[0].Indice);
            Assert.Equal(1, plano.Correcoes[1].Indice);
        }
    }
}

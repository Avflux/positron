using System.Collections.Generic;
using Positron.Data.Bornes;
using Positron.Data.Correcoes;
using Positron.Data.Fiacao;
using Positron.Data.Modelos;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// A subida do <c>lm</c> dos bornes: de onde o valor sai
    /// (<see cref="LmDasReguas"/>) e quem entra (<see cref="CorrecaoLmBornes"/>).
    /// O <c>lm</c> que o original lê (<c>+6</c>/<c>+7</c> do <c>REGUAS/MODELOS2</c>)
    /// **nunca é gravado** — o dicionário de bornes da régua é a fonte de verdade
    /// (medido no desenho real, rodada 74).
    /// </summary>
    public class CorrecaoLmBornesTests
    {
        // ── De onde o lm da régua sai ─────────────────────────────────────────

        [Fact]
        public void O_MODELOS2_tem_a_precedencia()
        {
            // O campo do original (+6 = tipo 0) definido vence, mesmo com o
            // dicionário de bornes por perto.
            ReguasModelo reguas = Reguas(new int[] { 37 }, 45, 46);
            List<BorneReserva> doDicionario = Reservas((0, 476));

            Assert.Equal(45, LmDasReguas.Resolver(reguas, 37, doDicionario, 0));
            Assert.Equal(46, LmDasReguas.Resolver(reguas, 37, doDicionario, 1));
        }

        [Fact]
        public void Sem_lm_no_MODELOS2_o_valor_vem_do_dicionario_de_bornes()
        {
            // O que o desenho real mostra: +6/+7 zerados (o gravador escreve 0) e
            // o lm de verdade no borne de reserva da régua (39 → tipo 0 → 496).
            ReguasModelo reguas = Reguas(new int[] { 39 }, 0, 0);
            List<BorneReserva> doDicionario = Reservas((0, 496));

            Assert.Equal(496, LmDasReguas.Resolver(reguas, 39, doDicionario, 0));
        }

        [Fact]
        public void O_dicionario_casa_o_tipo_do_borne()
        {
            // O borne de reserva define o lm do **tipo dele**: um borne de tipo 0
            // não pega o lm de um borne de tipo 1.
            ReguasModelo reguas = new ReguasModelo();
            List<BorneReserva> doDicionario = Reservas((1, 476));

            Assert.Equal(0, LmDasReguas.Resolver(reguas, 225, doDicionario, 0));
            Assert.Equal(476, LmDasReguas.Resolver(reguas, 225, doDicionario, 1));
        }

        [Fact]
        public void O_primeiro_lm_nao_zerado_do_tipo_vale()
        {
            ReguasModelo reguas = new ReguasModelo();
            List<BorneReserva> doDicionario = Reservas((0, 0), (0, 476), (0, 480));

            Assert.Equal(476, LmDasReguas.Resolver(reguas, 478, doDicionario, 0));
        }

        [Fact]
        public void Regua_sem_registro_no_dicionario_nao_define()
        {
            Assert.Equal(0, LmDasReguas.Resolver(new ReguasModelo(), 999, null, 0));
            Assert.Equal(0, LmDasReguas.Resolver(null, 999, new List<BorneReserva>(), 0));
        }

        [Fact]
        public void O_dicionario_lido_do_xrecord_da_regua_alimenta_a_resolucao()
        {
            // O registro é lido pelo leitor do `CENG_BORNES` (10 valores, +4 =
            // tipo e +5 = lm), no layout medido: `(0) ("41") ("") (41.0) (0) (496)
            // (true) ("") ("") ("")`.
            List<TypedXData> registro = new List<TypedXData>
            {
                new TypedXData(90, 0),
                new TypedXData(1, "41"),
                new TypedXData(1, string.Empty),
                new TypedXData(40, 41.0),
                new TypedXData(90, 0),
                new TypedXData(90, 496),
                new TypedXData(290, true),
                new TypedXData(1, string.Empty),
                new TypedXData(1, string.Empty),
                new TypedXData(1, string.Empty),
            };

            List<BorneReserva> doDicionario = BornesReserva.Ler(registro);

            Assert.Equal(496, LmDasReguas.Resolver(new ReguasModelo(), 39, doDicionario, 0));
        }

        // ── Quem entra na correção ────────────────────────────────────────────

        [Fact]
        public void So_entra_o_borne_zerado()
        {
            List<BorneDeLm> bornes = new List<BorneDeLm>
            {
                new BorneDeLm { Handle = "A", IndiceRegua = 39, Tipo = 0, Lm = 0 },
                new BorneDeLm { Handle = "B", IndiceRegua = 39, Tipo = 0, Lm = 496 },
            };

            IReadOnlyList<CorrecaoLmBornes.Ajuste> ajustes = CorrecaoLmBornes.Planejar(bornes, (regua, tipo) => 496);

            Assert.Collection(
                ajustes,
                a =>
                {
                    Assert.Equal("A", a.Handle);
                    Assert.Equal(496, a.Lm);
                    Assert.Equal(0, a.Tipo);
                });
        }

        [Fact]
        public void Quem_a_regua_nao_define_fica_como_esta()
        {
            // Sem definição para o tipo é **dado faltando no desenho**, não regra: o
            // borne continua no `BorneSemLm` do VERIF.
            List<BorneDeLm> bornes = new List<BorneDeLm>
            {
                new BorneDeLm { Handle = "A", IndiceRegua = 39, Tipo = 0, Lm = 0 },
                new BorneDeLm { Handle = "B", IndiceRegua = 44, Tipo = 1, Lm = 0 },
            };

            IReadOnlyList<CorrecaoLmBornes.Ajuste> ajustes =
                CorrecaoLmBornes.Planejar(bornes, (regua, tipo) => tipo == 0 ? 496 : 0);

            Assert.Collection(ajustes, a => Assert.Equal("A", a.Handle));
        }

        [Fact]
        public void Cada_borne_pega_o_lm_do_seu_tipo()
        {
            List<BorneDeLm> bornes = new List<BorneDeLm>
            {
                new BorneDeLm { Handle = "A", IndiceRegua = 37, Tipo = 0, Lm = 0 },
                new BorneDeLm { Handle = "B", IndiceRegua = 37, Tipo = 1, Lm = 0 },
                new BorneDeLm { Handle = "C", IndiceRegua = 37, Tipo = 2, Lm = 0 },
            };

            IReadOnlyList<CorrecaoLmBornes.Ajuste> ajustes =
                CorrecaoLmBornes.Planejar(bornes, (regua, tipo) => LmDasReguas.Resolver(Reguas(new[] { 37 }, 45, 46), regua, null, tipo));

            Assert.Collection(
                ajustes,
                a => Assert.Equal(45, a.Lm),
                a => Assert.Equal(46, a.Lm));
        }

        [Fact]
        public void Sem_borne_ou_sem_resolvedor_nao_ha_ajuste()
        {
            Assert.Empty(CorrecaoLmBornes.Planejar(null, (regua, tipo) => 1));
            Assert.Empty(CorrecaoLmBornes.Planejar(new List<BorneDeLm>(), null));
            Assert.Empty(CorrecaoLmBornes.Planejar(
                new List<BorneDeLm> { new BorneDeLm { Lm = 1 } },
                (regua, tipo) => 1));
        }

        [Fact]
        public void O_lm_subido_volta_pelo_leitor_do_xdata()
        {
            // O que o adapter grava é o mesmo XData do `GravarXDataDispBorne`; o
            // `FIA` relê o desenho depois da correção.
            BorneXData borne = new BorneXData { Numero = "41", Ordem = 41, IndiceRegua = 39, Lm = 0, Tipo = 0 };

            IReadOnlyList<CorrecaoLmBornes.Ajuste> ajustes = CorrecaoLmBornes.Planejar(
                new List<BorneDeLm> { new BorneDeLm { Handle = "A", IndiceRegua = 39, Tipo = 0, Lm = 0 } },
                (regua, tipo) => 496);

            borne.Lm = ajustes[0].Lm;

            BorneXData lido;
            Assert.True(BorneXData.Ler(borne.ParaValores("ana", "2026-09-23"), out lido));
            Assert.Equal(496, lido.Lm);
        }

        // ── Montagem ──────────────────────────────────────────────────────────

        /// <summary>O <c>MODELOS2</c> com uma régua só: cabeçalho + registro de 10 valores.</summary>
        private static ReguasModelo Reguas(int[] indices, int lmTipo0, int lmTipo1)
        {
            List<TypedXData> valores = new List<TypedXData> { new TypedXData(90, indices.Length) };
            foreach (int indice in indices)
            {
                valores.Add(new TypedXData(90, indice));
                valores.Add(new TypedXData(1, "R" + indice));
                valores.Add(new TypedXData(1, string.Empty));
                valores.Add(new TypedXData(90, 9));
                valores.Add(new TypedXData(90, 0));
                valores.Add(new TypedXData(90, 0));
                valores.Add(new TypedXData(90, lmTipo0));
                valores.Add(new TypedXData(90, lmTipo1));
                valores.Add(new TypedXData(90, 0));
                valores.Add(new TypedXData(1, string.Empty));
            }

            return ReguasModelo.Ler(valores);
        }

        private static List<BorneReserva> Reservas(params (int Tipo, int Lm)[] lm)
        {
            List<BorneReserva> bornes = new List<BorneReserva>();
            for (int i = 0; i < lm.Length; i++)
            {
                bornes.Add(new BorneReserva { Numero = (i + 41).ToString(), Tipo = lm[i].Tipo, Lm = lm[i].Lm, Reserva = true });
            }

            return bornes;
        }
    }
}

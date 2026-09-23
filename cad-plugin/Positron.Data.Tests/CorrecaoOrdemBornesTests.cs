using System.Collections.Generic;
using Positron.Data.Bornes;
using Positron.Data.Correcoes;
using Positron.Data.Fiacao;
using Positron.Data.Modelos;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// A regra do <c>corrigeOrdemBornes</c> (frente 2 do §7.6): a ordenação por
    /// régua/ordem, a renumeração 1..N e o pulo das ordens reservadas — mais o
    /// escritor do XData do borne, que a regravação usa.
    /// </summary>
    public class CorrecaoOrdemBornesTests
    {
        private static readonly IReadOnlyList<int> SemReservas = new List<int>();

        private static BorneDeOrdem Borne(string handle, int regua, double ordem)
        {
            return new BorneDeOrdem { Handle = handle, IndiceRegua = regua, Ordem = ordem };
        }

        // ── Renumeração ───────────────────────────────────────────────────────

        [Fact]
        public void Ordem_ja_correta_nao_gera_ajuste()
        {
            List<BorneDeOrdem> bornes = new List<BorneDeOrdem>
            {
                Borne("A", 1, 1),
                Borne("B", 1, 2),
                Borne("C", 2, 1),
            };

            Assert.Empty(CorrecaoOrdemBornes.Planejar(bornes, _ => SemReservas));
        }

        [Fact]
        public void Ordem_fora_de_sequencia_e_renumerada_por_regua()
        {
            // Régua 1: 1, 3, 7 -> 1, 2, 3. Régua 2 começa de novo em 1.
            List<BorneDeOrdem> bornes = new List<BorneDeOrdem>
            {
                Borne("A", 1, 1),
                Borne("B", 1, 3),
                Borne("C", 1, 7),
                Borne("D", 2, 1),
                Borne("E", 2, 9),
            };

            IReadOnlyList<CorrecaoOrdemBornes.Ajuste> ajustes = CorrecaoOrdemBornes.Planejar(bornes, _ => SemReservas);

            Assert.Collection(
                ajustes,
                a => { Assert.Equal("B", a.Handle); Assert.Equal(3, a.OrdemAntiga); Assert.Equal(2, a.OrdemNova); },
                a => { Assert.Equal("C", a.Handle); Assert.Equal(7, a.OrdemAntiga); Assert.Equal(3, a.OrdemNova); },
                a => { Assert.Equal("E", a.Handle); Assert.Equal(9, a.OrdemAntiga); Assert.Equal(2, a.OrdemNova); });
        }

        [Fact]
        public void Ordens_repetidas_sao_separadas()
        {
            // Três bornes com a ordem 2 na mesma régua: o original renumera os três
            // (1, 2, 3) e só o do meio fica com o valor que já tinha.
            List<BorneDeOrdem> bornes = new List<BorneDeOrdem>
            {
                Borne("A", 1, 2),
                Borne("B", 1, 2),
                Borne("C", 1, 2),
            };

            IReadOnlyList<CorrecaoOrdemBornes.Ajuste> ajustes = CorrecaoOrdemBornes.Planejar(bornes, _ => SemReservas);

            Assert.Collection(
                ajustes,
                a => { Assert.Equal("A", a.Handle); Assert.Equal(1, a.OrdemNova); },
                a => { Assert.Equal("C", a.Handle); Assert.Equal(3, a.OrdemNova); });
        }

        [Fact]
        public void Reguas_desordenadas_saem_na_ordem_da_regua()
        {
            // A lista vem na ordem do ModelSpace: réguas e ordens trocadas. O
            // original ordena antes de renumerar, então o ajuste sai na ordem nova.
            List<BorneDeOrdem> bornes = new List<BorneDeOrdem>
            {
                Borne("A", 2, 5),
                Borne("B", 1, 9),
                Borne("C", 1, 4),
            };

            IReadOnlyList<CorrecaoOrdemBornes.Ajuste> ajustes = CorrecaoOrdemBornes.Planejar(bornes, _ => SemReservas);

            Assert.Collection(
                ajustes,
                a => { Assert.Equal("C", a.Handle); Assert.Equal(4, a.OrdemAntiga); Assert.Equal(1, a.OrdemNova); },
                a => { Assert.Equal("B", a.Handle); Assert.Equal(9, a.OrdemAntiga); Assert.Equal(2, a.OrdemNova); },
                a => { Assert.Equal("A", a.Handle); Assert.Equal(5, a.OrdemAntiga); Assert.Equal(1, a.OrdemNova); });
        }

        // ── Reservas ──────────────────────────────────────────────────────────

        [Fact]
        public void Ordem_reservada_e_pulada()
        {
            // Régua 5 com a ordem 2 reservada: os bornes do desenho saem 1, 3, 4.
            List<BorneDeOrdem> bornes = new List<BorneDeOrdem>
            {
                Borne("A", 5, 1),
                Borne("B", 5, 2),
                Borne("C", 5, 3),
            };

            IReadOnlyList<CorrecaoOrdemBornes.Ajuste> ajustes =
                CorrecaoOrdemBornes.Planejar(bornes, _ => new List<int> { 2 });

            Assert.Collection(
                ajustes,
                a => { Assert.Equal("B", a.Handle); Assert.Equal(3, a.OrdemNova); },
                a => { Assert.Equal("C", a.Handle); Assert.Equal(4, a.OrdemNova); });
        }

        [Fact]
        public void Reservas_valem_por_regua()
        {
            // A reserva 2 é da régua 5; a régua 6 (sem reserva) numera 1,2.
            List<BorneDeOrdem> bornes = new List<BorneDeOrdem>
            {
                Borne("A", 5, 1),
                Borne("B", 6, 1),
                Borne("C", 6, 2),
            };

            IReadOnlyList<CorrecaoOrdemBornes.Ajuste> ajustes = CorrecaoOrdemBornes.Planejar(
                bornes,
                regua => regua == 5 ? new List<int> { 2 } : SemReservas);

            Assert.Empty(ajustes);
        }

        [Fact]
        public void Reservas_consecutivas_empurram_a_numeracao()
        {
            // Régua 5 reserva 1 e 3: os bornes saem 2 e 4; a régua 6 começa do zero.
            List<BorneDeOrdem> bornes = new List<BorneDeOrdem>
            {
                Borne("A", 5, 9),
                Borne("B", 5, 9),
                Borne("C", 6, 2),
            };

            IReadOnlyList<CorrecaoOrdemBornes.Ajuste> ajustes = CorrecaoOrdemBornes.Planejar(
                bornes,
                regua => regua == 5 ? new List<int> { 1, 3 } : SemReservas);

            Assert.Collection(
                ajustes,
                a => { Assert.Equal("A", a.Handle); Assert.Equal(2, a.OrdemNova); },
                a => { Assert.Equal("B", a.Handle); Assert.Equal(4, a.OrdemNova); },
                a => { Assert.Equal("C", a.Handle); Assert.Equal(1, a.OrdemNova); });
        }

        // ── Casos de borda ────────────────────────────────────────────────────

        [Fact]
        public void Lista_vazia_nao_gera_ajuste()
        {
            Assert.Empty(CorrecaoOrdemBornes.Planejar(new List<BorneDeOrdem>(), _ => SemReservas));
            Assert.Empty(CorrecaoOrdemBornes.Planejar(null, _ => SemReservas));
        }

        [Fact]
        public void Um_borne_so_e_renumerado_para_1()
        {
            List<BorneDeOrdem> bornes = new List<BorneDeOrdem> { Borne("A", 7, 4) };

            IReadOnlyList<CorrecaoOrdemBornes.Ajuste> ajustes = CorrecaoOrdemBornes.Planejar(bornes, _ => SemReservas);

            Assert.Collection(ajustes, a => Assert.Equal(1, a.OrdemNova));
        }

        [Fact]
        public void Reserva_nula_e_tratada_como_sem_reserva()
        {
            List<BorneDeOrdem> bornes = new List<BorneDeOrdem> { Borne("A", 1, 5) };

            IReadOnlyList<CorrecaoOrdemBornes.Ajuste> ajustes = CorrecaoOrdemBornes.Planejar(bornes, _ => null);

            Assert.Collection(ajustes, a => Assert.Equal(1, a.OrdemNova));
        }

        // ── XData do borne (escrita) ──────────────────────────────────────────

        [Fact]
        public void Para_valores_reproduz_o_layout_de_18_valores()
        {
            BorneXData borne = new BorneXData
            {
                PosIntJumper = "J1",
                BlocoLayout = "LAY",
                Numero = "12",
                NumeroComplem = "A",
                Ordem = 3,
                IndiceRegua = 37,
                Conector = "C",
                Lm = 45,
                Orientacao = "H",
                Tipo = 0,
                Visivel = 1,
            };

            IReadOnlyList<TypedXData> valores = borne.ParaValores("ana", "2026-09-23");

            Assert.Equal(BorneXData.QuantidadeValores, valores.Count);
            Assert.Equal(1001, valores[0].Codigo);
            Assert.Equal(BorneXData.AppName, valores[0].Valor);
            Assert.Equal("B", valores[1].Valor);
            Assert.Equal(string.Empty, valores[2].Valor);
            Assert.Equal("J1", valores[3].Valor);
            Assert.Equal("LAY", valores[4].Valor);
            Assert.Equal("12A", valores[5].Valor);
            Assert.Equal(string.Empty, valores[6].Valor);
            Assert.Equal(1040, valores[7].Codigo);
            Assert.Equal(3.0, valores[7].Valor);
            Assert.Equal(1071, valores[8].Codigo);
            Assert.Equal(37, valores[8].Valor);
            Assert.Equal("45", valores[10].Valor);
            Assert.Equal(1040, valores[12].Codigo);
            Assert.Equal(1040, valores[13].Codigo);
            Assert.Equal(0, valores[14].Valor);
            Assert.Equal(1, valores[15].Valor);
            Assert.Equal("ana", valores[16].Valor);
            Assert.Equal("2026-09-23", valores[17].Valor);
        }

        [Fact]
        public void Para_valores_ida_e_volta_preserva_a_ordem()
        {
            // O que a correção grava tem que ser legível pelo mesmo leitor — o FIA
            // relê o desenho depois.
            BorneXData original = new BorneXData { Numero = "7", Ordem = 4, IndiceRegua = 9, Lm = 45, Tipo = 1 };

            BorneXData lido;
            Assert.True(BorneXData.Ler(original.ParaValores("ana", "2026-09-23"), out lido));

            Assert.Equal(4.0, lido.Ordem);
            Assert.Equal(9, lido.IndiceRegua);
            Assert.Equal(45, lido.Lm);
            Assert.Equal(1, lido.Tipo);
            Assert.Equal("7", lido.Numero);
            Assert.Equal("B", lido.TipoDispositivo);
        }

        // ── lm no dicionário de réguas ────────────────────────────────────────

        [Fact]
        public void Lm_da_regua_vem_do_tipo_do_borne()
        {
            // Layout do MODELOS2: cabeçalho + um registro de 10; +6 = lm do tipo 0,
            // +7 = lm do tipo 1 (o `BuscaLMdaRegua` do original).
            List<TypedXData> valores = new List<TypedXData> { new TypedXData(90, 1) };
            valores.Add(new TypedXData(90, 37));
            valores.Add(new TypedXData(1, "R6"));
            valores.Add(new TypedXData(1, string.Empty));
            valores.Add(new TypedXData(90, 9));
            valores.Add(new TypedXData(90, 0));
            valores.Add(new TypedXData(90, 0));
            valores.Add(new TypedXData(90, 45));
            valores.Add(new TypedXData(90, 46));
            valores.Add(new TypedXData(90, 0));
            valores.Add(new TypedXData(1, string.Empty));

            ReguasModelo reguas = ReguasModelo.Ler(valores);

            Assert.Equal(45, reguas.BuscarLm(37, 0));
            Assert.Equal(46, reguas.BuscarLm(37, 1));
            Assert.Equal(0, reguas.BuscarLm(37, 2));
            Assert.Equal(0, reguas.BuscarLm(99, 0));
        }

        // ── Ordens das reservas ───────────────────────────────────────────────

        [Fact]
        public void Ordens_reservadas_lidas_sem_filtro_de_tipo()
        {
            // Dois registros de 10 valores; o segundo tem `tipo` 3, que o
            // `LeDicBornesReserva` descartaria — o `LeOrdemDicBornesReserva` (o
            // usado aqui) não filtra.
            List<TypedXData> valores = new List<TypedXData>();
            for (int registro = 0; registro < 2; registro++)
            {
                for (int campo = 0; campo < 10; campo++)
                {
                    object valor = 0;
                    if (campo == 3)
                    {
                        valor = registro + 2;
                    }
                    else if (campo == 4)
                    {
                        valor = 3;
                    }

                    valores.Add(new TypedXData(90, valor));
                }
            }

            List<int> ordens = BornesReserva.OrdensReservadas(valores);

            Assert.Equal(new[] { 2, 3 }, ordens);
        }
    }
}

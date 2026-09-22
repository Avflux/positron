using System.Collections.Generic;
using Positron.Data.Fiacao;
using Positron.Data.Interligacao;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// A **ação** <c>IndefineCabosNaoExistentes</c> do verificador da interligação
    /// (o botão "Corrigir cabos"): o que é puro é a decisão de quais trechos
    /// indefinir (<see cref="AcaoIndefinirCabos.Planejar"/>), a transformação do
    /// XData (<see cref="InterligacaoXData.IndefinirCabo"/>) e a sua regravação
    /// (<see cref="InterligacaoXData.ParaValores"/>).
    /// </summary>
    public class IndefineCabosTests
    {
        private static InterligacaoXData Trecho()
        {
            return new InterligacaoXData
            {
                Tipo = 2,
                Tag_Cabo = "CABO1",
                NumVeia = 3,
                NomeVeia = "VEIA1",
                Painel1 = 2,
                Painel2 = 0,
                Handle = "H1",
                OcultaTag = 1,
                IndexModeloVeiaFuncao = 5,
                Usuario = "ana",
                Data = "2026-10-07",
            };
        }

        // ── Planejar ──────────────────────────────────────────────────────────

        [Fact]
        public void Catalogo_vazio_nao_planeja_nada()
        {
            // O `if (lCabos.Count <= 0) return;` do original: catálogo vazio é
            // ausência de dado, não "nenhum cabo existe" — sem a guarda a ação
            // apagaria a tag de todo trecho do desenho.
            IReadOnlyList<int> indices = AcaoIndefinirCabos.Planejar(
                new List<string> { "A", "B" },
                new List<string>());

            Assert.Empty(indices);
        }

        [Fact]
        public void Catalogo_nulo_nao_planeja_nada()
        {
            Assert.Empty(AcaoIndefinirCabos.Planejar(new List<string> { "A" }, null));
        }

        [Fact]
        public void Tag_fora_do_catalogo_e_planejada()
        {
            IReadOnlyList<int> indices = AcaoIndefinirCabos.Planejar(
                new List<string> { "A", "FANTASMA", "B" },
                new List<string> { "A", "B" });

            Assert.Equal(new[] { 1 }, indices);
        }

        [Fact]
        public void Tag_no_catalogo_nao_e_planejada()
        {
            IReadOnlyList<int> indices = AcaoIndefinirCabos.Planejar(
                new List<string> { "A", "B" },
                new List<string> { "A", "B" });

            Assert.Empty(indices);
        }

        [Fact]
        public void Comparacao_e_ordinal()
        {
            // O `List(Of String).Contains` do original é ordinal (sensível a caixa):
            // "cabo1" fora de um catálogo com "CABO1" é cabo inexistente. É diferente
            // da regra read-only `VerificarCabosSemCatalogo`, que tolera caixa.
            IReadOnlyList<int> indices = AcaoIndefinirCabos.Planejar(
                new List<string> { "cabo1" },
                new List<string> { "CABO1" });

            Assert.Equal(new[] { 0 }, indices);
        }

        [Fact]
        public void Tag_vazia_tambem_e_indefinida()
        {
            IReadOnlyList<int> indices = AcaoIndefinirCabos.Planejar(
                new List<string> { "", "A" },
                new List<string> { "A" });

            Assert.Equal(new[] { 0 }, indices);
        }

        [Fact]
        public void Preserva_a_ordem_dos_indices()
        {
            IReadOnlyList<int> indices = AcaoIndefinirCabos.Planejar(
                new List<string> { "X", "A", "Y", "B", "Z" },
                new List<string> { "A", "B" });

            Assert.Equal(new[] { 0, 2, 4 }, indices);
        }

        // ── IndefinirCabo ─────────────────────────────────────────────────────

        [Fact]
        public void Indefinir_cabo_zera_o_cabo_e_a_veia()
        {
            InterligacaoXData trecho = Trecho();
            trecho.IndefinirCabo();

            Assert.Equal(string.Empty, trecho.Tag_Cabo);
            Assert.Equal(InterligacaoXData.NumVeiaIndefinido, trecho.NumVeia);
            Assert.Equal(string.Empty, trecho.NomeVeia);
            Assert.Equal(0, trecho.OcultaTag);
        }

        [Fact]
        public void Indefinir_cabo_preserva_o_que_nao_e_do_cabo()
        {
            InterligacaoXData trecho = Trecho();
            trecho.IndefinirCabo();

            Assert.Equal((short)2, trecho.Tipo);
            Assert.Equal((short)2, trecho.Painel1);
            Assert.Equal((short)0, trecho.Painel2);
            Assert.Equal("H1", trecho.Handle);
            Assert.Equal(5, trecho.IndexModeloVeiaFuncao);
        }

        // ── ParaValores ───────────────────────────────────────────────────────

        [Fact]
        public void Para_valores_reproduz_o_layout_de_19_valores()
        {
            InterligacaoXData trecho = Trecho();
            IReadOnlyList<TypedXData> valores = trecho.ParaValores("joao", "2026-10-12");

            Assert.Equal(19, valores.Count);
            Assert.Equal(1001, valores[0].Codigo);
            Assert.Equal("INTERLIGACAO", valores[0].Valor);
            Assert.Equal((short)2, valores[1].Valor);
            Assert.Equal("CABO1", valores[2].Valor);
            Assert.Equal(3, valores[3].Valor);
            Assert.Equal("VEIA1", valores[4].Valor);
            Assert.Equal((short)2, valores[5].Valor);
            Assert.Equal(0, valores[6].Valor);
            Assert.Equal((short)0, valores[7].Valor);
            Assert.Equal("H1", valores[9].Valor);
            Assert.Equal(1, valores[12].Valor);
            Assert.Equal(5, valores[13].Valor);
            Assert.Equal("joao", valores[14].Valor);
            Assert.Equal("2026-10-12", valores[15].Valor);
            Assert.Equal(1071, valores[16].Codigo);
            Assert.Equal(1040, valores[17].Codigo);
        }

        [Fact]
        public void Para_valores_ida_e_volta()
        {
            // O que a ação grava tem que ser legível pelo mesmo leitor — o
            // `INT`/`VERIF` releem o XData depois.
            InterligacaoXData original = Trecho();
            original.IndefinirCabo();

            InterligacaoXData lido;
            Assert.True(InterligacaoXData.Ler(original.ParaValores("joao", "2026-10-12"), out lido));

            Assert.Equal(string.Empty, lido.Tag_Cabo);
            Assert.Equal(InterligacaoXData.NumVeiaIndefinido, lido.NumVeia);
            Assert.Equal(string.Empty, lido.NomeVeia);
            Assert.Equal(0, lido.OcultaTag);
            Assert.Equal("H1", lido.Handle);
        }

        // ── Rótulo auxiliar (AUXINTERLIG) ─────────────────────────────────────

        [Fact]
        public void Rotulo_do_cabo_e_o_tipo_1()
        {
            Assert.True(AcaoIndefinirCabos.RotuloEhDoCabo(1));
            Assert.False(AcaoIndefinirCabos.RotuloEhDoCabo(2));
            Assert.False(AcaoIndefinirCabos.RotuloEhDoCabo(0));
        }

        [Fact]
        public void Aux_interligacao_le_o_tipo()
        {
            List<TypedXData> valores = new List<TypedXData>
            {
                new TypedXData(1001, "AUXINTERLIG"),
                new TypedXData(1070, (short)1),
                new TypedXData(1000, "H1"),
                new TypedXData(1000, "H2"),
            };

            short tipo;
            Assert.True(AuxInterligacaoXData.Ler(valores, out tipo));
            Assert.Equal((short)1, tipo);
        }

        [Fact]
        public void Aux_interligacao_recusa_app_name_diferente()
        {
            List<TypedXData> valores = new List<TypedXData>
            {
                new TypedXData(1001, "INTERLIGACAO"),
                new TypedXData(1070, (short)1),
            };

            short tipo;
            Assert.False(AuxInterligacaoXData.Ler(valores, out tipo));
        }

        [Fact]
        public void Aux_interligacao_recusa_registro_truncado()
        {
            // O original lê os índices 1..7 direto e estoura num registro curto; aqui
            // registro degenerado é dado de terceiro e devolve false.
            List<TypedXData> valores = new List<TypedXData>
            {
                new TypedXData(1001, "AUXINTERLIG"),
            };

            short tipo;
            Assert.False(AuxInterligacaoXData.Ler(valores, out tipo));
        }
    }
}

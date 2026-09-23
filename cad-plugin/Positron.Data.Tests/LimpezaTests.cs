using System.Collections.Generic;
using Positron.Data.Fiacao;
using Positron.Data.Limpeza;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// As regras **puras** das ações de limpeza do CAD (frente 2 do §7.6): a do
    /// texto em branco do <c>ApagarTextosEmBranco</c>, a marca do
    /// <c>apagaXDataTerceiros</c> e os nomes dos dois dicionários que os
    /// <c>ApagaLayouts</c>/<c>ApagaPlaquetas</c> removem.
    /// </summary>
    public class LimpezaTests
    {
        // ── Texto em branco ───────────────────────────────────────────────────

        [Fact]
        public void Texto_vazio_e_em_branco()
        {
            Assert.True(LimpezaDoDesenho.TextoEmBranco(string.Empty, false));
        }

        [Fact]
        public void Texto_so_espacos_e_em_branco()
        {
            // O original usa `TextString.Trim()` — tabulação e espaços contam.
            Assert.True(LimpezaDoDesenho.TextoEmBranco(" \t  ", false));
        }

        [Fact]
        public void Texto_nulo_e_em_branco()
        {
            Assert.True(LimpezaDoDesenho.TextoEmBranco(null, false));
        }

        [Fact]
        public void Texto_com_conteudo_nao_e_em_branco()
        {
            Assert.False(LimpezaDoDesenho.TextoEmBranco("27TTX1", false));
            Assert.False(LimpezaDoDesenho.TextoEmBranco(" x ", false));
        }

        [Fact]
        public void Texto_em_branco_com_xdata_nao_e_apagado()
        {
            // Segunda condição do original: rótulo sem texto mas COM XData é dado
            // (ex.: o AUXINTERLIG de um cabo), não lixo.
            Assert.False(LimpezaDoDesenho.TextoEmBranco("   ", true));
            Assert.False(LimpezaDoDesenho.TextoEmBranco(string.Empty, true));
        }

        // ── XData de terceiros ────────────────────────────────────────────────

        [Fact]
        public void Substituicao_do_xdata_de_terceiros_e_um_unico_registro_1001()
        {
            // O original troca o buffer inteiro por um registro 1001 com o próprio
            // app name: o conteúdo de terceiro some, a marca fica.
            IReadOnlyList<TypedXData> valores = LimpezaDoDesenho.XDataDeTerceirosSubstituido();

            Assert.Single(valores);
            Assert.Equal(1001, valores[0].Codigo);
            Assert.Equal(LimpezaDoDesenho.XDataTerceiros, valores[0].Valor);
        }

        // ── Nomes (o contrato com o desenho original) ──────────────────────────

        [Fact]
        public void Nomes_batem_com_o_reverso()
        {
            // Trocados, as duas ações apagariam o dicionário errado — ou nenhum.
            Assert.Equal("AEC_XDATA_BOUND_SPACE", LimpezaDoDesenho.XDataTerceiros);
            Assert.Equal("CENG_LAYOUT", LimpezaDoDesenho.DicionarioLayout);
            Assert.Equal("CENG_PLAQUETA", LimpezaDoDesenho.DicionarioPlaquetas);
        }
    }
}

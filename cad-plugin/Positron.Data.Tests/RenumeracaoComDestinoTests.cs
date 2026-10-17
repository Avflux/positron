using System.Collections.Generic;
using Positron.Data.Interface;
using Positron.Data.Paginas;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// A renumeração com destino da paleta — o `C8Op1CM1YgS` do menu das folhas (o item
    /// **Renumerar Páginas**) e o corpo do combo `Folha` (o `Es6p1Y15jTb`).
    /// </summary>
    public class RenumeracaoComDestinoTests
    {
        [Theory]
        [InlineData("12", 0)]
        [InlineData("012", 3)]
        [InlineData("0012", 4)]
        [InlineData("00012", 5)]
        [InlineData("000012", 6)]
        [InlineData("0000012", 7)]
        public void Os_seis_literais_do_combo_valem_a_largura_fixa(string literal, int largura)
        {
            int lida;
            Assert.True(RenumeracaoComDestino.LarguraDoFormatoLiteral(literal, out lida));
            Assert.Equal(largura, lida);

            // O texto é comparado sem caixa pelo original (`TextCompare: true`).
            Assert.True(RenumeracaoComDestino.LarguraDoFormatoLiteral(" " + literal + " ", out lida));
            Assert.Equal(largura, lida);
        }

        [Fact]
        public void O_combo_aceita_texto_digitado_sem_mexer_na_largura()
        {
            // O `switch` do original não tem `default`: com texto fora dos seis literais a
            // `Conf.LarguraFixaPaginas` fica como estava.
            int largura;
            Assert.False(RenumeracaoComDestino.LarguraDoFormatoLiteral("7", out largura));
            Assert.False(RenumeracaoComDestino.LarguraDoFormatoLiteral("00000012", out largura));
            Assert.False(RenumeracaoComDestino.LarguraDoFormatoLiteral("", out largura));
            Assert.False(RenumeracaoComDestino.LarguraDoFormatoLiteral(null, out largura));
            Assert.Equal(0, largura);
        }

        [Fact]
        public void O_combo_normaliza_todas_as_paginas_com_a_largura()
        {
            List<string> paginas = new List<string> { "1", "2", "10A", "489" };

            IReadOnlyList<string> com3 = RenumeracaoComDestino.Normalizar(paginas, 3);
            Assert.Equal(new[] { "001", "002", "010A", "489" }, com3);

            // Largura zero (o literal `12`) tira os zeros à esquerda.
            IReadOnlyList<string> semLargura = RenumeracaoComDestino.Normalizar(
                new List<string> { "001", "0002" }, 0);
            Assert.Equal(new[] { "1", "2" }, semLargura);
        }

        [Fact]
        public void O_destino_da_capa_e_recusado()
        {
            // mMensagem 57 — o `checaCapa` é a primeira guarda do original.
            RenumeracaoComDestino.Plano plano = RenumeracaoComDestino.Planejar(
                "0000001", 7, 1, new List<string> { "2" }, new List<string> { "1", "3" });

            Assert.False(plano.Aplicar);
            Assert.Equal(MensagensDoReverso.NaoEPossivelMoverSobreACapa, plano.Aviso);
            Assert.Empty(plano.Novas);
        }

        [Fact]
        public void O_destino_que_ja_e_pagina_recusa_com_a_mensagem_da_selecao()
        {
            // mMensagem 26 — o destino está entre as **selecionadas**; a 25 é para as outras.
            RenumeracaoComDestino.Plano selecionada = RenumeracaoComDestino.Planejar(
                "3", 0, 1, new List<string> { "3", "4" }, new List<string> { "1", "5" });
            Assert.False(selecionada.Aplicar);
            Assert.Equal(MensagensDoReverso.EstaPaginaFoiSelecionada, selecionada.Aviso);

            RenumeracaoComDestino.Plano outra = RenumeracaoComDestino.Planejar(
                "5", 0, 1, new List<string> { "3", "4" }, new List<string> { "1", "5" });
            Assert.False(outra.Aplicar);
            Assert.Equal(MensagensDoReverso.EstaPaginaJaExisteInformeLivre, outra.Aviso);
        }

        [Fact]
        public void O_ramo_numerico_usa_o_passo_e_a_largura()
        {
            // O destino `12` cabe até a página `20` (a primeira não selecionada depois dele): 8
            // lugares para 2 selecionadas — o ramo numérico do `definePaginasNumericas`.
            RenumeracaoComDestino.Plano plano = RenumeracaoComDestino.Planejar(
                "12", 0, 1, new List<string> { "10", "11" }, new List<string> { "1", "20" });

            Assert.True(plano.Aplicar);
            Assert.Equal("12", plano.Destino);
            Assert.Equal(new[] { "12", "13" }, plano.Novas);
        }

        [Fact]
        public void O_ramo_numerico_respeita_o_passo_do_caderno()
        {
            RenumeracaoComDestino.Plano plano = RenumeracaoComDestino.Planejar(
                "2", 3, 5, new List<string> { "40", "41" }, new List<string> { "1", "20" });

            Assert.True(plano.Aplicar);
            Assert.Equal(new[] { "002", "007" }, plano.Novas);
        }

        [Fact]
        public void Sem_espaco_numerico_o_destino_ganha_letra()
        {
            // `5` não existe; a próxima página é a `6`, então só cabe **uma** numérica (o próprio 5)
            // e a segunda selecionada sai como `5A` — o `definePaginasAlfaNumericas`.
            RenumeracaoComDestino.Plano plano = RenumeracaoComDestino.Planejar(
                "5", 0, 1, new List<string> { "3", "4" }, new List<string> { "1", "6" });

            Assert.True(plano.Aplicar);
            Assert.Equal(new[] { "5", "5A" }, plano.Novas);
        }

        [Fact]
        public void Sem_espaco_alfanumerico_a_movimentacao_e_recusada()
        {
            // mMensagem 27: de `5A` até a `6` cabem 26 páginas alfanuméricas (A..Z) — uma a mais
            // não cabe.
            List<string> selecionadas = new List<string>();
            for (int i = 100; i <= 126; i++)
            {
                selecionadas.Add(i.ToString());
            }

            RenumeracaoComDestino.Plano plano = RenumeracaoComDestino.Planejar(
                "5A", 0, 1, selecionadas, new List<string> { "1", "6" });

            Assert.False(plano.Aplicar);
            Assert.Equal(MensagensDoReverso.NaoHaEspacoSuficiente, plano.Aviso);
            Assert.Empty(plano.Novas);

            // Com 26 cabe inteiro (o limite é `>=`).
            selecionadas.RemoveAt(selecionadas.Count - 1);
            RenumeracaoComDestino.Plano cabe = RenumeracaoComDestino.Planejar(
                "5A", 0, 1, selecionadas, new List<string> { "1", "6" });
            Assert.True(cabe.Aplicar);
            Assert.Equal(26, cabe.Novas.Count);
            Assert.Equal("5A", cabe.Novas[0]);
            Assert.Equal("5Z", cabe.Novas[25]);
        }

        [Fact]
        public void A_letra_vizinha_esgota_os_dois_espacos_com_duas_selecionadas()
        {
            // A outra forma da mMensagem 27, a que **não** precisa de 27 páginas no desenho (e a
            // que foi medida no CAD na rodada 221): o destino é numérico e a próxima página não
            // selecionada é a letra seguinte, a `5A`. O espaço numérico é 1 (o próprio `5`:
            // floor(5,65) - 5 + 1) e o alfanumérico também 1 (de 64 = 'A' - 1 a 65 = 'A').
            RenumeracaoComDestino.Plano plano = RenumeracaoComDestino.Planejar(
                "5", 0, 1, new List<string> { "6", "7" }, new List<string> { "1", "5A" });

            Assert.False(plano.Aplicar);
            Assert.Equal(MensagensDoReverso.NaoHaEspacoSuficiente, plano.Aviso);
            Assert.Empty(plano.Novas);

            // Uma selecionada cabe — no número seco (`5`), o ramo numérico.
            RenumeracaoComDestino.Plano cabe = RenumeracaoComDestino.Planejar(
                "5", 0, 1, new List<string> { "6" }, new List<string> { "1", "5A" });
            Assert.True(cabe.Aplicar);
            Assert.Equal(new[] { "5" }, cabe.Novas);
        }

        [Fact]
        public void A_resposta_do_prompt_e_normalizada_como_no_original()
        {
            // `ToUpper()` + `montaNumeroPagina`: espaços fora, letra em caixa alta e os zeros da
            // largura fixa.
            RenumeracaoComDestino.Plano plano = RenumeracaoComDestino.Planejar(
                "  12a  ", 3, 1, new List<string> { "30" }, new List<string> { "1", "20" });

            Assert.True(plano.Aplicar);
            Assert.Equal("012A", plano.Destino);
            // Com a letra no destino o ramo numérico parte do **número seguinte** (o `Floor + 1`).
            Assert.Equal(new[] { "013" }, plano.Novas);
        }

        [Fact]
        public void Sem_nenhuma_selecionada_o_original_pergunta_e_nao_renomeia()
        {
            // O laço do prompt fica **fora** do `If dg.SelectedRows.Count > 0`: sem seleção o
            // original pergunta igual (e o `renumerarPaginasLote` não tem o que renomear).
            RenumeracaoComDestino.Plano plano = RenumeracaoComDestino.Planejar(
                "9", 0, 1, new List<string>(), new List<string> { "1", "2" });

            Assert.True(plano.Aplicar);
            Assert.Empty(plano.Novas);
        }

        [Fact]
        public void O_alfanumerico_pula_do_Z_para_o_numero_seguinte()
        {
            IReadOnlyList<string> novas = RenumeracaoComDestino.AlfaNumericas("10", 28, 0);

            Assert.Equal(28, novas.Count);
            Assert.Equal("10", novas[0]);
            Assert.Equal("10Z", novas[26]);
            Assert.Equal("11", novas[27]);
        }

        [Fact]
        public void O_destino_sem_numero_estoura_como_no_original()
        {
            // O original estoura no `Strings.Mid("", 0, 1)` e mostra a mensagem num `MsgBox`
            // crítico, sem renomear nada.
            Assert.Throws<System.InvalidOperationException>(
                () => RenumeracaoComDestino.AlfaNumericas("", 1, 0));
        }
    }
}

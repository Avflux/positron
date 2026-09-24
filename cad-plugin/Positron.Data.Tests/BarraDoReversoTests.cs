using System;
using System.Collections.Generic;
using Positron.Data.Interface.Mapas;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// A barra de ferramentas do reverso (`BarraDoReverso`) — a aba, os nove painéis e os 121 botões
    /// do `Ribbon.cs`, medidos pelo `scripts/extrair-barra-do-reverso.ps1`.
    ///
    /// O que estes testes protegem é o **cruzamento**: todo botão que diz abrir janela tem de ter o
    /// comando no mapa dos 216 (`ComandosDoReverso`) **com** uma tela. É o que faz a barra ser uma
    /// porta de entrada de verdade para as telas, e não um rótulo bonito.
    /// </summary>
    public class BarraDoReversoTests
    {
        [Fact]
        public void ASaoDaAbaOAidEOtituloDoOriginal()
        {
            Assert.Equal("CENG.ID_Elet", BarraDoReverso.IdDaAbaDoOriginal);
            Assert.Equal("Elétron", BarraDoReverso.TituloDaAbaDoOriginal);
        }

        [Fact]
        public void SaoNovePaineisECentoEVinteEUmBotoes()
        {
            Assert.Equal(9, BarraDoReverso.Paineis.Count);
            Assert.Equal(121, BarraDoReverso.Quantidade);
            Assert.Equal(121, BarraDoReverso.Botoes.Count);
        }

        [Fact]
        public void OsPaineisSaemNaOrdemDaBarra()
        {
            Assert.Equal(
                new[] { "Configuração", "Caderno", "Dispositivos", "Bornes", "Fiação", "Construtivo", "Cabos e Veias", "Utilitários", "Help" },
                NomesDosPaineis().ToArray());

            for (int i = 0; i < BarraDoReverso.Paineis.Count; i++)
            {
                Assert.Equal(i + 1, BarraDoReverso.Paineis[i].Ordem);
            }
        }

        [Fact]
        public void OsPaineisTemOsIndicesDaMensagemDoOriginal()
        {
            // 111 Configuração, 109 Caderno, 110 Dispositivos, 540 Bornes, 559 Fiação, 1549
            // Construtivo, 560 Cabos e Veias, 112 Utilitários - e o Help, que é literal (-1).
            int[] indices = new int[BarraDoReverso.Paineis.Count];
            for (int i = 0; i < BarraDoReverso.Paineis.Count; i++)
            {
                indices[i] = BarraDoReverso.Paineis[i].IndiceMensagem;
            }

            Assert.Equal(new[] { 111, 109, 110, 540, 559, 1549, 560, 112, -1 }, indices);
        }

        [Fact]
        public void OsPaineisSomamOsBotoesDaBarra()
        {
            int total = 0;
            foreach (PainelDaBarra painel in BarraDoReverso.Paineis)
            {
                total += painel.Botoes.Count;
            }

            Assert.Equal(BarraDoReverso.Quantidade, total);
        }

        [Fact]
        public void TodoBotaoTemLinhaDoRibbonEDica()
        {
            Assert.All(BarraDoReverso.Botoes, botao =>
            {
                Assert.True(botao.Origem > 0, "botao sem a linha do Ribbon.cs");
                Assert.False(string.IsNullOrEmpty(botao.Grau));

                // O banner da versao e o unico sem rotulo e sem dica: o texto dele o original
                // monta em execucao (versao + hardlock), entao no mapa ele sai vazio.
                if (!botao.TemComando)
                {
                    return;
                }

                Assert.False(string.IsNullOrEmpty(botao.Rotulo) && string.IsNullOrEmpty(botao.Dica));
            });
        }

        [Fact]
        public void OPrimeiroBotaoEBannerDaVersao()
        {
            // O painel Configuração abre com o banner (sem comando): o `Text` dele monta a versão e
            // o hardlock em tempo de execução, então o mapa sai com rótulo vazio.
            BotaoDaBarra banner = BarraDoReverso.Paineis[0].Botoes[0];

            Assert.False(banner.TemComando);
            Assert.False(banner.Coberto);
            Assert.Equal("Setup_32", banner.Icone);
            Assert.Equal("Grande", banner.Grau);
        }

        /// <summary>O launcher do canto do painel também é um botão — e é o `CFG` no original.</summary>
        [Fact]
        public void OLancadorDeDialogoDaConfiguracaoEOComandoCfg()
        {
            BotaoDaBarra cfg = BarraDoReverso.Buscar("CFG");

            Assert.NotNull(cfg);
            Assert.Equal("Dialogo", cfg.Grau);
            Assert.True(cfg.Coberto);
            Assert.True(cfg.AbreJanela);
        }

        /// <summary>
        /// O arquivo do original tem **um só** `DialogLauncher` (o `CFG` da Configuração) e **120**
        /// chamadas de ajudante; 120 + 1 = os **121** botões do mapa. É a conta que fecha a extração
        /// com o arquivo-fonte: se aparecesse um segundo launcher e ele não entrasse no mapa, a
        /// barra ficaria com um botão a menos sem ninguém notar.
        /// </summary>
        [Fact]
        public void OAjudanteEElancadorSomamOsCentoEVinteEUmBotoes()
        {
            int chamadas = 0;
            int launchers = 0;
            foreach (BotaoDaBarra botao in BarraDoReverso.Botoes)
            {
                if (botao.Grau == "Dialogo")
                {
                    launchers++;
                    continue;
                }

                chamadas++;
            }

            Assert.Equal(120, chamadas);
            Assert.Equal(1, launchers);
            Assert.Equal(121, chamadas + launchers);
            Assert.Equal("CFG", Assert.Single(BotoesDeDialogo()).Comando);
        }

        private static List<BotaoDaBarra> BotoesDeDialogo()
        {
            List<BotaoDaBarra> achados = new List<BotaoDaBarra>();
            foreach (BotaoDaBarra botao in BarraDoReverso.Botoes)
            {
                if (botao.Grau == "Dialogo")
                {
                    achados.Add(botao);
                }
            }

            return achados;
        }

        [Fact]
        public void OGerdwgEOMesmoBotaoDoOriginal()
        {
            BotaoDaBarra botao = BarraDoReverso.Buscar("GERDWG");

            Assert.NotNull(botao);
            Assert.Equal("GER DWG", botao.Rotulo);
            Assert.Equal("Database_Preto_32", botao.Icone);
            Assert.Equal("Pequeno", botao.Grau);
            Assert.True(botao.Utilizavel);
        }

        [Fact]
        public void OsBotoesCobertosEAbrindoJanelaSomamOCruzamentoMedido()
        {
            Assert.Equal(83, BarraDoReverso.QuantosCobertos());
            Assert.Equal(76, BarraDoReverso.QuantosAbremJanela());
        }

        /// <summary>
        /// O cruzamento que interessa: quem diz que abre janela tem o comando **e** a tela no outro
        /// mapa. Um só dos dois lados seria um botão que não abre nada.
        /// </summary>
        [Fact]
        public void TodoBotaoQueDizAbrirJanelaTemAComandoETela()
        {
            List<string> conferidos = new List<string>();
            List<string> ligados = new List<string>();
            foreach (BotaoDaBarra botao in BarraDoReverso.Botoes)
            {
                if (!botao.AbreJanela)
                {
                    continue;
                }

                Comando comando = ComandosDoReverso.Buscar(botao.Comando);
                Assert.True(comando != null, "botao " + botao.Comando + " sem comando no mapa dos 216");
                Assert.True(comando.AbreJanela, "botao " + botao.Comando + " marcado na barra mas sem janela no mapa");
                Assert.NotNull(FormulariosDoReverso.Buscar(comando.Janelas[0].Nome));
                conferidos.Add(botao.Comando);
                if (botao.Utilizavel)
                {
                    ligados.Add(botao.Comando);
                }
            }

            // 78 botoes da barra do original abrem janela; 76 deles o recoder responde (TROCAPN e
            // IMPBD ficaram de fora como os outros: variante de tela e comando com regra propria).
            Assert.Equal(78, conferidos.Count);
            Assert.Equal(76, ligados.Count);
            Assert.DoesNotContain("TROCAPN", ligados);
            Assert.DoesNotContain("IMPBD", ligados);
        }

        /// <summary>Todo botão utilizável tem comando no plugin — e o Coberto vem de lá.</summary>
        [Fact]
        public void UtilizavelExigeComandoECobertura()
        {
            Assert.All(BarraDoReverso.Botoes, botao =>
            {
                Assert.Equal(botao.TemComando && botao.Coberto, botao.Utilizavel);
                if (!botao.Utilizavel)
                {
                    return;
                }

                Assert.False(string.IsNullOrEmpty(botao.Comando));
            });
        }

        [Fact]
        public void ABuscaIgnoraAMaiusculaEZeraONaoEncontrado()
        {
            Assert.NotNull(BarraDoReverso.Buscar("gerdwg"));
            Assert.Null(BarraDoReverso.Buscar("NAOEXISTE"));
            Assert.Null(BarraDoReverso.Buscar(null));
            Assert.Null(BarraDoReverso.Buscar(string.Empty));
        }

        [Fact]
        public void OsIconesSaoNomesDeRecursoDoOriginal()
        {
            Assert.All(BarraDoReverso.Botoes, botao =>
            {
                Assert.DoesNotContain(".", botao.Icone);
                Assert.DoesNotContain("/", botao.Icone);
            });
        }

        private static List<string> NomesDosPaineis()
        {
            List<string> nomes = new List<string>();
            foreach (PainelDaBarra painel in BarraDoReverso.Paineis)
            {
                nomes.Add(painel.Titulo);
            }

            return nomes;
        }
    }
}

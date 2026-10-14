using System;
using System.Collections.Generic;
using Positron.Data.Interface.Mapas;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// A barra de ferramentas do reverso (`BarraDoReverso`) — a aba, os nove painéis e a árvore de
    /// cada um como o `Ribbon.cs` a monta, medidos pelo `scripts/extrair-barra-do-reverso.ps1`.
    ///
    /// O que estes testes protegem: (1) a **estrutura** — as contagens batem com os `new Ribbon*()`
    /// do arquivo, e a árvore tem a forma do original (linhas, área recolhível, menus); (2) o
    /// **cruzamento** — todo item que diz abrir janela tem o comando no mapa dos 216
    /// (`ComandosDoReverso`) **com** uma tela.
    /// </summary>
    public class BarraDoReversoTests
    {
        [Fact]
        public void OIdEOTituloDaAbaSaoDoOriginal()
        {
            Assert.Equal("CENG.ID_Elet", BarraDoReverso.IdDaAbaDoOriginal);
            Assert.Equal("Elétron", BarraDoReverso.TituloDaAbaDoOriginal);
        }

        /// <summary>
        /// As contagens por tipo são as do `Ribbon.cs` (o `new RibbonX()` de cada classe): o mapa não
        /// perde nem inventa item. Os separadores contam cada **uso** na árvore (o original reusa a
        /// mesma variável: 3 declarados, um deles usado seis vezes, e 3 criados na própria adição).
        /// </summary>
        [Theory]
        [InlineData(TipoDoItemDaBarra.Botao, 121)]
        [InlineData(TipoDoItemDaBarra.Menu, 5)]
        [InlineData(TipoDoItemDaBarra.ItemDeMenu, 39)]
        [InlineData(TipoDoItemDaBarra.Linha, 34)]
        [InlineData(TipoDoItemDaBarra.QuebraDeLinha, 86)]
        [InlineData(TipoDoItemDaBarra.Recolhe, 7)]
        [InlineData(TipoDoItemDaBarra.ListaDeSecao, 1)]
        [InlineData(TipoDoItemDaBarra.CampoDeCor, 1)]
        [InlineData(TipoDoItemDaBarra.Alternar, 1)]
        [InlineData(TipoDoItemDaBarra.Separador, 9)]
        public void AsContagensSaoAsDoRibbon(TipoDoItemDaBarra tipo, int esperado)
        {
            Assert.Equal(esperado, BarraDoReverso.Contar(tipo));
        }

        [Fact]
        public void OsAcionaveisSaoBotoesItensDeMenuEOLigaDesliga()
        {
            Assert.Equal(121 + 39 + 1, BarraDoReverso.Acionaveis.Count);
            Assert.All(BarraDoReverso.Acionaveis, item => Assert.True(item.Acionavel));
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
        public void AConfiguracaoEOBannerDesativadoEOCfgNoCanto()
        {
            PainelDaBarra configuracao = BarraDoReverso.Paineis[0];
            ItemDaBarra banner = Assert.Single(configuracao.Itens);

            Assert.Equal(TipoDoItemDaBarra.Botao, banner.Tipo);
            Assert.Equal("Grande", banner.Grau);
            Assert.True(banner.Desativado);
            Assert.False(banner.TemComando);
            Assert.Equal("Setup_32", banner.Icone);
            Assert.Equal("Setup_32_Dark", banner.IconeEscuro);

            Assert.NotNull(configuracao.Lancador);
            Assert.Equal("CFG", configuracao.Lancador.Comando);
            Assert.Equal("Dialogo", configuracao.Lancador.Grau);
        }

        /// <summary>O arquivo do original tem um só `DialogLauncher`: o `CFG` da Configuração.</summary>
        [Fact]
        public void SoAConfiguracaoTemBotaoNoCanto()
        {
            int comLancador = 0;
            foreach (PainelDaBarra painel in BarraDoReverso.Paineis)
            {
                if (painel.Lancador != null)
                {
                    comLancador++;
                }
            }

            Assert.Equal(1, comLancador);
        }

        [Fact]
        public void OCadernoAbreComDuasLinhasDeIconeGrandeEARecolhivel()
        {
            IReadOnlyList<ItemDaBarra> itens = BarraDoReverso.Paineis[1].Itens;

            Assert.Equal(TipoDoItemDaBarra.Linha, itens[0].Tipo);
            Assert.Equal(new[] { "CAD", "", "GERDWG" }, Comandos(itens[0].Filhos));
            Assert.Equal(TipoDoItemDaBarra.QuebraDeLinha, itens[0].Filhos[1].Tipo);
            Assert.Equal(new[] { "REGH", "", "REGV" }, Comandos(itens[1].Filhos));
            Assert.Equal(TipoDoItemDaBarra.Recolhe, itens[2].Tipo);

            ItemDaBarra gerdwg = BarraDoReverso.Buscar("GERDWG");
            Assert.Equal("IconeGrande", gerdwg.Grau);
            Assert.Equal("GER DWG", gerdwg.Rotulo);
            Assert.Equal("Database_Preto_32", gerdwg.Icone);
            Assert.Equal("Database_Branco_32", gerdwg.IconeEscuro);
        }

        [Fact]
        public void AFiacaoTemAListaACorEOsDoisMenus()
        {
            PainelDaBarra fiacao = BarraDoReverso.Paineis[4];
            ItemDaBarra linha = null;
            foreach (ItemDaBarra item in fiacao.Itens)
            {
                if (item.Tipo == TipoDoItemDaBarra.Linha && item.Filhos[0].Tipo == TipoDoItemDaBarra.ListaDeSecao)
                {
                    linha = item;
                }
            }

            Assert.NotNull(linha);
            Assert.Equal(TipoDoItemDaBarra.CampoDeCor, linha.Filhos[1].Tipo);
            Assert.Equal(65, linha.Filhos[0].Largura);

            List<ItemDaBarra> menus = new List<ItemDaBarra>();
            foreach (ItemDaBarra item in linha.Filhos)
            {
                if (item.Tipo == TipoDoItemDaBarra.Menu)
                {
                    menus.Add(item);
                }
            }

            Assert.Equal(2, menus.Count);
            Assert.Equal(9, menus[0].Filhos.Count);
            Assert.Equal("RFIA", menus[0].Filhos[0].Comando);
            Assert.Equal(new[] { "TPG", "ATPG" }, Comandos(menus[1].Filhos));
        }

        [Fact]
        public void OHelpEOAjudaEOLigaDesligaInfoOn()
        {
            ItemDaBarra linha = Assert.Single(BarraDoReverso.Paineis[8].Itens);
            Assert.Equal(new[] { "AJUDA", "", "InfoOn" }, Comandos(linha.Filhos));

            ItemDaBarra info = linha.Filhos[2];
            Assert.Equal(TipoDoItemDaBarra.Alternar, info.Tipo);
            Assert.Equal("InformationOn_32", info.Icone);
            Assert.Equal("InformationOn_32_Dark", info.IconeEscuro);
        }

        /// <summary>A forma da árvore: quebra só dentro de linha, item de menu só dentro de menu.</summary>
        [Fact]
        public void AArvoreTemAFormaDoRibbon()
        {
            foreach (PainelDaBarra painel in BarraDoReverso.Paineis)
            {
                int recolhe = 0;
                foreach (ItemDaBarra item in painel.Itens)
                {
                    Assert.NotEqual(TipoDoItemDaBarra.QuebraDeLinha, item.Tipo);
                    Assert.NotEqual(TipoDoItemDaBarra.ItemDeMenu, item.Tipo);
                    if (item.Tipo == TipoDoItemDaBarra.Recolhe)
                    {
                        recolhe++;
                    }

                    foreach (ItemDaBarra descendente in item.EleEOsDescendentes())
                    {
                        if (descendente.Tipo == TipoDoItemDaBarra.Menu)
                        {
                            Assert.NotEmpty(descendente.Filhos);
                            Assert.All(descendente.Filhos, filho => Assert.Equal(TipoDoItemDaBarra.ItemDeMenu, filho.Tipo));
                        }
                        else if (descendente.Tipo != TipoDoItemDaBarra.Linha)
                        {
                            Assert.Empty(descendente.Filhos);
                        }
                    }
                }

                Assert.True(recolhe <= 1, "painel " + painel.Titulo + " com mais de uma area recolhivel");
            }
        }

        [Fact]
        public void TodoAcionavelTemLinhaDoRibbonEGrau()
        {
            Assert.All(BarraDoReverso.Acionaveis, item =>
            {
                Assert.True(item.Origem > 0, "item sem a linha do Ribbon.cs");
                Assert.False(string.IsNullOrEmpty(item.Grau));
                if (item.TemComando)
                {
                    Assert.False(string.IsNullOrEmpty(item.Rotulo) && string.IsNullOrEmpty(item.Dica) && item.Tipo != TipoDoItemDaBarra.Alternar && item.Grau != "Dialogo");
                }
            });
        }

        [Fact]
        public void OsCobertosEOsQueAbremJanelaSomamOCruzamentoMedido()
        {
            Assert.Equal(124, BarraDoReverso.QuantosCobertos());
            Assert.Equal(117, BarraDoReverso.QuantosAbremJanela());
        }

        /// <summary>
        /// O cruzamento que interessa: quem diz que abre janela tem o comando **e** a tela no outro
        /// mapa. Um só dos dois lados seria um item que não abre nada.
        /// </summary>
        [Fact]
        public void TodoAcionavelQueDizAbrirJanelaTemAComandoETela()
        {
            List<string> conferidos = new List<string>();
            List<string> semComando = new List<string>();
            foreach (ItemDaBarra item in BarraDoReverso.Acionaveis)
            {
                if (!item.AbreJanela)
                {
                    continue;
                }

                Comando comando = ComandosDoReverso.Buscar(item.Comando);
                Assert.True(comando != null, "item " + item.Comando + " sem comando no mapa dos 216");
                Assert.True(comando.AbreJanela, "item " + item.Comando + " marcado na barra mas sem janela no mapa");
                Assert.NotNull(FormulariosDoReverso.Buscar(comando.Janelas[0].Nome));
                conferidos.Add(item.Comando);
                if (!item.Utilizavel)
                {
                    semComando.Add(item.Comando);
                }
            }

            // 117 itens da barra abrem janela; com as variantes (rodada 158) e o IMPBD (rodada 159), todos ligados.
            Assert.Equal(117, conferidos.Count);
            Assert.Empty(semComando);
        }

        [Fact]
        public void UtilizavelExigeComandoCoberturaEItemAtivo()
        {
            Assert.All(BarraDoReverso.Acionaveis, item =>
                Assert.Equal(item.TemComando && item.Coberto && !item.Desativado, item.Utilizavel));
        }

        [Fact]
        public void ABuscaIgnoraAMaiusculaEZeraONaoEncontrado()
        {
            Assert.NotNull(BarraDoReverso.Buscar("gerdwg"));
            Assert.NotNull(BarraDoReverso.Buscar("rfia"));
            Assert.Null(BarraDoReverso.Buscar("NAOEXISTE"));
            Assert.Null(BarraDoReverso.Buscar(null));
            Assert.Null(BarraDoReverso.Buscar(string.Empty));
        }

        [Fact]
        public void OsIconesSaoNomesDeRecursoDoOriginal()
        {
            foreach (PainelDaBarra painel in BarraDoReverso.Paineis)
            {
                foreach (ItemDaBarra raiz in painel.Itens)
                {
                    foreach (ItemDaBarra item in raiz.EleEOsDescendentes())
                    {
                        Assert.DoesNotContain(".", item.Icone + item.IconeEscuro);
                        Assert.DoesNotContain("/", item.Icone + item.IconeEscuro);
                    }
                }
            }
        }

        private static string[] Comandos(IReadOnlyList<ItemDaBarra> itens)
        {
            List<string> saida = new List<string>();
            foreach (ItemDaBarra item in itens)
            {
                saida.Add(item.Comando);
            }

            return saida.ToArray();
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

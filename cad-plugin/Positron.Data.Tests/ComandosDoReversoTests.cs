using System;
using System.Collections.Generic;
using Positron.Data.Interface;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// O mapa dos comandos do reverso (`ComandosDoReverso`) — os 216 `[CommandMethod]` do Eletron4Z
    /// e a janela que cada um abre, medidos pelo `scripts/extrair-comandos-do-reverso.ps1`.
    ///
    /// A parte que interessa aqui é o **casamento dos dois mapas**: quem abre janela tem de apontar
    /// para uma tela que existe no `FormulariosDoReverso`. É isso que garante que o comando do
    /// original (o `GERDWG`, o `DEF`) abre a tela decodificada, e não um nome solto.
    /// </summary>
    public class ComandosDoReversoTests
    {
        [Fact]
        public void SaoOsDuzentosEDezeSeisComandosDoReverso()
        {
            Assert.Equal(216, ComandosDoReverso.Quantidade);
            Assert.Equal(216, ComandosDoReverso.Todos.Count);
        }

        [Fact]
        public void NaoHaComandoRepetido()
        {
            HashSet<string> nomes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (Comando comando in ComandosDoReverso.Todos)
            {
                Assert.True(nomes.Add(comando.Nome), "comando repetido: " + comando.Nome);
            }
        }

        [Fact]
        public void TodoComandoTemArquivoELinhaDoReverso()
        {
            Assert.All(ComandosDoReverso.Todos, comando =>
            {
                Assert.False(string.IsNullOrEmpty(comando.Nome));
                Assert.False(string.IsNullOrEmpty(comando.Arquivo));
                Assert.True(comando.Origem > 0, comando.Nome + " sem a linha do atributo");
            });
        }

        [Fact]
        public void CentoEVinteEUmComandosAbremJanela()
        {
            Assert.Equal(121, ComandosDoReverso.QuantosAbremJanela());

            int contados = 0;
            int soJanela = 0;
            foreach (Comando comando in ComandosDoReverso.Todos)
            {
                if (comando.AbreJanela)
                {
                    contados++;
                }

                if (comando.SomenteJanela)
                {
                    soJanela++;
                }
            }

            Assert.Equal(121, contados);
            Assert.Equal(119, soJanela);
        }

        /// <summary>
        /// O contrato do que o plugin registra: 99 comandos do original respondem com o próprio nome
        /// e abrem a tela padrão (o `ComandosDoOriginal.Gerado.cs` gera um método por um destes).
        /// </summary>
        [Fact]
        public void NoventaENoveComandosSAoLigaveis()
        {
            Assert.Equal(99, ComandosDoReverso.QuantosLigaveis());

            List<string> ligaveis = new List<string>();
            foreach (Comando comando in ComandosDoReverso.Todos)
            {
                if (comando.Ligavel)
                {
                    ligaveis.Add(comando.Nome);
                }
            }

            Assert.Equal(99, ligaveis.Count);
            Assert.Contains("GERDWG", ligaveis);
            Assert.Contains("DEF", ligaveis);
            Assert.Contains("BORN", ligaveis);
            Assert.DoesNotContain("SYNCD", ligaveis);
            Assert.DoesNotContain("APAGARXDATA", ligaveis);
        }

        /// <summary>
        /// O casamento dos dois mapas: toda janela citada por um comando é uma tela decodificada do
        /// designer. Sem isso, o comando registraria e não abriria nada.
        /// </summary>
        [Fact]
        public void TodaJanelaDeUmComandoExisteNoMapaDasTelas()
        {
            Assert.All(ComandosDoReverso.Todos, comando => Assert.All(comando.Janelas, janela =>
            {
                Assert.NotNull(FormulariosDoReverso.Buscar(janela.Nome));
                Assert.StartsWith("new ", janela.Construcao);
            }));
        }

        [Fact]
        public void OApagarXDataAbreOPesquisaXdatas()
        {
            Comando comando = ComandosDoReverso.Buscar("APAGARXDATA");

            Assert.NotNull(comando);
            Assert.True(comando.SomenteJanela);
            Assert.True(comando.JaNoPlugin); // o recoder ja portou a regra com esse nome
            Assert.False(comando.ComVariante);
            Assert.Single(comando.Janelas);
            Assert.Equal("frmPesquisaXdatas", comando.Janelas[0].Nome);
            Assert.False(comando.Janelas[0].ComArgumento);
        }

        [Fact]
        public void OGerdwgAbreOGerenciadorDeDwg()
        {
            Comando comando = ComandosDoReverso.Buscar("GERDWG");

            Assert.NotNull(comando);
            Assert.Equal("Comandos.cs", comando.Arquivo);
            Assert.Equal("frmGerenciadorDWG", comando.Janelas[0].Nome);
            Assert.Equal("new frmGerenciadorDWG()", comando.Janelas[0].Construcao);
            Assert.True(comando.Ligavel);
        }

        /// <summary>
        /// A guarda não é trabalho: o `DEF` pergunta `clsRegua.VerificaRegua()` e **só** abre o
        /// `frmDefinicao`. A guarda fica registrada no mapa legível (`docs/reverso-comandos.txt`).
        /// </summary>
        [Fact]
        public void ODefTemGuardaMasSoAbreAJanela()
        {
            Comando comando = ComandosDoReverso.Buscar("DEF");

            Assert.NotNull(comando);
            Assert.True(comando.SomenteJanela);
            Assert.True(comando.Ligavel);
            Assert.Equal("frmDefinicao", comando.Janelas[0].Nome);
        }

        /// <summary>
        /// O `SYNCD` roda a sincronização inteira e **não** abre janela: registrar o nome dele como
        /// abertura de tela pularia a regra.
        /// </summary>
        [Fact]
        public void OSyncdNaoAbreJanelaENaoEhLigavel()
        {
            Comando comando = ComandosDoReverso.Buscar("SYNCD");

            Assert.NotNull(comando);
            Assert.False(comando.AbreJanela);
            Assert.False(comando.SomenteJanela);
            Assert.False(comando.Ligavel);
        }

        /// <summary>
        /// As variantes do diagrama de interligação: **um** `frmRelatorio_DInterlig` aberto por onze
        /// comandos, cada um com o seu argumento. O argumento é o relatório — abrir a tela padrão no
        /// lugar deles seria mentir, então nenhum é ligável.
        /// </summary>
        [Fact]
        public void AsVariantesDoDiagramaDeInterligacaoNaoSaoLigaveis()
        {
            Comando primeira = ComandosDoReverso.Buscar("DICHESF");
            Comando outra = ComandosDoReverso.Buscar("DIITAIPU");

            Assert.NotNull(primeira);
            Assert.NotNull(outra);
            Assert.Equal("frmRelatorio_DInterlig", primeira.Janelas[0].Nome);
            Assert.Equal("new frmRelatorio_DInterlig(1)", primeira.Janelas[0].Construcao);
            Assert.Equal("new frmRelatorio_DInterlig(11)", outra.Janelas[0].Construcao);
            Assert.True(primeira.ComVariante);
            Assert.True(outra.ComVariante);
            Assert.True(primeira.Janelas[0].ComArgumento);
            Assert.False(primeira.Ligavel);
            Assert.False(outra.Ligavel);
        }

        /// <summary>A variante também pode ser argumento nomeado (`new frmTrocaPaineis(bAbre: false)`).</summary>
        [Fact]
        public void AVariantePorArgumentoNomeadoTambemFicaDeFora()
        {
            Comando comando = ComandosDoReverso.Buscar("TROCAPN");

            Assert.NotNull(comando);
            Assert.Equal("frmTrocaPaineis", comando.Janelas[0].Nome);
            Assert.Equal("new frmTrocaPaineis(bAbre: false)", comando.Janelas[0].Construcao);
            Assert.True(comando.ComVariante);
            Assert.False(comando.Ligavel);
        }

        [Fact]
        public void DaTelaDevolveOsComandosDaJanela()
        {
            IReadOnlyList<Comando> xdatas = ComandosDoReverso.DaTela("frmPesquisaXdatas");
            Assert.Contains(xdatas, comando => comando.Nome == "APAGARXDATA");

            IReadOnlyList<Comando> interlig = ComandosDoReverso.DaTela("frmRelatorio_DInterlig");
            Assert.True(interlig.Count >= 10, "frmRelatorio_DInterlig com " + interlig.Count + " comando(s)");
            Assert.All(interlig, comando => Assert.True(comando.ComVariante));

            Assert.Empty(ComandosDoReverso.DaTela("frmNaoExiste"));
            Assert.Empty(ComandosDoReverso.DaTela(null));
            Assert.Empty(ComandosDoReverso.DaTela(string.Empty));
        }

        /// <summary>
        /// 108 das 127 telas têm um comando que as abre no original. As outras 19 são abertas de
        /// dentro de outra janela (o `frmRelatorio_FiacaoDWG` sai do botão do `frmRelatorio_Fiacao`)
        /// ou por um construtor com argumento (`frmPesquisaMateriais(Conversions.ToInteger(...))`) —
        /// e é assim mesmo que o original as alcança.
        /// </summary>
        [Fact]
        public void CentoEOitoTelasTemComandoNoOriginal()
        {
            List<string> semComando = new List<string>();
            int comComando = 0;
            foreach (Tela tela in FormulariosDoReverso.Todas)
            {
                if (ComandosDoReverso.DaTela(tela.Nome).Count == 0)
                {
                    semComando.Add(tela.Nome);
                }
                else
                {
                    comComando++;
                }
            }

            Assert.Equal(108, comComando);
            Assert.Equal(19, semComando.Count);
            Assert.Contains("frmRelatorio_FiacaoDWG", semComando);
            Assert.Contains("frmVisualizarBloco", semComando);
            Assert.Contains("frmPesquisaMateriais", semComando);
        }

        [Fact]
        public void OsLigaveisViramMetodoCSharp()
        {
            Assert.All(ComandosDoReverso.Todos, comando =>
            {
                if (!comando.Ligavel)
                {
                    return;
                }

                Assert.Matches("^[A-Za-z_][A-Za-z_0-9]*$", comando.Nome);
            });
        }

        /// <summary>Os comandos que o recoder já portou aparecem marcados — a varredura do script acha.</summary>
        [Fact]
        public void OsComandosJaPortadosAparecemMarcados()
        {
            Assert.True(ComandosDoReverso.Buscar("APAGARXDATA").JaNoPlugin);
            Assert.True(ComandosDoReverso.Buscar("FIA").JaNoPlugin);
            Assert.True(ComandosDoReverso.Buscar("INT").JaNoPlugin);
            Assert.True(ComandosDoReverso.Buscar("SYNCD").JaNoPlugin);
        }

        [Fact]
        public void ABuscaIgnoraAMaiusculaEZeraONaoEncontrado()
        {
            Assert.NotNull(ComandosDoReverso.Buscar("gerdwg"));
            Assert.Null(ComandosDoReverso.Buscar("NAOEXISTE"));
            Assert.Null(ComandosDoReverso.Buscar(null));
            Assert.Null(ComandosDoReverso.Buscar(string.Empty));
        }
    }
}

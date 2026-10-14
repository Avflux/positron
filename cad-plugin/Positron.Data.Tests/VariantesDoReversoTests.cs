using System;
using System.Collections.Generic;
using Positron.Data.Interface.Mapas;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// Testes do mapa de variantes de telas do reverso (<see cref="VariantesDoReverso"/>) — as 15 janelas
    /// do original com argumentos no construtor (<c>frmRelatorio_DInterlig(1..11)</c>,
    /// <c>frmRelatorio_DICemig(1..3)</c> e <c>frmTrocaPaineis(bAbre: false)</c>).
    /// </summary>
    public class VariantesDoReversoTests
    {
        [Fact]
        public void AQuantidadeTotalEDe15Variantes()
        {
            Assert.Equal(15, VariantesDoReverso.Quantidade);
            Assert.Equal(15, VariantesDoReverso.Todas.Count);
        }

        [Fact]
        public void AsVariantesEstaoDistribuidasPelosFormulariosCorretos()
        {
            Assert.Equal(11, VariantesDoReverso.DaTela("frmRelatorio_DInterlig").Count);
            Assert.Equal(3, VariantesDoReverso.DaTela("frmRelatorio_DICemig").Count);
            Assert.Single(VariantesDoReverso.DaTela("frmTrocaPaineis"));
            Assert.Empty(VariantesDoReverso.DaTela("TelaInexistente"));
            Assert.Empty(VariantesDoReverso.DaTela(null));
        }

        [Fact]
        public void TodaVarianteApontaParaUmaTelaExistenteNoMapa()
        {
            foreach (VarianteDeTela variante in VariantesDoReverso.Todas)
            {
                Tela telaBase = FormulariosDoReverso.Buscar(variante.Tela);
                Assert.NotNull(telaBase);
                Assert.Equal(variante.Tela, telaBase.Nome);
            }
        }

        [Fact]
        public void TodaVarianteTemComandoLigavelQueAbreJanela()
        {
            foreach (VarianteDeTela variante in VariantesDoReverso.Todas)
            {
                Comando cmd = ComandosDoReverso.Buscar(variante.Comando);
                Assert.NotNull(cmd);
                Assert.True(cmd.AbreJanela, "Comando " + variante.Comando + " deveria abrir janela");
                Assert.True(cmd.Ligavel, "Comando " + variante.Comando + " deveria ser ligável");
                Assert.Equal(variante.Tela, cmd.Janelas[0].Nome);
            }
        }

        [Theory]
        [InlineData("DICHESF", 1, "Diagrama de Interligação CHESF")]
        [InlineData("DICPFL", 2, "Diagrama de Interligação CPFL SERVIÇOS")]
        [InlineData("DICTEEP", 3, "Diagrama de Interligação ISA CTEEP")]
        [InlineData("DIEQUAT", 4, "Diagrama de Interligação EQUATORIAL")]
        [InlineData("DICPFLTR", 5, "Diagrama de Interligação CPFL TRANSMISSÃO")]
        [InlineData("DIEDP", 6, "Diagrama de Interligação EDP ES")]
        [InlineData("DITAESA", 7, "Diagrama de Interligação TAESA")]
        [InlineData("DIFURNAS", 8, "Diagrama de Interligação FURNAS")]
        [InlineData("DICEMIGGTP", 9, "Diagrama de Interligação CEMIG-GT PAINEL")]
        [InlineData("DIENELSP", 10, "Diagrama de Interligação ENEL-SP")]
        [InlineData("DIITAIPU", 11, "Diagrama de Interligação ITAIPU")]
        public void AsVariantesDoRelatorioInterligacaoTemCasosETitulosCorretos(string comando, int caso, string tituloEsperado)
        {
            VarianteDeTela v = VariantesDoReverso.Buscar(comando);
            Assert.NotNull(v);
            Assert.Equal("frmRelatorio_DInterlig", v.Tela);
            Assert.Equal(caso, v.Caso);
            Assert.Equal(tituloEsperado, v.Titulo);
        }

        [Theory]
        [InlineData("DICEMIGGTE", 1, "Diagrama de Interligação CEMIG-GT EQUIP")]
        [InlineData("DICEMIGDP", 2, "Diagrama de Interligação CEMIG-D PAINEL")]
        [InlineData("DICEMIGDE", 3, "Diagrama de Interligação CEMIG-D EQUIP")]
        public void AsVariantesDoRelatorioCemigTemCasosETitulosCorretos(string comando, int caso, string tituloEsperado)
        {
            VarianteDeTela v = VariantesDoReverso.Buscar(comando);
            Assert.NotNull(v);
            Assert.Equal("frmRelatorio_DICemig", v.Tela);
            Assert.Equal(caso, v.Caso);
            Assert.Equal(tituloEsperado, v.Titulo);
        }

        [Fact]
        public void ATrocaPaineisTemArgumentoNomeadoETituloCorreto()
        {
            VarianteDeTela v = VariantesDoReverso.Buscar("TROCAPN");
            Assert.NotNull(v);
            Assert.Equal("frmTrocaPaineis", v.Tela);
            Assert.Equal("new frmTrocaPaineis(bAbre: false)", v.Construcao);
            Assert.Equal(0, v.Caso);
            Assert.Equal("Trocar Painel", v.Titulo);
            Assert.Contains("btTrocaosPaineis", v.ControlesDesabilitados);
        }

        [Fact]
        public void ABuscaEInsensivelAMaiusculasERetornaNuloParaInexistente()
        {
            Assert.NotNull(VariantesDoReverso.Buscar("dichesf"));
            Assert.NotNull(VariantesDoReverso.Buscar("DIFURNAS"));
            Assert.NotNull(VariantesDoReverso.Buscar("trocapn"));
            Assert.Null(VariantesDoReverso.Buscar("COMANDO_INEXISTENTE"));
            Assert.Null(VariantesDoReverso.Buscar(null));
            Assert.Null(VariantesDoReverso.Buscar(string.Empty));
        }

        [Fact]
        public void AplicarVarianteModificaTituloECamposSemAlterarBase()
        {
            Tela telaOriginal = FormulariosDoReverso.Buscar("frmRelatorio_DInterlig");
            Assert.NotNull(telaOriginal);

            VarianteDeTela vChesf = VariantesDoReverso.Buscar("DICHESF");
            Assert.NotNull(vChesf);

            Tela telaAdaptada = vChesf.Aplicar(telaOriginal);
            Assert.NotNull(telaAdaptada);
            Assert.Equal(telaOriginal.Nome, telaAdaptada.Nome);
            Assert.Equal("Diagrama de Interligação CHESF", telaAdaptada.Titulo);

            // Confere que telaOriginal não foi alterada
            Assert.NotEqual(telaOriginal.Titulo, telaAdaptada.Titulo);

            // Verifica campo com visibilidade modificada
            Campo gpCruz = ObterCampo(telaAdaptada, "GroupBoxTipoCruz");
            Assert.NotNull(gpCruz);
            Assert.Equal("False", ObterPropriedade(gpCruz, "Visible"));

            Campo gpCima = ObterCampo(telaAdaptada, "GroupBoxPaineisCima");
            Assert.NotNull(gpCima);
            Assert.Equal("True", ObterPropriedade(gpCima, "Visible"));
            Assert.Equal(12, gpCima.X);
            Assert.Equal(459, gpCima.Y);

            // Verifica controle desabilitado
            Campo btRebate = ObterCampo(telaAdaptada, "btRebateCabos");
            Assert.NotNull(btRebate);
            Assert.Equal("False", ObterPropriedade(btRebate, "Enabled"));

            // Verifica controle habilitado
            Campo btMirror = ObterCampo(telaAdaptada, "btMirrorJumper");
            Assert.NotNull(btMirror);
            Assert.Equal("True", ObterPropriedade(btMirror, "Enabled"));
        }

        [Fact]
        public void AplicarVarianteEmNuloRetornaNulo()
        {
            VarianteDeTela v = VariantesDoReverso.Buscar("TROCAPN");
            Assert.Null(v.Aplicar(null));
        }

        private static Campo ObterCampo(Tela tela, string nome)
        {
            foreach (Campo c in tela.Campos)
            {
                if (string.Equals(c.Nome, nome, StringComparison.OrdinalIgnoreCase))
                {
                    return c;
                }
            }

            return null;
        }

        private static string ObterPropriedade(Campo campo, string chave)
        {
            foreach (Par p in campo.Propriedades)
            {
                if (string.Equals(p.Nome, chave, StringComparison.OrdinalIgnoreCase))
                {
                    return p.Valor;
                }
            }

            return null;
        }
    }
}

using System.Collections.Generic;
using Positron.Data.Fiacao;
using Positron.Data.Layout;
using Positron.Data.Modelos;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// `Dispositivos4F` — o trecho do `frmCompilarFiacao` do original que grava
    /// um dispositivo por bloco `P` e um por bloco de máscara `M`.
    /// </summary>
    public class Dispositivos4FTests
    {
        private static LayoutPosicoes Posicoes(params PosicaoLayout[] posicoes)
        {
            return LayoutPosicoes.Ler(posicoes);
        }

        [Fact]
        public void Gera_linha_do_bloco_P_com_modelo_e_layout()
        {
            List<DispositivoFiacao> blocos = new List<DispositivoFiacao>
            {
                new DispositivoFiacao
                {
                    Tipo = "P", Nome1 = "D1", Nome2 = "A", Alternativo = "ALT",
                    Painel = 1, Handle = "H1", Layer = "PAG1", IndexModelo = 7,
                },
            };

            Dictionary<int, BlocoDoModelo> deDispositivo = new Dictionary<int, BlocoDoModelo>
            {
                { 7, new BlocoDoModelo { BlocoTopografico = "TOPO1", BlocoLayout = "LAY1" } },
            };

            List<Dispositivo4F> linhas = Dispositivos4FGerador.Gerar(
                blocos,
                new List<int> { 1 },
                deDispositivo,
                new Dictionary<int, BlocoDoModelo>(),
                Posicoes(new PosicaoLayout { Painel = 1, Tag = "D1/A", PosicaoNum = 3, Ordem = 5 }));

            Dispositivo4F linha = Assert.Single(linhas);
            Assert.Equal("P", linha.Tipo);
            Assert.Equal((short)1, linha.Painel);
            Assert.Equal("D1/A", linha.Tag);
            Assert.Equal("ALT", linha.Alternativo);
            Assert.Equal("H1", linha.Handle);
            Assert.Equal("PAG1", linha.Pagina);
            Assert.Equal("TOPO1", linha.BlocoTopografico);
            Assert.Equal("LAY1", linha.BlocoLayout);
            Assert.Equal(3, linha.PosicaoNum);
            Assert.Equal(5, linha.Ordem);
        }

        [Fact]
        public void Gera_linha_da_mascara_M_com_modelo_de_mascara()
        {
            List<DispositivoFiacao> blocos = new List<DispositivoFiacao>
            {
                new DispositivoFiacao
                {
                    Tipo = "M", Nome1 = "M1", Painel = 2, Handle = "H2",
                    Layer = "PAG2", IndexModelo = 4,
                },
            };

            Dictionary<int, BlocoDoModelo> deMascara = new Dictionary<int, BlocoDoModelo>
            {
                { 4, new BlocoDoModelo { BlocoTopografico = "TOPO-M", BlocoLayout = "LAY-M" } },
            };

            List<Dispositivo4F> linhas = Dispositivos4FGerador.Gerar(
                blocos,
                new List<int> { 2 },
                new Dictionary<int, BlocoDoModelo>(),
                deMascara,
                LayoutPosicoes.Vazia);

            Dispositivo4F linha = Assert.Single(linhas);
            Assert.Equal("M", linha.Tipo);
            Assert.Equal("M1", linha.Tag);
            Assert.Equal("TOPO-M", linha.BlocoTopografico);
            Assert.Equal("LAY-M", linha.BlocoLayout);
            Assert.Equal(0, linha.PosicaoNum);
            Assert.Equal(0, linha.Ordem);
        }

        [Fact]
        public void Pula_complementar_painel_fora_de_uso_e_tipos_que_nao_geram_dispositivo()
        {
            List<DispositivoFiacao> blocos = new List<DispositivoFiacao>
            {
                new DispositivoFiacao { Tipo = "P", Nome1 = "COMP", Painel = 1, Complementar = true },
                new DispositivoFiacao { Tipo = "P", Nome1 = "FORA", Painel = 9 },
                new DispositivoFiacao { Tipo = "E", Nome1 = "PORTA", Painel = 1 },
                new DispositivoFiacao { Tipo = "A", Nome1 = "AUX", Painel = 1 },
                new DispositivoFiacao { Tipo = "I", Nome1 = "IMP", Painel = 1 },
                new DispositivoFiacao { Tipo = "B", Nome1 = "BORNE", Painel = 1 },
                new DispositivoFiacao { Tipo = "P", Nome1 = "OK", Painel = 1 },
            };

            List<Dispositivo4F> linhas = Dispositivos4FGerador.Gerar(
                blocos,
                new List<int> { 1 },
                new Dictionary<int, BlocoDoModelo>(),
                new Dictionary<int, BlocoDoModelo>(),
                LayoutPosicoes.Vazia);

            Dispositivo4F linha = Assert.Single(linhas);
            Assert.Equal("OK", linha.Tag);
        }

        [Fact]
        public void Sem_modelo_as_colunas_de_bloco_e_posicao_ficam_vazias()
        {
            List<DispositivoFiacao> blocos = new List<DispositivoFiacao>
            {
                new DispositivoFiacao { Tipo = "P", Nome1 = "SEM", Painel = 1, IndexModelo = 0 },
            };

            List<Dispositivo4F> linhas = Dispositivos4FGerador.Gerar(
                blocos,
                new List<int> { 1 },
                new Dictionary<int, BlocoDoModelo>(),
                new Dictionary<int, BlocoDoModelo>(),
                LayoutPosicoes.Vazia);

            Dispositivo4F linha = Assert.Single(linhas);
            Assert.Null(linha.BlocoTopografico);
            Assert.Null(linha.BlocoLayout);
            Assert.Equal(0, linha.PosicaoNum);
            Assert.Equal(0, linha.Ordem);
        }

        [Fact]
        public void Gravar_duas_vezes_nao_duplica_e_lote_vazio_limpa_a_revisao()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);
                List<Dispositivo4F> linhas = new List<Dispositivo4F>
                {
                    new Dispositivo4F { Tipo = "P", Painel = 1, Tag = "D1", Handle = "H1", Pagina = "PAG1" },
                    new Dispositivo4F { Tipo = "M", Painel = 1, Tag = "M1", Handle = "H2", Pagina = "PAG1" },
                };

                store.InserirDispositivos(linhas, "R0", 1);
                Assert.Equal(2, store.DispositivosDaRevisao(1, "R0").Count);

                store.InserirDispositivos(linhas, "R0", 1);
                Assert.Equal(2, store.DispositivosDaRevisao(1, "R0").Count);

                // Outra revisão não é tocada.
                store.InserirDispositivos(linhas, "R1", 1);
                Assert.Equal(2, store.DispositivosDaRevisao(1, "R1").Count);

                // Desenho sem dispositivo nesta revisão: o banco reflete o desenho.
                store.InserirDispositivos(new List<Dispositivo4F>(), "R0", 1);
                Assert.Empty(store.DispositivosDaRevisao(1, "R0"));
                Assert.Equal(2, store.DispositivosDaRevisao(1, "R1").Count);
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }
    }
}

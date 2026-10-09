using System;
using System.Collections.Generic;
using Positron.Contract;
using Positron.Data;
using Positron.Data.Fiacao;
using Positron.Data.Interligacao;
using Positron.Data.Modelos;
using Xunit;

namespace Positron.Data.Tests
{
    public class VerificadorProjetoTests
    {
        [Fact]
        public void Fiacao_aponta_sem_tag_terminal_indefinido_e_potencial_invalido()
        {
            List<FiacaoRow> linhas = new List<FiacaoRow>
            {
                new FiacaoRow { Painel = 1, Potencial = 3, Tag = "D1", Terminal = "5" },
                new FiacaoRow { Painel = 1, Potencial = 3, Tag = null, Terminal = "6" },   // sem tag
                new FiacaoRow { Painel = 1, Potencial = 4, Tag = "D2", Terminal = "?" },   // indefinido
                new FiacaoRow { Painel = 1, Potencial = 5, Tag = "D3", Terminal = "0" },   // "0" também é indefinido
                new FiacaoRow { Painel = 1, Potencial = 0, Tag = "D4", Terminal = "7" },   // potencial 0
            };

            List<Problema> problemas = VerificadorProjeto.VerificarFiacao(linhas);

            Assert.Contains(problemas, p => p.Tipo == TipoProblema.SemTag);
            Assert.Contains(problemas, p => p.Tipo == TipoProblema.PotencialInvalido);
            Assert.Equal(2, problemas.FindAll(p => p.Tipo == TipoProblema.TerminalIndefinido).Count);
        }

        [Fact]
        public void Fiacao_aponta_terminal_duplicado_no_mesmo_potencial()
        {
            List<FiacaoRow> linhas = new List<FiacaoRow>
            {
                new FiacaoRow { Painel = 1, Potencial = 3, Tag = "D1", Terminal = "5", Handle = "H1" },
                new FiacaoRow { Painel = 1, Potencial = 3, Tag = "D2", Terminal = "5", Handle = "H2" },
                new FiacaoRow { Painel = 2, Potencial = 3, Tag = "D3", Terminal = "5", Handle = "H3" },  // outro painel: ok
            };

            List<Problema> problemas = VerificadorProjeto.VerificarFiacao(linhas);

            Problema problema = Assert.Single(problemas);
            Assert.Equal(TipoProblema.TerminalDuplicado, problema.Tipo);
            Assert.Equal("H2", problema.Identificador);
        }

        [Fact]
        public void Interligacao_aponta_cabo_ponta_e_veia()
        {
            List<Interligacao4Row> linhas = new List<Interligacao4Row>
            {
                // Trecho completo: nada a apontar.
                new Interligacao4Row { Tag_Cabo = "C1", Num_Veia = 1, Tag1 = "A", Terminal1 = "1", Tag2 = "B", Terminal2 = "2" },
                // Cabo ausente, ponta 1 sem tag, veia zerada e terminal indefinido na ponta 2.
                new Interligacao4Row { Tag_Cabo = null, Num_Veia = 0, Tag1 = null, Terminal1 = "1", Tag2 = "B", Terminal2 = "?" },
            };

            List<Problema> problemas = VerificadorProjeto.VerificarInterligacao(linhas);

            Assert.Contains(problemas, p => p.Tipo == TipoProblema.CaboIndefinido);
            Assert.Contains(problemas, p => p.Tipo == TipoProblema.PontoSemTag);
            Assert.Contains(problemas, p => p.Tipo == TipoProblema.VeiaIndefinida);
            Assert.Contains(problemas, p => p.Tipo == TipoProblema.TerminalIndefinido && p.Detalhe.Contains("ponta 2"));
        }

        [Fact]
        public void Modelos_apontam_regua_borne_terminal_e_duplicado()
        {
            List<Portas4FRow> portas = new List<Portas4FRow>
            {
                new Portas4FRow { IndexModelo = 7, NomeModelo = "CONT7", Regua = "R1", Borne = "1", Terminal = "2" },
                new Portas4FRow { IndexModelo = 8, NomeModelo = "CONT8", Regua = null, Borne = null, Terminal = "3" },
            };
            List<Bornes4FRow> bornes = new List<Bornes4FRow>
            {
                new Bornes4FRow { Regua = "R1", IndexRegua = 1, Borne = "1" },
                new Bornes4FRow { Regua = null, IndexRegua = 0, Borne = null },
            };
            List<Contatos4FRow> contatos = new List<Contatos4FRow>
            {
                new Contatos4FRow { IndexModelo = 7, NomeModelo = "C7", Terminal = "1" },
                new Contatos4FRow { IndexModelo = 7, NomeModelo = "C7", Terminal = "1" },  // duplicado
                new Contatos4FRow { IndexModelo = 7, NomeModelo = "C7", Terminal = "0" },  // indefinido
            };

            List<Problema> problemas = VerificadorProjeto.VerificarModelos(portas, bornes, contatos);

            Assert.Contains(problemas, p => p.Tipo == TipoProblema.ReguaAusente && p.Tabela == "Portas4F");
            Assert.Contains(problemas, p => p.Tipo == TipoProblema.SemBorne && p.Tabela == "Bornes4F");
            Assert.Contains(problemas, p => p.Tipo == TipoProblema.TerminalIndefinido && p.Tabela == "Contatos4F");
            Assert.Contains(problemas, p => p.Tipo == TipoProblema.TerminalDuplicado && p.Tabela == "Contatos4F");
        }

        [Fact]
        public void Fiacao_da_revisao_le_o_que_foi_gravado()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);
                FiacaoProjetor projetor = new FiacaoProjetor(store);
                projetor.Projetar(
                    new List<PontoFiacao>
                    {
                        new PontoFiacao { Painel = 1, Potencial = 3, X = 0.0, Y = 0.0, Layer = "PAG1", Terminal = "5", Tag = "D1" },
                    },
                    new ContextoProjecao { Dwg = 4, Revisao = "R0", Criador = "ana", Data = DateTime.Now },
                    null,
                    null,
                    null,
                    null);

                Assert.Single(store.FiacaoDaRevisao(4, "R0"));
                Assert.Empty(store.FiacaoDaRevisao(4, "R1"));
                Assert.Empty(store.FiacaoDaRevisao(9, "R0"));
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }

        [Fact]
        public void Interligacao_e_modelos_da_revisao_lem_o_que_foi_gravado()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);

                store.InserirInterligacao(new List<TrechoInterligacao>
                {
                    new TrechoInterligacao
                    {
                        Tag_Cabo = "C1", NumVeia = 1, Revisao = "R0", Dwg = 4,
                        Tag1 = "A", Terminal1 = "1", Tag2 = "B", Terminal2 = "2", Data = DateTime.Now,
                    },
                });

                store.InserirPortas(
                    new List<Porta4F>
                    {
                        new Porta4F { IndexModelo = 7, NomeModelo = "CONT7", Regua = "R1", Borne = "1", Terminal = "2", TerminalNum = 2.0 },
                    },
                    "R0", 4);

                store.InserirBornes(
                    new List<Borne4F>
                    {
                        new Borne4F { Painel = 1, IndexRegua = 1, Regua = "R1", Borne = "1", Ordem = 1.0 },
                    },
                    "R0", 4);

                store.InserirContatos(
                    new List<Contato4F>
                    {
                        new Contato4F { IndexModelo = 7, NomeModelo = "CONT7", Terminal = "1", TerminalNum = 1.0 },
                    },
                    "R0", 4);

                Assert.Single(store.InterligacaoDaRevisao(4, "R0"));
                Assert.Single(store.PortasDaRevisao(4, "R0"));
                Assert.Single(store.BornesDaRevisao(4, "R0"));
                Assert.Single(store.ContatosDaRevisao(4, "R0"));

                Assert.Empty(store.InterligacaoDaRevisao(4, "R1"));
                Assert.Empty(store.PortasDaRevisao(4, "R1"));
                Assert.Empty(store.BornesDaRevisao(9, "R0"));
                Assert.Empty(store.ContatosDaRevisao(4, "R1"));
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }
    }
}

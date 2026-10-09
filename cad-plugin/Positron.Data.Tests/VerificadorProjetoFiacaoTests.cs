using System;
using System.Collections.Generic;
using Positron.Contract;
using Positron.Data;
using Positron.Data.Fiacao;
using Xunit;

namespace Positron.Data.Tests
{
    public class VerificadorProjetoFiacaoTests
    {
        [Fact]
        public void Aponta_sem_tag_terminal_indefinido_e_potencial_invalido()
        {
            List<FiacaoRow> linhas = new List<FiacaoRow>
            {
                new FiacaoRow { Painel = 1, Potencial = 3, Tag = "D1", Terminal = "5" },
                new FiacaoRow { Painel = 1, Potencial = 3, Tag = null, Terminal = "6" },   // sem tag
                new FiacaoRow { Painel = 1, Potencial = 4, Tag = "D2", Terminal = "?" },   // indefinido
                new FiacaoRow { Painel = 1, Potencial = 0, Tag = "D3", Terminal = "7" },   // potencial 0
            };

            List<ProblemaFiacao> problemas = VerificadorProjetoFiacao.Verificar(linhas);

            Assert.Contains(problemas, p => p.Tipo == TipoProblemaFiacao.SemTag);
            Assert.Contains(problemas, p => p.Tipo == TipoProblemaFiacao.TerminalIndefinido);
            Assert.Contains(problemas, p => p.Tipo == TipoProblemaFiacao.PotencialInvalido);
        }

        [Fact]
        public void Aponta_terminal_duplicado_no_mesmo_potencial()
        {
            List<FiacaoRow> linhas = new List<FiacaoRow>
            {
                new FiacaoRow { Painel = 1, Potencial = 3, Tag = "D1", Terminal = "5" },
                new FiacaoRow { Painel = 1, Potencial = 3, Tag = "D2", Terminal = "5" },
                new FiacaoRow { Painel = 2, Potencial = 3, Tag = "D3", Terminal = "5" },  // outro painel: ok
            };

            List<ProblemaFiacao> problemas = VerificadorProjetoFiacao.Verificar(linhas);

            ProblemaFiacao problema = Assert.Single(problemas);
            Assert.Equal(TipoProblemaFiacao.TerminalDuplicado, problema.Tipo);
            Assert.Equal("D2", problema.Tag);
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
    }
}

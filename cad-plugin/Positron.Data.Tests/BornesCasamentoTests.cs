using System.Collections.Generic;
using Positron.Data.Bornes;
using Xunit;

namespace Positron.Data.Tests
{
    public class BornesCasamentoTests
    {
        private static PontoBorne Borne()
        {
            return new PontoBorne
            {
               Layer = "P1",
                Painel = 1,
                X = 0.0,
                Y = 0.0,
                NomeBloco = "BLK",
                TemBounds = true,
                MinX = 9.0,
                MinY = 4.0,
                MaxX = 11.0,
                MaxY = 6.0,
                Terminal = "T1",
                NomeRegua = "R1",
            };
        }

        [Fact]
        public void Ponto_dentro_dos_bounds_casa_pela_tabela_de_deslocamento()
        {
            // Inserção em (0,0), mas o ponto de ligação do bloco é (10,5):
            // o ponto de fiação em (10,1;5,0) só casa via a tabela.
            PontoBorne borne = Borne();
            TabelaDeslocamentoBlocos tabela = TabelaDeslocamentoBlocos.Ler(new[]
            {
                new DeslocamentoBloco { Nome = "BLK", X = 10.0, Y = 5.0 },
            });

            PontoBorne casado = CasamentoBorne.Proximo(
                10.1, 5.0, "P1", 1, new List<PontoBorne> { borne }, CasamentoBorne.Tolerancia, tabela);

            Assert.Same(borne, casado);
        }

        [Fact]
        public void Sem_tabela_o_pe_de_insercao_nao_alcanca()
        {
            // Mesmo sensor, sem tabela: a distância é a do pé de inserção (0,0).
            PontoBorne borne = Borne();

            PontoBorne casado = CasamentoBorne.Proximo(
                10.1, 5.0, "P1", 1, new List<PontoBorne> { borne }, CasamentoBorne.Tolerancia, null);

            Assert.Null(casado);
        }

        [Fact]
        public void Ponto_fora_dos_bounds_nao_casa()
        {
            // Ponto longe da bounding-box (±0,25) — o filtro de bounds rejeita,
            // mesmo que o deslocamento fosse trazer perto.
            PontoBorne borne = Borne();
            TabelaDeslocamentoBlocos tabela = TabelaDeslocamentoBlocos.Ler(new[]
            {
                new DeslocamentoBloco { Nome = "BLK", X = 10.0, Y = 5.0 },
            });

            PontoBorne casado = CasamentoBorne.Proximo(
                40.0, 40.0, "P1", 1, new List<PontoBorne> { borne }, CasamentoBorne.Tolerancia, tabela);

            Assert.Null(casado);
        }

        [Fact]
        public void Margem_de_025_em_torno_dos_bounds_aceita()
        {
            // Sem deslocamento, o pé de inserção cai em (9,4) (canto dos bounds).
            // O ponto a 0,2 para fora ainda entra pela margem de 0,25.
            PontoBorne borne = new PontoBorne
            {
                Layer = "P1",
                Painel = 1,
                X = 9.0,
                Y = 4.0,
                NomeBloco = "BLK",
                TemBounds = true,
                MinX = 9.0,
                MinY = 4.0,
                MaxX = 11.0,
                MaxY = 6.0,
            };

            PontoBorne casado = CasamentoBorne.Proximo(
                8.9, 4.0, "P1", 1, new List<PontoBorne> { borne });

            Assert.Same(borne, casado);
        }

        [Fact]
        public void Por_painel_diferente_nao_casa()
        {
            PontoBorne borne = Borne();
            PontoBorne casado = CasamentoBorne.Proximo(
                0.0, 0.0, "P1", 9, new List<PontoBorne> { borne });
            Assert.Null(casado);
        }
    }
}

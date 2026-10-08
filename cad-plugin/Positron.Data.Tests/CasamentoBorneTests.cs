using System.Collections.Generic;
using Positron.Data.Bornes;
using Xunit;

namespace Positron.Data.Tests
{
    public class CasamentoBorneTests
    {
        private static PontoBorne Borne(string handle, double x, double y, string layer, short painel)
        {
            return new PontoBorne { Handle = handle, X = x, Y = y, Layer = layer, Painel = painel };
        }

        [Fact]
        public void Escolhe_o_borne_mais_proximo_dentro_da_tolerancia()
        {
            List<PontoBorne> bornes = new List<PontoBorne>
            {
                Borne("A", 0.40, 0.0, "PAG1", 1),
                Borne("B", 0.10, 0.0, "PAG1", 1),
                Borne("C", 3.0, 0.0, "PAG1", 1),
            };

            PontoBorne casado = CasamentoBorne.Proximo(0.0, 0.0, "PAG1", 1, bornes);
            Assert.NotNull(casado);
            Assert.Equal("B", casado.Handle);
        }

        [Fact]
        public void Nao_casa_fora_da_tolerancia()
        {
            List<PontoBorne> bornes = new List<PontoBorne> { Borne("A", 3.0, 0.0, "PAG1", 1) };
            Assert.Null(CasamentoBorne.Proximo(0.0, 0.0, "PAG1", 1, bornes));
        }

        [Fact]
        public void Respeita_layer_e_painel()
        {
            List<PontoBorne> bornes = new List<PontoBorne>
            {
                Borne("outro-layer", 0.1, 0.0, "PAG2", 1),
                Borne("outro-painel", 0.1, 0.0, "PAG1", 9),
                Borne("bom", 0.1, 0.0, "PAG1", 1),
            };

            PontoBorne casado = CasamentoBorne.Proximo(0.0, 0.0, "PAG1", 1, bornes);
            Assert.Equal("bom", casado.Handle);
        }

        [Fact]
        public void Painel_desconhecido_nao_restringe()
        {
            // Borne com painel 0 (régua fora do dicionário) casa mesmo assim.
            List<PontoBorne> bornes = new List<PontoBorne> { Borne("A", 0.1, 0.0, "PAG1", 0) };
            Assert.NotNull(CasamentoBorne.Proximo(0.0, 0.0, "PAG1", 5, bornes));
        }
    }
}

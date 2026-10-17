using System.Collections.Generic;
using System.Linq;
using Positron.Data.Paginas;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>Os ramos `P` do <c>clsApagar.ApagarDerivados</c> (promoveComplementar e ApagaContatosModeloDispositivo).</summary>
    public class ApagarDispositivoTests
    {
        private static ApagarDispositivo.Bloco P(string handle, bool compl = false, string n1 = "A", string n2 = "B", string alt = "", short painel = 1)
        {
            return new ApagarDispositivo.Bloco
            {
                Handle = handle,
                Tipo = "P",
                Nome1 = n1,
                Nome2 = n2,
                Alternativo = alt,
                Painel = painel,
                Complementar = compl,
            };
        }

        [Fact]
        public void Promove_o_primeiro_complementar_de_mesmo_nome()
        {
            ApagarDispositivo.Bloco apagada = P("P1");
            string promovida = ApagarDispositivo.HandleAPromover(apagada, new List<ApagarDispositivo.Bloco>
            {
                P("P1"),
                P("C1", compl: true, n1: "a", n2: "b"),
                P("C2", compl: true),
            });

            Assert.Equal("C1", promovida);
        }

        [Fact]
        public void Nao_promove_quando_a_apagada_e_complementar()
        {
            Assert.Null(ApagarDispositivo.HandleAPromover(P("P1", compl: true), new List<ApagarDispositivo.Bloco> { P("C1", compl: true) }));
        }

        [Fact]
        public void Nao_promove_sem_complementar_de_mesmo_nome_ou_alternativo_diferente()
        {
            Assert.Null(ApagarDispositivo.HandleAPromover(P("P1"), new List<ApagarDispositivo.Bloco>
            {
                P("C1", compl: true, n1: "X"),
                P("C2", compl: true, alt: "ALT"),
                P("N3"),
            }));
        }

        [Fact]
        public void Nao_promove_o_proprio_bloco()
        {
            Assert.Null(ApagarDispositivo.HandleAPromover(P("P1"), new List<ApagarDispositivo.Bloco> { P("P1", compl: true) }));
        }

        [Fact]
        public void Contatos_do_modelo_saem_com_o_principal_do_mesmo_nome_no_painel_e_complementares()
        {
            ApagarDispositivo.Bloco apagada = P("P2");
            IReadOnlyList<string> handles = ApagarDispositivo.HandlesDosContatosDoModelo(apagada, new List<ApagarDispositivo.Bloco>
            {
                P("P2"),
                P("C2", compl: true),
                P("C3", compl: true, painel: 2),
                P("N4", compl: false),
                P("X5", compl: true, n1: "Outro"),
            });

            Assert.Equal(new[] { "C2" }, handles.ToArray());
        }

        [Fact]
        public void Contato_auxiliar_e_bloco_de_modelo_saem_quando_apontam_para_a_apagada()
        {
            ApagarDispositivo.Bloco apagada = P("P2");
            IReadOnlyList<string> handles = ApagarDispositivo.HandlesDosContatosDoModelo(apagada, new List<ApagarDispositivo.Bloco>
            {
                new ApagarDispositivo.Bloco { Handle = "AX", Tipo = "A", HandleBob = "p2" },
                new ApagarDispositivo.Bloco { Handle = "AY", Tipo = "A", HandleBob = "OUTRO" },
                new ApagarDispositivo.Bloco { Handle = "MD", Tipo = "", HandleBob = "P2" },
                new ApagarDispositivo.Bloco { Handle = "MO", Tipo = "", HandleBob = null },
            });

            Assert.Equal(new[] { "AX", "MD" }, handles.ToArray());
        }

        [Fact]
        public void Sem_blocos_ou_sem_apagada_nao_ha_nada_a_apagar()
        {
            Assert.Empty(ApagarDispositivo.HandlesDosContatosDoModelo(null, new List<ApagarDispositivo.Bloco>()));
            Assert.Empty(ApagarDispositivo.HandlesDosContatosDoModelo(P("P1"), null));
            Assert.Null(ApagarDispositivo.HandleAPromover(null, new List<ApagarDispositivo.Bloco>()));
        }
    }
}

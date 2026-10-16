using System.Collections.Generic;
using System.Linq;
using Positron.Data.Fiacao;
using Positron.Data.Paginas;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>O plano do <c>clsMascara.ApagaAMascara</c> e os layouts de XData que ele regrava.</summary>
    public class ApagarMascaraTests
    {
        private static EstadoDaMascara Estado(string n1 = "A", string n2 = "B", string alt = "", short painel = 1, bool compl = false)
        {
            return new EstadoDaMascara
            {
                Nome1 = n1,
                Nome2 = n2,
                Alternativo = alt,
                Painel = painel,
                IndexModelo = 7,
                Complementar = compl,
                HandleMascPrincipal = "H0",
                Topografico = "TOPO",
                Layout = "LAY",
                ILM1 = 11,
                ILM2 = 22,
            };
        }

        private static ApagarMascara.Candidata Cand(string handle, EstadoDaMascara estado, string mod = "", string fab = "", string desc = "")
        {
            return new ApagarMascara.Candidata { Handle = handle, Estado = estado, Modelo = mod, Fabricante = fab, Descricao = desc };
        }

        [Fact]
        public void Mascara_complementar_nao_leva_nada()
        {
            Assert.Null(ApagarMascara.Planejar("A1", Estado(compl: true), "m", "f", "d", new List<ApagarMascara.Candidata>()));
        }

        [Fact]
        public void Sem_outra_igual_nao_ha_sucessora()
        {
            ApagarMascara.Plano plano = ApagarMascara.Planejar("A1", Estado(), "m", "f", "d", new List<ApagarMascara.Candidata>
            {
                Cand("A1", Estado()),
                Cand("B2", Estado(n1: "OUTRA")),
                Cand("C3", Estado(painel: 2)),
            });

            Assert.Equal(string.Empty, plano.Sucessora);
            Assert.Empty(plano.Gravacoes);
        }

        [Fact]
        public void A_primeira_igual_vira_a_principal_com_o_estado_da_apagada()
        {
            ApagarMascara.Plano plano = ApagarMascara.Planejar("A1", Estado(), "MOD", "FAB", "DESC", new List<ApagarMascara.Candidata>
            {
                Cand("A1", Estado()),
                Cand("b2", Estado(n1: "a", n2: "b")),
            });

            Assert.Equal("b2", plano.Sucessora);
            ApagarMascara.Gravacao g = Assert.Single(plano.Gravacoes);
            Assert.Equal("b2", g.Handle);
            Assert.Equal("H0", g.Estado.HandleMascPrincipal);
            Assert.Equal(11, g.Estado.ILM1);
            Assert.Equal("TOPO", g.Estado.Topografico);
        }

        [Fact]
        public void A_principal_ganha_os_atributos_que_estavam_vazios_com_a_visibilidade_do_original()
        {
            ApagarMascara.Plano plano = ApagarMascara.Planejar("A1", Estado(), "MOD", "FAB", "DESC", new List<ApagarMascara.Candidata>
            {
                Cand("B2", Estado(), mod: "", fab: "ja", desc: ""),
            });

            List<ApagarMascara.EdicaoDeAtributo> atributos = plano.Gravacoes[0].Atributos;
            Assert.Equal(2, atributos.Count);
            Assert.Equal("MODELO", atributos[0].Tag);
            Assert.Equal("MOD", atributos[0].Valor);
            Assert.True(atributos[0].Visivel);
            Assert.Equal("DESCRICAO", atributos[1].Tag);
            Assert.False(atributos[1].Visivel);
        }

        [Fact]
        public void As_demais_apontam_para_a_sucessora_e_perdem_lm_topografico_e_layout()
        {
            ApagarMascara.Plano plano = ApagarMascara.Planejar("A1", Estado(), "MOD", "FAB", "DESC", new List<ApagarMascara.Candidata>
            {
                Cand("B2", Estado()),
                Cand("C3", Estado()),
            });

            Assert.Equal("B2", plano.Sucessora);
            Assert.Equal(2, plano.Gravacoes.Count);
            ApagarMascara.Gravacao segunda = plano.Gravacoes[1];
            Assert.Equal("C3", segunda.Handle);
            Assert.Equal("B2", segunda.Estado.HandleMascPrincipal);
            Assert.Equal(0, segunda.Estado.ILM1);
            Assert.Equal(0, segunda.Estado.ILM2);
            Assert.Equal(string.Empty, segunda.Estado.Topografico);
            Assert.Equal(string.Empty, segunda.Estado.Layout);
            Assert.Empty(segunda.Atributos);
        }

        [Fact]
        public void Nas_demais_o_teste_de_atributo_vazio_olha_a_apagada_como_o_original()
        {
            ApagarMascara.Plano plano = ApagarMascara.Planejar("A1", Estado(), "", "FAB", "", new List<ApagarMascara.Candidata>
            {
                Cand("B2", Estado()),
                Cand("C3", Estado()),
            });

            List<ApagarMascara.EdicaoDeAtributo> atributos = plano.Gravacoes[1].Atributos;
            Assert.Equal(new[] { "MODELO", "DESCRICAO" }, atributos.Select(a => a.Tag).ToArray());
            Assert.All(atributos, a => Assert.False(a.Visivel));
            Assert.All(atributos, a => Assert.Equal(string.Empty, a.Valor));
        }

        [Fact]
        public void Porta_ou_definicao_da_mascara_sai_sem_sucessora_e_reaponta_com_ela()
        {
            bool apagar;
            Assert.Null(ApagarMascara.NovoHandleDaMascara("a1", "A1", "", out apagar));
            Assert.True(apagar);

            Assert.Equal("B2", ApagarMascara.NovoHandleDaMascara("a1", "A1", "B2", out apagar));
            Assert.False(apagar);

            Assert.Null(ApagarMascara.NovoHandleDaMascara("X9", "A1", "B2", out apagar));
            Assert.False(apagar);

            Assert.Null(ApagarMascara.NovoHandleDaMascara("", "", "B2", out apagar));
            Assert.False(apagar);
        }

        [Fact]
        public void Xdata_da_mascara_tem_29_valores_e_volta_igual()
        {
            EstadoDaMascara original = Estado(compl: true);
            IReadOnlyList<TypedXData> valores = original.ParaValores("usr", "hoje", new object());

            Assert.Equal(29, valores.Count);
            Assert.Equal(-1, (short)valores[13].Valor);
            Assert.Equal(1011, valores[19].Codigo);

            EstadoDaMascara lido;
            Assert.True(EstadoDaMascara.Ler(valores, out lido));
            Assert.Equal("A", lido.Nome1);
            Assert.Equal("B", lido.Nome2);
            Assert.Equal((short)1, lido.Painel);
            Assert.Equal(7, lido.IndexModelo);
            Assert.True(lido.Complementar);
            Assert.Equal("H0", lido.HandleMascPrincipal);
            Assert.Equal("TOPO", lido.Topografico);
            Assert.Equal("LAY", lido.Layout);
            Assert.Equal(11, lido.ILM1);
            Assert.Equal(22, lido.ILM2);
        }

        [Fact]
        public void Xdata_da_porta_tem_18_valores_e_volta_igual()
        {
            EstadoDaPorta porta = new EstadoDaPorta
            {
                Nome1 = "N1",
                Nome2 = "N2",
                HandleDaMascara = "AA",
                IndiceDoModelo = 3,
                IndiceDaPorta = 4,
                HandleDaDefinicao = "DD",
                ChavePrimaria = "CP",
                Alternativo = "ALT",
            };

            IReadOnlyList<TypedXData> valores = porta.ParaValores("usr", "hoje");
            Assert.Equal(18, valores.Count);

            EstadoDaPorta lida;
            Assert.True(EstadoDaPorta.Ler(valores, out lida));
            Assert.Equal("AA", lida.HandleDaMascara);
            Assert.Equal(3, lida.IndiceDoModelo);
            Assert.Equal(4, lida.IndiceDaPorta);
            Assert.Equal("DD", lida.HandleDaDefinicao);
            Assert.Equal("CP", lida.ChavePrimaria);
            Assert.Equal("ALT", lida.Alternativo);
        }

        [Fact]
        public void Xdata_da_definicao_tem_5_valores_e_aceita_o_app_name_legado()
        {
            EstadoDaDefinicao def = new EstadoDaDefinicao { HandleDaMascara = "AA", IndiceDoModelo = 1, IndiceDaPorta = 2, HandleDaPorta = "PP" };
            IReadOnlyList<TypedXData> valores = def.ParaValores();
            Assert.Equal(5, valores.Count);

            EstadoDaDefinicao lida;
            Assert.True(EstadoDaDefinicao.Ler(valores, out lida));
            Assert.Equal("PP", lida.HandleDaPorta);

            List<TypedXData> legado = new List<TypedXData>(valores);
            legado[0] = new TypedXData(1001, "DEFINICAO");
            Assert.True(EstadoDaDefinicao.Ler(legado, out lida));
            Assert.Equal("AA", lida.HandleDaMascara);
        }

        [Fact]
        public void Registro_que_nao_e_mascara_nao_le()
        {
            EstadoDaMascara estado;
            List<TypedXData> curto = new List<TypedXData> { new TypedXData(1001, "Dispositivo"), new TypedXData(1000, "M") };
            Assert.False(EstadoDaMascara.Ler(curto, out estado));
            Assert.False(EstadoDaMascara.Ler(null, out estado));

            IReadOnlyList<TypedXData> porta = new EstadoDaPorta().ParaValores("u", "d");
            Assert.False(EstadoDaMascara.Ler(porta, out estado));
        }
    }
}

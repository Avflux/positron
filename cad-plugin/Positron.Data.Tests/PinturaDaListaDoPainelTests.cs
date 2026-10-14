using System.Collections.Generic;
using Positron.Data.Materiais;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// A pintura da grade do <c>ATINDEP</c> (rodada 154): o <c>MesclaDGDisp</c> do original — a cor
    /// das células 3–5 por origem da linha (desenho/avulso), a dica e o <c>ErrorText</c> do material.
    /// </summary>
    public class PinturaDaListaDoPainelTests
    {
        private static readonly IReadOnlyDictionary<int, MaterialDoCatalogo> Catalogo =
            new Dictionary<int, MaterialDoCatalogo> { { 461, new MaterialDoCatalogo { CodigoInterno = 461 } } };

        private static LinhaDoItemNaGrade Linha(int material, bool avulso, string handle)
        {
            return new LinhaDoItemNaGrade { Tag = "X", IndiceMaterial = material, Avulso = avulso, Handle = handle };
        }

        [Fact]
        public void A_linha_do_desenho_com_material_do_catalogo_e_limao_sem_erro()
        {
            PinturaDaLinha pintura = PinturaDaListaDoPainel.Pintar(Linha(461, false, "5A3E"), Catalogo);

            Assert.Equal(CorDaCelula.Limao, pintura.Fundo);
            Assert.Null(pintura.FundoDoMaterial);
            Assert.Equal("Dispositivo Independente", pintura.Dica);
            Assert.Equal(string.Empty, pintura.Erro);
        }

        [Fact]
        public void O_avulso_e_ciano_e_ganha_a_dica_de_avulso()
        {
            PinturaDaLinha pintura = PinturaDaListaDoPainel.Pintar(Linha(461, true, string.Empty), Catalogo);

            Assert.Equal(CorDaCelula.Ciano, pintura.Fundo);
            Assert.Equal("Dispositivo Avulso", pintura.Dica);
            Assert.Equal(string.Empty, pintura.Erro);
        }

        [Fact]
        public void A_linha_sem_handle_e_nao_avulsa_fica_cinza_sem_dica()
        {
            // o handle nulo e o vazio sao o mesmo (o `Nothing = ""` do VB)
            PinturaDaLinha pintura = PinturaDaListaDoPainel.Pintar(Linha(461, false, null), Catalogo);

            Assert.Equal(CorDaCelula.CinzaClaro, pintura.Fundo);
            Assert.Equal(string.Empty, pintura.Dica);
        }

        [Fact]
        public void O_material_zero_diz_por_que_fica_fora_do_relatorio()
        {
            Assert.Equal(
                "Esse Material deve ser atribuido no modelo do Dispositivo\r\nDispositivo com Material '0' não será inserido no relatório",
                PinturaDaListaDoPainel.Pintar(Linha(0, true, string.Empty), Catalogo).Erro);
            Assert.Equal(
                "Dispositivo Independente\r\nDispositivo com Material '0' não será inserido no relatório",
                PinturaDaListaDoPainel.Pintar(Linha(0, false, "5A3E"), Catalogo).Erro);
            Assert.Equal(
                "Dispositivo Avulso\r\nDispositivo com Material '0' não será inserido no relatório",
                PinturaDaListaDoPainel.Pintar(Linha(0, true, "5A3E"), Catalogo).Erro);

            // o 0 nunca e "fora do catalogo": a celula 4 nao fica coral
            Assert.Null(PinturaDaListaDoPainel.Pintar(Linha(0, false, "5A3E"), Catalogo).FundoDoMaterial);
        }

        [Fact]
        public void O_material_fora_do_catalogo_pinta_so_a_celula_do_material_de_coral()
        {
            PinturaDaLinha pintura = PinturaDaListaDoPainel.Pintar(Linha(9999, false, "5A3E"), Catalogo);

            Assert.Equal(CorDaCelula.Limao, pintura.Fundo);
            Assert.Equal(CorDaCelula.Coral, pintura.FundoDoMaterial);
            Assert.Equal(
                "Material não cadastrado no Gerenciador de Materiais\r\nDispositivos sem material não serão inseridos no relatório",
                pintura.Erro);
        }
    }
}

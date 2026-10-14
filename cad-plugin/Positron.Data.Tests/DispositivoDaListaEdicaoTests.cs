using System.Collections.Generic;
using Positron.Data.Materiais;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// O **ramo do desenho** do <b>Edita Material Selecionado</b> do <c>ATINDEP</c> (rodada 152): a
    /// regra do <c>clsDispositivo.EditaLMDoDispositivo</c> — quais linhas do plano viram escrita no
    /// bloco, o guarda do <c>iLM1</c>, o nome do painel do cadastro e os três atributos
    /// (<c>MODELO</c>/<c>PAINEL</c>/<c>FABRICANTE</c>).
    /// </summary>
    public class DispositivoDaListaEdicaoTests
    {
        [Fact]
        public void So_a_linha_com_handle_vira_escrita_no_desenho()
        {
            List<AcaoNoItemDaLM> plano = new List<AcaoNoItemDaLM>
            {
                // O item avulso: e escrita de banco, nao do desenho.
                new AcaoNoItemDaLM
                {
                    Tipo = TipoDeAcaoNoItemDaLM.Substituir,
                    Indice = 501,
                    IndiceMaterial = 900,
                    Item = ListaMateriaisEdicao.ItemNovo(63, 9, "AV1", "900", "1", 100000),
                },
                // A linha do desenho: o que o `EditaLMDoDispositivo` recebe no array (3, 1).
                new AcaoNoItemDaLM
                {
                    Tipo = TipoDeAcaoNoItemDaLM.AjustarMaterialDoDispositivo,
                    Indice = 12,
                    IndiceMaterial = 900,
                    Handle = "2A4F",
                },
            };

            ItemDoDispositivo item = Assert.Single(DispositivoDaListaEdicao.ItensParaODesenho(plano));

            // O array do original e `mLM[0, i]` = Indice, `mLM[1, i]` = material, `mLM[2, i]` = handle.
            Assert.Equal(12, item.Indice);
            Assert.Equal(900, item.Lm);
            Assert.Equal("2A4F", item.Handle);
        }

        [Fact]
        public void Plano_sem_linha_do_desenho_nao_gera_escrita()
        {
            Assert.Empty(DispositivoDaListaEdicao.ItensParaODesenho(null));
            Assert.Empty(DispositivoDaListaEdicao.ItensParaODesenho(new List<AcaoNoItemDaLM>()));

            // O avulso nao entra; o ajuste sem handle (o guarda do `Cells[11] <> ""` do formulario)
            // tambem nao — o original so monta o array dentro daquele `if`.
            List<AcaoNoItemDaLM> plano = new List<AcaoNoItemDaLM>
            {
                null,
                new AcaoNoItemDaLM { Tipo = TipoDeAcaoNoItemDaLM.AjustarMaterialDoDispositivo, Indice = 1, Handle = null },
                new AcaoNoItemDaLM { Tipo = TipoDeAcaoNoItemDaLM.AjustarMaterialDoDispositivo, Indice = 2, Handle = string.Empty },
            };

            Assert.Empty(DispositivoDaListaEdicao.ItensParaODesenho(plano));
        }

        [Fact]
        public void O_xdata_so_e_regravado_quando_o_lm_muda()
        {
            // O `If disp.iLM1 <> Conversions.ToInteger(mLM[1, i])` do original.
            Assert.False(DispositivoDaListaEdicao.PrecisaGravarLm(900, 900));
            Assert.True(DispositivoDaListaEdicao.PrecisaGravarLm(0, 900));
            Assert.True(DispositivoDaListaEdicao.PrecisaGravarLm(900, 0));
        }

        [Fact]
        public void Painel_fora_do_cadastro_responde_o_interrogacao()
        {
            Dictionary<int, string> nomes = new Dictionary<int, string>
            {
                { 9, "R16" },
                { 10, string.Empty },
            };

            // O `BuscaNomeDoPainel`: o valor da tabela `Paineis` quando o indice esta la...
            Assert.Equal("R16", DispositivoDaListaEdicao.NomeDoPainel(nomes, 9));
            // ...inclusive vazio (o cadastro tem a linha, o nome e que nao foi digitado)...
            Assert.Equal(string.Empty, DispositivoDaListaEdicao.NomeDoPainel(nomes, 10));
            // ...e o literal `???` quando nao esta (o `lPnAoagado` do original): nao e o indice.
            Assert.Equal("???", DispositivoDaListaEdicao.NomeDoPainel(nomes, 11));
            Assert.Equal("???", DispositivoDaListaEdicao.NomeDoPainel(null, 9));
            Assert.Equal("???", DispositivoDaListaEdicao.PainelSemCadastro);
        }

        [Fact]
        public void Fabricante_sai_do_material_e_e_vazio_fora_do_catalogo()
        {
            // O `BuscaFabricanteDoMaterial` busca por `CodigoInterno` na `Materiais`; sem material,
            // o `Rows.Count = 0` deixa o resultado vazio (nao o `???` do painel).
            Assert.Equal("WEG", DispositivoDaListaEdicao.FabricanteDoMaterial(
                new MaterialDoCatalogo { CodigoInterno = 900, Fabricante = "WEG" }));
            Assert.Equal(string.Empty, DispositivoDaListaEdicao.FabricanteDoMaterial(
                new MaterialDoCatalogo { CodigoInterno = 900, Fabricante = null }));
            Assert.Equal(string.Empty, DispositivoDaListaEdicao.FabricanteDoMaterial(null));
        }

        [Fact]
        public void Os_tres_atributos_saem_na_ordem_do_original_com_o_modelo_limpo()
        {
            List<AtributoDoDispositivo> atributos =
                DispositivoDaListaEdicao.AtributosDoDispositivo("R16", "WEG");

            Assert.Equal(3, atributos.Count);
            Assert.Equal("MODELO", atributos[0].Tag);
            // O original LIMPA o modelo do dispositivo: e o `AtualizaValorDeUmAtributo(handle, "MODELO", "")`.
            Assert.Equal(string.Empty, atributos[0].Valor);
            Assert.Equal("PAINEL", atributos[1].Tag);
            Assert.Equal("R16", atributos[1].Valor);
            Assert.Equal("FABRICANTE", atributos[2].Tag);
            Assert.Equal("WEG", atributos[2].Valor);

            // Sem cadastro/os dois valores vazios: os atributos sao gravados assim mesmo.
            List<AtributoDoDispositivo> vazios =
                DispositivoDaListaEdicao.AtributosDoDispositivo(null, null);
            Assert.Equal(string.Empty, vazios[0].Valor);
            Assert.Equal(string.Empty, vazios[1].Valor);
            Assert.Equal(string.Empty, vazios[2].Valor);
            Assert.Equal("MODELO", DispositivoDaListaEdicao.TagDoModelo);
            Assert.Equal("PAINEL", DispositivoDaListaEdicao.TagDoPainel);
            Assert.Equal("FABRICANTE", DispositivoDaListaEdicao.TagDoFabricante);
        }

        [Fact]
        public void O_indice_do_lm_e_do_painel_no_xdata_sao_os_do_reverso()
        {
            // O `GravarXDataDispPrincipal` do reverso (o array de 29 valores do `XDataDispositivosMaster`):
            // o painel e o `array[8]` (1070) e o `iLM1` e o `array[21]` (1071). Os indices sao
            // contados **depois** do app name, o mesmo criterio do `ATT`/`lm1` do `cad-dump-xdata.lsp`.
            Assert.Equal(8, DispositivoDaListaEdicao.IndiceDoPainelNoXData);
            Assert.Equal(21, DispositivoDaListaEdicao.IndiceDoLmNoXData);
        }
    }
}

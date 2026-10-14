using System.Collections.Generic;
using Positron.Data;
using Positron.Data.Materiais;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// A **escrita da lista** de materiais pelo <c>frmGerenciadorMatIndep</c> (<c>ATINDEP</c>, rodada
    /// 151): a regra do item avulso (<c>AdicionaUmItemMaterialAvulso</c>) e a do plano do
    /// <b>Edita Material Selecionado</b> (<c>eK4ppmS0dUi</c>), mais a escrita no banco
    /// (<see cref="ProjectStore.AdicionarItemDaLM"/>, <see cref="ProjectStore.EditarMaterialDoItemDaLM"/>
    /// e <see cref="ProjectStore.RemoverItemDaLM"/>).
    /// </summary>
    public class ListaMateriaisEdicaoTests
    {
        [Fact]
        public void Ordem_do_item_avulso_comeca_em_100000()
        {
            // O `rfCpTfmCm7Q = 100000` do construtor do original: a primeira linha avulsa da janela.
            Assert.Equal(100000, ListaMateriaisEdicao.OrdemDoItemAvulso(0));
            Assert.Equal(100001, ListaMateriaisEdicao.OrdemDoItemAvulso(1));
            Assert.Equal(100002, ListaMateriaisEdicao.OrdemDoItemAvulso(2));
            // Um contador negativo não desce a ordem — é o parâmetro, não o estado da tela.
            Assert.Equal(100000, ListaMateriaisEdicao.OrdemDoItemAvulso(-3));
        }

        [Fact]
        public void Quantidade_vazia_ou_zero_vira_1()
        {
            // O `TBQuantidade.Text = "1"` do `eK4ppmS0dUi`.
            Assert.Equal("1", ListaMateriaisEdicao.QuantidadeDoTexto(null));
            Assert.Equal("1", ListaMateriaisEdicao.QuantidadeDoTexto(string.Empty));
            Assert.Equal("1", ListaMateriaisEdicao.QuantidadeDoTexto("   "));
            Assert.Equal("1", ListaMateriaisEdicao.QuantidadeDoTexto("0"));
            Assert.Equal("1", ListaMateriaisEdicao.QuantidadeDoTexto(" 0 "));

            // O resto passa como foi digitado (é esse texto que a grade recebe).
            Assert.Equal("3", ListaMateriaisEdicao.QuantidadeDoTexto("3"));
            Assert.Equal(" 3 ", ListaMateriaisEdicao.QuantidadeDoTexto(" 3 "));
        }

        [Fact]
        public void Caixa_do_codigo_em_zero_nao_acrescenta()
        {
            // O guarda do `jnTppR04rG4`: `CompareString(tbCodigo1.Text, "0", TextCompare: true) <> 0`.
            Assert.False(ListaMateriaisEdicao.PodeAcrescentarItem("0"));
            Assert.True(ListaMateriaisEdicao.PodeAcrescentarItem("518"));
            Assert.True(ListaMateriaisEdicao.PodeAcrescentarItem("M1"));

            // A caixa **vazia** não é o "0" e o original acrescenta o material 0 — o quirk fica.
            Assert.True(ListaMateriaisEdicao.PodeAcrescentarItem(string.Empty));
            Assert.True(ListaMateriaisEdicao.PodeAcrescentarItem(null));
        }

        [Fact]
        public void Item_novo_entra_avulso_com_os_campos_vazios()
        {
            LinhaListaMaterial item = ListaMateriaisEdicao.ItemNovo(63, 9, "AV1", "518", "2", 100000);

            Assert.Equal(63, item.DWG);
            Assert.Equal(9, item.Painel);
            Assert.Equal("AV1", item.Tag);
            Assert.Equal(518, item.IndiceMaterial);
            Assert.Equal(2, item.Quantidade);
            Assert.Equal(100000, item.Ordem);
            Assert.True(item.Avulso, "o item da tela entra avulso - e o que faz a projecao preserva-lo");

            // O insert do original manda "" nesses quatro: o item e do usuario, nao do desenho.
            Assert.Equal(string.Empty, item.Destino);
            Assert.Equal(string.Empty, item.DescDestino);
            Assert.Equal(string.Empty, item.Alternativo);
            Assert.Equal(string.Empty, item.Handle);

            // O IndiceLM do original e o indice da LINHA da grade: aqui nao se inventa o numero do LM.
            Assert.Equal(0, item.IndiceLM);
            Assert.Equal(0, item.OrdemLay);
        }

        [Fact]
        public void Codigo_e_quantidade_fora_do_numero_nao_estouram()
        {
            Assert.Equal(518, ListaMateriaisEdicao.CodigoDoTexto("518"));
            Assert.Equal(518, ListaMateriaisEdicao.CodigoDoTexto(" 518 "));
            Assert.Equal(52, ListaMateriaisEdicao.CodigoDoTexto("51.6"));
            Assert.Equal(0, ListaMateriaisEdicao.CodigoDoTexto("abc"));
            Assert.Equal(0, ListaMateriaisEdicao.CodigoDoTexto(null));
        }

        [Fact]
        public void Plano_do_editar_substitui_a_linha_avulsa()
        {
            List<LinhaDoItemNaGrade> selecionadas = new List<LinhaDoItemNaGrade>
            {
                new LinhaDoItemNaGrade
                {
                    Indice = 501,
                    DWG = 63,
                    Painel = 9,
                    Tag = "AV1",
                    IndiceMaterial = 518,
                    Quantidade = 2,
                    Ordem = 100000,
                    Avulso = true,
                    Alternativo = "ALT",
                },
            };

            List<AcaoNoItemDaLM> plano = ListaMateriaisEdicao.PlanoDoMaterialEscolhido(selecionadas, "AV1-NOVO", "4", "900");

            AcaoNoItemDaLM acao = Assert.Single(plano);
            Assert.Equal(TipoDeAcaoNoItemDaLM.Substituir, acao.Tipo);
            Assert.Equal(501, acao.Indice);
            Assert.Equal(900, acao.Item.IndiceMaterial);
            Assert.Equal("AV1-NOVO", acao.Item.Tag);
            Assert.Equal(4, acao.Item.Quantidade);

            // A ordem e o resto da linha vem da grade (o insert rele as celulas 1..6 e 10/11).
            Assert.Equal(100000, acao.Item.Ordem);
            Assert.Equal(9, acao.Item.Painel);
            Assert.Equal(63, acao.Item.DWG);
            Assert.Equal("ALT", acao.Item.Alternativo);
            Assert.True(acao.Item.Avulso);
        }

        [Fact]
        public void Plano_do_editar_manda_o_dispositivo_do_desenho_pelo_handle()
        {
            List<LinhaDoItemNaGrade> selecionadas = new List<LinhaDoItemNaGrade>
            {
                // A linha do desenho: nao e avulsa, tem handle - so o material do dispositivo.
                new LinhaDoItemNaGrade { Indice = 12, Tag = "R16", IndiceMaterial = 0, Handle = "2A4F", Ordem = 3 },
                // Sem avulso e sem handle: nao gera operacao nenhuma.
                new LinhaDoItemNaGrade { Indice = 13, Tag = "SEM", IndiceMaterial = 0, Ordem = 4 },
            };

            List<AcaoNoItemDaLM> plano = ListaMateriaisEdicao.PlanoDoMaterialEscolhido(selecionadas, "R16", "1", "900");

            AcaoNoItemDaLM acao = Assert.Single(plano);
            Assert.Equal(TipoDeAcaoNoItemDaLM.AjustarMaterialDoDispositivo, acao.Tipo);
            Assert.Equal(12, acao.Indice);
            Assert.Equal(900, acao.IndiceMaterial);
            Assert.Equal("2A4F", acao.Handle);
            Assert.Null(acao.Item);
        }

        [Fact]
        public void Plano_do_editar_normaliza_a_quantidade_e_o_vazio_nao_quebra()
        {
            List<LinhaDoItemNaGrade> selecionadas = new List<LinhaDoItemNaGrade>
            {
                new LinhaDoItemNaGrade { Indice = 7, Painel = 9, Tag = "AV", Avulso = true, Ordem = 100000 },
            };

            Assert.Equal(1, ListaMateriaisEdicao.PlanoDoMaterialEscolhido(selecionadas, "AV", "0", "5")[0].Item.Quantidade);
            Assert.Equal(1, ListaMateriaisEdicao.PlanoDoMaterialEscolhido(selecionadas, "AV", "", "5")[0].Item.Quantidade);
            Assert.Empty(ListaMateriaisEdicao.PlanoDoMaterialEscolhido(null, "AV", "1", "5"));
            Assert.Empty(ListaMateriaisEdicao.PlanoDoMaterialEscolhido(
                new List<LinhaDoItemNaGrade> { null }, "AV", "1", "5"));
        }

        [Fact]
        public void Escreve_o_item_avulso_na_lista()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);

                int indice = store.AdicionarItemDaLM(ListaMateriaisEdicao.ItemNovo(63, 9, "AV1", "518", "2", 100000));
                Assert.True(indice > 0, "o Indice e a chave que o banco atribui (o insert nao manda)");

                LinhaListaMaterial lida = Assert.Single(store.LerListaMateriais(63));
                Assert.Equal(indice, lida.Indice);
                Assert.Equal(63, lida.DWG);
                Assert.Equal(9, lida.Painel);
                Assert.Equal("AV1", lida.Tag);
                Assert.Equal(518, lida.IndiceMaterial);
                Assert.Equal(2, lida.Quantidade);
                Assert.Equal(100000, lida.Ordem);
                Assert.True(lida.Avulso);
                // O IndiceLM e o OrdemLay nao vao no insert: o banco devolve nulo (o leitor faz 0).
                Assert.Equal(0, lida.IndiceLM);
                Assert.Equal(0, lida.OrdemLay);
                // Os quatro campos de texto saem como o original os manda (o `""` e nao ausente: o
                // leitor devolveria `null` se a coluna fosse nula).
                Assert.Equal(string.Empty, lida.Destino);
                Assert.Equal(string.Empty, lida.DescDestino);
                Assert.Equal(string.Empty, lida.Alternativo);
                Assert.Equal(string.Empty, lida.Handle);

                // O avulso e o que a projecao preserva (o `CapturaMateriaisAvulso`).
                Assert.Single(store.LerListaMateriaisAvulsos(63));

                // O `EditaUmItemMaterialAvulso`: so o material de UMA linha.
                Assert.Equal(1, store.EditarMaterialDoItemDaLM(indice, 900));
                Assert.Equal(900, Assert.Single(store.LerListaMateriais(63)).IndiceMaterial);

                // O `RemoveMaterialAvulso` pelo Indice; a chave que nao existe nao mente.
                Assert.Equal(1, store.RemoverItemDaLM(indice));
                Assert.Empty(store.LerListaMateriais(63));
                Assert.Equal(0, store.RemoverItemDaLM(indice));
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }

        [Fact]
        public void Item_de_outro_desenho_nao_entra_na_leitura_do_dwg()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);
                store.AdicionarItemDaLM(ListaMateriaisEdicao.ItemNovo(63, 9, "AV1", "518", "1", 100000));
                store.AdicionarItemDaLM(ListaMateriaisEdicao.ItemNovo(64, 9, "AV2", "518", "1", 100000));

                Assert.Equal("AV1", Assert.Single(store.LerListaMateriais(63)).Tag);
                Assert.Equal("AV2", Assert.Single(store.LerListaMateriais(64)).Tag);
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }

        [Fact]
        public void Plano_aplicado_troca_a_linha_avulsa_pela_regravada()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);
                // Uma linha que não entra na edição: a chave nova da substituída fica provada por contraste.
                store.AdicionarItemDaLM(ListaMateriaisEdicao.ItemNovo(63, 9, "OUTRO", "518", "1", 99999));
                int antes = store.AdicionarItemDaLM(ListaMateriaisEdicao.ItemNovo(63, 9, "AV1", "518", "1", 100000));

                List<LinhaDoItemNaGrade> selecionadas = new List<LinhaDoItemNaGrade>
                {
                    new LinhaDoItemNaGrade
                    {
                        Indice = antes,
                        DWG = 63,
                        Painel = 9,
                        Tag = "AV1",
                        IndiceMaterial = 518,
                        Quantidade = 1,
                        Ordem = 100000,
                        Avulso = true,
                    },
                };

                // O `eK4ppmS0dUi`: remover a linha do banco e inserir de novo com o que foi digitado.
                foreach (AcaoNoItemDaLM acao in ListaMateriaisEdicao.PlanoDoMaterialEscolhido(selecionadas, "AV1-EDITADO", "3", "900"))
                {
                    if (acao.Tipo == TipoDeAcaoNoItemDaLM.Substituir)
                    {
                        store.RemoverItemDaLM(acao.Indice);
                        store.AdicionarItemDaLM(acao.Item);
                    }
                }

                List<LinhaListaMaterial> lidas = store.LerListaMateriais(63);
                Assert.Equal(2, lidas.Count);
                Assert.Equal("OUTRO", lidas[0].Tag);

                LinhaListaMaterial lida = lidas[1];
                Assert.Equal("AV1-EDITADO", lida.Tag);
                // A linha voltou com uma chave que o banco atribuiu (a substituta do original é um
                // DELETE + INSERT; o SQLite pode reusar a chave da linha que saiu, e não se afirma).
                Assert.True(lida.Indice > 0, "a linha regravada tem a chave do banco (antes=" + antes + ")");
                Assert.Equal(900, lida.IndiceMaterial);
                Assert.Equal(3, lida.Quantidade);
                // A `Ordem` da linha da grade nao muda: ela continua no fim da lista.
                Assert.Equal(99999, lidas[0].Ordem);
                Assert.Equal(100000, lida.Ordem);
                Assert.True(lida.Avulso);
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }

        [Fact]
        public void Apaga_so_o_que_foi_escolhido()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);
                int um = store.AdicionarItemDaLM(ListaMateriaisEdicao.ItemNovo(63, 9, "AV1", "518", "1", 100000));
                store.AdicionarItemDaLM(ListaMateriaisEdicao.ItemNovo(63, 9, "AV2", "518", "1", 100001));

                Assert.Equal(1, store.RemoverItemDaLM(um));
                Assert.Equal("AV2", Assert.Single(store.LerListaMateriais(63)).Tag);
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }

        [Fact]
        public void A_substituicao_nao_toca_no_Indice_das_outras_linhas()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);
                int primeira = store.AdicionarItemDaLM(ListaMateriaisEdicao.ItemNovo(63, 9, "A", "518", "1", 100000));
                int segunda = store.AdicionarItemDaLM(ListaMateriaisEdicao.ItemNovo(63, 9, "B", "518", "1", 100001));

                Assert.Equal(1, store.EditarMaterialDoItemDaLM(segunda, 901));

                List<LinhaListaMaterial> lidas = store.LerListaMateriais(63);
                Assert.Equal(new[] { "A", "B" }, lidas.ConvertAll(l => l.Tag));
                Assert.Equal(new[] { primeira, segunda }, lidas.ConvertAll(l => l.Indice));
                Assert.Equal(new[] { 518, 901 }, lidas.ConvertAll(l => l.IndiceMaterial));
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }
    }
}

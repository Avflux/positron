using System.Collections.Generic;
using Positron.Data.TrocaDeBlocos;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// A troca de blocos do reverso (<c>clsTrocaEditaBlocos.cs</c> e o
    /// <c>frmTrocaEditaBlocos.cs</c>): o **buffer dos atributos invisíveis** que a troca de bloco
    /// carrega de um bloco para o outro, o resumo do <c>CorrigeAtributos</c> e as marcas
    /// <c>_A_</c>/<c>_B_</c>/<c>_E_</c> do nome que escolhem as correções do pós-troca.
    /// </summary>
    public class TrocaDeBlocosTests
    {
        private static AtributoDoBloco Atributo(
            string handle,
            string bloco,
            string tag,
            string valor,
            bool visivel = false)
        {
            return new AtributoDoBloco
            {
                HandleDoBloco = handle,
                NomeDoBloco = bloco,
                Tag = tag,
                Valor = valor,
                Visivel = visivel,
            };
        }

        private static List<AtributoDoBloco> Mistura()
        {
            return new List<AtributoDoBloco>
            {
                Atributo("1A", "MODELO_NA_1", "T1", "A1"),
                Atributo("1A", "MODELO_NA_1", "T2", "A2", visivel: true),
                Atributo("2B", "AUXILIAR_A_1", "T3", "A3"),
                Atributo("3C", "QUADRO", "TAG", "Q1", visivel: true),
            };
        }

        [Fact]
        public void O_buffer_so_guarda_os_atributos_invisiveis()
        {
            // A regra do original é uma só: os **invisíveis** são o que a troca de bloco carrega —
            // é neles que o valor atravessa a substituição do bloco.
            IReadOnlyList<AtributoDoBloco> buffer = AtributosDosBlocos.Invisiveis(Mistura(), null);

            Assert.Equal(2, buffer.Count);
            Assert.Equal("T1", buffer[0].Tag);
            Assert.Equal("T3", buffer[1].Tag);
        }

        [Fact]
        public void O_filtro_de_nome_nao_distingue_caixa_e_a_lista_vazia_le_tudo()
        {
            IReadOnlyList<AtributoDoBloco> buffer =
                AtributosDosBlocos.Invisiveis(Mistura(), new List<string> { "auxiliar_a_1" });

            Assert.Single(buffer);
            Assert.Equal("AUXILIAR_A_1", buffer[0].NomeDoBloco);

            // Sem lista (e com lista vazia) a varredura é a do `LeTodosAtributos`.
            Assert.Equal(2, AtributosDosBlocos.Invisiveis(Mistura(), null).Count);
            Assert.Equal(2, AtributosDosBlocos.Invisiveis(Mistura(), new List<string>()).Count);
        }

        [Fact]
        public void Os_nomes_dos_blocos_saem_em_maiuscula_sem_repeticao_e_na_ordem_de_leitura()
        {
            // O `lBlocosExistentesTrocados` do original: o bloco entra assim que tem **algum**
            // atributo (visível ou não), em maiúscula e uma vez só.
            IReadOnlyList<string> nomes = AtributosDosBlocos.NomesDosBlocos(Mistura());

            Assert.Equal(new[] { "MODELO_NA_1", "AUXILIAR_A_1", "QUADRO" }, nomes);
        }

        [Fact]
        public void Os_handles_dos_blocos_saem_unicos_na_ordem_de_leitura()
        {
            // O `lBlocosAlterados` do original.
            IReadOnlyList<string> handles = AtributosDosBlocos.HandlesDosBlocos(Mistura());

            Assert.Equal(new[] { "1A", "2B", "3C" }, handles);
        }

        [Fact]
        public void O_resumo_e_o_do_original_no_singular_e_no_plural()
        {
            // `clsTrocaEditaBlocos.cs:154-158`: a mMensagem 1298 no singular e a 1302 com mais de um.
            Assert.Equal("1 Tipo de Bloco Trocado", AtributosDosBlocos.Resumo(1, 0, ""));
            Assert.Equal("2 Tipos de Blocos Trocados", AtributosDosBlocos.Resumo(2, 0, ""));
        }

        [Fact]
        public void O_resumo_com_handle_trocado_usa_o_titulo_dos_blocos_trocados()
        {
            // `:160-163`: quando algum handle mudou na troca, a mMensagem 1349 **substitui** o título
            // e vem com dois espaços antes da contagem (é a contagem dos handles trocados, não a dos
            // blocos existentes).
            Assert.Equal("Blocos Trocados  2", AtributosDosBlocos.Resumo(5, 2, ""));
        }

        [Fact]
        public void O_resumo_dos_inexistentes_escolhe_o_singular_e_o_plural_pelo_ponto_e_virgula()
        {
            // `:164-169`: a cauda é `\r\n\r\n` + a mMensagem (1300 quando a lista tem `;`, 1299
            // quando é um só) + " " + a 1301 ("no Desenho") + a lista.
            string um = AtributosDosBlocos.ListaDosNaoExistentes("", "AUXILIAR_A_1");
            string dois = AtributosDosBlocos.ListaDosNaoExistentes(um, "quadro_2");

            Assert.Equal("\r\nAUXILIAR_A_1", um);
            Assert.Equal("\r\nAUXILIAR_A_1;\r\nQUADRO_2", dois);

            Assert.Equal("1 Tipo de Bloco Trocado\r\n\r\nNão existe esse bloco no Desenho" + um,
                AtributosDosBlocos.Resumo(1, 0, um));
            Assert.Equal("1 Tipo de Bloco Trocado\r\n\r\nNão existem esses blocos no Desenho" + dois,
                AtributosDosBlocos.Resumo(1, 0, dois));
        }

        [Fact]
        public void A_lista_dos_inexistentes_repete_a_tela_o_primeiro_sem_maiuscula()
        {
            // `frmTrocaEditaBlocos.cs:715-724`: o primeiro entra com a quebra de linha e **sem**
            // maiúscula; os seguintes entram em maiúscula, separados por `;` — é essa diferença que
            // o resumo usa para escolher entre o singular e o plural.
            Assert.Equal("\r\nbloco_a", AtributosDosBlocos.ListaDosNaoExistentes("", "bloco_a"));
            Assert.Equal("\r\nbloco_a;\r\nBLOCO_B",
                AtributosDosBlocos.ListaDosNaoExistentes("\r\nbloco_a", "bloco_b"));
        }

        [Fact]
        public void As_marcas_das_tres_familias_saem_da_leitura_do_bloco()
        {
            // Os `Contains("_A_")`/`"_B_"`/`"_E_"` do original, sobre o nome que a leitura guarda
            // em maiúscula (`NomesDosBlocos`) — por isso a marca é achada sem depender da caixa.
            Assert.True(AtributosDosBlocos.EhDosContatosAuxiliares("AUXILIAR_A_1"));
            Assert.True(AtributosDosBlocos.EhDosBornes("BORNE_B_2"));
            Assert.True(AtributosDosBlocos.EhDosPortas("PORTA_E_3"));
            Assert.False(AtributosDosBlocos.EhDosPortas("AUXILIAR_A_1"));
        }

        [Fact]
        public void As_marcas_do_nome_escolhem_as_correcoes_da_tela()
        {
            // `frmTrocaEditaBlocos.cs:699-740`: o `_A_` dispara os contatos auxiliares, o `_B_` o
            // painel/ET1 dos bornes e o `PreencheNovosAtributos` vem com `flag | flag3` — ou seja o
            // `_A_` **também** o dispara; o `_E_` só ele.
            CorrecoesPosTroca soA = AtributosDosBlocos.AcoesPosTroca(new List<string> { "AUXILIAR_A_1" });
            Assert.True(soA.ContatosAuxiliares);
            Assert.False(soA.PainelEt1);
            Assert.True(soA.PreencheAtributos);

            CorrecoesPosTroca soB = AtributosDosBlocos.AcoesPosTroca(new List<string> { "BORNE_B_1" });
            Assert.False(soB.ContatosAuxiliares);
            Assert.True(soB.PainelEt1);
            Assert.False(soB.PreencheAtributos);

            CorrecoesPosTroca soE = AtributosDosBlocos.AcoesPosTroca(new List<string> { "PORTA_E_1" });
            Assert.False(soE.ContatosAuxiliares);
            Assert.False(soE.PainelEt1);
            Assert.True(soE.PreencheAtributos);

            CorrecoesPosTroca semMarca = AtributosDosBlocos.AcoesPosTroca(new List<string> { "QUADRO" });
            Assert.False(semMarca.ContatosAuxiliares);
            Assert.False(semMarca.PainelEt1);
            Assert.False(semMarca.PreencheAtributos);
        }

        [Fact]
        public void As_marcas_da_troca_tambem_saem_da_lista_completa_do_original()
        {
            // A lista do pós-troca não é a do buffer: qualquer bloco do desenho com a marca já a liga.
            CorrecoesPosTroca acoes = AtributosDosBlocos.AcoesPosTroca(
                new List<string> { "QUADRO", "por_b_1", "PORTA_E_2" });

            Assert.False(acoes.ContatosAuxiliares);
            Assert.True(acoes.PainelEt1);
            Assert.True(acoes.PreencheAtributos);
        }
    }
}

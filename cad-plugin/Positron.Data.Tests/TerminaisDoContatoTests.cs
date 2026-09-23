using System.Collections.Generic;
using Positron.Data.Correcoes;
using Positron.Data.Modelos;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// O <c>CorrigeBlocosContatosAux</c> (frente 2 do §7.6): a regra dos terminais do
    /// <c>AtualizaOsTerminaisAuxiliares</c> — tag, tipo do contato e tipo do bloco.
    /// </summary>
    public class TerminaisDoContatoTests
    {
        [Fact]
        public void T1_recebe_sempre_o_sT1()
        {
            Assert.Equal("A1", Valor("T1", "RV", "NA"));
            Assert.Equal("A1", Valor("t1", "NA", "NF"));
        }

        [Fact]
        public void T2_normal_recebe_o_sT2()
        {
            Assert.Equal("A2", Valor("T2", "NA", "RV"));
            Assert.Equal("A2", Valor("T2", "", ""));
        }

        [Fact]
        public void T2_com_tipo_RV_e_bloco_NA_recebe_o_sT3()
        {
            // O quirk do original: com o contato RV, o T2 do bloco `NA` vem do `sT3`.
            Assert.Equal("A3", Valor("T2", "RV", "NA"));
        }

        [Fact]
        public void T2_com_tipo_RV_e_bloco_NF_ou_RV_recebe_o_sT2()
        {
            Assert.Equal("A2", Valor("T2", "RV", "NF"));
            Assert.Equal("A2", Valor("T2", "RV", "RV"));
        }

        [Fact]
        public void T2_com_tipo_RV_e_outro_bloco_nao_mexe()
        {
            Assert.Equal(TerminaisDoContato.NaoMexer, Valor("T2", "RV", "XX"));
            Assert.Equal(TerminaisDoContato.NaoMexer, Valor("T2", "RV", ""));
        }

        [Fact]
        public void T3_normal_recebe_o_sT3_e_com_o_tipo_NA_o_vazio_cai_no_sT2()
        {
            Assert.Equal("A3", Valor("T3", "RV", "NA"));
            Assert.Equal("A3", Valor("T3", "NA", "NA"));

            // Com o tipo `NA` e o `sT3` vazio, o atributo T3 recebe o `sT2`.
            Assert.Equal("A2", TerminaisDoContato.ValorDoAtributo("T3", "NA", "NA", "A1", "A2", ""));
            Assert.Equal("A3", TerminaisDoContato.ValorDoAtributo("T3", "NA", "NA", "A1", "A2", "A3"));
        }

        [Fact]
        public void Qualquer_outra_tag_nao_mexe()
        {
            Assert.Equal(TerminaisDoContato.NaoMexer, Valor("T4", "NA", "NA"));
            Assert.Equal(TerminaisDoContato.NaoMexer, Valor("", "NA", "NA"));
            Assert.Equal(TerminaisDoContato.NaoMexer, Valor(null, "NA", "NA"));
        }

        [Fact]
        public void O_tipo_do_bloco_vem_da_quinta_letra_do_nome()
        {
            // `Mid(nome, 5, 2)` do original: os DOIS caracteres da quinta posição.
            Assert.Equal("NA", TerminaisDoContato.TipoDoBloco("BT4XNAY"));
            Assert.Equal("NF", TerminaisDoContato.TipoDoBloco("BT4XNFY"));
            Assert.Equal("RV", TerminaisDoContato.TipoDoBloco("BT4XRVY"));

            // O deslocamento importa: no `BT4NAXX` a quinta letra é o `A`.
            Assert.Equal("AX", TerminaisDoContato.TipoDoBloco("BT4NAXX"));

            // O `Mid` corta no fim da string: "BT4NA" (5 letras) dá só o "A".
            Assert.Equal("A", TerminaisDoContato.TipoDoBloco("BT4NA"));
            // Sem a quinta letra o `Mid` do original devolve vazio.
            Assert.Equal(string.Empty, TerminaisDoContato.TipoDoBloco("BT4A"));
            Assert.Equal(string.Empty, TerminaisDoContato.TipoDoBloco("BT4"));
            Assert.Equal(string.Empty, TerminaisDoContato.TipoDoBloco(null));
        }

        [Fact]
        public void O_contato_e_buscado_pelo_indice()
        {
            List<ContatoAuxiliar> contatos = new List<ContatoAuxiliar>
            {
                new ContatoAuxiliar { Indice = 4, T1 = "A1" },
                new ContatoAuxiliar { Indice = 9, T1 = "B1" },
            };

            Assert.Equal("B1", TerminaisDoContato.BuscarContato(contatos, 9).T1);
            Assert.Null(TerminaisDoContato.BuscarContato(contatos, 7));
            Assert.Null(TerminaisDoContato.BuscarContato(null, 9));
        }

        private static string Valor(string tag, string tipoModelo, string tipoDoBloco)
        {
            return TerminaisDoContato.ValorDoAtributo(tag, tipoModelo, tipoDoBloco, "A1", "A2", "A3");
        }
    }
}

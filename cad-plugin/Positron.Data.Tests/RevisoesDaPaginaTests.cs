using System.Collections.Generic;
using Positron.Data.Fiacao;
using Positron.Data.Paginas;
using Xunit;

namespace Positron.Data.Tests
{
    public class RevisoesDaPaginaTests
    {
        private static List<TypedXData> XDataRevisaoCompleta(int posicao, string revisao, string desc,
            string elab, string verif, string aprov, string data)
        {
            RevisaoCompletaDaPagina rev = new RevisaoCompletaDaPagina("01", revisao, desc, data, elab, verif, aprov, posicao);
            return new List<TypedXData>(RevisaoCompletaXData.ParaValores(rev, "usuario", "2026-10-14"));
        }

        [Fact]
        public void Le_os_campos_do_xdata_de_revisao_completa()
        {
            List<TypedXData> valores = XDataRevisaoCompleta(1, "R1", "EMISSÃO INICIAL", "ANA", "BOB", "CARLOS", "14/10/2026");

            RevisaoCompletaDaPagina lida;
            Assert.True(RevisaoCompletaXData.Ler(valores, out lida));
            Assert.NotNull(lida);
            Assert.Equal(1, lida.Posicao);
            Assert.Equal("R1", lida.Revisao);
            Assert.Equal("R1", lida.RevisaoOriginal);
            Assert.Equal("EMISSÃO INICIAL", lida.Descricao);
            Assert.Equal("ANA", lida.Elaborador);
            Assert.Equal("BOB", lida.Verificador);
            Assert.Equal("CARLOS", lida.Aprovador);
            Assert.Equal("14/10/2026", lida.Data);
        }

        [Fact]
        public void Recusa_xdata_invalido_ou_incompleto()
        {
            RevisaoCompletaDaPagina lida;
            Assert.False(RevisaoCompletaXData.Ler(null, out lida));
            Assert.False(RevisaoCompletaXData.Ler(new List<TypedXData>(), out lida));

            List<TypedXData> outroApp = new List<TypedXData>
            {
                new TypedXData(1001, "Outro"),
                new TypedXData(1000, "Revisao"),
                new TypedXData(1070, 1),
                new TypedXData(1000, "R1"),
                new TypedXData(1000, "D"),
                new TypedXData(1000, "E"),
                new TypedXData(1000, "V"),
                new TypedXData(1000, "A"),
                new TypedXData(1000, "01/01/2026"),
            };
            Assert.False(RevisaoCompletaXData.Ler(outroApp, out lida));

            List<TypedXData> outraMarca = new List<TypedXData>
            {
                new TypedXData(1001, "DiagLog"),
                new TypedXData(1000, "TituloPagina"),
                new TypedXData(1070, 1),
                new TypedXData(1000, "R1"),
                new TypedXData(1000, "D"),
                new TypedXData(1000, "E"),
                new TypedXData(1000, "V"),
                new TypedXData(1000, "A"),
                new TypedXData(1000, "01/01/2026"),
            };
            Assert.False(RevisaoCompletaXData.Ler(outraMarca, out lida));
        }

        [Fact]
        public void Substituicao_em_texto_funciona_conforme_esperado()
        {
            Assert.Equal("EMISSÃO FINAL", OperacoesDeRevisao.Substituir("EMISSÃO INICIAL ", "INICIAL", "FINAL"));
            Assert.Equal("PROJETO ", OperacoesDeRevisao.Substituir("PROJETO ", "XPTO", "ABC"));
            Assert.Equal("", OperacoesDeRevisao.Substituir("", "A", "B"));
            Assert.Equal("TESTE", OperacoesDeRevisao.Substituir("TESTE", null, "B"));
        }

        [Fact]
        public void Revisao_completa_so_entra_com_posicao_maior_que_a_guardada()
        {
            // O original parte de Posicao 0: a posição 0 nunca entra, e a posição nova precisa ser maior.
            Assert.False(OperacoesDeRevisao.AceitaRevisaoCompleta(0, 0));
            Assert.True(OperacoesDeRevisao.AceitaRevisaoCompleta(0, 1));
            Assert.True(OperacoesDeRevisao.AceitaRevisaoCompleta(1, 2));
            Assert.False(OperacoesDeRevisao.AceitaRevisaoCompleta(2, 1));
        }

        [Fact]
        public void Atributo_de_revisao_usa_a_familia_com_digito_de_0_a_7()
        {
            // As tags reais dos blocos são REV0..REV7 (o JdCp1GqFmnk do original); REV sem dígito não recebe valor.
            Assert.Equal("Revisao", RevisaoCompletaXData.CampoDoAtributo("REV0"));
            Assert.Equal("Revisao", RevisaoCompletaXData.CampoDoAtributo("rev7"));
            Assert.Equal("Descricao", RevisaoCompletaXData.CampoDoAtributo("DESC3"));
            Assert.Equal("Data", RevisaoCompletaXData.CampoDoAtributo("DATA1"));
            Assert.Equal("Elaborador", RevisaoCompletaXData.CampoDoAtributo("ELAB2"));
            Assert.Equal("Verificador", RevisaoCompletaXData.CampoDoAtributo("VERIF0"));
            Assert.Equal("Aprovador", RevisaoCompletaXData.CampoDoAtributo("APROV7"));
            Assert.Null(RevisaoCompletaXData.CampoDoAtributo("REV"));
            Assert.Null(RevisaoCompletaXData.CampoDoAtributo("REV8"));
            Assert.Null(RevisaoCompletaXData.CampoDoAtributo("REVISAO"));
            Assert.Null(RevisaoCompletaXData.CampoDoAtributo("TITULO1PAG"));
            Assert.Null(RevisaoCompletaXData.CampoDoAtributo(null));
        }

        [Fact]
        public void Construtor_de_revisao_simplificada_normaliza_nulos()
        {
            RevisaoSimplificadaDaPagina rev = new RevisaoSimplificadaDaPagina(null, null);
            Assert.Equal("", rev.Pagina);
            Assert.Equal("", rev.Revisao);
        }
    }
}

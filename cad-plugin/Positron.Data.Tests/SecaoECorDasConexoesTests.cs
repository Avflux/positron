using System.Collections.Generic;
using Positron.Data.Fiacao;
using Xunit;

namespace Positron.Data.Tests
{
    public class SecaoECorDasConexoesTests
    {
        private static ConexaoXData Conexao(short tipo, int potencial, string secao = "1,5", string cor = "PT")
        {
            return new ConexaoXData
            {
                Tipo = tipo,
                Potencial = potencial,
                Handle = "A1",
                Painel = 3,
                Aplicacao = 7,
                Nome = "X1",
                Funcao = "F",
                Tensao = "125",
                Secao = secao,
                Cor = cor,
                Disp1 = true,
                Disp2 = false,
                Jumper = "J",
                Enderecamento = 5,
            };
        }

        [Theory]
        [InlineData("S", ModoSecaoECor.Secao)]
        [InlineData("c", ModoSecaoECor.Cor)]
        [InlineData("A", ModoSecaoECor.Ambas)]
        public void Palavra_chave_vira_modo_sem_caixa(string palavra, ModoSecaoECor esperado)
        {
            Assert.Equal(esperado, SecaoECorDasConexoes.ModoDaPalavra(palavra));
        }

        [Fact]
        public void Palavra_desconhecida_nao_tem_modo()
        {
            Assert.Null(SecaoECorDasConexoes.ModoDaPalavra("X"));
        }

        [Fact]
        public void Selecao_junta_potenciais_dos_tipos_1_a_4_sem_repetir()
        {
            List<int> potenciais = SecaoECorDasConexoes.PotenciaisDaSelecao(new[]
            {
                Conexao(1, 10), Conexao(3, 20), Conexao(4, 10), Conexao(5, 30), Conexao(0, 40),
            });

            Assert.Equal(new[] { 10, 20 }, potenciais);
        }

        [Fact]
        public void Paginas_ignoram_o_tipo_3_e_diferenciam_maiusculas()
        {
            List<int> potenciais = SecaoECorDasConexoes.PotenciaisDasPaginas(
                new[]
                {
                    new KeyValuePair<string, ConexaoXData>("1", Conexao(1, 10)),
                    new KeyValuePair<string, ConexaoXData>("1", Conexao(3, 20)),
                    new KeyValuePair<string, ConexaoXData>("2", Conexao(2, 30)),
                    new KeyValuePair<string, ConexaoXData>("2A", Conexao(4, 40)),
                    new KeyValuePair<string, ConexaoXData>("2a", Conexao(4, 50)),
                },
                new List<string> { "1", "2A" });

            Assert.Equal(new[] { 10, 40 }, potenciais);
        }

        [Fact]
        public void Aplicar_secao_preserva_a_cor_e_zera_a_aplicacao()
        {
            ConexaoXData conexao = Conexao(1, 10);
            SecaoECorDasConexoes.Aplicar(conexao, ModoSecaoECor.Secao, "2,5", "VM");

            Assert.Equal("2,5", conexao.Secao);
            Assert.Equal("PT", conexao.Cor);
            Assert.Equal(0, conexao.Aplicacao);
        }

        [Fact]
        public void Aplicar_cor_preserva_a_secao()
        {
            ConexaoXData conexao = Conexao(1, 10);
            SecaoECorDasConexoes.Aplicar(conexao, ModoSecaoECor.Cor, "2,5", "VM");

            Assert.Equal("1,5", conexao.Secao);
            Assert.Equal("VM", conexao.Cor);
        }

        [Fact]
        public void Aplicar_ambas_troca_as_duas()
        {
            ConexaoXData conexao = Conexao(1, 10);
            SecaoECorDasConexoes.Aplicar(conexao, ModoSecaoECor.Ambas, "2,5", "VM");

            Assert.Equal("2,5", conexao.Secao);
            Assert.Equal("VM", conexao.Cor);
        }

        [Theory]
        [InlineData((short)4, "VM")]
        [InlineData((short)5, "2,5")]
        [InlineData((short)6, "VM (2,5)")]
        public void Texto_do_auxiliar_por_tipo(short tipo, string esperado)
        {
            Assert.Equal(esperado, SecaoECorDasConexoes.TextoDoAuxiliar(tipo, "VM", "2,5"));
        }

        [Fact]
        public void Outros_tipos_de_auxiliar_nao_sao_tocados()
        {
            Assert.Null(SecaoECorDasConexoes.TextoDoAuxiliar(1, "VM", "2,5"));
        }

        [Fact]
        public void Gravacao_da_conexao_volta_pela_leitura_com_os_reservados_fixos()
        {
            ConexaoXData original = Conexao(2, 10);
            IReadOnlyList<TypedXData> valores = original.ParaValores("ana", "15/10/2026 10:00:00");

            Assert.Equal(ConexaoXData.QuantidadeValores, valores.Count);
            Assert.Equal((short)1070, valores[1].Codigo);
            Assert.Equal((short)1071, valores[2].Codigo);
            Assert.Equal(-1, valores[14].Valor);
            Assert.Equal(1, valores[19].Valor);
            Assert.Equal(1, valores[22].Valor);

            ConexaoXData lida;
            Assert.True(ConexaoXData.Ler(valores, out lida));
            Assert.Equal(original.Tipo, lida.Tipo);
            Assert.Equal(original.Potencial, lida.Potencial);
            Assert.Equal(original.Painel, lida.Painel);
            Assert.Equal(original.Aplicacao, lida.Aplicacao);
            Assert.Equal(original.Secao, lida.Secao);
            Assert.Equal(original.Cor, lida.Cor);
            Assert.True(lida.Disp1);
            Assert.False(lida.Disp2);
            Assert.Equal(original.Jumper, lida.Jumper);
            Assert.Equal(original.Enderecamento, lida.Enderecamento);
            Assert.Equal("ana", lida.Usuario);
            Assert.Equal("15/10/2026 10:00:00", lida.Data);
        }

        [Fact]
        public void Auxiliar_le_tipo_potencial_e_handle()
        {
            List<TypedXData> valores = new List<TypedXData>
            {
                new TypedXData(1001, "AUXCONEXAO"),
                new TypedXData(1070, (short)6),
                new TypedXData(1071, 10),
                new TypedXData(1000, "2B4"),
                new TypedXData(1000, string.Empty),
                new TypedXData(1000, string.Empty),
                new TypedXData(1071, 3),
                new TypedXData(1000, "ana"),
                new TypedXData(1000, "data"),
                new TypedXData(1071, 1),
                new TypedXData(1040, 0.0),
                new TypedXData(1000, " "),
            };

            short tipo;
            int potencial;
            string handle;
            Assert.True(AuxConexaoXData.Ler(valores, out tipo, out potencial, out handle));
            Assert.Equal((short)6, tipo);
            Assert.Equal(10, potencial);
            Assert.Equal("2B4", handle);

            valores.RemoveRange(6, 6);
            Assert.False(AuxConexaoXData.Ler(valores, out tipo, out potencial, out handle));
        }
    }
}

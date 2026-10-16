using System.Collections.Generic;
using Positron.Data.Correcoes;
using Positron.Data.Fiacao;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// As marcas das cinco correções automáticas do <c>IniciarDWG</c> no XData <c>CORRECAO</c> do
    /// ModelSpace: o <c>LerCorrecao</c>/<c>setaCorrecao</c> (<c>XDataCorrecao.cs</c>).
    /// </summary>
    public class MarcasDeCorrecaoTests
    {
        [Fact]
        public void O_app_name_e_o_numero_de_marcas_sao_os_do_original()
        {
            Assert.Equal("CORRECAO", MarcasDeCorrecao.AppName);
            Assert.Equal(30, MarcasDeCorrecao.NumeroDeMarcas);
        }

        [Fact]
        public void Os_cinco_numeros_do_iniciardwg_sao_1_a_5_na_ordem()
        {
            // A ordem do `IniciarDWG` (Iniciar.cs:151-186): trocar estes números trocaria a correção
            // que roda — e as marcas dos desenhos já corrigidos pelo original deixariam de casar.
            Assert.Equal(1, MarcasDeCorrecao.AppNameDoDispositivo);
            Assert.Equal(2, MarcasDeCorrecao.BornesVisiveis);
            Assert.Equal(3, MarcasDeCorrecao.TextosDeCircuito);
            Assert.Equal(4, MarcasDeCorrecao.Linhas);
            Assert.Equal(5, MarcasDeCorrecao.OrdemDosBornes);
        }

        [Fact]
        public void O_buffer_novo_e_o_1001_com_trinta_zeros()
        {
            IReadOnlyList<TypedXData> baseDoDesenho = MarcasDeCorrecao.Base();

            Assert.Equal(31, baseDoDesenho.Count);
            Assert.Equal(1001, baseDoDesenho[0].Codigo);
            Assert.Equal("CORRECAO", baseDoDesenho[0].Valor);
            for (int i = 1; i <= MarcasDeCorrecao.NumeroDeMarcas; i++)
            {
                Assert.Equal(1070, baseDoDesenho[i].Codigo);
                Assert.Equal((short)0, baseDoDesenho[i].Valor);
            }
        }

        [Fact]
        public void Sem_buffer_nenhuma_marca_esta_lida()
        {
            Assert.False(MarcasDeCorrecao.Lida(null, MarcasDeCorrecao.Linhas));
            Assert.False(MarcasDeCorrecao.Lida(new List<TypedXData>(), MarcasDeCorrecao.Linhas));
        }

        [Fact]
        public void Marcar_nasce_do_zero_quando_o_desenho_nao_tem_o_xdata()
        {
            IReadOnlyList<TypedXData> marcados = MarcasDeCorrecao.Marcar(null, MarcasDeCorrecao.TextosDeCircuito);

            Assert.Equal(31, marcados.Count);
            Assert.True(MarcasDeCorrecao.Lida(marcados, MarcasDeCorrecao.TextosDeCircuito));
            Assert.False(MarcasDeCorrecao.Lida(marcados, MarcasDeCorrecao.Linhas));
        }

        [Fact]
        public void Marcar_conserva_as_marcas_anteriores()
        {
            IReadOnlyList<TypedXData> depois = MarcasDeCorrecao.Marcar(
                MarcasDeCorrecao.Marcar(null, MarcasDeCorrecao.AppNameDoDispositivo),
                MarcasDeCorrecao.OrdemDosBornes);

            Assert.True(MarcasDeCorrecao.Lida(depois, MarcasDeCorrecao.AppNameDoDispositivo));
            Assert.True(MarcasDeCorrecao.Lida(depois, MarcasDeCorrecao.OrdemDosBornes));
            Assert.False(MarcasDeCorrecao.Lida(depois, MarcasDeCorrecao.BornesVisiveis));
        }

        [Fact]
        public void Marcar_e_idempotente()
        {
            IReadOnlyList<TypedXData> uma = MarcasDeCorrecao.Marcar(null, MarcasDeCorrecao.BornesVisiveis);
            IReadOnlyList<TypedXData> duas = MarcasDeCorrecao.Marcar(uma, MarcasDeCorrecao.BornesVisiveis);

            Assert.Equal(31, duas.Count);
            Assert.True(MarcasDeCorrecao.Lida(duas, MarcasDeCorrecao.BornesVisiveis));
        }

        [Fact]
        public void Um_buffer_de_outro_app_name_nao_vale()
        {
            // O `GetXDataForApplication` sempre devolve o bloco do app pedido, mas a conferência do
            // `array[0]` é do original: dado estranho não pode fazer a correção ser pulada.
            List<TypedXData> outro = new List<TypedXData>
            {
                new TypedXData(1001, "OUTRO"),
                new TypedXData(1070, (short)1),
            };

            Assert.False(MarcasDeCorrecao.Lida(outro, 1));
            Assert.True(MarcasDeCorrecao.Lida(MarcasDeCorrecao.Marcar(outro, 1), 1));
        }

        [Fact]
        public void Buffer_curto_nao_derruba_a_leitura()
        {
            // O original indexa sem conferir o tamanho (estoura o `IniciarDWG` inteiro); aqui o buffer
            // curto responde `false` e a marca nova nasce do zero.
            List<TypedXData> curto = new List<TypedXData>
            {
                new TypedXData(1001, "CORRECAO"),
                new TypedXData(1070, (short)1),
            };

            Assert.True(MarcasDeCorrecao.Lida(curto, 1));
            Assert.False(MarcasDeCorrecao.Lida(curto, 5));

            IReadOnlyList<TypedXData> marcados = MarcasDeCorrecao.Marcar(curto, 5);
            Assert.Equal(31, marcados.Count);
            Assert.True(MarcasDeCorrecao.Lida(marcados, 5));
        }

        [Fact]
        public void Numero_fora_da_faixa_nao_marca_nada()
        {
            // Índice inválido responde `false` (não existe correção nº 0 nem nº 31).
            Assert.False(MarcasDeCorrecao.Lida(MarcasDeCorrecao.Base(), 0));
            Assert.False(MarcasDeCorrecao.Lida(MarcasDeCorrecao.Base(), 31));
        }
    }
}

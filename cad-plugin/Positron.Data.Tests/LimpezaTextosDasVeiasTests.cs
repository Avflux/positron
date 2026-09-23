using System.Collections.Generic;
using Positron.Data.Fiacao;
using Positron.Data.Interligacao;
using Positron.Data.Limpeza;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// A quinta ação de limpeza da frente 2 do §7.6 — o <c>apagarTodosOsTextosDasVeias</c>
    /// do <c>Correcao.cs</c>: a regra de quem sai (<see cref="LimpezaDoDesenho.ApagarRotuloAuxiliar"/>)
    /// e o leitor do app name <c>ELETROSUL</c> (<see cref="AuxInterligacaoEletrosulXData"/>).
    /// </summary>
    public class LimpezaTextosDasVeiasTests
    {
        // ── Quem sai ──────────────────────────────────────────────────────────

        [Fact]
        public void Texto_com_AUXINTERLIG_do_tipo_1_e_apagado()
        {
            Assert.True(LimpezaDoDesenho.ApagarRotuloAuxiliar(ehTexto: true, temXDataEletrosul: false, tipoAuxInterligacao: 1));
        }

        [Fact]
        public void Texto_com_AUXINTERLIG_de_outro_tipo_fica()
        {
            // O tipo 2 é o rótulo da ponta (o que aponta um THandle): o original
            // não o apaga, e o recoder reproduz o filtro — o nome do comando fala
            // de "veias", mas quem decide é o tipo.
            Assert.False(LimpezaDoDesenho.ApagarRotuloAuxiliar(ehTexto: true, temXDataEletrosul: false, tipoAuxInterligacao: 2));
            Assert.False(LimpezaDoDesenho.ApagarRotuloAuxiliar(ehTexto: true, temXDataEletrosul: false, tipoAuxInterligacao: 0));
        }

        [Fact]
        public void Nao_texto_com_AUXINTERLIG_do_tipo_1_fica()
        {
            // O ramo do AUXINTERLIG só olha DBText; uma polyline com o XData do
            // tipo 1 não é rótulo de veia.
            Assert.False(LimpezaDoDesenho.ApagarRotuloAuxiliar(ehTexto: false, temXDataEletrosul: false, tipoAuxInterligacao: 1));
        }

        [Fact]
        public void Qualquer_entidade_com_ELETROSUL_e_apagada()
        {
            // O primeiro ramo do original não olha tipo nem se é texto.
            Assert.True(LimpezaDoDesenho.ApagarRotuloAuxiliar(ehTexto: false, temXDataEletrosul: true, tipoAuxInterligacao: 0));
            Assert.True(LimpezaDoDesenho.ApagarRotuloAuxiliar(ehTexto: true, temXDataEletrosul: true, tipoAuxInterligacao: 0));
        }

        [Fact]
        public void O_ELETROSUL_vence_o_tipo_do_AUXINTERLIG()
        {
            Assert.True(LimpezaDoDesenho.ApagarRotuloAuxiliar(ehTexto: true, temXDataEletrosul: true, tipoAuxInterligacao: 2));
        }

        [Fact]
        public void Sem_XData_nao_sai_nada()
        {
            Assert.False(LimpezaDoDesenho.ApagarRotuloAuxiliar(ehTexto: true, temXDataEletrosul: false, tipoAuxInterligacao: 0));
        }

        [Fact]
        public void O_tipo_do_rotulo_e_o_mesmo_do_INDCABO()
        {
            // As duas ações olham o mesmo rótulo: a `INDCABO` troca o texto dele,
            // esta o apaga. Se um dia divergirem, é aqui que aparece.
            Assert.Equal(AcaoIndefinirCabos.TipoRotuloCabo, LimpezaDoDesenho.TipoRotuloAuxiliar);
        }

        // ── O leitor do ELETROSUL ─────────────────────────────────────────────

        [Fact]
        public void Le_o_handle_no_layout_medido()
        {
            // O que o `GravarXDataAuxInterligacaoEletrosul` grava: app name,
            // usuario, data, handle e 1.
            List<TypedXData> valores = new List<TypedXData>
            {
                new TypedXData(1001, "ELETROSUL"),
                new TypedXData(1000, "ana"),
                new TypedXData(1000, "2026-09-23"),
                new TypedXData(1000, "4E8B"),
                new TypedXData(1071, 1),
            };

            string handle;
            Assert.True(AuxInterligacaoEletrosulXData.Ler(valores, out handle));
            Assert.Equal("4E8B", handle);
        }

        [Fact]
        public void App_name_errado_nao_le()
        {
            // O app name é `ELETROSUL`, não `AUXINTERLIGELETROSUL` (o nome da funcao
            // do reverso engana).
            List<TypedXData> valores = new List<TypedXData>
            {
                new TypedXData(1001, "AUXINTERLIG"),
                new TypedXData(1000, "ana"),
                new TypedXData(1000, "2026-09-23"),
                new TypedXData(1000, "4E8B"),
                new TypedXData(1071, 1),
            };

            string handle;
            Assert.False(AuxInterligacaoEletrosulXData.Ler(valores, out handle));
            Assert.Null(handle);
        }

        [Fact]
        public void Registro_truncado_nao_le_e_nao_estoura()
        {
            // O original estoura no `array[3]` de um registro curto.
            Assert.False(AuxInterligacaoEletrosulXData.Ler(null, out _));
            Assert.False(AuxInterligacaoEletrosulXData.Ler(
                new List<TypedXData> { new TypedXData(1001, "ELETROSUL") }, out _));
        }

        [Fact]
        public void O_leitor_do_AUXINTERLIG_le_o_tipo()
        {
            List<TypedXData> valores = new List<TypedXData>
            {
                new TypedXData(1001, "AUXINTERLIG"),
                new TypedXData(1070, (short)1),
                new TypedXData(1000, "H1"),
                new TypedXData(1000, "H2"),
            };

            short tipo;
            Assert.True(AuxInterligacaoXData.Ler(valores, out tipo));
            Assert.Equal(1, tipo);
            Assert.True(LimpezaDoDesenho.ApagarRotuloAuxiliar(true, false, tipo));
        }
    }
}

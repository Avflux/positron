using System.Collections.Generic;
using Positron.Data.Interligacao;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// O <c>RecriaTextosCabo</c> (frente 2 do §7.6): o texto do rótulo
    /// (<see cref="TextoDoRotuloDeCabo"/>), a geometria
    /// (<see cref="PosicaoDoRotuloDeCabo"/>) e a regra de apagar/reinserir
    /// (<see cref="CorrecaoTextosCabo"/>).
    /// </summary>
    public class RecriaTextosCaboTests
    {
        // ── O texto do rótulo ─────────────────────────────────────────────────

        [Fact]
        public void Veia_sai_com_a_tag_e_o_separador()
        {
            Assert.Equal("8-CCE-001/2", Texto(Trecho("8-CCE-001", 2, ""), singelo: false));
        }

        [Fact]
        public void Cabo_singelo_com_uma_veia_sai_so_a_tag()
        {
            // O `Cabos.Formacao like 1x`: com uma veia só, o número some.
            Assert.Equal("8-CCE-001", Texto(Trecho("8-CCE-001", 1, ""), singelo: true));
            Assert.Equal("8-CCE-001/1", Texto(Trecho("8-CCE-001", 1, ""), singelo: false));
        }

        [Fact]
        public void Tag_oculta_tira_a_tag()
        {
            InterligacaoXData ilig = Trecho("8-CCE-001", 2, "");
            ilig.OcultaTag = 1;
            Assert.Equal("2", Texto(ilig, singelo: false));
        }

        [Fact]
        public void Veia_indefinida_sai_o_caracter_de_terminal()
        {
            Assert.Equal("?", Texto(Trecho("8-CCE-001", InterligacaoXData.NumVeiaIndefinido, ""), singelo: false));

            InterligacaoXData oculta = Trecho("8-CCE-001", InterligacaoXData.NumVeiaIndefinido, "");
            oculta.OcultaTag = 1;
            Assert.Equal(string.Empty, Texto(oculta, singelo: false));
        }

        [Fact]
        public void Nome_de_veia_sai_entre_parenteses()
        {
            Assert.Equal("8-CCE-001 (V1)", Texto(Trecho("8-CCE-001", 2, "V1"), singelo: false));

            InterligacaoXData oculta = Trecho("8-CCE-001", 2, "V1");
            oculta.OcultaTag = 1;
            Assert.Equal("(V1)", Texto(oculta, singelo: false));
        }

        // ── A geometria ───────────────────────────────────────────────────────

        [Fact]
        public void Segmento_horizontal_poe_o_rotulo_no_meio_um_acima()
        {
            PosicaoDoRotulo posicao = PosicaoDoRotuloDeCabo.Calcular(Vertices(0, 0, 10, 0));

            Assert.Equal(0.0, posicao.Rotation, 6);
            Assert.Equal(5.0, posicao.AlignX, 6);
            Assert.Equal(1.0, posicao.AlignY, 6);
        }

        [Fact]
        public void Segmento_vertical_usa_o_meio_plano_de_157()
        {
            // `num6 == limite / 2` (1.57): o deslocamento perpendicular troca de sinal.
            PosicaoDoRotulo posicao = PosicaoDoRotuloDeCabo.Calcular(Vertices(0, 0, 0, 10));

            // O `cos`/`sin` de 1.57 (o π arredondado) deixam o alinhamento em
            // -0,996, e não em -1: é o arredondamento do original, não um erro.
            Assert.Equal(1.57, posicao.Rotation, 6);
            Assert.InRange(posicao.AlignX, -1.01, -0.99);
            Assert.InRange(posicao.AlignY, 4.99, 5.01);
        }

        [Fact]
        public void Sentido_contrario_gira_meia_volta()
        {
            PosicaoDoRotulo posicao = PosicaoDoRotuloDeCabo.Calcular(Vertices(10, 0, 0, 0));

            Assert.True(System.Math.Abs(posicao.Rotation) < 0.01);
        }

        [Fact]
        public void Tres_vertices_escolhem_o_maior_segmento()
        {
            // (0,0)-(10,0) é maior que (10,0)-(10,1).
            PosicaoDoRotulo primeiro = PosicaoDoRotuloDeCabo.Calcular(Vertices(0, 0, 10, 0, 10, 1));
            Assert.Equal(5.0, primeiro.AlignX, 6);
            Assert.Equal(1.0, primeiro.AlignY, 6);

            // Agora o segundo é o maior: (1,0)-(1,10).
            PosicaoDoRotulo segundo = PosicaoDoRotuloDeCabo.Calcular(Vertices(0, 0, 1, 0, 1, 10));
            Assert.Equal(1.57, segundo.Rotation, 6);
            Assert.InRange(segundo.AlignX, -0.01, 0.01);
            Assert.InRange(segundo.AlignY, 4.99, 5.01);
        }

        [Fact]
        public void Quatro_vertices_usam_o_segmento_do_meio()
        {
            PosicaoDoRotulo posicao = PosicaoDoRotuloDeCabo.Calcular(Vertices(0, 0, 10, 0, 10, 10, 0, 10));

            Assert.Equal(1.57, posicao.Rotation, 6);
            Assert.InRange(posicao.AlignX, 8.99, 9.01);
            Assert.InRange(posicao.AlignY, 4.99, 5.01);
        }

        [Fact]
        public void Sem_vertices_a_posicao_e_a_origem()
        {
            PosicaoDoRotulo posicao = PosicaoDoRotuloDeCabo.Calcular(null);
            Assert.Equal(0.0, posicao.AlignX, 6);
            Assert.Equal(0.0, posicao.AlignY, 6);
            Assert.Equal(0.0, posicao.Rotation, 6);

            Assert.Equal(0.0, PosicaoDoRotuloDeCabo.Calcular(new List<PontoDoRotulo>()).AlignX, 6);
        }

        // ── Quem sai e quem entra ─────────────────────────────────────────────

        [Fact]
        public void O_rotulo_de_cabo_sai_e_os_outros_tipos_ficam()
        {
            Assert.True(CorrecaoTextosCabo.ApagarRotulo(true, false, true, 1, 0, false));
            Assert.True(CorrecaoTextosCabo.ApagarRotulo(true, false, true, 4, 0, false));
            Assert.True(CorrecaoTextosCabo.ApagarRotulo(true, false, true, 5, 0, false));
            Assert.True(CorrecaoTextosCabo.ApagarRotulo(true, false, true, 6, 0, false));
            Assert.False(CorrecaoTextosCabo.ApagarRotulo(true, false, true, 2, 0, false));
            Assert.False(CorrecaoTextosCabo.ApagarRotulo(true, false, false, 1, 0, false));
        }

        [Fact]
        public void O_tipo_3_so_sai_no_layout_ENEL_ou_com_apagar_tudo()
        {
            Assert.False(CorrecaoTextosCabo.ApagarRotulo(true, false, true, 3, 0, false));
            Assert.True(CorrecaoTextosCabo.ApagarRotulo(true, false, true, 3, 3, false));
            Assert.True(CorrecaoTextosCabo.ApagarRotulo(true, false, true, 2, 0, true));
        }

        [Fact]
        public void O_nao_texto_sai_pelo_app_name_da_variante()
        {
            Assert.True(CorrecaoTextosCabo.ApagarRotulo(false, true, false, 0, 0, false));
            Assert.True(CorrecaoTextosCabo.ApagarRotulo(false, false, true, 0, 0, false));
            Assert.False(CorrecaoTextosCabo.ApagarRotulo(false, false, false, 0, 0, false));
        }

        [Fact]
        public void So_os_trechos_sem_rotulo_entram()
        {
            IReadOnlyList<string> sem = CorrecaoTextosCabo.SemRotulo(
                new List<string> { "A", "B", "C", "" },
                new List<string> { "B" });

            Assert.Equal(new[] { "A", "C" }, sem);
            Assert.Empty(CorrecaoTextosCabo.SemRotulo(null, new List<string> { "A" }));
            Assert.Equal(new[] { "A" }, CorrecaoTextosCabo.SemRotulo(
                new List<string> { "A" }, null));
        }

        // ── Montagem ──────────────────────────────────────────────────────────

        private static string Texto(InterligacaoXData ilig, bool singelo)
        {
            return TextoDoRotuloDeCabo.Calcular(ilig, "/", "?", singelo);
        }

        private static InterligacaoXData Trecho(string tag, int numVeia, string nomeVeia)
        {
            return new InterligacaoXData
            {
                Tag_Cabo = tag,
                NumVeia = numVeia,
                NomeVeia = nomeVeia,
                OcultaTag = 0,
            };
        }

        private static List<PontoDoRotulo> Vertices(params double[] xy)
        {
            List<PontoDoRotulo> vertices = new List<PontoDoRotulo>();
            for (int i = 0; i + 1 < xy.Length; i += 2)
            {
                vertices.Add(new PontoDoRotulo { X = xy[i], Y = xy[i + 1] });
            }

            return vertices;
        }
    }
}

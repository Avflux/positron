using System.Collections.Generic;
using Positron.Contract;
using Positron.Data.Interligacao;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// O <c>CorrigeCabosSingelos</c> (frente 2 do §7.6): a regra que decide os cabos
    /// candidatos (<see cref="CorrecaoCabosSingelos"/>) — a consulta 1 (<c>Cabos = 1</c>)
    /// e a 2 (uma veia só no arquivo, com <c>#</c> no nome).
    /// </summary>
    public class CorrecaoCabosSingelosTests
    {
        [Fact]
        public void Uma_veia_com_marcador_e_candidato()
        {
            IReadOnlyList<string> candidatos = CorrecaoCabosSingelos.Candidatos(
                new List<string> { "C1" },
                new List<VeiasRow> { Veia("C1", 63, 1, "V#") },
                63);

            Assert.Equal(new[] { "C1" }, candidatos);
        }

        [Fact]
        public void Sem_marcador_ou_com_mais_de_uma_veia_nao_e()
        {
            // A regra do original: **exatamente uma** linha no arquivo e o `#`.
            Assert.Empty(CorrecaoCabosSingelos.Candidatos(
                new List<string> { "C1" },
                new List<VeiasRow> { Veia("C1", 63, 1, "V1") },
                63));

            Assert.Empty(CorrecaoCabosSingelos.Candidatos(
                new List<string> { "C1" },
                new List<VeiasRow> { Veia("C1", 63, 1, "V#"), Veia("C1", 63, 2, "V#2") },
                63));

            Assert.Empty(CorrecaoCabosSingelos.Candidatos(
                new List<string> { "C1" },
                new List<VeiasRow>(),
                63));
        }

        [Fact]
        public void Veia_de_outro_arquivo_ou_indice_zero_fica_fora()
        {
            // A leitura é por `Arquivo` (a coluna que o `RCD.mdb` tem — o `DWG` do
            // reverso não existe) e só entram as veias com `indice > 0`.
            Assert.Empty(CorrecaoCabosSingelos.Candidatos(
                new List<string> { "C1" },
                new List<VeiasRow> { Veia("C1", 64, 1, "V#") },
                63));

            Assert.Empty(CorrecaoCabosSingelos.Candidatos(
                new List<string> { "C1" },
                new List<VeiasRow> { Veia("C1", 63, 0, "V#") },
                63));
        }

        [Fact]
        public void A_ordem_dos_candidatos_e_a_da_consulta_1()
        {
            IReadOnlyList<string> candidatos = CorrecaoCabosSingelos.Candidatos(
                new List<string> { "C3", "C1", "C2" },
                new List<VeiasRow>
                {
                    Veia("C1", 63, 1, "A#"),
                    Veia("C2", 63, 1, "B#"),
                    Veia("C3", 63, 1, "C#"),
                },
                63);

            Assert.Equal(new[] { "C3", "C1", "C2" }, candidatos);
        }

        [Fact]
        public void Sem_tags_ou_sem_veias_nao_ha_candidato()
        {
            Assert.Empty(CorrecaoCabosSingelos.Candidatos(null, null, 63));
            Assert.Empty(CorrecaoCabosSingelos.Candidatos(new List<string>(), new List<VeiasRow>(), 63));
            Assert.False(CorrecaoCabosSingelos.PrecisaLimpar(1, null));
            Assert.False(CorrecaoCabosSingelos.PrecisaLimpar(2, "V#"));
            Assert.True(CorrecaoCabosSingelos.PrecisaLimpar(1, "V#1"));
        }

        [Fact]
        public void So_os_trechos_da_lista_entram()
        {
            IReadOnlyList<string> limpar = CorrecaoCabosSingelos.TrechosParaLimpar(
                new List<string> { "C1", "C9", "C2", "" },
                new List<string> { "C1", "C2" });

            Assert.Equal(new[] { "C1", "C2" }, limpar);
            Assert.Empty(CorrecaoCabosSingelos.TrechosParaLimpar(null, new List<string> { "C1" }));
            Assert.Empty(CorrecaoCabosSingelos.TrechosParaLimpar(new List<string> { "C1" }, null));
        }

        // ── Montagem ──────────────────────────────────────────────────────────

        private static VeiasRow Veia(string tag, int arquivo, int indice, string nome)
        {
            return new VeiasRow
            {
                Tag = tag,
                Arquivo = arquivo,
                Indice = indice,
                Nome_Veia = nome,
            };
        }
    }
}

using System.Collections.Generic;
using Positron.Contract;
using Positron.Data.Bornes;
using Positron.Data.Fiacao;
using Positron.Data.Plaquetas;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// O <c>exportaPlaquetas</c> (<c>EPLQ</c>) do original: o que é puro é o leitor do
    /// dicionário <c>CENG_PLAQUETA</c> (<see cref="PlaquetasXData"/>) e a resolução do
    /// nome de cada plaqueta (<see cref="Plaquetas4Gerador"/>).
    /// </summary>
    public class Plaquetas4Tests
    {
        private static List<TypedXData> Registro(string tipo, string handle, int indiceRegua, string d1, string d2, string d3, string modelo)
        {
            return new List<TypedXData>
            {
                new TypedXData(1, tipo),
                new TypedXData(1, handle),
                new TypedXData(70, indiceRegua),
                new TypedXData(1, d1),
                new TypedXData(1, d2),
                new TypedXData(1, d3),
                new TypedXData(1, modelo),
            };
        }

        // ── Leitor do dicionário (CENG_PLAQUETA) ──────────────────────────────

        [Fact]
        public void Le_registros_de_sete_em_sete()
        {
            List<TypedXData> valores = Registro("P", "H1", 0, "D1", "", "", "M1");
            valores.AddRange(Registro("D", "H2", 0, "D2", "D3", "", "M2"));

            IReadOnlyList<PlaquetaDefinicao> plaquetas = PlaquetasXData.Ler(valores);

            Assert.Equal(2, plaquetas.Count);
            Assert.Equal("P", plaquetas[0].Tipo);
            Assert.Equal("H1", plaquetas[0].Handle);
            Assert.Equal("D1", plaquetas[0].Desc1);
            Assert.Equal("M1", plaquetas[0].Modelo);
            Assert.Equal("D", plaquetas[1].Tipo);
            Assert.Equal("H2", plaquetas[1].Handle);
            Assert.Equal("D2", plaquetas[1].Desc1);
            Assert.Equal("D3", plaquetas[1].Desc2);
            Assert.Equal("M2", plaquetas[1].Modelo);
        }

        [Fact]
        public void Le_indice_de_regua()
        {
            IReadOnlyList<PlaquetaDefinicao> plaquetas =
                PlaquetasXData.Ler(Registro("R", "H1", 37, "D1", "", "", ""));

            Assert.Equal(37, plaquetas[0].IndiceRegua);
        }

        [Fact]
        public void Ignora_cauda_incompleta()
        {
            // Um registro incompleto no fim não vira plaqueta nem estoura.
            List<TypedXData> valores = Registro("P", "H1", 0, "D1", "", "", "M1");
            valores.Add(new TypedXData(1, "D"));

            IReadOnlyList<PlaquetaDefinicao> plaquetas = PlaquetasXData.Ler(valores);

            Assert.Single(plaquetas);
        }

        [Fact]
        public void Registro_curto_devolve_vazio()
        {
            Assert.Empty(PlaquetasXData.Ler(new List<TypedXData> { new TypedXData(1, "P") }));
            Assert.Empty(PlaquetasXData.Ler(null));
        }

        // ── Gerador ───────────────────────────────────────────────────────────

        private static ReguasModelo Reguas()
        {
            // Índice 0 = cabeçalho; cada régua ocupa 10 valores, com
            // indexRegua/nomeRegua/alternativo/indexPainel nos 4 primeiros.
            List<TypedXData> valores = new List<TypedXData> { new TypedXData(70, 37) };
            valores.Add(new TypedXData(70, 37));
            valores.Add(new TypedXData(1, "R6"));
            valores.Add(new TypedXData(1, ""));
            valores.Add(new TypedXData(70, 9));
            for (int i = 0; i < 6; i++)
            {
                valores.Add(new TypedXData(1, ""));
            }

            return ReguasModelo.Ler(valores);
        }

        private static Dictionary<int, IReadOnlyList<PlaquetaDefinicao>> Dicionario(params PlaquetaDefinicao[] plaquetas)
        {
            return new Dictionary<int, IReadOnlyList<PlaquetaDefinicao>>
            {
                { 9, new List<PlaquetaDefinicao>(plaquetas) },
            };
        }

        private static PlaquetaDefinicao Plaqueta(string tipo, string handle, int indiceRegua, string d1, string d2, string d3, string modelo)
        {
            return new PlaquetaDefinicao
            {
                Tipo = tipo,
                Handle = handle,
                IndiceRegua = indiceRegua,
                Desc1 = d1,
                Desc2 = d2,
                Desc3 = d3,
                Modelo = modelo,
            };
        }

        private static List<Plaquetas4Row> Gerar(
            Dictionary<int, IReadOnlyList<PlaquetaDefinicao>> dicionario,
            Dictionary<int, IReadOnlyDictionary<string, string>> dispositivos,
            params int[] comFiacao)
        {
            return Plaquetas4Gerador.Gerar(
                63,
                dicionario,
                new Dictionary<int, string> { { 9, "PAINEL-9" } },
                Reguas(),
                new List<int>(comFiacao),
                dispositivos);
        }

        [Fact]
        public void Tipo_P_recebe_o_nome_do_painel()
        {
            List<Plaquetas4Row> linhas = Gerar(
                Dicionario(Plaqueta("P", "H1", 0, "D1", "", "", "M1")),
                new Dictionary<int, IReadOnlyDictionary<string, string>>(),
                9);

            Assert.Single(linhas);
            Assert.Equal("PAINEL-9", linhas[0].Tag);
            Assert.Equal(9, linhas[0].Painel);
            Assert.Equal(63, linhas[0].DWG);
            Assert.Equal("D1", linhas[0].Desc1);
            Assert.Equal("M1", linhas[0].Modelo);
            Assert.Null(linhas[0].Quantidade);
        }

        [Fact]
        public void Tipo_D_recebe_o_nome_do_dispositivo_pelo_handle()
        {
            Dictionary<int, IReadOnlyDictionary<string, string>> dispositivos =
                new Dictionary<int, IReadOnlyDictionary<string, string>>
                {
                    { 9, new Dictionary<string, string> { { "H2", "DISJ-1/2" } } },
                };

            List<Plaquetas4Row> linhas = Gerar(
                Dicionario(Plaqueta("D", "H2", 0, "D1", "", "", "M1")),
                dispositivos,
                9);

            Assert.Single(linhas);
            Assert.Equal("DISJ-1/2", linhas[0].Tag);
        }

        [Fact]
        public void Tipo_D_sem_dispositivo_no_mapa_nao_grava()
        {
            List<Plaquetas4Row> linhas = Gerar(
                Dicionario(Plaqueta("D", "H9", 0, "D1", "", "", "M1")),
                new Dictionary<int, IReadOnlyDictionary<string, string>>(),
                9);

            Assert.Empty(linhas);
        }

        [Fact]
        public void Tipo_X_recebe_a_primeira_descricao_nao_vazia()
        {
            List<Plaquetas4Row> linhas = Gerar(
                Dicionario(Plaqueta("X", "#1", 0, "   ", "SEGUNDA", "", "M1")),
                new Dictionary<int, IReadOnlyDictionary<string, string>>(),
                9);

            Assert.Single(linhas);
            Assert.Equal("SEGUNDA", linhas[0].Tag);
        }

        [Fact]
        public void Tipo_R_recebe_o_nome_da_regua()
        {
            List<Plaquetas4Row> linhas = Gerar(
                Dicionario(Plaqueta("R", "H1", 37, "D1", "", "", "M1")),
                new Dictionary<int, IReadOnlyDictionary<string, string>>(),
                9);

            Assert.Single(linhas);
            Assert.Equal("R6", linhas[0].Tag);
        }

        [Fact]
        public void Tipo_R_sem_regua_no_dicionario_nao_grava()
        {
            List<Plaquetas4Row> linhas = Gerar(
                Dicionario(Plaqueta("R", "H1", 999, "D1", "", "", "M1")),
                new Dictionary<int, IReadOnlyDictionary<string, string>>(),
                9);

            Assert.Empty(linhas);
        }

        [Fact]
        public void Tipo_desconhecido_nao_grava()
        {
            List<Plaquetas4Row> linhas = Gerar(
                Dicionario(Plaqueta("Z", "H1", 0, "D1", "", "", "M1")),
                new Dictionary<int, IReadOnlyDictionary<string, string>>(),
                9);

            Assert.Empty(linhas);
        }

        [Fact]
        public void Sem_nenhuma_descricao_nao_grava()
        {
            // Nome existe (painel), mas a plaqueta não tem o que imprimir.
            List<Plaquetas4Row> linhas = Gerar(
                Dicionario(Plaqueta("P", "H1", 0, "", "", "", "M1")),
                new Dictionary<int, IReadOnlyDictionary<string, string>>(),
                9);

            Assert.Empty(linhas);
        }

        [Fact]
        public void Painel_sem_fiacao_no_desenho_nao_grava()
        {
            List<Plaquetas4Row> linhas = Gerar(
                Dicionario(Plaqueta("P", "H1", 0, "D1", "", "", "M1")),
                new Dictionary<int, IReadOnlyDictionary<string, string>>());

            Assert.Empty(linhas);
        }

        [Fact]
        public void Painel_sem_registro_no_dicionario_nao_grava()
        {
            List<Plaquetas4Row> linhas = Gerar(
                new Dictionary<int, IReadOnlyList<PlaquetaDefinicao>>
                {
                    { 77, new List<PlaquetaDefinicao> { Plaqueta("P", "H1", 0, "D1", "", "", "M1") } },
                },
                new Dictionary<int, IReadOnlyDictionary<string, string>>(),
                9);

            Assert.Empty(linhas);
        }

        [Fact]
        public void Comparacao_de_tipo_ignora_caixa()
        {
            List<Plaquetas4Row> linhas = Gerar(
                Dicionario(Plaqueta("p", "H1", 0, "D1", "", "", "M1")),
                new Dictionary<int, IReadOnlyDictionary<string, string>>(),
                9);

            Assert.Single(linhas);
            Assert.Equal("PAINEL-9", linhas[0].Tag);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Positron.Contract;
using Positron.Data.Cabos;
using Xunit;

namespace Positron.Data.Tests
{
    public class CabosVeias4Tests
    {
        [Fact]
        public void Cabos_do_catalogo_viram_cabos4_com_a_revisao()
        {
            List<CabosRow> catalogo = new List<CabosRow>
            {
                new CabosRow
                {
                    Tag = "C1",
                    Formacao = "3F",
                    Blindagem = true,
                    Pn1 = 1,
                    Pn2 = 2,
                    Codigo = "ABC",
                    Funcao = "F",
                    Alarme = 9,
                    Aterrar = 1,
                    Comprimento = 12.5,
                    Trajeto = "T",
                    Instrucao = "I",
                    Diametro = 8.0,
                    Grupo = "G",
                    Cabos = 1,
                },
            };

            List<Cabos4Row> linhas = CabosVeias4Gerador.GerarCabos(catalogo, "R1", "ana", new DateTime(2026, 10, 8));

            Cabos4Row linha = Assert.Single(linhas);
            Assert.Equal("R1", linha.Revisao);
            Assert.Equal("C1", linha.Tag);
            Assert.Equal("3F", linha.Formacao);
            Assert.True(linha.Blindagem);
            Assert.Equal(1L, linha.Pn1.Value);
            Assert.Equal(2L, linha.Pn2.Value);
            Assert.Equal("ABC", linha.Codigo);
            Assert.Equal("F", linha.Funcao);
            Assert.Equal(1L, linha.Aterrar.Value);
            Assert.Equal(12.5, linha.Comprimento.Value);
            Assert.Equal("T", linha.Trajeto);
            Assert.Equal("I", linha.Instrucao);
            Assert.Equal(8.0, linha.Diametro.Value);
            Assert.Equal("G", linha.Grupo);
            Assert.Equal(1L, linha.Cabos.Value);
            Assert.Equal("ana", linha.Criador);
            Assert.Equal(new DateTime(2026, 10, 8), linha.Data.Value);
        }

        [Fact]
        public void Veias_mapeiam_indice_para_num_veia()
        {
            List<VeiasRow> catalogo = new List<VeiasRow>
            {
                new VeiasRow { Tag = "V1", Indice = 3, Nome_Veia = "Azul", Uso = true, Funcao = "F" },
            };

            List<Veias4Row> linhas = CabosVeias4Gerador.GerarVeias(catalogo, "R1");

            Veias4Row linha = Assert.Single(linhas);
            Assert.Equal("R1", linha.Revisao);
            Assert.Equal("V1", linha.Tag);
            Assert.Equal(3L, linha.Num_Veia.Value);
            Assert.Equal("Azul", linha.Nome_Veia);
            Assert.True(linha.Uso);
            Assert.Equal("F", linha.Funcao);
        }

        [Fact]
        public void Regravar_substitui_a_revisao_em_vez_de_duplicar()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);

                List<Cabos4Row> primeira = CabosVeias4Gerador.GerarCabos(
                    new List<CabosRow> { new CabosRow { Tag = "C1" } }, "R1", "ana", DateTime.Now);
                store.RegravarCabos4("R1", primeira);
                Assert.Single(store.Cabos4PorRevisao("R1"));

                List<Cabos4Row> segunda = CabosVeias4Gerador.GerarCabos(
                    new List<CabosRow> { new CabosRow { Tag = "C2", Blindagem = true }, new CabosRow { Tag = "C3" } },
                    "R1", "bia", DateTime.Now);
                store.RegravarCabos4("R1", segunda);

                IReadOnlyList<Cabos4Row> gravados = store.Cabos4PorRevisao("R1");
                Assert.Equal(2, gravados.Count);
                Assert.Equal("C2", gravados[0].Tag);
                Assert.Equal("C3", gravados[1].Tag);
                Assert.Equal("bia", gravados[0].Criador);

                List<Veias4Row> veias = CabosVeias4Gerador.GerarVeias(
                    new List<VeiasRow> { new VeiasRow { Tag = "V1", Indice = 1, Nome_Veia = "A", Uso = true } }, "R1");
                store.RegravarVeias4("R1", veias);
                store.RegravarVeias4("R1", veias);
                Assert.Single(store.Veias4PorRevisao("R1"));
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }

        [Fact]
        public void Ler_catalogo_do_banco_alimenta_o_snapshot()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                InserirCatalogo(caminho);
                ProjectStore store = new ProjectStore(caminho);

                List<Cabos4Row> cabos = CabosVeias4Gerador.GerarCabos(store.LerCabos(), "R1", "ana", DateTime.Now);
                Assert.Single(cabos);
                Assert.Equal("C1", cabos[0].Tag);
                Assert.Equal("3F", cabos[0].Formacao);

                List<Veias4Row> veias = CabosVeias4Gerador.GerarVeias(store.LerVeias(), "R1");
                Assert.Single(veias);
                Assert.Equal("V1", veias[0].Tag);
                Assert.Equal(3L, veias[0].Num_Veia.Value);
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }

        private static void InserirCatalogo(string caminho)
        {
            using (SQLiteConnection conexao = new SQLiteConnection("Data Source=" + caminho + ";Version=3;"))
            {
                conexao.Open();
                using (SQLiteCommand comando = conexao.CreateCommand())
                {
                    comando.CommandText = "INSERT INTO Cabos(Tag, Formacao, Blindagem, Pn1, Cabos) VALUES('C1', '3F', 1, 1, 1)";
                    comando.ExecuteNonQuery();

                    comando.CommandText = "INSERT INTO Veias(Tag, Indice, Nome_Veia, Uso, Chave) VALUES('V1', 3, 'Azul', 1, 1)";
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}

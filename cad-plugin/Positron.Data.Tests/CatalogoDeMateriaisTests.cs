using System.Collections.Generic;
using System.Data.SQLite;
using Positron.Data;
using Positron.Data.Materiais;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// O catálogo de materiais (<c>Materiais</c>) — a leitura que as duas telas de materiais do
    /// reverso usam (rodada 148): o <c>frmGerenciadorMateriais</c> (<c>GERLM</c>) monta a grade com
    /// ele e o <c>frmGerenciadorMatIndep</c> (<c>ATINDEP</c>) procura o material da linha da lista
    /// pelo código interno.
    /// </summary>
    public class CatalogoDeMateriaisTests
    {
        [Fact]
        public void Le_o_catalogo_ordenado_por_codigo_interno()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                using (SQLiteConnection conexao = Abrir(caminho))
                {
                    Executar(conexao, "INSERT INTO Materiais(Indice, CodigoInterno, CodigoCliente, Modelo, "
                        + "Fabricante, DescricaoResumida, DescricaoCompleta) VALUES (9, 518, 'C3', 'M3', 'F3', 'Res 3', 'Completa 3')");
                    Executar(conexao, "INSERT INTO Materiais(Indice, CodigoInterno, CodigoCliente, Modelo, "
                        + "Fabricante, DescricaoResumida) VALUES (2, 458, 'C1', 'M1', 'F1', 'Res 1')");
                    Executar(conexao, "INSERT INTO Materiais(Indice, CodigoInterno, CodigoCliente, Modelo, "
                        + "Fabricante, DescricaoResumida, DescricaoCompleta) VALUES (5, 476, 'C2', 'M2', 'F2', 'Res 2', 'Completa 2')");
                }

                List<MaterialDoCatalogo> materiais = new ProjectStore(caminho).LerMateriais();

                // A ordem é a do original: `order by CodigoInterno`.
                Assert.Equal(new[] { 458, 476, 518 }, materiais.ConvertAll(m => m.CodigoInterno));
                Assert.Equal(2, materiais[0].Indice);
                Assert.Equal("C1", materiais[0].CodigoCliente);
                Assert.Equal("M1", materiais[0].Modelo);
                Assert.Equal("F1", materiais[0].Fabricante);
                Assert.Equal("Res 1", materiais[0].DescricaoResumida);
                // Coluna nula sai vazia (o `TiraDBNull` do original), nunca `null`.
                Assert.Equal(string.Empty, materiais[0].DescricaoCompleta);
                Assert.Equal("Completa 3", materiais[2].DescricaoCompleta);
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }

        [Fact]
        public void Indexa_por_codigo_interno_e_o_primeiro_fica()
        {
            List<MaterialDoCatalogo> materiais = new List<MaterialDoCatalogo>
            {
                new MaterialDoCatalogo { Indice = 1, CodigoInterno = 458, DescricaoResumida = "primeiro" },
                new MaterialDoCatalogo { Indice = 2, CodigoInterno = 458, DescricaoResumida = "segundo" },
                new MaterialDoCatalogo { Indice = 3, CodigoInterno = 476, DescricaoResumida = "outro" },
            };

            IReadOnlyDictionary<int, MaterialDoCatalogo> indice = CatalogoDeMateriais.Indexar(materiais);

            Assert.Equal(2, indice.Count);
            Assert.Equal("primeiro", indice[458].DescricaoResumida);

            // O `ODLpp1Gpc7y`/`MesclaDGDisp` do original: procura pelo código interno e não lança.
            Assert.Equal("outro", CatalogoDeMateriais.Buscar(indice, 476).DescricaoResumida);
            Assert.Null(CatalogoDeMateriais.Buscar(indice, 999));
            Assert.Null(CatalogoDeMateriais.Buscar(null, 458));
        }

        [Fact]
        public void Paineis_da_lista_saem_distintos_na_ordem_da_lista()
        {
            List<LinhaListaMaterial> linhas = new List<LinhaListaMaterial>
            {
                new LinhaListaMaterial { Painel = 9, Tag = "R1" },
                new LinhaListaMaterial { Painel = 503, Tag = "D1" },
                new LinhaListaMaterial { Painel = 9, Tag = "R2" },
                new LinhaListaMaterial { Painel = 155, Tag = "R6" },
                new LinhaListaMaterial { Painel = 503, Tag = "D2" },
            };

            Assert.Equal(new[] { 9, 503, 155 }, PaineisDaListaDeMateriais.Distintos(linhas));
            Assert.Empty(PaineisDaListaDeMateriais.Distintos(null));
        }

        [Fact]
        public void Linhas_do_painel_saem_na_ordem_em_que_vieram()
        {
            List<LinhaListaMaterial> linhas = new List<LinhaListaMaterial>
            {
                new LinhaListaMaterial { Painel = 9, Tag = "R1", IndiceMaterial = 10 },
                new LinhaListaMaterial { Painel = 503, Tag = "D1", IndiceMaterial = 20 },
                new LinhaListaMaterial { Painel = 9, Tag = "R2", IndiceMaterial = 11 },
            };

            List<LinhaListaMaterial> doPainel = PaineisDaListaDeMateriais.DoPainel(linhas, 9);

            Assert.Equal(new[] { "R1", "R2" }, doPainel.ConvertAll(l => l.Tag));
            Assert.Empty(PaineisDaListaDeMateriais.DoPainel(linhas, 77));
        }

        private static SQLiteConnection Abrir(string caminho)
        {
            SQLiteConnection conexao = new SQLiteConnection("Data Source=" + caminho + ";Version=3;");
            conexao.Open();
            return conexao;
        }

        private static void Executar(SQLiteConnection conexao, string sql)
        {
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText = sql;
                comando.ExecuteNonQuery();
            }
        }
    }
}

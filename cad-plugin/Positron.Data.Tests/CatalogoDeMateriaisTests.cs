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

        [Fact]
        public void ProximoCodigo_usa_o_digitado_quando_e_numero()
        {
            List<int> grade = new List<int> { 4, 5 };

            // O `Versioned.IsNumeric` do VB tem prioridade sobre a grade.
            Assert.Equal(4, CatalogoDeMateriais.ProximoCodigo(grade, "4"));
            Assert.Equal(9, CatalogoDeMateriais.ProximoCodigo(grade, "9"));
            // Decimal no campo (o `ToInteger` arredonda).
            Assert.Equal(6, CatalogoDeMateriais.ProximoCodigo(grade, "5.6"));
        }

        [Fact]
        public void ProximoCodigo_e_o_maior_da_grade_mais_um()
        {
            // O laço do original: `num = 1` e, a cada código, `if (num < codigo) num = codigo + 1`.
            Assert.Equal(8, CatalogoDeMateriais.ProximoCodigo(new List<int> { 5, 7 }, ""));
            Assert.Equal(10, CatalogoDeMateriais.ProximoCodigo(new List<int> { 3, 9, 5 }, "abc"));
            Assert.Equal(1, CatalogoDeMateriais.ProximoCodigo(new List<int>(), ""));
            Assert.Equal(1, CatalogoDeMateriais.ProximoCodigo(null, null));
        }

        [Fact]
        public void Plano_de_gravacao_segue_a_ordem_do_original()
        {
            List<LinhaDoCatalogoNaGrade> linhas = new List<LinhaDoCatalogoNaGrade>
            {
                // Sem marca: veio do banco e não foi tocada.
                new LinhaDoCatalogoNaGrade { CodigoInterno = 4, Marca = "" },
                // `A` = acrescentada na tela: sai um remover defensivo antes do adicionar.
                new LinhaDoCatalogoNaGrade { CodigoInterno = 12, Marca = "A", CodigoCliente = "CC", Modelo = "M" },
                // `E` = editada na tela.
                new LinhaDoCatalogoNaGrade { CodigoInterno = 5, Marca = "E", DescricaoResumida = "nova" },
            };

            List<OperacaoNoCatalogo> plano = CatalogoDeMateriais.PlanoDeGravacao(linhas, new List<int> { 77 });

            // 1) os apagados na tela, 2) o par remover+adicionar do `A`, 3) a edição do `E`.
            Assert.Equal(
                new[]
                {
                    TipoDeOperacaoNoCatalogo.Remover,
                    TipoDeOperacaoNoCatalogo.Remover,
                    TipoDeOperacaoNoCatalogo.Adicionar,
                    TipoDeOperacaoNoCatalogo.Editar,
                },
                plano.ConvertAll(o => o.Tipo));
            Assert.Equal(new[] { 77, 12, 12, 5 }, plano.ConvertAll(o => o.Material.CodigoInterno));
            Assert.Equal("CC", plano[2].Material.CodigoCliente);
            Assert.Equal("nova", plano[3].Material.DescricaoResumida);
        }

        [Fact]
        public void Escreve_o_catalogo_no_banco()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);

                store.AdicionarMaterial(new MaterialDoCatalogo
                {
                    CodigoInterno = 12,
                    CodigoCliente = "CC12",
                    Modelo = "M12",
                    Fabricante = "F12",
                    DescricaoResumida = "Res 12",
                    DescricaoCompleta = "Completa 12",
                });

                MaterialDoCatalogo lido = Assert.Single(store.LerMateriais());
                Assert.Equal(12, lido.CodigoInterno);
                Assert.Equal("CC12", lido.CodigoCliente);
                Assert.Equal("Completa 12", lido.DescricaoCompleta);
                Assert.True(lido.Indice > 0, "o Indice e a chave que o banco atribui (o insert nao manda)");

                // A edição não troca o código interno — só os cinco campos.
                store.EditarMaterial(new MaterialDoCatalogo
                {
                    CodigoInterno = 12,
                    CodigoCliente = "NOVO",
                    Modelo = "M12",
                    Fabricante = "F12",
                    DescricaoResumida = "Res 12 nova",
                    DescricaoCompleta = "Completa 12 nova",
                });

                lido = Assert.Single(store.LerMateriais());
                Assert.Equal("NOVO", lido.CodigoCliente);
                Assert.Equal("Res 12 nova", lido.DescricaoResumida);
                Assert.Equal("Completa 12 nova", lido.DescricaoCompleta);

                Assert.Equal(1, store.RemoverMaterial(12));
                Assert.Empty(store.LerMateriais());
                // O código que não existe mais não derruba nem mente.
                Assert.Equal(0, store.RemoverMaterial(12));
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }

        [Fact]
        public void Plano_aplicado_grava_o_catalogo()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);
                store.AdicionarMaterial(new MaterialDoCatalogo { CodigoInterno = 1, DescricaoResumida = "um" });
                store.AdicionarMaterial(new MaterialDoCatalogo { CodigoInterno = 77, DescricaoResumida = "fora" });

                List<LinhaDoCatalogoNaGrade> linhas = new List<LinhaDoCatalogoNaGrade>
                {
                    new LinhaDoCatalogoNaGrade { CodigoInterno = 1, Marca = "E", DescricaoResumida = "um novo" },
                    new LinhaDoCatalogoNaGrade { CodigoInterno = 12, Marca = "A", DescricaoResumida = "doze" },
                };

                Executar(store, CatalogoDeMateriais.PlanoDeGravacao(linhas, new List<int> { 77 }));

                List<MaterialDoCatalogo> lidos = store.LerMateriais();
                Assert.Equal(new[] { 1, 12 }, lidos.ConvertAll(m => m.CodigoInterno));
                Assert.Equal("um novo", lidos[0].DescricaoResumida);
                Assert.Equal("doze", lidos[1].DescricaoResumida);
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }

        /// <summary>Executa o plano na mesma ordem em que a ligação do <c>GERLM</c> o executa.</summary>
        private static void Executar(ProjectStore store, List<OperacaoNoCatalogo> plano)
        {
            foreach (OperacaoNoCatalogo operacao in plano)
            {
                switch (operacao.Tipo)
                {
                    case TipoDeOperacaoNoCatalogo.Remover:
                        store.RemoverMaterial(operacao.Material.CodigoInterno);
                        break;
                    case TipoDeOperacaoNoCatalogo.Adicionar:
                        store.AdicionarMaterial(operacao.Material);
                        break;
                    default:
                        store.EditarMaterial(operacao.Material);
                        break;
                }
            }
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

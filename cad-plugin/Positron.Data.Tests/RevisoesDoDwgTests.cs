using System.Collections.Generic;
using System.Data.SQLite;
using Positron.Data;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// <see cref="ProjectStore.LerRevisoes"/> — as revisões do DWG que já têm compilação, o insumo
    /// da grade <c>dgRevisao</c> das telas <c>frmCompilar*</c> (rodada 140).
    /// </summary>
    public class RevisoesDoDwgTests
    {
        [Fact]
        public void Reune_as_tres_tabelas_com_o_carimbo_mais_recente()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                using (SQLiteConnection conexao = Abrir(caminho))
                {
                    Executar(conexao, "INSERT INTO Fiacao(Revisao, DWG, Criador, Data, BJumper, BLink) "
                        + "VALUES ('R1', 63, 'ana', '2026-10-01', 0, 0)");
                    Executar(conexao, "INSERT INTO Interligacao4(Revisao, DWG, Criador, Data) "
                        + "VALUES ('R0', 63, 'bruno', '2026-09-30')");
                    Executar(conexao, "INSERT INTO Jumper4(Revisao, DWG, Criador, Data, BJumper, BLink) "
                        + "VALUES ('R1', 63, 'ana', '2026-10-02', 0, 0)");
                }

                IReadOnlyList<RevisaoDoDwg> revisoes = new ProjectStore(caminho).LerRevisoes(63);

                Assert.Equal(2, revisoes.Count);
                Assert.Equal("R0", revisoes[0].Revisao);
                Assert.Equal("bruno", revisoes[0].Criador);
                Assert.Equal("2026-09-30", revisoes[0].Data);
                Assert.Equal("R1", revisoes[1].Revisao);
                Assert.Equal("ana", revisoes[1].Criador);
                Assert.Equal("2026-10-02", revisoes[1].Data);
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }

        [Fact]
        public void So_as_revisoes_do_dwg_pedido()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                using (SQLiteConnection conexao = Abrir(caminho))
                {
                    Executar(conexao, "INSERT INTO Fiacao(Revisao, DWG, BJumper, BLink) VALUES ('R0', 63, 0, 0)");
                    Executar(conexao, "INSERT INTO Fiacao(Revisao, DWG, BJumper, BLink) VALUES ('R9', 74, 0, 0)");
                }

                IReadOnlyList<RevisaoDoDwg> revisoes = new ProjectStore(caminho).LerRevisoes(63);

                RevisaoDoDwg unica = Assert.Single(revisoes);
                Assert.Equal("R0", unica.Revisao);
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }

        [Fact]
        public void Sem_compilacao_devolve_vazio()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                Assert.Empty(new ProjectStore(caminho).LerRevisoes(63));
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }

        [Fact]
        public void Revisao_nula_vira_texto_vazio()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                using (SQLiteConnection conexao = Abrir(caminho))
                {
                    Executar(conexao, "INSERT INTO Interligacao4(DWG) VALUES (63)");
                }

                RevisaoDoDwg unica = Assert.Single(new ProjectStore(caminho).LerRevisoes(63));
                Assert.Equal(string.Empty, unica.Revisao);
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
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

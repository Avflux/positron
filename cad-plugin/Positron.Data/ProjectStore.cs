using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Positron.Contract;
using Positron.Data.Fiacao;
using Positron.Data.Interligacao;
using Positron.Data.Modelos;

namespace Positron.Data
{
    /// <summary>
    /// Acesso do plugin ao `.db` do projeto — o MESMO arquivo que o frontend APP
    /// lê pelo sidecar (ver docs/POSITRON.md).
    ///
    /// Divisão de trabalho: o plugin é quem ESCREVE as tabelas derivadas do
    /// diagrama (Fiacao, Interligacao4, ...); o app só lê. Por isso aqui não há
    /// nenhuma dependência do sidecar — draftar no ZWCAD não pode depender de
    /// outro processo estar no ar.
    /// </summary>
    public sealed class ProjectStore
    {
        private readonly string _caminho;

        public ProjectStore(string caminho)
        {
            if (string.IsNullOrWhiteSpace(caminho))
            {
                throw new ArgumentException("caminho do banco vazio", "caminho");
            }

            _caminho = caminho;
        }

        public string Caminho
        {
            get { return _caminho; }
        }

        /// <summary>
        /// Abre uma conexão já em WAL. Sem WAL, uma conexão longa do app bloquearia
        /// o plugin no meio de um comando (e vice-versa).
        /// </summary>
        private SQLiteConnection Abrir()
        {
            SQLiteConnection conexao = new SQLiteConnection("Data Source=" + _caminho + ";Version=3;");
            conexao.Open();
            DefinirPragma(conexao, "PRAGMA journal_mode=WAL");
            DefinirPragma(conexao, "PRAGMA busy_timeout=5000");
            return conexao;
        }

        private static void DefinirPragma(SQLiteConnection conexao, string sql)
        {
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText = sql;
                comando.ExecuteNonQuery();
            }
        }

        public int ContarFiacaoDoPainel(long painel)
        {
            using (SQLiteConnection conexao = Abrir())
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText = "SELECT COUNT(*) FROM Fiacao WHERE Painel = @painel";
                comando.Parameters.AddWithValue("@painel", painel);
                return Convert.ToInt32(comando.ExecuteScalar());
            }
        }

        /// <summary>
        /// Lê a fiação de um painel já nas linhas do contrato gerado
        /// (<see cref="FiacaoRow"/>). Mapeia as colunas que o fluxo de fiação do
        /// scaffold usa; a projeção completa entra na fase 5.
        /// </summary>
        public IReadOnlyList<FiacaoRow> FiacaoDoPainel(long painel)
        {
            List<FiacaoRow> linhas = new List<FiacaoRow>();
            using (SQLiteConnection conexao = Abrir())
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                // Ordem reinicia a cada potencial, então Potencial vem primeiro.
                comando.CommandText =
                    "SELECT Indice, Revisao, DWG, Painel, Potencial, Ordem, Pagina, Tag, Terminal, Secao, Cor, " +
                    "Criador FROM Fiacao WHERE Painel = @painel ORDER BY Potencial, Ordem";
                comando.Parameters.AddWithValue("@painel", painel);

                using (SQLiteDataReader leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        linhas.Add(LerFiacao(leitor));
                    }
                }
            }

            return linhas;
        }

        /// <summary>
        /// Grava as linhas de fiação. A lista de colunas é a do INSERT do original
        /// (<c>cDadosAccessFiacao.AdicionaItemPotencial</c>); <c>Indice</c> fica de
        /// fora de propósito — o SQLite atribui o rowid.
        ///
        /// Uma conexão e um comando preparado para o lote inteiro: projetar fiação
        /// costuma ser centenas de linhas, e abrir conexão por linha seria lento.
        /// </summary>
        public void InserirFiacao(IEnumerable<PontoFiacao> pontos)
        {
            using (SQLiteConnection conexao = Abrir())
            using (SQLiteTransaction transacao = conexao.BeginTransaction())
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText =
                    "INSERT INTO Fiacao(Revisao, DWG, Painel, Potencial, Ordem, Pagina, Tag, Alternativo, NRegua, " +
                    "Terminal, TerminalNum, Tipo, Secao, Cor, PosicaoNum, TipoBorne, BJumper, BLink, Handle, " +
                    "IndexModelo, Aplicacao, Criador, Data) " +
                    "VALUES(@revisao, @dwg, @painel, @potencial, @ordem, @pagina, @tag, @alternativo, @nregua, " +
                    "@terminal, @terminalNum, @tipo, @secao, @cor, @posicaoNum, @tipoBorne, @bJumper, @bLink, " +
                    "@handle, @indexModelo, @aplicacao, @criador, @data)";

                SQLiteParameter[] parametros =
                {
                    comando.Parameters.Add("@revisao", System.Data.DbType.String),
                    comando.Parameters.Add("@dwg", System.Data.DbType.Int32),
                    comando.Parameters.Add("@painel", System.Data.DbType.Int32),
                    comando.Parameters.Add("@potencial", System.Data.DbType.Int32),
                    comando.Parameters.Add("@ordem", System.Data.DbType.Int32),
                    comando.Parameters.Add("@pagina", System.Data.DbType.String),
                    comando.Parameters.Add("@tag", System.Data.DbType.String),
                    comando.Parameters.Add("@alternativo", System.Data.DbType.String),
                    comando.Parameters.Add("@nregua", System.Data.DbType.String),
                    comando.Parameters.Add("@terminal", System.Data.DbType.String),
                    comando.Parameters.Add("@terminalNum", System.Data.DbType.Double),
                    comando.Parameters.Add("@tipo", System.Data.DbType.String),
                    comando.Parameters.Add("@secao", System.Data.DbType.String),
                    comando.Parameters.Add("@cor", System.Data.DbType.String),
                    comando.Parameters.Add("@posicaoNum", System.Data.DbType.Int32),
                    comando.Parameters.Add("@tipoBorne", System.Data.DbType.Int32),
                    comando.Parameters.Add("@bJumper", System.Data.DbType.Boolean),
                    comando.Parameters.Add("@bLink", System.Data.DbType.Boolean),
                    comando.Parameters.Add("@handle", System.Data.DbType.String),
                    comando.Parameters.Add("@indexModelo", System.Data.DbType.Int32),
                    comando.Parameters.Add("@aplicacao", System.Data.DbType.Int32),
                    comando.Parameters.Add("@criador", System.Data.DbType.String),
                    comando.Parameters.Add("@data", System.Data.DbType.DateTime),
                };

                foreach (PontoFiacao ponto in pontos)
                {
                    parametros[0].Value = Nulo(ponto.Revisao);
                    parametros[1].Value = ponto.Dwg;
                    parametros[2].Value = (int)ponto.Painel;
                    parametros[3].Value = ponto.Potencial;
                    parametros[4].Value = ponto.Ordem;
                    parametros[5].Value = DBNull.Value; // Pagina: depende da paginação (não projetada)
                    parametros[6].Value = Nulo(ponto.Tag);
                    parametros[7].Value = Nulo(ponto.Alternativo);
                    parametros[8].Value = Nulo(ponto.NRegua);
                    parametros[9].Value = Nulo(ponto.Terminal);
                    parametros[10].Value = ponto.TerminalNum;
                    parametros[11].Value = Nulo(ponto.Tipo);
                    parametros[12].Value = Nulo(ponto.Secao);
                    parametros[13].Value = Nulo(ponto.Cor);
                    parametros[14].Value = ponto.PosicaoNum;
                    parametros[15].Value = (int)ponto.TipoBorne;
                    parametros[16].Value = ponto.BJumper;
                    parametros[17].Value = ponto.BLink;
                    parametros[18].Value = Nulo(ponto.Handle);
                    parametros[19].Value = (int)ponto.IndexModelo;
                    parametros[20].Value = ponto.Aplicacao;
                    parametros[21].Value = Nulo(ponto.Criador);
                    parametros[22].Value = ponto.Data;
                    comando.ExecuteNonQuery();
                }

                transacao.Commit();
            }
        }

        /// <summary>Grava as linhas de interligação já mescladas (ver <see cref="InterligacaoProjetor"/>).</summary>
        public void InserirInterligacao(IEnumerable<TrechoInterligacao> trechos)
        {
            using (SQLiteConnection conexao = Abrir())
            using (SQLiteTransaction transacao = conexao.BeginTransaction())
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                // Colunas do INSERT canônico do original; Indice fica de fora (SQLite atribui o rowid).
                comando.CommandText =
                    "INSERT INTO Interligacao4(Revisao, DWG, Tag_Cabo, Num_Veia, Nome_Veia, Painel1, Pagina1, " +
                    "Painel2, Pagina2, Criador, Data) " +
                    "VALUES(@revisao, @dwg, @tagCabo, @numVeia, @nomeVeia, @painel1, @pagina1, @painel2, @pagina2, " +
                    "@criador, @data)";

                SQLiteParameter[] parametros =
                {
                    comando.Parameters.Add("@revisao", System.Data.DbType.String),
                    comando.Parameters.Add("@dwg", System.Data.DbType.Int32),
                    comando.Parameters.Add("@tagCabo", System.Data.DbType.String),
                    comando.Parameters.Add("@numVeia", System.Data.DbType.Int32),
                    comando.Parameters.Add("@nomeVeia", System.Data.DbType.String),
                    comando.Parameters.Add("@painel1", System.Data.DbType.Int32),
                    comando.Parameters.Add("@pagina1", System.Data.DbType.String),
                    comando.Parameters.Add("@painel2", System.Data.DbType.Int32),
                    comando.Parameters.Add("@pagina2", System.Data.DbType.String),
                    comando.Parameters.Add("@criador", System.Data.DbType.String),
                    comando.Parameters.Add("@data", System.Data.DbType.DateTime),
                };

                foreach (TrechoInterligacao trecho in trechos)
                {
                    parametros[0].Value = Nulo(trecho.Revisao);
                    parametros[1].Value = trecho.Dwg;
                    parametros[2].Value = Nulo(trecho.Tag_Cabo);
                    parametros[3].Value = trecho.NumVeia;
                    parametros[4].Value = Nulo(trecho.NomeVeia);
                    parametros[5].Value = trecho.Painel1 > 0 ? (object)(int)trecho.Painel1 : DBNull.Value;
                    parametros[6].Value = Nulo(trecho.Pagina1);
                    parametros[7].Value = trecho.Painel2 > 0 ? (object)(int)trecho.Painel2 : DBNull.Value;
                    parametros[8].Value = Nulo(trecho.Pagina2);
                    parametros[9].Value = Nulo(trecho.Criador);
                    parametros[10].Value = trecho.Data;
                    comando.ExecuteNonQuery();
                }

                transacao.Commit();
            }
        }

        /// <summary>
        /// Lê os trechos de um cabo já nas linhas do contrato gerado
        /// (<see cref="Interligacao4Row"/>). Mesma ordenação do sidecar
        /// (<c>interligacao_por_cabo</c>), para os dois frontends concordarem.
        /// </summary>
        public IReadOnlyList<Interligacao4Row> InterligacaoPorCabo(string tagCabo)
        {
            List<Interligacao4Row> linhas = new List<Interligacao4Row>();
            using (SQLiteConnection conexao = Abrir())
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText =
                    "SELECT Indice, Revisao, DWG, Tag_Cabo, Num_Veia, Nome_Veia, Painel1, Pagina1, Painel2, " +
                    "Pagina2, Criador FROM Interligacao4 WHERE Tag_Cabo = @tagCabo ORDER BY Num_Veia, Indice";
                comando.Parameters.AddWithValue("@tagCabo", tagCabo);

                using (SQLiteDataReader leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        linhas.Add(new Interligacao4Row
                        {
                            Indice = leitor.GetInt64(leitor.GetOrdinal("Indice")),
                            Revisao = Texto(leitor, "Revisao"),
                            DWG = Inteiro(leitor, "DWG"),
                            Tag_Cabo = Texto(leitor, "Tag_Cabo"),
                            Num_Veia = Inteiro(leitor, "Num_Veia"),
                            Nome_Veia = Texto(leitor, "Nome_Veia"),
                            Painel1 = Inteiro(leitor, "Painel1"),
                            Pagina1 = Texto(leitor, "Pagina1"),
                            Painel2 = Inteiro(leitor, "Painel2"),
                            Pagina2 = Texto(leitor, "Pagina2"),
                            Criador = Texto(leitor, "Criador"),
                        });
                    }
                }
            }

            return linhas;
        }

        /// <summary>Grava as portas de fiação (<c>Portas4F</c>) — ver <see cref="Portas4FGerador"/>.</summary>
        public void InserirPortas(IEnumerable<Porta4F> portas, string revisao, int dwg)
        {
            using (SQLiteConnection conexao = Abrir())
            using (SQLiteTransaction transacao = conexao.BeginTransaction())
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText =
                    "INSERT INTO Portas4F(Revisao, DWG, IndexModelo, NomeModelo, Regua, Borne, Terminal, " +
                    "TerminalNum, Tipo, Orientacao) " +
                    "VALUES(@revisao, @dwg, @indexModelo, @nomeModelo, @regua, @borne, @terminal, @terminalNum, " +
                    "@tipo, @orientacao)";

                SQLiteParameter[] parametros =
                {
                    comando.Parameters.Add("@revisao", System.Data.DbType.String),
                    comando.Parameters.Add("@dwg", System.Data.DbType.Int32),
                    comando.Parameters.Add("@indexModelo", System.Data.DbType.Int32),
                    comando.Parameters.Add("@nomeModelo", System.Data.DbType.String),
                    comando.Parameters.Add("@regua", System.Data.DbType.String),
                    comando.Parameters.Add("@borne", System.Data.DbType.String),
                    comando.Parameters.Add("@terminal", System.Data.DbType.String),
                    comando.Parameters.Add("@terminalNum", System.Data.DbType.Double),
                    comando.Parameters.Add("@tipo", System.Data.DbType.String),
                    comando.Parameters.Add("@orientacao", System.Data.DbType.String),
                };

                foreach (Porta4F porta in portas)
                {
                    parametros[0].Value = Nulo(revisao);
                    parametros[1].Value = dwg;
                    parametros[2].Value = porta.IndexModelo;
                    parametros[3].Value = Nulo(porta.NomeModelo);
                    parametros[4].Value = Nulo(porta.Regua);
                    parametros[5].Value = Nulo(porta.Borne);
                    parametros[6].Value = Nulo(porta.Terminal);
                    parametros[7].Value = porta.TerminalNum;
                    parametros[8].Value = Nulo(porta.Tipo);
                    parametros[9].Value = Nulo(porta.Orientacao);
                    comando.ExecuteNonQuery();
                }

                transacao.Commit();
            }
        }

        /// <summary>Grava os bornes (<c>Bornes4F</c>) — ver <see cref="Bornes4FGerador"/>.</summary>
        public void InserirBornes(IEnumerable<Borne4F> bornes, string revisao, int dwg)
        {
            using (SQLiteConnection conexao = Abrir())
            using (SQLiteTransaction transacao = conexao.BeginTransaction())
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText =
                    "INSERT INTO Bornes4F(Revisao, DWG, Painel, IndexRegua, Regua, Alternativo, Handle, Borne, " +
                    "Ordem, Tipo, Pagina, bReserva, LM, Orientacao, BlocoLayout) " +
                    "VALUES(@revisao, @dwg, @painel, @indexRegua, @regua, @alternativo, @handle, @borne, @ordem, " +
                    "@tipo, @pagina, @bReserva, @lm, @orientacao, @blocoLayout)";

                SQLiteParameter[] parametros =
                {
                    comando.Parameters.Add("@revisao", System.Data.DbType.String),
                    comando.Parameters.Add("@dwg", System.Data.DbType.Int32),
                    comando.Parameters.Add("@painel", System.Data.DbType.Int32),
                    comando.Parameters.Add("@indexRegua", System.Data.DbType.Int32),
                    comando.Parameters.Add("@regua", System.Data.DbType.String),
                    comando.Parameters.Add("@alternativo", System.Data.DbType.String),
                    comando.Parameters.Add("@handle", System.Data.DbType.String),
                    comando.Parameters.Add("@borne", System.Data.DbType.String),
                    comando.Parameters.Add("@ordem", System.Data.DbType.Double),
                    comando.Parameters.Add("@tipo", System.Data.DbType.Int32),
                    comando.Parameters.Add("@pagina", System.Data.DbType.String),
                    comando.Parameters.Add("@bReserva", System.Data.DbType.Boolean),
                    comando.Parameters.Add("@lm", System.Data.DbType.Int32),
                    comando.Parameters.Add("@orientacao", System.Data.DbType.String),
                    comando.Parameters.Add("@blocoLayout", System.Data.DbType.String),
                };

                foreach (Borne4F borne in bornes)
                {
                    parametros[0].Value = Nulo(revisao);
                    parametros[1].Value = dwg;
                    parametros[2].Value = (int)borne.Painel;
                    parametros[3].Value = borne.IndexRegua;
                    parametros[4].Value = Nulo(borne.Regua);
                    parametros[5].Value = Nulo(borne.Alternativo);
                    parametros[6].Value = Nulo(borne.Handle);
                    parametros[7].Value = Nulo(borne.Borne);
                    parametros[8].Value = borne.Ordem;
                    parametros[9].Value = borne.Tipo;
                    parametros[10].Value = Nulo(borne.Pagina);
                    parametros[11].Value = borne.BReserva;
                    parametros[12].Value = borne.Lm;
                    parametros[13].Value = Nulo(borne.Orientacao);
                    parametros[14].Value = Nulo(borne.BlocoLayout);
                    comando.ExecuteNonQuery();
                }

                transacao.Commit();
            }
        }

        /// <summary>Grava os contatos (<c>Contatos4F</c>) — ver <see cref="Contatos4FGerador"/>.</summary>
        public void InserirContatos(IEnumerable<Contato4F> contatos, string revisao, int dwg)
        {
            using (SQLiteConnection conexao = Abrir())
            using (SQLiteTransaction transacao = conexao.BeginTransaction())
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText =
                    "INSERT INTO Contatos4F(Revisao, DWG, IndexModelo, NomeModelo, Terminal, TerminalNum, Orientacao) " +
                    "VALUES(@revisao, @dwg, @indexModelo, @nomeModelo, @terminal, @terminalNum, @orientacao)";

                SQLiteParameter[] parametros =
                {
                    comando.Parameters.Add("@revisao", System.Data.DbType.String),
                    comando.Parameters.Add("@dwg", System.Data.DbType.Int32),
                    comando.Parameters.Add("@indexModelo", System.Data.DbType.Int32),
                    comando.Parameters.Add("@nomeModelo", System.Data.DbType.String),
                    comando.Parameters.Add("@terminal", System.Data.DbType.String),
                    comando.Parameters.Add("@terminalNum", System.Data.DbType.Double),
                    comando.Parameters.Add("@orientacao", System.Data.DbType.String),
                };

                foreach (Contato4F contato in contatos)
                {
                    parametros[0].Value = Nulo(revisao);
                    parametros[1].Value = dwg;
                    parametros[2].Value = contato.IndexModelo;
                    parametros[3].Value = Nulo(contato.NomeModelo);
                    parametros[4].Value = Nulo(contato.Terminal);
                    parametros[5].Value = contato.TerminalNum;
                    parametros[6].Value = Nulo(contato.Orientacao);
                    comando.ExecuteNonQuery();
                }

                transacao.Commit();
            }
        }

        /// <summary>Conta os contatos de um modelo em <c>Contatos4F</c>.</summary>
        public int ContarContatosDoModelo(long indexModelo)
        {
            using (SQLiteConnection conexao = Abrir())
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText = "SELECT COUNT(*) FROM Contatos4F WHERE IndexModelo = @indexModelo";
                comando.Parameters.AddWithValue("@indexModelo", indexModelo);
                return Convert.ToInt32(comando.ExecuteScalar());
            }
        }

        /// <summary>Conta as portas de um modelo em <c>Portas4F</c>.</summary>
        public int ContarPortasDoModelo(long indexModelo)
        {
            using (SQLiteConnection conexao = Abrir())
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText = "SELECT COUNT(*) FROM Portas4F WHERE IndexModelo = @indexModelo";
                comando.Parameters.AddWithValue("@indexModelo", indexModelo);
                return Convert.ToInt32(comando.ExecuteScalar());
            }
        }

        /// <summary>Conta os bornes de uma régua em <c>Bornes4F</c>.</summary>
        public int ContarBornesDaRegua(long indexRegua)
        {
            using (SQLiteConnection conexao = Abrir())
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText = "SELECT COUNT(*) FROM Bornes4F WHERE IndexRegua = @indexRegua";
                comando.Parameters.AddWithValue("@indexRegua", indexRegua);
                return Convert.ToInt32(comando.ExecuteScalar());
            }
        }

        private static object Nulo(string valor)
        {
            return string.IsNullOrEmpty(valor) ? (object)DBNull.Value : valor;
        }

        private static FiacaoRow LerFiacao(SQLiteDataReader leitor)
        {
            return new FiacaoRow
            {
                Indice = leitor.GetInt64(leitor.GetOrdinal("Indice")),
                Revisao = Texto(leitor, "Revisao"),
                DWG = Inteiro(leitor, "DWG"),
                Painel = Inteiro(leitor, "Painel"),
                Potencial = Inteiro(leitor, "Potencial"),
                Ordem = Inteiro(leitor, "Ordem"),
                Pagina = Texto(leitor, "Pagina"),
                Tag = Texto(leitor, "Tag"),
                Terminal = Texto(leitor, "Terminal"),
                Secao = Texto(leitor, "Secao"),
                Cor = Texto(leitor, "Cor"),
                Criador = Texto(leitor, "Criador"),
            };
        }

        private static string Texto(SQLiteDataReader leitor, string coluna)
        {
            int indice = leitor.GetOrdinal(coluna);
            return leitor.IsDBNull(indice) ? null : leitor.GetString(indice);
        }

        private static long? Inteiro(SQLiteDataReader leitor, string coluna)
        {
            int indice = leitor.GetOrdinal(coluna);
            return leitor.IsDBNull(indice) ? (long?)null : leitor.GetInt64(indice);
        }
    }
}

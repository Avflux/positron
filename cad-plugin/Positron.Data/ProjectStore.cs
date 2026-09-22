using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Positron.Contract;
using Positron.Data.Fiacao;
using Positron.Data.Interligacao;
using Positron.Data.Materiais;
using Positron.Data.Modelos;
using Positron.Data.Plaquetas;

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
                    "SELECT Indice, Revisao, DWG, Painel, Potencial, Ordem, Pagina, Tag, Alternativo, NRegua, " +
                    "Terminal, TerminalNum, Tipo, Secao, Cor, PosicaoNum, TipoBorne, BLink, Handle, IndexModelo, " +
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
        /// Lê a fiação de uma revisão (todos os painéis de um DWG), já nas linhas
        /// do contrato gerado. É a leitura do <c>VERIF</c>: a validação olha o que
        /// foi projetado, não um painel só.
        /// </summary>
        public IReadOnlyList<FiacaoRow> FiacaoDaRevisao(int dwg, string revisao)
        {
            List<FiacaoRow> linhas = new List<FiacaoRow>();
            using (SQLiteConnection conexao = Abrir())
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText =
                    "SELECT Indice, Revisao, DWG, Painel, Potencial, Ordem, Pagina, Tag, Alternativo, NRegua, " +
                    "Terminal, TerminalNum, Tipo, Secao, Cor, PosicaoNum, TipoBorne, BLink, Handle, IndexModelo, " +
                    "Criador FROM Fiacao " +
                    "WHERE DWG = @dwg AND IFNULL(Revisao, '') = IFNULL(@revisao, '') " +
                    "ORDER BY Painel, Potencial, Ordem";
                comando.Parameters.AddWithValue("@dwg", dwg);
                comando.Parameters.AddWithValue("@revisao", (object)revisao ?? DBNull.Value);

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
            List<PontoFiacao> lista = pontos == null
                ? new List<PontoFiacao>()
                : new List<PontoFiacao>(pontos);

            using (SQLiteConnection conexao = Abrir())
            using (SQLiteTransaction transacao = conexao.BeginTransaction())
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                // A projeção SUBSTITUI a revisão, como o RemoveRevisaoTabelaParaDWG
                // do original: rodar o FIA duas vezes não duplica linha nem
                // embaralha a Ordem. Lote vazio não tem (DWG, Revisão) para apagar
                // — e o comando já sai antes disso quando não há conexão.
                RemoverRevisoesDoLote(conexao, "Fiacao", lista, ponto => ponto.Dwg, ponto => ponto.Revisao);

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

                foreach (PontoFiacao ponto in lista)
                {
                    parametros[0].Value = Nulo(ponto.Revisao);
                    parametros[1].Value = ponto.Dwg;
                    parametros[2].Value = (int)ponto.Painel;
                    parametros[3].Value = ponto.Potencial;
                    parametros[4].Value = ponto.Ordem;
                    // Pagina: a coluna configurada (`Conf.incluirColuna`) já veio
                    // montada no ponto; sem ela, o layer cru — o caso 0..2 do original.
                    parametros[5].Value = Nulo(ponto.Pagina ?? ponto.Layer);
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

        /// <summary>
        /// Grava os pontos de **jumper** (<c>Jumper4</c>) — o <c>JMP</c> do
        /// original. Mesmas colunas do <c>Fiacao</c>, sem <c>Aplicacao</c>/
        /// <c>Orientacao</c>; a revisão é substituída, como nas demais tabelas.
        /// </summary>
        public void InserirJumper(IEnumerable<PontoFiacao> pontos)
        {
            List<PontoFiacao> lista = pontos == null
                ? new List<PontoFiacao>()
                : new List<PontoFiacao>(pontos);

            using (SQLiteConnection conexao = Abrir())
            using (SQLiteTransaction transacao = conexao.BeginTransaction())
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                // Substitui a revisão (RemoveRevisaoTabelaParaDWG do original).
                RemoverRevisoesDoLote(conexao, "Jumper4", lista, ponto => ponto.Dwg, ponto => ponto.Revisao);

                comando.CommandText =
                    "INSERT INTO Jumper4(Revisao, DWG, Painel, Potencial, Ordem, Pagina, Tag, Alternativo, NRegua, " +
                    "Terminal, TerminalNum, Tipo, Secao, Cor, PosicaoNum, TipoBorne, BJumper, BLink, Handle, " +
                    "IndexModelo, Criador, Data) " +
                    "VALUES(@revisao, @dwg, @painel, @potencial, @ordem, @pagina, @tag, @alternativo, @nregua, " +
                    "@terminal, @terminalNum, @tipo, @secao, @cor, @posicaoNum, @tipoBorne, @bJumper, @bLink, " +
                    "@handle, @indexModelo, @criador, @data)";

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
                    comando.Parameters.Add("@criador", System.Data.DbType.String),
                    comando.Parameters.Add("@data", System.Data.DbType.DateTime),
                };

                foreach (PontoFiacao ponto in lista)
                {
                    parametros[0].Value = Nulo(ponto.Revisao);
                    parametros[1].Value = ponto.Dwg;
                    parametros[2].Value = (int)ponto.Painel;
                    parametros[3].Value = ponto.Potencial;
                    parametros[4].Value = ponto.Ordem;
                    parametros[5].Value = Nulo(ponto.Pagina ?? ponto.Layer);
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
                    parametros[20].Value = Nulo(ponto.Criador);
                    parametros[21].Value = ponto.Data;
                    comando.ExecuteNonQuery();
                }

                transacao.Commit();
            }
        }

        /// <summary>Lê os jumpers de uma revisão (<c>Jumper4</c>).</summary>
        public IReadOnlyList<Jumper4Row> JumperDaRevisao(int dwg, string revisao)
        {
            List<Jumper4Row> linhas = new List<Jumper4Row>();
            using (SQLiteConnection conexao = Abrir())
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText =
                    "SELECT Indice, Revisao, DWG, Painel, Potencial, Ordem, Pagina, Tag, Alternativo, NRegua, " +
                    "Terminal, TerminalNum, Tipo, Secao, Cor, PosicaoNum, TipoBorne, BJumper, BLink, Handle, " +
                    "IndexModelo, Criador, Data FROM Jumper4 " +
                    "WHERE DWG = @dwg AND IFNULL(Revisao, '') = IFNULL(@revisao, '') ORDER BY Potencial, Ordem, Indice";
                comando.Parameters.AddWithValue("@dwg", dwg);
                comando.Parameters.AddWithValue("@revisao", (object)revisao ?? DBNull.Value);

                using (SQLiteDataReader leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        linhas.Add(new Jumper4Row
                        {
                            Indice = leitor.GetInt64(leitor.GetOrdinal("Indice")),
                            Revisao = Texto(leitor, "Revisao"),
                            DWG = Inteiro(leitor, "DWG"),
                            Painel = Inteiro(leitor, "Painel"),
                            Potencial = Inteiro(leitor, "Potencial"),
                            Ordem = Inteiro(leitor, "Ordem"),
                            Pagina = Texto(leitor, "Pagina"),
                            Tag = Texto(leitor, "Tag"),
                            Alternativo = Texto(leitor, "Alternativo"),
                            NRegua = Texto(leitor, "NRegua"),
                            Terminal = Texto(leitor, "Terminal"),
                            TerminalNum = Real(leitor, "TerminalNum"),
                            Tipo = Texto(leitor, "Tipo"),
                            Secao = Texto(leitor, "Secao"),
                            Cor = Texto(leitor, "Cor"),
                            PosicaoNum = Inteiro(leitor, "PosicaoNum"),
                            TipoBorne = Inteiro(leitor, "TipoBorne"),
                            BJumper = Logico(leitor, "BJumper"),
                            BLink = Logico(leitor, "BLink"),
                            Handle = Texto(leitor, "Handle"),
                            IndexModelo = Inteiro(leitor, "IndexModelo"),
                            Criador = Texto(leitor, "Criador"),
                            Data = leitor.IsDBNull(leitor.GetOrdinal("Data"))
                                ? (System.DateTime?)null
                                : leitor.GetDateTime(leitor.GetOrdinal("Data")),
                        });
                    }
                }
            }

            return linhas;
        }

        /// <summary>
        /// Renumera <c>Ordem</c> de 1..N dentro de cada <c>Potencial</c> da revisão
        /// — o <c>ReordenaOrdemPotenciais</c> do original
        /// (<c>cDadosAccessFiacao</c>). Só toca as linhas cujo <c>Ordem</c> já divergiu
        /// da sequência; devolve quantas foram corrigidas. É no-op quando a inserção
        /// já veio ordenada (<see cref="FiacaoProjetor.Numerar"/>).
        /// </summary>
        public int ReordenarOrdemFiacao(int dwg, string revisao)
        {
            int corrigidas = 0;

            using (SQLiteConnection conexao = Abrir())
            using (SQLiteTransaction transacao = conexao.BeginTransaction())
            {
                List<int> potenciais = new List<int>();
                using (SQLiteCommand comando = conexao.CreateCommand())
                {
                    comando.CommandText =
                        "SELECT DISTINCT Potencial FROM Fiacao " +
                        "WHERE DWG = @dwg AND IFNULL(Revisao, '') = IFNULL(@revisao, '')";
                    comando.Parameters.AddWithValue("@dwg", dwg);
                    comando.Parameters.AddWithValue("@revisao", (object)revisao ?? DBNull.Value);
                    using (SQLiteDataReader leitor = comando.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            if (!leitor.IsDBNull(0))
                            {
                                potenciais.Add(leitor.GetInt32(0));
                            }
                        }
                    }
                }

                using (SQLiteCommand buscar = conexao.CreateCommand())
                using (SQLiteCommand atualizar = conexao.CreateCommand())
                {
                    buscar.CommandText =
                        "SELECT Indice, Ordem FROM Fiacao " +
                        "WHERE DWG = @dwg AND IFNULL(Revisao, '') = IFNULL(@revisao, '') AND Potencial = @potencial " +
                        "ORDER BY Ordem, Indice";
                    buscar.Parameters.Add("@dwg", System.Data.DbType.Int32);
                    buscar.Parameters.Add("@revisao", System.Data.DbType.String);
                    buscar.Parameters.Add("@potencial", System.Data.DbType.Int32);

                    atualizar.CommandText = "UPDATE Fiacao SET Ordem = @ordem WHERE Indice = @indice";
                    SQLiteParameter ordem = atualizar.Parameters.Add("@ordem", System.Data.DbType.Int32);
                    SQLiteParameter indice = atualizar.Parameters.Add("@indice", System.Data.DbType.Int64);

                    foreach (int potencial in potenciais)
                    {
                        buscar.Parameters["@dwg"].Value = dwg;
                        buscar.Parameters["@revisao"].Value = (object)revisao ?? DBNull.Value;
                        buscar.Parameters["@potencial"].Value = potencial;

                        List<long> ids = new List<long>();
                        List<int> ordens = new List<int>();
                        using (SQLiteDataReader leitor = buscar.ExecuteReader())
                        {
                            while (leitor.Read())
                            {
                                ids.Add(leitor.GetInt64(0));
                                ordens.Add(leitor.IsDBNull(1) ? 0 : leitor.GetInt32(1));
                            }
                        }

                        for (int i = 0; i < ids.Count; i++)
                        {
                            int nova = i + 1;
                            if (ordens[i] != nova)
                            {
                                ordem.Value = nova;
                                indice.Value = ids[i];
                                atualizar.ExecuteNonQuery();
                                corrigidas++;
                            }
                        }
                    }
                }

                transacao.Commit();
            }

            return corrigidas;
        }

        /// <summary>Grava as linhas de interligação já mescladas (ver <see cref="InterligacaoProjetor"/>).</summary>
        public void InserirInterligacao(IEnumerable<TrechoInterligacao> trechos)
        {
            List<TrechoInterligacao> lista = trechos == null
                ? new List<TrechoInterligacao>()
                : new List<TrechoInterligacao>(trechos);

            using (SQLiteConnection conexao = Abrir())
            using (SQLiteTransaction transacao = conexao.BeginTransaction())
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                // Mesma regra da fiação: a revisão é substituída, não acumulada
                // (RemoveRevisaoTabelaParaDWG do original).
                RemoverRevisoesDoLote(conexao, "Interligacao4", lista, trecho => trecho.Dwg, trecho => trecho.Revisao);

                // Colunas do INSERT canônico do original (cDadosAccessInterligacao2.
                // AdicionaItemInterligacao); Indice fica de fora — o SQLite atribui
                // o rowid. As colunas que a varredura de bornes preenche vêm do
                // TrechoInterligacao; as demais saem nulas de propósito.
                comando.CommandText =
                    "INSERT INTO Interligacao4(Revisao, DWG, Tag_Cabo, Num_Veia, Nome_Veia, DWG1, Documento1, " +
                    "Painel1, Tag1, Alternativo1, NRegua1, Terminal1, TerminalNum1, TipoBorne1, Handle1, " +
                    "Pagina1, Posicao1, IndexModelo1, DWG2, Documento2, Painel2, Tag2, Alternativo2, NRegua2, " +
                    "Terminal2, TerminalNum2, TipoBorne2, Handle2, Pagina2, Posicao2, IndexModelo2, " +
                    "Criador, Data) " +
                    "VALUES(@revisao, @dwg, @tagCabo, @numVeia, @nomeVeia, @dwg1, @documento1, @painel1, @tag1, " +
                    "@alternativo1, @nregua1, @terminal1, @terminalNum1, @tipoBorne1, @handle1, @pagina1, " +
                    "@posicao1, @indexModelo1, @dwg2, @documento2, @painel2, @tag2, @alternativo2, @nregua2, " +
                    "@terminal2, @terminalNum2, @tipoBorne2, @handle2, @pagina2, @posicao2, @indexModelo2, " +
                    "@criador, @data)";

                SQLiteParameter[] parametros =
                {
                    comando.Parameters.Add("@revisao", System.Data.DbType.String),
                    comando.Parameters.Add("@dwg", System.Data.DbType.Int32),
                    comando.Parameters.Add("@tagCabo", System.Data.DbType.String),
                    comando.Parameters.Add("@numVeia", System.Data.DbType.Int32),
                    comando.Parameters.Add("@nomeVeia", System.Data.DbType.String),
                    comando.Parameters.Add("@dwg1", System.Data.DbType.Int32),
                    comando.Parameters.Add("@documento1", System.Data.DbType.String),
                    comando.Parameters.Add("@painel1", System.Data.DbType.Int32),
                    comando.Parameters.Add("@tag1", System.Data.DbType.String),
                    comando.Parameters.Add("@alternativo1", System.Data.DbType.String),
                    comando.Parameters.Add("@nregua1", System.Data.DbType.String),
                    comando.Parameters.Add("@terminal1", System.Data.DbType.String),
                    comando.Parameters.Add("@terminalNum1", System.Data.DbType.Double),
                    comando.Parameters.Add("@tipoBorne1", System.Data.DbType.Int32),
                    comando.Parameters.Add("@handle1", System.Data.DbType.String),
                    comando.Parameters.Add("@pagina1", System.Data.DbType.String),
                    comando.Parameters.Add("@posicao1", System.Data.DbType.String),
                    comando.Parameters.Add("@indexModelo1", System.Data.DbType.Int32),
                    comando.Parameters.Add("@dwg2", System.Data.DbType.Int32),
                    comando.Parameters.Add("@documento2", System.Data.DbType.String),
                    comando.Parameters.Add("@painel2", System.Data.DbType.Int32),
                    comando.Parameters.Add("@tag2", System.Data.DbType.String),
                    comando.Parameters.Add("@alternativo2", System.Data.DbType.String),
                    comando.Parameters.Add("@nregua2", System.Data.DbType.String),
                    comando.Parameters.Add("@terminal2", System.Data.DbType.String),
                    comando.Parameters.Add("@terminalNum2", System.Data.DbType.Double),
                    comando.Parameters.Add("@tipoBorne2", System.Data.DbType.Int32),
                    comando.Parameters.Add("@handle2", System.Data.DbType.String),
                    comando.Parameters.Add("@pagina2", System.Data.DbType.String),
                    comando.Parameters.Add("@posicao2", System.Data.DbType.String),
                    comando.Parameters.Add("@indexModelo2", System.Data.DbType.Int32),
                    comando.Parameters.Add("@criador", System.Data.DbType.String),
                    comando.Parameters.Add("@data", System.Data.DbType.DateTime),
                };

                foreach (TrechoInterligacao trecho in lista)
                {
                    parametros[0].Value = Nulo(trecho.Revisao);
                    parametros[1].Value = trecho.Dwg;
                    parametros[2].Value = Nulo(trecho.Tag_Cabo);
                    parametros[3].Value = trecho.NumVeia;
                    parametros[4].Value = Nulo(trecho.NomeVeia);
                    parametros[5].Value = Falta(trecho.Dwg1); // DWG1: carimbado no casamento com o borne
                    parametros[6].Value = Nulo(trecho.Documento1);
                    parametros[7].Value = trecho.Painel1 > 0 ? (object)(int)trecho.Painel1 : DBNull.Value;
                    parametros[8].Value = Nulo(trecho.Tag1);
                    parametros[9].Value = Nulo(trecho.Alternativo1);
                    parametros[10].Value = Nulo(trecho.NRegua1);
                    parametros[11].Value = Nulo(trecho.Terminal1);
                    parametros[12].Value = Falta(trecho.TerminalNum1);
                    parametros[13].Value = Falta(trecho.TipoBorne1);
                    parametros[14].Value = Nulo(trecho.Handle1);
                    parametros[15].Value = Nulo(trecho.Pagina1);
                    parametros[16].Value = trecho.Posicao1 ?? string.Empty; // Posicao1: o original grava ""
                    parametros[17].Value = Falta(trecho.IndexModelo1);
                    parametros[18].Value = Falta(trecho.Dwg2); // DWG2
                    parametros[19].Value = Nulo(trecho.Documento2); // Documento2
                    parametros[20].Value = trecho.Painel2 > 0 ? (object)(int)trecho.Painel2 : DBNull.Value;
                    parametros[21].Value = Nulo(trecho.Tag2);
                    parametros[22].Value = Nulo(trecho.Alternativo2);
                    parametros[23].Value = Nulo(trecho.NRegua2);
                    parametros[24].Value = Nulo(trecho.Terminal2);
                    parametros[25].Value = Falta(trecho.TerminalNum2);
                    parametros[26].Value = Falta(trecho.TipoBorne2);
                    parametros[27].Value = Nulo(trecho.Handle2);
                    parametros[28].Value = Nulo(trecho.Pagina2);
                    parametros[29].Value = trecho.Posicao2 ?? string.Empty; // Posicao2
                    parametros[30].Value = Falta(trecho.IndexModelo2);
                    parametros[31].Value = Nulo(trecho.Criador);
                    parametros[32].Value = trecho.Data;
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
                    "SELECT Indice, Revisao, DWG, Tag_Cabo, Num_Veia, Nome_Veia, DWG1, Documento1, Painel1, " +
                    "Pagina1, Posicao1, Tag1, Alternativo1, NRegua1, Terminal1, TerminalNum1, TipoBorne1, " +
                    "Handle1, IndexModelo1, DWG2, Documento2, Painel2, Pagina2, Posicao2, Tag2, Alternativo2, " +
                    "NRegua2, Terminal2, TerminalNum2, TipoBorne2, Handle2, IndexModelo2, " +
                    "Criador FROM Interligacao4 WHERE Tag_Cabo = @tagCabo ORDER BY Num_Veia, Indice";
                comando.Parameters.AddWithValue("@tagCabo", tagCabo);

                using (SQLiteDataReader leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        linhas.Add(LerInterligacao(leitor));
                    }
                }
            }

            return linhas;
        }

        /// <summary>
        /// Lê a interligação de uma revisão (todos os cabos de um DWG) — a leitura
        /// do <c>VERIF</c> para os trechos.
        /// </summary>
        public IReadOnlyList<Interligacao4Row> InterligacaoDaRevisao(int dwg, string revisao)
        {
            List<Interligacao4Row> linhas = new List<Interligacao4Row>();
            using (SQLiteConnection conexao = Abrir())
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText =
                    "SELECT Indice, Revisao, DWG, Tag_Cabo, Num_Veia, Nome_Veia, DWG1, Documento1, Painel1, " +
                    "Pagina1, Posicao1, Tag1, Alternativo1, NRegua1, Terminal1, TerminalNum1, TipoBorne1, " +
                    "Handle1, IndexModelo1, DWG2, Documento2, Painel2, Pagina2, Posicao2, Tag2, Alternativo2, " +
                    "NRegua2, Terminal2, TerminalNum2, TipoBorne2, Handle2, IndexModelo2, " +
                    "Criador FROM Interligacao4 " +
                    "WHERE DWG = @dwg AND IFNULL(Revisao, '') = IFNULL(@revisao, '') ORDER BY Tag_Cabo, Num_Veia, Indice";
                comando.Parameters.AddWithValue("@dwg", dwg);
                comando.Parameters.AddWithValue("@revisao", (object)revisao ?? DBNull.Value);

                using (SQLiteDataReader leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        linhas.Add(LerInterligacao(leitor));
                    }
                }
            }

            return linhas;
        }

        /// <summary>Lê as portas de uma revisão (<c>Portas4F</c>).</summary>
        public IReadOnlyList<Portas4FRow> PortasDaRevisao(int dwg, string revisao)
        {
            List<Portas4FRow> linhas = new List<Portas4FRow>();
            using (SQLiteConnection conexao = Abrir())
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText =
                    "SELECT Indice, Revisao, DWG, IndexModelo, NomeModelo, Regua, Borne, Terminal, TerminalNum, " +
                    "Tipo, Orientacao FROM Portas4F " +
                    "WHERE DWG = @dwg AND IFNULL(Revisao, '') = IFNULL(@revisao, '') ORDER BY IndexModelo, Indice";
                comando.Parameters.AddWithValue("@dwg", dwg);
                comando.Parameters.AddWithValue("@revisao", (object)revisao ?? DBNull.Value);

                using (SQLiteDataReader leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        linhas.Add(new Portas4FRow
                        {
                            Indice = leitor.GetInt64(leitor.GetOrdinal("Indice")),
                            Revisao = Texto(leitor, "Revisao"),
                            DWG = Inteiro(leitor, "DWG"),
                            IndexModelo = Inteiro(leitor, "IndexModelo"),
                            NomeModelo = Texto(leitor, "NomeModelo"),
                            Regua = Texto(leitor, "Regua"),
                            Borne = Texto(leitor, "Borne"),
                            Terminal = Texto(leitor, "Terminal"),
                            TerminalNum = Real(leitor, "TerminalNum"),
                            Tipo = Texto(leitor, "Tipo"),
                            Orientacao = Texto(leitor, "Orientacao"),
                        });
                    }
                }
            }

            return linhas;
        }

        /// <summary>Lê os bornes de uma revisão (<c>Bornes4F</c>).</summary>
        public IReadOnlyList<Bornes4FRow> BornesDaRevisao(int dwg, string revisao)
        {
            List<Bornes4FRow> linhas = new List<Bornes4FRow>();
            using (SQLiteConnection conexao = Abrir())
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText =
                    "SELECT Indice, Revisao, DWG, Painel, IndexRegua, Regua, Alternativo, Handle, Borne, Ordem, " +
                    "Tipo, Pagina, bReserva, LM, Orientacao, BlocoLayout FROM Bornes4F " +
                    "WHERE DWG = @dwg AND IFNULL(Revisao, '') = IFNULL(@revisao, '') ORDER BY Painel, IndexRegua, Ordem";
                comando.Parameters.AddWithValue("@dwg", dwg);
                comando.Parameters.AddWithValue("@revisao", (object)revisao ?? DBNull.Value);

                using (SQLiteDataReader leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        linhas.Add(new Bornes4FRow
                        {
                            Indice = leitor.GetInt64(leitor.GetOrdinal("Indice")),
                            Revisao = Texto(leitor, "Revisao"),
                            DWG = Inteiro(leitor, "DWG"),
                            Painel = Inteiro(leitor, "Painel"),
                            IndexRegua = Inteiro(leitor, "IndexRegua"),
                            Regua = Texto(leitor, "Regua"),
                            Alternativo = Texto(leitor, "Alternativo"),
                            Handle = Texto(leitor, "Handle"),
                            Borne = Texto(leitor, "Borne"),
                            Ordem = Real(leitor, "Ordem"),
                            Tipo = Inteiro(leitor, "Tipo"),
                            Pagina = Texto(leitor, "Pagina"),
                            bReserva = Logico(leitor, "bReserva"),
                            LM = Inteiro(leitor, "LM"),
                            Orientacao = Texto(leitor, "Orientacao"),
                            BlocoLayout = Texto(leitor, "BlocoLayout"),
                        });
                    }
                }
            }

            return linhas;
        }

        /// <summary>Lê os contatos de uma revisão (<c>Contatos4F</c>).</summary>
        public IReadOnlyList<Contatos4FRow> ContatosDaRevisao(int dwg, string revisao)
        {
            List<Contatos4FRow> linhas = new List<Contatos4FRow>();
            using (SQLiteConnection conexao = Abrir())
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText =
                    "SELECT Indice, Revisao, DWG, IndexModelo, NomeModelo, Terminal, TerminalNum, Orientacao " +
                    "FROM Contatos4F " +
                    "WHERE DWG = @dwg AND IFNULL(Revisao, '') = IFNULL(@revisao, '') ORDER BY IndexModelo, Indice";
                comando.Parameters.AddWithValue("@dwg", dwg);
                comando.Parameters.AddWithValue("@revisao", (object)revisao ?? DBNull.Value);

                using (SQLiteDataReader leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        linhas.Add(new Contatos4FRow
                        {
                            Indice = leitor.GetInt64(leitor.GetOrdinal("Indice")),
                            Revisao = Texto(leitor, "Revisao"),
                            DWG = Inteiro(leitor, "DWG"),
                            IndexModelo = Inteiro(leitor, "IndexModelo"),
                            NomeModelo = Texto(leitor, "NomeModelo"),
                            Terminal = Texto(leitor, "Terminal"),
                            TerminalNum = Real(leitor, "TerminalNum"),
                            Orientacao = Texto(leitor, "Orientacao"),
                        });
                    }
                }
            }

            return linhas;
        }

        /// <summary>Lê as portas de uma revisão (<c>Portas4I</c>).</summary>
        public IReadOnlyList<Portas4IRow> Portas4IDaRevisao(int dwg, string revisao)
        {
            List<Portas4IRow> linhas = new List<Portas4IRow>();
            using (SQLiteConnection conexao = Abrir())
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText =
                    "SELECT Indice, Revisao, DWG, IndexModelo, NomeModelo, Regua, Borne, Terminal, TerminalNum, Tipo " +
                    "FROM Portas4I " +
                    "WHERE DWG = @dwg AND IFNULL(Revisao, '') = IFNULL(@revisao, '') ORDER BY IndexModelo, Indice";
                comando.Parameters.AddWithValue("@dwg", dwg);
                comando.Parameters.AddWithValue("@revisao", (object)revisao ?? DBNull.Value);

                using (SQLiteDataReader leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        linhas.Add(new Portas4IRow
                        {
                            Indice = leitor.GetInt64(leitor.GetOrdinal("Indice")),
                            Revisao = Texto(leitor, "Revisao"),
                            DWG = Inteiro(leitor, "DWG"),
                            IndexModelo = Inteiro(leitor, "IndexModelo"),
                            NomeModelo = Texto(leitor, "NomeModelo"),
                            Regua = Texto(leitor, "Regua"),
                            Borne = Texto(leitor, "Borne"),
                            Terminal = Texto(leitor, "Terminal"),
                            TerminalNum = Real(leitor, "TerminalNum"),
                            Tipo = Texto(leitor, "Tipo"),
                        });
                    }
                }
            }

            return linhas;
        }

        /// <summary>Lê os bornes de uma revisão (<c>Bornes4I</c>).</summary>
        public IReadOnlyList<Bornes4IRow> Bornes4IDaRevisao(int dwg, string revisao)
        {
            List<Bornes4IRow> linhas = new List<Bornes4IRow>();
            using (SQLiteConnection conexao = Abrir())
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText =
                    "SELECT Indice, Revisao, DWG, Painel, IndexRegua, Regua, Alternativo, Handle, Borne, " +
                    "Ordem, Tipo, Pagina, bReserva FROM Bornes4I " +
                    "WHERE DWG = @dwg AND IFNULL(Revisao, '') = IFNULL(@revisao, '') ORDER BY Painel, Indice";
                comando.Parameters.AddWithValue("@dwg", dwg);
                comando.Parameters.AddWithValue("@revisao", (object)revisao ?? DBNull.Value);

                using (SQLiteDataReader leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        linhas.Add(new Bornes4IRow
                        {
                            Indice = leitor.GetInt64(leitor.GetOrdinal("Indice")),
                            Revisao = Texto(leitor, "Revisao"),
                            DWG = Inteiro(leitor, "DWG"),
                            Painel = Inteiro(leitor, "Painel"),
                            IndexRegua = Inteiro(leitor, "IndexRegua"),
                            Regua = Texto(leitor, "Regua"),
                            Alternativo = Texto(leitor, "Alternativo"),
                            Handle = Texto(leitor, "Handle"),
                            Borne = Texto(leitor, "Borne"),
                            Ordem = Real(leitor, "Ordem"),
                            Tipo = Inteiro(leitor, "Tipo"),
                            Pagina = Texto(leitor, "Pagina"),
                            bReserva = Logico(leitor, "bReserva"),
                        });
                    }
                }
            }

            return linhas;
        }

        /// <summary>Lê os tipos de aplicação de uma revisão (<c>Aplicacao4F</c>).</summary>
        public IReadOnlyList<Aplicacao4FRow> AplicacoesDaRevisao(int dwg, string revisao)
        {
            List<Aplicacao4FRow> linhas = new List<Aplicacao4FRow>();
            using (SQLiteConnection conexao = Abrir())
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText =
                    "SELECT Indice, Revisao, DWG, Numero, Nome, Secao, Cor, TipoCabo, Isolacao " +
                    "FROM Aplicacao4F " +
                    "WHERE DWG = @dwg AND IFNULL(Revisao, '') = IFNULL(@revisao, '') ORDER BY Numero, Indice";
                comando.Parameters.AddWithValue("@dwg", dwg);
                comando.Parameters.AddWithValue("@revisao", (object)revisao ?? DBNull.Value);

                using (SQLiteDataReader leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        linhas.Add(new Aplicacao4FRow
                        {
                            Indice = leitor.GetInt64(leitor.GetOrdinal("Indice")),
                            Revisao = Texto(leitor, "Revisao"),
                            DWG = Inteiro(leitor, "DWG"),
                            Numero = Inteiro(leitor, "Numero"),
                            Nome = Texto(leitor, "Nome"),
                            Secao = Texto(leitor, "Secao"),
                            Cor = Texto(leitor, "Cor"),
                            TipoCabo = Texto(leitor, "TipoCabo"),
                            Isolacao = Texto(leitor, "Isolacao"),
                        });
                    }
                }
            }

            return linhas;
        }

        /// <summary>Lê os circuitos de uma revisão (<c>Circuitos4F</c>).</summary>
        public IReadOnlyList<Circuitos4FRow> CircuitosDaRevisao(int dwg, string revisao)
        {
            List<Circuitos4FRow> linhas = new List<Circuitos4FRow>();
            using (SQLiteConnection conexao = Abrir())
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText =
                    "SELECT Indice, Revisao, DWG, Painel, Circuito, Potencial " +
                    "FROM Circuitos4F " +
                    "WHERE DWG = @dwg AND IFNULL(Revisao, '') = IFNULL(@revisao, '') ORDER BY Painel, Indice";
                comando.Parameters.AddWithValue("@dwg", dwg);
                comando.Parameters.AddWithValue("@revisao", (object)revisao ?? DBNull.Value);

                using (SQLiteDataReader leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        linhas.Add(new Circuitos4FRow
                        {
                            Indice = leitor.GetInt64(leitor.GetOrdinal("Indice")),
                            Revisao = Texto(leitor, "Revisao"),
                            DWG = Inteiro(leitor, "DWG"),
                            Painel = Inteiro(leitor, "Painel"),
                            Circuito = Texto(leitor, "Circuito"),
                            Potencial = Inteiro(leitor, "Potencial"),
                        });
                    }
                }
            }

            return linhas;
        }

        /// <summary>Lê os dispositivos de uma revisão (<c>Dispositivos4F</c>).</summary>
        public IReadOnlyList<Dispositivos4FRow> DispositivosDaRevisao(int dwg, string revisao)
        {
            List<Dispositivos4FRow> linhas = new List<Dispositivos4FRow>();
            using (SQLiteConnection conexao = Abrir())
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText =
                    "SELECT Indice, Revisao, DWG, Painel, Tag, Alternativo, Tipo, Handle, Pagina, " +
                    "BlocoTopografico, BlocoLayout, PosicaoNum, Ordem " +
                    "FROM Dispositivos4F " +
                    "WHERE DWG = @dwg AND IFNULL(Revisao, '') = IFNULL(@revisao, '') ORDER BY Painel, Indice";
                comando.Parameters.AddWithValue("@dwg", dwg);
                comando.Parameters.AddWithValue("@revisao", (object)revisao ?? DBNull.Value);

                using (SQLiteDataReader leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        linhas.Add(new Dispositivos4FRow
                        {
                            Indice = leitor.GetInt64(leitor.GetOrdinal("Indice")),
                            Revisao = Texto(leitor, "Revisao"),
                            DWG = Inteiro(leitor, "DWG"),
                            Painel = Inteiro(leitor, "Painel"),
                            Tag = Texto(leitor, "Tag"),
                            Alternativo = Texto(leitor, "Alternativo"),
                            Tipo = Texto(leitor, "Tipo"),
                            Handle = Texto(leitor, "Handle"),
                            Pagina = Texto(leitor, "Pagina"),
                            BlocoTopografico = Texto(leitor, "BlocoTopografico"),
                            BlocoLayout = Texto(leitor, "BlocoLayout"),
                            PosicaoNum = Inteiro(leitor, "PosicaoNum"),
                            Ordem = Inteiro(leitor, "Ordem"),
                        });
                    }
                }
            }

            return linhas;
        }

        /// <summary>
        /// Lê o **cadastro de painéis** (<c>Paineis</c>) — o mapa <c>índice → nome</c> do
        /// projeto. No original o dicionário de painéis mora no **banco**
        /// (<c>cDadosAccess.carregaPainelDicionario</c>, lido por
        /// <c>Dicionario.BuscaNomeDoPainel</c>), não no desenho: é esta tabela que
        /// responde "???" para um painel que não existe mais (`lPnAoagado`).
        /// </summary>
        public IReadOnlyCollection<int> LerIndicesDePaineis()
        {
            List<int> indices = new List<int>();
            using (SQLiteConnection conexao = Abrir())
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText = "SELECT Indice FROM Paineis";

                using (SQLiteDataReader leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        indices.Add((int)leitor.GetInt64(0));
                    }
                }
            }

            return indices;
        }

        /// <summary>
        /// Lê o cadastro de painéis como o mapa <c>índice → nome</c> — o
        /// <c>Dicionario.BuscaNomeDoPainel</c> do original, que é o prefixo do
        /// rótulo da máscara no verificador (<c>bt5Terminais</c>/<c>bt6Portas</c>).
        /// </summary>
        public IReadOnlyDictionary<int, string> LerNomesDePaineis()
        {
            Dictionary<int, string> nomes = new Dictionary<int, string>();
            using (SQLiteConnection conexao = Abrir())
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText = "SELECT Indice, Nome FROM Paineis";

                using (SQLiteDataReader leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        nomes[(int)leitor.GetInt64(0)] = leitor.IsDBNull(1) ? string.Empty : leitor.GetString(1);
                    }
                }
            }

            return nomes;
        }

        /// <summary>Lê o catálogo de cabos (<c>Cabos</c>) — fonte do snapshot <c>Cabos4</c>.</summary>
        public IReadOnlyList<CabosRow> LerCabos()
        {
            List<CabosRow> linhas = new List<CabosRow>();
            using (SQLiteConnection conexao = Abrir())
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText =
                    "SELECT Tag, Formacao, Blindagem, Pn1, Pn2, Codigo, Funcao, Alarme, Aterrar, Comprimento, " +
                    "Trajeto, Instrucao, Diametro, Grupo, Cabos FROM Cabos ORDER BY Tag";

                using (SQLiteDataReader leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        linhas.Add(new CabosRow
                        {
                            Tag = Texto(leitor, "Tag"),
                            Formacao = Texto(leitor, "Formacao"),
                            Blindagem = Logico(leitor, "Blindagem"),
                            Pn1 = Inteiro(leitor, "Pn1"),
                            Pn2 = Inteiro(leitor, "Pn2"),
                            Codigo = Texto(leitor, "Codigo"),
                            Funcao = Texto(leitor, "Funcao"),
                            Alarme = Inteiro(leitor, "Alarme"),
                            Aterrar = Inteiro(leitor, "Aterrar"),
                            Comprimento = Real(leitor, "Comprimento"),
                            Trajeto = Texto(leitor, "Trajeto"),
                            Instrucao = Texto(leitor, "Instrucao"),
                            Diametro = Real(leitor, "Diametro"),
                            Grupo = Texto(leitor, "Grupo"),
                            Cabos = Inteiro(leitor, "Cabos"),
                        });
                    }
                }
            }

            return linhas;
        }

        /// <summary>Lê o catálogo de veias (<c>Veias</c>) — fonte do snapshot <c>Veias4</c>.</summary>
        public IReadOnlyList<VeiasRow> LerVeias()
        {
            List<VeiasRow> linhas = new List<VeiasRow>();
            using (SQLiteConnection conexao = Abrir())
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText =
                    "SELECT Tag, Indice, Nome_Veia, Uso, Handle, Arquivo, Pagina, Chave, Funcao FROM Veias ORDER BY Tag";

                using (SQLiteDataReader leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        linhas.Add(new VeiasRow
                        {
                            Tag = Texto(leitor, "Tag"),
                            Indice = Inteiro(leitor, "Indice"),
                            Nome_Veia = Texto(leitor, "Nome_Veia"),
                            Uso = Logico(leitor, "Uso"),
                            Handle = Texto(leitor, "Handle"),
                            Arquivo = Inteiro(leitor, "Arquivo"),
                            Pagina = Texto(leitor, "Pagina"),
                            Chave = leitor.IsDBNull(leitor.GetOrdinal("Chave")) ? 0L : leitor.GetInt64(leitor.GetOrdinal("Chave")),
                            Funcao = Texto(leitor, "Funcao"),
                        });
                    }
                }
            }

            return linhas;
        }

        /// <summary>
        /// Regrava o snapshot <c>Cabos4</c> da revisão — apaga as linhas anteriores
        /// dessa revisão e insere as novas (como o <c>RemoveRevisaoTabelaParaTodosDWG</c>
        /// + <c>RUIU5Sbjhj</c> do original). Devolve quantas linhas foram gravadas.
        /// </summary>
        public int RegravarCabos4(string revisao, IEnumerable<Cabos4Row> linhas)
        {
            List<Cabos4Row> lista = linhas == null ? new List<Cabos4Row>() : new List<Cabos4Row>(linhas);

            using (SQLiteConnection conexao = Abrir())
            using (SQLiteTransaction transacao = conexao.BeginTransaction())
            {
                using (SQLiteCommand remover = conexao.CreateCommand())
                {
                    remover.CommandText = "DELETE FROM Cabos4 WHERE IFNULL(Revisao, '') = IFNULL(@revisao, '')";
                    remover.Parameters.AddWithValue("@revisao", (object)revisao ?? DBNull.Value);
                    remover.ExecuteNonQuery();
                }

                using (SQLiteCommand comando = conexao.CreateCommand())
                {
                    comando.CommandText =
                        "INSERT INTO Cabos4(Revisao, Tag, Formacao, Blindagem, Pn1, Pn2, Codigo, Funcao, Aterrar, " +
                        "Comprimento, Trajeto, Instrucao, Diametro, Grupo, Cabos, Criador, Data) " +
                        "VALUES(@revisao, @tag, @formacao, @blindagem, @pn1, @pn2, @codigo, @funcao, @aterrar, " +
                        "@comprimento, @trajeto, @instrucao, @diametro, @grupo, @cabos, @criador, @data)";

                    SQLiteParameter[] parametros =
                    {
                        comando.Parameters.Add("@revisao", System.Data.DbType.String),
                        comando.Parameters.Add("@tag", System.Data.DbType.String),
                        comando.Parameters.Add("@formacao", System.Data.DbType.String),
                        comando.Parameters.Add("@blindagem", System.Data.DbType.Boolean),
                        comando.Parameters.Add("@pn1", System.Data.DbType.Int32),
                        comando.Parameters.Add("@pn2", System.Data.DbType.Int32),
                        comando.Parameters.Add("@codigo", System.Data.DbType.String),
                        comando.Parameters.Add("@funcao", System.Data.DbType.String),
                        comando.Parameters.Add("@aterrar", System.Data.DbType.Int32),
                        comando.Parameters.Add("@comprimento", System.Data.DbType.Double),
                        comando.Parameters.Add("@trajeto", System.Data.DbType.String),
                        comando.Parameters.Add("@instrucao", System.Data.DbType.String),
                        comando.Parameters.Add("@diametro", System.Data.DbType.Double),
                        comando.Parameters.Add("@grupo", System.Data.DbType.String),
                        comando.Parameters.Add("@cabos", System.Data.DbType.Int32),
                        comando.Parameters.Add("@criador", System.Data.DbType.String),
                        comando.Parameters.Add("@data", System.Data.DbType.DateTime),
                    };

                    foreach (Cabos4Row linha in lista)
                    {
                        parametros[0].Value = Nulo(linha.Revisao);
                        parametros[1].Value = Nulo(linha.Tag);
                        parametros[2].Value = Nulo(linha.Formacao);
                        parametros[3].Value = linha.Blindagem;
                        parametros[4].Value = Falta(linha.Pn1);
                        parametros[5].Value = Falta(linha.Pn2);
                        parametros[6].Value = Nulo(linha.Codigo);
                        parametros[7].Value = Nulo(linha.Funcao);
                        parametros[8].Value = Falta(linha.Aterrar);
                        parametros[9].Value = Falta(linha.Comprimento);
                        parametros[10].Value = Nulo(linha.Trajeto);
                        parametros[11].Value = Nulo(linha.Instrucao);
                        parametros[12].Value = Falta(linha.Diametro);
                        parametros[13].Value = Nulo(linha.Grupo);
                        parametros[14].Value = Falta(linha.Cabos);
                        parametros[15].Value = Nulo(linha.Criador);
                        parametros[16].Value = linha.Data.HasValue ? (object)linha.Data.Value : DBNull.Value;
                        comando.ExecuteNonQuery();
                    }
                }

                transacao.Commit();
                return lista.Count;
            }
        }

        /// <summary>
        /// Regrava o snapshot <c>Veias4</c> da revisão — apaga as anteriores e
        /// insere as novas (o <c>v1TU0cEjWd</c> do original).
        /// </summary>
        public int RegravarVeias4(string revisao, IEnumerable<Veias4Row> linhas)
        {
            List<Veias4Row> lista = linhas == null ? new List<Veias4Row>() : new List<Veias4Row>(linhas);

            using (SQLiteConnection conexao = Abrir())
            using (SQLiteTransaction transacao = conexao.BeginTransaction())
            {
                using (SQLiteCommand remover = conexao.CreateCommand())
                {
                    remover.CommandText = "DELETE FROM Veias4 WHERE IFNULL(Revisao, '') = IFNULL(@revisao, '')";
                    remover.Parameters.AddWithValue("@revisao", (object)revisao ?? DBNull.Value);
                    remover.ExecuteNonQuery();
                }

                using (SQLiteCommand comando = conexao.CreateCommand())
                {
                    comando.CommandText =
                        "INSERT INTO Veias4(Revisao, Tag, Num_Veia, Nome_Veia, Uso, Funcao) " +
                        "VALUES(@revisao, @tag, @numVeia, @nomeVeia, @uso, @funcao)";

                    SQLiteParameter[] parametros =
                    {
                        comando.Parameters.Add("@revisao", System.Data.DbType.String),
                        comando.Parameters.Add("@tag", System.Data.DbType.String),
                        comando.Parameters.Add("@numVeia", System.Data.DbType.Int32),
                        comando.Parameters.Add("@nomeVeia", System.Data.DbType.String),
                        comando.Parameters.Add("@uso", System.Data.DbType.Boolean),
                        comando.Parameters.Add("@funcao", System.Data.DbType.String),
                    };

                    foreach (Veias4Row linha in lista)
                    {
                        parametros[0].Value = Nulo(linha.Revisao);
                        parametros[1].Value = Nulo(linha.Tag);
                        parametros[2].Value = Falta(linha.Num_Veia);
                        parametros[3].Value = Nulo(linha.Nome_Veia);
                        parametros[4].Value = linha.Uso;
                        parametros[5].Value = Nulo(linha.Funcao);
                        comando.ExecuteNonQuery();
                    }
                }

                transacao.Commit();
                return lista.Count;
            }
        }

        /// <summary>Lê o snapshot <c>Cabos4</c> de uma revisão (para o app conferir).</summary>
        public IReadOnlyList<Cabos4Row> Cabos4PorRevisao(string revisao)
        {
            List<Cabos4Row> linhas = new List<Cabos4Row>();
            using (SQLiteConnection conexao = Abrir())
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText =
                    "SELECT Indice, Revisao, Tag, Formacao, Blindagem, Pn1, Pn2, Codigo, Funcao, Aterrar, " +
                    "Comprimento, Trajeto, Instrucao, Diametro, Grupo, Cabos, Criador, Data FROM Cabos4 " +
                    "WHERE Revisao = @revisao ORDER BY Tag";
                comando.Parameters.AddWithValue("@revisao", (object)revisao ?? DBNull.Value);

                using (SQLiteDataReader leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        linhas.Add(new Cabos4Row
                        {
                            Indice = leitor.GetInt64(leitor.GetOrdinal("Indice")),
                            Revisao = Texto(leitor, "Revisao"),
                            Tag = Texto(leitor, "Tag"),
                            Formacao = Texto(leitor, "Formacao"),
                            Blindagem = Logico(leitor, "Blindagem"),
                            Pn1 = Inteiro(leitor, "Pn1"),
                            Pn2 = Inteiro(leitor, "Pn2"),
                            Codigo = Texto(leitor, "Codigo"),
                            Funcao = Texto(leitor, "Funcao"),
                            Aterrar = Inteiro(leitor, "Aterrar"),
                            Comprimento = Real(leitor, "Comprimento"),
                            Trajeto = Texto(leitor, "Trajeto"),
                            Instrucao = Texto(leitor, "Instrucao"),
                            Diametro = Real(leitor, "Diametro"),
                            Grupo = Texto(leitor, "Grupo"),
                            Cabos = Inteiro(leitor, "Cabos"),
                            Criador = Texto(leitor, "Criador"),
                        });
                    }
                }
            }

            return linhas;
        }

        /// <summary>Lê o snapshot <c>Veias4</c> de uma revisão.</summary>
        public IReadOnlyList<Veias4Row> Veias4PorRevisao(string revisao)
        {
            List<Veias4Row> linhas = new List<Veias4Row>();
            using (SQLiteConnection conexao = Abrir())
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText =
                    "SELECT Indice, Revisao, Tag, Num_Veia, Nome_Veia, Uso, Funcao FROM Veias4 " +
                    "WHERE Revisao = @revisao ORDER BY Tag";
                comando.Parameters.AddWithValue("@revisao", (object)revisao ?? DBNull.Value);

                using (SQLiteDataReader leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        linhas.Add(new Veias4Row
                        {
                            Indice = leitor.GetInt64(leitor.GetOrdinal("Indice")),
                            Revisao = Texto(leitor, "Revisao"),
                            Tag = Texto(leitor, "Tag"),
                            Num_Veia = Inteiro(leitor, "Num_Veia"),
                            Nome_Veia = Texto(leitor, "Nome_Veia"),
                            Uso = Logico(leitor, "Uso"),
                            Funcao = Texto(leitor, "Funcao"),
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
                // Substitui a revisão (RemoveRevisaoTabelaParaDWG do original):
                // mesmo com lote vazio, o desenho é a verdade — o que sumiu do
                // desenho não pode ficar no banco.
                RemoverRevisaoDaTabela(conexao, "Portas4F", dwg, revisao);

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
                // Substitui a revisão (RemoveRevisaoTabelaParaDWG do original):
                // mesmo com lote vazio, o desenho é a verdade — o que sumiu do
                // desenho não pode ficar no banco.
                RemoverRevisaoDaTabela(conexao, "Bornes4F", dwg, revisao);

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
                // Substitui a revisão (RemoveRevisaoTabelaParaDWG do original):
                // mesmo com lote vazio, o desenho é a verdade — o que sumiu do
                // desenho não pode ficar no banco.
                RemoverRevisaoDaTabela(conexao, "Contatos4F", dwg, revisao);

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

        /// <summary>Grava as portas da interligação (<c>Portas4I</c>) — ver <see cref="Portas4IGerador"/>.</summary>
        public void InserirPortas4I(IEnumerable<Porta4I> portas, string revisao, int dwg)
        {
            List<Porta4I> lista = portas == null ? new List<Porta4I>() : new List<Porta4I>(portas);

            using (SQLiteConnection conexao = Abrir())
            using (SQLiteTransaction transacao = conexao.BeginTransaction())
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                RemoverRevisaoDaTabela(conexao, "Portas4I", dwg, revisao);

                comando.CommandText =
                    "INSERT INTO Portas4I(Revisao, DWG, IndexModelo, NomeModelo, Regua, Borne, Terminal, " +
                    "TerminalNum, Tipo) " +
                    "VALUES(@revisao, @dwg, @indexModelo, @nomeModelo, @regua, @borne, @terminal, " +
                    "@terminalNum, @tipo)";

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
                };

                foreach (Porta4I porta in lista)
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
                    comando.ExecuteNonQuery();
                }

                transacao.Commit();
            }
        }

        /// <summary>Grava os bornes da interligação (<c>Bornes4I</c>) — ver <see cref="Bornes4IGerador"/>.</summary>
        public void InserirBornes4I(IEnumerable<Borne4I> bornes, string revisao, int dwg)
        {
            List<Borne4I> lista = bornes == null ? new List<Borne4I>() : new List<Borne4I>(bornes);

            using (SQLiteConnection conexao = Abrir())
            using (SQLiteTransaction transacao = conexao.BeginTransaction())
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                RemoverRevisaoDaTabela(conexao, "Bornes4I", dwg, revisao);

                comando.CommandText =
                    "INSERT INTO Bornes4I(Revisao, DWG, Painel, IndexRegua, Regua, Alternativo, Handle, Borne, " +
                    "Ordem, Tipo, Pagina, bReserva) " +
                    "VALUES(@revisao, @dwg, @painel, @indexRegua, @regua, @alternativo, @handle, @borne, " +
                    "@ordem, @tipo, @pagina, @bReserva)";

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
                };

                foreach (Borne4I borne in lista)
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
                    comando.ExecuteNonQuery();
                }

                transacao.Commit();
            }
        }

        /// <summary>Grava os tipos de aplicação (<c>Aplicacao4F</c>) — ver <see cref="Aplicacao4FGerador"/>.</summary>
        public void InserirAplicacoes(IEnumerable<Aplicacao4F> aplicacoes, string revisao, int dwg)
        {
            List<Aplicacao4F> lista = aplicacoes == null
                ? new List<Aplicacao4F>()
                : new List<Aplicacao4F>(aplicacoes);

            using (SQLiteConnection conexao = Abrir())
            using (SQLiteTransaction transacao = conexao.BeginTransaction())
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                // Substitui a revisão (RemoveRevisaoTabelaParaDWG do original).
                RemoverRevisaoDaTabela(conexao, "Aplicacao4F", dwg, revisao);

                comando.CommandText =
                    "INSERT INTO Aplicacao4F(Revisao, DWG, Numero, Nome, Secao, Cor, TipoCabo, Isolacao) " +
                    "VALUES(@revisao, @dwg, @numero, @nome, @secao, @cor, @tipoCabo, @isolacao)";

                SQLiteParameter[] parametros =
                {
                    comando.Parameters.Add("@revisao", System.Data.DbType.String),
                    comando.Parameters.Add("@dwg", System.Data.DbType.Int32),
                    comando.Parameters.Add("@numero", System.Data.DbType.Int32),
                    comando.Parameters.Add("@nome", System.Data.DbType.String),
                    comando.Parameters.Add("@secao", System.Data.DbType.String),
                    comando.Parameters.Add("@cor", System.Data.DbType.String),
                    comando.Parameters.Add("@tipoCabo", System.Data.DbType.String),
                    comando.Parameters.Add("@isolacao", System.Data.DbType.String),
                };

                foreach (Aplicacao4F aplicacao in lista)
                {
                    parametros[0].Value = Nulo(revisao);
                    parametros[1].Value = dwg;
                    parametros[2].Value = aplicacao.Numero;
                    parametros[3].Value = Nulo(aplicacao.Nome);
                    parametros[4].Value = Nulo(aplicacao.Secao);
                    parametros[5].Value = Nulo(aplicacao.Cor);
                    parametros[6].Value = Nulo(aplicacao.TipoCabo);
                    parametros[7].Value = Nulo(aplicacao.Isolacao);
                    comando.ExecuteNonQuery();
                }

                transacao.Commit();
            }
        }

        /// <summary>Grava os circuitos (<c>Circuitos4F</c>) — ver <see cref="Circuitos4FGerador"/>.</summary>
        public void InserirCircuitos(IEnumerable<Circuito4F> circuitos, string revisao, int dwg)
        {
            List<Circuito4F> lista = circuitos == null
                ? new List<Circuito4F>()
                : new List<Circuito4F>(circuitos);

            using (SQLiteConnection conexao = Abrir())
            using (SQLiteTransaction transacao = conexao.BeginTransaction())
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                // Substitui a revisão (RemoveRevisaoTabelaParaDWG do original).
                RemoverRevisaoDaTabela(conexao, "Circuitos4F", dwg, revisao);

                comando.CommandText =
                    "INSERT INTO Circuitos4F(Revisao, DWG, Painel, Circuito, Potencial) " +
                    "VALUES(@revisao, @dwg, @painel, @circuito, @potencial)";

                SQLiteParameter[] parametros =
                {
                    comando.Parameters.Add("@revisao", System.Data.DbType.String),
                    comando.Parameters.Add("@dwg", System.Data.DbType.Int32),
                    comando.Parameters.Add("@painel", System.Data.DbType.Int32),
                    comando.Parameters.Add("@circuito", System.Data.DbType.String),
                    comando.Parameters.Add("@potencial", System.Data.DbType.Int32),
                };

                foreach (Circuito4F circuito in lista)
                {
                    parametros[0].Value = Nulo(revisao);
                    parametros[1].Value = dwg;
                    parametros[2].Value = (int)circuito.Painel;
                    parametros[3].Value = Nulo(circuito.Circuito);
                    parametros[4].Value = circuito.Potencial;
                    comando.ExecuteNonQuery();
                }

                transacao.Commit();
            }
        }

        /// <summary>Grava os dispositivos (<c>Dispositivos4F</c>) — ver <see cref="Dispositivos4FGerador"/>.</summary>
        public void InserirDispositivos(IEnumerable<Dispositivo4F> dispositivos, string revisao, int dwg)
        {
            List<Dispositivo4F> lista = dispositivos == null
                ? new List<Dispositivo4F>()
                : new List<Dispositivo4F>(dispositivos);

            using (SQLiteConnection conexao = Abrir())
            using (SQLiteTransaction transacao = conexao.BeginTransaction())
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                // Substitui a revisão (RemoveRevisaoTabelaParaDWG): o desenho é a
                // verdade — dispositivo que sumiu do desenho sai do banco.
                RemoverRevisaoDaTabela(conexao, "Dispositivos4F", dwg, revisao);

                comando.CommandText =
                    "INSERT INTO Dispositivos4F(Revisao, DWG, Painel, Tag, Alternativo, Tipo, Handle, Pagina, " +
                    "BlocoTopografico, BlocoLayout, PosicaoNum, Ordem) " +
                    "VALUES(@revisao, @dwg, @painel, @tag, @alternativo, @tipo, @handle, @pagina, " +
                    "@blocoTopografico, @blocoLayout, @posicaoNum, @ordem)";

                SQLiteParameter[] parametros =
                {
                    comando.Parameters.Add("@revisao", System.Data.DbType.String),
                    comando.Parameters.Add("@dwg", System.Data.DbType.Int32),
                    comando.Parameters.Add("@painel", System.Data.DbType.Int32),
                    comando.Parameters.Add("@tag", System.Data.DbType.String),
                    comando.Parameters.Add("@alternativo", System.Data.DbType.String),
                    comando.Parameters.Add("@tipo", System.Data.DbType.String),
                    comando.Parameters.Add("@handle", System.Data.DbType.String),
                    comando.Parameters.Add("@pagina", System.Data.DbType.String),
                    comando.Parameters.Add("@blocoTopografico", System.Data.DbType.String),
                    comando.Parameters.Add("@blocoLayout", System.Data.DbType.String),
                    comando.Parameters.Add("@posicaoNum", System.Data.DbType.Int32),
                    comando.Parameters.Add("@ordem", System.Data.DbType.Int32),
                };

                foreach (Dispositivo4F dispositivo in lista)
                {
                    parametros[0].Value = Nulo(revisao);
                    parametros[1].Value = dwg;
                    parametros[2].Value = (int)dispositivo.Painel;
                    parametros[3].Value = Nulo(dispositivo.Tag);
                    parametros[4].Value = Nulo(dispositivo.Alternativo);
                    parametros[5].Value = Nulo(dispositivo.Tipo);
                    parametros[6].Value = Nulo(dispositivo.Handle);
                    parametros[7].Value = Nulo(dispositivo.Pagina);
                    parametros[8].Value = Nulo(dispositivo.BlocoTopografico);
                    parametros[9].Value = Nulo(dispositivo.BlocoLayout);
                    parametros[10].Value = dispositivo.PosicaoNum;
                    parametros[11].Value = dispositivo.Ordem;
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

        /// <summary>
        /// Grava as plaquetas do desenho (<c>Plaquetas4</c>) — ver
        /// <see cref="Plaquetas4Gerador"/>.
        ///
        /// A tabela **não tem revisão**: o original apaga por <c>DWG</c>
        /// (<c>RemovePlaquetas</c>) e insere o lote novo, na mesma transação — a
        /// mesma idempotência por desenho das outras tabelas.
        /// </summary>
        public void InserirPlaquetas(IEnumerable<Plaquetas4Row> plaquetas, int dwg)
        {
            using (SQLiteConnection conexao = Abrir())
            using (SQLiteTransaction transacao = conexao.BeginTransaction())
            {
                using (SQLiteCommand remover = conexao.CreateCommand())
                {
                    remover.CommandText = "DELETE FROM Plaquetas4 WHERE DWG = @dwg";
                    remover.Parameters.AddWithValue("@dwg", dwg);
                    remover.ExecuteNonQuery();
                }

                using (SQLiteCommand comando = conexao.CreateCommand())
                {
                    comando.CommandText =
                        "INSERT INTO Plaquetas4(DWG, Painel, Tag, Desc1, Desc2, Desc3, Modelo) " +
                        "VALUES(@dwg, @painel, @tag, @desc1, @desc2, @desc3, @modelo)";

                    SQLiteParameter[] parametros =
                    {
                        comando.Parameters.Add("@dwg", System.Data.DbType.Int64),
                        comando.Parameters.Add("@painel", System.Data.DbType.Int64),
                        comando.Parameters.Add("@tag", System.Data.DbType.String),
                        comando.Parameters.Add("@desc1", System.Data.DbType.String),
                        comando.Parameters.Add("@desc2", System.Data.DbType.String),
                        comando.Parameters.Add("@desc3", System.Data.DbType.String),
                        comando.Parameters.Add("@modelo", System.Data.DbType.String),
                    };

                    foreach (Plaquetas4Row plaqueta in plaquetas)
                    {
                        parametros[0].Value = Falta(plaqueta.DWG);
                        parametros[1].Value = Falta(plaqueta.Painel);
                        parametros[2].Value = Nulo(plaqueta.Tag);
                        parametros[3].Value = Nulo(plaqueta.Desc1);
                        parametros[4].Value = Nulo(plaqueta.Desc2);
                        parametros[5].Value = Nulo(plaqueta.Desc3);
                        parametros[6].Value = Nulo(plaqueta.Modelo);
                        comando.ExecuteNonQuery();
                    }
                }

                transacao.Commit();
            }
        }

        /// <summary>
        /// As linhas de <c>ListaMateriais</c> de um desenho, na ordem do original
        /// (<c>ORDER BY Painel, Ordem</c>) — o <c>CarregaOrdemEmMateriais</c>.
        ///
        /// A lista **não tem revisão**: a chave é o <c>DWG</c>.
        /// </summary>
        public List<LinhaListaMaterial> LerListaMateriais(int dwg)
        {
            return LerListaMateriais(dwg, false, false);
        }

        /// <summary>As linhas <c>Avulso = true</c> do desenho — o <c>CapturaMateriaisAvulso</c>.</summary>
        public List<LinhaListaMaterial> LerListaMateriaisAvulsos(int dwg)
        {
            return LerListaMateriais(dwg, true, false);
        }

        private List<LinhaListaMaterial> LerListaMateriais(int dwg, bool somenteAvulsos, bool somenteComIndiceLM)
        {
            List<LinhaListaMaterial> linhas = new List<LinhaListaMaterial>();

            using (SQLiteConnection conexao = Abrir())
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText =
                    "SELECT DWG, Painel, Tag, IndiceMaterial, Quantidade, Ordem, Avulso, Destino, " +
                    "DescDestino, Alternativo, Handle, IndiceLM, OrdemLay FROM ListaMateriais WHERE DWG = @dwg";
                if (somenteAvulsos)
                {
                    comando.CommandText += " AND Avulso = 1";
                }

                if (somenteComIndiceLM)
                {
                    comando.CommandText += " AND IndiceLM IS NOT NULL";
                }

                comando.CommandText += " ORDER BY Painel, Ordem";
                comando.Parameters.AddWithValue("@dwg", dwg);

                using (SQLiteDataReader leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        linhas.Add(new LinhaListaMaterial
                        {
                            DWG = (int)(Inteiro(leitor, "DWG") ?? 0),
                            Painel = (int)(Inteiro(leitor, "Painel") ?? 0),
                            Tag = Texto(leitor, "Tag"),
                            IndiceMaterial = (int)(Inteiro(leitor, "IndiceMaterial") ?? 0),
                            Quantidade = (int)(Inteiro(leitor, "Quantidade") ?? 0),
                            Ordem = (int)(Inteiro(leitor, "Ordem") ?? 0),
                            Avulso = Logico(leitor, "Avulso"),
                            Destino = Texto(leitor, "Destino"),
                            DescDestino = Texto(leitor, "DescDestino"),
                            Alternativo = Texto(leitor, "Alternativo"),
                            Handle = Texto(leitor, "Handle"),
                            IndiceLM = (int)(Inteiro(leitor, "IndiceLM") ?? 0),
                            OrdemLay = (int)(Inteiro(leitor, "OrdemLay") ?? 0),
                        });
                    }
                }
            }

            return linhas;
        }

        /// <summary>
        /// Apaga as linhas **não-avulsas** do desenho — o <c>RemoveMateriaisLista</c>
        /// do original. Os itens avulsos (o que o usuário lançou à mão no app) ficam:
        /// o fluxo os relê em seguida (<c>CapturaMateriaisAvulso</c>) e os regrava.
        /// </summary>
        public int RemoverListaMateriaisNaoAvulsos(int dwg)
        {
            using (SQLiteConnection conexao = Abrir())
            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText = "DELETE FROM ListaMateriais WHERE DWG = @dwg AND IFNULL(Avulso, 0) = 0";
                comando.Parameters.AddWithValue("@dwg", dwg);
                return comando.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Apaga a lista dos desenhos que **não estão no cadastro** (<c>DWG</c>) — o
        /// <c>cDadosLM.AtualizaLMBaseadoNosDWGsCadastrados</c>.
        ///
        /// **Desvio deliberado:** o original roda isto sempre; aqui a limpeza é
        /// **pulada quando o cadastro está vazio**. Sem nenhum desenho cadastrado não
        /// há o que comparar, e apagar todas as listas por ausência de cadastro seria
        /// concluir dado que não existe — a regra do recorte é não inventar.
        /// </summary>
        public int RemoverListaMateriaisDeDwgsForaDoCadastro()
        {
            using (SQLiteConnection conexao = Abrir())
            {
                using (SQLiteCommand contar = conexao.CreateCommand())
                {
                    contar.CommandText = "SELECT COUNT(*) FROM DWG";
                    if (Convert.ToInt64(contar.ExecuteScalar()) == 0)
                    {
                        return 0;
                    }
                }

                using (SQLiteCommand comando = conexao.CreateCommand())
                {
                    comando.CommandText =
                        "DELETE FROM ListaMateriais WHERE DWG NOT IN (SELECT Indice FROM DWG)";
                    return comando.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Grava a lista do desenho — o <c>RemoveItemMaterial</c> do original: lê o
        /// <c>IndiceLM</c> das linhas que ainda estão no banco (por
        /// <c>DWG, Painel, Tag</c>), **apaga tudo do desenho** e insere o lote, na
        /// mesma transação.
        ///
        /// O <c>IndiceLM</c> **não** vem do gerador: quem o atribui é outro fluxo
        /// (<c>AtualizaIndiceLM</c>) e a projeção só o preserva.
        /// </summary>
        public int InserirListaMateriais(IEnumerable<LinhaListaMaterial> linhas, int dwg)
        {
            List<LinhaListaMaterial> lote = new List<LinhaListaMaterial>();
            if (linhas != null)
            {
                foreach (LinhaListaMaterial linha in linhas)
                {
                    if (linha != null)
                    {
                        lote.Add(linha);
                    }
                }
            }

            using (SQLiteConnection conexao = Abrir())
            using (SQLiteTransaction transacao = conexao.BeginTransaction())
            {
                Dictionary<string, int> indices = LerIndicesLM(conexao, dwg);

                using (SQLiteCommand remover = conexao.CreateCommand())
                {
                    remover.CommandText = "DELETE FROM ListaMateriais WHERE DWG = @dwg";
                    remover.Parameters.AddWithValue("@dwg", dwg);
                    remover.ExecuteNonQuery();
                }

                using (SQLiteCommand comando = conexao.CreateCommand())
                {
                    comando.CommandText =
                        "INSERT INTO ListaMateriais(DWG, Painel, Tag, IndiceMaterial, Quantidade, Ordem, " +
                        "Avulso, Destino, DescDestino, Alternativo, Handle, IndiceLM, OrdemLay) " +
                        "VALUES(@dwg, @painel, @tag, @indiceMaterial, @quantidade, @ordem, " +
                        "@avulso, @destino, @descDestino, @alternativo, @handle, @indiceLM, @ordemLay)";

                    SQLiteParameter[] parametros =
                    {
                        comando.Parameters.Add("@dwg", System.Data.DbType.Int64),
                        comando.Parameters.Add("@painel", System.Data.DbType.Int64),
                        comando.Parameters.Add("@tag", System.Data.DbType.String),
                        comando.Parameters.Add("@indiceMaterial", System.Data.DbType.Int64),
                        comando.Parameters.Add("@quantidade", System.Data.DbType.Int64),
                        comando.Parameters.Add("@ordem", System.Data.DbType.Int64),
                        comando.Parameters.Add("@avulso", System.Data.DbType.Int64),
                        comando.Parameters.Add("@destino", System.Data.DbType.String),
                        comando.Parameters.Add("@descDestino", System.Data.DbType.String),
                        comando.Parameters.Add("@alternativo", System.Data.DbType.String),
                        comando.Parameters.Add("@handle", System.Data.DbType.String),
                        comando.Parameters.Add("@indiceLM", System.Data.DbType.Int64),
                        comando.Parameters.Add("@ordemLay", System.Data.DbType.Int64),
                    };

                    foreach (LinhaListaMaterial linha in lote)
                    {
                        parametros[0].Value = linha.DWG != 0 ? linha.DWG : dwg;
                        parametros[1].Value = linha.Painel;
                        parametros[2].Value = Nulo(linha.Tag);
                        parametros[3].Value = linha.IndiceMaterial;
                        parametros[4].Value = linha.Quantidade;
                        parametros[5].Value = linha.Ordem;
                        parametros[6].Value = linha.Avulso ? 1 : 0;
                        parametros[7].Value = Nulo(linha.Destino);
                        parametros[8].Value = Nulo(linha.DescDestino);
                        parametros[9].Value = Nulo(linha.Alternativo);
                        parametros[10].Value = Nulo(linha.Handle);
                        parametros[11].Value = IndiceLMDe(indices, linha, linha.IndiceLM);
                        parametros[12].Value = linha.OrdemLay;
                        comando.ExecuteNonQuery();
                    }
                }

                transacao.Commit();
                return lote.Count;
            }
        }

        /// <summary>
        /// O mapa <c>(Painel, Tag) → IndiceLM</c> das linhas que já estão no banco —
        /// o <c>Select DWG, Painel, Tag, IndiceLM ... and IndiceLM IS NOT NULL</c> do
        /// <c>RemoveItemMaterial</c>.
        /// </summary>
        private Dictionary<string, int> LerIndicesLM(SQLiteConnection conexao, int dwg)
        {
            Dictionary<string, int> indices = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            using (SQLiteCommand comando = conexao.CreateCommand())
            {
                comando.CommandText =
                    "SELECT Painel, Tag, IndiceLM FROM ListaMateriais WHERE DWG = @dwg AND IndiceLM IS NOT NULL";
                comando.Parameters.AddWithValue("@dwg", dwg);

                using (SQLiteDataReader leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        long? painel = Inteiro(leitor, "Painel");
                        string tag = Texto(leitor, "Tag");
                        long? indice = Inteiro(leitor, "IndiceLM");
                        if (indice.HasValue)
                        {
                            indices[ChaveIndiceLM((int)(painel ?? 0), tag)] = (int)indice.Value;
                        }
                    }
                }
            }

            return indices;
        }

        private static object IndiceLMDe(Dictionary<string, int> indices, LinhaListaMaterial linha, int atual)
        {
            if (atual != 0)
            {
                return atual;
            }

            int guardado;
            if (indices.TryGetValue(ChaveIndiceLM(linha.Painel, linha.Tag), out guardado))
            {
                return guardado;
            }

            return 0;
        }

        private static string ChaveIndiceLM(int painel, string tag)
        {
            return painel + "\u0000" + (tag ?? string.Empty);
        }

        private static object Nulo(string valor)
        {
            return string.IsNullOrEmpty(valor) ? (object)DBNull.Value : valor;
        }

        /// <summary>Converte um valor opcional para o parâmetro (DBNull quando ausente).</summary>
        private static object Falta(double? valor)
        {
            return valor.HasValue ? (object)valor.Value : DBNull.Value;
        }

        /// <summary>Converte um valor opcional para o parâmetro (DBNull quando ausente).</summary>
        private static object Falta(int? valor)
        {
            return valor.HasValue ? (object)valor.Value : DBNull.Value;
        }

        /// <summary>Converte um valor opcional para o parâmetro (DBNull quando ausente).</summary>
        private static object Falta(long? valor)
        {
            return valor.HasValue ? (object)valor.Value : DBNull.Value;
        }

        private static Interligacao4Row LerInterligacao(SQLiteDataReader leitor)
        {
            return new Interligacao4Row
            {
                Indice = leitor.GetInt64(leitor.GetOrdinal("Indice")),
                Revisao = Texto(leitor, "Revisao"),
                DWG = Inteiro(leitor, "DWG"),
                Tag_Cabo = Texto(leitor, "Tag_Cabo"),
                Num_Veia = Inteiro(leitor, "Num_Veia"),
                Nome_Veia = Texto(leitor, "Nome_Veia"),
                DWG1 = Inteiro(leitor, "DWG1"),
                Documento1 = Texto(leitor, "Documento1"),
                Painel1 = Inteiro(leitor, "Painel1"),
                Pagina1 = Texto(leitor, "Pagina1"),
                Posicao1 = Texto(leitor, "Posicao1"),
                Tag1 = Texto(leitor, "Tag1"),
                Alternativo1 = Texto(leitor, "Alternativo1"),
                NRegua1 = Texto(leitor, "NRegua1"),
                Terminal1 = Texto(leitor, "Terminal1"),
                TerminalNum1 = Real(leitor, "TerminalNum1"),
                TipoBorne1 = Inteiro(leitor, "TipoBorne1"),
                Handle1 = Texto(leitor, "Handle1"),
                IndexModelo1 = Inteiro(leitor, "IndexModelo1"),
                DWG2 = Inteiro(leitor, "DWG2"),
                Documento2 = Texto(leitor, "Documento2"),
                Painel2 = Inteiro(leitor, "Painel2"),
                Pagina2 = Texto(leitor, "Pagina2"),
                Posicao2 = Texto(leitor, "Posicao2"),
                Tag2 = Texto(leitor, "Tag2"),
                Alternativo2 = Texto(leitor, "Alternativo2"),
                NRegua2 = Texto(leitor, "NRegua2"),
                Terminal2 = Texto(leitor, "Terminal2"),
                TerminalNum2 = Real(leitor, "TerminalNum2"),
                TipoBorne2 = Inteiro(leitor, "TipoBorne2"),
                Handle2 = Texto(leitor, "Handle2"),
                IndexModelo2 = Inteiro(leitor, "IndexModelo2"),
                Criador = Texto(leitor, "Criador"),
            };
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
                Alternativo = Texto(leitor, "Alternativo"),
                NRegua = Texto(leitor, "NRegua"),
                Terminal = Texto(leitor, "Terminal"),
                TerminalNum = Real(leitor, "TerminalNum"),
                Tipo = Texto(leitor, "Tipo"),
                Secao = Texto(leitor, "Secao"),
                Cor = Texto(leitor, "Cor"),
                PosicaoNum = Inteiro(leitor, "PosicaoNum"),
                TipoBorne = Inteiro(leitor, "TipoBorne"),
                BLink = Logico(leitor, "BLink"),
                Handle = Texto(leitor, "Handle"),
                IndexModelo = Inteiro(leitor, "IndexModelo"),
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

        private static double? Real(SQLiteDataReader leitor, string coluna)
        {
            int indice = leitor.GetOrdinal(coluna);
            return leitor.IsDBNull(indice) ? (double?)null : leitor.GetDouble(indice);
        }

        private static bool Logico(SQLiteDataReader leitor, string coluna)
        {
            int indice = leitor.GetOrdinal(coluna);
            return !leitor.IsDBNull(indice) && leitor.GetBoolean(indice);
        }

        /// <summary>
        /// Apaga as linhas de uma revisão de um desenho — o
        /// <c>RemoveRevisaoTabelaParaDWG</c> do original. Roda DENTRO da transação
        /// do INSERT: a projeção substitui a revisão em vez de acumular.
        /// </summary>
        private static void RemoverRevisaoDaTabela(SQLiteConnection conexao, string tabela, int dwg, string revisao)
        {
            using (SQLiteCommand remover = conexao.CreateCommand())
            {
                // `tabela` é literal deste arquivo — nunca vem de entrada do usuário.
                remover.CommandText = "DELETE FROM " + tabela +
                    " WHERE DWG = @dwg AND IFNULL(Revisao, '') = IFNULL(@revisao, '')";
                remover.Parameters.AddWithValue("@dwg", dwg);
                remover.Parameters.AddWithValue("@revisao", (object)revisao ?? DBNull.Value);
                remover.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Apaga a revisão de cada par (DWG, Revisão) presente no lote — para as
        /// origens que trazem o par por linha (fiação e interligação). Lote vazio
        /// não apaga nada: sem par não há o que substituir.
        /// </summary>
        private static void RemoverRevisoesDoLote<T>(
            SQLiteConnection conexao,
            string tabela,
            IEnumerable<T> itens,
            Func<T, int> obterDwg,
            Func<T, string> obterRevisao)
        {
            HashSet<Tuple<int, string>> pares = new HashSet<Tuple<int, string>>();
            foreach (T item in itens)
            {
                pares.Add(Tuple.Create(obterDwg(item), obterRevisao(item)));
            }

            foreach (Tuple<int, string> par in pares)
            {
                RemoverRevisaoDaTabela(conexao, tabela, par.Item1, par.Item2);
            }
        }
    }
}

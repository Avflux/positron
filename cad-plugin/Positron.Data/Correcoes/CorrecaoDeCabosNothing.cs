using System;
using System.Collections.Generic;

namespace Positron.Data.Correcoes
{
    /// <summary>Uma das atualizações do <c>CorrigeNothing</c>.</summary>
    public sealed class AtualizacaoDeCabo
    {
        /// <summary>A tabela do <c>UPDATE</c> (a <c>Cabos</c> do cadastro ou a <c>Cabos4</c>).</summary>
        public string Tabela { get; set; }

        public string Coluna { get; set; }

        /// <summary>O valor gravado.</summary>
        public string Valor { get; set; }

        /// <summary><c>true</c> quando o original <b>não</b> tem <c>WHERE</c> (o caso do <c>Alarme</c>).</summary>
        public bool SemFiltro { get; set; }
    }

    /// <summary>
    /// O <c>CorrigeCabos</c> do <c>Correcao.cs</c> — o <c>CorrigeNothing("Funcao")</c> do
    /// <c>cDadosAccessInterligacao2</c> (frente 2 do §7.6): **só banco**, três atualizações:
    ///
    /// <code>
    /// UPDATE Cabos  SET Funcao = ' ' WHERE Funcao = ''
    /// UPDATE Cabos4 SET Funcao = ' ' WHERE Funcao = ''
    /// UPDATE Cabos  SET Alarme = 0
    /// </code>
    ///
    /// Ou seja: a <c>Funcao</c> vazia vira um **espaço** (nas duas tabelas de cabos) e o
    /// <c>Alarme</c> do cadastro é **zerado sem filtro**.
    ///
    /// **Diferença registrada:** o original concatena o nome da coluna no SQL (o comando
    /// passa <c>"Funcao"</c>); aqui a coluna é conferida numa **lista branca** antes de
    /// montar o SQL.
    /// </summary>
    public static class CorrecaoDeCabosNothing
    {
        /// <summary>A coluna que o comando usa.</summary>
        public const string ColunaFuncao = "Funcao";

        /// <summary>O valor que substitui a string vazia (um espaço, como no original).</summary>
        public const string Vazio = " ";

        /// <summary>As colunas aceitas (a lista branca de segurança).</summary>
        public static bool ColunaValida(string coluna)
        {
            return string.Equals(coluna, ColunaFuncao, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>As três atualizações, na ordem do original.</summary>
        public static IReadOnlyList<AtualizacaoDeCabo> Plano(string coluna)
        {
            List<AtualizacaoDeCabo> atualizacoes = new List<AtualizacaoDeCabo>();
            if (!ColunaValida(coluna))
            {
                return atualizacoes;
            }

            atualizacoes.Add(new AtualizacaoDeCabo { Tabela = "Cabos", Coluna = coluna, Valor = Vazio });
            atualizacoes.Add(new AtualizacaoDeCabo { Tabela = "Cabos4", Coluna = coluna, Valor = Vazio });
            atualizacoes.Add(new AtualizacaoDeCabo { Tabela = "Cabos", Coluna = "Alarme", Valor = "0", SemFiltro = true });
            return atualizacoes;
        }
    }
}

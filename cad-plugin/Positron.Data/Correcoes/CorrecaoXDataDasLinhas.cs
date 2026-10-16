namespace Positron.Data.Correcoes
{
    /// <summary>
    /// <c>correcaoLines</c> — a quarta das cinco correções automáticas do <c>IniciarDWG</c>
    /// (<c>Correcao.cs:480</c>).
    ///
    /// Percorre o ModelSpace e, em cada <c>Line</c>:
    ///
    /// - com XData <c>CONEXAO</c> → <c>LimpaXData(linha, "CONEXAO")</c>
    ///   (<c>Correcao.cs:937</c>: o buffer do app name vira um **registro único** com o próprio nome —
    ///   some o conteúdo, fica a marca);
    /// - sem ele, com XData <c>INTERLIGACAO</c> → <c>LimpaXData(linha, "INTERLIGACAO")</c>.
    ///
    /// É uma limpeza **de migração**: numa versão antiga o trecho de conexão e o de interligação
    /// chegaram a ser gravados também em <c>Line</c> (hoje são da polilinha), e a correção tira o
    /// XData que sobrou. Como toda correção do <c>IniciarDWG</c>, ela roda **uma vez por desenho** —
    /// a marca é a nº 4 do XData <c>CORRECAO</c> (<see cref="MarcasDeCorrecao.Linhas"/>).
    ///
    /// Quem varre o ModelSpace e escreve é o adapter
    /// (<c>Positron.Plugin.Correcoes.XDataDasLinhasDoDesenho</c>).
    /// </summary>
    public static class CorrecaoXDataDasLinhas
    {
        /// <summary>O app name que a <c>Line</c> não deve ter (o primeiro que o original testa).</summary>
        public const string Conexao = "CONEXAO";

        /// <summary>O app name do segundo teste do original.</summary>
        public const string Interligacao = "INTERLIGACAO";

        /// <summary>
        /// Qual app name sai da linha: <c>CONEXAO</c> quando ela o tem, senão <c>INTERLIGACAO</c>
        /// quando tem esse, senão <c>null</c> (linha sem nada a limpar).
        /// </summary>
        public static string QualLimpar(bool temConexao, bool temInterligacao)
        {
            if (temConexao)
            {
                return Conexao;
            }

            return temInterligacao ? Interligacao : null;
        }
    }
}

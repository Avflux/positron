using Positron.Data.Configuracao;

namespace Positron.Plugin
{
    /// <summary>
    /// A configuração **efetiva** do recoder dentro do CAD: o
    /// <c>ConfiguracaoPositron.Carregar(arquivo, ambiente, desenho)</c>, com o **desenho** no
    /// meio — <c>padrão &lt; arquivo &lt; desenho &lt; ambiente</c>.
    ///
    /// É o caminho que o <c>IniciarDWG</c> do reverso faz ao abrir o desenho (ler o XData
    /// <c>Eletron</c>/<c>Config</c> e preencher o <c>DeclaracoesGeral.Conf</c>): os comandos
    /// do plugin passam a ler daqui em vez de só do <c>.ini</c>/ambiente. O ambiente
    /// <c>POSITRON_*</c> continua vencendo, para o harness não depender do desenho; e sem
    /// desenho ativo (ou sem o XData) a leitura cai no arquivo, como antes.
    /// </summary>
    internal static class ConfiguracaoEfetiva
    {
        /// <summary>A configuração efetiva do desenho ativo (arquivo + desenho + ambiente).</summary>
        internal static ConfiguracaoPositron Carregar()
        {
            return Carregar(Configuracao.ConfiguracaoDoDesenho.Ler());
        }

        /// <summary>
        /// A configuração efetiva com o caderno já lido — para quem lê o XData uma vez só
        /// (o <c>ELETCFG</c>, que precisa do caderno também para regravar).
        /// </summary>
        internal static ConfiguracaoPositron Carregar(ConfiguracaoDoCaderno desenho)
        {
            return ConfiguracaoPositron.Carregar(
                ConfiguracaoPositron.ArquivoPadrao,
                ConfiguracaoPositron.VariaveisDeAmbiente(),
                desenho);
        }
    }
}

using System;

namespace Positron.Data.Licenca
{
    /// <summary>Resultado de uma verificação de licença.</summary>
    public sealed class ResultadoLicenca
    {
        public bool Autorizado { get; set; }

        public string Mensagem { get; set; }

        public static ResultadoLicenca Ok(string mensagem = null)
        {
            return new ResultadoLicenca { Autorizado = true, Mensagem = mensagem };
        }

        public static ResultadoLicenca Negado(string mensagem)
        {
            return new ResultadoLicenca { Autorizado = false, Mensagem = mensagem };
        }
    }

    /// <summary>
    /// Ponto de entrada do licenciamento — o encaixe para o provedor que o produto
    /// escolher.
    ///
    /// O original tinha **três** provedores (`cCheckLicRockey`, `cCheckElecKey` e
    /// `cCheckNuvem`, este com `cDadosSQLServerLicenca`), todos chamados na carga do
    /// plugin (`myEletron`/`frmCarregaEL`). O recoder **não** reconstrói as
    /// credenciais do reverso: define só o encaixe, com um provedor de
    /// desenvolvimento que autoriza tudo, e o comando pergunta antes de rodar.
    ///
    /// Assim a decisão de Etapa 9 não bloqueia nada: quando houver provedor, basta
    /// atribuir <see cref="Provedor"/> na carga do plugin — nenhum comando muda.
    /// </summary>
    public static class ServicoDeLicenca
    {
        private static ILicenca _provedor = new LicencaDeDesenvolvimento();

        /// <summary>Provedor ativo (por padrão, o de desenvolvimento).</summary>
        public static ILicenca Provedor
        {
            get { return _provedor; }
            set { _provedor = value ?? new LicencaDeDesenvolvimento(); }
        }

        /// <summary>Pergunta ao provedor. Nunca lança: falha de licença vira negativa.</summary>
        public static ResultadoLicenca Verificar()
        {
            try
            {
                return _provedor.Verificar();
            }
            catch (Exception erro)
            {
                return ResultadoLicenca.Negado("falha ao verificar a licença: " + erro.Message);
            }
        }

        /// <summary>Volta ao provedor de desenvolvimento (usado nos testes).</summary>
        public static void UsarDesenvolvimento()
        {
            _provedor = new LicencaDeDesenvolvimento();
        }
    }

    /// <summary>O que um provedor de licença precisa responder.</summary>
    public interface ILicenca
    {
        ResultadoLicenca Verificar();
    }

    /// <summary>
    /// Provedor de desenvolvimento: autoriza sempre e diz isso na mensagem. É o
    /// padrão — o recorte atual roda sem licença, como o plano descreve.
    /// </summary>
    public sealed class LicencaDeDesenvolvimento : ILicenca
    {
        public ResultadoLicenca Verificar()
        {
            return ResultadoLicenca.Ok("licença de desenvolvimento (sem provedor configurado)");
        }
    }
}

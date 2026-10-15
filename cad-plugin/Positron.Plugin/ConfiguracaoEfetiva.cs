using System;
using System.Collections.Generic;
using System.IO;
using Positron.Data;
using Positron.Data.Configuracao;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
#else
using ZwSoft.ZwCAD.ApplicationServices;
#endif

namespace Positron.Plugin
{
    /// <summary>
    /// A configuração **efetiva** do desenho ativo — o <c>DeclaracoesGeral.Conf</c> e o
    /// <c>arqAtivo</c> que o <c>Iniciar.IniciarDWG</c> do original monta a cada desenho ativado
    /// (<c>Iniciar.cs:61-195</c>):
    ///
    /// - os valores do XData do desenho, ou os padrões do original sem ele
    ///   (<see cref="Configuracao.ConfiguracaoDoDesenho.LerOuPadrao"/>) — o banco do projeto é o
    ///   <c>DirProjeto</c> do desenho, nunca o de outro projeto;
    /// - o **índice do DWG** pelo nome do arquivo na tabela <c>DWG</c> do banco
    ///   (<c>cDadosAccess.carregaDadosDWG</c>, <c>cDadosAccess.cs:15-62</c>);
    /// - por cima, as variáveis <c>POSITRON_*</c>, que existem **só para o harness**.
    ///
    /// Não há cache: cada comando lê o desenho que está ativo agora.
    /// </summary>
    internal static class ConfiguracaoEfetiva
    {
        /// <summary>A configuração efetiva do desenho ativo.</summary>
        internal static ConfiguracaoPositron Carregar()
        {
            return Carregar(Configuracao.ConfiguracaoDoDesenho.LerOuPadrao());
        }

        /// <summary>A configuração efetiva com o caderno já lido (quem precisa dele também para regravar).</summary>
        internal static ConfiguracaoPositron Carregar(ConfiguracaoDoCaderno desenho)
        {
            IDictionary<string, string> ambiente = ConfiguracaoPositron.VariaveisDeAmbiente();
            ConfiguracaoPositron configuracao = ConfiguracaoPositron.Carregar(ambiente, desenho);
            if (!ambiente.ContainsKey(ConfiguracaoPositron.VariavelDwg))
            {
                configuracao.Dwg = IndiceDoDwg(configuracao.Banco);
            }

            return configuracao;
        }

        /// <summary>
        /// O <c>carregaDadosDWG</c>: o nome do desenho ativo (o arquivo sem a extensão, o
        /// <c>Geral.extraiNomeCaminhoDwg</c>) procurado sem diferenciar maiúsculas na tabela
        /// <c>DWG</c>; 0 quando o banco não é válido ou o desenho não está cadastrado.
        /// </summary>
        internal static int IndiceDoDwg(string bancoDoProjeto)
        {
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null || string.IsNullOrEmpty(bancoDoProjeto) || !File.Exists(bancoDoProjeto))
            {
                return 0;
            }

            // O plugin só lê o banco SQLite; o Access (`Conf.Banco = "A"`, `.mdb`/`.accdb`) do original
            // ainda não tem leitor (rodada 180, *Falta*).
            if (EhAccess(bancoDoProjeto))
            {
                return 0;
            }

            string nome = NomeDoDwg(documento.Name);
            try
            {
                foreach (KeyValuePair<int, string> dwg in new ProjectStore(bancoDoProjeto).LerNomesDeDwgs())
                {
                    if (string.Equals(dwg.Value, nome, StringComparison.OrdinalIgnoreCase))
                    {
                        return dwg.Key;
                    }
                }
            }
            catch (Exception erro)
            {
                Plugin.Escrever("O cadastro de DWGs não pôde ser lido do banco do projeto — " + erro.Message);
            }

            return 0;
        }

        /// <summary>O banco do projeto é um arquivo do Access (<c>.mdb</c>/<c>.accdb</c>).</summary>
        internal static bool EhAccess(string bancoDoProjeto)
        {
            string extensao = Path.GetExtension(bancoDoProjeto ?? string.Empty);
            return string.Equals(extensao, ".mdb", StringComparison.OrdinalIgnoreCase)
                || string.Equals(extensao, ".accdb", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>O <c>extraiNomeCaminhoDwg</c>: o último trecho do caminho sem os 4 últimos caracteres.</summary>
        internal static string NomeDoDwg(string caminhoDoDocumento)
        {
            string arquivo = Path.GetFileName(caminhoDoDocumento ?? string.Empty);
            return arquivo.Length > 4 ? arquivo.Substring(0, arquivo.Length - 4) : string.Empty;
        }
    }
}

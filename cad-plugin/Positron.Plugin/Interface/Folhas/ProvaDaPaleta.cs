using System;
using System.Collections.Generic;
using Positron.Data.Paginas;

namespace Positron.Plugin.Interface.Folhas
{
    /// <summary>
    /// A **prova do caminho da paleta** — o que o comando <c>pzFolhas</c> roda. Monta o
    /// <see cref="FolhasControle"/> e chama o **mesmo** handler que o clique do menu e a tecla
    /// chamam, sem passar pela interface: é o caminho do usuário sem o clique (que um script não dá).
    ///
    /// A entrada é toda do harness, e **só** daqui: <c>POSITRON_FOLHA_ACAO</c> (<c>nova</c>,
    /// <c>inserir:N</c>, <c>apagar</c>, <c>multiselecao</c>; sem ela o comando só despeja o estado),
    /// <c>POSITRON_FOLHA_SELECAO</c> (a linha selecionada; o padrão é <c>POSITRON_PAGINA</c>) e
    /// <c>POSITRON_FOLHA_SELECIONADAS</c> (as linhas selecionadas, separadas por vírgula).
    /// </summary>
    internal static class ProvaDaPaleta
    {
        internal static string Executar()
        {
            try
            {
                FolhasControle controle = new FolhasControle();
                int paginas = controle.Carregar();

                string selecao = Environment.GetEnvironmentVariable("POSITRON_FOLHA_SELECAO");
                if (string.IsNullOrEmpty(selecao))
                {
                    selecao = Environment.GetEnvironmentVariable("POSITRON_PAGINA");
                }

                string selecionadas = Environment.GetEnvironmentVariable("POSITRON_FOLHA_SELECIONADAS");
                List<string> linhas = new List<string>();
                if (!string.IsNullOrEmpty(selecionadas))
                {
                    foreach (string parte in selecionadas.Split(','))
                    {
                        if (!string.IsNullOrEmpty(parte.Trim()))
                        {
                            linhas.Add(parte.Trim());
                        }
                    }

                    // Mais de uma página pedida é o usuário que ligou a `Multiseleção` no menu para
                    // poder marcar as linhas (no `Inserir` de colunas ou no `Apagar Páginas`).
                    if (linhas.Count > 1)
                    {
                        controle.Multiselecao = true;
                    }
                }
                else if (!string.IsNullOrEmpty(selecao))
                {
                    linhas.Add(selecao);
                }

                int achadas = controle.Selecionar(linhas);

                string acao = (Environment.GetEnvironmentVariable("POSITRON_FOLHA_ACAO") ?? string.Empty).Trim().ToLowerInvariant();
                string resultado = "(sem ação: só o estado da grade)";

                if (acao == "multiselecao")
                {
                    controle.Multiselecao = true;
                    resultado = controle.NovaPagina();
                }
                else if (acao == "nova")
                {
                    resultado = controle.NovaPagina();
                }
                else if (acao == "apagar")
                {
                    resultado = controle.ApagarSelecionadas();
                }
                else if (acao.StartsWith("inserir", StringComparison.Ordinal))
                {
                    int indice = 1;
                    int doisPontos = acao.IndexOf(':');
                    if (doisPontos > 0)
                    {
                        int.TryParse(acao.Substring(doisPontos + 1), out indice);
                    }

                    resultado = controle.InserirColuna(indice);
                }

                return "pzFolhas: " + controle.Paginas().Count + " página(s) na grade " + Lista(controle.Paginas())
                    + " (antes: " + paginas + ")"
                    + "; seleção pedida " + Lista(linhas) + " (" + achadas + " achada(s))"
                    + "; selecionada depois " + Lista(controle.Selecionadas())
                    + "; ação \"" + (acao.Length == 0 ? "(nenhuma)" : acao) + "\" → " + resultado
                    + "; " + DescreverColunas(controle.Colunas());
            }
            catch (Exception erro)
            {
                return "pzFolhas: falhou — " + erro.GetType().Name + ": " + erro.Message;
            }
        }

        private static string Lista(IReadOnlyList<string> nomes)
        {
            List<string> limpos = new List<string>();
            for (int i = 0; i < nomes.Count; i++)
            {
                limpos.Add(nomes[i].Length == 0 ? "(vazio)" : nomes[i]);
            }

            return "[" + string.Join(" | ", limpos.ToArray()) + "]";
        }

        private static string DescreverColunas(IReadOnlyList<ColunaDoFormato> colunas)
        {
            List<string> itens = new List<string>();
            foreach (ColunaDoFormato coluna in colunas)
            {
                itens.Add(coluna.Visivel ? coluna.Tipo : ("ELET" + coluna.Indice + "_ausente"));
            }

            return "colunas do formato " + (ColunasDoFormato.TemAlguma(colunas) ? "visíveis" : "nenhuma")
                + " [" + string.Join(" | ", itens.ToArray()) + "]";
        }
    }
}

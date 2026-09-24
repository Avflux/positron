using System;
using System.Collections.Generic;
using Positron.Data.Interface;

namespace Positron.Plugin.Interface
{
    /// <summary>
    /// Abre a janela de um **comando do original** pelo nome dele: o <c>GERDWG</c> abre a
    /// <c>frmGerenciadorDWG</c>, o <c>DEF</c> a <c>frmDefinicao</c> — exatamente como no
    /// <c>Eletron4Z</c>, onde o corpo do comando é só o <c>new frmX()</c> e quem trabalha é a janela.
    ///
    /// O caminho é um só para todos: o comando gerado (<c>ComandosDoOriginal.Gerado.cs</c>) diz o
    /// **nome**, o mapa do reverso (<see cref="ComandosDoReverso"/>) diz a **tela**, e aqui a
    /// janela é montada e aberta pelo <see cref="RenderizadorDeTelas"/> (modeless, dentro do CAD).
    /// A variante — o comando que abre a mesma tela com um argumento
    /// (<c>new frmRelatorio_DICemig(3)</c>) — **não** é registrada como comando: abrir a tela padrão
    /// no lugar dela seria mentir, então ela fica no mapa, com a construção, à espera da rodada que
    /// portar o relatório.
    ///
    /// Nunca lança: um comando que estoura derruba a linha de comando do CAD.
    /// </summary>
    internal static class JanelasDoOriginal
    {
        /// <summary>Abre a(s) janela(s) do comando e devolve a linha de resumo.</summary>
        internal static string Abrir(string nome)
        {
            Comando comando = ComandosDoReverso.Buscar(nome);
            if (comando == null)
            {
                return nome + ": não há esse comando no mapa do reverso ("
                    + ComandosDoReverso.Quantidade + " comandos; ver docs/reverso-comandos.txt).";
            }

            if (!comando.AbreJanela)
            {
                return nome + ": o mapa do reverso não liga esse comando a nenhuma janela.";
            }

            try
            {
                List<string> linhas = new List<string>();
                foreach (Janela janela in comando.Janelas)
                {
                    linhas.Add(RenderizadorDeTelas.Abrir(janela.Nome, comando.Nome));
                }

                return string.Join(" | ", linhas.ToArray());
            }
            catch (Exception erro)
            {
                return nome + ": falhou — " + erro.Message + ".";
            }
        }

        /// <summary>
        /// O que o comando do original faz quando a janela não abre: a linha de resumo para o
        /// comando que ainda **não** é do plugin (usada pelo seletor e pelo diagnóstico).
        /// </summary>
        internal static string Descrever(Comando comando)
        {
            if (comando == null)
            {
                return string.Empty;
            }

            if (!comando.AbreJanela)
            {
                return comando.Nome + " não abre janela (a regra dele é de desenho).";
            }

            List<string> construcoes = new List<string>();
            foreach (Janela janela in comando.Janelas)
            {
                construcoes.Add(janela.Construcao);
            }

            return comando.Nome + " — " + string.Join(" ", construcoes.ToArray());
        }
    }
}

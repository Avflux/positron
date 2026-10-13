using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Positron.Data;
using Positron.Data.Configuracao;

namespace Positron.Plugin.Interface.Telas
{
    /// <summary>
    /// A base das **três telas de compilação** do original — <c>frmCompilarFiacao</c>,
    /// <c>frmCompilarInterligacao</c> e <c>frmCompilarJumperExt</c>. As três têm a mesma casca (a
    /// grade das revisões, a grade de erros e os quatro botões Analisar/Salvar/Apagar/ApagarComp) e a
    /// **regra de cada uma já existe** no recoder: são os pipelines <c>FIA</c>, <c>INT</c> e
    /// <c>JMP</c>, medidos no desenho real desde as primeiras rodadas.
    ///
    /// O que fica ligado (e por quê):
    ///
    /// - <c>btAnalisar</c> roda o pipeline da tela com a revisão do <c>tbRevisao</c> (vazia = a da
    ///   configuração, <c>POSITRON_REVISAO</c>) e recarrega a grade de erros — é o "Analisar" do
    ///   original, que é o mesmo caminho do comando equivalente;
    /// - <c>dgERROS</c> abre com os **problemas da revisão** (a mesma lista que o <c>VERIF</c> e o
    ///   <c>ELETREL</c> usam, um por linha) — o original só a preenche depois do Analisar e com as
    ///   **páginas** onde ele desenhou um bloco de erro (o recoder não desenha; a diferença está
    ///   registrada no RUNBOOK);
    /// - <c>dgRevisao</c> abre com as revisões que já têm compilação no banco para o DWG ativo
    ///   (<see cref="ProjectStore.LerRevisoes"/>) — o original lê criador e data do Access, colunas
    ///   que o schema do SQLite não tem por revisão, então só a primeira coluna é preenchida.
    ///
    /// O que entra **desabilitado**, com o motivo na dica (o mesmo padrão do menu das folhas): o
    /// <c>btSalvar</c> (o recoder grava na mesma passada do Analisar — o original separa os dois
    /// passos), o <c>btApagar</c> (destrutivo: apaga a compilação da revisão nas tabelas) e o
    /// <c>btApagarComp</c> (o original desenha blocos <c>ErroFiacao</c> no desenho e este botão os
    /// apaga — o recoder não desenha erro no desenho).
    ///
    /// **Como a tela é medida num script:** não há clique, então <c>POSITRON_ANALISAR=1</c> roda a
    /// **mesma** análise do <c>btAnalisar</c> ao abrir a tela (o gancho do harness, como o
    /// <c>POSITRON_JANELA</c> do seletor) e a linha <c>COMPILAR:</c> resume o que a ligação leu.
    /// </summary>
    internal abstract class LigacaoDeCompilacao : ILigacaoDeTela
    {
        private const string MotivoSalvar =
            "Salvar: o recoder grava na mesma passada do Analisar (o original separa analisar de salvar)";

        private const string MotivoApagar =
            "Apagar: destrutivo — apaga a compilação da revisão (Interligacao4/Portas4I/Bornes4I/Cabos4/Veias4)";

        private const string MotivoApagarComp =
            "ApagarComp: o original desenha blocos ErroFiacao no desenho e este botão os apaga; o recoder não desenha";

        /// <summary>As dicas ficam num único componente vivo (um <c>ToolTip</c> por botão morreria no GC).</summary>
        private static ToolTip _dicas;

        public abstract string NomeDaTela { get; }

        /// <summary>O comando do recoder que o <c>Analisar</c> desta tela executa.</summary>
        protected abstract string Comando { get; }

        /// <summary>Roda o pipeline da tela com a revisão pedida e devolve a linha de resumo.</summary>
        protected abstract string Executar(string revisao);

        public void Preencher(Form janela)
        {
            if (janela == null)
            {
                return;
            }

            DataGridView revisoes = ControlesDaTela.Achar<DataGridView>(janela, "dgRevisao");
            DataGridView erros = ControlesDaTela.Achar<DataGridView>(janela, "dgERROS");
            Button analisar = ControlesDaTela.Achar<Button>(janela, "btAnalisar");
            TextBox campo = ControlesDaTela.Achar<TextBox>(janela, "tbRevisao");

            Desabilitar(ControlesDaTela.Achar<Button>(janela, "btSalvar"), MotivoSalvar);
            Desabilitar(ControlesDaTela.Achar<Button>(janela, "btApagar"), MotivoApagar);
            Desabilitar(ControlesDaTela.Achar<Button>(janela, "btApagarComp"), MotivoApagarComp);

            if (analisar != null)
            {
                analisar.Click += (origem, evento) => Analisar(erros, campo);
            }

            ConfiguracaoPositron config = ConfiguracaoPositron.Carregar();

            // O campo abre com a revisão da configuração (o original abre vazio): é o valor que o
            // Analisar usa — e o que o harness mede, já que um script não digita no campo.
            if (campo != null && string.IsNullOrEmpty(campo.Text))
            {
                campo.Text = config.Revisao ?? string.Empty;
            }

            string revisao = RevisaoDoCampo(campo, config);
            int quantas = CarregarRevisoes(revisoes, config);
            int problemas = CarregarErros(erros, config, revisao);

            Plugin.Escrever("COMPILAR: " + NomeDaTela + " — Analisar ligado no " + Comando
                + " (revisão \"" + revisao + "\"); " + quantas + " revisão(ões) na grade; "
                + problemas + " problema(s) na grade de erros; desabilitados: Salvar, Apagar e ApagarComp.");

            if (AnalisarAoAbrir())
            {
                Analisar(erros, campo);
            }
        }

        /// <summary>O que o clique do <c>btAnalisar</c> faz: roda o pipeline e recarrega os erros.</summary>
        private void Analisar(DataGridView erros, TextBox campo)
        {
            ConfiguracaoPositron config = ConfiguracaoPositron.Carregar();
            string revisao = RevisaoDoCampo(campo, config);
            Plugin.Escrever(Executar(revisao));
            CarregarErros(erros, config, revisao);
        }

        private static string RevisaoDoCampo(TextBox campo, ConfiguracaoPositron config)
        {
            string digitada = campo == null ? null : campo.Text;
            if (string.IsNullOrEmpty(digitada) || string.IsNullOrEmpty(digitada.Trim()))
            {
                return config.Revisao ?? string.Empty;
            }

            return digitada.Trim();
        }

        /// <summary>As revisões do DWG ativo que já têm compilação no banco (a grade do original).</summary>
        private static int CarregarRevisoes(DataGridView grade, ConfiguracaoPositron config)
        {
            if (grade == null)
            {
                return 0;
            }

            grade.Rows.Clear();
            if (string.IsNullOrEmpty(config.Banco))
            {
                return 0;
            }

            try
            {
                // As colunas do mapa são (Revisão, Data, Criador); o original adiciona
                // (revisao, criador, data) — aqui cada valor vai para a coluna do seu nome.
                IReadOnlyList<RevisaoDoDwg> revisoes = new ProjectStore(config.Banco).LerRevisoes(config.Dwg);
                foreach (RevisaoDoDwg revisao in revisoes)
                {
                    grade.Rows.Add(revisao.Revisao, revisao.Data, revisao.Criador);
                }

                return revisoes.Count;
            }
            catch (Exception erro)
            {
                Plugin.Escrever("COMPILAR: as revisões do DWG não vieram do banco — " + erro.Message);
                return 0;
            }
        }

        /// <summary>
        /// Os problemas da revisão na grade — a **mesma** lista do <c>VERIF</c>/<c>ELETREL</c>
        /// (<c>Comandos.VerificarRevisao</c>), um por linha. O original mostra as páginas onde
        /// desenhou um bloco de erro; o recoder não desenha erro no desenho, então mostra o problema.
        /// </summary>
        private static int CarregarErros(DataGridView grade, ConfiguracaoPositron config, string revisao)
        {
            if (grade == null)
            {
                return 0;
            }

            grade.Rows.Clear();
            if (string.IsNullOrEmpty(config.Banco))
            {
                return 0;
            }

            try
            {
                int fios;
                int trechos;
                int portas;
                int bornes;
                int contatos;
                List<Problema> problemas = Positron.Plugin.Comandos.VerificarRevisao(
                    config.Banco, config.Dwg, revisao, out fios, out trechos, out portas, out bornes, out contatos);

                foreach (Problema problema in problemas)
                {
                    grade.Rows.Add(Linha(problema));
                }

                return problemas.Count;
            }
            catch (Exception erro)
            {
                Plugin.Escrever("COMPILAR: os problemas da revisão não vieram — " + erro.Message);
                return 0;
            }
        }

        /// <summary>Uma linha da grade: o problema no formato do relatório (área/tipo/tabela/onde/detalhe).</summary>
        private static string Linha(Problema problema)
        {
            if (problema == null)
            {
                return string.Empty;
            }

            string onde = string.IsNullOrEmpty(problema.Identificador) ? string.Empty : " [" + problema.Identificador + "]";
            string detalhe = string.IsNullOrEmpty(problema.Detalhe) ? string.Empty : " — " + problema.Detalhe;
            return problema.Area + " / " + problema.Tipo + " (" + problema.Tabela + ")" + onde + detalhe;
        }

        private static void Desabilitar(Button botao, string motivo)
        {
            if (botao == null)
            {
                return;
            }

            botao.Enabled = false;
            botao.Tag = motivo;
            if (_dicas == null)
            {
                _dicas = new ToolTip();
            }

            _dicas.SetToolTip(botao, motivo);
        }

        /// <summary>
        /// O gancho do harness: um script não clica no botão, então <c>POSITRON_ANALISAR=1</c> roda a
        /// **mesma** análise do clique ao abrir a tela (receita no RUNBOOK).
        /// </summary>
        private static bool AnalisarAoAbrir()
        {
            string valor = Environment.GetEnvironmentVariable("POSITRON_ANALISAR");
            return !string.IsNullOrEmpty(valor) && valor != "0";
        }
    }
}

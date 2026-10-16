using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Positron.Data;
using Positron.Data.Configuracao;

namespace Positron.Plugin.Interface.Telas
{
    /// <summary>
    /// A base das **três telas de compilação** do original — <c>frmCompilarFiacao</c>,
    /// <c>frmCompilarInterligacao</c> e <c>frmCompilarJumperExt</c> —, com o construtor de
    /// <c>frmCompilarJumperExt.cs:461</c> (os outros dois são iguais): banco inválido ou DWG sem
    /// cadastro → <c>MsgBox</c> 331 e a tela não abre; <c>cbPreservar</c> marcado; dicas dos botões
    /// Analisar/Apagar/Salvar pelas mMensagens; <c>btSalvar</c> desabilitado; <c>dgRevisao</c> com
    /// Revisão | Criador | Data (<c>formataDGRevisao :2422</c>, larguras 2/8, 2/8, 4/8 de largura − 22);
    /// <c>dgERROS</c> vazia e sem coluna (<c>formataDGErros(false) :2479</c>).
    ///
    /// <c>btAnalisar</c> roda o pipeline do recoder (<c>FIA</c>/<c>INT</c>/<c>JMP</c>) com a revisão
    /// digitada — vazia: <c>MsgBox</c> 761 — e então mostra a coluna "Erros" (755) com os problemas
    /// da revisão. O original mostra aí as páginas onde desenhou um bloco de erro; o recoder não
    /// desenha, então lista o problema (diferença registrada no RUNBOOK).
    ///
    /// <c>btApagar</c> e <c>btApagarComp</c> ficam desabilitados: a regra de apagar a revisão
    /// (mMensagem 760, <c>RemoveRevisaoTabelaParaDWG</c>) e de apagar os blocos de erro ainda não
    /// foi portada (fila do <c>ESTADO.md</c>).
    ///
    /// **Harness:** um script não clica nem digita, então <c>POSITRON_ANALISAR=1</c> preenche o campo
    /// com a revisão da configuração (<c>POSITRON_REVISAO</c>) e roda o mesmo caminho do clique ao abrir.
    /// </summary>
    internal abstract class LigacaoDeCompilacao : ILigacaoDeTela
    {
        /// <summary>As dicas ficam num único componente vivo (um <c>ToolTip</c> por botão morreria no GC).</summary>
        private static ToolTip _dicas;

        public abstract string NomeDaTela { get; }

        /// <summary>O comando do recoder que o <c>Analisar</c> desta tela executa.</summary>
        protected abstract string Comando { get; }

        /// <summary>A mMensagem da dica do <c>btAnalisar</c> desta tela.</summary>
        protected abstract string DicaAnalisar { get; }

        /// <summary>A mMensagem da dica do <c>btSalvar</c> desta tela.</summary>
        protected abstract string DicaSalvar { get; }

        /// <summary>Roda o pipeline da tela com a revisão pedida e devolve a linha de resumo.</summary>
        protected abstract string Executar(string revisao);

        public void Preencher(Form janela)
        {
            if (janela == null)
            {
                return;
            }

            // Construtor do original: `clsAuxiliar.BancoValido()` e, sem o DWG cadastrado, a mMensagem 331.
            if (!InicioDoDesenho.BancoValido(true))
            {
                janela.Dispose();
                return;
            }

            ConfiguracaoPositron config = ConfiguracaoEfetiva.Carregar();
            if (config.Dwg == 0)
            {
                Aviso.MsgBox("Este arquivo ainda não foi cadastrado no banco do projeto!", string.Empty);
                janela.Dispose();
                return;
            }

            DataGridView revisoes = ControlesDaTela.Achar<DataGridView>(janela, "dgRevisao");
            DataGridView erros = ControlesDaTela.Achar<DataGridView>(janela, "dgERROS");
            Button analisar = ControlesDaTela.Achar<Button>(janela, "btAnalisar");
            Button apagar = ControlesDaTela.Achar<Button>(janela, "btApagar");
            Button salvar = ControlesDaTela.Achar<Button>(janela, "btSalvar");
            Button apagarComp = ControlesDaTela.Achar<Button>(janela, "btApagarComp");
            TextBox campo = ControlesDaTela.Achar<TextBox>(janela, "tbRevisao");
            CheckBox preservar = ControlesDaTela.Achar<CheckBox>(janela, "cbPreservar");

            if (preservar != null)
            {
                preservar.Checked = true;
            }

            if (_dicas == null)
            {
                _dicas = new ToolTip();
            }

            Dica(analisar, DicaAnalisar);
            Dica(apagar, "Apagar revisão");
            Dica(salvar, DicaSalvar);

            if (salvar != null)
            {
                salvar.Enabled = false;
            }

            if (apagar != null)
            {
                apagar.Enabled = false;
            }

            if (apagarComp != null)
            {
                apagarComp.Enabled = false;
            }

            if (erros != null)
            {
                erros.Rows.Clear();
                erros.Columns.Clear();
            }

            CarregarRevisoes(revisoes, config);

            if (analisar != null)
            {
                analisar.Click += (origem, evento) => Analisar(erros, campo);
            }

            if (AnalisarAoAbrir())
            {
                if (campo != null && string.IsNullOrEmpty(campo.Text))
                {
                    campo.Text = config.Revisao ?? string.Empty;
                }

                Analisar(erros, campo);
            }
        }

        /// <summary>O que o clique do <c>btAnalisar</c> faz: pede a revisão, roda o pipeline e mostra os erros.</summary>
        private void Analisar(DataGridView erros, TextBox campo)
        {
            string revisao = campo == null ? string.Empty : (campo.Text ?? string.Empty).Trim();
            if (revisao.Length == 0)
            {
                Aviso.MsgBox("Informe um número de revisão!", string.Empty);
                return;
            }

            ConfiguracaoPositron config = ConfiguracaoEfetiva.Carregar();
            Plugin.Escrever(Executar(revisao));
            CarregarErros(erros, config, revisao);
        }

        private static void Dica(Button botao, string texto)
        {
            if (botao != null)
            {
                _dicas.SetToolTip(botao, texto);
            }
        }

        /// <summary>
        /// A grade do original (<c>formataDGRevisao</c> e <c>CarregaDGRevisao</c>): Revisão | Criador |
        /// Data, as revisões do DWG ativo que já têm compilação no banco.
        /// </summary>
        private static void CarregarRevisoes(DataGridView grade, ConfiguracaoPositron config)
        {
            if (grade == null)
            {
                return;
            }

            grade.Rows.Clear();
            grade.Columns.Clear();
            foreach (string titulo in new[] { "Revisão", "Criador", "Data" })
            {
                int indice = grade.Columns.Add("", titulo);
                grade.Columns[indice].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            float util = grade.Width - 22;
            grade.Columns[0].Width = (int)Math.Round(util * 2f / 8f);
            grade.Columns[1].Width = (int)Math.Round(util * 2f / 8f);
            grade.Columns[2].Width = (int)Math.Round(util * 4f / 8f);

            try
            {
                IReadOnlyList<RevisaoDoDwg> revisoes = new ProjectStore(config.Banco).LerRevisoes(config.Dwg);
                foreach (RevisaoDoDwg revisao in revisoes)
                {
                    grade.Rows.Add(revisao.Revisao, revisao.Criador, revisao.Data);
                }
            }
            catch (Exception erro)
            {
                Aviso.MsgBox(erro.Message, "Elétron");
            }
        }

        /// <summary>
        /// A coluna "Erros" (<c>formataDGErros(true)</c>, mMensagem 755) com os problemas da revisão —
        /// a **mesma** lista do <c>VERIF</c>/<c>ELETREL</c> (<c>Comandos.VerificarRevisao</c>), um por linha.
        /// </summary>
        private static void CarregarErros(DataGridView grade, ConfiguracaoPositron config, string revisao)
        {
            if (grade == null)
            {
                return;
            }

            grade.Rows.Clear();
            grade.Columns.Clear();
            int coluna = grade.Columns.Add("", "Erros");
            grade.Columns[coluna].SortMode = DataGridViewColumnSortMode.NotSortable;
            grade.Columns[coluna].Width = grade.Width - 4;

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
            }
            catch (Exception erro)
            {
                Aviso.MsgBox(erro.Message, "Elétron");
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

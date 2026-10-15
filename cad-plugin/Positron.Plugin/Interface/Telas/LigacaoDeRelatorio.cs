using System;
using System.Windows.Forms;
using Positron.Data;
using Positron.Data.Configuracao;

namespace Positron.Plugin.Interface.Telas
{
    /// <summary>
    /// A base das **telas de relatório** do original — <c>frmRelatorio_Veias</c> (<c>LVEI</c>) e
    /// <c>frmRelatorio_Materiais</c> (<c>EXPLM</c>), as duas primeiras da frente. As duas giram em
    /// volta das tabelas que a **projeção** já grava (<c>Cabos4</c>/<c>Veias4</c>/<c>Interligacao4</c> e
    /// a <c>ListaMateriais</c>) e do catálogo (<c>Materiais</c>), e no original as duas leem o banco na
    /// própria rotina de carga.
    ///
    /// O que fica **ligado**: a grade com as linhas da **regra do recoder** (as mesmas que os relatórios
    /// do app já montam e medem) e os botões cuja regra existe. O que entra **desabilitado, com o
    /// motivo na dica**: a exportação (Excel/DWG, interop) e tudo que no original é edição/ordenação
    /// dentro da tela.
    ///
    /// **Como a tela é medida num script** (não há clique): <c>POSITRON_REL_PAINEL</c> escolhe o painel
    /// (as duas telas) e <c>POSITRON_REL_REVISAO</c> escolhe a revisão (a <c>LVEI</c>); sem elas, a tela
    /// abre no primeiro item das duas colunas, como o original abre com a primeira linha selecionada.
    /// </summary>
    internal abstract class LigacaoDeRelatorio : ILigacaoDeTela
    {
        /// <summary>As dicas ficam num único componente vivo (um <c>ToolTip</c> por botão morreria no GC).</summary>
        private static ToolTip _dicas;

        public abstract string NomeDaTela { get; }

        public abstract void Preencher(Form janela);

        /// <summary>A configuração viva (arquivo &lt; ambiente) — o banco e o DWG ativo saem dela.</summary>
        protected static ConfiguracaoPositron Configuracao()
        {
            return ConfiguracaoEfetiva.Carregar();
        }

        /// <summary>O painel pedido pelo harness (<c>POSITRON_REL_PAINEL</c>), ou <c>0</c>.</summary>
        protected static int PainelPedido()
        {
            int painel;
            string valor = Environment.GetEnvironmentVariable("POSITRON_REL_PAINEL");
            return !string.IsNullOrEmpty(valor) && int.TryParse(valor, out painel) ? painel : 0;
        }

        /// <summary>A revisão pedida pelo harness (<c>POSITRON_REL_REVISAO</c>), ou <c>null</c>.</summary>
        protected static string RevisaoPedida()
        {
            string valor = Environment.GetEnvironmentVariable("POSITRON_REL_REVISAO");
            return string.IsNullOrEmpty(valor) ? null : valor;
        }

        /// <summary>
        /// Lê um catálogo/lista do banco **sem derrubar a tela**: o erro vai para a linha de comando e a
        /// grade abre vazia (a mesma regra das telas de compilação e de materiais).
        /// </summary>
        protected static T DoBanco<T>(string rotulo, Func<T> ler)
        {
            try
            {
                return ler();
            }
            catch (Exception erro)
            {
                Plugin.Escrever(rotulo + ": o banco não respondeu — " + erro.Message);
                return default(T);
            }
        }

        /// <summary>
        /// O <c>OrderBy</c> do original é <c>ORDER BY Data</c> e o laço da tela acrescenta as revisões de
        /// trás para a frente: a **mais nova fica em cima**. Devolve a lista já nessa ordem.
        /// </summary>
        protected static System.Collections.Generic.List<RevisaoDoDwg> MaisNovaPrimeiro(
            System.Collections.Generic.IReadOnlyList<RevisaoDoDwg> revisoes)
        {
            System.Collections.Generic.List<RevisaoDoDwg> lista =
                new System.Collections.Generic.List<RevisaoDoDwg>();
            if (revisoes == null)
            {
                return lista;
            }

            for (int i = revisoes.Count - 1; i >= 0; i--)
            {
                lista.Add(revisoes[i]);
            }

            return lista;
        }

        /// <summary>O texto de um controle pelo `Name` — o original sobrescreve os textos do designer.</summary>
        protected static void Texto(Form janela, string nome, string texto)
        {
            Control controle = ControlesDaTela.Procurar(janela, nome);
            if (controle != null)
            {
                controle.Text = texto ?? string.Empty;
            }
        }

        /// <summary>O texto atual de uma caixa pelo `Name` (vazio quando a caixa não existe).</summary>
        protected static string LerCaixa(Form janela, string nome)
        {
            TextBox caixa = ControlesDaTela.Achar<TextBox>(janela, nome);
            return caixa == null ? string.Empty : (caixa.Text ?? string.Empty);
        }

        /// <summary>A dica de um controle — o `SetToolTip` que o construtor do original faz.</summary>
        protected static void Dica(Form janela, string nome, string dica)
        {
            Control controle = ControlesDaTela.Procurar(janela, nome);
            if (controle == null)
            {
                return;
            }

            if (_dicas == null)
            {
                _dicas = new ToolTip();
            }

            _dicas.SetToolTip(controle, dica);
        }

        /// <summary>
        /// Desabilita o controle com o **motivo** na dica e no `Tag` — o botão fica visível e explicado,
        /// em vez de sumir (o que não tem regra portada aparece desabilitado e diz por quê).
        /// </summary>
        protected static void Desabilitar(Form janela, string nome, string motivo)
        {
            Control controle = ControlesDaTela.Procurar(janela, nome);
            if (controle == null)
            {
                return;
            }

            controle.Enabled = false;
            controle.Tag = motivo;
            Dica(janela, nome, motivo);
        }

        /// <summary>Pendura o clique num botão, quando ele existe.</summary>
        protected static void Ligar(Button botao, EventHandler acao)
        {
            if (botao != null)
            {
                botao.Click += acao;
            }
        }

        /// <summary>O texto de uma célula da grade (o `Conversions.ToString(...Value)` do original).</summary>
        protected static string Celula(DataGridViewRow linha, int coluna)
        {
            if (linha == null || coluna >= linha.Cells.Count || linha.Cells[coluna].Value == null)
            {
                return string.Empty;
            }

            return Convert.ToString(linha.Cells[coluna].Value) ?? string.Empty;
        }
    }
}

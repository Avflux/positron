using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Positron.Data;
using Positron.Data.Configuracao;
using Positron.Data.Materiais;

namespace Positron.Plugin.Interface.Telas
{
    /// <summary>
    /// A base das **duas telas de materiais** do original — <c>frmGerenciadorMateriais</c>
    /// (<c>GERLM</c>) e <c>frmGerenciadorMatIndep</c> (<c>ATINDEP</c>). As duas giram em volta das
    /// mesmas duas tabelas: o **catálogo** (<c>Materiais</c>, o <c>LM</c> do original) e a **lista**
    /// (<c>ListaMateriais</c>, a projeção do <c>COMPLM</c>) — esta última é a regra que o recoder já
    /// tem e já mediu no desenho real.
    ///
    /// O que fica **ligado**: a grade (o catálogo no <c>GERLM</c>; os painéis e os itens do painel no
    /// <c>ATINDEP</c>) e a **seleção** — que no original preenche as caixas do material. O que entra
    /// **desabilitado, com o motivo na dica** (o mesmo padrão das telas de compilação): tudo que
    /// **grava** (o original edita o catálogo e a lista dentro do próprio formulário) e o que sai pelo
    /// **Excel** (interop).
    ///
    /// Duas diferenças deliberadas em relação ao original, registradas no RUNBOOK (rodada 148):
    /// a lista de painéis do <c>ATINDEP</c> sai da <c>ListaMateriais</c> (a regra do recoder) em vez
    /// de uma segunda varredura do ModelSpace, e a pintura da grade (<c>MesclaDGDisp</c>) fica para a
    /// rodada que portar a edição.
    /// </summary>
    internal abstract class LigacaoDeMateriais : ILigacaoDeTela
    {
        /// <summary>As dicas ficam num único componente vivo (um <c>ToolTip</c> por botão morreria no GC).</summary>
        private static ToolTip _dicas;

        public abstract string NomeDaTela { get; }

        public abstract void Preencher(Form janela);

        /// <summary>
        /// O catálogo do banco, ordenado por código interno — o <c>CarregaListaMateriaisDoDG</c> /
        /// <c>CarregaDadosLMMatriz</c> do original. Sem banco (ou com erro de leitura) devolve vazio e
        /// **diz na linha de comando**: a tela abre vazia, não quebrada.
        /// </summary>
        protected static List<MaterialDoCatalogo> Catalogo(ConfiguracaoPositron config)
        {
            if (config == null || string.IsNullOrEmpty(config.Banco))
            {
                return new List<MaterialDoCatalogo>();
            }

            try
            {
                return new ProjectStore(config.Banco).LerMateriais();
            }
            catch (Exception erro)
            {
                Aviso.MsgBoxCritico(erro.Message, string.Empty);
                return new List<MaterialDoCatalogo>();
            }
        }

        /// <summary>
        /// O texto de um controle pelo `Name` — o original **sobrescreve** os textos do designer no
        /// construtor (as `mMensagem`), e o renderizador pinta o texto do designer.
        /// </summary>
        protected static void Texto(Form janela, string nome, string texto)
        {
            Control controle = ControlesDaTela.Procurar(janela, nome);
            if (controle != null)
            {
                controle.Text = texto;
            }
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

        /// <summary>O texto de uma célula da grade (o `Conversions.ToString(...Value)` do original).</summary>
        protected static string Celula(DataGridViewRow linha, int coluna)
        {
            if (linha == null || coluna >= linha.Cells.Count || linha.Cells[coluna].Value == null)
            {
                return string.Empty;
            }

            return Convert.ToString(linha.Cells[coluna].Value) ?? string.Empty;
        }

        /// <summary>O texto atual de uma caixa pelo `Name` (vazio quando a caixa não existe).</summary>
        protected static string LerCaixa(Form janela, string nome)
        {
            TextBox caixa = ControlesDaTela.Achar<TextBox>(janela, nome);
            return caixa == null ? string.Empty : (caixa.Text ?? string.Empty);
        }

        /// <summary>O texto de uma caixa pelo `Name` — a célula da grade preenchendo o campo da tela.</summary>
        protected static void TextoDaCaixa(Form janela, string nome, string valor)
        {
            TextBox caixa = ControlesDaTela.Achar<TextBox>(janela, nome);
            if (caixa != null)
            {
                caixa.Text = valor ?? string.Empty;
            }
        }

        /// <summary>
        /// Desabilita o controle com o **motivo** na dica e no `Tag` — o botão fica visível e
        /// explicado, em vez de sumir (a regra do recoder é a casca fina: o que não tem regra
        /// portada aparece desabilitado e diz por quê).
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
    }
}

#if !POSITRON_SEM_WINFORMS
using System;
using System.Drawing;
using System.Windows.Forms;
using Positron.Data.Configuracao;

namespace Positron.Plugin.Configuracao
{
    /// <summary>
    /// Tela de configuração do plugin — o lugar das variáveis <c>POSITRON_*</c>
    /// (o original tinha as telas <c>frmCompilar*</c> com os mesmos campos).
    ///
    /// Ela só **edita e grava** o arquivo: quem decide a configuração efetiva é
    /// <see cref="ConfiguracaoPositron.Carregar"/>, com a precedência
    /// padrão &lt; arquivo &lt; ambiente — a variável de ambiente continua vencendo,
    /// para o harness e a automação não dependerem de arquivo nenhum.
    ///
    /// A tela é aberta pelo comando <c>ELETCFG</c>. Ela é modal: rodar
    /// <c>ELETCFG</c> dentro do script do harness trava (ninguém clica em OK), por
    /// isso os E2E **não** a executam — a lógica testável está em
    /// <see cref="ConfiguracaoPositron"/>, coberta por <c>ConfiguracaoPositronTests</c>.
    /// </summary>
    internal sealed class FormularioConfiguracao : Form
    {
        private readonly TextBox _banco = new TextBox();
        private readonly TextBox _dwg = new TextBox();
        private readonly TextBox _revisao = new TextBox();
        private readonly TextBox _local = new TextBox();
        private readonly TextBox _log = new TextBox();
        private readonly TextBox _incluirColuna = new TextBox();
        private readonly TextBox _separador = new TextBox();

        internal ConfiguracaoPositron Resultado { get; private set; }

        internal FormularioConfiguracao(ConfiguracaoPositron configuracao)
        {
            Text = "Positron — configuração";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(520, 300);

            ConfiguracaoPositron atual = configuracao ?? ConfiguracaoPositron.Padrao();
            _dwg.Text = atual.Dwg.ToString();
            _revisao.Text = atual.Revisao ?? string.Empty;
            _local.Text = atual.Local ?? string.Empty;
            _log.Text = atual.Log ?? string.Empty;
            _incluirColuna.Text = atual.IncluirColuna.ToString();
            _separador.Text = atual.SeparadorCruzamento ?? string.Empty;
            _banco.Text = atual.Banco ?? string.Empty;

            string[] rotulos =
            {
                "Banco do projeto (.db)",
                "DWG (índice)",
                "Revisão",
                "Local (caderno)",
                "Log",
                "Incluir coluna (0..6)",
                "Separador do cruzamento",
            };

            TextBox[] campos = { _banco, _dwg, _revisao, _local, _log, _incluirColuna, _separador };

            int y = 12;
            for (int i = 0; i < rotulos.Length; i++)
            {
                Label rotulo = new Label
                {
                    Text = rotulos[i],
                    Left = 12,
                    Top = y + 4,
                    Width = 170,
                };

                campos[i].Left = 190;
                campos[i].Top = y;
                campos[i].Width = 310;
                Controls.Add(rotulo);
                Controls.Add(campos[i]);
                y += 32;
            }

            Button salvar = new Button { Text = "Salvar", Left = 330, Top = y + 8, Width = 80, DialogResult = DialogResult.OK };
            Button cancelar = new Button { Text = "Cancelar", Left = 420, Top = y + 8, Width = 80, DialogResult = DialogResult.Cancel };
            Controls.Add(salvar);
            Controls.Add(cancelar);

            AcceptButton = salvar;
            CancelButton = cancelar;

            salvar.Click += (origem, evento) => Coletar(atual);
        }

        private void Coletar(ConfiguracaoPositron atual)
        {
            int numero;

            Resultado = new ConfiguracaoPositron
            {
                Banco = Texto(_banco),
                Dwg = int.TryParse(_dwg.Text.Trim(), out numero) ? numero : atual.Dwg,
                Revisao = Texto(_revisao),
                Local = Texto(_local),
                Log = Texto(_log),
                IncluirColuna = int.TryParse(_incluirColuna.Text.Trim(), out numero) ? numero : atual.IncluirColuna,
                SeparadorCruzamento = Texto(_separador),
            };
        }

        private static string Texto(TextBox caixa)
        {
            string valor = caixa.Text.Trim();
            return valor.Length == 0 ? null : valor;
        }
    }
}
#endif

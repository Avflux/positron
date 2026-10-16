using System.Drawing;
using System.Windows.Forms;

namespace Positron.Plugin.Interface.Folhas
{
    /// <summary>Pergunta de campo da página; os títulos usam a frmEditaTitulos não modal.</summary>
    internal sealed class FormularioDeCampoDaPagina : Form
    {
        private readonly TextBox _valor;

        internal FormularioDeCampoDaPagina(string titulo, string rotulo, string pagina, string valor)
        {
            Text = titulo + " — página " + pagina;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(320, 90);
            Label campo = new Label { Left = 12, Top = 16, Width = 120, Text = rotulo };
            _valor = new TextBox { Left = 12, Top = 38, Width = 296, Text = valor ?? string.Empty };
            Button ok = new Button { Left = 152, Top = 66, Width = 75, Text = "OK", DialogResult = DialogResult.OK };
            Button cancelar = new Button { Left = 233, Top = 66, Width = 75, Text = "Cancelar", DialogResult = DialogResult.Cancel };
            Controls.Add(campo);
            Controls.Add(_valor);
            Controls.Add(ok);
            Controls.Add(cancelar);
            AcceptButton = ok;
            CancelButton = cancelar;
        }

        internal string Valor { get { return _valor.Text; } }

        internal static bool Perguntar(string titulo, string rotulo, string pagina, string valor, out string escolhido)
        {
            if (RespostaDoHarness.Campo(rotulo, out escolhido)) return true;
            using (FormularioDeCampoDaPagina form = new FormularioDeCampoDaPagina(titulo, rotulo, pagina, valor))
            {
                if (form.ShowDialog() != DialogResult.OK)
                {
                    escolhido = null;
                    return false;
                }
                escolhido = form.Valor;
                return true;
            }
        }
    }
}

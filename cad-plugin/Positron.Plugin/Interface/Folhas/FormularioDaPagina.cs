using System.Drawing;
using System.Windows.Forms;

namespace Positron.Plugin.Interface.Folhas
{
    /// <summary>
    /// O **editor de um campo** de uma pagina — o `Editar Unidade` / `Editar Alternativo` do menu
    /// das folhas (os itens do `cmStrip1` do reverso, que abrem o form da fatia 5).
    ///
    /// O form do original tem a pagina, os dois campos e os botoes; aqui o campo que o item edita
    /// vem no titulo e o valor entra no `GravarXDataUnidadeAlternativo` (o adapter
    /// `UnidadeDaPaginaDoDesenho`), que e a regra ja portada na rodada 144.
    /// </summary>
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

        /// <summary>O valor digitado.</summary>
        internal string Valor
        {
            get { return _valor.Text; }
        }

        /// <summary>Pergunta o valor e devolve <c>false</c> quando o usuario cancela.</summary>
        internal static bool Perguntar(string titulo, string rotulo, string pagina, string valor, out string escolhido)
        {
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

    /// <summary>
    /// O **editor dos quatro titulos** de uma pagina — o `Editar Títulos` do menu (o form da
    /// fatia 6). Le os titulos pelo `TitulosDaPaginaDoDesenho` e os regrava quando o usuario
    /// confirma.
    /// </summary>
    internal sealed class FormularioDeTitulosDaPagina : Form
    {
        private readonly TextBox[] _campos;

        internal FormularioDeTitulosDaPagina(string pagina, Positron.Data.Paginas.TitulosDaPagina titulos)
        {
            Text = "Editar Títulos — página " + pagina;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(360, 190);

            _campos = new TextBox[Positron.Data.Paginas.TitulosDaPagina.UltimoIndice];
            for (int i = 0; i < _campos.Length; i++)
            {
                Label rotulo = new Label { Left = 12, Top = 16 + (i * 30), Width = 30, Text = "T" + (i + 1) };
                _campos[i] = new TextBox
                {
                    Left = 46,
                    Top = 12 + (i * 30),
                    Width = 300,
                    Text = titulos == null ? string.Empty : (titulos.De(i + 1) ?? string.Empty),
                };
                Controls.Add(rotulo);
                Controls.Add(_campos[i]);
            }

            Button ok = new Button { Left = 190, Top = 152, Width = 75, Text = "OK", DialogResult = DialogResult.OK };
            Button cancelar = new Button { Left = 271, Top = 152, Width = 75, Text = "Cancelar", DialogResult = DialogResult.Cancel };
            Controls.Add(ok);
            Controls.Add(cancelar);
            AcceptButton = ok;
            CancelButton = cancelar;
        }

        /// <summary>Os quatro titulos digitados, na ordem 1..4.</summary>
        internal Positron.Data.Paginas.TitulosDaPagina Titulos()
        {
            Positron.Data.Paginas.TitulosDaPagina titulos = new Positron.Data.Paginas.TitulosDaPagina();
            for (int i = 0; i < _campos.Length; i++)
            {
                titulos.Definir(i + 1, _campos[i].Text);
            }

            return titulos;
        }

        /// <summary>Pergunta os quatro titulos e devolve <c>false</c> quando o usuario cancela.</summary>
        internal static bool Perguntar(string pagina, Positron.Data.Paginas.TitulosDaPagina atuais, out Positron.Data.Paginas.TitulosDaPagina escolhidos)
        {
            using (FormularioDeTitulosDaPagina form = new FormularioDeTitulosDaPagina(pagina, atuais))
            {
                if (form.ShowDialog() != DialogResult.OK)
                {
                    escolhidos = null;
                    return false;
                }

                escolhidos = form.Titulos();
                return true;
            }
        }
    }
}

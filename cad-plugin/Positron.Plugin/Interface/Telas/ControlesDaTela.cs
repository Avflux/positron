using System;
using System.Windows.Forms;

namespace Positron.Plugin.Interface.Telas
{
    /// <summary>
    /// O **achador de controle** pelo `Name` do designer, em qualquer nível de aninhamento — o que
    /// toda ligação de tela precisa e o que o original fazia com o campo do `frm*` já resolvido.
    /// </summary>
    internal static class ControlesDaTela
    {
        internal static T Achar<T>(Control raiz, string nome) where T : Control
        {
            return Procurar(raiz, nome) as T;
        }

        internal static Control Procurar(Control raiz, string nome)
        {
            if (raiz == null)
            {
                return null;
            }

            if (string.Equals(raiz.Name, nome, StringComparison.Ordinal))
            {
                return raiz;
            }

            foreach (Control filho in raiz.Controls)
            {
                Control achado = Procurar(filho, nome);
                if (achado != null)
                {
                    return achado;
                }
            }

            return null;
        }
    }
}

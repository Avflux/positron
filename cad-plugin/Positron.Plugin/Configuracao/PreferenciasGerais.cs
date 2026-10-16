using System;
using Microsoft.Win32;

namespace Positron.Plugin.Configuracao
{
    /// <summary>
    /// Preferências do produto gravadas no Registro do usuário (<c>HKCU\Software\Cadgraph\Eletron4</c>),
    /// como o original (<c>frmConfiguracaoGeral.cs:3904-3910</c>, <c>myEletron.cs:93-103</c>).
    /// </summary>
    internal static class PreferenciasGerais
    {
        internal const string ChaveRegistro = @"Software\Cadgraph\Eletron4";
        internal const string ValorIdioma = "Idioma";

        internal static string LerIdioma()
        {
            try
            {
                using (RegistryKey chave = Registry.CurrentUser.OpenSubKey(ChaveRegistro))
                {
                    if (chave != null)
                    {
                        string idioma = Convert.ToString(chave.GetValue(ValorIdioma, "[PT]"));
                        return string.IsNullOrEmpty(idioma) ? "[PT]" : idioma;
                    }
                }
            }
            catch
            {
            }

            return "[PT]";
        }

        internal static void GravarIdioma(string idioma)
        {
            try
            {
                using (RegistryKey chave = Registry.CurrentUser.CreateSubKey(ChaveRegistro))
                {
                    if (chave != null)
                    {
                        chave.SetValue(ValorIdioma, idioma ?? "[PT]", RegistryValueKind.String);
                    }
                }
            }
            catch
            {
            }
        }
    }
}

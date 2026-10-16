using System;
using Microsoft.Win32;

namespace Positron.Plugin.Interface.Folhas
{
    internal static class PreferenciasDeFolhas
    {
        private const string Caminho = @"Software\Cadgraph\Eletron4";

        internal static bool LerAlternativo()
        {
            using (RegistryKey chave = Registry.CurrentUser.OpenSubKey(Caminho))
            {
                return chave != null && Convert.ToString(chave.GetValue("Altern", "0")) == "1";
            }
        }

        internal static void GravarAlternativo(bool mostrar)
        {
            using (RegistryKey chave = Registry.CurrentUser.CreateSubKey(Caminho))
            {
                chave.SetValue("Altern", mostrar ? "1" : "0", RegistryValueKind.String);
            }
        }
    }
}

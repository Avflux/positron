using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using ZwSoft.ZwCAD.DatabaseServices;

namespace Eletron4;

public class Trigger
{
	private string Yfcp1QlhOcB;

	public Trigger()
	{
		Yfcp1QlhOcB = HostApplicationServices.Current.UserRegistryProductRootKey;
	}

	public void Register()
	{
		RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(Yfcp1QlhOcB, writable: true);
		RegistryKey registryKey2 = registryKey.OpenSubKey("Applications", writable: true);
		if (registryKey2 == null)
		{
			registryKey2 = registryKey.CreateSubKey("Applications");
		}
		string text = "Trigger";
		RegistryKey registryKey3 = registryKey2.CreateSubKey(text);
		registryKey3.SetValue("DESCRIPTION", text, RegistryValueKind.String);
		registryKey3.SetValue("LOADCTRLS", 14, RegistryValueKind.DWord);
		registryKey3.SetValue("LOADER", "C:\\Windows\\System32\\TriggerZ.dll", RegistryValueKind.String);
		registryKey3.SetValue("MANAGED", 1, RegistryValueKind.DWord);
		registryKey2.Close();
		Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1979]), MsgBoxStyle.Information, "Eletron");
	}

	public void Unregister()
	{
		RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(Yfcp1QlhOcB, writable: true);
		RegistryKey registryKey2 = registryKey.OpenSubKey("Applications", writable: true);
		if (registryKey2 != null)
		{
			string subkey = "Trigger";
			registryKey2.DeleteSubKeyTree(subkey);
			registryKey2.Close();
		}
	}
}

using System;
using System.Security.Cryptography;
using System.Text;
using Eletron4.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;

namespace Eletron4;

public class CProtect
{
	public string GerarChave()
	{
		string text = "";
		string name = "SOFTWARE\\\\Microsoft\\\\Cryptography";
		string text2 = "";
		RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(name, writable: false);
		text2 = ((registryKey == null) ? "NOTFOUND1" : Conversions.ToString(registryKey.GetValue("MachineGuid", "NOTFOUND2")));
		registryKey.Close();
		int millisecond = DateAndTime.Now.Millisecond;
		if (MySettingsProperty.Settings.Cont == -1)
		{
			MySettingsProperty.Settings.Cont = millisecond;
			MySettingsProperty.Settings.Save();
		}
		return text2 + "-" + MySettingsProperty.Settings.Cont;
	}

	public string Descriptografar(string Message, int prog)
	{
		string s = "";
		switch (prog)
		{
		case 3:
			s = "2C400B16-731344-8434238-92834456-C1BB52F50228";
			break;
		case 1:
			s = "FC416B16-522354-4134638-93334986-B1BC52F50345";
			break;
		case 2:
			s = "4C436B16-732324-4479238-93211456-A1BC52F50338";
			break;
		}
		UTF8Encoding uTF8Encoding = new UTF8Encoding();
		MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
		byte[] key = mD5CryptoServiceProvider.ComputeHash(uTF8Encoding.GetBytes(s));
		TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
		tripleDESCryptoServiceProvider.Key = key;
		tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
		tripleDESCryptoServiceProvider.Padding = PaddingMode.PKCS7;
		byte[] array = Convert.FromBase64String(Message);
		byte[] bytes;
		try
		{
			ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateDecryptor();
			bytes = cryptoTransform.TransformFinalBlock(array, 0, array.Length);
		}
		finally
		{
			tripleDESCryptoServiceProvider.Clear();
			mD5CryptoServiceProvider.Clear();
		}
		return uTF8Encoding.GetString(bytes);
	}

	public string CriptografarDH(string Message)
	{
		string s = "4C436B16-732324-4479238-93211456-A1BC52F50338";
		UTF8Encoding uTF8Encoding = new UTF8Encoding();
		MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
		byte[] key = mD5CryptoServiceProvider.ComputeHash(uTF8Encoding.GetBytes(s));
		TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
		tripleDESCryptoServiceProvider.Key = key;
		tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
		tripleDESCryptoServiceProvider.Padding = PaddingMode.PKCS7;
		byte[] bytes = uTF8Encoding.GetBytes(Message);
		byte[] inArray;
		try
		{
			ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateEncryptor();
			inArray = cryptoTransform.TransformFinalBlock(bytes, 0, bytes.Length);
		}
		finally
		{
			tripleDESCryptoServiceProvider.Clear();
			mD5CryptoServiceProvider.Clear();
		}
		return Convert.ToBase64String(inArray);
	}

	public string DescriptografarDH(string Message)
	{
		string s = "4C436B16-732324-4479238-93211456-A1BC52F50338";
		UTF8Encoding uTF8Encoding = new UTF8Encoding();
		MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
		byte[] key = mD5CryptoServiceProvider.ComputeHash(uTF8Encoding.GetBytes(s));
		TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
		tripleDESCryptoServiceProvider.Key = key;
		tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
		tripleDESCryptoServiceProvider.Padding = PaddingMode.PKCS7;
		byte[] array = Convert.FromBase64String(Message);
		byte[] bytes;
		try
		{
			ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateDecryptor();
			bytes = cryptoTransform.TransformFinalBlock(array, 0, array.Length);
		}
		finally
		{
			tripleDESCryptoServiceProvider.Clear();
			mD5CryptoServiceProvider.Clear();
		}
		return uTF8Encoding.GetString(bytes);
	}
}

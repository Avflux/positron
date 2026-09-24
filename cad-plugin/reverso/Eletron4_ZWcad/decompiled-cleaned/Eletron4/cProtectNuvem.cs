using System;
using System.Security.Cryptography;
using System.Text;
using Eletron4.My;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;

namespace Eletron4;

public class cProtectNuvem
{
	public string CriptografarDH(string Message)
	{
		string cHV = MySettingsProperty.Settings.CHV;
		UTF8Encoding uTF8Encoding = new UTF8Encoding();
		MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
		byte[] key = mD5CryptoServiceProvider.ComputeHash(uTF8Encoding.GetBytes(cHV));
		TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
		byte[] inArray;
		try
		{
			tripleDESCryptoServiceProvider.Key = key;
			tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
			tripleDESCryptoServiceProvider.Padding = PaddingMode.PKCS7;
			byte[] bytes = uTF8Encoding.GetBytes(Message);
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
		string cHV = MySettingsProperty.Settings.CHV;
		byte[] bytes = null;
		UTF8Encoding uTF8Encoding = new UTF8Encoding();
		MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
		byte[] key = mD5CryptoServiceProvider.ComputeHash(uTF8Encoding.GetBytes(cHV));
		TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
		try
		{
			tripleDESCryptoServiceProvider.Key = key;
			tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
			tripleDESCryptoServiceProvider.Padding = PaddingMode.PKCS7;
			byte[] array = Convert.FromBase64String(Message);
			ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateDecryptor();
			bytes = cryptoTransform.TransformFinalBlock(array, 0, array.Length);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			Registry.CurrentUser.DeleteSubKey("Software\\\\W64c\\\\Elk", throwOnMissingSubKey: false);
			ProjectData.ClearProjectError();
		}
		finally
		{
			tripleDESCryptoServiceProvider.Clear();
			mD5CryptoServiceProvider.Clear();
		}
		return uTF8Encoding.GetString(bytes);
	}
}

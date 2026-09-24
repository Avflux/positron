using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4.My;

[CompilerGenerated]
[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.14.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
internal sealed class MySettings : ApplicationSettingsBase
{
	private static MySettings defaultInstance;

	public static MySettings Default => defaultInstance;

	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	[UserScopedSetting]
	public string Codigo
	{
		get
		{
			return Conversions.ToString(this["Codigo"]);
		}
		set
		{
			this["Codigo"] = value;
		}
	}

	[DefaultSettingValue("")]
	[DebuggerNonUserCode]
	[UserScopedSetting]
	public string HCode
	{
		get
		{
			return Conversions.ToString(this["HCode"]);
		}
		set
		{
			this["HCode"] = value;
		}
	}

	[UserScopedSetting]
	[DefaultSettingValue("")]
	[DebuggerNonUserCode]
	public string DCode
	{
		get
		{
			return Conversions.ToString(this["DCode"]);
		}
		set
		{
			this["DCode"] = value;
		}
	}

	[DefaultSettingValue("-1")]
	[DebuggerNonUserCode]
	[UserScopedSetting]
	public int Cont
	{
		get
		{
			return Conversions.ToInteger(this["Cont"]);
		}
		set
		{
			this["Cont"] = value;
		}
	}

	[DebuggerNonUserCode]
	[UserScopedSetting]
	[DefaultSettingValue("0")]
	public int LicMode
	{
		get
		{
			return Conversions.ToInteger(this["LicMode"]);
		}
		set
		{
			this["LicMode"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("1,5")]
	public string Secao
	{
		get
		{
			return Conversions.ToString(this["Secao"]);
		}
		set
		{
			this["Secao"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("PT")]
	public string Cor
	{
		get
		{
			return Conversions.ToString(this["Cor"]);
		}
		set
		{
			this["Cor"] = value;
		}
	}

	[DefaultSettingValue("7148680A-CE7F-4CB2-B588-31B0C8FBDF13")]
	[DebuggerNonUserCode]
	[ApplicationScopedSetting]
	public string CHV => Conversions.ToString(this["CHV"]);

	[DebuggerNonUserCode]
	[UserScopedSetting]
	[DefaultSettingValue("")]
	public string LicCloud
	{
		get
		{
			return Conversions.ToString(this["LicCloud"]);
		}
		set
		{
			this["LicCloud"] = value;
		}
	}

	[DefaultSettingValue("")]
	[DebuggerNonUserCode]
	[UserScopedSetting]
	public string EmailCloud
	{
		get
		{
			return Conversions.ToString(this["EmailCloud"]);
		}
		set
		{
			this["EmailCloud"] = value;
		}
	}

	[DefaultSettingValue("False")]
	[DebuggerNonUserCode]
	[UserScopedSetting]
	public bool DesinstalarAut
	{
		get
		{
			return Conversions.ToBoolean(this["DesinstalarAut"]);
		}
		set
		{
			this["DesinstalarAut"] = value;
		}
	}

	static MySettings()
	{
		defaultInstance = (MySettings)SettingsBase.Synchronized(new MySettings());
	}
}

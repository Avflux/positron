using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using KeyLib;
using Microsoft.VisualBasic.CompilerServices;
using USiQ9BxrK9i9kKRRA9;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;

namespace Eletron4;

public class cCheckElecKey
{
	public KeyCheck Kc0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private bool XI3SEHE5i;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string YBO4594es;

	public bool bApp
	{
		[CompilerGenerated]
		get
		{
			return XI3SEHE5i;
		}
		[CompilerGenerated]
		set
		{
			XI3SEHE5i = value;
		}
	}

	public string msg
	{
		[CompilerGenerated]
		get
		{
			return YBO4594es;
		}
		[CompilerGenerated]
		set
		{
			YBO4594es = value;
		}
	}

	public cCheckElecKey()
	{
		bApp = false;
		msg = "";
	}

	public void verificaElecKey()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected Obj, but got Unknown
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected Obj, but got Unknown
		Application.BeginQuit += [SpecialName] [DebuggerHidden] (object a0, BeginQuitEventArgs a1) =>
		{
			ejlZUpsa7();
		};
		Kc0 = new KeyCheck(1975451131, 1, 0, 0, "", Application.ExecutablePath, "");
		Kc0.SrvIdx = 6;
		OyUEG143c(Kc0);
	}

	public void CloseElecKey()
	{
		Kc0.NetKeyLogout();
		Kc0.NetKeyDisconnect();
		Kc0.CloseKeySrv(6);
	}

	private void OyUEG143c(KeyCheck P_0)
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected Obj, but got Unknown
		if (P_0.OpenKeySrv(6))
		{
			string text = Lx48sLwEDmLUNP1cLK.FTLMkY2vQ.FileSystem.SpecialDirectories.ProgramFiles + "\\Eletron4\\DLL\\NetKey.ini";
			if (P_0.NetKeyConnect(text))
			{
				if (P_0.UpdateLimitKey(0u))
				{
					if (P_0.NetKeyLogin("Elétron", "Elétron", 6u))
					{
						P_0.SetClientBackgroundCheck(20, (TBackgroundCheckCmd)0, (evResultProc)dqviuow4S);
						P_0.SetServerBackgroundCheck(10, 0);
						DeclaracoesGeral.companyHardlock = Geral.leCompanyNuvemElecKey(P_0.UserID);
						string companyHardlock = DeclaracoesGeral.companyHardlock;
						if (Operators.CompareString(companyHardlock, "Ghenova", TextCompare: true) != 0 && Operators.CompareString(companyHardlock, "Inova", TextCompare: true) != 0 && Operators.CompareString(companyHardlock, "Siproenge", TextCompare: true) != 0 && Operators.CompareString(companyHardlock, "Enel CE", TextCompare: true) != 0 && Operators.CompareString(companyHardlock, "Cápua Engenharia", TextCompare: true) != 0 && Operators.CompareString(companyHardlock, "Pronext", TextCompare: true) != 0 && Operators.CompareString(companyHardlock, "JPW", TextCompare: true) != 0 && Operators.CompareString(companyHardlock, "DMA Sistemas", TextCompare: true) != 0 && Operators.CompareString(companyHardlock, "Tecmon", TextCompare: true) != 0 && Operators.CompareString(companyHardlock, "Nery", TextCompare: true) != 0 && Operators.CompareString(companyHardlock, "EDP ES", TextCompare: true) != 0 && Operators.CompareString(companyHardlock, "Petra", TextCompare: true) != 0 && Operators.CompareString(companyHardlock, "Engepro", TextCompare: true) != 0 && Operators.CompareString(companyHardlock, "Copenge2", TextCompare: true) != 0 && Operators.CompareString(companyHardlock, "Copenge", TextCompare: true) != 0 && Operators.CompareString(companyHardlock, "Energisa", TextCompare: true) != 0 && Operators.CompareString(companyHardlock, "Gama Engenharia", TextCompare: true) != 0 && Operators.CompareString(companyHardlock, "STK", TextCompare: true) != 0 && Operators.CompareString(companyHardlock, "AllPrime", TextCompare: true) != 0 && Operators.CompareString(companyHardlock, "Enel GO", TextCompare: true) != 0 && Operators.CompareString(companyHardlock, "Tractebel BH", TextCompare: true) != 0 && Operators.CompareString(companyHardlock, "Tractebel DF", TextCompare: true) != 0 && Operators.CompareString(companyHardlock, "Tractebel RJ", TextCompare: true) != 0 && Operators.CompareString(companyHardlock, "Arteche", TextCompare: true) != 0 && Operators.CompareString(companyHardlock, "SNEF Brasil", TextCompare: true) != 0 && Operators.CompareString(companyHardlock, "Acrux", TextCompare: true) != 0 && Operators.CompareString(companyHardlock, "Vision", TextCompare: true) != 0)
						{
							bApp = true;
							return;
						}
						msg = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 0]);
						bApp = false;
					}
					else
					{
						msg = P_0.ErrStr;
						bApp = false;
					}
				}
				else
				{
					msg = P_0.ErrStr;
					bApp = false;
				}
			}
			else
			{
				msg = P_0.ErrStr;
				bApp = false;
			}
		}
		else
		{
			msg = P_0.ErrStr;
			bApp = false;
		}
	}

	private void ejlZUpsa7()
	{
		CloseElecKey();
	}

	private void dqviuow4S(int P_0, int P_1, string P_2)
	{
		if (P_1 != 0)
		{
			new wElecKey();
		}
	}
}

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Timers;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.Runtime;

namespace Eletron4;

public class cCheckLicRockey
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static BeginQuitEventHandler _0024IR4_002D1;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		[DebuggerHidden]
		internal void _Lambda_0024__R4_002D1(object a0, BeginQuitEventArgs a1)
		{
			qPqBDaMXb();
		}
	}

	public static Timer t;

	private static DeclaracoesGeral.Hardlock qyEuv9RU7;

	static cCheckLicRockey()
	{
		t = new Timer();
		qyEuv9RU7 = default;
	}

	public static void verificaRockey()
	{
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected Obj, but got Unknown
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		DeclaracoesGeral.app = true;
		if (!qyEuv9RU7.existe & (Operators.CompareString(qyEuv9RU7.company, "", TextCompare: true) == 0))
		{
			BeginQuitEventHandler val2;
			if (_Closure_0024__._0024IR4_002D1 == null)
			{
				BeginQuitEventHandler val = [SpecialName] [DebuggerHidden] (object a0, BeginQuitEventArgs a1) =>
				{
					qPqBDaMXb();
				};
				_Closure_0024__._0024IR4_002D1 = val;
				val2 = val;
			}
			else
			{
				val2 = _Closure_0024__._0024IR4_002D1;
			}
			Application.BeginQuit += val2;
			qyEuv9RU7.company = "";
			qyEuv9RU7.existe = false;
			qyEuv9RU7.handle = 0;
			qyEuv9RU7.tipo = 0;
			qyEuv9RU7.erro = 0;
			try
			{
				Rockey.Rockey432 rockey = new Rockey.Rockey432();
				rockey.AbreModulo3(ref qyEuv9RU7);
				if (!qyEuv9RU7.existe)
				{
					throw new Exception((ErrorStatus)1, "");
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				try
				{
					Rockey.Rockey464 rockey2 = new Rockey.Rockey464();
					rockey2.AbreModulo3(ref qyEuv9RU7);
					if (!qyEuv9RU7.existe)
					{
						throw new Exception((ErrorStatus)1, "");
					}
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					try
					{
						Rockey.Rockey4ND32 rockey4ND = new Rockey.Rockey4ND32();
						rockey4ND.AbreModulo3(ref qyEuv9RU7);
						if (!qyEuv9RU7.existe)
						{
							throw new Exception((ErrorStatus)1, "");
						}
					}
					catch (Exception projectError3)
					{
						ProjectData.SetProjectError(projectError3);
						try
						{
							Rockey.Rockey4ND64 rockey4ND2 = new Rockey.Rockey4ND64();
							rockey4ND2.AbreModulo3(ref qyEuv9RU7);
							if (!qyEuv9RU7.existe)
							{
								throw new Exception((ErrorStatus)1, "");
							}
						}
						catch (Exception projectError4)
						{
							ProjectData.SetProjectError(projectError4);
							try
							{
								Rockey.NetRockey432 netRockey = new Rockey.NetRockey432();
								netRockey.AbreModulo3(ref qyEuv9RU7);
							}
							catch (Exception projectError5)
							{
								ProjectData.SetProjectError(projectError5);
								try
								{
									Rockey.NetRockey464 netRockey2 = new Rockey.NetRockey464();
									netRockey2.AbreModulo3(ref qyEuv9RU7);
								}
								catch (Exception projectError6)
								{
									ProjectData.SetProjectError(projectError6);
									qyEuv9RU7.existe = false;
									ProjectData.ClearProjectError();
								}
								ProjectData.ClearProjectError();
							}
							ProjectData.ClearProjectError();
						}
						ProjectData.ClearProjectError();
					}
					ProjectData.ClearProjectError();
				}
				ProjectData.ClearProjectError();
			}
			string company = qyEuv9RU7.company;
			if (Operators.CompareString(company, "IRINEU", TextCompare: true) == 0 || Operators.CompareString(company, "ROUBADO", TextCompare: true) == 0 || Operators.CompareString(company, "TOWER", TextCompare: true) == 0 || Operators.CompareString(company, "COELBA", TextCompare: true) == 0 || Operators.CompareString(company, "INVALIDA", TextCompare: true) == 0 || Operators.CompareString(company, "JCS ELET", TextCompare: true) == 0 || Operators.CompareString(company, "EXAUT", TextCompare: true) == 0 || Operators.CompareString(company, "CPE-CE", TextCompare: true) == 0 || Operators.CompareString(company, "TALENT", TextCompare: true) == 0 || Operators.CompareString(company, "MULTIEMP.", TextCompare: true) == 0 || Operators.CompareString(company, "SETEPLA", TextCompare: true) == 0 || Operators.CompareString(company, "NOVA ENGEVIX", TextCompare: true) == 0 || Operators.CompareString(company, "TSE", TextCompare: true) == 0 || Operators.CompareString(company, "THEMAG SP", TextCompare: true) == 0 || Operators.CompareString(company, "THEMAG DF", TextCompare: true) == 0 || Operators.CompareString(company, "JF VIEIRA", TextCompare: true) == 0 || Operators.CompareString(company, "GNETO", TextCompare: true) == 0 || Operators.CompareString(company, "OMEGA", TextCompare: true) == 0 || Operators.CompareString(company, "SHUNT", TextCompare: true) == 0 || Operators.CompareString(company, "SHUNT2", TextCompare: true) == 0 || Operators.CompareString(company, "ARTECHE MX", TextCompare: true) == 0 || Operators.CompareString(company, "PRONEXT2", TextCompare: true) == 0 || Operators.CompareString(company, "PRONEXT3", TextCompare: true) == 0 || Operators.CompareString(company, "PRONEXT", TextCompare: true) == 0 || Operators.CompareString(company, "CENNATECH", TextCompare: true) == 0 || Operators.CompareString(company, "INOVA", TextCompare: true) == 0 || Operators.CompareString(company, "FABIO ROSAN", TextCompare: true) == 0 || Operators.CompareString(company, "ENGELIMA", TextCompare: true) == 0 || Operators.CompareString(company, "JPW", TextCompare: true) == 0 || Operators.CompareString(company, "ZIV DO BRASIL", TextCompare: true) == 0 || Operators.CompareString(company, "COPENGE", TextCompare: true) == 0 || Operators.CompareString(company, "GAMA ENGENHARIA", TextCompare: true) == 0 || Operators.CompareString(company, "STK", TextCompare: true) == 0 || Operators.CompareString(company, "ALLPRIME", TextCompare: true) == 0 || Operators.CompareString(company, "ENEL GO", TextCompare: true) == 0 || Operators.CompareString(company, "ENGERA", TextCompare: true) == 0 || Operators.CompareString(company, "DAROIT", TextCompare: true) == 0 || Operators.CompareString(company, "TSEA", TextCompare: true) == 0 || Operators.CompareString(company, "ELEKTRO", TextCompare: true) == 0 || Operators.CompareString(company, "CJM ENG", TextCompare: true) == 0)
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 0]), MsgBoxStyle.Information, "Elétron");
				DeclaracoesGeral.app = false;
				return;
			}
			string text = Conversion.Hex(qyEuv9RU7.ID);
			bool flag = false;
			string left = text;
			if (Operators.CompareString(left, "41592950", TextCompare: true) != 0)
			{
				if (Operators.CompareString(left, "F5A60695", TextCompare: true) != 0)
				{
					if (Operators.CompareString(left, "FBA60C95", TextCompare: true) != 0)
					{
						if (Operators.CompareString(left, "F1260C95", TextCompare: true) != 0)
						{
							if (Operators.CompareString(left, "7DE2B0D8", TextCompare: true) != 0)
							{
								if (Operators.CompareString(left, "000E1FD2", TextCompare: true) == 0)
								{
									flag = true;
								}
							}
							else
							{
								flag = true;
							}
						}
						else
						{
							flag = true;
						}
					}
					else
					{
						flag = true;
					}
				}
				else
				{
					flag = true;
				}
			}
			else
			{
				flag = true;
			}
			if (flag)
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 0]), MsgBoxStyle.Information, "Elétron");
				DeclaracoesGeral.app = false;
				return;
			}
			if (qyEuv9RU7.existe)
			{
				DeclaracoesGeral.companyHardlock = qyEuv9RU7.company;
				DeclaracoesGeral.tipoHardlock = qyEuv9RU7.tipo;
			}
			else
			{
				if (qyEuv9RU7.erro != 1)
				{
					if (qyEuv9RU7.erro == 2)
					{
						Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 2]), MsgBoxStyle.Information);
					}
				}
				else
				{
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1]), MsgBoxStyle.Information);
				}
				DeclaracoesGeral.app = false;
			}
		}
		if (!((qyEuv9RU7.tipo == 1) | (qyEuv9RU7.tipo == 2) | (qyEuv9RU7.tipo == 5) | (qyEuv9RU7.tipo == 6)))
		{
			if ((qyEuv9RU7.tipo == 3) | (qyEuv9RU7.tipo == 4))
			{
				t.Interval = 200000.0;
				t.Enabled = true;
				t.Elapsed += zBJVmyF3b;
			}
		}
		else
		{
			t.Interval = 20000.0;
			t.Enabled = true;
			t.Elapsed += zBJVmyF3b;
		}
	}

	private static void qPqBDaMXb()
	{
		switch (qyEuv9RU7.tipo)
		{
		case 6:
		{
			Rockey.Rockey4ND64 rockey4ND2 = new Rockey.Rockey4ND64();
			rockey4ND2.fechaModulo3(ref qyEuv9RU7);
			break;
		}
		case 1:
		{
			Rockey.Rockey432 rockey2 = new Rockey.Rockey432();
			rockey2.fechaModulo3(ref qyEuv9RU7);
			break;
		}
		case 2:
		{
			Rockey.Rockey464 rockey = new Rockey.Rockey464();
			rockey.fechaModulo3(ref qyEuv9RU7);
			break;
		}
		case 3:
		{
			Rockey.NetRockey432 netRockey2 = new Rockey.NetRockey432();
			netRockey2.fechaModulo3(ref qyEuv9RU7);
			break;
		}
		case 4:
		{
			Rockey.NetRockey464 netRockey = new Rockey.NetRockey464();
			netRockey.fechaModulo3(ref qyEuv9RU7);
			break;
		}
		case 5:
		{
			Rockey.Rockey4ND32 rockey4ND = new Rockey.Rockey4ND32();
			rockey4ND.fechaModulo3(ref qyEuv9RU7);
			break;
		}
		}
	}

	private static void zBJVmyF3b(object P_0, EventArgs P_1)
	{
		bool flag = false;
		switch (qyEuv9RU7.tipo)
		{
		case 6:
		{
			Rockey.Rockey4ND64 rockey4ND2 = new Rockey.Rockey4ND64();
			flag = rockey4ND2.checaModulo3(ref qyEuv9RU7);
			break;
		}
		case 1:
		{
			Rockey.Rockey432 rockey2 = new Rockey.Rockey432();
			flag = rockey2.checaModulo3(ref qyEuv9RU7);
			break;
		}
		case 2:
		{
			Rockey.Rockey464 rockey = new Rockey.Rockey464();
			flag = rockey.checaModulo3(ref qyEuv9RU7);
			break;
		}
		case 3:
		{
			Rockey.NetRockey432 netRockey2 = new Rockey.NetRockey432();
			flag = netRockey2.checaModulo3(ref qyEuv9RU7);
			break;
		}
		case 4:
		{
			Rockey.NetRockey464 netRockey = new Rockey.NetRockey464();
			flag = netRockey.checaModulo3(ref qyEuv9RU7);
			break;
		}
		case 5:
		{
			Rockey.Rockey4ND32 rockey4ND = new Rockey.Rockey4ND32();
			flag = rockey4ND.checaModulo3(ref qyEuv9RU7);
			break;
		}
		}
		if (flag)
		{
			t.Interval = 60000.0;
			t.Enabled = true;
			return;
		}
		t.Enabled = false;
		new wHardlock();
		t.Interval = 4000.0;
		t.Enabled = true;
	}
}

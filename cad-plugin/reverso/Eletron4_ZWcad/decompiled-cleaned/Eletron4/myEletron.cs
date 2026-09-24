using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Windows;
using Eletron4.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using ZwSoft.Windows;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.Runtime;

namespace Eletron4;

public class myEletron : IExtensionApplication
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static DocumentCollectionEventHandler _0024IR3_002D1;

		public static DocumentCollectionEventHandler _0024IR3_002D2;

		public static DocumentDestroyedEventHandler _0024IR3_002D3;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		[DebuggerHidden]
		internal void _Lambda_0024__R3_002D1(object a0, DocumentCollectionEventArgs a1)
		{
			EventosDOC.criaDocumento();
		}

		[SpecialName]
		[DebuggerHidden]
		internal void _Lambda_0024__R3_002D2(object a0, DocumentCollectionEventArgs a1)
		{
			EventosDOC.AtivaDocumento();
		}

		[SpecialName]
		[DebuggerHidden]
		internal void _Lambda_0024__R3_002D3(object a0, DocumentDestroyedEventArgs a1)
		{
			EventosDOC.fechaDocumento();
		}
	}

	public static Timer t;

	static myEletron()
	{
		t = new Timer();
	}

	public void Initialize()
	{
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0361: Expected Obj, but got Unknown
		//IL_0363: Expected Obj, but got Unknown
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Expected Obj, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Expected Obj, but got Unknown
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Expected Obj, but got Unknown
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Expected Obj, but got Unknown
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Expected Obj, but got Unknown
		try
		{
			if (ComponentManager.Ribbon != null)
			{
				if (!((UIElement)(object)ComponentManager.Ribbon).IsVisible)
				{
					Interaction.MsgBox("Nenhum Ribbon ativo! / No Ribbon active!", MsgBoxStyle.Information, "Elétron");
					return;
				}
				DeclaracoesGeral.ConfElet.Idioma = "[PT]";
				RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\\\Cadgraph\\\\Eletron4", writable: true);
				if (registryKey != null)
				{
					DeclaracoesGeral.ConfElet.Idioma = Conversions.ToString(registryKey.GetValue("Idioma", ""));
				}
				else
				{
					registryKey = Registry.CurrentUser.CreateSubKey("Software\\\\Cadgraph\\\\Eletron4");
					registryKey.SetValue("Idioma", DeclaracoesGeral.ConfElet.Idioma);
				}
				registryKey.Close();
				Mensagem mensagem = new Mensagem();
				mensagem.CarregaMensagens();
				DeclaracoesGeral.LicModeSel = 0;
				if (MySettingsProperty.Settings.LicMode != 0)
				{
					if (MySettingsProperty.Settings.LicMode != 1)
					{
						if (MySettingsProperty.Settings.LicMode != 2)
						{
							if (MySettingsProperty.Settings.LicMode == 4)
							{
								DeclaracoesGeral.LicModeSel = 4;
							}
						}
						else
						{
							DeclaracoesGeral.LicModeSel = 2;
						}
					}
					else
					{
						DeclaracoesGeral.LicModeSel = 1;
					}
				}
				else
				{
					new frmCarregaEL();
				}
				bool flag = false;
				DocumentCollection documentManager;
				DocumentCollectionEventHandler val2;
				DocumentCollection documentManager2;
				DocumentCollectionEventHandler val4;
				DocumentCollection documentManager3;
				DocumentDestroyedEventHandler val6;
				switch (DeclaracoesGeral.LicModeSel)
				{
				case 4:
				{
					cCheckNuvem cCheckNuvem2 = new cCheckNuvem();
					cCheckNuvem2.verificaLic();
					if (!cCheckNuvem2.bApp)
					{
						if (!cCheckNuvem2.bTrial)
						{
							if (!cCheckNuvem2.bAbreRegistro)
							{
								Interaction.MsgBox(cCheckNuvem2.msg, MsgBoxStyle.Information);
								clsUtilitarios.limpaComandos();
								break;
							}
							FormRegNuvem formRegNuvem = new FormRegNuvem();
							formRegNuvem.ShowDialog();
							if (!formRegNuvem.bInstalou)
							{
								clsUtilitarios.limpaComandos();
								break;
							}
							flag = true;
						}
						else
						{
							Interaction.MsgBox(cCheckNuvem2.msg, MsgBoxStyle.Information);
							flag = true;
						}
					}
					else
					{
						flag = true;
					}
					goto IL_01c3;
				}
				case 1:
					cCheckLicRockey.verificaRockey();
					if (!DeclaracoesGeral.app)
					{
						clsUtilitarios.limpaComandos();
						break;
					}
					goto IL_01c3;
				case 2:
				{
					cCheckElecKey cCheckElecKey2 = new cCheckElecKey();
					cCheckElecKey2.verificaElecKey();
					if (!cCheckElecKey2.bApp)
					{
						Interaction.MsgBox(cCheckElecKey2.msg, MsgBoxStyle.Information);
						clsUtilitarios.limpaComandos();
						break;
					}
					goto IL_01c3;
				}
				default:
					{
						clsUtilitarios.limpaComandos();
						break;
					}
					IL_01c3:
					Iniciar.IniciarApp();
					Iniciar.IniciarDWG();
					documentManager = Application.DocumentManager;
					if (_Closure_0024__._0024IR3_002D1 == null)
					{
						DocumentCollectionEventHandler val = [SpecialName] [DebuggerHidden] (object a0, DocumentCollectionEventArgs a1) =>
						{
							EventosDOC.criaDocumento();
						};
						_Closure_0024__._0024IR3_002D1 = val;
						val2 = val;
					}
					else
					{
						val2 = _Closure_0024__._0024IR3_002D1;
					}
					documentManager.DocumentCreated += val2;
					documentManager2 = Application.DocumentManager;
					if (_Closure_0024__._0024IR3_002D2 == null)
					{
						DocumentCollectionEventHandler val3 = [SpecialName] [DebuggerHidden] (object a0, DocumentCollectionEventArgs a1) =>
						{
							EventosDOC.AtivaDocumento();
						};
						_Closure_0024__._0024IR3_002D2 = val3;
						val4 = val3;
					}
					else
					{
						val4 = _Closure_0024__._0024IR3_002D2;
					}
					documentManager2.DocumentActivated += val4;
					documentManager3 = Application.DocumentManager;
					if (_Closure_0024__._0024IR3_002D3 == null)
					{
						DocumentDestroyedEventHandler val5 = [SpecialName] [DebuggerHidden] (object a0, DocumentDestroyedEventArgs a1) =>
						{
							EventosDOC.fechaDocumento();
						};
						_Closure_0024__._0024IR3_002D3 = val5;
						val6 = val5;
					}
					else
					{
						val6 = _Closure_0024__._0024IR3_002D3;
					}
					documentManager3.DocumentDestroyed += val6;
					Application.DocumentManager.DocumentLockModeWillChange += EventosDOC.WillLockCommand;
					Application.SystemVariableChanged += EventosDOC.trocaColorSchema;
					if (flag)
					{
						t.Interval = 20000.0;
						t.Enabled = true;
						t.Elapsed += TimerEventHandler;
					}
					break;
				}
			}
			else
			{
				Interaction.MsgBox("Nenhum Ribbon ativo! / No Ribbon active!", MsgBoxStyle.Information, "Elétron");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError((Exception)ex);
			Exception ex2 = ex;
			Interaction.MsgBox(((Exception)(object)ex2).Message, MsgBoxStyle.Critical, "Elétron");
			ProjectData.ClearProjectError();
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			Interaction.MsgBox(ex4.Message, MsgBoxStyle.Critical, "Elétron");
			ProjectData.ClearProjectError();
		}
		finally
		{
		}
	}

	public static void TimerEventHandler(object obj, EventArgs ergs)
	{
		bool flag = false;
		DeclaracoesGeral.structureUserPC structureUserPC = default;
		RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\\\W64c\\\\Elk", writable: false);
		if (registryKey != null)
		{
			structureUserPC.Licenca = Conversions.ToString(registryKey.GetValue("CL3", ""));
			if (Operators.CompareString(structureUserPC.Licenca.Trim(), "", TextCompare: true) != 0)
			{
				flag = true;
			}
			registryKey.Close();
		}
		if (flag)
		{
			t.Interval = 20000.0;
			t.Enabled = true;
			return;
		}
		t.Enabled = false;
		new WNuvem();
		t.Interval = 4000.0;
		t.Enabled = true;
	}

	public void Terminate()
	{
		if (DeclaracoesGeral.LicModeSel == 4 && MySettingsProperty.Settings.DesinstalarAut)
		{
			cCheckNuvem cCheckNuvem2 = new cCheckNuvem();
			cCheckNuvem2.DesregistraNuvemAut();
		}
	}
}

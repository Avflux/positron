using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Eletron4.My;
using Eletron4.My.Resources;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.Windows;
using ZwSoft.ZwCAD.ApplicationServices.Core;

namespace Eletron4;

public class Ribbon
{
	private Version R99p17GO0HF;

	public Ribbon()
	{
		R99p17GO0HF = Application.Version;
	}

	public void RemoveRibbon()
	{
		RibbonControl ribbon = ComponentManager.Ribbon;
		checked
		{
			int num = ((Collection<RibbonTab>)(object)ribbon.Tabs).Count - 1;
			int num2 = 0;
			while (true)
			{
				if (num2 <= num)
				{
					if (((Collection<RibbonTab>)(object)ribbon.Tabs)[num2].Id.Equals("CENG.ID_Elet"))
					{
						break;
					}
					num2++;
					continue;
				}
				return;
			}
			((Collection<RibbonTab>)(object)ribbon.Tabs).Remove(((Collection<RibbonTab>)(object)ribbon.Tabs)[num2]);
		}
	}

	public void CreateRibbon()
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected Obj, but got Unknown
		RibbonControl ribbon = ComponentManager.Ribbon;
		checked
		{
			int num = ((Collection<RibbonTab>)(object)ribbon.Tabs).Count - 1;
			int num2 = 0;
			while (true)
			{
				if (num2 <= num)
				{
					if (!((Collection<RibbonTab>)(object)ribbon.Tabs)[num2].Id.Equals("CENG.ID_Elet"))
					{
						num2++;
						continue;
					}
					break;
				}
				DeclaracoesGeral.indexRibbon = ((Collection<RibbonTab>)(object)ribbon.Tabs).Count;
				RibbonTab val = new RibbonTab();
				val.Title = "Elétron";
				val.Id = "CENG.ID_Elet";
				((Collection<RibbonTab>)(object)ribbon.Tabs).Add(val);
				val.IsActive = true;
				TSfp1Hv8Fcw(val);
				sqNp1kxf3Uh(val);
				break;
			}
		}
	}

	public void CreateRibbon2()
	{
		RibbonControl ribbon = ComponentManager.Ribbon;
		checked
		{
			int num = ((Collection<RibbonTab>)(object)ribbon.Tabs).Count - 1;
			int num2 = 0;
			while (true)
			{
				if (num2 <= num)
				{
					if (((Collection<RibbonTab>)(object)ribbon.Tabs)[num2].Id.Equals("CENG.ID_Elet"))
					{
						break;
					}
					num2++;
					continue;
				}
				return;
			}
			RibbonTab val = ((Collection<RibbonTab>)(object)ribbon.Tabs)[num2];
			val.IsActive = true;
			Xcxp1ds9OPI(val);
			fJdp1fB9M7a(val);
			RuZp1DKCh0P(val);
			qGpp1vUUxZV(val);
			HEpp169Agfo(val);
			E74p1tC6alM(val);
			vwCp1jIpDXj(val);
			PointMonitorToolTips.StartMonitor();
		}
	}

	private void TSfp1Hv8Fcw(RibbonTab P_0)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected Obj, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected Obj, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected Obj, but got Unknown
		RibbonPanelSource val = new RibbonPanelSource();
		val.Title = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 111]);
		RibbonPanel val2 = new RibbonPanel();
		val2.Source = val;
		((Collection<RibbonPanel>)(object)P_0.Panels).Add(val2);
		Bitmap image = null;
		int num = 1;
		if (R99p17GO0HF.Major >= 20)
		{
			num = Conversions.ToInteger(Application.GetSystemVariable("COLORTHEME"));
		}
		RibbonButton val3 = new RibbonButton();
		string text = "";
		if (num == 0)
		{
			image = Resources.Setup_32_Dark;
		}
		if (num == 1)
		{
			image = Resources.Setup_32;
		}
		Nowp1LGUQxQ(ref val3, "Elétron v26.03\r\n" + DeclaracoesGeral.companyHardlock, "", getBitmap(image), text);
		((RibbonCommandItem)val3).IsActive = false;
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)(object)val3);
		RibbonButton val4 = new RibbonButton();
		((RibbonCommandItem)val4).CommandParameter = "CFG ";
		((RibbonItem)val4).ShowText = true;
		((RibbonItem)val4).ShowImage = true;
		((RibbonCommandItem)val4).CommandHandler = new AdskCommandHandler();
		val.DialogLauncher = (RibbonCommandItem)(object)val4;
	}

	private void sqNp1kxf3Uh(RibbonTab P_0)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected Obj, but got Unknown
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected Obj, but got Unknown
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected Obj, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Expected Obj, but got Unknown
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Expected Obj, but got Unknown
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Expected Obj, but got Unknown
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Expected Obj, but got Unknown
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Expected Obj, but got Unknown
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Expected Obj, but got Unknown
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Expected Obj, but got Unknown
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Expected Obj, but got Unknown
		//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Expected Obj, but got Unknown
		//IL_0322: Unknown result type (might be due to invalid IL or missing references)
		//IL_032c: Expected Obj, but got Unknown
		//IL_032c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0333: Expected Obj, but got Unknown
		//IL_038a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0394: Expected Obj, but got Unknown
		//IL_0394: Unknown result type (might be due to invalid IL or missing references)
		//IL_039b: Expected Obj, but got Unknown
		//IL_03f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fc: Expected Obj, but got Unknown
		//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0403: Expected Obj, but got Unknown
		//IL_045a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0464: Expected Obj, but got Unknown
		//IL_0464: Unknown result type (might be due to invalid IL or missing references)
		//IL_046b: Expected Obj, but got Unknown
		//IL_04c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cc: Expected Obj, but got Unknown
		//IL_04cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d3: Expected Obj, but got Unknown
		//IL_052a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0534: Expected Obj, but got Unknown
		//IL_0534: Unknown result type (might be due to invalid IL or missing references)
		//IL_053b: Expected Obj, but got Unknown
		//IL_0592: Unknown result type (might be due to invalid IL or missing references)
		//IL_059c: Expected Obj, but got Unknown
		//IL_059c: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a3: Expected Obj, but got Unknown
		RibbonPanelSource val = new RibbonPanelSource();
		val.Title = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 109]);
		RibbonPanel val2 = new RibbonPanel();
		val2.Source = val;
		((Collection<RibbonPanel>)(object)P_0.Panels).Add(val2);
		Bitmap image = null;
		int num = 1;
		if (R99p17GO0HF.Major >= 20)
		{
			num = Conversions.ToInteger(Application.GetSystemVariable("COLORTHEME"));
		}
		RibbonButton item = new RibbonButton();
		if (num == 0)
		{
			image = Resources.Caderno_32;
		}
		if (num == 1)
		{
			image = Resources.Caderno_32;
		}
		IsVp1wK9F5x(ref item, "CADERNO", "CAD ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 123]));
		RibbonButton item2 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.Database_Branco_32;
		}
		if (num == 1)
		{
			image = Resources.Database_Preto_32;
		}
		IsVp1wK9F5x(ref item2, "GER DWG", "GERDWG ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 122]));
		RibbonButton item3 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.ReguaH_32_Dark;
		}
		if (num == 1)
		{
			image = Resources.ReguaH_32;
		}
		IsVp1wK9F5x(ref item3, "REGUAH", "REGH ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 124]));
		RibbonButton item4 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.ReguaV_32_Dark;
		}
		if (num == 1)
		{
			image = Resources.ReguaV_32;
		}
		IsVp1wK9F5x(ref item4, "REGUAV", "REGV ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 125]));
		RibbonRowPanel val3 = new RibbonRowPanel();
		((Collection<RibbonItem>)(object)val3.Items).Add((RibbonItem)(object)item);
		((Collection<RibbonItem>)(object)val3.Items).Add((RibbonItem)new RibbonRowBreak());
		((Collection<RibbonItem>)(object)val3.Items).Add((RibbonItem)(object)item2);
		RibbonRowPanel val4 = new RibbonRowPanel();
		((Collection<RibbonItem>)(object)val4.Items).Add((RibbonItem)(object)item3);
		((Collection<RibbonItem>)(object)val4.Items).Add((RibbonItem)new RibbonRowBreak());
		((Collection<RibbonItem>)(object)val4.Items).Add((RibbonItem)(object)item4);
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)(object)val3);
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)(object)val4);
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)new RibbonPanelBreak());
		RibbonRowPanel val5 = new RibbonRowPanel();
		RibbonButton item5 = new RibbonButton();
		PVGp1btLkXV(ref item5, "PN ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 531]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 531]));
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)(object)item5);
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item6 = new RibbonButton();
		PVGp1btLkXV(ref item6, "TROCAPN ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1015]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1015]));
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)(object)item6);
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item7 = new RibbonButton();
		PVGp1btLkXV(ref item7, "DUPCAD ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1377]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1377]));
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)(object)item7);
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item8 = new RibbonButton();
		PVGp1btLkXV(ref item8, "IMPBD ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 598]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 598]));
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)(object)item8);
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item9 = new RibbonButton();
		PVGp1btLkXV(ref item9, "INDPG ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 155]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 155]));
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)(object)item9);
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item10 = new RibbonButton();
		PVGp1btLkXV(ref item10, "RELREV ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1673]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1673]));
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)(object)item10);
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item11 = new RibbonButton();
		PVGp1btLkXV(ref item11, "RELREVF ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1862]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1862]));
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)(object)item11);
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item12 = new RibbonButton();
		PVGp1btLkXV(ref item12, "RELMATRI ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1912]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1912]));
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)(object)item12);
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item13 = new RibbonButton();
		PVGp1btLkXV(ref item13, "HBASE ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1760]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1760]));
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)(object)item13);
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)(object)val5);
	}

	private RibbonPanelSource Xcxp1ds9OPI(RibbonTab P_0)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected Obj, but got Unknown
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected Obj, but got Unknown
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected Obj, but got Unknown
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected Obj, but got Unknown
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected Obj, but got Unknown
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Expected Obj, but got Unknown
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Expected Obj, but got Unknown
		//IL_0285: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Expected Obj, but got Unknown
		//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ce: Expected Obj, but got Unknown
		//IL_0309: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Expected Obj, but got Unknown
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0352: Expected Obj, but got Unknown
		//IL_038d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0394: Expected Obj, but got Unknown
		//IL_0502: Unknown result type (might be due to invalid IL or missing references)
		//IL_0509: Expected Obj, but got Unknown
		//IL_051e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0528: Expected Obj, but got Unknown
		//IL_0536: Unknown result type (might be due to invalid IL or missing references)
		//IL_053d: Expected Obj, but got Unknown
		//IL_0552: Unknown result type (might be due to invalid IL or missing references)
		//IL_055c: Expected Obj, but got Unknown
		//IL_056a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0571: Expected Obj, but got Unknown
		//IL_0586: Unknown result type (might be due to invalid IL or missing references)
		//IL_0590: Expected Obj, but got Unknown
		//IL_059e: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a5: Expected Obj, but got Unknown
		//IL_05ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c4: Expected Obj, but got Unknown
		//IL_05c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cb: Expected Obj, but got Unknown
		//IL_05e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ea: Expected Obj, but got Unknown
		//IL_05ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0609: Expected Obj, but got Unknown
		//IL_0617: Unknown result type (might be due to invalid IL or missing references)
		//IL_061e: Expected Obj, but got Unknown
		//IL_0633: Unknown result type (might be due to invalid IL or missing references)
		//IL_063d: Expected Obj, but got Unknown
		//IL_0652: Unknown result type (might be due to invalid IL or missing references)
		//IL_065c: Expected Obj, but got Unknown
		//IL_06a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ae: Expected Obj, but got Unknown
		//IL_06ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d8: Expected Obj, but got Unknown
		//IL_06d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06df: Expected Obj, but got Unknown
		//IL_06df: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e6: Expected Obj, but got Unknown
		//IL_073d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0747: Expected Obj, but got Unknown
		//IL_0747: Unknown result type (might be due to invalid IL or missing references)
		//IL_074e: Expected Obj, but got Unknown
		//IL_07a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07af: Expected Obj, but got Unknown
		//IL_07af: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b6: Expected Obj, but got Unknown
		//IL_080d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0817: Expected Obj, but got Unknown
		//IL_0817: Unknown result type (might be due to invalid IL or missing references)
		//IL_081e: Expected Obj, but got Unknown
		//IL_0875: Unknown result type (might be due to invalid IL or missing references)
		//IL_087f: Expected Obj, but got Unknown
		//IL_087f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0886: Expected Obj, but got Unknown
		//IL_08dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e7: Expected Obj, but got Unknown
		//IL_08e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ee: Expected Obj, but got Unknown
		//IL_0945: Unknown result type (might be due to invalid IL or missing references)
		//IL_094f: Expected Obj, but got Unknown
		//IL_094f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0956: Expected Obj, but got Unknown
		//IL_09ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b7: Expected Obj, but got Unknown
		//IL_09b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_09be: Expected Obj, but got Unknown
		//IL_0a15: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1f: Expected Obj, but got Unknown
		//IL_0a1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a26: Expected Obj, but got Unknown
		//IL_0a7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a87: Expected Obj, but got Unknown
		//IL_0a87: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a8e: Expected Obj, but got Unknown
		//IL_0ae5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aef: Expected Obj, but got Unknown
		//IL_0aef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af6: Expected Obj, but got Unknown
		//IL_0b4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b57: Expected Obj, but got Unknown
		RibbonPanelSource val = new RibbonPanelSource();
		val.Title = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 110]);
		RibbonPanel val2 = new RibbonPanel();
		val2.Source = val;
		((Collection<RibbonPanel>)(object)P_0.Panels).Add(val2);
		Bitmap image = null;
		int num = 1;
		if (R99p17GO0HF.Major >= 20)
		{
			num = Conversions.ToInteger(Application.GetSystemVariable("COLORTHEME"));
		}
		RibbonButton item = new RibbonButton();
		if (num == 0)
		{
			image = Resources.GerContatos_32_Dark;
		}
		if (num == 1)
		{
			image = Resources.GerContatos_32;
		}
		IsVp1wK9F5x(ref item, "GERCONT", "GERCONT ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 522]));
		RibbonButton item2 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.GerMascaras_32_Dark;
		}
		if (num == 1)
		{
			image = Resources.GerMascaras_32;
		}
		IsVp1wK9F5x(ref item2, "GERMASC", "GERMASC ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 523]));
		RibbonButton item3 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.Dispositivos_32_Dark;
		}
		if (num == 1)
		{
			image = Resources.Dispositivos_32;
		}
		IsVp1wK9F5x(ref item3, "DISP", "DISP ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 518]));
		RibbonButton item4 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.Portas_32_Dark;
		}
		if (num == 1)
		{
			image = Resources.Portas_32;
		}
		IsVp1wK9F5x(ref item4, "PORTA", "PORT ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 520]));
		RibbonButton item5 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.Contatos_32_Dark;
		}
		if (num == 1)
		{
			image = Resources.Contatos_32;
		}
		IsVp1wK9F5x(ref item5, "CONTATO", "CONT ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 519]));
		RibbonButton item6 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.Definicao_32_Dark;
		}
		if (num == 1)
		{
			image = Resources.Definicao_32;
		}
		IsVp1wK9F5x(ref item6, "DEFINIÇÃO", "DEF ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 521]));
		RibbonButton item7 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.Excel_32_Dark;
		}
		if (num == 1)
		{
			image = Resources.Excel_32;
		}
		IsVp1wK9F5x(ref item7, "LXLS", "LXLS ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1941]));
		RibbonButton item8 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.Mascara_16_Dark;
		}
		if (num == 1)
		{
			image = Resources.Mascara_16;
		}
		UCHp1xnMtMs(ref item8, "MASC ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 524]));
		RibbonButton item9 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.LigaDesligaAtributos_16_Dark;
		}
		if (num == 1)
		{
			image = Resources.LigaDesligaAtributos_16;
		}
		UCHp1xnMtMs(ref item9, "LDAT ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 527]));
		RibbonButton item10 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.Pincel2_16_Dark;
		}
		if (num == 1)
		{
			image = Resources.Pincel2_16;
		}
		UCHp1xnMtMs(ref item10, "PINC ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 528]));
		RibbonButton item11 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.MoverPainel_16_Dark;
		}
		if (num == 1)
		{
			image = Resources.MoverPainel_16;
		}
		UCHp1xnMtMs(ref item11, "MOVPN ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 530]));
		RibbonButton item12 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.DePara_16_Dark;
		}
		if (num == 1)
		{
			image = Resources.DePara_16;
		}
		UCHp1xnMtMs(ref item12, "DEPARA ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 551]));
		RibbonButton item13 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.Sincronizar_16_Dark;
		}
		if (num == 1)
		{
			image = Resources.Sincronizar_16;
		}
		UCHp1xnMtMs(ref item13, "SYNCD ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 810]));
		RibbonRowPanel val3 = new RibbonRowPanel();
		((Collection<RibbonItem>)(object)val3.Items).Add((RibbonItem)(object)item);
		((Collection<RibbonItem>)(object)val3.Items).Add((RibbonItem)new RibbonRowBreak());
		((Collection<RibbonItem>)(object)val3.Items).Add((RibbonItem)(object)item2);
		RibbonRowPanel val4 = new RibbonRowPanel();
		((Collection<RibbonItem>)(object)val4.Items).Add((RibbonItem)(object)item3);
		((Collection<RibbonItem>)(object)val4.Items).Add((RibbonItem)new RibbonRowBreak());
		((Collection<RibbonItem>)(object)val4.Items).Add((RibbonItem)(object)item4);
		RibbonRowPanel val5 = new RibbonRowPanel();
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)(object)item5);
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)new RibbonRowBreak());
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)(object)item6);
		RibbonRowPanel val6 = new RibbonRowPanel();
		((Collection<RibbonItem>)(object)val6.Items).Add((RibbonItem)(object)item7);
		((Collection<RibbonItem>)(object)val6.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonRowPanel val7 = new RibbonRowPanel();
		((Collection<RibbonItem>)(object)val7.Items).Add((RibbonItem)(object)item8);
		((Collection<RibbonItem>)(object)val7.Items).Add((RibbonItem)new RibbonRowBreak());
		((Collection<RibbonItem>)(object)val7.Items).Add((RibbonItem)(object)item9);
		((Collection<RibbonItem>)(object)val7.Items).Add((RibbonItem)new RibbonRowBreak());
		((Collection<RibbonItem>)(object)val7.Items).Add((RibbonItem)(object)item10);
		RibbonRowPanel val8 = new RibbonRowPanel();
		((Collection<RibbonItem>)(object)val8.Items).Add((RibbonItem)(object)item11);
		((Collection<RibbonItem>)(object)val8.Items).Add((RibbonItem)new RibbonRowBreak());
		((Collection<RibbonItem>)(object)val8.Items).Add((RibbonItem)(object)item12);
		((Collection<RibbonItem>)(object)val8.Items).Add((RibbonItem)new RibbonRowBreak());
		((Collection<RibbonItem>)(object)val8.Items).Add((RibbonItem)(object)item13);
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)(object)val3);
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)(object)val4);
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)(object)val5);
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)(object)val6);
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)new RibbonSeparator());
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)(object)val7);
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)(object)val8);
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)new RibbonPanelBreak());
		RibbonRowPanel val9 = new RibbonRowPanel();
		RibbonButton item14 = new RibbonButton();
		PVGp1btLkXV(ref item14, "CONFLP ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 532]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 532]));
		((Collection<RibbonItem>)(object)val9.Items).Add((RibbonItem)(object)item14);
		((Collection<RibbonItem>)(object)val9.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item15 = new RibbonButton();
		PVGp1btLkXV(ref item15, "CHVAUT ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 536]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 536]));
		((Collection<RibbonItem>)(object)val9.Items).Add((RibbonItem)(object)item15);
		((Collection<RibbonItem>)(object)val9.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item16 = new RibbonButton();
		PVGp1btLkXV(ref item16, "ADDDESC ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 535]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 535]));
		((Collection<RibbonItem>)(object)val9.Items).Add((RibbonItem)(object)item16);
		((Collection<RibbonItem>)(object)val9.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item17 = new RibbonButton();
		PVGp1btLkXV(ref item17, "SYNCLP ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1014]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1014]));
		((Collection<RibbonItem>)(object)val9.Items).Add((RibbonItem)(object)item17);
		((Collection<RibbonItem>)(object)val9.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item18 = new RibbonButton();
		PVGp1btLkXV(ref item18, "MIGPOR ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 539]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 539]));
		((Collection<RibbonItem>)(object)val9.Items).Add((RibbonItem)(object)item18);
		((Collection<RibbonItem>)(object)val9.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item19 = new RibbonButton();
		PVGp1btLkXV(ref item19, "MCONT ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1656]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1656]));
		((Collection<RibbonItem>)(object)val9.Items).Add((RibbonItem)(object)item19);
		((Collection<RibbonItem>)(object)val9.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item20 = new RibbonButton();
		PVGp1btLkXV(ref item20, "MMASC ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1640]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1640]));
		((Collection<RibbonItem>)(object)val9.Items).Add((RibbonItem)(object)item20);
		((Collection<RibbonItem>)(object)val9.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item21 = new RibbonButton();
		PVGp1btLkXV(ref item21, "EDTFUNC ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1676]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1676]));
		((Collection<RibbonItem>)(object)val9.Items).Add((RibbonItem)(object)item21);
		((Collection<RibbonItem>)(object)val9.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item22 = new RibbonButton();
		PVGp1btLkXV(ref item22, "EDTDISPS ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1602]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1602]));
		((Collection<RibbonItem>)(object)val9.Items).Add((RibbonItem)(object)item22);
		((Collection<RibbonItem>)(object)val9.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item23 = new RibbonButton();
		PVGp1btLkXV(ref item23, "EDTDISPSA ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1688]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1688]));
		((Collection<RibbonItem>)(object)val9.Items).Add((RibbonItem)(object)item23);
		((Collection<RibbonItem>)(object)val9.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item24 = new RibbonButton();
		PVGp1btLkXV(ref item24, "RELEKTRO ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1674]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1674]));
		((Collection<RibbonItem>)(object)val9.Items).Add((RibbonItem)(object)item24);
		((Collection<RibbonItem>)(object)val9.Items).Add((RibbonItem)new RibbonRowBreak());
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)(object)val9);
		return val;
	}

	private RibbonPanelSource fJdp1fB9M7a(RibbonTab P_0)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected Obj, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected Obj, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected Obj, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected Obj, but got Unknown
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Expected Obj, but got Unknown
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected Obj, but got Unknown
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Expected Obj, but got Unknown
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Expected Obj, but got Unknown
		//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ed: Expected Obj, but got Unknown
		//IL_0302: Unknown result type (might be due to invalid IL or missing references)
		//IL_030c: Expected Obj, but got Unknown
		//IL_031a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Expected Obj, but got Unknown
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Expected Obj, but got Unknown
		//IL_034e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0355: Expected Obj, but got Unknown
		//IL_036a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0374: Expected Obj, but got Unknown
		//IL_0389: Unknown result type (might be due to invalid IL or missing references)
		//IL_0393: Expected Obj, but got Unknown
		//IL_03ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d8: Expected Obj, but got Unknown
		//IL_03d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03df: Expected Obj, but got Unknown
		//IL_03df: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e6: Expected Obj, but got Unknown
		//IL_043d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0447: Expected Obj, but got Unknown
		//IL_0447: Unknown result type (might be due to invalid IL or missing references)
		//IL_044e: Expected Obj, but got Unknown
		//IL_04a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04af: Expected Obj, but got Unknown
		RibbonPanelSource val = new RibbonPanelSource();
		val.Title = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 540]);
		RibbonPanel val2 = new RibbonPanel();
		val2.Source = val;
		((Collection<RibbonPanel>)(object)P_0.Panels).Add(val2);
		Bitmap image = null;
		int num = 1;
		if (R99p17GO0HF.Major >= 20)
		{
			num = Conversions.ToInteger(Application.GetSystemVariable("COLORTHEME"));
		}
		RibbonButton item = new RibbonButton();
		if (num == 0)
		{
			image = Resources.ReguaBorne_32_Dark;
		}
		if (num == 1)
		{
			image = Resources.ReguaBorne_32;
		}
		IsVp1wK9F5x(ref item, "GERRB", "GERRB ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 541]));
		RibbonButton item2 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.Bornes_32_Dark;
		}
		if (num == 1)
		{
			image = Resources.Bornes_32;
		}
		IsVp1wK9F5x(ref item2, "BORNE", "BORN ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 542]));
		RibbonButton item3 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.Editar_Branco_32;
		}
		if (num == 1)
		{
			image = Resources.Editar_Preto_32;
		}
		IsVp1wK9F5x(ref item3, "EDBORN", "EDBORN ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 543]));
		RibbonButton item4 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.EditaBornesSelecao_32_Dark;
		}
		if (num == 1)
		{
			image = Resources.EditaBornesSelecao_32;
		}
		IsVp1wK9F5x(ref item4, "SELBORN", "SELBORN ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1346]));
		RibbonButton item5 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.LigaDesligaAtributos_16_Dark;
		}
		if (num == 1)
		{
			image = Resources.LigaDesligaAtributos_16;
		}
		UCHp1xnMtMs(ref item5, "LDNR ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 544]));
		RibbonButton item6 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.OcultaPainelBorne_16_Dark;
		}
		if (num == 1)
		{
			image = Resources.OcultaPainelBorne_16;
		}
		UCHp1xnMtMs(ref item6, "OCPN ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 545]));
		RibbonButton item7 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.Estatistica_16_Dark;
		}
		if (num == 1)
		{
			image = Resources.Estatistica_16;
		}
		UCHp1xnMtMs(ref item7, "STATBORN ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 546]));
		RibbonRowPanel val3 = new RibbonRowPanel();
		((Collection<RibbonItem>)(object)val3.Items).Add((RibbonItem)(object)item);
		((Collection<RibbonItem>)(object)val3.Items).Add((RibbonItem)new RibbonRowBreak());
		((Collection<RibbonItem>)(object)val3.Items).Add((RibbonItem)(object)item2);
		RibbonRowPanel val4 = new RibbonRowPanel();
		((Collection<RibbonItem>)(object)val4.Items).Add((RibbonItem)(object)item3);
		((Collection<RibbonItem>)(object)val4.Items).Add((RibbonItem)new RibbonRowBreak());
		((Collection<RibbonItem>)(object)val4.Items).Add((RibbonItem)(object)item4);
		RibbonRowPanel val5 = new RibbonRowPanel();
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)(object)item5);
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)new RibbonRowBreak());
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)(object)item6);
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)new RibbonRowBreak());
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)(object)item7);
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)(object)val3);
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)(object)val4);
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)(object)val5);
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)new RibbonPanelBreak());
		RibbonRowPanel val6 = new RibbonRowPanel();
		RibbonButton item8 = new RibbonButton();
		PVGp1btLkXV(ref item8, "MBOR ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1071]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1973]));
		((Collection<RibbonItem>)(object)val6.Items).Add((RibbonItem)(object)item8);
		((Collection<RibbonItem>)(object)val6.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item9 = new RibbonButton();
		PVGp1btLkXV(ref item9, "CLOBORN ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1588]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1588]));
		((Collection<RibbonItem>)(object)val6.Items).Add((RibbonItem)(object)item9);
		((Collection<RibbonItem>)(object)val6.Items).Add((RibbonItem)new RibbonRowBreak());
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)(object)val6);
		return val;
	}

	private RibbonPanelSource RuZp1DKCh0P(RibbonTab P_0)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected Obj, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected Obj, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected Obj, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected Obj, but got Unknown
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Expected Obj, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Expected Obj, but got Unknown
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected Obj, but got Unknown
		//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Expected Obj, but got Unknown
		//IL_033d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0344: Expected Obj, but got Unknown
		//IL_035c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0363: Expected Obj, but got Unknown
		//IL_037b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0382: Expected Obj, but got Unknown
		//IL_039a: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a1: Expected Obj, but got Unknown
		//IL_03dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e3: Expected Obj, but got Unknown
		//IL_041e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0425: Expected Obj, but got Unknown
		//IL_0460: Unknown result type (might be due to invalid IL or missing references)
		//IL_0467: Expected Obj, but got Unknown
		//IL_04a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a9: Expected Obj, but got Unknown
		//IL_04e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04eb: Expected Obj, but got Unknown
		//IL_0526: Unknown result type (might be due to invalid IL or missing references)
		//IL_052d: Expected Obj, but got Unknown
		//IL_0563: Unknown result type (might be due to invalid IL or missing references)
		//IL_056a: Expected Obj, but got Unknown
		//IL_05ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b3: Expected Obj, but got Unknown
		//IL_05f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fc: Expected Obj, but got Unknown
		//IL_063e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0645: Expected Obj, but got Unknown
		//IL_0687: Unknown result type (might be due to invalid IL or missing references)
		//IL_068e: Expected Obj, but got Unknown
		//IL_06d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d7: Expected Obj, but got Unknown
		//IL_0719: Unknown result type (might be due to invalid IL or missing references)
		//IL_0720: Expected Obj, but got Unknown
		//IL_0762: Unknown result type (might be due to invalid IL or missing references)
		//IL_0769: Expected Obj, but got Unknown
		//IL_07ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b2: Expected Obj, but got Unknown
		//IL_0872: Unknown result type (might be due to invalid IL or missing references)
		//IL_0879: Expected Obj, but got Unknown
		//IL_095f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0966: Expected Obj, but got Unknown
		//IL_09a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_09af: Expected Obj, but got Unknown
		//IL_0a0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a14: Expected Obj, but got Unknown
		//IL_0a29: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a33: Expected Obj, but got Unknown
		//IL_0a41: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a48: Expected Obj, but got Unknown
		//IL_0a5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a67: Expected Obj, but got Unknown
		//IL_0a75: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a7c: Expected Obj, but got Unknown
		//IL_0a9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa9: Expected Obj, but got Unknown
		//IL_0b12: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b1c: Expected Obj, but got Unknown
		//IL_0b9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba8: Expected Obj, but got Unknown
		//IL_0bbb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc5: Expected Obj, but got Unknown
		//IL_0bc5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bcc: Expected Obj, but got Unknown
		//IL_0bcc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd3: Expected Obj, but got Unknown
		//IL_0c2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c34: Expected Obj, but got Unknown
		//IL_0c34: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c3b: Expected Obj, but got Unknown
		//IL_0c92: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c9c: Expected Obj, but got Unknown
		//IL_0c9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca3: Expected Obj, but got Unknown
		//IL_0cfa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d04: Expected Obj, but got Unknown
		//IL_0d04: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d0b: Expected Obj, but got Unknown
		//IL_0d62: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d6c: Expected Obj, but got Unknown
		//IL_0d6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d73: Expected Obj, but got Unknown
		//IL_0dca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd4: Expected Obj, but got Unknown
		//IL_0dd4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ddb: Expected Obj, but got Unknown
		//IL_0e32: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e3c: Expected Obj, but got Unknown
		RibbonPanelSource val = new RibbonPanelSource();
		val.Title = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 559]);
		RibbonPanel val2 = new RibbonPanel();
		val2.Source = val;
		((Collection<RibbonPanel>)(object)P_0.Panels).Add(val2);
		Bitmap image = null;
		int num = 1;
		if (R99p17GO0HF.Major >= 20)
		{
			num = Conversions.ToInteger(Application.GetSystemVariable("COLORTHEME"));
		}
		RibbonButton item = new RibbonButton();
		if (num == 0)
		{
			image = Resources.Circuito_32_Dark;
		}
		if (num == 1)
		{
			image = Resources.Circuito_32;
		}
		IsVp1wK9F5x(ref item, "CIRCUITO", "CIRC ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 547]));
		RibbonButton item2 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.ConexaoTT_32_Dark;
		}
		if (num == 1)
		{
			image = Resources.ConexaoTT_32;
		}
		IsVp1wK9F5x(ref item2, "CONEXAO", "CON ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 548]));
		RibbonButton item3 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.ConexaoAuto_32_Dark;
		}
		if (num == 1)
		{
			image = Resources.ConexaoAuto_32;
		}
		IsVp1wK9F5x(ref item3, "CONEXAOAUTO", "CONAUT ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 550]));
		RibbonButton item4 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.DerivacaoAuto_32_Dark;
		}
		if (num == 1)
		{
			image = Resources.DerivacaoAuto_32;
		}
		IsVp1wK9F5x(ref item4, "DERIVACAOAUTO", "DERAUT ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1472]));
		DeclaracoesGeral.ativoRibbon.Secao = MySettingsProperty.Settings.Secao;
		DeclaracoesGeral.ativoRibbon.Cor = MySettingsProperty.Settings.Cor;
		RibbonCombo val3 = new RibbonCombo();
		StringEnumerator enumerator = DeclaracoesGeral.BitolaCollection.GetEnumerator();
		while (enumerator.MoveNext())
		{
			string current = enumerator.Current;
			RibbonItem val4 = new RibbonItem();
			val4.Text = current;
			((RibbonList)val3).Items.Add(val4);
			if (Operators.CompareString(val4.Text, DeclaracoesGeral.ativoRibbon.Secao, TextCompare: true) == 0)
			{
				((RibbonList)val3).Current = val4;
			}
		}
		((RibbonItem)val3).MinWidth = 15.0;
		((RibbonItem)val3).Width = 65.0;
		((RibbonList)val3).DropDownWidth = 65.0;
		((RibbonItem)val3).MaxHeight = double.PositiveInfinity;
		((RibbonItem)val3).Text = "CB1";
		((RibbonItem)val3).ShowText = false;
		val3.IsTextSearchEnabled = true;
		((RibbonList)val3).CurrentChanged += vaOp1I1h7AV;
		RibbonTextBox val5 = new RibbonTextBox();
		((RibbonItem)val5).MinWidth = 15.0;
		((RibbonItem)val5).Width = 54.0;
		val5.TextValue = DeclaracoesGeral.ativoRibbon.Cor;
		val5.IsEmptyTextValid = true;
		val5.AcceptTextOnLostFocus = true;
		val5.InvokesCommand = true;
		val5.CommandHandler = new TextboxCommandHandler();
		RibbonSeparator val6 = new RibbonSeparator();
		((RibbonItem)val6).Width = 3.0;
		val6.SeparatorStyle = (RibbonSeparatorStyle)1;
		RibbonSeparator val7 = new RibbonSeparator();
		((RibbonItem)val7).Width = 21.0;
		val7.SeparatorStyle = (RibbonSeparatorStyle)1;
		RibbonSeparator val8 = new RibbonSeparator();
		((RibbonItem)val8).Width = 30.0;
		val8.SeparatorStyle = (RibbonSeparatorStyle)1;
		RibbonButton item5 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.InsereCor_16_Dark;
		}
		if (num == 1)
		{
			image = Resources.InsereCor_16;
		}
		UCHp1xnMtMs(ref item5, "INSM ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 581]));
		RibbonButton item6 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.EditaSelecao_16_Dark;
		}
		if (num == 1)
		{
			image = Resources.EditaSelecao_16;
		}
		UCHp1xnMtMs(ref item6, "EDCON ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 553]));
		RibbonButton item7 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.Editor_16;
		}
		if (num == 1)
		{
			image = Resources.Editor_16;
		}
		UCHp1xnMtMs(ref item7, "EDCONP ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 554]));
		RibbonButton item8 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.Sincronizar_16_Dark;
		}
		if (num == 1)
		{
			image = Resources.Sincronizar_16;
		}
		UCHp1xnMtMs(ref item8, "SYNCC ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 605]));
		RibbonButton item9 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.Aplicacao2_16_Dark;
		}
		if (num == 1)
		{
			image = Resources.Aplicacao2_16;
		}
		UCHp1xnMtMs(ref item9, "APL ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1816]));
		RibbonButton item10 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.EditarBornes_16_Dark;
		}
		if (num == 1)
		{
			image = Resources.EditarBornes_16;
		}
		UCHp1xnMtMs(ref item10, "EDTNCIRC ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1934]));
		RibbonMenuButton val9 = new RibbonMenuButton();
		if (num == 0)
		{
			image = Resources.Fiacao_16_Dark;
		}
		if (num == 1)
		{
			image = Resources.Fiacao_16;
		}
		hlxp1M9O0Oq(ref val9, getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1546]));
		RibbonMenuItem item11 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item11, "RFIA ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 590]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 590]));
		RibbonMenuItem item12 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item12, "RBORELS ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1657]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1657]));
		RibbonMenuItem item13 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item13, "RPOT ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 820]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 820]));
		RibbonMenuItem item14 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item14, "RPOTS ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1851]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1851]));
		RibbonMenuItem item15 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item15, "RDIF ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 821]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 821]));
		RibbonMenuItem item16 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item16, "DPOT ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1438]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1438]));
		RibbonMenuItem item17 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item17, "RANI ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1509]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1509]));
		RibbonMenuItem item18 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item18, "RTAF ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1928]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1928]));
		RibbonMenuItem item19 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item19, "ESTF ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1482]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1482]));
		((Collection<RibbonItem>)(object)((RibbonListButton)val9).Items).Add((RibbonItem)(object)item11);
		((Collection<RibbonItem>)(object)((RibbonListButton)val9).Items).Add((RibbonItem)(object)item12);
		((Collection<RibbonItem>)(object)((RibbonListButton)val9).Items).Add((RibbonItem)(object)item13);
		((Collection<RibbonItem>)(object)((RibbonListButton)val9).Items).Add((RibbonItem)(object)item14);
		((Collection<RibbonItem>)(object)((RibbonListButton)val9).Items).Add((RibbonItem)(object)item15);
		((Collection<RibbonItem>)(object)((RibbonListButton)val9).Items).Add((RibbonItem)(object)item16);
		((Collection<RibbonItem>)(object)((RibbonListButton)val9).Items).Add((RibbonItem)(object)item17);
		((Collection<RibbonItem>)(object)((RibbonListButton)val9).Items).Add((RibbonItem)(object)item18);
		((Collection<RibbonItem>)(object)((RibbonListButton)val9).Items).Add((RibbonItem)(object)item19);
		RibbonMenuButton val10 = new RibbonMenuButton();
		if (num == 0)
		{
			image = Resources.Topografico_16_Dark;
		}
		if (num == 1)
		{
			image = Resources.Topografico_16;
		}
		hlxp1M9O0Oq(ref val10, getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1547]));
		RibbonMenuItem item20 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item20, "TPG ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 552]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 552]));
		RibbonMenuItem item21 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item21, "ATPG ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 866]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 866]));
		((Collection<RibbonItem>)(object)((RibbonListButton)val10).Items).Add((RibbonItem)(object)item20);
		((Collection<RibbonItem>)(object)((RibbonListButton)val10).Items).Add((RibbonItem)(object)item21);
		RibbonRowPanel val11 = new RibbonRowPanel();
		((Collection<RibbonItem>)(object)val11.Items).Add((RibbonItem)(object)item);
		((Collection<RibbonItem>)(object)val11.Items).Add((RibbonItem)new RibbonRowBreak());
		((Collection<RibbonItem>)(object)val11.Items).Add((RibbonItem)(object)item2);
		RibbonRowPanel val12 = new RibbonRowPanel();
		((Collection<RibbonItem>)(object)val12.Items).Add((RibbonItem)(object)item3);
		((Collection<RibbonItem>)(object)val12.Items).Add((RibbonItem)new RibbonRowBreak());
		((Collection<RibbonItem>)(object)val12.Items).Add((RibbonItem)(object)item4);
		RibbonRowPanel val13 = new RibbonRowPanel();
		((Collection<RibbonItem>)(object)val13.Items).Add((RibbonItem)(object)val3);
		((Collection<RibbonItem>)(object)val13.Items).Add((RibbonItem)(object)val5);
		((Collection<RibbonItem>)(object)val13.Items).Add((RibbonItem)new RibbonRowBreak());
		((Collection<RibbonItem>)(object)val13.Items).Add((RibbonItem)(object)item5);
		((Collection<RibbonItem>)(object)val13.Items).Add((RibbonItem)(object)val6);
		((Collection<RibbonItem>)(object)val13.Items).Add((RibbonItem)(object)item6);
		((Collection<RibbonItem>)(object)val13.Items).Add((RibbonItem)(object)val6);
		((Collection<RibbonItem>)(object)val13.Items).Add((RibbonItem)(object)item9);
		((Collection<RibbonItem>)(object)val13.Items).Add((RibbonItem)(object)val6);
		((Collection<RibbonItem>)(object)val13.Items).Add((RibbonItem)(object)val9);
		((Collection<RibbonItem>)(object)val13.Items).Add((RibbonItem)new RibbonRowBreak());
		((Collection<RibbonItem>)(object)val13.Items).Add((RibbonItem)(object)item7);
		((Collection<RibbonItem>)(object)val13.Items).Add((RibbonItem)(object)val6);
		((Collection<RibbonItem>)(object)val13.Items).Add((RibbonItem)(object)item8);
		((Collection<RibbonItem>)(object)val13.Items).Add((RibbonItem)(object)val6);
		((Collection<RibbonItem>)(object)val13.Items).Add((RibbonItem)(object)item10);
		((Collection<RibbonItem>)(object)val13.Items).Add((RibbonItem)(object)val6);
		((Collection<RibbonItem>)(object)val13.Items).Add((RibbonItem)(object)val10);
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)(object)val11);
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)(object)val12);
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)new RibbonSeparator());
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)(object)val13);
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)new RibbonPanelBreak());
		RibbonRowPanel val14 = new RibbonRowPanel();
		RibbonButton item22 = new RibbonButton();
		PVGp1btLkXV(ref item22, "VFIA ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1637]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1637]));
		((Collection<RibbonItem>)(object)val14.Items).Add((RibbonItem)(object)item22);
		((Collection<RibbonItem>)(object)val14.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item23 = new RibbonButton();
		PVGp1btLkXV(ref item23, "LR ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 556]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 556]));
		((Collection<RibbonItem>)(object)val14.Items).Add((RibbonItem)(object)item23);
		((Collection<RibbonItem>)(object)val14.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item24 = new RibbonButton();
		PVGp1btLkXV(ref item24, "FIA ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 555]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 555]));
		((Collection<RibbonItem>)(object)val14.Items).Add((RibbonItem)(object)item24);
		((Collection<RibbonItem>)(object)val14.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item25 = new RibbonButton();
		PVGp1btLkXV(ref item25, "SEQ ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 557]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 557]));
		((Collection<RibbonItem>)(object)val14.Items).Add((RibbonItem)(object)item25);
		((Collection<RibbonItem>)(object)val14.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item26 = new RibbonButton();
		PVGp1btLkXV(ref item26, "LNK ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 558]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 558]));
		((Collection<RibbonItem>)(object)val14.Items).Add((RibbonItem)(object)item26);
		((Collection<RibbonItem>)(object)val14.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item27 = new RibbonButton();
		PVGp1btLkXV(ref item27, "DELFIPROJ ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1730]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1730]));
		((Collection<RibbonItem>)(object)val14.Items).Add((RibbonItem)(object)item27);
		((Collection<RibbonItem>)(object)val14.Items).Add((RibbonItem)new RibbonRowBreak());
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)(object)val14);
		return val;
	}

	private RibbonPanelSource qGpp1vUUxZV(RibbonTab P_0)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected Obj, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected Obj, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected Obj, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected Obj, but got Unknown
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Expected Obj, but got Unknown
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected Obj, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Expected Obj, but got Unknown
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Expected Obj, but got Unknown
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Expected Obj, but got Unknown
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e3: Expected Obj, but got Unknown
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Expected Obj, but got Unknown
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f1: Expected Obj, but got Unknown
		//IL_0348: Unknown result type (might be due to invalid IL or missing references)
		//IL_0352: Expected Obj, but got Unknown
		//IL_0352: Unknown result type (might be due to invalid IL or missing references)
		//IL_0359: Expected Obj, but got Unknown
		//IL_03b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ba: Expected Obj, but got Unknown
		//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c1: Expected Obj, but got Unknown
		//IL_0418: Unknown result type (might be due to invalid IL or missing references)
		//IL_0422: Expected Obj, but got Unknown
		//IL_0422: Unknown result type (might be due to invalid IL or missing references)
		//IL_0429: Expected Obj, but got Unknown
		//IL_0480: Unknown result type (might be due to invalid IL or missing references)
		//IL_048a: Expected Obj, but got Unknown
		//IL_048a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0491: Expected Obj, but got Unknown
		//IL_04e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f2: Expected Obj, but got Unknown
		RibbonPanelSource val = new RibbonPanelSource();
		val.Title = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1549]);
		RibbonPanel val2 = new RibbonPanel();
		val2.Source = val;
		((Collection<RibbonPanel>)(object)P_0.Panels).Add(val2);
		Bitmap image = null;
		int num = 1;
		if (R99p17GO0HF.Major >= 20)
		{
			num = Conversions.ToInteger(Application.GetSystemVariable("COLORTHEME"));
		}
		RibbonButton item = new RibbonButton();
		if (num == 0)
		{
			image = Resources.LM_32_Dark;
		}
		if (num == 1)
		{
			image = Resources.LM_32;
		}
		IsVp1wK9F5x(ref item, "GERLM", "GERLM ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 585]));
		RibbonButton item2 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.Layout_32_Dark;
		}
		if (num == 1)
		{
			image = Resources.Layout_32;
		}
		IsVp1wK9F5x(ref item2, "LAYMEC", "LAYMEC ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 583]));
		RibbonButton item3 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.GerPlaquetas_32_Dark;
		}
		if (num == 1)
		{
			image = Resources.GerPlaquetas_32;
		}
		IsVp1wK9F5x(ref item3, "PLAQ", "PLAQ ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 811]));
		RibbonMenuButton val3 = new RibbonMenuButton();
		if (num == 0)
		{
			image = Resources.Relatorios_16_Dark;
		}
		if (num == 1)
		{
			image = Resources.Relatorios_16;
		}
		hlxp1M9O0Oq(ref val3, getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1550]));
		RibbonMenuItem item4 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item4, "EXPLM ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 588]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 588]));
		RibbonMenuItem item5 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item5, "RELPL ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 589]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 589]));
		((Collection<RibbonItem>)(object)((RibbonListButton)val3).Items).Add((RibbonItem)(object)item4);
		((Collection<RibbonItem>)(object)((RibbonListButton)val3).Items).Add((RibbonItem)(object)item5);
		RibbonRowPanel val4 = new RibbonRowPanel();
		((Collection<RibbonItem>)(object)val4.Items).Add((RibbonItem)(object)item);
		((Collection<RibbonItem>)(object)val4.Items).Add((RibbonItem)(object)item2);
		((Collection<RibbonItem>)(object)val4.Items).Add((RibbonItem)new RibbonRowBreak());
		((Collection<RibbonItem>)(object)val4.Items).Add((RibbonItem)(object)item3);
		((Collection<RibbonItem>)(object)val4.Items).Add((RibbonItem)(object)val3);
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)(object)val4);
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)new RibbonPanelBreak());
		RibbonRowPanel val5 = new RibbonRowPanel();
		RibbonButton item6 = new RibbonButton();
		PVGp1btLkXV(ref item6, "ATINDEP ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 586]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 586]));
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)(object)item6);
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item7 = new RibbonButton();
		PVGp1btLkXV(ref item7, "EPLQ ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 818]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 818]));
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)(object)item7);
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item8 = new RibbonButton();
		PVGp1btLkXV(ref item8, "COMPLM ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 587]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 587]));
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)(object)item8);
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item9 = new RibbonButton();
		PVGp1btLkXV(ref item9, "DELLM ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1295]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1295]));
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)(object)item9);
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item10 = new RibbonButton();
		PVGp1btLkXV(ref item10, "DELPLA ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1909]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1909]));
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)(object)item10);
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)new RibbonRowBreak());
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)(object)val5);
		return val;
	}

	private RibbonPanelSource HEpp169Agfo(RibbonTab P_0)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected Obj, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected Obj, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected Obj, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected Obj, but got Unknown
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Expected Obj, but got Unknown
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected Obj, but got Unknown
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Expected Obj, but got Unknown
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Expected Obj, but got Unknown
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Expected Obj, but got Unknown
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Expected Obj, but got Unknown
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Expected Obj, but got Unknown
		//IL_031b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0322: Expected Obj, but got Unknown
		//IL_035d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0364: Expected Obj, but got Unknown
		//IL_039f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a6: Expected Obj, but got Unknown
		//IL_03e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e8: Expected Obj, but got Unknown
		//IL_0423: Unknown result type (might be due to invalid IL or missing references)
		//IL_042a: Expected Obj, but got Unknown
		//IL_0465: Unknown result type (might be due to invalid IL or missing references)
		//IL_046c: Expected Obj, but got Unknown
		//IL_04a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ae: Expected Obj, but got Unknown
		//IL_04e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04eb: Expected Obj, but got Unknown
		//IL_052d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0534: Expected Obj, but got Unknown
		//IL_0576: Unknown result type (might be due to invalid IL or missing references)
		//IL_057d: Expected Obj, but got Unknown
		//IL_05bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c6: Expected Obj, but got Unknown
		//IL_0608: Unknown result type (might be due to invalid IL or missing references)
		//IL_060f: Expected Obj, but got Unknown
		//IL_0651: Unknown result type (might be due to invalid IL or missing references)
		//IL_0658: Expected Obj, but got Unknown
		//IL_069a: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a1: Expected Obj, but got Unknown
		//IL_06e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ea: Expected Obj, but got Unknown
		//IL_079c: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a3: Expected Obj, but got Unknown
		//IL_097a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0981: Expected Obj, but got Unknown
		//IL_09c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ca: Expected Obj, but got Unknown
		//IL_0a0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a13: Expected Obj, but got Unknown
		//IL_0a55: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a5c: Expected Obj, but got Unknown
		//IL_0a9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa5: Expected Obj, but got Unknown
		//IL_0ae7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aee: Expected Obj, but got Unknown
		//IL_0b30: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b37: Expected Obj, but got Unknown
		//IL_0b79: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b80: Expected Obj, but got Unknown
		//IL_0bc2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc9: Expected Obj, but got Unknown
		//IL_0c0b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c12: Expected Obj, but got Unknown
		//IL_0c54: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c5b: Expected Obj, but got Unknown
		//IL_0c9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca4: Expected Obj, but got Unknown
		//IL_0ce6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ced: Expected Obj, but got Unknown
		//IL_0d2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d36: Expected Obj, but got Unknown
		//IL_0d78: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d7f: Expected Obj, but got Unknown
		//IL_0dc1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc8: Expected Obj, but got Unknown
		//IL_0e0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e11: Expected Obj, but got Unknown
		//IL_0e53: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e5a: Expected Obj, but got Unknown
		//IL_0f98: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f9f: Expected Obj, but got Unknown
		//IL_0fb4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fbe: Expected Obj, but got Unknown
		//IL_0fcc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fd3: Expected Obj, but got Unknown
		//IL_0fe8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ff2: Expected Obj, but got Unknown
		//IL_1000: Unknown result type (might be due to invalid IL or missing references)
		//IL_1007: Expected Obj, but got Unknown
		//IL_101c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1026: Expected Obj, but got Unknown
		//IL_1034: Unknown result type (might be due to invalid IL or missing references)
		//IL_103b: Expected Obj, but got Unknown
		//IL_1050: Unknown result type (might be due to invalid IL or missing references)
		//IL_105a: Expected Obj, but got Unknown
		//IL_1068: Unknown result type (might be due to invalid IL or missing references)
		//IL_106f: Expected Obj, but got Unknown
		//IL_1084: Unknown result type (might be due to invalid IL or missing references)
		//IL_108e: Expected Obj, but got Unknown
		//IL_109c: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a3: Expected Obj, but got Unknown
		//IL_10d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_10de: Expected Obj, but got Unknown
		//IL_110f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1119: Expected Obj, but got Unknown
		//IL_117c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1186: Expected Obj, but got Unknown
		//IL_1199: Unknown result type (might be due to invalid IL or missing references)
		//IL_11a3: Expected Obj, but got Unknown
		//IL_11a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_11aa: Expected Obj, but got Unknown
		//IL_11aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_11b1: Expected Obj, but got Unknown
		//IL_1208: Unknown result type (might be due to invalid IL or missing references)
		//IL_1212: Expected Obj, but got Unknown
		//IL_1212: Unknown result type (might be due to invalid IL or missing references)
		//IL_1219: Expected Obj, but got Unknown
		//IL_1270: Unknown result type (might be due to invalid IL or missing references)
		//IL_127a: Expected Obj, but got Unknown
		//IL_127a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1281: Expected Obj, but got Unknown
		//IL_12d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_12e2: Expected Obj, but got Unknown
		//IL_12e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_12e9: Expected Obj, but got Unknown
		//IL_1340: Unknown result type (might be due to invalid IL or missing references)
		//IL_134a: Expected Obj, but got Unknown
		//IL_134a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1351: Expected Obj, but got Unknown
		//IL_13a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_13b2: Expected Obj, but got Unknown
		//IL_13b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_13b9: Expected Obj, but got Unknown
		//IL_1410: Unknown result type (might be due to invalid IL or missing references)
		//IL_141a: Expected Obj, but got Unknown
		//IL_141a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1421: Expected Obj, but got Unknown
		//IL_1478: Unknown result type (might be due to invalid IL or missing references)
		//IL_1482: Expected Obj, but got Unknown
		//IL_1482: Unknown result type (might be due to invalid IL or missing references)
		//IL_1489: Expected Obj, but got Unknown
		//IL_14e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_14ea: Expected Obj, but got Unknown
		//IL_14ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_14f1: Expected Obj, but got Unknown
		//IL_1548: Unknown result type (might be due to invalid IL or missing references)
		//IL_1552: Expected Obj, but got Unknown
		//IL_1552: Unknown result type (might be due to invalid IL or missing references)
		//IL_1559: Expected Obj, but got Unknown
		//IL_15b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_15ba: Expected Obj, but got Unknown
		//IL_15ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_15c1: Expected Obj, but got Unknown
		//IL_1618: Unknown result type (might be due to invalid IL or missing references)
		//IL_1622: Expected Obj, but got Unknown
		//IL_1622: Unknown result type (might be due to invalid IL or missing references)
		//IL_1629: Expected Obj, but got Unknown
		//IL_1680: Unknown result type (might be due to invalid IL or missing references)
		//IL_168a: Expected Obj, but got Unknown
		//IL_168a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1691: Expected Obj, but got Unknown
		//IL_16e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_16f2: Expected Obj, but got Unknown
		//IL_16f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_16f9: Expected Obj, but got Unknown
		//IL_1750: Unknown result type (might be due to invalid IL or missing references)
		//IL_175a: Expected Obj, but got Unknown
		RibbonPanelSource val = new RibbonPanelSource();
		val.Title = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 560]);
		RibbonPanel val2 = new RibbonPanel();
		val2.Source = val;
		((Collection<RibbonPanel>)(object)P_0.Panels).Add(val2);
		Bitmap image = null;
		int num = 1;
		if (R99p17GO0HF.Major >= 20)
		{
			num = Conversions.ToInteger(Application.GetSystemVariable("COLORTHEME"));
		}
		RibbonButton item = new RibbonButton();
		if (num == 0)
		{
			image = Resources.Interlig1_32_Dark;
		}
		if (num == 1)
		{
			image = Resources.Interlig1_32;
		}
		IsVp1wK9F5x(ref item, "VEIA1", "VEIA1 ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 561]));
		RibbonButton item2 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.Interlig_32_Dark;
		}
		if (num == 1)
		{
			image = Resources.Interlig_32;
		}
		IsVp1wK9F5x(ref item2, "VEIA", "VEIA ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 562]));
		RibbonButton item3 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.Interlig2_32_Dark;
		}
		if (num == 1)
		{
			image = Resources.Interlig2_32;
		}
		IsVp1wK9F5x(ref item3, "VEIA2", "VEIA2 ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 563]));
		RibbonButton item4 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.VeiaAuto_32_Dark;
		}
		if (num == 1)
		{
			image = Resources.VeiaAuto_32;
		}
		IsVp1wK9F5x(ref item4, "VEAUT", "VEAUT ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 735]));
		RibbonButton item5 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.Blindagem_32_Dark;
		}
		if (num == 1)
		{
			image = Resources.Blindagem_32;
		}
		IsVp1wK9F5x(ref item5, "BLI", "BLI ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 565]));
		RibbonButton item6 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.JumperExt_32_Dark;
		}
		if (num == 1)
		{
			image = Resources.JumperExt_32;
		}
		IsVp1wK9F5x(ref item6, "JUMPEXT", "JPEXT ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 549]));
		RibbonButton item7 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.Excel_32_Dark;
		}
		if (num == 1)
		{
			image = Resources.Excel_32;
		}
		IsVp1wK9F5x(ref item7, "IVEIEX", "IVEIEX ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 576]));
		RibbonButton item8 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.Derivacao_32_Dark;
		}
		if (num == 1)
		{
			image = Resources.Derivacao_32;
		}
		IsVp1wK9F5x(ref item8, "CONEXAO", "CON ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1561]));
		RibbonButton item9 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.Editar_Branco_32;
		}
		if (num == 1)
		{
			image = Resources.Editar_Preto_32;
		}
		IsVp1wK9F5x(ref item9, "EDCABO", "EDCABO ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 571]));
		RibbonButton item10 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.Veias_32_Dark;
		}
		if (num == 1)
		{
			image = Resources.Veias_32;
		}
		IsVp1wK9F5x(ref item10, "ATCABO", "ATCABO ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 564]));
		RibbonButton item11 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.OcultarCabos_16_Dark;
		}
		if (num == 1)
		{
			image = Resources.OcultarCabos_16;
		}
		UCHp1xnMtMs(ref item11, "OCCAB ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 579]));
		RibbonButton item12 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.LigaDesligaAtributos_16_Dark;
		}
		if (num == 1)
		{
			image = Resources.LigaDesligaAtributos_16;
		}
		UCHp1xnMtMs(ref item12, "LNOME ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 569]));
		RibbonButton item13 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.Desliga_16_Dark;
		}
		if (num == 1)
		{
			image = Resources.Desliga_16;
		}
		UCHp1xnMtMs(ref item13, "DNOME ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 570]));
		RibbonButton item14 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.Indefinir_16_Dark;
		}
		if (num == 1)
		{
			image = Resources.Indefinir_16;
		}
		UCHp1xnMtMs(ref item14, "INDV ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 567]));
		RibbonButton item15 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.Pesquisar_16;
		}
		if (num == 1)
		{
			image = Resources.Pesquisar_16;
		}
		UCHp1xnMtMs(ref item15, "PESQC ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 568]));
		RibbonButton item16 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.Sincronizar_16_Dark;
		}
		if (num == 1)
		{
			image = Resources.Sincronizar_16;
		}
		UCHp1xnMtMs(ref item16, "SYNCV ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 573]));
		RibbonMenuButton val3 = new RibbonMenuButton();
		if (num == 0)
		{
			image = Resources.Relatorios_16_Dark;
		}
		if (num == 1)
		{
			image = Resources.Relatorios_16;
		}
		hlxp1M9O0Oq(ref val3, getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 158]));
		RibbonMenuItem item17 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item17, "LCAB ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 894]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 894]));
		RibbonMenuItem item18 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item18, "LCABCOP ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1921]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1921]));
		RibbonMenuItem item19 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item19, "LVEI ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 895]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 895]));
		RibbonMenuItem item20 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item20, "RINT ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 591]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 591]));
		RibbonMenuItem item21 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item21, "RINTE ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1416]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1416]));
		RibbonMenuItem item22 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item22, "LJUMP ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 898]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 898]));
		RibbonMenuItem item23 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item23, "LGIGA ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1609]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1609]));
		RibbonMenuItem item24 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item24, "LANI ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1778]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1778]));
		((Collection<RibbonItem>)(object)((RibbonListButton)val3).Items).Add((RibbonItem)(object)item17);
		((Collection<RibbonItem>)(object)((RibbonListButton)val3).Items).Add((RibbonItem)(object)item18);
		((Collection<RibbonItem>)(object)((RibbonListButton)val3).Items).Add((RibbonItem)(object)item19);
		((Collection<RibbonItem>)(object)((RibbonListButton)val3).Items).Add((RibbonItem)(object)item20);
		((Collection<RibbonItem>)(object)((RibbonListButton)val3).Items).Add((RibbonItem)(object)item21);
		((Collection<RibbonItem>)(object)((RibbonListButton)val3).Items).Add((RibbonItem)(object)item22);
		((Collection<RibbonItem>)(object)((RibbonListButton)val3).Items).Add((RibbonItem)(object)item23);
		((Collection<RibbonItem>)(object)((RibbonListButton)val3).Items).Add((RibbonItem)(object)item24);
		RibbonMenuButton val4 = new RibbonMenuButton();
		if (num == 0)
		{
			image = Resources.Diagramas_16_Dark;
		}
		if (num == 1)
		{
			image = Resources.Diagramas_16;
		}
		hlxp1M9O0Oq(ref val4, getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1464]));
		RibbonMenuItem item25 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item25, "DIELN ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 896]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1540]));
		RibbonMenuItem item26 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item26, "DICEMIGGTP ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1877]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1876]));
		RibbonMenuItem item27 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item27, "DICEMIGGTE ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1886]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1887]));
		RibbonMenuItem item28 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item28, "DICEMIGDP ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1896]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1895]));
		RibbonMenuItem item29 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item29, "DICEMIGDE ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1898]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1897]));
		RibbonMenuItem item30 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item30, "DICHESF ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 897]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1541]));
		RibbonMenuItem item31 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item31, "DICPFL ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1493]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1542]));
		RibbonMenuItem item32 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item32, "DICPFLTR ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1793]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1794]));
		RibbonMenuItem item33 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item33, "DIEDP ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1795]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1796]));
		RibbonMenuItem item34 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item34, "DIEQUAT ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1682]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1543]));
		RibbonMenuItem item35 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item35, "DIENER ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1523]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1544]));
		RibbonMenuItem item36 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item36, "DIENERMT ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1977]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1978]));
		RibbonMenuItem item37 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item37, "DIENERSSE ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1775]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1776]));
		RibbonMenuItem item38 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item38, "DIENELSP ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1879]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1881]));
		RibbonMenuItem item39 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item39, "DIFURNAS ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1871]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1870]));
		RibbonMenuItem item40 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item40, "DICTEEP ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1494]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1545]));
		RibbonMenuItem item41 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item41, "DIITAIPU ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1961]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1960]));
		RibbonMenuItem item42 = new RibbonMenuItem();
		dQ7p1OIrNSK(ref item42, "DITAESA ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1861]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1860]));
		((Collection<RibbonItem>)(object)((RibbonListButton)val4).Items).Add((RibbonItem)(object)item25);
		((Collection<RibbonItem>)(object)((RibbonListButton)val4).Items).Add((RibbonItem)(object)item26);
		((Collection<RibbonItem>)(object)((RibbonListButton)val4).Items).Add((RibbonItem)(object)item27);
		((Collection<RibbonItem>)(object)((RibbonListButton)val4).Items).Add((RibbonItem)(object)item28);
		((Collection<RibbonItem>)(object)((RibbonListButton)val4).Items).Add((RibbonItem)(object)item29);
		((Collection<RibbonItem>)(object)((RibbonListButton)val4).Items).Add((RibbonItem)(object)item30);
		((Collection<RibbonItem>)(object)((RibbonListButton)val4).Items).Add((RibbonItem)(object)item31);
		((Collection<RibbonItem>)(object)((RibbonListButton)val4).Items).Add((RibbonItem)(object)item32);
		((Collection<RibbonItem>)(object)((RibbonListButton)val4).Items).Add((RibbonItem)(object)item33);
		((Collection<RibbonItem>)(object)((RibbonListButton)val4).Items).Add((RibbonItem)(object)item34);
		((Collection<RibbonItem>)(object)((RibbonListButton)val4).Items).Add((RibbonItem)(object)item35);
		((Collection<RibbonItem>)(object)((RibbonListButton)val4).Items).Add((RibbonItem)(object)item36);
		((Collection<RibbonItem>)(object)((RibbonListButton)val4).Items).Add((RibbonItem)(object)item37);
		((Collection<RibbonItem>)(object)((RibbonListButton)val4).Items).Add((RibbonItem)(object)item38);
		((Collection<RibbonItem>)(object)((RibbonListButton)val4).Items).Add((RibbonItem)(object)item39);
		((Collection<RibbonItem>)(object)((RibbonListButton)val4).Items).Add((RibbonItem)(object)item40);
		((Collection<RibbonItem>)(object)((RibbonListButton)val4).Items).Add((RibbonItem)(object)item41);
		((Collection<RibbonItem>)(object)((RibbonListButton)val4).Items).Add((RibbonItem)(object)item42);
		RibbonRowPanel val5 = new RibbonRowPanel();
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)(object)item);
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)new RibbonRowBreak());
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)(object)item2);
		RibbonRowPanel val6 = new RibbonRowPanel();
		((Collection<RibbonItem>)(object)val6.Items).Add((RibbonItem)(object)item3);
		((Collection<RibbonItem>)(object)val6.Items).Add((RibbonItem)new RibbonRowBreak());
		((Collection<RibbonItem>)(object)val6.Items).Add((RibbonItem)(object)item4);
		RibbonRowPanel val7 = new RibbonRowPanel();
		((Collection<RibbonItem>)(object)val7.Items).Add((RibbonItem)(object)item5);
		((Collection<RibbonItem>)(object)val7.Items).Add((RibbonItem)new RibbonRowBreak());
		((Collection<RibbonItem>)(object)val7.Items).Add((RibbonItem)(object)item6);
		RibbonRowPanel val8 = new RibbonRowPanel();
		((Collection<RibbonItem>)(object)val8.Items).Add((RibbonItem)(object)item7);
		((Collection<RibbonItem>)(object)val8.Items).Add((RibbonItem)new RibbonRowBreak());
		((Collection<RibbonItem>)(object)val8.Items).Add((RibbonItem)(object)item8);
		RibbonRowPanel val9 = new RibbonRowPanel();
		((Collection<RibbonItem>)(object)val9.Items).Add((RibbonItem)(object)item9);
		((Collection<RibbonItem>)(object)val9.Items).Add((RibbonItem)new RibbonRowBreak());
		((Collection<RibbonItem>)(object)val9.Items).Add((RibbonItem)(object)item10);
		RibbonRowPanel val10 = new RibbonRowPanel();
		((Collection<RibbonItem>)(object)val10.Items).Add((RibbonItem)(object)item11);
		((Collection<RibbonItem>)(object)val10.Items).Add((RibbonItem)(object)item14);
		((Collection<RibbonItem>)(object)val10.Items).Add((RibbonItem)(object)val3);
		((Collection<RibbonItem>)(object)val10.Items).Add((RibbonItem)new RibbonRowBreak());
		((Collection<RibbonItem>)(object)val10.Items).Add((RibbonItem)(object)item12);
		((Collection<RibbonItem>)(object)val10.Items).Add((RibbonItem)(object)item15);
		((Collection<RibbonItem>)(object)val10.Items).Add((RibbonItem)(object)val4);
		((Collection<RibbonItem>)(object)val10.Items).Add((RibbonItem)new RibbonRowBreak());
		((Collection<RibbonItem>)(object)val10.Items).Add((RibbonItem)(object)item13);
		((Collection<RibbonItem>)(object)val10.Items).Add((RibbonItem)(object)item16);
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)(object)val5);
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)(object)val6);
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)(object)val7);
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)(object)val8);
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)(object)val9);
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)new RibbonSeparator());
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)(object)val10);
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)new RibbonPanelBreak());
		RibbonRowPanel val11 = new RibbonRowPanel();
		RibbonButton item43 = new RibbonButton();
		PVGp1btLkXV(ref item43, "VINT ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1636]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1636]));
		((Collection<RibbonItem>)(object)val11.Items).Add((RibbonItem)(object)item43);
		((Collection<RibbonItem>)(object)val11.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item44 = new RibbonButton();
		PVGp1btLkXV(ref item44, "JMP ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1404]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1404]));
		((Collection<RibbonItem>)(object)val11.Items).Add((RibbonItem)(object)item44);
		((Collection<RibbonItem>)(object)val11.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item45 = new RibbonButton();
		PVGp1btLkXV(ref item45, "INT ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 574]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 574]));
		((Collection<RibbonItem>)(object)val11.Items).Add((RibbonItem)(object)item45);
		((Collection<RibbonItem>)(object)val11.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item46 = new RibbonButton();
		PVGp1btLkXV(ref item46, "SEQJ ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1405]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1405]));
		((Collection<RibbonItem>)(object)val11.Items).Add((RibbonItem)(object)item46);
		((Collection<RibbonItem>)(object)val11.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item47 = new RibbonButton();
		PVGp1btLkXV(ref item47, "CLOCAB ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 577]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 577]));
		((Collection<RibbonItem>)(object)val11.Items).Add((RibbonItem)(object)item47);
		((Collection<RibbonItem>)(object)val11.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item48 = new RibbonButton();
		PVGp1btLkXV(ref item48, "PESQCAB ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 580]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 580]));
		((Collection<RibbonItem>)(object)val11.Items).Add((RibbonItem)(object)item48);
		((Collection<RibbonItem>)(object)val11.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item49 = new RibbonButton();
		PVGp1btLkXV(ref item49, "ESTVL ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1432]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1432]));
		((Collection<RibbonItem>)(object)val11.Items).Add((RibbonItem)(object)item49);
		((Collection<RibbonItem>)(object)val11.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item50 = new RibbonButton();
		PVGp1btLkXV(ref item50, "ESTVCABOS ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1756]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1756]));
		((Collection<RibbonItem>)(object)val11.Items).Add((RibbonItem)(object)item50);
		((Collection<RibbonItem>)(object)val11.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item51 = new RibbonButton();
		PVGp1btLkXV(ref item51, "EDNOMEFUNVEIAS ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1658]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1658]));
		((Collection<RibbonItem>)(object)val11.Items).Add((RibbonItem)(object)item51);
		((Collection<RibbonItem>)(object)val11.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item52 = new RibbonButton();
		PVGp1btLkXV(ref item52, "RECRIACABOS ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1716]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1716]));
		((Collection<RibbonItem>)(object)val11.Items).Add((RibbonItem)(object)item52);
		((Collection<RibbonItem>)(object)val11.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item53 = new RibbonButton();
		PVGp1btLkXV(ref item53, "OPVEIAS ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1660]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1660]));
		((Collection<RibbonItem>)(object)val11.Items).Add((RibbonItem)(object)item53);
		((Collection<RibbonItem>)(object)val11.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item54 = new RibbonButton();
		PVGp1btLkXV(ref item54, "INDEFCAB ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 578]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 578]));
		((Collection<RibbonItem>)(object)val11.Items).Add((RibbonItem)(object)item54);
		((Collection<RibbonItem>)(object)val11.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item55 = new RibbonButton();
		PVGp1btLkXV(ref item55, "IIEX ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1507]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1507]));
		((Collection<RibbonItem>)(object)val11.Items).Add((RibbonItem)(object)item55);
		((Collection<RibbonItem>)(object)val11.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item56 = new RibbonButton();
		PVGp1btLkXV(ref item56, "DELINTPROJ ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1731]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1731]));
		((Collection<RibbonItem>)(object)val11.Items).Add((RibbonItem)(object)item56);
		((Collection<RibbonItem>)(object)val11.Items).Add((RibbonItem)new RibbonRowBreak());
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)(object)val11);
		return val;
	}

	private void E74p1tC6alM(RibbonTab P_0)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected Obj, but got Unknown
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected Obj, but got Unknown
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected Obj, but got Unknown
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected Obj, but got Unknown
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected Obj, but got Unknown
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Expected Obj, but got Unknown
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Expected Obj, but got Unknown
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Expected Obj, but got Unknown
		//IL_03ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b3: Expected Obj, but got Unknown
		//IL_03c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d2: Expected Obj, but got Unknown
		//IL_03d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d9: Expected Obj, but got Unknown
		//IL_03ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f8: Expected Obj, but got Unknown
		//IL_0406: Unknown result type (might be due to invalid IL or missing references)
		//IL_040d: Expected Obj, but got Unknown
		//IL_0422: Unknown result type (might be due to invalid IL or missing references)
		//IL_042c: Expected Obj, but got Unknown
		//IL_043a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0441: Expected Obj, but got Unknown
		//IL_0456: Unknown result type (might be due to invalid IL or missing references)
		//IL_0460: Expected Obj, but got Unknown
		//IL_046e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0475: Expected Obj, but got Unknown
		//IL_048a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0494: Expected Obj, but got Unknown
		//IL_04e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f3: Expected Obj, but got Unknown
		//IL_04f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fa: Expected Obj, but got Unknown
		//IL_04fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0501: Expected Obj, but got Unknown
		//IL_0558: Unknown result type (might be due to invalid IL or missing references)
		//IL_0562: Expected Obj, but got Unknown
		//IL_0562: Unknown result type (might be due to invalid IL or missing references)
		//IL_0569: Expected Obj, but got Unknown
		//IL_05c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ca: Expected Obj, but got Unknown
		//IL_05ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d1: Expected Obj, but got Unknown
		//IL_0628: Unknown result type (might be due to invalid IL or missing references)
		//IL_0632: Expected Obj, but got Unknown
		//IL_0632: Unknown result type (might be due to invalid IL or missing references)
		//IL_0639: Expected Obj, but got Unknown
		//IL_0690: Unknown result type (might be due to invalid IL or missing references)
		//IL_069a: Expected Obj, but got Unknown
		//IL_069a: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a1: Expected Obj, but got Unknown
		//IL_06f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0702: Expected Obj, but got Unknown
		//IL_0702: Unknown result type (might be due to invalid IL or missing references)
		//IL_0709: Expected Obj, but got Unknown
		//IL_0760: Unknown result type (might be due to invalid IL or missing references)
		//IL_076a: Expected Obj, but got Unknown
		//IL_076a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0771: Expected Obj, but got Unknown
		//IL_07c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d2: Expected Obj, but got Unknown
		//IL_07d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d9: Expected Obj, but got Unknown
		//IL_0830: Unknown result type (might be due to invalid IL or missing references)
		//IL_083a: Expected Obj, but got Unknown
		//IL_083a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0841: Expected Obj, but got Unknown
		RibbonPanelSource val = new RibbonPanelSource();
		val.Title = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 112]);
		RibbonPanel val2 = new RibbonPanel();
		val2.Source = val;
		((Collection<RibbonPanel>)(object)P_0.Panels).Add(val2);
		Bitmap image = null;
		int num = 1;
		if (R99p17GO0HF.Major >= 20)
		{
			num = Conversions.ToInteger(Application.GetSystemVariable("COLORTHEME"));
		}
		RibbonButton item = new RibbonButton();
		if (num == 0)
		{
			image = Resources.PDF_VM_32;
		}
		if (num == 1)
		{
			image = Resources.PDF_VM_32;
		}
		IsVp1wK9F5x(ref item, "PDF", "EXPPDF ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1768]));
		RibbonButton item2 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.Clonar_32_Dark;
		}
		if (num == 1)
		{
			image = Resources.Clonar_32;
		}
		IsVp1wK9F5x(ref item2, "CLONAR", "CLONAR ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 602]));
		RibbonButton item3 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.Comprimir_32;
		}
		if (num == 1)
		{
			image = Resources.Comprimir_32;
		}
		IsVp1wK9F5x(ref item3, "CBD", "CBD ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1807]));
		RibbonButton item4 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.ExpImp_Branco_32;
		}
		if (num == 1)
		{
			image = Resources.ExpImp_Preto_32;
		}
		IsVp1wK9F5x(ref item4, "EXPCOMP", "EXPCOMP ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 599]));
		RibbonButton item5 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.Sincroniza_32_Dark;
		}
		if (num == 1)
		{
			image = Resources.Sincroniza_32;
		}
		IsVp1wK9F5x(ref item5, "RESTPROJ", "RESTPROJ ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 604]));
		RibbonButton item6 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.Mover_32_Dark;
		}
		if (num == 1)
		{
			image = Resources.Mover_32;
		}
		IsVp1wK9F5x(ref item6, "MOVER", "MOV ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 160]));
		RibbonButton item7 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.Revisao_32_dark;
		}
		if (num == 1)
		{
			image = Resources.Revisao_32;
		}
		IsVp1wK9F5x(ref item7, "REVAUT", "REVAUT ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1583]));
		RibbonButton item8 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.DWG_Branco_32;
		}
		if (num == 1)
		{
			image = Resources.DWG_Preto_32;
		}
		IsVp1wK9F5x(ref item8, "EXPORTAR", "EXPDWG ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 140]));
		RibbonButton item9 = new RibbonButton();
		if (num == 0)
		{
			image = Resources.Imprimir_32;
		}
		if (num == 1)
		{
			image = Resources.Imprimir_32;
		}
		IsVp1wK9F5x(ref item9, "IMPRIMIR", "IMPR ", getBitmap(image), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 141]));
		RibbonRowPanel val3 = new RibbonRowPanel();
		((Collection<RibbonItem>)(object)val3.Items).Add((RibbonItem)(object)item);
		((Collection<RibbonItem>)(object)val3.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonRowPanel val4 = new RibbonRowPanel();
		((Collection<RibbonItem>)(object)val4.Items).Add((RibbonItem)(object)item2);
		((Collection<RibbonItem>)(object)val4.Items).Add((RibbonItem)new RibbonRowBreak());
		((Collection<RibbonItem>)(object)val4.Items).Add((RibbonItem)(object)item3);
		RibbonRowPanel val5 = new RibbonRowPanel();
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)(object)item4);
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)new RibbonRowBreak());
		((Collection<RibbonItem>)(object)val5.Items).Add((RibbonItem)(object)item5);
		RibbonRowPanel val6 = new RibbonRowPanel();
		((Collection<RibbonItem>)(object)val6.Items).Add((RibbonItem)(object)item6);
		((Collection<RibbonItem>)(object)val6.Items).Add((RibbonItem)new RibbonRowBreak());
		((Collection<RibbonItem>)(object)val6.Items).Add((RibbonItem)(object)item7);
		RibbonRowPanel val7 = new RibbonRowPanel();
		((Collection<RibbonItem>)(object)val7.Items).Add((RibbonItem)(object)item8);
		((Collection<RibbonItem>)(object)val7.Items).Add((RibbonItem)new RibbonRowBreak());
		((Collection<RibbonItem>)(object)val7.Items).Add((RibbonItem)(object)item9);
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)(object)val3);
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)(object)val4);
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)(object)val5);
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)(object)val6);
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)(object)val7);
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)new RibbonPanelBreak());
		RibbonRowPanel val8 = new RibbonRowPanel();
		RibbonButton item10 = new RibbonButton();
		PVGp1btLkXV(ref item10, "TROCTT ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 592]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 592]));
		((Collection<RibbonItem>)(object)val8.Items).Add((RibbonItem)(object)item10);
		((Collection<RibbonItem>)(object)val8.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item11 = new RibbonButton();
		PVGp1btLkXV(ref item11, "EXPIT ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 593]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 593]));
		((Collection<RibbonItem>)(object)val8.Items).Add((RibbonItem)(object)item11);
		((Collection<RibbonItem>)(object)val8.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item12 = new RibbonButton();
		PVGp1btLkXV(ref item12, "COPYCAD ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 594]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 594]));
		((Collection<RibbonItem>)(object)val8.Items).Add((RibbonItem)(object)item12);
		((Collection<RibbonItem>)(object)val8.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item13 = new RibbonButton();
		PVGp1btLkXV(ref item13, "TROCBL ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 595]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 595]));
		((Collection<RibbonItem>)(object)val8.Items).Add((RibbonItem)(object)item13);
		((Collection<RibbonItem>)(object)val8.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item14 = new RibbonButton();
		PVGp1btLkXV(ref item14, "PESQUISA ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1687]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1687]));
		((Collection<RibbonItem>)(object)val8.Items).Add((RibbonItem)(object)item14);
		((Collection<RibbonItem>)(object)val8.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item15 = new RibbonButton();
		PVGp1btLkXV(ref item15, "APAGARXDATA ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1930]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1930]));
		((Collection<RibbonItem>)(object)val8.Items).Add((RibbonItem)(object)item15);
		((Collection<RibbonItem>)(object)val8.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item16 = new RibbonButton();
		PVGp1btLkXV(ref item16, "IMPCAD ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1389]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1389]));
		((Collection<RibbonItem>)(object)val8.Items).Add((RibbonItem)(object)item16);
		((Collection<RibbonItem>)(object)val8.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item17 = new RibbonButton();
		PVGp1btLkXV(ref item17, "MUDAUSER ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1786]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1786]));
		((Collection<RibbonItem>)(object)val8.Items).Add((RibbonItem)(object)item17);
		((Collection<RibbonItem>)(object)val8.Items).Add((RibbonItem)new RibbonRowBreak());
		RibbonButton item18 = new RibbonButton();
		PVGp1btLkXV(ref item18, "CorrigeJanelas ", getBitmap(Resources.Item), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1761]), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1761]));
		((Collection<RibbonItem>)(object)val8.Items).Add((RibbonItem)(object)item18);
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)(object)val8);
	}

	private void vwCp1jIpDXj(RibbonTab P_0)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected Obj, but got Unknown
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected Obj, but got Unknown
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected Obj, but got Unknown
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected Obj, but got Unknown
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected Obj, but got Unknown
		RibbonPanelSource val = new RibbonPanelSource();
		val.Title = "Help";
		RibbonPanel val2 = new RibbonPanel();
		val2.Source = val;
		((Collection<RibbonPanel>)(object)P_0.Panels).Add(val2);
		Bitmap image = null;
		int num = 1;
		if (R99p17GO0HF.Major >= 20)
		{
			num = Conversions.ToInteger(Application.GetSystemVariable("COLORTHEME"));
		}
		RibbonButton item = new RibbonButton();
		if (num == 0)
		{
			image = Resources.Ajuda_32_Dark;
		}
		if (num == 1)
		{
			image = Resources.Ajuda_32;
		}
		IsVp1wK9F5x(ref item, "Help", "AJUDA ", getBitmap(image), "Help");
		RibbonToggleButton val3 = new RibbonToggleButton();
		if (num == 0)
		{
			image = Resources.InformationOn_32_Dark;
		}
		if (num == 1)
		{
			image = Resources.InformationOn_32;
		}
		((RibbonItem)val3).Size = (RibbonItemSize)1;
		((RibbonItem)val3).LargeImage = getBitmap(image);
		((RibbonItem)val3).ShowText = false;
		((RibbonItem)val3).ShowImage = true;
		((RibbonButton)val3).Orientation = Orientation.Horizontal;
		((RibbonItem)val3).Text = "";
		((RibbonCommandItem)val3).CommandParameter = "InfoOn ";
		((RibbonCommandItem)val3).CommandHandler = new ToggleButtonCmdHandler();
		RibbonRowPanel val4 = new RibbonRowPanel();
		((Collection<RibbonItem>)(object)val4.Items).Add((RibbonItem)(object)item);
		((Collection<RibbonItem>)(object)val4.Items).Add((RibbonItem)new RibbonRowBreak());
		((Collection<RibbonItem>)(object)val4.Items).Add((RibbonItem)(object)val3);
		((Collection<RibbonItem>)(object)val.Items).Add((RibbonItem)(object)val4);
	}

	public BitmapImage getBitmap(Bitmap image)
	{
		MemoryStream memoryStream = new MemoryStream();
		image.Save(memoryStream, ImageFormat.Png);
		BitmapImage bitmapImage = new BitmapImage();
		bitmapImage.BeginInit();
		bitmapImage.StreamSource = memoryStream;
		bitmapImage.EndInit();
		return bitmapImage;
	}

	private void Nowp1LGUQxQ(ref RibbonButton P_0, string P_1, string P_2, BitmapImage P_3, string P_4)
	{
		((RibbonItem)P_0).Text = P_1;
		((RibbonCommandItem)P_0).CommandParameter = P_2;
		((RibbonItem)P_0).ShowText = true;
		((RibbonItem)P_0).ShowImage = true;
		((RibbonItem)P_0).LargeImage = P_3;
		P_0.Orientation = Orientation.Vertical;
		((RibbonItem)P_0).Size = (RibbonItemSize)1;
		((RibbonItem)P_0).ToolTip = P_4;
		((RibbonCommandItem)P_0).CommandHandler = new AdskCommandHandler();
	}

	private void IsVp1wK9F5x(ref RibbonButton P_0, string P_1, string P_2, BitmapImage P_3, string P_4)
	{
		((RibbonCommandItem)P_0).CommandParameter = P_2;
		((RibbonItem)P_0).ShowText = false;
		((RibbonItem)P_0).ShowImage = true;
		((RibbonItem)P_0).LargeImage = P_3;
		P_0.Orientation = Orientation.Horizontal;
		((RibbonItem)P_0).Size = (RibbonItemSize)1;
		((RibbonItem)P_0).ToolTip = P_4;
		((RibbonCommandItem)P_0).CommandHandler = new AdskCommandHandler();
	}

	private void UCHp1xnMtMs(ref RibbonButton P_0, string P_1, BitmapImage P_2, string P_3)
	{
		((RibbonCommandItem)P_0).CommandParameter = P_1;
		((RibbonItem)P_0).ShowImage = true;
		((RibbonItem)P_0).Image = P_2;
		((RibbonItem)P_0).Width = 16.0;
		((RibbonItem)P_0).Height = 16.0;
		((RibbonItem)P_0).ToolTip = P_3;
		((RibbonCommandItem)P_0).CommandHandler = new AdskCommandHandler();
	}

	private void PVGp1btLkXV(ref RibbonButton P_0, string P_1, BitmapImage P_2, string P_3, string P_4)
	{
		((RibbonCommandItem)P_0).CommandParameter = P_1;
		((RibbonItem)P_0).Text = P_4;
		((RibbonItem)P_0).ShowImage = true;
		((RibbonItem)P_0).ShowText = true;
		((RibbonItem)P_0).Image = P_2;
		((RibbonItem)P_0).Height = 16.0;
		P_0.Orientation = Orientation.Horizontal;
		((RibbonItem)P_0).Size = (RibbonItemSize)0;
		((RibbonItem)P_0).ToolTip = P_3;
		((RibbonCommandItem)P_0).CommandHandler = new AdskCommandHandler();
	}

	private void hlxp1M9O0Oq(ref RibbonMenuButton P_0, BitmapImage P_1, string P_2)
	{
		((RibbonItem)P_0).Text = "";
		((RibbonItem)P_0).ShowText = false;
		((RibbonItem)P_0).ShowImage = true;
		((RibbonItem)P_0).Image = P_1;
		((RibbonItem)P_0).MinWidth = 15.0;
		((RibbonItem)P_0).Width = 40.0;
		((RibbonItem)P_0).ToolTip = P_2;
	}

	private void dQ7p1OIrNSK(ref RibbonMenuItem P_0, string P_1, BitmapImage P_2, string P_3, string P_4)
	{
		((RibbonItem)P_0).Text = P_4;
		((RibbonItem)P_0).ShowText = true;
		((RibbonItem)P_0).ShowImage = true;
		((RibbonItem)P_0).Image = P_2;
		((RibbonItem)P_0).ToolTip = P_3;
		((RibbonCommandItem)P_0).CommandParameter = P_1;
		((RibbonCommandItem)P_0).CommandHandler = new RibbomMenuItemCommandHandler();
	}

	private void vaOp1I1h7AV(object P_0, RibbonPropertyChangedEventArgs P_1)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		DeclaracoesGeral.ativoRibbon.Secao = ((RibbonItem)P_1.NewValue).Text.ToString();
		MySettingsProperty.Settings.Secao = DeclaracoesGeral.ativoRibbon.Secao.ToString();
		MySettingsProperty.Settings.Save();
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class ExcFuncoesExcel
{
	public struct PosicoesExcel
	{
		public string SSheet;

		public string SNomeCampo;

		public string SPosicao;
	}

	public struct ValoresExcel
	{
		public string SNomeCampo;

		public string SValor;
	}

	public static void VerificaExcel(ref Microsoft.Office.Interop.Excel.Application oExcelNew, ref Worksheet oSheet, string oNomeSheet)
	{
		checked
		{
			try
			{
				bool flag = ExcelAberto();
				if (Operators.CompareString(oNomeSheet, "", TextCompare: true) == 0)
				{
					oNomeSheet = "Plan1";
				}
				TrocaBarra(ref oNomeSheet);
				Workbook workbook;
				if (!flag)
				{
					oExcelNew = (Microsoft.Office.Interop.Excel.Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
					workbook = oExcelNew.Workbooks.Add(RuntimeHelpers.GetObjectValue(Missing.Value));
					oSheet = (Worksheet)oExcelNew.ActiveSheet;
				}
				else
				{
					oExcelNew = (Microsoft.Office.Interop.Excel.Application)excEXCEL.GetObject("Excel.Application");
					workbook = ((oExcelNew.Workbooks.Count > 0) ? oExcelNew.ActiveWorkbook : oExcelNew.Workbooks.Add(RuntimeHelpers.GetObjectValue(Missing.Value)));
					oSheet = (Worksheet)oExcelNew.ActiveSheet;
					if (oExcelNew.WindowState == XlWindowState.xlMinimized)
					{
						oExcelNew.WindowState = XlWindowState.xlMaximized;
					}
				}
				bool flag2 = false;
				int count = workbook.Sheets.Count;
				for (int i = 1; i <= count; i++)
				{
					if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(workbook.Worksheets[i], null, "Name", new object[0], null, null, null), oNomeSheet, TextCompare: true))
					{
						flag2 = true;
						NewLateBinding.LateCall(workbook.Worksheets[i], null, "Activate", new object[0], null, null, null, IgnoreReturn: true);
						oSheet = (Worksheet)oExcelNew.ActiveSheet;
						ApagaFigura(oNomeSheet);
						LimpaSheet(ref oSheet);
						oExcelNew.ScreenUpdating = true;
						System.Windows.Forms.Application.DoEvents();
						oExcelNew.Visible = true;
						break;
					}
				}
				if (flag2)
				{
					return;
				}
				int count2 = workbook.Sheets.Count;
				int num = 1;
				if (1 <= count2)
				{
					NewLateBinding.LateCall(workbook.Worksheets[num], null, "Activate", new object[0], null, null, null, IgnoreReturn: true);
					oSheet = (Worksheet)oExcelNew.ActiveSheet;
				}
				Worksheet worksheet = (Worksheet)workbook.Worksheets.Add(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(workbook.Worksheets[workbook.Worksheets.Count]), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
				worksheet.Name = oNomeSheet;
				int count3 = workbook.Sheets.Count;
				for (int j = 1; j <= count3; j++)
				{
					if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(workbook.Worksheets[j], null, "Name", new object[0], null, null, null), oNomeSheet, TextCompare: true))
					{
						flag2 = true;
						NewLateBinding.LateCall(workbook.Worksheets[j], null, "Activate", new object[0], null, null, null, IgnoreReturn: true);
						oSheet = (Worksheet)oExcelNew.ActiveSheet;
						System.Windows.Forms.Application.DoEvents();
						break;
					}
				}
				if (oExcelNew.Calculation == XlCalculation.xlCalculationManual)
				{
					oExcelNew.Calculation = XlCalculation.xlCalculationAutomatic;
					oExcelNew.Calculation = XlCalculation.xlCalculationManual;
					System.Windows.Forms.Application.DoEvents();
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	public static bool VerificaExcelAtivo(ref Microsoft.Office.Interop.Excel.Application oExcelNew, ref Workbook oBook, ref Worksheet oSheet, bool bMaximiza = true)
	{
		bool flag = false;
		try
		{
			if (!ExcelAberto())
			{
				oExcelNew = (Microsoft.Office.Interop.Excel.Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
				oBook = oExcelNew.Workbooks.Add(RuntimeHelpers.GetObjectValue(Missing.Value));
				oSheet = (Worksheet)oExcelNew.ActiveSheet;
				((_Worksheet)oSheet).get_Range((object)"A1", RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
				flag = true;
			}
			else
			{
				oExcelNew = (Microsoft.Office.Interop.Excel.Application)excEXCEL.GetObject("Excel.Application");
				if (oExcelNew.Workbooks.Count <= 0)
				{
					oBook = oExcelNew.Workbooks.Add(RuntimeHelpers.GetObjectValue(Missing.Value));
				}
				else
				{
					oBook = oExcelNew.ActiveWorkbook;
				}
				oSheet = (Worksheet)oExcelNew.ActiveSheet;
				if (bMaximiza & (oExcelNew.WindowState == XlWindowState.xlMinimized))
				{
					oExcelNew.WindowState = XlWindowState.xlMaximized;
				}
				flag = true;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			flag = false;
			ProjectData.ClearProjectError();
		}
		return flag;
	}

	public static bool VerificaExcelAtivoImportar(ref Microsoft.Office.Interop.Excel.Application oExcelNew, ref Workbook oBook, ref Worksheet oSheet, bool bMaximiza = true)
	{
		bool result = false;
		try
		{
			if (!ExcelAberto())
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 254]), MsgBoxStyle.Information, "ArqNet");
			}
			else
			{
				oExcelNew = (Microsoft.Office.Interop.Excel.Application)excEXCEL.GetObject("Excel.Application");
				if (oExcelNew.Workbooks.Count <= 0)
				{
					oBook = oExcelNew.Workbooks.Add(RuntimeHelpers.GetObjectValue(Missing.Value));
				}
				else
				{
					oBook = oExcelNew.ActiveWorkbook;
				}
				oSheet = (Worksheet)oExcelNew.ActiveSheet;
				if (bMaximiza & (oExcelNew.WindowState == XlWindowState.xlMinimized))
				{
					oExcelNew.WindowState = XlWindowState.xlMaximized;
				}
				result = true;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static bool VerificaExisteSheet(ref Microsoft.Office.Interop.Excel.Application oExcelNew, ref Worksheet oSheet, string oNomeSheet, bool bMaximiza = true)
	{
		bool result = false;
		if (Operators.CompareString(oNomeSheet, "", TextCompare: true) != 0)
		{
			try
			{
				if (!ExcelAberto())
				{
					result = false;
				}
				else
				{
					oExcelNew = (Microsoft.Office.Interop.Excel.Application)excEXCEL.GetObject("Excel.Application");
					Workbook workbook = ((oExcelNew.Workbooks.Count > 0) ? oExcelNew.ActiveWorkbook : oExcelNew.Workbooks.Add(RuntimeHelpers.GetObjectValue(Missing.Value)));
					oSheet = (Worksheet)oExcelNew.ActiveSheet;
					if (bMaximiza & (oExcelNew.WindowState == XlWindowState.xlMinimized))
					{
						oExcelNew.WindowState = XlWindowState.xlMaximized;
					}
					int count = workbook.Sheets.Count;
					for (int i = 1; i <= count; i = checked(i + 1))
					{
						if (Operators.CompareString(NewLateBinding.LateGet(workbook.Worksheets[i], null, "Name", new object[0], null, null, null).ToString().ToUpper(), oNomeSheet.ToString().ToUpper(), TextCompare: true) == 0)
						{
							NewLateBinding.LateCall(workbook.Worksheets[oNomeSheet], null, "Activate", new object[0], null, null, null, IgnoreReturn: true);
							oSheet = (Worksheet)oExcelNew.ActiveSheet;
							((_Worksheet)oSheet).get_Range((object)"A1", RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
							System.Windows.Forms.Application.DoEvents();
							result = true;
							break;
						}
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
		return result;
	}

	public static bool ExisteSheet(string oNomeSheet, bool bMaximiza = true)
	{
		bool result = false;
		int num = 0;
		checked
		{
			if (Operators.CompareString(oNomeSheet, "", TextCompare: true) != 0)
			{
				try
				{
					if (!ExcelAberto())
					{
						result = false;
					}
					else
					{
						Microsoft.Office.Interop.Excel.Application application = (Microsoft.Office.Interop.Excel.Application)excEXCEL.GetObject("Excel.Application");
						Workbook workbook = ((application.Workbooks.Count > 0) ? application.ActiveWorkbook : application.Workbooks.Add(RuntimeHelpers.GetObjectValue(Missing.Value)));
						_ = (Worksheet)application.ActiveSheet;
						if (bMaximiza & (application.WindowState == XlWindowState.xlMinimized))
						{
							application.WindowState = XlWindowState.xlMaximized;
						}
						int count = workbook.Sheets.Count;
						for (int i = 1; i <= count; i++)
						{
							num++;
							if (Operators.CompareString(NewLateBinding.LateGet(workbook.Worksheets[i], null, "Name", new object[0], null, null, null).ToString().ToUpper(), oNomeSheet.ToString().ToUpper(), TextCompare: true) == 0)
							{
								result = true;
								break;
							}
						}
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					throw;
				}
			}
			return result;
		}
	}

	public static bool VerificaExisteSheetSiemens(ref Microsoft.Office.Interop.Excel.Application OExcelNew, ref Worksheet OSheet, string oNomeSheet)
	{
		bool result = false;
		if (Operators.CompareString(oNomeSheet, "", TextCompare: true) != 0)
		{
			try
			{
				if (ExcelAberto())
				{
					OExcelNew = (Microsoft.Office.Interop.Excel.Application)excEXCEL.GetObject("Excel.Application");
					if (OExcelNew.Workbooks.Count > 0)
					{
						foreach (Workbook workbook in OExcelNew.Workbooks)
						{
							int count = workbook.Sheets.Count;
							for (int i = 1; i <= count; i = checked(i + 1))
							{
								if (Operators.CompareString(NewLateBinding.LateGet(workbook.Worksheets[i], null, "Name", new object[0], null, null, null).ToString().ToUpper(), oNomeSheet.ToString().ToUpper(), TextCompare: true) == 0)
								{
									NewLateBinding.LateCall(workbook.Worksheets[oNomeSheet], null, "Activate", new object[0], null, null, null, IgnoreReturn: true);
									OSheet = (Worksheet)OExcelNew.ActiveSheet;
									result = true;
									goto end_IL_0052;
								}
							}
							continue;
							end_IL_0052:
							break;
						}
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
		return result;
	}

	public static void AbreExcelExterno(string sCaminho)
	{
		Microsoft.Office.Interop.Excel.Application application = null;
		if (!ExcelAberto())
		{
			application = (Microsoft.Office.Interop.Excel.Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
		}
		else
		{
			application = (Microsoft.Office.Interop.Excel.Application)excEXCEL.GetObject("Excel.Application");
			if (application.WindowState == XlWindowState.xlMinimized)
			{
				application.WindowState = XlWindowState.xlMaximized;
			}
		}
		try
		{
			application.Visible = true;
			application.Workbooks.Open(sCaminho, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			_ = (Worksheet)application.ActiveSheet;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public static void FechaExcelOculto()
	{
		Process[] processes = Process.GetProcesses();
		foreach (Process process in processes)
		{
			if (Operators.CompareString(process.ProcessName.ToUpper(), "EXCEL", TextCompare: true) == 0)
			{
				Microsoft.Office.Interop.Excel.Application application = (Microsoft.Office.Interop.Excel.Application)excEXCEL.GetObject("Excel.Application");
				if (!application.Visible)
				{
					process.Kill();
				}
			}
		}
	}

	public static bool ExcelAberto()
	{
		bool result = false;
		Microsoft.Office.Interop.Excel.Application application = null;
		Process[] processes = Process.GetProcesses();
		foreach (Process process in processes)
		{
			if (Operators.CompareString(process.ProcessName.ToUpper(), "EXCEL", TextCompare: true) == 0)
			{
				result = true;
				application = (Microsoft.Office.Interop.Excel.Application)excEXCEL.GetObject("Excel.Application");
				if (!application.Visible)
				{
					result = false;
					process.Kill();
				}
			}
		}
		return result;
	}

	public static void DesativaCalculoExcel(ref Microsoft.Office.Interop.Excel.Application oExcel)
	{
		string text = Geral.CADVersion();
		string left = text;
		if (Operators.CompareString(left, "A_2025", TextCompare: true) != 0 && Operators.CompareString(left, "A_2026", TextCompare: true) != 0 && Operators.CompareString(left, "A_2027", TextCompare: true) != 0)
		{
			try
			{
				oExcel.ScreenUpdating = false;
				oExcel.Calculation = XlCalculation.xlCalculationManual;
				return;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
				return;
			}
		}
		AtivaCalculOExcel(ref oExcel);
	}

	public static void AtivaCalculOExcel(ref Microsoft.Office.Interop.Excel.Application OExcelNew)
	{
		try
		{
			Process[] processes = Process.GetProcesses();
			int num = 0;
			while (true)
			{
				if (num < processes.Length)
				{
					Process process = processes[num];
					if (Operators.CompareString(process.ProcessName.ToUpper(), "EXCEL", TextCompare: true) == 0)
					{
						break;
					}
					num = checked(num + 1);
					continue;
				}
				return;
			}
			OExcelNew = (Microsoft.Office.Interop.Excel.Application)excEXCEL.GetObject("Excel.Application");
			OExcelNew.Visible = true;
			OExcelNew.ScreenUpdating = true;
			OExcelNew.Calculation = XlCalculation.xlCalculationAutomatic;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public static void AtuaizaCalculOExcel(ref Microsoft.Office.Interop.Excel.Application OExcelNew)
	{
		try
		{
			if (!OExcelNew.ScreenUpdating)
			{
				OExcelNew.ScreenUpdating = true;
				OExcelNew.Calculation = XlCalculation.xlCalculationAutomatic;
				OExcelNew.ScreenUpdating = false;
				OExcelNew.Calculation = XlCalculation.xlCalculationManual;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public static void FormataPagina(ref Microsoft.Office.Interop.Excel.Application OExcelNew, ref Worksheet OSheet, int Zoom)
	{
		PageSetup pageSetup = OSheet.PageSetup;
		pageSetup.LeftHeader = "";
		pageSetup.CenterHeader = "";
		pageSetup.RightHeader = "";
		pageSetup.LeftFooter = "";
		pageSetup.CenterFooter = "";
		pageSetup.RightFooter = "";
		pageSetup.LeftMargin = OExcelNew.InchesToPoints(0.393700787401575);
		pageSetup.RightMargin = OExcelNew.InchesToPoints(0.393700787401575);
		pageSetup.TopMargin = OExcelNew.InchesToPoints(0.393700787401575);
		pageSetup.BottomMargin = OExcelNew.InchesToPoints(0.393700787401575);
		pageSetup.HeaderMargin = OExcelNew.InchesToPoints(125.0 / 127.0);
		pageSetup.FooterMargin = OExcelNew.InchesToPoints(125.0 / 127.0);
		pageSetup.PrintHeadings = false;
		pageSetup.PrintGridlines = false;
		pageSetup.PrintComments = XlPrintLocation.xlPrintNoComments;
		pageSetup.CenterHorizontally = false;
		pageSetup.CenterVertically = false;
		pageSetup.Orientation = XlPageOrientation.xlPortrait;
		pageSetup.Draft = false;
		pageSetup.PaperSize = XlPaperSize.xlPaperA4;
		pageSetup.FirstPageNumber = 1;
		pageSetup.Order = XlOrder.xlDownThenOver;
		pageSetup.BlackAndWhite = false;
		pageSetup.Zoom = Zoom;
		pageSetup.PrintErrors = XlPrintErrors.xlPrintErrorsDisplayed;
		pageSetup.OddAndEvenPagesHeaderFooter = false;
		pageSetup.DifferentFirstPageHeaderFooter = false;
		pageSetup.ScaleWithDocHeaderFooter = true;
		pageSetup.AlignMarginsHeaderFooter = true;
		pageSetup.EvenPage.LeftHeader.Text = "";
		pageSetup.EvenPage.CenterHeader.Text = "";
		pageSetup.EvenPage.RightHeader.Text = "";
		pageSetup.EvenPage.LeftFooter.Text = "";
		pageSetup.EvenPage.CenterFooter.Text = "";
		pageSetup.EvenPage.RightFooter.Text = "";
		pageSetup.FirstPage.LeftHeader.Text = "";
		pageSetup.FirstPage.CenterHeader.Text = "";
		pageSetup.FirstPage.RightHeader.Text = "";
		pageSetup.FirstPage.LeftFooter.Text = "";
		pageSetup.FirstPage.CenterFooter.Text = "";
		pageSetup.FirstPage.RightFooter.Text = "";
		pageSetup = null;
	}

	public static int BuscaIndiceMaximoUsado(ref Worksheet OSheet, string sColuna, int Linha = 1)
	{
		int num = Linha;
		string cell = sColuna + Linha;
		checked
		{
			while (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)OSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
			{
				num++;
				cell = sColuna + Conversions.ToString(num);
			}
			return num - 1;
		}
	}

	public static void LimpaSheet(ref Worksheet OSheet)
	{
		((_Worksheet)OSheet).get_Range((object)"A1", (object)"Z10000").EntireRow.Delete(RuntimeHelpers.GetObjectValue(Missing.Value));
		((_Worksheet)OSheet).get_Range((object)"A1:Z1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 8.43;
		OSheet.Cells.ClearComments();
	}

	public static bool InsereFigura1(ref Worksheet OSheet, string SCel1, string SCaminho, int iDeslocX, int iDeslocY)
	{
		int num = 0;
		bool result = false;
		checked
		{
			while (Operators.CompareString(SCaminho.Trim(), "", TextCompare: true) != 0 && File.Exists(SCaminho))
			{
				Microsoft.Office.Interop.Excel.Application application = (Microsoft.Office.Interop.Excel.Application)excEXCEL.GetObject("Excel.Application");
				int num2 = Conversions.ToInteger(NewLateBinding.LateGet(NewLateBinding.LateGet(application.ActiveSheet, null, "pictures", new object[0], null, null, null), null, "count", new object[0], null, null, null));
				((_Worksheet)OSheet).get_Range((object)SCel1, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
				Image image = Image.FromFile(SCaminho);
				Clipboard.Clear();
				Clipboard.SetImage(image);
				application.ScreenUpdating = true;
				try
				{
					OSheet.PasteSpecial(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					num++;
					if (num >= 5)
					{
						ProjectData.ClearProjectError();
						break;
					}
					Thread.Sleep(200);
					ProjectData.ClearProjectError();
					continue;
				}
				int num3 = Conversions.ToInteger(NewLateBinding.LateGet(NewLateBinding.LateGet(application.ActiveSheet, null, "pictures", new object[0], null, null, null), null, "count", new object[0], null, null, null));
				if (num2 < num3)
				{
					int num4 = 0;
					foreach (object item in (IEnumerable)NewLateBinding.LateGet(application.ActiveSheet, null, "Pictures", new object[0], null, null, null))
					{
						object objectValue = RuntimeHelpers.GetObjectValue(item);
						num4++;
						if (num4 == num3)
						{
							NewLateBinding.LateSet(objectValue, null, "Top", new object[1] { Operators.AddObject(application.ActiveCell.Top, iDeslocY) }, null, null);
							NewLateBinding.LateSet(objectValue, null, "Left", new object[1] { Operators.AddObject(application.ActiveCell.Left, iDeslocX) }, null, null);
							break;
						}
					}
				}
				((_Worksheet)OSheet).get_Range((object)SCel1, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
				result = true;
				break;
			}
			return result;
		}
	}

	public static int QuantidadeFigura(ref Microsoft.Office.Interop.Excel.Application OExcelNew)
	{
		int result;
		try
		{
			_ = (Worksheet)OExcelNew.ActiveSheet;
			result = Conversions.ToInteger(NewLateBinding.LateGet(NewLateBinding.LateGet(OExcelNew.ActiveSheet, null, "pictures", new object[0], null, null, null), null, "count", new object[0], null, null, null));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static string BuscaValorNaPlanilhaExcel(string SPlanilha, string SWorksheet, string SValor, int IInicio = 1, int IFim = 100)
	{
		string result = "";
		Microsoft.Office.Interop.Excel.Application application = (Microsoft.Office.Interop.Excel.Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
		application.Visible = false;
		Workbook workbook = application.Workbooks.Open(SPlanilha, RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing));
		Worksheet worksheet = null;
		worksheet = (Worksheet)application.ActiveSheet;
		checked
		{
			foreach (Worksheet sheet in workbook.Sheets)
			{
				if (Operators.CompareString(sheet.Name.ToUpper(), SWorksheet.ToUpper(), TextCompare: true) != 0)
				{
					continue;
				}
				NewLateBinding.LateCall(workbook.Worksheets[SWorksheet], null, "Activate", new object[0], null, null, null, IgnoreReturn: true);
				worksheet = (Worksheet)workbook.ActiveSheet;
				int num = 1;
				while (true)
				{
					string text = mudaNumeroAsc(num);
					int num2 = IInicio;
					while (true)
					{
						if (num2 <= IFim)
						{
							string text2 = text + num2;
							if (Operators.CompareString(clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)worksheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))).ToString().ToUpper(), SValor.ToUpper(), TextCompare: true) != 0)
							{
								num2++;
								continue;
							}
							result = text2;
							goto end_IL_0145;
						}
						num++;
						if (num <= 20)
						{
							break;
						}
						goto end_IL_0145;
					}
					continue;
					end_IL_0145:
					break;
				}
				break;
			}
			application.DisplayAlerts = false;
			workbook.Close(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			application.Quit();
			return result;
		}
	}

	public static void BuscaTodosValorDoModelo(string sPlanilha, List<string> lCampos, ref PosicoesExcel[] mPosicoes)
	{
		Microsoft.Office.Interop.Excel.Application application = (Microsoft.Office.Interop.Excel.Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
		application.Visible = false;
		Workbook workbook = application.Workbooks.Open(sPlanilha, RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing));
		Worksheet worksheet = null;
		worksheet = (Worksheet)application.ActiveSheet;
		int num = 0;
		mPosicoes = new PosicoesExcel[1];
		DeclaracoesGeral._uscPagina.Quantidade = 150;
		DeclaracoesGeral._uscPagina.pbIniciar();
		checked
		{
			foreach (Worksheet sheet in workbook.Sheets)
			{
				NewLateBinding.LateCall(workbook.Worksheets[sheet.Name], null, "Activate", new object[0], null, null, null, IgnoreReturn: true);
				worksheet = (Worksheet)workbook.ActiveSheet;
				int num2 = 0;
				int num3 = 0;
				int num4 = 0;
				int num5 = 1;
				do
				{
					num4 = ((_Worksheet)worksheet).get_Range((object)(mudaNumeroAsc(num5) + "1"), RuntimeHelpers.GetObjectValue(Missing.Value)).get_End(XlDirection.xlDown).Row;
					if (num4 < 1000)
					{
						num3 = num5 + 1;
						if (num4 > num2)
						{
							num2 = num4 + 2;
						}
					}
					DeclaracoesGeral._uscPagina.pbPasso();
					num5++;
				}
				while (num5 <= 50);
				int num6 = num3;
				for (int i = 1; i <= num6; i++)
				{
					string text = mudaNumeroAsc(i);
					int num7 = num2;
					for (int j = 1; j <= num7; j++)
					{
						string text2 = text + j;
						string text3 = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)worksheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
						if (lCampos.Contains(text3.ToString().ToUpper()))
						{
							num++;
							mPosicoes = (PosicoesExcel[])Utils.CopyArray(mPosicoes, new PosicoesExcel[num + 1]);
							mPosicoes[num].SSheet = worksheet.Name.ToUpper();
							mPosicoes[num].SPosicao = text2;
							mPosicoes[num].SNomeCampo = ((_Worksheet)worksheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
								.ToUpper();
						}
					}
				}
			}
			DeclaracoesGeral._uscPagina.pbFim();
			application.DisplayAlerts = false;
			workbook.Close(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			application.Quit();
		}
	}

	public static void PreencheTodosValorDoModelo(PosicoesExcel[] MPosicoes, ValoresExcel[] ValoresExcel)
	{
		bool flag = false;
		Process[] processes = Process.GetProcesses();
		foreach (Process process in processes)
		{
			if (Operators.CompareString(process.ProcessName.ToUpper(), "EXCEL", TextCompare: true) == 0)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			return;
		}
		Microsoft.Office.Interop.Excel.Application application = (Microsoft.Office.Interop.Excel.Application)excEXCEL.GetObject("Excel.Application");
		if (application.Workbooks.Count <= 0)
		{
			return;
		}
		Workbook activeWorkbook = application.ActiveWorkbook;
		checked
		{
			foreach (object sheet in activeWorkbook.Sheets)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(sheet);
				NewLateBinding.LateCall(activeWorkbook.Worksheets[RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, null, "Name", new object[0], null, null, null))], null, "Activate", new object[0], null, null, null, IgnoreReturn: true);
				objectValue = RuntimeHelpers.GetObjectValue(activeWorkbook.ActiveSheet);
				int num = Information.UBound(MPosicoes);
				for (int j = 1; j <= num; j++)
				{
					if (!Operators.ConditionalCompareObjectEqual(MPosicoes[j].SSheet, NewLateBinding.LateGet(objectValue, null, "Name", new object[0], null, null, null), TextCompare: true))
					{
						continue;
					}
					int num2 = Information.UBound(ValoresExcel);
					for (int k = 1; k <= num2; k++)
					{
						if (Operators.CompareString(ValoresExcel[k].SNomeCampo, MPosicoes[j].SNomeCampo, TextCompare: true) == 0)
						{
							object instance = objectValue;
							object[] array = new object[1];
							ref string sPosicao = ref MPosicoes[j].SPosicao;
							array[0] = sPosicao;
							object[] array2 = array;
							object instance2 = NewLateBinding.LateGet(instance, null, "Range", array, null, null, new bool[1] { true });
							sPosicao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
							NewLateBinding.LateSetComplex(instance2, null, "Value", new object[1] { ValoresExcel[k].SValor }, null, null, OptimisticSet: false, RValueBase: true);
						}
					}
				}
			}
		}
	}

	public static void PreencheUmValorNOExcel(string SSheet, string SCel1, string sValor)
	{
		Microsoft.Office.Interop.Excel.Application oExcelNew = null;
		Worksheet oSheet = null;
		if (VerificaExisteSheet(ref oExcelNew, ref oSheet, SSheet))
		{
			((_Worksheet)oSheet).get_Range((object)SCel1, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)sValor);
		}
	}

	public static void ApagaFigura(string ONomeSheet)
	{
		try
		{
			bool flag = false;
			Process[] processes = Process.GetProcesses();
			foreach (Process process in processes)
			{
				if (Operators.CompareString(process.ProcessName.ToUpper(), "EXCEL", TextCompare: true) == 0)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return;
			}
			Microsoft.Office.Interop.Excel.Application application = (Microsoft.Office.Interop.Excel.Application)excEXCEL.GetObject("Excel.Application");
			if (application.Workbooks.Count <= 0)
			{
				application.Workbooks.Add(RuntimeHelpers.GetObjectValue(Missing.Value));
			}
			else
			{
				_ = application.ActiveWorkbook;
			}
			_ = (Worksheet)application.ActiveSheet;
			try
			{
				int num = Conversions.ToInteger(NewLateBinding.LateGet(NewLateBinding.LateGet(application.ActiveSheet, null, "pictures", new object[0], null, null, null), null, "count", new object[0], null, null, null));
				if (num == 0 || num <= 0)
				{
					return;
				}
				foreach (object item in (IEnumerable)NewLateBinding.LateGet(application.ActiveSheet, null, "Pictures", new object[0], null, null, null))
				{
					object objectValue = RuntimeHelpers.GetObjectValue(item);
					NewLateBinding.LateCall(objectValue, null, "Delete", new object[0], null, null, null, IgnoreReturn: true);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			throw;
		}
	}

	public static int EncontraZoomPagina(ref Microsoft.Office.Interop.Excel.Application OExcelNew, ref Worksheet OSheetNew)
	{
		int num = 75;
		AtivaView(ref OExcelNew, bPreview: true);
		if (OSheetNew.VPageBreaks.Count > 0)
		{
			OSheetNew.VPageBreaks[1].DragOff(XlDirection.xlToRight, 1);
		}
		num = Conversions.ToInteger(OSheetNew.PageSetup.Zoom);
		AtivaView(ref OExcelNew, bPreview: false);
		return num;
	}

	public static void AtivaView(ref Microsoft.Office.Interop.Excel.Application OExcelNew, bool bPreview)
	{
		try
		{
			if (OExcelNew.Workbooks.Count > 0)
			{
				if (!bPreview)
				{
					OExcelNew.ActiveWindow.View = XlWindowView.xlNormalView;
				}
				else
				{
					OExcelNew.ActiveWindow.View = XlWindowView.xlPageBreakPreview;
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
	}

	public static void TrocaBarra(ref string SSheet)
	{
		string text = "";
		int num2;
		try
		{
			int num = Strings.Len(SSheet);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				string text2 = Strings.Mid(SSheet, i, 1);
				if (!(((Strings.Asc(text2) >= 48) & (Strings.Asc(text2) <= 57)) | ((Strings.Asc(text2) >= 65) & (Strings.Asc(text2) <= 90)) | ((Strings.Asc(text2) >= 97) & (Strings.Asc(text2) <= 122))))
				{
					string left = text2;
					if (Operators.CompareString(left, "/", TextCompare: true) != 0)
					{
						if (Operators.CompareString(left, "?", TextCompare: true) != 0 && Operators.CompareString(left, "!", TextCompare: true) != 0 && Operators.CompareString(left, "*", TextCompare: true) != 0 && Operators.CompareString(left, "@", TextCompare: true) != 0 && Operators.CompareString(left, "#", TextCompare: true) != 0 && Operators.CompareString(left, "$", TextCompare: true) != 0 && Operators.CompareString(left, "%", TextCompare: true) != 0 && Operators.CompareString(left, "&", TextCompare: true) != 0)
						{
							if (Operators.CompareString(left, "-", TextCompare: true) != 0)
							{
								if (Operators.CompareString(left, "(", TextCompare: true) != 0 && Operators.CompareString(left, ")", TextCompare: true) != 0 && Operators.CompareString(left, " ", TextCompare: true) != 0 && Operators.CompareString(left, "Ã", TextCompare: true) != 0 && Operators.CompareString(left, "É", TextCompare: true) != 0 && Operators.CompareString(left, "Ç", TextCompare: true) != 0)
								{
									text2 = "_";
								}
							}
							else
							{
								text2 = "-";
							}
						}
						else
						{
							text2 = "_";
						}
					}
					else
					{
						text2 = "|";
					}
				}
				else
				{
					text2 = text2;
				}
				text += text2;
			}
			num2 = Strings.Len(text);
			if (num2 > 31)
			{
				num2 = 31;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		SSheet = Strings.Mid(text, 1, num2);
		SSheet = SSheet.ToUpper();
	}

	public static void CriaLinhasExterna(ref Worksheet OSheet, string sRange, bool bCompleto)
	{
		try
		{
			((_Worksheet)OSheet).get_Range((object)sRange, RuntimeHelpers.GetObjectValue(Missing.Value)).Borders[XlBordersIndex.xlEdgeTop].Weight = 3;
			((_Worksheet)OSheet).get_Range((object)sRange, RuntimeHelpers.GetObjectValue(Missing.Value)).Borders[XlBordersIndex.xlEdgeBottom].Weight = 3;
			if (bCompleto)
			{
				((_Worksheet)OSheet).get_Range((object)sRange, RuntimeHelpers.GetObjectValue(Missing.Value)).Borders[XlBordersIndex.xlEdgeRight].Weight = 3;
				((_Worksheet)OSheet).get_Range((object)sRange, RuntimeHelpers.GetObjectValue(Missing.Value)).Borders[XlBordersIndex.xlEdgeLeft].Weight = 3;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public static void CriaLinhasExternaSimles(ref Worksheet OSheet, string sRange, bool bCompleto)
	{
		try
		{
			((_Worksheet)OSheet).get_Range((object)sRange, RuntimeHelpers.GetObjectValue(Missing.Value)).Borders[XlBordersIndex.xlEdgeTop].Weight = 3;
			((_Worksheet)OSheet).get_Range((object)sRange, RuntimeHelpers.GetObjectValue(Missing.Value)).Borders[XlBordersIndex.xlEdgeBottom].Weight = 3;
			if (bCompleto)
			{
				((_Worksheet)OSheet).get_Range((object)sRange, RuntimeHelpers.GetObjectValue(Missing.Value)).Borders[XlBordersIndex.xlEdgeRight].Weight = 3;
				((_Worksheet)OSheet).get_Range((object)sRange, RuntimeHelpers.GetObjectValue(Missing.Value)).Borders[XlBordersIndex.xlEdgeLeft].Weight = 3;
				((_Worksheet)OSheet).get_Range((object)sRange, RuntimeHelpers.GetObjectValue(Missing.Value)).Borders[XlBordersIndex.xlEdgeLeft].Weight = 2;
				((_Worksheet)OSheet).get_Range((object)sRange, RuntimeHelpers.GetObjectValue(Missing.Value)).Borders[XlBordersIndex.xlEdgeRight].Weight = 2;
			}
			((_Worksheet)OSheet).get_Range((object)sRange, RuntimeHelpers.GetObjectValue(Missing.Value)).Borders[XlBordersIndex.xlEdgeTop].Weight = 2;
			((_Worksheet)OSheet).get_Range((object)sRange, RuntimeHelpers.GetObjectValue(Missing.Value)).Borders[XlBordersIndex.xlEdgeBottom].Weight = 2;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public static void LimpaLinhasInterna(ref Worksheet OSheet, string sRange)
	{
		try
		{
			((_Worksheet)OSheet).get_Range((object)sRange, RuntimeHelpers.GetObjectValue(Missing.Value)).Borders.LineStyle = 0;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public static void CriaLinhasInterna(ref Worksheet OSheet, string sRange)
	{
		try
		{
			((_Worksheet)OSheet).get_Range((object)sRange, RuntimeHelpers.GetObjectValue(Missing.Value)).WrapText = true;
			((_Worksheet)OSheet).get_Range((object)sRange, RuntimeHelpers.GetObjectValue(Missing.Value)).Borders.LineStyle = 1;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public static void CriaLinhasPontilhadaInterna(ref Worksheet OSheet, string sRange)
	{
		try
		{
			((_Worksheet)OSheet).get_Range((object)sRange, RuntimeHelpers.GetObjectValue(Missing.Value)).WrapText = true;
			((_Worksheet)OSheet).get_Range((object)sRange, RuntimeHelpers.GetObjectValue(Missing.Value)).Borders.LineStyle = 3;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public static void SetarCorCelula(ref Worksheet OSheet, string sRange)
	{
		try
		{
			((_Worksheet)OSheet).get_Range((object)sRange, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 1;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public static void LimpaErro(ref Worksheet OSheet, string sLinha)
	{
		try
		{
			string cell = mudaNumeroAsc(1L) + sLinha.ToString() + ":" + mudaNumeroAsc(11L) + sLinha.ToString();
			((_Worksheet)OSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 0;
			((_Worksheet)OSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ClearComments();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public static void PintaCelula(ref Worksheet OSheet, string SColuna, string SLinha, string SMsg, int ICor, int IQuantLinhas = 0, int ILargura = 0)
	{
		try
		{
			string cell = SColuna + SLinha;
			if (Operators.CompareString(SMsg, "", TextCompare: true) == 0)
			{
				if (!Information.IsNothing(((_Worksheet)OSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Comment))
				{
					((_Worksheet)OSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Comment.Delete();
				}
				((_Worksheet)OSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = ICor;
				return;
			}
			try
			{
				if (Information.IsNothing(((_Worksheet)OSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Comment))
				{
					((_Worksheet)OSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).AddComment(RuntimeHelpers.GetObjectValue(Missing.Value));
				}
				((_Worksheet)OSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Comment.Visible = false;
				((_Worksheet)OSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Comment.Text(SMsg, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
				if (IQuantLinhas != 0)
				{
					((_Worksheet)OSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Comment.Shape.Height = checked(12 * IQuantLinhas);
				}
				if (ILargura != 0)
				{
					((_Worksheet)OSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Comment.Shape.Width = ILargura;
				}
				((_Worksheet)OSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = ICor;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			ProjectData.ClearProjectError();
		}
	}

	public static bool VerificaSheetVazia(ref Worksheet OSheet)
	{
		bool result = true;
		int num = 1;
		checked
		{
			do
			{
				int num2 = 1;
				do
				{
					string cell = mudaNumeroAsc(num2) + Conversions.ToString(num);
					if (Operators.CompareString(clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)OSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))), "", TextCompare: true) != 0)
					{
						result = false;
					}
					num2++;
				}
				while (num2 <= 15);
				num++;
			}
			while (num <= 60);
			return result;
		}
	}

	public static void SetaAreaDeImpressao(ref Worksheet OSheet, ref List<string> LSheetArea, string SCol, string SLin)
	{
		try
		{
			LSheetArea.Add(OSheet.Name);
			OSheet.PageSetup.PrintArea = "$A$1:$" + SCol + "$" + SLin;
			OSheet.HPageBreaks.Add(((_Worksheet)OSheet).get_Range((object)(SCol + "$" + Conversions.ToString(Conversions.ToDouble(SLin) + 1.0)), RuntimeHelpers.GetObjectValue(Missing.Value)));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public static void RemoveHPageBreaks(ref Worksheet OSheet)
	{
		try
		{
			int count = OSheet.HPageBreaks.Count;
			for (int i = count; i >= 0; i = checked(i + -1))
			{
				if (OSheet.VPageBreaks.Count > 0)
				{
					OSheet.VPageBreaks[1].DragOff(XlDirection.xlToRight, 1);
				}
				if (OSheet.HPageBreaks.Count > 0)
				{
					OSheet.HPageBreaks[1].DragOff(XlDirection.xlDown, 1);
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public static string mudaNumeroAsc(long iCol)
	{
		string text = "";
		while (iCol > 0L)
		{
			long num = checked((long)Conversion.Int((double)(iCol - 1L) / 26.0));
			long num2 = checked(iCol - 1L) % 26L;
			text = Conversions.ToString(Strings.Chr(checked((int)(num2 + 65L)))) + text;
			iCol = num;
		}
		return text;
	}

	public static void CopyValorCelula(ref Worksheet oSheet, string sDestino, string sOrigem)
	{
		((_Worksheet)oSheet).get_Range((object)sDestino, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(((_Worksheet)oSheet).get_Range((object)sOrigem, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
		((_Worksheet)oSheet).get_Range((object)sDestino, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = RuntimeHelpers.GetObjectValue(((_Worksheet)oSheet).get_Range((object)sOrigem, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold);
		((_Worksheet)oSheet).get_Range((object)sDestino, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Name = RuntimeHelpers.GetObjectValue(((_Worksheet)oSheet).get_Range((object)sOrigem, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Name);
		((_Worksheet)oSheet).get_Range((object)sDestino, RuntimeHelpers.GetObjectValue(Missing.Value)).WrapText = RuntimeHelpers.GetObjectValue(((_Worksheet)oSheet).get_Range((object)sOrigem, RuntimeHelpers.GetObjectValue(Missing.Value)).WrapText);
		((_Worksheet)oSheet).get_Range((object)sDestino, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = RuntimeHelpers.GetObjectValue(((_Worksheet)oSheet).get_Range((object)sOrigem, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight);
		((_Worksheet)oSheet).get_Range((object)sDestino, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = RuntimeHelpers.GetObjectValue(((_Worksheet)oSheet).get_Range((object)sOrigem, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size);
		((_Worksheet)oSheet).get_Range((object)sDestino, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = RuntimeHelpers.GetObjectValue(((_Worksheet)oSheet).get_Range((object)sOrigem, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment);
		((_Worksheet)oSheet).get_Range((object)sDestino, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = RuntimeHelpers.GetObjectValue(((_Worksheet)oSheet).get_Range((object)sOrigem, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment);
	}
}

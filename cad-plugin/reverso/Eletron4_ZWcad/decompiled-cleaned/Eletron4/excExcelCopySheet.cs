using System;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class excExcelCopySheet
{
	public struct Imagens
	{
		public string sNome;

		public float dTop;

		public float dLeft;

		public float dWidth;

		public float dHeight;
	}

	public static void Delete(string SNomeSheet)
	{
		ExcFuncoesExcel.TrocaBarra(ref SNomeSheet);
		Microsoft.Office.Interop.Excel.Application oExcelNew = null;
		Workbook oBook = null;
		Worksheet oSheet = null;
		if (!ExcFuncoesExcel.VerificaExcelAtivo(ref oExcelNew, ref oBook, ref oSheet))
		{
			return;
		}
		oBook.Application.DisplayAlerts = false;
		foreach (Worksheet sheet in oBook.Sheets)
		{
			if (sheet.Name.Contains(SNomeSheet))
			{
				NewLateBinding.LateCall(oBook.Sheets[SNomeSheet], null, "Delete", new object[0], null, null, null, IgnoreReturn: true);
				break;
			}
		}
		oBook.Application.DisplayAlerts = true;
	}

	public static string AddSheet(string sCaminho, string SNomeModelo, string SNomeSheet, bool BCriaSheetInicio = false)
	{
		string result = "";
		Microsoft.Office.Interop.Excel.Application oExcelNew = null;
		Workbook oBook = null;
		Worksheet oSheet = null;
		if (ExcFuncoesExcel.VerificaExcelAtivo(ref oExcelNew, ref oBook, ref oSheet))
		{
			oExcelNew.Visible = true;
		}
		bool flag = false;
		Microsoft.Office.Interop.Excel.Application application = (Microsoft.Office.Interop.Excel.Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
		application.Visible = false;
		Workbook workbook = application.Workbooks.Open(sCaminho, RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing));
		Worksheet worksheet = null;
		worksheet = (Worksheet)application.ActiveSheet;
		foreach (Worksheet sheet in workbook.Sheets)
		{
			worksheet = sheet;
			if (Operators.CompareString(worksheet.Name.ToUpper(), SNomeModelo.ToUpper(), TextCompare: true) == 0)
			{
				NewLateBinding.LateCall(workbook.Worksheets[SNomeModelo], null, "Activate", new object[0], null, null, null, IgnoreReturn: true);
				worksheet.Cells.Select();
				worksheet.Cells.Copy(RuntimeHelpers.GetObjectValue(Missing.Value));
				flag = true;
				result = SNomeModelo.ToUpper();
				break;
			}
		}
		checked
		{
			if (flag)
			{
				bool flag2 = false;
				ExcFuncoesExcel.TrocaBarra(ref SNomeSheet);
				foreach (Worksheet sheet2 in oBook.Sheets)
				{
					if (Operators.CompareString(sheet2.Name.ToUpper(), SNomeSheet.ToUpper(), TextCompare: true) == 0)
					{
						NewLateBinding.LateCall(oBook.Worksheets[SNomeSheet], null, "Activate", new object[0], null, null, null, IgnoreReturn: true);
						((_Worksheet)oSheet).get_Range((object)"A1", (object)"Z10000").EntireRow.Delete(RuntimeHelpers.GetObjectValue(Missing.Value));
						oSheet.Cells.ClearComments();
						ExcFuncoesExcel.ApagaFigura(SNomeSheet);
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					oSheet = (BCriaSheetInicio ? ((Worksheet)oBook.Sheets.Add(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value))) : ((Worksheet)oBook.Worksheets.Add(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(oBook.Worksheets[oBook.Worksheets.Count]), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value))));
					oSheet.Name = SNomeSheet.ToUpper();
				}
				int num = 1;
				do
				{
					string cell = ExcFuncoesExcel.mudaNumeroAsc(num) + "1";
					((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = RuntimeHelpers.GetObjectValue(((_Worksheet)worksheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth);
					num++;
				}
				while (num <= 20);
				int num2 = 1;
				do
				{
					string cell2 = "A" + num2;
					((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = RuntimeHelpers.GetObjectValue(((_Worksheet)worksheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight);
					num2++;
				}
				while (num2 <= 100);
				oSheet.Paste(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
				Imagens[] array = null;
				int num3 = 0;
				array = new Imagens[1];
				foreach (object shape in worksheet.Shapes)
				{
					object objectValue = RuntimeHelpers.GetObjectValue(shape);
					num3++;
					array = (Imagens[])Utils.CopyArray(array, new Imagens[num3 + 1]);
					array[num3].sNome = Conversions.ToString(NewLateBinding.LateGet(objectValue, null, "name", new object[0], null, null, null));
					array[num3].dTop = worksheet.Shapes.get_Range(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, null, "name", new object[0], null, null, null))).Top;
					array[num3].dLeft = worksheet.Shapes.get_Range(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, null, "name", new object[0], null, null, null))).Left;
					array[num3].dWidth = worksheet.Shapes.get_Range(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, null, "name", new object[0], null, null, null))).Width;
					array[num3].dHeight = worksheet.Shapes.get_Range(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, null, "name", new object[0], null, null, null))).Height;
				}
				if (num3 > 0)
				{
					foreach (object item in (IEnumerable)NewLateBinding.LateGet(application.ActiveSheet, null, "Shapes", new object[0], null, null, null))
					{
						object objectValue2 = RuntimeHelpers.GetObjectValue(item);
						try
						{
							NewLateBinding.LateCall(objectValue2, null, "copy", new object[0], null, null, null, IgnoreReturn: true);
							oSheet.Paste(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
						}
					}
					num3 = 1;
					foreach (object shape2 in oSheet.Shapes)
					{
						object objectValue3 = RuntimeHelpers.GetObjectValue(shape2);
						if (num3 <= Information.UBound(array))
						{
							oSheet.Shapes.get_Range(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue3, null, "name", new object[0], null, null, null))).Top = array[num3].dTop;
							oSheet.Shapes.get_Range(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue3, null, "name", new object[0], null, null, null))).Left = array[num3].dLeft;
							oSheet.Shapes.get_Range(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue3, null, "name", new object[0], null, null, null))).Width = array[num3].dWidth;
							oSheet.Shapes.get_Range(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue3, null, "name", new object[0], null, null, null))).Height = array[num3].dHeight;
							num3++;
							continue;
						}
						break;
					}
				}
				Clipboard.Clear();
				if (Operators.CompareString(SNomeSheet.ToUpper(), "CAPA", TextCompare: true) == 0)
				{
					oBook.Application.DisplayAlerts = false;
					foreach (Worksheet sheet3 in oBook.Sheets)
					{
						Worksheet OSheet = sheet3;
						if (OSheet.Name.Contains("Plan") && ExcFuncoesExcel.VerificaSheetVazia(ref OSheet))
						{
							NewLateBinding.LateCall(oBook.Sheets[OSheet.Name], null, "Delete", new object[0], null, null, null, IgnoreReturn: true);
						}
					}
					oBook.Application.DisplayAlerts = true;
				}
			}
			application.DisplayAlerts = false;
			oExcelNew.DisplayAlerts = false;
			workbook.Close(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			application.Quit();
			return result;
		}
	}
}

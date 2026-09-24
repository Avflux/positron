using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class Relatorios_ExcelComum_ENEL
{
	public static void CriaListaCabos_ENEL_EXCEL(string sNomeSheet, string sRev, string sDt, string sDesc, string sExec, DataGridView dg)
	{
		checked
		{
			try
			{
				int count = dg.Rows.Count;
				double num = (double)count / 49.0;
				string value = Conversions.ToString(Conversion.Int(num));
				string value2 = Conversions.ToString(num - Conversions.ToDouble(value));
				num = Conversions.ToDouble(value);
				if (Conversions.ToDouble(value2) > 0.0)
				{
					num++;
				}
				Microsoft.Office.Interop.Excel.Application oExcelNew = null;
				Workbook oBook = null;
				Worksheet oSheet = null;
				if (ExcFuncoesExcel.VerificaExcelAtivo(ref oExcelNew, ref oBook, ref oSheet))
				{
					oExcelNew.Visible = true;
				}
				ExcFuncoesExcel.VerificaExcel(ref oExcelNew, ref oSheet, sNomeSheet.ToUpper());
				foreach (Worksheet sheet in oBook.Sheets)
				{
					if (Operators.CompareString(sheet.Name.ToUpper(), sNomeSheet.ToUpper(), TextCompare: true) == 0)
					{
						NewLateBinding.LateCall(oBook.Worksheets[sNomeSheet], null, "Activate", new object[0], null, null, null, IgnoreReturn: true);
						((_Worksheet)oSheet).get_Range((object)"A1", (object)"Z10000").EntireRow.Delete(RuntimeHelpers.GetObjectValue(Missing.Value));
						oSheet.Cells.ClearComments();
						ExcFuncoesExcel.ApagaFigura(sNomeSheet);
						break;
					}
				}
				bool flag = false;
				Microsoft.Office.Interop.Excel.Application application = (Microsoft.Office.Interop.Excel.Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
				application.Visible = false;
				Workbook workbook = application.Workbooks.Open("C:\\Program Files\\Eletron4\\MODELOS\\Modelo Lista de Cabos ENEL.xls", RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing), RuntimeHelpers.GetObjectValue(Type.Missing));
				Worksheet worksheet2 = null;
				worksheet2 = (Worksheet)application.ActiveSheet;
				foreach (Worksheet sheet2 in workbook.Sheets)
				{
					worksheet2 = sheet2;
					if (Operators.CompareString(worksheet2.Name.ToUpper(), "LC", TextCompare: true) == 0)
					{
						NewLateBinding.LateCall(workbook.Worksheets["LC"], null, "Activate", new object[0], null, null, null, IgnoreReturn: true);
						int num2 = 1;
						do
						{
							string cell = ExcFuncoesExcel.mudaNumeroAsc(num2) + "1";
							((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = RuntimeHelpers.GetObjectValue(((_Worksheet)worksheet2).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth);
							num2++;
						}
						while (num2 <= 7);
						flag = true;
						break;
					}
				}
				List<int> list = new List<int>();
				int num3 = 0;
				int num4 = 0;
				int num5 = (int)Math.Round(num - 1.0);
				for (int i = 0; i <= num5; i++)
				{
					ExcFuncoesExcel.VerificaExcelAtivo(ref oExcelNew, ref oBook, ref oSheet);
					ExcFuncoesExcel.DesativaCalculoExcel(ref oExcelNew);
					ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
					int num6 = 0;
					num6 = i * 61 + 1;
					string cell = "A" + num6;
					((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
					list.Add(num6 + 3);
					num3 = num6 + 3;
					if (flag)
					{
						string cell2 = "A1:F61";
						((_Worksheet)worksheet2).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
						worksheet2.Cells.Copy(RuntimeHelpers.GetObjectValue(Missing.Value));
						oSheet.Paste(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
						oExcelNew.ScreenUpdating = true;
						if (i == 0)
						{
							int num7 = 80;
							num7 = ExcFuncoesExcel.EncontraZoomPagina(ref oExcelNew, ref oSheet);
							ExcFuncoesExcel.FormataPagina(ref oExcelNew, ref oSheet, num7);
						}
						if (num4 > dg.Rows.Count)
						{
							break;
						}
						int num8 = 1;
						int num9 = 0;
						cell = "A" + (num6 + 58);
						((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
						ExcFuncoesExcel.InsereFigura1(ref oSheet, cell, DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "ENEL1.png", 15, 30);
						int num10 = num3;
						int num11 = num4;
						int num12 = dg.Rows.Count - 1;
						for (num9 = num11; num9 <= num12; num9++)
						{
							cell = "A" + num10;
							((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
							((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(dg.Rows[num9].Cells[1].Value));
							cell = "B" + num10;
							((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(dg.Rows[num9].Cells[2].Value));
							cell = "C" + num10;
							((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(dg.Rows[num9].Cells[3].Value));
							cell = "D" + num10;
							((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(dg.Rows[num9].Cells[4].Value));
							cell = "E" + num10;
							((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(dg.Rows[num9].Cells[5].Value));
							cell = "F" + num10;
							((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(dg.Rows[num9].Cells[6].Value));
							num10++;
							num8++;
							if (num8 == 51)
							{
								break;
							}
						}
						num4 = num9 + 1;
					}
					int num13 = num6 + 54;
					cell = "A" + num13;
					((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
					((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)sRev);
					cell = "B" + num13;
					((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)sDt);
					cell = "C" + num13;
					((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)sDesc);
					cell = "F" + num13;
					((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)sExec);
					cell = "A" + (num6 + 58);
					((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
					System.Windows.Forms.Application.DoEvents();
					ExcFuncoesExcel.DesativaCalculoExcel(ref oExcelNew);
					ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
				}
				excExcelCopySheet.Delete("LC");
				excExcelCopySheet.Delete("Planilha1");
				excExcelCopySheet.Delete("Plan1");
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}
}

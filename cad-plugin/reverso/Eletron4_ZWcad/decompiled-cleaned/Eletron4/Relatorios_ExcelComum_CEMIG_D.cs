using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class Relatorios_ExcelComum_CEMIG_D
{
	public static void preencheIndiceComumExcel(string sSheet, string sEquip, string sDesc1, string sDesc2, string sDesc3, string sRev, string sDesenho, string sFl, int iInicio = 1, int iFim = 100)
	{
		Microsoft.Office.Interop.Excel.Application oExcelNew = null;
		Worksheet oSheet = null;
		if (!ExcFuncoesExcel.VerificaExisteSheet(ref oExcelNew, ref oSheet, sSheet))
		{
			return;
		}
		int num = 1;
		checked
		{
			do
			{
				string text = ExcFuncoesExcel.mudaNumeroAsc(num);
				for (int i = iInicio; i <= iFim; i++)
				{
					string cell = text + i;
					string left = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))).ToString().ToUpper();
					if (Operators.CompareString(left, "#EQUIPAMENTO#", TextCompare: true) != 0)
					{
						if (Operators.CompareString(left, "#DESC1#", TextCompare: true) != 0)
						{
							if (Operators.CompareString(left, "#DESC2#", TextCompare: true) != 0)
							{
								if (Operators.CompareString(left, "#DESC3#", TextCompare: true) != 0)
								{
									if (Operators.CompareString(left, "#REV#", TextCompare: true) != 0)
									{
										if (Operators.CompareString(left, "#DESENHO#", TextCompare: true) != 0)
										{
											if (Operators.CompareString(left, "#FL#", TextCompare: true) == 0)
											{
												((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)sFl);
											}
										}
										else
										{
											((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)sDesenho);
										}
									}
									else
									{
										((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)sRev);
									}
								}
								else
								{
									((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)sDesc3);
								}
							}
							else
							{
								((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)sDesc2);
							}
						}
						else
						{
							((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)sDesc1);
						}
					}
					else
					{
						((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)sEquip);
					}
				}
				num++;
			}
			while (num <= 20);
		}
	}

	public static void CriaListaCabosEletronCEMIG_D_EXCEL(string sNomeSheet, DataGridView dg)
	{
		checked
		{
			try
			{
				Microsoft.Office.Interop.Excel.Application oExcelNew = null;
				Worksheet oSheet = null;
				long num = 1L;
				if (!ExcFuncoesExcel.VerificaExisteSheet(ref oExcelNew, ref oSheet, sNomeSheet))
				{
					ExcFuncoesExcel.VerificaExisteSheet(ref oExcelNew, ref oSheet, sNomeSheet);
				}
				int num2 = 8;
				((_Worksheet)oSheet).get_Range((object)("A" + num2), (object)"M10000").EntireRow.Clear();
				Thread.Sleep(400);
				num = num2;
				string text = "";
				string text2 = "";
				int num3 = 0;
				int num4 = 1;
				int num5 = dg.RowCount - 1;
				for (int i = 0; i <= num5; i++)
				{
					int num6 = dg.ColumnCount - 1;
					for (int j = 0; j <= num6; j++)
					{
						text2 = ((j != dg.ColumnCount - 1) ? (text2 + clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dg.Rows[i].Cells[j].Value)) + "\t") : (text2 + clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dg.Rows[i].Cells[j].Value)) + "\r"));
					}
					num++;
					num4++;
					if (num4 == 12)
					{
						num3++;
						num4 = 1;
					}
				}
				double a = (double)dg.RowCount / 12.0;
				num3 = (int)Math.Round(a);
				System.Windows.Clipboard.Clear();
				System.Windows.Clipboard.SetText(text2);
				text = "A" + num2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
				oSheet.Paste(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
				string text3 = "A" + num2 + ":L" + Conversions.ToString(num - 1L);
				((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text3);
				ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text3, bCompleto: true);
				ExcFuncoesExcel.RemoveHPageBreaks(ref oSheet);
				int num7 = 0;
				int num8 = num3;
				for (int k = 1; k <= num8; k++)
				{
					num7 = k * 12 + num2;
					text = "L" + Conversions.ToString(num7);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
					oSheet.HPageBreaks.Add(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)));
				}
				oSheet.PageSetup.PrintArea = "$A$1:$L$" + Conversions.ToString(num7 - 1);
				oExcelNew.ScreenUpdating = true;
				num3++;
				text = "A1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
				DeclaracoesGeral._uscPagina.pbFim();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				DeclaracoesGeral._uscPagina.pbFim();
				ProjectData.ClearProjectError();
			}
		}
	}
}

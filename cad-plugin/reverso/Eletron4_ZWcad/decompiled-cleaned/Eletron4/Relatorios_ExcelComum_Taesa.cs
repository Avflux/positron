using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class Relatorios_ExcelComum_Taesa
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

	public static void CriaListaCabosEletronTaesaEXCEL(string sNomeSheet, DataGridView dg, string sRev, string sDesenho, string sTit1, string sTit2, string sTit3, ref Relatorios_ListaCabosEXCEL.indiceRelatorioCabos[] mIndice)
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
				((_Worksheet)oSheet).get_Range((object)"A8", (object)"M10000").EntireRow.Clear();
				Thread.Sleep(400);
				num = 8L;
				string text = "";
				string text2 = "";
				int num2 = dg.RowCount - 1;
				for (int i = 0; i <= num2; i++)
				{
					int num3 = dg.ColumnCount - 1;
					for (int j = 0; j <= num3; j++)
					{
						text2 = ((j != dg.ColumnCount - 1) ? (text2 + clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dg.Rows[i].Cells[j].Value)) + "\t") : (text2 + clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dg.Rows[i].Cells[j].Value)) + "\r"));
					}
					num++;
				}
				System.Windows.Clipboard.Clear();
				System.Windows.Clipboard.SetText(text2);
				text = "A8";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
				oSheet.Paste(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
				ExcFuncoesExcel.DesativaCalculoExcel(ref oExcelNew);
				Thread.Sleep(400);
				ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
				string cell = "B8:C" + Conversions.ToString(num - 1L);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				cell = "F8:G" + Conversions.ToString(num - 1L);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				cell = "J8:J" + Conversions.ToString(num - 1L);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				cell = "A8:M" + Conversions.ToString(num - 1L);
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, cell);
				ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, cell, bCompleto: true);
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

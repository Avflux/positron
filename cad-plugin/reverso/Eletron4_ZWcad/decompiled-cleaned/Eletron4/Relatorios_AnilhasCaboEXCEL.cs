using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class Relatorios_AnilhasCaboEXCEL
{
	public static void CriaListaAnilhasCaboEXCEL(DataGridView dgAnilhas, string sNomeSheet)
	{
		try
		{
			Microsoft.Office.Interop.Excel.Application oExcelNew = null;
			Worksheet oSheet = null;
			ExcFuncoesExcel.VerificaExcel(ref oExcelNew, ref oSheet, sNomeSheet);
			ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
			((_Worksheet)oSheet).get_Range((object)"A1", (object)"Z10000").EntireRow.Delete(RuntimeHelpers.GetObjectValue(Missing.Value));
			oSheet.Cells.ClearComments();
			eXM3PXoyDb(ref oSheet, dgAnilhas);
			string cell = "A1";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
			DeclaracoesGeral._uscPagina.pbFim();
			ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			DeclaracoesGeral._uscPagina.pbFim();
			ProjectData.ClearProjectError();
		}
	}

	private static void eXM3PXoyDb(ref Worksheet P_0, DataGridView P_1)
	{
		checked
		{
			try
			{
				AUc3cyReIe(ref P_0);
				string text = "";
				int num = 3;
				int num2 = P_1.RowCount - 1;
				for (int i = 0; i <= num2; i++)
				{
					text = "A" + Conversions.ToString(num);
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", P_1.Rows[i].Cells[0].Value));
					text = "B" + Conversions.ToString(num);
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", P_1.Rows[i].Cells[1].Value));
					text = "C" + Conversions.ToString(num);
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", P_1.Rows[i].Cells[2].Value));
					num++;
					string cell = "A" + Conversions.ToString(num + 3);
					((_Worksheet)P_0).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
				}
				text = "A3:C" + Conversions.ToString(num - 1);
				ExcFuncoesExcel.CriaLinhasInterna(ref P_0, text);
				ExcFuncoesExcel.CriaLinhasExterna(ref P_0, text, bCompleto: true);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	private static void AUc3cyReIe(ref Worksheet P_0)
	{
		try
		{
			string text = "";
			text = "A1";
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 20;
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 514]));
			text = "B1";
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1239]));
			text = "C1";
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 30;
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1782]));
			text = "A1:C1";
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
			ExcFuncoesExcel.CriaLinhasExterna(ref P_0, text, bCompleto: true);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}
}

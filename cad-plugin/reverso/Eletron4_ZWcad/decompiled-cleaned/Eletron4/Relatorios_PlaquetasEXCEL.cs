using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class Relatorios_PlaquetasEXCEL
{
	public static void ExportaPlaquetas(ref Worksheet oSheet, ref DataGridView dg)
	{
		string text = "";
		Microsoft.Office.Interop.Excel.Application oExcelNew = null;
		ExcFuncoesExcel.VerificaExcel(ref oExcelNew, ref oSheet, DeclaracoesGeral.mMensagem[1, 582].ToString().ToUpper());
		ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
		ExcFuncoesExcel.LimpaSheet(ref oSheet);
		int num = 1;
		text = "A" + Conversions.ToString(1);
		((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 804]));
		((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 20;
		text = "B" + Conversions.ToString(1);
		((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 805]));
		((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 30;
		text = "C" + Conversions.ToString(1);
		((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 806]));
		((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 30;
		text = "D" + Conversions.ToString(1);
		((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 807]));
		((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 30;
		text = "E" + Conversions.ToString(1);
		((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 808]));
		((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
		DeclaracoesGeral._uscPagina.pbPasso();
		text = "A1:E1";
		((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
		((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
		checked
		{
			text = "A2:E" + Conversions.ToString(dg.RowCount + 1);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 2;
			text = "B2:D" + Conversions.ToString(dg.RowCount + 1);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).WrapText = true;
			num = 2;
			try
			{
				int num2 = (int)(dg.RowCount - 1L);
				for (int i = 0; i <= num2; i++)
				{
					int num3 = 3;
					do
					{
						text = ExcFuncoesExcel.mudaNumeroAsc(num3 - 2) + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + dg.Rows[i].Cells[num3].Value.ToString()));
						num3++;
					}
					while (num3 <= 7);
					num++;
					DeclaracoesGeral._uscPagina.pbPasso();
				}
				text = "A1:E" + Conversions.ToString(num - 1);
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
				string cell = "A1";
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			DeclaracoesGeral._uscPagina.pbFim();
		}
	}

	public static void ImportarPlaquetas(ref Worksheet oSheet, ref DataGridView dg)
	{
		string text = "";
		Microsoft.Office.Interop.Excel.Application oExcelNew = null;
		if (!ExcFuncoesExcel.VerificaExisteSheet(ref oExcelNew, ref oSheet, DeclaracoesGeral.mMensagem[1, 582].ToString().ToUpper(), bMaximiza: false))
		{
			return;
		}
		checked
		{
			try
			{
				_ = ((_Worksheet)oSheet).get_Range((object)"E1", RuntimeHelpers.GetObjectValue(Missing.Value)).get_End(XlDirection.xlDown).Row;
				int rowCount = dg.RowCount;
				for (int i = 0; i <= rowCount; i++)
				{
					int num = i + 2;
					text = "B" + Conversions.ToString(num);
					dg.Rows[i].Cells[4].Value = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
					text = "C" + Conversions.ToString(num);
					dg.Rows[i].Cells[5].Value = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
					text = "D" + Conversions.ToString(num);
					dg.Rows[i].Cells[6].Value = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
					text = "E" + Conversions.ToString(num);
					dg.Rows[i].Cells[7].Value = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			DeclaracoesGeral._uscPagina.pbFim();
		}
	}

	public static void CriaPlaquetasEXCEL(DeclaracoesFiacao.structureRelPlaquetas[] mRelPlaquetas, string sPainel)
	{
		checked
		{
			try
			{
				bool flag = false;
				MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1575]), MsgBoxStyle.YesNo, "Elétron");
				if (msgBoxResult == MsgBoxResult.Yes)
				{
					flag = true;
				}
				if (Information.IsNothing(mRelPlaquetas))
				{
					return;
				}
				Microsoft.Office.Interop.Excel.Application oExcelNew = null;
				Worksheet oSheet = null;
				string oNomeSheet = "Plaquetas_" + sPainel;
				ExcFuncoesExcel.VerificaExcel(ref oExcelNew, ref oSheet, oNomeSheet);
				ExcFuncoesExcel.DesativaCalculoExcel(ref oExcelNew);
				((_Worksheet)oSheet).get_Range((object)"A1", (object)"Z10000").EntireRow.Delete(RuntimeHelpers.GetObjectValue(Missing.Value));
				oSheet.Cells.ClearComments();
				ExcFuncoesExcel.ApagaFigura(oNomeSheet);
				long num = 1L;
				string text = "";
				text = "A1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "B1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "C1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "D1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "E1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				if (!flag)
				{
					text = "F1";
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				}
				text = "A" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 804].ToString().ToUpper()));
				text = "B" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 805].ToString().ToUpper()));
				text = "C" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 806].ToString().ToUpper()));
				text = "D" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 807].ToString().ToUpper()));
				text = "E" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 808].ToString().ToUpper()));
				if (!flag)
				{
					text = "F" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 797].ToString().ToUpper()));
				}
				text = "A" + Conversions.ToString(num) + ":E" + Conversions.ToString(num);
				if (!flag)
				{
					text = "A" + Conversions.ToString(num) + ":F" + Conversions.ToString(num);
				}
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
				ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
				num++;
				text = "A" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 9;
				num++;
				string text2 = "";
				int num2 = 0;
				DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mRelPlaquetas);
				DeclaracoesGeral._uscPagina.pbIniciar();
				int num3 = Information.UBound(mRelPlaquetas);
				for (int i = 1; i <= num3; i++)
				{
					num2 = Conversions.ToInteger(mRelPlaquetas[i].Quant);
					while (true)
					{
						text2 = "A" + Conversions.ToString(num + 2L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
						if (i != 0)
						{
						}
						if (Operators.CompareString(mRelPlaquetas[i].Nome, "##B##", TextCompare: true) == 0)
						{
							mRelPlaquetas[i].Nome = "";
						}
						if (Operators.CompareString(mRelPlaquetas[i].Desc1, "##B##", TextCompare: true) == 0)
						{
							mRelPlaquetas[i].Desc1 = "";
						}
						if (Operators.CompareString(mRelPlaquetas[i].Desc2, "##B##", TextCompare: true) == 0)
						{
							mRelPlaquetas[i].Desc2 = "";
						}
						if (Operators.CompareString(mRelPlaquetas[i].Desc3, "##B##", TextCompare: true) == 0)
						{
							mRelPlaquetas[i].Desc3 = "";
						}
						if (Operators.CompareString(mRelPlaquetas[i].Modelo, "##B##", TextCompare: true) == 0)
						{
							mRelPlaquetas[i].Modelo = "";
						}
						text = "A" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mRelPlaquetas[i].Nome));
						text = "B" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mRelPlaquetas[i].Desc1));
						text = "C" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mRelPlaquetas[i].Desc2));
						text = "D" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mRelPlaquetas[i].Desc3));
						text = "E" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mRelPlaquetas[i].Modelo));
						if (!flag)
						{
							text = "F" + Conversions.ToString(num);
							((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mRelPlaquetas[i].Quant));
						}
						text = "E" + Conversions.ToString(num) + ":F" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						text = "A" + Conversions.ToString(num) + ":E" + Conversions.ToString(num);
						if (!flag)
						{
							text = "A" + Conversions.ToString(num) + ":F" + Conversions.ToString(num);
						}
						ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
						num++;
						if (!flag || num2 <= 1)
						{
							break;
						}
						num2--;
					}
					DeclaracoesGeral._uscPagina.pbPasso();
				}
				text2 = "A1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
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
	}
}

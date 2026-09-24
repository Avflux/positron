using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class excDispositivos
{
	public struct structureNomes
	{
		public string N1;

		public string N2;

		public string A;

		public string handle;
	}

	public static void ExportaDispositivosParaOExcel(ref Worksheet oSheet, ref DataGridView dg)
	{
		string text = "";
		int num = 1;
		text = "A1:Z10000";
		((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).EntireRow.Delete(RuntimeHelpers.GetObjectValue(Missing.Value));
		((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 15;
		int num2 = 1;
		checked
		{
			string cell;
			do
			{
				cell = ExcFuncoesExcel.mudaNumeroAsc(num2) + "1";
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				num2++;
			}
			while (num2 <= 15);
			cell = ExcFuncoesExcel.mudaNumeroAsc(1L) + "1";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 627].ToString().ToUpper());
			cell = ExcFuncoesExcel.mudaNumeroAsc(2L) + "1";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 628].ToString().ToUpper());
			cell = ExcFuncoesExcel.mudaNumeroAsc(3L) + "1";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 629].ToString().ToUpper());
			cell = ExcFuncoesExcel.mudaNumeroAsc(4L) + "1";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"Handle");
			ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(4L), "1", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1194]), 43, 2, 150);
			num++;
			if (dg.RowCount > 0)
			{
				DeclaracoesGeral._uscPagina.Quantidade = dg.RowCount;
				DeclaracoesGeral._uscPagina.pbIniciar();
				int num3 = dg.RowCount - 1;
				for (int i = 0; i <= num3; i++)
				{
					DeclaracoesGeral._uscPagina.pbPasso();
					text = "A" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", dg.Rows[i].Cells[0].Value));
					text = "B" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", dg.Rows[i].Cells[1].Value));
					text = "C" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", dg.Rows[i].Cells[2].Value));
					text = "D" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", dg.Rows[i].Cells[5].Value));
					num++;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
				}
				text = "A1:D" + Conversions.ToString(num - 1);
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
				DeclaracoesGeral._uscPagina.pbFim();
			}
		}
	}

	public static bool ExisteNomesIguais(ref Worksheet oSheet, ref DataGridView dg)
	{
		bool result = true;
		checked
		{
			try
			{
				string text = "A2";
				string text2 = "B2";
				string text3 = "C2";
				int num = 1;
				structureNomes[] array = new structureNomes[1];
				num = ((_Worksheet)oSheet).get_Range((object)"A1", RuntimeHelpers.GetObjectValue(Missing.Value)).get_End(XlDirection.xlDown).Row;
				text = "A" + Conversions.ToString(2) + ":D" + Conversions.ToString(num + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 0;
				oSheet.Cells.ClearComments();
				List<string> list = new List<string>();
				List<string> list2 = new List<string>();
				List<string> list3 = new List<string>();
				List<string> list4 = new List<string>();
				int num2 = num;
				for (int i = 2; i <= num2; i++)
				{
					array = (structureNomes[])Utils.CopyArray(array, new structureNomes[i + 1]);
					text = "A" + Conversions.ToString(i);
					array[i].N1 = ((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
						.Trim();
					text = "B" + Conversions.ToString(i);
					array[i].N2 = ((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
						.Trim();
					text = "C" + Conversions.ToString(i);
					array[i].A = ((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
						.Trim();
					text = "D" + Conversions.ToString(i);
					array[i].handle = Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
					string text4 = array[i].N1 + array[i].N2;
					if (list.Contains(text4))
					{
						if (Operators.CompareString(clsTextos.TiraNothing(text4), "", TextCompare: true) != 0)
						{
							list3.Add(text4);
						}
					}
					else
					{
						list.Add(text4);
					}
					text4 = array[i].A;
					if (list2.Contains(text4))
					{
						if (Operators.CompareString(clsTextos.TiraNothing(text4), "", TextCompare: true) != 0)
						{
							list4.Add(text4);
						}
					}
					else
					{
						list2.Add(text4);
					}
				}
				if (!((list3.Count > 0) | (list4.Count > 0)))
				{
					int num3 = dg.RowCount - 1;
					for (int j = 0; j <= num3; j++)
					{
						structureNomes[] array2 = array;
						for (int k = 0; k < array2.Length; k++)
						{
							structureNomes structureNomes2 = array2[k];
							bool flag = false;
							if (Operators.CompareString(clsTextos.TiraNothing(structureNomes2.handle), "", TextCompare: true) != 0 && Operators.ConditionalCompareObjectEqual(dg.Rows[j].Cells[5].Value, structureNomes2.handle, TextCompare: true))
							{
								if (Operators.ConditionalCompareObjectNotEqual(dg.Rows[j].Cells[0].Value, structureNomes2.N1, TextCompare: true))
								{
									dg.Rows[j].Cells[0].Value = structureNomes2.N1;
									flag = true;
									dg.Rows[j].Cells[0].Style.BackColor = Color.Yellow;
								}
								if (Operators.ConditionalCompareObjectNotEqual(dg.Rows[j].Cells[1].Value, structureNomes2.N2, TextCompare: true))
								{
									dg.Rows[j].Cells[1].Value = structureNomes2.N2;
									flag = true;
									dg.Rows[j].Cells[1].Style.BackColor = Color.Yellow;
								}
								if (Operators.ConditionalCompareObjectNotEqual(dg.Rows[j].Cells[2].Value, structureNomes2.A, TextCompare: true))
								{
									dg.Rows[j].Cells[2].Value = structureNomes2.A;
									flag = true;
									dg.Rows[j].Cells[2].Style.BackColor = Color.Yellow;
								}
								dg.Rows[j].Cells[6].Value = flag;
								break;
							}
						}
					}
				}
				else
				{
					int num4 = num;
					for (int l = 2; l <= num4; l++)
					{
						text = "A" + Conversions.ToString(l);
						text2 = "B" + Conversions.ToString(l);
						string item = Conversions.ToString(Operators.ConcatenateObject(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), ((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
						if (list3.Contains(item))
						{
							ExcFuncoesExcel.PintaCelula(ref oSheet, "A", Conversions.ToString(l), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1601]), 46, 1, 100);
							ExcFuncoesExcel.PintaCelula(ref oSheet, "B", Conversions.ToString(l), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1601]), 46, 1, 100);
						}
						text3 = "C" + Conversions.ToString(l);
						item = Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
						if (list4.Contains(item))
						{
							ExcFuncoesExcel.PintaCelula(ref oSheet, "C", Conversions.ToString(l), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1601]), 46, 1, 100);
						}
					}
				}
				DeclaracoesGeral._uscPagina.pbFim();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}
}

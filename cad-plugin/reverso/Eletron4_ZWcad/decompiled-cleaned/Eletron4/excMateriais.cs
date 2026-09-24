using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class excMateriais
{
	public static void ImportaMateriais(ref Worksheet oSheet, ref DataGridView dg)
	{
		checked
		{
			try
			{
				string text = "";
				int i = 2;
				int num = 2;
				text = "A2";
				while (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
				{
					num++;
					text = "A" + Conversions.ToString(num);
				}
				cDadosAccessMateriais cDadosAccessMateriais2 = new cDadosAccessMateriais();
				DeclaracoesGeral._uscPagina.Quantidade = num;
				DeclaracoesGeral._uscPagina.pbIniciar();
				List<int> list = new List<int>();
				new List<int>();
				bool flag = true;
				for (; Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)("A" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true); i++)
				{
					ExcFuncoesExcel.PintaCelula(ref oSheet, "A", Conversions.ToString(i), "", 0);
					if (!Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(((_Worksheet)oSheet).get_Range((object)("A" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))))
					{
						ExcFuncoesExcel.PintaCelula(ref oSheet, "A", Conversions.ToString(i), "", 3);
						flag = false;
					}
					else if (!list.Contains(Conversions.ToInteger(((_Worksheet)oSheet).get_Range((object)("A" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))))
					{
						list.Add(Conversions.ToInteger(((_Worksheet)oSheet).get_Range((object)("A" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
					}
					else
					{
						ExcFuncoesExcel.PintaCelula(ref oSheet, "A", Conversions.ToString(i), "Não pode haver valores duplicados", 3);
						flag = false;
					}
				}
				if (flag)
				{
					for (i = 2; Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)("A" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true); i++)
					{
						DeclaracoesGeral._uscPagina.pbPasso();
						flag = true;
						string text2 = Conversions.ToString(((_Worksheet)oSheet).get_Range((object)("A" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
						string text3 = Conversions.ToString(((_Worksheet)oSheet).get_Range((object)("B" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
						string text4 = Conversions.ToString(((_Worksheet)oSheet).get_Range((object)("C" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
						string text5 = Conversions.ToString(((_Worksheet)oSheet).get_Range((object)("D" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
						string text6 = Conversions.ToString(((_Worksheet)oSheet).get_Range((object)("E" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
						string text7 = Conversions.ToString(((_Worksheet)oSheet).get_Range((object)("F" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
						if (Operators.CompareString(text3, null, TextCompare: true) == 0)
						{
							text3 = "";
						}
						if (Operators.CompareString(text4, null, TextCompare: true) == 0)
						{
							text4 = "";
						}
						if (Operators.CompareString(text5, null, TextCompare: true) == 0)
						{
							text5 = "";
						}
						if (Operators.CompareString(text6, null, TextCompare: true) == 0)
						{
							text6 = "";
						}
						if (Operators.CompareString(text7, null, TextCompare: true) == 0)
						{
							text7 = "";
						}
						int num2 = dg.Rows.Count - 1;
						for (int j = 0; j <= num2; j++)
						{
							if (Operators.ConditionalCompareObjectEqual(dg.Rows[j].Cells[6].Value, text2, TextCompare: true))
							{
								flag = false;
								if (Operators.CompareString(dg.Rows[j].Cells[1].Value.ToString(), text3, TextCompare: true) != 0)
								{
									dg.Rows[j].Cells[1].Value = text3;
									Color yellow = Color.Yellow;
									dg.Rows[j].Cells[1].Style.BackColor = yellow;
									dg.Rows[j].Cells[7].Value = "E";
								}
								if (Operators.CompareString(dg.Rows[j].Cells[2].Value.ToString(), text4, TextCompare: true) != 0)
								{
									dg.Rows[j].Cells[2].Value = text4;
									Color yellow = Color.Yellow;
									dg.Rows[j].Cells[2].Style.BackColor = yellow;
									dg.Rows[j].Cells[7].Value = "E";
								}
								if (Operators.ConditionalCompareObjectNotEqual(dg.Rows[j].Cells[3].Value, text5, TextCompare: true))
								{
									dg.Rows[j].Cells[3].Value = text5;
									Color yellow = Color.Yellow;
									dg.Rows[j].Cells[3].Style.BackColor = yellow;
									dg.Rows[j].Cells[7].Value = "E";
								}
								if (Operators.ConditionalCompareObjectNotEqual(dg.Rows[j].Cells[4].Value, text6, TextCompare: true))
								{
									dg.Rows[j].Cells[4].Value = text6;
									Color yellow = Color.Yellow;
									dg.Rows[j].Cells[4].Style.BackColor = yellow;
									dg.Rows[j].Cells[7].Value = "E";
								}
								if (Operators.ConditionalCompareObjectNotEqual(dg.Rows[j].Cells[5].Value, text7, TextCompare: true))
								{
									dg.Rows[j].Cells[5].Value = text7;
									Color yellow = Color.Yellow;
									dg.Rows[j].Cells[5].Style.BackColor = yellow;
									dg.Rows[j].Cells[7].Value = "E";
								}
								break;
							}
						}
						if (flag)
						{
							dg.Rows.Add(text2, text3, text4, text5, text6, text7, 0, "A", 0);
							Color yellow = Color.LightGreen;
							int num3 = 0;
							do
							{
								dg.Rows[dg.Rows.Count - 1].Cells[num3].Style.BackColor = yellow;
								num3++;
							}
							while (num3 <= 5);
						}
					}
				}
				cDadosAccessMateriais2.fechaConexao();
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

	public static void ExportaMateriais(ref Worksheet oSheet, ref DataGridView dg)
	{
		checked
		{
			try
			{
				string text = "";
				Microsoft.Office.Interop.Excel.Application oExcelNew = null;
				ExcFuncoesExcel.VerificaExcel(ref oExcelNew, ref oSheet, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 584]));
				ExcFuncoesExcel.DesativaCalculoExcel(ref oExcelNew);
				ExcFuncoesExcel.LimpaSheet(ref oSheet);
				DeclaracoesGeral._uscPagina.pbPasso();
				text = "A1:F" + Conversions.ToString(dg.RowCount + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 2;
				text = "E2:F" + Conversions.ToString(dg.RowCount + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).WrapText = true;
				int num = 1;
				text = "A" + Conversions.ToString(1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1245]));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				text = "B" + Conversions.ToString(1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1163]));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
				text = "C" + Conversions.ToString(1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 654]));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 25;
				text = "D" + Conversions.ToString(1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1169]));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
				text = "E" + Conversions.ToString(1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 246]));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 35;
				text = "F" + Conversions.ToString(1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 247]));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 60;
				num = 2;
				DeclaracoesGeral._uscPagina.Quantidade = dg.RowCount + 1;
				DeclaracoesGeral._uscPagina.pbIniciar();
				int num2 = 0;
				int num3 = dg.RowCount - 1;
				for (int i = 0; i <= num3; i++)
				{
					DeclaracoesGeral._uscPagina.pbPasso();
					text = "A" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(dg.Rows[i].Cells[0].Value));
					text = "B" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(dg.Rows[i].Cells[1].Value));
					text = "C" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(dg.Rows[i].Cells[2].Value));
					text = "D" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(dg.Rows[i].Cells[3].Value));
					text = "E" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(dg.Rows[i].Cells[4].Value));
					text = "F" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(dg.Rows[i].Cells[5].Value));
					num++;
					num2++;
					if (num2 == 20)
					{
						text = "A" + Conversions.ToString(num + 25);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
						num2 = 0;
					}
				}
				DeclaracoesGeral._uscPagina.pbPasso();
				text = "A1:F1";
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
				ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
				DeclaracoesGeral._uscPagina.pbPasso();
				text = "A2:F" + Conversions.ToString(num - 1);
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
				ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
				DeclaracoesGeral._uscPagina.pbFim();
				ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}
}

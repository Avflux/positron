using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class excPaineis
{
	public struct mPNs
	{
		public int iPN;

		public string sPN;

		public int iIndice;
	}

	public static void ExportaModeloPaineisParaImportarOExcel(ref Worksheet oSheet, string sPainel)
	{
		string text = "";
		text = "A1:Z10000";
		((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).EntireRow.Delete(RuntimeHelpers.GetObjectValue(Missing.Value));
		((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 15;
		int num = 1;
		string cell;
		do
		{
			cell = ExcFuncoesExcel.mudaNumeroAsc(num) + "1";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
			num = checked(num + 1);
		}
		while (num <= 15);
		cell = ExcFuncoesExcel.mudaNumeroAsc(1L) + "1";
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 0;
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 915].ToString().ToUpper());
		ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(1L), "1", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1194]), 43, 2, 150);
		cell = ExcFuncoesExcel.mudaNumeroAsc(2L) + "1";
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 30;
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 626].ToString().ToUpper());
		ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(2L), "1", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1129]), 43, 2, 150);
		text = "B2:B10000";
	}

	public static void ExportaPaineisParaOExcel(ref Worksheet oSheet, ref DataGridView dg, string sPainel, int iMaiorPainel)
	{
		string text = "";
		int num = 1;
		text = "A1:Z10000";
		((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).EntireRow.Delete(RuntimeHelpers.GetObjectValue(Missing.Value));
		((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 15;
		checked
		{
			iMaiorPainel++;
			int num2 = 1;
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
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 915].ToString().ToUpper());
			ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(1L), "1", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1194]), 43, 2, 150);
			cell = ExcFuncoesExcel.mudaNumeroAsc(2L) + "1";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 30;
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 626].ToString().ToUpper());
			num++;
			if (dg.RowCount <= 0)
			{
				return;
			}
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
				if (dg.Rows[i].Cells[0].Style.BackColor == Color.LightCoral)
				{
					ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(2L), Conversions.ToString(num), "", 22);
				}
				num++;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
			}
			text = "A" + Conversions.ToString(num);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'");
			ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(1L), Conversions.ToString(num), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1194]), 0, 4, 100);
			text = "B" + Conversions.ToString(num);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'");
			ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(2L), Conversions.ToString(num), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1129]), 0, 1, 150);
			text = "A1:B" + Conversions.ToString(num - 1);
			ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
			text = "B2:B10000";
			DeclaracoesGeral._uscPagina.pbFim();
		}
	}

	public static bool VerificaImportaPaineis(ref Worksheet oSheet, ref DataGridView dg, ref DataGridView dgH, List<string> lPNExc)
	{
		bool flag = true;
		checked
		{
			try
			{
				string cell = "A1";
				string cell2 = "B1";
				if (!((Operators.CompareString(clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))).ToString().ToUpper(), DeclaracoesGeral.mMensagem[1, 915].ToString().ToUpper(), TextCompare: true) != 0) | (Operators.CompareString(clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))).ToString().ToUpper(), DeclaracoesGeral.mMensagem[1, 626].ToString().ToUpper(), TextCompare: true) != 0)))
				{
					cell = "A2";
					cell2 = "B2";
					int num = 2;
					int num2 = ExcFuncoesExcel.BuscaIndiceMaximoUsado(ref oSheet, "B") - 1;
					DeclaracoesGeral._uscPagina.Quantidade = dg.RowCount - 1 + num2 * 3;
					DeclaracoesGeral._uscPagina.pbIniciar();
					num = 2;
					int num3 = 0;
					mPNs[] array = new mPNs[1];
					int num4 = num2;
					for (int i = 1; i <= num4; i++)
					{
						num = i + 1;
						cell = "A" + Conversions.ToString(num);
						cell2 = "B" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 0;
						ExcFuncoesExcel.LimpaErro(ref oSheet, Conversions.ToString(num));
						DeclaracoesGeral._uscPagina.pbPasso();
						if (!Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), "", TextCompare: true))
						{
							ExcFuncoesExcel.PintaCelula(ref oSheet, "B", Conversions.ToString(num), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1044]), 3, 2, 100);
							flag = false;
							continue;
						}
						array = (mPNs[])Utils.CopyArray(array, new mPNs[num3 + 1]);
						if (!Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))))
						{
							array[num3].iPN = 0;
						}
						else
						{
							array[num3].iPN = Conversions.ToInteger(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
						}
						array[num3].sPN = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
						array[num3].iIndice = num;
						num3++;
					}
					if (dg.RowCount == 0)
					{
						AdicionaNovoPainelNoDG(ref dg, ref dgH, array[1].sPN);
					}
					int num5 = 0;
					mPNs[] array2 = new mPNs[1];
					int num6 = dg.RowCount - 1;
					for (int j = 0; j <= num6; j++)
					{
						DeclaracoesGeral._uscPagina.pbPasso();
						array2 = (mPNs[])Utils.CopyArray(array2, new mPNs[num5 + 1]);
						array2[num5].iPN = Conversions.ToInteger(dg.Rows[j].Cells[0].Value.ToString());
						array2[num5].sPN = clsTextos.TiraNothing(dg.Rows[j].Cells[1].Value.ToString());
						array2[num5].iIndice = num5;
						num5++;
					}
					int num7 = Information.UBound(array);
					for (int k = 0; k <= num7; k++)
					{
						DeclaracoesGeral._uscPagina.pbPasso();
						cell2 = "B" + Conversions.ToString(k);
						int num8 = k + 1;
						int num9 = Information.UBound(array);
						for (int l = num8; l <= num9; l++)
						{
							_ = "B" + Conversions.ToString(l);
							if (Operators.CompareString(array[k].sPN.ToUpper(), array[l].sPN.ToUpper(), TextCompare: true) == 0)
							{
								ExcFuncoesExcel.PintaCelula(ref oSheet, "B", Conversions.ToString(array[l].iIndice), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1601]), 46, 1, 100);
								ExcFuncoesExcel.PintaCelula(ref oSheet, "B", Conversions.ToString(array[k].iIndice), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1601]), 46, 1, 100);
								flag = false;
							}
						}
					}
					List<string> list = new List<string>();
					if (array2.Count() > 0)
					{
						int num10 = Information.UBound(array2);
						for (int m = 0; m <= num10; m++)
						{
							list.Add(array2[m].sPN.ToUpper());
						}
					}
					int num11 = Information.UBound(array);
					for (int n = 0; n <= num11; n++)
					{
						_ = "B" + Conversions.ToString(n);
						if (array[n].iPN == 0 && list.Contains(array[n].sPN.ToUpper()))
						{
							ExcFuncoesExcel.PintaCelula(ref oSheet, "B", Conversions.ToString(array[n].iIndice), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 956]), 46, 2, 100);
							flag = false;
						}
					}
					DateTime dateTime = Conversions.ToDate(DateTime.Now.ToString());
					string userName = Environment.UserName;
					if (!flag)
					{
						Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1605]), MsgBoxStyle.Critical, "Eletron");
					}
					else
					{
						int num12 = Information.UBound(array);
						for (int num13 = 0; num13 <= num12; num13++)
						{
							bool flag2 = true;
							DeclaracoesGeral._uscPagina.pbPasso();
							int num14 = Information.UBound(array2);
							for (int num15 = 0; num15 <= num14; num15++)
							{
								if (array2[num15].iPN != array[num13].iPN)
								{
									if (((array[num13].iPN == 0) & (array2[num15].iPN != array[num13].iPN)) && Operators.CompareString(array2[num15].sPN.ToUpper(), array[num13].sPN.ToUpper(), TextCompare: true) == 0)
									{
										flag2 = false;
										break;
									}
									continue;
								}
								if (Operators.CompareString(array2[num15].sPN.ToUpper(), array[num13].sPN.ToUpper(), TextCompare: true) != 0)
								{
									dg.Rows[num15].Cells[1].Value = array[num13].sPN;
									dg.Rows[num15].Cells[3].Value = userName;
									dg.Rows[num15].Cells[4].Value = dateTime;
									dg.Rows[num15].Cells[8].Value = true;
								}
								flag2 = false;
								break;
							}
							if (!flag2)
							{
								continue;
							}
							if (!lPNExc.Contains(array[num13].sPN.ToUpper()))
							{
								AdicionaNovoPainelNoDG(ref dg, ref dgH, array[num13].sPN);
								continue;
							}
							int num16 = dgH.Rows.Count - 1;
							for (int num17 = 0; num17 <= num16; num17++)
							{
								if (Operators.CompareString(dgH.Rows[num17].Cells[1].Value.ToString().ToUpper(), array[num13].sPN.ToUpper(), TextCompare: true) == 0)
								{
									dg.Rows.Add(dgH.Rows[num17].Cells[0].Value, dgH.Rows[num17].Cells[1].Value, dgH.Rows[num17].Cells[2].Value, userName, dateTime, dgH.Rows[num17].Cells[5].Value, true, true, false);
									dgH.Rows.RemoveAt(num17);
									break;
								}
							}
						}
					}
					DeclaracoesGeral._uscPagina.pbFim();
					cell2 = "B2:B10000";
				}
				else
				{
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1607]), MsgBoxStyle.Critical, "Eletron");
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			return flag;
		}
	}

	public static void AdicionaPainelisExcluidoDoDG(ref DataGridView dg, ref DataGridView dgH, string sPainel)
	{
		DateTime dateTime = Conversions.ToDate(DateTime.Now.ToString());
		string userName = Environment.UserName;
		checked
		{
			try
			{
				MsgBoxResult msgBoxResult = Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 958], sPainel), DeclaracoesGeral.mMensagem[1, 1171]), "\r\n"), "\r\n"), DeclaracoesGeral.mMensagem[1, 1172]), MsgBoxStyle.YesNo);
				if (msgBoxResult != MsgBoxResult.Yes)
				{
					msgBoxResult = Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 958], sPainel), DeclaracoesGeral.mMensagem[1, 1171]), "\r\n"), "\r\n"), DeclaracoesGeral.mMensagem[1, 1173]), MsgBoxStyle.YesNo);
					if (msgBoxResult != MsgBoxResult.Yes)
					{
						return;
					}
					int num = dgH.Rows.Count - 1;
					int num2 = 0;
					while (true)
					{
						if (num2 <= num)
						{
							if (dgH.Rows[num2].Selected)
							{
								break;
							}
							num2++;
							continue;
						}
						return;
					}
					AdicionaNovoPainelNoDG(ref dg, ref dgH, sPainel + "_", Conversions.ToInteger(dgH.Rows[num2].Cells[0].Value));
					dgH.Rows.RemoveAt(num2);
					return;
				}
				int num3 = dgH.Rows.Count - 1;
				int num4 = 0;
				while (true)
				{
					if (num4 <= num3)
					{
						if (dgH.Rows[num4].Selected)
						{
							break;
						}
						num4++;
						continue;
					}
					return;
				}
				dg.Rows.Add(dgH.Rows[num4].Cells[0].Value, dgH.Rows[num4].Cells[1].Value, dgH.Rows[num4].Cells[2].Value, userName, dateTime, dgH.Rows[num4].Cells[5].Value, true, true, false);
				dgH.Rows.RemoveAt(num4);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
			}
		}
	}

	public static void AdicionaNovoPainelNoDG(ref DataGridView Dg, ref DataGridView DgH, string sPainel, int IPNDel = 0)
	{
		DateTime dateTime = Conversions.ToDate(DateTime.Now.ToString());
		string userName = Environment.UserName;
		checked
		{
			try
			{
				short num = 0;
				int num2 = Dg.Rows.Count - 1;
				for (int i = 0; i <= num2; i++)
				{
					if (Operators.ConditionalCompareObjectLess(num, Dg[0, i].Value, TextCompare: true))
					{
						num = Conversions.ToShort(Dg[0, i].Value);
					}
				}
				int num3 = DgH.Rows.Count - 1;
				for (int j = 0; j <= num3; j++)
				{
					if (Operators.ConditionalCompareObjectLess(num, DgH[0, j].Value, TextCompare: true))
					{
						num = Conversions.ToShort(DgH[0, j].Value);
					}
				}
				num++;
				dateTime = Conversions.ToDate(DateTime.Now.ToString());
				Dg.Rows.Add(num, sPainel.ToString(), userName.ToString(), userName.ToString(), dateTime.ToString(), false, true, false, false, IPNDel);
				Dg.Rows[Dg.Rows.Count - 1].Selected = true;
				Dg.FirstDisplayedScrollingRowIndex = Dg.Rows.Count - 1;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
			}
		}
	}
}

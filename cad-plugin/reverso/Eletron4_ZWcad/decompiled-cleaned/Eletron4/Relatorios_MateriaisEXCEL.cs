using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class Relatorios_MateriaisEXCEL
{
	public static void CriaMatrizDeMateriaisEXCEL(cDadosLM.structureLMRelelatorio[] mRelatMateriais, cDadosLM.indexCODMateriais[] mRelCod, string sRelatorio, bool bConcatModelo, bool bConcatFabricante, bool bVisivelCli)
	{
		checked
		{
			try
			{
				Microsoft.Office.Interop.Excel.Application oExcelNew = null;
				Worksheet oSheet = null;
				ExcFuncoesExcel.VerificaExcel(ref oExcelNew, ref oSheet, sRelatorio);
				ExcFuncoesExcel.DesativaCalculoExcel(ref oExcelNew);
				((_Worksheet)oSheet).get_Range((object)"A1", (object)"Z10000").EntireRow.Delete(RuntimeHelpers.GetObjectValue(Missing.Value));
				oSheet.Cells.ClearComments();
				ExcFuncoesExcel.ApagaFigura(sRelatorio);
				long num = 1L;
				string text = "";
				text = "A1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 7;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mRelatMateriais[0].Index));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				text = "B1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 7;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mRelatMateriais[0].Quantidade));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				text = "C1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 40;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mRelatMateriais[0].Tag));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				int num2 = 5;
				int num3 = 0;
				int num4 = 0;
				int num5 = 0;
				if (!bConcatModelo)
				{
					num3 = num2;
					num2++;
				}
				if (!bConcatFabricante)
				{
					num4 = num2;
					num2++;
				}
				if (bVisivelCli)
				{
					num5 = num2;
					num2++;
				}
				double num6 = 50.0;
				if (bConcatModelo)
				{
					num6 += 10.0;
				}
				if (bConcatFabricante)
				{
					num6 += 10.0;
				}
				if (!bVisivelCli)
				{
					num6 += 10.0;
				}
				text = "D1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = num6;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mRelatMateriais[0].Desc));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				text = "A" + Conversions.ToString(num) + ":D" + Conversions.ToString(num);
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
				if (!bConcatModelo)
				{
					text = ExcFuncoesExcel.mudaNumeroAsc(num3) + "1";
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 20;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mRelatMateriais[0].sModelo));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
					text = "A" + Conversions.ToString(num) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num3) + Conversions.ToString(num);
					ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
				}
				if (!bConcatFabricante)
				{
					text = ExcFuncoesExcel.mudaNumeroAsc(num4) + "1";
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 20;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mRelatMateriais[0].sFabricante));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
					text = "A" + Conversions.ToString(num) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num4) + Conversions.ToString(num);
					ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
				}
				if (bVisivelCli)
				{
					text = ExcFuncoesExcel.mudaNumeroAsc(num5) + "1";
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 20;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mRelatMateriais[0].CodCli));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
					text = "A" + Conversions.ToString(num) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num5) + Conversions.ToString(num);
					ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
				}
				num += 2L;
				string text2 = "";
				int num7 = Information.UBound(mRelatMateriais);
				for (int i = 1; i <= num7; i++)
				{
					text2 = "A" + Conversions.ToString(num + 2L);
					((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
					text = "A" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + Conversions.ToString(i)));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "B" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mRelatMateriais[i].Quantidade));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "C" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).WrapText = true;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mRelatMateriais[i].Tag));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 2;
					text = "D" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).WrapText = true;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mRelatMateriais[i].Desc));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 2;
					text = "A" + Conversions.ToString(num) + ":D" + Conversions.ToString(num);
					ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
					if (!bConcatModelo)
					{
						text = ExcFuncoesExcel.mudaNumeroAsc(num3) + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mRelatMateriais[i].sModelo));
						text = "A" + Conversions.ToString(num) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num3) + Conversions.ToString(num);
						ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
					}
					if (!bConcatFabricante)
					{
						text = ExcFuncoesExcel.mudaNumeroAsc(num4) + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mRelatMateriais[i].sFabricante));
						text = "A" + Conversions.ToString(num) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num4) + Conversions.ToString(num);
						ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
					}
					if (bVisivelCli)
					{
						text = ExcFuncoesExcel.mudaNumeroAsc(num5) + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mRelatMateriais[i].CodCli));
						text = "A" + Conversions.ToString(num) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num5) + Conversions.ToString(num);
						ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
					}
					num++;
				}
				text2 = "A1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
				ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void CriaMatrizDeMateriaisMEXCEL(DataGridView dg, string sRelatorio, bool bConcatModelo, bool bConcatFabricante, bool bVisivelCli)
	{
		checked
		{
			try
			{
				Microsoft.Office.Interop.Excel.Application oExcelNew = null;
				Worksheet oSheet = null;
				ExcFuncoesExcel.VerificaExcel(ref oExcelNew, ref oSheet, sRelatorio);
				ExcFuncoesExcel.DesativaCalculoExcel(ref oExcelNew);
				((_Worksheet)oSheet).get_Range((object)"A1", (object)"Z10000").EntireRow.Delete(RuntimeHelpers.GetObjectValue(Missing.Value));
				oSheet.Cells.ClearComments();
				ExcFuncoesExcel.ApagaFigura(sRelatorio);
				long num = 1L;
				string text = "";
				int count = dg.Columns.Count;
				for (int i = 1; i <= count; i++)
				{
					NewLateBinding.LateSetComplex(oSheet.Cells[1, i], null, "ColumnWidth", new object[1] { 10 }, null, null, OptimisticSet: false, RValueBase: true);
				}
				text = "A1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 7;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				text = "B1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 40;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				int num2 = 4;
				int num3 = 0;
				int num4 = 0;
				int num5 = 0;
				if (!bConcatModelo)
				{
					num3 = num2;
					num2++;
				}
				if (!bConcatFabricante)
				{
					num4 = num2;
					num2++;
				}
				if (bVisivelCli)
				{
					num5 = num2;
					num2++;
				}
				double num6 = 50.0;
				if (bConcatModelo)
				{
					num6 += 10.0;
				}
				if (bConcatFabricante)
				{
					num6 += 10.0;
				}
				if (!bVisivelCli)
				{
					num6 += 10.0;
				}
				text = "C1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = num6;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				text = "A" + Conversions.ToString(num) + ":D" + Conversions.ToString(num);
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
				if (!bConcatModelo)
				{
					text = ExcFuncoesExcel.mudaNumeroAsc(num3) + "1";
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 20;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
					text = "A" + Conversions.ToString(num) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num3) + Conversions.ToString(num);
					ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
				}
				if (!bConcatFabricante)
				{
					text = ExcFuncoesExcel.mudaNumeroAsc(num4) + "1";
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 20;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
					text = "A" + Conversions.ToString(num) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num4) + Conversions.ToString(num);
					ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
				}
				if (bVisivelCli)
				{
					text = ExcFuncoesExcel.mudaNumeroAsc(num5) + "1";
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 20;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
					text = "A" + Conversions.ToString(num) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num5) + Conversions.ToString(num);
					ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
				}
				int num7 = dg.RowCount - 1;
				for (int j = 0; j <= num7; j++)
				{
					if (j == 0)
					{
						int count2 = dg.Columns.Count;
						for (int k = 1; k <= count2; k++)
						{
							oSheet.Cells[1, k] = dg.Columns[k - 1].HeaderText;
						}
					}
					int num8 = dg.ColumnCount - 1;
					for (int l = 0; l <= num8; l++)
					{
						oSheet.Cells[j + 2, l + 1] = "'" + dg[l, j].Value.ToString();
						if (!((l == 1) | (l == 2)))
						{
							NewLateBinding.LateSetComplex(oSheet.Cells[j + 2, l + 1], null, "VerticalAlignment", new object[1] { 2 }, null, null, OptimisticSet: false, RValueBase: true);
							NewLateBinding.LateSetComplex(oSheet.Cells[j + 2, l + 1], null, "HorizontalAlignment", new object[1] { 3 }, null, null, OptimisticSet: false, RValueBase: true);
						}
						else
						{
							NewLateBinding.LateSetComplex(oSheet.Cells[j + 2, l + 1], null, "VerticalAlignment", new object[1] { 2 }, null, null, OptimisticSet: false, RValueBase: true);
							NewLateBinding.LateSetComplex(oSheet.Cells[j + 2, l + 1], null, "HorizontalAlignment", new object[1] { 2 }, null, null, OptimisticSet: false, RValueBase: true);
						}
					}
					text = "A" + Conversions.ToString(j + 5);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
					num = j + 2;
				}
				text = "A1:" + ExcFuncoesExcel.mudaNumeroAsc(dg.ColumnCount) + "1";
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				text = "A2:" + ExcFuncoesExcel.mudaNumeroAsc(dg.ColumnCount) + Conversions.ToString(num);
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
				text = "A1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
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

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class Relatorios_GIGA
{
	public static void CriaListaVeiasEXCELGIGA(string sNomeSheet, clsVeias.InterGIGA[] mCabos, int iQuantLinhas, ref string sNumCabo, ref string sPN1, ref string sPN2)
	{
		checked
		{
			try
			{
				Application oExcelNew = null;
				Worksheet oSheet = null;
				ExcFuncoesExcel.VerificaExcel(ref oExcelNew, ref oSheet, sNomeSheet);
				ExcFuncoesExcel.LimpaSheet(ref oSheet);
				ExcFuncoesExcel.DesativaCalculoExcel(ref oExcelNew);
				List<string> list = new List<string>();
				list.Sort();
				clsVeias.InterGIGA[] Cabos = null;
				DeclaracoesGeral._uscPagina.Quantidade = list.Count;
				DeclaracoesGeral._uscPagina.pbIniciar();
				int num = 1;
				string text = "";
				int num2 = Information.UBound(mCabos);
				for (int i = 1; i <= num2; i++)
				{
					if (mCabos[i].iIndice == 0)
					{
						text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1288], " "), sNumCabo));
						carregaUmCaboGIGA(ref i, ref iQuantLinhas, ref Cabos, mCabos);
						NcQ3KHX9fc(ref oSheet, Cabos, ref num, text, sPN1, sPN2);
						num += 4;
						sNumCabo = Conversions.ToString(Conversions.ToInteger(sNumCabo) + 1);
					}
				}
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
	}

	public static void carregaUmCaboGIGA(ref int iLinhas, ref int iQuantLinhas, ref clsVeias.InterGIGA[] Cabos, clsVeias.InterGIGA[] mCabos)
	{
		checked
		{
			try
			{
				int num = 0;
				Cabos = new clsVeias.InterGIGA[1];
				int num2 = iLinhas;
				int num3 = Information.UBound(mCabos);
				for (int i = num2; i <= num3 && !((i > iLinhas) & (mCabos[i].iIndice == 0)); i++)
				{
					num++;
					Cabos = (clsVeias.InterGIGA[])Utils.CopyArray(Cabos, new clsVeias.InterGIGA[num + 1]);
					Cabos[num] = mCabos[i];
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	private static void NcQ3KHX9fc(ref Worksheet P_0, clsVeias.InterGIGA[] P_1, ref int P_2, string P_3, string P_4, string P_5)
	{
		checked
		{
			try
			{
				string text = "";
				int num = 4;
				string text2 = ExcFuncoesExcel.mudaNumeroAsc(P_2);
				string text3 = ExcFuncoesExcel.mudaNumeroAsc(P_2 + 1);
				string text4 = ExcFuncoesExcel.mudaNumeroAsc(P_2 + 2);
				string text5 = ExcFuncoesExcel.mudaNumeroAsc(P_2 + 3);
				string cell = text2 + "1";
				((_Worksheet)P_0).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
				((_Worksheet)P_0).get_Range((object)(text2 + "1"), RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
				((_Worksheet)P_0).get_Range((object)(text3 + "1"), RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
				((_Worksheet)P_0).get_Range((object)(text4 + "1"), RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
				((_Worksheet)P_0).get_Range((object)(text5 + "1"), RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
				((_Worksheet)P_0).get_Range((object)"A1", RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 32.25;
				((_Worksheet)P_0).get_Range((object)"A2", RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 32.25;
				((_Worksheet)P_0).get_Range((object)"A3", RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 51;
				((_Worksheet)P_0).get_Range((object)("A4:A" + Conversions.ToString(Information.UBound(P_1) + 3)), RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 22;
				text = text2 + "1:" + text5 + Conversions.ToString(Information.UBound(P_1) + 3);
				ExcFuncoesExcel.CriaLinhasInterna(ref P_0, text);
				ExcFuncoesExcel.CriaLinhasExterna(ref P_0, text, bCompleto: true);
				text = text2 + "1:" + text4 + "1";
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 508].ToString().ToUpper()));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 16;
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Name = "ARIAL";
				text = text2 + "2:" + text4 + "2";
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 1288].ToString().ToUpper() + ": " + P_3.ToString().ToUpper()));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 14;
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 1;
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Name = "ARIAL";
				text = text2 + "3";
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("'", NewLateBinding.LateGet(DeclaracoesGeral.mMensagem[1, 176], null, "ToUpper", new object[0], null, null, null)), ": "), P_4));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 14;
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 1;
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Name = "ARIAL";
				text = text3 + "3";
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 1569].ToString().ToUpper() + ".:"));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 14;
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Name = "ARIAL";
				text = text4 + "3";
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("'", NewLateBinding.LateGet(DeclaracoesGeral.mMensagem[1, 176], null, "ToUpper", new object[0], null, null, null)), ": "), P_5));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 14;
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 1;
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Name = "ARIAL";
				text = text5 + "2:" + text5 + "3";
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'N° " + DeclaracoesGeral.mMensagem[1, 287].ToString().ToUpper()));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 14;
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Orientation = -90;
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Name = "ARIAL";
				cell = text5 + "1";
				((_Worksheet)P_0).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
				int num2 = Information.UBound(P_1);
				for (int i = 1; i <= num2; i++)
				{
					text = text2 + Conversions.ToString(num);
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + P_1[i].sTag1));
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Name = "ARIAL";
					text = text3 + Conversions.ToString(num);
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + P_1[i].sCor));
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Name = "ARIAL";
					text = text4 + Conversions.ToString(num);
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + P_1[i].sTag2));
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Name = "ARIAL";
					text = text5 + Conversions.ToString(num);
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + P_1[i].sPG));
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Name = "ARIAL";
					num++;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}
}

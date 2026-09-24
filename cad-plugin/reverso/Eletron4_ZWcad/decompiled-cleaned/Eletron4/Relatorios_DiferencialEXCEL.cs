using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class Relatorios_DiferencialEXCEL
{
	public static void CriaMatrizDeDiferenciaisEXCEL(DeclaracoesFiacao.structureRelPotencial[] mDiferencialADD, DeclaracoesFiacao.structureRelPotencial[] mDiferencialDEL, string sPainel, bool bAlternativo)
	{
		checked
		{
			try
			{
				Application oExcelNew = null;
				Worksheet oSheet = null;
				string oNomeSheet = "DIF_" + sPainel;
				ExcFuncoesExcel.VerificaExcel(ref oExcelNew, ref oSheet, oNomeSheet);
				ExcFuncoesExcel.DesativaCalculoExcel(ref oExcelNew);
				if (Operators.CompareString(DeclaracoesGeral.companyHardlock.ToUpper(), "CADGRAPH", TextCompare: true) != 0)
				{
					ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
				}
				((_Worksheet)oSheet).get_Range((object)"A1", (object)"Z10000").EntireRow.Delete(RuntimeHelpers.GetObjectValue(Missing.Value));
				oSheet.Cells.ClearComments();
				long num = 1L;
				int num2 = 1;
				int num3 = 1;
				string text = "";
				int num4 = 1;
				int num5 = 1;
				text = ExcFuncoesExcel.mudaNumeroAsc(1L) + "1";
				num4 = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				if (bAlternativo)
				{
					text = ExcFuncoesExcel.mudaNumeroAsc(num4) + "1";
					num4++;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				}
				text = ExcFuncoesExcel.mudaNumeroAsc(num4) + "1";
				num4++;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = ExcFuncoesExcel.mudaNumeroAsc(num4) + "1";
				num4++;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				if (bAlternativo)
				{
					text = ExcFuncoesExcel.mudaNumeroAsc(num4) + "1";
					num4++;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				}
				text = ExcFuncoesExcel.mudaNumeroAsc(num4) + "1";
				num4++;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = ExcFuncoesExcel.mudaNumeroAsc(num4) + "1";
				num4++;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = ExcFuncoesExcel.mudaNumeroAsc(num4) + "1";
				num4++;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = ExcFuncoesExcel.mudaNumeroAsc(num4) + "1";
				num4++;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				num5 = num4 - 1;
				num4 = 0;
				num4 = 1;
				text = ExcFuncoesExcel.mudaNumeroAsc(1L) + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mDiferencialADD[0].tag1));
				if (bAlternativo)
				{
					num4++;
					text = ExcFuncoesExcel.mudaNumeroAsc(num4) + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mDiferencialADD[0].alt1 + "1"));
				}
				num4++;
				text = ExcFuncoesExcel.mudaNumeroAsc(num4) + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mDiferencialADD[0].term1));
				num4++;
				text = ExcFuncoesExcel.mudaNumeroAsc(num4) + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mDiferencialADD[0].tag2));
				if (bAlternativo)
				{
					num4++;
					text = ExcFuncoesExcel.mudaNumeroAsc(num4) + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mDiferencialADD[0].alt2 + "2"));
				}
				num4++;
				text = ExcFuncoesExcel.mudaNumeroAsc(num4) + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mDiferencialADD[0].term2));
				num4++;
				text = ExcFuncoesExcel.mudaNumeroAsc(num4) + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mDiferencialADD[0].secao));
				num4++;
				text = ExcFuncoesExcel.mudaNumeroAsc(num4) + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mDiferencialADD[0].cor));
				num4++;
				text = ExcFuncoesExcel.mudaNumeroAsc(num4) + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mDiferencialADD[0].pagina));
				num3 = (int)num;
				text = "A" + Conversions.ToString(num) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num5) + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
				ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
				num += 2L;
				num2 = 1;
				num3 = 1;
				text = "A" + Conversions.ToString(num) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num5) + Conversions.ToString(num + 1L);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 822]));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 14;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 9;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
				ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
				num += 3L;
				num2 = (int)num;
				DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mDiferencialADD) + Information.UBound(mDiferencialDEL);
				DeclaracoesGeral._uscPagina.pbIniciar();
				string text2 = "";
				int num6 = Information.UBound(mDiferencialADD);
				for (int i = 1; i <= num6; i++)
				{
					text2 = "A" + Conversions.ToString(num + 2L);
					((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
					num4 = 0;
					num4 = 1;
					text = ExcFuncoesExcel.mudaNumeroAsc(1L) + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mDiferencialADD[i].tag1));
					if (bAlternativo)
					{
						num4++;
						text = ExcFuncoesExcel.mudaNumeroAsc(num4) + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mDiferencialADD[i].alt1));
					}
					num4++;
					text = ExcFuncoesExcel.mudaNumeroAsc(num4) + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mDiferencialADD[i].term1));
					num4++;
					text = ExcFuncoesExcel.mudaNumeroAsc(num4) + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mDiferencialADD[i].tag2));
					if (bAlternativo)
					{
						num4++;
						text = ExcFuncoesExcel.mudaNumeroAsc(num4) + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mDiferencialADD[i].alt2));
					}
					num4++;
					text = ExcFuncoesExcel.mudaNumeroAsc(num4) + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mDiferencialADD[i].term2));
					num4++;
					text = ExcFuncoesExcel.mudaNumeroAsc(num4) + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mDiferencialADD[i].secao));
					num4++;
					text = ExcFuncoesExcel.mudaNumeroAsc(num4) + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mDiferencialADD[i].cor));
					num4++;
					text = ExcFuncoesExcel.mudaNumeroAsc(num4) + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mDiferencialADD[i].pagina));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "A" + Conversions.ToString(num) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num5) + Conversions.ToString(num);
					ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
					num3 = (int)num;
					num++;
					DeclaracoesGeral._uscPagina.pbPasso();
				}
				text = "A" + Conversions.ToString(num2) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num5) + Conversions.ToString(num3);
				if (Information.UBound(mDiferencialADD) > 0)
				{
					ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
				}
				num++;
				num2 = 1;
				num3 = 1;
				text = "A" + Conversions.ToString(num) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num5) + Conversions.ToString(num + 1L);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 823]));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 14;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 9;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
				ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
				num += 3L;
				num2 = (int)num;
				int num7 = Information.UBound(mDiferencialDEL);
				for (int j = 1; j <= num7; j++)
				{
					text2 = "A" + Conversions.ToString(num + 2L);
					((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
					num4 = 0;
					num4 = 1;
					text = ExcFuncoesExcel.mudaNumeroAsc(1L) + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mDiferencialDEL[j].tag1));
					if (bAlternativo)
					{
						num4++;
						text = ExcFuncoesExcel.mudaNumeroAsc(num4) + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mDiferencialDEL[j].alt1));
					}
					num4++;
					text = ExcFuncoesExcel.mudaNumeroAsc(num4) + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mDiferencialDEL[j].term1));
					num4++;
					text = ExcFuncoesExcel.mudaNumeroAsc(num4) + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mDiferencialDEL[j].tag2));
					if (bAlternativo)
					{
						num4++;
						text = ExcFuncoesExcel.mudaNumeroAsc(num4) + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mDiferencialDEL[j].alt2));
					}
					num4++;
					text = ExcFuncoesExcel.mudaNumeroAsc(num4) + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mDiferencialDEL[j].term2));
					num4++;
					text = ExcFuncoesExcel.mudaNumeroAsc(num4) + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mDiferencialDEL[j].secao));
					num4++;
					text = ExcFuncoesExcel.mudaNumeroAsc(num4) + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mDiferencialDEL[j].cor));
					num4++;
					text = ExcFuncoesExcel.mudaNumeroAsc(num4) + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mDiferencialDEL[j].pagina));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "A" + Conversions.ToString(num) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num5) + Conversions.ToString(num);
					ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
					num3 = (int)num;
					num++;
					DeclaracoesGeral._uscPagina.pbPasso();
				}
				text = "A" + Conversions.ToString(num2) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num5) + Conversions.ToString(num3);
				if (Information.UBound(mDiferencialDEL) > 0)
				{
					ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
				}
				ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
				text2 = "A1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
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

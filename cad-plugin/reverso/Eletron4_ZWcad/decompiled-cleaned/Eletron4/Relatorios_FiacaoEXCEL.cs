using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class Relatorios_FiacaoEXCEL
{
	public struct ConfRelatorio
	{
		public short CorLinha;

		public short CorJumper;

		public short CorTexto;

		public double TamanhoFonte;

		public short QuantColunas;

		public double AlturaInicial;

		public double DistEntreColunas;

		public double AlturaDoBloco;

		public string sFonte;
	}

	public static void CriaMatrizFiacao_Excel(DeclaracoesFiacao.structureRelFiacao[] mFiacao, string sRelatorio, string sPainel)
	{
		checked
		{
			try
			{
				Microsoft.Office.Interop.Excel.Application oExcelNew = null;
				Worksheet oSheet = null;
				string oNomeSheet = sRelatorio + "_" + sPainel;
				ExcFuncoesExcel.VerificaExcel(ref oExcelNew, ref oSheet, oNomeSheet);
				ExcFuncoesExcel.DesativaCalculoExcel(ref oExcelNew);
				((_Worksheet)oSheet).get_Range((object)"A1", (object)"Z10000").EntireRow.Delete(RuntimeHelpers.GetObjectValue(Missing.Value));
				oSheet.Cells.ClearComments();
				long num = 1L;
				int num2 = 1;
				int num3 = 1;
				string text = "";
				mFiacao[0].Terminal = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 776]);
				mFiacao[0].Disp1 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 777]);
				mFiacao[0].Term1 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 778]);
				mFiacao[0].Disp2 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 779]);
				mFiacao[0].Term2 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 780]);
				mFiacao[0].Cor12 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 782]);
				mFiacao[0].Secao12 = "mm²";
				mFiacao[0].Pagina12 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 783]);
				int num4 = Information.UBound(mFiacao);
				for (int i = 0; i <= num4; i++)
				{
					if (Operators.CompareString(mFiacao[i].Tag, null, TextCompare: true) == 0)
					{
						mFiacao[i].Tag = "";
					}
					if (Operators.CompareString(mFiacao[i].Jumper, null, TextCompare: true) == 0)
					{
						mFiacao[i].Jumper = "";
					}
					if (Operators.CompareString(mFiacao[i].Terminal, null, TextCompare: true) == 0)
					{
						mFiacao[i].Terminal = "";
					}
					if (Operators.CompareString(mFiacao[i].Disp1, null, TextCompare: true) == 0)
					{
						mFiacao[i].Disp1 = "";
					}
					if (Operators.CompareString(mFiacao[i].Term1, null, TextCompare: true) == 0)
					{
						mFiacao[i].Term1 = "";
					}
					if (Operators.CompareString(mFiacao[i].Disp2, null, TextCompare: true) == 0)
					{
						mFiacao[i].Disp2 = "";
					}
					if (Operators.CompareString(mFiacao[i].Term2, null, TextCompare: true) == 0)
					{
						mFiacao[i].Term2 = "";
					}
					if (Operators.CompareString(mFiacao[i].Disp3, null, TextCompare: true) == 0)
					{
						mFiacao[i].Disp3 = "";
					}
					if (Operators.CompareString(mFiacao[i].Term3, null, TextCompare: true) == 0)
					{
						mFiacao[i].Term3 = "";
					}
					if (Operators.CompareString(mFiacao[i].Disp4, null, TextCompare: true) == 0)
					{
						mFiacao[i].Disp4 = "";
					}
					if (Operators.CompareString(mFiacao[i].Term4, null, TextCompare: true) == 0)
					{
						mFiacao[i].Term4 = "";
					}
					if (Operators.CompareString(mFiacao[i].Cor12, null, TextCompare: true) == 0)
					{
						mFiacao[i].Cor12 = "";
					}
					if (Operators.CompareString(mFiacao[i].Secao12, null, TextCompare: true) == 0)
					{
						mFiacao[i].Secao12 = "";
					}
					if (Operators.CompareString(mFiacao[i].Pagina12, null, TextCompare: true) == 0)
					{
						mFiacao[i].Pagina12 = "";
					}
					if (Operators.CompareString(mFiacao[i].Cor34, null, TextCompare: true) == 0)
					{
						mFiacao[i].Cor34 = "";
					}
					if (Operators.CompareString(mFiacao[i].Secao34, null, TextCompare: true) == 0)
					{
						mFiacao[i].Secao34 = "";
					}
					if (Operators.CompareString(mFiacao[i].Pagina34, null, TextCompare: true) == 0)
					{
						mFiacao[i].Pagina34 = "";
					}
				}
				text = "A1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "B1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "C1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "D1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "E1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "F1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "G1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 6;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "H1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 6;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "A" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Terminal));
				text = "B" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Disp1));
				text = "C" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Term1));
				text = "D" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Disp2));
				text = "E" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Term2));
				text = "F" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Cor12));
				text = "G" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Secao12));
				text = "H" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Pagina12));
				num3 = (int)num;
				text = "A" + Conversions.ToString(num) + ":H" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
				ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
				num += 2L;
				num2 = 0;
				num3 = 0;
				text = "A" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Tag));
				text = "A" + Conversions.ToString(num) + ":A" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 12;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
				num++;
				num3 = (int)num;
				num2 = (int)num;
				int num5 = Information.UBound(mFiacao);
				for (int j = 1; j <= num5; j++)
				{
					string cell = "A" + Conversions.ToString(num + 2L);
					((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
					int num6 = 0;
					num6 = ((j == 0) ? j : (j - 1));
					if ((Operators.CompareString(mFiacao[num6].Tag, "", TextCompare: true) != 0) & (num6 > 0))
					{
						text = "A" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[num6].Tag));
						text = "A" + Conversions.ToString(num) + ":A" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 12;
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
						num++;
						num3 = (int)num;
						num2 = (int)num;
						if (j == 0)
						{
							continue;
						}
					}
					text = "A" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Terminal));
					text = "B" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Disp1));
					text = "C" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Term1));
					text = "D" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Disp2));
					text = "E" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Term2));
					text = "F" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Cor12));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "G" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Secao12));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "H" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Pagina12));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "A" + Conversions.ToString(num) + ":H" + Conversions.ToString(num);
					ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
					num3 = (int)num;
					num++;
					if (j < Information.UBound(mFiacao))
					{
						num6 = j;
					}
					if (Operators.CompareString(mFiacao[num6].Tag, "", TextCompare: true) != 0)
					{
						text = "A" + Conversions.ToString(num2) + ":H" + Conversions.ToString(num3);
						ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
						num++;
						num2 = (int)num;
						num3 = (int)num;
					}
				}
				text = "A" + Conversions.ToString(num2) + ":H" + Conversions.ToString(num3);
				ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
				ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void CriaMatrizFiacaoBorneExcel(DeclaracoesFiacao.structureRelFiacao[] mFiacao, string sRelatorio, string sPainel)
	{
		checked
		{
			try
			{
				Microsoft.Office.Interop.Excel.Application oExcelNew = null;
				Worksheet oSheet = null;
				string oNomeSheet = sRelatorio + "_" + sPainel;
				ExcFuncoesExcel.VerificaExcel(ref oExcelNew, ref oSheet, oNomeSheet);
				ExcFuncoesExcel.DesativaCalculoExcel(ref oExcelNew);
				((_Worksheet)oSheet).get_Range((object)"A1", (object)"Z10000").EntireRow.Delete(RuntimeHelpers.GetObjectValue(Missing.Value));
				oSheet.Cells.ClearComments();
				long num = 1L;
				int num2 = 1;
				int num3 = 1;
				string text = "";
				mFiacao[0].Terminal = DeclaracoesGeral.mMensagem[1, 776].ToString();
				mFiacao[0].Disp1 = DeclaracoesGeral.mMensagem[1, 777].ToString();
				mFiacao[0].Term1 = DeclaracoesGeral.mMensagem[1, 778].ToString();
				mFiacao[0].Disp2 = DeclaracoesGeral.mMensagem[1, 779].ToString();
				mFiacao[0].Term2 = DeclaracoesGeral.mMensagem[1, 780].ToString();
				mFiacao[0].Cor12 = DeclaracoesGeral.mMensagem[1, 782].ToString();
				mFiacao[0].Secao12 = "mm²";
				mFiacao[0].Pagina12 = DeclaracoesGeral.mMensagem[1, 783].ToString();
				int num4 = Information.UBound(mFiacao);
				for (int i = 0; i <= num4; i++)
				{
					if (Operators.CompareString(mFiacao[i].Tag, null, TextCompare: true) == 0)
					{
						mFiacao[i].Tag = "";
					}
					if (Operators.CompareString(mFiacao[i].Jumper, null, TextCompare: true) == 0)
					{
						mFiacao[i].Jumper = "";
					}
					if (Operators.CompareString(mFiacao[i].Terminal, null, TextCompare: true) == 0)
					{
						mFiacao[i].Terminal = "";
					}
					if (Operators.CompareString(mFiacao[i].Disp1, null, TextCompare: true) == 0)
					{
						mFiacao[i].Disp1 = "";
					}
					if (Operators.CompareString(mFiacao[i].Term1, null, TextCompare: true) == 0)
					{
						mFiacao[i].Term1 = "";
					}
					if (Operators.CompareString(mFiacao[i].Disp2, null, TextCompare: true) == 0)
					{
						mFiacao[i].Disp2 = "";
					}
					if (Operators.CompareString(mFiacao[i].Term2, null, TextCompare: true) == 0)
					{
						mFiacao[i].Term2 = "";
					}
					if (Operators.CompareString(mFiacao[i].Disp3, null, TextCompare: true) == 0)
					{
						mFiacao[i].Disp3 = "";
					}
					if (Operators.CompareString(mFiacao[i].Term3, null, TextCompare: true) == 0)
					{
						mFiacao[i].Term3 = "";
					}
					if (Operators.CompareString(mFiacao[i].Disp4, null, TextCompare: true) == 0)
					{
						mFiacao[i].Disp4 = "";
					}
					if (Operators.CompareString(mFiacao[i].Term4, null, TextCompare: true) == 0)
					{
						mFiacao[i].Term4 = "";
					}
					if (Operators.CompareString(mFiacao[i].Cor12, null, TextCompare: true) == 0)
					{
						mFiacao[i].Cor12 = "";
					}
					if (Operators.CompareString(mFiacao[i].Secao12, null, TextCompare: true) == 0)
					{
						mFiacao[i].Secao12 = "";
					}
					if (Operators.CompareString(mFiacao[i].Pagina12, null, TextCompare: true) == 0)
					{
						mFiacao[i].Pagina12 = "";
					}
					if (Operators.CompareString(mFiacao[i].Cor34, null, TextCompare: true) == 0)
					{
						mFiacao[i].Cor34 = "";
					}
					if (Operators.CompareString(mFiacao[i].Secao34, null, TextCompare: true) == 0)
					{
						mFiacao[i].Secao34 = "";
					}
					if (Operators.CompareString(mFiacao[i].Pagina34, null, TextCompare: true) == 0)
					{
						mFiacao[i].Pagina34 = "";
					}
				}
				((_Worksheet)oSheet).get_Range((object)"A1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 1;
				((_Worksheet)oSheet).get_Range((object)"B1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 0.6;
				((_Worksheet)oSheet).get_Range((object)"C1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				((_Worksheet)oSheet).get_Range((object)"D1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 0.6;
				((_Worksheet)oSheet).get_Range((object)"E1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 1;
				((_Worksheet)oSheet).get_Range((object)"F1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
				((_Worksheet)oSheet).get_Range((object)"G1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
				((_Worksheet)oSheet).get_Range((object)"H1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
				((_Worksheet)oSheet).get_Range((object)"I1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
				((_Worksheet)oSheet).get_Range((object)"J1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				((_Worksheet)oSheet).get_Range((object)"K1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 6;
				((_Worksheet)oSheet).get_Range((object)"L1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 6;
				text = "A1:E1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				text = "A" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Terminal));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "F" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Disp1));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "G" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Term1));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "H" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Disp2));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "I" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Term2));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "J" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Cor12));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "K" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Secao12));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "L" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Pagina12));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				num3 = (int)num;
				text = "A" + Conversions.ToString(num) + ":L" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
				ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
				num += 2L;
				num2 = 0;
				num3 = 0;
				text = "A" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Tag));
				text = "A" + Conversions.ToString(num) + ":E" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 12;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
				num++;
				num3 = (int)num;
				num2 = (int)num;
				int num5 = Information.UBound(mFiacao);
				for (int j = 1; j <= num5; j++)
				{
					string cell = "A" + Conversions.ToString(num + 2L);
					((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
					int num6 = 0;
					num6 = ((j == 0) ? j : (j - 1));
					if ((Operators.CompareString(mFiacao[num6].Tag, "", TextCompare: true) != 0) & (num6 > 0))
					{
						text = "A" + Conversions.ToString(num) + ":E" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[num6].Tag));
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 12;
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
						num++;
						num3 = (int)num;
						num2 = (int)num;
						if (j == 0)
						{
							continue;
						}
					}
					if (mFiacao[j].TipoBorne == 1)
					{
						text = "A" + Conversions.ToString(num) + ":L" + Conversions.ToString(num + 3L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 9;
						text = "A" + Conversions.ToString(num) + ":A" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text = "A" + Conversions.ToString(num + 2L) + ":A" + Conversions.ToString(num + 3L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text = "B" + Conversions.ToString(num) + ":B" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text = "B" + Conversions.ToString(num + 2L) + ":B" + Conversions.ToString(num + 3L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text = "C" + Conversions.ToString(num) + ":C" + Conversions.ToString(num + 3L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text = "D" + Conversions.ToString(num) + ":D" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text = "D" + Conversions.ToString(num + 2L) + ":D" + Conversions.ToString(num + 3L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text = "E" + Conversions.ToString(num) + ":E" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text = "E" + Conversions.ToString(num + 2L) + ":E" + Conversions.ToString(num + 3L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text = "F" + Conversions.ToString(num) + ":F" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text = "G" + Conversions.ToString(num) + ":G" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text = "H" + Conversions.ToString(num) + ":H" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text = "I" + Conversions.ToString(num) + ":I" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text = "J" + Conversions.ToString(num) + ":J" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text = "K" + Conversions.ToString(num) + ":K" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text = "L" + Conversions.ToString(num) + ":L" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text = "F" + Conversions.ToString(num + 2L) + ":F" + Conversions.ToString(num + 3L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text = "G" + Conversions.ToString(num + 2L) + ":G" + Conversions.ToString(num + 3L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text = "H" + Conversions.ToString(num + 2L) + ":H" + Conversions.ToString(num + 3L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text = "I" + Conversions.ToString(num + 2L) + ":I" + Conversions.ToString(num + 3L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text = "J" + Conversions.ToString(num + 2L) + ":J" + Conversions.ToString(num + 3L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text = "K" + Conversions.ToString(num + 2L) + ":K" + Conversions.ToString(num + 3L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text = "L" + Conversions.ToString(num + 2L) + ":L" + Conversions.ToString(num + 3L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text = "A" + Conversions.ToString(num) + ":L" + Conversions.ToString(num + 3L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
						text = "A" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"o");
						text = "A" + Conversions.ToString(num + 2L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"o");
						text = "C" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Terminal));
						if (Operators.CompareString(mFiacao[j].Jumper, "U", TextCompare: true) == 0)
						{
							text = "D" + Conversions.ToString(num);
							ExcFuncoesExcel.SetarCorCelula(ref oSheet, text);
						}
						if (Operators.CompareString(mFiacao[j].Jumper, "D", TextCompare: true) == 0)
						{
							text = "D" + Conversions.ToString(num + 2L);
							ExcFuncoesExcel.SetarCorCelula(ref oSheet, text);
						}
						if (Operators.CompareString(mFiacao[j].Jumper, "UD", TextCompare: true) == 0)
						{
							text = "D" + Conversions.ToString(num) + ":D" + Conversions.ToString(num + 3L);
							ExcFuncoesExcel.SetarCorCelula(ref oSheet, text);
						}
						text = "E" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"o");
						text = "E" + Conversions.ToString(num + 2L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"o");
						text = "F" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Disp1));
						text = "G" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Term1));
						text = "H" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Disp2));
						text = "I" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Term2));
						text = "J" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Cor12));
						text = "K" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Secao12));
						text = "L" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Pagina12));
						text = "F" + Conversions.ToString(num + 2L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j + 1].Disp3));
						text = "G" + Conversions.ToString(num + 2L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j + 1].Term3));
						text = "H" + Conversions.ToString(num + 2L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j + 1].Disp4));
						text = "I" + Conversions.ToString(num + 2L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j + 1].Term4));
						text = "J" + Conversions.ToString(num + 2L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j + 1].Cor34));
						text = "K" + Conversions.ToString(num + 2L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j + 1].Secao34));
						text = "L" + Conversions.ToString(num + 2L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j + 1].Pagina34));
						num3 = (int)(num + 3L);
						num += 4L;
					}
					if (mFiacao[j].TipoBorne == 0)
					{
						text = "A" + Conversions.ToString(num) + ":L" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 9;
						text = "A" + Conversions.ToString(num) + ":A" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text = "C" + Conversions.ToString(num) + ":C" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text = "E" + Conversions.ToString(num) + ":E" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text = "F" + Conversions.ToString(num) + ":F" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text = "G" + Conversions.ToString(num) + ":G" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text = "H" + Conversions.ToString(num) + ":H" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text = "I" + Conversions.ToString(num) + ":I" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text = "J" + Conversions.ToString(num) + ":J" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text = "K" + Conversions.ToString(num) + ":K" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text = "L" + Conversions.ToString(num) + ":L" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text = "A" + Conversions.ToString(num) + ":L" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
						text = "A" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"o");
						text = "C" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Terminal));
						if (Operators.CompareString(mFiacao[j].Jumper, "U", TextCompare: true) == 0)
						{
							text = "D" + Conversions.ToString(num);
							ExcFuncoesExcel.SetarCorCelula(ref oSheet, text);
						}
						if (Operators.CompareString(mFiacao[j].Jumper, "D", TextCompare: true) == 0)
						{
							text = "D" + Conversions.ToString(num + 1L);
							ExcFuncoesExcel.SetarCorCelula(ref oSheet, text);
						}
						if (Operators.CompareString(mFiacao[j].Jumper, "UD", TextCompare: true) == 0)
						{
							text = "D" + Conversions.ToString(num) + ":D" + Conversions.ToString(num + 1L);
							ExcFuncoesExcel.SetarCorCelula(ref oSheet, text);
						}
						text = "E" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"o");
						text = "F" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Disp1));
						text = "G" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Term1));
						text = "H" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Disp2));
						text = "I" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Term2));
						text = "J" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Cor12));
						text = "K" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Secao12));
						text = "L" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Pagina12));
						num3 = (int)(num + 1L);
						num += 2L;
					}
					if (j < Information.UBound(mFiacao))
					{
						num6 = j;
					}
					if (Operators.CompareString(mFiacao[num6].Tag, "", TextCompare: true) != 0)
					{
						text = "A" + Conversions.ToString(num2) + ":L" + Conversions.ToString(num3);
						ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
						num++;
						num2 = (int)num;
						num3 = (int)num;
					}
				}
				text = "A" + Conversions.ToString(num2) + ":L" + Conversions.ToString(num3);
				ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
				ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static object BuscaPaginasUsadas(DeclaracoesFiacao.structureRelFiacao[] mFiacao, string sTagSubtitulo)
	{
		string text = "";
		checked
		{
			try
			{
				List<string> list = new List<string>();
				bool flag = false;
				int num = Information.UBound(mFiacao);
				for (int i = 1; i <= num; i++)
				{
					if (Operators.CompareString(mFiacao[i - 1].Tag, "", TextCompare: true) != 0 && Operators.CompareString(mFiacao[i - 1].Tag.ToString().ToUpper(), sTagSubtitulo.ToString().ToUpper(), TextCompare: true) == 0)
					{
						flag = true;
					}
					if (flag && Operators.CompareString(mFiacao[i].Pagina12, "", TextCompare: true) != 0 && i > 0 && !list.Contains(mFiacao[i].Pagina12.ToString().ToUpper()))
					{
						list.Add(mFiacao[i].Pagina12.ToString().ToUpper());
					}
					if (i < Information.UBound(mFiacao) && Operators.CompareString(mFiacao[i + 1].Tag.ToString().ToUpper(), "", TextCompare: true) != 0 && Operators.CompareString(mFiacao[i + 1].Tag.ToString().ToUpper(), sTagSubtitulo.ToString().ToUpper(), TextCompare: true) != 0 && flag)
					{
						break;
					}
				}
				list.Sort();
				foreach (string item in list)
				{
					text = text + item + "/";
				}
				if (Operators.CompareString(text, "", TextCompare: true) != 0)
				{
					text = Strings.Mid(text, 1, Strings.Len(text) - 1);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			return text;
		}
	}

	public static void ExportaNomesCircuitosEXCEL(DataGridView dgCircuitos)
	{
		checked
		{
			try
			{
				Microsoft.Office.Interop.Excel.Application oExcelNew = null;
				Worksheet oSheet = null;
				string oNomeSheet = "CIRCUITOS";
				ExcFuncoesExcel.VerificaExcel(ref oExcelNew, ref oSheet, oNomeSheet);
				ExcFuncoesExcel.DesativaCalculoExcel(ref oExcelNew);
				((_Worksheet)oSheet).get_Range((object)"A1", (object)"Z10000").EntireRow.Delete(RuntimeHelpers.GetObjectValue(Missing.Value));
				oSheet.Cells.ClearComments();
				long num = 1L;
				int num2 = 1;
				string text = "";
				text = "A1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 20;
				text = "B1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				text = "C1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 20;
				text = "D1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 30;
				text = "A1:D1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "A" + Conversions.ToString(1L);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1081]));
				text = "B" + Conversions.ToString(1L);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 428]));
				text = "C" + Conversions.ToString(1L);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 686]));
				text = "D" + Conversions.ToString(1L);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 772]));
				text = "A" + Conversions.ToString(1L) + ":D" + Conversions.ToString(1L);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
				ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
				num = 2L;
				num2 = 2;
				string text2 = "";
				int num3 = dgCircuitos.RowCount - 1;
				for (int i = 0; i <= num3; i++)
				{
					if (dgCircuitos.Rows[i].Selected)
					{
						text2 = "A" + Conversions.ToString(num + 2L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
						text = "A" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", dgCircuitos.Rows[i].Cells[1].Value));
						text = "B" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", dgCircuitos.Rows[i].Cells[2].Value));
						text = "C" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", dgCircuitos.Rows[i].Cells[3].Value));
						text = "D" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", dgCircuitos.Rows[i].Cells[4].Value));
						num++;
					}
				}
				text = "A" + Conversions.ToString(num2) + ":D" + Conversions.ToString(num - 1L);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
				text2 = "A1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
				ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
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

	public static bool ImportaNomesCircuitosEXCEL(ref DataGridView dgCircuitos, DeclaracoesEntidades.StructureConexao[] conex)
	{
		bool result = false;
		checked
		{
			try
			{
				Microsoft.Office.Interop.Excel.Application OExcelNew = null;
				Worksheet OSheet = null;
				string oNomeSheet = "CIRCUITOS";
				DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
				dataGridViewCellStyle.BackColor = Color.Yellow;
				if (ExcFuncoesExcel.VerificaExisteSheetSiemens(ref OExcelNew, ref OSheet, oNomeSheet))
				{
					string text = "";
					int num = 3;
					text = "A2";
					while (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)OSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
					{
						num++;
						text = "A" + Conversions.ToString(num);
					}
					int num2 = num - 1;
					for (int i = 2; i <= num2; i++)
					{
						string text2 = "";
						string text3 = "";
						string text4 = "";
						text = "A" + Conversions.ToString(i);
						text2 = Conversions.ToString(((_Worksheet)OSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
						text = "B" + Conversions.ToString(i);
						text3 = Conversions.ToString(((_Worksheet)OSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
						text = "C" + Conversions.ToString(i);
						text4 = Conversions.ToString(((_Worksheet)OSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
						int num3 = dgCircuitos.RowCount - 1;
						for (int j = 0; j <= num3; j++)
						{
							string left = Conversions.ToString(dgCircuitos.Rows[j].Cells[1].Value);
							string left2 = Conversions.ToString(dgCircuitos.Rows[j].Cells[2].Value);
							string left3 = Conversions.ToString(dgCircuitos.Rows[j].Cells[3].Value);
							if ((Operators.CompareString(left, text2, TextCompare: true) == 0) & (Operators.CompareString(left2, text3, TextCompare: true) == 0) & (Operators.CompareString(left3, text4, TextCompare: true) != 0))
							{
								dgCircuitos.Rows[j].Cells[3].Value = text4;
								dgCircuitos.Rows[j].Cells[5].Value = "E";
								dgCircuitos.Rows[j].Cells[3].Style = dataGridViewCellStyle;
								result = true;
								break;
							}
						}
					}
				}
				DeclaracoesGeral._uscPagina.pbFim();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				DeclaracoesGeral._uscPagina.pbFim();
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}
}

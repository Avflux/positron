using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class Relatorios_FiacaoEXCEL_Sul
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
				Application oExcelNew = null;
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
				mFiacao[0].Terminal = "TERM.";
				mFiacao[0].Disp1 = "DISP.";
				mFiacao[0].Term1 = "TERM.";
				mFiacao[0].Disp2 = "Disp.";
				mFiacao[0].Term2 = "TERM.";
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
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 8;
				text = "B1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				text = "C1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 7.57;
				text = "D1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				text = "E1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 7.57;
				text = "F1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 6.29;
				text = "G1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 8;
				text = "H1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				text = "I1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 7.57;
				text = "J1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				text = "K1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 7.57;
				text = "L1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 6.29;
				int iLinhaRelatorio = 2;
				CriaTitulo(ref oSheet, "A", ref iLinhaRelatorio);
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
				Application oExcelNew = null;
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
				DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mFiacao);
				DeclaracoesGeral._uscPagina.pbIniciar();
				int num5 = Information.UBound(mFiacao);
				for (int j = 1; j <= num5; DeclaracoesGeral._uscPagina.pbPasso(), j++)
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

	public static void CriaTitulo(ref Worksheet oSheet, string sColuna, ref int iLinhaRelatorio)
	{
		checked
		{
			try
			{
				string text = "";
				text = "A" + Conversions.ToString(iLinhaRelatorio);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 16;
				text = "A" + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 16;
				if (Operators.CompareString(sColuna, "A", TextCompare: true) != 0)
				{
					text = "G" + Conversions.ToString(iLinhaRelatorio);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'DE");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "H" + Conversions.ToString(iLinhaRelatorio) + ":I" + Conversions.ToString(iLinhaRelatorio);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'PARA: 1");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "J" + Conversions.ToString(iLinhaRelatorio) + ":K" + Conversions.ToString(iLinhaRelatorio);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'PARA: 2");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "L" + Conversions.ToString(iLinhaRelatorio) + ":L" + Conversions.ToString(iLinhaRelatorio + 1);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'OBS:");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					iLinhaRelatorio++;
					text = "G" + Conversions.ToString(iLinhaRelatorio);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'TERM.");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "H" + Conversions.ToString(iLinhaRelatorio);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'DISP.");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "I" + Conversions.ToString(iLinhaRelatorio);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'TERM.");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "J" + Conversions.ToString(iLinhaRelatorio);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'DISP.");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "K" + Conversions.ToString(iLinhaRelatorio);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'TERM.");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				}
				else
				{
					text = "A" + Conversions.ToString(iLinhaRelatorio);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'DE");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "B" + Conversions.ToString(iLinhaRelatorio) + ":C" + Conversions.ToString(iLinhaRelatorio);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'PARA: 1");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "D" + Conversions.ToString(iLinhaRelatorio) + ":E" + Conversions.ToString(iLinhaRelatorio);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'PARA: 2");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "F" + Conversions.ToString(iLinhaRelatorio) + ":F" + Conversions.ToString(iLinhaRelatorio + 1);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'OBS:");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					iLinhaRelatorio++;
					text = "A" + Conversions.ToString(iLinhaRelatorio);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'TERM.");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "B" + Conversions.ToString(iLinhaRelatorio);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'DISP.");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "C" + Conversions.ToString(iLinhaRelatorio);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'TERM.");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "D" + Conversions.ToString(iLinhaRelatorio);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'DISP.");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "E" + Conversions.ToString(iLinhaRelatorio);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'TERM.");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void AdicionaDispositivoMatrizDeIndices(ref Declaracoes2.StructureIndiceRelatEletroSul[] mIndiceRelatorio, string sPagina, string sDispositivo)
	{
		bool flag = true;
		string text = sDispositivo;
		int num = Information.UBound(mIndiceRelatorio);
		if (Operators.CompareString(mIndiceRelatorio[num].sFolha, sPagina, TextCompare: true) == 0)
		{
			if (Operators.CompareString(clsTextos.TiraNothing(mIndiceRelatorio[num].sDescricao), "", TextCompare: true) != 0)
			{
				if (mIndiceRelatorio[num].sDescricao.Contains(sDispositivo))
				{
					flag = false;
					goto IL_0026;
				}
				text = mIndiceRelatorio[num].sDescricao + ", " + sDispositivo;
			}
			else
			{
				text = sDispositivo;
			}
			if (Strings.Len(text) > 38)
			{
				text = sDispositivo;
			}
			else
			{
				mIndiceRelatorio[num].sDescricao = text;
				flag = false;
			}
		}
		goto IL_0026;
		IL_0026:
		checked
		{
			if (flag)
			{
				int num2 = Information.UBound(mIndiceRelatorio) + 1;
				mIndiceRelatorio = (Declaracoes2.StructureIndiceRelatEletroSul[])Utils.CopyArray(mIndiceRelatorio, new Declaracoes2.StructureIndiceRelatEletroSul[num2 + 1]);
				mIndiceRelatorio[num2].sFolha = sPagina;
				mIndiceRelatorio[num2].sDescricao = text;
			}
		}
	}

	public static void BuscaIndiceJaExistente(ref Application OExcel, ref Declaracoes2.StructureIndiceRelatEletroSul[] mIndiceRelatorio)
	{
		checked
		{
			try
			{
				int num = default;
				mIndiceRelatorio = new Declaracoes2.StructureIndiceRelatEletroSul[num + 1];
				if (OExcel.Workbooks.Count <= 0)
				{
					return;
				}
				Workbook activeWorkbook = OExcel.ActiveWorkbook;
				int count = activeWorkbook.Sheets.Count;
				for (int i = 1; i <= count; i++)
				{
					bool flag = true;
					int num2 = Information.UBound(mIndiceRelatorio);
					for (int j = 1; j <= num2; j++)
					{
						if (Operators.ConditionalCompareObjectEqual(mIndiceRelatorio[num].sDescricao, NewLateBinding.LateGet(activeWorkbook.Worksheets[i], null, "Name", new object[0], null, null, null), TextCompare: true))
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						num++;
						mIndiceRelatorio = (Declaracoes2.StructureIndiceRelatEletroSul[])Utils.CopyArray(mIndiceRelatorio, new Declaracoes2.StructureIndiceRelatEletroSul[num + 1]);
						mIndiceRelatorio[num].sFolha = Conversions.ToString(i);
						mIndiceRelatorio[num].sDescricao = Conversions.ToString(NewLateBinding.LateGet(activeWorkbook.Worksheets[i], null, "Name", new object[0], null, null, null));
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}
}

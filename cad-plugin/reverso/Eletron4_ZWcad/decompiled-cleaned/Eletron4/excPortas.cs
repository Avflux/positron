using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class excPortas
{
	public static void ExportaPortas(ref Worksheet oSheet, ref Declaracoes2.MModeloDePortas[] mPortas, string sMOdelo, string sLm1, string sLm2, string sTopo, string sLay)
	{
		checked
		{
			try
			{
				string text = "";
				ExcFuncoesExcel.LimpaSheet(ref oSheet);
				DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mPortas);
				DeclaracoesGeral._uscPagina.pbIniciar();
				int num = 1;
				text = "A" + Conversions.ToString(1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 915]));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 8;
				text = "C" + Conversions.ToString(1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1030]));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
				text = "D" + Conversions.ToString(1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 983]));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).AddComment(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Comment.Visible = false;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Comment.Text(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1031]), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
				text = "E" + Conversions.ToString(1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1846]));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				text = "F" + Conversions.ToString(1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 924]));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 18;
				text = "G" + Conversions.ToString(1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 925]));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 18;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).AddComment(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Comment.Visible = false;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Comment.Text(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1032]), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).WrapText = true;
				num = 2;
				int num2 = Information.UBound(mPortas);
				for (int i = 1; i <= num2; i++)
				{
					text = "A" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + Conversions.ToString(mPortas[i].IndiceDaPorta)));
					text = "C" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mPortas[i].sEFC));
					text = "D" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mPortas[i].sTerminais));
					text = "E" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mPortas[i].sOrientacao));
					text = "F" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mPortas[i].sRegua));
					text = "G" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mPortas[i].sBornes));
					num++;
					DeclaracoesGeral._uscPagina.pbPasso();
				}
				text = "A1:G" + Conversions.ToString(num - 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
				text = "B:B";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 0;
				((_Worksheet)oSheet).get_Range((object)"I1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 25;
				((_Worksheet)oSheet).get_Range((object)"J1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 25;
				string cell = "I1:J1";
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 654]));
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				cell = "I2";
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 654]));
				cell = "J2";
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + sMOdelo));
				cell = "I3";
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject(Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 656]), "1"));
				cell = "J3";
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + sLm1));
				cell = "I4";
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject(Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 656]), "2"));
				cell = "J4";
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + sLm2));
				cell = "I5";
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 657]));
				cell = "J5";
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + sTopo));
				cell = "I6";
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 658]));
				cell = "J6";
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + sLay));
				cell = "I1:J6";
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, cell);
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

	public static bool ExisteIndicesIguaisNasMascarasNovas(ref Worksheet oSheet)
	{
		bool result = false;
		checked
		{
			try
			{
				string cell = "A1";
				int row = ((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_End(XlDirection.xlDown).Row;
				int[,] array = new int[2, 1]
				{
					{ 1 },
					{ 1 }
				};
				cell = "A2:G" + Conversions.ToString(row);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 0;
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ClearComments();
				List<string> list = new List<string>();
				List<string> list2 = new List<string>();
				int num = row;
				for (int i = 2; i <= num; i++)
				{
					if (list.Contains(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)("A" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))))
					{
						list2.Add(Conversions.ToString(i));
					}
					else
					{
						list.Add(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)("A" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
					}
					cell = "F" + Conversions.ToString(i);
					string text = Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
					if (!Information.IsNothing(text) && Operators.CompareString(text, text.Replace("*", ""), TextCompare: true) != 0)
					{
						((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 3;
						ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(6L), Conversions.ToString(i), Conversions.ToString(Operators.ConcatenateObject("* ", DeclaracoesGeral.mMensagem[1, 1252])), 3);
						result = true;
					}
					cell = "F" + Conversions.ToString(i);
					int num2 = DivideValores(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
					cell = "G" + Conversions.ToString(i);
					int num3 = DivideValores(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
					if (!((num2 == 1) & (num3 > 0)) && num2 != num3)
					{
						((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 3;
						ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(6L), Conversions.ToString(i), Conversions.ToString(Operators.ConcatenateObject("* ", DeclaracoesGeral.mMensagem[1, 1252])), 3);
						ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(7L), Conversions.ToString(i), Conversions.ToString(Operators.ConcatenateObject("* ", DeclaracoesGeral.mMensagem[1, 1252])), 3);
						result = true;
					}
				}
				foreach (string item in list2)
				{
					cell = Conversions.ToString(Operators.CompareString(cell, "A" + item, TextCompare: true) == 0);
					((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 3;
					result = true;
				}
				int num4 = row;
				for (int j = 2; j <= num4; j++)
				{
					cell = "E" + Conversions.ToString(j);
					((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))).ToString().ToUpper());
					string text2 = Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
					if (Information.IsNothing(text2) || Operators.CompareString(text2, "", TextCompare: true) == 0)
					{
						continue;
					}
					string text3 = text2.Replace(";", "");
					string text4 = "";
					int num5 = Strings.Len(text3);
					for (int k = 1; k <= num5; k++)
					{
						string text5 = Strings.Mid(text3, k, 1);
						if ((Operators.CompareString(text5, "N", TextCompare: true) == 0) | (Operators.CompareString(text5, "S", TextCompare: true) == 0))
						{
							text4 = text4 + text5 + ";";
						}
					}
					if (Operators.CompareString(text2, text4, TextCompare: true) != 0)
					{
						((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)text4);
						ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(5L), Conversions.ToString(j), Conversions.ToString(Operators.ConcatenateObject(text2 + " ", DeclaracoesGeral.mMensagem[1, 1849])), 44);
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public static int DivideValores(string sValor)
	{
		int num = 0;
		List<string> lTerminais = new List<string>();
		Geral.DivideTerminais(ref lTerminais, sValor, bRepete: true);
		foreach (string item in lTerminais)
		{
			if (Operators.CompareString(item.Trim(), "", TextCompare: true) != 0)
			{
				num = checked(num + 1);
			}
		}
		return num;
	}

	public static bool ExisteIndicesIguaisNasMascarasAntigas(ref Worksheet oSheet)
	{
		bool result = false;
		checked
		{
			try
			{
				int num = 1;
				string cell = "A1";
				int[,] array = new int[2, 1]
				{
					{ 1 },
					{ 1 }
				};
				while (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
				{
					num++;
					cell = "A" + num;
					((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 0;
					if (num > 1)
					{
						array = (int[,])Utils.CopyArray(array, new int[2, Information.UBound(array, 2) + 1 + 1]);
						array[0, Information.UBound(array, 2)] = num;
						array[1, Information.UBound(array, 2)] = Conversions.ToInteger(((_Worksheet)oSheet).get_Range((object)("A" + Conversions.ToString(num)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
						((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 0;
					}
				}
				int num2 = Information.UBound(array, 2) - 1;
				for (int i = 2; i <= num2; i++)
				{
					int num3 = i + 1;
					int num4 = Information.UBound(array, 2);
					for (int j = num3; j <= num4; j++)
					{
						if (array[1, i] == array[1, j])
						{
							cell = "A" + array[0, j];
							((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 3;
							result = true;
						}
					}
				}
				int num5 = num;
				for (int k = 2; k <= num5; k++)
				{
					cell = "E" + Conversions.ToString(k);
					string text = Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
					ExcFuncoesExcel.LimpaErro(ref oSheet, Conversions.ToString(k));
					if (!Information.IsNothing(text) && Operators.CompareString(text, text.Replace("*", ""), TextCompare: true) != 0)
					{
						((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 3;
						ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(5L), Conversions.ToString(k), Conversions.ToString(Operators.ConcatenateObject("* ", DeclaracoesGeral.mMensagem[1, 1252])), 3);
						result = true;
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public static void ImportaPortasMascaraNova(ref Worksheet oSheet, ref Declaracoes2.MModeloDePortas[] mPORTAS, ref bool bComplemento, ref string sMOdelo, ref string sLm1, ref string sLm2, ref string sTopo, ref string sLay)
	{
		checked
		{
			try
			{
				bComplemento = false;
				string text = "";
				int num = 1;
				text = "A1";
				while (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
				{
					num++;
					text = "A" + Conversions.ToString(num);
				}
				mPORTAS = (Declaracoes2.MModeloDePortas[])Utils.CopyArray(mPORTAS, new Declaracoes2.MModeloDePortas[1]);
				int num2 = 0;
				int num3 = num - 1;
				for (int i = 2; i <= num3; i++)
				{
					num2 = Information.UBound(mPORTAS) + 1;
					mPORTAS = (Declaracoes2.MModeloDePortas[])Utils.CopyArray(mPORTAS, new Declaracoes2.MModeloDePortas[num2 + 1]);
					mPORTAS[num2].IndiceDaPorta = 0;
					mPORTAS[num2].sEFC = "";
					mPORTAS[num2].sTerminais = "";
					mPORTAS[num2].sRegua = "";
					mPORTAS[num2].sBornes = "";
					text = "A" + i;
					if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
					{
						mPORTAS[num2].IndiceDaPorta = Conversions.ToInteger(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
					}
					text = "C" + i;
					if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
					{
						mPORTAS[num2].sEFC = ((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString();
						mPORTAS[num2].sEFC = mPORTAS[num2].sEFC.Replace("'", "`");
					}
					text = "D" + i;
					if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
					{
						mPORTAS[num2].sTerminais = ((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString();
						mPORTAS[num2].sTerminais = mPORTAS[num2].sTerminais.Replace("'", "`");
					}
					text = "E" + i;
					if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
					{
						mPORTAS[num2].sOrientacao = ((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString();
						mPORTAS[num2].sOrientacao = mPORTAS[num2].sOrientacao.Replace("'", "`");
					}
					text = "F" + i;
					if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
					{
						mPORTAS[num2].sRegua = ((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString();
						mPORTAS[num2].sRegua = mPORTAS[num2].sRegua.Replace("'", "`");
					}
					text = "G" + i;
					if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
					{
						mPORTAS[num2].sBornes = ((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString();
						mPORTAS[num2].sBornes = mPORTAS[num2].sBornes.Replace("'", "`");
					}
				}
				string cell = "I1";
				if (Operators.ConditionalCompareObjectEqual(clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))), DeclaracoesGeral.mMensagem[1, 654], TextCompare: true))
				{
					bComplemento = true;
					cell = "J2";
					sMOdelo = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
					cell = "J3";
					sLm1 = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
					cell = "J4";
					sLm2 = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
					cell = "J5";
					sTopo = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
					cell = "J6";
					sLay = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void ImportaPortasMascaraAntiga(ref Worksheet oSheet, ref Declaracoes2.MModeloDePortas[] mPORTAS, ref bool bComplemento, ref string sMOdelo, ref string sLm1, ref string sLm2, ref string sTopo, ref string sLay)
	{
		checked
		{
			try
			{
				bComplemento = false;
				string text = "";
				int num = 1;
				text = "A1";
				while (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
				{
					num++;
					text = "A" + Conversions.ToString(num);
				}
				mPORTAS = (Declaracoes2.MModeloDePortas[])Utils.CopyArray(mPORTAS, new Declaracoes2.MModeloDePortas[1]);
				int num2 = 0;
				int num3 = num - 1;
				for (int i = 2; i <= num3; i++)
				{
					num2 = Information.UBound(mPORTAS) + 1;
					mPORTAS = (Declaracoes2.MModeloDePortas[])Utils.CopyArray(mPORTAS, new Declaracoes2.MModeloDePortas[num2 + 1]);
					mPORTAS[num2].IndiceDaPorta = 0;
					mPORTAS[num2].sEFC = "";
					mPORTAS[num2].sTerminais = "";
					mPORTAS[num2].sRegua = "";
					mPORTAS[num2].sBornes = "";
					text = "A" + i;
					if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
					{
						mPORTAS[num2].IndiceDaPorta = Conversions.ToInteger(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
					}
					text = "C" + i;
					if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
					{
						mPORTAS[num2].sEFC = ((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString();
						mPORTAS[num2].sEFC = mPORTAS[num2].sEFC.Replace("'", "`");
					}
					text = "D" + i;
					if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
					{
						mPORTAS[num2].sTerminais = ((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString();
						mPORTAS[num2].sTerminais = mPORTAS[num2].sTerminais.Replace("'", "`");
					}
					text = "E" + i;
					if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
					{
						mPORTAS[num2].sRegua = ((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString();
						mPORTAS[num2].sRegua = mPORTAS[num2].sRegua.Replace("'", "`");
					}
					text = "F" + i;
					if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
					{
						mPORTAS[num2].sBornes = ((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString();
						mPORTAS[num2].sBornes = mPORTAS[num2].sBornes.Replace("'", "`");
					}
					mPORTAS[num2].sOrientacao = "";
				}
				string cell = "H1";
				if (Operators.ConditionalCompareObjectEqual(clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))), DeclaracoesGeral.mMensagem[1, 654], TextCompare: true))
				{
					bComplemento = true;
					cell = "I2";
					sMOdelo = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
					cell = "I3";
					sLm1 = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
					cell = "I4";
					sLm2 = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
					cell = "I5";
					sTopo = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
					cell = "I6";
					sLay = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
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

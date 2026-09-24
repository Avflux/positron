using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class excContatos
{
	public static void ExportaContatos(ref Worksheet oSheet, ref Declaracoes2.StructureContatosAuxiliares[] mContatos, string sMOdelo, string sTerminais, string sLm1, string sLm2, string sTopo, string sLay, string sOrientacao)
	{
		checked
		{
			try
			{
				string text = "";
				((_Worksheet)oSheet).get_Range((object)"A1", (object)"Z10000").EntireRow.Delete(RuntimeHelpers.GetObjectValue(Missing.Value));
				int num = 1;
				((_Worksheet)oSheet).get_Range((object)"A1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 9;
				((_Worksheet)oSheet).get_Range((object)"B1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 6;
				((_Worksheet)oSheet).get_Range((object)"C1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 6;
				((_Worksheet)oSheet).get_Range((object)"D1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 6;
				((_Worksheet)oSheet).get_Range((object)"E1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
				((_Worksheet)oSheet).get_Range((object)"F1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 6;
				((_Worksheet)oSheet).get_Range((object)"G1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
				((_Worksheet)oSheet).get_Range((object)"H1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 4;
				((_Worksheet)oSheet).get_Range((object)"I1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 20;
				((_Worksheet)oSheet).get_Range((object)"J1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 20;
				text = "A" + Conversions.ToString(1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 915]));
				text = "B" + Conversions.ToString(1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"T1");
				text = "C" + Conversions.ToString(1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"T2");
				text = "D" + Conversions.ToString(1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"T3");
				text = "E" + Conversions.ToString(1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1846]));
				text = "F" + Conversions.ToString(1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 908]));
				text = "G" + Conversions.ToString(1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 909]));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).WrapText = true;
				num = 2;
				int num2 = Information.UBound(mContatos);
				for (int i = 1; i <= num2; i++)
				{
					text = "A" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)mContatos[i].iIndice);
					text = "B" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)mContatos[i].sT1);
					text = "C" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)mContatos[i].sT2);
					text = "D" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)mContatos[i].sT3);
					text = "E" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)mContatos[i].sOrientacao);
					text = "F" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)mContatos[i].sTipo);
					text = "G" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)mContatos[i].sComportamento);
					num++;
				}
				text = "A1:G" + Conversions.ToString(num - 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
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
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 655]));
				cell = "J3";
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + sTerminais));
				cell = "I4";
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject(Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 656]), "1"));
				cell = "J4";
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + sLm1));
				cell = "I5";
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject(Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 656]), "2"));
				cell = "J5";
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + sLm2));
				cell = "I6";
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 657]));
				cell = "J6";
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + sTopo));
				cell = "I7";
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 658]));
				cell = "J7";
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + sLay));
				cell = "I8";
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1846]));
				cell = "J8";
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + sOrientacao));
				text = "G2:G8";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				cell = "I1:J8";
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, cell);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static bool ComparaContatosAntigo(ref Worksheet oSheet, ref Declaracoes2.StructureContatosAuxiliares[] mContatos)
	{
		bool result = true;
		string text = "";
		checked
		{
			try
			{
				if (!ExisteIndicesIguaisContatosAntigo(ref oSheet))
				{
					int num = 2;
					text = "A1";
					string text2 = "";
					string text3 = "";
					while (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
					{
						text = "A" + num;
						if (Operators.ConditionalCompareObjectEqual(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
						{
							continue;
						}
						text = "E" + num;
						text2 = Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
						string left = text2;
						if (Operators.CompareString(left, "NA", TextCompare: true) != 0 && Operators.CompareString(left, "NF", TextCompare: true) != 0 && Operators.CompareString(left, "RV", TextCompare: true) != 0)
						{
							if (Operators.CompareString(left, "na", TextCompare: true) != 0 && Operators.CompareString(left, "nf", TextCompare: true) != 0 && Operators.CompareString(left, "rv", TextCompare: true) != 0)
							{
								result = false;
								((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 46;
							}
							else
							{
								((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)text2.ToUpper());
							}
						}
						if (Operators.CompareString(text2, "RV", TextCompare: true) != 0)
						{
							text = "D" + num;
							if (!Operators.ConditionalCompareObjectEqual(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
							{
								string text4 = Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1033], ((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
								((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).AddComment(RuntimeHelpers.GetObjectValue(Missing.Value));
								((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Comment.Visible = false;
								((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Comment.Text(text4, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
								((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"");
								((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 44;
							}
						}
						text = "F" + num;
						text3 = Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
						string left2 = text3;
						if (Operators.CompareString(left2, "ST", TextCompare: true) != 0 && Operators.CompareString(left2, "TE", TextCompare: true) != 0 && Operators.CompareString(left2, "TD", TextCompare: true) != 0 && Operators.CompareString(left2, "BI", TextCompare: true) != 0 && Operators.CompareString(left2, "AM", TextCompare: true) != 0)
						{
							if (Operators.CompareString(left2, "st", TextCompare: true) != 0 && Operators.CompareString(left2, "te", TextCompare: true) != 0 && Operators.CompareString(left2, "td", TextCompare: true) != 0 && Operators.CompareString(left2, "bi", TextCompare: true) != 0 && Operators.CompareString(left2, "am", TextCompare: true) != 0)
							{
								result = false;
								((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 46;
							}
							else
							{
								((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)text3.ToUpper());
							}
						}
						num++;
					}
					int num2;
					if (num == Information.UBound(mContatos))
					{
						num2 = num;
					}
					else
					{
						num2 = ((num < Information.UBound(mContatos)) ? num : (Information.UBound(mContatos) - 1));
					}
					int num3 = 0;
					int num4 = num2;
					for (int i = 1; i <= num4; i++)
					{
						num3 = i + 1;
						text = "E" + num3;
						if (!Operators.ConditionalCompareObjectEqual(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), mContatos[i].sTipo, TextCompare: true))
						{
							((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 46;
							string sTipo = mContatos[i].sTipo;
							((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).AddComment(RuntimeHelpers.GetObjectValue(Missing.Value));
							((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Comment.Visible = false;
							((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Comment.Text(sTipo, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
							result = false;
						}
						text = "F" + num3;
						if (!Operators.ConditionalCompareObjectEqual(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), mContatos[i].sComportamento, TextCompare: true))
						{
							((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 46;
							string sComportamento = mContatos[i].sComportamento;
							((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).AddComment(RuntimeHelpers.GetObjectValue(Missing.Value));
							((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Comment.Visible = false;
							((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Comment.Text(sComportamento, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
							result = false;
						}
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

	public static bool ComparaContatosNovo(ref Worksheet oSheet, ref Declaracoes2.StructureContatosAuxiliares[] mContatos)
	{
		bool result = true;
		string cell = "A1";
		checked
		{
			try
			{
				int num = 2;
				string text = "";
				string text2 = "";
				while (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
				{
					cell = "A" + num;
					if (Operators.ConditionalCompareObjectEqual(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
					{
						continue;
					}
					cell = "F" + num;
					text = Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
					string left = text;
					if (Operators.CompareString(left, "NA", TextCompare: true) != 0 && Operators.CompareString(left, "NF", TextCompare: true) != 0 && Operators.CompareString(left, "RV", TextCompare: true) != 0)
					{
						if (Operators.CompareString(left, "na", TextCompare: true) != 0 && Operators.CompareString(left, "nf", TextCompare: true) != 0 && Operators.CompareString(left, "rv", TextCompare: true) != 0)
						{
							result = false;
							((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 46;
						}
						else
						{
							((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)text.ToUpper());
						}
					}
					if (Operators.CompareString(text, "RV", TextCompare: true) != 0)
					{
						cell = "D" + num;
						if (!Operators.ConditionalCompareObjectEqual(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
						{
							string text3 = Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1033], ((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
							((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).AddComment(RuntimeHelpers.GetObjectValue(Missing.Value));
							((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Comment.Visible = false;
							((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Comment.Text(text3, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
							((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"");
							((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 44;
						}
					}
					cell = "G" + num;
					text2 = Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
					string left2 = text2;
					if (Operators.CompareString(left2, "ST", TextCompare: true) != 0 && Operators.CompareString(left2, "TE", TextCompare: true) != 0 && Operators.CompareString(left2, "TD", TextCompare: true) != 0 && Operators.CompareString(left2, "BI", TextCompare: true) != 0 && Operators.CompareString(left2, "AM", TextCompare: true) != 0)
					{
						if (Operators.CompareString(left2, "st", TextCompare: true) != 0 && Operators.CompareString(left2, "te", TextCompare: true) != 0 && Operators.CompareString(left2, "td", TextCompare: true) != 0 && Operators.CompareString(left2, "bi", TextCompare: true) != 0 && Operators.CompareString(left2, "am", TextCompare: true) != 0)
						{
							result = false;
							((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 46;
						}
						else
						{
							((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)text2.ToUpper());
						}
					}
					num++;
				}
				int num2;
				if (num == Information.UBound(mContatos))
				{
					num2 = num;
				}
				else
				{
					num2 = ((num < Information.UBound(mContatos)) ? num : (Information.UBound(mContatos) - 1));
				}
				int num3 = 0;
				int num4 = num2;
				for (int i = 1; i <= num4; i++)
				{
					num3 = i + 1;
					cell = "F" + num3;
					if (!Operators.ConditionalCompareObjectEqual(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), mContatos[i].sTipo, TextCompare: true))
					{
						((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 46;
						string sTipo = mContatos[i].sTipo;
						((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).AddComment(RuntimeHelpers.GetObjectValue(Missing.Value));
						((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Comment.Visible = false;
						((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Comment.Text(sTipo, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
						result = false;
					}
					cell = "G" + num3;
					if (!Operators.ConditionalCompareObjectEqual(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), mContatos[i].sComportamento, TextCompare: true))
					{
						((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 46;
						string sComportamento = mContatos[i].sComportamento;
						((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).AddComment(RuntimeHelpers.GetObjectValue(Missing.Value));
						((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Comment.Visible = false;
						((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Comment.Text(sComportamento, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
						result = false;
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

	public static bool ImportaContatosAntigo(ref Worksheet oSheet, ref Declaracoes2.StructureContatosAuxiliares[] mContatos_IMPORTAR, ref bool bComplemento, ref Declaracoes2.StructureContatosAuxiliares[] mContatos_CADERNO, ref string sMOdelo, ref string sTerminais, ref string sLm1, ref string sLm2, ref string sTopo, ref string sLay)
	{
		bComplemento = false;
		bool result = true;
		string text = "";
		text = "A1:Z3000";
		((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 0;
		oSheet.Cells.ClearComments();
		text = "";
		checked
		{
			try
			{
				int num = 1;
				text = "A1";
				while (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
				{
					num++;
					text = "A" + Conversions.ToString(num);
				}
				mContatos_IMPORTAR = (Declaracoes2.StructureContatosAuxiliares[])Utils.CopyArray(mContatos_IMPORTAR, new Declaracoes2.StructureContatosAuxiliares[1]);
				int num2 = 0;
				List<string> list = new List<string>();
				List<string> list2 = new List<string>();
				if (num != 1)
				{
					int num3 = num - 1;
					for (int i = 2; i <= num3; i++)
					{
						num2 = Information.UBound(mContatos_IMPORTAR) + 1;
						mContatos_IMPORTAR = (Declaracoes2.StructureContatosAuxiliares[])Utils.CopyArray(mContatos_IMPORTAR, new Declaracoes2.StructureContatosAuxiliares[num2 + 1]);
						mContatos_IMPORTAR[num2].iIndice = 0;
						mContatos_IMPORTAR[num2].sT1 = "";
						mContatos_IMPORTAR[num2].sT2 = "";
						mContatos_IMPORTAR[num2].sT3 = "";
						mContatos_IMPORTAR[num2].sTipo = "";
						mContatos_IMPORTAR[num2].iT = 1;
						mContatos_IMPORTAR[num2].sComportamento = "";
						mContatos_IMPORTAR[num2].iComportamento = 0;
						mContatos_IMPORTAR[num2].sUso = "";
						text = "A" + i;
						if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
						{
							mContatos_IMPORTAR[num2].iIndice = Conversions.ToInteger(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
						}
						text = "B" + i;
						if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
						{
							((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
								.ToUpper());
							mContatos_IMPORTAR[num2].sT1 = ((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString();
						}
						text = "C" + i;
						if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
						{
							((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
								.ToUpper());
							mContatos_IMPORTAR[num2].sT2 = ((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString();
						}
						text = "D" + i;
						if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
						{
							((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
								.ToUpper());
							mContatos_IMPORTAR[num2].sT3 = ((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString();
						}
						text = "E" + i;
						if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
						{
							((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
								.ToUpper());
							mContatos_IMPORTAR[num2].sTipo = ((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString();
						}
						if (Operators.CompareString(mContatos_IMPORTAR[num2].sT1, "", TextCompare: true) == 0)
						{
							mContatos_IMPORTAR[num2].sT1 = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
							((_Worksheet)oSheet).get_Range((object)("B" + i), RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.Conf.CaracterTerminalIndefinido);
						}
						if (Operators.CompareString(mContatos_IMPORTAR[num2].sT2, "", TextCompare: true) == 0)
						{
							mContatos_IMPORTAR[num2].sT2 = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
							((_Worksheet)oSheet).get_Range((object)("C" + i), RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.Conf.CaracterTerminalIndefinido);
						}
						if (Operators.CompareString(mContatos_IMPORTAR[num2].sTipo, "RV", TextCompare: true) != 0)
						{
							mContatos_IMPORTAR[num2].sT3 = "";
						}
						else if (Operators.CompareString(mContatos_IMPORTAR[num2].sT3, "", TextCompare: true) == 0)
						{
							mContatos_IMPORTAR[num2].sT3 = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
							((_Worksheet)oSheet).get_Range((object)("D" + i), RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.Conf.CaracterTerminalIndefinido);
						}
						mContatos_IMPORTAR[num2].sOrientacao = "";
						string sTipo = mContatos_IMPORTAR[num2].sTipo;
						if (Operators.CompareString(sTipo, "NA", TextCompare: true) != 0 && Operators.CompareString(sTipo, "NF", TextCompare: true) != 0 && Operators.CompareString(sTipo, "RV", TextCompare: true) != 0)
						{
							string text2 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 100]);
							((_Worksheet)oSheet).get_Range((object)("E" + i), RuntimeHelpers.GetObjectValue(Missing.Value)).AddComment(RuntimeHelpers.GetObjectValue(Missing.Value));
							((_Worksheet)oSheet).get_Range((object)("E" + i), RuntimeHelpers.GetObjectValue(Missing.Value)).Comment.Visible = false;
							((_Worksheet)oSheet).get_Range((object)("E" + i), RuntimeHelpers.GetObjectValue(Missing.Value)).Comment.Text(text2, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
							((_Worksheet)oSheet).get_Range((object)("E" + i), RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 3;
							result = false;
						}
						if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
						{
							string left = ((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString();
							if (Operators.CompareString(left, "NA", TextCompare: true) != 0)
							{
								if (Operators.CompareString(left, "NF", TextCompare: true) != 0)
								{
									if (Operators.CompareString(left, "RV", TextCompare: true) == 0)
									{
										mContatos_IMPORTAR[num2].iT = 3;
									}
								}
								else
								{
									mContatos_IMPORTAR[num2].iT = 2;
								}
							}
							else
							{
								mContatos_IMPORTAR[num2].iT = 1;
							}
						}
						int num4 = Information.UBound(mContatos_CADERNO);
						for (int j = 1; j <= num4; j++)
						{
							if (mContatos_CADERNO[j].iIndice != mContatos_IMPORTAR[num2].iIndice)
							{
								continue;
							}
							string sTipo2 = mContatos_IMPORTAR[num2].sTipo;
							bool bNA = mContatos_CADERNO[j].bNA;
							bool bNF = mContatos_CADERNO[j].bNF;
							bool bRV = mContatos_CADERNO[j].bRV;
							if (!(!bNA & !bNF & !bRV))
							{
								if (j > Information.UBound(mContatos_CADERNO))
								{
									break;
								}
								string left2 = sTipo2;
								if (Operators.CompareString(left2, "NA", TextCompare: true) != 0)
								{
									if (Operators.CompareString(left2, "NF", TextCompare: true) != 0)
									{
										if (Operators.CompareString(left2, "RV", TextCompare: true) == 0)
										{
										}
									}
									else if (!(!bNA & bNF & !bRV))
									{
										((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 3;
										result = false;
									}
								}
								else if (!(bNA & !bNF & !bRV))
								{
									((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 3;
									result = false;
								}
							}
							else
							{
								mContatos_IMPORTAR[num2].sUso = "";
							}
							break;
						}
						text = "F" + i;
						if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
						{
							mContatos_IMPORTAR[num2].sComportamento = ((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString();
						}
						if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
						{
							string left3 = ((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString();
							if (Operators.CompareString(left3, "ST", TextCompare: true) != 0)
							{
								if (Operators.CompareString(left3, "TE", TextCompare: true) != 0)
								{
									if (Operators.CompareString(left3, "TD", TextCompare: true) != 0)
									{
										if (Operators.CompareString(left3, "BI", TextCompare: true) != 0)
										{
											if (Operators.CompareString(left3, "AM", TextCompare: true) == 0)
											{
												mContatos_IMPORTAR[num2].iComportamento = 4;
											}
										}
										else
										{
											mContatos_IMPORTAR[num2].iComportamento = 3;
										}
									}
									else
									{
										mContatos_IMPORTAR[num2].iComportamento = 2;
									}
								}
								else
								{
									mContatos_IMPORTAR[num2].iComportamento = 1;
								}
							}
							else
							{
								mContatos_IMPORTAR[num2].iComportamento = 0;
							}
						}
						text = "A" + i;
						if (list.Contains(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))))
						{
							list2.Add(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
							result = false;
						}
						else
						{
							list.Add(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
						}
					}
					if (list2.Count > 0)
					{
						int num5 = 2;
						while (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
						{
							text = "A" + num5;
							if (list2.Contains(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))))
							{
								string text3 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 915], " "), ((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))), " "), DeclaracoesGeral.mMensagem[1, 1567]));
								((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).AddComment(RuntimeHelpers.GetObjectValue(Missing.Value));
								((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Comment.Visible = false;
								((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Comment.Text(text3, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
								((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 3;
							}
							num5++;
						}
					}
					string cell = "H1";
					if (Operators.ConditionalCompareObjectEqual(clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))), DeclaracoesGeral.mMensagem[1, 654], TextCompare: true))
					{
						bComplemento = true;
						cell = "I2";
						sMOdelo = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
						cell = "I3";
						sTerminais = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
						cell = "I4";
						sLm1 = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
						cell = "I5";
						sLm2 = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
						cell = "I6";
						sTopo = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
						cell = "I7";
						sLay = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
					}
				}
				else
				{
					result = false;
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

	public static bool ImportaContatosNovo(ref Worksheet oSheet, ref Declaracoes2.StructureContatosAuxiliares[] mContatos_IMPORTAR, ref bool bComplemento, ref Declaracoes2.StructureContatosAuxiliares[] mContatos_CADERNO, ref string sMOdelo, ref string sTerminais, ref string sLm1, ref string sLm2, ref string sTopo, ref string sLay, ref string sOrientacao)
	{
		bComplemento = false;
		bool bRet = true;
		string cell = "A1:Z3000";
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 0;
		oSheet.Cells.ClearComments();
		checked
		{
			try
			{
				int num = 1;
				cell = "A1";
				while (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
				{
					num++;
					cell = "A" + Conversions.ToString(num);
				}
				mContatos_IMPORTAR = (Declaracoes2.StructureContatosAuxiliares[])Utils.CopyArray(mContatos_IMPORTAR, new Declaracoes2.StructureContatosAuxiliares[1]);
				int num2 = 0;
				List<string> list = new List<string>();
				List<string> list2 = new List<string>();
				if (num != 1)
				{
					int num3 = num - 1;
					for (int i = 2; i <= num3; i++)
					{
						num2 = Information.UBound(mContatos_IMPORTAR) + 1;
						mContatos_IMPORTAR = (Declaracoes2.StructureContatosAuxiliares[])Utils.CopyArray(mContatos_IMPORTAR, new Declaracoes2.StructureContatosAuxiliares[num2 + 1]);
						mContatos_IMPORTAR[num2].iIndice = 0;
						mContatos_IMPORTAR[num2].sT1 = "";
						mContatos_IMPORTAR[num2].sT2 = "";
						mContatos_IMPORTAR[num2].sT3 = "";
						mContatos_IMPORTAR[num2].sTipo = "";
						mContatos_IMPORTAR[num2].iT = 1;
						mContatos_IMPORTAR[num2].sComportamento = "";
						mContatos_IMPORTAR[num2].iComportamento = 0;
						mContatos_IMPORTAR[num2].sUso = "";
						cell = "A" + i;
						if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
						{
							mContatos_IMPORTAR[num2].iIndice = Conversions.ToInteger(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
						}
						cell = "B" + i;
						if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
						{
							((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
								.ToUpper());
							mContatos_IMPORTAR[num2].sT1 = ((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString();
						}
						cell = "C" + i;
						if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
						{
							((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
								.ToUpper());
							mContatos_IMPORTAR[num2].sT2 = ((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString();
						}
						cell = "D" + i;
						if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
						{
							((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
								.ToUpper());
							mContatos_IMPORTAR[num2].sT3 = ((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString();
						}
						cell = "E" + i;
						if (!Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
						{
							mContatos_IMPORTAR[num2].sOrientacao = "";
						}
						else
						{
							VerificaOrientacaoNovoContato(ref oSheet, cell, ref bRet, Conversions.ToString(i));
							((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
								.ToUpper());
							mContatos_IMPORTAR[num2].sOrientacao = ((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString();
						}
						cell = "F" + i;
						if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
						{
							((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
								.ToUpper());
							mContatos_IMPORTAR[num2].sTipo = ((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString();
						}
						if (Operators.CompareString(mContatos_IMPORTAR[num2].sT1, "", TextCompare: true) == 0)
						{
							mContatos_IMPORTAR[num2].sT1 = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
							((_Worksheet)oSheet).get_Range((object)("B" + i), RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.Conf.CaracterTerminalIndefinido);
						}
						if (Operators.CompareString(mContatos_IMPORTAR[num2].sT2, "", TextCompare: true) == 0)
						{
							mContatos_IMPORTAR[num2].sT2 = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
							((_Worksheet)oSheet).get_Range((object)("C" + i), RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.Conf.CaracterTerminalIndefinido);
						}
						if (Operators.CompareString(mContatos_IMPORTAR[num2].sTipo, "RV", TextCompare: true) != 0)
						{
							mContatos_IMPORTAR[num2].sT3 = "";
						}
						else if (Operators.CompareString(mContatos_IMPORTAR[num2].sT3, "", TextCompare: true) == 0)
						{
							mContatos_IMPORTAR[num2].sT3 = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
							((_Worksheet)oSheet).get_Range((object)("D" + i), RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.Conf.CaracterTerminalIndefinido);
						}
						string sTipo = mContatos_IMPORTAR[num2].sTipo;
						if (Operators.CompareString(sTipo, "NA", TextCompare: true) != 0 && Operators.CompareString(sTipo, "NF", TextCompare: true) != 0 && Operators.CompareString(sTipo, "RV", TextCompare: true) != 0)
						{
							string text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 100]);
							((_Worksheet)oSheet).get_Range((object)("F" + i), RuntimeHelpers.GetObjectValue(Missing.Value)).AddComment(RuntimeHelpers.GetObjectValue(Missing.Value));
							((_Worksheet)oSheet).get_Range((object)("F" + i), RuntimeHelpers.GetObjectValue(Missing.Value)).Comment.Visible = false;
							((_Worksheet)oSheet).get_Range((object)("F" + i), RuntimeHelpers.GetObjectValue(Missing.Value)).Comment.Text(text, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
							((_Worksheet)oSheet).get_Range((object)("F" + i), RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 3;
							bRet = false;
						}
						if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
						{
							string left = ((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString();
							if (Operators.CompareString(left, "NA", TextCompare: true) != 0)
							{
								if (Operators.CompareString(left, "NF", TextCompare: true) != 0)
								{
									if (Operators.CompareString(left, "RV", TextCompare: true) == 0)
									{
										mContatos_IMPORTAR[num2].iT = 3;
									}
								}
								else
								{
									mContatos_IMPORTAR[num2].iT = 2;
								}
							}
							else
							{
								mContatos_IMPORTAR[num2].iT = 1;
							}
						}
						int num4 = Information.UBound(mContatos_CADERNO);
						for (int j = 1; j <= num4; j++)
						{
							if (mContatos_CADERNO[j].iIndice != mContatos_IMPORTAR[num2].iIndice)
							{
								continue;
							}
							string sTipo2 = mContatos_IMPORTAR[num2].sTipo;
							bool bNA = mContatos_CADERNO[j].bNA;
							bool bNF = mContatos_CADERNO[j].bNF;
							bool bRV = mContatos_CADERNO[j].bRV;
							if (!(!bNA & !bNF & !bRV))
							{
								if (j > Information.UBound(mContatos_CADERNO))
								{
									break;
								}
								string left2 = sTipo2;
								if (Operators.CompareString(left2, "NA", TextCompare: true) != 0)
								{
									if (Operators.CompareString(left2, "NF", TextCompare: true) != 0)
									{
										if (Operators.CompareString(left2, "RV", TextCompare: true) == 0)
										{
										}
									}
									else if (!(!bNA & bNF & !bRV))
									{
										((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 3;
										bRet = false;
									}
								}
								else if (!(bNA & !bNF & !bRV))
								{
									((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 3;
									bRet = false;
								}
							}
							else
							{
								mContatos_IMPORTAR[num2].sUso = "";
							}
							break;
						}
						cell = "G" + i;
						if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
						{
							mContatos_IMPORTAR[num2].sComportamento = ((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
								.ToUpper();
						}
						if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
						{
							string left3 = ((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString();
							if (Operators.CompareString(left3, "ST", TextCompare: true) != 0)
							{
								if (Operators.CompareString(left3, "TE", TextCompare: true) != 0)
								{
									if (Operators.CompareString(left3, "TD", TextCompare: true) != 0)
									{
										if (Operators.CompareString(left3, "BI", TextCompare: true) != 0)
										{
											if (Operators.CompareString(left3, "AM", TextCompare: true) == 0)
											{
												mContatos_IMPORTAR[num2].iComportamento = 4;
											}
										}
										else
										{
											mContatos_IMPORTAR[num2].iComportamento = 3;
										}
									}
									else
									{
										mContatos_IMPORTAR[num2].iComportamento = 2;
									}
								}
								else
								{
									mContatos_IMPORTAR[num2].iComportamento = 1;
								}
							}
							else
							{
								mContatos_IMPORTAR[num2].iComportamento = 0;
							}
						}
						cell = "A" + i;
						if (list.Contains(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))))
						{
							list2.Add(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
							bRet = false;
						}
						else
						{
							list.Add(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
						}
					}
					if (list2.Count > 0)
					{
						int num5 = 2;
						while (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
						{
							cell = "A" + num5;
							if (list2.Contains(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))))
							{
								string text2 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 915], " "), ((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))), " "), DeclaracoesGeral.mMensagem[1, 1567]));
								((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).AddComment(RuntimeHelpers.GetObjectValue(Missing.Value));
								((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Comment.Visible = false;
								((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Comment.Text(text2, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
								((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 3;
							}
							num5++;
						}
					}
					string cell2 = "I1";
					if (Operators.ConditionalCompareObjectEqual(clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))), DeclaracoesGeral.mMensagem[1, 654], TextCompare: true))
					{
						bComplemento = true;
						cell2 = "J2";
						sMOdelo = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
						cell2 = "J3";
						sTerminais = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
						cell2 = "J4";
						sLm1 = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
						cell2 = "J5";
						sLm2 = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
						cell2 = "J6";
						sTopo = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
						cell2 = "J7";
						sLay = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
						cell2 = "J8";
						sOrientacao = "";
						if (Operators.CompareString(clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))).ToUpper(), "", TextCompare: true) != 0)
						{
							VerificaOrientacaoNovoContato(ref oSheet, cell2, ref bRet, Conversions.ToString(8), bModelo: true);
							sOrientacao = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))).ToUpper();
						}
					}
				}
				else
				{
					bRet = false;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			return bRet;
		}
	}

	public static void VerificaOrientacaoNovoContato(ref Worksheet oSheet, string sCel, ref bool bRet, string lin, bool bModelo = false)
	{
		checked
		{
			try
			{
				((_Worksheet)oSheet).get_Range((object)sCel, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 0;
				((_Worksheet)oSheet).get_Range((object)sCel, RuntimeHelpers.GetObjectValue(Missing.Value)).ClearComments();
				((_Worksheet)oSheet).get_Range((object)sCel, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)((_Worksheet)oSheet).get_Range((object)sCel, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
					.ToUpper());
				string text = Conversions.ToString(((_Worksheet)oSheet).get_Range((object)sCel, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
				if (Information.IsNothing(text))
				{
					return;
				}
				bool flag = false;
				if (Operators.CompareString(text, "", TextCompare: true) == 0)
				{
					return;
				}
				int num = 0;
				string text2 = "";
				text2 = (bModelo ? Conversions.ToString(Operators.ConcatenateObject(((_Worksheet)oSheet).get_Range((object)"J3", RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), ";")) : Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(((_Worksheet)oSheet).get_Range((object)("B" + lin), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), ";"), ((_Worksheet)oSheet).get_Range((object)("C" + lin), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))), ";"), ((_Worksheet)oSheet).get_Range((object)("D" + lin), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))), ";")));
				text2 = text2.Replace(";;", ";");
				string[] array = text2.Split(';');
				int num2 = Information.UBound(array);
				for (int i = 0; i <= num2; i++)
				{
					if (Operators.CompareString(array[i].ToString().Trim(), "", TextCompare: true) != 0)
					{
						num++;
					}
				}
				text = text.ToUpper();
				text = text.Trim();
				string text3 = text.Trim();
				text3 = text3.Replace("NN", "N");
				text3 = text3.Replace("SS", "S");
				text3 = text3.Replace("NS", "N");
				text3 = text3.Replace("SN", "S");
				string text4 = "";
				int num3 = 0;
				int num4 = Strings.Len(text3);
				for (int j = 1; j <= num4; j++)
				{
					string text5 = Strings.Mid(text3, j, 1);
					if (!((Operators.CompareString(text5, "N", TextCompare: true) == 0) | (Operators.CompareString(text5, "S", TextCompare: true) == 0) | (Operators.CompareString(text5, ";", TextCompare: true) == 0)))
					{
						flag = true;
						continue;
					}
					if ((Operators.CompareString(text5, "N", TextCompare: true) == 0) | (Operators.CompareString(text5, "S", TextCompare: true) == 0))
					{
						num3++;
					}
					if (num3 <= num)
					{
						text4 += text5;
					}
				}
				text4 = text4.Replace(";;", ";");
				if (Operators.CompareString(text4, ";", TextCompare: true) == 0)
				{
					text4 = "";
				}
				if (!flag)
				{
					if (Operators.CompareString(text, text4, TextCompare: true) != 0)
					{
						((_Worksheet)oSheet).get_Range((object)sCel, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)text4);
						if (!bModelo)
						{
							ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(5L), lin, Conversions.ToString(Operators.ConcatenateObject(text + " ", DeclaracoesGeral.mMensagem[1, 1849])), 44);
						}
						else
						{
							ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(10L), lin, Conversions.ToString(Operators.ConcatenateObject(text + " ", DeclaracoesGeral.mMensagem[1, 1849])), 44);
						}
					}
				}
				else
				{
					if (!bModelo)
					{
						ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(5L), lin, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1850]), 3);
					}
					else
					{
						ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(10L), lin, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1850]), 3);
					}
					bRet = false;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static bool ExisteIndicesIguaisContatosAntigo(ref Worksheet oSheet)
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

	public static void ExportaFuncoesContatos(ref Worksheet oSheet, ref ClsFuncoesDispositivo.StructureFuncaoDisp[] mFuncaoDisp)
	{
		checked
		{
			try
			{
				string text = "";
				((_Worksheet)oSheet).get_Range((object)"A1", (object)"Z10000").EntireRow.Delete(RuntimeHelpers.GetObjectValue(Missing.Value));
				int num = 1;
				string text2 = "";
				int num2 = 1;
				text2 = "A1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text2 = "B1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text2 = "C1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text2 = "D1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 50;
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "A" + Conversions.ToString(1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1005]));
				text = "B" + Conversions.ToString(1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 804]));
				text = "C" + Conversions.ToString(1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 1667].ToString().ToLower());
				text = "D" + Conversions.ToString(1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1244]));
				text2 = "A" + Conversions.ToString(1L) + ":D" + Conversions.ToString(1L);
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text2);
				ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text2, bCompleto: true);
				num2 = 2;
				num = 2;
				string text3 = "";
				int num3 = Information.UBound(mFuncaoDisp);
				for (int i = 1; i <= num3; i++)
				{
					if (Operators.CompareString(text3, "", TextCompare: true) == 0)
					{
						text3 = mFuncaoDisp[i].Nome1;
						if (Operators.CompareString(mFuncaoDisp[i].Nome2, "", TextCompare: true) != 0)
						{
							text3 = text3 + "/" + mFuncaoDisp[i].Nome2;
						}
						num = num2;
					}
					if (i > 1)
					{
						string text4 = mFuncaoDisp[i].Nome1;
						if (Operators.CompareString(mFuncaoDisp[i].Nome2, "", TextCompare: true) != 0)
						{
							text4 = text4 + "/" + mFuncaoDisp[i].Nome2;
						}
						if (Operators.CompareString(text3, text4, TextCompare: true) != 0)
						{
							text2 = "A" + Conversions.ToString(num) + ":D" + Conversions.ToString(num2 - 1);
							ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text2);
							ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text2, bCompleto: true);
							text3 = text4;
							num = num2;
						}
					}
					text = "A" + Conversions.ToString(num2);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFuncaoDisp[i].sPN));
					text = "B" + Conversions.ToString(num2);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + text3));
					text = "C" + Conversions.ToString(num2);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + Conversions.ToString(mFuncaoDisp[i].itemModelo)));
					text = "D" + Conversions.ToString(num2);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFuncaoDisp[i].Funcao));
					num2++;
				}
				text2 = "A" + Conversions.ToString(num) + ":D" + Conversions.ToString(num2 - 1);
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text2);
				ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text2, bCompleto: true);
				text = "A1:D" + Conversions.ToString(num2 - 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void ImportaFuncoesContatos(ref Worksheet oSheet, ClsFuncoesDispositivo.StructureFuncaoDisp[] mFuncaoDisp)
	{
		checked
		{
			try
			{
				string text = "";
				int num = 1;
				text = "A1";
				while (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
				{
					num++;
					text = "A" + Conversions.ToString(num);
				}
				int num2 = num - 1;
				for (int i = 2; i <= num2; i++)
				{
					text = "A" + i;
					string right = ((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString();
					text = "B" + i;
					string left = ((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString();
					text = "C" + i;
					string value = ((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString();
					text = "D" + i;
					string value2 = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
					int num3 = Information.UBound(mFuncaoDisp);
					for (int j = 1; j <= num3; j++)
					{
						string text2 = mFuncaoDisp[j].Nome1;
						if (Operators.CompareString(mFuncaoDisp[j].Nome2, "", TextCompare: true) != 0)
						{
							text2 = text2 + "/" + mFuncaoDisp[j].Nome2;
						}
						if ((Operators.CompareString(mFuncaoDisp[j].sPN, right, TextCompare: true) == 0) & (Operators.CompareString(left, text2, TextCompare: true) == 0) & ((double)mFuncaoDisp[j].itemModelo == Conversions.ToDouble(value)))
						{
							mFuncaoDisp[j].Funcao = clsTextos.TiraNothing(value2);
							break;
						}
					}
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

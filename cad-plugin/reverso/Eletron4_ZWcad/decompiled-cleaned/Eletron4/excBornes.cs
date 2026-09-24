using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class excBornes
{
	public static void ExportaBornes(ref Worksheet oSheet, ref DeclaracoesEntidades.StructureBorne[] mBornes)
	{
		checked
		{
			try
			{
				string text = "";
				DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mBornes) + 1;
				DeclaracoesGeral._uscPagina.pbIniciar();
				ExcFuncoesExcel.LimpaSheet(ref oSheet);
				int num = 1;
				text = "A" + Conversions.ToString(1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1082]));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 0;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).AddComment(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Comment.Visible = false;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Comment.Text(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1194]), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
				text = "B" + Conversions.ToString(1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1036]));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).WrapText = true;
				text = "C" + Conversions.ToString(1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 271]));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).AddComment(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Comment.Visible = false;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Comment.Text(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1195], "\r\n"), DeclaracoesGeral.mMensagem[1, 1196]), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
				text = "D" + Conversions.ToString(1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1069]));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).WrapText = true;
				text = "E" + Conversions.ToString(1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"Handle");
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 0;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).AddComment(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Comment.Visible = false;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Comment.Text(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1194]), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
				text = "F" + Conversions.ToString(1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1846]));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).AddComment(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Comment.Visible = false;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Comment.Text(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("N=", DeclaracoesGeral.mMensagem[1, 1847]), "\r\n"), "S="), DeclaracoesGeral.mMensagem[1, 1848]), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
				text = "G" + Conversions.ToString(1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 658]));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 20;
				num = 2;
				DeclaracoesGeral._uscPagina.pbPasso();
				int num2 = Information.UBound(mBornes);
				for (int i = 1; i <= num2; i++)
				{
					text = "A" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)mBornes[i].Ordem);
					text = "B" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)mBornes[i].Numero);
					text = "C" + Conversions.ToString(num);
					switch (mBornes[i].tipo)
					{
					case 2:
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"X");
						break;
					case 0:
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"S");
						break;
					case 1:
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"D");
						break;
					}
					text = "D" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)mBornes[i].lm);
					text = "E" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mBornes[i].Handle));
					text = "F" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mBornes[i].Orientacao));
					text = "G" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mBornes[i].BlocoLayout));
					num++;
					DeclaracoesGeral._uscPagina.pbPasso();
				}
				text = "A1:G" + Conversions.ToString(num - 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				DeclaracoesGeral._uscPagina.pbFim();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void ImportaBornes(ref Worksheet oSheet, ref DeclaracoesEntidades.StructureBorne[] mBornes)
	{
		checked
		{
			try
			{
				string text = "";
				int num = 2;
				long num2 = 1L;
				num2 = ((_Worksheet)oSheet).get_Range((object)"B1", RuntimeHelpers.GetObjectValue(Missing.Value)).get_End(XlDirection.xlDown).Row;
				mBornes = (DeclaracoesEntidades.StructureBorne[])Utils.CopyArray(mBornes, new DeclaracoesEntidades.StructureBorne[1]);
				int num3 = 0;
				int num4 = (int)num2;
				for (int i = 2; i <= num4; i++)
				{
					ExcFuncoesExcel.LimpaErro(ref oSheet, Conversions.ToString(i));
					num3 = Information.UBound(mBornes) + 1;
					mBornes = (DeclaracoesEntidades.StructureBorne[])Utils.CopyArray(mBornes, new DeclaracoesEntidades.StructureBorne[num3 + 1]);
					text = "A" + Conversions.ToString(num);
					mBornes[num3].Ordem = Conversions.ToInteger(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
					text = "B" + Conversions.ToString(num);
					mBornes[num3].Numero = Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
					text = "C" + Conversions.ToString(num);
					mBornes[num3].tipo = 0;
					object left = ((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value));
					if (!Operators.ConditionalCompareObjectEqual(left, "S", TextCompare: true))
					{
						if (!Operators.ConditionalCompareObjectEqual(left, "D", TextCompare: true))
						{
							if (Operators.ConditionalCompareObjectEqual(left, "X", TextCompare: true))
							{
								mBornes[num3].tipo = 2;
							}
						}
						else
						{
							mBornes[num3].tipo = 1;
						}
					}
					else
					{
						mBornes[num3].tipo = 0;
					}
					text = "D" + Conversions.ToString(num);
					mBornes[num3].lm = Conversions.ToInteger(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
					text = "E" + Conversions.ToString(num);
					if (Operators.CompareString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
						.ToUpper()
						.Trim(), DeclaracoesGeral.mMensagem[1, 375].ToString().ToUpper(), TextCompare: true) != 0)
					{
						if (Operators.CompareString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
							.ToUpper()
							.Trim(), DeclaracoesGeral.mMensagem[1, 1890].ToString().ToUpper(), TextCompare: true) != 0)
						{
							mBornes[num3].Handle = Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
						}
						else
						{
							mBornes[num3].Handle = "";
							mBornes[num3].pagina = Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
						}
					}
					else
					{
						mBornes[num3].Handle = "";
						mBornes[num3].pagina = Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
					}
					text = "F" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))).ToString().ToUpper());
					string text2 = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
					if (!((Operators.CompareString(text2, "N", TextCompare: true) == 0) | (Operators.CompareString(text2, "S", TextCompare: true) == 0) | (Operators.CompareString(text2, "", TextCompare: true) == 0)))
					{
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 3;
						ExcFuncoesExcel.PintaCelula(ref oSheet, "F", Conversions.ToString(Conversions.ToInteger(num.ToString())), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1850]), 3, 1, 160);
					}
					else
					{
						mBornes[num3].Orientacao = text2;
					}
					text = "G" + Conversions.ToString(num);
					mBornes[num3].BlocoLayout = Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
					num++;
					DeclaracoesGeral._uscPagina.pbPasso();
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static string NomeUnico(ref int iNumero)
	{
		checked
		{
			iNumero++;
			return "A" + iNumero;
		}
	}
}

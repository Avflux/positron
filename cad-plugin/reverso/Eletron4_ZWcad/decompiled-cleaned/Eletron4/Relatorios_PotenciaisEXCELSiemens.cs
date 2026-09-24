using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class Relatorios_PotenciaisEXCELSiemens
{
	public static void ExportaAplicacaoEXCEL(DeclaracoesFiacao.structureAplicacao[] mAplicacao)
	{
		checked
		{
			try
			{
				Microsoft.Office.Interop.Excel.Application oExcelNew = null;
				Worksheet oSheet = null;
				string oNomeSheet = "APLICACAO";
				ExcFuncoesExcel.VerificaExcel(ref oExcelNew, ref oSheet, oNomeSheet);
				ExcFuncoesExcel.DesativaCalculoExcel(ref oExcelNew);
				((_Worksheet)oSheet).get_Range((object)"A1", (object)"Z10000").EntireRow.Delete(RuntimeHelpers.GetObjectValue(Missing.Value));
				oSheet.Cells.ClearComments();
				long num = 1L;
				int num2 = 1;
				string text = "";
				text = "A1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 0;
				text = "B1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 30;
				text = "C1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
				text = "D1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				text = "E1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
				text = "F1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				text = "A1:F1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "A" + Conversions.ToString(1L);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1817]));
				text = "B" + Conversions.ToString(1L);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1818]));
				text = "C" + Conversions.ToString(1L);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1819]));
				text = "D" + Conversions.ToString(1L);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1820]));
				text = "E" + Conversions.ToString(1L);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1821]));
				text = "F" + Conversions.ToString(1L);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1822]));
				text = "A" + Conversions.ToString(1L) + ":F" + Conversions.ToString(1L);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
				ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
				num = 2L;
				num2 = 2;
				string text2 = "";
				int num3 = Information.UBound(mAplicacao);
				for (int i = 1; i <= num3; i++)
				{
					text2 = "A" + Conversions.ToString(num + 2L);
					((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
					text = "A" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + Conversions.ToString(mAplicacao[i].Indice)));
					text = "B" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mAplicacao[i].Nome));
					text = "C" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mAplicacao[i].Secao));
					text = "D" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mAplicacao[i].Cor));
					text = "E" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mAplicacao[i].TipoCabo));
					text = "F" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mAplicacao[i].Isolacao));
					num++;
				}
				text = "A" + Conversions.ToString(num2) + ":F" + Conversions.ToString(num - 1L);
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

	public static bool ImportaAplicacaoEXCEL(ref DeclaracoesFiacao.structureAplicacao[] mAplicacao)
	{
		bool flag = true;
		List<int> list = new List<int>();
		checked
		{
			try
			{
				Microsoft.Office.Interop.Excel.Application OExcelNew = null;
				Worksheet OSheet = null;
				string oNomeSheet = "APLICACAO";
				if (ExcFuncoesExcel.VerificaExisteSheetSiemens(ref OExcelNew, ref OSheet, oNomeSheet))
				{
					string text = "";
					int num = 3;
					text = "B3";
					while (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)OSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
					{
						num++;
						text = "B" + Conversions.ToString(num);
					}
					mAplicacao = (DeclaracoesFiacao.structureAplicacao[])Utils.CopyArray(mAplicacao, new DeclaracoesFiacao.structureAplicacao[1]);
					int num2 = 0;
					List<int> list2 = new List<int>();
					int num3 = 0;
					int num4 = num - 1;
					for (int i = 2; i <= num4; i++)
					{
						num2 = Information.UBound(mAplicacao) + 1;
						mAplicacao = (DeclaracoesFiacao.structureAplicacao[])Utils.CopyArray(mAplicacao, new DeclaracoesFiacao.structureAplicacao[num2 + 1]);
						text = "B" + i;
						if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)OSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
						{
							mAplicacao[num2].Nome = ((_Worksheet)OSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString();
						}
						text = "C" + i;
						if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)OSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
						{
							mAplicacao[num2].Secao = ((_Worksheet)OSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString();
						}
						text = "D" + i;
						if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)OSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
						{
							mAplicacao[num2].Cor = ((_Worksheet)OSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString();
						}
						text = "E" + i;
						if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)OSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
						{
							mAplicacao[num2].TipoCabo = ((_Worksheet)OSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString();
						}
						text = "F" + i;
						if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)OSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
						{
							mAplicacao[num2].Isolacao = ((_Worksheet)OSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString();
						}
						text = "A" + i;
						if (!Operators.ConditionalCompareObjectNotEqual(((_Worksheet)OSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
						{
							if (Operators.CompareString(mAplicacao[num2].Nome, "", TextCompare: true) != 0)
							{
								num3++;
								mAplicacao[num2].Indice = num3;
							}
							continue;
						}
						mAplicacao[num2].Indice = Conversions.ToInteger(((_Worksheet)OSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
						if (num3 < mAplicacao[num2].Indice)
						{
							num3 = mAplicacao[num2].Indice;
						}
						if (list2.Contains(mAplicacao[num2].Indice))
						{
							list.Add(mAplicacao[num2].Indice);
							flag = false;
						}
						else
						{
							list2.Add(mAplicacao[num2].Indice);
						}
					}
					if (!flag)
					{
						int num5 = num - 1;
						for (int j = 3; j <= num5; j++)
						{
							text = "A" + j;
							if (list.Contains(Conversions.ToInteger(((_Worksheet)OSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))))
							{
								ExcFuncoesExcel.PintaCelula(ref OSheet, ExcFuncoesExcel.mudaNumeroAsc(1L), Conversions.ToString(j), Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1667], " "), DeclaracoesGeral.mMensagem[1, 1567])), 3);
							}
						}
					}
				}
				ExcFuncoesExcel.AtivaCalculOExcel(ref OExcelNew);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				DeclaracoesGeral._uscPagina.pbFim();
				ProjectData.ClearProjectError();
			}
			return flag;
		}
	}

	public static void ExportaPotenciaisSiemensEXCEL(DeclaracoesFiacao.structureRelPotencialSiemens[] mPotenciais, DeclaracoesFiacao.structureAplicacao[] mAplicacaoOrigem, string sDesenho, string sPainel)
	{
		checked
		{
			try
			{
				Microsoft.Office.Interop.Excel.Application OExcelNew = null;
				Worksheet OSheet = null;
				string oNomeSheet = "EQUIP-EQUIP";
				if (ExcFuncoesExcel.VerificaExisteSheetSiemens(ref OExcelNew, ref OSheet, oNomeSheet))
				{
					ExcFuncoesExcel.AtivaCalculOExcel(ref OExcelNew);
					string text = "";
					string text2 = "";
					int num = Information.UBound(mPotenciais);
					for (int i = 1; i <= num; i++)
					{
						text2 = text2 + clsTextos.TiraDBNull(mPotenciais[i].tag1) + "\t";
						text2 = text2 + clsTextos.TiraDBNull(mPotenciais[i].term1) + "\t";
						text2 = text2 + clsTextos.TiraDBNull(mPotenciais[i].ori1) + "\t";
						text2 = text2 + clsTextos.TiraDBNull(mPotenciais[i].tag2) + "\t";
						text2 = text2 + clsTextos.TiraDBNull(mPotenciais[i].term2) + "\t";
						text2 = text2 + clsTextos.TiraDBNull(mPotenciais[i].ori2) + "\t";
						text2 = text2 + clsTextos.TiraDBNull(mPotenciais[i].cor) + "\t";
						text2 = text2 + clsTextos.TiraDBNull(mPotenciais[i].secao) + "\t";
						text2 += "\t";
						text2 += "\t";
						text2 = text2 + clsTextos.TiraDBNull(mPotenciais[i].potencial) + "\t";
						text2 = text2 + clsTextos.TiraDBNull(mPotenciais[i].Aplicacao) + "\t";
						text2 = text2 + clsTextos.TiraDBNull(mPotenciais[i].pagina1 + "; " + mPotenciais[i].pagina2) + "\t";
						text2 += "\t";
						text2 += "\t";
						text2 += "\r";
					}
					Clipboard.Clear();
					Clipboard.SetText(text2);
					text = "A8";
					((_Worksheet)OSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
					OSheet.Paste(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
					ExcFuncoesExcel.DesativaCalculoExcel(ref OExcelNew);
					Thread.Sleep(1000);
					ExcFuncoesExcel.AtivaCalculOExcel(ref OExcelNew);
					oNomeSheet = "FIAÇÃO";
					if (ExcFuncoesExcel.VerificaExisteSheetSiemens(ref OExcelNew, ref OSheet, oNomeSheet))
					{
						ExcFuncoesExcel.AtivaCalculOExcel(ref OExcelNew);
						text2 = "";
						int num2 = Information.UBound(mAplicacaoOrigem);
						for (int j = 1; j <= num2; j++)
						{
							int num3 = 1;
							do
							{
								text2 += "\t";
								num3++;
							}
							while (num3 <= 5);
							text2 += "\r";
						}
						Clipboard.Clear();
						Clipboard.SetText(text2);
						text = "A5";
						((_Worksheet)OSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
						OSheet.Paste(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
						text2 = "";
						int num4 = Information.UBound(mAplicacaoOrigem);
						for (int k = 1; k <= num4; k++)
						{
							text2 = text2 + clsTextos.TiraDBNull(mAplicacaoOrigem[k].Nome) + "\t";
							text2 = text2 + clsTextos.TiraDBNull(mAplicacaoOrigem[k].TipoCabo) + "\t";
							text2 = text2 + clsTextos.TiraDBNull(mAplicacaoOrigem[k].Isolacao) + "\t";
							text2 = text2 + clsTextos.TiraDBNull(mAplicacaoOrigem[k].Secao) + "\t";
							text2 = text2 + clsTextos.TiraDBNull(mAplicacaoOrigem[k].Cor) + "\r";
						}
						Clipboard.Clear();
						Clipboard.SetText(text2);
						text = "A5";
						((_Worksheet)OSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
						OSheet.Paste(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
						text = "A1";
						((_Worksheet)OSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
					}
					else
					{
						Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1844]), MsgBoxStyle.Exclamation, "Eletron");
					}
				}
				else
				{
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1844]), MsgBoxStyle.Exclamation, "Eletron");
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void ExportaReguasSiemensEXCEL(StructureBorneAplicacao[] mRelReguasSiemens)
	{
		try
		{
			Microsoft.Office.Interop.Excel.Application OExcelNew = null;
			Worksheet OSheet = null;
			string oNomeSheet = "BORNES";
			if (ExcFuncoesExcel.VerificaExisteSheetSiemens(ref OExcelNew, ref OSheet, oNomeSheet))
			{
				ExcFuncoesExcel.AtivaCalculOExcel(ref OExcelNew);
				string text = "";
				string text2 = "";
				int num = Information.UBound(mRelReguasSiemens);
				for (int i = 1; i <= num; i = checked(i + 1))
				{
					text2 = text2 + mRelReguasSiemens[i].Regua + "\t";
					text2 = text2 + mRelReguasSiemens[i].Terminal + "\t";
					text2 = text2 + mRelReguasSiemens[i].modelo + "\t";
					text2 = text2 + mRelReguasSiemens[i].Fabricante + "\t";
					text2 += "\r";
				}
				Clipboard.Clear();
				Clipboard.SetText(text2);
				text = "B8";
				((_Worksheet)OSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
				OSheet.Paste(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
				text = "B8";
				((_Worksheet)OSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
			}
			else
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1844]), MsgBoxStyle.Exclamation, "Eletron");
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public static void ExportaLinksSiemensEXCEL(DeclaracoesFiacao.StructureLinks[] mLinks)
	{
		try
		{
			Microsoft.Office.Interop.Excel.Application OExcelNew = null;
			Worksheet OSheet = null;
			string oNomeSheet = "LINKS";
			if (ExcFuncoesExcel.VerificaExisteSheetSiemens(ref OExcelNew, ref OSheet, oNomeSheet))
			{
				ExcFuncoesExcel.AtivaCalculOExcel(ref OExcelNew);
				string text = "";
				string text2 = "";
				int num = Information.UBound(mLinks);
				for (int i = 1; i <= num; i = checked(i + 1))
				{
					text2 = text2 + mLinks[i].sModelo + "\t";
					text2 = text2 + mLinks[i].sRegua + "\t";
					text2 = text2 + mLinks[i].sBorne1 + "\t";
					text2 = text2 + mLinks[i].sBorne2 + "\t";
					text2 = text2 + Conversions.ToString(mLinks[i].iQuant) + "\t";
					text2 = text2 + mLinks[i].sTipo + "\r";
				}
				Clipboard.Clear();
				Clipboard.SetText(text2);
				text = "B8";
				((_Worksheet)OSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
				OSheet.Paste(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
				text = "B8";
				((_Worksheet)OSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
			}
			else
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1844]), MsgBoxStyle.Exclamation, "Eletron");
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}
}

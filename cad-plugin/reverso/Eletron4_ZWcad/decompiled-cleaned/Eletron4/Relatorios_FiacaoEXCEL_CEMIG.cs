using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class Relatorios_FiacaoEXCEL_CEMIG
{
	public static void EncontraDadosFiacao(ref string sPaginaInicio, ref int ProximaLinhaIndice, ref int iColuna)
	{
		checked
		{
			try
			{
				Microsoft.Office.Interop.Excel.Application oExcelNew = null;
				Worksheet oSheet = null;
				sPaginaInicio = "1";
				if (ExcFuncoesExcel.VerificaExisteSheet(ref oExcelNew, ref oSheet, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1668])))
				{
					sPaginaInicio = "2";
				}
				if (ExcFuncoesExcel.VerificaExisteSheet(ref oExcelNew, ref oSheet, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1667])))
				{
					sPaginaInicio = Conversions.ToString(Conversions.ToInteger(sPaginaInicio) + 1);
				}
				if (ExcFuncoesExcel.VerificaExisteSheet(ref oExcelNew, ref oSheet, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1666])))
				{
					sPaginaInicio = Conversions.ToString(Conversions.ToInteger(sPaginaInicio) + 1);
				}
				if (Information.UBound(FiacaoExcel.mIndiceExcel) > 1)
				{
					sPaginaInicio = Conversions.ToString(Conversions.ToInteger(FiacaoExcel.mIndiceExcel[Information.UBound(FiacaoExcel.mIndiceExcel)].sFolha) + 1);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void CriaMatrizFiacaoDispositivos_Excel_CEMIG(DeclaracoesFiacao.structureRelFiacao[] mFiacao, string sRelatorio, ref string sPainel, frmRelatorio_Fiacao_Excel.ConfRelelatorioExcel ConfRel, ref string sPaginaInicio)
	{
		checked
		{
			try
			{
				Microsoft.Office.Interop.Excel.Application oExcelNew = null;
				Worksheet oSheet = null;
				string oNomeSheet = DeclaracoesGeral.mMensagem[1, 559].ToString().ToUpper();
				string text = DeclaracoesGeral.mMensagem[1, 1081].ToString().ToUpper() + " " + sPainel;
				int num = 75;
				bool flag = true;
				int num2 = 0;
				List<string> lSheetArea = new List<string>();
				Conversions.ToString(4);
				int num3 = 2;
				if (Operators.CompareString(sRelatorio, "DISP", TextCompare: true) == 0)
				{
					sRelatorio = DeclaracoesGeral.mMensagem[1, 832].ToString().ToUpper();
				}
				if (!ExcFuncoesExcel.VerificaExisteSheet(ref oExcelNew, ref oSheet, oNomeSheet))
				{
					ExcFuncoesExcel.VerificaExcel(ref oExcelNew, ref oSheet, oNomeSheet);
				}
				List<string> list = new List<string>();
				list.Add(DeclaracoesGeral.mMensagem[1, 559].ToString().ToUpper());
				if (FiacaoExcel.iLinhaInicialRelatorio == 1)
				{
					Relatorios_ExcelComum.BuscaIndiceSSheetExcel(ref oExcelNew, list);
				}
				long num4 = FiacaoExcel.iLinhaInicialRelatorio;
				int num5 = Conversions.ToInteger(sPaginaInicio);
				_ = (int)Math.Round(ConfRel.LinhasPorPagina);
				string text2 = "";
				text2 = "A1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				text2 = "B1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 14;
				text2 = "C1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
				text2 = "D1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 27;
				text2 = "E1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 8;
				text2 = "F1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 8;
				text2 = "G1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 14;
				text2 = "H1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
				text2 = "I1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 27;
				text2 = "J1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 8;
				text2 = "K1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 8;
				string text3 = "";
				string text4 = "";
				if (flag)
				{
					num = ExcFuncoesExcel.EncontraZoomPagina(ref oExcelNew, ref oSheet);
					ExcFuncoesExcel.FormataPagina(ref oExcelNew, ref oSheet, num);
				}
				ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
				int iLinhaRelatorio = (int)num4;
				FormataCabecalhoInicioCEMIG(ref oExcelNew, ref oSheet, ref iLinhaRelatorio, sRelatorio.ToUpper() + " - " + sPainel, ConfRel);
				num4 = iLinhaRelatorio;
				string text5 = "A";
				string text6 = "";
				text2 = "A1:A" + Conversions.ToString(ConfRel.LinhasPorPagina);
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 16;
				DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mFiacao);
				DeclaracoesGeral._uscPagina.pbIniciar();
				int num6 = 0;
				bool flag2 = false;
				int num7 = Information.UBound(mFiacao);
				for (int i = 1; i <= num7; i++)
				{
					if (Operators.CompareString(mFiacao[i].Disp2, "", TextCompare: true) == 0)
					{
						if (Operators.CompareString(mFiacao[i].Disp3, "", TextCompare: true) == 0)
						{
							if (Operators.CompareString(mFiacao[i].Disp4, "", TextCompare: true) != 0)
							{
								mFiacao[i].Disp2 = mFiacao[i].Disp4;
								mFiacao[i].Term2 = mFiacao[i].Term4;
								if (Operators.CompareString(mFiacao[i].Cor12, mFiacao[i].Cor34, TextCompare: true) != 0)
								{
									ref string cor = ref mFiacao[i].Cor12;
									cor = cor + "; " + mFiacao[i].Cor34;
								}
								if (Operators.CompareString(mFiacao[i].Secao12, mFiacao[i].Secao34, TextCompare: true) != 0)
								{
									ref string secao = ref mFiacao[i].Secao12;
									secao = secao + "; " + mFiacao[i].Secao34;
								}
								mFiacao[i].Disp4 = "";
								mFiacao[i].Term4 = "";
							}
						}
						else
						{
							mFiacao[i].Disp2 = mFiacao[i].Disp3;
							mFiacao[i].Term2 = mFiacao[i].Term3;
							if (Operators.CompareString(mFiacao[i].Cor12, mFiacao[i].Cor34, TextCompare: true) != 0)
							{
								ref string cor2 = ref mFiacao[i].Cor12;
								cor2 = cor2 + "; " + mFiacao[i].Cor34;
							}
							if (Operators.CompareString(mFiacao[i].Secao12, mFiacao[i].Secao34, TextCompare: true) != 0)
							{
								ref string secao2 = ref mFiacao[i].Secao12;
								secao2 = secao2 + "; " + mFiacao[i].Secao34;
							}
							mFiacao[i].Disp3 = "";
							mFiacao[i].Term3 = "";
							if (Operators.CompareString(mFiacao[i].Disp4, "", TextCompare: true) != 0)
							{
								mFiacao[i].Disp3 = mFiacao[i].Disp4;
								mFiacao[i].Term3 = mFiacao[i].Term4;
								mFiacao[i].Disp4 = "";
								mFiacao[i].Term4 = "";
							}
						}
					}
					num6++;
					if ((Operators.CompareString(mFiacao[i - 1].Tag, "", TextCompare: true) != 0) | flag2)
					{
						text3 = mFiacao[i - 1].Tag;
						text4 = mFiacao[i - 1].NomeDispositivo;
						iLinhaRelatorio = (int)num4;
						FormataCabecalhoRodapeCEMIG(ref oExcelNew, ref oSheet, ref lSheetArea, ref iLinhaRelatorio, text4, text3);
						num4 = iLinhaRelatorio;
						if (i < Information.UBound(mFiacao))
						{
							AdicionaDispositivoMatrizDeIndices(num5.ToString(), text3);
						}
					}
					text2 = "A" + Conversions.ToString(num4);
					((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Terminal));
					if (Operators.CompareString(mFiacao[i].Disp1, "", TextCompare: true) != 0)
					{
						text2 = "B" + Conversions.ToString(num4);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Disp1));
						text2 = "C" + Conversions.ToString(num4);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Term1));
						text2 = "D" + Conversions.ToString(num4);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + text3 + "-" + mFiacao[i].Terminal + " / " + mFiacao[i].Disp1 + "-" + mFiacao[i].Term1));
						text2 = "E" + Conversions.ToString(num4);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Cor12));
						text2 = "F" + Conversions.ToString(num4);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Secao12));
					}
					text2 = "D" + Conversions.ToString(num4);
					((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.Color = Information.RGB(253, 233, 217);
					text2 = "F" + Conversions.ToString(num4);
					((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.Color = Information.RGB(253, 233, 217);
					if (Operators.CompareString(mFiacao[i].Disp2, "", TextCompare: true) != 0)
					{
						text2 = "G" + Conversions.ToString(num4);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Disp2));
						text2 = "H" + Conversions.ToString(num4);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Term2));
						text2 = "I" + Conversions.ToString(num4);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + text3 + "-" + mFiacao[i].Terminal + " / " + mFiacao[i].Disp2 + "-" + mFiacao[i].Term2));
						text2 = "J" + Conversions.ToString(num4);
						if (Operators.CompareString(mFiacao[i].Cor34, "", TextCompare: true) == 0)
						{
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Cor12));
						}
						else
						{
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Cor34));
						}
						text2 = "K" + Conversions.ToString(num4);
						if (Operators.CompareString(mFiacao[i].Secao12, "", TextCompare: true) != 0)
						{
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Secao12));
						}
					}
					text2 = "I" + Conversions.ToString(num4);
					((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.Color = Information.RGB(253, 233, 217);
					text2 = "K" + Conversions.ToString(num4);
					((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.Color = Information.RGB(253, 233, 217);
					text2 = "A" + Conversions.ToString(num4) + ":K" + Conversions.ToString(num4);
					ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text2);
					((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					num4++;
					num2++;
					if (((double)num2 >= ConfRel.LinhasPorPagina) | (i == Information.UBound(mFiacao)))
					{
						text6 = text5 + Conversions.ToString(num4 + 2L);
						((_Worksheet)oSheet).get_Range((object)text6, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
						num2 = 0;
						num3++;
					}
					if ((Operators.CompareString(mFiacao[i].Disp3, "", TextCompare: true) != 0) | (Operators.CompareString(mFiacao[i].Disp4, "", TextCompare: true) != 0))
					{
						text2 = "A" + Conversions.ToString(num4);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Terminal));
						if (Operators.CompareString(mFiacao[i].Disp3, "", TextCompare: true) != 0)
						{
							text2 = "B" + Conversions.ToString(num4);
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Disp3));
							text2 = "C" + Conversions.ToString(num4);
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Term3));
							text2 = "D" + Conversions.ToString(num4);
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + text3 + "-" + mFiacao[i].Terminal + " / " + mFiacao[i].Disp3 + "-" + mFiacao[i].Term3));
							text2 = "E" + Conversions.ToString(num4);
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Cor34));
							text2 = "F" + Conversions.ToString(num4);
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Secao34));
						}
						text2 = "D" + Conversions.ToString(num4);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.Color = Information.RGB(253, 233, 217);
						text2 = "F" + Conversions.ToString(num4);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.Color = Information.RGB(253, 233, 217);
						if (Operators.CompareString(mFiacao[i].Disp4, "", TextCompare: true) != 0)
						{
							text2 = "G" + Conversions.ToString(num4);
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Disp4));
							text2 = "H" + Conversions.ToString(num4);
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Term4));
							text2 = "I" + Conversions.ToString(num4);
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + text3 + "-" + mFiacao[i].Terminal + " / " + mFiacao[i].Disp4 + "-" + mFiacao[i].Term4));
							text2 = "J" + Conversions.ToString(num4);
							if (Operators.CompareString(mFiacao[i].Cor34, "", TextCompare: true) != 0)
							{
								((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Cor34));
							}
							text2 = "K" + Conversions.ToString(num4);
							if (Operators.CompareString(mFiacao[i].Secao34, "", TextCompare: true) != 0)
							{
								((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Secao34));
							}
						}
						text2 = "I" + Conversions.ToString(num4);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.Color = Information.RGB(253, 233, 217);
						text2 = "K" + Conversions.ToString(num4);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.Color = Information.RGB(253, 233, 217);
						text2 = "A" + Conversions.ToString(num4) + ":K" + Conversions.ToString(num4);
						ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text2);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						num4++;
						num2++;
						if (((double)num2 >= ConfRel.LinhasPorPagina) | (i == Information.UBound(mFiacao)))
						{
							text6 = text5 + Conversions.ToString(num4 + 2L);
							((_Worksheet)oSheet).get_Range((object)text6, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
							num2 = 0;
							num3++;
						}
					}
					DeclaracoesGeral._uscPagina.pbPasso();
					if (DeclaracoesGeral.bPararRelatorio)
					{
						System.Windows.Forms.Application.DoEvents();
						break;
					}
				}
				oExcelNew.ScreenUpdating = true;
				num5++;
				DeclaracoesFiacao.ilinhaCEMIGD = (int)num4;
				ExcFuncoesExcel.FormataPagina(ref oExcelNew, ref oSheet, num);
				text6 = "A1";
				((_Worksheet)oSheet).get_Range((object)text6, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
				ExcFuncoesExcel.AtivaView(ref oExcelNew, bPreview: true);
				if (oSheet.VPageBreaks.Count > 0)
				{
					oSheet.VPageBreaks[1].DragOff(XlDirection.xlToRight, 1);
				}
				if (oSheet.HPageBreaks.Count > 0)
				{
					oSheet.HPageBreaks[1].DragOff(XlDirection.xlDown, 1);
				}
				int num8 = 0;
				num5 = (int)Math.Round((double)DeclaracoesFiacao.ilinhaCEMIGD / ConfRel.LinhasPorPagina);
				sPaginaInicio = Conversions.ToString(num5);
				int num9 = num5 - 1;
				for (int j = 1; j <= num9; j++)
				{
					num8 = (int)Math.Round((double)j * ConfRel.LinhasPorPagina + 1.0);
					text6 = "A" + Conversions.ToString(num8);
					((_Worksheet)oSheet).get_Range((object)text6, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
					oSheet.HPageBreaks.Add(((_Worksheet)oSheet).get_Range((object)text6, RuntimeHelpers.GetObjectValue(Missing.Value)));
				}
				ExcFuncoesExcel.AtivaView(ref oExcelNew, bPreview: false);
				oSheet.PageSetup.Zoom = num;
				DeclaracoesGeral._uscPagina.pbFim();
				text6 = "A1";
				((_Worksheet)oSheet).get_Range((object)text6, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
				sPainel = text;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				DeclaracoesGeral._uscPagina.pbFim();
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void FormataCabecalhoInicioCEMIG(ref Microsoft.Office.Interop.Excel.Application oExcel, ref Worksheet oSheet, ref int iLinhaRelatorio, string sDispositivo, frmRelatorio_Fiacao_Excel.ConfRelelatorioExcel ConfRel)
	{
		checked
		{
			try
			{
				string text = "";
				ExcFuncoesExcel.AtivaCalculOExcel(ref oExcel);
				text = "A" + Conversions.ToString(iLinhaRelatorio) + ":K" + Conversions.ToString(iLinhaRelatorio);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 12;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)ConfRel.NumDesenho);
				iLinhaRelatorio++;
				text = "A" + Conversions.ToString(iLinhaRelatorio) + ":K" + Conversions.ToString(iLinhaRelatorio);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 12;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)sDispositivo);
				text = "A" + Conversions.ToString(iLinhaRelatorio - 1) + ":K" + Conversions.ToString(iLinhaRelatorio);
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
				iLinhaRelatorio++;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void FormataCabecalhoRodapeCEMIG(ref Microsoft.Office.Interop.Excel.Application oExcel, ref Worksheet oSheet, ref List<string> lSheetArea, ref int iLinhaRelatorio, string sNomeDispositivo, string sDispositivo)
	{
		checked
		{
			try
			{
				string text = "";
				text = "A" + Conversions.ToString(iLinhaRelatorio) + ":A" + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)sDispositivo);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 12;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "B" + Conversions.ToString(iLinhaRelatorio) + ":K" + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)sNomeDispositivo);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 12;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				iLinhaRelatorio += 2;
				text = "A" + Conversions.ToString(iLinhaRelatorio);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'DE");
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "A" + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'TERMINAL");
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "B" + Conversions.ToString(iLinhaRelatorio) + ":D" + Conversions.ToString(iLinhaRelatorio);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'PARA1");
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "B" + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'EQUIPAMENTO");
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "C" + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'TERMINAL");
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "D" + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'ANILHA");
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "E" + Conversions.ToString(iLinhaRelatorio) + ":E" + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'COR");
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "F" + Conversions.ToString(iLinhaRelatorio) + ":F" + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'SEÇÃO\r\n(mm²)");
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "G" + Conversions.ToString(iLinhaRelatorio) + ":I" + Conversions.ToString(iLinhaRelatorio);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'PARA2");
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "G" + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'EQUIPAMENTO");
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "H" + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'TERMINAL");
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "I" + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'ANILHA");
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "J" + Conversions.ToString(iLinhaRelatorio) + ":J" + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'COR");
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "K" + Conversions.ToString(iLinhaRelatorio) + ":K" + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'SEÇÃO\r\n(mm²)");
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "A" + Conversions.ToString(iLinhaRelatorio - 2) + ":K" + Conversions.ToString(iLinhaRelatorio + 1);
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
				iLinhaRelatorio += 2;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void preencheIndiceInterligacaoExcel(string sRev)
	{
		Microsoft.Office.Interop.Excel.Application oExcelNew = null;
		Worksheet oSheet = null;
		int num = 1;
		int num2 = 57;
		List<string> list = new List<string>();
		int num3 = 4;
		checked
		{
			if (ExcFuncoesExcel.VerificaExisteSheet(ref oExcelNew, ref oSheet, "INDICE"))
			{
				string cell = "A4";
				int num4 = Information.UBound(FiacaoExcel.mIndiceExcel);
				for (int i = 1; i <= num4; i++)
				{
					string cell2 = ExcFuncoesExcel.mudaNumeroAsc(num) + num3;
					string cell3 = ExcFuncoesExcel.mudaNumeroAsc(num + 1) + num3;
					string cell4 = ExcFuncoesExcel.mudaNumeroAsc(num + 2) + num3;
					if (!list.Contains(FiacaoExcel.mIndiceExcel[i].sFolha))
					{
						((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + FiacaoExcel.mIndiceExcel[i].sFolha.ToString()));
						((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						list.Add(FiacaoExcel.mIndiceExcel[i].sFolha);
						int num5 = 1;
						do
						{
							string cell5 = ExcFuncoesExcel.mudaNumeroAsc(num5) + num3;
							((_Worksheet)oSheet).get_Range((object)cell5, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Name = RuntimeHelpers.GetObjectValue(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Name);
							((_Worksheet)oSheet).get_Range((object)cell5, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = RuntimeHelpers.GetObjectValue(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size);
							num5++;
						}
						while (num5 <= 3);
						if (Operators.CompareString(sRev, "", TextCompare: true) != 0)
						{
							((_Worksheet)oSheet).get_Range((object)cell3, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + sRev));
							((_Worksheet)oSheet).get_Range((object)cell3, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
							((_Worksheet)oSheet).get_Range((object)cell3, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						}
					}
					int num6 = 1;
					do
					{
						string cell6 = ExcFuncoesExcel.mudaNumeroAsc(num6) + num3;
						((_Worksheet)oSheet).get_Range((object)cell6, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Name = RuntimeHelpers.GetObjectValue(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Name);
						((_Worksheet)oSheet).get_Range((object)cell6, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = RuntimeHelpers.GetObjectValue(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size);
						num6++;
					}
					while (num6 <= 3);
					((_Worksheet)oSheet).get_Range((object)cell4, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + FiacaoExcel.mIndiceExcel[i].sDescricao));
					((_Worksheet)oSheet).get_Range((object)cell4, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)cell4, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 2;
					num3++;
					if (num3 > num2)
					{
						num = 4;
						num3 = 3;
						list.Clear();
					}
				}
			}
			oExcelNew.ScreenUpdating = true;
		}
	}

	public static void AdicionaDispositivoMatrizDeIndices(string sPagina, string sDispositivo)
	{
		bool flag = true;
		string text = sDispositivo;
		int num = Information.UBound(FiacaoExcel.mIndiceExcel);
		new List<string>();
		if (Operators.CompareString(FiacaoExcel.mIndiceExcel[num].sFolha, sPagina, TextCompare: true) == 0)
		{
			if (Operators.CompareString(clsTextos.TiraNothing(FiacaoExcel.mIndiceExcel[num].sDescricao), "", TextCompare: true) != 0)
			{
				if (FiacaoExcel.mIndiceExcel[num].sDescricao.Contains(sDispositivo))
				{
					flag = false;
					goto IL_0032;
				}
				text = FiacaoExcel.mIndiceExcel[num].sDescricao + ", " + sDispositivo;
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
				FiacaoExcel.mIndiceExcel[num].sDescricao = text;
				flag = false;
			}
		}
		goto IL_0032;
		IL_0032:
		int num2 = Information.UBound(FiacaoExcel.mIndiceExcel);
		checked
		{
			for (int i = 0; i <= num2; i++)
			{
				if (Operators.CompareString(FiacaoExcel.mIndiceExcel[num].sFolha, sPagina, TextCompare: true) == 0)
				{
					flag = false;
				}
			}
			if (flag)
			{
				int num3 = Information.UBound(FiacaoExcel.mIndiceExcel) + 1;
				FiacaoExcel.mIndiceExcel = (FiacaoExcel.StructureIndiceRelatorio[])Utils.CopyArray(FiacaoExcel.mIndiceExcel, new FiacaoExcel.StructureIndiceRelatorio[num3 + 1]);
				FiacaoExcel.mIndiceExcel[num3].sFolha = sPagina;
				FiacaoExcel.mIndiceExcel[num3].sDescricao = text;
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class Relatorios_FiacaoEXCEL_Furnas
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

	public static void CriaMatrizFiacaoDispositivos_Excel_Furnas(DeclaracoesFiacao.structureRelFiacao[] mFiacao, string sRelatorio, ref string sPainel, frmRelatorio_Fiacao_Excel.ConfRelelatorioExcel ConfRel, ref string sPaginaInicio)
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
				int num2 = 0;
				List<string> lSheetArea = new List<string>();
				if (!ExcFuncoesExcel.VerificaExisteSheet(ref oExcelNew, ref oSheet, oNomeSheet) && FiacaoExcel.iLinhaInicialRelatorio == 1)
				{
					ExcFuncoesExcel.VerificaExcel(ref oExcelNew, ref oSheet, oNomeSheet);
				}
				List<string> list = new List<string>();
				list.Add(DeclaracoesGeral.mMensagem[1, 559].ToString().ToUpper());
				if (FiacaoExcel.iLinhaInicialRelatorio == 1)
				{
					Relatorios_ExcelComum.BuscaIndiceSSheetExcel(ref oExcelNew, list);
				}
				long num3 = FiacaoExcel.iLinhaInicialRelatorio;
				int num4 = Conversions.ToInteger(sPaginaInicio);
				int iTamanhoDaPagina = (int)Math.Round(ConfRel.LinhasPorPagina);
				string text2 = "";
				text2 = "A1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 11;
				text2 = "B1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 11;
				text2 = "C1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
				text2 = "D1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 11;
				text2 = "E1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 11;
				text2 = "F1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
				text2 = "G1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 11;
				text2 = "H1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 11;
				text2 = "I1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
				text2 = "J1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 8;
				text2 = "K1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 8;
				text2 = "L1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 8;
				text2 = "M1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 8;
				string text3 = "";
				num = ExcFuncoesExcel.EncontraZoomPagina(ref oExcelNew, ref oSheet);
				ExcFuncoesExcel.FormataPagina(ref oExcelNew, ref oSheet, num);
				int iLinhaRelatorio = (int)num3;
				int num5 = FormataCabecalhoRodapeFurnas(ref oExcelNew, ref oSheet, ref lSheetArea, ref iLinhaRelatorio, text, ref iTamanhoDaPagina, sPainel, num4.ToString(), ConfRel, 17, 1);
				num3 = iLinhaRelatorio;
				int num6 = num5;
				string text4 = "A";
				string text5 = "";
				text2 = "A1:A" + Conversions.ToString(ConfRel.LinhasPorPagina);
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 16;
				DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mFiacao);
				DeclaracoesGeral._uscPagina.pbIniciar();
				int num7 = 0;
				bool flag = false;
				int num8 = Information.UBound(mFiacao);
				for (int i = 1; i <= num8; i++)
				{
					num7++;
					if ((Operators.CompareString(mFiacao[i - 1].Tag, "", TextCompare: true) != 0) | flag)
					{
						text3 = mFiacao[i - 1].Tag;
						if (i < Information.UBound(mFiacao))
						{
							AdicionaDispositivoMatrizDeIndices(num4.ToString(), text3);
						}
					}
					text2 = "A" + Conversions.ToString(num3);
					((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + text3));
					text2 = "B" + Conversions.ToString(num3);
					((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Terminal));
					string text6 = "";
					if (Operators.CompareString(text3, "", TextCompare: true) != 0)
					{
						text6 = text3 + ":" + mFiacao[i].Terminal;
					}
					text2 = "C" + Conversions.ToString(num3);
					((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + text6));
					text2 = "D" + Conversions.ToString(num3);
					((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Disp1));
					text2 = "E" + Conversions.ToString(num3);
					((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Term1));
					text6 = "";
					if (Operators.CompareString(mFiacao[i].Disp1, "", TextCompare: true) != 0)
					{
						text6 = mFiacao[i].Disp1 + ":" + mFiacao[i].Term1;
					}
					text2 = "F" + Conversions.ToString(num3);
					((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + text6));
					text2 = "G" + Conversions.ToString(num3);
					((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Disp2));
					text2 = "H" + Conversions.ToString(num3);
					((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Term2));
					text6 = "";
					if (Operators.CompareString(mFiacao[i].Disp2, "", TextCompare: true) != 0)
					{
						text6 = mFiacao[i].Disp2 + ":" + mFiacao[i].Term2;
					}
					text2 = "I" + Conversions.ToString(num3);
					((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + text6));
					text2 = "J" + Conversions.ToString(num3);
					((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Cor12));
					text2 = "K" + Conversions.ToString(num3);
					((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Secao12));
					text2 = "L" + Conversions.ToString(num3);
					((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Pagina12));
					if (mFiacao[i].numLigacoes > 2)
					{
						if (num6 != num3)
						{
							num3++;
						}
						else
						{
							num4++;
							ExcFuncoesExcel.FormataPagina(ref oExcelNew, ref oSheet, num);
							num3 += 4L;
							if (i < Information.UBound(mFiacao))
							{
								num5 = (int)num3;
								iLinhaRelatorio = FormataCabecalhoRodapeFurnas(ref oExcelNew, ref oSheet, ref lSheetArea, ref num5, text, ref iTamanhoDaPagina, sPainel, num4.ToString(), ConfRel, 17, 1);
								num3 = num5;
								num6 = iLinhaRelatorio;
								AdicionaDispositivoMatrizDeIndices(num4.ToString(), text3);
							}
						}
						text2 = "A" + Conversions.ToString(num3);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + text3));
						text2 = "B" + Conversions.ToString(num3);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Terminal));
						text6 = "";
						if (Operators.CompareString(text3, "", TextCompare: true) != 0)
						{
							text6 = text3 + ":" + mFiacao[i].Terminal;
						}
						text2 = "C" + Conversions.ToString(num3);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + text6));
						text2 = "D" + Conversions.ToString(num3);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Disp3));
						text2 = "E" + Conversions.ToString(num3);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Term3));
						text6 = "";
						if (Operators.CompareString(mFiacao[i].Disp3, "", TextCompare: true) != 0)
						{
							text6 = mFiacao[i].Disp3 + ":" + mFiacao[i].Term3;
						}
						text2 = "F" + Conversions.ToString(num3);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + text6));
						text2 = "G" + Conversions.ToString(num3);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Disp4));
						text2 = "H" + Conversions.ToString(num3);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Term4));
						text6 = "";
						if (Operators.CompareString(mFiacao[i].Disp4, "", TextCompare: true) != 0)
						{
							text6 = mFiacao[i].Disp4 + ":" + mFiacao[i].Term4;
						}
						text2 = "I" + Conversions.ToString(num3);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + text6));
						text2 = "J" + Conversions.ToString(num3);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Cor34));
						text2 = "K" + Conversions.ToString(num3);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Secao34));
						text2 = "L" + Conversions.ToString(num3);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Pagina34));
					}
					if (num6 != num3)
					{
						num3++;
					}
					else
					{
						num4++;
						ExcFuncoesExcel.FormataPagina(ref oExcelNew, ref oSheet, num);
						num3 += 4L;
						if (i < Information.UBound(mFiacao))
						{
							iLinhaRelatorio = (int)num3;
							num5 = FormataCabecalhoRodapeFurnas(ref oExcelNew, ref oSheet, ref lSheetArea, ref iLinhaRelatorio, text, ref iTamanhoDaPagina, sPainel, num4.ToString(), ConfRel, 17, 1);
							num3 = iLinhaRelatorio;
							num6 = num5;
							AdicionaDispositivoMatrizDeIndices(num4.ToString(), text3);
						}
					}
					if (((double)num2 >= ConfRel.LinhasPorPagina) | (i == Information.UBound(mFiacao)))
					{
						text5 = text4 + Conversions.ToString(num3 + 2L);
						((_Worksheet)oSheet).get_Range((object)text5, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
						num2 = 0;
					}
					DeclaracoesGeral._uscPagina.pbPasso();
					if (DeclaracoesGeral.bPararRelatorio)
					{
						System.Windows.Forms.Application.DoEvents();
						break;
					}
				}
				oExcelNew.ScreenUpdating = true;
				num4++;
				ExcFuncoesExcel.FormataPagina(ref oExcelNew, ref oSheet, num);
				text5 = "A1";
				((_Worksheet)oSheet).get_Range((object)text5, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
				ExcFuncoesExcel.AtivaView(ref oExcelNew, bPreview: true);
				if (oSheet.VPageBreaks.Count > 0)
				{
					oSheet.VPageBreaks[1].DragOff(XlDirection.xlToRight, 1);
				}
				if (oSheet.HPageBreaks.Count > 0)
				{
					oSheet.HPageBreaks[1].DragOff(XlDirection.xlDown, 1);
				}
				int num9 = 0;
				int num10 = num4 - 1;
				for (int j = 1; j <= num10; j++)
				{
					num9 = (int)Math.Round((double)j * ConfRel.LinhasPorPagina + 1.0);
					text5 = "A" + Conversions.ToString(num9);
					((_Worksheet)oSheet).get_Range((object)text5, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
					oSheet.HPageBreaks.Add(((_Worksheet)oSheet).get_Range((object)text5, RuntimeHelpers.GetObjectValue(Missing.Value)));
				}
				FiacaoExcel.iLinhaInicialRelatorio = num6 + 4;
				ExcFuncoesExcel.AtivaView(ref oExcelNew, bPreview: false);
				oSheet.PageSetup.Zoom = num;
				DeclaracoesGeral._uscPagina.pbFim();
				text5 = "A1";
				((_Worksheet)oSheet).get_Range((object)text5, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
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

	public static int FormataCabecalhoRodapeFurnas(ref Microsoft.Office.Interop.Excel.Application oExcel, ref Worksheet oSheet, ref List<string> lSheetArea, ref int iLinhaRelatorio, string sDispositivo, ref int iTamanhoDaPagina, string sNomePN, string sFolha, frmRelatorio_Fiacao_Excel.ConfRelelatorioExcel ConfRel, int iX, int iY)
	{
		int num = 1;
		checked
		{
			try
			{
				string text = "";
				text = "A" + Conversions.ToString(iLinhaRelatorio) + ":M" + Conversions.ToString(iLinhaRelatorio);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
				ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)sDispositivo);
				iLinhaRelatorio++;
				text = "A" + Conversions.ToString(iLinhaRelatorio) + ":C" + Conversions.ToString(iLinhaRelatorio);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'DE");
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "A" + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'EQUIP");
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "B" + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'TERMINAL");
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "C" + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'ANILHA");
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "D" + Conversions.ToString(iLinhaRelatorio) + ":F" + Conversions.ToString(iLinhaRelatorio);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'PARA1");
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "D" + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'EQUIP");
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "E" + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'TERMINAL");
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "F" + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'ANILHA");
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
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'EQUIP");
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "H" + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'TERMINAL");
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "I" + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
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
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'BITOLA (mm²)");
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "L" + Conversions.ToString(iLinhaRelatorio) + ":L" + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'FOLHA");
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "M" + Conversions.ToString(iLinhaRelatorio) + ":M" + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'OBS:");
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "A" + Conversions.ToString(iLinhaRelatorio) + ":M" + Conversions.ToString(iLinhaRelatorio + 1);
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
				ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
				iLinhaRelatorio += 2;
				int num2 = iLinhaRelatorio;
				num = iLinhaRelatorio + iTamanhoDaPagina - 7;
				text = "A" + Conversions.ToString(iLinhaRelatorio) + ":M" + Conversions.ToString(num);
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
				ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
				string cell = "A" + Conversions.ToString(iLinhaRelatorio);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
				iLinhaRelatorio = num + 1;
				text = "A" + Conversions.ToString(iLinhaRelatorio) + ":B" + Conversions.ToString(iLinhaRelatorio + 2);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				ExcFuncoesExcel.CriaLinhasExternaSimles(ref oSheet, text, bCompleto: true);
				text = "A" + Conversions.ToString(iLinhaRelatorio + 1);
				ExcFuncoesExcel.InsereFigura1(ref oSheet, text, ConfRel.sCaminhoDesenho, iX, iY);
				text = "A" + Conversions.ToString(iLinhaRelatorio) + ":B" + Conversions.ToString(iLinhaRelatorio + 2);
				ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
				text = "C" + Conversions.ToString(iLinhaRelatorio) + ":E" + Conversions.ToString(iLinhaRelatorio);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + ConfRel.Desc1));
				text = "C" + Conversions.ToString(iLinhaRelatorio + 1) + ":F" + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'PAINEL " + sNomePN.ToUpper()));
				text = "C" + Conversions.ToString(iLinhaRelatorio + 2) + ":F" + Conversions.ToString(iLinhaRelatorio + 2);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'Lista de Fiação Interna");
				text = "C" + Conversions.ToString(iLinhaRelatorio) + ":F" + Conversions.ToString(iLinhaRelatorio + 2);
				ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
				text = "G" + Conversions.ToString(iLinhaRelatorio) + ":I" + Conversions.ToString(iLinhaRelatorio);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"Num. Des. ");
				text = "G" + Conversions.ToString(iLinhaRelatorio + 1) + ":I" + Conversions.ToString(iLinhaRelatorio + 2);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + ConfRel.NumDesenho));
				text = "G" + Conversions.ToString(iLinhaRelatorio) + ":I" + Conversions.ToString(iLinhaRelatorio + 2);
				ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
				text = "J" + Conversions.ToString(iLinhaRelatorio) + ":K" + Conversions.ToString(iLinhaRelatorio);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"REV.");
				text = "J" + Conversions.ToString(iLinhaRelatorio + 1) + ":K" + Conversions.ToString(iLinhaRelatorio + 2);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)ConfRel.sRev);
				text = "J" + Conversions.ToString(iLinhaRelatorio) + ":K" + Conversions.ToString(iLinhaRelatorio + 2);
				ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
				text = "L" + Conversions.ToString(iLinhaRelatorio) + ":M" + Conversions.ToString(iLinhaRelatorio);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1665]));
				text = "L" + Conversions.ToString(iLinhaRelatorio + 1) + ":M" + Conversions.ToString(iLinhaRelatorio + 2);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)sFolha);
				text = "L" + Conversions.ToString(iLinhaRelatorio) + ":M" + Conversions.ToString(iLinhaRelatorio + 2);
				ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
				text = "C" + Conversions.ToString(iLinhaRelatorio) + ":M" + Conversions.ToString(iLinhaRelatorio + 2);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				ExcFuncoesExcel.SetaAreaDeImpressao(ref oSheet, ref lSheetArea, "M", Conversions.ToString(iLinhaRelatorio + 2));
				iLinhaRelatorio = num2;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			return num;
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

	public static void preencheRelatorioRevCapaExcel(string sRev)
	{
		Microsoft.Office.Interop.Excel.Application oExcelNew = null;
		Worksheet oSheet = null;
		int num = 3;
		int num2 = 28;
		new List<string>();
		int num3 = 1;
		int num4 = 2;
		checked
		{
			if (ExcFuncoesExcel.VerificaExisteSheet(ref oExcelNew, ref oSheet, "CAPA"))
			{
				int num5 = Information.UBound(FiacaoExcel.mIndiceExcel);
				for (int i = 1; i <= num5; i++)
				{
					string text = "A" + num3 + ":B" + num3;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 287].ToString().ToUpper()));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
					ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
					string text2 = "A" + num4 + ":B" + num4;
					((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 752].ToString().ToUpper()));
					((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text2);
					ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text2, bCompleto: true);
					text = ExcFuncoesExcel.mudaNumeroAsc(num) + num3;
					text2 = ExcFuncoesExcel.mudaNumeroAsc(num) + num4;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + FiacaoExcel.mIndiceExcel[i].sFolha.ToString()));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + sRev));
					((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					num++;
					List<string> list = new List<string>();
					if (((num > num2) | (i == Information.UBound(FiacaoExcel.mIndiceExcel))) && !list.Contains(ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(num3)))
					{
						list.Add(ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(num3));
						num--;
						text = ExcFuncoesExcel.mudaNumeroAsc(3L) + Conversions.ToString(num3) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(num3);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
						ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
						text = ExcFuncoesExcel.mudaNumeroAsc(3L) + Conversions.ToString(num4) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(num4);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 15;
						ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
						ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
						num = 3;
						num3 += 2;
						num4 += 2;
					}
				}
			}
			ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
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

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class RelatoriosFiacaoDispositivosExcelEletrosul
{
	public static void CriaMatrizFiacaoDispositivos_Excel_Sul(DeclaracoesFiacao.structureRelFiacao[] mFiacao, string sRelatorio, ref string sPainel, frmRelatorio_Fiacao_Excel.ConfRelelatorioExcel ConfRel, ref string sPaginaInicio, ref Declaracoes2.StructureIndiceRelatEletroSul[] mIndiceRelatorio, bool bAddCor)
	{
		checked
		{
			try
			{
				Microsoft.Office.Interop.Excel.Application oExcelNew = null;
				Worksheet oSheet = null;
				string oNomeSheet = DeclaracoesGeral.mMensagem[1, 559].ToString().ToUpper();
				string text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1081], " "), sPainel));
				int num = 75;
				bool flag = true;
				int num2 = 0;
				List<string> lSheetArea = new List<string>();
				string sLinIni = Conversions.ToString(1);
				List<int> list = new List<int>();
				if (!ExcFuncoesExcel.VerificaExisteSheet(ref oExcelNew, ref oSheet, oNomeSheet))
				{
					ExcFuncoesExcel.VerificaExcel(ref oExcelNew, ref oSheet, oNomeSheet);
				}
				ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
				ExcFuncoesExcel.VerificaExcel(ref oExcelNew, ref oSheet, oNomeSheet);
				long num3 = 1L;
				int num4 = 1;
				int iLinhaRelatorio = (int)Math.Round(ConfRel.LinhasPorPagina - 3.0);
				string text2 = "";
				mFiacao[0].Terminal = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1156]);
				mFiacao[0].Disp1 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1157]);
				mFiacao[0].Term1 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1156]);
				mFiacao[0].Disp2 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1157]);
				mFiacao[0].Term2 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1156]);
				mFiacao[0].Cor12 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 782]);
				mFiacao[0].Secao12 = "mm²";
				mFiacao[0].Pagina12 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 783]);
				text2 = "A1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 7.5;
				text2 = "B1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 0.5;
				text2 = "C1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				text2 = "D1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 7.57;
				text2 = "E1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				text2 = "F1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 7.57;
				text2 = "G1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 6.29;
				text2 = "H1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 7.5;
				text2 = "I1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 0.5;
				text2 = "J1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				text2 = "K1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 7.57;
				text2 = "L1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				text2 = "M1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 7.57;
				text2 = "N1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 6.29;
				if (bAddCor)
				{
					text2 = "G1";
					((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 6.8;
					text2 = "N1";
					((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 6.8;
				}
				text2 = "A1:N" + Conversions.ToString(ConfRel.LinhasPorPagina - 3.0);
				ExcFuncoesExcel.CriaLinhasPontilhadaInterna(ref oSheet, text2);
				int iLinhaRelatorio2 = (int)num3;
				CriaCabecalhoE_SUL(ref oSheet, ref iLinhaRelatorio2, text);
				num3 = iLinhaRelatorio2;
				if (flag)
				{
					num = ExcFuncoesExcel.EncontraZoomPagina(ref oExcelNew, ref oSheet);
					ExcFuncoesExcel.FormataPagina(ref oExcelNew, ref oSheet, num);
				}
				iLinhaRelatorio2 = (int)num3;
				CriaTituloE_SUL(ref oSheet, "A", ref iLinhaRelatorio2);
				num3 = iLinhaRelatorio2;
				string sDispositivo = "";
				string text3 = "A";
				string text4 = "";
				long num5 = num3;
				long num6 = num3;
				text2 = "A1:A" + Conversions.ToString(ConfRel.LinhasPorPagina);
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 16;
				DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mFiacao);
				DeclaracoesGeral._uscPagina.pbIniciar();
				int num7 = 0;
				bool flag2 = false;
				int num8 = Information.UBound(mFiacao);
				for (int i = 1; i <= num8; i++)
				{
					num7++;
					if (num7 > 30)
					{
						oExcelNew.ScreenUpdating = true;
						text4 = "A" + Conversions.ToString(num5);
						((_Worksheet)oSheet).get_Range((object)text4, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
						oExcelNew.ScreenUpdating = false;
						num7 = 0;
					}
					if (Operators.CompareString(DeclaracoesGeral.companyHardlock.ToUpper(), "CADGRAPH", TextCompare: true) == 0)
					{
						oExcelNew.ScreenUpdating = true;
						text4 = text3 + Conversions.ToString(num3 + 2L);
						((_Worksheet)oSheet).get_Range((object)text4, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
					}
					if ((Operators.CompareString(mFiacao[i - 1].Tag, "", TextCompare: true) != 0) | flag2)
					{
						if (Operators.CompareString(mFiacao[i - 1].Tag, "", TextCompare: true) != 0)
						{
							sDispositivo = mFiacao[i - 1].Tag;
						}
						flag2 = false;
						if (ConfRel.bPagina)
						{
							sDispositivo = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(mFiacao[i - 1].Tag + ConfRel.Prefixo, Relatorios_FiacaoEXCEL.BuscaPaginasUsadas(mFiacao, mFiacao[i - 1].Tag)), ConfRel.Sufixo));
						}
						if ((double)num5 > (double)(num4 - 1) * ConfRel.LinhasPorPagina + 4.0)
						{
							text2 = ((Operators.CompareString(text3, "A", TextCompare: true) == 0) ? ("A" + Conversions.ToString(num5) + ":G" + Conversions.ToString(num6 - 1L)) : ("H" + Conversions.ToString(num5) + ":N" + Conversions.ToString(num6 - 1L)));
							ExcFuncoesExcel.CriaLinhasExternaSimles(ref oSheet, text2, bCompleto: true);
						}
						string sColuna = text3;
						iLinhaRelatorio2 = (int)num3;
						CriaSubTituloE_SUL(ref oSheet, sColuna, ref iLinhaRelatorio2, sDispositivo);
						num3 = iLinhaRelatorio2;
						Relatorios_FiacaoEXCEL_Sul.AdicionaDispositivoMatrizDeIndices(ref mIndiceRelatorio, sPaginaInicio, sDispositivo);
						num5 = num3;
						num6 = num3;
					}
					if (Operators.CompareString(text3, "A", TextCompare: true) != 0)
					{
						text2 = "H" + Conversions.ToString(num3) + ":I" + Conversions.ToString(num3);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text2 = "H" + Conversions.ToString(num3);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Terminal));
						text2 = "J" + Conversions.ToString(num3);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Disp1));
						text2 = "K" + Conversions.ToString(num3);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Term1));
						text2 = "L" + Conversions.ToString(num3);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Disp2));
						text2 = "M" + Conversions.ToString(num3);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Term2));
						if (!bAddCor)
						{
							text2 = "N" + Conversions.ToString(num3);
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Secao12));
						}
						else
						{
							string text5 = mFiacao[i].Secao12 + "/" + mFiacao[i].Cor12;
							if (Operators.CompareString(text5, "/", TextCompare: true) == 0)
							{
								text5 = "";
							}
							text2 = "N" + Conversions.ToString(num3);
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + text5));
						}
						text2 = "H" + Conversions.ToString(num3) + ":N" + Conversions.ToString(num3);
						ExcFuncoesExcel.CriaLinhasPontilhadaInterna(ref oSheet, text2);
						num3++;
						num6 = num3;
					}
					else
					{
						text2 = "A" + Conversions.ToString(num3) + ":B" + Conversions.ToString(num3);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text2 = "A" + Conversions.ToString(num3);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Terminal));
						text2 = "C" + Conversions.ToString(num3);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Disp1));
						text2 = "D" + Conversions.ToString(num3);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Term1));
						text2 = "E" + Conversions.ToString(num3);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Disp2));
						text2 = "F" + Conversions.ToString(num3);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Term2));
						if (!bAddCor)
						{
							text2 = "G" + Conversions.ToString(num3);
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Secao12));
						}
						else
						{
							string text6 = mFiacao[i].Secao12 + "/" + mFiacao[i].Cor12;
							if (Operators.CompareString(text6, "/", TextCompare: true) == 0)
							{
								text6 = "";
							}
							text2 = "G" + Conversions.ToString(num3);
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + text6));
						}
						text2 = "A" + Conversions.ToString(num3) + ":G" + Conversions.ToString(num3);
						ExcFuncoesExcel.CriaLinhasPontilhadaInterna(ref oSheet, text2);
						num3++;
						num6 = num3;
					}
					iLinhaRelatorio = (int)Math.Round((double)num4 * ConfRel.LinhasPorPagina - 2.0);
					bool flag3 = false;
					if (i < Information.UBound(mFiacao) - 1 && Operators.CompareString(mFiacao[i].Tag, "", TextCompare: true) != 0 && num3 + 3L >= iLinhaRelatorio)
					{
						flag3 = true;
					}
					num6 = num3;
					if ((num3 >= iLinhaRelatorio) | flag3)
					{
						if (Operators.CompareString(text3, "A", TextCompare: true) != 0)
						{
							if (Operators.CompareString(text3, "H", TextCompare: true) == 0)
							{
								Thread.Sleep(50);
								text2 = "A" + Conversions.ToString(num3 + 4L) + ":N" + Conversions.ToString((double)(num4 + 1) * ConfRel.LinhasPorPagina - 3.0);
								ExcFuncoesExcel.CriaLinhasPontilhadaInterna(ref oSheet, text2);
								text2 = "H" + Conversions.ToString(num5) + ":N" + Conversions.ToString(num6 - 1L);
								ExcFuncoesExcel.CriaLinhasExternaSimles(ref oSheet, text2, bCompleto: true);
								text3 = "A";
								if (i != Information.UBound(mFiacao))
								{
									num3 = (long)Math.Round((double)num4 * ConfRel.LinhasPorPagina + 1.0);
									iLinhaRelatorio2 = (int)num3;
									CriaCabecalhoE_SUL(ref oSheet, ref iLinhaRelatorio2, text);
									num3 = iLinhaRelatorio2;
									sPaginaInicio = Conversions.ToString(Conversions.ToInteger(sPaginaInicio) + 1);
									string sColuna2 = text3;
									iLinhaRelatorio2 = (int)num3;
									CriaTituloE_SUL(ref oSheet, sColuna2, ref iLinhaRelatorio2);
									num3 = iLinhaRelatorio2;
									if (i < Information.UBound(mFiacao) - 1 && Operators.CompareString(mFiacao[i].Tag, "", TextCompare: true) == 0 && Operators.CompareString(mFiacao[i + 1].Tag, "", TextCompare: true) == 0)
									{
										string sColuna3 = text3;
										iLinhaRelatorio2 = (int)num3;
										CriaSubTituloE_SUL(ref oSheet, sColuna3, ref iLinhaRelatorio2, sDispositivo);
										num3 = iLinhaRelatorio2;
										Relatorios_FiacaoEXCEL_Sul.AdicionaDispositivoMatrizDeIndices(ref mIndiceRelatorio, sPaginaInicio, sDispositivo);
									}
									num5 = num3;
									num6 = num3;
									num4++;
									if (i + 1 <= Information.UBound(mFiacao) && Operators.CompareString(mFiacao[i + 1].Tag, "", TextCompare: true) != 0)
									{
										flag2 = true;
									}
									text2 = "A" + Conversions.ToString(num5) + ":A" + Conversions.ToString((double)num4 * ConfRel.LinhasPorPagina);
									((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 16;
								}
								else
								{
									text3 = "C";
								}
							}
						}
						else
						{
							Thread.Sleep(50);
							text2 = "A" + Conversions.ToString(num5) + ":G" + Conversions.ToString(num6 - 1L);
							ExcFuncoesExcel.CriaLinhasExternaSimles(ref oSheet, text2, bCompleto: true);
							Relatorios_ExcelComum_EletroSul.CriarodapeFiacaoELS(ref oSheet, ref lSheetArea, (int)num3, sPainel, sLinIni, ref iLinhaRelatorio, iLinhaRelatorio, bFormacao: true, bfuncao: true, bDoc: false, bOpcional: false, mIndiceRelatorio[Information.UBound(mIndiceRelatorio)].sFolha, ConfRel, 26, 3);
							list.Add((int)num3);
							text3 = "H";
							num3 = (long)Math.Round((double)(num4 - 1) * ConfRel.LinhasPorPagina + 2.0);
							string sColuna4 = text3;
							iLinhaRelatorio2 = (int)num3;
							CriaTituloE_SUL(ref oSheet, sColuna4, ref iLinhaRelatorio2);
							num3 = iLinhaRelatorio2;
							if (i < Information.UBound(mFiacao) - 1 && Operators.CompareString(mFiacao[i].Tag, "", TextCompare: true) == 0 && Operators.CompareString(mFiacao[i + 1].Tag, "", TextCompare: true) == 0)
							{
								string sColuna5 = text3;
								iLinhaRelatorio2 = (int)num3;
								CriaSubTituloE_SUL(ref oSheet, sColuna5, ref iLinhaRelatorio2, sDispositivo);
								num3 = iLinhaRelatorio2;
								Relatorios_FiacaoEXCEL_Sul.AdicionaDispositivoMatrizDeIndices(ref mIndiceRelatorio, sPaginaInicio, sDispositivo);
							}
							num6 = num3;
							num5 = num3;
							if (i + 1 <= Information.UBound(mFiacao) && Operators.CompareString(mFiacao[i + 1].Tag, "", TextCompare: true) != 0)
							{
								flag2 = true;
							}
						}
					}
					num2++;
					if (((double)num2 >= ConfRel.LinhasPorPagina) | (i == Information.UBound(mFiacao)))
					{
						text4 = text3 + Conversions.ToString(num3 + 2L);
						((_Worksheet)oSheet).get_Range((object)text4, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
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
				if (Operators.CompareString(text3, "A", TextCompare: true) == 0)
				{
					Relatorios_ExcelComum_EletroSul.CriarodapeFiacaoELS(ref oSheet, ref lSheetArea, (int)num3, sPainel, sLinIni, ref iLinhaRelatorio, iLinhaRelatorio, bFormacao: true, bfuncao: true, bDoc: false, bOpcional: false, mIndiceRelatorio[Information.UBound(mIndiceRelatorio)].sFolha, ConfRel, 26, 3);
					list.Add((int)num3);
				}
				sPaginaInicio = Conversions.ToString(Conversions.ToInteger(sPaginaInicio) + 1);
				text2 = "A" + Conversions.ToString(num5) + ":G" + Conversions.ToString(num6 - 1L);
				if (Operators.CompareString(text3, "H", TextCompare: true) == 0)
				{
					text2 = "H" + Conversions.ToString(num5) + ":N" + Conversions.ToString(num6 - 1L);
				}
				ExcFuncoesExcel.CriaLinhasExternaSimles(ref oSheet, text2, bCompleto: true);
				text2 = "A1:N" + Conversions.ToString((double)num4 * ConfRel.LinhasPorPagina);
				ExcFuncoesExcel.CriaLinhasExternaSimles(ref oSheet, text2, bCompleto: true);
				ExcFuncoesExcel.FormataPagina(ref oExcelNew, ref oSheet, num);
				text4 = "A1";
				((_Worksheet)oSheet).get_Range((object)text4, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
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
					text4 = "A" + Conversions.ToString(num9);
					((_Worksheet)oSheet).get_Range((object)text4, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
					oSheet.HPageBreaks.Add(((_Worksheet)oSheet).get_Range((object)text4, RuntimeHelpers.GetObjectValue(Missing.Value)));
				}
				ExcFuncoesExcel.AtivaView(ref oExcelNew, bPreview: false);
				oSheet.PageSetup.Zoom = num;
				DeclaracoesGeral._uscPagina.pbFim();
				text4 = "A1";
				((_Worksheet)oSheet).get_Range((object)text4, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
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

	public static void CriaCabecalhoE_SUL(ref Worksheet oSheet, ref int iLinhaRelatorio, string sDispositivo)
	{
		checked
		{
			try
			{
				string text = "";
				text = "A" + Conversions.ToString(iLinhaRelatorio) + ":N" + Conversions.ToString(iLinhaRelatorio);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 16;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 12;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)sDispositivo);
				iLinhaRelatorio++;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void CriaTituloE_SUL(ref Worksheet oSheet, string sColuna, ref int iLinhaRelatorio)
	{
		checked
		{
			try
			{
				string text = "";
				text = "A" + Conversions.ToString(iLinhaRelatorio) + ":A" + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 16;
				if (Operators.CompareString(sColuna, "A", TextCompare: true) != 0)
				{
					text = "H" + Conversions.ToString(iLinhaRelatorio) + ":I" + Conversions.ToString(iLinhaRelatorio);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'DE");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "J" + Conversions.ToString(iLinhaRelatorio) + ":K" + Conversions.ToString(iLinhaRelatorio);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'PARA: 1");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "L" + Conversions.ToString(iLinhaRelatorio) + ":M" + Conversions.ToString(iLinhaRelatorio);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'PARA: 2");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "N" + Conversions.ToString(iLinhaRelatorio) + ":N" + Conversions.ToString(iLinhaRelatorio + 1);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'OBS:");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					iLinhaRelatorio++;
					text = "H" + Conversions.ToString(iLinhaRelatorio) + ":I" + Conversions.ToString(iLinhaRelatorio);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
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
					text = "L" + Conversions.ToString(iLinhaRelatorio);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'DISP.");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "M" + Conversions.ToString(iLinhaRelatorio);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'TERM.");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "H" + Conversions.ToString(iLinhaRelatorio - 1) + ":N" + Conversions.ToString(iLinhaRelatorio);
				}
				else
				{
					text = "A" + Conversions.ToString(iLinhaRelatorio) + ":A" + Conversions.ToString(iLinhaRelatorio + 1);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 16;
					text = "A" + Conversions.ToString(iLinhaRelatorio) + ":B" + Conversions.ToString(iLinhaRelatorio);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'DE");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "C" + Conversions.ToString(iLinhaRelatorio) + ":D" + Conversions.ToString(iLinhaRelatorio);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'PARA: 1");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "E" + Conversions.ToString(iLinhaRelatorio) + ":F" + Conversions.ToString(iLinhaRelatorio);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'PARA: 2");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "G" + Conversions.ToString(iLinhaRelatorio) + ":G" + Conversions.ToString(iLinhaRelatorio + 1);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'OBS:");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					iLinhaRelatorio++;
					text = "A" + Conversions.ToString(iLinhaRelatorio) + ":B" + Conversions.ToString(iLinhaRelatorio);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'TERM.");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "C" + Conversions.ToString(iLinhaRelatorio);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'DISP.");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "D" + Conversions.ToString(iLinhaRelatorio);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'TERM.");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "E" + Conversions.ToString(iLinhaRelatorio);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'DISP.");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "F" + Conversions.ToString(iLinhaRelatorio);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'TERM.");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "A" + Conversions.ToString(iLinhaRelatorio - 1) + ":G" + Conversions.ToString(iLinhaRelatorio);
				}
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

	public static void CriaSubTituloE_SUL(ref Worksheet oSheet, string sColuna, ref int iLinhaRelatorio, string sDispositivo)
	{
		checked
		{
			try
			{
				string text = "";
				if (Operators.CompareString(sColuna, "A", TextCompare: true) != 0)
				{
					text = "H" + Conversions.ToString(iLinhaRelatorio) + ":N" + Conversions.ToString(iLinhaRelatorio + 1);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 16;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
					text = "H" + Conversions.ToString(iLinhaRelatorio);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)sDispositivo);
				}
				else
				{
					text = "A" + Conversions.ToString(iLinhaRelatorio) + ":G" + Conversions.ToString(iLinhaRelatorio + 1);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 16;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
					text = "A" + Conversions.ToString(iLinhaRelatorio);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)sDispositivo);
				}
				iLinhaRelatorio += 2;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}
}

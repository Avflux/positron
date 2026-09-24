using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class RelatoriosFiacaoBornesExcelEletrosul
{
	public static void EncontraDadosFiacao(ref string sPaginaInicio, ref int iColuna, [Optional][DefaultParameterValue(2)] ref int ProximaLinhaIndice)
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
				bool flag = false;
				if (ExcFuncoesExcel.VerificaExisteSheet(ref oExcelNew, ref oSheet, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1667])))
				{
					ProximaLinhaIndice = 2;
					string text = "";
					int num = 3;
					do
					{
						text = "A" + Conversions.ToString(num);
						iColuna = 1;
						if (Operators.CompareString(clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))).Trim(), "", TextCompare: true) != 0)
						{
							ProximaLinhaIndice = num;
							sPaginaInicio = Conversions.ToString(Conversions.ToInteger(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
						}
						num++;
					}
					while (num <= 55);
					int num2 = 3;
					do
					{
						text = "G" + Conversions.ToString(num2);
						if (Operators.CompareString(clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))).Trim(), "", TextCompare: true) != 0)
						{
							if (iColuna == 1)
							{
								iColuna = 7;
								ProximaLinhaIndice = 3;
							}
							ProximaLinhaIndice = num2;
							sPaginaInicio = Conversions.ToString(Conversions.ToInteger(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
						}
						num2++;
					}
					while (num2 <= 55);
					sPaginaInicio = Conversions.ToString(Conversions.ToDouble(sPaginaInicio) + 1.0);
					if (ProximaLinhaIndice != 57)
					{
						ProximaLinhaIndice++;
					}
					else
					{
						ProximaLinhaIndice = 4;
					}
					flag = true;
				}
				if (flag)
				{
					return;
				}
				if (ExcFuncoesExcel.VerificaExisteSheet(ref oExcelNew, ref oSheet, DeclaracoesGeral.mMensagem[1, 559].ToString().ToUpper()))
				{
					string text2 = "";
					int num3 = 0;
					int num4 = 10;
					do
					{
						text2 = "N" + Conversions.ToString(num4);
						if (!Operators.ConditionalCompareObjectEqual(clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))), DeclaracoesGeral.mMensagem[1, 1665], TextCompare: true))
						{
							num3++;
						}
						else
						{
							text2 = "N" + Conversions.ToString(num4 + 1);
							if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))))
							{
								sPaginaInicio = Conversions.ToString(Conversions.ToInteger(((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
							}
							num3 = 0;
						}
						if (num3 > 200)
						{
							break;
						}
						num4++;
					}
					while (num4 <= 15000);
				}
				if (!ExcFuncoesExcel.VerificaExisteSheet(ref oExcelNew, ref oSheet, DeclaracoesGeral.mMensagem[1, 924].ToString().ToUpper()))
				{
					return;
				}
				string text3 = "";
				int num5 = 0;
				int num6 = 10;
				do
				{
					text3 = "N" + Conversions.ToString(num6);
					if (!Operators.ConditionalCompareObjectEqual(clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))), DeclaracoesGeral.mMensagem[1, 1665], TextCompare: true))
					{
						num5++;
					}
					else
					{
						text3 = "N" + Conversions.ToString(num6 + 2);
						if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))))
						{
							sPaginaInicio = Conversions.ToString(Conversions.ToInteger(((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
						}
						num5 = 0;
					}
					if (num5 <= 200)
					{
						num6++;
						continue;
					}
					break;
				}
				while (num6 <= 15000);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void EncontraLinhaDoIndice(ref int ProximaLinhaIndice)
	{
		checked
		{
			try
			{
				Microsoft.Office.Interop.Excel.Application oExcelNew = null;
				Worksheet oSheet = null;
				if (!ExcFuncoesExcel.VerificaExisteSheet(ref oExcelNew, ref oSheet, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1667])))
				{
					return;
				}
				ProximaLinhaIndice = 2;
				string text = "";
				int num = 3;
				int num2;
				do
				{
					text = "A" + Conversions.ToString(num);
					num2 = 1;
					if (Operators.CompareString(clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))).Trim(), "", TextCompare: true) != 0)
					{
						ProximaLinhaIndice = num;
					}
					num++;
				}
				while (num <= 55);
				int num3 = 3;
				do
				{
					text = "G" + Conversions.ToString(num3);
					if (Operators.CompareString(clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))).Trim(), "", TextCompare: true) != 0)
					{
						if (num2 == 1)
						{
							num2 = 7;
							ProximaLinhaIndice = 3;
						}
						ProximaLinhaIndice = num3;
					}
					num3++;
				}
				while (num3 <= 55);
				if (ProximaLinhaIndice != 57)
				{
					ProximaLinhaIndice++;
				}
				else
				{
					ProximaLinhaIndice = 4;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void LeDadosDoIndiceDoIndiceEletrosul(ref Declaracoes2.StructureIndiceRelatEletroSul[] mIndiceRelatorio)
	{
		checked
		{
			try
			{
				Microsoft.Office.Interop.Excel.Application oExcelNew = null;
				Worksheet oSheet = null;
				int num = 0;
				if (!ExcFuncoesExcel.VerificaExisteSheet(ref oExcelNew, ref oSheet, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1667])))
				{
					return;
				}
				string text = "";
				int num2 = 3;
				do
				{
					text = "A" + Conversions.ToString(num2);
					string sFolha = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
					text = "C" + Conversions.ToString(num2);
					string text2 = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
					if (Operators.CompareString(text2, "", TextCompare: true) == 0)
					{
						break;
					}
					num++;
					mIndiceRelatorio = (Declaracoes2.StructureIndiceRelatEletroSul[])Utils.CopyArray(mIndiceRelatorio, new Declaracoes2.StructureIndiceRelatEletroSul[num + 1]);
					mIndiceRelatorio[num].sFolha = sFolha;
					mIndiceRelatorio[num].sDescricao = text2;
					num2++;
				}
				while (num2 <= 55);
				int num3 = 3;
				do
				{
					text = "G" + Conversions.ToString(num3);
					string sFolha2 = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
					text = "I" + Conversions.ToString(num3);
					string text3 = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
					if (Operators.CompareString(text3, "", TextCompare: true) != 0)
					{
						num++;
						mIndiceRelatorio = (Declaracoes2.StructureIndiceRelatEletroSul[])Utils.CopyArray(mIndiceRelatorio, new Declaracoes2.StructureIndiceRelatEletroSul[num + 1]);
						mIndiceRelatorio[num].sFolha = sFolha2;
						mIndiceRelatorio[num].sDescricao = text3;
						num3++;
						continue;
					}
					break;
				}
				while (num3 <= 55);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void EncontraProximaPagina(ref string sPaginaInicio)
	{
		checked
		{
			try
			{
				Microsoft.Office.Interop.Excel.Application oExcelNew = null;
				Worksheet oSheet = null;
				if (!ExcFuncoesExcel.VerificaExisteSheet(ref oExcelNew, ref oSheet, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1667])))
				{
					return;
				}
				string text = "";
				int num = 3;
				int num2;
				do
				{
					text = "A" + Conversions.ToString(num);
					num2 = 1;
					if (Operators.CompareString(clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))).Trim(), "", TextCompare: true) != 0)
					{
						sPaginaInicio = Conversions.ToString(Conversions.ToInteger(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
					}
					num++;
				}
				while (num <= 55);
				int num3 = 3;
				do
				{
					text = "G" + Conversions.ToString(num3);
					if (Operators.CompareString(clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))).Trim(), "", TextCompare: true) != 0)
					{
						if (num2 == 1)
						{
							num2 = 7;
						}
						sPaginaInicio = Conversions.ToString(Conversions.ToInteger(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
					}
					num3++;
				}
				while (num3 <= 55);
				sPaginaInicio = Conversions.ToString(Conversions.ToDouble(sPaginaInicio) + 1.0);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void CriaMatrizFiacaoBornes_Excel_Sul(DeclaracoesFiacao.structureRelFiacao[] mFiacao, string sRelatorio, ref string sPainel, frmRelatorio_Fiacao_Excel.ConfRelelatorioExcel ConfRel, ref string sPaginaInicio, ref Declaracoes2.StructureIndiceRelatEletroSul[] mIndiceRelatorio, bool bAddCor)
	{
		checked
		{
			try
			{
				Microsoft.Office.Interop.Excel.Application oExcelNew = null;
				Worksheet oSheet = null;
				string oNomeSheet = DeclaracoesGeral.mMensagem[1, 924].ToString().ToUpper();
				string text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1081], " "), sPainel));
				int num = 75;
				int num2 = 0;
				string sPagina = sPaginaInicio;
				List<string> lSheetArea = new List<string>();
				string sLinIni = Conversions.ToString(1);
				List<int> list = new List<int>();
				if (!ExcFuncoesExcel.VerificaExisteSheet(ref oExcelNew, ref oSheet, oNomeSheet))
				{
					ExcFuncoesExcel.VerificaExcel(ref oExcelNew, ref oSheet, oNomeSheet);
				}
				ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
				((_Worksheet)oSheet).get_Range((object)"A1", (object)"Z10000").EntireRow.Delete(RuntimeHelpers.GetObjectValue(Missing.Value));
				oSheet.Cells.ClearComments();
				ExcFuncoesExcel.ApagaFigura(oNomeSheet);
				long num3 = 1L;
				int num4 = 1;
				int iLinhaRelatorio = (int)Math.Round(ConfRel.LinhasPorPagina * 2.0 - 2.0);
				string text2 = "";
				text2 = "A1:A" + Conversions.ToString(ConfRel.LinhasPorPagina * 2.0);
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 8;
				mFiacao[0].Terminal = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1156]);
				mFiacao[0].Disp1 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1157]);
				mFiacao[0].Term1 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1156]);
				mFiacao[0].Disp2 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1157]);
				mFiacao[0].Term2 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1156]);
				mFiacao[0].Cor12 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 782]);
				mFiacao[0].Secao12 = "mm²";
				mFiacao[0].Pagina12 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 783]);
				text2 = "A1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 6;
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
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 6;
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
				text2 = "A1:N" + Conversions.ToString(ConfRel.LinhasPorPagina * 2.0 - 6.0);
				ExcFuncoesExcel.CriaLinhasPontilhadaInterna(ref oSheet, text2);
				int iLinhaRelatorio2 = (int)num3;
				CriaCabecalhoBorneE_SUL(ref oSheet, ref iLinhaRelatorio2, text);
				num3 = iLinhaRelatorio2;
				num = ExcFuncoesExcel.EncontraZoomPagina(ref oExcelNew, ref oSheet);
				ExcFuncoesExcel.FormataPagina(ref oExcelNew, ref oSheet, num);
				iLinhaRelatorio2 = (int)num3;
				CriaTituloBorneE_SUL(ref oSheet, "A", ref iLinhaRelatorio2);
				num3 = iLinhaRelatorio2;
				string sDispositivo = "";
				string text3 = "A";
				string text4 = "";
				long num5 = num3;
				long num6 = num3;
				DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mFiacao);
				DeclaracoesGeral._uscPagina.pbIniciar();
				oExcelNew.ScreenUpdating = false;
				int num7 = 1;
				int num8 = Information.UBound(mFiacao);
				for (int i = 1; i <= num8; i++)
				{
					num7++;
					if (num7 > 15)
					{
						oExcelNew.ScreenUpdating = true;
						text4 = "A" + Conversions.ToString(num3);
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
					text4 = text3 + Conversions.ToString(num3 + 5L);
					((_Worksheet)oSheet).get_Range((object)text4, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
					if (Operators.CompareString(mFiacao[i - 1].Tag, "", TextCompare: true) != 0)
					{
						sDispositivo = "";
						string text5 = "";
						if (!ConfRel.bPagina)
						{
							sDispositivo = mFiacao[i - 1].Tag;
						}
						if (ConfRel.bPagina)
						{
							text5 = Conversions.ToString(Relatorios_FiacaoEXCEL.BuscaPaginasUsadas(mFiacao, mFiacao[i - 1].Tag));
							sDispositivo = mFiacao[i - 1].Tag + ConfRel.Prefixo + text5 + ConfRel.Sufixo;
						}
						Relatorios_FiacaoEXCEL_Sul.AdicionaDispositivoMatrizDeIndices(ref mIndiceRelatorio, sPagina, sDispositivo);
						if ((double)num5 > (double)(num4 - 1) * (ConfRel.LinhasPorPagina * 2.0) + 7.0)
						{
							text2 = ((Operators.CompareString(text3, "A", TextCompare: true) == 0) ? ("A" + Conversions.ToString(num5) + ":G" + Conversions.ToString(num6 - 1L)) : ("H" + Conversions.ToString(num5) + ":N" + Conversions.ToString(num6 - 1L)));
							ExcFuncoesExcel.CriaLinhasExternaSimles(ref oSheet, text2, bCompleto: true);
						}
						string sColuna = text3;
						iLinhaRelatorio2 = (int)num3;
						CriaSubTituloBorneE_SUL(ref oSheet, sColuna, ref iLinhaRelatorio2, sDispositivo);
						num3 = iLinhaRelatorio2;
						num5 = num3;
						num6 = num3;
					}
					if (Operators.CompareString(text3, "A", TextCompare: true) != 0)
					{
						if (mFiacao[i].TipoBorne != 0)
						{
							text2 = "H" + Conversions.ToString(num3) + ":H" + Conversions.ToString(num3 + 3L);
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Terminal));
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						}
						else
						{
							text2 = "H" + Conversions.ToString(num3) + ":H" + Conversions.ToString(num3 + 1L);
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Terminal));
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						}
						text2 = "J" + Conversions.ToString(num3) + ":J" + Conversions.ToString(num3 + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Disp1));
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						text2 = "K" + Conversions.ToString(num3) + ":K" + Conversions.ToString(num3 + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Term1));
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						text2 = "L" + Conversions.ToString(num3) + ":L" + Conversions.ToString(num3 + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Disp2));
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						text2 = "M" + Conversions.ToString(num3) + ":M" + Conversions.ToString(num3 + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Term2));
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						text2 = "N" + Conversions.ToString(num3) + ":N" + Conversions.ToString(num3 + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						if (!bAddCor)
						{
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Secao12));
						}
						else
						{
							string text6 = mFiacao[i].Secao12 + "/" + mFiacao[i].Cor12;
							if (Operators.CompareString(text6, "/", TextCompare: true) == 0)
							{
								text6 = "";
							}
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + text6));
						}
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						text2 = "H" + Conversions.ToString(num3) + ":N" + Conversions.ToString(num3 + 1L);
						ExcFuncoesExcel.CriaLinhasPontilhadaInterna(ref oSheet, text2);
						if (Operators.CompareString(mFiacao[i].Jumper, "", TextCompare: true) != 0)
						{
							if (Operators.CompareString(mFiacao[i].Jumper, "D", TextCompare: true) == 0)
							{
								text2 = "I" + Conversions.ToString(num3 + 1L);
								ExcFuncoesExcel.SetarCorCelula(ref oSheet, text2);
							}
							if (Operators.CompareString(mFiacao[i].Jumper, "UD", TextCompare: true) == 0)
							{
								text2 = "I" + Conversions.ToString(num3) + ":I" + Conversions.ToString(num3 + 1L);
								ExcFuncoesExcel.SetarCorCelula(ref oSheet, text2);
							}
							if (mFiacao[i].TipoBorne != 1)
							{
								if (Operators.CompareString(mFiacao[i].Jumper, "U", TextCompare: true) == 0)
								{
									text2 = "I" + Conversions.ToString(num3);
									ExcFuncoesExcel.SetarCorCelula(ref oSheet, text2);
								}
							}
							else if (Operators.CompareString(mFiacao[i].Jumper, "U", TextCompare: true) == 0)
							{
								text2 = "I" + Conversions.ToString(num3) + ":I" + Conversions.ToString(num3 + 1L);
								ExcFuncoesExcel.SetarCorCelula(ref oSheet, text2);
							}
						}
						num3 += 2L;
						num6 = num3;
						if (mFiacao[i].TipoBorne == 1)
						{
							text2 = "H" + Conversions.ToString(num3) + ":H" + Conversions.ToString(num3 + 1L);
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Terminal));
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
							text2 = "J" + Conversions.ToString(num3) + ":J" + Conversions.ToString(num3 + 1L);
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Disp3));
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
							text2 = "K" + Conversions.ToString(num3) + ":K" + Conversions.ToString(num3 + 1L);
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Term3));
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
							text2 = "L" + Conversions.ToString(num3) + ":L" + Conversions.ToString(num3 + 1L);
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Disp4));
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
							text2 = "M" + Conversions.ToString(num3) + ":M" + Conversions.ToString(num3 + 1L);
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Term4));
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
							text2 = "N" + Conversions.ToString(num3) + ":N" + Conversions.ToString(num3 + 1L);
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Secao34));
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
							text2 = "H" + Conversions.ToString(num3) + ":N" + Conversions.ToString(num3 + 1L);
							ExcFuncoesExcel.CriaLinhasPontilhadaInterna(ref oSheet, text2);
							if (Operators.CompareString(mFiacao[i].Jumper, "", TextCompare: true) != 0)
							{
								if (Operators.CompareString(mFiacao[i].Jumper, "U", TextCompare: true) == 0)
								{
									text2 = "I" + Conversions.ToString(num3);
									ExcFuncoesExcel.SetarCorCelula(ref oSheet, text2);
								}
								if (Operators.CompareString(mFiacao[i].Jumper, "D", TextCompare: true) == 0)
								{
									text2 = "I" + Conversions.ToString(num3) + ":I" + Conversions.ToString(num3 + 1L);
									ExcFuncoesExcel.SetarCorCelula(ref oSheet, text2);
								}
								if (Operators.CompareString(mFiacao[i].Jumper, "UD", TextCompare: true) == 0)
								{
									text2 = "I" + Conversions.ToString(num3) + ":I" + Conversions.ToString(num3 + 1L);
									ExcFuncoesExcel.SetarCorCelula(ref oSheet, text2);
								}
							}
							num3 += 2L;
							num6 = num3;
						}
					}
					else
					{
						if (mFiacao[i].TipoBorne != 0)
						{
							text2 = "A" + Conversions.ToString(num3) + ":A" + Conversions.ToString(num3 + 3L);
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Terminal));
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						}
						else
						{
							text2 = "A" + Conversions.ToString(num3) + ":A" + Conversions.ToString(num3 + 1L);
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Terminal));
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						}
						text2 = "C" + Conversions.ToString(num3) + ":C" + Conversions.ToString(num3 + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Disp1));
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						text2 = "D" + Conversions.ToString(num3) + ":D" + Conversions.ToString(num3 + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Term1));
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						text2 = "E" + Conversions.ToString(num3) + ":E" + Conversions.ToString(num3 + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Disp2));
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						text2 = "F" + Conversions.ToString(num3) + ":F" + Conversions.ToString(num3 + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Term2));
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						text2 = "G" + Conversions.ToString(num3) + ":G" + Conversions.ToString(num3 + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						if (!bAddCor)
						{
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Secao12));
						}
						else
						{
							string text7 = mFiacao[i].Secao12 + "/" + mFiacao[i].Cor12;
							if (Operators.CompareString(text7, "/", TextCompare: true) == 0)
							{
								text7 = "";
							}
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + text7));
						}
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						if (Operators.CompareString(mFiacao[i].Jumper, "", TextCompare: true) != 0)
						{
							if (Operators.CompareString(mFiacao[i].Jumper, "D", TextCompare: true) == 0)
							{
								text2 = "B" + Conversions.ToString(num3 + 1L);
								ExcFuncoesExcel.SetarCorCelula(ref oSheet, text2);
							}
							if (Operators.CompareString(mFiacao[i].Jumper, "UD", TextCompare: true) == 0)
							{
								text2 = "B" + Conversions.ToString(num3) + ":B" + Conversions.ToString(num3 + 1L);
								ExcFuncoesExcel.SetarCorCelula(ref oSheet, text2);
							}
							if (mFiacao[i].TipoBorne != 1)
							{
								if (Operators.CompareString(mFiacao[i].Jumper, "U", TextCompare: true) == 0)
								{
									text2 = "B" + Conversions.ToString(num3);
									ExcFuncoesExcel.SetarCorCelula(ref oSheet, text2);
								}
							}
							else if (Operators.CompareString(mFiacao[i].Jumper, "U", TextCompare: true) == 0)
							{
								text2 = "B" + Conversions.ToString(num3) + ":B" + Conversions.ToString(num3 + 1L);
								ExcFuncoesExcel.SetarCorCelula(ref oSheet, text2);
							}
						}
						text2 = "A" + Conversions.ToString(num3) + ":G" + Conversions.ToString(num3 + 1L);
						ExcFuncoesExcel.CriaLinhasPontilhadaInterna(ref oSheet, text2);
						num3 += 2L;
						num6 = num3;
						if (mFiacao[i].TipoBorne == 1)
						{
							text2 = "A" + Conversions.ToString(num3) + ":A" + Conversions.ToString(num3 + 1L);
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Terminal));
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
							text2 = "C" + Conversions.ToString(num3) + ":C" + Conversions.ToString(num3 + 1L);
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Disp3));
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
							text2 = "D" + Conversions.ToString(num3) + ":D" + Conversions.ToString(num3 + 1L);
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Term3));
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
							text2 = "E" + Conversions.ToString(num3) + ":E" + Conversions.ToString(num3 + 1L);
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Disp4));
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
							text2 = "F" + Conversions.ToString(num3) + ":F" + Conversions.ToString(num3 + 1L);
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Term4));
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
							text2 = "G" + Conversions.ToString(num3) + ":G" + Conversions.ToString(num3 + 1L);
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
							if (!bAddCor)
							{
								((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[i].Secao34));
							}
							else
							{
								string text8 = mFiacao[i].Secao34 + "/" + mFiacao[i].Cor34;
								if (Operators.CompareString(text8, "/", TextCompare: true) == 0)
								{
									text8 = "";
								}
								((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + text8));
							}
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
							if (Operators.CompareString(mFiacao[i].Jumper, "", TextCompare: true) != 0)
							{
								if (Operators.CompareString(mFiacao[i].Jumper, "U", TextCompare: true) == 0)
								{
									text2 = "B" + Conversions.ToString(num3);
									ExcFuncoesExcel.SetarCorCelula(ref oSheet, text2);
								}
								if (Operators.CompareString(mFiacao[i].Jumper, "D", TextCompare: true) == 0)
								{
									text2 = "B" + Conversions.ToString(num3) + ":B" + Conversions.ToString(num3 + 1L);
									ExcFuncoesExcel.SetarCorCelula(ref oSheet, text2);
								}
								if (Operators.CompareString(mFiacao[i].Jumper, "UD", TextCompare: true) == 0)
								{
									text2 = "B" + Conversions.ToString(num3) + ":B" + Conversions.ToString(num3 + 1L);
									ExcFuncoesExcel.SetarCorCelula(ref oSheet, text2);
								}
							}
							text2 = "A" + Conversions.ToString(num3) + ":G" + Conversions.ToString(num3 + 1L);
							ExcFuncoesExcel.CriaLinhasPontilhadaInterna(ref oSheet, text2);
							num3 += 2L;
							num6 = num3;
						}
					}
					iLinhaRelatorio = (int)Math.Round((double)num4 * (ConfRel.LinhasPorPagina * 2.0) - 5.0);
					bool flag = false;
					if (i < Information.UBound(mFiacao) - 1)
					{
						bool flag2 = false;
						if (Operators.CompareString(mFiacao[i].Tag, "", TextCompare: true) != 0)
						{
							flag2 = true;
						}
						if (mFiacao[i + 1].TipoBorne != 0)
						{
							if (num3 + 4L <= iLinhaRelatorio)
							{
								if (flag2 && num3 + 6L > iLinhaRelatorio)
								{
									flag = true;
								}
							}
							else
							{
								flag = true;
							}
						}
						else if (num3 + 2L <= iLinhaRelatorio)
						{
							if (flag2 && num3 + 4L > iLinhaRelatorio)
							{
								flag = true;
							}
						}
						else
						{
							flag = true;
						}
					}
					num6 = num3;
					if ((num3 >= iLinhaRelatorio) | flag)
					{
						if (Operators.CompareString(text3, "A", TextCompare: true) != 0)
						{
							if (Operators.CompareString(text3, "H", TextCompare: true) == 0)
							{
								text2 = "A" + Conversions.ToString((double)num4 * (ConfRel.LinhasPorPagina * 2.0) + 1.0) + ":A" + Conversions.ToString((double)(num4 + 1) * (ConfRel.LinhasPorPagina * 2.0));
								((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 8;
								text2 = "A" + Conversions.ToString((double)num4 * (ConfRel.LinhasPorPagina * 2.0) + 1.0) + ":N" + Conversions.ToString((double)(num4 + 1) * (ConfRel.LinhasPorPagina * 2.0) - 6.0);
								ExcFuncoesExcel.CriaLinhasPontilhadaInterna(ref oSheet, text2);
								text2 = "H" + Conversions.ToString(num5) + ":N" + Conversions.ToString(num6 - 1L);
								ExcFuncoesExcel.CriaLinhasExternaSimles(ref oSheet, text2, bCompleto: true);
								text3 = "A";
								num3 = (long)Math.Round((double)num4 * (ConfRel.LinhasPorPagina * 2.0) + 1.0);
								iLinhaRelatorio2 = (int)num3;
								CriaCabecalhoBorneE_SUL(ref oSheet, ref iLinhaRelatorio2, text);
								num3 = iLinhaRelatorio2;
								text4 = text3 + Conversions.ToString(num3 + 4L);
								((_Worksheet)oSheet).get_Range((object)text4, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
								string sColuna2 = text3;
								iLinhaRelatorio2 = (int)num3;
								CriaTituloBorneE_SUL(ref oSheet, sColuna2, ref iLinhaRelatorio2);
								num3 = iLinhaRelatorio2;
								if (i < Information.UBound(mFiacao) - 1 && Operators.CompareString(mFiacao[i].Tag, "", TextCompare: true) == 0)
								{
									string sColuna3 = text3;
									iLinhaRelatorio2 = (int)num3;
									CriaSubTituloBorneE_SUL(ref oSheet, sColuna3, ref iLinhaRelatorio2, sDispositivo);
									num3 = iLinhaRelatorio2;
								}
								num5 = num3;
								num6 = num3;
								num4++;
								sPagina = sPaginaInicio;
								Relatorios_FiacaoEXCEL_Sul.AdicionaDispositivoMatrizDeIndices(ref mIndiceRelatorio, sPagina, sDispositivo);
							}
						}
						else
						{
							text2 = "A" + Conversions.ToString(num5) + ":G" + Conversions.ToString(num6 - 1L);
							ExcFuncoesExcel.CriaLinhasExternaSimles(ref oSheet, text2, bCompleto: true);
							Relatorios_ExcelComum_EletroSul.CriarodapeFiacaoELSBornes(ref oSheet, ref lSheetArea, (int)num3, sPainel, sLinIni, ref iLinhaRelatorio, iLinhaRelatorio, bFormacao: true, bfuncao: true, bDoc: false, bOpcional: false, mIndiceRelatorio[Information.UBound(mIndiceRelatorio)].sFolha, ConfRel, 26, 3);
							list.Add((int)num3);
							sPagina = sPaginaInicio;
							Relatorios_FiacaoEXCEL_Sul.AdicionaDispositivoMatrizDeIndices(ref mIndiceRelatorio, sPagina, sDispositivo);
							sPaginaInicio = Conversions.ToString(Conversions.ToInteger(sPaginaInicio) + 1);
							text3 = "H";
							num3 = (long)Math.Round((double)(num4 - 1) * (ConfRel.LinhasPorPagina * 2.0) + 3.0);
							string sColuna4 = text3;
							iLinhaRelatorio2 = (int)num3;
							CriaTituloBorneE_SUL(ref oSheet, sColuna4, ref iLinhaRelatorio2);
							num3 = iLinhaRelatorio2;
							if (i < Information.UBound(mFiacao) - 1 && Operators.CompareString(mFiacao[i].Tag, "", TextCompare: true) == 0)
							{
								string sColuna5 = text3;
								iLinhaRelatorio2 = (int)num3;
								CriaSubTituloBorneE_SUL(ref oSheet, sColuna5, ref iLinhaRelatorio2, sDispositivo);
								num3 = iLinhaRelatorio2;
							}
							num6 = num3;
							num5 = num3;
						}
					}
					num2++;
					if (((double)num2 >= ConfRel.LinhasPorPagina * 2.0 - 1.0) | (i == Information.UBound(mFiacao)))
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
					Relatorios_ExcelComum_EletroSul.CriarodapeFiacaoELSBornes(ref oSheet, ref lSheetArea, (int)num3, sPainel, sLinIni, ref iLinhaRelatorio, iLinhaRelatorio, bFormacao: true, bfuncao: true, bDoc: false, bOpcional: false, mIndiceRelatorio[Information.UBound(mIndiceRelatorio)].sFolha, ConfRel, 26, 3);
					list.Add((int)num3);
				}
				sPaginaInicio = Conversions.ToString(Conversions.ToInteger(sPaginaInicio) + 1);
				text2 = "A" + Conversions.ToString(num5) + ":G" + Conversions.ToString(num6 - 1L);
				if (Operators.CompareString(text3, "H", TextCompare: true) == 0)
				{
					text2 = "H" + Conversions.ToString(num5) + ":N" + Conversions.ToString(num6 - 1L);
				}
				ExcFuncoesExcel.CriaLinhasExternaSimles(ref oSheet, text2, bCompleto: true);
				text2 = "A1:N" + Conversions.ToString((double)num4 * (ConfRel.LinhasPorPagina * 2.0));
				ExcFuncoesExcel.CriaLinhasExternaSimles(ref oSheet, text2, bCompleto: true);
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
				ExcFuncoesExcel.AtivaView(ref oExcelNew, bPreview: false);
				int num9 = 0;
				int num10 = num4 - 1;
				for (int j = 1; j <= num10; j++)
				{
					num9 = (int)Math.Round((double)j * (ConfRel.LinhasPorPagina * 2.0) + 1.0);
					text4 = "A" + Conversions.ToString(num9);
					((_Worksheet)oSheet).get_Range((object)text4, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
					oSheet.HPageBreaks.Add(((_Worksheet)oSheet).get_Range((object)text4, RuntimeHelpers.GetObjectValue(Missing.Value)));
				}
				oSheet.PageSetup.Zoom = num;
				DeclaracoesGeral._uscPagina.pbFim();
				oExcelNew.ScreenUpdating = true;
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

	public static void CriaCabecalhoBorneE_SUL(ref Worksheet oSheet, ref int iLinhaRelatorio, string sDispositivo)
	{
		checked
		{
			try
			{
				string text = "";
				text = "A" + Conversions.ToString(iLinhaRelatorio) + ":N" + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 12;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)sDispositivo.ToUpper());
				iLinhaRelatorio += 2;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void CriaTituloBorneE_SUL(ref Worksheet oSheet, string sColuna, ref int iLinhaRelatorio)
	{
		checked
		{
			try
			{
				string text = "";
				if (Operators.CompareString(sColuna, "A", TextCompare: true) != 0)
				{
					text = "H" + Conversions.ToString(iLinhaRelatorio) + ":I" + Conversions.ToString(iLinhaRelatorio + 1);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'DE");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "J" + Conversions.ToString(iLinhaRelatorio) + ":K" + Conversions.ToString(iLinhaRelatorio + 1);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'PARA: 1");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "L" + Conversions.ToString(iLinhaRelatorio) + ":M" + Conversions.ToString(iLinhaRelatorio + 1);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'PARA: 2");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "N" + Conversions.ToString(iLinhaRelatorio) + ":N" + Conversions.ToString(iLinhaRelatorio + 3);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'OBS:");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					iLinhaRelatorio += 2;
					text = "H" + Conversions.ToString(iLinhaRelatorio) + ":I" + Conversions.ToString(iLinhaRelatorio + 1);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'TERM.");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "J" + Conversions.ToString(iLinhaRelatorio) + ":J" + Conversions.ToString(iLinhaRelatorio + 1);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'DISP.");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "K" + Conversions.ToString(iLinhaRelatorio) + ":K" + Conversions.ToString(iLinhaRelatorio + 1);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'TERM.");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "L" + Conversions.ToString(iLinhaRelatorio) + ":L" + Conversions.ToString(iLinhaRelatorio + 1);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'DISP.");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "M" + Conversions.ToString(iLinhaRelatorio) + ":M" + Conversions.ToString(iLinhaRelatorio + 1);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'TERM.");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "H" + Conversions.ToString(iLinhaRelatorio - 3) + ":N" + Conversions.ToString(iLinhaRelatorio + 1);
				}
				else
				{
					text = "A" + Conversions.ToString(iLinhaRelatorio) + ":B" + Conversions.ToString(iLinhaRelatorio + 1);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'DE");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "C" + Conversions.ToString(iLinhaRelatorio) + ":D" + Conversions.ToString(iLinhaRelatorio + 1);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'PARA: 1");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "E" + Conversions.ToString(iLinhaRelatorio) + ":F" + Conversions.ToString(iLinhaRelatorio + 1);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'PARA: 2");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "G" + Conversions.ToString(iLinhaRelatorio) + ":G" + Conversions.ToString(iLinhaRelatorio + 3);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'OBS:");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					iLinhaRelatorio += 2;
					text = "A" + Conversions.ToString(iLinhaRelatorio) + ":B" + Conversions.ToString(iLinhaRelatorio + 1);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'TERM.");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "C" + Conversions.ToString(iLinhaRelatorio) + ":C" + Conversions.ToString(iLinhaRelatorio + 1);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'DISP.");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "D" + Conversions.ToString(iLinhaRelatorio) + ":D" + Conversions.ToString(iLinhaRelatorio + 1);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'TERM.");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "E" + Conversions.ToString(iLinhaRelatorio) + ":E" + Conversions.ToString(iLinhaRelatorio + 1);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'DISP.");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "F" + Conversions.ToString(iLinhaRelatorio) + ":F" + Conversions.ToString(iLinhaRelatorio + 1);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'TERM.");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 11;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "A" + Conversions.ToString(iLinhaRelatorio - 3) + ":G" + Conversions.ToString(iLinhaRelatorio + 1);
				}
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

	public static void CriaSubTituloBorneE_SUL(ref Worksheet oSheet, string sColuna, ref int iLinhaRelatorio, string sDispositivo)
	{
		checked
		{
			try
			{
				string text = "";
				if (Operators.CompareString(sColuna, "A", TextCompare: true) != 0)
				{
					text = "H" + Conversions.ToString(iLinhaRelatorio) + ":N" + Conversions.ToString(iLinhaRelatorio + 1);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
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

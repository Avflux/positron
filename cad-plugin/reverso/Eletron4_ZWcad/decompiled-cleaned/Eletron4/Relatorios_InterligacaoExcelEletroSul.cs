using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class Relatorios_InterligacaoExcelEletroSul
{
	public struct structureRelInterligacao
	{
		public string TagRegua;

		public string Jumper;

		public string TagCabo_Veia;

		public string Formacao;

		public string Destino;

		public string Régua;

		public string Borne;

		public string Funcao;

		public string Documento;

		public int TipoBorne;

		public string Trajeto;
	}

	public struct structureReguasInterligacao
	{
		public string sRegua;

		public string sNomeSheet;
	}

	public static void CriaMatrizInterligacaoExcel(ref List<string> lSheetArea, structureRelInterligacao[] mInterligacao, string sPainel, int QuantLinhasMax, bool bFormacao, bool bFuncao, bool bDocumento, bool bReserva, string sOpcional, bool bOpcional, bool bTrajeto, DeclaracoesInterligacao.reservaRI[] mAterrados, DeclaracoesInterligacao.reservaRI[] mNaoAterrados, string sMaxColuna, string sMaxQuebra, ref Declaracoes2.StructureIndiceRelatEletroSul[] mIndiceRel, bool bRodape, frmRelatorio_InterligacaoEletroSul_Excel.ConfRelelatorioExcel ConfRelinterligacao)
	{
		checked
		{
			try
			{
				Microsoft.Office.Interop.Excel.Application oExcelNew = null;
				Worksheet oSheet = null;
				int num = QuantLinhasMax - 3;
				string text = "";
				int num2 = 0;
				int num3 = 0;
				structureReguasInterligacao[] array = new structureReguasInterligacao[1];
				string sNomeSheet = "";
				int num4 = Information.UBound(mInterligacao);
				for (int i = 1; i <= num4; i++)
				{
					if (mInterligacao[i].TipoBorne == -10)
					{
						if (i > 1)
						{
							num3++;
							array = (structureReguasInterligacao[])Utils.CopyArray(array, new structureReguasInterligacao[num3 + 1]);
							array[num3].sRegua = text;
							array[num3].sNomeSheet = sNomeSheet;
						}
						text = mInterligacao[i].TagRegua;
					}
					if (Operators.CompareString(mInterligacao[i].TagRegua, "", TextCompare: true) != 0)
					{
						sNomeSheet = DeclaracoesGeral.mMensagem[1, 984].ToString().ToUpper() + " " + text + "(1-" + mInterligacao[i].TagRegua + ")";
					}
				}
				num3++;
				array = (structureReguasInterligacao[])Utils.CopyArray(array, new structureReguasInterligacao[num3 + 1]);
				array[num3].sRegua = text;
				array[num3].sNomeSheet = sNomeSheet;
				int num5 = 0;
				if (bReserva)
				{
					num5 = Information.UBound(mAterrados) + Information.UBound(mNaoAterrados);
				}
				DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mInterligacao) + num5;
				DeclaracoesGeral._uscPagina.pbIniciar();
				text = "";
				int num6 = 0;
				structureRelInterligacao[] array2 = new structureRelInterligacao[1];
				int num7 = Information.UBound(mInterligacao);
				int num8 = 1;
				while (true)
				{
					if (num8 <= num7)
					{
						if (mInterligacao[num8].TipoBorne != -10)
						{
							num6++;
							array2 = (structureRelInterligacao[])Utils.CopyArray(array2, new structureRelInterligacao[num6 + 1]);
							array2[num6] = mInterligacao[num8];
						}
						else
						{
							if (Information.UBound(array2) > 0)
							{
								sNomeSheet = BuscaNomeDaSheet(text, array);
								desenhaMreguaELS(sNomeSheet, ref lSheetArea, text, array2, QuantLinhasMax, bFormacao, bFuncao, bDocumento, bTrajeto, sOpcional, bOpcional, sMaxColuna, sMaxQuebra, ref mIndiceRel, bRodape, ConfRelinterligacao);
								if (DeclaracoesGeral.bPararRelatorio)
								{
									break;
								}
							}
							num6 = 0;
							array2 = new structureRelInterligacao[1];
							text = mInterligacao[num8].TagRegua;
						}
						if (num8 == Information.UBound(mInterligacao))
						{
							sNomeSheet = BuscaNomeDaSheet(text, array);
							desenhaMreguaELS(sNomeSheet, ref lSheetArea, text, array2, QuantLinhasMax, bFormacao, bFuncao, bDocumento, bTrajeto, sOpcional, bOpcional, sMaxColuna, sMaxQuebra, ref mIndiceRel, bRodape, ConfRelinterligacao);
						}
						if (DeclaracoesGeral.bPararRelatorio)
						{
							break;
						}
						DeclaracoesGeral._uscPagina.pbPasso();
						num8++;
						continue;
					}
					if (!bReserva)
					{
						break;
					}
					string text2 = "";
					if (Information.UBound(mAterrados) > 0)
					{
						text2 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1434]);
					}
					if (Operators.CompareString(text2, "", TextCompare: true) != 0)
					{
						ExcFuncoesExcel.VerificaExcel(ref oExcelNew, ref oSheet, text2);
						num2 = Information.UBound(mIndiceRel) + 1;
						mIndiceRel = (Declaracoes2.StructureIndiceRelatEletroSul[])Utils.CopyArray(mIndiceRel, new Declaracoes2.StructureIndiceRelatEletroSul[num2 + 1]);
						mIndiceRel[num2].sFolha = Conversions.ToString(Conversions.ToDouble(mIndiceRel[Information.UBound(mIndiceRel) - 1].sFolha) + 1.0);
						mIndiceRel[num2].sDescricao = text2;
						int num9 = 1;
						if (Information.UBound(mAterrados) > 0)
						{
							qgu31jj7K1(ref oExcelNew, ref oSheet, ref lSheetArea, ref num9, mAterrados, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1434]), ref num, QuantLinhasMax, ref mIndiceRel, ConfRelinterligacao);
						}
						ExcFuncoesExcel.EncontraZoomPagina(ref oExcelNew, ref oSheet);
						DeclaracoesGeral._uscPagina.pbPasso();
					}
					break;
				}
				DeclaracoesGeral._uscPagina.pbFim();
				ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				DeclaracoesGeral._uscPagina.pbFim();
				ProjectData.ClearProjectError();
			}
		}
	}

	public static string BuscaNomeDaSheet(string sRegua, structureReguasInterligacao[] sNomeReguas)
	{
		string result = "";
		int num = Information.UBound(sNomeReguas);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (Operators.CompareString(sRegua, sNomeReguas[i].sRegua, TextCompare: true) == 0)
			{
				result = sNomeReguas[i].sNomeSheet;
				break;
			}
		}
		return result;
	}

	public static void desenhaMreguaELS(string sSheet, ref List<string> lSheetArea, string sRegua, structureRelInterligacao[] mRegua, int QuantLinhasMax, bool bFormacao, bool bFuncao, bool bDocumento, bool bTrajeto, string sOpcional, bool bOpcional, string sMaxColuna, string sMaxQuebra, ref Declaracoes2.StructureIndiceRelatEletroSul[] mIndiceRel, bool bRodape, frmRelatorio_InterligacaoEletroSul_Excel.ConfRelelatorioExcel ConfRelinterligacao)
	{
		checked
		{
			try
			{
				Microsoft.Office.Interop.Excel.Application oExcelNew = null;
				Worksheet oSheet = null;
				long num = 1L;
				long num2 = 1L;
				int num3 = 1;
				string text = Conversions.ToString(1);
				int num4 = 1;
				string text2 = "";
				string text3 = "";
				int num5 = 75;
				ExcFuncoesExcel.VerificaExcel(ref oExcelNew, ref oSheet, sSheet);
				ExcFuncoesExcel.RemoveHPageBreaks(ref oSheet);
				ExcFuncoesExcel.AtivaView(ref oExcelNew, bPreview: false);
				int num6 = 0;
				if (bRodape)
				{
					num6 = 4;
				}
				ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
				NM7355LkAH(ref oSheet, bFormacao, bFuncao, bDocumento, sOpcional, bTrajeto);
				int num7 = (int)num;
				OIX30sQvc4(ref oSheet, ref num7, bFormacao, bFuncao, bDocumento, sOpcional, bTrajeto);
				num = num7;
				num4 = QuantLinhasMax * 2 + 1;
				num++;
				num5 = ExcFuncoesExcel.EncontraZoomPagina(ref oExcelNew, ref oSheet);
				num7 = (int)num;
				a653XZOLxi(ref oSheet, ref num7, sRegua);
				num = num7;
				int num8 = Information.UBound(mIndiceRel) + 1;
				mIndiceRel = (Declaracoes2.StructureIndiceRelatEletroSul[])Utils.CopyArray(mIndiceRel, new Declaracoes2.StructureIndiceRelatEletroSul[num8 + 1]);
				mIndiceRel[num8].sFolha = Conversions.ToString(Conversions.ToDouble(mIndiceRel[Information.UBound(mIndiceRel) - 1].sFolha) + 1.0);
				mIndiceRel[num8].sDescricao = DeclaracoesGeral.mMensagem[1, 984].ToString().ToUpper() + " " + sRegua;
				int num9 = Information.UBound(mRegua);
				int num10 = 1;
				while (true)
				{
					if (num10 <= num9)
					{
						if (num + 4L + num6 >= num4)
						{
							if (bRodape)
							{
								string text4 = text;
								num7 = (int)num;
								EDM3R9Q20T(ref oExcelNew, ref oSheet, ref lSheetArea, sSheet, text4, ref num7, num4, bFormacao, bFuncao, bDocumento, bTrajeto, bOpcional, mIndiceRel[num8].sFolha, ConfRelinterligacao);
								num = num7;
							}
							text2 = "A" + Conversions.ToString(num2) + ":" + sMaxColuna + (num - 1L);
							ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text2, bCompleto: true);
							num3++;
							num = num4;
							num4 = QuantLinhasMax * 2 * num3 + 1;
							text = Conversions.ToString(num);
							num7 = (int)num;
							OIX30sQvc4(ref oSheet, ref num7, bFormacao, bFuncao, bDocumento, sOpcional, bTrajeto);
							num = num7;
							ExcFuncoesExcel.AtuaizaCalculOExcel(ref oExcelNew);
							num++;
							text3 = "A" + Conversions.ToString(num);
							((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
							num7 = (int)num;
							a653XZOLxi(ref oSheet, ref num7, sRegua);
							num = num7;
							num8 = Information.UBound(mIndiceRel) + 1;
							mIndiceRel = (Declaracoes2.StructureIndiceRelatEletroSul[])Utils.CopyArray(mIndiceRel, new Declaracoes2.StructureIndiceRelatEletroSul[num8 + 1]);
							mIndiceRel[num8].sFolha = Conversions.ToString(Conversions.ToDouble(mIndiceRel[Information.UBound(mIndiceRel) - 1].sFolha) + 1.0);
							mIndiceRel[num8].sDescricao = DeclaracoesGeral.mMensagem[1, 984].ToString().ToUpper() + " " + sRegua;
							num2 = num;
						}
						if (DeclaracoesGeral.bPararRelatorio)
						{
							break;
						}
						if (mRegua[num10].TipoBorne != -20)
						{
							if (num10 != Information.UBound(mRegua))
							{
								if (Operators.CompareString(mRegua[num10].TagRegua, mRegua[num10 + 1].TagRegua, TextCompare: true) != 0)
								{
									if (mRegua[num10].TipoBorne != -20)
									{
										num7 = (int)num;
										AdicionaLinhaRelInterligacao(ref oSheet, ref num7, ref mRegua, num10, 0, bFormacao, bFuncao, bDocumento, bTrajeto, sOpcional);
										num = num7;
									}
								}
								else
								{
									num7 = (int)num;
									AdicionaLinhaRelInterligacao(ref oSheet, ref num7, ref mRegua, num10, num10 + 1, bFormacao, bFuncao, bDocumento, bTrajeto, sOpcional);
									num = num7;
								}
								goto IL_0221;
							}
							num7 = (int)num;
							AdicionaLinhaRelInterligacao(ref oSheet, ref num7, ref mRegua, num10, 0, bFormacao, bFuncao, bDocumento, bTrajeto, sOpcional);
							num = num7;
						}
						else if (num10 != Information.UBound(mRegua))
						{
							goto IL_0221;
						}
						while (!DeclaracoesGeral.bPararRelatorio)
						{
							if (num + 4L + num6 < num4 + 1)
							{
								text3 = "A" + Conversions.ToString(num + 10L);
								((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
								num7 = (int)num;
								AdicionaLinhaRelInterligacao(ref oSheet, ref num7, ref mRegua, 0, 0, bFormacao, bFuncao, bDocumento, bTrajeto, sOpcional, bCampoVazio: true);
								num = num7;
								continue;
							}
							goto IL_04d6;
						}
					}
					else
					{
						text3 = "A" + Conversions.ToString(1);
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
						text2 = "A" + Conversions.ToString(num2) + ":" + sMaxColuna + (num - 1L);
						ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text2, bCompleto: true);
						ExcFuncoesExcel.FormataPagina(ref oExcelNew, ref oSheet, num5);
						text3 = "A" + Conversions.ToString(1);
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
					}
					break;
					IL_0221:
					DeclaracoesGeral._uscPagina.pbPasso();
					text3 = "A" + Conversions.ToString(num + 10L);
					((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
					if (!DeclaracoesGeral.bPararRelatorio)
					{
						num10++;
						continue;
					}
					break;
					IL_04d6:
					if (bRodape)
					{
						string text5 = text;
						num7 = (int)num;
						EDM3R9Q20T(ref oExcelNew, ref oSheet, ref lSheetArea, sSheet, text5, ref num7, num4, bFormacao, bFuncao, bDocumento, bTrajeto, bOpcional, mIndiceRel[num8].sFolha, ConfRelinterligacao);
						num = num7;
					}
					goto IL_0221;
				}
				if (DeclaracoesGeral.bPararRelatorio)
				{
					System.Windows.Forms.Application.DoEvents();
				}
				ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
				oExcelNew.ActiveWindow.View = XlWindowView.xlPageBreakPreview;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	private static void qgu31jj7K1(ref Microsoft.Office.Interop.Excel.Application P_0, ref Worksheet P_1, ref List<string> P_2, ref int P_3, DeclaracoesInterligacao.reservaRI[] P_4, string P_5, ref int P_6, int P_7, ref Declaracoes2.StructureIndiceRelatEletroSul[] P_8, frmRelatorio_InterligacaoEletroSul_Excel.ConfRelelatorioExcel P_9)
	{
		checked
		{
			try
			{
				string text = "";
				int num = 1;
				string text2 = Conversions.ToString(1);
				string text3 = "";
				int num2 = 1;
				yFQ3lS2JES(ref P_1, ref P_3, P_5);
				wao3mITsLF(ref P_0, ref P_1, ref P_2, ref P_3, P_5, text2, ref P_6, P_7, _0020: true, _0020: true, _0020: false, _0020: false, P_8[Information.UBound(P_8)].sFolha, P_9);
				text = "A3:K" + Conversions.ToString(P_6 - 1);
				ExcFuncoesExcel.CriaLinhasInterna(ref P_1, text);
				ExcFuncoesExcel.CriaLinhasExterna(ref P_1, text, bCompleto: true);
				int num3 = P_7 * 1 - P_7 + 3;
				int num4 = P_7 * 1 - 2;
				int num5 = Information.UBound(P_4);
				for (int i = 1; i <= num5; i++)
				{
					if (P_3 >= num4)
					{
						num2++;
						num3 = P_7 * num2 - P_7;
						P_3 = num3;
						P_3++;
						num3 = P_7 * num2 - P_7 + 3;
						int num6 = Information.UBound(P_8) + 1;
						P_8 = (Declaracoes2.StructureIndiceRelatEletroSul[])Utils.CopyArray(P_8, new Declaracoes2.StructureIndiceRelatEletroSul[num6 + 1]);
						P_8[num6].sFolha = Conversions.ToString(Conversions.ToDouble(P_8[num6 - 1].sFolha) + 1.0);
						P_8[num6].sDescricao = P_5;
						num++;
						P_6 = P_7 * num;
						if (i <= Information.UBound(P_4))
						{
							yFQ3lS2JES(ref P_1, ref P_3, P_5);
							wao3mITsLF(ref P_0, ref P_1, ref P_2, ref P_3, P_5, text2, ref P_6, P_6, _0020: true, _0020: true, _0020: false, _0020: false, P_8[Information.UBound(P_8)].sFolha, P_9);
						}
						num4 = P_7 * num2 - 2;
					}
					text = "A" + Conversions.ToString(P_3) + ":F" + Conversions.ToString(P_3);
					((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + P_4[i].Tag));
					text = "G" + Conversions.ToString(P_3) + ":I" + Conversions.ToString(P_3);
					((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + P_4[i].sPainelDest));
					text = "J" + Conversions.ToString(P_3) + ":K" + Conversions.ToString(P_3);
					((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + P_4[i].Veias));
					text = "A" + Conversions.ToString(P_3) + ":K" + Conversions.ToString(P_3);
					((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					P_3++;
					text3 = "A" + Conversions.ToString(P_3 + 2);
					((_Worksheet)P_1).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
				}
				int num7 = num + 1;
				for (int j = 1; j <= num7; j++)
				{
					text3 = "A" + Conversions.ToString(P_6 + 3);
					P_1.HPageBreaks.Add(((_Worksheet)P_1).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)));
				}
				text3 = "A" + Conversions.ToString(1);
				((_Worksheet)P_1).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
				P_3++;
				P_0.ActiveWindow.View = XlWindowView.xlPageBreakPreview;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	private static void yFQ3lS2JES(ref Worksheet P_0, ref int P_1, string P_2)
	{
		checked
		{
			try
			{
				string text = "";
				if (P_1 == 1)
				{
					((_Worksheet)P_0).get_Range((object)"A1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 1;
					((_Worksheet)P_0).get_Range((object)"B1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 0.6;
					((_Worksheet)P_0).get_Range((object)"C1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
					((_Worksheet)P_0).get_Range((object)"D1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 0.6;
					((_Worksheet)P_0).get_Range((object)"E1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 1;
					((_Worksheet)P_0).get_Range((object)"F1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
					((_Worksheet)P_0).get_Range((object)"G1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
					((_Worksheet)P_0).get_Range((object)"H1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 20;
					((_Worksheet)P_0).get_Range((object)"I1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
					((_Worksheet)P_0).get_Range((object)"J1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 8.5;
					((_Worksheet)P_0).get_Range((object)"K1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 30;
				}
				text = "A" + Conversions.ToString(P_1) + ":K" + Conversions.ToString(P_1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + P_2.ToUpper()));
				ExcFuncoesExcel.CriaLinhasExterna(ref P_0, text, bCompleto: true);
				text = "A" + Conversions.ToString(P_1 + 1) + ":F" + Conversions.ToString(P_1 + 1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1456]));
				ExcFuncoesExcel.CriaLinhasExterna(ref P_0, text, bCompleto: true);
				text = "G" + Conversions.ToString(P_1 + 1) + ":I" + Conversions.ToString(P_1 + 1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1455]));
				ExcFuncoesExcel.CriaLinhasExterna(ref P_0, text, bCompleto: true);
				text = "J" + Conversions.ToString(P_1 + 1) + ":K" + Conversions.ToString(P_1 + 1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1454]));
				ExcFuncoesExcel.CriaLinhasExterna(ref P_0, text, bCompleto: true);
				text = "A" + Conversions.ToString(P_1) + ":K" + Conversions.ToString(P_1 + 1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				ExcFuncoesExcel.CriaLinhasExterna(ref P_0, text, bCompleto: true);
				P_1 += 2;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void AdicionaLinhaRelInterligacao(ref Worksheet oSheet, ref int iLinhaRelatorio, ref structureRelInterligacao[] mInterligacao, int iIndice1, int iIndice2, bool bFormacao, bool bfuncao, bool bDoc, bool bTrajeto, string sOpcional, bool bCampoVazio = false)
	{
		checked
		{
			try
			{
				string text = "";
				int num = 10;
				text = "A" + Conversions.ToString(iLinhaRelatorio) + ":E" + Conversions.ToString(iLinhaRelatorio + 3);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "A" + Conversions.ToString(iLinhaRelatorio) + ":L" + Conversions.ToString(iLinhaRelatorio + 10);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 9;
				if (mInterligacao[iIndice1].TipoBorne != 1)
				{
					text = "A" + Conversions.ToString(iLinhaRelatorio) + ":A" + Conversions.ToString(iLinhaRelatorio + 3);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				}
				else
				{
					text = "A" + Conversions.ToString(iLinhaRelatorio) + ":A" + Conversions.ToString(iLinhaRelatorio + 1);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					text = "A" + Conversions.ToString(iLinhaRelatorio + 2) + ":A" + Conversions.ToString(iLinhaRelatorio + 3);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				}
				text = "B" + Conversions.ToString(iLinhaRelatorio) + ":B" + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				text = "B" + Conversions.ToString(iLinhaRelatorio + 2) + ":B" + Conversions.ToString(iLinhaRelatorio + 3);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				text = "C" + Conversions.ToString(iLinhaRelatorio) + ":C" + Conversions.ToString(iLinhaRelatorio + 3);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				text = "D" + Conversions.ToString(iLinhaRelatorio) + ":D" + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				text = "D" + Conversions.ToString(iLinhaRelatorio + 2) + ":D" + Conversions.ToString(iLinhaRelatorio + 3);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				if (mInterligacao[iIndice1].TipoBorne != 1)
				{
					text = "E" + Conversions.ToString(iLinhaRelatorio) + ":E" + Conversions.ToString(iLinhaRelatorio + 3);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				}
				else
				{
					text = "E" + Conversions.ToString(iLinhaRelatorio) + ":E" + Conversions.ToString(iLinhaRelatorio + 1);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					text = "E" + Conversions.ToString(iLinhaRelatorio + 2) + ":E" + Conversions.ToString(iLinhaRelatorio + 3);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				}
				text = "A" + Conversions.ToString(iLinhaRelatorio);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"o");
				if (mInterligacao[iIndice1].TipoBorne == 1)
				{
					text = "A" + Conversions.ToString(iLinhaRelatorio + 2);
				}
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"o");
				if (!bCampoVazio)
				{
					text = "C" + Conversions.ToString(iLinhaRelatorio);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mInterligacao[iIndice1].TagRegua));
				}
				text = "E" + Conversions.ToString(iLinhaRelatorio);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"o");
				if (mInterligacao[iIndice1].TipoBorne == 1)
				{
					text = "E" + Conversions.ToString(iLinhaRelatorio + 2);
				}
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"o");
				text = "F" + Conversions.ToString(iLinhaRelatorio) + ":F" + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				if (!bCampoVazio)
				{
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mInterligacao[iIndice1].TagCabo_Veia));
				}
				text = "F" + Conversions.ToString(iLinhaRelatorio + 2) + ":F" + Conversions.ToString(iLinhaRelatorio + 3);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				if (iIndice2 > 0 && !bCampoVazio)
				{
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mInterligacao[iIndice2].TagCabo_Veia));
				}
				num = 7;
				if (bFormacao)
				{
					text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 1);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					if (!bCampoVazio)
					{
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mInterligacao[iIndice1].Formacao));
					}
					text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 2) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 3);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					if (iIndice2 > 0 && !bCampoVazio)
					{
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mInterligacao[iIndice2].Formacao));
					}
					num++;
				}
				text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				if (!bCampoVazio)
				{
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mInterligacao[iIndice1].Destino));
				}
				text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 2) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 3);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				if (iIndice2 > 0 && !bCampoVazio)
				{
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mInterligacao[iIndice2].Destino));
				}
				num++;
				text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				if (!bCampoVazio)
				{
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mInterligacao[iIndice1].Régua));
				}
				text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 2) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 3);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				if (iIndice2 > 0 && !bCampoVazio)
				{
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mInterligacao[iIndice2].Régua));
				}
				num++;
				text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				if (!bCampoVazio)
				{
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mInterligacao[iIndice1].Borne));
				}
				text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 2) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 3);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				if (iIndice2 > 0 && !bCampoVazio)
				{
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mInterligacao[iIndice2].Borne));
				}
				ExcFuncoesExcel.mudaNumeroAsc(num);
				num++;
				if (bDoc)
				{
					if (!((Operators.CompareString(clsTextos.TiraNothing(mInterligacao[iIndice1].Documento), clsTextos.TiraNothing(mInterligacao[iIndice2].Documento), TextCompare: true) == 0) & (Operators.CompareString(clsTextos.TiraNothing(mInterligacao[iIndice1].Documento), "", TextCompare: true) != 0) & (iIndice2 > 0)))
					{
						text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 1);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						if (!bCampoVazio)
						{
							((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mInterligacao[iIndice1].Documento));
						}
						text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 2) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 3);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						if (!bCampoVazio)
						{
							((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mInterligacao[iIndice2].Documento));
						}
					}
					else
					{
						text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 3);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						if (!bCampoVazio)
						{
							((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mInterligacao[iIndice1].Documento));
						}
					}
					text = ExcFuncoesExcel.mudaNumeroAsc(1L) + Conversions.ToString(iLinhaRelatorio) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 3);
					ExcFuncoesExcel.mudaNumeroAsc(num);
					num++;
				}
				if (bfuncao)
				{
					if (!((Operators.CompareString(clsTextos.TiraNothing(mInterligacao[iIndice1].Funcao), clsTextos.TiraNothing(mInterligacao[iIndice2].Funcao), TextCompare: true) == 0) & (Operators.CompareString(clsTextos.TiraNothing(mInterligacao[iIndice1].Funcao), "", TextCompare: true) != 0) & (iIndice2 > 0)))
					{
						text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 1);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						if (!bCampoVazio)
						{
							((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mInterligacao[iIndice1].Funcao));
						}
						text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 2) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 3);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						if (iIndice2 > 0 && !bCampoVazio)
						{
							((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mInterligacao[iIndice2].Funcao));
						}
					}
					else
					{
						text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 3);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						if (!bCampoVazio)
						{
							((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mInterligacao[iIndice1].Funcao));
						}
					}
					text = ExcFuncoesExcel.mudaNumeroAsc(1L) + Conversions.ToString(iLinhaRelatorio) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 3);
					ExcFuncoesExcel.mudaNumeroAsc(num);
					num++;
				}
				if (bTrajeto)
				{
					if (!((Operators.CompareString(clsTextos.TiraNothing(mInterligacao[iIndice1].Trajeto), clsTextos.TiraNothing(mInterligacao[iIndice2].Trajeto), TextCompare: true) == 0) & (Operators.CompareString(clsTextos.TiraNothing(mInterligacao[iIndice1].Trajeto), "", TextCompare: true) != 0) & (iIndice2 > 0)))
					{
						text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 1);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						if (!bCampoVazio)
						{
							((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mInterligacao[iIndice1].Trajeto));
						}
						text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 2) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 3);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						if (iIndice2 > 0 && !bCampoVazio)
						{
							((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mInterligacao[iIndice2].Trajeto));
						}
					}
					else
					{
						text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 3);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						if (!bCampoVazio)
						{
							((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mInterligacao[iIndice1].Trajeto));
						}
					}
					ExcFuncoesExcel.mudaNumeroAsc(num);
					num++;
				}
				if (Operators.CompareString(sOpcional, "", TextCompare: true) != 0)
				{
					text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + (iLinhaRelatorio + 1);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 2) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + (iLinhaRelatorio + 3);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					text = "A" + Conversions.ToString(iLinhaRelatorio) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 3);
					ExcFuncoesExcel.mudaNumeroAsc(num);
					num++;
				}
				text = ExcFuncoesExcel.mudaNumeroAsc(1L) + Conversions.ToString(iLinhaRelatorio) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num - 1) + (iLinhaRelatorio + 3);
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				text = "A" + Conversions.ToString(iLinhaRelatorio) + ":A" + (iLinhaRelatorio + 3);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 1;
				text = "E" + Conversions.ToString(iLinhaRelatorio) + ":E" + (iLinhaRelatorio + 3);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 1;
				if (Operators.CompareString(mInterligacao[iIndice1].Jumper, "╗", TextCompare: true) == 0)
				{
					text = "D" + Conversions.ToString(iLinhaRelatorio + 2);
					ExcFuncoesExcel.SetarCorCelula(ref oSheet, text);
				}
				if (Operators.CompareString(mInterligacao[iIndice1].Jumper, "║", TextCompare: true) == 0)
				{
					text = "D" + Conversions.ToString(iLinhaRelatorio) + ":D" + Conversions.ToString(iLinhaRelatorio + 3);
					ExcFuncoesExcel.SetarCorCelula(ref oSheet, text);
				}
				if (Operators.CompareString(mInterligacao[iIndice1].Jumper, "╝", TextCompare: true) == 0)
				{
					text = "D" + Conversions.ToString(iLinhaRelatorio);
					ExcFuncoesExcel.SetarCorCelula(ref oSheet, text);
				}
				if (iIndice2 > 0)
				{
					mInterligacao[iIndice2].TipoBorne = -20;
				}
				iLinhaRelatorio += 4;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	private static void NM7355LkAH(ref Worksheet P_0, bool P_1, bool P_2, bool P_3, string P_4, bool P_5)
	{
		checked
		{
			try
			{
				int num = 1;
				string text = ExcFuncoesExcel.mudaNumeroAsc(1L);
				((_Worksheet)P_0).get_Range((object)(text + "1"), RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 1;
				num = 2;
				text = ExcFuncoesExcel.mudaNumeroAsc(2L);
				((_Worksheet)P_0).get_Range((object)(text + "1"), RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 0.6;
				num = 3;
				text = ExcFuncoesExcel.mudaNumeroAsc(3L);
				((_Worksheet)P_0).get_Range((object)(text + "1"), RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				num = 4;
				text = ExcFuncoesExcel.mudaNumeroAsc(4L);
				((_Worksheet)P_0).get_Range((object)(text + "1"), RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 0.6;
				num = 5;
				text = ExcFuncoesExcel.mudaNumeroAsc(5L);
				((_Worksheet)P_0).get_Range((object)(text + "1"), RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 1;
				num = 6;
				text = ExcFuncoesExcel.mudaNumeroAsc(6L);
				((_Worksheet)P_0).get_Range((object)(text + "1"), RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
				num = 7;
				text = ExcFuncoesExcel.mudaNumeroAsc(7L);
				if (P_1)
				{
					((_Worksheet)P_0).get_Range((object)(text + "1"), RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
					num++;
					text = ExcFuncoesExcel.mudaNumeroAsc(num);
				}
				((_Worksheet)P_0).get_Range((object)(text + "1"), RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 20;
				num++;
				text = ExcFuncoesExcel.mudaNumeroAsc(num);
				((_Worksheet)P_0).get_Range((object)(text + "1"), RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				num++;
				text = ExcFuncoesExcel.mudaNumeroAsc(num);
				((_Worksheet)P_0).get_Range((object)(text + "1"), RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 8.5;
				num++;
				text = ExcFuncoesExcel.mudaNumeroAsc(num);
				if (P_2)
				{
					((_Worksheet)P_0).get_Range((object)(text + "1"), RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 20;
					num++;
					text = ExcFuncoesExcel.mudaNumeroAsc(num);
				}
				if (P_3)
				{
					((_Worksheet)P_0).get_Range((object)(text + "1"), RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 30;
					num++;
					text = ExcFuncoesExcel.mudaNumeroAsc(num);
				}
				if (P_5)
				{
					((_Worksheet)P_0).get_Range((object)(text + "1"), RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 30;
					num++;
					text = ExcFuncoesExcel.mudaNumeroAsc(num);
				}
				if (Operators.CompareString(P_4, "", TextCompare: true) != 0)
				{
					((_Worksheet)P_0).get_Range((object)(text + "1"), RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 5;
					num++;
					text = ExcFuncoesExcel.mudaNumeroAsc(num);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	private static void OIX30sQvc4(ref Worksheet P_0, ref int P_1, bool P_2, bool P_3, bool P_4, string P_5, bool P_6)
	{
		checked
		{
			try
			{
				string text = "";
				int num = 10;
				text = "A" + Conversions.ToString(P_1) + ":A" + Conversions.ToString(P_1 + 10);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 9;
				string cell = "A" + Conversions.ToString(P_1);
				((_Worksheet)P_0).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
				if (!P_2)
				{
					text = ExcFuncoesExcel.mudaNumeroAsc(1L) + Conversions.ToString(P_1) + ":" + ExcFuncoesExcel.mudaNumeroAsc(6L) + Conversions.ToString(P_1 + 1);
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1241]));
					text = ExcFuncoesExcel.mudaNumeroAsc(7L) + Conversions.ToString(P_1) + ":" + ExcFuncoesExcel.mudaNumeroAsc(9L) + Conversions.ToString(P_1 + 1);
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1242]));
					text = ExcFuncoesExcel.mudaNumeroAsc(1L) + Conversions.ToString(P_1 + 2) + ":" + ExcFuncoesExcel.mudaNumeroAsc(5L) + Conversions.ToString(P_1 + 3);
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 984]));
					text = ExcFuncoesExcel.mudaNumeroAsc(6L) + Conversions.ToString(P_1 + 2) + ":" + ExcFuncoesExcel.mudaNumeroAsc(6L) + Conversions.ToString(P_1 + 3);
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1305]));
					text = ExcFuncoesExcel.mudaNumeroAsc(7L) + Conversions.ToString(P_1 + 2) + ":" + ExcFuncoesExcel.mudaNumeroAsc(7L) + Conversions.ToString(P_1 + 3);
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 626]));
					text = ExcFuncoesExcel.mudaNumeroAsc(8L) + Conversions.ToString(P_1 + 2) + ":" + ExcFuncoesExcel.mudaNumeroAsc(8L) + Conversions.ToString(P_1 + 3);
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 984]));
					text = ExcFuncoesExcel.mudaNumeroAsc(9L) + Conversions.ToString(P_1 + 2) + ":" + ExcFuncoesExcel.mudaNumeroAsc(9L) + Conversions.ToString(P_1 + 3);
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1429]));
					num = 9;
					ExcFuncoesExcel.mudaNumeroAsc(9L);
				}
				else
				{
					text = ExcFuncoesExcel.mudaNumeroAsc(1L) + Conversions.ToString(P_1) + ":" + ExcFuncoesExcel.mudaNumeroAsc(7L) + Conversions.ToString(P_1 + 1);
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1241]));
					text = ExcFuncoesExcel.mudaNumeroAsc(8L) + Conversions.ToString(P_1) + ":" + ExcFuncoesExcel.mudaNumeroAsc(10L) + Conversions.ToString(P_1 + 1);
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1242]));
					text = ExcFuncoesExcel.mudaNumeroAsc(1L) + Conversions.ToString(P_1 + 2) + ":" + ExcFuncoesExcel.mudaNumeroAsc(5L) + Conversions.ToString(P_1 + 3);
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 984]));
					text = ExcFuncoesExcel.mudaNumeroAsc(6L) + Conversions.ToString(P_1 + 2) + ":" + ExcFuncoesExcel.mudaNumeroAsc(6L) + Conversions.ToString(P_1 + 3);
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1305]));
					text = ExcFuncoesExcel.mudaNumeroAsc(7L) + Conversions.ToString(P_1 + 2) + ":" + ExcFuncoesExcel.mudaNumeroAsc(7L) + Conversions.ToString(P_1 + 3);
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1285]));
					text = ExcFuncoesExcel.mudaNumeroAsc(8L) + Conversions.ToString(P_1 + 2) + ":" + ExcFuncoesExcel.mudaNumeroAsc(8L) + Conversions.ToString(P_1 + 3);
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 626]));
					text = ExcFuncoesExcel.mudaNumeroAsc(9L) + Conversions.ToString(P_1 + 2) + ":" + ExcFuncoesExcel.mudaNumeroAsc(9L) + Conversions.ToString(P_1 + 3);
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 984]));
					text = ExcFuncoesExcel.mudaNumeroAsc(10L) + Conversions.ToString(P_1 + 2) + ":" + ExcFuncoesExcel.mudaNumeroAsc(10L) + Conversions.ToString(P_1 + 3);
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1429]));
					num = 10;
					ExcFuncoesExcel.mudaNumeroAsc(10L);
				}
				if (P_4)
				{
					num++;
					text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(P_1) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(P_1 + 3);
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1417]));
				}
				if (P_3)
				{
					num++;
					ExcFuncoesExcel.mudaNumeroAsc(num);
					text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(P_1) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(P_1 + 3);
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1244]));
				}
				if (P_6)
				{
					num++;
					text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(P_1) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(P_1 + 3);
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1248]));
				}
				if (Operators.CompareString(P_5, "", TextCompare: true) != 0)
				{
					num++;
					text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(P_1) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(P_1 + 3);
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + P_5));
				}
				text = ExcFuncoesExcel.mudaNumeroAsc(1L) + Conversions.ToString(P_1) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(P_1 + 3);
				ExcFuncoesExcel.CriaLinhasInterna(ref P_0, text);
				ExcFuncoesExcel.CriaLinhasExterna(ref P_0, text, bCompleto: true);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				P_1 += 4;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	private static void EDM3R9Q20T(ref Microsoft.Office.Interop.Excel.Application P_0, ref Worksheet P_1, ref List<string> P_2, string P_3, string P_4, ref int P_5, int P_6, bool P_7, bool P_8, bool P_9, bool P_10, bool P_11, string P_12, frmRelatorio_InterligacaoEletroSul_Excel.ConfRelelatorioExcel P_13)
	{
		checked
		{
			try
			{
				Workbook oBook = null;
				if (ExcFuncoesExcel.VerificaExcelAtivo(ref P_0, ref oBook, ref P_1))
				{
					P_0.Visible = true;
				}
				P_6 -= 4;
				P_5 = P_6;
				string text = "";
				int num = 9;
				string cell = "A" + Conversions.ToString(P_5);
				((_Worksheet)P_1).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
				if (P_7)
				{
					num++;
				}
				if (P_9)
				{
					num++;
				}
				if (P_8)
				{
					num++;
				}
				if (P_10)
				{
					num++;
				}
				if (P_11)
				{
					num++;
				}
				string cell2 = "A" + Conversions.ToString(P_6);
				((_Worksheet)P_1).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
				text = ExcFuncoesExcel.mudaNumeroAsc(1L) + Conversions.ToString(P_5) + ":" + ExcFuncoesExcel.mudaNumeroAsc(1L) + Conversions.ToString(P_5 + 2);
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 16;
				text = ExcFuncoesExcel.mudaNumeroAsc(1L) + Conversions.ToString(P_5) + ":" + ExcFuncoesExcel.mudaNumeroAsc(6L) + Conversions.ToString(P_5);
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				text = ExcFuncoesExcel.mudaNumeroAsc(1L) + Conversions.ToString(P_5 + 1) + ":" + ExcFuncoesExcel.mudaNumeroAsc(6L) + Conversions.ToString(P_5 + 1);
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				text = ExcFuncoesExcel.mudaNumeroAsc(1L) + Conversions.ToString(P_5 + 2) + ":" + ExcFuncoesExcel.mudaNumeroAsc(6L) + Conversions.ToString(P_5 + 2);
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				text = ExcFuncoesExcel.mudaNumeroAsc(1L) + Conversions.ToString(P_5) + ":" + ExcFuncoesExcel.mudaNumeroAsc(6L) + Conversions.ToString(P_5 + 2);
				ExcFuncoesExcel.LimpaLinhasInterna(ref P_1, text);
				ExcFuncoesExcel.CriaLinhasExternaSimles(ref P_1, text, bCompleto: true);
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = ExcFuncoesExcel.mudaNumeroAsc(1L) + Conversions.ToString(P_5) + ":" + ExcFuncoesExcel.mudaNumeroAsc(1L) + Conversions.ToString(P_5 + 2);
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				text = ExcFuncoesExcel.mudaNumeroAsc(1L) + Conversions.ToString(P_5);
				int num2;
				do
				{
					num2 = ExcFuncoesExcel.QuantidadeFigura(ref P_0);
					ExcFuncoesExcel.InsereFigura1(ref P_1, text, P_13.sCaminhoDesenho, 26, 3);
				}
				while (num2 == ExcFuncoesExcel.QuantidadeFigura(ref P_0));
				string text2 = ExcFuncoesExcel.mudaNumeroAsc(num - 2);
				text = ExcFuncoesExcel.mudaNumeroAsc(7L) + Conversions.ToString(P_5) + ":" + text2 + Conversions.ToString(P_5);
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("Num. Des. " + P_13.NumDesenho));
				text = ExcFuncoesExcel.mudaNumeroAsc(7L) + Conversions.ToString(P_5 + 1) + ":" + text2 + Conversions.ToString(P_5 + 2);
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)P_13.Desc1);
				text = ExcFuncoesExcel.mudaNumeroAsc(7L) + Conversions.ToString(P_5) + ":" + text2 + Conversions.ToString(P_5 + 2);
				ExcFuncoesExcel.LimpaLinhasInterna(ref P_1, text);
				ExcFuncoesExcel.CriaLinhasExternaSimles(ref P_1, text, bCompleto: true);
				string text3 = ExcFuncoesExcel.mudaNumeroAsc(num - 1);
				text = text3 + Conversions.ToString(P_5);
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"REV.");
				text = text3 + Conversions.ToString(P_5 + 1) + ":" + text3 + Conversions.ToString(P_5 + 2);
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)P_13.sRev);
				text = text3 + Conversions.ToString(P_5) + ":" + text3 + Conversions.ToString(P_5 + 2);
				ExcFuncoesExcel.LimpaLinhasInterna(ref P_1, text);
				ExcFuncoesExcel.CriaLinhasExternaSimles(ref P_1, text, bCompleto: true);
				string text4 = ExcFuncoesExcel.mudaNumeroAsc(num);
				text = text4 + Conversions.ToString(P_5);
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1665]));
				text = text4 + Conversions.ToString(P_5 + 1) + ":" + text4 + Conversions.ToString(P_5 + 2);
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)P_12);
				text = text4 + Conversions.ToString(P_5) + ":" + text4 + Conversions.ToString(P_5 + 2);
				ExcFuncoesExcel.LimpaLinhasInterna(ref P_1, text);
				ExcFuncoesExcel.CriaLinhasExternaSimles(ref P_1, text, bCompleto: true);
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "A" + Conversions.ToString(P_5) + ":" + text4 + Conversions.ToString(P_5 + 2);
				ExcFuncoesExcel.CriaLinhasExterna(ref P_1, text, bCompleto: true);
				ExcFuncoesExcel.SetaAreaDeImpressao(ref P_1, ref P_2, text4, (P_5 + 2).ToString());
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	private static void wao3mITsLF(ref Microsoft.Office.Interop.Excel.Application P_0, ref Worksheet P_1, ref List<string> P_2, ref int P_3, string P_4, string P_5, ref int P_6, int P_7, bool P_8, bool P_9, bool P_10, bool P_11, string P_12, frmRelatorio_InterligacaoEletroSul_Excel.ConfRelelatorioExcel P_13)
	{
		checked
		{
			try
			{
				P_6 = P_7 - 3;
				string text = "";
				int num = 9;
				string cell = "A" + Conversions.ToString(P_6);
				((_Worksheet)P_1).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
				if (P_8)
				{
					num++;
				}
				if (P_10)
				{
					num++;
				}
				if (P_9)
				{
					num++;
				}
				if (P_11)
				{
					num++;
				}
				int num2 = P_3;
				int num3 = P_7 - 3;
				for (int i = num2; i <= num3; i++)
				{
					text = "A" + Conversions.ToString(i) + ":F" + Conversions.ToString(i);
					((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					text = "G" + Conversions.ToString(i) + ":I" + Conversions.ToString(i);
					((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					text = "J" + Conversions.ToString(i) + ":K" + Conversions.ToString(i);
					((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				}
				text = "A" + Conversions.ToString(P_3) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(P_7 - 3);
				ExcFuncoesExcel.LimpaLinhasInterna(ref P_1, text);
				ExcFuncoesExcel.CriaLinhasInterna(ref P_1, text);
				ExcFuncoesExcel.CriaLinhasExterna(ref P_1, text, bCompleto: true);
				string cell2 = "A" + Conversions.ToString(P_7);
				((_Worksheet)P_1).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
				P_6++;
				text = "A" + Conversions.ToString(P_6) + ":A" + Conversions.ToString(P_6 + 2);
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 16;
				text = "A" + Conversions.ToString(P_6) + ":F" + Conversions.ToString(P_6 + 2);
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				ExcFuncoesExcel.CriaLinhasExterna(ref P_1, text, bCompleto: true);
				text = "A" + Conversions.ToString(P_6 + 1);
				int num4;
				do
				{
					num4 = ExcFuncoesExcel.QuantidadeFigura(ref P_0);
					ExcFuncoesExcel.InsereFigura1(ref P_1, text, P_13.sCaminhoDesenho, 26, 3);
				}
				while (num4 == ExcFuncoesExcel.QuantidadeFigura(ref P_0));
				string text2 = ExcFuncoesExcel.mudaNumeroAsc(num - 2);
				text = "G" + Conversions.ToString(P_6) + ":" + text2 + Conversions.ToString(P_6);
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("Num. Des. " + P_13.NumDesenho));
				text = "G" + Conversions.ToString(P_6 + 1) + ":" + text2 + Conversions.ToString(P_6 + 2);
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)P_13.Desc1);
				text = "G" + Conversions.ToString(P_6) + ":" + text2 + Conversions.ToString(P_6 + 2);
				ExcFuncoesExcel.CriaLinhasExterna(ref P_1, text, bCompleto: true);
				string text3 = ExcFuncoesExcel.mudaNumeroAsc(num - 1);
				text = text3 + Conversions.ToString(P_6);
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"REV.");
				text = text3 + Conversions.ToString(P_6 + 1) + ":" + text3 + Conversions.ToString(P_6 + 2);
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)P_13.sRev);
				text = text3 + Conversions.ToString(P_6) + ":" + text3 + Conversions.ToString(P_6 + 2);
				ExcFuncoesExcel.CriaLinhasExterna(ref P_1, text, bCompleto: true);
				string text4 = ExcFuncoesExcel.mudaNumeroAsc(num);
				text = text4 + Conversions.ToString(P_6);
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1665]));
				text = text4 + Conversions.ToString(P_6 + 1) + ":" + text4 + Conversions.ToString(P_6 + 2);
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)P_1).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)P_12);
				text = text4 + Conversions.ToString(P_6) + ":" + text4 + Conversions.ToString(P_6 + 2);
				ExcFuncoesExcel.CriaLinhasExterna(ref P_1, text, bCompleto: true);
				ExcFuncoesExcel.SetaAreaDeImpressao(ref P_1, ref P_2, text4, Conversions.ToString(P_6 + 2));
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	private static void a653XZOLxi(ref Worksheet P_0, ref int P_1, string P_2)
	{
		checked
		{
			try
			{
				string text = "";
				text = "A" + Conversions.ToString(P_1) + ":A" + Conversions.ToString(P_1 + 3);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 9;
				text = "A" + Conversions.ToString(P_1) + ":E" + Conversions.ToString(P_1 + 1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + P_2));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 12;
				ExcFuncoesExcel.CriaLinhasExterna(ref P_0, text, bCompleto: true);
				P_1 += 2;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}
}

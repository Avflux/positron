using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class Relatorios_ExcelComum_EletroSul
{
	public static void preencheIndiceInterligacaoExcel(ref Declaracoes2.StructureIndiceRelatEletroSul[] mIndiceRelatorio, string sPainel, string sRev, string sDoc, string bFiacao, ref int iColuna)
	{
		Application oExcelNew = null;
		Worksheet oSheet = null;
		int num = 55;
		List<string> list = new List<string>();
		int num2 = 3;
		checked
		{
			if (ExcFuncoesExcel.VerificaExisteSheet(ref oExcelNew, ref oSheet, "INDICE"))
			{
				string cell = "A3";
				int num3 = Information.UBound(mIndiceRelatorio);
				for (int i = 1; i <= num3; i++)
				{
					string cell2 = ExcFuncoesExcel.mudaNumeroAsc(iColuna) + num2;
					string cell3 = ExcFuncoesExcel.mudaNumeroAsc(iColuna + 1) + num2;
					string cell4 = ExcFuncoesExcel.mudaNumeroAsc(iColuna + 2) + num2;
					if (!list.Contains(mIndiceRelatorio[i].sFolha))
					{
						((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mIndiceRelatorio[i].sFolha.ToString()));
						((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						list.Add(mIndiceRelatorio[i].sFolha);
						int num4 = 1;
						do
						{
							string cell5 = ExcFuncoesExcel.mudaNumeroAsc(num4) + num2;
							((_Worksheet)oSheet).get_Range((object)cell5, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Name = RuntimeHelpers.GetObjectValue(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Name);
							((_Worksheet)oSheet).get_Range((object)cell5, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = RuntimeHelpers.GetObjectValue(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size);
							num4++;
						}
						while (num4 <= 3);
						if (Operators.CompareString(sRev, "", TextCompare: true) != 0)
						{
							((_Worksheet)oSheet).get_Range((object)cell3, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + sRev));
							((_Worksheet)oSheet).get_Range((object)cell3, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
							((_Worksheet)oSheet).get_Range((object)cell3, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						}
					}
					((_Worksheet)oSheet).get_Range((object)cell4, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mIndiceRelatorio[i].sDescricao));
					((_Worksheet)oSheet).get_Range((object)cell4, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)cell4, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 2;
					num2 = (DeclaracoesFiacao.ilinhaCEMIGD = num2 + 1);
					if (num2 > num)
					{
						iColuna += 6;
						num2 = 3;
						list.Clear();
					}
				}
			}
			oExcelNew.ScreenUpdating = true;
		}
	}

	public static void preencheIndiceComumExcel(string sSheet, string sEquip, string sDesc1, string sDesc2, string sDesc3, string sRev, string sDesenho, string sFl, int iInicio = 1, int iFim = 100)
	{
		Application oExcelNew = null;
		Worksheet oSheet = null;
		if (!ExcFuncoesExcel.VerificaExisteSheet(ref oExcelNew, ref oSheet, sSheet))
		{
			return;
		}
		int num = 1;
		checked
		{
			do
			{
				string text = ExcFuncoesExcel.mudaNumeroAsc(num);
				for (int i = iInicio; i <= iFim; i++)
				{
					string cell = text + i;
					string left = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))).ToString().ToUpper();
					if (Operators.CompareString(left, "#EQUIPAMENTO#", TextCompare: true) != 0)
					{
						if (Operators.CompareString(left, "#DESC1#", TextCompare: true) != 0)
						{
							if (Operators.CompareString(left, "#DESC2#", TextCompare: true) != 0)
							{
								if (Operators.CompareString(left, "#DESC3#", TextCompare: true) != 0)
								{
									if (Operators.CompareString(left, "#REV#", TextCompare: true) != 0)
									{
										if (Operators.CompareString(left, "#DESENHO#", TextCompare: true) != 0)
										{
											if (Operators.CompareString(left, "#FL#", TextCompare: true) == 0)
											{
												((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)sFl);
											}
										}
										else
										{
											((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)sDesenho);
										}
									}
									else
									{
										((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)sRev);
									}
								}
								else
								{
									((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)sDesc3);
								}
							}
							else
							{
								((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)sDesc2);
							}
						}
						else
						{
							((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)sDesc1);
						}
					}
					else
					{
						((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)sEquip);
					}
				}
				num++;
			}
			while (num <= 20);
		}
	}

	public static void AtualizaPaginas(Relatorios_ListaCabosEXCEL.indiceRelatorioCabos[] mIndiceRel)
	{
		Application oExcelNew = null;
		Worksheet oSheet = null;
		for (int i = 0; i < mIndiceRel.Length; i = checked(i + 1))
		{
			Relatorios_ListaCabosEXCEL.indiceRelatorioCabos indiceRelatorioCabos = mIndiceRel[i];
			if (ExcFuncoesExcel.VerificaExisteSheet(ref oExcelNew, ref oSheet, indiceRelatorioCabos.sNomeSheet))
			{
				((_Worksheet)oSheet).get_Range((object)"H49", RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)indiceRelatorioCabos.sPagina);
			}
		}
	}

	public static void CriarodapeFiacaoELS(ref Worksheet oSheet, ref List<string> lSheetArea, int iLinhaInicial, string sNomeSheet, string sLinIni, ref int iLinhaRelatorio, int iProximaQuebra, bool bFormacao, bool bfuncao, bool bDoc, bool bOpcional, string sFolha, frmRelatorio_Fiacao_Excel.ConfRelelatorioExcel ConfRel, int iX, int iY)
	{
		iLinhaRelatorio = iProximaQuebra;
		string text = "";
		string cell = "A" + Conversions.ToString(iLinhaRelatorio);
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
		checked
		{
			text = "A" + Conversions.ToString(iLinhaRelatorio) + ":A" + Conversions.ToString(iLinhaRelatorio + 2);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 16;
			text = "A" + Conversions.ToString(iLinhaRelatorio) + ":D" + Conversions.ToString(iLinhaRelatorio + 2);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
			ExcFuncoesExcel.CriaLinhasExternaSimles(ref oSheet, text, bCompleto: true);
			text = "A" + Conversions.ToString(iLinhaRelatorio + 1);
			ExcFuncoesExcel.InsereFigura1(ref oSheet, text, ConfRel.sCaminhoDesenho, iX, iY);
			text = "E" + Conversions.ToString(iLinhaRelatorio) + ":J" + Conversions.ToString(iLinhaRelatorio);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("Num. Des. " + ConfRel.NumDesenho));
			text = "E" + Conversions.ToString(iLinhaRelatorio + 1) + ":J" + Conversions.ToString(iLinhaRelatorio + 2);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)ConfRel.Desc1);
			text = "E" + Conversions.ToString(iLinhaRelatorio) + ":J" + Conversions.ToString(iLinhaRelatorio + 2);
			ExcFuncoesExcel.CriaLinhasExternaSimles(ref oSheet, text, bCompleto: true);
			text = "K" + Conversions.ToString(iLinhaRelatorio) + ":L" + Conversions.ToString(iLinhaRelatorio);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"REV.");
			text = "K" + Conversions.ToString(iLinhaRelatorio + 1) + ":L" + Conversions.ToString(iLinhaRelatorio + 2);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)ConfRel.sRev);
			text = "K" + Conversions.ToString(iLinhaRelatorio) + ":L" + Conversions.ToString(iLinhaRelatorio + 2);
			ExcFuncoesExcel.CriaLinhasExternaSimles(ref oSheet, text, bCompleto: true);
			text = "M" + Conversions.ToString(iLinhaRelatorio) + ":N" + Conversions.ToString(iLinhaRelatorio);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1665]));
			text = "M" + Conversions.ToString(iLinhaRelatorio + 1) + ":N" + Conversions.ToString(iLinhaRelatorio + 2);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)sFolha);
			text = "M" + Conversions.ToString(iLinhaRelatorio) + ":N" + Conversions.ToString(iLinhaRelatorio + 2);
			ExcFuncoesExcel.CriaLinhasExternaSimles(ref oSheet, text, bCompleto: true);
			ExcFuncoesExcel.SetaAreaDeImpressao(ref oSheet, ref lSheetArea, "N", Conversions.ToString(iLinhaRelatorio + 2));
		}
	}

	public static void CriarodapeFiacaoELSBornes(ref Worksheet oSheet, ref List<string> lSheetArea, int iLinhaInicial, string sNomeSheet, string sLinIni, ref int iLinhaRelatorio, int iProximaQuebra, bool bFormacao, bool bfuncao, bool bDoc, bool bOpcional, string sFolha, frmRelatorio_Fiacao_Excel.ConfRelelatorioExcel ConfRel, int iX, int iY)
	{
		checked
		{
			try
			{
				iLinhaRelatorio = iProximaQuebra;
				string text = "";
				string cell = "A" + Conversions.ToString(iLinhaRelatorio);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
				text = "A" + Conversions.ToString(iLinhaRelatorio) + ":A" + Conversions.ToString(iLinhaRelatorio + 6);
				string cell2 = "A" + Conversions.ToString(iProximaQuebra);
				((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
				text = "A" + Conversions.ToString(iLinhaRelatorio) + ":D" + Conversions.ToString(iLinhaRelatorio + 5);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				ExcFuncoesExcel.CriaLinhasExternaSimles(ref oSheet, text, bCompleto: true);
				text = "A" + Conversions.ToString(iLinhaRelatorio + 1);
				ExcFuncoesExcel.InsereFigura1(ref oSheet, text, ConfRel.sCaminhoDesenho, iX, iY);
				text = "E" + Conversions.ToString(iLinhaRelatorio) + ":J" + Conversions.ToString(iLinhaRelatorio + 2);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("Num. Des. " + ConfRel.NumDesenho));
				text = "E" + Conversions.ToString(iLinhaRelatorio + 3) + ":J" + Conversions.ToString(iLinhaRelatorio + 5);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)ConfRel.Desc1);
				text = "E" + Conversions.ToString(iLinhaRelatorio) + ":J" + Conversions.ToString(iLinhaRelatorio + 5);
				ExcFuncoesExcel.CriaLinhasExternaSimles(ref oSheet, text, bCompleto: true);
				text = "K" + Conversions.ToString(iLinhaRelatorio) + ":L" + Conversions.ToString(iLinhaRelatorio + 2);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 380], "."));
				text = "K" + Conversions.ToString(iLinhaRelatorio + 3) + ":L" + Conversions.ToString(iLinhaRelatorio + 5);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)ConfRel.sRev);
				text = "K" + Conversions.ToString(iLinhaRelatorio) + ":L" + Conversions.ToString(iLinhaRelatorio + 5);
				ExcFuncoesExcel.CriaLinhasExternaSimles(ref oSheet, text, bCompleto: true);
				text = "M" + Conversions.ToString(iLinhaRelatorio) + ":N" + Conversions.ToString(iLinhaRelatorio + 2);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1665]));
				text = "M" + Conversions.ToString(iLinhaRelatorio + 3) + ":N" + Conversions.ToString(iLinhaRelatorio + 5);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)sFolha);
				text = "M" + Conversions.ToString(iLinhaRelatorio) + ":N" + Conversions.ToString(iLinhaRelatorio + 5);
				ExcFuncoesExcel.CriaLinhasExternaSimles(ref oSheet, text, bCompleto: true);
				ExcFuncoesExcel.SetaAreaDeImpressao(ref oSheet, ref lSheetArea, "N", Conversions.ToString(iLinhaRelatorio + 2));
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}
}

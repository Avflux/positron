using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class Relatorios_ListaVeiasEXCEL
{
	public static void CriaListaVeiasEXCEL(clsVeias.StructureVeias[] mCabos, bool bFuncaoVeia, bool bComprimento)
	{
		checked
		{
			try
			{
				Application oExcelNew = null;
				Worksheet oSheet = null;
				string oNomeSheet = DeclaracoesGeral.mMensagem[1, 895].ToString().Replace(" ", "_");
				ExcFuncoesExcel.VerificaExcel(ref oExcelNew, ref oSheet, oNomeSheet);
				ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
				((_Worksheet)oSheet).get_Range((object)"A1", (object)"Z10000").EntireRow.Delete(RuntimeHelpers.GetObjectValue(Missing.Value));
				oSheet.Cells.ClearComments();
				long num = 1L;
				M88pnrJWPVd(ref oSheet, bComprimento);
				int num2 = 1;
				VjYpn9hCyM0(ref oSheet, ref num2, bComprimento);
				num = num2;
				List<string> list = new List<string>();
				int num3 = Information.UBound(mCabos);
				for (int i = 1; i <= num3; i++)
				{
					if (!list.Contains(mCabos[i].sTag) && Operators.CompareString(mCabos[i].sTag, "", TextCompare: true) != 0)
					{
						list.Add(mCabos[i].sTag);
					}
				}
				list.Sort();
				clsVeias.StructureVeias[] Cabos = null;
				DeclaracoesGeral._uscPagina.Quantidade = list.Count;
				DeclaracoesGeral._uscPagina.pbIniciar();
				int iQuantLinhas = 0;
				if (Operators.CompareString(DeclaracoesGeral.companyHardlock.ToUpper(), "CADGRAPH", TextCompare: true) != 0)
				{
					ExcFuncoesExcel.DesativaCalculoExcel(ref oExcelNew);
				}
				int num4 = list.Count - 1;
				for (int j = 0; j <= num4; j++)
				{
					carregaUmCabo(list[j].ToString(), ref iQuantLinhas, ref Cabos, mCabos);
					clsVeias.StructureVeias[] array = Cabos;
					num2 = (int)num;
					chjp1WrvJyr(ref oSheet, array, ref num2, ref iQuantLinhas, bFuncaoVeia, bComprimento);
					num = num2;
					DeclaracoesGeral._uscPagina.pbPasso();
				}
				ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
				string cell = "A1";
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
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

	public static void CriaListaVeiasEXCELSeparaPainel(clsVeias.StructureVeias[] mCabos, bool bFuncaoVeia, bool bComprimento)
	{
		checked
		{
			try
			{
				Application oExcelNew = null;
				Worksheet oSheet = null;
				string oNomeSheet = "Lista_De_Veias_v4";
				ExcFuncoesExcel.VerificaExcel(ref oExcelNew, ref oSheet, oNomeSheet);
				ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
				if (Operators.CompareString(DeclaracoesGeral.companyHardlock.ToUpper(), "CADGRAPH", TextCompare: true) != 0)
				{
					ExcFuncoesExcel.DesativaCalculoExcel(ref oExcelNew);
				}
				((_Worksheet)oSheet).get_Range((object)"A1", (object)"Z10000").EntireRow.Delete(RuntimeHelpers.GetObjectValue(Missing.Value));
				oSheet.Cells.ClearComments();
				M88pnrJWPVd(ref oSheet, bComprimento);
				long num = 1L;
				List<string> list = new List<string>();
				string text = "";
				DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mCabos) - 1;
				DeclaracoesGeral._uscPagina.pbIniciar();
				int num2 = Information.UBound(mCabos) - 1;
				for (int i = 1; i <= num2; i++)
				{
					if (!list.Contains(mCabos[i].sTag) && Operators.CompareString(mCabos[i].sTag, "", TextCompare: true) != 0)
					{
						list.Add(mCabos[i].sTag);
					}
					if (i == Information.UBound(mCabos) - 1)
					{
						mCabos[i].iPainelSel = -1000;
					}
					if (mCabos[1].iPainelSel != 0 && Operators.CompareString(text, "", TextCompare: true) == 0)
					{
						text = Dicionario.BuscaNomeDoPainel(mCabos[1].iPainelSel);
					}
					if ((mCabos[i].iPainelSel != 0) & (list.Count > 0))
					{
						list.Sort();
						int num3;
						if (num > 1L)
						{
							num3 = (int)num;
							TyZpnzGJBd2(ref oSheet, ref num3, text, bComprimento);
							num = num3;
						}
						num3 = (int)num;
						VjYpn9hCyM0(ref oSheet, ref num3, bComprimento, text);
						num = num3;
						clsVeias.StructureVeias[] Cabos = null;
						int iQuantLinhas = 0;
						int num4 = list.Count - 1;
						for (int j = 0; j <= num4; j++)
						{
							carregaUmCabo(list[j].ToString(), ref iQuantLinhas, ref Cabos, mCabos);
							clsVeias.StructureVeias[] array = Cabos;
							num3 = (int)num;
							chjp1WrvJyr(ref oSheet, array, ref num3, ref iQuantLinhas, bFuncaoVeia, bComprimento);
							num = num3;
						}
						num += 2L;
						list.Clear();
						if (mCabos[i].iPainelSel != 0)
						{
							text = Dicionario.BuscaNomeDoPainel(mCabos[i].iPainelSel);
						}
					}
					DeclaracoesGeral._uscPagina.pbPasso();
				}
				DeclaracoesGeral._uscPagina.pbFim();
				string cell = "A" + Conversions.ToString(1);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
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

	public static void CriaListaVeiasEXCELSeparaSheet(clsVeias.StructureVeias[] mCabos, bool bFuncaoVeia, bool bComprimento)
	{
		checked
		{
			try
			{
				Application OExcelNew = null;
				Worksheet oSheet = null;
				long num = 1L;
				List<string> list = new List<string>();
				string text = "";
				int num2 = 0;
				int num3 = Information.UBound(mCabos);
				for (int i = 1; i <= num3; i++)
				{
					if (!list.Contains(mCabos[i].sTag) && Operators.CompareString(mCabos[i].sTag, "", TextCompare: true) != 0)
					{
						list.Add(mCabos[i].sTag);
					}
					if (i == Information.UBound(mCabos))
					{
						mCabos[i].iPainelSel = -1000;
					}
					if (((mCabos[i].iPainelSel != 0) & (mCabos[i].iIndice == -1000)) && num2 == 0)
					{
						num2 = mCabos[i].iPainelSel;
					}
					if ((mCabos[i].iPainelSel != 0) & (list.Count > 0))
					{
						list.Sort();
						if (num2 != mCabos[i - 1].iPn1 && mCabos[i - 1].iPn1 > 0)
						{
							num2 = mCabos[i - 1].iPn1;
						}
						text = Dicionario.BuscaNomeDoPainel(num2);
						num2 = 0;
						ExcFuncoesExcel.VerificaExcel(ref OExcelNew, ref oSheet, text);
						ExcFuncoesExcel.AtivaCalculOExcel(ref OExcelNew);
						num = 1L;
						((_Worksheet)oSheet).get_Range((object)"A1", (object)"Z10000").EntireRow.Delete(RuntimeHelpers.GetObjectValue(Missing.Value));
						oSheet.Cells.ClearComments();
						M88pnrJWPVd(ref oSheet, bComprimento);
						int num4 = 1;
						VjYpn9hCyM0(ref oSheet, ref num4, bComprimento);
						num = num4;
						clsVeias.StructureVeias[] Cabos = null;
						DeclaracoesGeral._uscPagina.Quantidade = list.Count;
						DeclaracoesGeral._uscPagina.pbIniciar();
						int iQuantLinhas = 0;
						int num5 = list.Count - 1;
						for (int j = 0; j <= num5; j++)
						{
							carregaUmCabo(list[j].ToString(), ref iQuantLinhas, ref Cabos, mCabos);
							clsVeias.StructureVeias[] array = Cabos;
							num4 = (int)num;
							chjp1WrvJyr(ref oSheet, array, ref num4, ref iQuantLinhas, bFuncaoVeia, bComprimento);
							num = num4;
							DeclaracoesGeral._uscPagina.pbPasso();
						}
						list.Clear();
						if (((mCabos[i].iPainelSel != 0) & (mCabos[i].iIndice == -1000)) && num2 == 0)
						{
							num2 = mCabos[i].iPainelSel;
						}
					}
				}
				DeclaracoesGeral._uscPagina.pbFim();
				ExcFuncoesExcel.AtivaCalculOExcel(ref OExcelNew);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				DeclaracoesGeral._uscPagina.pbFim();
				ProjectData.ClearProjectError();
			}
		}
	}

	private static void M88pnrJWPVd(ref Worksheet P_0, bool P_1)
	{
		try
		{
			((_Worksheet)P_0).get_Range((object)"A1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 14;
			((_Worksheet)P_0).get_Range((object)"B1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 14;
			((_Worksheet)P_0).get_Range((object)"C1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 37;
			((_Worksheet)P_0).get_Range((object)"D1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 9;
			((_Worksheet)P_0).get_Range((object)"E1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 14;
			((_Worksheet)P_0).get_Range((object)"F1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
			((_Worksheet)P_0).get_Range((object)"G1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
			((_Worksheet)P_0).get_Range((object)"H1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
			((_Worksheet)P_0).get_Range((object)"I1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 14;
			((_Worksheet)P_0).get_Range((object)"J1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
			((_Worksheet)P_0).get_Range((object)"K1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
			((_Worksheet)P_0).get_Range((object)"L1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
			((_Worksheet)P_0).get_Range((object)"M1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 30;
			((_Worksheet)P_0).get_Range((object)"N1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
			if (P_1)
			{
				((_Worksheet)P_0).get_Range((object)"O1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private static void VjYpn9hCyM0(ref Worksheet P_0, ref int P_1, bool P_2, string P_3 = "")
	{
		checked
		{
			try
			{
				string text = "";
				int num = P_1;
				string text2 = "N";
				if (P_2)
				{
					text2 = "O";
				}
				if (P_1 < 5)
				{
					text = "A" + Conversions.ToString(P_1) + ":" + text2 + Conversions.ToString(P_1 + 2);
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 16;
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'Relatório de Veias");
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					P_1 += 3;
					if (Operators.CompareString(P_3, "", TextCompare: true) != 0)
					{
						TyZpnzGJBd2(ref P_0, ref P_1, P_3, P_2);
						num = P_1;
					}
				}
				if (Operators.CompareString(text, "", TextCompare: true) != 0)
				{
					ExcFuncoesExcel.CriaLinhasExterna(ref P_0, text, bCompleto: true);
				}
				text = "A" + Conversions.ToString(P_1) + ":D" + Conversions.ToString(P_1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 1288].ToString().ToUpper()));
				text = "E" + Conversions.ToString(P_1) + ":H" + Conversions.ToString(P_1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 48].ToString().ToUpper()));
				text = "I" + Conversions.ToString(P_1) + ":L" + Conversions.ToString(P_1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 49].ToString().ToUpper()));
				text = "M" + Conversions.ToString(P_1) + ":" + text2 + Conversions.ToString(P_1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 115].ToString().ToUpper()));
				string cell = "A" + Conversions.ToString(P_1 + 10);
				((_Worksheet)P_0).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
				P_1++;
				text = "A" + Conversions.ToString(P_1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 176].ToString().ToUpper()));
				text = "B" + Conversions.ToString(P_1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 1285].ToString().ToUpper()));
				text = "C" + Conversions.ToString(P_1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 1430].ToString().ToUpper()));
				text = "D" + Conversions.ToString(P_1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 1569].ToString().ToUpper()));
				text = "E" + Conversions.ToString(P_1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 1081].ToString().ToUpper()));
				text = "F" + Conversions.ToString(P_1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 1336].ToString().ToUpper()));
				text = "G" + Conversions.ToString(P_1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 1429].ToString().ToUpper()));
				text = "H" + Conversions.ToString(P_1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 1243].ToString().ToUpper()));
				text = "I" + Conversions.ToString(P_1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 1081].ToString().ToUpper()));
				text = "J" + Conversions.ToString(P_1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 1336].ToString().ToUpper()));
				text = "K" + Conversions.ToString(P_1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 1429].ToString().ToUpper()));
				text = "L" + Conversions.ToString(P_1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 1243].ToString().ToUpper()));
				text = "M" + Conversions.ToString(P_1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 1959].ToString().ToUpper()));
				text = "N" + Conversions.ToString(P_1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 9].ToString().ToUpper()));
				if (P_2)
				{
					text = "O" + Conversions.ToString(P_1);
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1246]));
				}
				text = "A" + Conversions.ToString(P_1 - 1) + ":" + text2 + Conversions.ToString(P_1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 12;
				text = "A" + Conversions.ToString(num) + ":" + text2 + Conversions.ToString(P_1);
				ExcFuncoesExcel.CriaLinhasInterna(ref P_0, text);
				ExcFuncoesExcel.CriaLinhasExterna(ref P_0, text, bCompleto: true);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				P_1++;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	private static void TyZpnzGJBd2(ref Worksheet P_0, ref int P_1, string P_2, bool P_3)
	{
		checked
		{
			try
			{
				string text = "";
				if (!P_3)
				{
					text = "A" + Conversions.ToString(P_1) + ":N" + Conversions.ToString(P_1);
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				}
				else
				{
					text = "A" + Conversions.ToString(P_1) + ":O" + Conversions.ToString(P_1);
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				}
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 12;
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 626]), " "), P_2));
				ExcFuncoesExcel.CriaLinhasExterna(ref P_0, text, bCompleto: true);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				P_1++;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void carregaUmCabo(string sCabo, ref int iQuantLinhas, ref clsVeias.StructureVeias[] Cabos, clsVeias.StructureVeias[] mCabos)
	{
		checked
		{
			try
			{
				iQuantLinhas = 0;
				Cabos = new clsVeias.StructureVeias[1];
				int num = Information.UBound(mCabos);
				for (int i = 1; i <= num; i++)
				{
					if (Operators.CompareString(sCabo, mCabos[i].sTag, TextCompare: true) != 0)
					{
						continue;
					}
					int num2 = Information.UBound(Cabos) + 1;
					Cabos = (clsVeias.StructureVeias[])Utils.CopyArray(Cabos, new clsVeias.StructureVeias[num2 + 1]);
					Cabos[num2] = mCabos[i];
					if (Operators.CompareString(Cabos[num2].sPagina1, Cabos[num2].sPagina2, TextCompare: true) != 0 && Operators.CompareString(Cabos[num2].sPagina2, "", TextCompare: true) != 0)
					{
						if (Operators.CompareString(Cabos[num2].sPagina1, "", TextCompare: true) == 0)
						{
							Cabos[num2].sPagina1 = Cabos[num2].sPagina2;
							Cabos[num2].sPagina2 = "";
						}
						else
						{
							ref string sPagina = ref Cabos[num2].sPagina1;
							sPagina = sPagina + ", " + Cabos[num2].sPagina2;
							Cabos[num2].sPagina2 = "";
						}
					}
					iQuantLinhas++;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	private static void chjp1WrvJyr(ref Worksheet P_0, clsVeias.StructureVeias[] P_1, ref int P_2, ref int P_3, bool P_4, bool P_5)
	{
		checked
		{
			try
			{
				P_3--;
				string text = "";
				int num = P_2;
				text = "A" + Conversions.ToString(P_2) + ":A" + Conversions.ToString(P_2 + P_3);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				text = "B" + Conversions.ToString(P_2) + ":B" + Conversions.ToString(P_2 + P_3);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				if (!P_4)
				{
					text = "C" + Conversions.ToString(P_2) + ":C" + Conversions.ToString(P_2 + P_3);
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				}
				text = "E" + Conversions.ToString(P_2) + ":E" + Conversions.ToString(P_2 + P_3);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				text = "I" + Conversions.ToString(P_2) + ":I" + Conversions.ToString(P_2 + P_3);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				text = "M" + Conversions.ToString(P_2) + ":M" + Conversions.ToString(P_2 + P_3);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				text = "C" + Conversions.ToString(P_2) + ":C" + Conversions.ToString(P_2 + P_3);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				text = "A" + Conversions.ToString(P_2) + ":B" + Conversions.ToString(P_2 + P_3);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "D" + Conversions.ToString(P_2) + ":N" + Conversions.ToString(P_2 + P_3);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				if (P_5)
				{
					text = "O" + Conversions.ToString(P_2) + ":O" + Conversions.ToString(P_2 + P_3);
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				}
				int num2 = Information.UBound(P_1);
				for (int i = 1; i <= num2; i++)
				{
					text = "A" + Conversions.ToString(P_2);
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + P_1[i].sTag));
					text = "B" + Conversions.ToString(P_2);
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + P_1[i].sFormacao));
					text = "C" + Conversions.ToString(P_2);
					((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + P_1[i].sFuncao));
					unchecked
					{
						if (P_4 && P_2 % 2 != 0)
						{
							((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 15;
						}
						text = "D" + Conversions.ToString(P_2);
						((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + P_1[i].sVeia));
						if (P_2 % 2 != 0)
						{
							((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 15;
						}
						text = "E" + Conversions.ToString(P_2);
						((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + P_1[i].sPainel1));
						text = "F" + Conversions.ToString(P_2);
						((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + P_1[i].sDisp1));
						if (P_2 % 2 != 0)
						{
							((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 15;
						}
						text = "G" + Conversions.ToString(P_2);
						((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + P_1[i].sBorne1));
						if (P_2 % 2 != 0)
						{
							((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 15;
						}
						text = "H" + Conversions.ToString(P_2);
						((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + P_1[i].sAterrar1));
						if (P_2 % 2 != 0)
						{
							((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 15;
						}
						text = "I" + Conversions.ToString(P_2);
						((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + P_1[i].sPainel2));
						text = "J" + Conversions.ToString(P_2);
						((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + P_1[i].sDisp2));
						if (P_2 % 2 != 0)
						{
							((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 15;
						}
						text = "K" + Conversions.ToString(P_2);
						((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + P_1[i].sBorne2));
						if (P_2 % 2 != 0)
						{
							((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 15;
						}
						text = "L" + Conversions.ToString(P_2);
						((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + P_1[i].sAterrar2));
						if (P_2 % 2 != 0)
						{
							((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 15;
						}
						if (i == 1)
						{
							text = "M" + Conversions.ToString(P_2);
							((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + P_1[i].sDiagrama));
						}
						text = "N" + Conversions.ToString(P_2);
						((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + P_1[i].sPagina1));
						if (P_2 % 2 != 0)
						{
							((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 15;
						}
						if (P_5 && i == 1)
						{
							text = "O" + Conversions.ToString(P_2);
							((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + Conversions.ToString(P_1[i].dComprimento)));
						}
					}
					P_2++;
					string cell = "A" + Conversions.ToString(P_2 + 10);
					((_Worksheet)P_0).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
				}
				text = (P_5 ? ("A" + Conversions.ToString(num) + ":O" + Conversions.ToString(P_2 - 1)) : ("A" + Conversions.ToString(num) + ":N" + Conversions.ToString(P_2 - 1)));
				ExcFuncoesExcel.CriaLinhasInterna(ref P_0, text);
				ExcFuncoesExcel.CriaLinhasExterna(ref P_0, text, bCompleto: true);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}
}

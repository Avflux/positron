using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class Relatorios_FiacaoExcelEletronorte
{
	public struct ConfRelatorio
	{
		public short CorLinha;

		public short CorJumper;

		public short CorTexto;

		public double TamanhoFonte;

		public short QuantColunas;

		public double AlturaInicial;

		public double DistEntreColunas;

		public double AlturaDoBloco;

		public string sFonte;
	}

	public static void CriaMatrizFiacao_Excel(DeclaracoesFiacao.structureRelFiacao[] mFiacao, string sRelatorio, string sPainel, double qLinhas)
	{
		Application oExcelNew = null;
		Worksheet oSheet = null;
		checked
		{
			try
			{
				string oNomeSheet = sRelatorio + "_N_" + sPainel;
				ExcFuncoesExcel.VerificaExcel(ref oExcelNew, ref oSheet, oNomeSheet);
				if (Operators.CompareString(DeclaracoesGeral.companyHardlock.ToUpper(), "CADGRAPH", TextCompare: true) != 0)
				{
					ExcFuncoesExcel.DesativaCalculoExcel(ref oExcelNew);
				}
				((_Worksheet)oSheet).get_Range((object)"A1", (object)"Z10000").EntireRow.Delete(RuntimeHelpers.GetObjectValue(Missing.Value));
				oSheet.Cells.ClearComments();
				ExcFuncoesExcel.ApagaFigura(oNomeSheet);
				long num = 0L;
				int iLinhaInicial = 1;
				int iLinhaFinal = 1;
				int iLinhaTitulo = 0;
				bool flag = false;
				int num2 = 1;
				string text = "";
				string text2 = "";
				string text3 = "";
				mFiacao[0].Terminal = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 776]);
				mFiacao[0].Disp1 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 777]);
				mFiacao[0].Term1 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 778]);
				mFiacao[0].Disp2 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 779]);
				mFiacao[0].Term2 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 780]);
				mFiacao[0].Cor12 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 782]);
				mFiacao[0].Secao12 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 781]);
				mFiacao[0].Pagina12 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 783]);
				int num3 = Information.UBound(mFiacao);
				for (int i = 0; i <= num3; i++)
				{
					if (Operators.CompareString(mFiacao[i].Tag, null, TextCompare: true) == 0)
					{
						mFiacao[i].Tag = "";
					}
					if (Operators.CompareString(mFiacao[i].Jumper, null, TextCompare: true) == 0)
					{
						mFiacao[i].Jumper = "";
					}
					if (Operators.CompareString(mFiacao[i].Terminal, null, TextCompare: true) == 0)
					{
						mFiacao[i].Terminal = "";
					}
					if (Operators.CompareString(mFiacao[i].Disp1, null, TextCompare: true) == 0)
					{
						mFiacao[i].Disp1 = "";
					}
					if (Operators.CompareString(mFiacao[i].Term1, null, TextCompare: true) == 0)
					{
						mFiacao[i].Term1 = "";
					}
					if (Operators.CompareString(mFiacao[i].Disp2, null, TextCompare: true) == 0)
					{
						mFiacao[i].Disp2 = "";
					}
					if (Operators.CompareString(mFiacao[i].Term2, null, TextCompare: true) == 0)
					{
						mFiacao[i].Term2 = "";
					}
					if (Operators.CompareString(mFiacao[i].Disp3, null, TextCompare: true) == 0)
					{
						mFiacao[i].Disp3 = "";
					}
					if (Operators.CompareString(mFiacao[i].Term3, null, TextCompare: true) == 0)
					{
						mFiacao[i].Term3 = "";
					}
					if (Operators.CompareString(mFiacao[i].Disp4, null, TextCompare: true) == 0)
					{
						mFiacao[i].Disp4 = "";
					}
					if (Operators.CompareString(mFiacao[i].Term4, null, TextCompare: true) == 0)
					{
						mFiacao[i].Term4 = "";
					}
					if (Operators.CompareString(mFiacao[i].Cor12, null, TextCompare: true) == 0)
					{
						mFiacao[i].Cor12 = "";
					}
					if (Operators.CompareString(mFiacao[i].Secao12, null, TextCompare: true) == 0)
					{
						mFiacao[i].Secao12 = "";
					}
					if (Operators.CompareString(mFiacao[i].Pagina12, null, TextCompare: true) == 0)
					{
						mFiacao[i].Pagina12 = "";
					}
					if (Operators.CompareString(mFiacao[i].Cor34, null, TextCompare: true) == 0)
					{
						mFiacao[i].Cor34 = "";
					}
					if (Operators.CompareString(mFiacao[i].Secao34, null, TextCompare: true) == 0)
					{
						mFiacao[i].Secao34 = "";
					}
					if (Operators.CompareString(mFiacao[i].Pagina34, null, TextCompare: true) == 0)
					{
						mFiacao[i].Pagina34 = "";
					}
				}
				text = "A1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "B1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "C1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "D1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "E1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "F1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "G1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 8;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "H1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 8;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				int iLinhaRelatorio = (int)num;
				CriaCabecalho(ref oSheet, mFiacao, ref iLinhaRelatorio, ref iLinhaFinal, ref iLinhaTitulo, ref iLinhaInicial);
				num = iLinhaRelatorio;
				DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mFiacao);
				DeclaracoesGeral._uscPagina.pbIniciar();
				int num4 = Information.UBound(mFiacao);
				for (int j = 1; j <= num4; j++)
				{
					if (Operators.CompareString(mFiacao[j - 1].Tag, "", TextCompare: true) != 0)
					{
						text2 = mFiacao[j - 1].Tag;
					}
					text3 = "A" + Conversions.ToString(num + 2L);
					((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
					if ((Operators.CompareString(mFiacao[j - 1].Tag, "", TextCompare: true) != 0) & ((double)num2 * qLinhas - (double)num < 2.0))
					{
						num = (long)Math.Round((double)num2 * qLinhas + 1.0);
						flag = true;
					}
					if (((double)num > (double)num2 * qLinhas) | flag)
					{
						num--;
						iLinhaRelatorio = (int)num;
						CriaCabecalho(ref oSheet, mFiacao, ref iLinhaRelatorio, ref iLinhaFinal, ref iLinhaTitulo, ref iLinhaInicial);
						num = iLinhaRelatorio;
						num2++;
						flag = true;
					}
					if ((Operators.CompareString(mFiacao[j - 1].Tag, "", TextCompare: true) != 0) | flag)
					{
						string sTituloCorrente = text2;
						iLinhaRelatorio = (int)num;
						Criatitulo(ref oSheet, sTituloCorrente, ref iLinhaRelatorio, ref iLinhaFinal, ref iLinhaInicial);
						num = iLinhaRelatorio;
						flag = false;
					}
					int iIndice = j;
					iLinhaRelatorio = (int)num;
					Crialinha(ref oSheet, mFiacao, iIndice, ref iLinhaRelatorio, ref iLinhaFinal);
					num = iLinhaRelatorio;
					num++;
					DeclaracoesGeral._uscPagina.pbPasso();
				}
				text = "A" + Conversions.ToString(iLinhaInicial) + ":H" + Conversions.ToString(iLinhaFinal);
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
				ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
				text3 = "A1";
				((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
				ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
				DeclaracoesGeral._uscPagina.pbFim();
			}
		}
	}

	public static void CriaCabecalho(ref Worksheet oSheet, DeclaracoesFiacao.structureRelFiacao[] mFiacao, ref int iLinhaRelatorio, ref int iLinhaFinal, ref int iLinhaTitulo, ref int iLinhaInicial)
	{
		string text = "";
		checked
		{
			iLinhaRelatorio++;
			text = "A" + Conversions.ToString(iLinhaRelatorio);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Terminal));
			text = "B" + Conversions.ToString(iLinhaRelatorio);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Disp1));
			text = "C" + Conversions.ToString(iLinhaRelatorio);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Term1));
			text = "D" + Conversions.ToString(iLinhaRelatorio);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Disp2));
			text = "E" + Conversions.ToString(iLinhaRelatorio);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Term2));
			text = "F" + Conversions.ToString(iLinhaRelatorio);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Secao12));
			text = "G" + Conversions.ToString(iLinhaRelatorio);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Cor12));
			text = "H" + Conversions.ToString(iLinhaRelatorio);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Pagina12));
			text = "A" + Conversions.ToString(iLinhaRelatorio) + ":H" + Conversions.ToString(iLinhaRelatorio);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
			ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
			ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
			if (iLinhaFinal > 1)
			{
				text = "A" + Conversions.ToString(iLinhaInicial) + ":H" + Conversions.ToString(iLinhaFinal);
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
				ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
			}
			iLinhaRelatorio++;
		}
	}

	public static void Criatitulo(ref Worksheet oSheet, string sTituloCorrente, ref int iLinhaRelatorio, ref int iLinhaFinal, ref int iLinhaInicial)
	{
		string text = "";
		if ((iLinhaInicial != 1) | (iLinhaFinal != 1))
		{
			text = "A" + Conversions.ToString(iLinhaInicial) + ":H" + Conversions.ToString(iLinhaFinal);
			ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
			ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
		}
		checked
		{
			iLinhaRelatorio++;
			text = "A" + Conversions.ToString(iLinhaRelatorio);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + sTituloCorrente));
			text = "A" + Conversions.ToString(iLinhaRelatorio) + ":A" + Conversions.ToString(iLinhaRelatorio);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 12;
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
			ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
			iLinhaRelatorio++;
			iLinhaInicial = iLinhaRelatorio;
		}
	}

	public static void Crialinha(ref Worksheet oSheet, DeclaracoesFiacao.structureRelFiacao[] mFiacao, int iIndice, ref int iLinhaRelatorio, ref int iLinhaFinal)
	{
		string cell = "A" + Conversions.ToString(iLinhaRelatorio);
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[iIndice].Terminal));
		cell = "B" + Conversions.ToString(iLinhaRelatorio);
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[iIndice].Disp1));
		cell = "C" + Conversions.ToString(iLinhaRelatorio);
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[iIndice].Term1));
		cell = "D" + Conversions.ToString(iLinhaRelatorio);
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[iIndice].Disp2));
		cell = "E" + Conversions.ToString(iLinhaRelatorio);
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[iIndice].Term2));
		cell = "F" + Conversions.ToString(iLinhaRelatorio);
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[iIndice].Secao12));
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
		cell = "G" + Conversions.ToString(iLinhaRelatorio);
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[iIndice].Cor12));
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
		cell = "H" + Conversions.ToString(iLinhaRelatorio);
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[iIndice].Pagina12));
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
		iLinhaFinal = iLinhaRelatorio;
	}

	public static void CriaMatrizFiacaoBorne_Excel(DeclaracoesFiacao.structureRelFiacao[] mFiacao, string sRelatorio, string sPainel, int iQuantLinhas)
	{
		checked
		{
			try
			{
				Application oExcelNew = null;
				Worksheet oSheet = null;
				string oNomeSheet = sRelatorio + "_N_" + sPainel;
				string text = "";
				ExcFuncoesExcel.VerificaExcel(ref oExcelNew, ref oSheet, oNomeSheet);
				((_Worksheet)oSheet).get_Range((object)"A1", (object)"Z10000").EntireRow.Delete(RuntimeHelpers.GetObjectValue(Missing.Value));
				oSheet.Cells.ClearComments();
				ExcFuncoesExcel.ApagaFigura(oNomeSheet);
				long num = 1L;
				int num2 = 1;
				int num3 = 1;
				int num4 = 0;
				string text2 = "";
				int num5 = 1;
				mFiacao[0].Terminal = DeclaracoesGeral.mMensagem[1, 776].ToString();
				mFiacao[0].Disp1 = DeclaracoesGeral.mMensagem[1, 777].ToString();
				mFiacao[0].Term1 = DeclaracoesGeral.mMensagem[1, 778].ToString();
				mFiacao[0].Disp2 = DeclaracoesGeral.mMensagem[1, 779].ToString();
				mFiacao[0].Term2 = DeclaracoesGeral.mMensagem[1, 780].ToString();
				mFiacao[0].Cor12 = DeclaracoesGeral.mMensagem[1, 782].ToString();
				mFiacao[0].Secao12 = DeclaracoesGeral.mMensagem[1, 781].ToString();
				mFiacao[0].Pagina12 = DeclaracoesGeral.mMensagem[1, 783].ToString();
				int num6 = Information.UBound(mFiacao);
				for (int i = 0; i <= num6; i++)
				{
					if (Operators.CompareString(mFiacao[i].Tag, null, TextCompare: true) == 0)
					{
						mFiacao[i].Tag = "";
					}
					if (Operators.CompareString(mFiacao[i].Jumper, null, TextCompare: true) == 0)
					{
						mFiacao[i].Jumper = "";
					}
					if (Operators.CompareString(mFiacao[i].Terminal, null, TextCompare: true) == 0)
					{
						mFiacao[i].Terminal = "";
					}
					if (Operators.CompareString(mFiacao[i].Disp1, null, TextCompare: true) == 0)
					{
						mFiacao[i].Disp1 = "";
					}
					if (Operators.CompareString(mFiacao[i].Term1, null, TextCompare: true) == 0)
					{
						mFiacao[i].Term1 = "";
					}
					if (Operators.CompareString(mFiacao[i].Disp2, null, TextCompare: true) == 0)
					{
						mFiacao[i].Disp2 = "";
					}
					if (Operators.CompareString(mFiacao[i].Term2, null, TextCompare: true) == 0)
					{
						mFiacao[i].Term2 = "";
					}
					if (Operators.CompareString(mFiacao[i].Disp3, null, TextCompare: true) == 0)
					{
						mFiacao[i].Disp3 = "";
					}
					if (Operators.CompareString(mFiacao[i].Term3, null, TextCompare: true) == 0)
					{
						mFiacao[i].Term3 = "";
					}
					if (Operators.CompareString(mFiacao[i].Disp4, null, TextCompare: true) == 0)
					{
						mFiacao[i].Disp4 = "";
					}
					if (Operators.CompareString(mFiacao[i].Term4, null, TextCompare: true) == 0)
					{
						mFiacao[i].Term4 = "";
					}
					if (Operators.CompareString(mFiacao[i].Cor12, null, TextCompare: true) == 0)
					{
						mFiacao[i].Cor12 = "";
					}
					if (Operators.CompareString(mFiacao[i].Secao12, null, TextCompare: true) == 0)
					{
						mFiacao[i].Secao12 = "";
					}
					if (Operators.CompareString(mFiacao[i].Pagina12, null, TextCompare: true) == 0)
					{
						mFiacao[i].Pagina12 = "";
					}
					if (Operators.CompareString(mFiacao[i].Cor34, null, TextCompare: true) == 0)
					{
						mFiacao[i].Cor34 = "";
					}
					if (Operators.CompareString(mFiacao[i].Secao34, null, TextCompare: true) == 0)
					{
						mFiacao[i].Secao34 = "";
					}
					if (Operators.CompareString(mFiacao[i].Pagina34, null, TextCompare: true) == 0)
					{
						mFiacao[i].Pagina34 = "";
					}
					if (Operators.CompareString(mFiacao[i].Tag, "##B##", TextCompare: true) == 0)
					{
						mFiacao[i].Tag = "";
					}
					if (Operators.CompareString(mFiacao[i].Jumper, "##B##", TextCompare: true) == 0)
					{
						mFiacao[i].Jumper = "";
					}
					if (Operators.CompareString(mFiacao[i].Terminal, "##B##", TextCompare: true) == 0)
					{
						mFiacao[i].Terminal = "";
					}
					if (Operators.CompareString(mFiacao[i].Disp1, "##B##", TextCompare: true) == 0)
					{
						mFiacao[i].Disp1 = "";
					}
					if (Operators.CompareString(mFiacao[i].Term1, "##B##", TextCompare: true) == 0)
					{
						mFiacao[i].Term1 = "";
					}
					if (Operators.CompareString(mFiacao[i].Disp2, "##B##", TextCompare: true) == 0)
					{
						mFiacao[i].Disp2 = "";
					}
					if (Operators.CompareString(mFiacao[i].Term2, "##B##", TextCompare: true) == 0)
					{
						mFiacao[i].Term2 = "";
					}
					if (Operators.CompareString(mFiacao[i].Disp3, "##B##", TextCompare: true) == 0)
					{
						mFiacao[i].Disp3 = "";
					}
					if (Operators.CompareString(mFiacao[i].Term3, "##B##", TextCompare: true) == 0)
					{
						mFiacao[i].Term3 = "";
					}
					if (Operators.CompareString(mFiacao[i].Disp4, "##B##", TextCompare: true) == 0)
					{
						mFiacao[i].Disp4 = "";
					}
					if (Operators.CompareString(mFiacao[i].Term4, "##B##", TextCompare: true) == 0)
					{
						mFiacao[i].Term4 = "";
					}
					if (Operators.CompareString(mFiacao[i].Cor12, "##B##", TextCompare: true) == 0)
					{
						mFiacao[i].Cor12 = "";
					}
					if (Operators.CompareString(mFiacao[i].Secao12, "##B##", TextCompare: true) == 0)
					{
						mFiacao[i].Secao12 = "";
					}
					if (Operators.CompareString(mFiacao[i].Pagina12, "##B##", TextCompare: true) == 0)
					{
						mFiacao[i].Pagina12 = "";
					}
					if (Operators.CompareString(mFiacao[i].Cor34, "##B##", TextCompare: true) == 0)
					{
						mFiacao[i].Cor34 = "";
					}
					if (Operators.CompareString(mFiacao[i].Secao34, "##B##", TextCompare: true) == 0)
					{
						mFiacao[i].Secao34 = "";
					}
					if (Operators.CompareString(mFiacao[i].Pagina34, "##B##", TextCompare: true) == 0)
					{
						mFiacao[i].Pagina34 = "";
					}
				}
				((_Worksheet)oSheet).get_Range((object)"A1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 1;
				((_Worksheet)oSheet).get_Range((object)"B1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 0.6;
				((_Worksheet)oSheet).get_Range((object)"C1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				((_Worksheet)oSheet).get_Range((object)"D1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 0.6;
				((_Worksheet)oSheet).get_Range((object)"E1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 1;
				((_Worksheet)oSheet).get_Range((object)"F1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
				((_Worksheet)oSheet).get_Range((object)"G1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
				((_Worksheet)oSheet).get_Range((object)"H1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
				((_Worksheet)oSheet).get_Range((object)"I1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
				((_Worksheet)oSheet).get_Range((object)"J1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				((_Worksheet)oSheet).get_Range((object)"K1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 6;
				((_Worksheet)oSheet).get_Range((object)"L1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 8;
				text2 = "A1:E2";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 9;
				text2 = "A" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Terminal));
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text2 = "F" + Conversions.ToString(num) + ":F" + Conversions.ToString(num + 1L);
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Disp1));
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text2 = "G" + Conversions.ToString(num) + ":G" + Conversions.ToString(num + 1L);
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Term1));
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text2 = "H" + Conversions.ToString(num) + ":H" + Conversions.ToString(num + 1L);
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Disp2));
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text2 = "I" + Conversions.ToString(num) + ":I" + Conversions.ToString(num + 1L);
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Term2));
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text2 = "J" + Conversions.ToString(num) + ":J" + Conversions.ToString(num + 1L);
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Secao12));
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text2 = "K" + Conversions.ToString(num) + ":K" + Conversions.ToString(num + 1L);
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Cor12));
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text2 = "L" + Conversions.ToString(num) + ":L" + Conversions.ToString(num + 1L);
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Pagina12));
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text2 = "A" + Conversions.ToString(num) + ":L" + Conversions.ToString(num + 1L);
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text2);
				ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text2, bCompleto: true);
				num += 2L;
				text2 = "A" + Conversions.ToString(num) + ":A" + Conversions.ToString(num + 1L);
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 9;
				num += 2L;
				text2 = "A" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Tag));
				text2 = "A" + Conversions.ToString(num) + ":E" + Conversions.ToString(num + 1L);
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 9;
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 12;
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text2, bCompleto: true);
				num += 2L;
				num3 = (int)num;
				num2 = (int)num;
				DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mFiacao);
				DeclaracoesGeral._uscPagina.pbIniciar();
				int num7 = Information.UBound(mFiacao);
				for (int j = 1; j <= num7; DeclaracoesGeral._uscPagina.pbPasso(), j++)
				{
					text = "A" + Conversions.ToString(num + 2L);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
					int num8 = 0;
					num8 = ((j == 0) ? j : (j - 1));
					if ((Operators.CompareString(mFiacao[num8].Tag, "", TextCompare: true) != 0) & (num8 > 0))
					{
						text2 = "A" + Conversions.ToString(num) + ":E" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 9;
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[num8].Tag));
						num4 = num8;
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 12;
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text2, bCompleto: true);
						num += 2L;
						num3 = (int)num;
						num2 = (int)num;
						if (j == 0)
						{
							continue;
						}
					}
					if (mFiacao[j].TipoBorne == 1)
					{
						text2 = "A" + Conversions.ToString(num) + ":L" + Conversions.ToString(num + 3L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 9;
						text2 = "A" + Conversions.ToString(num) + ":A" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text2 = "A" + Conversions.ToString(num + 2L) + ":A" + Conversions.ToString(num + 3L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text2 = "B" + Conversions.ToString(num) + ":B" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text2 = "B" + Conversions.ToString(num + 2L) + ":B" + Conversions.ToString(num + 3L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text2 = "C" + Conversions.ToString(num) + ":C" + Conversions.ToString(num + 3L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text2 = "D" + Conversions.ToString(num) + ":D" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text2 = "D" + Conversions.ToString(num + 2L) + ":D" + Conversions.ToString(num + 3L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text2 = "E" + Conversions.ToString(num) + ":E" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text2 = "E" + Conversions.ToString(num + 2L) + ":E" + Conversions.ToString(num + 3L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text2 = "F" + Conversions.ToString(num) + ":F" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text2 = "G" + Conversions.ToString(num) + ":G" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text2 = "H" + Conversions.ToString(num) + ":H" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text2 = "I" + Conversions.ToString(num) + ":I" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text2 = "J" + Conversions.ToString(num) + ":J" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text2 = "K" + Conversions.ToString(num) + ":K" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text2 = "L" + Conversions.ToString(num) + ":L" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text2 = "F" + Conversions.ToString(num + 2L) + ":F" + Conversions.ToString(num + 3L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text2 = "G" + Conversions.ToString(num + 2L) + ":G" + Conversions.ToString(num + 3L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text2 = "H" + Conversions.ToString(num + 2L) + ":H" + Conversions.ToString(num + 3L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text2 = "I" + Conversions.ToString(num + 2L) + ":I" + Conversions.ToString(num + 3L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text2 = "J" + Conversions.ToString(num + 2L) + ":J" + Conversions.ToString(num + 3L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text2 = "K" + Conversions.ToString(num + 2L) + ":K" + Conversions.ToString(num + 3L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text2 = "L" + Conversions.ToString(num + 2L) + ":L" + Conversions.ToString(num + 3L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text2 = "A" + Conversions.ToString(num) + ":L" + Conversions.ToString(num + 3L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text2);
						text2 = "A" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"o");
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 1;
						text2 = "A" + Conversions.ToString(num + 2L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"o");
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 1;
						text2 = "C" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Terminal));
						if (Operators.CompareString(mFiacao[j].Jumper, "U", TextCompare: true) == 0)
						{
							text2 = "D" + Conversions.ToString(num);
							ExcFuncoesExcel.SetarCorCelula(ref oSheet, text2);
						}
						if (Operators.CompareString(mFiacao[j].Jumper, "D", TextCompare: true) == 0)
						{
							text2 = "D" + Conversions.ToString(num + 2L);
							ExcFuncoesExcel.SetarCorCelula(ref oSheet, text2);
						}
						if (Operators.CompareString(mFiacao[j].Jumper, "UD", TextCompare: true) == 0)
						{
							text2 = "D" + Conversions.ToString(num) + ":D" + Conversions.ToString(num + 3L);
							ExcFuncoesExcel.SetarCorCelula(ref oSheet, text2);
						}
						text2 = "E" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"o");
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 1;
						text2 = "E" + Conversions.ToString(num + 2L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"o");
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 1;
						text2 = "F" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Disp1.ToString()));
						text2 = "G" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Term1.ToString()));
						text2 = "H" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Disp2.ToString()));
						text2 = "I" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Term2.ToString()));
						text2 = "J" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Secao12.ToString()));
						text2 = "K" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Cor12.ToString()));
						text2 = "L" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Pagina12.ToString()));
						if (mFiacao[j].TipoBorne == 1)
						{
							text2 = "F" + Conversions.ToString(num + 2L);
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Disp3.ToString()));
							text2 = "G" + Conversions.ToString(num + 2L);
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Term3.ToString()));
							text2 = "H" + Conversions.ToString(num + 2L);
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Disp4.ToString()));
							text2 = "I" + Conversions.ToString(num + 2L);
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Term4.ToString()));
							text2 = "J" + Conversions.ToString(num + 2L);
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Secao34.ToString()));
							text2 = "K" + Conversions.ToString(num + 2L);
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Cor34.ToString()));
							text2 = "L" + Conversions.ToString(num + 2L);
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Pagina34.ToString()));
						}
						num3 = (int)(num + 3L);
						num += 4L;
					}
					if (mFiacao[j].TipoBorne == 0)
					{
						text2 = "A" + Conversions.ToString(num) + ":L" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 9;
						text2 = "A" + Conversions.ToString(num) + ":A" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text2 = "C" + Conversions.ToString(num) + ":C" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text2 = "E" + Conversions.ToString(num) + ":E" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text2 = "F" + Conversions.ToString(num) + ":F" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text2 = "G" + Conversions.ToString(num) + ":G" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text2 = "H" + Conversions.ToString(num) + ":H" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text2 = "I" + Conversions.ToString(num) + ":I" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text2 = "J" + Conversions.ToString(num) + ":J" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text2 = "K" + Conversions.ToString(num) + ":K" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text2 = "L" + Conversions.ToString(num) + ":L" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						text2 = "A" + Conversions.ToString(num) + ":L" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text2);
						text2 = "A" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 1;
						text2 = "A" + Conversions.ToString(num + 2L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 1;
						text2 = "A" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"o");
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 1;
						text2 = "C" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Terminal));
						if (Operators.CompareString(mFiacao[j].Jumper, "U", TextCompare: true) == 0)
						{
							text2 = "D" + Conversions.ToString(num);
							ExcFuncoesExcel.SetarCorCelula(ref oSheet, text2);
						}
						if (Operators.CompareString(mFiacao[j].Jumper, "D", TextCompare: true) == 0)
						{
							text2 = "D" + Conversions.ToString(num + 1L);
							ExcFuncoesExcel.SetarCorCelula(ref oSheet, text2);
						}
						if (Operators.CompareString(mFiacao[j].Jumper, "UD", TextCompare: true) == 0)
						{
							text2 = "D" + Conversions.ToString(num) + ":D" + Conversions.ToString(num + 1L);
							ExcFuncoesExcel.SetarCorCelula(ref oSheet, text2);
						}
						text2 = "E" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"o");
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 1;
						text2 = "F" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Disp1));
						text2 = "G" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Term1));
						text2 = "H" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Disp2));
						text2 = "I" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Term2));
						text2 = "J" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Secao12));
						text2 = "K" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Cor12));
						text2 = "L" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Pagina12));
						num3 = (int)(num + 1L);
						num += 2L;
						text2 = "A" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						text2 = "E" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					}
					int num9 = num5 * iQuantLinhas * 2 + 1;
					bool flag = false;
					if (j <= Information.UBound(mFiacao) - 1)
					{
						if (mFiacao[j + 1].TipoBorne != 0)
						{
							if (num + 4L > num9)
							{
								flag = true;
							}
						}
						else if (num + 2L > num9)
						{
							flag = true;
						}
					}
					if (flag)
					{
						text2 = "A" + Conversions.ToString(num2) + ":L" + Conversions.ToString(num3);
						ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text2, bCompleto: true);
						text2 = "A" + Conversions.ToString(num) + ":A" + Conversions.ToString(num9 - 1);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 9;
						if (num < num9)
						{
							num = num9;
						}
						text2 = "A" + Conversions.ToString(num) + ":E" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Terminal));
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						text2 = "F" + Conversions.ToString(num) + ":F" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Disp1));
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						text2 = "G" + Conversions.ToString(num) + ":G" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Term1));
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						text2 = "H" + Conversions.ToString(num) + ":H" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Disp2));
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						text2 = "I" + Conversions.ToString(num) + ":I" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Term2));
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						text2 = "J" + Conversions.ToString(num) + ":J" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Secao12));
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						text2 = "K" + Conversions.ToString(num) + ":K" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Cor12));
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						text2 = "L" + Conversions.ToString(num) + ":L" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[0].Pagina12));
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						text2 = "A" + Conversions.ToString(num) + ":L" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 9;
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
						ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text2);
						ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text2, bCompleto: true);
						num += 2L;
						text2 = "A" + Conversions.ToString(num) + ":A" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 9;
						num += 2L;
						text2 = "A" + Conversions.ToString(num) + ":E" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 9;
						if (Operators.CompareString(mFiacao[j].Tag, "", TextCompare: true) == 0)
						{
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[num4].Tag));
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 12;
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
							ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text2, bCompleto: true);
							num += 2L;
							num2 = (int)num;
							num5++;
						}
						else
						{
							num2 = (int)num;
							num5++;
						}
					}
					if (j < Information.UBound(mFiacao))
					{
						num8 = j;
					}
					if (Operators.CompareString(mFiacao[num8].Tag, "", TextCompare: true) != 0)
					{
						text2 = "A" + Conversions.ToString(num2) + ":L" + Conversions.ToString(num3);
						ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text2, bCompleto: true);
						text2 = "A" + Conversions.ToString(num) + ":L" + Conversions.ToString(num + 1L);
						((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 9;
						num += 2L;
						num2 = (int)num;
						num3 = (int)num;
					}
				}
				text2 = "A" + Conversions.ToString(num2) + ":L" + Conversions.ToString(num3);
				ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text2, bCompleto: true);
				text2 = "A1:L" + Conversions.ToString(num3);
				ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text2, bCompleto: true);
				ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
				text = "A1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
				DeclaracoesGeral._uscPagina.pbFim();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void CriaMatrizFiacaoFurnas_Excel(DeclaracoesFiacao.structureRelFiacao[] mFiacao, string sRelatorio, string sPainel, double qLinhas, int iTipoAnilha, string sSeparadorDisp, string sSeparador)
	{
		Application oExcelNew = null;
		Worksheet oSheet = null;
		checked
		{
			try
			{
				string oNomeSheet = sRelatorio + "_F_" + sPainel;
				ExcFuncoesExcel.VerificaExcel(ref oExcelNew, ref oSheet, oNomeSheet);
				((_Worksheet)oSheet).get_Range((object)"A1", (object)"Z10000").EntireRow.Delete(RuntimeHelpers.GetObjectValue(Missing.Value));
				oSheet.Cells.ClearComments();
				ExcFuncoesExcel.ApagaFigura(oNomeSheet);
				long num = 1L;
				int num2 = 1;
				int num3 = 1;
				int num4 = 1;
				string text = "";
				string text2 = "";
				mFiacao[0].Terminal = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 776]);
				mFiacao[0].Disp1 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 777]);
				mFiacao[0].Term1 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 778]);
				mFiacao[0].Disp2 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 779]);
				mFiacao[0].Term2 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 780]);
				mFiacao[0].Cor12 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 782]);
				mFiacao[0].Secao12 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 781]);
				mFiacao[0].Pagina12 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 783]);
				int num5 = Information.UBound(mFiacao);
				for (int i = 0; i <= num5; i++)
				{
					if (Operators.CompareString(mFiacao[i].Tag, null, TextCompare: true) == 0)
					{
						mFiacao[i].Tag = "";
					}
					if (Operators.CompareString(mFiacao[i].Jumper, null, TextCompare: true) == 0)
					{
						mFiacao[i].Jumper = "";
					}
					if (Operators.CompareString(mFiacao[i].Terminal, null, TextCompare: true) == 0)
					{
						mFiacao[i].Terminal = "";
					}
					if (Operators.CompareString(mFiacao[i].Disp1, null, TextCompare: true) == 0)
					{
						mFiacao[i].Disp1 = "";
					}
					if (Operators.CompareString(mFiacao[i].Term1, null, TextCompare: true) == 0)
					{
						mFiacao[i].Term1 = "";
					}
					if (Operators.CompareString(mFiacao[i].Disp2, null, TextCompare: true) == 0)
					{
						mFiacao[i].Disp2 = "";
					}
					if (Operators.CompareString(mFiacao[i].Term2, null, TextCompare: true) == 0)
					{
						mFiacao[i].Term2 = "";
					}
					if (Operators.CompareString(mFiacao[i].Disp3, null, TextCompare: true) == 0)
					{
						mFiacao[i].Disp3 = "";
					}
					if (Operators.CompareString(mFiacao[i].Term3, null, TextCompare: true) == 0)
					{
						mFiacao[i].Term3 = "";
					}
					if (Operators.CompareString(mFiacao[i].Disp4, null, TextCompare: true) == 0)
					{
						mFiacao[i].Disp4 = "";
					}
					if (Operators.CompareString(mFiacao[i].Term4, null, TextCompare: true) == 0)
					{
						mFiacao[i].Term4 = "";
					}
					if (Operators.CompareString(mFiacao[i].Cor12, null, TextCompare: true) == 0)
					{
						mFiacao[i].Cor12 = "";
					}
					if (Operators.CompareString(mFiacao[i].Secao12, null, TextCompare: true) == 0)
					{
						mFiacao[i].Secao12 = "";
					}
					if (Operators.CompareString(mFiacao[i].Pagina12, null, TextCompare: true) == 0)
					{
						mFiacao[i].Pagina12 = "";
					}
					if (Operators.CompareString(mFiacao[i].Cor34, null, TextCompare: true) == 0)
					{
						mFiacao[i].Cor34 = "";
					}
					if (Operators.CompareString(mFiacao[i].Secao34, null, TextCompare: true) == 0)
					{
						mFiacao[i].Secao34 = "";
					}
					if (Operators.CompareString(mFiacao[i].Pagina34, null, TextCompare: true) == 0)
					{
						mFiacao[i].Pagina34 = "";
					}
				}
				int num6 = (int)num;
				SSXpnYIMyaC(ref oSheet, ref num6, iTipoAnilha);
				num = num6;
				num3 = (int)num;
				num2 = 0;
				num3 = 0;
				num3 = (int)num;
				num2 = (int)num;
				string tag = mFiacao[0].Tag;
				DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mFiacao);
				DeclaracoesGeral._uscPagina.pbIniciar();
				int num7 = Information.UBound(mFiacao);
				for (int j = 1; j <= num7; j++)
				{
					text2 = "A" + Conversions.ToString(num + 2L);
					((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
					int num8 = 0;
					num8 = ((j == 0) ? j : (j - 1));
					text = "A" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + tag));
					text = "B" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Terminal));
					if (iTipoAnilha != 1)
					{
						if (iTipoAnilha != 2)
						{
							if (iTipoAnilha == 3)
							{
								if ((Operators.CompareString(tag, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Terminal, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Disp1, "", TextCompare: true) != 0))
								{
									text = "C" + Conversions.ToString(num);
									((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + tag + sSeparador + mFiacao[j].Terminal + sSeparadorDisp + mFiacao[j].Disp1 + sSeparador + mFiacao[j].Term1));
								}
								if ((Operators.CompareString(tag, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Terminal, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Disp2, "", TextCompare: true) != 0))
								{
									text = "D" + Conversions.ToString(num);
									((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + tag + sSeparador + mFiacao[j].Terminal + sSeparadorDisp + mFiacao[j].Disp2 + sSeparador + mFiacao[j].Term2));
								}
							}
						}
						else
						{
							if ((Operators.CompareString(mFiacao[j].Disp1, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Term1, "", TextCompare: true) != 0))
							{
								text = "C" + Conversions.ToString(num);
								((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Disp1 + sSeparador + mFiacao[j].Term1));
							}
							if ((Operators.CompareString(mFiacao[j].Disp2, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Term2, "", TextCompare: true) != 0))
							{
								text = "D" + Conversions.ToString(num);
								((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Disp2 + sSeparador + mFiacao[j].Term2));
							}
						}
					}
					else
					{
						if ((Operators.CompareString(tag, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Terminal, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Disp1, "", TextCompare: true) != 0))
						{
							text = "C" + Conversions.ToString(num);
							((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + tag + sSeparador + mFiacao[j].Terminal));
						}
						if ((Operators.CompareString(tag, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Terminal, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Disp2, "", TextCompare: true) != 0))
						{
							text = "D" + Conversions.ToString(num);
							((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + tag + sSeparador + mFiacao[j].Terminal));
						}
					}
					text = "E" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Disp1));
					text = "F" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Term1));
					if (iTipoAnilha != 1)
					{
						if (iTipoAnilha != 2)
						{
							if (iTipoAnilha == 3 && ((Operators.CompareString(tag, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Terminal, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Disp1, "", TextCompare: true) != 0)))
							{
								text = "G" + Conversions.ToString(num);
								((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Disp1 + sSeparador + mFiacao[j].Term1 + sSeparadorDisp + tag + sSeparador + mFiacao[j].Terminal));
							}
						}
						else if ((Operators.CompareString(tag, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Terminal, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Disp1, "", TextCompare: true) != 0))
						{
							text = "G" + Conversions.ToString(num);
							((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + tag + sSeparador + mFiacao[j].Terminal));
						}
					}
					else if ((Operators.CompareString(mFiacao[j].Disp1, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Term1, "", TextCompare: true) != 0))
					{
						text = "G" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Disp1 + sSeparador + mFiacao[j].Term1));
					}
					text = "H" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Disp2));
					text = "I" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Term2));
					if (iTipoAnilha != 1)
					{
						if (iTipoAnilha != 2)
						{
							if (iTipoAnilha == 3 && ((Operators.CompareString(tag, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Terminal, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Disp2, "", TextCompare: true) != 0)))
							{
								text = "J" + Conversions.ToString(num);
								((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Disp2 + sSeparador + mFiacao[j].Term2 + sSeparadorDisp + tag + sSeparador + mFiacao[j].Terminal));
							}
						}
						else if ((Operators.CompareString(tag, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Terminal, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Disp2, "", TextCompare: true) != 0))
						{
							text = "j" + Conversions.ToString(num);
							((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + tag + sSeparador + mFiacao[j].Terminal));
						}
					}
					else if ((Operators.CompareString(mFiacao[j].Disp2, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Term2, "", TextCompare: true) != 0))
					{
						text = "J" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Disp2 + sSeparador + mFiacao[j].Term2));
					}
					text = "K" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Cor12));
					text = "L" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Secao12));
					text = "M" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Pagina12));
					text = "N" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Circuito));
					text = "A" + Conversions.ToString(num) + ":N" + Conversions.ToString(num);
					ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
					text = "A" + Conversions.ToString(num) + ":N" + Conversions.ToString(num + 2L);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					if (((Operators.CompareString(mFiacao[j].Disp3, "", TextCompare: true) != 0) | (Operators.CompareString(mFiacao[j].Disp4, "", TextCompare: true) != 0)) && mFiacao[j].TipoBorne == 1)
					{
						num++;
						text = "A" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + tag));
						text = "B" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Terminal));
						if (iTipoAnilha != 1)
						{
							if (iTipoAnilha != 2)
							{
								if (iTipoAnilha == 3)
								{
									if ((Operators.CompareString(tag, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Terminal, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Disp3, "", TextCompare: true) != 0))
									{
										text = "C" + Conversions.ToString(num);
										((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + tag + sSeparador + mFiacao[j].Terminal + sSeparadorDisp + mFiacao[j].Disp3 + sSeparador + mFiacao[j].Term3));
									}
									if ((Operators.CompareString(tag, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Terminal, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Disp4, "", TextCompare: true) != 0))
									{
										text = "D" + Conversions.ToString(num);
										((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + tag + sSeparador + mFiacao[j].Terminal + sSeparadorDisp + mFiacao[j].Disp4 + sSeparador + mFiacao[j].Term4));
									}
								}
							}
							else
							{
								if ((Operators.CompareString(mFiacao[j].Disp1, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Term3, "", TextCompare: true) != 0))
								{
									text = "C" + Conversions.ToString(num);
									((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Disp1 + sSeparador + mFiacao[j].Term3));
								}
								if ((Operators.CompareString(mFiacao[j].Disp2, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Term4, "", TextCompare: true) != 0))
								{
									text = "D" + Conversions.ToString(num);
									((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Disp2 + sSeparador + mFiacao[j].Term4));
								}
							}
						}
						else
						{
							if ((Operators.CompareString(tag, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Terminal, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Disp3, "", TextCompare: true) != 0))
							{
								text = "C" + Conversions.ToString(num);
								((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + tag + sSeparador + mFiacao[j].Terminal));
							}
							if ((Operators.CompareString(tag, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Terminal, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Disp4, "", TextCompare: true) != 0))
							{
								text = "D" + Conversions.ToString(num);
								((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + tag + sSeparador + mFiacao[j].Terminal));
							}
						}
						text = "E" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Disp3));
						text = "F" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Term3));
						if (iTipoAnilha != 1)
						{
							if (iTipoAnilha != 2)
							{
								if (iTipoAnilha == 3 && ((Operators.CompareString(tag, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Terminal, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Disp3, "", TextCompare: true) != 0)))
								{
									text = "G" + Conversions.ToString(num);
									((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Disp3 + sSeparador + mFiacao[j].Term3 + sSeparadorDisp + tag + sSeparador + mFiacao[j].Terminal));
								}
							}
							else if ((Operators.CompareString(tag, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Terminal, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Disp3, "", TextCompare: true) != 0))
							{
								text = "G" + Conversions.ToString(num);
								((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + tag + sSeparador + mFiacao[j].Terminal));
							}
						}
						else if ((Operators.CompareString(mFiacao[j].Disp3, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Term3, "", TextCompare: true) != 0))
						{
							text = "G" + Conversions.ToString(num);
							((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Disp3 + sSeparador + mFiacao[j].Term3));
						}
						text = "H" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Disp4));
						text = "I" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Term4));
						if (iTipoAnilha != 1)
						{
							if (iTipoAnilha != 2)
							{
								if (iTipoAnilha == 3 && ((Operators.CompareString(tag, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Terminal, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Disp4, "", TextCompare: true) != 0)))
								{
									text = "J" + Conversions.ToString(num);
									((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Disp4 + sSeparador + mFiacao[j].Term4 + sSeparadorDisp + tag + sSeparador + mFiacao[j].Terminal));
								}
							}
							else if ((Operators.CompareString(tag, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Terminal, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Disp4, "", TextCompare: true) != 0))
							{
								text = "j" + Conversions.ToString(num);
								((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + tag + sSeparador + mFiacao[j].Terminal));
							}
						}
						else if ((Operators.CompareString(mFiacao[j].Disp4, "", TextCompare: true) != 0) & (Operators.CompareString(mFiacao[j].Term4, "", TextCompare: true) != 0))
						{
							text = "J" + Conversions.ToString(num);
							((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Disp4 + sSeparador + mFiacao[j].Term4));
						}
						text = "K" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Cor34));
						text = "L" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Secao34));
						text = "M" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Pagina34));
						text = "N" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mFiacao[j].Circuito));
						text = "A" + Conversions.ToString(num) + ":N" + Conversions.ToString(num);
						ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					}
					num3 = (int)num;
					if (j < Information.UBound(mFiacao))
					{
						num8 = j;
					}
					if ((double)num != (double)num4 * qLinhas)
					{
						num++;
					}
					else
					{
						text = "A" + Conversions.ToString(num2) + ":N" + Conversions.ToString(num3);
						ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
						num++;
						num6 = (int)num;
						SSXpnYIMyaC(ref oSheet, ref num6, iTipoAnilha);
						num = num6;
						num3 = (int)num;
						num3 = (int)num;
						num2 = (int)num;
						num4++;
					}
					if (Operators.CompareString(mFiacao[num8].Tag, "", TextCompare: true) != 0)
					{
						tag = mFiacao[j].Tag;
						text = "A" + Conversions.ToString(num2) + ":N" + Conversions.ToString(num3);
						ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
						num3 = (int)num;
						num2 = (int)num;
					}
					DeclaracoesGeral._uscPagina.pbPasso();
				}
				text = "A" + Conversions.ToString(num2) + ":N" + Conversions.ToString(num3);
				ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
				text2 = "A1";
				((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
				ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
				DeclaracoesGeral._uscPagina.pbFim();
			}
		}
	}

	private static void SSXpnYIMyaC(ref Worksheet P_0, ref int P_1, int P_2)
	{
		checked
		{
			try
			{
				string text = "";
				if (P_1 < 2)
				{
					((_Worksheet)P_0).get_Range((object)"A1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 18;
					((_Worksheet)P_0).get_Range((object)"B1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
					((_Worksheet)P_0).get_Range((object)"C1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
					((_Worksheet)P_0).get_Range((object)"D1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
					((_Worksheet)P_0).get_Range((object)"E1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 18;
					((_Worksheet)P_0).get_Range((object)"F1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
					((_Worksheet)P_0).get_Range((object)"G1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
					((_Worksheet)P_0).get_Range((object)"H1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 18;
					((_Worksheet)P_0).get_Range((object)"I1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
					((_Worksheet)P_0).get_Range((object)"J1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
					((_Worksheet)P_0).get_Range((object)"K1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
					((_Worksheet)P_0).get_Range((object)"L1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
					((_Worksheet)P_0).get_Range((object)"M1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
					((_Worksheet)P_0).get_Range((object)"N1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 25;
					if (P_2 == 3)
					{
						((_Worksheet)P_0).get_Range((object)"C1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 20;
						((_Worksheet)P_0).get_Range((object)"D1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 20;
						((_Worksheet)P_0).get_Range((object)"G1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 20;
						((_Worksheet)P_0).get_Range((object)"J1", RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 20;
					}
				}
				text = "A" + Conversions.ToString(P_1) + ":D" + Conversions.ToString(P_1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 48]));
				text = "A" + Conversions.ToString(P_1 + 1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 1005].ToString().ToUpper()));
				text = "B" + Conversions.ToString(P_1 + 1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 771].ToString().ToUpper()));
				text = "C" + Conversions.ToString(P_1 + 1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 498].ToString().ToUpper()));
				text = "D" + Conversions.ToString(P_1 + 1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 499].ToString().ToUpper()));
				text = "E" + Conversions.ToString(P_1) + ":G" + Conversions.ToString(P_1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject(Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 49]), "1"));
				text = "E" + Conversions.ToString(P_1 + 1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 1005].ToString().ToUpper()));
				text = "F" + Conversions.ToString(P_1 + 1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 771].ToString().ToUpper()));
				text = "G" + Conversions.ToString(P_1 + 1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 1591].ToString().ToUpper()));
				text = "H" + Conversions.ToString(P_1) + ":J" + Conversions.ToString(P_1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject(Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 49]), "2"));
				text = "H" + Conversions.ToString(P_1 + 1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 1005].ToString().ToUpper()));
				text = "I" + Conversions.ToString(P_1 + 1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 771].ToString().ToUpper()));
				text = "J" + Conversions.ToString(P_1 + 1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 1591].ToString().ToUpper()));
				text = "K" + Conversions.ToString(P_1) + ":K" + Conversions.ToString(P_1 + 1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 497].ToString().ToUpper()));
				text = "L" + Conversions.ToString(P_1) + ":L" + Conversions.ToString(P_1 + 1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 1669].ToString().ToUpper() + "\r\n(mm²)"));
				text = "M" + Conversions.ToString(P_1) + ":M" + Conversions.ToString(P_1 + 1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 287].ToString().ToUpper()));
				text = "N" + Conversions.ToString(P_1) + ":N" + Conversions.ToString(P_1 + 1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + DeclaracoesGeral.mMensagem[1, 1670].ToString().ToUpper()));
				text = "A" + Conversions.ToString(P_1) + ":N" + Conversions.ToString(P_1 + 1);
				ExcFuncoesExcel.CriaLinhasInterna(ref P_0, text);
				ExcFuncoesExcel.CriaLinhasExterna(ref P_0, text, bCompleto: true);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class Relatorios_ListaCabosEXCEL
{
	public struct indiceRelatorioCabos
	{
		public string sPagina;

		public string sPainel;

		public string sNomeSheet;
	}

	public static void CriaListaCabosEletronEXCEL(DeclaracoesInterligacao.structureCabo[] mCabos, bool bComprimento, bool bTrajeto)
	{
		checked
		{
			try
			{
				Microsoft.Office.Interop.Excel.Application oExcelNew = null;
				Worksheet oSheet = null;
				string oNomeSheet = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1409]);
				ExcFuncoesExcel.VerificaExcel(ref oExcelNew, ref oSheet, oNomeSheet);
				ExcFuncoesExcel.DesativaCalculoExcel(ref oExcelNew);
				((_Worksheet)oSheet).get_Range((object)"A1", (object)"Z10000").EntireRow.Delete(RuntimeHelpers.GetObjectValue(Missing.Value));
				oSheet.Cells.ClearComments();
				ExcFuncoesExcel.ApagaFigura(oNomeSheet);
				long num = 1L;
				string text = "";
				text = "A1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "B1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "C1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 60;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "D1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 8;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 3;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "E1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 20;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "F1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 20;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "G1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 8;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 3;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "H1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "I1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				text = "J1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 20;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				int num2 = 0;
				text = "A" + Conversions.ToString(1L);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1415]));
				text = "B" + Conversions.ToString(1L);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1285]));
				text = "C" + Conversions.ToString(1L);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1244]));
				text = "D" + Conversions.ToString(1L);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1243]));
				text = "E" + Conversions.ToString(1L);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1241]));
				text = "F" + Conversions.ToString(1L);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1242]));
				text = "G" + Conversions.ToString(1L);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1243]));
				text = "H" + Conversions.ToString(1L);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1414]));
				if (bComprimento)
				{
					text = "I" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1412]));
					num2++;
				}
				if (bTrajeto)
				{
					text = "J" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1413]));
					num2++;
				}
				switch (num2)
				{
				case 2:
					text = "A" + Conversions.ToString(num) + ":J" + Conversions.ToString(num);
					break;
				case 0:
					text = "A" + Conversions.ToString(num) + ":H" + Conversions.ToString(num);
					break;
				case 1:
					text = "A" + Conversions.ToString(num) + ":I" + Conversions.ToString(num);
					break;
				}
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
				ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text, bCompleto: true);
				num += 2L;
				DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mCabos);
				DeclaracoesGeral._uscPagina.pbIniciar();
				string text2 = "";
				int num3 = Information.UBound(mCabos);
				for (int i = 1; i <= num3; i++)
				{
					text2 = "A" + Conversions.ToString(num + 2L);
					((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
					text = "A" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mCabos[i].Tag));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					text = "B" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mCabos[i].Formacao2));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					text = "C" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mCabos[i].Funcao));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					text = "D" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mCabos[i].AterrarOrigem));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "E" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mCabos[i].Origem));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					text = "F" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mCabos[i].Destino));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					text = "G" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mCabos[i].AterrarDestino));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					text = "H" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mCabos[i].blindagem2));
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					if (bComprimento)
					{
						text = "I" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + Conversions.ToString(mCabos[i].Comprimento)));
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 4;
					}
					if (bTrajeto)
					{
						text = "J" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mCabos[i].Trajeto));
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					}
					switch (num2)
					{
					case 2:
						text = "A" + Conversions.ToString(num) + ":J" + Conversions.ToString(num);
						break;
					case 0:
						text = "A" + Conversions.ToString(num) + ":H" + Conversions.ToString(num);
						break;
					case 1:
						text = "A" + Conversions.ToString(num) + ":I" + Conversions.ToString(num);
						break;
					}
					ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
					num++;
					DeclaracoesGeral._uscPagina.pbPasso();
				}
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

	public static void CriaListaCabosEletronEletrosulEXCEL(DataGridView dg, string sRev, string sDesenho, string sTit1, string sTit2, string sTit3, ref indiceRelatorioCabos[] mIndice)
	{
		checked
		{
			try
			{
				Microsoft.Office.Interop.Excel.Application OExcelNew = null;
				Worksheet oSheet = null;
				string text = "";
				string text2 = "";
				long num = 1L;
				string text3 = "";
				List<string> list = new List<string>();
				int num2 = 3;
				int num3 = 0;
				mIndice = new indiceRelatorioCabos[1];
				DeclaracoesGeral._uscPagina.Quantidade = dg.RowCount;
				DeclaracoesGeral._uscPagina.pbIniciar();
				string text4 = "";
				bool flag = false;
				int num4 = 48;
				string text5 = "";
				int num5 = dg.RowCount - 1;
				for (int i = 0; i <= num5; DeclaracoesGeral._uscPagina.pbPasso(), i++)
				{
					if ((num == num4) & (dg.Rows[i].Cells[0].Style.BackColor != Color.LightGray))
					{
						flag = true;
					}
					if ((dg.Rows[i].Cells[0].Style.BackColor == Color.LightGray) | flag)
					{
						if (Operators.CompareString(text4, "", TextCompare: true) != 0)
						{
							Clipboard.Clear();
							Clipboard.SetText(text4);
							text5 = "A3";
							((_Worksheet)oSheet).get_Range((object)text5, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
							oSheet.Paste(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
							text4 = "";
						}
						int num6 = 1;
						if (flag)
						{
							num2++;
						}
						if (Operators.CompareString(dg.Rows[i].Cells[0].Value.ToString(), "", TextCompare: true) == 0)
						{
							continue;
						}
						if (!(flag & (dg.Rows[i].Cells[0].Style.BackColor != Color.LightGray)))
						{
							text = dg.Rows[i].Cells[0].Value.ToString();
						}
						else
						{
							int num7 = 1;
							do
							{
								text = text2 + "_" + num7;
								if (list.Contains(text))
								{
									num7++;
									continue;
								}
								break;
							}
							while (num7 <= 10);
						}
						if (list.Contains(text))
						{
							do
							{
								if (Operators.CompareString(text4, "", TextCompare: true) != 0)
								{
									Clipboard.Clear();
									Clipboard.SetText(text4);
									text5 = "A3";
									((_Worksheet)oSheet).get_Range((object)text5, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
									oSheet.Paste(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
									text4 = "";
								}
								text = text2 + "_" + Conversions.ToString(num6);
								num6++;
							}
							while (list.Contains(text));
						}
						else
						{
							text2 = text;
						}
						list.Add(text);
						ExcFuncoesExcel.VerificaExcel(ref OExcelNew, ref oSheet, text);
						if (Operators.CompareString(DeclaracoesGeral.companyHardlock.ToUpper(), "CADGRAPH", TextCompare: true) != 0)
						{
							ExcFuncoesExcel.DesativaCalculoExcel(ref OExcelNew);
						}
						else
						{
							ExcFuncoesExcel.AtivaCalculOExcel(ref OExcelNew);
						}
						((_Worksheet)oSheet).get_Range((object)"A1", (object)"Z10000").EntireRow.Delete(RuntimeHelpers.GetObjectValue(Missing.Value));
						oSheet.Cells.ClearComments();
						ExcFuncoesExcel.ApagaFigura(text);
						num = 1L;
						text3 = "A1:B1";
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1288]));
						text3 = "A2";
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1154]));
						text3 = "B2";
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 389]));
						text3 = "C1:D1";
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 890]));
						text3 = "C2";
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1241]));
						text3 = "D2";
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1242]));
						text3 = "E1:E2";
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 70;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1623]));
						text3 = "F1:F2";
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1285]));
						text3 = "G1:G2";
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 40;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1624]));
						text3 = "H1:H2";
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1625]));
						text3 = "A1:H2";
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
						num = 3L;
						text3 = "A" + Conversions.ToString(num4);
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1626]));
						text3 = "A" + Conversions.ToString(num4 + 1) + ":A" + Conversions.ToString(num4 + 2);
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + text));
						text3 = "B" + Conversions.ToString(num4) + ":E" + Conversions.ToString(num4);
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + sTit1));
						text3 = "B" + Conversions.ToString(num4 + 1) + ":E" + Conversions.ToString(num4 + 1);
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + sTit2));
						text3 = "B" + Conversions.ToString(num4 + 2) + ":E" + Conversions.ToString(num4 + 2);
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + sTit3));
						text3 = "F" + Conversions.ToString(num4);
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 380]));
						text3 = "F" + Conversions.ToString(num4 + 1) + ":F" + Conversions.ToString(num4 + 2);
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + sRev));
						text3 = "G" + Conversions.ToString(num4);
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1158]));
						text3 = "G" + Conversions.ToString(num4 + 1) + ":G" + Conversions.ToString(num4 + 2);
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + sDesenho));
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						text3 = "H" + Conversions.ToString(num4);
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1627]));
						text3 = "H" + Conversions.ToString(num4 + 1) + ":H" + Conversions.ToString(num4 + 2);
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + Conversions.ToString(num2)));
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						text3 = "A3:H" + Conversions.ToString(num4 + 2);
						ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text3);
						ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text3, bCompleto: true);
						text3 = "A" + Conversions.ToString(num4) + ":H" + Conversions.ToString(num4 + 2);
						ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, text3, bCompleto: true);
						num3++;
						mIndice = (indiceRelatorioCabos[])Utils.CopyArray(mIndice, new indiceRelatorioCabos[num3 + 1]);
						mIndice[num3].sPagina = Conversions.ToString(num2);
						mIndice[num3].sPainel = text2;
						mIndice[num3].sNomeSheet = text;
						num2 = Conversions.ToInteger(Conversions.ToString(num2 + 1));
						if (!flag)
						{
							continue;
						}
						flag = false;
					}
					text3 = "A" + Conversions.ToString(num) + ":H" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
					((_Worksheet)oSheet).get_Range((object)text3, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
					int num8 = 0;
					do
					{
						text4 = Conversions.ToString(Operators.AddObject(text4, Operators.ConcatenateObject(dg.Rows[i].Cells[num8].Value, "\t")));
						num8++;
					}
					while (num8 <= 6);
					text4 = Conversions.ToString(Operators.AddObject(text4, Operators.ConcatenateObject(dg.Rows[i].Cells[7].Value, "\r")));
					num++;
				}
				if (Operators.CompareString(text4, "", TextCompare: true) != 0)
				{
					Clipboard.Clear();
					Clipboard.SetText(text4);
					text5 = "A3";
					((_Worksheet)oSheet).get_Range((object)text5, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
					oSheet.Paste(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
					text4 = "";
				}
				text5 = "A1";
				((_Worksheet)oSheet).get_Range((object)text5, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
				ExcFuncoesExcel.AtivaCalculOExcel(ref OExcelNew);
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

	public static bool preencheIndiceCaboExcel(indiceRelatorioCabos[] mIndiceRel, string sRev)
	{
		bool result = false;
		Microsoft.Office.Interop.Excel.Application oExcelNew = null;
		Worksheet oSheet = null;
		string text = "";
		int num = 1;
		int num2 = 1;
		int num3 = 3;
		int num4 = 1;
		int num5 = 47;
		int num6 = 3;
		int num7 = 3;
		int num8 = 47;
		checked
		{
			if (ExcFuncoesExcel.VerificaExisteSheet(ref oExcelNew, ref oSheet, "Indice"))
			{
				int num9 = num3;
				int num10 = 1;
				do
				{
					string text2 = ExcFuncoesExcel.mudaNumeroAsc(num10);
					int num11 = num9;
					int num12 = num5;
					for (int i = num11; i <= num12; i++)
					{
						text = text2 + i;
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)" ");
					}
					num10++;
				}
				while (num10 <= 5);
				text = "A" + num3;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'1");
				text = "B" + num3;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + sRev));
				text = "C" + num3;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'CAPA");
				num3++;
				int num13 = 1;
				int num14 = 1;
				int num15 = 0;
				int num16 = (int)Math.Round((double)Information.UBound(mIndiceRel) / 43.0) + 1;
				for (int j = 2; j <= num16; j++)
				{
					text = "A" + num3;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + Conversions.ToString(j)));
					text = "B" + num3;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + sRev));
					text = "C" + num3;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'INDICE");
					num3++;
					num15++;
				}
				if (num15 == 0)
				{
					text = "A" + num3;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + Conversions.ToString(2)));
					text = "B" + num3;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + sRev));
					text = "C" + num3;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'INDICE");
					num3++;
					num15 = 1;
				}
				while (true)
				{
					if (num == 1)
					{
						num2 = 1;
						num7 = num15 + 1;
						num14 = num7;
						num8 = 44;
						num4 = 98;
						result = false;
					}
					else if (num == 2)
					{
						num7 = 53;
						num8 = 97;
						num4 = 148;
						result = true;
					}
					else
					{
						num7 += 50;
						num8 += 50;
						num4 += 50;
						result = true;
					}
					num++;
					int num17 = num7;
					int num18 = num8;
					for (int k = num17; k <= num18; k++)
					{
						mIndiceRel[num2].sPagina = Conversions.ToString(num14 + 1);
						text = "A" + num3;
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mIndiceRel[num2].sPagina));
						text = "B" + num3;
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + sRev));
						text = "C" + num3;
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mIndiceRel[num2].sPainel));
						text = "A" + num3 + ":B" + num3;
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						num2++;
						num3++;
						num14++;
						if (num2 > Information.UBound(mIndiceRel))
						{
							goto end_IL_025a;
						}
					}
					text = "A" + Conversions.ToString(num7) + ":F" + Conversions.ToString(num8);
					ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
					num3 += 3;
					text = "A" + num3 + ":F" + num3;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					ExcFuncoesExcel.CopyValorCelula(ref oSheet, text, "A1");
					num3++;
					text = "A" + num3;
					ExcFuncoesExcel.CopyValorCelula(ref oSheet, text, "A2");
					text = "B" + num3;
					ExcFuncoesExcel.CopyValorCelula(ref oSheet, text, "B2");
					text = "C" + num3 + ":F" + num3;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					ExcFuncoesExcel.CopyValorCelula(ref oSheet, text, "C2");
					num3++;
					text = "A" + Conversions.ToString(num4) + ":A" + Conversions.ToString(num4 + 2);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					ExcFuncoesExcel.CopyValorCelula(ref oSheet, text, "A48");
					text = "B" + Conversions.ToString(num4) + ":C" + Conversions.ToString(num4);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					ExcFuncoesExcel.CopyValorCelula(ref oSheet, text, "B48");
					text = "B" + Conversions.ToString(num4 + 1) + ":C" + Conversions.ToString(num4 + 1);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					ExcFuncoesExcel.CopyValorCelula(ref oSheet, text, "B49");
					text = "B" + Conversions.ToString(num4 + 2) + ":C" + Conversions.ToString(num4 + 2);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					ExcFuncoesExcel.CopyValorCelula(ref oSheet, text, "B50");
					text = "D" + Conversions.ToString(num4);
					ExcFuncoesExcel.CopyValorCelula(ref oSheet, text, "D48");
					text = "D" + Conversions.ToString(num4 + 1) + ":D" + Conversions.ToString(num4 + 2);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					ExcFuncoesExcel.CopyValorCelula(ref oSheet, text, "D49");
					text = "E" + Conversions.ToString(num4);
					ExcFuncoesExcel.CopyValorCelula(ref oSheet, text, "D48");
					text = "E" + Conversions.ToString(num4 + 1) + ":E" + Conversions.ToString(num4 + 2);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					ExcFuncoesExcel.CopyValorCelula(ref oSheet, text, "E49");
					text = "F" + Conversions.ToString(num4);
					ExcFuncoesExcel.CopyValorCelula(ref oSheet, text, "F48");
					text = "F" + Conversions.ToString(num4 + 1) + ":F" + Conversions.ToString(num4 + 2);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					ExcFuncoesExcel.CopyValorCelula(ref oSheet, text, "F49");
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + Conversions.ToString(num6)));
					num6++;
					int num19 = num3;
					int num20 = num4 - 1;
					for (int l = num19; l <= num20; l++)
					{
						text = "C" + Conversions.ToString(l) + ":F" + Conversions.ToString(l);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
					}
					text = "A" + Conversions.ToString(num3 - 2) + ":F" + Conversions.ToString(num4 + 2);
					ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
					num13++;
					continue;
					end_IL_025a:
					break;
				}
			}
			return result;
		}
	}
}

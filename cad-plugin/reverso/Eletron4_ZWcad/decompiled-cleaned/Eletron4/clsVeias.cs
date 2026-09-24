using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class clsVeias
{
	public struct StructureVeias
	{
		public int iPainelSel;

		public string sTag;

		public string sFormacao;

		public string sFuncao;

		public string sVeia;

		public int iIndice;

		public string sAterrar1;

		public int iPn1;

		public string sPainel1;

		public string sDisp1;

		public string sBorne1;

		public int iPn2;

		public string sPainel2;

		public string sDisp2;

		public string sBorne2;

		public string sAterrar2;

		public string sDiagrama;

		public string sPagina1;

		public string sPagina2;

		public bool bBlindagem;

		public int iAterrar;

		public int iCabos;

		public double dComprimento;
	}

	public struct StructureUmaVeia
	{
		public string sTag;

		public int iIndice;

		public double iIndiceOrdem;

		public string sNome_Veia;

		public string sFuncao;

		public string sArquivo;

		public string sPagina;

		public string sIsolamento;
	}

	public struct StructureInterComplementa
	{
		public int DWG1;

		public string sDocumento1;

		public int Painel1;

		public string sPagina1;

		public string sTag1;

		public string sAlternativo1;

		public string sNRegua1;

		public string sTerminal1;

		public int DWG2;

		public string sDocumento2;

		public int Painel2;

		public string sPagina2;

		public string sTag2;

		public string sAlternativo2;

		public string sNRegua2;

		public string sTerminal2;
	}

	public struct StructureVeiasgIGA
	{
		public int iPainelSel;

		public string sTag;

		public int iPn1;

		public string sPainel1;

		public string sDisp1;

		public string sBorne1;

		public int iPn2;

		public string sPainel2;

		public string sDisp2;

		public string sBorne2;

		public string sPagina1;

		public string sPagina2;
	}

	public struct InterGIGA
	{
		public int iIndice;

		public string sTag1;

		public string sCor;

		public string sTag2;

		public string sPG;

		public string sD1;

		public string sD2;

		public string sB1;

		public string sB2;
	}

	public static void ExportaNomeFuncaoVeiaParaOExcel(ref Worksheet oSheet, ref DataGridView dg, structureVeiasCaderno[] SincVeias)
	{
		int num = 2;
		int num2 = 2;
		ExcFuncoesExcel.LimpaSheet(ref oSheet);
		string cell = "A1";
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 1766].ToString().ToUpper());
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
		cell = "B1";
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 0;
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 1239].ToString().ToUpper());
		cell = "C1";
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 1239].ToString().ToUpper());
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
		cell = "D1";
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 30;
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 987].ToString().ToUpper());
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
		cell = "E1";
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 50;
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 1659].ToString().ToUpper());
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
		cell = "A1:E1";
		ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, cell);
		if (dg.RowCount <= 0)
		{
			return;
		}
		int num3 = Information.UBound(SincVeias);
		checked
		{
			for (int i = 1; i <= num3; i++)
			{
				double num4 = SincVeias[i].iIndice;
				if (num4 == 0.0)
				{
					num4 = -99.0;
				}
				if ((num4 != -99.0) & (num4 < 0.0))
				{
					if (num4 < -50.0)
					{
						num4 += 50.0;
						num4 *= -1.0;
						if (num4 > 50.0)
						{
							num4 -= 50.0;
						}
						if (SincVeias[i].sFormacao.Contains("P"))
						{
							num4 *= 2.0;
							num4 += 0.2;
						}
						if (SincVeias[i].sFormacao.Contains("T"))
						{
							num4 *= 3.0;
							num4 += 0.2;
						}
					}
					if (num4 < 0.0)
					{
						num4 *= -1.0;
						if (SincVeias[i].sFormacao.Contains("P"))
						{
							num4 *= 2.0;
							num4 += 0.1;
						}
						if (SincVeias[i].sFormacao.Contains("T"))
						{
							num4 *= 3.0;
							num4 += 0.1;
						}
					}
				}
				SincVeias[i].X = num4;
			}
			structureVeiasCaderno structureVeiasCaderno2 = default;
			if (Information.UBound(SincVeias) >= 2 && Information.UBound(SincVeias) > 0)
			{
				int num5 = Information.UBound(SincVeias);
				for (int j = 1; j <= num5; j++)
				{
					int num6 = Information.UBound(SincVeias) - 1;
					int num7 = j;
					for (int k = num6; k >= num7; k += -1)
					{
						if (Operators.CompareString(SincVeias[k].sTag, SincVeias[k + 1].sTag, TextCompare: true) > 0)
						{
							structureVeiasCaderno2 = SincVeias[k + 1];
							SincVeias[k + 1] = SincVeias[k];
							SincVeias[k] = structureVeiasCaderno2;
						}
						if (Operators.CompareString(SincVeias[k].sTag, SincVeias[k + 1].sTag, TextCompare: true) == 0 && SincVeias[k].X > SincVeias[k + 1].X)
						{
							structureVeiasCaderno2 = SincVeias[k + 1];
							SincVeias[k + 1] = SincVeias[k];
							SincVeias[k] = structureVeiasCaderno2;
						}
					}
				}
			}
			DeclaracoesGeral._uscPagina.Quantidade = dg.RowCount;
			DeclaracoesGeral._uscPagina.pbIniciar();
			int num8 = dg.RowCount - 1;
			for (int l = 0; l <= num8; l++)
			{
				string left = Conversions.ToString(dg.Rows[l].Cells[0].Value);
				num2 = num;
				bool flag = false;
				int num9 = Information.UBound(SincVeias);
				for (int m = 0; m <= num9; m++)
				{
					if (Operators.CompareString(left, SincVeias[m].sTag, TextCompare: true) == 0 && SincVeias[m].iIndice > -51)
					{
						cell = "A" + num;
						((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + SincVeias[m].sTag));
						cell = "B" + num;
						((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + Conversions.ToString(SincVeias[m].iIndice)));
						if (SincVeias[m].iIndice >= 1)
						{
							cell = "C" + num;
							((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + Conversions.ToString(SincVeias[m].iIndice)));
						}
						else
						{
							cell = "C" + num;
							((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + SincVeias[m].sNomeVeia));
						}
						((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						cell = "D" + num;
						((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + SincVeias[m].sNomeVeia));
						((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
						((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
						cell = "E" + num;
						((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + SincVeias[m].sFuncaoVeia));
						num++;
						flag = true;
					}
					if (flag && Operators.CompareString(left, SincVeias[m].sTag, TextCompare: true) != 0)
					{
						flag = false;
						break;
					}
				}
				if (num != num2)
				{
					cell = "A" + Conversions.ToString(num2) + ":E" + Conversions.ToString(num - 1);
					ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, cell);
					ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, cell, bCompleto: true);
				}
				DeclaracoesGeral._uscPagina.pbPasso();
				cell = "A" + Conversions.ToString(num + 5);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
			}
			cell = "A1";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
			DeclaracoesGeral._uscPagina.pbFim();
		}
	}

	public static void ImportaNomeFuncaoVeiaDoExcel(ref Worksheet oSheet, ref structureVeiasCaderno[] SincVeias)
	{
		SincVeias = new structureVeiasCaderno[1];
		int num = ExcFuncoesExcel.BuscaIndiceMaximoUsado(ref oSheet, "A");
		string text = "A" + Conversions.ToString(num);
		int num2 = 0;
		DeclaracoesGeral._uscPagina.pbIniciar();
		DeclaracoesGeral._uscPagina.Quantidade = num;
		int num3 = num;
		checked
		{
			for (int i = 2; i <= num3; i++)
			{
				text = "A" + i;
				if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
				{
					text = "B" + i;
					if (Versioned.IsNumeric(clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))))))
					{
						num2++;
						SincVeias = (structureVeiasCaderno[])Utils.CopyArray(SincVeias, new structureVeiasCaderno[num2 + 1]);
						text = "A" + i;
						SincVeias[num2].sTag = ((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString();
						text = "B" + i;
						SincVeias[num2].iIndice = Conversions.ToInteger(clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))));
						text = "D" + i;
						SincVeias[num2].sNomeVeia = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
						text = "E" + i;
						SincVeias[num2].sFuncaoVeia = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
						text = "B" + i;
						if (Conversions.ToInteger(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))) < 1)
						{
							if (Conversions.ToInteger(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))) != 0)
							{
								num2++;
								SincVeias = (structureVeiasCaderno[])Utils.CopyArray(SincVeias, new structureVeiasCaderno[num2 + 1]);
								text = "A" + i;
								SincVeias[num2].sTag = ((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString();
								text = "B" + i;
								SincVeias[num2].iIndice = Conversions.ToInteger(clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))))) - 50;
								text = "D" + i;
								SincVeias[num2].sNomeVeia = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
								text = "E" + i;
								SincVeias[num2].sFuncaoVeia = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
							}
							else
							{
								num2++;
								SincVeias = (structureVeiasCaderno[])Utils.CopyArray(SincVeias, new structureVeiasCaderno[num2 + 1]);
								text = "A" + i;
								SincVeias[num2].sTag = ((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString();
								text = "B" + i;
								SincVeias[num2].iIndice = -99;
								text = "D" + i;
								SincVeias[num2].sNomeVeia = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
								text = "E" + i;
								SincVeias[num2].sFuncaoVeia = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
							}
						}
					}
				}
				DeclaracoesGeral._uscPagina.pbPasso();
			}
			DeclaracoesGeral._uscPagina.pbFim();
		}
	}
}

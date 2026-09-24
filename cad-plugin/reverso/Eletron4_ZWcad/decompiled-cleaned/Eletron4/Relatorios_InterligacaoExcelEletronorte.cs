using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class Relatorios_InterligacaoExcelEletronorte
{
	public struct structureRelInterligacao
	{
		public string TagRegua;

		public string Jumper;

		public string TagCabo_Veia;

		public string Formacao;

		public string sAnilhas;

		public string Destino;

		public string Régua;

		public string Borne;

		public string Funcao;

		public string Documento;

		public string Trajeto;

		public string sOpcional;

		public int TipoBorne;
	}

	public static void CriaMatrizInterligacaoExcel(structureRelInterligacao[] mInterligacao, string sPainel, int QuantLinhasMax, bool bAnilha, bool bFuncao, bool bDocumentooo, bool bTrajeto, string sOpcional, bool bVazio, string sVazio, DeclaracoesInterligacao.reservaRI[] mAterrados, DeclaracoesInterligacao.reservaRI[] mNaoAterrados)
	{
		Application oExcelNew = null;
		Worksheet oSheet = null;
		string oNomeSheet = Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(sPainel));
		ExcFuncoesExcel.VerificaExcel(ref oExcelNew, ref oSheet, oNomeSheet);
		ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
		((_Worksheet)oSheet).get_Range((object)"A1", (object)"Z10000").EntireRow.Delete(RuntimeHelpers.GetObjectValue(Missing.Value));
		long num = 1L;
		int num2 = 1;
		int num3 = 1;
		int num4 = 1;
		string text = "";
		string text2 = "";
		string text3 = Conversions.ToString(oFp3e36WZ9(ref oSheet, bAnilha, bFuncao, bDocumentooo, bTrajeto, sOpcional, sVazio));
		int num5 = 1;
		h7F32glpM2(ref oSheet, ref num5, bAnilha, bFuncao, bDocumentooo, bTrajeto, sOpcional, sVazio);
		num = num5;
		int num6 = Information.UBound(mInterligacao);
		checked
		{
			if (bVazio)
			{
				num6 += Information.UBound(mAterrados) + Information.UBound(mNaoAterrados);
			}
			num3 = QuantLinhasMax * 2 + 1;
			bool flag = false;
			bool flag2 = false;
			DeclaracoesGeral._uscPagina.Quantidade = num6;
			DeclaracoesGeral._uscPagina.pbIniciar();
			int num7 = Information.UBound(mInterligacao);
			int num8 = 1;
			while (num8 <= num7)
			{
				if (mInterligacao[num8].TipoBorne == -10)
				{
					text2 = mInterligacao[num8].TagRegua;
				}
				flag = false;
				if ((num + 4L >= num3 + 1) | flag2)
				{
					num = QuantLinhasMax * 2 * num2 + 1;
					num5 = (int)num;
					h7F32glpM2(ref oSheet, ref num5, bAnilha, bFuncao, bDocumentooo, bTrajeto, sOpcional, sVazio);
					num = num5;
					num += 2L;
					num5 = (int)num;
					OUs33fGOH3(ref oSheet, ref num5, text2);
					num = num5;
					num4 = (int)num;
					flag = true;
					num2++;
					num3 = QuantLinhasMax * 2 * num2 + 2;
					flag2 = false;
				}
				if ((mInterligacao[num8].TipoBorne == -10) & !flag)
				{
					text2 = mInterligacao[num8].TagRegua;
					if (num + 6L >= num3 + 1)
					{
						flag2 = true;
						goto IL_018f;
					}
					int num9 = 10;
					if (bAnilha)
					{
						num9++;
					}
					if (bFuncao)
					{
						num9++;
					}
					if (bDocumentooo)
					{
						num9++;
					}
					if (bTrajeto)
					{
						num9++;
					}
					if (Operators.CompareString(sVazio, "", TextCompare: true) != 0)
					{
						num9++;
					}
					_ = "A" + Conversions.ToString(num4) + ":" + text3 + Conversions.ToString(num - 1L);
					num += 2L;
					num5 = (int)num;
					OUs33fGOH3(ref oSheet, ref num5, text2);
					num = num5;
					num4 = (int)num;
				}
				text = "A" + Conversions.ToString(num + 10L);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
				if (mInterligacao[num8].TipoBorne != -10 && mInterligacao[num8].TipoBorne != -20)
				{
					if (num8 != Information.UBound(mInterligacao))
					{
						if (Operators.CompareString(mInterligacao[num8].TagRegua, mInterligacao[num8 + 1].TagRegua, TextCompare: true) != 0)
						{
							if (mInterligacao[num8].TipoBorne != -20)
							{
								Worksheet oSheet2 = oSheet;
								num5 = (int)num;
								AdicionaLinhaRelInterligacao(oSheet2, ref num5, ref mInterligacao, num8, 0, bAnilha, bFuncao, bDocumentooo, bTrajeto, sOpcional, sVazio);
								num = num5;
							}
						}
						else
						{
							Worksheet oSheet3 = oSheet;
							num5 = (int)num;
							AdicionaLinhaRelInterligacao(oSheet3, ref num5, ref mInterligacao, num8, num8 + 1, bAnilha, bFuncao, bDocumentooo, bTrajeto, sOpcional, sVazio);
							num = num5;
						}
					}
					else
					{
						Worksheet oSheet4 = oSheet;
						num5 = (int)num;
						AdicionaLinhaRelInterligacao(oSheet4, ref num5, ref mInterligacao, num8, 0, bAnilha, bFuncao, bDocumentooo, bTrajeto, sOpcional, sVazio);
						num = num5;
					}
				}
				goto IL_018f;
				IL_018f:
				DeclaracoesGeral._uscPagina.pbPasso();
				if (!DeclaracoesGeral.bPararRelatorio)
				{
					num8++;
					continue;
				}
				break;
			}
			int num10 = 10;
			if (bAnilha)
			{
				num10++;
			}
			if (bFuncao)
			{
				num10++;
			}
			if (bDocumentooo)
			{
				num10++;
			}
			if (bTrajeto)
			{
				num10++;
			}
			if (Operators.CompareString(sVazio, "", TextCompare: true) != 0)
			{
				num10++;
			}
			text3 = ExcFuncoesExcel.mudaNumeroAsc(num10);
			_ = "A" + Conversions.ToString(num4) + ":" + text3 + (num - 1L);
			if (bVazio && !DeclaracoesGeral.bPararRelatorio)
			{
				if (Information.UBound(mAterrados) > 0)
				{
					num5 = (int)num;
					E8u3nTEZgB(ref oSheet, ref num5, mAterrados, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1435]));
					num = num5;
				}
				if (!DeclaracoesGeral.bPararRelatorio && Information.UBound(mNaoAterrados) > 0)
				{
					num5 = (int)num;
					E8u3nTEZgB(ref oSheet, ref num5, mNaoAterrados, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1436]));
					num = num5;
				}
			}
			text = "A" + Conversions.ToString(1);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
			DeclaracoesGeral._uscPagina.pbFim();
		}
	}

	public static void AdicionaLinhaRelInterligacao(Worksheet oSheet, ref int iLinhaRelatorio, ref structureRelInterligacao[] mInterligacao, int iIndice1, int iIndice2, bool bAnilha, bool bfuncao, bool bDocumentooo, bool bTrajeto, string sOpcional, string sVazio)
	{
		string text = "";
		checked
		{
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
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"o");
			}
			text = "C" + Conversions.ToString(iLinhaRelatorio);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mInterligacao[iIndice1].TagRegua));
			text = "E" + Conversions.ToString(iLinhaRelatorio);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"o");
			if (mInterligacao[iIndice1].TipoBorne == 1)
			{
				text = "E" + Conversions.ToString(iLinhaRelatorio + 2);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"o");
			}
			text = "F" + Conversions.ToString(iLinhaRelatorio) + ":F" + Conversions.ToString(iLinhaRelatorio + 1);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mInterligacao[iIndice1].TagCabo_Veia));
			text = "F" + Conversions.ToString(iLinhaRelatorio + 2) + ":F" + Conversions.ToString(iLinhaRelatorio + 3);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
			if (iIndice2 > 0)
			{
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mInterligacao[iIndice2].TagCabo_Veia));
			}
			text = "G" + Conversions.ToString(iLinhaRelatorio) + ":G" + Conversions.ToString(iLinhaRelatorio + 1);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mInterligacao[iIndice1].Formacao));
			text = "G" + Conversions.ToString(iLinhaRelatorio + 2) + ":G" + Conversions.ToString(iLinhaRelatorio + 3);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
			if (iIndice2 > 0)
			{
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mInterligacao[iIndice2].Formacao));
			}
			int num = 7;
			if (bAnilha)
			{
				num++;
				text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				if ((Operators.CompareString(mInterligacao[iIndice1].TagCabo_Veia, "", TextCompare: true) != 0) | (Operators.CompareString(mInterligacao[iIndice1].Jumper, "", TextCompare: true) != 0))
				{
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mInterligacao[iIndice1].sAnilhas));
				}
				text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 2) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 3);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				if (Operators.CompareString(mInterligacao[iIndice2].TagCabo_Veia, "", TextCompare: true) != 0)
				{
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mInterligacao[iIndice1].sAnilhas));
				}
			}
			num++;
			text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 1);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mInterligacao[iIndice1].Destino));
			text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 2) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 3);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
			if (iIndice2 > 0)
			{
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mInterligacao[iIndice2].Destino));
			}
			num++;
			text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 1);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mInterligacao[iIndice1].Régua));
			text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 2) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 3);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
			if (iIndice2 > 0)
			{
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mInterligacao[iIndice2].Régua));
			}
			num++;
			text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 1);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mInterligacao[iIndice1].Borne));
			text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 2) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 3);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
			if (iIndice2 > 0)
			{
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mInterligacao[iIndice2].Borne));
			}
			if (bfuncao)
			{
				num++;
				text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mInterligacao[iIndice1].Funcao));
				text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 2) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 3);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				if (iIndice2 > 0)
				{
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + mInterligacao[iIndice2].Funcao));
				}
			}
			if (bDocumentooo)
			{
				num++;
				text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + clsTextos.TiraNothing(mInterligacao[iIndice1].Documento)));
				text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 2) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 3);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + clsTextos.TiraNothing(mInterligacao[iIndice2].Documento)));
			}
			if (bTrajeto)
			{
				num++;
				text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + clsTextos.TiraNothing(mInterligacao[iIndice1].Trajeto)));
				text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 2) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 3);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + clsTextos.TiraNothing(mInterligacao[iIndice2].Trajeto)));
			}
			if (Operators.CompareString(sOpcional, "", TextCompare: true) != 0)
			{
				num++;
				text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + clsTextos.TiraNothing(mInterligacao[iIndice1].sOpcional)));
				text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 2) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 3);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + clsTextos.TiraNothing(mInterligacao[iIndice2].sOpcional)));
			}
			if (Operators.CompareString(sVazio, "", TextCompare: true) != 0)
			{
				num++;
				text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 1);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)" ");
				text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 2) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 3);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)" ");
			}
			ExcFuncoesExcel.mudaNumeroAsc(num);
			text = ExcFuncoesExcel.mudaNumeroAsc(1L) + Conversions.ToString(iLinhaRelatorio) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(iLinhaRelatorio + 3);
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
	}

	private static object oFp3e36WZ9(ref Worksheet P_0, bool P_1, bool P_2, bool P_3, bool P_4, string P_5, string P_6)
	{
		int num = 0;
		string text = "";
		num = 1;
		text = ExcFuncoesExcel.mudaNumeroAsc(1L) + "1";
		((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 1;
		num = 2;
		text = ExcFuncoesExcel.mudaNumeroAsc(2L) + "1";
		((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 0.6;
		num = 3;
		text = ExcFuncoesExcel.mudaNumeroAsc(3L) + "1";
		((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
		num = 4;
		text = ExcFuncoesExcel.mudaNumeroAsc(4L) + "1";
		((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 0.6;
		num = 5;
		text = ExcFuncoesExcel.mudaNumeroAsc(5L) + "1";
		((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 1;
		num = 6;
		text = ExcFuncoesExcel.mudaNumeroAsc(6L) + "1";
		((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
		num = 7;
		text = ExcFuncoesExcel.mudaNumeroAsc(7L) + "1";
		((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
		checked
		{
			if (P_1)
			{
				num++;
				text = ExcFuncoesExcel.mudaNumeroAsc(num) + "1";
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
			}
			num++;
			text = ExcFuncoesExcel.mudaNumeroAsc(num) + "1";
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 20;
			num++;
			text = ExcFuncoesExcel.mudaNumeroAsc(num) + "1";
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
			num++;
			text = ExcFuncoesExcel.mudaNumeroAsc(num) + "1";
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 8.5;
			if (P_2)
			{
				num++;
				text = ExcFuncoesExcel.mudaNumeroAsc(num) + "1";
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 20;
			}
			if (P_3)
			{
				num++;
				text = ExcFuncoesExcel.mudaNumeroAsc(num) + "1";
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 30;
			}
			if (P_4)
			{
				num++;
				text = ExcFuncoesExcel.mudaNumeroAsc(num) + "1";
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 30;
			}
			if (Operators.CompareString(P_5, "", TextCompare: true) != 0)
			{
				num++;
				text = ExcFuncoesExcel.mudaNumeroAsc(num) + "1";
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 20;
			}
			if (Operators.CompareString(P_6, "", TextCompare: true) != 0)
			{
				num++;
				text = ExcFuncoesExcel.mudaNumeroAsc(num) + "1";
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 5;
			}
			return ExcFuncoesExcel.mudaNumeroAsc(num);
		}
	}

	private static void h7F32glpM2(ref Worksheet P_0, ref int P_1, bool P_2, bool P_3, bool P_4, bool P_5, string P_6, string P_7)
	{
		string text = "";
		checked
		{
			text = "A" + Conversions.ToString(P_1) + ":A" + Conversions.ToString(P_1 + 10);
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 9;
			string cell = "A" + Conversions.ToString(P_1);
			((_Worksheet)P_0).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
			int num = 7;
			if (!P_2)
			{
				text = "A" + Conversions.ToString(P_1) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(P_1 + 1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1241]));
			}
			else
			{
				num++;
				text = "A" + Conversions.ToString(P_1) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(P_1 + 1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1241]));
				text = "H" + Conversions.ToString(P_1 + 2) + ":H" + Conversions.ToString(P_1 + 3);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1591]));
			}
			text = "A" + Conversions.ToString(P_1 + 2) + ":E" + Conversions.ToString(P_1 + 3);
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 984]));
			text = "F" + Conversions.ToString(P_1 + 2) + ":F" + Conversions.ToString(P_1 + 3);
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1305]));
			text = "G" + Conversions.ToString(P_1 + 2) + ":G" + Conversions.ToString(P_1 + 3);
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1285]));
			num++;
			text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(P_1) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num + 2) + Conversions.ToString(P_1 + 1);
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1242]));
			text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(P_1 + 2) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(P_1 + 3);
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 626]));
			num++;
			text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(P_1 + 2) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(P_1 + 3);
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 984]));
			num++;
			text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(P_1 + 2) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(P_1 + 3);
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1429]));
			if (P_3)
			{
				num++;
				text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(P_1) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(P_1 + 3);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1244]));
			}
			if (P_4)
			{
				num++;
				text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(P_1) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(P_1 + 3);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1417]));
			}
			if (P_5)
			{
				num++;
				text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(P_1) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(P_1 + 3);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1248]));
			}
			if (Operators.CompareString(P_6, "", TextCompare: true) != 0)
			{
				num++;
				text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(P_1) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(P_1 + 3);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + P_6));
			}
			if (Operators.CompareString(P_7, "", TextCompare: true) != 0)
			{
				num++;
				text = ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(P_1) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(P_1 + 3);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + P_7));
			}
			text = "A" + Conversions.ToString(P_1) + ":" + ExcFuncoesExcel.mudaNumeroAsc(num) + Conversions.ToString(P_1 + 3);
			ExcFuncoesExcel.CriaLinhasInterna(ref P_0, text);
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
			P_1 += 4;
		}
	}

	private static void OUs33fGOH3(ref Worksheet P_0, ref int P_1, string P_2)
	{
		string text = "";
		checked
		{
			text = "A" + Conversions.ToString(P_1) + ":A" + Conversions.ToString(P_1 + 3);
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 9;
			text = "A" + Conversions.ToString(P_1) + ":E" + Conversions.ToString(P_1 + 1);
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + P_2));
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 12;
			ExcFuncoesExcel.CriaLinhasInterna(ref P_0, text);
			P_1 += 2;
		}
	}

	private static void E8u3nTEZgB(ref Worksheet P_0, ref int P_1, DeclaracoesInterligacao.reservaRI[] P_2, string P_3)
	{
		string text = "";
		checked
		{
			P_1 += 2;
			text = "A" + Conversions.ToString(P_1) + ":A" + Conversions.ToString(P_1 + 10);
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 12.75;
			text = "F" + Conversions.ToString(P_1) + ":I" + Conversions.ToString(P_1);
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + P_3));
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
			ExcFuncoesExcel.CriaLinhasInterna(ref P_0, text);
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 12;
			P_1++;
			int num = P_1;
			string text2 = "";
			text = "F" + Conversions.ToString(P_1);
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1456]));
			text = "G" + Conversions.ToString(P_1);
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1454]));
			text = "H" + Conversions.ToString(P_1) + ":I" + Conversions.ToString(P_1);
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", DeclaracoesGeral.mMensagem[1, 1455]));
			text = "F" + Conversions.ToString(P_1) + ":I" + Conversions.ToString(P_1);
			ExcFuncoesExcel.CriaLinhasInterna(ref P_0, text);
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
			((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 12;
			P_1++;
			int num2 = Information.UBound(P_2);
			for (int i = 1; i <= num2; i++)
			{
				text = "F" + Conversions.ToString(P_1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + P_2[i].Tag));
				text = "G" + Conversions.ToString(P_1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + P_2[i].Veias));
				text = "H" + Conversions.ToString(P_1) + ":I" + Conversions.ToString(P_1);
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
				((_Worksheet)P_0).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + P_2[i].sPainelDest));
				text = "F" + Conversions.ToString(P_1) + ":I" + Conversions.ToString(P_1);
				P_1++;
				text2 = "A" + Conversions.ToString(P_1 + 2);
				((_Worksheet)P_0).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
			}
			text = "F" + Conversions.ToString(num) + ":I" + Conversions.ToString(P_1 - 1);
			ExcFuncoesExcel.CriaLinhasInterna(ref P_0, text);
		}
	}
}

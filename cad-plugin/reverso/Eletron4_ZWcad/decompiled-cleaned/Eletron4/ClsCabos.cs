using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;

namespace Eletron4;

public class ClsCabos
{
	public struct NomeVeias
	{
		public string blVar;

		public string P1Var;

		public string P2Var;

		public string T1Var;

		public string T2Var;

		public string T3Var;
	}

	public struct StructureCabo
	{
		public int iLinha;

		public string sTag;

		public string sFormacao;

		public bool bBlindagem;

		public int iPn1;

		public int iPn2;

		public string sCodigo;

		public string sFuncao;

		public int iAlarme;

		public int iAterrar;

		public double dComprimento;

		public string sTrajeto;

		public string sInstrucao;

		public double dDiametro;

		public string sGrupo;

		public int iCabos;

		public string sVeias;

		public string sSecao;

		public string sTagAntigo;
	}

	public struct StructureVeia
	{
		public string sTag;

		public int iIndice;

		public string sNome;

		public bool bUso;

		public string sHandle;

		public string sArquivo;

		public string sPagina;

		public string sFuncao;
	}

	public struct VeiaCabo
	{
		public string sTag;

		public int iNumVeias;

		public int iNumBlColetivas;

		public int iNumBlIndividuais;

		public string sTipo;
	}

	public struct CaboDWG
	{
		public string sTagOriginal;

		public string sTagNovo;

		public int iPn1;

		public int iPn2;
	}

	public static void CarregaOsCabosDoExcel(ref Worksheet oSheet, ref StructureCabo[] mCabos, List<string> lmListaCabos, NomeVeias nv, StructureCabo[] mCadernoCabos)
	{
		int i = 2;
		int num = 1;
		string cell = "A2";
		checked
		{
			while (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
			{
				num++;
				cell = "A" + Conversions.ToString(num);
			}
			List<string> list = new List<string>();
			list.Clear();
			DeclaracoesGeral._uscPagina.Quantidade = num;
			DeclaracoesGeral._uscPagina.pbIniciar();
			int num2 = 1;
			for (; Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)("A" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true); i++)
			{
				ExcFuncoesExcel.LimpaErro(ref oSheet, Conversions.ToString(i));
			}
			i = 2;
			while (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)("A" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
			{
				int num3 = 1;
				do
				{
					string cell2 = ExcFuncoesExcel.mudaNumeroAsc(num3) + i;
					if (Information.IsNothing(RuntimeHelpers.GetObjectValue(((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))))
					{
						ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(num3), Conversions.ToString(i), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1252]), 3);
					}
					num3++;
				}
				while (num3 <= 8);
				string cell3 = "A" + Conversions.ToString(i);
				((_Worksheet)oSheet).get_Range((object)cell3, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
				int num4 = 1;
				do
				{
					string cell4 = ExcFuncoesExcel.mudaNumeroAsc(num4) + i;
					if (Information.IsNothing(RuntimeHelpers.GetObjectValue(((_Worksheet)oSheet).get_Range((object)cell4, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))))
					{
						((_Worksheet)oSheet).get_Range((object)cell4, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)" ");
					}
					num4++;
				}
				while (num4 <= 11);
				string text = "";
				if (Conversions.ToBoolean(vkypgJ9yxl(ref oSheet, i, ref lmListaCabos, ref list, ref text, _0020: false, mCadernoCabos)))
				{
					list.Add(text);
					ExcFuncoesExcel.LimpaErro(ref oSheet, Conversions.ToString(i));
					num2 = Information.UBound(mCabos) + 1;
					mCabos = (StructureCabo[])Utils.CopyArray(mCabos, new StructureCabo[num2 + 1]);
					mCabos[num2].iLinha = i;
					mCabos[num2].iPn1 = Dicionario.BuscaIndiceDoPainel(((_Worksheet)oSheet).get_Range((object)("A" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
						.Trim());
					mCabos[num2].iPn2 = Dicionario.BuscaIndiceDoPainel(((_Worksheet)oSheet).get_Range((object)("B" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
						.Trim());
					mCabos[num2].sTag = text;
					if (Versioned.IsNumeric(((_Worksheet)oSheet).get_Range((object)("G" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
						.Trim()))
					{
						int num5 = Conversions.ToInteger(((_Worksheet)oSheet).get_Range((object)("G" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
						if (num5 > 1)
						{
							((_Worksheet)oSheet).get_Range((object)("D" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'1");
						}
					}
					mCabos[num2].sVeias = ((_Worksheet)oSheet).get_Range((object)("D" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
						.Trim();
					mCabos[num2].sSecao = ((_Worksheet)oSheet).get_Range((object)("E" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
						.Trim();
					if (Conversions.ToInteger(((_Worksheet)oSheet).get_Range((object)("G" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
						.Trim()) != 1)
					{
						mCabos[num2].sFormacao = "1x" + ((_Worksheet)oSheet).get_Range((object)("E" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
							.Trim();
					}
					else
					{
						mCabos[num2].sFormacao = ((_Worksheet)oSheet).get_Range((object)("D" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
							.Trim() + "x" + ((_Worksheet)oSheet).get_Range((object)("E" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
							.Trim();
					}
					mCabos[num2].iCabos = Conversions.ToInteger(((_Worksheet)oSheet).get_Range((object)("G" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
						.Trim());
					mCabos[num2].bBlindagem = Conversions.ToBoolean(((_Worksheet)oSheet).get_Range((object)("F" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
						.Trim());
					mCabos[num2].iAterrar = Conversions.ToInteger(((_Worksheet)oSheet).get_Range((object)("H" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
						.Trim());
					mCabos[num2].sFuncao = ((_Worksheet)oSheet).get_Range((object)("I" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
						.Trim();
					mCabos[num2].sFuncao = "";
					if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(((_Worksheet)oSheet).get_Range((object)("I" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))))
					{
						mCabos[num2].sFuncao = ((_Worksheet)oSheet).get_Range((object)("I" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
							.Trim();
					}
					mCabos[num2].dComprimento = 0.0;
					if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(((_Worksheet)oSheet).get_Range((object)("J" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))) && Versioned.IsNumeric(((_Worksheet)oSheet).get_Range((object)("J" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()))
					{
						mCabos[num2].dComprimento = Conversions.ToDouble(((_Worksheet)oSheet).get_Range((object)("J" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
							.Trim());
					}
					mCabos[num2].sTrajeto = "";
					if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(((_Worksheet)oSheet).get_Range((object)("K" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))))
					{
						mCabos[num2].sTrajeto = ((_Worksheet)oSheet).get_Range((object)("K" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
							.Trim();
					}
					mCabos[num2].sTagAntigo = "";
				}
				i++;
				DeclaracoesGeral._uscPagina.pbPasso();
			}
			DeclaracoesGeral._uscPagina.pbFim();
		}
	}

	public static void AdicionaBDCabosDoExcel(ref Worksheet oSheet, ref StructureCabo[] mCabos, NomeVeias nv, ref CDadosAccessInterligacao cDadosAccessInterligacao)
	{
		DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mCabos);
		DeclaracoesGeral._uscPagina.pbIniciar();
		int num = Information.UBound(mCabos);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				StructureCabo cabo = mCabos[i];
				cDadosAccessInterligacao.RemoveCaboErro(cabo.sTag);
				if (LancaUmCabo(cabo, nv, ref cDadosAccessInterligacao))
				{
					for (int j = 2; Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)("C" + Conversions.ToString(j)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true); j++)
					{
						string left = ((_Worksheet)oSheet).get_Range((object)("C" + Conversions.ToString(j)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
							.Trim();
						if (Operators.CompareString(left, cabo.sTag, TextCompare: true) == 0)
						{
							string text = ExcFuncoesExcel.mudaNumeroAsc(3L);
							_ = text + j;
							ExcFuncoesExcel.PintaCelula(ref oSheet, text, Conversions.ToString(j), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1253]), 4, 1, 100);
							text = "A" + Conversions.ToString(j);
							((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
							break;
						}
					}
				}
				DeclaracoesGeral._uscPagina.pbPasso();
			}
			DeclaracoesGeral._uscPagina.pbFim();
		}
	}

	public static void CarregaOsCabosDoExcelParaEdicao(ref Worksheet oSheet, ref StructureCabo[] mCabos, List<string> lmListaCabos, NomeVeias nv, ref CaboDWG[] mCabosDWG, ref CaboDWG[] mCabosEditar, StructureCabo[] mmCadernoCabos, ref CDadosAccessInterligacao cDadosAccessInterligacao)
	{
		int i = 2;
		int num = 1;
		string cell = "A2";
		checked
		{
			while (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
			{
				num++;
				cell = "A" + Conversions.ToString(num);
			}
			List<string> list = new List<string>();
			list.Clear();
			DeclaracoesGeral._uscPagina.Quantidade = num;
			DeclaracoesGeral._uscPagina.pbIniciar();
			int num2 = 1;
			for (; Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)("A" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true); i++)
			{
				ExcFuncoesExcel.LimpaErro(ref oSheet, Conversions.ToString(i));
			}
			i = 2;
			while (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)("A" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
			{
				int num3 = 1;
				do
				{
					string cell2 = ExcFuncoesExcel.mudaNumeroAsc(num3) + i;
					if (Information.IsNothing(RuntimeHelpers.GetObjectValue(((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))))
					{
						ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(num3), Conversions.ToString(i), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1252]), 3);
					}
					num3++;
				}
				while (num3 <= 8);
				string cell3 = "A" + Conversions.ToString(i);
				((_Worksheet)oSheet).get_Range((object)cell3, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
				int num4 = 1;
				do
				{
					string cell4 = ExcFuncoesExcel.mudaNumeroAsc(num4) + i;
					if (Information.IsNothing(RuntimeHelpers.GetObjectValue(((_Worksheet)oSheet).get_Range((object)cell4, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))))
					{
						((_Worksheet)oSheet).get_Range((object)cell4, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)" ");
					}
					num4++;
				}
				while (num4 <= 11);
				string text = "";
				if (Conversions.ToBoolean(VNEpy4gRec(ref oSheet, i, ref lmListaCabos, ref list, ref text, _0020: true, mmCadernoCabos)))
				{
					if (Operators.CompareString(((_Worksheet)oSheet).get_Range((object)"L1", RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
						.Trim(), "", TextCompare: true) != 0)
					{
						if (Operators.CompareString(((_Worksheet)oSheet).get_Range((object)("L" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
							.ToUpper()
							.Trim(), text.ToString().ToUpper().Trim(), TextCompare: true) != 0)
						{
							num2 = Information.UBound(mCabosDWG) + 1;
							mCabosDWG = (CaboDWG[])Utils.CopyArray(mCabosDWG, new CaboDWG[num2 + 1]);
							mCabosDWG[num2].sTagNovo = text;
							mCabosDWG[num2].sTagOriginal = ((_Worksheet)oSheet).get_Range((object)("L" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
								.Trim();
							mCabosDWG[num2].iPn1 = Dicionario.BuscaIndiceDoPainel(((_Worksheet)oSheet).get_Range((object)("A" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
								.Trim());
							mCabosDWG[num2].iPn2 = Dicionario.BuscaIndiceDoPainel(((_Worksheet)oSheet).get_Range((object)("B" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
								.Trim());
						}
						num2 = Information.UBound(mCabosEditar) + 1;
						mCabosEditar = (CaboDWG[])Utils.CopyArray(mCabosEditar, new CaboDWG[num2 + 1]);
						mCabosEditar[num2].sTagNovo = text;
						mCabosEditar[num2].sTagOriginal = ((_Worksheet)oSheet).get_Range((object)("L" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
							.Trim();
						mCabosEditar[num2].iPn1 = Dicionario.BuscaIndiceDoPainel(((_Worksheet)oSheet).get_Range((object)("A" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
							.Trim());
						mCabosEditar[num2].iPn2 = Dicionario.BuscaIndiceDoPainel(((_Worksheet)oSheet).get_Range((object)("B" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
							.Trim());
					}
					list.Add(text);
					num2 = Information.UBound(mCabos) + 1;
					mCabos = (StructureCabo[])Utils.CopyArray(mCabos, new StructureCabo[num2 + 1]);
					mCabos[num2].iLinha = i;
					mCabos[num2].iPn1 = Dicionario.BuscaIndiceDoPainel(((_Worksheet)oSheet).get_Range((object)("A" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
						.Trim());
					mCabos[num2].iPn2 = Dicionario.BuscaIndiceDoPainel(((_Worksheet)oSheet).get_Range((object)("B" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
						.Trim());
					mCabos[num2].sTag = text;
					if (Versioned.IsNumeric(((_Worksheet)oSheet).get_Range((object)("G" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
						.Trim()))
					{
						int num5 = Conversions.ToInteger(((_Worksheet)oSheet).get_Range((object)("G" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
						if (num5 > 1)
						{
							((_Worksheet)oSheet).get_Range((object)("D" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'1");
						}
					}
					mCabos[num2].sVeias = ((_Worksheet)oSheet).get_Range((object)("D" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
						.Trim();
					mCabos[num2].sSecao = ((_Worksheet)oSheet).get_Range((object)("E" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
						.Trim();
					if (Conversions.ToInteger(((_Worksheet)oSheet).get_Range((object)("G" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
						.Trim()) != 1)
					{
						mCabos[num2].sFormacao = ((_Worksheet)oSheet).get_Range((object)("E" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
							.Trim();
					}
					else
					{
						mCabos[num2].sFormacao = ((_Worksheet)oSheet).get_Range((object)("D" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
							.Trim() + "x" + ((_Worksheet)oSheet).get_Range((object)("E" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
							.Trim();
					}
					mCabos[num2].iCabos = Conversions.ToInteger(((_Worksheet)oSheet).get_Range((object)("G" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
						.Trim());
					mCabos[num2].bBlindagem = Conversions.ToBoolean(((_Worksheet)oSheet).get_Range((object)("F" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
						.Trim());
					mCabos[num2].iAterrar = Conversions.ToInteger(((_Worksheet)oSheet).get_Range((object)("H" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
						.Trim());
					mCabos[num2].sFuncao = ((_Worksheet)oSheet).get_Range((object)("I" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
						.Trim();
					mCabos[num2].dComprimento = 0.0;
					if (Operators.CompareString(((_Worksheet)oSheet).get_Range((object)("J" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
						.Trim(), "", TextCompare: true) != 0 && Versioned.IsNumeric(((_Worksheet)oSheet).get_Range((object)("J" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()))
					{
						mCabos[num2].dComprimento = Conversions.ToDouble(((_Worksheet)oSheet).get_Range((object)("J" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
							.Trim());
					}
					mCabos[num2].sTrajeto = ((_Worksheet)oSheet).get_Range((object)("K" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
						.Trim();
					mCabos[num2].sTagAntigo = clsTextos.TiraNothing(((_Worksheet)oSheet).get_Range((object)("L" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
						.Trim());
				}
				i++;
				DeclaracoesGeral._uscPagina.pbPasso();
			}
			DeclaracoesGeral._uscPagina.pbFim();
			if (Information.UBound(mCabosDWG) > 0)
			{
				RemoveOsCabosAntigos(ref mCabosDWG, ref cDadosAccessInterligacao);
			}
			if (Information.UBound(mCabos) <= 0)
			{
				return;
			}
			DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mCabos);
			DeclaracoesGeral._uscPagina.pbIniciar();
			int num6 = Information.UBound(mCabos);
			for (int j = 1; j <= num6; j++)
			{
				StructureCabo structureCabo = mCabos[j];
				cDadosAccessInterligacao.RemoveCaboErro(structureCabo.sTag);
			}
			int num7 = Information.UBound(mCabos);
			for (int k = 1; k <= num7; k++)
			{
				StructureCabo structureCabo = mCabos[k];
				if (LancaUmCabo(structureCabo, nv, ref cDadosAccessInterligacao))
				{
					for (i = 2; Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)("C" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true); i++)
					{
						string left = ((_Worksheet)oSheet).get_Range((object)("C" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
							.Trim();
						if (Operators.CompareString(left, structureCabo.sTag, TextCompare: true) == 0)
						{
							string text2 = ExcFuncoesExcel.mudaNumeroAsc(3L);
							_ = text2 + i;
							ExcFuncoesExcel.PintaCelula(ref oSheet, "C", Conversions.ToString(i), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1254]), 46, 1, 100);
							text2 = "A" + Conversions.ToString(i);
							((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
							break;
						}
					}
				}
				DeclaracoesGeral._uscPagina.pbPasso();
			}
			DeclaracoesGeral._uscPagina.pbFim();
		}
	}

	private static object VNEpy4gRec(ref Worksheet P_0, int P_1, ref List<string> P_2, ref List<string> P_3, ref string P_4, bool P_5, StructureCabo[] P_6)
	{
		bool flag = true;
		string text = clsTextos.TiraNothing(((_Worksheet)P_0).get_Range((object)("A" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
			.Trim());
		string text2 = clsTextos.TiraNothing(((_Worksheet)P_0).get_Range((object)("B" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
			.Trim());
		P_4 = clsTextos.TiraNothing(((_Worksheet)P_0).get_Range((object)("C" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
			.Trim());
		string text3 = clsTextos.TiraNothing(((_Worksheet)P_0).get_Range((object)("D" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
			.Trim());
		string left = clsTextos.TiraNothing(((_Worksheet)P_0).get_Range((object)("E" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
			.Trim());
		bool flag2 = Conversions.ToBoolean(((_Worksheet)P_0).get_Range((object)("F" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
			.Trim());
		string left2 = clsTextos.TiraNothing(((_Worksheet)P_0).get_Range((object)("G" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
			.Trim());
		string left3 = clsTextos.TiraNothing(((_Worksheet)P_0).get_Range((object)("H" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
			.Trim());
		string left4 = clsTextos.TiraNothing(((_Worksheet)P_0).get_Range((object)("I" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
			.Trim());
		string left5 = clsTextos.TiraNothing(((_Worksheet)P_0).get_Range((object)("J" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
			.Trim());
		if (Operators.CompareString(left5, "", TextCompare: true) == 0)
		{
			left5 = "0";
			((_Worksheet)P_0).get_Range((object)("J" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"0");
		}
		string left6 = clsTextos.TiraNothing(((_Worksheet)P_0).get_Range((object)("K" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
			.Trim());
		string text4 = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)P_0).get_Range((object)("L" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
		if (Conversions.ToInteger(((_Worksheet)P_0).get_Range((object)("G" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
			.Trim()) != 1)
		{
			_ = "1x" + ((_Worksheet)P_0).get_Range((object)("E" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
				.Trim();
		}
		else
		{
			_ = ((_Worksheet)P_0).get_Range((object)("D" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
				.Trim() + "x" + ((_Worksheet)P_0).get_Range((object)("E" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
				.Trim();
		}
		if (Operators.CompareString(text4, "", TextCompare: true) == 0)
		{
			text4 = P_4;
		}
		bool flag3 = false;
		int num = Information.UBound(P_6);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (Operators.CompareString(text4, P_6[i].sTag, TextCompare: true) == 0)
			{
				if (Operators.CompareString(text, Dicionario.BuscaNomeDoPainel(P_6[i].iPn1), TextCompare: true) != 0)
				{
					flag3 = true;
					ExcFuncoesExcel.PintaCelula(ref P_0, "A", Conversions.ToString(P_1), "Editado", 44, 1, 100);
				}
				if (Operators.CompareString(text2, Dicionario.BuscaNomeDoPainel(P_6[i].iPn2), TextCompare: true) != 0)
				{
					flag3 = true;
					ExcFuncoesExcel.PintaCelula(ref P_0, "B", Conversions.ToString(P_1), "Editado", 44, 1, 100);
				}
				if (Operators.CompareString(P_4, P_6[i].sTag, TextCompare: true) != 0)
				{
					flag3 = true;
					ExcFuncoesExcel.PintaCelula(ref P_0, "C", Conversions.ToString(P_1), "Editado", 44, 1, 100);
				}
				encontraVeiaSecao(P_6[i].sFormacao, P_6[i].iCabos, ref P_6[i].sVeias, ref P_6[i].sSecao);
				if (Operators.CompareString(text3, P_6[i].sVeias, TextCompare: true) != 0)
				{
					flag3 = true;
					ExcFuncoesExcel.PintaCelula(ref P_0, "D", Conversions.ToString(P_1), "Editado", 44, 1, 100);
				}
				if (Operators.CompareString(left, P_6[i].sSecao, TextCompare: true) != 0)
				{
					flag3 = true;
					ExcFuncoesExcel.PintaCelula(ref P_0, "E", Conversions.ToString(P_1), "Editado", 44, 1, 100);
				}
				if (flag2 != P_6[i].bBlindagem)
				{
					flag3 = true;
					ExcFuncoesExcel.PintaCelula(ref P_0, "F", Conversions.ToString(P_1), "Editado", 44, 1, 100);
				}
				if (Operators.CompareString(left2, P_6[i].iCabos.ToString(), TextCompare: true) != 0)
				{
					flag3 = true;
					ExcFuncoesExcel.PintaCelula(ref P_0, "G", Conversions.ToString(P_1), "Editado", 44, 1, 100);
				}
				if (Operators.CompareString(left3, P_6[i].iAterrar.ToString(), TextCompare: true) != 0)
				{
					flag3 = true;
					ExcFuncoesExcel.PintaCelula(ref P_0, "H", Conversions.ToString(P_1), "Editado", 44, 1, 100);
				}
				if (Operators.CompareString(left4, P_6[i].sFuncao, TextCompare: true) != 0)
				{
					flag3 = true;
					ExcFuncoesExcel.PintaCelula(ref P_0, "I", Conversions.ToString(P_1), "Editado", 44, 1, 100);
				}
				if (Operators.CompareString(left5, P_6[i].dComprimento.ToString(), TextCompare: true) != 0)
				{
					flag3 = true;
					ExcFuncoesExcel.PintaCelula(ref P_0, "J", Conversions.ToString(P_1), "Editado", 44, 1, 100);
				}
				if (Operators.CompareString(left6, P_6[i].sTrajeto, TextCompare: true) != 0)
				{
					flag3 = true;
					ExcFuncoesExcel.PintaCelula(ref P_0, "K", Conversions.ToString(P_1), "Editado", 44, 1, 100);
				}
				break;
			}
		}
		if (!flag3)
		{
			flag = false;
		}
		if (P_5 && Operators.ConditionalCompareObjectEqual(((_Worksheet)P_0).get_Range((object)("L" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
		{
			flag = false;
			ExcFuncoesExcel.PintaCelula(ref P_0, "C", Conversions.ToString(P_1), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1255]), 3, 1, 150);
			ExcFuncoesExcel.PintaCelula(ref P_0, "L", Conversions.ToString(P_1), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1255]), 3, 1, 150);
		}
		if ((Dicionario.BuscaIndiceDoPainel(text) == 0) | (Operators.CompareString(text, "", TextCompare: true) == 0))
		{
			flag = false;
			ExcFuncoesExcel.PintaCelula(ref P_0, "A", Conversions.ToString(P_1), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1256]), 3, 1, 100);
		}
		if ((Dicionario.BuscaIndiceDoPainel(text2) == 0) | (Operators.CompareString(text2, "", TextCompare: true) == 0))
		{
			flag = false;
			ExcFuncoesExcel.PintaCelula(ref P_0, "B", Conversions.ToString(P_1), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1256]), 3, 1, 100);
		}
		if (Operators.CompareString(text, text2, TextCompare: true) == 0)
		{
			flag = false;
			ExcFuncoesExcel.PintaCelula(ref P_0, "A", Conversions.ToString(P_1), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1257]), 3, 1, 100);
			ExcFuncoesExcel.PintaCelula(ref P_0, "B", Conversions.ToString(P_1), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1257]), 3, 1, 100);
		}
		if ((P_2.Contains(P_4) | P_3.Contains(P_4)) && !P_5)
		{
			flag = false;
			ExcFuncoesExcel.PintaCelula(ref P_0, "C", Conversions.ToString(P_1), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1258]), 46, 1, 150);
		}
		if (Operators.CompareString(P_4, text4, TextCompare: true) != 0 && P_2.Contains(P_4))
		{
			flag = false;
			ExcFuncoesExcel.PintaCelula(ref P_0, "C", Conversions.ToString(P_1), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1258]), 3, 1, 150);
		}
		if (!((Operators.CompareString(text3.Trim(), "", TextCompare: true) == 0) | (Operators.CompareString(text3.Trim(), "0", TextCompare: true) == 0)))
		{
			if (!Versioned.IsNumeric(text3))
			{
				text3 = text3.ToUpper();
				string left7 = Strings.Mid(text3, Strings.Len(text3), 1);
				if (Operators.CompareString(left7, "P", TextCompare: true) != 0)
				{
					if (Operators.CompareString(left7, "T", TextCompare: true) != 0)
					{
						flag = false;
						ExcFuncoesExcel.PintaCelula(ref P_0, "D", Conversions.ToString(P_1), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1259]), 3, 1, 100);
					}
					else
					{
						((_Worksheet)P_0).get_Range((object)("D" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)text3);
					}
				}
				else
				{
					((_Worksheet)P_0).get_Range((object)("D" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)text3);
				}
			}
		}
		else
		{
			flag = false;
			ExcFuncoesExcel.PintaCelula(ref P_0, "D", Conversions.ToString(P_1), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1259]), 3, 1, 100);
		}
		if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(((_Worksheet)P_0).get_Range((object)("F" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))))
		{
			if ((Conversions.ToInteger(((_Worksheet)P_0).get_Range((object)("G" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))) < 0) | (Conversions.ToInteger(((_Worksheet)P_0).get_Range((object)("F" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))) > 3))
			{
				flag = false;
				ExcFuncoesExcel.PintaCelula(ref P_0, "F", Conversions.ToString(P_1), "", 3);
			}
			if (Conversions.ToInteger(((_Worksheet)P_0).get_Range((object)("G" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))) == 0)
			{
				flag = false;
				ExcFuncoesExcel.PintaCelula(ref P_0, "G", Conversions.ToString(P_1), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1259]), 3, 1, 100);
			}
		}
		else
		{
			flag = false;
			ExcFuncoesExcel.PintaCelula(ref P_0, "F", Conversions.ToString(P_1), "", 3);
		}
		if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(((_Worksheet)P_0).get_Range((object)("G" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))))
		{
			if (Operators.CompareString(((_Worksheet)P_0).get_Range((object)("G" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
				.Trim(), "1", TextCompare: true) != 0 && !Versioned.IsNumeric(text3))
			{
				ExcFuncoesExcel.PintaCelula(ref P_0, "D", Conversions.ToString(P_1), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1260]), 3, 1, 100);
				ExcFuncoesExcel.PintaCelula(ref P_0, "G", Conversions.ToString(P_1), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1260]), 3, 1, 100);
				flag = false;
			}
		}
		else
		{
			flag = false;
		}
		if (!Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(((_Worksheet)P_0).get_Range((object)("H" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))))
		{
			flag = false;
			ExcFuncoesExcel.PintaCelula(ref P_0, "H", Conversions.ToString(P_1), "", 3);
		}
		if (Strings.Len(RuntimeHelpers.GetObjectValue(((_Worksheet)P_0).get_Range((object)("I" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))) > 255)
		{
			flag = false;
			ExcFuncoesExcel.PintaCelula(ref P_0, "I", Conversions.ToString(P_1), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1304]), 3, 1, 180);
		}
		return flag;
	}

	public static void encontraVeiaSecao(string sFormacao, int iCabos, ref string sveia, ref string sSecao)
	{
		if (iCabos != 1)
		{
			if (!Versioned.IsNumeric(sFormacao))
			{
				string[] array = sFormacao.Split('x');
				sveia = Conversions.ToString(1);
				sSecao = array[1].Trim();
			}
			else
			{
				sveia = Conversions.ToString(1);
				sSecao = sFormacao;
			}
		}
		else
		{
			string[] array2 = sFormacao.Split('x');
			sveia = array2[0].Trim();
			sSecao = array2[1].Trim();
		}
	}

	private static object vkypgJ9yxl(ref Worksheet P_0, int P_1, ref List<string> P_2, ref List<string> P_3, ref string P_4, bool P_5, StructureCabo[] P_6)
	{
		bool flag = true;
		string text = clsTextos.TiraNothing(((_Worksheet)P_0).get_Range((object)("A" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
			.Trim());
		string text2 = clsTextos.TiraNothing(((_Worksheet)P_0).get_Range((object)("B" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
			.Trim());
		P_4 = clsTextos.TiraNothing(((_Worksheet)P_0).get_Range((object)("C" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
			.Trim());
		string text3 = clsTextos.TiraNothing(((_Worksheet)P_0).get_Range((object)("D" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
			.Trim());
		string text4 = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)P_0).get_Range((object)("J" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
		if (Operators.CompareString(text4.Trim(), "", TextCompare: true) == 0)
		{
			((_Worksheet)P_0).get_Range((object)("J" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"0");
		}
		((_Worksheet)P_0).get_Range((object)("K" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)P_0).get_Range((object)("K" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))));
		if (P_5 && Operators.ConditionalCompareObjectEqual(((_Worksheet)P_0).get_Range((object)("L" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
		{
			flag = false;
			ExcFuncoesExcel.PintaCelula(ref P_0, "C", Conversions.ToString(P_1), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1255]), 3, 1, 150);
			ExcFuncoesExcel.PintaCelula(ref P_0, "L", Conversions.ToString(P_1), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1255]), 3, 1, 150);
		}
		if ((Dicionario.BuscaIndiceDoPainel(text) == 0) | (Operators.CompareString(text, "", TextCompare: true) == 0))
		{
			flag = false;
			ExcFuncoesExcel.PintaCelula(ref P_0, "A", Conversions.ToString(P_1), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1256]), 3, 1, 100);
		}
		if ((Dicionario.BuscaIndiceDoPainel(text2) == 0) | (Operators.CompareString(text2, "", TextCompare: true) == 0))
		{
			flag = false;
			ExcFuncoesExcel.PintaCelula(ref P_0, "B", Conversions.ToString(P_1), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1256]), 3, 1, 100);
		}
		if (Operators.CompareString(text, text2, TextCompare: true) == 0)
		{
			flag = false;
			ExcFuncoesExcel.PintaCelula(ref P_0, "A", Conversions.ToString(P_1), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1257]), 3, 1, 100);
			ExcFuncoesExcel.PintaCelula(ref P_0, "B", Conversions.ToString(P_1), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1257]), 3, 1, 100);
		}
		if ((P_2.Contains(P_4) | P_3.Contains(P_4)) && !P_5)
		{
			flag = false;
			ExcFuncoesExcel.PintaCelula(ref P_0, "C", Conversions.ToString(P_1), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1258]), 46, 1, 150);
		}
		if (!((Operators.CompareString(text3.Trim(), "", TextCompare: true) == 0) | (Operators.CompareString(text3.Trim(), "0", TextCompare: true) == 0)))
		{
			if (!Versioned.IsNumeric(text3))
			{
				text3 = text3.ToUpper();
				string left = Strings.Mid(text3, Strings.Len(text3), 1);
				if (Operators.CompareString(left, "P", TextCompare: true) != 0)
				{
					if (Operators.CompareString(left, "T", TextCompare: true) != 0)
					{
						flag = false;
						ExcFuncoesExcel.PintaCelula(ref P_0, "D", Conversions.ToString(P_1), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1259]), 3, 1, 100);
					}
					else
					{
						((_Worksheet)P_0).get_Range((object)("D" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)text3);
					}
				}
				else
				{
					((_Worksheet)P_0).get_Range((object)("D" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)text3);
				}
			}
		}
		else
		{
			flag = false;
			ExcFuncoesExcel.PintaCelula(ref P_0, "D", Conversions.ToString(P_1), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1259]), 3, 1, 100);
		}
		if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(((_Worksheet)P_0).get_Range((object)("F" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))))
		{
			if ((Conversions.ToInteger(((_Worksheet)P_0).get_Range((object)("G" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))) < 0) | (Conversions.ToInteger(((_Worksheet)P_0).get_Range((object)("F" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))) > 3))
			{
				flag = false;
				ExcFuncoesExcel.PintaCelula(ref P_0, "F", Conversions.ToString(P_1), "", 3);
			}
			if (Conversions.ToInteger(((_Worksheet)P_0).get_Range((object)("G" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))) == 0)
			{
				flag = false;
				ExcFuncoesExcel.PintaCelula(ref P_0, "G", Conversions.ToString(P_1), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1259]), 3, 1, 100);
			}
		}
		else
		{
			flag = false;
			ExcFuncoesExcel.PintaCelula(ref P_0, "F", Conversions.ToString(P_1), "", 3);
		}
		if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(((_Worksheet)P_0).get_Range((object)("G" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))))
		{
			if (Operators.CompareString(((_Worksheet)P_0).get_Range((object)("G" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString()
				.Trim(), "1", TextCompare: true) != 0 && !Versioned.IsNumeric(text3))
			{
				ExcFuncoesExcel.PintaCelula(ref P_0, "D", Conversions.ToString(P_1), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1260]), 3, 1, 100);
				ExcFuncoesExcel.PintaCelula(ref P_0, "G", Conversions.ToString(P_1), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1260]), 3, 1, 100);
				flag = false;
			}
		}
		else
		{
			flag = false;
		}
		if (!Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(((_Worksheet)P_0).get_Range((object)("H" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))))
		{
			flag = false;
			ExcFuncoesExcel.PintaCelula(ref P_0, "H", Conversions.ToString(P_1), "", 3);
		}
		if (Strings.Len(RuntimeHelpers.GetObjectValue(((_Worksheet)P_0).get_Range((object)("I" + Conversions.ToString(P_1)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))) > 255)
		{
			flag = false;
			ExcFuncoesExcel.PintaCelula(ref P_0, "I", Conversions.ToString(P_1), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1304]), 3, 1, 180);
		}
		return flag;
	}

	public static void RemoveOsCabosAntigos(ref CaboDWG[] mCabosDWG, ref CDadosAccessInterligacao CDadosAccessInterligacao)
	{
		if (Information.UBound(mCabosDWG) > 0)
		{
			DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mCabosDWG);
			DeclaracoesGeral._uscPagina.pbIniciar();
			int num = Information.UBound(mCabosDWG);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				CDadosAccessInterligacao.RemoveCaboErro(mCabosDWG[i].sTagOriginal);
				DeclaracoesGeral._uscPagina.pbPasso();
			}
			DeclaracoesGeral._uscPagina.pbFim();
		}
	}

	public static bool LancaUmCabo(StructureCabo cabo, NomeVeias nv, ref CDadosAccessInterligacao cDadosAccessInterligacao)
	{
		bool result = true;
		VeiaCabo Veia = default;
		CalculaVeiasEBlindagens(ref Veia, ref cabo);
		Veia.sTag = cabo.sTag;
		cabo.iAlarme = 0;
		if (cabo.iCabos != 1)
		{
			cabo.sFormacao = "1x" + cabo.sSecao.ToString();
		}
		if (!cDadosAccessInterligacao.LancaUmCaboNoBanco(cabo))
		{
			result = false;
		}
		else if (!LancaUmaVeia(Veia, cabo, nv, ref cDadosAccessInterligacao))
		{
			result = false;
		}
		return result;
	}

	public static bool LancaUmaVeia(VeiaCabo Veia, StructureCabo cabo, NomeVeias nv, ref CDadosAccessInterligacao cDadosAccessInterligacao)
	{
		bool result = true;
		if (Veia.iNumBlColetivas != 2)
		{
			goto IL_000d;
		}
		string sFuncao = "";
		string blVar = nv.blVar;
		if (cDadosAccessInterligacao.AddParteDeUmaVeia(Veia.sTag, 0, blVar, sFuncao))
		{
			if (cDadosAccessInterligacao.AddParteDeUmaVeia(Veia.sTag, -99, blVar, sFuncao))
			{
				goto IL_000d;
			}
			result = false;
		}
		else
		{
			result = false;
		}
		goto IL_0313;
		IL_000d:
		checked
		{
			if (Veia.iNumBlIndividuais > 0)
			{
				int iNumBlIndividuais = Veia.iNumBlIndividuais;
				int num = 1;
				while (num <= iNumBlIndividuais)
				{
					string sFuncao2 = "";
					string sNome = Conversions.ToString(num) + nv.blVar;
					if (!cDadosAccessInterligacao.AddParteDeUmaVeia(Veia.sTag, num * -1, sNome, sFuncao2))
					{
						goto IL_0129;
					}
					if (cDadosAccessInterligacao.AddParteDeUmaVeia(Veia.sTag, num * -1 - 50, sNome, sFuncao2))
					{
						num++;
						continue;
					}
					goto IL_0130;
				}
			}
			if (Operators.CompareString(Veia.sTipo, "S", TextCompare: true) != 0)
			{
				string text = "";
				if (Operators.CompareString(Veia.sTipo, "P", TextCompare: true) != 0)
				{
					if (Operators.CompareString(Veia.sTipo, "T", TextCompare: true) == 0)
					{
						int num2 = 0;
						int num3 = 1;
						int iNumVeias = Veia.iNumVeias;
						for (int num = 1; num <= iNumVeias; num++)
						{
							num2++;
							switch (num2)
							{
							case 4:
								num2 = 1;
								text = nv.T1Var;
								num3++;
								break;
							case 1:
								text = nv.T1Var;
								break;
							case 2:
								text = nv.T2Var;
								break;
							case 3:
								text = nv.T3Var;
								break;
							}
							string sFuncao3 = "";
							string sNome2 = Conversions.ToString(num3) + text;
							if (!cDadosAccessInterligacao.AddParteDeUmaVeia(Veia.sTag, num, sNome2, sFuncao3))
							{
								result = false;
								break;
							}
						}
					}
				}
				else
				{
					int num2 = 0;
					int num3 = 1;
					int iNumVeias2 = Veia.iNumVeias;
					for (int num = 1; num <= iNumVeias2; num++)
					{
						num2++;
						switch (num2)
						{
						case 3:
							num2 = 1;
							text = nv.P1Var;
							num3++;
							break;
						case 1:
							text = nv.P1Var;
							break;
						case 2:
							text = nv.P2Var;
							break;
						}
						string sFuncao4 = "";
						string sNome3 = Conversions.ToString(num3) + text;
						if (!cDadosAccessInterligacao.AddParteDeUmaVeia(Veia.sTag, num, sNome3, sFuncao4))
						{
							result = false;
							break;
						}
					}
				}
			}
			else if (cabo.iCabos <= 1)
			{
				int iNumVeias3 = Veia.iNumVeias;
				for (int num = 1; num <= iNumVeias3; num++)
				{
					string sFuncao5 = "";
					string sNome4 = "";
					if (!cDadosAccessInterligacao.AddParteDeUmaVeia(Veia.sTag, num, sNome4, sFuncao5))
					{
						result = false;
						break;
					}
				}
			}
			else
			{
				string sFuncao6 = "";
				if (!cDadosAccessInterligacao.AddParteDeUmaVeia(Veia.sTag, 1, Conversions.ToString(cabo.iCabos) + "#" + cabo.sSecao, sFuncao6))
				{
					result = false;
				}
			}
			goto IL_0313;
		}
		IL_0130:
		result = false;
		goto IL_0313;
		IL_0313:
		return result;
		IL_0129:
		result = false;
		goto IL_0313;
	}

	public static void CalculaVeiasEBlindagens(ref VeiaCabo Veia, ref StructureCabo cabo)
	{
		checked
		{
			if (Versioned.IsNumeric(cabo.sVeias))
			{
				Veia.iNumVeias = Conversions.ToInteger(cabo.sVeias);
				Veia.sTipo = "S";
				Veia.iNumBlIndividuais = 0;
			}
			else if ((Strings.Len(cabo.sVeias) > 1) & ((Operators.CompareString(Strings.Mid(cabo.sVeias, Strings.Len(cabo.sVeias), 1), "P", TextCompare: true) == 0) | (Operators.CompareString(Strings.Mid(cabo.sVeias, Strings.Len(cabo.sVeias), 1), "T", TextCompare: true) == 0)) & Versioned.IsNumeric(Strings.Mid(cabo.sVeias, 1, Strings.Len(cabo.sVeias) - 1)))
			{
				if (Operators.CompareString(Strings.Mid(cabo.sVeias, Strings.Len(cabo.sVeias), 1), "P", TextCompare: true) != 0)
				{
					if (Operators.CompareString(Strings.Mid(cabo.sVeias, Strings.Len(cabo.sVeias), 1), "T", TextCompare: true) == 0)
					{
						Veia.iNumVeias = Conversions.ToInteger(Strings.Mid(cabo.sVeias, 1, Strings.Len(cabo.sVeias) - 1)) * 3;
						Veia.sTipo = "T";
					}
				}
				else
				{
					Veia.iNumVeias = Conversions.ToInteger(Strings.Mid(cabo.sVeias, 1, Strings.Len(cabo.sVeias) - 1)) * 2;
					Veia.sTipo = "P";
				}
				Veia.iNumBlIndividuais = Conversions.ToInteger(Strings.Mid(cabo.sVeias, 1, Strings.Len(cabo.sVeias) - 1));
			}
			if (!cabo.bBlindagem)
			{
				Veia.iNumBlColetivas = 0;
			}
			else
			{
				Veia.iNumBlColetivas = 2;
			}
		}
	}

	public static void ExportaModeloDeCabosParaOExcel(ref Worksheet oSheet)
	{
		ExcFuncoesExcel.LimpaSheet(ref oSheet);
		int num = 1;
		string cell;
		do
		{
			cell = ExcFuncoesExcel.mudaNumeroAsc(num) + "1";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
			num = checked(num + 1);
		}
		while (num <= 15);
		cell = ExcFuncoesExcel.mudaNumeroAsc(1L) + "1";
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 429].ToString().ToUpper());
		ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(1L), "1", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1261]), 43, 2, 150);
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 15;
		cell = ExcFuncoesExcel.mudaNumeroAsc(2L) + "1";
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 432].ToString().ToUpper());
		ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(2L), "1", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1262]), 43, 2, 150);
		cell = ExcFuncoesExcel.mudaNumeroAsc(3L) + "1";
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 389].ToString().ToUpper());
		ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(3L), "1", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1238]), 43, 1);
		cell = ExcFuncoesExcel.mudaNumeroAsc(4L) + "1";
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 1239].ToString().ToUpper());
		ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(4L), "1", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1263], "\r\n"), DeclaracoesGeral.mMensagem[1, 1264]), "\r\n"), DeclaracoesGeral.mMensagem[1, 1265])), 43, 3, 180);
		cell = ExcFuncoesExcel.mudaNumeroAsc(5L) + "1";
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 1240].ToString().ToUpper());
		ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(5L), "1", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1266]), 43, 1);
		cell = ExcFuncoesExcel.mudaNumeroAsc(6L) + "1";
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 565].ToString().ToUpper());
		ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(6L), "1", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 19], "= 1"), "\r\n"), DeclaracoesGeral.mMensagem[1, 20]), " = 0")), 43, 2, 50);
		cell = ExcFuncoesExcel.mudaNumeroAsc(7L) + "1";
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 7;
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 514].ToString().ToUpper());
		ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(7L), "1", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1267]), 43, 4, 120);
		cell = ExcFuncoesExcel.mudaNumeroAsc(8L) + "1";
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 1243].ToString().ToUpper());
		ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(8L), "1", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1268], "\r\n"), DeclaracoesGeral.mMensagem[1, 20]), " = 0"), "\r\n"), DeclaracoesGeral.mMensagem[1, 429]), " = 1"), "\r\n"), DeclaracoesGeral.mMensagem[1, 432]), " = 2"), "\r\n"), DeclaracoesGeral.mMensagem[1, 1269]), " = 3")), 43, 5, 150);
		cell = ExcFuncoesExcel.mudaNumeroAsc(9L) + "1";
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 35;
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 1244].ToString().ToUpper());
		ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(9L), "1", Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1270], DeclaracoesGeral.mMensagem[1, 1271])), 37, 2, 100);
		cell = ExcFuncoesExcel.mudaNumeroAsc(10L) + "1";
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 1246].ToString().ToUpper());
		ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(10L), "1", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1272], "\r\n"), DeclaracoesGeral.mMensagem[1, 1271])), 37, 2, 120);
		cell = ExcFuncoesExcel.mudaNumeroAsc(11L) + "1";
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 35;
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 1248].ToString().ToUpper());
		ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(11L), "1", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1273], "\r\n"), DeclaracoesGeral.mMensagem[1, 1271])), 37, 2, 130);
	}

	public static void ExportaCabosParaOExcel(ref Worksheet oSheet, ref DataGridView dg, string sTipo)
	{
		ExcFuncoesExcel.LimpaSheet(ref oSheet);
		int num = 1;
		checked
		{
			string cell;
			do
			{
				cell = ExcFuncoesExcel.mudaNumeroAsc(num) + "1";
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				num++;
			}
			while (num <= 15);
			cell = ExcFuncoesExcel.mudaNumeroAsc(1L) + "1";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 429].ToString().ToUpper());
			ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(1L), "1", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1261]), 43, 2, 150);
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 15;
			cell = ExcFuncoesExcel.mudaNumeroAsc(2L) + "1";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 432].ToString().ToUpper());
			ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(2L), "1", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1262]), 43, 2, 150);
			cell = ExcFuncoesExcel.mudaNumeroAsc(3L) + "1";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 389].ToString().ToUpper());
			ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(3L), "1", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1238]), 43, 1);
			cell = ExcFuncoesExcel.mudaNumeroAsc(4L) + "1";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 1239].ToString().ToUpper());
			ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(4L), "1", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1263], "\r\n"), DeclaracoesGeral.mMensagem[1, 1264]), "\r\n"), DeclaracoesGeral.mMensagem[1, 1265])), 43, 3, 180);
			cell = ExcFuncoesExcel.mudaNumeroAsc(5L) + "1";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 1240].ToString().ToUpper());
			ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(5L), "1", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1266]), 43, 1);
			cell = ExcFuncoesExcel.mudaNumeroAsc(6L) + "1";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 12;
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 565].ToString().ToUpper());
			ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(6L), "1", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 19], "= 1"), "\r\n"), DeclaracoesGeral.mMensagem[1, 20]), " = 0")), 43, 2, 50);
			cell = ExcFuncoesExcel.mudaNumeroAsc(7L) + "1";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 7;
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 514].ToString().ToUpper());
			ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(7L), "1", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1267]), 43, 4, 120);
			cell = ExcFuncoesExcel.mudaNumeroAsc(8L) + "1";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 1243].ToString().ToUpper());
			ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(8L), "1", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1268], "\r\n"), DeclaracoesGeral.mMensagem[1, 20]), " = 0"), "\r\n"), DeclaracoesGeral.mMensagem[1, 429]), " = 1"), "\r\n"), DeclaracoesGeral.mMensagem[1, 432]), " = 2"), "\r\n"), DeclaracoesGeral.mMensagem[1, 1269]), " = 3")), 43, 5, 150);
			cell = ExcFuncoesExcel.mudaNumeroAsc(9L) + "1";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 35;
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 1244].ToString().ToUpper());
			ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(9L), "1", Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1270], DeclaracoesGeral.mMensagem[1, 1271])), 37, 2, 100);
			cell = ExcFuncoesExcel.mudaNumeroAsc(10L) + "1";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 1246].ToString().ToUpper());
			ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(10L), "1", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1272], "\r\n"), DeclaracoesGeral.mMensagem[1, 1271])), 37, 2, 120);
			cell = ExcFuncoesExcel.mudaNumeroAsc(11L) + "1";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 35;
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 1248].ToString().ToUpper());
			ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(11L), "1", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1273], "\r\n"), DeclaracoesGeral.mMensagem[1, 1271])), 37, 2, 130);
			if (dg.RowCount <= 0)
			{
				return;
			}
			DeclaracoesGeral._uscPagina.Quantidade = dg.RowCount;
			DeclaracoesGeral._uscPagina.pbIniciar();
			if (Operators.CompareString(sTipo, "T", TextCompare: true) != 0)
			{
				cell = ExcFuncoesExcel.mudaNumeroAsc(12L) + "1";
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 389].ToString().ToUpper());
				ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(12L), "1", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1274]), 43, 1);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Locked = TriState.True;
			}
			DeclaracoesGeral._uscPagina.pbPasso();
			int num2 = dg.RowCount - 1;
			for (int i = 0; i <= num2; i++)
			{
				string text = "";
				int num3 = 1;
				do
				{
					text = Conversions.ToString(i + 2);
					cell = ExcFuncoesExcel.mudaNumeroAsc(num3) + text;
					((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", dg.Rows[i].Cells[num3 - 1].Value));
					num3++;
				}
				while (num3 <= 11);
				if (Operators.CompareString(sTipo, "T", TextCompare: true) != 0)
				{
					cell = ExcFuncoesExcel.mudaNumeroAsc(12L) + text;
					((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", dg.Rows[i].Cells[2].Value));
					ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(12L), text, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1274]), 15, 1);
				}
				DeclaracoesGeral._uscPagina.pbPasso();
				string cell2 = "A" + Conversions.ToString(i + 2);
				((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
			}
			DeclaracoesGeral._uscPagina.pbFim();
		}
	}

	public static void OrdenaVeias(ref DataGridView dg, int indice = 4)
	{
		string left = "";
		checked
		{
			int num = dg.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (Conversions.ToInteger(dg.Rows[i].Cells[indice].Value) == 1)
				{
					if (dg.Rows[i].Cells[1].Value.ToString().Contains("P"))
					{
						left = "P";
					}
					if (dg.Rows[i].Cells[1].Value.ToString().Contains("T"))
					{
						left = "T";
					}
				}
				if (Conversions.ToInteger(dg.Rows[i].Cells[indice].Value) == -99)
				{
					dg.Rows[i].Cells[indice].Value = 0;
				}
				if (Conversions.ToInteger(dg.Rows[i].Cells[indice].Value) < -50)
				{
					dg.Rows[i].Cells[indice].Value = Conversions.ToDouble(dg.Rows[i].Cells[indice].Value) + 50.0;
				}
			}
			if (Operators.CompareString(left, "", TextCompare: true) != 0)
			{
				int num2 = dg.Rows.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					if (Operators.ConditionalCompareObjectLess(dg.Rows[j].Cells[indice].Value, 0, TextCompare: true))
					{
						if (Operators.CompareString(left, "P", TextCompare: true) == 0)
						{
							dg.Rows[j].Cells[indice].Value = Conversions.ToDouble(dg.Rows[j].Cells[indice].Value) * 2.0;
							dg.Rows[j].Cells[indice].Value = Operators.SubtractObject(dg.Rows[j].Cells[indice].Value, 0.1);
						}
						if (Operators.CompareString(left, "T", TextCompare: true) == 0)
						{
							dg.Rows[j].Cells[indice].Value = Conversions.ToDouble(dg.Rows[j].Cells[indice].Value) * 3.0;
							dg.Rows[j].Cells[indice].Value = Operators.SubtractObject(dg.Rows[j].Cells[indice].Value, 0.1);
						}
					}
				}
				int num3 = dg.Rows.Count - 1;
				for (int k = 0; k <= num3; k++)
				{
					if (Conversions.ToInteger(dg.Rows[k].Cells[indice].Value) < 0)
					{
						dg.Rows[k].Cells[indice].Value = Conversions.ToDouble(dg.Rows[k].Cells[indice].Value) * -1.0;
					}
				}
			}
			string text = "";
			int num4 = dg.Rows.Count - 2;
			for (int l = num4; l >= 0; l += -1)
			{
				int num5 = l;
				for (int m = 0; m <= num5; m++)
				{
					if (Conversions.ToDouble(dg[indice, m].Value) > Conversions.ToDouble(dg[indice, m + 1].Value))
					{
						for (int n = 0; n <= indice; n++)
						{
							text = Conversions.ToString(dg[n, m + 1].Value);
							dg[n, m + 1].Value = RuntimeHelpers.GetObjectValue(dg[n, m].Value);
							dg[n, m].Value = text;
						}
					}
				}
			}
			DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
			dataGridViewCellStyle.BackColor = Color.LightBlue;
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			dataGridViewCellStyle2.BackColor = Color.LightGoldenrodYellow;
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			dataGridViewCellStyle3.BackColor = Color.LightGray;
			bool flag = true;
			int num6 = dg.Rows.Count - 1;
			for (int num7 = 0; num7 <= num6; num7++)
			{
				if (num7 > 0)
				{
					if (!(Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(dg.Rows[num7 - 1].Cells[1].Value)) | Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(dg.Rows[num7].Cells[1].Value))))
					{
						if (Operators.CompareString(Strings.Mid(Conversions.ToString(dg.Rows[num7 - 1].Cells[1].Value), 1, 1), Strings.Mid(Conversions.ToString(dg.Rows[num7].Cells[1].Value), 1, 1), TextCompare: true) != 0)
						{
							flag = !flag;
						}
					}
					else
					{
						flag = !flag;
					}
				}
				if (!Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(dg.Rows[num7].Cells[0].Value, -99, TextCompare: true), Operators.CompareObjectEqual(dg.Rows[num7].Cells[0].Value, 0, TextCompare: true))))
				{
					if (!flag)
					{
						dg.Rows[num7].Cells[1].Style = dataGridViewCellStyle3;
						dg.Rows[num7].Cells[2].Style = dataGridViewCellStyle3;
						dg.Rows[num7].Cells[3].Style = dataGridViewCellStyle3;
						dg.Rows[num7].Cells[4].Style = dataGridViewCellStyle3;
					}
					else
					{
						dg.Rows[num7].Cells[1].Style = dataGridViewCellStyle2;
						dg.Rows[num7].Cells[2].Style = dataGridViewCellStyle2;
						dg.Rows[num7].Cells[3].Style = dataGridViewCellStyle2;
						dg.Rows[num7].Cells[4].Style = dataGridViewCellStyle2;
					}
				}
				else
				{
					dg.Rows[num7].Cells[1].Style = dataGridViewCellStyle;
					dg.Rows[num7].Cells[2].Style = dataGridViewCellStyle;
					dg.Rows[num7].Cells[3].Style = dataGridViewCellStyle;
					dg.Rows[num7].Cells[4].Style = dataGridViewCellStyle;
				}
			}
		}
	}

	public static void CarregaOsCabosDoDG(ref frmImportarInterligExcel.structureImpCabos[] mCabosImp, ref CDadosAccessInterligacao cDadosAccessInterligacao)
	{
		int num = 0;
		StructureCabo[] array = new StructureCabo[1];
		NomeVeias nv = new NomeVeias
		{
			blVar = "BL",
			P1Var = "P1",
			P2Var = "P2",
			T1Var = "T1",
			T2Var = "T2",
			T3Var = "T3"
		};
		List<string> list = new List<string>();
		list.Clear();
		int num2 = Information.UBound(mCabosImp);
		checked
		{
			for (int i = 1; i <= num2; i++)
			{
				num = Information.UBound(array) + 1;
				array = (StructureCabo[])Utils.CopyArray(array, new StructureCabo[num + 1]);
				array[num].iPn1 = Dicionario.BuscaIndiceDoPainel(mCabosImp[i].sDe);
				array[num].iPn2 = Dicionario.BuscaIndiceDoPainel(mCabosImp[i].sPara);
				array[num].sTag = mCabosImp[i].sCabo;
				array[num].sFormacao = mCabosImp[i].sVeias + "x" + mCabosImp[i].sSecao;
				array[num].iCabos = 1;
				array[num].bBlindagem = mCabosImp[i].bBlindado;
				array[num].iAterrar = mCabosImp[i].iAterrar;
				array[num].sFuncao = mCabosImp[i].sFuncao;
				array[num].dComprimento = mCabosImp[i].dComprimento;
				array[num].sTrajeto = mCabosImp[i].sTajeto;
				array[num].sCodigo = "";
				array[num].sGrupo = "";
				array[num].sInstrucao = "";
				array[num].sSecao = "";
				array[num].sVeias = mCabosImp[i].sVeias;
			}
			if (Information.UBound(array) <= 0)
			{
				return;
			}
			int num3 = Information.UBound(array);
			for (int j = 1; j <= num3; j++)
			{
				StructureCabo cabo = array[j];
				cDadosAccessInterligacao.RemoveCaboErro(cabo.sTag);
				if (!LancaUmCabo(cabo, nv, ref cDadosAccessInterligacao))
				{
				}
			}
		}
	}

	public static void ExportaCabosParcialParaOExcel(ref Worksheet oSheet, ref DataGridView dg, string sTipo)
	{
		ExcFuncoesExcel.LimpaSheet(ref oSheet);
		int num = 1;
		checked
		{
			string cell;
			do
			{
				cell = ExcFuncoesExcel.mudaNumeroAsc(num) + "1";
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				num++;
			}
			while (num <= 15);
			cell = ExcFuncoesExcel.mudaNumeroAsc(1L) + "1";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 429].ToString().ToUpper());
			ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(1L), "1", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1261]), 43, 2, 150);
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 15;
			cell = ExcFuncoesExcel.mudaNumeroAsc(2L) + "1";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 432].ToString().ToUpper());
			ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(2L), "1", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1262]), 43, 2, 150);
			cell = ExcFuncoesExcel.mudaNumeroAsc(3L) + "1";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 389].ToString().ToUpper());
			ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(3L), "1", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1238]), 43, 1);
			cell = ExcFuncoesExcel.mudaNumeroAsc(4L) + "1";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 35;
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 1244].ToString().ToUpper());
			ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(4L), "1", Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1270], DeclaracoesGeral.mMensagem[1, 1271])), 37, 2, 100);
			cell = ExcFuncoesExcel.mudaNumeroAsc(5L) + "1";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 1246].ToString().ToUpper());
			ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(5L), "1", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1272], "\r\n"), DeclaracoesGeral.mMensagem[1, 1271])), 37, 2, 120);
			cell = ExcFuncoesExcel.mudaNumeroAsc(6L) + "1";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 40;
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 1248].ToString().ToUpper());
			ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(6L), "1", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1273], "\r\n"), DeclaracoesGeral.mMensagem[1, 1271])), 37, 2, 130);
			cell = ExcFuncoesExcel.mudaNumeroAsc(7L) + "1";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 20;
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 1797].ToString().ToUpper());
			ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(7L), "1", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1797], "\r\n"), DeclaracoesGeral.mMensagem[1, 1271])), 37, 2, 130);
			if (dg.RowCount <= 0)
			{
				return;
			}
			DeclaracoesGeral._uscPagina.Quantidade = dg.RowCount;
			DeclaracoesGeral._uscPagina.pbIniciar();
			DeclaracoesGeral._uscPagina.pbPasso();
			int num2 = dg.RowCount - 1;
			for (int i = 0; i <= num2; i++)
			{
				string text = "";
				int num3 = 1;
				do
				{
					text = Conversions.ToString(i + 2);
					cell = ExcFuncoesExcel.mudaNumeroAsc(num3) + text;
					((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", dg.Rows[i].Cells[num3 - 1].Value));
					num3++;
				}
				while (num3 <= 7);
				DeclaracoesGeral._uscPagina.pbPasso();
				string cell2 = "A" + Conversions.ToString(i + 2);
				((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
			}
			DeclaracoesGeral._uscPagina.pbFim();
		}
	}

	public static void ExportaCabosTrajetoParaOExcel(ref Worksheet oSheet, ref DataGridView dg, string sTipo)
	{
		ExcFuncoesExcel.LimpaSheet(ref oSheet);
		int num = 1;
		checked
		{
			string cell;
			do
			{
				cell = ExcFuncoesExcel.mudaNumeroAsc(num) + "1";
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				num++;
			}
			while (num <= 15);
			cell = ExcFuncoesExcel.mudaNumeroAsc(1L) + "1";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 429].ToString().ToUpper());
			ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(1L), "1", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1261]), 43, 2, 150);
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 15;
			cell = ExcFuncoesExcel.mudaNumeroAsc(2L) + "1";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 432].ToString().ToUpper());
			ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(2L), "1", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1262]), 43, 2, 150);
			cell = ExcFuncoesExcel.mudaNumeroAsc(3L) + "1";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 20;
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 1246].ToString().ToUpper());
			ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(3L), "1", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1272], "\r\n"), DeclaracoesGeral.mMensagem[1, 1271])), 43, 2, 120);
			if (dg.RowCount <= 0)
			{
				return;
			}
			DeclaracoesGeral._uscPagina.Quantidade = dg.RowCount;
			DeclaracoesGeral._uscPagina.pbIniciar();
			DeclaracoesGeral._uscPagina.pbPasso();
			int num2 = dg.RowCount - 1;
			for (int i = 0; i <= num2; i++)
			{
				string text = "";
				int num3 = 1;
				do
				{
					text = Conversions.ToString(i + 2);
					cell = ExcFuncoesExcel.mudaNumeroAsc(num3) + text;
					((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), Operators.ConcatenateObject("'", dg.Rows[i].Cells[num3 - 1].Value));
					num3++;
				}
				while (num3 <= 3);
				DeclaracoesGeral._uscPagina.pbPasso();
				string cell2 = "A" + Conversions.ToString(i + 2);
				((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
			}
			DeclaracoesGeral._uscPagina.pbFim();
		}
	}

	public static void CarregaOsCabosDoExcelParaEdicaoParcial(ref Worksheet oSheet, ref StructureCabo[] mCabos, List<string> lmListaCabos, NomeVeias nv, ref CaboDWG[] mCabosDWG, ref CaboDWG[] mCabosEditar, StructureCabo[] mmCadernoCabos, ref CDadosAccessInterligacao cDadosAccessInterligacao)
	{
		int i = 2;
		int num = 1;
		string cell = "C2";
		checked
		{
			while (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
			{
				num++;
				cell = "C" + Conversions.ToString(num);
			}
			List<string> list = new List<string>();
			list.Clear();
			DeclaracoesGeral._uscPagina.Quantidade = num;
			DeclaracoesGeral._uscPagina.pbIniciar();
			for (; Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)("C" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true); i++)
			{
				ExcFuncoesExcel.LimpaErro(ref oSheet, Conversions.ToString(i));
			}
			i = 2;
			List<string> lTodosCabos = new List<string>();
			cDadosAccessInterligacao.LeTodosOsCabos(ref mCabos, ref lTodosCabos);
			if (Information.UBound(mCabos) > 0)
			{
				while (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)("C" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
				{
					clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)("A" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
					clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)("B" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
					string text = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)("C" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
					string text2 = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)("D" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
					double num2 = 0.0;
					if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(((_Worksheet)oSheet).get_Range((object)("E" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))))
					{
						num2 = Conversions.ToDouble(((_Worksheet)oSheet).get_Range((object)("E" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
					}
					string text3 = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)("F" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
					string text4 = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)("G" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
					bool flag = false;
					int num3 = Information.UBound(mCabos);
					for (int j = 1; j <= num3; j++)
					{
						if (Operators.CompareString(mCabos[j].sTag, text, TextCompare: true) == 0)
						{
							bool flag2 = false;
							if (Operators.CompareString(mCabos[j].sFuncao.Trim(), text2.Trim(), TextCompare: true) != 0)
							{
								mCabos[j].sFuncao = text2.Trim();
								flag2 = true;
								ExcFuncoesExcel.PintaCelula(ref oSheet, "D", Conversions.ToString(i), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1620]), 46, 1, 100);
							}
							if (mCabos[j].dComprimento != num2)
							{
								mCabos[j].dComprimento = num2;
								flag2 = true;
								ExcFuncoesExcel.PintaCelula(ref oSheet, "E", Conversions.ToString(i), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1620]), 46, 1, 100);
							}
							if (Operators.CompareString(mCabos[j].sTrajeto.Trim(), text3.Trim(), TextCompare: true) != 0)
							{
								mCabos[j].sTrajeto = text3.Trim();
								flag2 = true;
								ExcFuncoesExcel.PintaCelula(ref oSheet, "F", Conversions.ToString(i), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1620]), 46, 1, 100);
							}
							if (Operators.CompareString(mCabos[j].sInstrucao.Trim(), text4.Trim(), TextCompare: true) != 0)
							{
								mCabos[j].sInstrucao = text4.Trim();
								flag2 = true;
								ExcFuncoesExcel.PintaCelula(ref oSheet, "G", Conversions.ToString(i), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1620]), 46, 1, 100);
							}
							if (flag2)
							{
								cDadosAccessInterligacao.EditaFuncaoComprimentoTrajeto(text, text2, num2, text3, text4);
							}
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						ExcFuncoesExcel.PintaCelula(ref oSheet, "C", Conversions.ToString(i), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1621]), 3, 1, 100);
					}
					i++;
					DeclaracoesGeral._uscPagina.pbPasso();
				}
			}
			DeclaracoesGeral._uscPagina.pbFim();
		}
	}

	public static void CarregaOsCabosDoExcelParaEdicaoParcial2(ref Worksheet oSheet, ref CDadosAccessInterligacao CDadosAccessInterligacao)
	{
		string text = "";
		int i = 2;
		int num = 1;
		text = "A2";
		checked
		{
			while (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
			{
				num++;
				text = "A" + Conversions.ToString(num);
			}
			DeclaracoesGeral._uscPagina.Quantidade = num;
			DeclaracoesGeral._uscPagina.pbIniciar();
			for (; Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)("A" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true); i++)
			{
				ExcFuncoesExcel.LimpaErro(ref oSheet, Conversions.ToString(i));
			}
			i = 2;
			while (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)("A" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
			{
				int num2 = Dicionario.BuscaIndiceDoPainel(clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)("A" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))));
				int num3 = Dicionario.BuscaIndiceDoPainel(clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)("B" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))));
				double dComprimento = 0.0;
				if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(((_Worksheet)oSheet).get_Range((object)("C" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))))
				{
					dComprimento = Conversions.ToDouble(((_Worksheet)oSheet).get_Range((object)("C" + Conversions.ToString(i)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)));
				}
				CDadosAccessInterligacao.EditaComprimento(dComprimento, num2, num3);
				CDadosAccessInterligacao.EditaComprimento(dComprimento, num3, num2);
				i++;
				DeclaracoesGeral._uscPagina.pbPasso();
			}
			DeclaracoesGeral._uscPagina.pbFim();
		}
	}

	public static void CriaEstiloDeLinha(ref string estilo, double escala)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				LinetypeTable val3 = (LinetypeTable)val2.GetObject(database.LinetypeTableId, (OpenMode)0);
				if (!((SymbolTable)val3).Has(estilo))
				{
					try
					{
						database.LoadLineTypeFile(estilo, "acadiso.lin");
						database.Ltscale = escala;
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						estilo = "Continuous";
						ProjectData.ClearProjectError();
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}
}

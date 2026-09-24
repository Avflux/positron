using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.Runtime;

namespace Eletron4;

public class clsBornesInterligAuto
{
	public struct StructureBorneInseidos
	{
		public string o_sPainel;

		public string o_sRegua;

		public string o_sBorne;

		public int o_iPainel;

		public int o_iRegua;

		public string d_sPainel;

		public string d_sRegua;

		public string d_sBorne;

		public int d_iPainel;

		public int d_iRegua;
	}

	public struct mAtt
	{
		public string Att;

		public string Valor;
	}

	public static void ExportaModeloBornesInterligacao(ref Worksheet oSheet)
	{
		string text = "";
		text = "A1:Z10000";
		((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).EntireRow.Delete(RuntimeHelpers.GetObjectValue(Missing.Value));
		((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 15;
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
		cell = "A1:F1";
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 1553].ToString().ToUpper());
		cell = ExcFuncoesExcel.mudaNumeroAsc(1L) + "2";
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 429].ToString().ToUpper());
		cell = ExcFuncoesExcel.mudaNumeroAsc(2L) + "2";
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 924].ToString().ToUpper());
		cell = ExcFuncoesExcel.mudaNumeroAsc(3L) + "2";
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 789].ToString().ToUpper());
		cell = ExcFuncoesExcel.mudaNumeroAsc(4L) + "2";
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 432].ToString().ToUpper());
		cell = ExcFuncoesExcel.mudaNumeroAsc(5L) + "2";
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 924].ToString().ToUpper());
		cell = ExcFuncoesExcel.mudaNumeroAsc(6L) + "2";
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
		((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 789].ToString().ToUpper());
		cell = "A1:F2";
		ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, cell);
		ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, cell, bCompleto: true);
	}

	public static void capturaBornesDoDesenho(ref List<string> lBornes)
	{
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Expected Obj, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected Obj, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected Obj, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected Obj, but got Unknown
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				Declaracoes2.StructureModeloDeReguas[] mModelo = new Declaracoes2.StructureModeloDeReguas[1];
				DicionarioReguas.LeOsModelosDeRegua(ref mModelo);
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				DeclaracoesEntidades.StructureBorne structureBorne = default;
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val4.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity ent = (Entity)val2.GetObject(current, (OpenMode)0);
						string tipoImportado = "";
						string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
						if (Operators.CompareString(left, "B", TextCompare: true) != 0)
						{
							continue;
						}
						BlockReference blockRef = (BlockReference)ent;
						object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
						ent = (Entity)(object)blockRef;
						DeclaracoesEntidades.StructureBorne structureBorne2 = ((obj == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj));
						int num = Information.UBound(mModelo);
						for (int i = 1; i <= num; i = checked(i + 1))
						{
							if (mModelo[i].indexRegua == structureBorne2.IndiceRegua)
							{
								string text = Dicionario.BuscaNomeDoPainel(mModelo[i].indexPainel) + "-" + mModelo[i].nomeRegua + "-" + structureBorne2.Numero.ToString();
								lBornes.Add(text.ToUpper());
							}
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				val2.Abort();
				ProjectData.ClearProjectError();
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

	public static bool VerificaBornes(ref Worksheet oSheet, ref List<string> lBornes, ref StructureBorneInseidos[] mBornesAdd)
	{
		bool result = false;
		List<string> list = new List<string>();
		string text = "";
		int num = 3;
		int num2 = 3;
		text = "D3";
		checked
		{
			while (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
			{
				num2++;
				text = "D" + Conversions.ToString(num2);
			}
			bool flag = true;
			string cell = "A1:F1000";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 0;
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ClearComments();
			int num3 = 0;
			mBornesAdd = new StructureBorneInseidos[1];
			bool flag2 = false;
			while (!flag2)
			{
				string text2 = "";
				string text3 = "";
				string text4 = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)(ExcFuncoesExcel.mudaNumeroAsc(1L) + Conversions.ToString(num)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))).ToString().ToUpper();
				string text5 = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)(ExcFuncoesExcel.mudaNumeroAsc(2L) + Conversions.ToString(num)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))).ToString().ToUpper();
				string text6 = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)(ExcFuncoesExcel.mudaNumeroAsc(3L) + Conversions.ToString(num)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
				string text7 = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)(ExcFuncoesExcel.mudaNumeroAsc(4L) + Conversions.ToString(num)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))).ToString().ToUpper();
				string text8 = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)(ExcFuncoesExcel.mudaNumeroAsc(5L) + Conversions.ToString(num)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)))).ToString().ToUpper();
				string text9 = clsTextos.TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)(ExcFuncoesExcel.mudaNumeroAsc(6L) + Conversions.ToString(num)), RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
				text2 = text4 + "-" + text5 + "-" + text6;
				text3 = text7 + "-" + text8 + "-" + text9;
				if (!((Operators.CompareString(text2, "--", TextCompare: true) == 0) & (Operators.CompareString(text3, "--", TextCompare: true) == 0)))
				{
					bool flag3 = false;
					bool flag4 = false;
					if (Operators.CompareString(text6, "", TextCompare: true) == 0)
					{
						if (!((Operators.CompareString(text4, "", TextCompare: true) == 0) & (Operators.CompareString(text5, "", TextCompare: true) == 0)) && ((Operators.CompareString(text4, "", TextCompare: true) == 0) | (Operators.CompareString(text5, "", TextCompare: true) == 0)))
						{
							flag3 = true;
						}
					}
					else if ((Operators.CompareString(text4, "", TextCompare: true) == 0) | (Operators.CompareString(text5, "", TextCompare: true) == 0))
					{
						flag3 = true;
					}
					if (flag3)
					{
						ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(1L), Conversions.ToString(num), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1554]), 46);
						ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(2L), Conversions.ToString(num), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1554]), 46);
						ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(3L), Conversions.ToString(num), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1554]), 46);
						if (flag)
						{
							((_Worksheet)oSheet).get_Range((object)("A" + Conversions.ToString(num + 5)), RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
							flag = false;
						}
						result = true;
					}
					if (Operators.CompareString(text9, "", TextCompare: true) == 0)
					{
						if (!((Operators.CompareString(text7, "", TextCompare: true) == 0) & (Operators.CompareString(text8, "", TextCompare: true) == 0)) && ((Operators.CompareString(text7, "", TextCompare: true) == 0) | (Operators.CompareString(text8, "", TextCompare: true) == 0)))
						{
							flag4 = true;
						}
					}
					else if ((Operators.CompareString(text7, "", TextCompare: true) == 0) | (Operators.CompareString(text8, "", TextCompare: true) == 0))
					{
						flag4 = true;
					}
					if (flag4)
					{
						ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(4L), Conversions.ToString(num), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1554]), 46);
						ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(5L), Conversions.ToString(num), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1554]), 46);
						ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(6L), Conversions.ToString(num), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1554]), 46);
						if (flag)
						{
							((_Worksheet)oSheet).get_Range((object)("A" + Conversions.ToString(num + 5)), RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
							flag = false;
						}
						result = true;
					}
					if (((Operators.CompareString(text6, "", TextCompare: true) == 0) | (Operators.CompareString(text6, "0", TextCompare: true) == 0)) && ((Operators.CompareString(text4, "", TextCompare: true) != 0) & (Operators.CompareString(text5, "", TextCompare: true) != 0)))
					{
						text6 = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
					}
					if (((Operators.CompareString(text9, "", TextCompare: true) == 0) | (Operators.CompareString(text9, "0", TextCompare: true) == 0)) && ((Operators.CompareString(text7, "", TextCompare: true) != 0) & (Operators.CompareString(text8, "", TextCompare: true) != 0)))
					{
						text9 = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
					}
					if (lBornes.Contains(text2))
					{
						ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(1L), Conversions.ToString(num), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1555]), 46);
						ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(2L), Conversions.ToString(num), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1555]), 46);
						ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(3L), Conversions.ToString(num), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1555]), 46);
						if (flag)
						{
							((_Worksheet)oSheet).get_Range((object)("A" + Conversions.ToString(num + 5)), RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
							flag = false;
						}
						result = true;
					}
					if (!list.Contains(text2))
					{
						list.Add(text2);
					}
					else if (Operators.CompareString(text2, "--", TextCompare: true) != 0)
					{
						if (Operators.CompareString(text6, DeclaracoesGeral.Conf.CaracterTerminalIndefinido, TextCompare: true) != 0)
						{
							ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(1L), Conversions.ToString(num), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1556]), 46);
							ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(2L), Conversions.ToString(num), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1556]), 46);
							ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(3L), Conversions.ToString(num), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1556]), 46);
							if (flag)
							{
								((_Worksheet)oSheet).get_Range((object)("A" + Conversions.ToString(num + 5)), RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
								flag = false;
							}
							result = true;
						}
						else
						{
							list.Add(text2);
						}
					}
					if (lBornes.Contains(text3))
					{
						ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(4L), Conversions.ToString(num), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1555]), 46);
						ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(5L), Conversions.ToString(num), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1555]), 46);
						ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(6L), Conversions.ToString(num), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1555]), 46);
						if (flag)
						{
							((_Worksheet)oSheet).get_Range((object)("A" + Conversions.ToString(num + 5)), RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
							flag = false;
						}
						result = true;
					}
					if (!list.Contains(text3))
					{
						list.Add(text3);
					}
					else if (Operators.CompareString(text3, "--", TextCompare: true) != 0)
					{
						if (Operators.CompareString(text9, DeclaracoesGeral.Conf.CaracterTerminalIndefinido, TextCompare: true) != 0)
						{
							ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(4L), Conversions.ToString(num), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1556]), 46);
							ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(5L), Conversions.ToString(num), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1556]), 46);
							ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(6L), Conversions.ToString(num), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1556]), 46);
							if (flag)
							{
								((_Worksheet)oSheet).get_Range((object)("A" + Conversions.ToString(num + 5)), RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
								flag = false;
							}
							result = true;
						}
						else
						{
							list.Add(text3);
						}
					}
					if (Operators.CompareString(text4, text7, TextCompare: true) == 0 && !((Operators.CompareString(text2, "--", TextCompare: true) == 0) & (Operators.CompareString(text3, "--", TextCompare: true) == 0)))
					{
						ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(1L), Conversions.ToString(num), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 733]), 46);
						ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(4L), Conversions.ToString(num), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 733]), 46);
						if (flag)
						{
							((_Worksheet)oSheet).get_Range((object)("A" + Conversions.ToString(num + 5)), RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
							flag = false;
						}
						result = true;
					}
					if (!((Operators.CompareString(text2, "--", TextCompare: true) == 0) & (Operators.CompareString(text3, "--", TextCompare: true) == 0)))
					{
						num++;
						num3++;
						mBornesAdd = (StructureBorneInseidos[])Utils.CopyArray(mBornesAdd, new StructureBorneInseidos[num3 + 1]);
						mBornesAdd[num3].o_sPainel = text4.Trim();
						mBornesAdd[num3].o_sRegua = text5.Trim();
						mBornesAdd[num3].o_sBorne = text6.Trim();
						mBornesAdd[num3].d_sPainel = text7.Trim();
						mBornesAdd[num3].d_sRegua = text8.Trim();
						mBornesAdd[num3].d_sBorne = text9.Trim();
					}
					else
					{
						flag2 = true;
					}
				}
				else
				{
					flag2 = true;
				}
			}
			return result;
		}
	}

	public static void CadastraPaineis(ref StructureBorneInseidos[] mBornes)
	{
		string userName = Environment.UserName;
		string sEditor = "";
		DateTime sData = Conversions.ToDate(DateTime.Now.ToString());
		int num = 1;
		int num2 = 1;
		cDadosAccessPaineis cDadosAccessPaineis2 = new cDadosAccessPaineis();
		num = cDadosAccessPaineis2.ProximoIndicePainel();
		List<string> list = new List<string>();
		int num3 = Information.UBound(mBornes);
		checked
		{
			for (int i = 1; i <= num3; i++)
			{
				if (!list.Contains(mBornes[i].o_sPainel) && Dicionario.BuscaIndiceDoPainel(mBornes[i].o_sPainel) == 0 && Operators.CompareString(mBornes[i].o_sPainel.Trim(), "", TextCompare: true) != 0)
				{
					list.Add(mBornes[i].o_sPainel);
				}
				if (!list.Contains(mBornes[i].d_sPainel) && Dicionario.BuscaIndiceDoPainel(mBornes[i].d_sPainel) == 0 && Operators.CompareString(mBornes[i].d_sPainel.Trim(), "", TextCompare: true) != 0)
				{
					list.Add(mBornes[i].d_sPainel);
				}
			}
			foreach (string item in list)
			{
				cDadosAccessPaineis2.AdicionaPainel("Paineis", num, item, userName, sEditor, sData);
				num++;
			}
			cDadosAccessPaineis2.fechaConexao();
			cDadosAccess.carregaPainelDicionario();
			int num4 = Information.UBound(mBornes);
			for (int j = 1; j <= num4; j++)
			{
				mBornes[j].o_iPainel = Dicionario.BuscaIndiceDoPainel(mBornes[j].o_sPainel);
				mBornes[j].d_iPainel = Dicionario.BuscaIndiceDoPainel(mBornes[j].d_sPainel);
			}
		}
	}

	public static void CadastraReguas(ref StructureBorneInseidos[] mBornes)
	{
		//IL_032d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0333: Expected Obj, but got Unknown
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected Obj, but got Unknown
		//IL_034c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0352: Expected Obj, but got Unknown
		checked
		{
			try
			{
				Declaracoes2.StructureModeloDeReguas[] mModelo = new Declaracoes2.StructureModeloDeReguas[1];
				DicionarioReguas.LeOsModelosDeRegua(ref mModelo);
				bool flag = true;
				try
				{
					int num = Information.UBound(mBornes);
					for (int i = 1; i <= num; i++)
					{
						flag = true;
						int num2 = Information.UBound(mModelo);
						for (int j = 1; j <= num2; j++)
						{
							if (Operators.CompareString(mBornes[i].o_sRegua.Trim(), "", TextCompare: true) == 0)
							{
								flag = false;
								break;
							}
							if (mBornes[i].o_iPainel == mModelo[j].indexPainel && Operators.CompareString(mBornes[i].o_sRegua, mModelo[j].nomeRegua, TextCompare: true) == 0)
							{
								mBornes[i].o_iRegua = mModelo[j].indexRegua;
								flag = false;
								break;
							}
						}
						if (flag)
						{
							mBornes[i].o_iRegua = mModelo[0].iMaxIndice + 1;
							int num3 = Information.UBound(mModelo) + 1;
							mModelo = (Declaracoes2.StructureModeloDeReguas[])Utils.CopyArray(mModelo, new Declaracoes2.StructureModeloDeReguas[num3 + 1]);
							mModelo[num3].indexRegua = mBornes[i].o_iRegua;
							mModelo[num3].nomeRegua = mBornes[i].o_sRegua;
							mModelo[num3].nomeAlternativo = "";
							mModelo[num3].indexPainel = mBornes[i].o_iPainel;
							DicionarioReguas.GravaOsModelosDeRegua(mModelo);
							mModelo = new Declaracoes2.StructureModeloDeReguas[1];
							DicionarioReguas.LeOsModelosDeRegua(ref mModelo);
						}
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError((Exception)ex);
					ProjectData.ClearProjectError();
				}
				mModelo = new Declaracoes2.StructureModeloDeReguas[1];
				DicionarioReguas.LeOsModelosDeRegua(ref mModelo);
				try
				{
					int num4 = Information.UBound(mBornes);
					for (int k = 1; k <= num4; k++)
					{
						flag = true;
						int num5 = Information.UBound(mModelo);
						for (int l = 1; l <= num5; l++)
						{
							if (Operators.CompareString(mBornes[k].d_sRegua.Trim(), "", TextCompare: true) == 0)
							{
								flag = false;
								break;
							}
							if (mBornes[k].d_iPainel == mModelo[l].indexPainel && Operators.CompareString(mBornes[k].d_sRegua, mModelo[l].nomeRegua, TextCompare: true) == 0)
							{
								mBornes[k].d_iRegua = mModelo[l].indexRegua;
								flag = false;
								break;
							}
						}
						if (flag)
						{
							mBornes[k].d_iRegua = mModelo[0].iMaxIndice + 1;
							int num6 = Information.UBound(mModelo) + 1;
							mModelo = (Declaracoes2.StructureModeloDeReguas[])Utils.CopyArray(mModelo, new Declaracoes2.StructureModeloDeReguas[num6 + 1]);
							mModelo[num6].indexRegua = mBornes[k].d_iRegua;
							mModelo[num6].nomeRegua = mBornes[k].d_sRegua;
							mModelo[num6].nomeAlternativo = "";
							mModelo[num6].indexPainel = mBornes[k].d_iPainel;
							DicionarioReguas.GravaOsModelosDeRegua(mModelo);
							mModelo = new Declaracoes2.StructureModeloDeReguas[1];
							DicionarioReguas.LeOsModelosDeRegua(ref mModelo);
						}
					}
				}
				catch (Exception ex2)
				{
					ProjectData.SetProjectError((Exception)ex2);
					ProjectData.ClearProjectError();
				}
				mModelo = new Declaracoes2.StructureModeloDeReguas[1];
				DicionarioReguas.LeOsModelosDeRegua(ref mModelo);
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError((Exception)ex3);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void insereVeia(Point3d PrimeiroPoint, Point3d SegundoPoint, DeclaracoesEntidades.StructureInterligacao ilig)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected Obj, but got Unknown
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected Obj, but got Unknown
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Expected Obj, but got Unknown
		//IL_0195: Expected Obj, but got Unknown
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected Obj, but got Unknown
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected Obj, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected Obj, but got Unknown
		Point2d val = PrimeiroPoint.Convert2d((PlanarEntity)new Plane());
		Point2d val2 = SegundoPoint.Convert2d((PlanarEntity)new Plane());
		Polyline pl = new Polyline();
		((Entity)pl).SetDatabaseDefaults();
		((Entity)pl).ColorIndex = DeclaracoesGeral.Conf.CorInterligacao;
		pl.AddVertexAt(0, val, 0.0, 0.0, 0.0);
		pl.AddVertexAt(1, val2, 0.0, 0.0, 0.0);
		DocumentLock val3 = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			_ = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val4 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val5 = (BlockTable)val4.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val6 = (BlockTableRecord)val4.GetObject(((SymbolTable)val5)[BlockTableRecord.ModelSpace], (OpenMode)1);
				val6.AppendEntity((Entity)(object)pl);
				DeclaracoesGeral.bAnularEventos = true;
				val4.AddNewlyCreatedDBObject((DBObject)(object)pl, true);
				XDataInterligacao.GravarXDataInterligacao(ref pl, ref ilig, 0);
				DBText val7 = clsInterligacao.criarTextoNomeCabo(pl, DeclaracoesGeral.Conf.CaracterTerminalIndefinido, DeclaracoesGeral.ativo.Pagina);
				val6.AppendEntity((Entity)(object)val7);
				DeclaracoesGeral.bAnularEventos = true;
				val4.AddNewlyCreatedDBObject((DBObject)(object)val7, true);
				Entity ent = (Entity)(object)val7;
				XDataInterligacao.GravarXDataAuxInterligacao(ref ent, ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString(), 1, "");
				val7 = (DBText)ent;
				DeclaracoesGeral.bAnularEventos = true;
				val4.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				Exception ex2 = ex;
				val4.Abort();
				Interaction.MsgBox(((Exception)(object)ex2).Message, MsgBoxStyle.Information);
				ProjectData.ClearProjectError();
			}
			finally
			{
				((IDisposable)val4)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val3)?.Dispose();
		}
		PointMonitorToolTips.StartMonitor();
	}

	public static void moveoBloco(ref string sHandle, double x, double y)
	{
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected Obj, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				Entity val4 = (Entity)Geral.HandleToObject(sHandle);
				if (val4 != null)
				{
					BlockReference val5 = (BlockReference)(object)((val4 is BlockReference) ? val4 : null);
					if (val5 != null)
					{
						Point3d val6 = new Point3d(0.0, 0.0, 0.0);
						Vector3d vectorTo = val6.GetVectorTo(new Point3d(x, y, 0.0));
						((DBObject)val5).UpgradeOpen();
						((Entity)val5).TransformBy(Matrix3d.Displacement(vectorTo));
						((DBObject)val5).DowngradeOpen();
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				ProjectData.ClearProjectError();
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

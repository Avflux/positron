using System;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;

namespace Eletron4;

public class XDataDIEnergisaSSE
{
	public string Tag_Cabo;

	public string Formacao;

	public bool Blindagem;

	public bool bAterrar;

	public string sPainelDest;

	public string Pagina;

	public int Coluna;

	public double Y;

	public string Lado;

	public static void GravarXDataBorne(ref BlockReference blockRef, DeclaracoesInterligacao.borneAranha bn)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			RegAppTable val = (RegAppTable)topTransaction.GetObject(database.RegAppTableId, (OpenMode)1);
			if (!((SymbolTable)val).Has("ARANHA"))
			{
				RegAppTableRecord val2 = new RegAppTableRecord();
				((SymbolTableRecord)val2).Name = "ARANHA";
				((SymbolTable)val).Add((SymbolTableRecord)(object)val2);
				DeclaracoesGeral.bAnularEventos = true;
				topTransaction.AddNewlyCreatedDBObject((DBObject)(object)val2, true);
			}
			TypedValue[] array = new TypedValue[13]
			{
				new TypedValue(1001, (object)"ARANHA"),
				new TypedValue(1000, (object)"BORNE"),
				new TypedValue(1000, (object)bn.Revisao),
				new TypedValue(1070, (object)bn.Painel),
				new TypedValue(1000, (object)bn.Tag),
				new TypedValue(1000, (object)bn.NRegua),
				new TypedValue(1070, (object)bn.TipoBorne),
				new TypedValue(1000, (object)bn.Borne),
				new TypedValue(1070, (object)bn.Ordem),
				new TypedValue(1070, (object)bn.Posicao),
				new TypedValue(1000, (object)""),
				new TypedValue(1000, (object)""),
				new TypedValue(1070, (object)0)
			};
			((DBObject)blockRef).XData = new ResultBuffer(array);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		finally
		{
			((IDisposable)topTransaction)?.Dispose();
		}
	}

	public static bool LerXDataBorne(ref BlockReference blockRef, ref DeclaracoesInterligacao.borneAranha bn)
	{
		bool result = false;
		ResultBuffer xDataForApplication = ((DBObject)blockRef).GetXDataForApplication("ARANHA");
		if (xDataForApplication != null)
		{
			TypedValue[] array = xDataForApplication.AsArray();
			if (Operators.ConditionalCompareObjectEqual(array[1].Value, "BORNE", TextCompare: true))
			{
				bn.Revisao = Conversions.ToString(array[2].Value);
				bn.Painel = Conversions.ToInteger(array[3].Value);
				bn.Tag = Conversions.ToString(array[4].Value);
				bn.NRegua = Conversions.ToString(array[5].Value);
				bn.TipoBorne = Conversions.ToInteger(array[6].Value);
				bn.Borne = Conversions.ToString(array[7].Value);
				bn.Ordem = Conversions.ToDouble(array[8].Value);
				bn.Posicao = Conversions.ToInteger(array[9].Value);
				result = true;
			}
		}
		return result;
	}

	public static void GravarXDataJumper(ref Entity ent, string revisao, int painel, DeclaracoesInterligacao.borneAranha bnO, DeclaracoesInterligacao.borneAranha bnD)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			RegAppTable val = (RegAppTable)topTransaction.GetObject(database.RegAppTableId, (OpenMode)1);
			if (!((SymbolTable)val).Has("ARANHA"))
			{
				RegAppTableRecord val2 = new RegAppTableRecord();
				((SymbolTableRecord)val2).Name = "ARANHA";
				((SymbolTable)val).Add((SymbolTableRecord)(object)val2);
				DeclaracoesGeral.bAnularEventos = true;
				topTransaction.AddNewlyCreatedDBObject((DBObject)(object)val2, true);
			}
			TypedValue[] array = new TypedValue[10]
			{
				new TypedValue(1001, (object)"ARANHA"),
				new TypedValue(1000, (object)"JUMPER"),
				new TypedValue(1000, (object)revisao),
				new TypedValue(1070, (object)painel),
				new TypedValue(1000, (object)bnO.Tag),
				new TypedValue(1000, (object)bnO.NRegua),
				new TypedValue(1000, (object)bnO.Borne),
				new TypedValue(1000, (object)bnD.Tag),
				new TypedValue(1000, (object)bnD.NRegua),
				new TypedValue(1000, (object)bnD.Borne)
			};
			((DBObject)ent).XData = new ResultBuffer(array);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		finally
		{
			((IDisposable)topTransaction)?.Dispose();
		}
	}

	public static bool LerXDataJumper(ref Entity ent, ref string revisao, ref int painel, ref DeclaracoesInterligacao.borneAranha bnO, ref DeclaracoesInterligacao.borneAranha bnD)
	{
		bool result = false;
		ResultBuffer xDataForApplication = ((DBObject)ent).GetXDataForApplication("ARANHA");
		if (xDataForApplication != null)
		{
			TypedValue[] array = xDataForApplication.AsArray();
			if (Operators.ConditionalCompareObjectEqual(array[1].Value, "JUMPER", TextCompare: true))
			{
				revisao = Conversions.ToString(array[2].Value);
				painel = Conversions.ToInteger(array[3].Value);
				bnO.Tag = Conversions.ToString(array[4].Value);
				bnO.NRegua = Conversions.ToString(array[5].Value);
				bnO.Borne = Conversions.ToString(array[6].Value);
				bnD.Tag = Conversions.ToString(array[7].Value);
				bnD.NRegua = Conversions.ToString(array[8].Value);
				bnD.Borne = Conversions.ToString(array[9].Value);
				result = true;
			}
		}
		return result;
	}

	public static void GravarXDataCabo(ref Entity ent, string revisao, int painel, string regua)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			RegAppTable val = (RegAppTable)topTransaction.GetObject(database.RegAppTableId, (OpenMode)1);
			if (!((SymbolTable)val).Has("ARANHA"))
			{
				RegAppTableRecord val2 = new RegAppTableRecord();
				((SymbolTableRecord)val2).Name = "ARANHA";
				((SymbolTable)val).Add((SymbolTableRecord)(object)val2);
				DeclaracoesGeral.bAnularEventos = true;
				topTransaction.AddNewlyCreatedDBObject((DBObject)(object)val2, true);
			}
			TypedValue[] array = new TypedValue[8]
			{
				new TypedValue(1001, (object)"ARANHA"),
				new TypedValue(1000, (object)"CABO"),
				new TypedValue(1000, (object)revisao),
				new TypedValue(1070, (object)painel),
				new TypedValue(1000, (object)regua),
				new TypedValue(1070, (object)0),
				new TypedValue(1070, (object)0),
				new TypedValue(1000, (object)"E")
			};
			((DBObject)ent).XData = new ResultBuffer(array);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		finally
		{
			((IDisposable)topTransaction)?.Dispose();
		}
	}

	public static bool LerXDataCabo(ref Entity ent, ref string revisao, ref int painel)
	{
		bool result = false;
		ResultBuffer xDataForApplication = ((DBObject)ent).GetXDataForApplication("ARANHA");
		if (xDataForApplication != null)
		{
			TypedValue[] array = xDataForApplication.AsArray();
			if (Operators.ConditionalCompareObjectEqual(array[1].Value, "CABO", TextCompare: true))
			{
				revisao = Conversions.ToString(array[2].Value);
				painel = Conversions.ToInteger(array[3].Value);
				result = true;
			}
		}
		return result;
	}
}

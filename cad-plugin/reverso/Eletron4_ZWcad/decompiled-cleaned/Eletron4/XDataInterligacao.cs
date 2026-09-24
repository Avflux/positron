using System;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;

namespace Eletron4;

public class XDataInterligacao
{
	public static void GravarXDataInterligacao(ref Polyline pl, ref DeclaracoesEntidades.StructureInterligacao ilig, short parte)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Expected Obj, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Expected Obj, but got Unknown
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			RegAppTable val2 = (RegAppTable)val.GetObject(database.RegAppTableId, (OpenMode)1);
			if (!((SymbolTable)val2).Has("INTERLIGACAO"))
			{
				RegAppTableRecord val3 = new RegAppTableRecord();
				((SymbolTableRecord)val3).Name = "INTERLIGACAO";
				((SymbolTable)val2).Add((SymbolTableRecord)(object)val3);
				DeclaracoesGeral.bAnularEventos = true;
				val.AddNewlyCreatedDBObject((DBObject)(object)val3, true);
			}
			TypedValue[] array = new TypedValue[19]
			{
				new TypedValue(1001, (object)"INTERLIGACAO"),
				new TypedValue(1070, (object)ilig.Tipo),
				new TypedValue(1000, (object)ilig.Tag_Cabo),
				new TypedValue(1070, (object)ilig.NumVeia),
				new TypedValue(1000, (object)ilig.NomeVeia),
				new TypedValue(1070, (object)ilig.Painel1),
				new TypedValue(1070, (object)0),
				new TypedValue(1070, (object)ilig.Painel2),
				new TypedValue(1070, (object)0),
				default,
				default,
				default,
				default,
				default,
				default,
				default,
				default,
				default,
				default
			};
			switch (parte)
			{
			case 2:
				array[9] = new TypedValue(1000, (object)ilig.Handle1);
				break;
			case 0:
				array[9] = new TypedValue(1000, (object)"");
				break;
			case 1:
				array[9] = new TypedValue(1000, (object)ilig.Handle2);
				break;
			}
			array[10] = new TypedValue(1000, (object)"");
			array[11] = new TypedValue(1000, (object)"");
			array[12] = new TypedValue(1070, (object)ilig.ocultaTag);
			array[13] = new TypedValue(1070, (object)ilig.iModeloVeiaFuncao);
			array[14] = new TypedValue(1000, (object)ilig.Usuario);
			array[15] = new TypedValue(1000, (object)ilig.Data);
			array[16] = new TypedValue(1071, (object)1);
			array[17] = new TypedValue(1040, (object)0);
			array[18] = new TypedValue(1000, (object)"");
			((DBObject)pl).XData = new ResultBuffer(array);
			DeclaracoesGeral.bAnularEventos = true;
			val.Commit();
			DeclaracoesGeral.bAnularEventos = false;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static bool lerXDataInterligacao(ref Polyline pl, ref DeclaracoesEntidades.StructureInterligacao ilig)
	{
		bool result = false;
		ResultBuffer xDataForApplication = ((DBObject)pl).GetXDataForApplication("INTERLIGACAO");
		if (xDataForApplication != null)
		{
			TypedValue[] array = xDataForApplication.AsArray();
			ilig.Tipo = Conversions.ToShort(array[1].Value);
			ilig.Tag_Cabo = Conversions.ToString(array[2].Value);
			ilig.NumVeia = Conversions.ToInteger(array[3].Value);
			ilig.NomeVeia = Conversions.ToString(array[4].Value);
			ilig.Painel1 = Conversions.ToShort(array[5].Value);
			ilig.Painel2 = Conversions.ToShort(array[7].Value);
			ilig.handle = Conversions.ToString(array[9].Value);
			ilig.ocultaTag = Conversions.ToInteger(array[12].Value);
			ilig.iModeloVeiaFuncao = Conversions.ToInteger(array[13].Value);
			ilig.Usuario = Conversions.ToString(array[14].Value);
			ilig.Data = Conversions.ToString(array[15].Value);
			result = true;
		}
		return result;
	}

	public static void GravarXDataAuxInterligacao(ref Entity ent, string handle, short tipo, string THandle, string sOpcionais = "")
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			RegAppTable val = (RegAppTable)topTransaction.GetObject(database.RegAppTableId, (OpenMode)1);
			if (!((SymbolTable)val).Has("AUXINTERLIG"))
			{
				RegAppTableRecord val2 = new RegAppTableRecord();
				((SymbolTableRecord)val2).Name = "AUXINTERLIG";
				((SymbolTable)val).Add((SymbolTableRecord)(object)val2);
				DeclaracoesGeral.bAnularEventos = true;
				topTransaction.AddNewlyCreatedDBObject((DBObject)(object)val2, true);
			}
			TypedValue[] array = new TypedValue[8]
			{
				new TypedValue(1001, (object)"AUXINTERLIG"),
				new TypedValue(1070, (object)tipo),
				new TypedValue(1000, (object)handle),
				new TypedValue(1000, (object)THandle),
				new TypedValue(1071, (object)1),
				new TypedValue(1000, (object)Environment.UserName),
				new TypedValue(1000, (object)DateTime.Now.ToString()),
				new TypedValue(1000, (object)sOpcionais)
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

	public static bool lerXDataAuxInterligacao(ref Entity ent, ref string handle, ref short tipo, ref string THandle, [Optional][DefaultParameterValue("")] ref string sOpcionais)
	{
		bool result = false;
		ResultBuffer xDataForApplication = ((DBObject)ent).GetXDataForApplication("AUXINTERLIG");
		if (xDataForApplication != null)
		{
			TypedValue[] array = xDataForApplication.AsArray();
			tipo = Conversions.ToShort(array[1].Value);
			handle = Conversions.ToString(array[2].Value);
			THandle = Conversions.ToString(array[3].Value);
			sOpcionais = Conversions.ToString(array[7].Value);
			result = true;
		}
		return result;
	}

	public static void GravarXDataAuxInterligacaoEletrosul(ref Entity ent, string handle, short tipo, string THandle)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			RegAppTable val = (RegAppTable)topTransaction.GetObject(database.RegAppTableId, (OpenMode)1);
			if (!((SymbolTable)val).Has("ELETROSUL"))
			{
				RegAppTableRecord val2 = new RegAppTableRecord();
				((SymbolTableRecord)val2).Name = "ELETROSUL";
				((SymbolTable)val).Add((SymbolTableRecord)(object)val2);
				DeclaracoesGeral.bAnularEventos = true;
				topTransaction.AddNewlyCreatedDBObject((DBObject)(object)val2, true);
			}
			TypedValue[] array = new TypedValue[5]
			{
				new TypedValue(1001, (object)"ELETROSUL"),
				new TypedValue(1000, (object)Environment.UserName),
				new TypedValue(1000, (object)DateTime.Now.ToString()),
				new TypedValue(1000, (object)handle),
				new TypedValue(1071, (object)1)
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

	public static bool lerXDataAuxInterligacaoEletrosul(ref Entity ent, [Optional][DefaultParameterValue("")] ref string sHandle)
	{
		bool result = false;
		ResultBuffer xDataForApplication = ((DBObject)ent).GetXDataForApplication("ELETROSUL");
		if (xDataForApplication != null)
		{
			TypedValue[] array = xDataForApplication.AsArray();
			result = true;
			sHandle = Conversions.ToString(array[3].Value);
		}
		return result;
	}

	public static void GravarXDataAuxInterligacaoENEL(ref Entity ent, string handle, short tipo, string THandle)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			RegAppTable val = (RegAppTable)topTransaction.GetObject(database.RegAppTableId, (OpenMode)1);
			if (!((SymbolTable)val).Has("AUXINTERLIG"))
			{
				RegAppTableRecord val2 = new RegAppTableRecord();
				((SymbolTableRecord)val2).Name = "AUXINTERLIG";
				((SymbolTable)val).Add((SymbolTableRecord)(object)val2);
				DeclaracoesGeral.bAnularEventos = true;
				topTransaction.AddNewlyCreatedDBObject((DBObject)(object)val2, true);
			}
			TypedValue[] array = new TypedValue[8]
			{
				new TypedValue(1001, (object)"AUXINTERLIG"),
				new TypedValue(1070, (object)2),
				new TypedValue(1000, (object)handle),
				new TypedValue(1000, (object)""),
				new TypedValue(1071, (object)1),
				new TypedValue(1000, (object)Environment.UserName),
				new TypedValue(1000, (object)DateTime.Now.ToString()),
				new TypedValue(1000, (object)"")
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

	public static bool lerXDataAuxInterligacaoENEL(ref Entity ent)
	{
		bool result = false;
		ResultBuffer xDataForApplication = ((DBObject)ent).GetXDataForApplication("AUXINTERLIG");
		if (xDataForApplication != null)
		{
			result = true;
		}
		return result;
	}

	public static bool lerXDataAuxInterligacaoENELHandle(ref Entity ent, ref string sHandle)
	{
		bool result = false;
		ResultBuffer xDataForApplication = ((DBObject)ent).GetXDataForApplication("ENEL");
		if (xDataForApplication != null)
		{
			TypedValue[] array = xDataForApplication.AsArray();
			sHandle = Conversions.ToString(array[3].Value);
			result = true;
		}
		return result;
	}

	public static void AtualizaXDataInterligacao(ref Polyline pl, ref DeclaracoesEntidades.StructureInterligacao ilig)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected Obj, but got Unknown
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected Obj, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0296: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Expected Obj, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected Obj, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		Entity ent = (Entity)(object)pl;
		object oValor = text;
		XDataDispositivo.lexDataRetornaValorDoIndiceInformado(ref ent, "INTERLIGACAO", 9, ref oValor);
		text = Conversions.ToString(oValor);
		pl = (Polyline)ent;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			RegAppTable val2 = (RegAppTable)val.GetObject(database.RegAppTableId, (OpenMode)1);
			if (!((SymbolTable)val2).Has("INTERLIGACAO"))
			{
				RegAppTableRecord val3 = new RegAppTableRecord();
				((SymbolTableRecord)val3).Name = "INTERLIGACAO";
				((SymbolTable)val2).Add((SymbolTableRecord)(object)val3);
				DeclaracoesGeral.bAnularEventos = true;
				val.AddNewlyCreatedDBObject((DBObject)(object)val3, true);
			}
			TypedValue[] array = new TypedValue[19]
			{
				new TypedValue(1001, (object)"INTERLIGACAO"),
				new TypedValue(1070, (object)ilig.Tipo),
				new TypedValue(1000, (object)ilig.Tag_Cabo),
				new TypedValue(1070, (object)ilig.NumVeia),
				new TypedValue(1000, (object)ilig.NomeVeia),
				new TypedValue(1070, (object)ilig.Painel1),
				new TypedValue(1070, (object)0),
				new TypedValue(1070, (object)ilig.Painel2),
				new TypedValue(1070, (object)0),
				new TypedValue(1000, (object)text),
				new TypedValue(1000, (object)""),
				new TypedValue(1000, (object)""),
				new TypedValue(1070, (object)ilig.ocultaTag),
				new TypedValue(1070, (object)ilig.iModeloVeiaFuncao),
				new TypedValue(1000, (object)Environment.UserName),
				new TypedValue(1000, (object)DateTime.Now.ToString()),
				new TypedValue(1071, (object)1),
				new TypedValue(1040, (object)0),
				new TypedValue(1000, (object)"")
			};
			((DBObject)pl).XData = new ResultBuffer(array);
			DeclaracoesGeral.bAnularEventos = true;
			val.Commit();
			DeclaracoesGeral.bAnularEventos = false;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static bool checaHandleEntidadeAuxInterligacao(ref Entity ent, string handle)
	{
		bool result = false;
		ResultBuffer xDataForApplication = ((DBObject)ent).GetXDataForApplication("AUXINTERLIG");
		if (xDataForApplication != null)
		{
			TypedValue[] array = xDataForApplication.AsArray();
			if (Operators.ConditionalCompareObjectEqual(array[2].Value, handle, TextCompare: true))
			{
				result = true;
			}
		}
		return result;
	}

	public static bool checaXDataAuxInterligacaoEletrosulHandle(ref Entity ent, ref string handle)
	{
		bool result = false;
		ResultBuffer xDataForApplication = ((DBObject)ent).GetXDataForApplication("ELETROSUL");
		if (xDataForApplication != null)
		{
			TypedValue[] array = xDataForApplication.AsArray();
			if (Operators.ConditionalCompareObjectEqual(handle, array[3].Value, TextCompare: true))
			{
				result = true;
			}
		}
		return result;
	}
}

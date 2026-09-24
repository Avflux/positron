using System;
using System.Linq;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Runtime;

namespace Eletron4;

public class XDataRelatorio
{
	public static void GravarXDataFiacao(ref Entity Ent, string sRelatorio, int iPN)
	{
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected Obj, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				RegAppTable val3 = (RegAppTable)val2.GetObject(database.RegAppTableId, (OpenMode)1);
				if (!((SymbolTable)val3).Has("Eletron"))
				{
					RegAppTableRecord val4 = new RegAppTableRecord();
					((SymbolTableRecord)val4).Name = "Eletron";
					((SymbolTable)val3).Add((SymbolTableRecord)(object)val4);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
				}
				TypedValue[] array = new TypedValue[5]
				{
					new TypedValue(1001, (object)"Eletron"),
					new TypedValue(1000, (object)"Fiacao"),
					new TypedValue(1000, (object)sRelatorio),
					new TypedValue(1071, (object)iPN),
					new TypedValue(1000, (object)"")
				};
				((DBObject)Ent).UpgradeOpen();
				((DBObject)Ent).XData = new ResultBuffer(array);
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				val2.Abort();
				throw;
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

	public static bool LerXDataFiacao(ref Entity Ent, ref string sRel, ref int iPN)
	{
		bool flag = false;
		ResultBuffer val = null;
		val = ((DBObject)Ent).GetXDataForApplication("Eletron");
		if (val == null)
		{
			val = ((DBObject)Ent).GetXDataForApplication("Eletron".ToUpper());
			if (val != null)
			{
				flag = true;
			}
		}
		else
		{
			flag = true;
		}
		if (flag)
		{
			TypedValue[] array = val.AsArray();
			if (Operators.CompareString(array[0].Value.ToString().ToUpper(), "Eletron".ToUpper(), TextCompare: true) != 0)
			{
				flag = false;
			}
			else if (Operators.CompareString(array[1].Value.ToString().ToUpper(), "FIACAO", TextCompare: true) != 0)
			{
				flag = false;
			}
			else
			{
				sRel = Conversions.ToString(array[2].Value);
				iPN = Conversions.ToInteger(array[3].Value);
				flag = true;
			}
		}
		return flag;
	}

	public static void GravarXDataJumpers(ref Entity Ent, string sRelatorio, int iPN)
	{
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected Obj, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				RegAppTable val3 = (RegAppTable)val2.GetObject(database.RegAppTableId, (OpenMode)1);
				if (!((SymbolTable)val3).Has("Eletron"))
				{
					RegAppTableRecord val4 = new RegAppTableRecord();
					((SymbolTableRecord)val4).Name = "Eletron";
					((SymbolTable)val3).Add((SymbolTableRecord)(object)val4);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
				}
				TypedValue[] array = new TypedValue[5]
				{
					new TypedValue(1001, (object)"Eletron"),
					new TypedValue(1000, (object)"JUMPEREXT"),
					new TypedValue(1000, (object)sRelatorio),
					new TypedValue(1071, (object)iPN),
					new TypedValue(1000, (object)"")
				};
				((DBObject)Ent).UpgradeOpen();
				((DBObject)Ent).XData = new ResultBuffer(array);
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				val2.Abort();
				throw;
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

	public static bool LerXDataJumpers(ref Entity Ent, ref string sRel, ref int iPN)
	{
		bool flag = false;
		ResultBuffer val = null;
		val = ((DBObject)Ent).GetXDataForApplication("Eletron");
		if (val == null)
		{
			val = ((DBObject)Ent).GetXDataForApplication("Eletron".ToUpper());
			if (val != null)
			{
				flag = true;
			}
		}
		else
		{
			flag = true;
		}
		if (flag)
		{
			TypedValue[] array = val.AsArray();
			if (Operators.CompareString(array[0].Value.ToString().ToUpper(), "Eletron".ToUpper(), TextCompare: true) != 0)
			{
				flag = false;
			}
			else if (Operators.CompareString(array[1].Value.ToString().ToUpper(), "JUMPEREXT", TextCompare: true) != 0)
			{
				flag = false;
			}
			else
			{
				sRel = Conversions.ToString(array[2].Value);
				iPN = Conversions.ToInteger(array[3].Value);
				flag = true;
			}
		}
		return flag;
	}

	public static void GravarXDataPlaquetas(ref Entity Ent, string sIndice, string sDisp, int iPN)
	{
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Expected Obj, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				RegAppTable val3 = (RegAppTable)val2.GetObject(database.RegAppTableId, (OpenMode)1);
				if (!((SymbolTable)val3).Has("Eletron"))
				{
					RegAppTableRecord val4 = new RegAppTableRecord();
					((SymbolTableRecord)val4).Name = "Eletron";
					((SymbolTable)val3).Add((SymbolTableRecord)(object)val4);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
				}
				TypedValue[] array = new TypedValue[5]
				{
					new TypedValue(1001, (object)"Eletron"),
					new TypedValue(1000, (object)"Plaquetas"),
					new TypedValue(1000, (object)sIndice),
					new TypedValue(1000, (object)sDisp),
					new TypedValue(1071, (object)iPN)
				};
				((DBObject)Ent).UpgradeOpen();
				((DBObject)Ent).XData = new ResultBuffer(array);
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				val2.Abort();
				throw;
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

	public static bool LerXDataPlaquetas(ref Entity Ent, ref string sEti, ref string sDisp, ref int iPN)
	{
		bool flag = false;
		ResultBuffer val = null;
		val = ((DBObject)Ent).GetXDataForApplication("Eletron");
		if (val == null)
		{
			val = ((DBObject)Ent).GetXDataForApplication("Eletron".ToUpper());
			if (val != null)
			{
				flag = true;
			}
		}
		else
		{
			flag = true;
		}
		if (flag)
		{
			TypedValue[] array = val.AsArray();
			if (Operators.CompareString(array[0].Value.ToString().ToUpper(), "Eletron".ToUpper(), TextCompare: true) != 0)
			{
				flag = false;
			}
			else if (Operators.CompareString(array[1].Value.ToString().ToUpper(), "PLAQUETAS", TextCompare: true) != 0)
			{
				flag = false;
			}
			else
			{
				sEti = Conversions.ToString(array[2].Value);
				sDisp = Conversions.ToString(array[3].Value);
				iPN = Conversions.ToInteger(array[4].Value);
				flag = true;
			}
		}
		return flag;
	}

	public static void GravarXDataIndice(ref object ent, int iIndice, string sPG = "")
	{
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			RegAppTable val2 = (RegAppTable)val.GetObject(database.RegAppTableId, (OpenMode)1);
			if (!((SymbolTable)val2).Has("DiagLog"))
			{
				RegAppTableRecord val3 = new RegAppTableRecord();
				((SymbolTableRecord)val3).Name = "DiagLog";
				((SymbolTable)val2).Add((SymbolTableRecord)(object)val3);
				DeclaracoesGeral.bAnularEventos = true;
				val.AddNewlyCreatedDBObject((DBObject)(object)val3, true);
			}
			TypedValue[] array = new TypedValue[6]
			{
				new TypedValue(1001, (object)"DiagLog"),
				new TypedValue(1000, (object)"INDICE"),
				new TypedValue(1071, (object)iIndice),
				new TypedValue(1000, (object)Environment.UserName),
				new TypedValue(1000, (object)DateTime.Now.ToString()),
				new TypedValue(1000, (object)sPG)
			};
			NewLateBinding.LateSet(ent, null, "XData", new object[1] { (object)new ResultBuffer(array) }, null, null);
			DeclaracoesGeral.bAnularEventos = true;
			val.Commit();
			DeclaracoesGeral.bAnularEventos = false;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw new Exception((ErrorStatus)1, "Não conseguiu gravar o XData!");
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static bool LerXDataIndicePG(ref Entity Ent)
	{
		bool flag = false;
		ResultBuffer xDataForApplication = ((DBObject)Ent).GetXDataForApplication("DiagLog");
		if (xDataForApplication == null)
		{
			xDataForApplication = ((DBObject)Ent).GetXDataForApplication("DiagLog".ToUpper());
			if (xDataForApplication != null)
			{
				flag = true;
			}
		}
		else
		{
			flag = true;
		}
		if (flag)
		{
			TypedValue[] array = xDataForApplication.AsArray();
			flag = Operators.CompareString(array[0].Value.ToString().ToUpper(), "DiagLog".ToUpper(), TextCompare: true) == 0 && Operators.CompareString(array[1].Value.ToString().ToUpper(), "INDICE", TextCompare: true) == 0 && (Operators.ConditionalCompareObjectNotEqual(array[5].Value, "", TextCompare: true) ? true : false);
		}
		return flag;
	}

	public static bool TemOxDataNoRelatorio(ref Entity ent, string sNomeRelatorio)
	{
		bool result = false;
		ResultBuffer xDataForApplication = ((DBObject)ent).GetXDataForApplication("DiagLog");
		if (xDataForApplication != null)
		{
			TypedValue[] array = xDataForApplication.AsArray();
			if (Operators.CompareString(array[1].Value.ToString().ToUpper(), sNomeRelatorio, TextCompare: true) == 0)
			{
				result = true;
			}
		}
		return result;
	}

	public static void GravarXDataMateriais(ref Entity Ent, int iIndice, int iPN, string sDisp = "")
	{
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected Obj, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				RegAppTable val3 = (RegAppTable)val2.GetObject(database.RegAppTableId, (OpenMode)1);
				if (!((SymbolTable)val3).Has("Eletron"))
				{
					RegAppTableRecord val4 = new RegAppTableRecord();
					((SymbolTableRecord)val4).Name = "Eletron";
					((SymbolTable)val3).Add((SymbolTableRecord)(object)val4);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
				}
				TypedValue[] array = new TypedValue[5]
				{
					new TypedValue(1001, (object)"Eletron"),
					new TypedValue(1000, (object)"RELMATERIAIS"),
					new TypedValue(1071, (object)iIndice),
					new TypedValue(1071, (object)iPN),
					new TypedValue(1000, (object)sDisp)
				};
				((DBObject)Ent).UpgradeOpen();
				((DBObject)Ent).XData = new ResultBuffer(array);
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				val2.Abort();
				throw;
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

	public static bool LerXDataMateriais(ref Entity Ent, ref int iIndice, ref int iPN)
	{
		bool flag = false;
		ResultBuffer val = null;
		val = ((DBObject)Ent).GetXDataForApplication("Eletron");
		if (val == null)
		{
			val = ((DBObject)Ent).GetXDataForApplication("Eletron".ToUpper());
			if (val != null)
			{
				flag = true;
			}
		}
		else
		{
			flag = true;
		}
		if (flag)
		{
			TypedValue[] array = val.AsArray();
			if (Operators.CompareString(array[0].Value.ToString().ToUpper(), "Eletron".ToUpper(), TextCompare: true) != 0)
			{
				flag = false;
			}
			else if (Operators.CompareString(array[1].Value.ToString().ToUpper(), "RELMATERIAIS", TextCompare: true) != 0)
			{
				flag = false;
			}
			else if (!Operators.ConditionalCompareObjectEqual(array[3].Value, iPN, TextCompare: true))
			{
				flag = false;
			}
			else
			{
				iIndice = Conversions.ToInteger(array[2].Value);
				flag = true;
			}
		}
		return flag;
	}

	public static bool LerDispsXDataMateriais(ref Entity Ent, ref int iIndice, ref int iPN, ref string[] sDisps)
	{
		bool flag = false;
		ResultBuffer val = null;
		val = ((DBObject)Ent).GetXDataForApplication("Eletron");
		if (val == null)
		{
			val = ((DBObject)Ent).GetXDataForApplication("Eletron".ToUpper());
			if (val != null)
			{
				flag = true;
			}
		}
		else
		{
			flag = true;
		}
		if (flag)
		{
			TypedValue[] array = val.AsArray();
			if (Operators.CompareString(array[0].Value.ToString().ToUpper(), "Eletron".ToUpper(), TextCompare: true) != 0)
			{
				flag = false;
			}
			else if (Operators.CompareString(array[1].Value.ToString().ToUpper(), "RELMATERIAIS", TextCompare: true) != 0)
			{
				flag = false;
			}
			else if (!Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(array[4].Value, null, "trim", new object[0], null, null, null), "", TextCompare: true))
			{
				flag = false;
			}
			else
			{
				iIndice = Conversions.ToInteger(array[2].Value);
				iPN = Conversions.ToInteger(array[3].Value);
				sDisps = (string[])NewLateBinding.LateGet(array[4].Value, null, "Split", new object[1] { "," }, null, null, null);
				flag = true;
			}
		}
		return flag;
	}

	public static bool LerDispsXDataMateriaisM(ref Entity Ent, ref int iIndice, ref int iPN, ref string[] sDisps)
	{
		bool flag = false;
		ResultBuffer val = null;
		val = ((DBObject)Ent).GetXDataForApplication("Eletron");
		if (val == null)
		{
			val = ((DBObject)Ent).GetXDataForApplication("Eletron".ToUpper());
			if (val != null)
			{
				flag = true;
			}
		}
		else
		{
			flag = true;
		}
		if (flag)
		{
			TypedValue[] array = val.AsArray();
			if (Operators.CompareString(array[0].Value.ToString().ToUpper(), "Eletron".ToUpper(), TextCompare: true) != 0)
			{
				flag = false;
			}
			else if (Operators.CompareString(array[1].Value.ToString().ToUpper(), "RELMATERIAIS", TextCompare: true) != 0)
			{
				flag = false;
			}
			else
			{
				iIndice = Conversions.ToInteger(array[2].Value);
				iPN = Conversions.ToInteger(array[3].Value);
				sDisps = (string[])NewLateBinding.LateGet(array[4].Value, null, "Split", new object[1] { "," }, null, null, null);
				flag = true;
			}
		}
		return flag;
	}

	public static void gravaXDataDistPot(ref Entity Ent, Relatorios_DistribuicaoPot.StructureBloco Bloco)
	{
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Expected Obj, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				RegAppTable val3 = (RegAppTable)val2.GetObject(database.RegAppTableId, (OpenMode)1);
				if (!((SymbolTable)val3).Has("DistribuicaoDePotenciais"))
				{
					RegAppTableRecord val4 = new RegAppTableRecord();
					((SymbolTableRecord)val4).Name = "DistribuicaoDePotenciais";
					((SymbolTable)val3).Add((SymbolTableRecord)(object)val4);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
				}
				TypedValue[] array = new TypedValue[13]
				{
					new TypedValue(1001, (object)"DistribuicaoDePotenciais"),
					new TypedValue(1071, (object)Bloco.iPot),
					new TypedValue(1071, (object)Bloco.iDwg),
					new TypedValue(1000, (object)Bloco.sTipo),
					new TypedValue(1071, (object)Bloco.iPn),
					new TypedValue(1000, (object)Bloco.sRegua),
					new TypedValue(1000, (object)Bloco.sNome),
					new TypedValue(1000, (object)Bloco.sT1),
					new TypedValue(1000, (object)Bloco.sT2),
					new TypedValue(1000, (object)" "),
					new TypedValue(1000, (object)Bloco.sHandle),
					new TypedValue(1000, (object)Bloco.sRevisao),
					new TypedValue(1071, (object)Bloco.Eletron)
				};
				((DBObject)Ent).XData = new ResultBuffer(array);
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				val2.Abort();
				throw;
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

	public static bool LerXDataDistPot(ref Entity Ent, ref Relatorios_DistribuicaoPot.StructureBloco Bloco)
	{
		bool flag = false;
		ResultBuffer val = null;
		val = ((DBObject)Ent).GetXDataForApplication("DistribuicaoDePotenciais");
		if (val == null)
		{
			val = ((DBObject)Ent).GetXDataForApplication("DISTRIBUICAODEPOTENCIAIS");
			if (val != null)
			{
				flag = true;
			}
		}
		else
		{
			flag = true;
		}
		if (!flag)
		{
			return false;
		}
		TypedValue[] array = val.AsArray();
		if (Operators.CompareString(array[0].Value.ToString().ToUpper(), "DISTRIBUICAODEPOTENCIAIS", TextCompare: true) != 0)
		{
			return false;
		}
		Bloco.iPot = Conversions.ToInteger(array[1].Value);
		Bloco.iDwg = Conversions.ToInteger(array[2].Value);
		Bloco.sTipo = Conversions.ToString(array[3].Value);
		Bloco.iPn = Conversions.ToInteger(array[4].Value);
		Bloco.sRegua = Conversions.ToString(array[5].Value);
		Bloco.sNome = Conversions.ToString(array[6].Value);
		Bloco.sT1 = Conversions.ToString(array[7].Value);
		Bloco.sT2 = Conversions.ToString(array[8].Value);
		Bloco.sHandle = Conversions.ToString(array[10].Value);
		if (array.Length != 11)
		{
			Bloco.Eletron = 4;
			Bloco.sRevisao = Conversions.ToString(array[11].Value);
		}
		else
		{
			Bloco.Eletron = 3;
			Bloco.sRevisao = "";
		}
		return true;
	}

	public static bool LerXDataDistPotLinhas(ref Entity Ent, ref Relatorios_DistribuicaoPot.StructureBloco Bloco)
	{
		bool flag = false;
		ResultBuffer val = null;
		val = ((DBObject)Ent).GetXDataForApplication("DistribuicaoDePotenciaisLinha");
		if (val == null)
		{
			val = ((DBObject)Ent).GetXDataForApplication("DISTRIBUICAODEPOTENCIAISLINHA");
			if (val != null)
			{
				flag = true;
			}
		}
		else
		{
			flag = true;
		}
		if (!flag)
		{
			return false;
		}
		TypedValue[] array = val.AsArray();
		if (Operators.CompareString(array[0].Value.ToString().ToUpper(), "DISTRIBUICAODEPOTENCIAISLINHA", TextCompare: true) != 0)
		{
			return false;
		}
		Bloco.iPot = Conversions.ToInteger(array[1].Value);
		Bloco.iDwg = Conversions.ToInteger(array[2].Value);
		Bloco.sTipo = "L";
		Bloco.iPn = 0;
		Bloco.sRegua = "";
		Bloco.sNome = "";
		Bloco.sT1 = "";
		Bloco.sT2 = "";
		Bloco.sHandle = "";
		if (array.Length != 11)
		{
			Bloco.Eletron = 4;
			Bloco.sRevisao = Conversions.ToString(array[11].Value);
		}
		else
		{
			Bloco.Eletron = 3;
			Bloco.sRevisao = "";
		}
		return true;
	}

	public static void LeTodosOsXdatasDeRelatorio(ref Entity ent, ref string s1, ref string s2)
	{
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				_ = (RegAppTable)val2.GetObject(database.RegAppTableId, (OpenMode)1);
				if (((DBObject)ent).XData != (ResultBuffer)null)
				{
					string text = ((DBObject)ent).XData.ToString();
					string[] array = text.Split(')');
					if (Information.UBound(array) > 0)
					{
						int num = 0;
						do
						{
							array[num] = array[num].Replace("(", "");
							array[num] = array[num].Replace(")", "");
							num = checked(num + 1);
						}
						while (num <= 1);
						string[] array2 = null;
						array2 = array[0].Split(',');
						s1 = array2[1];
						array2 = array[1].Split(',');
						s2 = array2[1];
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				val2.Abort();
				throw;
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

	public static void GravarXDataCabosEnergisa(ref Entity Ent, string sRev, ref string sRelatorio, ref string sCabo)
	{
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected Obj, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				RegAppTable val3 = (RegAppTable)val2.GetObject(database.RegAppTableId, (OpenMode)1);
				if (!((SymbolTable)val3).Has("Eletron"))
				{
					RegAppTableRecord val4 = new RegAppTableRecord();
					((SymbolTableRecord)val4).Name = "Eletron";
					((SymbolTable)val3).Add((SymbolTableRecord)(object)val4);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
				}
				TypedValue[] array = new TypedValue[7]
				{
					new TypedValue(1001, (object)"Eletron"),
					new TypedValue(1000, (object)"CabosDWG"),
					new TypedValue(1000, (object)sRelatorio),
					new TypedValue(1000, (object)sRev),
					new TypedValue(1000, (object)sCabo),
					new TypedValue(1000, (object)""),
					new TypedValue(1000, (object)"")
				};
				((DBObject)Ent).UpgradeOpen();
				((DBObject)Ent).XData = new ResultBuffer(array);
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				val2.Abort();
				throw;
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

	public static bool LEXDataCabosEnergisa(ref Entity Ent, ref string SREV, ref string sRelatorio, ref string sCabo)
	{
		bool flag = false;
		ResultBuffer val = null;
		val = ((DBObject)Ent).GetXDataForApplication("Eletron");
		if (val == null)
		{
			val = ((DBObject)Ent).GetXDataForApplication("Eletron".ToUpper());
			if (val != null)
			{
				flag = true;
			}
		}
		else
		{
			flag = true;
		}
		if (flag)
		{
			TypedValue[] array = val.AsArray();
			if (Operators.CompareString(array[0].Value.ToString().ToUpper(), "Eletron".ToUpper(), TextCompare: true) != 0)
			{
				flag = false;
			}
			else if (Operators.CompareString(array[1].Value.ToString().ToUpper(), "CABOSDWG", TextCompare: true) != 0)
			{
				flag = false;
			}
			else if (!Operators.ConditionalCompareObjectEqual(array[3].Value, SREV, TextCompare: true))
			{
				flag = false;
			}
			else
			{
				sRelatorio = Conversions.ToString(array[2].Value);
				sCabo = Conversions.ToString(array[4].Value);
				flag = true;
			}
		}
		return flag;
	}

	public static void GravarXDataCabosEDPES(ref Entity Ent, string revisaoSel, int iPainel)
	{
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected Obj, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				RegAppTable val3 = (RegAppTable)val2.GetObject(database.RegAppTableId, (OpenMode)1);
				if (!((SymbolTable)val3).Has("Eletron"))
				{
					RegAppTableRecord val4 = new RegAppTableRecord();
					((SymbolTableRecord)val4).Name = "Eletron";
					((SymbolTable)val3).Add((SymbolTableRecord)(object)val4);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
				}
				TypedValue[] array = new TypedValue[5]
				{
					new TypedValue(1001, (object)"Eletron"),
					new TypedValue(1000, (object)"CabosEDPESDWG"),
					new TypedValue(1070, (object)iPainel),
					new TypedValue(1000, (object)revisaoSel),
					new TypedValue(1000, (object)"")
				};
				((DBObject)Ent).UpgradeOpen();
				((DBObject)Ent).XData = new ResultBuffer(array);
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				val2.Abort();
				throw;
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

	public static bool LEXDataCabosEDPES(ref Entity Ent, ref string SREV)
	{
		bool flag = false;
		ResultBuffer val = null;
		val = ((DBObject)Ent).GetXDataForApplication("Eletron");
		if (val == null)
		{
			val = ((DBObject)Ent).GetXDataForApplication("Eletron".ToUpper());
			if (val != null)
			{
				flag = true;
			}
		}
		else
		{
			flag = true;
		}
		if (flag)
		{
			TypedValue[] array = val.AsArray();
			flag = Operators.CompareString(array[0].Value.ToString().ToUpper(), "Eletron".ToUpper(), TextCompare: true) == 0 && Operators.CompareString(array[1].Value.ToString().ToUpper(), "CABOSEDPESDWG", TextCompare: true) == 0 && (Operators.ConditionalCompareObjectEqual(array[3].Value, SREV, TextCompare: true) ? true : false);
		}
		return flag;
	}

	public static bool LeXDataRevisao(ref BlockReference blockRef, ref DeclaracoesGeral.Revisoes revC)
	{
		bool result = false;
		ResultBuffer xDataForApplication = ((DBObject)blockRef).GetXDataForApplication("DiagLog");
		if (xDataForApplication != null)
		{
			TypedValue[] array = xDataForApplication.AsArray();
			if (Operators.CompareString(array[1].Value.ToString().ToUpper(), "REVISAO", TextCompare: true) == 0)
			{
				revC.Posicao = Conversions.ToInteger(array[2].Value);
				revC.RevisaoOriginal = Conversions.ToString(array[3].Value);
				revC.Revisao = Conversions.ToString(array[3].Value);
				revC.Descricao = Conversions.ToString(array[4].Value);
				revC.Elaborador = Conversions.ToString(array[5].Value);
				revC.Verificador = Conversions.ToString(array[6].Value);
				revC.Aprovador = Conversions.ToString(array[7].Value);
				revC.Data = Conversions.ToString(array[8].Value);
				result = true;
			}
		}
		return result;
	}

	public static bool leXDataRevisaoCompleta(ref Entity Ent, ref string sRevisao, ref int iColuna, ref int iIndice)
	{
		bool flag = false;
		ResultBuffer val = null;
		val = ((DBObject)Ent).GetXDataForApplication("Eletron");
		if (val == null)
		{
			val = ((DBObject)Ent).GetXDataForApplication("Eletron".ToUpper());
			if (val != null)
			{
				flag = true;
			}
		}
		else
		{
			flag = true;
		}
		if (flag)
		{
			TypedValue[] array = val.AsArray();
			if (Operators.CompareString(array[0].Value.ToString().ToUpper(), "Eletron".ToUpper(), TextCompare: true) != 0)
			{
				flag = false;
			}
			else if (Operators.CompareString(array[1].Value.ToString().ToUpper(), "REVISAOCOMPLETA", TextCompare: true) != 0)
			{
				flag = false;
			}
			else
			{
				sRevisao = Conversions.ToString(array[2].Value);
				iColuna = Conversions.ToInteger(array[3].Value);
				iIndice = Conversions.ToInteger(array[4].Value);
				flag = true;
			}
		}
		return flag;
	}

	public static bool leXDataBuscaTamanhoColunasRevisaoCompleta(ref Entity Ent, ref Relatorios_Rev.ConfigReV confRelRev)
	{
		bool flag = false;
		ResultBuffer val = null;
		val = ((DBObject)Ent).GetXDataForApplication("Eletron");
		if (val == null)
		{
			val = ((DBObject)Ent).GetXDataForApplication("Eletron".ToUpper());
			if (val != null)
			{
				flag = true;
			}
		}
		else
		{
			flag = true;
		}
		if (flag)
		{
			TypedValue[] array = val.AsArray();
			if (Operators.CompareString(array[0].Value.ToString().ToUpper(), "Eletron".ToUpper(), TextCompare: true) != 0)
			{
				flag = false;
			}
			else if (Operators.CompareString(array[1].Value.ToString().ToUpper(), "REVISAOCOMPLETA", TextCompare: true) != 0)
			{
				flag = false;
			}
			else if (array.Count() > 6)
			{
				confRelRev.i1 = Conversions.ToInteger(array[5].Value);
				confRelRev.i2 = Conversions.ToInteger(array[6].Value);
				confRelRev.i3 = Conversions.ToInteger(array[7].Value);
				flag = true;
			}
		}
		return flag;
	}

	public static void GravarXDataRevisaoCompleta(ref Entity Ent, string sRevisao, int iColuna, int iIndice, int i1, int i2, int i3)
	{
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected Obj, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				RegAppTable val3 = (RegAppTable)val2.GetObject(database.RegAppTableId, (OpenMode)1);
				if (!((SymbolTable)val3).Has("Eletron"))
				{
					RegAppTableRecord val4 = new RegAppTableRecord();
					((SymbolTableRecord)val4).Name = "Eletron";
					((SymbolTable)val3).Add((SymbolTableRecord)(object)val4);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
				}
				TypedValue[] array = new TypedValue[9]
				{
					new TypedValue(1001, (object)"Eletron"),
					new TypedValue(1000, (object)"REVISAOCOMPLETA"),
					new TypedValue(1000, (object)sRevisao),
					new TypedValue(1071, (object)iColuna),
					new TypedValue(1071, (object)iIndice),
					new TypedValue(1071, (object)i1),
					new TypedValue(1071, (object)i2),
					new TypedValue(1071, (object)i3),
					new TypedValue(1000, (object)"")
				};
				((DBObject)Ent).UpgradeOpen();
				((DBObject)Ent).XData = new ResultBuffer(array);
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				val2.Abort();
				throw;
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

	public static bool leXDataRevisaoElektro(ref Entity Ent, ref clsRelatorio_Elektro.ConfElektro rel)
	{
		bool flag = false;
		ResultBuffer val = null;
		val = ((DBObject)Ent).GetXDataForApplication("Eletron");
		if (val == null)
		{
			val = ((DBObject)Ent).GetXDataForApplication("Eletron".ToUpper());
			if (val != null)
			{
				flag = true;
			}
		}
		else
		{
			flag = true;
		}
		if (flag)
		{
			TypedValue[] array = val.AsArray();
			if (Operators.CompareString(array[0].Value.ToString().ToUpper(), "Eletron".ToUpper(), TextCompare: true) != 0)
			{
				flag = false;
			}
			else if (Operators.CompareString(array[1].Value.ToString().ToUpper(), "RELELEKTRO", TextCompare: true) != 0)
			{
				flag = false;
			}
			else
			{
				rel.iColuna = Conversions.ToInteger(array[3].Value);
				rel.iIndiceUnico = Conversions.ToInteger(array[4].Value);
				rel.iPainel = Conversions.ToInteger(array[5].Value);
				rel.sDisp = Conversions.ToString(array[6].Value);
				rel.sTipo = Conversions.ToString(array[7].Value);
				rel.sUnidade = Conversions.ToString(array[8].Value);
				flag = true;
			}
		}
		return flag;
	}

	public static void GravarXDataElektro(ref Entity Ent, clsRelatorio_Elektro.ConfElektro rel)
	{
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Expected Obj, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				RegAppTable val3 = (RegAppTable)val2.GetObject(database.RegAppTableId, (OpenMode)1);
				if (!((SymbolTable)val3).Has("Eletron"))
				{
					RegAppTableRecord val4 = new RegAppTableRecord();
					((SymbolTableRecord)val4).Name = "Eletron";
					((SymbolTable)val3).Add((SymbolTableRecord)(object)val4);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
				}
				TypedValue[] array = new TypedValue[11]
				{
					new TypedValue(1001, (object)"Eletron"),
					new TypedValue(1000, (object)"RELELEKTRO"),
					new TypedValue(1000, (object)""),
					new TypedValue(1071, (object)rel.iColuna),
					new TypedValue(1071, (object)rel.iIndiceUnico),
					new TypedValue(1071, (object)rel.iPainel),
					new TypedValue(1000, (object)rel.sDisp),
					new TypedValue(1000, (object)rel.sTipo),
					new TypedValue(1000, (object)rel.sUnidade),
					new TypedValue(1000, (object)""),
					new TypedValue(1000, (object)"")
				};
				((DBObject)Ent).UpgradeOpen();
				((DBObject)Ent).XData = new ResultBuffer(array);
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				val2.Abort();
				throw;
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

	public static void GravarXDataFurnas(ref Entity Ent, int Pag)
	{
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected Obj, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				RegAppTable val3 = (RegAppTable)val2.GetObject(database.RegAppTableId, (OpenMode)1);
				if (!((SymbolTable)val3).Has("Eletron"))
				{
					RegAppTableRecord val4 = new RegAppTableRecord();
					((SymbolTableRecord)val4).Name = "Eletron";
					((SymbolTable)val3).Add((SymbolTableRecord)(object)val4);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
				}
				TypedValue[] array = new TypedValue[3]
				{
					new TypedValue(1001, (object)"Eletron"),
					new TypedValue(1000, (object)"REL_FURNAS"),
					new TypedValue(1070, (object)Pag)
				};
				((DBObject)Ent).UpgradeOpen();
				((DBObject)Ent).XData = new ResultBuffer(array);
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				val2.Abort();
				throw;
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

	public static bool LerXDataFurnas(ref Entity Ent)
	{
		bool result = false;
		bool flag = false;
		ResultBuffer val = null;
		val = ((DBObject)Ent).GetXDataForApplication("Eletron");
		if (val == null)
		{
			val = ((DBObject)Ent).GetXDataForApplication("Eletron".ToUpper());
			if (val != null)
			{
				flag = true;
			}
		}
		else
		{
			flag = true;
		}
		if (flag)
		{
			TypedValue[] array = val.AsArray();
			if (Operators.CompareString(array[0].Value.ToString().ToUpper(), "Eletron".ToUpper(), TextCompare: true) == 0 && Operators.CompareString(array[1].Value.ToString().ToUpper(), "REL_FURNAS", TextCompare: true) == 0)
			{
				result = true;
			}
		}
		return result;
	}

	public static bool LerXDataFurnasIndice(ref Entity Ent)
	{
		bool result = false;
		bool flag = false;
		ResultBuffer val = null;
		val = ((DBObject)Ent).GetXDataForApplication("Eletron");
		if (val == null)
		{
			val = ((DBObject)Ent).GetXDataForApplication("Eletron".ToUpper());
			if (val != null)
			{
				flag = true;
			}
		}
		else
		{
			flag = true;
		}
		if (flag)
		{
			TypedValue[] array = val.AsArray();
			if (Operators.CompareString(array[0].Value.ToString().ToUpper(), "Eletron".ToUpper(), TextCompare: true) == 0 && Operators.CompareString(array[1].Value.ToString().ToUpper(), "REL_FURNAS", TextCompare: true) == 0 && Operators.ConditionalCompareObjectEqual(array[2].Value, 1, TextCompare: true))
			{
				result = true;
			}
		}
		return result;
	}

	public static void GravarXDataRevisaoMatricial(ref Entity Ent, string sPagina, int iIndice, string sRevisoes, string sTipo)
	{
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected Obj, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				RegAppTable val3 = (RegAppTable)val2.GetObject(database.RegAppTableId, (OpenMode)1);
				if (!((SymbolTable)val3).Has("Eletron"))
				{
					RegAppTableRecord val4 = new RegAppTableRecord();
					((SymbolTableRecord)val4).Name = "Eletron";
					((SymbolTable)val3).Add((SymbolTableRecord)(object)val4);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
				}
				TypedValue[] array = new TypedValue[9]
				{
					new TypedValue(1001, (object)"Eletron"),
					new TypedValue(1000, (object)"REVISAOMATRICIAL"),
					new TypedValue(1000, (object)sRevisoes),
					new TypedValue(1000, (object)sPagina),
					new TypedValue(1071, (object)iIndice),
					new TypedValue(1071, (object)0),
					new TypedValue(1071, (object)0),
					new TypedValue(1000, (object)sTipo),
					new TypedValue(1000, (object)"")
				};
				((DBObject)Ent).UpgradeOpen();
				((DBObject)Ent).XData = new ResultBuffer(array);
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				val2.Abort();
				throw;
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

	public static bool leXDataRevisaoMatricial(ref Entity Ent, ref string sRevisao, ref string sPagina, ref int iIndice, ref string sTipo)
	{
		bool flag = false;
		ResultBuffer val = null;
		val = ((DBObject)Ent).GetXDataForApplication("Eletron");
		if (val == null)
		{
			val = ((DBObject)Ent).GetXDataForApplication("Eletron".ToUpper());
			if (val != null)
			{
				flag = true;
			}
		}
		else
		{
			flag = true;
		}
		if (flag)
		{
			TypedValue[] array = val.AsArray();
			if (Operators.CompareString(array[0].Value.ToString().ToUpper(), "Eletron".ToUpper(), TextCompare: true) != 0)
			{
				flag = false;
			}
			else if (Operators.CompareString(array[1].Value.ToString().ToUpper(), "REVISAOMATRICIAL", TextCompare: true) != 0)
			{
				flag = false;
			}
			else
			{
				sRevisao = Conversions.ToString(array[2].Value);
				sPagina = Conversions.ToString(array[3].Value);
				iIndice = Conversions.ToInteger(array[4].Value);
				sTipo = Conversions.ToString(array[7].Value);
				flag = true;
			}
		}
		if (!Information.IsNothing(val))
		{
			((DisposableWrapper)val).Dispose();
		}
		return flag;
	}

	public static bool leXDataBuscaTamanhoColunasRevisaoMatricial(ref Entity Ent, ref Relatorios_Rev_Matricial.ConfigReV confRelRev)
	{
		bool flag = false;
		ResultBuffer val = null;
		val = ((DBObject)Ent).GetXDataForApplication("Eletron");
		if (val == null)
		{
			val = ((DBObject)Ent).GetXDataForApplication("Eletron".ToUpper());
			if (val != null)
			{
				flag = true;
			}
		}
		else
		{
			flag = true;
		}
		if (flag)
		{
			TypedValue[] array = val.AsArray();
			flag = Operators.CompareString(array[0].Value.ToString().ToUpper(), "Eletron".ToUpper(), TextCompare: true) == 0 && Operators.CompareString(array[1].Value.ToString().ToUpper(), "REVISAOMATRICIAL", TextCompare: true) == 0;
		}
		return flag;
	}

	public static void GravarXDataVeiasCopel(ref Entity Ent, string sRelatorio, int iINDICE)
	{
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Expected Obj, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				RegAppTable val3 = (RegAppTable)val2.GetObject(database.RegAppTableId, (OpenMode)1);
				if (!((SymbolTable)val3).Has("Eletron"))
				{
					RegAppTableRecord val4 = new RegAppTableRecord();
					((SymbolTableRecord)val4).Name = "Eletron";
					((SymbolTable)val3).Add((SymbolTableRecord)(object)val4);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
				}
				TypedValue[] array = new TypedValue[7]
				{
					new TypedValue(1001, (object)"Eletron"),
					new TypedValue(1000, (object)"VEIASCOPEL"),
					new TypedValue(1000, (object)sRelatorio),
					new TypedValue(1071, (object)iINDICE),
					new TypedValue(1071, (object)0),
					new TypedValue(1071, (object)0),
					new TypedValue(1000, (object)"")
				};
				((DBObject)Ent).UpgradeOpen();
				((DBObject)Ent).XData = new ResultBuffer(array);
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				val2.Abort();
				throw;
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

	public static bool LerXDataVeiasCopel(ref Entity Ent, ref string sRel, ref int iIndice)
	{
		bool flag = false;
		ResultBuffer val = null;
		val = ((DBObject)Ent).GetXDataForApplication("Eletron");
		if (val == null)
		{
			val = ((DBObject)Ent).GetXDataForApplication("Eletron".ToUpper());
			if (val != null)
			{
				flag = true;
			}
		}
		else
		{
			flag = true;
		}
		if (flag)
		{
			TypedValue[] array = val.AsArray();
			if (Operators.CompareString(array[0].Value.ToString().ToUpper(), "Eletron".ToUpper(), TextCompare: true) != 0)
			{
				flag = false;
			}
			else if (Operators.CompareString(array[1].Value.ToString().ToUpper(), "VEIASCOPEL", TextCompare: true) != 0)
			{
				flag = false;
			}
			else
			{
				sRel = Conversions.ToString(array[2].Value);
				iIndice = Conversions.ToInteger(array[3].Value);
				flag = true;
			}
		}
		return flag;
	}
}

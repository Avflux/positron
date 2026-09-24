using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;

namespace Eletron4;

public class XDataTopografico
{
	public static bool LerXDataConfiguracao(ref DeclaracoesTopografico.structureConfigTopografico ctpg)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Obj, but got Unknown
		bool flag = false;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
			BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
			ResultBuffer xDataForApplication = ((DBObject)val3).GetXDataForApplication("ConfigTopografico");
			if (xDataForApplication != null)
			{
				TypedValue[] array = xDataForApplication.AsArray();
				ctpg.delimitadorD = Conversions.ToString(array[2].Value);
				ctpg.delimitadorTT = Conversions.ToString(array[3].Value);
				ctpg.padrao = Conversions.ToInteger(array[5].Value);
				if (Information.UBound(array) <= 5)
				{
					ctpg.prefixoCruzado = "";
					ctpg.sufixoCruzado = "";
					ctpg.prefixoPonto = "";
					ctpg.sufixoPonto = "";
				}
				else
				{
					ctpg.prefixoCruzado = Conversions.ToString(array[6].Value);
					ctpg.sufixoCruzado = Conversions.ToString(array[7].Value);
					ctpg.prefixoPonto = Conversions.ToString(array[8].Value);
					ctpg.sufixoPonto = Conversions.ToString(array[9].Value);
				}
				flag = true;
			}
			else
			{
				ctpg.delimitadorD = "/";
				ctpg.delimitadorTT = ":";
				ctpg.padrao = 0;
				ctpg.prefixoCruzado = "";
				ctpg.sufixoCruzado = "";
				ctpg.prefixoPonto = "";
				ctpg.sufixoPonto = "";
				flag = false;
			}
			val.Commit();
			return flag;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			val.Abort();
			throw;
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void GravarXDataConfiguracao(DeclaracoesTopografico.structureConfigTopografico ctpg)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected Obj, but got Unknown
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Expected Obj, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected Obj, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				RegAppTable val5 = (RegAppTable)val2.GetObject(database.RegAppTableId, (OpenMode)1);
				if (!((SymbolTable)val5).Has("ConfigTopografico"))
				{
					RegAppTableRecord val6 = new RegAppTableRecord();
					((SymbolTableRecord)val6).Name = "ConfigTopografico";
					((SymbolTable)val5).Add((SymbolTableRecord)(object)val6);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val6, true);
				}
				((DBObject)val4).XData = new ResultBuffer(new TypedValue[10]
				{
					new TypedValue(1001, (object)"ConfigTopografico"),
					new TypedValue(1000, (object)" "),
					new TypedValue(1000, (object)ctpg.delimitadorD),
					new TypedValue(1000, (object)ctpg.delimitadorTT),
					new TypedValue(1000, (object)""),
					new TypedValue(1070, (object)ctpg.padrao),
					new TypedValue(1000, (object)ctpg.prefixoCruzado),
					new TypedValue(1000, (object)ctpg.sufixoCruzado),
					new TypedValue(1000, (object)ctpg.prefixoPonto),
					new TypedValue(1000, (object)ctpg.sufixoPonto)
				});
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
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

	public static void GravarXDataDispTopografico(ref BlockReference blockRef, DeclaracoesTopografico.structureDispTopografico dTpg)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			RegAppTable val = (RegAppTable)topTransaction.GetObject(database.RegAppTableId, (OpenMode)1);
			if (!((SymbolTable)val).Has("TOPOGRAFICO"))
			{
				RegAppTableRecord val2 = new RegAppTableRecord();
				((SymbolTableRecord)val2).Name = "TOPOGRAFICO";
				((SymbolTable)val).Add((SymbolTableRecord)(object)val2);
				DeclaracoesGeral.bAnularEventos = true;
				topTransaction.AddNewlyCreatedDBObject((DBObject)(object)val2, true);
			}
			TypedValue[] array = new TypedValue[13]
			{
				new TypedValue(1001, (object)"TOPOGRAFICO"),
				new TypedValue(1000, (object)"DISP"),
				new TypedValue(1000, (object)""),
				new TypedValue(1000, (object)dTpg.painel.ToString()),
				new TypedValue(1000, (object)dTpg.tag),
				new TypedValue(1000, (object)dTpg.alternativo),
				new TypedValue(1000, (object)""),
				new TypedValue(1000, (object)""),
				new TypedValue(1000, (object)""),
				new TypedValue(1000, (object)""),
				new TypedValue(1000, (object)""),
				new TypedValue(1070, (object)0),
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

	public static bool lerXDataDispTopografico(ref BlockReference blockRef, ref DeclaracoesTopografico.structureDispTopografico dTpg)
	{
		bool result = false;
		ResultBuffer xDataForApplication = ((DBObject)blockRef).GetXDataForApplication("TOPOGRAFICO");
		if (xDataForApplication != null)
		{
			TypedValue[] array = xDataForApplication.AsArray();
			if (Operators.ConditionalCompareObjectEqual(array[1].Value, "DISP", TextCompare: true))
			{
				dTpg.painel = Conversions.ToInteger(array[3].Value);
				dTpg.tag = Conversions.ToString(array[4].Value);
				dTpg.alternativo = Conversions.ToString(array[5].Value);
				result = true;
			}
		}
		return result;
	}

	public static void GravarXDataBorneTopografico(ref BlockReference blockRef, DeclaracoesTopografico.structureBorneTopografico bTpg)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			RegAppTable val = (RegAppTable)topTransaction.GetObject(database.RegAppTableId, (OpenMode)1);
			if (!((SymbolTable)val).Has("TOPOGRAFICO"))
			{
				RegAppTableRecord val2 = new RegAppTableRecord();
				((SymbolTableRecord)val2).Name = "TOPOGRAFICO";
				((SymbolTable)val).Add((SymbolTableRecord)(object)val2);
				DeclaracoesGeral.bAnularEventos = true;
				topTransaction.AddNewlyCreatedDBObject((DBObject)(object)val2, true);
			}
			TypedValue[] array = new TypedValue[13]
			{
				new TypedValue(1001, (object)"TOPOGRAFICO"),
				new TypedValue(1000, (object)"BORNE"),
				new TypedValue(1000, (object)""),
				new TypedValue(1000, (object)bTpg.painel.ToString()),
				new TypedValue(1000, (object)bTpg.regua),
				new TypedValue(1000, (object)bTpg.borne),
				new TypedValue(1000, (object)""),
				new TypedValue(1000, (object)bTpg.posEntrada),
				new TypedValue(1000, (object)bTpg.tipoBorne.ToString()),
				new TypedValue(1000, (object)""),
				new TypedValue(1000, (object)""),
				new TypedValue(1070, (object)0),
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

	public static bool lerXDataBorneTopografico(ref BlockReference blockRef, ref DeclaracoesTopografico.structureBorneTopografico bTpg)
	{
		bool result = false;
		ResultBuffer xDataForApplication = ((DBObject)blockRef).GetXDataForApplication("TOPOGRAFICO");
		if (xDataForApplication != null)
		{
			TypedValue[] array = xDataForApplication.AsArray();
			if (Operators.ConditionalCompareObjectEqual(array[1].Value, "BORNE", TextCompare: true))
			{
				bTpg.painel = Conversions.ToInteger(array[3].Value);
				bTpg.regua = Conversions.ToString(array[4].Value);
				bTpg.borne = Conversions.ToString(array[5].Value);
				bTpg.posEntrada = Conversions.ToString(array[7].Value);
				bTpg.tipoBorne = Conversions.ToInteger(array[8].Value);
				result = true;
			}
		}
		return result;
	}

	public static void GravarXDataLinkTopografico(ref BlockReference blockRef, string handle)
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
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			RegAppTable val = (RegAppTable)topTransaction.GetObject(database.RegAppTableId, (OpenMode)1);
			if (!((SymbolTable)val).Has("TOPOGRAFICO"))
			{
				RegAppTableRecord val2 = new RegAppTableRecord();
				((SymbolTableRecord)val2).Name = "TOPOGRAFICO";
				((SymbolTable)val).Add((SymbolTableRecord)(object)val2);
				DeclaracoesGeral.bAnularEventos = true;
				topTransaction.AddNewlyCreatedDBObject((DBObject)(object)val2, true);
			}
			TypedValue[] array = new TypedValue[3]
			{
				new TypedValue(1001, (object)"TOPOGRAFICO"),
				new TypedValue(1000, (object)"JUMPER"),
				new TypedValue(1000, (object)handle)
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

	public static bool lerXDataLinkTopografico(ref BlockReference blockRef, ref string handle)
	{
		bool result = false;
		ResultBuffer xDataForApplication = ((DBObject)blockRef).GetXDataForApplication("TOPOGRAFICO");
		if (xDataForApplication != null)
		{
			TypedValue[] array = xDataForApplication.AsArray();
			if (Operators.ConditionalCompareObjectEqual(array[1].Value, "JUMPER", TextCompare: true))
			{
				handle = Conversions.ToString(array[2].Value);
				result = true;
			}
		}
		return result;
	}

	public static bool lerXDataAtributoTopografico(ref AttributeReference attRef, ref DeclaracoesTopografico.structureTermBlocoTopografico term)
	{
		bool result = false;
		ResultBuffer xDataForApplication = ((DBObject)attRef).GetXDataForApplication("Construtor");
		if (xDataForApplication != null)
		{
			TypedValue[] array = xDataForApplication.AsArray();
			if (Operators.ConditionalCompareObjectEqual(array[1].Value, 0, TextCompare: true))
			{
				term.terminal = ((DBText)attRef).TextString;
				term.orientacao = Conversions.ToString(array[2].Value);
				term.X = Conversions.ToDouble(array[3].Value);
				term.Y = Conversions.ToDouble(array[4].Value);
				result = true;
			}
		}
		return result;
	}

	public static void GravarXDataTermTopografico(ref BlockReference blockRef, string tipo, string handle, string tag, string alternativo, string terminal, string rotacao, DeclaracoesTopografico.structureTerminalTopog[] mLigTerm)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		//IL_034f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0354: Unknown result type (might be due to invalid IL or missing references)
		//IL_036f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0374: Unknown result type (might be due to invalid IL or missing references)
		//IL_038f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0394: Unknown result type (might be due to invalid IL or missing references)
		//IL_03af: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0407: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			RegAppTable val = (RegAppTable)topTransaction.GetObject(database.RegAppTableId, (OpenMode)1);
			if (!((SymbolTable)val).Has("TOPOGRAFICO"))
			{
				RegAppTableRecord val2 = new RegAppTableRecord();
				((SymbolTableRecord)val2).Name = "TOPOGRAFICO";
				((SymbolTable)val).Add((SymbolTableRecord)(object)val2);
				DeclaracoesGeral.bAnularEventos = true;
				topTransaction.AddNewlyCreatedDBObject((DBObject)(object)val2, true);
			}
			TypedValue[] array = new TypedValue[31]
			{
				new TypedValue(1001, (object)"TOPOGRAFICO"),
				new TypedValue(1000, (object)tipo),
				new TypedValue(1000, (object)handle),
				new TypedValue(1000, (object)tag),
				new TypedValue(1000, (object)alternativo),
				new TypedValue(1000, (object)terminal),
				new TypedValue(1000, (object)rotacao),
				new TypedValue(1000, (object)mLigTerm[1].Tag),
				new TypedValue(1000, (object)mLigTerm[1].Alternativo),
				new TypedValue(1000, (object)mLigTerm[1].Term),
				new TypedValue(1000, (object)mLigTerm[1].Secao),
				new TypedValue(1000, (object)mLigTerm[1].Cor),
				new TypedValue(1000, (object)mLigTerm[1].Anilha),
				new TypedValue(1000, (object)mLigTerm[2].Tag),
				new TypedValue(1000, (object)mLigTerm[2].Alternativo),
				new TypedValue(1000, (object)mLigTerm[2].Term),
				new TypedValue(1000, (object)mLigTerm[2].Secao),
				new TypedValue(1000, (object)mLigTerm[2].Cor),
				new TypedValue(1000, (object)mLigTerm[2].Anilha),
				new TypedValue(1000, (object)mLigTerm[3].Tag),
				new TypedValue(1000, (object)mLigTerm[3].Alternativo),
				new TypedValue(1000, (object)mLigTerm[3].Term),
				new TypedValue(1000, (object)mLigTerm[3].Secao),
				new TypedValue(1000, (object)mLigTerm[3].Cor),
				new TypedValue(1000, (object)mLigTerm[3].Anilha),
				new TypedValue(1000, (object)mLigTerm[4].Tag),
				new TypedValue(1000, (object)mLigTerm[4].Alternativo),
				new TypedValue(1000, (object)mLigTerm[4].Term),
				new TypedValue(1000, (object)mLigTerm[4].Secao),
				new TypedValue(1000, (object)mLigTerm[4].Cor),
				new TypedValue(1000, (object)mLigTerm[4].Anilha)
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

	public static bool LerXDataTermTopografico(ref BlockReference attRef, ref string tipo, ref string handle, ref string tag, ref string alternativo, ref string terminal, ref string rotacao, ref DeclaracoesTopografico.structureTerminalTopog[] mLigTerm)
	{
		bool result = false;
		ResultBuffer xDataForApplication = ((DBObject)attRef).GetXDataForApplication("TOPOGRAFICO");
		if (xDataForApplication != null)
		{
			TypedValue[] array = xDataForApplication.AsArray();
			if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(array[1].Value, "FD", TextCompare: true), Operators.CompareObjectEqual(array[1].Value, "FB", TextCompare: true))))
			{
				tipo = Conversions.ToString(array[1].Value);
				handle = Conversions.ToString(array[2].Value);
				tag = Conversions.ToString(array[3].Value);
				alternativo = Conversions.ToString(array[4].Value);
				terminal = Conversions.ToString(array[5].Value);
				rotacao = Conversions.ToString(array[6].Value);
				mLigTerm[1].Tag = Conversions.ToString(array[7].Value);
				mLigTerm[1].Alternativo = Conversions.ToString(array[8].Value);
				mLigTerm[1].Term = Conversions.ToString(array[9].Value);
				mLigTerm[1].Secao = Conversions.ToString(array[10].Value);
				mLigTerm[1].Cor = Conversions.ToString(array[11].Value);
				mLigTerm[1].Anilha = Conversions.ToString(array[12].Value);
				mLigTerm[2].Tag = Conversions.ToString(array[13].Value);
				mLigTerm[2].Alternativo = Conversions.ToString(array[14].Value);
				mLigTerm[2].Term = Conversions.ToString(array[15].Value);
				mLigTerm[2].Secao = Conversions.ToString(array[16].Value);
				mLigTerm[2].Cor = Conversions.ToString(array[17].Value);
				mLigTerm[2].Anilha = Conversions.ToString(array[18].Value);
				mLigTerm[3].Tag = Conversions.ToString(array[19].Value);
				mLigTerm[3].Alternativo = Conversions.ToString(array[20].Value);
				mLigTerm[3].Term = Conversions.ToString(array[21].Value);
				mLigTerm[3].Secao = Conversions.ToString(array[22].Value);
				mLigTerm[3].Cor = Conversions.ToString(array[23].Value);
				mLigTerm[3].Anilha = Conversions.ToString(array[24].Value);
				mLigTerm[4].Tag = Conversions.ToString(array[25].Value);
				mLigTerm[4].Alternativo = Conversions.ToString(array[26].Value);
				mLigTerm[4].Term = Conversions.ToString(array[27].Value);
				mLigTerm[4].Secao = Conversions.ToString(array[28].Value);
				mLigTerm[4].Cor = Conversions.ToString(array[29].Value);
				mLigTerm[4].Anilha = Conversions.ToString(array[30].Value);
				result = true;
			}
		}
		return result;
	}

	public static bool LerXDataHandleTermTopografico(ref BlockReference attRef, ref string handle)
	{
		bool result = false;
		ResultBuffer xDataForApplication = ((DBObject)attRef).GetXDataForApplication("TOPOGRAFICO");
		if (xDataForApplication != null)
		{
			TypedValue[] array = xDataForApplication.AsArray();
			if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(array[1].Value, "FD", TextCompare: true), Operators.CompareObjectEqual(array[1].Value, "FB", TextCompare: true))))
			{
				handle = Conversions.ToString(array[2].Value);
				result = true;
			}
		}
		return result;
	}
}

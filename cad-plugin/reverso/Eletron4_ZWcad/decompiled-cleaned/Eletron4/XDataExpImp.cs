using System;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;

namespace Eletron4;

public class XDataExpImp
{
	public static int codigoExportacao()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected Obj, but got Unknown
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected Obj, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected Obj, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected Obj, but got Unknown
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected Obj, but got Unknown
		int num = 0;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				ResultBuffer xDataForApplication = ((DBObject)val4).GetXDataForApplication("CODEXPORT");
				if (xDataForApplication != null)
				{
					TypedValue[] array = xDataForApplication.AsArray();
					num = Conversions.ToInteger(array[1].Value);
					num = checked(num + 1);
					array[0] = new TypedValue(1001, (object)"CODEXPORT");
					array[1] = new TypedValue(1071, (object)num);
					((DBObject)val4).XData = new ResultBuffer(array);
				}
				else
				{
					RegAppTable val5 = (RegAppTable)val2.GetObject(database.RegAppTableId, (OpenMode)1);
					if (!((SymbolTable)val5).Has("CODEXPORT"))
					{
						RegAppTableRecord val6 = new RegAppTableRecord();
						((SymbolTableRecord)val6).Name = "CODEXPORT";
						((SymbolTable)val5).Add((SymbolTableRecord)(object)val6);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)val6, true);
					}
					num = 1;
					((DBObject)val4).XData = new ResultBuffer(new TypedValue[2]
					{
						new TypedValue(1001, (object)"CODEXPORT"),
						new TypedValue(1071, (object)1)
					});
				}
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
		return num;
	}

	public static void GravarXDataExportado(ref Entity ent, ref DeclaracoesEntidades.StructureExportar exp)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			RegAppTable val2 = (RegAppTable)val.GetObject(database.RegAppTableId, (OpenMode)1);
			if (!((SymbolTable)val2).Has("EXPORTADO"))
			{
				RegAppTableRecord val3 = new RegAppTableRecord();
				((SymbolTableRecord)val3).Name = "EXPORTADO";
				((SymbolTable)val2).Add((SymbolTableRecord)(object)val3);
				DeclaracoesGeral.bAnularEventos = true;
				val.AddNewlyCreatedDBObject((DBObject)(object)val3, true);
			}
			TypedValue[] array = new TypedValue[8]
			{
				new TypedValue(1001, (object)"EXPORTADO"),
				new TypedValue(1071, (object)exp.indice),
				new TypedValue(1071, (object)exp.Codigo),
				new TypedValue(1000, (object)exp.Handle),
				new TypedValue(1000, (object)exp.Tipo),
				new TypedValue(1000, (object)exp.DWG.ToString()),
				new TypedValue(1000, (object)""),
				new TypedValue(1000, (object)"")
			};
			((DBObject)ent).XData = new ResultBuffer(array);
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

	public static bool LerXDataExportado(ref Entity ent, ref DeclaracoesEntidades.StructureExportar exp)
	{
		bool result = false;
		ResultBuffer xDataForApplication = ((DBObject)ent).GetXDataForApplication("EXPORTADO");
		if (xDataForApplication != null)
		{
			TypedValue[] array = xDataForApplication.AsArray();
			exp.indice = Conversions.ToInteger(array[1].Value);
			exp.Codigo = Conversions.ToInteger(array[2].Value);
			exp.Handle = Conversions.ToString(array[3].Value);
			exp.Tipo = Conversions.ToString(array[4].Value);
			exp.DWG = Conversions.ToInteger(array[5].Value);
			result = true;
		}
		return result;
	}

	public static bool PossuiXDataExportado(ref Entity ent)
	{
		bool result = false;
		ResultBuffer xDataForApplication = ((DBObject)ent).GetXDataForApplication("EXPORTADO");
		if (xDataForApplication != null)
		{
			result = true;
		}
		return result;
	}

	public static void ApagarXDataExportado(ref Entity ent)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			_ = (RegAppTable)topTransaction.GetObject(database.RegAppTableId, (OpenMode)1);
			TypedValue[] array = new TypedValue[1]
			{
				new TypedValue(1001, (object)"EXPORTADO")
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

	public static void GravarXDataImportado(ref Entity ent, ref DeclaracoesEntidades.StructureExportar exp)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			RegAppTable val = (RegAppTable)topTransaction.GetObject(database.RegAppTableId, (OpenMode)1);
			if (!((SymbolTable)val).Has("IMPORTADO"))
			{
				RegAppTableRecord val2 = new RegAppTableRecord();
				((SymbolTableRecord)val2).Name = "IMPORTADO";
				((SymbolTable)val).Add((SymbolTableRecord)(object)val2);
				DeclaracoesGeral.bAnularEventos = true;
				topTransaction.AddNewlyCreatedDBObject((DBObject)(object)val2, true);
			}
			TypedValue[] array = new TypedValue[16]
			{
				new TypedValue(1001, (object)"IMPORTADO"),
				new TypedValue(1071, (object)exp.indice),
				new TypedValue(1071, (object)exp.Codigo),
				new TypedValue(1000, (object)exp.Tipo),
				new TypedValue(1000, (object)exp.DWG.ToString()),
				new TypedValue(1000, (object)clsTextos.TiraNothing(exp.Caderno)),
				new TypedValue(1000, (object)clsTextos.TiraNothing(exp.Handle)),
				new TypedValue(1000, (object)clsTextos.TiraNothing(exp.Pagina)),
				new TypedValue(1000, (object)clsTextos.TiraNothing(exp.posicao)),
				new TypedValue(1070, (object)exp.Painel),
				new TypedValue(1070, (object)0),
				new TypedValue(1000, (object)exp.DWGDest.ToString()),
				new TypedValue(1000, (object)clsTextos.TiraNothing(exp.NomeRegua)),
				new TypedValue(1071, (object)exp.indexModelo),
				new TypedValue(1000, (object)Environment.UserName),
				new TypedValue(1000, (object)DateTime.Now.ToString())
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

	public static bool LerXDataImportado(ref Entity ent, ref DeclaracoesEntidades.StructureExportar exp)
	{
		bool result = false;
		ResultBuffer xDataForApplication = ((DBObject)ent).GetXDataForApplication("IMPORTADO");
		if (xDataForApplication != null)
		{
			TypedValue[] array = xDataForApplication.AsArray();
			exp.indice = Conversions.ToInteger(array[1].Value);
			exp.Codigo = Conversions.ToInteger(array[2].Value);
			exp.Tipo = Conversions.ToString(array[3].Value);
			exp.DWG = Conversions.ToInteger(array[4].Value);
			exp.Caderno = Conversions.ToString(array[5].Value);
			exp.Handle = Conversions.ToString(array[6].Value);
			exp.Pagina = Conversions.ToString(array[7].Value);
			exp.posicao = Conversions.ToString(array[8].Value);
			exp.Painel = Conversions.ToInteger(array[9].Value);
			exp.DWGDest = Conversions.ToInteger(array[11].Value);
			exp.NomeRegua = Conversions.ToString(array[12].Value);
			exp.indexModelo = Conversions.ToInteger(array[13].Value);
			result = true;
		}
		return result;
	}

	public static bool PossuiXDataImportado(ref Entity ent)
	{
		bool result = false;
		ResultBuffer xDataForApplication = ((DBObject)ent).GetXDataForApplication("IMPORTADO");
		if (xDataForApplication != null)
		{
			result = true;
		}
		return result;
	}

	public static void GravarXDataAuxImportado(ref Entity ent, string handle, int tipo)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			RegAppTable val = (RegAppTable)topTransaction.GetObject(database.RegAppTableId, (OpenMode)1);
			if (!((SymbolTable)val).Has("AUXIMPORTADO"))
			{
				RegAppTableRecord val2 = new RegAppTableRecord();
				((SymbolTableRecord)val2).Name = "AUXIMPORTADO";
				((SymbolTable)val).Add((SymbolTableRecord)(object)val2);
				DeclaracoesGeral.bAnularEventos = true;
				topTransaction.AddNewlyCreatedDBObject((DBObject)(object)val2, true);
			}
			TypedValue[] array = new TypedValue[3]
			{
				new TypedValue(1001, (object)"AUXIMPORTADO"),
				new TypedValue(1000, (object)handle),
				new TypedValue(1070, (object)tipo)
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

	public static bool LerXDataAuxiliarImportado(ref Entity ent, ref string handle, ref int tipo)
	{
		bool result = false;
		ResultBuffer xDataForApplication = ((DBObject)ent).GetXDataForApplication("AUXIMPORTADO");
		if (xDataForApplication != null)
		{
			TypedValue[] array = xDataForApplication.AsArray();
			handle = Conversions.ToString(array[1].Value);
			tipo = Conversions.ToInteger(array[2].Value);
			result = true;
		}
		return result;
	}

	public static bool PossuiXDataAuxiliarImportado(ref Entity ent)
	{
		bool result = false;
		ResultBuffer xDataForApplication = ((DBObject)ent).GetXDataForApplication("AUXIMPORTADO");
		if (xDataForApplication != null)
		{
			result = true;
		}
		return result;
	}

	public static void GravarXDataAuxExportado(ref Entity ent, int Indice, int tipo)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			RegAppTable val = (RegAppTable)topTransaction.GetObject(database.RegAppTableId, (OpenMode)1);
			if (!((SymbolTable)val).Has("AUXEXPORTADO"))
			{
				RegAppTableRecord val2 = new RegAppTableRecord();
				((SymbolTableRecord)val2).Name = "AUXEXPORTADO";
				((SymbolTable)val).Add((SymbolTableRecord)(object)val2);
				DeclaracoesGeral.bAnularEventos = true;
				topTransaction.AddNewlyCreatedDBObject((DBObject)(object)val2, true);
			}
			TypedValue[] array = new TypedValue[3]
			{
				new TypedValue(1001, (object)"AUXEXPORTADO"),
				new TypedValue(1071, (object)Indice),
				new TypedValue(1070, (object)tipo)
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

	public static bool LerXDataAuxiliarExportado(ref Entity ent, ref int indice, ref int tipo)
	{
		bool result = false;
		ResultBuffer xDataForApplication = ((DBObject)ent).GetXDataForApplication("AUXEXPORTADO");
		if (xDataForApplication != null)
		{
			TypedValue[] array = xDataForApplication.AsArray();
			indice = Conversions.ToInteger(array[1].Value);
			tipo = Conversions.ToInteger(array[2].Value);
			result = true;
		}
		return result;
	}

	public static bool PossuiXDataAuxiliarExportado(ref Entity ent)
	{
		bool result = false;
		ResultBuffer xDataForApplication = ((DBObject)ent).GetXDataForApplication("AUXEXPORTADO");
		if (xDataForApplication != null)
		{
			result = true;
		}
		return result;
	}
}

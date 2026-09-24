using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Runtime;

namespace Eletron4;

public class DicionarioPlaqueta
{
	public static void gravaDicPlaqueta(string nomeXrec, ref Declaracoes2.StructurePlaquetas[] mPlaquetas)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected Obj, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Expected Obj, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected Obj, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected Obj, but got Unknown
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected Obj, but got Unknown
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected Obj, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					DBDictionary val3 = (DBDictionary)val2.GetObject(database.NamedObjectsDictionaryId, (OpenMode)1, false);
					DBDictionary val4;
					if (!val3.Contains("CENG_PLAQUETA"))
					{
						val4 = new DBDictionary();
						val3.SetAt("CENG_PLAQUETA", (DBObject)(object)val4);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
					}
					else
					{
						val4 = (DBDictionary)val2.GetObject(val3.GetAt("CENG_PLAQUETA"), (OpenMode)1);
					}
					Xrecord val5;
					if (!val4.Contains(nomeXrec))
					{
						TypedValue[] array = new TypedValue[1];
						ResultBuffer data = new ResultBuffer(array);
						val5 = new Xrecord();
						val5.Data = data;
						val4.SetAt(nomeXrec, (DBObject)(object)val5);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)val5, true);
					}
					else
					{
						ObjectId at = val4.GetAt(nomeXrec);
						val5 = (Xrecord)val2.GetObject(at, (OpenMode)1);
					}
					int num = mPlaquetas.GetUpperBound(0) + 1;
					TypedValue[] array2 = new TypedValue[7 * num - 1 + 1];
					int num2 = 0;
					int num3 = 7 * num - 1;
					for (int i = 0; i <= num3; i += 7)
					{
						array2[i] = new TypedValue(1, (object)mPlaquetas[num2].Tipo);
						array2[i + 1] = new TypedValue(1, (object)mPlaquetas[num2].Handle);
						array2[i + 2] = new TypedValue(70, (object)mPlaquetas[num2].IndiceRegua);
						array2[i + 3] = new TypedValue(1, (object)mPlaquetas[num2].Desc1);
						array2[i + 4] = new TypedValue(1, (object)mPlaquetas[num2].Desc2);
						array2[i + 5] = new TypedValue(1, (object)mPlaquetas[num2].Desc3);
						array2[i + 6] = new TypedValue(1, (object)mPlaquetas[num2].Modelo);
						num2++;
					}
					ResultBuffer data2 = new ResultBuffer(array2);
					val5.Data = data2;
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
					if (!Information.IsNothing(val4))
					{
						((DisposableWrapper)val4).Dispose();
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
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
	}

	public static bool ExisteDicPlaquetaPainel(string pn)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected Obj, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected Obj, but got Unknown
		bool result = false;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			DBDictionary val2 = (DBDictionary)val.GetObject(database.NamedObjectsDictionaryId, (OpenMode)0, false);
			DBDictionary val3;
			if (!val2.Contains("CENG_PLAQUETA"))
			{
				val3 = null;
				result = false;
			}
			else
			{
				val3 = (DBDictionary)val.GetObject(val2.GetAt("CENG_PLAQUETA"), (OpenMode)0);
				result = (val3.Contains(pn) ? true : false);
			}
			DeclaracoesGeral.bAnularEventos = true;
			val.Commit();
			DeclaracoesGeral.bAnularEventos = false;
			if (!Information.IsNothing(val3))
			{
				((DisposableWrapper)val3).Dispose();
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			val.Abort();
			ProjectData.ClearProjectError();
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		return result;
	}

	public static void ApagaDicPlaquetasPainel(string pn)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected Obj, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected Obj, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				DBDictionary val3 = (DBDictionary)val2.GetObject(database.NamedObjectsDictionaryId, (OpenMode)0, false);
				DBDictionary val4;
				if (!val3.Contains("CENG_PLAQUETA"))
				{
					val4 = null;
				}
				else
				{
					val4 = (DBDictionary)val2.GetObject(val3.GetAt("CENG_PLAQUETA"), (OpenMode)0);
					if (val4.Contains(pn))
					{
						ObjectId at = val4.GetAt(pn);
						Xrecord val5 = (Xrecord)val2.GetObject(at, (OpenMode)1);
						((DBObject)val5).Erase();
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				if (!Information.IsNothing(val4))
				{
					((DisposableWrapper)val4).Dispose();
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
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

	public static bool LeDicPlaquetas(string nomeXrec, ref Declaracoes2.StructurePlaquetas[] mPlaquetas)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected Obj, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected Obj, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected Obj, but got Unknown
		bool result = false;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				DBDictionary val2 = (DBDictionary)val.GetObject(database.NamedObjectsDictionaryId, (OpenMode)0, false);
				DBDictionary val3;
				if (!val2.Contains("CENG_PLAQUETA"))
				{
					val3 = null;
				}
				else
				{
					val3 = (DBDictionary)val.GetObject(val2.GetAt("CENG_PLAQUETA"), (OpenMode)0);
					if (val3.Contains(nomeXrec))
					{
						ObjectId at = val3.GetAt(nomeXrec);
						Xrecord val4 = (Xrecord)val.GetObject(at, (OpenMode)0);
						ResultBuffer data = val4.Data;
						TypedValue[] array = data.AsArray();
						int num = (int)Math.Round((double)(array.GetUpperBound(0) + 1) / 7.0);
						mPlaquetas = new Declaracoes2.StructurePlaquetas[num - 1 + 1];
						int num2 = 0;
						int num3 = Information.UBound(array) - 1;
						for (int i = 0; i <= num3; i += 7)
						{
							mPlaquetas[num2].Nome = "";
							mPlaquetas[num2].Tipo = Conversions.ToString(array[i].Value);
							mPlaquetas[num2].Handle = Conversions.ToString(array[i + 1].Value);
							mPlaquetas[num2].IndiceRegua = Conversions.ToInteger(array[i + 2].Value);
							mPlaquetas[num2].Desc1 = Conversions.ToString(array[i + 3].Value);
							mPlaquetas[num2].Desc2 = Conversions.ToString(array[i + 4].Value);
							mPlaquetas[num2].Desc3 = Conversions.ToString(array[i + 5].Value);
							mPlaquetas[num2].Modelo = Conversions.ToString(array[i + 6].Value);
							num2++;
						}
						result = true;
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				if (!Information.IsNothing(val3))
				{
					((DisposableWrapper)val3).Dispose();
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				val.Abort();
				ProjectData.ClearProjectError();
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			return result;
		}
	}
}

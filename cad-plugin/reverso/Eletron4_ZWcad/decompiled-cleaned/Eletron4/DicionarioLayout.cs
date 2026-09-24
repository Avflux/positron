using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Runtime;

namespace Eletron4;

public class DicionarioLayout
{
	public static void gravaDicLayout(string nomeXrec, ref DeclaracoesEntidades.StructureLayout[] mTags)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected Obj, but got Unknown
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Expected Obj, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected Obj, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Expected Obj, but got Unknown
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
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected Obj, but got Unknown
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
					if (!val3.Contains("CENG_LAYOUT"))
					{
						val4 = new DBDictionary();
						val3.SetAt("CENG_LAYOUT", (DBObject)(object)val4);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
					}
					else
					{
						val4 = (DBDictionary)val2.GetObject(val3.GetAt("CENG_LAYOUT"), (OpenMode)1);
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
					int num = mTags.GetUpperBound(0) + 1;
					TypedValue[] array2 = new TypedValue[5 * num - 1 + 1];
					int num2 = 0;
					int num3 = 5 * num - 1;
					for (int i = 0; i <= num3; i += 5)
					{
						array2[i] = new TypedValue(1, (object)mTags[num2].Tag);
						array2[i + 1] = new TypedValue(1, (object)mTags[num2].Alternativo);
						array2[i + 2] = new TypedValue(40, (object)mTags[num2].X);
						array2[i + 3] = new TypedValue(40, (object)mTags[num2].Y);
						array2[i + 4] = new TypedValue(1, (object)"");
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

	public static bool ExisteDicLayout()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected Obj, but got Unknown
		bool result = false;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			DBDictionary val2 = (DBDictionary)val.GetObject(database.NamedObjectsDictionaryId, (OpenMode)0, false);
			if (val2.Contains("CENG_LAYOUT"))
			{
				result = true;
			}
			DeclaracoesGeral.bAnularEventos = true;
			val.Commit();
			DeclaracoesGeral.bAnularEventos = false;
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

	public static bool ExisteDicLayoutPainel(string pn)
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
			if (!val2.Contains("CENG_LAYOUT"))
			{
				val3 = null;
				result = false;
			}
			else
			{
				val3 = (DBDictionary)val.GetObject(val2.GetAt("CENG_LAYOUT"), (OpenMode)0);
				result = !(!val3.Contains("P" + pn) & !val3.Contains("C" + pn));
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

	public static bool ExisteDicLayoutPainelTipo(string pn, string tipo)
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
			if (!val2.Contains("CENG_LAYOUT"))
			{
				val3 = null;
				result = false;
			}
			else
			{
				val3 = (DBDictionary)val.GetObject(val2.GetAt("CENG_LAYOUT"), (OpenMode)0);
				result = (val3.Contains(tipo.ToUpper() + pn) ? true : false);
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

	public static void ApagaDicLayoutPainel(string pos, string pn)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected Obj, but got Unknown
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected Obj, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected Obj, but got Unknown
		string text = pos + pn;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				DBDictionary val3 = (DBDictionary)val2.GetObject(database.NamedObjectsDictionaryId, (OpenMode)0, false);
				DBDictionary val4;
				if (!val3.Contains("CENG_LAYOUT"))
				{
					val4 = null;
				}
				else
				{
					val4 = (DBDictionary)val2.GetObject(val3.GetAt("CENG_LAYOUT"), (OpenMode)0);
					if (val4.Contains(text))
					{
						ObjectId at = val4.GetAt(text);
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

	public static bool LeDicLayout(string nomeXrec, ref DeclaracoesEntidades.StructureLayout[] mTags)
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
				if (!val2.Contains("CENG_LAYOUT"))
				{
					val3 = null;
				}
				else
				{
					val3 = (DBDictionary)val.GetObject(val2.GetAt("CENG_LAYOUT"), (OpenMode)0);
					if (val3.Contains(nomeXrec))
					{
						ObjectId at = val3.GetAt(nomeXrec);
						Xrecord val4 = (Xrecord)val.GetObject(at, (OpenMode)0);
						ResultBuffer data = val4.Data;
						TypedValue[] array = data.AsArray();
						int num = (int)Math.Round((double)(array.GetUpperBound(0) + 1) / 5.0);
						mTags = new DeclaracoesEntidades.StructureLayout[num - 1 + 1];
						int num2 = 0;
						int num3 = Information.UBound(array) - 1;
						for (int i = 0; i <= num3; i += 5)
						{
							mTags[num2].Tag = Conversions.ToString(array[i].Value);
							mTags[num2].Alternativo = Conversions.ToString(array[i + 1].Value);
							mTags[num2].X = Conversions.ToDouble(array[i + 2].Value);
							mTags[num2].Y = Conversions.ToDouble(array[i + 3].Value);
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

	public static void buscaDicLayoutPainel(string pos, int painel, ref DeclaracoesFiacao.structurePosicaoDisp[] mPosicao)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected Obj, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected Obj, but got Unknown
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected Obj, but got Unknown
		string text = pos + painel;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				DBDictionary val2 = (DBDictionary)val.GetObject(database.NamedObjectsDictionaryId, (OpenMode)0, false);
				DBDictionary val3;
				if (!val2.Contains("CENG_LAYOUT"))
				{
					val3 = null;
				}
				else
				{
					val3 = (DBDictionary)val.GetObject(val2.GetAt("CENG_LAYOUT"), (OpenMode)0);
					if (val3.Contains(text))
					{
						ObjectId at = val3.GetAt(text);
						Xrecord val4 = (Xrecord)val.GetObject(at, (OpenMode)0);
						ResultBuffer data = val4.Data;
						TypedValue[] array = data.AsArray();
						int posicaoNum = 0;
						if (Operators.CompareString(pos, "P", TextCompare: true) != 0)
						{
							if (Operators.CompareString(pos, "C", TextCompare: true) != 0)
							{
								if (Operators.CompareString(pos, "X", TextCompare: true) == 0)
								{
									posicaoNum = 3;
								}
							}
							else
							{
								posicaoNum = 2;
							}
						}
						else
						{
							posicaoNum = 3;
						}
						int num = 0;
						int num2 = Information.UBound(array) - 1;
						for (int i = 0; i <= num2; i += 5)
						{
							if (Operators.CompareString(pos, "X", TextCompare: true) == 0)
							{
								num++;
								mPosicao = (DeclaracoesFiacao.structurePosicaoDisp[])Utils.CopyArray(mPosicao, new DeclaracoesFiacao.structurePosicaoDisp[Information.UBound(mPosicao) + 1 + 1]);
								mPosicao[Information.UBound(mPosicao)].painel = painel;
								mPosicao[Information.UBound(mPosicao)].tag = Conversions.ToString(array[i].Value);
								mPosicao[Information.UBound(mPosicao)].posicaoNum = posicaoNum;
								mPosicao[Information.UBound(mPosicao)].ordem = num;
							}
							else
							{
								num++;
								mPosicao = (DeclaracoesFiacao.structurePosicaoDisp[])Utils.CopyArray(mPosicao, new DeclaracoesFiacao.structurePosicaoDisp[Information.UBound(mPosicao) + 1 + 1]);
								mPosicao[Information.UBound(mPosicao)].painel = painel;
								mPosicao[Information.UBound(mPosicao)].tag = Conversions.ToString(array[i].Value);
								mPosicao[Information.UBound(mPosicao)].posicaoNum = posicaoNum;
								mPosicao[Information.UBound(mPosicao)].ordem = num;
							}
						}
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
		}
	}
}

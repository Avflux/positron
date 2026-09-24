using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Runtime;

namespace Eletron4;

public class DicionarioAplicacao
{
	public static void GravaDicionarioAplicacoes(DeclaracoesFiacao.structureAplicacao[] mAplicacao)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected Obj, but got Unknown
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Expected Obj, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected Obj, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Expected Obj, but got Unknown
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected Obj, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected Obj, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					try
					{
						DBDictionary val3 = (DBDictionary)val2.GetObject(database.NamedObjectsDictionaryId, (OpenMode)1, false);
						int num = 1;
						DBDictionary val4;
						if (!val3.Contains("APLICACAO"))
						{
							val4 = new DBDictionary();
							val3.SetAt("APLICACAO", (DBObject)(object)val4);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
						}
						else
						{
							val4 = (DBDictionary)val2.GetObject(val3.GetAt("APLICACAO"), (OpenMode)1);
						}
						Xrecord val5;
						if (!val4.Contains("TIPOS"))
						{
							TypedValue[] array = new TypedValue[1];
							ResultBuffer data = new ResultBuffer(array);
							val5 = new Xrecord();
							val5.Data = data;
							val4.SetAt("TIPOS", (DBObject)(object)val5);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)val5, true);
						}
						else
						{
							ObjectId at = val4.GetAt("TIPOS");
							val5 = (Xrecord)val2.GetObject(at, (OpenMode)1);
						}
						TypedValue[] array2 = new TypedValue[Information.UBound(mAplicacao) * 10 + 1];
						int num2 = 0;
						int num3 = Information.UBound(mAplicacao) * 10;
						for (int i = 1; i <= num3; i += 10)
						{
							num2++;
							array2[i + 0] = new TypedValue(90, (object)mAplicacao[num2].Indice);
							array2[i + 1] = new TypedValue(1, (object)mAplicacao[num2].Nome);
							array2[i + 2] = new TypedValue(1, (object)mAplicacao[num2].Secao);
							array2[i + 3] = new TypedValue(1, (object)mAplicacao[num2].Cor);
							array2[i + 4] = new TypedValue(1, (object)mAplicacao[num2].TipoCabo);
							array2[i + 5] = new TypedValue(1, (object)mAplicacao[num2].Isolacao);
							array2[i + 6] = new TypedValue(1, (object)"");
							array2[i + 7] = new TypedValue(1, (object)"");
							array2[i + 8] = new TypedValue(1, (object)"");
							array2[i + 9] = new TypedValue(90, (object)0);
						}
						num = ((Information.UBound(mAplicacao) == 0) ? 1 : mAplicacao[num2].Indice);
						array2[0] = new TypedValue(90, (object)num);
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
					}
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

	public static int LeOsTiposDeAplicacoes(ref DeclaracoesFiacao.structureAplicacao[] mAplicacao)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected Obj, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected Obj, but got Unknown
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected Obj, but got Unknown
		int result = 0;
		int num = 0;
		long num2 = 0L;
		mAplicacao = new DeclaracoesFiacao.structureAplicacao[1];
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				try
				{
					DBDictionary val2 = (DBDictionary)val.GetObject(database.NamedObjectsDictionaryId, (OpenMode)0, false);
					DBDictionary val3;
					if (!val2.Contains("APLICACAO"))
					{
						val3 = null;
					}
					else
					{
						val3 = (DBDictionary)val.GetObject(val2.GetAt("APLICACAO"), (OpenMode)0);
						if (val3.Contains("TIPOS"))
						{
							ObjectId at = val3.GetAt("TIPOS");
							Xrecord val4 = (Xrecord)val.GetObject(at, (OpenMode)0);
							ResultBuffer data = val4.Data;
							TypedValue[] array = data.AsArray();
							int num3 = Information.UBound(array);
							for (int i = 1; i <= num3; i += 10)
							{
								num2 = Information.UBound(mAplicacao) + 1;
								mAplicacao = (DeclaracoesFiacao.structureAplicacao[])Utils.CopyArray(mAplicacao, new DeclaracoesFiacao.structureAplicacao[(int)num2 + 1]);
								mAplicacao[(int)num2].Indice = Conversions.ToInteger(array[i + 0].Value);
								mAplicacao[(int)num2].Nome = Conversions.ToString(array[i + 1].Value);
								mAplicacao[(int)num2].Secao = Conversions.ToString(array[i + 2].Value);
								mAplicacao[(int)num2].Cor = Conversions.ToString(array[i + 3].Value);
								mAplicacao[(int)num2].TipoCabo = Conversions.ToString(array[i + 4].Value);
								mAplicacao[(int)num2].Isolacao = Conversions.ToString(array[i + 5].Value);
								num = mAplicacao[(int)num2].Indice;
							}
							result = num;
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
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			return result;
		}
	}

	public static void carregaDicAplicacao()
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected Obj, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected Obj, but got Unknown
		DeclaracoesFiacao.structureAplicacao[] array = new DeclaracoesFiacao.structureAplicacao[1];
		long num = 0L;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				try
				{
					DBDictionary val2 = (DBDictionary)val.GetObject(database.NamedObjectsDictionaryId, (OpenMode)0, false);
					DBDictionary val3;
					if (!val2.Contains("APLICACAO"))
					{
						val3 = null;
					}
					else
					{
						val3 = (DBDictionary)val.GetObject(val2.GetAt("APLICACAO"), (OpenMode)0);
						if (val3.Contains("TIPOS"))
						{
							ObjectId at = val3.GetAt("TIPOS");
							Xrecord val4 = (Xrecord)val.GetObject(at, (OpenMode)0);
							ResultBuffer data = val4.Data;
							TypedValue[] array2 = data.AsArray();
							int num2 = Information.UBound(array2);
							for (int i = 1; i <= num2; i += 10)
							{
								num = Information.UBound(array) + 1;
								array = (DeclaracoesFiacao.structureAplicacao[])Utils.CopyArray(array, new DeclaracoesFiacao.structureAplicacao[(int)num + 1]);
								array[(int)num].Indice = Conversions.ToInteger(array2[i + 0].Value);
								array[(int)num].Nome = Conversions.ToString(array2[i + 1].Value);
								array[(int)num].Secao = Conversions.ToString(array2[i + 2].Value);
								array[(int)num].Cor = Conversions.ToString(array2[i + 3].Value);
								array[(int)num].TipoCabo = Conversions.ToString(array2[i + 4].Value);
								array[(int)num].Isolacao = Conversions.ToString(array2[i + 5].Value);
							}
						}
					}
					DeclaracoesGeral.dicAplicacao = new Dictionary<int, string>();
					int num3 = Information.UBound(array);
					for (int j = 1; j <= num3; j++)
					{
						DeclaracoesGeral.dicAplicacao.Add(array[j].Indice, array[j].Nome);
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
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}
}

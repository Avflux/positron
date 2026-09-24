using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Runtime;

namespace Eletron4;

public class DicionarioMascaras
{
	public static bool LeUmModeloDeDicionarioMascara(int indice, ref Declaracoes2.MModeloDeMascara mModelo)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected Obj, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected Obj, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected Obj, but got Unknown
		bool result = false;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				DBDictionary val2 = (DBDictionary)val.GetObject(database.NamedObjectsDictionaryId, (OpenMode)0, false);
				DBDictionary val3;
				if (!val2.Contains("MASCARAS"))
				{
					val3 = null;
				}
				else
				{
					val3 = (DBDictionary)val.GetObject(val2.GetAt("MASCARAS"), (OpenMode)0);
					if (val3.Contains("MODELOS2"))
					{
						ObjectId at = val3.GetAt("MODELOS2");
						Xrecord val4 = (Xrecord)val.GetObject(at, (OpenMode)0);
						ResultBuffer data = val4.Data;
						TypedValue[] array = data.AsArray();
						int num = Information.UBound(array);
						for (int i = 1; i <= num; i += 10)
						{
							if (indice == Conversions.ToInteger(array[i + 0].Value))
							{
								mModelo.iIndiceModelo = Conversions.ToInteger(array[i + 0].Value);
								mModelo.sNomeModelo = Conversions.ToString(array[i + 1].Value);
								mModelo.iLM1 = Conversions.ToInteger(array[i + 2].Value);
								mModelo.iLM2 = Conversions.ToInteger(array[i + 3].Value);
								mModelo.sBlocoTopografico = Conversions.ToString(array[i + 5].Value);
								mModelo.sBlocoLayout = Conversions.ToString(array[i + 6].Value);
								mModelo.Orientacao = Conversions.ToString(array[i + 7].Value);
								mModelo.sPlaquetas = "";
								mModelo.sFabricante = "";
								mModelo.sDescricao = "";
								result = true;
								break;
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
			return result;
		}
	}

	public static bool LeOsModelosDeMascaras(ref Declaracoes2.MModeloDeMascara[] mModelo, bool bComplementarModelo)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected Obj, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected Obj, but got Unknown
		bool result = false;
		long num = 0L;
		mModelo = new Declaracoes2.MModeloDeMascara[1];
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
					try
					{
						if (!val2.Contains("MASCARAS"))
						{
							val3 = null;
						}
						else
						{
							val3 = (DBDictionary)val.GetObject(val2.GetAt("MASCARAS"), (OpenMode)0);
							if (val3.Contains("MODELOS2"))
							{
								ObjectId at = val3.GetAt("MODELOS2");
								Xrecord val4 = (Xrecord)val.GetObject(at, (OpenMode)0);
								ResultBuffer data = val4.Data;
								TypedValue[] array = data.AsArray();
								int num2 = Information.UBound(array);
								for (int i = 1; i <= num2; i += 10)
								{
									num = Information.UBound(mModelo) + 1;
									mModelo = (Declaracoes2.MModeloDeMascara[])Utils.CopyArray(mModelo, new Declaracoes2.MModeloDeMascara[(int)num + 1]);
									mModelo[(int)num].iIndiceModelo = Conversions.ToInteger(array[i + 0].Value);
									mModelo[(int)num].sNomeModelo = Conversions.ToString(array[i + 1].Value);
									mModelo[(int)num].iLM1 = Conversions.ToInteger(array[i + 2].Value);
									mModelo[(int)num].iLM2 = Conversions.ToInteger(array[i + 3].Value);
									mModelo[(int)num].sBlocoTopografico = Conversions.ToString(array[i + 5].Value);
									mModelo[(int)num].sBlocoLayout = Conversions.ToString(array[i + 6].Value);
									mModelo[(int)num].Orientacao = Conversions.ToString(array[i + 7].Value);
									mModelo[(int)num].sPlaquetas = "";
									mModelo[(int)num].sFabricante = "";
									mModelo[(int)num].sDescricao = "";
								}
								if (bComplementarModelo)
								{
									cDadosLM cDadosLM2 = new cDadosLM();
									cDadosLM2.ComplementaModelo(mModelo);
									cDadosLM2.fechaConexao();
								}
								result = true;
							}
						}
						DeclaracoesGeral.bAnularEventos = true;
						val.Commit();
						DeclaracoesGeral.bAnularEventos = false;
						OrdenaOsModelosDeDeDicionarioMascara(ref mModelo);
					}
					finally
					{
						((IDisposable)val2)?.Dispose();
					}
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

	public static bool LeOsModelosDeMascarasSemAbrirDWG(ref Declaracoes2.MModeloDeMascara[] mModelo, bool bComplementarModelo, ref Database db)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected Obj, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected Obj, but got Unknown
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected Obj, but got Unknown
		bool result = false;
		long num = 0L;
		mModelo = new Declaracoes2.MModeloDeMascara[1];
		Transaction val = db.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				try
				{
					DBDictionary val2 = (DBDictionary)val.GetObject(db.NamedObjectsDictionaryId, (OpenMode)0, false);
					DBDictionary val3;
					if (!val2.Contains("MASCARAS"))
					{
						val3 = null;
					}
					else
					{
						val3 = (DBDictionary)val.GetObject(val2.GetAt("MASCARAS"), (OpenMode)0);
						if (val3.Contains("MODELOS2"))
						{
							ObjectId at = val3.GetAt("MODELOS2");
							Xrecord val4 = (Xrecord)val.GetObject(at, (OpenMode)0);
							ResultBuffer data = val4.Data;
							TypedValue[] array = data.AsArray();
							int num2 = Information.UBound(array);
							for (int i = 1; i <= num2; i += 10)
							{
								num = Information.UBound(mModelo) + 1;
								mModelo = (Declaracoes2.MModeloDeMascara[])Utils.CopyArray(mModelo, new Declaracoes2.MModeloDeMascara[(int)num + 1]);
								mModelo[(int)num].iIndiceModelo = Conversions.ToInteger(array[i + 0].Value);
								mModelo[(int)num].sNomeModelo = Conversions.ToString(array[i + 1].Value);
								mModelo[(int)num].iLM1 = Conversions.ToInteger(array[i + 2].Value);
								mModelo[(int)num].iLM2 = Conversions.ToInteger(array[i + 3].Value);
								mModelo[(int)num].sBlocoTopografico = Conversions.ToString(array[i + 5].Value);
								mModelo[(int)num].sBlocoLayout = Conversions.ToString(array[i + 6].Value);
								mModelo[(int)num].Orientacao = Conversions.ToString(array[i + 7].Value);
								mModelo[(int)num].sPlaquetas = "";
								mModelo[(int)num].sFabricante = "";
								mModelo[(int)num].sDescricao = "";
							}
							if (bComplementarModelo)
							{
								cDadosLM cDadosLM2 = new cDadosLM();
								cDadosLM2.ComplementaModelo(mModelo);
								cDadosLM2.fechaConexao();
							}
							result = true;
						}
					}
					DeclaracoesGeral.bAnularEventos = true;
					val.Commit();
					DeclaracoesGeral.bAnularEventos = false;
					OrdenaOsModelosDeDeDicionarioMascara(ref mModelo);
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

	public static void GravaOsModelosDeMascara(Declaracoes2.MModeloDeMascara[] mModelo)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_0240: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected Obj, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Expected Obj, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected Obj, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected Obj, but got Unknown
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					OrdenaOsModelosDeDeDicionarioMascara(ref mModelo);
					DBDictionary val3 = (DBDictionary)val2.GetObject(database.NamedObjectsDictionaryId, (OpenMode)1, false);
					int num = 1;
					DBDictionary val4;
					if (!val3.Contains("MASCARAS"))
					{
						val4 = new DBDictionary();
						val3.SetAt("MASCARAS", (DBObject)(object)val4);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
					}
					else
					{
						val4 = (DBDictionary)val2.GetObject(val3.GetAt("MASCARAS"), (OpenMode)1);
					}
					Xrecord val5;
					if (!val4.Contains("MODELOS2"))
					{
						TypedValue[] array = new TypedValue[1];
						ResultBuffer data = new ResultBuffer(array);
						val5 = new Xrecord();
						val5.Data = data;
						val4.SetAt("MODELOS2", (DBObject)(object)val5);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)val5, true);
					}
					else
					{
						ObjectId at = val4.GetAt("MODELOS2");
						val5 = (Xrecord)val2.GetObject(at, (OpenMode)1);
					}
					TypedValue[] array2 = new TypedValue[Information.UBound(mModelo) * 10 + 1];
					int num2 = 0;
					int num3 = Information.UBound(mModelo) * 10;
					for (int i = 1; i <= num3; i += 10)
					{
						num2++;
						array2[i + 0] = new TypedValue(90, (object)mModelo[num2].iIndiceModelo);
						array2[i + 1] = new TypedValue(1, (object)mModelo[num2].sNomeModelo);
						array2[i + 2] = new TypedValue(90, (object)mModelo[num2].iLM1);
						array2[i + 3] = new TypedValue(90, (object)mModelo[num2].iLM2);
						array2[i + 4] = new TypedValue(90, (object)0);
						array2[i + 5] = new TypedValue(1, (object)mModelo[num2].sBlocoTopografico);
						array2[i + 6] = new TypedValue(1, (object)mModelo[num2].sBlocoLayout);
						array2[i + 7] = new TypedValue(1, (object)mModelo[num2].Orientacao);
						array2[i + 8] = new TypedValue(1, (object)"");
						array2[i + 9] = new TypedValue(1, (object)"");
					}
					num = ((Information.UBound(mModelo) == 0) ? 1 : (mModelo[num2].iIndiceModelo + 1));
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
					((IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}

	public static void GravaOsModelosDeMascaraSemAbrirDWG(Declaracoes2.MModeloDeMascara[] mModelo, ref Database db)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected Obj, but got Unknown
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Expected Obj, but got Unknown
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Expected Obj, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected Obj, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected Obj, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a5: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Transaction val2 = db.TransactionManager.StartTransaction();
				try
				{
					OrdenaOsModelosDeDeDicionarioMascara(ref mModelo);
					DBDictionary val3 = (DBDictionary)val2.GetObject(db.NamedObjectsDictionaryId, (OpenMode)1, false);
					int num = 1;
					DBDictionary val4;
					if (!val3.Contains("MASCARAS"))
					{
						val4 = new DBDictionary();
						val3.SetAt("MASCARAS", (DBObject)(object)val4);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
					}
					else
					{
						val4 = (DBDictionary)val2.GetObject(val3.GetAt("MASCARAS"), (OpenMode)1);
					}
					Xrecord val5;
					if (!val4.Contains("MODELOS2"))
					{
						TypedValue[] array = new TypedValue[1];
						ResultBuffer data = new ResultBuffer(array);
						val5 = new Xrecord();
						val5.Data = data;
						val4.SetAt("MODELOS2", (DBObject)(object)val5);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)val5, true);
					}
					else
					{
						ObjectId at = val4.GetAt("MODELOS2");
						val5 = (Xrecord)val2.GetObject(at, (OpenMode)1);
					}
					TypedValue[] array2 = new TypedValue[Information.UBound(mModelo) * 10 + 1];
					int num2 = 0;
					int num3 = Information.UBound(mModelo) * 10;
					for (int i = 1; i <= num3; i += 10)
					{
						num2++;
						array2[i + 0] = new TypedValue(90, (object)mModelo[num2].iIndiceModelo);
						array2[i + 1] = new TypedValue(1, (object)mModelo[num2].sNomeModelo);
						array2[i + 2] = new TypedValue(90, (object)mModelo[num2].iLM1);
						array2[i + 3] = new TypedValue(90, (object)mModelo[num2].iLM2);
						array2[i + 4] = new TypedValue(90, (object)0);
						array2[i + 5] = new TypedValue(1, (object)mModelo[num2].sBlocoTopografico);
						array2[i + 6] = new TypedValue(1, (object)mModelo[num2].sBlocoLayout);
						array2[i + 7] = new TypedValue(1, (object)mModelo[num2].Orientacao);
						array2[i + 8] = new TypedValue(1, (object)"");
						array2[i + 9] = new TypedValue(1, (object)"");
					}
					num = ((Information.UBound(mModelo) == 0) ? 1 : (mModelo[num2].iIndiceModelo + 1));
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
					((IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}

	public static void OrdenaOsModelosDeDeDicionarioMascara(ref Declaracoes2.MModeloDeMascara[] mModelo)
	{
		if (Information.UBound(mModelo) < 2)
		{
			return;
		}
		checked
		{
			int num = Information.UBound(mModelo) - 1;
			for (int i = num; i >= 1; i += -1)
			{
				int num2 = i;
				for (int j = 1; j <= num2; j++)
				{
					if (mModelo[j].iIndiceModelo > mModelo[j + 1].iIndiceModelo)
					{
						Declaracoes2.MModeloDeMascara mModeloDeMascara = default;
						mModeloDeMascara = mModelo[j + 1];
						mModelo[j + 1] = mModelo[j];
						mModelo[j] = mModeloDeMascara;
					}
				}
			}
		}
	}

	public static bool LeAsPortasDoModeloDoDicionario(ref int iIndiceSelecionado, string sNomeModelo, ref Declaracoes2.MModeloDePortas[] mPortas)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected Obj, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected Obj, but got Unknown
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected Obj, but got Unknown
		bool result = false;
		long num = 0L;
		mPortas = (Declaracoes2.MModeloDePortas[])Utils.CopyArray(mPortas, new Declaracoes2.MModeloDePortas[1]);
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				DBDictionary val2 = (DBDictionary)val.GetObject(database.NamedObjectsDictionaryId, (OpenMode)0, false);
				DBDictionary val3;
				if (!val2.Contains("MASCARAS"))
				{
					val3 = null;
				}
				else
				{
					val3 = (DBDictionary)val.GetObject(val2.GetAt("MASCARAS"), (OpenMode)0);
					if (val3.Contains(Conversions.ToString(iIndiceSelecionado)))
					{
						ObjectId at = val3.GetAt(Conversions.ToString(iIndiceSelecionado));
						Xrecord val4 = (Xrecord)val.GetObject(at, (OpenMode)0);
						ResultBuffer data = val4.Data;
						TypedValue[] array = data.AsArray();
						mPortas[0].MaxIndice = Conversions.ToInteger(array[0].Value);
						mPortas = (Declaracoes2.MModeloDePortas[])Utils.CopyArray(mPortas, new Declaracoes2.MModeloDePortas[1]);
						int num2 = Information.UBound(array);
						for (int i = 1; i <= num2; i += 8)
						{
							num = Information.UBound(mPortas) + 1;
							mPortas = (Declaracoes2.MModeloDePortas[])Utils.CopyArray(mPortas, new Declaracoes2.MModeloDePortas[(int)num + 1]);
							mPortas[(int)num].IndiceDaPorta = Conversions.ToInteger(array[i + 0].Value);
							mPortas[(int)num].IndiceModelo = iIndiceSelecionado;
							mPortas[(int)num].IndicePN = 0;
							mPortas[(int)num].NomeModelo = sNomeModelo;
							mPortas[(int)num].sOrientacao = Conversions.ToString(array[i + 1].Value);
							mPortas[(int)num].sEFC = Conversions.ToString(array[i + 2].Value);
							mPortas[(int)num].sTerminais = Conversions.ToString(array[i + 3].Value);
							mPortas[(int)num].sBornes = Conversions.ToString(array[i + 4].Value);
							mPortas[(int)num].sRegua = Conversions.ToString(array[i + 6].Value);
							mPortas[(int)num].Uso = false;
							mPortas[(int)num].PaginaPorta = "";
							mPortas[(int)num].PaginaDef = "";
							mPortas[(int)num].HandlePorta = "";
							mPortas[(int)num].HandleDef = "";
						}
						result = true;
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				OrdenaAsPortasDoModeloMascara(ref mPortas);
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

	public static bool LeAsPortasDoModeloDoDicionarioSemAbriDWG(ref int iIndiceSelecionado, string sNomeModelo, ref Declaracoes2.MModeloDePortas[] mPortas, ref Database db)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected Obj, but got Unknown
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected Obj, but got Unknown
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected Obj, but got Unknown
		bool result = false;
		long num = 0L;
		mPortas = (Declaracoes2.MModeloDePortas[])Utils.CopyArray(mPortas, new Declaracoes2.MModeloDePortas[1]);
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Transaction val2 = db.TransactionManager.StartTransaction();
				try
				{
					DBDictionary val3 = (DBDictionary)val2.GetObject(db.NamedObjectsDictionaryId, (OpenMode)0, false);
					DBDictionary val4;
					if (!val3.Contains("MASCARAS"))
					{
						val4 = null;
					}
					else
					{
						val4 = (DBDictionary)val2.GetObject(val3.GetAt("MASCARAS"), (OpenMode)0);
						if (val4.Contains(Conversions.ToString(iIndiceSelecionado)))
						{
							ObjectId at = val4.GetAt(Conversions.ToString(iIndiceSelecionado));
							Xrecord val5 = (Xrecord)val2.GetObject(at, (OpenMode)0);
							ResultBuffer data = val5.Data;
							TypedValue[] array = data.AsArray();
							mPortas[0].MaxIndice = Conversions.ToInteger(array[0].Value);
							mPortas = (Declaracoes2.MModeloDePortas[])Utils.CopyArray(mPortas, new Declaracoes2.MModeloDePortas[1]);
							int num2 = Information.UBound(array);
							for (int i = 1; i <= num2; i += 8)
							{
								num = Information.UBound(mPortas) + 1;
								mPortas = (Declaracoes2.MModeloDePortas[])Utils.CopyArray(mPortas, new Declaracoes2.MModeloDePortas[(int)num + 1]);
								mPortas[(int)num].IndiceDaPorta = Conversions.ToInteger(array[i + 0].Value);
								mPortas[(int)num].IndiceModelo = iIndiceSelecionado;
								mPortas[(int)num].IndicePN = 0;
								mPortas[(int)num].NomeModelo = sNomeModelo;
								mPortas[(int)num].sOrientacao = Conversions.ToString(array[i + 1].Value);
								mPortas[(int)num].sEFC = Conversions.ToString(array[i + 2].Value);
								mPortas[(int)num].sTerminais = Conversions.ToString(array[i + 3].Value);
								mPortas[(int)num].sBornes = Conversions.ToString(array[i + 4].Value);
								mPortas[(int)num].sRegua = Conversions.ToString(array[i + 6].Value);
								mPortas[(int)num].Uso = false;
								mPortas[(int)num].PaginaPorta = "";
								mPortas[(int)num].PaginaDef = "";
								mPortas[(int)num].HandlePorta = "";
								mPortas[(int)num].HandleDef = "";
							}
							result = true;
						}
					}
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
					OrdenaAsPortasDoModeloMascara(ref mPortas);
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
			return result;
		}
	}

	public static void GravaAsPortasDoModeloDoDicionario(int iIndiceSelecionado, ref Declaracoes2.MModeloDePortas[] mPortas)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected Obj, but got Unknown
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Expected Obj, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Expected Obj, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected Obj, but got Unknown
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected Obj, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					OrdenaAsPortasDoModeloMascara(ref mPortas);
					DBDictionary val3 = (DBDictionary)val2.GetObject(database.NamedObjectsDictionaryId, (OpenMode)1, false);
					DBDictionary val4;
					if (!val3.Contains("MASCARAS"))
					{
						val4 = new DBDictionary();
						val3.SetAt("MASCARAS", (DBObject)(object)val4);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
					}
					else
					{
						val4 = (DBDictionary)val2.GetObject(val3.GetAt("MASCARAS"), (OpenMode)1);
					}
					Xrecord val5;
					if (!val4.Contains(Conversions.ToString(iIndiceSelecionado)))
					{
						TypedValue[] array = new TypedValue[1];
						ResultBuffer data = new ResultBuffer(array);
						val5 = new Xrecord();
						val5.Data = data;
						val4.SetAt(Conversions.ToString(iIndiceSelecionado), (DBObject)(object)val5);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)val5, true);
					}
					else
					{
						ObjectId at = val4.GetAt(Conversions.ToString(iIndiceSelecionado));
						val5 = (Xrecord)val2.GetObject(at, (OpenMode)1);
					}
					TypedValue[] array2 = new TypedValue[Information.UBound(mPortas) * 8 + 1];
					array2[0] = new TypedValue(90, (object)mPortas[0].MaxIndice);
					int num = 0;
					int num2 = Information.UBound(mPortas) * 8;
					for (int i = 1; i <= num2; i += 8)
					{
						num++;
						array2[i + 0] = new TypedValue(90, (object)mPortas[num].IndiceDaPorta);
						array2[i + 1] = new TypedValue(1, (object)clsTextos.TiraNothing(mPortas[num].sOrientacao).ToUpper());
						array2[i + 2] = new TypedValue(1, (object)mPortas[num].sEFC);
						array2[i + 3] = new TypedValue(1, (object)mPortas[num].sTerminais);
						array2[i + 4] = new TypedValue(1, (object)mPortas[num].sBornes);
						array2[i + 5] = new TypedValue(1, (object)"");
						array2[i + 6] = new TypedValue(1, (object)mPortas[num].sRegua);
						array2[i + 7] = new TypedValue(1, (object)"");
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

	public static string BuscaNomePortaMascara(ref int iIndiceModelo, ref int iIndiceSelecionado)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected Obj, but got Unknown
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected Obj, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected Obj, but got Unknown
		string result = "";
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				DBDictionary val2 = (DBDictionary)val.GetObject(database.NamedObjectsDictionaryId, (OpenMode)0, false);
				DBDictionary val3;
				if (!val2.Contains("MASCARAS"))
				{
					val3 = null;
				}
				else
				{
					val3 = (DBDictionary)val.GetObject(val2.GetAt("MASCARAS"), (OpenMode)0);
					if (val3.Contains(Conversions.ToString(iIndiceModelo)))
					{
						ObjectId at = val3.GetAt(Conversions.ToString(iIndiceModelo));
						Xrecord val4 = (Xrecord)val.GetObject(at, (OpenMode)0);
						ResultBuffer data = val4.Data;
						TypedValue[] array = data.AsArray();
						int num = Information.UBound(array);
						for (int i = 1; i <= num; i += 8)
						{
							if (iIndiceSelecionado == Conversions.ToInteger(array[i + 0].Value))
							{
								result = Conversions.ToString(array[i + 2].Value);
								break;
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
			return result;
		}
	}

	public static void OrdenaAsPortasDoModeloMascara(ref Declaracoes2.MModeloDePortas[] mPortas)
	{
		if (Information.UBound(mPortas) < 2)
		{
			return;
		}
		checked
		{
			int num = Information.UBound(mPortas) - 1;
			for (int i = num; i >= 1; i += -1)
			{
				int num2 = i;
				for (int j = 1; j <= num2; j++)
				{
					if (mPortas[j].IndiceDaPorta > mPortas[j + 1].IndiceDaPorta)
					{
						Declaracoes2.MModeloDePortas mModeloDePortas = default;
						mModeloDePortas = mPortas[j + 1];
						mPortas[j + 1] = mPortas[j];
						mPortas[j] = mModeloDePortas;
					}
				}
			}
		}
	}
}

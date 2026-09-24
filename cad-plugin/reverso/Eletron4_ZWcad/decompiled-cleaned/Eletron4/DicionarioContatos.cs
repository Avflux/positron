using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Runtime;

namespace Eletron4;

public class DicionarioContatos
{
	public static bool LeUmModeloDeDeDicionarioContatos(int indice, ref Declaracoes2.MModelosDeContatos mModelo)
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
				if (!val2.Contains("CONTATOS"))
				{
					val3 = null;
				}
				else
				{
					val3 = (DBDictionary)val.GetObject(val2.GetAt("CONTATOS"), (OpenMode)0);
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
								mModelo.sOrientacao = Conversions.ToString(array[i + 8].Value);
								mModelo.sTerminaisDoDispositivo = Conversions.ToString(array[i + 9].Value);
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

	public static int LeOsModelosDeDeDicionarioContatos(ref Declaracoes2.MModelosDeContatos[] mModelo)
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
		int result = 0;
		long num = 0L;
		mModelo = new Declaracoes2.MModelosDeContatos[1];
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				DBDictionary val2 = (DBDictionary)val.GetObject(database.NamedObjectsDictionaryId, (OpenMode)0, false);
				DBDictionary val3;
				try
				{
					if (!val2.Contains("CONTATOS"))
					{
						val3 = null;
					}
					else
					{
						val3 = (DBDictionary)val.GetObject(val2.GetAt("CONTATOS"), (OpenMode)0);
						if (val3.Contains("MODELOS2"))
						{
							ObjectId at = val3.GetAt("MODELOS2");
							Xrecord val4 = (Xrecord)val.GetObject(at, (OpenMode)0);
							ResultBuffer data = val4.Data;
							TypedValue[] array = data.AsArray();
							result = Conversions.ToInteger(array[0].Value);
							int num2 = Information.UBound(array);
							for (int i = 1; i <= num2; i += 10)
							{
								num = Information.UBound(mModelo) + 1;
								mModelo = (Declaracoes2.MModelosDeContatos[])Utils.CopyArray(mModelo, new Declaracoes2.MModelosDeContatos[(int)num + 1]);
								mModelo[(int)num].iIndiceModelo = Conversions.ToInteger(array[i + 0].Value);
								mModelo[(int)num].sNomeModelo = Conversions.ToString(array[i + 1].Value);
								mModelo[(int)num].iLM1 = Conversions.ToInteger(array[i + 2].Value);
								mModelo[(int)num].iLM2 = Conversions.ToInteger(array[i + 3].Value);
								mModelo[(int)num].sBlocoTopografico = Conversions.ToString(array[i + 5].Value);
								mModelo[(int)num].sBlocoLayout = Conversions.ToString(array[i + 6].Value);
								mModelo[(int)num].sOrientacao = Conversions.ToString(array[i + 8].Value);
								mModelo[(int)num].sTerminaisDoDispositivo = Conversions.ToString(array[i + 9].Value);
							}
						}
					}
					DeclaracoesGeral.bAnularEventos = true;
					val.Commit();
					DeclaracoesGeral.bAnularEventos = false;
					OrdenaOsModelosDeDeDicionarioContatos(ref mModelo);
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
				((IDisposable)val)?.Dispose();
			}
			return result;
		}
	}

	public static int LeOsModelosDeDeDicionarioContatosSemAbrirDWG(ref Declaracoes2.MModelosDeContatos[] mModelo, ref Database db)
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
		int result = 0;
		long num = 0L;
		mModelo = new Declaracoes2.MModelosDeContatos[1];
		Transaction val = db.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				DBDictionary val2 = (DBDictionary)val.GetObject(db.NamedObjectsDictionaryId, (OpenMode)0, false);
				DBDictionary val3;
				if (!val2.Contains("CONTATOS"))
				{
					val3 = null;
				}
				else
				{
					val3 = (DBDictionary)val.GetObject(val2.GetAt("CONTATOS"), (OpenMode)0);
					if (val3.Contains("MODELOS2"))
					{
						ObjectId at = val3.GetAt("MODELOS2");
						Xrecord val4 = (Xrecord)val.GetObject(at, (OpenMode)0);
						ResultBuffer data = val4.Data;
						TypedValue[] array = data.AsArray();
						result = Conversions.ToInteger(array[0].Value);
						int num2 = Information.UBound(array);
						for (int i = 1; i <= num2; i += 10)
						{
							num = Information.UBound(mModelo) + 1;
							mModelo = (Declaracoes2.MModelosDeContatos[])Utils.CopyArray(mModelo, new Declaracoes2.MModelosDeContatos[(int)num + 1]);
							mModelo[(int)num].iIndiceModelo = Conversions.ToInteger(array[i + 0].Value);
							mModelo[(int)num].sNomeModelo = Conversions.ToString(array[i + 1].Value);
							mModelo[(int)num].iLM1 = Conversions.ToInteger(array[i + 2].Value);
							mModelo[(int)num].iLM2 = Conversions.ToInteger(array[i + 3].Value);
							mModelo[(int)num].sBlocoTopografico = Conversions.ToString(array[i + 5].Value);
							mModelo[(int)num].sBlocoLayout = Conversions.ToString(array[i + 6].Value);
							mModelo[(int)num].sOrientacao = Conversions.ToString(array[i + 8].Value);
							mModelo[(int)num].sTerminaisDoDispositivo = Conversions.ToString(array[i + 9].Value);
						}
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				OrdenaOsModelosDeDeDicionarioContatos(ref mModelo);
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

	public static int GravaOsModelosDeDispositivosDeDicionario(ref Declaracoes2.MModelosDeContatos[] mModelo)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected Obj, but got Unknown
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected Obj, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Expected Obj, but got Unknown
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected Obj, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected Obj, but got Unknown
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Expected Obj, but got Unknown
		int num = 1;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					OrdenaOsModelosDeDeDicionarioContatos(ref mModelo);
					DBDictionary val3 = (DBDictionary)val2.GetObject(database.NamedObjectsDictionaryId, (OpenMode)1, false);
					DBDictionary val4;
					if (!val3.Contains("CONTATOS"))
					{
						val4 = new DBDictionary();
						val3.SetAt("CONTATOS", (DBObject)(object)val4);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
					}
					else
					{
						val4 = (DBDictionary)val2.GetObject(val3.GetAt("CONTATOS"), (OpenMode)1);
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
						array2[i + 7] = new TypedValue(1, (object)"");
						array2[i + 8] = new TypedValue(1, (object)mModelo[num2].sOrientacao.ToUpper());
						array2[i + 9] = new TypedValue(1, (object)mModelo[num2].sTerminaisDoDispositivo);
						num = mModelo[num2].iIndiceModelo + 1;
					}
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
			return num;
		}
	}

	public static int GravaOsModelosDeDispositivosDeDicionarioSemAbrirDWG(ref Declaracoes2.MModelosDeContatos[] mModelo, ref Database db)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected Obj, but got Unknown
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Expected Obj, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected Obj, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Expected Obj, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected Obj, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected Obj, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Expected Obj, but got Unknown
		int num = 1;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Transaction val2 = db.TransactionManager.StartTransaction();
				try
				{
					OrdenaOsModelosDeDeDicionarioContatos(ref mModelo);
					DBDictionary val3 = (DBDictionary)val2.GetObject(db.NamedObjectsDictionaryId, (OpenMode)1, false);
					DBDictionary val4;
					if (!val3.Contains("CONTATOS"))
					{
						val4 = new DBDictionary();
						val3.SetAt("CONTATOS", (DBObject)(object)val4);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
					}
					else
					{
						val4 = (DBDictionary)val2.GetObject(val3.GetAt("CONTATOS"), (OpenMode)1);
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
						array2[i + 7] = new TypedValue(1, (object)"");
						array2[i + 8] = new TypedValue(1, (object)mModelo[num2].sOrientacao.ToUpper());
						array2[i + 9] = new TypedValue(1, (object)mModelo[num2].sTerminaisDoDispositivo);
						num = mModelo[num2].iIndiceModelo + 1;
					}
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
			return num;
		}
	}

	public static void OrdenaOsModelosDeDeDicionarioContatos(ref Declaracoes2.MModelosDeContatos[] mModelo)
	{
		if (Information.UBound(mModelo) >= 2)
		{
			Declaracoes2.MModelosDeContatos[] source = mModelo.OrderBy([SpecialName] (Declaracoes2.MModelosDeContatos x) => x.iIndiceModelo).ToArray();
			mModelo = source.ToArray();
		}
	}

	public static bool LeOsContatosAuxiliarDoModeloDoDicionario(ref int iIndiceSelecionado, ref Declaracoes2.StructureContatosAuxiliares[] mCONTATOS)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected Obj, but got Unknown
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected Obj, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected Obj, but got Unknown
		bool result = false;
		long num = 0L;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				DBDictionary val2 = (DBDictionary)val.GetObject(database.NamedObjectsDictionaryId, (OpenMode)0, false);
				DBDictionary val3;
				if (!val2.Contains("CONTATOS"))
				{
					val3 = null;
				}
				else
				{
					val3 = (DBDictionary)val.GetObject(val2.GetAt("CONTATOS"), (OpenMode)0);
					mCONTATOS = new Declaracoes2.StructureContatosAuxiliares[1];
					if (val3.Contains(Conversions.ToString(iIndiceSelecionado)))
					{
						ObjectId at = val3.GetAt(Conversions.ToString(iIndiceSelecionado));
						Xrecord val4 = (Xrecord)val.GetObject(at, (OpenMode)0);
						ResultBuffer data = val4.Data;
						TypedValue[] array = data.AsArray();
						int num2 = Information.UBound(array);
						for (int i = 1; i <= num2; i += 8)
						{
							num = Information.UBound(mCONTATOS) + 1;
							mCONTATOS = (Declaracoes2.StructureContatosAuxiliares[])Utils.CopyArray(mCONTATOS, new Declaracoes2.StructureContatosAuxiliares[(int)num + 1]);
							mCONTATOS[(int)num].iIndice = Conversions.ToInteger(array[i + 0].Value);
							mCONTATOS[(int)num].sT1 = Conversions.ToString(array[i + 1].Value);
							mCONTATOS[(int)num].sT2 = Conversions.ToString(array[i + 2].Value);
							mCONTATOS[(int)num].sT3 = Conversions.ToString(array[i + 3].Value);
							mCONTATOS[(int)num].iT = Conversions.ToInteger(array[i + 4].Value);
							object value = array[i + 4].Value;
							if (!Operators.ConditionalCompareObjectEqual(value, 1, TextCompare: true))
							{
								if (!Operators.ConditionalCompareObjectEqual(value, 2, TextCompare: true))
								{
									if (Operators.ConditionalCompareObjectEqual(value, 3, TextCompare: true))
									{
										mCONTATOS[(int)num].sTipo = "RV";
									}
								}
								else
								{
									mCONTATOS[(int)num].sTipo = "NF";
								}
							}
							else
							{
								mCONTATOS[(int)num].sTipo = "NA";
							}
							mCONTATOS[(int)num].sOrientacao = Conversions.ToString(array[i + 6].Value);
							string sTerm = mCONTATOS[(int)num].sT1 + ";" + mCONTATOS[(int)num].sT2 + ";" + mCONTATOS[(int)num].sT3 + ";";
							mCONTATOS[(int)num].sOrientacao = VerificaOrientacaoContato(sTerm, mCONTATOS[(int)num].sOrientacao);
							mCONTATOS[(int)num].iComportamento = Conversions.ToInteger(array[i + 5].Value);
							object value2 = array[i + 5].Value;
							if (!Operators.ConditionalCompareObjectEqual(value2, 0, TextCompare: true))
							{
								if (!Operators.ConditionalCompareObjectEqual(value2, 1, TextCompare: true))
								{
									if (!Operators.ConditionalCompareObjectEqual(value2, 2, TextCompare: true))
									{
										if (!Operators.ConditionalCompareObjectEqual(value2, 3, TextCompare: true))
										{
											if (Operators.ConditionalCompareObjectEqual(value2, 4, TextCompare: true))
											{
												mCONTATOS[(int)num].sComportamento = "AM";
											}
										}
										else
										{
											mCONTATOS[(int)num].sComportamento = "BI";
										}
									}
									else
									{
										mCONTATOS[(int)num].sComportamento = "TD";
									}
								}
								else
								{
									mCONTATOS[(int)num].sComportamento = "TE";
								}
							}
							else
							{
								mCONTATOS[(int)num].sComportamento = "ST";
							}
							mCONTATOS[(int)num].sUso = "";
						}
						result = true;
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				OrdenaOsModelosDeDeDicionarioContatosAuxiliates(ref mCONTATOS);
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

	public static void GravaOsContatosAuxiliarDoModeloDoDicionario(int iIndiceSelecionado, ref int iMaxIndice, Declaracoes2.StructureContatosAuxiliares[] mCONTATOS)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Expected Obj, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected Obj, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Expected Obj, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected Obj, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected Obj, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					OrdenaOsModelosDeDeDicionarioContatosAuxiliates(ref mCONTATOS);
					DBDictionary val3 = (DBDictionary)val2.GetObject(database.NamedObjectsDictionaryId, (OpenMode)1, false);
					DBDictionary val4;
					if (!val3.Contains("CONTATOS"))
					{
						val4 = new DBDictionary();
						val3.SetAt("CONTATOS", (DBObject)(object)val4);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
					}
					else
					{
						val4 = (DBDictionary)val2.GetObject(val3.GetAt("CONTATOS"), (OpenMode)1);
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
					TypedValue[] array2 = new TypedValue[Information.UBound(mCONTATOS) * 8 + 1];
					array2[0] = new TypedValue(90, (object)iMaxIndice);
					int num = 0;
					int num2 = Information.UBound(mCONTATOS) * 8;
					for (int i = 1; i <= num2; i += 8)
					{
						num++;
						array2[i + 0] = new TypedValue(90, (object)mCONTATOS[num].iIndice);
						array2[i + 1] = new TypedValue(1, (object)mCONTATOS[num].sT1);
						array2[i + 2] = new TypedValue(1, (object)mCONTATOS[num].sT2);
						array2[i + 3] = new TypedValue(1, (object)mCONTATOS[num].sT3);
						array2[i + 4] = new TypedValue(90, (object)mCONTATOS[num].iT);
						array2[i + 5] = new TypedValue(90, (object)mCONTATOS[num].iComportamento);
						array2[i + 6] = new TypedValue(1, (object)mCONTATOS[num].sOrientacao.ToUpper());
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

	public static void OrdenaOsModelosDeDeDicionarioContatosAuxiliates(ref Declaracoes2.StructureContatosAuxiliares[] mContatos)
	{
		if (Information.UBound(mContatos) < 2)
		{
			return;
		}
		checked
		{
			int num = Information.UBound(mContatos) - 1;
			for (int i = num; i >= 1; i += -1)
			{
				int num2 = i;
				for (int j = 1; j <= num2; j++)
				{
					if (mContatos[j].iIndice > mContatos[j + 1].iIndice)
					{
						Declaracoes2.StructureContatosAuxiliares structureContatosAuxiliares = default;
						structureContatosAuxiliares = mContatos[j + 1];
						mContatos[j + 1] = mContatos[j];
						mContatos[j] = structureContatosAuxiliares;
					}
				}
			}
		}
	}

	public static bool LeOsContatosAuxiliarDoModeloDoDicionarioSemAbrirDWG(ref int iIndiceSelecionado, ref Declaracoes2.StructureContatosAuxiliares[] mCONTATOS, ref Database db)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected Obj, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected Obj, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected Obj, but got Unknown
		bool result = false;
		long num = 0L;
		Transaction val = db.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				DBDictionary val2 = (DBDictionary)val.GetObject(db.NamedObjectsDictionaryId, (OpenMode)0, false);
				DBDictionary val3;
				if (!val2.Contains("CONTATOS"))
				{
					val3 = null;
				}
				else
				{
					val3 = (DBDictionary)val.GetObject(val2.GetAt("CONTATOS"), (OpenMode)0);
					mCONTATOS = new Declaracoes2.StructureContatosAuxiliares[1];
					if (val3.Contains(Conversions.ToString(iIndiceSelecionado)))
					{
						ObjectId at = val3.GetAt(Conversions.ToString(iIndiceSelecionado));
						Xrecord val4 = (Xrecord)val.GetObject(at, (OpenMode)0);
						ResultBuffer data = val4.Data;
						TypedValue[] array = data.AsArray();
						int num2 = Information.UBound(array);
						for (int i = 1; i <= num2; i += 8)
						{
							num = Information.UBound(mCONTATOS) + 1;
							mCONTATOS = (Declaracoes2.StructureContatosAuxiliares[])Utils.CopyArray(mCONTATOS, new Declaracoes2.StructureContatosAuxiliares[(int)num + 1]);
							mCONTATOS[(int)num].iIndice = Conversions.ToInteger(array[i + 0].Value);
							mCONTATOS[(int)num].sT1 = Conversions.ToString(array[i + 1].Value);
							mCONTATOS[(int)num].sT2 = Conversions.ToString(array[i + 2].Value);
							mCONTATOS[(int)num].sT3 = Conversions.ToString(array[i + 3].Value);
							mCONTATOS[(int)num].iT = Conversions.ToInteger(array[i + 4].Value);
							object value = array[i + 4].Value;
							if (!Operators.ConditionalCompareObjectEqual(value, 1, TextCompare: true))
							{
								if (!Operators.ConditionalCompareObjectEqual(value, 2, TextCompare: true))
								{
									if (Operators.ConditionalCompareObjectEqual(value, 3, TextCompare: true))
									{
										mCONTATOS[(int)num].sTipo = "RV";
									}
								}
								else
								{
									mCONTATOS[(int)num].sTipo = "NF";
								}
							}
							else
							{
								mCONTATOS[(int)num].sTipo = "NA";
							}
							if (Operators.CompareString(mCONTATOS[(int)num].sT1, "", TextCompare: true) == 0)
							{
								mCONTATOS[(int)num].sT1 = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
							}
							if (Operators.CompareString(mCONTATOS[(int)num].sT2, "", TextCompare: true) == 0)
							{
								mCONTATOS[(int)num].sT2 = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
							}
							if (Operators.CompareString(mCONTATOS[(int)num].sTipo, "RV", TextCompare: true) == 0 && Operators.CompareString(mCONTATOS[(int)num].sT3, "", TextCompare: true) == 0)
							{
								mCONTATOS[(int)num].sT3 = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
							}
							mCONTATOS[(int)num].iComportamento = Conversions.ToInteger(array[i + 5].Value);
							object value2 = array[i + 5].Value;
							if (!Operators.ConditionalCompareObjectEqual(value2, 0, TextCompare: true))
							{
								if (!Operators.ConditionalCompareObjectEqual(value2, 1, TextCompare: true))
								{
									if (!Operators.ConditionalCompareObjectEqual(value2, 2, TextCompare: true))
									{
										if (!Operators.ConditionalCompareObjectEqual(value2, 3, TextCompare: true))
										{
											if (Operators.ConditionalCompareObjectEqual(value2, 4, TextCompare: true))
											{
												mCONTATOS[(int)num].sComportamento = "AM";
											}
										}
										else
										{
											mCONTATOS[(int)num].sComportamento = "BI";
										}
									}
									else
									{
										mCONTATOS[(int)num].sComportamento = "TD";
									}
								}
								else
								{
									mCONTATOS[(int)num].sComportamento = "TE";
								}
							}
							else
							{
								mCONTATOS[(int)num].sComportamento = "ST";
							}
							mCONTATOS[(int)num].sOrientacao = Conversions.ToString(array[i + 6].Value);
							mCONTATOS[(int)num].sUso = "";
						}
						result = true;
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				OrdenaOsModelosDeDeDicionarioContatosAuxiliates(ref mCONTATOS);
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

	public static string VerificaOrientacaoContato(string sTerm, string sOrientacao)
	{
		string text = "";
		checked
		{
			try
			{
				int num = 0;
				sTerm = sTerm.Replace(";;", ";");
				string[] array = sTerm.Split(';');
				int num2 = Information.UBound(array);
				for (int i = 0; i <= num2; i++)
				{
					if (Operators.CompareString(array[i].ToString().Trim(), "", TextCompare: true) != 0)
					{
						num++;
					}
				}
				sOrientacao = sOrientacao.ToUpper();
				sOrientacao = sOrientacao.Trim();
				string text2 = sOrientacao.Trim();
				text2 = text2.Replace("NN", "N");
				text2 = text2.Replace("SS", "S");
				text2 = text2.Replace("NS", "N");
				text2 = text2.Replace("SN", "S");
				int num3 = 0;
				int num4 = Strings.Len(text2);
				for (int j = 1; j <= num4; j++)
				{
					string text3 = Strings.Mid(text2, j, 1);
					if ((Operators.CompareString(text3, "N", TextCompare: true) == 0) | (Operators.CompareString(text3, "S", TextCompare: true) == 0) | (Operators.CompareString(text3, ";", TextCompare: true) == 0))
					{
						if ((Operators.CompareString(text3, "N", TextCompare: true) == 0) | (Operators.CompareString(text3, "S", TextCompare: true) == 0))
						{
							num3++;
						}
						if (num3 <= num)
						{
							text += text3;
						}
					}
				}
				text = text.Replace(";;", ";");
				if (Operators.CompareString(text, ";", TextCompare: true) == 0)
				{
					text = "";
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			return text;
		}
	}
}

using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Runtime;

namespace Eletron4;

public class DicionarioReguas
{
	public static void GravaOsModelosDeRegua(Declaracoes2.StructureModeloDeReguas[] mModelo)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected Obj, but got Unknown
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Expected Obj, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected Obj, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Expected Obj, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected Obj, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected Obj, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Expected Obj, but got Unknown
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
					if (!val3.Contains("REGUAS"))
					{
						val4 = new DBDictionary();
						val3.SetAt("REGUAS", (DBObject)(object)val4);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
					}
					else
					{
						val4 = (DBDictionary)val2.GetObject(val3.GetAt("REGUAS"), (OpenMode)1);
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
					int num = 0;
					int num2 = 0;
					int num3 = Information.UBound(mModelo) * 10;
					for (int i = 1; i <= num3; i += 10)
					{
						num2++;
						array2[i + 0] = new TypedValue(90, (object)mModelo[num2].indexRegua);
						array2[i + 1] = new TypedValue(1, (object)mModelo[num2].nomeRegua);
						array2[i + 2] = new TypedValue(1, (object)mModelo[num2].nomeAlternativo);
						array2[i + 3] = new TypedValue(90, (object)mModelo[num2].indexPainel);
						array2[i + 4] = new TypedValue(90, (object)0);
						array2[i + 5] = new TypedValue(90, (object)0);
						array2[i + 6] = new TypedValue(90, (object)0);
						array2[i + 7] = new TypedValue(90, (object)0);
						array2[i + 8] = new TypedValue(90, (object)0);
						array2[i + 9] = new TypedValue(1, (object)"");
						if (mModelo[num2].indexRegua > num)
						{
							num = mModelo[num2].indexRegua;
						}
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
		}
	}

	public static bool LeOsModelosDeRegua(ref Declaracoes2.StructureModeloDeReguas[] mModelo)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected Obj, but got Unknown
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected Obj, but got Unknown
		bool result = false;
		long num = 0L;
		mModelo = new Declaracoes2.StructureModeloDeReguas[1];
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				DBDictionary val2 = (DBDictionary)val.GetObject(database.NamedObjectsDictionaryId, (OpenMode)0, false);
				DBDictionary val3;
				if (!val2.Contains("REGUAS"))
				{
					val3 = null;
				}
				else
				{
					val3 = (DBDictionary)val.GetObject(val2.GetAt("REGUAS"), (OpenMode)0);
					if (val3.Contains("MODELOS2"))
					{
						ObjectId at = val3.GetAt("MODELOS2");
						Xrecord val4 = (Xrecord)val.GetObject(at, (OpenMode)0);
						ResultBuffer data = val4.Data;
						TypedValue[] array = data.AsArray();
						mModelo[0].iMaxIndice = 0;
						int num2 = Information.UBound(array);
						for (int i = 1; i <= num2; i += 10)
						{
							if (Conversions.ToInteger(array[i + 3].Value) > 0)
							{
								num = Information.UBound(mModelo) + 1;
								mModelo = (Declaracoes2.StructureModeloDeReguas[])Utils.CopyArray(mModelo, new Declaracoes2.StructureModeloDeReguas[(int)num + 1]);
								mModelo[(int)num].indexRegua = Conversions.ToInteger(array[i + 0].Value);
								mModelo[(int)num].nomeRegua = Conversions.ToString(array[i + 1].Value);
								mModelo[(int)num].nomeAlternativo = Conversions.ToString(array[i + 2].Value);
								mModelo[(int)num].indexPainel = Conversions.ToInteger(array[i + 3].Value);
								if (mModelo[(int)num].indexRegua > mModelo[0].iMaxIndice)
								{
									mModelo[0].iMaxIndice = mModelo[(int)num].indexRegua;
								}
							}
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

	public static void OrdenaOsModelosDeRegua(ref Declaracoes2.StructureModeloDeReguas[] mModeloDeReguas)
	{
		if (Information.UBound(mModeloDeReguas) < 2 || Information.UBound(mModeloDeReguas) <= 0)
		{
			return;
		}
		int num = Information.UBound(mModeloDeReguas);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				int num2 = Information.UBound(mModeloDeReguas) - 1;
				int num3 = i;
				for (int j = num2; j >= num3; j += -1)
				{
					if (Operators.CompareString(Dicionario.BuscaNomeDoPainel(mModeloDeReguas[j].indexPainel), Dicionario.BuscaNomeDoPainel(mModeloDeReguas[j + 1].indexPainel), TextCompare: true) > 0)
					{
						Declaracoes2.StructureModeloDeReguas structureModeloDeReguas = mModeloDeReguas[j + 1];
						mModeloDeReguas[j + 1] = mModeloDeReguas[j];
						mModeloDeReguas[j] = structureModeloDeReguas;
					}
					if (Operators.CompareString(Dicionario.BuscaNomeDoPainel(mModeloDeReguas[j].indexPainel), Dicionario.BuscaNomeDoPainel(mModeloDeReguas[j + 1].indexPainel), TextCompare: true) == 0 && Operators.CompareString(mModeloDeReguas[j].nomeRegua, mModeloDeReguas[j + 1].nomeRegua, TextCompare: true) > 0)
					{
						Declaracoes2.StructureModeloDeReguas structureModeloDeReguas2 = mModeloDeReguas[j + 1];
						mModeloDeReguas[j + 1] = mModeloDeReguas[j];
						mModeloDeReguas[j] = structureModeloDeReguas2;
					}
				}
			}
		}
	}

	public static bool LeOsModelosDeReguaSemAbrirDWG(ref Declaracoes2.StructureModeloDeReguas[] mModelo, ref Database db)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected Obj, but got Unknown
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected Obj, but got Unknown
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected Obj, but got Unknown
		bool result = false;
		long num = 0L;
		mModelo = new Declaracoes2.StructureModeloDeReguas[1];
		Transaction val = db.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				DBDictionary val2 = (DBDictionary)val.GetObject(db.NamedObjectsDictionaryId, (OpenMode)0, false);
				DBDictionary val3;
				if (!val2.Contains("REGUAS"))
				{
					val3 = null;
				}
				else
				{
					val3 = (DBDictionary)val.GetObject(val2.GetAt("REGUAS"), (OpenMode)0);
					if (val3.Contains("MODELOS2"))
					{
						ObjectId at = val3.GetAt("MODELOS2");
						Xrecord val4 = (Xrecord)val.GetObject(at, (OpenMode)0);
						ResultBuffer data = val4.Data;
						TypedValue[] array = data.AsArray();
						mModelo[0].iMaxIndice = 0;
						int num2 = Information.UBound(array);
						for (int i = 1; i <= num2; i += 10)
						{
							if (Conversions.ToInteger(array[i + 3].Value) > 0)
							{
								num = Information.UBound(mModelo) + 1;
								mModelo = (Declaracoes2.StructureModeloDeReguas[])Utils.CopyArray(mModelo, new Declaracoes2.StructureModeloDeReguas[(int)num + 1]);
								mModelo[(int)num].indexRegua = Conversions.ToInteger(array[i + 0].Value);
								mModelo[(int)num].nomeRegua = Conversions.ToString(array[i + 1].Value);
								mModelo[(int)num].nomeAlternativo = Conversions.ToString(array[i + 2].Value);
								mModelo[(int)num].indexPainel = Conversions.ToInteger(array[i + 3].Value);
								if (mModelo[(int)num].indexRegua > mModelo[0].iMaxIndice)
								{
									mModelo[0].iMaxIndice = mModelo[(int)num].indexRegua;
								}
							}
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

	public static string BuscaNomeDeUmaRegua(int indexRegua)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected Obj, but got Unknown
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected Obj, but got Unknown
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected Obj, but got Unknown
		string result = "";
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				DBDictionary val2 = (DBDictionary)val.GetObject(database.NamedObjectsDictionaryId, (OpenMode)0, false);
				DBDictionary val3;
				if (!val2.Contains("REGUAS"))
				{
					val3 = null;
				}
				else
				{
					val3 = (DBDictionary)val.GetObject(val2.GetAt("REGUAS"), (OpenMode)0);
					if (val3.Contains("MODELOS2"))
					{
						ObjectId at = val3.GetAt("MODELOS2");
						Xrecord val4 = (Xrecord)val.GetObject(at, (OpenMode)0);
						ResultBuffer data = val4.Data;
						TypedValue[] array = data.AsArray();
						int num = Information.UBound(array);
						for (int i = 1; i <= num; i += 10)
						{
							if (Conversions.ToInteger(array[i + 0].Value) == indexRegua)
							{
								result = Conversions.ToString(array[i + 1].Value);
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

	public static int BuscaIndiceDeUmaRegua(string nomeRegua, int pn)
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
		int result = 0;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				DBDictionary val2 = (DBDictionary)val.GetObject(database.NamedObjectsDictionaryId, (OpenMode)0, false);
				DBDictionary val3;
				if (!val2.Contains("REGUAS"))
				{
					val3 = null;
				}
				else
				{
					val3 = (DBDictionary)val.GetObject(val2.GetAt("REGUAS"), (OpenMode)0);
					if (val3.Contains("MODELOS2"))
					{
						ObjectId at = val3.GetAt("MODELOS2");
						Xrecord val4 = (Xrecord)val.GetObject(at, (OpenMode)0);
						ResultBuffer data = val4.Data;
						TypedValue[] array = data.AsArray();
						int num = Information.UBound(array);
						for (int i = 1; i <= num; i += 10)
						{
							if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(array[i + 1].Value, nomeRegua, TextCompare: true), Conversions.ToInteger(array[i + 3].Value) == pn)))
							{
								result = Conversions.ToInteger(array[i + 0].Value);
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
}

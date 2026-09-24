using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Runtime;

namespace Eletron4;

public class DicionarioBorne
{
	public static void gravaDicBornesReserva(int indexRegua, ref DeclaracoesEntidades.StructureBorne[] mBornes)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected Obj, but got Unknown
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected Obj, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected Obj, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Expected Obj, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected Obj, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected Obj, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_028a: Expected Obj, but got Unknown
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
					if (!val3.Contains("CENG_BORNES"))
					{
						val4 = new DBDictionary();
						val3.SetAt("CENG_BORNES", (DBObject)(object)val4);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
					}
					else
					{
						val4 = (DBDictionary)val2.GetObject(val3.GetAt("CENG_BORNES"), (OpenMode)1);
					}
					Xrecord val5;
					if (!val4.Contains(Conversions.ToString(indexRegua)))
					{
						TypedValue[] array = new TypedValue[1];
						ResultBuffer data = new ResultBuffer(array);
						val5 = new Xrecord();
						val5.Data = data;
						val4.SetAt(Conversions.ToString(indexRegua), (DBObject)(object)val5);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)val5, true);
					}
					else
					{
						ObjectId at = val4.GetAt(Conversions.ToString(indexRegua));
						val5 = (Xrecord)val2.GetObject(at, (OpenMode)1);
					}
					int upperBound = mBornes.GetUpperBound(0);
					TypedValue[] array2 = new TypedValue[10 * upperBound - 1 + 1];
					int num = 1;
					int num2 = 10 * upperBound - 1;
					for (int i = 0; i <= num2; i += 10)
					{
						array2[i] = new TypedValue(90, (object)0);
						array2[i + 1] = new TypedValue(1, (object)mBornes[num].Numero);
						array2[i + 2] = new TypedValue(1, (object)mBornes[num].Alternativo);
						array2[i + 3] = new TypedValue(40, (object)mBornes[num].Ordem);
						array2[i + 4] = new TypedValue(90, (object)mBornes[num].tipo);
						array2[i + 5] = new TypedValue(90, (object)mBornes[num].lm);
						array2[i + 6] = new TypedValue(290, (object)true);
						array2[i + 7] = new TypedValue(1, (object)mBornes[num].Orientacao);
						array2[i + 8] = new TypedValue(1, (object)mBornes[num].BlocoLayout);
						array2[i + 9] = new TypedValue(1, (object)"");
						num++;
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

	public static bool ExisteDicBornesReserva()
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
			if (val2.Contains("CENG_BORNES"))
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

	public static bool LeDicBornesReserva(int indexRegua, ref DeclaracoesEntidades.StructureBorne[] mBornes, ref int qSimples, ref int qDuplo, bool bExtra = false)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected Obj, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected Obj, but got Unknown
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected Obj, but got Unknown
		bool result = false;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				DBDictionary val2 = (DBDictionary)val.GetObject(database.NamedObjectsDictionaryId, (OpenMode)0, false);
				DBDictionary val3;
				if (!val2.Contains("CENG_BORNES"))
				{
					val3 = null;
				}
				else
				{
					val3 = (DBDictionary)val.GetObject(val2.GetAt("CENG_BORNES"), (OpenMode)0);
					if (val3.Contains(indexRegua.ToString()))
					{
						ObjectId at = val3.GetAt(indexRegua.ToString());
						Xrecord val4 = (Xrecord)val.GetObject(at, (OpenMode)0);
						ResultBuffer data = val4.Data;
						if (!(val4.Data == (ResultBuffer)null))
						{
							TypedValue[] array = data.AsArray();
							_ = (int)Math.Round((double)(array.GetUpperBound(0) + 1) / 10.0);
							int num = Information.UBound(array) - 1;
							for (int i = 0; i <= num; i += 10)
							{
								bool flag = true;
								int num2 = Information.UBound(mBornes);
								for (int j = 1; j <= num2; j++)
								{
									if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.CompareObjectEqual(mBornes[j].Ordem, array[i + 3].Value, TextCompare: true), Operators.CompareObjectEqual(mBornes[j].Numero, array[i + 1].Value, TextCompare: true)), mBornes[j].IndiceRegua == indexRegua)))
									{
										if (Operators.ConditionalCompareObjectLess(array[i + 4].Value, 10, TextCompare: true))
										{
											flag = false;
										}
										break;
									}
								}
								if (!flag || !Conversions.ToBoolean(Operators.OrObject(Operators.OrObject(Operators.CompareObjectEqual(array[i + 4].Value, 0, TextCompare: true), Operators.CompareObjectEqual(array[i + 4].Value, 1, TextCompare: true)), Operators.CompareObjectEqual(array[i + 4].Value, 2, TextCompare: true))))
								{
									continue;
								}
								int num3 = Information.UBound(mBornes) + 1;
								mBornes = (DeclaracoesEntidades.StructureBorne[])Utils.CopyArray(mBornes, new DeclaracoesEntidades.StructureBorne[num3 + 1]);
								mBornes[num3].Numero = Conversions.ToString(array[i + 1].Value);
								mBornes[num3].Alternativo = Conversions.ToString(array[i + 2].Value);
								mBornes[num3].Ordem = Conversions.ToDouble(array[i + 3].Value);
								mBornes[num3].tipo = Conversions.ToInteger(array[i + 4].Value);
								if (mBornes[num3].tipo != 0)
								{
									if (mBornes[num3].tipo == 1)
									{
										qDuplo++;
									}
								}
								else
								{
									qSimples++;
								}
								mBornes[num3].lm = Conversions.ToInteger(array[i + 5].Value);
								mBornes[num3].reserva = Conversions.ToBoolean(array[i + 6].Value);
								mBornes[num3].Orientacao = Conversions.ToString(array[i + 7].Value);
								mBornes[num3].BlocoLayout = Conversions.ToString(array[i + 8].Value);
								int tipo = mBornes[num3].tipo;
								if (unchecked((uint)tipo) <= 1u)
								{
									mBornes[num3].pagina = DeclaracoesGeral.mMensagem[1, 1050].ToString().ToUpper();
								}
								else if (tipo == 2)
								{
									mBornes[num3].pagina = DeclaracoesGeral.mMensagem[1, 1890].ToString().ToUpper();
								}
								mBornes[num3].sPagina = "100000";
								mBornes[num3].iLinha = 100000;
								mBornes[num3].iColuna = 100000;
								mBornes[num3].IndiceRegua = indexRegua;
								num3++;
							}
							result = true;
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

	public static bool LeDicBornesReservaEXTRAS(int indexRegua, ref DeclaracoesEntidades.StructureBorne[] mBornes, ref int qSimples, ref int qDuplo, bool bExtra = false)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected Obj, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected Obj, but got Unknown
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected Obj, but got Unknown
		bool result = false;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				DBDictionary val2 = (DBDictionary)val.GetObject(database.NamedObjectsDictionaryId, (OpenMode)0, false);
				DBDictionary val3;
				if (!val2.Contains("CENG_BORNES"))
				{
					val3 = null;
				}
				else
				{
					val3 = (DBDictionary)val.GetObject(val2.GetAt("CENG_BORNES"), (OpenMode)0);
					if (val3.Contains(indexRegua.ToString()))
					{
						ObjectId at = val3.GetAt(indexRegua.ToString());
						Xrecord val4 = (Xrecord)val.GetObject(at, (OpenMode)0);
						ResultBuffer data = val4.Data;
						if (!(val4.Data == (ResultBuffer)null))
						{
							TypedValue[] array = data.AsArray();
							_ = (int)Math.Round((double)(array.GetUpperBound(0) + 1) / 10.0);
							int num = Information.UBound(array) - 1;
							for (int i = 0; i <= num; i += 10)
							{
								bool flag = true;
								int num2 = Information.UBound(mBornes);
								for (int j = 1; j <= num2; j++)
								{
									if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.CompareObjectEqual(mBornes[j].Ordem, array[i + 3].Value, TextCompare: true), Operators.CompareObjectEqual(mBornes[j].Numero, array[i + 1].Value, TextCompare: true)), mBornes[j].IndiceRegua == indexRegua)))
									{
										if (Operators.ConditionalCompareObjectLess(array[i + 4].Value, 10, TextCompare: true))
										{
											flag = false;
										}
										break;
									}
								}
								if (!flag || !Operators.ConditionalCompareObjectEqual(array[i + 4].Value, 2, TextCompare: true))
								{
									continue;
								}
								int num3 = Information.UBound(mBornes) + 1;
								mBornes = (DeclaracoesEntidades.StructureBorne[])Utils.CopyArray(mBornes, new DeclaracoesEntidades.StructureBorne[num3 + 1]);
								mBornes[num3].Numero = Conversions.ToString(array[i + 1].Value);
								mBornes[num3].Alternativo = Conversions.ToString(array[i + 2].Value);
								mBornes[num3].Ordem = Conversions.ToDouble(array[i + 3].Value);
								mBornes[num3].tipo = Conversions.ToInteger(array[i + 4].Value);
								if (mBornes[num3].tipo != 0)
								{
									if (mBornes[num3].tipo == 1)
									{
										qDuplo++;
									}
								}
								else
								{
									qSimples++;
								}
								mBornes[num3].lm = Conversions.ToInteger(array[i + 5].Value);
								mBornes[num3].reserva = Conversions.ToBoolean(array[i + 6].Value);
								mBornes[num3].Orientacao = Conversions.ToString(array[i + 7].Value);
								mBornes[num3].BlocoLayout = Conversions.ToString(array[i + 8].Value);
								mBornes[num3].pagina = DeclaracoesGeral.mMensagem[1, 1890].ToString().ToUpper();
								mBornes[num3].sPagina = "100000";
								mBornes[num3].iLinha = 100000;
								mBornes[num3].iColuna = 100000;
								mBornes[num3].IndiceRegua = indexRegua;
								num3++;
							}
							result = true;
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

	public static bool LeOrdemDicBornesReserva(int indexRegua, ref List<int> lOrdem)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected Obj, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected Obj, but got Unknown
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected Obj, but got Unknown
		bool result = false;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				DBDictionary val2 = (DBDictionary)val.GetObject(database.NamedObjectsDictionaryId, (OpenMode)0, false);
				DBDictionary val3;
				if (!val2.Contains("CENG_BORNES"))
				{
					val3 = null;
				}
				else
				{
					val3 = (DBDictionary)val.GetObject(val2.GetAt("CENG_BORNES"), (OpenMode)0);
					if (val3.Contains(indexRegua.ToString()))
					{
						ObjectId at = val3.GetAt(indexRegua.ToString());
						Xrecord val4 = (Xrecord)val.GetObject(at, (OpenMode)0);
						ResultBuffer data = val4.Data;
						if (!(val4.Data == (ResultBuffer)null))
						{
							TypedValue[] array = data.AsArray();
							_ = (int)Math.Round((double)(array.GetUpperBound(0) + 1) / 10.0);
							int num = Information.UBound(array) - 1;
							for (int i = 0; i <= num; i += 10)
							{
								lOrdem.Add(Conversions.ToInteger(array[i + 3].Value));
								result = true;
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

	public static bool LeDicBornesReservaTodos(int indexRegua, ref DeclaracoesEntidades.StructureBorne[] mBornes)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected Obj, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected Obj, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected Obj, but got Unknown
		bool result = false;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				DBDictionary val2 = (DBDictionary)val.GetObject(database.NamedObjectsDictionaryId, (OpenMode)0, false);
				DBDictionary val3;
				if (!val2.Contains("CENG_BORNES"))
				{
					val3 = null;
				}
				else
				{
					val3 = (DBDictionary)val.GetObject(val2.GetAt("CENG_BORNES"), (OpenMode)0);
					if (val3.Contains(Conversions.ToString(indexRegua)))
					{
						ObjectId at = val3.GetAt(Conversions.ToString(indexRegua));
						Xrecord val4 = (Xrecord)val.GetObject(at, (OpenMode)0);
						ResultBuffer data = val4.Data;
						if (!(val4.Data == (ResultBuffer)null))
						{
							TypedValue[] array = data.AsArray();
							_ = (int)Math.Round((double)(array.GetUpperBound(0) + 1) / 10.0);
							int num = Information.UBound(array) - 1;
							for (int i = 0; i <= num; i += 10)
							{
								int num2 = Information.UBound(mBornes) + 1;
								mBornes = (DeclaracoesEntidades.StructureBorne[])Utils.CopyArray(mBornes, new DeclaracoesEntidades.StructureBorne[num2 + 1]);
								mBornes[num2].Numero = Conversions.ToString(array[i + 1].Value);
								mBornes[num2].Alternativo = Conversions.ToString(array[i + 2].Value);
								mBornes[num2].Ordem = Conversions.ToDouble(array[i + 3].Value);
								mBornes[num2].tipo = Conversions.ToInteger(array[i + 4].Value);
								switch (mBornes[num2].tipo)
								{
								case 0:
								case 1:
									mBornes[num2].pagina = DeclaracoesGeral.mMensagem[1, 1050].ToString().ToUpper();
									break;
								case 2:
									mBornes[num2].pagina = DeclaracoesGeral.mMensagem[1, 1890].ToString().ToUpper();
									break;
								}
								mBornes[num2].lm = Conversions.ToInteger(array[i + 5].Value);
								mBornes[num2].reserva = Conversions.ToBoolean(array[i + 6].Value);
								mBornes[num2].Orientacao = Conversions.ToString(array[i + 7].Value);
								mBornes[num2].BlocoLayout = Conversions.ToString(array[i + 8].Value);
								mBornes[num2].sPagina = "100000";
								mBornes[num2].iLinha = 100000;
								mBornes[num2].iColuna = 100000;
								mBornes[num2].IndiceRegua = indexRegua;
								mBornes[num2].CaboOrigem = "";
								mBornes[num2].conector = "";
								mBornes[num2].data = "";
								mBornes[num2].Handle = "";
								mBornes[num2].NomePainel = "";
								mBornes[num2].NomeRegua = "";
								mBornes[num2].NumeroComplem = "";
								mBornes[num2].user = "";
								num2++;
							}
							result = true;
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

	public static bool LeDicBornesReservaTodosSemAbrirDWG(int indexRegua, ref DeclaracoesEntidades.StructureBorne[] mBornes, ref Database db)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected Obj, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected Obj, but got Unknown
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected Obj, but got Unknown
		bool result = false;
		Transaction val = db.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				DBDictionary val2 = (DBDictionary)val.GetObject(db.NamedObjectsDictionaryId, (OpenMode)0, false);
				DBDictionary val3;
				if (!val2.Contains("CENG_BORNES"))
				{
					val3 = null;
				}
				else
				{
					val3 = (DBDictionary)val.GetObject(val2.GetAt("CENG_BORNES"), (OpenMode)0);
					if (val3.Contains(Conversions.ToString(indexRegua)))
					{
						ObjectId at = val3.GetAt(Conversions.ToString(indexRegua));
						Xrecord val4 = (Xrecord)val.GetObject(at, (OpenMode)0);
						if (!(val4.Data == (ResultBuffer)null))
						{
							ResultBuffer data = val4.Data;
							TypedValue[] array = data.AsArray();
							_ = (int)Math.Round((double)(array.GetUpperBound(0) + 1) / 10.0);
							int num = Information.UBound(array) - 1;
							for (int i = 0; i <= num; i += 10)
							{
								int num2 = Information.UBound(mBornes) + 1;
								mBornes = (DeclaracoesEntidades.StructureBorne[])Utils.CopyArray(mBornes, new DeclaracoesEntidades.StructureBorne[num2 + 1]);
								mBornes[num2].Numero = Conversions.ToString(array[i + 1].Value);
								mBornes[num2].Alternativo = Conversions.ToString(array[i + 2].Value);
								mBornes[num2].Ordem = Conversions.ToDouble(array[i + 3].Value);
								mBornes[num2].tipo = Conversions.ToInteger(array[i + 4].Value);
								mBornes[num2].lm = Conversions.ToInteger(array[i + 5].Value);
								mBornes[num2].reserva = Conversions.ToBoolean(array[i + 6].Value);
								mBornes[num2].Orientacao = Conversions.ToString(array[i + 7].Value);
								mBornes[num2].BlocoLayout = Conversions.ToString(array[i + 8].Value);
								mBornes[num2].pagina = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1050]);
								mBornes[num2].sPagina = "100000";
								mBornes[num2].iLinha = 100000;
								mBornes[num2].iColuna = 100000;
								mBornes[num2].IndiceRegua = indexRegua;
								mBornes[num2].CaboOrigem = "";
								mBornes[num2].conector = "";
								mBornes[num2].data = "";
								mBornes[num2].Handle = "";
								mBornes[num2].NomePainel = "";
								mBornes[num2].NomeRegua = "";
								mBornes[num2].NumeroComplem = "";
								mBornes[num2].user = "";
								num2++;
							}
							result = true;
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

	public static int BuscaPainelDoBorneNoDicionario(ref int iRegua, [Optional][DefaultParameterValue("")] ref string sRegua, [Optional][DefaultParameterValue("")] ref string sAlternativo)
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
						if (!(val4.Data == (ResultBuffer)null))
						{
							TypedValue[] array = data.AsArray();
							int num = Conversions.ToInteger(Operators.MultiplyObject(array[0].Value, 10));
							int num2 = num - 1;
							for (int i = 1; i <= num2; i += 10)
							{
								if (Operators.ConditionalCompareObjectEqual(array[i].Value, iRegua, TextCompare: true))
								{
									sRegua = Conversions.ToString(array[i + 1].Value);
									sAlternativo = Conversions.ToString(array[i + 2].Value);
									result = Conversions.ToInteger(array[i + 3].Value);
									break;
								}
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

	public static int BuscaLMdaRegua(ref int iRegua, ref string stipo)
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
						if (!(val4.Data == (ResultBuffer)null))
						{
							TypedValue[] array = data.AsArray();
							int num = Conversions.ToInteger(Operators.MultiplyObject(array[0].Value, 10));
							int num2 = num - 1;
							for (int i = 1; i <= num2; i += 10)
							{
								if (Operators.ConditionalCompareObjectEqual(array[i].Value, iRegua, TextCompare: true))
								{
									if (Conversions.ToDouble(stipo) == 0.0)
									{
										result = Conversions.ToInteger(array[i + 6].Value);
									}
									if (Conversions.ToDouble(stipo) == 1.0)
									{
										result = Conversions.ToInteger(array[i + 7].Value);
									}
									break;
								}
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

	public static bool BuscaBornesReserva(int indexRegua, ref string numBorne, ref int ordem)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Obj, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected Obj, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected Obj, but got Unknown
		bool result = false;
		ordem = 0;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				DBDictionary val2 = (DBDictionary)val.GetObject(database.NamedObjectsDictionaryId, (OpenMode)0, false);
				DBDictionary val3;
				if (!val2.Contains("CENG_BORNES"))
				{
					val3 = null;
				}
				else
				{
					val3 = (DBDictionary)val.GetObject(val2.GetAt("CENG_BORNES"), (OpenMode)0);
					if (val3.Contains(Conversions.ToString(indexRegua)))
					{
						ObjectId at = val3.GetAt(Conversions.ToString(indexRegua));
						Xrecord val4 = (Xrecord)val.GetObject(at, (OpenMode)0);
						ResultBuffer data = val4.Data;
						if (!(val4.Data == (ResultBuffer)null))
						{
							TypedValue[] array = data.AsArray();
							_ = (int)Math.Round((double)(array.GetUpperBound(0) + 1) / 10.0);
							int num = Information.UBound(array) - 1;
							for (int i = 0; i <= num; i += 10)
							{
								if (Operators.ConditionalCompareObjectEqual(array[i + 1].Value, numBorne, TextCompare: true))
								{
									ordem = Conversions.ToInteger(array[i + 3].Value);
									result = true;
									break;
								}
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

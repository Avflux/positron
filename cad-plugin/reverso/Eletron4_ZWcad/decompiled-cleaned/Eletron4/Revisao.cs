using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.Runtime;

namespace Eletron4;

public class Revisao
{
	public static void capturaRevisoesSimplificadasNova()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected Obj, but got Unknown
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected Obj, but got Unknown
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected Obj, but got Unknown
		DeclaracoesGeral.dicRevSimplificadaNova = new Dictionary<string, string>();
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
			BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
			BlockTableRecordEnumerator enumerator = default;
			try
			{
				enumerator = val3.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ObjectId current = enumerator.Current;
					Entity val4 = (Entity)val.GetObject(current, (OpenMode)0);
					DBText text = (DBText)(object)((val4 is DBText) ? val4 : null);
					if (!((DisposableWrapper)(object)text != (DisposableWrapper)null))
					{
						continue;
					}
					int num = XDataGeral.LeXDataTitulo(ref text);
					if (num == 8)
					{
						string textString = text.TextString;
						if (!DeclaracoesGeral.dicRevSimplificadaNova.ContainsKey(val4.Layer.ToString()))
						{
							DeclaracoesGeral.dicRevSimplificadaNova.Add(val4.Layer.ToString(), textString);
						}
					}
				}
			}
			finally
			{
				((IDisposable)enumerator)?.Dispose();
			}
			DeclaracoesGeral.bAnularEventos = true;
			val.Commit();
			DeclaracoesGeral.bAnularEventos = false;
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

	public static void capturaRevisoesSimplificadas()
	{
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected Obj, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected Obj, but got Unknown
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected Obj, but got Unknown
		checked
		{
			DeclaracoesGeral.mRevSimplificada = new object[2, Information.UBound(DeclaracoesGeral.mPaginas, 2) + 1];
			int num = Information.UBound(DeclaracoesGeral.mPaginas, 2);
			for (int i = 1; i <= num; i++)
			{
				DeclaracoesGeral.mRevSimplificada[0, i] = RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mPaginas[0, i]);
				DeclaracoesGeral.mRevSimplificada[1, i] = "";
			}
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val3.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val4 = (Entity)val.GetObject(current, (OpenMode)0);
						DBText text = (DBText)(object)((val4 is DBText) ? val4 : null);
						if (!((DisposableWrapper)(object)text != (DisposableWrapper)null))
						{
							continue;
						}
						int num2 = XDataGeral.LeXDataTitulo(ref text);
						if (num2 != 8)
						{
							continue;
						}
						string textString = text.TextString;
						int num3 = Information.UBound(DeclaracoesGeral.mRevSimplificada, 2);
						for (int j = 1; j <= num3; j++)
						{
							if (Operators.ConditionalCompareObjectEqual(val4.Layer.ToString(), DeclaracoesGeral.mRevSimplificada[0, j], TextCompare: true))
							{
								DeclaracoesGeral.mRevSimplificada[1, j] = textString;
								break;
							}
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				DeclaracoesGeral.bAnularEventos = true;
				val.Commit();
				DeclaracoesGeral.bAnularEventos = false;
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
	}

	public static void AtualizaRevSimplificada()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val4.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
						DBText text = (DBText)(object)((val5 is DBText) ? val5 : null);
						if (!((DisposableWrapper)(object)text != (DisposableWrapper)null))
						{
							continue;
						}
						int num = XDataGeral.LeXDataTitulo(ref text);
						if (num != 8)
						{
							continue;
						}
						string text2 = "";
						int num2 = Information.UBound(DeclaracoesGeral.mRevSimplificada, 2);
						for (int i = 1; i <= num2; i = checked(i + 1))
						{
							if (Operators.ConditionalCompareObjectEqual(DeclaracoesGeral.mRevSimplificada[0, i], ((Entity)text).Layer, TextCompare: true))
							{
								text2 = Conversions.ToString(DeclaracoesGeral.mRevSimplificada[1, i]);
								((DBObject)text).UpgradeOpen();
								text.TextString = text2;
								XDataGeral.gravarXDataTitulo(ref text, num, text2);
								break;
							}
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
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
	}

	public static void capturaRevisoesCompletas()
	{
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected Obj, but got Unknown
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected Obj, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected Obj, but got Unknown
		checked
		{
			DeclaracoesGeral.mRevCompleta = new DeclaracoesGeral.Revisoes[Information.UBound(DeclaracoesGeral.mPaginas, 2) + 1];
			int num = Information.UBound(DeclaracoesGeral.mPaginas, 2);
			for (int i = 1; i <= num; i++)
			{
				DeclaracoesGeral.mRevCompleta[i].Pagina = Conversions.ToString(DeclaracoesGeral.mPaginas[0, i]);
				DeclaracoesGeral.mRevCompleta[i].Posicao = 0;
				DeclaracoesGeral.mRevCompleta[i].Revisao = "";
				DeclaracoesGeral.mRevCompleta[i].RevisaoOriginal = "";
			}
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val3.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val4 = (Entity)val.GetObject(current, (OpenMode)0);
						BlockReference blockRef = (BlockReference)(object)((val4 is BlockReference) ? val4 : null);
						if (blockRef == null)
						{
							continue;
						}
						DeclaracoesGeral.Revisoes revC = default;
						if (!XDataGeral.LeXDataRevisao(ref blockRef, ref revC))
						{
							continue;
						}
						int num2 = Information.UBound(DeclaracoesGeral.mRevCompleta);
						for (int j = 1; j <= num2; j++)
						{
							if (Operators.CompareString(val4.Layer.ToString(), DeclaracoesGeral.mRevCompleta[j].Pagina, TextCompare: true) == 0 && revC.Posicao > DeclaracoesGeral.mRevCompleta[j].Posicao)
							{
								DeclaracoesGeral.mRevCompleta[j].Posicao = revC.Posicao;
								DeclaracoesGeral.mRevCompleta[j].RevisaoOriginal = revC.RevisaoOriginal;
								DeclaracoesGeral.mRevCompleta[j].Revisao = revC.Revisao;
								DeclaracoesGeral.mRevCompleta[j].Descricao = revC.Descricao;
								DeclaracoesGeral.mRevCompleta[j].Elaborador = revC.Elaborador;
								DeclaracoesGeral.mRevCompleta[j].Verificador = revC.Verificador;
								DeclaracoesGeral.mRevCompleta[j].Aprovador = revC.Aprovador;
								DeclaracoesGeral.mRevCompleta[j].Data = revC.Data;
								break;
							}
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				DeclaracoesGeral.bAnularEventos = true;
				val.Commit();
				DeclaracoesGeral.bAnularEventos = false;
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
	}

	private static void JLbp1hmRF2d(ref DeclaracoesGeral.Revisoes[] P_0, string P_1)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected Obj, but got Unknown
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
			BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
			BlockTableRecordEnumerator enumerator = default;
			try
			{
				enumerator = val3.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ObjectId current = enumerator.Current;
					Entity val4 = (Entity)val.GetObject(current, (OpenMode)0);
					if (Operators.CompareString(val4.Layer.ToString(), P_1, TextCompare: true) != 0)
					{
						continue;
					}
					BlockReference blockRef = (BlockReference)(object)((val4 is BlockReference) ? val4 : null);
					if (blockRef != null)
					{
						DeclaracoesGeral.Revisoes revC = default;
						if (XDataGeral.LeXDataRevisao(ref blockRef, ref revC))
						{
							P_0 = (DeclaracoesGeral.Revisoes[])Utils.CopyArray(P_0, new DeclaracoesGeral.Revisoes[checked(Information.UBound(P_0) + 1 + 1)]);
							P_0[Information.UBound(P_0)] = revC;
							P_0[Information.UBound(P_0)].Pagina = P_1;
						}
					}
				}
			}
			finally
			{
				((IDisposable)enumerator)?.Dispose();
			}
			DeclaracoesGeral.bAnularEventos = true;
			val.Commit();
			DeclaracoesGeral.bAnularEventos = false;
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

	public static void AtualizaRevCompleta()
	{
		checked
		{
			try
			{
				string layer = Pagina.retornaNumeroCapa();
				int num = DeclaracoesGeral.Conf.maxCapa - 1;
				for (int i = 0; i <= num; i++)
				{
					verificaCriaBlocoRevisao(layer, i.ToString());
				}
				int num2 = DeclaracoesGeral.Conf.maxCorpo - 1;
				for (int j = 0; j <= num2; j++)
				{
					verificaCriaBlocoRevisao("-1", j.ToString());
				}
				int num3 = 0;
				int num4 = Information.UBound(DeclaracoesGeral.mRevCompleta);
				for (int k = 1; k <= num4; k++)
				{
					if (Operators.CompareString(DeclaracoesGeral.mRevCompleta[k].Revisao.Trim(), "", TextCompare: true) == 0)
					{
						continue;
					}
					num3 = (Pagina.checaCapa(DeclaracoesGeral.mRevCompleta[k].Pagina) ? DeclaracoesGeral.Conf.maxCapa : DeclaracoesGeral.Conf.maxCorpo);
					if (!((Operators.CompareString(DeclaracoesGeral.mRevCompleta[k].Revisao, DeclaracoesGeral.mRevCompleta[k].RevisaoOriginal, TextCompare: true) == 0) & (DeclaracoesGeral.mRevCompleta[k].Posicao > 0)))
					{
						if (DeclaracoesGeral.mRevCompleta[k].Posicao >= num3)
						{
							DeclaracoesGeral.Revisoes[] array = new DeclaracoesGeral.Revisoes[1];
							JLbp1hmRF2d(ref array, DeclaracoesGeral.mRevCompleta[k].Pagina);
							int num5 = Information.UBound(array);
							for (int l = 1; l <= num5; l++)
							{
								LK3p1o8pTVH(array[l].Posicao, array[l].Pagina);
							}
							int num6 = Information.UBound(array);
							for (int m = 1; m <= num6; m++)
							{
								if (array[m].Posicao > 1)
								{
									array[m].Posicao--;
									JdCp1GqFmnk(array[m]);
								}
							}
							JdCp1GqFmnk(DeclaracoesGeral.mRevCompleta[k]);
						}
						else
						{
							DeclaracoesGeral.mRevCompleta[k].Posicao++;
							JdCp1GqFmnk(DeclaracoesGeral.mRevCompleta[k]);
						}
					}
					else
					{
						LK3p1o8pTVH(DeclaracoesGeral.mRevCompleta[k].Posicao, DeclaracoesGeral.mRevCompleta[k].Pagina);
						JdCp1GqFmnk(DeclaracoesGeral.mRevCompleta[k]);
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	private static void LK3p1o8pTVH(int P_0, string P_1)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val4.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
						try
						{
							if (Operators.CompareString(val5.Layer.ToString(), P_1, TextCompare: true) != 0)
							{
								continue;
							}
							BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
							try
							{
								if (val6 != null)
								{
									DeclaracoesGeral.Revisoes revC = default;
									BlockReference blockRef = val6;
									if (XDataGeral.LeXDataRevisao(ref blockRef, ref revC) && revC.Posicao == P_0)
									{
										((DBObject)val5).UpgradeOpen();
										((DBObject)val5).Erase();
										break;
									}
								}
							}
							finally
							{
								((IDisposable)val6)?.Dispose();
							}
						}
						finally
						{
							((IDisposable)val5)?.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
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
	}

	private static void JdCp1GqFmnk(DeclaracoesGeral.Revisoes P_0)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected Obj, but got Unknown
		//IL_05ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected Obj, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected Obj, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected Obj, but got Unknown
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected Obj, but got Unknown
		//IL_05e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05eb: Expected Obj, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected Obj, but got Unknown
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected Obj, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0554: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				string text = "";
				text = checked(Pagina.checaCapa(P_0.Pagina) ? ("Revisao_Capa" + (P_0.Posicao - 1)) : ("Revisao_Corpo" + (P_0.Posicao - 1)));
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				ObjectId val4 = default;
				if (((SymbolTable)val3).Has(text))
				{
					val4 = ((SymbolTable)val3)[text];
				}
				BlockReference val5 = new BlockReference(Point3d.Origin, val4);
				((Entity)val5).Layer = P_0.Pagina;
				BlockTableRecord val6 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				val6.AppendEntity((Entity)(object)val5);
				DeclaracoesGeral.bAnularEventos = true;
				val2.AddNewlyCreatedDBObject((DBObject)(object)val5, true);
				BlockTableRecord val7 = (BlockTableRecord)val2.GetObject(val4, (OpenMode)0);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val7.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val8 = (Entity)val2.GetObject(current, (OpenMode)0);
						try
						{
							if (!(val8 is AttributeDefinition))
							{
								continue;
							}
							AttributeReference val9 = new AttributeReference();
							AttributeDefinition val10 = (AttributeDefinition)val8;
							try
							{
								val9.SetAttributeFromBlock(val10, val5.BlockTransform);
								string left = Strings.UCase(val9.Tag);
								if (Operators.CompareString(left, "REV0", TextCompare: true) != 0 && Operators.CompareString(left, "REV1", TextCompare: true) != 0 && Operators.CompareString(left, "REV2", TextCompare: true) != 0 && Operators.CompareString(left, "REV3", TextCompare: true) != 0 && Operators.CompareString(left, "REV4", TextCompare: true) != 0 && Operators.CompareString(left, "REV5", TextCompare: true) != 0 && Operators.CompareString(left, "REV6", TextCompare: true) != 0 && Operators.CompareString(left, "REV7", TextCompare: true) != 0)
								{
									if (Operators.CompareString(left, "DESC0", TextCompare: true) != 0 && Operators.CompareString(left, "DESC1", TextCompare: true) != 0 && Operators.CompareString(left, "DESC2", TextCompare: true) != 0 && Operators.CompareString(left, "DESC3", TextCompare: true) != 0 && Operators.CompareString(left, "DESC4", TextCompare: true) != 0 && Operators.CompareString(left, "DESC5", TextCompare: true) != 0 && Operators.CompareString(left, "DESC6", TextCompare: true) != 0 && Operators.CompareString(left, "DESC7", TextCompare: true) != 0)
									{
										if (Operators.CompareString(left, "DATA0", TextCompare: true) != 0 && Operators.CompareString(left, "DATA1", TextCompare: true) != 0 && Operators.CompareString(left, "DATA2", TextCompare: true) != 0 && Operators.CompareString(left, "DATA3", TextCompare: true) != 0 && Operators.CompareString(left, "DATA4", TextCompare: true) != 0 && Operators.CompareString(left, "DATA5", TextCompare: true) != 0 && Operators.CompareString(left, "DATA6", TextCompare: true) != 0 && Operators.CompareString(left, "DATA7", TextCompare: true) != 0)
										{
											if (Operators.CompareString(left, "ELAB0", TextCompare: true) != 0 && Operators.CompareString(left, "ELAB1", TextCompare: true) != 0 && Operators.CompareString(left, "ELAB2", TextCompare: true) != 0 && Operators.CompareString(left, "ELAB3", TextCompare: true) != 0 && Operators.CompareString(left, "ELAB4", TextCompare: true) != 0 && Operators.CompareString(left, "ELAB5", TextCompare: true) != 0 && Operators.CompareString(left, "ELAB6", TextCompare: true) != 0 && Operators.CompareString(left, "ELAB7", TextCompare: true) != 0)
											{
												if (Operators.CompareString(left, "VERIF0", TextCompare: true) != 0 && Operators.CompareString(left, "VERIF1", TextCompare: true) != 0 && Operators.CompareString(left, "VERIF2", TextCompare: true) != 0 && Operators.CompareString(left, "VERIF3", TextCompare: true) != 0 && Operators.CompareString(left, "VERIF4", TextCompare: true) != 0 && Operators.CompareString(left, "VERIF5", TextCompare: true) != 0 && Operators.CompareString(left, "VERIF6", TextCompare: true) != 0 && Operators.CompareString(left, "VERIF7", TextCompare: true) != 0)
												{
													if (Operators.CompareString(left, "APROV0", TextCompare: true) == 0 || Operators.CompareString(left, "APROV1", TextCompare: true) == 0 || Operators.CompareString(left, "APROV2", TextCompare: true) == 0 || Operators.CompareString(left, "APROV3", TextCompare: true) == 0 || Operators.CompareString(left, "APROV4", TextCompare: true) == 0 || Operators.CompareString(left, "APROV5", TextCompare: true) == 0 || Operators.CompareString(left, "APROV6", TextCompare: true) == 0 || Operators.CompareString(left, "APROV7", TextCompare: true) == 0)
													{
														((DBText)val9).TextString = P_0.Aprovador;
													}
												}
												else
												{
													((DBText)val9).TextString = P_0.Verificador;
												}
											}
											else
											{
												((DBText)val9).TextString = P_0.Elaborador;
											}
										}
										else
										{
											((DBText)val9).TextString = P_0.Data;
										}
									}
									else
									{
										((DBText)val9).TextString = P_0.Descricao;
									}
								}
								else
								{
									((DBText)val9).TextString = P_0.Revisao;
								}
								((DBText)val9).AdjustAlignment(database);
								val5.AttributeCollection.AppendAttribute(val9);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val9, true);
								((Entity)val9).Draw();
							}
							finally
							{
								((IDisposable)val10)?.Dispose();
							}
						}
						finally
						{
							((IDisposable)val8)?.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				Entity ent = (Entity)(object)val5;
				XDataGeral.gravarXDataRevisao(ref ent, P_0);
				val5 = (BlockReference)ent;
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

	public static void verificaCriaBlocoRevisao(string layer, string tipo)
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected Obj, but got Unknown
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected Obj, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected Obj, but got Unknown
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected Obj, but got Unknown
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Expected Obj, but got Unknown
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected Obj, but got Unknown
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected Obj, but got Unknown
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Expected Obj, but got Unknown
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			try
			{
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					string text = "";
					if (!Pagina.checaCapa(layer))
					{
						if (Operators.CompareString(layer, "-1", TextCompare: true) == 0)
						{
							text = "Revisao_Corpo" + tipo;
						}
					}
					else
					{
						text = "Revisao_Capa" + tipo;
					}
					try
					{
						BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)1, false, true);
						try
						{
							BlockTableRecord val4;
							if (!((SymbolTable)val3).Has(text))
							{
								val4 = new BlockTableRecord();
								((SymbolTableRecord)val4).Name = text;
								((SymbolTable)val3).Add((SymbolTableRecord)(object)val4);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
							}
							else
							{
								val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[text], (OpenMode)1);
								BlockTableRecordEnumerator enumerator = default;
								try
								{
									enumerator = val4.GetEnumerator();
									while (enumerator.MoveNext())
									{
										ObjectId current = enumerator.Current;
										Entity val5 = (Entity)current.GetObject((OpenMode)1);
										try
										{
											((DBObject)val5).Erase();
										}
										finally
										{
											((IDisposable)val5)?.Dispose();
										}
									}
								}
								finally
								{
									((IDisposable)enumerator)?.Dispose();
								}
							}
							if (((SymbolTable)val3).Has(DeclaracoesGeral.blockFormatoName))
							{
								ObjectId val6 = ((SymbolTable)val3)[DeclaracoesGeral.blockFormatoName];
								BlockTableRecord val7 = (BlockTableRecord)val2.GetObject(val6, (OpenMode)0);
								try
								{
									BlockTableRecordEnumerator enumerator2 = default;
									try
									{
										enumerator2 = val7.GetEnumerator();
										while (enumerator2.MoveNext())
										{
											ObjectId current2 = enumerator2.Current;
											Entity val8 = (Entity)val2.GetObject(current2, (OpenMode)0);
											try
											{
												AttributeDefinition val9 = (AttributeDefinition)(object)((val8 is AttributeDefinition) ? val8 : null);
												try
												{
													if (val9 != null && ((Operators.CompareString(((Entity)val9).Layer, layer, TextCompare: true) == 0) & DeclaracoesGeral.attRevProtCollection.Contains(val9.Tag)) && val9.Tag.EndsWith(tipo))
													{
														AttributeDefinition val10 = (AttributeDefinition)((RXObject)val9).Clone();
														((Entity)val10).Layer = "0";
														((Entity)val10).Visible = true;
														((DBText)val10).TextString = "";
														val4.AppendEntity((Entity)(object)val10);
														DeclaracoesGeral.bAnularEventos = true;
														val2.AddNewlyCreatedDBObject((DBObject)(object)val10, true);
													}
												}
												finally
												{
													((IDisposable)val9)?.Dispose();
												}
											}
											finally
											{
												((IDisposable)val8)?.Dispose();
											}
										}
									}
									finally
									{
										((IDisposable)enumerator2)?.Dispose();
									}
								}
								finally
								{
									((IDisposable)val7)?.Dispose();
								}
							}
							ObjectIdCollection blockReferenceIds = val4.GetBlockReferenceIds(false, true);
							try
							{
								foreach (object item in blockReferenceIds)
								{
									ObjectId val11 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
									BlockReference val12 = (BlockReference)val2.GetObject(val11, (OpenMode)1, false, true);
									try
									{
										((Entity)val12).RecordGraphicsModified(true);
										string text2 = "_.attsync _Name " + text + "\r";
										Application.DocumentManager.MdiActiveDocument.SendStringToExecute(text2, true, false, false);
									}
									finally
									{
										((IDisposable)val12)?.Dispose();
									}
								}
							}
							finally
							{
								((IDisposable)blockReferenceIds)?.Dispose();
							}
							((DisposableWrapper)val4).Dispose();
						}
						finally
						{
							((IDisposable)val3)?.Dispose();
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
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)database)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void carregaConfiguracaoRevisao()
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected Obj, but got Unknown
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected Obj, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected Obj, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					DeclaracoesGeral.Conf.SCapa = false;
					DeclaracoesGeral.Conf.SCorpo = false;
					DeclaracoesGeral.Conf.CCapa = false;
					DeclaracoesGeral.Conf.CCorpo = false;
					DeclaracoesGeral.Conf.maxCapa = 0;
					DeclaracoesGeral.Conf.maxCorpo = 0;
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					ObjectId val4 = default;
					if (((SymbolTable)val3).Has(DeclaracoesGeral.blockFormatoName))
					{
						val4 = ((SymbolTable)val3)[DeclaracoesGeral.blockFormatoName];
					}
					BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(val4, (OpenMode)0);
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val5.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val6 = (Entity)val2.GetObject(current, (OpenMode)0);
							if (!(val6 is AttributeDefinition))
							{
								continue;
							}
							AttributeDefinition val7 = (AttributeDefinition)val6;
							string left = Strings.UCase(val7.Tag);
							if (Operators.CompareString(left, "REV", TextCompare: true) != 0)
							{
								if (Operators.CompareString(left, "REV0", TextCompare: true) != 0 && Operators.CompareString(left, "REV1", TextCompare: true) != 0 && Operators.CompareString(left, "REV2", TextCompare: true) != 0 && Operators.CompareString(left, "REV3", TextCompare: true) != 0 && Operators.CompareString(left, "REV4", TextCompare: true) != 0 && Operators.CompareString(left, "REV5", TextCompare: true) != 0 && Operators.CompareString(left, "REV6", TextCompare: true) != 0 && Operators.CompareString(left, "REV7", TextCompare: true) != 0)
								{
									continue;
								}
								if (Operators.CompareString(((Entity)val7).Layer, Pagina.retornaNumeroCapa(), TextCompare: true) != 0)
								{
									if (Operators.CompareString(((Entity)val7).Layer, "-1", TextCompare: true) == 0)
									{
										DeclaracoesGeral.Conf.CCorpo = true;
										DeclaracoesGeral.Conf.maxCorpo++;
									}
								}
								else
								{
									DeclaracoesGeral.Conf.CCapa = true;
									DeclaracoesGeral.Conf.maxCapa++;
								}
							}
							else if (Operators.CompareString(((Entity)val7).Layer, Pagina.retornaNumeroCapa(), TextCompare: true) != 0)
							{
								if (Operators.CompareString(((Entity)val7).Layer, "-1", TextCompare: true) == 0)
								{
									DeclaracoesGeral.Conf.SCorpo = true;
								}
							}
							else
							{
								DeclaracoesGeral.Conf.SCapa = true;
							}
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
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
		}
	}
}

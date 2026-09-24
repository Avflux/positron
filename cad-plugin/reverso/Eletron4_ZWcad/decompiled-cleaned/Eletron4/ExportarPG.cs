using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using SAHkZEpGH6TdnaWjq6F;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.Runtime;

namespace Eletron4;

public class ExportarPG
{
	public static void ExportaPaginaDWG(double dLtScale, int iUnit, string sLayer, string sPgMax, string sCaminho, DwgVersion Dwg, string NomeOriginal, string VersaoCAD, ref bool bExportar, bool bMensagem)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected Obj, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected Obj, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected Obj, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected Obj, but got Unknown
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected Obj, but got Unknown
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		DeclaracoesGeral.bAnularEventos = true;
		ObjectIdCollection val = new ObjectIdCollection();
		try
		{
			Database val2 = new Database();
			try
			{
				Database workingDatabase = HostApplicationServices.WorkingDatabase;
				try
				{
					if (Conversions.ToDouble(sPgMax) != 1.0)
					{
						if (bMensagem)
						{
							Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("\r\n", DeclaracoesGeral.mMensagem[1, 415]), " "), sPgMax), " "), DeclaracoesGeral.mMensagem[1, 416]), DeclaracoesGeral.mMensagem[1, 414]), "\r\n"), "")));
						}
					}
					else if (bMensagem)
					{
						Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("\r\n", DeclaracoesGeral.mMensagem[1, 413]), " "), sLayer), " "), DeclaracoesGeral.mMensagem[1, 414]), "\r\n"), "")));
					}
					Transaction val3 = workingDatabase.TransactionManager.StartTransaction();
					try
					{
						val = new ObjectIdCollection();
						BlockTable val4 = (BlockTable)val3.GetObject(workingDatabase.BlockTableId, (OpenMode)0);
						BlockTableRecord val5 = (BlockTableRecord)val3.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)0);
						string right = "-1";
						if (Pagina.checaCapa(sLayer))
						{
							right = sLayer;
						}
						BlockTableRecordEnumerator enumerator = default;
						try
						{
							enumerator = val5.GetEnumerator();
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.Current;
								Entity val6 = (Entity)val3.GetObject(current, (OpenMode)0);
								try
								{
									if (((Operators.CompareString(val6.Layer.ToString(), sLayer, TextCompare: true) == 0) | (Operators.CompareString(val6.Layer.ToString(), "0", TextCompare: true) == 0) | (Operators.CompareString(val6.Layer.ToString(), right, TextCompare: true) == 0)) && val6.Visible)
									{
										val.Add(((DBObject)val6).ObjectId);
									}
								}
								finally
								{
									((IDisposable)val6)?.Dispose();
								}
							}
						}
						finally
						{
							((IDisposable)enumerator)?.Dispose();
						}
						if (!HostApplicationServices.Current.UserBreak())
						{
							if (bExportar)
							{
								workingDatabase.Wblock(val2, val, Point3d.Origin, (DuplicateRecordCloning)2);
							}
							((DisposableWrapper)val).Dispose();
							ZoomExtents(val2);
							if (bExportar)
							{
								Database newDb = val2;
								Database db = workingDatabase;
								copiaTextStyles(ref newDb, ref db);
							}
							if (bExportar)
							{
								Database db = val2;
								KmXZg6powIdvncpZAnk.iuSpHoklP4(ref db, sLayer);
							}
							if (bExportar)
							{
								Database db = val2;
								KmXZg6powIdvncpZAnk.dM3pkT3Tgq(ref db, sLayer);
							}
							if (bExportar)
							{
								Database db = val2;
								RemoveLayerDiferente(ref db, "0", ref bExportar);
							}
							if (bExportar)
							{
								Database db = val2;
								sSs1Qg9f0o(ref db, ref bExportar);
							}
							if (bExportar)
							{
								Database db = val2;
								Lpu1P5P1ZY(ref db, ref bExportar);
							}
							if (bExportar)
							{
								Database db = val2;
								PurgeDatabase(ref db);
							}
							val2.Ltscale = dLtScale;
							val2.Insunits = (UnitsValue)iUnit;
							if (bExportar)
							{
								Database db = val2;
								gravaInformacoesAdicionais(ref db, VersaoCAD, "", NomeOriginal, sLayer);
							}
							DeclaracoesGeral.bAnularEventos = true;
							if (bExportar)
							{
								val2.SaveAs(sCaminho, true, Dwg, workingDatabase.SecurityParameters);
							}
							DeclaracoesGeral.bAnularEventos = true;
							val3.Commit();
							DeclaracoesGeral.bAnularEventos = false;
						}
						else
						{
							CancelarExportacao(ref bExportar);
						}
					}
					finally
					{
						((IDisposable)val3)?.Dispose();
					}
				}
				finally
				{
					((IDisposable)workingDatabase)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage("Unexpected Error: " + ex2.ToString());
			ProjectData.ClearProjectError();
		}
	}

	private static void sSs1Qg9f0o(ref Database P_0, ref bool P_1)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected Obj, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected Obj, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected Obj, but got Unknown
		Transaction val = P_0.TransactionManager.StartTransaction();
		try
		{
			BlockTable val2 = (BlockTable)val.GetObject(P_0.BlockTableId, (OpenMode)0);
			BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
			BlockTableRecordEnumerator enumerator = default;
			try
			{
				enumerator = val3.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ObjectId current = enumerator.Current;
					if (!HostApplicationServices.Current.UserBreak())
					{
						Entity val4 = (Entity)val.GetObject(current, (OpenMode)0);
						DBText val5 = (DBText)(object)((val4 is DBText) ? val4 : null);
						if (val5 != null && Operators.CompareString(val5.TextString.Trim(), "", TextCompare: true) == 0)
						{
							((DBObject)val5).UpgradeOpen();
							((DBObject)val4).Erase();
							((DBObject)val5).DowngradeOpen();
						}
						continue;
					}
					CancelarExportacao(ref P_1);
					return;
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
			ProjectData.ClearProjectError();
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	private static void Lpu1P5P1ZY(ref Database P_0, ref bool P_1)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected Obj, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected Obj, but got Unknown
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Expected Obj, but got Unknown
		Transaction val = P_0.TransactionManager.StartTransaction();
		try
		{
			BlockTable val2 = (BlockTable)val.GetObject(P_0.BlockTableId, (OpenMode)0);
			BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
			BlockTableRecordEnumerator enumerator = default;
			try
			{
				enumerator = val3.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ObjectId current = enumerator.Current;
					if (!HostApplicationServices.Current.UserBreak())
					{
						Entity val4 = (Entity)val.GetObject(current, (OpenMode)0);
						if (!(((DBObject)val4).XData != (ResultBuffer)null) || ((DBObject)val4).IsErased || Information.IsNothing(((DBObject)val4).XData))
						{
							continue;
						}
						clsTextos.TiraNothing(((DBObject)val4).XData.ToString());
						string text = ((DBObject)val4).XData.ToString();
						string[] array = text.Split(',');
						if (Operators.CompareString(array[1].ToString().Trim(), "", TextCompare: true) == 0)
						{
							continue;
						}
						array = array[1].Split(')');
						if (Operators.CompareString(array[0].ToString().Trim(), "", TextCompare: true) != 0)
						{
							text = array[0].ToString().ToUpper();
							string left = text;
							if (Operators.CompareString(left, "ACAD", TextCompare: true) != 0)
							{
								TypedValue[] array2 = new TypedValue[1]
								{
									new TypedValue(1001, (object)array[0].ToString())
								};
								((DBObject)val4).UpgradeOpen();
								((DBObject)val4).XData = new ResultBuffer(array2);
								((DBObject)val4).DowngradeOpen();
							}
						}
						continue;
					}
					CancelarExportacao(ref P_1);
					return;
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
			ProjectData.ClearProjectError();
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	private static void tvN1cFnrBR(ref Database P_0, ref bool P_1)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected Obj, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected Obj, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected Obj, but got Unknown
		Transaction val = P_0.TransactionManager.StartTransaction();
		try
		{
			BlockTable val2 = (BlockTable)val.GetObject(P_0.BlockTableId, (OpenMode)0);
			BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
			BlockTableRecordEnumerator enumerator = default;
			try
			{
				enumerator = val3.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ObjectId current = enumerator.Current;
					if (!HostApplicationServices.Current.UserBreak())
					{
						Entity val4 = (Entity)val.GetObject(current, (OpenMode)0);
						if (!val4.Visible)
						{
							((DBObject)val4).UpgradeOpen();
							((DBObject)val4).Erase();
							((DBObject)val4).DowngradeOpen();
						}
						continue;
					}
					CancelarExportacao(ref P_1);
					return;
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
			ProjectData.ClearProjectError();
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void RemoveLayerDiferente(ref Database newDb, string sLayer, ref bool bExportar)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected Obj, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected Obj, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Expected Obj, but got Unknown
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Expected Obj, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected Obj, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected Obj, but got Unknown
		List<string> list = new List<string>();
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Transaction val2 = newDb.TransactionManager.StartTransaction();
			try
			{
				LayerTable val3 = (LayerTable)val2.GetObject(newDb.LayerTableId, (OpenMode)1);
				ObjectId layerTableId = newDb.LayerTableId;
				LayerTable val4 = (LayerTable)layerTableId.GetObject((OpenMode)0);
				SymbolTableEnumerator enumerator = default;
				try
				{
					enumerator = val3.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						LayerTableRecord val5 = (LayerTableRecord)val2.GetObject(current, (OpenMode)1);
						val5.IsLocked = false;
						list.Add(((SymbolTableRecord)val5).Name.ToString());
						if (Operators.CompareString(((SymbolTableRecord)val5).Name.ToString(), "0", TextCompare: true) == 0)
						{
							newDb.Clayer = ((SymbolTable)val4)["0"];
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
				Application.DocumentManager.MdiActiveDocument.Editor.Regen();
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
		Transaction val6 = newDb.TransactionManager.StartTransaction();
		try
		{
			LayerTable val7 = (LayerTable)val6.GetObject(newDb.LayerTableId, (OpenMode)0);
			foreach (string item in list)
			{
				if (!(((SymbolTable)val7).Has(item) & (Operators.CompareString(item, "0", TextCompare: true) != 0)))
				{
					continue;
				}
				ObjectIdCollection val8 = new ObjectIdCollection();
				val8.Add(((SymbolTable)val7)[item]);
				newDb.Purge(val8);
				if (val8.Count > 0)
				{
					LayerTableRecord val9 = (LayerTableRecord)val6.GetObject(val8[0], (OpenMode)1);
					try
					{
						((DBObject)val9).Erase(true);
					}
					catch (Exception projectError2)
					{
						ProjectData.SetProjectError(projectError2);
						ProjectData.ClearProjectError();
					}
				}
			}
			DeclaracoesGeral.bAnularEventos = true;
			val6.Commit();
			DeclaracoesGeral.bAnularEventos = false;
		}
		finally
		{
			((IDisposable)val6)?.Dispose();
		}
	}

	public static void PurgeDatabase(ref Database newDb)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected Obj, but got Unknown
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected Obj, but got Unknown
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		Transaction val = newDb.TransactionManager.StartTransaction();
		try
		{
			ObjectIdCollection val2 = new ObjectIdCollection();
			RegAppTable val3 = (RegAppTable)val.GetObject(newDb.RegAppTableId, (OpenMode)0);
			SymbolTableEnumerator enumerator = default;
			try
			{
				enumerator = ((SymbolTable)val3).GetEnumerator();
				while (enumerator.MoveNext())
				{
					ObjectId current = enumerator.Current;
					if (current.IsValid)
					{
						val2.Add(current);
					}
				}
			}
			finally
			{
				((IDisposable)enumerator)?.Dispose();
			}
			newDb.Purge(val2);
			DeclaracoesGeral.bAnularEventos = true;
			val.Commit();
			DeclaracoesGeral.bAnularEventos = false;
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void gravaInformacoesAdicionais(ref Database newDb, string sVersao, string Revisao, string Documento, string Pagina)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected Obj, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			DatabaseSummaryInfoBuilder val = new DatabaseSummaryInfoBuilder(newDb.SummaryInfo);
			val.Title = "Cadgraph Soluções para Engenharia";
			val.Subject = "Exportado do Eletron v26.03";
			val.Author = Environment.UserName.ToUpper() + " - " + DateTime.Now.ToString();
			val.HyperlinkBase = "www.cadgraph.com.br";
			val.RevisionNumber = val.RevisionNumber.Trim() + DateTime.Now.ToString();
			val.LastSavedBy = sVersao;
			newDb.SummaryInfo = val.ToDatabaseSummaryInfo();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public static int CalculaZeros(string sValor)
	{
		int num = 0;
		int num2 = Strings.Len(sValor);
		int num3 = 0;
		int num4 = 1;
		checked
		{
			if (num2 >= 1)
			{
				int num5 = num2;
				for (int i = 1; i <= num5; i++)
				{
					string left = Strings.Mid(sValor, i, 1);
					if (Operators.CompareString(left, "0", TextCompare: true) == 0)
					{
						num4 = i;
						break;
					}
				}
				int num6 = num4;
				int num7 = num2;
				for (int i = num6; i <= num7; i++)
				{
					string left = Strings.Mid(sValor, i, 1);
					if (Operators.CompareString(left, "0", TextCompare: true) != 0)
					{
						num3 = 0;
						num = 0;
					}
					else if (num <= num2)
					{
						num3++;
					}
				}
			}
			return num3;
		}
	}

	public static void copiaTextStyles(ref Database newDb, ref Database db)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected Obj, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected Obj, but got Unknown
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Transaction topTransaction = db.TransactionManager.TopTransaction;
			try
			{
				Transaction val = newDb.TransactionManager.StartTransaction();
				try
				{
					TextStyleTable val2 = (TextStyleTable)topTransaction.GetObject(db.TextStyleTableId, (OpenMode)0, false);
					TextStyleTable val3 = (TextStyleTable)val.GetObject(newDb.TextStyleTableId, (OpenMode)0, false);
					SymbolTableEnumerator enumerator = default;
					try
					{
						enumerator = ((SymbolTable)val2).GetEnumerator();
						SymbolTableEnumerator enumerator2 = default;
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							TextStyleTableRecord val4 = (TextStyleTableRecord)topTransaction.GetObject(current, (OpenMode)0, false);
							try
							{
								enumerator2 = ((SymbolTable)val3).GetEnumerator();
								while (enumerator2.MoveNext())
								{
									ObjectId current2 = enumerator2.Current;
									TextStyleTableRecord val5 = (TextStyleTableRecord)val.GetObject(current2, (OpenMode)1, false, true);
									if (Operators.CompareString(((SymbolTableRecord)val4).Name.ToUpper(), ((SymbolTableRecord)val5).Name.ToUpper(), TextCompare: true) == 0)
									{
										((DBObject)val5).UpgradeOpen();
										val5.Font = val4.Font;
										val5.XScale = val4.XScale;
										val5.TextSize = val4.TextSize;
									}
								}
							}
							finally
							{
								((IDisposable)enumerator2)?.Dispose();
							}
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
					val.Commit();
				}
				finally
				{
					((IDisposable)val)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)topTransaction)?.Dispose();
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
	}

	public static void CancelarExportacao(ref bool bExportar)
	{
		MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 295]), MsgBoxStyle.YesNo);
		if (msgBoxResult == MsgBoxResult.Yes)
		{
			bExportar = false;
			Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("\r\n", DeclaracoesGeral.mMensagem[1, 296]), "\r\n"), " ")));
		}
	}

	public static void ZoomExtents(Database db)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected Obj, but got Unknown
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected Obj, but got Unknown
		Transaction val = db.TransactionManager.StartTransaction();
		try
		{
			ViewportTable val2 = (ViewportTable)val.GetObject(db.ViewportTableId, (OpenMode)0);
			ViewportTableRecord viewportTableRec = (ViewportTableRecord)val.GetObject(((SymbolTable)val2)["*Active"], (OpenMode)1);
			SetViewportToExtents(db, viewportTableRec);
			DeclaracoesGeral.bAnularEventos = true;
			val.Commit();
			DeclaracoesGeral.bAnularEventos = false;
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void SetViewportToExtents(Database db, ViewportTableRecord viewportTableRec)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		db.UpdateExt(true);
		double num = ((AbstractViewTableRecord)viewportTableRec).Width / ((AbstractViewTableRecord)viewportTableRec).Height;
		Matrix3d val = Matrix3d.PlaneToWorld(((AbstractViewTableRecord)viewportTableRec).ViewDirection);
		val = Matrix3d.Displacement(((AbstractViewTableRecord)viewportTableRec).Target - Point3d.Origin) * val;
		val = Matrix3d.Rotation(0.0 - ((AbstractViewTableRecord)viewportTableRec).ViewTwist, ((AbstractViewTableRecord)viewportTableRec).ViewDirection, ((AbstractViewTableRecord)viewportTableRec).Target) * val;
		val = val.Inverse();
		Extents3d val2 = new Extents3d(db.Extmin, db.Extmax);
		val2.TransformBy(val);
		Point3d val3 = val2.MaxPoint;
		double x = val3.X;
		val3 = val2.MinPoint;
		double num2 = x - val3.X;
		val3 = val2.MaxPoint;
		double y = val3.Y;
		val3 = val2.MinPoint;
		double num3 = y - val3.Y;
		val3 = val2.MaxPoint;
		double x2 = val3.X;
		val3 = val2.MinPoint;
		double num4 = (x2 + val3.X) * 0.5;
		val3 = val2.MaxPoint;
		double y2 = val3.Y;
		val3 = val2.MinPoint;
		Point2d centerPoint = new Point2d(num4, (y2 + val3.Y) * 0.5);
		if (num2 > num3 * num)
		{
			num3 = num2 / num;
		}
		((AbstractViewTableRecord)viewportTableRec).Height = num3;
		((AbstractViewTableRecord)viewportTableRec).Width = num3 * num;
		((AbstractViewTableRecord)viewportTableRec).CenterPoint = centerPoint;
	}
}

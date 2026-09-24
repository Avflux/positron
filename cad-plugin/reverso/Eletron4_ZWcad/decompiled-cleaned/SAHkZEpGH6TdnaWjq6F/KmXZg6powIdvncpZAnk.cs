using System;
using System.Collections.Generic;
using Eletron4;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Runtime;

namespace SAHkZEpGH6TdnaWjq6F;

internal class KmXZg6powIdvncpZAnk
{
	public static void iuSpHoklP4(ref Database P_0, string P_1)
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected Obj, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected Obj, but got Unknown
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Expected Obj, but got Unknown
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Expected Obj, but got Unknown
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Expected Obj, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Expected Obj, but got Unknown
		List<string> list = new List<string>();
		if (!Pagina.checaCapa(P_1))
		{
			list.Add("0");
			list.Add("-1");
			list.Add(P_1);
		}
		else
		{
			list.Add("0");
			list.Add("1");
			list.Add("001");
			list.Add("0001");
			list.Add("00001");
			list.Add("000001");
			list.Add("0000001");
		}
		try
		{
			DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
			try
			{
				Transaction val2 = P_0.TransactionManager.StartTransaction();
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(P_0.BlockTableId, (OpenMode)1);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						BlockTableRecordEnumerator enumerator2 = default;
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val5 = (Entity)val2.GetObject(current, (OpenMode)1);
							try
							{
								BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
								try
								{
									if (val6 == null)
									{
										continue;
									}
									if (val6 == null)
									{
										if (!list.Contains(val5.Layer))
										{
											((DBObject)val5).UpgradeOpen();
											((DBObject)val5).Erase();
										}
										else
										{
											val5.Layer = "0";
										}
										continue;
									}
									new DBObjectCollection();
									DBObject val7 = val2.GetObject(val6.BlockTableRecord, (OpenMode)1);
									BlockTableRecord val8 = (BlockTableRecord)(object)((val7 is BlockTableRecord) ? val7 : null);
									try
									{
										enumerator2 = val8.GetEnumerator();
										while (enumerator2.MoveNext())
										{
											ObjectId current2 = enumerator2.Current;
											Entity val9 = (Entity)val2.GetObject(current2, (OpenMode)1);
											try
											{
												if (list.Contains(val9.Layer))
												{
													val5.Layer = "0";
													continue;
												}
												((DBObject)val9).UpgradeOpen();
												((DBObject)val9).Erase();
											}
											finally
											{
												((IDisposable)val9)?.Dispose();
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
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
				Transaction val10 = P_0.TransactionManager.StartTransaction();
				try
				{
					BlockTable val11 = (BlockTable)val10.GetObject(P_0.BlockTableId, (OpenMode)1);
					BlockTableRecord val12 = (BlockTableRecord)val10.GetObject(((SymbolTable)val11)[BlockTableRecord.ModelSpace], (OpenMode)1);
					BlockTableRecordEnumerator enumerator3 = default;
					try
					{
						enumerator3 = val12.GetEnumerator();
						while (enumerator3.MoveNext())
						{
							ObjectId current3 = enumerator3.Current;
							Entity val13 = (Entity)val10.GetObject(current3, (OpenMode)1);
							try
							{
								if (!list.Contains(val13.Layer))
								{
									((DBObject)val13).UpgradeOpen();
									((DBObject)val13).Erase();
								}
								else if (Operators.CompareString(val13.Layer, "0", TextCompare: true) != 0)
								{
									val13.Layer = "0";
								}
							}
							finally
							{
								((IDisposable)val13)?.Dispose();
							}
						}
					}
					finally
					{
						((IDisposable)enumerator3)?.Dispose();
					}
					DeclaracoesGeral.bAnularEventos = true;
					val10.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				finally
				{
					((IDisposable)val10)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public static void dM3pkT3Tgq(ref Database P_0, string P_1)
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		List<string> list = new List<string>();
		if (!Pagina.checaCapa(P_1))
		{
			list.Add("0");
			list.Add("-1");
			list.Add(P_1);
		}
		else
		{
			list.Add("0");
			list.Add("1");
			list.Add("001");
			list.Add("0001");
			list.Add("00001");
			list.Add("000001");
			list.Add("0000001");
		}
		try
		{
			DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
			try
			{
				Transaction val2 = P_0.TransactionManager.StartTransaction();
				try
				{
					ObjectId blockModelSpaceId = SymbolUtilityServices.GetBlockModelSpaceId(P_0);
					DBObject val3 = val2.GetObject(blockModelSpaceId, (OpenMode)1);
					BlockTableRecord val4 = (BlockTableRecord)(object)((val3 is BlockTableRecord) ? val3 : null);
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						BlockTableRecordEnumerator enumerator2 = default;
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							DBObject val5 = val2.GetObject(current, (OpenMode)1);
							BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
							try
							{
								if (val6 == null)
								{
									continue;
								}
								new DBObjectCollection();
								DBObject val7 = val2.GetObject(val6.BlockTableRecord, (OpenMode)1);
								BlockTableRecord val8 = (BlockTableRecord)(object)((val7 is BlockTableRecord) ? val7 : null);
								try
								{
									enumerator2 = val8.GetEnumerator();
									while (enumerator2.MoveNext())
									{
										ObjectId current2 = enumerator2.Current;
										if (Operators.CompareString(current2.ObjectClass.Name, "AcDbAttributeDefinition", TextCompare: true) == 0)
										{
											DBObject val9 = val2.GetObject(current2, (OpenMode)1);
											AttributeDefinition val10 = (AttributeDefinition)(object)((val9 is AttributeDefinition) ? val9 : null);
											if (!list.Contains(((Entity)val10).Layer))
											{
												((DBObject)val10).Erase();
											}
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
								((IDisposable)val6)?.Dispose();
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
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			DocumentLock val11 = Application.DocumentManager.MdiActiveDocument.LockDocument();
			try
			{
				Transaction val12 = P_0.TransactionManager.StartTransaction();
				try
				{
					ObjectId blockModelSpaceId2 = SymbolUtilityServices.GetBlockModelSpaceId(P_0);
					DBObject val13 = val12.GetObject(blockModelSpaceId2, (OpenMode)1);
					BlockTableRecord val14 = (BlockTableRecord)(object)((val13 is BlockTableRecord) ? val13 : null);
					BlockTableRecordEnumerator enumerator3 = default;
					try
					{
						enumerator3 = val14.GetEnumerator();
						while (enumerator3.MoveNext())
						{
							ObjectId current3 = enumerator3.Current;
							DBObject val15 = val12.GetObject(current3, (OpenMode)1);
							BlockReference val16 = (BlockReference)(object)((val15 is BlockReference) ? val15 : null);
							try
							{
								if (val16 == null)
								{
									continue;
								}
								foreach (object item in val16.AttributeCollection)
								{
									ObjectId val17 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
									DBObject val18 = val12.GetObject(val17, (OpenMode)1);
									AttributeReference val19 = (AttributeReference)(object)((val18 is AttributeReference) ? val18 : null);
									try
									{
										if (!list.Contains(((Entity)val19).Layer))
										{
											((DBObject)val19).Erase();
										}
									}
									finally
									{
										((IDisposable)val19)?.Dispose();
									}
								}
							}
							finally
							{
								((IDisposable)val16)?.Dispose();
							}
						}
					}
					finally
					{
						((IDisposable)enumerator3)?.Dispose();
					}
					DeclaracoesGeral.bAnularEventos = true;
					val12.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				finally
				{
					((IDisposable)val12)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val11)?.Dispose();
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public static void B87pdnUnMO(string P_0, DwgVersion P_1)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected Obj, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Obj, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected Obj, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected Obj, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected Obj, but got Unknown
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected Obj, but got Unknown
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		Database val = new Database(false, true);
		try
		{
			val.ReadDwgFile(P_0, (FileOpenMode)3, false, "");
			Transaction val2 = (Transaction)(object)val.TransactionManager.StartOpenCloseTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(val.BlockTableId, (OpenMode)1);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val4.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)1);
						try
						{
							BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
							try
							{
								if (val6 == null)
								{
									continue;
								}
								DBObjectCollection val7 = new DBObjectCollection();
								val5.Explode(val7);
								bool visible = val5.Visible;
								((DBObject)val5).Erase();
								if (!visible)
								{
									continue;
								}
								foreach (Entity item in val7)
								{
									Entity val8 = item;
									string text = ((object)((DBObject)val8).Drawable).ToString().ToUpper();
									if (!text.Contains("OLE"))
									{
										val4.AppendEntity(val8);
										DeclaracoesGeral.bAnularEventos = true;
										val2.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
									}
									else
									{
										Ole2Frame val9 = (Ole2Frame)(object)((val8 is Ole2Frame) ? val8 : null);
										val4.AppendEntity((Entity)(object)val9);
										DeclaracoesGeral.bAnularEventos = true;
										val2.AddNewlyCreatedDBObject((DBObject)(object)val9, true);
									}
									((DisposableWrapper)val8).Dispose();
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
				val.SaveAs(P_0, true, P_1, val.SecurityParameters);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
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

	public static void xdmpfY6Fg7(string P_0, DwgVersion P_1)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected Obj, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Obj, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected Obj, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected Obj, but got Unknown
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		Database val = new Database(false, true);
		try
		{
			val.ReadDwgFile(P_0, (FileOpenMode)3, false, "");
			Transaction val2 = (Transaction)(object)val.TransactionManager.StartOpenCloseTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(val.BlockTableId, (OpenMode)1);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val4.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						if (Operators.CompareString(current.ObjectClass.Name, "AcDbAttributeDefinition", TextCompare: true) == 0)
						{
							Entity val5 = (Entity)val2.GetObject(current, (OpenMode)1);
							((DBObject)val5).Erase();
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
				val.SaveAs(P_0, true, P_1, val.SecurityParameters);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
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

	public static void vbOpDVnOD8(string P_0, DwgVersion P_1)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected Obj, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Obj, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected Obj, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected Obj, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		Database val = new Database(false, true);
		try
		{
			val.ReadDwgFile(P_0, (FileOpenMode)3, false, "");
			Transaction val2 = (Transaction)(object)val.TransactionManager.StartOpenCloseTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(val.BlockTableId, (OpenMode)1);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val4.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)1);
						try
						{
							val5.Layer = "0";
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
				val.SaveAs(P_0, true, P_1, val.SecurityParameters);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
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

	public static DBText Slmpvj7wSm(AttributeReference P_0, string P_1, string P_2)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Invalid comparison between Unknown and I4
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Invalid comparison between Unknown and I4
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		DBText val = new DBText();
		((Entity)val).Layer = P_2;
		val.TextString = P_1;
		val.TextStyleId = ((DBText)P_0).TextStyleId;
		((Entity)val).ColorIndex = ((Entity)P_0).ColorIndex;
		((Entity)val).LineWeight = ((Entity)P_0).LineWeight;
		val.Height = ((DBText)P_0).Height;
		val.WidthFactor = ((DBText)P_0).WidthFactor;
		val.Position = ((DBText)P_0).Position;
		val.Oblique = ((DBText)P_0).Oblique;
		val.Rotation = ((DBText)P_0).Rotation;
		((Entity)val).Visible = true;
		val.HorizontalMode = ((DBText)P_0).HorizontalMode;
		val.VerticalMode = ((DBText)P_0).VerticalMode;
		if (!(((int)((DBText)P_0).HorizontalMode == 0) & ((int)((DBText)P_0).VerticalMode == 0)))
		{
			val.AlignmentPoint = ((DBText)P_0).AlignmentPoint;
		}
		return val;
	}

	public static void kOHp6XhTCZ(string P_0)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected Obj, but got Unknown
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected Obj, but got Unknown
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Expected Obj, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Expected Obj, but got Unknown
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)1);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val4.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)1);
						try
						{
							BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
							try
							{
								if (!val5.Visible || val6 == null)
								{
									continue;
								}
								if (!Pagina.checaCapa(P_0))
								{
									AttributeCollection attributeCollection = val6.AttributeCollection;
									foreach (object item in attributeCollection)
									{
										ObjectId val7 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
										AttributeReference val8 = (AttributeReference)val2.GetObject(val7, (OpenMode)1);
										try
										{
											if (((Entity)val8).Visible && ((Operators.CompareString(((Entity)val6).Layer, P_0, TextCompare: true) == 0) | (Operators.CompareString(((Entity)val6).Layer, "-1", TextCompare: true) == 0) | (Operators.CompareString(((Entity)val8).Layer, "-1", TextCompare: true) == 0)))
											{
												DBText val9 = Slmpvj7wSm(val8, ((DBText)val8).TextString, P_0);
												val4.AppendEntity((Entity)(object)val9);
												DeclaracoesGeral.bAnularEventos = true;
												val2.AddNewlyCreatedDBObject((DBObject)(object)val9, true);
												Entity val10 = (Entity)(object)val9;
												a7upLbFIFt(ref val10);
												val9 = (DBText)val10;
											}
										}
										finally
										{
											((IDisposable)val8)?.Dispose();
										}
									}
								}
								else
								{
									if (!((Entity)val6).Visible)
									{
										continue;
									}
									AttributeCollection attributeCollection2 = val6.AttributeCollection;
									foreach (object item2 in attributeCollection2)
									{
										ObjectId val11 = ((item2 == null) ? default(ObjectId) : ((ObjectId)item2));
										AttributeReference val12 = (AttributeReference)val2.GetObject(val11, (OpenMode)1);
										try
										{
											if (((Operators.CompareString(((Entity)val6).Layer, P_0, TextCompare: true) == 0) | (Operators.CompareString(((Entity)val6).Layer, "1", TextCompare: true) == 0) | (Operators.CompareString(((Entity)val12).Layer, P_0, TextCompare: true) == 0)) && ((Entity)val12).Visible)
											{
												DBText val13 = Slmpvj7wSm(val12, ((DBText)val12).TextString, P_0);
												val4.AppendEntity((Entity)(object)val13);
												DeclaracoesGeral.bAnularEventos = true;
												val2.AddNewlyCreatedDBObject((DBObject)(object)val13, true);
												Entity val10 = (Entity)(object)val13;
												a7upLbFIFt(ref val10);
												val13 = (DBText)val10;
											}
										}
										finally
										{
											((IDisposable)val12)?.Dispose();
										}
									}
									continue;
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

	public static void Xh6ptgg8r5()
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
						try
						{
							DBText val6 = (DBText)(object)((val5 is DBText) ? val5 : null);
							try
							{
								if (val6 != null)
								{
									Entity val7 = (Entity)(object)val6;
									if (AKNpwVqDPw(ref val7))
									{
										((DBObject)val6).UpgradeOpen();
										((DBObject)val6).Erase();
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

	public static void Tnapj8Vx74(string P_0, DwgVersion P_1)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected Obj, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected Obj, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		Database val = new Database(false, true);
		try
		{
			val.ReadDwgFile(P_0, (FileOpenMode)3, false, "");
			Transaction val2 = (Transaction)(object)val.TransactionManager.StartOpenCloseTransaction();
			try
			{
				Database newDb = Application.DocumentManager.MdiActiveDocument.Database;
				ExportarPG.PurgeDatabase(ref newDb);
				ObjectIdCollection val3 = new ObjectIdCollection();
				RegAppTable val4 = (RegAppTable)val2.GetObject(val.RegAppTableId, (OpenMode)0);
				SymbolTableEnumerator enumerator = default;
				try
				{
					enumerator = ((SymbolTable)val4).GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						if (current.IsValid)
						{
							val3.Add(current);
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				val.Purge(val3);
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				val.SaveAs(P_0, true, P_1, val.SecurityParameters);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
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

	public static void a7upLbFIFt(ref Entity P_0)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			RegAppTable val2 = (RegAppTable)val.GetObject(database.RegAppTableId, (OpenMode)1);
			if (!((SymbolTable)val2).Has("BURST_"))
			{
				RegAppTableRecord val3 = new RegAppTableRecord();
				((SymbolTableRecord)val3).Name = "BURST_";
				((SymbolTable)val2).Add((SymbolTableRecord)(object)val3);
				DeclaracoesGeral.bAnularEventos = true;
				val.AddNewlyCreatedDBObject((DBObject)(object)val3, true);
			}
			TypedValue[] array = new TypedValue[2]
			{
				new TypedValue(1001, (object)"BURST_"),
				new TypedValue(1000, (object)"TEXTO_ATT")
			};
			((DBObject)P_0).XData = new ResultBuffer(array);
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

	public static bool AKNpwVqDPw(ref Entity P_0)
	{
		ResultBuffer xDataForApplication = ((DBObject)P_0).GetXDataForApplication("BURST_");
		if (xDataForApplication == null)
		{
			return false;
		}
		TypedValue[] array = xDataForApplication.AsArray();
		if (Operators.CompareString(array[1].Value.ToString().ToUpper(), "TEXTO_ATT", TextCompare: true) != 0)
		{
			return false;
		}
		return true;
	}

	public static void PISpx4jbBk()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected Obj, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected Obj, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected Obj, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val4.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)1);
						try
						{
							BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
							try
							{
								if (!val5.Visible || val6 == null)
								{
									continue;
								}
								DBObjectCollection val7 = new DBObjectCollection();
								val5.Explode(val7);
								foreach (Entity item in val7)
								{
									Entity val8 = item;
									string text = ((object)((DBObject)val8).Drawable).ToString().ToUpper();
									if (text.Contains("OLE"))
									{
										Ole2Frame val9 = (Ole2Frame)(object)((val8 is Ole2Frame) ? val8 : null);
										val4.AppendEntity((Entity)(object)val9);
										Entity val10 = (Entity)(object)val9;
										KHwpbG6WKa(ref val10);
										val9 = (Ole2Frame)val10;
										DeclaracoesGeral.bAnularEventos = true;
										val2.AddNewlyCreatedDBObject((DBObject)(object)val9, true);
									}
									((DisposableWrapper)val8).Dispose();
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

	public static void KHwpbG6WKa(ref Entity P_0)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			RegAppTable val2 = (RegAppTable)val.GetObject(database.RegAppTableId, (OpenMode)1);
			try
			{
				if (!((SymbolTable)val2).Has("BURST_OLE"))
				{
					RegAppTableRecord val3 = new RegAppTableRecord();
					((SymbolTableRecord)val3).Name = "BURST_OLE";
					((SymbolTable)val2).Add((SymbolTableRecord)(object)val3);
					DeclaracoesGeral.bAnularEventos = true;
					val.AddNewlyCreatedDBObject((DBObject)(object)val3, true);
				}
				TypedValue[] array = new TypedValue[2]
				{
					new TypedValue(1001, (object)"BURST_OLE"),
					new TypedValue(1000, (object)"OLE")
				};
				((DBObject)P_0).XData = new ResultBuffer(array);
				DeclaracoesGeral.bAnularEventos = true;
				val.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
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

	public static bool kJopM3rVW3(ref Entity P_0)
	{
		ResultBuffer xDataForApplication = ((DBObject)P_0).GetXDataForApplication("BURST_OLE");
		if (xDataForApplication == null)
		{
			return false;
		}
		TypedValue[] array = xDataForApplication.AsArray();
		if (Operators.CompareString(array[1].Value.ToString().ToUpper(), "OLE", TextCompare: true) != 0)
		{
			return false;
		}
		return true;
	}

	public static void TUOpOC13mF()
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
						try
						{
							Entity val6 = val5;
							if (kJopM3rVW3(ref val6))
							{
								((DBObject)val5).UpgradeOpen();
								((DBObject)val5).Erase();
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

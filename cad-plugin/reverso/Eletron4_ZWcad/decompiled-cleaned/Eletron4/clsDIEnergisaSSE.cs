using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.EditorInput;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.Runtime;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

public class clsDIEnergisaSSE
{
	public static void InserirColunaAranha(string nomebloco, Point3d ptIns, string nomePainel)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected Obj, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected Obj, but got Unknown
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Expected Obj, but got Unknown
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected Obj, but got Unknown
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected Obj, but got Unknown
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected Obj, but got Unknown
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Expected Obj, but got Unknown
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Expected Obj, but got Unknown
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Expected Obj, but got Unknown
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			_ = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				try
				{
					ObjectId val3 = ObjectId.Null;
					BlockTable val4 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)1);
					string text = nomebloco.Substring(0, checked(nomebloco.Length - 4));
					string text2 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Interligação\\EnergisaSSE\\" + nomebloco;
					if (!((SymbolTable)val4).Has(text))
					{
						Database val6 = new Database(false, true);
						val6.ReadDwgFile(text2, FileShare.Read, true, "");
						DeclaracoesGeral.bAnularEventos = true;
						val3 = database.Insert(text, val6, false);
						((DisposableWrapper)val6).Dispose();
					}
					else
					{
						BlockTableRecord val7 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[text], (OpenMode)0);
						val3 = ((DBObject)val7).Id;
					}
					BlockReference val8 = new BlockReference(ptIns, val3);
					((Entity)val8).Layer = DeclaracoesGeral.ativo.Pagina;
					val5.AppendEntity((Entity)(object)val8);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
					BlockTableRecord val9 = (BlockTableRecord)val2.GetObject(val3, (OpenMode)0);
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val9.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val10 = (Entity)val2.GetObject(current, (OpenMode)0);
							if (val10 is AttributeDefinition)
							{
								AttributeDefinition val11 = (AttributeDefinition)val10;
								AttributeReference val12 = new AttributeReference();
								val12.SetAttributeFromBlock(val11, val8.BlockTransform);
								string tag = val11.Tag;
								if (Operators.CompareString(tag, "ORIGEM", TextCompare: true) != 0)
								{
									((Entity)val12).Visible = false;
								}
								else
								{
									((DBText)val12).TextString = nomePainel;
								}
								((DBText)val12).AdjustAlignment(database);
								val8.AttributeCollection.AppendAttribute(val12);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val12, true);
								((Entity)val12).Draw();
							}
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
					((Entity)val8).Draw();
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					val2.Abort();
					Interaction.MsgBox(ex2.Message, MsgBoxStyle.Information);
					ProjectData.ClearProjectError();
				}
				finally
				{
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
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

	public static void InserirBorneAranha(string nomebloco, DeclaracoesInterligacao.borneAranha bn, Point3d ptIns)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected Obj, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected Obj, but got Unknown
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Expected Obj, but got Unknown
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected Obj, but got Unknown
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected Obj, but got Unknown
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected Obj, but got Unknown
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Expected Obj, but got Unknown
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected Obj, but got Unknown
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected Obj, but got Unknown
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			_ = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				try
				{
					ObjectId val3 = ObjectId.Null;
					BlockTable val4 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)1);
					string text = nomebloco.Substring(0, checked(nomebloco.Length - 4));
					string text2 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Interligação\\EnergisaSSE\\" + nomebloco;
					if (!((SymbolTable)val4).Has(text))
					{
						Database val6 = new Database(false, true);
						val6.ReadDwgFile(text2, FileShare.Read, true, "");
						DeclaracoesGeral.bAnularEventos = true;
						val3 = database.Insert(text, val6, false);
						((DisposableWrapper)val6).Dispose();
					}
					else
					{
						BlockTableRecord val7 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[text], (OpenMode)0);
						val3 = ((DBObject)val7).Id;
					}
					BlockReference blockRef = new BlockReference(ptIns, val3);
					((Entity)blockRef).Layer = DeclaracoesGeral.ativo.Pagina;
					val5.AppendEntity((Entity)(object)blockRef);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)blockRef, true);
					BlockTableRecord val8 = (BlockTableRecord)val2.GetObject(val3, (OpenMode)0);
					string textString = bn.Tag;
					if (Operators.CompareString(bn.NRegua, "", TextCompare: true) != 0)
					{
						textString = bn.NRegua;
					}
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val8.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val9 = (Entity)val2.GetObject(current, (OpenMode)0);
							if (!(val9 is AttributeDefinition))
							{
								continue;
							}
							AttributeDefinition val10 = (AttributeDefinition)val9;
							AttributeReference val11 = new AttributeReference();
							val11.SetAttributeFromBlock(val10, blockRef.BlockTransform);
							string tag = val10.Tag;
							if (Operators.CompareString(tag, "R", TextCompare: true) != 0)
							{
								if (Operators.CompareString(tag, "B", TextCompare: true) != 0)
								{
									((Entity)val11).Visible = false;
								}
								else
								{
									((DBText)val11).TextString = bn.Borne;
								}
							}
							else
							{
								((DBText)val11).TextString = textString;
							}
							((DBText)val11).AdjustAlignment(database);
							blockRef.AttributeCollection.AppendAttribute(val11);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)val11, true);
							((Entity)val11).Draw();
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
					((Entity)blockRef).Draw();
					XDataDIEnergisaSSE.GravarXDataBorne(ref blockRef, bn);
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					val2.Abort();
					Interaction.MsgBox(ex2.Message, MsgBoxStyle.Information);
					ProjectData.ClearProjectError();
				}
				finally
				{
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
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

	public static void InserirVeia(string revisao, int painel, string Regua, DeclaracoesInterligacao.borneRI borneRI, Point3d ptIns, int index, int tipoCabo, double deltaY)
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected Obj, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected Obj, but got Unknown
		//IL_037b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0386: Unknown result type (might be due to invalid IL or missing references)
		//IL_038d: Expected Obj, but got Unknown
		//IL_038f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0394: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected Obj, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected Obj, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Expected Obj, but got Unknown
		//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03db: Expected Obj, but got Unknown
		//IL_03ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0412: Unknown result type (might be due to invalid IL or missing references)
		//IL_0449: Unknown result type (might be due to invalid IL or missing references)
		//IL_046e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0475: Expected Obj, but got Unknown
		//IL_048d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0492: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b5: Expected Obj, but got Unknown
		//IL_04c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0523: Unknown result type (might be due to invalid IL or missing references)
		//IL_0548: Unknown result type (might be due to invalid IL or missing references)
		//IL_054f: Expected Obj, but got Unknown
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Expected Obj, but got Unknown
		//IL_0584: Unknown result type (might be due to invalid IL or missing references)
		//IL_058b: Expected Obj, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Expected Obj, but got Unknown
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Expected Obj, but got Unknown
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		if (tipoCabo != 1)
		{
			if (tipoCabo == 2)
			{
				text = "Cabo2.dwg";
			}
		}
		else
		{
			text = "Cabo.dwg";
		}
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			_ = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				try
				{
					ObjectId val3 = ObjectId.Null;
					BlockTable val4 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)1);
					string text2 = text.Substring(0, checked(text.Length - 4));
					string text3 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Interligação\\EnergisaSSE\\" + text;
					if (!((SymbolTable)val4).Has(text2))
					{
						Database val6 = new Database(false, true);
						val6.ReadDwgFile(text3, FileShare.Read, true, "");
						DeclaracoesGeral.bAnularEventos = true;
						val3 = database.Insert(text2, val6, false);
						((DisposableWrapper)val6).Dispose();
					}
					else
					{
						BlockTableRecord val7 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[text2], (OpenMode)0);
						val3 = ((DBObject)val7).Id;
					}
					BlockReference val8 = new BlockReference(ptIns, val3);
					((Entity)val8).Layer = DeclaracoesGeral.ativo.Pagina;
					val5.AppendEntity((Entity)(object)val8);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
					BlockTableRecord val9 = (BlockTableRecord)val2.GetObject(val3, (OpenMode)0);
					Entity ent;
					if (tipoCabo == 2)
					{
						Point2d val10 = new Point2d(ptIns.X + 20.0, ptIns.Y);
						Point2d val11 = new Point2d(ptIns.X + 20.0, deltaY);
						Polyline val12 = new Polyline();
						((Entity)val12).SetDatabaseDefaults();
						((Entity)val12).ColorIndex = 7;
						val12.AddVertexAt(0, val10, 0.0, 0.0, 0.0);
						val12.AddVertexAt(1, val11, 0.0, 0.0, 0.0);
						((Entity)val12).Layer = DeclaracoesGeral.ativo.Pagina;
						val5.AppendEntity((Entity)(object)val12);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)val12, true);
						ent = (Entity)(object)val12;
						XDataDIEnergisaSSE.GravarXDataCabo(ref ent, revisao, painel, Regua);
						val12 = (Polyline)ent;
						val10 = new Point2d(ptIns.X + 87.0, ptIns.Y);
						val11 = new Point2d(ptIns.X + 87.0, deltaY);
						val12 = new Polyline();
						((Entity)val12).SetDatabaseDefaults();
						((Entity)val12).ColorIndex = 7;
						val12.AddVertexAt(0, val10, 0.0, 0.0, 0.0);
						val12.AddVertexAt(1, val11, 0.0, 0.0, 0.0);
						((Entity)val12).Layer = DeclaracoesGeral.ativo.Pagina;
						val5.AppendEntity((Entity)(object)val12);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)val12, true);
						ent = (Entity)(object)val12;
						XDataDIEnergisaSSE.GravarXDataCabo(ref ent, revisao, painel, Regua);
						val12 = (Polyline)ent;
					}
					string textString = borneRI.cabos[index].TagDest;
					if (Operators.CompareString(borneRI.cabos[index].NReguaDest, "", TextCompare: true) != 0)
					{
						textString = borneRI.cabos[index].NReguaDest;
					}
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val9.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val13 = (Entity)val2.GetObject(current, (OpenMode)0);
							if (!(val13 is AttributeDefinition))
							{
								continue;
							}
							AttributeDefinition val14 = (AttributeDefinition)val13;
							AttributeReference val15 = new AttributeReference();
							val15.SetAttributeFromBlock(val14, val8.BlockTransform);
							string tag = val14.Tag;
							if (Operators.CompareString(tag, "R", TextCompare: true) != 0)
							{
								if (Operators.CompareString(tag, "B", TextCompare: true) != 0)
								{
									if (Operators.CompareString(tag, "COR1", TextCompare: true) != 0 && Operators.CompareString(tag, "COR2", TextCompare: true) != 0)
									{
										if (Operators.CompareString(tag, "CABO", TextCompare: true) != 0)
										{
											if (Operators.CompareString(tag, "DESTINO", TextCompare: true) != 0)
											{
												((Entity)val15).Visible = false;
											}
											else
											{
												((DBText)val15).TextString = borneRI.cabos[index].sPainelDest;
											}
										}
										else
										{
											((DBText)val15).TextString = borneRI.cabos[index].Tag_Cabo;
										}
									}
									else if (Operators.CompareString(borneRI.cabos[index].NomeVeia.Trim(), "", TextCompare: true) == 0)
									{
										((DBText)val15).TextString = Conversions.ToString(borneRI.cabos[index].Veia);
									}
									else
									{
										((DBText)val15).TextString = borneRI.cabos[index].NomeVeia;
									}
								}
								else
								{
									((DBText)val15).TextString = borneRI.cabos[index].BorneDest;
								}
							}
							else
							{
								((DBText)val15).TextString = textString;
							}
							((DBText)val15).AdjustAlignment(database);
							val8.AttributeCollection.AppendAttribute(val15);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)val15, true);
							((Entity)val15).Draw();
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
					((Entity)val8).Draw();
					ent = (Entity)(object)val8;
					XDataDIEnergisaSSE.GravarXDataCabo(ref ent, revisao, painel, Regua);
					val8 = (BlockReference)ent;
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					val2.Abort();
					Interaction.MsgBox(ex2.Message, MsgBoxStyle.Information);
					ProjectData.ClearProjectError();
				}
				finally
				{
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
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

	public static void buscaPaginasColuna(ref List<string> lPaginasColunas)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected Obj, but got Unknown
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
					if (Operators.CompareString(current.ObjectClass.DxfName.ToUpper(), "INSERT", TextCompare: true) == 0)
					{
						BlockReference val4 = (BlockReference)val.GetObject(current, (OpenMode)0);
						if (Operators.CompareString(val4.Name, "Coluna1", TextCompare: true) == 0 && !lPaginasColunas.Contains(((Entity)val4).Layer))
						{
							lPaginasColunas.Add(((Entity)val4).Layer);
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

	public static void buscaXColunas(ref double X1, ref double X2)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected Obj, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected Obj, but got Unknown
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		bool flag = false;
		bool flag2 = false;
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
					if (Operators.CompareString(current.ObjectClass.DxfName.ToUpper(), "INSERT", TextCompare: true) != 0)
					{
						continue;
					}
					BlockReference val4 = (BlockReference)val.GetObject(current, (OpenMode)0);
					Point3d position;
					if (Operators.CompareString(val4.Name, "Coluna1", TextCompare: true) != 0)
					{
						if (Operators.CompareString(val4.Name, "Coluna2", TextCompare: true) == 0)
						{
							position = val4.Position;
							X2 = position.X;
							flag2 = true;
						}
					}
					else
					{
						position = val4.Position;
						X1 = position.X;
						flag = true;
					}
					if (flag & flag2)
					{
						break;
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

	public static void insereColunasSePrecisar(ref List<string> lPaginasColunas, Point3d ptCol1, Point3d ptCol2, string nomePainel)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		if (!lPaginasColunas.Contains(DeclaracoesGeral.ativo.Pagina))
		{
			InserirColunaAranha("Coluna1.dwg", ptCol1, nomePainel);
			InserirColunaAranha("Coluna2.dwg", ptCol2, nomePainel);
			lPaginasColunas.Add(DeclaracoesGeral.ativo.Pagina);
		}
	}

	public static bool reguaExiste(int Painel, string Tag, string NRegua)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected Obj, but got Unknown
		bool result = false;
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
					if (Operators.CompareString(current.ObjectClass.DxfName.ToUpper(), "INSERT", TextCompare: true) != 0)
					{
						continue;
					}
					BlockReference blockRef = (BlockReference)val.GetObject(current, (OpenMode)0);
					if ((Operators.CompareString(blockRef.Name, "Borne1", TextCompare: true) == 0) | (Operators.CompareString(blockRef.Name, "Borne2", TextCompare: true) == 0) | (Operators.CompareString(blockRef.Name, "Borne3", TextCompare: true) == 0) | (Operators.CompareString(blockRef.Name, "Borne4", TextCompare: true) == 0))
					{
						DeclaracoesInterligacao.borneAranha bn = default;
						if (XDataDIEnergisaSSE.LerXDataBorne(ref blockRef, ref bn) && ((bn.Painel == Painel) & (Operators.CompareString(bn.Tag, Tag, TextCompare: true) == 0) & (Operators.CompareString(bn.NRegua, NRegua, TextCompare: true) == 0)))
						{
							result = true;
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
			return result;
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

	public static bool outraReguaExiste(string Pagina, ref Point3d pt, int colNum, ref double deltaY)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected Obj, but got Unknown
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
			BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
			Point3d val4 = new Point3d(0.0, 1000.0, 0.0);
			BlockTableRecordEnumerator enumerator = default;
			try
			{
				enumerator = val3.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ObjectId current = enumerator.Current;
					if (Operators.CompareString(current.ObjectClass.DxfName.ToUpper(), "INSERT", TextCompare: true) != 0)
					{
						continue;
					}
					BlockReference blockRef = (BlockReference)val.GetObject(current, (OpenMode)0);
					if (!((Operators.CompareString(blockRef.Name, "Borne1", TextCompare: true) == 0) | (Operators.CompareString(blockRef.Name, "Borne2", TextCompare: true) == 0) | (Operators.CompareString(blockRef.Name, "Borne3", TextCompare: true) == 0) | (Operators.CompareString(blockRef.Name, "Borne4", TextCompare: true) == 0)) || Operators.CompareString(((Entity)blockRef).Layer, Pagina, TextCompare: true) != 0)
					{
						continue;
					}
					DeclaracoesInterligacao.borneAranha bn = default;
					if (!XDataDIEnergisaSSE.LerXDataBorne(ref blockRef, ref bn) || bn.Posicao != colNum)
					{
						continue;
					}
					Point3d position = blockRef.Position;
					if (!(position.Y < val4.Y))
					{
						continue;
					}
					val4 = blockRef.Position;
					string name = blockRef.Name;
					if (Operators.CompareString(name, "Borne1", TextCompare: true) != 0)
					{
						if (Operators.CompareString(name, "Borne2", TextCompare: true) != 0)
						{
							if (Operators.CompareString(name, "Borne3", TextCompare: true) != 0)
							{
								if (Operators.CompareString(name, "Borne4", TextCompare: true) == 0)
								{
									deltaY = 25.0;
								}
							}
							else
							{
								deltaY = 20.0;
							}
						}
						else
						{
							deltaY = 15.0;
						}
					}
					else
					{
						deltaY = 10.0;
					}
					result = true;
				}
			}
			finally
			{
				((IDisposable)enumerator)?.Dispose();
			}
			pt = val4;
			DeclaracoesGeral.bAnularEventos = true;
			val.Commit();
			DeclaracoesGeral.bAnularEventos = false;
			return result;
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

	public static void ApagaRegua(string revisao, int Painel, string Tag, string NRegua)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected Obj, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected Obj, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Expected Obj, but got Unknown
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
					int painel = default;
					int painel2 = default;
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						if (Operators.CompareString(current.ObjectClass.DxfName.ToUpper(), "INSERT", TextCompare: true) != 0)
						{
							if (Operators.CompareString(current.ObjectClass.DxfName.ToUpper(), "LWPOLYLINE", TextCompare: true) == 0)
							{
								Entity ent = (Entity)val2.GetObject(current, (OpenMode)0);
								string revisao2 = "";
								if (XDataDIEnergisaSSE.LerXDataCabo(ref ent, ref revisao2, ref painel) && ((Operators.CompareString(revisao2, revisao, TextCompare: true) == 0) & (painel == Painel)))
								{
									((DBObject)ent).UpgradeOpen();
									((DBObject)ent).Erase();
								}
							}
							continue;
						}
						BlockReference blockRef = (BlockReference)val2.GetObject(current, (OpenMode)0);
						if (!((Operators.CompareString(blockRef.Name, "Borne1", TextCompare: true) == 0) | (Operators.CompareString(blockRef.Name, "Borne2", TextCompare: true) == 0) | (Operators.CompareString(blockRef.Name, "Borne3", TextCompare: true) == 0) | (Operators.CompareString(blockRef.Name, "Borne4", TextCompare: true) == 0)))
						{
							if ((Operators.CompareString(blockRef.Name, "Cabo", TextCompare: true) == 0) | (Operators.CompareString(blockRef.Name, "Cabo2", TextCompare: true) == 0))
							{
								string revisao3 = "";
								Entity ent2 = (Entity)(object)blockRef;
								bool flag = XDataDIEnergisaSSE.LerXDataCabo(ref ent2, ref revisao3, ref painel2);
								blockRef = (BlockReference)ent2;
								if (flag && ((Operators.CompareString(revisao3, revisao, TextCompare: true) == 0) & (painel2 == Painel)))
								{
									((DBObject)blockRef).UpgradeOpen();
									((DBObject)blockRef).Erase();
								}
							}
						}
						else
						{
							DeclaracoesInterligacao.borneAranha bn = default;
							if (XDataDIEnergisaSSE.LerXDataBorne(ref blockRef, ref bn) && ((Operators.CompareString(bn.Revisao, revisao, TextCompare: true) == 0) & (bn.Painel == Painel)))
							{
								((DBObject)blockRef).UpgradeOpen();
								((DBObject)blockRef).Erase();
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

	public static bool carregaBornesJ(string revisao, int Painel, ref DeclaracoesInterligacao.borneJ[] mBornesJ)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected Obj, but got Unknown
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val3.GetEnumerator();
					double num2 = default;
					double num3 = default;
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						if (Operators.CompareString(current.ObjectClass.DxfName.ToUpper(), "INSERT", TextCompare: true) != 0)
						{
							continue;
						}
						BlockReference blockRef = (BlockReference)val.GetObject(current, (OpenMode)0);
						if (!((Operators.CompareString(blockRef.Name, "Borne1", TextCompare: true) == 0) | (Operators.CompareString(blockRef.Name, "Borne2", TextCompare: true) == 0) | (Operators.CompareString(blockRef.Name, "Borne3", TextCompare: true) == 0) | (Operators.CompareString(blockRef.Name, "Borne4", TextCompare: true) == 0)))
						{
							continue;
						}
						DeclaracoesInterligacao.borneAranha bn = default;
						if (!XDataDIEnergisaSSE.LerXDataBorne(ref blockRef, ref bn) || bn.Painel != Painel)
						{
							continue;
						}
						result = true;
						int num = Information.UBound(mBornesJ) + 1;
						mBornesJ = (DeclaracoesInterligacao.borneJ[])Utils.CopyArray(mBornesJ, new DeclaracoesInterligacao.borneJ[num + 1]);
						mBornesJ[num].Tag = bn.Tag;
						mBornesJ[num].NRegua = bn.NRegua;
						mBornesJ[num].Borne = bn.Borne;
						mBornesJ[num].TipoBorne = bn.TipoBorne;
						ref DeclaracoesInterligacao.borneJ reference = ref mBornesJ[num];
						Point3d position = blockRef.Position;
						reference.Y = position.Y;
						mBornesJ[num].Pagina = ((Entity)blockRef).Layer;
						mBornesJ[num].PaginaNum = Pagina.calculaPaginaDecimal(((Entity)blockRef).Layer);
						mBornesJ[num].Posicao = bn.Posicao;
						mBornesJ[num].Handle = ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString();
						mBornesJ[num].contVeiasLigadas = 0;
						int posicao = bn.Posicao;
						if (posicao == 1 || posicao == 3)
						{
							int tipoBorne = bn.TipoBorne;
							if (unchecked((uint)tipoBorne) <= 4u)
							{
								num2 = 25.0;
								num3 = -2.5;
							}
						}
						ref DeclaracoesInterligacao.borneJ reference2 = ref mBornesJ[num];
						position = blockRef.Position;
						double num4 = position.X + num2;
						position = blockRef.Position;
						reference2.ptInsTerm = new Point2d(num4, position.Y + num3);
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				DeclaracoesGeral.bAnularEventos = true;
				val.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				DeclaracoesInterligacao.borneJ borneJ = default;
				if (Information.UBound(mBornesJ) >= 2)
				{
					int num5 = Information.UBound(mBornesJ);
					for (int i = 1; i <= num5; i++)
					{
						int num6 = Information.UBound(mBornesJ) - 1;
						int num7 = i;
						for (int j = num6; j >= num7; j += -1)
						{
							if (mBornesJ[j].PaginaNum > mBornesJ[j + 1].PaginaNum)
							{
								borneJ = mBornesJ[j + 1];
								mBornesJ[j + 1] = mBornesJ[j];
								mBornesJ[j] = borneJ;
							}
							if (mBornesJ[j].PaginaNum == mBornesJ[j + 1].PaginaNum && mBornesJ[j].Posicao > mBornesJ[j + 1].Posicao)
							{
								borneJ = mBornesJ[j + 1];
								mBornesJ[j + 1] = mBornesJ[j];
								mBornesJ[j] = borneJ;
							}
							if (((mBornesJ[j].PaginaNum == mBornesJ[j + 1].PaginaNum) & (mBornesJ[j].Posicao == mBornesJ[j + 1].Posicao)) && mBornesJ[j].Y < mBornesJ[j + 1].Y)
							{
								borneJ = mBornesJ[j + 1];
								mBornesJ[j + 1] = mBornesJ[j];
								mBornesJ[j] = borneJ;
							}
						}
					}
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
			return result;
		}
	}

	public static void buscaJumpers(ref DeclaracoesInterligacao.borneJ[] mBornesJ, ref DeclaracoesInterligacao.jumper[] mJumpers, ref DeclaracoesInterligacao.structureRI[] mReguas)
	{
		string text = "";
		string text2 = "";
		string text3 = "";
		int num = Information.UBound(mBornesJ);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				text = mBornesJ[i].Tag;
				text2 = mBornesJ[i].NRegua;
				text3 = mBornesJ[i].Borne;
				int num2 = Information.UBound(mReguas);
				for (int j = 1; j <= num2; j++)
				{
					if (!((Operators.CompareString(mReguas[j].Tag, text, TextCompare: true) == 0) & (Operators.CompareString(mReguas[j].NRegua, text2, TextCompare: true) == 0)))
					{
						continue;
					}
					int num3 = Information.UBound(mReguas[j].Bornes);
					for (int k = 1; k <= num3; k++)
					{
						if (Operators.CompareString(mReguas[j].Bornes[k].Borne, text3, TextCompare: true) != 0)
						{
							continue;
						}
						string text4 = "";
						string text5 = "";
						string text6 = "";
						int num4 = Information.UBound(mReguas[j].Bornes[k].jumpers);
						for (int l = 1; l <= num4; l++)
						{
							if (!mReguas[j].Bornes[k].jumpers[l].bSai)
							{
								continue;
							}
							text4 = mReguas[j].Bornes[k].jumpers[l].Tag;
							text5 = mReguas[j].Bornes[k].jumpers[l].NRegua;
							text6 = mReguas[j].Bornes[k].jumpers[l].Borne;
							int num5 = Information.UBound(mBornesJ);
							for (int m = 1; m <= num5; m++)
							{
								if ((Operators.CompareString(mBornesJ[m].Tag, text4, TextCompare: true) == 0) & (Operators.CompareString(mBornesJ[m].NRegua, text5, TextCompare: true) == 0) & (Operators.CompareString(mBornesJ[m].Borne, text6, TextCompare: true) == 0))
								{
									long num6 = Information.UBound(mJumpers) + 1;
									mJumpers = (DeclaracoesInterligacao.jumper[])Utils.CopyArray(mJumpers, new DeclaracoesInterligacao.jumper[(int)num6 + 1]);
									mJumpers[(int)num6].indexOrig = i;
									mJumpers[(int)num6].indexDest = m;
									double num7 = mBornesJ[m].Y - mBornesJ[i].Y;
									if (num7 < 0.0)
									{
										num7 *= -1.0;
									}
									mJumpers[(int)num6].dist = num7;
									if (!((Operators.CompareString(mBornesJ[i].Pagina, mBornesJ[m].Pagina, TextCompare: true) == 0) & (mBornesJ[i].Posicao == mBornesJ[m].Posicao)))
									{
										mJumpers[(int)num6].bMesmaPaginaColuna = false;
									}
									else
									{
										mJumpers[(int)num6].bMesmaPaginaColuna = true;
									}
								}
							}
						}
					}
				}
			}
			DeclaracoesInterligacao.jumper jumper = default;
			if (Information.UBound(mJumpers) < 2)
			{
				return;
			}
			int num8 = Information.UBound(mJumpers);
			for (int n = 1; n <= num8; n++)
			{
				int num9 = Information.UBound(mJumpers) - 1;
				int num10 = n;
				for (int num11 = num9; num11 >= num10; num11 += -1)
				{
					if (mJumpers[num11].dist > mJumpers[num11 + 1].dist)
					{
						jumper = mJumpers[num11 + 1];
						mJumpers[num11 + 1] = mJumpers[num11];
						mJumpers[num11] = jumper;
					}
				}
			}
		}
	}

	public static void desenhaJumper1(string revisao, int painel, ref DeclaracoesInterligacao.borneJ[] mBornesJ, ref DeclaracoesInterligacao.jumper[] mJumpers, long index)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected Obj, but got Unknown
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Expected Obj, but got Unknown
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
		//IL_036c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0371: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0400: Unknown result type (might be due to invalid IL or missing references)
		//IL_0402: Unknown result type (might be due to invalid IL or missing references)
		//IL_0404: Unknown result type (might be due to invalid IL or missing references)
		//IL_0406: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Expected Obj, but got Unknown
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_0433: Unknown result type (might be due to invalid IL or missing references)
		//IL_053d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0544: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
					try
					{
						string handle = mBornesJ[(int)mJumpers[(int)index].indexOrig].Handle;
						int tipoBorne = mBornesJ[(int)mJumpers[(int)index].indexOrig].TipoBorne;
						int posicao = mBornesJ[(int)mJumpers[(int)index].indexOrig].Posicao;
						string handle2 = mBornesJ[(int)mJumpers[(int)index].indexDest].Handle;
						int tipoBorne2 = mBornesJ[(int)mJumpers[(int)index].indexDest].TipoBorne;
						int posicao2 = mBornesJ[(int)mJumpers[(int)index].indexDest].Posicao;
						string pagina = mBornesJ[(int)mJumpers[(int)index].indexDest].Pagina;
						Point3d val5 = default;
						Entity val6 = (Entity)Geral.HandleToObject(handle);
						Point3d position;
						if (val6 != null)
						{
							BlockReference val7 = (BlockReference)(object)((val6 is BlockReference) ? val6 : null);
							if (((tipoBorne == 0) | (tipoBorne == 1) | (tipoBorne == 2) | (tipoBorne == 3) | (tipoBorne == 4)) && ((posicao == 1) | (posicao == 3)))
							{
								position = val7.Position;
								double num = position.X + 25.0;
								position = val7.Position;
								val5 = new Point3d(num, position.Y - 2.5, 0.0);
							}
						}
						Point3d val8 = default;
						val6 = (Entity)Geral.HandleToObject(handle2);
						if (val6 != null)
						{
							BlockReference val9 = (BlockReference)(object)((val6 is BlockReference) ? val6 : null);
							if (((tipoBorne2 == 0) | (tipoBorne2 == 1) | (tipoBorne2 == 2) | (tipoBorne2 == 3) | (tipoBorne2 == 4)) && ((posicao2 == 1) | (posicao2 == 3)))
							{
								position = val9.Position;
								double num2 = position.X + 25.0;
								position = val9.Position;
								val8 = new Point3d(num2, position.Y - 2.5, 0.0);
							}
						}
						Point3d val10 = default;
						if (val5.Y < val8.Y)
						{
							val10 = val5;
							val5 = val8;
							val8 = val10;
						}
						double num3 = default;
						if ((posicao == 1) | (posicao == 3))
						{
							num3 = 2.5;
						}
						int num4 = 1;
						Polyline val15;
						while (true)
						{
							Point2d val11 = new Point2d(val5.X, val5.Y);
							Point2d val12 = new Point2d(val5.X + num3 * (double)num4, val5.Y - 1.5);
							Point2d val13 = new Point2d(val8.X + num3 * (double)num4, val8.Y + 1.5);
							Point2d val14 = new Point2d(val8.X, val8.Y);
							val15 = new Polyline();
							((Entity)val15).SetDatabaseDefaults();
							((Entity)val15).ColorIndex = 7;
							val15.AddVertexAt(0, val11, 0.0, 0.0, 0.0);
							val15.AddVertexAt(1, val12, 0.0, 0.0, 0.0);
							val15.AddVertexAt(2, val13, 0.0, 0.0, 0.0);
							val15.AddVertexAt(3, val14, 0.0, 0.0, 0.0);
							((Entity)val15).Layer = pagina;
							((Entity)val15).LineWeight = (LineWeight)9;
							if (!kT3puIkumE(val12.X, val12.Y, val13.Y, pagina, revisao, painel))
							{
								break;
							}
							num4++;
							((DisposableWrapper)val15).Dispose();
						}
						val4.AppendEntity((Entity)(object)val15);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)val15, true);
						DeclaracoesInterligacao.borneAranha bnO = new DeclaracoesInterligacao.borneAranha
						{
							Tag = mBornesJ[(int)mJumpers[(int)index].indexOrig].Tag,
							NRegua = mBornesJ[(int)mJumpers[(int)index].indexOrig].NRegua,
							Borne = mBornesJ[(int)mJumpers[(int)index].indexOrig].Borne
						};
						DeclaracoesInterligacao.borneAranha bnD = new DeclaracoesInterligacao.borneAranha
						{
							Tag = mBornesJ[(int)mJumpers[(int)index].indexDest].Tag,
							NRegua = mBornesJ[(int)mJumpers[(int)index].indexDest].NRegua,
							Borne = mBornesJ[(int)mJumpers[(int)index].indexDest].Borne
						};
						Entity ent = (Entity)(object)val15;
						XDataDIEnergisaSSE.GravarXDataJumper(ref ent, revisao, painel, bnO, bnD);
						val15 = (Polyline)ent;
						DeclaracoesGeral.bAnularEventos = true;
						val2.Commit();
						DeclaracoesGeral.bAnularEventos = false;
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						val2.Abort();
						Interaction.MsgBox(ex2.Message, MsgBoxStyle.Information);
						ProjectData.ClearProjectError();
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

	private static bool kT3puIkumE(double P_0, double P_1, double P_2, string P_3, string P_4, int P_5)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected Obj, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected Obj, but got Unknown
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			BlockTable val = (BlockTable)topTransaction.GetObject(database.BlockTableId, (OpenMode)0);
			try
			{
				BlockTableRecord val2 = (BlockTableRecord)topTransaction.GetObject(((SymbolTable)val)[BlockTableRecord.ModelSpace], (OpenMode)0);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val2.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val3 = (Entity)topTransaction.GetObject(current, (OpenMode)0);
						if (Operators.CompareString(P_3, val3.Layer, TextCompare: true) != 0)
						{
							continue;
						}
						Polyline val4 = (Polyline)(object)((val3 is Polyline) ? val3 : null);
						if (val4 == null)
						{
							continue;
						}
						DeclaracoesInterligacao.borneAranha bnO = default;
						DeclaracoesInterligacao.borneAranha bnD = default;
						Entity ent = (Entity)(object)val4;
						bool flag = XDataDIEnergisaSSE.LerXDataJumper(ref ent, ref P_4, ref P_5, ref bnO, ref bnD);
						val4 = (Polyline)ent;
						if (!flag)
						{
							continue;
						}
						LineSegment2d lineSegment2dAt = val4.GetLineSegment2dAt(1);
						Point2d val5 = lineSegment2dAt.StartPoint;
						if (P_0 == val5.X)
						{
							val5 = lineSegment2dAt.StartPoint;
							bool flag2 = P_1 > val5.Y;
							val5 = lineSegment2dAt.EndPoint;
							bool num = flag2 & (P_1 > val5.Y);
							val5 = lineSegment2dAt.StartPoint;
							bool num2 = num & (P_2 > val5.Y);
							val5 = lineSegment2dAt.EndPoint;
							bool num3 = num2 & (P_2 > val5.Y);
							val5 = lineSegment2dAt.StartPoint;
							bool flag3 = P_1 < val5.Y;
							val5 = lineSegment2dAt.EndPoint;
							bool num4 = flag3 & (P_1 < val5.Y);
							val5 = lineSegment2dAt.StartPoint;
							bool num5 = num4 & (P_2 < val5.Y);
							val5 = lineSegment2dAt.EndPoint;
							if (!(num3 | (num5 & (P_2 < val5.Y))))
							{
								result = true;
								break;
							}
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
		finally
		{
			((IDisposable)topTransaction)?.Dispose();
		}
		return result;
	}

	public static void desenhaJumper2(string revisao, int painel, ref DeclaracoesInterligacao.borneJ[] mBornesJ, ref DeclaracoesInterligacao.jumper[] mJumpers, long index)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Expected Obj, but got Unknown
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Expected Obj, but got Unknown
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_067f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0684: Unknown result type (might be due to invalid IL or missing references)
		//IL_0699: Unknown result type (might be due to invalid IL or missing references)
		//IL_069e: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_075c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0767: Unknown result type (might be due to invalid IL or missing references)
		//IL_076e: Expected Obj, but got Unknown
		//IL_0770: Unknown result type (might be due to invalid IL or missing references)
		//IL_0775: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Expected Obj, but got Unknown
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_070a: Unknown result type (might be due to invalid IL or missing references)
		//IL_070f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0724: Unknown result type (might be due to invalid IL or missing references)
		//IL_0729: Unknown result type (might be due to invalid IL or missing references)
		//IL_0745: Unknown result type (might be due to invalid IL or missing references)
		//IL_074a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0306: Expected Obj, but got Unknown
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_0338: Expected Obj, but got Unknown
		//IL_0348: Unknown result type (might be due to invalid IL or missing references)
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
		//IL_0358: Unknown result type (might be due to invalid IL or missing references)
		//IL_035f: Expected Obj, but got Unknown
		//IL_036d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0374: Expected Obj, but got Unknown
		//IL_0374: Unknown result type (might be due to invalid IL or missing references)
		//IL_037b: Expected Obj, but got Unknown
		//IL_0381: Unknown result type (might be due to invalid IL or missing references)
		//IL_0478: Unknown result type (might be due to invalid IL or missing references)
		//IL_047f: Expected Obj, but got Unknown
		//IL_03bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0780: Unknown result type (might be due to invalid IL or missing references)
		//IL_078b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0792: Expected Obj, but got Unknown
		//IL_0794: Unknown result type (might be due to invalid IL or missing references)
		//IL_0799: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b2: Expected Obj, but got Unknown
		//IL_04ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04de: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e7: Expected Obj, but got Unknown
		//IL_04f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_050a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0512: Unknown result type (might be due to invalid IL or missing references)
		//IL_0519: Expected Obj, but got Unknown
		//IL_0529: Unknown result type (might be due to invalid IL or missing references)
		//IL_052e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0531: Unknown result type (might be due to invalid IL or missing references)
		//IL_0539: Unknown result type (might be due to invalid IL or missing references)
		//IL_0540: Expected Obj, but got Unknown
		//IL_054e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0555: Expected Obj, but got Unknown
		//IL_0555: Unknown result type (might be due to invalid IL or missing references)
		//IL_055c: Expected Obj, but got Unknown
		//IL_0562: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c1: Expected Obj, but got Unknown
		//IL_05a0: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
					try
					{
						string tag = mBornesJ[(int)mJumpers[(int)index].indexOrig].Tag;
						string nRegua = mBornesJ[(int)mJumpers[(int)index].indexOrig].NRegua;
						string borne = mBornesJ[(int)mJumpers[(int)index].indexOrig].Borne;
						string handle = mBornesJ[(int)mJumpers[(int)index].indexOrig].Handle;
						int tipoBorne = mBornesJ[(int)mJumpers[(int)index].indexOrig].TipoBorne;
						int posicao = mBornesJ[(int)mJumpers[(int)index].indexOrig].Posicao;
						string pagina = mBornesJ[(int)mJumpers[(int)index].indexOrig].Pagina;
						string tag2 = mBornesJ[(int)mJumpers[(int)index].indexDest].Tag;
						string nRegua2 = mBornesJ[(int)mJumpers[(int)index].indexDest].NRegua;
						string borne2 = mBornesJ[(int)mJumpers[(int)index].indexDest].Borne;
						string handle2 = mBornesJ[(int)mJumpers[(int)index].indexDest].Handle;
						int tipoBorne2 = mBornesJ[(int)mJumpers[(int)index].indexDest].TipoBorne;
						int posicao2 = mBornesJ[(int)mJumpers[(int)index].indexDest].Posicao;
						string pagina2 = mBornesJ[(int)mJumpers[(int)index].indexDest].Pagina;
						DeclaracoesInterligacao.borneAranha bnO = new DeclaracoesInterligacao.borneAranha
						{
							Tag = tag,
							NRegua = nRegua,
							Borne = borne
						};
						DeclaracoesInterligacao.borneAranha bnD = new DeclaracoesInterligacao.borneAranha
						{
							Tag = tag2,
							NRegua = nRegua2,
							Borne = borne2
						};
						string text = "";
						Point3d val5 = default;
						Entity val6 = (Entity)Geral.HandleToObject(handle);
						Point3d position;
						if (val6 != null)
						{
							BlockReference val7 = (BlockReference)(object)((val6 is BlockReference) ? val6 : null);
							if (((tipoBorne == 0) | (tipoBorne == 1) | (tipoBorne == 2) | (tipoBorne == 3) | (tipoBorne == 4)) && ((posicao == 1) | (posicao == 3)))
							{
								position = val7.Position;
								double num = position.X + 25.0;
								position = val7.Position;
								val5 = new Point3d(num, position.Y - 2.5, 0.0);
								text = "JumperSaiDireita";
							}
						}
						string text2 = "";
						Point3d val8 = default;
						val6 = (Entity)Geral.HandleToObject(handle2);
						if (val6 != null)
						{
							BlockReference val9 = (BlockReference)(object)((val6 is BlockReference) ? val6 : null);
							if (((tipoBorne2 == 0) | (tipoBorne2 == 1) | (tipoBorne2 == 2) | (tipoBorne2 == 3) | (tipoBorne2 == 4)) && ((posicao2 == 1) | (posicao2 == 3)))
							{
								position = val9.Position;
								double num2 = position.X + 25.0;
								position = val9.Position;
								val8 = new Point3d(num2, position.Y - 2.5, 0.0);
								text2 = "JumperEntraDireita";
							}
						}
						ObjectId val10 = ObjectId.Null;
						string text3 = "";
						text3 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Interligação\\EnergisaSSE\\" + text + ".dwg";
						if (!((SymbolTable)val3).Has(text))
						{
							Database val11 = new Database(false, true);
							val11.ReadDwgFile(text3, FileShare.Read, true, "");
							DeclaracoesGeral.bAnularEventos = true;
							val10 = database.Insert(text, val11, false);
							((DisposableWrapper)val11).Dispose();
						}
						else
						{
							BlockTableRecord val12 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[text], (OpenMode)0);
							val10 = ((DBObject)val12).Id;
						}
						BlockReference val13 = new BlockReference(val5, val10);
						((Entity)val13).Layer = pagina;
						val4.AppendEntity((Entity)(object)val13);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)val13, true);
						BlockTableRecord val14 = (BlockTableRecord)val2.GetObject(val10, (OpenMode)0);
						BlockTableRecordEnumerator enumerator = default;
						try
						{
							enumerator = val14.GetEnumerator();
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.Current;
								Entity val15 = (Entity)val2.GetObject(current, (OpenMode)0);
								if (!(val15 is AttributeDefinition))
								{
									continue;
								}
								AttributeDefinition val16 = (AttributeDefinition)val15;
								AttributeReference val17 = new AttributeReference();
								val17.SetAttributeFromBlock(val16, val13.BlockTransform);
								string tag3 = val16.Tag;
								if (Operators.CompareString(tag3, "BORNE", TextCompare: true) != 0)
								{
									((Entity)val17).Visible = false;
								}
								else
								{
									string text4 = tag2;
									if (Operators.CompareString(nRegua2, "", TextCompare: true) != 0)
									{
										text4 = nRegua2;
									}
									text4 = text4 + "-" + borne2;
									if (Operators.CompareString(pagina, pagina2, TextCompare: true) != 0)
									{
										text4 = text4 + DeclaracoesGeral.Conf.PrefixoCruzInterno + pagina2 + DeclaracoesGeral.Conf.SufixoCruzInterno;
									}
									((DBText)val17).TextString = text4;
								}
								((DBText)val17).AdjustAlignment(database);
								val13.AttributeCollection.AppendAttribute(val17);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val17, true);
								((Entity)val17).Draw();
							}
						}
						finally
						{
							((IDisposable)enumerator)?.Dispose();
						}
						((Entity)val13).Draw();
						Entity ent = (Entity)(object)val13;
						XDataDIEnergisaSSE.GravarXDataJumper(ref ent, revisao, painel, bnO, bnD);
						val13 = (BlockReference)ent;
						text3 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Interligação\\EnergisaSSE\\" + text2 + ".dwg";
						if (!((SymbolTable)val3).Has(text2))
						{
							Database val18 = new Database(false, true);
							val18.ReadDwgFile(text3, FileShare.Read, true, "");
							DeclaracoesGeral.bAnularEventos = true;
							val10 = database.Insert(text2, val18, false);
							((DisposableWrapper)val18).Dispose();
						}
						else
						{
							BlockTableRecord val19 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[text2], (OpenMode)0);
							val10 = ((DBObject)val19).Id;
						}
						val13 = new BlockReference(val8, val10);
						((Entity)val13).Layer = pagina2;
						val4.AppendEntity((Entity)(object)val13);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)val13, true);
						val14 = (BlockTableRecord)val2.GetObject(val10, (OpenMode)0);
						BlockTableRecordEnumerator enumerator2 = default;
						try
						{
							enumerator2 = val14.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								ObjectId current2 = enumerator2.Current;
								Entity val20 = (Entity)val2.GetObject(current2, (OpenMode)0);
								if (!(val20 is AttributeDefinition))
								{
									continue;
								}
								AttributeDefinition val21 = (AttributeDefinition)val20;
								AttributeReference val22 = new AttributeReference();
								val22.SetAttributeFromBlock(val21, val13.BlockTransform);
								string tag4 = val21.Tag;
								if (Operators.CompareString(tag4, "BORNE", TextCompare: true) != 0)
								{
									((Entity)val22).Visible = false;
								}
								else
								{
									string text5 = tag;
									if (Operators.CompareString(nRegua, "", TextCompare: true) != 0)
									{
										text5 = nRegua;
									}
									text5 = text5 + "-" + borne;
									if (Operators.CompareString(pagina, pagina2, TextCompare: true) != 0)
									{
										text5 = text5 + DeclaracoesGeral.Conf.PrefixoCruzInterno + pagina + DeclaracoesGeral.Conf.SufixoCruzInterno;
									}
									((DBText)val22).TextString = text5;
								}
								((DBText)val22).AdjustAlignment(database);
								val13.AttributeCollection.AppendAttribute(val22);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val22, true);
								((Entity)val22).Draw();
							}
						}
						finally
						{
							((IDisposable)enumerator2)?.Dispose();
						}
						((Entity)val13).Draw();
						ent = (Entity)(object)val13;
						XDataDIEnergisaSSE.GravarXDataJumper(ref ent, revisao, painel, bnO, bnD);
						val13 = (BlockReference)ent;
						DeclaracoesGeral.bAnularEventos = true;
						val2.Commit();
						DeclaracoesGeral.bAnularEventos = false;
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						val2.Abort();
						Interaction.MsgBox(ex2.Message, MsgBoxStyle.Information);
						ProjectData.ClearProjectError();
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

	public static void ApagaJumper(string revisao, int Painel)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected Obj, but got Unknown
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
					int painel = default;
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						if ((Operators.CompareString(current.ObjectClass.DxfName.ToUpper(), "LWPOLYLINE", TextCompare: true) == 0) | (Operators.CompareString(current.ObjectClass.DxfName.ToUpper(), "INSERT", TextCompare: true) == 0))
						{
							Entity ent = (Entity)val2.GetObject(current, (OpenMode)0);
							string revisao2 = "";
							DeclaracoesInterligacao.borneAranha bnO = default;
							DeclaracoesInterligacao.borneAranha bnD = default;
							if (XDataDIEnergisaSSE.LerXDataJumper(ref ent, ref revisao2, ref painel, ref bnO, ref bnD) && ((Operators.CompareString(revisao2, revisao, TextCompare: true) == 0) & (painel == Painel)))
							{
								((DBObject)ent).UpgradeOpen();
								((DBObject)ent).Erase();
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

	public static bool SelecionaBorne(ref string rev, ref int painel)
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected Obj, but got Unknown
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected Obj, but got Unknown
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Invalid comparison between Unknown and I4
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected Obj, but got Unknown
		PointMonitorToolTips.StopMonitor();
		bool result = false;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
					Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
					PromptEntityOptions val4 = new PromptEntityOptions("");
					val4.SetRejectMessage(Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 1351])));
					((PromptOptions)val4).Message = Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 1351]));
					val4.AddAllowedClass(typeof(BlockReference), true);
					PromptEntityResult entity = editor.GetEntity(val4);
					if ((int)((PromptResult)entity).Status != -5002)
					{
						ObjectId objectId = entity.ObjectId;
						BlockReference blockRef = (BlockReference)objectId.GetObject((OpenMode)0);
						DeclaracoesInterligacao.borneAranha bn = default;
						if (XDataDIEnergisaSSE.LerXDataBorne(ref blockRef, ref bn))
						{
							rev = bn.Revisao;
							painel = bn.Painel;
							result = true;
						}
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
					mdiActiveDocument.SendStringToExecute("\u001b", true, false, false);
				}
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
			return result;
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}
}

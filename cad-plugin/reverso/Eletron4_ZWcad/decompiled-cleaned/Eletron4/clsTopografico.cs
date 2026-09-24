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
using ZwSoft.ZwCAD.GraphicsInterface;
using ZwSoft.ZwCAD.Runtime;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

public class clsTopografico
{
	public static string InserirBlocoDispTopografico(DeclaracoesTopografico.structureDispTopografico dTpg, string nomebloco)
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected Obj, but got Unknown
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02da: Expected Obj, but got Unknown
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected Obj, but got Unknown
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected Obj, but got Unknown
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Invalid comparison between Unknown and I4
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Invalid comparison between Unknown and I4
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected Obj, but got Unknown
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Expected Obj, but got Unknown
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Expected Obj, but got Unknown
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Expected Obj, but got Unknown
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				try
				{
					ObjectId val3 = ObjectId.Null;
					BlockTable val4 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)1);
					string text = nomebloco.Substring(0, checked(nomebloco.Length - 4));
					string text2 = DeclaracoesGeral.Conf.dirSimbologiaTopografico + nomebloco;
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
					BlockReference blockRef = new BlockReference(Point3d.Origin, val3);
					((Entity)blockRef).Layer = DeclaracoesGeral.ativo.Pagina;
					Jig jig = new Jig((Entity)(object)blockRef);
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
					PromptResult val8 = editor.Drag((Jig)(object)jig);
					if (!(((int)val8.Status == -5002) | ((int)val8.Status == -5001)))
					{
						val5.AppendEntity((Entity)(object)blockRef);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)blockRef, true);
						BlockTableRecord val9 = (BlockTableRecord)val2.GetObject(val3, (OpenMode)0);
						BlockTableRecordEnumerator enumerator = default;
						try
						{
							enumerator = val9.GetEnumerator();
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.Current;
								Entity val10 = (Entity)val2.GetObject(current, (OpenMode)0);
								if (!(val10 is AttributeDefinition))
								{
									continue;
								}
								AttributeDefinition val11 = (AttributeDefinition)val10;
								AttributeReference val12 = new AttributeReference();
								val12.SetAttributeFromBlock(val11, blockRef.BlockTransform);
								string tag = val11.Tag;
								if (Operators.CompareString(tag, "NOME", TextCompare: true) != 0)
								{
									if (Operators.CompareString(tag, "ALT", TextCompare: true) != 0)
									{
										if (Operators.CompareString(tag, "@LM", TextCompare: true) != 0)
										{
											((DBText)val12).TextString = val11.Tag;
										}
										else
										{
											((DBText)val12).TextString = "?";
										}
									}
									else
									{
										((DBText)val12).TextString = dTpg.alternativo;
									}
								}
								else
								{
									((DBText)val12).TextString = dTpg.tag;
								}
								((DBText)val12).AdjustAlignment(database);
								blockRef.AttributeCollection.AppendAttribute(val12);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val12, true);
								((Entity)val12).Draw();
								((DBObject)val12).XData = ((DBObject)val11).XData;
							}
						}
						finally
						{
							((IDisposable)enumerator)?.Dispose();
						}
						((Entity)blockRef).Draw();
						XDataTopografico.GravarXDataDispTopografico(ref blockRef, dTpg);
						result = ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString();
					}
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
		return result;
	}

	public static string InserirPrimeiroBorneTopografico(DeclaracoesTopografico.structureBorneTopografico bTpg, string nomebloco)
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected Obj, but got Unknown
		//IL_03e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fa: Expected Obj, but got Unknown
		//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0401: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected Obj, but got Unknown
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected Obj, but got Unknown
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Invalid comparison between Unknown and I4
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Invalid comparison between Unknown and I4
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected Obj, but got Unknown
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Expected Obj, but got Unknown
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected Obj, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Expected Obj, but got Unknown
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Expected Obj, but got Unknown
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_040f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0414: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Expected Obj, but got Unknown
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_041d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0422: Unknown result type (might be due to invalid IL or missing references)
		//IL_0437: Unknown result type (might be due to invalid IL or missing references)
		//IL_043c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0458: Unknown result type (might be due to invalid IL or missing references)
		//IL_045d: Unknown result type (might be due to invalid IL or missing references)
		//IL_032b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0330: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Unknown result type (might be due to invalid IL or missing references)
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0352: Unknown result type (might be due to invalid IL or missing references)
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0371: Unknown result type (might be due to invalid IL or missing references)
		//IL_0376: Unknown result type (might be due to invalid IL or missing references)
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_0387: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c7: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				try
				{
					ObjectId val3 = ObjectId.Null;
					BlockTable val4 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)1);
					string text = nomebloco.Substring(0, checked(nomebloco.Length - 4));
					string text2 = DeclaracoesGeral.Conf.dirSimbologiaTopografico + "Auxiliares\\" + nomebloco;
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
					BlockReference blockRef = new BlockReference(Point3d.Origin, val3);
					((Entity)blockRef).Layer = DeclaracoesGeral.ativo.Pagina;
					Jig jig = new Jig((Entity)(object)blockRef);
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
					PromptResult val8 = editor.Drag((Jig)(object)jig);
					if (!(((int)val8.Status == -5002) | ((int)val8.Status == -5001)))
					{
						val5.AppendEntity((Entity)(object)blockRef);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)blockRef, true);
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
									val12.SetAttributeFromBlock(val11, blockRef.BlockTransform);
									string tag = val11.Tag;
									if (Operators.CompareString(tag, "NUM", TextCompare: true) != 0)
									{
										((Entity)val12).Visible = false;
									}
									else
									{
										((DBText)val12).TextString = bTpg.borne;
									}
									((DBText)val12).AdjustAlignment(database);
									blockRef.AttributeCollection.AppendAttribute(val12);
									DeclaracoesGeral.bAnularEventos = true;
									val2.AddNewlyCreatedDBObject((DBObject)(object)val12, true);
									((Entity)val12).Draw();
									((DBObject)val12).XData = ((DBObject)val11).XData;
								}
							}
						}
						finally
						{
							((IDisposable)enumerator)?.Dispose();
						}
						((Entity)blockRef).Draw();
						XDataTopografico.GravarXDataBorneTopografico(ref blockRef, bTpg);
						result = ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString();
						TextStyleTable val13 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)0);
						ObjectId textStyleId = (((SymbolTable)val13).Has("Romans") ? ((SymbolTable)val13)["Romans"] : ((SymbolTable)val13)["Standard"]);
						DBText val14 = new DBText();
						val14.TextString = bTpg.regua;
						((Entity)val14).ColorIndex = DeclaracoesGeral.Conf.CorTextoCircuito;
						((Entity)val14).Layer = ((Entity)blockRef).Layer;
						val14.Height = 3.0;
						val14.TextStyleId = textStyleId;
						val14.WidthFactor = 1.0;
						Point3d val15;
						Point3d alignmentPoint;
						if (!nomebloco.Contains("90"))
						{
							Extents3d value = ((Drawable)blockRef).Bounds.Value;
							val15 = value.MaxPoint;
							double x = val15.X;
							value = ((Drawable)blockRef).Bounds.Value;
							val15 = value.MinPoint;
							double num = (x - val15.X) / 2.0;
							val15 = blockRef.Position;
							double num2 = num + val15.X;
							val15 = blockRef.Position;
							alignmentPoint = new Point3d(num2, val15.Y + 2.0, 0.0);
							val14.HorizontalMode = (TextHorizontalMode)1;
							val14.VerticalMode = (TextVerticalMode)0;
						}
						else
						{
							val15 = blockRef.Position;
							double num3 = val15.X - 2.0;
							val15 = blockRef.Position;
							alignmentPoint = new Point3d(num3, val15.Y + 4.5, 0.0);
							val14.HorizontalMode = (TextHorizontalMode)2;
							val14.VerticalMode = (TextVerticalMode)0;
						}
						val14.AlignmentPoint = alignmentPoint;
						val5.AppendEntity((Entity)(object)val14);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)val14, true);
					}
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
		return result;
	}

	public static string InserirOutroBorneTopografico(DeclaracoesTopografico.structureBorneTopografico bTpg, string nomebloco, Point3d ptIns)
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected Obj, but got Unknown
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Expected Obj, but got Unknown
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected Obj, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected Obj, but got Unknown
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected Obj, but got Unknown
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected Obj, but got Unknown
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Expected Obj, but got Unknown
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected Obj, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
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
					string text2 = DeclaracoesGeral.Conf.dirSimbologiaTopografico + "Auxiliares\\" + nomebloco;
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
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val8.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val9 = (Entity)val2.GetObject(current, (OpenMode)0);
							if (val9 is AttributeDefinition)
							{
								AttributeDefinition val10 = (AttributeDefinition)val9;
								AttributeReference val11 = new AttributeReference();
								val11.SetAttributeFromBlock(val10, blockRef.BlockTransform);
								string tag = val10.Tag;
								if (Operators.CompareString(tag, "NUM", TextCompare: true) != 0)
								{
									((Entity)val11).Visible = false;
								}
								else
								{
									((DBText)val11).TextString = bTpg.borne;
								}
								((DBText)val11).AdjustAlignment(database);
								blockRef.AttributeCollection.AppendAttribute(val11);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val11, true);
								((Entity)val11).Draw();
								((DBObject)val11).XData = ((DBObject)val10).XData;
							}
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
					((Entity)blockRef).Draw();
					XDataTopografico.GravarXDataBorneTopografico(ref blockRef, bTpg);
					result = ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString();
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
		return result;
	}

	public static void InserirTerminaisDispositivo(DeclaracoesTopografico.structureDispTopografico dTpg, ref DeclaracoesTopografico.structureConfigTopografico ctpg, ref string sblockRef, ref DeclaracoesTopografico.structureLigTermTopografico[] mLigacoes, bool bIgnorarExcedentes, bool bAlternativo, bool bIgnorarFaltantes)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected Obj, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected Obj, but got Unknown
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected Obj, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected Obj, but got Unknown
		//IL_0578: Unknown result type (might be due to invalid IL or missing references)
		//IL_057d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b87: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b92: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b99: Expected Obj, but got Unknown
		//IL_0b9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba0: Unknown result type (might be due to invalid IL or missing references)
		//IL_058e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0595: Expected Obj, but got Unknown
		//IL_05b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0606: Unknown result type (might be due to invalid IL or missing references)
		//IL_060b: Unknown result type (might be due to invalid IL or missing references)
		//IL_060d: Unknown result type (might be due to invalid IL or missing references)
		//IL_060f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0611: Unknown result type (might be due to invalid IL or missing references)
		//IL_0618: Expected Obj, but got Unknown
		//IL_0633: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0803: Unknown result type (might be due to invalid IL or missing references)
		//IL_080a: Expected Obj, but got Unknown
		//IL_0821: Unknown result type (might be due to invalid IL or missing references)
		//IL_0826: Unknown result type (might be due to invalid IL or missing references)
		//IL_0829: Unknown result type (might be due to invalid IL or missing references)
		//IL_0831: Unknown result type (might be due to invalid IL or missing references)
		//IL_0838: Expected Obj, but got Unknown
		//IL_08f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0844: Unknown result type (might be due to invalid IL or missing references)
		//IL_084b: Expected Obj, but got Unknown
		//IL_084d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0854: Expected Obj, but got Unknown
		//IL_085a: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a2: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				_ = Application.DocumentManager.MdiActiveDocument.Editor;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					try
					{
						BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
						BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
						DeclaracoesTopografico.structureTermBlocoTopografico[] array = new DeclaracoesTopografico.structureTermBlocoTopografico[1];
						BlockReference val5 = (BlockReference)Geral.HandleToObject(sblockRef);
						AttributeCollection attributeCollection = val5.AttributeCollection;
						foreach (object item in attributeCollection)
						{
							ObjectId val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							AttributeReference attRef = (AttributeReference)val6.GetObject((OpenMode)0);
							DeclaracoesTopografico.structureTermBlocoTopografico term = default;
							string left = attRef.Tag.ToUpper();
							if (Operators.CompareString(left, "NOME", TextCompare: true) != 0 && Operators.CompareString(left, "ALT", TextCompare: true) != 0 && Operators.CompareString(left, "@LM", TextCompare: true) != 0 && XDataTopografico.lerXDataAtributoTopografico(ref attRef, ref term))
							{
								array = (DeclaracoesTopografico.structureTermBlocoTopografico[])Utils.CopyArray(array, new DeclaracoesTopografico.structureTermBlocoTopografico[Information.UBound(array) + 1 + 1]);
								array[Information.UBound(array)] = term;
							}
						}
						int num = 0;
						List<string> list = new List<string>();
						int num2 = Information.UBound(mLigacoes);
						for (int i = 1; i <= num2; i++)
						{
							bool flag = false;
							int num3 = Information.UBound(array);
							for (int j = 1; j <= num3; j++)
							{
								if (Operators.CompareString(mLigacoes[i].Terminal.ToUpper(), array[j].terminal.ToUpper(), TextCompare: true) == 0)
								{
									flag = true;
									break;
								}
							}
							if (!flag)
							{
								if (!list.Contains(mLigacoes[i].Terminal.ToUpper()))
								{
									list.Add(mLigacoes[i].Terminal.ToUpper());
								}
								num++;
							}
						}
						if (!((num > 0) & !bIgnorarFaltantes))
						{
							List<string> list2 = new List<string>();
							int num4 = Information.UBound(array);
							for (int k = 1; k <= num4; k++)
							{
								bool flag2 = false;
								int num5 = Information.UBound(mLigacoes);
								for (int l = 1; l <= num5; l++)
								{
									if (Operators.CompareString(array[k].terminal.ToUpper(), mLigacoes[l].Terminal.ToUpper(), TextCompare: true) == 0)
									{
										flag2 = true;
										break;
									}
								}
								if (!flag2)
								{
									list2.Add(array[k].terminal);
								}
							}
							if ((list2.Count > 0) & !bIgnorarExcedentes)
							{
								string text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 856]);
								foreach (string item2 in list2)
								{
									text = text + " " + item2 + ",";
								}
								text = Strings.Mid(text, 1, text.Length - 1) + " ";
								text = Conversions.ToString(Operators.AddObject(text, DeclaracoesGeral.mMensagem[1, 857]));
								MsgBoxResult msgBoxResult = Interaction.MsgBox(text, MsgBoxStyle.YesNo);
								if (msgBoxResult == MsgBoxResult.No)
								{
									goto IL_0c79;
								}
							}
							int num6 = Information.UBound(array);
							BlockTableRecordEnumerator enumerator3 = default;
							for (int m = 1; m <= num6; m++)
							{
								int num7 = 0;
								int num8 = 0;
								int num9 = Information.UBound(mLigacoes);
								for (int n = 1; n <= num9; n++)
								{
									if (Operators.CompareString(array[m].terminal.ToUpper(), mLigacoes[n].Terminal.ToUpper(), TextCompare: true) == 0)
									{
										num7 = Information.UBound(mLigacoes[n].Lig);
										num8 = n;
										break;
									}
								}
								string text2 = "";
								double rotation = 0.0;
								switch (num7)
								{
								case 2:
									if (!((Operators.CompareString(array[m].orientacao, "R", TextCompare: true) == 0) | (Operators.CompareString(array[m].orientacao, "U", TextCompare: true) == 0)))
									{
										if ((Operators.CompareString(array[m].orientacao, "D", TextCompare: true) == 0) | (Operators.CompareString(array[m].orientacao, "L", TextCompare: true) == 0))
										{
											text2 = "DUPLO_L";
											if (Operators.CompareString(array[m].orientacao, "D", TextCompare: true) == 0)
											{
												rotation = Math.PI / 2.0;
											}
										}
									}
									else
									{
										text2 = "DUPLO_R";
										if (Operators.CompareString(array[m].orientacao, "U", TextCompare: true) == 0)
										{
											rotation = Math.PI / 2.0;
										}
									}
									break;
								case 0:
									continue;
								default:
									if (!((Operators.CompareString(array[m].orientacao, "R", TextCompare: true) == 0) | (Operators.CompareString(array[m].orientacao, "U", TextCompare: true) == 0)))
									{
										if ((Operators.CompareString(array[m].orientacao, "D", TextCompare: true) == 0) | (Operators.CompareString(array[m].orientacao, "L", TextCompare: true) == 0))
										{
											text2 = "ERRO_L";
											if (Operators.CompareString(array[m].orientacao, "D", TextCompare: true) == 0)
											{
												rotation = Math.PI / 2.0;
											}
										}
									}
									else
									{
										text2 = "ERRO_R";
										if (Operators.CompareString(array[m].orientacao, "U", TextCompare: true) == 0)
										{
											rotation = Math.PI / 2.0;
										}
									}
									break;
								case 1:
									if (!((Operators.CompareString(array[m].orientacao, "R", TextCompare: true) == 0) | (Operators.CompareString(array[m].orientacao, "U", TextCompare: true) == 0)))
									{
										if ((Operators.CompareString(array[m].orientacao, "D", TextCompare: true) == 0) | (Operators.CompareString(array[m].orientacao, "L", TextCompare: true) == 0))
										{
											text2 = "MONO_L";
											if (Operators.CompareString(array[m].orientacao, "D", TextCompare: true) == 0)
											{
												rotation = Math.PI / 2.0;
											}
										}
									}
									else
									{
										text2 = "MONO_R";
										if (Operators.CompareString(array[m].orientacao, "U", TextCompare: true) == 0)
										{
											rotation = Math.PI / 2.0;
										}
									}
									break;
								}
								string text3 = DeclaracoesGeral.Conf.dirSimbologiaTopografico + "AUXILIARES\\" + text2 + ".DWG";
								ObjectId val7 = ObjectId.Null;
								if (!((SymbolTable)val3).Has(text2))
								{
									Database val8 = new Database(false, true);
									val8.ReadDwgFile(text3, FileShare.Read, true, "");
									DeclaracoesGeral.bAnularEventos = true;
									val7 = database.Insert(text2, val8, false);
									((DisposableWrapper)val8).Dispose();
								}
								else
								{
									BlockTableRecord val9 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[text2], (OpenMode)0);
									val7 = ((DBObject)val9).Id;
								}
								Point3d position = val5.Position;
								double num10 = position.X + array[m].X;
								position = val5.Position;
								Point3d val10 = new Point3d(num10, position.Y + array[m].Y, 0.0);
								BlockReference blockRef = new BlockReference(val10, val7);
								((Entity)blockRef).Layer = ((Entity)val5).Layer;
								blockRef.Rotation = rotation;
								val4.AppendEntity((Entity)(object)blockRef);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)blockRef, true);
								((Entity)blockRef).Draw();
								if (num7 > 2)
								{
									continue;
								}
								DeclaracoesTopografico.structureTerminalTopog[] mLigTerm = new DeclaracoesTopografico.structureTerminalTopog[5];
								string valor = "";
								string valor2 = "";
								string valor3 = "";
								string valor4 = "";
								mLigTerm[1].Tag = mLigacoes[num8].Lig[1].Tag;
								mLigTerm[1].Alternativo = mLigacoes[num8].Lig[1].Alternativo;
								mLigTerm[1].Term = mLigacoes[num8].Lig[1].Term;
								mLigTerm[1].Secao = mLigacoes[num8].Lig[1].Secao;
								mLigTerm[1].Cor = mLigacoes[num8].Lig[1].Cor;
								mLigTerm[1].Anilha = valor;
								if (num7 != 2)
								{
									mLigTerm[2].Tag = "";
									mLigTerm[2].Alternativo = "";
									mLigTerm[2].Term = "";
									mLigTerm[2].Secao = "";
									mLigTerm[2].Cor = "";
									mLigTerm[2].Anilha = "";
								}
								else
								{
									mLigTerm[2].Tag = mLigacoes[num8].Lig[2].Tag;
									mLigTerm[2].Alternativo = mLigacoes[num8].Lig[2].Alternativo;
									mLigTerm[2].Term = mLigacoes[num8].Lig[2].Term;
									mLigTerm[2].Secao = mLigacoes[num8].Lig[2].Secao;
									mLigTerm[2].Cor = mLigacoes[num8].Lig[2].Cor;
									mLigTerm[2].Anilha = valor2;
								}
								montarTerminais(dTpg.tag, dTpg.alternativo, ref ctpg, mLigacoes[num8].Terminal, bAlternativo, array[m].orientacao, ref mLigTerm, ref valor, ref valor2, ref valor3, ref valor4);
								BlockTableRecord val11 = (BlockTableRecord)val2.GetObject(val7, (OpenMode)0);
								try
								{
									enumerator3 = val11.GetEnumerator();
									while (enumerator3.MoveNext())
									{
										ObjectId current3 = enumerator3.Current;
										Entity val12 = (Entity)val2.GetObject(current3, (OpenMode)1);
										if (!(val12 is AttributeDefinition))
										{
											continue;
										}
										AttributeReference val13 = new AttributeReference();
										AttributeDefinition val14 = (AttributeDefinition)val12;
										val13.SetAttributeFromBlock(val14, blockRef.BlockTransform);
										string tag = val14.Tag;
										if (Operators.CompareString(tag, "T1", TextCompare: true) != 0)
										{
											if (Operators.CompareString(tag, "T2", TextCompare: true) == 0)
											{
												((DBText)val13).TextString = valor2;
											}
										}
										else
										{
											((DBText)val13).TextString = valor;
										}
										((DBText)val13).AdjustAlignment(database);
										blockRef.AttributeCollection.AppendAttribute(val13);
										DeclaracoesGeral.bAnularEventos = true;
										val2.AddNewlyCreatedDBObject((DBObject)(object)val13, true);
										((Entity)val13).Draw();
									}
								}
								finally
								{
									((IDisposable)enumerator3)?.Dispose();
								}
								XDataTopografico.GravarXDataTermTopografico(ref blockRef, "FD", ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString(), dTpg.tag, dTpg.alternativo, mLigacoes[num8].Terminal, array[m].orientacao, mLigTerm);
							}
						}
						else
						{
							string text4 = "";
							list.Sort();
							foreach (string item3 in list)
							{
								text4 = text4 + item3 + " ,";
							}
							text4 = text4.Substring(0, text4.Length - 2);
							Interaction.MsgBox(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 858], text4), MsgBoxStyle.Critical);
						}
						goto IL_0c79;
						IL_0c79:
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
	}

	public static void InserirTerminaisBorne(DeclaracoesTopografico.structureBorneTopografico bTpg, ref DeclaracoesTopografico.structureConfigTopografico ctpg, ref string sblockRef, ref DeclaracoesTopografico.structureLigTermTopografico mLigacao, bool bAlternativo, bool bSeparaTerminaisDuplos)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected Obj, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected Obj, but got Unknown
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected Obj, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected Obj, but got Unknown
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a66: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6d: Expected Obj, but got Unknown
		//IL_0a6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a74: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Expected Obj, but got Unknown
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Expected Obj, but got Unknown
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0505: Unknown result type (might be due to invalid IL or missing references)
		//IL_050c: Expected Obj, but got Unknown
		//IL_0523: Unknown result type (might be due to invalid IL or missing references)
		//IL_0528: Unknown result type (might be due to invalid IL or missing references)
		//IL_052b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0533: Unknown result type (might be due to invalid IL or missing references)
		//IL_053a: Expected Obj, but got Unknown
		//IL_062c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0631: Unknown result type (might be due to invalid IL or missing references)
		//IL_0546: Unknown result type (might be due to invalid IL or missing references)
		//IL_054d: Expected Obj, but got Unknown
		//IL_054f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0556: Expected Obj, but got Unknown
		//IL_055c: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c8: Unknown result type (might be due to invalid IL or missing references)
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
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
					DeclaracoesTopografico.structureTermBlocoTopografico structureTermBlocoTopografico = default;
					BlockReference val5 = (BlockReference)Geral.HandleToObject(sblockRef);
					AttributeCollection attributeCollection = val5.AttributeCollection;
					foreach (object item in attributeCollection)
					{
						ObjectId val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
						AttributeReference attRef = (AttributeReference)val6.GetObject((OpenMode)0);
						DeclaracoesTopografico.structureTermBlocoTopografico term = default;
						if (XDataTopografico.lerXDataAtributoTopografico(ref attRef, ref term) && Operators.CompareString(bTpg.posEntrada, term.terminal, TextCompare: true) == 0)
						{
							structureTermBlocoTopografico = term;
						}
					}
					int num = Information.UBound(mLigacao.Lig);
					string text = "";
					double rotation = 0.0;
					bool flag = false;
					string text2;
					ObjectId val7;
					Point3d position;
					double num2;
					Point3d val10;
					BlockReference blockRef;
					DeclaracoesTopografico.structureTerminalTopog[] mLigTerm;
					string valor;
					string valor2;
					string valor3;
					string valor4;
					BlockTableRecord val11;
					BlockTableRecordEnumerator enumerator2 = default;
					switch (num)
					{
					case 4:
						if (!((Operators.CompareString(structureTermBlocoTopografico.orientacao, "R", TextCompare: true) == 0) | (Operators.CompareString(structureTermBlocoTopografico.orientacao, "U", TextCompare: true) == 0)))
						{
							if ((Operators.CompareString(structureTermBlocoTopografico.orientacao, "D", TextCompare: true) == 0) | (Operators.CompareString(structureTermBlocoTopografico.orientacao, "L", TextCompare: true) == 0))
							{
								if (bTpg.tipoBorne != 0)
								{
									text = "QUADRUPLO_L";
								}
								else
								{
									text = "ERRO_L";
									flag = true;
								}
								if (Operators.CompareString(structureTermBlocoTopografico.orientacao, "D", TextCompare: true) == 0)
								{
									rotation = Math.PI / 2.0;
								}
							}
						}
						else
						{
							if (bTpg.tipoBorne != 0)
							{
								text = "QUADRUPLO_R";
							}
							else
							{
								text = "ERRO_R";
								flag = true;
							}
							if (Operators.CompareString(structureTermBlocoTopografico.orientacao, "U", TextCompare: true) == 0)
							{
								rotation = Math.PI / 2.0;
							}
						}
						goto IL_01b4;
					default:
						if (!((Operators.CompareString(structureTermBlocoTopografico.orientacao, "R", TextCompare: true) == 0) | (Operators.CompareString(structureTermBlocoTopografico.orientacao, "U", TextCompare: true) == 0)))
						{
							if ((Operators.CompareString(structureTermBlocoTopografico.orientacao, "D", TextCompare: true) == 0) | (Operators.CompareString(structureTermBlocoTopografico.orientacao, "L", TextCompare: true) == 0))
							{
								text = "ERRO_L";
								if (Operators.CompareString(structureTermBlocoTopografico.orientacao, "D", TextCompare: true) == 0)
								{
									rotation = Math.PI / 2.0;
								}
							}
						}
						else
						{
							text = "ERRO_R";
							if (Operators.CompareString(structureTermBlocoTopografico.orientacao, "U", TextCompare: true) == 0)
							{
								rotation = Math.PI / 2.0;
							}
						}
						flag = true;
						goto IL_01b4;
					case 1:
						if (!((Operators.CompareString(structureTermBlocoTopografico.orientacao, "R", TextCompare: true) == 0) | (Operators.CompareString(structureTermBlocoTopografico.orientacao, "U", TextCompare: true) == 0)))
						{
							if ((Operators.CompareString(structureTermBlocoTopografico.orientacao, "D", TextCompare: true) == 0) | (Operators.CompareString(structureTermBlocoTopografico.orientacao, "L", TextCompare: true) == 0))
							{
								text = "MONO_L";
								if (Operators.CompareString(structureTermBlocoTopografico.orientacao, "D", TextCompare: true) == 0)
								{
									rotation = Math.PI / 2.0;
								}
							}
						}
						else
						{
							text = "MONO_R";
							if (Operators.CompareString(structureTermBlocoTopografico.orientacao, "U", TextCompare: true) == 0)
							{
								rotation = Math.PI / 2.0;
							}
						}
						goto IL_01b4;
					case 2:
						if (!((Operators.CompareString(structureTermBlocoTopografico.orientacao, "R", TextCompare: true) == 0) | (Operators.CompareString(structureTermBlocoTopografico.orientacao, "U", TextCompare: true) == 0)))
						{
							if ((Operators.CompareString(structureTermBlocoTopografico.orientacao, "D", TextCompare: true) == 0) | (Operators.CompareString(structureTermBlocoTopografico.orientacao, "L", TextCompare: true) == 0))
							{
								text = (((bTpg.tipoBorne == 1) & bSeparaTerminaisDuplos) ? "DUPLOD_L" : "DUPLO_L");
								if (Operators.CompareString(structureTermBlocoTopografico.orientacao, "D", TextCompare: true) == 0)
								{
									rotation = Math.PI / 2.0;
								}
							}
						}
						else
						{
							text = (((bTpg.tipoBorne == 1) & bSeparaTerminaisDuplos) ? "DUPLOD_R" : "DUPLO_R");
							if (Operators.CompareString(structureTermBlocoTopografico.orientacao, "U", TextCompare: true) == 0)
							{
								rotation = Math.PI / 2.0;
							}
						}
						goto IL_01b4;
					case 3:
						if (!((Operators.CompareString(structureTermBlocoTopografico.orientacao, "R", TextCompare: true) == 0) | (Operators.CompareString(structureTermBlocoTopografico.orientacao, "U", TextCompare: true) == 0)))
						{
							if ((Operators.CompareString(structureTermBlocoTopografico.orientacao, "D", TextCompare: true) == 0) | (Operators.CompareString(structureTermBlocoTopografico.orientacao, "L", TextCompare: true) == 0))
							{
								if (bTpg.tipoBorne != 0)
								{
									text = "TRIPLO_L";
								}
								else
								{
									text = "ERRO_L";
									flag = true;
								}
								if (Operators.CompareString(structureTermBlocoTopografico.orientacao, "D", TextCompare: true) == 0)
								{
									rotation = Math.PI / 2.0;
								}
							}
						}
						else
						{
							if (bTpg.tipoBorne != 0)
							{
								text = "TRIPLO_R";
							}
							else
							{
								text = "ERRO_R";
								flag = true;
							}
							if (Operators.CompareString(structureTermBlocoTopografico.orientacao, "U", TextCompare: true) == 0)
							{
								rotation = Math.PI / 2.0;
							}
						}
						goto IL_01b4;
					case 0:
						break;
						IL_01b4:
						text2 = DeclaracoesGeral.Conf.dirSimbologiaTopografico + "AUXILIARES\\" + text + ".DWG";
						val7 = ObjectId.Null;
						if (!((SymbolTable)val3).Has(text))
						{
							Database val8 = new Database(false, true);
							val8.ReadDwgFile(text2, FileShare.Read, true, "");
							DeclaracoesGeral.bAnularEventos = true;
							val7 = database.Insert(text, val8, false);
							((DisposableWrapper)val8).Dispose();
						}
						else
						{
							BlockTableRecord val9 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[text], (OpenMode)0);
							val7 = ((DBObject)val9).Id;
						}
						position = val5.Position;
						num2 = position.X + structureTermBlocoTopografico.X;
						position = val5.Position;
						val10 = new Point3d(num2, position.Y + structureTermBlocoTopografico.Y, 0.0);
						blockRef = new BlockReference(val10, val7);
						((Entity)blockRef).Layer = ((Entity)val5).Layer;
						blockRef.Rotation = rotation;
						val4.AppendEntity((Entity)(object)blockRef);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)blockRef, true);
						((Entity)blockRef).Draw();
						if (flag)
						{
							break;
						}
						mLigTerm = new DeclaracoesTopografico.structureTerminalTopog[5];
						valor = "";
						valor2 = "";
						valor3 = "";
						valor4 = "";
						mLigTerm[1].Tag = mLigacao.Lig[1].Tag;
						mLigTerm[1].Alternativo = mLigacao.Lig[1].Alternativo;
						mLigTerm[1].Term = mLigacao.Lig[1].Term;
						mLigTerm[1].Secao = mLigacao.Lig[1].Secao;
						mLigTerm[1].Cor = mLigacao.Lig[1].Cor;
						mLigTerm[1].Anilha = valor;
						mLigTerm[2].Tag = "";
						mLigTerm[3].Tag = "";
						mLigTerm[4].Tag = "";
						mLigTerm[2].Alternativo = "";
						mLigTerm[3].Alternativo = "";
						mLigTerm[4].Alternativo = "";
						mLigTerm[2].Term = "";
						mLigTerm[3].Term = "";
						mLigTerm[4].Term = "";
						mLigTerm[2].Secao = "";
						mLigTerm[3].Secao = "";
						mLigTerm[4].Secao = "";
						mLigTerm[2].Cor = "";
						mLigTerm[3].Cor = "";
						mLigTerm[4].Cor = "";
						mLigTerm[2].Anilha = "";
						mLigTerm[3].Anilha = "";
						mLigTerm[4].Anilha = "";
						if (num >= 2)
						{
							mLigTerm[2].Tag = mLigacao.Lig[2].Tag;
							mLigTerm[2].Alternativo = mLigacao.Lig[2].Alternativo;
							mLigTerm[2].Term = mLigacao.Lig[2].Term;
							mLigTerm[2].Secao = mLigacao.Lig[2].Secao;
							mLigTerm[2].Cor = mLigacao.Lig[2].Cor;
							mLigTerm[2].Anilha = valor2;
						}
						if (num >= 3)
						{
							mLigTerm[3].Tag = mLigacao.Lig[3].Tag;
							mLigTerm[3].Alternativo = mLigacao.Lig[3].Alternativo;
							mLigTerm[3].Term = mLigacao.Lig[3].Term;
							mLigTerm[3].Secao = mLigacao.Lig[3].Secao;
							mLigTerm[3].Cor = mLigacao.Lig[3].Cor;
							mLigTerm[3].Anilha = valor3;
						}
						if (num == 4)
						{
							mLigTerm[4].Tag = mLigacao.Lig[4].Tag;
							mLigTerm[4].Alternativo = mLigacao.Lig[4].Alternativo;
							mLigTerm[4].Term = mLigacao.Lig[4].Term;
							mLigTerm[4].Secao = mLigacao.Lig[4].Secao;
							mLigTerm[4].Cor = mLigacao.Lig[4].Cor;
							mLigTerm[4].Anilha = valor4;
						}
						montarTerminais(bTpg.regua, "", ref ctpg, mLigacao.Terminal, bAlternativo, structureTermBlocoTopografico.orientacao, ref mLigTerm, ref valor, ref valor2, ref valor3, ref valor4);
						val11 = (BlockTableRecord)val2.GetObject(val7, (OpenMode)0);
						try
						{
							enumerator2 = val11.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								ObjectId current2 = enumerator2.Current;
								Entity val12 = (Entity)val2.GetObject(current2, (OpenMode)1);
								if (!(val12 is AttributeDefinition))
								{
									continue;
								}
								AttributeReference val13 = new AttributeReference();
								AttributeDefinition val14 = (AttributeDefinition)val12;
								val13.SetAttributeFromBlock(val14, blockRef.BlockTransform);
								string tag = val14.Tag;
								if (Operators.CompareString(tag, "T1", TextCompare: true) != 0)
								{
									if (Operators.CompareString(tag, "T2", TextCompare: true) != 0)
									{
										if (Operators.CompareString(tag, "T3", TextCompare: true) != 0)
										{
											if (Operators.CompareString(tag, "T4", TextCompare: true) == 0)
											{
												((DBText)val13).TextString = valor4;
											}
										}
										else
										{
											((DBText)val13).TextString = valor3;
										}
									}
									else
									{
										((DBText)val13).TextString = valor2;
									}
								}
								else
								{
									((DBText)val13).TextString = valor;
								}
								((DBText)val13).AdjustAlignment(database);
								blockRef.AttributeCollection.AppendAttribute(val13);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val13, true);
								((Entity)val13).Draw();
							}
						}
						finally
						{
							((IDisposable)enumerator2)?.Dispose();
						}
						XDataTopografico.GravarXDataTermTopografico(ref blockRef, "FB", ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString(), bTpg.regua, "", mLigacao.Terminal, structureTermBlocoTopografico.orientacao, mLigTerm);
						break;
					}
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

	public static void InserirErroBorne(string posEntrada, ref BlockReference blockRef)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected Obj, but got Unknown
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected Obj, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Expected Obj, but got Unknown
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Expected Obj, but got Unknown
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Expected Obj, but got Unknown
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		_ = Application.DocumentManager.MdiActiveDocument.Editor;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			BlockTable val = (BlockTable)topTransaction.GetObject(database.BlockTableId, (OpenMode)0);
			BlockTableRecord val2 = (BlockTableRecord)topTransaction.GetObject(((SymbolTable)val)[BlockTableRecord.ModelSpace], (OpenMode)1);
			DeclaracoesTopografico.structureTermBlocoTopografico structureTermBlocoTopografico = default;
			AttributeCollection attributeCollection = blockRef.AttributeCollection;
			foreach (object item in attributeCollection)
			{
				ObjectId val3 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
				AttributeReference attRef = (AttributeReference)val3.GetObject((OpenMode)0);
				DeclaracoesTopografico.structureTermBlocoTopografico term = default;
				if (XDataTopografico.lerXDataAtributoTopografico(ref attRef, ref term) && Operators.CompareString(posEntrada, term.terminal, TextCompare: true) == 0)
				{
					structureTermBlocoTopografico = term;
				}
			}
			string text = "";
			double rotation = 0.0;
			if (!((Operators.CompareString(structureTermBlocoTopografico.orientacao, "R", TextCompare: true) == 0) | (Operators.CompareString(structureTermBlocoTopografico.orientacao, "U", TextCompare: true) == 0)))
			{
				if ((Operators.CompareString(structureTermBlocoTopografico.orientacao, "D", TextCompare: true) == 0) | (Operators.CompareString(structureTermBlocoTopografico.orientacao, "L", TextCompare: true) == 0))
				{
					text = "ERRO_L";
					if (Operators.CompareString(structureTermBlocoTopografico.orientacao, "D", TextCompare: true) == 0)
					{
						rotation = Math.PI / 2.0;
					}
				}
			}
			else
			{
				text = "ERRO_R";
				if (Operators.CompareString(structureTermBlocoTopografico.orientacao, "U", TextCompare: true) == 0)
				{
					rotation = Math.PI / 2.0;
				}
			}
			string text2 = DeclaracoesGeral.Conf.dirSimbologiaTopografico + "AUXILIARES\\" + text + ".DWG";
			ObjectId val4 = ObjectId.Null;
			if (!((SymbolTable)val).Has(text))
			{
				Database val5 = new Database(false, true);
				val5.ReadDwgFile(text2, FileShare.Read, true, "");
				DeclaracoesGeral.bAnularEventos = true;
				val4 = database.Insert(text, val5, false);
				((DisposableWrapper)val5).Dispose();
			}
			else
			{
				BlockTableRecord val6 = (BlockTableRecord)topTransaction.GetObject(((SymbolTable)val)[text], (OpenMode)0);
				val4 = ((DBObject)val6).Id;
			}
			Point3d position = blockRef.Position;
			double num = position.X + structureTermBlocoTopografico.X;
			position = blockRef.Position;
			Point3d val7 = new Point3d(num, position.Y + structureTermBlocoTopografico.Y, 0.0);
			BlockReference val8 = new BlockReference(val7, val4);
			((Entity)val8).Layer = ((Entity)blockRef).Layer;
			val8.Rotation = rotation;
			val2.AppendEntity((Entity)(object)val8);
			DeclaracoesGeral.bAnularEventos = true;
			topTransaction.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
			((Entity)val8).Draw();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			topTransaction.Abort();
			ProjectData.ClearProjectError();
		}
		finally
		{
			((IDisposable)topTransaction)?.Dispose();
		}
	}

	public static string InserirLinkTopografico(DeclaracoesTopografico.structureBorneTopografico bTpg, string nomebloco, string sHandle)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected Obj, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected Obj, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected Obj, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Expected Obj, but got Unknown
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected Obj, but got Unknown
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Expected Obj, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			_ = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockReference val3 = (BlockReference)Geral.HandleToObject(sHandle);
				try
				{
					ObjectId val4 = ObjectId.Null;
					BlockTable val5 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val6 = (BlockTableRecord)val2.GetObject(((SymbolTable)val5)[BlockTableRecord.ModelSpace], (OpenMode)1);
					string text = nomebloco.Substring(0, checked(nomebloco.Length - 4));
					string text2 = DeclaracoesGeral.Conf.dirSimbologiaTopografico + "Auxiliares\\" + nomebloco;
					if (!((SymbolTable)val5).Has(text))
					{
						Database val7 = new Database(false, true);
						val7.ReadDwgFile(text2, FileShare.Read, true, "");
						DeclaracoesGeral.bAnularEventos = true;
						val4 = database.Insert(text, val7, false);
						((DisposableWrapper)val7).Dispose();
					}
					else
					{
						BlockTableRecord val8 = (BlockTableRecord)val2.GetObject(((SymbolTable)val5)[text], (OpenMode)0);
						val4 = ((DBObject)val8).Id;
					}
					BlockReference blockRef = new BlockReference(val3.Position, val4);
					((Entity)blockRef).Layer = ((Entity)val3).Layer;
					val6.AppendEntity((Entity)(object)blockRef);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)blockRef, true);
					_ = (BlockTableRecord)val2.GetObject(val4, (OpenMode)0);
					((Entity)blockRef).Draw();
					XDataTopografico.GravarXDataLinkTopografico(ref blockRef, ((object)((DBObject)val3).Handle/*cast due to constrained. prefix*/).ToString());
					result = ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString();
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
		return result;
	}

	public static void AtualizarTerminais(ref DeclaracoesTopografico.structureConfigTopografico ctpg, bool bAlternativo)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected Obj, but got Unknown
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Expected Obj, but got Unknown
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
						Entity val5 = (Entity)current.GetObject((OpenMode)0);
						BlockReference attRef = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
						if (attRef == null)
						{
							continue;
						}
						DeclaracoesTopografico.structureTerminalTopog[] mLigTerm = new DeclaracoesTopografico.structureTerminalTopog[5];
						string tipo = "";
						string handle = "";
						string tag = "";
						string alternativo = "";
						string terminal = "";
						string rotacao = "";
						if (!XDataTopografico.LerXDataTermTopografico(ref attRef, ref tipo, ref handle, ref tag, ref alternativo, ref terminal, ref rotacao, ref mLigTerm))
						{
							continue;
						}
						DeclaracoesTopografico.structureDispTopografico structureDispTopografico = new DeclaracoesTopografico.structureDispTopografico
						{
							tag = tag,
							alternativo = alternativo
						};
						string valor = "";
						string valor2 = "";
						string valor3 = "";
						string valor4 = "";
						montarTerminais(structureDispTopografico.tag, structureDispTopografico.alternativo, ref ctpg, terminal, bAlternativo, rotacao, ref mLigTerm, ref valor, ref valor2, ref valor3, ref valor4);
						foreach (object item in attRef.AttributeCollection)
						{
							ObjectId val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							AttributeReference val7 = (AttributeReference)val6.GetObject((OpenMode)1);
							string left = val7.Tag.ToUpper();
							if (Operators.CompareString(left, "T1", TextCompare: true) != 0)
							{
								if (Operators.CompareString(left, "T2", TextCompare: true) != 0)
								{
									if (Operators.CompareString(left, "T3", TextCompare: true) != 0)
									{
										if (Operators.CompareString(left, "T4", TextCompare: true) == 0)
										{
											((DBText)val7).TextString = valor4;
										}
									}
									else
									{
										((DBText)val7).TextString = valor3;
									}
								}
								else
								{
									((DBText)val7).TextString = valor2;
								}
							}
							else
							{
								((DBText)val7).TextString = valor;
							}
						}
						((DBObject)attRef).UpgradeOpen();
						XDataTopografico.GravarXDataTermTopografico(ref attRef, tipo, handle, tag, alternativo, terminal, rotacao, mLigTerm);
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
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
	}

	public static void mostraSecao(string secao)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected Obj, but got Unknown
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_0296: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Expected Obj, but got Unknown
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
						Entity val5 = (Entity)current.GetObject((OpenMode)0);
						BlockReference attRef = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
						if (attRef == null)
						{
							continue;
						}
						DeclaracoesTopografico.structureTerminalTopog[] mLigTerm = new DeclaracoesTopografico.structureTerminalTopog[5];
						string tipo = "";
						string handle = "";
						string tag = "";
						string alternativo = "";
						string terminal = "";
						string rotacao = "";
						if (!XDataTopografico.LerXDataTermTopografico(ref attRef, ref tipo, ref handle, ref tag, ref alternativo, ref terminal, ref rotacao, ref mLigTerm))
						{
							continue;
						}
						bool flag = false;
						string text = mLigTerm[1].Anilha;
						string text2 = "";
						if (Operators.CompareString(mLigTerm[1].Secao, secao, TextCompare: true) == 0)
						{
							text2 = " (" + secao;
							if (Operators.CompareString(mLigTerm[1].Cor.Trim(), "", TextCompare: true) != 0)
							{
								text2 = text2 + " " + mLigTerm[1].Cor;
							}
							text2 += ") ";
							flag = true;
						}
						bool flag2 = false;
						string text3 = mLigTerm[2].Anilha;
						string text4 = "";
						if (Operators.CompareString(mLigTerm[2].Secao, secao, TextCompare: true) == 0)
						{
							text4 = " (" + secao;
							if (Operators.CompareString(mLigTerm[2].Cor.Trim(), "", TextCompare: true) != 0)
							{
								text4 = text4 + " " + mLigTerm[2].Cor;
							}
							text4 += ") ";
							flag2 = true;
						}
						bool flag3 = false;
						string text5 = mLigTerm[3].Anilha;
						string text6 = "";
						if (Operators.CompareString(mLigTerm[3].Secao, secao, TextCompare: true) == 0)
						{
							text6 = " (" + secao;
							if (Operators.CompareString(mLigTerm[3].Cor.Trim(), "", TextCompare: true) != 0)
							{
								text6 = text6 + " " + mLigTerm[3].Cor;
							}
							text6 += ") ";
							flag3 = true;
						}
						bool flag4 = false;
						string text7 = mLigTerm[4].Anilha;
						string text8 = "";
						if (Operators.CompareString(mLigTerm[4].Secao, secao, TextCompare: true) == 0)
						{
							text8 = " (" + secao;
							if (Operators.CompareString(mLigTerm[4].Cor.Trim(), "", TextCompare: true) != 0)
							{
								text8 = text8 + " " + mLigTerm[4].Cor;
							}
							text8 += ") ";
							flag4 = true;
						}
						string left = rotacao;
						if (Operators.CompareString(left, "R", TextCompare: true) != 0 && Operators.CompareString(left, "U", TextCompare: true) != 0)
						{
							if (Operators.CompareString(left, "L", TextCompare: true) == 0 || Operators.CompareString(left, "D", TextCompare: true) == 0)
							{
								text = text2 + text;
								text3 = text4 + text3;
								text5 = text6 + text5;
								text7 = text8 + text7;
							}
						}
						else
						{
							text += text2;
							text3 += text4;
							text5 += text6;
							text7 += text8;
						}
						foreach (object item in attRef.AttributeCollection)
						{
							ObjectId val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							AttributeReference val7 = (AttributeReference)val6.GetObject((OpenMode)1);
							string left2 = val7.Tag.ToUpper();
							if (Operators.CompareString(left2, "T1", TextCompare: true) != 0)
							{
								if (Operators.CompareString(left2, "T2", TextCompare: true) != 0)
								{
									if (Operators.CompareString(left2, "T3", TextCompare: true) != 0)
									{
										if (Operators.CompareString(left2, "T4", TextCompare: true) == 0 && flag4)
										{
											((DBText)val7).TextString = text7;
										}
									}
									else if (flag3)
									{
										((DBText)val7).TextString = text5;
									}
								}
								else if (flag2)
								{
									((DBText)val7).TextString = text3;
								}
							}
							else if (flag)
							{
								((DBText)val7).TextString = text;
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
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
	}

	public static void ocultaSecao()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected Obj, but got Unknown
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Expected Obj, but got Unknown
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
						Entity val5 = (Entity)current.GetObject((OpenMode)0);
						BlockReference attRef = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
						if (attRef == null)
						{
							continue;
						}
						DeclaracoesTopografico.structureTerminalTopog[] mLigTerm = new DeclaracoesTopografico.structureTerminalTopog[5];
						string tipo = "";
						string handle = "";
						string tag = "";
						string alternativo = "";
						string terminal = "";
						string rotacao = "";
						if (!XDataTopografico.LerXDataTermTopografico(ref attRef, ref tipo, ref handle, ref tag, ref alternativo, ref terminal, ref rotacao, ref mLigTerm))
						{
							continue;
						}
						string anilha = mLigTerm[1].Anilha;
						string anilha2 = mLigTerm[2].Anilha;
						string anilha3 = mLigTerm[3].Anilha;
						string anilha4 = mLigTerm[4].Anilha;
						foreach (object item in attRef.AttributeCollection)
						{
							ObjectId val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							AttributeReference val7 = (AttributeReference)val6.GetObject((OpenMode)1);
							string left = val7.Tag.ToUpper();
							if (Operators.CompareString(left, "T1", TextCompare: true) != 0)
							{
								if (Operators.CompareString(left, "T2", TextCompare: true) != 0)
								{
									if (Operators.CompareString(left, "T3", TextCompare: true) != 0)
									{
										if (Operators.CompareString(left, "T4", TextCompare: true) == 0)
										{
											((DBText)val7).TextString = anilha4;
										}
									}
									else
									{
										((DBText)val7).TextString = anilha3;
									}
								}
								else
								{
									((DBText)val7).TextString = anilha2;
								}
							}
							else
							{
								((DBText)val7).TextString = anilha;
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
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
	}

	public static void ReinserirTodasLigacoesDispositivos(ref DeclaracoesTopografico.structureConfigTopografico ctpg, int dwg, string revisao, int painel, bool bIgnorarExcedentes, bool bAlternativo, DeclaracoesTopografico.structureDispsTpg[] mTags, bool bIgnorarFaltantes)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected Obj, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected Obj, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		new List<string>();
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
					int indexModelo = default;
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val5 = (Entity)current.GetObject((OpenMode)0);
						BlockReference blockRef = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
						if (blockRef == null)
						{
							continue;
						}
						DeclaracoesTopografico.structureDispTopografico dTpg = default;
						if (!XDataTopografico.lerXDataDispTopografico(ref blockRef, ref dTpg))
						{
							continue;
						}
						string sblockRef = ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString();
						if (dTpg.painel != painel)
						{
							continue;
						}
						bool flag = false;
						string tipo = "";
						int num = Information.UBound(mTags);
						for (int i = 0; i <= num; i = checked(i + 1))
						{
							if (Operators.CompareString(mTags[i].Tag, dTpg.tag, TextCompare: true) == 0)
							{
								tipo = mTags[i].tipo;
								indexModelo = mTags[i].indexModelo;
								flag = true;
								break;
							}
						}
						if (flag)
						{
							DeclaracoesTopografico.structureLigTermTopografico[] mLigacoes = new DeclaracoesTopografico.structureLigTermTopografico[1];
							mLigacoes[0].Lig = new DeclaracoesFiacao.structureLigacao[1];
							DeclaracoesFiacao.structureLink[] mLink = new DeclaracoesFiacao.structureLink[1];
							carregarLigacoes(dTpg.tag, ref mLigacoes, dwg, revisao, painel, tipo, indexModelo, ref mLink);
							InserirTerminaisDispositivo(dTpg, ref ctpg, ref sblockRef, ref mLigacoes, bIgnorarExcedentes, bAlternativo, bIgnorarFaltantes);
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
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
	}

	public static void ReinserirTodasLigacoesRegua(ref DeclaracoesTopografico.structureConfigTopografico ctpg, int dwg, string revisao, int painel, string regua, int indexModelo, bool bAlternativo, bool bSeparaTerminaisDuplos)
	{
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected Obj, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected Obj, but got Unknown
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected Obj, but got Unknown
		//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_0306: Unknown result type (might be due to invalid IL or missing references)
		//IL_031f: Unknown result type (might be due to invalid IL or missing references)
		new List<string>();
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					DeclaracoesTopografico.structureLigTermTopografico[] mLigacoes = new DeclaracoesTopografico.structureLigTermTopografico[1];
					mLigacoes[0].Lig = new DeclaracoesFiacao.structureLigacao[1];
					DeclaracoesFiacao.structureLink[] mLink = new DeclaracoesFiacao.structureLink[1];
					carregarLigacoes(regua, ref mLigacoes, dwg, revisao, painel, "B", indexModelo, ref mLink);
					List<string> list = new List<string>();
					int num = Information.UBound(mLigacoes);
					for (int i = 1; i <= num; i++)
					{
						if (!list.Contains(mLigacoes[i].Terminal))
						{
							list.Add(mLigacoes[i].Terminal);
						}
					}
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val5 = (Entity)current.GetObject((OpenMode)0);
							BlockReference blockRef = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
							if (blockRef == null)
							{
								continue;
							}
							DeclaracoesTopografico.structureBorneTopografico bTpg = default;
							if (!XDataTopografico.lerXDataBorneTopografico(ref blockRef, ref bTpg) || !((bTpg.painel == painel) & (Operators.CompareString(bTpg.regua, regua, TextCompare: true) == 0)))
							{
								continue;
							}
							bool flag = false;
							bool flag2 = false;
							DeclaracoesTopografico.structureLigTermTopografico mLigacao = default;
							int num2 = Information.UBound(mLigacoes);
							for (int j = 1; j <= num2; j++)
							{
								if (Operators.CompareString(mLigacoes[j].Terminal, bTpg.borne, TextCompare: true) == 0)
								{
									mLigacao = mLigacoes[j];
									flag = true;
									if (list.Contains(bTpg.borne))
									{
										list.Remove(bTpg.borne);
									}
									break;
								}
							}
							DeclaracoesFiacao.structureLink structureLink = default;
							int num3 = Information.UBound(mLink);
							for (int k = 1; k <= num3; k++)
							{
								if (Operators.CompareString(mLink[k].borne, bTpg.borne, TextCompare: true) == 0)
								{
									structureLink = mLink[k];
									flag2 = true;
									break;
								}
							}
							if (flag2 & (structureLink.bUp | structureLink.bDown))
							{
								string text = "BORNE";
								text = ((bTpg.tipoBorne == 0) ? (text + "S") : (text + "D"));
								text = (blockRef.Name.Contains("90") ? (text + "90") : (text + "0"));
								if (structureLink.bUp)
								{
									text += "U";
								}
								if (structureLink.bDown)
								{
									text += "D";
								}
								text += bTpg.posEntrada;
								text += ".dwg";
								_ = (BlockReference)Geral.HandleToObject(InserirLinkTopografico(bTpg, text, ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString()));
							}
							if (!flag)
							{
								Interaction.MsgBox(Operators.AddObject(bTpg.regua + ":" + bTpg.borne + " ", DeclaracoesGeral.mMensagem[1, 1527]), MsgBoxStyle.Critical);
							}
							else if (!(((bTpg.tipoBorne == 0) & (Information.UBound(mLigacao.Lig) > 2)) | ((bTpg.tipoBorne == 1) & (Information.UBound(mLigacao.Lig) > 4))))
							{
								string sblockRef = ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString();
								InserirTerminaisBorne(bTpg, ref ctpg, ref sblockRef, ref mLigacao, bAlternativo, bSeparaTerminaisDuplos);
							}
							else
							{
								InserirErroBorne(bTpg.posEntrada, ref blockRef);
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
					if (list.Count > 0)
					{
						string text2 = "";
						foreach (string item in list)
						{
							text2 = text2 + item + ", ";
						}
						text2 = Strings.Mid(text2, 1, text2.Length - 2);
						Interaction.MsgBox(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1528], " "), regua), " => "), text2), MsgBoxStyle.Critical);
					}
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
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		}
	}

	public static void ApagarTodasLigacoes(int painel, string tipo)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected Obj, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected Obj, but got Unknown
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Expected Obj, but got Unknown
		List<string> list = new List<string>();
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
						Entity val5 = (Entity)current.GetObject((OpenMode)0);
						BlockReference blockRef = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
						if (blockRef == null)
						{
							continue;
						}
						DeclaracoesTopografico.structureDispTopografico dTpg = default;
						if (!(XDataTopografico.lerXDataDispTopografico(ref blockRef, ref dTpg) & (Operators.CompareString(tipo, "D", TextCompare: true) == 0)))
						{
							DeclaracoesTopografico.structureBorneTopografico bTpg = default;
							if ((XDataTopografico.lerXDataBorneTopografico(ref blockRef, ref bTpg) & (Operators.CompareString(tipo, "B", TextCompare: true) == 0)) && bTpg.painel == painel)
							{
								list.Add(((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString());
							}
						}
						else if (dTpg.painel == painel)
						{
							list.Add(((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString());
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				BlockTableRecordEnumerator enumerator2 = default;
				try
				{
					enumerator2 = val4.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						ObjectId current2 = enumerator2.Current;
						Entity val6 = (Entity)current2.GetObject((OpenMode)0);
						BlockReference attRef = (BlockReference)(object)((val6 is BlockReference) ? val6 : null);
						if (attRef == null)
						{
							continue;
						}
						string handle = "";
						if (!XDataTopografico.LerXDataHandleTermTopografico(ref attRef, ref handle))
						{
							if (XDataTopografico.lerXDataLinkTopografico(ref attRef, ref handle) && list.Contains(handle))
							{
								((DBObject)attRef).UpgradeOpen();
								((DBObject)attRef).Erase();
							}
						}
						else if (list.Contains(handle))
						{
							((DBObject)attRef).UpgradeOpen();
							((DBObject)attRef).Erase();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator2)?.Dispose();
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
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
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
	}

	public static void carregarPaineisBlocos(ref List<int> lPn)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected Obj, but got Unknown
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
					Entity val4 = (Entity)current.GetObject((OpenMode)0);
					BlockReference blockRef = (BlockReference)(object)((val4 is BlockReference) ? val4 : null);
					if (blockRef == null)
					{
						continue;
					}
					DeclaracoesTopografico.structureDispTopografico dTpg = default;
					if (!XDataTopografico.lerXDataDispTopografico(ref blockRef, ref dTpg))
					{
						DeclaracoesTopografico.structureBorneTopografico bTpg = default;
						if (XDataTopografico.lerXDataBorneTopografico(ref blockRef, ref bTpg) && !lPn.Contains(bTpg.painel))
						{
							lPn.Add(bTpg.painel);
						}
					}
					else if (!lPn.Contains(dTpg.painel))
					{
						lPn.Add(dTpg.painel);
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
			ProjectData.ClearProjectError();
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void carregarHandlesBlocos(ref List<string> lhandles, int pn)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected Obj, but got Unknown
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			BlockTable val = (BlockTable)topTransaction.GetObject(database.BlockTableId, (OpenMode)0);
			BlockTableRecord val2 = (BlockTableRecord)topTransaction.GetObject(((SymbolTable)val)[BlockTableRecord.ModelSpace], (OpenMode)0);
			BlockTableRecordEnumerator enumerator = default;
			try
			{
				enumerator = val2.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ObjectId current = enumerator.Current;
					Entity val3 = (Entity)current.GetObject((OpenMode)0);
					BlockReference blockRef = (BlockReference)(object)((val3 is BlockReference) ? val3 : null);
					if (blockRef == null)
					{
						continue;
					}
					DeclaracoesTopografico.structureDispTopografico dTpg = default;
					if (!XDataTopografico.lerXDataDispTopografico(ref blockRef, ref dTpg))
					{
						DeclaracoesTopografico.structureBorneTopografico bTpg = default;
						if (XDataTopografico.lerXDataBorneTopografico(ref blockRef, ref bTpg) && bTpg.painel == pn && !lhandles.Contains(((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString()))
						{
							lhandles.Add(((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString());
						}
					}
					else if (dTpg.painel == pn && !lhandles.Contains(((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString()))
					{
						lhandles.Add(((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString());
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
			topTransaction.Abort();
			ProjectData.ClearProjectError();
		}
		finally
		{
			((IDisposable)topTransaction)?.Dispose();
		}
	}

	public static void carregaAnilhas(ref DeclaracoesTopografico.structureAnilhaTopografico[] mAnilhas, int pn)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected Obj, but got Unknown
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
				List<string> lhandles = new List<string>();
				carregarHandlesBlocos(ref lhandles, pn);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val3.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val4 = (Entity)current.GetObject((OpenMode)0);
						BlockReference attRef = (BlockReference)(object)((val4 is BlockReference) ? val4 : null);
						if (attRef == null)
						{
							continue;
						}
						DeclaracoesTopografico.structureTerminalTopog[] mLigTerm = new DeclaracoesTopografico.structureTerminalTopog[5];
						string tipo = "";
						string handle = "";
						string tag = "";
						string alternativo = "";
						string terminal = "";
						string rotacao = "";
						if (XDataTopografico.LerXDataTermTopografico(ref attRef, ref tipo, ref handle, ref tag, ref alternativo, ref terminal, ref rotacao, ref mLigTerm) && lhandles.Contains(handle))
						{
							int num = mAnilhas.Length;
							mAnilhas = (DeclaracoesTopografico.structureAnilhaTopografico[])Utils.CopyArray(mAnilhas, new DeclaracoesTopografico.structureAnilhaTopografico[num + 1]);
							mAnilhas[num].Tag1 = tag;
							mAnilhas[num].Term1 = terminal;
							mAnilhas[num].Tag2 = mLigTerm[1].Tag;
							mAnilhas[num].Term2 = mLigTerm[1].Term;
							mAnilhas[num].Secao = mLigTerm[1].Secao;
							mAnilhas[num].Cor = mLigTerm[1].Cor;
							mAnilhas[num].Anilha1 = mLigTerm[1].Anilha;
							mAnilhas[num].Anilha2 = "";
							mAnilhas[num].bUsou = false;
							if (Operators.CompareString(mLigTerm[2].Tag, "", TextCompare: true) != 0)
							{
								num = mAnilhas.Length;
								mAnilhas = (DeclaracoesTopografico.structureAnilhaTopografico[])Utils.CopyArray(mAnilhas, new DeclaracoesTopografico.structureAnilhaTopografico[num + 1]);
								mAnilhas[num].Tag1 = tag;
								mAnilhas[num].Term1 = terminal;
								mAnilhas[num].Tag2 = mLigTerm[2].Tag;
								mAnilhas[num].Term2 = mLigTerm[2].Term;
								mAnilhas[num].Secao = mLigTerm[2].Secao;
								mAnilhas[num].Cor = mLigTerm[2].Cor;
								mAnilhas[num].Anilha1 = mLigTerm[2].Anilha;
								mAnilhas[num].Anilha2 = "";
								mAnilhas[num].bUsou = false;
							}
							if (Operators.CompareString(mLigTerm[3].Tag, "", TextCompare: true) != 0)
							{
								num = mAnilhas.Length;
								mAnilhas = (DeclaracoesTopografico.structureAnilhaTopografico[])Utils.CopyArray(mAnilhas, new DeclaracoesTopografico.structureAnilhaTopografico[num + 1]);
								mAnilhas[num].Tag1 = tag;
								mAnilhas[num].Term1 = terminal;
								mAnilhas[num].Tag2 = mLigTerm[3].Tag;
								mAnilhas[num].Term2 = mLigTerm[3].Term;
								mAnilhas[num].Secao = mLigTerm[3].Secao;
								mAnilhas[num].Cor = mLigTerm[3].Cor;
								mAnilhas[num].Anilha1 = mLigTerm[3].Anilha;
								mAnilhas[num].Anilha2 = "";
								mAnilhas[num].bUsou = false;
							}
							if (Operators.CompareString(mLigTerm[4].Tag, "", TextCompare: true) != 0)
							{
								num = mAnilhas.Length;
								mAnilhas = (DeclaracoesTopografico.structureAnilhaTopografico[])Utils.CopyArray(mAnilhas, new DeclaracoesTopografico.structureAnilhaTopografico[num + 1]);
								mAnilhas[num].Tag1 = tag;
								mAnilhas[num].Term1 = terminal;
								mAnilhas[num].Tag2 = mLigTerm[4].Tag;
								mAnilhas[num].Term2 = mLigTerm[4].Term;
								mAnilhas[num].Secao = mLigTerm[4].Secao;
								mAnilhas[num].Cor = mLigTerm[4].Cor;
								mAnilhas[num].Anilha1 = mLigTerm[4].Anilha;
								mAnilhas[num].Anilha2 = "";
								mAnilhas[num].bUsou = false;
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
				ProjectData.ClearProjectError();
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}

	public static void processaAnilhas(ref DeclaracoesTopografico.structureAnilhaTopografico[] mAnilhasTemp, ref DeclaracoesTopografico.structureAnilhaTopografico[] mAnilhas)
	{
		checked
		{
			int num = Information.UBound(mAnilhasTemp) - 1;
			for (int i = 1; i <= num; i++)
			{
				if (mAnilhasTemp[i].bUsou)
				{
					continue;
				}
				bool flag = false;
				int num2 = i + 1;
				int num3 = Information.UBound(mAnilhasTemp);
				for (int j = num2; j <= num3; j++)
				{
					if ((Operators.CompareString(mAnilhasTemp[i].Tag1, mAnilhasTemp[j].Tag2, TextCompare: true) == 0) & (Operators.CompareString(mAnilhasTemp[i].Tag2, mAnilhasTemp[j].Tag1, TextCompare: true) == 0) & (Operators.CompareString(mAnilhasTemp[i].Term1, mAnilhasTemp[j].Term2, TextCompare: true) == 0) & (Operators.CompareString(mAnilhasTemp[i].Term2, mAnilhasTemp[j].Term1, TextCompare: true) == 0) & (Operators.CompareString(mAnilhasTemp[i].Secao, mAnilhasTemp[j].Secao, TextCompare: true) == 0) & (Operators.CompareString(mAnilhasTemp[i].Cor, mAnilhasTemp[j].Cor, TextCompare: true) == 0) & !mAnilhasTemp[j].bUsou)
					{
						int num4 = mAnilhas.Length;
						mAnilhas = (DeclaracoesTopografico.structureAnilhaTopografico[])Utils.CopyArray(mAnilhas, new DeclaracoesTopografico.structureAnilhaTopografico[num4 + 1]);
						mAnilhas[num4] = mAnilhasTemp[i];
						mAnilhas[num4].Anilha2 = mAnilhasTemp[j].Anilha1;
						mAnilhasTemp[j].bUsou = true;
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					int num5 = mAnilhas.Length;
					mAnilhas = (DeclaracoesTopografico.structureAnilhaTopografico[])Utils.CopyArray(mAnilhas, new DeclaracoesTopografico.structureAnilhaTopografico[num5 + 1]);
					mAnilhas[num5] = mAnilhasTemp[i];
					mAnilhas[num5].Anilha2 = "";
				}
			}
		}
	}

	public static void inserirItemLMDisp(int painel, cDadosLM.structureDispLM[] mItens)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected Obj, but got Unknown
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected Obj, but got Unknown
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
						Entity val5 = (Entity)current.GetObject((OpenMode)0);
						BlockReference blockRef = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
						if (blockRef == null)
						{
							continue;
						}
						DeclaracoesTopografico.structureDispTopografico dTpg = default;
						if (!XDataTopografico.lerXDataDispTopografico(ref blockRef, ref dTpg) || dTpg.painel != painel)
						{
							continue;
						}
						((DBObject)blockRef).UpgradeOpen();
						int num = Information.UBound(mItens);
						for (int i = 1; i <= num; i = checked(i + 1))
						{
							if (!((Operators.CompareString(mItens[i].sTag, dTpg.tag, TextCompare: true) == 0) & (mItens[i].IndiceLM > 0)))
							{
								continue;
							}
							foreach (object item in blockRef.AttributeCollection)
							{
								ObjectId val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
								AttributeReference val7 = (AttributeReference)val6.GetObject((OpenMode)1);
								if (Operators.CompareString(val7.Tag.ToUpper(), "@LM", TextCompare: true) == 0)
								{
									((DBText)val7).TextString = mItens[i].IndiceLM.ToString();
									break;
								}
							}
							break;
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
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
	}

	public static void montarTerminais(string tag, string alternativo, ref DeclaracoesTopografico.structureConfigTopografico ctpg, string terminal, bool bAlternativo, string orientacao, ref DeclaracoesTopografico.structureTerminalTopog[] mLigTerm, ref string valor1, ref string valor2, ref string valor3, ref string valor4)
	{
		valor1 = "";
		valor2 = "";
		valor3 = "";
		valor4 = "";
		int num = 0;
		if (Operators.CompareString(mLigTerm[1].Tag, "", TextCompare: true) != 0)
		{
			num = 1;
		}
		if (Operators.CompareString(mLigTerm[2].Tag, "", TextCompare: true) != 0)
		{
			num = 2;
		}
		if (Operators.CompareString(mLigTerm[3].Tag, "", TextCompare: true) != 0)
		{
			num = 3;
		}
		if (Operators.CompareString(mLigTerm[4].Tag, "", TextCompare: true) != 0)
		{
			num = 4;
		}
		string text = tag;
		string text2 = mLigTerm[1].Tag;
		if (bAlternativo)
		{
			if (Operators.CompareString(alternativo.Trim(), "", TextCompare: true) != 0)
			{
				text = alternativo;
			}
			if (Operators.CompareString(mLigTerm[1].Alternativo.Trim(), "", TextCompare: true) != 0)
			{
				text2 = mLigTerm[1].Alternativo;
			}
		}
		if (Operators.CompareString(orientacao, "L", TextCompare: true) != 0 && Operators.CompareString(orientacao, "D", TextCompare: true) != 0)
		{
			if (Operators.CompareString(orientacao, "R", TextCompare: true) == 0 || Operators.CompareString(orientacao, "U", TextCompare: true) == 0)
			{
				switch (ctpg.padrao)
				{
				case 7:
					valor1 = ctpg.prefixoPonto + terminal + ctpg.delimitadorTT + text + ctpg.sufixoPonto;
					break;
				case 0:
					valor1 = ctpg.prefixoCruzado + text2 + ctpg.delimitadorTT + mLigTerm[1].Term + ctpg.sufixoCruzado;
					break;
				case 1:
					valor1 = ctpg.prefixoPonto + text + ctpg.delimitadorTT + terminal + ctpg.sufixoPonto;
					break;
				case 2:
					valor1 = ctpg.prefixoPonto + terminal + ctpg.delimitadorTT + text + ctpg.sufixoPonto + ctpg.delimitadorD + ctpg.prefixoCruzado + text2 + ctpg.delimitadorTT + mLigTerm[1].Term + ctpg.sufixoCruzado;
					break;
				case 3:
					valor1 = ctpg.prefixoPonto + text + ctpg.delimitadorTT + terminal + ctpg.sufixoPonto + ctpg.delimitadorD + ctpg.prefixoCruzado + text2 + ctpg.delimitadorTT + mLigTerm[1].Term + ctpg.sufixoCruzado;
					break;
				case 4:
					valor1 = ctpg.prefixoPonto + terminal + ctpg.sufixoPonto + ctpg.delimitadorD + ctpg.prefixoCruzado + text2 + ctpg.delimitadorTT + mLigTerm[1].Term + ctpg.sufixoCruzado;
					break;
				case 5:
					valor1 = ctpg.prefixoPonto + terminal + ctpg.sufixoPonto + ctpg.delimitadorD + ctpg.prefixoCruzado + text2 + ctpg.delimitadorTT + mLigTerm[1].Term + ctpg.sufixoCruzado;
					break;
				case 6:
					valor1 = ctpg.prefixoPonto + terminal + ctpg.delimitadorTT + text + ctpg.sufixoPonto + ctpg.delimitadorD + ctpg.prefixoCruzado + text2 + ctpg.delimitadorTT + mLigTerm[1].Term + ctpg.sufixoCruzado;
					break;
				}
			}
		}
		else
		{
			switch (ctpg.padrao)
			{
			case 7:
				valor1 = ctpg.prefixoPonto + text + ctpg.delimitadorTT + terminal + ctpg.sufixoPonto;
				break;
			case 0:
				valor1 = ctpg.prefixoCruzado + text2 + ctpg.delimitadorTT + mLigTerm[1].Term + ctpg.sufixoCruzado;
				break;
			case 1:
				valor1 = ctpg.prefixoPonto + text + ctpg.delimitadorTT + terminal + ctpg.sufixoPonto;
				break;
			case 2:
				valor1 = ctpg.prefixoCruzado + mLigTerm[1].Term + ctpg.delimitadorTT + text2 + ctpg.sufixoCruzado + ctpg.delimitadorD + ctpg.prefixoPonto + text + ctpg.delimitadorTT + terminal + ctpg.sufixoPonto;
				break;
			case 3:
				valor1 = ctpg.prefixoCruzado + text2 + ctpg.delimitadorTT + mLigTerm[1].Term + ctpg.sufixoCruzado + ctpg.delimitadorD + ctpg.prefixoPonto + text + ctpg.delimitadorTT + terminal + ctpg.sufixoPonto;
				break;
			case 4:
				valor1 = ctpg.prefixoCruzado + text2 + ctpg.delimitadorTT + mLigTerm[1].Term + ctpg.sufixoCruzado + ctpg.delimitadorD + ctpg.prefixoPonto + terminal + ctpg.sufixoPonto;
				break;
			case 5:
				valor1 = ctpg.prefixoCruzado + mLigTerm[1].Term + ctpg.delimitadorTT + text2 + ctpg.sufixoCruzado + ctpg.delimitadorD + ctpg.prefixoPonto + terminal + ctpg.sufixoPonto;
				break;
			case 6:
				valor1 = ctpg.prefixoCruzado + text2 + ctpg.delimitadorTT + mLigTerm[1].Term + ctpg.sufixoCruzado + ctpg.delimitadorD + ctpg.prefixoPonto + text + ctpg.delimitadorTT + terminal + ctpg.sufixoPonto;
				break;
			}
		}
		if (num >= 2)
		{
			string text3 = mLigTerm[2].Tag;
			if (bAlternativo && Operators.CompareString(mLigTerm[2].Alternativo.Trim(), "", TextCompare: true) != 0)
			{
				text3 = mLigTerm[2].Alternativo;
			}
			if (Operators.CompareString(orientacao, "L", TextCompare: true) != 0 && Operators.CompareString(orientacao, "D", TextCompare: true) != 0)
			{
				if (Operators.CompareString(orientacao, "R", TextCompare: true) == 0 || Operators.CompareString(orientacao, "U", TextCompare: true) == 0)
				{
					switch (ctpg.padrao)
					{
					case 7:
						valor2 = ctpg.prefixoPonto + terminal + ctpg.delimitadorTT + text + ctpg.sufixoPonto;
						break;
					case 0:
						valor2 = ctpg.prefixoCruzado + text3 + ctpg.delimitadorTT + mLigTerm[2].Term + ctpg.sufixoCruzado;
						break;
					case 1:
						valor2 = ctpg.prefixoPonto + text + ctpg.delimitadorTT + terminal + ctpg.sufixoPonto;
						break;
					case 2:
						valor2 = ctpg.prefixoPonto + terminal + ctpg.delimitadorTT + text + ctpg.sufixoPonto + ctpg.delimitadorD + ctpg.prefixoCruzado + text3 + ctpg.delimitadorTT + mLigTerm[2].Term + ctpg.sufixoCruzado;
						break;
					case 3:
						valor2 = ctpg.prefixoPonto + text + ctpg.delimitadorTT + terminal + ctpg.sufixoPonto + ctpg.delimitadorD + ctpg.prefixoCruzado + text3 + ctpg.delimitadorTT + mLigTerm[2].Term + ctpg.sufixoCruzado;
						break;
					case 4:
						valor2 = ctpg.prefixoPonto + terminal + ctpg.sufixoPonto + ctpg.delimitadorD + ctpg.prefixoCruzado + text3 + ctpg.delimitadorTT + mLigTerm[2].Term + ctpg.sufixoCruzado;
						break;
					case 5:
						valor2 = ctpg.prefixoPonto + terminal + ctpg.sufixoPonto + ctpg.delimitadorD + ctpg.prefixoCruzado + text3 + ctpg.delimitadorTT + mLigTerm[2].Term + ctpg.sufixoCruzado;
						break;
					case 6:
						valor2 = ctpg.prefixoPonto + terminal + ctpg.delimitadorTT + text + ctpg.sufixoPonto + ctpg.delimitadorD + ctpg.prefixoCruzado + text3 + ctpg.delimitadorTT + mLigTerm[2].Term + ctpg.sufixoCruzado;
						break;
					}
				}
			}
			else
			{
				switch (ctpg.padrao)
				{
				case 7:
					valor2 = ctpg.prefixoPonto + text + ctpg.delimitadorTT + terminal + ctpg.sufixoPonto;
					break;
				case 0:
					valor2 = ctpg.prefixoCruzado + text3 + ctpg.delimitadorTT + mLigTerm[2].Term + ctpg.sufixoCruzado;
					break;
				case 1:
					valor2 = ctpg.prefixoPonto + text + ctpg.delimitadorTT + terminal + ctpg.sufixoPonto;
					break;
				case 2:
					valor2 = ctpg.prefixoCruzado + mLigTerm[2].Term + ctpg.delimitadorTT + text3 + ctpg.sufixoCruzado + ctpg.delimitadorD + ctpg.prefixoPonto + text + ctpg.delimitadorTT + terminal + ctpg.sufixoPonto;
					break;
				case 3:
					valor2 = ctpg.prefixoCruzado + text3 + ctpg.delimitadorTT + mLigTerm[2].Term + ctpg.sufixoCruzado + ctpg.delimitadorD + ctpg.prefixoPonto + text + ctpg.delimitadorTT + terminal + ctpg.sufixoPonto;
					break;
				case 4:
					valor2 = ctpg.prefixoCruzado + text3 + ctpg.delimitadorTT + mLigTerm[2].Term + ctpg.sufixoCruzado + ctpg.delimitadorD + ctpg.prefixoPonto + terminal + ctpg.sufixoPonto;
					break;
				case 5:
					valor2 = ctpg.prefixoCruzado + mLigTerm[2].Term + ctpg.delimitadorTT + text3 + ctpg.sufixoCruzado + ctpg.delimitadorD + ctpg.prefixoPonto + terminal + ctpg.sufixoPonto;
					break;
				case 6:
					valor2 = ctpg.prefixoCruzado + text3 + ctpg.delimitadorTT + mLigTerm[2].Term + ctpg.sufixoCruzado + ctpg.delimitadorD + ctpg.prefixoPonto + text + ctpg.delimitadorTT + terminal + ctpg.sufixoPonto;
					break;
				}
			}
		}
		if (num >= 3)
		{
			string text4 = mLigTerm[3].Tag;
			if (bAlternativo && Operators.CompareString(mLigTerm[3].Alternativo.Trim(), "", TextCompare: true) != 0)
			{
				text4 = mLigTerm[3].Alternativo;
			}
			if (Operators.CompareString(orientacao, "L", TextCompare: true) != 0 && Operators.CompareString(orientacao, "D", TextCompare: true) != 0)
			{
				if (Operators.CompareString(orientacao, "R", TextCompare: true) == 0 || Operators.CompareString(orientacao, "U", TextCompare: true) == 0)
				{
					switch (ctpg.padrao)
					{
					case 7:
						valor3 = ctpg.prefixoPonto + terminal + ctpg.delimitadorTT + text + ctpg.sufixoPonto;
						break;
					case 0:
						valor3 = ctpg.prefixoCruzado + text4 + ctpg.delimitadorTT + mLigTerm[3].Term + ctpg.sufixoCruzado;
						break;
					case 1:
						valor3 = ctpg.prefixoPonto + text + ctpg.delimitadorTT + terminal + ctpg.sufixoPonto;
						break;
					case 2:
						valor3 = ctpg.prefixoPonto + terminal + ctpg.delimitadorTT + text + ctpg.sufixoPonto + ctpg.delimitadorD + ctpg.prefixoCruzado + text4 + ctpg.delimitadorTT + mLigTerm[3].Term + ctpg.sufixoCruzado;
						break;
					case 3:
						valor3 = ctpg.prefixoPonto + text + ctpg.delimitadorTT + terminal + ctpg.sufixoPonto + ctpg.delimitadorD + ctpg.prefixoCruzado + text4 + ctpg.delimitadorTT + mLigTerm[3].Term + ctpg.sufixoCruzado;
						break;
					case 4:
						valor3 = ctpg.prefixoPonto + terminal + ctpg.sufixoPonto + ctpg.delimitadorD + ctpg.prefixoCruzado + text4 + ctpg.delimitadorTT + mLigTerm[3].Term + ctpg.sufixoCruzado;
						break;
					case 5:
						valor3 = ctpg.prefixoPonto + terminal + ctpg.sufixoPonto + ctpg.delimitadorD + ctpg.prefixoCruzado + text4 + ctpg.delimitadorTT + mLigTerm[3].Term + ctpg.sufixoCruzado;
						break;
					case 6:
						valor3 = ctpg.prefixoPonto + terminal + ctpg.delimitadorTT + text + ctpg.sufixoPonto + ctpg.delimitadorD + ctpg.prefixoCruzado + text4 + ctpg.delimitadorTT + mLigTerm[3].Term + ctpg.sufixoCruzado;
						break;
					}
				}
			}
			else
			{
				switch (ctpg.padrao)
				{
				case 7:
					valor3 = ctpg.prefixoPonto + text + ctpg.delimitadorTT + terminal + ctpg.sufixoPonto;
					break;
				case 0:
					valor3 = ctpg.prefixoCruzado + text4 + ctpg.delimitadorTT + mLigTerm[3].Term + ctpg.sufixoCruzado;
					break;
				case 1:
					valor3 = ctpg.prefixoPonto + text + ctpg.delimitadorTT + terminal + ctpg.sufixoPonto;
					break;
				case 2:
					valor3 = ctpg.prefixoCruzado + mLigTerm[3].Term + ctpg.delimitadorTT + text4 + ctpg.sufixoCruzado + ctpg.delimitadorD + ctpg.prefixoPonto + text + ctpg.delimitadorTT + terminal + ctpg.sufixoPonto;
					break;
				case 3:
					valor3 = ctpg.prefixoCruzado + text4 + ctpg.delimitadorTT + mLigTerm[3].Term + ctpg.sufixoCruzado + ctpg.delimitadorD + ctpg.prefixoPonto + text + ctpg.delimitadorTT + terminal + ctpg.sufixoPonto;
					break;
				case 4:
					valor3 = ctpg.prefixoCruzado + text4 + ctpg.delimitadorTT + mLigTerm[3].Term + ctpg.sufixoCruzado + ctpg.delimitadorD + ctpg.prefixoPonto + terminal + ctpg.sufixoPonto;
					break;
				case 5:
					valor3 = ctpg.prefixoCruzado + mLigTerm[3].Term + ctpg.delimitadorTT + text4 + ctpg.sufixoCruzado + ctpg.delimitadorD + ctpg.prefixoPonto + terminal + ctpg.sufixoPonto;
					break;
				case 6:
					valor3 = ctpg.prefixoCruzado + text4 + ctpg.delimitadorTT + mLigTerm[3].Term + ctpg.sufixoCruzado + ctpg.delimitadorD + ctpg.prefixoPonto + text + ctpg.delimitadorTT + terminal + ctpg.sufixoPonto;
					break;
				}
			}
		}
		if (num == 4)
		{
			string text5 = mLigTerm[4].Tag;
			if (bAlternativo && Operators.CompareString(mLigTerm[4].Alternativo.Trim(), "", TextCompare: true) != 0)
			{
				text5 = mLigTerm[4].Alternativo;
			}
			if (Operators.CompareString(orientacao, "L", TextCompare: true) != 0 && Operators.CompareString(orientacao, "D", TextCompare: true) != 0)
			{
				if (Operators.CompareString(orientacao, "R", TextCompare: true) == 0 || Operators.CompareString(orientacao, "U", TextCompare: true) == 0)
				{
					switch (ctpg.padrao)
					{
					case 7:
						valor4 = ctpg.prefixoPonto + terminal + ctpg.delimitadorTT + text + ctpg.sufixoPonto;
						break;
					case 0:
						valor4 = ctpg.prefixoCruzado + text5 + ctpg.delimitadorTT + mLigTerm[4].Term + ctpg.sufixoCruzado;
						break;
					case 1:
						valor4 = ctpg.prefixoPonto + text + ctpg.delimitadorTT + terminal + ctpg.sufixoPonto;
						break;
					case 2:
						valor4 = ctpg.prefixoPonto + terminal + ctpg.delimitadorTT + text + ctpg.sufixoPonto + ctpg.delimitadorD + ctpg.prefixoCruzado + text5 + ctpg.delimitadorTT + mLigTerm[4].Term + ctpg.sufixoCruzado;
						break;
					case 3:
						valor4 = ctpg.prefixoPonto + text + ctpg.delimitadorTT + terminal + ctpg.sufixoPonto + ctpg.delimitadorD + ctpg.prefixoCruzado + text5 + ctpg.delimitadorTT + mLigTerm[4].Term + ctpg.sufixoCruzado;
						break;
					case 4:
						valor4 = ctpg.prefixoPonto + terminal + ctpg.sufixoPonto + ctpg.delimitadorD + ctpg.prefixoCruzado + text5 + ctpg.delimitadorTT + mLigTerm[4].Term + ctpg.sufixoCruzado;
						break;
					case 5:
						valor4 = ctpg.prefixoPonto + terminal + ctpg.sufixoPonto + ctpg.delimitadorD + ctpg.prefixoCruzado + text5 + ctpg.delimitadorTT + mLigTerm[4].Term + ctpg.sufixoCruzado;
						break;
					case 6:
						valor4 = ctpg.prefixoPonto + terminal + ctpg.delimitadorTT + text + ctpg.sufixoPonto + ctpg.delimitadorD + ctpg.prefixoCruzado + text5 + ctpg.delimitadorTT + mLigTerm[4].Term + ctpg.sufixoCruzado;
						break;
					}
				}
			}
			else
			{
				switch (ctpg.padrao)
				{
				case 7:
					valor4 = ctpg.prefixoPonto + text + ctpg.delimitadorTT + terminal + ctpg.sufixoPonto;
					break;
				case 0:
					valor4 = ctpg.prefixoCruzado + text5 + ctpg.delimitadorTT + mLigTerm[4].Term + ctpg.sufixoCruzado;
					break;
				case 1:
					valor4 = ctpg.prefixoPonto + text + ctpg.delimitadorTT + terminal + ctpg.sufixoPonto;
					break;
				case 2:
					valor4 = ctpg.prefixoCruzado + mLigTerm[4].Term + ctpg.delimitadorTT + text5 + ctpg.sufixoCruzado + ctpg.delimitadorD + ctpg.prefixoPonto + text + ctpg.delimitadorTT + terminal + ctpg.sufixoPonto;
					break;
				case 3:
					valor4 = ctpg.prefixoCruzado + text5 + ctpg.delimitadorTT + mLigTerm[4].Term + ctpg.sufixoCruzado + ctpg.delimitadorD + ctpg.prefixoPonto + text + ctpg.delimitadorTT + terminal + ctpg.sufixoPonto;
					break;
				case 4:
					valor4 = ctpg.prefixoCruzado + text5 + ctpg.delimitadorTT + mLigTerm[4].Term + ctpg.sufixoCruzado + ctpg.delimitadorD + ctpg.prefixoPonto + terminal + ctpg.sufixoPonto;
					break;
				case 5:
					valor4 = ctpg.prefixoCruzado + mLigTerm[4].Term + ctpg.delimitadorTT + text5 + ctpg.sufixoCruzado + ctpg.delimitadorD + ctpg.prefixoPonto + terminal + ctpg.sufixoPonto;
					break;
				case 6:
					valor4 = ctpg.prefixoCruzado + text5 + ctpg.delimitadorTT + mLigTerm[4].Term + ctpg.sufixoCruzado + ctpg.delimitadorD + ctpg.prefixoPonto + text + ctpg.delimitadorTT + terminal + ctpg.sufixoPonto;
					break;
				}
			}
		}
		mLigTerm[1].Anilha = valor1;
		mLigTerm[2].Anilha = valor2;
		mLigTerm[3].Anilha = valor3;
		mLigTerm[4].Anilha = valor4;
	}

	public static void carregarLigacoes(string tag, ref DeclaracoesTopografico.structureLigTermTopografico[] mLigacoes, int indiceSel, string revisaoSel, int painelSel, string tipo, int indexModelo, ref DeclaracoesFiacao.structureLink[] mLink)
	{
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		checked
		{
			try
			{
				DeclaracoesFiacao.structureFiacao[] mfiacao = new DeclaracoesFiacao.structureFiacao[1];
				mfiacao[0].Lig = new DeclaracoesFiacao.structureLigacao[1];
				if (!((Operators.CompareString(tipo, "A", TextCompare: true) == 0) & (indexModelo == 0)))
				{
					if (!((Operators.CompareString(tipo, "A", TextCompare: true) == 0) & (indexModelo > 0)))
					{
						if (Operators.CompareString(tipo, "E", TextCompare: true) != 0)
						{
							if (Operators.CompareString(tipo, "B", TextCompare: true) == 0)
							{
								cDadosAccessFiacao2.CarregaTerminaisRegua(indiceSel, revisaoSel, painelSel, indexModelo, ref mfiacao);
							}
						}
						else
						{
							cDadosAccessFiacao2.CarregaTerminaisMascara(indiceSel, revisaoSel, indexModelo, ref mfiacao);
						}
					}
					else
					{
						cDadosAccessFiacao2.CarregaTerminaisContato(indiceSel, revisaoSel, indexModelo, ref mfiacao);
					}
				}
				else
				{
					cDadosAccessFiacao2.CarregaTerminaisDispositivo(indiceSel, revisaoSel, painelSel, tag, ref mfiacao);
				}
				cDadosAccessFiacao2.CarregaLigacoesTerminal(indiceSel, revisaoSel, painelSel, tag, tipo, ref mfiacao, ref mLink);
				int num = Information.UBound(mfiacao);
				for (int i = 1; i <= num; i++)
				{
					DeclaracoesFiacao.structureLigacao[] lig = mfiacao[i].Lig;
					mLigacoes = (DeclaracoesTopografico.structureLigTermTopografico[])Utils.CopyArray(mLigacoes, new DeclaracoesTopografico.structureLigTermTopografico[Information.UBound(mLigacoes) + 1 + 1]);
					ref DeclaracoesFiacao.structureLigacao[] lig2 = ref mLigacoes[Information.UBound(mLigacoes)].Lig;
					lig2 = (DeclaracoesFiacao.structureLigacao[])Utils.CopyArray(lig2, new DeclaracoesFiacao.structureLigacao[Information.UBound(lig) + 1]);
					mLigacoes[Information.UBound(mLigacoes)].Terminal = mfiacao[i].Terminal;
					int num2 = Information.UBound(lig);
					for (int j = 1; j <= num2; j++)
					{
						mLigacoes[Information.UBound(mLigacoes)].Lig[j].Tag = lig[j].Tag;
						mLigacoes[Information.UBound(mLigacoes)].Lig[j].Alternativo = lig[j].Alternativo;
						mLigacoes[Information.UBound(mLigacoes)].Lig[j].Term = lig[j].Term;
						mLigacoes[Information.UBound(mLigacoes)].Lig[j].Secao = lig[j].Secao;
						mLigacoes[Information.UBound(mLigacoes)].Lig[j].Cor = lig[j].Cor;
					}
				}
			}
			finally
			{
				cDadosAccessFiacao2.fechaConexao();
			}
		}
	}

	public static void carregaDispositivosInseridos(int painel, List<string> lTags)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected Obj, but got Unknown
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
					Entity val4 = (Entity)current.GetObject((OpenMode)0);
					BlockReference blockRef = (BlockReference)(object)((val4 is BlockReference) ? val4 : null);
					if (blockRef != null)
					{
						DeclaracoesTopografico.structureDispTopografico dTpg = default;
						if (XDataTopografico.lerXDataDispTopografico(ref blockRef, ref dTpg) && painel == dTpg.painel)
						{
							lTags.Add(dTpg.tag);
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
			ProjectData.ClearProjectError();
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void carregaBornesInseridos(int painel, string regua, List<string> lBornes)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected Obj, but got Unknown
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
					Entity val4 = (Entity)current.GetObject((OpenMode)0);
					BlockReference blockRef = (BlockReference)(object)((val4 is BlockReference) ? val4 : null);
					if (blockRef != null)
					{
						DeclaracoesTopografico.structureBorneTopografico bTpg = default;
						if (XDataTopografico.lerXDataBorneTopografico(ref blockRef, ref bTpg) && ((painel == bTpg.painel) & (Operators.CompareString(regua, bTpg.regua, TextCompare: true) == 0)))
						{
							lBornes.Add(bTpg.borne);
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
			ProjectData.ClearProjectError();
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void ApagaTerminaisDoBlocoApagado(string sLayer, string sTag, string sAlternativo)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected Obj, but got Unknown
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
						Entity val5 = (Entity)current.GetObject((OpenMode)0);
						if (Operators.CompareString(val5.Layer, sLayer, TextCompare: true) != 0)
						{
							continue;
						}
						BlockReference attRef = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
						if (attRef != null)
						{
							DeclaracoesTopografico.structureTerminalTopog[] mLigTerm = new DeclaracoesTopografico.structureTerminalTopog[5];
							string tipo = "";
							string handle = "";
							string tag = "";
							string alternativo = "";
							string terminal = "";
							string rotacao = "";
							if (XDataTopografico.LerXDataTermTopografico(ref attRef, ref tipo, ref handle, ref tag, ref alternativo, ref terminal, ref rotacao, ref mLigTerm) && ((Operators.CompareString(tag, sTag, TextCompare: true) == 0) & (Operators.CompareString(alternativo, sAlternativo, TextCompare: true) == 0)))
							{
								((DBObject)attRef).UpgradeOpen();
								((DBObject)attRef).Erase();
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
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
	}
}

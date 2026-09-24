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

public class clsDIEnergisaMS
{
	private struct RRPSqdp5G7emk7eXw6v2
	{
		public string F1Jp5H24SJl;

		public int gwyp5kMUNv1;
	}

	public static void InserirColunaAranha(string nomebloco, Point3d ptIns)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected Obj, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected Obj, but got Unknown
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected Obj, but got Unknown
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected Obj, but got Unknown
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected Obj, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
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
					string text2 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Interligação\\Energisa\\" + nomebloco;
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
					_ = (BlockTableRecord)val2.GetObject(val3, (OpenMode)0);
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

	public static void InserirBorneAranha(string nomebloco, DeclaracoesInterligacao.borneAranha bn, Point3d ptIns, bool bInsereNomeRegua)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected Obj, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected Obj, but got Unknown
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected Obj, but got Unknown
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
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
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Expected Obj, but got Unknown
		//IL_039c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Expected Obj, but got Unknown
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_0324: Unknown result type (might be due to invalid IL or missing references)
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_035e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0369: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0393: Expected Obj, but got Unknown
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
					string text2 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Interligação\\Energisa\\" + nomebloco;
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
								if (Operators.CompareString(tag, "B", TextCompare: true) != 0)
								{
									((Entity)val11).Visible = false;
								}
								else
								{
									((DBText)val11).TextString = bn.Borne;
								}
								((DBText)val11).AdjustAlignment(database);
								blockRef.AttributeCollection.AppendAttribute(val11);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val11, true);
								((Entity)val11).Draw();
							}
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
					((Entity)blockRef).Draw();
					XDataDIEnergisa.GravarXDataBorne(ref blockRef, bn);
					if (bInsereNomeRegua)
					{
						TextStyleTable val12 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)0);
						ObjectId textStyleId = (((SymbolTable)val12).Has("Romans") ? ((SymbolTable)val12)["Romans"] : ((SymbolTable)val12)["Standard"]);
						DBText val13 = new DBText();
						val13.TextString = bn.Tag;
						if (Operators.CompareString(bn.NRegua, "", TextCompare: true) != 0)
						{
							val13.TextString = bn.NRegua;
						}
						((Entity)val13).ColorIndex = 7;
						((Entity)val13).Layer = ((Entity)blockRef).Layer;
						val13.Height = 2.5;
						val13.TextStyleId = textStyleId;
						val13.WidthFactor = 1.0;
						Extents3d value = ((Drawable)blockRef).Bounds.Value;
						Point3d val14 = value.MaxPoint;
						double x = val14.X;
						value = ((Drawable)blockRef).Bounds.Value;
						val14 = value.MinPoint;
						double num = (x - val14.X) / 2.0;
						val14 = blockRef.Position;
						double num2 = num + val14.X;
						val14 = blockRef.Position;
						Point3d alignmentPoint = new Point3d(num2, val14.Y + 1.5, 0.0);
						val13.HorizontalMode = (TextHorizontalMode)1;
						val13.VerticalMode = (TextVerticalMode)0;
						val13.AlignmentPoint = alignmentPoint;
						val5.AppendEntity((Entity)(object)val13);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)val13, true);
						Entity ent = (Entity)(object)val13;
						XDataDIEnergisa.GravarXDataNomeRegua(ref ent, bn);
						val13 = (DBText)ent;
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

	public static void insereColunasSePrecisar(ref List<string> lPaginasColunas, Point3d ptCol1, Point3d ptCol2)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		if (!lPaginasColunas.Contains(DeclaracoesGeral.ativo.Pagina))
		{
			InserirColunaAranha("Coluna1.dwg", ptCol1);
			InserirColunaAranha("Coluna2.dwg", ptCol2);
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
					if ((Operators.CompareString(blockRef.Name, "BorneSimples", TextCompare: true) == 0) | (Operators.CompareString(blockRef.Name, "BorneDuplo", TextCompare: true) == 0))
					{
						DeclaracoesInterligacao.borneAranha bn = default;
						if (XDataDIEnergisa.LerXDataBorne(ref blockRef, ref bn) && ((bn.Painel == Painel) & (Operators.CompareString(bn.Tag, Tag, TextCompare: true) == 0) & (Operators.CompareString(bn.NRegua, NRegua, TextCompare: true) == 0)))
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

	public static bool outraReguaExiste(string Pagina, ref Point3d pt, int colNum)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected Obj, but got Unknown
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
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
					if (!((Operators.CompareString(blockRef.Name, "BorneSimples", TextCompare: true) == 0) | (Operators.CompareString(blockRef.Name, "BorneDuplo", TextCompare: true) == 0)) || Operators.CompareString(((Entity)blockRef).Layer, Pagina, TextCompare: true) != 0)
					{
						continue;
					}
					DeclaracoesInterligacao.borneAranha bn = default;
					if (XDataDIEnergisa.LerXDataBorne(ref blockRef, ref bn) && bn.Posicao == colNum)
					{
						Point3d position = blockRef.Position;
						if (position.Y < val4.Y)
						{
							val4 = blockRef.Position;
							result = true;
						}
					}
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

	public static bool BuscaUltimoBorne(int Painel, string Tag, string NRegua, ref DeclaracoesInterligacao.PosborneAranha ubn, ref List<string> lBornes)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected Obj, but got Unknown
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
			BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
			double num = 0.0;
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
					if (!((Operators.CompareString(blockRef.Name, "BorneSimples", TextCompare: true) == 0) | (Operators.CompareString(blockRef.Name, "BorneDuplo", TextCompare: true) == 0)))
					{
						continue;
					}
					DeclaracoesInterligacao.borneAranha bn = default;
					if (XDataDIEnergisa.LerXDataBorne(ref blockRef, ref bn) && ((bn.Painel == Painel) & (Operators.CompareString(bn.Tag, Tag, TextCompare: true) == 0) & (Operators.CompareString(bn.NRegua, NRegua, TextCompare: true) == 0)))
					{
						result = true;
						if (bn.Ordem > num)
						{
							num = bn.Ordem;
							lBornes.Add(bn.Borne);
							ubn.Pagina = ((Entity)blockRef).Layer;
							ubn.Posicao = bn.Posicao;
							ubn.PtIns = blockRef.Position;
							ubn.Ordem = bn.Ordem;
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
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected Obj, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected Obj, but got Unknown
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected Obj, but got Unknown
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
						if (Operators.CompareString(current.ObjectClass.DxfName.ToUpper(), "INSERT", TextCompare: true) != 0)
						{
							if (Operators.CompareString(current.ObjectClass.DxfName.ToUpper(), "TEXT", TextCompare: true) == 0)
							{
								DBText val5 = (DBText)val2.GetObject(current, (OpenMode)0);
								DeclaracoesInterligacao.borneAranha bn = default;
								Entity ent = (Entity)(object)val5;
								bool flag = XDataDIEnergisa.LerXDataNomeRegua(ref ent, ref bn);
								val5 = (DBText)ent;
								if (flag && ((Operators.CompareString(bn.Revisao, revisao, TextCompare: true) == 0) & (bn.Painel == Painel) & (Operators.CompareString(bn.Tag, Tag, TextCompare: true) == 0) & (Operators.CompareString(bn.NRegua, NRegua, TextCompare: true) == 0)))
								{
									((DBObject)val5).UpgradeOpen();
									((DBObject)val5).Erase();
								}
							}
							continue;
						}
						BlockReference blockRef = (BlockReference)val2.GetObject(current, (OpenMode)0);
						if ((Operators.CompareString(blockRef.Name, "BorneSimples", TextCompare: true) == 0) | (Operators.CompareString(blockRef.Name, "BorneDuplo", TextCompare: true) == 0))
						{
							DeclaracoesInterligacao.borneAranha bn2 = default;
							if (XDataDIEnergisa.LerXDataBorne(ref blockRef, ref bn2) && ((Operators.CompareString(bn2.Revisao, revisao, TextCompare: true) == 0) & (bn2.Painel == Painel) & (Operators.CompareString(bn2.Tag, Tag, TextCompare: true) == 0) & (Operators.CompareString(bn2.NRegua, NRegua, TextCompare: true) == 0)))
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
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected Obj, but got Unknown
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
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
						if (!((Operators.CompareString(blockRef.Name, "BorneSimples", TextCompare: true) == 0) | (Operators.CompareString(blockRef.Name, "BorneDuplo", TextCompare: true) == 0)))
						{
							continue;
						}
						DeclaracoesInterligacao.borneAranha bn = default;
						if (!XDataDIEnergisa.LerXDataBorne(ref blockRef, ref bn) || bn.Painel != Painel)
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
							if (bn.TipoBorne != 0)
							{
								if (bn.TipoBorne == 1)
								{
									num2 = 10.0;
									num3 = -2.5;
								}
							}
							else
							{
								num2 = 10.0;
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
		//IL_0389: Unknown result type (might be due to invalid IL or missing references)
		//IL_038e: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_049c: Unknown result type (might be due to invalid IL or missing references)
		//IL_049e: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0330: Unknown result type (might be due to invalid IL or missing references)
		//IL_0335: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_034f: Unknown result type (might be due to invalid IL or missing references)
		//IL_036b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0370: Unknown result type (might be due to invalid IL or missing references)
		//IL_0455: Unknown result type (might be due to invalid IL or missing references)
		//IL_045a: Unknown result type (might be due to invalid IL or missing references)
		//IL_046f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0474: Unknown result type (might be due to invalid IL or missing references)
		//IL_0490: Unknown result type (might be due to invalid IL or missing references)
		//IL_0495: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0401: Unknown result type (might be due to invalid IL or missing references)
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		//IL_041b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0437: Unknown result type (might be due to invalid IL or missing references)
		//IL_043c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Expected Obj, but got Unknown
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f4: Expected Obj, but got Unknown
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
							if (tipoBorne != 0)
							{
								if (tipoBorne == 1 && ((posicao == 1) | (posicao == 3)))
								{
									position = val7.Position;
									double num = position.X + 10.0;
									position = val7.Position;
									val5 = new Point3d(num, position.Y - 7.5, 0.0);
								}
							}
							else if ((posicao == 1) | (posicao == 3))
							{
								position = val7.Position;
								double num2 = position.X + 10.0;
								position = val7.Position;
								val5 = new Point3d(num2, position.Y - 2.5, 0.0);
							}
						}
						Point3d val8 = default;
						val6 = (Entity)Geral.HandleToObject(handle2);
						if (val6 != null)
						{
							BlockReference val9 = (BlockReference)(object)((val6 is BlockReference) ? val6 : null);
							if (tipoBorne2 != 0)
							{
								if (tipoBorne2 == 1 && ((posicao2 == 1) | (posicao2 == 3)))
								{
									position = val9.Position;
									double num3 = position.X + 10.0;
									position = val9.Position;
									val8 = new Point3d(num3, position.Y - 7.5, 0.0);
								}
							}
							else if ((posicao2 == 1) | (posicao2 == 3))
							{
								position = val9.Position;
								double num4 = position.X + 10.0;
								position = val9.Position;
								val8 = new Point3d(num4, position.Y - 2.5, 0.0);
							}
						}
						Point3d val10 = default;
						if (val5.Y < val8.Y)
						{
							val10 = val5;
							val5 = val8;
							val8 = val10;
						}
						double num5 = default;
						if (!((posicao == 1) | (posicao == 3)))
						{
							if ((posicao == 2) | (posicao == 4))
							{
								num5 = -2.5;
							}
						}
						else
						{
							num5 = 2.5;
						}
						int num6 = 1;
						Polyline val15;
						while (true)
						{
							Point2d val11 = new Point2d(val5.X, val5.Y);
							Point2d val12 = new Point2d(val5.X + num5 * (double)num6, val5.Y - 1.5);
							Point2d val13 = new Point2d(val8.X + num5 * (double)num6, val8.Y + 1.5);
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
							if (!dEop2RxAm0(val12.X, val12.Y, val13.Y, pagina, revisao, painel))
							{
								break;
							}
							num6++;
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
						XDataDIEnergisa.GravarXDataJumper(ref ent, revisao, painel, bnO, bnD);
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

	private static bool dEop2RxAm0(double P_0, double P_1, double P_2, string P_3, string P_4, int P_5)
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
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected Obj, but got Unknown
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected Obj, but got Unknown
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
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
						string tag_cabo = "";
						string veia = "";
						string handle = "";
						Entity ent = (Entity)(object)val4;
						bool flag = XDataDIEnergisa.LerXDataJumper(ref ent, ref P_4, ref P_5, ref bnO, ref bnD);
						val4 = (Polyline)ent;
						Point2d val5;
						if (!flag)
						{
							ent = (Entity)(object)val4;
							flag = XDataDIEnergisa.LerXDataVeia(ref ent, ref P_4, ref P_5, ref tag_cabo, ref veia, ref handle);
							val4 = (Polyline)ent;
							if (!flag)
							{
								continue;
							}
							LineSegment2d lineSegment2dAt = val4.GetLineSegment2dAt(0);
							val5 = lineSegment2dAt.StartPoint;
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
							continue;
						}
						LineSegment2d lineSegment2dAt2 = val4.GetLineSegment2dAt(1);
						val5 = lineSegment2dAt2.StartPoint;
						if (P_0 == val5.X)
						{
							val5 = lineSegment2dAt2.StartPoint;
							bool flag4 = P_1 > val5.Y;
							val5 = lineSegment2dAt2.EndPoint;
							bool num6 = flag4 & (P_1 > val5.Y);
							val5 = lineSegment2dAt2.StartPoint;
							bool num7 = num6 & (P_2 > val5.Y);
							val5 = lineSegment2dAt2.EndPoint;
							bool num8 = num7 & (P_2 > val5.Y);
							val5 = lineSegment2dAt2.StartPoint;
							bool flag5 = P_1 < val5.Y;
							val5 = lineSegment2dAt2.EndPoint;
							bool num9 = flag5 & (P_1 < val5.Y);
							val5 = lineSegment2dAt2.StartPoint;
							bool num10 = num9 & (P_2 < val5.Y);
							val5 = lineSegment2dAt2.EndPoint;
							if (!(num8 | (num10 & (P_2 < val5.Y))))
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
		//IL_06ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0709: Unknown result type (might be due to invalid IL or missing references)
		//IL_070e: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0805: Unknown result type (might be due to invalid IL or missing references)
		//IL_080c: Expected Obj, but got Unknown
		//IL_080e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0813: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Expected Obj, but got Unknown
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_066e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0673: Unknown result type (might be due to invalid IL or missing references)
		//IL_0688: Unknown result type (might be due to invalid IL or missing references)
		//IL_068d: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0306: Expected Obj, but got Unknown
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_0338: Expected Obj, but got Unknown
		//IL_0748: Unknown result type (might be due to invalid IL or missing references)
		//IL_074d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0762: Unknown result type (might be due to invalid IL or missing references)
		//IL_0767: Unknown result type (might be due to invalid IL or missing references)
		//IL_0783: Unknown result type (might be due to invalid IL or missing references)
		//IL_0788: Unknown result type (might be due to invalid IL or missing references)
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
		//IL_081e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0829: Unknown result type (might be due to invalid IL or missing references)
		//IL_0830: Expected Obj, but got Unknown
		//IL_0832: Unknown result type (might be due to invalid IL or missing references)
		//IL_0837: Unknown result type (might be due to invalid IL or missing references)
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
		//IL_0858: Unknown result type (might be due to invalid IL or missing references)
		//IL_085f: Expected Obj, but got Unknown
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
							if (tipoBorne != 0)
							{
								if (tipoBorne == 1 && ((posicao == 1) | (posicao == 3)))
								{
									position = val7.Position;
									double num = position.X + 10.0;
									position = val7.Position;
									val5 = new Point3d(num, position.Y - 7.5, 0.0);
									text = "JumperSaiDireita";
								}
							}
							else if ((posicao == 1) | (posicao == 3))
							{
								position = val7.Position;
								double num2 = position.X + 10.0;
								position = val7.Position;
								val5 = new Point3d(num2, position.Y - 2.5, 0.0);
								text = "JumperSaiDireita";
							}
						}
						string text2 = "";
						Point3d val8 = default;
						val6 = (Entity)Geral.HandleToObject(handle2);
						if (val6 != null)
						{
							BlockReference val9 = (BlockReference)(object)((val6 is BlockReference) ? val6 : null);
							if (tipoBorne2 != 0)
							{
								if (tipoBorne2 == 1 && ((posicao2 == 1) | (posicao2 == 3)))
								{
									position = val9.Position;
									double num3 = position.X + 10.0;
									position = val9.Position;
									val8 = new Point3d(num3, position.Y - 7.5, 0.0);
									text2 = "JumperEntraDireita";
								}
							}
							else if ((posicao2 == 1) | (posicao2 == 3))
							{
								position = val9.Position;
								double num4 = position.X + 10.0;
								position = val9.Position;
								val8 = new Point3d(num4, position.Y - 2.5, 0.0);
								text2 = "JumperEntraDireita";
							}
						}
						ObjectId val10 = ObjectId.Null;
						string text3 = "";
						text3 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Interligação\\Energisa\\" + text + ".dwg";
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
						XDataDIEnergisa.GravarXDataJumper(ref ent, revisao, painel, bnO, bnD);
						val13 = (BlockReference)ent;
						text3 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Interligação\\Energisa\\" + text2 + ".dwg";
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
						XDataDIEnergisa.GravarXDataJumper(ref ent, revisao, painel, bnO, bnD);
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
							if (XDataDIEnergisa.LerXDataJumper(ref ent, ref revisao2, ref painel, ref bnO, ref bnD) && ((Operators.CompareString(revisao2, revisao, TextCompare: true) == 0) & (painel == Painel)))
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

	public static void carregaCabos(string revisao, ref DeclaracoesInterligacao.structureRI[] mReguas, ref DeclaracoesInterligacao.borneJ[] mBornesJ, ref DeclaracoesInterligacao.caboAranha[] mCabos)
	{
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		List<string> list = new List<string>();
		int num = Information.UBound(mBornesJ);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				string tag = mBornesJ[i].Tag;
				string nRegua = mBornesJ[i].NRegua;
				string borne = mBornesJ[i].Borne;
				int num2 = Information.UBound(mReguas);
				for (int j = 1; j <= num2; j++)
				{
					if (!((Operators.CompareString(mReguas[j].Tag, tag, TextCompare: true) == 0) & (Operators.CompareString(mReguas[j].NRegua, nRegua, TextCompare: true) == 0)))
					{
						continue;
					}
					int num3 = Information.UBound(mReguas[j].Bornes);
					for (int k = 1; k <= num3; k++)
					{
						if (Operators.CompareString(mReguas[j].Bornes[k].Borne, borne, TextCompare: true) != 0)
						{
							continue;
						}
						int num4 = Information.UBound(mReguas[j].Bornes[k].cabos);
						for (int l = 1; l <= num4; l++)
						{
							string tag_Cabo = mReguas[j].Bornes[k].cabos[l].Tag_Cabo;
							string text = "";
							text = ((mReguas[j].Bornes[k].cabos[l].Cabos > 1) ? (mReguas[j].Bornes[k].cabos[l].Cabos + "x" + mReguas[j].Bornes[k].cabos[l].Formacao) : mReguas[j].Bornes[k].cabos[l].Formacao);
							bool blindagem = mReguas[j].Bornes[k].cabos[l].Blindagem;
							string sPainelDest = mReguas[j].Bornes[k].cabos[l].sPainelDest;
							bool bAterrar = mReguas[j].Bornes[k].cabos[l].bAterrar;
							if (list.Contains(tag_Cabo))
							{
								continue;
							}
							list.Add(tag_Cabo);
							int num5 = Information.UBound(mCabos) + 1;
							mCabos = (DeclaracoesInterligacao.caboAranha[])Utils.CopyArray(mCabos, new DeclaracoesInterligacao.caboAranha[num5 + 1]);
							mCabos[num5].mIndices = new int[1];
							mCabos[num5].Tag_Cabo = tag_Cabo;
							mCabos[num5].Formacao = text;
							mCabos[num5].Blindagem = blindagem;
							mCabos[num5].bAterrar = bAterrar;
							mCabos[num5].sPainelDest = sPainelDest;
							mCabos[num5].Pagina = mBornesJ[i].Pagina;
							if (!(text.Contains("P") | text.Contains("T")))
							{
								mCabos[num5].bParTrioTrancado = false;
							}
							else
							{
								mCabos[num5].bParTrioTrancado = true;
							}
							mCabos[num5].lVeiasUsadas = new List<string>();
							mCabos[num5].lVeiasLivres = new List<string>();
							cDadosAccessInterligacao3.CarregaVeiasUsadasLivres(revisao, tag_Cabo, ref mCabos[num5].lVeiasUsadas, ref mCabos[num5].lVeiasLivres);
							int posicao = mBornesJ[i].Posicao;
							if (posicao == 1)
							{
								mCabos[num5].Coluna = 1;
								mCabos[num5].Lado = "E";
							}
							else if (posicao == 3)
							{
								mCabos[num5].Coluna = 2;
								mCabos[num5].Lado = "E";
							}
							mCabos[num5].Y = mBornesJ[i].Y - 2.5;
							while (true)
							{
								int num6 = Information.UBound(mCabos);
								int num7 = 1;
								while (num7 <= num6)
								{
									if (!((num7 != num5) & (Operators.CompareString(mCabos[num7].Pagina, mCabos[num5].Pagina, TextCompare: true) == 0) & (mCabos[num7].Coluna == mCabos[num5].Coluna) & (mCabos[num7].Y == mCabos[num5].Y)))
									{
										num7++;
										continue;
									}
									goto IL_04f0;
								}
								break;
								IL_04f0:
								mCabos[num5].Y -= 5.0;
							}
						}
					}
				}
			}
			cDadosAccessInterligacao3.fechaConexao();
		}
	}

	public static void insereCabos(string revisao, int Painel, ref DeclaracoesInterligacao.caboAranha[] mCabos, List<string> lCabosInseridos, bool bAterrarBlindagem)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_0391: Unknown result type (might be due to invalid IL or missing references)
		//IL_0396: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected Obj, but got Unknown
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected Obj, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected Obj, but got Unknown
		//IL_04cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04df: Expected Obj, but got Unknown
		//IL_04e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_044f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0454: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Expected Obj, but got Unknown
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_0308: Expected Obj, but got Unknown
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Expected Obj, but got Unknown
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Expected Obj, but got Unknown
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
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
					double X = default;
					double X2 = default;
					buscaXColunas(ref X, ref X2);
					int num = Information.UBound(mCabos);
					Point3d val5 = default;
					BlockTableRecordEnumerator enumerator = default;
					for (int i = 1; i <= num; i = checked(i + 1))
					{
						if (lCabosInseridos.Contains(mCabos[i].Tag_Cabo))
						{
							continue;
						}
						string text = "";
						if (mCabos[i].Coluna != 1)
						{
							if (mCabos[i].Coluna == 2 && Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0)
							{
								val5 = new Point3d(X2 - 50.0, mCabos[i].Y, 0.0);
								if (mCabos[i].Blindagem)
								{
									if (mCabos[i].bAterrar)
									{
										text = "CaboEBA";
									}
									else if (mCabos[i].bParTrioTrancado)
									{
										text = "CaboEBNA";
									}
									else
									{
										text = (bAterrarBlindagem ? "CaboEBA" : "CaboEBNA");
									}
								}
								else
								{
									text = "CaboE";
								}
							}
						}
						else if (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0)
						{
							val5 = new Point3d(X - 50.0, mCabos[i].Y, 0.0);
							if (mCabos[i].Blindagem)
							{
								if (mCabos[i].bAterrar)
								{
									text = "CaboEBA";
								}
								else if (mCabos[i].bParTrioTrancado)
								{
									text = "CaboEBNA";
								}
								else
								{
									text = (bAterrarBlindagem ? "CaboEBA" : "CaboEBNA");
								}
							}
							else
							{
								text = "CaboE";
							}
						}
						ObjectId val6 = ObjectId.Null;
						string text2 = "";
						text2 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Interligação\\Energisa\\" + text + ".dwg";
						if (!((SymbolTable)val3).Has(text))
						{
							Database val7 = new Database(false, true);
							val7.ReadDwgFile(text2, FileShare.Read, true, "");
							DeclaracoesGeral.bAnularEventos = true;
							val6 = database.Insert(text, val7, false);
							((DisposableWrapper)val7).Dispose();
						}
						else
						{
							BlockTableRecord val8 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[text], (OpenMode)0);
							val6 = ((DBObject)val8).Id;
						}
						BlockReference val9 = new BlockReference(val5, val6);
						((Entity)val9).Layer = mCabos[i].Pagina;
						val4.AppendEntity((Entity)(object)val9);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)val9, true);
						BlockTableRecord val10 = (BlockTableRecord)val2.GetObject(val6, (OpenMode)0);
						try
						{
							enumerator = val10.GetEnumerator();
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.Current;
								Entity val11 = (Entity)val2.GetObject(current, (OpenMode)0);
								if (!(val11 is AttributeDefinition))
								{
									continue;
								}
								AttributeDefinition val12 = (AttributeDefinition)val11;
								AttributeReference val13 = new AttributeReference();
								val13.SetAttributeFromBlock(val12, val9.BlockTransform);
								string left = val12.Tag.ToUpper();
								if (Operators.CompareString(left, "EQTO", TextCompare: true) != 0)
								{
									if (Operators.CompareString(left, "FL", TextCompare: true) != 0)
									{
										if (Operators.CompareString(left, "COL", TextCompare: true) != 0)
										{
											if (Operators.CompareString(left, "TAG", TextCompare: true) != 0)
											{
												if (Operators.CompareString(left, "FORM", TextCompare: true) == 0)
												{
													((DBText)val13).TextString = mCabos[i].Formacao;
												}
											}
											else
											{
												((DBText)val13).TextString = mCabos[i].Tag_Cabo;
											}
										}
										else
										{
											((DBText)val13).TextString = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
										}
									}
									else
									{
										((DBText)val13).TextString = DeclaracoesGeral.Conf.PrefixoCruzInterno + DeclaracoesGeral.Conf.CaracterTerminalIndefinido + DeclaracoesGeral.Conf.SufixoCruzInterno;
									}
								}
								else
								{
									((DBText)val13).TextString = mCabos[i].sPainelDest;
								}
								((DBText)val13).AdjustAlignment(database);
								val9.AttributeCollection.AppendAttribute(val13);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val13, true);
								((Entity)val13).Draw();
							}
						}
						finally
						{
							((IDisposable)enumerator)?.Dispose();
						}
						((Entity)val9).Draw();
						Entity ent = (Entity)(object)val9;
						XDataDIEnergisa.GravarXDataCabo(ref ent, revisao, Painel, mCabos[i]);
						val9 = (BlockReference)ent;
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

	public static void carregaCabosInseridos(string revisao, int Painel, ref List<string> lCabosInseridos)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected Obj, but got Unknown
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected Obj, but got Unknown
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
					if (val4.Name.ToUpper().Contains("CABO"))
					{
						string revisao2 = "";
						int painel = 0;
						DeclaracoesInterligacao.caboAranha cabo = default;
						Entity ent = (Entity)(object)val4;
						bool flag = XDataDIEnergisa.LerXDataCabo(ref ent, ref revisao2, ref painel, ref cabo);
						val4 = (BlockReference)ent;
						if (flag && ((Operators.CompareString(revisao, revisao2, TextCompare: true) == 0) & (Painel == painel)) && !lCabosInseridos.Contains(cabo.Tag_Cabo))
						{
							lCabosInseridos.Add(cabo.Tag_Cabo);
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

	public static void AtualizaBornesJ(string revisao, int Painel, ref DeclaracoesInterligacao.borneJ[] mBornesJ)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected Obj, but got Unknown
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
			BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
			List<string> list = new List<string>();
			BlockTableRecordEnumerator enumerator = default;
			try
			{
				enumerator = val3.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ObjectId current = enumerator.Current;
					Entity ent = (Entity)val.GetObject(current, (OpenMode)0);
					Polyline val4 = (Polyline)(object)((ent is Polyline) ? ent : null);
					if (val4 != null)
					{
						string revisao2 = "";
						int painel = 0;
						string tag_cabo = "";
						string veia = "";
						string handle = "";
						if (XDataDIEnergisa.LerXDataVeia(ref ent, ref revisao2, ref painel, ref tag_cabo, ref veia, ref handle) && ((Operators.CompareString(revisao, revisao2, TextCompare: true) == 0) & (Painel == painel) & (Operators.CompareString(handle, "", TextCompare: true) != 0)) && !list.Contains(handle))
						{
							list.Add(handle);
						}
					}
				}
			}
			finally
			{
				((IDisposable)enumerator)?.Dispose();
			}
			int num = Information.UBound(mBornesJ);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (list.Contains(mBornesJ[i].Handle))
				{
					mBornesJ[i].contVeiasLigadas = 1;
				}
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

	public static void carregaCabosInseridosViaVeias(string revisao, int Painel, ref List<string> lCabosInseridos)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected Obj, but got Unknown
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
					Entity ent = (Entity)val.GetObject(current, (OpenMode)0);
					string revisao2 = "";
					int painel = 0;
					string tag_cabo = "";
					string veia = "";
					string handle = "";
					if (XDataDIEnergisa.LerXDataVeia(ref ent, ref revisao2, ref painel, ref tag_cabo, ref veia, ref handle) && ((Operators.CompareString(revisao, revisao2, TextCompare: true) == 0) & (Painel == painel)) && !lCabosInseridos.Contains(tag_cabo))
					{
						lCabosInseridos.Add(tag_cabo);
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

	public static void ApagaCabos(string revisao, int Painel)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected Obj, but got Unknown
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Expected Obj, but got Unknown
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
						if (Operators.CompareString(current.ObjectClass.DxfName.ToUpper(), "INSERT", TextCompare: true) != 0)
						{
							continue;
						}
						BlockReference val5 = (BlockReference)val2.GetObject(current, (OpenMode)0);
						if (val5.Name.ToUpper().Contains("CABO"))
						{
							string revisao2 = "";
							int painel = 0;
							DeclaracoesInterligacao.caboAranha cabo = default;
							Entity ent = (Entity)(object)val5;
							bool flag = XDataDIEnergisa.LerXDataCabo(ref ent, ref revisao2, ref painel, ref cabo);
							val5 = (BlockReference)ent;
							if (flag && ((Operators.CompareString(revisao, revisao2, TextCompare: true) == 0) & (Painel == painel)))
							{
								((DBObject)val5).UpgradeOpen();
								((DBObject)val5).Erase();
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

	public static void carregaCabosDWG(string revisao, int Painel, ref DeclaracoesInterligacao.caboAranha[] mCabos)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Obj, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected Obj, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected Obj, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected Obj, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
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
							if (val4.Name.ToUpper().Contains("CABO"))
							{
								string revisao2 = "";
								int painel = 0;
								DeclaracoesInterligacao.caboAranha cabo = default;
								Entity ent = (Entity)(object)val4;
								bool flag = XDataDIEnergisa.LerXDataCabo(ref ent, ref revisao2, ref painel, ref cabo);
								val4 = (BlockReference)ent;
								if (flag && ((Operators.CompareString(revisao, revisao2, TextCompare: true) == 0) & (Painel == painel)))
								{
									int num = Information.UBound(mCabos) + 1;
									mCabos = (DeclaracoesInterligacao.caboAranha[])Utils.CopyArray(mCabos, new DeclaracoesInterligacao.caboAranha[num + 1]);
									mCabos[num] = cabo;
									mCabos[num].mIndices = new int[1];
									mCabos[num].Pagina = ((Entity)val4).Layer;
									mCabos[num].PaginaNum = Pagina.calculaPaginaDecimal(((Entity)val4).Layer);
									mCabos[num].ptIns = val4.Position;
									mCabos[num].lVeiasUsadas = new List<string>();
									mCabos[num].lVeiasLivres = new List<string>();
									cDadosAccessInterligacao3.CarregaVeiasUsadasLivres(revisao, mCabos[num].Tag_Cabo, ref mCabos[num].lVeiasUsadas, ref mCabos[num].lVeiasLivres);
								}
							}
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
					DeclaracoesInterligacao.caboAranha caboAranha = default;
					if (Information.UBound(mCabos) >= 2)
					{
						int num2 = Information.UBound(mCabos);
						for (int i = 1; i <= num2; i++)
						{
							int num3 = Information.UBound(mCabos) - 1;
							int num4 = i;
							for (int j = num3; j >= num4; j += -1)
							{
								if (mCabos[j].PaginaNum > mCabos[j + 1].PaginaNum)
								{
									caboAranha = mCabos[j + 1];
									mCabos[j + 1] = mCabos[j];
									mCabos[j] = caboAranha;
								}
								if (mCabos[j].PaginaNum == mCabos[j + 1].PaginaNum && mCabos[j].Coluna > mCabos[j + 1].Coluna)
								{
									caboAranha = mCabos[j + 1];
									mCabos[j + 1] = mCabos[j];
									mCabos[j] = caboAranha;
								}
								if (((mCabos[j].PaginaNum == mCabos[j + 1].PaginaNum) & (mCabos[j].Coluna == mCabos[j + 1].Coluna)) && mCabos[j].ptIns.Y < mCabos[j + 1].ptIns.Y)
								{
									caboAranha = mCabos[j + 1];
									mCabos[j + 1] = mCabos[j];
									mCabos[j] = caboAranha;
								}
							}
						}
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
					cDadosAccessInterligacao3.fechaConexao();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}

	public static void relacionaCabosBornes(int Painel, ref DeclaracoesInterligacao.structureRI[] mReguas, ref DeclaracoesInterligacao.borneJ[] mBornesJ, ref DeclaracoesInterligacao.caboAranha[] mCabos)
	{
		RRPSqdp5G7emk7eXw6v2[] array = new RRPSqdp5G7emk7eXw6v2[1];
		int num = Information.UBound(mCabos);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				int num2 = Information.UBound(mReguas);
				for (int j = 1; j <= num2; j++)
				{
					int num3 = Information.UBound(mReguas[j].Bornes);
					for (int k = 1; k <= num3; k++)
					{
						int num4 = Information.UBound(mReguas[j].Bornes[k].cabos);
						for (int l = 1; l <= num4; l++)
						{
							string tag_Cabo = mReguas[j].Bornes[k].cabos[l].Tag_Cabo;
							if (Operators.CompareString(tag_Cabo, mCabos[i].Tag_Cabo, TextCompare: true) != 0)
							{
								continue;
							}
							string tag = mReguas[j].Tag;
							string nRegua = mReguas[j].NRegua;
							string borne = mReguas[j].Bornes[k].Borne;
							int veia = mReguas[j].Bornes[k].cabos[l].Veia;
							string nomeVeia = mReguas[j].Bornes[k].cabos[l].NomeVeia;
							string tagDest = mReguas[j].Bornes[k].cabos[l].TagDest;
							string nReguaDest = mReguas[j].Bornes[k].cabos[l].NReguaDest;
							string borneDest = mReguas[j].Bornes[k].cabos[l].BorneDest;
							string text = veia.ToString();
							if (Operators.CompareString(nomeVeia.Trim(), "", TextCompare: true) != 0)
							{
								text = nomeVeia.Trim();
							}
							int num5 = Information.UBound(mBornesJ);
							for (int m = 1; m <= num5; m++)
							{
								if (!((Operators.CompareString(mBornesJ[m].Tag, tag, TextCompare: true) == 0) & (Operators.CompareString(mBornesJ[m].NRegua, nRegua, TextCompare: true) == 0) & (Operators.CompareString(mBornesJ[m].Borne, borne, TextCompare: true) == 0)))
								{
									continue;
								}
								bool flag = false;
								int num6 = Information.UBound(array);
								for (int n = 1; n <= num6; n++)
								{
									if ((Operators.CompareString(array[n].F1Jp5H24SJl, tag_Cabo, TextCompare: true) == 0) & (array[n].gwyp5kMUNv1 == veia))
									{
										flag = true;
									}
								}
								if (!flag)
								{
									int num7 = Information.UBound(mCabos[i].mIndices) + 1;
									ref int[] mIndices = ref mCabos[i].mIndices;
									mIndices = (int[])Utils.CopyArray(mIndices, new int[num7 + 1]);
									mCabos[i].mIndices[num7] = m;
									ref string[] mVeias = ref mCabos[i].mVeias;
									mVeias = (string[])Utils.CopyArray(mVeias, new string[num7 + 1]);
									mCabos[i].mVeias[num7] = text;
									ref DeclaracoesInterligacao.borneDestino[] mDestinos = ref mCabos[i].mDestinos;
									mDestinos = (DeclaracoesInterligacao.borneDestino[])Utils.CopyArray(mDestinos, new DeclaracoesInterligacao.borneDestino[num7 + 1]);
									mCabos[i].mDestinos[num7].tagDest = tagDest;
									mCabos[i].mDestinos[num7].nReguaDest = nReguaDest;
									mCabos[i].mDestinos[num7].borneDest = borneDest;
									array = (RRPSqdp5G7emk7eXw6v2[])Utils.CopyArray(array, new RRPSqdp5G7emk7eXw6v2[Information.UBound(array) + 1 + 1]);
									array[Information.UBound(array)].F1Jp5H24SJl = tag_Cabo;
									array[Information.UBound(array)].gwyp5kMUNv1 = veia;
									break;
								}
							}
						}
					}
				}
			}
		}
	}

	public static void verificaErro(DeclaracoesInterligacao.caboAranha[] mCabos)
	{
		List<string> list = new List<string>();
		int num = Information.UBound(mCabos);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				if (mCabos[i].mIndices.Length - 1 < mCabos[i].lVeiasUsadas.Count)
				{
					list.Add(mCabos[i].Tag_Cabo);
				}
			}
			if (list.Count <= 0)
			{
				return;
			}
			string text = "";
			list.Sort();
			foreach (string item in list)
			{
				text = text + "\r\n" + item;
			}
			Interaction.MsgBox(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1447], text), MsgBoxStyle.Information);
		}
	}

	public static void insereVeias(string revisao, int Painel, ref DeclaracoesInterligacao.borneJ[] mBornesJ, ref DeclaracoesInterligacao.caboAranha[] mCabos, ref DeclaracoesInterligacao.cruzamentoCaboAranha[] mInfoVeias, List<string> lCabosInseridos)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_049a: Unknown result type (might be due to invalid IL or missing references)
		//IL_049f: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d5: Expected Obj, but got Unknown
		//IL_0505: Unknown result type (might be due to invalid IL or missing references)
		//IL_052a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0550: Unknown result type (might be due to invalid IL or missing references)
		//IL_0580: Unknown result type (might be due to invalid IL or missing references)
		//IL_0587: Expected Obj, but got Unknown
		//IL_059e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d88: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d93: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d9a: Expected Obj, but got Unknown
		//IL_0d9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0da1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b1a: Expected Obj, but got Unknown
		//IL_0b36: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd0: Expected Obj, but got Unknown
		//IL_0e00: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e25: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e82: Expected Obj, but got Unknown
		//IL_0e84: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e96: Expected Obj, but got Unknown
		//IL_0b5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b60: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b62: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b69: Expected Obj, but got Unknown
		//IL_0b82: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b98: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba7: Expected Obj, but got Unknown
		//IL_112a: Unknown result type (might be due to invalid IL or missing references)
		//IL_112f: Unknown result type (might be due to invalid IL or missing references)
		//IL_116b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1170: Unknown result type (might be due to invalid IL or missing references)
		//IL_1099: Unknown result type (might be due to invalid IL or missing references)
		//IL_109e: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_117e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eb3: Unknown result type (might be due to invalid IL or missing references)
		//IL_069a: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a1: Expected Obj, but got Unknown
		//IL_0eb5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ebc: Expected Obj, but got Unknown
		//IL_06fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0702: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bbc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bcb: Expected Obj, but got Unknown
		//IL_1349: Unknown result type (might be due to invalid IL or missing references)
		//IL_134e: Unknown result type (might be due to invalid IL or missing references)
		//IL_13ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_13bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be0: Expected Obj, but got Unknown
		//IL_0be0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be7: Expected Obj, but got Unknown
		//IL_0bed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c08: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c69: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c70: Expected Obj, but got Unknown
		//IL_0d14: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d19: Unknown result type (might be due to invalid IL or missing references)
		//IL_13fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1401: Unknown result type (might be due to invalid IL or missing references)
		//IL_1425: Unknown result type (might be due to invalid IL or missing references)
		//IL_142a: Unknown result type (might be due to invalid IL or missing references)
		//IL_13cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_13d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_142e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1430: Unknown result type (might be due to invalid IL or missing references)
		//IL_1582: Unknown result type (might be due to invalid IL or missing references)
		//IL_1587: Unknown result type (might be due to invalid IL or missing references)
		//IL_0970: Unknown result type (might be due to invalid IL or missing references)
		//IL_0995: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_09df: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a04: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a34: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a63: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6a: Expected Obj, but got Unknown
		//IL_0a6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a77: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a7e: Expected Obj, but got Unknown
		//IL_0f9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_147a: Unknown result type (might be due to invalid IL or missing references)
		//IL_147f: Unknown result type (might be due to invalid IL or missing references)
		//IL_14ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_14b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1441: Unknown result type (might be due to invalid IL or missing references)
		//IL_1446: Unknown result type (might be due to invalid IL or missing references)
		//IL_138d: Unknown result type (might be due to invalid IL or missing references)
		//IL_138f: Unknown result type (might be due to invalid IL or missing references)
		//IL_15bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_15c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_15e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_15ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_1598: Unknown result type (might be due to invalid IL or missing references)
		//IL_159d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1607: Unknown result type (might be due to invalid IL or missing references)
		//IL_160c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0782: Unknown result type (might be due to invalid IL or missing references)
		//IL_0787: Unknown result type (might be due to invalid IL or missing references)
		//IL_1285: Unknown result type (might be due to invalid IL or missing references)
		//IL_128a: Unknown result type (might be due to invalid IL or missing references)
		//IL_14ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_14d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_14f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_14fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_13a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_13a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_165d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1662: Unknown result type (might be due to invalid IL or missing references)
		//IL_1690: Unknown result type (might be due to invalid IL or missing references)
		//IL_1695: Unknown result type (might be due to invalid IL or missing references)
		//IL_1545: Unknown result type (might be due to invalid IL or missing references)
		//IL_154a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0789: Unknown result type (might be due to invalid IL or missing references)
		//IL_0790: Expected Obj, but got Unknown
		//IL_07c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1936: Unknown result type (might be due to invalid IL or missing references)
		//IL_193b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1793: Unknown result type (might be due to invalid IL or missing references)
		//IL_1798: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ff8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1003: Unknown result type (might be due to invalid IL or missing references)
		//IL_1033: Unknown result type (might be due to invalid IL or missing references)
		//IL_103a: Expected Obj, but got Unknown
		//IL_12e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_12e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_16b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_16b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_162f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1634: Unknown result type (might be due to invalid IL or missing references)
		//IL_16d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_16d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_16fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1702: Unknown result type (might be due to invalid IL or missing references)
		//IL_155e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1563: Unknown result type (might be due to invalid IL or missing references)
		//IL_1963: Unknown result type (might be due to invalid IL or missing references)
		//IL_1968: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0822: Unknown result type (might be due to invalid IL or missing references)
		//IL_0829: Expected Obj, but got Unknown
		//IL_0830: Unknown result type (might be due to invalid IL or missing references)
		//IL_0837: Expected Obj, but got Unknown
		//IL_0857: Unknown result type (might be due to invalid IL or missing references)
		//IL_17cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_17d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_17f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_17fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_17a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_17ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_1822: Unknown result type (might be due to invalid IL or missing references)
		//IL_1827: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0903: Unknown result type (might be due to invalid IL or missing references)
		//IL_0917: Unknown result type (might be due to invalid IL or missing references)
		//IL_0944: Unknown result type (might be due to invalid IL or missing references)
		//IL_094b: Expected Obj, but got Unknown
		//IL_1878: Unknown result type (might be due to invalid IL or missing references)
		//IL_187d: Unknown result type (might be due to invalid IL or missing references)
		//IL_18ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_18b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1756: Unknown result type (might be due to invalid IL or missing references)
		//IL_175b: Unknown result type (might be due to invalid IL or missing references)
		//IL_18cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_18d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_184a: Unknown result type (might be due to invalid IL or missing references)
		//IL_184f: Unknown result type (might be due to invalid IL or missing references)
		//IL_18ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_18f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1918: Unknown result type (might be due to invalid IL or missing references)
		//IL_191d: Unknown result type (might be due to invalid IL or missing references)
		//IL_176f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1774: Unknown result type (might be due to invalid IL or missing references)
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
						double num = 5.0;
						int num2 = Information.UBound(mCabos);
						double num10 = default;
						BlockTableRecordEnumerator enumerator = default;
						Point2d val18 = default;
						Point2d val19 = default;
						int num14 = default;
						Point3d alignmentPoint = default;
						Point2d val26 = default;
						Point2d val27 = default;
						Point2d val28 = default;
						Point2d ptInsTerm = default;
						Point3d alignmentPoint2 = default;
						for (int i = 1; i <= num2; i++)
						{
							if (lCabosInseridos.Contains(mCabos[i].Tag_Cabo))
							{
								continue;
							}
							string tag_Cabo = mCabos[i].Tag_Cabo;
							double num3 = 0.0;
							double num4 = 1000.0;
							double num5 = 0.0;
							object[,] array = new object[5, 1];
							int num6 = 0;
							int num7 = Information.UBound(mCabos[i].mIndices);
							for (int j = 1; j <= num7; j++)
							{
								int num8 = mCabos[i].mIndices[j];
								DeclaracoesInterligacao.borneJ borneJ = mBornesJ[num8];
								string text = mCabos[i].mVeias[j];
								string tagDest = mCabos[i].mDestinos[j].tagDest;
								string nReguaDest = mCabos[i].mDestinos[j].nReguaDest;
								string borneDest = mCabos[i].mDestinos[j].borneDest;
								double num9 = 0.0;
								if (borneJ.contVeiasLigadas == 1)
								{
									if (borneJ.TipoBorne != 0)
									{
										if (borneJ.TipoBorne == 1)
										{
											num9 = 5.0;
										}
									}
									else
									{
										num9 = 2.5;
									}
								}
								new Point2d(mCabos[i].ptIns.X, mCabos[i].ptIns.Y);
								Point2d val5 = new Point2d(borneJ.ptInsTerm.X, borneJ.ptInsTerm.Y - num9);
								if (Operators.CompareString(mCabos[i].Pagina, borneJ.Pagina, TextCompare: true) == 0 && (((mCabos[i].Coluna == 1) & (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0) & (borneJ.Posicao == 1)) | ((mCabos[i].Coluna == 2) & (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0) & (borneJ.Posicao == 3))))
								{
									if (val5.Y > num3)
									{
										num3 = val5.Y;
									}
									if (val5.Y < num4)
									{
										num4 = val5.Y;
									}
									num10 = val5.X;
									num6 = borneJ.Posicao;
									num5 = val5.X;
									int num11 = Information.UBound(array, 2) + 1;
									array = (object[,])Utils.CopyArray(array, new object[5, num11 + 1]);
									array[0, num11] = num8;
									array[1, num11] = text;
									array[2, num11] = tagDest;
									array[3, num11] = nReguaDest;
									array[4, num11] = borneDest;
								}
							}
							if (mCabos[i].ptIns.Y > num3)
							{
								num3 = mCabos[i].ptIns.Y;
							}
							if (mCabos[i].ptIns.Y < num4)
							{
								num4 = mCabos[i].ptIns.Y;
							}
							if (Information.UBound(array, 2) <= 0)
							{
								continue;
							}
							do
							{
								if (((mCabos[i].Coluna == 1) & (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0) & (num6 == 1)) | ((mCabos[i].Coluna == 2) & (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0) & (num6 == 3)))
								{
									num10 += num;
									if (num10 - num5 < 40.0)
									{
										num10 += 40.0 - (num10 - num5);
									}
								}
							}
							while (dEop2RxAm0(num10, num3, num4, mCabos[i].Pagina, revisao, Painel));
							Point2d val6 = new Point2d(num10, mCabos[i].ptIns.Y);
							Point2d val7 = new Point2d(mCabos[i].ptIns.X, mCabos[i].ptIns.Y);
							Polyline val8 = new Polyline();
							((Entity)val8).SetDatabaseDefaults();
							((Entity)val8).ColorIndex = 7;
							((Entity)val8).Layer = mCabos[i].Pagina;
							((Entity)val8).LineWeight = (LineWeight)9;
							val8.AddVertexAt(0, val6, 0.0, 0.0, 0.0);
							val8.AddVertexAt(1, val7, 0.0, 0.0, 0.0);
							val4.AppendEntity((Entity)(object)val8);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
							Entity ent = (Entity)(object)val8;
							XDataDIEnergisa.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, "", "");
							val8 = (Polyline)ent;
							Hatch val9 = WNNp3iiHqr(new Point3d(val6.X, val6.Y, 0.0), mCabos[i].Pagina);
							try
							{
								ent = (Entity)(object)val9;
								XDataDIEnergisa.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, "", "");
							}
							finally
							{
								((IDisposable)val9)?.Dispose();
							}
							int count = mCabos[i].lVeiasUsadas.Count;
							int num12 = Information.UBound(array, 2);
							if (count > num12)
							{
								string text2 = "";
								if ((num6 == 1) | (num6 == 3))
								{
									text2 = "VeiaSaiDireita";
								}
								ObjectId val10 = ObjectId.Null;
								string text3 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Interligação\\Energisa\\" + text2 + ".dwg";
								if (!((SymbolTable)val3).Has(text2))
								{
									Database val11 = new Database(false, true);
									val11.ReadDwgFile(text3, FileShare.Read, true, "");
									DeclaracoesGeral.bAnularEventos = true;
									val10 = database.Insert(text2, val11, false);
									((DisposableWrapper)val11).Dispose();
								}
								else
								{
									BlockTableRecord val12 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[text2], (OpenMode)0);
									val10 = ((DBObject)val12).Id;
								}
								BlockReference val13 = new BlockReference(new Point3d(val6.X, val6.Y, 0.0), val10);
								((Entity)val13).Layer = mCabos[i].Pagina;
								val4.AppendEntity((Entity)(object)val13);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val13, true);
								BlockTableRecord val14 = (BlockTableRecord)val2.GetObject(val10, (OpenMode)0);
								try
								{
									enumerator = val14.GetEnumerator();
									while (enumerator.MoveNext())
									{
										ObjectId current = enumerator.Current;
										Entity val15 = (Entity)val2.GetObject(current, (OpenMode)0);
										if (val15 is AttributeDefinition)
										{
											AttributeDefinition val16 = (AttributeDefinition)val15;
											AttributeReference val17 = new AttributeReference();
											val17.SetAttributeFromBlock(val16, val13.BlockTransform);
											((DBText)val17).AdjustAlignment(database);
											val13.AttributeCollection.AppendAttribute(val17);
											DeclaracoesGeral.bAnularEventos = true;
											val2.AddNewlyCreatedDBObject((DBObject)(object)val17, true);
											((Entity)val17).Draw();
										}
									}
								}
								finally
								{
									((IDisposable)enumerator)?.Dispose();
								}
								((Entity)val13).Draw();
								ent = (Entity)(object)val13;
								XDataDIEnergisa.GravarXDataVeia(ref ent, revisao, Painel, mCabos[i].Tag_Cabo, "", "");
								val13 = (BlockReference)ent;
								mInfoVeias = (DeclaracoesInterligacao.cruzamentoCaboAranha[])Utils.CopyArray(mInfoVeias, new DeclaracoesInterligacao.cruzamentoCaboAranha[Information.UBound(mInfoVeias) + 1 + 1]);
								mInfoVeias[Information.UBound(mInfoVeias)].mBornes = new DeclaracoesInterligacao.borneCruzamentoCaboAranha[1];
								mInfoVeias[Information.UBound(mInfoVeias)].tag_Cabo = mCabos[i].Tag_Cabo;
								mInfoVeias[Information.UBound(mInfoVeias)].coluna = mCabos[i].Coluna;
								mInfoVeias[Information.UBound(mInfoVeias)].mBornes[0].ID = ((DBObject)val13).ObjectId;
								mInfoVeias[Information.UBound(mInfoVeias)].mBornes[0].rb = "";
								mInfoVeias[Information.UBound(mInfoVeias)].mBornes[0].pagina = mCabos[i].Pagina;
							}
							if (mCabos[i].lVeiasLivres.Count > 0)
							{
								if (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0)
								{
									if (mCabos[i].bAterrar)
									{
										val18 = new Point2d(mCabos[i].ptIns.X - 9.0 + 0.85, mCabos[i].ptIns.Y + 1.8);
										val19 = new Point2d(mCabos[i].ptIns.X - 9.0 - 0.85, mCabos[i].ptIns.Y - 1.8);
									}
									else
									{
										val18 = new Point2d(mCabos[i].ptIns.X - 9.0, mCabos[i].ptIns.Y + 1.8);
										val19 = new Point2d(mCabos[i].ptIns.X - 9.0, mCabos[i].ptIns.Y - 1.8);
									}
								}
								Polyline val20 = new Polyline();
								((Entity)val20).SetDatabaseDefaults();
								((Entity)val20).ColorIndex = 7;
								((Entity)val20).Layer = mCabos[i].Pagina;
								((Entity)val20).LineWeight = (LineWeight)30;
								val20.AddVertexAt(0, val18, 0.0, 0.0, 0.0);
								val20.AddVertexAt(1, val19, 0.0, 0.0, 0.0);
								val4.AppendEntity((Entity)(object)val20);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val20, true);
								ent = (Entity)(object)val20;
								XDataDIEnergisa.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, "", "");
								val20 = (Polyline)ent;
								TextStyleTable val21 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)0);
								ObjectId textStyleId = (((SymbolTable)val21).Has("Romans") ? ((SymbolTable)val21)["Romans"] : ((SymbolTable)val21)["Standard"]);
								DBText val22 = new DBText();
								bool flag = true;
								bool flag2 = true;
								int num13 = 0;
								string left = "";
								if (mCabos[i].lVeiasLivres.Count > 2)
								{
									foreach (string lVeiasLivre in mCabos[i].lVeiasLivres)
									{
										if (Versioned.IsNumeric(lVeiasLivre))
										{
											if (!flag)
											{
												num14 = Conversions.ToInteger(lVeiasLivre);
												num13++;
												if (num14 != num13)
												{
													flag2 = false;
													break;
												}
											}
											else
											{
												flag = false;
												left = lVeiasLivre;
												num13 = Conversions.ToInteger(lVeiasLivre);
											}
											continue;
										}
										flag2 = false;
										break;
									}
								}
								else
								{
									flag2 = false;
								}
								if (!flag2)
								{
									flag = true;
									foreach (string lVeiasLivre2 in mCabos[i].lVeiasLivres)
									{
										DBText val23;
										if (!flag)
										{
											(val23 = val22).TextString = val23.TextString + ",";
										}
										(val23 = val22).TextString = val23.TextString + lVeiasLivre2;
										flag = false;
									}
								}
								else
								{
									val22.TextString = Conversions.ToString(Operators.AddObject(Operators.AddObject(left, DeclaracoesGeral.mMensagem[1, 1446]), num14.ToString()));
								}
								((Entity)val22).ColorIndex = 7;
								((Entity)val22).Layer = mCabos[i].Pagina;
								val22.Height = 1.8;
								val22.TextStyleId = textStyleId;
								val22.WidthFactor = 0.9;
								if (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) != 0)
								{
									if (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0)
									{
										alignmentPoint = new Point3d(mCabos[i].ptIns.X - 10.0, mCabos[i].ptIns.Y + 1.8, 0.0);
										val22.HorizontalMode = (TextHorizontalMode)2;
										val22.VerticalMode = (TextVerticalMode)2;
									}
								}
								else
								{
									alignmentPoint = new Point3d(mCabos[i].ptIns.X + 10.5, mCabos[i].ptIns.Y + 1.8, 0.0);
									val22.HorizontalMode = (TextHorizontalMode)0;
									val22.VerticalMode = (TextVerticalMode)2;
								}
								val22.AlignmentPoint = alignmentPoint;
								val4.AppendEntity((Entity)(object)val22);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val22, true);
								ent = (Entity)(object)val22;
								XDataDIEnergisa.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, "", "");
								val22 = (DBText)ent;
							}
							int num15 = Information.UBound(array, 2);
							for (int k = 1; k <= num15; k++)
							{
								int num16 = Conversions.ToInteger(array[0, k]);
								string text4 = Conversions.ToString(array[1, k]);
								string text5 = Conversions.ToString(array[2, k]);
								string text6 = Conversions.ToString(array[3, k]);
								string text7 = Conversions.ToString(array[4, k]);
								DeclaracoesInterligacao.borneJ borneJ2 = mBornesJ[num16];
								Polyline val24 = new Polyline();
								((Entity)val24).SetDatabaseDefaults();
								((Entity)val24).ColorIndex = 7;
								((Entity)val24).Layer = mCabos[i].Pagina;
								((Entity)val24).LineWeight = (LineWeight)9;
								if (borneJ2.contVeiasLigadas == 1 && borneJ2.TipoBorne != 0 && borneJ2.TipoBorne == 1)
								{
									mBornesJ[num16].ptInsTerm = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y - 5.0);
									borneJ2 = mBornesJ[num16];
								}
								double num17 = 0.0;
								Point2d val25 = new Point2d(num10, mCabos[i].ptIns.Y);
								if (mCabos[i].ptIns.Y != borneJ2.ptInsTerm.Y)
								{
									if (!(mCabos[i].ptIns.Y > borneJ2.ptInsTerm.Y))
									{
										if (mCabos[i].ptIns.Y < borneJ2.ptInsTerm.Y)
										{
											if (borneJ2.contVeiasLigadas != 0)
											{
												if (borneJ2.TipoBorne != 0)
												{
													if (borneJ2.TipoBorne == 1)
													{
														val26 = new Point2d(num10, borneJ2.ptInsTerm.Y - 2.5);
														if ((num6 == 1) | (num6 == 3))
														{
															val27 = new Point2d(num10 - 2.5, borneJ2.ptInsTerm.Y);
															val28 = new Point2d(borneJ2.ptInsTerm.X + 1.5, borneJ2.ptInsTerm.Y);
															num17 = 0.42;
														}
														ptInsTerm = borneJ2.ptInsTerm;
													}
												}
												else
												{
													val26 = new Point2d(num10, borneJ2.ptInsTerm.Y - 5.0);
													if ((num6 == 1) | (num6 == 3))
													{
														val27 = new Point2d(num10 - 2.5, borneJ2.ptInsTerm.Y - 2.5);
														val28 = new Point2d(borneJ2.ptInsTerm.X + 1.5, borneJ2.ptInsTerm.Y - 2.5);
														num17 = 0.42;
													}
													if (val26.Y == val27.Y)
													{
														val26 = new Point2d(num10, val25.Y);
													}
													ptInsTerm = borneJ2.ptInsTerm;
												}
											}
											else
											{
												val26 = new Point2d(num10, borneJ2.ptInsTerm.Y - 2.5);
												if ((num6 == 1) | (num6 == 3))
												{
													val27 = new Point2d(num10 - 2.5, borneJ2.ptInsTerm.Y);
													val28 = new Point2d(borneJ2.ptInsTerm.X + 1.5, borneJ2.ptInsTerm.Y);
													num17 = 0.42;
												}
												ptInsTerm = borneJ2.ptInsTerm;
											}
										}
									}
									else if (borneJ2.contVeiasLigadas != 0)
									{
										if (borneJ2.TipoBorne != 0)
										{
											if (borneJ2.TipoBorne == 1)
											{
												val26 = new Point2d(num10, borneJ2.ptInsTerm.Y + 2.5);
												if ((num6 == 1) | (num6 == 3))
												{
													val27 = new Point2d(num10 - 2.5, borneJ2.ptInsTerm.Y);
													val28 = new Point2d(borneJ2.ptInsTerm.X + 1.5, borneJ2.ptInsTerm.Y);
													num17 = -0.42;
												}
												ptInsTerm = borneJ2.ptInsTerm;
											}
										}
										else
										{
											val26 = new Point2d(num10, borneJ2.ptInsTerm.Y);
											if ((num6 == 1) | (num6 == 3))
											{
												val27 = new Point2d(num10 - 2.5, borneJ2.ptInsTerm.Y - 2.5);
												val28 = new Point2d(borneJ2.ptInsTerm.X + 1.5, borneJ2.ptInsTerm.Y - 2.5);
												num17 = -0.42;
											}
											if (val26.Y == val27.Y)
											{
												val26 = new Point2d(num10, val25.Y);
											}
											ptInsTerm = borneJ2.ptInsTerm;
										}
									}
									else
									{
										val26 = new Point2d(num10, borneJ2.ptInsTerm.Y + 2.5);
										if ((num6 == 1) | (num6 == 3))
										{
											val27 = new Point2d(num10 - 2.5, borneJ2.ptInsTerm.Y);
											val28 = new Point2d(borneJ2.ptInsTerm.X + 1.5, borneJ2.ptInsTerm.Y);
											num17 = -0.42;
										}
										ptInsTerm = borneJ2.ptInsTerm;
									}
								}
								else if (borneJ2.contVeiasLigadas != 0)
								{
									if (borneJ2.TipoBorne != 0)
									{
										if (borneJ2.TipoBorne == 1)
										{
											val26 = val25;
											if ((num6 == 1) | (num6 == 3))
											{
												val27 = new Point2d(num10 - 2.5, borneJ2.ptInsTerm.Y);
												val28 = new Point2d(borneJ2.ptInsTerm.X + 1.5, borneJ2.ptInsTerm.Y);
											}
											ptInsTerm = borneJ2.ptInsTerm;
											num17 = 0.0;
										}
									}
									else
									{
										val26 = val25;
										if ((num6 == 1) | (num6 == 3))
										{
											val27 = new Point2d(num10 - 2.5, borneJ2.ptInsTerm.Y - 2.5);
											val28 = new Point2d(borneJ2.ptInsTerm.X + 1.5, borneJ2.ptInsTerm.Y - 2.5);
										}
										ptInsTerm = borneJ2.ptInsTerm;
										num17 = -0.42;
									}
								}
								else
								{
									val26 = val25;
									if ((num6 == 1) | (num6 == 3))
									{
										val27 = new Point2d(num10 - 2.5, borneJ2.ptInsTerm.Y);
										val28 = new Point2d(borneJ2.ptInsTerm.X + 1.5, borneJ2.ptInsTerm.Y);
									}
									ptInsTerm = borneJ2.ptInsTerm;
									num17 = 0.0;
								}
								val24.AddVertexAt(0, val25, 0.0, 0.0, 0.0);
								val24.AddVertexAt(1, val26, 0.0, 0.0, 0.0);
								val24.AddVertexAt(2, val27, 0.0, 0.0, 0.0);
								val24.AddVertexAt(3, val28, 0.0, 0.0, 0.0);
								val24.AddVertexAt(4, ptInsTerm, 0.0, 0.0, 0.0);
								val24.SetBulgeAt(1, num17);
								val4.AppendEntity((Entity)(object)val24);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val24, true);
								ent = (Entity)(object)val24;
								XDataDIEnergisa.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, text4, borneJ2.Handle);
								val24 = (Polyline)ent;
								TextStyleTable val29 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)0);
								ObjectId textStyleId2 = (((SymbolTable)val29).Has("Romans") ? ((SymbolTable)val29)["Romans"] : ((SymbolTable)val29)["Standard"]);
								DBText val30 = new DBText();
								val30.TextString = text4;
								((Entity)val30).ColorIndex = 7;
								((Entity)val30).Layer = ((Entity)val24).Layer;
								val30.Height = 1.6;
								val30.TextStyleId = textStyleId2;
								val30.WidthFactor = 0.9;
								if ((num6 == 1) | (num6 == 3))
								{
									alignmentPoint2 = new Point3d(val27.X, val27.Y + 1.1, 0.0);
									val30.HorizontalMode = (TextHorizontalMode)2;
									val30.VerticalMode = (TextVerticalMode)2;
								}
								val30.AlignmentPoint = alignmentPoint2;
								val4.AppendEntity((Entity)(object)val30);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val30, true);
								ent = (Entity)(object)val30;
								XDataDIEnergisa.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, text4, "");
								val30 = (DBText)ent;
								string text8 = "";
								DBText val31 = new DBText();
								((Entity)val31).Layer = ((Entity)val24).Layer;
								val31.Height = 1.6;
								val31.TextStyleId = textStyleId2;
								val31.WidthFactor = 0.9;
								val31.Rotation = 0.0;
								((Entity)val31).ColorIndex = 7;
								val31.Oblique = Math.PI / 12.0;
								text8 = text5;
								if (Operators.CompareString(text6, "", TextCompare: true) != 0)
								{
									text8 = text6;
								}
								text8 = text8 + "-" + text7;
								Point3d alignmentPoint3 = new Point3d(val28.X + 8.0, val28.Y + 1.1, 0.0);
								val31.HorizontalMode = (TextHorizontalMode)0;
								val31.VerticalMode = (TextVerticalMode)2;
								val31.AlignmentPoint = alignmentPoint3;
								val31.TextString = text8;
								val4.AppendEntity((Entity)(object)val31);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val31, true);
								ent = (Entity)(object)val31;
								XDataDIEnergisa.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, text4, "");
								val31 = (DBText)ent;
								mBornesJ[num16].contVeiasLigadas++;
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
				((IDisposable)val)?.Dispose();
			}
		}
	}

	public static void insereVeias2(string revisao, int Painel, ref DeclaracoesInterligacao.borneJ[] mBornesJ, ref DeclaracoesInterligacao.caboAranha[] mCabos, ref DeclaracoesInterligacao.cruzamentoCaboAranha[] mInfoVeias, List<string> lCabosInseridos)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0736: Unknown result type (might be due to invalid IL or missing references)
		//IL_0757: Unknown result type (might be due to invalid IL or missing references)
		//IL_075c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0819: Unknown result type (might be due to invalid IL or missing references)
		//IL_081e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0837: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c25: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c69: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c71: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c78: Expected Obj, but got Unknown
		//IL_08a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d12: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c96: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a28: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a2f: Expected Obj, but got Unknown
		//IL_0a31: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a36: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_08dd: Expected Obj, but got Unknown
		//IL_08f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ca5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cac: Expected Obj, but got Unknown
		//IL_091e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0923: Unknown result type (might be due to invalid IL or missing references)
		//IL_0925: Unknown result type (might be due to invalid IL or missing references)
		//IL_092c: Expected Obj, but got Unknown
		//IL_0945: Unknown result type (might be due to invalid IL or missing references)
		//IL_095b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0963: Unknown result type (might be due to invalid IL or missing references)
		//IL_096a: Expected Obj, but got Unknown
		//IL_0ab7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0abc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0abf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ace: Expected Obj, but got Unknown
		//IL_0adc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae3: Expected Obj, but got Unknown
		//IL_0ae3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aea: Expected Obj, but got Unknown
		//IL_0af0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba6: Expected Obj, but got Unknown
		//IL_0b2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c66: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e66: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e6d: Expected Obj, but got Unknown
		//IL_0e6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e74: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c99: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca0: Expected Obj, but got Unknown
		//IL_0cbc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cef: Expected Obj, but got Unknown
		//IL_0d08: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d26: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d2d: Expected Obj, but got Unknown
		//IL_1478: Unknown result type (might be due to invalid IL or missing references)
		//IL_147d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ff8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fff: Expected Obj, but got Unknown
		//IL_1043: Unknown result type (might be due to invalid IL or missing references)
		//IL_1048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d42: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d51: Expected Obj, but got Unknown
		//IL_0d5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d66: Expected Obj, but got Unknown
		//IL_0d66: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d6d: Expected Obj, but got Unknown
		//IL_0d73: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0def: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df6: Expected Obj, but got Unknown
		//IL_154f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1554: Unknown result type (might be due to invalid IL or missing references)
		//IL_15cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_15ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_160e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1613: Unknown result type (might be due to invalid IL or missing references)
		//IL_1637: Unknown result type (might be due to invalid IL or missing references)
		//IL_163c: Unknown result type (might be due to invalid IL or missing references)
		//IL_15df: Unknown result type (might be due to invalid IL or missing references)
		//IL_15e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1640: Unknown result type (might be due to invalid IL or missing references)
		//IL_1642: Unknown result type (might be due to invalid IL or missing references)
		//IL_1794: Unknown result type (might be due to invalid IL or missing references)
		//IL_1799: Unknown result type (might be due to invalid IL or missing references)
		//IL_128f: Unknown result type (might be due to invalid IL or missing references)
		//IL_12b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_12d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_12fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1323: Unknown result type (might be due to invalid IL or missing references)
		//IL_1353: Unknown result type (might be due to invalid IL or missing references)
		//IL_1382: Unknown result type (might be due to invalid IL or missing references)
		//IL_1389: Expected Obj, but got Unknown
		//IL_138b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1396: Unknown result type (might be due to invalid IL or missing references)
		//IL_139d: Expected Obj, but got Unknown
		//IL_168c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1691: Unknown result type (might be due to invalid IL or missing references)
		//IL_16bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_16c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1653: Unknown result type (might be due to invalid IL or missing references)
		//IL_1658: Unknown result type (might be due to invalid IL or missing references)
		//IL_159f: Unknown result type (might be due to invalid IL or missing references)
		//IL_15a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_17ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_17d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_17f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_17fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_17aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_17af: Unknown result type (might be due to invalid IL or missing references)
		//IL_1819: Unknown result type (might be due to invalid IL or missing references)
		//IL_181e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1095: Unknown result type (might be due to invalid IL or missing references)
		//IL_109a: Unknown result type (might be due to invalid IL or missing references)
		//IL_16e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_16e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1709: Unknown result type (might be due to invalid IL or missing references)
		//IL_170e: Unknown result type (might be due to invalid IL or missing references)
		//IL_15b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_15ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_186f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1874: Unknown result type (might be due to invalid IL or missing references)
		//IL_18a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_18a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1757: Unknown result type (might be due to invalid IL or missing references)
		//IL_175c: Unknown result type (might be due to invalid IL or missing references)
		//IL_109c: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a3: Expected Obj, but got Unknown
		//IL_10d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b48: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_19a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_19aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f21: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f26: Unknown result type (might be due to invalid IL or missing references)
		//IL_18c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_18c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1841: Unknown result type (might be due to invalid IL or missing references)
		//IL_1846: Unknown result type (might be due to invalid IL or missing references)
		//IL_18e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_18eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_190f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1914: Unknown result type (might be due to invalid IL or missing references)
		//IL_1770: Unknown result type (might be due to invalid IL or missing references)
		//IL_1775: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b75: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_10fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1108: Unknown result type (might be due to invalid IL or missing references)
		//IL_1135: Unknown result type (might be due to invalid IL or missing references)
		//IL_113c: Expected Obj, but got Unknown
		//IL_1143: Unknown result type (might be due to invalid IL or missing references)
		//IL_114a: Expected Obj, but got Unknown
		//IL_116a: Unknown result type (might be due to invalid IL or missing references)
		//IL_19df: Unknown result type (might be due to invalid IL or missing references)
		//IL_19e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a08: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_19bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_19c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a34: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a39: Unknown result type (might be due to invalid IL or missing references)
		//IL_11fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1202: Unknown result type (might be due to invalid IL or missing references)
		//IL_1216: Unknown result type (might be due to invalid IL or missing references)
		//IL_122a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1257: Unknown result type (might be due to invalid IL or missing references)
		//IL_125e: Expected Obj, but got Unknown
		//IL_1a8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1abd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ac2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1968: Unknown result type (might be due to invalid IL or missing references)
		//IL_196d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1add: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ae2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a61: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b01: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b06: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1981: Unknown result type (might be due to invalid IL or missing references)
		//IL_1986: Unknown result type (might be due to invalid IL or missing references)
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
						double num = 5.0;
						int num2 = Information.UBound(mCabos);
						int num9 = default;
						double num22 = default;
						BlockTableRecordEnumerator enumerator = default;
						BlockTableRecordEnumerator enumerator2 = default;
						Point2d val23 = default;
						Point2d val24 = default;
						Point2d val25 = default;
						Point2d ptInsTerm = default;
						Point3d alignmentPoint = default;
						for (int i = 1; i <= num2; i++)
						{
							if (lCabosInseridos.Contains(mCabos[i].Tag_Cabo))
							{
								continue;
							}
							string tag_Cabo = mCabos[i].Tag_Cabo;
							double num3 = 0.0;
							double num4 = 1000.0;
							double num5 = 0.0;
							DeclaracoesInterligacao.veiasCompl[] array = new DeclaracoesInterligacao.veiasCompl[1];
							int num6 = 0;
							int num7 = Information.UBound(mCabos[i].mIndices);
							for (int j = 1; j <= num7; j++)
							{
								int num8 = mCabos[i].mIndices[j];
								DeclaracoesInterligacao.borneJ borneJ = mBornesJ[num8];
								string veia = mCabos[i].mVeias[j];
								string tagDest = mCabos[i].mDestinos[j].tagDest;
								string nReguaDest = mCabos[i].mDestinos[j].nReguaDest;
								string borneDest = mCabos[i].mDestinos[j].borneDest;
								if (!((mCabos[i].Coluna == 1) & (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0)))
								{
									if ((mCabos[i].Coluna == 2) & (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0))
									{
										num9 = 3;
									}
								}
								else
								{
									num9 = 1;
								}
								if (Operators.CompareString(mCabos[i].Pagina, borneJ.Pagina, TextCompare: true) != 0)
								{
									int num10 = Information.UBound(array) + 1;
									array = (DeclaracoesInterligacao.veiasCompl[])Utils.CopyArray(array, new DeclaracoesInterligacao.veiasCompl[num10 + 1]);
									array[num10].Pagina = borneJ.Pagina;
									array[num10].PaginaNum = borneJ.PaginaNum;
									array[num10].Posicao = borneJ.Posicao;
									array[num10].indiceBorne = num8;
									array[num10].Veia = veia;
									array[num10].Dest.tagDest = tagDest;
									array[num10].Dest.nReguaDest = nReguaDest;
									array[num10].Dest.borneDest = borneDest;
								}
								else if (num9 != borneJ.Posicao)
								{
									int num11 = Information.UBound(array) + 1;
									array = (DeclaracoesInterligacao.veiasCompl[])Utils.CopyArray(array, new DeclaracoesInterligacao.veiasCompl[num11 + 1]);
									array[num11].Pagina = borneJ.Pagina;
									array[num11].PaginaNum = borneJ.PaginaNum;
									array[num11].Posicao = borneJ.Posicao;
									array[num11].indiceBorne = num8;
									array[num11].Veia = veia;
									array[num11].Dest.tagDest = tagDest;
									array[num11].Dest.nReguaDest = nReguaDest;
									array[num11].Dest.borneDest = borneDest;
								}
							}
							DeclaracoesInterligacao.veiasCompl veiasCompl = default;
							if (Information.UBound(array) >= 2)
							{
								int num12 = Information.UBound(array);
								for (int k = 1; k <= num12; k++)
								{
									int num13 = Information.UBound(array) - 1;
									int num14 = k;
									for (int l = num13; l >= num14; l += -1)
									{
										if (array[l].PaginaNum > array[l + 1].PaginaNum)
										{
											veiasCompl = array[l + 1];
											array[l + 1] = array[l];
											array[l] = veiasCompl;
										}
										if (array[l].PaginaNum == array[l + 1].PaginaNum && array[l].Posicao > array[l + 1].Posicao)
										{
											veiasCompl = array[l + 1];
											array[l + 1] = array[l];
											array[l] = veiasCompl;
										}
									}
								}
							}
							if (Information.UBound(array) == 0)
							{
								continue;
							}
							DeclaracoesInterligacao.limitesMatriz[] array2 = new DeclaracoesInterligacao.limitesMatriz[1];
							int inicio = 1;
							int final = 1;
							string pagina = array[1].Pagina;
							int posicao = array[1].Posicao;
							int num15 = Information.UBound(array);
							for (int m = 1; m <= num15; m++)
							{
								string pagina2 = array[m].Pagina;
								int posicao2 = array[m].Posicao;
								if (!((Operators.CompareString(pagina2, pagina, TextCompare: true) == 0) & (posicao2 == posicao)))
								{
									array2 = (DeclaracoesInterligacao.limitesMatriz[])Utils.CopyArray(array2, new DeclaracoesInterligacao.limitesMatriz[Information.UBound(array2) + 1 + 1]);
									array2[Information.UBound(array2)].inicio = inicio;
									array2[Information.UBound(array2)].final = m - 1;
									inicio = m;
									final = m;
									pagina = array[m].Pagina;
									posicao = array[m].Posicao;
								}
								else
								{
									final = m;
								}
							}
							array2 = (DeclaracoesInterligacao.limitesMatriz[])Utils.CopyArray(array2, new DeclaracoesInterligacao.limitesMatriz[Information.UBound(array2) + 1 + 1]);
							array2[Information.UBound(array2)].inicio = inicio;
							array2[Information.UBound(array2)].final = final;
							int num16 = 0;
							int num17 = Information.UBound(array2);
							for (int n = 1; n <= num17; n++)
							{
								num16++;
								inicio = array2[n].inicio;
								final = array2[n].final;
								num3 = 0.0;
								num4 = 1000.0;
								double y = mBornesJ[array[inicio].indiceBorne].ptInsTerm.Y;
								int num18 = inicio;
								int num19 = final;
								for (int num20 = num18; num20 <= num19; num20++)
								{
									DeclaracoesInterligacao.borneJ borneJ2 = mBornesJ[array[num20].indiceBorne];
									double num21 = 0.0;
									if (borneJ2.contVeiasLigadas == 1)
									{
										if (borneJ2.TipoBorne != 0)
										{
											if (borneJ2.TipoBorne == 1)
											{
												num21 = 5.0;
											}
										}
										else
										{
											num21 = 2.5;
										}
									}
									new Point2d(mCabos[i].ptIns.X, y);
									Point2d val5 = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y - num21);
									num5 = val5.X;
									if (val5.Y > num3)
									{
										num3 = val5.Y;
									}
									if (val5.Y < num4)
									{
										num4 = val5.Y;
									}
									num22 = val5.X;
									num6 = borneJ2.Posicao;
								}
								do
								{
									if ((num6 == 1) | (num6 == 3))
									{
										num22 += num;
										if (num22 - num5 < 40.0)
										{
											num22 += 40.0 - (num22 - num5);
										}
									}
								}
								while (dEop2RxAm0(num22, num3, num4, array[inicio].Pagina, revisao, Painel));
								DeclaracoesInterligacao.borneJ borneJ3 = mBornesJ[array[inicio].indiceBorne];
								Point2d val6 = new Point2d(num22, borneJ3.ptInsTerm.Y);
								Hatch val7 = WNNp3iiHqr(new Point3d(val6.X, val6.Y, 0.0), array[inicio].Pagina);
								Entity ent;
								try
								{
									ent = (Entity)(object)val7;
									XDataDIEnergisa.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, "", "");
								}
								finally
								{
									((IDisposable)val7)?.Dispose();
								}
								string text = "";
								bool flag = false;
								if (n == Information.UBound(array2))
								{
									flag = true;
								}
								if ((num6 == 1) | (num6 == 3))
								{
									text = ((!flag) ? "VeiaEntraDireita" : "VeiaEntraDireitaReta");
								}
								ObjectId val8 = ObjectId.Null;
								string text2 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Interligação\\Energisa\\" + text + ".dwg";
								if (!((SymbolTable)val3).Has(text))
								{
									Database val9 = new Database(false, true);
									val9.ReadDwgFile(text2, FileShare.Read, true, "");
									DeclaracoesGeral.bAnularEventos = true;
									val8 = database.Insert(text, val9, false);
									((DisposableWrapper)val9).Dispose();
								}
								else
								{
									BlockTableRecord val10 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[text], (OpenMode)0);
									val8 = ((DBObject)val10).Id;
								}
								BlockReference val11 = new BlockReference(new Point3d(val6.X, val6.Y, 0.0), val8);
								((Entity)val11).Layer = array[inicio].Pagina;
								val4.AppendEntity((Entity)(object)val11);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val11, true);
								BlockTableRecord val12 = (BlockTableRecord)val2.GetObject(val8, (OpenMode)0);
								string text3 = "";
								int num23 = Information.UBound(mInfoVeias);
								for (int num24 = 1; num24 <= num23; num24++)
								{
									if (Operators.CompareString(mInfoVeias[num24].tag_Cabo, mCabos[i].Tag_Cabo, TextCompare: true) == 0)
									{
										text3 = mCabos[i].Tag_Cabo + DeclaracoesGeral.Conf.SeparadorCruzamento + mInfoVeias[num24].coluna;
										if (Operators.CompareString(array[inicio].Pagina, mInfoVeias[num24].mBornes[0].pagina, TextCompare: true) != 0)
										{
											text3 = text3 + DeclaracoesGeral.Conf.PrefixoCruzInterno + mInfoVeias[num24].mBornes[0].pagina + DeclaracoesGeral.Conf.SufixoCruzInterno;
										}
										break;
									}
								}
								try
								{
									enumerator = val12.GetEnumerator();
									while (enumerator.MoveNext())
									{
										ObjectId current = enumerator.Current;
										Entity val13 = (Entity)val2.GetObject(current, (OpenMode)0);
										if (val13 is AttributeDefinition)
										{
											AttributeDefinition val14 = (AttributeDefinition)val13;
											AttributeReference val15 = new AttributeReference();
											val15.SetAttributeFromBlock(val14, val11.BlockTransform);
											string tag = val14.Tag;
											if (Operators.CompareString(tag, "CABO", TextCompare: true) != 0)
											{
												((Entity)val15).Visible = false;
											}
											else
											{
												((DBText)val15).TextString = text3;
											}
											((DBText)val15).AdjustAlignment(database);
											val11.AttributeCollection.AppendAttribute(val15);
											DeclaracoesGeral.bAnularEventos = true;
											val2.AddNewlyCreatedDBObject((DBObject)(object)val15, true);
											((Entity)val15).Draw();
										}
									}
								}
								finally
								{
									((IDisposable)enumerator)?.Dispose();
								}
								((Entity)val11).Draw();
								ent = (Entity)(object)val11;
								XDataDIEnergisa.GravarXDataVeia(ref ent, revisao, Painel, mCabos[i].Tag_Cabo, "", "");
								val11 = (BlockReference)ent;
								if (n >= Information.UBound(array2))
								{
									int num25 = Information.UBound(mInfoVeias);
									for (int num26 = 1; num26 <= num25; num26++)
									{
										if (Operators.CompareString(mInfoVeias[num26].tag_Cabo, mCabos[i].Tag_Cabo, TextCompare: true) == 0)
										{
											ref DeclaracoesInterligacao.borneCruzamentoCaboAranha[] mBornes = ref mInfoVeias[num26].mBornes;
											mBornes = (DeclaracoesInterligacao.borneCruzamentoCaboAranha[])Utils.CopyArray(mBornes, new DeclaracoesInterligacao.borneCruzamentoCaboAranha[num16 + 1]);
											string text4 = mBornesJ[array[inicio].indiceBorne].Tag;
											if (Operators.CompareString(mBornesJ[array[inicio].indiceBorne].NRegua, "", TextCompare: true) != 0)
											{
												text4 = mBornesJ[array[inicio].indiceBorne].NRegua;
											}
											string borne = mBornesJ[array[inicio].indiceBorne].Borne;
											mInfoVeias[num26].mBornes[num16].ID = ObjectId.Null;
											mInfoVeias[num26].mBornes[num16].rb = text4 + "-" + borne;
											mInfoVeias[num26].mBornes[num16].pagina = array[inicio].Pagina;
										}
									}
								}
								else
								{
									text = "";
									if (!((num6 == 1) | (num6 == 3)))
									{
										if ((num6 == 2) | (num6 == 4))
										{
											text = "VeiaSaiEsquerda";
										}
									}
									else
									{
										text = "VeiaSaiDireita";
									}
									val8 = ObjectId.Null;
									text2 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Interligação\\Energisa\\" + text + ".dwg";
									if (!((SymbolTable)val3).Has(text))
									{
										Database val16 = new Database(false, true);
										val16.ReadDwgFile(text2, FileShare.Read, true, "");
										DeclaracoesGeral.bAnularEventos = true;
										val8 = database.Insert(text, val16, false);
										((DisposableWrapper)val16).Dispose();
									}
									else
									{
										BlockTableRecord val17 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[text], (OpenMode)0);
										val8 = ((DBObject)val17).Id;
									}
									val11 = new BlockReference(new Point3d(val6.X, val6.Y, 0.0), val8);
									((Entity)val11).Layer = array[inicio].Pagina;
									val4.AppendEntity((Entity)(object)val11);
									DeclaracoesGeral.bAnularEventos = true;
									val2.AddNewlyCreatedDBObject((DBObject)(object)val11, true);
									val12 = (BlockTableRecord)val2.GetObject(val8, (OpenMode)0);
									try
									{
										enumerator2 = val12.GetEnumerator();
										while (enumerator2.MoveNext())
										{
											ObjectId current2 = enumerator2.Current;
											Entity val18 = (Entity)val2.GetObject(current2, (OpenMode)0);
											if (val18 is AttributeDefinition)
											{
												AttributeDefinition val19 = (AttributeDefinition)val18;
												AttributeReference val20 = new AttributeReference();
												val20.SetAttributeFromBlock(val19, val11.BlockTransform);
												((DBText)val20).AdjustAlignment(database);
												val11.AttributeCollection.AppendAttribute(val20);
												DeclaracoesGeral.bAnularEventos = true;
												val2.AddNewlyCreatedDBObject((DBObject)(object)val20, true);
												((Entity)val20).Draw();
											}
										}
									}
									finally
									{
										((IDisposable)enumerator2)?.Dispose();
									}
									((Entity)val11).Draw();
									ent = (Entity)(object)val11;
									XDataDIEnergisa.GravarXDataVeia(ref ent, revisao, Painel, mCabos[i].Tag_Cabo, "", "");
									val11 = (BlockReference)ent;
									int num27 = Information.UBound(mInfoVeias);
									for (int num28 = 1; num28 <= num27; num28++)
									{
										if (Operators.CompareString(mInfoVeias[num28].tag_Cabo, mCabos[i].Tag_Cabo, TextCompare: true) == 0)
										{
											ref DeclaracoesInterligacao.borneCruzamentoCaboAranha[] mBornes2 = ref mInfoVeias[num28].mBornes;
											mBornes2 = (DeclaracoesInterligacao.borneCruzamentoCaboAranha[])Utils.CopyArray(mBornes2, new DeclaracoesInterligacao.borneCruzamentoCaboAranha[num16 + 1]);
											string text5 = mBornesJ[array[inicio].indiceBorne].Tag;
											if (Operators.CompareString(mBornesJ[array[inicio].indiceBorne].NRegua, "", TextCompare: true) != 0)
											{
												text5 = mBornesJ[array[inicio].indiceBorne].NRegua;
											}
											string borne2 = mBornesJ[array[inicio].indiceBorne].Borne;
											mInfoVeias[num28].mBornes[num16].ID = ((DBObject)val11).ObjectId;
											mInfoVeias[num28].mBornes[num16].rb = text5 + "-" + borne2;
											mInfoVeias[num28].mBornes[num16].pagina = array[inicio].Pagina;
											break;
										}
									}
								}
								int num29 = inicio;
								int num30 = final;
								for (int num31 = num29; num31 <= num30; num31++)
								{
									DeclaracoesInterligacao.borneJ borneJ4 = mBornesJ[array[num31].indiceBorne];
									string veia2 = array[num31].Veia;
									string tagDest2 = array[num31].Dest.tagDest;
									string nReguaDest2 = array[num31].Dest.nReguaDest;
									string borneDest2 = array[num31].Dest.borneDest;
									Polyline val21 = new Polyline();
									((Entity)val21).SetDatabaseDefaults();
									((Entity)val21).ColorIndex = 7;
									((Entity)val21).Layer = borneJ4.Pagina;
									((Entity)val21).LineWeight = (LineWeight)9;
									if (borneJ4.contVeiasLigadas == 1 && borneJ4.TipoBorne != 0 && borneJ4.TipoBorne == 1)
									{
										mBornesJ[array[num31].indiceBorne].ptInsTerm = new Point2d(borneJ4.ptInsTerm.X, borneJ4.ptInsTerm.Y - 5.0);
										borneJ4 = mBornesJ[array[num31].indiceBorne];
									}
									double num32 = 0.0;
									Point2d val22 = new Point2d(num22, y);
									if (y != borneJ4.ptInsTerm.Y)
									{
										if (!(y > borneJ4.ptInsTerm.Y))
										{
											if (y < borneJ4.ptInsTerm.Y)
											{
												if (borneJ4.contVeiasLigadas != 0)
												{
													if (borneJ4.TipoBorne != 0)
													{
														if (borneJ4.TipoBorne == 1)
														{
															val23 = new Point2d(num22, borneJ4.ptInsTerm.Y - 2.5);
															if ((num6 == 1) | (num6 == 3))
															{
																val24 = new Point2d(num22 - 2.5, borneJ4.ptInsTerm.Y);
																val25 = new Point2d(borneJ4.ptInsTerm.X + 1.5, borneJ4.ptInsTerm.Y);
																num32 = 0.42;
															}
															ptInsTerm = borneJ4.ptInsTerm;
														}
													}
													else
													{
														val23 = new Point2d(num22, borneJ4.ptInsTerm.Y - 5.0);
														if ((num6 == 1) | (num6 == 3))
														{
															val24 = new Point2d(num22 - 2.5, borneJ4.ptInsTerm.Y - 2.5);
															val25 = new Point2d(borneJ4.ptInsTerm.X + 1.5, borneJ4.ptInsTerm.Y - 2.5);
															num32 = 0.42;
														}
														if (val23.Y == val24.Y)
														{
															val23 = new Point2d(num22, val22.Y);
														}
														ptInsTerm = borneJ4.ptInsTerm;
													}
												}
												else
												{
													val23 = new Point2d(num22, borneJ4.ptInsTerm.Y - 2.5);
													if ((num6 == 1) | (num6 == 3))
													{
														val24 = new Point2d(num22 - 2.5, borneJ4.ptInsTerm.Y);
														val25 = new Point2d(borneJ4.ptInsTerm.X + 1.5, borneJ4.ptInsTerm.Y);
														num32 = 0.42;
													}
													ptInsTerm = borneJ4.ptInsTerm;
												}
											}
										}
										else if (borneJ4.contVeiasLigadas != 0)
										{
											if (borneJ4.TipoBorne != 0)
											{
												if (borneJ4.TipoBorne == 1)
												{
													val23 = new Point2d(num22, borneJ4.ptInsTerm.Y + 2.5);
													if ((num6 == 1) | (num6 == 3))
													{
														val24 = new Point2d(num22 - 2.5, borneJ4.ptInsTerm.Y);
														val25 = new Point2d(borneJ4.ptInsTerm.X + 1.5, borneJ4.ptInsTerm.Y);
														num32 = -0.42;
													}
													ptInsTerm = borneJ4.ptInsTerm;
												}
											}
											else
											{
												val23 = new Point2d(num22, borneJ4.ptInsTerm.Y);
												if ((num6 == 1) | (num6 == 3))
												{
													val24 = new Point2d(num22 - 2.5, borneJ4.ptInsTerm.Y - 2.5);
													val25 = new Point2d(borneJ4.ptInsTerm.X + 1.5, borneJ4.ptInsTerm.Y - 2.5);
													num32 = -0.42;
												}
												if (val23.Y == val24.Y)
												{
													val23 = new Point2d(num22, val22.Y);
												}
												ptInsTerm = borneJ4.ptInsTerm;
											}
										}
										else
										{
											val23 = new Point2d(num22, borneJ4.ptInsTerm.Y + 2.5);
											if ((num6 == 1) | (num6 == 3))
											{
												val24 = new Point2d(num22 - 2.5, borneJ4.ptInsTerm.Y);
												val25 = new Point2d(borneJ4.ptInsTerm.X + 1.5, borneJ4.ptInsTerm.Y);
												num32 = -0.42;
											}
											ptInsTerm = borneJ4.ptInsTerm;
										}
									}
									else if (borneJ4.contVeiasLigadas != 0)
									{
										if (borneJ4.TipoBorne != 0)
										{
											if (borneJ4.TipoBorne == 1)
											{
												val23 = val22;
												if ((num6 == 1) | (num6 == 3))
												{
													val24 = new Point2d(num22 - 2.5, borneJ4.ptInsTerm.Y);
													val25 = new Point2d(borneJ4.ptInsTerm.X + 1.5, borneJ4.ptInsTerm.Y);
												}
												ptInsTerm = borneJ4.ptInsTerm;
												num32 = 0.0;
											}
										}
										else
										{
											val23 = val22;
											if ((num6 == 1) | (num6 == 3))
											{
												val24 = new Point2d(num22 - 2.5, borneJ4.ptInsTerm.Y - 2.5);
												val25 = new Point2d(borneJ4.ptInsTerm.X + 1.5, borneJ4.ptInsTerm.Y - 2.5);
											}
											ptInsTerm = borneJ4.ptInsTerm;
											num32 = 0.42;
										}
									}
									else
									{
										val23 = val22;
										if ((num6 == 1) | (num6 == 3))
										{
											val24 = new Point2d(num22 - 2.5, borneJ4.ptInsTerm.Y);
											val25 = new Point2d(borneJ4.ptInsTerm.X + 1.5, borneJ4.ptInsTerm.Y);
										}
										ptInsTerm = borneJ4.ptInsTerm;
										num32 = 0.0;
									}
									val21.AddVertexAt(0, val22, 0.0, 0.0, 0.0);
									val21.AddVertexAt(1, val23, 0.0, 0.0, 0.0);
									val21.AddVertexAt(2, val24, 0.0, 0.0, 0.0);
									val21.AddVertexAt(3, val25, 0.0, 0.0, 0.0);
									val21.AddVertexAt(4, ptInsTerm, 0.0, 0.0, 0.0);
									val21.SetBulgeAt(1, num32);
									val4.AppendEntity((Entity)(object)val21);
									DeclaracoesGeral.bAnularEventos = true;
									val2.AddNewlyCreatedDBObject((DBObject)(object)val21, true);
									ent = (Entity)(object)val21;
									XDataDIEnergisa.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, veia2, borneJ4.Handle);
									val21 = (Polyline)ent;
									TextStyleTable val26 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)0);
									ObjectId textStyleId = (((SymbolTable)val26).Has("Romans") ? ((SymbolTable)val26)["Romans"] : ((SymbolTable)val26)["Standard"]);
									DBText val27 = new DBText();
									val27.TextString = veia2;
									((Entity)val27).ColorIndex = 7;
									((Entity)val27).Layer = ((Entity)val21).Layer;
									val27.Height = 1.6;
									val27.TextStyleId = textStyleId;
									val27.WidthFactor = 0.9;
									if ((num6 == 1) | (num6 == 3))
									{
										alignmentPoint = new Point3d(val24.X, val24.Y + 1.1, 0.0);
										val27.HorizontalMode = (TextHorizontalMode)2;
										val27.VerticalMode = (TextVerticalMode)2;
									}
									val27.AlignmentPoint = alignmentPoint;
									val4.AppendEntity((Entity)(object)val27);
									DeclaracoesGeral.bAnularEventos = true;
									val2.AddNewlyCreatedDBObject((DBObject)(object)val27, true);
									ent = (Entity)(object)val27;
									XDataDIEnergisa.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, veia2, "");
									val27 = (DBText)ent;
									string text6 = "";
									DBText val28 = new DBText();
									((Entity)val28).Layer = ((Entity)val21).Layer;
									val28.Height = 1.6;
									val28.TextStyleId = textStyleId;
									val28.WidthFactor = 0.9;
									val28.Rotation = 0.0;
									((Entity)val28).ColorIndex = 7;
									val28.Oblique = Math.PI / 12.0;
									text6 = tagDest2;
									if (Operators.CompareString(nReguaDest2, "", TextCompare: true) != 0)
									{
										text6 = nReguaDest2;
									}
									text6 = text6 + "-" + borneDest2;
									Point3d alignmentPoint2 = new Point3d(val25.X + 8.0, val25.Y + 1.1, 0.0);
									val28.HorizontalMode = (TextHorizontalMode)0;
									val28.VerticalMode = (TextVerticalMode)2;
									val28.AlignmentPoint = alignmentPoint2;
									val28.TextString = text6;
									val4.AppendEntity((Entity)(object)val28);
									DeclaracoesGeral.bAnularEventos = true;
									val2.AddNewlyCreatedDBObject((DBObject)(object)val28, true);
									ent = (Entity)(object)val28;
									XDataDIEnergisa.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, veia2, "");
									val28 = (DBText)ent;
									mBornesJ[array[num31].indiceBorne].contVeiasLigadas++;
								}
							}
							int num33 = Information.UBound(mInfoVeias);
							for (int num34 = 1; num34 <= num33; num34++)
							{
								if (Operators.CompareString(mInfoVeias[num34].tag_Cabo, mCabos[i].Tag_Cabo, TextCompare: true) != 0)
								{
									continue;
								}
								int num35 = Information.UBound(mInfoVeias[num34].mBornes) - 1;
								for (int num36 = 0; num36 <= num35; num36++)
								{
									ObjectId iD = mInfoVeias[num34].mBornes[num36].ID;
									string pagina3 = mInfoVeias[num34].mBornes[num36].pagina;
									string pagina4 = mInfoVeias[num34].mBornes[num36 + 1].pagina;
									BlockReference val29 = (BlockReference)val2.GetObject(iD, (OpenMode)0);
									AttributeCollection attributeCollection = val29.AttributeCollection;
									foreach (object item in attributeCollection)
									{
										ObjectId val30 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
										AttributeReference val31 = (AttributeReference)val30.GetObject((OpenMode)1);
										string text7 = mInfoVeias[num34].mBornes[num36 + 1].rb;
										if (Operators.CompareString(pagina3, pagina4, TextCompare: true) != 0)
										{
											text7 = text7 + DeclaracoesGeral.Conf.PrefixoCruzInterno + pagina4 + DeclaracoesGeral.Conf.SufixoCruzInterno;
										}
										string tag2 = val31.Tag;
										if (Operators.CompareString(tag2, "BORNE", TextCompare: true) == 0)
										{
											((DBText)val31).TextString = text7;
										}
									}
								}
								break;
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
				((IDisposable)val)?.Dispose();
			}
		}
	}

	public static void ApagaVeias(string revisao, int Painel)
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
						Entity ent = (Entity)val2.GetObject(current, (OpenMode)0);
						string revisao2 = "";
						int painel = 0;
						string tag_cabo = "";
						string veia = "";
						string handle = "";
						if (XDataDIEnergisa.LerXDataVeia(ref ent, ref revisao2, ref painel, ref tag_cabo, ref veia, ref handle) && ((Operators.CompareString(revisao, revisao2, TextCompare: true) == 0) & (Painel == painel)))
						{
							((DBObject)ent).UpgradeOpen();
							((DBObject)ent).Erase();
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

	public static void ApagaVeiasUmCabo(string revisao, int Painel, string Tag)
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
						Entity ent = (Entity)val2.GetObject(current, (OpenMode)0);
						string revisao2 = "";
						int painel = 0;
						string tag_cabo = "";
						string veia = "";
						string handle = "";
						if (XDataDIEnergisa.LerXDataVeia(ref ent, ref revisao2, ref painel, ref tag_cabo, ref veia, ref handle) && ((Operators.CompareString(revisao, revisao2, TextCompare: true) == 0) & (Painel == painel) & (Operators.CompareString(tag_cabo, Tag, TextCompare: true) == 0)))
						{
							((DBObject)ent).UpgradeOpen();
							((DBObject)ent).Erase();
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

	private static Hatch WNNp3iiHqr(Point3d P_0, string P_1)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Obj, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected Obj, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected Obj, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		Hatch result = null;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			BlockTable val = (BlockTable)topTransaction.GetObject(database.BlockTableId, (OpenMode)0);
			BlockTableRecord val2 = (BlockTableRecord)topTransaction.GetObject(((SymbolTable)val)[BlockTableRecord.ModelSpace], (OpenMode)1);
			Circle val3 = new Circle();
			((Entity)val3).SetDatabaseDefaults();
			val3.Center = P_0;
			val3.Radius = 0.4;
			val2.AppendEntity((Entity)(object)val3);
			DeclaracoesGeral.bAnularEventos = true;
			topTransaction.AddNewlyCreatedDBObject((DBObject)(object)val3, true);
			ObjectIdCollection val4 = new ObjectIdCollection();
			val4.Add(((DBObject)val3).ObjectId);
			Hatch val5 = new Hatch();
			val2.AppendEntity((Entity)(object)val5);
			DeclaracoesGeral.bAnularEventos = true;
			topTransaction.AddNewlyCreatedDBObject((DBObject)(object)val5, true);
			((Entity)val5).SetDatabaseDefaults();
			((Entity)val5).ColorIndex = 7;
			((Entity)val5).LineWeight = (LineWeight)9;
			((Entity)val5).Layer = P_1;
			val5.SetHatchPattern((HatchPatternType)1, "SOLID");
			val5.Associative = true;
			val5.AppendLoop((HatchLoopTypes)16, val4);
			val5.EvaluateHatch(true);
			((DBObject)val3).Erase();
			result = val5;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		finally
		{
			((IDisposable)topTransaction)?.Dispose();
		}
		return result;
	}

	public static void carregaTodosCabosDWG(string revisao, ref DeclaracoesInterligacao.caboSync[] mCabosSync)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected Obj, but got Unknown
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected Obj, but got Unknown
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
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
							if (val4.Name.ToUpper().Contains("CABO"))
							{
								string revisao2 = "";
								int painel = 0;
								DeclaracoesInterligacao.caboAranha cabo = default;
								Entity ent = (Entity)(object)val4;
								bool flag = XDataDIEnergisa.LerXDataCabo(ref ent, ref revisao2, ref painel, ref cabo);
								val4 = (BlockReference)ent;
								if (flag && Operators.CompareString(revisao, revisao2, TextCompare: true) == 0)
								{
									int num = Information.UBound(mCabosSync) + 1;
									mCabosSync = (DeclaracoesInterligacao.caboSync[])Utils.CopyArray(mCabosSync, new DeclaracoesInterligacao.caboSync[num + 1]);
									mCabosSync[num].Revisao = revisao;
									mCabosSync[num].Tag_Cabo = cabo.Tag_Cabo;
									mCabosSync[num].Painel = painel;
									mCabosSync[num].Caderno = DeclaracoesGeral.Conf.Local;
									mCabosSync[num].Folha = ((Entity)val4).Layer.ToString();
									mCabosSync[num].Coluna = cabo.Coluna;
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
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}

	public static void LimpaCruzamentoCabos()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected Obj, but got Unknown
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected Obj, but got Unknown
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
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
							if (Operators.CompareString(current.ObjectClass.DxfName.ToUpper(), "INSERT", TextCompare: true) != 0)
							{
								continue;
							}
							BlockReference val5 = (BlockReference)val2.GetObject(current, (OpenMode)0);
							if (!val5.Name.ToUpper().Contains("CABO"))
							{
								continue;
							}
							string revisao = "";
							int painel = 0;
							DeclaracoesInterligacao.caboAranha cabo = default;
							Entity ent = (Entity)(object)val5;
							bool flag = XDataAranha.LerXDataCabo(ref ent, ref revisao, ref painel, ref cabo);
							val5 = (BlockReference)ent;
							if (!flag)
							{
								continue;
							}
							string text = DeclaracoesGeral.Conf.PrefixoCruzInterno + "?" + DeclaracoesGeral.Conf.SufixoCruzInterno;
							AttributeCollection attributeCollection = val5.AttributeCollection;
							foreach (object item in attributeCollection)
							{
								ObjectId val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
								AttributeReference val7 = (AttributeReference)val6.GetObject((OpenMode)1);
								string tag = val7.Tag;
								if (Operators.CompareString(tag, "CAD", TextCompare: true) == 0 || Operators.CompareString(tag, "COL", TextCompare: true) == 0 || Operators.CompareString(tag, "FL1", TextCompare: true) == 0 || Operators.CompareString(tag, "FL2", TextCompare: true) == 0)
								{
									((DBText)val7).TextString = text.Trim();
								}
								((Entity)val7).Draw();
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

	public static void SincronizaCabos(string revisao, DeclaracoesInterligacao.caboSync[] mTodosCabosSync)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected Obj, but got Unknown
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Expected Obj, but got Unknown
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
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
							if (Operators.CompareString(current.ObjectClass.DxfName.ToUpper(), "INSERT", TextCompare: true) != 0)
							{
								continue;
							}
							BlockReference val5 = (BlockReference)val2.GetObject(current, (OpenMode)0);
							if (!val5.Name.ToUpper().Contains("CABO"))
							{
								continue;
							}
							string revisao2 = "";
							int painel = 0;
							DeclaracoesInterligacao.caboAranha cabo = default;
							Entity ent = (Entity)(object)val5;
							bool flag = XDataDIEnergisa.LerXDataCabo(ref ent, ref revisao2, ref painel, ref cabo);
							val5 = (BlockReference)ent;
							if (!flag || Operators.CompareString(revisao, revisao2, TextCompare: true) != 0)
							{
								continue;
							}
							int num = Information.UBound(mTodosCabosSync);
							for (int i = 1; i <= num; i = checked(i + 1))
							{
								if (Operators.CompareString(mTodosCabosSync[i].Tag_Cabo, cabo.Tag_Cabo, TextCompare: true) != 0 || mTodosCabosSync[i].Painel == painel)
								{
									continue;
								}
								string caderno = mTodosCabosSync[i].Caderno;
								string text = "";
								string text2 = "";
								int num2 = Conversions.ToInteger(mTodosCabosSync[i].Coluna.ToString());
								if (Operators.CompareString(DeclaracoesGeral.Conf.Local, caderno, TextCompare: true) != 0)
								{
									caderno = mTodosCabosSync[i].Caderno;
									text = "";
									text2 = DeclaracoesGeral.Conf.PrefixoCruzInterno + mTodosCabosSync[i].Folha + DeclaracoesGeral.Conf.SufixoCruzInterno;
								}
								else
								{
									caderno = "";
									text = DeclaracoesGeral.Conf.PrefixoCruzInterno + mTodosCabosSync[i].Folha + DeclaracoesGeral.Conf.SufixoCruzInterno;
									text2 = "";
								}
								AttributeCollection attributeCollection = val5.AttributeCollection;
								foreach (object item in attributeCollection)
								{
									ObjectId val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
									AttributeReference val7 = (AttributeReference)val6.GetObject((OpenMode)1);
									string tag = val7.Tag;
									if (Operators.CompareString(tag, "COL", TextCompare: true) != 0)
									{
										if (Operators.CompareString(tag, "FL1", TextCompare: true) != 0)
										{
											if (Operators.CompareString(tag, "FL2", TextCompare: true) != 0)
											{
												if (Operators.CompareString(tag, "CAD", TextCompare: true) == 0)
												{
													((DBText)val7).TextString = caderno;
												}
											}
											else
											{
												((DBText)val7).TextString = text2;
											}
										}
										else
										{
											((DBText)val7).TextString = text;
										}
									}
									else
									{
										((DBText)val7).TextString = Conversions.ToString(num2);
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
					val2.Abort();
					throw;
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
						if (XDataDIEnergisa.LerXDataBorne(ref blockRef, ref bn))
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

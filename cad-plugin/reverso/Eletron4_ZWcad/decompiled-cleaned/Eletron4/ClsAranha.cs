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

public class ClsAranha
{
	private struct NQhjx4p5dPwqQdUuSpSF
	{
		public string sqVp5fesunt;

		public int sNUp5DnYIpl;
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
					string text2 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Interligação\\Eletronorte\\" + nomebloco;
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
		//IL_038f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0394: Unknown result type (might be due to invalid IL or missing references)
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
					string text2 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Interligação\\Eletronorte\\" + nomebloco;
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
					XDataAranha.GravarXDataBorne(ref blockRef, bn);
					if (bInsereNomeRegua)
					{
						TextStyleTable val12 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)0);
						ObjectId textStyleId = (((SymbolTable)val12).Has("Romans") ? ((SymbolTable)val12)["Romans"] : ((SymbolTable)val12)["Standard"]);
						DBText text3 = new DBText();
						text3.TextString = bn.Tag;
						if (Operators.CompareString(bn.NRegua, "", TextCompare: true) != 0)
						{
							text3.TextString = bn.NRegua;
						}
						((Entity)text3).ColorIndex = 7;
						((Entity)text3).Layer = ((Entity)blockRef).Layer;
						text3.Height = 2.5;
						text3.TextStyleId = textStyleId;
						text3.WidthFactor = 1.0;
						Extents3d value = ((Drawable)blockRef).Bounds.Value;
						Point3d val13 = value.MaxPoint;
						double x = val13.X;
						value = ((Drawable)blockRef).Bounds.Value;
						val13 = value.MinPoint;
						double num = (x - val13.X) / 2.0;
						val13 = blockRef.Position;
						double num2 = num + val13.X;
						val13 = blockRef.Position;
						Point3d alignmentPoint = new Point3d(num2, val13.Y + 1.5, 0.0);
						text3.HorizontalMode = (TextHorizontalMode)1;
						text3.VerticalMode = (TextVerticalMode)0;
						text3.AlignmentPoint = alignmentPoint;
						val5.AppendEntity((Entity)(object)text3);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)text3, true);
						XDataAranha.GravarXDataNomeRegua(ref text3, bn);
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

	public static void BuscaPaginasColuna(ref List<string> lPaginasColunas)
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

	public static void BuscaXColunas(ref double X1, ref double X2)
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

	public static void InsereColunasSePrecisar(ref List<string> lPaginasColunas, Point3d ptCol1, Point3d ptCol2)
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

	public static bool ReguaExiste(int Painel, string Tag, string NRegua)
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
						if (XDataAranha.LerXDataBorne(ref blockRef, ref bn) && ((bn.Painel == Painel) & (Operators.CompareString(bn.Tag, Tag, TextCompare: true) == 0) & (Operators.CompareString(bn.NRegua, NRegua, TextCompare: true) == 0)))
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

	public static void ContaBornesReguas(int Painel, ref DeclaracoesInterligacao.structureBornesInseridos[] mBornesInseridos)
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
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						if (Operators.CompareString(current.ObjectClass.DxfName.ToUpper(), "INSERT", TextCompare: true) != 0)
						{
							continue;
						}
						BlockReference blockRef = (BlockReference)val.GetObject(current, (OpenMode)0);
						if (!(blockRef.Name.Contains("BorneSimples") | blockRef.Name.Contains("BorneDuplo")))
						{
							continue;
						}
						DeclaracoesInterligacao.borneAranha bn = default;
						if (!XDataAranha.LerXDataBorne(ref blockRef, ref bn) || bn.Painel != Painel)
						{
							continue;
						}
						bool flag = false;
						int num = Information.UBound(mBornesInseridos);
						for (int i = 0; i <= num; i++)
						{
							if ((Operators.CompareString(mBornesInseridos[i].Tag, bn.Tag, TextCompare: true) == 0) & (Operators.CompareString(mBornesInseridos[i].NRegua, bn.NRegua, TextCompare: true) == 0))
							{
								flag = true;
								mBornesInseridos[i].Qtde++;
								break;
							}
						}
						if (!flag)
						{
							mBornesInseridos = (DeclaracoesInterligacao.structureBornesInseridos[])Utils.CopyArray(mBornesInseridos, new DeclaracoesInterligacao.structureBornesInseridos[Information.UBound(mBornesInseridos) + 1 + 1]);
							mBornesInseridos[Information.UBound(mBornesInseridos)].Tag = bn.Tag;
							mBornesInseridos[Information.UBound(mBornesInseridos)].NRegua = bn.NRegua;
							mBornesInseridos[Information.UBound(mBornesInseridos)].Qtde = 1;
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

	public static bool OutraReguaExiste(string Pagina, ref Point3d pt, int colNum)
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
					if (XDataAranha.LerXDataBorne(ref blockRef, ref bn) && bn.Posicao == colNum)
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
					if (XDataAranha.LerXDataBorne(ref blockRef, ref bn) && ((bn.Painel == Painel) & (Operators.CompareString(bn.Tag, Tag, TextCompare: true) == 0) & (Operators.CompareString(bn.NRegua, NRegua, TextCompare: true) == 0)))
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
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected Obj, but got Unknown
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected Obj, but got Unknown
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
								DBText text = (DBText)val2.GetObject(current, (OpenMode)0);
								DeclaracoesInterligacao.borneAranha bn = default;
								if (XDataAranha.LerXDataNomeRegua(ref text, ref bn) && ((Operators.CompareString(bn.Revisao, revisao, TextCompare: true) == 0) & (bn.Painel == Painel) & (Operators.CompareString(bn.Tag, Tag, TextCompare: true) == 0) & (Operators.CompareString(bn.NRegua, NRegua, TextCompare: true) == 0)))
								{
									((DBObject)text).UpgradeOpen();
									((DBObject)text).Erase();
								}
							}
							continue;
						}
						BlockReference blockRef = (BlockReference)val2.GetObject(current, (OpenMode)0);
						if ((Operators.CompareString(blockRef.Name, "BorneSimples", TextCompare: true) == 0) | (Operators.CompareString(blockRef.Name, "BorneDuplo", TextCompare: true) == 0))
						{
							DeclaracoesInterligacao.borneAranha bn2 = default;
							if (XDataAranha.LerXDataBorne(ref blockRef, ref bn2) && ((Operators.CompareString(bn2.Revisao, revisao, TextCompare: true) == 0) & (bn2.Painel == Painel) & (Operators.CompareString(bn2.Tag, Tag, TextCompare: true) == 0) & (Operators.CompareString(bn2.NRegua, NRegua, TextCompare: true) == 0)))
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

	public static bool CarregaBornesJ(string revisao, int Painel, ref DeclaracoesInterligacao.borneJ[] mBornesJ)
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
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
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
						if (!XDataAranha.LerXDataBorne(ref blockRef, ref bn) || bn.Painel != Painel)
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
						mBornesJ[num].contVeiasLigadas2 = 0;
						switch (bn.Posicao)
						{
						case 2:
						case 4:
						case 5:
							if (bn.TipoBorne != 0)
							{
								if (bn.TipoBorne == 1)
								{
									num2 = 0.0;
									num3 = -2.5;
								}
							}
							else
							{
								num2 = 0.0;
								num3 = -2.5;
							}
							break;
						case 1:
						case 3:
							if (bn.TipoBorne != 0)
							{
								if (bn.TipoBorne == 1)
								{
									num2 = 15.0;
									num3 = -2.5;
								}
							}
							else
							{
								num2 = 10.0;
								num3 = -2.5;
							}
							break;
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

	public static void BuscaJumpers(ref DeclaracoesInterligacao.borneJ[] mBornesJ, ref DeclaracoesInterligacao.jumper[] mJumpers, ref DeclaracoesInterligacao.structureRI[] mReguas)
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

	public static void DesenhaJumper1(string revisao, int painel, ref DeclaracoesInterligacao.borneJ[] mBornesJ, ref DeclaracoesInterligacao.jumper[] mJumpers, long index)
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
		//IL_03ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0407: Unknown result type (might be due to invalid IL or missing references)
		//IL_040c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0428: Unknown result type (might be due to invalid IL or missing references)
		//IL_042d: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03be: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03df: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0436: Unknown result type (might be due to invalid IL or missing references)
		//IL_043b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0450: Unknown result type (might be due to invalid IL or missing references)
		//IL_0455: Unknown result type (might be due to invalid IL or missing references)
		//IL_0471: Unknown result type (might be due to invalid IL or missing references)
		//IL_0476: Unknown result type (might be due to invalid IL or missing references)
		//IL_0560: Unknown result type (might be due to invalid IL or missing references)
		//IL_0565: Unknown result type (might be due to invalid IL or missing references)
		//IL_057a: Unknown result type (might be due to invalid IL or missing references)
		//IL_057f: Unknown result type (might be due to invalid IL or missing references)
		//IL_059b: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_034c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0351: Unknown result type (might be due to invalid IL or missing references)
		//IL_035c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_0521: Unknown result type (might be due to invalid IL or missing references)
		//IL_0526: Unknown result type (might be due to invalid IL or missing references)
		//IL_0531: Unknown result type (might be due to invalid IL or missing references)
		//IL_0536: Unknown result type (might be due to invalid IL or missing references)
		//IL_0552: Unknown result type (might be due to invalid IL or missing references)
		//IL_0557: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Expected Obj, but got Unknown
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0637: Unknown result type (might be due to invalid IL or missing references)
		//IL_0743: Unknown result type (might be due to invalid IL or missing references)
		//IL_074a: Expected Obj, but got Unknown
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
								if (tipoBorne == 1)
								{
									if (!((posicao == 1) | (posicao == 3) | (posicao == 5)))
									{
										if ((posicao == 2) | (posicao == 4))
										{
											position = val7.Position;
											double x = position.X;
											position = val7.Position;
											val5 = new Point3d(x, position.Y - 7.5, 0.0);
										}
									}
									else
									{
										position = val7.Position;
										double num = position.X + 15.0;
										position = val7.Position;
										val5 = new Point3d(num, position.Y - 7.5, 0.0);
									}
								}
							}
							else if (!((posicao == 1) | (posicao == 3) | (posicao == 5)))
							{
								if ((posicao == 2) | (posicao == 4))
								{
									position = val7.Position;
									double x2 = position.X;
									position = val7.Position;
									val5 = new Point3d(x2, position.Y - 2.5, 0.0);
								}
							}
							else
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
								if (tipoBorne2 == 1)
								{
									if (!((posicao2 == 1) | (posicao2 == 3) | (posicao2 == 5)))
									{
										if ((posicao2 == 2) | (posicao2 == 4))
										{
											position = val9.Position;
											double x3 = position.X;
											position = val9.Position;
											val8 = new Point3d(x3, position.Y - 7.5, 0.0);
										}
									}
									else
									{
										position = val9.Position;
										double num3 = position.X + 15.0;
										position = val9.Position;
										val8 = new Point3d(num3, position.Y - 7.5, 0.0);
									}
								}
							}
							else if (!((posicao2 == 1) | (posicao2 == 3) | (posicao2 == 5)))
							{
								if ((posicao2 == 2) | (posicao2 == 4))
								{
									position = val9.Position;
									double x4 = position.X;
									position = val9.Position;
									val8 = new Point3d(x4, position.Y - 2.5, 0.0);
								}
							}
							else
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
						if (!((posicao == 1) | (posicao == 3) | (posicao == 5)))
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
							if (!Tcgp54aYGJ(val12.X, val12.Y, val13.Y, pagina, revisao, painel))
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
						XDataAranha.GravarXDataJumper(ref ent, revisao, painel, bnO, bnD, tipoBorne);
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

	private static bool Tcgp54aYGJ(double P_0, double P_1, double P_2, string P_3, string P_4, int P_5)
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
						bool flag = XDataAranha.LerXDataJumper(ref ent, ref P_4, ref P_5, ref bnO, ref bnD);
						val4 = (Polyline)ent;
						Point2d val5;
						if (!flag)
						{
							ent = (Entity)(object)val4;
							flag = XDataAranha.LerXDataVeia(ref ent, ref P_4, ref P_5, ref tag_cabo, ref veia, ref handle);
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

	public static void DesenhaJumper2(string revisao, int painel, ref DeclaracoesInterligacao.borneJ[] mBornesJ, ref DeclaracoesInterligacao.jumper[] mJumpers, long index)
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
		//IL_0734: Unknown result type (might be due to invalid IL or missing references)
		//IL_0739: Unknown result type (might be due to invalid IL or missing references)
		//IL_074e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0753: Unknown result type (might be due to invalid IL or missing references)
		//IL_076f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0774: Unknown result type (might be due to invalid IL or missing references)
		//IL_0965: Unknown result type (might be due to invalid IL or missing references)
		//IL_0970: Unknown result type (might be due to invalid IL or missing references)
		//IL_0977: Expected Obj, but got Unknown
		//IL_0979: Unknown result type (might be due to invalid IL or missing references)
		//IL_097e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Expected Obj, but got Unknown
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0703: Unknown result type (might be due to invalid IL or missing references)
		//IL_071f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0724: Unknown result type (might be due to invalid IL or missing references)
		//IL_0784: Unknown result type (might be due to invalid IL or missing references)
		//IL_0789: Unknown result type (might be due to invalid IL or missing references)
		//IL_079e: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0903: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0306: Expected Obj, but got Unknown
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_0338: Expected Obj, but got Unknown
		//IL_0685: Unknown result type (might be due to invalid IL or missing references)
		//IL_068a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0695: Unknown result type (might be due to invalid IL or missing references)
		//IL_069a: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_087d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0882: Unknown result type (might be due to invalid IL or missing references)
		//IL_088d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0892: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0913: Unknown result type (might be due to invalid IL or missing references)
		//IL_0918: Unknown result type (might be due to invalid IL or missing references)
		//IL_092d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0932: Unknown result type (might be due to invalid IL or missing references)
		//IL_094e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0953: Unknown result type (might be due to invalid IL or missing references)
		//IL_0814: Unknown result type (might be due to invalid IL or missing references)
		//IL_0819: Unknown result type (might be due to invalid IL or missing references)
		//IL_0824: Unknown result type (might be due to invalid IL or missing references)
		//IL_0829: Unknown result type (might be due to invalid IL or missing references)
		//IL_0845: Unknown result type (might be due to invalid IL or missing references)
		//IL_084a: Unknown result type (might be due to invalid IL or missing references)
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
		//IL_0479: Unknown result type (might be due to invalid IL or missing references)
		//IL_0480: Expected Obj, but got Unknown
		//IL_03bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0989: Unknown result type (might be due to invalid IL or missing references)
		//IL_0994: Unknown result type (might be due to invalid IL or missing references)
		//IL_099b: Expected Obj, but got Unknown
		//IL_099d: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b3: Expected Obj, but got Unknown
		//IL_04cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04df: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e8: Expected Obj, but got Unknown
		//IL_04f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_050b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0513: Unknown result type (might be due to invalid IL or missing references)
		//IL_051a: Expected Obj, but got Unknown
		//IL_052a: Unknown result type (might be due to invalid IL or missing references)
		//IL_052f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0532: Unknown result type (might be due to invalid IL or missing references)
		//IL_053a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0541: Expected Obj, but got Unknown
		//IL_054f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0556: Expected Obj, but got Unknown
		//IL_0556: Unknown result type (might be due to invalid IL or missing references)
		//IL_055d: Expected Obj, but got Unknown
		//IL_0563: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_09cb: Expected Obj, but got Unknown
		//IL_05a1: Unknown result type (might be due to invalid IL or missing references)
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
								if (tipoBorne == 1)
								{
									if (!((posicao == 1) | (posicao == 3) | (posicao == 5)))
									{
										if ((posicao == 2) | (posicao == 4))
										{
											position = val7.Position;
											double x = position.X;
											position = val7.Position;
											val5 = new Point3d(x, position.Y - 7.5, 0.0);
											text = "JumperSaiEsquerda";
										}
									}
									else
									{
										position = val7.Position;
										double num = position.X + 15.0;
										position = val7.Position;
										val5 = new Point3d(num, position.Y - 7.5, 0.0);
										text = "JumperSaiDireita";
									}
								}
							}
							else if (!((posicao == 1) | (posicao == 3) | (posicao == 5)))
							{
								if ((posicao == 2) | (posicao == 4))
								{
									position = val7.Position;
									double x2 = position.X;
									position = val7.Position;
									val5 = new Point3d(x2, position.Y - 2.5, 0.0);
									text = "JumperSaiEsquerda";
								}
							}
							else
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
								if (tipoBorne2 == 1)
								{
									if (!((posicao2 == 1) | (posicao2 == 3) | (posicao2 == 5)))
									{
										if ((posicao2 == 2) | (posicao2 == 4))
										{
											position = val9.Position;
											double x3 = position.X;
											position = val9.Position;
											val8 = new Point3d(x3, position.Y - 7.5, 0.0);
											text2 = "JumperEntraEsquerda";
										}
									}
									else
									{
										position = val9.Position;
										double num3 = position.X + 15.0;
										position = val9.Position;
										val8 = new Point3d(num3, position.Y - 7.5, 0.0);
										text2 = "JumperEntraDireita";
									}
								}
							}
							else if (!((posicao2 == 1) | (posicao2 == 3) | (posicao2 == 5)))
							{
								if ((posicao2 == 2) | (posicao2 == 4))
								{
									position = val9.Position;
									double x4 = position.X;
									position = val9.Position;
									val8 = new Point3d(x4, position.Y - 2.5, 0.0);
									text2 = "JumperEntraEsquerda";
								}
							}
							else
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
						text3 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Interligação\\Eletronorte\\" + text + ".dwg";
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
						XDataAranha.GravarXDataJumper(ref ent, revisao, painel, bnO, bnD, -1);
						val13 = (BlockReference)ent;
						text3 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Interligação\\Eletronorte\\" + text2 + ".dwg";
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
						XDataAranha.GravarXDataJumper(ref ent, revisao, painel, bnO, bnD, -1);
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
							if (XDataAranha.LerXDataJumper(ref ent, ref revisao2, ref painel, ref bnO, ref bnD) && ((Operators.CompareString(revisao2, revisao, TextCompare: true) == 0) & (painel == Painel)))
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

	public static void CarregaEquipamentos5(ref DeclaracoesInterligacao.structureRI[] mReguas, ref DeclaracoesInterligacao.borneJ[] mBornesJ, ref List<string> lPaineis)
	{
		int num = Information.UBound(mBornesJ);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				if (mBornesJ[i].Posicao != 5)
				{
					continue;
				}
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
							string sPainelDest = mReguas[j].Bornes[k].cabos[l].sPainelDest;
							if (!lPaineis.Contains(sPainelDest))
							{
								lPaineis.Add(sPainelDest);
							}
						}
					}
				}
			}
		}
	}

	public static void CarregaCabos(string revisao, ref DeclaracoesInterligacao.structureRI[] mReguas, ref DeclaracoesInterligacao.borneJ[] mBornesJ, ref DeclaracoesInterligacao.caboAranha[] mCabos, List<string> lPaineisEsquerda)
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
							switch (mBornesJ[i].Posicao)
							{
							case 5:
								if (!lPaineisEsquerda.Contains(sPainelDest))
								{
									mCabos[num5].Coluna = 2;
									mCabos[num5].Lado = "E";
								}
								else
								{
									mCabos[num5].Coluna = 1;
									mCabos[num5].Lado = "D";
								}
								break;
							case 1:
								mCabos[num5].Coluna = 1;
								mCabos[num5].Lado = "E";
								break;
							case 2:
								mCabos[num5].Coluna = 1;
								mCabos[num5].Lado = "D";
								break;
							case 3:
								mCabos[num5].Coluna = 2;
								mCabos[num5].Lado = "E";
								break;
							case 4:
								mCabos[num5].Coluna = 2;
								mCabos[num5].Lado = "D";
								break;
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
									goto IL_05a8;
								}
								break;
								IL_05a8:
								mCabos[num5].Y -= 5.0;
							}
						}
					}
				}
			}
			cDadosAccessInterligacao3.fechaConexao();
		}
	}

	public static void InsereCabos(string revisao, int Painel, ref DeclaracoesInterligacao.caboAranha[] mCabos, List<string> lCabosInseridos, bool bAterrarBlindagem)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_042b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0430: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
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
		//IL_0661: Unknown result type (might be due to invalid IL or missing references)
		//IL_066c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0673: Expected Obj, but got Unknown
		//IL_0675: Unknown result type (might be due to invalid IL or missing references)
		//IL_067a: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_053a: Unknown result type (might be due to invalid IL or missing references)
		//IL_053f: Unknown result type (might be due to invalid IL or missing references)
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
					BuscaXColunas(ref X, ref X2);
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
							if (mCabos[i].Coluna == 2)
							{
								if (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) != 0)
								{
									if (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) == 0)
									{
										val5 = new Point3d(X2 + 25.0, mCabos[i].Y, 0.0);
										if (mCabos[i].Blindagem)
										{
											if (mCabos[i].bAterrar)
											{
												text = "CaboDBA";
											}
											else if (mCabos[i].bParTrioTrancado)
											{
												text = "CaboDBNA";
											}
											else
											{
												text = (bAterrarBlindagem ? "CaboDBA" : "CaboDBNA");
											}
										}
										else
										{
											text = "CaboD";
										}
									}
								}
								else
								{
									val5 = new Point3d(X2 - 25.0, mCabos[i].Y, 0.0);
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
						}
						else if (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) != 0)
						{
							if (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) == 0)
							{
								val5 = new Point3d(X + 25.0, mCabos[i].Y, 0.0);
								if (mCabos[i].Blindagem)
								{
									if (mCabos[i].bAterrar)
									{
										text = "CaboDBA";
									}
									else if (mCabos[i].bParTrioTrancado)
									{
										text = "CaboDBNA";
									}
									else
									{
										text = (bAterrarBlindagem ? "CaboDBA" : "CaboDBNA");
									}
								}
								else
								{
									text = "CaboD";
								}
							}
						}
						else
						{
							val5 = new Point3d(X - 25.0, mCabos[i].Y, 0.0);
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
						text2 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Interligação\\Eletronorte\\" + text + ".dwg";
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
						XDataAranha.GravarXDataCabo(ref ent, revisao, Painel, mCabos[i]);
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

	public static void CarregaCabosInseridos(string revisao, int Painel, ref List<string> lCabosInseridos)
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
						bool flag = XDataAranha.LerXDataCabo(ref ent, ref revisao2, ref painel, ref cabo);
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
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected Obj, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
			BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			BlockTableRecordEnumerator enumerator = default;
			try
			{
				enumerator = val3.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ObjectId current = enumerator.Current;
					Entity ent = (Entity)val.GetObject(current, (OpenMode)0);
					Polyline val4 = (Polyline)(object)((ent is Polyline) ? ent : null);
					if (val4 == null)
					{
						continue;
					}
					string revisao2 = "";
					int painel = 0;
					string tag_cabo = "";
					string veia = "";
					string handle = "";
					if (!XDataAranha.LerXDataVeia(ref ent, ref revisao2, ref painel, ref tag_cabo, ref veia, ref handle))
					{
						continue;
					}
					bool flag = false;
					Point3d val5 = ((Curve)val4).StartPoint;
					double x = val5.X;
					val5 = ((Curve)val4).EndPoint;
					flag = ((x > val5.X) ? true : false);
					if ((Operators.CompareString(revisao, revisao2, TextCompare: true) == 0) & (Painel == painel) & (Operators.CompareString(handle, "", TextCompare: true) != 0))
					{
						if (!flag & !list.Contains(handle))
						{
							list.Add(handle);
						}
						if (flag & !list2.Contains(handle))
						{
							list2.Add(handle);
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
				if (((mBornesJ[i].Posicao == 1) | (mBornesJ[i].Posicao == 3)) && list2.Contains(mBornesJ[i].Handle))
				{
					mBornesJ[i].contVeiasLigadas = 1;
				}
				if (((mBornesJ[i].Posicao == 2) | (mBornesJ[i].Posicao == 4)) && list.Contains(mBornesJ[i].Handle))
				{
					mBornesJ[i].contVeiasLigadas = 1;
				}
				if (mBornesJ[i].Posicao == 5)
				{
					if (list.Contains(mBornesJ[i].Handle))
					{
						mBornesJ[i].contVeiasLigadas = 1;
					}
					if (list2.Contains(mBornesJ[i].Handle))
					{
						mBornesJ[i].contVeiasLigadas2 = 1;
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
			((IDisposable)val)?.Dispose();
		}
	}

	public static void CarregaCabosInseridosViaVeias(string revisao, int Painel, ref List<string> lCabosInseridos)
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
					if (XDataAranha.LerXDataVeia(ref ent, ref revisao2, ref painel, ref tag_cabo, ref veia, ref handle) && ((Operators.CompareString(revisao, revisao2, TextCompare: true) == 0) & (Painel == painel)) && !lCabosInseridos.Contains(tag_cabo))
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
							bool flag = XDataAranha.LerXDataCabo(ref ent, ref revisao2, ref painel, ref cabo);
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

	public static void CarregaCabosDWG(string revisao, int Painel, ref DeclaracoesInterligacao.caboAranha[] mCabos)
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
								bool flag = XDataAranha.LerXDataCabo(ref ent, ref revisao2, ref painel, ref cabo);
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

	public static void RelacionaCabosBornes(int Painel, ref DeclaracoesInterligacao.structureRI[] mReguas, ref DeclaracoesInterligacao.borneJ[] mBornesJ, ref DeclaracoesInterligacao.caboAranha[] mCabos)
	{
		NQhjx4p5dPwqQdUuSpSF[] array = new NQhjx4p5dPwqQdUuSpSF[1];
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
									if ((Operators.CompareString(array[n].sqVp5fesunt, tag_Cabo, TextCompare: true) == 0) & (array[n].sNUp5DnYIpl == veia))
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
									array = (NQhjx4p5dPwqQdUuSpSF[])Utils.CopyArray(array, new NQhjx4p5dPwqQdUuSpSF[Information.UBound(array) + 1 + 1]);
									array[Information.UBound(array)].sqVp5fesunt = tag_Cabo;
									array[Information.UBound(array)].sNUp5DnYIpl = veia;
									break;
								}
							}
						}
					}
				}
			}
		}
	}

	public static void VerificaErro(DeclaracoesInterligacao.caboAranha[] mCabos)
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

	public static void InsereVeias(string revisao, int Painel, ref DeclaracoesInterligacao.borneJ[] mBornesJ, ref DeclaracoesInterligacao.caboAranha[] mCabos, ref DeclaracoesInterligacao.cruzamentoCaboAranha[] mInfoVeias, List<string> lCabosInseridos)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0676: Unknown result type (might be due to invalid IL or missing references)
		//IL_067b: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b1: Expected Obj, but got Unknown
		//IL_06e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0706: Unknown result type (might be due to invalid IL or missing references)
		//IL_072c: Unknown result type (might be due to invalid IL or missing references)
		//IL_075c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0763: Expected Obj, but got Unknown
		//IL_077a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c44: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ef3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0efe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f05: Expected Obj, but got Unknown
		//IL_0f07: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c72: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c79: Expected Obj, but got Unknown
		//IL_0c95: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_12b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_12bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_12f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_12fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1225: Unknown result type (might be due to invalid IL or missing references)
		//IL_122a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1270: Unknown result type (might be due to invalid IL or missing references)
		//IL_1275: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f55: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f5c: Expected Obj, but got Unknown
		//IL_0f8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fd7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1007: Unknown result type (might be due to invalid IL or missing references)
		//IL_100e: Expected Obj, but got Unknown
		//IL_1010: Unknown result type (might be due to invalid IL or missing references)
		//IL_101b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1022: Expected Obj, but got Unknown
		//IL_0843: Unknown result type (might be due to invalid IL or missing references)
		//IL_084a: Expected Obj, but got Unknown
		//IL_0cba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cbf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc8: Expected Obj, but got Unknown
		//IL_0ce1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cf7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d06: Expected Obj, but got Unknown
		//IL_13ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_13f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_142f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1434: Unknown result type (might be due to invalid IL or missing references)
		//IL_135d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1362: Unknown result type (might be due to invalid IL or missing references)
		//IL_13a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_13ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_1442: Unknown result type (might be due to invalid IL or missing references)
		//IL_1447: Unknown result type (might be due to invalid IL or missing references)
		//IL_103a: Unknown result type (might be due to invalid IL or missing references)
		//IL_103f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1041: Unknown result type (might be due to invalid IL or missing references)
		//IL_1048: Expected Obj, but got Unknown
		//IL_15fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1601: Unknown result type (might be due to invalid IL or missing references)
		//IL_08dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d18: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d23: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d2a: Expected Obj, but got Unknown
		//IL_1668: Unknown result type (might be due to invalid IL or missing references)
		//IL_166d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d38: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d3f: Expected Obj, but got Unknown
		//IL_0d3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d46: Expected Obj, but got Unknown
		//IL_0d4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d67: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dcf: Expected Obj, but got Unknown
		//IL_0e73: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e78: Unknown result type (might be due to invalid IL or missing references)
		//IL_1733: Unknown result type (might be due to invalid IL or missing references)
		//IL_1735: Unknown result type (might be due to invalid IL or missing references)
		//IL_1129: Unknown result type (might be due to invalid IL or missing references)
		//IL_17c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_17cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_17f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_17f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1847: Unknown result type (might be due to invalid IL or missing references)
		//IL_1849: Unknown result type (might be due to invalid IL or missing references)
		//IL_1af6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1afb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a74: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a99: Unknown result type (might be due to invalid IL or missing references)
		//IL_0abe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b08: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b38: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b67: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b6e: Expected Obj, but got Unknown
		//IL_0b70: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b82: Expected Obj, but got Unknown
		//IL_1549: Unknown result type (might be due to invalid IL or missing references)
		//IL_154e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1799: Unknown result type (might be due to invalid IL or missing references)
		//IL_179e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1812: Unknown result type (might be due to invalid IL or missing references)
		//IL_1817: Unknown result type (might be due to invalid IL or missing references)
		//IL_183b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1840: Unknown result type (might be due to invalid IL or missing references)
		//IL_18e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_18ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_191c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1921: Unknown result type (might be due to invalid IL or missing references)
		//IL_16aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_16ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b83: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b88: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bac: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bb1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c26: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0961: Unknown result type (might be due to invalid IL or missing references)
		//IL_0966: Unknown result type (might be due to invalid IL or missing references)
		//IL_1184: Unknown result type (might be due to invalid IL or missing references)
		//IL_118f: Unknown result type (might be due to invalid IL or missing references)
		//IL_11bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_11c6: Expected Obj, but got Unknown
		//IL_15a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_15ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_18b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_18b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_194a: Unknown result type (might be due to invalid IL or missing references)
		//IL_194f: Unknown result type (might be due to invalid IL or missing references)
		//IL_197d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1982: Unknown result type (might be due to invalid IL or missing references)
		//IL_19a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_19a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_19ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_19cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b64: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bd8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bdd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c01: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c06: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cd5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cda: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d08: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a63: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a68: Unknown result type (might be due to invalid IL or missing references)
		//IL_0968: Unknown result type (might be due to invalid IL or missing references)
		//IL_096f: Expected Obj, but got Unknown
		//IL_09a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_228e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2293: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f23: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f28: Unknown result type (might be due to invalid IL or missing references)
		//IL_171c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1721: Unknown result type (might be due to invalid IL or missing references)
		//IL_19ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_19f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a17: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d41: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d46: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d74: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d79: Unknown result type (might be due to invalid IL or missing references)
		//IL_1db8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dbd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1de1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1de6: Unknown result type (might be due to invalid IL or missing references)
		//IL_22bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_22c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fb0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fb5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fd9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fde: Unknown result type (might be due to invalid IL or missing references)
		//IL_205d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2062: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d94: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d99: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ca7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cac: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ad2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ad7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e10: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e15: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e39: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a09: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a14: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a41: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a48: Expected Obj, but got Unknown
		//IL_22f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_22fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f91: Unknown result type (might be due to invalid IL or missing references)
		//IL_2005: Unknown result type (might be due to invalid IL or missing references)
		//IL_200a: Unknown result type (might be due to invalid IL or missing references)
		//IL_202e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2033: Unknown result type (might be due to invalid IL or missing references)
		//IL_210c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2111: Unknown result type (might be due to invalid IL or missing references)
		//IL_213f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2144: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e90: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e95: Unknown result type (might be due to invalid IL or missing references)
		//IL_2178: Unknown result type (might be due to invalid IL or missing references)
		//IL_217d: Unknown result type (might be due to invalid IL or missing references)
		//IL_21ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_21b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_21ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_21f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_2218: Unknown result type (might be due to invalid IL or missing references)
		//IL_221d: Unknown result type (might be due to invalid IL or missing references)
		//IL_21cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_21d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_20de: Unknown result type (might be due to invalid IL or missing references)
		//IL_20e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eff: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f04: Unknown result type (might be due to invalid IL or missing references)
		//IL_2247: Unknown result type (might be due to invalid IL or missing references)
		//IL_224c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2270: Unknown result type (might be due to invalid IL or missing references)
		//IL_2275: Unknown result type (might be due to invalid IL or missing references)
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
						double num12 = default;
						BlockTableRecordEnumerator enumerator = default;
						Point2d val18 = default;
						Point2d val19 = default;
						int num16 = default;
						Point3d alignmentPoint = default;
						Point2d val26 = default;
						Point2d val27 = default;
						Point2d val28 = default;
						Point2d val29 = default;
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
							object[,] array = new object[2, 1];
							int num6 = 0;
							int num7 = Information.UBound(mCabos[i].mIndices);
							for (int j = 1; j <= num7; j++)
							{
								int num8 = mCabos[i].mIndices[j];
								DeclaracoesInterligacao.borneJ borneJ = mBornesJ[num8];
								string text = mCabos[i].mVeias[j];
								double num9 = 0.0;
								double num10 = 0.0;
								int num11 = 0;
								if (!((borneJ.Posicao == 5) & (mCabos[i].Coluna == 2)))
								{
									num11 = borneJ.contVeiasLigadas;
								}
								else
								{
									if (borneJ.TipoBorne != 0)
									{
										if (borneJ.TipoBorne == 1)
										{
											num10 = 15.0;
										}
									}
									else
									{
										num10 = 10.0;
									}
									num11 = borneJ.contVeiasLigadas2;
									borneJ.ptInsTerm = new Point2d(borneJ.ptInsTerm.X + num10, borneJ.ptInsTerm.Y);
								}
								if (num11 == 1)
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
								if (Operators.CompareString(mCabos[i].Pagina, borneJ.Pagina, TextCompare: true) == 0 && (((mCabos[i].Coluna == 1) & (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0) & (borneJ.Posicao == 1)) | ((mCabos[i].Coluna == 2) & (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0) & (borneJ.Posicao == 3)) | ((mCabos[i].Coluna == 1) & (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) == 0) & (borneJ.Posicao == 2)) | ((mCabos[i].Coluna == 2) & (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) == 0) & (borneJ.Posicao == 4)) | ((mCabos[i].Coluna == 1) & (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) == 0) & (borneJ.Posicao == 5)) | ((mCabos[i].Coluna == 2) & (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0) & (borneJ.Posicao == 5))))
								{
									if (val5.Y > num3)
									{
										num3 = val5.Y;
									}
									if (val5.Y < num4)
									{
										num4 = val5.Y;
									}
									num12 = val5.X;
									num6 = borneJ.Posicao;
									num5 = val5.X;
									int num13 = Information.UBound(array, 2) + 1;
									array = (object[,])Utils.CopyArray(array, new object[2, num13 + 1]);
									array[0, num13] = num8;
									array[1, num13] = text;
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
								if (!(((mCabos[i].Coluna == 1) & (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0) & (num6 == 1)) | ((mCabos[i].Coluna == 2) & (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0) & (num6 == 3)) | ((mCabos[i].Coluna == 2) & (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0) & (num6 == 5))))
								{
									if (((mCabos[i].Coluna == 1) & (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) == 0) & (num6 == 2)) | ((mCabos[i].Coluna == 2) & (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) == 0) & (num6 == 4)) | ((mCabos[i].Coluna == 1) & (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) == 0) & (num6 == 5)))
									{
										num12 -= num;
										if (num5 - num12 < 10.0)
										{
											num12 -= num;
										}
									}
								}
								else
								{
									num12 += num;
									if (num12 - num5 < 10.0)
									{
										num12 += num;
									}
								}
							}
							while (Tcgp54aYGJ(num12, num3, num4, mCabos[i].Pagina, revisao, Painel));
							Point2d val6 = new Point2d(num12, mCabos[i].ptIns.Y);
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
							XDataAranha.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, "", "");
							val8 = (Polyline)ent;
							Hatch val9 = kqjp0JVh8h(new Point3d(val6.X, val6.Y, 0.0), mCabos[i].Pagina);
							try
							{
								ent = (Entity)(object)val9;
								XDataAranha.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, "", "");
							}
							finally
							{
								((IDisposable)val9)?.Dispose();
							}
							int count = mCabos[i].lVeiasUsadas.Count;
							int num14 = Information.UBound(array, 2);
							if (count > num14)
							{
								string text2 = "";
								if (!((num6 == 1) | (num6 == 3) | ((num6 == 5) & (mCabos[i].Coluna == 2))))
								{
									if ((num6 == 2) | (num6 == 4) | ((num6 == 5) & (mCabos[i].Coluna == 1)))
									{
										text2 = "VeiaSaiEsquerda";
									}
								}
								else
								{
									text2 = "VeiaSaiDireita";
								}
								ObjectId val10 = ObjectId.Null;
								string text3 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Interligação\\Eletronorte\\" + text2 + ".dwg";
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
								XDataAranha.GravarXDataVeia(ref ent, revisao, Painel, mCabos[i].Tag_Cabo, "", "");
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
								if (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) != 0)
								{
									if (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) == 0)
									{
										if (mCabos[i].bAterrar)
										{
											val18 = new Point2d(mCabos[i].ptIns.X + 9.0 + 0.85, mCabos[i].ptIns.Y + 1.8);
											val19 = new Point2d(mCabos[i].ptIns.X + 9.0 - 0.85, mCabos[i].ptIns.Y - 1.8);
										}
										else
										{
											val18 = new Point2d(mCabos[i].ptIns.X + 9.0, mCabos[i].ptIns.Y + 1.8);
											val19 = new Point2d(mCabos[i].ptIns.X + 9.0, mCabos[i].ptIns.Y - 1.8);
										}
									}
								}
								else if (mCabos[i].bAterrar)
								{
									val18 = new Point2d(mCabos[i].ptIns.X - 9.0 + 0.85, mCabos[i].ptIns.Y + 1.8);
									val19 = new Point2d(mCabos[i].ptIns.X - 9.0 - 0.85, mCabos[i].ptIns.Y - 1.8);
								}
								else
								{
									val18 = new Point2d(mCabos[i].ptIns.X - 9.0, mCabos[i].ptIns.Y + 1.8);
									val19 = new Point2d(mCabos[i].ptIns.X - 9.0, mCabos[i].ptIns.Y - 1.8);
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
								XDataAranha.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, "", "");
								val20 = (Polyline)ent;
								TextStyleTable val21 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)0);
								ObjectId textStyleId = (((SymbolTable)val21).Has("Romans") ? ((SymbolTable)val21)["Romans"] : ((SymbolTable)val21)["Standard"]);
								DBText val22 = new DBText();
								bool flag = true;
								bool flag2 = true;
								int num15 = 0;
								string left = "";
								if (mCabos[i].lVeiasLivres.Count > 2)
								{
									foreach (string lVeiasLivre in mCabos[i].lVeiasLivres)
									{
										if (Versioned.IsNumeric(lVeiasLivre))
										{
											if (!flag)
											{
												num16 = Conversions.ToInteger(lVeiasLivre);
												num15++;
												if (num16 != num15)
												{
													flag2 = false;
													break;
												}
											}
											else
											{
												flag = false;
												left = lVeiasLivre;
												num15 = Conversions.ToInteger(lVeiasLivre);
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
									val22.TextString = Conversions.ToString(Operators.AddObject(Operators.AddObject(left, DeclaracoesGeral.mMensagem[1, 1446]), num16.ToString()));
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
								XDataAranha.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, "", "");
								val22 = (DBText)ent;
							}
							int num17 = Information.UBound(array, 2);
							for (int k = 1; k <= num17; k++)
							{
								int num18 = Conversions.ToInteger(array[0, k]);
								string text4 = Conversions.ToString(array[1, k]);
								DeclaracoesInterligacao.borneJ borneJ2 = mBornesJ[num18];
								Polyline val24 = new Polyline();
								((Entity)val24).SetDatabaseDefaults();
								((Entity)val24).ColorIndex = 7;
								((Entity)val24).Layer = mCabos[i].Pagina;
								((Entity)val24).LineWeight = (LineWeight)9;
								double num19 = 0.0;
								int num20 = 0;
								bool flag3 = false;
								if (!((borneJ2.Posicao == 5) & (mCabos[i].Coluna == 2)))
								{
									num20 = borneJ2.contVeiasLigadas;
								}
								else
								{
									flag3 = true;
									if (borneJ2.TipoBorne != 0)
									{
										if (borneJ2.TipoBorne == 1)
										{
											num19 = 15.0;
										}
									}
									else
									{
										num19 = 10.0;
									}
									borneJ2.ptInsTerm = new Point2d(borneJ2.ptInsTerm.X + num19, borneJ2.ptInsTerm.Y);
									num20 = borneJ2.contVeiasLigadas2;
								}
								if (num20 == 1 && borneJ2.TipoBorne == 1)
								{
									mBornesJ[num18].ptInsTerm = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y - 5.0);
									borneJ2 = mBornesJ[num18];
								}
								double num21 = 0.0;
								Point2d val25 = new Point2d(num12, mCabos[i].ptIns.Y);
								if (mCabos[i].ptIns.Y != borneJ2.ptInsTerm.Y)
								{
									if (!(mCabos[i].ptIns.Y > borneJ2.ptInsTerm.Y))
									{
										if (mCabos[i].ptIns.Y < borneJ2.ptInsTerm.Y)
										{
											if (num20 != 0)
											{
												if (borneJ2.TipoBorne != 0)
												{
													if (borneJ2.TipoBorne == 1)
													{
														val26 = new Point2d(num12, borneJ2.ptInsTerm.Y - 2.5);
														if (!((num6 == 1) | (num6 == 3) | ((num6 == 5) & (mCabos[i].Coluna == 2))))
														{
															if ((num6 == 2) | (num6 == 4) | ((num6 == 5) & (mCabos[i].Coluna == 1)))
															{
																val27 = new Point2d(num12 + 2.5, borneJ2.ptInsTerm.Y);
																val28 = new Point2d(borneJ2.ptInsTerm.X - 1.5, borneJ2.ptInsTerm.Y);
																num21 = -0.42;
															}
														}
														else
														{
															val27 = new Point2d(num12 - 2.5, borneJ2.ptInsTerm.Y);
															val28 = new Point2d(borneJ2.ptInsTerm.X + 1.5, borneJ2.ptInsTerm.Y);
															num21 = 0.42;
														}
														val29 = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y);
													}
												}
												else
												{
													val26 = new Point2d(num12, borneJ2.ptInsTerm.Y - 5.0);
													if (!((num6 == 1) | (num6 == 3) | ((num6 == 5) & (mCabos[i].Coluna == 2))))
													{
														if ((num6 == 2) | (num6 == 4) | ((num6 == 5) & (mCabos[i].Coluna == 1)))
														{
															val27 = new Point2d(num12 + 2.5, borneJ2.ptInsTerm.Y - 2.5);
															val28 = new Point2d(borneJ2.ptInsTerm.X - 1.5, borneJ2.ptInsTerm.Y - 2.5);
															num21 = -0.42;
														}
													}
													else
													{
														val27 = new Point2d(num12 - 2.5, borneJ2.ptInsTerm.Y - 2.5);
														val28 = new Point2d(borneJ2.ptInsTerm.X + 1.5, borneJ2.ptInsTerm.Y - 2.5);
														num21 = 0.42;
													}
													if (val26.Y == val27.Y)
													{
														val26 = new Point2d(num12, val25.Y);
													}
													val29 = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y);
												}
											}
											else
											{
												val26 = new Point2d(num12, borneJ2.ptInsTerm.Y - 2.5);
												if (!((num6 == 1) | (num6 == 3) | ((num6 == 5) & (mCabos[i].Coluna == 2))))
												{
													if ((num6 == 2) | (num6 == 4) | ((num6 == 5) & (mCabos[i].Coluna == 1)))
													{
														val27 = new Point2d(num12 + 2.5, borneJ2.ptInsTerm.Y);
														val28 = new Point2d(borneJ2.ptInsTerm.X - 1.5, borneJ2.ptInsTerm.Y);
														num21 = -0.42;
													}
												}
												else
												{
													val27 = new Point2d(num12 - 2.5, borneJ2.ptInsTerm.Y);
													val28 = new Point2d(borneJ2.ptInsTerm.X + 1.5, borneJ2.ptInsTerm.Y);
													num21 = 0.42;
												}
												val29 = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y);
											}
										}
									}
									else if (num20 != 0)
									{
										if (borneJ2.TipoBorne != 0)
										{
											if (borneJ2.TipoBorne == 1)
											{
												val26 = new Point2d(num12, borneJ2.ptInsTerm.Y + 2.5);
												if (!((num6 == 1) | (num6 == 3) | ((num6 == 5) & (mCabos[i].Coluna == 2))))
												{
													if ((num6 == 2) | (num6 == 4) | ((num6 == 5) & (mCabos[i].Coluna == 1)))
													{
														val27 = new Point2d(num12 + 2.5, borneJ2.ptInsTerm.Y);
														val28 = new Point2d(borneJ2.ptInsTerm.X - 1.5, borneJ2.ptInsTerm.Y);
														num21 = 0.42;
													}
												}
												else
												{
													val27 = new Point2d(num12 - 2.5, borneJ2.ptInsTerm.Y);
													val28 = new Point2d(borneJ2.ptInsTerm.X + 1.5, borneJ2.ptInsTerm.Y);
													num21 = -0.42;
												}
												val29 = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y);
											}
										}
										else
										{
											val26 = new Point2d(num12, borneJ2.ptInsTerm.Y);
											if (!((num6 == 1) | (num6 == 3) | ((num6 == 5) & (mCabos[i].Coluna == 2))))
											{
												if ((num6 == 2) | (num6 == 4) | ((num6 == 5) & (mCabos[i].Coluna == 1)))
												{
													val27 = new Point2d(num12 + 2.5, borneJ2.ptInsTerm.Y - 2.5);
													val28 = new Point2d(borneJ2.ptInsTerm.X - 1.5, borneJ2.ptInsTerm.Y - 2.5);
													num21 = 0.42;
												}
											}
											else
											{
												val27 = new Point2d(num12 - 2.5, borneJ2.ptInsTerm.Y - 2.5);
												val28 = new Point2d(borneJ2.ptInsTerm.X + 1.5, borneJ2.ptInsTerm.Y - 2.5);
												num21 = -0.42;
											}
											if (val26.Y == val27.Y)
											{
												val26 = new Point2d(num12, val25.Y);
											}
											val29 = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y);
										}
									}
									else
									{
										val26 = new Point2d(num12, borneJ2.ptInsTerm.Y + 2.5);
										if (!((num6 == 1) | (num6 == 3) | ((num6 == 5) & (mCabos[i].Coluna == 2))))
										{
											if ((num6 == 2) | (num6 == 4) | ((num6 == 5) & (mCabos[i].Coluna == 1)))
											{
												val27 = new Point2d(num12 + 2.5, borneJ2.ptInsTerm.Y);
												val28 = new Point2d(borneJ2.ptInsTerm.X - 1.5, borneJ2.ptInsTerm.Y);
												num21 = 0.42;
											}
										}
										else
										{
											val27 = new Point2d(num12 - 2.5, borneJ2.ptInsTerm.Y);
											val28 = new Point2d(borneJ2.ptInsTerm.X + 1.5, borneJ2.ptInsTerm.Y);
											num21 = -0.42;
										}
										val29 = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y);
									}
								}
								else if (num20 != 0)
								{
									if (borneJ2.TipoBorne != 0)
									{
										if (borneJ2.TipoBorne == 1)
										{
											val26 = val25;
											if (!((num6 == 1) | (num6 == 3) | ((num6 == 5) & (mCabos[i].Coluna == 2))))
											{
												if ((num6 == 2) | (num6 == 4) | (num6 == 5) | ((num6 == 5) & (mCabos[i].Coluna == 1)))
												{
													val27 = new Point2d(num12 + 2.5, borneJ2.ptInsTerm.Y);
													val28 = new Point2d(borneJ2.ptInsTerm.X - 1.5, borneJ2.ptInsTerm.Y);
												}
											}
											else
											{
												val27 = new Point2d(num12 - 2.5, borneJ2.ptInsTerm.Y);
												val28 = new Point2d(borneJ2.ptInsTerm.X + 1.5, borneJ2.ptInsTerm.Y);
											}
											val29 = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y);
											num21 = 0.0;
										}
									}
									else
									{
										val26 = val25;
										if (!((num6 == 1) | (num6 == 3) | ((num6 == 5) & (mCabos[i].Coluna == 2))))
										{
											if ((num6 == 2) | (num6 == 4) | ((num6 == 5) & (mCabos[i].Coluna == 1)))
											{
												val27 = new Point2d(num12 + 2.5, borneJ2.ptInsTerm.Y - 2.5);
												val28 = new Point2d(borneJ2.ptInsTerm.X - 1.5, borneJ2.ptInsTerm.Y - 2.5);
											}
										}
										else
										{
											val27 = new Point2d(num12 - 2.5, borneJ2.ptInsTerm.Y - 2.5);
											val28 = new Point2d(borneJ2.ptInsTerm.X + 1.5, borneJ2.ptInsTerm.Y - 2.5);
										}
										val29 = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y);
										num21 = 0.42;
									}
								}
								else
								{
									val26 = val25;
									if (!((num6 == 1) | (num6 == 3) | ((num6 == 5) & (mCabos[i].Coluna == 2))))
									{
										if ((num6 == 2) | (num6 == 4) | ((num6 == 5) & (mCabos[i].Coluna == 1)))
										{
											val27 = new Point2d(num12 + 2.5, borneJ2.ptInsTerm.Y);
											val28 = new Point2d(borneJ2.ptInsTerm.X - 1.5, borneJ2.ptInsTerm.Y);
										}
									}
									else
									{
										val27 = new Point2d(num12 - 2.5, borneJ2.ptInsTerm.Y);
										val28 = new Point2d(borneJ2.ptInsTerm.X + 1.5, borneJ2.ptInsTerm.Y);
									}
									val29 = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y);
									num21 = 0.0;
								}
								val24.AddVertexAt(0, val25, 0.0, 0.0, 0.0);
								val24.AddVertexAt(1, val26, 0.0, 0.0, 0.0);
								val24.AddVertexAt(2, val27, 0.0, 0.0, 0.0);
								val24.AddVertexAt(3, val28, 0.0, 0.0, 0.0);
								val24.AddVertexAt(4, val29, 0.0, 0.0, 0.0);
								val24.SetBulgeAt(1, num21);
								val4.AppendEntity((Entity)(object)val24);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val24, true);
								ent = (Entity)(object)val24;
								XDataAranha.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, text4, borneJ2.Handle);
								val24 = (Polyline)ent;
								TextStyleTable val30 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)0);
								ObjectId textStyleId2 = (((SymbolTable)val30).Has("Romans") ? ((SymbolTable)val30)["Romans"] : ((SymbolTable)val30)["Standard"]);
								DBText val31 = new DBText();
								val31.TextString = text4;
								((Entity)val31).ColorIndex = 7;
								((Entity)val31).Layer = ((Entity)val24).Layer;
								val31.Height = 1.6;
								val31.TextStyleId = textStyleId2;
								val31.WidthFactor = 0.9;
								if (!((num6 == 1) | (num6 == 3) | ((num6 == 5) & (mCabos[i].Coluna == 2))))
								{
									if ((num6 == 2) | (num6 == 4) | ((num6 == 5) & (mCabos[i].Coluna == 1)))
									{
										alignmentPoint2 = new Point3d(val27.X, val27.Y + 1.1, 0.0);
										val31.HorizontalMode = (TextHorizontalMode)0;
										val31.VerticalMode = (TextVerticalMode)2;
									}
								}
								else
								{
									alignmentPoint2 = new Point3d(val27.X, val27.Y + 1.1, 0.0);
									val31.HorizontalMode = (TextHorizontalMode)2;
									val31.VerticalMode = (TextVerticalMode)2;
								}
								val31.AlignmentPoint = alignmentPoint2;
								val4.AppendEntity((Entity)(object)val31);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val31, true);
								ent = (Entity)(object)val31;
								XDataAranha.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, text4, "");
								val31 = (DBText)ent;
								if (!flag3)
								{
									mBornesJ[num18].contVeiasLigadas++;
								}
								else
								{
									mBornesJ[num18].contVeiasLigadas2++;
								}
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

	public static void InsereVeias2(string revisao, int Painel, ref DeclaracoesInterligacao.borneJ[] mBornesJ, ref DeclaracoesInterligacao.caboAranha[] mCabos, ref DeclaracoesInterligacao.cruzamentoCaboAranha[] mInfoVeias, List<string> lCabosInseridos)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_22de: Unknown result type (might be due to invalid IL or missing references)
		//IL_22e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_2322: Unknown result type (might be due to invalid IL or missing references)
		//IL_232a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2331: Expected Obj, but got Unknown
		//IL_080b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0810: Unknown result type (might be due to invalid IL or missing references)
		//IL_0746: Unknown result type (might be due to invalid IL or missing references)
		//IL_0767: Unknown result type (might be due to invalid IL or missing references)
		//IL_076c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0904: Unknown result type (might be due to invalid IL or missing references)
		//IL_0909: Unknown result type (might be due to invalid IL or missing references)
		//IL_0922: Unknown result type (might be due to invalid IL or missing references)
		//IL_23c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_23c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_234f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2354: Unknown result type (might be due to invalid IL or missing references)
		//IL_235e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2365: Expected Obj, but got Unknown
		//IL_09cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b80: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b92: Expected Obj, but got Unknown
		//IL_0b94: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b99: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a06: Expected Obj, but got Unknown
		//IL_0a22: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a27: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a47: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a55: Expected Obj, but got Unknown
		//IL_0a6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a84: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a93: Expected Obj, but got Unknown
		//IL_0c1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c22: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c31: Expected Obj, but got Unknown
		//IL_0c3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c46: Expected Obj, but got Unknown
		//IL_0c46: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c4d: Expected Obj, but got Unknown
		//IL_0c53: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d02: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d09: Expected Obj, but got Unknown
		//IL_0c91: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dfc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ff7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ffe: Expected Obj, but got Unknown
		//IL_1000: Unknown result type (might be due to invalid IL or missing references)
		//IL_1005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e31: Expected Obj, but got Unknown
		//IL_0e4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e52: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e72: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e77: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e79: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e80: Expected Obj, but got Unknown
		//IL_0e99: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eaf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ebe: Expected Obj, but got Unknown
		//IL_1550: Unknown result type (might be due to invalid IL or missing references)
		//IL_1555: Unknown result type (might be due to invalid IL or missing references)
		//IL_114a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1151: Expected Obj, but got Unknown
		//IL_0ecb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ed0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ed3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0edb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ee2: Expected Obj, but got Unknown
		//IL_0ef0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ef7: Expected Obj, but got Unknown
		//IL_0ef7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0efe: Expected Obj, but got Unknown
		//IL_0f04: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f80: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f87: Expected Obj, but got Unknown
		//IL_1610: Unknown result type (might be due to invalid IL or missing references)
		//IL_1615: Unknown result type (might be due to invalid IL or missing references)
		//IL_11d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_11d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_167f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1684: Unknown result type (might be due to invalid IL or missing references)
		//IL_1738: Unknown result type (might be due to invalid IL or missing references)
		//IL_173a: Unknown result type (might be due to invalid IL or missing references)
		//IL_17b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_17ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_17de: Unknown result type (might be due to invalid IL or missing references)
		//IL_17e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1834: Unknown result type (might be due to invalid IL or missing references)
		//IL_1836: Unknown result type (might be due to invalid IL or missing references)
		//IL_1aad: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ab2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1367: Unknown result type (might be due to invalid IL or missing references)
		//IL_138c: Unknown result type (might be due to invalid IL or missing references)
		//IL_13b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_13d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_13fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_142b: Unknown result type (might be due to invalid IL or missing references)
		//IL_145a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1461: Expected Obj, but got Unknown
		//IL_1463: Unknown result type (might be due to invalid IL or missing references)
		//IL_146e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1475: Expected Obj, but got Unknown
		//IL_10b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_10b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1786: Unknown result type (might be due to invalid IL or missing references)
		//IL_178b: Unknown result type (might be due to invalid IL or missing references)
		//IL_17ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_1804: Unknown result type (might be due to invalid IL or missing references)
		//IL_1828: Unknown result type (might be due to invalid IL or missing references)
		//IL_182d: Unknown result type (might be due to invalid IL or missing references)
		//IL_18bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_18c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_18ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_18f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_16cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_16cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b22: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b27: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b50: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bc5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bca: Unknown result type (might be due to invalid IL or missing references)
		//IL_1225: Unknown result type (might be due to invalid IL or missing references)
		//IL_122a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1882: Unknown result type (might be due to invalid IL or missing references)
		//IL_1887: Unknown result type (might be due to invalid IL or missing references)
		//IL_1919: Unknown result type (might be due to invalid IL or missing references)
		//IL_191e: Unknown result type (might be due to invalid IL or missing references)
		//IL_194c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1951: Unknown result type (might be due to invalid IL or missing references)
		//IL_1970: Unknown result type (might be due to invalid IL or missing references)
		//IL_1975: Unknown result type (might be due to invalid IL or missing references)
		//IL_1999: Unknown result type (might be due to invalid IL or missing references)
		//IL_199e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1afe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b03: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b77: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ba0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ba5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c61: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c94: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a32: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a37: Unknown result type (might be due to invalid IL or missing references)
		//IL_122c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1233: Expected Obj, but got Unknown
		//IL_1264: Unknown result type (might be due to invalid IL or missing references)
		//IL_21a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_21aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e83: Unknown result type (might be due to invalid IL or missing references)
		//IL_1721: Unknown result type (might be due to invalid IL or missing references)
		//IL_1726: Unknown result type (might be due to invalid IL or missing references)
		//IL_19bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_19c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_19e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_19eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cc8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ccd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cfb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d00: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d44: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d68: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_21d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_21d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ef3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ef8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f21: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f91: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d20: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c33: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a89: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d97: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dc0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dc5: Unknown result type (might be due to invalid IL or missing references)
		//IL_12cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_12d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1303: Unknown result type (might be due to invalid IL or missing references)
		//IL_130a: Expected Obj, but got Unknown
		//IL_220f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2214: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ecf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ed4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f48: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f71: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f76: Unknown result type (might be due to invalid IL or missing references)
		//IL_2023: Unknown result type (might be due to invalid IL or missing references)
		//IL_2028: Unknown result type (might be due to invalid IL or missing references)
		//IL_2056: Unknown result type (might be due to invalid IL or missing references)
		//IL_205b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e03: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e08: Unknown result type (might be due to invalid IL or missing references)
		//IL_208f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2094: Unknown result type (might be due to invalid IL or missing references)
		//IL_20c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_20c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2106: Unknown result type (might be due to invalid IL or missing references)
		//IL_210b: Unknown result type (might be due to invalid IL or missing references)
		//IL_212f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2134: Unknown result type (might be due to invalid IL or missing references)
		//IL_20e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_20e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ff5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ffa: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_215e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2163: Unknown result type (might be due to invalid IL or missing references)
		//IL_2187: Unknown result type (might be due to invalid IL or missing references)
		//IL_218c: Unknown result type (might be due to invalid IL or missing references)
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
						double num25 = default;
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
								string ladoEntradaBorne = "";
								if (!((mCabos[i].Coluna == 1) & (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0)))
								{
									if (!((mCabos[i].Coluna == 1) & (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) == 0)))
									{
										if (!((mCabos[i].Coluna == 2) & (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0)))
										{
											if ((mCabos[i].Coluna == 2) & (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) == 0))
											{
												num9 = 4;
											}
										}
										else if (borneJ.Posicao != 5)
										{
											num9 = 3;
										}
										else
										{
											num9 = 5;
											ladoEntradaBorne = "D";
										}
									}
									else if (borneJ.Posicao != 5)
									{
										num9 = 2;
									}
									else
									{
										num9 = 5;
										ladoEntradaBorne = "E";
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
									array[num10].LadoEntradaBorne = ladoEntradaBorne;
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
									array[num11].LadoEntradaBorne = ladoEntradaBorne;
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
								string left = "";
								inicio = array2[n].inicio;
								final = array2[n].final;
								num3 = 0.0;
								num4 = 1000.0;
								double num18 = mBornesJ[array[inicio].indiceBorne].ptInsTerm.Y;
								int num19 = inicio;
								int num20 = final;
								for (int num21 = num19; num21 <= num20; num21++)
								{
									DeclaracoesInterligacao.borneJ borneJ2 = mBornesJ[array[num21].indiceBorne];
									double num22 = 0.0;
									double num23 = 0.0;
									int num24 = 0;
									if (!((borneJ2.Posicao == 5) & (Operators.CompareString(array[num21].LadoEntradaBorne, "D", TextCompare: true) == 0)))
									{
										num24 = borneJ2.contVeiasLigadas;
									}
									else
									{
										if (borneJ2.TipoBorne != 0)
										{
											if (borneJ2.TipoBorne == 1)
											{
												num23 = 15.0;
											}
										}
										else
										{
											num23 = 10.0;
										}
										num24 = borneJ2.contVeiasLigadas2;
										borneJ2.ptInsTerm = new Point2d(borneJ2.ptInsTerm.X + num23, borneJ2.ptInsTerm.Y);
									}
									if (num24 == 1)
									{
										if (borneJ2.TipoBorne != 0)
										{
											if (borneJ2.TipoBorne == 1)
											{
												num22 = 5.0;
											}
										}
										else
										{
											num22 = 2.5;
										}
										num18 -= 5.0;
									}
									new Point2d(mCabos[i].ptIns.X, num18);
									Point2d val5 = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y - num22);
									num5 = val5.X;
									if (val5.Y > num3)
									{
										num3 = val5.Y;
									}
									if (val5.Y < num4)
									{
										num4 = val5.Y;
									}
									num25 = val5.X;
									num6 = borneJ2.Posicao;
									left = array[num21].LadoEntradaBorne;
								}
								do
								{
									if (!((num6 == 1) | (num6 == 3) | ((num6 == 5) & (Operators.CompareString(left, "D", TextCompare: true) == 0))))
									{
										if ((num6 == 2) | (num6 == 4) | ((num6 == 5) & (Operators.CompareString(left, "E", TextCompare: true) == 0)))
										{
											num25 -= num;
											if (num5 - num25 < 10.0)
											{
												num25 -= num;
											}
										}
									}
									else
									{
										num25 += num;
										if (num25 - num5 < 10.0)
										{
											num25 += num;
										}
									}
								}
								while (Tcgp54aYGJ(num25, num3, num4, array[inicio].Pagina, revisao, Painel));
								Point2d val6 = new Point2d(num25, num18);
								Hatch val7 = kqjp0JVh8h(new Point3d(val6.X, val6.Y, 0.0), array[inicio].Pagina);
								Entity ent;
								try
								{
									ent = (Entity)(object)val7;
									XDataAranha.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, "", "");
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
								if ((num6 == 1) | (num6 == 3) | ((num6 == 5) & (Operators.CompareString(left, "D", TextCompare: true) == 0)))
								{
									text = ((!flag) ? "VeiaEntraDireita" : "VeiaEntraDireitaReta");
								}
								else if ((num6 == 2) | (num6 == 4) | ((num6 == 5) & (Operators.CompareString(left, "E", TextCompare: true) == 0)))
								{
									text = ((!flag) ? "VeiaEntraEsquerda" : "VeiaEntraEsquerdaReta");
								}
								ObjectId val8 = ObjectId.Null;
								string text2 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Interligação\\Eletronorte\\" + text + ".dwg";
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
								int num26 = Information.UBound(mInfoVeias);
								for (int num27 = 1; num27 <= num26; num27++)
								{
									if (Operators.CompareString(mInfoVeias[num27].tag_Cabo, mCabos[i].Tag_Cabo, TextCompare: true) == 0)
									{
										text3 = mCabos[i].Tag_Cabo + DeclaracoesGeral.Conf.SeparadorCruzamento + mInfoVeias[num27].coluna;
										if (Operators.CompareString(array[inicio].Pagina, mInfoVeias[num27].mBornes[0].pagina, TextCompare: true) != 0)
										{
											text3 = text3 + DeclaracoesGeral.Conf.PrefixoCruzInterno + mInfoVeias[num27].mBornes[0].pagina + DeclaracoesGeral.Conf.SufixoCruzInterno;
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
								XDataAranha.GravarXDataVeia(ref ent, revisao, Painel, mCabos[i].Tag_Cabo, "", "");
								val11 = (BlockReference)ent;
								if (n >= Information.UBound(array2))
								{
									int num28 = Information.UBound(mInfoVeias);
									for (int num29 = 1; num29 <= num28; num29++)
									{
										if (Operators.CompareString(mInfoVeias[num29].tag_Cabo, mCabos[i].Tag_Cabo, TextCompare: true) == 0)
										{
											ref DeclaracoesInterligacao.borneCruzamentoCaboAranha[] mBornes = ref mInfoVeias[num29].mBornes;
											mBornes = (DeclaracoesInterligacao.borneCruzamentoCaboAranha[])Utils.CopyArray(mBornes, new DeclaracoesInterligacao.borneCruzamentoCaboAranha[num16 + 1]);
											string text4 = mBornesJ[array[inicio].indiceBorne].Tag;
											if (Operators.CompareString(mBornesJ[array[inicio].indiceBorne].NRegua, "", TextCompare: true) != 0)
											{
												text4 = mBornesJ[array[inicio].indiceBorne].NRegua;
											}
											string borne = mBornesJ[array[inicio].indiceBorne].Borne;
											mInfoVeias[num29].mBornes[num16].ID = ObjectId.Null;
											mInfoVeias[num29].mBornes[num16].rb = text4 + "-" + borne;
											mInfoVeias[num29].mBornes[num16].pagina = array[inicio].Pagina;
										}
									}
								}
								else
								{
									text = "";
									if (!((num6 == 1) | (num6 == 3) | ((num6 == 5) & (Operators.CompareString(left, "D", TextCompare: true) == 0))))
									{
										if ((num6 == 2) | (num6 == 4) | ((num6 == 5) & (Operators.CompareString(left, "E", TextCompare: true) == 0)))
										{
											text = "VeiaSaiEsquerda";
										}
									}
									else
									{
										text = "VeiaSaiDireita";
									}
									val8 = ObjectId.Null;
									text2 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Interligação\\Eletronorte\\" + text + ".dwg";
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
									XDataAranha.GravarXDataVeia(ref ent, revisao, Painel, mCabos[i].Tag_Cabo, "", "");
									val11 = (BlockReference)ent;
									int num30 = Information.UBound(mInfoVeias);
									for (int num31 = 1; num31 <= num30; num31++)
									{
										if (Operators.CompareString(mInfoVeias[num31].tag_Cabo, mCabos[i].Tag_Cabo, TextCompare: true) == 0)
										{
											ref DeclaracoesInterligacao.borneCruzamentoCaboAranha[] mBornes2 = ref mInfoVeias[num31].mBornes;
											mBornes2 = (DeclaracoesInterligacao.borneCruzamentoCaboAranha[])Utils.CopyArray(mBornes2, new DeclaracoesInterligacao.borneCruzamentoCaboAranha[num16 + 1]);
											string text5 = mBornesJ[array[inicio].indiceBorne].Tag;
											if (Operators.CompareString(mBornesJ[array[inicio].indiceBorne].NRegua, "", TextCompare: true) != 0)
											{
												text5 = mBornesJ[array[inicio].indiceBorne].NRegua;
											}
											string borne2 = mBornesJ[array[inicio].indiceBorne].Borne;
											mInfoVeias[num31].mBornes[num16].ID = ((DBObject)val11).ObjectId;
											mInfoVeias[num31].mBornes[num16].rb = text5 + "-" + borne2;
											mInfoVeias[num31].mBornes[num16].pagina = array[inicio].Pagina;
											break;
										}
									}
								}
								int num32 = inicio;
								int num33 = final;
								for (int num34 = num32; num34 <= num33; num34++)
								{
									DeclaracoesInterligacao.borneJ borneJ3 = mBornesJ[array[num34].indiceBorne];
									string veia2 = array[num34].Veia;
									Polyline val21 = new Polyline();
									((Entity)val21).SetDatabaseDefaults();
									((Entity)val21).ColorIndex = 7;
									((Entity)val21).Layer = borneJ3.Pagina;
									((Entity)val21).LineWeight = (LineWeight)9;
									double num35 = 0.0;
									int num36 = 0;
									if (!((borneJ3.Posicao == 5) & (Operators.CompareString(array[num34].LadoEntradaBorne, "D", TextCompare: true) == 0)))
									{
										num36 = borneJ3.contVeiasLigadas;
									}
									else
									{
										if (borneJ3.TipoBorne != 0)
										{
											if (borneJ3.TipoBorne == 1)
											{
												num35 = 15.0;
											}
										}
										else
										{
											num35 = 10.0;
										}
										num36 = borneJ3.contVeiasLigadas2;
										borneJ3.ptInsTerm = new Point2d(borneJ3.ptInsTerm.X + num35, borneJ3.ptInsTerm.Y);
									}
									if (num36 == 1 && borneJ3.TipoBorne == 1)
									{
										mBornesJ[array[num34].indiceBorne].ptInsTerm = new Point2d(borneJ3.ptInsTerm.X, borneJ3.ptInsTerm.Y - 5.0);
										borneJ3 = mBornesJ[array[num34].indiceBorne];
									}
									double num37 = 0.0;
									Point2d val22 = new Point2d(num25, num18);
									if (num18 != borneJ3.ptInsTerm.Y)
									{
										if (!(num18 > borneJ3.ptInsTerm.Y))
										{
											if (num18 < borneJ3.ptInsTerm.Y)
											{
												if (num36 != 0)
												{
													if (borneJ3.TipoBorne != 0)
													{
														if (borneJ3.TipoBorne == 1)
														{
															val23 = new Point2d(num25, num18);
															if (!((num6 == 1) | (num6 == 3) | ((num6 == 5) & (Operators.CompareString(left, "D", TextCompare: true) == 0))))
															{
																if ((num6 == 2) | (num6 == 4) | ((num6 == 5) & (Operators.CompareString(left, "E", TextCompare: true) == 0)))
																{
																	val24 = new Point2d(num25 + 2.5, borneJ3.ptInsTerm.Y);
																	val25 = new Point2d(borneJ3.ptInsTerm.X - 1.5, borneJ3.ptInsTerm.Y);
																	num37 = -0.42;
																}
															}
															else
															{
																val24 = new Point2d(num25 - 2.5, borneJ3.ptInsTerm.Y);
																val25 = new Point2d(borneJ3.ptInsTerm.X + 1.5, borneJ3.ptInsTerm.Y);
																num37 = 0.42;
															}
															ptInsTerm = borneJ3.ptInsTerm;
														}
													}
													else
													{
														val23 = new Point2d(num25, num18);
														if (!((num6 == 1) | (num6 == 3) | ((num6 == 5) & (Operators.CompareString(left, "D", TextCompare: true) == 0))))
														{
															if ((num6 == 2) | (num6 == 4) | ((num6 == 5) & (Operators.CompareString(left, "E", TextCompare: true) == 0)))
															{
																val24 = new Point2d(num25 + 2.5, borneJ3.ptInsTerm.Y - 2.5);
																val25 = new Point2d(borneJ3.ptInsTerm.X - 1.5, borneJ3.ptInsTerm.Y - 2.5);
																num37 = -0.42;
															}
														}
														else
														{
															val24 = new Point2d(num25 - 2.5, borneJ3.ptInsTerm.Y - 2.5);
															val25 = new Point2d(borneJ3.ptInsTerm.X + 1.5, borneJ3.ptInsTerm.Y - 2.5);
															num37 = 0.42;
														}
														if (val23.Y == val24.Y)
														{
															val23 = new Point2d(num25, val22.Y);
														}
														ptInsTerm = borneJ3.ptInsTerm;
													}
												}
												else
												{
													val23 = new Point2d(num25, borneJ3.ptInsTerm.Y - 2.5);
													if (!((num6 == 1) | (num6 == 3) | ((num6 == 5) & (Operators.CompareString(left, "D", TextCompare: true) == 0))))
													{
														if ((num6 == 2) | (num6 == 4) | ((num6 == 5) & (Operators.CompareString(left, "E", TextCompare: true) == 0)))
														{
															val24 = new Point2d(num25 + 2.5, borneJ3.ptInsTerm.Y);
															val25 = new Point2d(borneJ3.ptInsTerm.X - 1.5, borneJ3.ptInsTerm.Y);
															num37 = -0.42;
														}
													}
													else
													{
														val24 = new Point2d(num25 - 2.5, borneJ3.ptInsTerm.Y);
														val25 = new Point2d(borneJ3.ptInsTerm.X + 1.5, borneJ3.ptInsTerm.Y);
														num37 = 0.42;
													}
													ptInsTerm = borneJ3.ptInsTerm;
												}
											}
										}
										else if (num36 != 0)
										{
											if (borneJ3.TipoBorne != 0)
											{
												if (borneJ3.TipoBorne == 1)
												{
													val23 = new Point2d(num25, borneJ3.ptInsTerm.Y + 2.5);
													if (!((num6 == 1) | (num6 == 3) | ((num6 == 5) & (Operators.CompareString(left, "D", TextCompare: true) == 0))))
													{
														if ((num6 == 2) | (num6 == 4) | ((num6 == 5) & (Operators.CompareString(left, "E", TextCompare: true) == 0)))
														{
															val24 = new Point2d(num25 + 2.5, borneJ3.ptInsTerm.Y);
															val25 = new Point2d(borneJ3.ptInsTerm.X - 1.5, borneJ3.ptInsTerm.Y);
															num37 = 0.42;
														}
													}
													else
													{
														val24 = new Point2d(num25 - 2.5, borneJ3.ptInsTerm.Y);
														val25 = new Point2d(borneJ3.ptInsTerm.X + 1.5, borneJ3.ptInsTerm.Y);
														num37 = -0.42;
													}
													ptInsTerm = borneJ3.ptInsTerm;
												}
											}
											else
											{
												val23 = new Point2d(num25, borneJ3.ptInsTerm.Y);
												if (!((num6 == 1) | (num6 == 3) | ((num6 == 5) & (Operators.CompareString(left, "D", TextCompare: true) == 0))))
												{
													if ((num6 == 2) | (num6 == 4) | ((num6 == 5) & (Operators.CompareString(left, "E", TextCompare: true) == 0)))
													{
														val24 = new Point2d(num25 + 2.5, borneJ3.ptInsTerm.Y - 2.5);
														val25 = new Point2d(borneJ3.ptInsTerm.X - 1.5, borneJ3.ptInsTerm.Y - 2.5);
														num37 = 0.42;
													}
												}
												else
												{
													val24 = new Point2d(num25 - 2.5, borneJ3.ptInsTerm.Y - 2.5);
													val25 = new Point2d(borneJ3.ptInsTerm.X + 1.5, borneJ3.ptInsTerm.Y - 2.5);
													num37 = -0.42;
												}
												if (val23.Y == val24.Y)
												{
													val23 = new Point2d(num25, val22.Y);
												}
												ptInsTerm = borneJ3.ptInsTerm;
											}
										}
										else
										{
											val23 = new Point2d(num25, borneJ3.ptInsTerm.Y + 2.5);
											if (!((num6 == 1) | (num6 == 3) | ((num6 == 5) & (Operators.CompareString(left, "D", TextCompare: true) == 0))))
											{
												if ((num6 == 2) | (num6 == 4) | ((num6 == 5) & (Operators.CompareString(left, "E", TextCompare: true) == 0)))
												{
													val24 = new Point2d(num25 + 2.5, borneJ3.ptInsTerm.Y);
													val25 = new Point2d(borneJ3.ptInsTerm.X - 1.5, borneJ3.ptInsTerm.Y);
													num37 = 0.42;
												}
											}
											else
											{
												val24 = new Point2d(num25 - 2.5, borneJ3.ptInsTerm.Y);
												val25 = new Point2d(borneJ3.ptInsTerm.X + 1.5, borneJ3.ptInsTerm.Y);
												num37 = -0.42;
											}
											ptInsTerm = borneJ3.ptInsTerm;
										}
									}
									else if (num36 != 0)
									{
										if (borneJ3.TipoBorne != 0)
										{
											if (borneJ3.TipoBorne == 1)
											{
												val23 = val22;
												if (!((num6 == 1) | (num6 == 3) | ((num6 == 5) & (Operators.CompareString(left, "D", TextCompare: true) == 0))))
												{
													if ((num6 == 2) | (num6 == 4) | ((num6 == 5) & (Operators.CompareString(left, "E", TextCompare: true) == 0)))
													{
														val24 = new Point2d(num25 + 2.5, borneJ3.ptInsTerm.Y);
														val25 = new Point2d(borneJ3.ptInsTerm.X - 1.5, borneJ3.ptInsTerm.Y);
													}
												}
												else
												{
													val24 = new Point2d(num25 - 2.5, borneJ3.ptInsTerm.Y);
													val25 = new Point2d(borneJ3.ptInsTerm.X + 1.5, borneJ3.ptInsTerm.Y);
												}
												ptInsTerm = borneJ3.ptInsTerm;
												num37 = 0.0;
											}
										}
										else
										{
											val23 = val22;
											if (!((num6 == 1) | (num6 == 3) | ((num6 == 5) & (Operators.CompareString(left, "D", TextCompare: true) == 0))))
											{
												if ((num6 == 2) | (num6 == 4) | ((num6 == 5) & (Operators.CompareString(left, "E", TextCompare: true) == 0)))
												{
													val24 = new Point2d(num25 + 2.5, borneJ3.ptInsTerm.Y - 2.5);
													val25 = new Point2d(borneJ3.ptInsTerm.X - 1.5, borneJ3.ptInsTerm.Y - 2.5);
												}
											}
											else
											{
												val24 = new Point2d(num25 - 2.5, borneJ3.ptInsTerm.Y - 2.5);
												val25 = new Point2d(borneJ3.ptInsTerm.X + 1.5, borneJ3.ptInsTerm.Y - 2.5);
											}
											ptInsTerm = borneJ3.ptInsTerm;
											num37 = 0.42;
										}
									}
									else
									{
										val23 = val22;
										if (!((num6 == 1) | (num6 == 3) | ((num6 == 5) & (Operators.CompareString(left, "D", TextCompare: true) == 0))))
										{
											if ((num6 == 2) | (num6 == 4) | ((num6 == 5) & (Operators.CompareString(left, "E", TextCompare: true) == 0)))
											{
												val24 = new Point2d(num25 + 2.5, borneJ3.ptInsTerm.Y);
												val25 = new Point2d(borneJ3.ptInsTerm.X - 1.5, borneJ3.ptInsTerm.Y);
											}
										}
										else
										{
											val24 = new Point2d(num25 - 2.5, borneJ3.ptInsTerm.Y);
											val25 = new Point2d(borneJ3.ptInsTerm.X + 1.5, borneJ3.ptInsTerm.Y);
										}
										ptInsTerm = borneJ3.ptInsTerm;
										num37 = 0.0;
									}
									val21.AddVertexAt(0, val22, 0.0, 0.0, 0.0);
									val21.AddVertexAt(1, val23, 0.0, 0.0, 0.0);
									val21.AddVertexAt(2, val24, 0.0, 0.0, 0.0);
									val21.AddVertexAt(3, val25, 0.0, 0.0, 0.0);
									val21.AddVertexAt(4, ptInsTerm, 0.0, 0.0, 0.0);
									val21.SetBulgeAt(1, num37);
									val4.AppendEntity((Entity)(object)val21);
									DeclaracoesGeral.bAnularEventos = true;
									val2.AddNewlyCreatedDBObject((DBObject)(object)val21, true);
									ent = (Entity)(object)val21;
									XDataAranha.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, veia2, borneJ3.Handle);
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
									if (!((num6 == 1) | (num6 == 3) | ((num6 == 5) & (Operators.CompareString(left, "D", TextCompare: true) == 0))))
									{
										if ((num6 == 2) | (num6 == 4) | ((num6 == 5) & (Operators.CompareString(left, "E", TextCompare: true) == 0)))
										{
											alignmentPoint = new Point3d(val24.X, val24.Y + 1.1, 0.0);
											val27.HorizontalMode = (TextHorizontalMode)0;
											val27.VerticalMode = (TextVerticalMode)2;
										}
									}
									else
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
									XDataAranha.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, veia2, "");
									val27 = (DBText)ent;
									if (!((borneJ3.Posicao == 5) & (Operators.CompareString(array[num34].LadoEntradaBorne, "D", TextCompare: true) == 0)))
									{
										mBornesJ[array[num34].indiceBorne].contVeiasLigadas++;
									}
									else
									{
										mBornesJ[array[num34].indiceBorne].contVeiasLigadas2++;
									}
								}
							}
							int num38 = Information.UBound(mInfoVeias);
							for (int num39 = 1; num39 <= num38; num39++)
							{
								if (Operators.CompareString(mInfoVeias[num39].tag_Cabo, mCabos[i].Tag_Cabo, TextCompare: true) != 0)
								{
									continue;
								}
								int num40 = Information.UBound(mInfoVeias[num39].mBornes) - 1;
								for (int num41 = 0; num41 <= num40; num41++)
								{
									ObjectId iD = mInfoVeias[num39].mBornes[num41].ID;
									string pagina3 = mInfoVeias[num39].mBornes[num41].pagina;
									string pagina4 = mInfoVeias[num39].mBornes[num41 + 1].pagina;
									BlockReference val28 = (BlockReference)val2.GetObject(iD, (OpenMode)0);
									AttributeCollection attributeCollection = val28.AttributeCollection;
									foreach (object item in attributeCollection)
									{
										ObjectId val29 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
										AttributeReference val30 = (AttributeReference)val29.GetObject((OpenMode)1);
										string text6 = mInfoVeias[num39].mBornes[num41 + 1].rb;
										if (Operators.CompareString(pagina3, pagina4, TextCompare: true) != 0)
										{
											text6 = text6 + DeclaracoesGeral.Conf.PrefixoCruzInterno + pagina4 + DeclaracoesGeral.Conf.SufixoCruzInterno;
										}
										string tag2 = val30.Tag;
										if (Operators.CompareString(tag2, "BORNE", TextCompare: true) == 0)
										{
											((DBText)val30).TextString = text6;
										}
										((Entity)val30).Draw();
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
						if (XDataAranha.LerXDataVeia(ref ent, ref revisao2, ref painel, ref tag_cabo, ref veia, ref handle) && ((Operators.CompareString(revisao, revisao2, TextCompare: true) == 0) & (Painel == painel)))
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
						if (XDataAranha.LerXDataVeia(ref ent, ref revisao2, ref painel, ref tag_cabo, ref veia, ref handle) && ((Operators.CompareString(revisao, revisao2, TextCompare: true) == 0) & (Painel == painel) & (Operators.CompareString(tag_cabo, Tag, TextCompare: true) == 0)))
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

	private static Hatch kqjp0JVh8h(Point3d P_0, string P_1)
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

	public static void EspelhaJumperLeft()
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected Obj, but got Unknown
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected Obj, but got Unknown
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected Obj, but got Unknown
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Invalid comparison between Unknown and I4
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Expected Obj, but got Unknown
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Expected Obj, but got Unknown
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected Obj, but got Unknown
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Expected Obj, but got Unknown
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		PointMonitorToolTips.StopMonitor();
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
					TypedValue[] array = new TypedValue[3];
					array.SetValue((object)new TypedValue(0, (object)"LWPOLYLINE"), 0);
					array.SetValue((object)new TypedValue(1001, (object)"ARANHA"), 1);
					array.SetValue((object)new TypedValue(1000, (object)"JUMPER"), 2);
					SelectionFilter val4 = new SelectionFilter(array);
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
					PromptSelectionOptions val5 = new PromptSelectionOptions();
					val5.MessageForAdding = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1535]);
					PromptSelectionResult selection = editor.GetSelection(val5, val4);
					if ((int)selection.Status == 5100)
					{
						SelectionSet value = selection.Value;
						ObjectIdCollection val6 = new ObjectIdCollection(value.GetObjectIds());
						int painel = default;
						foreach (object item in val6)
						{
							ObjectId val7 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							Polyline val8 = (Polyline)val7.GetObject((OpenMode)1);
							string revisao = "";
							DeclaracoesInterligacao.borneAranha bnO = default;
							DeclaracoesInterligacao.borneAranha bnD = default;
							Entity ent = (Entity)(object)val8;
							bool flag = XDataAranha.LerXDataJumper(ref ent, ref revisao, ref painel, ref bnO, ref bnD);
							val8 = (Polyline)ent;
							if (!flag)
							{
								continue;
							}
							double num = 0.0;
							if (bnO.TipoBorne != 0)
							{
								if (bnO.TipoBorne == 1)
								{
									num = 7.5;
								}
							}
							else
							{
								num = 5.0;
							}
							Point2d point2dAt = val8.GetPoint2dAt(0);
							double num2 = point2dAt.X - num;
							point2dAt = val8.GetPoint2dAt(0);
							Point3d val9 = new Point3d(num2, point2dAt.Y + 10.0, 0.0);
							point2dAt = val8.GetPoint2dAt(0);
							double num3 = point2dAt.X - num;
							point2dAt = val8.GetPoint2dAt(0);
							Point3d val10 = new Point3d(num3, point2dAt.Y, 0.0);
							Line3d val11 = new Line3d(val9, val10);
							((Entity)val8).TransformBy(Matrix3d.Mirroring(val11));
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
			PointMonitorToolTips.StartMonitor();
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void CarregaTodosCabosDWG(string revisao, ref DeclaracoesInterligacao.caboSync[] mCabosSync)
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
								bool flag = XDataAranha.LerXDataCabo(ref ent, ref revisao2, ref painel, ref cabo);
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
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Expected Obj, but got Unknown
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
								if (Operators.CompareString(tag, "FL", TextCompare: true) == 0)
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
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Expected Obj, but got Unknown
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
							bool flag = XDataAranha.LerXDataCabo(ref ent, ref revisao2, ref painel, ref cabo);
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
									((Entity)val7).Draw();
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
						if (XDataAranha.LerXDataBorne(ref blockRef, ref bn))
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

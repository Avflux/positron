using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
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

public class clsDICemig
{
	private struct sbQGSAp5JiNX4Kwc3m3x
	{
		public string PBnp5hAKFEL;

		public int ABFp5oXr4DV;
	}

	public static void InserirBorneAranha(string nomebloco, DeclaracoesInterligacao.borneAranha bn, Point3d ptIns, bool bInsereNomeRegua, ref DeclaracoesInterligacao.ConfigDInterlig cfgDI)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected Obj, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected Obj, but got Unknown
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Expected Obj, but got Unknown
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected Obj, but got Unknown
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected Obj, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Expected Obj, but got Unknown
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Expected Obj, but got Unknown
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Expected Obj, but got Unknown
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected Obj, but got Unknown
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Expected Obj, but got Unknown
		//IL_0395: Unknown result type (might be due to invalid IL or missing references)
		//IL_039a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Expected Obj, but got Unknown
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02da: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0328: Unknown result type (might be due to invalid IL or missing references)
		//IL_032d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0349: Unknown result type (might be due to invalid IL or missing references)
		//IL_034e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_036d: Unknown result type (might be due to invalid IL or missing references)
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
					string text2 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + cfgDI.diretorio + nomebloco;
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
						ObjectId textStyleId = (((SymbolTable)val12).Has(cfgDI.textStyle) ? ((SymbolTable)val12)[cfgDI.textStyle] : ((SymbolTable)val12)["Standard"]);
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
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
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
						int posicao = bn.Posicao;
						if (unchecked((uint)(posicao - 1)) <= 3u)
						{
							if (bn.TipoBorne != 0)
							{
								if (bn.TipoBorne == 1)
								{
									num2 = 10.0;
									num3 = -4.0;
								}
							}
							else
							{
								num2 = 10.0;
								num3 = -4.0;
							}
						}
						else if (posicao == 5)
						{
							if (bn.TipoBorne != 0)
							{
								if (bn.TipoBorne == 1)
								{
									num2 = 0.0;
									num3 = -4.0;
								}
							}
							else
							{
								num2 = 0.0;
								num3 = -4.0;
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
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected Obj, but got Unknown
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected Obj, but got Unknown
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_031d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		//IL_0337: Unknown result type (might be due to invalid IL or missing references)
		//IL_0353: Unknown result type (might be due to invalid IL or missing references)
		//IL_0358: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_030a: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0404: Unknown result type (might be due to invalid IL or missing references)
		//IL_040b: Unknown result type (might be due to invalid IL or missing references)
		//IL_040d: Unknown result type (might be due to invalid IL or missing references)
		//IL_040f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0411: Unknown result type (might be due to invalid IL or missing references)
		//IL_0413: Unknown result type (might be due to invalid IL or missing references)
		//IL_0415: Unknown result type (might be due to invalid IL or missing references)
		//IL_037b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0380: Unknown result type (might be due to invalid IL or missing references)
		//IL_0395: Unknown result type (might be due to invalid IL or missing references)
		//IL_039a: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Expected Obj, but got Unknown
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_0432: Unknown result type (might be due to invalid IL or missing references)
		//IL_053e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0545: Expected Obj, but got Unknown
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
						string handle2 = mBornesJ[(int)mJumpers[(int)index].indexDest].Handle;
						int tipoBorne2 = mBornesJ[(int)mJumpers[(int)index].indexDest].TipoBorne;
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
									position = val7.Position;
									double num = position.X + 10.0;
									position = val7.Position;
									val5 = new Point3d(num, position.Y - 12.0, 0.0);
								}
							}
							else
							{
								position = val7.Position;
								double num2 = position.X + 10.0;
								position = val7.Position;
								val5 = new Point3d(num2, position.Y - 4.0, 0.0);
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
									position = val9.Position;
									double num3 = position.X + 10.0;
									position = val9.Position;
									val8 = new Point3d(num3, position.Y - 12.0, 0.0);
								}
							}
							else
							{
								position = val9.Position;
								double num4 = position.X + 10.0;
								position = val9.Position;
								val8 = new Point3d(num4, position.Y - 4.0, 0.0);
							}
						}
						Point3d val10 = default;
						if (val5.Y < val8.Y)
						{
							val10 = val5;
							val5 = val8;
							val8 = val10;
						}
						double num5 = 2.5;
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
							if (!bnBpcVfvXO(val12.X, val12.Y, val13.Y, pagina, revisao, painel))
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

	private static bool bnBpcVfvXO(double P_0, double P_1, double P_2, string P_3, string P_4, int P_5)
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

	public static void DesenhaJumper2(string revisao, int painel, ref DeclaracoesInterligacao.borneJ[] mBornesJ, ref DeclaracoesInterligacao.jumper[] mJumpers, long index, ref DeclaracoesInterligacao.ConfigDInterlig cfgDI)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Expected Obj, but got Unknown
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Expected Obj, but got Unknown
		//IL_0681: Unknown result type (might be due to invalid IL or missing references)
		//IL_0686: Unknown result type (might be due to invalid IL or missing references)
		//IL_069b: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_0631: Unknown result type (might be due to invalid IL or missing references)
		//IL_0636: Unknown result type (might be due to invalid IL or missing references)
		//IL_064b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0650: Unknown result type (might be due to invalid IL or missing references)
		//IL_066c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0671: Unknown result type (might be due to invalid IL or missing references)
		//IL_073b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0740: Unknown result type (might be due to invalid IL or missing references)
		//IL_0755: Unknown result type (might be due to invalid IL or missing references)
		//IL_075a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0776: Unknown result type (might be due to invalid IL or missing references)
		//IL_077b: Unknown result type (might be due to invalid IL or missing references)
		//IL_078d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0798: Unknown result type (might be due to invalid IL or missing references)
		//IL_079f: Expected Obj, but got Unknown
		//IL_07a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Expected Obj, but got Unknown
		//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0705: Unknown result type (might be due to invalid IL or missing references)
		//IL_070a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0726: Unknown result type (might be due to invalid IL or missing references)
		//IL_072b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Expected Obj, but got Unknown
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Expected Obj, but got Unknown
		//IL_030e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_0316: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0325: Expected Obj, but got Unknown
		//IL_0333: Unknown result type (might be due to invalid IL or missing references)
		//IL_033a: Expected Obj, but got Unknown
		//IL_033a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0341: Expected Obj, but got Unknown
		//IL_0347: Unknown result type (might be due to invalid IL or missing references)
		//IL_0444: Unknown result type (might be due to invalid IL or missing references)
		//IL_044b: Expected Obj, but got Unknown
		//IL_0385: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c3: Expected Obj, but got Unknown
		//IL_07c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0479: Unknown result type (might be due to invalid IL or missing references)
		//IL_0480: Expected Obj, but got Unknown
		//IL_049c: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b5: Expected Obj, but got Unknown
		//IL_04c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e7: Expected Obj, but got Unknown
		//IL_04f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0507: Unknown result type (might be due to invalid IL or missing references)
		//IL_050e: Expected Obj, but got Unknown
		//IL_051c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0523: Expected Obj, but got Unknown
		//IL_0523: Unknown result type (might be due to invalid IL or missing references)
		//IL_052a: Expected Obj, but got Unknown
		//IL_0530: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f3: Expected Obj, but got Unknown
		//IL_056e: Unknown result type (might be due to invalid IL or missing references)
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
						string pagina = mBornesJ[(int)mJumpers[(int)index].indexOrig].Pagina;
						string tag2 = mBornesJ[(int)mJumpers[(int)index].indexDest].Tag;
						string nRegua2 = mBornesJ[(int)mJumpers[(int)index].indexDest].NRegua;
						string borne2 = mBornesJ[(int)mJumpers[(int)index].indexDest].Borne;
						string handle2 = mBornesJ[(int)mJumpers[(int)index].indexDest].Handle;
						int tipoBorne2 = mBornesJ[(int)mJumpers[(int)index].indexDest].TipoBorne;
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
									position = val7.Position;
									double num = position.X + 10.0;
									position = val7.Position;
									val5 = new Point3d(num, position.Y - 12.0, 0.0);
									text = "JumperSaiDireita";
								}
							}
							else
							{
								position = val7.Position;
								double num2 = position.X + 10.0;
								position = val7.Position;
								val5 = new Point3d(num2, position.Y - 4.0, 0.0);
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
									position = val9.Position;
									double num3 = position.X + 10.0;
									position = val9.Position;
									val8 = new Point3d(num3, position.Y - 12.0, 0.0);
									text2 = "JumperEntraDireita";
								}
							}
							else
							{
								position = val9.Position;
								double num4 = position.X + 10.0;
								position = val9.Position;
								val8 = new Point3d(num4, position.Y - 4.0, 0.0);
								text2 = "JumperEntraDireita";
							}
						}
						ObjectId val10 = ObjectId.Null;
						string text3 = "";
						text3 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + cfgDI.diretorio + text + ".dwg";
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
										text4 = text4 + DeclaracoesGeral.Conf.PrefixoCruzInterno + vA4peEvg2y(pagina2) + DeclaracoesGeral.Conf.SufixoCruzInterno;
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
						text3 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + cfgDI.diretorio + text2 + ".dwg";
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
										text5 = text5 + DeclaracoesGeral.Conf.PrefixoCruzInterno + vA4peEvg2y(pagina) + DeclaracoesGeral.Conf.SufixoCruzInterno;
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
									mCabos[num5].Coluna = 5;
									mCabos[num5].Lado = "D";
								}
								else
								{
									mCabos[num5].Coluna = 5;
									mCabos[num5].Lado = "E";
								}
								break;
							case 1:
								mCabos[num5].Coluna = 1;
								mCabos[num5].Lado = "D";
								break;
							case 2:
								mCabos[num5].Coluna = 2;
								mCabos[num5].Lado = "D";
								break;
							case 3:
								mCabos[num5].Coluna = 3;
								mCabos[num5].Lado = "D";
								break;
							case 4:
								mCabos[num5].Coluna = 4;
								mCabos[num5].Lado = "D";
								break;
							}
							mCabos[num5].Y = mBornesJ[i].Y - 4.0;
							while (true)
							{
								int num6 = Information.UBound(mCabos);
								int num7 = 1;
								while (num7 <= num6)
								{
									if (!((num7 != num5) & (Operators.CompareString(mCabos[num7].Pagina, mCabos[num5].Pagina, TextCompare: true) == 0) & (mCabos[num7].Coluna == mCabos[num5].Coluna) & (Operators.CompareString(mCabos[num7].Lado, mCabos[num5].Lado, TextCompare: true) == 0) & (mCabos[num7].Y == mCabos[num5].Y)))
									{
										num7++;
										continue;
									}
									goto IL_05d4;
								}
								break;
								IL_05d4:
								mCabos[num5].Y -= 8.0;
							}
						}
					}
				}
			}
			cDadosAccessInterligacao3.fechaConexao();
		}
	}

	public static void InsereCabos(string revisao, int Painel, ref DeclaracoesInterligacao.caboAranha[] mCabos, List<string> lCabosInseridos, ref DeclaracoesInterligacao.ConfigDInterlig cfgDI)
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected Obj, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected Obj, but got Unknown
		//IL_0505: Unknown result type (might be due to invalid IL or missing references)
		//IL_050a: Unknown result type (might be due to invalid IL or missing references)
		//IL_052a: Unknown result type (might be due to invalid IL or missing references)
		//IL_052f: Unknown result type (might be due to invalid IL or missing references)
		//IL_054f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0554: Unknown result type (might be due to invalid IL or missing references)
		//IL_0574: Unknown result type (might be due to invalid IL or missing references)
		//IL_0579: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0476: Unknown result type (might be due to invalid IL or missing references)
		//IL_047b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Expected Obj, but got Unknown
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Expected Obj, but got Unknown
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ba: Expected Obj, but got Unknown
		//IL_06c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d3: Expected Obj, but got Unknown
		//IL_06d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06da: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Expected Obj, but got Unknown
		//IL_0464: Unknown result type (might be due to invalid IL or missing references)
		//IL_046b: Expected Obj, but got Unknown
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fd: Expected Obj, but got Unknown
		//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0304: Expected Obj, but got Unknown
		//IL_030a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0381: Unknown result type (might be due to invalid IL or missing references)
		DeclaracoesGeral.Reguas RH = default;
		checked
		{
			if (XDataGeral.LeXDataReguaH(ref RH))
			{
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
							int num = 0;
							double num2 = 0.0;
							if (!cfgDI.bA1)
							{
								num = 3;
								num2 = 70.0;
							}
							else
							{
								num = 4;
								num2 = 80.0;
							}
							double num3 = (RH.LarguraBase - RH.Pti.X) / (double)num;
							double num4 = RH.Pti.X + num3 * 1.0 - num2;
							double num5 = RH.Pti.X + num3 * 2.0 - num2;
							double num6 = RH.Pti.X + num3 * 3.0 - num2;
							double num7 = RH.Pti.X + num3 * 4.0 - num2;
							double num8 = 0.0;
							num8 = ((num == 4) ? (RH.Pti.X + num3 * 1.0 + num2) : (RH.Pti.X + num2));
							int num9 = Information.UBound(mCabos);
							Point3d val5 = default;
							BlockTableRecordEnumerator enumerator = default;
							for (int i = 1; i <= num9; i++)
							{
								if (lCabosInseridos.Contains(mCabos[i].Tag_Cabo))
								{
									continue;
								}
								string text = "";
								switch (mCabos[i].Coluna)
								{
								case 5:
									if (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) != 0)
									{
										if (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0)
										{
											val5 = new Point3d(num8, mCabos[i].Y, 0.0);
										}
									}
									else
									{
										val5 = ((num == 4) ? new Point3d(num6, mCabos[i].Y, 0.0) : new Point3d(num6, mCabos[i].Y, 0.0));
									}
									break;
								case 1:
									val5 = new Point3d(num4, mCabos[i].Y, 0.0);
									break;
								case 2:
									val5 = new Point3d(num5, mCabos[i].Y, 0.0);
									break;
								case 3:
									val5 = new Point3d(num6, mCabos[i].Y, 0.0);
									break;
								case 4:
									val5 = new Point3d(num7, mCabos[i].Y, 0.0);
									break;
								}
								if (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) == 0)
								{
									if (mCabos[i].Blindagem)
									{
										if (mCabos[i].bAterrar)
										{
											text = "CaboDBA";
										}
										else
										{
											text = (mCabos[i].bParTrioTrancado ? "CaboDBNA" : "CaboDBNA");
										}
									}
									else
									{
										text = "CaboD";
									}
								}
								else if (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0)
								{
									if (mCabos[i].Blindagem)
									{
										if (mCabos[i].bAterrar)
										{
											text = "CaboEBA";
										}
										else
										{
											text = (mCabos[i].bParTrioTrancado ? "CaboEBNA" : "CaboEBNA");
										}
									}
									else
									{
										text = "CaboE";
									}
								}
								ObjectId val6 = ObjectId.Null;
								string text2 = "";
								text2 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + cfgDI.diretorio + text + ".dwg";
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
												if (Operators.CompareString(left, "TAG", TextCompare: true) != 0)
												{
													if (Operators.CompareString(left, "VEIA", TextCompare: true) == 0)
													{
														((DBText)val13).TextString = Conversions.ToString(mCabos[i].lVeiasLivres.Count + mCabos[i].lVeiasUsadas.Count);
													}
												}
												else
												{
													((DBText)val13).TextString = mCabos[i].Tag_Cabo;
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
							return;
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							val2.Abort();
							Interaction.MsgBox(ex2.Message, MsgBoxStyle.Information);
							ProjectData.ClearProjectError();
							return;
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
			Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 611]), MsgBoxStyle.Information);
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
		sbQGSAp5JiNX4Kwc3m3x[] array = new sbQGSAp5JiNX4Kwc3m3x[1];
		int num = Information.UBound(mCabos);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				mCabos[i].mDestinos = new DeclaracoesInterligacao.borneDestino[1];
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
									if ((Operators.CompareString(array[n].PBnp5hAKFEL, tag_Cabo, TextCompare: true) == 0) & (array[n].ABFp5oXr4DV == veia))
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
									array = (sbQGSAp5JiNX4Kwc3m3x[])Utils.CopyArray(array, new sbQGSAp5JiNX4Kwc3m3x[Information.UBound(array) + 1 + 1]);
									array[Information.UBound(array)].PBnp5hAKFEL = tag_Cabo;
									array[Information.UBound(array)].ABFp5oXr4DV = veia;
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

	public static void InsereVeias(string revisao, int Painel, ref DeclaracoesInterligacao.borneJ[] mBornesJ, ref DeclaracoesInterligacao.caboAranha[] mCabos, ref DeclaracoesInterligacao.cruzamentoCaboAranha[] mInfoVeias, List<string> lCabosInseridos, ref DeclaracoesInterligacao.ConfigDInterlig cfgDI)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06da: Unknown result type (might be due to invalid IL or missing references)
		//IL_06dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e3: Expected Obj, but got Unknown
		//IL_0713: Unknown result type (might be due to invalid IL or missing references)
		//IL_0738: Unknown result type (might be due to invalid IL or missing references)
		//IL_075e: Unknown result type (might be due to invalid IL or missing references)
		//IL_078e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0795: Expected Obj, but got Unknown
		//IL_07ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd7: Unknown result type (might be due to invalid IL or missing references)
		//IL_088d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0894: Expected Obj, but got Unknown
		//IL_1088: Unknown result type (might be due to invalid IL or missing references)
		//IL_1093: Unknown result type (might be due to invalid IL or missing references)
		//IL_109a: Expected Obj, but got Unknown
		//IL_109c: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e07: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e0e: Expected Obj, but got Unknown
		//IL_0e2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e54: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e56: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e5d: Expected Obj, but got Unknown
		//IL_0e76: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e94: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e9b: Expected Obj, but got Unknown
		//IL_10e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0931: Unknown result type (might be due to invalid IL or missing references)
		//IL_0936: Unknown result type (might be due to invalid IL or missing references)
		//IL_114c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ea8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ead: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eb0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eb8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ebf: Expected Obj, but got Unknown
		//IL_1221: Unknown result type (might be due to invalid IL or missing references)
		//IL_1223: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ecd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ed4: Expected Obj, but got Unknown
		//IL_0ed4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0edb: Expected Obj, but got Unknown
		//IL_0ee1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0efc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f64: Expected Obj, but got Unknown
		//IL_1008: Unknown result type (might be due to invalid IL or missing references)
		//IL_100d: Unknown result type (might be due to invalid IL or missing references)
		//IL_12c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_12cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_12f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1345: Unknown result type (might be due to invalid IL or missing references)
		//IL_1347: Unknown result type (might be due to invalid IL or missing references)
		//IL_1614: Unknown result type (might be due to invalid IL or missing references)
		//IL_1619: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c24: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c49: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c93: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cf2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cf9: Expected Obj, but got Unknown
		//IL_0cfb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d06: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d0d: Expected Obj, but got Unknown
		//IL_1297: Unknown result type (might be due to invalid IL or missing references)
		//IL_129c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1310: Unknown result type (might be due to invalid IL or missing references)
		//IL_1315: Unknown result type (might be due to invalid IL or missing references)
		//IL_1339: Unknown result type (might be due to invalid IL or missing references)
		//IL_133e: Unknown result type (might be due to invalid IL or missing references)
		//IL_13f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_13fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_142a: Unknown result type (might be due to invalid IL or missing references)
		//IL_142f: Unknown result type (might be due to invalid IL or missing references)
		//IL_118e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1190: Unknown result type (might be due to invalid IL or missing references)
		//IL_16b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_16b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_16da: Unknown result type (might be due to invalid IL or missing references)
		//IL_16df: Unknown result type (might be due to invalid IL or missing references)
		//IL_1754: Unknown result type (might be due to invalid IL or missing references)
		//IL_1759: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_09bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_13be: Unknown result type (might be due to invalid IL or missing references)
		//IL_13c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1458: Unknown result type (might be due to invalid IL or missing references)
		//IL_145d: Unknown result type (might be due to invalid IL or missing references)
		//IL_148b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1490: Unknown result type (might be due to invalid IL or missing references)
		//IL_14af: Unknown result type (might be due to invalid IL or missing references)
		//IL_14b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_14d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_14dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_168d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1692: Unknown result type (might be due to invalid IL or missing references)
		//IL_1706: Unknown result type (might be due to invalid IL or missing references)
		//IL_170b: Unknown result type (might be due to invalid IL or missing references)
		//IL_172f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1734: Unknown result type (might be due to invalid IL or missing references)
		//IL_1813: Unknown result type (might be due to invalid IL or missing references)
		//IL_1818: Unknown result type (might be due to invalid IL or missing references)
		//IL_1846: Unknown result type (might be due to invalid IL or missing references)
		//IL_184b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1571: Unknown result type (might be due to invalid IL or missing references)
		//IL_1576: Unknown result type (might be due to invalid IL or missing references)
		//IL_09bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c4: Expected Obj, but got Unknown
		//IL_09e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dfe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e03: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a71: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a76: Unknown result type (might be due to invalid IL or missing references)
		//IL_120a: Unknown result type (might be due to invalid IL or missing references)
		//IL_120f: Unknown result type (might be due to invalid IL or missing references)
		//IL_14fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1501: Unknown result type (might be due to invalid IL or missing references)
		//IL_1525: Unknown result type (might be due to invalid IL or missing references)
		//IL_152a: Unknown result type (might be due to invalid IL or missing references)
		//IL_187f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1884: Unknown result type (might be due to invalid IL or missing references)
		//IL_18b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_18b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_18f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_18fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_191f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1924: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b13: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b37: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bbb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bc0: Unknown result type (might be due to invalid IL or missing references)
		//IL_18d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_18d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_17e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_17ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_15f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_15f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_194e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1953: Unknown result type (might be due to invalid IL or missing references)
		//IL_1977: Unknown result type (might be due to invalid IL or missing references)
		//IL_197c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1aea: Unknown result type (might be due to invalid IL or missing references)
		//IL_1aef: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b63: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b68: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b91: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cad: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cb2: Unknown result type (might be due to invalid IL or missing references)
		//IL_19ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_19d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e36: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e3b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ce6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ceb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d19: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d62: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d86: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a85: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab9: Expected Obj, but got Unknown
		//IL_0ac0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac7: Expected Obj, but got Unknown
		//IL_0ad7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e69: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d39: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c51: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a52: Unknown result type (might be due to invalid IL or missing references)
		//IL_1db5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dba: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dde: Unknown result type (might be due to invalid IL or missing references)
		//IL_1de3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ebb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ec0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ed4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f34: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f39: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bcc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd3: Expected Obj, but got Unknown
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
						double num = 0.0;
						num = (cfgDI.bA1 ? 10.0 : 6.0);
						int num2 = Information.UBound(mCabos);
						double num12 = default;
						BlockTableRecordEnumerator enumerator = default;
						Point2d val20 = default;
						Point2d val21 = default;
						Point2d val22 = default;
						Point2d val23 = default;
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
								double num10 = 0.0;
								int num11 = 0;
								if (!((borneJ.Posicao == 5) & (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) == 0)))
								{
									num11 = borneJ.contVeiasLigadas;
								}
								else
								{
									if (borneJ.TipoBorne != 0)
									{
										if (borneJ.TipoBorne == 1)
										{
											num10 = 10.0;
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
											num9 = 8.0;
										}
									}
									else
									{
										num9 = 4.0;
									}
								}
								new Point2d(mCabos[i].ptIns.X, mCabos[i].ptIns.Y);
								Point2d val5 = new Point2d(borneJ.ptInsTerm.X, borneJ.ptInsTerm.Y - num9);
								if (Operators.CompareString(mCabos[i].Pagina, borneJ.Pagina, TextCompare: true) == 0 && (((mCabos[i].Coluna == 1) & (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) == 0) & (borneJ.Posicao == 1)) | ((mCabos[i].Coluna == 2) & (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) == 0) & (borneJ.Posicao == 2)) | ((mCabos[i].Coluna == 3) & (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) == 0) & (borneJ.Posicao == 3)) | ((mCabos[i].Coluna == 4) & (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) == 0) & (borneJ.Posicao == 4)) | ((mCabos[i].Coluna == 5) & (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) == 0) & (borneJ.Posicao == 5)) | ((mCabos[i].Coluna == 5) & (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0) & (borneJ.Posicao == 5))))
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
									array = (object[,])Utils.CopyArray(array, new object[5, num13 + 1]);
									array[0, num13] = num8;
									array[1, num13] = text;
									array[2, num13] = tagDest;
									array[3, num13] = nReguaDest;
									array[4, num13] = borneDest;
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
							double num14 = 0.0;
							num14 = (cfgDI.bA1 ? 30.0 : 20.0);
							if (Information.UBound(array, 2) <= 0)
							{
								continue;
							}
							do
							{
								if ((mCabos[i].Coluna >= 1) & (mCabos[i].Coluna <= 5) & (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) == 0) & ((num6 >= 1) & (num6 <= 5)))
								{
									num12 = ((num12 - num5 < num14) ? (num12 + num14) : (num12 + num));
								}
								else if ((mCabos[i].Coluna == 5) & (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0) & (num6 == 5))
								{
									num12 = ((num5 - num12 < num14) ? (num12 - num14) : (num12 - num));
								}
							}
							while (bnBpcVfvXO(num12, num3, num4, mCabos[i].Pagina, revisao, Painel));
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
							Hatch val9 = mpIpKTbioB(new Point3d(val6.X, val6.Y, 0.0), mCabos[i].Pagina);
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
							int num15 = Information.UBound(array, 2);
							if (count > num15)
							{
								string text2 = "";
								if (!(((num6 >= 1) & (num6 <= 4)) | ((num6 == 5) & (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) == 0))))
								{
									if ((num6 == 5) & (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0))
									{
										text2 = "VeiaSaiEsquerda";
									}
								}
								else
								{
									text2 = "VeiaSaiDireita";
								}
								ObjectId val10 = ObjectId.Null;
								string text3 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + cfgDI.diretorio + text2 + ".dwg";
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
							int num16 = Information.UBound(array, 2);
							for (int k = 1; k <= num16; k++)
							{
								int num17 = Conversions.ToInteger(array[0, k]);
								string text4 = Conversions.ToString(array[1, k]);
								string text5 = Conversions.ToString(array[2, k]);
								string text6 = Conversions.ToString(array[3, k]);
								string text7 = Conversions.ToString(array[4, k]);
								DeclaracoesInterligacao.borneJ borneJ2 = mBornesJ[num17];
								Polyline val18 = new Polyline();
								((Entity)val18).SetDatabaseDefaults();
								((Entity)val18).ColorIndex = 7;
								((Entity)val18).Layer = mCabos[i].Pagina;
								((Entity)val18).LineWeight = (LineWeight)9;
								double num18 = 0.0;
								int num19 = 0;
								bool flag = false;
								if (!((borneJ2.Posicao == 5) & (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) == 0)))
								{
									num19 = borneJ2.contVeiasLigadas;
								}
								else
								{
									flag = true;
									if (borneJ2.TipoBorne != 0)
									{
										if (borneJ2.TipoBorne == 1)
										{
											num18 = 10.0;
										}
									}
									else
									{
										num18 = 10.0;
									}
									borneJ2.ptInsTerm = new Point2d(borneJ2.ptInsTerm.X + num18, borneJ2.ptInsTerm.Y);
									num19 = borneJ2.contVeiasLigadas2;
								}
								if (num19 == 1 && borneJ2.TipoBorne == 1)
								{
									mBornesJ[num17].ptInsTerm = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y - 8.0);
									borneJ2 = mBornesJ[num17];
								}
								double num20 = 0.0;
								Point2d val19 = new Point2d(num12, mCabos[i].ptIns.Y);
								if (mCabos[i].ptIns.Y != borneJ2.ptInsTerm.Y)
								{
									if (!(mCabos[i].ptIns.Y > borneJ2.ptInsTerm.Y))
									{
										if (mCabos[i].ptIns.Y < borneJ2.ptInsTerm.Y)
										{
											if (num19 != 0)
											{
												if (borneJ2.TipoBorne != 0)
												{
													if (borneJ2.TipoBorne == 1)
													{
														val20 = new Point2d(num12, borneJ2.ptInsTerm.Y - 4.0);
														if (!(((num6 >= 1) & (num6 <= 4)) | ((num6 == 5) & (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) == 0))))
														{
															if ((num6 == 5) & (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0))
															{
																val21 = new Point2d(num12 + 4.0, borneJ2.ptInsTerm.Y);
																val22 = new Point2d(borneJ2.ptInsTerm.X - 1.5, borneJ2.ptInsTerm.Y);
																num20 = -0.42;
															}
														}
														else
														{
															val21 = new Point2d(num12 - 4.0, borneJ2.ptInsTerm.Y);
															val22 = new Point2d(borneJ2.ptInsTerm.X + 1.5, borneJ2.ptInsTerm.Y);
															num20 = 0.42;
														}
														val23 = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y);
													}
												}
												else
												{
													val20 = new Point2d(num12, borneJ2.ptInsTerm.Y - 8.0);
													if (!(((num6 >= 1) & (num6 <= 4)) | ((num6 == 5) & (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) == 0))))
													{
														if ((num6 == 5) & (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0))
														{
															val21 = new Point2d(num12 + 4.0, borneJ2.ptInsTerm.Y - 4.0);
															val22 = new Point2d(borneJ2.ptInsTerm.X - 1.5, borneJ2.ptInsTerm.Y - 4.0);
															num20 = -0.42;
														}
													}
													else
													{
														val21 = new Point2d(num12 - 4.0, borneJ2.ptInsTerm.Y - 4.0);
														val22 = new Point2d(borneJ2.ptInsTerm.X + 1.5, borneJ2.ptInsTerm.Y - 4.0);
														num20 = 0.42;
													}
													if (val20.Y == val21.Y)
													{
														val20 = new Point2d(num12, val19.Y);
													}
													val23 = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y);
												}
											}
											else
											{
												val20 = new Point2d(num12, borneJ2.ptInsTerm.Y - 4.0);
												if (!(((num6 >= 1) & (num6 <= 4)) | ((num6 == 5) & (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) == 0))))
												{
													if ((num6 == 5) & (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0))
													{
														val21 = new Point2d(num12 + 4.0, borneJ2.ptInsTerm.Y);
														val22 = new Point2d(borneJ2.ptInsTerm.X - 1.5, borneJ2.ptInsTerm.Y);
														num20 = -0.42;
													}
												}
												else
												{
													val21 = new Point2d(num12 - 4.0, borneJ2.ptInsTerm.Y);
													val22 = new Point2d(borneJ2.ptInsTerm.X + 1.5, borneJ2.ptInsTerm.Y);
													num20 = 0.42;
												}
												val23 = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y);
											}
										}
									}
									else if (num19 != 0)
									{
										if (borneJ2.TipoBorne != 0)
										{
											if (borneJ2.TipoBorne == 1)
											{
												val20 = new Point2d(num12, borneJ2.ptInsTerm.Y + 4.0);
												if (!(((num6 >= 1) & (num6 <= 4)) | ((num6 == 5) & (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) == 0))))
												{
													if ((num6 == 5) & (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0))
													{
														val21 = new Point2d(num12 + 4.0, borneJ2.ptInsTerm.Y);
														val22 = new Point2d(borneJ2.ptInsTerm.X - 1.5, borneJ2.ptInsTerm.Y);
														num20 = 0.42;
													}
												}
												else
												{
													val21 = new Point2d(num12 - 4.0, borneJ2.ptInsTerm.Y);
													val22 = new Point2d(borneJ2.ptInsTerm.X + 1.5, borneJ2.ptInsTerm.Y);
													num20 = -0.42;
												}
												val23 = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y);
											}
										}
										else
										{
											val20 = new Point2d(num12, borneJ2.ptInsTerm.Y);
											if (!(((num6 >= 1) & (num6 <= 4)) | ((num6 == 5) & (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) == 0))))
											{
												if ((num6 == 5) & (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0))
												{
													val21 = new Point2d(num12 + 4.0, borneJ2.ptInsTerm.Y - 4.0);
													val22 = new Point2d(borneJ2.ptInsTerm.X - 1.5, borneJ2.ptInsTerm.Y - 4.0);
													num20 = 0.42;
												}
											}
											else
											{
												val21 = new Point2d(num12 - 4.0, borneJ2.ptInsTerm.Y - 4.0);
												val22 = new Point2d(borneJ2.ptInsTerm.X + 1.5, borneJ2.ptInsTerm.Y - 4.0);
												num20 = -0.42;
											}
											if (val20.Y == val21.Y)
											{
												val20 = new Point2d(num12, val19.Y);
											}
											val23 = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y);
										}
									}
									else
									{
										val20 = new Point2d(num12, borneJ2.ptInsTerm.Y + 4.0);
										if (!(((num6 >= 1) & (num6 <= 4)) | ((num6 == 5) & (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) == 0))))
										{
											if ((num6 == 5) & (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0))
											{
												val21 = new Point2d(num12 + 4.0, borneJ2.ptInsTerm.Y);
												val22 = new Point2d(borneJ2.ptInsTerm.X - 1.5, borneJ2.ptInsTerm.Y);
												num20 = 0.42;
											}
										}
										else
										{
											val21 = new Point2d(num12 - 4.0, borneJ2.ptInsTerm.Y);
											val22 = new Point2d(borneJ2.ptInsTerm.X + 1.5, borneJ2.ptInsTerm.Y);
											num20 = -0.42;
										}
										val23 = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y);
									}
								}
								else if (num19 != 0)
								{
									if (borneJ2.TipoBorne != 0)
									{
										if (borneJ2.TipoBorne == 1)
										{
											val20 = val19;
											if (!(((num6 >= 1) & (num6 <= 4)) | ((num6 == 5) & (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) == 0))))
											{
												if ((num6 == 5) & (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0))
												{
													val21 = new Point2d(num12 + 4.0, borneJ2.ptInsTerm.Y);
													val22 = new Point2d(borneJ2.ptInsTerm.X - 1.5, borneJ2.ptInsTerm.Y);
												}
											}
											else
											{
												val21 = new Point2d(num12 - 4.0, borneJ2.ptInsTerm.Y);
												val22 = new Point2d(borneJ2.ptInsTerm.X + 1.5, borneJ2.ptInsTerm.Y);
											}
											val23 = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y);
											num20 = 0.0;
										}
									}
									else
									{
										val20 = val19;
										if (!(((num6 >= 1) & (num6 <= 4)) | ((num6 == 5) & (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) == 0))))
										{
											if ((num6 == 5) & (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0))
											{
												val21 = new Point2d(num12 + 4.0, borneJ2.ptInsTerm.Y - 4.0);
												val22 = new Point2d(borneJ2.ptInsTerm.X - 1.5, borneJ2.ptInsTerm.Y - 4.0);
											}
										}
										else
										{
											val21 = new Point2d(num12 - 4.0, borneJ2.ptInsTerm.Y - 4.0);
											val22 = new Point2d(borneJ2.ptInsTerm.X + 1.5, borneJ2.ptInsTerm.Y - 4.0);
										}
										val23 = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y);
										num20 = -0.42;
									}
								}
								else
								{
									val20 = val19;
									if (!(((num6 >= 1) & (num6 <= 4)) | ((num6 == 5) & (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) == 0))))
									{
										if ((num6 == 5) & (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0))
										{
											val21 = new Point2d(num12 + 4.0, borneJ2.ptInsTerm.Y);
											val22 = new Point2d(borneJ2.ptInsTerm.X - 1.5, borneJ2.ptInsTerm.Y);
										}
									}
									else
									{
										val21 = new Point2d(num12 - 4.0, borneJ2.ptInsTerm.Y);
										val22 = new Point2d(borneJ2.ptInsTerm.X + 1.5, borneJ2.ptInsTerm.Y);
									}
									val23 = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y);
									num20 = 0.0;
								}
								val18.AddVertexAt(0, val19, 0.0, 0.0, 0.0);
								val18.AddVertexAt(1, val20, 0.0, 0.0, 0.0);
								val18.AddVertexAt(2, val21, 0.0, 0.0, 0.0);
								val18.AddVertexAt(3, val22, 0.0, 0.0, 0.0);
								val18.AddVertexAt(4, val23, 0.0, 0.0, 0.0);
								val18.SetBulgeAt(1, num20);
								val4.AppendEntity((Entity)(object)val18);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val18, true);
								ent = (Entity)(object)val18;
								XDataAranha.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, text4, borneJ2.Handle);
								val18 = (Polyline)ent;
								TextStyleTable val24 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)0);
								ObjectId textStyleId = (((SymbolTable)val24).Has(cfgDI.textStyle) ? ((SymbolTable)val24)[cfgDI.textStyle] : ((SymbolTable)val24)["Standard"]);
								DBText val25 = new DBText();
								val25.TextString = text4;
								((Entity)val25).ColorIndex = 7;
								((Entity)val25).Layer = ((Entity)val18).Layer;
								val25.TextStyleId = textStyleId;
								val25.WidthFactor = 0.9;
								if (!cfgDI.bA1)
								{
									val25.Height = 1.8;
								}
								else
								{
									val25.Height = 2.0;
								}
								if (!(((num6 >= 1) & (num6 <= 4)) | ((num6 == 5) & (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) == 0))))
								{
									if ((num6 == 5) & (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0))
									{
										alignmentPoint = new Point3d(val21.X, val21.Y, 0.0);
										val25.HorizontalMode = (TextHorizontalMode)0;
										val25.VerticalMode = (TextVerticalMode)1;
									}
								}
								else
								{
									alignmentPoint = new Point3d(val21.X, val21.Y, 0.0);
									val25.HorizontalMode = (TextHorizontalMode)2;
									val25.VerticalMode = (TextVerticalMode)1;
								}
								val25.AlignmentPoint = alignmentPoint;
								val4.AppendEntity((Entity)(object)val25);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val25, true);
								ent = (Entity)(object)val25;
								XDataAranha.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, text4, "");
								val25 = (DBText)ent;
								string text8 = "";
								DBText val26 = new DBText();
								((Entity)val26).Layer = ((Entity)val18).Layer;
								val26.TextStyleId = textStyleId;
								val26.WidthFactor = 0.85;
								val26.Rotation = 0.0;
								((Entity)val26).ColorIndex = 7;
								val26.Oblique = 0.0;
								if (!cfgDI.bA1)
								{
									val26.Height = 1.8;
								}
								else
								{
									val26.Height = 2.0;
								}
								if (!(((num6 >= 1) & (num6 <= 4)) | ((num6 == 5) & (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) == 0))))
								{
									if ((num6 == 5) & (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0))
									{
										Point3d alignmentPoint2 = new Point3d(val22.X - 2.5, val22.Y, 0.0);
										val26.HorizontalMode = (TextHorizontalMode)2;
										val26.VerticalMode = (TextVerticalMode)1;
										val26.AlignmentPoint = alignmentPoint2;
										text8 = ((Operators.CompareString(text6, "", TextCompare: true) != 0) ? text6 : (text8 + text5));
										text8 = text8 + "-" + text7;
									}
								}
								else
								{
									Point3d alignmentPoint2 = new Point3d(val22.X + 2.5, val22.Y, 0.0);
									val26.HorizontalMode = (TextHorizontalMode)0;
									val26.VerticalMode = (TextVerticalMode)1;
									val26.AlignmentPoint = alignmentPoint2;
									text8 = ((Operators.CompareString(text6, "", TextCompare: true) != 0) ? text6 : (text8 + text5));
									text8 = text8 + "-" + text7;
								}
								val26.TextString = text8;
								val4.AppendEntity((Entity)(object)val26);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val26, true);
								ent = (Entity)(object)val26;
								XDataAranha.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, text4, "");
								val26 = (DBText)ent;
								if (!flag)
								{
									mBornesJ[num17].contVeiasLigadas++;
								}
								else
								{
									mBornesJ[num17].contVeiasLigadas2++;
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

	public static void InsereVeias2(string revisao, int Painel, ref DeclaracoesInterligacao.borneJ[] mBornesJ, ref DeclaracoesInterligacao.caboAranha[] mCabos, ref DeclaracoesInterligacao.cruzamentoCaboAranha[] mInfoVeias, List<string> lCabosInseridos, ref DeclaracoesInterligacao.ConfigDInterlig cfgDI)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_268f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2694: Unknown result type (might be due to invalid IL or missing references)
		//IL_26d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_26db: Unknown result type (might be due to invalid IL or missing references)
		//IL_26e2: Expected Obj, but got Unknown
		//IL_097f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0984: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_08db: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab8: Unknown result type (might be due to invalid IL or missing references)
		//IL_2774: Unknown result type (might be due to invalid IL or missing references)
		//IL_277a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2700: Unknown result type (might be due to invalid IL or missing references)
		//IL_2705: Unknown result type (might be due to invalid IL or missing references)
		//IL_270f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2716: Expected Obj, but got Unknown
		//IL_0b62: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b67: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d29: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d30: Expected Obj, but got Unknown
		//IL_0d32: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d37: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b97: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b9e: Expected Obj, but got Unknown
		//IL_0bba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bbf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bdf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bed: Expected Obj, but got Unknown
		//IL_0c06: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c24: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c2b: Expected Obj, but got Unknown
		//IL_0d95: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0da5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dac: Expected Obj, but got Unknown
		//IL_0dba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc1: Expected Obj, but got Unknown
		//IL_0dc1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc8: Expected Obj, but got Unknown
		//IL_0dce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e84: Expected Obj, but got Unknown
		//IL_0e0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f77: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_116e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1179: Unknown result type (might be due to invalid IL or missing references)
		//IL_1180: Expected Obj, but got Unknown
		//IL_1182: Unknown result type (might be due to invalid IL or missing references)
		//IL_1187: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb3: Expected Obj, but got Unknown
		//IL_0fcf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fd4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ff4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ff9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ffb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1002: Expected Obj, but got Unknown
		//IL_101b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1031: Unknown result type (might be due to invalid IL or missing references)
		//IL_1039: Unknown result type (might be due to invalid IL or missing references)
		//IL_1040: Expected Obj, but got Unknown
		//IL_1821: Unknown result type (might be due to invalid IL or missing references)
		//IL_1826: Unknown result type (might be due to invalid IL or missing references)
		//IL_130b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1312: Expected Obj, but got Unknown
		//IL_104d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1052: Unknown result type (might be due to invalid IL or missing references)
		//IL_1055: Unknown result type (might be due to invalid IL or missing references)
		//IL_105d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1064: Expected Obj, but got Unknown
		//IL_1072: Unknown result type (might be due to invalid IL or missing references)
		//IL_1079: Expected Obj, but got Unknown
		//IL_1079: Unknown result type (might be due to invalid IL or missing references)
		//IL_1080: Expected Obj, but got Unknown
		//IL_1086: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1102: Unknown result type (might be due to invalid IL or missing references)
		//IL_1109: Expected Obj, but got Unknown
		//IL_18e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_18e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1394: Unknown result type (might be due to invalid IL or missing references)
		//IL_1399: Unknown result type (might be due to invalid IL or missing references)
		//IL_1950: Unknown result type (might be due to invalid IL or missing references)
		//IL_1955: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a09: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a0b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a86: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1aaf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ab4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b05: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b07: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d83: Unknown result type (might be due to invalid IL or missing references)
		//IL_1636: Unknown result type (might be due to invalid IL or missing references)
		//IL_165b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1680: Unknown result type (might be due to invalid IL or missing references)
		//IL_16a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_16ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_16fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_1729: Unknown result type (might be due to invalid IL or missing references)
		//IL_1730: Expected Obj, but got Unknown
		//IL_1732: Unknown result type (might be due to invalid IL or missing references)
		//IL_173d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1744: Expected Obj, but got Unknown
		//IL_1234: Unknown result type (might be due to invalid IL or missing references)
		//IL_1239: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a57: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ad0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ad5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1af9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1afe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b91: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bbf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bc4: Unknown result type (might be due to invalid IL or missing references)
		//IL_199e: Unknown result type (might be due to invalid IL or missing references)
		//IL_19a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1df3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1df8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e21: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e96: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_13e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_13eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b53: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b58: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bea: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bef: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c1d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c22: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c41: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c46: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c6a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dcf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dd4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e48: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e71: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e76: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f32: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f60: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f65: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d03: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d08: Unknown result type (might be due to invalid IL or missing references)
		//IL_13ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_13f4: Expected Obj, but got Unknown
		//IL_1425: Unknown result type (might be due to invalid IL or missing references)
		//IL_2478: Unknown result type (might be due to invalid IL or missing references)
		//IL_247d: Unknown result type (might be due to invalid IL or missing references)
		//IL_214f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2154: Unknown result type (might be due to invalid IL or missing references)
		//IL_19f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_19f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c93: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cbc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f99: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fcc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fd1: Unknown result type (might be due to invalid IL or missing references)
		//IL_2010: Unknown result type (might be due to invalid IL or missing references)
		//IL_2015: Unknown result type (might be due to invalid IL or missing references)
		//IL_2039: Unknown result type (might be due to invalid IL or missing references)
		//IL_203e: Unknown result type (might be due to invalid IL or missing references)
		//IL_249b: Unknown result type (might be due to invalid IL or missing references)
		//IL_24a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_21c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_21c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_21ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_21f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_225d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2262: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fec: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ff1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eff: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f04: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2068: Unknown result type (might be due to invalid IL or missing references)
		//IL_206d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2091: Unknown result type (might be due to invalid IL or missing references)
		//IL_2096: Unknown result type (might be due to invalid IL or missing references)
		//IL_148c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1497: Unknown result type (might be due to invalid IL or missing references)
		//IL_14c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_14cb: Expected Obj, but got Unknown
		//IL_14d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_14d9: Expected Obj, but got Unknown
		//IL_14f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_24ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_24d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_21a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_21a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_2219: Unknown result type (might be due to invalid IL or missing references)
		//IL_221e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2242: Unknown result type (might be due to invalid IL or missing references)
		//IL_2247: Unknown result type (might be due to invalid IL or missing references)
		//IL_22f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_22f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_2327: Unknown result type (might be due to invalid IL or missing references)
		//IL_232c: Unknown result type (might be due to invalid IL or missing references)
		//IL_20d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_20d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_250b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2510: Unknown result type (might be due to invalid IL or missing references)
		//IL_2524: Unknown result type (might be due to invalid IL or missing references)
		//IL_2360: Unknown result type (might be due to invalid IL or missing references)
		//IL_2365: Unknown result type (might be due to invalid IL or missing references)
		//IL_2393: Unknown result type (might be due to invalid IL or missing references)
		//IL_2398: Unknown result type (might be due to invalid IL or missing references)
		//IL_23d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_23dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_2400: Unknown result type (might be due to invalid IL or missing references)
		//IL_2405: Unknown result type (might be due to invalid IL or missing references)
		//IL_2584: Unknown result type (might be due to invalid IL or missing references)
		//IL_2589: Unknown result type (might be due to invalid IL or missing references)
		//IL_259d: Unknown result type (might be due to invalid IL or missing references)
		//IL_15a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_15d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_15d9: Expected Obj, but got Unknown
		//IL_23b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_23b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_22c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_22cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_212b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2130: Unknown result type (might be due to invalid IL or missing references)
		//IL_242f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2434: Unknown result type (might be due to invalid IL or missing references)
		//IL_2458: Unknown result type (might be due to invalid IL or missing references)
		//IL_245d: Unknown result type (might be due to invalid IL or missing references)
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
						double num = 0.0;
						num = (cfgDI.bA1 ? 10.0 : 6.0);
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
								string tagDest = mCabos[i].mDestinos[j].tagDest;
								string nReguaDest = mCabos[i].mDestinos[j].nReguaDest;
								string borneDest = mCabos[i].mDestinos[j].borneDest;
								if (!((mCabos[i].Coluna == 1) & (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) == 0)))
								{
									if (!((mCabos[i].Coluna == 2) & (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) == 0)))
									{
										if (!((mCabos[i].Coluna == 3) & (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) == 0)))
										{
											if (!((mCabos[i].Coluna == 4) & (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) == 0)))
											{
												if (!((mCabos[i].Coluna == 5) & (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) == 0)))
												{
													if ((mCabos[i].Coluna == 5) & (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0))
													{
														num9 = 5;
														ladoEntradaBorne = "E";
													}
												}
												else
												{
													num9 = 5;
													ladoEntradaBorne = "D";
												}
											}
											else
											{
												num9 = 4;
											}
										}
										else
										{
											num9 = 3;
										}
									}
									else
									{
										num9 = 2;
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
									array[num10].Dest.tagDest = tagDest;
									array[num10].Dest.nReguaDest = nReguaDest;
									array[num10].Dest.borneDest = borneDest;
									array[num10].Dest.FuncaoVeia = "";
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
									array[num11].Dest.tagDest = tagDest;
									array[num11].Dest.nReguaDest = nReguaDest;
									array[num11].Dest.borneDest = borneDest;
									array[num11].Dest.FuncaoVeia = "";
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
												num23 = 10.0;
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
												num22 = 8.0;
											}
										}
										else
										{
											num22 = 4.0;
										}
										num18 -= 8.0;
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
								double num26 = 0.0;
								num26 = (cfgDI.bA1 ? 30.0 : 20.0);
								do
								{
									if ((num6 == 1) | (num6 == 2) | (num6 == 3) | (num6 == 4) | ((num6 == 5) & (Operators.CompareString(left, "D", TextCompare: true) == 0)))
									{
										num25 = ((num25 - num5 < num26) ? (num25 + num26) : (num25 + num));
									}
									else if ((num6 == 5) & (Operators.CompareString(left, "E", TextCompare: true) == 0))
									{
										num25 = ((num5 - num25 < num26) ? (num25 - num26) : (num25 - num));
									}
								}
								while (bnBpcVfvXO(num25, num3, num4, array[inicio].Pagina, revisao, Painel));
								Point2d val6 = new Point2d(num25, num18);
								Hatch val7 = mpIpKTbioB(new Point3d(val6.X, val6.Y, 0.0), array[inicio].Pagina);
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
								if ((num6 == 1) | (num6 == 2) | (num6 == 3) | (num6 == 4) | ((num6 == 5) & (Operators.CompareString(left, "D", TextCompare: true) == 0)))
								{
									text = ((!flag) ? "VeiaEntraDireita" : "VeiaEntraDireitaReta");
								}
								else if ((num6 == 5) & (Operators.CompareString(left, "E", TextCompare: true) == 0))
								{
									text = ((!flag) ? "VeiaEntraEsquerda" : "VeiaEntraEsquerdaReta");
								}
								ObjectId val8 = ObjectId.Null;
								string text2 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + cfgDI.diretorio + text + ".dwg";
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
								int num27 = Information.UBound(mInfoVeias);
								for (int num28 = 1; num28 <= num27; num28++)
								{
									if (Operators.CompareString(mInfoVeias[num28].tag_Cabo, mCabos[i].Tag_Cabo, TextCompare: true) == 0)
									{
										text3 = mCabos[i].Tag_Cabo;
										if (Operators.CompareString(array[inicio].Pagina, mInfoVeias[num28].mBornes[0].pagina, TextCompare: true) != 0)
										{
											text3 = text3 + DeclaracoesGeral.Conf.PrefixoCruzInterno + vA4peEvg2y(mInfoVeias[num28].mBornes[0].pagina) + DeclaracoesGeral.Conf.SufixoCruzInterno;
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
									int num29 = Information.UBound(mInfoVeias);
									for (int num30 = 1; num30 <= num29; num30++)
									{
										if (Operators.CompareString(mInfoVeias[num30].tag_Cabo, mCabos[i].Tag_Cabo, TextCompare: true) == 0)
										{
											ref DeclaracoesInterligacao.borneCruzamentoCaboAranha[] mBornes = ref mInfoVeias[num30].mBornes;
											mBornes = (DeclaracoesInterligacao.borneCruzamentoCaboAranha[])Utils.CopyArray(mBornes, new DeclaracoesInterligacao.borneCruzamentoCaboAranha[num16 + 1]);
											string text4 = mBornesJ[array[inicio].indiceBorne].Tag;
											if (Operators.CompareString(mBornesJ[array[inicio].indiceBorne].NRegua, "", TextCompare: true) != 0)
											{
												text4 = mBornesJ[array[inicio].indiceBorne].NRegua;
											}
											string borne = mBornesJ[array[inicio].indiceBorne].Borne;
											mInfoVeias[num30].mBornes[num16].ID = ObjectId.Null;
											mInfoVeias[num30].mBornes[num16].rb = text4 + "-" + borne;
											mInfoVeias[num30].mBornes[num16].pagina = array[inicio].Pagina;
										}
									}
								}
								else
								{
									text = "";
									if (!((num6 == 1) | (num6 == 2) | (num6 == 3) | (num6 == 4) | ((num6 == 5) & (Operators.CompareString(left, "D", TextCompare: true) == 0))))
									{
										if ((num6 == 5) & (Operators.CompareString(left, "E", TextCompare: true) == 0))
										{
											text = "VeiaSaiEsquerda";
										}
									}
									else
									{
										text = "VeiaSaiDireita";
									}
									val8 = ObjectId.Null;
									text2 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + cfgDI.diretorio + text + ".dwg";
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
									int num31 = Information.UBound(mInfoVeias);
									for (int num32 = 1; num32 <= num31; num32++)
									{
										if (Operators.CompareString(mInfoVeias[num32].tag_Cabo, mCabos[i].Tag_Cabo, TextCompare: true) == 0)
										{
											ref DeclaracoesInterligacao.borneCruzamentoCaboAranha[] mBornes2 = ref mInfoVeias[num32].mBornes;
											mBornes2 = (DeclaracoesInterligacao.borneCruzamentoCaboAranha[])Utils.CopyArray(mBornes2, new DeclaracoesInterligacao.borneCruzamentoCaboAranha[num16 + 1]);
											string text5 = mBornesJ[array[inicio].indiceBorne].Tag;
											if (Operators.CompareString(mBornesJ[array[inicio].indiceBorne].NRegua, "", TextCompare: true) != 0)
											{
												text5 = mBornesJ[array[inicio].indiceBorne].NRegua;
											}
											string borne2 = mBornesJ[array[inicio].indiceBorne].Borne;
											mInfoVeias[num32].mBornes[num16].ID = ((DBObject)val11).ObjectId;
											mInfoVeias[num32].mBornes[num16].rb = text5 + "-" + borne2;
											mInfoVeias[num32].mBornes[num16].pagina = array[inicio].Pagina;
											break;
										}
									}
								}
								int num33 = inicio;
								int num34 = final;
								for (int num35 = num33; num35 <= num34; num35++)
								{
									DeclaracoesInterligacao.borneJ borneJ3 = mBornesJ[array[num35].indiceBorne];
									string veia2 = array[num35].Veia;
									string tagDest2 = array[num35].Dest.tagDest;
									string nReguaDest2 = array[num35].Dest.nReguaDest;
									string borneDest2 = array[num35].Dest.borneDest;
									Polyline val21 = new Polyline();
									((Entity)val21).SetDatabaseDefaults();
									((Entity)val21).ColorIndex = 7;
									((Entity)val21).Layer = borneJ3.Pagina;
									((Entity)val21).LineWeight = (LineWeight)9;
									double num36 = 0.0;
									int num37 = 0;
									if (!((borneJ3.Posicao == 5) & (Operators.CompareString(array[num35].LadoEntradaBorne, "D", TextCompare: true) == 0)))
									{
										num37 = borneJ3.contVeiasLigadas;
									}
									else
									{
										if (borneJ3.TipoBorne != 0)
										{
											if (borneJ3.TipoBorne == 1)
											{
												num36 = 15.0;
											}
										}
										else
										{
											num36 = 10.0;
										}
										num37 = borneJ3.contVeiasLigadas2;
										borneJ3.ptInsTerm = new Point2d(borneJ3.ptInsTerm.X + num36, borneJ3.ptInsTerm.Y);
									}
									if (num37 == 1 && borneJ3.TipoBorne == 1)
									{
										mBornesJ[array[num35].indiceBorne].ptInsTerm = new Point2d(borneJ3.ptInsTerm.X, borneJ3.ptInsTerm.Y - 8.0);
										borneJ3 = mBornesJ[array[num35].indiceBorne];
									}
									double num38 = 0.0;
									Point2d val22 = new Point2d(num25, num18);
									if (num18 != borneJ3.ptInsTerm.Y)
									{
										if (!(num18 > borneJ3.ptInsTerm.Y))
										{
											if (num18 < borneJ3.ptInsTerm.Y)
											{
												if (num37 != 0)
												{
													if (borneJ3.TipoBorne != 0)
													{
														if (borneJ3.TipoBorne == 1)
														{
															val23 = new Point2d(num25, num18);
															if (!((num6 == 1) | (num6 == 2) | (num6 == 3) | (num6 == 4) | ((num6 == 5) & (Operators.CompareString(left, "D", TextCompare: true) == 0))))
															{
																if ((num6 == 5) & (Operators.CompareString(left, "E", TextCompare: true) == 0))
																{
																	val24 = new Point2d(num25 + 4.0, borneJ3.ptInsTerm.Y);
																	val25 = new Point2d(borneJ3.ptInsTerm.X - 1.5, borneJ3.ptInsTerm.Y);
																	num38 = -0.42;
																}
															}
															else
															{
																val24 = new Point2d(num25 - 4.0, borneJ3.ptInsTerm.Y);
																val25 = new Point2d(borneJ3.ptInsTerm.X + 1.5, borneJ3.ptInsTerm.Y);
																num38 = 0.42;
															}
															ptInsTerm = borneJ3.ptInsTerm;
														}
													}
													else
													{
														val23 = new Point2d(num25, num18);
														if (!((num6 == 1) | (num6 == 2) | (num6 == 3) | (num6 == 4) | ((num6 == 5) & (Operators.CompareString(left, "D", TextCompare: true) == 0))))
														{
															if ((num6 == 5) & (Operators.CompareString(left, "E", TextCompare: true) == 0))
															{
																val24 = new Point2d(num25 + 4.0, borneJ3.ptInsTerm.Y - 4.0);
																val25 = new Point2d(borneJ3.ptInsTerm.X - 1.5, borneJ3.ptInsTerm.Y - 4.0);
																num38 = -0.42;
															}
														}
														else
														{
															val24 = new Point2d(num25 - 4.0, borneJ3.ptInsTerm.Y - 4.0);
															val25 = new Point2d(borneJ3.ptInsTerm.X + 1.5, borneJ3.ptInsTerm.Y - 4.0);
															num38 = 0.42;
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
													val23 = new Point2d(num25, borneJ3.ptInsTerm.Y - 4.0);
													if (!((num6 == 1) | (num6 == 2) | (num6 == 3) | (num6 == 4) | ((num6 == 5) & (Operators.CompareString(left, "D", TextCompare: true) == 0))))
													{
														if ((num6 == 5) & (Operators.CompareString(left, "E", TextCompare: true) == 0))
														{
															val24 = new Point2d(num25 + 4.0, borneJ3.ptInsTerm.Y);
															val25 = new Point2d(borneJ3.ptInsTerm.X - 1.5, borneJ3.ptInsTerm.Y);
															num38 = -0.42;
														}
													}
													else
													{
														val24 = new Point2d(num25 - 4.0, borneJ3.ptInsTerm.Y);
														val25 = new Point2d(borneJ3.ptInsTerm.X + 1.5, borneJ3.ptInsTerm.Y);
														num38 = 0.42;
													}
													ptInsTerm = borneJ3.ptInsTerm;
												}
											}
										}
										else if (num37 != 0)
										{
											if (borneJ3.TipoBorne != 0)
											{
												if (borneJ3.TipoBorne == 1)
												{
													val23 = new Point2d(num25, borneJ3.ptInsTerm.Y + 4.0);
													if (!((num6 == 1) | (num6 == 2) | (num6 == 3) | (num6 == 4) | ((num6 == 5) & (Operators.CompareString(left, "D", TextCompare: true) == 0))))
													{
														if ((num6 == 5) & (Operators.CompareString(left, "E", TextCompare: true) == 0))
														{
															val24 = new Point2d(num25 + 4.0, borneJ3.ptInsTerm.Y);
															val25 = new Point2d(borneJ3.ptInsTerm.X - 1.5, borneJ3.ptInsTerm.Y);
															num38 = 0.42;
														}
													}
													else
													{
														val24 = new Point2d(num25 - 4.0, borneJ3.ptInsTerm.Y);
														val25 = new Point2d(borneJ3.ptInsTerm.X + 1.5, borneJ3.ptInsTerm.Y);
														num38 = -0.42;
													}
													ptInsTerm = borneJ3.ptInsTerm;
												}
											}
											else
											{
												val23 = new Point2d(num25, borneJ3.ptInsTerm.Y);
												if (!((num6 == 1) | (num6 == 2) | (num6 == 3) | (num6 == 4) | ((num6 == 5) & (Operators.CompareString(left, "D", TextCompare: true) == 0))))
												{
													if ((num6 == 5) & (Operators.CompareString(left, "E", TextCompare: true) == 0))
													{
														val24 = new Point2d(num25 + 4.0, borneJ3.ptInsTerm.Y - 4.0);
														val25 = new Point2d(borneJ3.ptInsTerm.X - 1.5, borneJ3.ptInsTerm.Y - 4.0);
														num38 = 0.42;
													}
												}
												else
												{
													val24 = new Point2d(num25 - 4.0, borneJ3.ptInsTerm.Y - 4.0);
													val25 = new Point2d(borneJ3.ptInsTerm.X + 1.5, borneJ3.ptInsTerm.Y - 4.0);
													num38 = -0.42;
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
											val23 = new Point2d(num25, borneJ3.ptInsTerm.Y + 4.0);
											if (!((num6 == 1) | (num6 == 2) | (num6 == 3) | (num6 == 4) | ((num6 == 5) & (Operators.CompareString(left, "D", TextCompare: true) == 0))))
											{
												if ((num6 == 5) & (Operators.CompareString(left, "E", TextCompare: true) == 0))
												{
													val24 = new Point2d(num25 + 4.0, borneJ3.ptInsTerm.Y);
													val25 = new Point2d(borneJ3.ptInsTerm.X - 1.5, borneJ3.ptInsTerm.Y);
													num38 = 0.42;
												}
											}
											else
											{
												val24 = new Point2d(num25 - 4.0, borneJ3.ptInsTerm.Y);
												val25 = new Point2d(borneJ3.ptInsTerm.X + 1.5, borneJ3.ptInsTerm.Y);
												num38 = -0.42;
											}
											ptInsTerm = borneJ3.ptInsTerm;
										}
									}
									else if (num37 != 0)
									{
										if (borneJ3.TipoBorne != 0)
										{
											if (borneJ3.TipoBorne == 1)
											{
												val23 = val22;
												if (!((num6 == 1) | (num6 == 2) | (num6 == 3) | (num6 == 4) | ((num6 == 5) & (Operators.CompareString(left, "D", TextCompare: true) == 0))))
												{
													if ((num6 == 5) & (Operators.CompareString(left, "E", TextCompare: true) == 0))
													{
														val24 = new Point2d(num25 + 4.0, borneJ3.ptInsTerm.Y);
														val25 = new Point2d(borneJ3.ptInsTerm.X - 1.5, borneJ3.ptInsTerm.Y);
													}
												}
												else
												{
													val24 = new Point2d(num25 - 4.0, borneJ3.ptInsTerm.Y);
													val25 = new Point2d(borneJ3.ptInsTerm.X + 1.5, borneJ3.ptInsTerm.Y);
												}
												ptInsTerm = borneJ3.ptInsTerm;
												num38 = 0.0;
											}
										}
										else
										{
											val23 = val22;
											if (!((num6 == 1) | (num6 == 2) | (num6 == 3) | (num6 == 4) | ((num6 == 5) & (Operators.CompareString(left, "D", TextCompare: true) == 0))))
											{
												if ((num6 == 5) & (Operators.CompareString(left, "E", TextCompare: true) == 0))
												{
													val24 = new Point2d(num25 + 4.0, borneJ3.ptInsTerm.Y - 4.0);
													val25 = new Point2d(borneJ3.ptInsTerm.X - 1.5, borneJ3.ptInsTerm.Y - 4.0);
												}
											}
											else
											{
												val24 = new Point2d(num25 - 4.0, borneJ3.ptInsTerm.Y - 4.0);
												val25 = new Point2d(borneJ3.ptInsTerm.X + 1.5, borneJ3.ptInsTerm.Y - 4.0);
											}
											ptInsTerm = borneJ3.ptInsTerm;
											num38 = 0.42;
										}
									}
									else
									{
										val23 = val22;
										if (!((num6 == 1) | (num6 == 2) | (num6 == 3) | (num6 == 4) | ((num6 == 5) & (Operators.CompareString(left, "D", TextCompare: true) == 0))))
										{
											if ((num6 == 5) & (Operators.CompareString(left, "E", TextCompare: true) == 0))
											{
												val24 = new Point2d(num25 + 4.0, borneJ3.ptInsTerm.Y);
												val25 = new Point2d(borneJ3.ptInsTerm.X - 1.5, borneJ3.ptInsTerm.Y);
											}
										}
										else
										{
											val24 = new Point2d(num25 - 4.0, borneJ3.ptInsTerm.Y);
											val25 = new Point2d(borneJ3.ptInsTerm.X + 1.5, borneJ3.ptInsTerm.Y);
										}
										ptInsTerm = borneJ3.ptInsTerm;
										num38 = 0.0;
									}
									val21.AddVertexAt(0, val22, 0.0, 0.0, 0.0);
									val21.AddVertexAt(1, val23, 0.0, 0.0, 0.0);
									val21.AddVertexAt(2, val24, 0.0, 0.0, 0.0);
									val21.AddVertexAt(3, val25, 0.0, 0.0, 0.0);
									val21.AddVertexAt(4, ptInsTerm, 0.0, 0.0, 0.0);
									val21.SetBulgeAt(1, num38);
									val4.AppendEntity((Entity)(object)val21);
									DeclaracoesGeral.bAnularEventos = true;
									val2.AddNewlyCreatedDBObject((DBObject)(object)val21, true);
									ent = (Entity)(object)val21;
									XDataAranha.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, veia2, borneJ3.Handle);
									val21 = (Polyline)ent;
									TextStyleTable val26 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)0);
									ObjectId textStyleId = (((SymbolTable)val26).Has(cfgDI.textStyle) ? ((SymbolTable)val26)[cfgDI.textStyle] : ((SymbolTable)val26)["Standard"]);
									DBText val27 = new DBText();
									val27.TextString = veia2;
									((Entity)val27).ColorIndex = 7;
									((Entity)val27).Layer = ((Entity)val21).Layer;
									val27.Height = 2.0;
									val27.TextStyleId = textStyleId;
									val27.WidthFactor = 0.9;
									if (!((num6 == 1) | (num6 == 2) | (num6 == 3) | (num6 == 4) | ((num6 == 5) & (Operators.CompareString(left, "D", TextCompare: true) == 0))))
									{
										if ((num6 == 5) & (Operators.CompareString(left, "E", TextCompare: true) == 0))
										{
											alignmentPoint = new Point3d(val24.X, val24.Y, 0.0);
											val27.HorizontalMode = (TextHorizontalMode)0;
											val27.VerticalMode = (TextVerticalMode)1;
										}
									}
									else
									{
										alignmentPoint = new Point3d(val24.X, val24.Y, 0.0);
										val27.HorizontalMode = (TextHorizontalMode)2;
										val27.VerticalMode = (TextVerticalMode)1;
									}
									val27.AlignmentPoint = alignmentPoint;
									val4.AppendEntity((Entity)(object)val27);
									DeclaracoesGeral.bAnularEventos = true;
									val2.AddNewlyCreatedDBObject((DBObject)(object)val27, true);
									ent = (Entity)(object)val27;
									XDataAranha.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, veia2, "");
									val27 = (DBText)ent;
									string text6 = "";
									DBText val28 = new DBText();
									((Entity)val28).Layer = ((Entity)val21).Layer;
									val28.Height = 2.0;
									val28.TextStyleId = textStyleId;
									val28.WidthFactor = 0.85;
									val28.Rotation = 0.0;
									((Entity)val28).ColorIndex = 7;
									val28.Oblique = 0.0;
									if (!(((num6 >= 1) & (num6 <= 4)) | ((num6 == 5) & (Operators.CompareString(mCabos[i].Lado, "D", TextCompare: true) == 0))))
									{
										if ((num6 == 5) & (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0))
										{
											Point3d alignmentPoint2 = new Point3d(val25.X - 2.5, val25.Y, 0.0);
											val28.HorizontalMode = (TextHorizontalMode)2;
											val28.VerticalMode = (TextVerticalMode)1;
											val28.AlignmentPoint = alignmentPoint2;
											text6 = ((Operators.CompareString(nReguaDest2, "", TextCompare: true) != 0) ? nReguaDest2 : (text6 + tagDest2));
											text6 = text6 + "-" + borneDest2;
										}
									}
									else
									{
										Point3d alignmentPoint2 = new Point3d(val25.X + 2.5, val25.Y, 0.0);
										val28.HorizontalMode = (TextHorizontalMode)0;
										val28.VerticalMode = (TextVerticalMode)1;
										val28.AlignmentPoint = alignmentPoint2;
										text6 = ((Operators.CompareString(nReguaDest2, "", TextCompare: true) != 0) ? nReguaDest2 : (text6 + tagDest2));
										text6 = text6 + "-" + borneDest2;
									}
									val28.TextString = text6;
									val4.AppendEntity((Entity)(object)val28);
									DeclaracoesGeral.bAnularEventos = true;
									val2.AddNewlyCreatedDBObject((DBObject)(object)val28, true);
									ent = (Entity)(object)val28;
									XDataAranha.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, veia2, "");
									val28 = (DBText)ent;
									if (!((borneJ3.Posicao == 5) & (Operators.CompareString(array[num35].LadoEntradaBorne, "D", TextCompare: true) == 0)))
									{
										mBornesJ[array[num35].indiceBorne].contVeiasLigadas++;
									}
									else
									{
										mBornesJ[array[num35].indiceBorne].contVeiasLigadas2++;
									}
								}
							}
							int num39 = Information.UBound(mInfoVeias);
							for (int num40 = 1; num40 <= num39; num40++)
							{
								if (Operators.CompareString(mInfoVeias[num40].tag_Cabo, mCabos[i].Tag_Cabo, TextCompare: true) != 0)
								{
									continue;
								}
								int num41 = Information.UBound(mInfoVeias[num40].mBornes) - 1;
								for (int num42 = 0; num42 <= num41; num42++)
								{
									ObjectId iD = mInfoVeias[num40].mBornes[num42].ID;
									string pagina3 = mInfoVeias[num40].mBornes[num42].pagina;
									string pagina4 = mInfoVeias[num40].mBornes[num42 + 1].pagina;
									BlockReference val29 = (BlockReference)val2.GetObject(iD, (OpenMode)0);
									AttributeCollection attributeCollection = val29.AttributeCollection;
									foreach (object item in attributeCollection)
									{
										ObjectId val30 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
										AttributeReference val31 = (AttributeReference)val30.GetObject((OpenMode)1);
										string text7 = mInfoVeias[num40].mBornes[num42 + 1].rb;
										if (Operators.CompareString(pagina3, pagina4, TextCompare: true) != 0)
										{
											text7 = text7 + DeclaracoesGeral.Conf.PrefixoCruzInterno + vA4peEvg2y(pagina4) + DeclaracoesGeral.Conf.SufixoCruzInterno;
										}
										string tag2 = val31.Tag;
										if (Operators.CompareString(tag2, "BORNE", TextCompare: true) == 0)
										{
											((DBText)val31).TextString = text7;
										}
										((Entity)val31).Draw();
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

	private static Hatch mpIpKTbioB(Point3d P_0, string P_1)
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
									mCabosSync[num].Folha = vA4peEvg2y(((Entity)val4).Layer.ToString());
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
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Expected Obj, but got Unknown
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
								if (Operators.CompareString(DeclaracoesGeral.Conf.Local, caderno, TextCompare: true) != 0)
								{
									caderno = mTodosCabosSync[i].Caderno;
									text = DeclaracoesGeral.Conf.PrefixoCruzInterno + mTodosCabosSync[i].Folha + DeclaracoesGeral.Conf.SufixoCruzInterno;
								}
								else
								{
									caderno = "";
									text = DeclaracoesGeral.Conf.PrefixoCruzInterno + mTodosCabosSync[i].Folha + DeclaracoesGeral.Conf.SufixoCruzInterno;
								}
								AttributeCollection attributeCollection = val5.AttributeCollection;
								foreach (object item in attributeCollection)
								{
									ObjectId val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
									AttributeReference val7 = (AttributeReference)val6.GetObject((OpenMode)1);
									string text2 = caderno + "  " + text;
									string tag = val7.Tag;
									if (Operators.CompareString(tag, "FL", TextCompare: true) == 0)
									{
										((DBText)val7).TextString = text2.Trim();
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

	private static string vA4peEvg2y(string P_0)
	{
		string text = "";
		if (!((DeclaracoesGeral.Conf.incluirColuna == 3) | (DeclaracoesGeral.Conf.incluirColuna == 4) | (DeclaracoesGeral.Conf.incluirColuna == 5)))
		{
			return P_0;
		}
		return Pagina.BuscaAlternativo(P_0, bretornaVazio: false);
	}
}

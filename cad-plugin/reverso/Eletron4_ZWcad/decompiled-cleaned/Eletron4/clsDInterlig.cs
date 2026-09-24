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
using ZwSoft.ZwCAD.Runtime;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

public class clsDInterlig
{
	private struct vQiEi3p5jhL1O6WRxSw9
	{
		public string uaNp5L50Vca;

		public int Ha2p5wm1p9f;
	}

	public static void InserirBorneDInterlig(string nomebloco, DeclaracoesInterligacao.borneAranha bn, Point3d ptIns, bool bInsereNomeRegua, ref DeclaracoesInterligacao.ConfigDInterlig cfgDI)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected Obj, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected Obj, but got Unknown
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Expected Obj, but got Unknown
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
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
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
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
					XDataDInterlig.GravarXDataBorne(ref blockRef, bn);
					if (bInsereNomeRegua)
					{
						InserirReguaDInterlig(ref bn, ptIns, ref cfgDI);
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

	public static void InserirReguaDInterlig(ref DeclaracoesInterligacao.borneAranha bn, Point3d ptIns, ref DeclaracoesInterligacao.ConfigDInterlig cfgDI)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected Obj, but got Unknown
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Expected Obj, but got Unknown
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected Obj, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected Obj, but got Unknown
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected Obj, but got Unknown
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected Obj, but got Unknown
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected Obj, but got Unknown
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Expected Obj, but got Unknown
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		_ = Application.DocumentManager.MdiActiveDocument.Editor;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			try
			{
				ObjectId val = ObjectId.Null;
				BlockTable val2 = (BlockTable)topTransaction.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val3 = (BlockTableRecord)topTransaction.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)1);
				string text = "Regua";
				string text2 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + cfgDI.diretorio + "Regua.dwg";
				if (!((SymbolTable)val2).Has(text))
				{
					Database val4 = new Database(false, true);
					val4.ReadDwgFile(text2, FileShare.Read, true, "");
					DeclaracoesGeral.bAnularEventos = true;
					val = database.Insert(text, val4, false);
					((DisposableWrapper)val4).Dispose();
				}
				else
				{
					BlockTableRecord val5 = (BlockTableRecord)topTransaction.GetObject(((SymbolTable)val2)[text], (OpenMode)0);
					val = ((DBObject)val5).Id;
				}
				BlockReference blockRef = new BlockReference(ptIns, val);
				((Entity)blockRef).Layer = DeclaracoesGeral.ativo.Pagina;
				val3.AppendEntity((Entity)(object)blockRef);
				DeclaracoesGeral.bAnularEventos = true;
				topTransaction.AddNewlyCreatedDBObject((DBObject)(object)blockRef, true);
				BlockTableRecord val6 = (BlockTableRecord)topTransaction.GetObject(val, (OpenMode)0);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val6.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val7 = (Entity)topTransaction.GetObject(current, (OpenMode)0);
						if (!(val7 is AttributeDefinition))
						{
							continue;
						}
						AttributeDefinition val8 = (AttributeDefinition)val7;
						AttributeReference val9 = new AttributeReference();
						val9.SetAttributeFromBlock(val8, blockRef.BlockTransform);
						string tag = val8.Tag;
						if (Operators.CompareString(tag, "REGUA", TextCompare: true) != 0)
						{
							((Entity)val9).Visible = false;
						}
						else
						{
							((DBText)val9).TextString = bn.Tag;
							if (Operators.CompareString(bn.NRegua, "", TextCompare: true) != 0)
							{
								((DBText)val9).TextString = bn.NRegua;
							}
						}
						((DBText)val9).AdjustAlignment(database);
						blockRef.AttributeCollection.AppendAttribute(val9);
						DeclaracoesGeral.bAnularEventos = true;
						topTransaction.AddNewlyCreatedDBObject((DBObject)(object)val9, true);
						((Entity)val9).Draw();
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				XDataDInterlig.GravarXDataNomeRegua(ref blockRef, bn);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				topTransaction.Abort();
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
			((IDisposable)topTransaction)?.Dispose();
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
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected Obj, but got Unknown
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
					if (blockRef.Name.Contains("BorneSimples1") | blockRef.Name.Contains("BorneDuplo1"))
					{
						DeclaracoesInterligacao.borneAranha bn = default;
						if (XDataDInterlig.LerXDataBorne(ref blockRef, ref bn) && ((bn.Painel == Painel) & (Operators.CompareString(bn.Tag, Tag, TextCompare: true) == 0) & (Operators.CompareString(bn.NRegua, NRegua, TextCompare: true) == 0)))
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
						if (!(blockRef.Name.Contains("BorneSimples1") | blockRef.Name.Contains("BorneDuplo1")))
						{
							continue;
						}
						DeclaracoesInterligacao.borneAranha bn = default;
						if (!XDataDInterlig.LerXDataBorne(ref blockRef, ref bn) || bn.Painel != Painel)
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

	public static bool outraReguaExiste(string Pagina, ref Point3d pt, int LinhaNum)
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
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
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
					if (!(blockRef.Name.Contains("BorneSimples1") | blockRef.Name.Contains("BorneDuplo1")) || Operators.CompareString(((Entity)blockRef).Layer, Pagina, TextCompare: true) != 0)
					{
						continue;
					}
					DeclaracoesInterligacao.borneAranha bn = default;
					if (XDataDInterlig.LerXDataBorne(ref blockRef, ref bn) && bn.Posicao == LinhaNum)
					{
						Point3d position = blockRef.Position;
						if (position.X > val4.X)
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

	public static bool BuscaUltimoBorne(int Painel, string Tag, string NRegua, ref DeclaracoesInterligacao.PosborneDInterlig ubn, ref List<string> lBornes)
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
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
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
					if (!(blockRef.Name.Contains("BorneSimples1") | blockRef.Name.Contains("BorneDuplo1")))
					{
						continue;
					}
					DeclaracoesInterligacao.borneAranha bn = default;
					if (XDataDInterlig.LerXDataBorne(ref blockRef, ref bn) && ((bn.Painel == Painel) & (Operators.CompareString(bn.Tag, Tag, TextCompare: true) == 0) & (Operators.CompareString(bn.NRegua, NRegua, TextCompare: true) == 0)))
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
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected Obj, but got Unknown
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
						BlockReference blockRef = (BlockReference)val2.GetObject(current, (OpenMode)0);
						if (!((Operators.CompareString(blockRef.Name, "BorneSimples1", TextCompare: true) == 0) | (Operators.CompareString(blockRef.Name, "BorneDuplo1", TextCompare: true) == 0) | (Operators.CompareString(blockRef.Name, "BorneSimples1F", TextCompare: true) == 0) | (Operators.CompareString(blockRef.Name, "BorneDuplo1F", TextCompare: true) == 0)))
						{
							if (Operators.CompareString(blockRef.Name, "Regua", TextCompare: true) == 0)
							{
								DeclaracoesInterligacao.borneAranha bn = default;
								if (XDataDInterlig.LerXDataNomeRegua(ref blockRef, ref bn) && ((Operators.CompareString(bn.Revisao, revisao, TextCompare: true) == 0) & (bn.Painel == Painel) & (Operators.CompareString(bn.Tag, Tag, TextCompare: true) == 0) & (Operators.CompareString(bn.NRegua, NRegua, TextCompare: true) == 0)))
								{
									((DBObject)blockRef).UpgradeOpen();
									((DBObject)blockRef).Erase();
								}
							}
						}
						else
						{
							DeclaracoesInterligacao.borneAranha bn2 = default;
							if (XDataDInterlig.LerXDataBorne(ref blockRef, ref bn2) && ((Operators.CompareString(bn2.Revisao, revisao, TextCompare: true) == 0) & (bn2.Painel == Painel) & (Operators.CompareString(bn2.Tag, Tag, TextCompare: true) == 0) & (Operators.CompareString(bn2.NRegua, NRegua, TextCompare: true) == 0)))
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

	public static bool carregaBornesJ(string revisao, int Painel, ref DeclaracoesInterligacao.borneJ[] mBornesJ, ref bool bJumperCima, ref DeclaracoesInterligacao.ConfigDInterlig cfgDI)
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
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
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
						if (!(blockRef.Name.Contains("BorneSimples1") | blockRef.Name.Contains("BorneDuplo1")))
						{
							continue;
						}
						DeclaracoesInterligacao.borneAranha bn = default;
						if (!XDataDInterlig.LerXDataBorne(ref blockRef, ref bn) || bn.Painel != Painel)
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
						reference.X = position.X;
						ref DeclaracoesInterligacao.borneJ reference2 = ref mBornesJ[num];
						position = blockRef.Position;
						reference2.Y = position.Y;
						mBornesJ[num].Pagina = ((Entity)blockRef).Layer;
						mBornesJ[num].PaginaNum = Pagina.calculaPaginaDecimal(((Entity)blockRef).Layer);
						mBornesJ[num].Posicao = bn.Posicao;
						mBornesJ[num].Handle = ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString();
						mBornesJ[num].contVeiasLigadas = 0;
						if (!bJumperCima)
						{
							if (bn.TipoBorne != 0)
							{
								if (bn.TipoBorne == 1)
								{
									num2 = cfgDI.larguraBorne / 2.0;
									num3 = 0.0;
								}
							}
							else
							{
								num2 = cfgDI.larguraBorne / 2.0;
								num3 = 0.0;
							}
						}
						else if (bn.TipoBorne != 0)
						{
							if (bn.TipoBorne == 1)
							{
								num2 = cfgDI.larguraBorne / 2.0;
								num3 = 10.0;
							}
						}
						else
						{
							num2 = cfgDI.larguraBorne / 2.0;
							num3 = 10.0;
						}
						ref DeclaracoesInterligacao.borneJ reference3 = ref mBornesJ[num];
						position = blockRef.Position;
						double num4 = position.X + num2;
						position = blockRef.Position;
						reference3.ptInsTerm = new Point2d(num4, position.Y + num3);
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
							if (((mBornesJ[j].PaginaNum == mBornesJ[j + 1].PaginaNum) & (mBornesJ[j].Posicao == mBornesJ[j + 1].Posicao)) && mBornesJ[j].X > mBornesJ[j + 1].X)
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

	public static void desenhaJumper1(string revisao, int painel, ref DeclaracoesInterligacao.borneJ[] mBornesJ, ref DeclaracoesInterligacao.jumper[] mJumpers, long index, ref DeclaracoesInterligacao.ConfigDInterlig cfgDI)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Expected Obj, but got Unknown
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected Obj, but got Unknown
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_040f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0414: Unknown result type (might be due to invalid IL or missing references)
		//IL_0430: Unknown result type (might be due to invalid IL or missing references)
		//IL_0435: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03df: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_043e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0443: Unknown result type (might be due to invalid IL or missing references)
		//IL_0460: Unknown result type (might be due to invalid IL or missing references)
		//IL_0465: Unknown result type (might be due to invalid IL or missing references)
		//IL_0481: Unknown result type (might be due to invalid IL or missing references)
		//IL_0486: Unknown result type (might be due to invalid IL or missing references)
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0378: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Unknown result type (might be due to invalid IL or missing references)
		//IL_038f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0394: Unknown result type (might be due to invalid IL or missing references)
		//IL_054c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0551: Unknown result type (might be due to invalid IL or missing references)
		//IL_056e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0573: Unknown result type (might be due to invalid IL or missing references)
		//IL_058f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0594: Unknown result type (might be due to invalid IL or missing references)
		//IL_0505: Unknown result type (might be due to invalid IL or missing references)
		//IL_050a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0527: Unknown result type (might be due to invalid IL or missing references)
		//IL_052c: Unknown result type (might be due to invalid IL or missing references)
		//IL_053e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0543: Unknown result type (might be due to invalid IL or missing references)
		//IL_059d: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Expected Obj, but got Unknown
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0639: Unknown result type (might be due to invalid IL or missing references)
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
						string handle2 = mBornesJ[(int)mJumpers[(int)index].indexDest].Handle;
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
									if (!cfgDI.bJumperCima)
									{
										position = val7.Position;
										double num = position.X + cfgDI.larguraBorne * 1.5;
										position = val7.Position;
										val5 = new Point3d(num, position.Y, 0.0);
									}
									else
									{
										position = val7.Position;
										double num2 = position.X + cfgDI.larguraBorne * 1.5;
										position = val7.Position;
										val5 = new Point3d(num2, position.Y + 10.0, 0.0);
									}
								}
							}
							else if (!cfgDI.bJumperCima)
							{
								position = val7.Position;
								double num3 = position.X + cfgDI.larguraBorne / 2.0;
								position = val7.Position;
								val5 = new Point3d(num3, position.Y, 0.0);
							}
							else
							{
								position = val7.Position;
								double num4 = position.X + cfgDI.larguraBorne / 2.0;
								position = val7.Position;
								val5 = new Point3d(num4, position.Y + 10.0, 0.0);
							}
						}
						Point3d val8 = default;
						val6 = (Entity)Geral.HandleToObject(handle2);
						if (val6 != null)
						{
							BlockReference val9 = (BlockReference)(object)((val6 is BlockReference) ? val6 : null);
							if (tipoBorne != 0)
							{
								if (tipoBorne == 1)
								{
									if (!cfgDI.bJumperCima)
									{
										position = val9.Position;
										double num5 = position.X + cfgDI.larguraBorne * 1.5;
										position = val9.Position;
										val8 = new Point3d(num5, position.Y, 0.0);
									}
									else
									{
										position = val9.Position;
										double num6 = position.X + cfgDI.larguraBorne * 1.5;
										position = val9.Position;
										val8 = new Point3d(num6, position.Y + 10.0, 0.0);
									}
								}
							}
							else if (!cfgDI.bJumperCima)
							{
								position = val9.Position;
								double num7 = position.X + cfgDI.larguraBorne / 2.0;
								position = val9.Position;
								val8 = new Point3d(num7, position.Y, 0.0);
							}
							else
							{
								position = val9.Position;
								double num8 = position.X + cfgDI.larguraBorne / 2.0;
								position = val9.Position;
								val8 = new Point3d(num8, position.Y + 10.0, 0.0);
							}
						}
						Point3d val10 = default;
						if (val5.X > val8.X)
						{
							val10 = val5;
							val5 = val8;
							val8 = val10;
						}
						double num9 = 0.0;
						if (!((cfgDI.tipo == 0) | (cfgDI.tipo == 3) | (cfgDI.tipo == 5) | (cfgDI.tipo == 6) | (cfgDI.tipo == 9)))
						{
							if ((cfgDI.tipo == 1) | (cfgDI.tipo == 2) | (cfgDI.tipo == 4) | (cfgDI.tipo == 7) | (cfgDI.tipo == 8) | (cfgDI.tipo == 10))
							{
								num9 = -1.0 * cfgDI.distEntreJumpers;
							}
						}
						else
						{
							num9 = cfgDI.distEntreJumpers;
						}
						int num10 = 1;
						Polyline val15;
						while (true)
						{
							Point2d val11 = new Point2d(val5.X, val5.Y);
							Point2d val12 = new Point2d(val5.X + cfgDI.larguraBorne / 4.0, val5.Y + num9 * (double)num10);
							Point2d val13 = new Point2d(val8.X - cfgDI.larguraBorne / 4.0, val8.Y + num9 * (double)num10);
							Point2d val14 = new Point2d(val8.X, val8.Y);
							val15 = new Polyline();
							((Entity)val15).SetDatabaseDefaults();
							val15.AddVertexAt(0, val11, 0.0, 0.0, 0.0);
							val15.AddVertexAt(1, val12, 0.0, 0.0, 0.0);
							val15.AddVertexAt(2, val13, 0.0, 0.0, 0.0);
							val15.AddVertexAt(3, val14, 0.0, 0.0, 0.0);
							((Entity)val15).Layer = pagina;
							((Entity)val15).ColorIndex = cfgDI.corJumper;
							((Entity)val15).LineWeight = (LineWeight)9;
							if (!w91TxoeIGN(val12.Y, val12.X, val13.X, pagina, revisao, painel))
							{
								break;
							}
							num10++;
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
						XDataDInterlig.GravarXDataJumper(ref ent, revisao, painel, bnO, bnD);
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

	private static bool w91TxoeIGN(double P_0, double P_1, double P_2, string P_3, string P_4, int P_5)
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
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected Obj, but got Unknown
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
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
						bool flag = XDataDInterlig.LerXDataJumper(ref ent, ref P_4, ref P_5, ref bnO, ref bnD);
						val4 = (Polyline)ent;
						Point2d val5;
						if (!flag)
						{
							ent = (Entity)(object)val4;
							flag = false;
							bool flag2 = XDataDInterlig.LerXDataVeia(ref ent, ref P_4, ref P_5, ref tag_cabo, ref veia, ref handle, ref flag);
							val4 = (Polyline)ent;
							if (!flag2)
							{
								continue;
							}
							LineSegment2d lineSegment2dAt = val4.GetLineSegment2dAt(0);
							val5 = lineSegment2dAt.StartPoint;
							if (P_0 == val5.Y)
							{
								val5 = lineSegment2dAt.StartPoint;
								bool flag3 = P_2 > val5.X;
								val5 = lineSegment2dAt.EndPoint;
								bool num = flag3 & (P_2 > val5.X);
								val5 = lineSegment2dAt.StartPoint;
								bool num2 = num & (P_1 > val5.X);
								val5 = lineSegment2dAt.EndPoint;
								bool num3 = num2 & (P_1 > val5.X);
								val5 = lineSegment2dAt.StartPoint;
								bool flag4 = P_2 < val5.X;
								val5 = lineSegment2dAt.EndPoint;
								bool num4 = flag4 & (P_2 < val5.X);
								val5 = lineSegment2dAt.StartPoint;
								bool num5 = num4 & (P_1 < val5.X);
								val5 = lineSegment2dAt.EndPoint;
								if (!(num3 | (num5 & (P_1 < val5.X))))
								{
									result = true;
									break;
								}
							}
							continue;
						}
						LineSegment2d lineSegment2dAt2 = val4.GetLineSegment2dAt(1);
						val5 = lineSegment2dAt2.StartPoint;
						if (P_0 == val5.Y)
						{
							val5 = lineSegment2dAt2.StartPoint;
							bool flag5 = P_2 > val5.X;
							val5 = lineSegment2dAt2.EndPoint;
							bool num6 = flag5 & (P_2 > val5.X);
							val5 = lineSegment2dAt2.StartPoint;
							bool num7 = num6 & (P_1 > val5.X);
							val5 = lineSegment2dAt2.EndPoint;
							bool num8 = num7 & (P_1 > val5.X);
							val5 = lineSegment2dAt2.StartPoint;
							bool flag6 = P_2 < val5.X;
							val5 = lineSegment2dAt2.EndPoint;
							bool num9 = flag6 & (P_2 < val5.X);
							val5 = lineSegment2dAt2.StartPoint;
							bool num10 = num9 & (P_1 < val5.X);
							val5 = lineSegment2dAt2.EndPoint;
							if (!(num8 | (num10 & (P_1 < val5.X))))
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

	private static bool vNxTbFSm0s(double P_0, string P_1, string P_2, int P_3)
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
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected Obj, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
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
						if (Operators.CompareString(P_1, val3.Layer, TextCompare: true) != 0)
						{
							continue;
						}
						Polyline val4 = (Polyline)(object)((val3 is Polyline) ? val3 : null);
						if (val4 == null)
						{
							continue;
						}
						DeclaracoesInterligacao.borneAranha borneAranha = default;
						DeclaracoesInterligacao.borneAranha borneAranha2 = default;
						string tag_cabo = "";
						string veia = "";
						string handle = "";
						Entity ent = (Entity)(object)val4;
						bool bRebatido = false;
						bool flag = XDataDInterlig.LerXDataVeia(ref ent, ref P_2, ref P_3, ref tag_cabo, ref veia, ref handle, ref bRebatido);
						val4 = (Polyline)ent;
						if (flag && Operators.CompareString(veia, "H", TextCompare: true) == 0)
						{
							LineSegment2d lineSegment2dAt = val4.GetLineSegment2dAt(0);
							Point2d startPoint = lineSegment2dAt.StartPoint;
							if (P_0 == startPoint.Y)
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

	public static void desenhaJumper2(string revisao, int painel, ref DeclaracoesInterligacao.borneJ[] mBornesJ, ref DeclaracoesInterligacao.jumper[] mJumpers, long index, ref DeclaracoesInterligacao.ConfigDInterlig cfgDI)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected Obj, but got Unknown
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected Obj, but got Unknown
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0749: Unknown result type (might be due to invalid IL or missing references)
		//IL_074e: Unknown result type (might be due to invalid IL or missing references)
		//IL_076b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0770: Unknown result type (might be due to invalid IL or missing references)
		//IL_078c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0791: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a00: Expected Obj, but got Unknown
		//IL_0a02: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a07: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Expected Obj, but got Unknown
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0713: Unknown result type (might be due to invalid IL or missing references)
		//IL_0718: Unknown result type (might be due to invalid IL or missing references)
		//IL_0734: Unknown result type (might be due to invalid IL or missing references)
		//IL_0739: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07da: Unknown result type (might be due to invalid IL or missing references)
		//IL_07df: Unknown result type (might be due to invalid IL or missing references)
		//IL_0946: Unknown result type (might be due to invalid IL or missing references)
		//IL_094b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0968: Unknown result type (might be due to invalid IL or missing references)
		//IL_096d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0989: Unknown result type (might be due to invalid IL or missing references)
		//IL_098e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ae: Expected Obj, but got Unknown
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Expected Obj, but got Unknown
		//IL_0692: Unknown result type (might be due to invalid IL or missing references)
		//IL_0697: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0910: Unknown result type (might be due to invalid IL or missing references)
		//IL_0915: Unknown result type (might be due to invalid IL or missing references)
		//IL_0931: Unknown result type (might be due to invalid IL or missing references)
		//IL_0936: Unknown result type (might be due to invalid IL or missing references)
		//IL_099e: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_09dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_088f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0894: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		//IL_0307: Expected Obj, but got Unknown
		//IL_0315: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Expected Obj, but got Unknown
		//IL_031c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Expected Obj, but got Unknown
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_0422: Unknown result type (might be due to invalid IL or missing references)
		//IL_0429: Expected Obj, but got Unknown
		//IL_0367: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a12: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a24: Expected Obj, but got Unknown
		//IL_0a26: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0457: Unknown result type (might be due to invalid IL or missing references)
		//IL_045e: Expected Obj, but got Unknown
		//IL_047a: Unknown result type (might be due to invalid IL or missing references)
		//IL_047f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0488: Unknown result type (might be due to invalid IL or missing references)
		//IL_048a: Unknown result type (might be due to invalid IL or missing references)
		//IL_048c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0493: Expected Obj, but got Unknown
		//IL_04a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04be: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c5: Expected Obj, but got Unknown
		//IL_04d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04da: Unknown result type (might be due to invalid IL or missing references)
		//IL_04dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ec: Expected Obj, but got Unknown
		//IL_04fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0501: Expected Obj, but got Unknown
		//IL_0501: Unknown result type (might be due to invalid IL or missing references)
		//IL_0508: Expected Obj, but got Unknown
		//IL_050e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a53: Expected Obj, but got Unknown
		//IL_054c: Unknown result type (might be due to invalid IL or missing references)
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
							if (!((cfgDI.tipo == 0) | (cfgDI.tipo == 3) | (cfgDI.tipo == 5) | (cfgDI.tipo == 6) | (cfgDI.tipo == 9)))
							{
								if ((cfgDI.tipo == 1) | (cfgDI.tipo == 2) | (cfgDI.tipo == 4) | (cfgDI.tipo == 7) | (cfgDI.tipo == 8) | (cfgDI.tipo == 10))
								{
									if (tipoBorne != 0)
									{
										if (tipoBorne == 1)
										{
											position = val7.Position;
											double num = position.X + cfgDI.larguraBorne * 1.5;
											position = val7.Position;
											val5 = new Point3d(num, position.Y, 0.0);
											text = "JumperSaiBaixo";
										}
									}
									else
									{
										position = val7.Position;
										double num2 = position.X + cfgDI.larguraBorne / 2.0;
										position = val7.Position;
										val5 = new Point3d(num2, position.Y, 0.0);
										text = "JumperSaiBaixo";
									}
								}
							}
							else if (tipoBorne != 0)
							{
								if (tipoBorne == 1)
								{
									position = val7.Position;
									double num3 = position.X + cfgDI.larguraBorne * 1.5;
									position = val7.Position;
									val5 = new Point3d(num3, position.Y + 10.0, 0.0);
									text = "JumperSaiCima";
								}
							}
							else
							{
								position = val7.Position;
								double num4 = position.X + cfgDI.larguraBorne / 2.0;
								position = val7.Position;
								val5 = new Point3d(num4, position.Y + 10.0, 0.0);
								text = "JumperSaiCima";
							}
						}
						string text2 = "";
						Point3d val8 = default;
						val6 = (Entity)Geral.HandleToObject(handle2);
						if (val6 != null)
						{
							BlockReference val9 = (BlockReference)(object)((val6 is BlockReference) ? val6 : null);
							if (!((cfgDI.tipo == 0) | (cfgDI.tipo == 3) | (cfgDI.tipo == 5) | (cfgDI.tipo == 6) | (cfgDI.tipo == 9)))
							{
								if ((cfgDI.tipo == 1) | (cfgDI.tipo == 2) | (cfgDI.tipo == 4) | (cfgDI.tipo == 7) | (cfgDI.tipo == 8) | (cfgDI.tipo == 10))
								{
									if (tipoBorne != 0)
									{
										if (tipoBorne == 1)
										{
											position = val9.Position;
											double num5 = position.X + cfgDI.larguraBorne * 1.5;
											position = val9.Position;
											val8 = new Point3d(num5, position.Y, 0.0);
											text2 = "JumperEntraBaixo";
										}
									}
									else
									{
										position = val9.Position;
										double num6 = position.X + cfgDI.larguraBorne / 2.0;
										position = val9.Position;
										val8 = new Point3d(num6, position.Y, 0.0);
										text2 = "JumperEntraBaixo";
									}
								}
							}
							else if (tipoBorne != 0)
							{
								if (tipoBorne == 1)
								{
									position = val9.Position;
									double num7 = position.X + cfgDI.larguraBorne * 1.5;
									position = val9.Position;
									val8 = new Point3d(num7, position.Y + 10.0, 0.0);
									text2 = "JumperEntraCima";
								}
							}
							else
							{
								position = val9.Position;
								double num8 = position.X + cfgDI.larguraBorne / 2.0;
								position = val9.Position;
								val8 = new Point3d(num8, position.Y + 10.0, 0.0);
								text2 = "JumperEntraCima";
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
									if (cfgDI.tipo == 8)
									{
										text4 = text4 + DeclaracoesGeral.Conf.PrefixoCruzInterno + W9kTOy0nnY(pagina2) + DeclaracoesGeral.Conf.SufixoCruzInterno;
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
						XDataDInterlig.GravarXDataJumper(ref ent, revisao, painel, bnO, bnD);
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
									if (cfgDI.tipo == 8)
									{
										text5 = text5 + DeclaracoesGeral.Conf.PrefixoCruzInterno + W9kTOy0nnY(pagina2) + DeclaracoesGeral.Conf.SufixoCruzInterno;
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
						XDataDInterlig.GravarXDataJumper(ref ent, revisao, painel, bnO, bnD);
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
							if (XDataDInterlig.LerXDataJumper(ref ent, ref revisao2, ref painel, ref bnO, ref bnD) && ((Operators.CompareString(revisao2, revisao, TextCompare: true) == 0) & (painel == Painel)))
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

	public static void CarregaEquipamentosReguaCentral(ref DeclaracoesInterligacao.structureRI[] mReguas, ref DeclaracoesInterligacao.borneJ[] mBornesJ, ref List<string> lPaineis)
	{
		int num = Information.UBound(mBornesJ);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				if (mBornesJ[i].Posicao != 2)
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

	public static void carregaCabos(string revisao, ref DeclaracoesInterligacao.structureRI[] mReguas, ref DeclaracoesInterligacao.borneJ[] mBornesJ, ref DeclaracoesInterligacao.caboAranha[] mCabos, List<string> lPaineisCima, ref DeclaracoesInterligacao.ConfigDInterlig cfgDI)
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
							string funcao = mReguas[j].Bornes[k].cabos[l].Funcao;
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
							mCabos[num5].Funcao = funcao;
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
								mCabos[num5].Linha = 1;
							}
							else if (posicao == 2)
							{
								if (!lPaineisCima.Contains(sPainelDest))
								{
									mCabos[num5].Linha = 2;
								}
								else
								{
									mCabos[num5].Linha = 0;
								}
							}
							mCabos[num5].X = mBornesJ[i].X + cfgDI.larguraBorne / 2.0;
							mCabos[num5].Y = mBornesJ[i].Y;
							while (true)
							{
								int num6 = Information.UBound(mCabos);
								int num7 = 1;
								while (num7 <= num6)
								{
									if (!((num7 != num5) & (Operators.CompareString(mCabos[num7].Pagina, mCabos[num5].Pagina, TextCompare: true) == 0) & (mCabos[num7].Linha == mCabos[num5].Linha) & (mCabos[num7].X == mCabos[num5].X)))
									{
										num7++;
										continue;
									}
									goto IL_0544;
								}
								break;
								IL_0544:
								mCabos[num5].X += cfgDI.larguraBorne;
							}
						}
					}
				}
			}
			cDadosAccessInterligacao3.fechaConexao();
		}
	}

	public static void insereCabos(string revisao, int Painel, ref DeclaracoesInterligacao.caboAranha[] mCabos, List<string> lCabosInseridos, ref DeclaracoesInterligacao.ConfigDInterlig cfgDI)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_052d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0532: Unknown result type (might be due to invalid IL or missing references)
		//IL_0552: Unknown result type (might be due to invalid IL or missing references)
		//IL_0557: Unknown result type (might be due to invalid IL or missing references)
		//IL_0577: Unknown result type (might be due to invalid IL or missing references)
		//IL_057c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0628: Unknown result type (might be due to invalid IL or missing references)
		//IL_062d: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_047e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0483: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Expected Obj, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Expected Obj, but got Unknown
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Expected Obj, but got Unknown
		//IL_0696: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a8: Expected Obj, but got Unknown
		//IL_06aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_06af: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Expected Obj, but got Unknown
		//IL_046c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0473: Expected Obj, but got Unknown
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Expected Obj, but got Unknown
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Expected Obj, but got Unknown
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0349: Unknown result type (might be due to invalid IL or missing references)
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
						DeclaracoesGeral.Reguas RH = default;
						if (XDataGeral.LeXDataReguaH(ref RH))
						{
							double num = RH.Pti.Y - 3.0 - RH.AltBase;
							double num2 = RH.AltBase + num - cfgDI.alturaInsercaoCabo - cfgDI.margemCima;
							double num3 = RH.AltBase + num / 2.0 + cfgDI.alturaInsercaoCabo;
							double num4 = RH.AltBase + cfgDI.alturaInsercaoCabo;
							if ((cfgDI.tipo == 5) | (cfgDI.tipo == 6))
							{
								num3 -= 55.0;
								num4 += 38.0;
							}
							if (cfgDI.tipo == 0)
							{
								num2 += 10.0;
							}
							int num5 = Information.UBound(mCabos);
							Point3d val5 = default;
							BlockTableRecordEnumerator enumerator = default;
							for (int i = 1; i <= num5; i++)
							{
								if (lCabosInseridos.Contains(mCabos[i].Tag_Cabo))
								{
									continue;
								}
								string text = "";
								if (mCabos[i].Linha != 1)
								{
									if (mCabos[i].Linha != 2)
									{
										if (mCabos[i].Linha == 0)
										{
											val5 = new Point3d(mCabos[i].X, num2, 0.0);
										}
									}
									else
									{
										val5 = new Point3d(mCabos[i].X, num4, 0.0);
									}
								}
								else
								{
									val5 = new Point3d(mCabos[i].X, num3, 0.0);
								}
								if (cfgDI.tipo == 9)
								{
									if (!((mCabos[i].Linha == 1) | (mCabos[i].Linha == 2)))
									{
										if (mCabos[i].Linha == 0)
										{
											val5 = new Point3d(mCabos[i].X, mCabos[i].Y + 50.0, 0.0);
										}
									}
									else
									{
										val5 = new Point3d(mCabos[i].X, mCabos[i].Y - 40.0, 0.0);
									}
								}
								if (mCabos[i].Blindagem)
								{
									if (!mCabos[i].bAterrar)
									{
										text = "CaboBNA";
										if (mCabos[i].Linha == 0)
										{
											text = "CaboIBNA";
										}
									}
									else
									{
										text = "CaboBA";
										if (mCabos[i].Linha == 0)
										{
											text = "CaboIBA";
										}
									}
								}
								else
								{
									text = "Cabo";
									if (mCabos[i].Linha == 0)
									{
										text = "CaboI";
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
											if (Operators.CompareString(left, "TAG", TextCompare: true) != 0)
											{
												if (Operators.CompareString(left, "FORM", TextCompare: true) != 0)
												{
													if (Operators.CompareString(left, "FL", TextCompare: true) != 0)
													{
														if (Operators.CompareString(left, "FUNCAO", TextCompare: true) != 0)
														{
															if (Operators.CompareString(left, "VEIA", TextCompare: true) == 0)
															{
																((DBText)val13).TextString = Conversions.ToString(mCabos[i].lVeiasLivres.Count + mCabos[i].lVeiasUsadas.Count);
															}
														}
														else
														{
															((DBText)val13).TextString = "(" + mCabos[i].Funcao + ")";
														}
													}
													else
													{
														((DBText)val13).TextString = DeclaracoesGeral.Conf.PrefixoCruzInterno + DeclaracoesGeral.Conf.CaracterTerminalIndefinido + DeclaracoesGeral.Conf.SufixoCruzInterno;
													}
												}
												else
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
								XDataDInterlig.GravarXDataCabo(ref ent, revisao, Painel, mCabos[i]);
								val9 = (BlockReference)ent;
							}
							DeclaracoesGeral.bAnularEventos = true;
							val2.Commit();
							DeclaracoesGeral.bAnularEventos = false;
						}
						else
						{
							Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 611]), MsgBoxStyle.Information);
						}
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
						bool flag = XDataDInterlig.LerXDataCabo(ref ent, ref revisao2, ref painel, ref cabo);
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
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
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
					bool bRebatido = false;
					if (!XDataDInterlig.LerXDataVeia(ref ent, ref revisao2, ref painel, ref tag_cabo, ref veia, ref handle, ref bRebatido))
					{
						continue;
					}
					bool flag = false;
					Point3d val5 = ((Curve)val4).StartPoint;
					double y = val5.Y;
					val5 = ((Curve)val4).EndPoint;
					flag = ((y < val5.Y) ? true : false);
					if ((Operators.CompareString(revisao, revisao2, TextCompare: true) == 0) & (Painel == painel) & (Operators.CompareString(handle, "", TextCompare: true) != 0) & !bRebatido)
					{
						if (flag & !list.Contains(handle))
						{
							list.Add(handle);
						}
						if (!flag & !list2.Contains(handle))
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
				if ((mBornesJ[i].Posicao == 1) | (mBornesJ[i].Posicao == 2))
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
					bool bRebatido = false;
					if (XDataDInterlig.LerXDataVeia(ref ent, ref revisao2, ref painel, ref tag_cabo, ref veia, ref handle, ref bRebatido) && ((Operators.CompareString(revisao, revisao2, TextCompare: true) == 0) & (Painel == painel)) && !lCabosInseridos.Contains(tag_cabo))
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

	public static void carregaCabosInseridosPagina(string revisao, int Painel, ref List<string> lCabosInseridos, ref List<string> lCabosPagina)
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
					Entity ent = (Entity)val.GetObject(current, (OpenMode)0);
					string revisao2 = "";
					int painel = 0;
					string tag_cabo = "";
					string veia = "";
					string handle = "";
					bool bRebatido = false;
					if (XDataDInterlig.LerXDataVeia(ref ent, ref revisao2, ref painel, ref tag_cabo, ref veia, ref handle, ref bRebatido) && ((Operators.CompareString(revisao, revisao2, TextCompare: true) == 0) & (Painel != painel) & (Operators.CompareString(ent.Layer, DeclaracoesGeral.ativo.Pagina, TextCompare: true) == 0) & lCabosInseridos.Contains(tag_cabo)) && !lCabosPagina.Contains(tag_cabo))
					{
						lCabosPagina.Add(tag_cabo);
					}
				}
			}
			finally
			{
				((IDisposable)enumerator)?.Dispose();
			}
			lCabosPagina.Sort();
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
							bool flag = XDataDInterlig.LerXDataCabo(ref ent, ref revisao2, ref painel, ref cabo);
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

	public static void ApagaUmCabo(string revisao, int Painel, string tag_cabo)
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
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected Obj, but got Unknown
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
							bool flag = XDataDInterlig.LerXDataCabo(ref ent, ref revisao2, ref painel, ref cabo);
							val5 = (BlockReference)ent;
							if (flag && ((Operators.CompareString(revisao, revisao2, TextCompare: true) == 0) & (Painel == painel) & (Operators.CompareString(cabo.Tag_Cabo, tag_cabo, TextCompare: true) == 0)))
							{
								((DBObject)val5).UpgradeOpen();
								((DBObject)val5).Erase();
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
								bool flag = XDataDInterlig.LerXDataCabo(ref ent, ref revisao2, ref painel, ref cabo);
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
								if (mCabos[j].PaginaNum == mCabos[j + 1].PaginaNum && mCabos[j].Linha > mCabos[j + 1].Linha)
								{
									caboAranha = mCabos[j + 1];
									mCabos[j + 1] = mCabos[j];
									mCabos[j] = caboAranha;
								}
								if (((mCabos[j].PaginaNum == mCabos[j + 1].PaginaNum) & (mCabos[j].Linha == mCabos[j + 1].Linha)) && mCabos[j].ptIns.X > mCabos[j + 1].ptIns.X)
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

	public static void carregaOutrosCabosDWG(string revisao, int Painel, ref DeclaracoesInterligacao.caboAranha[] mOutrosCabos, List<string> lCabosPagina)
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
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
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
								bool flag = XDataDInterlig.LerXDataCabo(ref ent, ref revisao2, ref painel, ref cabo);
								val4 = (BlockReference)ent;
								if (flag && ((Operators.CompareString(revisao, revisao2, TextCompare: true) == 0) & (Painel != painel) & (Operators.CompareString(((Entity)val4).Layer, DeclaracoesGeral.ativo.Pagina, TextCompare: true) == 0) & lCabosPagina.Contains(cabo.Tag_Cabo)))
								{
									int num = Information.UBound(mOutrosCabos) + 1;
									mOutrosCabos = (DeclaracoesInterligacao.caboAranha[])Utils.CopyArray(mOutrosCabos, new DeclaracoesInterligacao.caboAranha[num + 1]);
									mOutrosCabos[num] = cabo;
									mOutrosCabos[num].mIndices = new int[1];
									mOutrosCabos[num].ptIns = val4.Position;
									mOutrosCabos[num].Handle = ((object)((DBObject)val4).Handle/*cast due to constrained. prefix*/).ToString();
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
					cDadosAccessInterligacao3.fechaConexao();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}

	public static void ProcuraEditaCabosRebater(string revisao, int Painel, ref DeclaracoesInterligacao.caboAranha[] mCabos, ref DeclaracoesInterligacao.caboAranha[] mOutrosCabos, ref DeclaracoesInterligacao.caboAranha[] mCabosRebatidos, List<string> lCabosPagina)
	{
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		int num = Information.UBound(mCabos);
		checked
		{
			for (int i = 0; i <= num; i++)
			{
				if (!((Operators.CompareString(mCabos[i].Pagina, DeclaracoesGeral.ativo.Pagina, TextCompare: true) == 0) & (mCabos[i].Linha == 2)) || !lCabosPagina.Contains(mCabos[i].Tag_Cabo))
				{
					continue;
				}
				int num2 = Information.UBound(mOutrosCabos);
				for (int j = 0; j <= num2; j++)
				{
					if (Operators.CompareString(mCabos[i].Tag_Cabo, mOutrosCabos[j].Tag_Cabo, TextCompare: true) == 0)
					{
						mCabos[i].ptIns = new Point3d(mOutrosCabos[j].ptIns.X, mOutrosCabos[j].ptIns.Y - 30.0, 0.0);
						break;
					}
				}
				ApagaUmCabo(revisao, Painel, mCabos[i].Tag_Cabo);
				ApagaVeiasUmCabo(revisao, Painel, mCabos[i].Tag_Cabo);
				mCabosRebatidos = (DeclaracoesInterligacao.caboAranha[])Utils.CopyArray(mCabosRebatidos, new DeclaracoesInterligacao.caboAranha[Information.UBound(mCabosRebatidos) + 1 + 1]);
				mCabosRebatidos[Information.UBound(mCabosRebatidos)] = mCabos[i];
			}
		}
	}

	public static void SubstituiBlocoOutrosCabos(string revisao, int Painel, ref DeclaracoesInterligacao.caboAranha[] mCabosRebatidos, ref DeclaracoesInterligacao.caboAranha[] mOutrosCabos, ref DeclaracoesInterligacao.ConfigDInterlig cfgDI, List<string> lCabosPagina)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected Obj, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected Obj, but got Unknown
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected Obj, but got Unknown
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Expected Obj, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04db: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e2: Expected Obj, but got Unknown
		//IL_04e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Expected Obj, but got Unknown
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Expected Obj, but got Unknown
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Expected Obj, but got Unknown
		//IL_02da: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f1: Expected Obj, but got Unknown
		//IL_03c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ca: Expected Obj, but got Unknown
		//IL_03f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0306: Expected Obj, but got Unknown
		//IL_0306: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Expected Obj, but got Unknown
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0503: Unknown result type (might be due to invalid IL or missing references)
		//IL_050a: Expected Obj, but got Unknown
		//IL_050c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0511: Unknown result type (might be due to invalid IL or missing references)
		//IL_040f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0416: Expected Obj, but got Unknown
		//IL_0435: Unknown result type (might be due to invalid IL or missing references)
		//IL_043a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0443: Unknown result type (might be due to invalid IL or missing references)
		//IL_0445: Unknown result type (might be due to invalid IL or missing references)
		//IL_0447: Unknown result type (might be due to invalid IL or missing references)
		//IL_044e: Expected Obj, but got Unknown
		//IL_0460: Unknown result type (might be due to invalid IL or missing references)
		//IL_0476: Unknown result type (might be due to invalid IL or missing references)
		//IL_047e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0485: Expected Obj, but got Unknown
		//IL_04ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b3: Expected Obj, but got Unknown
		//IL_0360: Unknown result type (might be due to invalid IL or missing references)
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					try
					{
						BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
						BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
						int num = Information.UBound(mOutrosCabos);
						BlockTableRecordEnumerator enumerator2 = default;
						for (int i = 0; i <= num; i++)
						{
							Entity val5 = (Entity)Geral.HandleToObject(mOutrosCabos[i].Handle);
							if (val5 == null)
							{
								continue;
							}
							BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
							string revisao2 = "";
							int painel = 0;
							DeclaracoesInterligacao.caboAranha cabo = default;
							Entity ent = (Entity)(object)val6;
							bool flag = XDataDInterlig.LerXDataCabo(ref ent, ref revisao2, ref painel, ref cabo);
							val6 = (BlockReference)ent;
							if (!flag || !((Operators.CompareString(revisao, revisao2, TextCompare: true) == 0) & (Painel != painel) & (Operators.CompareString(((Entity)val6).Layer, DeclaracoesGeral.ativo.Pagina, TextCompare: true) == 0) & lCabosPagina.Contains(cabo.Tag_Cabo)))
							{
								continue;
							}
							int num2 = Information.UBound(mCabosRebatidos);
							for (int j = 0; j <= num2; j++)
							{
								if (Operators.CompareString(cabo.Tag_Cabo, mCabosRebatidos[j].Tag_Cabo, TextCompare: true) != 0)
								{
									continue;
								}
								string textString = "";
								AttributeCollection attributeCollection = val6.AttributeCollection;
								foreach (object item in attributeCollection)
								{
									ObjectId val7 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
									AttributeReference val8 = (AttributeReference)val7.GetObject((OpenMode)1);
									string tag = val8.Tag;
									if (Operators.CompareString(tag, "FORM", TextCompare: true) == 0)
									{
										textString = ((DBText)val8).TextString;
									}
								}
								string text = val6.Name;
								if (!text.EndsWith("_R"))
								{
									text += "_R";
								}
								Point3d position = val6.Position;
								ObjectId val9 = ObjectId.Null;
								string text2 = "";
								text2 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + cfgDI.diretorio + text + ".dwg";
								if (!((SymbolTable)val3).Has(text))
								{
									Database val10 = new Database(false, true);
									val10.ReadDwgFile(text2, FileShare.Read, true, "");
									DeclaracoesGeral.bAnularEventos = true;
									val9 = database.Insert(text, val10, false);
									((DisposableWrapper)val10).Dispose();
								}
								else
								{
									BlockTableRecord val11 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[text], (OpenMode)0);
									val9 = ((DBObject)val11).Id;
								}
								BlockReference val12 = new BlockReference(position, val9);
								((Entity)val12).Layer = ((Entity)val6).Layer;
								val4.AppendEntity((Entity)(object)val12);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val12, true);
								BlockTableRecord val13 = (BlockTableRecord)val2.GetObject(val9, (OpenMode)0);
								try
								{
									enumerator2 = val13.GetEnumerator();
									while (enumerator2.MoveNext())
									{
										ObjectId current2 = enumerator2.Current;
										Entity val14 = (Entity)val2.GetObject(current2, (OpenMode)0);
										if (!(val14 is AttributeDefinition))
										{
											continue;
										}
										AttributeDefinition val15 = (AttributeDefinition)val14;
										AttributeReference val16 = new AttributeReference();
										val16.SetAttributeFromBlock(val15, val12.BlockTransform);
										string left = val15.Tag.ToUpper();
										if (Operators.CompareString(left, "TAG", TextCompare: true) != 0)
										{
											if (Operators.CompareString(left, "FORM", TextCompare: true) == 0)
											{
												((DBText)val16).TextString = textString;
											}
										}
										else
										{
											((DBText)val16).TextString = cabo.Tag_Cabo;
										}
										((DBText)val16).AdjustAlignment(database);
										val12.AttributeCollection.AppendAttribute(val16);
										DeclaracoesGeral.bAnularEventos = true;
										val2.AddNewlyCreatedDBObject((DBObject)(object)val16, true);
										((Entity)val16).Draw();
									}
								}
								finally
								{
									((IDisposable)enumerator2)?.Dispose();
								}
								((Entity)val12).Draw();
								ent = (Entity)(object)val12;
								XDataDInterlig.GravarXDataCabo(ref ent, revisao, painel, cabo);
								val12 = (BlockReference)ent;
								((DBObject)val6).UpgradeOpen();
								((DBObject)val6).Erase();
								text2 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + cfgDI.diretorio + "Cabo_REBAT.dwg";
								ObjectId val17 = ObjectId.Null;
								if (!((SymbolTable)val3).Has("Cabo_REBAT"))
								{
									Database val18 = new Database(false, true);
									val18.ReadDwgFile(text2, FileShare.Read, true, "");
									DeclaracoesGeral.bAnularEventos = true;
									val17 = database.Insert("Cabo_REBAT", val18, false);
									((DisposableWrapper)val18).Dispose();
								}
								else
								{
									BlockTableRecord val19 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)["Cabo_REBAT"], (OpenMode)0);
									val17 = ((DBObject)val19).Id;
								}
								BlockReference val20 = new BlockReference(position, val17);
								((Entity)val20).Layer = ((Entity)val6).Layer;
								val4.AppendEntity((Entity)(object)val20);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val20, true);
								val13 = (BlockTableRecord)val2.GetObject(val17, (OpenMode)0);
								mCabosRebatidos[j].Linha = 3;
								ent = (Entity)(object)val20;
								XDataDInterlig.GravarXDataCabo(ref ent, revisao, Painel, mCabosRebatidos[j]);
								val20 = (BlockReference)ent;
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
					finally
					{
						cDadosAccessInterligacao3.fechaConexao();
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

	public static void relacionaCabosBornes(int Painel, ref DeclaracoesInterligacao.structureRI[] mReguas, ref DeclaracoesInterligacao.borneJ[] mBornesJ, ref DeclaracoesInterligacao.caboAranha[] mCabos)
	{
		vQiEi3p5jhL1O6WRxSw9[] array = new vQiEi3p5jhL1O6WRxSw9[1];
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
							string funcaoVeia = mReguas[j].Bornes[k].cabos[l].FuncaoVeia;
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
									if ((Operators.CompareString(array[n].uaNp5L50Vca, tag_Cabo, TextCompare: true) == 0) & (array[n].Ha2p5wm1p9f == veia))
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
									mCabos[i].mDestinos[num7].FuncaoVeia = funcaoVeia;
									array = (vQiEi3p5jhL1O6WRxSw9[])Utils.CopyArray(array, new vQiEi3p5jhL1O6WRxSw9[Information.UBound(array) + 1 + 1]);
									array[Information.UBound(array)].uaNp5L50Vca = tag_Cabo;
									array[Information.UBound(array)].Ha2p5wm1p9f = veia;
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

	public static void insereVeias(string revisao, int Painel, ref DeclaracoesInterligacao.borneJ[] mBornesJ, ref DeclaracoesInterligacao.caboAranha[] mCabos, ref DeclaracoesInterligacao.cruzamentoCaboAranha[] mInfoVeias, List<string> lCabosInseridos, ref DeclaracoesInterligacao.ConfigDInterlig cfgDI, ref DeclaracoesInterligacao.AltPagUsada[] mAltPag)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_047b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0480: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_04af: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b6: Expected Obj, but got Unknown
		//IL_04ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0511: Unknown result type (might be due to invalid IL or missing references)
		//IL_0537: Unknown result type (might be due to invalid IL or missing references)
		//IL_0568: Unknown result type (might be due to invalid IL or missing references)
		//IL_056f: Expected Obj, but got Unknown
		//IL_0b32: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b93: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b98: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fa7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fae: Expected Obj, but got Unknown
		//IL_0fb0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bcf: Expected Obj, but got Unknown
		//IL_0beb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf0: Unknown result type (might be due to invalid IL or missing references)
		//IL_12e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_1328: Unknown result type (might be due to invalid IL or missing references)
		//IL_132d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1369: Unknown result type (might be due to invalid IL or missing references)
		//IL_136e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fd3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fd5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fdc: Expected Obj, but got Unknown
		//IL_0c1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c24: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c26: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c2d: Expected Obj, but got Unknown
		//IL_13a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_13aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_13dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_13e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0732: Unknown result type (might be due to invalid IL or missing references)
		//IL_0739: Expected Obj, but got Unknown
		//IL_0c46: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c64: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c6b: Expected Obj, but got Unknown
		//IL_150f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1516: Expected Obj, but got Unknown
		//IL_154c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1571: Unknown result type (might be due to invalid IL or missing references)
		//IL_1596: Unknown result type (might be due to invalid IL or missing references)
		//IL_15bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_15ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_15f4: Expected Obj, but got Unknown
		//IL_1418: Unknown result type (might be due to invalid IL or missing references)
		//IL_141d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1459: Unknown result type (might be due to invalid IL or missing references)
		//IL_145e: Unknown result type (might be due to invalid IL or missing references)
		//IL_079b: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_10db: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_10ed: Expected Obj, but got Unknown
		//IL_1600: Unknown result type (might be due to invalid IL or missing references)
		//IL_1605: Unknown result type (might be due to invalid IL or missing references)
		//IL_148b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1490: Unknown result type (might be due to invalid IL or missing references)
		//IL_14c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_14c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1503: Unknown result type (might be due to invalid IL or missing references)
		//IL_1508: Unknown result type (might be due to invalid IL or missing references)
		//IL_1715: Unknown result type (might be due to invalid IL or missing references)
		//IL_171a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1107: Unknown result type (might be due to invalid IL or missing references)
		//IL_110c: Unknown result type (might be due to invalid IL or missing references)
		//IL_16ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_16f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_16fe: Expected Obj, but got Unknown
		//IL_1700: Unknown result type (might be due to invalid IL or missing references)
		//IL_1705: Unknown result type (might be due to invalid IL or missing references)
		//IL_1635: Unknown result type (might be due to invalid IL or missing references)
		//IL_163c: Expected Obj, but got Unknown
		//IL_1658: Unknown result type (might be due to invalid IL or missing references)
		//IL_165d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a70: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a75: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b38: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b3d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b61: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b66: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b6a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c78: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c80: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c88: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c8f: Expected Obj, but got Unknown
		//IL_110e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1115: Expected Obj, but got Unknown
		//IL_167d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1682: Unknown result type (might be due to invalid IL or missing references)
		//IL_1684: Unknown result type (might be due to invalid IL or missing references)
		//IL_168b: Expected Obj, but got Unknown
		//IL_16a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_16dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_16e3: Expected Obj, but got Unknown
		//IL_09ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a38: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a82: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae9: Expected Obj, but got Unknown
		//IL_0aeb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0afd: Expected Obj, but got Unknown
		//IL_1bab: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bb0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bdc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1be1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c17: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c20: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c25: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cfc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d01: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d20: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d44: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d49: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d58: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca4: Expected Obj, but got Unknown
		//IL_0ca4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cab: Expected Obj, but got Unknown
		//IL_0cb1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ccc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d35: Expected Obj, but got Unknown
		//IL_0dd9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dde: Unknown result type (might be due to invalid IL or missing references)
		//IL_0820: Unknown result type (might be due to invalid IL or missing references)
		//IL_0825: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ab7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ab9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ad3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ad8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1afc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b01: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b05: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d93: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dbf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dc4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dfa: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dff: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e47: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e4e: Expected Obj, but got Unknown
		//IL_0e83: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e88: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e91: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e96: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ea1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ea6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ed0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ef6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f27: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f2e: Expected Obj, but got Unknown
		//IL_0f45: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_2006: Unknown result type (might be due to invalid IL or missing references)
		//IL_200b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c81: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ca0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cc4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cc9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cd8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cdd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1edf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ee4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1efe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f03: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f27: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f3b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f40: Unknown result type (might be due to invalid IL or missing references)
		//IL_19da: Unknown result type (might be due to invalid IL or missing references)
		//IL_19df: Unknown result type (might be due to invalid IL or missing references)
		//IL_2012: Unknown result type (might be due to invalid IL or missing references)
		//IL_2019: Expected Obj, but got Unknown
		//IL_2037: Unknown result type (might be due to invalid IL or missing references)
		//IL_085d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0864: Expected Obj, but got Unknown
		//IL_0882: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f71: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f76: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fa2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fa7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fdd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fe2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ff1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ff6: Unknown result type (might be due to invalid IL or missing references)
		//IL_125f: Unknown result type (might be due to invalid IL or missing references)
		//IL_127a: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_12b2: Expected Obj, but got Unknown
		//IL_1a0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a12: Unknown result type (might be due to invalid IL or missing references)
		//IL_2168: Unknown result type (might be due to invalid IL or missing references)
		//IL_216d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2181: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e64: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e83: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ea7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eac: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ebb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ec0: Unknown result type (might be due to invalid IL or missing references)
		//IL_210d: Unknown result type (might be due to invalid IL or missing references)
		//IL_213b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2142: Expected Obj, but got Unknown
		//IL_21b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_21bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_21d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_233a: Unknown result type (might be due to invalid IL or missing references)
		//IL_233f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2353: Unknown result type (might be due to invalid IL or missing references)
		//IL_2206: Unknown result type (might be due to invalid IL or missing references)
		//IL_220b: Unknown result type (might be due to invalid IL or missing references)
		//IL_221f: Unknown result type (might be due to invalid IL or missing references)
		//IL_280b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2839: Unknown result type (might be due to invalid IL or missing references)
		//IL_2840: Expected Obj, but got Unknown
		//IL_225d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2262: Unknown result type (might be due to invalid IL or missing references)
		//IL_2276: Unknown result type (might be due to invalid IL or missing references)
		//IL_24ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_24f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_2505: Unknown result type (might be due to invalid IL or missing references)
		//IL_22bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_22c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_22d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_23ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_23f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_2405: Unknown result type (might be due to invalid IL or missing references)
		//IL_264e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2653: Unknown result type (might be due to invalid IL or missing references)
		//IL_2667: Unknown result type (might be due to invalid IL or missing references)
		//IL_26cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_26d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_26e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_259c: Unknown result type (might be due to invalid IL or missing references)
		//IL_25a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_25b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_2749: Unknown result type (might be due to invalid IL or missing references)
		//IL_274e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2762: Unknown result type (might be due to invalid IL or missing references)
		//IL_27cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_27d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_27e5: Unknown result type (might be due to invalid IL or missing references)
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
						DeclaracoesGeral.Reguas RH = default;
						if (XDataGeral.LeXDataReguaH(ref RH))
						{
							double num = RH.LarguraBase - 14.0;
							double distEntreVeias = cfgDI.distEntreVeias;
							int num2 = Information.UBound(mCabos);
							double num8 = default;
							BlockTableRecordEnumerator enumerator = default;
							Point2d val22 = default;
							Point2d val23 = default;
							Point2d val24 = default;
							int num12 = default;
							Point3d alignmentPoint = default;
							Point2d val35 = default;
							Point2d val36 = default;
							Point2d val37 = default;
							Point2d ptInsTerm = default;
							double num17 = default;
							for (int i = 1; i <= num2; i++)
							{
								if (lCabosInseridos.Contains(mCabos[i].Tag_Cabo) || mCabos[i].Linha == 0)
								{
									continue;
								}
								string tag_Cabo = mCabos[i].Tag_Cabo;
								double num3 = 0.0;
								double num4 = 1000.0;
								object[,] array = new object[6, 1];
								int num5 = Information.UBound(mCabos[i].mIndices);
								for (int j = 1; j <= num5; j++)
								{
									int num6 = mCabos[i].mIndices[j];
									DeclaracoesInterligacao.borneJ borneJ = mBornesJ[num6];
									string text = mCabos[i].mVeias[j];
									string tagDest = mCabos[i].mDestinos[j].tagDest;
									string nReguaDest = mCabos[i].mDestinos[j].nReguaDest;
									string borneDest = mCabos[i].mDestinos[j].borneDest;
									string funcaoVeia = mCabos[i].mDestinos[j].FuncaoVeia;
									double num7 = 0.0;
									if (borneJ.contVeiasLigadas == 1)
									{
										if (borneJ.TipoBorne != 0)
										{
											if (borneJ.TipoBorne == 1)
											{
												num7 = cfgDI.larguraBorne;
											}
										}
										else
										{
											num7 = cfgDI.larguraBorne / 2.0;
										}
									}
									new Point2d(mCabos[i].ptIns.X, mCabos[i].ptIns.Y);
									Point2d val5 = new Point2d(borneJ.ptInsTerm.X + num7, borneJ.ptInsTerm.Y);
									if (Operators.CompareString(mCabos[i].Pagina, borneJ.Pagina, TextCompare: true) == 0 && (((mCabos[i].Linha == 1) & (borneJ.Posicao == 1)) | ((mCabos[i].Linha == 2) & (borneJ.Posicao == 2))))
									{
										if (val5.X > num3)
										{
											num3 = val5.X;
										}
										if (val5.X < num4)
										{
											num4 = val5.X;
										}
										num8 = val5.Y - cfgDI.distInicialBorneCabo;
										_ = val5.Y;
										int num9 = Information.UBound(array, 2) + 1;
										array = (object[,])Utils.CopyArray(array, new object[6, num9 + 1]);
										array[0, num9] = num6;
										array[1, num9] = text;
										array[2, num9] = tagDest;
										array[3, num9] = nReguaDest;
										array[4, num9] = borneDest;
										array[5, num9] = funcaoVeia;
									}
								}
								if (mCabos[i].ptIns.X > num3)
								{
									num3 = mCabos[i].ptIns.X;
								}
								if (mCabos[i].ptIns.X < num4)
								{
									num4 = mCabos[i].ptIns.X;
								}
								if (Information.UBound(array, 2) <= 0)
								{
									continue;
								}
								do
								{
									num8 -= distEntreVeias;
								}
								while (w91TxoeIGN(num8, num3, num4, mCabos[i].Pagina, revisao, Painel));
								Point2d val6 = new Point2d(mCabos[i].ptIns.X, num8);
								Point2d val7 = new Point2d(mCabos[i].ptIns.X, mCabos[i].ptIns.Y);
								Polyline val8 = new Polyline();
								((Entity)val8).SetDatabaseDefaults();
								((Entity)val8).ColorIndex = cfgDI.corLinhaVCabo;
								((Entity)val8).Layer = mCabos[i].Pagina;
								((Entity)val8).LineWeight = (LineWeight)9;
								val8.AddVertexAt(0, val6, 0.0, 0.0, 0.0);
								val8.AddVertexAt(1, val7, 0.0, 0.0, 0.0);
								val4.AppendEntity((Entity)(object)val8);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
								Entity ent = (Entity)(object)val8;
								XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, "", "");
								val8 = (Polyline)ent;
								if (Information.UBound(array, 2) > 1)
								{
									Hatch val9 = KE6TMvkKPi(new Point3d(val6.X, val6.Y, 0.0), mCabos[i].Pagina, cfgDI.corHatch, cfgDI.raioHatch);
									try
									{
										ent = (Entity)(object)val9;
										XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, "", "");
									}
									finally
									{
										((IDisposable)val9)?.Dispose();
									}
								}
								mAltPag = (DeclaracoesInterligacao.AltPagUsada[])Utils.CopyArray(mAltPag, new DeclaracoesInterligacao.AltPagUsada[Information.UBound(mAltPag) + 1 + 1]);
								mAltPag[Information.UBound(mAltPag)].Y = val6.Y;
								mAltPag[Information.UBound(mAltPag)].Pagina = ((Entity)val8).Layer;
								int count = mCabos[i].lVeiasUsadas.Count;
								int num10 = Information.UBound(array, 2);
								if (count > num10)
								{
									string text2 = "";
									text2 = "VeiaSai";
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
									BlockReference val13 = ((cfgDI.tipo == 0) ? new BlockReference(new Point3d(num, val6.Y, 0.0), val10) : new BlockReference(new Point3d(val6.X, val6.Y, 0.0), val10));
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
									XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, mCabos[i].Tag_Cabo, "", "");
									val13 = (BlockReference)ent;
									mInfoVeias = (DeclaracoesInterligacao.cruzamentoCaboAranha[])Utils.CopyArray(mInfoVeias, new DeclaracoesInterligacao.cruzamentoCaboAranha[Information.UBound(mInfoVeias) + 1 + 1]);
									mInfoVeias[Information.UBound(mInfoVeias)].mBornes = new DeclaracoesInterligacao.borneCruzamentoCaboAranha[1];
									mInfoVeias[Information.UBound(mInfoVeias)].tag_Cabo = mCabos[i].Tag_Cabo;
									mInfoVeias[Information.UBound(mInfoVeias)].coluna = mCabos[i].Coluna;
									mInfoVeias[Information.UBound(mInfoVeias)].mBornes[0].ID = ((DBObject)val13).ObjectId;
									mInfoVeias[Information.UBound(mInfoVeias)].mBornes[0].rb = "";
									mInfoVeias[Information.UBound(mInfoVeias)].mBornes[0].pagina = mCabos[i].Pagina;
									if (cfgDI.tipo == 0)
									{
										Polyline val18 = new Polyline();
										((Entity)val18).SetDatabaseDefaults();
										((Entity)val18).Layer = ((Entity)val13).Layer;
										((Entity)val18).LineWeight = (LineWeight)9;
										((Entity)val18).ColorIndex = cfgDI.corVeias;
										double x = val6.X;
										Point3d position = val13.Position;
										Point2d val19 = new Point2d(x, position.Y);
										Point2d val20 = new Point2d(num, val19.Y);
										val18.AddVertexAt(0, val19, 0.0, 0.0, 0.0);
										val18.AddVertexAt(1, val20, 0.0, 0.0, 0.0);
										val4.AppendEntity((Entity)(object)val18);
										DeclaracoesGeral.bAnularEventos = true;
										val2.AddNewlyCreatedDBObject((DBObject)(object)val18, true);
										ent = (Entity)(object)val18;
										XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, "H", "");
										val18 = (Polyline)ent;
										Hatch val21 = KE6TMvkKPi(new Point3d(val6.X, val6.Y, 0.0), mCabos[i].Pagina, cfgDI.corHatch, cfgDI.raioHatch);
										try
										{
											ent = (Entity)(object)val21;
											XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, "", "");
										}
										finally
										{
											((IDisposable)val21)?.Dispose();
										}
									}
								}
								if ((mCabos[i].lVeiasLivres.Count > 0) & ((cfgDI.tipo == 0) | (cfgDI.tipo == 1) | (cfgDI.tipo == 2) | (cfgDI.tipo == 3) | (cfgDI.tipo == 4) | (cfgDI.tipo == 5) | (cfgDI.tipo == 6) | (cfgDI.tipo == 7) | (cfgDI.tipo == 9) | (cfgDI.tipo == 10)))
								{
									if (!((cfgDI.tipo == 0) | (cfgDI.tipo == 1)))
									{
										if (cfgDI.tipo != 3)
										{
											if (!((cfgDI.tipo == 4) | (cfgDI.tipo == 7) | (cfgDI.tipo == 10)))
											{
												if ((cfgDI.tipo == 2) | (cfgDI.tipo == 5) | (cfgDI.tipo == 6) | (cfgDI.tipo == 9))
												{
													val22 = new Point2d(mCabos[i].ptIns.X, mCabos[i].ptIns.Y);
													val23 = new Point2d(mCabos[i].ptIns.X - 1.25, mCabos[i].ptIns.Y);
													val24 = new Point2d(mCabos[i].ptIns.X - 1.25, mCabos[i].ptIns.Y + 1.0);
												}
											}
											else
											{
												val22 = new Point2d(mCabos[i].ptIns.X, mCabos[i].ptIns.Y - 1.0);
												val24 = new Point2d(mCabos[i].ptIns.X + 3.0, mCabos[i].ptIns.Y - 0.7);
											}
										}
										else
										{
											val22 = new Point2d(mCabos[i].ptIns.X, mCabos[i].ptIns.Y - 2.0);
											val24 = new Point2d(mCabos[i].ptIns.X + 3.25, mCabos[i].ptIns.Y);
										}
									}
									else
									{
										val22 = new Point2d(mCabos[i].ptIns.X, mCabos[i].ptIns.Y - 2.0);
										val23 = new Point2d(mCabos[i].ptIns.X + 1.25, mCabos[i].ptIns.Y - 2.0);
										val24 = new Point2d(mCabos[i].ptIns.X + 1.25, mCabos[i].ptIns.Y - 1.0);
									}
									if (!((cfgDI.tipo == 0) | (cfgDI.tipo == 1) | (cfgDI.tipo == 2) | (cfgDI.tipo == 5) | (cfgDI.tipo == 6) | (cfgDI.tipo == 9)))
									{
										if ((cfgDI.tipo == 3) | (cfgDI.tipo == 4) | (cfgDI.tipo == 7) | (cfgDI.tipo == 10))
										{
											string text4 = "Rabicho";
											ObjectId val25 = ObjectId.Null;
											string text5 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + cfgDI.diretorio + text4 + ".dwg";
											if (!((SymbolTable)val3).Has(text4))
											{
												Database val26 = new Database(false, true);
												val26.ReadDwgFile(text5, FileShare.Read, true, "");
												DeclaracoesGeral.bAnularEventos = true;
												val25 = database.Insert(text4, val26, false);
												((DisposableWrapper)val26).Dispose();
											}
											else
											{
												BlockTableRecord val27 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[text4], (OpenMode)0);
												val25 = ((DBObject)val27).Id;
											}
											BlockReference val28 = new BlockReference(new Point3d(val22.X, val22.Y, 0.0), val25);
											((Entity)val28).Layer = mCabos[i].Pagina;
											val4.AppendEntity((Entity)(object)val28);
											DeclaracoesGeral.bAnularEventos = true;
											val2.AddNewlyCreatedDBObject((DBObject)(object)val28, true);
											((Entity)val28).Draw();
											ent = (Entity)(object)val28;
											XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, "", "");
											val28 = (BlockReference)ent;
										}
									}
									else
									{
										Polyline val29 = new Polyline();
										((Entity)val29).SetDatabaseDefaults();
										((Entity)val29).Layer = mCabos[i].Pagina;
										((Entity)val29).ColorIndex = cfgDI.corTracoVeiasReservas;
										((Entity)val29).LineWeight = (LineWeight)9;
										val29.AddVertexAt(0, val22, 0.0, 0.0, 0.0);
										val29.AddVertexAt(1, val23, 0.0, 0.0, 0.0);
										val29.AddVertexAt(2, val24, 0.0, 0.0, 0.0);
										val4.AppendEntity((Entity)(object)val29);
										DeclaracoesGeral.bAnularEventos = true;
										val2.AddNewlyCreatedDBObject((DBObject)(object)val29, true);
										ent = (Entity)(object)val29;
										XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, "", "");
										val29 = (Polyline)ent;
									}
									TextStyleTable val30 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)0);
									ObjectId textStyleId = (((SymbolTable)val30).Has(cfgDI.textStyle) ? ((SymbolTable)val30)[cfgDI.textStyle] : ((SymbolTable)val30)["Standard"]);
									DBText val31 = new DBText();
									if (!((cfgDI.tipo == 0) | (cfgDI.tipo == 3) | (cfgDI.tipo == 6) | (cfgDI.tipo == 7)))
									{
										if ((cfgDI.tipo == 1) | (cfgDI.tipo == 2) | (cfgDI.tipo == 4) | (cfgDI.tipo == 5) | (cfgDI.tipo == 9) | (cfgDI.tipo == 10))
										{
											bool flag = true;
											bool flag2 = true;
											int num11 = 0;
											string text6 = "";
											if (mCabos[i].lVeiasLivres.Count > 2)
											{
												foreach (string lVeiasLivre in mCabos[i].lVeiasLivres)
												{
													if (Versioned.IsNumeric(lVeiasLivre))
													{
														if (!flag)
														{
															num12 = Conversions.ToInteger(lVeiasLivre);
															num11++;
															if (num12 != num11)
															{
																flag2 = false;
																break;
															}
														}
														else
														{
															flag = false;
															text6 = lVeiasLivre;
															num11 = Conversions.ToInteger(lVeiasLivre);
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
												if ((cfgDI.tipo == 1) | (cfgDI.tipo == 2))
												{
													val31.TextString = "(";
												}
												foreach (string lVeiasLivre2 in mCabos[i].lVeiasLivres)
												{
													DBText val32;
													if (!flag)
													{
														(val32 = val31).TextString = val32.TextString + ",";
													}
													(val32 = val31).TextString = val32.TextString + lVeiasLivre2;
													flag = false;
												}
												if ((cfgDI.tipo == 1) | (cfgDI.tipo == 2))
												{
													DBText val32;
													(val32 = val31).TextString = val32.TextString + ")";
												}
											}
											else if (!((cfgDI.tipo == 1) | (cfgDI.tipo == 2)))
											{
												if ((cfgDI.tipo == 4) | (cfgDI.tipo == 5) | (cfgDI.tipo == 9) | (cfgDI.tipo == 10))
												{
													val31.TextString = Conversions.ToString(Operators.AddObject(Operators.AddObject(text6, DeclaracoesGeral.mMensagem[1, 1446]), num12.ToString()));
												}
											}
											else
											{
												val31.TextString = Conversions.ToString(Operators.AddObject(Operators.AddObject(Operators.AddObject("(" + text6, DeclaracoesGeral.mMensagem[1, 1446]), num12.ToString()), ")"));
											}
										}
									}
									else
									{
										val31.TextString = "(" + mCabos[i].lVeiasLivres.Count + ")";
									}
									((Entity)val31).Layer = mCabos[i].Pagina;
									((Entity)val31).ColorIndex = cfgDI.corTextoVeiasReservas;
									val31.Oblique = cfgDI.anguloTextoVeiasReservas;
									val31.Height = cfgDI.alturaFonteReservas;
									val31.TextStyleId = textStyleId;
									val31.WidthFactor = 0.9;
									if (!((cfgDI.tipo == 0) | (cfgDI.tipo == 1) | (cfgDI.tipo == 2) | (cfgDI.tipo == 5) | (cfgDI.tipo == 6) | (cfgDI.tipo == 9)))
									{
										if ((cfgDI.tipo == 3) | (cfgDI.tipo == 4) | (cfgDI.tipo == 7) | (cfgDI.tipo == 10))
										{
											alignmentPoint = new Point3d(val24.X, val24.Y, 0.0);
											val31.HorizontalMode = (TextHorizontalMode)0;
											val31.VerticalMode = (TextVerticalMode)3;
										}
									}
									else
									{
										alignmentPoint = new Point3d(val24.X, val24.Y + 0.5, 0.0);
										val31.HorizontalMode = (TextHorizontalMode)0;
										val31.VerticalMode = (TextVerticalMode)2;
									}
									val31.AlignmentPoint = alignmentPoint;
									val31.Rotation = Math.PI / 2.0;
									val4.AppendEntity((Entity)(object)val31);
									DeclaracoesGeral.bAnularEventos = true;
									val2.AddNewlyCreatedDBObject((DBObject)(object)val31, true);
									ent = (Entity)(object)val31;
									XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, "", "");
									val31 = (DBText)ent;
								}
								int num13 = Information.UBound(array, 2);
								for (int k = 1; k <= num13; k++)
								{
									int num14 = Conversions.ToInteger(array[0, k]);
									string text7 = Conversions.ToString(array[1, k]);
									string text8 = Conversions.ToString(array[2, k]);
									string text9 = Conversions.ToString(array[3, k]);
									string text10 = Conversions.ToString(array[4, k]);
									string text11 = Conversions.ToString(array[5, k]);
									DeclaracoesInterligacao.borneJ borneJ2 = mBornesJ[num14];
									string tag = borneJ2.Tag;
									string nRegua = borneJ2.NRegua;
									string borne = borneJ2.Borne;
									Polyline val33 = new Polyline();
									((Entity)val33).SetDatabaseDefaults();
									((Entity)val33).Layer = mCabos[i].Pagina;
									((Entity)val33).LineWeight = (LineWeight)9;
									((Entity)val33).ColorIndex = cfgDI.corVeias;
									if (borneJ2.contVeiasLigadas == 1 && borneJ2.TipoBorne != 0 && borneJ2.TipoBorne == 1)
									{
										mBornesJ[num14].ptInsTerm = new Point2d(borneJ2.ptInsTerm.X + cfgDI.larguraBorne, borneJ2.ptInsTerm.Y);
										borneJ2 = mBornesJ[num14];
									}
									double num15 = 0.0;
									Point2d val34 = new Point2d(mCabos[i].ptIns.X, num8);
									if (mCabos[i].ptIns.X != borneJ2.ptInsTerm.X)
									{
										if (!(mCabos[i].ptIns.X > borneJ2.ptInsTerm.X))
										{
											if (mCabos[i].ptIns.X < borneJ2.ptInsTerm.X)
											{
												if (borneJ2.contVeiasLigadas != 0)
												{
													if (borneJ2.TipoBorne != 0)
													{
														if (borneJ2.TipoBorne == 1)
														{
															val35 = new Point2d(borneJ2.ptInsTerm.X - 1.0, num8);
															val36 = new Point2d(borneJ2.ptInsTerm.X, num8 + 1.0);
															val37 = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y - 2.0);
															num15 = 0.42;
															ptInsTerm = borneJ2.ptInsTerm;
														}
													}
													else
													{
														val35 = new Point2d(borneJ2.ptInsTerm.X + cfgDI.larguraBorne / 2.0 - 1.0, num8);
														val36 = new Point2d(borneJ2.ptInsTerm.X + cfgDI.larguraBorne / 2.0, num8 + 1.0);
														val37 = new Point2d(borneJ2.ptInsTerm.X + cfgDI.larguraBorne / 2.0, borneJ2.ptInsTerm.Y - 2.0);
														num15 = 0.42;
														ptInsTerm = borneJ2.ptInsTerm;
													}
												}
												else
												{
													val35 = new Point2d(borneJ2.ptInsTerm.X - 1.0, num8);
													val36 = new Point2d(borneJ2.ptInsTerm.X, num8 + 1.0);
													val37 = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y - 2.0);
													num15 = 0.42;
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
													val35 = new Point2d(borneJ2.ptInsTerm.X + 1.0, num8);
													val36 = new Point2d(borneJ2.ptInsTerm.X, num8 + 1.0);
													val37 = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y - 2.0);
													num15 = -0.42;
													ptInsTerm = borneJ2.ptInsTerm;
												}
											}
											else
											{
												val35 = new Point2d(borneJ2.ptInsTerm.X + cfgDI.larguraBorne / 2.0 + 1.0, num8);
												val36 = new Point2d(borneJ2.ptInsTerm.X + cfgDI.larguraBorne / 2.0, num8 + 1.0);
												val37 = new Point2d(borneJ2.ptInsTerm.X + cfgDI.larguraBorne / 2.0, borneJ2.ptInsTerm.Y - 2.0);
												num15 = -0.42;
												ptInsTerm = borneJ2.ptInsTerm;
											}
										}
										else
										{
											val35 = new Point2d(borneJ2.ptInsTerm.X + 1.0, num8);
											val36 = new Point2d(borneJ2.ptInsTerm.X, num8 + 1.0);
											val37 = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y - 2.0);
											num15 = -0.42;
											ptInsTerm = borneJ2.ptInsTerm;
										}
									}
									else if (borneJ2.contVeiasLigadas != 0)
									{
										if (borneJ2.TipoBorne != 0)
										{
											if (borneJ2.TipoBorne == 1)
											{
												val35 = val34;
												val36 = new Point2d(borneJ2.ptInsTerm.X, num8 + 1.0);
												val37 = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y - 2.0);
												ptInsTerm = borneJ2.ptInsTerm;
												num15 = 0.0;
											}
										}
										else
										{
											val35 = new Point2d(val34.X + cfgDI.larguraBorne / 2.0 - 1.0, val34.Y);
											val36 = new Point2d(borneJ2.ptInsTerm.X + cfgDI.larguraBorne / 2.0, num8 + 1.0);
											val37 = new Point2d(borneJ2.ptInsTerm.X + cfgDI.larguraBorne / 2.0, borneJ2.ptInsTerm.Y - 2.0);
											ptInsTerm = borneJ2.ptInsTerm;
											num15 = 0.42;
										}
									}
									else
									{
										val35 = val34;
										val36 = new Point2d(borneJ2.ptInsTerm.X, num8 + 1.0);
										val37 = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y - 2.0);
										ptInsTerm = borneJ2.ptInsTerm;
										num15 = 0.0;
									}
									val33.AddVertexAt(0, val34, 0.0, 0.0, 0.0);
									val33.AddVertexAt(1, val35, 0.0, 0.0, 0.0);
									val33.AddVertexAt(2, val36, 0.0, 0.0, 0.0);
									val33.AddVertexAt(3, val37, 0.0, 0.0, 0.0);
									val33.AddVertexAt(4, ptInsTerm, 0.0, 0.0, 0.0);
									val33.SetBulgeAt(1, num15);
									val4.AppendEntity((Entity)(object)val33);
									DeclaracoesGeral.bAnularEventos = true;
									val2.AddNewlyCreatedDBObject((DBObject)(object)val33, true);
									ent = (Entity)(object)val33;
									XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, text7, borneJ2.Handle);
									val33 = (Polyline)ent;
									TextStyleTable val38 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)0);
									ObjectId textStyleId2 = (((SymbolTable)val38).Has(cfgDI.textStyle) ? ((SymbolTable)val38)[cfgDI.textStyle] : ((SymbolTable)val38)["Standard"]);
									if (mCabos[i].lVeiasLivres.Count + mCabos[i].lVeiasUsadas.Count > 1)
									{
										DBText val39 = new DBText();
										((Entity)val39).Layer = ((Entity)val33).Layer;
										val39.Height = cfgDI.alturaFonteVeia;
										val39.TextStyleId = textStyleId2;
										val39.WidthFactor = 0.9;
										val39.Rotation = Math.PI / 2.0;
										((Entity)val39).ColorIndex = cfgDI.corTextoVeia;
										val39.Oblique = cfgDI.anguloTextoVeia;
										if (cfgDI.tipo != 0)
										{
											if (cfgDI.tipo != 3)
											{
												if (!((cfgDI.tipo == 1) | (cfgDI.tipo == 9)))
												{
													if (!((cfgDI.tipo == 2) | (cfgDI.tipo == 4) | (cfgDI.tipo == 7) | (cfgDI.tipo == 10)))
													{
														if ((cfgDI.tipo == 5) | (cfgDI.tipo == 6) | (cfgDI.tipo == 8))
														{
															Point3d alignmentPoint2 = new Point3d(val37.X, val37.Y - 0.5, 0.0);
															val39.HorizontalMode = (TextHorizontalMode)2;
															val39.VerticalMode = (TextVerticalMode)1;
															val39.AlignmentPoint = alignmentPoint2;
															val39.TextString = text7;
														}
													}
													else
													{
														Point3d alignmentPoint3 = new Point3d(val37.X, val37.Y - cfgDI.distEntreJumpers - 0.5, 0.0);
														val39.HorizontalMode = (TextHorizontalMode)2;
														val39.VerticalMode = (TextVerticalMode)1;
														val39.AlignmentPoint = alignmentPoint3;
														val39.TextString = "(" + text7 + ")";
													}
												}
												else
												{
													Point3d alignmentPoint4 = new Point3d(val36.X, val36.Y + 0.5, 0.0);
													val39.HorizontalMode = (TextHorizontalMode)0;
													val39.VerticalMode = (TextVerticalMode)1;
													val39.AlignmentPoint = alignmentPoint4;
													val39.TextString = text7;
												}
											}
											else
											{
												Point3d alignmentPoint5 = new Point3d(val37.X - 0.4, val37.Y, 0.0);
												val39.HorizontalMode = (TextHorizontalMode)2;
												val39.VerticalMode = (TextVerticalMode)0;
												val39.AlignmentPoint = alignmentPoint5;
												val39.TextString = text7;
											}
										}
										else
										{
											Point3d alignmentPoint6 = new Point3d(val37.X - 0.4, val37.Y, 0.0);
											val39.HorizontalMode = (TextHorizontalMode)2;
											val39.VerticalMode = (TextVerticalMode)0;
											val39.AlignmentPoint = alignmentPoint6;
											val39.TextString = text7;
										}
										val4.AppendEntity((Entity)(object)val39);
										DeclaracoesGeral.bAnularEventos = true;
										val2.AddNewlyCreatedDBObject((DBObject)(object)val39, true);
										ent = (Entity)(object)val39;
										XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, text7, "");
										val39 = (DBText)ent;
									}
									string text12 = "";
									DBText val40 = new DBText();
									((Entity)val40).Layer = ((Entity)val33).Layer;
									val40.Height = cfgDI.alturaFonteCruzamento;
									val40.TextStyleId = textStyleId2;
									val40.WidthFactor = 0.85;
									val40.Rotation = Math.PI / 2.0;
									((Entity)val40).ColorIndex = cfgDI.corTextoDestino;
									val40.Oblique = cfgDI.anguloTextoDestino;
									if (cfgDI.tipo != 0)
									{
										if (!((cfgDI.tipo == 3) | (cfgDI.tipo == 10)))
										{
											if (cfgDI.tipo != 1)
											{
												if (cfgDI.tipo != 9)
												{
													if (cfgDI.tipo != 4)
													{
														if (cfgDI.tipo != 5)
														{
															if (cfgDI.tipo != 6)
															{
																if (!((cfgDI.tipo == 2) | (cfgDI.tipo == 8)))
																{
																	if (cfgDI.tipo == 7)
																	{
																		text12 = ((Operators.CompareString(nRegua, "", TextCompare: true) != 0) ? (text12 + nRegua) : (text12 + tag));
																		text12 = text12 + "-" + borne;
																		Point3d alignmentPoint7 = new Point3d(val37.X - 0.4, val37.Y - 7.0, 0.0);
																		val40.HorizontalMode = (TextHorizontalMode)2;
																		val40.VerticalMode = (TextVerticalMode)0;
																		val40.AlignmentPoint = alignmentPoint7;
																	}
																}
																else
																{
																	text12 = text8;
																	if (Operators.CompareString(text9, "", TextCompare: true) != 0)
																	{
																		text12 = text9;
																	}
																	text12 = text12 + "-" + text10;
																	Point3d alignmentPoint8 = new Point3d(val37.X, val37.Y - cfgDI.distEntreJumpers - 9.0, 0.0);
																	val40.HorizontalMode = (TextHorizontalMode)2;
																	val40.VerticalMode = (TextVerticalMode)1;
																	val40.AlignmentPoint = alignmentPoint8;
																}
															}
															else
															{
																text12 = text8;
																if (Operators.CompareString(text9, "", TextCompare: true) != 0)
																{
																	text12 = text9;
																}
																text12 = text12 + "-" + text10;
																Point3d alignmentPoint9 = new Point3d(val37.X, val37.Y - cfgDI.distEntreJumpers - 9.0, 0.0);
																val40.HorizontalMode = (TextHorizontalMode)2;
																val40.VerticalMode = (TextVerticalMode)1;
																val40.AlignmentPoint = alignmentPoint9;
															}
														}
														else
														{
															text12 = ((Operators.CompareString(text9, "", TextCompare: true) != 0) ? (text12 + text9) : (text12 + text8));
															text12 = text12 + "-" + text10;
															text12 = text12 + " (" + borne + ")";
															Point3d alignmentPoint10 = new Point3d(val37.X, val37.Y - cfgDI.distEntreJumpers - 4.0, 0.0);
															val40.HorizontalMode = (TextHorizontalMode)2;
															val40.VerticalMode = (TextVerticalMode)1;
															val40.AlignmentPoint = alignmentPoint10;
														}
													}
													else
													{
														text12 = ((Operators.CompareString(text9, "", TextCompare: true) != 0) ? (text12 + text9) : (text12 + text8));
														text12 = text12 + "-" + text10;
														text12 = ((Operators.CompareString(nRegua, "", TextCompare: true) != 0) ? (text12 + "/" + nRegua) : (text12 + "/" + tag));
														text12 = text12 + "-" + borne;
														Point3d alignmentPoint11 = new Point3d(val37.X, val37.Y - cfgDI.distEntreJumpers - 4.0, 0.0);
														val40.HorizontalMode = (TextHorizontalMode)2;
														val40.VerticalMode = (TextVerticalMode)1;
														val40.AlignmentPoint = alignmentPoint11;
													}
												}
												else
												{
													text12 = text11;
													double num16 = 3.0;
													Point3d alignmentPoint12 = new Point3d(val37.X, val37.Y - num16, 0.0);
													val40.HorizontalMode = (TextHorizontalMode)2;
													val40.VerticalMode = (TextVerticalMode)1;
													val40.AlignmentPoint = alignmentPoint12;
												}
											}
											else
											{
												if ((cfgDI.tipoCruzamento == 1) | (cfgDI.tipoCruzamento == 2))
												{
													text12 = text10;
													text12 = ((Operators.CompareString(text9, "", TextCompare: true) != 0) ? (text12 + "-" + text9) : (text12 + "-" + text8));
												}
												if (cfgDI.tipoCruzamento == 2)
												{
													text12 = ((Operators.CompareString(nRegua, "", TextCompare: true) != 0) ? (text12 + "/" + nRegua) : (text12 + "/" + tag));
													text12 = text12 + "-" + borne;
												}
												if (cfgDI.tipoCruzamento == 3)
												{
													text12 = text11;
												}
												switch (cfgDI.tipoCruzamento)
												{
												case 3:
													num17 = 3.0;
													break;
												case 1:
													num17 = 6.0;
													break;
												case 2:
													num17 = 3.0;
													break;
												}
												Point3d alignmentPoint13 = new Point3d(val37.X - 0.4, val37.Y - num17, 0.0);
												val40.HorizontalMode = (TextHorizontalMode)2;
												val40.VerticalMode = (TextVerticalMode)0;
												val40.AlignmentPoint = alignmentPoint13;
											}
										}
									}
									else
									{
										text12 = text8;
										if (Operators.CompareString(text9, "", TextCompare: true) != 0)
										{
											text12 = text9;
										}
										text12 = text12 + "-" + text10;
										Point3d alignmentPoint14 = new Point3d(val37.X - 0.4, val37.Y - 7.0, 0.0);
										val40.HorizontalMode = (TextHorizontalMode)1;
										val40.VerticalMode = (TextVerticalMode)0;
										val40.AlignmentPoint = alignmentPoint14;
									}
									if ((cfgDI.tipo == 0) | (cfgDI.tipo == 1) | (cfgDI.tipo == 2) | (cfgDI.tipo == 4) | (cfgDI.tipo == 5) | (cfgDI.tipo == 6) | (cfgDI.tipo == 7) | (cfgDI.tipo == 8) | (cfgDI.tipo == 9))
									{
										val40.TextString = text12;
										val4.AppendEntity((Entity)(object)val40);
										DeclaracoesGeral.bAnularEventos = true;
										val2.AddNewlyCreatedDBObject((DBObject)(object)val40, true);
										ent = (Entity)(object)val40;
										XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, text7, "");
										val40 = (DBText)ent;
									}
									mBornesJ[num14].contVeiasLigadas++;
								}
							}
							DeclaracoesGeral.bAnularEventos = true;
							val2.Commit();
							DeclaracoesGeral.bAnularEventos = false;
						}
						else
						{
							Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 611]), MsgBoxStyle.Information);
						}
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

	public static void insereVeiasInv(string revisao, int Painel, ref DeclaracoesInterligacao.borneJ[] mBornesJ, ref DeclaracoesInterligacao.caboAranha[] mCabos, ref DeclaracoesInterligacao.cruzamentoCaboAranha[] mInfoVeias, List<string> lCabosInseridos, ref DeclaracoesInterligacao.ConfigDInterlig cfgDI, ref DeclaracoesInterligacao.AltPagUsada[] mAltPag)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_0468: Unknown result type (might be due to invalid IL or missing references)
		//IL_046d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0495: Unknown result type (might be due to invalid IL or missing references)
		//IL_049a: Unknown result type (might be due to invalid IL or missing references)
		//IL_049c: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a3: Expected Obj, but got Unknown
		//IL_04d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0524: Unknown result type (might be due to invalid IL or missing references)
		//IL_0555: Unknown result type (might be due to invalid IL or missing references)
		//IL_055c: Expected Obj, but got Unknown
		//IL_0ab6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b26: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_122a: Unknown result type (might be due to invalid IL or missing references)
		//IL_122f: Unknown result type (might be due to invalid IL or missing references)
		//IL_126b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1270: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_12b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f3b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f46: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f4d: Expected Obj, but got Unknown
		//IL_0f4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f54: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b62: Expected Obj, but got Unknown
		//IL_0b7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b83: Unknown result type (might be due to invalid IL or missing references)
		//IL_12de: Unknown result type (might be due to invalid IL or missing references)
		//IL_12e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1315: Unknown result type (might be due to invalid IL or missing references)
		//IL_131a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1356: Unknown result type (might be due to invalid IL or missing references)
		//IL_135b: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b4: Expected Obj, but got Unknown
		//IL_13df: Unknown result type (might be due to invalid IL or missing references)
		//IL_13e6: Expected Obj, but got Unknown
		//IL_141c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1441: Unknown result type (might be due to invalid IL or missing references)
		//IL_1466: Unknown result type (might be due to invalid IL or missing references)
		//IL_148c: Unknown result type (might be due to invalid IL or missing references)
		//IL_14bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_14c4: Expected Obj, but got Unknown
		//IL_1392: Unknown result type (might be due to invalid IL or missing references)
		//IL_1397: Unknown result type (might be due to invalid IL or missing references)
		//IL_13d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_13d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_071a: Unknown result type (might be due to invalid IL or missing references)
		//IL_071f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0744: Unknown result type (might be due to invalid IL or missing references)
		//IL_0749: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f72: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f74: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f7b: Expected Obj, but got Unknown
		//IL_0bb2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc0: Expected Obj, but got Unknown
		//IL_104a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1055: Unknown result type (might be due to invalid IL or missing references)
		//IL_105c: Expected Obj, but got Unknown
		//IL_14d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_14d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bfe: Expected Obj, but got Unknown
		//IL_15e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_15ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_1076: Unknown result type (might be due to invalid IL or missing references)
		//IL_107b: Unknown result type (might be due to invalid IL or missing references)
		//IL_15bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_15c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_15ce: Expected Obj, but got Unknown
		//IL_15d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_15d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1505: Unknown result type (might be due to invalid IL or missing references)
		//IL_150c: Expected Obj, but got Unknown
		//IL_1528: Unknown result type (might be due to invalid IL or missing references)
		//IL_152d: Unknown result type (might be due to invalid IL or missing references)
		//IL_191f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1924: Unknown result type (might be due to invalid IL or missing references)
		//IL_19cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_19cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_19e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_19ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a10: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a15: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a19: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_107d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1084: Expected Obj, but got Unknown
		//IL_154d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1552: Unknown result type (might be due to invalid IL or missing references)
		//IL_1554: Unknown result type (might be due to invalid IL or missing references)
		//IL_155b: Expected Obj, but got Unknown
		//IL_1574: Unknown result type (might be due to invalid IL or missing references)
		//IL_15ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_15b3: Expected Obj, but got Unknown
		//IL_0972: Unknown result type (might be due to invalid IL or missing references)
		//IL_0997: Unknown result type (might be due to invalid IL or missing references)
		//IL_09bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a06: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a36: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a66: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6d: Expected Obj, but got Unknown
		//IL_0a6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a81: Expected Obj, but got Unknown
		//IL_1a48: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a79: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ab4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ab9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1abd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ac2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b99: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bb8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bbd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1be1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1be6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bf5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bfa: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_1966: Unknown result type (might be due to invalid IL or missing references)
		//IL_1968: Unknown result type (might be due to invalid IL or missing references)
		//IL_1982: Unknown result type (might be due to invalid IL or missing references)
		//IL_1987: Unknown result type (might be due to invalid IL or missing references)
		//IL_19ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_19b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_19b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_19b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c30: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c61: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c97: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cab: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cb0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c0b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c10: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c22: Expected Obj, but got Unknown
		//IL_1127: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ea3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ea8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b19: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b38: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b3d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b61: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b66: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b75: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d81: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1da0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dc4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dc9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dd8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ddd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c30: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c37: Expected Obj, but got Unknown
		//IL_0c37: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c3e: Expected Obj, but got Unknown
		//IL_0c44: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc8: Expected Obj, but got Unknown
		//IL_0d6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d71: Unknown result type (might be due to invalid IL or missing references)
		//IL_1889: Unknown result type (might be due to invalid IL or missing references)
		//IL_188e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eaf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eb6: Expected Obj, but got Unknown
		//IL_1ed4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0806: Unknown result type (might be due to invalid IL or missing references)
		//IL_080d: Expected Obj, but got Unknown
		//IL_082b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e13: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e44: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e93: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dda: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de1: Expected Obj, but got Unknown
		//IL_0e16: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e24: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e29: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e34: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e39: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e63: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e89: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ec1: Expected Obj, but got Unknown
		//IL_0ed8: Unknown result type (might be due to invalid IL or missing references)
		//IL_11a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_11bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_11f5: Expected Obj, but got Unknown
		//IL_18bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_18c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fe1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fe6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ffa: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cfc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d01: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d20: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d44: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d49: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d58: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f90: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fbe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fc5: Expected Obj, but got Unknown
		//IL_202d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2032: Unknown result type (might be due to invalid IL or missing references)
		//IL_2046: Unknown result type (might be due to invalid IL or missing references)
		//IL_2161: Unknown result type (might be due to invalid IL or missing references)
		//IL_2166: Unknown result type (might be due to invalid IL or missing references)
		//IL_217a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2084: Unknown result type (might be due to invalid IL or missing references)
		//IL_2089: Unknown result type (might be due to invalid IL or missing references)
		//IL_209d: Unknown result type (might be due to invalid IL or missing references)
		//IL_24dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_250a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2511: Expected Obj, but got Unknown
		//IL_21b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_21ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_21ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_20e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_20e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_20fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_230d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2312: Unknown result type (might be due to invalid IL or missing references)
		//IL_2326: Unknown result type (might be due to invalid IL or missing references)
		//IL_2398: Unknown result type (might be due to invalid IL or missing references)
		//IL_239d: Unknown result type (might be due to invalid IL or missing references)
		//IL_23b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_2265: Unknown result type (might be due to invalid IL or missing references)
		//IL_226a: Unknown result type (might be due to invalid IL or missing references)
		//IL_227e: Unknown result type (might be due to invalid IL or missing references)
		//IL_241c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2421: Unknown result type (might be due to invalid IL or missing references)
		//IL_2435: Unknown result type (might be due to invalid IL or missing references)
		//IL_249d: Unknown result type (might be due to invalid IL or missing references)
		//IL_24a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_24b6: Unknown result type (might be due to invalid IL or missing references)
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
						DeclaracoesGeral.Reguas RH = default;
						if (XDataGeral.LeXDataReguaH(ref RH))
						{
							double num = RH.LarguraBase - 14.0;
							double distEntreVeias = cfgDI.distEntreVeias;
							int num2 = Information.UBound(mCabos);
							double num8 = default;
							BlockTableRecordEnumerator enumerator = default;
							Point2d val22 = default;
							Point2d val23 = default;
							Point2d val24 = default;
							int num12 = default;
							Point3d alignmentPoint = default;
							Point2d val35 = default;
							Point2d val36 = default;
							Point2d val37 = default;
							Point2d ptInsTerm = default;
							for (int i = 1; i <= num2; i++)
							{
								if (lCabosInseridos.Contains(mCabos[i].Tag_Cabo) || mCabos[i].Linha != 0)
								{
									continue;
								}
								string tag_Cabo = mCabos[i].Tag_Cabo;
								double num3 = 0.0;
								double num4 = 1000.0;
								object[,] array = new object[6, 1];
								int num5 = Information.UBound(mCabos[i].mIndices);
								for (int j = 1; j <= num5; j++)
								{
									int num6 = mCabos[i].mIndices[j];
									DeclaracoesInterligacao.borneJ borneJ = mBornesJ[num6];
									string text = mCabos[i].mVeias[j];
									string tagDest = mCabos[i].mDestinos[j].tagDest;
									string nReguaDest = mCabos[i].mDestinos[j].nReguaDest;
									string borneDest = mCabos[i].mDestinos[j].borneDest;
									string funcaoVeia = mCabos[i].mDestinos[j].FuncaoVeia;
									double num7 = 0.0;
									if (borneJ.contVeiasLigadas2 == 1)
									{
										if (borneJ.TipoBorne != 0)
										{
											if (borneJ.TipoBorne == 1)
											{
												num7 = cfgDI.larguraBorne;
											}
										}
										else
										{
											num7 = cfgDI.larguraBorne / 2.0;
										}
									}
									new Point2d(mCabos[i].ptIns.X, mCabos[i].ptIns.Y);
									Point2d val5 = new Point2d(borneJ.ptInsTerm.X + num7, borneJ.ptInsTerm.Y);
									if (Operators.CompareString(mCabos[i].Pagina, borneJ.Pagina, TextCompare: true) == 0 && ((mCabos[i].Linha == 0) & (borneJ.Posicao == 2)))
									{
										if (val5.X > num3)
										{
											num3 = val5.X;
										}
										if (val5.X < num4)
										{
											num4 = val5.X;
										}
										num8 = val5.Y + cfgDI.distInicialBorneCabo + 10.0;
										_ = val5.Y;
										int num9 = Information.UBound(array, 2) + 1;
										array = (object[,])Utils.CopyArray(array, new object[6, num9 + 1]);
										array[0, num9] = num6;
										array[1, num9] = text;
										array[2, num9] = tagDest;
										array[3, num9] = nReguaDest;
										array[4, num9] = borneDest;
										array[5, num9] = funcaoVeia;
									}
								}
								if (mCabos[i].ptIns.X > num3)
								{
									num3 = mCabos[i].ptIns.X;
								}
								if (mCabos[i].ptIns.X < num4)
								{
									num4 = mCabos[i].ptIns.X;
								}
								if (Information.UBound(array, 2) <= 0)
								{
									continue;
								}
								do
								{
									num8 += distEntreVeias;
								}
								while (w91TxoeIGN(num8, num3, num4, mCabos[i].Pagina, revisao, Painel));
								Point2d val6 = new Point2d(mCabos[i].ptIns.X, num8);
								Point2d val7 = new Point2d(mCabos[i].ptIns.X, mCabos[i].ptIns.Y);
								Polyline val8 = new Polyline();
								((Entity)val8).SetDatabaseDefaults();
								((Entity)val8).ColorIndex = cfgDI.corLinhaVCabo;
								((Entity)val8).Layer = mCabos[i].Pagina;
								((Entity)val8).LineWeight = (LineWeight)9;
								val8.AddVertexAt(0, val6, 0.0, 0.0, 0.0);
								val8.AddVertexAt(1, val7, 0.0, 0.0, 0.0);
								val4.AppendEntity((Entity)(object)val8);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
								Entity ent = (Entity)(object)val8;
								XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, "", "");
								val8 = (Polyline)ent;
								if (Information.UBound(array, 2) > 1)
								{
									Hatch val9 = KE6TMvkKPi(new Point3d(val6.X, val6.Y, 0.0), mCabos[i].Pagina, cfgDI.corHatch, cfgDI.raioHatch);
									try
									{
										ent = (Entity)(object)val9;
										XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, "", "");
									}
									finally
									{
										((IDisposable)val9)?.Dispose();
									}
								}
								int count = mCabos[i].lVeiasUsadas.Count;
								int num10 = Information.UBound(array, 2);
								if (count > num10)
								{
									string text2 = "";
									text2 = ((cfgDI.tipo == 0) ? "VeiaSai" : "VeiaSaiI");
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
									BlockReference val13 = ((cfgDI.tipo == 0) ? new BlockReference(new Point3d(num, val6.Y, 0.0), val10) : new BlockReference(new Point3d(val6.X, val6.Y, 0.0), val10));
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
									XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, mCabos[i].Tag_Cabo, "", "");
									val13 = (BlockReference)ent;
									mInfoVeias = (DeclaracoesInterligacao.cruzamentoCaboAranha[])Utils.CopyArray(mInfoVeias, new DeclaracoesInterligacao.cruzamentoCaboAranha[Information.UBound(mInfoVeias) + 1 + 1]);
									mInfoVeias[Information.UBound(mInfoVeias)].mBornes = new DeclaracoesInterligacao.borneCruzamentoCaboAranha[1];
									mInfoVeias[Information.UBound(mInfoVeias)].tag_Cabo = mCabos[i].Tag_Cabo;
									mInfoVeias[Information.UBound(mInfoVeias)].coluna = mCabos[i].Coluna;
									mInfoVeias[Information.UBound(mInfoVeias)].mBornes[0].ID = ((DBObject)val13).ObjectId;
									mInfoVeias[Information.UBound(mInfoVeias)].mBornes[0].rb = "";
									mInfoVeias[Information.UBound(mInfoVeias)].mBornes[0].pagina = mCabos[i].Pagina;
									if (cfgDI.tipo == 0)
									{
										Polyline val18 = new Polyline();
										((Entity)val18).SetDatabaseDefaults();
										((Entity)val18).Layer = ((Entity)val13).Layer;
										((Entity)val18).LineWeight = (LineWeight)9;
										((Entity)val18).ColorIndex = cfgDI.corVeias;
										double x = val6.X;
										Point3d position = val13.Position;
										Point2d val19 = new Point2d(x, position.Y);
										Point2d val20 = new Point2d(num, val19.Y);
										val18.AddVertexAt(0, val19, 0.0, 0.0, 0.0);
										val18.AddVertexAt(1, val20, 0.0, 0.0, 0.0);
										val4.AppendEntity((Entity)(object)val18);
										DeclaracoesGeral.bAnularEventos = true;
										val2.AddNewlyCreatedDBObject((DBObject)(object)val18, true);
										ent = (Entity)(object)val18;
										XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, "H", "");
										val18 = (Polyline)ent;
										Hatch val21 = KE6TMvkKPi(new Point3d(val6.X, val6.Y, 0.0), mCabos[i].Pagina, cfgDI.corHatch, cfgDI.raioHatch);
										try
										{
											ent = (Entity)(object)val21;
											XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, "", "");
										}
										finally
										{
											((IDisposable)val21)?.Dispose();
										}
									}
								}
								if ((mCabos[i].lVeiasLivres.Count > 0) & ((cfgDI.tipo == 0) | (cfgDI.tipo == 2) | (cfgDI.tipo == 4) | (cfgDI.tipo == 5) | (cfgDI.tipo == 6) | (cfgDI.tipo == 7) | (cfgDI.tipo == 9) | (cfgDI.tipo == 10)))
								{
									if (cfgDI.tipo != 0)
									{
										if (!((cfgDI.tipo == 2) | (cfgDI.tipo == 5) | (cfgDI.tipo == 6) | (cfgDI.tipo == 9)))
										{
											if ((cfgDI.tipo == 4) | (cfgDI.tipo == 7) | (cfgDI.tipo == 10))
											{
												val22 = new Point2d(mCabos[i].ptIns.X, mCabos[i].ptIns.Y + 1.0);
												val23 = new Point2d(mCabos[i].ptIns.X + 3.0, mCabos[i].ptIns.Y - 0.5);
											}
										}
										else
										{
											val22 = new Point2d(mCabos[i].ptIns.X, mCabos[i].ptIns.Y);
											val24 = new Point2d(mCabos[i].ptIns.X - 1.25, mCabos[i].ptIns.Y);
											val23 = new Point2d(mCabos[i].ptIns.X - 1.25, mCabos[i].ptIns.Y - 1.0);
										}
									}
									else
									{
										val22 = new Point2d(mCabos[i].ptIns.X, mCabos[i].ptIns.Y + 2.0);
										val24 = new Point2d(mCabos[i].ptIns.X + 1.25, mCabos[i].ptIns.Y + 2.0);
										val23 = new Point2d(mCabos[i].ptIns.X + 1.25, mCabos[i].ptIns.Y + 1.0);
									}
									if (!((cfgDI.tipo == 0) | (cfgDI.tipo == 2) | (cfgDI.tipo == 5) | (cfgDI.tipo == 6) | (cfgDI.tipo == 9)))
									{
										if ((cfgDI.tipo == 4) | (cfgDI.tipo == 7) | (cfgDI.tipo == 10))
										{
											string text4 = "Rabicho";
											ObjectId val25 = ObjectId.Null;
											string text5 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + cfgDI.diretorio + text4 + ".dwg";
											if (!((SymbolTable)val3).Has(text4))
											{
												Database val26 = new Database(false, true);
												val26.ReadDwgFile(text5, FileShare.Read, true, "");
												DeclaracoesGeral.bAnularEventos = true;
												val25 = database.Insert(text4, val26, false);
												((DisposableWrapper)val26).Dispose();
											}
											else
											{
												BlockTableRecord val27 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[text4], (OpenMode)0);
												val25 = ((DBObject)val27).Id;
											}
											BlockReference val28 = new BlockReference(new Point3d(val22.X, val22.Y, 0.0), val25);
											((Entity)val28).Layer = mCabos[i].Pagina;
											val4.AppendEntity((Entity)(object)val28);
											DeclaracoesGeral.bAnularEventos = true;
											val2.AddNewlyCreatedDBObject((DBObject)(object)val28, true);
											((Entity)val28).Draw();
											ent = (Entity)(object)val28;
											XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, "", "");
											val28 = (BlockReference)ent;
										}
									}
									else
									{
										Polyline val29 = new Polyline();
										((Entity)val29).SetDatabaseDefaults();
										((Entity)val29).Layer = mCabos[i].Pagina;
										((Entity)val29).ColorIndex = cfgDI.corTracoVeiasReservas;
										((Entity)val29).LineWeight = (LineWeight)9;
										val29.AddVertexAt(0, val22, 0.0, 0.0, 0.0);
										val29.AddVertexAt(1, val24, 0.0, 0.0, 0.0);
										val29.AddVertexAt(2, val23, 0.0, 0.0, 0.0);
										val4.AppendEntity((Entity)(object)val29);
										DeclaracoesGeral.bAnularEventos = true;
										val2.AddNewlyCreatedDBObject((DBObject)(object)val29, true);
										ent = (Entity)(object)val29;
										XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, "", "");
										val29 = (Polyline)ent;
									}
									TextStyleTable val30 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)0);
									ObjectId textStyleId = (((SymbolTable)val30).Has(cfgDI.textStyle) ? ((SymbolTable)val30)[cfgDI.textStyle] : ((SymbolTable)val30)["Standard"]);
									DBText val31 = new DBText();
									if (!((cfgDI.tipo == 0) | (cfgDI.tipo == 6) | (cfgDI.tipo == 7)))
									{
										if ((cfgDI.tipo == 2) | (cfgDI.tipo == 4) | (cfgDI.tipo == 5) | (cfgDI.tipo == 9) | (cfgDI.tipo == 10))
										{
											bool flag = true;
											bool flag2 = true;
											int num11 = 0;
											string text6 = "";
											if (mCabos[i].lVeiasLivres.Count > 2)
											{
												foreach (string lVeiasLivre in mCabos[i].lVeiasLivres)
												{
													if (Versioned.IsNumeric(lVeiasLivre))
													{
														if (!flag)
														{
															num12 = Conversions.ToInteger(lVeiasLivre);
															num11++;
															if (num12 != num11)
															{
																flag2 = false;
																break;
															}
														}
														else
														{
															flag = false;
															text6 = lVeiasLivre;
															num11 = Conversions.ToInteger(lVeiasLivre);
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
												if (cfgDI.tipo == 2)
												{
													val31.TextString = "(";
												}
												foreach (string lVeiasLivre2 in mCabos[i].lVeiasLivres)
												{
													DBText val32;
													if (!flag)
													{
														(val32 = val31).TextString = val32.TextString + ",";
													}
													(val32 = val31).TextString = val32.TextString + lVeiasLivre2;
													flag = false;
												}
												if (cfgDI.tipo == 2)
												{
													DBText val32;
													(val32 = val31).TextString = val32.TextString + ")";
												}
											}
											else if (cfgDI.tipo != 2)
											{
												if ((cfgDI.tipo == 4) | (cfgDI.tipo == 5) | (cfgDI.tipo == 9) | (cfgDI.tipo == 10))
												{
													val31.TextString = Conversions.ToString(Operators.AddObject(Operators.AddObject(text6, DeclaracoesGeral.mMensagem[1, 1446]), num12.ToString()));
												}
											}
											else
											{
												val31.TextString = Conversions.ToString(Operators.AddObject(Operators.AddObject(Operators.AddObject("(" + text6, DeclaracoesGeral.mMensagem[1, 1446]), num12.ToString()), ")"));
											}
										}
									}
									else
									{
										val31.TextString = "(" + mCabos[i].lVeiasLivres.Count + ")";
									}
									((Entity)val31).Layer = mCabos[i].Pagina;
									((Entity)val31).ColorIndex = cfgDI.corTextoVeiasReservas;
									val31.Oblique = cfgDI.anguloTextoVeiasReservas;
									val31.Height = cfgDI.alturaFonteReservas;
									val31.TextStyleId = textStyleId;
									val31.WidthFactor = 0.9;
									if (!((cfgDI.tipo == 0) | (cfgDI.tipo == 2) | (cfgDI.tipo == 5) | (cfgDI.tipo == 6) | (cfgDI.tipo == 9)))
									{
										if ((cfgDI.tipo == 4) | (cfgDI.tipo == 7) | (cfgDI.tipo == 10))
										{
											alignmentPoint = new Point3d(val23.X, val23.Y, 0.0);
											val31.HorizontalMode = (TextHorizontalMode)2;
											val31.VerticalMode = (TextVerticalMode)3;
										}
									}
									else
									{
										alignmentPoint = new Point3d(val23.X, val23.Y - 0.5, 0.0);
										val31.HorizontalMode = (TextHorizontalMode)2;
										val31.VerticalMode = (TextVerticalMode)2;
									}
									val31.AlignmentPoint = alignmentPoint;
									val31.Rotation = Math.PI / 2.0;
									val4.AppendEntity((Entity)(object)val31);
									DeclaracoesGeral.bAnularEventos = true;
									val2.AddNewlyCreatedDBObject((DBObject)(object)val31, true);
									ent = (Entity)(object)val31;
									XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, "", "");
									val31 = (DBText)ent;
								}
								int num13 = Information.UBound(array, 2);
								for (int k = 1; k <= num13; k++)
								{
									int num14 = Conversions.ToInteger(array[0, k]);
									string text7 = Conversions.ToString(array[1, k]);
									string text8 = Conversions.ToString(array[2, k]);
									string text9 = Conversions.ToString(array[3, k]);
									string text10 = Conversions.ToString(array[4, k]);
									string text11 = Conversions.ToString(array[5, k]);
									DeclaracoesInterligacao.borneJ borneJ2 = mBornesJ[num14];
									string tag = borneJ2.Tag;
									string nRegua = borneJ2.NRegua;
									string borne = borneJ2.Borne;
									Polyline val33 = new Polyline();
									((Entity)val33).SetDatabaseDefaults();
									((Entity)val33).Layer = mCabos[i].Pagina;
									((Entity)val33).LineWeight = (LineWeight)9;
									((Entity)val33).ColorIndex = cfgDI.corVeias;
									if (borneJ2.contVeiasLigadas2 == 1 && borneJ2.TipoBorne != 0 && borneJ2.TipoBorne == 1)
									{
										mBornesJ[num14].ptInsTerm = new Point2d(borneJ2.ptInsTerm.X + cfgDI.larguraBorne, borneJ2.ptInsTerm.Y);
										borneJ2 = mBornesJ[num14];
									}
									borneJ2.ptInsTerm = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y + 10.0);
									double num15 = 0.0;
									Point2d val34 = new Point2d(mCabos[i].ptIns.X, num8);
									if (mCabos[i].ptIns.X != borneJ2.ptInsTerm.X)
									{
										if (!(mCabos[i].ptIns.X > borneJ2.ptInsTerm.X))
										{
											if (mCabos[i].ptIns.X < borneJ2.ptInsTerm.X)
											{
												if (borneJ2.contVeiasLigadas2 != 0)
												{
													if (borneJ2.TipoBorne != 0)
													{
														if (borneJ2.TipoBorne == 1)
														{
															val35 = new Point2d(borneJ2.ptInsTerm.X - 1.0, num8);
															val36 = new Point2d(borneJ2.ptInsTerm.X, num8 - 1.0);
															val37 = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y + 2.0);
															num15 = -0.42;
															ptInsTerm = borneJ2.ptInsTerm;
														}
													}
													else
													{
														val35 = new Point2d(borneJ2.ptInsTerm.X + cfgDI.larguraBorne / 2.0 - 1.0, num8);
														val36 = new Point2d(borneJ2.ptInsTerm.X + cfgDI.larguraBorne / 2.0, num8 - 1.0);
														val37 = new Point2d(borneJ2.ptInsTerm.X + cfgDI.larguraBorne / 2.0, borneJ2.ptInsTerm.Y + 2.0);
														num15 = -0.42;
														ptInsTerm = borneJ2.ptInsTerm;
													}
												}
												else
												{
													val35 = new Point2d(borneJ2.ptInsTerm.X - 1.0, num8);
													val36 = new Point2d(borneJ2.ptInsTerm.X, num8 - 1.0);
													val37 = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y + 2.0);
													num15 = -0.42;
													ptInsTerm = borneJ2.ptInsTerm;
												}
											}
										}
										else if (borneJ2.contVeiasLigadas2 != 0)
										{
											if (borneJ2.TipoBorne != 0)
											{
												if (borneJ2.TipoBorne == 1)
												{
													val35 = new Point2d(borneJ2.ptInsTerm.X + 1.0, num8);
													val36 = new Point2d(borneJ2.ptInsTerm.X, num8 - 1.0);
													val37 = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y + 2.0);
													num15 = 0.42;
													ptInsTerm = borneJ2.ptInsTerm;
												}
											}
											else
											{
												val35 = new Point2d(borneJ2.ptInsTerm.X + cfgDI.larguraBorne / 2.0 + 1.0, num8);
												val36 = new Point2d(borneJ2.ptInsTerm.X + cfgDI.larguraBorne / 2.0, num8 - 1.0);
												val37 = new Point2d(borneJ2.ptInsTerm.X + cfgDI.larguraBorne / 2.0, borneJ2.ptInsTerm.Y + 2.0);
												num15 = 0.42;
												ptInsTerm = borneJ2.ptInsTerm;
											}
										}
										else
										{
											val35 = new Point2d(borneJ2.ptInsTerm.X + 1.0, num8);
											val36 = new Point2d(borneJ2.ptInsTerm.X, num8 - 1.0);
											val37 = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y + 2.0);
											num15 = 0.42;
											ptInsTerm = borneJ2.ptInsTerm;
										}
									}
									else if (borneJ2.contVeiasLigadas2 != 0)
									{
										if (borneJ2.TipoBorne != 0)
										{
											if (borneJ2.TipoBorne == 1)
											{
												val35 = val34;
												val36 = new Point2d(borneJ2.ptInsTerm.X, num8 - 1.0);
												val37 = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y + 2.0);
												ptInsTerm = borneJ2.ptInsTerm;
												num15 = 0.0;
											}
										}
										else
										{
											val35 = new Point2d(val34.X + 2.0, val34.Y);
											val36 = new Point2d(borneJ2.ptInsTerm.X + cfgDI.larguraBorne / 2.0, num8 - 1.0);
											val37 = new Point2d(borneJ2.ptInsTerm.X + cfgDI.larguraBorne / 2.0, borneJ2.ptInsTerm.Y + 2.0);
											ptInsTerm = borneJ2.ptInsTerm;
											num15 = -0.42;
										}
									}
									else
									{
										val35 = val34;
										val36 = new Point2d(borneJ2.ptInsTerm.X, num8 - 1.0);
										val37 = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y + 2.0);
										ptInsTerm = borneJ2.ptInsTerm;
										num15 = 0.0;
									}
									val33.AddVertexAt(0, val34, 0.0, 0.0, 0.0);
									val33.AddVertexAt(1, val35, 0.0, 0.0, 0.0);
									val33.AddVertexAt(2, val36, 0.0, 0.0, 0.0);
									val33.AddVertexAt(3, val37, 0.0, 0.0, 0.0);
									val33.AddVertexAt(4, ptInsTerm, 0.0, 0.0, 0.0);
									val33.SetBulgeAt(1, num15);
									val4.AppendEntity((Entity)(object)val33);
									DeclaracoesGeral.bAnularEventos = true;
									val2.AddNewlyCreatedDBObject((DBObject)(object)val33, true);
									ent = (Entity)(object)val33;
									XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, text7, borneJ2.Handle);
									val33 = (Polyline)ent;
									TextStyleTable val38 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)0);
									ObjectId textStyleId2 = (((SymbolTable)val38).Has(cfgDI.textStyle) ? ((SymbolTable)val38)[cfgDI.textStyle] : ((SymbolTable)val38)["Standard"]);
									if (mCabos[i].lVeiasLivres.Count + mCabos[i].lVeiasUsadas.Count > 1)
									{
										DBText val39 = new DBText();
										((Entity)val39).Layer = ((Entity)val33).Layer;
										val39.Height = cfgDI.alturaFonteVeia;
										val39.TextStyleId = textStyleId2;
										val39.WidthFactor = 0.9;
										val39.Rotation = Math.PI / 2.0;
										((Entity)val39).ColorIndex = cfgDI.corTextoVeia;
										val39.Oblique = cfgDI.anguloTextoVeia;
										if (cfgDI.tipo != 0)
										{
											if (cfgDI.tipo != 9)
											{
												if (!((cfgDI.tipo == 2) | (cfgDI.tipo == 4) | (cfgDI.tipo == 7) | (cfgDI.tipo == 10)))
												{
													if ((cfgDI.tipo == 5) | (cfgDI.tipo == 6) | (cfgDI.tipo == 8))
													{
														Point3d alignmentPoint2 = new Point3d(val37.X, val37.Y + 0.5, 0.0);
														val39.HorizontalMode = (TextHorizontalMode)0;
														val39.VerticalMode = (TextVerticalMode)1;
														val39.AlignmentPoint = alignmentPoint2;
														val39.TextString = text7;
													}
												}
												else
												{
													Point3d alignmentPoint2 = new Point3d(val37.X, val37.Y + cfgDI.distEntreJumpers + 0.5, 0.0);
													val39.HorizontalMode = (TextHorizontalMode)0;
													val39.VerticalMode = (TextVerticalMode)1;
													val39.AlignmentPoint = alignmentPoint2;
													val39.TextString = "(" + text7 + ")";
												}
											}
											else
											{
												Point3d alignmentPoint2 = new Point3d(val36.X, val36.Y - 0.5, 0.0);
												val39.HorizontalMode = (TextHorizontalMode)2;
												val39.VerticalMode = (TextVerticalMode)1;
												val39.AlignmentPoint = alignmentPoint2;
												val39.TextString = text7;
											}
										}
										else
										{
											Point3d alignmentPoint2 = new Point3d(val37.X, val37.Y, 0.0);
											val39.HorizontalMode = (TextHorizontalMode)0;
											val39.VerticalMode = (TextVerticalMode)1;
											val39.AlignmentPoint = alignmentPoint2;
											val39.TextString = text7;
										}
										val4.AppendEntity((Entity)(object)val39);
										DeclaracoesGeral.bAnularEventos = true;
										val2.AddNewlyCreatedDBObject((DBObject)(object)val39, true);
										ent = (Entity)(object)val39;
										XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, text7, "");
										val39 = (DBText)ent;
									}
									string text12 = "";
									DBText val40 = new DBText();
									((Entity)val40).Layer = ((Entity)val33).Layer;
									val40.Height = cfgDI.alturaFonteCruzamento;
									val40.TextStyleId = textStyleId2;
									val40.WidthFactor = 0.85;
									val40.Rotation = Math.PI / 2.0;
									((Entity)val40).ColorIndex = cfgDI.corTextoDestino;
									val40.Oblique = cfgDI.anguloTextoDestino;
									if (cfgDI.tipo != 0)
									{
										if (cfgDI.tipo != 10)
										{
											if (cfgDI.tipo != 9)
											{
												if (cfgDI.tipo != 4)
												{
													if (cfgDI.tipo != 5)
													{
														if (cfgDI.tipo != 6)
														{
															if (!((cfgDI.tipo == 2) | (cfgDI.tipo == 8)))
															{
																if (cfgDI.tipo == 7)
																{
																	text12 = ((Operators.CompareString(nRegua, "", TextCompare: true) != 0) ? (text12 + nRegua) : (text12 + tag));
																	text12 = text12 + "-" + borne;
																	Point3d alignmentPoint3 = new Point3d(val37.X, val37.Y + cfgDI.distEntreJumpers + 7.0, 0.0);
																	val40.HorizontalMode = (TextHorizontalMode)0;
																	val40.VerticalMode = (TextVerticalMode)1;
																	val40.AlignmentPoint = alignmentPoint3;
																}
															}
															else
															{
																text12 = text8;
																if (Operators.CompareString(text9, "", TextCompare: true) != 0)
																{
																	text12 = text9;
																}
																text12 = text12 + "-" + text10;
																Point3d alignmentPoint4 = new Point3d(val37.X - 1.15, val37.Y + cfgDI.distEntreJumpers + 9.0, 0.0);
																val40.HorizontalMode = (TextHorizontalMode)0;
																val40.VerticalMode = (TextVerticalMode)2;
																val40.AlignmentPoint = alignmentPoint4;
															}
														}
														else
														{
															text12 = text8;
															if (Operators.CompareString(text9, "", TextCompare: true) != 0)
															{
																text12 = text9;
															}
															text12 = text12 + "-" + text10;
															Point3d alignmentPoint5 = new Point3d(val37.X - 1.15, val37.Y + cfgDI.distEntreJumpers + 9.0, 0.0);
															val40.HorizontalMode = (TextHorizontalMode)0;
															val40.VerticalMode = (TextVerticalMode)2;
															val40.AlignmentPoint = alignmentPoint5;
														}
													}
													else
													{
														text12 = "(" + borne + ") ";
														text12 = ((Operators.CompareString(text9, "", TextCompare: true) != 0) ? (text12 + text9) : (text12 + text8));
														text12 = text12 + "-" + text10;
														Point3d alignmentPoint6 = new Point3d(val37.X, val37.Y + 4.0, 0.0);
														val40.HorizontalMode = (TextHorizontalMode)0;
														val40.VerticalMode = (TextVerticalMode)1;
														val40.AlignmentPoint = alignmentPoint6;
													}
												}
												else
												{
													text12 = ((Operators.CompareString(nRegua, "", TextCompare: true) != 0) ? (text12 + nRegua) : (text12 + tag));
													text12 = text12 + "-" + borne;
													text12 = ((Operators.CompareString(text9, "", TextCompare: true) != 0) ? (text12 + "/" + text9) : (text12 + "/" + text8));
													text12 = text12 + "-" + text10;
													Point3d alignmentPoint7 = new Point3d(val37.X, val37.Y + cfgDI.distEntreJumpers + 4.0, 0.0);
													val40.HorizontalMode = (TextHorizontalMode)0;
													val40.VerticalMode = (TextVerticalMode)1;
													val40.AlignmentPoint = alignmentPoint7;
												}
											}
											else
											{
												text12 = text11;
												double num16 = 3.0;
												Point3d alignmentPoint8 = new Point3d(val37.X, val37.Y + num16, 0.0);
												val40.HorizontalMode = (TextHorizontalMode)0;
												val40.VerticalMode = (TextVerticalMode)1;
												val40.AlignmentPoint = alignmentPoint8;
											}
										}
									}
									else
									{
										text12 = text8;
										if (Operators.CompareString(text9, "", TextCompare: true) != 0)
										{
											text12 = text9;
										}
										text12 = text12 + "-" + text10;
										Point3d alignmentPoint9 = new Point3d(val37.X - 0.4, val37.Y + 7.0, 0.0);
										val40.HorizontalMode = (TextHorizontalMode)1;
										val40.VerticalMode = (TextVerticalMode)0;
										val40.AlignmentPoint = alignmentPoint9;
									}
									if ((cfgDI.tipo == 0) | (cfgDI.tipo == 2) | (cfgDI.tipo == 4) | (cfgDI.tipo == 5) | (cfgDI.tipo == 6) | (cfgDI.tipo == 7) | (cfgDI.tipo == 8) | (cfgDI.tipo == 9))
									{
										val40.TextString = text12;
										val4.AppendEntity((Entity)(object)val40);
										DeclaracoesGeral.bAnularEventos = true;
										val2.AddNewlyCreatedDBObject((DBObject)(object)val40, true);
										ent = (Entity)(object)val40;
										XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, text7, "");
										val40 = (DBText)ent;
									}
									mBornesJ[num14].contVeiasLigadas2++;
								}
							}
							DeclaracoesGeral.bAnularEventos = true;
							val2.Commit();
							DeclaracoesGeral.bAnularEventos = false;
						}
						else
						{
							Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 611]), MsgBoxStyle.Information);
						}
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

	public static void insereVeias2(string revisao, int Painel, ref DeclaracoesInterligacao.borneJ[] mBornesJ, ref DeclaracoesInterligacao.caboAranha[] mCabos, ref DeclaracoesInterligacao.cruzamentoCaboAranha[] mInfoVeias, List<string> lCabosInseridos, ref DeclaracoesInterligacao.ConfigDInterlig cfgDI, ref DeclaracoesInterligacao.AltPagUsada[] mAltPag)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_08b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_26a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_26aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_26cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_26d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_26db: Expected Obj, but got Unknown
		//IL_0ab7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0852: Unknown result type (might be due to invalid IL or missing references)
		//IL_0780: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_27a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_27ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_26ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b96: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba8: Expected Obj, but got Unknown
		//IL_0baa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0baf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0926: Unknown result type (might be due to invalid IL or missing references)
		//IL_092d: Expected Obj, but got Unknown
		//IL_0949: Unknown result type (might be due to invalid IL or missing references)
		//IL_094e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2704: Unknown result type (might be due to invalid IL or missing references)
		//IL_270e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2715: Expected Obj, but got Unknown
		//IL_096e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0973: Unknown result type (might be due to invalid IL or missing references)
		//IL_0975: Unknown result type (might be due to invalid IL or missing references)
		//IL_097c: Expected Obj, but got Unknown
		//IL_0995: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ba: Expected Obj, but got Unknown
		//IL_0c4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c54: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c57: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c66: Expected Obj, but got Unknown
		//IL_0c74: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c7b: Expected Obj, but got Unknown
		//IL_0c7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c82: Expected Obj, but got Unknown
		//IL_0c88: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d38: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d3f: Expected Obj, but got Unknown
		//IL_0cc6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e70: Unknown result type (might be due to invalid IL or missing references)
		//IL_105a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1065: Unknown result type (might be due to invalid IL or missing references)
		//IL_106c: Expected Obj, but got Unknown
		//IL_106e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ea0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ea7: Expected Obj, but got Unknown
		//IL_0ec3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ec8: Unknown result type (might be due to invalid IL or missing references)
		//IL_108c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1091: Unknown result type (might be due to invalid IL or missing references)
		//IL_1093: Unknown result type (might be due to invalid IL or missing references)
		//IL_109a: Expected Obj, but got Unknown
		//IL_0ef7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0efc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0efe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f05: Expected Obj, but got Unknown
		//IL_0f1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f34: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f43: Expected Obj, but got Unknown
		//IL_190f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1914: Unknown result type (might be due to invalid IL or missing references)
		//IL_125b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1262: Expected Obj, but got Unknown
		//IL_12ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_12b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f50: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f55: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f58: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f60: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f67: Expected Obj, but got Unknown
		//IL_0f75: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f7c: Expected Obj, but got Unknown
		//IL_0f7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f83: Expected Obj, but got Unknown
		//IL_0f89: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fa4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1006: Unknown result type (might be due to invalid IL or missing references)
		//IL_100d: Expected Obj, but got Unknown
		//IL_19e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_19e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1aad: Unknown result type (might be due to invalid IL or missing references)
		//IL_1aaf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ac9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ace: Unknown result type (might be due to invalid IL or missing references)
		//IL_1af2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1af7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1afb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b00: Unknown result type (might be due to invalid IL or missing references)
		//IL_15d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_15fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1623: Unknown result type (might be due to invalid IL or missing references)
		//IL_1648: Unknown result type (might be due to invalid IL or missing references)
		//IL_166d: Unknown result type (might be due to invalid IL or missing references)
		//IL_169d: Unknown result type (might be due to invalid IL or missing references)
		//IL_16cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_16d4: Expected Obj, but got Unknown
		//IL_16d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_16e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_16e8: Expected Obj, but got Unknown
		//IL_1b3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b41: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b72: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ba8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bad: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bb1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1caa: Unknown result type (might be due to invalid IL or missing references)
		//IL_1caf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cc9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cce: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cf2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cf7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d06: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d0b: Unknown result type (might be due to invalid IL or missing references)
		//IL_12fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1303: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a45: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a64: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a69: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a92: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a96: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c06: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c0b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c37: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c72: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c77: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c86: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1305: Unknown result type (might be due to invalid IL or missing references)
		//IL_130c: Expected Obj, but got Unknown
		//IL_132a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1efe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f03: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dd7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ddc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1df6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dfb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e24: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e33: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e38: Unknown result type (might be due to invalid IL or missing references)
		//IL_1145: Unknown result type (might be due to invalid IL or missing references)
		//IL_114a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1721: Unknown result type (might be due to invalid IL or missing references)
		//IL_1728: Expected Obj, but got Unknown
		//IL_175d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1762: Unknown result type (might be due to invalid IL or missing references)
		//IL_176b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1770: Unknown result type (might be due to invalid IL or missing references)
		//IL_177b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1780: Unknown result type (might be due to invalid IL or missing references)
		//IL_1785: Unknown result type (might be due to invalid IL or missing references)
		//IL_17aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_17d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1801: Unknown result type (might be due to invalid IL or missing references)
		//IL_1808: Expected Obj, but got Unknown
		//IL_181f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f30: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f44: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e69: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ed5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eda: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ee9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eee: Unknown result type (might be due to invalid IL or missing references)
		//IL_1400: Unknown result type (might be due to invalid IL or missing references)
		//IL_142e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1435: Expected Obj, but got Unknown
		//IL_143c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1443: Expected Obj, but got Unknown
		//IL_1461: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f93: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d57: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d76: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1da4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1db3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1db8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fc9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fce: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fe2: Unknown result type (might be due to invalid IL or missing references)
		//IL_20fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_2102: Unknown result type (might be due to invalid IL or missing references)
		//IL_2116: Unknown result type (might be due to invalid IL or missing references)
		//IL_2020: Unknown result type (might be due to invalid IL or missing references)
		//IL_2025: Unknown result type (might be due to invalid IL or missing references)
		//IL_2039: Unknown result type (might be due to invalid IL or missing references)
		//IL_25e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_260e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2615: Expected Obj, but got Unknown
		//IL_207e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2083: Unknown result type (might be due to invalid IL or missing references)
		//IL_2097: Unknown result type (might be due to invalid IL or missing references)
		//IL_22af: Unknown result type (might be due to invalid IL or missing references)
		//IL_22b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_22c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_232d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2332: Unknown result type (might be due to invalid IL or missing references)
		//IL_2346: Unknown result type (might be due to invalid IL or missing references)
		//IL_21af: Unknown result type (might be due to invalid IL or missing references)
		//IL_21b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_21c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_2495: Unknown result type (might be due to invalid IL or missing references)
		//IL_249a: Unknown result type (might be due to invalid IL or missing references)
		//IL_24ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_2520: Unknown result type (might be due to invalid IL or missing references)
		//IL_2525: Unknown result type (might be due to invalid IL or missing references)
		//IL_2539: Unknown result type (might be due to invalid IL or missing references)
		//IL_23e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_23e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_23fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_25a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_25a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_25ba: Unknown result type (might be due to invalid IL or missing references)
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
						DeclaracoesGeral.Reguas RH = default;
						if (XDataGeral.LeXDataReguaH(ref RH))
						{
							double num = RH.LarguraBase - 14.0;
							double distEntreVeias = cfgDI.distEntreVeias;
							int num2 = Information.UBound(mCabos);
							int num7 = default;
							double num21 = default;
							BlockTableRecordEnumerator enumerator = default;
							BlockTableRecordEnumerator enumerator2 = default;
							Point2d val27 = default;
							Point2d val28 = default;
							Point2d val29 = default;
							Point2d ptInsTerm = default;
							double num35 = default;
							for (int i = 1; i <= num2; i++)
							{
								if (lCabosInseridos.Contains(mCabos[i].Tag_Cabo) || mCabos[i].Linha == 0)
								{
									continue;
								}
								string tag_Cabo = mCabos[i].Tag_Cabo;
								double num3 = 0.0;
								double num4 = 1000.0;
								DeclaracoesInterligacao.veiasCompl[] array = new DeclaracoesInterligacao.veiasCompl[1];
								int num5 = Information.UBound(mCabos[i].mIndices);
								for (int j = 1; j <= num5; j++)
								{
									int num6 = mCabos[i].mIndices[j];
									DeclaracoesInterligacao.borneJ borneJ = mBornesJ[num6];
									string veia = mCabos[i].mVeias[j];
									string tagDest = mCabos[i].mDestinos[j].tagDest;
									string nReguaDest = mCabos[i].mDestinos[j].nReguaDest;
									string borneDest = mCabos[i].mDestinos[j].borneDest;
									string funcaoVeia = mCabos[i].mDestinos[j].FuncaoVeia;
									if (mCabos[i].Linha != 1)
									{
										if (mCabos[i].Linha == 2)
										{
											num7 = 2;
										}
									}
									else
									{
										num7 = 1;
									}
									if (Operators.CompareString(mCabos[i].Pagina, borneJ.Pagina, TextCompare: true) != 0)
									{
										int num8 = Information.UBound(array) + 1;
										array = (DeclaracoesInterligacao.veiasCompl[])Utils.CopyArray(array, new DeclaracoesInterligacao.veiasCompl[num8 + 1]);
										array[num8].Pagina = borneJ.Pagina;
										array[num8].PaginaNum = borneJ.PaginaNum;
										array[num8].Posicao = borneJ.Posicao;
										array[num8].indiceBorne = num6;
										array[num8].Veia = veia;
										array[num8].Dest.tagDest = tagDest;
										array[num8].Dest.nReguaDest = nReguaDest;
										array[num8].Dest.borneDest = borneDest;
										array[num8].Dest.FuncaoVeia = funcaoVeia;
									}
									else if (num7 != borneJ.Posicao)
									{
										int num9 = Information.UBound(array) + 1;
										array = (DeclaracoesInterligacao.veiasCompl[])Utils.CopyArray(array, new DeclaracoesInterligacao.veiasCompl[num9 + 1]);
										array[num9].Pagina = borneJ.Pagina;
										array[num9].PaginaNum = borneJ.PaginaNum;
										array[num9].Posicao = borneJ.Posicao;
										array[num9].indiceBorne = num6;
										array[num9].Veia = veia;
										array[num9].Dest.tagDest = tagDest;
										array[num9].Dest.nReguaDest = nReguaDest;
										array[num9].Dest.borneDest = borneDest;
										array[num9].Dest.FuncaoVeia = funcaoVeia;
									}
								}
								DeclaracoesInterligacao.veiasCompl veiasCompl = default;
								if (Information.UBound(array) >= 2)
								{
									int num10 = Information.UBound(array);
									for (int k = 1; k <= num10; k++)
									{
										int num11 = Information.UBound(array) - 1;
										int num12 = k;
										for (int l = num11; l >= num12; l += -1)
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
								int num13 = Information.UBound(array);
								for (int m = 1; m <= num13; m++)
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
								int num14 = 0;
								int num15 = Information.UBound(array2);
								for (int n = 1; n <= num15; n++)
								{
									num14++;
									inicio = array2[n].inicio;
									final = array2[n].final;
									num3 = 0.0;
									num4 = 1000.0;
									double num16 = mBornesJ[array[inicio].indiceBorne].ptInsTerm.X;
									int num17 = inicio;
									int num18 = final;
									for (int num19 = num17; num19 <= num18; num19++)
									{
										DeclaracoesInterligacao.borneJ borneJ2 = mBornesJ[array[num19].indiceBorne];
										double num20 = 0.0;
										if (borneJ2.contVeiasLigadas == 1)
										{
											if (borneJ2.TipoBorne != 0)
											{
												if (borneJ2.TipoBorne == 1)
												{
													num20 = cfgDI.larguraBorne;
												}
											}
											else
											{
												num20 = cfgDI.larguraBorne / 2.0;
											}
										}
										if (num19 == inicio)
										{
											num16 += num20;
										}
										if (borneJ2.contVeiasLigadas != 0)
										{
											new Point2d(num16, mCabos[i].ptIns.Y);
										}
										else
										{
											new Point2d(num16, mCabos[i].ptIns.Y);
										}
										Point2d val5 = new Point2d(borneJ2.ptInsTerm.X + num20, borneJ2.ptInsTerm.Y);
										_ = val5.Y;
										if (val5.X > num3)
										{
											num3 = val5.X;
										}
										if (val5.X < num4)
										{
											num4 = val5.X;
										}
										num21 = val5.Y - cfgDI.distInicialBorneCabo;
									}
									while (true)
									{
										IL_0879:
										num21 -= distEntreVeias;
										if (w91TxoeIGN(num21, num3, num4, array[inicio].Pagina, revisao, Painel))
										{
											continue;
										}
										if (cfgDI.tipo != 0)
										{
											break;
										}
										int num22 = Information.UBound(mAltPag);
										for (int num23 = 1; num23 <= num22; num23++)
										{
											if ((num21 == mAltPag[num23].Y) & (Operators.CompareString(array[inicio].Pagina, mAltPag[num23].Pagina, TextCompare: true) == 0))
											{
												goto IL_0879;
											}
										}
										if (n >= Information.UBound(array2) || !vNxTbFSm0s(num21, array[inicio].Pagina, revisao, Painel))
										{
											break;
										}
									}
									Point2d val6 = new Point2d(num4, num21);
									Entity ent;
									if (inicio < final)
									{
										Hatch val7 = KE6TMvkKPi(new Point3d(val6.X, val6.Y, 0.0), array[inicio].Pagina, cfgDI.corHatch, cfgDI.raioHatch);
										try
										{
											ent = (Entity)(object)val7;
											XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, "", "");
											mAltPag = (DeclaracoesInterligacao.AltPagUsada[])Utils.CopyArray(mAltPag, new DeclaracoesInterligacao.AltPagUsada[Information.UBound(mAltPag) + 1 + 1]);
											mAltPag[Information.UBound(mAltPag)].Y = val6.Y;
											mAltPag[Information.UBound(mAltPag)].Pagina = ((Entity)val7).Layer;
										}
										finally
										{
											((IDisposable)val7)?.Dispose();
										}
									}
									string text = "";
									bool flag = false;
									if (n == Information.UBound(array2))
									{
										flag = true;
									}
									if (flag)
									{
										text = "VeiaEntraReta";
									}
									else
									{
										text = ((cfgDI.tipo == 0) ? "VeiaEntraReta" : "VeiaEntra");
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
									int num24 = Information.UBound(mInfoVeias);
									for (int num25 = 1; num25 <= num24; num25++)
									{
										if (Operators.CompareString(mInfoVeias[num25].tag_Cabo, mCabos[i].Tag_Cabo, TextCompare: true) == 0)
										{
											text3 = mCabos[i].Tag_Cabo;
											if ((cfgDI.tipo == 0) | (cfgDI.tipo == 3) | (cfgDI.tipo == 7) | (cfgDI.tipo == 8) | (cfgDI.tipo == 9) | (cfgDI.tipo == 10))
											{
												text3 = DeclaracoesGeral.Conf.PrefixoCruzInterno + mInfoVeias[num25].mBornes[0].pagina + DeclaracoesGeral.Conf.SufixoCruzInterno + " " + text3;
											}
											if (((cfgDI.tipo == 2) | (cfgDI.tipo == 4) | (cfgDI.tipo == 5) | (cfgDI.tipo == 6)) && Operators.CompareString(array[inicio].Pagina, mInfoVeias[num25].mBornes[0].pagina, TextCompare: true) != 0)
											{
												text3 = text3 + DeclaracoesGeral.Conf.PrefixoCruzInterno + mInfoVeias[num25].mBornes[0].pagina + DeclaracoesGeral.Conf.SufixoCruzInterno;
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
									XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, mCabos[i].Tag_Cabo, "", "");
									val11 = (BlockReference)ent;
									if (n >= Information.UBound(array2))
									{
										int num26 = Information.UBound(mInfoVeias);
										for (int num27 = 1; num27 <= num26; num27++)
										{
											if (Operators.CompareString(mInfoVeias[num27].tag_Cabo, mCabos[i].Tag_Cabo, TextCompare: true) == 0)
											{
												ref DeclaracoesInterligacao.borneCruzamentoCaboAranha[] mBornes = ref mInfoVeias[num27].mBornes;
												mBornes = (DeclaracoesInterligacao.borneCruzamentoCaboAranha[])Utils.CopyArray(mBornes, new DeclaracoesInterligacao.borneCruzamentoCaboAranha[num14 + 1]);
												string text4 = mBornesJ[array[inicio].indiceBorne].Tag;
												if (Operators.CompareString(mBornesJ[array[inicio].indiceBorne].NRegua, "", TextCompare: true) != 0)
												{
													text4 = mBornesJ[array[inicio].indiceBorne].NRegua;
												}
												string borne = mBornesJ[array[inicio].indiceBorne].Borne;
												mInfoVeias[num27].mBornes[num14].ID = ObjectId.Null;
												mInfoVeias[num27].mBornes[num14].rb = text4 + "-" + borne;
												mInfoVeias[num27].mBornes[num14].pagina = array[inicio].Pagina;
											}
										}
									}
									else
									{
										text = "VeiaSai";
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
										val11 = ((cfgDI.tipo == 0) ? new BlockReference(new Point3d(num, val6.Y, 0.0), val8) : new BlockReference(new Point3d(val6.X, val6.Y, 0.0), val8));
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
										XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, mCabos[i].Tag_Cabo, "", "");
										val11 = (BlockReference)ent;
										int num28 = Information.UBound(mInfoVeias);
										for (int num29 = 1; num29 <= num28; num29++)
										{
											if (Operators.CompareString(mInfoVeias[num29].tag_Cabo, mCabos[i].Tag_Cabo, TextCompare: true) == 0)
											{
												ref DeclaracoesInterligacao.borneCruzamentoCaboAranha[] mBornes2 = ref mInfoVeias[num29].mBornes;
												mBornes2 = (DeclaracoesInterligacao.borneCruzamentoCaboAranha[])Utils.CopyArray(mBornes2, new DeclaracoesInterligacao.borneCruzamentoCaboAranha[num14 + 1]);
												string text5 = mBornesJ[array[inicio].indiceBorne].Tag;
												if (Operators.CompareString(mBornesJ[array[inicio].indiceBorne].NRegua, "", TextCompare: true) != 0)
												{
													text5 = mBornesJ[array[inicio].indiceBorne].NRegua;
												}
												string borne2 = mBornesJ[array[inicio].indiceBorne].Borne;
												mInfoVeias[num29].mBornes[num14].ID = ((DBObject)val11).ObjectId;
												mInfoVeias[num29].mBornes[num14].rb = text5 + "-" + borne2;
												mInfoVeias[num29].mBornes[num14].pagina = array[inicio].Pagina;
												break;
											}
										}
										if (cfgDI.tipo == 0)
										{
											Polyline val21 = new Polyline();
											((Entity)val21).SetDatabaseDefaults();
											((Entity)val21).Layer = ((Entity)val11).Layer;
											((Entity)val21).LineWeight = (LineWeight)9;
											((Entity)val21).ColorIndex = cfgDI.corVeias;
											double x = val6.X;
											Point3d position = val11.Position;
											Point2d val22 = new Point2d(x, position.Y);
											Point2d val23 = new Point2d(num, val22.Y);
											val21.AddVertexAt(0, val22, 0.0, 0.0, 0.0);
											val21.AddVertexAt(1, val23, 0.0, 0.0, 0.0);
											val4.AppendEntity((Entity)(object)val21);
											DeclaracoesGeral.bAnularEventos = true;
											val2.AddNewlyCreatedDBObject((DBObject)(object)val21, true);
											ent = (Entity)(object)val21;
											XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, "H", "");
											val21 = (Polyline)ent;
											Hatch val24 = KE6TMvkKPi(new Point3d(val6.X, val6.Y, 0.0), ((Entity)val11).Layer, cfgDI.corHatch, cfgDI.raioHatch);
											try
											{
												ent = (Entity)(object)val24;
												XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, "", "");
											}
											finally
											{
												((IDisposable)val24)?.Dispose();
											}
										}
									}
									int num30 = inicio;
									int num31 = final;
									for (int num32 = num30; num32 <= num31; num32++)
									{
										DeclaracoesInterligacao.borneJ borneJ3 = mBornesJ[array[num32].indiceBorne];
										string veia2 = array[num32].Veia;
										string tagDest2 = array[num32].Dest.tagDest;
										string nReguaDest2 = array[num32].Dest.nReguaDest;
										string borneDest2 = array[num32].Dest.borneDest;
										string funcaoVeia2 = array[num32].Dest.FuncaoVeia;
										string tag2 = borneJ3.Tag;
										string nRegua = borneJ3.NRegua;
										string borne3 = borneJ3.Borne;
										Polyline val25 = new Polyline();
										((Entity)val25).SetDatabaseDefaults();
										((Entity)val25).Layer = borneJ3.Pagina;
										((Entity)val25).LineWeight = (LineWeight)9;
										((Entity)val25).ColorIndex = cfgDI.corVeias;
										if (borneJ3.contVeiasLigadas == 1 && borneJ3.TipoBorne != 0 && borneJ3.TipoBorne == 1)
										{
											mBornesJ[array[num32].indiceBorne].ptInsTerm = new Point2d(borneJ3.ptInsTerm.X + cfgDI.larguraBorne, borneJ3.ptInsTerm.Y);
											borneJ3 = mBornesJ[array[num32].indiceBorne];
										}
										double num33 = 0.0;
										Point2d val26 = new Point2d(num16, num21);
										if (num16 != borneJ3.ptInsTerm.X)
										{
											if (!(num16 > borneJ3.ptInsTerm.X))
											{
												if (num16 < borneJ3.ptInsTerm.X)
												{
													if (borneJ3.contVeiasLigadas != 0)
													{
														if (borneJ3.TipoBorne != 0)
														{
															if (borneJ3.TipoBorne == 1)
															{
																val27 = new Point2d(borneJ3.ptInsTerm.X - 1.0, num21);
																val28 = new Point2d(borneJ3.ptInsTerm.X, num21 + 1.0);
																val29 = new Point2d(borneJ3.ptInsTerm.X, borneJ3.ptInsTerm.Y - 2.0);
																num33 = 0.42;
																ptInsTerm = borneJ3.ptInsTerm;
															}
														}
														else
														{
															val27 = new Point2d(borneJ3.ptInsTerm.X + cfgDI.larguraBorne / 2.0 - 1.0, num21);
															val28 = new Point2d(borneJ3.ptInsTerm.X + cfgDI.larguraBorne / 2.0, num21 + 1.0);
															val29 = new Point2d(borneJ3.ptInsTerm.X + cfgDI.larguraBorne / 2.0, borneJ3.ptInsTerm.Y - 2.0);
															num33 = 0.42;
															ptInsTerm = borneJ3.ptInsTerm;
														}
													}
													else
													{
														val27 = new Point2d(borneJ3.ptInsTerm.X - 1.0, num21);
														val28 = new Point2d(borneJ3.ptInsTerm.X, num21 + 1.0);
														val29 = new Point2d(borneJ3.ptInsTerm.X, borneJ3.ptInsTerm.Y - 2.0);
														num33 = 0.42;
														ptInsTerm = borneJ3.ptInsTerm;
													}
												}
											}
											else if (borneJ3.contVeiasLigadas != 0)
											{
												if (borneJ3.TipoBorne == 0)
												{
													val27 = new Point2d(borneJ3.ptInsTerm.X + cfgDI.larguraBorne / 2.0, num21);
													val28 = new Point2d(borneJ3.ptInsTerm.X + cfgDI.larguraBorne / 2.0, num21 + 1.0);
													val29 = new Point2d(borneJ3.ptInsTerm.X + cfgDI.larguraBorne / 2.0, borneJ3.ptInsTerm.Y - 2.0);
													num33 = 0.0;
													ptInsTerm = borneJ3.ptInsTerm;
												}
											}
											else
											{
												val27 = new Point2d(borneJ3.ptInsTerm.X + 1.0, num21);
												val28 = new Point2d(borneJ3.ptInsTerm.X, num21 + 1.0);
												val29 = new Point2d(borneJ3.ptInsTerm.X, borneJ3.ptInsTerm.Y - 2.0);
												num33 = -0.42;
												ptInsTerm = borneJ3.ptInsTerm;
											}
										}
										else if (borneJ3.contVeiasLigadas != 0)
										{
											if (borneJ3.TipoBorne != 0)
											{
												if (borneJ3.TipoBorne == 1)
												{
													val27 = new Point2d(borneJ3.ptInsTerm.X, num21);
													val28 = new Point2d(borneJ3.ptInsTerm.X, num21 + 1.0);
													val29 = new Point2d(borneJ3.ptInsTerm.X, borneJ3.ptInsTerm.Y - 2.0);
													ptInsTerm = borneJ3.ptInsTerm;
													num33 = 0.0;
												}
											}
											else
											{
												val27 = new Point2d(val26.X + cfgDI.larguraBorne / 2.0 - 1.0, val26.Y);
												val28 = new Point2d(borneJ3.ptInsTerm.X + cfgDI.larguraBorne / 2.0, num21 + 1.0);
												val29 = new Point2d(borneJ3.ptInsTerm.X + cfgDI.larguraBorne / 2.0, borneJ3.ptInsTerm.Y - 2.0);
												ptInsTerm = borneJ3.ptInsTerm;
												num33 = 0.42;
											}
										}
										else
										{
											val27 = val26;
											val28 = new Point2d(borneJ3.ptInsTerm.X, num21 + 1.0);
											val29 = new Point2d(borneJ3.ptInsTerm.X, borneJ3.ptInsTerm.Y - 2.0);
											ptInsTerm = borneJ3.ptInsTerm;
											num33 = 0.0;
										}
										val25.AddVertexAt(0, val26, 0.0, 0.0, 0.0);
										val25.AddVertexAt(1, val27, 0.0, 0.0, 0.0);
										val25.AddVertexAt(2, val28, 0.0, 0.0, 0.0);
										val25.AddVertexAt(3, val29, 0.0, 0.0, 0.0);
										val25.AddVertexAt(4, ptInsTerm, 0.0, 0.0, 0.0);
										val25.SetBulgeAt(1, num33);
										val4.AppendEntity((Entity)(object)val25);
										DeclaracoesGeral.bAnularEventos = true;
										val2.AddNewlyCreatedDBObject((DBObject)(object)val25, true);
										ent = (Entity)(object)val25;
										XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, veia2, borneJ3.Handle);
										val25 = (Polyline)ent;
										TextStyleTable val30 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)0);
										ObjectId textStyleId = (((SymbolTable)val30).Has(cfgDI.textStyle) ? ((SymbolTable)val30)[cfgDI.textStyle] : ((SymbolTable)val30)["Standard"]);
										DBText val31 = new DBText();
										((Entity)val31).Layer = ((Entity)val25).Layer;
										val31.Height = cfgDI.alturaFonteVeia;
										val31.TextStyleId = textStyleId;
										val31.WidthFactor = 0.9;
										val31.Rotation = Math.PI / 2.0;
										((Entity)val31).ColorIndex = cfgDI.corTextoVeia;
										val31.Oblique = cfgDI.anguloTextoVeia;
										if (cfgDI.tipo != 0)
										{
											if (cfgDI.tipo != 3)
											{
												if (!((cfgDI.tipo == 1) | (cfgDI.tipo == 9)))
												{
													if (!((cfgDI.tipo == 2) | (cfgDI.tipo == 4) | (cfgDI.tipo == 7) | (cfgDI.tipo == 10)))
													{
														if ((cfgDI.tipo == 5) | (cfgDI.tipo == 6) | (cfgDI.tipo == 8))
														{
															Point3d alignmentPoint = new Point3d(val29.X, val29.Y - 0.5, 0.0);
															val31.HorizontalMode = (TextHorizontalMode)2;
															val31.VerticalMode = (TextVerticalMode)1;
															val31.AlignmentPoint = alignmentPoint;
															val31.TextString = veia2;
														}
													}
													else
													{
														Point3d alignmentPoint2 = new Point3d(val29.X, val29.Y - cfgDI.distEntreJumpers - 0.5, 0.0);
														val31.HorizontalMode = (TextHorizontalMode)2;
														val31.VerticalMode = (TextVerticalMode)1;
														val31.AlignmentPoint = alignmentPoint2;
														val31.TextString = "(" + veia2 + ")";
													}
												}
												else
												{
													Point3d alignmentPoint3 = new Point3d(val28.X, val28.Y + 0.5, 0.0);
													val31.HorizontalMode = (TextHorizontalMode)0;
													val31.VerticalMode = (TextVerticalMode)1;
													val31.AlignmentPoint = alignmentPoint3;
													val31.TextString = veia2;
												}
											}
											else
											{
												Point3d alignmentPoint4 = new Point3d(val29.X - 0.4, val29.Y, 0.0);
												val31.HorizontalMode = (TextHorizontalMode)2;
												val31.VerticalMode = (TextVerticalMode)0;
												val31.AlignmentPoint = alignmentPoint4;
												val31.TextString = veia2;
											}
										}
										else
										{
											Point3d alignmentPoint5 = new Point3d(val29.X - 0.4, val29.Y, 0.0);
											val31.HorizontalMode = (TextHorizontalMode)2;
											val31.VerticalMode = (TextVerticalMode)0;
											val31.AlignmentPoint = alignmentPoint5;
											val31.TextString = veia2;
										}
										val4.AppendEntity((Entity)(object)val31);
										DeclaracoesGeral.bAnularEventos = true;
										val2.AddNewlyCreatedDBObject((DBObject)(object)val31, true);
										ent = (Entity)(object)val31;
										XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, veia2, "");
										val31 = (DBText)ent;
										string text6 = "";
										DBText val32 = new DBText();
										((Entity)val32).Layer = ((Entity)val25).Layer;
										val32.Height = cfgDI.alturaFonteCruzamento;
										val32.TextStyleId = textStyleId;
										val32.WidthFactor = 0.85;
										val32.Rotation = Math.PI / 2.0;
										((Entity)val32).ColorIndex = cfgDI.corTextoDestino;
										val32.Oblique = cfgDI.anguloTextoDestino;
										if (cfgDI.tipo != 0)
										{
											if (!((cfgDI.tipo == 3) | (cfgDI.tipo == 10)))
											{
												if (cfgDI.tipo != 1)
												{
													if (cfgDI.tipo != 9)
													{
														if (!((cfgDI.tipo == 2) | (cfgDI.tipo == 8)))
														{
															if (cfgDI.tipo != 4)
															{
																if (cfgDI.tipo != 5)
																{
																	if (cfgDI.tipo != 6)
																	{
																		if (cfgDI.tipo == 7)
																		{
																			text6 = ((Operators.CompareString(nRegua, "", TextCompare: true) != 0) ? (text6 + nRegua) : (text6 + tag2));
																			text6 = text6 + "-" + borne3;
																			Point3d alignmentPoint6 = new Point3d(val29.X, val29.Y - cfgDI.distEntreJumpers - 7.0, 0.0);
																			val32.HorizontalMode = (TextHorizontalMode)2;
																			val32.VerticalMode = (TextVerticalMode)1;
																			val32.AlignmentPoint = alignmentPoint6;
																		}
																	}
																	else
																	{
																		text6 = tagDest2;
																		if (Operators.CompareString(nReguaDest2, "", TextCompare: true) != 0)
																		{
																			text6 = nReguaDest2;
																		}
																		text6 = text6 + "-" + borneDest2;
																		Point3d alignmentPoint7 = new Point3d(val29.X - 0.4, val29.Y - cfgDI.distEntreJumpers - 9.0, 0.0);
																		val32.HorizontalMode = (TextHorizontalMode)2;
																		val32.VerticalMode = (TextVerticalMode)0;
																		val32.AlignmentPoint = alignmentPoint7;
																	}
																}
																else
																{
																	text6 = ((Operators.CompareString(nReguaDest2, "", TextCompare: true) != 0) ? (text6 + nReguaDest2) : (text6 + tagDest2));
																	text6 = text6 + "-" + borneDest2;
																	text6 = text6 + " (" + borne3 + ")";
																	Point3d alignmentPoint8 = new Point3d(val29.X, val29.Y - cfgDI.distEntreJumpers - 4.0, 0.0);
																	val32.HorizontalMode = (TextHorizontalMode)2;
																	val32.VerticalMode = (TextVerticalMode)1;
																	val32.AlignmentPoint = alignmentPoint8;
																}
															}
															else
															{
																text6 = ((Operators.CompareString(nReguaDest2, "", TextCompare: true) != 0) ? (text6 + nReguaDest2) : (text6 + tagDest2));
																text6 = text6 + "-" + borneDest2;
																text6 = ((Operators.CompareString(nRegua, "", TextCompare: true) != 0) ? (text6 + "/" + nRegua) : (text6 + "/" + tag2));
																text6 = text6 + "-" + borne3;
																Point3d alignmentPoint9 = new Point3d(val29.X, val29.Y - cfgDI.distEntreJumpers - 4.0, 0.0);
																val32.HorizontalMode = (TextHorizontalMode)2;
																val32.VerticalMode = (TextVerticalMode)1;
																val32.AlignmentPoint = alignmentPoint9;
															}
														}
														else
														{
															text6 = tagDest2;
															if (Operators.CompareString(nReguaDest2, "", TextCompare: true) != 0)
															{
																text6 = nReguaDest2;
															}
															text6 = text6 + "-" + borneDest2;
															Point3d alignmentPoint10 = new Point3d(val29.X - 0.4, val29.Y - cfgDI.distEntreJumpers - 9.0, 0.0);
															val32.HorizontalMode = (TextHorizontalMode)2;
															val32.VerticalMode = (TextVerticalMode)0;
															val32.AlignmentPoint = alignmentPoint10;
														}
													}
													else
													{
														text6 = funcaoVeia2;
														double num34 = 3.0;
														Point3d alignmentPoint11 = new Point3d(val29.X, val29.Y - num34, 0.0);
														val32.HorizontalMode = (TextHorizontalMode)2;
														val32.VerticalMode = (TextVerticalMode)1;
														val32.AlignmentPoint = alignmentPoint11;
													}
												}
												else
												{
													if ((cfgDI.tipoCruzamento == 1) | (cfgDI.tipoCruzamento == 2))
													{
														text6 = borneDest2;
														text6 = ((Operators.CompareString(nReguaDest2, "", TextCompare: true) != 0) ? (text6 + "-" + nReguaDest2) : (text6 + "-" + tagDest2));
													}
													if (cfgDI.tipoCruzamento == 2)
													{
														text6 = ((Operators.CompareString(nRegua, "", TextCompare: true) != 0) ? (text6 + "/" + nRegua) : (text6 + "/" + tag2));
														text6 = text6 + "-" + borne3;
													}
													if (cfgDI.tipoCruzamento == 3)
													{
														text6 = funcaoVeia2;
													}
													switch (cfgDI.tipoCruzamento)
													{
													case 3:
														num35 = 3.0;
														break;
													case 1:
														num35 = 6.0;
														break;
													case 2:
														num35 = 3.0;
														break;
													}
													Point3d alignmentPoint12 = new Point3d(val29.X - 0.4, val29.Y - num35, 0.0);
													val32.HorizontalMode = (TextHorizontalMode)2;
													val32.VerticalMode = (TextVerticalMode)0;
													val32.AlignmentPoint = alignmentPoint12;
												}
											}
										}
										else
										{
											text6 = tagDest2;
											if (Operators.CompareString(nReguaDest2, "", TextCompare: true) != 0)
											{
												text6 = nReguaDest2;
											}
											text6 = text6 + "-" + borneDest2;
											Point3d alignmentPoint13 = new Point3d(val29.X - 0.4, val29.Y - 6.0, 0.0);
											val32.HorizontalMode = (TextHorizontalMode)1;
											val32.VerticalMode = (TextVerticalMode)0;
											val32.AlignmentPoint = alignmentPoint13;
										}
										if ((cfgDI.tipo == 0) | (cfgDI.tipo == 1) | (cfgDI.tipo == 2) | (cfgDI.tipo == 4) | (cfgDI.tipo == 5) | (cfgDI.tipo == 6) | (cfgDI.tipo == 7) | (cfgDI.tipo == 8) | (cfgDI.tipo == 9))
										{
											val32.TextString = text6;
											val4.AppendEntity((Entity)(object)val32);
											DeclaracoesGeral.bAnularEventos = true;
											val2.AddNewlyCreatedDBObject((DBObject)(object)val32, true);
											ent = (Entity)(object)val32;
											XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, veia2, "");
											val32 = (DBText)ent;
										}
										mBornesJ[array[num32].indiceBorne].contVeiasLigadas++;
									}
								}
								int num36 = Information.UBound(mInfoVeias);
								for (int num37 = 1; num37 <= num36; num37++)
								{
									if (Operators.CompareString(mInfoVeias[num37].tag_Cabo, mCabos[i].Tag_Cabo, TextCompare: true) != 0)
									{
										continue;
									}
									int num38 = Information.UBound(mInfoVeias[num37].mBornes) - 1;
									for (int num39 = 0; num39 <= num38; num39++)
									{
										ObjectId iD = mInfoVeias[num37].mBornes[num39].ID;
										string pagina3 = mInfoVeias[num37].mBornes[num39 + 1].pagina;
										BlockReference val33 = (BlockReference)val2.GetObject(iD, (OpenMode)0);
										AttributeCollection attributeCollection = val33.AttributeCollection;
										foreach (object item in attributeCollection)
										{
											ObjectId val34 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
											AttributeReference val35 = (AttributeReference)val34.GetObject((OpenMode)1);
											string text7 = mInfoVeias[num37].mBornes[num39 + 1].rb;
											if (cfgDI.tipo == 0)
											{
												text7 = text7 + DeclaracoesGeral.Conf.PrefixoCruzInterno + pagina3 + DeclaracoesGeral.Conf.SufixoCruzInterno;
											}
											if (cfgDI.tipo == 7)
											{
												text7 = text7 + " " + DeclaracoesGeral.Conf.PrefixoCruzInterno + pagina3 + DeclaracoesGeral.Conf.SufixoCruzInterno;
											}
											if (cfgDI.tipo == 8)
											{
												text7 = text7 + " " + DeclaracoesGeral.Conf.PrefixoCruzInterno + W9kTOy0nnY(pagina3) + DeclaracoesGeral.Conf.SufixoCruzInterno;
											}
											if (cfgDI.tipo == 10)
											{
												text7 = text7 + " " + DeclaracoesGeral.Conf.PrefixoCruzInterno + pagina3 + DeclaracoesGeral.Conf.SufixoCruzInterno;
											}
											string tag3 = val35.Tag;
											if (Operators.CompareString(tag3, "BORNE", TextCompare: true) == 0)
											{
												((DBText)val35).TextString = text7;
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
						else
						{
							Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 611]), MsgBoxStyle.Information);
						}
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

	public static void insereVeias2Inv(string revisao, int Painel, ref DeclaracoesInterligacao.borneJ[] mBornesJ, ref DeclaracoesInterligacao.caboAranha[] mCabos, ref DeclaracoesInterligacao.cruzamentoCaboAranha[] mInfoVeias, List<string> lCabosInseridos, ref DeclaracoesInterligacao.ConfigDInterlig cfgDI, ref DeclaracoesInterligacao.AltPagUsada[] mAltPag)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_089e: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_2542: Unknown result type (might be due to invalid IL or missing references)
		//IL_2547: Unknown result type (might be due to invalid IL or missing references)
		//IL_2569: Unknown result type (might be due to invalid IL or missing references)
		//IL_2571: Unknown result type (might be due to invalid IL or missing references)
		//IL_2578: Expected Obj, but got Unknown
		//IL_0aa2: Unknown result type (might be due to invalid IL or missing references)
		//IL_083d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0761: Unknown result type (might be due to invalid IL or missing references)
		//IL_078c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0791: Unknown result type (might be due to invalid IL or missing references)
		//IL_08dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_2643: Unknown result type (might be due to invalid IL or missing references)
		//IL_2649: Unknown result type (might be due to invalid IL or missing references)
		//IL_259c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b81: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b93: Expected Obj, but got Unknown
		//IL_0b95: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0911: Unknown result type (might be due to invalid IL or missing references)
		//IL_0918: Expected Obj, but got Unknown
		//IL_0934: Unknown result type (might be due to invalid IL or missing references)
		//IL_0939: Unknown result type (might be due to invalid IL or missing references)
		//IL_25a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_25ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_25b2: Expected Obj, but got Unknown
		//IL_0959: Unknown result type (might be due to invalid IL or missing references)
		//IL_095e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0960: Unknown result type (might be due to invalid IL or missing references)
		//IL_0967: Expected Obj, but got Unknown
		//IL_0980: Unknown result type (might be due to invalid IL or missing references)
		//IL_0996: Unknown result type (might be due to invalid IL or missing references)
		//IL_099e: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a5: Expected Obj, but got Unknown
		//IL_0c2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c34: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c37: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c46: Expected Obj, but got Unknown
		//IL_0c54: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c5b: Expected Obj, but got Unknown
		//IL_0c5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c62: Expected Obj, but got Unknown
		//IL_0c68: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d18: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d1f: Expected Obj, but got Unknown
		//IL_0ca6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1055: Unknown result type (might be due to invalid IL or missing references)
		//IL_1060: Unknown result type (might be due to invalid IL or missing references)
		//IL_1067: Expected Obj, but got Unknown
		//IL_1069: Unknown result type (might be due to invalid IL or missing references)
		//IL_106e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e96: Expected Obj, but got Unknown
		//IL_0eb2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_18fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1902: Unknown result type (might be due to invalid IL or missing references)
		//IL_1087: Unknown result type (might be due to invalid IL or missing references)
		//IL_108c: Unknown result type (might be due to invalid IL or missing references)
		//IL_108e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1095: Expected Obj, but got Unknown
		//IL_0ee6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eeb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ef4: Expected Obj, but got Unknown
		//IL_1256: Unknown result type (might be due to invalid IL or missing references)
		//IL_125d: Expected Obj, but got Unknown
		//IL_0f0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f23: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f32: Expected Obj, but got Unknown
		//IL_12bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_12c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_12d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_12da: Unknown result type (might be due to invalid IL or missing references)
		//IL_19d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_19d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ab7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1abc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ae0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ae5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ae9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1aee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f44: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f47: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f56: Expected Obj, but got Unknown
		//IL_15c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_15ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_1611: Unknown result type (might be due to invalid IL or missing references)
		//IL_1636: Unknown result type (might be due to invalid IL or missing references)
		//IL_165b: Unknown result type (might be due to invalid IL or missing references)
		//IL_168b: Unknown result type (might be due to invalid IL or missing references)
		//IL_16bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_16c2: Expected Obj, but got Unknown
		//IL_16c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_16cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_16d6: Expected Obj, but got Unknown
		//IL_1b2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b60: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b96: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ba4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c98: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cbc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ce0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ce5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cf4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cf9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f64: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f6b: Expected Obj, but got Unknown
		//IL_0f6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f72: Expected Obj, but got Unknown
		//IL_0f78: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f93: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ff5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ffc: Expected Obj, but got Unknown
		//IL_1327: Unknown result type (might be due to invalid IL or missing references)
		//IL_132c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a33: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a38: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a52: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a57: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a80: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a84: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a89: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bf4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bf9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c25: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c60: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c65: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c74: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c79: Unknown result type (might be due to invalid IL or missing references)
		//IL_132e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1335: Expected Obj, but got Unknown
		//IL_1353: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eec: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ef1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dc5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dca: Unknown result type (might be due to invalid IL or missing references)
		//IL_1de4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1de9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e12: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e21: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e26: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f19: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f32: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e57: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e88: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ec3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ec8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ed7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1edc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1413: Unknown result type (might be due to invalid IL or missing references)
		//IL_1441: Unknown result type (might be due to invalid IL or missing references)
		//IL_1448: Expected Obj, but got Unknown
		//IL_144f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1456: Expected Obj, but got Unknown
		//IL_1474: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f68: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f81: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d45: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d64: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d69: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d92: Unknown result type (might be due to invalid IL or missing references)
		//IL_1da1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1da6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1140: Unknown result type (might be due to invalid IL or missing references)
		//IL_1145: Unknown result type (might be due to invalid IL or missing references)
		//IL_170f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1716: Expected Obj, but got Unknown
		//IL_174b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1750: Unknown result type (might be due to invalid IL or missing references)
		//IL_1759: Unknown result type (might be due to invalid IL or missing references)
		//IL_175e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1769: Unknown result type (might be due to invalid IL or missing references)
		//IL_176e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1773: Unknown result type (might be due to invalid IL or missing references)
		//IL_1798: Unknown result type (might be due to invalid IL or missing references)
		//IL_17be: Unknown result type (might be due to invalid IL or missing references)
		//IL_17ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_17f6: Expected Obj, but got Unknown
		//IL_180d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fbf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fc4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fd8: Unknown result type (might be due to invalid IL or missing references)
		//IL_20fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_20ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_2113: Unknown result type (might be due to invalid IL or missing references)
		//IL_201d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2022: Unknown result type (might be due to invalid IL or missing references)
		//IL_2036: Unknown result type (might be due to invalid IL or missing references)
		//IL_247d: Unknown result type (might be due to invalid IL or missing references)
		//IL_24ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_24b2: Expected Obj, but got Unknown
		//IL_214e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2153: Unknown result type (might be due to invalid IL or missing references)
		//IL_2167: Unknown result type (might be due to invalid IL or missing references)
		//IL_207b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2080: Unknown result type (might be due to invalid IL or missing references)
		//IL_2094: Unknown result type (might be due to invalid IL or missing references)
		//IL_21cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_21d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_21e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_2332: Unknown result type (might be due to invalid IL or missing references)
		//IL_2337: Unknown result type (might be due to invalid IL or missing references)
		//IL_234b: Unknown result type (might be due to invalid IL or missing references)
		//IL_23bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_23c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_23d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_2282: Unknown result type (might be due to invalid IL or missing references)
		//IL_2287: Unknown result type (might be due to invalid IL or missing references)
		//IL_229b: Unknown result type (might be due to invalid IL or missing references)
		//IL_243e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2443: Unknown result type (might be due to invalid IL or missing references)
		//IL_2457: Unknown result type (might be due to invalid IL or missing references)
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
						DeclaracoesGeral.Reguas RH = default;
						if (XDataGeral.LeXDataReguaH(ref RH))
						{
							double num = RH.LarguraBase - 14.0;
							double distEntreVeias = cfgDI.distEntreVeias;
							int num2 = Information.UBound(mCabos);
							int num7 = default;
							double num21 = default;
							BlockTableRecordEnumerator enumerator = default;
							BlockTableRecordEnumerator enumerator2 = default;
							Point2d val27 = default;
							Point2d val28 = default;
							Point2d val29 = default;
							Point2d ptInsTerm = default;
							for (int i = 1; i <= num2; i++)
							{
								if (lCabosInseridos.Contains(mCabos[i].Tag_Cabo) || mCabos[i].Linha != 0)
								{
									continue;
								}
								string tag_Cabo = mCabos[i].Tag_Cabo;
								double num3 = 0.0;
								double num4 = 1000.0;
								DeclaracoesInterligacao.veiasCompl[] array = new DeclaracoesInterligacao.veiasCompl[1];
								int num5 = Information.UBound(mCabos[i].mIndices);
								for (int j = 1; j <= num5; j++)
								{
									int num6 = mCabos[i].mIndices[j];
									DeclaracoesInterligacao.borneJ borneJ = mBornesJ[num6];
									string veia = mCabos[i].mVeias[j];
									string tagDest = mCabos[i].mDestinos[j].tagDest;
									string nReguaDest = mCabos[i].mDestinos[j].nReguaDest;
									string borneDest = mCabos[i].mDestinos[j].borneDest;
									string funcaoVeia = mCabos[i].mDestinos[j].FuncaoVeia;
									if (mCabos[i].Linha == 0)
									{
										num7 = 2;
									}
									if (Operators.CompareString(mCabos[i].Pagina, borneJ.Pagina, TextCompare: true) != 0)
									{
										int num8 = Information.UBound(array) + 1;
										array = (DeclaracoesInterligacao.veiasCompl[])Utils.CopyArray(array, new DeclaracoesInterligacao.veiasCompl[num8 + 1]);
										array[num8].Pagina = borneJ.Pagina;
										array[num8].PaginaNum = borneJ.PaginaNum;
										array[num8].Posicao = borneJ.Posicao;
										array[num8].indiceBorne = num6;
										array[num8].Veia = veia;
										array[num8].Dest.tagDest = tagDest;
										array[num8].Dest.nReguaDest = nReguaDest;
										array[num8].Dest.borneDest = borneDest;
										array[num8].Dest.FuncaoVeia = funcaoVeia;
									}
									else if (num7 != borneJ.Posicao)
									{
										int num9 = Information.UBound(array) + 1;
										array = (DeclaracoesInterligacao.veiasCompl[])Utils.CopyArray(array, new DeclaracoesInterligacao.veiasCompl[num9 + 1]);
										array[num9].Pagina = borneJ.Pagina;
										array[num9].PaginaNum = borneJ.PaginaNum;
										array[num9].Posicao = borneJ.Posicao;
										array[num9].indiceBorne = num6;
										array[num9].Veia = veia;
										array[num9].Dest.tagDest = tagDest;
										array[num9].Dest.nReguaDest = nReguaDest;
										array[num9].Dest.borneDest = borneDest;
										array[num9].Dest.FuncaoVeia = funcaoVeia;
									}
								}
								DeclaracoesInterligacao.veiasCompl veiasCompl = default;
								if (Information.UBound(array) >= 2)
								{
									int num10 = Information.UBound(array);
									for (int k = 1; k <= num10; k++)
									{
										int num11 = Information.UBound(array) - 1;
										int num12 = k;
										for (int l = num11; l >= num12; l += -1)
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
								int num13 = Information.UBound(array);
								for (int m = 1; m <= num13; m++)
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
								int num14 = 0;
								int num15 = Information.UBound(array2);
								for (int n = 1; n <= num15; n++)
								{
									num14++;
									inicio = array2[n].inicio;
									final = array2[n].final;
									num3 = 0.0;
									num4 = 1000.0;
									double num16 = mBornesJ[array[inicio].indiceBorne].ptInsTerm.X;
									int num17 = inicio;
									int num18 = final;
									for (int num19 = num17; num19 <= num18; num19++)
									{
										DeclaracoesInterligacao.borneJ borneJ2 = mBornesJ[array[num19].indiceBorne];
										double num20 = 0.0;
										if (borneJ2.contVeiasLigadas2 == 1)
										{
											if (borneJ2.TipoBorne != 0)
											{
												if (borneJ2.TipoBorne == 1)
												{
													num20 = cfgDI.larguraBorne;
												}
											}
											else
											{
												num20 = cfgDI.larguraBorne / 2.0;
											}
										}
										if (num19 == inicio)
										{
											num16 += num20;
										}
										if (borneJ2.contVeiasLigadas2 != 0)
										{
											new Point2d(num16, mCabos[i].ptIns.Y);
										}
										else
										{
											new Point2d(num16, mCabos[i].ptIns.Y);
										}
										Point2d val5 = new Point2d(borneJ2.ptInsTerm.X + num20, borneJ2.ptInsTerm.Y + 10.0);
										_ = val5.Y;
										if (val5.X > num3)
										{
											num3 = val5.X;
										}
										if (val5.X < num4)
										{
											num4 = val5.X;
										}
										num21 = val5.Y + cfgDI.distInicialBorneCabo;
									}
									while (true)
									{
										IL_0864:
										num21 += distEntreVeias;
										if (w91TxoeIGN(num21, num3, num4, array[inicio].Pagina, revisao, Painel))
										{
											continue;
										}
										if (cfgDI.tipo != 0)
										{
											break;
										}
										int num22 = Information.UBound(mAltPag);
										for (int num23 = 1; num23 <= num22; num23++)
										{
											if ((num21 == mAltPag[num23].Y) & (Operators.CompareString(array[inicio].Pagina, mAltPag[num23].Pagina, TextCompare: true) == 0))
											{
												goto IL_0864;
											}
										}
										if (n >= Information.UBound(array2) || !vNxTbFSm0s(num21, array[inicio].Pagina, revisao, Painel))
										{
											break;
										}
									}
									Point2d val6 = new Point2d(num4, num21);
									Entity ent;
									if (inicio < final)
									{
										Hatch val7 = KE6TMvkKPi(new Point3d(val6.X, val6.Y, 0.0), array[inicio].Pagina, cfgDI.corHatch, cfgDI.raioHatch);
										try
										{
											ent = (Entity)(object)val7;
											XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, "", "");
											mAltPag = (DeclaracoesInterligacao.AltPagUsada[])Utils.CopyArray(mAltPag, new DeclaracoesInterligacao.AltPagUsada[Information.UBound(mAltPag) + 1 + 1]);
											mAltPag[Information.UBound(mAltPag)].Y = val6.Y;
											mAltPag[Information.UBound(mAltPag)].Pagina = ((Entity)val7).Layer;
										}
										finally
										{
											((IDisposable)val7)?.Dispose();
										}
									}
									string text = "";
									bool flag = false;
									if (n == Information.UBound(array2))
									{
										flag = true;
									}
									if (flag)
									{
										text = "VeiaEntraRetaI";
									}
									else
									{
										text = ((cfgDI.tipo == 0) ? "VeiaEntraRetaI" : "VeiaEntraI");
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
									int num24 = Information.UBound(mInfoVeias);
									for (int num25 = 1; num25 <= num24; num25++)
									{
										if (Operators.CompareString(mInfoVeias[num25].tag_Cabo, mCabos[i].Tag_Cabo, TextCompare: true) == 0)
										{
											text3 = mCabos[i].Tag_Cabo;
											if ((cfgDI.tipo == 0) | (cfgDI.tipo == 7) | (cfgDI.tipo == 8) | (cfgDI.tipo == 9) | (cfgDI.tipo == 10))
											{
												text3 = DeclaracoesGeral.Conf.PrefixoCruzInterno + mInfoVeias[num25].mBornes[0].pagina + DeclaracoesGeral.Conf.SufixoCruzInterno + " " + text3;
											}
											if (((cfgDI.tipo == 2) | (cfgDI.tipo == 4) | (cfgDI.tipo == 5) | (cfgDI.tipo == 6)) && Operators.CompareString(array[inicio].Pagina, mInfoVeias[num25].mBornes[0].pagina, TextCompare: true) != 0)
											{
												text3 = text3 + DeclaracoesGeral.Conf.PrefixoCruzInterno + mInfoVeias[num25].mBornes[0].pagina + DeclaracoesGeral.Conf.SufixoCruzInterno;
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
									XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, mCabos[i].Tag_Cabo, "", "");
									val11 = (BlockReference)ent;
									if (n >= Information.UBound(array2))
									{
										int num26 = Information.UBound(mInfoVeias);
										for (int num27 = 1; num27 <= num26; num27++)
										{
											if (Operators.CompareString(mInfoVeias[num27].tag_Cabo, mCabos[i].Tag_Cabo, TextCompare: true) == 0)
											{
												ref DeclaracoesInterligacao.borneCruzamentoCaboAranha[] mBornes = ref mInfoVeias[num27].mBornes;
												mBornes = (DeclaracoesInterligacao.borneCruzamentoCaboAranha[])Utils.CopyArray(mBornes, new DeclaracoesInterligacao.borneCruzamentoCaboAranha[num14 + 1]);
												string text4 = mBornesJ[array[inicio].indiceBorne].Tag;
												if (Operators.CompareString(mBornesJ[array[inicio].indiceBorne].NRegua, "", TextCompare: true) != 0)
												{
													text4 = mBornesJ[array[inicio].indiceBorne].NRegua;
												}
												string borne = mBornesJ[array[inicio].indiceBorne].Borne;
												mInfoVeias[num27].mBornes[num14].ID = ObjectId.Null;
												mInfoVeias[num27].mBornes[num14].rb = text4 + "-" + borne;
												mInfoVeias[num27].mBornes[num14].pagina = array[inicio].Pagina;
											}
										}
									}
									else
									{
										text = ((cfgDI.tipo == 0) ? "VeiaSai" : "VeiaSaiI");
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
										val11 = ((cfgDI.tipo == 0) ? new BlockReference(new Point3d(num, val6.Y, 0.0), val8) : new BlockReference(new Point3d(val6.X, val6.Y, 0.0), val8));
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
										XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, mCabos[i].Tag_Cabo, "", "");
										val11 = (BlockReference)ent;
										int num28 = Information.UBound(mInfoVeias);
										for (int num29 = 1; num29 <= num28; num29++)
										{
											if (Operators.CompareString(mInfoVeias[num29].tag_Cabo, mCabos[i].Tag_Cabo, TextCompare: true) == 0)
											{
												ref DeclaracoesInterligacao.borneCruzamentoCaboAranha[] mBornes2 = ref mInfoVeias[num29].mBornes;
												mBornes2 = (DeclaracoesInterligacao.borneCruzamentoCaboAranha[])Utils.CopyArray(mBornes2, new DeclaracoesInterligacao.borneCruzamentoCaboAranha[num14 + 1]);
												string text5 = mBornesJ[array[inicio].indiceBorne].Tag;
												if (Operators.CompareString(mBornesJ[array[inicio].indiceBorne].NRegua, "", TextCompare: true) != 0)
												{
													text5 = mBornesJ[array[inicio].indiceBorne].NRegua;
												}
												string borne2 = mBornesJ[array[inicio].indiceBorne].Borne;
												mInfoVeias[num29].mBornes[num14].ID = ((DBObject)val11).ObjectId;
												mInfoVeias[num29].mBornes[num14].rb = text5 + "-" + borne2;
												mInfoVeias[num29].mBornes[num14].pagina = array[inicio].Pagina;
												break;
											}
										}
										if (cfgDI.tipo == 0)
										{
											Polyline val21 = new Polyline();
											((Entity)val21).SetDatabaseDefaults();
											((Entity)val21).Layer = ((Entity)val11).Layer;
											((Entity)val21).LineWeight = (LineWeight)9;
											((Entity)val21).ColorIndex = cfgDI.corVeias;
											double x = val6.X;
											Point3d position = val11.Position;
											Point2d val22 = new Point2d(x, position.Y);
											Point2d val23 = new Point2d(num, val22.Y);
											val21.AddVertexAt(0, val22, 0.0, 0.0, 0.0);
											val21.AddVertexAt(1, val23, 0.0, 0.0, 0.0);
											val4.AppendEntity((Entity)(object)val21);
											DeclaracoesGeral.bAnularEventos = true;
											val2.AddNewlyCreatedDBObject((DBObject)(object)val21, true);
											ent = (Entity)(object)val21;
											XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, "H", "");
											val21 = (Polyline)ent;
											Hatch val24 = KE6TMvkKPi(new Point3d(val6.X, val6.Y, 0.0), ((Entity)val11).Layer, cfgDI.corHatch, cfgDI.raioHatch);
											try
											{
												ent = (Entity)(object)val24;
												XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, "", "");
											}
											finally
											{
												((IDisposable)val24)?.Dispose();
											}
										}
									}
									int num30 = inicio;
									int num31 = final;
									for (int num32 = num30; num32 <= num31; num32++)
									{
										DeclaracoesInterligacao.borneJ borneJ3 = mBornesJ[array[num32].indiceBorne];
										string veia2 = array[num32].Veia;
										string tagDest2 = array[num32].Dest.tagDest;
										string nReguaDest2 = array[num32].Dest.nReguaDest;
										string borneDest2 = array[num32].Dest.borneDest;
										string funcaoVeia2 = array[num32].Dest.FuncaoVeia;
										string tag2 = borneJ3.Tag;
										string nRegua = borneJ3.NRegua;
										string borne3 = borneJ3.Borne;
										Polyline val25 = new Polyline();
										((Entity)val25).SetDatabaseDefaults();
										((Entity)val25).Layer = borneJ3.Pagina;
										((Entity)val25).LineWeight = (LineWeight)9;
										((Entity)val25).ColorIndex = cfgDI.corVeias;
										if (borneJ3.contVeiasLigadas2 == 1 && borneJ3.TipoBorne != 0 && borneJ3.TipoBorne == 1)
										{
											mBornesJ[array[num32].indiceBorne].ptInsTerm = new Point2d(borneJ3.ptInsTerm.X + cfgDI.larguraBorne, borneJ3.ptInsTerm.Y);
											borneJ3 = mBornesJ[array[num32].indiceBorne];
										}
										borneJ3.ptInsTerm = new Point2d(borneJ3.ptInsTerm.X, borneJ3.ptInsTerm.Y + 10.0);
										double num33 = 0.0;
										Point2d val26 = new Point2d(num16, num21);
										if (num16 != borneJ3.ptInsTerm.X)
										{
											if (!(num16 > borneJ3.ptInsTerm.X))
											{
												if (num16 < borneJ3.ptInsTerm.X)
												{
													if (borneJ3.contVeiasLigadas2 != 0)
													{
														if (borneJ3.TipoBorne != 0)
														{
															if (borneJ3.TipoBorne == 1)
															{
																val27 = new Point2d(borneJ3.ptInsTerm.X - 1.0, num21);
																val28 = new Point2d(borneJ3.ptInsTerm.X, num21 - 1.0);
																val29 = new Point2d(borneJ3.ptInsTerm.X, borneJ3.ptInsTerm.Y + 2.0);
																num33 = -0.42;
																ptInsTerm = borneJ3.ptInsTerm;
															}
														}
														else
														{
															val27 = new Point2d(borneJ3.ptInsTerm.X + cfgDI.larguraBorne / 2.0 - 1.0, num21);
															val28 = new Point2d(borneJ3.ptInsTerm.X + cfgDI.larguraBorne / 2.0, num21 - 1.0);
															val29 = new Point2d(borneJ3.ptInsTerm.X + cfgDI.larguraBorne / 2.0, borneJ3.ptInsTerm.Y + 2.0);
															num33 = -0.42;
															ptInsTerm = borneJ3.ptInsTerm;
														}
													}
													else
													{
														val27 = new Point2d(borneJ3.ptInsTerm.X - 1.0, num21);
														val28 = new Point2d(borneJ3.ptInsTerm.X, num21 - 1.0);
														val29 = new Point2d(borneJ3.ptInsTerm.X, borneJ3.ptInsTerm.Y + 2.0);
														num33 = -0.42;
														ptInsTerm = borneJ3.ptInsTerm;
													}
												}
											}
											else if (borneJ3.contVeiasLigadas2 != 0)
											{
												if (borneJ3.TipoBorne == 0)
												{
													val27 = new Point2d(borneJ3.ptInsTerm.X + cfgDI.larguraBorne / 2.0, num21);
													val28 = new Point2d(borneJ3.ptInsTerm.X + cfgDI.larguraBorne / 2.0, num21 - 1.0);
													val29 = new Point2d(borneJ3.ptInsTerm.X + cfgDI.larguraBorne / 2.0, borneJ3.ptInsTerm.Y + 2.0);
													num33 = 0.0;
													ptInsTerm = borneJ3.ptInsTerm;
												}
											}
											else
											{
												val27 = new Point2d(borneJ3.ptInsTerm.X + 1.0, num21);
												val28 = new Point2d(borneJ3.ptInsTerm.X, num21 - 1.0);
												val29 = new Point2d(borneJ3.ptInsTerm.X, borneJ3.ptInsTerm.Y + 2.0);
												num33 = 0.42;
												ptInsTerm = borneJ3.ptInsTerm;
											}
										}
										else if (borneJ3.contVeiasLigadas2 != 0)
										{
											if (borneJ3.TipoBorne != 0)
											{
												if (borneJ3.TipoBorne == 1)
												{
													val27 = new Point2d(borneJ3.ptInsTerm.X, num21);
													val28 = new Point2d(borneJ3.ptInsTerm.X, num21 - 1.0);
													val29 = new Point2d(borneJ3.ptInsTerm.X, borneJ3.ptInsTerm.Y + 2.0);
													ptInsTerm = borneJ3.ptInsTerm;
													num33 = 0.0;
												}
											}
											else
											{
												val27 = new Point2d(val26.X + cfgDI.larguraBorne / 2.0 - 1.0, val26.Y);
												val28 = new Point2d(borneJ3.ptInsTerm.X + cfgDI.larguraBorne / 2.0, num21 - 1.0);
												val29 = new Point2d(borneJ3.ptInsTerm.X + cfgDI.larguraBorne / 2.0, borneJ3.ptInsTerm.Y + 2.0);
												ptInsTerm = borneJ3.ptInsTerm;
												num33 = -0.42;
											}
										}
										else
										{
											val27 = val26;
											val28 = new Point2d(borneJ3.ptInsTerm.X, num21 - 1.0);
											val29 = new Point2d(borneJ3.ptInsTerm.X, borneJ3.ptInsTerm.Y + 2.0);
											ptInsTerm = borneJ3.ptInsTerm;
											num33 = 0.0;
										}
										val25.AddVertexAt(0, val26, 0.0, 0.0, 0.0);
										val25.AddVertexAt(1, val27, 0.0, 0.0, 0.0);
										val25.AddVertexAt(2, val28, 0.0, 0.0, 0.0);
										val25.AddVertexAt(3, val29, 0.0, 0.0, 0.0);
										val25.AddVertexAt(4, ptInsTerm, 0.0, 0.0, 0.0);
										val25.SetBulgeAt(1, num33);
										val4.AppendEntity((Entity)(object)val25);
										DeclaracoesGeral.bAnularEventos = true;
										val2.AddNewlyCreatedDBObject((DBObject)(object)val25, true);
										ent = (Entity)(object)val25;
										XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, veia2, borneJ3.Handle);
										val25 = (Polyline)ent;
										TextStyleTable val30 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)0);
										ObjectId textStyleId = (((SymbolTable)val30).Has(cfgDI.textStyle) ? ((SymbolTable)val30)[cfgDI.textStyle] : ((SymbolTable)val30)["Standard"]);
										DBText val31 = new DBText();
										((Entity)val31).Layer = ((Entity)val25).Layer;
										val31.Height = cfgDI.alturaFonteVeia;
										val31.TextStyleId = textStyleId;
										val31.WidthFactor = 0.9;
										val31.Rotation = Math.PI / 2.0;
										((Entity)val31).ColorIndex = cfgDI.corTextoVeia;
										val31.Oblique = cfgDI.anguloTextoVeia;
										if (cfgDI.tipo != 0)
										{
											if (cfgDI.tipo != 9)
											{
												if (!((cfgDI.tipo == 2) | (cfgDI.tipo == 4) | (cfgDI.tipo == 7) | (cfgDI.tipo == 10)))
												{
													if (cfgDI.tipo != 5)
													{
														if ((cfgDI.tipo == 6) | (cfgDI.tipo == 8))
														{
															Point3d alignmentPoint = new Point3d(val29.X, val29.Y + 0.5, 0.0);
															val31.HorizontalMode = (TextHorizontalMode)0;
															val31.VerticalMode = (TextVerticalMode)1;
															val31.AlignmentPoint = alignmentPoint;
															val31.TextString = veia2;
														}
													}
													else
													{
														Point3d alignmentPoint = new Point3d(val29.X, val29.Y + 0.5, 0.0);
														val31.HorizontalMode = (TextHorizontalMode)0;
														val31.VerticalMode = (TextVerticalMode)1;
														val31.AlignmentPoint = alignmentPoint;
														val31.TextString = "(" + veia2 + ")";
													}
												}
												else
												{
													Point3d alignmentPoint = new Point3d(val29.X, val29.Y + cfgDI.distEntreJumpers + 0.5, 0.0);
													val31.HorizontalMode = (TextHorizontalMode)0;
													val31.VerticalMode = (TextVerticalMode)1;
													val31.AlignmentPoint = alignmentPoint;
													val31.TextString = "(" + veia2 + ")";
												}
											}
											else
											{
												Point3d alignmentPoint = new Point3d(val28.X, val28.Y - 0.5, 0.0);
												val31.HorizontalMode = (TextHorizontalMode)2;
												val31.VerticalMode = (TextVerticalMode)1;
												val31.AlignmentPoint = alignmentPoint;
												val31.TextString = veia2;
											}
										}
										else
										{
											Point3d alignmentPoint = new Point3d(val29.X - 0.4, val29.Y, 0.0);
											val31.HorizontalMode = (TextHorizontalMode)0;
											val31.VerticalMode = (TextVerticalMode)1;
											val31.AlignmentPoint = alignmentPoint;
											val31.TextString = veia2;
										}
										val4.AppendEntity((Entity)(object)val31);
										DeclaracoesGeral.bAnularEventos = true;
										val2.AddNewlyCreatedDBObject((DBObject)(object)val31, true);
										ent = (Entity)(object)val31;
										XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, veia2, "");
										val31 = (DBText)ent;
										string text6 = "";
										DBText val32 = new DBText();
										((Entity)val32).Layer = ((Entity)val25).Layer;
										val32.Height = cfgDI.alturaFonteCruzamento;
										val32.TextStyleId = textStyleId;
										val32.WidthFactor = 0.85;
										val32.Rotation = Math.PI / 2.0;
										((Entity)val32).ColorIndex = cfgDI.corTextoDestino;
										val32.Oblique = cfgDI.anguloTextoDestino;
										if (cfgDI.tipo != 0)
										{
											if (cfgDI.tipo != 10)
											{
												if (cfgDI.tipo != 9)
												{
													if (!((cfgDI.tipo == 2) | (cfgDI.tipo == 8)))
													{
														if (cfgDI.tipo != 4)
														{
															if (cfgDI.tipo != 5)
															{
																if (cfgDI.tipo != 6)
																{
																	if (cfgDI.tipo == 7)
																	{
																		text6 = ((Operators.CompareString(nRegua, "", TextCompare: true) != 0) ? (text6 + nRegua) : (text6 + tag2));
																		text6 = text6 + "-" + borne3;
																		Point3d alignmentPoint2 = new Point3d(val29.X, val29.Y + cfgDI.distEntreJumpers + 7.0, 0.0);
																		val32.HorizontalMode = (TextHorizontalMode)0;
																		val32.VerticalMode = (TextVerticalMode)1;
																		val32.AlignmentPoint = alignmentPoint2;
																	}
																}
																else
																{
																	text6 = tagDest2;
																	if (Operators.CompareString(nReguaDest2, "", TextCompare: true) != 0)
																	{
																		text6 = nReguaDest2;
																	}
																	text6 = text6 + "-" + borneDest2;
																	Point3d alignmentPoint3 = new Point3d(val29.X - 1.15, val29.Y + cfgDI.distEntreJumpers + 9.0, 0.0);
																	val32.HorizontalMode = (TextHorizontalMode)0;
																	val32.VerticalMode = (TextVerticalMode)2;
																	val32.AlignmentPoint = alignmentPoint3;
																}
															}
															else
															{
																text6 = "(" + borne3 + ") ";
																text6 = ((Operators.CompareString(nReguaDest2, "", TextCompare: true) != 0) ? (text6 + nReguaDest2) : (text6 + tagDest2));
																text6 = text6 + "-" + borneDest2;
																Point3d alignmentPoint4 = new Point3d(val29.X, val29.Y + cfgDI.distEntreJumpers + 4.0, 0.0);
																val32.HorizontalMode = (TextHorizontalMode)0;
																val32.VerticalMode = (TextVerticalMode)1;
																val32.AlignmentPoint = alignmentPoint4;
															}
														}
														else
														{
															text6 = ((Operators.CompareString(nRegua, "", TextCompare: true) != 0) ? (text6 + nRegua) : (text6 + tag2));
															text6 = text6 + "-" + borne3;
															text6 = ((Operators.CompareString(nReguaDest2, "", TextCompare: true) != 0) ? (text6 + "/" + nReguaDest2) : (text6 + "/" + tagDest2));
															text6 = text6 + "-" + borneDest2;
															Point3d alignmentPoint5 = new Point3d(val29.X, val29.Y + cfgDI.distEntreJumpers + 4.0, 0.0);
															val32.HorizontalMode = (TextHorizontalMode)0;
															val32.VerticalMode = (TextVerticalMode)1;
															val32.AlignmentPoint = alignmentPoint5;
														}
													}
													else
													{
														text6 = tagDest2;
														if (Operators.CompareString(nReguaDest2, "", TextCompare: true) != 0)
														{
															text6 = nReguaDest2;
														}
														text6 = text6 + "-" + borneDest2;
														Point3d alignmentPoint6 = new Point3d(val29.X - 1.15, val29.Y + cfgDI.distEntreJumpers + 9.0, 0.0);
														val32.HorizontalMode = (TextHorizontalMode)0;
														val32.VerticalMode = (TextVerticalMode)2;
														val32.AlignmentPoint = alignmentPoint6;
													}
												}
												else
												{
													text6 = funcaoVeia2;
													double num34 = 3.0;
													Point3d alignmentPoint7 = new Point3d(val29.X, val29.Y + num34, 0.0);
													val32.HorizontalMode = (TextHorizontalMode)0;
													val32.VerticalMode = (TextVerticalMode)1;
													val32.AlignmentPoint = alignmentPoint7;
												}
											}
										}
										else
										{
											text6 = tagDest2;
											if (Operators.CompareString(nReguaDest2, "", TextCompare: true) != 0)
											{
												text6 = nReguaDest2;
											}
											text6 = text6 + "-" + borneDest2;
											Point3d alignmentPoint8 = new Point3d(val29.X - 0.4, val29.Y + 7.0, 0.0);
											val32.HorizontalMode = (TextHorizontalMode)1;
											val32.VerticalMode = (TextVerticalMode)1;
											val32.AlignmentPoint = alignmentPoint8;
										}
										if ((cfgDI.tipo == 0) | (cfgDI.tipo == 2) | (cfgDI.tipo == 4) | (cfgDI.tipo == 5) | (cfgDI.tipo == 6) | (cfgDI.tipo == 7) | (cfgDI.tipo == 8) | (cfgDI.tipo == 9))
										{
											val32.TextString = text6;
											val4.AppendEntity((Entity)(object)val32);
											DeclaracoesGeral.bAnularEventos = true;
											val2.AddNewlyCreatedDBObject((DBObject)(object)val32, true);
											ent = (Entity)(object)val32;
											XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, veia2, "");
											val32 = (DBText)ent;
										}
										mBornesJ[array[num32].indiceBorne].contVeiasLigadas2++;
									}
								}
								int num35 = Information.UBound(mInfoVeias);
								for (int num36 = 1; num36 <= num35; num36++)
								{
									if (Operators.CompareString(mInfoVeias[num36].tag_Cabo, mCabos[i].Tag_Cabo, TextCompare: true) != 0)
									{
										continue;
									}
									int num37 = Information.UBound(mInfoVeias[num36].mBornes) - 1;
									for (int num38 = 0; num38 <= num37; num38++)
									{
										ObjectId iD = mInfoVeias[num36].mBornes[num38].ID;
										string pagina3 = mInfoVeias[num36].mBornes[num38 + 1].pagina;
										BlockReference val33 = (BlockReference)val2.GetObject(iD, (OpenMode)0);
										AttributeCollection attributeCollection = val33.AttributeCollection;
										foreach (object item in attributeCollection)
										{
											ObjectId val34 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
											AttributeReference val35 = (AttributeReference)val34.GetObject((OpenMode)1);
											string text7 = mInfoVeias[num36].mBornes[num38 + 1].rb;
											if (cfgDI.tipo == 0)
											{
												text7 = text7 + DeclaracoesGeral.Conf.PrefixoCruzInterno + pagina3 + DeclaracoesGeral.Conf.SufixoCruzInterno;
											}
											if (cfgDI.tipo == 7)
											{
												text7 = text7 + " " + DeclaracoesGeral.Conf.PrefixoCruzInterno + pagina3 + DeclaracoesGeral.Conf.SufixoCruzInterno;
											}
											if (cfgDI.tipo == 8)
											{
												text7 = text7 + " " + DeclaracoesGeral.Conf.PrefixoCruzInterno + W9kTOy0nnY(pagina3) + DeclaracoesGeral.Conf.SufixoCruzInterno;
											}
											if (cfgDI.tipo == 10)
											{
												text7 = text7 + " " + DeclaracoesGeral.Conf.PrefixoCruzInterno + pagina3 + DeclaracoesGeral.Conf.SufixoCruzInterno;
											}
											string tag3 = val35.Tag;
											if (Operators.CompareString(tag3, "BORNE", TextCompare: true) == 0)
											{
												((DBText)val35).TextString = text7;
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
						else
						{
							Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 611]), MsgBoxStyle.Information);
						}
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
						bool bRebatido = false;
						if (XDataDInterlig.LerXDataVeia(ref ent, ref revisao2, ref painel, ref tag_cabo, ref veia, ref handle, ref bRebatido) && ((Operators.CompareString(revisao, revisao2, TextCompare: true) == 0) & (Painel == painel)))
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

	public static void ApagaVeiasCabo(string revisao, int Painel, string tagCabo)
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
						bool bRebatido = false;
						if (XDataDInterlig.LerXDataVeia(ref ent, ref revisao2, ref painel, ref tag_cabo, ref veia, ref handle, ref bRebatido) && ((Operators.CompareString(revisao, revisao2, TextCompare: true) == 0) & (Painel == painel) & (Operators.CompareString(tag_cabo, tagCabo, TextCompare: true) == 0)))
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
						bool bRebatido = false;
						if (XDataDInterlig.LerXDataVeia(ref ent, ref revisao2, ref painel, ref tag_cabo, ref veia, ref handle, ref bRebatido) && ((Operators.CompareString(revisao, revisao2, TextCompare: true) == 0) & (Painel == painel) & (Operators.CompareString(tag_cabo, Tag, TextCompare: true) == 0)))
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

	private static Hatch KE6TMvkKPi(Point3d P_0, string P_1, int P_2, double P_3)
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
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected Obj, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected Obj, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
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
			val3.Radius = P_3;
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
			((Entity)val5).ColorIndex = P_2;
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
							if (!val4.Name.ToUpper().Contains("CABO"))
							{
								continue;
							}
							string revisao2 = "";
							int painel = 0;
							DeclaracoesInterligacao.caboAranha cabo = default;
							Entity ent = (Entity)(object)val4;
							bool flag = XDataDInterlig.LerXDataCabo(ref ent, ref revisao2, ref painel, ref cabo);
							val4 = (BlockReference)ent;
							if (flag && Operators.CompareString(revisao, revisao2, TextCompare: true) == 0)
							{
								int num = Information.UBound(mCabosSync) + 1;
								mCabosSync = (DeclaracoesInterligacao.caboSync[])Utils.CopyArray(mCabosSync, new DeclaracoesInterligacao.caboSync[num + 1]);
								mCabosSync[num].Revisao = revisao;
								mCabosSync[num].Tag_Cabo = cabo.Tag_Cabo;
								mCabosSync[num].Painel = painel;
								mCabosSync[num].Caderno = DeclaracoesGeral.Conf.Local;
								if (!((DeclaracoesGeral.Conf.incluirColuna == 3) | (DeclaracoesGeral.Conf.incluirColuna == 4) | (DeclaracoesGeral.Conf.incluirColuna == 5)))
								{
									mCabosSync[num].Folha = ((Entity)val4).Layer.ToString();
								}
								else
								{
									mCabosSync[num].Folha = Pagina.BuscaAlternativo(((Entity)val4).Layer.ToString(), bretornaVazio: false);
								}
								mCabosSync[num].Coluna = cabo.Coluna;
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
							bool flag = XDataDInterlig.LerXDataCabo(ref ent, ref revisao2, ref painel, ref cabo);
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
						if (XDataDInterlig.LerXDataBorne(ref blockRef, ref bn))
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

	public static void EspelhaJumper(int lado)
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
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Expected Obj, but got Unknown
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected Obj, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Expected Obj, but got Unknown
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
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
					array.SetValue((object)new TypedValue(1001, (object)"DINTERLIG"), 1);
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
							bool flag = XDataDInterlig.LerXDataJumper(ref ent, ref revisao, ref painel, ref bnO, ref bnD);
							val8 = (Polyline)ent;
							if (!flag)
							{
								continue;
							}
							double num = 0.0;
							if (lado != 1)
							{
								if (lado == 2)
								{
									num = 5.0;
								}
							}
							else
							{
								num = -5.0;
							}
							Point2d point2dAt = val8.GetPoint2dAt(0);
							double x = point2dAt.X;
							point2dAt = val8.GetPoint2dAt(0);
							Point3d val9 = new Point3d(x, point2dAt.Y + num, 0.0);
							point2dAt = val8.GetPoint2dAt(0);
							double num2 = point2dAt.X + 10.0;
							point2dAt = val8.GetPoint2dAt(0);
							Point3d val10 = new Point3d(num2, point2dAt.Y + num, 0.0);
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

	public static void RebaterCabos(string revisao, int Painel, ref DeclaracoesInterligacao.borneJ[] mBornesJ, ref DeclaracoesInterligacao.caboAranha[] mCabos, ref DeclaracoesInterligacao.cruzamentoCaboAranha[] mInfoVeias, List<string> lCabosInseridos, ref DeclaracoesInterligacao.ConfigDInterlig cfgDI, ref DeclaracoesInterligacao.AltPagUsada[] mAltPag)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_040a: Unknown result type (might be due to invalid IL or missing references)
		//IL_040f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0437: Unknown result type (might be due to invalid IL or missing references)
		//IL_043c: Unknown result type (might be due to invalid IL or missing references)
		//IL_043e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0445: Expected Obj, but got Unknown
		//IL_047b: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fe: Expected Obj, but got Unknown
		//IL_0964: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b9: Expected Obj, but got Unknown
		//IL_061b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0620: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b06: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b08: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b22: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b27: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b50: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b54: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b59: Unknown result type (might be due to invalid IL or missing references)
		//IL_0820: Unknown result type (might be due to invalid IL or missing references)
		//IL_0845: Unknown result type (might be due to invalid IL or missing references)
		//IL_086a: Unknown result type (might be due to invalid IL or missing references)
		//IL_088f: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0914: Unknown result type (might be due to invalid IL or missing references)
		//IL_091b: Expected Obj, but got Unknown
		//IL_091d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0928: Unknown result type (might be due to invalid IL or missing references)
		//IL_092f: Expected Obj, but got Unknown
		//IL_0b95: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bcb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c01: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c06: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c0f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ceb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d05: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d33: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d42: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d47: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0abd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aeb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d78: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0da9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dfd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ff0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ff5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c66: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c85: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cb3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ec9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ece: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ee8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f11: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f16: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f25: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ffc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1003: Expected Obj, but got Unknown
		//IL_1021: Unknown result type (might be due to invalid IL or missing references)
		//IL_1085: Unknown result type (might be due to invalid IL or missing references)
		//IL_108a: Unknown result type (might be due to invalid IL or missing references)
		//IL_109e: Unknown result type (might be due to invalid IL or missing references)
		//IL_10b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e7: Expected Obj, but got Unknown
		//IL_06dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e4: Expected Obj, but got Unknown
		//IL_0702: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f60: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f91: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fcc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fdb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fe0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0799: Unknown result type (might be due to invalid IL or missing references)
		//IL_079e: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fb: Expected Obj, but got Unknown
		//IL_0e49: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e68: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e91: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e96: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ea5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eaa: Unknown result type (might be due to invalid IL or missing references)
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
						DeclaracoesGeral.Reguas RH = default;
						if (XDataGeral.LeXDataReguaH(ref RH))
						{
							double distEntreVeias = cfgDI.distEntreVeias;
							int num = Information.UBound(mCabos);
							double num7 = default;
							Point2d val12 = default;
							Point2d val13 = default;
							Point2d val14 = default;
							Point2d ptInsTerm = default;
							for (int i = 1; i <= num; i++)
							{
								string tag_Cabo = mCabos[i].Tag_Cabo;
								double num2 = 0.0;
								double num3 = 1000.0;
								object[,] array = new object[5, 1];
								int num4 = Information.UBound(mCabos[i].mIndices);
								for (int j = 1; j <= num4; j++)
								{
									int num5 = mCabos[i].mIndices[j];
									DeclaracoesInterligacao.borneJ borneJ = mBornesJ[num5];
									string text = mCabos[i].mVeias[j];
									string tagDest = mCabos[i].mDestinos[j].tagDest;
									string nReguaDest = mCabos[i].mDestinos[j].nReguaDest;
									string borneDest = mCabos[i].mDestinos[j].borneDest;
									double num6 = 0.0;
									if (borneJ.contVeiasLigadas == 1)
									{
										if (borneJ.TipoBorne != 0)
										{
											if (borneJ.TipoBorne == 1)
											{
												num6 = cfgDI.larguraBorne;
											}
										}
										else
										{
											num6 = cfgDI.larguraBorne / 2.0;
										}
									}
									new Point2d(mCabos[i].ptIns.X, mCabos[i].ptIns.Y + 10.0);
									Point2d val5 = new Point2d(borneJ.ptInsTerm.X + num6, borneJ.ptInsTerm.Y + 10.0);
									if (Operators.CompareString(mCabos[i].Pagina, borneJ.Pagina, TextCompare: true) == 0 && ((mCabos[i].Linha == 3) & (borneJ.Posicao == 2)))
									{
										if (val5.X > num2)
										{
											num2 = val5.X;
										}
										if (val5.X < num3)
										{
											num3 = val5.X;
										}
										num7 = val5.Y + cfgDI.distInicialBorneCabo;
										_ = val5.Y;
										int num8 = Information.UBound(array, 2) + 1;
										array = (object[,])Utils.CopyArray(array, new object[5, num8 + 1]);
										array[0, num8] = num5;
										array[1, num8] = text;
										array[2, num8] = tagDest;
										array[3, num8] = nReguaDest;
										array[4, num8] = borneDest;
									}
								}
								if (mCabos[i].ptIns.X > num2)
								{
									num2 = mCabos[i].ptIns.X;
								}
								if (mCabos[i].ptIns.X < num3)
								{
									num3 = mCabos[i].ptIns.X;
								}
								if (Information.UBound(array, 2) <= 0)
								{
									continue;
								}
								do
								{
									num7 += distEntreVeias;
								}
								while (w91TxoeIGN(num7, num2, num3, mCabos[i].Pagina, revisao, Painel));
								Point2d val6 = new Point2d(mCabos[i].ptIns.X, num7);
								Point2d val7 = new Point2d(mCabos[i].ptIns.X, mCabos[i].ptIns.Y);
								Polyline val8 = new Polyline();
								((Entity)val8).SetDatabaseDefaults();
								((Entity)val8).ColorIndex = cfgDI.corLinhaVCabo;
								((Entity)val8).Layer = mCabos[i].Pagina;
								((Entity)val8).LineWeight = (LineWeight)9;
								val8.AddVertexAt(0, val6, 0.0, 0.0, 0.0);
								val8.AddVertexAt(1, val7, 0.0, 0.0, 0.0);
								val4.AppendEntity((Entity)(object)val8);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
								Entity ent = (Entity)(object)val8;
								XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, "", "");
								val8 = (Polyline)ent;
								if (Information.UBound(array, 2) > 1)
								{
									Hatch val9 = KE6TMvkKPi(new Point3d(val6.X, val6.Y, 0.0), mCabos[i].Pagina, cfgDI.corHatch, cfgDI.raioHatch);
									try
									{
										ent = (Entity)(object)val9;
										XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, "", "");
										mAltPag = (DeclaracoesInterligacao.AltPagUsada[])Utils.CopyArray(mAltPag, new DeclaracoesInterligacao.AltPagUsada[Information.UBound(mAltPag) + 1 + 1]);
										mAltPag[Information.UBound(mAltPag)].Y = val6.Y;
										mAltPag[Information.UBound(mAltPag)].Pagina = ((Entity)val9).Layer;
									}
									finally
									{
										((IDisposable)val9)?.Dispose();
									}
								}
								int num9 = Information.UBound(array, 2);
								for (int k = 1; k <= num9; k++)
								{
									int num10 = Conversions.ToInteger(array[0, k]);
									string text2 = Conversions.ToString(array[1, k]);
									string text3 = Conversions.ToString(array[2, k]);
									string text4 = Conversions.ToString(array[3, k]);
									string text5 = Conversions.ToString(array[4, k]);
									DeclaracoesInterligacao.borneJ borneJ2 = mBornesJ[num10];
									borneJ2.ptInsTerm = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y + 10.0);
									Polyline val10 = new Polyline();
									((Entity)val10).SetDatabaseDefaults();
									((Entity)val10).Layer = mCabos[i].Pagina;
									((Entity)val10).LineWeight = (LineWeight)9;
									((Entity)val10).ColorIndex = cfgDI.corVeias;
									if (borneJ2.contVeiasLigadas == 1 && borneJ2.TipoBorne != 0 && borneJ2.TipoBorne == 1)
									{
										mBornesJ[num10].ptInsTerm = new Point2d(borneJ2.ptInsTerm.X + cfgDI.larguraBorne, borneJ2.ptInsTerm.Y);
										borneJ2 = mBornesJ[num10];
									}
									double num11 = 0.0;
									Point2d val11 = new Point2d(mCabos[i].ptIns.X, num7);
									if (mCabos[i].ptIns.X != borneJ2.ptInsTerm.X)
									{
										if (!(mCabos[i].ptIns.X > borneJ2.ptInsTerm.X))
										{
											if (mCabos[i].ptIns.X < borneJ2.ptInsTerm.X)
											{
												if (borneJ2.contVeiasLigadas != 0)
												{
													if (borneJ2.TipoBorne != 0)
													{
														if (borneJ2.TipoBorne == 1)
														{
															val12 = new Point2d(borneJ2.ptInsTerm.X - 1.0, num7);
															val13 = new Point2d(borneJ2.ptInsTerm.X, num7 - 1.0);
															val14 = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y + 2.0);
															num11 = -0.42;
															ptInsTerm = borneJ2.ptInsTerm;
														}
													}
													else
													{
														val12 = new Point2d(borneJ2.ptInsTerm.X + cfgDI.larguraBorne / 2.0 - 1.0, num7);
														val13 = new Point2d(borneJ2.ptInsTerm.X + cfgDI.larguraBorne / 2.0, num7 - 1.0);
														val14 = new Point2d(borneJ2.ptInsTerm.X + cfgDI.larguraBorne / 2.0, borneJ2.ptInsTerm.Y + 2.0);
														num11 = -0.42;
														ptInsTerm = borneJ2.ptInsTerm;
													}
												}
												else
												{
													val12 = new Point2d(borneJ2.ptInsTerm.X - 1.0, num7);
													val13 = new Point2d(borneJ2.ptInsTerm.X, num7 - 1.0);
													val14 = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y + 2.0);
													num11 = -0.42;
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
													val12 = new Point2d(borneJ2.ptInsTerm.X + 1.0, num7);
													val13 = new Point2d(borneJ2.ptInsTerm.X, num7 - 1.0);
													val14 = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y + 2.0);
													num11 = 0.42;
													ptInsTerm = borneJ2.ptInsTerm;
												}
											}
											else
											{
												val12 = new Point2d(borneJ2.ptInsTerm.X + cfgDI.larguraBorne / 2.0 + 1.0, num7);
												val13 = new Point2d(borneJ2.ptInsTerm.X + cfgDI.larguraBorne / 2.0, num7 - 1.0);
												val14 = new Point2d(borneJ2.ptInsTerm.X + cfgDI.larguraBorne / 2.0, borneJ2.ptInsTerm.Y + 2.0);
												num11 = 0.42;
												ptInsTerm = borneJ2.ptInsTerm;
											}
										}
										else
										{
											val12 = new Point2d(borneJ2.ptInsTerm.X + 1.0, num7);
											val13 = new Point2d(borneJ2.ptInsTerm.X, num7 - 1.0);
											val14 = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y + 2.0);
											num11 = 0.42;
											ptInsTerm = borneJ2.ptInsTerm;
										}
									}
									else if (borneJ2.contVeiasLigadas != 0)
									{
										if (borneJ2.TipoBorne != 0)
										{
											if (borneJ2.TipoBorne == 1)
											{
												val12 = val11;
												val13 = new Point2d(borneJ2.ptInsTerm.X, num7 - 1.0);
												val14 = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y + 2.0);
												ptInsTerm = borneJ2.ptInsTerm;
												num11 = 0.0;
											}
										}
										else
										{
											val12 = new Point2d(val11.X + cfgDI.larguraBorne / 2.0 - 1.0, val11.Y);
											val13 = new Point2d(borneJ2.ptInsTerm.X + cfgDI.larguraBorne / 2.0, num7 - 1.0);
											val14 = new Point2d(borneJ2.ptInsTerm.X + cfgDI.larguraBorne / 2.0, borneJ2.ptInsTerm.Y + 2.0);
											ptInsTerm = borneJ2.ptInsTerm;
											num11 = -0.42;
										}
									}
									else
									{
										val12 = val11;
										val13 = new Point2d(borneJ2.ptInsTerm.X, num7 - 1.0);
										val14 = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y + 2.0);
										ptInsTerm = borneJ2.ptInsTerm;
										num11 = 0.0;
									}
									val10.AddVertexAt(0, val11, 0.0, 0.0, 0.0);
									val10.AddVertexAt(1, val12, 0.0, 0.0, 0.0);
									val10.AddVertexAt(2, val13, 0.0, 0.0, 0.0);
									val10.AddVertexAt(3, val14, 0.0, 0.0, 0.0);
									val10.AddVertexAt(4, ptInsTerm, 0.0, 0.0, 0.0);
									val10.SetBulgeAt(1, num11);
									val4.AppendEntity((Entity)(object)val10);
									DeclaracoesGeral.bAnularEventos = true;
									val2.AddNewlyCreatedDBObject((DBObject)(object)val10, true);
									ent = (Entity)(object)val10;
									XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, text2, borneJ2.Handle, bRebatido: true);
									val10 = (Polyline)ent;
									TextStyleTable val15 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)0);
									ObjectId textStyleId = (((SymbolTable)val15).Has(cfgDI.textStyle) ? ((SymbolTable)val15)[cfgDI.textStyle] : ((SymbolTable)val15)["Standard"]);
									if (mCabos[i].lVeiasLivres.Count + mCabos[i].lVeiasUsadas.Count > 1)
									{
										DBText val16 = new DBText();
										((Entity)val16).Layer = ((Entity)val10).Layer;
										val16.Height = cfgDI.alturaFonteVeia;
										val16.TextStyleId = textStyleId;
										val16.WidthFactor = 0.9;
										val16.Rotation = Math.PI / 2.0;
										((Entity)val16).ColorIndex = cfgDI.corTextoVeia;
										val16.Oblique = cfgDI.anguloTextoVeia;
										Point3d alignmentPoint = new Point3d(val14.X - 0.4, val14.Y, 0.0);
										val16.HorizontalMode = (TextHorizontalMode)2;
										val16.VerticalMode = (TextVerticalMode)0;
										val16.AlignmentPoint = alignmentPoint;
										val16.TextString = text2;
										val4.AppendEntity((Entity)(object)val16);
										DeclaracoesGeral.bAnularEventos = true;
										val2.AddNewlyCreatedDBObject((DBObject)(object)val16, true);
										ent = (Entity)(object)val16;
										XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, text2, "");
										val16 = (DBText)ent;
									}
									string text6 = "";
									DBText val17 = new DBText();
									((Entity)val17).Layer = ((Entity)val10).Layer;
									val17.Height = cfgDI.alturaFonteCruzamento;
									val17.TextStyleId = textStyleId;
									val17.WidthFactor = 0.85;
									val17.Rotation = Math.PI / 2.0;
									((Entity)val17).ColorIndex = cfgDI.corTextoDestino;
									val17.Oblique = cfgDI.anguloTextoDestino;
									text6 = text3;
									if (Operators.CompareString(text4, "", TextCompare: true) != 0)
									{
										text6 = text4;
									}
									text6 = text6 + "-" + text5;
									Point3d alignmentPoint2 = new Point3d(val14.X - 0.4, val14.Y + 6.0, 0.0);
									val17.HorizontalMode = (TextHorizontalMode)1;
									val17.VerticalMode = (TextVerticalMode)0;
									val17.AlignmentPoint = alignmentPoint2;
									val17.TextString = text6;
									val4.AppendEntity((Entity)(object)val17);
									DeclaracoesGeral.bAnularEventos = true;
									val2.AddNewlyCreatedDBObject((DBObject)(object)val17, true);
									ent = (Entity)(object)val17;
									XDataDInterlig.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, text2, "");
									val17 = (DBText)ent;
									mBornesJ[num10].contVeiasLigadas++;
								}
							}
							DeclaracoesGeral.bAnularEventos = true;
							val2.Commit();
							DeclaracoesGeral.bAnularEventos = false;
						}
						else
						{
							Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 611]), MsgBoxStyle.Information);
						}
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

	private static string W9kTOy0nnY(string P_0)
	{
		string text = "";
		if (!((DeclaracoesGeral.Conf.incluirColuna == 3) | (DeclaracoesGeral.Conf.incluirColuna == 4) | (DeclaracoesGeral.Conf.incluirColuna == 5)))
		{
			return P_0;
		}
		return Pagina.BuscaAlternativo(P_0, bretornaVazio: false);
	}
}

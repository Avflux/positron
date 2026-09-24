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

public class clsDIEnergisaMT
{
	private struct Yb9Oqjp5vBcxg0FjiLZH
	{
		public string jllp56tgGxM;

		public int OIhp5tjdiel;
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
					string text2 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Interligação\\EnergisaMT\\" + nomebloco;
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
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Expected Obj, but got Unknown
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
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
					string text2 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Interligação\\EnergisaMT\\" + nomebloco;
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

	public static void InserirReguaDInterlig(ref DeclaracoesInterligacao.borneAranha bn, Point3d ptIns)
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
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected Obj, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected Obj, but got Unknown
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Expected Obj, but got Unknown
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected Obj, but got Unknown
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Expected Obj, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Expected Obj, but got Unknown
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected Obj, but got Unknown
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
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
					string text = "Regua";
					string text2 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Interligação\\EnergisaMT\\Regua.dwg";
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
							if (!(val10 is AttributeDefinition))
							{
								continue;
							}
							AttributeDefinition val11 = (AttributeDefinition)val10;
							AttributeReference val12 = new AttributeReference();
							val12.SetAttributeFromBlock(val11, val8.BlockTransform);
							string tag = val11.Tag;
							if (Operators.CompareString(tag, "REGUA", TextCompare: true) != 0)
							{
								((Entity)val12).Visible = false;
							}
							else
							{
								((DBText)val12).TextString = bn.Tag;
								if (Operators.CompareString(bn.NRegua, "", TextCompare: true) != 0)
								{
									((DBText)val12).TextString = bn.NRegua;
								}
							}
							((DBText)val12).AdjustAlignment(database);
							val8.AttributeCollection.AppendAttribute(val12);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)val12, true);
							((Entity)val12).Draw();
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
					Entity ent = (Entity)(object)val8;
					XDataDIEnergisa.GravarXDataNomeRegua(ref ent, bn);
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

	public static void buscaXColuna1(ref double X1)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected Obj, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected Obj, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected Obj, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
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
					if (Operators.CompareString(current.ObjectClass.DxfName.ToUpper(), "INSERT", TextCompare: true) == 0)
					{
						BlockReference val4 = (BlockReference)val.GetObject(current, (OpenMode)0);
						if (Operators.CompareString(val4.Name, "Coluna1", TextCompare: true) == 0)
						{
							Point3d position = val4.Position;
							X1 = position.X;
							flag = true;
						}
						if (flag & flag2)
						{
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

	public static void insereColunasSePrecisar(ref List<string> lPaginasColunas, Point3d ptCol1)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		if (!lPaginasColunas.Contains(DeclaracoesGeral.ativo.Pagina))
		{
			InserirColunaAranha("Coluna1.dwg", ptCol1);
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
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected Obj, but got Unknown
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected Obj, but got Unknown
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
						if (!((Operators.CompareString(blockRef.Name, "BorneSimples", TextCompare: true) == 0) | (Operators.CompareString(blockRef.Name, "BorneDuplo", TextCompare: true) == 0)))
						{
							if (Operators.CompareString(blockRef.Name, "Regua", TextCompare: true) == 0)
							{
								DeclaracoesInterligacao.borneAranha bn = default;
								Entity ent = (Entity)(object)blockRef;
								bool flag = XDataDIEnergisa.LerXDataNomeRegua(ref ent, ref bn);
								blockRef = (BlockReference)ent;
								if (flag && ((Operators.CompareString(bn.Revisao, revisao, TextCompare: true) == 0) & (bn.Painel == Painel) & (Operators.CompareString(bn.Tag, Tag, TextCompare: true) == 0) & (Operators.CompareString(bn.NRegua, NRegua, TextCompare: true) == 0)))
								{
									((DBObject)blockRef).UpgradeOpen();
									((DBObject)blockRef).Erase();
								}
							}
						}
						else
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
						if (posicao == 1)
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
		//IL_035e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0363: Unknown result type (might be due to invalid IL or missing references)
		//IL_036e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		//IL_038f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0394: Unknown result type (might be due to invalid IL or missing references)
		//IL_0453: Unknown result type (might be due to invalid IL or missing references)
		//IL_0455: Unknown result type (might be due to invalid IL or missing references)
		//IL_0457: Unknown result type (might be due to invalid IL or missing references)
		//IL_0459: Unknown result type (might be due to invalid IL or missing references)
		//IL_045b: Unknown result type (might be due to invalid IL or missing references)
		//IL_045d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0315: Unknown result type (might be due to invalid IL or missing references)
		//IL_031a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0346: Unknown result type (might be due to invalid IL or missing references)
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		//IL_041b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0426: Unknown result type (might be due to invalid IL or missing references)
		//IL_042b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0447: Unknown result type (might be due to invalid IL or missing references)
		//IL_044c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Expected Obj, but got Unknown
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_047a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0584: Unknown result type (might be due to invalid IL or missing references)
		//IL_058b: Expected Obj, but got Unknown
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
								if (tipoBorne == 1 && posicao == 1)
								{
									position = val7.Position;
									double x = position.X;
									position = val7.Position;
									val5 = new Point3d(x, position.Y - 7.5, 0.0);
								}
							}
							else if (posicao == 1)
							{
								position = val7.Position;
								double x2 = position.X;
								position = val7.Position;
								val5 = new Point3d(x2, position.Y - 2.5, 0.0);
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
									double x3 = position.X;
									position = val9.Position;
									val8 = new Point3d(x3, position.Y - 7.5, 0.0);
								}
							}
							else if ((posicao2 == 1) | (posicao2 == 3))
							{
								position = val9.Position;
								double x4 = position.X;
								position = val9.Position;
								val8 = new Point3d(x4, position.Y - 2.5, 0.0);
							}
						}
						Point3d val10 = default;
						if (val5.Y < val8.Y)
						{
							val10 = val5;
							val5 = val8;
							val8 = val10;
						}
						double num = -1.5;
						int num2 = 1;
						Polyline val15;
						while (true)
						{
							Point2d val11 = new Point2d(val5.X, val5.Y);
							Point2d val12 = new Point2d(val5.X + num * (double)num2, val5.Y - 1.5);
							Point2d val13 = new Point2d(val8.X + num * (double)num2, val8.Y + 1.5);
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
							if (!UwtpBjheyp(val12.X, val12.Y, val13.Y, pagina, revisao, painel))
							{
								break;
							}
							num2++;
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

	private static bool UwtpBjheyp(double P_0, double P_1, double P_2, string P_3, string P_4, int P_5)
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
		//IL_0658: Unknown result type (might be due to invalid IL or missing references)
		//IL_065d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0668: Unknown result type (might be due to invalid IL or missing references)
		//IL_066d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0689: Unknown result type (might be due to invalid IL or missing references)
		//IL_068e: Unknown result type (might be due to invalid IL or missing references)
		//IL_075a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0765: Unknown result type (might be due to invalid IL or missing references)
		//IL_076c: Expected Obj, but got Unknown
		//IL_076e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0773: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Expected Obj, but got Unknown
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0608: Unknown result type (might be due to invalid IL or missing references)
		//IL_060d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0618: Unknown result type (might be due to invalid IL or missing references)
		//IL_061d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0639: Unknown result type (might be due to invalid IL or missing references)
		//IL_063e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0712: Unknown result type (might be due to invalid IL or missing references)
		//IL_0717: Unknown result type (might be due to invalid IL or missing references)
		//IL_0722: Unknown result type (might be due to invalid IL or missing references)
		//IL_0727: Unknown result type (might be due to invalid IL or missing references)
		//IL_0743: Unknown result type (might be due to invalid IL or missing references)
		//IL_0748: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0306: Expected Obj, but got Unknown
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_0338: Expected Obj, but got Unknown
		//IL_06c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f8: Unknown result type (might be due to invalid IL or missing references)
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
		//IL_0448: Unknown result type (might be due to invalid IL or missing references)
		//IL_044f: Expected Obj, but got Unknown
		//IL_03bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_077e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0789: Unknown result type (might be due to invalid IL or missing references)
		//IL_0790: Expected Obj, but got Unknown
		//IL_0792: Unknown result type (might be due to invalid IL or missing references)
		//IL_0797: Unknown result type (might be due to invalid IL or missing references)
		//IL_047b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0482: Expected Obj, but got Unknown
		//IL_049e: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b7: Expected Obj, but got Unknown
		//IL_04c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04da: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e9: Expected Obj, but got Unknown
		//IL_04f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0501: Unknown result type (might be due to invalid IL or missing references)
		//IL_0509: Unknown result type (might be due to invalid IL or missing references)
		//IL_0510: Expected Obj, but got Unknown
		//IL_051e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0525: Expected Obj, but got Unknown
		//IL_0525: Unknown result type (might be due to invalid IL or missing references)
		//IL_052c: Expected Obj, but got Unknown
		//IL_0532: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bf: Expected Obj, but got Unknown
		//IL_0570: Unknown result type (might be due to invalid IL or missing references)
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
								if (tipoBorne == 1 && posicao == 1)
								{
									position = val7.Position;
									double x = position.X;
									position = val7.Position;
									val5 = new Point3d(x, position.Y - 7.5, 0.0);
									text = "JumperSaiEsquerda";
								}
							}
							else if (posicao == 1)
							{
								position = val7.Position;
								double x2 = position.X;
								position = val7.Position;
								val5 = new Point3d(x2, position.Y - 2.5, 0.0);
								text = "JumperSaiEsquerda";
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
								if (tipoBorne2 == 1 && posicao2 == 1)
								{
									position = val9.Position;
									double x3 = position.X;
									position = val9.Position;
									val8 = new Point3d(x3, position.Y - 7.5, 0.0);
									text2 = "JumperEntraEsquerda";
								}
							}
							else if (posicao2 == 1)
							{
								position = val9.Position;
								double x4 = position.X;
								position = val9.Position;
								val8 = new Point3d(x4, position.Y - 2.5, 0.0);
								text2 = "JumperEntraEsquerda";
							}
						}
						ObjectId val10 = ObjectId.Null;
						string text3 = "";
						text3 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Interligação\\EnergisaMT\\" + text + ".dwg";
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
						text3 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Interligação\\EnergisaMT\\" + text2 + ".dwg";
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
							string funcao = mReguas[j].Bornes[k].cabos[l].Funcao;
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
							mCabos[num5].Funcao = funcao;
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
									goto IL_04f4;
								}
								break;
								IL_04f4:
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
		//IL_032a: Unknown result type (might be due to invalid IL or missing references)
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected Obj, but got Unknown
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected Obj, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Expected Obj, but got Unknown
		//IL_0426: Unknown result type (might be due to invalid IL or missing references)
		//IL_0431: Unknown result type (might be due to invalid IL or missing references)
		//IL_0438: Expected Obj, but got Unknown
		//IL_043a: Unknown result type (might be due to invalid IL or missing references)
		//IL_043f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected Obj, but got Unknown
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_031f: Expected Obj, but got Unknown
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Expected Obj, but got Unknown
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Expected Obj, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
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
					buscaXColuna1(ref X);
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
						if (mCabos[i].Coluna == 1 && Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0)
						{
							val5 = new Point3d(X - 58.0, mCabos[i].Y, 0.0);
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
						text2 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Interligação\\EnergisaMT\\" + text + ".dwg";
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
												if (Operators.CompareString(left, "FORM", TextCompare: true) != 0)
												{
													if (Operators.CompareString(left, "DESCRICAO", TextCompare: true) == 0)
													{
														((DBText)val13).TextString = mCabos[i].Funcao;
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
		Yb9Oqjp5vBcxg0FjiLZH[] array = new Yb9Oqjp5vBcxg0FjiLZH[1];
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
									if ((Operators.CompareString(array[n].jllp56tgGxM, tag_Cabo, TextCompare: true) == 0) & (array[n].OIhp5tjdiel == veia))
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
									array = (Yb9Oqjp5vBcxg0FjiLZH[])Utils.CopyArray(array, new Yb9Oqjp5vBcxg0FjiLZH[Information.UBound(array) + 1 + 1]);
									array[Information.UBound(array)].jllp56tgGxM = tag_Cabo;
									array[Information.UBound(array)].OIhp5tjdiel = veia;
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
		//IL_0428: Unknown result type (might be due to invalid IL or missing references)
		//IL_042d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0455: Unknown result type (might be due to invalid IL or missing references)
		//IL_045a: Unknown result type (might be due to invalid IL or missing references)
		//IL_045c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0463: Expected Obj, but got Unknown
		//IL_0493: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04de: Unknown result type (might be due to invalid IL or missing references)
		//IL_050e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0515: Expected Obj, but got Unknown
		//IL_052c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b49: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dfc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e03: Expected Obj, but got Unknown
		//IL_0e05: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b83: Expected Obj, but got Unknown
		//IL_0b9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba4: Unknown result type (might be due to invalid IL or missing references)
		//IL_10ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_10cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_10f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_10f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e32: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e39: Expected Obj, but got Unknown
		//IL_0e69: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eb4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ee4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eeb: Expected Obj, but got Unknown
		//IL_0eed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ef8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eff: Expected Obj, but got Unknown
		//IL_0bc4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bcb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd2: Expected Obj, but got Unknown
		//IL_0beb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c01: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c09: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c10: Expected Obj, but got Unknown
		//IL_1106: Unknown result type (might be due to invalid IL or missing references)
		//IL_110b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f17: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0628: Unknown result type (might be due to invalid IL or missing references)
		//IL_062f: Expected Obj, but got Unknown
		//IL_065c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0663: Expected Obj, but got Unknown
		//IL_0f1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f25: Expected Obj, but got Unknown
		//IL_06b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c1d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c22: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c25: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c34: Expected Obj, but got Unknown
		//IL_1213: Unknown result type (might be due to invalid IL or missing references)
		//IL_1218: Unknown result type (might be due to invalid IL or missing references)
		//IL_127e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1280: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c42: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c49: Expected Obj, but got Unknown
		//IL_0c49: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c50: Expected Obj, but got Unknown
		//IL_0c56: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c71: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cd2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cd9: Expected Obj, but got Unknown
		//IL_0d7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d82: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_12bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_12e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_12e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_128b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1290: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_1434: Unknown result type (might be due to invalid IL or missing references)
		//IL_1439: Unknown result type (might be due to invalid IL or missing references)
		//IL_0925: Unknown result type (might be due to invalid IL or missing references)
		//IL_094a: Unknown result type (might be due to invalid IL or missing references)
		//IL_096f: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a43: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a69: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a82: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab8: Expected Obj, but got Unknown
		//IL_0ad2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad9: Expected Obj, but got Unknown
		//IL_0adb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aed: Expected Obj, but got Unknown
		//IL_1006: Unknown result type (might be due to invalid IL or missing references)
		//IL_1048: Unknown result type (might be due to invalid IL or missing references)
		//IL_104d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1061: Unknown result type (might be due to invalid IL or missing references)
		//IL_106c: Unknown result type (might be due to invalid IL or missing references)
		//IL_109c: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a3: Expected Obj, but got Unknown
		//IL_1332: Unknown result type (might be due to invalid IL or missing references)
		//IL_1337: Unknown result type (might be due to invalid IL or missing references)
		//IL_1365: Unknown result type (might be due to invalid IL or missing references)
		//IL_136a: Unknown result type (might be due to invalid IL or missing references)
		//IL_12f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_12fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1257: Unknown result type (might be due to invalid IL or missing references)
		//IL_1259: Unknown result type (might be due to invalid IL or missing references)
		//IL_1468: Unknown result type (might be due to invalid IL or missing references)
		//IL_146d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1491: Unknown result type (might be due to invalid IL or missing references)
		//IL_1496: Unknown result type (might be due to invalid IL or missing references)
		//IL_1444: Unknown result type (might be due to invalid IL or missing references)
		//IL_1449: Unknown result type (might be due to invalid IL or missing references)
		//IL_14b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_14b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_073d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0742: Unknown result type (might be due to invalid IL or missing references)
		//IL_1386: Unknown result type (might be due to invalid IL or missing references)
		//IL_138b: Unknown result type (might be due to invalid IL or missing references)
		//IL_13af: Unknown result type (might be due to invalid IL or missing references)
		//IL_13b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1267: Unknown result type (might be due to invalid IL or missing references)
		//IL_126c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1503: Unknown result type (might be due to invalid IL or missing references)
		//IL_1508: Unknown result type (might be due to invalid IL or missing references)
		//IL_1536: Unknown result type (might be due to invalid IL or missing references)
		//IL_153b: Unknown result type (might be due to invalid IL or missing references)
		//IL_13fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1402: Unknown result type (might be due to invalid IL or missing references)
		//IL_0744: Unknown result type (might be due to invalid IL or missing references)
		//IL_074b: Expected Obj, but got Unknown
		//IL_077c: Unknown result type (might be due to invalid IL or missing references)
		//IL_17ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_17cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1633: Unknown result type (might be due to invalid IL or missing references)
		//IL_1638: Unknown result type (might be due to invalid IL or missing references)
		//IL_1556: Unknown result type (might be due to invalid IL or missing references)
		//IL_155b: Unknown result type (might be due to invalid IL or missing references)
		//IL_14d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_14da: Unknown result type (might be due to invalid IL or missing references)
		//IL_157a: Unknown result type (might be due to invalid IL or missing references)
		//IL_157f: Unknown result type (might be due to invalid IL or missing references)
		//IL_15a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_15a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1410: Unknown result type (might be due to invalid IL or missing references)
		//IL_1415: Unknown result type (might be due to invalid IL or missing references)
		//IL_17f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_17fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_079f: Unknown result type (might be due to invalid IL or missing references)
		//IL_07aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07de: Expected Obj, but got Unknown
		//IL_07e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ec: Expected Obj, but got Unknown
		//IL_080c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1667: Unknown result type (might be due to invalid IL or missing references)
		//IL_166c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1690: Unknown result type (might be due to invalid IL or missing references)
		//IL_1695: Unknown result type (might be due to invalid IL or missing references)
		//IL_1643: Unknown result type (might be due to invalid IL or missing references)
		//IL_1648: Unknown result type (might be due to invalid IL or missing references)
		//IL_16bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_16c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_089f: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0900: Expected Obj, but got Unknown
		//IL_170c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1711: Unknown result type (might be due to invalid IL or missing references)
		//IL_173f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1744: Unknown result type (might be due to invalid IL or missing references)
		//IL_15fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1601: Unknown result type (might be due to invalid IL or missing references)
		//IL_175f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1764: Unknown result type (might be due to invalid IL or missing references)
		//IL_16de: Unknown result type (might be due to invalid IL or missing references)
		//IL_16e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1783: Unknown result type (might be due to invalid IL or missing references)
		//IL_1788: Unknown result type (might be due to invalid IL or missing references)
		//IL_17ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_17b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_160f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1614: Unknown result type (might be due to invalid IL or missing references)
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
						Point2d val27 = default;
						Point2d val28 = default;
						Point2d val29 = default;
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
								if (Operators.CompareString(mCabos[i].Pagina, borneJ.Pagina, TextCompare: true) == 0 && ((mCabos[i].Coluna == 1) & (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0) & (borneJ.Posicao == 1)))
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
								if ((mCabos[i].Coluna == 1) & (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0) & (num6 == 1))
								{
									num10 += num;
									if (num10 - num5 < 40.0)
									{
										num10 += 40.0 - (num10 - num5);
									}
								}
							}
							while (UwtpBjheyp(num10, num3, num4, mCabos[i].Pagina, revisao, Painel));
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
							Hatch val9 = NNrpVu9gbG(new Point3d(val6.X, val6.Y, 0.0), mCabos[i].Pagina);
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
								if (num6 == 1)
								{
									text2 = "VeiaSaiDireita";
								}
								ObjectId val10 = ObjectId.Null;
								string text3 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Interligação\\EnergisaMT\\" + text2 + ".dwg";
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
									val18 = new Point2d(val6.X + 20.0, val6.Y + 1.8);
									val19 = new Point2d(val6.X + 20.0, val6.Y - 1.8);
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
								val22.Height = 1.6;
								val22.TextStyleId = textStyleId;
								val22.WidthFactor = 0.8;
								Point3d alignmentPoint = new Point3d(val6.X + 21.0, val6.Y + 1.8, 0.0);
								val22.HorizontalMode = (TextHorizontalMode)0;
								val22.VerticalMode = (TextVerticalMode)2;
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
								Polyline val25 = new Polyline();
								((Entity)val25).SetDatabaseDefaults();
								((Entity)val25).ColorIndex = 7;
								((Entity)val25).Layer = borneJ2.Pagina;
								((Entity)val25).LineWeight = (LineWeight)9;
								if (borneJ2.contVeiasLigadas == 1 && borneJ2.TipoBorne != 0 && borneJ2.TipoBorne == 1)
								{
									mBornesJ[num16].ptInsTerm = new Point2d(borneJ2.ptInsTerm.X, borneJ2.ptInsTerm.Y - 5.0);
									borneJ2 = mBornesJ[num16];
								}
								double num17 = 0.0;
								Point2d val26 = new Point2d(num10, mCabos[i].ptIns.Y);
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
														val27 = new Point2d(num10, borneJ2.ptInsTerm.Y - 2.5);
														if (num6 == 1)
														{
															val28 = new Point2d(num10 - 2.5, borneJ2.ptInsTerm.Y);
															val29 = new Point2d(borneJ2.ptInsTerm.X + 1.5, borneJ2.ptInsTerm.Y);
															num17 = 0.42;
														}
														ptInsTerm = borneJ2.ptInsTerm;
													}
												}
												else
												{
													val27 = new Point2d(num10, borneJ2.ptInsTerm.Y - 5.0);
													if (num6 == 1)
													{
														val28 = new Point2d(num10 - 2.5, borneJ2.ptInsTerm.Y - 2.5);
														val29 = new Point2d(borneJ2.ptInsTerm.X + 1.5, borneJ2.ptInsTerm.Y - 2.5);
														num17 = 0.42;
													}
													if (val27.Y == val28.Y)
													{
														val27 = new Point2d(num10, val26.Y);
													}
													ptInsTerm = borneJ2.ptInsTerm;
												}
											}
											else
											{
												val27 = new Point2d(num10, borneJ2.ptInsTerm.Y - 2.5);
												if (num6 == 1)
												{
													val28 = new Point2d(num10 - 2.5, borneJ2.ptInsTerm.Y);
													val29 = new Point2d(borneJ2.ptInsTerm.X + 1.5, borneJ2.ptInsTerm.Y);
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
												val27 = new Point2d(num10, borneJ2.ptInsTerm.Y + 2.5);
												if (num6 == 1)
												{
													val28 = new Point2d(num10 - 2.5, borneJ2.ptInsTerm.Y);
													val29 = new Point2d(borneJ2.ptInsTerm.X + 1.5, borneJ2.ptInsTerm.Y);
													num17 = -0.42;
												}
												ptInsTerm = borneJ2.ptInsTerm;
											}
										}
										else
										{
											val27 = new Point2d(num10, borneJ2.ptInsTerm.Y);
											if (num6 == 1)
											{
												val28 = new Point2d(num10 - 2.5, borneJ2.ptInsTerm.Y - 2.5);
												val29 = new Point2d(borneJ2.ptInsTerm.X + 1.5, borneJ2.ptInsTerm.Y - 2.5);
												num17 = -0.42;
											}
											if (val27.Y == val28.Y)
											{
												val27 = new Point2d(num10, val26.Y);
											}
											ptInsTerm = borneJ2.ptInsTerm;
										}
									}
									else
									{
										val27 = new Point2d(num10, borneJ2.ptInsTerm.Y + 2.5);
										if (num6 == 1)
										{
											val28 = new Point2d(num10 - 2.5, borneJ2.ptInsTerm.Y);
											val29 = new Point2d(borneJ2.ptInsTerm.X + 1.5, borneJ2.ptInsTerm.Y);
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
											val27 = val26;
											if (num6 == 1)
											{
												val28 = new Point2d(num10 - 2.5, borneJ2.ptInsTerm.Y);
												val29 = new Point2d(borneJ2.ptInsTerm.X + 1.5, borneJ2.ptInsTerm.Y);
											}
											ptInsTerm = borneJ2.ptInsTerm;
											num17 = 0.0;
										}
									}
									else
									{
										val27 = val26;
										if (num6 == 1)
										{
											val28 = new Point2d(num10 - 2.5, borneJ2.ptInsTerm.Y - 2.5);
											val29 = new Point2d(borneJ2.ptInsTerm.X + 1.5, borneJ2.ptInsTerm.Y - 2.5);
										}
										ptInsTerm = borneJ2.ptInsTerm;
										num17 = -0.42;
									}
								}
								else
								{
									val27 = val26;
									if (num6 == 1)
									{
										val28 = new Point2d(num10 - 2.5, borneJ2.ptInsTerm.Y);
										val29 = new Point2d(borneJ2.ptInsTerm.X + 1.5, borneJ2.ptInsTerm.Y);
									}
									ptInsTerm = borneJ2.ptInsTerm;
									num17 = 0.0;
								}
								val24.AddVertexAt(0, val26, 0.0, 0.0, 0.0);
								val24.AddVertexAt(1, val27, 0.0, 0.0, 0.0);
								val24.AddVertexAt(2, val28, 0.0, 0.0, 0.0);
								val24.AddVertexAt(3, new Point2d(val29.X + 10.0, val29.Y), 0.0, 0.0, 0.0);
								val24.SetBulgeAt(1, num17);
								val25.AddVertexAt(0, new Point2d(val29.X + 5.0, val29.Y), 0.0, 0.0, 0.0);
								val25.AddVertexAt(1, val29, 0.0, 0.0, 0.0);
								val25.AddVertexAt(2, ptInsTerm, 0.0, 0.0, 0.0);
								val4.AppendEntity((Entity)(object)val24);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val24, true);
								val4.AppendEntity((Entity)(object)val25);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val25, true);
								ent = (Entity)(object)val24;
								XDataDIEnergisa.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, text4, borneJ2.Handle);
								val24 = (Polyline)ent;
								ent = (Entity)(object)val25;
								XDataDIEnergisa.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, text4, borneJ2.Handle);
								val25 = (Polyline)ent;
								TextStyleTable val30 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)0);
								ObjectId textStyleId2 = (((SymbolTable)val30).Has("Romans") ? ((SymbolTable)val30)["Romans"] : ((SymbolTable)val30)["Standard"]);
								DBText val31 = new DBText();
								val31.TextString = text4;
								((Entity)val31).ColorIndex = 7;
								((Entity)val31).Layer = ((Entity)val24).Layer;
								val31.Height = 1.6;
								val31.TextStyleId = textStyleId2;
								val31.WidthFactor = 0.9;
								if (num6 == 1)
								{
									alignmentPoint2 = new Point3d(val29.X + 7.5, val29.Y, 0.0);
									val31.HorizontalMode = (TextHorizontalMode)4;
									val31.VerticalMode = (TextVerticalMode)2;
								}
								val31.AlignmentPoint = alignmentPoint2;
								val4.AppendEntity((Entity)(object)val31);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val31, true);
								ent = (Entity)(object)val31;
								XDataDIEnergisa.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, text4, "");
								val31 = (DBText)ent;
								string text8 = "";
								DBText val32 = new DBText();
								((Entity)val32).Layer = ((Entity)val24).Layer;
								val32.Height = 1.6;
								val32.TextStyleId = textStyleId2;
								val32.WidthFactor = 0.9;
								val32.Rotation = 0.0;
								((Entity)val32).ColorIndex = 7;
								val32.Oblique = Math.PI / 12.0;
								text8 = text5;
								if (Operators.CompareString(text6, "", TextCompare: true) != 0)
								{
									text8 = text6;
								}
								text8 = text8 + "-" + text7;
								Point3d alignmentPoint3 = new Point3d(val29.X + 25.0, val29.Y + 1.1, 0.0);
								val32.HorizontalMode = (TextHorizontalMode)0;
								val32.VerticalMode = (TextVerticalMode)2;
								val32.AlignmentPoint = alignmentPoint3;
								val32.TextString = text8;
								val4.AppendEntity((Entity)(object)val32);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val32, true);
								ent = (Entity)(object)val32;
								XDataDIEnergisa.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, text4, "");
								val32 = (DBText)ent;
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
		//IL_06fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_071b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0720: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c52: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c91: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c99: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ca0: Expected Obj, but got Unknown
		//IL_085b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0860: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d44: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cc1: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e7: Expected Obj, but got Unknown
		//IL_09e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_088e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0895: Expected Obj, but got Unknown
		//IL_08b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cc6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cd0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cd7: Expected Obj, but got Unknown
		//IL_08d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_08db: Unknown result type (might be due to invalid IL or missing references)
		//IL_08dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e4: Expected Obj, but got Unknown
		//IL_08fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0913: Unknown result type (might be due to invalid IL or missing references)
		//IL_091b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0922: Expected Obj, but got Unknown
		//IL_0a56: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a66: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6d: Expected Obj, but got Unknown
		//IL_0a7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a82: Expected Obj, but got Unknown
		//IL_0a82: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a89: Expected Obj, but got Unknown
		//IL_0a8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b45: Expected Obj, but got Unknown
		//IL_0acd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dea: Expected Obj, but got Unknown
		//IL_0dec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c22: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c29: Expected Obj, but got Unknown
		//IL_0c45: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c6a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c71: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c78: Expected Obj, but got Unknown
		//IL_0c91: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0caf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cb6: Expected Obj, but got Unknown
		//IL_14d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_14db: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f75: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f7c: Expected Obj, but got Unknown
		//IL_0fa2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fa9: Expected Obj, but got Unknown
		//IL_0cc3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ccb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cd3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cda: Expected Obj, but got Unknown
		//IL_0fed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ff2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cef: Expected Obj, but got Unknown
		//IL_0cef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cf6: Expected Obj, but got Unknown
		//IL_0cfc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d17: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d78: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d7f: Expected Obj, but got Unknown
		//IL_15ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_15b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1624: Unknown result type (might be due to invalid IL or missing references)
		//IL_1626: Unknown result type (might be due to invalid IL or missing references)
		//IL_1660: Unknown result type (might be due to invalid IL or missing references)
		//IL_1665: Unknown result type (might be due to invalid IL or missing references)
		//IL_1689: Unknown result type (might be due to invalid IL or missing references)
		//IL_168e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1631: Unknown result type (might be due to invalid IL or missing references)
		//IL_1636: Unknown result type (might be due to invalid IL or missing references)
		//IL_1692: Unknown result type (might be due to invalid IL or missing references)
		//IL_1694: Unknown result type (might be due to invalid IL or missing references)
		//IL_17da: Unknown result type (might be due to invalid IL or missing references)
		//IL_17df: Unknown result type (might be due to invalid IL or missing references)
		//IL_1233: Unknown result type (might be due to invalid IL or missing references)
		//IL_1258: Unknown result type (might be due to invalid IL or missing references)
		//IL_127d: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_1304: Unknown result type (might be due to invalid IL or missing references)
		//IL_132c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1351: Unknown result type (might be due to invalid IL or missing references)
		//IL_1377: Unknown result type (might be due to invalid IL or missing references)
		//IL_1390: Unknown result type (might be due to invalid IL or missing references)
		//IL_13bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_13c6: Expected Obj, but got Unknown
		//IL_13e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_13e7: Expected Obj, but got Unknown
		//IL_13e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_13f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_13fb: Expected Obj, but got Unknown
		//IL_16d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_16dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_170b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1710: Unknown result type (might be due to invalid IL or missing references)
		//IL_169f: Unknown result type (might be due to invalid IL or missing references)
		//IL_16a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_15fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_15ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_180e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1813: Unknown result type (might be due to invalid IL or missing references)
		//IL_1837: Unknown result type (might be due to invalid IL or missing references)
		//IL_183c: Unknown result type (might be due to invalid IL or missing references)
		//IL_17ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_17ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_1859: Unknown result type (might be due to invalid IL or missing references)
		//IL_185e: Unknown result type (might be due to invalid IL or missing references)
		//IL_103f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ea3: Unknown result type (might be due to invalid IL or missing references)
		//IL_172c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1731: Unknown result type (might be due to invalid IL or missing references)
		//IL_1755: Unknown result type (might be due to invalid IL or missing references)
		//IL_175a: Unknown result type (might be due to invalid IL or missing references)
		//IL_160d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1612: Unknown result type (might be due to invalid IL or missing references)
		//IL_18a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_18ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_18dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_18e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_17a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_17a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1046: Unknown result type (might be due to invalid IL or missing references)
		//IL_104d: Expected Obj, but got Unknown
		//IL_107e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b70: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b75: Unknown result type (might be due to invalid IL or missing references)
		//IL_19d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_19de: Unknown result type (might be due to invalid IL or missing references)
		//IL_18fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1901: Unknown result type (might be due to invalid IL or missing references)
		//IL_187b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1880: Unknown result type (might be due to invalid IL or missing references)
		//IL_1920: Unknown result type (might be due to invalid IL or missing references)
		//IL_1925: Unknown result type (might be due to invalid IL or missing references)
		//IL_1949: Unknown result type (might be due to invalid IL or missing references)
		//IL_194e: Unknown result type (might be due to invalid IL or missing references)
		//IL_17b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_17bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ba2: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_10ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_10d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e0: Expected Obj, but got Unknown
		//IL_10e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_10ee: Expected Obj, but got Unknown
		//IL_110e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a12: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a36: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a3b: Unknown result type (might be due to invalid IL or missing references)
		//IL_19e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_19ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a62: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a67: Unknown result type (might be due to invalid IL or missing references)
		//IL_11a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_11a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_11fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1202: Expected Obj, but got Unknown
		//IL_1ab2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ab7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ae5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1aea: Unknown result type (might be due to invalid IL or missing references)
		//IL_19a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_19a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b05: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a84: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a89: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b29: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b52: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b57: Unknown result type (might be due to invalid IL or missing references)
		//IL_19b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_19ba: Unknown result type (might be due to invalid IL or missing references)
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
						Point2d val24 = default;
						Point2d val25 = default;
						Point2d val26 = default;
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
								if ((mCabos[i].Coluna == 1) & (Operators.CompareString(mCabos[i].Lado, "E", TextCompare: true) == 0))
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
									if (num6 == 1)
									{
										num22 += num;
										if (num22 - num5 < 40.0)
										{
											num22 += 40.0 - (num22 - num5);
										}
									}
								}
								while (UwtpBjheyp(num22, num3, num4, array[inicio].Pagina, revisao, Painel));
								DeclaracoesInterligacao.borneJ borneJ3 = mBornesJ[array[inicio].indiceBorne];
								Point2d val6 = new Point2d(num22, borneJ3.ptInsTerm.Y);
								Hatch val7 = NNrpVu9gbG(new Point3d(val6.X, val6.Y, 0.0), array[inicio].Pagina);
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
								if (num6 == 1)
								{
									text = ((!flag) ? "VeiaEntraDireita" : "VeiaEntraDireitaReta");
								}
								ObjectId val8 = ObjectId.Null;
								string text2 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Interligação\\EnergisaMT\\" + text + ".dwg";
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
										text3 = mCabos[i].Tag_Cabo + " ";
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
									if (num6 == 1)
									{
										text = "VeiaSaiDireita";
									}
									val8 = ObjectId.Null;
									text2 = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Interligação\\EnergisaMT\\" + text + ".dwg";
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
									Polyline val22 = new Polyline();
									((Entity)val22).SetDatabaseDefaults();
									((Entity)val22).ColorIndex = 7;
									((Entity)val22).Layer = borneJ4.Pagina;
									((Entity)val22).LineWeight = (LineWeight)9;
									if (borneJ4.contVeiasLigadas == 1 && borneJ4.TipoBorne != 0 && borneJ4.TipoBorne == 1)
									{
										mBornesJ[array[num31].indiceBorne].ptInsTerm = new Point2d(borneJ4.ptInsTerm.X, borneJ4.ptInsTerm.Y - 5.0);
										borneJ4 = mBornesJ[array[num31].indiceBorne];
									}
									double num32 = 0.0;
									Point2d val23 = new Point2d(num22, y);
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
															val24 = new Point2d(num22, borneJ4.ptInsTerm.Y - 2.5);
															if (num6 == 1)
															{
																val25 = new Point2d(num22 - 2.5, borneJ4.ptInsTerm.Y);
																val26 = new Point2d(borneJ4.ptInsTerm.X + 1.5, borneJ4.ptInsTerm.Y);
																num32 = 0.42;
															}
															ptInsTerm = borneJ4.ptInsTerm;
														}
													}
													else
													{
														val24 = new Point2d(num22, borneJ4.ptInsTerm.Y - 5.0);
														if (num6 == 1)
														{
															val25 = new Point2d(num22 - 2.5, borneJ4.ptInsTerm.Y - 2.5);
															val26 = new Point2d(borneJ4.ptInsTerm.X + 1.5, borneJ4.ptInsTerm.Y - 2.5);
															num32 = 0.42;
														}
														if (val24.Y == val25.Y)
														{
															val24 = new Point2d(num22, val23.Y);
														}
														ptInsTerm = borneJ4.ptInsTerm;
													}
												}
												else
												{
													val24 = new Point2d(num22, borneJ4.ptInsTerm.Y - 2.5);
													if (num6 == 1)
													{
														val25 = new Point2d(num22 - 2.5, borneJ4.ptInsTerm.Y);
														val26 = new Point2d(borneJ4.ptInsTerm.X + 1.5, borneJ4.ptInsTerm.Y);
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
													val24 = new Point2d(num22, borneJ4.ptInsTerm.Y + 2.5);
													if (num6 == 1)
													{
														val25 = new Point2d(num22 - 2.5, borneJ4.ptInsTerm.Y);
														val26 = new Point2d(borneJ4.ptInsTerm.X + 1.5, borneJ4.ptInsTerm.Y);
														num32 = -0.42;
													}
													ptInsTerm = borneJ4.ptInsTerm;
												}
											}
											else
											{
												val24 = new Point2d(num22, borneJ4.ptInsTerm.Y);
												if (num6 == 1)
												{
													val25 = new Point2d(num22 - 2.5, borneJ4.ptInsTerm.Y - 2.5);
													val26 = new Point2d(borneJ4.ptInsTerm.X + 1.5, borneJ4.ptInsTerm.Y - 2.5);
													num32 = -0.42;
												}
												if (val24.Y == val25.Y)
												{
													val24 = new Point2d(num22, val23.Y);
												}
												ptInsTerm = borneJ4.ptInsTerm;
											}
										}
										else
										{
											val24 = new Point2d(num22, borneJ4.ptInsTerm.Y + 2.5);
											if (num6 == 1)
											{
												val25 = new Point2d(num22 - 2.5, borneJ4.ptInsTerm.Y);
												val26 = new Point2d(borneJ4.ptInsTerm.X + 1.5, borneJ4.ptInsTerm.Y);
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
												val24 = val23;
												if (num6 == 1)
												{
													val25 = new Point2d(num22 - 2.5, borneJ4.ptInsTerm.Y);
													val26 = new Point2d(borneJ4.ptInsTerm.X + 1.5, borneJ4.ptInsTerm.Y);
												}
												ptInsTerm = borneJ4.ptInsTerm;
												num32 = 0.0;
											}
										}
										else
										{
											val24 = val23;
											if (num6 == 1)
											{
												val25 = new Point2d(num22 - 2.5, borneJ4.ptInsTerm.Y - 2.5);
												val26 = new Point2d(borneJ4.ptInsTerm.X + 1.5, borneJ4.ptInsTerm.Y - 2.5);
											}
											ptInsTerm = borneJ4.ptInsTerm;
											num32 = 0.42;
										}
									}
									else
									{
										val24 = val23;
										if (num6 == 1)
										{
											val25 = new Point2d(num22 - 2.5, borneJ4.ptInsTerm.Y);
											val26 = new Point2d(borneJ4.ptInsTerm.X + 1.5, borneJ4.ptInsTerm.Y);
										}
										ptInsTerm = borneJ4.ptInsTerm;
										num32 = 0.0;
									}
									val21.AddVertexAt(0, val23, 0.0, 0.0, 0.0);
									val21.AddVertexAt(1, val24, 0.0, 0.0, 0.0);
									val21.AddVertexAt(2, val25, 0.0, 0.0, 0.0);
									val21.AddVertexAt(3, new Point2d(val26.X + 10.0, val26.Y), 0.0, 0.0, 0.0);
									val21.SetBulgeAt(1, num32);
									val22.AddVertexAt(0, new Point2d(val26.X + 5.0, val26.Y), 0.0, 0.0, 0.0);
									val22.AddVertexAt(1, val26, 0.0, 0.0, 0.0);
									val22.AddVertexAt(2, ptInsTerm, 0.0, 0.0, 0.0);
									val4.AppendEntity((Entity)(object)val21);
									DeclaracoesGeral.bAnularEventos = true;
									val2.AddNewlyCreatedDBObject((DBObject)(object)val21, true);
									val4.AppendEntity((Entity)(object)val22);
									DeclaracoesGeral.bAnularEventos = true;
									val2.AddNewlyCreatedDBObject((DBObject)(object)val22, true);
									ent = (Entity)(object)val21;
									XDataDIEnergisa.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, veia2, borneJ4.Handle);
									val21 = (Polyline)ent;
									ent = (Entity)(object)val22;
									XDataDIEnergisa.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, veia2, borneJ4.Handle);
									val22 = (Polyline)ent;
									TextStyleTable val27 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)0);
									ObjectId textStyleId = (((SymbolTable)val27).Has("Romans") ? ((SymbolTable)val27)["Romans"] : ((SymbolTable)val27)["Standard"]);
									DBText val28 = new DBText();
									val28.TextString = veia2;
									((Entity)val28).ColorIndex = 7;
									((Entity)val28).Layer = ((Entity)val21).Layer;
									val28.Height = 1.6;
									val28.TextStyleId = textStyleId;
									val28.WidthFactor = 0.9;
									if (num6 == 1)
									{
										alignmentPoint = new Point3d(val26.X + 7.5, val26.Y, 0.0);
										val28.HorizontalMode = (TextHorizontalMode)4;
										val28.VerticalMode = (TextVerticalMode)2;
									}
									val28.AlignmentPoint = alignmentPoint;
									val4.AppendEntity((Entity)(object)val28);
									DeclaracoesGeral.bAnularEventos = true;
									val2.AddNewlyCreatedDBObject((DBObject)(object)val28, true);
									ent = (Entity)(object)val28;
									XDataDIEnergisa.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, veia2, "");
									val28 = (DBText)ent;
									string text6 = "";
									DBText val29 = new DBText();
									((Entity)val29).Layer = ((Entity)val21).Layer;
									val29.Height = 1.6;
									val29.TextStyleId = textStyleId;
									val29.WidthFactor = 0.9;
									val29.Rotation = 0.0;
									((Entity)val29).ColorIndex = 7;
									val29.Oblique = Math.PI / 12.0;
									text6 = tagDest2;
									if (Operators.CompareString(nReguaDest2, "", TextCompare: true) != 0)
									{
										text6 = nReguaDest2;
									}
									text6 = text6 + "-" + borneDest2;
									Point3d alignmentPoint2 = new Point3d(val26.X + 25.0, val26.Y + 1.1, 0.0);
									val29.HorizontalMode = (TextHorizontalMode)0;
									val29.VerticalMode = (TextVerticalMode)2;
									val29.AlignmentPoint = alignmentPoint2;
									val29.TextString = text6;
									val4.AppendEntity((Entity)(object)val29);
									DeclaracoesGeral.bAnularEventos = true;
									val2.AddNewlyCreatedDBObject((DBObject)(object)val29, true);
									ent = (Entity)(object)val29;
									XDataDIEnergisa.GravarXDataVeia(ref ent, revisao, Painel, tag_Cabo, veia2, "");
									val29 = (DBText)ent;
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
									BlockReference val30 = (BlockReference)val2.GetObject(iD, (OpenMode)0);
									AttributeCollection attributeCollection = val30.AttributeCollection;
									foreach (object item in attributeCollection)
									{
										ObjectId val31 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
										AttributeReference val32 = (AttributeReference)val31.GetObject((OpenMode)1);
										string text7 = mInfoVeias[num34].mBornes[num36 + 1].rb + " ";
										if (Operators.CompareString(pagina3, pagina4, TextCompare: true) != 0)
										{
											text7 = text7 + DeclaracoesGeral.Conf.PrefixoCruzInterno + pagina4 + DeclaracoesGeral.Conf.SufixoCruzInterno;
										}
										string tag2 = val32.Tag;
										if (Operators.CompareString(tag2, "BORNE", TextCompare: true) == 0)
										{
											((DBText)val32).TextString = text7;
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

	private static Hatch NNrpVu9gbG(Point3d P_0, string P_1)
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
								if (Operators.CompareString(tag, "CAD", TextCompare: true) == 0 || Operators.CompareString(tag, "COL", TextCompare: true) == 0 || Operators.CompareString(tag, "FL1", TextCompare: true) == 0)
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
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Expected Obj, but got Unknown
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
								string text = mTodosCabosSync[i].Caderno;
								string textString = DeclaracoesGeral.Conf.PrefixoCruzInterno + mTodosCabosSync[i].Folha + DeclaracoesGeral.Conf.SufixoCruzInterno;
								if (Operators.CompareString(DeclaracoesGeral.Conf.Local, text, TextCompare: true) == 0)
								{
									text = "";
								}
								AttributeCollection attributeCollection = val5.AttributeCollection;
								foreach (object item in attributeCollection)
								{
									ObjectId val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
									AttributeReference val7 = (AttributeReference)val6.GetObject((OpenMode)1);
									string tag = val7.Tag;
									if (Operators.CompareString(tag, "FL1", TextCompare: true) != 0)
									{
										if (Operators.CompareString(tag, "CAD", TextCompare: true) == 0)
										{
											((DBText)val7).TextString = text;
										}
									}
									else
									{
										((DBText)val7).TextString = textString;
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

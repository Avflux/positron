using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
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

public class clsBlocos
{
	public struct StructureErros
	{
		public string iPainel;

		public string sTipo;

		public string sPagina;

		public string sHandle;
	}

	public static int AcadObjectCount()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected Obj, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected Obj, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Database database = mdiActiveDocument.Database;
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
					_ = enumerator.Current;
					num = checked(num + 1);
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
		return num;
	}

	public static ObjectId RetornaID_Bloco(string shandle)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected Obj, but got Unknown
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected Obj, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected Obj, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		ObjectId result = ObjectId.Null;
		try
		{
			DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = (Transaction)(object)database.TransactionManager.StartOpenCloseTransaction();
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
							BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
							if (val6 != null && Operators.CompareString(((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString(), shandle, TextCompare: true) == 0)
							{
								result = ((DBObject)val6).ObjectId;
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
		catch (Exception ex)
		{
			ProjectData.SetProjectError((Exception)ex);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static void MarcaComoErro(string sHandle, string sDisp, string sTipo)
	{
		//IL_033e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0344: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected Obj, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Expected Obj, but got Unknown
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected Obj, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Expected Obj, but got Unknown
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				ObjectId val5 = Geral.HandleToID(sHandle);
				if (val5.IsValid)
				{
					Entity val6 = (Entity)val2.GetObject(val5, (OpenMode)0);
					if (val6 != null)
					{
						Extents3d value = ((Drawable)val6).Bounds.Value;
						object instance = value.MinPoint;
						value = ((Drawable)val6).Bounds.Value;
						object instance2 = value.MaxPoint;
						Point2d val7 = new Point2d(Conversions.ToDouble(NewLateBinding.LateGet(instance, null, "X", new object[0], null, null, null)), Conversions.ToDouble(NewLateBinding.LateGet(instance, null, "Y", new object[0], null, null, null)));
						Point2d val8 = new Point2d(Conversions.ToDouble(NewLateBinding.LateGet(instance2, null, "X", new object[0], null, null, null)), Conversions.ToDouble(NewLateBinding.LateGet(instance2, null, "Y", new object[0], null, null, null)));
						Point2d val9 = new Point2d(Conversions.ToDouble(NewLateBinding.LateGet(instance2, null, "X", new object[0], null, null, null)), Conversions.ToDouble(NewLateBinding.LateGet(instance, null, "Y", new object[0], null, null, null)));
						Point2d val10 = new Point2d(Conversions.ToDouble(NewLateBinding.LateGet(instance, null, "X", new object[0], null, null, null)), Conversions.ToDouble(NewLateBinding.LateGet(instance2, null, "Y", new object[0], null, null, null)));
						Polyline val11 = new Polyline();
						Polyline val12 = new Polyline();
						((Entity)val11).SetDatabaseDefaults();
						((Entity)val12).SetDatabaseDefaults();
						((Entity)val11).ColorIndex = DeclaracoesGeral.Conf.CorConexao;
						val11.AddVertexAt(0, val7, 0.0, 0.0, 0.0);
						val11.AddVertexAt(1, val8, 0.0, 0.0, 0.0);
						((Entity)val11).ColorIndex = 1;
						((Entity)val11).Layer = val6.Layer;
						((Entity)val11).LineWeight = (LineWeight)30;
						val4.AppendEntity((Entity)(object)val11);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)val11, true);
						Entity Ent = (Entity)(object)val11;
						XDataDispositivosMaster.GravarXDataErro(ref Ent, sTipo, sDisp, sHandle);
						val11 = (Polyline)Ent;
						((Entity)val12).ColorIndex = DeclaracoesGeral.Conf.CorConexao;
						val12.AddVertexAt(0, val9, 0.0, 0.0, 0.0);
						val12.AddVertexAt(1, val10, 0.0, 0.0, 0.0);
						((Entity)val12).ColorIndex = 1;
						((Entity)val12).Layer = val6.Layer;
						((Entity)val12).LineWeight = (LineWeight)30;
						val4.AppendEntity((Entity)(object)val12);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)val12, true);
						Ent = (Entity)(object)val12;
						XDataDispositivosMaster.GravarXDataErro(ref Ent, sTipo, sDisp, sHandle);
						val12 = (Polyline)Ent;
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
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

	public static void ApagaERROS(ref string sTipo)
	{
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected Obj, but got Unknown
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected Obj, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected Obj, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected Obj, but got Unknown
		try
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
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity Ent = (Entity)val2.GetObject(current, (OpenMode)1);
							string sDisp = "";
							string sHandle = "";
							if (Operators.ConditionalCompareObjectEqual(XDataDispositivosMaster.LerXDataErro(ref Ent, sTipo, ref sDisp, ref sHandle), true, TextCompare: true))
							{
								((DBObject)Ent).UpgradeOpen();
								((DBObject)Ent).Erase();
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
				catch (Exception ex)
				{
					ProjectData.SetProjectError((Exception)ex);
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
		catch (Exception ex2)
		{
			ProjectData.SetProjectError((Exception)ex2);
			throw;
		}
		finally
		{
		}
	}

	public static void calculaOPontoCentralDoBloco(BlockReference blockRef, ref Point3d pt, ref double dPontoDoModelo, string sNomeBlocoAnterior)
	{
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		double num = 0.0;
		string text = blockRef.Name;
		if (text.Contains("RC_TIT") | text.Contains("RC_TIT1") | text.Contains("RC_TIT2"))
		{
			text = "RC_TIT";
		}
		string left = text;
		if (Operators.CompareString(left, "RC_TIT", TextCompare: true) != 0)
		{
			if (Operators.CompareString(left, "RC_NA", TextCompare: true) != 0)
			{
				if (Operators.CompareString(left, "RC_NF", TextCompare: true) != 0)
				{
					if (Operators.CompareString(left, "RC_RV", TextCompare: true) == 0)
					{
						num = Declaracoes2.mTamanhosDosContatos.RV + dPontoDoModelo;
					}
				}
				else
				{
					num = Declaracoes2.mTamanhosDosContatos.NF + dPontoDoModelo;
				}
			}
			else
			{
				num = Declaracoes2.mTamanhosDosContatos.NA + dPontoDoModelo;
			}
		}
		else
		{
			num = Declaracoes2.mTamanhosDosContatos.TIT + dPontoDoModelo;
		}
		Point3d position = blockRef.Position;
		double x = position.X;
		position = blockRef.Position;
		pt = new Point3d(x, position.Y - num, 0.0);
	}

	public static void EditaUmAtributoDeUmBloco(ref string sHandle, string sAttributo, string sValor, bool bliga = true)
	{
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected Obj, but got Unknown
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				Entity val4 = (Entity)Geral.HandleToObject(sHandle);
				if (val4 != null)
				{
					BlockReference val5 = (BlockReference)(object)((val4 is BlockReference) ? val4 : null);
					AttributeCollection attributeCollection = val5.AttributeCollection;
					foreach (object item in attributeCollection)
					{
						ObjectId val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
						AttributeReference val7 = (AttributeReference)val6.GetObject((OpenMode)1);
						if (Operators.CompareString(val7.Tag.ToUpper(), sAttributo.ToUpper(), TextCompare: true) == 0)
						{
							((DBObject)val7).UpgradeOpen();
							if (Operators.CompareString(((DBText)val7).TextString, sValor, TextCompare: true) != 0)
							{
								((DBText)val7).TextString = sValor;
							}
							((Entity)val7).Visible = bliga;
							((DBText)val7).AdjustAlignment(database);
							((Entity)val7).Draw();
							break;
						}
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
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

	public static void EditaNomesDeUmBloco(ref string sHandle, string sNome1, string sNome2, string sAlternativo)
	{
		//IL_0308: Unknown result type (might be due to invalid IL or missing references)
		//IL_030e: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected Obj, but got Unknown
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected Obj, but got Unknown
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				Entity val4 = (Entity)Geral.HandleToObject(sHandle);
				if (val4 != null)
				{
					BlockReference val5 = (BlockReference)(object)((val4 is BlockReference) ? val4 : null);
					AttributeCollection attributeCollection = val5.AttributeCollection;
					bool flag = false;
					bool flag2 = false;
					bool flag3 = false;
					bool visible = false;
					bool flag4 = false;
					ObjectId val6;
					foreach (object item in attributeCollection)
					{
						val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
						AttributeReference val7 = (AttributeReference)val6.GetObject((OpenMode)1);
						if (Operators.CompareString(val7.Tag, "NOME1", TextCompare: true) == 0 && ((Entity)val7).Visible)
						{
							flag3 = true;
						}
						if (Operators.CompareString(val7.Tag, "NOME2", TextCompare: true) == 0)
						{
							flag = true;
							if (((Entity)val7).Visible)
							{
								visible = true;
							}
						}
						if (Operators.CompareString(val7.Tag, "ALTERNATIVO", TextCompare: true) == 0)
						{
							flag2 = true;
							if (((Entity)val7).Visible)
							{
								flag4 = true;
							}
						}
					}
					if (flag3 && !flag && Operators.CompareString(sNome2, "", TextCompare: true) != 0)
					{
						sNome1 = sNome1 + "/" + sNome2;
						sNome2 = "";
					}
					if (!flag2 && flag4)
					{
						sNome1 = (flag3 ? (sNome1 + "/" + sAlternativo) : sAlternativo);
					}
					foreach (object item2 in attributeCollection)
					{
						val6 = ((item2 == null) ? default(ObjectId) : ((ObjectId)item2));
						AttributeReference val7 = (AttributeReference)val6.GetObject((OpenMode)1);
						string left = val7.Tag.ToUpper();
						if (Operators.CompareString(left, "NOME1", TextCompare: true) != 0)
						{
							if (Operators.CompareString(left, "NOME2", TextCompare: true) != 0)
							{
								if (Operators.CompareString(left, "ALTERNATIVO", TextCompare: true) == 0)
								{
									((DBObject)val7).UpgradeOpen();
									((DBText)val7).TextString = sAlternativo;
									((Entity)val7).Visible = flag4;
									((DBText)val7).AdjustAlignment(database);
									((Entity)val7).Draw();
								}
							}
							else
							{
								((DBObject)val7).UpgradeOpen();
								((DBText)val7).TextString = sNome2;
								((Entity)val7).Visible = visible;
								((DBText)val7).AdjustAlignment(database);
								((Entity)val7).Draw();
							}
						}
						else
						{
							((DBObject)val7).UpgradeOpen();
							((DBText)val7).TextString = sNome1;
							((Entity)val7).Visible = flag3;
							((DBText)val7).AdjustAlignment(database);
							((Entity)val7).Draw();
						}
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
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

	public static void AtualizaValorDeUmAtributo(ref string sHandle, string sAttributo, string sValor)
	{
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected Obj, but got Unknown
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				Entity val4 = (Entity)Geral.HandleToObject(sHandle);
				if (val4 != null)
				{
					BlockReference val5 = (BlockReference)(object)((val4 is BlockReference) ? val4 : null);
					AttributeCollection attributeCollection = val5.AttributeCollection;
					foreach (object item in attributeCollection)
					{
						ObjectId val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
						AttributeReference val7 = (AttributeReference)val6.GetObject((OpenMode)1);
						if (Operators.CompareString(val7.Tag.ToUpper(), sAttributo.ToUpper(), TextCompare: true) == 0)
						{
							((DBObject)val7).UpgradeOpen();
							((DBText)val7).TextString = sValor;
							((DBText)val7).AdjustAlignment(database);
							((Entity)val7).Draw();
						}
					}
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
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

	public static void AtualizaValorDeUmAtributoPMF(ref string sHandle, string iPN, int iLM, clsLM.LModFab[] ModFab, string sModelo)
	{
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected Obj, but got Unknown
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			try
			{
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					try
					{
						BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
						try
						{
							Entity val5 = (Entity)Geral.HandleToObject(sHandle);
							try
							{
								if (val5 != null)
								{
									string text = "";
									int num = Information.UBound(ModFab);
									for (int i = 1; i <= num; i = checked(i + 1))
									{
										if (ModFab[i].indice == iLM)
										{
											text = ModFab[i].Fabricante;
											break;
										}
									}
									BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
									try
									{
										AttributeCollection attributeCollection = val6.AttributeCollection;
										string text2 = "";
										foreach (object item in attributeCollection)
										{
											ObjectId val7 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
											AttributeReference val8 = (AttributeReference)val7.GetObject((OpenMode)1);
											text2 = ((DBText)val8).TextString;
											bool flag = false;
											string left = val8.Tag.ToUpper();
											if (Operators.CompareString(left, "PAINEL", TextCompare: true) != 0)
											{
												if (Operators.CompareString(left, "MODELO", TextCompare: true) != 0)
												{
													if (Operators.CompareString(left, "FABRICANTE", TextCompare: true) == 0 && Operators.CompareString(((DBText)val8).TextString, text, TextCompare: true) != 0)
													{
														text2 = text;
														flag = true;
													}
												}
												else if (Operators.CompareString(((DBText)val8).TextString, sModelo, TextCompare: true) != 0)
												{
													text2 = sModelo;
													flag = true;
												}
											}
											else if (Operators.CompareString(((DBText)val8).TextString, Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(iPN)), TextCompare: true) != 0)
											{
												text2 = Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(iPN));
												flag = true;
											}
											if (flag)
											{
												((DBObject)val8).UpgradeOpen();
												((DBText)val8).TextString = text2;
												((DBText)val8).AdjustAlignment(database);
												((Entity)val8).Draw();
												((DisposableWrapper)val8).Dispose();
											}
										}
									}
									finally
									{
										((IDisposable)val6)?.Dispose();
									}
								}
								DeclaracoesGeral.bAnularEventos = true;
								val2.Commit();
								DeclaracoesGeral.bAnularEventos = false;
							}
							finally
							{
								((IDisposable)val5)?.Dispose();
							}
						}
						finally
						{
							((IDisposable)val4)?.Dispose();
						}
					}
					finally
					{
						((IDisposable)val3)?.Dispose();
					}
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError((Exception)ex);
					ProjectData.ClearProjectError();
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

	public static bool AtributoVisivelDeUmBloco(ref string sHandle, string sAttributo)
	{
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected Obj, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected Obj, but got Unknown
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected Obj, but got Unknown
		bool result = false;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				ObjectId val4 = Geral.HandleToID(sHandle);
				if (val4.IsValid)
				{
					Entity val5 = (Entity)val2.GetObject(val4, (OpenMode)0);
					if (val5 != null)
					{
						BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
						AttributeCollection attributeCollection = val6.AttributeCollection;
						foreach (object item in attributeCollection)
						{
							ObjectId val7 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							AttributeReference val8 = (AttributeReference)val7.GetObject((OpenMode)0);
							if (Operators.CompareString(val8.Tag.ToUpper(), sAttributo.ToUpper(), TextCompare: true) == 0)
							{
								result = ((Entity)val8).Visible;
								break;
							}
						}
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
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
		return result;
	}

	public static void EditaUmaMascara(ref string sHandle, DeclaracoesEntidades.StructureMascara DispMasc, bool bAlternativoVisivel)
	{
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Expected Obj, but got Unknown
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected Obj, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected Obj, but got Unknown
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			BlockTable val = (BlockTable)topTransaction.GetObject(database.BlockTableId, (OpenMode)0);
			_ = (BlockTableRecord)topTransaction.GetObject(((SymbolTable)val)[BlockTableRecord.ModelSpace], (OpenMode)0);
			Entity val2 = (Entity)Geral.HandleToObject(sHandle);
			if (val2 != null)
			{
				string text = DispMasc.Nome1;
				string alternativo = DispMasc.Alternativo;
				if (Operators.CompareString(DispMasc.Nome2, "", TextCompare: true) != 0)
				{
					text = text + "/" + DispMasc.Nome2;
				}
				BlockReference val3 = (BlockReference)(object)((val2 is BlockReference) ? val2 : null);
				AttributeCollection attributeCollection = val3.AttributeCollection;
				foreach (object item in attributeCollection)
				{
					object objectValue = RuntimeHelpers.GetObjectValue(item);
					AttributeReference val4 = (AttributeReference)NewLateBinding.LateGet(objectValue, null, "GetObject", new object[1] { (object)(OpenMode)1 }, null, null, null);
					string text2 = "";
					string tag = val4.Tag;
					if (Operators.CompareString(tag, "NOME1", TextCompare: true) != 0)
					{
						if (Operators.CompareString(tag, "FABRICANTE", TextCompare: true) != 0)
						{
							if (Operators.CompareString(tag, "DESCRICAO", TextCompare: true) != 0)
							{
								if (Operators.CompareString(tag, "MODELO", TextCompare: true) != 0)
								{
									if (Operators.CompareString(tag, "ALTERNATIVO", TextCompare: true) != 0)
									{
										text2 = ((DBText)val4).TextString;
									}
									else
									{
										text2 = alternativo;
										((Entity)val4).Visible = bAlternativoVisivel;
									}
								}
								else
								{
									text2 = DispMasc.Modelo;
								}
							}
							else
							{
								text2 = DispMasc.Descricao;
							}
						}
						else
						{
							text2 = DispMasc.Fabricante;
						}
					}
					else
					{
						text2 = text;
					}
					((DBText)val4).TextString = clsTextos.TiraNothing(text2);
					((DBText)val4).AdjustAlignment(database);
					((Entity)val4).Draw();
				}
			}
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError((Exception)ex);
			throw;
		}
		finally
		{
			((IDisposable)topTransaction)?.Dispose();
		}
	}

	public static void PreencheOsNomesDeUmBloco(ref string sHandle, string sNome1, string sNome2, string sAlternativo)
	{
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected Obj, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected Obj, but got Unknown
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				Entity val4 = (Entity)Geral.HandleToObject(sHandle);
				if (val4 != null)
				{
					BlockReference val5 = (BlockReference)(object)((val4 is BlockReference) ? val4 : null);
					AttributeCollection attributeCollection = val5.AttributeCollection;
					bool flag = false;
					ObjectId val6;
					foreach (object item in attributeCollection)
					{
						val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
						AttributeReference val7 = (AttributeReference)val6.GetObject((OpenMode)1);
						if (Operators.CompareString(val7.Tag, "NOME1", TextCompare: true) != 0)
						{
						}
						if (Operators.CompareString(val7.Tag, "NOME2", TextCompare: true) == 0)
						{
							flag = true;
						}
					}
					if (!flag && Operators.CompareString(sNome2, "", TextCompare: true) != 0)
					{
						sNome1 = sNome1 + "/" + sNome2;
						sNome2 = "";
					}
					foreach (object item2 in attributeCollection)
					{
						val6 = ((item2 == null) ? default(ObjectId) : ((ObjectId)item2));
						AttributeReference val7 = (AttributeReference)val6.GetObject((OpenMode)1);
						string left = val7.Tag.ToUpper();
						if (Operators.CompareString(left, "NOME1", TextCompare: true) != 0)
						{
							if (Operators.CompareString(left, "NOME2", TextCompare: true) != 0)
							{
								if (Operators.CompareString(left, "ALTERNATIVO", TextCompare: true) == 0)
								{
									((DBObject)val7).UpgradeOpen();
									((DBText)val7).TextString = sAlternativo;
								}
							}
							else
							{
								((DBObject)val7).UpgradeOpen();
								((DBText)val7).TextString = sNome2;
							}
						}
						else
						{
							((DBObject)val7).UpgradeOpen();
							((DBText)val7).TextString = sNome1;
						}
						((DBText)val7).AdjustAlignment(database);
						((Entity)val7).Draw();
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
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

	public static void EditaNomesDeUmBloco(ref string sHandle, string sNome1, string sNome2, string sAlternativo, string sTerm, bool bNomeVisivel, bool bAlternativoVisivel)
	{
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e4: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected Obj, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected Obj, but got Unknown
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				ObjectId val4 = Geral.HandleToID(sHandle);
				if (val4.IsValid)
				{
					Entity val5 = (Entity)val2.GetObject(val4, (OpenMode)0);
					if (val5 != null)
					{
						BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
						AttributeCollection attributeCollection = val6.AttributeCollection;
						bool flag = false;
						bool flag2 = false;
						ObjectId val7;
						foreach (object item in attributeCollection)
						{
							val7 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							AttributeReference val8 = (AttributeReference)val7.GetObject((OpenMode)1);
							if (Operators.CompareString(val8.Tag, "NOME1", TextCompare: true) != 0)
							{
							}
							if (Operators.CompareString(val8.Tag, "NOME2", TextCompare: true) == 0)
							{
								flag = true;
							}
							if (Operators.CompareString(val8.Tag, "ALTERNATIVO", TextCompare: true) == 0)
							{
								flag2 = true;
							}
						}
						if (bNomeVisivel && !flag && Operators.CompareString(sNome2, "", TextCompare: true) != 0)
						{
							sNome1 = sNome1 + "/" + sNome2;
							sNome2 = "";
						}
						if (!flag2 && bAlternativoVisivel)
						{
							sNome1 = (bNomeVisivel ? (sNome1 + "/" + sAlternativo) : sAlternativo);
						}
						foreach (object item2 in attributeCollection)
						{
							val7 = ((item2 == null) ? default(ObjectId) : ((ObjectId)item2));
							AttributeReference val8 = (AttributeReference)val7.GetObject((OpenMode)1);
							string left = val8.Tag.ToUpper();
							if (Operators.CompareString(left, "NOME1", TextCompare: true) != 0)
							{
								if (Operators.CompareString(left, "NOME2", TextCompare: true) != 0)
								{
									if (Operators.CompareString(left, "ALTERNATIVO", TextCompare: true) == 0)
									{
										((DBObject)val8).UpgradeOpen();
										((DBText)val8).TextString = sAlternativo;
										((Entity)val8).Visible = bAlternativoVisivel;
									}
								}
								else
								{
									((DBObject)val8).UpgradeOpen();
									((DBText)val8).TextString = sNome2;
									((Entity)val8).Visible = bNomeVisivel;
								}
							}
							else
							{
								((DBObject)val8).UpgradeOpen();
								((DBText)val8).TextString = sNome1;
								((Entity)val8).Visible = bNomeVisivel;
							}
							((DBText)val8).AdjustAlignment(database);
							((Entity)val8).Draw();
						}
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
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

	public static void EditaTerminaisDeUmBloco(ref string sHandle, string sTerm)
	{
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027b: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected Obj, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected Obj, but got Unknown
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
					_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					ObjectId val4 = Geral.HandleToID(sHandle);
					if (val4.IsValid)
					{
						Entity val5 = (Entity)val2.GetObject(val4, (OpenMode)0);
						if (val5 != null)
						{
							BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
							AttributeCollection attributeCollection = val6.AttributeCollection;
							foreach (object item in attributeCollection)
							{
								ObjectId val7 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
								AttributeReference val8 = (AttributeReference)val7.GetObject((OpenMode)1);
								string left = val8.Tag.ToUpper();
								if (Operators.CompareString(left, Strings.Mid(val8.Tag, 1, 1) + Strings.Mid(val8.Tag, 2, Strings.Len(val8.Tag)), TextCompare: true) == 0 && ((Operators.CompareString(Strings.Mid(val8.Tag, 1, 1), "T", TextCompare: true) == 0) & Versioned.IsNumeric(Strings.Mid(val8.Tag, 2, Strings.Len(val8.Tag)))))
								{
									sTerm += ";";
									int num = 1;
									string text = "";
									int num2 = Strings.Len(sTerm);
									for (int i = 1; i <= num2; i++)
									{
										string text2 = Strings.Mid(sTerm, i, 1);
										if (Operators.CompareString(text2, ";", TextCompare: true) != 0)
										{
											text += text2;
											continue;
										}
										if (num == Conversions.ToInteger(Strings.Mid(val8.Tag, 2, Strings.Len(val8.Tag))))
										{
											break;
										}
										text = "";
										num++;
									}
									((DBObject)val8).UpgradeOpen();
									if (Operators.CompareString(text, "", TextCompare: true) == 0)
									{
										text = "?";
									}
									((DBText)val8).TextString = text;
								}
								((DBText)val8).AdjustAlignment(database);
								((Entity)val8).Draw();
							}
						}
					}
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError((Exception)ex);
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

	public static string LeUmAtributoDeUmBloco(ref string sHandle, string sAttributo)
	{
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Expected Obj, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected Obj, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected Obj, but got Unknown
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected Obj, but got Unknown
		string result = "";
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				ObjectId val4 = Geral.HandleToID(sHandle);
				if (val4.IsValid)
				{
					Entity val5 = (Entity)val2.GetObject(val4, (OpenMode)0);
					if (val5 != null)
					{
						BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
						AttributeCollection attributeCollection = val6.AttributeCollection;
						foreach (object item in attributeCollection)
						{
							ObjectId val7 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							AttributeReference val8 = (AttributeReference)val7.GetObject((OpenMode)0);
							if (Operators.CompareString(val8.Tag.ToUpper(), sAttributo.ToUpper(), TextCompare: true) == 0)
							{
								result = ((DBText)val8).TextString;
								break;
							}
						}
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
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
		return result;
	}

	public static void IndefineCruzamentoDoBloco(ref string sHandle)
	{
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected Obj, but got Unknown
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				ObjectId val4 = Geral.HandleToID(sHandle);
				if (val4.IsValid && val4.IsValid)
				{
					Entity val5 = (Entity)val2.GetObject(val4, (OpenMode)0);
					if (val5 != null)
					{
						BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
						AttributeCollection attributeCollection = val6.AttributeCollection;
						foreach (object item in attributeCollection)
						{
							ObjectId val7 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							AttributeReference val8 = (AttributeReference)val7.GetObject((OpenMode)1);
							string tag = val8.Tag;
							if (Operators.CompareString(tag, "ORIGEM", TextCompare: true) == 0 || Operators.CompareString(tag, "INSERCAO", TextCompare: true) == 0 || Operators.CompareString(tag, "INSERCAONA", TextCompare: true) == 0 || Operators.CompareString(tag, "INSERCAONF", TextCompare: true) == 0)
							{
								((DBObject)val8).UpgradeOpen();
								((DBText)val8).TextString = "";
								((DBText)val8).AdjustAlignment(database);
								((Entity)val8).Draw();
							}
						}
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
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

	public static void EditaUmTexto(ref string sHandle, string sValor)
	{
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				ObjectId val4 = Geral.HandleToID(sHandle);
				if (val4.IsValid)
				{
					Entity val5 = (Entity)val2.GetObject(val4, (OpenMode)0);
					if (val5 != null)
					{
						DBText val6 = (DBText)(object)((val5 is DBText) ? val5 : null);
						if (val6 != null)
						{
							((DBObject)val6).UpgradeOpen();
							val6.TextString = sValor;
						}
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
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

	public static bool ExisteAtributo(string sHandle, string sAtributo)
	{
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Expected Obj, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected Obj, but got Unknown
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected Obj, but got Unknown
		bool result = false;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				ObjectId val4 = Geral.HandleToID(sHandle);
				if (val4.IsValid)
				{
					Entity val5 = (Entity)val2.GetObject(val4, (OpenMode)0);
					if (val5 != null)
					{
						BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
						AttributeCollection attributeCollection = val6.AttributeCollection;
						foreach (object item in attributeCollection)
						{
							ObjectId val7 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							AttributeReference val8 = (AttributeReference)val7.GetObject((OpenMode)1);
							if (Operators.CompareString(val8.Tag.ToUpper(), sAtributo.ToUpper(), TextCompare: true) == 0)
							{
								result = true;
								break;
							}
						}
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
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
		return result;
	}

	public static bool AtributoVisivel(string sHandle, string sAtributo)
	{
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Expected Obj, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected Obj, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected Obj, but got Unknown
		bool result = false;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				ObjectId val4 = Geral.HandleToID(sHandle);
				if (val4.IsValid)
				{
					Entity val5 = (Entity)val2.GetObject(val4, (OpenMode)0);
					if (val5 != null)
					{
						BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
						AttributeCollection attributeCollection = val6.AttributeCollection;
						foreach (object item in attributeCollection)
						{
							ObjectId val7 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							AttributeReference val8 = (AttributeReference)val7.GetObject((OpenMode)1);
							if (Operators.CompareString(val8.Tag.ToUpper(), sAtributo.ToUpper(), TextCompare: true) == 0)
							{
								result = ((Entity)val8).Visible;
								break;
							}
						}
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
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
		return result;
	}

	public static bool LimpaAtributoInvisivel(string sHandle)
	{
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected Obj, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected Obj, but got Unknown
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected Obj, but got Unknown
		bool result = false;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				ObjectId val4 = Geral.HandleToID(sHandle);
				if (val4.IsValid)
				{
					Entity val5 = (Entity)val2.GetObject(val4, (OpenMode)0);
					if (val5 != null)
					{
						BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
						AttributeCollection attributeCollection = val6.AttributeCollection;
						foreach (object item in attributeCollection)
						{
							ObjectId val7 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							AttributeReference val8 = (AttributeReference)val7.GetObject((OpenMode)1);
							if (!((Entity)val8).Visible)
							{
								((DBObject)val8).UpgradeOpen();
								((DBText)val8).TextString = "";
								((DBObject)val8).DowngradeOpen();
							}
						}
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
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
		return result;
	}

	public static void AtributoVisivelInvidivel(ref string sHandle, string sAttributo, bool bliga)
	{
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected Obj, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				Entity val4 = (Entity)Geral.HandleToObject(sHandle);
				if (val4 != null)
				{
					BlockReference val5 = (BlockReference)(object)((val4 is BlockReference) ? val4 : null);
					AttributeCollection attributeCollection = val5.AttributeCollection;
					foreach (object item in attributeCollection)
					{
						ObjectId val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
						AttributeReference val7 = (AttributeReference)val6.GetObject((OpenMode)1);
						if (Operators.CompareString(val7.Tag.ToUpper(), sAttributo.ToUpper(), TextCompare: true) == 0)
						{
							((DBObject)val7).UpgradeOpen();
							((Entity)val7).Visible = bliga;
							break;
						}
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
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

	public static void InsereOsBlocos(ref DataGridView dg)
	{
		checked
		{
			int num = dg.RowCount - 1;
			for (int i = 0; i <= num; i++)
			{
				string value = insereUmBloco(dg.Rows[i].Cells[0].Value.ToString(), dg.Rows[i].Cells[1].Value.ToString());
				dg.Rows[i].Cells[2].Value = value;
			}
		}
	}

	public static void removeOsBlocos(ref DataGridView dg)
	{
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected Obj, but got Unknown
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
						_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
						int num = dg.RowCount - 1;
						for (int i = 0; i <= num; i++)
						{
							ObjectId val4 = Geral.HandleToID(dg.Rows[i].Cells[2].Value.ToString());
							if (val4.IsValid)
							{
								Entity val5 = (Entity)val2.GetObject(val4, (OpenMode)0);
								if (val5 != null)
								{
									((DBObject)val5).UpgradeOpen();
									((DBObject)val5).Erase();
								}
							}
						}
						DeclaracoesGeral.bAnularEventos = true;
						val2.Commit();
						DeclaracoesGeral.bAnularEventos = false;
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError((Exception)ex);
						val2.Abort();
						ProjectData.ClearProjectError();
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
	}

	public static void AtivaHighlightDispP(ref DeclaracoesEntidades.StructureDispositivo Disp, string sHandle)
	{
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Expected Obj, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected Obj, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected Obj, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected Obj, but got Unknown
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		try
		{
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
							BlockReference val5 = (BlockReference)(object)((ent is BlockReference) ? ent : null);
							if (val5 == null)
							{
								continue;
							}
							string tipoImportado = "";
							string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
							if (Operators.CompareString(left, "P", TextCompare: true) != 0)
							{
								continue;
							}
							BlockReference blockRef = (BlockReference)ent;
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
							ent = (Entity)(object)blockRef;
							DeclaracoesEntidades.StructureDispositivo structureDispositivo = ((obj == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj));
							if (!((structureDispositivo.Painel == Disp.Painel) & (Operators.CompareString(structureDispositivo.Nome1, Disp.Nome1, TextCompare: true) == 0) & (Operators.CompareString(structureDispositivo.Nome2, Disp.Nome2, TextCompare: true) == 0) & (Operators.CompareString(structureDispositivo.Alternativo, Disp.Alternativo, TextCompare: true) == 0)))
							{
								continue;
							}
							if (Disp.Complementar)
							{
								if (Operators.CompareString(((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString(), sHandle, TextCompare: true) == 0)
								{
									ent.Highlight();
								}
							}
							else
							{
								ent.Highlight();
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
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError((Exception)ex);
			ProjectData.ClearProjectError();
		}
	}

	public static void Unhighlight()
	{
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected Obj, but got Unknown
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected Obj, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected Obj, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected Obj, but got Unknown
		try
		{
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
							if (Operators.CompareString(val5.Layer.ToString(), DeclaracoesGeral.ativo.Pagina, TextCompare: true) == 0)
							{
								val5.Unhighlight();
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
				catch (Exception ex)
				{
					ProjectData.SetProjectError((Exception)ex);
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
		catch (Exception ex2)
		{
			ProjectData.SetProjectError((Exception)ex2);
			ProjectData.ClearProjectError();
		}
	}

	public static string TipoBlocoDoEletron(ref BlockReference blockRef, ref string sNomeBloco)
	{
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Expected Obj, but got Unknown
		string result = "";
		PointMonitorToolTips.StopMonitor();
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				_ = Application.DocumentManager.MdiActiveDocument.Database;
				_ = Application.DocumentManager.MdiActiveDocument.Editor;
				try
				{
					int num = 0;
					if (!Information.IsDBNull(blockRef) && ((DBObject)blockRef).XData != (ResultBuffer)null)
					{
						sNomeBloco = blockRef.Name;
						string text = ((DBObject)blockRef).XData.ToString();
						string[] array = text.Split(')');
						string[] array2 = null;
						int num2 = Information.UBound(array);
						for (int i = 0; i <= num2; i++)
						{
							if (Operators.CompareString(array[i].ToString().Trim(), "", TextCompare: true) != 0)
							{
								array2 = array[i].Split('(');
								array[i] = array2[Information.UBound(array2)];
								array2 = array[i].Split(',');
								array[i] = array2[Information.UBound(array2)];
								num++;
							}
							if (num == 3)
							{
								break;
							}
							if (Versioned.IsNumeric(array[i]))
							{
								continue;
							}
							if (num == 1)
							{
								string left = array[i].ToUpper();
								if (Operators.CompareString(left, "MODELO", TextCompare: true) == 0 || Operators.CompareString(left, "DINTERLIG", TextCompare: true) == 0 || Operators.CompareString(left, "ARANHA", TextCompare: true) == 0 || Operators.CompareString(left, "LAYOUT", TextCompare: true) == 0 || Operators.CompareString(left, "IMPORTADO", TextCompare: true) == 0 || Operators.CompareString(left, "TOPOGRAFICO", TextCompare: true) == 0 || Operators.CompareString(left, "DISP_FUNCAO", TextCompare: true) == 0)
								{
									result = blockRef.Name;
									break;
								}
							}
							if (num == 2 && ((Operators.CompareString(array[i], "A", TextCompare: true) == 0) | (Operators.CompareString(array[i], "B", TextCompare: true) == 0) | (Operators.CompareString(array[i], "E", TextCompare: true) == 0) | (Operators.CompareString(array[i], "P", TextCompare: true) == 0) | (Operators.CompareString(array[i], "M", TextCompare: true) == 0) | (Operators.CompareString(array[i].ToUpper(), "MODELO", TextCompare: true) == 0) | (Operators.CompareString(array[i].ToUpper(), "REVISAOAUTOMATICA", TextCompare: true) == 0)))
							{
								result = array[i];
								break;
							}
						}
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError((Exception)ex);
					ProjectData.ClearProjectError();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			PointMonitorToolTips.StartMonitor();
			return result;
		}
	}

	public static string BuscaNomeDoBloco(string sCaminho)
	{
		string text = "";
		string[] array = sCaminho.Split('\\');
		checked
		{
			if (Information.UBound(array) > 0)
			{
				text = array[Information.UBound(array)];
				array = text.Split('.');
				if (Information.UBound(array) > 0)
				{
					if (Information.UBound(array) != 1)
					{
						text = "";
						int num = Information.UBound(array) - 1;
						for (int i = 0; i <= num; i++)
						{
							if (Operators.CompareString(text, "", TextCompare: true) != 0)
							{
								text += ".";
							}
							text += array[i];
						}
					}
					else
					{
						text = array[0];
					}
				}
			}
			return text;
		}
	}

	public static string selecionaUmBlocoDaSimbologia(string sFiltro)
	{
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected Obj, but got Unknown
		string result = "";
		using (OpenFileDialog openFileDialog = new OpenFileDialog())
		{
			OpenFileDialog openFileDialog2 = openFileDialog;
			openFileDialog2.AddExtension = true;
			openFileDialog2.CheckFileExists = true;
			openFileDialog2.CheckPathExists = true;
			openFileDialog2.FilterIndex = 0;
			if (Operators.CompareString(sFiltro, "", TextCompare: true) != 0)
			{
				openFileDialog2.Filter = "AutoCAD DWG (*.dwg)|*" + sFiltro + "*dwg";
			}
			else
			{
				openFileDialog2.Filter = "AutoCAD DWG (*.dwg)|*.dwg";
			}
			openFileDialog2.RestoreDirectory = true;
			openFileDialog2.Multiselect = false;
			openFileDialog2.Title = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 327]);
			openFileDialog2 = null;
			openFileDialog.InitialDirectory = DeclaracoesGeral.Conf.DirSimbologiaEletrica;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					result = openFileDialog.FileName;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError((Exception)ex);
					ProjectData.ClearProjectError();
				}
			}
		}
		return result;
	}

	public static void selecionaVariosBlocos(string sFiltro, List<string> lNomeBlocosSel, ref DataGridView dg)
	{
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Expected Obj, but got Unknown
		string text = "";
		lNomeBlocosSel.Clear();
		checked
		{
			using OpenFileDialog openFileDialog = new OpenFileDialog();
			OpenFileDialog openFileDialog2 = openFileDialog;
			openFileDialog2.AddExtension = true;
			openFileDialog2.CheckFileExists = true;
			openFileDialog2.CheckPathExists = true;
			openFileDialog2.FilterIndex = 0;
			if (Operators.CompareString(sFiltro, "", TextCompare: true) != 0)
			{
				openFileDialog2.Filter = "AutoCAD DWG (*.dwg)|*" + sFiltro + "*dwg";
			}
			else
			{
				openFileDialog2.Filter = "AutoCAD DWG (*.dwg)|*.dwg";
			}
			openFileDialog2.InitialDirectory = DeclaracoesGeral.Conf.DirSimbologiaEletrica;
			openFileDialog2.Multiselect = true;
			openFileDialog2.Title = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1608]);
			openFileDialog2 = null;
			if (openFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			try
			{
				int num = openFileDialog.FileNames.Length - 1;
				for (int i = 0; i <= num; i++)
				{
					text = BuscaNomeDoBloco(openFileDialog.FileNames[i]);
					text = text.ToUpper();
					dg.Rows.Add(openFileDialog.FileNames[i], text);
					if (!lNomeBlocosSel.Contains(text))
					{
						lNomeBlocosSel.Add(text);
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static string insereUmBloco(string sCaminhoBloco, string sNomeDoBloco)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Expected Obj, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected Obj, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected Obj, but got Unknown
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Expected Obj, but got Unknown
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Expected Obj, but got Unknown
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Expected Obj, but got Unknown
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Expected Obj, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Expected Obj, but got Unknown
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Expected Obj, but got Unknown
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Unknown result type (might be due to invalid IL or missing references)
		ObjectId val = ObjectId.Null;
		string result = "";
		Point3d val2 = new Point3d(0.0, 0.0, 0.0);
		DocumentLock val3 = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			_ = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val4 = database.TransactionManager.StartTransaction();
			try
			{
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				val2 = new Point3d(0.0, 0.0, 0.0);
				try
				{
					BlockTable val5 = (BlockTable)val4.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val6 = (BlockTableRecord)val4.GetObject(((SymbolTable)val5)[BlockTableRecord.ModelSpace], (OpenMode)1);
					val2 = new Point3d(0.0, 0.0, 0.0);
					Database val7 = new Database(false, true);
					val7.ReadDwgFile(sCaminhoBloco, FileShare.Read, true, "");
					DeclaracoesGeral.bAnularEventos = true;
					val = database.Insert(sNomeDoBloco, val7, false);
					((DisposableWrapper)val7).Dispose();
					if (Caderno.ExisteFormato() && (DeclaracoesGeral.blockFormatoID.IsValid & !DeclaracoesGeral.blockFormatoID.IsErased))
					{
						_ = val4.GetObject(DeclaracoesGeral.blockFormatoID, (OpenMode)0) is BlockReference;
						Caderno.ZEntity(DeclaracoesGeral.blockFormatoID);
					}
					BlockReference val8 = new BlockReference(val2, val);
					((Entity)val8).Layer = "0";
					val6.AppendEntity((Entity)(object)val8);
					DeclaracoesGeral.bAnularEventos = true;
					val4.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
					((Entity)val8).Draw();
					BlockTableRecord val9 = null;
					val9 = (BlockTableRecord)val4.GetObject(val, (OpenMode)0);
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val9.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val10 = (Entity)val4.GetObject(current, (OpenMode)0);
							if (val10 is AttributeDefinition)
							{
								AttributeDefinition val11 = (AttributeDefinition)val10;
								AttributeReference val12 = new AttributeReference();
								val12.SetAttributeFromBlock(val11, val8.BlockTransform);
								((DBText)val12).TextString = val11.Tag.ToString();
								((DBText)val12).AdjustAlignment(database);
								val8.AttributeCollection.AppendAttribute(val12);
								DeclaracoesGeral.bAnularEventos = true;
								val4.AddNewlyCreatedDBObject((DBObject)(object)val12, true);
								((Entity)val12).Draw();
							}
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
					((Entity)val8).Draw();
					result = ((object)((DBObject)val8).Handle/*cast due to constrained. prefix*/).ToString();
					DeclaracoesGeral.bAnularEventos = true;
					val4.Commit();
					DeclaracoesGeral.bAnularEventos = false;
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError((Exception)ex);
					val4.Abort();
					ProjectData.ClearProjectError();
				}
				finally
				{
				}
			}
			finally
			{
				((IDisposable)val4)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val3)?.Dispose();
		}
		return result;
	}

	public static void ExecutaATTSYNC(ref DataGridView dg)
	{
		checked
		{
			int num = dg.RowCount - 1;
			for (int i = 0; i <= num; i++)
			{
				string text = Conversions.ToString(dg.Rows[i].Cells[1].Value);
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				mdiActiveDocument.SendStringToExecute("_.attsync Name " + text + "\n", true, false, true);
			}
		}
	}

	public static void ExecutaATTSYNC_UmBloco(ref string s1)
	{
		string text = s1;
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		mdiActiveDocument.SendStringToExecute("_.attsync Name " + text + "\n", true, false, true);
	}

	public static void MostraBloco(string sHandle, bool bZoom = true, int dAproximacao = 20)
	{
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected Obj, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected Obj, but got Unknown
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		Unhighlight();
		Application.UpdateScreen();
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				ObjectId val4 = Geral.HandleToID(sHandle);
				if (val4.IsValid)
				{
					Entity val5 = (Entity)val2.GetObject(val4, (OpenMode)1);
					if (val5 != null)
					{
						Pagina.AtivaPagina(val5.Layer);
						uscPaginas uscPagina = DeclaracoesGeral._uscPagina;
						string pag = val5.Layer.ToString();
						uscPagina.ativaPaginaAtalho(ref pag);
						if (bZoom)
						{
							Caderno.ZEntity(((DBObject)val5).ObjectId, dAproximacao);
						}
						val5.Highlight();
						Application.UpdateScreen();
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
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

	public static void OcultaAtributos(ref string sHandle, ref clsBornesInterligAuto.mAtt[] mAtt)
	{
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected Obj, but got Unknown
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected Obj, but got Unknown
		int num = 0;
		mAtt = new clsBornesInterligAuto.mAtt[1];
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
					_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					Entity val4 = (Entity)Geral.HandleToObject(sHandle);
					if (val4 != null)
					{
						BlockReference val5 = (BlockReference)(object)((val4 is BlockReference) ? val4 : null);
						AttributeCollection attributeCollection = val5.AttributeCollection;
						foreach (object item in attributeCollection)
						{
							ObjectId val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							AttributeReference val7 = (AttributeReference)val6.GetObject((OpenMode)1);
							mAtt = (clsBornesInterligAuto.mAtt[])Utils.CopyArray(mAtt, new clsBornesInterligAuto.mAtt[num + 1]);
							mAtt[num].Att = val7.Tag;
							mAtt[num].Valor = ((DBText)val7).TextString;
							num++;
							((DBText)val7).TextString = "";
							((DBText)val7).AdjustAlignment(database);
							((Entity)val7).Draw();
						}
					}
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError((Exception)ex);
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

	public static void DesOcultaAtributos(ref string sHandle, ref clsBornesInterligAuto.mAtt[] mAtt)
	{
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected Obj, but got Unknown
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				Entity val4 = (Entity)Geral.HandleToObject(sHandle);
				if (val4 != null)
				{
					BlockReference val5 = (BlockReference)(object)((val4 is BlockReference) ? val4 : null);
					AttributeCollection attributeCollection = val5.AttributeCollection;
					foreach (object item in attributeCollection)
					{
						ObjectId val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
						AttributeReference val7 = (AttributeReference)val6.GetObject((OpenMode)1);
						int num = Information.UBound(mAtt);
						for (int i = 0; i <= num; i = checked(i + 1))
						{
							if (Operators.CompareString(mAtt[i].Att, val7.Tag, TextCompare: true) == 0)
							{
								((DBText)val7).TextString = mAtt[i].Valor;
								((DBText)val7).AdjustAlignment(database);
								((Entity)val7).Draw();
							}
						}
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
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

	public static void EditaNomesDeUmBlocoDodispositivoPM(ref string sHandle, string sNome1, string sNome2, string sAlternativo)
	{
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected Obj, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected Obj, but got Unknown
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				Entity val4 = (Entity)Geral.HandleToObject(sHandle);
				if (val4 != null)
				{
					BlockReference val5 = (BlockReference)(object)((val4 is BlockReference) ? val4 : null);
					AttributeCollection attributeCollection = val5.AttributeCollection;
					bool flag = false;
					ObjectId val6;
					foreach (object item in attributeCollection)
					{
						val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
						AttributeReference val7 = (AttributeReference)val6.GetObject((OpenMode)1);
						if (Operators.CompareString(val7.Tag, "NOME1", TextCompare: true) != 0)
						{
						}
						if (Operators.CompareString(val7.Tag, "NOME2", TextCompare: true) == 0)
						{
							flag = true;
						}
					}
					if (!flag && Operators.CompareString(sNome2, "", TextCompare: true) != 0)
					{
						sNome1 = sNome1 + "/" + sNome2;
						sNome2 = "";
					}
					foreach (object item2 in attributeCollection)
					{
						val6 = ((item2 == null) ? default(ObjectId) : ((ObjectId)item2));
						AttributeReference val7 = (AttributeReference)val6.GetObject((OpenMode)1);
						string left = val7.Tag.ToUpper();
						if (Operators.CompareString(left, "NOME1", TextCompare: true) != 0)
						{
							if (Operators.CompareString(left, "NOME2", TextCompare: true) != 0)
							{
								if (Operators.CompareString(left, "ALTERNATIVO", TextCompare: true) == 0)
								{
									((DBObject)val7).UpgradeOpen();
									((DBText)val7).TextString = sAlternativo;
									((DBText)val7).AdjustAlignment(database);
									((Entity)val7).Draw();
								}
							}
							else
							{
								((DBObject)val7).UpgradeOpen();
								((DBText)val7).TextString = sNome2;
								((DBText)val7).AdjustAlignment(database);
								((Entity)val7).Draw();
							}
						}
						else
						{
							((DBObject)val7).UpgradeOpen();
							((DBText)val7).TextString = sNome1;
							((DBText)val7).AdjustAlignment(database);
							((Entity)val7).Draw();
						}
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
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

	public static void VerificaDuplicados(ref StructureErros[] MErros, bool bProgress = true)
	{
		//IL_0a63: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a69: Expected Obj, but got Unknown
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected Obj, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected Obj, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected Obj, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected Obj, but got Unknown
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ae: Expected Obj, but got Unknown
		//IL_044b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0452: Expected Obj, but got Unknown
		//IL_0983: Unknown result type (might be due to invalid IL or missing references)
		//IL_098a: Expected Obj, but got Unknown
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Expected Obj, but got Unknown
		//IL_05cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d2: Expected Obj, but got Unknown
		//IL_0a0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a11: Expected Obj, but got Unknown
		//IL_09af: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_0389: Expected Obj, but got Unknown
		//IL_03f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0602: Unknown result type (might be due to invalid IL or missing references)
		//IL_0609: Expected Obj, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Expected Obj, but got Unknown
		//IL_0570: Unknown result type (might be due to invalid IL or missing references)
		//IL_0575: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bc: Expected Obj, but got Unknown
		//IL_0724: Unknown result type (might be due to invalid IL or missing references)
		//IL_0729: Unknown result type (might be due to invalid IL or missing references)
		//IL_0853: Unknown result type (might be due to invalid IL or missing references)
		//IL_0858: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08fe: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		MErros = new StructureErros[1];
		List<string> list = new List<string>();
		DeclaracoesEntidades.StructureBorne structureBorne = default;
		if (bProgress)
		{
			DeclaracoesGeral._uscPagina.Quantidade = 6;
			DeclaracoesGeral._uscPagina.pbIniciar();
		}
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
						BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
						BlockTableRecordEnumerator enumerator = default;
						try
						{
							enumerator = val4.GetEnumerator();
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.Current;
								Entity ent = (Entity)val2.GetObject(current, (OpenMode)0);
								BlockReference blockRef = (BlockReference)(object)((ent is BlockReference) ? ent : null);
								if (blockRef != null)
								{
									string tipoImportado = "";
									string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
									string left = text;
									if (Operators.CompareString(left, "A", TextCompare: true) != 0)
									{
										if (Operators.CompareString(left, "B", TextCompare: true) != 0)
										{
											unchecked
											{
												if (Operators.CompareString(left, "E", TextCompare: true) != 0)
												{
													if (Operators.CompareString(left, "P", TextCompare: true) != 0)
													{
														if (Operators.CompareString(left, "M", TextCompare: true) == 0)
														{
															BlockReference blockRef2 = (BlockReference)ent;
															object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef2);
															ent = (Entity)(object)blockRef2;
															object obj2 = obj;
															DeclaracoesEntidades.StructureMascara structureMascara = ((obj2 == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj2));
															string item = Conversions.ToString((int)structureMascara.Painel) + "_" + structureMascara.Nome1 + "_" + structureMascara.Nome2 + "_" + structureMascara.Alternativo;
															if (!structureMascara.Complementar)
															{
																if (!list.Contains(item))
																{
																	list.Add(item);
																}
																else
																{
																	checked
																	{
																		num++;
																		MErros = (StructureErros[])Utils.CopyArray(MErros, new StructureErros[num + 1]);
																	}
																	MErros[num].iPainel = Conversions.ToString((int)structureMascara.Painel);
																	MErros[num].sHandle = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
																	MErros[num].sPagina = ent.Layer;
																	MErros[num].sTipo = DeclaracoesGeral.mMensagem[1, 524].ToString().ToUpper();
																}
															}
														}
													}
													else
													{
														object obj3 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
														DeclaracoesEntidades.StructureDispositivo structureDispositivo = ((obj3 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj3));
														string item2 = Conversions.ToString((int)structureDispositivo.Painel) + "_" + structureDispositivo.Nome1 + "_" + structureDispositivo.Nome2 + "_" + structureDispositivo.Alternativo;
														if (!structureDispositivo.Complementar)
														{
															if (!list.Contains(item2))
															{
																list.Add(item2);
															}
															else
															{
																checked
																{
																	num++;
																	MErros = (StructureErros[])Utils.CopyArray(MErros, new StructureErros[num + 1]);
																}
																MErros[num].iPainel = Conversions.ToString((int)structureDispositivo.Painel);
																MErros[num].sHandle = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
																MErros[num].sPagina = ent.Layer;
																MErros[num].sTipo = DeclaracoesGeral.mMensagem[1, 625].ToString().ToUpper();
															}
														}
													}
												}
												else
												{
													BlockReference blockRef2 = (BlockReference)ent;
													object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef2);
													ent = (Entity)(object)blockRef2;
													object obj4 = obj;
													DeclaracoesEntidades.StructurePortas structurePortas = ((obj4 == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj4));
													DeclaracoesEntidades.StructureMascara structureMascara2 = default;
													Entity val5 = (Entity)Geral.HandleToObject(structurePortas.HandleDaMascara);
													if (val5 != null)
													{
														blockRef2 = (BlockReference)val5;
														obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef2);
														val5 = (Entity)(object)blockRef2;
														object obj5 = obj;
														structureMascara2 = ((obj5 == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj5));
													}
													if (structurePortas.indiceDaPorta > 0)
													{
														string item3 = Conversions.ToString((int)structureMascara2.Painel) + "_" + structureMascara2.Nome1 + "_" + structureMascara2.Nome2 + "_" + structureMascara2.Alternativo + "_" + Conversions.ToString(structurePortas.indiceDaPorta);
														if (!list.Contains(item3))
														{
															list.Add(item3);
														}
														else
														{
															checked
															{
																num++;
																MErros = (StructureErros[])Utils.CopyArray(MErros, new StructureErros[num + 1]);
															}
															MErros[num].iPainel = Conversions.ToString((int)structureMascara2.Painel);
															MErros[num].sHandle = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
															MErros[num].sPagina = ent.Layer;
															MErros[num].sTipo = DeclaracoesGeral.mMensagem[1, 750].ToString().ToUpper();
														}
													}
												}
											}
										}
										else
										{
											BlockReference blockRef2 = (BlockReference)ent;
											object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef2);
											ent = (Entity)(object)blockRef2;
											object obj6 = obj;
											structureBorne = ((obj6 == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj6));
											structureBorne.indexPainel = DicionarioBorne.BuscaPainelDoBorneNoDicionario(ref structureBorne.IndiceRegua, ref structureBorne.NomeRegua, ref structureBorne.Alternativo);
											string item4 = Conversions.ToString(structureBorne.indexPainel) + "_" + Conversions.ToString(structureBorne.IndiceRegua) + "_" + structureBorne.Numero;
											if (!list.Contains(item4))
											{
												list.Add(item4);
											}
											else if (!((Operators.CompareString(structureBorne.Numero.ToString(), DeclaracoesGeral.Conf.CaracterTerminalIndefinido, TextCompare: true) == 0) | (Operators.CompareString(structureBorne.Numero.ToString(), "0", TextCompare: true) == 0)))
											{
												num++;
												MErros = (StructureErros[])Utils.CopyArray(MErros, new StructureErros[num + 1]);
												MErros[num].iPainel = Conversions.ToString(structureBorne.indexPainel);
												MErros[num].sHandle = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
												MErros[num].sPagina = ent.Layer;
												MErros[num].sTipo = DeclaracoesGeral.mMensagem[1, 1429].ToString().ToUpper();
											}
										}
									}
									else
									{
										BlockReference blockRef2 = (BlockReference)ent;
										object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef2);
										ent = (Entity)(object)blockRef2;
										object obj7 = obj;
										DeclaracoesEntidades.StructureAuxiliar structureAuxiliar = ((obj7 == null) ? default(DeclaracoesEntidades.StructureAuxiliar) : ((DeclaracoesEntidades.StructureAuxiliar)obj7));
										DeclaracoesEntidades.StructureDispositivo structureDispositivo2 = default;
										Entity val6 = (Entity)Geral.HandleToObject(structureAuxiliar.HandleBob);
										if (val6 != null)
										{
											blockRef2 = (BlockReference)val6;
											obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef2);
											val6 = (Entity)(object)blockRef2;
											object obj8 = obj;
											structureDispositivo2 = ((obj8 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj8));
										}
										string item5 = Conversions.ToString(unchecked((int)structureDispositivo2.Painel)) + "_" + structureDispositivo2.Nome1 + "_" + structureDispositivo2.Nome2 + "_" + structureDispositivo2.Alternativo + "_" + Conversions.ToString(structureAuxiliar.IndexContato);
										if (!list.Contains(item5))
										{
											list.Add(item5);
										}
										else
										{
											num++;
											MErros = (StructureErros[])Utils.CopyArray(MErros, new StructureErros[num + 1]);
											MErros[num].iPainel = Conversions.ToString(structureBorne.indexPainel);
											MErros[num].sHandle = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
											MErros[num].sPagina = ent.Layer;
											MErros[num].sTipo = DeclaracoesGeral.mMensagem[1, 500].ToString().ToUpper();
										}
									}
								}
								DBText val7 = (DBText)(object)((ent is DBText) ? ent : null);
								if (val7 == null)
								{
									continue;
								}
								DeclaracoesEntidades.StructureDefinicaoPortas Def = new DeclaracoesEntidades.StructureDefinicaoPortas
								{
									Nome = ""
								};
								Entity Ent = (Entity)(object)val7;
								XDataDispositivosMaster.LerXDataDefinicao(ref Ent, ref Def);
								val7 = (DBText)Ent;
								if (Operators.CompareString(Def.Nome.ToUpper(), "DEFINICAO", TextCompare: true) != 0)
								{
									continue;
								}
								string item6 = Def.HandleDaMascara + "_" + Conversions.ToString(Def.indiceDoModelo) + "_" + Conversions.ToString(Def.indiceDaPorta);
								if (!list.Contains(item6))
								{
									list.Add(item6);
									continue;
								}
								num++;
								MErros = (StructureErros[])Utils.CopyArray(MErros, new StructureErros[num + 1]);
								int num2 = 0;
								DeclaracoesEntidades.StructureMascara structureMascara3 = default;
								Entity val8 = (Entity)Geral.HandleToObject(Def.HandleDaMascara);
								if (val8 != null)
								{
									BlockReference blockRef2 = (BlockReference)val8;
									object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef2);
									val8 = (Entity)(object)blockRef2;
									object obj9 = obj;
									num2 = ((obj9 == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj9)).Painel;
								}
								MErros[num].iPainel = Conversions.ToString(num2);
								MErros[num].sHandle = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
								MErros[num].sPagina = ent.Layer;
								MErros[num].sTipo = DeclaracoesGeral.mMensagem[1, 521].ToString().ToUpper();
							}
						}
						finally
						{
							((IDisposable)enumerator)?.Dispose();
						}
						if (bProgress)
						{
							DeclaracoesGeral._uscPagina.pbPasso();
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError((Exception)ex);
						ProjectData.ClearProjectError();
					}
					finally
					{
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
			if (bProgress)
			{
				DeclaracoesGeral._uscPagina.pbFim();
			}
		}
	}

	public static Point3d retornaUmPonto()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected Obj, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected Obj, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Invalid comparison between Unknown and I4
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		Point3d result = default;
		PointMonitorToolTips.StopMonitor();
		try
		{
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			PromptPointResult val = (PromptPointResult)NewLateBinding.LateGet(editor, null, "GetPoint", new object[1] { Operators.ConcatenateObject("\r\n", DeclaracoesGeral.mMensagem[1, 1691]) }, null, null, null);
			if ((int)((PromptResult)val).Status != -5002)
			{
				Point3d value = val.Value;
				double x = value.X;
				value = val.Value;
				result = new Point3d(x, value.Y, 0.0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError((Exception)ex);
			throw;
		}
		PointMonitorToolTips.StartMonitor();
		return result;
	}

	public static void movePosicaoDoBloco(ref string sHandle, double dx, double dy)
	{
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected Obj, but got Unknown
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				Entity val4 = (Entity)Geral.HandleToObject(sHandle);
				if (val4 != null)
				{
					Point3d val5 = new Point3d(0.0, 0.0, 0.0);
					Vector3d vectorTo = val5.GetVectorTo(new Point3d(dx, dy, 0.0));
					((DBObject)val4).UpgradeOpen();
					val4.TransformBy(Matrix3d.Displacement(vectorTo));
					((DBObject)val4).DowngradeOpen();
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
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

	public static bool VerificaDocumetoValidoParaColar()
	{
		bool result = true;
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		if (Operators.CompareString(DeclaracoesGeral.sDocumentoclip, mdiActiveDocument.Name, TextCompare: true) != 0)
		{
			result = false;
		}
		return result;
	}
}

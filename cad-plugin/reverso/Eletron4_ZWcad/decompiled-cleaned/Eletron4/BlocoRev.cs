using System;
using System.Collections.Generic;
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

public class BlocoRev
{
	public void CriarBlocoRev(string sRev, int iCorSel, double dAltFonte)
	{
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected Obj, but got Unknown
		//IL_00e3: Expected Obj, but got Unknown
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Expected Obj, but got Unknown
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Invalid comparison between Unknown and I4
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected Obj, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected Obj, but got Unknown
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected Obj, but got Unknown
		PointMonitorToolTips.StopMonitor();
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			_ = Point3d.Origin;
			ObjectId val2 = CriarDefinicaoBlocoRevisao(sRev, iCorSel, dAltFonte);
			BlockReference val3;
			while (true)
			{
				val3 = new BlockReference(Point3d.Origin, val2);
				((Entity)val3).Layer = DeclaracoesGeral.ativo.Pagina;
				Jig jig = new Jig((Entity)(object)val3);
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				PromptResult val4 = editor.Drag((Jig)(object)jig);
				PromptStatus status = val4.Status;
				if ((int)status != 5100)
				{
					break;
				}
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val5 = database.TransactionManager.StartTransaction();
				try
				{
					BlockTable val6 = (BlockTable)val5.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val7 = (BlockTableRecord)val5.GetObject(((SymbolTable)val6)[BlockTableRecord.ModelSpace], (OpenMode)1);
					((Entity)val3).Layer = DeclaracoesGeral.ativo.Pagina;
					val7.AppendEntity((Entity)(object)val3);
					DeclaracoesGeral.bAnularEventos = true;
					val5.AddNewlyCreatedDBObject((DBObject)(object)val3, true);
					Entity ent = (Entity)(object)val3;
					XDataGeral.gravarXDataRevisaoAutomatica(ref ent, sRev, iCorSel);
					val3 = (BlockReference)ent;
					DeclaracoesGeral.bAnularEventos = true;
					val5.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError((Exception)ex);
					Exception ex2 = ex;
					Interaction.MsgBox(((Exception)(object)ex2).Message, MsgBoxStyle.Information);
					val5.Abort();
					ProjectData.ClearProjectError();
				}
				finally
				{
					((IDisposable)val5)?.Dispose();
				}
			}
			((DisposableWrapper)val3).Dispose();
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		PointMonitorToolTips.StartMonitor();
	}

	public ObjectId CriarDefinicaoBlocoRevisao(string sRev, int iCorSel, double dAltFonte)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected Obj, but got Unknown
		//IL_0439: Unknown result type (might be due to invalid IL or missing references)
		//IL_043e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected Obj, but got Unknown
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected Obj, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Expected Obj, but got Unknown
		//IL_047a: Unknown result type (might be due to invalid IL or missing references)
		//IL_047b: Unknown result type (might be due to invalid IL or missing references)
		//IL_047d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Unknown result type (might be due to invalid IL or missing references)
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_0330: Expected Obj, but got Unknown
		//IL_0339: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Expected Obj, but got Unknown
		//IL_0375: Unknown result type (might be due to invalid IL or missing references)
		//IL_0391: Unknown result type (might be due to invalid IL or missing references)
		//IL_03af: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0405: Unknown result type (might be due to invalid IL or missing references)
		//IL_040a: Unknown result type (might be due to invalid IL or missing references)
		ObjectId result = ObjectId.Null;
		DeclaracoesGeral.bAnularEventos = true;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			try
			{
				string text = BuscaNomeBlocoREV(sRev);
				if (Operators.CompareString(text, "", TextCompare: true) == 0)
				{
					text = "REV_" + Conversions.ToString(Conversions.ToDouble(BuscaProximoIndiceRevisao()) + 1.0);
				}
				new Point3d(0.0, 0.0, 0.0);
				BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
				if (!((SymbolTable)val2).Has(text))
				{
					BlockTableRecord val3 = new BlockTableRecord();
					((SymbolTableRecord)val3).Name = text;
					((DBObject)val2).UpgradeOpen();
					((SymbolTable)val2).Add((SymbolTableRecord)(object)val3);
					DeclaracoesGeral.bAnularEventos = true;
					val.AddNewlyCreatedDBObject((DBObject)(object)val3, true);
					double num = 0.55;
					Point2d val4 = new Point2d(0.0, -1.8);
					Point2d val5 = new Point2d(3.964, -1.8);
					Point2d val6 = new Point2d(4.105, -1.555);
					Point2d val7 = new Point2d(2.1255, 1.875);
					Point2d val8 = new Point2d(1.8355, 1.875);
					Point2d val9 = new Point2d(-0.14, -1.555);
					Point2d val10 = new Point2d(0.0, -1.8);
					Polyline val11 = new Polyline();
					((Entity)val11).SetDatabaseDefaults();
					((Entity)val11).Linetype = "Continuous";
					((Entity)val11).ColorIndex = iCorSel;
					((Entity)val11).Layer = "0";
					((Entity)val11).LineWeight = (LineWeight)9;
					val11.AddVertexAt(0, val4, 0.0, 0.0, 0.0);
					val11.AddVertexAt(1, val5, 0.0, 0.0, 0.0);
					val11.AddVertexAt(2, val6, 0.0, 0.0, 0.0);
					val11.AddVertexAt(3, val7, 0.0, 0.0, 0.0);
					val11.AddVertexAt(4, val8, 0.0, 0.0, 0.0);
					val11.AddVertexAt(5, val9, 0.0, 0.0, 0.0);
					val11.AddVertexAt(6, val10, 0.0, 0.0, 0.0);
					val11.SetBulgeAt(1, num);
					val11.SetBulgeAt(3, num);
					val11.SetBulgeAt(5, num);
					Vector3d val12 = default;
					((Entity)val11).TransformBy(Matrix3d.Displacement(val12));
					val3.AppendEntity((Entity)(object)val11);
					DeclaracoesGeral.bAnularEventos = true;
					val.AddNewlyCreatedDBObject((DBObject)(object)val11, true);
					TextStyleTable val13 = (TextStyleTable)val.GetObject(database.TextStyleTableId, (OpenMode)0);
					try
					{
						ObjectId val14 = (((SymbolTable)val13).Has("Romans") ? ((SymbolTable)val13)["Romans"] : ((SymbolTable)val13)["Standard"]);
						TextStyleTableRecord val15 = (TextStyleTableRecord)val.GetObject(val14, (OpenMode)0);
						double xScale = val15.XScale;
						DBText val16 = new DBText();
						try
						{
							val16.TextString = sRev;
							val16.HorizontalMode = (TextHorizontalMode)4;
							val16.VerticalMode = (TextVerticalMode)2;
							val16.AlignmentPoint = new Point3d(2.0, -0.9, 0.0);
							((Entity)val16).ColorIndex = iCorSel;
							val16.Height = dAltFonte;
							val16.TextStyleId = val14;
							val16.WidthFactor = xScale;
							((Entity)val16).Layer = "0";
							((Entity)val16).TransformBy(Matrix3d.Displacement(val12));
							val3.AppendEntity((Entity)(object)val16);
							DeclaracoesGeral.bAnularEventos = true;
							val.AddNewlyCreatedDBObject((DBObject)(object)val16, true);
						}
						finally
						{
							((IDisposable)val16)?.Dispose();
						}
					}
					finally
					{
						((IDisposable)val13)?.Dispose();
					}
					result = ((DBObject)val3).ObjectId;
				}
				else
				{
					result = ((SymbolTable)val2)[text];
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
				DeclaracoesGeral.bAnularEventos = false;
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		return result;
	}

	public static string BuscaProximoIndiceRevisao()
	{
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Obj, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected Obj, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected Obj, but got Unknown
		int num = 1;
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
						Entity ent = (Entity)val2.GetObject(current, (OpenMode)0);
						string rev = "";
						int iCor = 1;
						if (!XDataGeral.LeXDataRevisaoAutomatica(ref ent, ref rev, ref iCor))
						{
							continue;
						}
						BlockReference val5 = (BlockReference)(object)((ent is BlockReference) ? ent : null);
						if (val5 == null || list.Contains(val5.Name))
						{
							continue;
						}
						list.Add(val5.Name);
						string name = val5.Name;
						name = name.Replace("REV_", "");
						if (Versioned.IsNumeric(name))
						{
							if (Conversions.ToDouble(name) == 0.0)
							{
								num = 1;
							}
							else if (!Versioned.IsNumeric(name))
							{
								num = 1;
							}
							else if (Conversions.ToDouble(name) >= (double)num)
							{
								num = Conversions.ToInteger(name);
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
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
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
		return num.ToString();
	}

	public static string BuscaNomeBlocoREV(string sRevSel)
	{
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected Obj, but got Unknown
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
		string result = "";
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
						string rev = "";
						int iCor = 1;
						if (XDataGeral.LeXDataRevisaoAutomatica(ref ent, ref rev, ref iCor))
						{
							BlockReference val5 = (BlockReference)(object)((ent is BlockReference) ? ent : null);
							if (val5 != null && Operators.CompareString(sRevSel, rev, TextCompare: true) == 0 && Operators.CompareString(val5.Name.ToUpper(), "REVISAO", TextCompare: true) != 0)
							{
								result = val5.Name;
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
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
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
		return result;
	}
}

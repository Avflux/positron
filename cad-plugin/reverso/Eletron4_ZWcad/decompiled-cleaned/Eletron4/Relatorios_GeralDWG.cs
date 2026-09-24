using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;

namespace Eletron4;

public class Relatorios_GeralDWG
{
	public static object CapturaOsTextStyle()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		object result = null;
		_ = Application.DocumentManager.MdiActiveDocument;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			string[] array = new string[1] { "" };
			result = array;
			DBObject val2 = val.GetObject(database.TextStyleTableId, (OpenMode)0);
			TextStyleTable val3 = (TextStyleTable)(object)((val2 is TextStyleTable) ? val2 : null);
			try
			{
				SymbolTableEnumerator enumerator = default;
				try
				{
					enumerator = ((SymbolTable)val3).GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						DBObject val4 = val.GetObject(current, (OpenMode)0);
						TextStyleTableRecord val5 = (TextStyleTableRecord)(object)((val4 is TextStyleTableRecord) ? val4 : null);
						_ = ((SymbolTableRecord)val5).Name;
						if (Operators.CompareString(((SymbolTableRecord)val5).Name.Trim(), "", TextCompare: true) != 0)
						{
							array = (string[])Utils.CopyArray(array, new string[checked(Information.UBound(array) + 1 + 1)]);
							array[Information.UBound(array)] = ((SymbolTableRecord)val5).Name;
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val3)?.Dispose();
			}
			DeclaracoesGeral.bAnularEventos = true;
			val.Commit();
			DeclaracoesGeral.bAnularEventos = false;
			result = array;
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
		return result;
	}

	public static void criarJumperHatch(string sTipodoRelatorio, string tipo, Point3d pt, double Altura, double Largura, string layer, string sDisp, int iPN, Declaracoes2.ConfRelatorio ConfRelFiacao)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02da: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected Obj, but got Unknown
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Expected Obj, but got Unknown
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Expected Obj, but got Unknown
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		//IL_031d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0322: Unknown result type (might be due to invalid IL or missing references)
		//IL_033f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0344: Unknown result type (might be due to invalid IL or missing references)
		//IL_036d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0372: Unknown result type (might be due to invalid IL or missing references)
		//IL_039b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			BlockTable val = (BlockTable)topTransaction.GetObject(database.BlockTableId, (OpenMode)0);
			BlockTableRecord val2 = (BlockTableRecord)topTransaction.GetObject(((SymbolTable)val)[BlockTableRecord.ModelSpace], (OpenMode)1);
			Largura /= 3.0;
			Point2d val3 = new Point2d(pt.X, pt.Y);
			Point2d val4 = default;
			Point2d val5 = default;
			Point2d val6 = default;
			Point2d val7 = default;
			if (Operators.CompareString(tipo, "C", TextCompare: true) != 0)
			{
				if (Operators.CompareString(tipo, "B", TextCompare: true) == 0)
				{
					val3 = new Point2d(pt.X, pt.Y - Altura / 2.0);
					val4 = new Point2d(val3.X - Largura / 2.0, val3.Y);
					val5 = new Point2d(val3.X + Largura / 2.0, val3.Y);
					val6 = new Point2d(val3.X - Largura / 2.0, val3.Y + Altura / 2.0);
					val7 = new Point2d(val3.X + Largura / 2.0, val3.Y + Altura / 2.0);
				}
			}
			else
			{
				val4 = new Point2d(val3.X - Largura / 2.0, val3.Y);
				val5 = new Point2d(val3.X + Largura / 2.0, val3.Y);
				val6 = new Point2d(val3.X - Largura / 2.0, val3.Y + Altura / 2.0);
				val7 = new Point2d(val3.X + Largura / 2.0, val3.Y + Altura / 2.0);
			}
			Polyline val8 = new Polyline();
			((Entity)val8).SetDatabaseDefaults();
			val8.AddVertexAt(0, val4, 0.0, 0.0, 0.0);
			val8.AddVertexAt(1, val5, 0.0, 0.0, 0.0);
			val8.AddVertexAt(2, val7, 0.0, 0.0, 0.0);
			val8.AddVertexAt(3, val6, 0.0, 0.0, 0.0);
			val8.AddVertexAt(4, val4, 0.0, 0.0, 0.0);
			((Entity)val8).ColorIndex = 1;
			((Entity)val8).Layer = layer;
			((Entity)val8).LineWeight = (LineWeight)40;
			((Entity)val8).SetDatabaseDefaults();
			val2.AppendEntity((Entity)(object)val8);
			DeclaracoesGeral.bAnularEventos = true;
			topTransaction.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
			ObjectIdCollection val9 = new ObjectIdCollection();
			val9.Add(((DBObject)val8).ObjectId);
			Hatch val10 = new Hatch();
			try
			{
				val2.AppendEntity((Entity)(object)val10);
				DeclaracoesGeral.bAnularEventos = true;
				topTransaction.AddNewlyCreatedDBObject((DBObject)(object)val10, true);
				((Entity)val10).SetDatabaseDefaults();
				((Entity)val10).ColorIndex = ConfRelFiacao.CorDoJumper;
				((Entity)val10).LineWeight = (LineWeight)9;
				((Entity)val10).Layer = layer;
				val10.SetHatchPattern((HatchPatternType)1, "SOLID");
				val10.Associative = true;
				val10.AppendLoop((HatchLoopTypes)16, val9);
				val10.EvaluateHatch(true);
				((DBObject)val8).Erase();
				Entity Ent = (Entity)(object)val10;
				XDataRelatorio.GravarXDataFiacao(ref Ent, sTipodoRelatorio, iPN);
			}
			finally
			{
				((IDisposable)val10)?.Dispose();
			}
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
	}

	public static void criarCirculoDoBorne(string sTipoDoRelatorio, Point3d pt, double Largura, string layer, bool bHatchCirculo, string sDisp, int iPN, Declaracoes2.ConfRelatorio ConfRelFiacao)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected Obj, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected Obj, but got Unknown
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected Obj, but got Unknown
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			BlockTable val = (BlockTable)topTransaction.GetObject(database.BlockTableId, (OpenMode)0);
			BlockTableRecord val2 = (BlockTableRecord)topTransaction.GetObject(((SymbolTable)val)[BlockTableRecord.ModelSpace], (OpenMode)1);
			Circle val3 = new Circle();
			try
			{
				((Entity)val3).SetDatabaseDefaults();
				val3.Center = pt;
				val3.Radius = Largura / 6.0;
				((Entity)val3).ColorIndex = ConfRelFiacao.CorLinha;
				val2.AppendEntity((Entity)(object)val3);
				DeclaracoesGeral.bAnularEventos = true;
				topTransaction.AddNewlyCreatedDBObject((DBObject)(object)val3, true);
				Entity Ent = (Entity)(object)val3;
				XDataRelatorio.GravarXDataFiacao(ref Ent, sTipoDoRelatorio, iPN);
				if (bHatchCirculo)
				{
					ObjectIdCollection val4 = new ObjectIdCollection();
					val4.Add(((DBObject)val3).ObjectId);
					Hatch val5 = new Hatch();
					try
					{
						val2.AppendEntity((Entity)(object)val5);
						DeclaracoesGeral.bAnularEventos = true;
						topTransaction.AddNewlyCreatedDBObject((DBObject)(object)val5, true);
						((Entity)val5).SetDatabaseDefaults();
						((Entity)val5).ColorIndex = ConfRelFiacao.CorDoJumper;
						((Entity)val5).LineWeight = (LineWeight)9;
						((Entity)val5).Layer = layer;
						val5.SetHatchPattern((HatchPatternType)1, "SOLID");
						val5.Associative = true;
						val5.AppendLoop((HatchLoopTypes)16, val4);
						val5.EvaluateHatch(true);
						((DBObject)val3).Erase();
						Ent = (Entity)(object)val5;
						XDataRelatorio.GravarXDataFiacao(ref Ent, sTipoDoRelatorio, iPN);
						return;
					}
					finally
					{
						((IDisposable)val5)?.Dispose();
					}
				}
			}
			finally
			{
				((IDisposable)val3)?.Dispose();
			}
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
	}
}

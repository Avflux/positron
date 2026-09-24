using System;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.Runtime;

namespace Eletron4;

public class clsENEL
{
	public static string ReinsereAuxInterligaENEL_SP(string sHandleLN)
	{
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected Obj, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected Obj, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected Obj, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected Obj, but got Unknown
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				Entity val5 = (Entity)Geral.HandleToObject(sHandleLN);
				if (val5 != null)
				{
					Polyline pl = (Polyline)(object)((val5 is Polyline) ? val5 : null);
					if (pl != null)
					{
						DeclaracoesEntidades.StructureInterligacao ilig = default;
						if (XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig))
						{
							DBText val6 = criarTextoNomeCaboENEL_SP(pl, "", DeclaracoesGeral.ativo.Pagina);
							val4.AppendEntity((Entity)(object)val6);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)val6, true);
							Entity ent = (Entity)(object)val6;
							XDataInterligacao.GravarXDataAuxInterligacao(ref ent, ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString(), 3, "", "FU#");
							val6 = (DBText)ent;
							result = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
							((Entity)val6).Layer = ((Entity)pl).Layer;
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

	public static DBText criarTextoNomeCaboENEL_SP(Polyline pl, string texto, string layer)
	{
		//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bd: Expected Obj, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected Obj, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		//IL_0296: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0358: Unknown result type (might be due to invalid IL or missing references)
		//IL_035d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0393: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
		double num = Math.Round(Math.PI, 2);
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Database database = mdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		DBText val2;
		try
		{
			TextStyleTable val = (TextStyleTable)topTransaction.GetObject(database.TextStyleTableId, (OpenMode)0);
			ObjectId textStyleId = (((SymbolTable)val).Has("Romans") ? ((SymbolTable)val)["Romans"] : ((SymbolTable)val)["Standard"]);
			val2 = new DBText();
			Point3d point3dAt;
			Point3d point3dAt2;
			if (pl.NumberOfVertices != 2)
			{
				if (pl.NumberOfVertices != 3)
				{
					if (pl.NumberOfVertices != 4)
					{
						point3dAt = pl.GetPoint3dAt(0);
						point3dAt2 = pl.GetPoint3dAt(1);
					}
					else
					{
						point3dAt = pl.GetPoint3dAt(1);
						point3dAt2 = pl.GetPoint3dAt(2);
					}
				}
				else
				{
					point3dAt = pl.GetPoint3dAt(0);
					point3dAt2 = pl.GetPoint3dAt(1);
					double num2 = point3dAt.DistanceTo(point3dAt2);
					point3dAt = pl.GetPoint3dAt(1);
					point3dAt2 = pl.GetPoint3dAt(2);
					double num3 = point3dAt.DistanceTo(point3dAt2);
					if (!(num2 > num3))
					{
						point3dAt = pl.GetPoint3dAt(1);
						point3dAt2 = pl.GetPoint3dAt(2);
					}
					else
					{
						point3dAt = pl.GetPoint3dAt(0);
						point3dAt2 = pl.GetPoint3dAt(1);
					}
				}
			}
			else
			{
				point3dAt = pl.GetPoint3dAt(0);
				point3dAt2 = pl.GetPoint3dAt(1);
			}
			double num4 = point3dAt.DistanceTo(point3dAt2) / 2.0;
			double num5 = 1.0;
			double x = point3dAt2.X - point3dAt.X;
			double y = point3dAt2.Y - point3dAt.Y;
			double num6 = Math.Round(Math.Atan2(y, x), 2);
			x = 0.0;
			y = 0.0;
			double rotation;
			if (!((num6 <= num / 2.0) & (num6 > num / 2.0 * -1.0)))
			{
				val2.VerticalMode = (TextVerticalMode)1;
				val2.HorizontalMode = (TextHorizontalMode)1;
				rotation = num6 - Math.PI;
				x += 4.0;
			}
			else
			{
				val2.VerticalMode = (TextVerticalMode)1;
				val2.HorizontalMode = (TextHorizontalMode)1;
				rotation = num6;
				y -= 4.0;
			}
			double num7 = num4 * Math.Cos(num6);
			double num8 = num4 * Math.Sin(num6);
			double num9 = num5 * Math.Cos(Math.PI / 2.0 - num6);
			double num10 = num5 * Math.Sin(Math.PI / 2.0 - num6);
			if (num10 < 0.0)
			{
				num10 *= -1.0;
			}
			if (num6 == num / 2.0)
			{
				num9 *= -1.0;
			}
			if (((num6 > 0.0) & (num6 < num / 2.0)) | ((num6 < 0.0) & (num6 > num / 2.0 * -1.0)))
			{
				num9 *= -1.0;
			}
			Point3d alignmentPoint = new Point3d(point3dAt.X + num7 + num9 + x, point3dAt.Y + num8 + num10 + y, 0.0);
			((Entity)val2).ColorIndex = DeclaracoesGeral.Conf.CorTextoInterligacao;
			((Entity)val2).Layer = layer;
			val2.TextString = texto;
			val2.Height = DeclaracoesGeral.Conf.FonteCabos;
			val2.TextStyleId = textStyleId;
			((Entity)val2).LineWeight = (LineWeight)9;
			val2.AlignmentPoint = alignmentPoint;
			val2.Rotation = rotation;
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
		return val2;
	}
}

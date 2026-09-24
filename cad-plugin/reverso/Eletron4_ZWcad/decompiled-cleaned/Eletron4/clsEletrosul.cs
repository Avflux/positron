using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.Runtime;

namespace Eletron4;

public class clsEletrosul
{
	[CommandMethod("RecriaTextosCaboEletrosul")]
	public static void RecriaTextosCaboEletrosul(bool bApaga = false)
	{
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected Obj, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected Obj, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected Obj, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected Obj, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		clsEletron.ApagarTodosOsTextosDasVeias(bApaga);
		List<string> sCaboSingelos = new List<string>();
		CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
		cDadosAccessInterligacao3.CaboSingelo(ref sCaboSingelos);
		cDadosAccessInterligacao3.FechaConexao();
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
							Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
							Polyline pl = (Polyline)(object)((val5 is Polyline) ? val5 : null);
							if (pl == null)
							{
								continue;
							}
							DeclaracoesEntidades.StructureInterligacao ilig = default;
							if (!XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig))
							{
								continue;
							}
							string sHandle = reinsereAuxInterligEletrosul(((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString());
							string text = "";
							if (Operators.CompareString(ilig.NomeVeia.Trim(), "", TextCompare: true) == 0)
							{
								if (ilig.NumVeia != -1000)
								{
									text = ilig.NumVeia.ToString();
									if (ilig.ocultaTag == 0)
									{
										text = ilig.Tag_Cabo + DeclaracoesGeral.Conf.SeparadorCaboVeia + text;
									}
									if (ilig.NumVeia == 1 && sCaboSingelos.Contains(ilig.Tag_Cabo))
									{
										text = ilig.Tag_Cabo;
									}
								}
								else if (ilig.ocultaTag == 0)
								{
									text = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
								}
							}
							else
							{
								text = "(" + ilig.NomeVeia + ")";
								if (ilig.ocultaTag == 0)
								{
									text = ilig.Tag_Cabo + " " + text;
								}
							}
							ilig.iModeloVeiaFuncao = 1;
							((DBObject)pl).UpgradeOpen();
							XDataInterligacao.AtualizaXDataInterligacao(ref pl, ref ilig);
							clsTextos.AtualizaUmTexto(sHandle, text);
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

	public static string reinsereAuxInterligEletrosul(string sHandleLN)
	{
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Expected Obj, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected Obj, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected Obj, but got Unknown
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected Obj, but got Unknown
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
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
							DBText val6 = criarTextoNomeCaboEletrosul(pl, DeclaracoesGeral.Conf.CaracterTerminalIndefinido, DeclaracoesGeral.ativo.Pagina);
							((Entity)val6).Layer = ((Entity)pl).Layer;
							val4.AppendEntity((Entity)(object)val6);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)val6, true);
							Entity ent = (Entity)(object)val6;
							XDataInterligacao.GravarXDataAuxInterligacao(ref ent, ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString(), 1, "");
							val6 = (DBText)ent;
							result = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
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

	public static DBText criarTextoNomeCaboEletrosul(Polyline pl, string texto, string layer)
	{
		//IL_0441: Unknown result type (might be due to invalid IL or missing references)
		//IL_0447: Expected Obj, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected Obj, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0302: Unknown result type (might be due to invalid IL or missing references)
		//IL_0307: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		//IL_0428: Unknown result type (might be due to invalid IL or missing references)
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
			string sRotaHV = "V";
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
						if (Math.Round(point3dAt.X, 2) == Math.Round(point3dAt2.X, 2))
						{
							sRotaHV = "H";
						}
					}
					else
					{
						point3dAt = pl.GetPoint3dAt(1);
						point3dAt2 = pl.GetPoint3dAt(2);
						if (Math.Round(point3dAt.X, 2) == Math.Round(point3dAt2.X, 2))
						{
							sRotaHV = "H";
						}
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
					if (Math.Round(point3dAt.X, 2) == Math.Round(point3dAt2.X, 2))
					{
						sRotaHV = "H";
					}
				}
			}
			else
			{
				point3dAt = pl.GetPoint3dAt(0);
				point3dAt2 = pl.GetPoint3dAt(1);
				if (Math.Round(point3dAt.X, 2) == Math.Round(point3dAt2.X, 2))
				{
					sRotaHV = "H";
				}
			}
			double num4 = point3dAt.DistanceTo(point3dAt2) / 2.0;
			double num5 = 0.0;
			double x = point3dAt2.X - point3dAt.X;
			double y = point3dAt2.Y - point3dAt.Y;
			double num6 = Math.Round(Math.Atan2(y, x), 2);
			if (!((num6 <= num / 2.0) & (num6 > num / 2.0 * -1.0)))
			{
				val2.VerticalMode = (TextVerticalMode)1;
				val2.HorizontalMode = (TextHorizontalMode)0;
			}
			else
			{
				val2.VerticalMode = (TextVerticalMode)1;
				val2.HorizontalMode = (TextHorizontalMode)0;
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
			Point3d mCenterPt = new Point3d(point3dAt.X + num7 + num9, point3dAt.Y + num8 + num10, 0.0);
			AdicionaCaboEletrosul(ref mCenterPt, ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString(), sRotaHV, ((Entity)pl).Layer);
			((Entity)val2).ColorIndex = DeclaracoesGeral.Conf.CorTextoInterligacao;
			((Entity)val2).Layer = layer;
			val2.TextString = texto;
			val2.Height = DeclaracoesGeral.Conf.FonteCabos;
			val2.TextStyleId = textStyleId;
			((Entity)val2).LineWeight = (LineWeight)9;
			val2.AlignmentPoint = mCenterPt;
			val2.Rotation = 0.0;
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

	public static void AdicionaCaboEletrosul(ref Point3d mCenterPt, string sHandle, string sRotaHV, string sLayer)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Obj, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected Obj, but got Unknown
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Unknown result type (might be due to invalid IL or missing references)
		//IL_033b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Unknown result type (might be due to invalid IL or missing references)
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_0367: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Expected Obj, but got Unknown
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Expected Obj, but got Unknown
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Expected Obj, but got Unknown
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03aa: Unknown result type (might be due to invalid IL or missing references)
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Database database = mdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
			BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)1);
			double num = Math.PI * 2.0;
			Vector3d ucsxdir = database.Ucsxdir;
			Vector3d ucsydir = database.Ucsydir;
			Vector3d val4 = ucsxdir.CrossProduct(ucsydir);
			val4.GetNormal();
			Vector3d val5 = new Vector3d(1.0, 0.0, 0.0);
			if (Operators.CompareString(sRotaHV, "V", TextCompare: true) == 0)
			{
				val5 = new Vector3d(0.0, 1.0, 0.0);
			}
			Ellipse val6 = new Ellipse(mCenterPt, Vector3d.ZAxis, val5, 0.6, 0.0, num);
			((Entity)val6).SetDatabaseDefaults();
			((Entity)val6).ColorIndex = DeclaracoesGeral.Conf.CorInterligacao;
			((Entity)val6).Layer = sLayer;
			val3.AppendEntity((Entity)(object)val6);
			val.AddNewlyCreatedDBObject((DBObject)(object)val6, true);
			Point2d val7 = new Point2d(mCenterPt.X + 1.0, mCenterPt.Y);
			Point2d val8 = new Point2d(mCenterPt.X + 2.0, mCenterPt.Y);
			Point2d val9 = new Point2d(mCenterPt.X + 2.0, mCenterPt.Y);
			if (Operators.CompareString(sRotaHV, "V", TextCompare: true) == 0)
			{
				val7 = new Point2d(mCenterPt.X, mCenterPt.Y + 1.0);
				val8 = new Point2d(mCenterPt.X, mCenterPt.Y + 2.0);
				val9 = new Point2d(mCenterPt.X + 1.0, mCenterPt.Y + 2.0);
			}
			Polyline val10 = new Polyline();
			((Entity)val10).SetDatabaseDefaults();
			((Entity)val10).ColorIndex = DeclaracoesGeral.Conf.CorInterligacao;
			((Entity)val10).Linetype = DeclaracoesGeral.Conf.EstiloLinha;
			((Entity)val10).LinetypeScale = DeclaracoesGeral.Conf.EstiloLinhaEscala;
			val10.AddVertexAt(0, val7, 0.0, 0.0, 0.0);
			val10.AddVertexAt(1, val8, 0.0, 0.0, 0.0);
			val10.AddVertexAt(2, val9, 0.0, 0.0, 0.0);
			((Entity)val10).Layer = sLayer;
			val3.AppendEntity((Entity)(object)val10);
			val.AddNewlyCreatedDBObject((DBObject)(object)val10, true);
			Entity ent = (Entity)(object)val6;
			XDataInterligacao.GravarXDataAuxInterligacaoEletrosul(ref ent, sHandle, 0, "");
			val6 = (Ellipse)ent;
			ent = (Entity)(object)val10;
			XDataInterligacao.GravarXDataAuxInterligacaoEletrosul(ref ent, sHandle, 0, "");
			val10 = (Polyline)ent;
			DeclaracoesGeral.bAnularEventos = true;
			val.Commit();
			DeclaracoesGeral.bAnularEventos = false;
			mCenterPt = new Point3d(val8.X + 1.0, val8.Y - DeclaracoesGeral.Conf.FonteCabos * 0.85, 0.0);
			if (Operators.CompareString(sRotaHV, "V", TextCompare: true) == 0)
			{
				mCenterPt = new Point3d(val8.X + 2.0, val8.Y - DeclaracoesGeral.Conf.FonteCabos * 0.85, 0.0);
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void AtualizaCorTodasVeiasEletrosulElipseLinha()
	{
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected Obj, but got Unknown
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
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)1);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val4.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity ent = (Entity)val2.GetObject(current, (OpenMode)1);
						string sHandle = "";
						if (XDataInterligacao.lerXDataAuxInterligacaoEletrosul(ref ent, ref sHandle))
						{
							ent.ColorIndex = DeclaracoesGeral.Conf.CorInterligacao;
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
}

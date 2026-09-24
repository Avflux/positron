using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.GraphicsInterface;
using ZwSoft.ZwCAD.Runtime;

namespace Eletron4;

public class Relatorios_FurnasDWG
{
	public static void CriarRelatorioRevisaoFurnasDWG(double dOrdenadaY, double dOrdenadax, double dFim)
	{
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		DeclaracoesGeral.Reguas RH = default;
		XDataGeral.LeXDataReguaH(ref RH);
		if (Caderno.ExisteFormato())
		{
			Caderno.ZEntity(DeclaracoesGeral.blockFormatoID);
		}
		Revisao.capturaRevisoesSimplificadas();
		string pag = Pagina.retornaNumeroCapa();
		Pagina.AtivaPagina(pag);
		DeclaracoesGeral._uscPagina.ativaPaginaAtalho(ref pag);
		Point3d pt = new Point3d(dOrdenadax, dOrdenadaY, 0.0);
		double num = dFim - dOrdenadax - 2.0;
		double value = num / 12.5;
		value = Math.Round(value, 0);
		double num2 = num / Math.Round(value, 0);
		double num3 = 6.5;
		ApagaRelatorioFURNAS();
		checked
		{
			try
			{
				bool flag = false;
				CriaTabela_Titulo_FURNAS(pag, num + 2.0, num3, ref pt, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1863]));
				int num4 = 1;
				int num5 = 0;
				do
				{
					int num6 = (int)Math.Round(value - 1.0);
					for (int i = 0; i <= num6; i++)
					{
						if (num4 > Information.UBound(DeclaracoesGeral.mRevSimplificada, 2))
						{
							flag = true;
							if (i == 0)
							{
								break;
							}
						}
						if (i != 0)
						{
							if (num4 > Information.UBound(DeclaracoesGeral.mRevSimplificada, 2))
							{
								CriaTabela_Celula_FURNAS(pag, num2, num3, ref pt, "##B##", "##B##");
								flag = true;
							}
							else
							{
								CriaTabela_Celula_FURNAS(pag, num2, num3, ref pt, Conversions.ToString(DeclaracoesGeral.mRevSimplificada[0, num4]), Conversions.ToString(DeclaracoesGeral.mRevSimplificada[1, num4]));
								num4++;
							}
						}
						else
						{
							CriaTabela_Celula_FURNAS(pag, num2 + 2.0, num3, ref pt, Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 287], " Nº")), Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 380], " Nº")));
						}
					}
					if (!flag)
					{
						pt = new Point3d(dOrdenadax, pt.Y - num3 * 2.0, 0.0);
						num5++;
						continue;
					}
					break;
				}
				while (num5 <= 100);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void CriaTabela_Titulo_FURNAS(string sLayer, double dLarguraDoBloco, double AlturaDoBloco, ref Point3d pt, string sTit)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected Obj, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected Obj, but got Unknown
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected Obj, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Expected Obj, but got Unknown
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Expected Obj, but got Unknown
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_033b: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				TextStyleTable val3 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)0);
				_ = ((SymbolTable)val3)["romans"];
				new DBObjectCollection();
				BlockTable val4 = (BlockTable)val2.GetObject(mdiActiveDocument.Database.BlockTableId, (OpenMode)0);
				BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)1);
				double num = 0.0;
				double num2 = 0.0;
				Dicionario.CriaTableStyleRelatorios("romans", 0.1, 0.1);
				Table val6 = new Table();
				((Entity)val6).Layer = sLayer;
				val6.SetSize(1, 1);
				val6.GenerateLayout();
				val6.RecomputeTableBlock(true);
				((BlockReference)val6).Position = pt;
				val6.Columns[0].Width = dLarguraDoBloco;
				val6.SetRowHeight(AlturaDoBloco);
				((CellRange)val6.Cells[0, 0]).TextHeight = 1.5;
				val6.Cells[0, 0].TextString = sTit;
				((CellRange)val6.Cells[0, 0]).Alignment = (CellAlignment)5;
				((Entity)val6).ColorIndex = 7;
				DeclaracoesGeral.bAnularEventos = true;
				val6.TableStyle = database.Tablestyle;
				DeclaracoesGeral.bAnularEventos = false;
				val6.GenerateLayout();
				val5.AppendEntity((Entity)(object)val6);
				DeclaracoesGeral.bAnularEventos = true;
				val2.AddNewlyCreatedDBObject((DBObject)(object)val6, true);
				val6.RecomputeTableBlock(true);
				Extents3d value = ((Drawable)val6).Bounds.Value;
				Point3d minPoint = value.MinPoint;
				num2 = minPoint.Y;
				value = ((Drawable)val6).Bounds.Value;
				minPoint = value.MinPoint;
				num = minPoint.X;
				Application.UpdateScreen();
				DBObjectCollection val7 = new DBObjectCollection();
				DeclaracoesGeral.bAnularEventos = true;
				val6.TableStyle = database.Tablestyle;
				DeclaracoesGeral.bAnularEventos = false;
				((Entity)val6).Explode(val7);
				((DBObject)val6).Erase();
				foreach (Entity item in val7)
				{
					Entity Ent = item;
					MText val8 = (MText)(object)((Ent is MText) ? Ent : null);
					try
					{
						if (val8 != null && Operators.CompareString(val8.Text, "##B##", TextCompare: true) != 0)
						{
							((Entity)val8).ColorIndex = 7;
							((Entity)val8).Layer = DeclaracoesGeral.ativo.Pagina;
							val5.AppendEntity((Entity)(object)val8);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
							Entity Ent2 = (Entity)(object)val8;
							XDataRelatorio.GravarXDataFurnas(ref Ent2, 0);
						}
					}
					finally
					{
						((IDisposable)val8)?.Dispose();
					}
					Line val9 = (Line)(object)((Ent is Line) ? Ent : null);
					try
					{
						if (val9 != null)
						{
							Ent.Layer = DeclaracoesGeral.ativo.Pagina;
							val5.AppendEntity(Ent);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)Ent, true);
							XDataRelatorio.GravarXDataFurnas(ref Ent, 0);
						}
					}
					finally
					{
						((IDisposable)val9)?.Dispose();
					}
					((DisposableWrapper)Ent).Dispose();
				}
				pt = new Point3d(num, num2, 0.0);
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
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

	public static void CriaTabela_Celula_FURNAS(string sLayer, double dLarguraDoBloco, double AlturaDoBloco, ref Point3d pt, string sPG, string sRev)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected Obj, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected Obj, but got Unknown
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected Obj, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Expected Obj, but got Unknown
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Expected Obj, but got Unknown
		//IL_03a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0343: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				TextStyleTable val3 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)0);
				_ = ((SymbolTable)val3)["romans"];
				new DBObjectCollection();
				BlockTable val4 = (BlockTable)val2.GetObject(mdiActiveDocument.Database.BlockTableId, (OpenMode)0);
				BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)1);
				double num = 0.0;
				double num2 = 0.0;
				Dicionario.CriaTableStyleRelatorios("romans", 0.1, 0.1);
				Table val6 = new Table();
				((Entity)val6).Layer = sLayer;
				val6.SetSize(2, 1);
				val6.GenerateLayout();
				val6.RecomputeTableBlock(true);
				((BlockReference)val6).Position = pt;
				val6.Columns[0].Width = dLarguraDoBloco;
				val6.SetRowHeight(AlturaDoBloco);
				((CellRange)val6.Cells[0, 0]).TextHeight = 2.0;
				((CellRange)val6.Cells[1, 0]).TextHeight = 2.0;
				val6.Cells[0, 0].TextString = sPG;
				((CellRange)val6.Cells[0, 0]).Alignment = (CellAlignment)5;
				val6.Cells[1, 0].TextString = sRev;
				((CellRange)val6.Cells[1, 0]).Alignment = (CellAlignment)5;
				((Entity)val6).ColorIndex = 7;
				DeclaracoesGeral.bAnularEventos = true;
				val6.TableStyle = database.Tablestyle;
				DeclaracoesGeral.bAnularEventos = false;
				val6.GenerateLayout();
				val5.AppendEntity((Entity)(object)val6);
				DeclaracoesGeral.bAnularEventos = true;
				val2.AddNewlyCreatedDBObject((DBObject)(object)val6, true);
				val6.RecomputeTableBlock(true);
				Extents3d value = ((Drawable)val6).Bounds.Value;
				Point3d maxPoint = value.MaxPoint;
				num2 = maxPoint.Y;
				value = ((Drawable)val6).Bounds.Value;
				maxPoint = value.MaxPoint;
				num = maxPoint.X;
				Application.UpdateScreen();
				DBObjectCollection val7 = new DBObjectCollection();
				DeclaracoesGeral.bAnularEventos = true;
				val6.TableStyle = database.Tablestyle;
				DeclaracoesGeral.bAnularEventos = false;
				((Entity)val6).Explode(val7);
				((DBObject)val6).Erase();
				foreach (Entity item in val7)
				{
					Entity Ent = item;
					MText val8 = (MText)(object)((Ent is MText) ? Ent : null);
					try
					{
						if (val8 != null && Operators.CompareString(val8.Text, "##B##", TextCompare: true) != 0)
						{
							((Entity)val8).ColorIndex = 7;
							((Entity)val8).Layer = DeclaracoesGeral.ativo.Pagina;
							val5.AppendEntity((Entity)(object)val8);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
							if (Operators.CompareString(sPG, val8.Text, TextCompare: true) != 0)
							{
								Entity Ent2 = (Entity)(object)val8;
								XDataRelatorio.GravarXDataFurnas(ref Ent2, 0);
							}
							else
							{
								Entity Ent2 = (Entity)(object)val8;
								XDataRelatorio.GravarXDataFurnas(ref Ent2, 1);
							}
						}
					}
					finally
					{
						((IDisposable)val8)?.Dispose();
					}
					Line val9 = (Line)(object)((Ent is Line) ? Ent : null);
					try
					{
						if (val9 != null)
						{
							Ent.Layer = DeclaracoesGeral.ativo.Pagina;
							val5.AppendEntity(Ent);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)Ent, true);
							XDataRelatorio.GravarXDataFurnas(ref Ent, 0);
						}
					}
					finally
					{
						((IDisposable)val9)?.Dispose();
					}
					((DisposableWrapper)Ent).Dispose();
				}
				pt = new Point3d(num, num2, 0.0);
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
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

	public static void ApagaRelatorioFURNAS()
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
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val4.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity Ent = (Entity)val2.GetObject(current, (OpenMode)1);
						if (XDataRelatorio.LerXDataFurnas(ref Ent))
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
				Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();
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
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.Colors;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.EditorInput;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.GraphicsInterface;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

public class clsMisturador
{
	public struct LayerColor
	{
		public Color Cor;

		public string lAYER;

		public string vISISVEL;
	}

	public static void BuscaPontos(string sNome, ref Point3d ptIni, ref Point3d ptFim)
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected Obj, but got Unknown
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Invalid comparison between Unknown and I4
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Invalid comparison between Unknown and I4
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		if (!File.Exists(sNome))
		{
			return;
		}
		DeclaracoesGeral.bAnularEventos = true;
		DeclaracoesGeral.bCancelarEventoTrocaDocumento = true;
		Document Doc = DocumentCollectionExtension.Open(Application.DocumentManager, sNome, true);
		_ = Application.DocumentManager.MdiActiveDocument.Editor;
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		LigaLayers(ref Doc);
		zoomall();
		try
		{
			_ = Doc.Database;
			PromptPointOptions val = new PromptPointOptions("");
			((PromptOptions)val).Message = Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 1558]));
			PromptPointResult point = Doc.Editor.GetPoint(val);
			Point3d value = point.Value;
			if ((int)((PromptResult)point).Status == -5002)
			{
				return;
			}
			((PromptOptions)val).Message = Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 1559]));
			val.UseBasePoint = true;
			((PromptCornerOptions)val).BasePoint = value;
			point = Doc.Editor.GetPoint(val);
			Point3d value2 = point.Value;
			if ((int)((PromptResult)point).Status == -5002)
			{
				return;
			}
			ptIni = value;
			ptFim = value2;
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			if (!(ptIni.X < ptFim.X))
			{
				num = ptFim.X;
				num2 = ptIni.X;
			}
			else
			{
				num = ptIni.X;
				num2 = ptFim.X;
			}
			if (!(ptIni.Y < ptFim.Y))
			{
				num3 = ptFim.Y;
				num4 = ptIni.Y;
			}
			else
			{
				num3 = ptIni.Y;
				num4 = ptFim.Y;
			}
			num = Math.Round(num, 2);
			num2 = Math.Round(num2, 2);
			num3 = Math.Round(num3, 2);
			num4 = Math.Round(num4, 2);
			ptIni = new Point3d(num, num3, 0.0);
			ptFim = new Point3d(num2, num4, 0.0);
			buscaMenorPonto(ref ptIni, ref ptFim);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox(ex2.Message);
			ProjectData.ClearProjectError();
		}
		DocumentExtension.CloseAndDiscard(Doc);
		DeclaracoesGeral.bCancelarEventoTrocaDocumento = false;
		DeclaracoesGeral.bAnularEventos = false;
	}

	public static void LigaLayers(ref Document Doc)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected Obj, but got Unknown
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Doc.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				ObjectId val3 = mdiActiveDocument.Database.LayerTableId;
				LayerTable val4 = (LayerTable)val3.GetObject((OpenMode)0);
				SymbolTableEnumerator enumerator = val4.GetEnumerator();
				while (enumerator.MoveNext())
				{
					val3 = enumerator.Current;
					LayerTableRecord val5 = (LayerTableRecord)val3.GetObject((OpenMode)0);
					((DBObject)val5).UpgradeOpen();
					val5.IsOff = false;
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				Application.UpdateScreen();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
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

	public static void buscaMenorPonto(ref Point3d ptIni, ref Point3d ptFim)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected Obj, but got Unknown
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected Obj, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected Obj, but got Unknown
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Unknown result type (might be due to invalid IL or missing references)
		//IL_033e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0389: Unknown result type (might be due to invalid IL or missing references)
		//IL_038e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		Point3d val = new Point3d(1000000.0, 1000000.0, 0.0);
		Point3d val2 = new Point3d(-1000000.0, -1000000.0, 0.0);
		Point3d val3 = default;
		Point3d val4 = default;
		DocumentLock val5 = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val6 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val7 = (BlockTable)val6.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val8 = (BlockTableRecord)val6.GetObject(((SymbolTable)val7)[BlockTableRecord.ModelSpace], (OpenMode)0);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val8.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val9 = (Entity)val6.GetObject(current, (OpenMode)0);
						if (!Information.IsNothing(((Drawable)val9).Bounds))
						{
							Extents3d value = ((Drawable)val9).Bounds.Value;
							Point3d val10 = value.MinPoint;
							double x = val10.X;
							value = ((Drawable)val9).Bounds.Value;
							val10 = value.MinPoint;
							val3 = new Point3d(x, val10.Y, 0.0);
							value = ((Drawable)val9).Bounds.Value;
							val10 = value.MaxPoint;
							double x2 = val10.X;
							value = ((Drawable)val9).Bounds.Value;
							val10 = value.MaxPoint;
							val4 = new Point3d(x2, val10.Y, 0.0);
							if (Math.Round(val.X, 2) > Math.Round(val3.X, 2))
							{
								val = new Point3d(Math.Round(val3.X, 2), Math.Round(val.Y, 2), 0.0);
							}
							if (Math.Round(val.Y, 2) > Math.Round(val3.Y, 2))
							{
								val = new Point3d(Math.Round(val.X, 2), Math.Round(val3.Y, 2), 0.0);
							}
							if (Math.Round(val2.X, 2) < Math.Round(val4.X, 2))
							{
								val2 = new Point3d(Math.Round(val4.X, 2), Math.Round(val2.Y, 2), 0.0);
							}
							if (Math.Round(val2.Y, 2) < Math.Round(val4.Y, 2))
							{
								val2 = new Point3d(Math.Round(val2.X, 2), Math.Round(val4.Y, 2), 0.0);
							}
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				double value2 = ptIni.X - val.X;
				double value3 = ptIni.Y - val.Y;
				DeclaracoesGeral.bAnularEventos = true;
				val6.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				ptIni = new Point3d(Math.Round(value2, 2), Math.Round(value3, 2), 0.0);
				value2 = Math.Round(ptFim.X, 2) - Math.Round(val.X, 2);
				value3 = Math.Round(ptFim.Y, 2) - Math.Round(val.Y, 2);
				ptFim = new Point3d(value2, value3, 0.0);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				val6.Abort();
				throw;
			}
			finally
			{
				((IDisposable)val6)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val5)?.Dispose();
		}
	}

	public static void burstNoBloco(ref BlockTableRecord mdl, ref BlockReference blockRef, string sLayer)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected Obj, but got Unknown
		//IL_0312: Unknown result type (might be due to invalid IL or missing references)
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected Obj, but got Unknown
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected Obj, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Expected Obj, but got Unknown
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected Obj, but got Unknown
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				DBObjectCollection val2 = new DBObjectCollection();
				((Entity)blockRef).Explode(val2);
				int num = val2.Count - 1;
				for (int i = num; i >= 0; i += -1)
				{
					if (val2[i] is AttributeDefinition)
					{
						val2.RemoveAt(i);
					}
				}
				int num2 = val2.Count - 1;
				for (int j = num2; j >= 0; j += -1)
				{
					DBObject val3 = val2[j];
					Entity val4 = (Entity)(object)((val3 is Entity) ? val3 : null);
					val4.Layer = sLayer;
				}
				int num3 = val2.Count - 1;
				for (int k = num3; k >= 0; k += -1)
				{
					DBObject val5 = val2[k];
					BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
					if (val6 != null && ((Operators.CompareString(val6.Name.ToUpper(), "REGUAV", TextCompare: true) == 0) | (Operators.CompareString(val6.Name.ToUpper(), "REGUAH", TextCompare: true) == 0)) && !((Entity)val6).Visible)
					{
						val2.RemoveAt(k);
					}
				}
				BlockTableRecord val7 = (BlockTableRecord)val.GetObject(database.CurrentSpaceId, (OpenMode)1);
				foreach (Entity item in val2)
				{
					Entity val8 = item;
					val8.Layer = sLayer;
					val7.AppendEntity(val8);
					DeclaracoesGeral.bAnularEventos = true;
					val.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
				}
				foreach (object item2 in blockRef.AttributeCollection)
				{
					ObjectId val9 = ((item2 == null) ? default(ObjectId) : ((ObjectId)item2));
					AttributeReference val10 = (AttributeReference)val.GetObject(val9, (OpenMode)1);
					DBText val11 = new DBText();
					new MText();
					_ = (Entity)val.GetObject(val9, (OpenMode)1);
					if (!((Entity)val10).Visible)
					{
						continue;
					}
					Type typeFromHandle = typeof(DBText);
					PropertyInfo[] properties = typeFromHandle.GetProperties();
					foreach (PropertyInfo propertyInfo in properties)
					{
						if (!(propertyInfo.CanWrite & ((object)propertyInfo.DeclaringType == typeFromHandle)))
						{
							continue;
						}
						try
						{
							if (val10.IsMTextAttribute)
							{
								propertyInfo.SetValue(val11, RuntimeHelpers.GetObjectValue(propertyInfo.GetValue(val10, null)), null);
							}
							else
							{
								propertyInfo.SetValue(val11, RuntimeHelpers.GetObjectValue(propertyInfo.GetValue(val10, null)), null);
							}
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
						}
					}
					if (val10.IsMTextAttribute)
					{
						val11.TextString = ((DBText)val10).TextString;
						((Entity)val11).ColorIndex = ((Entity)val10).ColorIndex;
						((Entity)val11).Layer = sLayer;
						val11.TextStyleId = ((DBText)val10).TextStyleId;
						mdl.AppendEntity((Entity)(object)val11);
						DeclaracoesGeral.bAnularEventos = true;
						val.AddNewlyCreatedDBObject((DBObject)(object)val11, true);
					}
					else
					{
						val11.TextString = ((DBText)val10).TextString;
						((Entity)val11).ColorIndex = ((Entity)val10).ColorIndex;
						((Entity)val11).Layer = sLayer;
						val11.TextStyleId = ((DBText)val10).TextStyleId;
						mdl.AppendEntity((Entity)(object)val11);
						DeclaracoesGeral.bAnularEventos = true;
						val.AddNewlyCreatedDBObject((DBObject)(object)val11, true);
					}
				}
				val2.Clear();
				DeclaracoesGeral.bAnularEventos = true;
				val.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				throw;
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}

	public static void ApagarxDataDaEntity(ref Database db, ref Entity ent)
	{
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected Obj, but got Unknown
		Transaction val = db.TransactionManager.StartTransaction();
		try
		{
			if (((DBObject)ent).XData != (ResultBuffer)null)
			{
				string text = ((DBObject)ent).XData.ToString();
				string[] array = text.Split(',');
				if (Operators.CompareString(array[1].ToString().Trim(), "", TextCompare: true) != 0)
				{
					array = array[1].Split(')');
					if (Operators.CompareString(array[0].ToString().Trim(), "", TextCompare: true) != 0)
					{
						TypedValue[] array2 = new TypedValue[1]
						{
							new TypedValue(1001, (object)array[0].ToString())
						};
						((DBObject)ent).UpgradeOpen();
						((DBObject)ent).XData = new ResultBuffer(array2);
						((DBObject)ent).DowngradeOpen();
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
			throw;
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void zoomall()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected Obj, but got Unknown
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected Obj, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected Obj, but got Unknown
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Expected Obj, but got Unknown
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		Point3d val = new Point3d(1000000.0, 1000000.0, 0.0);
		Point3d val2 = new Point3d(-1000000.0, -1000000.0, 0.0);
		Point3d val3 = default;
		Point3d val4 = default;
		DocumentLock val5 = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val6 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val7 = (BlockTable)val6.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val8 = (BlockTableRecord)val6.GetObject(((SymbolTable)val7)[BlockTableRecord.ModelSpace], (OpenMode)0);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val8.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val9 = (Entity)val6.GetObject(current, (OpenMode)0);
						if (!Information.IsNothing(((Drawable)val9).Bounds))
						{
							Extents3d value = ((Drawable)val9).Bounds.Value;
							Point3d val10 = value.MinPoint;
							double x = val10.X;
							value = ((Drawable)val9).Bounds.Value;
							val10 = value.MinPoint;
							val3 = new Point3d(x, val10.Y, 0.0);
							value = ((Drawable)val9).Bounds.Value;
							val10 = value.MaxPoint;
							double x2 = val10.X;
							value = ((Drawable)val9).Bounds.Value;
							val10 = value.MaxPoint;
							val4 = new Point3d(x2, val10.Y, 0.0);
							if (val.X > val3.X)
							{
								val = new Point3d(val3.X, val.Y, 0.0);
							}
							if (val.Y > val3.Y)
							{
								val = new Point3d(val.X, val3.Y, 0.0);
							}
							if (val2.X < val4.X)
							{
								val2 = new Point3d(val4.X, val2.Y, 0.0);
							}
							if (val2.Y < val4.Y)
							{
								val2 = new Point3d(val2.X, val4.Y, 0.0);
							}
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				Editor editor = mdiActiveDocument.Editor;
				Point2d val11 = new Point2d(val.X, val.Y);
				Point2d val12 = new Point2d(val2.X, val2.Y);
				ViewTableRecord val13 = new ViewTableRecord();
				try
				{
					((AbstractViewTableRecord)val13).CenterPoint = val11 + (val12 - val11) / 2.0;
					((AbstractViewTableRecord)val13).Height = val12.Y - val11.Y;
					((AbstractViewTableRecord)val13).Width = val12.X - val11.X;
					editor.SetCurrentView(val13);
				}
				finally
				{
					((IDisposable)val13)?.Dispose();
				}
				DeclaracoesGeral.bAnularEventos = true;
				val6.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				val6.Abort();
				throw;
			}
			finally
			{
				((IDisposable)val6)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val5)?.Dispose();
		}
	}

	public static void LeTodososOsLayers(ref List<string> lLayers)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected Obj, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Database database = mdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			Transaction val2 = val;
			try
			{
				LayerTable val3 = (LayerTable)val.GetObject(database.LayerTableId, (OpenMode)0);
				SymbolTableEnumerator enumerator = default;
				try
				{
					enumerator = val3.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						LayerTableRecord val4 = (LayerTableRecord)val.GetObject(current, (OpenMode)0);
						lLayers.Add(((SymbolTableRecord)val4).Name);
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void LeTodososOshandles(ref List<string> lHandles, ref long ipontoInicial)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected Obj, but got Unknown
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected Obj, but got Unknown
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected Obj, but got Unknown
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		lHandles.Clear();
		ipontoInicial = 0L;
		checked
		{
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
								lHandles.Add(((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString());
								ipontoInicial++;
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
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void MoveOsOutrosaLayersParaPagiana(ref List<string> lHandles, string slayer)
	{
	}

	public static void EncontraCorLayerZeroDoFormato(ref Color Corzero)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected Obj, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				LayerTable val4 = (LayerTable)val2.GetObject(database.LayerTableId, (OpenMode)0);
				SymbolTableEnumerator enumerator = default;
				try
				{
					enumerator = val4.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						LayerTableRecord val5 = (LayerTableRecord)val2.GetObject(current, (OpenMode)0);
						if (Operators.CompareString(((SymbolTableRecord)val5).Name, "0", TextCompare: true) == 0)
						{
							Corzero = val5.Color;
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
				((IDisposable)val2)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}
}

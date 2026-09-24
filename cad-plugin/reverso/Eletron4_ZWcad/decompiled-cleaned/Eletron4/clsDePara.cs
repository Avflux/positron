using System;
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

public class clsDePara
{
	private static string aedpAgqhAj;

	private static string QgvpsgEOQ4;

	public static void CriarDePara(ref int tipo)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected Obj, but got Unknown
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected Obj, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected Obj, but got Unknown
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected Obj, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected I4, but got Unknown
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected Obj, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Invalid comparison between Unknown and I4
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Invalid comparison between Unknown and I4
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_033d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0342: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Expected Obj, but got Unknown
		PointMonitorToolTips.StopMonitor();
		Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)1);
				TextStyleTable val4 = (TextStyleTable)val.GetObject(database.TextStyleTableId, (OpenMode)0);
				ObjectId textStyleId = (((SymbolTable)val4).Has("Romans") ? ((SymbolTable)val4)["Romans"] : ((SymbolTable)val4)["Standard"]);
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				int num = 2;
				Point3d position = default;
				while (true)
				{
					ObjectId val5 = CriarRetangulo(num);
					BlockReference val6 = new BlockReference(Point3d.Origin, val5);
					try
					{
						((Entity)val6).Layer = DeclaracoesGeral.ativo.Pagina;
						JigDePara jigDePara = new JigDePara((Entity)(object)val6);
						PromptResult val7 = editor.Drag((Jig)(object)jigDePara);
						PromptStatus status = val7.Status;
						switch (unchecked(status - -5005))
						{
						case 4:
							((DisposableWrapper)val6).Dispose();
							goto end_IL_0161;
						default:
							unchecked
							{
								if ((int)status != 5000)
								{
									if ((int)status == 5100)
									{
										position = val6.Position;
									}
									break;
								}
								goto case 0;
							}
						case 0:
							num++;
							if (num > 3)
							{
								num = 1;
							}
							continue;
						case 1:
						case 2:
							break;
						case 3:
							tipo--;
							((DisposableWrapper)val6).Dispose();
							goto end_IL_0161;
						}
					}
					finally
					{
						((IDisposable)val6)?.Dispose();
					}
					DBText text = new DBText();
					if (tipo != 1)
					{
						if (tipo == 2)
						{
							QgvpsgEOQ4 = "";
							if (Information.IsNothing(RuntimeHelpers.GetObjectValue(Geral.HandleToObject(aedpAgqhAj))))
							{
								tipo = 1;
								text.TextString = "DE";
								aedpAgqhAj = "";
								QgvpsgEOQ4 = "";
							}
							else
							{
								text.TextString = "PARA";
							}
						}
					}
					else
					{
						text.TextString = "DE";
						aedpAgqhAj = "";
						QgvpsgEOQ4 = "";
					}
					if (num != 1)
					{
						if (num != 2)
						{
							if (num == 3)
							{
								text.HorizontalMode = (TextHorizontalMode)2;
							}
						}
						else
						{
							text.HorizontalMode = (TextHorizontalMode)4;
						}
					}
					else
					{
						text.HorizontalMode = (TextHorizontalMode)0;
					}
					((Entity)text).ColorIndex = DeclaracoesGeral.Conf.CorTextoCircuito;
					((Entity)text).Layer = DeclaracoesGeral.ativo.Pagina;
					text.Height = DeclaracoesGeral.Conf.FonteCruzamento;
					text.VerticalMode = (TextVerticalMode)2;
					text.TextStyleId = textStyleId;
					text.AlignmentPoint = position;
					val3.AppendEntity((Entity)(object)text);
					DeclaracoesGeral.bAnularEventos = true;
					val.AddNewlyCreatedDBObject((DBObject)(object)text, true);
					if (tipo != 1)
					{
						if (tipo == 2)
						{
							QgvpsgEOQ4 = ((object)((DBObject)text).Handle/*cast due to constrained. prefix*/).ToString();
							XDataDispositivo.GravarXDataDePara(ref text, aedpAgqhAj, (short)tipo);
							DBText text2 = (DBText)Geral.HandleToObject(aedpAgqhAj);
							if (text2 != null)
							{
								((DBObject)text2).UpgradeOpen();
								XDataDispositivo.GravarXDataDePara(ref text2, QgvpsgEOQ4, 1);
							}
							SincronizaDePara();
						}
					}
					else
					{
						aedpAgqhAj = ((object)((DBObject)text).Handle/*cast due to constrained. prefix*/).ToString();
						XDataDispositivo.GravarXDataDePara(ref text, QgvpsgEOQ4, (short)tipo);
					}
					break;
					continue;
					end_IL_0161:
					break;
				}
				DeclaracoesGeral.bAnularEventos = true;
				val.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				val.Abort();
				Interaction.MsgBox(ex2.Message, MsgBoxStyle.Information);
				ProjectData.ClearProjectError();
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			PointMonitorToolTips.StartMonitor();
		}
	}

	public static ObjectId CriarRetangulo(int tipoAlinhamento)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected Obj, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_031b: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected Obj, but got Unknown
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Expected Obj, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Expected Obj, but got Unknown
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected Obj, but got Unknown
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Expected Obj, but got Unknown
		ObjectId result = ObjectId.Null;
		DeclaracoesGeral.bAnularEventos = true;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				try
				{
					string text = "Bloco_Retangulo_DePara";
					Point3d val3 = new Point3d(0.0, 0.0, 0.0);
					Vector3d vectorTo = default;
					if (tipoAlinhamento != 1)
					{
						if (tipoAlinhamento != 2)
						{
							if (tipoAlinhamento == 3)
							{
								vectorTo = val3.GetVectorTo(new Point3d(0.0 - DeclaracoesGeral.Conf.FonteCircuito, 0.0, 0.0));
							}
						}
						else
						{
							vectorTo = val3.GetVectorTo(new Point3d(0.0, 0.0, 0.0));
						}
					}
					else
					{
						vectorTo = val3.GetVectorTo(new Point3d(DeclaracoesGeral.Conf.FonteCircuito, 0.0, 0.0));
					}
					BlockTable val4 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)1);
					BlockTableRecord val6;
					if (((SymbolTable)val4).Has(text))
					{
						BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[text], (OpenMode)1);
						val6 = (BlockTableRecord)val2.GetObject(((DBObject)val5).Id, (OpenMode)1);
						((DBObject)val6).Erase();
					}
					val6 = new BlockTableRecord();
					((SymbolTableRecord)val6).Name = text;
					((SymbolTable)val4).Add((SymbolTableRecord)(object)val6);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val6, true);
					Point3dCollection val7 = new Point3dCollection();
					val7.Add(new Point3d(0.0 - DeclaracoesGeral.Conf.FonteCruzamento, (0.0 - DeclaracoesGeral.Conf.FonteCruzamento) / 2.0, 0.0));
					val7.Add(new Point3d(DeclaracoesGeral.Conf.FonteCruzamento, (0.0 - DeclaracoesGeral.Conf.FonteCruzamento) / 2.0, 0.0));
					val7.Add(new Point3d(DeclaracoesGeral.Conf.FonteCruzamento, DeclaracoesGeral.Conf.FonteCruzamento / 2.0, 0.0));
					val7.Add(new Point3d(0.0 - DeclaracoesGeral.Conf.FonteCruzamento, DeclaracoesGeral.Conf.FonteCruzamento / 2.0, 0.0));
					Polyline2d val8 = new Polyline2d((Poly2dType)0, val7, 0.0, true, 0.0, 0.0, (DoubleCollection)null);
					((Entity)val8).Layer = "0";
					((Entity)val8).LineWeight = (LineWeight)9;
					((Entity)val8).ColorIndex = DeclaracoesGeral.Conf.CorConexao;
					((Entity)val8).TransformBy(Matrix3d.Displacement(vectorTo));
					val6.AppendEntity((Entity)(object)val8);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
					result = ((DBObject)val6).ObjectId;
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
					DeclaracoesGeral.bAnularEventos = false;
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
		return result;
	}

	public static void AtualizarTextoDeParaCruzado(ref DBText texto, string handle)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected Obj, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected Obj, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected Obj, but got Unknown
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			DeclaracoesGeral.Reguas RH = default;
			bool flag = false;
			DeclaracoesGeral.Reguas RH2 = default;
			bool flag2 = false;
			flag = XDataGeral.LeXDataReguaH(ref RH);
			flag2 = XDataGeral.LeXDataReguaV(ref RH2);
			BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
			_ = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
			DBText val3 = (DBText)Geral.HandleToObject(handle);
			if (!Information.IsNothing(val3))
			{
				((DBObject)val3).UpgradeOpen();
				string pagina = ((Entity)texto).Layer.ToString();
				Entity ent = (Entity)(object)texto;
				string posicao = Pagina.calculaLinhaColuna(ref ent, ref RH, ref RH2, flag, flag2);
				texto = (DBText)ent;
				val3.TextString = Pagina.montaCruzamentoPagina(pagina, posicao);
			}
			else
			{
				((DBObject)texto).UpgradeOpen();
				((DBObject)texto).Erase();
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

	public static void ApagarTextoDeParaCruzado(string handle)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				DBText val4 = (DBText)Geral.HandleToObject(handle);
				if (!Information.IsNothing(val4))
				{
					((DBObject)val4).UpgradeOpen();
					((DBObject)val4).Erase();
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

	public static void SincronizaDePara(bool bUpdateProp = true)
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected Obj, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected Obj, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected Obj, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				DeclaracoesGeral.Reguas RH = default;
				bool flag = false;
				DeclaracoesGeral.Reguas RH2 = default;
				bool flag2 = false;
				flag = XDataGeral.LeXDataReguaH(ref RH);
				flag2 = XDataGeral.LeXDataReguaV(ref RH2);
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val4.GetEnumerator();
					short tipo = default;
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
						DBText text = (DBText)(object)((val5 is DBText) ? val5 : null);
						if (text == null)
						{
							continue;
						}
						string handle = "";
						if (!XDataDispositivo.lerXDataDePara(ref text, ref handle, ref tipo))
						{
							continue;
						}
						object obj = Geral.HandleToObject(handle);
						DBText val6 = (DBText)((obj is DBText) ? obj : null);
						if (val6 == null)
						{
							((DBObject)text).UpgradeOpen();
							((DBObject)text).Erase();
							continue;
						}
						((DBObject)text).UpgradeOpen();
						DBText val7 = text;
						string pagina = ((Entity)val6).Layer.ToString();
						Entity ent = (Entity)(object)val6;
						string posicao = Pagina.calculaLinhaColuna(ref ent, ref RH, ref RH2, flag, flag2);
						val6 = (DBText)ent;
						val7.TextString = Pagina.montaCruzamentoPagina(pagina, posicao);
						if (bUpdateProp)
						{
							((Entity)text).ColorIndex = DeclaracoesGeral.Conf.CorTextoCircuito;
							text.Height = DeclaracoesGeral.Conf.FonteCruzamento;
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

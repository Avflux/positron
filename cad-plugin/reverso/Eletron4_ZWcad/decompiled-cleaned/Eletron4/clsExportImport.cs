using System;
using System.IO;
using System.Runtime.InteropServices;
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

public class clsExportImport
{
	public static void removeTodosCodigosExportacao()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected Obj, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected Obj, but got Unknown
		int num = 0;
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
						if (XDataExpImp.PossuiXDataExportado(ref ent))
						{
							((DBObject)ent).UpgradeOpen();
							XDataExpImp.ApagarXDataExportado(ref ent);
							num = checked(num + 1);
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
				Interaction.MsgBox(Operators.AddObject(num + " ", DeclaracoesGeral.mMensagem[1, 876]), MsgBoxStyle.Information);
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

	public static void removeCodigosSelecionadosExportacao()
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected Obj, but got Unknown
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected Obj, but got Unknown
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Invalid comparison between Unknown and I4
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected Obj, but got Unknown
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected Obj, but got Unknown
		PointMonitorToolTips.StopMonitor();
		int num = 0;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				TypedValue[] array = new TypedValue[1];
				array.SetValue((object)new TypedValue(1001, (object)"EXPORTADO"), 0);
				SelectionFilter val4 = new SelectionFilter(array);
				PromptSelectionOptions val5 = new PromptSelectionOptions();
				val5.MessageForAdding = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 877]);
				PromptSelectionResult selection = editor.GetSelection(val5, val4);
				if ((int)selection.Status == 5100)
				{
					SelectionSet value = selection.Value;
					ObjectIdCollection val6 = new ObjectIdCollection(value.GetObjectIds());
					if (val6.Count != 0)
					{
						foreach (object item in val6)
						{
							ObjectId val7 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							Entity ent = (Entity)val7.GetObject((OpenMode)0);
							if (XDataExpImp.PossuiXDataExportado(ref ent))
							{
								((DBObject)ent).UpgradeOpen();
								XDataExpImp.ApagarXDataExportado(ref ent);
								num = checked(num + 1);
							}
						}
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				Interaction.MsgBox(Operators.AddObject(num + " ", DeclaracoesGeral.mMensagem[1, 876]), MsgBoxStyle.Information);
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
				((IDisposable)val2)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		PointMonitorToolTips.StartMonitor();
	}

	public static void ocultarImportadosSelecionados()
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected Obj, but got Unknown
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected Obj, but got Unknown
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected Obj, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Invalid comparison between Unknown and I4
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected Obj, but got Unknown
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected Obj, but got Unknown
		PointMonitorToolTips.StopMonitor();
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				TypedValue[] array = new TypedValue[1];
				array.SetValue((object)new TypedValue(1001, (object)"IMPORTADO"), 0);
				SelectionFilter val4 = new SelectionFilter(array);
				PromptSelectionOptions val5 = new PromptSelectionOptions();
				val5.MessageForAdding = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 877]);
				PromptSelectionResult selection = editor.GetSelection(val5, val4);
				if ((int)selection.Status == 5100)
				{
					SelectionSet value = selection.Value;
					ObjectIdCollection val6 = new ObjectIdCollection(value.GetObjectIds());
					if (val6.Count != 0)
					{
						foreach (object item in val6)
						{
							ObjectId val7 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							Entity ent = (Entity)val7.GetObject((OpenMode)0);
							if (XDataExpImp.PossuiXDataImportado(ref ent))
							{
								((DBObject)ent).UpgradeOpen();
								ent.Visible = false;
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
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				val2.Abort();
				Interaction.MsgBox(ex2.Message, MsgBoxStyle.Information);
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
		PointMonitorToolTips.StartMonitor();
	}

	public static void ligarImportadosPagina(string layer)
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
							if (XDataExpImp.PossuiXDataImportado(ref ent) && Operators.CompareString(ent.Layer.ToString(), layer, TextCompare: true) == 0 && !ent.Visible)
							{
								((DBObject)ent).UpgradeOpen();
								ent.Visible = true;
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

	public static void Carimbo()
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected Obj, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected Obj, but got Unknown
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected Obj, but got Unknown
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Invalid comparison between Unknown and I4
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected Obj, but got Unknown
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected Obj, but got Unknown
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Expected Obj, but got Unknown
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Expected Obj, but got Unknown
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected Obj, but got Unknown
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Invalid comparison between Unknown and I4
		//IL_03dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e3: Invalid comparison between Unknown and I4
		//IL_047e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0485: Expected Obj, but got Unknown
		//IL_03e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0406: Unknown result type (might be due to invalid IL or missing references)
		//IL_040b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0423: Unknown result type (might be due to invalid IL or missing references)
		//IL_042a: Expected Obj, but got Unknown
		//IL_04d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0516: Unknown result type (might be due to invalid IL or missing references)
		//IL_051b: Unknown result type (might be due to invalid IL or missing references)
		//IL_051d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0524: Unknown result type (might be due to invalid IL or missing references)
		//IL_0526: Invalid comparison between Unknown and I4
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a7: Expected Obj, but got Unknown
		//IL_0654: Unknown result type (might be due to invalid IL or missing references)
		//IL_065b: Invalid comparison between Unknown and I4
		//IL_0661: Unknown result type (might be due to invalid IL or missing references)
		//IL_068c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0693: Expected Obj, but got Unknown
		//IL_054d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0554: Expected Obj, but got Unknown
		PointMonitorToolTips.StopMonitor();
		cDadosAccess.carregaDadosDWG();
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				cDadosAccessExpImp cDadosAccessExpImp2 = new cDadosAccessExpImp();
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
					PromptEntityOptions val5 = new PromptEntityOptions("");
					val5.SetRejectMessage(Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 880])));
					((PromptOptions)val5).Message = Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 880]));
					val5.AddAllowedClass(typeof(BlockReference), true);
					PromptEntityResult entity = editor.GetEntity(val5);
					if ((int)((PromptResult)entity).Status != -5002)
					{
						ObjectId objectId = entity.ObjectId;
						BlockReference val6 = (BlockReference)objectId.GetObject((OpenMode)0);
						TextStyleTable val7 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)0);
						ObjectId textStyleId = (((SymbolTable)val7).Has("Romans") ? ((SymbolTable)val7)["Romans"] : ((SymbolTable)val7)["Standard"]);
						DeclaracoesEntidades.StructureExportar exp = default;
						Entity ent = (Entity)(object)val6;
						bool flag = XDataExpImp.LerXDataImportado(ref ent, ref exp);
						val6 = (BlockReference)ent;
						if (flag)
						{
							int num = 1;
							DBText val8 = new DBText();
							while (true)
							{
								IL_01ce:
								val8.TextString = Dicionario.BuscaNomeDoPainel(exp.Painel);
								while (true)
								{
									((Entity)val8).ColorIndex = DeclaracoesGeral.Conf.CorTextoInterligacao;
									((Entity)val8).Layer = DeclaracoesGeral.ativo.Pagina;
									val8.Height = DeclaracoesGeral.Conf.FonteCabos;
									val8.HorizontalMode = (TextHorizontalMode)0;
									val8.VerticalMode = (TextVerticalMode)0;
									val8.TextStyleId = textStyleId;
									val8.Position = new Point3d(0.0, 0.0, 0.0);
									JigTexto jigTexto = new JigTexto((Entity)(object)val8);
									PromptResult val9 = editor.Drag((Jig)(object)jigTexto);
									PromptStatus status = val9.Status;
									if (status - -5002 <= 1)
									{
										if (!((num == 1) | (num == 2) | (num == 3)))
										{
											((DisposableWrapper)val8).Dispose();
											break;
										}
										((DisposableWrapper)val8).Dispose();
									}
									else
									{
										if ((int)status != 5100)
										{
										}
										val4.AppendEntity((Entity)(object)val8);
										DeclaracoesGeral.bAnularEventos = true;
										val2.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
										ent = (Entity)(object)val8;
										XDataExpImp.GravarXDataAuxImportado(ref ent, ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString(), num);
										val8 = (DBText)ent;
										((Entity)val8).Draw();
									}
									num = checked(num + 1);
									if (num <= 6)
									{
										val8 = new DBText();
										switch (num)
										{
										case 1:
											break;
										default:
											continue;
										case 6:
											val8.TextString = DeclaracoesGeral.Conf.PrefixoCruzFF + exp.Caderno + DeclaracoesGeral.Conf.SeparadorCarimbo + exp.posicao + DeclaracoesGeral.Conf.SufixoCruzFF;
											continue;
										case 2:
											val8.TextString = exp.Caderno;
											continue;
										case 3:
											val8.TextString = DeclaracoesGeral.Conf.PrefixoCruzFF + exp.Pagina + DeclaracoesGeral.Conf.SufixoCruzFF;
											continue;
										case 4:
											val8.TextString = DeclaracoesGeral.Conf.PrefixoCruzFF + exp.Caderno + DeclaracoesGeral.Conf.SeparadorCarimbo + exp.Pagina + DeclaracoesGeral.Conf.SufixoCruzFF;
											continue;
										case 5:
											val8.TextString = DeclaracoesGeral.Conf.PrefixoCruzFF + exp.posicao + DeclaracoesGeral.Conf.SufixoCruzFF;
											continue;
										}
										goto IL_01ce;
									}
									break;
								}
								break;
							}
						}
						exp = default;
						ent = (Entity)(object)val6;
						flag = XDataExpImp.LerXDataExportado(ref ent, ref exp);
						val6 = (BlockReference)ent;
						if (flag)
						{
							string CadernoDest = "";
							string paginaDest = "";
							string posicaoDest = "";
							if (cDadosAccessExpImp2.carregaDestinos(exp.indice, ref CadernoDest, ref paginaDest, ref posicaoDest))
							{
								int num2 = 4;
								DBText val10 = new DBText();
								while (true)
								{
									IL_0485:
									val10.TextString = CadernoDest;
									while (true)
									{
										((Entity)val10).ColorIndex = DeclaracoesGeral.Conf.CorTextoInterligacao;
										((Entity)val10).Layer = DeclaracoesGeral.ativo.Pagina;
										val10.Height = DeclaracoesGeral.Conf.FonteCabos;
										val10.HorizontalMode = (TextHorizontalMode)0;
										val10.VerticalMode = (TextVerticalMode)0;
										val10.TextStyleId = textStyleId;
										val10.Position = new Point3d(0.0, 0.0, 0.0);
										JigTexto jigTexto2 = new JigTexto((Entity)(object)val10);
										PromptResult val11 = editor.Drag((Jig)(object)jigTexto2);
										PromptStatus status2 = val11.Status;
										if (status2 - -5002 <= 1)
										{
											if (!((num2 == 4) | (num2 == 5) | (num2 == 6)))
											{
												((DisposableWrapper)val10).Dispose();
												break;
											}
											((DisposableWrapper)val10).Dispose();
										}
										else
										{
											if ((int)status2 != 5100)
											{
											}
											val4.AppendEntity((Entity)(object)val10);
											DeclaracoesGeral.bAnularEventos = true;
											val2.AddNewlyCreatedDBObject((DBObject)(object)val10, true);
											ent = (Entity)(object)val10;
											XDataExpImp.GravarXDataAuxExportado(ref ent, exp.indice, num2);
											val10 = (DBText)ent;
											((Entity)val10).Draw();
										}
										num2 = checked(num2 + 1);
										if (num2 <= 8)
										{
											val10 = new DBText();
											switch (num2)
											{
											case 4:
												break;
											default:
												continue;
											case 8:
												val10.TextString = DeclaracoesGeral.Conf.PrefixoCruzFF + CadernoDest + DeclaracoesGeral.Conf.SeparadorCarimbo + posicaoDest + DeclaracoesGeral.Conf.SufixoCruzFF;
												continue;
											case 5:
												val10.TextString = DeclaracoesGeral.Conf.PrefixoCruzFF + paginaDest + DeclaracoesGeral.Conf.SufixoCruzFF;
												continue;
											case 6:
												val10.TextString = DeclaracoesGeral.Conf.PrefixoCruzFF + posicaoDest + DeclaracoesGeral.Conf.SufixoCruzFF;
												continue;
											case 7:
												val10.TextString = DeclaracoesGeral.Conf.PrefixoCruzFF + CadernoDest + DeclaracoesGeral.Conf.SeparadorCarimbo + paginaDest + DeclaracoesGeral.Conf.SufixoCruzFF;
												continue;
											}
											goto IL_0485;
										}
										break;
									}
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
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					val2.Abort();
					Interaction.MsgBox(ex2.Message, MsgBoxStyle.Information);
					ProjectData.ClearProjectError();
				}
				finally
				{
					cDadosAccessExpImp2.fechaConexao();
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
		PointMonitorToolTips.StartMonitor();
	}

	public static void SincronizaExportados()
	{
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected Obj, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected Obj, but got Unknown
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected Obj, but got Unknown
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a05: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a16: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1d: Expected Obj, but got Unknown
		//IL_0a40: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a47: Expected Obj, but got Unknown
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_0457: Unknown result type (might be due to invalid IL or missing references)
		//IL_045e: Expected Obj, but got Unknown
		//IL_053d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0544: Expected Obj, but got Unknown
		//IL_0677: Unknown result type (might be due to invalid IL or missing references)
		//IL_067e: Expected Obj, but got Unknown
		//IL_0568: Unknown result type (might be due to invalid IL or missing references)
		//IL_056f: Expected Obj, but got Unknown
		//IL_07b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bf: Expected Obj, but got Unknown
		//IL_06a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06aa: Expected Obj, but got Unknown
		//IL_08bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c3: Expected Obj, but got Unknown
		//IL_0506: Unknown result type (might be due to invalid IL or missing references)
		//IL_050c: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0953: Unknown result type (might be due to invalid IL or missing references)
		//IL_095a: Expected Obj, but got Unknown
		//IL_04bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d0: Expected Obj, but got Unknown
		//IL_061c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0622: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c6: Expected Obj, but got Unknown
		//IL_075d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0763: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0700: Unknown result type (might be due to invalid IL or missing references)
		//IL_0707: Expected Obj, but got Unknown
		//IL_0885: Unknown result type (might be due to invalid IL or missing references)
		//IL_088b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0839: Unknown result type (might be due to invalid IL or missing references)
		//IL_083e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0848: Unknown result type (might be due to invalid IL or missing references)
		//IL_084f: Expected Obj, but got Unknown
		cDadosAccess.carregaDadosDWG();
		DeclaracoesGeral.Reguas RH = default;
		bool flag = false;
		DeclaracoesGeral.Reguas RH2 = default;
		bool flag2 = false;
		flag = XDataGeral.LeXDataReguaH(ref RH);
		flag2 = XDataGeral.LeXDataReguaV(ref RH2);
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				cDadosAccessExpImp cDadosAccessExpImp2 = new cDadosAccessExpImp();
				try
				{
					cDadosAccessExpImp2.setaAtualizadoFalseDWG(DeclaracoesGeral.arqAtivo.Indice);
					cDadosAccessExpImp2.ApagaAtributos(DeclaracoesGeral.arqAtivo.Indice);
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					DeclaracoesGeral._uscPagina.Quantidade = 2;
					DeclaracoesGeral._uscPagina.pbIniciar();
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity ent = (Entity)val2.GetObject(current, (OpenMode)0);
							DeclaracoesEntidades.StructureExportar exp = default;
							if (!XDataExpImp.LerXDataExportado(ref ent, ref exp))
							{
								continue;
							}
							if (!((DeclaracoesGeral.Conf.incluirColuna == 0) | (DeclaracoesGeral.Conf.incluirColuna == 1) | (DeclaracoesGeral.Conf.incluirColuna == 2)))
							{
								if (!((DeclaracoesGeral.Conf.incluirColuna == 3) | (DeclaracoesGeral.Conf.incluirColuna == 4) | (DeclaracoesGeral.Conf.incluirColuna == 5)))
								{
									if (DeclaracoesGeral.Conf.incluirColuna == 6)
									{
										exp.Pagina = "(" + ent.Layer.ToString() + ")";
										string text = Pagina.BuscaAlternativo(ent.Layer.ToString(), bretornaVazio: true);
										if (Operators.CompareString(text, "", TextCompare: true) != 0)
										{
											ref string pagina = ref exp.Pagina;
											pagina = pagina + DeclaracoesGeral.Conf.SeparadorCruzamento + text;
										}
									}
								}
								else
								{
									exp.Pagina = Pagina.BuscaAlternativo(ent.Layer.ToString(), bretornaVazio: false);
								}
							}
							else
							{
								exp.Pagina = ent.Layer.ToString();
							}
							if (Operators.CompareString(exp.Handle, ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString(), TextCompare: true) != 0)
							{
								Correcao.LimpaXData(ent, "EXPORTADO");
								Correcao.LimpaXData(ent, "DISPOSITIVO");
								cDadosAccessExpImp2.ApagaRegistroInvalido(exp.indice, exp.Codigo, exp.Handle);
								continue;
							}
							exp.Handle = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
							exp.DWG = DeclaracoesGeral.arqAtivo.Indice;
							exp.Caderno = DeclaracoesGeral.Conf.Local;
							exp.Atualizado = true;
							string text2 = Pagina.calculaLinhaColuna(ref ent, ref RH, ref RH2, flag, flag2);
							if (Operators.CompareString(text2, "", TextCompare: true) != 0)
							{
								switch (DeclaracoesGeral.Conf.incluirColuna)
								{
								case 1:
								case 5:
									exp.posicao = exp.Pagina + DeclaracoesGeral.Conf.SeparadorCruzamento + text2;
									break;
								case 2:
									exp.posicao = text2 + DeclaracoesGeral.Conf.SeparadorCruzamento + exp.Pagina;
									break;
								case 4:
									exp.posicao = exp.Pagina + DeclaracoesGeral.Conf.SeparadorCruzamento + text2;
									break;
								}
							}
							else
							{
								exp.posicao = exp.Pagina;
							}
							string tipo = exp.Tipo;
							if (Operators.CompareString(tipo, "P", TextCompare: true) != 0)
							{
								if (Operators.CompareString(tipo, "A", TextCompare: true) != 0)
								{
									if (Operators.CompareString(tipo, "E", TextCompare: true) != 0)
									{
										if (Operators.CompareString(tipo, "B", TextCompare: true) != 0)
										{
											if (Operators.CompareString(tipo, "C", TextCompare: true) != 0)
											{
												if (Operators.CompareString(tipo, "D", TextCompare: true) != 0)
												{
													if (Operators.CompareString(tipo, "T", TextCompare: true) != 0)
													{
														if (Operators.CompareString(tipo, "K", TextCompare: true) == 0)
														{
															exp.posicao = "";
															exp.Painel = -1;
															exp.Texto = "";
															exp.NomeRegua = "";
															exp.indexModelo = 0;
														}
													}
													else
													{
														DBText val5 = (DBText)ent;
														exp.posicao = "";
														exp.Painel = -1;
														exp.Texto = val5.TextString;
														exp.NomeRegua = "";
														exp.indexModelo = 0;
													}
												}
												else
												{
													exp.posicao = "";
													exp.Painel = -1;
													exp.Texto = "";
													exp.NomeRegua = "";
													exp.indexModelo = 0;
												}
											}
											else
											{
												Polyline pl = (Polyline)ent;
												DeclaracoesEntidades.StructureConexao conex = default;
												if (XDataConexao.lerXDataConexao(ref pl, ref conex))
												{
													exp.posicao = "";
													exp.Painel = conex.Painel;
													exp.Texto = "";
													exp.NomeRegua = "";
													exp.indexModelo = 0;
												}
											}
										}
										else
										{
											BlockReference blockRef = (BlockReference)ent;
											object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
											DeclaracoesEntidades.StructureBorne structureBorne = ((obj == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj));
											ref int indiceRegua = ref structureBorne.IndiceRegua;
											string sRegua = "";
											string sAlternativo = "";
											exp.Painel = DicionarioBorne.BuscaPainelDoBorneNoDicionario(ref indiceRegua, ref sRegua, ref sAlternativo);
											exp.Texto = "";
											exp.NomeRegua = DicionarioReguas.BuscaNomeDeUmaRegua(structureBorne.IndiceRegua);
											exp.indexModelo = 0;
											foreach (object item in blockRef.AttributeCollection)
											{
												ObjectId val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
												AttributeReference val7 = (AttributeReference)val6.GetObject((OpenMode)0);
												cDadosAccessExpImp2.gravaAtributoExportado(exp.DWG, exp.Handle, val7.Tag.ToUpper(), ((DBText)val7).TextString);
											}
										}
									}
									else
									{
										BlockReference blockRef2 = (BlockReference)ent;
										object obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef2);
										DeclaracoesEntidades.StructurePortas structurePortas = ((obj2 == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj2));
										Entity ent2 = (Entity)(object)blockRef2;
										short painel = XDataDispositivo.BuscaPainelDispositivo(ref ent2);
										blockRef2 = (BlockReference)ent2;
										exp.Painel = painel;
										exp.Texto = "";
										exp.NomeRegua = "";
										exp.indexModelo = structurePortas.indiceDoModelo;
										foreach (object item2 in blockRef2.AttributeCollection)
										{
											ObjectId val8 = ((item2 == null) ? default(ObjectId) : ((ObjectId)item2));
											AttributeReference val9 = (AttributeReference)val8.GetObject((OpenMode)0);
											string valor = ((DBText)val9).TextString;
											if (Operators.CompareString(val9.Tag.ToUpper(), "ORIGEM", TextCompare: true) == 0)
											{
												valor = DeclaracoesGeral.Conf.PrefixoCruzFF + exp.posicao + DeclaracoesGeral.Conf.SufixoCruzFF;
											}
											cDadosAccessExpImp2.gravaAtributoExportado(exp.DWG, exp.Handle, val9.Tag.ToUpper(), valor);
										}
									}
								}
								else
								{
									BlockReference blockRef3 = (BlockReference)ent;
									object obj3 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef3);
									if (obj3 == null)
									{
										_ = default(DeclaracoesEntidades.StructureAuxiliar);
									}
									else
										_ = (DeclaracoesEntidades.StructureAuxiliar)obj3;
									Entity ent2 = (Entity)(object)blockRef3;
									short painel = XDataDispositivo.BuscaPainelDispositivo(ref ent2);
									blockRef3 = (BlockReference)ent2;
									exp.Painel = painel;
									exp.Texto = "";
									exp.NomeRegua = "";
									exp.indexModelo = 0;
									foreach (object item3 in blockRef3.AttributeCollection)
									{
										ObjectId val10 = ((item3 == null) ? default(ObjectId) : ((ObjectId)item3));
										AttributeReference val11 = (AttributeReference)val10.GetObject((OpenMode)0);
										string valor2 = ((DBText)val11).TextString;
										if (Operators.CompareString(val11.Tag.ToUpper(), "ORIGEM", TextCompare: true) == 0)
										{
											valor2 = DeclaracoesGeral.Conf.PrefixoCruzFF + exp.posicao + DeclaracoesGeral.Conf.SufixoCruzFF;
										}
										cDadosAccessExpImp2.gravaAtributoExportado(exp.DWG, exp.Handle, val11.Tag.ToUpper(), valor2);
									}
								}
							}
							else
							{
								BlockReference blockRef4 = (BlockReference)ent;
								object obj4 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef4);
								exp.Painel = ((obj4 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj4)).Painel;
								exp.Texto = "";
								exp.NomeRegua = "";
								exp.indexModelo = 0;
								foreach (object item4 in blockRef4.AttributeCollection)
								{
									ObjectId val12 = ((item4 == null) ? default(ObjectId) : ((ObjectId)item4));
									AttributeReference val13 = (AttributeReference)val12.GetObject((OpenMode)0);
									cDadosAccessExpImp2.gravaAtributoExportado(exp.DWG, exp.Handle, val13.Tag.ToUpper(), ((DBText)val13).TextString);
								}
							}
							cDadosAccessExpImp2.AtualizaRegistro(exp.indice, ref exp);
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
					DeclaracoesGeral._uscPagina.pbPasso();
					cDadosAccessExpImp2.ApagaRegistros(DeclaracoesGeral.arqAtivo.Indice);
					BlockTableRecordEnumerator enumerator6 = default;
					try
					{
						enumerator6 = val4.GetEnumerator();
						int indice = default;
						int tipo2 = default;
						while (enumerator6.MoveNext())
						{
							ObjectId current6 = enumerator6.Current;
							Entity val14 = (Entity)val2.GetObject(current6, (OpenMode)0);
							DBText val15 = (DBText)(object)((val14 is DBText) ? val14 : null);
							if (val15 == null)
							{
								continue;
							}
							Entity ent2 = (Entity)(object)val15;
							bool flag3 = XDataExpImp.LerXDataAuxiliarExportado(ref ent2, ref indice, ref tipo2);
							val15 = (DBText)ent2;
							if (!flag3)
							{
								continue;
							}
							string CadernoDest = "";
							string paginaDest = "";
							string posicaoDest = "";
							((DBObject)val15).UpgradeOpen();
							if (!cDadosAccessExpImp2.carregaDestinos(indice, ref CadernoDest, ref paginaDest, ref posicaoDest))
							{
								((DBObject)val15).Erase();
								continue;
							}
							switch (tipo2)
							{
							case 8:
								val15.TextString = DeclaracoesGeral.Conf.PrefixoCruzFF + CadernoDest + DeclaracoesGeral.Conf.SeparadorCarimbo + posicaoDest + DeclaracoesGeral.Conf.SufixoCruzFF;
								break;
							case 4:
								val15.TextString = CadernoDest;
								break;
							case 5:
								val15.TextString = DeclaracoesGeral.Conf.PrefixoCruzFF + paginaDest + DeclaracoesGeral.Conf.SufixoCruzFF;
								break;
							case 6:
								val15.TextString = DeclaracoesGeral.Conf.PrefixoCruzFF + posicaoDest + DeclaracoesGeral.Conf.SufixoCruzFF;
								break;
							case 7:
								val15.TextString = DeclaracoesGeral.Conf.PrefixoCruzFF + CadernoDest + DeclaracoesGeral.Conf.SeparadorCarimbo + paginaDest + DeclaracoesGeral.Conf.SufixoCruzFF;
								break;
							}
						}
					}
					finally
					{
						((IDisposable)enumerator6)?.Dispose();
					}
					DeclaracoesGeral._uscPagina.pbPasso();
					DeclaracoesGeral._uscPagina.pbFim();
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
					cDadosAccessExpImp2.fechaConexao();
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

	public static void SincronizaImportados(bool bApagarImp, [Optional][DefaultParameterValue(false)] ref bool bExisteErro)
	{
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected Obj, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected Obj, but got Unknown
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected Obj, but got Unknown
		//IL_05cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05dd: Expected Obj, but got Unknown
		//IL_05e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f8: Expected Obj, but got Unknown
		//IL_0506: Unknown result type (might be due to invalid IL or missing references)
		//IL_050d: Expected Obj, but got Unknown
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
		//IL_0357: Expected Obj, but got Unknown
		//IL_0605: Unknown result type (might be due to invalid IL or missing references)
		//IL_060a: Unknown result type (might be due to invalid IL or missing references)
		//IL_060e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0616: Unknown result type (might be due to invalid IL or missing references)
		//IL_061d: Expected Obj, but got Unknown
		//IL_0647: Unknown result type (might be due to invalid IL or missing references)
		//IL_064e: Expected Obj, but got Unknown
		//IL_0660: Unknown result type (might be due to invalid IL or missing references)
		//IL_0667: Expected Obj, but got Unknown
		//IL_03d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03da: Unknown result type (might be due to invalid IL or missing references)
		//IL_0378: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ac: Expected Obj, but got Unknown
		//IL_037d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0387: Unknown result type (might be due to invalid IL or missing references)
		//IL_038e: Expected Obj, but got Unknown
		cDadosAccess.carregaDadosDWG();
		DeclaracoesGeral.Reguas RH = default;
		bool flag = false;
		DeclaracoesGeral.Reguas RH2 = default;
		bool flag2 = false;
		flag = XDataGeral.LeXDataReguaH(ref RH);
		flag2 = XDataGeral.LeXDataReguaV(ref RH2);
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				cDadosAccessExpImp cDadosAccessExpImp2 = new cDadosAccessExpImp();
				try
				{
					cDadosAccessExpImp2.setaAtualizadoFalseDWGDestino(DeclaracoesGeral.arqAtivo.Indice);
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					DeclaracoesGeral._uscPagina.Quantidade = 2;
					DeclaracoesGeral._uscPagina.pbIniciar();
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity ent = (Entity)val2.GetObject(current, (OpenMode)0);
							DeclaracoesEntidades.StructureExportar exp = default;
							if (!XDataExpImp.LerXDataImportado(ref ent, ref exp))
							{
								continue;
							}
							if (exp.DWGDest == DeclaracoesGeral.arqAtivo.Indice)
							{
								DeclaracoesEntidades.StructureExportar exp2 = default;
								if (!cDadosAccessExpImp2.carregaExportadoParcial(exp.indice, ref exp2))
								{
									if (!bApagarImp)
									{
										InsereBlocoErro(ent);
										bExisteErro = true;
									}
									else
									{
										((DBObject)ent).UpgradeOpen();
										((DBObject)ent).Erase();
									}
									continue;
								}
								exp.Caderno = exp2.Caderno;
								exp.Pagina = exp2.Pagina;
								exp.posicao = exp2.posicao;
								exp.Painel = exp2.Painel;
								exp.NomeRegua = exp2.NomeRegua;
								exp.indexModelo = exp2.indexModelo;
								((DBObject)ent).UpgradeOpen();
								XDataExpImp.GravarXDataImportado(ref ent, ref exp);
								exp.DWGDest = DeclaracoesGeral.arqAtivo.Indice;
								exp.CadernoDest = DeclaracoesGeral.Conf.Local;
								if (!((DeclaracoesGeral.Conf.incluirColuna == 0) | (DeclaracoesGeral.Conf.incluirColuna == 1) | (DeclaracoesGeral.Conf.incluirColuna == 2)))
								{
									if (!((DeclaracoesGeral.Conf.incluirColuna == 3) | (DeclaracoesGeral.Conf.incluirColuna == 4) | (DeclaracoesGeral.Conf.incluirColuna == 5)))
									{
										if (DeclaracoesGeral.Conf.incluirColuna == 6)
										{
											exp.PaginaDest = "(" + ent.Layer.ToString() + ")";
											string text = Pagina.BuscaAlternativo(ent.Layer.ToString(), bretornaVazio: true);
											if (Operators.CompareString(text, "", TextCompare: true) != 0)
											{
												ref string paginaDest = ref exp.PaginaDest;
												paginaDest = paginaDest + DeclaracoesGeral.Conf.SeparadorCruzamento + text;
											}
										}
									}
									else
									{
										exp.PaginaDest = Pagina.BuscaAlternativo(ent.Layer.ToString(), bretornaVazio: false);
									}
								}
								else
								{
									exp.PaginaDest = ent.Layer.ToString();
								}
								string text2 = Pagina.calculaLinhaColuna(ref ent, ref RH, ref RH2, flag, flag2);
								if (Operators.CompareString(text2, "", TextCompare: true) != 0)
								{
									switch (DeclaracoesGeral.Conf.incluirColuna)
									{
									case 1:
									case 5:
										exp.PosicaoDest = exp.PaginaDest + DeclaracoesGeral.Conf.SeparadorCruzamento + text2;
										break;
									case 2:
										exp.PosicaoDest = text2 + DeclaracoesGeral.Conf.SeparadorCruzamento + exp.PaginaDest;
										break;
									case 4:
										exp.PosicaoDest = exp.PaginaDest + DeclaracoesGeral.Conf.SeparadorCruzamento + text2;
										break;
									}
								}
								else
								{
									exp.PosicaoDest = exp.PaginaDest;
								}
								exp.Atualizado = true;
								cDadosAccessExpImp2.AtualizaRegistroDestino(exp.indice, ref exp);
								if (Operators.CompareString(exp.Tipo, "T", TextCompare: true) == 0)
								{
									DBText val5 = (DBText)ent;
									((DBObject)val5).UpgradeOpen();
									val5.TextString = exp2.Texto;
								}
								if (!((Operators.CompareString(exp.Tipo, "P", TextCompare: true) == 0) | (Operators.CompareString(exp.Tipo, "A", TextCompare: true) == 0) | (Operators.CompareString(exp.Tipo, "E", TextCompare: true) == 0) | (Operators.CompareString(exp.Tipo, "B", TextCompare: true) == 0)))
								{
									continue;
								}
								BlockReference val6 = (BlockReference)ent;
								((DBObject)val6).UpgradeOpen();
								foreach (object item in val6.AttributeCollection)
								{
									ObjectId val7 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
									AttributeReference val8 = (AttributeReference)val7.GetObject((OpenMode)1);
									string valor = "";
									if (!cDadosAccessExpImp2.lerValorAtributo(exp.DWG, exp.Handle, val8.Tag.ToUpper(), ref valor))
									{
										((DBText)val8).TextString = "";
									}
									else
									{
										((DBText)val8).TextString = valor;
									}
								}
							}
							else if (!bApagarImp)
							{
								InsereBlocoErro(ent);
								bExisteErro = true;
							}
							else
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
					DeclaracoesGeral._uscPagina.pbPasso();
					cDadosAccessExpImp2.AlteraStatusImportadosApagados(DeclaracoesGeral.arqAtivo.Indice);
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
					cDadosAccessExpImp2.fechaConexao();
				}
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
			Transaction val9 = database.TransactionManager.StartTransaction();
			try
			{
				cDadosAccessExpImp cDadosAccessExpImp3 = new cDadosAccessExpImp();
				try
				{
					cDadosAccessExpImp3.setaAtualizadoFalseDWGDestino(DeclaracoesGeral.arqAtivo.Indice);
					BlockTable val10 = (BlockTable)val9.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val11 = (BlockTableRecord)val9.GetObject(((SymbolTable)val10)[BlockTableRecord.ModelSpace], (OpenMode)0);
					BlockTableRecordEnumerator enumerator3 = default;
					try
					{
						enumerator3 = val11.GetEnumerator();
						int tipo = default;
						while (enumerator3.MoveNext())
						{
							ObjectId current3 = enumerator3.Current;
							Entity val12 = (Entity)val9.GetObject(current3, (OpenMode)0);
							DBText val13 = (DBText)(object)((val12 is DBText) ? val12 : null);
							if (val13 == null)
							{
								continue;
							}
							string handle = "";
							Entity ent2 = (Entity)(object)val13;
							bool flag3 = XDataExpImp.LerXDataAuxiliarImportado(ref ent2, ref handle, ref tipo);
							val13 = (DBText)ent2;
							if (!flag3)
							{
								continue;
							}
							((DBObject)val13).UpgradeOpen();
							BlockReference val14 = (BlockReference)Geral.HandleToObject(handle);
							if (val14 == null)
							{
								if (!bApagarImp)
								{
									InsereBlocoErro(val12);
									bExisteErro = true;
								}
								continue;
							}
							DeclaracoesEntidades.StructureExportar exp3 = default;
							ent2 = (Entity)(object)val14;
							flag3 = XDataExpImp.LerXDataImportado(ref ent2, ref exp3);
							val14 = (BlockReference)ent2;
							if (flag3)
							{
								switch (tipo)
								{
								case 6:
									val13.TextString = DeclaracoesGeral.Conf.PrefixoCruzFF + exp3.Caderno + DeclaracoesGeral.Conf.SeparadorCarimbo + exp3.posicao + DeclaracoesGeral.Conf.SufixoCruzFF;
									break;
								case 1:
									val13.TextString = Dicionario.BuscaNomeDoPainel(exp3.Painel);
									break;
								case 2:
									val13.TextString = exp3.Caderno;
									break;
								case 3:
									val13.TextString = DeclaracoesGeral.Conf.PrefixoCruzFF + exp3.Pagina + DeclaracoesGeral.Conf.SufixoCruzFF;
									break;
								case 4:
									val13.TextString = DeclaracoesGeral.Conf.PrefixoCruzFF + exp3.Caderno + DeclaracoesGeral.Conf.SeparadorCarimbo + exp3.Pagina + DeclaracoesGeral.Conf.SufixoCruzFF;
									break;
								case 5:
									val13.TextString = DeclaracoesGeral.Conf.PrefixoCruzFF + exp3.posicao + DeclaracoesGeral.Conf.SufixoCruzFF;
									break;
								}
							}
						}
					}
					finally
					{
						((IDisposable)enumerator3)?.Dispose();
					}
					DeclaracoesGeral._uscPagina.pbPasso();
					DeclaracoesGeral._uscPagina.pbFim();
					DeclaracoesGeral.bAnularEventos = true;
					val9.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					val9.Abort();
					throw;
				}
				finally
				{
					cDadosAccessExpImp3.fechaConexao();
				}
			}
			finally
			{
				((IDisposable)val9)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void CapturaExportados(ref DeclaracoesEntidades.StructureExportar[] mExp)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected Obj, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected Obj, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected Obj, but got Unknown
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Expected Obj, but got Unknown
		//IL_03ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d1: Expected Obj, but got Unknown
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Expected Obj, but got Unknown
		//IL_030a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Expected Obj, but got Unknown
		cDadosAccess.carregaDadosDWG();
		cDadosAccessExpImp cDadosAccessExpImp2 = new cDadosAccessExpImp();
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
							Entity ent = (Entity)val2.GetObject(current, (OpenMode)0);
							DeclaracoesEntidades.StructureExportar exp = default;
							if (!XDataExpImp.LerXDataExportado(ref ent, ref exp) || !((Operators.CompareString(exp.Tipo, "B", TextCompare: true) == 0) | (Operators.CompareString(exp.Tipo, "E", TextCompare: true) == 0)))
							{
								continue;
							}
							mExp = (DeclaracoesEntidades.StructureExportar[])Utils.CopyArray(mExp, new DeclaracoesEntidades.StructureExportar[checked(Information.UBound(mExp) + 1 + 1)]);
							exp.Pagina = ent.Layer.ToString();
							bool flag = true;
							if (Operators.CompareString(exp.Handle, ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString(), TextCompare: true) != 0)
							{
								flag = false;
							}
							exp.Handle = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
							exp.DWG = DeclaracoesGeral.arqAtivo.Indice;
							exp.Caderno = DeclaracoesGeral.Conf.Local;
							string tipo = exp.Tipo;
							if (Operators.CompareString(tipo, "E", TextCompare: true) != 0)
							{
								if (Operators.CompareString(tipo, "B", TextCompare: true) == 0)
								{
									BlockReference blockRef = (BlockReference)ent;
									object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
									DeclaracoesEntidades.StructureBorne structureBorne = ((obj == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj));
									exp.numero = structureBorne.Numero;
									ref int indiceRegua = ref structureBorne.IndiceRegua;
									string sRegua = "";
									string sAlternativo = "";
									exp.Painel = DicionarioBorne.BuscaPainelDoBorneNoDicionario(ref indiceRegua, ref sRegua, ref sAlternativo);
									exp.nomePainel = Dicionario.BuscaNomeDoPainel(exp.Painel);
									exp.Texto = "";
									exp.NomeRegua = DicionarioReguas.BuscaNomeDeUmaRegua(structureBorne.IndiceRegua);
									exp.indexModelo = 0;
									exp.tag = "";
									exp.efc = "";
									if (!flag)
									{
										exp.CadernoDest = "INVALIDO";
										exp.PaginaDest = "";
									}
									else
									{
										string CadernoDest = "";
										string paginaDest = "";
										string posicaoDest = "";
										if (cDadosAccessExpImp2.carregaDestinos(exp.indice, ref CadernoDest, ref paginaDest, ref posicaoDest))
										{
											exp.CadernoDest = CadernoDest;
											exp.PaginaDest = paginaDest;
										}
									}
								}
							}
							else
							{
								BlockReference blockRef2 = (BlockReference)ent;
								object obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef2);
								DeclaracoesEntidades.StructurePortas structurePortas = ((obj2 == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj2));
								exp.numero = "";
								Entity ent2 = (Entity)(object)blockRef2;
								short painel = XDataDispositivo.BuscaPainelDispositivo(ref ent2);
								blockRef2 = (BlockReference)ent2;
								exp.Painel = painel;
								exp.nomePainel = Dicionario.BuscaNomeDoPainel(exp.Painel);
								exp.Texto = "";
								exp.NomeRegua = "";
								exp.indexModelo = structurePortas.indiceDoModelo;
								foreach (object item in blockRef2.AttributeCollection)
								{
									ObjectId val5 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
									AttributeReference val6 = (AttributeReference)val5.GetObject((OpenMode)0);
									string textString = ((DBText)val6).TextString;
									if (Operators.CompareString(val6.Tag.ToUpper(), "NOME1", TextCompare: true) == 0)
									{
										exp.tag = textString;
									}
									if (Operators.CompareString(val6.Tag.ToUpper(), "EFC", TextCompare: true) == 0)
									{
										exp.efc = textString;
									}
									if (Operators.CompareString(val6.Tag.ToUpper(), "R1", TextCompare: true) == 0)
									{
										exp.NomeRegua = textString;
									}
									if (Operators.CompareString(val6.Tag.ToUpper(), "B1", TextCompare: true) == 0)
									{
										exp.numero = textString;
									}
								}
								if (!flag)
								{
									exp.CadernoDest = "INVALIDO";
									exp.PaginaDest = "";
								}
								else
								{
									string CadernoDest2 = "";
									string paginaDest2 = "";
									string posicaoDest2 = "";
									if (cDadosAccessExpImp2.carregaDestinos(exp.indice, ref CadernoDest2, ref paginaDest2, ref posicaoDest2))
									{
										exp.CadernoDest = CadernoDest2;
										exp.PaginaDest = paginaDest2;
									}
								}
							}
							mExp[Information.UBound(mExp)] = exp;
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
					cDadosAccessExpImp2.fechaConexao();
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

	public static void ApagaXDataImportadosAuxiliaresOrfaos()
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
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected Obj, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected Obj, but got Unknown
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
						int tipo = default;
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
							DBText val6 = (DBText)(object)((val5 is DBText) ? val5 : null);
							if (val6 == null)
							{
								continue;
							}
							string handle = "";
							Entity ent = (Entity)(object)val6;
							bool flag = XDataExpImp.LerXDataAuxiliarImportado(ref ent, ref handle, ref tipo);
							val6 = (DBText)ent;
							if (flag)
							{
								BlockReference expression = (BlockReference)Geral.HandleToObject(handle);
								if (Information.IsNothing(expression))
								{
									Correcao.LimpaXData((Entity)(object)val6, "AUXIMPORTADO");
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

	public static void ApagaImportadoExportado()
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
							Entity ent = (Entity)val2.GetObject(current, (OpenMode)1);
							DeclaracoesEntidades.StructureExportar exp = default;
							if (!XDataExpImp.PossuiXDataExportado(ref ent))
							{
								if (!XDataExpImp.LerXDataImportado(ref ent, ref exp))
								{
									if (!XDataExpImp.PossuiXDataAuxiliarImportado(ref ent))
									{
										if (XDataExpImp.PossuiXDataAuxiliarExportado(ref ent))
										{
											((DBObject)ent).UpgradeOpen();
											((DBObject)ent).Erase();
										}
									}
									else
									{
										((DBObject)ent).UpgradeOpen();
										((DBObject)ent).Erase();
									}
								}
								else
								{
									((DBObject)ent).UpgradeOpen();
									((DBObject)ent).Erase();
								}
							}
							else
							{
								((DBObject)ent).UpgradeOpen();
								XDataExpImp.ApagarXDataExportado(ref ent);
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
					ProjectData.ClearProjectError();
				}
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
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

	public static void InsereBlocoErro(Entity ent)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected Obj, but got Unknown
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected Obj, but got Unknown
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected Obj, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected Obj, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected Obj, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		string text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Cadgraph\\Eletron4\\";
		string text2 = "ErroFiacao";
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		_ = Application.DocumentManager.MdiActiveDocument.Editor;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			ObjectId val = ObjectId.Null;
			BlockTable val2 = (BlockTable)topTransaction.GetObject(database.BlockTableId, (OpenMode)0);
			BlockTableRecord val3 = (BlockTableRecord)topTransaction.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)1);
			if (!((SymbolTable)val2).Has(text2))
			{
				Database val4 = new Database(false, true);
				string text3 = text + text2 + ".dwg";
				val4.ReadDwgFile(text3, FileShare.Read, true, "");
				((DBObject)val2).UpgradeOpen();
				DeclaracoesGeral.bAnularEventos = true;
				val = database.Insert(text2, val4, false);
				((DisposableWrapper)val4).Dispose();
			}
			else
			{
				BlockTableRecord val5 = (BlockTableRecord)topTransaction.GetObject(((SymbolTable)val2)[text2], (OpenMode)0);
				val = ((DBObject)val5).Id;
			}
			Extents3d value = ((Drawable)ent).Bounds.Value;
			Point3d val6 = value.MinPoint;
			double x = val6.X;
			value = ((Drawable)ent).Bounds.Value;
			val6 = value.MaxPoint;
			double num = (x + val6.X) / 2.0;
			value = ((Drawable)ent).Bounds.Value;
			val6 = value.MinPoint;
			double y = val6.Y;
			value = ((Drawable)ent).Bounds.Value;
			val6 = value.MaxPoint;
			double num2 = (y + val6.Y) / 2.0;
			Point3d val7 = new Point3d(num, num2, 0.0);
			BlockReference val8 = new BlockReference(val7, val);
			((Entity)val8).Layer = ent.Layer;
			val3.AppendEntity((Entity)(object)val8);
			DeclaracoesGeral.bAnularEventos = true;
			topTransaction.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
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

	public static void ApagaBlocoErro()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected Obj, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)1);
					if (!((SymbolTable)val3).Has("ErroFiacao"))
					{
						return;
					}
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)["ErroFiacao"], (OpenMode)1);
					ObjectIdCollection blockReferenceIds = val4.GetBlockReferenceIds(true, true);
					foreach (object item in blockReferenceIds)
					{
						ObjectId val5 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
						BlockReference val6 = (BlockReference)val2.GetObject(val5, (OpenMode)1, false, true);
						((DBObject)val6).Erase();
					}
					((DBObject)val4).Erase(true);
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
}

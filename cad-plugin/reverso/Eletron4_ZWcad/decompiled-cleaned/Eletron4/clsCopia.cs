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

namespace Eletron4;

public class clsCopia
{
	public struct structureCopia
	{
		public string sHandle;

		public string sTipo;

		public string sNome;

		public string sNomeBloco;

		public double x;

		public double y;
	}

	public struct structureATTBloco
	{
		public string Tag;

		public string sValor;

		public bool bVisivel;
	}

	public static void SelecionaBornesParaEdicao(ref structureCopia[] mListaDisp)
	{
		//IL_0841: Unknown result type (might be due to invalid IL or missing references)
		//IL_0847: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected Obj, but got Unknown
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected Obj, but got Unknown
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Invalid comparison between Unknown and I4
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected Obj, but got Unknown
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0349: Unknown result type (might be due to invalid IL or missing references)
		//IL_034f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Expected Obj, but got Unknown
		//IL_0459: Unknown result type (might be due to invalid IL or missing references)
		//IL_0460: Expected Obj, but got Unknown
		//IL_038e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0393: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0403: Unknown result type (might be due to invalid IL or missing references)
		//IL_0421: Unknown result type (might be due to invalid IL or missing references)
		//IL_0426: Unknown result type (might be due to invalid IL or missing references)
		//IL_0579: Unknown result type (might be due to invalid IL or missing references)
		//IL_0580: Expected Obj, but got Unknown
		//IL_04a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0526: Unknown result type (might be due to invalid IL or missing references)
		//IL_052b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0549: Unknown result type (might be due to invalid IL or missing references)
		//IL_054e: Unknown result type (might be due to invalid IL or missing references)
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Expected Obj, but got Unknown
		//IL_05c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Unknown result type (might be due to invalid IL or missing references)
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Unknown result type (might be due to invalid IL or missing references)
		//IL_069e: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c6: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		mListaDisp = new structureCopia[1];
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
					_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
					Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
					TypedValue[] array = new TypedValue[2];
					array.SetValue((object)new TypedValue(0, (object)"INSERT"), 0);
					array.SetValue((object)new TypedValue(1001, (object)"DISPOSITIVO"), 1);
					SelectionFilter val4 = new SelectionFilter(array);
					PromptSelectionOptions val5 = new PromptSelectionOptions();
					val5.MessageForAdding = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1370]);
					PromptSelectionResult selection = editor.GetSelection(val5, val4);
					if (unchecked((int)selection.Status) == 5100)
					{
						SelectionSet value = selection.Value;
						ObjectIdCollection val6 = new ObjectIdCollection(value.GetObjectIds());
						string text = selection.ToString().ToUpper();
						if (!text.Contains("CROSSING"))
						{
						}
						new ObjectIdCollection();
						new List<double>();
						foreach (object item in val6)
						{
							ObjectId val7 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							Entity ent = (Entity)val7.GetObject((OpenMode)0);
							if (Operators.CompareString(ent.Layer, DeclaracoesGeral.ativo.Pagina, TextCompare: true) != 0)
							{
								continue;
							}
							BlockReference blockRef = (BlockReference)(object)((ent is BlockReference) ? ent : null);
							if (blockRef == null)
							{
								continue;
							}
							string tipoImportado = "";
							string text2 = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
							string left = text2;
							Point3d position;
							if (Operators.CompareString(left, "A", TextCompare: true) != 0)
							{
								if (Operators.CompareString(left, "B", TextCompare: true) != 0)
								{
									BlockReference blockRef2;
									object obj;
									if (Operators.CompareString(left, "E", TextCompare: true) != 0)
									{
										if (Operators.CompareString(left, "P", TextCompare: true) == 0)
										{
											DeclaracoesEntidades.StructureDispositivo structureDispositivo = default;
											blockRef2 = (BlockReference)ent;
											obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef2);
											ent = (Entity)(object)blockRef2;
											object obj2 = obj;
											structureDispositivo = ((obj2 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj2));
											num++;
											mListaDisp = (structureCopia[])Utils.CopyArray(mListaDisp, new structureCopia[num + 1]);
											mListaDisp[num].sHandle = ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString();
											mListaDisp[num].sTipo = text2;
											mListaDisp[num].sNome = structureDispositivo.Nome1;
											if (Operators.CompareString(structureDispositivo.Nome2, "", TextCompare: true) != 0)
											{
												mListaDisp[num].sNome = structureDispositivo.Nome1 + "/" + structureDispositivo.Nome2;
											}
											mListaDisp[num].sNomeBloco = blockRef.Name;
											ref structureCopia reference = ref mListaDisp[num];
											position = blockRef.Position;
											reference.x = Math.Round(position.X, 0);
											ref structureCopia reference2 = ref mListaDisp[num];
											position = blockRef.Position;
											reference2.y = Math.Round(position.Y, 0);
										}
										continue;
									}
									blockRef2 = (BlockReference)ent;
									obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef2);
									ent = (Entity)(object)blockRef2;
									object obj3 = obj;
									DeclaracoesEntidades.StructurePortas structurePortas = ((obj3 == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj3));
									num++;
									mListaDisp = (structureCopia[])Utils.CopyArray(mListaDisp, new structureCopia[num + 1]);
									mListaDisp[num].sHandle = ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString();
									mListaDisp[num].sTipo = text2;
									Declaracoes2.MModeloDePortas[] mPortas = null;
									string sNomeModelo = " ";
									DicionarioMascaras.LeAsPortasDoModeloDoDicionario(ref structurePortas.indiceDoModelo, sNomeModelo, ref mPortas);
									string text3 = "";
									int num2 = Information.UBound(mPortas);
									for (int i = 1; i <= num2; i++)
									{
										if (structurePortas.indiceDaPorta == mPortas[i].IndiceDaPorta)
										{
											text3 = mPortas[i].sEFC;
											break;
										}
									}
									mListaDisp[num].sNome = structurePortas.Nome1 + " - " + text3;
									mListaDisp[num].sNomeBloco = blockRef.Name;
									ref structureCopia reference3 = ref mListaDisp[num];
									position = blockRef.Position;
									reference3.x = Math.Round(position.X, 0);
									ref structureCopia reference4 = ref mListaDisp[num];
									position = blockRef.Position;
									reference4.y = Math.Round(position.Y, 0);
								}
								else
								{
									DeclaracoesEntidades.StructureBorne structureBorne = default;
									BlockReference blockRef2 = (BlockReference)ent;
									object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef2);
									ent = (Entity)(object)blockRef2;
									object obj4 = obj;
									structureBorne = ((obj4 == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj4));
									num++;
									mListaDisp = (structureCopia[])Utils.CopyArray(mListaDisp, new structureCopia[num + 1]);
									mListaDisp[num].sHandle = ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString();
									mListaDisp[num].sTipo = text2;
									DicionarioBorne.BuscaPainelDoBorneNoDicionario(ref structureBorne.IndiceRegua, ref structureBorne.NomeRegua, ref structureBorne.Alternativo);
									mListaDisp[num].sNome = structureBorne.NomeRegua + " - " + structureBorne.Numero;
									mListaDisp[num].sNomeBloco = blockRef.Name;
									ref structureCopia reference5 = ref mListaDisp[num];
									position = blockRef.Position;
									reference5.x = Math.Round(position.X, 0);
									ref structureCopia reference6 = ref mListaDisp[num];
									position = blockRef.Position;
									reference6.y = Math.Round(position.Y, 0);
								}
							}
							else
							{
								object obj5 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
								DeclaracoesEntidades.StructureAuxiliar structureAuxiliar = ((obj5 == null) ? default(DeclaracoesEntidades.StructureAuxiliar) : ((DeclaracoesEntidades.StructureAuxiliar)obj5));
								num++;
								mListaDisp = (structureCopia[])Utils.CopyArray(mListaDisp, new structureCopia[num + 1]);
								mListaDisp[num].sHandle = ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString();
								mListaDisp[num].sTipo = text2;
								mListaDisp[num].sNome = structureAuxiliar.Nome1 + " " + Conversions.ToString(unchecked((int)structureAuxiliar.TipoDoContato));
								mListaDisp[num].sNomeBloco = blockRef.Name;
								ref structureCopia reference7 = ref mListaDisp[num];
								position = blockRef.Position;
								reference7.x = Math.Round(position.X, 0);
								ref structureCopia reference8 = ref mListaDisp[num];
								position = blockRef.Position;
								reference8.y = Math.Round(position.Y, 0);
							}
						}
					}
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
					structureCopia structureCopia2 = default;
					if (Information.UBound(mListaDisp) <= 0)
					{
						return;
					}
					int num3 = Information.UBound(mListaDisp);
					for (int j = 1; j <= num3; j++)
					{
						int num4 = Information.UBound(mListaDisp) - 1;
						int num5 = j;
						for (int k = num4; k >= num5; k += -1)
						{
							if (mListaDisp[k].y < mListaDisp[k + 1].y)
							{
								structureCopia2 = mListaDisp[k + 1];
								mListaDisp[k + 1] = mListaDisp[k];
								mListaDisp[k] = structureCopia2;
							}
							if (mListaDisp[k].y == mListaDisp[k + 1].y && mListaDisp[k].x > mListaDisp[k + 1].x)
							{
								structureCopia2 = mListaDisp[k + 1];
								mListaDisp[k + 1] = mListaDisp[k];
								mListaDisp[k] = structureCopia2;
							}
						}
					}
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

	public static void LeTodosOsAtributosDoBloco(ref string sHandle, ref structureATTBloco[] Att)
	{
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Expected Obj, but got Unknown
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected Obj, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				int num = -1;
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				_ = Application.DocumentManager.MdiActiveDocument.Editor;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					ObjectId val3 = Geral.HandleToID(sHandle);
					if (val3.IsValid)
					{
						Entity val4 = (Entity)val2.GetObject(val3, (OpenMode)0);
						BlockReference val5 = (BlockReference)(object)((val4 is BlockReference) ? val4 : null);
						if (val5 != null)
						{
							_ = (BlockTableRecord)val2.GetObject(val5.BlockTableRecord, (OpenMode)0);
							AttributeCollection attributeCollection = val5.AttributeCollection;
							foreach (object item in attributeCollection)
							{
								ObjectId val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
								AttributeReference val7 = (AttributeReference)val6.GetObject((OpenMode)0);
								num++;
								Att = (structureATTBloco[])Utils.CopyArray(Att, new structureATTBloco[num + 1]);
								Att[num].Tag = val7.Tag;
								Att[num].sValor = ((DBText)val7).TextString;
								Att[num].bVisivel = ((Entity)val7).Visible;
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
	}

	public static void AtualizaBlocosCopia()
	{
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected Obj, but got Unknown
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
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected Obj, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected Obj, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
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
							BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
							if (val6 == null)
							{
								continue;
							}
							string rev = "";
							Entity ent = (Entity)(object)val6;
							bool flag = XDataGeral.leXDataCopiaSemFuncaoEletrica(ref ent, ref rev);
							val6 = (BlockReference)ent;
							if (!flag || Operators.CompareString(rev, "", TextCompare: true) == 0)
							{
								continue;
							}
							Entity val7 = (Entity)Geral.HandleToObject(rev);
							if (val7 == null)
							{
								((DBObject)val6).UpgradeOpen();
								((DBObject)val6).Erase();
								continue;
							}
							BlockReference val8 = (BlockReference)(object)((val7 is BlockReference) ? val7 : null);
							structureATTBloco[] Att = null;
							string sHandle = ((object)((DBObject)val8).Handle/*cast due to constrained. prefix*/).ToString();
							LeTodosOsAtributosDoBloco(ref sHandle, ref Att);
							int num = Information.UBound(Att);
							for (int i = 0; i <= num; i = checked(i + 1))
							{
								sHandle = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
								clsBlocos.EditaUmAtributoDeUmBloco(ref sHandle, Att[i].Tag, Att[i].sValor, Att[i].bVisivel);
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
			throw;
		}
		finally
		{
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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
using idK5By1ORRRAapLJQ3M;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

public class clsDispositivoAuxiliares
{
	public struct StructureFuncaoAuxiliares
	{
		public int iModelo;

		public string sNome1;

		public string sNome2;

		public int iIndice;

		public string sFuncao;
	}

	public struct StructureCorrigeMODELO
	{
		public Point3d ptMod0;

		public Point3d ptMod1;

		public double dAltura0;

		public double dAltura1;

		public string sHandle;

		public string sNomeBloco;
	}

	public static bool InserirContatoAux(ref Declaracoes2.StructureContatoAuxBobina cont, bool bNomeVisivel, bool bNomeAlternativo)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected Obj, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected Obj, but got Unknown
		//IL_06b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c9: Expected Obj, but got Unknown
		//IL_06cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected Obj, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Expected Obj, but got Unknown
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Invalid comparison between Unknown and I4
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Invalid comparison between Unknown and I4
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Expected Obj, but got Unknown
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Expected Obj, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Expected Obj, but got Unknown
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f8: Expected Obj, but got Unknown
		//IL_0725: Unknown result type (might be due to invalid IL or missing references)
		//IL_072c: Expected Obj, but got Unknown
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c0: Expected Obj, but got Unknown
		//IL_0671: Unknown result type (might be due to invalid IL or missing references)
		//IL_0676: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d5: Expected Obj, but got Unknown
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Expected Obj, but got Unknown
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0412: Unknown result type (might be due to invalid IL or missing references)
		PointMonitorToolTips.StopMonitor();
		bool result = false;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				cDadosLM cDadosLM2 = new cDadosLM();
				try
				{
					string value = "";
					string value2 = "";
					ObjectId val3 = ObjectId.Null;
					BlockTable val4 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)1);
					BlockTableRecord val6 = null;
					bool flag = false;
					string text = cont.sNome1;
					string sNome = cont.sNome2;
					string sAlternativo = cont.sAlternativo;
					bool flag2 = false;
					bool flag3 = false;
					if (!((SymbolTable)val4).Has(cont.sNomeDoBloco))
					{
						Database val7 = new Database(false, true);
						val7.ReadDwgFile(cont.sCaminhoBloco, FileShare.Read, true, "");
						DeclaracoesGeral.bAnularEventos = true;
						val3 = database.Insert(cont.sNomeDoBloco, val7, false);
						((DisposableWrapper)val7).Dispose();
					}
					else
					{
						BlockTableRecord val8 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[cont.sNomeDoBloco], (OpenMode)0);
						val3 = ((DBObject)val8).Id;
					}
					BlockReference blockRef = new BlockReference(Point3d.Origin, val3);
					((Entity)blockRef).Layer = DeclaracoesGeral.ativo.Pagina;
					Jig jig = new Jig((Entity)(object)blockRef);
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
					PromptResult val9 = editor.Drag((Jig)(object)jig);
					if (((int)val9.Status == -5002) | ((int)val9.Status == -5001))
					{
						return false;
					}
					val5.AppendEntity((Entity)(object)blockRef);
					((Entity)blockRef).Draw();
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)blockRef, true);
					((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString();
					_ = blockRef.Position;
					val6 = (BlockTableRecord)val2.GetObject(val3, (OpenMode)0);
					flag = true;
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val6.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val10 = (Entity)val2.GetObject(current, (OpenMode)0);
							if (!(val10 is AttributeDefinition))
							{
								continue;
							}
							AttributeDefinition val11 = (AttributeDefinition)val10;
							string tag = val11.Tag;
							if (Operators.CompareString(tag, "NOME2", TextCompare: true) != 0)
							{
								if (Operators.CompareString(tag, "ALTERNATIVO", TextCompare: true) == 0)
								{
									flag3 = true;
								}
							}
							else
							{
								flag2 = true;
							}
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
					if ((!bNomeVisivel & bNomeAlternativo) && flag)
					{
						text = sAlternativo;
					}
					string left = Strings.Mid(blockRef.Name, 5, 2);
					ObjectId val12 = Geral.HandleToID(cont.sHandleBobina);
					checked
					{
						if (val12.IsValid)
						{
							Entity val13 = (Entity)val2.GetObject(val12, (OpenMode)0);
							try
							{
								Entity ent = val13;
								string tipoImportado = "";
								string left2 = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
								if (Operators.CompareString(left2, "P", TextCompare: true) == 0)
								{
									BlockReference blockRef2 = (BlockReference)val13;
									object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef2);
									DeclaracoesEntidades.StructureDispositivo structureDispositivo = ((obj == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj));
									Declaracoes2.MModelosDeContatos[] mModelo = null;
									DicionarioContatos.LeOsModelosDeDeDicionarioContatos(ref mModelo);
									int num = Information.UBound(mModelo);
									for (int i = 1; i <= num; i++)
									{
										if (mModelo[i].iIndiceModelo == structureDispositivo.indexModelo)
										{
											value = mModelo[i].sNomeModelo;
											break;
										}
									}
									ref int iLM = ref structureDispositivo.iLM1;
									tipoImportado = Conversions.ToString(iLM);
									string text2 = cDadosLM2.BuscaFabricanteDoMaterial(ref tipoImportado);
									iLM = Conversions.ToInteger(tipoImportado);
									value2 = text2;
								}
							}
							finally
							{
								((IDisposable)val13)?.Dispose();
							}
						}
						value = clsTextos.TiraNothing(value);
						value2 = clsTextos.TiraNothing(value2);
						BlockTableRecordEnumerator enumerator2 = default;
						try
						{
							enumerator2 = val6.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								ObjectId current = enumerator2.Current;
								Entity val14 = (Entity)val2.GetObject(current, (OpenMode)0);
								if (!(val14 is AttributeDefinition))
								{
									continue;
								}
								AttributeDefinition val15 = (AttributeDefinition)val14;
								AttributeReference val16 = new AttributeReference();
								val16.SetAttributeFromBlock(val15, blockRef.BlockTransform);
								string text3 = "";
								string tag2 = val15.Tag;
								if (Operators.CompareString(tag2, "T1", TextCompare: true) == 0 || Operators.CompareString(tag2, "T2", TextCompare: true) == 0 || Operators.CompareString(tag2, "T3", TextCompare: true) != 0)
								{
								}
								string tag3 = val15.Tag;
								if (Operators.CompareString(tag3, "PAINEL", TextCompare: true) != 0)
								{
									if (Operators.CompareString(tag3, "MODELO", TextCompare: true) != 0)
									{
										if (Operators.CompareString(tag3, "FABRICANTE", TextCompare: true) != 0)
										{
											if (Operators.CompareString(tag3, "NOME1", TextCompare: true) != 0)
											{
												if (Operators.CompareString(tag3, "NOME2", TextCompare: true) != 0)
												{
													if (Operators.CompareString(tag3, "ALTERNATIVO", TextCompare: true) != 0)
													{
														if (Operators.CompareString(tag3, "T1", TextCompare: true) != 0)
														{
															if (Operators.CompareString(tag3, "T2", TextCompare: true) != 0)
															{
																if (Operators.CompareString(tag3, "T3", TextCompare: true) == 0)
																{
																	if (Operators.CompareString(cont.sTipo, "NA", TextCompare: true) != 0)
																	{
																		text3 = cont.sT3;
																	}
																	else
																	{
																		text3 = ((Operators.CompareString(cont.sT3, "", TextCompare: true) == 0) ? cont.sT2 : cont.sT3);
																	}
																}
															}
															else if (Operators.CompareString(cont.sTipo, "RV", TextCompare: true) != 0)
															{
																text3 = cont.sT2;
															}
															else
															{
																if (Operators.CompareString(left, "NA", TextCompare: true) == 0)
																{
																	text3 = cont.sT3;
																}
																if (Operators.CompareString(left, "NF", TextCompare: true) == 0)
																{
																	text3 = cont.sT2;
																}
																if (Operators.CompareString(left, "RV", TextCompare: true) == 0)
																{
																	text3 = cont.sT2;
																}
															}
														}
														else
														{
															text3 = cont.sT1;
														}
													}
													else
													{
														text3 = sAlternativo;
														if (!bNomeAlternativo)
														{
															((Entity)val16).Visible = false;
														}
														else
														{
															((Entity)val16).Visible = true;
														}
													}
												}
												else if (bNomeVisivel)
												{
													text3 = sNome;
												}
											}
											else
											{
												if (bNomeVisivel)
												{
													if (flag2)
													{
														text3 = text;
													}
													else
													{
														text3 = ((Operators.CompareString(sNome, "", TextCompare: true) != 0) ? (text + "/" + sNome) : text);
													}
													if (bNomeAlternativo && !flag3)
													{
														text3 = ((Operators.CompareString(text3, "", TextCompare: true) != 0) ? (text3 + "/" + sAlternativo) : sAlternativo);
													}
												}
												if ((bNomeAlternativo & !flag3) && Operators.CompareString(sAlternativo, "", TextCompare: true) != 0)
												{
													text3 = sAlternativo;
												}
											}
										}
										else
										{
											text3 = value2;
										}
									}
									else
									{
										text3 = value;
									}
								}
								else
								{
									text3 = cont.sPainel;
								}
								((DBText)val16).TextString = text3;
								((DBText)val16).AdjustAlignment(database);
								blockRef.AttributeCollection.AppendAttribute(val16);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val16, true);
								((Entity)val16).Draw();
							}
						}
						finally
						{
							((IDisposable)enumerator2)?.Dispose();
						}
						((Entity)blockRef).Draw();
						DeclaracoesEntidades.StructureAuxiliar Aux = new DeclaracoesEntidades.StructureAuxiliar
						{
							Nome1 = cont.sNome1,
							Nome2 = cont.sNome2,
							HandleBob = cont.sHandleBobina,
							TipoDoContato = (short)cont.iTipo,
							TipoDoComportamento = (short)cont.iComportamento,
							Alternativo = cont.sAlternativo,
							IndexContato = cont.iIndiceContato,
							IndexModelo = cont.iIndiceModelo
						};
						cont.sHandleContato = ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString();
						XDataDispositivosMaster.GravarXDataDispAuxiliar(ref blockRef, ref Aux);
						DeclaracoesGeral.bAnularEventos = true;
						val2.Commit();
						DeclaracoesGeral.bAnularEventos = false;
						result = true;
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					Interaction.MsgBox(ex2.Message, MsgBoxStyle.Information);
					ProjectData.ClearProjectError();
				}
				finally
				{
					cDadosLM2.fechaConexao();
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

	public static void BuscaContatosUsados(ref Declaracoes2.StructureContatosAuxiliares[] mCONTATOS, string sPainel, int iIndiceModelo, string sNome)
	{
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected Obj, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected Obj, but got Unknown
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected Obj, but got Unknown
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected Obj, but got Unknown
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		int num = Dicionario.BuscaIndiceDoPainel(sPainel);
		_ = new string[2, 1];
		int num2 = Information.UBound(mCONTATOS);
		checked
		{
			for (int i = 0; i <= num2; i++)
			{
				mCONTATOS[i].sUso = "Livre";
				mCONTATOS[i].sPagina = "";
			}
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
								int num3 = 0;
								BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
								if (val6 == null)
								{
									continue;
								}
								Entity ent = (Entity)(object)val6;
								string tipoImportado = "";
								string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
								val6 = (BlockReference)ent;
								string left = text;
								if (Operators.CompareString(left, "A", TextCompare: true) != 0)
								{
									continue;
								}
								object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val6);
								DeclaracoesEntidades.StructureAuxiliar structureAuxiliar = ((obj == null) ? default(DeclaracoesEntidades.StructureAuxiliar) : ((DeclaracoesEntidades.StructureAuxiliar)obj));
								if (structureAuxiliar.IndexModelo != iIndiceModelo)
								{
									continue;
								}
								string left2 = structureAuxiliar.Nome1;
								if (Operators.CompareString(structureAuxiliar.Nome2, "", TextCompare: true) != 0)
								{
									left2 = structureAuxiliar.Nome1 + "/" + structureAuxiliar.Nome2;
								}
								if (Operators.CompareString(left2, sNome, TextCompare: true) != 0)
								{
									continue;
								}
								num3 = clsDispositivo.BuscaPainelDoDispPrincipal(structureAuxiliar.HandleBob);
								if (num3 != num)
								{
									continue;
								}
								int num4 = Information.UBound(mCONTATOS);
								for (int j = 0; j <= num4; j++)
								{
									if (structureAuxiliar.IndexContato == mCONTATOS[j].iIndice)
									{
										mCONTATOS[j].sUso = "Usado";
										mCONTATOS[j].sPagina = ((Entity)val6).Layer;
										mCONTATOS[j].sHandle = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
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
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
			}
		}
	}

	public static void BuscaUsoDosContatosAuxiliares(ref Declaracoes2.StructureContatosAuxiliares[] mCONTATOS, int iIndiceModelo)
	{
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
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected Obj, but got Unknown
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
							Entity ent = (Entity)(object)val6;
							string tipoImportado = "";
							string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
							val6 = (BlockReference)ent;
							string left = text;
							if (Operators.CompareString(left, "A", TextCompare: true) != 0)
							{
								continue;
							}
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val6);
							DeclaracoesEntidades.StructureAuxiliar structureAuxiliar = ((obj == null) ? default(DeclaracoesEntidades.StructureAuxiliar) : ((DeclaracoesEntidades.StructureAuxiliar)obj));
							if (structureAuxiliar.IndexModelo != iIndiceModelo)
							{
								continue;
							}
							clsDispositivo.BuscaPainelDoDispPrincipal(structureAuxiliar.HandleBob);
							int num = Information.UBound(mCONTATOS);
							for (int i = 1; i <= num; i = checked(i + 1))
							{
								if (structureAuxiliar.IndexContato != mCONTATOS[i].iIndice)
								{
									continue;
								}
								string text2 = Strings.Mid(val6.Name, 5, 2);
								string left2 = text2.ToUpper();
								if (Operators.CompareString(left2, "NA", TextCompare: true) != 0)
								{
									if (Operators.CompareString(left2, "NF", TextCompare: true) != 0)
									{
										if (Operators.CompareString(left2, "RV", TextCompare: true) == 0)
										{
											mCONTATOS[i].bRV = true;
										}
									}
									else
									{
										mCONTATOS[i].bNF = true;
									}
								}
								else
								{
									mCONTATOS[i].bNA = true;
								}
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
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		finally
		{
		}
	}

	public static void carregaContatosNoDG(ref DataGridView DGContatos, Declaracoes2.StructureContatosAuxiliares[] mContatos)
	{
		checked
		{
			try
			{
				DGContatos.Rows.Clear();
				DGContatos.Columns.Clear();
				if (Information.UBound(mContatos) > 0)
				{
					DGContatos.Columns.Add("IndiceModelo", "#");
					DGContatos.Columns.Add("T1", "T1");
					DGContatos.Columns.Add("T2", "T2");
					DGContatos.Columns.Add("T3", "T3");
					DGContatos.Columns.Add("Orientação", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1846]));
					DGContatos.Columns.Add("Tipo", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 995]));
					DGContatos.Columns.Add("Comportamento", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 996]));
					DGContatos.Columns.Add("Uso", Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1049], "Uso")));
					DGContatos.Columns.Add("Pagina", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 9]));
					DGContatos.Columns.Add("Handle", "Handle");
					int num = Information.UBound(mContatos);
					for (int i = 1; i <= num; i++)
					{
						DGContatos.Rows.Add(mContatos[i].iIndice, mContatos[i].sT1, mContatos[i].sT2, mContatos[i].sT3, mContatos[i].sOrientacao, mContatos[i].sTipo, mContatos[i].sComportamento, mContatos[i].sUso, mContatos[i].sPagina, mContatos[i].sHandle);
						DGContatos.Rows[DGContatos.Rows.Count - 1].Selected = false;
					}
				}
				int num2 = DGContatos.Rows.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					int num3 = 0;
					do
					{
						if (Operators.ConditionalCompareObjectEqual(DGContatos.Rows[j].Cells[num3].Value, null, TextCompare: true) && !Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(DGContatos.Rows[j].Cells[num3].Value)))
						{
							DGContatos.Rows[j].Cells[num3].Value = "";
						}
						num3++;
					}
					while (num3 <= 7);
				}
				AtualizaColunasDGContatosAuxiliaresMODELO(ref DGContatos);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
			}
		}
	}

	public static void carregaContatosAuxiliaresNoDG(ref DataGridView DGContatos, Declaracoes2.StructureContatosAuxiliares[] mContatos)
	{
		checked
		{
			try
			{
				DGContatos.Rows.Clear();
				DGContatos.Columns.Clear();
				if (Information.UBound(mContatos) > 0)
				{
					DGContatos.Columns.Add("IndiceModelo", "#");
					DGContatos.Columns.Add("T1", "T1");
					DGContatos.Columns.Add("T2", "T2");
					DGContatos.Columns.Add("T3", "T3");
					DGContatos.Columns.Add("Orientação", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1846]));
					DGContatos.Columns.Add("Tipo", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 995]));
					DGContatos.Columns.Add("Comportamento", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 996]));
					DGContatos.Columns.Add("Uso", Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1049], "Uso")));
					DGContatos.Columns.Add("Pagina", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 9]));
					DGContatos.Columns.Add("Handle", "Handle");
					int num = Information.UBound(mContatos);
					for (int i = 1; i <= num; i++)
					{
						DGContatos.Rows.Add(mContatos[i].iIndice, mContatos[i].sT1, mContatos[i].sT2, mContatos[i].sT3, mContatos[i].sOrientacao, mContatos[i].sTipo, mContatos[i].sComportamento, mContatos[i].sUso, mContatos[i].sPagina, mContatos[i].sHandle);
						DGContatos.Rows[DGContatos.Rows.Count - 1].Selected = false;
					}
				}
				int num2 = DGContatos.Rows.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					int num3 = 0;
					do
					{
						if (Operators.ConditionalCompareObjectEqual(DGContatos.Rows[j].Cells[num3].Value, null, TextCompare: true) && !Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(DGContatos.Rows[j].Cells[num3].Value)))
						{
							DGContatos.Rows[j].Cells[num3].Value = "";
						}
						num3++;
					}
					while (num3 <= 7);
				}
				AtualizaColunasDGContatosAuxiliares(ref DGContatos);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
			}
		}
	}

	public static void AtualizaTipoDoContatoDepoisDeImportarDoExcel(ref DataGridView dg, int iIndiceModelo)
	{
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
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected Obj, but got Unknown
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
								BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
								if (val6 == null)
								{
									continue;
								}
								Entity ent = (Entity)(object)val6;
								string tipoImportado = "";
								string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
								val6 = (BlockReference)ent;
								string left = text;
								if (Operators.CompareString(left, "A", TextCompare: true) != 0)
								{
									continue;
								}
								object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val6);
								DeclaracoesEntidades.StructureAuxiliar Aux = ((obj == null) ? default(DeclaracoesEntidades.StructureAuxiliar) : ((DeclaracoesEntidades.StructureAuxiliar)obj));
								if (Aux.IndexModelo != iIndiceModelo)
								{
									continue;
								}
								int num = dg.Rows.Count - 1;
								for (int i = 0; i <= num; i++)
								{
									if (!Operators.ConditionalCompareObjectEqual(Aux.IndexContato, dg.Rows[i].Cells[0].Value, TextCompare: true))
									{
										continue;
									}
									object value = dg.Rows[i].Cells[5].Value;
									if (!Operators.ConditionalCompareObjectEqual(value, "NA", TextCompare: true))
									{
										if (!Operators.ConditionalCompareObjectEqual(value, "NF", TextCompare: true))
										{
											if (Operators.ConditionalCompareObjectEqual(value, "RV", TextCompare: true))
											{
												Aux.TipoDoContato = 3;
											}
										}
										else
										{
											Aux.TipoDoContato = 2;
										}
									}
									else
									{
										Aux.TipoDoContato = 1;
									}
									XDataDispositivosMaster.GravarXDataDispAuxiliar(ref val6, ref Aux);
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
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
			}
		}
	}

	public static void selecionaContatoAuxiliarInserido(ref Declaracoes2.StructureContatoAuxBobina myBL)
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected Obj, but got Unknown
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected Obj, but got Unknown
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Expected Obj, but got Unknown
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Expected Obj, but got Unknown
		PointMonitorToolTips.StopMonitor();
		myBL.bOK = false;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		_ = Application.DocumentManager.MdiActiveDocument.Editor;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			Point3d val3 = default;
			ObjectId val2 = zy3pEH1NOE(ref val3);
			if (!val2.IsNull)
			{
				Entity ent = (Entity)val.GetObject(val2, (OpenMode)0);
				if (!Information.IsDBNull(ent))
				{
					myBL.sHandleBobina = "";
					myBL.sNomeDisp = "";
					myBL.iPainel = 0;
					string tipoImportado = "";
					string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
					if (Operators.CompareString(left, "A", TextCompare: true) == 0)
					{
						BlockReference blockRef = (BlockReference)ent;
						object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
						ent = (Entity)(object)blockRef;
						DeclaracoesEntidades.StructureAuxiliar structureAuxiliar = ((obj == null) ? default(DeclaracoesEntidades.StructureAuxiliar) : ((DeclaracoesEntidades.StructureAuxiliar)obj));
						myBL.sNome1 = structureAuxiliar.Nome1;
						myBL.sNome2 = structureAuxiliar.Nome2;
						myBL.sAlternativo = structureAuxiliar.Alternativo;
						ObjectId val4 = clsBlocos.RetornaID_Bloco(structureAuxiliar.HandleBob);
						if (val4.IsValid)
						{
							Entity val5 = (Entity)val.GetObject(val4, (OpenMode)0);
							try
							{
								Entity ent2 = val5;
								tipoImportado = "";
								left = XDataDispositivo.verificaTipoDispositivo(ref ent2, ref tipoImportado);
								if (Operators.CompareString(left, "P", TextCompare: true) == 0)
								{
									blockRef = (BlockReference)val5;
									object obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
									DeclaracoesEntidades.StructureDispositivo structureDispositivo = ((obj2 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj2));
									myBL.bOK = true;
									myBL.sPainel = Dicionario.BuscaNomeDoPainel(structureDispositivo.Painel);
									BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
									myBL.sNomeDoBloco = val6.Name;
								}
							}
							finally
							{
								((IDisposable)val5)?.Dispose();
							}
						}
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
			val.Abort();
			throw;
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		PointMonitorToolTips.StartMonitor();
	}

	private static ObjectId zy3pEH1NOE(ref Point3d P_0)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected Obj, but got Unknown
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Invalid comparison between Unknown and I4
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
		PromptEntityOptions val = new PromptEntityOptions("\r\nSelecione um Contato Auxiliar");
		val.SetRejectMessage("\r\n");
		val.AddAllowedClass(typeof(BlockReference), false);
		PromptEntityResult entity = editor.GetEntity(val);
		if ((int)((PromptResult)entity).Status == 5100)
		{
			P_0 = entity.PickedPoint;
			return entity.ObjectId;
		}
		return ObjectId.Null;
	}

	public static void AtualizaOsTerminaisAuxiliares(string sHandle, string sTipoModelo, string sT1, string sT2, string sT3, int atualizaXdata = 0)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected Obj, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Expected Obj, but got Unknown
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected Obj, but got Unknown
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_0260: Expected Obj, but got Unknown
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
					string text = "";
					if (val4 != null)
					{
						BlockReference val5 = (BlockReference)(object)((val4 is BlockReference) ? val4 : null);
						text = Strings.Mid(val5.Name, 5, 2);
						AttributeCollection attributeCollection = val5.AttributeCollection;
						string text2 = "";
						foreach (object item in attributeCollection)
						{
							ObjectId val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							text2 = "##VAZIO##";
							AttributeReference val7 = (AttributeReference)val6.GetObject((OpenMode)1);
							string tag = val7.Tag;
							if (Operators.CompareString(tag, "T1", TextCompare: true) != 0)
							{
								if (Operators.CompareString(tag, "T2", TextCompare: true) != 0)
								{
									if (Operators.CompareString(tag, "T3", TextCompare: true) == 0)
									{
										if (Operators.CompareString(sTipoModelo, "NA", TextCompare: true) != 0)
										{
											text2 = sT3;
										}
										else
										{
											text2 = ((Operators.CompareString(sT3, "", TextCompare: true) == 0) ? sT2 : sT3);
										}
									}
								}
								else if (Operators.CompareString(sTipoModelo, "RV", TextCompare: true) != 0)
								{
									text2 = sT2;
								}
								else
								{
									if (Operators.CompareString(text, "NA", TextCompare: true) == 0)
									{
										text2 = sT3;
									}
									if (Operators.CompareString(text, "NF", TextCompare: true) == 0)
									{
										text2 = sT2;
									}
									if (Operators.CompareString(text, "RV", TextCompare: true) == 0)
									{
										text2 = sT2;
									}
								}
							}
							else
							{
								text2 = sT1;
							}
							if (Operators.CompareString(text2, "##VAZIO##", TextCompare: true) != 0)
							{
								((DBObject)val7).UpgradeOpen();
								((DBText)val7).TextString = text2;
								((Entity)val7).Draw();
							}
						}
						if (atualizaXdata != 0)
						{
							BlockReference blockRef = (BlockReference)val4;
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
							val4 = (Entity)(object)blockRef;
							DeclaracoesEntidades.StructureAuxiliar Aux = ((obj == null) ? default(DeclaracoesEntidades.StructureAuxiliar) : ((DeclaracoesEntidades.StructureAuxiliar)obj));
							Aux.TipoDoContato = checked((short)atualizaXdata);
							blockRef = (BlockReference)val4;
							XDataDispositivosMaster.GravarXDataDispAuxiliar(ref blockRef, ref Aux);
							val4 = (Entity)(object)blockRef;
						}
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
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

	public static List<string> carregaNomeContatosAux(ref frmContatosAux.BlocosAuxiliares[] mBlocosAuxiliares, ref bool bCaminhoSimb)
	{
		List<string> result = new List<string>();
		bCaminhoSimb = true;
		string text = "IEC";
		if (DeclaracoesGeral.Conf.Norma == 1)
		{
			text = "ANSI";
		}
		if (Operators.CompareString(DeclaracoesGeral.Conf.DirSimbologiaEletrica, "", TextCompare: true) != 0)
		{
			if (!Directory.Exists(DeclaracoesGeral.Conf.DirSimbologiaEletrica + "Contatos\\" + text))
			{
				string prompt = Conversions.ToString(Operators.ConcatenateObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1721], " "), text.ToString()), " "), DeclaracoesGeral.mMensagem[1, 1722]), "\r\n"), DeclaracoesGeral.Conf.DirSimbologiaEletrica), "Contatos\\"));
				Interaction.MsgBox(prompt, MsgBoxStyle.Information);
				bCaminhoSimb = false;
			}
			else
			{
				result = CarregaMatrizBlocosAux(ref mBlocosAuxiliares, text);
			}
		}
		return result;
	}

	public static List<string> CarregaMatrizBlocosAux(ref frmContatosAux.BlocosAuxiliares[] mBlocosAuxiliares, string sNorma)
	{
		List<string> list = new List<string>();
		int num = 0;
		mBlocosAuxiliares = new frmContatosAux.BlocosAuxiliares[1];
		mBlocosAuxiliares[0].NomeDWG = "Nome do DWG Visivel";
		mBlocosAuxiliares[0].CaminhoCompleto = "Caminho Completo";
		mBlocosAuxiliares[0].Tipo = "Tipo";
		mBlocosAuxiliares[0].Comportamento = "Comportamento";
		mBlocosAuxiliares[0].Quantidadede = 0;
		DirectoryInfo directoryInfo = new DirectoryInfo(DeclaracoesGeral.Conf.DirSimbologiaEletrica + "\\Contatos\\" + sNorma);
		FileInfo[] files = directoryInfo.GetFiles();
		string text = "";
		string sNomeDWGVisivel = "";
		string sDiretorio = "";
		string sTipo = "";
		string sComportamento = "";
		int num2 = 0;
		FileInfo[] array = files;
		checked
		{
			foreach (FileInfo fileInfo in array)
			{
				text = fileInfo.FullName.ToString().ToUpper();
				string[] array2 = text.Split('\\');
				string item = array2[Information.UBound(array2)];
				if (Operators.CompareString(Strings.UCase(Strings.Mid(text, Strings.Len(text) - 2, 3)), "DWG", TextCompare: true) == 0)
				{
					num2 = 0;
					string sCaminhoCompleto = text;
					string iQuantNomes = Conversions.ToString(0);
					bool flag = clsDispositivo.ExtraiNomeCaminhoDwgPorTipoAux(sCaminhoCompleto, ref sDiretorio, ref sNomeDWGVisivel, ref sTipo, ref sComportamento, ref iQuantNomes);
					num2 = Conversions.ToInteger(iQuantNomes);
					if (!flag)
					{
						list.Add(item);
					}
					else if ((Operators.CompareString(sNomeDWGVisivel.Trim(), "", TextCompare: true) != 0) & (Operators.CompareString(sTipo, "", TextCompare: true) != 0) & (num2 > 0) & (Operators.CompareString(sComportamento, "", TextCompare: true) != 0))
					{
						num++;
						mBlocosAuxiliares = (frmContatosAux.BlocosAuxiliares[])Utils.CopyArray(mBlocosAuxiliares, new frmContatosAux.BlocosAuxiliares[num + 1]);
						mBlocosAuxiliares[num].NomeDWG = sNomeDWGVisivel;
						mBlocosAuxiliares[num].CaminhoCompleto = text;
						mBlocosAuxiliares[num].Tipo = sTipo;
						mBlocosAuxiliares[num].Comportamento = sComportamento;
						mBlocosAuxiliares[num].Quantidadede = num2;
					}
				}
			}
			return list;
		}
	}

	public static void CarregaOsPaineisEmUsoPelosContatos(ref ComboBox combo)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected Obj, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected Obj, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected Obj, but got Unknown
		List<int> list = new List<int>();
		DeclaracoesGeral.bAnularEventos = true;
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
							BlockReference blockRef = (BlockReference)(object)((ent is BlockReference) ? ent : null);
							if (blockRef == null)
							{
								continue;
							}
							string tipoImportado = "";
							string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
							if (Operators.CompareString(left, "P", TextCompare: true) == 0)
							{
								object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
								DeclaracoesEntidades.StructureDispositivo structureDispositivo = ((obj == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj));
								if (structureDispositivo.indexModelo > 0 && !list.Contains(structureDispositivo.Painel))
								{
									list.Add(structureDispositivo.Painel);
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
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			combo.Items.Clear();
			foreach (int item in list)
			{
				if (!DeclaracoesGeral.dicPainel.ContainsKey(item))
				{
					combo.Items.Add(Operators.ConcatenateObject(item + " - ", DeclaracoesGeral.mMensagem[1, 1170]));
					continue;
				}
				combo.Items.Add(DeclaracoesGeral.dicPainel[item]);
				if (Operators.CompareString(combo.Text.Trim(), "", TextCompare: true) == 0)
				{
					combo.Text = DeclaracoesGeral.dicPainel[item];
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		finally
		{
			DeclaracoesGeral.bAnularEventos = false;
		}
	}

	public static void CarregaOsContatosAuxiliares(DataGridView dgDisp, ref DataGridView dgContatos, string sPainel)
	{
		Declaracoes2.StructureContatosAuxiliares[] mCONTATOS = null;
		if (dgDisp.SelectedRows.Count > 0)
		{
			int iIndiceSelecionado = Conversions.ToInteger(dgDisp.SelectedRows[0].Cells[0].Value);
			string sNome = Conversions.ToString(dgDisp.SelectedRows[0].Cells[1].Value);
			DicionarioContatos.LeOsContatosAuxiliarDoModeloDoDicionario(ref iIndiceSelecionado, ref mCONTATOS);
			BuscaContatosUsados(ref mCONTATOS, sPainel, iIndiceSelecionado, sNome);
			carregaContatosAuxiliaresNoDG(ref dgContatos, mCONTATOS);
		}
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		dataGridViewCellStyle.BackColor = Color.LightGreen;
		checked
		{
			int num = dgContatos.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				int num2 = 0;
				do
				{
					dgContatos.Rows[i].Cells[num2].Style = dataGridViewCellStyle;
					num2++;
				}
				while (num2 <= 7);
			}
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			dataGridViewCellStyle2.BackColor = Color.LightCoral;
			int num3 = dgContatos.Rows.Count - 1;
			for (int j = 0; j <= num3; j++)
			{
				int num4 = Information.UBound(mCONTATOS);
				for (int k = 1; k <= num4; k++)
				{
					if (!Operators.ConditionalCompareObjectEqual(dgContatos.Rows[j].Cells[0].Value, mCONTATOS[k].iIndice, TextCompare: true))
					{
						continue;
					}
					if (Operators.CompareString(mCONTATOS[k].sUso, "Usado", TextCompare: true) == 0)
					{
						int num5 = 0;
						do
						{
							dgContatos.Rows[j].Cells[num5].Style = dataGridViewCellStyle2;
							num5++;
						}
						while (num5 <= 7);
					}
					break;
				}
				dgContatos.Rows[j].Selected = false;
			}
			int num6 = dgContatos.Rows.Count - 1;
			for (int l = 0; l <= num6; l++)
			{
				if (dgContatos.Rows[l].Cells[0].Style.BackColor == Color.LightGreen)
				{
					dgContatos.Rows[l].Selected = true;
					dgContatos.CurrentCell = dgContatos.Rows[l].Cells[1];
					break;
				}
			}
			AtualizaColunasDGContatosAuxiliares(ref dgContatos);
		}
	}

	public static string carregaDGContatosAuxiliares(ref DataGridView Dg, ref DataGridView DgContatos, ref frmContatosAux Paleta, ref frmContatosAux.BlocosAuxiliares[] mBlocosAuxiliares, int iQuantidadeDeNomes)
	{
		string sTipoContato = "";
		string sComportamentoContato = "";
		buscaTipoDoContatoSelecionado(DgContatos, ref sTipoContato, ref sComportamentoContato);
		string result = "";
		checked
		{
			try
			{
				if (DgContatos.RowCount != 0 && Information.UBound(mBlocosAuxiliares) != 0)
				{
					bool flag = false;
					double a = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(Dg)) ? ((double)(Dg.Width - 4)) : ((double)(Dg.Width - 21)));
					Dg.Rows.Clear();
					Dg.Columns.Clear();
					Dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 997]));
					Dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 998]));
					Dg.ColumnHeadersVisible = false;
					Dg.Columns[0].Width = (int)Math.Round(a);
					Dg.Columns[1].Width = 0;
					Dg.Columns[0].Visible = true;
					Dg.Columns[1].Visible = false;
					Dg.Columns[0].ReadOnly = false;
					Dg.Columns[1].ReadOnly = false;
					Dg.MultiSelect = false;
					if (Information.UBound(mBlocosAuxiliares) >= 2 && Information.UBound(mBlocosAuxiliares) > 0)
					{
						int num = Information.UBound(mBlocosAuxiliares) - 1;
						for (int i = num; i >= 1; i += -1)
						{
							int num2 = i;
							for (int j = 1; j <= num2; j++)
							{
								if (Operators.CompareString(mBlocosAuxiliares[j].NomeDWG, mBlocosAuxiliares[j + 1].NomeDWG, TextCompare: true) > 0)
								{
									frmContatosAux.BlocosAuxiliares blocosAuxiliares = mBlocosAuxiliares[j + 1];
									mBlocosAuxiliares[j + 1] = mBlocosAuxiliares[j];
									mBlocosAuxiliares[j] = blocosAuxiliares;
								}
							}
						}
					}
					if (Operators.CompareString(sTipoContato, "RV", TextCompare: true) != 0)
					{
						int num3 = Information.UBound(mBlocosAuxiliares);
						for (int k = 1; k <= num3; k++)
						{
							if (Operators.CompareString(sTipoContato, mBlocosAuxiliares[k].Tipo, TextCompare: true) == 0 && iQuantidadeDeNomes == mBlocosAuxiliares[k].Quantidadede && Operators.CompareString(sComportamentoContato, mBlocosAuxiliares[k].Comportamento, TextCompare: true) == 0)
							{
								Dg.Rows.Add(mBlocosAuxiliares[k].NomeDWG, mBlocosAuxiliares[k].CaminhoCompleto);
								flag = true;
							}
						}
					}
					else
					{
						int num4 = Information.UBound(mBlocosAuxiliares);
						for (int l = 1; l <= num4; l++)
						{
							if (iQuantidadeDeNomes == mBlocosAuxiliares[l].Quantidadede && Operators.CompareString(sComportamentoContato, mBlocosAuxiliares[l].Comportamento, TextCompare: true) == 0)
							{
								Dg.Rows.Add(mBlocosAuxiliares[l].NomeDWG, mBlocosAuxiliares[l].CaminhoCompleto);
								flag = true;
							}
						}
					}
					a = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(Dg)) ? ((double)(Dg.Width - 4)) : ((double)(Dg.Width - 21)));
					Dg.Columns[0].Width = (int)Math.Round(a);
					Dg.Columns[1].Width = 0;
					if (flag)
					{
						Dg.Rows[0].Selected = true;
						result = Conversions.ToString(Dg.Rows[0].Cells[1].Value);
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
			}
			return result;
		}
	}

	public static void buscaTipoDoContatoSelecionado(DataGridView dgContatos, ref string sTipoContato, ref string sComportamentoContato)
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		dataGridViewCellStyle.BackColor = Color.LightCoral;
		checked
		{
			int num = dgContatos.Rows.Count - 1;
			int num2 = 0;
			while (true)
			{
				if (num2 <= num)
				{
					if (dgContatos.Rows[num2].Selected)
					{
						break;
					}
					num2++;
					continue;
				}
				return;
			}
			if (!(dgContatos.Rows[num2].Cells[0].Style.BackColor == Color.LightGreen))
			{
				sTipoContato = "";
				sComportamentoContato = "";
				dgContatos.Rows[num2].Selected = false;
			}
			else
			{
				sTipoContato = Conversions.ToString(dgContatos.Rows[num2].Cells[5].Value);
				sComportamentoContato = Conversions.ToString(dgContatos.Rows[num2].Cells[6].Value);
			}
		}
	}

	public static void CarregaContatosAuxiliaresInseridos(ref DataGridView dg, string sPainel)
	{
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Expected Obj, but got Unknown
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Expected Obj, but got Unknown
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Expected Obj, but got Unknown
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Expected Obj, but got Unknown
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Expected Obj, but got Unknown
		//IL_03d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03da: Unknown result type (might be due to invalid IL or missing references)
		dg.Rows.Clear();
		dg.Columns.Clear();
		dg.Columns.Add("Indice", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 999]));
		dg.Columns.Add("Dispositivo", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1000]));
		dg.Columns.Add("Nome1", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1001]));
		dg.Columns.Add("Nome2", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1002]));
		dg.Columns.Add("Nome3", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1003]));
		dg.Columns.Add("Handle", "Handle");
		dg.ColumnHeadersVisible = true;
		dg.MultiSelect = false;
		checked
		{
			if (haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg))
			{
				double num = dg.Width - 21;
			}
			else
			{
				double num = dg.Width - 4;
			}
			int num2 = Dicionario.BuscaIndiceDoPainel(sPainel);
			string[,] array = null;
			array = new string[6, 1]
			{
				{ "Indice do Modelo" },
				{ "Nome" },
				{ "Nome1" },
				{ "Nome2" },
				{ "Alternativo" },
				{ "Handle" }
			};
			bool flag = true;
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
								Entity Ent = (Entity)val2.GetObject(current, (OpenMode)0);
								object obj = "";
								Declaracoes2.StructureModelo Modelo = default;
								if (!XDataDispositivosMaster.LerXDataModelo(ref Ent, ref Modelo) || Modelo.indexContato != 0)
								{
									continue;
								}
								Entity val5 = (Entity)Geral.HandleToObject(Modelo.HandleBob);
								if (val5 == null)
								{
									continue;
								}
								BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
								if (val6 == null)
								{
									continue;
								}
								Entity ent = (Entity)(object)val6;
								string tipoImportado = "";
								string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
								val6 = (BlockReference)ent;
								string left = text;
								if (Operators.CompareString(left, "P", TextCompare: true) != 0)
								{
									continue;
								}
								object obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val6);
								DeclaracoesEntidades.StructureDispositivo structureDispositivo = ((obj2 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj2));
								if (structureDispositivo.Painel != num2)
								{
									continue;
								}
								flag = true;
								obj = structureDispositivo.Nome1;
								if (Operators.CompareString(structureDispositivo.Nome2, "", TextCompare: true) != 0)
								{
									obj = structureDispositivo.Nome1 + "/" + structureDispositivo.Nome2;
								}
								int num3 = Information.UBound(array, 2);
								for (int i = 1; i <= num3; i++)
								{
									if (Operators.ConditionalCompareObjectEqual(array[1, i], obj, TextCompare: true))
									{
										flag = false;
										break;
									}
								}
								if (flag)
								{
									array = (string[,])Utils.CopyArray(array, new string[6, Information.UBound(array, 2) + 1 + 1]);
									array[0, Information.UBound(array, 2)] = Conversions.ToString(structureDispositivo.indexModelo);
									array[1, Information.UBound(array, 2)] = Conversions.ToString(obj);
									array[2, Information.UBound(array, 2)] = structureDispositivo.Nome1;
									array[3, Information.UBound(array, 2)] = structureDispositivo.Nome2;
									array[4, Information.UBound(array, 2)] = structureDispositivo.Alternativo;
									array[5, Information.UBound(array, 2)] = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
								}
							}
						}
						finally
						{
							((IDisposable)enumerator)?.Dispose();
						}
						if (Information.UBound(array, 2) >= 2 && Information.UBound(array, 2) > 0)
						{
							int num4 = Information.UBound(array, 2) - 1;
							for (int j = num4; j >= 1; j += -1)
							{
								int num5 = j;
								for (int k = 1; k <= num5; k++)
								{
									if (Operators.CompareString(array[0, k], array[0, k + 1], TextCompare: true) > 0)
									{
										int num6 = 0;
										do
										{
											object obj3 = array[num6, k + 1];
											array[num6, k + 1] = array[num6, k];
											array[num6, k] = Conversions.ToString(obj3);
											num6++;
										}
										while (num6 <= 5);
									}
								}
							}
						}
						int num7 = Information.UBound(array, 2);
						for (int l = 1; l <= num7; l++)
						{
							dg.Rows.Add(array[0, l], array[1, l], array[2, l], array[3, l], array[4, l], array[5, l]);
						}
						double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg)) ? ((double)(dg.Width - 4)) : ((double)(dg.Width - 21)));
						dg.Columns[0].Visible = false;
						dg.Columns[1].Visible = true;
						dg.Columns[2].Visible = false;
						dg.Columns[3].Visible = false;
						dg.Columns[4].Visible = false;
						dg.Columns[5].Visible = false;
						dg.Columns[0].Width = 0;
						dg.Columns[1].Width = (int)Math.Round(num);
						dg.Columns[2].Width = 0;
						dg.Columns[3].Width = 0;
						dg.Columns[4].Width = 0;
						dg.Columns[5].Width = 0;
						dg.Columns[0].ReadOnly = false;
						dg.Columns[1].ReadOnly = false;
						dg.Columns[2].ReadOnly = false;
						dg.Columns[3].ReadOnly = false;
						dg.Columns[4].ReadOnly = false;
						dg.Columns[5].ReadOnly = false;
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
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
			}
		}
	}

	public static void AtualizaColunasDGContatosAuxiliares(ref DataGridView DGContatos)
	{
		if (DGContatos.RowCount == 0)
		{
			return;
		}
		checked
		{
			double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(DGContatos)) ? ((double)(DGContatos.Width - 5)) : ((double)(DGContatos.Width - 21)));
			DGContatos.Columns[0].Width = 0;
			DGContatos.Columns[1].Width = (int)Math.Round(num * 0.2);
			DGContatos.Columns[2].Width = (int)Math.Round(num * 0.2);
			DGContatos.Columns[3].Width = (int)Math.Round(num * 0.2);
			DGContatos.Columns[4].Width = 0;
			DGContatos.Columns[5].Width = (int)Math.Round(num * 0.2);
			DGContatos.Columns[6].Width = (int)Math.Round(num * 0.2);
			DGContatos.Columns[7].Width = 0;
			DGContatos.Columns[8].Width = 0;
			DGContatos.Columns[9].Width = 0;
			DGContatos.Columns[0].Visible = false;
			DGContatos.Columns[1].Visible = true;
			DGContatos.Columns[2].Visible = true;
			DGContatos.Columns[3].Visible = true;
			DGContatos.Columns[4].Visible = false;
			DGContatos.Columns[5].Visible = true;
			DGContatos.Columns[6].Visible = true;
			DGContatos.Columns[7].Visible = false;
			DGContatos.Columns[8].Visible = false;
			DGContatos.Columns[9].Visible = false;
			DGContatos.Columns[0].ReadOnly = false;
			DGContatos.Columns[1].ReadOnly = false;
			DGContatos.Columns[2].ReadOnly = false;
			DGContatos.Columns[3].ReadOnly = false;
			DGContatos.Columns[4].ReadOnly = false;
			DGContatos.Columns[5].ReadOnly = false;
			DGContatos.Columns[6].ReadOnly = false;
			DGContatos.Columns[7].ReadOnly = false;
			DGContatos.Columns[8].ReadOnly = false;
			DGContatos.Columns[9].ReadOnly = false;
			DGContatos.MultiSelect = false;
			int num2 = DGContatos.Columns.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				DGContatos.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
			}
			foreach (DataGridViewRow item in (IEnumerable)DGContatos.Rows)
			{
				DGContatos.Rows[item.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			}
		}
	}

	public static void AtualizaColunasDGContatosAuxiliaresMODELO(ref DataGridView DGContatos)
	{
		if (DGContatos.RowCount == 0)
		{
			return;
		}
		checked
		{
			double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(DGContatos)) ? ((double)(DGContatos.Width - 5)) : ((double)(DGContatos.Width - 21)));
			DGContatos.Columns[0].Width = 0;
			DGContatos.Columns[1].Width = (int)Math.Round(num * 0.166);
			DGContatos.Columns[2].Width = (int)Math.Round(num * 0.166);
			DGContatos.Columns[3].Width = (int)Math.Round(num * 0.166);
			DGContatos.Columns[4].Width = (int)Math.Round(num * 0.167);
			DGContatos.Columns[5].Width = (int)Math.Round(num * 0.166);
			DGContatos.Columns[6].Width = (int)Math.Round(num * 0.166);
			DGContatos.Columns[7].Width = 0;
			DGContatos.Columns[8].Width = 0;
			DGContatos.Columns[9].Width = 0;
			DGContatos.Columns[0].Visible = false;
			DGContatos.Columns[1].Visible = true;
			DGContatos.Columns[2].Visible = true;
			DGContatos.Columns[3].Visible = true;
			DGContatos.Columns[4].Visible = true;
			DGContatos.Columns[5].Visible = true;
			DGContatos.Columns[6].Visible = true;
			DGContatos.Columns[7].Visible = false;
			DGContatos.Columns[8].Visible = false;
			DGContatos.Columns[9].Visible = false;
			DGContatos.Columns[0].ReadOnly = false;
			DGContatos.Columns[1].ReadOnly = false;
			DGContatos.Columns[2].ReadOnly = false;
			DGContatos.Columns[3].ReadOnly = false;
			DGContatos.Columns[4].ReadOnly = false;
			DGContatos.Columns[5].ReadOnly = false;
			DGContatos.Columns[6].ReadOnly = false;
			DGContatos.Columns[7].ReadOnly = false;
			DGContatos.Columns[8].ReadOnly = false;
			DGContatos.Columns[9].ReadOnly = false;
			DGContatos.MultiSelect = false;
			int num2 = DGContatos.Columns.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				DGContatos.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
			}
			foreach (DataGridViewRow item in (IEnumerable)DGContatos.Rows)
			{
				DGContatos.Rows[item.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			}
		}
	}

	public static void carregaContatosAuxiliaresDoModeloInserido(ref DataGridView DGContatosInseridos, int indexModelo, int indexContato)
	{
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected Obj, but got Unknown
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected Obj, but got Unknown
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected Obj, but got Unknown
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Expected Obj, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		DGContatosInseridos.Rows.Clear();
		DGContatosInseridos.Columns.Clear();
		DGContatosInseridos.Columns.Add("Nome", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 987]));
		DGContatosInseridos.Columns.Add("PG", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 993]));
		DGContatosInseridos.Columns.Add("Bloco", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 987]));
		DGContatosInseridos.Columns.Add("Handle", "Handle");
		DGContatosInseridos.ColumnHeadersVisible = true;
		DGContatosInseridos.MultiSelect = false;
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
								Entity ent = (Entity)val2.GetObject(current, (OpenMode)0);
								string text = "";
								string tipoImportado = "";
								string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
								if (Operators.CompareString(left, "A", TextCompare: true) != 0)
								{
									continue;
								}
								BlockReference blockRef = (BlockReference)ent;
								object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
								ent = (Entity)(object)blockRef;
								DeclaracoesEntidades.StructureAuxiliar structureAuxiliar = ((obj == null) ? default(DeclaracoesEntidades.StructureAuxiliar) : ((DeclaracoesEntidades.StructureAuxiliar)obj));
								if (structureAuxiliar.IndexModelo == indexModelo && structureAuxiliar.IndexContato == indexContato)
								{
									if (Operators.CompareString(structureAuxiliar.Nome2, "", TextCompare: true) != 0)
									{
										structureAuxiliar.Nome1 = structureAuxiliar.Nome1 + "/" + structureAuxiliar.Nome2;
									}
									BlockReference val5 = (BlockReference)(object)((ent is BlockReference) ? ent : null);
									if (val5 != null)
									{
										text = val5.Name;
									}
									DGContatosInseridos.Rows.Add(structureAuxiliar.Nome1, ent.Layer, text, ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString());
									DGContatosInseridos.Rows[DGContatosInseridos.RowCount - 1].Selected = false;
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
				int num = DGContatosInseridos.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					int num2 = 0;
					do
					{
						if (Operators.ConditionalCompareObjectEqual(DGContatosInseridos.Rows[i].Cells[num2].Value, null, TextCompare: true) && !Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(DGContatosInseridos.Rows[i].Cells[num2].Value)))
						{
							DGContatosInseridos.Rows[i].Cells[num2].Value = "";
						}
						num2++;
					}
					while (num2 <= 3);
				}
				clsDispositivo.AtualizaColunasDGContatosInseridos(ref DGContatosInseridos);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
			}
		}
	}

	public static void carregaDispPrincipalDoModeloInserido(ref DataGridView DGContatosInseridos, int indexModelo)
	{
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected Obj, but got Unknown
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected Obj, but got Unknown
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected Obj, but got Unknown
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Expected Obj, but got Unknown
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		DGContatosInseridos.Rows.Clear();
		DGContatosInseridos.Columns.Clear();
		DGContatosInseridos.Columns.Add("Nome", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 987]));
		DGContatosInseridos.Columns.Add("PG", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 993]));
		DGContatosInseridos.Columns.Add("Bloco", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 987]));
		DGContatosInseridos.Columns.Add("Handle", "Handle");
		DGContatosInseridos.ColumnHeadersVisible = true;
		DGContatosInseridos.MultiSelect = false;
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
								Entity ent = (Entity)val2.GetObject(current, (OpenMode)0);
								string text = "";
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
								if (structureDispositivo.indexModelo == indexModelo)
								{
									if (Operators.CompareString(structureDispositivo.Nome2, "", TextCompare: true) != 0)
									{
										structureDispositivo.Nome1 = structureDispositivo.Nome1 + "/" + structureDispositivo.Nome2;
									}
									BlockReference val5 = (BlockReference)(object)((ent is BlockReference) ? ent : null);
									if (val5 != null)
									{
										text = val5.Name;
									}
									DGContatosInseridos.Rows.Add(structureDispositivo.Nome1, ent.Layer, text, ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString());
									DGContatosInseridos.Rows[DGContatosInseridos.RowCount - 1].Selected = false;
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
				int num = DGContatosInseridos.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					int num2 = 0;
					do
					{
						if (Operators.ConditionalCompareObjectEqual(DGContatosInseridos.Rows[i].Cells[num2].Value, null, TextCompare: true) && !Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(DGContatosInseridos.Rows[i].Cells[num2].Value)))
						{
							DGContatosInseridos.Rows[i].Cells[num2].Value = "";
						}
						num2++;
					}
					while (num2 <= 3);
				}
				clsDispositivo.AtualizaColunasDGContatosInseridos(ref DGContatosInseridos);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
			}
		}
	}

	public static void EditaNomeDoModelo(string sHandle, string sNome1, string sNome2, string sAlternativo, bool bNome, bool bAlternativo)
	{
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
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
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
							Entity Ent = (Entity)val2.GetObject(current, (OpenMode)0);
							BlockReference val5 = (BlockReference)(object)((Ent is BlockReference) ? Ent : null);
							if (val5 == null)
							{
								continue;
							}
							Declaracoes2.StructureModelo Modelo = default;
							if (!XDataDispositivosMaster.LerXDataModelo(ref Ent, ref Modelo) || Operators.CompareString(Modelo.HandleBob, sHandle, TextCompare: true) != 0 || Modelo.indexContato != 0)
							{
								continue;
							}
							string text = "";
							if (bNome)
							{
								text = sNome1;
								if (Operators.CompareString(sNome2, "", TextCompare: true) != 0)
								{
									text = text + "/" + sNome2;
								}
							}
							if (bAlternativo)
							{
								if (Operators.CompareString(text, "", TextCompare: true) != 0)
								{
									text += "/";
								}
								text += sAlternativo;
							}
							string sHandle2 = ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString();
							clsBlocos.EditaUmAtributoDeUmBloco(ref sHandle2, "NOME", text);
							break;
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
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public static void EditaNomeDoContatoAuxiliar(string sHandle, string sNome1, string sNome2, string sAlternativo, bool bNome, bool bAlternativo)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected Obj, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected Obj, but got Unknown
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected Obj, but got Unknown
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected Obj, but got Unknown
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
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
							string tipoImportado = "";
							string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
							if (Operators.CompareString(left, "A", TextCompare: true) != 0)
							{
								continue;
							}
							BlockReference blockRef = (BlockReference)ent;
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
							ent = (Entity)(object)blockRef;
							DeclaracoesEntidades.StructureAuxiliar Aux = ((obj == null) ? default(DeclaracoesEntidades.StructureAuxiliar) : ((DeclaracoesEntidades.StructureAuxiliar)obj));
							if (Operators.CompareString(Aux.HandleBob, sHandle, TextCompare: true) != 0)
							{
								continue;
							}
							string text = "";
							if (bNome)
							{
								text = sNome1;
								if (Operators.CompareString(sNome2, "", TextCompare: true) != 0)
								{
									text = text + "/" + sNome2;
								}
							}
							Aux.Nome1 = sNome1;
							Aux.Nome2 = sNome2;
							Aux.Alternativo = sAlternativo;
							blockRef = (BlockReference)ent;
							XDataDispositivosMaster.GravarXDataDispAuxiliar(ref blockRef, ref Aux);
							ent = (Entity)(object)blockRef;
							tipoImportado = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
							clsBlocos.EditaNomesDeUmBloco(ref tipoImportado, sNome1, sNome2, sAlternativo);
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
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public static void criaInsercaoTabela(ref Declaracoes2.StructureContatoAuxBobina cont)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected Obj, but got Unknown
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected Obj, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected Obj, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Expected Obj, but got Unknown
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_063e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0646: Unknown result type (might be due to invalid IL or missing references)
		//IL_064d: Expected Obj, but got Unknown
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Expected Obj, but got Unknown
		//IL_032e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Expected Obj, but got Unknown
		//IL_061b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0621: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0451: Unknown result type (might be due to invalid IL or missing references)
		//IL_0458: Expected Obj, but got Unknown
		//IL_05c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d8: Expected Obj, but got Unknown
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Expected Obj, but got Unknown
		//IL_0561: Unknown result type (might be due to invalid IL or missing references)
		//IL_0568: Expected Obj, but got Unknown
		//IL_04a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a7: Expected Obj, but got Unknown
		//IL_04ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f6: Expected Obj, but got Unknown
		//IL_0402: Unknown result type (might be due to invalid IL or missing references)
		//IL_0409: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				DeclaracoesGeral.Reguas RH = default;
				bool flag = false;
				DeclaracoesGeral.Reguas RH2 = default;
				bool flag2 = false;
				flag = XDataGeral.LeXDataReguaH(ref RH);
				flag2 = XDataGeral.LeXDataReguaV(ref RH2);
				try
				{
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					BlockReference val5 = null;
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						Declaracoes2.StructureModelo Modelo;
						BlockReference val7;
						Entity Ent;
						while (true)
						{
							if (!enumerator.MoveNext())
							{
								return;
							}
							ObjectId current = enumerator.Current;
							Entity val6 = (Entity)current.GetObject((OpenMode)0);
							val7 = (BlockReference)(object)((val6 is BlockReference) ? val6 : null);
							if (val7 != null)
							{
								Modelo = default;
								Ent = (Entity)(object)val7;
								bool flag3 = XDataDispositivosMaster.LerXDataModelo(ref Ent, ref Modelo);
								val7 = (BlockReference)Ent;
								if (flag3 && ((Operators.CompareString(Modelo.HandleBob, cont.sHandleBobina, TextCompare: true) == 0) & (Modelo.indexModelo == cont.iIndiceModelo) & (Modelo.indexContato == cont.iIndiceContato)))
								{
									break;
								}
							}
						}
						AttributeCollection attributeCollection = val7.AttributeCollection;
						bool flag4 = false;
						bool flag5 = false;
						ObjectId val8;
						foreach (object item in attributeCollection)
						{
							val8 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							AttributeReference val9 = (AttributeReference)val8.GetObject((OpenMode)0);
							string left = val9.Tag.ToUpper();
							if (Operators.CompareString(left, "INSERCAONA", TextCompare: true) != 0)
							{
								if (Operators.CompareString(left, "INSERCAONF", TextCompare: true) == 0)
								{
									flag5 = true;
								}
							}
							else
							{
								flag4 = true;
							}
						}
						ObjectId val10 = Geral.HandleToID(cont.sHandleContato);
						if (val10.IsValid)
						{
							val5 = (BlockReference)val2.GetObject(val10, (OpenMode)0);
						}
						string pagina = ((Entity)val5).Layer.ToString();
						Ent = (Entity)(object)val5;
						string posicao = Pagina.calculaLinhaColuna(ref Ent, ref RH, ref RH2, flag, flag2);
						val5 = (BlockReference)Ent;
						string textString = Pagina.montaCruzamentoPagina(pagina, posicao);
						string textString2 = "";
						foreach (object item2 in attributeCollection)
						{
							val8 = ((item2 == null) ? default(ObjectId) : ((ObjectId)item2));
							AttributeReference val11 = (AttributeReference)val8.GetObject((OpenMode)1);
							if (Operators.CompareString(val11.Tag.ToUpper(), "INSERCAO", TextCompare: true) == 0)
							{
								if ((cont.iTipo == 1) | (cont.iTipo == 2))
								{
									((DBObject)val11).UpgradeOpen();
									((DBText)val11).TextString = textString;
									((Entity)val11).Draw();
									string pagina2 = ((Entity)val7).Layer.ToString();
									Ent = (Entity)(object)val7;
									posicao = Pagina.calculaLinhaColuna(ref Ent, ref RH, ref RH2, flag, flag2);
									val7 = (BlockReference)Ent;
									textString2 = Pagina.montaCruzamentoPagina(pagina2, posicao);
								}
								if ((cont.iTipo == 3) & (Operators.CompareString(cont.sTipoBlocoContato, "RV", TextCompare: true) == 0))
								{
									((DBObject)val11).UpgradeOpen();
									((DBText)val11).TextString = textString;
									((Entity)val11).Draw();
									string pagina3 = ((Entity)val7).Layer.ToString();
									Ent = (Entity)(object)val7;
									posicao = Pagina.calculaLinhaColuna(ref Ent, ref RH, ref RH2, flag, flag2);
									val7 = (BlockReference)Ent;
									textString2 = Pagina.montaCruzamentoPagina(pagina3, posicao);
								}
								if ((cont.iTipo == 3) & (Operators.CompareString(cont.sTipoBlocoContato, "NA", TextCompare: true) == 0) & !flag4)
								{
									((DBObject)val11).UpgradeOpen();
									((DBText)val11).TextString = textString;
									((Entity)val11).Draw();
									string pagina4 = ((Entity)val7).Layer.ToString();
									Ent = (Entity)(object)val7;
									posicao = Pagina.calculaLinhaColuna(ref Ent, ref RH, ref RH2, flag, flag2);
									val7 = (BlockReference)Ent;
									textString2 = Pagina.montaCruzamentoPagina(pagina4, posicao);
								}
								if ((cont.iTipo == 3) & (Operators.CompareString(cont.sTipoBlocoContato, "NF", TextCompare: true) == 0) & !flag5)
								{
									((DBObject)val11).UpgradeOpen();
									((DBText)val11).TextString = textString;
									((Entity)val11).Draw();
									string pagina5 = ((Entity)val7).Layer.ToString();
									Ent = (Entity)(object)val7;
									posicao = Pagina.calculaLinhaColuna(ref Ent, ref RH, ref RH2, flag, flag2);
									val7 = (BlockReference)Ent;
									textString2 = Pagina.montaCruzamentoPagina(pagina5, posicao);
								}
							}
							if (Operators.CompareString(val11.Tag.ToUpper(), "INSERCAONA", TextCompare: true) == 0 && ((cont.iTipo == 3) & (Operators.CompareString(cont.sTipoBlocoContato, "NA", TextCompare: true) == 0)))
							{
								((DBObject)val11).UpgradeOpen();
								((DBText)val11).TextString = textString;
								((Entity)val11).Draw();
								string pagina6 = ((Entity)val7).Layer.ToString();
								Ent = (Entity)(object)val7;
								posicao = Pagina.calculaLinhaColuna(ref Ent, ref RH, ref RH2, flag, flag2);
								val7 = (BlockReference)Ent;
								textString2 = Pagina.montaCruzamentoPagina(pagina6, posicao);
							}
							if (Operators.CompareString(val11.Tag.ToUpper(), "INSERCAONF", TextCompare: true) == 0 && ((cont.iTipo == 3) & (Operators.CompareString(cont.sTipoBlocoContato, "NF", TextCompare: true) == 0)))
							{
								((DBObject)val11).UpgradeOpen();
								((DBText)val11).TextString = textString;
								((Entity)val11).Draw();
								string pagina7 = ((Entity)val7).Layer.ToString();
								Ent = (Entity)(object)val7;
								posicao = Pagina.calculaLinhaColuna(ref Ent, ref RH, ref RH2, flag, flag2);
								val7 = (BlockReference)Ent;
								textString2 = Pagina.montaCruzamentoPagina(pagina7, posicao);
							}
						}
						Modelo.HandleContatoAux = cont.sHandleContato;
						XDataDispositivosMaster.GravarXDataDispModelo(ref val7, ref Modelo);
						attributeCollection = val5.AttributeCollection;
						IEnumerator enumerator4 = attributeCollection.GetEnumerator();
						try
						{
							AttributeReference val12;
							do
							{
								if (enumerator4.MoveNext())
								{
									object current4 = enumerator4.Current;
									val8 = ((current4 == null) ? default(ObjectId) : ((ObjectId)current4));
									val12 = (AttributeReference)val8.GetObject((OpenMode)1);
									continue;
								}
								return;
							}
							while (Operators.CompareString(val12.Tag.ToUpper(), "ORIGEM", TextCompare: true) != 0);
							((DBObject)val12).UpgradeOpen();
							((DBText)val12).TextString = textString2;
							((Entity)val12).Draw();
						}
						finally
						{
							IDisposable disposable = enumerator4 as IDisposable;
							if (disposable != null)
							{
								disposable.Dispose();
							}
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					val2.Abort();
					throw;
				}
				finally
				{
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
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
	}

	public static void AtualizaInsercaoTabela(ref Declaracoes2.StructureContatoAuxBobina cont, ref BlockReference blockContato)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected Obj, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected Obj, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected Obj, but got Unknown
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Expected Obj, but got Unknown
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected Obj, but got Unknown
		//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				DeclaracoesGeral.Reguas RH = default;
				bool flag = false;
				DeclaracoesGeral.Reguas RH2 = default;
				bool flag2 = false;
				flag = XDataGeral.LeXDataReguaH(ref RH);
				flag2 = XDataGeral.LeXDataReguaV(ref RH2);
				try
				{
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						BlockReference val6;
						Entity Ent;
						while (true)
						{
							if (!enumerator.MoveNext())
							{
								return;
							}
							ObjectId current = enumerator.Current;
							Entity val5 = (Entity)current.GetObject((OpenMode)0);
							val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
							if (val6 != null)
							{
								Declaracoes2.StructureModelo Modelo = default;
								Ent = (Entity)(object)val6;
								bool flag3 = XDataDispositivosMaster.LerXDataModelo(ref Ent, ref Modelo);
								val6 = (BlockReference)Ent;
								if (flag3 && ((Operators.CompareString(Modelo.HandleBob, cont.sHandleBobina, TextCompare: true) == 0) & (Modelo.indexModelo == cont.iIndiceModelo) & (Modelo.indexContato == cont.iIndiceContato) & (Operators.CompareString(Modelo.HandleContatoAux, ((object)((DBObject)blockContato).Handle/*cast due to constrained. prefix*/).ToString(), TextCompare: true) == 0)))
								{
									break;
								}
							}
						}
						AttributeCollection attributeCollection = val6.AttributeCollection;
						bool flag4 = false;
						bool flag5 = false;
						ObjectId val7;
						foreach (object item in attributeCollection)
						{
							val7 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							AttributeReference val8 = (AttributeReference)val7.GetObject((OpenMode)0);
							string left = val8.Tag.ToUpper();
							if (Operators.CompareString(left, "INSERCAONA", TextCompare: true) != 0)
							{
								if (Operators.CompareString(left, "INSERCAONF", TextCompare: true) == 0)
								{
									flag5 = true;
								}
							}
							else
							{
								flag4 = true;
							}
						}
						string pagina = ((Entity)blockContato).Layer.ToString();
						Ent = (Entity)(object)blockContato;
						string posicao = Pagina.calculaLinhaColuna(ref Ent, ref RH, ref RH2, flag, flag2);
						blockContato = (BlockReference)Ent;
						string textString = Pagina.montaCruzamentoPagina(pagina, posicao);
						foreach (object item2 in attributeCollection)
						{
							val7 = ((item2 == null) ? default(ObjectId) : ((ObjectId)item2));
							AttributeReference val9 = (AttributeReference)val7.GetObject((OpenMode)1);
							if (Operators.CompareString(val9.Tag.ToUpper(), "INSERCAO", TextCompare: true) == 0)
							{
								if ((cont.iTipo == 1) | (cont.iTipo == 2))
								{
									((DBObject)val9).UpgradeOpen();
									((DBText)val9).TextString = textString;
								}
								if ((cont.iTipo == 3) & (Operators.CompareString(cont.sTipoBlocoContato, "RV", TextCompare: true) == 0))
								{
									((DBObject)val9).UpgradeOpen();
									((DBText)val9).TextString = textString;
								}
								if ((cont.iTipo == 3) & (Operators.CompareString(cont.sTipoBlocoContato, "NA", TextCompare: true) == 0) & !flag4)
								{
									((DBObject)val9).UpgradeOpen();
									((DBText)val9).TextString = textString;
								}
								if ((cont.iTipo == 3) & (Operators.CompareString(cont.sTipoBlocoContato, "NF", TextCompare: true) == 0) & !flag5)
								{
									((DBObject)val9).UpgradeOpen();
									((DBText)val9).TextString = textString;
								}
							}
							if (Operators.CompareString(val9.Tag.ToUpper(), "INSERCAONA", TextCompare: true) == 0 && ((cont.iTipo == 3) & (Operators.CompareString(cont.sTipoBlocoContato, "NA", TextCompare: true) == 0)))
							{
								((DBObject)val9).UpgradeOpen();
								((DBText)val9).TextString = textString;
							}
							if (Operators.CompareString(val9.Tag.ToUpper(), "INSERCAONF", TextCompare: true) == 0 && ((cont.iTipo == 3) & (Operators.CompareString(cont.sTipoBlocoContato, "NF", TextCompare: true) == 0)))
							{
								((DBObject)val9).UpgradeOpen();
								((DBText)val9).TextString = textString;
							}
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					val2.Abort();
					throw;
				}
				finally
				{
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
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
	}

	public static void limpaInsercaoTabela(string handle)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected Obj, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected Obj, but got Unknown
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				try
				{
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val5 = (Entity)current.GetObject((OpenMode)0);
							BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
							if (val6 == null)
							{
								continue;
							}
							Declaracoes2.StructureModelo Modelo = default;
							Entity Ent = (Entity)(object)val6;
							bool flag = XDataDispositivosMaster.LerXDataModelo(ref Ent, ref Modelo);
							val6 = (BlockReference)Ent;
							if (!flag || Operators.CompareString(Modelo.HandleContatoAux, handle, TextCompare: true) != 0)
							{
								continue;
							}
							AttributeCollection attributeCollection = val6.AttributeCollection;
							foreach (object item in attributeCollection)
							{
								ObjectId val7 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
								AttributeReference val8 = (AttributeReference)val7.GetObject((OpenMode)1);
								if ((Operators.CompareString(val8.Tag.ToUpper(), "INSERCAO", TextCompare: true) == 0) | (Operators.CompareString(val8.Tag.ToUpper(), "INSERCAONA", TextCompare: true) == 0) | (Operators.CompareString(val8.Tag.ToUpper(), "INSERCAONF", TextCompare: true) == 0))
								{
									((DBObject)val8).UpgradeOpen();
									((DBText)val8).TextString = "";
									((Entity)val8).Draw();
								}
							}
							Modelo.HandleContatoAux = "";
							XDataDispositivosMaster.GravarXDataDispModelo(ref val6, ref Modelo);
							break;
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
					Form form = Application.OpenForms["frmContatosAux"];
					if (!Information.IsNothing(form))
					{
						frmContatosAux frmContatosAux2 = (frmContatosAux)form;
						frmContatosAux2.AtualizadgDisp();
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					val2.Abort();
					throw;
				}
				finally
				{
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
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
	}

	public static void ApagaModelo(string handleBobina)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected Obj, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				try
				{
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val5 = (Entity)current.GetObject((OpenMode)0);
							BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
							if (val6 != null)
							{
								Declaracoes2.StructureModelo Modelo = default;
								Entity Ent = (Entity)(object)val6;
								bool flag = XDataDispositivosMaster.LerXDataModelo(ref Ent, ref Modelo);
								val6 = (BlockReference)Ent;
								if (flag && Operators.CompareString(Modelo.HandleBob, handleBobina, TextCompare: true) == 0)
								{
									((DBObject)val6).UpgradeOpen();
									((DBObject)val6).Erase();
								}
							}
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					val2.Abort();
					throw;
				}
				finally
				{
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
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
	}

	public static void AtualizaContatos(string handleBobina, int indexModelo, Declaracoes2.StructureContatosAuxiliares[] mContatos)
	{
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
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected Obj, but got Unknown
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
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
								Entity ent = (Entity)val2.GetObject(current, (OpenMode)0);
								BlockReference blockRef = (BlockReference)(object)((ent is BlockReference) ? ent : null);
								if (blockRef == null)
								{
									continue;
								}
								string tipoImportado = "";
								string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
								if (Operators.CompareString(left, "A", TextCompare: true) != 0)
								{
									continue;
								}
								BlockReference blockRef2 = (BlockReference)ent;
								object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef2);
								ent = (Entity)(object)blockRef2;
								DeclaracoesEntidades.StructureAuxiliar Aux = ((obj == null) ? default(DeclaracoesEntidades.StructureAuxiliar) : ((DeclaracoesEntidades.StructureAuxiliar)obj));
								if (Operators.CompareString(Aux.HandleBob, handleBobina, TextCompare: true) != 0)
								{
									continue;
								}
								string sValor = "";
								string sValor2 = "";
								string sValor3 = "";
								Aux.IndexModelo = indexModelo;
								string left2 = Strings.Mid(blockRef.Name, 5, 2);
								int num = Information.UBound(mContatos);
								for (int i = 0; i <= num; i++)
								{
									if (mContatos[i].iIndice != Aux.IndexContato)
									{
										continue;
									}
									Aux.TipoDoContato = (short)mContatos[i].iT;
									if (Aux.TipoDoContato != 1)
									{
										if (Aux.TipoDoContato != 2)
										{
											if (Aux.TipoDoContato == 3)
											{
												if (Operators.CompareString(left2, "NA", TextCompare: true) == 0)
												{
													sValor = mContatos[i].sT1;
													sValor2 = mContatos[i].sT3;
													sValor3 = mContatos[i].sT3;
												}
												if (Operators.CompareString(left2, "NF", TextCompare: true) == 0)
												{
													sValor = mContatos[i].sT1;
													sValor2 = mContatos[i].sT2;
													sValor3 = mContatos[i].sT2;
												}
												if (Operators.CompareString(left2, "RV", TextCompare: true) == 0)
												{
													sValor = mContatos[i].sT1;
													sValor2 = mContatos[i].sT2;
													sValor3 = mContatos[i].sT3;
												}
											}
										}
										else
										{
											sValor = mContatos[i].sT1;
											sValor2 = mContatos[i].sT2;
											sValor3 = mContatos[i].sT2;
										}
									}
									else
									{
										sValor = mContatos[i].sT1;
										sValor2 = mContatos[i].sT2;
										sValor3 = mContatos[i].sT2;
									}
									break;
								}
								XDataDispositivosMaster.GravarXDataDispAuxiliar(ref blockRef, ref Aux);
								tipoImportado = ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString();
								clsBlocos.EditaUmAtributoDeUmBloco(ref tipoImportado, "T1", sValor);
								tipoImportado = ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString();
								clsBlocos.EditaUmAtributoDeUmBloco(ref tipoImportado, "T2", sValor2);
								tipoImportado = ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString();
								clsBlocos.EditaUmAtributoDeUmBloco(ref tipoImportado, "T3", sValor3);
								Declaracoes2.StructureContatoAuxBobina cont = new Declaracoes2.StructureContatoAuxBobina
								{
									sHandleBobina = handleBobina,
									iIndiceModelo = indexModelo,
									iIndiceContato = Aux.IndexContato,
									iTipo = Aux.TipoDoContato,
									sHandleContato = ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString(),
									sTipoBlocoContato = Strings.Mid(blockRef.Name, 5, 2)
								};
								criaInsercaoTabela(ref cont);
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
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static bool podeTrocarModelo(string handleBobina, int indexModeloAntigo, int indexModeloNovo, Declaracoes2.MModelosDeContatos[] mMODELO)
	{
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected Obj, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected Obj, but got Unknown
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected Obj, but got Unknown
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected Obj, but got Unknown
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		bool result = true;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					Declaracoes2.StructureContatosAuxiliares[] mCONTATOS = null;
					Declaracoes2.StructureContatosAuxiliares[] mCONTATOS2 = null;
					int num = 0;
					int num2 = 0;
					DicionarioContatos.LeOsContatosAuxiliarDoModeloDoDicionario(ref indexModeloAntigo, ref mCONTATOS);
					Information.UBound(mCONTATOS);
					DicionarioContatos.LeOsContatosAuxiliarDoModeloDoDicionario(ref indexModeloNovo, ref mCONTATOS2);
					num2 = Information.UBound(mCONTATOS2);
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
							Entity ent = (Entity)(object)val6;
							string tipoImportado = "";
							string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
							val6 = (BlockReference)ent;
							string left = text;
							if (Operators.CompareString(left, "A", TextCompare: true) != 0)
							{
								continue;
							}
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val6);
							DeclaracoesEntidades.StructureAuxiliar structureAuxiliar = ((obj == null) ? default(DeclaracoesEntidades.StructureAuxiliar) : ((DeclaracoesEntidades.StructureAuxiliar)obj));
							if (Operators.CompareString(handleBobina, structureAuxiliar.HandleBob, TextCompare: true) != 0)
							{
								continue;
							}
							string sTipoUsados = Strings.Mid(val6.Name, 5, 2);
							int num3 = Information.UBound(mCONTATOS);
							for (int i = 1; i <= num3; i++)
							{
								if (mCONTATOS[i].iIndice == structureAuxiliar.IndexContato)
								{
									mCONTATOS[i].sUso = "USADO";
									mCONTATOS[i].sHandle = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
									mCONTATOS[i].sTipoUsados = sTipoUsados;
									mCONTATOS[i].sPagina = ((Entity)val6).Layer;
									if (structureAuxiliar.IndexContato > num)
									{
										num = structureAuxiliar.IndexContato;
									}
									break;
								}
							}
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
					if (num <= num2)
					{
						int num4 = Information.UBound(mCONTATOS2);
						for (int j = 1; j <= num4; j++)
						{
							int num5 = Information.UBound(mCONTATOS);
							int num6 = 1;
							while (num6 <= num5)
							{
								if (mCONTATOS2[j].iIndice != mCONTATOS[num6].iIndice)
								{
									num6++;
									continue;
								}
								goto IL_026d;
							}
							continue;
							IL_026d:
							if (Operators.CompareString(mCONTATOS[num6].sUso, "USADO", TextCompare: true) != 0)
							{
								continue;
							}
							string sTipo = mCONTATOS[num6].sTipo;
							if (Operators.CompareString(sTipo, "NA", TextCompare: true) != 0)
							{
								if (Operators.CompareString(sTipo, "NF", TextCompare: true) != 0)
								{
									if (Operators.CompareString(sTipo, "RV", TextCompare: true) == 0)
									{
										if (((Operators.CompareString(mCONTATOS[num6].sTipoUsados, "NA", TextCompare: true) == 0) | (Operators.CompareString(mCONTATOS[num6].sTipoUsados, "NF", TextCompare: true) == 0)) && Operators.CompareString(mCONTATOS[num6].sTipoUsados, mCONTATOS2[j].sTipo, TextCompare: true) != 0 && Operators.CompareString(mCONTATOS2[j].sTipo, "RV", TextCompare: true) != 0)
										{
											result = false;
											break;
										}
										if (Operators.CompareString(mCONTATOS[num6].sTipoUsados, "RV", TextCompare: true) == 0 && Operators.CompareString(mCONTATOS[num6].sTipoUsados, mCONTATOS2[j].sTipo, TextCompare: true) != 0)
										{
											result = false;
											break;
										}
									}
								}
								else if (Operators.CompareString(mCONTATOS2[j].sTipo, "NA", TextCompare: true) == 0)
								{
									result = false;
									break;
								}
							}
							else if (Operators.CompareString(mCONTATOS2[j].sTipo, "NF", TextCompare: true) == 0)
							{
								result = false;
								break;
							}
						}
					}
					else
					{
						result = false;
					}
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
					return result;
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
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

	public static void SincronizaContatos(int indexModelo = 0, bool bMarcaErros = true)
	{
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected Obj, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Expected Obj, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Expected Obj, but got Unknown
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected Obj, but got Unknown
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Expected Obj, but got Unknown
		//IL_036e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0430: Unknown result type (might be due to invalid IL or missing references)
		//IL_0437: Expected Obj, but got Unknown
		//IL_0462: Unknown result type (might be due to invalid IL or missing references)
		//IL_0467: Unknown result type (might be due to invalid IL or missing references)
		//IL_0589: Unknown result type (might be due to invalid IL or missing references)
		//IL_0590: Expected Obj, but got Unknown
		//IL_05b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bd: Expected Obj, but got Unknown
		//IL_0741: Unknown result type (might be due to invalid IL or missing references)
		//IL_0747: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fe: Expected Obj, but got Unknown
		DeclaracoesGeral.Reguas RH = default;
		bool flag = false;
		DeclaracoesGeral.Reguas RH2 = default;
		bool flag2 = false;
		flag = XDataGeral.LeXDataReguaH(ref RH);
		flag2 = XDataGeral.LeXDataReguaV(ref RH2);
		string[,] array = new string[7, 1]
		{
			{ "HANDLE BOBINA" },
			{ "MODELO" },
			{ "INDICE" },
			{ "PAGINA" },
			{ "TIPO DO CONTATO" },
			{ "HANDLE DO BLOCO DO CONTATO" },
			{ "TIPO DO BLOCO USADO" }
		};
		string[,] array2 = new string[6, 1]
		{
			{ "HANDLE BOBINA" },
			{ "MODELO" },
			{ "INDICE" },
			{ "PAGINA" },
			{ "HANDLE CONTATO" },
			{ "HANDLE DO BLOCO DO MODELO" }
		};
		string[,] array3 = new string[2, 1];
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
								Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
								BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
								if (val6 == null)
								{
									continue;
								}
								Entity ent = (Entity)(object)val6;
								string tipoImportado = "";
								string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
								val6 = (BlockReference)ent;
								if (Operators.CompareString(left, "A", TextCompare: true) != 0)
								{
									Declaracoes2.StructureModelo Modelo = default;
									ent = (Entity)(object)val6;
									bool flag3 = XDataDispositivosMaster.LerXDataModelo(ref ent, ref Modelo);
									val6 = (BlockReference)ent;
									if (!flag3 || ((indexModelo > 0) & (Modelo.indexModelo != indexModelo)))
									{
										continue;
									}
									bool flag4 = true;
									if (Modelo.indexContato <= 0)
									{
										continue;
									}
									int num = Information.UBound(array2, 2);
									for (int i = 1; i <= num; i++)
									{
										if ((Operators.CompareString(array2[0, i], Modelo.HandleBob, TextCompare: true) == 0) & (Conversions.ToDouble(array2[1, i]) == (double)Modelo.indexModelo) & (Conversions.ToDouble(array2[2, i]) == (double)Modelo.indexContato))
										{
											long num2 = Information.UBound(array3, 2) + 1;
											array3 = (string[,])Utils.CopyArray(array3, new string[2, (int)num2 + 1]);
											array3[0, (int)num2] = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
											array3[1, (int)num2] = ((Entity)val6).Layer;
											flag4 = false;
											break;
										}
									}
									if (flag4)
									{
										long num2 = Information.UBound(array2, 2) + 1;
										array2 = (string[,])Utils.CopyArray(array2, new string[6, (int)num2 + 1]);
										array2[0, (int)num2] = Modelo.HandleBob;
										array2[1, (int)num2] = Conversions.ToString(Modelo.indexModelo);
										array2[2, (int)num2] = Conversions.ToString(Modelo.indexContato);
										string[,] array4 = array2;
										int num3 = (int)num2;
										string pagina = ((Entity)val6).Layer.ToString();
										ent = (Entity)(object)val6;
										left = Pagina.calculaLinhaColuna(ref ent, ref RH, ref RH2, flag, flag2);
										val6 = (BlockReference)ent;
										array4[3, num3] = Pagina.montaCruzamentoPagina(pagina, left);
										array2[4, (int)num2] = Modelo.HandleContatoAux;
										array2[5, (int)num2] = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
									}
									continue;
								}
								DeclaracoesEntidades.StructureAuxiliar structureAuxiliar = default;
								object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val6);
								structureAuxiliar = ((obj == null) ? default(DeclaracoesEntidades.StructureAuxiliar) : ((DeclaracoesEntidades.StructureAuxiliar)obj));
								if ((indexModelo > 0) & (structureAuxiliar.IndexModelo != indexModelo))
								{
									continue;
								}
								bool flag5 = true;
								int num4 = Information.UBound(array, 2);
								for (int j = 1; j <= num4; j++)
								{
									if ((Operators.CompareString(array[0, j], structureAuxiliar.HandleBob, TextCompare: true) == 0) & (Conversions.ToDouble(array[1, j]) == (double)structureAuxiliar.IndexModelo) & (Conversions.ToDouble(array[2, j]) == (double)structureAuxiliar.IndexContato))
									{
										long num2 = Information.UBound(array3, 2) + 1;
										array3 = (string[,])Utils.CopyArray(array3, new string[2, (int)num2 + 1]);
										array3[0, (int)num2] = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
										array3[1, (int)num2] = val5.Layer;
										flag5 = false;
										break;
									}
								}
								if (flag5)
								{
									long num2 = Information.UBound(array, 2) + 1;
									array = (string[,])Utils.CopyArray(array, new string[7, (int)num2 + 1]);
									array[0, (int)num2] = structureAuxiliar.HandleBob;
									array[1, (int)num2] = Conversions.ToString(structureAuxiliar.IndexModelo);
									array[2, (int)num2] = Conversions.ToString(structureAuxiliar.IndexContato);
									string[,] array5 = array;
									int num5 = (int)num2;
									string pagina2 = ((Entity)val6).Layer.ToString();
									ent = (Entity)(object)val6;
									left = Pagina.calculaLinhaColuna(ref ent, ref RH, ref RH2, flag, flag2);
									val6 = (BlockReference)ent;
									array5[3, num5] = Pagina.montaCruzamentoPagina(pagina2, left);
									array[4, (int)num2] = Conversions.ToString(unchecked((int)structureAuxiliar.TipoDoContato));
									array[5, (int)num2] = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
									array[6, (int)num2] = Strings.Mid(val6.Name, 5, 2);
								}
							}
						}
						finally
						{
							((IDisposable)enumerator)?.Dispose();
						}
						int num6 = Information.UBound(array2, 2);
						for (int k = 1; k <= num6; k++)
						{
							clsBlocos.IndefineCruzamentoDoBloco(ref array2[5, k]);
						}
						int num7 = Information.UBound(array, 2);
						for (int l = 1; l <= num7; l++)
						{
							clsBlocos.IndefineCruzamentoDoBloco(ref array[5, l]);
						}
						if ((Information.UBound(array, 2) > 0) & (Information.UBound(array2, 2) > 0))
						{
							int num8 = Information.UBound(array, 2);
							for (int m = 1; m <= num8; m++)
							{
								int num9 = Information.UBound(array2, 2);
								for (int n = 1; n <= num9; n++)
								{
									if (Operators.CompareString(array[5, m], array2[4, n], TextCompare: true) != 0)
									{
										continue;
									}
									BlockReference val7 = (BlockReference)Geral.HandleToObject(array2[5, n]);
									if (val7 == null)
									{
										continue;
									}
									AttributeCollection attributeCollection = val7.AttributeCollection;
									bool flag6 = false;
									bool flag7 = false;
									foreach (object item in attributeCollection)
									{
										ObjectId val8 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
										AttributeReference val9 = (AttributeReference)val8.GetObject((OpenMode)0);
										string left2 = val9.Tag.ToUpper();
										if (Operators.CompareString(left2, "INSERCAONA", TextCompare: true) != 0)
										{
											if (Operators.CompareString(left2, "INSERCAONF", TextCompare: true) == 0)
											{
												flag7 = true;
											}
										}
										else
										{
											flag6 = true;
										}
									}
									clsBlocos.AtualizaValorDeUmAtributo(ref array[5, m], "ORIGEM", array2[3, n]);
									if (!((Conversions.ToDouble(array[4, m]) == 1.0) | (Conversions.ToDouble(array[4, m]) == 2.0)))
									{
										if (Conversions.ToDouble(array[4, m]) != 3.0)
										{
											break;
										}
										if (Operators.CompareString(array[6, m], "NA", TextCompare: true) != 0)
										{
											if (Operators.CompareString(array[6, m], "NF", TextCompare: true) != 0)
											{
												if (Operators.CompareString(array[6, m], "RV", TextCompare: true) == 0)
												{
													clsBlocos.AtualizaValorDeUmAtributo(ref array2[5, n], "INSERCAO", array[3, m]);
												}
											}
											else if (!flag7)
											{
												clsBlocos.AtualizaValorDeUmAtributo(ref array2[5, n], "INSERCAO", array[3, m]);
											}
											else
											{
												clsBlocos.AtualizaValorDeUmAtributo(ref array2[5, n], "INSERCAONF", array[3, m]);
											}
										}
										else if (!flag6)
										{
											clsBlocos.AtualizaValorDeUmAtributo(ref array2[5, n], "INSERCAO", array[3, m]);
										}
										else
										{
											clsBlocos.AtualizaValorDeUmAtributo(ref array2[5, n], "INSERCAONA", array[3, m]);
										}
									}
									else
									{
										clsBlocos.AtualizaValorDeUmAtributo(ref array2[5, n], "INSERCAO", array[3, m]);
									}
									break;
								}
							}
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
	}

	public static void ApagaContatosOrfaos()
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected Obj, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected Obj, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected Obj, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected Obj, but got Unknown
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected Obj, but got Unknown
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Expected Obj, but got Unknown
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected Obj, but got Unknown
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
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
						BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
						if (val6 == null)
						{
							continue;
						}
						Entity ent = (Entity)(object)val6;
						string tipoImportado = "";
						string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
						val6 = (BlockReference)ent;
						string left = text;
						if (Operators.CompareString(left, "P", TextCompare: true) == 0)
						{
							BlockReference blockRef = (BlockReference)val5;
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
							val5 = (Entity)(object)blockRef;
							object obj2 = obj;
							DeclaracoesEntidades.StructureDispositivo structureDispositivo = ((obj2 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj2));
							if (!structureDispositivo.Complementar & (structureDispositivo.indexModelo > 0))
							{
								list.Add(((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString());
							}
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				BlockTableRecordEnumerator enumerator2 = default;
				try
				{
					enumerator2 = val4.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						ObjectId current2 = enumerator2.Current;
						Entity val7 = (Entity)val2.GetObject(current2, (OpenMode)0);
						BlockReference val8 = (BlockReference)(object)((val7 is BlockReference) ? val7 : null);
						if (val8 == null)
						{
							continue;
						}
						Entity ent = (Entity)(object)val8;
						string text = "";
						string tipoImportado = XDataDispositivo.verificaTipoDispositivo(ref ent, ref text);
						val8 = (BlockReference)ent;
						string left2 = tipoImportado;
						if (Operators.CompareString(left2, "A", TextCompare: true) == 0)
						{
							BlockReference blockRef = (BlockReference)val7;
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
							val7 = (Entity)(object)blockRef;
							object obj3 = obj;
							if (!list.Contains(((obj3 == null) ? default(DeclaracoesEntidades.StructureAuxiliar) : ((DeclaracoesEntidades.StructureAuxiliar)obj3)).HandleBob))
							{
								((DBObject)val7).UpgradeOpen();
								((DBObject)val7).Erase();
							}
						}
					}
				}
				finally
				{
					((IDisposable)enumerator2)?.Dispose();
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

	public static bool BuscaModeloVisivel(string sHandle)
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
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected Obj, but got Unknown
		bool result = false;
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
						if (val6 != null)
						{
							Declaracoes2.StructureModelo Modelo = default;
							Entity Ent = (Entity)(object)val6;
							bool flag = XDataDispositivosMaster.LerXDataModelo(ref Ent, ref Modelo);
							val6 = (BlockReference)Ent;
							if (flag && Operators.CompareString(Modelo.HandleBob, sHandle, TextCompare: true) == 0)
							{
								result = !((Entity)val6).Visible;
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
		return result;
	}

	public static void EditaNomeDoModeloDosDispositivos(string sHandle, string sNome1, string sNome2, string sAlternativo)
	{
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
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
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
							Entity Ent = (Entity)val2.GetObject(current, (OpenMode)0);
							BlockReference val5 = (BlockReference)(object)((Ent is BlockReference) ? Ent : null);
							if (val5 == null)
							{
								continue;
							}
							Declaracoes2.StructureModelo Modelo = default;
							if (XDataDispositivosMaster.LerXDataModelo(ref Ent, ref Modelo) && Operators.CompareString(Modelo.HandleBob, sHandle, TextCompare: true) == 0 && Modelo.indexContato == 0)
							{
								string text = "";
								text = sNome1;
								if (Operators.CompareString(sNome2, "", TextCompare: true) != 0)
								{
									text = text + "/" + sNome2;
								}
								string sHandle2 = ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString();
								clsBlocos.EditaUmAtributoDeUmBloco(ref sHandle2, "NOME", text);
								if (Operators.CompareString(sAlternativo, "", TextCompare: true) != 0)
								{
									sHandle2 = ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString();
									clsBlocos.EditaUmAtributoDeUmBloco(ref sHandle2, "ALTERNATIVO", sAlternativo);
								}
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
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public static void EditaNomeDoContatoAuxiliarDispositivos(string sHandle, string sNome1, string sNome2, string sAlternativo)
	{
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
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected Obj, but got Unknown
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Expected Obj, but got Unknown
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
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
							string tipoImportado = "";
							string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
							if (Operators.CompareString(left, "A", TextCompare: true) != 0)
							{
								continue;
							}
							BlockReference blockRef = (BlockReference)ent;
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
							ent = (Entity)(object)blockRef;
							DeclaracoesEntidades.StructureAuxiliar Aux = ((obj == null) ? default(DeclaracoesEntidades.StructureAuxiliar) : ((DeclaracoesEntidades.StructureAuxiliar)obj));
							if (Operators.CompareString(Aux.HandleBob, sHandle, TextCompare: true) == 0)
							{
								string text = "";
								text = sNome1;
								if (Operators.CompareString(sNome2, "", TextCompare: true) != 0)
								{
									text = text + "/" + sNome2;
								}
								Aux.Nome1 = sNome1;
								Aux.Nome2 = sNome2;
								Aux.Alternativo = sAlternativo;
								blockRef = (BlockReference)ent;
								XDataDispositivosMaster.GravarXDataDispAuxiliar(ref blockRef, ref Aux);
								ent = (Entity)(object)blockRef;
								tipoImportado = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
								clsBlocos.EditaNomesDeUmBloco(ref tipoImportado, Aux.Nome1, Aux.Nome2, Aux.Alternativo);
								if (Operators.CompareString(sAlternativo, "", TextCompare: true) != 0)
								{
									tipoImportado = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
									clsBlocos.EditaUmAtributoDeUmBloco(ref tipoImportado, "ALTERNATIVO", sAlternativo);
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
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public static bool ExisteDispositivoAuxiliar(int iIndiceModelo, int iIndiceContato)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected Obj, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected Obj, but got Unknown
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected Obj, but got Unknown
		bool result = false;
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
							Entity ent = (Entity)(object)val6;
							string tipoImportado = "";
							string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
							val6 = (BlockReference)ent;
							if (Operators.CompareString(left, "A", TextCompare: true) == 0)
							{
								object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val6);
								DeclaracoesEntidades.StructureAuxiliar structureAuxiliar = ((obj == null) ? default(DeclaracoesEntidades.StructureAuxiliar) : ((DeclaracoesEntidades.StructureAuxiliar)obj));
								if (structureAuxiliar.IndexModelo == iIndiceModelo && structureAuxiliar.IndexContato == iIndiceContato)
								{
									result = true;
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
					return result;
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
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		finally
		{
		}
	}

	public static bool ExisteDispositivoDiferente(string sTipoContato, int iIndiceModelo, int iIndiceContato)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected Obj, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected Obj, but got Unknown
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected Obj, but got Unknown
		bool result = false;
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
							Entity ent = (Entity)(object)val6;
							string tipoImportado = "";
							string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
							val6 = (BlockReference)ent;
							if (Operators.CompareString(left, "A", TextCompare: true) == 0)
							{
								object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val6);
								DeclaracoesEntidades.StructureAuxiliar structureAuxiliar = ((obj == null) ? default(DeclaracoesEntidades.StructureAuxiliar) : ((DeclaracoesEntidades.StructureAuxiliar)obj));
								string right = Strings.Mid(val6.Name, 5, 2);
								if (structureAuxiliar.IndexModelo == iIndiceModelo && structureAuxiliar.IndexContato == iIndiceContato && Operators.CompareString(sTipoContato, right, TextCompare: true) != 0)
								{
									result = true;
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
					return result;
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
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		finally
		{
		}
	}

	public static void BuscaContatosUsadosDoModelo(ref StructureFuncaoAuxiliares[] mFuncoes, int iIndiceModelo)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected Obj, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected Obj, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected Obj, but got Unknown
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected Obj, but got Unknown
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Expected Obj, but got Unknown
		int num = 0;
		mFuncoes = new StructureFuncaoAuxiliares[1];
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
								BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
								if (val6 == null)
								{
									continue;
								}
								string text = "";
								int num2 = 0;
								int num3 = 0;
								Entity ent = (Entity)(object)val6;
								object oValor = text;
								object oValor2 = 0;
								object oValor3 = 0;
								bool flag = XDataLeitura.lexDataDaEntity3(ref ent, "MODELO", 1, 2, 3, ref oValor, ref oValor2, ref oValor3);
								num2 = Conversions.ToInteger(oValor3);
								num3 = Conversions.ToInteger(oValor2);
								text = Conversions.ToString(oValor);
								val6 = (BlockReference)ent;
								if (!flag || num3 != iIndiceModelo)
								{
									continue;
								}
								string sHandle = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
								string value = clsBlocos.LeUmAtributoDeUmBloco(ref sHandle, "FUNCAO");
								value = clsTextos.TiraNothing(value);
								if (Operators.CompareString(value.Trim(), "", TextCompare: true) == 0)
								{
									continue;
								}
								num++;
								mFuncoes = (StructureFuncaoAuxiliares[])Utils.CopyArray(mFuncoes, new StructureFuncaoAuxiliares[num + 1]);
								mFuncoes[num].iIndice = num2;
								mFuncoes[num].iModelo = iIndiceModelo;
								Entity ent2 = (Entity)Geral.HandleToObject(text);
								if (ent2 != null)
								{
									sHandle = "";
									string left = XDataDispositivo.verificaTipoDispositivo(ref ent2, ref sHandle);
									if (Operators.CompareString(left, "P", TextCompare: true) == 0)
									{
										BlockReference blockRef = (BlockReference)ent2;
										oValor3 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
										ent2 = (Entity)(object)blockRef;
										object obj = oValor3;
										DeclaracoesEntidades.StructureDispositivo structureDispositivo = ((obj == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj));
										mFuncoes[num].sNome1 = structureDispositivo.Nome1;
										mFuncoes[num].sNome2 = structureDispositivo.Nome2;
									}
								}
								mFuncoes[num].sFuncao = value;
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
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
			}
		}
	}

	public static void AtualizaFuncaoDoContatoAux(ref StructureFuncaoAuxiliares[] mFuncoes, int iIndiceModelo)
	{
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
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected Obj, but got Unknown
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected Obj, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected Obj, but got Unknown
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
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
							string text = "";
							int num = 0;
							Entity ent = (Entity)(object)val6;
							object oValor = text;
							object oValor2 = 0;
							object oValor3 = 0;
							bool flag = XDataLeitura.lexDataDaEntity3(ref ent, "MODELO", 1, 2, 3, ref oValor, ref oValor2, ref oValor3);
							num = Conversions.ToInteger(oValor3);
							Conversions.ToInteger(oValor2);
							text = Conversions.ToString(oValor);
							val6 = (BlockReference)ent;
							if (!flag)
							{
								continue;
							}
							Entity val7 = (Entity)Geral.HandleToObject(text);
							if (val7 == null)
							{
								continue;
							}
							BlockReference blockRef = (BlockReference)val7;
							oValor3 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
							val7 = (Entity)(object)blockRef;
							object obj = oValor3;
							DeclaracoesEntidades.StructureDispositivo structureDispositivo = ((obj == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj));
							int num2 = Information.UBound(mFuncoes);
							for (int i = 1; i <= num2; i = checked(i + 1))
							{
								if ((mFuncoes[i].iIndice == num) & (Operators.CompareString(mFuncoes[i].sNome1, structureDispositivo.Nome1, TextCompare: true) == 0) & (Operators.CompareString(mFuncoes[i].sNome2, structureDispositivo.Nome2, TextCompare: true) == 0))
								{
									string sHandle = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
									clsBlocos.EditaUmAtributoDeUmBloco(ref sHandle, "FUNCAO", mFuncoes[i].sFuncao);
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
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		finally
		{
		}
	}

	public static void ApagaContatoOrfao(ref List<int> lIndex, int iIndiceModelo)
	{
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
							Entity ent = (Entity)(object)val6;
							string tipoImportado = "";
							string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
							val6 = (BlockReference)ent;
							string left = text;
							if (Operators.CompareString(left, "A", TextCompare: true) == 0)
							{
								object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val6);
								DeclaracoesEntidades.StructureAuxiliar structureAuxiliar = ((obj == null) ? default(DeclaracoesEntidades.StructureAuxiliar) : ((DeclaracoesEntidades.StructureAuxiliar)obj));
								if (structureAuxiliar.IndexModelo == iIndiceModelo && lIndex.Contains(structureAuxiliar.IndexContato))
								{
									((DBObject)val6).UpgradeOpen();
									((DBObject)val6).Erase();
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
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		finally
		{
		}
	}

	public static bool CorrigirModelo(int iIndiceModelo)
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
		bool result = false;
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
							BlockReference blockRef = (BlockReference)(object)((ent is BlockReference) ? ent : null);
							if (blockRef == null)
							{
								continue;
							}
							string tipoImportado = "";
							string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
							if (Operators.CompareString(left, "P", TextCompare: true) != 0)
							{
								continue;
							}
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
							DeclaracoesEntidades.StructureDispositivo structureDispositivo = ((obj == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj));
							if (structureDispositivo.indexModelo == iIndiceModelo && !structureDispositivo.Complementar)
							{
								if (structureDispositivo.dAlturaModelo == 0.0)
								{
									result = true;
								}
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
					return result;
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
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		finally
		{
			DeclaracoesGeral.bAnularEventos = false;
		}
	}

	public static void CorrigeAlturaDosModelos(int iIndiceModelo)
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected Obj, but got Unknown
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected Obj, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected Obj, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected Obj, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0379: Unknown result type (might be due to invalid IL or missing references)
		//IL_0380: Expected Obj, but got Unknown
		int num = 0;
		StructureCorrigeMODELO[] array = new StructureCorrigeMODELO[1];
		List<string> list = new List<string>();
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
								BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
								if (val6 == null)
								{
									continue;
								}
								Declaracoes2.StructureModelo Modelo = default;
								Entity Ent = (Entity)(object)val6;
								bool flag = XDataDispositivosMaster.LerXDataModelo(ref Ent, ref Modelo);
								val6 = (BlockReference)Ent;
								if (!flag)
								{
									continue;
								}
								Point3d position;
								if (Modelo.indexContato != 0 || list.Contains(Modelo.HandleBob))
								{
									if (Modelo.indexContato != 1 || !list.Contains(Modelo.HandleBob))
									{
										continue;
									}
									int num2 = Information.UBound(array);
									for (int i = 1; i <= num2; i++)
									{
										if (Operators.CompareString(array[i].sHandle, Modelo.HandleBob, TextCompare: true) == 0)
										{
											array[i].ptMod1 = val6.Position;
											array[i].sNomeBloco = val6.Name;
											ref StructureCorrigeMODELO reference = ref array[num];
											position = val6.Position;
											reference.dAltura1 = position.Y;
											break;
										}
									}
								}
								else
								{
									num++;
									array = (StructureCorrigeMODELO[])Utils.CopyArray(array, new StructureCorrigeMODELO[num + 1]);
									array[num].sHandle = Modelo.HandleBob;
									array[num].ptMod0 = val6.Position;
									ref StructureCorrigeMODELO reference2 = ref array[num];
									position = val6.Position;
									reference2.dAltura0 = position.Y;
									list.Add(Modelo.HandleBob);
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
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
			}
			DocumentLock val7 = Application.DocumentManager.MdiActiveDocument.LockDocument();
			try
			{
				Database database2 = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val8 = database2.TransactionManager.StartTransaction();
				try
				{
					int num3 = Information.UBound(array);
					for (int j = 1; j <= num3; j++)
					{
						double num4 = 0.0;
						num4 = ((array[j].ptMod0.Y < array[j].ptMod1.Y) ? (array[j].ptMod1.Y - array[j].ptMod0.Y) : (array[j].ptMod0.Y - array[j].ptMod1.Y));
						string sNomeBloco = array[j].sNomeBloco;
						if (Operators.CompareString(sNomeBloco, "RC_TIT", TextCompare: true) != 0)
						{
							if (Operators.CompareString(sNomeBloco, "RC_NA", TextCompare: true) != 0)
							{
								if (Operators.CompareString(sNomeBloco, "RC_NF", TextCompare: true) != 0)
								{
									if (Operators.CompareString(sNomeBloco, "RC_RV", TextCompare: true) == 0)
									{
										num4 -= Declaracoes2.mTamanhosDosContatos.RV;
									}
								}
								else
								{
									num4 -= Declaracoes2.mTamanhosDosContatos.NF;
								}
							}
							else
							{
								num4 -= Declaracoes2.mTamanhosDosContatos.NA;
							}
						}
						else
						{
							num4 -= Declaracoes2.mTamanhosDosContatos.TIT;
						}
						num4 = Math.Round(num4, 1);
						BlockReference blockRef = (BlockReference)Geral.HandleToObject(array[j].sHandle);
						if (blockRef != null)
						{
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
							DeclaracoesEntidades.StructureDispositivo disp = ((obj == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj));
							disp.dAlturaModelo = num4;
							if (disp.dAlturaModelo < 0.0)
							{
								disp.dAlturaModelo = 0.0;
							}
							XDataDispositivosMaster.GravarXDataDispPrincipal(ref blockRef, ref disp);
						}
					}
					DeclaracoesGeral.bAnularEventos = true;
					val8.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				finally
				{
					((IDisposable)val8)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val7)?.Dispose();
			}
		}
	}

	public static double BuscaAlturaDoModelo(string sHandle)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected Obj, but got Unknown
		double result = 1.0;
		try
		{
			DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockReference blockRef = (BlockReference)Geral.HandleToObject(sHandle);
					if (blockRef != null)
					{
						object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
						result = ((obj == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj)).dAlturaModelo;
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
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		finally
		{
		}
		return result;
	}

	public static double BuscaAlturaDoModeloEspecifico(int indexModelo)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected Obj, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected Obj, but got Unknown
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected Obj, but got Unknown
		double result = -1.0;
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
							Entity ent = (Entity)(object)val6;
							string tipoImportado = "";
							string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
							val6 = (BlockReference)ent;
							string left = text;
							if (Operators.CompareString(left, "P", TextCompare: true) == 0)
							{
								object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val6);
								DeclaracoesEntidades.StructureDispositivo structureDispositivo = ((obj == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj));
								if (structureDispositivo.indexModelo == indexModelo)
								{
									result = structureDispositivo.dAlturaModelo;
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
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		finally
		{
		}
		return result;
	}

	public static void CorrigeAlturaDoModelosSelecionado(int iIndiceModelo, double dAltura)
	{
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
							Entity ent = (Entity)(object)val6;
							string tipoImportado = "";
							string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
							val6 = (BlockReference)ent;
							string left = text;
							if (Operators.CompareString(left, "P", TextCompare: true) != 0)
							{
								continue;
							}
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val6);
							DeclaracoesEntidades.StructureDispositivo disp = ((obj == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj));
							if (disp.indexModelo == iIndiceModelo)
							{
								disp.dAlturaModelo = Math.Round(dAltura, 2);
								if (disp.dAlturaModelo < 0.0)
								{
									disp.dAlturaModelo = 0.0;
								}
								XDataDispositivosMaster.GravarXDataDispPrincipal(ref val6, ref disp);
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
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		finally
		{
		}
	}

	public static void VerificaTamanhoContatosAuxiliares()
	{
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Expected Obj, but got Unknown
		//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f6: Expected Obj, but got Unknown
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_030a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0311: Expected Obj, but got Unknown
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Unknown result type (might be due to invalid IL or missing references)
		//IL_0326: Unknown result type (might be due to invalid IL or missing references)
		//IL_0355: Unknown result type (might be due to invalid IL or missing references)
		//IL_035a: Unknown result type (might be due to invalid IL or missing references)
		//IL_035e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0366: Unknown result type (might be due to invalid IL or missing references)
		//IL_036d: Expected Obj, but got Unknown
		//IL_037a: Unknown result type (might be due to invalid IL or missing references)
		//IL_037f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0383: Unknown result type (might be due to invalid IL or missing references)
		//IL_0388: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0403: Unknown result type (might be due to invalid IL or missing references)
		//IL_0408: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d6: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		string text2 = "IEC";
		if (DeclaracoesGeral.Conf.Norma == 1)
		{
			text2 = "ANSI";
		}
		if (Operators.CompareString(DeclaracoesGeral.Conf.DirSimbologiaEletrica, "", TextCompare: true) != 0)
		{
			if (!Directory.Exists(DeclaracoesGeral.Conf.DirSimbologiaEletrica + "Auxiliares\\" + text2))
			{
				string prompt = Conversions.ToString(Operators.ConcatenateObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1721], " "), text2.ToString()), " "), DeclaracoesGeral.mMensagem[1, 1722]), "\r\n"), DeclaracoesGeral.Conf.DirSimbologiaEletrica), "Contatos\\"));
				Interaction.MsgBox(prompt, MsgBoxStyle.Information);
				return;
			}
			text = DeclaracoesGeral.Conf.DirSimbologiaEletrica + "Auxiliares\\" + text2 + "\\";
		}
		Declaracoes2.mTamanhosDosContatos.TIT = 0.0;
		Declaracoes2.mTamanhosDosContatos.NA = 0.0;
		Declaracoes2.mTamanhosDosContatos.NF = 0.0;
		Declaracoes2.mTamanhosDosContatos.RV = 0.0;
		int num = 0;
		string text3 = "";
		BlockTableRecordEnumerator enumerator = default;
		while (true)
		{
			text3 = text + "RC_TIT.dwg";
			text3 = text3.Replace("\\\\", "\\");
			if (!File.Exists(text3))
			{
				text3 = "";
			}
			while (true)
			{
				if (Operators.CompareString(text3, "", TextCompare: true) != 0)
				{
					Database val = new Database(false, true);
					try
					{
						val.ReadDwgFile(text3, (FileOpenMode)3, false, "");
						Transaction val2 = (Transaction)(object)val.TransactionManager.StartOpenCloseTransaction();
						try
						{
							BlockTable val3 = (BlockTable)val2.GetObject(val.BlockTableId, (OpenMode)0);
							BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
							ObjectId blockEndId = val4.BlockEndId;
							Point3d insbase = blockEndId.OriginalDatabase.Insbase;
							double y = insbase.Y;
							double num2 = -100000.0;
							double y2 = insbase.Y;
							try
							{
								enumerator = val4.GetEnumerator();
								while (enumerator.MoveNext())
								{
									ObjectId current = enumerator.Current;
									Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
									double num3 = y2;
									Extents3d value = ((Drawable)val5).Bounds.Value;
									Point3d val6 = value.MinPoint;
									if (num3 > val6.Y)
									{
										value = ((Drawable)val5).Bounds.Value;
										val6 = value.MinPoint;
										y2 = val6.Y;
									}
									double num4 = num2;
									value = ((Drawable)val5).Bounds.Value;
									val6 = value.MaxPoint;
									if (num4 < val6.Y)
									{
										value = ((Drawable)val5).Bounds.Value;
										val6 = value.MaxPoint;
										num2 = val6.Y;
									}
								}
							}
							finally
							{
								((IDisposable)enumerator)?.Dispose();
							}
							double num5 = 0.0;
							switch (num)
							{
							case 0:
							case 4:
								if (Declaracoes2.mTamanhosDosContatos.TIT == 0.0)
								{
									Declaracoes2.mTamanhosDosContatos.TIT = Math.Round(y - y2, 2);
								}
								break;
							case 1:
								num5 = y - num2;
								Declaracoes2.mTamanhosDosContatos.NA = Math.Round(y - y2, 2) - Math.Round(num5, 2);
								break;
							case 2:
								num5 = y - num2;
								Declaracoes2.mTamanhosDosContatos.NF = Math.Round(y - y2, 2) - Math.Round(num5, 2);
								break;
							case 3:
								num5 = y - num2;
								Declaracoes2.mTamanhosDosContatos.RV = Math.Round(y - y2, 2) - Math.Round(num5, 2);
								break;
							}
							DeclaracoesGeral.bAnularEventos = true;
							val2.Commit();
							DeclaracoesGeral.bAnularEventos = false;
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
				num = checked(num + 1);
				if (num > 4)
				{
					return;
				}
				text3 = "";
				switch (num)
				{
				case 0:
					break;
				case 4:
					text3 = text + "RC_TIT2.dwg";
					text3 = text3.Replace("\\\\", "\\");
					if (!File.Exists(text3))
					{
						text3 = "";
					}
					continue;
				default:
					continue;
				case 1:
					text3 = text + "RC_NA.dwg";
					text3 = text3.Replace("\\\\", "\\");
					if (!File.Exists(text3))
					{
						text3 = "";
					}
					continue;
				case 2:
					text3 = text + "RC_NF.dwg";
					text3 = text3.Replace("\\\\", "\\");
					if (!File.Exists(text3))
					{
						text3 = "";
					}
					continue;
				case 3:
					text3 = text + "RC_RV.dwg";
					text3 = text3.Replace("\\\\", "\\");
					if (!File.Exists(text3))
					{
						text3 = "";
					}
					continue;
				}
				break;
			}
		}
	}

	public static void GuardaAsFuncoesDosModelos(ref Declaracoes2.StructureFuncoesDispositivo[] mFuncoes)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected Obj, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected Obj, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected Obj, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
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
						int num = 0;
						mFuncoes = new Declaracoes2.StructureFuncoesDispositivo[1];
						BlockTableRecordEnumerator enumerator = default;
						try
						{
							enumerator = val4.GetEnumerator();
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.Current;
								Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
								BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
								if (val6 != null)
								{
									Declaracoes2.StructureModelo Modelo = default;
									Entity Ent = (Entity)(object)val6;
									bool flag = XDataDispositivosMaster.LerXDataModelo(ref Ent, ref Modelo);
									val6 = (BlockReference)Ent;
									if (flag)
									{
										num++;
										mFuncoes = (Declaracoes2.StructureFuncoesDispositivo[])Utils.CopyArray(mFuncoes, new Declaracoes2.StructureFuncoesDispositivo[num + 1]);
										mFuncoes[num].Handle = Modelo.HandleBob;
										mFuncoes[num].index = Modelo.indexContato;
										ref Declaracoes2.StructureFuncoesDispositivo reference = ref mFuncoes[num];
										string sHandle = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
										reference.Funcao = clsBlocos.LeUmAtributoDeUmBloco(ref sHandle, "FUNCAO");
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
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void EscreveAsFuncoesDosModelos(ref Declaracoes2.StructureFuncoesDispositivo[] mFuncoes)
	{
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
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected Obj, but got Unknown
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
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
							Declaracoes2.StructureModelo Modelo = default;
							Entity Ent = (Entity)(object)val6;
							bool flag = XDataDispositivosMaster.LerXDataModelo(ref Ent, ref Modelo);
							val6 = (BlockReference)Ent;
							if (!flag)
							{
								continue;
							}
							int num = Information.UBound(mFuncoes);
							for (int i = 1; i <= num; i = checked(i + 1))
							{
								if ((Operators.CompareString(mFuncoes[i].Handle, Modelo.HandleBob, TextCompare: true) == 0) & (mFuncoes[i].index == Modelo.indexContato))
								{
									string sHandle = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
									clsBlocos.AtualizaValorDeUmAtributo(ref sHandle, "FUNCAO", mFuncoes[i].Funcao);
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
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}
}

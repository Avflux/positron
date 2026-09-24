using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

public class clsPainel
{
	public struct structureMod
	{
		public string HandleBob;

		public string HandleBloco;
	}

	public struct structureLP
	{
		public string ChavePri;

		public string HandleTexto;
	}

	public static void PaineisDocumento(ref object mPaineis, bool bTopografico = false)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected Obj, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected Obj, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected Obj, but got Unknown
		bool flag = true;
		int num = 0;
		int num2 = 0;
		string sTipo = "";
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				try
				{
					Transaction val2 = database.TransactionManager.StartTransaction();
					try
					{
						BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
						BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
						DeclaracoesGeral._uscPagina.Quantidade = clsBlocos.AcadObjectCount();
						DeclaracoesGeral._uscPagina.pbIniciar();
						int num3 = 0;
						BlockTableRecordEnumerator enumerator = default;
						try
						{
							enumerator = val4.GetEnumerator();
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.Current;
								Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
								try
								{
									num3++;
									if (num3 == 100)
									{
										DeclaracoesGeral._uscPagina.pbPasso(num3);
										num3 = 0;
									}
									num = 0;
									num2 = 0;
									int Potencial = 0;
									XDataDispositivo.xDataPaineis(val5, ref sTipo, ref num, ref num2, ref Potencial, bTopografico);
									if (num != 0)
									{
										flag = true;
										int num4 = Information.UBound((Array)mPaineis, 2);
										for (int i = 1; i <= num4; i++)
										{
											if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateIndexGet(mPaineis, new object[2] { 0, i }, null), num, TextCompare: true))
											{
												flag = false;
												break;
											}
										}
										if (flag)
										{
											mPaineis = Utils.CopyArray((Array)mPaineis, new object[2, Information.UBound((Array)mPaineis, 2) + 1 + 1]);
											NewLateBinding.LateIndexSet(mPaineis, new object[3]
											{
												0,
												Information.UBound((Array)mPaineis, 2),
												num
											}, null);
											NewLateBinding.LateIndexSet(mPaineis, new object[3]
											{
												1,
												Information.UBound((Array)mPaineis, 2),
												""
											}, null);
										}
									}
									if (num2 == 0)
									{
										continue;
									}
									flag = true;
									int num5 = Information.UBound((Array)mPaineis, 2);
									for (int j = 1; j <= num5; j++)
									{
										if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateIndexGet(mPaineis, new object[2] { 0, j }, null), num2, TextCompare: true))
										{
											flag = false;
											break;
										}
									}
									if (flag)
									{
										mPaineis = Utils.CopyArray((Array)mPaineis, new object[2, Information.UBound((Array)mPaineis, 2) + 1 + 1]);
										NewLateBinding.LateIndexSet(mPaineis, new object[3]
										{
											0,
											Information.UBound((Array)mPaineis, 2),
											num2
										}, null);
										NewLateBinding.LateIndexSet(mPaineis, new object[3]
										{
											1,
											Information.UBound((Array)mPaineis, 2),
											""
										}, null);
									}
								}
								finally
								{
									((IDisposable)val5)?.Dispose();
								}
							}
						}
						finally
						{
							((IDisposable)enumerator)?.Dispose();
						}
						DeclaracoesGeral._uscPagina.pbFim();
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
					((IDisposable)database)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			Declaracoes2.StructureModeloDeReguas[] mModelo = new Declaracoes2.StructureModeloDeReguas[1];
			DicionarioReguas.LeOsModelosDeRegua(ref mModelo);
			int num6 = Information.UBound(mModelo);
			for (int k = 1; k <= num6; k++)
			{
				flag = true;
				int num7 = Information.UBound((Array)mPaineis, 2);
				for (int l = 1; l <= num7; l++)
				{
					if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateIndexGet(mPaineis, new object[2] { 0, l }, null), mModelo[k].indexPainel, TextCompare: true))
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					mPaineis = Utils.CopyArray((Array)mPaineis, new object[2, Information.UBound((Array)mPaineis, 2) + 1 + 1]);
					NewLateBinding.LateIndexSet(mPaineis, new object[3]
					{
						0,
						Information.UBound((Array)mPaineis, 2),
						mModelo[k].indexPainel
					}, null);
				}
			}
			int num8 = Information.UBound((Array)mPaineis, 2);
			for (int m = 1; m <= num8; m++)
			{
				NewLateBinding.LateIndexSet(mPaineis, new object[3]
				{
					1,
					m,
					Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(NewLateBinding.LateIndexGet(mPaineis, new object[2] { 0, m }, null)))
				}, null);
			}
		}
	}

	public static void AtualizaBornes(int iPN, string sPn)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected Obj, but got Unknown
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected Obj, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected Obj, but got Unknown
		//IL_03b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Expected Obj, but got Unknown
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Expected Obj, but got Unknown
		object[,] array = new object[4, 1]
		{
			{ "ObjectId" },
			{ "sPn" },
			{ "sRegua" },
			{ "Mostra Painel ou Não" }
		};
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
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
							try
							{
								ResultBuffer xDataForApplication = ((DBObject)val5).GetXDataForApplication("Dispositivo");
								if (xDataForApplication == null)
								{
									continue;
								}
								TypedValue[] array2 = xDataForApplication.AsArray();
								if (Operators.CompareString(array2[1].Value.ToString().ToUpper(), "B", TextCompare: true) == 0)
								{
									string sRegua = "";
									int iRegua = Conversions.ToInteger(array2[8].Value);
									string sAlternativo = "";
									if (iPN == DicionarioBorne.BuscaPainelDoBorneNoDicionario(ref iRegua, ref sRegua, ref sAlternativo))
									{
										array = (object[,])Utils.CopyArray(array, new object[4, Information.UBound(array, 2) + 1 + 1]);
										array[0, Information.UBound(array, 2)] = ((DBObject)val5).ObjectId;
										array[1, Information.UBound(array, 2)] = sPn;
										array[2, Information.UBound(array, 2)] = sRegua;
										array[3, Information.UBound(array, 2)] = RuntimeHelpers.GetObjectValue(array2[15].Value);
									}
								}
							}
							finally
							{
								((IDisposable)val5)?.Dispose();
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
			DocumentLock val6 = Application.DocumentManager.MdiActiveDocument.LockDocument();
			try
			{
				Database database2 = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val7 = database2.TransactionManager.StartTransaction();
				try
				{
					int num = Information.UBound(array, 2);
					for (int i = 1; i <= num; i++)
					{
						object obj = array[0, i];
						Entity val8 = (Entity)val7.GetObject((obj == null) ? default(ObjectId) : ((ObjectId)obj), (OpenMode)0);
						try
						{
							BlockReference val9 = (BlockReference)(object)((val8 is BlockReference) ? val8 : null);
							try
							{
								AttributeCollection attributeCollection = val9.AttributeCollection;
								foreach (object item in attributeCollection)
								{
									ObjectId val10 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
									AttributeReference val11 = (AttributeReference)val7.GetObject(val10, (OpenMode)0);
									try
									{
										if (Operators.CompareString(val11.Tag, "NOME1", TextCompare: true) != 0)
										{
											continue;
										}
										((DBObject)val11).UpgradeOpen();
										if (!((DBText)val11).TextString.Contains(DeclaracoesGeral.Conf.SeparadorCaboVeia))
										{
											((DBText)val11).TextString = Conversions.ToString(array[2, i]);
										}
										else
										{
											((DBText)val11).TextString = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(array[1, i], DeclaracoesGeral.Conf.SeparadorCaboVeia), array[2, i]));
										}
										break;
									}
									finally
									{
										((IDisposable)val11)?.Dispose();
									}
								}
							}
							finally
							{
								((IDisposable)val9)?.Dispose();
							}
						}
						finally
						{
							((IDisposable)val8)?.Dispose();
						}
					}
					DeclaracoesGeral.bAnularEventos = true;
					val7.Commit();
					DeclaracoesGeral.bAnularEventos = false;
					Application.UpdateScreen();
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					val7.Abort();
					ProjectData.ClearProjectError();
				}
				finally
				{
					((IDisposable)val7)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val6)?.Dispose();
			}
		}
	}

	public static void ApagaPaineisDocumento(List<int> iPaineis)
	{
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected Obj, but got Unknown
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected Obj, but got Unknown
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected Obj, but got Unknown
		//IL_0a11: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a16: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a22: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a29: Expected Obj, but got Unknown
		//IL_0ad0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad7: Expected Obj, but got Unknown
		//IL_0402: Unknown result type (might be due to invalid IL or missing references)
		//IL_0407: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_0426: Unknown result type (might be due to invalid IL or missing references)
		//IL_042b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0487: Unknown result type (might be due to invalid IL or missing references)
		//IL_048c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0708: Unknown result type (might be due to invalid IL or missing references)
		//IL_070f: Expected Obj, but got Unknown
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b27: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b55: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07df: Expected Obj, but got Unknown
		//IL_0500: Unknown result type (might be due to invalid IL or missing references)
		//IL_0505: Unknown result type (might be due to invalid IL or missing references)
		//IL_0574: Unknown result type (might be due to invalid IL or missing references)
		//IL_0579: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b04: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd9: Expected Obj, but got Unknown
		//IL_0598: Unknown result type (might be due to invalid IL or missing references)
		//IL_059d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0606: Unknown result type (might be due to invalid IL or missing references)
		//IL_060b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0baa: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0677: Unknown result type (might be due to invalid IL or missing references)
		//IL_067c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c02: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c07: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_091b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0920: Unknown result type (might be due to invalid IL or missing references)
		//IL_093f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0944: Unknown result type (might be due to invalid IL or missing references)
		//IL_0977: Unknown result type (might be due to invalid IL or missing references)
		//IL_097c: Unknown result type (might be due to invalid IL or missing references)
		//IL_078a: Unknown result type (might be due to invalid IL or missing references)
		//IL_078f: Unknown result type (might be due to invalid IL or missing references)
		//IL_099b: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0396: Unknown result type (might be due to invalid IL or missing references)
		//IL_039b: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0847: Unknown result type (might be due to invalid IL or missing references)
		//IL_084c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0868: Unknown result type (might be due to invalid IL or missing references)
		//IL_086d: Unknown result type (might be due to invalid IL or missing references)
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		Declaracoes2.StructureModeloDeReguas[] mModelo = null;
		Declaracoes2.StructureModeloDeReguas[] array = null;
		array = new Declaracoes2.StructureModeloDeReguas[1];
		DicionarioReguas.LeOsModelosDeRegua(ref mModelo);
		structureMod[] array2 = null;
		structureLP[] array3 = null;
		NH4THUNG54(ref array2);
		lZuTG7c5fn(ref array3);
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
					try
					{
						BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
						try
						{
							DeclaracoesGeral._uscPagina.Quantidade = clsBlocos.AcadObjectCount() * 2;
							DeclaracoesGeral._uscPagina.pbIniciar();
							int num = 0;
							BlockTableRecordEnumerator enumerator = default;
							try
							{
								enumerator = val4.GetEnumerator();
								while (enumerator.MoveNext())
								{
									ObjectId current = enumerator.Current;
									Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
									try
									{
										BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
										try
										{
											if (val6 == null)
											{
												Polyline val7 = (Polyline)(object)((val5 is Polyline) ? val5 : null);
												try
												{
													if (val7 != null)
													{
														DeclaracoesEntidades.StructureConexao conex = default;
														Polyline pl = val7;
														if (!XDataConexao.lerXDataConexao(ref pl, ref conex))
														{
															DeclaracoesEntidades.StructureInterligacao ilig = default;
															pl = val7;
															if (XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig) && (iPaineis.Contains(ilig.Painel1) | iPaineis.Contains(ilig.Painel2)))
															{
																if (!list.Contains(((object)((DBObject)val7).Handle/*cast due to constrained. prefix*/).ToString()))
																{
																	list.Add(((object)((DBObject)val7).Handle/*cast due to constrained. prefix*/).ToString());
																}
																if (ilig.Tipo == 2 && !list.Contains(ilig.handle))
																{
																	list.Add(ilig.handle);
																}
															}
														}
														else if (iPaineis.Contains(conex.Painel) && !list.Contains(((object)((DBObject)val7).Handle/*cast due to constrained. prefix*/).ToString()))
														{
															list.Add(((object)((DBObject)val7).Handle/*cast due to constrained. prefix*/).ToString());
														}
													}
												}
												finally
												{
													((IDisposable)val7)?.Dispose();
												}
											}
											else
											{
												Entity ent = (Entity)(object)val6;
												string tipoImportado = "";
												string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
												string left = text;
												if (Operators.CompareString(left, "P", TextCompare: true) != 0)
												{
													if (Operators.CompareString(left, "A", TextCompare: true) != 0)
													{
														if (Operators.CompareString(left, "M", TextCompare: true) != 0)
														{
															if (Operators.CompareString(left, "E", TextCompare: true) != 0)
															{
																if (Operators.CompareString(left, "B", TextCompare: true) == 0)
																{
																	BlockReference blockRef = (BlockReference)val5;
																	object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
																	DeclaracoesEntidades.StructureBorne structureBorne = ((obj == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj));
																	int num2 = Information.UBound(mModelo);
																	for (int i = 1; i <= num2; i++)
																	{
																		if (structureBorne.IndiceRegua == mModelo[i].indexRegua)
																		{
																			structureBorne.indexPainel = mModelo[i].indexPainel;
																			break;
																		}
																	}
																	if (iPaineis.Contains(structureBorne.indexPainel) && !list.Contains(((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString()))
																	{
																		list.Add(((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString());
																	}
																}
															}
															else
															{
																DeclaracoesEntidades.StructurePortas structurePortas = default;
																BlockReference blockRef = val6;
																object obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
																structurePortas = ((obj2 == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj2));
																int item = Dicionario.BuscaIndiceDoPainel(clsMascara.BuscaPainel(structurePortas.HandleDaMascara));
																if (iPaineis.Contains(item))
																{
																	if (!list.Contains(((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString()))
																	{
																		list.Add(((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString());
																		if (Operators.CompareString(structurePortas.chavePrimaria, "", TextCompare: true) != 0 && !list2.Contains(structurePortas.chavePrimaria))
																		{
																			list2.Add(structurePortas.chavePrimaria);
																		}
																	}
																	int num3 = Information.UBound(array3);
																	for (int j = 1; j <= num3; j++)
																	{
																		if (Operators.CompareString(structurePortas.chavePrimaria, array3[j].ChavePri, TextCompare: true) == 0)
																		{
																			if (!list.Contains(array3[j].HandleTexto))
																			{
																				list.Add(array3[j].HandleTexto);
																			}
																			break;
																		}
																	}
																}
															}
														}
														else
														{
															BlockReference blockRef = val6;
															object obj3 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
															if (iPaineis.Contains(((obj3 == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj3)).Painel) && !list.Contains(((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString()))
															{
																list.Add(((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString());
															}
														}
													}
													else
													{
														BlockReference blockRef = val6;
														object obj4 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
														DeclaracoesEntidades.StructureAuxiliar structureAuxiliar = ((obj4 == null) ? default(DeclaracoesEntidades.StructureAuxiliar) : ((DeclaracoesEntidades.StructureAuxiliar)obj4));
														int item2 = clsDispositivo.BuscaPainelDoDispPrincipal(structureAuxiliar.HandleBob);
														if (iPaineis.Contains(item2))
														{
															if (!list.Contains(((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString()))
															{
																list.Add(((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString());
															}
															int num4 = Information.UBound(array2);
															for (int k = 1; k <= num4; k++)
															{
																if (Operators.CompareString(structureAuxiliar.HandleBob.ToString(), array2[k].HandleBob.ToString(), TextCompare: true) == 0 && !list.Contains(array2[k].HandleBloco))
																{
																	list.Add(array2[k].HandleBloco);
																}
															}
														}
													}
												}
												else
												{
													BlockReference blockRef = val6;
													object obj5 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
													if (iPaineis.Contains(((obj5 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj5)).Painel) && !list.Contains(((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString()))
													{
														list.Add(((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString());
													}
												}
												if (Operators.CompareString(text, "", TextCompare: true) == 0)
												{
													Declaracoes2.StructureModelo Modelo = default;
													ent = (Entity)(object)val6;
													if (!XDataDispositivosMaster.LerXDataModelo(ref ent, ref Modelo))
													{
														DeclaracoesTopografico.structureDispTopografico dTpg = default;
														BlockReference blockRef = val6;
														if (!XDataTopografico.lerXDataDispTopografico(ref blockRef, ref dTpg))
														{
															DeclaracoesTopografico.structureBorneTopografico bTpg = default;
															blockRef = val6;
															if (!XDataTopografico.lerXDataBorneTopografico(ref blockRef, ref bTpg))
															{
																int painel = 0;
																blockRef = val6;
																tipoImportado = "";
																string alternativo = "";
																string Handle = "";
																if (!XDataLayout.lerXDataDispLayout(ref blockRef, ref painel, ref tipoImportado, ref alternativo, ref Handle))
																{
																	int painel2 = 0;
																	ent = (Entity)(object)val6;
																	Handle = "";
																	alternativo = "";
																	int tipoBorne = 0;
																	if (XDataLayout.lerXDataBorneLayout(ref ent, ref painel2, ref Handle, ref alternativo, ref tipoBorne) && painel2 > 0 && iPaineis.Contains(painel2) && !list.Contains(((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString()))
																	{
																		list.Add(((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString());
																	}
																}
																else if (painel > 0 && iPaineis.Contains(painel) && !list.Contains(((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString()))
																{
																	list.Add(((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString());
																}
															}
															else if (iPaineis.Contains(bTpg.painel) && !list.Contains(((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString()))
															{
																list.Add(((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString());
															}
														}
														else if (iPaineis.Contains(dTpg.painel) && !list.Contains(((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString()))
														{
															list.Add(((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString());
														}
													}
													else
													{
														Entity val8 = (Entity)Geral.HandleToObject(Modelo.HandleBob);
														try
														{
															if (val8 != null)
															{
																BlockReference val9 = (BlockReference)(object)((val8 is BlockReference) ? val8 : null);
																try
																{
																	if (val9 != null)
																	{
																		ent = (Entity)(object)val9;
																		tipoImportado = "";
																		if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado), "P", TextCompare: true) == 0)
																		{
																			BlockReference blockRef = val9;
																			object obj6 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
																			if (iPaineis.Contains(((obj6 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj6)).Painel) && !list.Contains(((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString()))
																			{
																				list.Add(((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString());
																			}
																		}
																	}
																}
																finally
																{
																	((IDisposable)val9)?.Dispose();
																}
															}
														}
														finally
														{
															((IDisposable)val8)?.Dispose();
														}
													}
												}
											}
											num++;
											if (num == 100)
											{
												DeclaracoesGeral._uscPagina.pbPasso(num);
												num = 0;
											}
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
							}
							finally
							{
								((IDisposable)enumerator)?.Dispose();
							}
							int num5 = 0;
							BlockTableRecordEnumerator enumerator2 = default;
							try
							{
								enumerator2 = val4.GetEnumerator();
								short tipo = default;
								int potencial = default;
								int enderecamento = default;
								while (enumerator2.MoveNext())
								{
									ObjectId current2 = enumerator2.Current;
									Entity val10 = (Entity)val2.GetObject(current2, (OpenMode)0);
									try
									{
										string handle = "";
										string THandle = "";
										string text2 = "";
										num5++;
										DBText val11 = (DBText)(object)((val10 is DBText) ? val10 : null);
										if (val11 == null)
										{
											goto IL_0a54;
										}
										Entity ent = (Entity)(object)val11;
										string alternativo = "";
										bool flag = XDataInterligacao.lerXDataAuxInterligacao(ref ent, ref handle, ref tipo, ref THandle, ref alternativo);
										val11 = (DBText)ent;
										if (!flag || !list.Contains(handle))
										{
											if (!XDataConexao.lerXDataAuxCircuito(ref val11, ref potencial, ref handle, ref enderecamento, ref tipo) || !list.Contains(handle))
											{
												goto IL_0a54;
											}
											list.Add(((object)((DBObject)val10).Handle/*cast due to constrained. prefix*/).ToString());
										}
										else
										{
											list.Add(((object)((DBObject)val10).Handle/*cast due to constrained. prefix*/).ToString());
										}
										goto IL_0a9c;
										IL_0a9c:
										num++;
										if (num == 100)
										{
											DeclaracoesGeral._uscPagina.pbPasso(num);
											num = 0;
										}
										goto end_IL_0a29;
										IL_0a54:
										ent = val10;
										handle = XDataConexao.leHandleDerivacaoLinha(ref ent);
										if (Operators.CompareString(handle, "", TextCompare: true) == 0 || !list.Contains(handle))
										{
											MText val12 = (MText)(object)((val10 is MText) ? val10 : null);
											if (val12 != null)
											{
												ent = val10;
												text2 = XDataDispositivosMaster.LerXDataTextoLP(ref ent);
												if (Operators.CompareString(text2, "", TextCompare: true) != 0 && list2.Contains(text2))
												{
													list.Add(((object)((DBObject)val10).Handle/*cast due to constrained. prefix*/).ToString());
													goto IL_0a9c;
												}
											}
											Line val13 = (Line)(object)((val10 is Line) ? val10 : null);
											if (val13 != null)
											{
												ent = (Entity)(object)val13;
												alternativo = XDataDispositivosMaster.LerXDataLinhaTextoLP(ref ent);
												val13 = (Line)ent;
												text2 = alternativo;
												if (Operators.CompareString(text2, "", TextCompare: true) != 0 && list2.Contains(text2))
												{
													list.Add(((object)((DBObject)val13).Handle/*cast due to constrained. prefix*/).ToString());
												}
											}
										}
										else
										{
											list.Add(((object)((DBObject)val10).Handle/*cast due to constrained. prefix*/).ToString());
										}
										goto IL_0a9c;
										end_IL_0a29:;
									}
									finally
									{
										((IDisposable)val10)?.Dispose();
									}
								}
							}
							finally
							{
								((IDisposable)enumerator2)?.Dispose();
							}
							DeclaracoesGeral._uscPagina.pbFim();
							int num6 = 1;
							array[0].iMaxIndice = mModelo[0].iMaxIndice;
							int num7 = Information.UBound(mModelo);
							for (int l = 1; l <= num7; l++)
							{
								if (!iPaineis.Contains(mModelo[l].indexPainel))
								{
									num6 = Information.UBound(array) + 1;
									array = (Declaracoes2.StructureModeloDeReguas[])Utils.CopyArray(array, new Declaracoes2.StructureModeloDeReguas[num6 + 1]);
									array[num6] = mModelo[l];
								}
							}
							DicionarioReguas.GravaOsModelosDeRegua(array);
							int count = iPaineis.Count;
							for (int m = 0; m <= count; m++)
							{
								DicionarioLayout.ApagaDicLayoutPainel("P", m.ToString());
								DicionarioLayout.ApagaDicLayoutPainel("C", m.ToString());
								DicionarioPlaqueta.ApagaDicPlaquetasPainel(m.ToString());
							}
							DeclaracoesGeral.bAnularEventos = true;
							val2.Commit();
							DeclaracoesGeral.bAnularEventos = false;
						}
						finally
						{
							((IDisposable)val4)?.Dispose();
						}
					}
					finally
					{
						((IDisposable)val3)?.Dispose();
					}
					DeclaracoesGeral._uscPagina.pbFim();
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
			QDuToOngZ2(list);
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		}
	}

	private static void QDuToOngZ2(List<string> P_0)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected Obj, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)1);
				try
				{
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
					try
					{
						DeclaracoesGeral._uscPagina.Quantidade = clsBlocos.AcadObjectCount();
						DeclaracoesGeral._uscPagina.pbIniciar();
						int num = 0;
						BlockTableRecordEnumerator enumerator = default;
						try
						{
							enumerator = val4.GetEnumerator();
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.Current;
								Entity val5 = (Entity)val2.GetObject(current, (OpenMode)1);
								try
								{
									if (P_0.Contains(((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString()))
									{
										((DBObject)val5).Erase(true);
									}
									num = checked(num + 1);
									if (num == 100)
									{
										DeclaracoesGeral._uscPagina.pbPasso(num);
										num = 0;
									}
								}
								finally
								{
									((IDisposable)val5)?.Dispose();
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
						((IDisposable)val4)?.Dispose();
					}
				}
				finally
				{
					((IDisposable)val3)?.Dispose();
				}
				DeclaracoesGeral._uscPagina.pbFim();
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

	private static string lZuTG7c5fn(ref structureLP[] P_0)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected Obj, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected Obj, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected Obj, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
		P_0 = new structureLP[1];
		int num = 1;
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
					try
					{
						BlockTableRecordEnumerator enumerator = default;
						try
						{
							enumerator = val4.GetEnumerator();
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.Current;
								Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
								try
								{
									MText val6 = (MText)(object)((val5 is MText) ? val5 : null);
									try
									{
										if (val6 != null)
										{
											Entity Ent = (Entity)(object)val6;
											string text = XDataDispositivosMaster.LerXDataTextoLP(ref Ent);
											if (Operators.CompareString(text, "", TextCompare: true) != 0)
											{
												P_0 = (structureLP[])Utils.CopyArray(P_0, new structureLP[checked(num + 1)]);
												P_0[num].ChavePri = text;
												P_0[num].HandleTexto = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
											}
										}
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
						}
						finally
						{
							((IDisposable)enumerator)?.Dispose();
						}
					}
					finally
					{
						((IDisposable)val4)?.Dispose();
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

	private static string NH4THUNG54(ref structureMod[] P_0)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected Obj, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected Obj, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected Obj, but got Unknown
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
		P_0 = new structureMod[1];
		int num = 1;
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
					try
					{
						BlockTableRecordEnumerator enumerator = default;
						try
						{
							enumerator = val4.GetEnumerator();
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.Current;
								Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
								try
								{
									BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
									try
									{
										if (val6 != null)
										{
											Declaracoes2.StructureModelo Modelo = default;
											Entity Ent = val5;
											if (XDataDispositivosMaster.LerXDataModelo(ref Ent, ref Modelo))
											{
												P_0 = (structureMod[])Utils.CopyArray(P_0, new structureMod[checked(num + 1)]);
												P_0[num].HandleBob = Modelo.HandleBob;
												P_0[num].HandleBob = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
											}
										}
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
						}
						finally
						{
							((IDisposable)enumerator)?.Dispose();
						}
					}
					finally
					{
						((IDisposable)val4)?.Dispose();
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
}

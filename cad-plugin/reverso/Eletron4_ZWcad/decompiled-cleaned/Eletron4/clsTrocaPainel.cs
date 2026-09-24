using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;

namespace Eletron4;

public class clsTrocaPainel
{
	public struct mPN
	{
		public int iPainel;

		public string sPainel;

		public int iPainelNovo;

		public string sPainelNovo;
	}

	public struct mPNOutros
	{
		public int iPainel;

		public string sPainel;

		public int iPainelNovo;

		public string sPainelNovo;
	}

	public static void PaineisDoDocumento(ref mPN[] mPaineis)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected Obj, but got Unknown
		mPaineis = new mPN[1];
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
										if (val6 == null)
										{
											Polyline val7 = (Polyline)(object)((val5 is Polyline) ? val5 : null);
											try
											{
												if (val7 == null)
												{
													continue;
												}
												DeclaracoesEntidades.StructureConexao conex = default;
												Polyline pl = val7;
												if (XDataConexao.lerXDataConexao(ref pl, ref conex))
												{
													short tipo = conex.Tipo;
													if ((uint)(tipo - 1) <= 3u)
													{
														AdicionaNovoPainelNaLista(ref mPaineis, conex.Painel);
													}
												}
											}
											finally
											{
												((IDisposable)val7)?.Dispose();
											}
											continue;
										}
										Entity ent = val5;
										string tipoImportado = "";
										string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
										if (Operators.CompareString(left, "P", TextCompare: true) != 0)
										{
											BlockReference blockRef;
											if (Operators.CompareString(left, "M", TextCompare: true) != 0)
											{
												if (Operators.CompareString(left, "", TextCompare: true) != 0)
												{
													continue;
												}
												DeclaracoesTopografico.structureDispTopografico dTpg = default;
												blockRef = val6;
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
															ent = (Entity)(object)val6;
															Handle = "";
															alternativo = "";
															int tipoBorne = 0;
															if (XDataLayout.lerXDataBorneLayout(ref ent, ref painel, ref Handle, ref alternativo, ref tipoBorne))
															{
																AdicionaNovoPainelNaLista(ref mPaineis, painel);
															}
														}
														else
														{
															AdicionaNovoPainelNaLista(ref mPaineis, painel);
														}
													}
													else
													{
														AdicionaNovoPainelNaLista(ref mPaineis, bTpg.painel);
													}
												}
												else
												{
													AdicionaNovoPainelNaLista(ref mPaineis, dTpg.painel);
												}
												continue;
											}
											blockRef = val6;
											object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
											AdicionaNovoPainelNaLista(ref mPaineis, ((obj == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj)).Painel);
										}
										else
										{
											BlockReference blockRef = val6;
											object obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
											AdicionaNovoPainelNaLista(ref mPaineis, ((obj2 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj2)).Painel);
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
				Declaracoes2.StructureModeloDeReguas[] mModelo = null;
				DicionarioReguas.LeOsModelosDeRegua(ref mModelo);
				int num = Information.UBound(mModelo);
				for (int i = 1; i <= num; i = checked(i + 1))
				{
					AdicionaNovoPainelNaLista(ref mPaineis, mModelo[i].indexPainel);
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
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

	public static void AdicionaNovoPainelNaLista(ref mPN[] mPaineis, int iPainel)
	{
		bool flag = true;
		if (iPainel == 0)
		{
			return;
		}
		flag = true;
		int num = Information.UBound(mPaineis);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				if (mPaineis[i].iPainel == iPainel)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				int num2 = Information.UBound(mPaineis) + 1;
				mPaineis = (mPN[])Utils.CopyArray(mPaineis, new mPN[num2 + 1]);
				mPaineis[num2].iPainel = iPainel;
				mPaineis[num2].sPainel = Dicionario.BuscaNomeDoPainel(iPainel);
				mPaineis[num2].iPainelNovo = 0;
				mPaineis[num2].sPainelNovo = "";
			}
		}
	}

	public static void PaineisOutros(ref mPN[] mPaineis, ref mPNOutros[] mOutrosPaineis)
	{
		mOutrosPaineis = new mPNOutros[1];
		object mPaineis2 = new object[5, 1]
		{
			{ "INDICE" },
			{ "PAINEL" },
			{ null },
			{ null },
			{ null }
		};
		cDadosAccess.carregaDadosPNs(ref mPaineis2, "Paineis");
		object[,] array = (object[,])mPaineis2;
		bool flag = true;
		int num = Information.UBound(array, 2);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				flag = true;
				int num2 = Information.UBound(mPaineis);
				for (int j = 1; j <= num2; j++)
				{
					if (Operators.ConditionalCompareObjectEqual(array[0, i], mPaineis[j].iPainel, TextCompare: true))
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					int num3 = Information.UBound(mOutrosPaineis) + 1;
					mOutrosPaineis = (mPNOutros[])Utils.CopyArray(mOutrosPaineis, new mPNOutros[num3 + 1]);
					mOutrosPaineis[num3].iPainel = Conversions.ToInteger(array[0, i]);
					mOutrosPaineis[num3].sPainel = Conversions.ToString(array[1, i]);
				}
			}
		}
	}

	public static void TrocaPainelDisp_P_M_C(int iPnO, int iPnN)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected Obj, but got Unknown
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
													if (val7 == null)
													{
														continue;
													}
													DeclaracoesEntidades.StructureConexao conex = default;
													Polyline pl = val7;
													if (!XDataConexao.lerXDataConexao(ref pl, ref conex))
													{
														DeclaracoesEntidades.StructureInterligacao ilig = default;
														pl = val7;
														if (!XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig))
														{
															continue;
														}
														if (ilig.Painel1 != iPnO)
														{
															if (ilig.Painel2 == iPnO)
															{
																ilig.Painel2 = (short)iPnN;
																if (Information.IsNothing(ilig.Handle1))
																{
																	ilig.Handle1 = "";
																}
																if (Information.IsNothing(ilig.Handle2))
																{
																	ilig.Handle2 = "";
																}
																if (Information.IsNothing(ilig.THandle1))
																{
																	ilig.THandle1 = "";
																}
																if (Information.IsNothing(ilig.THandle2))
																{
																	ilig.THandle2 = "";
																}
																((DBObject)val7).UpgradeOpen();
																pl = val7;
																XDataInterligacao.AtualizaXDataInterligacao(ref pl, ref ilig);
															}
														}
														else
														{
															ilig.Painel1 = (short)iPnN;
															if (Information.IsNothing(ilig.Handle1))
															{
																ilig.Handle1 = "";
															}
															if (Information.IsNothing(ilig.Handle2))
															{
																ilig.Handle2 = "";
															}
															if (Information.IsNothing(ilig.THandle1))
															{
																ilig.THandle1 = "";
															}
															if (Information.IsNothing(ilig.THandle2))
															{
																ilig.THandle2 = "";
															}
															((DBObject)val7).UpgradeOpen();
															pl = val7;
															XDataInterligacao.AtualizaXDataInterligacao(ref pl, ref ilig);
														}
														continue;
													}
													if (conex.Painel == iPnO)
													{
														conex.Painel = (short)iPnN;
														short tipo = conex.Tipo;
														if (unchecked((uint)(tipo - 1)) <= 3u)
														{
															((DBObject)val7).UpgradeOpen();
															pl = val7;
															XDataConexao.GravarXDataConexao(ref pl, conex);
														}
													}
												}
												finally
												{
													((IDisposable)val7)?.Dispose();
												}
												continue;
											}
											Entity ent = (Entity)(object)val6;
											string tipoImportado = "";
											string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
											if (Operators.CompareString(left, "P", TextCompare: true) == 0)
											{
												BlockReference blockRef = val6;
												object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
												DeclaracoesEntidades.StructureDispositivo disp = ((obj == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj));
												if (disp.Painel == iPnO)
												{
													disp.Painel = (short)iPnN;
													((DBObject)val6).UpgradeOpen();
													blockRef = val6;
													XDataDispositivosMaster.GravarXDataDispPrincipal(ref blockRef, ref disp);
												}
											}
											if (Operators.CompareString(left, "M", TextCompare: true) == 0)
											{
												BlockReference blockRef = val6;
												object obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
												DeclaracoesEntidades.StructureMascara Masc = ((obj2 == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj2));
												if (Masc.Painel == iPnO)
												{
													Masc.Painel = (short)iPnN;
													((DBObject)val6).UpgradeOpen();
													ent = (Entity)(object)val6;
													XDataDispositivosMaster.GravarXDataMascara(ref ent, ref Masc);
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

	public static void TrocaPainelLAYOUT(int iPnO, int iPnN)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected Obj, but got Unknown
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
											int painel = 0;
											string tag = "";
											string alternativo = "";
											string Handle = "";
											BlockReference blockRef = val6;
											if (XDataLayout.lerXDataDispLayout(ref blockRef, ref painel, ref tag, ref alternativo, ref Handle) && painel == iPnO)
											{
												((DBObject)val6).UpgradeOpen();
												blockRef = val6;
												XDataLayout.GravarXDataDispLayout(ref blockRef, iPnN, tag, alternativo, "", Handle);
											}
											string regua = "";
											string borne = "";
											int tipoBorne = 0;
											Entity ent = (Entity)(object)val6;
											if (XDataLayout.lerXDataBorneLayout(ref ent, ref painel, ref regua, ref borne, ref tipoBorne) && painel == iPnO)
											{
												((DBObject)val6).UpgradeOpen();
												ent = (Entity)(object)val6;
												XDataLayout.GravarXDataBorneLayout(ref ent, iPnN, regua, borne, tipoBorne);
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

	public static void TrocaPainelTOPO(int iPnO, int iPnN)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected Obj, but got Unknown
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
											DeclaracoesTopografico.structureDispTopografico dTpg = default;
											BlockReference blockRef = val6;
											if (XDataTopografico.lerXDataDispTopografico(ref blockRef, ref dTpg) && dTpg.painel == iPnO)
											{
												dTpg.painel = iPnN;
												((DBObject)val6).UpgradeOpen();
												blockRef = val6;
												XDataTopografico.GravarXDataDispTopografico(ref blockRef, dTpg);
											}
											DeclaracoesTopografico.structureBorneTopografico bTpg = default;
											blockRef = val6;
											if (XDataTopografico.lerXDataBorneTopografico(ref blockRef, ref bTpg) && bTpg.painel == iPnO)
											{
												bTpg.painel = iPnN;
												((DBObject)val6).UpgradeOpen();
												blockRef = val6;
												XDataTopografico.GravarXDataBorneTopografico(ref blockRef, bTpg);
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

	public static void TrocaPainelCircuito(List<string> lHandle, int iPnNovo)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected Obj, but got Unknown
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
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
									if (!lHandle.Contains(((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString()))
									{
										continue;
									}
									Polyline val6 = (Polyline)(object)((val5 is Polyline) ? val5 : null);
									try
									{
										if (val6 == null)
										{
											continue;
										}
										DeclaracoesEntidades.StructureConexao conex = default;
										Polyline pl = val6;
										if (XDataConexao.lerXDataConexao(ref pl, ref conex))
										{
											conex.Painel = checked((short)iPnNovo);
											short tipo = conex.Tipo;
											if ((uint)(tipo - 1) <= 3u)
											{
												((DBObject)val6).UpgradeOpen();
												pl = val6;
												XDataConexao.GravarXDataConexao(ref pl, conex);
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

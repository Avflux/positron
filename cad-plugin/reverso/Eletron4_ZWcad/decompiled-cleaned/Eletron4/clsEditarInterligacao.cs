using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.GraphicsInterface;
using nCVEDDpS2Wye0s6s6hA;
using wMgkqQprEh9s8pjDa7d;

namespace Eletron4;

public class clsEditarInterligacao
{
	public static void EditaNomeDeVeiasImportadasDoExcels(ref ClsCabos.CaboDWG[] mCabosDWG, ref ProgressBar ProgressBar1, ref CDadosAccessInterligacao CDadosAccessInterligacao)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected Obj, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected Obj, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected Obj, but got Unknown
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected Obj, but got Unknown
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Expected Obj, but got Unknown
		eMRB2xpiIumgMRD8j88[] array = new eMRB2xpiIumgMRD8j88[1];
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
						long num = 0L;
						BlockTableRecordEnumerator enumerator = default;
						try
						{
							enumerator = val4.GetEnumerator();
							short tipo = default;
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.Current;
								Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
								DBText val6 = (DBText)(object)((val5 is DBText) ? val5 : null);
								if (val6 != null)
								{
									string handle = "";
									string THandle = "";
									Entity ent = (Entity)(object)val6;
									string sOpcionais = "";
									bool flag = XDataInterligacao.lerXDataAuxInterligacao(ref ent, ref handle, ref tipo, ref THandle, ref sOpcionais);
									val6 = (DBText)ent;
									if (flag && tipo == 1)
									{
										int num2 = Information.UBound(array) + 1;
										array = (eMRB2xpiIumgMRD8j88[])Utils.CopyArray(array, new eMRB2xpiIumgMRD8j88[num2 + 1]);
										array[num2].btNp42maiU = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
										array[num2].HpMpCeXr4I = handle;
									}
								}
								num++;
							}
						}
						finally
						{
							((IDisposable)enumerator)?.Dispose();
						}
						ProgressBar1.Minimum = 0;
						ProgressBar1.Maximum = (int)num;
						ProgressBar1.Step = 1;
						ProgressBar1.Value = 0;
						BlockTableRecordEnumerator enumerator2 = default;
						try
						{
							enumerator2 = val4.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								ObjectId current2 = enumerator2.Current;
								Entity val7 = (Entity)val2.GetObject(current2, (OpenMode)0);
								Polyline pl = (Polyline)(object)((val7 is Polyline) ? val7 : null);
								if (pl != null)
								{
									DeclaracoesEntidades.StructureInterligacao ilig = default;
									if (XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig) && ilig.NumVeia != -1000)
									{
										int num3 = Information.UBound(mCabosDWG);
										for (int i = 1; i <= num3; i++)
										{
											if (Operators.CompareString(mCabosDWG[i].sTagOriginal.ToUpper().Trim(), ilig.Tag_Cabo.ToUpper().Trim(), TextCompare: true) != 0)
											{
												continue;
											}
											if (ilig.Tipo == 1 && ((ilig.Painel1 != mCabosDWG[i].iPn1) | (ilig.Painel2 != mCabosDWG[i].iPn2)))
											{
												ilig.Painel1 = (short)mCabosDWG[i].iPn1;
												ilig.Painel2 = (short)mCabosDWG[i].iPn2;
												((DBObject)pl).UpgradeOpen();
												XDataInterligacao.AtualizaXDataInterligacao(ref pl, ref ilig);
											}
											if (ilig.Tipo == 2)
											{
												if (ilig.Painel1 == 0 && ilig.Painel2 != mCabosDWG[i].iPn2)
												{
													ilig.Painel2 = (short)mCabosDWG[i].iPn2;
												}
												if (ilig.Painel2 == 0 && ilig.Painel1 != mCabosDWG[i].iPn1)
												{
													ilig.Painel1 = (short)mCabosDWG[i].iPn1;
												}
												((DBObject)pl).UpgradeOpen();
												XDataInterligacao.AtualizaXDataInterligacao(ref pl, ref ilig);
											}
											string text = gWITT0T3TW(((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString(), array);
											if (Operators.CompareString(text, "", TextCompare: true) == 0)
											{
												continue;
											}
											ilig.Tag_Cabo = mCabosDWG[i].sTagNovo;
											string novoValor = (ilig.NomeVeia = Conversions.ToString(CDadosAccessInterligacao.LeNomeDeUmaVeiaDeUmCabo(ref mCabosDWG[i].sTagNovo, ilig.NumVeia)));
											((DBObject)pl).UpgradeOpen();
											XDataInterligacao.AtualizaXDataInterligacao(ref pl, ref ilig);
											if (Operators.CompareString(ilig.NomeVeia.Trim(), "", TextCompare: true) != 0)
											{
												if (ilig.ocultaTag != 0)
												{
													if (ilig.ocultaTag == 1)
													{
														novoValor = " (" + ilig.NomeVeia + ")";
													}
												}
												else
												{
													novoValor = ilig.Tag_Cabo + " (" + ilig.NomeVeia + ")";
												}
											}
											else if (ilig.ocultaTag != 0)
											{
												if (ilig.ocultaTag == 1)
												{
													novoValor = ilig.NumVeia.ToString();
												}
											}
											else
											{
												novoValor = ilig.Tag_Cabo + DeclaracoesGeral.Conf.SeparadorCaboVeia + ilig.NumVeia;
											}
											Entity val8 = (Entity)Geral.HandleToObject(text);
											if (val8 != null)
											{
												DBText val9 = (DBText)(object)((val8 is DBText) ? val8 : null);
												if (val9 != null)
												{
													clsTextos.AtualizarTexto(val9, novoValor);
												}
											}
										}
									}
								}
								ProgressBar1.Value++;
							}
						}
						finally
						{
							((IDisposable)enumerator2)?.Dispose();
						}
						DeclaracoesGeral.bAnularEventos = true;
						val2.Commit();
						DeclaracoesGeral.bAnularEventos = false;
						ProgressBar1.Value = 0;
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
	}

	private static string gWITT0T3TW(string P_0, eMRB2xpiIumgMRD8j88[] P_1)
	{
		string result = "";
		int num = Information.UBound(P_1);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (Operators.CompareString(P_1[i].HpMpCeXr4I, P_0, TextCompare: true) == 0)
			{
				result = P_1[i].btNp42maiU;
				break;
			}
		}
		return result;
	}

	public static void SincronizaVeiasDoCaderno(ref CDadosAccessInterligacao CDadosAccessInterligacao, bool bProgress = true)
	{
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected Obj, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected Obj, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected Obj, but got Unknown
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		//IL_032c: Unknown result type (might be due to invalid IL or missing references)
		//IL_037b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0380: Unknown result type (might be due to invalid IL or missing references)
		//IL_0409: Unknown result type (might be due to invalid IL or missing references)
		//IL_040e: Unknown result type (might be due to invalid IL or missing references)
		//IL_042d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0432: Unknown result type (might be due to invalid IL or missing references)
		cDadosAccess.carregaDadosDWG();
		if (bProgress)
		{
			DeclaracoesGeral._uscPagina.Quantidade = 6;
			DeclaracoesGeral._uscPagina.pbIniciar();
		}
		CDadosAccessInterligacao.LimpaVeiasDoArquivo();
		if (bProgress)
		{
			DeclaracoesGeral._uscPagina.pbPasso();
		}
		CDadosAccessInterligacao.IndefineVeiasDeUmcadeno();
		if (bProgress)
		{
			DeclaracoesGeral._uscPagina.pbPasso();
		}
		clsTextos.structureTextoCaderno[] TextoCabo = new clsTextos.structureTextoCaderno[1];
		clsInterligacao.buscaTextosdosCabos(ref TextoCabo);
		if (bProgress)
		{
			DeclaracoesGeral._uscPagina.pbPasso();
		}
		SincVeias[] SincVeias = new SincVeias[1];
		int num = 0;
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
							num++;
							if (!((ilig.Tipo == 1) | ((ilig.Tipo == 2) & (ilig.Painel1 > 0)) | (ilig.Tipo == 3)) || !((Operators.CompareString(Strings.Trim(ilig.Tag_Cabo), "", TextCompare: true) != 0) & (ilig.NumVeia > -100)))
							{
								continue;
							}
							if (!((ilig.Tipo == 1) | (ilig.Tipo == 3)))
							{
								if (ilig.Tipo != 2)
								{
									continue;
								}
								bool flag = true;
								int num2 = Information.UBound(SincVeias);
								for (int i = 0; i <= num2; i++)
								{
									flag = true;
									if ((Operators.CompareString(SincVeias[i].sTag, ilig.Tag_Cabo, TextCompare: true) == 0) & (SincVeias[i].iIndice == ilig.NumVeia) & (Operators.CompareString(SincVeias[i].sNomeVeia, ilig.NomeVeia, TextCompare: true) == 0))
									{
										SincVeias[i].sHandle2 = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
										SincVeias[i].iArquivo2 = DeclaracoesGeral.arqAtivo.Indice;
										SincVeias[i].sPagina2 = ((Entity)pl).Layer.ToString();
										SincVeias[i].sHandleTag2 = clsTextos.EncontraTextoDoCabo(TextoCabo, ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString());
										flag = false;
										break;
									}
								}
								if (flag)
								{
									int num3 = Information.UBound(SincVeias) + 1;
									SincVeias = (SincVeias[])Utils.CopyArray(SincVeias, new SincVeias[num3 + 1]);
									SincVeias[num3].sTag = ilig.Tag_Cabo;
									SincVeias[num3].iIndice = ilig.NumVeia;
									SincVeias[num3].sNomeVeia = ilig.NomeVeia;
									SincVeias[num3].sHandle1 = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
									SincVeias[num3].sHandleTag1 = clsTextos.EncontraTextoDoCabo(TextoCabo, ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString());
									SincVeias[num3].iArquivo1 = DeclaracoesGeral.arqAtivo.Indice;
									SincVeias[num3].sPagina1 = ((Entity)pl).Layer.ToString();
									SincVeias[num3].sHandle2 = "";
									SincVeias[num3].iArquivo2 = 0;
									SincVeias[num3].sPagina2 = "";
									SincVeias[num3].Del = "";
								}
							}
							else
							{
								int num4 = Information.UBound(SincVeias) + 1;
								SincVeias = (SincVeias[])Utils.CopyArray(SincVeias, new SincVeias[num4 + 1]);
								SincVeias[num4].sTag = ilig.Tag_Cabo;
								SincVeias[num4].iIndice = ilig.NumVeia;
								SincVeias[num4].sNomeVeia = ilig.NomeVeia;
								SincVeias[num4].sHandle1 = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
								SincVeias[num4].sHandleTag1 = clsTextos.EncontraTextoDoCabo(TextoCabo, ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString());
								SincVeias[num4].iArquivo1 = DeclaracoesGeral.arqAtivo.Indice;
								SincVeias[num4].sPagina1 = ((Entity)pl).Layer.ToString();
								SincVeias[num4].sHandle2 = "";
								SincVeias[num4].iArquivo2 = 0;
								SincVeias[num4].sPagina2 = "";
								SincVeias[num4].Del = "";
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
				if (bProgress)
				{
					DeclaracoesGeral._uscPagina.pbPasso();
				}
				CDadosAccessInterligacao.SincronizarTodasAsVeias(ref SincVeias);
				if (bProgress)
				{
					DeclaracoesGeral._uscPagina.pbPasso();
				}
				int num5 = Information.UBound(SincVeias);
				for (int j = 1; j <= num5; j++)
				{
					if (Operators.CompareString(SincVeias[j].Del, "#OK#", TextCompare: true) == 0)
					{
						if (Operators.CompareString(SincVeias[j].sHandle1, "", TextCompare: true) != 0)
						{
							IndefineumVeiaDoCabo(SincVeias[j].sHandle1, SincVeias[j].sHandleTag1);
						}
						if (Operators.CompareString(SincVeias[j].sHandle2, "", TextCompare: true) == 0)
						{
							SincVeias[j].sHandle2 = BuscaHandleDoPar(SincVeias[j].sHandle1);
							SincVeias[j].sHandleTag2 = clsTextos.EncontraTextoDoCabo(TextoCabo, SincVeias[j].sHandle2);
						}
						if (Operators.CompareString(SincVeias[j].sHandle2, "", TextCompare: true) != 0)
						{
							IndefineumVeiaDoCabo(SincVeias[j].sHandle2, SincVeias[j].sHandleTag2);
						}
					}
				}
				if (bProgress)
				{
					DeclaracoesGeral._uscPagina.pbFim();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}

	public static void CaboseVeiasDoCadernoDiscrepantes(bool bPesquisa, [Optional][DefaultParameterValue(null)] ref structureNomeVeiasErradas[] MVeiasErradas)
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected Obj, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected Obj, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected Obj, but got Unknown
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0351: Unknown result type (might be due to invalid IL or missing references)
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		//IL_0376: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Expected Obj, but got Unknown
		//IL_03ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cb: Unknown result type (might be due to invalid IL or missing references)
		DeclaracoesInterligacao.structureCabo[] MCabos = new DeclaracoesInterligacao.structureCabo[1];
		int num = 0;
		MVeiasErradas = new structureNomeVeiasErradas[1];
		CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
		cDadosAccessInterligacao3.BuscaCabo(ref MCabos);
		cDadosAccessInterligacao3.FechaConexao();
		List<string> list = new List<string>();
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
							Polyline pl = (Polyline)(object)((val5 is Polyline) ? val5 : null);
							if (pl == null)
							{
								continue;
							}
							DeclaracoesEntidades.StructureInterligacao ilig = default;
							if (!XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig) || list.Contains(((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString()) || ilig.NumVeia == -1000)
							{
								continue;
							}
							if (ilig.Tipo != 1)
							{
								if (ilig.Tipo != 2)
								{
									continue;
								}
								DeclaracoesInterligacao.structureCabo[] array = MCabos;
								for (int i = 0; i < array.Length; i++)
								{
									DeclaracoesInterligacao.structureCabo structureCabo = array[i];
									if (Operators.CompareString(structureCabo.Tag, ilig.Tag_Cabo, TextCompare: true) != 0)
									{
										continue;
									}
									if (((structureCabo.Pn1 == ilig.Painel1) & (structureCabo.Pn2 == ilig.Painel2)) || ((structureCabo.Pn1 == ilig.Painel2) & (structureCabo.Pn2 == ilig.Painel1)))
									{
										break;
									}
									DeclaracoesEntidades.StructureInterligacao ilig2 = default;
									list.Add(((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString());
									Entity val6 = (Entity)Geral.HandleToObject(ilig.handle);
									if (val6 == null)
									{
										break;
									}
									Polyline pl2 = (Polyline)(object)((val6 is Polyline) ? val6 : null);
									if (pl2 == null || !XDataInterligacao.lerXDataInterligacao(ref pl2, ref ilig2))
									{
										break;
									}
									list.Add(((object)((DBObject)pl2).Handle/*cast due to constrained. prefix*/).ToString());
									if (!(((ilig.Painel1 == structureCabo.Pn1) & (ilig.Painel2 == 0) & (ilig2.Painel1 == 0) & (ilig2.Painel2 == structureCabo.Pn2)) | ((ilig.Painel1 == structureCabo.Pn2) & (ilig.Painel2 == 0) & (ilig2.Painel1 == 0) & (ilig2.Painel2 == structureCabo.Pn1))))
									{
										if (!bPesquisa)
										{
											ilig.Painel1 = (short)structureCabo.Pn1;
											ilig.Painel2 = 0;
											((DBObject)pl).UpgradeOpen();
											XDataInterligacao.AtualizaXDataInterligacao(ref pl, ref ilig);
											ilig2.Painel1 = 0;
											ilig2.Painel2 = (short)structureCabo.Pn2;
											((DBObject)pl2).UpgradeOpen();
											XDataInterligacao.AtualizaXDataInterligacao(ref pl2, ref ilig2);
										}
										else
										{
											num++;
											MVeiasErradas = (structureNomeVeiasErradas[])Utils.CopyArray(MVeiasErradas, new structureNomeVeiasErradas[num + 1]);
											MVeiasErradas[num].sTag = ilig.Tag_Cabo;
											MVeiasErradas[num].sHandle = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
											MVeiasErradas[num].ipn1V = ilig.Painel1;
											MVeiasErradas[num].ipn2V = ilig.Painel2;
											MVeiasErradas[num].ipn1B = structureCabo.Pn1;
											MVeiasErradas[num].ipn2B = structureCabo.Pn2;
										}
									}
									break;
								}
								continue;
							}
							DeclaracoesInterligacao.structureCabo[] array2 = MCabos;
							for (int j = 0; j < array2.Length; j++)
							{
								DeclaracoesInterligacao.structureCabo structureCabo2 = array2[j];
								if (Operators.CompareString(structureCabo2.Tag, ilig.Tag_Cabo, TextCompare: true) != 0)
								{
									continue;
								}
								if (!((structureCabo2.Pn1 == ilig.Painel1) & (structureCabo2.Pn2 == ilig.Painel2)) && !((structureCabo2.Pn1 == ilig.Painel2) & (structureCabo2.Pn2 == ilig.Painel1)))
								{
									if (!bPesquisa)
									{
										ilig.Painel1 = (short)structureCabo2.Pn1;
										ilig.Painel2 = (short)structureCabo2.Pn2;
										((DBObject)pl).UpgradeOpen();
										XDataInterligacao.AtualizaXDataInterligacao(ref pl, ref ilig);
										list.Add(((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString());
									}
									else
									{
										num++;
										MVeiasErradas = (structureNomeVeiasErradas[])Utils.CopyArray(MVeiasErradas, new structureNomeVeiasErradas[num + 1]);
										MVeiasErradas[num].sTag = ilig.Tag_Cabo;
										MVeiasErradas[num].sHandle = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
										MVeiasErradas[num].ipn1V = ilig.Painel1;
										MVeiasErradas[num].ipn2V = ilig.Painel2;
										MVeiasErradas[num].ipn1B = structureCabo2.Pn1;
										MVeiasErradas[num].ipn2B = structureCabo2.Pn2;
									}
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

	public static void AtualizaNomesDosCabos()
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected Obj, but got Unknown
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected Obj, but got Unknown
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected Obj, but got Unknown
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				try
				{
					List<string> sCaboSingelos = new List<string>();
					CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
					cDadosAccessInterligacao3.CaboSingelo(ref sCaboSingelos);
					cDadosAccessInterligacao3.FechaConexao();
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
							DBText val6 = (DBText)(object)((val5 is DBText) ? val5 : null);
							if (val6 == null)
							{
								continue;
							}
							string handle = "";
							string THandle = "";
							Entity ent = (Entity)(object)val6;
							string sOpcionais = "";
							bool flag = XDataInterligacao.lerXDataAuxInterligacao(ref ent, ref handle, ref tipo, ref THandle, ref sOpcionais);
							val6 = (DBText)ent;
							if (!flag || tipo != 1)
							{
								continue;
							}
							Polyline pl = (Polyline)Geral.HandleToObject(handle);
							if (pl == null)
							{
								continue;
							}
							DeclaracoesEntidades.StructureInterligacao ilig = default;
							if (!XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig))
							{
								continue;
							}
							string text = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
							if (ilig.NumVeia != -1000)
							{
								text = "";
								if (!sCaboSingelos.Contains(ilig.Tag_Cabo))
								{
									if (DeclaracoesGeral.Conf.InterligacaoLayout != 3)
									{
										if (Operators.CompareString(ilig.NomeVeia.Trim(), "", TextCompare: true) == 0)
										{
											text = ilig.NumVeia.ToString();
											if (ilig.ocultaTag == 0)
											{
												text = ilig.Tag_Cabo + DeclaracoesGeral.Conf.SeparadorCaboVeia + text;
											}
										}
										else
										{
											text = "(" + ilig.NomeVeia.Trim() + ")";
											if (ilig.ocultaTag == 0)
											{
												text = ilig.Tag_Cabo + " " + text;
											}
										}
									}
									else
									{
										text = ilig.NomeVeia;
										if (Operators.CompareString(text, "", TextCompare: true) == 0)
										{
											text = ilig.NumVeia.ToString();
										}
									}
								}
								else if (DeclaracoesGeral.Conf.InterligacaoLayout != 3)
								{
									text = ilig.Tag_Cabo;
									if (Operators.CompareString(ilig.NomeVeia.Trim(), "", TextCompare: true) != 0)
									{
										text = ilig.Tag_Cabo + " (" + ilig.NomeVeia + ")";
										if (ilig.ocultaTag == 1)
										{
											text = "(" + ilig.NomeVeia + ")";
										}
									}
								}
								else
								{
									text = ilig.NomeVeia;
									if (Operators.CompareString(text, "", TextCompare: true) == 0)
									{
										text = ilig.NumVeia.ToString();
									}
								}
							}
							if (Operators.CompareString(val6.TextString, text, TextCompare: true) != 0)
							{
								clsTextos.AtualizarTexto(val6, text);
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

	public static void AtualizaXdatadosCabosVeiasUsadasCaderno(ref structureVeiasCaderno[] VeiasCaderno)
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected Obj, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected Obj, but got Unknown
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected Obj, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected Obj, but got Unknown
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Expected Obj, but got Unknown
		try
		{
			DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					try
					{
						List<string> sCaboSingelos = new List<string>();
						CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
						cDadosAccessInterligacao3.CaboSingelo(ref sCaboSingelos);
						cDadosAccessInterligacao3.FechaConexao();
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
								DBText val6 = (DBText)(object)((val5 is DBText) ? val5 : null);
								if (val6 == null)
								{
									continue;
								}
								string handle = "";
								string THandle = "";
								Entity ent = (Entity)(object)val6;
								string sOpcionais = "";
								bool flag = XDataInterligacao.lerXDataAuxInterligacao(ref ent, ref handle, ref tipo, ref THandle, ref sOpcionais);
								val6 = (DBText)ent;
								if (!flag)
								{
									continue;
								}
								Polyline pl = (Polyline)Geral.HandleToObject(handle);
								if (pl == null)
								{
									continue;
								}
								DeclaracoesEntidades.StructureInterligacao ilig = default;
								if (!XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig) || ilig.NumVeia == -1000)
								{
									continue;
								}
								int num = Information.UBound(VeiasCaderno);
								for (int i = 1; i <= num; i = checked(i + 1))
								{
									if (Operators.CompareString(VeiasCaderno[i].sTag, ilig.Tag_Cabo, TextCompare: true) == 0 && VeiasCaderno[i].iIndice == ilig.NumVeia)
									{
										ilig.NomeVeia = VeiasCaderno[i].sNomeVeia;
										((DBObject)pl).UpgradeOpen();
										XDataInterligacao.AtualizaXDataInterligacao(ref pl, ref ilig);
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
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			throw;
		}
		finally
		{
		}
	}

	public static void IndefineumVeiaDoCabo(string sHandleLinha, string sHandleTexto)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected Obj, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				Polyline pl = (Polyline)Geral.HandleToObject(sHandleLinha);
				if (pl != null)
				{
					DeclaracoesEntidades.StructureInterligacao ilig = default;
					if (XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig))
					{
						ilig.Tag_Cabo = "";
						ilig.NumVeia = -1000;
						ilig.NomeVeia = "";
						ilig.ocultaTag = 0;
						((DBObject)pl).UpgradeOpen();
						XDataInterligacao.AtualizaXDataInterligacao(ref pl, ref ilig);
					}
				}
				DBText val4 = (DBText)Geral.HandleToObject(sHandleTexto);
				if (val4 != null && val4 != null)
				{
					((DBObject)val4).UpgradeOpen();
					val4.TextString = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
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

	public static void carregaTodasAsVeiasIndefinidasDoCaderno(ref structureVeiasCaderno[] VeiasCaderno)
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected Obj, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected Obj, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Expected Obj, but got Unknown
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0389: Unknown result type (might be due to invalid IL or missing references)
		//IL_038e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0392: Unknown result type (might be due to invalid IL or missing references)
		//IL_0397: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_053e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0545: Expected Obj, but got Unknown
		//IL_041c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0423: Expected Obj, but got Unknown
		//IL_0598: Unknown result type (might be due to invalid IL or missing references)
		//IL_059d: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0476: Unknown result type (might be due to invalid IL or missing references)
		//IL_047b: Unknown result type (might be due to invalid IL or missing references)
		//IL_049b: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a0: Unknown result type (might be due to invalid IL or missing references)
		VeiasCaderno = new structureVeiasCaderno[1];
		GjFnBTpYJ2jOTH3qRap[] array = new GjFnBTpYJ2jOTH3qRap[1];
		clsTextos.structureTextoCaderno[] TextoCabo = new clsTextos.structureTextoCaderno[1];
		clsInterligacao.buscaTextosdosCabos(ref TextoCabo);
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
							Polyline pl = (Polyline)(object)((val5 is Polyline) ? val5 : null);
							if (pl == null)
							{
								continue;
							}
							DeclaracoesEntidades.StructureInterligacao ilig = default;
							if (XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig) && ((ilig.Tipo == 2) & (ilig.NumVeia == -1000)))
							{
								int num = Information.UBound(array) + 1;
								array = (GjFnBTpYJ2jOTH3qRap[])Utils.CopyArray(array, new GjFnBTpYJ2jOTH3qRap[num + 1]);
								array[num].P2Op9g6qGq = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
								array[num].GadpzbY3WI = ilig.handle;
								array[num].qLLTpfVO98 = ((Entity)pl).Layer;
								if (ilig.Painel1 != 0)
								{
									array[num].v3iTWJ65Xd = ilig.Painel1;
								}
								if (ilig.Painel2 != 0)
								{
									array[num].v3iTWJ65Xd = ilig.Painel2;
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
							Entity val6 = (Entity)val2.GetObject(current2, (OpenMode)0);
							Polyline pl2 = (Polyline)(object)((val6 is Polyline) ? val6 : null);
							if (pl2 == null)
							{
								continue;
							}
							DeclaracoesEntidades.StructureInterligacao ilig2 = default;
							if (!XDataInterligacao.lerXDataInterligacao(ref pl2, ref ilig2))
							{
								continue;
							}
							int tipo = ilig2.Tipo;
							bool flag = true;
							if ((ilig2.Painel1 == 0) & (ilig2.Painel2 > 0) & (tipo != 3))
							{
								flag = false;
							}
							if (!(flag & (ilig2.NumVeia == -1000)))
							{
								continue;
							}
							int num2 = Information.UBound(VeiasCaderno) + 1;
							VeiasCaderno = (structureVeiasCaderno[])Utils.CopyArray(VeiasCaderno, new structureVeiasCaderno[num2 + 1]);
							VeiasCaderno[num2].sTag = ilig2.Tag_Cabo;
							VeiasCaderno[num2].iIndice = ilig2.NumVeia;
							VeiasCaderno[num2].sNomeVeia = ilig2.NomeVeia;
							VeiasCaderno[num2].iArquivo = DeclaracoesGeral.arqAtivo.Indice;
							VeiasCaderno[num2].sPagina = ((Entity)pl2).Layer;
							VeiasCaderno[num2].iPn1 = ilig2.Painel1;
							VeiasCaderno[num2].sHandleCabo1 = ((object)((DBObject)pl2).Handle/*cast due to constrained. prefix*/).ToString();
							VeiasCaderno[num2].sHandleTag1 = "";
							VeiasCaderno[num2].iPn2 = ilig2.Painel2;
							VeiasCaderno[num2].sHandleCabo2 = "";
							VeiasCaderno[num2].sHandleTag2 = "";
							VeiasCaderno[num2].iTipo = ilig2.Tipo;
							ref structureVeiasCaderno reference = ref VeiasCaderno[num2];
							Extents3d value = ((Drawable)pl2).Bounds.Value;
							Point3d minPoint = value.MinPoint;
							reference.X = (int)Math.Round(minPoint.X);
							ref structureVeiasCaderno reference2 = ref VeiasCaderno[num2];
							value = ((Drawable)pl2).Bounds.Value;
							minPoint = value.MinPoint;
							reference2.Y = (int)Math.Round(minPoint.Y);
							if (tipo == 3 && ((VeiasCaderno[num2].iPn1 == 0) & (VeiasCaderno[num2].iPn2 != 0)))
							{
								VeiasCaderno[num2].iPn1 = VeiasCaderno[num2].iPn2;
								VeiasCaderno[num2].iPn2 = 0;
							}
							if (ilig2.Tipo != 2)
							{
								continue;
							}
							if (ilig2.Painel1 == 0)
							{
								Entity val7 = (Entity)Geral.HandleToObject(ilig2.handle);
								if (val7 != null)
								{
									Polyline pl3 = (Polyline)(object)((val7 is Polyline) ? val7 : null);
									if (pl3 != null)
									{
										DeclaracoesEntidades.StructureInterligacao ilig3 = default;
										if (XDataInterligacao.lerXDataInterligacao(ref pl3, ref ilig3))
										{
											VeiasCaderno[num2].iPn1 = ilig3.Painel2;
											VeiasCaderno[num2].sHandleCabo1 = ((object)((DBObject)pl3).Handle/*cast due to constrained. prefix*/).ToString();
											VeiasCaderno[num2].sHandleTag1 = clsTextos.EncontraTextoDoCabo(TextoCabo, ((object)((DBObject)pl3).Handle/*cast due to constrained. prefix*/).ToString());
										}
									}
								}
							}
							if (ilig2.Painel2 != 0)
							{
								continue;
							}
							Entity val8 = (Entity)Geral.HandleToObject(ilig2.handle);
							if (val8 == null)
							{
								continue;
							}
							Polyline pl4 = (Polyline)(object)((val8 is Polyline) ? val8 : null);
							if (pl4 != null)
							{
								DeclaracoesEntidades.StructureInterligacao ilig4 = default;
								if (XDataInterligacao.lerXDataInterligacao(ref pl4, ref ilig4))
								{
									VeiasCaderno[num2].iPn2 = ilig4.Painel2;
									VeiasCaderno[num2].sHandleCabo2 = ((object)((DBObject)pl4).Handle/*cast due to constrained. prefix*/).ToString();
									VeiasCaderno[num2].sHandleTag2 = clsTextos.EncontraTextoDoCabo(TextoCabo, ((object)((DBObject)pl4).Handle/*cast due to constrained. prefix*/).ToString());
								}
							}
						}
					}
					finally
					{
						((IDisposable)enumerator2)?.Dispose();
					}
					if (Information.UBound(VeiasCaderno) < 1)
					{
						return;
					}
					int num3 = Information.UBound(VeiasCaderno) - 1;
					for (int i = num3; i >= 1; i += -1)
					{
						int num4 = i;
						for (int j = 1; j <= num4; j++)
						{
							if (Pagina.calculaPaginaDecimal(VeiasCaderno[j].sPagina) > Pagina.calculaPaginaDecimal(VeiasCaderno[j + 1].sPagina))
							{
								structureVeiasCaderno structureVeiasCaderno2 = VeiasCaderno[j];
								VeiasCaderno[j] = VeiasCaderno[j + 1];
								VeiasCaderno[j + 1] = structureVeiasCaderno2;
							}
							if (Operators.CompareString(VeiasCaderno[j].sPagina, VeiasCaderno[j + 1].sPagina, TextCompare: true) == 0 && VeiasCaderno[j].Y < VeiasCaderno[j + 1].Y)
							{
								structureVeiasCaderno structureVeiasCaderno2 = VeiasCaderno[j];
								VeiasCaderno[j] = VeiasCaderno[j + 1];
								VeiasCaderno[j + 1] = structureVeiasCaderno2;
							}
							if (Operators.CompareString(VeiasCaderno[j].sPagina, VeiasCaderno[j + 1].sPagina, TextCompare: true) == 0 && VeiasCaderno[j].Y == VeiasCaderno[j + 1].Y && VeiasCaderno[j].X > VeiasCaderno[j + 1].X)
							{
								structureVeiasCaderno structureVeiasCaderno2 = VeiasCaderno[j];
								VeiasCaderno[j] = VeiasCaderno[j + 1];
								VeiasCaderno[j + 1] = structureVeiasCaderno2;
							}
						}
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
					((IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}

	public static void carregaApenasAsVeiasIndefinidasDoCaderno(ref structureVeiasCaderno[] VeiasCaderno)
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected Obj, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected Obj, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Expected Obj, but got Unknown
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0389: Unknown result type (might be due to invalid IL or missing references)
		//IL_038e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0392: Unknown result type (might be due to invalid IL or missing references)
		//IL_0397: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_04dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e3: Expected Obj, but got Unknown
		//IL_0412: Unknown result type (might be due to invalid IL or missing references)
		//IL_0419: Expected Obj, but got Unknown
		//IL_052d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0532: Unknown result type (might be due to invalid IL or missing references)
		//IL_0552: Unknown result type (might be due to invalid IL or missing references)
		//IL_0557: Unknown result type (might be due to invalid IL or missing references)
		//IL_046c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0471: Unknown result type (might be due to invalid IL or missing references)
		//IL_0491: Unknown result type (might be due to invalid IL or missing references)
		//IL_0496: Unknown result type (might be due to invalid IL or missing references)
		VeiasCaderno = new structureVeiasCaderno[1];
		GjFnBTpYJ2jOTH3qRap[] array = new GjFnBTpYJ2jOTH3qRap[1];
		clsTextos.structureTextoCaderno[] TextoCabo = new clsTextos.structureTextoCaderno[1];
		clsInterligacao.buscaTextosdosCabos(ref TextoCabo);
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
							Polyline pl = (Polyline)(object)((val5 is Polyline) ? val5 : null);
							if (pl == null)
							{
								continue;
							}
							DeclaracoesEntidades.StructureInterligacao ilig = default;
							if (XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig) && ((ilig.Tipo == 2) & (ilig.NumVeia == -1000)))
							{
								int num = Information.UBound(array) + 1;
								array = (GjFnBTpYJ2jOTH3qRap[])Utils.CopyArray(array, new GjFnBTpYJ2jOTH3qRap[num + 1]);
								array[num].P2Op9g6qGq = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
								array[num].GadpzbY3WI = ilig.handle;
								array[num].qLLTpfVO98 = ((Entity)pl).Layer;
								if (ilig.Painel1 != 0)
								{
									array[num].v3iTWJ65Xd = ilig.Painel1;
								}
								if (ilig.Painel2 != 0)
								{
									array[num].v3iTWJ65Xd = ilig.Painel2;
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
							Entity val6 = (Entity)val2.GetObject(current2, (OpenMode)0);
							Polyline pl2 = (Polyline)(object)((val6 is Polyline) ? val6 : null);
							if (pl2 == null)
							{
								continue;
							}
							DeclaracoesEntidades.StructureInterligacao ilig2 = default;
							if (!XDataInterligacao.lerXDataInterligacao(ref pl2, ref ilig2))
							{
								continue;
							}
							int tipo = ilig2.Tipo;
							bool flag = true;
							if ((ilig2.Painel1 == 0) & (ilig2.Painel2 > 0) & (tipo != 3))
							{
								flag = false;
							}
							if (!(flag & (ilig2.NumVeia == -1000)))
							{
								continue;
							}
							int num2 = Information.UBound(VeiasCaderno) + 1;
							VeiasCaderno = (structureVeiasCaderno[])Utils.CopyArray(VeiasCaderno, new structureVeiasCaderno[num2 + 1]);
							VeiasCaderno[num2].sTag = ilig2.Tag_Cabo;
							VeiasCaderno[num2].iIndice = ilig2.NumVeia;
							VeiasCaderno[num2].sNomeVeia = ilig2.NomeVeia;
							VeiasCaderno[num2].iArquivo = DeclaracoesGeral.arqAtivo.Indice;
							VeiasCaderno[num2].sPagina = ((Entity)pl2).Layer;
							VeiasCaderno[num2].iPn1 = ilig2.Painel1;
							VeiasCaderno[num2].sHandleCabo1 = ((object)((DBObject)pl2).Handle/*cast due to constrained. prefix*/).ToString();
							VeiasCaderno[num2].sHandleTag1 = "";
							VeiasCaderno[num2].iPn2 = ilig2.Painel2;
							VeiasCaderno[num2].sHandleCabo2 = "";
							VeiasCaderno[num2].sHandleTag2 = "";
							VeiasCaderno[num2].iTipo = ilig2.Tipo;
							ref structureVeiasCaderno reference = ref VeiasCaderno[num2];
							Extents3d value = ((Drawable)pl2).Bounds.Value;
							Point3d minPoint = value.MinPoint;
							reference.X = (int)Math.Round(minPoint.X);
							ref structureVeiasCaderno reference2 = ref VeiasCaderno[num2];
							value = ((Drawable)pl2).Bounds.Value;
							minPoint = value.MinPoint;
							reference2.Y = (int)Math.Round(minPoint.Y);
							if (ilig2.Tipo != 2)
							{
								continue;
							}
							if (ilig2.Painel1 == 0)
							{
								Entity val7 = (Entity)Geral.HandleToObject(ilig2.handle);
								if (val7 != null)
								{
									Polyline pl3 = (Polyline)(object)((val7 is Polyline) ? val7 : null);
									if (pl3 != null)
									{
										DeclaracoesEntidades.StructureInterligacao ilig3 = default;
										if (XDataInterligacao.lerXDataInterligacao(ref pl3, ref ilig3))
										{
											VeiasCaderno[num2].iPn1 = ilig3.Painel2;
											VeiasCaderno[num2].sHandleCabo1 = ((object)((DBObject)pl3).Handle/*cast due to constrained. prefix*/).ToString();
											VeiasCaderno[num2].sHandleTag1 = clsTextos.EncontraTextoDoCabo(TextoCabo, ((object)((DBObject)pl3).Handle/*cast due to constrained. prefix*/).ToString());
										}
									}
								}
							}
							if (ilig2.Painel2 != 0)
							{
								continue;
							}
							Entity val8 = (Entity)Geral.HandleToObject(ilig2.handle);
							if (val8 == null)
							{
								continue;
							}
							Polyline pl4 = (Polyline)(object)((val8 is Polyline) ? val8 : null);
							if (pl4 != null)
							{
								DeclaracoesEntidades.StructureInterligacao ilig4 = default;
								if (XDataInterligacao.lerXDataInterligacao(ref pl4, ref ilig4))
								{
									VeiasCaderno[num2].iPn2 = ilig4.Painel2;
									VeiasCaderno[num2].sHandleCabo2 = ((object)((DBObject)pl4).Handle/*cast due to constrained. prefix*/).ToString();
									VeiasCaderno[num2].sHandleTag2 = clsTextos.EncontraTextoDoCabo(TextoCabo, ((object)((DBObject)pl4).Handle/*cast due to constrained. prefix*/).ToString());
								}
							}
						}
					}
					finally
					{
						((IDisposable)enumerator2)?.Dispose();
					}
					if (Information.UBound(VeiasCaderno) < 1)
					{
						return;
					}
					int num3 = Information.UBound(VeiasCaderno) - 1;
					for (int i = num3; i >= 1; i += -1)
					{
						int num4 = i;
						for (int j = 1; j <= num4; j++)
						{
							if (VeiasCaderno[j].iPn1 < VeiasCaderno[j + 1].iPn1)
							{
								structureVeiasCaderno structureVeiasCaderno2 = VeiasCaderno[j];
								VeiasCaderno[j] = VeiasCaderno[j + 1];
								VeiasCaderno[j + 1] = structureVeiasCaderno2;
							}
							if (VeiasCaderno[j].iPn1 == VeiasCaderno[j + 1].iPn1 && VeiasCaderno[j].iPn2 > VeiasCaderno[j + 1].iPn2)
							{
								structureVeiasCaderno structureVeiasCaderno2 = VeiasCaderno[j];
								VeiasCaderno[j] = VeiasCaderno[j + 1];
								VeiasCaderno[j + 1] = structureVeiasCaderno2;
							}
						}
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
					((IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}

	public static string reinsereAuxInterlig(string sHandleLN)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected Obj, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected Obj, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected Obj, but got Unknown
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
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
							DBText val6 = clsInterligacao.criarTextoNomeCabo(pl, DeclaracoesGeral.Conf.CaracterTerminalIndefinido, DeclaracoesGeral.ativo.Pagina);
							val4.AppendEntity((Entity)(object)val6);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)val6, true);
							Entity ent = (Entity)(object)val6;
							XDataInterligacao.GravarXDataAuxInterligacao(ref ent, ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString(), 1, "");
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
		return result;
	}

	public static void PesquisaCabosFaltantes(ref structureCadernoMigra[] Veias)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected Obj, but got Unknown
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected Obj, but got Unknown
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Expected Obj, but got Unknown
		structureCadernoMigra[] VeiasCaderno = new structureCadernoMigra[1];
		PointMonitorToolTips.StopMonitor();
		List<string> list = new List<string>();
		int num = 0;
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
								Polyline pl = (Polyline)(object)((val5 is Polyline) ? val5 : null);
								if (pl == null)
								{
									continue;
								}
								DeclaracoesEntidades.StructureInterligacao ilig = default;
								if (!XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig) || ilig.NumVeia <= 0 || list.Contains(ilig.Tag_Cabo))
								{
									continue;
								}
								list.Add(ilig.Tag_Cabo);
								switch (ilig.Tipo)
								{
								case 3:
									num = Information.UBound(VeiasCaderno) + 1;
									VeiasCaderno = (structureCadernoMigra[])Utils.CopyArray(VeiasCaderno, new structureCadernoMigra[num + 1]);
									VeiasCaderno[num].sTag0 = ilig.Tag_Cabo;
									VeiasCaderno[num].sTag1 = "";
									VeiasCaderno[num].iPn1 = ilig.Painel1;
									VeiasCaderno[num].iPn2 = ilig.Painel2;
									break;
								case 1:
									num = Information.UBound(VeiasCaderno) + 1;
									VeiasCaderno = (structureCadernoMigra[])Utils.CopyArray(VeiasCaderno, new structureCadernoMigra[num + 1]);
									VeiasCaderno[num].sTag0 = ilig.Tag_Cabo;
									VeiasCaderno[num].sTag1 = "";
									VeiasCaderno[num].iPn1 = ilig.Painel1;
									VeiasCaderno[num].iPn2 = ilig.Painel2;
									break;
								case 2:
								{
									num = Information.UBound(VeiasCaderno) + 1;
									VeiasCaderno = (structureCadernoMigra[])Utils.CopyArray(VeiasCaderno, new structureCadernoMigra[num + 1]);
									VeiasCaderno[num].sTag0 = ilig.Tag_Cabo;
									VeiasCaderno[num].sTag1 = "";
									if (ilig.Painel1 != 0)
									{
										VeiasCaderno[num].iPn1 = ilig.Painel1;
									}
									if (ilig.Painel2 != 0)
									{
										VeiasCaderno[num].iPn1 = ilig.Painel2;
									}
									Entity val6 = (Entity)Geral.HandleToObject(ilig.handle);
									if (val6 == null)
									{
										break;
									}
									Polyline pl2 = (Polyline)(object)((val6 is Polyline) ? val6 : null);
									if (pl2 == null)
									{
										break;
									}
									DeclaracoesEntidades.StructureInterligacao ilig2 = default;
									if (XDataInterligacao.lerXDataInterligacao(ref pl2, ref ilig2))
									{
										if (ilig2.Painel1 != 0)
										{
											VeiasCaderno[num].iPn2 = ilig2.Painel1;
										}
										if (ilig2.Painel2 != 0)
										{
											VeiasCaderno[num].iPn2 = ilig2.Painel2;
										}
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
			cDadosAccess.carregaDadosDWG();
			CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
			cDadosAccessInterligacao3.PesquisaCabosFaltantesNoBanco(ref VeiasCaderno);
			cDadosAccessInterligacao3.FechaConexao();
			num = 0;
			int num2 = Information.UBound(VeiasCaderno);
			for (int i = 1; i <= num2; i++)
			{
				if (VeiasCaderno[i].bOK)
				{
					num = Information.UBound(Veias) + 1;
					Veias = (structureCadernoMigra[])Utils.CopyArray(Veias, new structureCadernoMigra[num + 1]);
					Veias[num] = VeiasCaderno[i];
				}
			}
			PointMonitorToolTips.StartMonitor();
		}
	}

	public static void EditaNomeDoCaboNoDesenho(ref DataGridView dg)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected Obj, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected Obj, but got Unknown
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d8: Expected Obj, but got Unknown
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected Obj, but got Unknown
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					List<string> list = new List<string>();
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
								int num = dg.Rows.Count - 1;
								for (int i = 0; i <= num; i++)
								{
									if (Operators.ConditionalCompareObjectEqual(dg.Rows[i].Cells[2].Value, "OK", TextCompare: true))
									{
										string right = Conversions.ToString(dg.Rows[i].Cells[0].Value);
										string tag_Cabo = Conversions.ToString(dg.Rows[i].Cells[1].Value);
										if (Operators.CompareString(ilig.Tag_Cabo, right, TextCompare: true) == 0)
										{
											ilig.Tag_Cabo = tag_Cabo;
											((DBObject)pl).UpgradeOpen();
											XDataInterligacao.AtualizaXDataInterligacao(ref pl, ref ilig);
											list.Add(((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString());
											break;
										}
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
							short tipo = default;
							while (enumerator2.MoveNext())
							{
								ObjectId current2 = enumerator2.Current;
								Entity val6 = (Entity)val2.GetObject(current2, (OpenMode)0);
								DBText val7 = (DBText)(object)((val6 is DBText) ? val6 : null);
								if (val7 == null)
								{
									continue;
								}
								string handle = "";
								string THandle = "";
								Entity ent = (Entity)(object)val7;
								string sOpcionais = "";
								bool flag = XDataInterligacao.lerXDataAuxInterligacao(ref ent, ref handle, ref tipo, ref THandle, ref sOpcionais);
								val7 = (DBText)ent;
								if (!flag || tipo != 1 || !list.Contains(handle))
								{
									continue;
								}
								_ = val7.TextString;
								Entity val8 = (Entity)Geral.HandleToObject(handle);
								if (val8 == null)
								{
									continue;
								}
								Polyline pl2 = (Polyline)(object)((val8 is Polyline) ? val8 : null);
								if (pl2 == null)
								{
									continue;
								}
								DeclaracoesEntidades.StructureInterligacao ilig2 = default;
								if (!XDataInterligacao.lerXDataInterligacao(ref pl2, ref ilig2))
								{
									continue;
								}
								string text = "";
								if (Operators.CompareString(ilig2.NomeVeia.Trim(), "", TextCompare: true) == 0)
								{
									text = ilig2.NumVeia.ToString();
									if (ilig2.ocultaTag == 0)
									{
										text = ilig2.Tag_Cabo + DeclaracoesGeral.Conf.SeparadorCaboVeia + text;
									}
								}
								else
								{
									text = "(" + ilig2.NomeVeia + ")";
									if (ilig2.ocultaTag == 0)
									{
										text = ilig2.Tag_Cabo + " " + text;
									}
								}
								((DBObject)val7).UpgradeOpen();
								val7.TextString = text;
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
						throw;
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

	public static string BuscaHandleDoPar(string sHandleLinha)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected Obj, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected Obj, but got Unknown
		string result = "";
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				Entity val4 = (Entity)Geral.HandleToObject(sHandleLinha);
				if (val4 != null)
				{
					Polyline pl = (Polyline)(object)((val4 is Polyline) ? val4 : null);
					if (pl != null)
					{
						DeclaracoesEntidades.StructureInterligacao ilig = default;
						if (XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig) && ilig.Tipo == 2)
						{
							result = ilig.handle;
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
				((IDisposable)val2)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		return result;
	}

	public static void InsereTextosDeCabos(bool bPadraoEL = false)
	{
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected Obj, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected Obj, but got Unknown
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected Obj, but got Unknown
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected Obj, but got Unknown
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected Obj, but got Unknown
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_0296: Unknown result type (might be due to invalid IL or missing references)
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		if (!bPadraoEL)
		{
			num = Conversions.ToInteger(clsInterligacao.LeOModeloVeias());
		}
		List<string> lHandleCabos = new List<string>();
		if (num == 3)
		{
			clsTextos.capturaTodosTextosDeCabos(ref lHandleCabos);
		}
		List<string> list = new List<string>();
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
						short tipo = default;
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
							DBText val6 = (DBText)(object)((val5 is DBText) ? val5 : null);
							if (val6 != null)
							{
								string handle = "";
								Entity ent = (Entity)(object)val6;
								string THandle = "";
								string sOpcionais = "";
								bool flag = XDataInterligacao.lerXDataAuxInterligacao(ref ent, ref handle, ref tipo, ref THandle, ref sOpcionais);
								val6 = (DBText)ent;
								if (flag && ((tipo == 1) | (tipo == 3)))
								{
									list.Add(handle);
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
							Polyline pl = (Polyline)(object)((val7 is Polyline) ? val7 : null);
							if (pl == null)
							{
								continue;
							}
							DeclaracoesEntidades.StructureInterligacao ilig = default;
							if (!XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig) || list.Contains(((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString()))
							{
								continue;
							}
							string sHandle = "";
							if (num != 0)
							{
								if (num == 2)
								{
									sHandle = clsEletrosul.reinsereAuxInterligEletrosul(((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString());
								}
							}
							else
							{
								sHandle = reinsereAuxInterlig(((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString());
							}
							if (DeclaracoesGeral.Conf.InterligacaoLayout == 3)
							{
								clsENEL.ReinsereAuxInterligaENEL_SP(((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString());
							}
							string text = "";
							if (DeclaracoesGeral.Conf.InterligacaoLayout != 3)
							{
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
							}
							else
							{
								text = ilig.NomeVeia;
								if (Operators.CompareString(text, "", TextCompare: true) == 0)
								{
									text = ilig.NumVeia.ToString();
								}
							}
							ilig.iModeloVeiaFuncao = num;
							((DBObject)pl).UpgradeOpen();
							XDataInterligacao.AtualizaXDataInterligacao(ref pl, ref ilig);
							clsTextos.AtualizaUmTexto(sHandle, text);
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
}

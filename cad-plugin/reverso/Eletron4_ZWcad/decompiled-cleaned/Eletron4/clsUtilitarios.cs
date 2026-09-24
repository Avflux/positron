using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;
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

public class clsUtilitarios
{
	public struct structureFormacao
	{
		public string sCabo;

		public string sFormacao;
	}

	public struct structureFuncaoVeia
	{
		public string sCabo;

		public int iVeia;

		public string sNome;

		public string sFuncao;
	}

	public struct structureTextosCabo
	{
		public string sHandleLinha;

		public string sPaginaCabo;
	}

	public static void moverElementos()
	{
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected Obj, but got Unknown
		//IL_01be: Expected Obj, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Invalid comparison between Unknown and I4
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected Obj, but got Unknown
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected Obj, but got Unknown
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected Obj, but got Unknown
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			PromptSelectionResult selection = editor.GetSelection();
			if ((int)selection.Status == 5100)
			{
				PromptStringOptions val2 = new PromptStringOptions(Conversions.ToString(Operators.ConcatenateObject("\r\n", DeclaracoesGeral.mMensagem[1, 218])));
				val2.AllowSpaces = false;
				((PromptOptions)val2).AppendKeywordsToMessage = false;
				val2.UseDefaultValue = false;
				PromptResult val3 = editor.GetString(val2);
				string text = val3.StringResult.ToUpper().Trim();
				if (Operators.CompareString(text.Trim(), "", TextCompare: true) != 0)
				{
					if (Pagina.localizaPaginaMatriz(text) == 0)
					{
						Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 219]), MsgBoxStyle.Exclamation);
					}
					else
					{
						DeclaracoesGeral.bSuspenderEvento = true;
						SelectionSet value = selection.Value;
						ObjectIdCollection val4 = new ObjectIdCollection(value.GetObjectIds());
						foreach (object item in val4)
						{
							ObjectId val5 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							Entity val6 = (Entity)val5.GetObject((OpenMode)0);
							((DBObject)val6).UpgradeOpen();
							val6.Layer = text;
						}
						DeclaracoesGeral.bSuspenderEvento = false;
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			clsPortas.SincronizaPortas();
			Correcao.CorrigeModelosDeContatos();
			clsDispositivoAuxiliares.SincronizaContatos();
			clsConexao.sincronizaCircuitos();
			clsDePara.SincronizaDePara(bUpdateProp: false);
			EditaPortaDipAuxPainelModeloFabricante();
			clsInterligacao.SincronizaCruzamentoInterlig();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError((Exception)ex);
			Exception ex2 = ex;
			val.Abort();
			Interaction.MsgBox(((Exception)(object)ex2).Message, MsgBoxStyle.Information);
			ProjectData.ClearProjectError();
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	[CommandMethod("PortasChesf")]
	public static void EditaPortaDipAuxPainelModeloFabricanteManualmente()
	{
		EditaPortaDipAuxPainelModeloFabricante();
	}

	public static void EditaPortaDipAuxPainelModeloFabricante(bool bProgress = true)
	{
		//IL_04a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ac: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected Obj, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected Obj, but got Unknown
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected Obj, but got Unknown
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Expected Obj, but got Unknown
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected Obj, but got Unknown
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Expected Obj, but got Unknown
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected Obj, but got Unknown
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Expected Obj, but got Unknown
		//IL_03bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0348: Unknown result type (might be due to invalid IL or missing references)
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		cDadosLM cDadosLM2 = null;
		try
		{
			Declaracoes2.MModeloDeMascara[] mModelo = new Declaracoes2.MModeloDeMascara[1];
			DicionarioMascaras.LeOsModelosDeMascaras(ref mModelo, bComplementarModelo: true);
			Declaracoes2.MModelosDeContatos[] mModelo2 = new Declaracoes2.MModelosDeContatos[1];
			DicionarioContatos.LeOsModelosDeDeDicionarioContatos(ref mModelo2);
			cDadosLM2 = new cDadosLM();
			clsLM.LModFab[] mModFab = null;
			cDadosLM2.buscaListaDeFabricanteDoMaterial(ref mModFab);
			DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					if (bProgress)
					{
						DeclaracoesGeral._uscPagina.Quantidade = clsBlocos.AcadObjectCount();
						DeclaracoesGeral._uscPagina.pbIniciar();
					}
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
								string sModelo = "";
								BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
								try
								{
									if (val6 != null)
									{
										Entity ent = val5;
										string tipoImportado = "";
										string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
										string left = text;
										if (Operators.CompareString(left, "A", TextCompare: true) != 0)
										{
											if (Operators.CompareString(left, "E", TextCompare: true) != 0)
											{
												if (Operators.CompareString(left, "P", TextCompare: true) == 0)
												{
													DeclaracoesEntidades.StructureDispositivo structureDispositivo = default;
													BlockReference blockRef = val6;
													object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
													structureDispositivo = ((obj == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj));
													int num2 = Information.UBound(mModelo2);
													for (int i = 1; i <= num2; i = checked(i + 1))
													{
														if (mModelo2[i].iIndiceModelo == structureDispositivo.indexModelo)
														{
															sModelo = mModelo2[i].sNomeModelo;
															break;
														}
													}
													tipoImportado = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
													clsBlocos.AtualizaValorDeUmAtributoPMF(ref tipoImportado, Conversions.ToString((int)structureDispositivo.Painel), structureDispositivo.iLM1, mModFab, sModelo);
												}
											}
											else
											{
												BlockReference blockRef = (BlockReference)val5;
												object obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
												Entity val7 = (Entity)Geral.HandleToObject(((obj2 == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj2)).HandleDaMascara);
												try
												{
													if (val5 != null)
													{
														DeclaracoesEntidades.StructureMascara structureMascara = default;
														blockRef = (BlockReference)val7;
														object obj3 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
														structureMascara = ((obj3 == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj3));
														int num3 = Information.UBound(mModelo);
														for (int j = 1; j <= num3; j = checked(j + 1))
														{
															if (mModelo[j].iIndiceModelo == structureMascara.indexModelo)
															{
																sModelo = mModelo[j].sNomeModelo;
																break;
															}
														}
														tipoImportado = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
														clsBlocos.AtualizaValorDeUmAtributoPMF(ref tipoImportado, Conversions.ToString((int)structureMascara.Painel), structureMascara.iLM1, mModFab, sModelo);
													}
												}
												finally
												{
													((IDisposable)val7)?.Dispose();
												}
											}
										}
										else
										{
											DeclaracoesEntidades.StructureAuxiliar structureAuxiliar = default;
											BlockReference blockRef = val6;
											object obj4 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
											Entity val8 = (Entity)Geral.HandleToObject(((obj4 == null) ? default(DeclaracoesEntidades.StructureAuxiliar) : ((DeclaracoesEntidades.StructureAuxiliar)obj4)).HandleBob);
											try
											{
												if (val8 != null)
												{
													DeclaracoesEntidades.StructureDispositivo structureDispositivo2 = default;
													blockRef = (BlockReference)val8;
													object obj5 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
													structureDispositivo2 = ((obj5 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj5));
													int num4 = Information.UBound(mModelo2);
													for (int k = 1; k <= num4; k = checked(k + 1))
													{
														if (mModelo2[k].iIndiceModelo == structureDispositivo2.indexModelo)
														{
															sModelo = mModelo2[k].sNomeModelo;
															break;
														}
													}
													tipoImportado = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
													clsBlocos.AtualizaValorDeUmAtributoPMF(ref tipoImportado, Conversions.ToString((int)structureDispositivo2.Painel), structureDispositivo2.iLM1, mModFab, sModelo);
												}
											}
											finally
											{
												((IDisposable)val8)?.Dispose();
											}
										}
									}
									if (bProgress)
									{
										num = checked(num + 1);
										if (num == 100)
										{
											DeclaracoesGeral._uscPagina.pbPasso(num);
											num = 0;
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
					if (bProgress)
					{
						DeclaracoesGeral._uscPagina.pbFim();
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
		catch (Exception ex)
		{
			ProjectData.SetProjectError((Exception)ex);
			throw;
		}
		finally
		{
			cDadosLM2.fechaConexao();
		}
	}

	public static void EditaPortasPainelModeloFabricante()
	{
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Expected Obj, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected Obj, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected Obj, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected Obj, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Expected Obj, but got Unknown
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Expected Obj, but got Unknown
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Expected Obj, but got Unknown
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		cDadosLM cDadosLM2 = new cDadosLM();
		try
		{
			Declaracoes2.MModeloDeMascara[] mModelo = new Declaracoes2.MModeloDeMascara[1];
			DicionarioMascaras.LeOsModelosDeMascaras(ref mModelo, bComplementarModelo: true);
			clsLM.LModFab[] mModFab = null;
			cDadosLM2.buscaListaDeFabricanteDoMaterial(ref mModFab);
			DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
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
							Entity ent = (Entity)val2.GetObject(current, (OpenMode)0);
							string sModelo = "";
							BlockReference val5 = (BlockReference)(object)((ent is BlockReference) ? ent : null);
							if (val5 != null)
							{
								string tipoImportado = "";
								string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
								if (Operators.CompareString(left, "E", TextCompare: true) == 0)
								{
									BlockReference blockRef = (BlockReference)ent;
									object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
									ent = (Entity)(object)blockRef;
									object obj2 = obj;
									Entity val6 = (Entity)Geral.HandleToObject(((obj2 == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj2)).HandleDaMascara);
									if (ent != null)
									{
										DeclaracoesEntidades.StructureMascara structureMascara = default;
										blockRef = (BlockReference)val6;
										obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
										val6 = (Entity)(object)blockRef;
										object obj3 = obj;
										structureMascara = ((obj3 == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj3));
										int num2 = Information.UBound(mModelo);
										for (int i = 1; i <= num2; i = checked(i + 1))
										{
											if (mModelo[i].iIndiceModelo == structureMascara.indexModelo)
											{
												sModelo = mModelo[i].sNomeModelo;
												break;
											}
										}
										tipoImportado = ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString();
										clsBlocos.AtualizaValorDeUmAtributoPMF(ref tipoImportado, Conversions.ToString((int)structureMascara.Painel), structureMascara.iLM1, mModFab, sModelo);
									}
								}
							}
							num = checked(num + 1);
							if (num == 100)
							{
								DeclaracoesGeral._uscPagina.pbPasso(num);
								num = 0;
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
					DeclaracoesGeral._uscPagina.pbFim();
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
			cDadosLM2.fechaConexao();
		}
	}

	public static void EditaDipAuxPainelModeloFabricante()
	{
		//IL_032c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0332: Expected Obj, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected Obj, but got Unknown
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected Obj, but got Unknown
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected Obj, but got Unknown
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected Obj, but got Unknown
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		cDadosLM cDadosLM2 = new cDadosLM();
		try
		{
			Declaracoes2.MModelosDeContatos[] mModelo = null;
			DicionarioContatos.LeOsModelosDeDeDicionarioContatos(ref mModelo);
			clsLM.LModFab[] mModFab = null;
			cDadosLM2.buscaListaDeFabricanteDoMaterial(ref mModFab);
			DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
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
							Entity ent = (Entity)val2.GetObject(current, (OpenMode)0);
							string sModelo = "";
							BlockReference blockRef = (BlockReference)(object)((ent is BlockReference) ? ent : null);
							if (blockRef != null)
							{
								string tipoImportado = "";
								string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
								string left = text;
								if (Operators.CompareString(left, "A", TextCompare: true) != 0)
								{
									if (Operators.CompareString(left, "P", TextCompare: true) == 0)
									{
										DeclaracoesEntidades.StructureDispositivo structureDispositivo = default;
										object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
										structureDispositivo = ((obj == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj));
										int num2 = Information.UBound(mModelo);
										for (int i = 1; i <= num2; i = checked(i + 1))
										{
											if (mModelo[i].iIndiceModelo == structureDispositivo.indexModelo)
											{
												sModelo = mModelo[i].sNomeModelo;
												break;
											}
										}
										tipoImportado = ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString();
										clsBlocos.AtualizaValorDeUmAtributoPMF(ref tipoImportado, Conversions.ToString((int)structureDispositivo.Painel), structureDispositivo.iLM1, mModFab, sModelo);
									}
								}
								else
								{
									DeclaracoesEntidades.StructureAuxiliar structureAuxiliar = default;
									object obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
									Entity val5 = (Entity)Geral.HandleToObject(((obj2 == null) ? default(DeclaracoesEntidades.StructureAuxiliar) : ((DeclaracoesEntidades.StructureAuxiliar)obj2)).HandleBob);
									if (val5 != null)
									{
										DeclaracoesEntidades.StructureDispositivo structureDispositivo2 = default;
										BlockReference blockRef2 = (BlockReference)val5;
										object obj3 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef2);
										val5 = (Entity)(object)blockRef2;
										structureDispositivo2 = ((obj3 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj3));
										int num3 = Information.UBound(mModelo);
										for (int j = 1; j <= num3; j = checked(j + 1))
										{
											if (mModelo[j].iIndiceModelo == structureDispositivo2.indexModelo)
											{
												sModelo = mModelo[j].sNomeModelo;
												break;
											}
										}
										tipoImportado = ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString();
										clsBlocos.AtualizaValorDeUmAtributoPMF(ref tipoImportado, Conversions.ToString((int)structureDispositivo2.Painel), structureDispositivo2.iLM1, mModFab, sModelo);
									}
								}
							}
							num = checked(num + 1);
							if (num == 100)
							{
								DeclaracoesGeral._uscPagina.pbPasso(num);
								num = 0;
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
					DeclaracoesGeral._uscPagina.pbFim();
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
			cDadosLM2.fechaConexao();
		}
	}

	[CommandMethod("CorrigeInterligacao")]
	public static void CorrigeInterliacaoIndefinida()
	{
		//IL_04ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b1: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected Obj, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected Obj, but got Unknown
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Expected Obj, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		string pagina = DeclaracoesGeral.ativo.Pagina;
		clsInterligacao clsInterligacao2 = new clsInterligacao();
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
					int num2 = 0;
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
							Polyline pl = (Polyline)(object)((val5 is Polyline) ? val5 : null);
							if (pl != null)
							{
								DeclaracoesEntidades.StructureInterligacao ilig = default;
								if (XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig))
								{
									num2++;
								}
							}
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
					DeclaracoesGeral._uscPagina.Quantidade = num2;
					DeclaracoesGeral._uscPagina.pbIniciar();
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
							clsBlocos.Unhighlight();
							Pagina.AtivaPagina(((Entity)pl2).Layer);
							uscPaginas uscPagina = DeclaracoesGeral._uscPagina;
							string pag = ((Entity)pl2).Layer.ToString();
							uscPagina.ativaPaginaAtalho(ref pag);
							Caderno.ZEntity(((DBObject)pl2).ObjectId, 20);
							((Entity)pl2).Highlight();
							if (ilig2.NumVeia == -1000)
							{
								if (ilig2.Tipo == 1)
								{
									Point3d point3dAt = pl2.GetPoint3dAt(0);
									Point3d point3dAt2 = pl2.GetPoint3dAt(pl2.NumberOfVertices - 1);
									string sTipo = "";
									int num3 = 0;
									short Painel = 0;
									pag = "";
									clsInterligacao2.verificaDispInterlig(point3dAt, ref sTipo, ref Painel, ref pag);
									num3 = Painel;
									string sTipo2 = "";
									int num4 = 0;
									Painel = 0;
									pag = "";
									clsInterligacao2.verificaDispInterlig(point3dAt2, ref sTipo2, ref Painel, ref pag);
									num4 = Painel;
									Dicionario.BuscaNomeDoPainel(num3);
									Dicionario.BuscaNomeDoPainel(num4);
									if (!(((ilig2.Painel1 == num3) & (ilig2.Painel2 == num4)) | ((ilig2.Painel1 == num4) & (ilig2.Painel2 == num3))))
									{
										if (num3 >= num4)
										{
											if (!(((ilig2.Painel1 == num4) & (ilig2.Painel2 == num3)) | ((ilig2.Painel1 == num3) & (ilig2.Painel2 == num4))))
											{
												ilig2.Painel1 = (short)num3;
												ilig2.Painel2 = (short)num4;
												((DBObject)pl2).UpgradeOpen();
												XDataInterligacao.AtualizaXDataInterligacao(ref pl2, ref ilig2);
												num++;
											}
										}
										else if (!(((ilig2.Painel1 == num3) & (ilig2.Painel2 == num4)) | ((ilig2.Painel1 == num4) & (ilig2.Painel2 == num3))))
										{
											ilig2.Painel1 = (short)num3;
											ilig2.Painel2 = (short)num4;
											((DBObject)pl2).UpgradeOpen();
											XDataInterligacao.AtualizaXDataInterligacao(ref pl2, ref ilig2);
											num++;
										}
									}
								}
								if ((ilig2.Tipo == 2) | (ilig2.Tipo == 3))
								{
									Pagina.AtivaPagina(((Entity)pl2).Layer.ToString());
									Point3d point3dAt3 = pl2.GetPoint3dAt(0);
									Point3d point3dAt4 = pl2.GetPoint3dAt(pl2.NumberOfVertices - 1);
									string sTipo3 = "";
									int num5 = 0;
									short Painel = 0;
									pag = "";
									bool flag = clsInterligacao2.verificaDispInterlig(point3dAt3, ref sTipo3, ref Painel, ref pag);
									num5 = Painel;
									if (!flag)
									{
										Painel = (short)num5;
										pag = "";
										clsInterligacao2.verificaDispInterlig(point3dAt4, ref sTipo3, ref Painel, ref pag);
										num5 = Painel;
									}
									if (ilig2.Painel1 == 0)
									{
										if (ilig2.Painel2 != num5)
										{
											ilig2.Painel2 = (short)num5;
											((DBObject)pl2).UpgradeOpen();
											XDataInterligacao.AtualizaXDataInterligacao(ref pl2, ref ilig2);
											num++;
										}
									}
									else if (ilig2.Painel1 != num5)
									{
										ilig2.Painel1 = (short)num5;
										((DBObject)pl2).UpgradeOpen();
										XDataInterligacao.AtualizaXDataInterligacao(ref pl2, ref ilig2);
										num++;
									}
								}
							}
							DeclaracoesGeral._uscPagina.pbPasso();
						}
					}
					finally
					{
						((IDisposable)enumerator2)?.Dispose();
					}
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
					DeclaracoesGeral.ativo.Pagina = pagina;
					DeclaracoesGeral._uscPagina.pbFim();
					if (num != 0)
					{
						Interaction.MsgBox("O Arquivo foi corrigido e possuia " + Conversions.ToString(num) + " Cabos com erro", MsgBoxStyle.Information, "Elétron");
					}
					else
					{
						Interaction.MsgBox("O Arquivo não possui Cabos com erro", MsgBoxStyle.Information, "Elétron");
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError((Exception)ex);
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

	[CommandMethod("CorrigePainelET1DosBornes")]
	public static void CorrigePainelET1DosBornes()
	{
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Expected Obj, but got Unknown
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
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected Obj, but got Unknown
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Expected Obj, but got Unknown
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Expected Obj, but got Unknown
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
						Entity ent = (Entity)val2.GetObject(current, (OpenMode)1);
						string tipoImportado = "";
						if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado), "B", TextCompare: true) != 0)
						{
							continue;
						}
						DeclaracoesEntidades.StructureBorne structureBorne = default;
						BlockReference blockRef = (BlockReference)ent;
						object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
						ent = (Entity)(object)blockRef;
						structureBorne = ((obj == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj));
						short num = 0;
						num = checked((short)DicionarioBorne.BuscaPainelDoBorneNoDicionario(ref structureBorne.IndiceRegua, ref structureBorne.NomeRegua, ref structureBorne.Alternativo));
						structureBorne.NomePainel = Dicionario.BuscaNomeDoPainel(num);
						BlockReference val5 = (BlockReference)val2.GetObject(current, (OpenMode)0);
						_ = (BlockTableRecord)val2.GetObject(val5.BlockTableRecord, (OpenMode)0);
						AttributeCollection attributeCollection = val5.AttributeCollection;
						foreach (object item in attributeCollection)
						{
							ObjectId val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							AttributeReference val7 = (AttributeReference)val6.GetObject((OpenMode)1);
							string text = "OK";
							string tag = val7.Tag;
							if (Operators.CompareString(tag, "NOME1", TextCompare: true) == 0)
							{
								text = ((structureBorne.Visivel == 1) ? structureBorne.NomeRegua : (structureBorne.NomePainel + DeclaracoesGeral.Conf.SeparadorPainelRegua + structureBorne.NomeRegua));
							}
							else if (Operators.CompareString(tag, "PAINEL", TextCompare: true) != 0)
							{
								if (Operators.CompareString(tag, "REGUA", TextCompare: true) != 0)
								{
									if (Operators.CompareString(tag, "T1", TextCompare: true) == 0)
									{
										text = ((Operators.CompareString(structureBorne.Numero.ToString(), "0", TextCompare: true) == 0) ? DeclaracoesGeral.Conf.CaracterTerminalIndefinido : structureBorne.Numero);
									}
								}
								else
								{
									text = structureBorne.NomeRegua;
								}
							}
							else
							{
								text = structureBorne.NomePainel;
							}
							if (Operators.CompareString(text, "OK", TextCompare: true) != 0)
							{
								((DBText)val7).TextString = text;
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

	[CommandMethod("EncontraHandle")]
	public static void EncontraHandle()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected Obj, but got Unknown
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected Obj, but got Unknown
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected Obj, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected Obj, but got Unknown
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
		string text = "";
		PromptStringOptions val = new PromptStringOptions("\r\nDigite Um Handle");
		val.AllowSpaces = true;
		val.DefaultValue = text;
		((PromptOptions)val).AppendKeywordsToMessage = false;
		if (Operators.CompareString(text, "", TextCompare: true) != 0)
		{
			val.UseDefaultValue = true;
		}
		else
		{
			val.UseDefaultValue = false;
		}
		PromptResult val2 = editor.GetString(val);
		DocumentLock val3 = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val4 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val5 = (BlockTable)val4.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val4.GetObject(((SymbolTable)val5)[BlockTableRecord.ModelSpace], (OpenMode)0);
				Entity val6 = (Entity)Geral.HandleToObject(val2.StringResult.ToUpper());
				try
				{
					if (val6 != null)
					{
						Pagina.AtivaPagina(val6.Layer);
						uscPaginas uscPagina = DeclaracoesGeral._uscPagina;
						string pag = val6.Layer.ToString();
						uscPagina.ativaPaginaAtalho(ref pag);
						Caderno.ZEntity(((DBObject)val6).ObjectId, 20);
					}
				}
				finally
				{
					((IDisposable)val6)?.Dispose();
				}
				DeclaracoesGeral.bAnularEventos = true;
				val4.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				ProjectData.ClearProjectError();
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

	[CommandMethod("ApagaBlocosMirror")]
	public static void ApagaBlocosMirror()
	{
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected Obj, but got Unknown
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected Obj, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected Obj, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected Obj, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected Obj, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected Obj, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			DeclaracoesGeral.bAnularEventos = true;
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
							Entity val5 = (Entity)val2.GetObject(current, (OpenMode)1);
							BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
							if (val6 == null)
							{
								continue;
							}
							DeclaracoesInterligacao.caboAranha caboAranha = default;
							Entity ent = (Entity)(object)val6;
							object oValor = "";
							bool flag = XDataLeitura.lexDataDaEntity1(ref ent, "DINTERLIG", 0, ref oValor);
							val6 = (BlockReference)ent;
							if (!flag && ((DBObject)val6).XData != (ResultBuffer)null)
							{
								Scale3d scaleFactors = val6.ScaleFactors;
								if (scaleFactors.X < 0.0)
								{
									((DBObject)val5).UpgradeOpen();
									((DBObject)val5).Erase();
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
			DeclaracoesGeral.bAnularEventos = false;
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError((Exception)ex2);
			throw;
		}
		finally
		{
		}
	}

	[CommandMethod("AtualizaOpcionaisDoCabo")]
	public static void AtualizaTodosOpcionaisDoCabo()
	{
		//IL_04e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e8: Expected Obj, but got Unknown
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected Obj, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected Obj, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected Obj, but got Unknown
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected Obj, but got Unknown
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected Obj, but got Unknown
		structureFormacao[] mFormacao = new structureFormacao[1];
		structureFuncaoVeia[] mFuncao = new structureFuncaoVeia[1];
		CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
		cDadosAccessInterligacao3.LeTodasasFormacoesdosCabosFuncoesDasVeias(ref mFormacao, ref mFuncao);
		cDadosAccessInterligacao3.FechaConexao();
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
				DeclaracoesGeral._uscPagina.Quantidade = clsBlocos.AcadObjectCount();
				DeclaracoesGeral._uscPagina.pbIniciar();
				int num = 0;
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val3.GetEnumerator();
					short tipo = default;
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val4 = (Entity)val.GetObject(current, (OpenMode)0);
						DBText val5 = (DBText)(object)((val4 is DBText) ? val4 : null);
						if (val5 != null)
						{
							string handle = "";
							string THandle = "";
							string sOpcionais = "";
							Entity ent = (Entity)(object)val5;
							bool flag = XDataInterligacao.lerXDataAuxInterligacao(ref ent, ref handle, ref tipo, ref THandle, ref sOpcionais);
							val5 = (DBText)ent;
							if (flag)
							{
								string[] array = sOpcionais.Split('#');
								if ((tipo == 3) | (tipo == 4) | (tipo == 5) | (tipo == 6))
								{
									string text = "";
									Polyline pl = (Polyline)Geral.HandleToObject(handle);
									if (pl != null)
									{
										DeclaracoesEntidades.StructureInterligacao ilig = default;
										if (XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig))
										{
											string text2 = "";
											int num2 = Information.UBound(array) - 1;
											for (int i = 0; i <= num2; i++)
											{
												text2 = array[i];
												string left = text2;
												if (Operators.CompareString(left, "C", TextCompare: true) != 0)
												{
													if (Operators.CompareString(left, "V", TextCompare: true) != 0)
													{
														if (Operators.CompareString(left, "N", TextCompare: true) != 0)
														{
															if (Operators.CompareString(left, "FU", TextCompare: true) != 0)
															{
																if (Operators.CompareString(left, "FO", TextCompare: true) != 0)
																{
																	if (Operators.CompareString(left, "(", TextCompare: true) != 0)
																	{
																		if (Operators.CompareString(left, ")", TextCompare: true) != 0)
																		{
																			if (Operators.CompareString(left, "/", TextCompare: true) != 0)
																			{
																				if (Operators.CompareString(left, "E", TextCompare: true) != 0)
																				{
																					if (Operators.CompareString(left, "-", TextCompare: true) == 0)
																					{
																						text += "-";
																					}
																				}
																				else
																				{
																					text += " ";
																				}
																			}
																			else
																			{
																				text += "/";
																			}
																		}
																		else
																		{
																			text += ")";
																		}
																	}
																	else
																	{
																		text += "(";
																	}
																}
																else
																{
																	text += BuscaFormacoes(mFormacao, ref ilig.Tag_Cabo);
																}
															}
															else
															{
																text += BuscaFuncaoVeia(mFuncao, ref ilig.Tag_Cabo, ilig.NumVeia);
															}
														}
														else
														{
															text += ilig.NomeVeia;
														}
													}
													else
													{
														if (ilig.NumVeia == -1000)
														{
															text = "";
															break;
														}
														text += BuscaNomeVeia(mFuncao, ref ilig.Tag_Cabo, ilig.NumVeia);
													}
												}
												else
												{
													text += ilig.Tag_Cabo;
												}
											}
											if (ilig.NumVeia == -1000)
											{
												text = "";
											}
										}
									}
									string text3 = text;
									text3 = text3.Replace("(", "");
									text3 = text3.Replace(")", "");
									text3 = text3.Replace("/", "");
									text3 = text3.Replace(" ", "");
									if (Operators.CompareString(text3, "", TextCompare: true) == 0)
									{
										text = "";
									}
									text = text.Replace("()", "");
									text = text.Replace("  ", " ");
									text = text.Replace("  ", " ");
									text = text.Trim();
									if (Operators.CompareString(text, "", TextCompare: true) == 0)
									{
										text = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
									}
									((DBObject)val5).UpgradeOpen();
									val5.TextString = text;
									hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
									Application.UpdateScreen();
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
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				DeclaracoesGeral.bAnularEventos = true;
				val.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				DeclaracoesGeral._uscPagina.pbFim();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				throw;
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			clsEditarInterligacao.AtualizaNomesDosCabos();
		}
	}

	public static string BuscaFormacoes(structureFormacao[] mFormacao, ref string sCabo)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Obj, but got Unknown
		string result = "";
		try
		{
			int num = Information.UBound(mFormacao);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (Operators.CompareString(mFormacao[i].sCabo, sCabo, TextCompare: true) == 0)
				{
					result = mFormacao[i].sFormacao;
					break;
				}
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
		return result;
	}

	public static string BuscaNomeVeia(structureFuncaoVeia[] mFuncao, ref string sCabo, int iVeia)
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected Obj, but got Unknown
		string result = "";
		try
		{
			int num = Information.UBound(mFuncao);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if ((Operators.CompareString(mFuncao[i].sCabo, sCabo, TextCompare: true) == 0) & (mFuncao[i].iVeia == iVeia))
				{
					result = ((Operators.CompareString(mFuncao[i].sNome.Trim(), "", TextCompare: true) != 0) ? mFuncao[i].sNome : Conversions.ToString(iVeia));
					break;
				}
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
		return result;
	}

	public static string BuscaFuncaoVeia(structureFuncaoVeia[] mFuncao, ref string sCabo, int iVeia)
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected Obj, but got Unknown
		string result = "";
		try
		{
			int num = Information.UBound(mFuncao);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if ((Operators.CompareString(mFuncao[i].sCabo, sCabo, TextCompare: true) == 0) & (mFuncao[i].iVeia == iVeia))
				{
					result = mFuncao[i].sFuncao;
					break;
				}
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
		return result;
	}

	public static void limpaComandos()
	{
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		DocumentCollection documentManager = Application.DocumentManager;
		_ = documentManager.MdiActiveDocument.Editor;
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		string[] array = V5UT6I3H00(executingAssembly, _0020: false);
		int num = Information.UBound(array);
		for (int i = 0; i <= num; i = checked(i + 1))
		{
			if (Operators.CompareString(array[i].ToUpper(), "RESETLIC", TextCompare: true) != 0)
			{
				mdiActiveDocument.SendStringToExecute("_UNDEFINE " + array[i] + "\n", true, false, true);
			}
		}
	}

	private static string[] V5UT6I3H00(Assembly P_0, bool P_1)
	{
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected Obj, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected Obj, but got Unknown
		StringCollection stringCollection = new StringCollection();
		object[] customAttributes = P_0.GetCustomAttributes(typeof(CommandClassAttribute), inherit: true);
		int num = customAttributes.Length;
		checked
		{
			Type[] array;
			if (num <= 0)
			{
				array = (P_1 ? new Type[0] : P_0.GetExportedTypes());
			}
			else
			{
				array = new Type[num - 1 + 1];
				for (int i = 0; i < num; i++)
				{
					CommandClassAttribute val = (CommandClassAttribute)customAttributes[i];
					if (val != null)
					{
						array[i] = val.Type;
					}
				}
			}
			Type[] array2 = array;
			foreach (Type type in array2)
			{
				MethodInfo[] methods = type.GetMethods();
				MethodInfo[] array3 = methods;
				foreach (MethodInfo methodInfo in array3)
				{
					customAttributes = methodInfo.GetCustomAttributes(typeof(CommandMethodAttribute), inherit: true);
					object[] array4 = customAttributes;
					for (int l = 0; l < array4.Length; l++)
					{
						object objectValue = RuntimeHelpers.GetObjectValue(array4[l]);
						CommandMethodAttribute val2 = (CommandMethodAttribute)objectValue;
						stringCollection.Add(val2.GlobalName);
					}
				}
			}
			string[] array5 = new string[stringCollection.Count - 1 + 1];
			stringCollection.CopyTo(array5, 0);
			return array5;
		}
	}

	[CommandMethod("CorrigeTextosDasLigacoes")]
	public static void CorrigeTextosDasLigacoes()
	{
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected Obj, but got Unknown
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected Obj, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected Obj, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected Obj, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected Obj, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected Obj, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			DeclaracoesGeral.bAnularEventos = true;
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
							Entity val5 = (Entity)val2.GetObject(current, (OpenMode)1);
							BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
							if (val6 == null)
							{
								continue;
							}
							DeclaracoesInterligacao.caboAranha caboAranha = default;
							Entity ent = (Entity)(object)val6;
							object oValor = "";
							bool flag = XDataLeitura.lexDataDaEntity1(ref ent, "DINTERLIG", 0, ref oValor);
							val6 = (BlockReference)ent;
							if (!flag && ((DBObject)val6).XData != (ResultBuffer)null)
							{
								Scale3d scaleFactors = val6.ScaleFactors;
								if (scaleFactors.X < 0.0)
								{
									((DBObject)val5).UpgradeOpen();
									((DBObject)val5).Erase();
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
			DeclaracoesGeral.bAnularEventos = false;
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError((Exception)ex2);
			throw;
		}
		finally
		{
		}
	}

	public static void CorrigeOsTextosDosCabos()
	{
		//IL_0328: Unknown result type (might be due to invalid IL or missing references)
		//IL_032e: Expected Obj, but got Unknown
		//IL_035f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0365: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected Obj, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected Obj, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected Obj, but got Unknown
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected Obj, but got Unknown
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Expected Obj, but got Unknown
		int num = 0;
		structureTextosCabo[] array = new structureTextosCabo[1];
		checked
		{
			try
			{
				DeclaracoesGeral.bAnularEventos = true;
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
								Entity val5 = (Entity)val2.GetObject(current, (OpenMode)1);
								Polyline pl = (Polyline)(object)((val5 is Polyline) ? val5 : null);
								if (pl != null)
								{
									DeclaracoesEntidades.StructureInterligacao ilig = default;
									if (XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig))
									{
										num++;
										array = (structureTextosCabo[])Utils.CopyArray(array, new structureTextosCabo[num + 1]);
										array[num].sHandleLinha = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
										array[num].sPaginaCabo = ((Entity)pl).Layer;
									}
								}
							}
						}
						finally
						{
							((IDisposable)enumerator)?.Dispose();
						}
						bool flag = false;
						BlockTableRecordEnumerator enumerator2 = default;
						try
						{
							enumerator2 = val4.GetEnumerator();
							short tipo = default;
							while (enumerator2.MoveNext())
							{
								ObjectId current2 = enumerator2.Current;
								Entity val6 = (Entity)val2.GetObject(current2, (OpenMode)1);
								DBText val7 = (DBText)(object)((val6 is DBText) ? val6 : null);
								if (val7 == null)
								{
									continue;
								}
								flag = false;
								string handle = "";
								string THandle = "";
								Entity ent = (Entity)(object)val7;
								string sOpcionais = "";
								bool flag2 = XDataInterligacao.lerXDataAuxInterligacao(ref ent, ref handle, ref tipo, ref THandle, ref sOpcionais);
								val7 = (DBText)ent;
								if (!flag2)
								{
									continue;
								}
								int num2 = Information.UBound(array);
								for (int i = 1; i <= num2; i++)
								{
									if (Operators.CompareString(array[i].sHandleLinha, handle, TextCompare: true) == 0)
									{
										if (Operators.CompareString(array[i].sPaginaCabo, ((Entity)val7).Layer, TextCompare: true) != 0)
										{
											((DBObject)val7).UpgradeOpen();
											((DBObject)val7).Erase();
										}
										flag = true;
										break;
									}
								}
								if (!flag)
								{
									((DBObject)val7).UpgradeOpen();
									((DBObject)val7).Erase();
								}
							}
						}
						finally
						{
							((IDisposable)enumerator2)?.Dispose();
						}
						if (DeclaracoesGeral.Conf.InterligacaoLayout == 1)
						{
							BlockTableRecordEnumerator enumerator3 = default;
							try
							{
								enumerator3 = val4.GetEnumerator();
								while (enumerator3.MoveNext())
								{
									ObjectId current3 = enumerator3.Current;
									Entity ent2 = (Entity)val2.GetObject(current3, (OpenMode)1);
									if (ent2 == null)
									{
										continue;
									}
									flag = false;
									string sHandle = "";
									if (!XDataInterligacao.lerXDataAuxInterligacaoEletrosul(ref ent2, ref sHandle))
									{
										continue;
									}
									int num3 = Information.UBound(array);
									for (int j = 1; j <= num3; j++)
									{
										if (Operators.CompareString(array[j].sHandleLinha, sHandle, TextCompare: true) == 0)
										{
											if (Operators.CompareString(array[j].sPaginaCabo, ent2.Layer, TextCompare: true) != 0)
											{
												((DBObject)ent2).UpgradeOpen();
												((DBObject)ent2).Erase();
											}
											flag = true;
											break;
										}
									}
									if (!flag)
									{
										((DBObject)ent2).UpgradeOpen();
										((DBObject)ent2).Erase();
									}
								}
							}
							finally
							{
								((IDisposable)enumerator3)?.Dispose();
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
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError((Exception)ex2);
				throw;
			}
			finally
			{
			}
		}
	}

	private static ObjectIdCollection FyCTtOiU72(ObjectIdCollection P_0)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Expected Obj, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected Obj, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected Obj, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected Obj, but got Unknown
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		ObjectIdCollection val = new ObjectIdCollection();
		DocumentLock val2 = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val3 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val4 = (BlockTable)val3.GetObject(database.BlockTableId, (OpenMode)0);
				SymbolTableEnumerator enumerator = default;
				try
				{
					enumerator = ((SymbolTable)val4).GetEnumerator();
					BlockTableRecordEnumerator enumerator2 = default;
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						BlockTableRecord val5 = (BlockTableRecord)val3.GetObject(current, (OpenMode)0);
						try
						{
							enumerator2 = val5.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								ObjectId current2 = enumerator2.Current;
								DBObject val6 = val3.GetObject(current2, (OpenMode)0, true);
								Entity val7 = (Entity)(object)((val6 is Entity) ? val6 : null);
								if (val7 != null && !((DBObject)val7).IsErased && P_0.Contains(val7.LinetypeId))
								{
									BlockTableRecord val8 = (BlockTableRecord)val3.GetObject(((DBObject)val7).OwnerId, (OpenMode)0);
									if (!((SymbolTableRecord)val8).Name.StartsWith("*") || Operators.CompareString(((SymbolTableRecord)val8).Name.ToUpper(), BlockTableRecord.ModelSpace, TextCompare: true) == 0 || ((SymbolTableRecord)val8).Name.ToUpper().StartsWith(BlockTableRecord.PaperSpace))
									{
										val.Add(val7.LinetypeId);
									}
								}
							}
						}
						finally
						{
							((IDisposable)enumerator2)?.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				DeclaracoesGeral.bAnularEventos = true;
				val3.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				val3.Abort();
				ProjectData.ClearProjectError();
			}
			finally
			{
				((IDisposable)val3)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val2)?.Dispose();
		}
		DeclaracoesGeral.bAnularEventos = false;
		return val;
	}

	[CommandMethod(/*Could not decode attribute arguments.*/)]
	public void SetLineType(ref List<string> lTypes)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Invalid comparison between Unknown and I4
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected Obj, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		if (mdiActiveDocument == null)
		{
			return;
		}
		Editor editor = mdiActiveDocument.Editor;
		PromptSelectionResult selection = editor.GetSelection();
		if ((int)selection.Status != 5100 || selection.Value.Count == 0)
		{
			return;
		}
		Transaction val = mdiActiveDocument.TransactionManager.StartTransaction();
		try
		{
			ObjectId[] objectIds = selection.Value.GetObjectIds();
			_ = ObjectId.Null;
			ObjectId[] array = objectIds;
			foreach (ObjectId val2 in array)
			{
				Entity val3 = (Entity)val.GetObject(val2, (OpenMode)0);
				if (val3.LinetypeId != ObjectId.Null)
				{
					_ = val3.LinetypeId;
				}
			}
			val.Commit();
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void BuscaLyneTypes(ref DeclaracoesInterligacao.structureEstiloInterligacao[] mEstilo)
	{
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_0326: Expected Obj, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected Obj, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected Obj, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected Obj, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Expected Obj, but got Unknown
		int num = 0;
		mEstilo = new DeclaracoesInterligacao.structureEstiloInterligacao[1];
		num = -1;
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
						List<string> list = new List<string>();
						BlockTableRecordEnumerator enumerator = default;
						try
						{
							enumerator = val4.GetEnumerator();
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.Current;
								Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
								Polyline val6 = (Polyline)(object)((val5 is Polyline) ? val5 : null);
								if (val6 != null && !((Operators.CompareString(((Entity)val6).Linetype.ToUpper(), "BYLAYER", TextCompare: true) == 0) | (Operators.CompareString(((Entity)val6).Linetype.ToUpper(), "BYBLOCK", TextCompare: true) == 0)))
								{
									string linetype = ((Entity)val6).Linetype;
									if (!list.Contains(linetype))
									{
										num++;
										mEstilo = (DeclaracoesInterligacao.structureEstiloInterligacao[])Utils.CopyArray(mEstilo, new DeclaracoesInterligacao.structureEstiloInterligacao[num + 1]);
										mEstilo[num].LinetypeScale = ((Entity)val6).LinetypeScale;
										mEstilo[num].Linetype = ((Entity)val6).Linetype;
										list.Add(linetype);
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
								Line val8 = (Line)(object)((val7 is Line) ? val7 : null);
								if (val8 != null && !((Operators.CompareString(((Entity)val8).Linetype.ToUpper(), "BYLAYER", TextCompare: true) == 0) | (Operators.CompareString(((Entity)val8).Linetype.ToUpper(), "BYBLOCK", TextCompare: true) == 0)))
								{
									string linetype2 = ((Entity)val8).Linetype;
									if (!list.Contains(linetype2))
									{
										num++;
										mEstilo = (DeclaracoesInterligacao.structureEstiloInterligacao[])Utils.CopyArray(mEstilo, new DeclaracoesInterligacao.structureEstiloInterligacao[num + 1]);
										mEstilo[num].LinetypeScale = ((Entity)val8).LinetypeScale;
										mEstilo[num].Linetype = ((Entity)val8).Linetype;
										list.Add(linetype2);
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
					finally
					{
						((IDisposable)val2)?.Dispose();
					}
				}
				finally
				{
					((IDisposable)val)?.Dispose();
				}
				if (Information.UBound(mEstilo) < 2)
				{
					return;
				}
				int num2 = Information.UBound(mEstilo) - 1;
				for (int i = num2; i >= 1; i += -1)
				{
					int num3 = i;
					for (int j = 1; j <= num3; j++)
					{
						if (Operators.CompareString(mEstilo[j].Linetype, mEstilo[j + 1].Linetype, TextCompare: true) > 0)
						{
							DeclaracoesInterligacao.structureEstiloInterligacao structureEstiloInterligacao = default;
							structureEstiloInterligacao = mEstilo[j + 1];
							mEstilo[j + 1] = mEstilo[j];
							mEstilo[j] = structureEstiloInterligacao;
						}
					}
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

	public static string SoNumeros(string sNumero)
	{
		string text = sNumero;
		string str = Conversions.ToString(0.5);
		str = Strings.Mid(str, 2, 1);
		text = text.Replace(".", str);
		text = text.Replace(",", str);
		if (!Versioned.IsNumeric(text))
		{
			text = Conversions.ToString(1);
		}
		return text;
	}
}

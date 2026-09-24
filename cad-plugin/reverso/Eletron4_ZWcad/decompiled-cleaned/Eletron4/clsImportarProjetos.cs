using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;

namespace Eletron4;

public class clsImportarProjetos
{
	public struct mEquip
	{
		public int iPainel;

		public string sPainel;
	}

	public struct mDWG
	{
		public int iDWG;

		public string sNome;

		public string sCaminho;
	}

	public struct mCabos
	{
		public int iDWG;

		public string sNomeCabo;
	}

	public struct mIndiceTrocaDWG
	{
		public int iDWG;

		public int iDWG_Troca;
	}

	public struct mIndiceTrocaPN
	{
		public int iPainel;

		public string sPainel;

		public int iPainelNovo;

		public string sPainelNovo;
	}

	public struct mTodosCabos
	{
		public string Tag;

		public string Formacao;

		public bool blindagem;

		public int Pn1;

		public int Pn2;

		public string Codigo;

		public string Funcao;

		public int Alarme;

		public int Aterrar;

		public double Comprimento;

		public string Trajeto;

		public string Instrucao;

		public double Diametro;

		public string Grupo;

		public int Cabos;
	}

	public struct mTodasVeias
	{
		public string Tag;

		public int indice;

		public string Nome_Veias;

		public bool Uso;

		public string Handle;

		public int Arquivo;

		public string Pagina;

		public int Chave;
	}

	public struct mExpo
	{
		public int Codigo;

		public string Tipo;

		public int DWG;

		public string Caderno;

		public string Handle;

		public string Pagina;

		public string Posicao;

		public int Painel;

		public string Texto;

		public int DWGDest;

		public string CadernoDest;

		public string PaginaDest;

		public string PosicaoDest;

		public string NomeRegua;

		public int indiceModelo;

		public bool atualizado;
	}

	public struct mAtt
	{
		public int DWG;

		public string Handle;

		public string Nome;

		public string Valor;
	}

	public struct mTrocaImportados
	{
		public int iIndice;

		public int iIndiceNovo;
	}

	public struct mTrocaCabos
	{
		public string sCabo;

		public string sCaboNovo;
	}

	public static void AualizaCodigoDWG_ExportadosImportados(mIndiceTrocaDWG[] mIndiceTrocaDWG, mTrocaImportados[] _i_IndiceExportados)
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
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			cDadosAccessImportarProj cDadosAccessImportarProj2 = new cDadosAccessImportarProj();
			try
			{
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
							DeclaracoesEntidades.StructureExportar exp = default;
							if (!XDataExpImp.LerXDataImportado(ref ent, ref exp))
							{
								DeclaracoesEntidades.StructureExportar exp2 = default;
								if (XDataExpImp.LerXDataExportado(ref ent, ref exp2))
								{
									exp2.Codigo = BuscaNovoCodidoExportado(_i_IndiceExportados, exp2.Codigo);
									exp2.DWG = BuscaNovoDWG(mIndiceTrocaDWG, exp2.DWG);
									exp2.DWGDest = BuscaNovoDWG(mIndiceTrocaDWG, exp2.DWGDest);
									exp2.indice = cDadosAccessImportarProj2.BuscaIndiceExportado(exp2.Codigo, exp2.DWG, exp2.Handle);
									((DBObject)ent).UpgradeOpen();
									XDataExpImp.GravarXDataExportado(ref ent, ref exp2);
								}
							}
							else
							{
								exp.Codigo = BuscaNovoCodidoExportado(_i_IndiceExportados, exp.Codigo);
								exp.DWG = BuscaNovoDWG(mIndiceTrocaDWG, exp.DWG);
								exp.DWGDest = BuscaNovoDWG(mIndiceTrocaDWG, exp.DWGDest);
								exp.indice = cDadosAccessImportarProj2.BuscaIndiceImportado(exp.Codigo, exp.DWGDest, exp.Handle);
								((DBObject)ent).UpgradeOpen();
								XDataExpImp.GravarXDataImportado(ref ent, ref exp);
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
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				ProjectData.ClearProjectError();
			}
			finally
			{
				cDadosAccessImportarProj2.fechaConexao();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static int BuscaNovoPainel(mIndiceTrocaPN[] iIndicePN_TROCA, int iPn)
	{
		int result = iPn;
		int num = Information.UBound(iIndicePN_TROCA);
		for (int i = 0; i <= num; i = checked(i + 1))
		{
			if (iIndicePN_TROCA[i].iPainel == iPn)
			{
				result = iIndicePN_TROCA[i].iPainelNovo;
				break;
			}
		}
		return result;
	}

	public static string BuscaNomeDoPainel(mEquip[] mPaineis, int iPn)
	{
		string result = "???";
		int num = Information.UBound(mPaineis);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (mPaineis[i].iPainel == iPn)
			{
				result = mPaineis[i].sPainel;
				break;
			}
		}
		return result;
	}

	public static int BuscaNovoDWG(mIndiceTrocaDWG[] mIndiceTrocaDWG, int iDWG)
	{
		int result = iDWG;
		int num = Information.UBound(mIndiceTrocaDWG);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (mIndiceTrocaDWG[i].iDWG == iDWG)
			{
				result = mIndiceTrocaDWG[i].iDWG_Troca;
				break;
			}
		}
		return result;
	}

	public static int BuscaNovoCodidoExportado(mTrocaImportados[] _i_IndiceExportados, int iCodigo)
	{
		int result = iCodigo;
		int num = Information.UBound(_i_IndiceExportados);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (_i_IndiceExportados[i].iIndice == iCodigo)
			{
				result = _i_IndiceExportados[i].iIndiceNovo;
				break;
			}
		}
		return result;
	}

	public static void EncontraPaineisDoDesenho(string dwgFile, ref object mPaineis, mEquip[] mNOVO_PnImportada, ref List<int> lLM)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected Obj, but got Unknown
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected Obj, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected Obj, but got Unknown
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Expected Obj, but got Unknown
		int num = 0;
		int num2 = 0;
		string sTipo = "";
		List<int> list = new List<int>();
		Database val = new Database(false, true);
		checked
		{
			try
			{
				val.ReadDwgFile(dwgFile, FileShare.Read, false, "");
				val.CloseInput(true);
				Transaction val2 = (Transaction)(object)val.TransactionManager.StartOpenCloseTransaction();
				try
				{
					bool flag = false;
					BlockTable val3 = (BlockTable)val2.GetObject(val.BlockTableId, (OpenMode)0);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					DeclaracoesGeral._uscPagina.Quantidade = clsBlocos.AcadObjectCount();
					DeclaracoesGeral._uscPagina.pbIniciar();
					int num3 = 0;
					Declaracoes2.StructureModeloDeReguas[] mModelo = new Declaracoes2.StructureModeloDeReguas[1];
					Database db = val;
					DicionarioReguas.LeOsModelosDeReguaSemAbrirDWG(ref mModelo, ref db);
					DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mModelo);
					DeclaracoesGeral._uscPagina.pbIniciar();
					int num4 = Information.UBound(mModelo);
					for (int i = 1; i <= num4; i++)
					{
						DeclaracoesEntidades.StructureBorne[] array = null;
						array = new DeclaracoesEntidades.StructureBorne[1];
						int indexRegua = mModelo[i].indexRegua;
						db = val;
						DicionarioBorne.LeDicBornesReservaTodosSemAbrirDWG(indexRegua, ref array, ref db);
						int num5 = Information.UBound(array);
						for (int j = 1; j <= num5; j++)
						{
							if (!lLM.Contains(array[j].lm))
							{
								lLM.Add(array[j].lm);
							}
						}
						DeclaracoesGeral._uscPagina.pbPasso();
					}
					DeclaracoesGeral._uscPagina.pbFim();
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
								num = 0;
								num2 = 0;
								flag = false;
								BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
								try
								{
									if (val6 != null)
									{
										flag = true;
									}
									if (flag)
									{
										Declaracoes2.StructureModeloDeReguas[] mModeloDeReguas = mModelo;
										int Potencial = 0;
										XDataDispositivo.xDataPaineisOutroDWG(val, (Entity)(object)val6, ref sTipo, ref num, ref num2, mModeloDeReguas, ref lLM, ref Potencial, bTopografico: true);
										if (num > 0 && !list.Contains(num))
										{
											list.Add(num);
										}
										if (num2 > 0 && !list.Contains(num2))
										{
											list.Add(num2);
										}
									}
									num3++;
									if (num3 == 100)
									{
										DeclaracoesGeral._uscPagina.pbPasso(num3);
										num3 = 0;
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
					DeclaracoesGeral._uscPagina.pbFim();
					DeclaracoesGeral._uscPagina.Quantidade = list.Count;
					DeclaracoesGeral._uscPagina.pbIniciar();
					int num6 = list.Count - 1;
					for (int k = 0; k <= num6; k++)
					{
						mPaineis = Utils.CopyArray((Array)mPaineis, new object[2, Information.UBound((Array)mPaineis, 2) + 1 + 1]);
						NewLateBinding.LateIndexSet(mPaineis, new object[3]
						{
							0,
							Information.UBound((Array)mPaineis, 2),
							list[k]
						}, null);
						NewLateBinding.LateIndexSet(mPaineis, new object[3]
						{
							1,
							Information.UBound((Array)mPaineis, 2),
							BuscaNomeDoPainel(mNOVO_PnImportada, list[k])
						}, null);
						DeclaracoesGeral._uscPagina.pbPasso();
					}
					DeclaracoesGeral._uscPagina.pbFim();
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
	}

	public static void AtualizaNomeDasVeias(mTrocaCabos[] iNomeCabosTroca)
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
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		clsTextos.structureTextoCaderno[] TextoCabo = new clsTextos.structureTextoCaderno[1];
		clsInterligacao.buscaTextosdosCabos(ref TextoCabo);
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
							if (!((ilig.Tipo == 1) | ((ilig.Tipo == 2) & (ilig.Painel1 > 0)) | (ilig.Tipo == 3)) || !((Operators.CompareString(Strings.Trim(ilig.Tag_Cabo), "", TextCompare: true) != 0) & (ilig.NumVeia > -100)) || !((ilig.Tipo == 1) | (ilig.Tipo == 2) | (ilig.Tipo == 3)))
							{
								continue;
							}
							int num2 = Information.UBound(iNomeCabosTroca);
							for (int i = 1; i <= num2; i++)
							{
								if (Operators.CompareString(ilig.Tag_Cabo, iNomeCabosTroca[i].sCabo, TextCompare: true) == 0)
								{
									ilig.Tag_Cabo = iNomeCabosTroca[i].sCaboNovo;
									string sHandle = clsTextos.EncontraTextoDoCabo(TextoCabo, ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString());
									((DBObject)pl).UpgradeOpen();
									XDataInterligacao.AtualizaXDataInterligacao(ref pl, ref ilig);
									string text = clsTextos.LeUmTexto(sHandle);
									string[] array = text.Split(Conversions.ToChar(DeclaracoesGeral.Conf.SeparadorCaboVeia));
									if (Information.UBound(array) == 1)
									{
										text = iNomeCabosTroca[i].sCaboNovo + DeclaracoesGeral.Conf.SeparadorCaboVeia + array[1];
									}
									clsTextos.AtualizaUmTexto(sHandle, text);
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
					((IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}

	public static void MudaLMdosBlocos(mTrocaImportados[] iIndiceTrocaLM, bool bLM)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected Obj, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected Obj, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected Obj, but got Unknown
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected Obj, but got Unknown
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Expected Obj, but got Unknown
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
					DeclaracoesEntidades.StructureBorne structureBorne = default;
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity ent = (Entity)val2.GetObject(current, (OpenMode)0);
							string tipoImportado = "";
							object obj;
							BlockReference blockRef;
							if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado), "B", TextCompare: true) != 0)
							{
								tipoImportado = "";
								if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado), "P", TextCompare: true) != 0)
								{
									continue;
								}
								blockRef = (BlockReference)ent;
								obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
								ent = (Entity)(object)blockRef;
								object obj2 = obj;
								DeclaracoesEntidades.StructureDispositivo disp = ((obj2 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj2));
								if (disp.indexModelo != 0)
								{
									continue;
								}
								if (!bLM)
								{
									disp.iLM1 = 0;
									disp.iLM2 = 0;
								}
								else
								{
									int num = Information.UBound(iIndiceTrocaLM);
									for (int i = 1; i <= num; i++)
									{
										if (iIndiceTrocaLM[i].iIndice == disp.iLM1)
										{
											disp.iLM1 = iIndiceTrocaLM[i].iIndiceNovo;
											break;
										}
									}
									int num2 = Information.UBound(iIndiceTrocaLM);
									for (int j = 1; j <= num2; j++)
									{
										if (iIndiceTrocaLM[j].iIndice == disp.iLM2)
										{
											disp.iLM2 = iIndiceTrocaLM[j].iIndiceNovo;
											break;
										}
									}
								}
								((DBObject)ent).UpgradeOpen();
								blockRef = (BlockReference)ent;
								XDataDispositivosMaster.GravarXDataDispPrincipal(ref blockRef, ref disp);
								ent = (Entity)(object)blockRef;
								continue;
							}
							blockRef = (BlockReference)ent;
							obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
							ent = (Entity)(object)blockRef;
							object obj3 = obj;
							structureBorne = ((obj3 == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj3));
							if (!bLM)
							{
								structureBorne.lm = 0;
							}
							else
							{
								int num3 = Information.UBound(iIndiceTrocaLM);
								for (int k = 1; k <= num3; k++)
								{
									if (iIndiceTrocaLM[k].iIndice == structureBorne.lm)
									{
										structureBorne.lm = iIndiceTrocaLM[k].iIndiceNovo;
										break;
									}
								}
							}
							blockRef = (BlockReference)ent;
							XDataDispositivosMaster.GravarXDataDispBorne(ref blockRef, ref structureBorne);
							ent = (Entity)(object)blockRef;
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
			Declaracoes2.StructureModeloDeReguas[] mModelo = new Declaracoes2.StructureModeloDeReguas[1];
			DicionarioReguas.LeOsModelosDeRegua(ref mModelo);
			DeclaracoesEntidades.StructureBorne[] array = null;
			int num4 = Information.UBound(mModelo);
			for (int l = 1; l <= num4; l++)
			{
				array = new DeclaracoesEntidades.StructureBorne[1];
				DicionarioBorne.LeDicBornesReservaTodos(mModelo[l].indexRegua, ref array);
				if (Information.UBound(array) <= 0)
				{
					continue;
				}
				int num5 = Information.UBound(array);
				for (int m = 1; m <= num5; m++)
				{
					if (!bLM)
					{
						array[m].lm = 0;
					}
					else
					{
						if (array[m].lm == 0)
						{
							continue;
						}
						int num6 = Information.UBound(iIndiceTrocaLM);
						for (int n = 1; n <= num6; n++)
						{
							if (array[m].lm == iIndiceTrocaLM[n].iIndice)
							{
								array[m].lm = iIndiceTrocaLM[n].iIndiceNovo;
								break;
							}
						}
					}
				}
				DicionarioBorne.gravaDicBornesReserva(mModelo[l].indexRegua, ref array);
			}
		}
	}

	public static void IndefineTodosAsVeiasDWG()
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected Obj, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Expected Obj, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Expected Obj, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected Obj, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Expected Obj, but got Unknown
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Expected Obj, but got Unknown
		List<string> list = new List<string>();
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
							if (XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig))
							{
								if (!list.Contains(ilig.Tag_Cabo))
								{
									list.Add(ilig.Tag_Cabo);
								}
								ilig.Tag_Cabo = "";
								ilig.NumVeia = -1000;
								ilig.NomeVeia = "";
								ilig.ocultaTag = 0;
								((DBObject)pl).UpgradeOpen();
								XDataInterligacao.AtualizaXDataInterligacao(ref pl, ref ilig);
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
		bool flag;
		try
		{
			DocumentLock val6 = Application.DocumentManager.MdiActiveDocument.LockDocument();
			try
			{
				Database database2 = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val7 = database2.TransactionManager.StartTransaction();
				try
				{
					BlockTable val8 = (BlockTable)val7.GetObject(database2.BlockTableId, (OpenMode)0);
					BlockTableRecord val9 = (BlockTableRecord)val7.GetObject(((SymbolTable)val8)[BlockTableRecord.ModelSpace], (OpenMode)0);
					BlockTableRecordEnumerator enumerator2 = default;
					try
					{
						enumerator2 = val9.GetEnumerator();
						short tipo = default;
						while (enumerator2.MoveNext())
						{
							ObjectId current2 = enumerator2.Current;
							Entity val10 = (Entity)val7.GetObject(current2, (OpenMode)0);
							DBText val11 = (DBText)(object)((val10 is DBText) ? val10 : null);
							if (val11 != null)
							{
								string handle = "";
								string THandle = "";
								Entity ent = (Entity)(object)val11;
								string sOpcionais = "";
								flag = XDataInterligacao.lerXDataAuxInterligacao(ref ent, ref handle, ref tipo, ref THandle, ref sOpcionais);
								val11 = (DBText)ent;
								if (flag && tipo == 1)
								{
									((DBObject)val11).UpgradeOpen();
									val11.TextString = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
								}
							}
						}
					}
					finally
					{
						((IDisposable)enumerator2)?.Dispose();
					}
					DeclaracoesGeral.bAnularEventos = true;
					val7.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					val7.Abort();
					throw;
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
		catch (Exception projectError3)
		{
			ProjectData.SetProjectError(projectError3);
			ProjectData.ClearProjectError();
		}
		flag = true;
		clsInterligacao.OcultaTodasAsVeiasDoDesnho(ref flag);
	}

	public static string BuscaNomeDoCabo(ref mTrocaCabos[] iNomeCabos, string sNome)
	{
		string result = sNome;
		int num = Information.UBound(iNomeCabos);
		for (int i = 0; i <= num; i = checked(i + 1))
		{
			if (Operators.CompareString(iNomeCabos[i].sCabo, sNome, TextCompare: true) == 0)
			{
				result = iNomeCabos[i].sCaboNovo;
				break;
			}
		}
		return result;
	}
}

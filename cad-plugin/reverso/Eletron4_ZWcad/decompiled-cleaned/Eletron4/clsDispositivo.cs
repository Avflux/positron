using System;
using System.Collections;
using System.Collections.Generic;
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
using oADsu33FpCEasW73ADP;

namespace Eletron4;

public class clsDispositivo
{
	public struct mBlocosPrincipal
	{
		public string sNome1;

		public string sNome2;

		public string sAlternativo;

		public int iPainel;

		public string sPainel;

		public int iOrdem;

		public int iLM;

		public bool bComplementar;

		public string sTipo;

		public string sHandle;

		public string sTerminais;

		public int iQuantTerminais;
	}

	public static void CarregaBlocosNaMatriz(ref object mBlocos, string sSimbologia)
	{
		mBlocos = new object[3, 1];
		NewLateBinding.LateIndexSet(mBlocos, new object[3] { 0, 0, "Bloco" }, null);
		NewLateBinding.LateIndexSet(mBlocos, new object[3] { 1, 0, "Caminho" }, null);
		NewLateBinding.LateIndexSet(mBlocos, new object[3] { 2, 0, "Nome Completo" }, null);
		DirectoryInfo directoryInfo = new DirectoryInfo(sSimbologia);
		FileInfo[] files = directoryInfo.GetFiles();
		string text = "";
		string sNomeDWGVisivel = "";
		string sDiretorio = "";
		string sNomeCompleto = "";
		FileInfo[] array = files;
		checked
		{
			foreach (FileInfo fileInfo in array)
			{
				text = fileInfo.FullName;
				if (Operators.CompareString(Strings.UCase(Strings.Mid(text, Strings.Len(text) - 2, 3)), "DWG", TextCompare: true) == 0)
				{
					string sCaminhoCompleto = text;
					string sTipo = "";
					ExtraiNomeCaminhoDwgPorTipo(sCaminhoCompleto, ref sDiretorio, ref sNomeCompleto, ref sNomeDWGVisivel, ref sTipo);
					mBlocos = Utils.CopyArray((Array)mBlocos, new object[3, Information.UBound((Array)mBlocos, 2) + 1 + 1]);
					NewLateBinding.LateIndexSet(mBlocos, new object[3]
					{
						0,
						Information.UBound((Array)mBlocos, 2),
						sNomeDWGVisivel
					}, null);
					NewLateBinding.LateIndexSet(mBlocos, new object[3]
					{
						1,
						Information.UBound((Array)mBlocos, 2),
						text
					}, null);
					NewLateBinding.LateIndexSet(mBlocos, new object[3]
					{
						2,
						Information.UBound((Array)mBlocos, 2),
						sNomeCompleto + ".dwg"
					}, null);
				}
			}
		}
	}

	public static bool ExtraiNomeCaminhoDwgPorTipo(string sCaminhoCompleto, ref string sDiretorio, ref string sNomeCompleto, ref string sNomeDWGVisivel, ref string sTipo)
	{
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Expected Obj, but got Unknown
		checked
		{
			bool result;
			try
			{
				string text = "";
				sNomeDWGVisivel = "";
				sDiretorio = "";
				sTipo = "";
				short num = (short)(Strings.Len(sCaminhoCompleto) - 4);
				short length = default;
				for (short num2 = num; num2 >= 1; num2 = (short)unchecked(num2 + -1))
				{
					char c = Conversions.ToChar(Strings.Mid(sCaminhoCompleto, num2, 1));
					if (c == '\\')
					{
						length = num2;
						break;
					}
					text = Conversions.ToString(c) + text;
				}
				if (!(((Operators.CompareString(Strings.Mid(text, 1, 1), "H", TextCompare: true) == 0) | (Operators.CompareString(Strings.Mid(text, 1, 1), "V", TextCompare: true) == 0)) & (Operators.CompareString(Strings.Mid(text, 2, 1), "_", TextCompare: true) == 0) & (Operators.CompareString(Strings.Mid(text, 4, 1), "_", TextCompare: true) == 0)))
				{
					sTipo = "";
					sNomeDWGVisivel = text;
					sDiretorio = Strings.Mid(sCaminhoCompleto, 1, length);
					sNomeCompleto = text;
					result = false;
				}
				else
				{
					sTipo = Strings.Mid(text, 3, 1);
					sDiretorio = Strings.Mid(sCaminhoCompleto, 1, length);
					sNomeDWGVisivel = Strings.Mid(text, 5, Strings.Len(text));
					sNomeCompleto = text;
					result = true;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				sTipo = "";
				sDiretorio = "";
				sNomeCompleto = "";
				result = false;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public static void ApagaContatosModeloDispositivo(Entity entPri)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected Obj, but got Unknown
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Expected Obj, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected Obj, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected Obj, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected Obj, but got Unknown
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected Obj, but got Unknown
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Expected Obj, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Expected Obj, but got Unknown
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Expected Obj, but got Unknown
		BlockReference blockRef = (BlockReference)entPri;
		object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
		entPri = (Entity)(object)blockRef;
		object obj2 = obj;
		DeclaracoesEntidades.StructureDispositivo structureDispositivo = ((obj2 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj2));
		string right = ((object)((DBObject)entPri).Handle/*cast due to constrained. prefix*/).ToString();
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
								if (Operators.CompareString(left, "P", TextCompare: true) != 0)
								{
									Declaracoes2.StructureModelo Modelo = default;
									ent = (Entity)(object)val6;
									bool flag = XDataDispositivosMaster.LerXDataModelo(ref ent, ref Modelo);
									val6 = (BlockReference)ent;
									if (flag && Operators.CompareString(Modelo.HandleBob, right, TextCompare: true) == 0)
									{
										((DBObject)val5).UpgradeOpen();
										((DBObject)val5).Erase();
									}
								}
								else if (Operators.CompareString(((object)((DBObject)entPri).Handle/*cast due to constrained. prefix*/).ToString(), ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString(), TextCompare: true) != 0)
								{
									blockRef = (BlockReference)val5;
									obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
									val5 = (Entity)(object)blockRef;
									object obj3 = obj;
									DeclaracoesEntidades.StructureDispositivo structureDispositivo2 = ((obj3 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj3));
									if ((structureDispositivo.Painel == structureDispositivo2.Painel) & (Operators.CompareString(structureDispositivo.Nome1, structureDispositivo2.Nome1, TextCompare: true) == 0) & (Operators.CompareString(structureDispositivo.Nome2, structureDispositivo2.Nome2, TextCompare: true) == 0) & (Operators.CompareString(structureDispositivo.Alternativo, structureDispositivo2.Alternativo, TextCompare: true) == 0) & structureDispositivo2.Complementar)
									{
										((DBObject)val5).UpgradeOpen();
										((DBObject)val5).Erase();
									}
								}
							}
							else
							{
								blockRef = (BlockReference)val5;
								obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
								val5 = (Entity)(object)blockRef;
								object obj4 = obj;
								if (Operators.CompareString(((obj4 == null) ? default(DeclaracoesEntidades.StructureAuxiliar) : ((DeclaracoesEntidades.StructureAuxiliar)obj4)).HandleBob, right, TextCompare: true) == 0)
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

	public static void promoveComplementar(Entity entPri)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected Obj, but got Unknown
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Expected Obj, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected Obj, but got Unknown
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected Obj, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected Obj, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected Obj, but got Unknown
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Expected Obj, but got Unknown
		BlockReference blockRef = (BlockReference)entPri;
		object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
		entPri = (Entity)(object)blockRef;
		object obj2 = obj;
		DeclaracoesEntidades.StructureDispositivo structureDispositivo = ((obj2 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj2));
		((object)((DBObject)entPri).Handle/*cast due to constrained. prefix*/).ToString();
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
							if (Operators.CompareString(left, "P", TextCompare: true) == 0 && Operators.CompareString(((object)((DBObject)entPri).Handle/*cast due to constrained. prefix*/).ToString(), ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString(), TextCompare: true) != 0)
							{
								blockRef = (BlockReference)val5;
								obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
								val5 = (Entity)(object)blockRef;
								object obj3 = obj;
								DeclaracoesEntidades.StructureDispositivo disp = ((obj3 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj3));
								if ((Operators.CompareString(structureDispositivo.Nome1, disp.Nome1, TextCompare: true) == 0) & (Operators.CompareString(structureDispositivo.Nome2, disp.Nome2, TextCompare: true) == 0) & (Operators.CompareString(structureDispositivo.Alternativo, disp.Alternativo, TextCompare: true) == 0) & disp.Complementar & !structureDispositivo.Complementar)
								{
									((DBObject)val5).UpgradeOpen();
									disp.Complementar = false;
									XDataDispositivosMaster.GravarXDataDispPrincipal(ref val6, ref disp);
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
				catch (Exception ex)
				{
					ProjectData.SetProjectError((Exception)ex);
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

	public static int carregaOsContatosDoModeloselecionado(string sNomeModelo, ref Declaracoes2.MModelosDeContatos[] mModelo, ref Declaracoes2.StructureContatosAuxiliares[] mContatos)
	{
		int iIndiceSelecionado = 0;
		int num = Information.UBound(mModelo);
		int result = default;
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (Operators.CompareString(mModelo[i].sNomeModelo, sNomeModelo, TextCompare: true) == 0)
			{
				iIndiceSelecionado = mModelo[i].iIndiceModelo;
				result = iIndiceSelecionado;
				break;
			}
		}
		if (iIndiceSelecionado > 0)
		{
			DicionarioContatos.LeOsContatosAuxiliarDoModeloDoDicionario(ref iIndiceSelecionado, ref mContatos);
		}
		return result;
	}

	public static void InsereOsContatosAuxiliaresModelo(Point3d pt, string sNorma, ref BlockReference blockRefAnterior, Declaracoes2.StructureModelo Modelo, Declaracoes2.StructureContatosAuxiliares[] mCONTATOS, string sLayer, double dDistanciaEntreModelo)
	{
		//IL_051b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0521: Expected Obj, but got Unknown
		//IL_0523: Expected Obj, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected Obj, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected Obj, but got Unknown
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fa: Expected Obj, but got Unknown
		//IL_04fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0501: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected Obj, but got Unknown
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Expected Obj, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected Obj, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Expected Obj, but got Unknown
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Expected Obj, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Expected Obj, but got Unknown
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			_ = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				ObjectId val3 = ObjectId.Null;
				BlockTable val4 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)0);
				BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)1);
				string sNomeBlocoAnterior = "RC_TIT";
				int num = Information.UBound(mCONTATOS);
				BlockTableRecordEnumerator enumerator = default;
				for (int i = 1; i <= num; i = checked(i + 1))
				{
					clsBlocos.calculaOPontoCentralDoBloco(blockRefAnterior, ref pt, ref dDistanciaEntreModelo, sNomeBlocoAnterior);
					string text = "RC_" + mCONTATOS[i].sTipo;
					sNomeBlocoAnterior = text;
					string text2 = DeclaracoesGeral.Conf.DirSimbologiaEletrica + "\\Auxiliares\\" + sNorma + "\\" + text + ".dwg";
					val3 = ObjectId.Null;
					text2 = text2.Replace("\\\\", "\\");
					if (!((SymbolTable)val4).Has(text))
					{
						Database val6 = new Database(false, true);
						val6.ReadDwgFile(text2, FileShare.Read, true, "");
						DeclaracoesGeral.bAnularEventos = true;
						val3 = database.Insert(text, val6, false);
						((DisposableWrapper)val6).Dispose();
					}
					else
					{
						BlockTableRecord val7 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[text], (OpenMode)0);
						val3 = ((DBObject)val7).Id;
					}
					blockRefAnterior = new BlockReference(pt, val3);
					((Entity)blockRefAnterior).Layer = sLayer;
					val5.AppendEntity((Entity)(object)blockRefAnterior);
					((Entity)blockRefAnterior).Draw();
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)blockRefAnterior, true);
					BlockTableRecord val8 = (BlockTableRecord)val2.GetObject(val3, (OpenMode)0);
					try
					{
						enumerator = val8.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val9 = (Entity)val2.GetObject(current, (OpenMode)0);
							if (!(val9 is AttributeDefinition))
							{
								continue;
							}
							AttributeDefinition val10 = (AttributeDefinition)val9;
							AttributeReference val11 = new AttributeReference();
							val11.SetAttributeFromBlock(val10, blockRefAnterior.BlockTransform);
							string text3 = "";
							string tag = val10.Tag;
							if (Operators.CompareString(tag, "T1", TextCompare: true) != 0)
							{
								if (Operators.CompareString(tag, "INSERCAO", TextCompare: true) != 0)
								{
									if (Operators.CompareString(tag, "INSERCAONA", TextCompare: true) != 0)
									{
										if (Operators.CompareString(tag, "INSERCAONF", TextCompare: true) == 0)
										{
											text3 = "";
										}
									}
									else
									{
										text3 = "";
									}
								}
								else
								{
									text3 = "";
								}
							}
							else
							{
								text3 = mCONTATOS[i].sT1;
								if (Operators.CompareString(text3, "", TextCompare: true) == 0)
								{
									text3 = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
								}
							}
							if (Operators.CompareString(mCONTATOS[i].sTipo, "NA", TextCompare: true) == 0)
							{
								string tag2 = val10.Tag;
								if (Operators.CompareString(tag2, "T2", TextCompare: true) == 0)
								{
									text3 = mCONTATOS[i].sT2;
									if (Operators.CompareString(text3, "", TextCompare: true) == 0)
									{
										text3 = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
									}
								}
							}
							if (Operators.CompareString(mCONTATOS[i].sTipo, "NF", TextCompare: true) == 0)
							{
								string tag3 = val10.Tag;
								if (Operators.CompareString(tag3, "T2", TextCompare: true) == 0)
								{
									text3 = mCONTATOS[i].sT2;
									if (Operators.CompareString(text3, "", TextCompare: true) == 0)
									{
										text3 = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
									}
								}
							}
							if (Operators.CompareString(mCONTATOS[i].sTipo, "RV", TextCompare: true) == 0)
							{
								string tag4 = val10.Tag;
								if (Operators.CompareString(tag4, "T2", TextCompare: true) != 0)
								{
									if (Operators.CompareString(tag4, "T3", TextCompare: true) == 0)
									{
										text3 = mCONTATOS[i].sT3;
										if (Operators.CompareString(text3, "", TextCompare: true) == 0)
										{
											text3 = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
										}
									}
								}
								else
								{
									text3 = mCONTATOS[i].sT2;
									if (Operators.CompareString(text3, "", TextCompare: true) == 0)
									{
										text3 = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
									}
								}
							}
							((DBText)val11).TextString = text3;
							((DBText)val11).AdjustAlignment(database);
							blockRefAnterior.AttributeCollection.AppendAttribute(val11);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)val11, true);
							((Entity)val11).Draw();
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
					((Entity)blockRefAnterior).Draw();
					Modelo.indexContato = mCONTATOS[i].iIndice;
					Modelo.HandleContatoAux = "";
					XDataDispositivosMaster.GravarXDataDispModelo(ref blockRefAnterior, ref Modelo);
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				Exception ex2 = ex;
				val2.Abort();
				Interaction.MsgBox(((Exception)(object)ex2).Message, MsgBoxStyle.Information);
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

	public static string BuscaTerminaisNoModelo(string sModelos, ref Declaracoes2.MModelosDeContatos[] mMODELO)
	{
		string result = "";
		if (Information.UBound(mMODELO) > 0)
		{
			int num = Information.UBound(mMODELO);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (Operators.CompareString(sModelos, mMODELO[i].sNomeModelo, TextCompare: true) == 0)
				{
					result = mMODELO[i].sTerminaisDoDispositivo;
					break;
				}
			}
		}
		return result;
	}

	public static string BuscaNomeDoModelo(int iIndexModelo, ref Declaracoes2.MModelosDeContatos[] mMODELO)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		string result = "";
		try
		{
			int num = Information.UBound(mMODELO);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (mMODELO[i].iIndiceModelo == iIndexModelo)
				{
					result = mMODELO[i].sNomeModelo;
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError((Exception)ex);
			result = "";
			throw;
		}
		return result;
	}

	public static int BuscaIndiceDoModelo(string sModelo, ref Declaracoes2.MModelosDeContatos[] mMODELO)
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected Obj, but got Unknown
		int result = 0;
		try
		{
			int num = Information.UBound(mMODELO);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (Operators.CompareString(mMODELO[i].sNomeModelo, sModelo, TextCompare: true) == 0)
				{
					result = mMODELO[i].iIndiceModelo;
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError((Exception)ex);
			result = Conversions.ToInteger("");
			throw;
		}
		return result;
	}

	public static void CarregaBlocos(ref object mBlocos, string sTipoBloco)
	{
		mBlocos = new object[3, 1];
		NewLateBinding.LateIndexSet(mBlocos, new object[3] { 0, 0, "Bloco" }, null);
		NewLateBinding.LateIndexSet(mBlocos, new object[3] { 1, 0, "Caminho" }, null);
		NewLateBinding.LateIndexSet(mBlocos, new object[3] { 2, 0, "Nome Completo" }, null);
		if (!((Operators.CompareString(DeclaracoesGeral.Conf.DirSimbologiaEletrica, "", TextCompare: true) != 0) & Directory.Exists(DeclaracoesGeral.Conf.DirSimbologiaEletrica)))
		{
			return;
		}
		DirectoryInfo directoryInfo = new DirectoryInfo(DeclaracoesGeral.Conf.DirSimbologiaEletrica);
		FileInfo[] files = directoryInfo.GetFiles();
		string text = "";
		string sNomeDWGVisivel = "";
		string sDiretorio = "";
		string sTipo = "";
		string sNomeCompleto = "";
		FileInfo[] array = files;
		checked
		{
			foreach (FileInfo fileInfo in array)
			{
				text = fileInfo.FullName;
				if (Operators.CompareString(Strings.UCase(Strings.Mid(text, Strings.Len(text) - 2, 3)), "DWG", TextCompare: true) == 0)
				{
					ExtraiNomeCaminhoDwgPorTipo(text, ref sDiretorio, ref sNomeCompleto, ref sNomeDWGVisivel, ref sTipo);
					if (Operators.CompareString(sTipo, sTipoBloco, TextCompare: true) == 0)
					{
						mBlocos = Utils.CopyArray((Array)mBlocos, new object[3, Information.UBound((Array)mBlocos, 2) + 1 + 1]);
						NewLateBinding.LateIndexSet(mBlocos, new object[3]
						{
							0,
							Information.UBound((Array)mBlocos, 2),
							sNomeDWGVisivel
						}, null);
						NewLateBinding.LateIndexSet(mBlocos, new object[3]
						{
							1,
							Information.UBound((Array)mBlocos, 2),
							text
						}, null);
						NewLateBinding.LateIndexSet(mBlocos, new object[3]
						{
							2,
							Information.UBound((Array)mBlocos, 2),
							sNomeCompleto
						}, null);
					}
				}
			}
		}
	}

	public static bool ExtraiNomeCaminhoDwgPorTipoAux(string sCaminhoCompleto, ref string sDiretorio, ref string sNomeDWGVisivel, ref string sTipo, ref string sComportamento, ref string iQuantNomes)
	{
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Expected Obj, but got Unknown
		bool flag = true;
		string left = "";
		checked
		{
			try
			{
				sTipo = "";
				sComportamento = "";
				sNomeDWGVisivel = "";
				sDiretorio = "";
				string text = "";
				short num = (short)(Strings.Len(sCaminhoCompleto) - 4);
				short length = default;
				for (short num2 = num; num2 >= 1; num2 = (short)unchecked(num2 + -1))
				{
					char c = Conversions.ToChar(Strings.Mid(sCaminhoCompleto, num2, 1));
					if (c == '\\')
					{
						length = num2;
						break;
					}
					text = Conversions.ToString(c) + text;
				}
				if (!((Operators.CompareString(Strings.Mid(text, 1, 3), "H_A", TextCompare: true) == 0) | (Operators.CompareString(Strings.Mid(text, 1, 3), "V_A", TextCompare: true) == 0)))
				{
					flag = false;
					sDiretorio = Strings.Mid(sCaminhoCompleto, 1, length);
				}
				else
				{
					sDiretorio = Strings.Mid(sCaminhoCompleto, 1, length);
					sNomeDWGVisivel = text;
					flag = true;
					if (Operators.CompareString(left, Strings.Mid(text, 7, 1), TextCompare: true) == 0)
					{
						flag = false;
					}
					else
					{
						left = Strings.Mid(text, 7, 1);
						if (!Versioned.IsNumeric(left))
						{
							flag = false;
						}
						else
						{
							iQuantNomes = Conversions.ToString(Conversions.ToInteger(left));
							string left2 = Strings.Mid(text, 5, 2);
							if (Operators.CompareString(left2, "NA", TextCompare: true) != 0 && Operators.CompareString(left2, "NF", TextCompare: true) != 0 && Operators.CompareString(left2, "RV", TextCompare: true) != 0)
							{
								text = "";
								flag = false;
							}
							else
							{
								sTipo = Strings.Mid(text, 5, 2);
								string left3 = Strings.Mid(text, Strings.Len(text) - 1, 2);
								if (Operators.CompareString(left3, "ST", TextCompare: true) != 0 && Operators.CompareString(left3, "TE", TextCompare: true) != 0 && Operators.CompareString(left3, "TD", TextCompare: true) != 0 && Operators.CompareString(left3, "BI", TextCompare: true) != 0 && Operators.CompareString(left3, "AM", TextCompare: true) != 0)
								{
									text = "";
									flag = false;
								}
								else
								{
									sComportamento = Strings.Mid(text, Strings.Len(text) - 1, 2);
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				flag = false;
				ProjectData.ClearProjectError();
			}
			if (!flag)
			{
				sTipo = "";
				sComportamento = "";
				sNomeDWGVisivel = "";
				sDiretorio = "";
				iQuantNomes = Conversions.ToString(0);
			}
			return flag;
		}
	}

	public static void carregaModelosNoCombo(ref ComboBox combo, ref Declaracoes2.MModelosDeContatos[] mMODELO)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected Obj, but got Unknown
		try
		{
			combo.Items.Clear();
			int num = Information.UBound(mMODELO);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				combo.Items.Add(mMODELO[i].sNomeModelo);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError((Exception)ex);
			throw;
		}
	}

	public static void InserirBlocoSimbologia(string sCaminhoBloco, string sNomeBlocoDWG, string sTerm, ref DeclaracoesEntidades.StructureDispositivo Disp, Declaracoes2.MModelosDeContatos[] mMODELO, Declaracoes2.StructureContatosAuxiliares[] mCONTATOS, string sFabricante, bool bOcultaModelo)
	{
		//IL_0740: Unknown result type (might be due to invalid IL or missing references)
		//IL_0746: Expected Obj, but got Unknown
		//IL_0748: Expected Obj, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected Obj, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected Obj, but got Unknown
		//IL_0683: Unknown result type (might be due to invalid IL or missing references)
		//IL_068e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0695: Expected Obj, but got Unknown
		//IL_0697: Unknown result type (might be due to invalid IL or missing references)
		//IL_069c: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected Obj, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Expected Obj, but got Unknown
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Invalid comparison between Unknown and I4
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Invalid comparison between Unknown and I4
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected Obj, but got Unknown
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected Obj, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Expected Obj, but got Unknown
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected Obj, but got Unknown
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Expected Obj, but got Unknown
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Expected Obj, but got Unknown
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_0643: Unknown result type (might be due to invalid IL or missing references)
		//IL_0648: Unknown result type (might be due to invalid IL or missing references)
		//IL_040a: Unknown result type (might be due to invalid IL or missing references)
		//IL_038d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0394: Expected Obj, but got Unknown
		//IL_03ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d8: Invalid comparison between Unknown and I4
		PointMonitorToolTips.StopMonitor();
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				ObjectId val3 = ObjectId.Null;
				BlockTable val4 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)1);
				BlockReference val6 = null;
				BlockTableRecord val7 = null;
				if (!((SymbolTable)val4).Has(sNomeBlocoDWG))
				{
					Database val8 = new Database(false, true);
					val8.ReadDwgFile(sCaminhoBloco, FileShare.Read, true, "");
					DeclaracoesGeral.bAnularEventos = true;
					val3 = database.Insert(sNomeBlocoDWG, val8, false);
					((DisposableWrapper)val8).Dispose();
				}
				else
				{
					BlockTableRecord val9 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[sNomeBlocoDWG], (OpenMode)0);
					val3 = ((DBObject)val9).Id;
				}
				val6 = new BlockReference(Point3d.Origin, val3);
				((Entity)val6).Layer = DeclaracoesGeral.ativo.Pagina;
				Jig jig = new Jig((Entity)(object)val6);
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				PromptResult val10 = editor.Drag((Jig)(object)jig);
				if (!(((int)val10.Status == -5002) | ((int)val10.Status == -5001)))
				{
					val5.AppendEntity((Entity)(object)val6);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val6, true);
					Point3d position = val6.Position;
					Disp.posX = Math.Round(position.X, 2);
					position = val6.Position;
					Disp.posY = Math.Round(position.Y, 2) - Disp.distContAux;
					val7 = (BlockTableRecord)val2.GetObject(val3, (OpenMode)0);
					string nome = Disp.Nome1;
					string nome2 = Disp.Nome2;
					string alternativo = Disp.Alternativo;
					bool flag = false;
					bool flag2 = false;
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val7.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val11 = (Entity)val2.GetObject(current, (OpenMode)0);
							if (!(val11 is AttributeDefinition))
							{
								continue;
							}
							AttributeDefinition val12 = (AttributeDefinition)val11;
							string tag = val12.Tag;
							if (Operators.CompareString(tag, "NOME2", TextCompare: true) != 0)
							{
								if (Operators.CompareString(tag, "ALTERNATIVO", TextCompare: true) == 0)
								{
									flag2 = true;
								}
							}
							else
							{
								flag = true;
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
						enumerator2 = val7.GetEnumerator();
						while (enumerator2.MoveNext())
						{
							ObjectId current = enumerator2.Current;
							Entity val13 = (Entity)val2.GetObject(current, (OpenMode)0);
							if (!(val13 is AttributeDefinition))
							{
								continue;
							}
							AttributeDefinition val14 = (AttributeDefinition)val13;
							AttributeReference val15 = new AttributeReference();
							val15.SetAttributeFromBlock(val14, val6.BlockTransform);
							string text = "";
							string tag2 = val14.Tag;
							if (Operators.CompareString(tag2, "PAINEL", TextCompare: true) != 0)
							{
								if (Operators.CompareString(tag2, "MODELO", TextCompare: true) != 0)
								{
									if (Operators.CompareString(tag2, "FABRICANTE", TextCompare: true) != 0)
									{
										if (Operators.CompareString(tag2, "NOME1", TextCompare: true) != 0)
										{
											if (Operators.CompareString(tag2, "NOME2", TextCompare: true) != 0)
											{
												if (Operators.CompareString(tag2, "ALTERNATIVO", TextCompare: true) != 0)
												{
													if (!((Operators.CompareString(Strings.Mid(val14.Tag, 1, 1), "T", TextCompare: true) == 0) & Versioned.IsNumeric(Strings.Mid(val14.Tag, 2, Strings.Len(val14.Tag)))))
													{
														string text2 = val14.Tag;
														if (Operators.CompareString(val14.Prompt, "", TextCompare: true) != 0)
														{
															text2 = val14.Prompt;
														}
														PromptStringOptions val16 = new PromptStringOptions("\n" + text2);
														val16.AllowSpaces = true;
														val16.DefaultValue = "";
														val16.UseDefaultValue = true;
														Editor editor2 = Application.DocumentManager.MdiActiveDocument.Editor;
														PromptResult val17 = editor2.GetString(val16);
														if ((int)val17.Status != 5100)
														{
															return;
														}
														text = val17.StringResult.Trim();
													}
													else
													{
														sTerm += ";";
														int num = 1;
														string text3 = "";
														int num2 = Strings.Len(sTerm);
														checked
														{
															for (int i = 1; i <= num2; i++)
															{
																string text4 = Strings.Mid(sTerm, i, 1);
																if (Operators.CompareString(text4, ";", TextCompare: true) != 0)
																{
																	text3 += text4;
																	continue;
																}
																if (num == Conversions.ToInteger(Strings.Mid(val14.Tag, 2, Strings.Len(val14.Tag))))
																{
																	break;
																}
																text3 = "";
																num++;
															}
															if (Operators.CompareString(text3, "", TextCompare: true) == 0)
															{
																text3 = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
															}
															text = text3;
														}
													}
												}
												else
												{
													text = alternativo;
													if (!Disp.AlternativoVisivel)
													{
														((Entity)val15).Visible = false;
													}
													else
													{
														((Entity)val15).Visible = true;
													}
												}
											}
											else if (Disp.NomeVisivel)
											{
												text = nome2;
											}
										}
										else
										{
											if (Disp.NomeVisivel)
											{
												if (flag)
												{
													text = nome;
												}
												else
												{
													text = ((Operators.CompareString(nome2, "", TextCompare: true) != 0) ? (nome + "/" + nome2) : nome);
												}
												if (Disp.AlternativoVisivel && !flag2)
												{
													text = ((Operators.CompareString(text, "", TextCompare: true) != 0) ? (text + "/" + alternativo) : alternativo);
												}
											}
											if ((Disp.AlternativoVisivel & !flag2 & !Disp.NomeVisivel) && Operators.CompareString(alternativo, "", TextCompare: true) != 0)
											{
												text = alternativo;
											}
										}
									}
									else
									{
										text = sFabricante;
									}
								}
								else if (DeclaracoesGeral.Conf.ModeloBobina != 0)
								{
									text = Disp.Modelo;
								}
							}
							else
							{
								text = Dicionario.BuscaNomeDoPainel(Disp.Painel);
							}
							((DBText)val15).TextString = text;
							((DBText)val15).AdjustAlignment(database);
							val6.AttributeCollection.AppendAttribute(val15);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)val15, true);
							((Entity)val15).Draw();
						}
					}
					finally
					{
						((IDisposable)enumerator2)?.Dispose();
					}
					((Entity)val6).Draw();
					if (!Disp.Complementar)
					{
						Disp.indexModelo = carregaOsContatosDoModeloselecionado(Disp.Modelo, ref mMODELO, ref mCONTATOS);
					}
					else
					{
						Disp.indexModelo = 0;
						Disp.distContAux = 0.0;
						Disp.posX = 0.0;
						Disp.posY = 0.0;
					}
					Disp.Handle = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
					XDataDispositivosMaster.GravarXDataDispPrincipal(ref val6, ref Disp);
					if (Operators.CompareString(Disp.Modelo, "", TextCompare: true) != 0 && !Disp.Complementar && Information.UBound(mCONTATOS) > 0)
					{
						insereTabelaModelo(ref val6, Disp, mMODELO, mCONTATOS, sFabricante, bOcultaModelo);
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				Exception ex2 = ex;
				val2.Abort();
				Interaction.MsgBox(((Exception)(object)ex2).Message, MsgBoxStyle.Information);
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

	public static void insereTabelaModelo(ref BlockReference blockRef, DeclaracoesEntidades.StructureDispositivo Disp, Declaracoes2.MModelosDeContatos[] mMODELO, Declaracoes2.StructureContatosAuxiliares[] mCONTATOS, string sFabricante, bool bOcultaModelo, double dDistanciaEntreModelo = 0.0)
	{
		//IL_05a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05af: Expected Obj, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected Obj, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected Obj, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0521: Unknown result type (might be due to invalid IL or missing references)
		//IL_052c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0533: Expected Obj, but got Unknown
		//IL_0535: Unknown result type (might be due to invalid IL or missing references)
		//IL_053a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected Obj, but got Unknown
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected Obj, but got Unknown
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Invalid comparison between Unknown and I4
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Invalid comparison between Unknown and I4
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected Obj, but got Unknown
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected Obj, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Expected Obj, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Expected Obj, but got Unknown
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0401: Unknown result type (might be due to invalid IL or missing references)
		//IL_043b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0440: Unknown result type (might be due to invalid IL or missing references)
		//IL_044b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0450: Unknown result type (might be due to invalid IL or missing references)
		//IL_0462: Unknown result type (might be due to invalid IL or missing references)
		//IL_0467: Unknown result type (might be due to invalid IL or missing references)
		//IL_0474: Unknown result type (might be due to invalid IL or missing references)
		//IL_0479: Unknown result type (might be due to invalid IL or missing references)
		//IL_047d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0482: Unknown result type (might be due to invalid IL or missing references)
		//IL_0496: Unknown result type (might be due to invalid IL or missing references)
		//IL_049b: Unknown result type (might be due to invalid IL or missing references)
		//IL_049f: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cf: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				ObjectId val3 = ObjectId.Null;
				BlockTable val4 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)1);
				BlockTableRecord val6 = null;
				string text = "RC_TIT";
				Point3d pt = default;
				clsBlocos.calculaOPontoCentralDoBloco(blockRef, ref pt, ref Disp.distContAux, blockRef.Name);
				string text2 = "IEC";
				if (DeclaracoesGeral.Conf.Norma == 1)
				{
					text2 = "ANSI";
				}
				string text3 = DeclaracoesGeral.Conf.DirSimbologiaEletrica + "\\Auxiliares\\" + text2 + "\\" + text + ".dwg";
				text3 = text3.Replace("\\\\", "\\");
				if (File.Exists(text3))
				{
					val3 = ObjectId.Null;
					if (!((SymbolTable)val4).Has(text))
					{
						Database val7 = new Database(false, true);
						val7.ReadDwgFile(text3, FileShare.Read, true, "");
						DeclaracoesGeral.bAnularEventos = true;
						val3 = database.Insert(text, val7, false);
						((DisposableWrapper)val7).Dispose();
					}
					else
					{
						BlockTableRecord val8 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[text], (OpenMode)0);
						val3 = ((DBObject)val8).Id;
					}
					BlockReference blockRef2 = new BlockReference(Point3d.Origin, val3);
					((Entity)blockRef2).Layer = DeclaracoesGeral.ativo.Pagina;
					Jig jig = new Jig((Entity)(object)blockRef2);
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
					PromptResult val9 = editor.Drag((Jig)(object)jig);
					if (!(((int)val9.Status == -5002) | ((int)val9.Status == -5001)))
					{
						val5.AppendEntity((Entity)(object)blockRef2);
						((Entity)blockRef2).Draw();
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)blockRef2, true);
						val6 = (BlockTableRecord)val2.GetObject(val3, (OpenMode)0);
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
								AttributeReference val12 = new AttributeReference();
								val12.SetAttributeFromBlock(val11, blockRef2.BlockTransform);
								string textString = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
								if ((Operators.CompareString(val11.Tag, "NOME1", TextCompare: true) == 0) | (Operators.CompareString(val11.Tag, "NOME", TextCompare: true) == 0))
								{
									string text4 = "";
									if (Disp.NomeVisivel)
									{
										text4 = Disp.Nome1;
										if (Operators.CompareString(Disp.Nome2, "", TextCompare: true) != 0)
										{
											text4 = Disp.Nome1 + "/" + Disp.Nome2;
										}
									}
									if (Disp.AlternativoVisivel)
									{
										if (Operators.CompareString(text4, "", TextCompare: true) != 0)
										{
											text4 += "/";
										}
										text4 += Disp.Alternativo;
									}
									textString = text4;
								}
								if (Operators.CompareString(val11.Tag, "MODELO", TextCompare: true) == 0)
								{
									textString = Disp.Modelo;
								}
								if (Operators.CompareString(val11.Tag, "FABRICANTE", TextCompare: true) == 0)
								{
									textString = sFabricante;
								}
								if (Operators.CompareString(val11.Tag, "FUNCAO", TextCompare: true) == 0)
								{
									textString = "";
								}
								((DBText)val12).TextString = textString;
								((DBText)val12).AdjustAlignment(database);
								blockRef2.AttributeCollection.AppendAttribute(val12);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val12, true);
								((Entity)val12).Draw();
							}
						}
						finally
						{
							((IDisposable)enumerator)?.Dispose();
						}
						if (DeclaracoesGeral.Conf.ModeloBobina == 1)
						{
							((DBObject)blockRef2).UpgradeOpen();
							((Entity)blockRef2).Visible = false;
						}
						Declaracoes2.StructureModelo Modelo = new Declaracoes2.StructureModelo
						{
							indexModelo = Disp.indexModelo,
							HandleBob = ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString(),
							HandleContatoAux = "",
							indexContato = 0
						};
						XDataDispositivosMaster.GravarXDataDispModelo(ref blockRef2, ref Modelo);
						((Entity)blockRef2).Draw();
						Point3d val13 = blockRef2.Position;
						double x = val13.X;
						val13 = blockRef2.Position;
						pt = new Point3d(x, val13.Y, 0.0);
						Extents3d value = ((Drawable)blockRef2).Bounds.Value;
						val13 = value.MaxPoint;
						double y = val13.Y;
						value = ((Drawable)blockRef2).Bounds.Value;
						val13 = value.MinPoint;
						_ = y - val13.Y;
						if (dDistanciaEntreModelo != 0.0)
						{
							Declaracoes2.dDistanciaModelo0 = dDistanciaEntreModelo;
						}
						else
						{
							Declaracoes2.dDistanciaModelo0 = clsDispositivoAuxiliares.BuscaAlturaDoModelo(Modelo.HandleBob);
						}
						double dDistanciaModelo = Declaracoes2.dDistanciaModelo0;
						InsereOsContatosAuxiliaresModelo(pt, text2, ref blockRef2, Modelo, mCONTATOS, ((Entity)blockRef).Layer.ToString(), dDistanciaModelo);
					}
					else
					{
						((DBObject)blockRef).UpgradeOpen();
						((DBObject)blockRef).Erase();
					}
				}
				else
				{
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 900]), MsgBoxStyle.Information);
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
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

	public static string selecionaDispositivoPrincipalInserido(ref Declaracoes2.MDispPrincipal myBL, ref DeclaracoesEntidades.StructureDispositivo Disp)
	{
		//IL_0378: Unknown result type (might be due to invalid IL or missing references)
		//IL_037e: Expected Obj, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected Obj, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected Obj, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
		clsBlocos.Unhighlight();
		PointMonitorToolTips.StopMonitor();
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			_ = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				Point3d ptInsert = default;
				ObjectId val3 = selDispositivoPrincipal(ref ptInsert, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 973]));
				if (!val3.IsNull)
				{
					BlockReference val4 = (BlockReference)val2.GetObject(val3, (OpenMode)0);
					if (!Information.IsDBNull(val4))
					{
						Entity ent = (Entity)(object)val4;
						string tipoImportado = "";
						string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
						val4 = (BlockReference)ent;
						if (Operators.CompareString(left, "P", TextCompare: true) == 0)
						{
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val4);
							Disp = ((obj == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj));
							if (Disp.dAlturaModelo < 0.0)
							{
								clsDispositivoAuxiliares.CorrigeAlturaDosModelos(Disp.indexModelo);
								object obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val4);
								Disp = ((obj2 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj2));
							}
							clsBlocos.AtivaHighlightDispP(ref Disp, ((object)((DBObject)val4).Handle/*cast due to constrained. prefix*/).ToString());
							myBL.sNome1 = Disp.Nome1;
							myBL.sNome2 = Disp.Nome2;
							myBL.LM1 = Disp.iLM1;
							myBL.LM2 = Disp.iLM2;
							myBL.sAlternativo = Disp.Alternativo;
							myBL.iPainel = Disp.Painel;
							myBL.iD = val3;
							myBL.iIndexModelo = Disp.indexModelo;
							myBL.sHandle = ((object)((DBObject)val4).Handle/*cast due to constrained. prefix*/).ToString();
							myBL.bComplementar = Disp.Complementar;
							myBL.dAltura = Disp.dAlturaModelo;
							myBL.sTopografico = Disp.Topografico;
							myBL.sLayout = Disp.Layout;
							myBL.sOrientacao = "";
							myBL.sTerminais = "";
							if (myBL.iIndexModelo > 0)
							{
								Declaracoes2.MModelosDeContatos[] array = null;
								array = new Declaracoes2.MModelosDeContatos[1];
								DicionarioContatos.LeOsModelosDeDeDicionarioContatos(ref array);
								int num = Information.UBound(array);
								for (int i = 1; i <= num; i = checked(i + 1))
								{
									if (array[i].iIndiceModelo == myBL.iIndexModelo)
									{
										myBL.sTopografico = array[i].sBlocoTopografico;
										myBL.sLayout = array[i].sBlocoLayout;
										myBL.LM1 = array[i].iLM1;
										myBL.LM2 = array[i].iLM2;
										myBL.sOrientacao = array[i].sOrientacao;
										myBL.sTerminais = array[i].sTerminaisDoDispositivo;
										break;
									}
								}
							}
							BlockReference val5 = val4;
							if (val5 != null)
							{
								myBL.sNomeBloco = val5.Name;
							}
							if (Operators.CompareString(myBL.sTerminais, "", TextCompare: true) == 0)
							{
								BuscaTerminaisDoBloco(val5, ref myBL.sTerminais);
							}
						}
						result = ((object)((DBObject)val4).Handle/*cast due to constrained. prefix*/).ToString();
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
		PointMonitorToolTips.StartMonitor();
		return result;
	}

	public static void BuscaTerminaisDoBloco(BlockReference blockRef, ref string sTerminais)
	{
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected Obj, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected Obj, but got Unknown
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				AttributeCollection attributeCollection = blockRef.AttributeCollection;
				sTerminais = "";
				int num = attributeCollection.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					foreach (object item in attributeCollection)
					{
						ObjectId val2 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
						AttributeReference val3 = (AttributeReference)val.GetObject(val2, (OpenMode)0);
						if ((!DeclaracoesGeral.attProtCollection.Contains(val3.Tag) & (Operators.CompareString(Strings.Trim(((DBText)val3).TextString), "", TextCompare: true) != 0)) && Operators.CompareString(val3.Tag, "T" + i, TextCompare: true) == 0)
						{
							sTerminais = sTerminais + ((DBText)val3).TextString + ";";
							((Entity)val3).Draw();
						}
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				val.Abort();
				throw;
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}

	public static string BuscaTerminaisTipoTdoBloco(BlockReference blockRef)
	{
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected Obj, but got Unknown
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected Obj, but got Unknown
		string text = "";
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			AttributeCollection attributeCollection = blockRef.AttributeCollection;
			foreach (object item in attributeCollection)
			{
				ObjectId val2 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
				AttributeReference val3 = (AttributeReference)val.GetObject(val2, (OpenMode)0);
				string tag = val3.Tag;
				if (tag.Length > 1 && (tag.StartsWith("T") & Versioned.IsNumeric(tag.Substring(1))))
				{
					text = text + ((DBText)val3).TextString + ";";
					((Entity)val3).Draw();
				}
			}
			DeclaracoesGeral.bAnularEventos = true;
			val.Commit();
			DeclaracoesGeral.bAnularEventos = false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError((Exception)ex);
			val.Abort();
			throw;
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		return text;
	}

	public static ObjectId selDispositivoPrincipal(ref Point3d ptInsert, string msg)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Invalid comparison between Unknown and I4
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
		PromptEntityOptions val = new PromptEntityOptions("\r\n" + msg);
		val.SetRejectMessage("\r\n");
		val.AddAllowedClass(typeof(BlockReference), false);
		PromptEntityResult entity = editor.GetEntity(val);
		if ((int)((PromptResult)entity).Status == 5100)
		{
			ptInsert = entity.PickedPoint;
			return entity.ObjectId;
		}
		return ObjectId.Null;
	}

	public static void carregaMatrizContatos(DataGridView DGContatos, ref Declaracoes2.StructureContatosAuxiliares[] mContatos)
	{
		mContatos = (Declaracoes2.StructureContatosAuxiliares[])Utils.CopyArray(mContatos, new Declaracoes2.StructureContatosAuxiliares[1]);
		int num = 0;
		checked
		{
			int num2 = DGContatos.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				num = Information.UBound(mContatos) + 1;
				mContatos = (Declaracoes2.StructureContatosAuxiliares[])Utils.CopyArray(mContatos, new Declaracoes2.StructureContatosAuxiliares[num + 1]);
				mContatos[num].iIndice = Conversions.ToInteger(DGContatos.Rows[i].Cells[0].Value);
				mContatos[num].sT1 = Conversions.ToString(DGContatos.Rows[i].Cells[1].Value);
				mContatos[num].sT2 = Conversions.ToString(DGContatos.Rows[i].Cells[2].Value);
				mContatos[num].sT3 = Conversions.ToString(DGContatos.Rows[i].Cells[3].Value);
				mContatos[num].sOrientacao = Conversions.ToString(DGContatos.Rows[i].Cells[4].Value);
				mContatos[num].sTipo = Conversions.ToString(DGContatos.Rows[i].Cells[5].Value);
				object value = DGContatos.Rows[i].Cells[5].Value;
				if (!Operators.ConditionalCompareObjectEqual(value, "NA", TextCompare: true))
				{
					if (!Operators.ConditionalCompareObjectEqual(value, "NF", TextCompare: true))
					{
						if (Operators.ConditionalCompareObjectEqual(value, "RV", TextCompare: true))
						{
							mContatos[num].iT = 3;
						}
					}
					else
					{
						mContatos[num].iT = 2;
					}
				}
				else
				{
					mContatos[num].iT = 1;
				}
				mContatos[num].sComportamento = Conversions.ToString(DGContatos.Rows[i].Cells[6].Value);
				object value2 = DGContatos.Rows[i].Cells[6].Value;
				if (!Operators.ConditionalCompareObjectEqual(value2, "ST", TextCompare: true))
				{
					if (!Operators.ConditionalCompareObjectEqual(value2, "TE", TextCompare: true))
					{
						if (!Operators.ConditionalCompareObjectEqual(value2, "TD", TextCompare: true))
						{
							if (!Operators.ConditionalCompareObjectEqual(value2, "BI", TextCompare: true))
							{
								if (Operators.ConditionalCompareObjectEqual(value2, "AM", TextCompare: true))
								{
									mContatos[num].iComportamento = 4;
								}
							}
							else
							{
								mContatos[num].iComportamento = 3;
							}
						}
						else
						{
							mContatos[num].iComportamento = 2;
						}
					}
					else
					{
						mContatos[num].iComportamento = 1;
					}
				}
				else
				{
					mContatos[num].iComportamento = 0;
				}
			}
		}
	}

	public static object ApagaOsContatoAuxiliarDoModelo(int indexModelo)
	{
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected Obj, but got Unknown
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Expected Obj, but got Unknown
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
		string result = "";
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
							Declaracoes2.StructureModelo Modelo = default;
							if (XDataDispositivosMaster.LerXDataModelo(ref Ent, ref Modelo) && Modelo.indexModelo == indexModelo && Modelo.indexContato > 0)
							{
								((DBObject)Ent).UpgradeOpen();
								((DBObject)Ent).Erase();
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
		catch (Exception ex2)
		{
			ProjectData.SetProjectError((Exception)ex2);
			throw;
		}
		finally
		{
		}
		return result;
	}

	public static object ApagaOsContatoAuxiliarDoDispositivo(int indexModelo, int indexContato)
	{
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected Obj, but got Unknown
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected Obj, but got Unknown
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
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected Obj, but got Unknown
		string result = "";
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
							if (Operators.CompareString(left, "A", TextCompare: true) == 0)
							{
								BlockReference blockRef = (BlockReference)ent;
								object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
								ent = (Entity)(object)blockRef;
								DeclaracoesEntidades.StructureAuxiliar structureAuxiliar = ((obj == null) ? default(DeclaracoesEntidades.StructureAuxiliar) : ((DeclaracoesEntidades.StructureAuxiliar)obj));
								if (structureAuxiliar.IndexModelo == indexModelo && structureAuxiliar.IndexContato == indexContato)
								{
									((DBObject)ent).UpgradeOpen();
									((DBObject)ent).Erase();
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
		catch (Exception ex2)
		{
			ProjectData.SetProjectError((Exception)ex2);
			throw;
		}
		finally
		{
		}
		return result;
	}

	public static object ApagaUmModelo(int indexModelo)
	{
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Expected Obj, but got Unknown
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Expected Obj, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected Obj, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected Obj, but got Unknown
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected Obj, but got Unknown
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected Obj, but got Unknown
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Expected Obj, but got Unknown
		string result = "";
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
					bool flag = false;
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity Ent = (Entity)val2.GetObject(current, (OpenMode)0);
							flag = false;
							Declaracoes2.StructureModelo Modelo = default;
							if (XDataDispositivosMaster.LerXDataModelo(ref Ent, ref Modelo))
							{
								if (Modelo.indexModelo == indexModelo)
								{
									((DBObject)Ent).UpgradeOpen();
									((DBObject)Ent).Erase();
								}
								flag = true;
							}
							string tipoImportado;
							if (!flag)
							{
								tipoImportado = "";
								string left = XDataDispositivo.verificaTipoDispositivo(ref Ent, ref tipoImportado);
								if (Operators.CompareString(left, "P", TextCompare: true) == 0)
								{
									BlockReference blockRef = (BlockReference)Ent;
									object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
									Ent = (Entity)(object)blockRef;
									object obj2 = obj;
									DeclaracoesEntidades.StructureDispositivo disp = ((obj2 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj2));
									if (indexModelo == disp.indexModelo)
									{
										disp.indexModelo = 0;
										blockRef = (BlockReference)Ent;
										XDataDispositivosMaster.GravarXDataDispPrincipal(ref blockRef, ref disp);
										Ent = (Entity)(object)blockRef;
									}
									flag = true;
								}
							}
							if (flag)
							{
								continue;
							}
							tipoImportado = "";
							string left2 = XDataDispositivo.verificaTipoDispositivo(ref Ent, ref tipoImportado);
							if (Operators.CompareString(left2, "A", TextCompare: true) == 0)
							{
								BlockReference blockRef = (BlockReference)Ent;
								object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
								Ent = (Entity)(object)blockRef;
								object obj3 = obj;
								if (indexModelo == ((obj3 == null) ? default(DeclaracoesEntidades.StructureAuxiliar) : ((DeclaracoesEntidades.StructureAuxiliar)obj3)).IndexModelo)
								{
									((DBObject)Ent).UpgradeOpen();
									((DBObject)Ent).Erase();
									flag = true;
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
		catch (Exception ex2)
		{
			ProjectData.SetProjectError((Exception)ex2);
			throw;
		}
		finally
		{
		}
		return result;
	}

	public static void carregaModelosNoDG(ref DataGridView dg, Declaracoes2.MModelosDeContatos[] mMODELO)
	{
		//IL_03b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b8: Expected Obj, but got Unknown
		checked
		{
			try
			{
				dg.Rows.Clear();
				dg.Columns.Clear();
				if (Information.UBound(mMODELO) > 0)
				{
					dg.Columns.Add("IndiceModelo", "#");
					dg.Columns.Add("Nome", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 987]));
					dg.Columns.Add("Material1", Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1084], "1")));
					dg.Columns.Add("Material2", Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1084], "2")));
					dg.Columns.Add("Reserva1", "Reserva1");
					dg.Columns.Add("Topográfico", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 990]));
					dg.Columns.Add("Layout", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 991]));
					dg.Columns.Add("Plaquetas", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 992]));
					dg.Columns.Add("Reserva2", "Reserva2");
					dg.Columns.Add("Terminais", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 983]));
					dg.Columns.Add("Orientação", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1846]));
					dg.ColumnHeadersVisible = true;
					int num = Information.UBound(mMODELO);
					for (int i = 1; i <= num; i++)
					{
						dg.Rows.Add(mMODELO[i].iIndiceModelo, mMODELO[i].sNomeModelo, mMODELO[i].iLM1, mMODELO[i].iLM2, 0, mMODELO[i].sBlocoTopografico, mMODELO[i].sBlocoLayout, "", "", mMODELO[i].sTerminaisDoDispositivo, mMODELO[i].sOrientacao);
					}
				}
				foreach (DataGridViewRow item in (IEnumerable)dg.Rows)
				{
					dg.Rows[item.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				}
				int num2 = dg.Rows.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					int num3 = 0;
					do
					{
						if (Operators.ConditionalCompareObjectEqual(dg.Rows[j].Cells[num3].Value, null, TextCompare: true) && !Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(dg.Rows[j].Cells[num3].Value)))
						{
							dg.Rows[j].Cells[num3].Value = "";
						}
						num3++;
					}
					while (num3 <= 9);
				}
				AtualizaColunasDGModelos(ref dg);
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

	public static void AtualizaColunasDGModelos(ref DataGridView dg)
	{
		checked
		{
			if (dg.RowCount != 0)
			{
				int num = (int)Math.Round((double)dg.Height / 23.0);
				double num2 = ((dg.RowCount < num) ? ((double)(dg.Width - 4)) : ((double)(dg.Width - 21)));
				dg.Columns[0].Width = (int)Math.Round(num2 * 0.05);
				dg.Columns[1].Width = (int)Math.Round(num2 * 0.13);
				dg.Columns[2].Width = (int)Math.Round(num2 * 0.09);
				dg.Columns[3].Width = (int)Math.Round(num2 * 0.09);
				dg.Columns[4].Width = 0;
				dg.Columns[5].Width = (int)Math.Round(num2 * 0.19);
				dg.Columns[6].Width = (int)Math.Round(num2 * 0.19);
				dg.Columns[7].Width = 0;
				dg.Columns[8].Width = 0;
				dg.Columns[9].Width = (int)Math.Round(num2 * 0.13);
				dg.Columns[10].Width = (int)Math.Round(num2 * 0.13);
				dg.Columns[0].Visible = true;
				dg.Columns[1].Visible = true;
				dg.Columns[2].Visible = true;
				dg.Columns[3].Visible = true;
				dg.Columns[4].Visible = false;
				dg.Columns[5].Visible = true;
				dg.Columns[6].Visible = true;
				dg.Columns[7].Visible = false;
				dg.Columns[8].Visible = false;
				dg.Columns[9].Visible = true;
				dg.Columns[10].Visible = true;
				dg.Columns[0].ReadOnly = false;
				dg.Columns[1].ReadOnly = false;
				dg.Columns[2].ReadOnly = false;
				dg.Columns[3].ReadOnly = false;
				dg.Columns[4].ReadOnly = false;
				dg.Columns[5].ReadOnly = false;
				dg.Columns[6].ReadOnly = false;
				dg.Columns[7].ReadOnly = false;
				dg.Columns[8].ReadOnly = false;
				dg.Columns[9].ReadOnly = false;
				dg.Columns[10].ReadOnly = false;
				dg.MultiSelect = false;
			}
		}
	}

	public static void AtualizaOsDispositivosPrincipais(int iIndexModelo, string sNome, string sTerm, string sTopo, string sLayout, int iLm1, int iLm2)
	{
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Expected Obj, but got Unknown
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected Obj, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected Obj, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected Obj, but got Unknown
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
			BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
			BlockTableRecordEnumerator enumerator = default;
			try
			{
				enumerator = val3.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ObjectId current = enumerator.Current;
					Entity ent = (Entity)val.GetObject(current, (OpenMode)0);
					string tipoImportado = "";
					string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
					if (Operators.CompareString(left, "P", TextCompare: true) != 0)
					{
						continue;
					}
					BlockReference blockRef = (BlockReference)ent;
					object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
					ent = (Entity)(object)blockRef;
					DeclaracoesEntidades.StructureDispositivo disp = ((obj == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj));
					if (iIndexModelo != disp.indexModelo)
					{
						continue;
					}
					BlockReference blockRef2 = (BlockReference)(object)((ent is BlockReference) ? ent : null);
					if (blockRef2 != null)
					{
						_ = ObjectId.Null;
						string name = blockRef2.Name;
						if (((SymbolTable)val2).Has(name))
						{
							BlockTableRecord val4 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[name], (OpenMode)0);
							_ = ((DBObject)val4).Id;
						}
						disp.Topografico = sTopo;
						disp.Layout = sLayout;
						disp.iLM1 = iLm1;
						disp.iLM2 = iLm2;
						XDataDispositivosMaster.GravarXDataDispPrincipal(ref blockRef2, ref disp);
						if (!disp.Complementar)
						{
							AtualizaOsTerminaisDaBobina(((DBObject)blockRef2).ObjectId, name, iIndexModelo, sTerm);
						}
						tipoImportado = ((object)((DBObject)blockRef2).Handle/*cast due to constrained. prefix*/).ToString();
						clsBlocos.PreencheOsNomesDeUmBloco(ref tipoImportado, disp.Nome1, disp.Nome2, disp.Alternativo);
						hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
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
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError((Exception)ex);
			val.Abort();
			ProjectData.ClearProjectError();
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void AtualizaOsTerminaisDaBobina(ObjectId BlockID, string sNomeBloco, int iIndex, string sTerm)
	{
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected Obj, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected Obj, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected Obj, but got Unknown
		sTerm += ";;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;";
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		if (BlockID.IsNull)
		{
			return;
		}
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockReference val3 = (BlockReference)val2.GetObject(BlockID, (OpenMode)0);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(val3.BlockTableRecord, (OpenMode)0);
					if (string.Compare(((SymbolTableRecord)val4).Name, sNomeBloco, ignoreCase: true) == 0)
					{
						AttributeCollection attributeCollection = val3.AttributeCollection;
						foreach (object item in attributeCollection)
						{
							ObjectId val5 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							AttributeReference val6 = (AttributeReference)val5.GetObject((OpenMode)1);
							string text = ((DBText)val6).TextString;
							string text2 = Strings.Mid(val6.Tag, 2, Strings.Len(val6.Tag));
							int num = 1;
							if ((Operators.CompareString(Strings.Mid(val6.Tag, 1, 1), "T", TextCompare: true) == 0) & Versioned.IsNumeric(text2))
							{
								text = "";
								int num2 = Strings.Len(sTerm);
								for (int i = 1; i <= num2; i++)
								{
									string text3 = Strings.Mid(sTerm, i, 1);
									if (Operators.CompareString(text3, ";", TextCompare: true) != 0)
									{
										text += text3;
										continue;
									}
									if (Conversions.ToDouble(text2) == (double)num)
									{
										break;
									}
									text = "";
									num++;
								}
							}
							((DBText)val6).TextString = text;
							((Entity)val6).Draw();
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

	public static void AtualizaOsModelosDosPrincipais(int iIndexModelo, string sNomeModelo)
	{
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected Obj, but got Unknown
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected Obj, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
			BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
			BlockTableRecordEnumerator enumerator = default;
			try
			{
				enumerator = val3.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ObjectId current = enumerator.Current;
					Entity Ent = (Entity)val.GetObject(current, (OpenMode)0);
					Declaracoes2.StructureModelo Modelo = default;
					if (!XDataDispositivosMaster.LerXDataModelo(ref Ent, ref Modelo) || !((Modelo.indexModelo == iIndexModelo) & (Modelo.indexContato == 0)))
					{
						continue;
					}
					BlockReference val4 = (BlockReference)(object)((Ent is BlockReference) ? Ent : null);
					if (val4 != null)
					{
						_ = ObjectId.Null;
						string name = val4.Name;
						if (((SymbolTable)val2).Has(name))
						{
							string sHandle = ((object)((DBObject)Ent).Handle/*cast due to constrained. prefix*/).ToString();
							clsBlocos.EditaUmAtributoDeUmBloco(ref sHandle, "MODELO", sNomeModelo);
						}
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
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError((Exception)ex);
			val.Abort();
			ProjectData.ClearProjectError();
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static string ModeloBobina(ref List<string> lHandlesOcultos)
	{
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected Obj, but got Unknown
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
		bool flag = false;
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
						Declaracoes2.StructureModelo Modelo = default;
						if (XDataDispositivosMaster.LerXDataModelo(ref Ent, ref Modelo) && Modelo.indexContato == 0 && !Ent.Visible)
						{
							lHandlesOcultos.Add(Modelo.HandleBob);
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
		return Conversions.ToString(flag);
	}

	public static string OcultaModeloBobinaEditada(ref List<string> lHandlesOcultos)
	{
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected Obj, but got Unknown
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
		bool flag = false;
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
						Declaracoes2.StructureModelo Modelo = default;
						if (XDataDispositivosMaster.LerXDataModelo(ref Ent, ref Modelo) && Modelo.indexContato == 0 && lHandlesOcultos.Contains(Modelo.HandleBob))
						{
							((DBObject)Ent).UpgradeOpen();
							Ent.Visible = false;
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
		return Conversions.ToString(flag);
	}

	public static void AtualizaColunasDGContatosInseridos(ref DataGridView ContatosInseridos)
	{
		checked
		{
			if (ContatosInseridos.RowCount != 0)
			{
				int num = (int)Math.Round((double)ContatosInseridos.Height / 23.0);
				double num2 = ((ContatosInseridos.RowCount < num) ? ((double)(ContatosInseridos.Width - 4)) : ((double)(ContatosInseridos.Width - 21)));
				ContatosInseridos.Columns[0].Visible = true;
				ContatosInseridos.Columns[1].Visible = true;
				ContatosInseridos.Columns[2].Visible = true;
				ContatosInseridos.Columns[3].Visible = false;
				ContatosInseridos.Columns[0].ReadOnly = false;
				ContatosInseridos.Columns[1].ReadOnly = false;
				ContatosInseridos.Columns[2].ReadOnly = false;
				ContatosInseridos.Columns[3].ReadOnly = false;
				ContatosInseridos.Columns[0].Width = (int)Math.Round(num2 * 0.375);
				ContatosInseridos.Columns[1].Width = (int)Math.Round(num2 * 0.15);
				ContatosInseridos.Columns[2].Width = (int)Math.Round(num2 * 0.475);
				ContatosInseridos.Columns[3].Width = 0;
			}
			else
			{
				ContatosInseridos.Rows.Clear();
				ContatosInseridos.Columns.Clear();
			}
		}
	}

	public static void ReInsereContatosModelo(Declaracoes2.StructureContatosAuxiliares[] mContatos, int indexModelo)
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Expected Obj, but got Unknown
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected Obj, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected Obj, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected Obj, but got Unknown
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected Obj, but got Unknown
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		string sNorma = "IEC";
		if (DeclaracoesGeral.Conf.Norma == 1)
		{
			sNorma = "ANSI";
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
							Entity Ent = (Entity)val2.GetObject(current, (OpenMode)0);
							Declaracoes2.StructureModelo Modelo = default;
							if (XDataDispositivosMaster.LerXDataModelo(ref Ent, ref Modelo) && Modelo.indexModelo == indexModelo && Modelo.indexContato == 0)
							{
								BlockReference blockRefAnterior = (BlockReference)val2.GetObject(current, (OpenMode)0);
								Point3d position = blockRefAnterior.Position;
								double x = position.X;
								position = blockRefAnterior.Position;
								Point3d pt = new Point3d(x, position.Y, 0.0);
								Declaracoes2.dDistanciaModelo0 = clsDispositivoAuxiliares.BuscaAlturaDoModelo(Modelo.HandleBob);
								double dDistanciaModelo = Declaracoes2.dDistanciaModelo0;
								InsereOsContatosAuxiliaresModelo(pt, sNorma, ref blockRefAnterior, Modelo, mContatos, Ent.Layer, dDistanciaModelo);
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
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
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
		catch (Exception ex2)
		{
			ProjectData.SetProjectError((Exception)ex2);
			throw;
		}
		finally
		{
		}
	}

	public static int BuscaPainelDoDispPrincipal(string sHandleDaEntity)
	{
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected Obj, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected Obj, but got Unknown
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected Obj, but got Unknown
		int result = 0;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		_ = Application.DocumentManager.MdiActiveDocument.Editor;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			ObjectId val2 = Geral.HandleToID(sHandleDaEntity);
			if (val2.IsValid)
			{
				Entity val3 = (Entity)val.GetObject(val2, (OpenMode)0);
				try
				{
					Entity ent = val3;
					string tipoImportado = "";
					string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
					if (Operators.CompareString(left, "P", TextCompare: true) == 0)
					{
						BlockReference blockRef = (BlockReference)val3;
						object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
						result = ((obj == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj)).Painel;
					}
				}
				finally
				{
					((IDisposable)val3)?.Dispose();
				}
			}
			DeclaracoesGeral.bAnularEventos = true;
			val.Commit();
			DeclaracoesGeral.bAnularEventos = false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError((Exception)ex);
			val.Abort();
			ProjectData.ClearProjectError();
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		return result;
	}

	public static int verificaExisteNomeDispositivo(int iPn, string Nome1, string Nome2, string Alternativo, ref string handle, ref string tipo)
	{
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		//IL_0379: Expected Obj, but got Unknown
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
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected Obj, but got Unknown
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Expected Obj, but got Unknown
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0330: Unknown result type (might be due to invalid IL or missing references)
		//IL_0335: Unknown result type (might be due to invalid IL or missing references)
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
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
						BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
						if (val6 == null || Information.IsDBNull(val6))
						{
							continue;
						}
						Entity ent = (Entity)(object)val6;
						string tipoImportado = "";
						string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
						val6 = (BlockReference)ent;
						string text2 = text;
						if (Operators.CompareString(text2, "P", TextCompare: true) != 0)
						{
							if (Operators.CompareString(text2, "M", TextCompare: true) != 0)
							{
								continue;
							}
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val6);
							DeclaracoesEntidades.StructureMascara structureMascara = ((obj == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj));
							if (structureMascara.Complementar || !((structureMascara.Painel == iPn) & (Operators.CompareString(handle, ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString(), TextCompare: true) != 0)))
							{
								continue;
							}
							if (!((Operators.CompareString(structureMascara.Nome1.Trim(), Nome1.Trim(), TextCompare: true) == 0) & (Operators.CompareString(structureMascara.Nome2.Trim(), Nome2.Trim(), TextCompare: true) == 0)))
							{
								if ((Operators.CompareString(structureMascara.Alternativo.Trim(), "", TextCompare: true) != 0) & (Operators.CompareString(structureMascara.Alternativo.Trim(), Alternativo.Trim(), TextCompare: true) == 0))
								{
									num = 3;
								}
							}
							else
							{
								num = 1;
								if (Operators.CompareString(structureMascara.Alternativo.Trim(), Alternativo.Trim(), TextCompare: true) == 0)
								{
									num = 2;
									handle = ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString();
								}
							}
							tipo = text2;
							if (num > 0)
							{
								break;
							}
							continue;
						}
						BlockReference blockRef = (BlockReference)val5;
						object obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
						val5 = (Entity)(object)blockRef;
						DeclaracoesEntidades.StructureDispositivo structureDispositivo = ((obj2 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj2));
						if (structureDispositivo.Complementar || !((structureDispositivo.Painel == iPn) & (Operators.CompareString(handle, ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString(), TextCompare: true) != 0)))
						{
							continue;
						}
						if (!((Operators.CompareString(structureDispositivo.Nome1.Trim(), Nome1.Trim(), TextCompare: true) == 0) & (Operators.CompareString(structureDispositivo.Nome2.Trim(), Nome2.Trim(), TextCompare: true) == 0)))
						{
							if ((Operators.CompareString(structureDispositivo.Alternativo.Trim(), "", TextCompare: true) != 0) & (Operators.CompareString(structureDispositivo.Alternativo.Trim(), Alternativo.Trim(), TextCompare: true) == 0))
							{
								num = 3;
							}
						}
						else
						{
							num = 1;
							if (Operators.CompareString(structureDispositivo.Alternativo.Trim(), Alternativo.Trim(), TextCompare: true) == 0)
							{
								num = 2;
							}
						}
						tipo = text2;
						if (num > 0)
						{
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
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
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
		return num;
	}

	public static object TrocaPainel(string TipoSelec, DeclaracoesEntidades.StructureDispositivo Disp, DeclaracoesEntidades.StructureMascara Masc, int iPainelAntigo, int iNovoPainelSel)
	{
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Expected Obj, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected Obj, but got Unknown
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected Obj, but got Unknown
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Expected Obj, but got Unknown
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected Obj, but got Unknown
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Expected Obj, but got Unknown
		bool flag = false;
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
							Entity ent = (Entity)val2.GetObject(current, (OpenMode)0);
							if (Information.IsDBNull(ent))
							{
								continue;
							}
							string tipoImportado = "";
							string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
							if ((Operators.CompareString(left, "P", TextCompare: true) == 0) & (Operators.CompareString(TipoSelec, "P", TextCompare: true) == 0))
							{
								BlockReference blockRef = (BlockReference)ent;
								object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
								ent = (Entity)(object)blockRef;
								object obj2 = obj;
								DeclaracoesEntidades.StructureDispositivo disp = ((obj2 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj2));
								if (disp.Painel == iPainelAntigo && ((Operators.CompareString(disp.Nome1.Trim(), Disp.Nome1.Trim(), TextCompare: true) == 0) & (Operators.CompareString(disp.Nome2.Trim(), Disp.Nome2.Trim(), TextCompare: true) == 0) & (Operators.CompareString(disp.Alternativo, Disp.Alternativo, TextCompare: true) == 0)))
								{
									disp.Painel = (short)iNovoPainelSel;
									blockRef = (BlockReference)ent;
									XDataDispositivosMaster.GravarXDataDispPrincipal(ref blockRef, ref disp);
									ent = (Entity)(object)blockRef;
								}
							}
							if ((Operators.CompareString(left, "M", TextCompare: true) == 0) & (Operators.CompareString(TipoSelec, "M", TextCompare: true) == 0))
							{
								BlockReference blockRef = (BlockReference)ent;
								object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
								ent = (Entity)(object)blockRef;
								object obj3 = obj;
								DeclaracoesEntidades.StructureMascara Masc2 = ((obj3 == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj3));
								if (Masc2.Painel == iPainelAntigo && ((Operators.CompareString(Masc2.Nome1.Trim(), Masc.Nome1.Trim(), TextCompare: true) == 0) & (Operators.CompareString(Masc2.Nome2.Trim(), Masc.Nome2.Trim(), TextCompare: true) == 0) & (Operators.CompareString(Masc2.Alternativo, Masc.Alternativo, TextCompare: true) == 0)))
								{
									Masc2.Painel = (short)iNovoPainelSel;
									XDataDispositivosMaster.GravarXDataMascara(ref ent, ref Masc2);
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
			return flag;
		}
	}

	public static void EditaNomeDoDispositivoPrincipal(ref Declaracoes2.MDispPrincipal myBL, string sNome1, string sNome2, string sAlternativo, bool bNomeVisivel, bool bAlternativoVisivel, string sHandleSel)
	{
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Expected Obj, but got Unknown
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
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected Obj, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Expected Obj, but got Unknown
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
						if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado), "P", TextCompare: true) != 0)
						{
							continue;
						}
						BlockReference blockRef = (BlockReference)ent;
						object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
						ent = (Entity)(object)blockRef;
						DeclaracoesEntidades.StructureDispositivo disp = ((obj == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj));
						if ((Operators.CompareString(myBL.sNome1, disp.Nome1, TextCompare: true) == 0) & (Operators.CompareString(myBL.sNome2, disp.Nome2, TextCompare: true) == 0) & (Operators.CompareString(myBL.sAlternativo, disp.Alternativo, TextCompare: true) == 0) & (myBL.iPainel == disp.Painel))
						{
							disp.Nome1 = sNome1;
							disp.Nome2 = sNome2;
							disp.Alternativo = sAlternativo;
							tipoImportado = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
							clsBlocos.EditaNomesDeUmBloco(ref tipoImportado, sNome1, sNome2, sAlternativo, myBL.sTerminais, bNomeVisivel, bAlternativoVisivel);
							if (Operators.CompareString(((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString(), sHandleSel, TextCompare: true) == 0)
							{
								tipoImportado = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
								clsBlocos.EditaTerminaisDeUmBloco(ref tipoImportado, myBL.sTerminais);
							}
							disp.iLM1 = myBL.LM1;
							disp.iLM2 = myBL.LM2;
							disp.Topografico = myBL.sTopografico;
							disp.Layout = myBL.sLayout;
							blockRef = (BlockReference)ent;
							XDataDispositivosMaster.GravarXDataDispPrincipal(ref blockRef, ref disp);
							ent = (Entity)(object)blockRef;
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

	public static void EditaLMDoDispositivo(object[,] mLM)
	{
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Expected Obj, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected Obj, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected Obj, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Expected Obj, but got Unknown
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected Obj, but got Unknown
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		cDadosLM cDadosLM2 = new cDadosLM();
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			_ = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				try
				{
					int num = Information.UBound(mLM, 2);
					for (int i = 1; i <= num; i = checked(i + 1))
					{
						Entity ent = (Entity)Geral.HandleToObject(Conversions.ToString(mLM[2, i]));
						if (ent == null)
						{
							continue;
						}
						string tipoImportado = "";
						string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
						if (Operators.CompareString(left, "P", TextCompare: true) == 0)
						{
							BlockReference blockRef = (BlockReference)ent;
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
							ent = (Entity)(object)blockRef;
							object obj2 = obj;
							DeclaracoesEntidades.StructureDispositivo disp = ((obj2 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj2));
							if (disp.iLM1 != Conversions.ToInteger(mLM[1, i]))
							{
								disp.iLM1 = Conversions.ToInteger(mLM[1, i]);
								blockRef = (BlockReference)ent;
								XDataDispositivosMaster.GravarXDataDispPrincipal(ref blockRef, ref disp);
								ent = (Entity)(object)blockRef;
							}
							string text = "";
							DeclaracoesEntidades.StructureDispositivo structureDispositivo = default;
							blockRef = (BlockReference)ent;
							obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
							ent = (Entity)(object)blockRef;
							object obj3 = obj;
							structureDispositivo = ((obj3 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj3));
							ref int iLM = ref structureDispositivo.iLM1;
							tipoImportado = Conversions.ToString(iLM);
							string text2 = cDadosLM2.BuscaFabricanteDoMaterial(ref tipoImportado);
							iLM = Conversions.ToInteger(tipoImportado);
							text = text2;
							text = clsTextos.TiraNothing(text);
							tipoImportado = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
							clsBlocos.AtualizaValorDeUmAtributo(ref tipoImportado, "MODELO", "");
							tipoImportado = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
							clsBlocos.AtualizaValorDeUmAtributo(ref tipoImportado, "PAINEL", Dicionario.BuscaNomeDoPainel(structureDispositivo.Painel));
							tipoImportado = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
							clsBlocos.AtualizaValorDeUmAtributo(ref tipoImportado, "FABRICANTE", text);
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
	}

	public static void EditaContatos(Declaracoes2.StructureContatosAuxiliares[] mContatos, int indexModelo, int index)
	{
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Expected Obj, but got Unknown
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
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected Obj, but got Unknown
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
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
							if (!flag || !((Modelo.indexModelo == indexModelo) & (Modelo.indexContato == index)))
							{
								continue;
							}
							int num = Information.UBound(mContatos);
							for (int i = 1; i <= num; i = checked(i + 1))
							{
								if (mContatos[i].iIndice == index)
								{
									string sHandle = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
									clsBlocos.AtualizaValorDeUmAtributo(ref sHandle, "T1", mContatos[index].sT1);
									sHandle = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
									clsBlocos.AtualizaValorDeUmAtributo(ref sHandle, "T2", mContatos[index].sT2);
									sHandle = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
									clsBlocos.AtualizaValorDeUmAtributo(ref sHandle, "T3", mContatos[index].sT3);
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
				catch (Exception ex)
				{
					ProjectData.SetProjectError((Exception)ex);
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

	public static void pesquisaDispositivosPeMnoDWG(ref mBlocosPrincipal[] mDispositivos)
	{
		//IL_0763: Unknown result type (might be due to invalid IL or missing references)
		//IL_0769: Expected Obj, but got Unknown
		//IL_078c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0792: Expected Obj, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected Obj, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected Obj, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected Obj, but got Unknown
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected Obj, but got Unknown
		//IL_0333: Unknown result type (might be due to invalid IL or missing references)
		//IL_0338: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		mDispositivos = new mBlocosPrincipal[1];
		num = 1;
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
						DeclaracoesGeral._uscPagina.Quantidade = clsBlocos.AcadObjectCount();
						DeclaracoesGeral._uscPagina.pbIniciar();
						int num2 = 0;
						BlockTableRecordEnumerator enumerator = default;
						try
						{
							enumerator = val4.GetEnumerator();
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.Current;
								Entity ent = (Entity)val2.GetObject(current, (OpenMode)0);
								BlockReference blockRef = (BlockReference)(object)((ent is BlockReference) ? ent : null);
								if (blockRef != null)
								{
									string tipoImportado = "";
									string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
									string left = text;
									if (Operators.CompareString(left, "P", TextCompare: true) != 0)
									{
										if (Operators.CompareString(left, "M", TextCompare: true) == 0)
										{
											BlockReference blockRef2 = (BlockReference)ent;
											object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef2);
											ent = (Entity)(object)blockRef2;
											DeclaracoesEntidades.StructureMascara structureMascara = ((obj == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj));
											mDispositivos = (mBlocosPrincipal[])Utils.CopyArray(mDispositivos, new mBlocosPrincipal[num + 1]);
											mDispositivos[num].sNome1 = clsTextos.TiraNothing(structureMascara.Nome1);
											mDispositivos[num].sNome2 = clsTextos.TiraNothing(structureMascara.Nome2);
											mDispositivos[num].sAlternativo = clsTextos.TiraNothing(structureMascara.Alternativo);
											mDispositivos[num].iPainel = structureMascara.Painel;
											mDispositivos[num].sPainel = Dicionario.BuscaNomeDoPainel(structureMascara.Painel);
											mDispositivos[num].iOrdem = 2;
											mDispositivos[num].sTipo = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 524]);
											mDispositivos[num].bComplementar = structureMascara.Complementar;
											mDispositivos[num].sHandle = ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString();
											num++;
										}
									}
									else
									{
										object obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
										DeclaracoesEntidades.StructureDispositivo structureDispositivo = ((obj2 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj2));
										mDispositivos = (mBlocosPrincipal[])Utils.CopyArray(mDispositivos, new mBlocosPrincipal[num + 1]);
										mDispositivos[num].sNome1 = clsTextos.TiraNothing(structureDispositivo.Nome1);
										mDispositivos[num].sNome2 = clsTextos.TiraNothing(structureDispositivo.Nome2);
										mDispositivos[num].sAlternativo = clsTextos.TiraNothing(structureDispositivo.Alternativo);
										mDispositivos[num].iPainel = structureDispositivo.Painel;
										mDispositivos[num].sPainel = Dicionario.BuscaNomeDoPainel(structureDispositivo.Painel);
										mDispositivos[num].iOrdem = 1;
										mDispositivos[num].sTipo = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 804]);
										mDispositivos[num].bComplementar = structureDispositivo.Complementar;
										mDispositivos[num].sHandle = ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString();
										num++;
									}
								}
								num2++;
								if (num2 == 100)
								{
									DeclaracoesGeral._uscPagina.pbPasso(num2);
									num2 = 0;
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
						if (Information.UBound(mDispositivos) >= 2)
						{
							int num3 = Information.UBound(mDispositivos);
							for (int i = 1; i <= num3; i++)
							{
								int num4 = Information.UBound(mDispositivos) - 1;
								int num5 = i;
								for (int j = num4; j >= num5; j += -1)
								{
									if (mDispositivos[j].iPainel > mDispositivos[j + 1].iPainel)
									{
										mBlocosPrincipal mBlocosPrincipal2 = mDispositivos[j + 1];
										mDispositivos[j + 1] = mDispositivos[j];
										mDispositivos[j] = mBlocosPrincipal2;
									}
									if (mDispositivos[j].iPainel == mDispositivos[j + 1].iPainel && Operators.CompareString(mDispositivos[j].sNome1, mDispositivos[j + 1].sNome1, TextCompare: true) > 0)
									{
										mBlocosPrincipal mBlocosPrincipal2 = mDispositivos[j + 1];
										mDispositivos[j + 1] = mDispositivos[j];
										mDispositivos[j] = mBlocosPrincipal2;
									}
									if (mDispositivos[j].iPainel == mDispositivos[j + 1].iPainel && Operators.CompareString(mDispositivos[j].sNome1, mDispositivos[j + 1].sNome1, TextCompare: true) == 0 && Operators.CompareString(mDispositivos[j].sNome2, mDispositivos[j + 1].sNome2, TextCompare: true) > 0)
									{
										mBlocosPrincipal mBlocosPrincipal2 = mDispositivos[j + 1];
										mDispositivos[j + 1] = mDispositivos[j];
										mDispositivos[j] = mBlocosPrincipal2;
									}
									if (mDispositivos[j].iPainel == mDispositivos[j + 1].iPainel && Operators.CompareString(mDispositivos[j].sNome1, mDispositivos[j + 1].sNome1, TextCompare: true) == 0 && Operators.CompareString(mDispositivos[j].sNome2, mDispositivos[j + 1].sNome2, TextCompare: true) == 0 && Operators.CompareString(mDispositivos[j].sAlternativo, mDispositivos[j + 1].sAlternativo, TextCompare: true) > 0)
									{
										mBlocosPrincipal mBlocosPrincipal2 = mDispositivos[j + 1];
										mDispositivos[j + 1] = mDispositivos[j];
										mDispositivos[j] = mBlocosPrincipal2;
									}
									if (mDispositivos[j].iPainel == mDispositivos[j + 1].iPainel && Operators.CompareString(mDispositivos[j].sNome1, mDispositivos[j + 1].sNome1, TextCompare: true) == 0 && Operators.CompareString(mDispositivos[j].sNome2, mDispositivos[j + 1].sNome2, TextCompare: true) == 0 && Operators.CompareString(mDispositivos[j].sAlternativo, mDispositivos[j + 1].sAlternativo, TextCompare: true) == 0 && Operators.CompareString(mDispositivos[j].sTipo, mDispositivos[j + 1].sTipo, TextCompare: true) > 0)
									{
										mBlocosPrincipal mBlocosPrincipal2 = mDispositivos[j + 1];
										mDispositivos[j + 1] = mDispositivos[j];
										mDispositivos[j] = mBlocosPrincipal2;
									}
								}
							}
						}
						DeclaracoesGeral._uscPagina.pbFim();
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError((Exception)ex);
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
			catch (Exception ex2)
			{
				ProjectData.SetProjectError((Exception)ex2);
				throw;
			}
		}
	}

	public static void pesquisaDispositivosTerminais(ref mBlocosPrincipal[] mDispositivos, ref List<int> lLM)
	{
		//IL_0945: Unknown result type (might be due to invalid IL or missing references)
		//IL_094b: Expected Obj, but got Unknown
		//IL_096e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0974: Expected Obj, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected Obj, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected Obj, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected Obj, but got Unknown
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		mDispositivos = new mBlocosPrincipal[1];
		num = 1;
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
						DeclaracoesGeral._uscPagina.Quantidade = clsBlocos.AcadObjectCount();
						DeclaracoesGeral._uscPagina.pbIniciar();
						int num2 = 0;
						BlockTableRecordEnumerator enumerator = default;
						try
						{
							enumerator = val4.GetEnumerator();
							while (enumerator.MoveNext())
							{
								ObjectId ObjectId = enumerator.Current;
								Entity ent = (Entity)val2.GetObject(ObjectId, (OpenMode)0);
								BlockReference blockRef = (BlockReference)(object)((ent is BlockReference) ? ent : null);
								if (blockRef != null)
								{
									string tipoImportado = "";
									string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
									string left = text;
									if (Operators.CompareString(left, "P", TextCompare: true) == 0)
									{
										object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
										DeclaracoesEntidades.StructureDispositivo structureDispositivo = ((obj == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj));
										if (structureDispositivo.indexModelo == 0)
										{
											mDispositivos = (mBlocosPrincipal[])Utils.CopyArray(mDispositivos, new mBlocosPrincipal[num + 1]);
											mDispositivos[num].sNome1 = clsTextos.TiraNothing(structureDispositivo.Nome1);
											mDispositivos[num].sNome2 = clsTextos.TiraNothing(structureDispositivo.Nome2);
											mDispositivos[num].sAlternativo = clsTextos.TiraNothing(structureDispositivo.Alternativo);
											mDispositivos[num].iPainel = structureDispositivo.Painel;
											mDispositivos[num].sPainel = Dicionario.BuscaNomeDoPainel(structureDispositivo.Painel);
											mDispositivos[num].iOrdem = 1;
											mDispositivos[num].iLM = structureDispositivo.iLM1;
											if (!lLM.Contains(structureDispositivo.iLM1))
											{
												lLM.Add(structureDispositivo.iLM1);
											}
											mDispositivos[num].sTipo = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 804]);
											mDispositivos[num].bComplementar = structureDispositivo.Complementar;
											mDispositivos[num].sHandle = ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString();
											string[,] array = null;
											array = new string[2, 1];
											clsAtributos.LeTodosOsAtributosDeUmBloco(ref ObjectId, ref array);
											if (Information.UBound(array, 2) >= 2)
											{
												int num3 = Information.UBound(array, 2);
												for (int i = 1; i <= num3; i++)
												{
													int num4 = Information.UBound(array, 2) - 1;
													int num5 = i;
													for (int j = num4; j >= num5; j += -1)
													{
														if (Operators.CompareString(array[0, j], array[0, j + 1], TextCompare: true) > 0)
														{
															string text2 = array[0, j];
															string text3 = array[1, j];
															array[0, j] = array[0, j + 1];
															array[1, j] = array[1, j + 1];
															array[0, j + 1] = text2;
															array[1, j + 1] = text3;
														}
													}
												}
											}
											mDispositivos[num].sTerminais = "";
											mDispositivos[num].iQuantTerminais = 0;
											int num6 = Information.UBound(array, 2);
											for (int k = 1; k <= num6; k++)
											{
												string text4 = array[0, k];
												string expression = Strings.Mid(text4, 2, Strings.Len(text4));
												if ((Operators.CompareString(Strings.Mid(text4, 1, 1), "T", TextCompare: true) == 0) & Versioned.IsNumeric(expression))
												{
													mDispositivos[num].iQuantTerminais++;
													if (Operators.CompareString(mDispositivos[num].sTerminais, "", TextCompare: true) != 0)
													{
														ref string sTerminais = ref mDispositivos[num].sTerminais;
														sTerminais = sTerminais + "; " + array[1, k];
													}
													else
													{
														mDispositivos[num].sTerminais = array[1, k];
													}
												}
											}
											num++;
										}
									}
								}
								num2++;
								if (num2 == 100)
								{
									DeclaracoesGeral._uscPagina.pbPasso(num2);
									num2 = 0;
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
						if (Information.UBound(mDispositivos) >= 2)
						{
							int num7 = Information.UBound(mDispositivos);
							for (int l = 1; l <= num7; l++)
							{
								int num8 = Information.UBound(mDispositivos) - 1;
								int num9 = l;
								for (int m = num8; m >= num9; m += -1)
								{
									if (mDispositivos[m].iPainel > mDispositivos[m + 1].iPainel)
									{
										mBlocosPrincipal mBlocosPrincipal2 = mDispositivos[m + 1];
										mDispositivos[m + 1] = mDispositivos[m];
										mDispositivos[m] = mBlocosPrincipal2;
									}
									if (mDispositivos[m].iPainel == mDispositivos[m + 1].iPainel && Operators.CompareString(mDispositivos[m].sNome1, mDispositivos[m + 1].sNome1, TextCompare: true) > 0)
									{
										mBlocosPrincipal mBlocosPrincipal2 = mDispositivos[m + 1];
										mDispositivos[m + 1] = mDispositivos[m];
										mDispositivos[m] = mBlocosPrincipal2;
									}
									if (mDispositivos[m].iPainel == mDispositivos[m + 1].iPainel && Operators.CompareString(mDispositivos[m].sNome1, mDispositivos[m + 1].sNome1, TextCompare: true) == 0 && Operators.CompareString(mDispositivos[m].sNome2, mDispositivos[m + 1].sNome2, TextCompare: true) > 0)
									{
										mBlocosPrincipal mBlocosPrincipal2 = mDispositivos[m + 1];
										mDispositivos[m + 1] = mDispositivos[m];
										mDispositivos[m] = mBlocosPrincipal2;
									}
									if (mDispositivos[m].iPainel == mDispositivos[m + 1].iPainel && Operators.CompareString(mDispositivos[m].sNome1, mDispositivos[m + 1].sNome1, TextCompare: true) == 0 && Operators.CompareString(mDispositivos[m].sNome2, mDispositivos[m + 1].sNome2, TextCompare: true) == 0 && Operators.CompareString(mDispositivos[m].sAlternativo, mDispositivos[m + 1].sAlternativo, TextCompare: true) > 0)
									{
										mBlocosPrincipal mBlocosPrincipal2 = mDispositivos[m + 1];
										mDispositivos[m + 1] = mDispositivos[m];
										mDispositivos[m] = mBlocosPrincipal2;
									}
									if (mDispositivos[m].iPainel == mDispositivos[m + 1].iPainel && Operators.CompareString(mDispositivos[m].sNome1, mDispositivos[m + 1].sNome1, TextCompare: true) == 0 && Operators.CompareString(mDispositivos[m].sNome2, mDispositivos[m + 1].sNome2, TextCompare: true) == 0 && Operators.CompareString(mDispositivos[m].sAlternativo, mDispositivos[m + 1].sAlternativo, TextCompare: true) == 0 && Operators.CompareString(mDispositivos[m].sTipo, mDispositivos[m + 1].sTipo, TextCompare: true) > 0)
									{
										mBlocosPrincipal mBlocosPrincipal2 = mDispositivos[m + 1];
										mDispositivos[m + 1] = mDispositivos[m];
										mDispositivos[m] = mBlocosPrincipal2;
									}
								}
							}
						}
						DeclaracoesGeral._uscPagina.pbFim();
						int num10 = Information.UBound(mDispositivos);
						for (int n = 1; n <= num10; n++)
						{
							if (mDispositivos[n].bComplementar)
							{
								continue;
							}
							int iPainel = mDispositivos[n].iPainel;
							string sNome = mDispositivos[n].sNome1;
							string sNome2 = mDispositivos[n].sNome2;
							int num11 = Information.UBound(mDispositivos);
							for (int num12 = 1; num12 <= num11; num12++)
							{
								if (mDispositivos[num12].iPainel == iPainel && mDispositivos[num12].bComplementar && Operators.CompareString(mDispositivos[num12].sNome1, sNome, TextCompare: true) == 0 && Operators.CompareString(mDispositivos[num12].sNome2, sNome2, TextCompare: true) == 0)
								{
									mDispositivos[num12].iLM = mDispositivos[n].iLM;
								}
							}
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError((Exception)ex);
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
			catch (Exception ex2)
			{
				ProjectData.SetProjectError((Exception)ex2);
				throw;
			}
		}
	}

	public static void editaUmBlocoDispositivoPrincipal(string sHandle, int iPN, string sNome1, string sNome2, string sAlternativo)
	{
		EditaApenasOsNomeDoDispositivoPrincipal(sHandle, sNome1, sNome2, sAlternativo);
		clsDispositivoAuxiliares.EditaNomeDoModeloDosDispositivos(sHandle, sNome1, sNome2, sAlternativo);
		clsDispositivoAuxiliares.EditaNomeDoContatoAuxiliarDispositivos(sHandle, sNome1, sNome2, sAlternativo);
		string text = sNome1;
		if (Operators.CompareString(sNome2.Trim(), "", TextCompare: true) != 0)
		{
			text = text + "/" + sNome2;
		}
		string text2 = sNome1;
		if (Operators.CompareString(sNome2, "", TextCompare: true) != 0)
		{
			text2 = text2 + "/" + sNome2;
		}
		clsLayoutMec.EditaNomeAlternativoLayoutMec(iPN, text, text2, sAlternativo);
		clsDispositivoTacito.editaLayoutRapido(Conversions.ToString(iPN), text, text2, sAlternativo);
	}

	public static void EditaApenasOsNomeDoDispositivoPrincipal(string shandle, string sNome1, string sNome2, string sAlternativo)
	{
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected Obj, but got Unknown
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected Obj, but got Unknown
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected Obj, but got Unknown
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
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
						if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado), "P", TextCompare: true) == 0)
						{
							bool flag = false;
							BlockReference blockRef = (BlockReference)ent;
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
							ent = (Entity)(object)blockRef;
							DeclaracoesEntidades.StructureDispositivo disp = ((obj == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj));
							if (Operators.CompareString(((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString(), shandle, TextCompare: true) == 0)
							{
								flag = true;
							}
							if (disp.Complementar && Operators.CompareString(disp.Handle, shandle, TextCompare: true) == 0)
							{
								flag = true;
							}
							if (flag)
							{
								disp.Nome1 = sNome1;
								disp.Nome2 = sNome2;
								disp.Alternativo = sAlternativo;
								blockRef = (BlockReference)ent;
								XDataDispositivosMaster.GravarXDataDispPrincipal(ref blockRef, ref disp);
								ent = (Entity)(object)blockRef;
								tipoImportado = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
								clsBlocos.EditaNomesDeUmBloco(ref tipoImportado, disp.Nome1, disp.Nome2, disp.Alternativo);
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

	public static void EditaTerminaisDispositivoSemModelo(mBlocosPrincipal[] mDispEditados)
	{
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected Obj, but got Unknown
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected Obj, but got Unknown
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected Obj, but got Unknown
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Expected Obj, but got Unknown
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
					_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					int num = Information.UBound(mDispEditados);
					for (int i = 1; i <= num; i++)
					{
						ObjectId val4 = Geral.HandleToID(mDispEditados[i].sHandle);
						if (!val4.IsValid)
						{
							continue;
						}
						Entity val5 = (Entity)val2.GetObject(val4, (OpenMode)0);
						try
						{
							Entity ent = val5;
							string tipoImportado = "";
							string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
							if (Operators.CompareString(left, "P", TextCompare: true) != 0)
							{
								continue;
							}
							string[] array = mDispEditados[i].sTerminais.Split(';');
							BlockReference val6 = (BlockReference)val2.GetObject(((DBObject)val5).ObjectId, (OpenMode)0);
							BlockTableRecord val7 = (BlockTableRecord)val2.GetObject(val6.BlockTableRecord, (OpenMode)0);
							if (string.Compare(((SymbolTableRecord)val7).Name, val6.Name, ignoreCase: true) != 0)
							{
								continue;
							}
							AttributeCollection attributeCollection = val6.AttributeCollection;
							foreach (object item in attributeCollection)
							{
								ObjectId val8 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
								AttributeReference val9 = (AttributeReference)val8.GetObject((OpenMode)1);
								int num2 = Information.UBound(array);
								for (int j = 0; j <= num2; j++)
								{
									if (Operators.CompareString(val9.Tag, "T" + Conversions.ToString(j + 1), TextCompare: true) == 0)
									{
										((DBText)val9).TextString = array[j].ToString();
										((Entity)val9).Draw();
										break;
									}
								}
							}
						}
						finally
						{
							((IDisposable)val5)?.Dispose();
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

	public static void EncontraModelosUsados(ref List<int> lModelosUsados)
	{
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected Obj, but got Unknown
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
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected Obj, but got Unknown
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
						if (Operators.CompareString(left, "P", TextCompare: true) == 0)
						{
							BlockReference blockRef = (BlockReference)ent;
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
							ent = (Entity)(object)blockRef;
							DeclaracoesEntidades.StructureDispositivo structureDispositivo = ((obj == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj));
							if (!lModelosUsados.Contains(structureDispositivo.indexModelo))
							{
								lModelosUsados.Add(structureDispositivo.indexModelo);
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

	public static void EncontraModelosComContatos(ref List<string> lModelosContatos)
	{
		Declaracoes2.MModelosDeContatos[] mModelo = null;
		Declaracoes2.StructureContatosAuxiliares[] mCONTATOS = null;
		DicionarioContatos.LeOsModelosDeDeDicionarioContatos(ref mModelo);
		int num = Information.UBound(mModelo);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			DicionarioContatos.LeOsContatosAuxiliarDoModeloDoDicionario(ref mModelo[i].iIndiceModelo, ref mCONTATOS);
			if (Information.UBound(mCONTATOS) > 0)
			{
				lModelosContatos.Add(mModelo[i].sNomeModelo);
			}
		}
	}

	public static void ModeloDoDispositivoPrincipalTipo0()
	{
		//IL_0240: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Expected Obj, but got Unknown
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
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected Obj, but got Unknown
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected Obj, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected Obj, but got Unknown
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
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
							if (!flag || Modelo.indexContato != 0)
							{
								continue;
							}
							Entity val7 = (Entity)Geral.HandleToObject(Modelo.HandleBob);
							if (val7 != null)
							{
								BlockReference blockRef = (BlockReference)val7;
								object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
								val7 = (Entity)(object)blockRef;
								DeclaracoesEntidades.StructureDispositivo structureDispositivo = ((obj == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj));
								string text = structureDispositivo.Nome1;
								if (Operators.CompareString(structureDispositivo.Nome2, "", TextCompare: true) != 0)
								{
									text = text + "/" + structureDispositivo.Nome2;
								}
								if (structureDispositivo.AlternativoVisivel)
								{
									text += structureDispositivo.Alternativo;
								}
								string sHandle = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
								clsBlocos.AtributoVisivelInvidivel(ref sHandle, "NOME", bliga: true);
								sHandle = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
								clsBlocos.AtualizaValorDeUmAtributo(ref sHandle, "NOME", text);
								ResultBuffer xDataForApplication = ((DBObject)val7).GetXDataForApplication("DISPOSITIVO");
								if (xDataForApplication != null)
								{
									sHandle = ((object)((DBObject)val7).Handle/*cast due to constrained. prefix*/).ToString();
									clsBlocos.AtualizaValorDeUmAtributo(ref sHandle, "MODELO", "");
									((DBObject)val6).UpgradeOpen();
									((Entity)val6).Visible = true;
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

	public static void ModeloDoDispositivoPrincipalTipo1()
	{
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected Obj, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected Obj, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected Obj, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected Obj, but got Unknown
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		Declaracoes2.MModelosDeContatos[] mModelo = null;
		DicionarioContatos.LeOsModelosDeDeDicionarioContatos(ref mModelo);
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
							if (!flag || Modelo.indexContato != 0)
							{
								continue;
							}
							Entity val7 = (Entity)Geral.HandleToObject(Modelo.HandleBob);
							if (val7 != null)
							{
								ResultBuffer xDataForApplication = ((DBObject)val7).GetXDataForApplication("DISPOSITIVO");
								if (xDataForApplication != null)
								{
									string sValor = BuscaNomeDoModelo(Modelo.indexModelo, ref mModelo);
									string sHandle = ((object)((DBObject)val7).Handle/*cast due to constrained. prefix*/).ToString();
									clsBlocos.AtualizaValorDeUmAtributo(ref sHandle, "MODELO", sValor);
									((DBObject)val6).UpgradeOpen();
									((Entity)val6).Visible = false;
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

	public static void ModeloDoDispositivoPrincipalTipo2()
	{
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected Obj, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected Obj, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected Obj, but got Unknown
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected Obj, but got Unknown
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected Obj, but got Unknown
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		Declaracoes2.MModelosDeContatos[] mModelo = null;
		DicionarioContatos.LeOsModelosDeDeDicionarioContatos(ref mModelo);
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
							if (!flag || Modelo.indexContato != 0)
							{
								continue;
							}
							Entity val7 = (Entity)Geral.HandleToObject(Modelo.HandleBob);
							if (val7 == null)
							{
								continue;
							}
							ResultBuffer xDataForApplication = ((DBObject)val7).GetXDataForApplication("DISPOSITIVO");
							if (xDataForApplication != null)
							{
								string sValor = BuscaNomeDoModelo(Modelo.indexModelo, ref mModelo);
								string sHandle = ((object)((DBObject)val7).Handle/*cast due to constrained. prefix*/).ToString();
								clsBlocos.AtualizaValorDeUmAtributo(ref sHandle, "MODELO", sValor);
								BlockReference blockRef = (BlockReference)val7;
								object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
								val7 = (Entity)(object)blockRef;
								DeclaracoesEntidades.StructureDispositivo structureDispositivo = ((obj == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj));
								string text = structureDispositivo.Nome1;
								if (Operators.CompareString(structureDispositivo.Nome2, "", TextCompare: true) != 0)
								{
									text = text + "/" + structureDispositivo.Nome2;
								}
								if (structureDispositivo.AlternativoVisivel)
								{
									text += structureDispositivo.Alternativo;
								}
								((DBObject)val6).UpgradeOpen();
								((Entity)val6).Visible = true;
								sHandle = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
								clsBlocos.AtributoVisivelInvidivel(ref sHandle, "NOME", bliga: true);
								sHandle = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
								clsBlocos.AtualizaValorDeUmAtributo(ref sHandle, "NOME", text);
								sHandle = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
								clsBlocos.AtualizaValorDeUmAtributo(ref sHandle, "MODELO", sValor);
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

	public static void ModeloDoDispositivoPrincipalTipo3()
	{
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected Obj, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected Obj, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected Obj, but got Unknown
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected Obj, but got Unknown
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		Declaracoes2.MModelosDeContatos[] mModelo = null;
		DicionarioContatos.LeOsModelosDeDeDicionarioContatos(ref mModelo);
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
							if (!flag || Modelo.indexContato != 0)
							{
								continue;
							}
							Entity val7 = (Entity)Geral.HandleToObject(Modelo.HandleBob);
							if (val7 != null)
							{
								ResultBuffer xDataForApplication = ((DBObject)val7).GetXDataForApplication("DISPOSITIVO");
								if (xDataForApplication != null)
								{
									string sValor = BuscaNomeDoModelo(Modelo.indexModelo, ref mModelo);
									string sHandle = ((object)((DBObject)val7).Handle/*cast due to constrained. prefix*/).ToString();
									clsBlocos.AtualizaValorDeUmAtributo(ref sHandle, "MODELO", sValor);
									((DBObject)val6).UpgradeOpen();
									((Entity)val6).Visible = true;
									sHandle = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
									clsBlocos.AtributoVisivelInvidivel(ref sHandle, "NOME", bliga: true);
									sHandle = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
									clsBlocos.AtualizaValorDeUmAtributo(ref sHandle, "NOME", "");
									sHandle = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
									clsBlocos.AtualizaValorDeUmAtributo(ref sHandle, "MODELO", sValor);
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

	public static void EditaUmModeloDeDispositivoPrincipalTipo0(string sHandle)
	{
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Expected Obj, but got Unknown
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
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected Obj, but got Unknown
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected Obj, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected Obj, but got Unknown
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
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
							if (!flag || Modelo.indexContato != 0)
							{
								continue;
							}
							Entity val7 = (Entity)Geral.HandleToObject(Modelo.HandleBob);
							if (val7 != null && Operators.CompareString(sHandle, ((object)((DBObject)val7).Handle/*cast due to constrained. prefix*/).ToString(), TextCompare: true) == 0)
							{
								BlockReference blockRef = (BlockReference)val7;
								object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
								val7 = (Entity)(object)blockRef;
								DeclaracoesEntidades.StructureDispositivo structureDispositivo = ((obj == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj));
								string text = structureDispositivo.Nome1;
								if (Operators.CompareString(structureDispositivo.Nome2, "", TextCompare: true) != 0)
								{
									text = text + "/" + structureDispositivo.Nome2;
								}
								if (structureDispositivo.AlternativoVisivel)
								{
									text += structureDispositivo.Alternativo;
								}
								string sHandle2 = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
								clsBlocos.AtributoVisivelInvidivel(ref sHandle2, "NOME", bliga: true);
								sHandle2 = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
								clsBlocos.AtualizaValorDeUmAtributo(ref sHandle2, "NOME", text);
								ResultBuffer xDataForApplication = ((DBObject)val7).GetXDataForApplication("DISPOSITIVO");
								if (xDataForApplication != null)
								{
									sHandle2 = ((object)((DBObject)val7).Handle/*cast due to constrained. prefix*/).ToString();
									clsBlocos.AtualizaValorDeUmAtributo(ref sHandle2, "MODELO", "");
									((DBObject)val6).UpgradeOpen();
									((Entity)val6).Visible = true;
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

	public static void EditaUmModeloDeDispositivoPrincipalTipo1(string sHandle)
	{
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected Obj, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected Obj, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected Obj, but got Unknown
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected Obj, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		Declaracoes2.MModelosDeContatos[] mModelo = null;
		DicionarioContatos.LeOsModelosDeDeDicionarioContatos(ref mModelo);
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
							if (!flag || Modelo.indexContato != 0)
							{
								continue;
							}
							Entity val7 = (Entity)Geral.HandleToObject(Modelo.HandleBob);
							if (val7 != null && Operators.CompareString(sHandle, ((object)((DBObject)val7).Handle/*cast due to constrained. prefix*/).ToString(), TextCompare: true) == 0)
							{
								ResultBuffer xDataForApplication = ((DBObject)val7).GetXDataForApplication("DISPOSITIVO");
								if (xDataForApplication != null)
								{
									string sValor = BuscaNomeDoModelo(Modelo.indexModelo, ref mModelo);
									string sHandle2 = ((object)((DBObject)val7).Handle/*cast due to constrained. prefix*/).ToString();
									clsBlocos.AtualizaValorDeUmAtributo(ref sHandle2, "MODELO", sValor);
									((DBObject)val6).UpgradeOpen();
									((Entity)val6).Visible = false;
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

	public static void EditaUmModeloDeDispositivoPrincipalTipo2(string sHandle)
	{
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected Obj, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected Obj, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected Obj, but got Unknown
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected Obj, but got Unknown
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Expected Obj, but got Unknown
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		Declaracoes2.MModelosDeContatos[] mModelo = null;
		DicionarioContatos.LeOsModelosDeDeDicionarioContatos(ref mModelo);
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
							if (!flag || Modelo.indexContato != 0)
							{
								continue;
							}
							Entity val7 = (Entity)Geral.HandleToObject(Modelo.HandleBob);
							if (val7 == null || Operators.CompareString(sHandle, ((object)((DBObject)val7).Handle/*cast due to constrained. prefix*/).ToString(), TextCompare: true) != 0)
							{
								continue;
							}
							ResultBuffer xDataForApplication = ((DBObject)val7).GetXDataForApplication("DISPOSITIVO");
							if (xDataForApplication != null)
							{
								string sValor = BuscaNomeDoModelo(Modelo.indexModelo, ref mModelo);
								string sHandle2 = ((object)((DBObject)val7).Handle/*cast due to constrained. prefix*/).ToString();
								clsBlocos.AtualizaValorDeUmAtributo(ref sHandle2, "MODELO", sValor);
								BlockReference blockRef = (BlockReference)val7;
								object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
								val7 = (Entity)(object)blockRef;
								DeclaracoesEntidades.StructureDispositivo structureDispositivo = ((obj == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj));
								string text = structureDispositivo.Nome1;
								if (Operators.CompareString(structureDispositivo.Nome2, "", TextCompare: true) != 0)
								{
									text = text + "/" + structureDispositivo.Nome2;
								}
								if (structureDispositivo.AlternativoVisivel)
								{
									text += structureDispositivo.Alternativo;
								}
								((DBObject)val6).UpgradeOpen();
								((Entity)val6).Visible = true;
								sHandle2 = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
								clsBlocos.AtributoVisivelInvidivel(ref sHandle2, "NOME", bliga: true);
								sHandle2 = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
								clsBlocos.AtualizaValorDeUmAtributo(ref sHandle2, "NOME", text);
								sHandle2 = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
								clsBlocos.AtualizaValorDeUmAtributo(ref sHandle2, "MODELO", sValor);
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

	public static void EditaUmModeloDeDispositivoPrincipalTipo3(string sHandle)
	{
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected Obj, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected Obj, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected Obj, but got Unknown
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected Obj, but got Unknown
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		Declaracoes2.MModelosDeContatos[] mModelo = null;
		DicionarioContatos.LeOsModelosDeDeDicionarioContatos(ref mModelo);
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
							if (!flag || Modelo.indexContato != 0)
							{
								continue;
							}
							Entity val7 = (Entity)Geral.HandleToObject(Modelo.HandleBob);
							if (val7 != null && Operators.CompareString(sHandle, ((object)((DBObject)val7).Handle/*cast due to constrained. prefix*/).ToString(), TextCompare: true) == 0)
							{
								ResultBuffer xDataForApplication = ((DBObject)val7).GetXDataForApplication("DISPOSITIVO");
								if (xDataForApplication != null)
								{
									string sValor = BuscaNomeDoModelo(Modelo.indexModelo, ref mModelo);
									string sHandle2 = ((object)((DBObject)val7).Handle/*cast due to constrained. prefix*/).ToString();
									clsBlocos.AtualizaValorDeUmAtributo(ref sHandle2, "MODELO", sValor);
									((DBObject)val6).UpgradeOpen();
									((Entity)val6).Visible = true;
									sHandle2 = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
									clsBlocos.AtributoVisivelInvidivel(ref sHandle2, "NOME", bliga: true);
									sHandle2 = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
									clsBlocos.AtualizaValorDeUmAtributo(ref sHandle2, "NOME", "");
									sHandle2 = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
									clsBlocos.AtualizaValorDeUmAtributo(ref sHandle2, "MODELO", sValor);
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

	public static object BuscaModeloExistente(string shandleBobina)
	{
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected Obj, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Obj, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected Obj, but got Unknown
		bool flag = false;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
			BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
			BlockTableRecordEnumerator enumerator = default;
			try
			{
				enumerator = val3.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ObjectId current = enumerator.Current;
					Entity Ent = (Entity)val.GetObject(current, (OpenMode)0);
					Declaracoes2.StructureModelo Modelo = default;
					if (XDataDispositivosMaster.LerXDataModelo(ref Ent, ref Modelo) && Operators.CompareString(Modelo.HandleBob, shandleBobina, TextCompare: true) == 0 && Modelo.indexContato == 0)
					{
						flag = true;
						break;
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
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError((Exception)ex);
			val.Abort();
			ProjectData.ClearProjectError();
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		return flag;
	}

	public static bool LPDisponivel(ref string lp)
	{
		bool result = false;
		if (XDataGeral.LerXDataConfiguracaoListaDePontos() && Operators.CompareString(DeclaracoesGeral.ConfLP.listaDePontos.Trim(), "", TextCompare: true) != 0 && File.Exists(DeclaracoesGeral.ConfLP.listaDePontos))
		{
			if (!Geral.IsFileInUse(DeclaracoesGeral.ConfLP.listaDePontos))
			{
				lp = DeclaracoesGeral.ConfLP.listaDePontos;
				result = true;
			}
			else
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1495]), MsgBoxStyle.Information);
			}
		}
		return result;
	}
}

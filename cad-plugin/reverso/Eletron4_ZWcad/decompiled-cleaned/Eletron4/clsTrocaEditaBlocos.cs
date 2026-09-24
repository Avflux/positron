using System;
using System.Collections.Generic;
using System.IO;
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

public class clsTrocaEditaBlocos
{
	[CommandMethod("LeAtributos")]
	public static string LeAtributos(List<string> mNomeBlocos, ref List<string> lAtributos, ref List<string> lBlocosNaoExistentes)
	{
		//IL_032c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0332: Expected Obj, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected Obj, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected Obj, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected Obj, but got Unknown
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected Obj, but got Unknown
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		bool flag = false;
		int num = 0;
		clsTrocaEditaBlocosMat.mAtributos = new structureAtributos[1];
		string sNomeBloco = "";
		lAtributos.Clear();
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
								BlockReference blockRef = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
								if (blockRef == null || !mNomeBlocos.Contains(blockRef.Name.ToUpper()) || Operators.CompareString(clsBlocos.TipoBlocoDoEletron(ref blockRef, ref sNomeBloco), "", TextCompare: true) == 0)
								{
									continue;
								}
								AttributeCollection attributeCollection = blockRef.AttributeCollection;
								foreach (object item in attributeCollection)
								{
									ObjectId val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
									AttributeReference val7 = (AttributeReference)val6.GetObject((OpenMode)0);
									flag = true;
									if (!clsTrocaEditaBlocosMat.lBlocosAlterados.Contains(((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString()))
									{
										clsTrocaEditaBlocosMat.lBlocosAlterados.Add(((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString());
									}
									if (!lBlocosNaoExistentes.Contains(blockRef.Name.ToUpper()))
									{
										lBlocosNaoExistentes.Add(blockRef.Name.ToUpper());
									}
									if (!((Entity)val7).Visible)
									{
										if (!lAtributos.Contains(((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString()))
										{
											lAtributos.Add(((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString());
										}
										num++;
										clsTrocaEditaBlocosMat.mAtributos = (structureAtributos[])Utils.CopyArray(clsTrocaEditaBlocosMat.mAtributos, new structureAtributos[num + 1]);
										clsTrocaEditaBlocosMat.mAtributos[num].sHandleBlocoo = ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString();
										clsTrocaEditaBlocosMat.mAtributos[num].sHandleBlocooNovo = ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString();
										clsTrocaEditaBlocosMat.mAtributos[num].sTag = val7.Tag;
										clsTrocaEditaBlocosMat.mAtributos[num].sValor = ((DBText)val7).TextString;
										clsTrocaEditaBlocosMat.mAtributos[num].sVisible = ((Entity)val7).Visible;
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
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				ProjectData.ClearProjectError();
			}
			return Conversions.ToString(flag);
		}
	}

	[CommandMethod("CorrigeAtributos")]
	public void CorrigeAtributos()
	{
		List<string> list = new List<string>();
		int num = Information.UBound(clsTrocaEditaBlocosMat.mAtributos);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			clsBlocos.EditaUmAtributoDeUmBloco(ref clsTrocaEditaBlocosMat.mAtributos[i].sHandleBlocooNovo, clsTrocaEditaBlocosMat.mAtributos[i].sTag, clsTrocaEditaBlocosMat.mAtributos[i].sValor, clsTrocaEditaBlocosMat.mAtributos[i].sVisible);
			if (Operators.CompareString(clsTrocaEditaBlocosMat.mAtributos[i].sHandleBlocoo, clsTrocaEditaBlocosMat.mAtributos[i].sHandleBlocooNovo, TextCompare: true) != 0 && !list.Contains(clsTrocaEditaBlocosMat.mAtributos[i].sHandleBlocooNovo))
			{
				list.Add(clsTrocaEditaBlocosMat.mAtributos[i].sHandleBlocooNovo);
			}
		}
		string text = Conversions.ToString(Operators.ConcatenateObject(Conversions.ToString(clsTrocaEditaBlocosMat.lBlocosExistentesTrocados.Count) + " ", DeclaracoesGeral.mMensagem[1, 1298]));
		if (clsTrocaEditaBlocosMat.lBlocosExistentesTrocados.Count > 1)
		{
			text = Conversions.ToString(Operators.ConcatenateObject(Conversions.ToString(clsTrocaEditaBlocosMat.lBlocosExistentesTrocados.Count) + " ", DeclaracoesGeral.mMensagem[1, 1302]));
		}
		if (list.Count >= 1)
		{
			text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1349], "  "), list.Count.ToString()));
		}
		string text2 = "";
		if (Operators.CompareString(clsTrocaEditaBlocosMat.sBlocosNaoExistentes, "", TextCompare: true) != 0)
		{
			text2 = (clsTrocaEditaBlocosMat.sBlocosNaoExistentes.Contains(";") ? Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("\r\n\r\n", DeclaracoesGeral.mMensagem[1, 1300]), " "), DeclaracoesGeral.mMensagem[1, 1301]), clsTrocaEditaBlocosMat.sBlocosNaoExistentes)) : Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("\r\n\r\n", DeclaracoesGeral.mMensagem[1, 1299]), " "), DeclaracoesGeral.mMensagem[1, 1301]), clsTrocaEditaBlocosMat.sBlocosNaoExistentes)));
		}
		Interaction.MsgBox(text + text2, MsgBoxStyle.Information, "Elétron");
	}

	[CommandMethod("LeTodosAtributos")]
	public static void LeTodosAtributos()
	{
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected Obj, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected Obj, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected Obj, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected Obj, but got Unknown
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected Obj, but got Unknown
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		clsTrocaEditaBlocosMat.mAtributos = new structureAtributos[1];
		string sNomeBloco = "";
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
								BlockReference blockRef = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
								if (blockRef == null || Operators.CompareString(clsBlocos.TipoBlocoDoEletron(ref blockRef, ref sNomeBloco), "", TextCompare: true) == 0)
								{
									continue;
								}
								AttributeCollection attributeCollection = blockRef.AttributeCollection;
								foreach (object item in attributeCollection)
								{
									ObjectId val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
									AttributeReference val7 = (AttributeReference)val6.GetObject((OpenMode)0);
									if (!((Entity)val7).Visible)
									{
										num++;
										clsTrocaEditaBlocosMat.mAtributos = (structureAtributos[])Utils.CopyArray(clsTrocaEditaBlocosMat.mAtributos, new structureAtributos[num + 1]);
										clsTrocaEditaBlocosMat.mAtributos[num].sHandleBlocoo = ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString();
										clsTrocaEditaBlocosMat.mAtributos[num].sTag = val7.Tag;
										clsTrocaEditaBlocosMat.mAtributos[num].sValor = ((DBText)val7).TextString;
										clsTrocaEditaBlocosMat.mAtributos[num].sVisible = ((Entity)val7).Visible;
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
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				ProjectData.ClearProjectError();
			}
		}
	}

	[CommandMethod("CorrigeAtributosSemMsg")]
	public void CorrigeAtributosSemMsg()
	{
		new List<string>();
		int num = Information.UBound(clsTrocaEditaBlocosMat.mAtributos);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			clsBlocos.EditaUmAtributoDeUmBloco(ref clsTrocaEditaBlocosMat.mAtributos[i].sHandleBlocoo, clsTrocaEditaBlocosMat.mAtributos[i].sTag, clsTrocaEditaBlocosMat.mAtributos[i].sValor, clsTrocaEditaBlocosMat.mAtributos[i].sVisible);
		}
	}

	[CommandMethod("PreencheNovosAtributos")]
	public void PreencheNovosAtributos()
	{
		checked
		{
			int num = clsTrocaEditaBlocosMat.lBlocosExistentesTrocados.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				structureAtributosSub[] mAtributosHandle = new structureAtributosSub[1];
				if (clsTrocaEditaBlocosMat.lBlocosExistentesTrocados[i].Contains("_E_"))
				{
					BuscaBlocosIguaisAoSelecionado(ref mAtributosHandle, clsTrocaEditaBlocosMat.lBlocosExistentesTrocados[i]);
					clsPortas.AtualizaAsPortasTrocadas(mAtributosHandle);
				}
				if (clsTrocaEditaBlocosMat.lBlocosExistentesTrocados[i].Contains("_A_"))
				{
					Correcao.CorrigeContatosAux();
				}
			}
		}
	}

	public static int BuscaNumeroDeBlocosParaTrocar(string sNomeDoBloco)
	{
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected Obj, but got Unknown
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
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
						BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
						if (val6 == null)
						{
							continue;
						}
						try
						{
							if (Operators.CompareString(val6.Name, sNomeDoBloco, TextCompare: true) == 0)
							{
								num = checked(num + 1);
							}
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError((Exception)ex);
							ProjectData.ClearProjectError();
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
				((IDisposable)val2)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		return num;
	}

	public static object selecionaBlocosParaTrocar(ref structureAtributosSub[] mAtributosHandle, ref string sNomeDoBloco, ref string stipo)
	{
		//IL_0306: Unknown result type (might be due to invalid IL or missing references)
		//IL_030c: Expected Obj, but got Unknown
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected Obj, but got Unknown
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected Obj, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		bool flag = false;
		int num = 0;
		mAtributosHandle = new structureAtributosSub[1];
		num = 1;
		stipo = "";
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				_ = Application.DocumentManager.MdiActiveDocument;
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				PromptSelectionOptions val2 = new PromptSelectionOptions();
				editor.WriteMessage(Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 1608])));
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				val2.Keywords.GetDisplayString(true);
				PromptSelectionResult selection = editor.GetSelection(val2);
				List<string> list = new List<string>();
				list.Clear();
				string sNomeBloco = "";
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val3 = database.TransactionManager.StartTransaction();
				try
				{
					if (!Information.IsNothing(selection.Value))
					{
						SelectionSet value = selection.Value;
						ObjectIdCollection val4 = new ObjectIdCollection(value.GetObjectIds());
						foreach (object item in val4)
						{
							ObjectId val5 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							Entity val6 = (Entity)val5.GetObject((OpenMode)0);
							if (Operators.CompareString(val6.Layer, DeclaracoesGeral.ativo.Pagina, TextCompare: true) != 0)
							{
								continue;
							}
							BlockReference blockRef = (BlockReference)(object)((val6 is BlockReference) ? val6 : null);
							if (blockRef == null)
							{
								continue;
							}
							if (Operators.CompareString(sNomeBloco, "", TextCompare: true) == 0)
							{
								stipo = clsBlocos.TipoBlocoDoEletron(ref blockRef, ref sNomeBloco);
							}
							if (Operators.CompareString(sNomeBloco, blockRef.Name, TextCompare: true) == 0)
							{
								if (Operators.CompareString(sNomeDoBloco, "", TextCompare: true) == 0)
								{
									sNomeDoBloco = blockRef.Name;
								}
								if (Operators.CompareString(sNomeDoBloco, blockRef.Name, TextCompare: true) == 0 && !list.Contains(((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString()))
								{
									list.Add(((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString());
									mAtributosHandle = (structureAtributosSub[])Utils.CopyArray(mAtributosHandle, new structureAtributosSub[num + 1]);
									mAtributosHandle[num].sHandleBlocoAntigo = ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString();
									num++;
								}
							}
						}
					}
					DeclaracoesGeral.bAnularEventos = true;
					val3.Commit();
					DeclaracoesGeral.bAnularEventos = false;
					clsBlocos.Unhighlight();
					clsInterligacao.AtivaHighlight(list);
					if ((Operators.CompareString(stipo, "A", TextCompare: true) == 0) | (Operators.CompareString(stipo, "B", TextCompare: true) == 0) | (Operators.CompareString(stipo, "P", TextCompare: true) == 0) | (Operators.CompareString(stipo, "E", TextCompare: true) == 0))
					{
						stipo = "_" + stipo + "_";
					}
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
				((IDisposable)val)?.Dispose();
			}
			return flag;
		}
	}

	public static void BuscaBlocosIguaisAoSelecionado(ref structureAtributosSub[] mAtributosHandle, string sNomeAntigo)
	{
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected Obj, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected Obj, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected Obj, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected Obj, but got Unknown
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			int num = Information.UBound(mAtributosHandle) + 1;
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
							try
							{
								if (Operators.CompareString(val6.Name.ToUpper(), sNomeAntigo.ToUpper(), TextCompare: true) == 0 && !(((DBObject)val6).XData == (ResultBuffer)null))
								{
									mAtributosHandle = (structureAtributosSub[])Utils.CopyArray(mAtributosHandle, new structureAtributosSub[num + 1]);
									mAtributosHandle[num].sHandleBlocoAntigo = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
									mAtributosHandle[num].sHandleBlocoNovo = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
									num++;
								}
							}
							catch (Exception ex)
							{
								ProjectData.SetProjectError((Exception)ex);
								ProjectData.ClearProjectError();
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
					((IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}

	public static void BuscaAtributosDeTodosOsBlocosIguaisAoSelecionado(string sNomeNovo, string sNomeAntigo)
	{
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected Obj, but got Unknown
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected Obj, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
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
					int num = 0;
					clsTrocaEditaBlocosMat.mAtributos = new structureAtributos[1];
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
							try
							{
								string text = val6.Name.ToUpper();
								text = text.Replace(".DWG", "");
								if (!((Operators.CompareString(text, sNomeAntigo.ToUpper(), TextCompare: true) == 0) | (Operators.CompareString(text, sNomeNovo.ToUpper(), TextCompare: true) == 0)) || ((DBObject)val6).XData == (ResultBuffer)null)
								{
									continue;
								}
								AttributeCollection attributeCollection = val6.AttributeCollection;
								foreach (object item in attributeCollection)
								{
									ObjectId val7 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
									AttributeReference val8 = (AttributeReference)val7.GetObject((OpenMode)0);
									num++;
									clsTrocaEditaBlocosMat.mAtributos = (structureAtributos[])Utils.CopyArray(clsTrocaEditaBlocosMat.mAtributos, new structureAtributos[num + 1]);
									clsTrocaEditaBlocosMat.mAtributos[num].sHandleBlocoo = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
									clsTrocaEditaBlocosMat.mAtributos[num].sHandleBlocooNovo = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
									clsTrocaEditaBlocosMat.mAtributos[num].sTag = val8.Tag;
									clsTrocaEditaBlocosMat.mAtributos[num].sValor = ((DBText)val8).TextString;
									clsTrocaEditaBlocosMat.mAtributos[num].sVisible = ((Entity)val8).Visible;
								}
							}
							catch (Exception ex)
							{
								ProjectData.SetProjectError((Exception)ex);
								ProjectData.ClearProjectError();
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
					((IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}

	public static string insereUmBlocoParaSubstituir(ref structureAtributosSub[] mAtributosHandle, string sNomeAntigo, string sNomeNovo, string sCaminhoBloco, bool bSelecionados)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0487: Unknown result type (might be due to invalid IL or missing references)
		//IL_048d: Expected Obj, but got Unknown
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected Obj, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Expected Obj, but got Unknown
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Expected Obj, but got Unknown
		//IL_03dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ee: Expected Obj, but got Unknown
		//IL_03f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected Obj, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected Obj, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Expected Obj, but got Unknown
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Expected Obj, but got Unknown
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Expected Obj, but got Unknown
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Expected Obj, but got Unknown
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0369: Unknown result type (might be due to invalid IL or missing references)
		//IL_0409: Unknown result type (might be due to invalid IL or missing references)
		//IL_040e: Unknown result type (might be due to invalid IL or missing references)
		//IL_043d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0442: Unknown result type (might be due to invalid IL or missing references)
		//IL_046b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0472: Expected Obj, but got Unknown
		ObjectId val = ObjectId.Null;
		string result = "";
		Point3d val2 = new Point3d(0.0, 0.0, 0.0);
		string layer = Conversions.ToString(0);
		PointMonitorToolTips.StopMonitor();
		DocumentLock val3 = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				_ = Application.DocumentManager.MdiActiveDocument.Editor;
				string text = "";
				DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mAtributosHandle);
				DeclaracoesGeral._uscPagina.pbIniciar();
				List<int> list = new List<int>();
				int num = Information.UBound(mAtributosHandle);
				BlockTableRecordEnumerator enumerator = default;
				for (int i = 1; i <= num; DeclaracoesGeral._uscPagina.pbPasso(), i++)
				{
					string right = "";
					BlockReference val4 = null;
					BlockReference val5 = null;
					Transaction val6 = database.TransactionManager.StartTransaction();
					TypedValue[] tpVals;
					try
					{
						text = mAtributosHandle[i].sHandleBlocoAntigo;
						Entity val7 = (Entity)Geral.HandleToObject(text);
						if (val7 != null)
						{
							val4 = (BlockReference)(object)((val7 is BlockReference) ? val7 : null);
							if (((DBObject)val4).XData != (ResultBuffer)null)
							{
								layer = ((Entity)val4).Layer;
								val2 = val4.Position;
							}
							if (!(((DBObject)val4).XData == (ResultBuffer)null))
							{
								tpVals = ((DBObject)val4).XData.AsArray();
								right = ((object)((DBObject)val4).Handle/*cast due to constrained. prefix*/).ToString();
								DeclaracoesGeral.bAnularEventos = true;
								val6.Commit();
								DeclaracoesGeral.bAnularEventos = false;
								hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
								goto IL_01a3;
							}
						}
					}
					finally
					{
						((IDisposable)val6)?.Dispose();
					}
					continue;
					IL_01a3:
					Transaction val8 = database.TransactionManager.StartTransaction();
					try
					{
						BlockTable val9 = (BlockTable)val8.GetObject(database.BlockTableId, (OpenMode)0);
						BlockTableRecord val10 = (BlockTableRecord)val8.GetObject(((SymbolTable)val9)[BlockTableRecord.ModelSpace], (OpenMode)1);
						BlockTableRecord val11 = null;
						if (!((SymbolTable)val9).Has(sNomeNovo))
						{
							Database val12 = new Database(false, true);
							val12.ReadDwgFile(sCaminhoBloco, FileShare.Read, true, "");
							DeclaracoesGeral.bAnularEventos = true;
							val = database.Insert(sNomeNovo, val12, false);
							((DisposableWrapper)val12).Dispose();
						}
						else
						{
							BlockTableRecord val13 = (BlockTableRecord)val8.GetObject(((SymbolTable)val9)[sNomeNovo], (OpenMode)0);
							val = ((DBObject)val13).Id;
						}
						val5 = new BlockReference(val2, val);
						((Entity)val5).Layer = layer;
						val10.AppendEntity((Entity)(object)val5);
						((Entity)val5).Draw();
						DeclaracoesGeral.bAnularEventos = true;
						val8.AddNewlyCreatedDBObject((DBObject)(object)val5, true);
						((Entity)val5).Draw();
						val11 = (BlockTableRecord)val8.GetObject(val, (OpenMode)0);
						try
						{
							enumerator = val11.GetEnumerator();
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.Current;
								Entity val14 = (Entity)val8.GetObject(current, (OpenMode)0);
								if (!(val14 is AttributeDefinition))
								{
									continue;
								}
								AttributeDefinition val15 = (AttributeDefinition)val14;
								AttributeReference val16 = new AttributeReference();
								val16.SetAttributeFromBlock(val15, val5.BlockTransform);
								((DBText)val16).TextString = "";
								((Entity)val16).Visible = false;
								int num2 = Information.UBound(clsTrocaEditaBlocosMat.mAtributos);
								for (int j = 1; j <= num2; j++)
								{
									if (Operators.CompareString(val15.Tag.ToUpper(), clsTrocaEditaBlocosMat.mAtributos[j].sTag, TextCompare: true) == 0)
									{
										((DBText)val16).TextString = clsTrocaEditaBlocosMat.mAtributos[j].sValor;
										((Entity)val16).Visible = clsTrocaEditaBlocosMat.mAtributos[j].sVisible;
										break;
									}
								}
								((DBText)val16).AdjustAlignment(database);
								val5.AttributeCollection.AppendAttribute(val16);
								DeclaracoesGeral.bAnularEventos = true;
								val8.AddNewlyCreatedDBObject((DBObject)(object)val16, true);
								((Entity)val16).Draw();
							}
						}
						finally
						{
							((IDisposable)enumerator)?.Dispose();
						}
						int num3 = Information.UBound(clsTrocaEditaBlocosMat.mAtributos);
						for (int k = 0; k <= num3; k++)
						{
							if (Operators.CompareString(clsTrocaEditaBlocosMat.mAtributos[k].sHandleBlocooNovo, right, TextCompare: true) == 0)
							{
								clsTrocaEditaBlocosMat.mAtributos[k].sHandleBlocooNovo = ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString();
							}
						}
						list.Clear();
						((Entity)val5).Draw();
						mAtributosHandle[i].sHandleBlocoNovo = ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString();
						DeclaracoesGeral.bAnularEventos = true;
						Entity Ent = (Entity)(object)val5;
						XDataTrocaBlocos.GravarXDataBlocos(ref Ent, tpVals);
						val5 = (BlockReference)Ent;
						DeclaracoesGeral.bAnularEventos = true;
						val8.Commit();
						DeclaracoesGeral.bAnularEventos = false;
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError((Exception)ex);
						ProjectData.ClearProjectError();
					}
					finally
					{
						((IDisposable)val8)?.Dispose();
					}
				}
				DeclaracoesGeral._uscPagina.pbFim();
			}
			finally
			{
				((IDisposable)val3)?.Dispose();
			}
			PointMonitorToolTips.StartMonitor();
			return result;
		}
	}

	public static void ApagaOsBlocosAntigos()
	{
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Expected Obj, but got Unknown
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Expected Obj, but got Unknown
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
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
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
							int num = Information.UBound(clsTrocaEditaBlocosMat.mAtributos);
							for (int i = 1; i <= num; i = checked(i + 1))
							{
								if (Operators.CompareString(clsTrocaEditaBlocosMat.mAtributos[i].sHandleBlocoo, clsTrocaEditaBlocosMat.mAtributos[i].sHandleBlocooNovo, TextCompare: true) != 0 && Operators.CompareString(((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString(), clsTrocaEditaBlocosMat.mAtributos[i].sHandleBlocoo, TextCompare: true) == 0)
								{
									((DBObject)val5).UpgradeOpen();
									((DBObject)val5).Erase();
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

	public static void corrigeOsHandlesDosBlocos(ref structureAtributosSub[] mAtributosHandle)
	{
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected Obj, but got Unknown
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Expected Obj, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected Obj, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected Obj, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected Obj, but got Unknown
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected Obj, but got Unknown
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Expected Obj, but got Unknown
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
					DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mAtributosHandle);
					DeclaracoesGeral._uscPagina.pbIniciar();
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity Ent = (Entity)val2.GetObject(current, (OpenMode)0);
							BlockReference val5 = (BlockReference)(object)((Ent is BlockReference) ? Ent : null);
							if (val5 != null)
							{
								Entity ent = (Entity)(object)val5;
								string tipoImportado = "";
								string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
								val5 = (BlockReference)ent;
								string text2 = text;
								string left = text2;
								if (Operators.CompareString(left, "P", TextCompare: true) != 0 && Operators.CompareString(left, "A", TextCompare: true) == 0)
								{
									object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val5);
									DeclaracoesEntidades.StructureAuxiliar Aux = ((obj == null) ? default(DeclaracoesEntidades.StructureAuxiliar) : ((DeclaracoesEntidades.StructureAuxiliar)obj));
									string text3 = Conversions.ToString(Yh8Tv698EL(ref Aux.HandleBob, ref mAtributosHandle));
									if (Operators.CompareString(text3, "", TextCompare: true) != 0)
									{
										Aux.HandleBob = text3;
										XDataDispositivosMaster.GravarXDataDispAuxiliar(ref val5, ref Aux);
									}
								}
								Declaracoes2.StructureModelo Modelo = default;
								ent = (Entity)(object)val5;
								bool flag = XDataDispositivosMaster.LerXDataModelo(ref ent, ref Modelo);
								val5 = (BlockReference)ent;
								if (flag)
								{
									string text4 = Conversions.ToString(Yh8Tv698EL(ref Modelo.HandleBob, ref mAtributosHandle));
									if (Operators.CompareString(text4, "", TextCompare: true) != 0)
									{
										Modelo.HandleBob = text4;
										XDataDispositivosMaster.GravarXDataDispModelo(ref val5, ref Modelo);
									}
								}
							}
							DBText val6 = (DBText)(object)((Ent is DBText) ? Ent : null);
							if (val6 == null)
							{
								continue;
							}
							DeclaracoesEntidades.StructureDefinicaoPortas Def = default;
							if (XDataDispositivosMaster.LerXDataDefinicao(ref Ent, ref Def))
							{
								string text5 = Conversions.ToString(Yh8Tv698EL(ref Def.handleDaPorta, ref mAtributosHandle));
								if (Operators.CompareString(text5, "", TextCompare: true) != 0)
								{
									Def.handleDaPorta = text5;
									Entity ent = (Entity)(object)val6;
									XDataDispositivosMaster.GravarXDataDefinicao(ref ent, ref Def);
									val6 = (DBText)ent;
								}
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

	private static object Yh8Tv698EL(ref string P_0, ref structureAtributosSub[] P_1)
	{
		string result = "";
		int num = Information.UBound(P_1);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (Operators.CompareString(P_1[i].sHandleBlocoAntigo, P_0, TextCompare: true) == 0)
			{
				result = P_1[i].sHandleBlocoNovo;
				break;
			}
		}
		return result;
	}
}

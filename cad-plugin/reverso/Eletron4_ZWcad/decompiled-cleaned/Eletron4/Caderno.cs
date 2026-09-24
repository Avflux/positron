using System;
using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.EditorInput;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.GraphicsInterface;
using ZwSoft.ZwCAD.Runtime;

namespace Eletron4;

public class Caderno
{
	public void CriaCaderno()
	{
		//IL_05d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected Obj, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected Obj, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected Obj, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected Obj, but got Unknown
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Invalid comparison between Unknown and I4
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Invalid comparison between Unknown and I4
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected Obj, but got Unknown
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Expected Obj, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Expected Obj, but got Unknown
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Expected Obj, but got Unknown
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Expected Obj, but got Unknown
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Expected Obj, but got Unknown
		object[,] array = new object[3, 1];
		bool flag = false;
		string text = "";
		bool flag2 = false;
		if (ExisteFormato())
		{
			flag2 = true;
			MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 75]), MsgBoxStyle.YesNo);
			if (msgBoxResult == MsgBoxResult.No)
			{
				return;
			}
			Pagina.capturaTitulos();
			Revisao.capturaRevisoesSimplificadas();
			object mAtributos = array;
			CapturaAtributosDoFormato(ref mAtributos);
			array = (object[,])mAtributos;
			ApagaDefinicaoReferencias(DeclaracoesGeral.blockFormatoName);
			Application.UpdateScreen();
			DeclaracoesGeral.blockFormatoID = ObjectId.Null;
			text = Pagina.retornaNumeroCapa();
			if (Operators.CompareString(text, "1", TextCompare: true) != 0)
			{
				flag = true;
				Pagina.alteraNomeLayer(text, "1");
			}
		}
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			try
			{
				BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)1);
				Database val4 = new Database(false, true);
				string caminho = "";
				string nomeDWG = "";
				PromptOpenFileOptions val5 = new PromptOpenFileOptions(Conversions.ToString(DeclaracoesGeral.mMensagem[1, 70]));
				((PromptFileOptions)val5).DialogCaption = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 71]);
				((PromptFileOptions)val5).Filter = "AutoCAD DWG (*.dwg)|*.dwg";
				PromptFileNameResult fileNameForOpen = editor.GetFileNameForOpen(val5);
				PromptStatus status = ((PromptResult)fileNameForOpen).Status;
				if ((int)status != -5002)
				{
					ObjectId val6 = default;
					if ((int)status == 5100)
					{
						val4.ReadDwgFile(((PromptResult)fileNameForOpen).StringResult, FileShare.Read, true, "");
						Geral.extraiNomeCaminhoDwg(((PromptResult)fileNameForOpen).StringResult, ref nomeDWG, ref caminho);
						DeclaracoesGeral.bAnularEventos = true;
						val6 = database.Insert(nomeDWG, val4, false);
						((DisposableWrapper)val4).Dispose();
					}
					BlockReference blockRef = new BlockReference(Point3d.Origin, val6);
					((Entity)blockRef).Layer = "0";
					val3.AppendEntity((Entity)(object)blockRef);
					DeclaracoesGeral.bAnularEventos = true;
					val.AddNewlyCreatedDBObject((DBObject)(object)blockRef, true);
					XDataGeral.GravarXDataFormato(ref blockRef);
					DeclaracoesGeral.blockFormatoID = ((DBObject)blockRef).ObjectId;
					DeclaracoesGeral.blockFormatoName = blockRef.Name;
					ZEntity(DeclaracoesGeral.blockFormatoID);
					BlockTableRecord val7 = (BlockTableRecord)val.GetObject(val6, (OpenMode)0);
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val7.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val8 = (Entity)val.GetObject(current, (OpenMode)0);
							if (!(val8 is AttributeDefinition))
							{
								continue;
							}
							AttributeDefinition val9 = (AttributeDefinition)val8;
							AttributeReference val10 = new AttributeReference();
							val10.SetAttributeFromBlock(val9, blockRef.BlockTransform);
							if (!DeclaracoesGeral.attProtCollection.Contains(val9.Tag))
							{
								string text2 = "";
								if (!Pagina.checaCapa(val8.Layer))
								{
									if (Operators.CompareString(val8.Layer, "-1", TextCompare: true) == 0)
									{
										text2 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 74]);
									}
								}
								else
								{
									text2 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 73]);
								}
								text2 = text2 + val9.Prompt + ":";
								string layer = val8.Layer;
								string tag = val9.Tag;
								object mAtributos = array;
								string text3 = euxs3rkWO(layer, tag, ref mAtributos);
								array = (object[,])mAtributos;
								string text4 = text3;
								PromptStringOptions val11 = new PromptStringOptions("\r\n" + text2);
								val11.AllowSpaces = true;
								val11.DefaultValue = text4;
								((PromptOptions)val11).AppendKeywordsToMessage = false;
								if (Operators.CompareString(text4, "", TextCompare: true) != 0)
								{
									val11.UseDefaultValue = true;
								}
								else
								{
									val11.UseDefaultValue = false;
								}
								PromptResult val12 = editor.GetString(val11);
								((DBText)val10).TextString = val12.StringResult;
							}
							else
							{
								((Entity)val10).Visible = false;
								((DBText)val10).TextString = "";
							}
							DeclaracoesGeral.bAnularEventos = true;
							((DBText)val10).AdjustAlignment(database);
							blockRef.AttributeCollection.AppendAttribute(val10);
							val.AddNewlyCreatedDBObject((DBObject)(object)val10, true);
							((Entity)val10).Draw();
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
					if (flag)
					{
						Pagina.alteraNomeLayer("1", text);
					}
					Pagina.CarregaPaginas();
					Pagina.OrdenaMatrizPaginas();
					Pagina.ApagarCamposPaginas();
					Pagina.criaCamposTOT();
					int num = Information.UBound(DeclaracoesGeral.mPaginas, 2);
					checked
					{
						for (int i = 1; i <= num; i++)
						{
							if (!Operators.ConditionalCompareObjectEqual(DeclaracoesGeral.mPaginas[1, i], 1, TextCompare: true))
							{
								Pagina.criaCamposFormato("-1", Conversions.ToString(DeclaracoesGeral.mPaginas[0, i]));
							}
							else
							{
								Pagina.criaCamposFormato(Pagina.retornaNumeroCapa(), Conversions.ToString(DeclaracoesGeral.mPaginas[0, i]));
							}
						}
						Revisao.carregaConfiguracaoRevisao();
						if (flag2)
						{
							int num2 = DeclaracoesGeral.Conf.maxCapa - 1;
							for (int j = 0; j <= num2; j++)
							{
								Revisao.verificaCriaBlocoRevisao(Pagina.retornaNumeroCapa(), j.ToString());
							}
							int num3 = DeclaracoesGeral.Conf.maxCorpo - 1;
							for (int k = 0; k <= num3; k++)
							{
								Revisao.verificaCriaBlocoRevisao("-1", k.ToString());
							}
							int maxCapa = DeclaracoesGeral.Conf.maxCapa;
							for (int l = maxCapa; l <= 7; l++)
							{
								ApagaDefinicaoReferencias("Revisao_Capa" + l);
							}
							int maxCorpo = DeclaracoesGeral.Conf.maxCorpo;
							for (int m = maxCorpo; m <= 7; m++)
							{
								ApagaDefinicaoReferencias("Revisao_Corpo" + m);
							}
							Pagina.AtualizaTitulos();
							Revisao.AtualizaRevSimplificada();
							Pagina.TrocaColunas();
						}
						Pagina.CarregaPaginas();
						Pagina.OrdenaMatrizPaginas();
						Pagina.AtualizaContTotFl();
						XDataGeral.GravarXDataConfiguracao();
						DeclaracoesGeral.ativo.Pagina = Pagina.retornaNumeroCapa();
						Comandos.GerenciadorPagina();
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val.Commit();
				DeclaracoesGeral.bAnularEventos = false;
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
				DeclaracoesGeral.bAnularEventos = false;
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static bool ExisteFormato()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected Obj, but got Unknown
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected Obj, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected Obj, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			DeclaracoesGeral.blockFormatoID = ObjectId.Null;
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
						Entity val4 = (Entity)val.GetObject(current, (OpenMode)0);
						BlockReference blockRef = (BlockReference)(object)((val4 is BlockReference) ? val4 : null);
						if (blockRef != null && XDataGeral.PossuiXDataFormato(ref blockRef))
						{
							DeclaracoesGeral.blockFormatoID = ((DBObject)blockRef).ObjectId;
							DeclaracoesGeral.blockFormatoName = blockRef.Name;
							result = true;
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
				return result;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void ApagaDefinicaoReferencias(string nomeBloco)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected Obj, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected Obj, but got Unknown
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)1);
			if (!((SymbolTable)val2).Has(nomeBloco))
			{
				return;
			}
			BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[nomeBloco], (OpenMode)1);
			ObjectIdCollection blockReferenceIds = val3.GetBlockReferenceIds(true, true);
			foreach (object item in blockReferenceIds)
			{
				ObjectId val4 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
				BlockReference val5 = (BlockReference)val.GetObject(val4, (OpenMode)1, false, true);
				((DBObject)val5).Erase();
			}
			((DBObject)val3).Erase(true);
			DeclaracoesGeral.bAnularEventos = true;
			val.Commit();
			DeclaracoesGeral.bAnularEventos = false;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void CapturaAtributosDoFormato(ref object mAtributos)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected Obj, but got Unknown
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				BlockReference val2 = null;
				if (DeclaracoesGeral.blockFormatoID.IsValid & !DeclaracoesGeral.blockFormatoID.IsErased)
				{
					DBObject val3 = val.GetObject(DeclaracoesGeral.blockFormatoID, (OpenMode)0);
					val2 = (BlockReference)(object)((val3 is BlockReference) ? val3 : null);
					AttributeCollection attributeCollection = val2.AttributeCollection;
					foreach (object item in attributeCollection)
					{
						ObjectId val4 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
						AttributeReference val5 = (AttributeReference)val.GetObject(val4, (OpenMode)0);
						if (!DeclaracoesGeral.attProtCollection.Contains(val5.Tag) & (Operators.CompareString(Strings.Trim(((DBText)val5).TextString), "", TextCompare: true) != 0))
						{
							int num = Information.UBound((Array)mAtributos, 2) + 1;
							mAtributos = Utils.CopyArray((Array)mAtributos, new object[3, num + 1]);
							NewLateBinding.LateIndexSet(mAtributos, new object[3]
							{
								0,
								num,
								((Entity)val5).Layer
							}, null);
							NewLateBinding.LateIndexSet(mAtributos, new object[3] { 1, num, val5.Tag }, null);
							NewLateBinding.LateIndexSet(mAtributos, new object[3]
							{
								2,
								num,
								((DBText)val5).TextString
							}, null);
							((Entity)val5).Draw();
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
				throw;
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}

	private static string euxs3rkWO(string P_0, string P_1, ref object P_2)
	{
		int num = Information.UBound((Array)P_2, 2);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if ((Pagina.calculaPaginaDecimal(P_0) == Pagina.calculaPaginaDecimal(Conversions.ToString(NewLateBinding.LateIndexGet(P_2, new object[2] { 0, i }, null)))) & (Operators.CompareString(P_1.ToUpper(), NewLateBinding.LateIndexGet(P_2, new object[2] { 1, i }, null).ToString().ToUpper(), TextCompare: true) == 0))
			{
				return Conversions.ToString(NewLateBinding.LateIndexGet(P_2, new object[2] { 2, i }, null));
			}
		}
		return "";
	}

	public static void AtivaHighlightFolhaConexJumper(string sPG, int iPotencial)
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected Obj, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected Obj, but got Unknown
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected Obj, but got Unknown
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0304: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0439: Unknown result type (might be due to invalid IL or missing references)
		//IL_043e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0459: Unknown result type (might be due to invalid IL or missing references)
		//IL_045e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Unknown result type (might be due to invalid IL or missing references)
		//IL_0354: Unknown result type (might be due to invalid IL or missing references)
		//IL_0359: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_047c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0481: Unknown result type (might be due to invalid IL or missing references)
		//IL_049a: Unknown result type (might be due to invalid IL or missing references)
		//IL_049f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0387: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0409: Unknown result type (might be due to invalid IL or missing references)
		//IL_040e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0412: Unknown result type (might be due to invalid IL or missing references)
		//IL_0414: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		//IL_0296: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				bool flag = false;
				Point3d val3 = new Point3d(0.0, 0.0, 0.0);
				Point3d val4 = new Point3d(0.0, 0.0, 0.0);
				Point3d val5 = new Point3d(0.0, 0.0, 0.0);
				Point3d val6 = new Point3d(0.0, 0.0, 0.0);
				BlockTable val7 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val8 = (BlockTableRecord)val2.GetObject(((SymbolTable)val7)[BlockTableRecord.ModelSpace], (OpenMode)0);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val8.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val9 = (Entity)val2.GetObject(current, (OpenMode)0);
						if (Operators.CompareString(val9.Layer, sPG, TextCompare: true) != 0)
						{
							continue;
						}
						Polyline pl = (Polyline)(object)((val9 is Polyline) ? val9 : null);
						if (pl == null)
						{
							continue;
						}
						DeclaracoesEntidades.StructureConexao conex = default;
						if (XDataConexao.lerXDataConexao(ref pl, ref conex) && Conversions.ToDouble(conex.Potencial.ToString()) == (double)iPotencial)
						{
							((Entity)pl).Highlight();
							Extents3d value = ((Drawable)pl).Bounds.Value;
							val5 = value.MinPoint;
							value = ((Drawable)pl).Bounds.Value;
							val6 = value.MaxPoint;
							if (val3 == val4)
							{
								val3 = val5;
								val4 = val6;
							}
							if (val3.X > val5.X)
							{
								val3 = new Point3d(val5.X, val3.Y, 0.0);
							}
							if (val3.Y > val5.Y)
							{
								val3 = new Point3d(val3.X, val5.Y, 0.0);
							}
							if (val4.X < val6.X)
							{
								val4 = new Point3d(val6.X, val4.Y, 0.0);
							}
							if (val4.Y < val6.Y)
							{
								val4 = new Point3d(val4.X, val6.Y, 0.0);
							}
							flag = true;
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				if (flag)
				{
					Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
					val5 = new Point3d(0.0, 0.0, 0.0);
					val6 = new Point3d(0.0, 0.0, 0.0);
					if (!(val3.Y < val4.Y))
					{
						val5 = new Point3d(0.0, val4.Y, 0.0);
						val6 = new Point3d(0.0, val3.Y, 0.0);
					}
					else
					{
						val5 = new Point3d(0.0, val3.Y, 0.0);
						val6 = new Point3d(0.0, val4.Y, 0.0);
					}
					if (!(val3.X < val4.X))
					{
						val5 = new Point3d(val4.X, val5.Y, 0.0);
						val6 = new Point3d(val3.X, val6.Y, 0.0);
					}
					else
					{
						val5 = new Point3d(val3.X, val5.Y, 0.0);
						val6 = new Point3d(val4.X, val6.Y, 0.0);
					}
					val5 = new Point3d(val5.X - 10.0, val5.Y - 10.0, 0.0);
					val6 = new Point3d(val6.X + 10.0, val6.Y + 10.0, 0.0);
					ZoomWin(editor, val5, val6);
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

	public static void ZEntity(ObjectId ID, int iTamanho = 0)
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected Obj, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Database database = mdiActiveDocument.Database;
		Editor editor = mdiActiveDocument.Editor;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			if (ID.IsValid & !ID.IsErased)
			{
				Entity val2 = (Entity)val.GetObject(ID, (OpenMode)0);
				Extents3d value = ((Drawable)val2).Bounds.Value;
				Point3d val3 = value.MinPoint;
				double num = val3.X - (double)iTamanho;
				value = ((Drawable)val2).Bounds.Value;
				val3 = value.MinPoint;
				Point3d min = new Point3d(num, val3.Y - (double)iTamanho, 0.0);
				value = ((Drawable)val2).Bounds.Value;
				val3 = value.MaxPoint;
				double num2 = val3.X + (double)iTamanho;
				value = ((Drawable)val2).Bounds.Value;
				val3 = value.MaxPoint;
				Point3d max = new Point3d(num2, val3.Y + (double)iTamanho, 0.0);
				ZoomWin(editor, min, max);
			}
			DeclaracoesGeral.bAnularEventos = true;
			val.Commit();
			DeclaracoesGeral.bAnularEventos = false;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			val.Abort();
			ProjectData.ClearProjectError();
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void ZoomWin(Editor ed, Point3d min, Point3d max)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		Point2d val = new Point2d(min.X, min.Y);
		Point2d val2 = new Point2d(max.X, max.Y);
		ViewTableRecord val3 = new ViewTableRecord();
		try
		{
			((AbstractViewTableRecord)val3).CenterPoint = val + (val2 - val) / 2.0;
			((AbstractViewTableRecord)val3).Height = val2.Y - val.Y;
			((AbstractViewTableRecord)val3).Width = val2.X - val.X;
			ed.SetCurrentView(val3);
		}
		finally
		{
			((IDisposable)val3)?.Dispose();
		}
	}
}

using System;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.GraphicsInterface;
using ZwSoft.ZwCAD.PlottingServices;
using ZwSoft.ZwCAD.Runtime;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Eletron4;

public class clsPDF
{
	public struct structurePaginasPDF
	{
		public string paginaDWG;

		public string alternativoDWG;

		public int paginaPDF;

		public bool bSelecionado;

		public string Revisao;
	}

	private string QMYTdfNDyA;

	public string Nome_PDF
	{
		get
		{
			return QMYTdfNDyA;
		}
		set
		{
			QMYTdfNDyA = value;
		}
	}

	public static void PltPdf(string DeviceName, string MediaNAme, string Pena, string Pagina, bool bMonocromatico)
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected Obj, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected Obj, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected Obj, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Expected Obj, but got Unknown
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Invalid comparison between Unknown and I4
		//IL_030d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Expected Obj, but got Unknown
		//IL_0343: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Expected Obj, but got Unknown
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		_ = mdiActiveDocument.Editor;
		Database database = mdiActiveDocument.Database;
		Conversions.ToShort(Application.GetSystemVariable("BACKGROUNDPLOT"));
		Application.SetSystemVariable("BACKGROUNDPLOT", (object)(short)0);
		Conversions.ToShort(Application.GetSystemVariable("TILEMODE"));
		Application.SetSystemVariable("TILEMODE", (object)(short)1);
		LayoutManager current = LayoutManager.Current;
		current.GetLayoutId(current.CurrentLayout);
		PlotInfo val = new PlotInfo();
		PlotSettingsValidator current2 = PlotSettingsValidator.Current;
		PlotSettings val2 = new PlotSettings(true);
		try
		{
			Transaction val3 = database.TransactionManager.StartTransaction();
			try
			{
				DBDictionary val4 = (DBDictionary)val3.GetObject(database.LayoutDictionaryId, (OpenMode)0);
				LayoutManager current3 = LayoutManager.Current;
				DbDictionaryEnumerator enumerator = default;
				try
				{
					enumerator = val4.GetEnumerator();
					while (enumerator.MoveNext())
					{
						DBDictionaryEntry current4 = enumerator.Current;
						if (Operators.CompareString(current4.Key.ToUpper(), current3.CurrentLayout.ToUpper(), TextCompare: true) == 0)
						{
							DBObject val5 = val3.GetObject(current4.Value, (OpenMode)0, false, true);
							Layout val6 = (Layout)(object)((val5 is Layout) ? val5 : null);
							mdiActiveDocument.Editor.WriteMessage("\nCurrent layout: " + val6.LayoutName);
							val.Layout = ((DBObject)val6).ObjectId;
							((RXObject)val2).CopyFrom((RXObject)(object)val6);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				BlockReference val7 = null;
				if (DeclaracoesGeral.blockFormatoID.IsValid & !DeclaracoesGeral.blockFormatoID.IsErased)
				{
					DBObject val8 = val3.GetObject(DeclaracoesGeral.blockFormatoID, (OpenMode)0);
					val7 = (BlockReference)(object)((val8 is BlockReference) ? val8 : null);
					current2.SetPlotConfigurationName(val2, DeviceName, MediaNAme);
					current2.SetPlotType(val2, (PlotType)1);
					current2.SetUseStandardScale(val2, true);
					current2.SetPlotRotation(val2, (PlotRotation)0);
					Extents3d value = ((Drawable)val7).Bounds.Value;
					Point3d val9 = value.MinPoint;
					double x = val9.X;
					value = ((Drawable)val7).Bounds.Value;
					val9 = value.MinPoint;
					current2.SetPlotOrigin(val2, new Point2d(x, val9.Y));
					current2.SetPlotCentered(val2, true);
					current2.SetStdScaleType(val2, (StdScaleType)0);
					value = ((Drawable)val7).Bounds.Value;
					val9 = value.MinPoint;
					double x2 = val9.X;
					value = ((Drawable)val7).Bounds.Value;
					val9 = value.MinPoint;
					double y = val9.Y;
					value = ((Drawable)val7).Bounds.Value;
					val9 = value.MaxPoint;
					double x3 = val9.X;
					value = ((Drawable)val7).Bounds.Value;
					val9 = value.MaxPoint;
					Extents2d val10 = new Extents2d(x2, y, x3, val9.Y);
					current2.SetPlotWindowArea(val2, val10);
					current2.SetPlotType(val2, (PlotType)4);
					val2.PlotPlotStyles = true;
					current2.SetCurrentStyleSheet(val2, Pena);
					val.OverrideSettings = val2;
					PlotInfoValidator val11 = new PlotInfoValidator();
					val11.MediaMatchingPolicy = (MatchingPolicy)2;
					val11.Validate(val);
					Pagina += ".PDF";
					string text = Path.Combine(Path.GetTempPath(), Pagina);
					if ((int)PlotFactory.ProcessPlotState == 0)
					{
						PlotEngine val12 = PlotFactory.CreatePublishEngine();
						try
						{
							PlotProgressDialog val13 = new PlotProgressDialog(false, 1, true);
							PlotProgressDialog val14 = val13;
							try
							{
								DeclaracoesGeral.bAnularEventos = true;
								((PlotProgress)val13).IsVisible = false;
								val12.BeginPlot((PlotProgress)(object)val13, (object)null);
								val12.BeginDocument(val, mdiActiveDocument.Name, (object)null, 1, true, text);
								PlotPageInfo val15 = new PlotPageInfo();
								try
								{
									val12.BeginPage(val15, val, true, (object)null);
									val12.BeginGenerateGraphics((object)null);
									val12.EndGenerateGraphics((object)null);
									val12.EndPage((object)null);
									val12.EndDocument((object)null);
									val12.EndPlot((object)null);
								}
								finally
								{
									((IDisposable)val15)?.Dispose();
								}
								DeclaracoesGeral.bAnularEventos = false;
							}
							finally
							{
								((IDisposable)val14)?.Dispose();
							}
						}
						finally
						{
							((IDisposable)val12)?.Dispose();
						}
					}
				}
				val3.Commit();
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
			if (val2 != null)
			{
				((DisposableWrapper)val2).Dispose();
			}
			if (val != null)
			{
				((DisposableWrapper)val).Dispose();
			}
		}
	}

	public static void Hyperlink(bool bAdd)
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
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected Obj, but got Unknown
		//IL_04ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c1: Expected Obj, but got Unknown
		//IL_055b: Unknown result type (might be due to invalid IL or missing references)
		//IL_053d: Unknown result type (might be due to invalid IL or missing references)
		//IL_058e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0570: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ed: Expected Obj, but got Unknown
		//IL_05c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0503: Unknown result type (might be due to invalid IL or missing references)
		//IL_050a: Expected Obj, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_061d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0519: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		//IL_032d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Expected Obj, but got Unknown
		//IL_042b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0431: Unknown result type (might be due to invalid IL or missing references)
		//IL_037a: Unknown result type (might be due to invalid IL or missing references)
		//IL_037f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0389: Unknown result type (might be due to invalid IL or missing references)
		//IL_0390: Expected Obj, but got Unknown
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Expected Obj, but got Unknown
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_040f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f4: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
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
					int potencial = default;
					int enderecamento = default;
					short tipo = default;
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
						DBText text2 = (DBText)(object)((val5 is DBText) ? val5 : null);
						if (text2 == null)
						{
							Entity val6 = (Entity)val2.GetObject(current, (OpenMode)0);
							try
							{
								MText val7 = (MText)(object)((val6 is MText) ? val6 : null);
								try
								{
									if (val7 != null)
									{
										Entity Ent = (Entity)(object)val7;
										if (XDataRelatorio.LerXDataFurnasIndice(ref Ent))
										{
											if (!bAdd)
											{
												RemoveHyperlinkEntidade(((DBObject)val7).ObjectId);
											}
											else
											{
												text = q4hTkUuZlF(val7.Text);
												InsereHyperlinkEntidade(((DBObject)val7).ObjectId, text);
											}
										}
									}
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
							BlockReference val8 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
							try
							{
								if (val8 == null)
								{
									continue;
								}
								Declaracoes2.StructureModelo Modelo = default;
								Entity Ent = (Entity)(object)val8;
								string tipoImportado = "";
								if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref Ent, ref tipoImportado), "A", TextCompare: true) != 0)
								{
									Ent = (Entity)(object)val8;
									if (!XDataDispositivosMaster.LerXDataModelo(ref Ent, ref Modelo))
									{
										Ent = (Entity)(object)val8;
										tipoImportado = "";
										if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref Ent, ref tipoImportado), "E", TextCompare: true) != 0)
										{
											continue;
										}
										AttributeCollection attributeCollection = val8.AttributeCollection;
										foreach (object item in attributeCollection)
										{
											ObjectId val9 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
											AttributeReference val10 = (AttributeReference)val9.GetObject((OpenMode)1);
											try
											{
												string left = val10.Tag.ToUpper();
												if (Operators.CompareString(left, "ORIGEM", TextCompare: true) != 0 || Operators.CompareString(((DBText)val10).TextString.Trim(), "", TextCompare: true) == 0)
												{
													continue;
												}
												if (!bAdd)
												{
													RemoveHyperlinkEntidade(((DBObject)val10).ObjectId);
													break;
												}
												text = q4hTkUuZlF(((DBText)val10).TextString);
												InsereHyperlinkEntidade(((DBObject)val10).ObjectId, text);
												break;
											}
											finally
											{
												((IDisposable)val10)?.Dispose();
											}
										}
										continue;
									}
									AttributeCollection attributeCollection2 = val8.AttributeCollection;
									foreach (object item2 in attributeCollection2)
									{
										ObjectId val11 = ((item2 == null) ? default(ObjectId) : ((ObjectId)item2));
										AttributeReference val12 = (AttributeReference)val11.GetObject((OpenMode)1);
										try
										{
											string left2 = val12.Tag.ToUpper();
											if ((Operators.CompareString(left2, "INSERCAO", TextCompare: true) != 0 && Operators.CompareString(left2, "INSERCAONA", TextCompare: true) != 0 && Operators.CompareString(left2, "INSERCAONF", TextCompare: true) != 0) || Operators.CompareString(((DBText)val12).TextString.Trim(), "", TextCompare: true) == 0)
											{
												continue;
											}
											if (!bAdd)
											{
												RemoveHyperlinkEntidade(((DBObject)val12).ObjectId);
												break;
											}
											text = q4hTkUuZlF(((DBText)val12).TextString);
											InsereHyperlinkEntidade(((DBObject)val12).ObjectId, text);
											break;
										}
										finally
										{
											((IDisposable)val12)?.Dispose();
										}
									}
									continue;
								}
								AttributeCollection attributeCollection3 = val8.AttributeCollection;
								foreach (object item3 in attributeCollection3)
								{
									ObjectId val13 = ((item3 == null) ? default(ObjectId) : ((ObjectId)item3));
									AttributeReference val14 = (AttributeReference)val13.GetObject((OpenMode)1);
									try
									{
										string left3 = val14.Tag.ToUpper();
										if (Operators.CompareString(left3, "ORIGEM", TextCompare: true) != 0 || Operators.CompareString(((DBText)val14).TextString.Trim(), "", TextCompare: true) == 0)
										{
											continue;
										}
										if (!bAdd)
										{
											RemoveHyperlinkEntidade(((DBObject)val14).ObjectId);
											break;
										}
										text = q4hTkUuZlF(((DBText)val14).TextString);
										InsereHyperlinkEntidade(((DBObject)val14).ObjectId, text);
										break;
									}
									finally
									{
										((IDisposable)val14)?.Dispose();
									}
								}
							}
							finally
							{
								((IDisposable)val8)?.Dispose();
							}
							continue;
						}
						string handle = "";
						DeclaracoesEntidades.StructureDefinicaoPortas Def = default;
						string THandle = "";
						if (!XDataConexao.lerXDataAuxCircuito(ref text2, ref potencial, ref handle, ref enderecamento, ref tipo))
						{
							if (!XDataDispositivo.lerXDataDePara(ref text2, ref handle, ref tipo))
							{
								Entity Ent = (Entity)(object)text2;
								bool flag = XDataDispositivosMaster.LerXDataDefinicao(ref Ent, ref Def);
								text2 = (DBText)Ent;
								if (!flag)
								{
									Ent = (Entity)(object)text2;
									string tipoImportado = "";
									flag = XDataInterligacao.lerXDataAuxInterligacao(ref Ent, ref handle, ref tipo, ref THandle, ref tipoImportado);
									text2 = (DBText)Ent;
									if (!flag)
									{
										Ent = (Entity)(object)text2;
										flag = XDataRelatorio.LerXDataIndicePG(ref Ent);
										text2 = (DBText)Ent;
										if (flag)
										{
											if (!bAdd)
											{
												RemoveHyperlinkEntidade(((DBObject)val5).ObjectId);
												continue;
											}
											text = q4hTkUuZlF(text2.TextString);
											InsereHyperlinkEntidade(((DBObject)val5).ObjectId, text);
										}
									}
									else if (tipo == 2)
									{
										if (!bAdd)
										{
											RemoveHyperlinkEntidade(((DBObject)val5).ObjectId);
											continue;
										}
										text = q4hTkUuZlF(text2.TextString);
										InsereHyperlinkEntidade(((DBObject)val5).ObjectId, text);
									}
								}
								else if (!bAdd)
								{
									RemoveHyperlinkEntidade(((DBObject)val5).ObjectId);
								}
								else
								{
									text = q4hTkUuZlF(text2.TextString);
									InsereHyperlinkEntidade(((DBObject)val5).ObjectId, text);
								}
							}
							else if (!bAdd)
							{
								RemoveHyperlinkEntidade(((DBObject)val5).ObjectId);
							}
							else
							{
								text = q4hTkUuZlF(text2.TextString);
								InsereHyperlinkEntidade(((DBObject)val5).ObjectId, text);
							}
						}
						else if ((tipo == 2) | (tipo == 3))
						{
							if (!bAdd)
							{
								RemoveHyperlinkEntidade(((DBObject)val5).ObjectId);
								continue;
							}
							text = q4hTkUuZlF(text2.TextString);
							InsereHyperlinkEntidade(((DBObject)val5).ObjectId, text);
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

	public static void InsereHyperlinkEntidade(ObjectId entID, string pagina)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected Obj, but got Unknown
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				Entity val3 = (Entity)val2.GetObject(entID, (OpenMode)1);
				HyperLinkCollection hyperlinks = val3.Hyperlinks;
				HyperLink val4 = new HyperLink();
				val4.Description = "PG";
				val4.Name = "F" + pagina.ToString() + ".pdf";
				while (hyperlinks.Count > 0)
				{
					hyperlinks.RemoveAt(0);
				}
				hyperlinks.Add(val4);
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

	public static void RemoveHyperlinkEntidade(ObjectId entID)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				Entity val3 = (Entity)val2.GetObject(entID, (OpenMode)1);
				HyperLinkCollection hyperlinks = val3.Hyperlinks;
				while (hyperlinks.Count > 0)
				{
					hyperlinks.RemoveAt(0);
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

	private static string q4hTkUuZlF(string P_0)
	{
		string result = "";
		checked
		{
			switch (DeclaracoesGeral.Conf.incluirColuna)
			{
			case 4:
			case 5:
				if (Operators.CompareString(DeclaracoesGeral.Conf.PrefixoCruzInterno, "", TextCompare: true) != 0 && P_0.StartsWith(DeclaracoesGeral.Conf.PrefixoCruzInterno))
				{
					P_0 = P_0.Substring(DeclaracoesGeral.Conf.PrefixoCruzInterno.Length);
				}
				if (Operators.CompareString(DeclaracoesGeral.Conf.SeparadorCruzamento, "", TextCompare: true) != 0 && P_0.Contains(DeclaracoesGeral.Conf.SeparadorCruzamento))
				{
					int length2 = P_0.IndexOf(DeclaracoesGeral.Conf.SeparadorCruzamento);
					P_0 = P_0.Substring(0, length2);
				}
				result = P_0;
				break;
			case 0:
				if (Operators.CompareString(DeclaracoesGeral.Conf.PrefixoCruzInterno, "", TextCompare: true) != 0 && P_0.StartsWith(DeclaracoesGeral.Conf.PrefixoCruzInterno))
				{
					P_0 = P_0.Substring(DeclaracoesGeral.Conf.PrefixoCruzInterno.Length);
				}
				if (Operators.CompareString(DeclaracoesGeral.Conf.SufixoCruzInterno, "", TextCompare: true) != 0 && P_0.EndsWith(DeclaracoesGeral.Conf.SufixoCruzInterno))
				{
					P_0 = P_0.Substring(0, P_0.Length - DeclaracoesGeral.Conf.SufixoCruzInterno.Length);
				}
				result = P_0;
				break;
			case 1:
				if (Operators.CompareString(DeclaracoesGeral.Conf.PrefixoCruzInterno, "", TextCompare: true) != 0 && P_0.StartsWith(DeclaracoesGeral.Conf.PrefixoCruzInterno))
				{
					P_0 = P_0.Substring(DeclaracoesGeral.Conf.PrefixoCruzInterno.Length);
				}
				if (Operators.CompareString(DeclaracoesGeral.Conf.SeparadorCruzamento, "", TextCompare: true) != 0 && P_0.Contains(DeclaracoesGeral.Conf.SeparadorCruzamento))
				{
					int length = P_0.IndexOf(DeclaracoesGeral.Conf.SeparadorCruzamento);
					P_0 = P_0.Substring(0, length);
				}
				result = P_0;
				break;
			case 2:
				if (Operators.CompareString(DeclaracoesGeral.Conf.PrefixoCruzInterno, "", TextCompare: true) != 0 && P_0.StartsWith(DeclaracoesGeral.Conf.PrefixoCruzInterno))
				{
					P_0 = P_0.Substring(DeclaracoesGeral.Conf.PrefixoCruzInterno.Length);
				}
				if (Operators.CompareString(DeclaracoesGeral.Conf.SeparadorCruzamento, "", TextCompare: true) != 0 && P_0.Contains(DeclaracoesGeral.Conf.SeparadorCruzamento))
				{
					int num = P_0.IndexOf(DeclaracoesGeral.Conf.SeparadorCruzamento);
					P_0 = P_0.Substring(num + DeclaracoesGeral.Conf.SeparadorCruzamento.Length);
				}
				if (Operators.CompareString(DeclaracoesGeral.Conf.SufixoCruzInterno, "", TextCompare: true) != 0 && P_0.EndsWith(DeclaracoesGeral.Conf.SufixoCruzInterno))
				{
					P_0 = P_0.Substring(0, P_0.Length - DeclaracoesGeral.Conf.SufixoCruzInterno.Length);
				}
				result = P_0;
				break;
			case 3:
				if (Operators.CompareString(DeclaracoesGeral.Conf.PrefixoCruzInterno, "", TextCompare: true) != 0 && P_0.StartsWith(DeclaracoesGeral.Conf.PrefixoCruzInterno))
				{
					P_0 = P_0.Substring(DeclaracoesGeral.Conf.PrefixoCruzInterno.Length);
				}
				if (Operators.CompareString(DeclaracoesGeral.Conf.SufixoCruzInterno, "", TextCompare: true) != 0 && P_0.EndsWith(DeclaracoesGeral.Conf.SufixoCruzInterno))
				{
					P_0 = P_0.Substring(0, P_0.Length - DeclaracoesGeral.Conf.SufixoCruzInterno.Length);
				}
				result = P_0;
				break;
			}
			return result;
		}
	}

	public static void MergePDF(ref structurePaginasPDF[] mPaginas)
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected Obj, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected Obj, but got Unknown
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected Obj, but got Unknown
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		string name = mdiActiveDocument.Name;
		checked
		{
			name = name.Substring(0, name.Length - 4) + "_TEMP.pdf";
			Document val = new Document(PageSize.A3, 0f, 0f, 0f, 0f);
			FileStream fileStream = new FileStream(name, FileMode.Create);
			PdfCopy val2 = new PdfCopy(val, (Stream)fileStream);
			val.Open();
			int num = 0;
			int num2 = mPaginas.Count() - 1;
			for (int i = 1; i <= num2; i++)
			{
				if (mPaginas[i].bSelecionado)
				{
					PdfReader val3 = new PdfReader(Path.GetTempPath() + mPaginas[i].paginaDWG + ".pdf");
					int numberOfPages = val3.NumberOfPages;
					for (int j = 1; j <= numberOfPages; j++)
					{
						val2.AddPage(val2.GetImportedPage(val3, j));
					}
					num++;
					mPaginas[i].paginaPDF = num;
					val3.Close();
				}
			}
			val.Close();
			fileStream.Close();
			int num3 = mPaginas.Count() - 1;
			for (int k = 1; k <= num3; k++)
			{
				if (mPaginas[k].bSelecionado)
				{
					string path = Path.GetTempPath() + mPaginas[k].paginaDWG + ".pdf";
					if (File.Exists(path))
					{
						File.Delete(path);
					}
				}
			}
		}
	}

	public static string TrocaHyperlink(ref structurePaginasPDF[] mPaginas, ref string nomePDF)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected Obj, but got Unknown
		//IL_038d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0394: Expected Obj, but got Unknown
		//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a9: Expected Obj, but got Unknown
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected Obj, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected Obj, but got Unknown
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected Obj, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Expected Obj, but got Unknown
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Expected Obj, but got Unknown
		string result = "";
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		nomePDF = mdiActiveDocument.Name;
		checked
		{
			nomePDF = nomePDF.Substring(0, nomePDF.Length - 4) + "_TEMP.pdf";
			try
			{
				PdfReader val = new PdfReader(nomePDF);
				int numberOfPages = val.NumberOfPages;
				for (int i = 1; i <= numberOfPages; i++)
				{
					PdfDictionary pageN = val.GetPageN(i);
					PdfArray val2 = (PdfArray)PdfReader.GetPdfObject(pageN.Get(PdfName.ANNOTS));
					if (val2 == null || ((PdfObject)val2).Length <= 0)
					{
						continue;
					}
					foreach (PdfObject array in val2.ArrayList)
					{
						PdfObject val3 = array;
						PdfDictionary val4 = (PdfDictionary)PdfReader.GetPdfObject(val3);
						if (val4 == null)
						{
							continue;
						}
						string left = val4.Get(PdfName.SUBTYPE).ToString();
						if ((Operators.CompareString(left, "/Link", TextCompare: true) != 0) & (Operators.CompareString(left, "/Square", TextCompare: true) != 0))
						{
							continue;
						}
						PdfDictionary val5 = (PdfDictionary)val4.Get(PdfName.A);
						if (val5 == null)
						{
							continue;
						}
						val5.Get(PdfName.S).ToString();
						string text = val5.Get(PdfName.URI).ToString();
						string text2 = text.ToString().Substring(1);
						text2 = text2.Substring(0, text2.Length - 4);
						int num = 1;
						int num2 = mPaginas.Count() - 1;
						for (int j = 1; j <= num2; j++)
						{
							if (!((DeclaracoesGeral.Conf.incluirColuna == 0) | (DeclaracoesGeral.Conf.incluirColuna == 1) | (DeclaracoesGeral.Conf.incluirColuna == 2)))
							{
								if ((DeclaracoesGeral.Conf.incluirColuna == 3) | (DeclaracoesGeral.Conf.incluirColuna == 4) | (DeclaracoesGeral.Conf.incluirColuna == 5))
								{
									if ((Operators.CompareString(mPaginas[j].alternativoDWG, "", TextCompare: true) != 0) & (Operators.CompareString(mPaginas[j].alternativoDWG, text2, TextCompare: true) == 0))
									{
										num = mPaginas[j].paginaPDF;
										break;
									}
									if ((Operators.CompareString(mPaginas[j].alternativoDWG, "", TextCompare: true) == 0) & (Operators.CompareString(mPaginas[j].paginaDWG, text2, TextCompare: true) == 0))
									{
										num = mPaginas[j].paginaPDF;
										break;
									}
								}
							}
							else if (Operators.CompareString(mPaginas[j].paginaDWG, text2, TextCompare: true) == 0)
							{
								num = mPaginas[j].paginaPDF;
								break;
							}
						}
						PdfDictionary val6 = (PdfDictionary)val4.Get(PdfName.A);
						if (((object)val6.Get(PdfName.S)).Equals((object)PdfName.URI))
						{
							val6.Remove(PdfName.S);
							val6.Put(PdfName.S, (PdfObject)(object)PdfName.GOTO);
							PdfArray val7 = new PdfArray();
							val7.Add((PdfObject)(object)val.GetPageOrigRef(num));
							val7.Add((PdfObject)(object)PdfName.FIT);
							val6.Put(PdfName.D, (PdfObject)(object)val7);
						}
					}
				}
				string name = mdiActiveDocument.Name;
				name = name.Substring(0, name.Length - 4) + ".pdf";
				Document val8 = new Document(PageSize.A3, 0f, 0f, 0f, 0f);
				FileStream fileStream = new FileStream(name, FileMode.Create);
				PdfCopy val9 = new PdfCopy(val8, (Stream)fileStream);
				val8.Open();
				val8.AddAuthor("Elétron - Cadgraph");
				val8.AddCreator("Exportador PDF Cadgraph");
				val8.AddKeywords("cadgraph eletron diaglog arqnet");
				int numberOfPages2 = val.NumberOfPages;
				for (int k = 1; k <= numberOfPages2; k++)
				{
					val9.AddPage(val9.GetImportedPage(val, k));
				}
				val8.Close();
				fileStream.Close();
				val.Close();
				result = name;
			}
			catch (IOException ex)
			{
				ProjectData.SetProjectError(ex);
				IOException ex2 = ex;
				Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical);
				ProjectData.ClearProjectError();
			}
			catch (NullReferenceException ex3)
			{
				ProjectData.SetProjectError(ex3);
				NullReferenceException ex4 = ex3;
				Interaction.MsgBox(ex4.Message, MsgBoxStyle.Critical);
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}
}

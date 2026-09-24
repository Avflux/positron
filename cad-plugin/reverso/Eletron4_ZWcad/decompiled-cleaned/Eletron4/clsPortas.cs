using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
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

public class clsPortas
{
	public static void RemoveUmaHandle(ref object[,] PortasSelecionadas, ref Declaracoes2.MModeloDePortas[] mPortasUsadas)
	{
		checked
		{
			try
			{
				int num = Information.UBound(PortasSelecionadas, 2);
				for (int i = 0; i <= num; i++)
				{
					Conversions.ToString(PortasSelecionadas[0, i]);
					int num2 = Information.UBound(mPortasUsadas);
					for (int j = 0; j <= num2; j++)
					{
						new List<string>();
						if (mPortasUsadas[j].HandlePorta != null && Operators.ConditionalCompareObjectEqual(PortasSelecionadas[1, i], "E", TextCompare: true))
						{
							DivideHandles(ref mPortasUsadas[j].HandlePorta, Conversions.ToString(PortasSelecionadas[0, i]), ref mPortasUsadas[j].PaginaPorta);
						}
						if (mPortasUsadas[j].HandleDef != null && Operators.ConditionalCompareObjectEqual(PortasSelecionadas[1, i], "T", TextCompare: true))
						{
							DivideHandles(ref mPortasUsadas[j].HandleDef, Conversions.ToString(PortasSelecionadas[0, i]), ref mPortasUsadas[j].PaginaDef);
						}
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
		}
	}

	public static void DivideHandles(ref string sTodosHandle, string sRemoverHandle, ref string sTodasPaginas)
	{
		if (Operators.CompareString(sTodosHandle, null, TextCompare: true) == 0)
		{
			sTodosHandle = "";
		}
		if (Operators.CompareString(sTodasPaginas, null, TextCompare: true) == 0)
		{
			sTodasPaginas = "";
		}
		string[] array = sTodosHandle.Split('|');
		string[] array2 = sTodasPaginas.Split('|');
		sTodosHandle = "";
		sTodasPaginas = "";
		int num = Information.UBound(array);
		for (int i = 0; i <= num; i = checked(i + 1))
		{
			if (Operators.CompareString(array[i].Trim(), "", TextCompare: true) != 0 && Operators.CompareString(array[i].Trim(), sRemoverHandle, TextCompare: true) != 0)
			{
				sTodosHandle = sTodosHandle + array[i].Trim() + "| ";
				sTodasPaginas = sTodasPaginas + array2[i].Trim() + "| ";
			}
		}
	}

	public static void MarcaOsContatosUsadosNoDG(int Indice, string sNome, ref DataGridView dg, ref Declaracoes2.MModeloDePortas[] mPortasUsadas, int indicePaineSel)
	{
		checked
		{
			try
			{
				int num = dg.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dg.Rows[i].Cells[8].Style.BackColor = Color.LightGreen;
					dg.Rows[i].Cells[8].Style.ForeColor = Color.Black;
					dg.Rows[i].Cells[9].Style.BackColor = Color.LightGreen;
					dg.Rows[i].Cells[9].Style.ForeColor = Color.Black;
					int num2 = Information.UBound(mPortasUsadas);
					for (int j = 0; j <= num2; j++)
					{
						if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(dg.Rows[i].Cells[1].Value, mPortasUsadas[j].IndiceModelo, TextCompare: true), mPortasUsadas[j].IndicePN == indicePaineSel)) && Operators.CompareString(sNome, mPortasUsadas[j].NomeModelo, TextCompare: true) == 0 && Operators.ConditionalCompareObjectEqual(dg.Rows[i].Cells[0].Value, mPortasUsadas[j].IndiceDaPorta, TextCompare: true))
						{
							int num3 = ContaContatos(mPortasUsadas[j].PaginaPorta);
							dg.Rows[i].Cells[8].Value = clsDispositivoMascaras.TiraCaracterDoTexto(ref mPortasUsadas[j].PaginaPorta, "|");
							if (num3 == 0)
							{
								dg.Rows[i].Cells[8].Style.BackColor = Color.LightGreen;
								dg.Rows[i].Cells[8].Style.ForeColor = Color.Black;
							}
							else if (num3 == 1)
							{
								dg.Rows[i].Cells[8].Style.BackColor = Color.LightCoral;
								dg.Rows[i].Cells[8].Style.ForeColor = Color.Black;
							}
							else
							{
								dg.Rows[i].Cells[8].Style.BackColor = Color.Red;
								dg.Rows[i].Cells[8].Style.ForeColor = Color.White;
							}
							num3 = ContaContatos(mPortasUsadas[j].PaginaDef);
							dg.Rows[i].Cells[9].Value = clsDispositivoMascaras.TiraCaracterDoTexto(ref mPortasUsadas[j].PaginaDef, "|");
							switch (num3)
							{
							case 0:
								dg.Rows[i].Cells[9].Style.BackColor = Color.LightGreen;
								dg.Rows[i].Cells[8].Style.ForeColor = Color.Black;
								break;
							case 1:
								dg.Rows[i].Cells[9].Style.BackColor = Color.LightCoral;
								dg.Rows[i].Cells[8].Style.ForeColor = Color.Black;
								break;
							default:
								dg.Rows[i].Cells[9].Style.BackColor = Color.Red;
								dg.Rows[i].Cells[9].Style.ForeColor = Color.White;
								break;
							}
						}
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
		}
	}

	public static int ContaContatos(string sTexto)
	{
		int num = 0;
		checked
		{
			if (Operators.CompareString(sTexto, "", TextCompare: true) != 0)
			{
				int num2 = Strings.Len(sTexto);
				for (int i = 1; i <= num2; i++)
				{
					char c = Conversions.ToChar(Strings.Mid(sTexto, i, 1));
					if (Operators.CompareString(Conversions.ToString(c), "|", TextCompare: true) == 0)
					{
						num++;
					}
				}
			}
			return num;
		}
	}

	public static void selecionaUmaPortaInserida(ref DeclaracoesEntidades.StructurePortas myBL, ref int iPainel, ref BlockReference ent)
	{
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected Obj, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Expected Obj, but got Unknown
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected Obj, but got Unknown
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected Obj, but got Unknown
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
				ObjectId val3 = clsDispositivo.selDispositivoPrincipal(ref ptInsert, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1133]));
				if (!val3.IsNull)
				{
					ent = (BlockReference)val2.GetObject(val3, (OpenMode)0);
					if (!Information.IsDBNull(ent))
					{
						Entity ent2 = (Entity)(object)ent;
						string tipoImportado = "";
						string left = XDataDispositivo.verificaTipoDispositivo(ref ent2, ref tipoImportado);
						ent = (BlockReference)ent2;
						if (Operators.CompareString(left, "E", TextCompare: true) == 0)
						{
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref ent);
							DeclaracoesEntidades.StructurePortas structurePortas = ((obj == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj));
							((Entity)ent).Highlight();
							myBL = structurePortas;
							DeclaracoesEntidades.StructureMascara structureMascara = default;
							Entity val4 = (Entity)Geral.HandleToObject(myBL.HandleDaMascara);
							try
							{
								if (val4 != null)
								{
									BlockReference blockRef = (BlockReference)val4;
									object obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
									structureMascara = ((obj2 == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj2));
									iPainel = structureMascara.Painel;
									if (Operators.CompareString(myBL.Nome1.Trim(), "", TextCompare: true) == 0)
									{
										myBL.Nome1 = structureMascara.Nome1;
										myBL.Nome2 = structureMascara.Nome2;
									}
								}
							}
							finally
							{
								((IDisposable)val4)?.Dispose();
							}
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
		PointMonitorToolTips.StartMonitor();
	}

	public static void IndefinePortasApagadas(int indexModelo, int indexPorta)
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
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
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
							try
							{
								BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
								try
								{
									if (val6 == null)
									{
										continue;
									}
									Entity ent = (Entity)(object)val6;
									string tipoImportado = "";
									string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
									if (Operators.CompareString(left, "E", TextCompare: true) == 0)
									{
										BlockReference blockRef = val6;
										object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
										DeclaracoesEntidades.StructurePortas structurePortas = ((obj == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj));
										if ((structurePortas.indiceDoModelo == indexModelo) & (structurePortas.indiceDaPorta == indexPorta))
										{
											IndefineUmaPorta(((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString(), bLimpaTudo: true);
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
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
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
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			throw;
		}
	}

	public static void EditaUmaPorta(int indexModelo, int indexPorta, string sEFC, string sTerminais, string sRegua, string sBornes)
	{
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Expected Obj, but got Unknown
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Expected Obj, but got Unknown
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected Obj, but got Unknown
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Expected Obj, but got Unknown
		checked
		{
			try
			{
				List<string> lTerminais = new List<string>();
				Geral.DivideTerminais(ref lTerminais, sTerminais, bRepete: true);
				List<string> lTerminais2 = new List<string>();
				Geral.DivideTerminais(ref lTerminais2, sBornes, bRepete: true);
				List<string> lTerminais3 = new List<string>();
				Geral.DivideTerminais(ref lTerminais3, sRegua, bRepete: true);
				if (lTerminais3.Count > 0)
				{
					if (lTerminais3.Count != lTerminais2.Count)
					{
						if ((lTerminais3.Count == 1) & (lTerminais2.Count > 1))
						{
							int count = lTerminais2.Count;
							for (int i = 2; i <= count; i++)
							{
								lTerminais3.Add(lTerminais3[0]);
							}
						}
						int num = lTerminais2.Count - 1;
						for (int j = 0; j <= num; j++)
						{
							if (lTerminais2[j].StartsWith("*"))
							{
								lTerminais3[j] = "*" + lTerminais3[j];
							}
						}
					}
					else
					{
						int num2 = lTerminais2.Count - 1;
						for (int k = 0; k <= num2; k++)
						{
							if (!lTerminais2[k].StartsWith("*"))
							{
								lTerminais3[k] = lTerminais3[k];
							}
							else
							{
								lTerminais3[k] = "*" + lTerminais3[k];
							}
						}
					}
				}
				int num3 = lTerminais2.Count - 1;
				for (int l = 0; l <= num3; l++)
				{
					lTerminais2[l] = lTerminais2[l].Replace("*", "");
				}
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
								try
								{
									BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
									try
									{
										if (val6 == null)
										{
											continue;
										}
										Entity ent = (Entity)(object)val6;
										string tipoImportado = "";
										string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
										if (Operators.CompareString(left, "E", TextCompare: true) != 0)
										{
											continue;
										}
										BlockReference blockRef = val6;
										object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
										DeclaracoesEntidades.StructurePortas structurePortas = ((obj == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj));
										if (!((structurePortas.indiceDoModelo == indexModelo) & (structurePortas.indiceDaPorta == indexPorta)))
										{
											continue;
										}
										((DBObject)val6).UpgradeOpen();
										AttributeCollection attributeCollection = val6.AttributeCollection;
										foreach (object item in attributeCollection)
										{
											object objectValue = RuntimeHelpers.GetObjectValue(item);
											AttributeReference val7 = (AttributeReference)NewLateBinding.LateGet(objectValue, null, "GetObject", new object[1] { (object)(OpenMode)1 }, null, null, null);
											string text = ((DBText)val7).TextString;
											if (Operators.CompareString(val7.Tag, "EFC", TextCompare: true) != 0)
											{
												if (Versioned.IsNumeric(Strings.Mid(val7.Tag, 2, Strings.Len(val7.Tag))))
												{
													int num4 = Conversions.ToInteger(Strings.Mid(val7.Tag, 2, Strings.Len(val7.Tag)));
													int index = Conversions.ToInteger(Strings.Mid(val7.Tag, 2, Strings.Len(val7.Tag))) - 1;
													if ((Operators.CompareString(Strings.Mid(val7.Tag, 1, 1), "T", TextCompare: true) == 0) & Versioned.IsNumeric(num4))
													{
														text = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
														if (num4 <= lTerminais.Count && Operators.CompareString(lTerminais[index], "", TextCompare: true) != 0)
														{
															text = lTerminais[index];
														}
													}
													if ((Operators.CompareString(Strings.Mid(val7.Tag, 1, 1), "B", TextCompare: true) == 0) & Versioned.IsNumeric(num4))
													{
														text = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
														if (num4 <= lTerminais2.Count && Operators.CompareString(lTerminais2[index], "", TextCompare: true) != 0)
														{
															text = lTerminais2[index];
														}
													}
													if ((Operators.CompareString(Strings.Mid(val7.Tag, 1, 1), "R", TextCompare: true) == 0) & Versioned.IsNumeric(num4))
													{
														((Entity)val7).Visible = false;
														if (num4 <= lTerminais3.Count)
														{
															text = lTerminais3[index].Trim();
															text = text.Replace("*", "");
															if (lTerminais3[index].Contains("*"))
															{
																((Entity)val7).Visible = true;
															}
														}
													}
												}
											}
											else
											{
												text = sEFC;
											}
											if (text == null)
											{
												text = "";
											}
											((DBText)val7).TextString = text;
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
						hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
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
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				throw;
			}
		}
	}

	public static void EditaTodasPortas(Declaracoes2.MModeloDePortas[] mPORTAS)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected Obj, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected Obj, but got Unknown
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e6: Expected Obj, but got Unknown
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
						int num = 0;
						BlockTableRecordEnumerator enumerator = default;
						try
						{
							enumerator = val4.GetEnumerator();
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.Current;
								bool flag = true;
								Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
								try
								{
									BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
									try
									{
										if (val6 != null)
										{
											Entity ent = (Entity)(object)val6;
											string tipoImportado = "";
											string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
											if (Operators.CompareString(left, "E", TextCompare: true) == 0)
											{
												BlockReference blockRef = val6;
												object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
												DeclaracoesEntidades.StructurePortas structurePortas = ((obj == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj));
												if (structurePortas.indiceDaPorta == 0)
												{
													flag = false;
												}
												else
												{
													int num2 = Information.UBound(mPORTAS);
													for (int i = 1; i <= num2; i++)
													{
														if (!((structurePortas.indiceDoModelo == mPORTAS[i].IndiceModelo) & (structurePortas.indiceDaPorta == mPORTAS[i].IndiceDaPorta)))
														{
															continue;
														}
														flag = false;
														string text = clsMascara.BuscaNomeDaMascara(structurePortas.HandleDaMascara);
														string text2 = "";
														if (Operators.CompareString(structurePortas.handleDaDefinicao, "", TextCompare: true) != 0)
														{
															text2 = clsTextos.EncontraPaginaDoTexto(structurePortas.handleDaDefinicao);
														}
														string[] array = mPORTAS[i].sTerminais.Split(';');
														string[] array2 = mPORTAS[i].sBornes.Split(';');
														string[] array3 = mPORTAS[i].sBornes.Split(';');
														int num3 = array2.Count() - 1;
														for (int j = 0; j <= num3; j++)
														{
															if (Operators.CompareString(Strings.Mid(array2[j], 1, 1), "*", TextCompare: true) != 0)
															{
																array3[j] = "";
																continue;
															}
															array3[j] = "*";
															array2[j] = Strings.Mid(array2[j], 2, Strings.Len(array2[j]));
														}
														((DBObject)val6).UpgradeOpen();
														AttributeCollection attributeCollection = val6.AttributeCollection;
														foreach (object item in attributeCollection)
														{
															object objectValue = RuntimeHelpers.GetObjectValue(item);
															AttributeReference val7 = (AttributeReference)NewLateBinding.LateGet(objectValue, null, "GetObject", new object[1] { (object)(OpenMode)1 }, null, null, null);
															string text3 = ((DBText)val7).TextString;
															if (Operators.CompareString(val7.Tag, "NOME1", TextCompare: true) != 0)
															{
																if (Operators.CompareString(val7.Tag, "ORIGEM", TextCompare: true) != 0)
																{
																	if (Operators.CompareString(val7.Tag, "EFC", TextCompare: true) != 0)
																	{
																		if (Versioned.IsNumeric(Strings.Mid(val7.Tag, 2, Strings.Len(val7.Tag))))
																		{
																			int num4 = Conversions.ToInteger(Strings.Mid(val7.Tag, 2, Strings.Len(val7.Tag)));
																			int num5 = Conversions.ToInteger(Strings.Mid(val7.Tag, 2, Strings.Len(val7.Tag))) - 1;
																			if ((Operators.CompareString(Strings.Mid(val7.Tag, 1, 1), "T", TextCompare: true) == 0) & Versioned.IsNumeric(num4))
																			{
																				text3 = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
																				if (num4 <= array.Count() && Operators.CompareString(array[num5], "", TextCompare: true) != 0)
																				{
																					text3 = array[num5];
																				}
																			}
																			if ((Operators.CompareString(Strings.Mid(val7.Tag, 1, 1), "B", TextCompare: true) == 0) & Versioned.IsNumeric(num4))
																			{
																				text3 = " ";
																				if (num4 <= array2.Count())
																				{
																					text3 = array2[num5];
																				}
																			}
																			if ((Operators.CompareString(Strings.Mid(val7.Tag, 1, 1), "R", TextCompare: true) == 0) & Versioned.IsNumeric(num4))
																			{
																				((Entity)val7).Visible = false;
																				text3 = mPORTAS[i].sRegua;
																				if (num4 <= array3.Count() && Operators.CompareString(array3[num5], "*", TextCompare: true) == 0)
																				{
																					((Entity)val7).Visible = true;
																				}
																			}
																		}
																	}
																	else
																	{
																		text3 = mPORTAS[i].sEFC;
																	}
																}
																else
																{
																	text3 = text2;
																}
															}
															else
															{
																text3 = text;
															}
															if (text3 == null)
															{
																text3 = "";
															}
															((DBText)val7).TextString = text3;
														}
													}
												}
												if (flag)
												{
													IndefineUmaPorta(((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString(), bLimpaTudo: true);
												}
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
						val2.Commit();
						DeclaracoesGeral.bAnularEventos = false;
						DeclaracoesGeral._uscPagina.pbFim();
						hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
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
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				throw;
			}
		}
	}

	public static void IndefinePortasModelo(string[] mPortas)
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
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected Obj, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
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
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)1);
						try
						{
							Entity ent = val5;
							string tipoImportado = "";
							string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
							if (Operators.CompareString(left, "E", TextCompare: true) != 0)
							{
								continue;
							}
							BlockReference blockRef = (BlockReference)val5;
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
							DeclaracoesEntidades.StructurePortas structurePortas = ((obj == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj));
							int num = Information.UBound(mPortas);
							for (int i = 1; i <= num; i = checked(i + 1))
							{
								if (Operators.CompareString(structurePortas.HandleDaMascara, mPortas[i], TextCompare: true) == 0)
								{
									IndefineUmaPorta(((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString(), bLimpaTudo: true);
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
	}

	public static void EditaAsPortasDeUmaMascara(string sHandle, bool bAlternativoVisivel)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected Obj, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected Obj, but got Unknown
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected Obj, but got Unknown
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				DeclaracoesEntidades.StructureMascara structureMascara = default;
				ObjectId val3 = clsBlocos.RetornaID_Bloco(sHandle);
				if (val3.IsValid)
				{
					BlockReference blockRef = (BlockReference)val2.GetObject(val3, (OpenMode)0);
					object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
					structureMascara = ((obj == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj));
					string text = structureMascara.Nome1;
					if (Operators.CompareString(structureMascara.Nome2, "", TextCompare: true) != 0)
					{
						text = text + "/" + structureMascara.Nome2;
					}
					BlockTable val4 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)0);
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val5.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val6 = (Entity)val2.GetObject(current, (OpenMode)0);
							try
							{
								BlockReference val7 = (BlockReference)(object)((val6 is BlockReference) ? val6 : null);
								try
								{
									if (val7 == null)
									{
										continue;
									}
									Entity ent = (Entity)(object)val7;
									string tipoImportado = "";
									string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
									if (Operators.CompareString(left, "E", TextCompare: true) == 0)
									{
										DeclaracoesEntidades.StructurePortas structurePortas = default;
										BlockReference blockRef2 = val7;
										object obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef2);
										structurePortas = ((obj2 == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj2));
										if (structurePortas.indiceDoModelo == structureMascara.indexModelo && Operators.CompareString(structurePortas.HandleDaMascara, sHandle, TextCompare: true) == 0)
										{
											bool flag = false;
											tipoImportado = ((object)((DBObject)val7).Handle/*cast due to constrained. prefix*/).ToString();
											flag = clsBlocos.AtributoVisivelDeUmBloco(ref tipoImportado, "NOME1");
											tipoImportado = ((object)((DBObject)val7).Handle/*cast due to constrained. prefix*/).ToString();
											clsBlocos.EditaUmAtributoDeUmBloco(ref tipoImportado, "NOME1", text, flag);
											tipoImportado = ((object)((DBObject)val7).Handle/*cast due to constrained. prefix*/).ToString();
											clsBlocos.EditaUmAtributoDeUmBloco(ref tipoImportado, "ALTERNATIVO", structureMascara.Alternativo, bAlternativoVisivel);
											structurePortas.Nome1 = structureMascara.Nome1;
											structurePortas.Nome2 = structureMascara.Nome2;
											structurePortas.Alternativo = structureMascara.Alternativo;
											ent = (Entity)(object)val7;
											XDataDispositivosMaster.GravarXDataPorta(ref ent, ref structurePortas);
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
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
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

	public static void EditaOsIndicesDoModeloDeMascara(string sHandleDaMascara, int iIndice)
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
							BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
							try
							{
								Entity Ent;
								if (val6 == null)
								{
									DBText val7 = (DBText)(object)((val5 is DBText) ? val5 : null);
									try
									{
										if (val7 != null)
										{
											DeclaracoesEntidades.StructureDefinicaoPortas Def = default;
											Ent = (Entity)(object)val7;
											if (XDataDispositivosMaster.LerXDataDefinicao(ref Ent, ref Def) && Operators.CompareString(Def.Nome.ToUpper(), "DEFINICAO", TextCompare: true) == 0 && Operators.CompareString(Def.HandleDaMascara, sHandleDaMascara, TextCompare: true) == 0)
											{
												Def.indiceDoModelo = iIndice;
												Ent = (Entity)(object)val7;
												XDataDispositivosMaster.GravarXDataDefinicao(ref Ent, ref Def);
											}
										}
									}
									finally
									{
										((IDisposable)val7)?.Dispose();
									}
									continue;
								}
								Ent = (Entity)(object)val6;
								string tipoImportado = "";
								string left = XDataDispositivo.verificaTipoDispositivo(ref Ent, ref tipoImportado);
								if (Operators.CompareString(left, "E", TextCompare: true) == 0)
								{
									BlockReference blockRef = val6;
									object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
									DeclaracoesEntidades.StructurePortas Porta = ((obj == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj));
									if (Operators.CompareString(Porta.HandleDaMascara, sHandleDaMascara, TextCompare: true) == 0)
									{
										Porta.indiceDoModelo = iIndice;
										Ent = (Entity)(object)val6;
										XDataDispositivosMaster.GravarXDataPorta(ref Ent, ref Porta);
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

	public static void ApagaUmaDefinicao(DBText texto)
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				string sValor = "";
				if (texto != null)
				{
					DeclaracoesEntidades.StructureDefinicaoPortas Def = default;
					Entity Ent = (Entity)(object)texto;
					bool flag = XDataDispositivosMaster.LerXDataDefinicao(ref Ent, ref Def);
					texto = (DBText)Ent;
					if (flag)
					{
						clsBlocos.EditaUmAtributoDeUmBloco(ref Def.handleDaPorta, "ORIGEM", sValor);
					}
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

	public static void SincronizaPortas(bool bMarcaErros = true, bool bProgress = true)
	{
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected Obj, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected Obj, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected Obj, but got Unknown
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		//IL_035d: Expected Obj, but got Unknown
		//IL_042b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0430: Unknown result type (might be due to invalid IL or missing references)
		//IL_051a: Unknown result type (might be due to invalid IL or missing references)
		//IL_051f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0570: Unknown result type (might be due to invalid IL or missing references)
		//IL_0575: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0322: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		DeclaracoesGeral.Reguas RH = default;
		bool flag = false;
		DeclaracoesGeral.Reguas RH2 = default;
		bool flag2 = false;
		flag = XDataGeral.LeXDataReguaH(ref RH);
		flag2 = XDataGeral.LeXDataReguaV(ref RH2);
		SyncPorta[] array = new SyncPorta[1];
		SyncDef[] array2 = new SyncDef[1];
		string[,] array3 = new string[2, 1];
		string[,] array4 = new string[2, 1];
		if (bProgress)
		{
			DeclaracoesGeral._uscPagina.Quantidade = 3;
			DeclaracoesGeral._uscPagina.pbIniciar();
		}
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
								try
								{
									Entity ent = val5;
									string tipoImportado = "";
									if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado), "E", TextCompare: true) != 0)
									{
										DBText val6 = (DBText)(object)((val5 is DBText) ? val5 : null);
										try
										{
											if (val6 == null)
											{
												continue;
											}
											DeclaracoesEntidades.StructureDefinicaoPortas Def = new DeclaracoesEntidades.StructureDefinicaoPortas
											{
												Nome = ""
											};
											bool flag3 = true;
											ent = (Entity)(object)val6;
											XDataDispositivosMaster.LerXDataDefinicao(ref ent, ref Def);
											if (Operators.CompareString(Def.Nome.ToUpper(), "DEFINICAO", TextCompare: true) != 0)
											{
												continue;
											}
											int num = Information.UBound(array2);
											for (int i = 1; i <= num; i++)
											{
												if (((Operators.CompareString(array2[i].HandleMasc, Def.HandleDaMascara, TextCompare: true) == 0) & (Conversions.ToDouble(array2[i].indiceModelo) == (double)Def.indiceDoModelo) & (Conversions.ToDouble(array2[i].indiceTexto) == (double)Def.indiceDaPorta)) && Conversions.ToDouble(array2[i].indiceTexto) != 0.0)
												{
													long num2 = Information.UBound(array4, 2) + 1;
													array4 = (string[,])Utils.CopyArray(array4, new string[2, (int)num2 + 1]);
													array4[0, (int)num2] = ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString();
													array4[1, (int)num2] = val5.Layer;
													flag3 = false;
													break;
												}
											}
											if (flag3)
											{
												long num2 = Information.UBound(array2) + 1;
												array2 = (SyncDef[])Utils.CopyArray(array2, new SyncDef[(int)num2 + 1]);
												array2[(int)num2].HandleMasc = Def.HandleDaMascara;
												array2[(int)num2].indiceModelo = Conversions.ToString(Def.indiceDoModelo);
												array2[(int)num2].indiceTexto = Conversions.ToString(Def.indiceDaPorta);
												array2[(int)num2].HandleTexto = ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString();
												ref SyncDef reference = ref array2[(int)num2];
												string pagina = val5.Layer.ToString();
												ent = val5;
												reference.Pagina = Pagina.montaCruzamentoPagina(pagina, Pagina.calculaLinhaColuna(ref ent, ref RH, ref RH2, flag, flag2));
												array2[(int)num2].MyHandle = ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString();
											}
										}
										finally
										{
											((IDisposable)val6)?.Dispose();
										}
										continue;
									}
									DeclaracoesEntidades.StructurePortas structurePortas = default;
									BlockReference blockRef = (BlockReference)val5;
									object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
									structurePortas = ((obj == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj));
									bool flag4 = true;
									int num3 = Information.UBound(array);
									for (int j = 0; j <= num3; j++)
									{
										if ((Operators.CompareString(array[j].HandleMasc, structurePortas.HandleDaMascara, TextCompare: true) == 0) & (Conversions.ToDouble(array[j].indiceModelo) == (double)structurePortas.indiceDoModelo) & (Conversions.ToDouble(array[j].indicePorta) == (double)structurePortas.indiceDaPorta))
										{
											long num2 = Information.UBound(array3, 2) + 1;
											array3 = (string[,])Utils.CopyArray(array3, new string[2, (int)num2 + 1]);
											array3[0, (int)num2] = ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString();
											array3[1, (int)num2] = val5.Layer;
											flag4 = false;
											break;
										}
									}
									if (flag4)
									{
										long num2 = Information.UBound(array) + 1;
										array = (SyncPorta[])Utils.CopyArray(array, new SyncPorta[(int)num2 + 1]);
										array[(int)num2].HandleMasc = structurePortas.HandleDaMascara;
										array[(int)num2].indiceModelo = Conversions.ToString(structurePortas.indiceDoModelo);
										array[(int)num2].indicePorta = Conversions.ToString(structurePortas.indiceDaPorta);
										array[(int)num2].HandlePorta = ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString();
										ref SyncPorta reference2 = ref array[(int)num2];
										string pagina2 = val5.Layer.ToString();
										ent = val5;
										reference2.Pagina = Pagina.montaCruzamentoPagina(pagina2, Pagina.calculaLinhaColuna(ref ent, ref RH, ref RH2, flag, flag2));
										array[(int)num2].MyHandle = ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString();
									}
									if (structurePortas.indiceDaPorta == 0)
									{
										EditaUmaPorta(structurePortas.indiceDoModelo, structurePortas.indiceDaPorta, "", DeclaracoesGeral.Conf.CaracterTerminalIndefinido, "", "");
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
						if (bProgress)
						{
							DeclaracoesGeral._uscPagina.pbPasso();
						}
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
					finally
					{
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
			int num4 = Information.UBound(array);
			for (int k = 1; k <= num4; k++)
			{
				clsBlocos.IndefineCruzamentoDoBloco(ref array[k].HandlePorta);
			}
			if (bProgress)
			{
				DeclaracoesGeral._uscPagina.pbPasso();
			}
			int num5 = Information.UBound(array2);
			for (int l = 1; l <= num5; l++)
			{
				string sValor = "( )";
				clsBlocos.EditaUmTexto(ref array2[l].HandleTexto, sValor);
			}
			if (bProgress)
			{
				DeclaracoesGeral._uscPagina.pbPasso();
			}
			if ((Information.UBound(array) > 0) & (Information.UBound(array2) > 0))
			{
				int num6 = Information.UBound(array);
				for (int m = 1; m <= num6; m++)
				{
					int num7 = Information.UBound(array2);
					for (int n = 1; n <= num7; n++)
					{
						if ((Operators.CompareString(array[m].HandleMasc, array2[n].HandleMasc, TextCompare: true) == 0) & (Operators.CompareString(array[m].indiceModelo, array2[n].indiceModelo, TextCompare: true) == 0) & (Operators.CompareString(array[m].indicePorta, array2[n].indiceTexto, TextCompare: true) == 0))
						{
							clsBlocos.AtualizaValorDeUmAtributo(ref array[m].HandlePorta, "ORIGEM", array2[n].Pagina);
							GravaHandleNaPorta(ref array[m].MyHandle, ref array2[n].MyHandle);
							clsBlocos.EditaUmTexto(ref array2[n].HandleTexto, array[m].Pagina);
							GravaHandleNaDefinicao(ref array2[n].MyHandle, ref array[m].MyHandle);
							break;
						}
					}
				}
			}
			if (bProgress)
			{
				DeclaracoesGeral._uscPagina.pbFim();
			}
		}
	}

	public static void GravaHandleNaPorta(ref string sHandlePorta, ref string sHandleTexto)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected Obj, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected Obj, but got Unknown
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		_ = Application.DocumentManager.MdiActiveDocument.Editor;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			ObjectId val2 = Geral.HandleToID(sHandlePorta);
			if (val2.IsValid)
			{
				Entity val3 = (Entity)val.GetObject(val2, (OpenMode)0);
				try
				{
					DeclaracoesEntidades.StructurePortas structurePortas = default;
					BlockReference blockRef = (BlockReference)val3;
					object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
					structurePortas = ((obj == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj));
					structurePortas.handleDaDefinicao = sHandleTexto;
					Entity ent = val3;
					XDataDispositivosMaster.GravarXDataPorta(ref ent, ref structurePortas);
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
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void GravaHandleNaDefinicao(ref string sHandleDefinicao, ref string sHandlePorta)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected Obj, but got Unknown
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		_ = Application.DocumentManager.MdiActiveDocument.Editor;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			ObjectId val2 = Geral.HandleToID(sHandleDefinicao);
			if (val2.IsValid)
			{
				Entity val3 = (Entity)val.GetObject(val2, (OpenMode)0);
				try
				{
					DBText val4 = (DBText)(object)((val3 is DBText) ? val3 : null);
					try
					{
						if (val4 != null)
						{
							DeclaracoesEntidades.StructureDefinicaoPortas Def = default;
							Entity Ent = (Entity)(object)val4;
							if (XDataDispositivosMaster.LerXDataDefinicao(ref Ent, ref Def))
							{
								Def.handleDaPorta = sHandlePorta;
								Ent = (Entity)(object)val4;
								XDataDispositivosMaster.GravarXDataDefinicao(ref Ent, ref Def);
							}
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
			DeclaracoesGeral.bAnularEventos = true;
			val.Commit();
			DeclaracoesGeral.bAnularEventos = false;
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static Point3d InserirPorta(Declaracoes2.MPorta myBL, bool bNomeVisivel, bool bNomeAlternativo, string indice, Point3d point)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected Obj, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected Obj, but got Unknown
		//IL_0669: Unknown result type (might be due to invalid IL or missing references)
		//IL_066a: Unknown result type (might be due to invalid IL or missing references)
		//IL_066c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0588: Unknown result type (might be due to invalid IL or missing references)
		//IL_0593: Unknown result type (might be due to invalid IL or missing references)
		//IL_059a: Expected Obj, but got Unknown
		//IL_059c: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected Obj, but got Unknown
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_05af: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b5: Expected Obj, but got Unknown
		//IL_05f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fe: Invalid comparison between Unknown and I4
		//IL_0602: Unknown result type (might be due to invalid IL or missing references)
		//IL_060c: Invalid comparison between Unknown and I4
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Expected Obj, but got Unknown
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Expected Obj, but got Unknown
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Expected Obj, but got Unknown
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Expected Obj, but got Unknown
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ba: Expected Obj, but got Unknown
		//IL_056c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0572: Expected Obj, but got Unknown
		//IL_0573: Unknown result type (might be due to invalid IL or missing references)
		//IL_0578: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Expected Obj, but got Unknown
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Expected Obj, but got Unknown
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d3: Unknown result type (might be due to invalid IL or missing references)
		Point3d val = default;
		val = new Point3d(0.0, 0.0, 0.0);
		PointMonitorToolTips.StopMonitor();
		BlockReference val2 = null;
		DocumentLock val3 = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val4 = database.TransactionManager.StartTransaction();
			try
			{
				if (myBL.iPainel != 0)
				{
					ObjectId val5 = ObjectId.Null;
					BlockTable val6 = (BlockTable)val4.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val7 = (BlockTableRecord)val4.GetObject(((SymbolTable)val6)[BlockTableRecord.ModelSpace], (OpenMode)1);
					BlockTableRecord val8 = null;
					int iIndiceModelo = myBL.iIndiceModelo;
					string sNome = myBL.sNome1;
					string sNome2 = myBL.sNome2;
					string sAlternativo = myBL.sAlternativo;
					bool flag = false;
					Declaracoes2.MModeloDeMascara[] mModelo = new Declaracoes2.MModeloDeMascara[1];
					DicionarioMascaras.LeOsModelosDeMascaras(ref mModelo, bComplementarModelo: true);
					int num = Information.UBound(mModelo);
					for (int i = 1; i <= num; i = checked(i + 1))
					{
						if (mModelo[i].iIndiceModelo == iIndiceModelo)
						{
							myBL.sNomeModelo = mModelo[i].sNomeModelo;
							myBL.sFabricante = mModelo[i].sFabricante;
							break;
						}
					}
					if (!((SymbolTable)val6).Has(myBL.sNomeDoBloco))
					{
						Database val9 = new Database(false, true);
						val9.ReadDwgFile(myBL.sCaminhoBloco, FileShare.Read, true, "");
						DeclaracoesGeral.bAnularEventos = true;
						val5 = database.Insert(myBL.sNomeDoBloco, val9, false);
						((DisposableWrapper)val9).Dispose();
					}
					else
					{
						BlockTableRecord val10 = (BlockTableRecord)val4.GetObject(((SymbolTable)val6)[myBL.sNomeDoBloco], (OpenMode)0);
						val5 = ((DBObject)val10).Id;
					}
					if (Conversions.ToDouble(indice) != 1.0)
					{
						val2 = new BlockReference(point, val5);
						((Entity)val2).Layer = DeclaracoesGeral.ativo.Pagina;
					}
					else
					{
						val2 = new BlockReference(Point3d.Origin, val5);
						((Entity)val2).Layer = DeclaracoesGeral.ativo.Pagina;
						Jig jig = new Jig((Entity)(object)val2);
						hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
						PromptResult val11 = editor.Drag((Jig)(object)jig);
						if (((int)val11.Status == -5002) | ((int)val11.Status == -5001))
						{
							goto IL_0614;
						}
					}
					val7.AppendEntity((Entity)(object)val2);
					((Entity)val2).Draw();
					DeclaracoesGeral.bAnularEventos = true;
					val4.AddNewlyCreatedDBObject((DBObject)(object)val2, true);
					((object)((DBObject)val2).Handle/*cast due to constrained. prefix*/).ToString();
					_ = val2.Position;
					val8 = (BlockTableRecord)val4.GetObject(val5, (OpenMode)0);
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val8.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val12 = (Entity)val4.GetObject(current, (OpenMode)0);
							try
							{
								if (val12 is AttributeDefinition)
								{
									AttributeDefinition val13 = (AttributeDefinition)val12;
									string tag = val13.Tag;
									if (Operators.CompareString(tag, "NOME2", TextCompare: true) == 0)
									{
										flag = true;
									}
								}
							}
							finally
							{
								((IDisposable)val12)?.Dispose();
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
						enumerator2 = val8.GetEnumerator();
						while (enumerator2.MoveNext())
						{
							ObjectId current = enumerator2.Current;
							Entity val14 = (Entity)val4.GetObject(current, (OpenMode)0);
							try
							{
								if (!(val14 is AttributeDefinition))
								{
									continue;
								}
								AttributeDefinition val15 = (AttributeDefinition)val14;
								AttributeReference val16 = new AttributeReference();
								val16.SetAttributeFromBlock(val15, val2.BlockTransform);
								string textString = "";
								((DBText)val16).TextString = textString;
								string tag2 = val15.Tag;
								if (Operators.CompareString(tag2, "NOME1", TextCompare: true) != 0)
								{
									if (Operators.CompareString(tag2, "NOME2", TextCompare: true) != 0)
									{
										if (Operators.CompareString(tag2, "ALTERNATIVO", TextCompare: true) != 0)
										{
											if (Operators.CompareString(tag2, "PAINEL", TextCompare: true) != 0)
											{
												if (Operators.CompareString(tag2, "MODELO", TextCompare: true) != 0)
												{
													if (Operators.CompareString(tag2, "FABRICANTE", TextCompare: true) != 0)
													{
														string expression = Strings.Mid(val16.Tag, 2, Strings.Len(val16.Tag));
														if ((Operators.CompareString(Strings.Mid(val16.Tag, 1, 1), "T", TextCompare: true) == 0) & Versioned.IsNumeric(expression))
														{
															((DBText)val16).TextString = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
														}
													}
													else
													{
														((DBText)val16).TextString = myBL.sFabricante;
														((Entity)val16).Visible = true;
													}
												}
												else
												{
													((DBText)val16).TextString = myBL.sNomeModelo;
													((Entity)val16).Visible = true;
												}
											}
											else
											{
												((DBText)val16).TextString = myBL.sPainel;
												((Entity)val16).Visible = true;
											}
										}
										else
										{
											((DBText)val16).TextString = sAlternativo;
											((Entity)val16).Visible = bNomeVisivel;
										}
									}
									else
									{
										((DBText)val16).TextString = sNome2;
										((Entity)val16).Visible = bNomeVisivel;
									}
								}
								else
								{
									textString = sNome;
									if (!flag && Operators.CompareString(sNome2, "", TextCompare: true) != 0)
									{
										textString = sNome + "/" + sNome2;
									}
									((DBText)val16).TextString = textString;
									((Entity)val16).Visible = bNomeVisivel;
								}
								((DBText)val16).AdjustAlignment(database);
								val2.AttributeCollection.AppendAttribute(val16);
								DeclaracoesGeral.bAnularEventos = true;
								val4.AddNewlyCreatedDBObject((DBObject)(object)val16, true);
								((Entity)val16).Draw();
							}
							finally
							{
								((IDisposable)val14)?.Dispose();
							}
						}
					}
					finally
					{
						((IDisposable)enumerator2)?.Dispose();
					}
					((Entity)val2).Draw();
					DeclaracoesEntidades.StructurePortas Porta = new DeclaracoesEntidades.StructurePortas
					{
						Nome1 = myBL.sNome1,
						Nome2 = myBL.sNome2,
						Alternativo = myBL.sAlternativo,
						handleDaDefinicao = "",
						chavePrimaria = "",
						indiceDaPorta = 0,
						HandleDaMascara = myBL.sHandle,
						indiceDoModelo = myBL.iIndiceModelo
					};
					Entity ent = (Entity)(object)val2;
					XDataDispositivosMaster.GravarXDataPorta(ref ent, ref Porta);
					val2 = (BlockReference)ent;
					val = val2.Position;
					goto IL_0614;
				}
				goto end_IL_006f;
				IL_0614:
				DeclaracoesGeral.bAnularEventos = true;
				val4.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				end_IL_006f:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				val4.Abort();
				Interaction.MsgBox(ex2.Message, MsgBoxStyle.Information);
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
		return val;
	}

	public static string selecionaUmaPorta(ref DeclaracoesEntidades.StructurePortas portaE, ref int iPainel)
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected Obj, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected Obj, but got Unknown
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected Obj, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected Obj, but got Unknown
		string result = "";
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		_ = Application.DocumentManager.MdiActiveDocument.Editor;
		PointMonitorToolTips.StopMonitor();
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			Point3d val3 = default;
			ObjectId val2 = DBYTfvCWmP(ref val3);
			if (!val2.IsNull)
			{
				Entity val4 = (Entity)val.GetObject(val2, (OpenMode)0);
				try
				{
					if (!Information.IsDBNull(val4))
					{
						Entity ent = val4;
						string tipoImportado = "";
						string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
						if (Operators.CompareString(left, "E", TextCompare: true) == 0)
						{
							BlockReference blockRef = (BlockReference)val4;
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
							portaE = ((obj == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj));
							BlockReference val5 = (BlockReference)(object)((val4 is BlockReference) ? val4 : null);
							try
							{
								result = val5.Name;
							}
							finally
							{
								((IDisposable)val5)?.Dispose();
							}
							DeclaracoesEntidades.StructureMascara structureMascara = default;
							Entity val6 = (Entity)Geral.HandleToObject(portaE.HandleDaMascara);
							try
							{
								if (val6 != null)
								{
									blockRef = (BlockReference)val6;
									object obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
									iPainel = ((obj2 == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj2)).Painel;
								}
							}
							finally
							{
								((IDisposable)val6)?.Dispose();
							}
						}
					}
				}
				finally
				{
					((IDisposable)val4)?.Dispose();
				}
				DeclaracoesGeral.bAnularEventos = true;
				val.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
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
		return result;
	}

	private static ObjectId DBYTfvCWmP(ref Point3d P_0)
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
		PromptEntityOptions val = new PromptEntityOptions("\r\nSelecione um Porta");
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

	public static bool SelecionaPortas(ref object[,] PortasSelecionadas, int indiceDoModelo, string sNome1, string sNome2, string sAlternativo, ref bool bContinua, ref bool bDiferente)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected Obj, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected Obj, but got Unknown
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected Obj, but got Unknown
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				_ = Application.DocumentManager.MdiActiveDocument;
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				PromptSelectionOptions val2 = new PromptSelectionOptions();
				editor.WriteMessage("\nSelecione as portas .");
				val2.Keywords.GetDisplayString(true);
				PromptSelectionResult selection = editor.GetSelection(val2);
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
							try
							{
								if (Operators.CompareString(val6.Layer, DeclaracoesGeral.ativo.Pagina, TextCompare: true) != 0)
								{
									continue;
								}
								BlockReference val7 = (BlockReference)(object)((val6 is BlockReference) ? val6 : null);
								try
								{
									if (val7 == null)
									{
										continue;
									}
									DeclaracoesEntidades.StructurePortas structurePortas = default;
									BlockReference blockRef = val7;
									object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
									structurePortas = ((obj == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj));
									if (Operators.CompareString(structurePortas.Tipo, "E", TextCompare: true) != 0)
									{
										continue;
									}
									if (!((structurePortas.indiceDoModelo == indiceDoModelo) & (Operators.CompareString(structurePortas.Nome1, sNome1, TextCompare: true) == 0) & (Operators.CompareString(structurePortas.Nome2, sNome2, TextCompare: true) == 0) & (Operators.CompareString(structurePortas.Alternativo, sAlternativo, TextCompare: true) == 0)))
									{
										bDiferente = true;
										continue;
									}
									int num = Information.UBound(PortasSelecionadas, 2) + 1;
									PortasSelecionadas = (object[,])Utils.CopyArray(PortasSelecionadas, new object[6, num + 1]);
									PortasSelecionadas[0, num] = ((object)((DBObject)val7).Handle/*cast due to constrained. prefix*/).ToString();
									object[,] obj2 = PortasSelecionadas;
									Point3d position = val7.Position;
									obj2[1, num] = Math.Round(position.X, 0);
									object[,] obj3 = PortasSelecionadas;
									position = val7.Position;
									obj3[2, num] = Math.Round(position.Y, 0);
									PortasSelecionadas[3, num] = -1;
									PortasSelecionadas[4, num] = -1;
									PortasSelecionadas[5, num] = -1;
									if (structurePortas.indiceDaPorta != 0)
									{
										PortasSelecionadas[3, num] = structurePortas.indiceDaPorta;
										result = true;
									}
									bContinua = true;
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
						if (bContinua)
						{
							object obj4 = null;
							if (Information.UBound(PortasSelecionadas, 2) >= 2 && Information.UBound(PortasSelecionadas, 2) > 0)
							{
								int num2 = Information.UBound(PortasSelecionadas, 2) - 1;
								for (int i = num2; i >= 1; i += -1)
								{
									int num3 = i;
									for (int j = 1; j <= num3; j++)
									{
										if (Conversions.ToDouble(PortasSelecionadas[1, j]) > Conversions.ToDouble(PortasSelecionadas[1, j + 1]))
										{
											int num4 = 0;
											do
											{
												obj4 = RuntimeHelpers.GetObjectValue(PortasSelecionadas[num4, j + 1]);
												PortasSelecionadas[num4, j + 1] = RuntimeHelpers.GetObjectValue(PortasSelecionadas[num4, j]);
												PortasSelecionadas[num4, j] = RuntimeHelpers.GetObjectValue(obj4);
												num4++;
											}
											while (num4 <= 4);
										}
										if (Conversions.ToDouble(PortasSelecionadas[1, j]) == Conversions.ToDouble(PortasSelecionadas[1, j + 1]) && Conversions.ToDouble(PortasSelecionadas[2, j]) < Conversions.ToDouble(PortasSelecionadas[2, j + 1]))
										{
											int num5 = 0;
											do
											{
												obj4 = RuntimeHelpers.GetObjectValue(PortasSelecionadas[num5, j + 1]);
												PortasSelecionadas[num5, j + 1] = RuntimeHelpers.GetObjectValue(PortasSelecionadas[num5, j]);
												PortasSelecionadas[num5, j] = RuntimeHelpers.GetObjectValue(obj4);
												num5++;
											}
											while (num5 <= 4);
										}
									}
								}
							}
							if (Information.UBound(PortasSelecionadas, 2) >= 2 && Information.UBound(PortasSelecionadas, 2) > 0)
							{
								int num6 = Information.UBound(PortasSelecionadas, 2) - 1;
								for (int k = num6; k >= 1; k += -1)
								{
									int num7 = k;
									for (int l = 1; l <= num7; l++)
									{
										if (Conversions.ToDouble(PortasSelecionadas[2, l]) < Conversions.ToDouble(PortasSelecionadas[2, l + 1]))
										{
											int num8 = 0;
											do
											{
												obj4 = RuntimeHelpers.GetObjectValue(PortasSelecionadas[num8, l + 1]);
												PortasSelecionadas[num8, l + 1] = RuntimeHelpers.GetObjectValue(PortasSelecionadas[num8, l]);
												PortasSelecionadas[num8, l] = RuntimeHelpers.GetObjectValue(obj4);
												num8++;
											}
											while (num8 <= 4);
										}
									}
								}
							}
						}
					}
					DeclaracoesGeral.bAnularEventos = true;
					val3.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
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
			return result;
		}
	}

	public static void SelecionaPortasOuDefinicao(ref object[,] PortasSelecionadas, string sTipoDef)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected Obj, but got Unknown
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected Obj, but got Unknown
		//IL_04dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected Obj, but got Unknown
		//IL_0343: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Expected Obj, but got Unknown
		//IL_0446: Unknown result type (might be due to invalid IL or missing references)
		//IL_044b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0475: Unknown result type (might be due to invalid IL or missing references)
		//IL_047a: Unknown result type (might be due to invalid IL or missing references)
		//IL_049a: Unknown result type (might be due to invalid IL or missing references)
		//IL_049f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		PointMonitorToolTips.StopMonitor();
		_ = Application.DocumentManager.MdiActiveDocument;
		Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
		PromptSelectionOptions val = new PromptSelectionOptions();
		if (Operators.CompareString(sTipoDef, "T", TextCompare: true) != 0)
		{
			editor.WriteMessage(Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 1152])));
		}
		else
		{
			editor.WriteMessage(Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 1151])));
		}
		List<string> list = new List<string>();
		val.Keywords.GetDisplayString(true);
		PromptSelectionResult selection = editor.GetSelection(val);
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val2 = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				if (!Information.IsNothing(selection.Value))
				{
					SelectionSet value = selection.Value;
					ObjectIdCollection val3 = new ObjectIdCollection(value.GetObjectIds());
					foreach (object item in val3)
					{
						ObjectId val4 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
						Entity val5 = (Entity)val4.GetObject((OpenMode)0);
						try
						{
							if (Operators.CompareString(val5.Layer, DeclaracoesGeral.ativo.Pagina, TextCompare: true) != 0)
							{
								continue;
							}
							Point3d position;
							if ((Operators.CompareString(sTipoDef, "ALL", TextCompare: true) == 0) | (Operators.CompareString(sTipoDef, "E", TextCompare: true) == 0))
							{
								BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
								try
								{
									if (val6 != null)
									{
										Entity ent = (Entity)(object)val6;
										string tipoImportado = "";
										string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
										if (Operators.CompareString(left, "E", TextCompare: true) == 0)
										{
											DeclaracoesEntidades.StructurePortas structurePortas = default;
											BlockReference blockRef = val6;
											object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
											structurePortas = ((obj == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj));
											int num = Information.UBound(PortasSelecionadas, 2) + 1;
											PortasSelecionadas = (object[,])Utils.CopyArray(PortasSelecionadas, new object[4, num + 1]);
											PortasSelecionadas[0, num] = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
											PortasSelecionadas[1, num] = "E";
											object[,] obj2 = PortasSelecionadas;
											position = val6.Position;
											obj2[2, num] = Math.Round(position.X, 0);
											object[,] obj3 = PortasSelecionadas;
											position = val6.Position;
											obj3[3, num] = Math.Round(position.Y, 0);
										}
									}
								}
								finally
								{
									((IDisposable)val6)?.Dispose();
								}
							}
							if ((Operators.CompareString(sTipoDef, "ALL", TextCompare: true) == 0) | (Operators.CompareString(sTipoDef, "T", TextCompare: true) == 0))
							{
								DBText val7 = (DBText)(object)((val5 is DBText) ? val5 : null);
								if (val7 != null)
								{
									DeclaracoesEntidades.StructureDefinicaoPortas Def = default;
									Entity ent = (Entity)(object)val7;
									bool flag = XDataDispositivosMaster.LerXDataDefinicao(ref ent, ref Def);
									val7 = (DBText)ent;
									if (!flag)
									{
										if (val7.TextString.StartsWith("(") & val7.TextString.EndsWith(")"))
										{
											int num2 = Information.UBound(PortasSelecionadas, 2) + 1;
											PortasSelecionadas = (object[,])Utils.CopyArray(PortasSelecionadas, new object[4, num2 + 1]);
											PortasSelecionadas[0, num2] = ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString();
											PortasSelecionadas[1, num2] = "N";
											object[,] obj4 = PortasSelecionadas;
											position = val7.Position;
											obj4[2, num2] = Math.Round(position.X, 0);
											object[,] obj5 = PortasSelecionadas;
											position = val7.Position;
											obj5[3, num2] = Math.Round(position.Y, 0);
										}
									}
									else
									{
										int num3 = Information.UBound(PortasSelecionadas, 2) + 1;
										PortasSelecionadas = (object[,])Utils.CopyArray(PortasSelecionadas, new object[4, num3 + 1]);
										PortasSelecionadas[0, num3] = ((object)((DBObject)val7).Handle/*cast due to constrained. prefix*/).ToString();
										PortasSelecionadas[1, num3] = "T";
										object[,] obj6 = PortasSelecionadas;
										position = val7.Position;
										obj6[2, num3] = Math.Round(position.X, 0);
										object[,] obj7 = PortasSelecionadas;
										position = val7.Position;
										obj7[3, num3] = Math.Round(position.Y, 0);
									}
								}
							}
							Polyline val8 = (Polyline)(object)((val5 is Polyline) ? val5 : null);
							if (val8 != null)
							{
								Entity ent = val5;
								object[,] mMensagem;
								string tipoImportado = Conversions.ToString((mMensagem = DeclaracoesGeral.mMensagem)[1, 750]);
								string sHandle = "";
								object left2 = XDataDispositivosMaster.LerXDataErro(ref ent, "PORTAS", ref tipoImportado, ref sHandle);
								mMensagem[1, 750] = tipoImportado;
								if (Operators.ConditionalCompareObjectEqual(left2, true, TextCompare: true))
								{
									list.Add(((object)((DBObject)val8).Handle/*cast due to constrained. prefix*/).ToString());
								}
							}
						}
						finally
						{
							((IDisposable)val5)?.Dispose();
						}
					}
				}
				if (Information.UBound(PortasSelecionadas, 2) > 1)
				{
					object obj8 = null;
					if (Information.UBound(PortasSelecionadas, 2) >= 2 && Information.UBound(PortasSelecionadas, 2) > 0)
					{
						int num4 = Information.UBound(PortasSelecionadas, 2) - 1;
						for (int i = num4; i >= 1; i += -1)
						{
							int num5 = i;
							for (int j = 1; j <= num5; j++)
							{
								if (Conversions.ToDouble(PortasSelecionadas[2, j]) > Conversions.ToDouble(PortasSelecionadas[2, j + 1]))
								{
									int num6 = 0;
									do
									{
										obj8 = RuntimeHelpers.GetObjectValue(PortasSelecionadas[num6, j + 1]);
										PortasSelecionadas[num6, j + 1] = RuntimeHelpers.GetObjectValue(PortasSelecionadas[num6, j]);
										PortasSelecionadas[num6, j] = RuntimeHelpers.GetObjectValue(obj8);
										num6++;
									}
									while (num6 <= 3);
								}
								if (Conversions.ToDouble(PortasSelecionadas[2, j]) == Conversions.ToDouble(PortasSelecionadas[2, j + 1]) && Conversions.ToDouble(PortasSelecionadas[3, j]) < Conversions.ToDouble(PortasSelecionadas[3, j + 1]))
								{
									int num7 = 0;
									do
									{
										obj8 = RuntimeHelpers.GetObjectValue(PortasSelecionadas[num7, j + 1]);
										PortasSelecionadas[num7, j + 1] = RuntimeHelpers.GetObjectValue(PortasSelecionadas[num7, j]);
										PortasSelecionadas[num7, j] = RuntimeHelpers.GetObjectValue(obj8);
										num7++;
									}
									while (num7 <= 3);
								}
							}
						}
					}
					if (Information.UBound(PortasSelecionadas, 2) >= 2 && Information.UBound(PortasSelecionadas, 2) > 0)
					{
						int num8 = Information.UBound(PortasSelecionadas, 2) - 1;
						for (int k = num8; k >= 1; k += -1)
						{
							int num9 = k;
							for (int l = 1; l <= num9; l++)
							{
								if (Conversions.ToDouble(PortasSelecionadas[3, l]) < Conversions.ToDouble(PortasSelecionadas[3, l + 1]))
								{
									int num10 = 0;
									do
									{
										obj8 = RuntimeHelpers.GetObjectValue(PortasSelecionadas[num10, l + 1]);
										PortasSelecionadas[num10, l + 1] = RuntimeHelpers.GetObjectValue(PortasSelecionadas[num10, l]);
										PortasSelecionadas[num10, l] = RuntimeHelpers.GetObjectValue(obj8);
										num10++;
									}
									while (num10 <= 3);
								}
							}
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
				ProjectData.ClearProjectError();
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
			if (list.Count > 0)
			{
				clsLinha.ApagaLinhaErro(list);
			}
			PointMonitorToolTips.StartMonitor();
		}
	}

	public static void IndefineUmaPorta(string sHandle, bool bLimpaTudo)
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected Obj, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			_ = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				Entity val3 = (Entity)Geral.HandleToObject(sHandle);
				try
				{
					if (val3 != null)
					{
						DeclaracoesEntidades.StructurePortas structurePortas = default;
						BlockReference blockRef = (BlockReference)val3;
						object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
						structurePortas = ((obj == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj));
						structurePortas.indiceDaPorta = 0;
						structurePortas.handleDaDefinicao = "";
						structurePortas.chavePrimaria = "";
						Entity ent = val3;
						XDataDispositivosMaster.GravarXDataPorta(ref ent, ref structurePortas);
						LimpaPorta(sHandle, bLimpaTudo);
					}
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				finally
				{
					((IDisposable)val3)?.Dispose();
				}
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

	public static void IndefineUmaDefinicao(string sHandle)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected Obj, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected Obj, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Expected Obj, but got Unknown
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected Obj, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			_ = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				ObjectId val4 = Geral.HandleToID(sHandle);
				if (val4.IsValid)
				{
					Entity val5 = (Entity)val2.GetObject(val4, (OpenMode)0);
					try
					{
						DeclaracoesEntidades.StructureDefinicaoPortas Def = default;
						Entity Ent = val5;
						XDataDispositivosMaster.LerXDataDefinicao(ref Ent, ref Def);
						if (Information.IsNothing(Def))
						{
							return;
						}
						DBText val6 = (DBText)(object)((val5 is DBText) ? val5 : null);
						try
						{
							if (val6 != null)
							{
								string textString = "(" + DicionarioMascaras.BuscaNomePortaMascara(ref Def.indiceDoModelo, ref Def.indiceDaPorta) + ")";
								((DBObject)val6).UpgradeOpen();
								val6.TextString = textString;
								RegAppTable val7 = (RegAppTable)val2.GetObject(database.RegAppTableId, (OpenMode)1);
								if (!((SymbolTable)val7).Has("Definicao"))
								{
									RegAppTableRecord val8 = new RegAppTableRecord();
									((SymbolTableRecord)val8).Name = "Definicao";
									((SymbolTable)val7).Add((SymbolTableRecord)(object)val8);
									DeclaracoesGeral.bAnularEventos = true;
									val2.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
								}
								TypedValue[] array = new TypedValue[1]
								{
									new TypedValue(1001, (object)"Definicao")
								};
								((DBObject)val6).UpgradeOpen();
								((DBObject)val6).XData = new ResultBuffer(array);
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

	public static void LimpaPorta(string sHandle, bool bLimpaTudo)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected Obj, but got Unknown
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected Obj, but got Unknown
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected Obj, but got Unknown
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		ObjectId val = Geral.HandleToID(sHandle);
		if (val.IsNull)
		{
			return;
		}
		DocumentLock val2 = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Transaction val3 = database.TransactionManager.StartTransaction();
			try
			{
				BlockReference val4 = (BlockReference)val3.GetObject(val, (OpenMode)0);
				try
				{
					BlockTableRecord val5 = (BlockTableRecord)val3.GetObject(val4.BlockTableRecord, (OpenMode)0);
					if (string.Compare(((SymbolTableRecord)val5).Name, val4.Name, ignoreCase: true) == 0)
					{
						AttributeCollection attributeCollection = val4.AttributeCollection;
						foreach (object item in attributeCollection)
						{
							ObjectId val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							AttributeReference val7 = (AttributeReference)val6.GetObject((OpenMode)1);
							if (bLimpaTudo)
							{
								((DBText)val7).TextString = "";
							}
							string tag = val7.Tag;
							if (Operators.CompareString(tag, "NOME1", TextCompare: true) != 0 && Operators.CompareString(tag, "NOME2", TextCompare: true) != 0 && Operators.CompareString(tag, "ALTERNATIVO", TextCompare: true) != 0 && Operators.CompareString(tag, "PAINEL", TextCompare: true) != 0 && Operators.CompareString(tag, "MODELO", TextCompare: true) != 0 && Operators.CompareString(tag, "FABRICANTE", TextCompare: true) != 0)
							{
								string expression = Strings.Mid(val7.Tag, 2, Strings.Len(val7.Tag));
								if (!(((Operators.CompareString(Strings.Mid(val7.Tag, 1, 1), "T", TextCompare: true) == 0) & Versioned.IsNumeric(expression)) | ((Operators.CompareString(Strings.Mid(val7.Tag, 1, 1), "B", TextCompare: true) == 0) & Versioned.IsNumeric(expression))))
								{
									((DBText)val7).TextString = "";
								}
								else
								{
									((DBText)val7).TextString = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
								}
							}
						}
					}
					((DBObject)val4).UpgradeOpen();
					DeclaracoesGeral.bAnularEventos = true;
					val3.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				finally
				{
					((IDisposable)val4)?.Dispose();
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
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
	}

	public static void AtribuiPortas(string sModelo, ref object[,] PortasSelecionadas, ref frmDefinicao.mItensSelecionadosDG[] mItensSelecionadosDG, ref Declaracoes2.MModeloDePortas[] mPortas_DefUsadas, int indicePainelSel)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected Obj, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected Obj, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected Obj, but got Unknown
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0363: Unknown result type (might be due to invalid IL or missing references)
		//IL_0368: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		PointMonitorToolTips.StopMonitor();
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					DeclaracoesGeral.Reguas RH = default;
					bool flag = false;
					DeclaracoesGeral.Reguas RH2 = default;
					bool flag2 = false;
					flag = XDataGeral.LeXDataReguaH(ref RH);
					flag2 = XDataGeral.LeXDataReguaV(ref RH2);
					_ = ObjectId.Null;
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					int num = Information.UBound(PortasSelecionadas, 2);
					if (num > Information.UBound(mItensSelecionadosDG))
					{
						num = Information.UBound(mItensSelecionadosDG);
					}
					int num2 = num;
					for (int i = 1; i <= num2; i++)
					{
						Entity val4 = (Entity)val2.GetObject(Geral.HandleToID(Conversions.ToString(PortasSelecionadas[0, i])), (OpenMode)1);
						try
						{
							if (val4 == null)
							{
								continue;
							}
							DeclaracoesEntidades.StructurePortas structurePortas = default;
							BlockReference blockRef = (BlockReference)val4;
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
							structurePortas = ((obj == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj));
							structurePortas.indiceDaPorta = mItensSelecionadosDG[i].IndicePorta;
							Entity ent = val4;
							XDataDispositivosMaster.GravarXDataPorta(ref ent, ref structurePortas);
							ObjectId BlockID = ((DBObject)val4).ObjectId;
							preencheAtributosPorta(ref BlockID, mItensSelecionadosDG, i, structurePortas, PreencheLogico: true);
							bool flag3 = true;
							int num3 = Information.UBound(mPortas_DefUsadas);
							for (int j = 0; j <= num3; j++)
							{
								if (!((mPortas_DefUsadas[j].IndiceModelo == structurePortas.indiceDoModelo) & (mPortas_DefUsadas[j].IndicePN == indicePainelSel)) || mPortas_DefUsadas[j].IndiceDaPorta != structurePortas.indiceDaPorta)
								{
									continue;
								}
								string text = structurePortas.Nome1;
								if (Operators.CompareString(structurePortas.Nome2, "", TextCompare: true) != 0)
								{
									text = text + "/" + structurePortas.Nome2;
								}
								if (Operators.CompareString(mPortas_DefUsadas[j].NomeModelo, text, TextCompare: true) == 0)
								{
									string pagina = val4.Layer.ToString();
									ent = val4;
									string text2 = Pagina.montaCruzamentoPagina(pagina, Pagina.calculaLinhaColuna(ref ent, ref RH, ref RH2, flag, flag2));
									ref string handlePorta = ref mPortas_DefUsadas[j].HandlePorta;
									handlePorta = handlePorta + ((object)((DBObject)val4).Handle/*cast due to constrained. prefix*/).ToString() + "|";
									if (Operators.CompareString(text2, "", TextCompare: true) != 0)
									{
										ref string paginaPorta = ref mPortas_DefUsadas[j].PaginaPorta;
										paginaPorta = paginaPorta + text2 + "|";
									}
									flag3 = false;
									break;
								}
							}
							if (flag3)
							{
								int num4 = Information.UBound(mPortas_DefUsadas) + 1;
								mPortas_DefUsadas = (Declaracoes2.MModeloDePortas[])Utils.CopyArray(mPortas_DefUsadas, new Declaracoes2.MModeloDePortas[num4 + 1]);
								string text3 = structurePortas.Nome1;
								if (Operators.CompareString(structurePortas.Nome2, "", TextCompare: true) != 0)
								{
									text3 = text3 + "/" + structurePortas.Nome2;
								}
								mPortas_DefUsadas[num4].NomeModelo = text3;
								mPortas_DefUsadas[num4].IndiceModelo = structurePortas.indiceDoModelo;
								mPortas_DefUsadas[num4].IndicePN = indicePainelSel;
								mPortas_DefUsadas[num4].IndiceDaPorta = structurePortas.indiceDaPorta;
								mPortas_DefUsadas[num4].Uso = true;
								ref string paginaPorta2 = ref mPortas_DefUsadas[num4].PaginaPorta;
								string obj2 = paginaPorta2;
								string pagina2 = val4.Layer.ToString();
								ent = val4;
								paginaPorta2 = obj2 + Pagina.montaCruzamentoPagina(pagina2, Pagina.calculaLinhaColuna(ref ent, ref RH, ref RH2, flag, flag2)) + "|";
								ref string handlePorta2 = ref mPortas_DefUsadas[num4].HandlePorta;
								handlePorta2 = handlePorta2 + ((object)((DBObject)val4).Handle/*cast due to constrained. prefix*/).ToString() + "|";
								mPortas_DefUsadas[num4].PaginaDef = "";
								mPortas_DefUsadas[num4].HandleDef = "";
								flag3 = false;
							}
						}
						finally
						{
							((IDisposable)val4)?.Dispose();
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
	}

	public static void AtribuiDefinicao(string smodelo, ref object[,] DefSelecionadas, ref frmDefinicao.mItensSelecionadosDG[] mItensSelecionadosDG, ref Declaracoes2.MModeloDePortas[] mPortas_DefUsadas)
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected Obj, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected Obj, but got Unknown
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Expected Obj, but got Unknown
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected Obj, but got Unknown
		//IL_036f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0374: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					DeclaracoesGeral.Reguas RH = default;
					bool flag = false;
					DeclaracoesGeral.Reguas RH2 = default;
					bool flag2 = false;
					flag = XDataGeral.LeXDataReguaH(ref RH);
					flag2 = XDataGeral.LeXDataReguaV(ref RH2);
					_ = ObjectId.Null;
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					int num = Information.UBound(DefSelecionadas, 2);
					if (num > Information.UBound(mItensSelecionadosDG))
					{
						num = Information.UBound(mItensSelecionadosDG);
					}
					int num2 = num;
					for (int i = 1; i <= num2; i++)
					{
						Entity val4 = (Entity)val2.GetObject(Geral.HandleToID(Conversions.ToString(DefSelecionadas[0, i])), (OpenMode)1);
						try
						{
							if (val4 == null)
							{
								continue;
							}
							DeclaracoesEntidades.StructureDefinicaoPortas Def = default;
							Entity Ent = val4;
							if (!XDataDispositivosMaster.LerXDataDefinicao(ref Ent, ref Def))
							{
								continue;
							}
							DeclaracoesEntidades.StructureMascara structureMascara = default;
							Entity val5 = (Entity)Geral.HandleToObject(Def.HandleDaMascara);
							if (val5 == null)
							{
								continue;
							}
							BlockReference blockRef = (BlockReference)val5;
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
							val5 = (Entity)(object)blockRef;
							structureMascara = ((obj == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj));
							bool flag3 = true;
							int num3 = Information.UBound(mPortas_DefUsadas);
							for (int j = 0; j <= num3; j++)
							{
								if (!((mPortas_DefUsadas[j].IndiceModelo == Def.indiceDoModelo) & (mPortas_DefUsadas[j].IndicePN == structureMascara.Painel)) || mPortas_DefUsadas[j].IndiceDaPorta != Def.indiceDaPorta)
								{
									continue;
								}
								string text = structureMascara.Nome1;
								if (Operators.CompareString(structureMascara.Nome2, "", TextCompare: true) != 0)
								{
									text = text + "/" + structureMascara.Nome2;
								}
								if (Operators.CompareString(mPortas_DefUsadas[j].NomeModelo, text, TextCompare: true) == 0)
								{
									string pagina = val4.Layer.ToString();
									Ent = val4;
									string text2 = Pagina.montaCruzamentoPagina(pagina, Pagina.calculaLinhaColuna(ref Ent, ref RH, ref RH2, flag, flag2));
									if (Operators.CompareString(text2, "", TextCompare: true) != 0)
									{
										ref string paginaDef = ref mPortas_DefUsadas[j].PaginaDef;
										paginaDef = paginaDef + text2 + "|";
									}
									ref string handleDef = ref mPortas_DefUsadas[j].HandleDef;
									handleDef = handleDef + ((object)((DBObject)val4).Handle/*cast due to constrained. prefix*/).ToString() + "|";
									flag3 = false;
									break;
								}
							}
							if (flag3 && flag3)
							{
								int num4 = Information.UBound(mPortas_DefUsadas) + 1;
								mPortas_DefUsadas = (Declaracoes2.MModeloDePortas[])Utils.CopyArray(mPortas_DefUsadas, new Declaracoes2.MModeloDePortas[num4 + 1]);
								string text3 = structureMascara.Nome1;
								if (Operators.CompareString(structureMascara.Nome2, "", TextCompare: true) != 0)
								{
									text3 = text3 + "/" + structureMascara.Nome2;
								}
								mPortas_DefUsadas[num4].NomeModelo = text3;
								mPortas_DefUsadas[num4].IndiceModelo = Def.indiceDoModelo;
								mPortas_DefUsadas[num4].IndicePN = structureMascara.Painel;
								mPortas_DefUsadas[num4].IndiceDaPorta = Def.indiceDaPorta;
								mPortas_DefUsadas[num4].Uso = true;
								ref string paginaDef2 = ref mPortas_DefUsadas[num4].PaginaDef;
								string obj2 = paginaDef2;
								string pagina2 = val4.Layer.ToString();
								Ent = val4;
								paginaDef2 = obj2 + Pagina.montaCruzamentoPagina(pagina2, Pagina.calculaLinhaColuna(ref Ent, ref RH, ref RH2, flag, flag2)) + "|";
								ref string handleDef2 = ref mPortas_DefUsadas[num4].HandleDef;
								handleDef2 = handleDef2 + ((object)((DBObject)val4).Handle/*cast due to constrained. prefix*/).ToString() + "|";
								mPortas_DefUsadas[num4].PaginaPorta = "";
								mPortas_DefUsadas[num4].HandlePorta = "";
								flag3 = false;
							}
						}
						finally
						{
							((IDisposable)val4)?.Dispose();
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

	public static void InserePaginaAsDefinicoes(ref object[,] DefSelecionadas, ref frmDefinicao.mItensSelecionadosDG[] mItensSelecionadosDG)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				_ = ObjectId.Null;
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				int num = Information.UBound(DefSelecionadas, 2);
				if (num > Information.UBound(mItensSelecionadosDG))
				{
					num = Information.UBound(mItensSelecionadosDG);
				}
				int num2 = num;
				for (int i = 1; i <= num2; i = checked(i + 1))
				{
					Entity val4 = (Entity)val2.GetObject(Geral.HandleToID(Conversions.ToString(DefSelecionadas[0, i])), (OpenMode)1);
					try
					{
						if (val4 == null)
						{
							continue;
						}
						DeclaracoesEntidades.StructureDefinicaoPortas Def = new DeclaracoesEntidades.StructureDefinicaoPortas
						{
							HandleDaMascara = mItensSelecionadosDG[i].HandleDaMascara,
							indiceDaPorta = mItensSelecionadosDG[i].IndicePorta,
							indiceDoModelo = Conversions.ToInteger(mItensSelecionadosDG[i].IndiceModelo),
							handleDaPorta = ""
						};
						DBText val5 = (DBText)(object)((val4 is DBText) ? val4 : null);
						try
						{
							if (val5 != null)
							{
								((DBObject)val5).UpgradeOpen();
								if (Operators.CompareString(mItensSelecionadosDG[i].PgPorta, "", TextCompare: true) == 0)
								{
									val5.TextString = "(" + mItensSelecionadosDG[i].EFC + ")";
								}
								else
								{
									val5.TextString = mItensSelecionadosDG[i].PgPorta;
								}
								Entity Ent = (Entity)(object)val5;
								XDataDispositivosMaster.GravarXDataDefinicao(ref Ent, ref Def);
							}
						}
						finally
						{
							((IDisposable)val5)?.Dispose();
						}
					}
					finally
					{
						((IDisposable)val4)?.Dispose();
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

	public static void preencheAtributosPorta(ref ObjectId BlockID, frmDefinicao.mItensSelecionadosDG[] mItensSelecionadosDG, int iIndice, DeclaracoesEntidades.StructurePortas porta, bool PreencheLogico)
	{
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Expected Obj, but got Unknown
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Expected Obj, but got Unknown
		//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		//IL_030a: Expected Obj, but got Unknown
		//IL_030e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_0320: Expected Obj, but got Unknown
		//IL_03b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0360: Unknown result type (might be due to invalid IL or missing references)
		//IL_0365: Unknown result type (might be due to invalid IL or missing references)
		//IL_036f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0376: Expected Obj, but got Unknown
		//IL_0560: Unknown result type (might be due to invalid IL or missing references)
		//IL_0566: Unknown result type (might be due to invalid IL or missing references)
		//IL_0431: Unknown result type (might be due to invalid IL or missing references)
		//IL_0436: Unknown result type (might be due to invalid IL or missing references)
		//IL_0440: Unknown result type (might be due to invalid IL or missing references)
		//IL_0447: Expected Obj, but got Unknown
		List<string> lTerminais = new List<string>();
		List<string> lTerminais2 = new List<string>();
		List<string> lTerminais3 = new List<string>();
		Geral.DivideTerminais(ref lTerminais, mItensSelecionadosDG[iIndice].Terminais, bRepete: true);
		Geral.DivideTerminais(ref lTerminais2, mItensSelecionadosDG[iIndice].Bornes, bRepete: true);
		Geral.DivideTerminais(ref lTerminais3, mItensSelecionadosDG[iIndice].regua, bRepete: true);
		checked
		{
			if (lTerminais3.Count > 0)
			{
				if (lTerminais3.Count != lTerminais2.Count)
				{
					if ((lTerminais3.Count == 1) & (lTerminais2.Count > 1))
					{
						int count = lTerminais2.Count;
						for (int i = 2; i <= count; i++)
						{
							lTerminais3.Add(lTerminais3[0]);
						}
					}
					int num = lTerminais2.Count - 1;
					for (int j = 0; j <= num; j++)
					{
						if (lTerminais2[j].StartsWith("*"))
						{
							lTerminais3[j] = "*" + lTerminais3[j];
						}
					}
				}
				else
				{
					int num2 = lTerminais2.Count - 1;
					for (int k = 0; k <= num2; k++)
					{
						if (!lTerminais2[k].StartsWith("*"))
						{
							lTerminais3[k] = lTerminais3[k];
						}
						else
						{
							lTerminais3[k] = "*" + lTerminais3[k];
						}
					}
				}
			}
			int num3 = lTerminais2.Count - 1;
			for (int l = 0; l <= num3; l++)
			{
				lTerminais2[l] = lTerminais2[l].Replace("*", "");
			}
			Declaracoes2.MModeloDeMascara[] mModelo = new Declaracoes2.MModeloDeMascara[1];
			DicionarioMascaras.LeOsModelosDeMascaras(ref mModelo, bComplementarModelo: true);
			DeclaracoesEntidades.StructureMascara structureMascara = default;
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			_ = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val = database.TransactionManager.StartTransaction();
			try
			{
				ObjectId val2 = Geral.HandleToID(porta.HandleDaMascara);
				if (val2.IsValid)
				{
					Entity val3 = (Entity)val.GetObject(val2, (OpenMode)0);
					try
					{
						BlockReference blockRef = (BlockReference)val3;
						object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
						structureMascara = ((obj == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj));
					}
					finally
					{
						((IDisposable)val3)?.Dispose();
					}
				}
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
			string text = "";
			string text2 = "";
			int num4 = Information.UBound(mModelo);
			for (int m = 1; m <= num4; m++)
			{
				if (mModelo[m].iIndiceModelo == porta.indiceDoModelo)
				{
					text = mModelo[m].sNomeModelo;
					text2 = mModelo[m].sFabricante;
					break;
				}
			}
			if (BlockID.IsNull)
			{
				return;
			}
			DocumentLock val4 = Application.DocumentManager.MdiActiveDocument.LockDocument();
			try
			{
				Transaction val5 = database.TransactionManager.StartTransaction();
				try
				{
					BlockReference val6 = (BlockReference)val5.GetObject(BlockID, (OpenMode)0);
					try
					{
						BlockTableRecord val7 = (BlockTableRecord)val5.GetObject(val6.BlockTableRecord, (OpenMode)1);
						if (string.Compare(((SymbolTableRecord)val7).Name, val6.Name, ignoreCase: true) == 0)
						{
							AttributeCollection attributeCollection = val6.AttributeCollection;
							bool flag = false;
							bool flag2 = false;
							ObjectId val8;
							foreach (object item in attributeCollection)
							{
								val8 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
								AttributeReference val9 = (AttributeReference)val8.GetObject((OpenMode)1);
								if (Operators.CompareString(val9.Tag, "NOME2", TextCompare: true) == 0)
								{
									flag = true;
								}
								if (Operators.CompareString(val9.Tag, "NOME3", TextCompare: true) == 0)
								{
									flag2 = true;
								}
							}
							if (Operators.CompareString(porta.Nome2, "", TextCompare: true) != 0 && !flag)
							{
								porta.Nome1 = porta.Nome1 + DeclaracoesGeral.Conf.SeparadorCruzamento + porta.Nome2;
								porta.Nome2 = "";
							}
							if (Operators.CompareString(porta.Alternativo, "", TextCompare: true) != 0 && !flag2)
							{
								porta.Nome1 = porta.Nome1 + DeclaracoesGeral.Conf.SeparadorCruzamento + porta.Alternativo;
								porta.Alternativo = "";
							}
							foreach (object item2 in attributeCollection)
							{
								val8 = ((item2 == null) ? default(ObjectId) : ((ObjectId)item2));
								AttributeReference val9 = (AttributeReference)val8.GetObject((OpenMode)1);
								string value = "";
								if (Operators.CompareString(val9.Tag, "PAINEL", TextCompare: true) != 0)
								{
									if (Operators.CompareString(val9.Tag, "MODELO", TextCompare: true) != 0)
									{
										if (Operators.CompareString(val9.Tag, "FABRICANTE", TextCompare: true) != 0)
										{
											if (Operators.CompareString(val9.Tag, "NOME1", TextCompare: true) != 0)
											{
												if (Operators.CompareString(val9.Tag, "NOME2", TextCompare: true) != 0)
												{
													if (Operators.CompareString(val9.Tag, "NOME3", TextCompare: true) != 0)
													{
														if (Operators.CompareString(val9.Tag, "ORIGEM", TextCompare: true) != 0)
														{
															if (Operators.CompareString(val9.Tag, "EFC", TextCompare: true) != 0)
															{
																if (Versioned.IsNumeric(Strings.Mid(val9.Tag, 2, Strings.Len(val9.Tag))))
																{
																	int num5 = Conversions.ToInteger(Strings.Mid(val9.Tag, 2, Strings.Len(val9.Tag)));
																	int index = Conversions.ToInteger(Strings.Mid(val9.Tag, 2, Strings.Len(val9.Tag))) - 1;
																	if ((Operators.CompareString(Strings.Mid(val9.Tag, 1, 1), "T", TextCompare: true) == 0) & Versioned.IsNumeric(num5))
																	{
																		value = "";
																		if (num5 <= lTerminais.Count)
																		{
																			value = ((Operators.CompareString(lTerminais[index].Trim(), "", TextCompare: true) == 0) ? DeclaracoesGeral.Conf.CaracterTerminalIndefinido : lTerminais[index]);
																		}
																	}
																	if ((Operators.CompareString(Strings.Mid(val9.Tag, 1, 1), "B", TextCompare: true) == 0) & Versioned.IsNumeric(num5))
																	{
																		value = "";
																		if (num5 <= lTerminais2.Count)
																		{
																			value = ((Operators.CompareString(lTerminais2[index].Trim(), "", TextCompare: true) == 0) ? DeclaracoesGeral.Conf.CaracterTerminalIndefinido : lTerminais2[index]);
																		}
																	}
																	if ((Operators.CompareString(Strings.Mid(val9.Tag, 1, 1), "R", TextCompare: true) == 0) & Versioned.IsNumeric(num5))
																	{
																		value = "";
																		if (num5 <= lTerminais3.Count && Operators.CompareString(lTerminais3[index], "", TextCompare: true) != 0)
																		{
																			if (!lTerminais3[index].StartsWith("*"))
																			{
																				value = lTerminais3[index];
																				((Entity)val9).Visible = false;
																			}
																			else
																			{
																				value = Strings.Mid(lTerminais3[index], 2, Strings.Len(lTerminais3[index]));
																				((Entity)val9).Visible = true;
																			}
																		}
																	}
																}
															}
															else
															{
																value = mItensSelecionadosDG[iIndice].EFC;
															}
														}
														else
														{
															value = mItensSelecionadosDG[iIndice].PgDef;
														}
													}
													else
													{
														value = porta.Alternativo;
													}
												}
												else
												{
													value = porta.Nome2;
												}
											}
											else
											{
												value = porta.Nome1;
											}
										}
										else
										{
											value = text2;
										}
									}
									else
									{
										value = text;
									}
								}
								else
								{
									value = Dicionario.BuscaNomeDoPainel(structureMascara.Painel);
								}
								value = clsTextos.TiraNothing(value);
								((DBText)val9).TextString = value.Trim();
							}
						}
						DeclaracoesGeral.bAnularEventos = true;
						val5.Commit();
						DeclaracoesGeral.bAnularEventos = false;
					}
					finally
					{
						((IDisposable)val6)?.Dispose();
					}
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					val5.Abort();
					ProjectData.ClearProjectError();
				}
				finally
				{
					((IDisposable)val5)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val4)?.Dispose();
			}
		}
	}

	public static void AtribuiChavePrimaria()
	{
		bool flag = false;
		if (!XDataGeral.LerXDataConfiguracaoListaDePontos())
		{
			Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 281]), MsgBoxStyle.Information);
		}
		else if (Operators.CompareString(DeclaracoesGeral.ConfLP.listaDePontos.Trim(), "", TextCompare: true) != 0)
		{
			if (!File.Exists(DeclaracoesGeral.ConfLP.listaDePontos))
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 282]), MsgBoxStyle.Information);
			}
			else if (!Geral.IsFileInUse(DeclaracoesGeral.ConfLP.listaDePontos))
			{
				flag = true;
			}
			else
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1495]), MsgBoxStyle.Information);
			}
		}
		if (flag)
		{
			MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1120]), MsgBoxStyle.YesNo, "Elétron");
			if (msgBoxResult == MsgBoxResult.Yes)
			{
				PortaExportada[] mPortas = new PortaExportada[1];
				mTrocaChavePri[] mChaves = null;
				cDadosExcel cDadosExcel2 = new cDadosExcel();
				cDadosExcel2.ImportarPaginasPosLogico(ref mPortas);
				cDadosExcel2.fechaConexao();
				int num = 0;
				num = leaChavePrimariaAntigaDasPortas(ref mChaves, ref mPortas);
				AtualizaChavePrimaria(ref mChaves);
				Interaction.MsgBox(Operators.ConcatenateObject(Conversions.ToString(num) + " ", DeclaracoesGeral.mMensagem[1, 1121]), MsgBoxStyle.Information, "Elétron");
			}
		}
	}

	public static bool ExportaImportarPortas()
	{
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Expected Obj, but got Unknown
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Expected Obj, but got Unknown
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Expected Obj, but got Unknown
		//IL_040f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0414: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		bool flag = false;
		if (Operators.CompareString(DeclaracoesGeral.ConfLP.listaDePontos.Trim(), "", TextCompare: true) != 0)
		{
			if (!File.Exists(DeclaracoesGeral.ConfLP.listaDePontos))
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 282]), MsgBoxStyle.Information);
			}
			else if (!Geral.IsFileInUse(DeclaracoesGeral.ConfLP.listaDePontos))
			{
				flag = true;
			}
			else
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1495]), MsgBoxStyle.Information);
			}
		}
		checked
		{
			if (flag)
			{
				MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1112]), MsgBoxStyle.YesNo, "Elétron");
				if (msgBoxResult == MsgBoxResult.Yes)
				{
					PortaExportada[] mPortas = new PortaExportada[1];
					cDadosExcel cDadosExcel2 = new cDadosExcel();
					cDadosExcel2.ImportarPaginasPosLogico(ref mPortas);
					cDadosExcel2.fechaConexao();
					int num = Information.UBound(mPortas);
					for (int i = 1; i <= num; i++)
					{
						mPortas[i].sPosicaoFuncional = "";
					}
					if (Information.UBound(mPortas) > 0)
					{
						DeclaracoesGeral.Reguas RH = default;
						bool flag2 = false;
						DeclaracoesGeral.Reguas RH2 = default;
						bool flag3 = false;
						flag2 = XDataGeral.LeXDataReguaH(ref RH);
						flag3 = XDataGeral.LeXDataReguaV(ref RH2);
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
										num2++;
										if (num2 == 100)
										{
											DeclaracoesGeral._uscPagina.pbPasso(num2);
											num2 = 0;
										}
										Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
										try
										{
											BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
											try
											{
												Entity Ent;
												if (val6 == null)
												{
													MText val7 = (MText)(object)((val5 is MText) ? val5 : null);
													try
													{
														if (val7 == null)
														{
															DBText val8 = (DBText)(object)((val5 is DBText) ? val5 : null);
															try
															{
																if (val8 == null)
																{
																	continue;
																}
																Ent = (Entity)(object)val8;
																string text = XDataDispositivosMaster.LerXDataTextoLP(ref Ent);
																if (Operators.CompareString(text, "", TextCompare: true) == 0)
																{
																	continue;
																}
																int num3 = Information.UBound(mPortas);
																for (int j = 1; j <= num3; j++)
																{
																	if (Operators.CompareString(mPortas[j].sChavePrimaria, text, TextCompare: true) == 0)
																	{
																		((DBObject)val8).UpgradeOpen();
																		val8.TextString = mPortas[j].sDescricao.ToString();
																		break;
																	}
																}
															}
															finally
															{
																((IDisposable)val8)?.Dispose();
															}
															continue;
														}
														Ent = (Entity)(object)val7;
														string text2 = XDataDispositivosMaster.LerXDataTextoLP(ref Ent);
														if (Operators.CompareString(text2, "", TextCompare: true) == 0)
														{
															continue;
														}
														int num4 = Information.UBound(mPortas);
														for (int k = 1; k <= num4; k++)
														{
															if (Operators.CompareString(mPortas[k].sChavePrimaria, text2, TextCompare: true) == 0)
															{
																((DBObject)val7).UpgradeOpen();
																val7.Contents = mPortas[k].sDescricao.ToString();
																break;
															}
														}
													}
													finally
													{
														((IDisposable)val7)?.Dispose();
													}
													continue;
												}
												Ent = (Entity)(object)val6;
												string tipoImportado = "";
												if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref Ent, ref tipoImportado), "E", TextCompare: true) != 0)
												{
													continue;
												}
												DeclaracoesEntidades.StructurePortas structurePortas = default;
												BlockReference blockRef = val6;
												object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
												structurePortas = ((obj == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj));
												int num5 = Information.UBound(mPortas);
												for (int l = 1; l <= num5; l++)
												{
													if (Operators.CompareString(mPortas[l].sChavePrimaria, structurePortas.chavePrimaria, TextCompare: true) != 0)
													{
														continue;
													}
													mPortas[l].shandle = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
													mPortas[l].sDocFuncional = DeclaracoesGeral.Conf.Local;
													switch (DeclaracoesGeral.Conf.incluirColuna)
													{
													case 6:
													{
														string text4 = Pagina.BuscaAlternativo(((Entity)val6).Layer.ToString(), bretornaVazio: true);
														mPortas[l].sPosicaoFuncional = "(" + ((Entity)val6).Layer.ToString() + ")";
														if (Operators.CompareString(text4, "", TextCompare: true) != 0)
														{
															ref string sPosicaoFuncional = ref mPortas[l].sPosicaoFuncional;
															sPosicaoFuncional = sPosicaoFuncional + DeclaracoesGeral.Conf.SeparadorCruzamento + text4;
														}
														break;
													}
													case 0:
														mPortas[l].sPosicaoFuncional = ((Entity)val6).Layer.ToString();
														break;
													case 1:
													{
														ref PortaExportada reference3 = ref mPortas[l];
														string text7 = ((Entity)val6).Layer.ToString();
														string separadorCruzamento2 = DeclaracoesGeral.Conf.SeparadorCruzamento;
														Ent = (Entity)(object)val6;
														reference3.sPosicaoFuncional = text7 + separadorCruzamento2 + Pagina.calculaLinhaColuna(ref Ent, ref RH, ref RH2, flag2, flag3);
														break;
													}
													case 2:
													{
														ref PortaExportada reference4 = ref mPortas[l];
														Ent = (Entity)(object)val6;
														reference4.sPosicaoFuncional = Pagina.calculaLinhaColuna(ref Ent, ref RH, ref RH2, flag2, flag3) + DeclaracoesGeral.Conf.SeparadorCruzamento + ((Entity)val6).Layer.ToString();
														break;
													}
													case 3:
													{
														string text8 = Pagina.BuscaAlternativo(((Entity)val6).Layer.ToString(), bretornaVazio: true);
														if (Operators.CompareString(text8.Trim(), "", TextCompare: true) == 0)
														{
															text8 = ((Entity)val6).Layer.ToString();
														}
														mPortas[l].sPosicaoFuncional = text8;
														break;
													}
													case 4:
													{
														string text5 = Pagina.BuscaAlternativo(((Entity)val6).Layer.ToString(), bretornaVazio: true);
														if (Operators.CompareString(text5.Trim(), "", TextCompare: true) == 0)
														{
															text5 = ((Entity)val6).Layer.ToString();
														}
														ref PortaExportada reference2 = ref mPortas[l];
														string text6 = text5;
														string separadorCruzamento = DeclaracoesGeral.Conf.SeparadorCruzamento;
														Ent = (Entity)(object)val6;
														reference2.sPosicaoFuncional = text6 + separadorCruzamento + Pagina.calculaLinhaColuna(ref Ent, ref RH, ref RH2, flag2, flag3);
														break;
													}
													case 5:
													{
														string text3 = Pagina.BuscaAlternativo(((Entity)val6).Layer.ToString(), bretornaVazio: true);
														if (Operators.CompareString(text3.Trim(), "", TextCompare: true) == 0)
														{
															text3 = ((Entity)val6).Layer.ToString();
														}
														ref PortaExportada reference = ref mPortas[l];
														Ent = (Entity)(object)val6;
														reference.sPosicaoFuncional = Pagina.calculaLinhaColuna(ref Ent, ref RH, ref RH2, flag2, flag3) + DeclaracoesGeral.Conf.SeparadorCruzamento + text3;
														break;
													}
													}
													string sValor = " ";
													if (Operators.CompareString(mPortas[l].sPosicaoLogico.Trim(), "", TextCompare: true) != 0)
													{
														sValor = DeclaracoesGeral.Conf.PrefixoCruzExterno + mPortas[l].sPosicaoLogico + DeclaracoesGeral.Conf.SufixoCruzExterno;
													}
													clsBlocos.EditaUmAtributoDeUmBloco(ref mPortas[l].shandle, "LOGICO", sValor);
													clsBlocos.EditaUmAtributoDeUmBloco(ref mPortas[l].shandle, "FUNCAO", clsTextos.TiraNothing(mPortas[l].sFuncao));
													break;
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
								DeclaracoesGeral.bAnularEventos = true;
								val2.Commit();
								DeclaracoesGeral.bAnularEventos = false;
							}
							catch (Exception projectError)
							{
								ProjectData.SetProjectError(projectError);
								val2.Abort();
								result = false;
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
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
					if (Information.UBound(mPortas) > 0)
					{
						cDadosExcel cDadosExcel3 = new cDadosExcel();
						cDadosExcel3.exportaPaginasPosFuncional(ref mPortas);
						cDadosExcel3.fechaConexao();
					}
				}
			}
			return result;
		}
	}

	public static void BuscaDescricaoDaLP(ref Declaracoes2.StructureDescricaoLP[] PortasSelecionadas)
	{
		PortaExportada[] mPortas = new PortaExportada[1];
		cDadosExcel cDadosExcel2 = new cDadosExcel();
		cDadosExcel2.ImportarPaginasPosLogico(ref mPortas);
		cDadosExcel2.fechaConexao();
		if (PortasSelecionadas == null)
		{
			return;
		}
		int num = Information.UBound(mPortas);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				int num2 = Information.UBound(PortasSelecionadas);
				for (int j = 1; j <= num2; j++)
				{
					if (Operators.CompareString(mPortas[i].sChavePrimaria, PortasSelecionadas[j].chavePri, TextCompare: true) == 0)
					{
						PortasSelecionadas[j].sHandle = mPortas[i].shandle;
						PortasSelecionadas[j].sDesc = mPortas[i].sDescricao;
						break;
					}
				}
			}
		}
	}

	public static int leaChavePrimariaAntigaDasPortas(ref mTrocaChavePri[] mChaves, ref PortaExportada[] mPortas)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected Obj, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected Obj, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected Obj, but got Unknown
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected Obj, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		int num2 = 0;
		mChaves = new mTrocaChavePri[1];
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
							Entity val5 = (Entity)val2.GetObject(current, (OpenMode)1);
							try
							{
								Entity ent = val5;
								string tipoImportado = "";
								string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
								if (Operators.CompareString(left, "E", TextCompare: true) != 0)
								{
									continue;
								}
								BlockReference blockRef = (BlockReference)val5;
								object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
								DeclaracoesEntidades.StructurePortas Porta = ((obj == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj));
								num2++;
								mChaves = (mTrocaChavePri[])Utils.CopyArray(mChaves, new mTrocaChavePri[num2 + 1]);
								mChaves[num2].shandle = ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString();
								mChaves[num2].sChaveAnterior = Porta.chavePrimaria;
								mChaves[num2].sChaveNova = "";
								string text = Porta.Nome1;
								if (Operators.CompareString(Porta.Nome2, "", TextCompare: true) != 0)
								{
									text = Porta.Nome1 + "/" + Porta.Nome2;
								}
								tipoImportado = ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString();
								string text2 = clsBlocos.LeUmAtributoDeUmBloco(ref tipoImportado, "EFC");
								int num3 = Information.UBound(mPortas);
								for (int i = 1; i <= num3; i++)
								{
									if ((Operators.CompareString(mPortas[i].sUnidade.ToUpper().Trim(), text.ToUpper().Trim(), TextCompare: true) == 0) & (Operators.CompareString(mPortas[i].sEfc.ToUpper().Trim(), text2.ToUpper().Trim(), TextCompare: true) == 0))
									{
										mChaves[num2].sChaveNova = mPortas[i].sChavePrimaria;
										Porta.chavePrimaria = mPortas[i].sChavePrimaria;
										num++;
										break;
									}
								}
								if (Operators.CompareString(mChaves[num2].sChaveAnterior, mChaves[num2].sChaveNova, TextCompare: true) != 0)
								{
									ent = val5;
									XDataDispositivosMaster.GravarXDataPorta(ref ent, ref Porta);
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
			return num;
		}
	}

	public static void AtualizaChavePrimaria(ref mTrocaChavePri[] mChaves)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected Obj, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				new List<string>();
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
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
							Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
							try
							{
								MText val6 = (MText)(object)((val5 is MText) ? val5 : null);
								try
								{
									if (val6 != null)
									{
										Entity Ent = (Entity)(object)val6;
										string left = XDataDispositivosMaster.LerXDataTextoLP(ref Ent);
										if (Operators.CompareString(left, "", TextCompare: true) != 0)
										{
											int num2 = Information.UBound(mChaves);
											for (int i = 1; i <= num2; i++)
											{
												if (Operators.CompareString(left, mChaves[i].sChaveAnterior, TextCompare: true) == 0 && Operators.CompareString(mChaves[i].sChaveAnterior, mChaves[i].sChaveNova, TextCompare: true) != 0)
												{
													((DBObject)val6).UpgradeOpen();
													Ent = (Entity)(object)val6;
													XDataDispositivosMaster.GravarXDataTextoLP(ref Ent, mChaves[i].sChaveNova);
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
				((IDisposable)val)?.Dispose();
			}
		}
	}

	public static void AtualizaAsPortasTrocadas(structureAtributosSub[] mAtributosHandle)
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected Obj, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected Obj, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected Obj, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected Obj, but got Unknown
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Expected Obj, but got Unknown
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected Obj, but got Unknown
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		SyncPorta[] array = new SyncPorta[1];
		List<string> list = new List<string>();
		int num2 = Information.UBound(mAtributosHandle);
		checked
		{
			for (int i = 1; i <= num2; i++)
			{
				if (!list.Contains(mAtributosHandle[i].sHandleBlocoNovo))
				{
					list.Add(mAtributosHandle[i].sHandleBlocoNovo);
				}
			}
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
						Entity val4 = (Entity)val.GetObject(current, (OpenMode)0);
						try
						{
							if (list.Contains(((object)((DBObject)val4).Handle/*cast due to constrained. prefix*/).ToString()))
							{
								DeclaracoesEntidades.StructurePortas structurePortas = default;
								BlockReference blockRef = (BlockReference)val4;
								object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
								structurePortas = ((obj == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj));
								num = Information.UBound(array) + 1;
								array = (SyncPorta[])Utils.CopyArray(array, new SyncPorta[num + 1]);
								array[num].HandleMasc = structurePortas.HandleDaMascara;
								array[num].indiceModelo = Conversions.ToString(structurePortas.indiceDoModelo);
								array[num].indicePorta = Conversions.ToString(structurePortas.indiceDaPorta);
								array[num].HandlePorta = ((object)((DBObject)val4).Handle/*cast due to constrained. prefix*/).ToString();
							}
						}
						finally
						{
							((IDisposable)val4)?.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				SyncPorta syncPorta = default;
				if (Information.UBound(array) >= 2 && Information.UBound(array) > 0)
				{
					int num3 = Information.UBound(array);
					for (int j = 1; j <= num3; j++)
					{
						int num4 = Information.UBound(array) - 1;
						int num5 = j;
						for (int k = num4; k >= num5; k += -1)
						{
							if (Operators.CompareString(array[k].indiceModelo, array[k + 1].indiceModelo, TextCompare: true) > 0)
							{
								syncPorta = array[k + 1];
								array[k + 1] = array[k];
								array[k] = syncPorta;
							}
							if (Operators.CompareString(array[k].indiceModelo, array[k + 1].indiceModelo, TextCompare: true) == 0 && Operators.CompareString(array[k].indicePorta, array[k + 1].indicePorta, TextCompare: true) > 0)
							{
								syncPorta = array[k + 1];
								array[k + 1] = array[k];
								array[k] = syncPorta;
							}
						}
					}
				}
				int num6 = Information.UBound(array);
				for (int l = 1; l <= num6; l++)
				{
					Entity val5 = (Entity)Geral.HandleToObject(array[l].HandlePorta);
					try
					{
						if (val5 != null)
						{
							BlockReference blockRef = (BlockReference)val5;
							object obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
							DeclaracoesEntidades.StructurePortas porta = ((obj2 == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj2));
							ObjectId BlockID = ((DBObject)val5).ObjectId;
							AtualizaAtributosPorta(ref BlockID, porta, PreencheLogico: true);
						}
					}
					finally
					{
						((IDisposable)val5)?.Dispose();
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}

	public static void AtualizaAtributosPorta(ref ObjectId BlockID, DeclaracoesEntidades.StructurePortas porta, bool PreencheLogico)
	{
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Expected Obj, but got Unknown
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Expected Obj, but got Unknown
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Expected Obj, but got Unknown
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Expected Obj, but got Unknown
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Expected Obj, but got Unknown
		//IL_04c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0394: Unknown result type (might be due to invalid IL or missing references)
		//IL_0399: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03aa: Expected Obj, but got Unknown
		List<string> lTerminais = new List<string>();
		List<string> lTerminais2 = new List<string>();
		List<string> list = new List<string>();
		Declaracoes2.MModeloDeMascara[] mModelo = new Declaracoes2.MModeloDeMascara[1];
		DicionarioMascaras.LeOsModelosDeMascaras(ref mModelo, bComplementarModelo: false);
		Declaracoes2.MModeloDePortas[] mPortas = null;
		string sNomeModelo = " ";
		DicionarioMascaras.LeAsPortasDoModeloDoDicionario(ref porta.indiceDoModelo, sNomeModelo, ref mPortas);
		int num = 0;
		int num2 = Information.UBound(mPortas);
		checked
		{
			for (int i = 1; i <= num2; i++)
			{
				if (porta.indiceDaPorta == mPortas[i].IndiceDaPorta)
				{
					num = i;
					break;
				}
			}
			Geral.DivideTerminais(ref lTerminais, mPortas[num].sTerminais);
			Geral.DivideTerminais(ref lTerminais2, mPortas[num].sBornes);
			string text = "";
			int num3 = lTerminais2.Count - 1;
			for (int j = 0; j <= num3; j++)
			{
				if (Operators.CompareString(Strings.Mid(lTerminais2[j], 1, 1), "*", TextCompare: true) != 0)
				{
					text = text + mPortas[num].sRegua + " ;";
					continue;
				}
				text = text + "*" + mPortas[num].sRegua + " ;";
				lTerminais2[j] = Strings.Mid(lTerminais2[j], 2, Strings.Len(lTerminais2[j]));
			}
			DeclaracoesEntidades.StructureMascara structureMascara = default;
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			_ = Application.DocumentManager.MdiActiveDocument.Editor;
			DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
			try
			{
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					ObjectId val3 = Geral.HandleToID(porta.HandleDaMascara);
					if (val3.IsValid)
					{
						Entity val4 = (Entity)val2.GetObject(val3, (OpenMode)0);
						try
						{
							BlockReference blockRef = (BlockReference)val4;
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
							structureMascara = ((obj == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj));
						}
						finally
						{
							((IDisposable)val4)?.Dispose();
						}
					}
					string text2 = "";
					string text3 = "";
					int num4 = Information.UBound(mModelo);
					for (int k = 1; k <= num4; k++)
					{
						if (mModelo[k].iIndiceModelo == porta.indiceDoModelo)
						{
							text2 = mModelo[k].sNomeModelo;
							text3 = mModelo[k].sFabricante;
							break;
						}
					}
					if (BlockID.IsNull)
					{
						return;
					}
					BlockReference val5 = (BlockReference)val2.GetObject(BlockID, (OpenMode)0);
					try
					{
						BlockTableRecord val6 = (BlockTableRecord)val2.GetObject(val5.BlockTableRecord, (OpenMode)1);
						if (string.Compare(((SymbolTableRecord)val6).Name, val5.Name, ignoreCase: true) == 0)
						{
							AttributeCollection attributeCollection = val5.AttributeCollection;
							bool flag = false;
							bool flag2 = false;
							ObjectId val7;
							foreach (object item in attributeCollection)
							{
								val7 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
								AttributeReference val8 = (AttributeReference)val7.GetObject((OpenMode)1);
								if (Operators.CompareString(val8.Tag, "NOME2", TextCompare: true) == 0)
								{
									flag = true;
								}
								if (Operators.CompareString(val8.Tag, "NOME3", TextCompare: true) == 0)
								{
									flag2 = true;
								}
							}
							if (Operators.CompareString(porta.Nome2, "", TextCompare: true) != 0 && !flag)
							{
								porta.Nome1 = porta.Nome1 + DeclaracoesGeral.Conf.SeparadorCruzamento + porta.Nome2;
								porta.Nome2 = "";
							}
							if (Operators.CompareString(porta.Alternativo, "", TextCompare: true) != 0 && !flag2)
							{
								porta.Nome1 = porta.Nome1 + DeclaracoesGeral.Conf.SeparadorCruzamento + porta.Alternativo;
								porta.Alternativo = "";
							}
							foreach (object item2 in attributeCollection)
							{
								val7 = ((item2 == null) ? default(ObjectId) : ((ObjectId)item2));
								AttributeReference val8 = (AttributeReference)val7.GetObject((OpenMode)1);
								string text4 = ((DBText)val8).TextString;
								if (Operators.CompareString(val8.Tag, "PAINEL", TextCompare: true) != 0)
								{
									if (Operators.CompareString(val8.Tag, "MODELO", TextCompare: true) != 0)
									{
										if (Operators.CompareString(val8.Tag, "FABRICANTE", TextCompare: true) != 0)
										{
											if (Operators.CompareString(val8.Tag, "NOME1", TextCompare: true) != 0)
											{
												if (Operators.CompareString(val8.Tag, "NOME2", TextCompare: true) != 0)
												{
													if (Operators.CompareString(val8.Tag, "NOME3", TextCompare: true) != 0)
													{
														if (Operators.CompareString(val8.Tag, "ORIGEM", TextCompare: true) != 0)
														{
															if (Operators.CompareString(val8.Tag, "EFC", TextCompare: true) != 0)
															{
																if (Versioned.IsNumeric(Strings.Mid(val8.Tag, 2, Strings.Len(val8.Tag))))
																{
																	int num5 = Conversions.ToInteger(Strings.Mid(val8.Tag, 2, Strings.Len(val8.Tag)));
																	int index = Conversions.ToInteger(Strings.Mid(val8.Tag, 2, Strings.Len(val8.Tag))) - 1;
																	if (((Operators.CompareString(Strings.Mid(val8.Tag, 1, 1), "T", TextCompare: true) == 0) & Versioned.IsNumeric(num5)) && num5 <= lTerminais.Count && Operators.CompareString(text4, lTerminais[index], TextCompare: true) != 0)
																	{
																		text4 = lTerminais[index];
																	}
																	if (((Operators.CompareString(Strings.Mid(val8.Tag, 1, 1), "B", TextCompare: true) == 0) & Versioned.IsNumeric(num5)) && num5 <= lTerminais2.Count && Operators.CompareString(text4, lTerminais2[index], TextCompare: true) != 0)
																	{
																		text4 = lTerminais2[index];
																	}
																	if (((Operators.CompareString(Strings.Mid(val8.Tag, 1, 1), "R", TextCompare: true) == 0) & Versioned.IsNumeric(num5)) && num5 <= list.Count && Operators.CompareString(list[index], "", TextCompare: true) != 0)
																	{
																		if (Operators.CompareString(Strings.Mid(list[index], 1, 1), "*", TextCompare: true) != 0)
																		{
																			if (Operators.CompareString(text4, list[index], TextCompare: true) != 0)
																			{
																				text4 = list[index];
																			}
																			((Entity)val8).Visible = false;
																		}
																		else
																		{
																			if (Operators.CompareString(text4, Strings.Mid(list[index], 2, Strings.Len(list[index])), TextCompare: true) != 0)
																			{
																				text4 = Strings.Mid(list[index], 2, Strings.Len(list[index]));
																			}
																			((Entity)val8).Visible = true;
																		}
																	}
																}
															}
															else if (Operators.CompareString(text4, mPortas[num].sEFC, TextCompare: true) != 0)
															{
																text4 = mPortas[num].sEFC;
															}
														}
													}
													else if (Operators.CompareString(text4, porta.Alternativo, TextCompare: true) != 0)
													{
														text4 = porta.Alternativo;
													}
												}
												else if (Operators.CompareString(text4, porta.Nome2, TextCompare: true) != 0)
												{
													text4 = porta.Nome2;
												}
											}
											else if (Operators.CompareString(text4, porta.Nome1, TextCompare: true) != 0)
											{
												text4 = porta.Nome1;
											}
										}
										else if (Operators.CompareString(text4, text3, TextCompare: true) != 0)
										{
											text4 = text3;
										}
									}
									else if (Operators.CompareString(text4, text2, TextCompare: true) != 0)
									{
										text4 = text2;
									}
								}
								else
								{
									text4 = Dicionario.BuscaNomeDoPainel(structureMascara.Painel);
								}
								text4 = clsTextos.TiraNothing(text4);
								((DBText)val8).TextString = text4.Trim();
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
						ProjectData.ClearProjectError();
					}
					finally
					{
						((IDisposable)val5)?.Dispose();
					}
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
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

	public static void AtualizaPortasPortas(string sPainel, int indexModelo, Declaracoes2.MModeloDePortas[] mPortas)
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
		//IL_0906: Unknown result type (might be due to invalid IL or missing references)
		//IL_090d: Expected Obj, but got Unknown
		//IL_08cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_095d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0962: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Expected Obj, but got Unknown
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Expected Obj, but got Unknown
		//IL_035e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0364: Unknown result type (might be due to invalid IL or missing references)
		//IL_0309: Unknown result type (might be due to invalid IL or missing references)
		//IL_030e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_031f: Expected Obj, but got Unknown
		//IL_050a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0510: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f2: Expected Obj, but got Unknown
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
								BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
								try
								{
									Entity Ent;
									if (val6 == null)
									{
										DBText val7 = (DBText)(object)((val5 is DBText) ? val5 : null);
										if (val7 == null)
										{
											continue;
										}
										DeclaracoesEntidades.StructureDefinicaoPortas Def = default;
										Ent = (Entity)(object)val7;
										bool flag = XDataDispositivosMaster.LerXDataDefinicao(ref Ent, ref Def);
										val7 = (DBText)Ent;
										if (!flag)
										{
											continue;
										}
										bool flag2 = true;
										if (Def.indiceDoModelo != indexModelo)
										{
											continue;
										}
										int num = Information.UBound(mPortas);
										for (int i = 1; i <= num; i++)
										{
											if (Def.indiceDaPorta == mPortas[i].IndiceDaPorta)
											{
												flag2 = false;
												break;
											}
										}
										if (flag2)
										{
											IndefineUmaDefinicao(((object)((DBObject)val7).Handle/*cast due to constrained. prefix*/).ToString());
											clsTextos.AtualizarTexto(val7, "( )");
											flag2 = false;
										}
										continue;
									}
									Ent = (Entity)(object)val6;
									string tipoImportado = "";
									string left = XDataDispositivo.verificaTipoDispositivo(ref Ent, ref tipoImportado);
									if (Operators.CompareString(left, "E", TextCompare: true) != 0)
									{
										continue;
									}
									BlockReference blockRef = val6;
									object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
									DeclaracoesEntidades.StructurePortas structurePortas = ((obj == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj));
									if (structurePortas.indiceDoModelo != indexModelo)
									{
										continue;
									}
									bool flag3 = true;
									int num2 = Information.UBound(mPortas);
									for (int j = 1; j <= num2; j++)
									{
										if (structurePortas.indiceDaPorta != mPortas[j].IndiceDaPorta)
										{
											continue;
										}
										List<string> lTerminais = new List<string>();
										List<string> lTerminais2 = new List<string>();
										List<string> list = new List<string>();
										Declaracoes2.MModeloDeMascara[] mModelo = new Declaracoes2.MModeloDeMascara[1];
										DicionarioMascaras.LeOsModelosDeMascaras(ref mModelo, bComplementarModelo: false);
										Geral.DivideTerminais(ref lTerminais, mPortas[j].sTerminais);
										Geral.DivideTerminais(ref lTerminais2, mPortas[j].sBornes);
										string text = "";
										int num3 = lTerminais2.Count - 1;
										for (int k = 0; k <= num3; k++)
										{
											if (Operators.CompareString(Strings.Mid(lTerminais2[k], 1, 1), "*", TextCompare: true) != 0)
											{
												text = text + mPortas[k].sRegua + " ;";
												continue;
											}
											text = text + "*" + mPortas[k].sRegua + " ;";
											lTerminais2[k] = Strings.Mid(lTerminais2[k], 2, Strings.Len(lTerminais2[k]));
										}
										string text2 = "";
										string text3 = "";
										int num4 = Information.UBound(mModelo);
										for (int l = 1; l <= num4; l++)
										{
											if (mModelo[l].iIndiceModelo == structurePortas.indiceDoModelo)
											{
												text2 = mModelo[l].sNomeModelo;
												text3 = mModelo[l].sFabricante;
												break;
											}
										}
										BlockReference val8 = (BlockReference)val2.GetObject(((DBObject)val5).ObjectId, (OpenMode)0);
										try
										{
											BlockTableRecord val9 = (BlockTableRecord)val2.GetObject(val8.BlockTableRecord, (OpenMode)1);
											if (string.Compare(((SymbolTableRecord)val9).Name, val8.Name, ignoreCase: true) == 0)
											{
												AttributeCollection attributeCollection = val8.AttributeCollection;
												bool flag4 = false;
												bool flag5 = false;
												ObjectId val10;
												foreach (object item in attributeCollection)
												{
													val10 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
													AttributeReference val11 = (AttributeReference)val10.GetObject((OpenMode)1);
													if (Operators.CompareString(val11.Tag, "NOME2", TextCompare: true) == 0)
													{
														flag4 = true;
													}
													if (Operators.CompareString(val11.Tag, "NOME3", TextCompare: true) == 0)
													{
														flag5 = true;
													}
												}
												if (Operators.CompareString(structurePortas.Nome2, "", TextCompare: true) != 0 && !flag4)
												{
													structurePortas.Nome1 = structurePortas.Nome1 + DeclaracoesGeral.Conf.SeparadorCruzamento + structurePortas.Nome2;
													structurePortas.Nome2 = "";
												}
												if (Operators.CompareString(structurePortas.Alternativo, "", TextCompare: true) != 0 && !flag5)
												{
													structurePortas.Nome1 = structurePortas.Nome1 + DeclaracoesGeral.Conf.SeparadorCruzamento + structurePortas.Alternativo;
													structurePortas.Alternativo = "";
												}
												foreach (object item2 in attributeCollection)
												{
													val10 = ((item2 == null) ? default(ObjectId) : ((ObjectId)item2));
													AttributeReference val11 = (AttributeReference)val10.GetObject((OpenMode)1);
													string text4 = ((DBText)val11).TextString;
													if (Operators.CompareString(val11.Tag, "PAINEL", TextCompare: true) != 0)
													{
														if (Operators.CompareString(val11.Tag, "MODELO", TextCompare: true) != 0)
														{
															if (Operators.CompareString(val11.Tag, "FABRICANTE", TextCompare: true) != 0)
															{
																if (Operators.CompareString(val11.Tag, "NOME1", TextCompare: true) != 0)
																{
																	if (Operators.CompareString(val11.Tag, "NOME2", TextCompare: true) != 0)
																	{
																		if (Operators.CompareString(val11.Tag, "NOME3", TextCompare: true) != 0)
																		{
																			if (Operators.CompareString(val11.Tag, "ORIGEM", TextCompare: true) != 0)
																			{
																				if (Operators.CompareString(val11.Tag, "EFC", TextCompare: true) != 0)
																				{
																					if (Versioned.IsNumeric(Strings.Mid(val11.Tag, 2, Strings.Len(val11.Tag))))
																					{
																						int num5 = Conversions.ToInteger(Strings.Mid(val11.Tag, 2, Strings.Len(val11.Tag)));
																						int index = Conversions.ToInteger(Strings.Mid(val11.Tag, 2, Strings.Len(val11.Tag))) - 1;
																						text4 = "";
																						if (((Operators.CompareString(Strings.Mid(val11.Tag, 1, 1), "T", TextCompare: true) == 0) & Versioned.IsNumeric(num5)) && num5 <= lTerminais.Count && Operators.CompareString(text4, lTerminais[index], TextCompare: true) != 0)
																						{
																							text4 = lTerminais[index];
																						}
																						if (((Operators.CompareString(Strings.Mid(val11.Tag, 1, 1), "B", TextCompare: true) == 0) & Versioned.IsNumeric(num5)) && num5 <= lTerminais2.Count && Operators.CompareString(text4, lTerminais2[index], TextCompare: true) != 0)
																						{
																							text4 = lTerminais2[index];
																						}
																						if (((Operators.CompareString(Strings.Mid(val11.Tag, 1, 1), "R", TextCompare: true) == 0) & Versioned.IsNumeric(num5)) && num5 <= list.Count && Operators.CompareString(list[index], "", TextCompare: true) != 0)
																						{
																							if (Operators.CompareString(Strings.Mid(list[index], 1, 1), "*", TextCompare: true) != 0)
																							{
																								if (Operators.CompareString(text4, list[index], TextCompare: true) != 0)
																								{
																									text4 = list[index];
																								}
																								((Entity)val11).Visible = false;
																							}
																							else
																							{
																								if (Operators.CompareString(text4, Strings.Mid(list[index], 2, Strings.Len(list[index])), TextCompare: true) != 0)
																								{
																									text4 = Strings.Mid(list[index], 2, Strings.Len(list[index]));
																								}
																								((Entity)val11).Visible = true;
																							}
																						}
																					}
																				}
																				else if (Operators.CompareString(text4, mPortas[j].sEFC, TextCompare: true) != 0)
																				{
																					text4 = mPortas[j].sEFC;
																				}
																			}
																		}
																		else if (Operators.CompareString(text4, structurePortas.Alternativo, TextCompare: true) != 0)
																		{
																			text4 = structurePortas.Alternativo;
																		}
																	}
																	else if (Operators.CompareString(text4, structurePortas.Nome2, TextCompare: true) != 0)
																	{
																		text4 = structurePortas.Nome2;
																	}
																}
																else if (Operators.CompareString(text4, structurePortas.Nome1, TextCompare: true) != 0)
																{
																	text4 = structurePortas.Nome1;
																}
															}
															else if (Operators.CompareString(text4, text3, TextCompare: true) != 0)
															{
																text4 = text3;
															}
														}
														else if (Operators.CompareString(text4, text2, TextCompare: true) != 0)
														{
															text4 = text2;
														}
													}
													else
													{
														text4 = Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(sPainel));
													}
													text4 = clsTextos.TiraNothing(text4);
													((DBText)val11).TextString = text4.Trim();
												}
											}
										}
										finally
										{
											((IDisposable)val8)?.Dispose();
										}
										flag3 = false;
										break;
									}
									if (flag3)
									{
										IndefineUmaPorta(((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString(), bLimpaTudo: false);
										flag3 = false;
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
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
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

	public static void AtualizaPortasImportadasDoExcel(int indexModelo, List<int> lIndiceAntigo, List<int> lIndiceNovo)
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
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
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
							try
							{
								BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
								try
								{
									Entity Ent;
									if (val6 == null)
									{
										DBText val7 = (DBText)(object)((val5 is DBText) ? val5 : null);
										try
										{
											if (val7 != null)
											{
												DeclaracoesEntidades.StructureDefinicaoPortas Def = default;
												Ent = (Entity)(object)val7;
												if (XDataDispositivosMaster.LerXDataDefinicao(ref Ent, ref Def) && Def.indiceDoModelo == indexModelo && lIndiceAntigo.Contains(Def.indiceDaPorta) && !lIndiceNovo.Contains(Def.indiceDaPorta))
												{
													IndefineUmaDefinicao(((object)((DBObject)val7).Handle/*cast due to constrained. prefix*/).ToString());
													clsTextos.AtualizarTexto(val7, "( )");
												}
											}
										}
										finally
										{
											((IDisposable)val7)?.Dispose();
										}
										continue;
									}
									Ent = (Entity)(object)val6;
									string tipoImportado = "";
									string left = XDataDispositivo.verificaTipoDispositivo(ref Ent, ref tipoImportado);
									if (Operators.CompareString(left, "E", TextCompare: true) == 0)
									{
										BlockReference blockRef = val6;
										object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
										DeclaracoesEntidades.StructurePortas structurePortas = ((obj == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj));
										if (structurePortas.indiceDoModelo == indexModelo && lIndiceAntigo.Contains(structurePortas.indiceDaPorta) && !lIndiceNovo.Contains(structurePortas.indiceDaPorta))
										{
											IndefineUmaPorta(((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString(), bLimpaTudo: false);
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
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
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
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			throw;
		}
	}

	public static void EditaNomeDePortasDeUmaMascara(string shandle, string sNome1, string sNome2, string sAlternativo, bool bAlternativo)
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
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
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
						try
						{
							BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
							try
							{
								if (val6 == null)
								{
									continue;
								}
								Entity ent = (Entity)(object)val6;
								string tipoImportado = "";
								string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
								if (Operators.CompareString(left, "E", TextCompare: true) == 0)
								{
									BlockReference blockRef = val6;
									object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
									DeclaracoesEntidades.StructurePortas Porta = ((obj == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj));
									if (Operators.CompareString(Porta.HandleDaMascara, shandle, TextCompare: true) == 0)
									{
										Porta.Nome1 = sNome1;
										Porta.Nome2 = sNome2;
										Porta.Alternativo = sAlternativo;
										tipoImportado = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
										clsBlocos.EditaNomesDeUmBlocoDodispositivoPM(ref tipoImportado, Porta.Nome1, Porta.Nome2, Porta.Alternativo);
										ent = (Entity)(object)val6;
										XDataDispositivosMaster.GravarXDataPorta(ref ent, ref Porta);
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
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
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

	public static void AtualizaChavePrimariaPortasDefinicao(ref structureAtributosSub[] mHandle)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected Obj, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				new List<string>();
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
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
							Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
							try
							{
								BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
								try
								{
									int num2 = Information.UBound(mHandle);
									for (int i = 1; i <= num2; i++)
									{
										if (val6 != null)
										{
											Entity ent = (Entity)(object)val6;
											string tipoImportado = "";
											string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
											if (Operators.CompareString(left, "E", TextCompare: true) == 0)
											{
												BlockReference blockRef = val6;
												object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
												DeclaracoesEntidades.StructurePortas Porta = ((obj == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj));
												if (Operators.CompareString(Porta.HandleDaMascara, mHandle[i].sHandleBlocoAntigo, TextCompare: true) == 0)
												{
													Porta.HandleDaMascara = mHandle[i].sHandleBlocoNovo;
													ent = (Entity)(object)val6;
													XDataDispositivosMaster.GravarXDataPorta(ref ent, ref Porta);
												}
											}
										}
										DBText val7 = (DBText)(object)((val5 is DBText) ? val5 : null);
										try
										{
											if (val7 != null)
											{
												DeclaracoesEntidades.StructureDefinicaoPortas Def = default;
												Entity ent = (Entity)(object)val7;
												if (XDataDispositivosMaster.LerXDataDefinicao(ref ent, ref Def) && Operators.CompareString(Def.Nome.ToUpper(), "DEFINICAO", TextCompare: true) == 0 && Operators.CompareString(Def.HandleDaMascara, mHandle[i].sHandleBlocoAntigo, TextCompare: true) == 0)
												{
													Def.HandleDaMascara = mHandle[i].sHandleBlocoNovo;
													ent = (Entity)(object)val7;
													XDataDispositivosMaster.GravarXDataDefinicao(ref ent, ref Def);
												}
											}
										}
										finally
										{
											((IDisposable)val7)?.Dispose();
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
				((IDisposable)val)?.Dispose();
			}
		}
	}

	public static void CarregaTodasAsPortasPortas(ref Declaracoes2.MModeloDePortas[] mPORTASAlt)
	{
		Declaracoes2.MModeloDeMascara[] mModelo = null;
		Declaracoes2.MModeloDePortas[] array = null;
		Declaracoes2.MModeloDePortas[] mPortas = null;
		int num = 0;
		DicionarioMascaras.LeOsModelosDeMascaras(ref mModelo, bComplementarModelo: false);
		array = new Declaracoes2.MModeloDePortas[1];
		checked
		{
			try
			{
				int num2 = Information.UBound(mModelo);
				for (int i = 1; i <= num2; i++)
				{
					DicionarioMascaras.LeAsPortasDoModeloDoDicionario(ref mModelo[i].iIndiceModelo, mModelo[i].sNomeModelo, ref mPortas);
					int num3 = Information.UBound(mPortas);
					for (int j = 1; j <= num3; j++)
					{
						num++;
						array = (Declaracoes2.MModeloDePortas[])Utils.CopyArray(array, new Declaracoes2.MModeloDePortas[num + 1]);
						array[num] = mPortas[j];
					}
				}
				VerificaPortasDiscrepantes(array, ref mPORTASAlt);
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

	public static void VerificaPortasDiscrepantes(Declaracoes2.MModeloDePortas[] mPORTAS, ref Declaracoes2.MModeloDePortas[] mPORTASAlt)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected Obj, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected Obj, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Expected Obj, but got Unknown
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0351: Expected Obj, but got Unknown
		//IL_0590: Unknown result type (might be due to invalid IL or missing references)
		//IL_0595: Unknown result type (might be due to invalid IL or missing references)
		//IL_0717: Unknown result type (might be due to invalid IL or missing references)
		//IL_071c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0647: Unknown result type (might be due to invalid IL or missing references)
		//IL_064c: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a7: Unknown result type (might be due to invalid IL or missing references)
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
						mPORTASAlt = new Declaracoes2.MModeloDePortas[1];
						DeclaracoesGeral._uscPagina.Quantidade = Conversions.ToInteger(NewLateBinding.LateGet(((DBObject)val4).AcadObject, null, "count", new object[0], null, null, null));
						DeclaracoesGeral._uscPagina.pbIniciar();
						int num2 = 0;
						BlockTableRecordEnumerator enumerator = default;
						try
						{
							enumerator = val4.GetEnumerator();
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.Current;
								List<string> list = new List<string>();
								List<string> list2 = new List<string>();
								Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
								try
								{
									BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
									try
									{
										if (val6 != null)
										{
											Entity ent = (Entity)(object)val6;
											string tipoImportado = "";
											string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
											if (Operators.CompareString(left, "E", TextCompare: true) == 0)
											{
												BlockReference blockRef = val6;
												object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
												DeclaracoesEntidades.StructurePortas structurePortas = ((obj == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj));
												if (structurePortas.indiceDaPorta != 0)
												{
													int num3 = Information.UBound(mPORTAS);
													for (int i = 1; i <= num3; i++)
													{
														if (!((structurePortas.indiceDoModelo == mPORTAS[i].IndiceModelo) & (structurePortas.indiceDaPorta == mPORTAS[i].IndiceDaPorta)))
														{
															continue;
														}
														string[] array = mPORTAS[i].sTerminais.Split(';');
														string[] array2 = mPORTAS[i].sBornes.Split(';');
														((DBObject)val6).UpgradeOpen();
														AttributeCollection attributeCollection = val6.AttributeCollection;
														foreach (object item in attributeCollection)
														{
															object objectValue = RuntimeHelpers.GetObjectValue(item);
															AttributeReference val7 = (AttributeReference)NewLateBinding.LateGet(objectValue, null, "GetObject", new object[1] { (object)(OpenMode)1 }, null, null, null);
															if (!Versioned.IsNumeric(Strings.Mid(val7.Tag, 2, Strings.Len(val7.Tag))))
															{
																continue;
															}
															int num4 = Conversions.ToInteger(Strings.Mid(val7.Tag, 2, Strings.Len(val7.Tag)));
															_ = Conversions.ToInteger(Strings.Mid(val7.Tag, 2, Strings.Len(val7.Tag))) - 1;
															if ((Operators.CompareString(Strings.Mid(val7.Tag, 1, 1), "B", TextCompare: true) == 0) & Versioned.IsNumeric(num4))
															{
																string text = array2[num4 - 1];
																if (!text.Contains("*"))
																{
																	list2.Add(val7.Tag);
																}
																else
																{
																	list.Add(val7.Tag);
																}
															}
														}
														foreach (object item2 in attributeCollection)
														{
															object objectValue2 = RuntimeHelpers.GetObjectValue(item2);
															AttributeReference val7 = (AttributeReference)NewLateBinding.LateGet(objectValue2, null, "GetObject", new object[1] { (object)(OpenMode)1 }, null, null, null);
															string textString = ((DBText)val7).TextString;
															if (!Versioned.IsNumeric(Strings.Mid(val7.Tag, 2, Strings.Len(val7.Tag))))
															{
																continue;
															}
															int num5 = Conversions.ToInteger(Strings.Mid(val7.Tag, 2, Strings.Len(val7.Tag)));
															_ = Conversions.ToInteger(Strings.Mid(val7.Tag, 2, Strings.Len(val7.Tag))) - 1;
															if ((Operators.CompareString(Strings.Mid(val7.Tag, 1, 1), "T", TextCompare: true) == 0) & Versioned.IsNumeric(num5))
															{
																if (array.Count() < num5)
																{
																	num++;
																	mPORTASAlt = (Declaracoes2.MModeloDePortas[])Utils.CopyArray(mPORTASAlt, new Declaracoes2.MModeloDePortas[num + 1]);
																	mPORTASAlt[num] = mPORTAS[i];
																	mPORTASAlt[num].HandlePorta = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
																	mPORTASAlt[num].sTerminais = textString;
																	mPORTASAlt[num].sBornes = "";
																	mPORTASAlt[num].sRegua = "";
																	mPORTASAlt[num].HandleDef = "";
																}
																else if (Operators.CompareString(array[num5 - 1], textString, TextCompare: true) != 0)
																{
																	num++;
																	mPORTASAlt = (Declaracoes2.MModeloDePortas[])Utils.CopyArray(mPORTASAlt, new Declaracoes2.MModeloDePortas[num + 1]);
																	mPORTASAlt[num] = mPORTAS[i];
																	mPORTASAlt[num].HandlePorta = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
																	mPORTASAlt[num].sTerminais = textString;
																	mPORTASAlt[num].sBornes = "";
																	mPORTASAlt[num].sRegua = "";
																	mPORTASAlt[num].HandleDef = array[num5 - 1];
																}
															}
															if ((Operators.CompareString(Strings.Mid(val7.Tag, 1, 1), "B", TextCompare: true) == 0) & Versioned.IsNumeric(num5))
															{
																string text2 = array2[num5 - 1];
																text2 = text2.Replace("*", "");
																if (Operators.CompareString(text2, textString, TextCompare: true) != 0)
																{
																	num++;
																	mPORTASAlt = (Declaracoes2.MModeloDePortas[])Utils.CopyArray(mPORTASAlt, new Declaracoes2.MModeloDePortas[num + 1]);
																	mPORTASAlt[num] = mPORTAS[i];
																	mPORTASAlt[num].HandlePorta = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
																	mPORTASAlt[num].sTerminais = "";
																	mPORTASAlt[num].sBornes = textString;
																	mPORTASAlt[num].sRegua = "";
																	mPORTASAlt[num].HandleDef = text2;
																}
															}
															if ((Operators.CompareString(Strings.Mid(val7.Tag, 1, 1), "R", TextCompare: true) == 0) & Versioned.IsNumeric(num5))
															{
																bool flag = false;
																string tag = val7.Tag;
																tag = tag.Replace("R", "B");
																if (list.Contains(tag))
																{
																	flag = !((Entity)val7).Visible;
																}
																if ((Operators.CompareString(mPORTAS[i].sRegua, textString, TextCompare: true) != 0) | flag)
																{
																	num++;
																	mPORTASAlt = (Declaracoes2.MModeloDePortas[])Utils.CopyArray(mPORTASAlt, new Declaracoes2.MModeloDePortas[num + 1]);
																	mPORTASAlt[num] = mPORTAS[i];
																	mPORTASAlt[num].HandlePorta = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
																	mPORTASAlt[num].sTerminais = "";
																	mPORTASAlt[num].sBornes = "";
																	mPORTASAlt[num].sRegua = textString;
																	mPORTASAlt[num].HandleDef = mPORTAS[i].sRegua;
																}
															}
														}
													}
												}
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
						DeclaracoesGeral._uscPagina.pbFim();
						hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
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
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				throw;
			}
		}
	}

	public static void corrigeAsPortas()
	{
		Declaracoes2.MModeloDeMascara[] mModelo = null;
		Declaracoes2.MModeloDePortas[] array = null;
		Declaracoes2.MModeloDePortas[] mPortas = null;
		int num = 0;
		DicionarioMascaras.LeOsModelosDeMascaras(ref mModelo, bComplementarModelo: false);
		array = new Declaracoes2.MModeloDePortas[1];
		checked
		{
			try
			{
				int num2 = Information.UBound(mModelo);
				for (int i = 1; i <= num2; i++)
				{
					DicionarioMascaras.LeAsPortasDoModeloDoDicionario(ref mModelo[i].iIndiceModelo, mModelo[i].sNomeModelo, ref mPortas);
					int num3 = Information.UBound(mPortas);
					for (int j = 1; j <= num3; j++)
					{
						num++;
						array = (Declaracoes2.MModeloDePortas[])Utils.CopyArray(array, new Declaracoes2.MModeloDePortas[num + 1]);
						array[num] = mPortas[j];
					}
				}
				EditaTodasPortas(array);
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
}

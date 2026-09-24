using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.EditorInput;

namespace Eletron4;

public class PointMonitorToolTips
{
	public static void StartMonitor()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected Obj, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected Obj, but got Unknown
		try
		{
			if (!Information.IsNothing(Application.DocumentManager.MdiActiveDocument))
			{
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				editor.PointMonitor -= mPLpnCoWslb;
				editor.PointMonitor += mPLpnCoWslb;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox("Error: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public static void StopMonitor()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected Obj, but got Unknown
		try
		{
			if (!Information.IsNothing(Application.DocumentManager.MdiActiveDocument))
			{
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				editor.PointMonitor -= mPLpnCoWslb;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox("Error: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	private static void mPLpnCoWslb(Editor P_0, PointMonitorEventArgs P_1)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected Obj, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_139e: Unknown result type (might be due to invalid IL or missing references)
		//IL_13a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_116e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1173: Unknown result type (might be due to invalid IL or missing references)
		//IL_29a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_29af: Expected Obj, but got Unknown
		//IL_3d3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3d43: Expected Obj, but got Unknown
		//IL_3d4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3d51: Unknown result type (might be due to invalid IL or missing references)
		//IL_15d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_15db: Expected Obj, but got Unknown
		//IL_29c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_29ca: Expected Obj, but got Unknown
		//IL_3dd6: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ddd: Expected Obj, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3dfd: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e04: Expected Obj, but got Unknown
		//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c04: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c0b: Expected Obj, but got Unknown
		//IL_4687: Unknown result type (might be due to invalid IL or missing references)
		//IL_468c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e32: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e39: Expected Obj, but got Unknown
		//IL_0367: Unknown result type (might be due to invalid IL or missing references)
		//IL_036e: Expected Obj, but got Unknown
		//IL_1774: Unknown result type (might be due to invalid IL or missing references)
		//IL_177b: Expected Obj, but got Unknown
		//IL_1af4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1af9: Unknown result type (might be due to invalid IL or missing references)
		//IL_4e33: Unknown result type (might be due to invalid IL or missing references)
		//IL_4e38: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e57: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e5e: Expected Obj, but got Unknown
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_0389: Expected Obj, but got Unknown
		//IL_1074: Unknown result type (might be due to invalid IL or missing references)
		//IL_1079: Unknown result type (might be due to invalid IL or missing references)
		//IL_292a: Unknown result type (might be due to invalid IL or missing references)
		//IL_292f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e85: Expected Obj, but got Unknown
		//IL_0767: Unknown result type (might be due to invalid IL or missing references)
		//IL_076c: Unknown result type (might be due to invalid IL or missing references)
		//IL_110e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1113: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ebd: Expected Obj, but got Unknown
		//IL_38e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_38ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_48c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_48c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_4c89: Unknown result type (might be due to invalid IL or missing references)
		//IL_4c8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ea9: Unknown result type (might be due to invalid IL or missing references)
		//IL_3eb0: Expected Obj, but got Unknown
		//IL_07d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_391d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3924: Expected Obj, but got Unknown
		//IL_434f: Unknown result type (might be due to invalid IL or missing references)
		//IL_4354: Unknown result type (might be due to invalid IL or missing references)
		//IL_500c: Unknown result type (might be due to invalid IL or missing references)
		//IL_5011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0849: Unknown result type (might be due to invalid IL or missing references)
		//IL_084e: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_08bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e94: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e99: Unknown result type (might be due to invalid IL or missing references)
		//IL_40f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_40f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0509: Unknown result type (might be due to invalid IL or missing references)
		//IL_050e: Unknown result type (might be due to invalid IL or missing references)
		//IL_092e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0933: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a16: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a87: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_21db: Unknown result type (might be due to invalid IL or missing references)
		//IL_21e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_2612: Unknown result type (might be due to invalid IL or missing references)
		//IL_2617: Unknown result type (might be due to invalid IL or missing references)
		FullSubentityPath[] pickedEntities = P_1.Context.GetPickedEntities();
		if (pickedEntities.Length == 0)
		{
			return;
		}
		Editor val = P_0;
		Document document = val.Document;
		try
		{
			Transaction val2 = document.TransactionManager.StartTransaction();
			try
			{
				string text = "";
				List<string> list = new List<string>();
				FullSubentityPath[] array = pickedEntities;
				int num = 0;
				if (0 < array.Length)
				{
					FullSubentityPath val3 = array[num];
					ObjectId[] objectIds = val3.GetObjectIds();
					if (objectIds.Length > 0)
					{
						ObjectId val4 = objectIds[0];
						DBObject val5 = val2.GetObject(val4, (OpenMode)0);
						try
						{
							if (val5 != null && !list.Contains(((object)val5.Handle/*cast due to constrained. prefix*/).ToString()))
							{
								if (Operators.CompareString(text, "", TextCompare: true) != 0)
								{
									text += "\r\n\r\n";
								}
								BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
								try
								{
									string tag;
									string text5;
									Entity Ent;
									int painel2;
									if (val6 == null)
									{
										Polyline pl = (Polyline)(object)((val5 is Polyline) ? val5 : null);
										DBText val7 = (DBText)(object)((val5 is DBText) ? val5 : null);
										if (val7 != null)
										{
											ResultBuffer xDataForApplication = ((DBObject)val7).GetXDataForApplication("AUXINTERLIG");
											if (xDataForApplication != null)
											{
												TypedValue[] array2 = xDataForApplication.AsArray();
												pl = (Polyline)Geral.HandleToObject(Conversions.ToString(array2[2].Value));
											}
										}
										if (pl == null)
										{
											DBText val8 = (DBText)(object)((val5 is DBText) ? val5 : null);
											try
											{
												if (val8 == null)
												{
													goto end_IL_0119;
												}
												list.Add(((object)((DBObject)val8).Handle/*cast due to constrained. prefix*/).ToString());
												string handle = "";
												DBText text2 = val8;
												short tipo = default;
												if (XDataDispositivo.lerXDataDePara(ref text2, ref handle, ref tipo))
												{
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 745], "\n")));
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 746], handle), "\n")));
													text = text + "Handle: " + ((object)((DBObject)val8).Handle/*cast due to constrained. prefix*/).ToString();
												}
												DeclaracoesEntidades.StructureDefinicaoPortas Def = default;
												Ent = (Entity)(object)val8;
												if (XDataDispositivosMaster.LerXDataDefinicao(ref Ent, ref Def))
												{
													text = "";
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 955], "\n")));
													Entity val9 = (Entity)Geral.HandleToObject(Def.HandleDaMascara);
													if (val9 != null)
													{
														DeclaracoesEntidades.StructureMascara structureMascara = default;
														BlockReference blockRef = (BlockReference)val9;
														object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
														val9 = (Entity)(object)blockRef;
														object obj2 = obj;
														structureMascara = ((obj2 == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj2));
														if (structureMascara.Painel != 0)
														{
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 702], PainelValido(structureMascara.Painel)), "\n")));
														}
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 935], structureMascara.Nome1), "\n")));
														if (Operators.CompareString(structureMascara.Nome2, "", TextCompare: true) != 0)
														{
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 936], structureMascara.Nome2), "\n")));
														}
														if (Operators.CompareString(structureMascara.Alternativo, "", TextCompare: true) != 0)
														{
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 937], structureMascara.Alternativo), "\n")));
														}
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 946], Def.indiceDoModelo.ToString()), "\n")));
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1206], " "), Def.indiceDaPorta.ToString()), "\n")));
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 308], structureMascara.Usuario), "\n")));
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 309], structureMascara.Data), "\n")));
														text = text + "Handle: " + ((object)((DBObject)val8).Handle/*cast due to constrained. prefix*/).ToString();
													}
												}
												text2 = val8;
												string text3 = Conversions.ToString(XDataGeral.LeXDataTitulo(ref text2));
												if (Operators.CompareString(text3, "", TextCompare: true) != 0)
												{
													string left = text3;
													if (Operators.CompareString(left, "1", TextCompare: true) != 0)
													{
														if (Operators.CompareString(left, "2", TextCompare: true) != 0)
														{
															if (Operators.CompareString(left, "3", TextCompare: true) != 0)
															{
																if (Operators.CompareString(left, "4", TextCompare: true) != 0)
																{
																	if (Operators.CompareString(left, "5", TextCompare: true) != 0)
																	{
																		if (Operators.CompareString(left, "6", TextCompare: true) != 0)
																		{
																			if (Operators.CompareString(left, "7", TextCompare: true) != 0)
																			{
																				if (Operators.CompareString(left, "8", TextCompare: true) != 0)
																				{
																					if (Operators.CompareString(left, "9", TextCompare: true) == 0)
																					{
																						text = Conversions.ToString(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n"), DeclaracoesGeral.mMensagem[1, 10].ToString().ToUpper()), "\n"), "Handle: "), ((object)((DBObject)val8).Handle/*cast due to constrained. prefix*/).ToString()));
																					}
																				}
																				else
																				{
																					text = Conversions.ToString(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n"), DeclaracoesGeral.mMensagem[1, 62].ToString().ToUpper()), "\n"), "Handle: "), ((object)((DBObject)val8).Handle/*cast due to constrained. prefix*/).ToString()));
																				}
																			}
																			else
																			{
																				text = Conversions.ToString(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n"), DeclaracoesGeral.mMensagem[1, 1080].ToString().ToUpper()), "\n"), "Handle: "), ((object)((DBObject)val8).Handle/*cast due to constrained. prefix*/).ToString()));
																			}
																		}
																		else
																		{
																			text = Conversions.ToString(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n"), DeclaracoesGeral.mMensagem[1, 287].ToString().ToUpper()), "\n"), "Handle: "), ((object)((DBObject)val8).Handle/*cast due to constrained. prefix*/).ToString()));
																		}
																	}
																	else
																	{
																		text = Conversions.ToString(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n"), DeclaracoesGeral.mMensagem[1, 1184].ToString().ToUpper()), "\n"), "Handle: "), ((object)((DBObject)val8).Handle/*cast due to constrained. prefix*/).ToString()));
																	}
																}
																else
																{
																	text = Conversions.ToString(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n"), DeclaracoesGeral.mMensagem[1, 43].ToString().ToUpper()), "\n"), "Handle: "), ((object)((DBObject)val8).Handle/*cast due to constrained. prefix*/).ToString()));
																}
															}
															else
															{
																text = Conversions.ToString(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n"), DeclaracoesGeral.mMensagem[1, 42].ToString().ToUpper()), "\n"), "Handle: "), ((object)((DBObject)val8).Handle/*cast due to constrained. prefix*/).ToString()));
															}
														}
														else
														{
															text = Conversions.ToString(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n"), DeclaracoesGeral.mMensagem[1, 41].ToString().ToUpper()), "\n"), "Handle: "), ((object)((DBObject)val8).Handle/*cast due to constrained. prefix*/).ToString()));
														}
													}
													else
													{
														text = Conversions.ToString(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n"), DeclaracoesGeral.mMensagem[1, 40].ToString().ToUpper()), "\n"), "Handle: "), ((object)((DBObject)val8).Handle/*cast due to constrained. prefix*/).ToString()));
													}
												}
												string revisao = "";
												int painel = 0;
												DeclaracoesInterligacao.caboAranha caboAranha = default;
												string tag_cabo = "";
												string veia = "";
												DeclaracoesInterligacao.borneAranha bn = default;
												text2 = val8;
												if (!XDataAranha.LerXDataNomeRegua(ref text2, ref bn))
												{
													Ent = (Entity)(object)val8;
													bool bRebatido = false;
													if (!XDataDInterlig.LerXDataVeia(ref Ent, ref revisao, ref painel, ref tag_cabo, ref veia, ref handle, ref bRebatido))
													{
														Ent = (Entity)(object)val8;
														if (XDataAranha.LerXDataVeia(ref Ent, ref revisao, ref painel, ref tag_cabo, ref veia, ref handle))
														{
															text = "";
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1464], "\n")));
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 702], PainelValido(painel)), "\n")));
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 62], ": "), revisao), "\n")));
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1288], ": "), tag_cabo), "\n")));
															if (Operators.CompareString(veia, "", TextCompare: true) != 0)
															{
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1569], ": "), veia), "\n")));
															}
															else
															{
																text = (val8.TextString.Contains(",") ? Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1239], ": "), DeclaracoesGeral.mMensagem[1, 1049]), "\n"))) : Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1569], ": "), DeclaracoesGeral.mMensagem[1, 1049]), "\n"))));
															}
														}
														string handle2 = "";
														Ent = (Entity)(object)val8;
														painel2 = 0;
														tag = "";
														if (XDataLayout.lerXDataTextoLayout(ref Ent, ref painel2, ref tag, ref handle2))
														{
															clsBlocos.MostraBloco(handle2, bZoom: false);
														}
														string handle3 = "";
														text2 = val8;
														int potencial = default;
														int enderecamento = default;
														if (XDataConexao.lerXDataAuxCircuito(ref text2, ref potencial, ref handle3, ref enderecamento, ref tipo))
														{
															text = "";
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
															if (tipo != 1)
															{
																if (tipo != 2)
																{
																	if (tipo == 3)
																	{
																		text = Conversions.ToString(Operators.AddObject(text, Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 179], " "), Operators.AddObject(DeclaracoesGeral.mMensagem[1, 49], "\n"))));
																	}
																}
																else
																{
																	text = Conversions.ToString(Operators.AddObject(text, Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 179], " "), Operators.AddObject(DeclaracoesGeral.mMensagem[1, 48], "\n"))));
																}
															}
															else
															{
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 686], "\n")));
															}
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 311], potencial.ToString()), "\n")));
														}
													}
													else
													{
														text = "";
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1464], "\n")));
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 702], PainelValido(painel)), "\n")));
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 62], ": "), revisao), "\n")));
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1288], ": "), tag_cabo), "\n")));
														if (Operators.CompareString(veia, "", TextCompare: true) != 0)
														{
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1569], ": "), veia), "\n")));
														}
													}
												}
												else
												{
													text = "";
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1464], "\n")));
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 702], PainelValido(bn.Painel)), "\n")));
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 62], ": "), bn.Revisao), "\n")));
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 788], ": "), bn.Tag), "\n")));
												}
												goto end_IL_00e0;
												end_IL_0119:;
											}
											finally
											{
												((IDisposable)val8)?.Dispose();
											}
											MText val10 = (MText)(object)((val5 is MText) ? val5 : null);
											try
											{
												if (val10 != null)
												{
													list.Add(((object)((DBObject)val10).Handle/*cast due to constrained. prefix*/).ToString());
													string text4 = "";
													Ent = (Entity)(object)val10;
													text4 = XDataDispositivosMaster.LerXDataTextoLP(ref Ent);
													if (Operators.CompareString(text4, "", TextCompare: true) != 0)
													{
														text = "";
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
														text += "Texto LP\n";
														text = text + "Chave Primaria: " + text4 + "\n";
														text = text + "Handle: " + ((object)((DBObject)val10).Handle/*cast due to constrained. prefix*/).ToString();
													}
												}
											}
											finally
											{
												((IDisposable)val10)?.Dispose();
											}
										}
										else
										{
											list.Add(((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString());
											DeclaracoesEntidades.StructureConexao conex = default;
											if (XDataConexao.lerXDataConexao(ref pl, ref conex))
											{
												DicionarioAplicacao.carregaDicAplicacao();
												if (conex.Tipo != 1)
												{
													if (conex.Tipo != 2)
													{
														if (conex.Tipo != 3)
														{
															if (conex.Tipo == 4)
															{
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 621], "\n")));
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 702], PainelValido(conex.Painel)), "\n")));
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 311], conex.Potencial.ToString()), "\n")));
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 612], conex.Secao.ToString()), "\n")));
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 613], conex.Cor.ToString()), "\n")));
																if (conex.Enderecamento != 1)
																{
																	if (conex.Enderecamento == 2)
																	{
																		text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 694], "\n")));
																	}
																}
																else
																{
																	text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 693], "\n")));
																}
																if (conex.Disp1)
																{
																	text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1954], DeclaracoesGeral.mMensagem[1, 1955]), "\n")));
																}
																if (conex.Disp2)
																{
																	text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1954], DeclaracoesGeral.mMensagem[1, 1956]), "\n")));
																}
																if (!conex.Disp1 & !conex.Disp2)
																{
																	text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1957], "\n")));
																}
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 308], conex.Usuario), "\n")));
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 309], conex.Data), "\n")));
																text = text + "Handle: " + ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString() + "\n";
															}
														}
														else
														{
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
															if (Operators.CompareString(conex.Jumper, "", TextCompare: true) != 0)
															{
																if (Operators.CompareString(conex.Jumper, "JUMPER", TextCompare: true) == 0)
																{
																	text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 620], "\n")));
																}
															}
															else
															{
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 307], "\n")));
																if (Operators.CompareString(conex.Nome, "", TextCompare: true) != 0)
																{
																	text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 701], conex.Nome), "\n")));
																}
															}
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 702], PainelValido(conex.Painel)), "\n")));
															if (conex.Aplicacao > 0 && DeclaracoesGeral.dicAplicacao.ContainsKey(conex.Aplicacao))
															{
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1824], DeclaracoesGeral.dicAplicacao[conex.Aplicacao]), "\n")));
															}
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 311], conex.Potencial.ToString()), "\n")));
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 612], conex.Secao.ToString()), "\n")));
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 613], conex.Cor.ToString()), "\n")));
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 308], conex.Usuario), "\n")));
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 309], conex.Data), "\n")));
															text = text + "Handle: " + ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString() + "\n";
															text = text + "Handle Sup: " + conex.Handle.ToString();
														}
													}
													else
													{
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 306], "\n")));
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 702], PainelValido(conex.Painel)), "\n")));
														if (conex.Aplicacao > 0 && DeclaracoesGeral.dicAplicacao.ContainsKey(conex.Aplicacao))
														{
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1824], DeclaracoesGeral.dicAplicacao[conex.Aplicacao]), "\n")));
														}
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 311], conex.Potencial.ToString()), "\n")));
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 612], conex.Secao.ToString()), "\n")));
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 613], conex.Cor.ToString()), "\n")));
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 308], conex.Usuario), "\n")));
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 309], conex.Data), "\n")));
														text = text + "Handle: " + ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
													}
												}
												else
												{
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 687], "\n")));
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 702], PainelValido(conex.Painel)), "\n")));
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 701], conex.Nome), "\n")));
													if (conex.Aplicacao > 0 && DeclaracoesGeral.dicAplicacao.ContainsKey(conex.Aplicacao))
													{
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1824], DeclaracoesGeral.dicAplicacao[conex.Aplicacao]), "\n")));
													}
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 311], conex.Potencial.ToString()), "\n")));
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 612], conex.Secao.ToString()), "\n")));
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 613], conex.Cor.ToString()), "\n")));
													if (conex.Enderecamento != 1)
													{
														if (conex.Enderecamento == 2)
														{
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 694], "\n")));
														}
													}
													else
													{
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 693], "\n")));
													}
													if (conex.Disp1)
													{
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1954], DeclaracoesGeral.mMensagem[1, 1955]), "\n")));
													}
													if (conex.Disp2)
													{
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1954], DeclaracoesGeral.mMensagem[1, 1956]), "\n")));
													}
													if (!conex.Disp1 & !conex.Disp2)
													{
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1957], "\n")));
													}
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 308], conex.Usuario), "\n")));
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 309], conex.Data), "\n")));
													text = text + "Handle: " + ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
												}
											}
											DeclaracoesEntidades.StructureInterligacao ilig = default;
											if (XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig))
											{
												if (ilig.Tipo != 1)
												{
													if (ilig.Tipo != 2)
													{
														if (ilig.Tipo == 3)
														{
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 741], "\n")));
															text = ((Operators.CompareString(ilig.Tag_Cabo, "", TextCompare: true) != 0) ? Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 737], ilig.Tag_Cabo), DeclaracoesGeral.Conf.SeparadorCaboVeia), ilig.NomeVeia), "\n"))) : Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 737], DeclaracoesGeral.mMensagem[1, 740]), "\n"))));
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 739], PainelValido(ilig.Painel2)), "\n")));
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 308], ilig.Usuario), "\n")));
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 309], ilig.Data), "\n")));
															text = text + "Handle: " + ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
														}
													}
													else
													{
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1594], "\n")));
														text = ((Operators.CompareString(ilig.Tag_Cabo, "", TextCompare: true) != 0) ? Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 737], ilig.Tag_Cabo), DeclaracoesGeral.Conf.SeparadorCaboVeia), ilig.NumVeia.ToString()), "\n"))) : Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 737], DeclaracoesGeral.mMensagem[1, 740]), "\n"))));
														text = ((ilig.Painel1 == 0) ? Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 739], PainelValido(ilig.Painel2)), "\n"))) : Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 738], PainelValido(ilig.Painel1)), "\n"))));
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 308], ilig.Usuario), "\n")));
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 309], ilig.Data), "\n")));
														text = text + "Handle: " + ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
													}
												}
												else
												{
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 736], "\n")));
													text = ((Operators.CompareString(ilig.Tag_Cabo, "", TextCompare: true) != 0) ? Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 737], ilig.Tag_Cabo), DeclaracoesGeral.Conf.SeparadorCaboVeia), ilig.NumVeia.ToString()), "\n"))) : Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 737], DeclaracoesGeral.mMensagem[1, 740]), "\n"))));
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 738], PainelValido(ilig.Painel1)), "\n")));
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 739], PainelValido(ilig.Painel2)), "\n")));
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 308], ilig.Usuario), "\n")));
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 309], ilig.Data), "\n")));
													text = text + "Handle: " + ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
												}
											}
											string revisao2 = "";
											int painel3 = 0;
											DeclaracoesInterligacao.caboAranha caboAranha2 = default;
											string tag_cabo2 = "";
											string veia2 = "";
											string handle4 = "";
											Ent = (Entity)(object)pl;
											bool bRebatido2 = false;
											bool bRebatido = XDataDInterlig.LerXDataVeia(ref Ent, ref revisao2, ref painel3, ref tag_cabo2, ref veia2, ref handle4, ref bRebatido2);
											pl = (Polyline)Ent;
											if (!bRebatido)
											{
												Ent = (Entity)(object)pl;
												bRebatido = XDataAranha.LerXDataVeia(ref Ent, ref revisao2, ref painel3, ref tag_cabo2, ref veia2, ref handle4);
												pl = (Polyline)Ent;
												if (!bRebatido)
												{
													DeclaracoesInterligacao.borneAranha bnO = default;
													DeclaracoesInterligacao.borneAranha bnD = default;
													Ent = (Entity)(object)pl;
													bRebatido = XDataAranha.LerXDataJumper(ref Ent, ref revisao2, ref painel3, ref bnO, ref bnD);
													pl = (Polyline)Ent;
													if (!bRebatido)
													{
														Ent = (Entity)(object)pl;
														bRebatido = XDataAranha.LerXDataJumper(ref Ent, ref revisao2, ref painel3, ref bnO, ref bnD);
														pl = (Polyline)Ent;
														if (!bRebatido)
														{
															Relatorios_DistribuicaoPot.StructureBloco Bloco = default;
															Ent = (Entity)(object)pl;
															bRebatido = XDataRelatorio.LerXDataDistPot(ref Ent, ref Bloco);
															pl = (Polyline)Ent;
															if (!bRebatido)
															{
																string rev = "";
																Ent = (Entity)(object)pl;
																painel2 = 0;
																bRebatido = XDataGeral.LeXDataRevisaoAutomatica(ref Ent, ref rev, ref painel2);
																pl = (Polyline)Ent;
																if (bRebatido)
																{
																	text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
																	text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1583], "\n")));
																	text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 62], ": "), rev)));
																}
															}
															else
															{
																text = "";
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1438], "\n")));
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 702], PainelValido(Bloco.iPn)), "\n")));
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 62], ": "), Bloco.sRevisao), "\n")));
															}
														}
														else
														{
															text = "";
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1464], "\n")));
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 702], PainelValido(painel3)), "\n")));
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 62], ": "), revisao2), "\n")));
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 549], "\n")));
														}
													}
													else
													{
														text = "";
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1464], "\n")));
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 702], PainelValido(painel3)), "\n")));
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 62], ": "), revisao2), "\n")));
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 549], "\n")));
													}
												}
												else
												{
													text = "";
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1464], "\n")));
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 702], PainelValido(painel3)), "\n")));
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 62], ": "), revisao2), "\n")));
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1288], ": "), tag_cabo2), "\n")));
													if (Operators.CompareString(veia2, "", TextCompare: true) != 0)
													{
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1569], ": "), veia2), "\n")));
													}
												}
											}
											else
											{
												text = "";
												text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
												text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1464], "\n")));
												text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 702], PainelValido(painel3)), "\n")));
												text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 62], ": "), revisao2), "\n")));
												text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1288], ": "), tag_cabo2), "\n")));
												if (Operators.CompareString(veia2, "", TextCompare: true) != 0)
												{
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1569], ": "), veia2), "\n")));
												}
											}
										}
									}
									else
									{
										Ent = (Entity)(object)val6;
										tag = "";
										text5 = XDataDispositivo.verificaTipoDispositivo(ref Ent, ref tag);
										BlockReference blockRef;
										if (Operators.CompareString(text5, "", TextCompare: true) != 0)
										{
											list.Add(((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString());
											string left2 = text5;
											if (Operators.CompareString(left2, "A", TextCompare: true) != 0)
											{
												if (Operators.CompareString(left2, "B", TextCompare: true) != 0)
												{
													if (Operators.CompareString(left2, "E", TextCompare: true) != 0)
													{
														if (Operators.CompareString(left2, "M", TextCompare: true) != 0)
														{
															if (Operators.CompareString(left2, "P", TextCompare: true) != 0)
															{
																if (Operators.CompareString(left2, "I", TextCompare: true) == 0)
																{
																	DeclaracoesEntidades.StructureExportar exp = default;
																	Ent = (Entity)(object)val6;
																	if (XDataExpImp.LerXDataImportado(ref Ent, ref exp))
																	{
																		text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
																		text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1340], "\n")));
																		text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 109], ": "), exp.Caderno), "\n")));
																		text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 626], ": "), Dicionario.BuscaNomeDoPainel(exp.Painel)), "\n")));
																		text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 772], ": "), exp.Pagina), "\n")));
																		text = text + "Handle: " + ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
																	}
																}
															}
															else
															{
																DeclaracoesEntidades.StructureDispositivo structureDispositivo = default;
																blockRef = val6;
																object obj3 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
																structureDispositivo = ((obj3 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj3));
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 934], "\n")));
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 702], PainelValido(structureDispositivo.Painel)), "\n")));
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 935], structureDispositivo.Nome1), "\n")));
																if (Operators.CompareString(structureDispositivo.Nome2, "", TextCompare: true) != 0)
																{
																	text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 936], structureDispositivo.Nome2), "\n")));
																}
																if (Operators.CompareString(structureDispositivo.Alternativo, "", TextCompare: true) != 0)
																{
																	text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 937], structureDispositivo.Alternativo), "\n")));
																}
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 940], structureDispositivo.indexModelo.ToString()), "\n")));
																if (structureDispositivo.Complementar)
																{
																	text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 938], "\n")));
																}
																if (!structureDispositivo.Complementar)
																{
																	text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 939], "\n")));
																}
																if (Operators.CompareString(structureDispositivo.Topografico.Trim(), "", TextCompare: true) != 0)
																{
																	text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 941], structureDispositivo.Topografico), "\n")));
																}
																if (Operators.CompareString(structureDispositivo.Layout.Trim(), "", TextCompare: true) != 0)
																{
																	text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 942], structureDispositivo.Layout), "\n")));
																}
																string text6 = "";
																if (structureDispositivo.iLM1 != 0)
																{
																	text6 = Conversions.ToString(structureDispositivo.iLM1);
																}
																if (structureDispositivo.iLM2 != 0 && Operators.CompareString(text6, "", TextCompare: true) != 0)
																{
																	text6 = text6 + "; " + Conversions.ToString(structureDispositivo.iLM2);
																}
																if (Operators.CompareString(text6, "", TextCompare: true) != 0)
																{
																	text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 943], text6), "\n")));
																}
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 308], structureDispositivo.Usuario), "\n")));
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 309], structureDispositivo.Data), "\n")));
																text = text + "Handle: " + ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
															}
														}
														else
														{
															DeclaracoesEntidades.StructureMascara structureMascara2 = default;
															blockRef = val6;
															object obj4 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
															structureMascara2 = ((obj4 == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj4));
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 944], "\n")));
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 702], PainelValido(structureMascara2.Painel)), "\n")));
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 935], structureMascara2.Nome1), "\n")));
															if (Operators.CompareString(structureMascara2.Nome2, "", TextCompare: true) != 0)
															{
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 936], structureMascara2.Nome2), "\n")));
															}
															if (Operators.CompareString(structureMascara2.Alternativo, "", TextCompare: true) != 0)
															{
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 937], structureMascara2.Alternativo), "\n")));
															}
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 940], structureMascara2.indexModelo.ToString()), "\n")));
															if (structureMascara2.Complementar)
															{
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 938], "\n")));
															}
															if (!structureMascara2.Complementar)
															{
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 939], "\n")));
															}
															if (Operators.CompareString(structureMascara2.Topografico.Trim(), "", TextCompare: true) != 0)
															{
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 941], structureMascara2.Topografico), "\n")));
															}
															if (Operators.CompareString(structureMascara2.Layout.Trim(), "", TextCompare: true) != 0)
															{
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 942], structureMascara2.Layout), "\n")));
															}
															string text7 = "";
															if (structureMascara2.iLM1 != 0)
															{
																text7 = Conversions.ToString(structureMascara2.iLM1);
															}
															if (structureMascara2.iLM2 != 0 && Operators.CompareString(text7, "", TextCompare: true) != 0)
															{
																text7 = text7 + "; " + Conversions.ToString(structureMascara2.iLM2);
															}
															if (Operators.CompareString(text7, "", TextCompare: true) != 0)
															{
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 943], text7), "\n")));
															}
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 308], structureMascara2.Usuario), "\n")));
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 309], structureMascara2.Data), "\n")));
															text = text + "Handle: " + ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
														}
													}
													else
													{
														DeclaracoesEntidades.StructurePortas structurePortas = default;
														blockRef = val6;
														object obj5 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
														structurePortas = ((obj5 == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj5));
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 945], "\n")));
														Entity val11 = (Entity)Geral.HandleToObject(structurePortas.HandleDaMascara);
														try
														{
															if (val11 == null)
															{
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1875], "\n")));
															}
															else
															{
																DeclaracoesEntidades.StructureMascara structureMascara3 = default;
																if (val11 != null)
																{
																	blockRef = (BlockReference)val11;
																	object obj6 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
																	structureMascara3 = ((obj6 == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj6));
																}
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 702], PainelValido(structureMascara3.Painel)), "\n")));
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 935], structurePortas.Nome1), "\n")));
																if (Operators.CompareString(structurePortas.Nome2, "", TextCompare: true) != 0)
																{
																	text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 936], structurePortas.Nome2), "\n")));
																}
																if (Operators.CompareString(structurePortas.Alternativo, "", TextCompare: true) != 0)
																{
																	text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 937], structurePortas.Alternativo), "\n")));
																}
																string nome = structurePortas.Nome1;
																if (Operators.CompareString(structurePortas.Nome2, "", TextCompare: true) != 0)
																{
																	nome = nome + "/" + structurePortas.Nome2;
																}
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 946], structurePortas.indiceDoModelo.ToString()), "\n")));
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1206], structurePortas.indiceDaPorta.ToString()), "\n")));
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 948], structurePortas.chavePrimaria), "\n")));
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 308], structurePortas.Usuario), "\n")));
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 309], structurePortas.Data), "\n")));
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 949], structurePortas.HandleDaMascara), "\n")));
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 950], structurePortas.handleDaDefinicao), "\n")));
																text = text + "Handle: " + ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
															}
														}
														finally
														{
															((IDisposable)val11)?.Dispose();
														}
													}
												}
												else
												{
													DeclaracoesEntidades.StructureBorne structureBorne = default;
													blockRef = val6;
													object obj7 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
													structureBorne = ((obj7 == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj7));
													short num2 = 0;
													num2 = checked((short)DicionarioBorne.BuscaPainelDoBorneNoDicionario(ref structureBorne.IndiceRegua, ref structureBorne.NomeRegua, ref structureBorne.Alternativo));
													structureBorne.NomePainel = PainelValido(num2);
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
													text = text + DeclaracoesGeral.mMensagem[1, 1091].ToString().ToUpper() + "\n";
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1081], ": "), structureBorne.NomePainel), "\n")));
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1043], ": "), structureBorne.NomeRegua), "\n")));
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1036], ": "), structureBorne.Numero), "\n")));
													if (Operators.CompareString(structureBorne.Alternativo, "", TextCompare: true) != 0)
													{
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1037], ": "), structureBorne.Alternativo), "\n")));
													}
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1082], ": "), Conversions.ToString(structureBorne.Ordem)), "\n")));
													string right = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1078]);
													if (structureBorne.tipo == 1)
													{
														right = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1079]);
													}
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 995], ": "), right), "\n")));
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 308], structureBorne.user), "\n")));
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 309], structureBorne.data), "\n")));
													text = text + "Handle: " + ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString() + "\n";
												}
											}
											else
											{
												DeclaracoesEntidades.StructureAuxiliar structureAuxiliar = default;
												blockRef = val6;
												object obj8 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
												structureAuxiliar = ((obj8 == null) ? default(DeclaracoesEntidades.StructureAuxiliar) : ((DeclaracoesEntidades.StructureAuxiliar)obj8));
												text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
												text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 951], "\n")));
												Entity val12 = (Entity)Geral.HandleToObject(structureAuxiliar.HandleBob);
												try
												{
													if (val12 == null)
													{
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1875], "\n")));
													}
													else
													{
														DeclaracoesEntidades.StructureDispositivo structureDispositivo2 = default;
														if (val12 != null)
														{
															blockRef = (BlockReference)val12;
															object obj9 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
															structureDispositivo2 = ((obj9 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj9));
														}
														if (structureDispositivo2.Painel != 0)
														{
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 702], PainelValido(structureDispositivo2.Painel)), "\n")));
														}
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 935], structureAuxiliar.Nome1), "\n")));
														if (Operators.CompareString(structureAuxiliar.Nome2, "", TextCompare: true) != 0)
														{
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 936], structureAuxiliar.Nome2), "\n")));
														}
														if (Operators.CompareString(structureAuxiliar.Alternativo, "", TextCompare: true) != 0)
														{
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 937], structureAuxiliar.Alternativo), "\n")));
														}
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 946], structureAuxiliar.IndexModelo.ToString()), "\n")));
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 308], structureAuxiliar.Usuario), "\n")));
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 309], structureAuxiliar.Data), "\n")));
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 953], structureAuxiliar.HandleBob), "\n")));
													}
												}
												finally
												{
													((IDisposable)val12)?.Dispose();
												}
											}
											Ent = (Entity)(object)val6;
											if (XDataExpImp.PossuiXDataExportado(ref Ent))
											{
												DeclaracoesEntidades.StructureExportar exp2 = default;
												Ent = (Entity)(object)val6;
												if (XDataExpImp.LerXDataExportado(ref Ent, ref exp2))
												{
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject("\n", DeclaracoesGeral.mMensagem[1, 301]), "\n")));
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1341], "\n")));
													text = text + "Ind. BD: " + exp2.indice + "\n";
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1245], ": "), exp2.Codigo.ToString()), "\n")));
													text = text + "DWG Orig.: " + exp2.DWG + "\n";
													text = text + "Handle Orig.: " + exp2.Handle;
												}
											}
											goto IL_135e;
										}
										list.Add(((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString());
										string text8 = "";
										int num3 = 0;
										Ent = (Entity)(object)val6;
										object oValor = text8;
										object obj = 0;
										bool flag = XDataLeitura.lexDataDaEntity2(ref Ent, "MODELO", 1, 2, ref oValor, ref obj);
										num3 = Conversions.ToInteger(obj);
										text8 = Conversions.ToString(oValor);
										if (flag)
										{
											text = "";
											text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
											text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 954], "\n")));
											Entity val13 = (Entity)Geral.HandleToObject(text8);
											try
											{
												if (val13 != null)
												{
													DeclaracoesEntidades.StructureDispositivo structureDispositivo3 = default;
													blockRef = (BlockReference)val13;
													object obj10 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
													structureDispositivo3 = ((obj10 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj10));
													if (structureDispositivo3.Painel != 0)
													{
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 702], PainelValido(structureDispositivo3.Painel)), "\n")));
													}
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 935], structureDispositivo3.Nome1), "\n")));
													if (Operators.CompareString(structureDispositivo3.Nome2, "", TextCompare: true) != 0)
													{
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 936], structureDispositivo3.Nome2), "\n")));
													}
													if (Operators.CompareString(structureDispositivo3.Alternativo, "", TextCompare: true) != 0)
													{
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 937], structureDispositivo3.Alternativo), "\n")));
													}
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 946], num3.ToString()), "\n")));
												}
											}
											finally
											{
												((IDisposable)val13)?.Dispose();
											}
										}
										DeclaracoesTopografico.structureDispTopografico dTpg = default;
										blockRef = val6;
										if (!XDataTopografico.lerXDataDispTopografico(ref blockRef, ref dTpg))
										{
											DeclaracoesTopografico.structureBorneTopografico bTpg = default;
											blockRef = val6;
											if (!XDataTopografico.lerXDataBorneTopografico(ref blockRef, ref bTpg))
											{
												string tag2 = "";
												string alternativo = "";
												string Handle = "";
												blockRef = val6;
												int painel4 = default;
												if (!XDataLayout.lerXDataDispLayout(ref blockRef, ref painel4, ref tag2, ref alternativo, ref Handle))
												{
													string regua = "";
													string borne = "";
													int tipoBorne = 0;
													Ent = (Entity)(object)val6;
													if (!XDataLayout.lerXDataBorneLayout(ref Ent, ref painel4, ref regua, ref borne, ref tipoBorne))
													{
														DeclaracoesInterligacao.borneAranha bn2 = default;
														blockRef = val6;
														if (!XDataAranha.LerXDataBorne(ref blockRef, ref bn2))
														{
															string revisao3 = "";
															int painel5 = 0;
															DeclaracoesInterligacao.caboAranha cabo = default;
															Ent = (Entity)(object)val6;
															if (!XDataAranha.LerXDataCabo(ref Ent, ref revisao3, ref painel5, ref cabo))
															{
																blockRef = val6;
																if (!XDataDInterlig.LerXDataNomeRegua(ref blockRef, ref bn2))
																{
																	blockRef = val6;
																	if (!XDataDInterlig.LerXDataBorne(ref blockRef, ref bn2))
																	{
																		Ent = (Entity)(object)val6;
																		if (!XDataDInterlig.LerXDataCabo(ref Ent, ref revisao3, ref painel5, ref cabo))
																		{
																			DeclaracoesInterligacao.borneAranha bnO2 = default;
																			DeclaracoesInterligacao.borneAranha bnD2 = default;
																			Ent = (Entity)(object)val6;
																			if (!XDataAranha.LerXDataJumper(ref Ent, ref revisao3, ref painel5, ref bnO2, ref bnD2))
																			{
																				Ent = (Entity)(object)val6;
																				if (!XDataDInterlig.LerXDataJumper(ref Ent, ref revisao3, ref painel5, ref bnO2, ref bnD2))
																				{
																					string tag_cabo3 = "";
																					string veia3 = "";
																					Ent = (Entity)(object)val6;
																					tag = "";
																					bool bRebatido2 = false;
																					if (!XDataDInterlig.LerXDataVeia(ref Ent, ref revisao3, ref painel5, ref tag_cabo3, ref veia3, ref tag, ref bRebatido2))
																					{
																						Relatorios_DistribuicaoPot.StructureBloco Bloco2 = default;
																						Ent = (Entity)(object)val6;
																						if (!XDataRelatorio.LerXDataDistPot(ref Ent, ref Bloco2))
																						{
																							goto IL_135e;
																						}
																						text = "";
																						text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
																						text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1438], "\n")));
																						text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 702], PainelValido(Bloco2.iPn)), "\n")));
																						text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 62], ": "), Bloco2.sRevisao), "\n")));
																					}
																					else
																					{
																						text = "";
																						text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
																						text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1464], "\n")));
																						text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 702], PainelValido(painel5)), "\n")));
																						text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 62], ": "), revisao3), "\n")));
																						text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1288], ": "), tag_cabo3), "\n")));
																					}
																				}
																				else
																				{
																					text = "";
																					text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
																					text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1464], "\n")));
																					text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 702], PainelValido(painel5)), "\n")));
																					text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 62], ": "), revisao3), "\n")));
																					text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 549], "\n")));
																				}
																			}
																			else
																			{
																				text = "";
																				text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
																				text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1464], "\n")));
																				text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 702], PainelValido(painel5)), "\n")));
																				text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 62], ": "), revisao3), "\n")));
																				text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 549], "\n")));
																			}
																		}
																		else
																		{
																			text = "";
																			text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
																			text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1464], "\n")));
																			text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 702], PainelValido(painel5)), "\n")));
																			text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 62], ": "), revisao3), "\n")));
																			text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1288], ": "), cabo.Tag_Cabo), "\n")));
																		}
																	}
																	else
																	{
																		text = "";
																		text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
																		text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1464], "\n")));
																		text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 702], PainelValido(bn2.Painel)), "\n")));
																		text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 62], ": "), bn2.Revisao), "\n")));
																		text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 788], ": "), bn2.Tag), "\n")));
																		text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1429], ": "), bn2.Borne), "\n")));
																	}
																}
																else
																{
																	text = "";
																	text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
																	text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1464], "\n")));
																	text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 702], PainelValido(bn2.Painel)), "\n")));
																	text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 62], ": "), bn2.Revisao), "\n")));
																	text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 788], ": "), bn2.Tag), "\n")));
																}
															}
															else
															{
																text = "";
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1464], "\n")));
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 702], PainelValido(painel5)), "\n")));
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 62], ": "), revisao3), "\n")));
																text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1288], ": "), cabo.Tag_Cabo), "\n")));
															}
														}
														else
														{
															text = "";
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1464], "\n")));
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 702], PainelValido(bn2.Painel)), "\n")));
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 62], ": "), bn2.Revisao), "\n")));
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 788], ": "), bn2.Tag), "\n")));
															text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1429], ": "), bn2.Borne), "\n")));
														}
													}
													else
													{
														text = "";
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 583], "\n")));
														text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 702], PainelValido(painel4)), "\n")));
														text = Conversions.ToString(Operators.AddObject(text, Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 984], ": "), regua + "\n")));
														text = Conversions.ToString(Operators.AddObject(text, Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1429], ": "), borne + "\n")));
														text = ((tipoBorne == 0) ? Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1074], "\n"))) : Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1075], "\n"))));
													}
												}
												else
												{
													text = "";
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 583], "\n")));
													text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 702], PainelValido(painel4)), "\n")));
													text = Conversions.ToString(Operators.AddObject(text, Operators.ConcatenateObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 702], ": "), tag2 + "\n")));
													text = text + "Handle Disp Principal: " + Handle + "\n";
												}
											}
											else
											{
												text = "";
												text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
												text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 552], "\n")));
												text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 702], PainelValido(bTpg.painel)), "\n")));
												text = Conversions.ToString(Operators.AddObject(text, Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 788], ": "), bTpg.regua + "\n")));
												text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1429], ": "), bTpg.borne), "\n")));
											}
										}
										else
										{
											text = "";
											text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
											text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 552], "\n")));
											text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 702], PainelValido(dTpg.painel)), "\n")));
											text = text + "Equipamento: " + dTpg.tag + "\n";
											if (Operators.CompareString(dTpg.alternativo, "", TextCompare: true) != 0)
											{
												text = text + "Alternativo: " + dTpg.alternativo + "\n";
											}
										}
									}
									goto end_IL_00e0;
									IL_135e:
									string rev2 = "";
									Ent = (Entity)(object)val6;
									if (!XDataGeral.leXDataCopiaSemFuncaoEletrica(ref Ent, ref rev2))
									{
										goto IL_1377;
									}
									list.Add(((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString());
									if (Operators.CompareString(rev2, "", TextCompare: true) == 0)
									{
										goto IL_1377;
									}
									Entity ent = (Entity)Geral.HandleToObject(rev2);
									if (ent == null)
									{
										goto IL_1377;
									}
									DeclaracoesGeral.Reguas RH = default;
									bool flag2 = false;
									flag2 = XDataGeral.LeXDataReguaH(ref RH);
									DeclaracoesGeral.Reguas RH2 = default;
									bool flag3 = false;
									flag3 = XDataGeral.LeXDataReguaV(ref RH2);
									string pagina = ((Entity)val6).Layer.ToString();
									Ent = (Entity)(object)val6;
									string right2 = Pagina.montaCruzamentoPagina(pagina, Pagina.calculaLinhaColuna(ref Ent, ref RH, ref RH2, flag2, flag3));
									tag = "";
									text5 = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tag);
									if (Operators.CompareString(text5, "", TextCompare: true) == 0)
									{
										goto IL_1377;
									}
									string left3 = text5;
									if (Operators.CompareString(left3, "A", TextCompare: true) != 0)
									{
										if (Operators.CompareString(left3, "B", TextCompare: true) != 0)
										{
											if (Operators.CompareString(left3, "E", TextCompare: true) != 0)
											{
												if (Operators.CompareString(left3, "P", TextCompare: true) != 0)
												{
													goto IL_1377;
												}
												text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
												text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1726], "\n")));
												text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 934], "\n")));
												text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1727], right2)));
											}
											else
											{
												text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
												text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1726], "\n")));
												text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 945], "\n")));
												text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1727], right2)));
											}
										}
										else
										{
											text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
											text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1726], "\n")));
											text = text + DeclaracoesGeral.mMensagem[1, 1091].ToString().ToUpper() + "\n";
											text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1727], right2)));
										}
									}
									else
									{
										text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
										text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1726], "\n")));
										text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 951], "\n")));
										text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1727], right2)));
									}
									goto end_IL_00e0;
									IL_1377:
									string rev3 = "";
									Ent = (Entity)(object)val6;
									painel2 = 0;
									if (XDataGeral.LeXDataRevisaoAutomatica(ref Ent, ref rev3, ref painel2))
									{
										text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 301], "\n")));
										text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1583], "\n")));
										text = Conversions.ToString(Operators.AddObject(text, Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 62], ": "), rev3)));
									}
									end_IL_00e0:;
								}
								finally
								{
									((IDisposable)val6)?.Dispose();
								}
							}
						}
						finally
						{
							((IDisposable)val5)?.Dispose();
						}
					}
					if (text.Length > 0)
					{
						P_1.AppendToolTipText(text);
					}
				}
				val2.Commit();
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public static string PainelValido(int indexPainel)
	{
		string result = "?";
		try
		{
			if (!Information.IsNothing(DeclaracoesGeral.dicPainel))
			{
				if (DeclaracoesGeral.dicPainel.Count == 0)
				{
					cDadosAccess.carregaPainelDicionario();
				}
			}
			else
			{
				cDadosAccess.carregaPainelDicionario();
			}
			result = (DeclaracoesGeral.dicPainel.ContainsKey(indexPainel) ? DeclaracoesGeral.dicPainel[indexPainel] : Conversions.ToString(Operators.ConcatenateObject(Conversions.ToString(indexPainel) + " - ", DeclaracoesGeral.mMensagem[1, 1170])));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		return result;
	}
}

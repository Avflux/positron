using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;

namespace Eletron4;

public class UserDataEL
{
	public static void UserData(string sUser, string sdata, bool bUser, bool bData, bool bBanco)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected Obj, but got Unknown
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Expected Obj, but got Unknown
		//IL_038b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0392: Expected Obj, but got Unknown
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Expected Obj, but got Unknown
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Expected Obj, but got Unknown
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Expected Obj, but got Unknown
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Expected Obj, but got Unknown
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected Obj, but got Unknown
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
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					for (enumerator = val4.GetEnumerator(); enumerator.MoveNext(); DeclaracoesGeral._uscPagina.pbPasso())
					{
						ObjectId current = enumerator.Current;
						Entity Ent = (Entity)val2.GetObject(current, (OpenMode)0);
						BlockReference val5 = (BlockReference)(object)((Ent is BlockReference) ? Ent : null);
						Entity Ent2;
						if (val5 == null)
						{
							DBText val6 = (DBText)(object)((Ent is DBText) ? Ent : null);
							if (val6 == null)
							{
								Polyline pl = (Polyline)(object)((Ent is Polyline) ? Ent : null);
								if (pl != null)
								{
									DeclaracoesEntidades.StructureInterligacao ilig = default;
									if (XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig))
									{
										short tipo = ilig.Tipo;
										if ((uint)(tipo - 1) <= 2u)
										{
											if (bUser)
											{
												int iIndice = 14;
												AtualizaValorDoXData("INTERLIGACAO", ref Ent, ref iIndice, sUser);
											}
											if (bData)
											{
												int iIndice = 15;
												AtualizaValorDoXData("INTERLIGACAO", ref Ent, ref iIndice, sdata);
											}
											continue;
										}
									}
									DeclaracoesEntidades.StructureConexao conex = default;
									if (XDataConexao.lerXDataConexao(ref pl, ref conex))
									{
										if (bUser)
										{
											int iIndice = 20;
											AtualizaValorDoXData("CONEXAO", ref Ent, ref iIndice, sUser);
										}
										if (bData)
										{
											int iIndice = 21;
											AtualizaValorDoXData("CONEXAO", ref Ent, ref iIndice, sdata);
										}
										continue;
									}
								}
								if (Operators.CompareString(XDataGeral.verificaXDataColunas(Ent), "0", TextCompare: true) == 0)
								{
									if (XDataRelatorio.TemOxDataNoRelatorio(ref Ent, "INDICE"))
									{
										if (bUser)
										{
											string snomeXData = "DiagLog".ToUpper();
											int iIndice = 3;
											AtualizaValorDoXData(snomeXData, ref Ent, ref iIndice, sUser);
										}
										if (bData)
										{
											string snomeXData2 = "DiagLog".ToUpper();
											int iIndice = 4;
											AtualizaValorDoXData(snomeXData2, ref Ent, ref iIndice, sdata);
										}
									}
								}
								else
								{
									if (bUser)
									{
										int iIndice = 3;
										AtualizaValorDoXData("DiagLog", ref Ent, ref iIndice, sUser);
									}
									if (bData)
									{
										int iIndice = 4;
										AtualizaValorDoXData("DiagLog", ref Ent, ref iIndice, sdata);
									}
								}
								continue;
							}
							object oValor = "";
							if (!XDataLeitura.lexDataDaEntity1(ref Ent, "AUXINTERLIG", 0, ref oValor))
							{
								oValor = "";
								if (!XDataLeitura.lexDataDaEntity1(ref Ent, "AUXCONEXAO", 0, ref oValor))
								{
									Ent2 = (Entity)(object)val6;
									int iIndice = 0;
									bool flag = clsEditaTitulosTextos.LeXDataTitulo(ref Ent2, ref iIndice);
									val6 = (DBText)Ent2;
									if (flag)
									{
										if (bUser)
										{
											iIndice = 5;
											AtualizaValorDoXData("DiagLog", ref Ent, ref iIndice, sUser);
										}
										if (bData)
										{
											iIndice = 6;
											AtualizaValorDoXData("DiagLog", ref Ent, ref iIndice, sdata);
										}
									}
								}
								else
								{
									if (bUser)
									{
										int iIndice = 7;
										AtualizaValorDoXData("AUXCONEXAO", ref Ent, ref iIndice, sUser);
									}
									if (bData)
									{
										int iIndice = 8;
										AtualizaValorDoXData("AUXCONEXAO", ref Ent, ref iIndice, sdata);
									}
								}
							}
							else
							{
								if (bUser)
								{
									int iIndice = 5;
									AtualizaValorDoXData("AUXINTERLIG", ref Ent, ref iIndice, sUser);
								}
								if (bData)
								{
									int iIndice = 6;
									AtualizaValorDoXData("AUXINTERLIG", ref Ent, ref iIndice, sdata);
								}
							}
							continue;
						}
						Ent2 = (Entity)(object)val5;
						string tipoImportado = "";
						string text = XDataDispositivo.verificaTipoDispositivo(ref Ent2, ref tipoImportado);
						val5 = (BlockReference)Ent2;
						string text2 = text;
						string left = text2;
						if (Operators.CompareString(left, "A", TextCompare: true) != 0 && Operators.CompareString(left, "B", TextCompare: true) != 0 && Operators.CompareString(left, "E", TextCompare: true) != 0)
						{
							if (Operators.CompareString(left, "P", TextCompare: true) != 0 && Operators.CompareString(left, "M", TextCompare: true) != 0)
							{
								DeclaracoesGeral.Revisoes revC = default;
								if (!XDataGeral.LeXDataRevisao(ref val5, ref revC))
								{
									text = "";
									int iIndice = 1;
									if (!XDataGeral.LeXDataRevisaoAutomatica(ref Ent, ref text, ref iIndice))
									{
										Ent2 = (Entity)(object)val5;
										object oValor = "";
										bool flag = XDataLeitura.lexDataDaEntity1(ref Ent2, "IMPORTADO", 0, ref oValor);
										val5 = (BlockReference)Ent2;
										if (flag)
										{
											if (bUser)
											{
												iIndice = 14;
												AtualizaValorDoXData("IMPORTADO", ref Ent, ref iIndice, sUser);
											}
											if (bData)
											{
												iIndice = 15;
												AtualizaValorDoXData("IMPORTADO", ref Ent, ref iIndice, sdata);
											}
										}
									}
									else
									{
										if (bUser)
										{
											iIndice = 10;
											AtualizaValorDoXData("DiagLog", ref Ent, ref iIndice, sUser);
										}
										if (bData)
										{
											iIndice = 11;
											AtualizaValorDoXData("DiagLog", ref Ent, ref iIndice, sdata);
										}
									}
								}
								else
								{
									if (bUser)
									{
										int iIndice = 10;
										AtualizaValorDoXData("DiagLog", ref Ent, ref iIndice, sUser);
									}
									if (bData)
									{
										int iIndice = 11;
										AtualizaValorDoXData("DiagLog", ref Ent, ref iIndice, sdata);
									}
								}
							}
							else
							{
								if (bUser)
								{
									Ent2 = (Entity)(object)val5;
									int iIndice = 24;
									AtualizaValorDoXData("DISPOSITIVO", ref Ent2, ref iIndice, sUser);
									val5 = (BlockReference)Ent2;
								}
								if (bData)
								{
									Ent2 = (Entity)(object)val5;
									int iIndice = 25;
									AtualizaValorDoXData("DISPOSITIVO", ref Ent2, ref iIndice, sdata);
									val5 = (BlockReference)Ent2;
								}
							}
						}
						else
						{
							if (bUser)
							{
								Ent2 = (Entity)(object)val5;
								int iIndice = 16;
								AtualizaValorDoXData("DISPOSITIVO", ref Ent2, ref iIndice, sUser);
								val5 = (BlockReference)Ent2;
							}
							if (bData)
							{
								Ent2 = (Entity)(object)val5;
								int iIndice = 17;
								AtualizaValorDoXData("DISPOSITIVO", ref Ent2, ref iIndice, sdata);
								val5 = (BlockReference)Ent2;
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
				DeclaracoesGeral._uscPagina.pbFim();
				if (!bBanco)
				{
					return;
				}
				cDadosAccessComum cDadosAccessComum2 = new cDadosAccessComum();
				try
				{
					DeclaracoesGeral._uscPagina.Quantidade = 20;
					DeclaracoesGeral._uscPagina.pbIniciar();
					if (bUser)
					{
						DeclaracoesGeral._uscPagina.pbPasso();
						cDadosAccessComum2.AtualizaUserData("DWG", "Criador", sUser);
						DeclaracoesGeral._uscPagina.pbPasso();
						cDadosAccessComum2.AtualizaUserData("DWG", "Editor", sUser);
						DeclaracoesGeral._uscPagina.pbPasso();
						cDadosAccessComum2.AtualizaUserData("DWGH", "Criador", sUser);
						DeclaracoesGeral._uscPagina.pbPasso();
						cDadosAccessComum2.AtualizaUserData("DWGH", "Editor", sUser);
						DeclaracoesGeral._uscPagina.pbPasso();
						cDadosAccessComum2.AtualizaUserData("Fiacao", "Criador", sUser);
						DeclaracoesGeral._uscPagina.pbPasso();
						cDadosAccessComum2.AtualizaUserData("Interligacao4", "Criador", sUser);
						DeclaracoesGeral._uscPagina.pbPasso();
						cDadosAccessComum2.AtualizaUserData("Jumper4", "Criador", sUser);
						DeclaracoesGeral._uscPagina.pbPasso();
						cDadosAccessComum2.AtualizaUserData("Paineis", "Criador", sUser);
						DeclaracoesGeral._uscPagina.pbPasso();
						cDadosAccessComum2.AtualizaUserData("Paineis", "Editor", sUser);
						DeclaracoesGeral._uscPagina.pbPasso();
						cDadosAccessComum2.AtualizaUserData("PaineisH", "Criador", sUser);
						DeclaracoesGeral._uscPagina.pbPasso();
						cDadosAccessComum2.AtualizaUserData("PaineisH", "Editor", sUser);
						DeclaracoesGeral._uscPagina.pbPasso();
					}
					if (bData)
					{
						DateTime sValor = Conversions.ToDate(sdata);
						cDadosAccessComum2.AtualizaUserDataBD("DWG", "Data", sValor);
						DeclaracoesGeral._uscPagina.pbPasso();
						cDadosAccessComum2.AtualizaUserDataBD("DWGH", "Data", sValor);
						DeclaracoesGeral._uscPagina.pbPasso();
						cDadosAccessComum2.AtualizaUserDataBD("Fiacao", "Data", sValor);
						DeclaracoesGeral._uscPagina.pbPasso();
						cDadosAccessComum2.AtualizaUserDataBD("Interligacao4", "Data", sValor);
						DeclaracoesGeral._uscPagina.pbPasso();
						cDadosAccessComum2.AtualizaUserDataBD("Jumper4", "Data", sValor);
						DeclaracoesGeral._uscPagina.pbPasso();
						cDadosAccessComum2.AtualizaUserDataBD("Paineis", "Data", sValor);
						DeclaracoesGeral._uscPagina.pbPasso();
						cDadosAccessComum2.AtualizaUserDataBD("PaineisH", "Data", sValor);
					}
					DeclaracoesGeral._uscPagina.pbFim();
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
				finally
				{
					cDadosAccessComum2.fechaConexao();
				}
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
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

	public static void AtualizaValorDoXData(string snomeXData, ref Entity Ent, ref int iIndice, string sValor)
	{
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				bool flag = false;
				ResultBuffer val3 = null;
				val3 = ((DBObject)Ent).GetXDataForApplication(snomeXData);
				if (val3 == null)
				{
					val3 = ((DBObject)Ent).GetXDataForApplication(snomeXData.ToUpper());
					if (val3 != null)
					{
						flag = true;
					}
				}
				else
				{
					flag = true;
				}
				if (flag)
				{
					TypedValue[] array = val3.AsArray();
					if (Information.UBound(array) >= iIndice)
					{
						array[iIndice] = new TypedValue(1000, (object)sValor);
						((DBObject)Ent).UpgradeOpen();
						((DBObject)Ent).XData = new ResultBuffer(array);
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
	}
}

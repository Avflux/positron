using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;

namespace Eletron4;

public class clsDispositivoMascaras
{
	public static void PesquisaTodasAsPortasEDefinicoesUsadas(ref Declaracoes2.MModeloDePortas[] mPortasUsadas)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected Obj, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected Obj, but got Unknown
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected Obj, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Expected Obj, but got Unknown
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected Obj, but got Unknown
		//IL_0634: Unknown result type (might be due to invalid IL or missing references)
		//IL_0639: Unknown result type (might be due to invalid IL or missing references)
		//IL_047a: Unknown result type (might be due to invalid IL or missing references)
		//IL_047f: Unknown result type (might be due to invalid IL or missing references)
		//IL_053b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0540: Unknown result type (might be due to invalid IL or missing references)
		//IL_0381: Unknown result type (might be due to invalid IL or missing references)
		//IL_0386: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				DeclaracoesGeral.Reguas RH = default;
				bool flag = false;
				DeclaracoesGeral.Reguas RH2 = default;
				bool flag2 = false;
				flag = XDataGeral.LeXDataReguaH(ref RH);
				flag2 = XDataGeral.LeXDataReguaV(ref RH2);
				BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
				long num = 0L;
				num = clsBlocos.AcadObjectCount();
				mPortasUsadas = (Declaracoes2.MModeloDePortas[])Utils.CopyArray(mPortasUsadas, new Declaracoes2.MModeloDePortas[1]);
				int num2 = 0;
				DeclaracoesGeral._uscPagina.Quantidade = (int)num;
				DeclaracoesGeral._uscPagina.pbIniciar();
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val3.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						num2++;
						if (num2 == 100)
						{
							DeclaracoesGeral._uscPagina.pbPasso(num2);
							num2 = 0;
						}
						Entity ent = (Entity)val.GetObject(current, (OpenMode)0);
						Entity ent2;
						if (ent is BlockReference)
						{
							BlockReference val4 = (BlockReference)(object)((ent is BlockReference) ? ent : null);
							if (val4 != null)
							{
								ent2 = (Entity)(object)val4;
								string tipoImportado = "";
								string text = XDataDispositivo.verificaTipoDispositivo(ref ent2, ref tipoImportado);
								val4 = (BlockReference)ent2;
								string left = text;
								if (Operators.CompareString(left, "E", TextCompare: true) == 0)
								{
									object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val4);
									DeclaracoesEntidades.StructurePortas structurePortas = ((obj == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj));
									string text2 = structurePortas.Nome1;
									if (Operators.CompareString(structurePortas.Nome2, "", TextCompare: true) != 0)
									{
										text2 = structurePortas.Nome1 + "/" + structurePortas.Nome2;
									}
									int num3 = Dicionario.BuscaIndiceDoPainel(clsMascara.BuscaPainel(structurePortas.HandleDaMascara));
									bool flag3 = true;
									int num4 = Information.UBound(mPortasUsadas);
									for (int i = 0; i <= num4; i++)
									{
										if (((mPortasUsadas[i].IndiceModelo == structurePortas.indiceDoModelo) & (mPortasUsadas[i].IndicePN == num3)) && Operators.CompareString(mPortasUsadas[i].NomeModelo, text2, TextCompare: true) == 0 && mPortasUsadas[i].IndiceDaPorta == structurePortas.indiceDaPorta)
										{
											mPortasUsadas[i].Uso = true;
											ref string paginaPorta = ref mPortasUsadas[i].PaginaPorta;
											paginaPorta = paginaPorta + Pagina.montaCruzamentoPagina(ent.Layer.ToString(), Pagina.calculaLinhaColuna(ref ent, ref RH, ref RH2, flag, flag2)) + "|";
											ref string handlePorta = ref mPortasUsadas[i].HandlePorta;
											handlePorta = handlePorta + ((object)((DBObject)val4).Handle/*cast due to constrained. prefix*/).ToString() + "|";
											flag3 = false;
											break;
										}
									}
									if (flag3)
									{
										int num5 = Information.UBound(mPortasUsadas) + 1;
										mPortasUsadas = (Declaracoes2.MModeloDePortas[])Utils.CopyArray(mPortasUsadas, new Declaracoes2.MModeloDePortas[num5 + 1]);
										mPortasUsadas[num5].NomeModelo = text2;
										mPortasUsadas[num5].IndiceModelo = structurePortas.indiceDoModelo;
										mPortasUsadas[num5].IndicePN = num3;
										mPortasUsadas[num5].IndiceDaPorta = structurePortas.indiceDaPorta;
										mPortasUsadas[num5].Uso = true;
										ref string paginaPorta2 = ref mPortasUsadas[num5].PaginaPorta;
										paginaPorta2 = paginaPorta2 + Pagina.montaCruzamentoPagina(ent.Layer.ToString(), Pagina.calculaLinhaColuna(ref ent, ref RH, ref RH2, flag, flag2)) + "|";
										ref string handlePorta2 = ref mPortasUsadas[num5].HandlePorta;
										handlePorta2 = handlePorta2 + ((object)((DBObject)val4).Handle/*cast due to constrained. prefix*/).ToString() + "|";
									}
								}
							}
						}
						if (!(ent is DBText))
						{
							continue;
						}
						DBText val5 = (DBText)(object)((ent is DBText) ? ent : null);
						if (val5 == null)
						{
							continue;
						}
						DeclaracoesEntidades.StructureDefinicaoPortas Def = new DeclaracoesEntidades.StructureDefinicaoPortas
						{
							Nome = ""
						};
						ent2 = (Entity)(object)val5;
						bool flag4 = XDataDispositivosMaster.LerXDataDefinicao(ref ent2, ref Def);
						val5 = (DBText)ent2;
						if (!flag4)
						{
							continue;
						}
						string text3 = clsMascara.BuscaNomeDaMascara(Def.HandleDaMascara);
						bool flag5 = true;
						int num6 = Dicionario.BuscaIndiceDoPainel(clsMascara.BuscaPainel(Def.HandleDaMascara));
						int num7 = Information.UBound(mPortasUsadas);
						for (int j = 0; j <= num7; j++)
						{
							if (((mPortasUsadas[j].IndiceModelo == Def.indiceDoModelo) & (mPortasUsadas[j].IndicePN == num6)) && Operators.CompareString(mPortasUsadas[j].NomeModelo, text3, TextCompare: true) == 0 && mPortasUsadas[j].IndiceDaPorta == Def.indiceDaPorta)
							{
								mPortasUsadas[j].Uso = true;
								ref string paginaDef = ref mPortasUsadas[j].PaginaDef;
								paginaDef = paginaDef + Pagina.montaCruzamentoPagina(ent.Layer.ToString(), Pagina.calculaLinhaColuna(ref ent, ref RH, ref RH2, flag, flag2)) + "|";
								ref string handleDef = ref mPortasUsadas[j].HandleDef;
								handleDef = handleDef + ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString() + "|";
								flag5 = false;
								break;
							}
						}
						if (flag5)
						{
							int num8 = Information.UBound(mPortasUsadas) + 1;
							mPortasUsadas = (Declaracoes2.MModeloDePortas[])Utils.CopyArray(mPortasUsadas, new Declaracoes2.MModeloDePortas[num8 + 1]);
							mPortasUsadas[num8].NomeModelo = text3;
							mPortasUsadas[num8].IndiceModelo = Def.indiceDoModelo;
							mPortasUsadas[num8].IndicePN = num6;
							mPortasUsadas[num8].IndiceDaPorta = Def.indiceDaPorta;
							mPortasUsadas[num8].Uso = true;
							ref string paginaDef2 = ref mPortasUsadas[num8].PaginaDef;
							paginaDef2 = paginaDef2 + Pagina.montaCruzamentoPagina(ent.Layer.ToString(), Pagina.calculaLinhaColuna(ref ent, ref RH, ref RH2, flag, flag2)) + "|";
							ref string handleDef2 = ref mPortasUsadas[num8].HandleDef;
							handleDef2 = handleDef2 + ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString() + "|";
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				DeclaracoesGeral._uscPagina.pbFim();
				DeclaracoesGeral.bAnularEventos = true;
				val.Commit();
				DeclaracoesGeral.bAnularEventos = false;
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
		}
	}

	public static string leUmaPorta(int iModelo, string sNomeModelo, int iPorta)
	{
		string result = "";
		Declaracoes2.MModeloDePortas[] mPortas = null;
		DicionarioMascaras.LeAsPortasDoModeloDoDicionario(ref iModelo, sNomeModelo, ref mPortas);
		int num = Information.UBound(mPortas);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (mPortas[i].IndiceDaPorta == iPorta)
			{
				result = mPortas[i].sEFC;
				break;
			}
		}
		return result;
	}

	public static void EditaMascarasDoModelo(int indiceMascara, ref Declaracoes2.MModeloDeMascara[] mModelo, string iLm1, string iLm2, string sTopografico, string sLayout)
	{
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected Obj, but got Unknown
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected Obj, but got Unknown
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected Obj, but got Unknown
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected Obj, but got Unknown
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		string[] array = new string[1] { "" };
		int num = 0;
		string text = "";
		string text2 = "";
		int num2 = 0;
		int num3 = Information.UBound(mModelo);
		checked
		{
			for (int i = 1; i <= num3; i++)
			{
				if (mModelo[i].iIndiceModelo == indiceMascara)
				{
					num2 = i;
					break;
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
						Entity ent = (Entity)val.GetObject(current, (OpenMode)0);
						string tipoImportado = "";
						string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
						if (Operators.CompareString(left, "M", TextCompare: true) != 0)
						{
							continue;
						}
						BlockReference blockRef = (BlockReference)ent;
						object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
						ent = (Entity)(object)blockRef;
						DeclaracoesEntidades.StructureMascara Masc = ((obj == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj));
						if (indiceMascara == Masc.indexModelo)
						{
							num++;
							array = (string[])Utils.CopyArray(array, new string[num + 1]);
							array[num] = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
							if (Operators.CompareString(text, "", TextCompare: true) == 0)
							{
								text = mModelo[num2].sNomeModelo;
							}
							if (Operators.CompareString(text2, "", TextCompare: true) == 0)
							{
								text2 = mModelo[num2].sFabricante;
							}
							Masc.Fabricante = mModelo[num2].sFabricante;
							Masc.Topografico = mModelo[num2].sBlocoTopografico;
							Masc.Layout = mModelo[num2].sBlocoLayout;
							if (Versioned.IsNumeric(iLm1))
							{
								Masc.iLM1 = Conversions.ToInteger(iLm1);
							}
							if (Versioned.IsNumeric(iLm2))
							{
								Masc.iLM2 = Conversions.ToInteger(iLm2);
							}
							XDataDispositivosMaster.GravarXDataMascara(ref ent, ref Masc);
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				int num4 = Information.UBound(array);
				for (int j = 1; j <= num4; j++)
				{
					string left2 = clsBlocos.LeUmAtributoDeUmBloco(ref array[j], "MODELO");
					if (Operators.CompareString(left2, "", TextCompare: true) == 0)
					{
						clsBlocos.EditaUmAtributoDeUmBloco(ref array[j], "MODELO", "");
					}
					else
					{
						clsBlocos.EditaUmAtributoDeUmBloco(ref array[j], "MODELO", text);
					}
					clsBlocos.EditaUmAtributoDeUmBloco(ref array[j], "FABRICANTE", text2);
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
	}

	public static void carregaMatrizPortas(DataGridView dg, ref Declaracoes2.MModeloDePortas[] mPORTAS)
	{
		mPORTAS = (Declaracoes2.MModeloDePortas[])Utils.CopyArray(mPORTAS, new Declaracoes2.MModeloDePortas[1]);
		int num = 0;
		checked
		{
			int num2 = dg.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				num = Information.UBound(mPORTAS) + 1;
				mPORTAS = (Declaracoes2.MModeloDePortas[])Utils.CopyArray(mPORTAS, new Declaracoes2.MModeloDePortas[num + 1]);
				mPORTAS[num].IndiceDaPorta = Conversions.ToInteger(dg.Rows[i].Cells[0].Value);
				mPORTAS[num].IndiceModelo = Conversions.ToInteger(dg.Rows[i].Cells[1].Value);
				mPORTAS[num].IndicePN = 0;
				mPORTAS[num].sEFC = Conversions.ToString(dg.Rows[i].Cells[2].Value);
				mPORTAS[num].sTerminais = Conversions.ToString(dg.Rows[i].Cells[3].Value);
				mPORTAS[num].sOrientacao = Conversions.ToString(dg.Rows[i].Cells[4].Value);
				mPORTAS[num].sRegua = Conversions.ToString(dg.Rows[i].Cells[5].Value);
				mPORTAS[num].sBornes = Conversions.ToString(dg.Rows[i].Cells[6].Value);
			}
		}
	}

	public static void PesquisaPortasUsadasDosModelos(int indiceMascara, int indicePorta, ref DeclaracoesEntidades.StructurePortas[] mPORTAS)
	{
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
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
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
						if (Operators.CompareString(left, "E", TextCompare: true) == 0)
						{
							BlockReference blockRef = (BlockReference)ent;
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
							ent = (Entity)(object)blockRef;
							DeclaracoesEntidades.StructurePortas structurePortas = ((obj == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj));
							if (indiceMascara == structurePortas.indiceDoModelo && indicePorta == structurePortas.indiceDaPorta)
							{
								int num = Information.UBound(mPORTAS) + 1;
								mPORTAS = (DeclaracoesEntidades.StructurePortas[])Utils.CopyArray(mPORTAS, new DeclaracoesEntidades.StructurePortas[num + 1]);
								mPORTAS[num] = structurePortas;
								mPORTAS[num].HandleBloco = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
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
	}

	public static void carregaPortasUsadasDosModelos(ref DataGridView dg, ref DeclaracoesEntidades.StructurePortas[] mPORTAS)
	{
		checked
		{
			try
			{
				dg.Rows.Clear();
				dg.Columns.Clear();
				if (mPORTAS == null)
				{
					return;
				}
				dg.Columns.Add("Nome1", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 987]));
				dg.Columns.Add("Página", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 772]));
				dg.Columns.Add("Handle", "");
				if (Information.UBound(mPORTAS) <= 0)
				{
					dg.Rows.Clear();
					dg.Columns.Clear();
				}
				else
				{
					int num = Information.UBound(mPORTAS);
					for (int i = 1; i <= num; i++)
					{
						if (Operators.CompareString(mPORTAS[i].Nome2, "", TextCompare: true) != 0)
						{
							mPORTAS[i].Nome1 = mPORTAS[i].Nome1 + "/" + mPORTAS[i].Nome2;
						}
						string text = U9qpZLTe2M(mPORTAS[i].HandleBloco);
						dg.Rows.Add(mPORTAS[i].Nome1, text, mPORTAS[i].HandleBloco);
					}
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
					while (num3 <= 2);
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

	private static string U9qpZLTe2M(string P_0)
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected Obj, but got Unknown
		string result = "";
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			_ = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				ObjectId val3 = Geral.HandleToID(P_0);
				if (val3.IsValid)
				{
					Entity ent = (Entity)val2.GetObject(val3, (OpenMode)0);
					DeclaracoesGeral.Reguas RH = default;
					bool flag = false;
					DeclaracoesGeral.Reguas RH2 = default;
					bool flag2 = false;
					flag = XDataGeral.LeXDataReguaH(ref RH);
					flag2 = XDataGeral.LeXDataReguaV(ref RH2);
					result = Pagina.montaCruzamentoPagina(ent.Layer.ToString(), Pagina.calculaLinhaColuna(ref ent, ref RH, ref RH2, flag, flag2));
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
		return result;
	}

	public static void carregaContatosNoDGMascara(ref DataGridView dg, ref Declaracoes2.MModeloDePortas[] mPORTAS, bool bPintaDG)
	{
		checked
		{
			try
			{
				dg.Rows.Clear();
				dg.Columns.Clear();
				if (mPORTAS == null)
				{
					return;
				}
				if (Information.UBound(mPORTAS) > 0)
				{
					dg.Columns.Add("IndicePorta", "#");
					dg.Columns.Add("indexModelo", "indexModelo");
					dg.Columns.Add("EFC", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 922]));
					dg.Columns.Add("Terminais", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 983]));
					dg.Columns.Add("Orientação", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1846]));
					dg.Columns.Add("Regua", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 984]));
					dg.Columns.Add("Bornes", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 985]));
					int num = Information.UBound(mPORTAS);
					for (int i = 1; i <= num; i++)
					{
						dg.Rows.Add(mPORTAS[i].IndiceDaPorta, mPORTAS[i].IndiceModelo, mPORTAS[i].sEFC, mPORTAS[i].sTerminais, mPORTAS[i].sOrientacao, mPORTAS[i].sRegua, mPORTAS[i].sBornes);
					}
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
					while (num3 <= 6);
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

	public static void carregaContatosNoDGDefinicao(ref DataGridView dg, ref Declaracoes2.MModeloDePortas[] mPORTAS, bool bPintaDG, int indicePainelSel)
	{
		checked
		{
			try
			{
				dg.Rows.Clear();
				dg.Columns.Clear();
				if (mPORTAS == null)
				{
					return;
				}
				dg.Columns.Add("IndicePorta", "#");
				dg.Columns.Add("indexModelo", "indexModelo");
				dg.Columns.Add("EFC", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 922]));
				dg.Columns.Add("Terminais", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 983]));
				dg.Columns.Add("Regua", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 984]));
				dg.Columns.Add("Bornes", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 985]));
				dg.Columns.Add("Reserva1", "Reserva");
				dg.Columns.Add("Reserva2", "Reserva");
				dg.Columns.Add("PagPorta", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 520]));
				dg.Columns.Add("PagDef", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 521]));
				dg.Columns.Add("HandlePorta", "HandlePorta");
				dg.Columns.Add("HandleDef", "HandleDef");
				if (Information.UBound(mPORTAS) > 0)
				{
					int num = Information.UBound(mPORTAS);
					for (int i = 1; i <= num; i++)
					{
						dg.Rows.Add(mPORTAS[i].IndiceDaPorta, mPORTAS[i].IndiceModelo, mPORTAS[i].sEFC, mPORTAS[i].sTerminais, mPORTAS[i].sRegua, mPORTAS[i].sBornes, "", "", TiraCaracterDoTexto(ref mPORTAS[i].PaginaPorta, "|"), TiraCaracterDoTexto(ref mPORTAS[i].PaginaDef, "|"), mPORTAS[i].HandlePorta, mPORTAS[i].HandleDef);
					}
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
					while (num3 <= 11);
				}
				if (!bPintaDG)
				{
					return;
				}
				int num4 = dg.Rows.Count - 1;
				for (int k = 0; k <= num4; k++)
				{
					int num5 = Information.UBound(mPORTAS);
					for (int l = 0; l <= num5; l++)
					{
						if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.CompareObjectEqual(dg.Rows[k].Cells[0].Value, mPORTAS[l].IndiceDaPorta, TextCompare: true), Operators.CompareObjectEqual(dg.Rows[k].Cells[1].Value, mPORTAS[l].IndiceModelo, TextCompare: true)), mPORTAS[l].IndicePN == indicePainelSel)))
						{
							switch (clsPortas.ContaContatos(mPORTAS[l].PaginaPorta))
							{
							case 0:
								dg.Rows[k].Cells[8].Style.BackColor = Color.LightGreen;
								dg.Rows[k].Cells[8].Style.ForeColor = Color.Black;
								break;
							case 1:
								dg.Rows[k].Cells[8].Style.BackColor = Color.LightCoral;
								dg.Rows[k].Cells[8].Style.ForeColor = Color.Black;
								break;
							default:
								dg.Rows[k].Cells[8].Style.BackColor = Color.Red;
								dg.Rows[k].Cells[8].Style.ForeColor = Color.White;
								break;
							}
							break;
						}
					}
					dg.Rows[k].Selected = false;
				}
				int num6 = dg.Rows.Count - 1;
				for (int m = 0; m <= num6; m++)
				{
					int num7 = Information.UBound(mPORTAS);
					for (int n = 0; n <= num7; n++)
					{
						if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.CompareObjectEqual(dg.Rows[m].Cells[0].Value, mPORTAS[n].IndiceDaPorta, TextCompare: true), Operators.CompareObjectEqual(dg.Rows[m].Cells[1].Value, mPORTAS[n].IndiceModelo, TextCompare: true)), mPORTAS[n].IndicePN == indicePainelSel)))
						{
							switch (clsPortas.ContaContatos(mPORTAS[n].PaginaDef))
							{
							case 0:
								dg.Rows[m].Cells[9].Style.BackColor = Color.LightGreen;
								dg.Rows[m].Cells[9].Style.ForeColor = Color.Black;
								break;
							case 1:
								dg.Rows[m].Cells[9].Style.BackColor = Color.LightCoral;
								dg.Rows[m].Cells[9].Style.ForeColor = Color.Black;
								break;
							default:
								dg.Rows[m].Cells[9].Style.BackColor = Color.Red;
								dg.Rows[m].Cells[9].Style.ForeColor = Color.White;
								break;
							}
							break;
						}
					}
					dg.Rows[m].Selected = false;
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

	public static string TiraCaracterDoTexto(ref string sTexto, string sCaracter)
	{
		string text = "";
		string text2 = "";
		int num = Strings.Len(sTexto);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			text = Strings.Mid(sTexto, i, 1);
			if (Operators.CompareString(text, sCaracter, TextCompare: true) != 0)
			{
				text2 += text;
			}
		}
		return text2;
	}

	public static void PesquisaTodasPortas(ref DeclaracoesFiacao.structurePortasTAF[] mPortas)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected Obj, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected Obj, but got Unknown
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
				mPortas = (DeclaracoesFiacao.structurePortasTAF[])Utils.CopyArray(mPortas, new DeclaracoesFiacao.structurePortasTAF[1]);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val3.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val4 = (Entity)val.GetObject(current, (OpenMode)0);
						if (!(val4 is BlockReference))
						{
							continue;
						}
						BlockReference val5 = (BlockReference)(object)((val4 is BlockReference) ? val4 : null);
						if (val5 == null)
						{
							continue;
						}
						Entity ent = (Entity)(object)val5;
						string tipoImportado = "";
						string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
						val5 = (BlockReference)ent;
						string left = text;
						if (Operators.CompareString(left, "E", TextCompare: true) == 0)
						{
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val5);
							DeclaracoesEntidades.StructurePortas structurePortas = ((obj == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj));
							if (Operators.CompareString(structurePortas.Nome2, "", TextCompare: true) != 0)
							{
								_ = structurePortas.Nome1 + "/" + structurePortas.Nome2;
							}
							int num = Information.UBound(mPortas) + 1;
							mPortas = (DeclaracoesFiacao.structurePortasTAF[])Utils.CopyArray(mPortas, new DeclaracoesFiacao.structurePortasTAF[num + 1]);
							mPortas[num].Handle = ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString();
							mPortas[num].ChavePrimaria = structurePortas.chavePrimaria;
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
		}
	}
}

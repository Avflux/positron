using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using idK5By1ORRRAapLJQ3M;

namespace Eletron4;

public class ClsFuncoesDispositivo
{
	public struct StructureFuncaoDisp
	{
		public int iPN;

		public string sPN;

		public int indexModelo;

		public string Nome1;

		public string Nome2;

		public string Alternativo;

		public string Handle;

		public int itemModelo;

		public string Funcao;
	}

	public struct ModeloFuncao
	{
		public string sDisp;

		public string sHandleBob;

		public string sFuncao;
	}

	public static void CarregaOsPaineisEmUsoPelosContatosFuncaoDG(ref DataGridView dg)
	{
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected Obj, but got Unknown
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected Obj, but got Unknown
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected Obj, but got Unknown
		List<int> list = new List<int>();
		DeclaracoesGeral.bAnularEventos = true;
		dg.Rows.Clear();
		dg.Columns.Clear();
		dg.Columns.Add("Indice", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 999]));
		dg.Columns.Add("Dispositivo", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 626]));
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
							BlockReference blockRef = (BlockReference)(object)((ent is BlockReference) ? ent : null);
							if (blockRef == null)
							{
								continue;
							}
							string tipoImportado = "";
							string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
							if (Operators.CompareString(left, "P", TextCompare: true) == 0)
							{
								object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
								DeclaracoesEntidades.StructureDispositivo structureDispositivo = ((obj == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj));
								if (structureDispositivo.indexModelo > 0 && !list.Contains(structureDispositivo.Painel))
								{
									list.Add(structureDispositivo.Painel);
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
			foreach (int item in list)
			{
				if (DeclaracoesGeral.dicPainel.ContainsKey(item))
				{
					dg.Rows.Add(item, DeclaracoesGeral.dicPainel[item]);
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
			DeclaracoesGeral.bAnularEventos = false;
		}
	}

	public static void CarregaContatosAuxiliaresInseridosFuncaoPaineis(ref DataGridView dg, ref StructureFuncaoDisp[] mFuncaoDisp, List<int> lPainel)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected Obj, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected Obj, but got Unknown
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected Obj, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		mFuncaoDisp = new StructureFuncaoDisp[1];
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
								Entity Ent = (Entity)val2.GetObject(current, (OpenMode)0);
								Declaracoes2.StructureModelo Modelo = default;
								if (!XDataDispositivosMaster.LerXDataModelo(ref Ent, ref Modelo))
								{
									continue;
								}
								Entity val5 = (Entity)Geral.HandleToObject(Modelo.HandleBob);
								if (val5 == null)
								{
									continue;
								}
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
								if (Operators.CompareString(left, "P", TextCompare: true) != 0)
								{
									continue;
								}
								object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val6);
								DeclaracoesEntidades.StructureDispositivo structureDispositivo = ((obj == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj));
								if (lPainel.Contains(structureDispositivo.Painel))
								{
									int num = Information.UBound(mFuncaoDisp) + 1;
									mFuncaoDisp = (StructureFuncaoDisp[])Utils.CopyArray(mFuncaoDisp, new StructureFuncaoDisp[num + 1]);
									mFuncaoDisp[num].iPN = structureDispositivo.Painel;
									mFuncaoDisp[num].sPN = Dicionario.BuscaNomeDoPainel(structureDispositivo.Painel);
									mFuncaoDisp[num].Handle = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
									mFuncaoDisp[num].Nome1 = structureDispositivo.Nome1;
									mFuncaoDisp[num].Nome2 = structureDispositivo.Nome2;
									mFuncaoDisp[num].Alternativo = structureDispositivo.Alternativo;
									mFuncaoDisp[num].indexModelo = Modelo.indexModelo;
									mFuncaoDisp[num].itemModelo = Modelo.indexContato;
									mFuncaoDisp[num].Funcao = "";
									string[] mFuncao = null;
									xDataFuncao.lerXDataFuncao(ref val6, ref mFuncao);
									if (!Information.IsNothing(mFuncao) && Information.UBound(mFuncao) >= Modelo.indexContato + 1)
									{
										mFuncaoDisp[num].Funcao = mFuncao[Modelo.indexContato + 1];
									}
								}
							}
						}
						finally
						{
							((IDisposable)enumerator)?.Dispose();
						}
						if (Information.UBound(mFuncaoDisp) >= 2)
						{
							int num2 = Information.UBound(mFuncaoDisp) - 1;
							for (int i = num2; i >= 1; i += -1)
							{
								int num3 = i;
								for (int j = 1; j <= num3; j++)
								{
									if (mFuncaoDisp[j].iPN > mFuncaoDisp[j + 1].iPN)
									{
										StructureFuncaoDisp structureFuncaoDisp = default;
										structureFuncaoDisp = mFuncaoDisp[j + 1];
										mFuncaoDisp[j + 1] = mFuncaoDisp[j];
										mFuncaoDisp[j] = structureFuncaoDisp;
									}
									if (mFuncaoDisp[j].iPN == mFuncaoDisp[j + 1].iPN && Operators.CompareString(mFuncaoDisp[j].Nome1, mFuncaoDisp[j + 1].Nome1, TextCompare: true) > 0)
									{
										StructureFuncaoDisp structureFuncaoDisp2 = default;
										structureFuncaoDisp2 = mFuncaoDisp[j + 1];
										mFuncaoDisp[j + 1] = mFuncaoDisp[j];
										mFuncaoDisp[j] = structureFuncaoDisp2;
									}
									if (mFuncaoDisp[j].iPN == mFuncaoDisp[j + 1].iPN && Operators.CompareString(mFuncaoDisp[j].Nome1, mFuncaoDisp[j + 1].Nome1, TextCompare: true) == 0 && Operators.CompareString(mFuncaoDisp[j].Nome2, mFuncaoDisp[j + 1].Nome2, TextCompare: true) > 0)
									{
										StructureFuncaoDisp structureFuncaoDisp3 = default;
										structureFuncaoDisp3 = mFuncaoDisp[j + 1];
										mFuncaoDisp[j + 1] = mFuncaoDisp[j];
										mFuncaoDisp[j] = structureFuncaoDisp3;
									}
									if (mFuncaoDisp[j].iPN == mFuncaoDisp[j + 1].iPN && Operators.CompareString(mFuncaoDisp[j].Nome1, mFuncaoDisp[j + 1].Nome1, TextCompare: true) == 0 && Operators.CompareString(mFuncaoDisp[j].Nome2, mFuncaoDisp[j + 1].Nome2, TextCompare: true) == 0 && Operators.CompareString(mFuncaoDisp[j].Alternativo, mFuncaoDisp[j + 1].Alternativo, TextCompare: true) > 0)
									{
										StructureFuncaoDisp structureFuncaoDisp4 = default;
										structureFuncaoDisp4 = mFuncaoDisp[j + 1];
										mFuncaoDisp[j + 1] = mFuncaoDisp[j];
										mFuncaoDisp[j] = structureFuncaoDisp4;
									}
									if (Operators.CompareString(mFuncaoDisp[j].Nome1, mFuncaoDisp[j + 1].Nome1, TextCompare: true) == 0 && Operators.CompareString(mFuncaoDisp[j].Nome2, mFuncaoDisp[j + 1].Nome2, TextCompare: true) == 0 && Operators.CompareString(mFuncaoDisp[j].Alternativo, mFuncaoDisp[j + 1].Alternativo, TextCompare: true) == 0 && mFuncaoDisp[j].indexModelo > mFuncaoDisp[j + 1].indexModelo)
									{
										StructureFuncaoDisp structureFuncaoDisp5 = default;
										structureFuncaoDisp5 = mFuncaoDisp[j + 1];
										mFuncaoDisp[j + 1] = mFuncaoDisp[j];
										mFuncaoDisp[j] = structureFuncaoDisp5;
									}
									if (mFuncaoDisp[j].iPN == mFuncaoDisp[j + 1].iPN && Operators.CompareString(mFuncaoDisp[j].Nome1, mFuncaoDisp[j + 1].Nome1, TextCompare: true) == 0 && Operators.CompareString(mFuncaoDisp[j].Nome2, mFuncaoDisp[j + 1].Nome2, TextCompare: true) == 0 && Operators.CompareString(mFuncaoDisp[j].Alternativo, mFuncaoDisp[j + 1].Alternativo, TextCompare: true) == 0 && mFuncaoDisp[j].indexModelo == mFuncaoDisp[j + 1].indexModelo && mFuncaoDisp[j].itemModelo > mFuncaoDisp[j + 1].itemModelo)
									{
										StructureFuncaoDisp structureFuncaoDisp6 = default;
										structureFuncaoDisp6 = mFuncaoDisp[j + 1];
										mFuncaoDisp[j + 1] = mFuncaoDisp[j];
										mFuncaoDisp[j] = structureFuncaoDisp6;
									}
								}
							}
						}
						int num4 = Information.UBound(mFuncaoDisp);
						for (int k = 1; k <= num4; k++)
						{
							if (mFuncaoDisp[k].itemModelo == 0)
							{
								string text2 = mFuncaoDisp[k].Nome1;
								if (Operators.CompareString(mFuncaoDisp[k].Nome2, "", TextCompare: true) != 0)
								{
									text2 = text2 + "/ " + mFuncaoDisp[k].Nome2;
								}
								dg.Rows.Add(mFuncaoDisp[k].sPN, mFuncaoDisp[k].indexModelo, text2, mFuncaoDisp[k].Nome1, mFuncaoDisp[k].Nome2, mFuncaoDisp[k].Alternativo, mFuncaoDisp[k].Handle);
							}
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
				throw;
			}
			finally
			{
			}
		}
	}

	public static void AtualizaFuncaoDisp(ref StructureFuncaoDisp[] mFuncaoDisp)
	{
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected Obj, but got Unknown
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Expected Obj, but got Unknown
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Expected Obj, but got Unknown
		List<string> list = new List<string>();
		string text = "";
		int num = Information.UBound(mFuncaoDisp);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				text = mFuncaoDisp[i].Nome1;
				if (Operators.CompareString(mFuncaoDisp[i].Nome2, "", TextCompare: true) != 0)
				{
					text = text + "/" + mFuncaoDisp[i].Nome2;
				}
				if (!list.Contains(text))
				{
					list.Add(text);
				}
			}
			DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					foreach (string item in list)
					{
						string text2 = "";
						string text3 = "";
						int num2 = Information.UBound(mFuncaoDisp);
						for (int j = 1; j <= num2; j++)
						{
							text = mFuncaoDisp[j].Nome1;
							if (Operators.CompareString(mFuncaoDisp[j].Nome2, "", TextCompare: true) != 0)
							{
								text = text + "/" + mFuncaoDisp[j].Nome2;
							}
							if (Operators.CompareString(text, item, TextCompare: true) == 0)
							{
								if (Operators.CompareString(text3, "", TextCompare: true) == 0)
								{
									text3 = mFuncaoDisp[j].Handle;
								}
								text2 = text2 + clsTextos.TiraNothing(mFuncaoDisp[j].Funcao) + ";";
								if (j < Information.UBound(mFuncaoDisp) && Operators.CompareString(text3, mFuncaoDisp[j + 1].Handle, TextCompare: true) != 0)
								{
									break;
								}
							}
						}
						Entity val4 = (Entity)Geral.HandleToObject(text3);
						if (val4 != null)
						{
							string[] mFuncao = text2.Split(';');
							BlockReference bl = (BlockReference)val4;
							xDataFuncao.GravarXDataFuncao(ref bl, ref mFuncao);
							val4 = (Entity)(object)bl;
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

	public static void BuscaFuncoesDeContatos(ref Declaracoes2.StructureContatosAuxiliares[] mCONTATOS, string sPainel, int iIndiceModelo, string shandle)
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected Obj, but got Unknown
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected Obj, but got Unknown
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected Obj, but got Unknown
		Dicionario.BuscaIndiceDoPainel(sPainel);
		int num = Information.UBound(mCONTATOS);
		checked
		{
			for (int i = 0; i <= num; i++)
			{
				mCONTATOS[i].sUso = "";
				mCONTATOS[i].sPagina = "";
			}
			DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					string[] mFuncao = null;
					Entity val4 = (Entity)Geral.HandleToObject(shandle);
					if (val4 != null)
					{
						BlockReference Bl = (BlockReference)val4;
						xDataFuncao.lerXDataFuncao(ref Bl, ref mFuncao);
						val4 = (Entity)(object)Bl;
						int num2 = Information.UBound(mCONTATOS);
						for (int j = 1; j <= num2; j++)
						{
							mCONTATOS[j].sUso = "";
							if (!Information.IsNothing(mFuncao))
							{
								mCONTATOS[j].sUso = mFuncao[j];
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
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}

	public static void CarregaOsFuncaoContatosAuxiliares(DataGridView DGDisp, ref DataGridView dgContatos, string sPainel)
	{
		Declaracoes2.StructureContatosAuxiliares[] mCONTATOS = null;
		if (DGDisp.SelectedRows.Count > 0)
		{
			int iIndiceSelecionado = Conversions.ToInteger(DGDisp.SelectedRows[0].Cells[1].Value);
			string sDisp = Conversions.ToString(DGDisp.SelectedRows[0].Cells[3].Value);
			string shandle = Conversions.ToString(DGDisp.SelectedRows[0].Cells[6].Value);
			LeOsContatosAuxiliarDoModeloDoDicionario(ref iIndiceSelecionado, ref mCONTATOS, sDisp);
			BuscaFuncoesDeContatos(ref mCONTATOS, sPainel, iIndiceSelecionado, shandle);
			carregaContatosNoDG(ref dgContatos, mCONTATOS);
		}
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		dataGridViewCellStyle.BackColor = Color.LightGreen;
		AtualizaColunasDGContatosAuxiliaresMODELO(ref dgContatos);
	}

	public static void CarregaOsFuncaoContatosAuxiliaresPaineis(DataGridView DGDisp, ref DataGridView dgContatos, List<int> iPainel)
	{
		Declaracoes2.StructureContatosAuxiliares[] mCONTATOS = null;
		if (DGDisp.SelectedRows.Count > 0)
		{
			int iIndiceSelecionado = Conversions.ToInteger(DGDisp.SelectedRows[0].Cells[1].Value);
			string sDisp = Conversions.ToString(DGDisp.SelectedRows[0].Cells[3].Value);
			string shandle = Conversions.ToString(DGDisp.SelectedRows[0].Cells[6].Value);
			LeOsContatosAuxiliarDoModeloDoDicionario(ref iIndiceSelecionado, ref mCONTATOS, sDisp);
			BuscaFuncoesDeContatos(ref mCONTATOS, "", iIndiceSelecionado, shandle);
			carregaContatosNoDG(ref dgContatos, mCONTATOS);
		}
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		dataGridViewCellStyle.BackColor = Color.LightGreen;
		AtualizaColunasDGContatosAuxiliaresMODELO(ref dgContatos);
	}

	public static bool LeOsContatosAuxiliarDoModeloDoDicionario(ref int iIndiceSelecionado, ref Declaracoes2.StructureContatosAuxiliares[] mCONTATOS, string sDisp)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected Obj, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected Obj, but got Unknown
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected Obj, but got Unknown
		bool result = false;
		DBDictionary val = null;
		long num = 0L;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val2 = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				DBDictionary val3 = (DBDictionary)val2.GetObject(database.NamedObjectsDictionaryId, (OpenMode)0, false);
				if (val3.Contains("CONTATOS"))
				{
					val = (DBDictionary)val2.GetObject(val3.GetAt("CONTATOS"), (OpenMode)0);
					mCONTATOS = new Declaracoes2.StructureContatosAuxiliares[1];
					num = Information.UBound(mCONTATOS) + 1;
					mCONTATOS = (Declaracoes2.StructureContatosAuxiliares[])Utils.CopyArray(mCONTATOS, new Declaracoes2.StructureContatosAuxiliares[(int)num + 1]);
					mCONTATOS[(int)num].iIndice = 0;
					mCONTATOS[(int)num].sT1 = sDisp;
					mCONTATOS[(int)num].sT2 = "";
					mCONTATOS[(int)num].sT3 = "";
					mCONTATOS[(int)num].sOrientacao = "";
					mCONTATOS[(int)num].iT = 0;
					mCONTATOS[(int)num].sTipo = "";
					mCONTATOS[(int)num].iComportamento = 0;
					mCONTATOS[(int)num].sComportamento = "";
					mCONTATOS[(int)num].sUso = "";
					if (val.Contains(Conversions.ToString(iIndiceSelecionado)))
					{
						ObjectId at = val.GetAt(Conversions.ToString(iIndiceSelecionado));
						Xrecord val4 = (Xrecord)val2.GetObject(at, (OpenMode)0);
						ResultBuffer data = val4.Data;
						TypedValue[] array = data.AsArray();
						int num2 = Information.UBound(array);
						for (int i = 1; i <= num2; i += 8)
						{
							num = Information.UBound(mCONTATOS) + 1;
							mCONTATOS = (Declaracoes2.StructureContatosAuxiliares[])Utils.CopyArray(mCONTATOS, new Declaracoes2.StructureContatosAuxiliares[(int)num + 1]);
							mCONTATOS[(int)num].iIndice = Conversions.ToInteger(array[i + 0].Value);
							mCONTATOS[(int)num].sT1 = Conversions.ToString(Conversions.ToInteger(array[i + 0].Value));
							mCONTATOS[(int)num].sT2 = "";
							mCONTATOS[(int)num].sT3 = "";
							mCONTATOS[(int)num].sOrientacao = "";
							mCONTATOS[(int)num].iT = 0;
							mCONTATOS[(int)num].sTipo = "";
							mCONTATOS[(int)num].iComportamento = 0;
							mCONTATOS[(int)num].sComportamento = "";
							mCONTATOS[(int)num].sUso = "";
						}
						result = true;
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				OrdenaOsModelosDeDeDicionarioContatosAuxiliates(ref mCONTATOS);
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
			return result;
		}
	}

	public static void OrdenaOsModelosDeDeDicionarioContatosAuxiliates(ref Declaracoes2.StructureContatosAuxiliares[] mContatos)
	{
		if (Information.UBound(mContatos) < 2)
		{
			return;
		}
		checked
		{
			int num = Information.UBound(mContatos) - 1;
			for (int i = num; i >= 1; i += -1)
			{
				int num2 = i;
				for (int j = 1; j <= num2; j++)
				{
					if (mContatos[j].iIndice > mContatos[j + 1].iIndice)
					{
						Declaracoes2.StructureContatosAuxiliares structureContatosAuxiliares = default;
						structureContatosAuxiliares = mContatos[j + 1];
						mContatos[j + 1] = mContatos[j];
						mContatos[j] = structureContatosAuxiliares;
					}
				}
			}
		}
	}

	public static void carregaContatosNoDG(ref DataGridView dg, Declaracoes2.StructureContatosAuxiliares[] mContatos)
	{
		checked
		{
			try
			{
				dg.Rows.Clear();
				dg.Columns.Clear();
				if (Information.UBound(mContatos) > 0)
				{
					dg.Columns.Add("IndiceModelo", "#");
					dg.Columns.Add("Disp", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 804]));
					dg.Columns.Add("Função", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1244]));
					int num = Information.UBound(mContatos);
					for (int i = 1; i <= num; i++)
					{
						dg.Rows.Add(mContatos[i].iIndice, mContatos[i].sT1, mContatos[i].sUso);
						dg.Rows[dg.Rows.Count - 1].Selected = false;
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
				AtualizaColunasDGContatosAuxiliaresMODELO(ref dg);
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

	public static void AtualizaColunasDGContatosAuxiliaresMODELO(ref DataGridView dg)
	{
		if (dg.RowCount == 0)
		{
			return;
		}
		checked
		{
			double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg)) ? ((double)(dg.Width - 5)) : ((double)(dg.Width - 21)));
			dg.Columns[0].Width = 0;
			dg.Columns[1].Width = (int)Math.Round(num * 0.25);
			dg.Columns[2].Width = (int)Math.Round(num * 0.75);
			dg.Columns[0].Visible = false;
			dg.Columns[1].Visible = true;
			dg.Columns[2].Visible = true;
			dg.Columns[0].ReadOnly = false;
			dg.Columns[1].ReadOnly = false;
			dg.Columns[2].ReadOnly = false;
			dg.MultiSelect = false;
			int num2 = dg.Columns.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				dg.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
			}
			foreach (DataGridViewRow item in (IEnumerable)dg.Rows)
			{
				dg.Rows[item.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			}
		}
	}

	public static void ImportaPN(ref StructureFuncaoDisp[] mFuncaoDisp)
	{
		Microsoft.Office.Interop.Excel.Application oExcelNew = null;
		Workbook oBook = null;
		Worksheet oSheet = null;
		ExcFuncoesExcel.VerificaExcelAtivo(ref oExcelNew, ref oBook, ref oSheet);
		ExcFuncoesExcel.DesativaCalculoExcel(ref oExcelNew);
		if (Operators.CompareString(DeclaracoesGeral.companyHardlock.ToUpper(), "CADGRAPH", TextCompare: true) == 0)
		{
			ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
		}
		excContatos.ImportaFuncoesContatos(ref oSheet, mFuncaoDisp);
		ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
	}

	public static void AtualizaValoresDosModelos(int iPn)
	{
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
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected Obj, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected Obj, but got Unknown
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected Obj, but got Unknown
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Expected Obj, but got Unknown
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		new List<string>();
		DateTime.Now.ToString();
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
							BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
							if (val6 == null)
							{
								continue;
							}
							string text = "";
							int num2 = 0;
							Entity ent = (Entity)(object)val6;
							object oValor = text;
							object oValor2 = 0;
							object oValor3 = 0;
							bool flag = XDataLeitura.lexDataDaEntity3(ref ent, "MODELO", 1, 2, 3, ref oValor, ref oValor2, ref oValor3);
							num2 = Conversions.ToInteger(oValor3);
							Conversions.ToInteger(oValor2);
							text = Conversions.ToString(oValor);
							val6 = (BlockReference)ent;
							if (!flag)
							{
								continue;
							}
							Entity ent2 = (Entity)Geral.HandleToObject(text);
							if (ent2 == null)
							{
								continue;
							}
							string tipoImportado = "";
							string left = XDataDispositivo.verificaTipoDispositivo(ref ent2, ref tipoImportado);
							if (Operators.CompareString(left, "P", TextCompare: true) != 0)
							{
								continue;
							}
							BlockReference blockRef = (BlockReference)ent2;
							oValor3 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
							ent2 = (Entity)(object)blockRef;
							object obj = oValor3;
							if (((obj == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj)).Painel != iPn)
							{
								continue;
							}
							string[] mFuncao = null;
							blockRef = (BlockReference)ent2;
							xDataFuncao.lerXDataFuncao(ref blockRef, ref mFuncao);
							ent2 = (Entity)(object)blockRef;
							if (!Information.IsNothing(mFuncao))
							{
								if (num2 != 0)
								{
									num++;
									tipoImportado = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
									clsBlocos.AtualizaValorDeUmAtributo(ref tipoImportado, "FUNCAO", mFuncao[num2 + 1]);
								}
								else
								{
									num++;
									tipoImportado = ((object)((DBObject)ent2).Handle/*cast due to constrained. prefix*/).ToString();
									clsBlocos.AtualizaValorDeUmAtributo(ref tipoImportado, "FUNCAO", mFuncao[num2 + 1]);
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
					Interaction.MsgBox(num);
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

	public static void verificaDispositivos()
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected Obj, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected Obj, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected Obj, but got Unknown
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected Obj, but got Unknown
		bool flag = true;
		DeclaracoesGeral.bAnularEventos = true;
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
							BlockReference blockRef = (BlockReference)(object)((ent is BlockReference) ? ent : null);
							if (blockRef == null)
							{
								continue;
							}
							string tipoImportado = "";
							string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
							if (Operators.CompareString(left, "P", TextCompare: true) == 0)
							{
								object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
								if (obj == null)
								{
									_ = default(DeclaracoesEntidades.StructureDispositivo);
								}
								else
									_ = (DeclaracoesEntidades.StructureDispositivo)obj;
								string[] mFuncao = null;
								BlockReference Bl = (BlockReference)ent;
								bool flag2 = xDataFuncao.lerXDataFuncao(ref Bl, ref mFuncao);
								ent = (Entity)(object)Bl;
								if (flag2)
								{
									flag = false;
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
		if (flag)
		{
			CorrigeFuncaoDoModelo();
		}
	}

	public static void CorrigeFuncaoDoModelo()
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected Obj, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected Obj, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected Obj, but got Unknown
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected Obj, but got Unknown
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected Obj, but got Unknown
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected Obj, but got Unknown
		//IL_033c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0347: Unknown result type (might be due to invalid IL or missing references)
		//IL_034e: Expected Obj, but got Unknown
		//IL_03d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d9: Expected Obj, but got Unknown
		//IL_03e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0383: Unknown result type (might be due to invalid IL or missing references)
		//IL_0388: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		//IL_041d: Expected Obj, but got Unknown
		//IL_0439: Unknown result type (might be due to invalid IL or missing references)
		//IL_0440: Expected Obj, but got Unknown
		//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_046b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0470: Unknown result type (might be due to invalid IL or missing references)
		//IL_0480: Unknown result type (might be due to invalid IL or missing references)
		//IL_0485: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04af: Expected Obj, but got Unknown
		int num = 0;
		ModeloFuncao[] array = new ModeloFuncao[1];
		List<string> list = new List<string>();
		string text = DateTime.Now.ToString();
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
							BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
							if (val6 == null)
							{
								continue;
							}
							string text2 = "";
							int num2 = 0;
							Entity ent = (Entity)(object)val6;
							object oValor = text2;
							object oValor2 = 0;
							object oValor3 = 0;
							bool flag = XDataLeitura.lexDataDaEntity3(ref ent, "MODELO", 1, 2, 3, ref oValor, ref oValor2, ref oValor3);
							num2 = Conversions.ToInteger(oValor3);
							Conversions.ToInteger(oValor2);
							text2 = Conversions.ToString(oValor);
							val6 = (BlockReference)ent;
							if (!flag)
							{
								continue;
							}
							Entity val7 = (Entity)Geral.HandleToObject(text2);
							if (val7 == null || num2 == 0)
							{
								continue;
							}
							DeclaracoesEntidades.StructureDispositivo structureDispositivo = default;
							BlockReference blockRef = (BlockReference)val7;
							oValor3 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
							val7 = (Entity)(object)blockRef;
							object obj = oValor3;
							structureDispositivo = ((obj == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj));
							string text3 = Conversions.ToString(unchecked((int)structureDispositivo.Painel)) + "-" + structureDispositivo.Nome1 + structureDispositivo.Nome2 + structureDispositivo.Alternativo;
							if (list.Contains(text3))
							{
								int num3 = Information.UBound(array);
								for (int i = 1; i <= num3; i++)
								{
									if (Operators.CompareString(array[i].sDisp, text3, TextCompare: true) == 0)
									{
										ref string sFuncao = ref array[num].sFuncao;
										string obj2 = sFuncao;
										string sHandle = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
										sFuncao = obj2 + clsBlocos.LeUmAtributoDeUmBloco(ref sHandle, "FUNCAO") + ";";
										break;
									}
								}
							}
							else
							{
								num++;
								array = (ModeloFuncao[])Utils.CopyArray(array, new ModeloFuncao[num + 1]);
								array[num].sDisp = text3;
								array[num].sHandleBob = text2;
								ref ModeloFuncao reference = ref array[num];
								string sHandle = ((object)((DBObject)val7).Handle/*cast due to constrained. prefix*/).ToString();
								string text4 = clsBlocos.LeUmAtributoDeUmBloco(ref sHandle, "FUNCAO");
								sHandle = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
								reference.sFuncao = text4 + ";" + clsBlocos.LeUmAtributoDeUmBloco(ref sHandle, "FUNCAO") + ";";
								list.Add(text3);
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
						string[] array2 = array[j].sFuncao.Split(';');
						RegAppTable val8 = (RegAppTable)val2.GetObject(database.RegAppTableId, (OpenMode)1);
						if (!((SymbolTable)val8).Has("DISP_FUNCAO"))
						{
							RegAppTableRecord val9 = new RegAppTableRecord();
							((SymbolTableRecord)val9).Name = "DISP_FUNCAO";
							((SymbolTable)val8).Add((SymbolTableRecord)(object)val9);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)val9, true);
						}
						int num5 = Information.UBound(array2) + 2;
						TypedValue[] array3 = new TypedValue[num5 + 1];
						array3[0] = new TypedValue(1001, (object)"DISP_FUNCAO");
						int num6 = 0;
						string[] array4 = array2;
						foreach (string text5 in array4)
						{
							num6++;
							array3[num6] = new TypedValue(1000, (object)text5.Trim());
						}
						Entity val10 = (Entity)Geral.HandleToObject(array[j].sHandleBob);
						if (val10 != null)
						{
							DeclaracoesEntidades.StructureDispositivo structureDispositivo2 = default;
							BlockReference blockRef = (BlockReference)val10;
							object oValor3 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
							val10 = (Entity)(object)blockRef;
							object obj3 = oValor3;
							structureDispositivo2 = ((obj3 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj3));
							array3[num5 - 1] = new TypedValue(1000, (object)structureDispositivo2.Usuario);
							array3[num5] = new TypedValue(1000, (object)text);
							BlockReference val11 = (BlockReference)(object)((val10 is BlockReference) ? val10 : null);
							if (val11 != null)
							{
								((DBObject)val11).UpgradeOpen();
								((DBObject)val11).XData = new ResultBuffer(array3);
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
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}

	public static void AtualizaFuncaoDosModelos()
	{
		DeclaracoesGeral._uscPagina.Quantidade = DeclaracoesGeral.dicPainel.Count;
		DeclaracoesGeral._uscPagina.pbIniciar();
		int num = 0;
		foreach (KeyValuePair<int, string> item in DeclaracoesGeral.dicPainel)
		{
			AtualizaValoresDosModelos(item.Key);
			num = checked(num + 1);
			if (num == 10)
			{
				DeclaracoesGeral._uscPagina.pbPasso(num);
				num = 0;
			}
		}
		DeclaracoesGeral._uscPagina.pbFim();
	}
}

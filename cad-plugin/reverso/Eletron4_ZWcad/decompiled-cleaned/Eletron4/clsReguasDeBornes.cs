using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using idK5By1ORRRAapLJQ3M;

namespace Eletron4;

public class clsReguasDeBornes
{
	public struct PnUso
	{
		public int index;

		public string spainel;

		public int uso;
	}

	public static void calculaSelecionado(ref DataGridView dg, ref frmEstatisticaDeBornes.mQuantBornes mQuantBornes)
	{
		mQuantBornes.qBorneUS = 0;
		mQuantBornes.qBorneRS = 0;
		mQuantBornes.qBorneTS = 0;
		mQuantBornes.qBorneUD = 0;
		mQuantBornes.qBorneRD = 0;
		mQuantBornes.qBorneTD = 0;
		mQuantBornes.qBorneTotal = 0;
		checked
		{
			int num = dg.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dg.Rows[i].Selected)
				{
					ref int qBorneUS = ref mQuantBornes.qBorneUS;
					qBorneUS = Conversions.ToInteger(Operators.AddObject(qBorneUS, dg.Rows[i].Cells[3].Value));
					ref int qBorneRS = ref mQuantBornes.qBorneRS;
					qBorneRS = Conversions.ToInteger(Operators.AddObject(qBorneRS, dg.Rows[i].Cells[4].Value));
					mQuantBornes.qBorneTS = mQuantBornes.qBorneUS + mQuantBornes.qBorneRS;
					ref int qBorneUD = ref mQuantBornes.qBorneUD;
					qBorneUD = Conversions.ToInteger(Operators.AddObject(qBorneUD, dg.Rows[i].Cells[5].Value));
					ref int qBorneRD = ref mQuantBornes.qBorneRD;
					qBorneRD = Conversions.ToInteger(Operators.AddObject(qBorneRD, dg.Rows[i].Cells[6].Value));
					mQuantBornes.qBorneTD = mQuantBornes.qBorneUD + mQuantBornes.qBorneRD;
					mQuantBornes.qBorneTotal = mQuantBornes.qBorneTS + mQuantBornes.qBorneTD;
				}
			}
		}
	}

	public static void carregaEstatisticaNoDG(ref DataGridView dg, Declaracoes2.StructureModeloDeReguas[] mMODELO, string sPesquisa)
	{
		try
		{
			dg.Rows.Clear();
			dg.Columns.Clear();
			dg.Columns.Add("IndiceRegua", "#");
			dg.Columns.Add("Painel", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1081]));
			dg.Columns.Add("Regua", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1043]));
			dg.Columns.Add("UsoS", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1078]));
			dg.Columns.Add("ResS", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1049]));
			dg.Columns.Add("UsoD", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1079]));
			dg.Columns.Add("ResD", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1049]));
			dg.Columns.Add("Total", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1080]));
			dg.ColumnHeadersVisible = true;
			if (Information.UBound(mMODELO) > 0)
			{
				int num = Information.UBound(mMODELO);
				for (int i = 1; i <= num; i = checked(i + 1))
				{
					string text = Dicionario.BuscaNomeDoPainel(mMODELO[i].indexPainel);
					if (LikeOperator.LikeString(text.ToString().ToUpper(), "*" + sPesquisa.ToUpper() + "*", CompareMethod.Text) | LikeOperator.LikeString(mMODELO[i].nomeRegua.ToUpper(), "*" + sPesquisa.ToUpper() + "*", CompareMethod.Text))
					{
						dg.Rows.Add(mMODELO[i].indexRegua, Dicionario.BuscaNomeDoPainel(mMODELO[i].indexPainel), mMODELO[i].nomeRegua, mMODELO[i].quantBornesS, mMODELO[i].quantBornesSRes, mMODELO[i].quantBornesD, mMODELO[i].quantBornesDRes, mMODELO[i].quantBornesRegua);
					}
				}
			}
			foreach (DataGridViewRow item in (IEnumerable)dg.Rows)
			{
				dg.Rows[item.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			}
			AtualizaColunasDGEstatistica(ref dg);
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

	public static void AtualizaColunasDGEstatistica(ref DataGridView dg)
	{
		checked
		{
			if (dg.RowCount != 0)
			{
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg)) ? ((double)(dg.Width - 4)) : ((double)(dg.Width - 21)));
				dg.Columns[0].Width = 0;
				dg.Columns[1].Width = (int)Math.Round(num * 0.25);
				dg.Columns[2].Width = (int)Math.Round(num * 0.2);
				dg.Columns[3].Width = (int)Math.Round(num * 0.1);
				dg.Columns[4].Width = (int)Math.Round(num * 0.1);
				dg.Columns[5].Width = (int)Math.Round(num * 0.1);
				dg.Columns[6].Width = (int)Math.Round(num * 0.1);
				dg.Columns[7].Width = (int)Math.Round(num * 0.15);
				dg.Columns[0].Visible = false;
				dg.Columns[1].Visible = true;
				dg.Columns[2].Visible = true;
				dg.Columns[3].Visible = true;
				dg.Columns[4].Visible = true;
				dg.Columns[5].Visible = true;
				dg.Columns[6].Visible = true;
				dg.Columns[7].Visible = true;
				dg.Columns[0].ReadOnly = false;
				dg.Columns[1].ReadOnly = false;
				dg.Columns[2].ReadOnly = false;
				dg.Columns[3].ReadOnly = false;
				dg.Columns[4].ReadOnly = false;
				dg.Columns[5].ReadOnly = false;
				dg.Columns[6].ReadOnly = false;
				dg.Columns[7].ReadOnly = false;
				dg.MultiSelect = true;
				int num2 = dg.Rows.Count - 1;
				for (int i = 0; i <= num2; i++)
				{
					dg.Rows[i].Selected = true;
				}
			}
		}
	}

	public static void SomaOsBornes(ref Declaracoes2.StructureModeloDeReguas[] mModBornes)
	{
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
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected Obj, but got Unknown
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
							if (Operators.CompareString(left, "B", TextCompare: true) != 0)
							{
								continue;
							}
							BlockReference blockRef = (BlockReference)ent;
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
							ent = (Entity)(object)blockRef;
							DeclaracoesEntidades.StructureBorne structureBorne = ((obj == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj));
							int num = Information.UBound(mModBornes);
							for (int i = 1; i <= num; i++)
							{
								if (mModBornes[i].indexRegua == structureBorne.IndiceRegua)
								{
									if (structureBorne.tipo != 0)
									{
										mModBornes[i].quantBornesD++;
									}
									else
									{
										mModBornes[i].quantBornesS++;
									}
									mModBornes[i].quantBornesRegua++;
								}
							}
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
					int num2 = Information.UBound(mModBornes);
					for (int j = 1; j <= num2; j++)
					{
						DeclaracoesEntidades.StructureBorne[] array = null;
						array = new DeclaracoesEntidades.StructureBorne[1];
						int qSimples = 0;
						int qDuplo = 0;
						DicionarioBorne.LeDicBornesReserva(mModBornes[j].indexRegua, ref array, ref qSimples, ref qDuplo);
						mModBornes[j].quantBornesSRes += qSimples;
						mModBornes[j].quantBornesDRes += qDuplo;
						mModBornes[j].quantBornesRegua = mModBornes[j].quantBornesS + mModBornes[j].quantBornesSRes + mModBornes[j].quantBornesD + mModBornes[j].quantBornesDRes;
					}
					if (Information.UBound(mModBornes) >= 2 && Information.UBound(mModBornes) > 0)
					{
						int num3 = Information.UBound(mModBornes) - 1;
						for (int k = num3; k >= 1; k += -1)
						{
							int num4 = k;
							for (int l = 1; l <= num4; l++)
							{
								if (Operators.CompareString(mModBornes[l].nomeRegua, mModBornes[l + 1].nomeRegua, TextCompare: true) > 0)
								{
									Declaracoes2.StructureModeloDeReguas structureModeloDeReguas = mModBornes[l + 1];
									mModBornes[l + 1] = mModBornes[l];
									mModBornes[l] = structureModeloDeReguas;
								}
								if (Operators.CompareString(mModBornes[l].nomeRegua, mModBornes[l + 1].nomeRegua, TextCompare: true) == 0 && Operators.CompareString(Dicionario.BuscaNomeDoPainel(mModBornes[l].indexPainel), Dicionario.BuscaNomeDoPainel(mModBornes[l + 1].indexPainel), TextCompare: true) > 0)
								{
									Declaracoes2.StructureModeloDeReguas structureModeloDeReguas = mModBornes[l + 1];
									mModBornes[l + 1] = mModBornes[l];
									mModBornes[l] = structureModeloDeReguas;
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
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}

	public static void EncontraReguasUsadasNoCaderno(ref List<string> lReguasUsadas)
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected Obj, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected Obj, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected Obj, but got Unknown
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected Obj, but got Unknown
		Declaracoes2.StructureModeloDeReguas[] mModelo = new Declaracoes2.StructureModeloDeReguas[1];
		DicionarioReguas.LeOsModelosDeRegua(ref mModelo);
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
							if (Operators.CompareString(left, "B", TextCompare: true) != 0)
							{
								continue;
							}
							BlockReference blockRef = (BlockReference)ent;
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
							ent = (Entity)(object)blockRef;
							DeclaracoesEntidades.StructureBorne structureBorne = ((obj == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj));
							int num = Information.UBound(mModelo);
							for (int i = 1; i <= num; i++)
							{
								if (mModelo[i].indexRegua == structureBorne.IndiceRegua && !lReguasUsadas.Contains(Conversions.ToString(mModelo[i].indexPainel) + "," + Conversions.ToString(mModelo[i].indexRegua)))
								{
									lReguasUsadas.Add(Conversions.ToString(mModelo[i].indexPainel) + "," + Conversions.ToString(mModelo[i].indexRegua));
								}
							}
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
					int num2 = Information.UBound(mModelo);
					for (int j = 1; j <= num2; j++)
					{
						DeclaracoesEntidades.StructureBorne[] array = null;
						array = new DeclaracoesEntidades.StructureBorne[1];
						int qSimples = 0;
						int qDuplo = 0;
						DicionarioBorne.LeDicBornesReserva(mModelo[j].indexRegua, ref array, ref qSimples, ref qDuplo);
						if (Information.UBound(array) > 0 && !lReguasUsadas.Contains(Conversions.ToString(mModelo[j].indexPainel) + "," + Conversions.ToString(mModelo[j].indexRegua)))
						{
							lReguasUsadas.Add(Conversions.ToString(mModelo[j].indexPainel) + "," + Conversions.ToString(mModelo[j].indexRegua));
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

	public static void carregaOsPaineisEmUsoNoDG(ref DataGridView dg, Declaracoes2.StructureModeloDeReguas[] mMODELO, int iPainel, string sPesquisa)
	{
		PnUso[] array = new PnUso[1];
		checked
		{
			try
			{
				string text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 768]);
				int num = 0;
				int num2 = 0;
				if (Information.IsNothing(DeclaracoesGeral.dicPainel))
				{
					cDadosAccess.carregaPainelDicionario();
				}
				bool flag = true;
				foreach (KeyValuePair<int, string> item in DeclaracoesGeral.dicPainel)
				{
					text = item.Value;
					flag = true;
					int num3 = Information.UBound(array);
					for (int i = 0; i <= num3; i++)
					{
						if (Operators.CompareString(array[i].spainel, text, TextCompare: true) == 0)
						{
							flag = false;
						}
					}
					if (flag && LikeOperator.LikeString(text.ToString().ToUpper(), "*" + sPesquisa.ToUpper() + "*", CompareMethod.Text))
					{
						num = Dicionario.BuscaIndiceDoPainel(text);
						num2 = Information.UBound(array) + 1;
						array = (PnUso[])Utils.CopyArray(array, new PnUso[num2 + 1]);
						array[num2].index = num;
						array[num2].spainel = text;
						array[num2].uso = 1;
					}
				}
				dg.Rows.Clear();
				dg.Columns.Clear();
				dg.Columns.Add("Indice", "");
				dg.Columns.Add("Painel", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1085]));
				dg.Columns.Add("uso", "");
				dg.ColumnHeadersVisible = true;
				int num4 = Information.UBound(array);
				for (int j = 0; j <= num4; j++)
				{
					if (Operators.CompareString(array[j].spainel, "", TextCompare: true) != 0)
					{
						dg.Rows.Add(array[j].index, array[j].spainel, array[j].uso);
					}
				}
				if (dg.RowCount <= 0)
				{
					dg.Rows.Clear();
					dg.Columns.Clear();
				}
				else
				{
					if (dg.RowCount == 0)
					{
						return;
					}
					double a = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg)) ? ((double)(dg.Width - 4)) : ((double)(dg.Width - 21)));
					dg.Columns[0].Width = 0;
					dg.Columns[1].Width = (int)Math.Round(a);
					dg.Columns[2].Width = 0;
					dg.Columns[0].Visible = false;
					dg.Columns[1].Visible = true;
					dg.Columns[2].Visible = false;
					dg.Columns[0].ReadOnly = false;
					dg.Columns[1].ReadOnly = false;
					dg.Columns[2].ReadOnly = false;
					dg.MultiSelect = false;
					DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
					dataGridViewCellStyle.BackColor = Color.LightCoral;
					int num5 = dg.Rows.Count - 1;
					for (int k = 0; k <= num5; k++)
					{
						num2 = Conversions.ToInteger(dg.Rows[k].Cells[0].Value);
						if (verificaSePossuiRegua(mMODELO, num2))
						{
							dg.Rows[k].Cells[2].Value = 0;
						}
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				dg.Rows.Clear();
				dg.Columns.Clear();
				ProjectData.ClearProjectError();
			}
		}
	}

	public static bool verificaSePossuiRegua(Declaracoes2.StructureModeloDeReguas[] mMODELO, int iPainel)
	{
		bool result = false;
		try
		{
			if (Information.UBound(mMODELO) > 0)
			{
				int num = Information.UBound(mMODELO);
				for (int i = 1; i <= num; i = checked(i + 1))
				{
					if (iPainel == mMODELO[i].indexPainel)
					{
						result = true;
						break;
					}
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = false;
			ProjectData.ClearProjectError();
		}
		finally
		{
		}
		return result;
	}

	public static void carregaAsReguasNoDG(ref DataGridView dg, Declaracoes2.StructureModeloDeReguas[] mMODELO, string sPesquisa)
	{
		try
		{
			dg.Rows.Clear();
			dg.Columns.Clear();
			if (Information.UBound(mMODELO) <= 0)
			{
				return;
			}
			dg.Columns.Add("IndiceRegua", "#");
			dg.Columns.Add("Painel", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1081]));
			dg.Columns.Add("ReguaAlternativa", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1117]));
			dg.Columns.Add("Regua", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1043]));
			dg.ColumnHeadersVisible = true;
			int num = Information.UBound(mMODELO);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				string text = Dicionario.BuscaNomeDoPainel(mMODELO[i].indexPainel);
				if (LikeOperator.LikeString(text.ToString().ToUpper(), "*" + sPesquisa.ToUpper() + "*", CompareMethod.Text) | LikeOperator.LikeString(mMODELO[i].nomeRegua.ToUpper(), "*" + sPesquisa.ToUpper() + "*", CompareMethod.Text))
				{
					dg.Rows.Add(mMODELO[i].indexRegua, text, mMODELO[i].nomeAlternativo, mMODELO[i].nomeRegua);
				}
			}
			if (dg.RowCount > 0)
			{
				AtualizaColunasDGReguaDeBornes(ref dg);
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

	public static int carregaAsReguasDoPainelNoDG(ref DataGridView dg, Declaracoes2.StructureModeloDeReguas[] mMODELO, int iPainel)
	{
		int result = 1;
		checked
		{
			try
			{
				dg.Rows.Clear();
				dg.Columns.Clear();
				dg.Columns.Add("IndiceRegua", "#");
				dg.Columns.Add("Regua", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1043]));
				dg.Columns.Add("ReguaAlternativa", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1117]));
				dg.Columns.Add("IndicePainel", "#");
				dg.Columns.Add("Painel", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1081]));
				dg.ColumnHeadersVisible = true;
				if (Information.UBound(mMODELO) > 0)
				{
					int num = Information.UBound(mMODELO);
					for (int i = 1; i <= num; i++)
					{
						if ((iPainel == 0) | (iPainel == mMODELO[i].indexPainel))
						{
							dg.Rows.Add(mMODELO[i].indexRegua, mMODELO[i].nomeRegua, mMODELO[i].nomeAlternativo, mMODELO[i].indexPainel, Dicionario.BuscaNomeDoPainel(mMODELO[i].indexPainel));
							result = 0;
						}
					}
				}
				if (dg.RowCount != 0)
				{
					double num2 = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg)) ? ((double)(dg.Width - 4)) : ((double)(dg.Width - 21)));
					dg.Columns[0].Width = (int)Math.Round(num2 / 4.0);
					dg.Columns[1].Width = (int)Math.Round(num2 * 3.0 / 4.0);
					dg.Columns[2].Width = 0;
					dg.Columns[3].Width = 0;
					dg.Columns[4].Width = 0;
					dg.Columns[0].Visible = true;
					dg.Columns[1].Visible = true;
					dg.Columns[2].Visible = false;
					dg.Columns[3].Visible = false;
					dg.Columns[4].Visible = false;
					dg.Columns[0].ReadOnly = false;
					dg.Columns[1].ReadOnly = false;
					dg.Columns[2].ReadOnly = false;
					dg.Columns[3].ReadOnly = false;
					dg.Columns[4].ReadOnly = false;
					dg.MultiSelect = true;
				}
				else
				{
					dg.Rows.Clear();
					dg.Columns.Clear();
					result = 1;
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
			int num3 = dg.Rows.Count - 1;
			for (int j = 0; j <= num3; j++)
			{
				dg.Rows[j].Selected = false;
			}
			return result;
		}
	}

	public static void AtualizaColunasDGReguaDeBornes(ref DataGridView dg)
	{
		checked
		{
			if (dg.RowCount != 0)
			{
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg)) ? ((double)(dg.Width - 4)) : ((double)(dg.Width - 21)));
				dg.Columns[0].Width = 0;
				dg.Columns[1].Width = (int)Math.Round(num * 0.5);
				dg.Columns[2].Width = 0;
				dg.Columns[3].Width = (int)Math.Round(num * 0.5);
				dg.Columns[0].Visible = false;
				dg.Columns[1].Visible = true;
				dg.Columns[2].Visible = false;
				dg.Columns[3].Visible = true;
				dg.Columns[0].ReadOnly = false;
				dg.Columns[1].ReadOnly = false;
				dg.Columns[2].ReadOnly = false;
				dg.Columns[3].ReadOnly = false;
				dg.MultiSelect = true;
			}
		}
	}
}
